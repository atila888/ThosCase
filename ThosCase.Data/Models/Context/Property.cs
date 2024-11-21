using System;
using System.Collections.Generic;

namespace ThosCase.Data.Models.Context;

public partial class Property
{
    public int Propertyid { get; set; }

    public string? Key { get; set; }

    public string? Value { get; set; }

    public virtual ICollection<Productproperty> Productproperties { get; set; } = new List<Productproperty>();
}
