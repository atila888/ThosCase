using Microsoft.AspNetCore.Mvc;
using ThosCase.Business.Core;
using ThosCase.Business.Helper.DataTable;
using ThosCase.DAL.BusinessObjects.Request.User;
using ThosCase.DAL.BusinessObjects.Response.User;

namespace ThosCase.Controllers
{
    public class UserController : BaseController
    {
        public UserController(BusinessManagerFactory businessManagerFactory) : base(businessManagerFactory)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewUser()
        {
            return View();
        }
        [HttpGet]
        public async Task<List<UserResponse>> GetAllUser()
        {
            var result = await BusinessManagerFactory.UserManager.GetAllUser();

            return result;
        }

        [HttpGet]
        public async Task<DatatableResponse<UserResponse>> Get(JqueryDatatableParam param)
        {
            var data = await BusinessManagerFactory.UserManager.GetAllUser();
            var result = BusinessManagerFactory.DataTable.GetForDataTable(data, param);

            return result;
        }
        [HttpPost]
        public async Task<bool> Save(UserSaveRequest userSaveRequest)
        {
            var result = await BusinessManagerFactory.UserManager.SaveAsync(userSaveRequest);

            return result;
        }
        [HttpPost]
        public async Task<bool> Update(UserUpdateRequest userUpdateRequest)
        {
            var result = await BusinessManagerFactory.UserManager.UpdateAsync(userUpdateRequest);

            return result;
        }
        [HttpPost]
        public async Task<bool> Delete(int id)
        {
            var result = await BusinessManagerFactory.UserManager.DeleteAsync(id);

            return result;
        }
    }
}
