using System;
using System.Collections.Generic;

namespace ThosCase.Data.Models.Context;

public partial class User
{
    public int Userid { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Username { get; set; }

    public string? Hashpassword { get; set; }

    public string? Saltpassword { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
