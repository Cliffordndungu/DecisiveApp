using DecisiveApp.Data.Services;
using DecisiveApp.Data;
using DecisiveApp.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using DecisiveApp.Data.Settings;
using DecisiveApp.Data.Enums;

namespace DecisiveApp.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDBContext _context;
        private readonly TenantSettings _tenantSettings;
        public OrdersService(AppDBContext context, TenantSettings tenantSettings)
        {
            _context = context;
            _tenantSettings = tenantSettings;
        }
        public async Task<List<Orders>> GetOrdersAsync()
        {
            var orders = await _context.Orders.Include(n => n.orderItems).ThenInclude(n => n.Service).ToListAsync();

            return orders;
        }


        public async Task StoreOrderAsync(List<ShoppingCartItem> items)
        {
            var order = new Orders()
            {
                userid = "",
                Email = ""

            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                if (item.service.HasTrial == "1")
                {

                    var orderItem = new OrderItem()
                    {
                        Amount = item.Amount,
                        serviceid = item.service.id,
                        Orderid = order.id,
                        Price = item.service.Price,
                        Startdate = DateTime.Now,
                        Nextbillingdate = DateTime.Now.AddDays(30),
                        status = "active",
                        lastpaymentdate = "",
                        billingcycle = BillingCycle.Monthly


                    };
                    string userid = "";
                    await _context.OrderItems.AddAsync(orderItem);
                    await _tenantSettings.UpdateTenantByidAsync(userid, item.service.id, item.Amount);
                }
               
               
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTenantAsync(string userid, int amount)
        {
            var tenant = await _context.Tenants.FirstOrDefaultAsync(t => t.userid == userid);

            if (tenant != null)
            {

                tenant.ABWorkstations = amount;
                await _context.SaveChangesAsync();
            }


        }
    }
}

   

   

   
