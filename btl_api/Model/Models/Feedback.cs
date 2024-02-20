using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
