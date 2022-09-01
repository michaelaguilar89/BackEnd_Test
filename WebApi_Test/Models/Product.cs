using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi_Test.Models
{
    public partial class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public decimal CostPrice { get; set; }
        [Required]
        public decimal SalePrice { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
