using DataLIbrary.Models;
using System.Threading.Tasks;

namespace DataLIbrary.Data
{
    public interface IOrderData
    {
        Task<int> CreateOrder(OrderModel order);
        Task<int> DeleteOrder(int orderID);
        Task<OrderModel> GetOrderById(int orderId);
        Task<int> UpdateOrderName(int orderID, string orderName);
    }
}