using _01_Assigment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Assigment.Models
{
    public class OrderRequest
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public ICollection<ProductEntity> Products { get; set; }
        public ICollection<CustomerEntity> Customer { get; set; }
    }
}
