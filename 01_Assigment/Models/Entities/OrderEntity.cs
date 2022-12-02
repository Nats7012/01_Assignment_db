using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Assigment.Models.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public ICollection<ProductEntity> Products { get; set; }
        public CustomerEntity Customer { get; set; } = null!;
    }
}
