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
    public partial class ProductDTO : IMapFrom<Product>
    {
        public int ProductId { get; set; }

        public int? CategoryId { get; set; }

        public string? ProductName { get; set; }

        public decimal? ProductPrice { get; set; }

        public int? ProductStock { get; set; }

        public bool? ProductStatus { get; set; }

        public virtual CategoryDTO? Category { get; set; }
    }
}
