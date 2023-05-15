using DecisiveApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DecisiveApp.Data.Cart
{
    public class ShoppingCart
    {
        public AppDBContext _context;
        public string ShoppingCartid { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }


        public ShoppingCart(AppDBContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartid = cartId };
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartid == ShoppingCartid).Include(n => n.service).ToList());
        }

        public void AddItemToCart(Service service)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.service.id == service.id && n.ShoppingCartid == ShoppingCartid);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartid = ShoppingCartid,
                    service = service,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Service service)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.service.id == service.id && n.ShoppingCartid == ShoppingCartid);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
        }
        public double GetShoppingCartTotal() => _context.ShoppingCartItems.Where(n => n.ShoppingCartid == ShoppingCartid).Select(n => n.service.Price * n.Amount).Sum();

        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartid == ShoppingCartid).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
