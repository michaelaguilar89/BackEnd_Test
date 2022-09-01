using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi_Test.Models
{
    public partial class Client_DTO

    {
      
        public int Id { get; set; }
       
        public string FirstName { get; set; } = null!;
      
        public string LastName { get; set; } = null!;
        
        public string Phone { get; set; } = null!;
    
        public string Email { get; set; } = null!;
   
        public string Direction { get; set; } = null!;

        }
}
