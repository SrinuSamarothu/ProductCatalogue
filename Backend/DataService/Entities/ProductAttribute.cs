using System;
using System.Collections.Generic;

namespace DataService.Entities;

public partial class ProductAttribute
{
    public string AttributeId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
