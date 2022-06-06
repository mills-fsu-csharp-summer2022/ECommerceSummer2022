using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.eCommerce.Models
{
    public class Product
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Id { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return Quantity * Price;
            }
        }

        public override string ToString()
        {
            return $"{Id} {TotalPrice} {Name}: {Description}";
        }
    }
}
