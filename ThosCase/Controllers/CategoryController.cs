using Microsoft.AspNetCore.Mvc;
using ThosCase.Business.Core;
using ThosCase.Business.Helper.DataTable;
using ThosCase.DAL.BusinessObjects.Request.Category;
using ThosCase.DAL.BusinessObjects.Response.Category;

namespace ThosCase.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(BusinessManagerFactory businessManagerFactory) : base(businessManagerFactory)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewCategory()
        {
            return View();
        }
        [HttpGet]
        public async Task<List<CategoryResponse>> GetAllCategory()
        {
            var result = await BusinessManagerFactory.CategoryManager.GetAllCategory();

            return result;
        }

        [HttpGet]
        public async Task<DatatableResponse<CategoryResponse>> Get(JqueryDatatableParam param)
        {
            var data = await BusinessManagerFactory.CategoryManager.GetAllCategory();
            var result = BusinessManagerFactory.DataTable.GetForDataTable(data, param);

            return result;
        }
        [HttpPost]
        public async Task<bool> Save(CategorySaveRequest categorySaveRequest)
        {
            var result = await BusinessManagerFactory.CategoryManager.SaveAsync(categorySaveRequest);

            return result;
        }
        [HttpPost]
        public async Task<bool> Update(CategoryUpdateRequest categoryUpdateRequest)
        {
            var result = await BusinessManagerFactory.CategoryManager.UpdateAsync(categoryUpdateRequest);

            return result;
        }
        [HttpPost]
        public async Task<bool> Delete(int id)
        {
            var result = await BusinessManagerFactory.CategoryManager.DeleteAsync(id);

            return result;
        }
    }
}
