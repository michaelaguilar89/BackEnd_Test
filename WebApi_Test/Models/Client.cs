using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi_Test.Models
{
    public partial class Client
    {
        public Client()
        {
            Sales = new HashSet<Sale>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string Phone { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Direction { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
