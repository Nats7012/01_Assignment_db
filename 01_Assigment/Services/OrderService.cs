using _01_Assigment.Models.Entities;
using _01_Assigment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Assigment.Data;
using Microsoft.AspNetCore.Mvc;

namespace _01_Assigment.Services
{
    public class OrderService
    {
        private readonly SqlContext _context;
        public OrderService(SqlContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> CreateOrderAsync(OrderRequest orderRequest)
        {
            try
            {
                var orderEntity = new OrderEntity()
                {
                    OrderDate = DateTime.Now,
                    CustomerId = orderRequest.CustomerId
                };
                _context.Orders.Add(orderEntity);
                await _context.SaveChangesAsync();

                foreach (var item in orderRequest.Products)
                    orderEntity.Products.Add(new ProductEntity { Id = item.Id });

                _context.Add(orderEntity);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            catch { return new BadRequestResult(); }
        }
    }
}
