using System;
using System.Collections.Generic;

namespace WebApi_Test.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public string? NameProduct { get; set; }
        public string? Description { get; set; }
        public decimal SalePriceProduct { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        public int IdClient { get; set; }
        public string? ClientFirstName { get; set; }
        public string? ClientLastName { get; set; }
        public int IdUser { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }

        public virtual Client IdClientNavigation { get; set; } = null!;
        public virtual Product IdProductNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
