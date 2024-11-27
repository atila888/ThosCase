using Microsoft.AspNetCore.Mvc;
using ThosCase.Business.Core;
using ThosCase.Business.Helper.DataTable;
using ThosCase.DAL.BusinessObjects.Request.Product;
using ThosCase.DAL.BusinessObjects.Response.Product;

namespace ThosCase.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(BusinessManagerFactory businessManagerFactory) : base(businessManagerFactory)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewProduct()
        {
            return View();
        }
        [HttpGet]
        public async Task<List<ProductResponse>> GetAllProduct()
        {
            var result = await BusinessManagerFactory.ProductManager.GetAllProduct();

            return result;
        }

        [HttpGet]
        public async Task<DatatableResponse<ProductResponse>> Get(JqueryDatatableParam param)
        {
            var data = await BusinessManagerFactory.ProductManager.GetAllProduct();
            var result = BusinessManagerFactory.DataTable.GetForDataTable(data, param);

            return result;
        }
        [HttpPost]
        public async Task<bool> Save(ProductSaveRequest productSaveRequest)
        {
            var result = await BusinessManagerFactory.ProductManager.SaveAsync(productSaveRequest);

            return result;
        }
        [HttpPost]
        public async Task<bool> Update(ProductUpdateRequest productUpdateRequest)
        {
            var result = await BusinessManagerFactory.ProductManager.UpdateAsync(productUpdateRequest);

            return result;
        }
        [HttpPost]
        public async Task<bool> Delete(int id)
        {
            var result = await BusinessManagerFactory.ProductManager.DeleteAsync(id);

            return result;
        }
    }
}
