using ThosCase.DAL.BusinessObjects.Request.Product;
using ThosCase.DAL.BusinessObjects.Response.Product;

namespace ThosCase.Business.Managers.Interfaces
{
    public interface IProductManager
    {
        Task<List<ProductResponse>> GetAllProduct();
        Task<bool> SaveAsync(ProductSaveRequest productSaveRequest);
        Task<bool> UpdateAsync(ProductUpdateRequest productUpdateRequest);
        Task<bool> DeleteAsync(int id);
    }
}
