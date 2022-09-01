using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi_Test.Models
{
    public partial class Sale
    {
        [Key]       
        public int Id { get; set; }
        [Required]
        public int IdProduct { get; set; }
        [Required]
        public string? NameProduct { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public decimal SalePriceProduct { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public int IdClient { get; set; }
        [Required]
        public string? ClientFirstName { get; set; }
        [Required]
        public string? ClientLastName { get; set; }
        [Required]
        public int IdUser { get; set; }
        [Required]
        public string? UserFirstName { get; set; }
        [Required]
        public string? UserLastName { get; set; }
        

        public virtual Client IdClientNavigation { get; set; } = null!;
        public virtual Product IdProductNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
