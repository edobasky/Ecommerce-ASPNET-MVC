using eTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IOrdersService
    {
        //Add orders to the database
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);

        //get Store orders to Db
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
