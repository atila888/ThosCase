namespace ThosCase.DAL.BusinessObjects.Request.Category
{
    public class CategoryUpdateRequest
    {
        public int Categoryid { get; set; }
        public string Categoryname { get; set; }
        public int Parentcategoryid { get; set; }
    }
}
