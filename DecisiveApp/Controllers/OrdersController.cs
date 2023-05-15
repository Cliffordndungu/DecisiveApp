using DecisiveApp.Data.Cart;
using DecisiveApp.Data.Services;
using DecisiveApp.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DecisiveApp.Controllers
{
    public class OrdersController : Controller
    {
            private readonly IServiceService _serviceService;
            private readonly ShoppingCart _shoppingcart;
            private readonly IOrdersService _ordersService;
            public OrdersController(IServiceService serviceService, ShoppingCart shoppingcart, IOrdersService orderservice)
            {
                _serviceService = serviceService;
                _shoppingcart = shoppingcart;
                _ordersService = orderservice;
            }

        public async Task<IActionResult> Index()
        {
            string userId = "";
            string userRole ="";


            var orders = await _ordersService.GetOrdersAsync();
            return View(orders);
        }
        public async Task<RedirectToActionResult> AddItemToShoppingCart(int id)
            {
                var item = await _serviceService.GetServicesByidAsync(id);

                if (item != null)
                {
                    _shoppingcart.AddItemToCart(item);
                }
                return RedirectToAction(nameof(ShoppingCart));
            }

            public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
            {
                var item = await _serviceService.GetServicesByidAsync(id);

                if (item != null)
                {
                    _shoppingcart.RemoveItemFromCart(item);
                }
                return RedirectToAction(nameof(ShoppingCart));
            }

            public IActionResult ShoppingCart()
            {
                var items = _shoppingcart.GetShoppingCartItems();
                _shoppingcart.ShoppingCartItems = items;

                var response = new ShoppingCartVM()
                {
                    ShoppingCart = _shoppingcart,
                    ShoppingCartTotal = _shoppingcart.GetShoppingCartTotal()
                };

                return View(response);
            }

            public async Task<IActionResult> CompleteOrder()
            {
                var items = _shoppingcart.GetShoppingCartItems();
                string userId = "";
                string userEmailAddress = "";

                await _ordersService.StoreOrderAsync(items);
                await _shoppingcart.ClearShoppingCartAsync();

                return View("OrderCompleted");
            }
        }
    }


