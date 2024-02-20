using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Order
    {
        ////public Order()
        ////{
        ////    OrderDetails = new HashSet<OrderDetail>();
        ////}

        public int IDorder { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerAddress { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string CustomerMobile { get; set; } = null!;
        public string CustomerMessage { get; set; } = null!;
        public string? PaymentMethod { get; set; }
        public DateTime? CreatedDate { get; set; }
      
        public bool Status { get; set; }
 

        //public virtual ApplicationUser Customer { get; set; } = null!;
        //public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
