using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Post
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryID { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool Status { get; set; }

        //public virtual PostCategory Category { get; set; } = null!;
    }
}
