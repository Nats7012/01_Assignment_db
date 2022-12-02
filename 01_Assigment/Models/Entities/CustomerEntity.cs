using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Assigment.Models.Entities
{
    public class CustomerEntity
    {
        public CustomerEntity()
        {

        }
        public CustomerEntity(string fullName, string email, string phone)
        {
            FullName = fullName;
            Email = email;
            Phone = phone;
        }
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public ICollection<OrderEntity> Order { get; set; }

    }
}
