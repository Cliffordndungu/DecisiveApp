using DecisiveApp.Data.Services;
using DecisiveApp.Data;
using DecisiveApp.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace DecisiveApp.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDBContext _context;
        public OrdersService(AppDBContext context)
        {
            _context = context;
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
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    serviceid = item.service.id,
                    Orderid = order.id,
                    Price = item.service.id
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}

   

   

   
