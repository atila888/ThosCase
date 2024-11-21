using System;
using System.Collections.Generic;

namespace ThosCase.Data.Models.Context;

public partial class Product : Entity
{
    public int Productid { get; set; }

    public string? Producname { get; set; }

    public int? Categoryid { get; set; }

    public decimal? Price { get; set; }

    public string? Imagepath { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User Creatoruser { get; set; } = null!;

    public virtual ICollection<Productproperty> Productproperties { get; set; } = new List<Productproperty>();
}
