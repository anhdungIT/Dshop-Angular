using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class ApplicationUser
    {
        public ApplicationUser()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
