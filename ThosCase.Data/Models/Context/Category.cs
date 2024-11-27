
namespace ThosCase.Data.Models.Context
{
    public partial class Category : Entity
    {
        public int Categoryid { get; set; }

        public string? Categoryname { get; set; }

        public int? Parentcategoryid { get; set; }
    }
}
