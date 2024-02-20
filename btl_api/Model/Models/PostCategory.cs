using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class PostCategory
    {
        //public PostCategory()
        //{
        //    Posts = new HashSet<Post>();
        //}

        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool Status { get; set; }

        //public virtual ICollection<Post> Posts { get; set; }
    }
}
