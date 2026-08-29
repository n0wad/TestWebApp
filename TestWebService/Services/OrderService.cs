using Microsoft.EntityFrameworkCore;
using TestWebService.Data;
using TestWebService.Models;

namespace TestWebService.Services
{
    public class OrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        { 
            _context = context;
        }

        /// <summary>
        /// Возвращает список всех заказов
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        /// <summary>
        /// Возвращает заказ по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Order?> GetOrderById(int id)
        {
            return await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        /// <summary>
        /// Создает заказ в базе
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Order> CreateOrder(OrderRequest request)
        {
            var order = new Order
            {
                OrderNumber = Guid.NewGuid().ToString().Substring(0, 8),
                SenderCity = request.SenderCity,
                SenderAddress = request.SenderAddress,
                ReceiverCity = request.ReceiverCity,
                ReceiverAddress = request.ReceiverAddress,
                Weight = request.Weight,
                PickupDate = request.PickupDate,
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        /// <summary>
        /// Удаляет заказ по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
                return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
