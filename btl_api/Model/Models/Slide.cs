using System;
using System.Collections.Generic;

namespace Model.Models 
{ 
    public partial class Slide
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Url { get; set; }
        public bool Status { get; set; }
    }
}
