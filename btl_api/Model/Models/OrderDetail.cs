using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class OrderDetail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantitty { get; set; }
        public int Price { get; set; }


        //public virtual Order Order { get; set; } = null!;
        //public virtual Product Product { get; set; } = null!;
    }
}
