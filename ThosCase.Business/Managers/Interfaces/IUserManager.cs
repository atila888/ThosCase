using ThosCase.DAL.BusinessObjects.Request.User;
using ThosCase.DAL.BusinessObjects.Response.User;

namespace ThosCase.Business.Managers.Interfaces
{
    public interface IUserManager
    {
        Task<List<UserResponse>> GetAllUser();
        Task<bool> SaveAsync(UserSaveRequest userSaveRequest);
        Task<bool> UpdateAsync(UserUpdateRequest userUpdateRequest);
        Task<bool> DeleteAsync(int id);
    }
}
