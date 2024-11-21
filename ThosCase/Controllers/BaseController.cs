using Microsoft.AspNetCore.Mvc;
using ThosCase.Business.Core;

namespace ThosCase.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController(BusinessManagerFactory businessManagerFactory)
        {
            BusinessManagerFactory = businessManagerFactory;
        }
        public BusinessManagerFactory BusinessManagerFactory { get; }
    }
}
