using DemoStore.WebApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoStore.WebApi
{
    public partial class CategoryDTO : IMapFrom<Category>
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public bool? CategoryStatus { get; set; }

        public virtual ICollection<ProductDTO> Categories { get; set; } = new List<ProductDTO>();
    }
}
