using DecisiveApp.Models;

namespace DecisiveApp.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items);

        Task<List<Orders>> GetOrdersAsync();

      


        //Task<List<Orders>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
