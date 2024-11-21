using Microsoft.AspNetCore.Mvc;
using ThosCase.Business.Core;

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
    }
}
