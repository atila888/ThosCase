namespace ThosCase.DAL.BusinessObjects.Response.Category
{
    public class CategoryResponse
    {
        public int Categoryid { get; set; }

        public string Categoryname { get; set; }

        public int Parentcategoryid { get; set; }
        public DateTime Createddate { get; set; }
        public int Creatoruserid { get; set; }
    }
}
