using _01_Assigment.Models.Entities;
using _01_Assigment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Assigment.Data;
using Microsoft.AspNetCore.Mvc;

namespace _01_Assigment.Services
{
    public class ProductService
    {
        private readonly SqlContext _context;

        public ProductService(SqlContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> CreateAsync(ProductRequest req)
        {
            _context.Add(new ProductEntity(req.Name, req.Description, req.Price));
            await _context.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<List<ProductEntity>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductEntity> GetAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateAssync(ProductEntity product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();
        }
    }
}
