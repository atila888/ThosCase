using System;
using System.Collections.Generic;

namespace ThosCase.Data.Models.Context;

public partial class Category : Entity
{
    public int Categoryid { get; set; }

    public string? Categoryname { get; set; }

    public int? Parentcategoryid { get; set; }

    public virtual User Creatoruser { get; set; } = null!;

    public virtual ICollection<Category> InverseParentcategory { get; set; } = new List<Category>();

    public virtual Category? Parentcategory { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
