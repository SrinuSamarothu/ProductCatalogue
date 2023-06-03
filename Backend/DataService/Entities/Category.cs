﻿using System;
using System.Collections.Generic;

namespace DataService.Entities;

public partial class Category
{
    public string CategoryId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
