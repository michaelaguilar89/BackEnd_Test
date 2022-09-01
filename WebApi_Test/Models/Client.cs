using System;
using System.Collections.Generic;

namespace WebApi_Test.Models
{
    public partial class Client
    {
        public Client()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Direction { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
