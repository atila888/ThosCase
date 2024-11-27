namespace ThosCase.DAL.BusinessObjects.Request.Product
{
    public class ProductUpdateRequest
    {
        public int Productid { get; set; }
        public string Producname { get; set; }

        public int Categoryid { get; set; }

        public decimal Price { get; set; }

        public string Imagepath { get; set; }
    }
}
