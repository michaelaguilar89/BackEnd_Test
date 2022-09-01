using System;
using System.Collections.Generic;

namespace WebApi_Test.Models
{
    public partial class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
