using System;
using System.Collections.Generic;

namespace DataService.Entities;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Brand { get; set; }

    public int Price { get; set; }

    public int Quantity { get; set; }

    public string Description { get; set; } = null!;

    public string? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();
}
