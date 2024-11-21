using System;
using System.Collections.Generic;

namespace ThosCase.Data.Models.Context;

public partial class Productproperty
{
    public int Productpropertyid { get; set; }

    public int? Productid { get; set; }

    public int? Propertyid { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Property? Property { get; set; }
}
