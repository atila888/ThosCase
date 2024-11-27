using ThosCase.DAL.BusinessObjects.Request.Category;
using ThosCase.DAL.BusinessObjects.Response.Category;

namespace ThosCase.Business.Managers.Interfaces
{
    public interface ICategoryManager
    {
        Task<List<CategoryResponse>> GetAllCategory();
        Task<bool> SaveAsync(CategorySaveRequest categorySaveRequest);
        Task<bool> UpdateAsync(CategoryUpdateRequest categoryUpdateRequest);
        Task<bool> DeleteAsync(int id);
    }
}
