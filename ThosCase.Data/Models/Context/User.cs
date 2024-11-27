
namespace ThosCase.Data.Models.Context;

public partial class User
{
    public int Userid { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Username { get; set; }

    public string? Hashpassword { get; set; }

    public string? Saltpassword { get; set; }
}
