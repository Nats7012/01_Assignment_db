using _01_Assigment.Models.Entities;
using _01_Assigment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Assigment.Data;

namespace _01_Assigment.Services
{
    public class CustomerService
    {
        private readonly SqlContext _context;

        public CustomerService(SqlContext context)
        {
            _context = context;
        }

        public async Task Create(CustomerRequest req) //För att skapa 
        //* Går att göra: public async Task CreateAsync(CustomerRequest req)
        {
            var customerEntity = new CustomerEntity
            {
                FullName = req.FullName,
                Email = req.Email,
                Phone = req.Phone

            };
            _context.Add(customerEntity);
            //* _context.Add(new CustomerEntity(req.FullName, req.Email, req.Phone));
            await _context.SaveChangesAsync();
        }


        public async Task<List<CustomerEntity>> GetAllAsync() //För att visa alla
        {
            return await _context.Customers.ToListAsync();
        }


        public async Task<CustomerEntity> GetAsync(int id) // För att hämta en specifik kund genom att söka på ID
        {
            return await _context.Customers.FindAsync(id);
        }


        public async Task UpdateAsync(CustomerEntity customer) // För att uppdatera
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id) // För att hitta, ta bort och spara efteråt
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customerEntity);
            await _context.SaveChangesAsync();
        }

    }
}
