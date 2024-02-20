using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Product
    {
        //public Product()
        //{
        //    OrderDetails = new HashSet<OrderDetail>();
        //}

        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryID { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool Status { get; set; }
        public int? Warranty { get; set; }
        public int Quantity { get; set; }
        public decimal OriginalPrice { get; set; }

        //public virtual ProductCategory Category { get; set; } = null!;
        //public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
