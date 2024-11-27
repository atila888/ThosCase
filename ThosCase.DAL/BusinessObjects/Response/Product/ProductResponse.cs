namespace ThosCase.DAL.BusinessObjects.Response.Product
{
    public class ProductResponse
    {
        public int Productid { get; set; }

        public string Producname { get; set; }

        public int Categoryid { get; set; }

        public decimal Price { get; set; }

        public string Imagepath { get; set; }
        public DateTime Createddate { get; set; }
        public int Creatoruserid { get; set; }
    }
}
