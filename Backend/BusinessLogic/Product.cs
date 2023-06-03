using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Product
    {
        public string ProductId { get; set; }

        public string Name { get; set; }

        public string? Brand { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public string? CategoryId { get; set; }
    }
}
