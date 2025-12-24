using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoStore.WebUI
{
    public partial class Category
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public bool? CategoryStatus { get; set; }

        public virtual ICollection<Product> Categories { get; set; } = new HashSet<Product>();
    }
}
