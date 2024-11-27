using AutoMapper;
using ThosCase.Business.Managers.Interfaces;
using ThosCase.DAL.BusinessObjects.Request.Product;
using ThosCase.DAL.BusinessObjects.Response.Product;
using ThosCase.DAL.BusinessObjects.Validators;
using ThosCase.DAL.Repositories.Interface;
using ThosCase.Data.Models.Context;

namespace ThosCase.Business.Managers.Implementations
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public ProductManager(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<List<ProductResponse>> GetAllProduct()
        {
            List<ProductResponse> productResponses = new List<ProductResponse>();

            var result = await _productRepository.FindAsync(x => x.Isdeleted == false);
            _mapper.Map(result.ToList(), productResponses);

            return productResponses;
        }
        public async Task<bool> SaveAsync(ProductSaveRequest productSaveRequest)
        {
            productSaveRequest.Validate(_productRepository, _categoryRepository);

            var product = new Product();
            _mapper.Map(productSaveRequest, product);
            try
            {
                await _productRepository.AddAsync(product);
                _productRepository.SaveAsync();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Kategori Kaydedilirken hata ile karşılaşıldı.");
            }
        }
        public async Task<bool> UpdateAsync(ProductUpdateRequest productUpdateRequest)
        {
            productUpdateRequest.Validate(_productRepository, _categoryRepository);

            try
            {
                var product = await _productRepository.FirstOrDefaultAsync(x => x.Productid == productUpdateRequest.Productid);
                _mapper.Map(productUpdateRequest, product);
                _productRepository.SaveAsync();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Kategori Güncellenirken hata ile karşılaşıldı.");
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    var product = await _productRepository.FirstOrDefaultAsync(x => x.Productid == id);
                    if (product != null)
                    {
                        product.Isdeleted = true;
                        _productRepository.SaveAsync();

                        return true;
                    }
                }
                return false;

            }
            catch (Exception)
            {
                throw new Exception("Ürün Silinirken hata ile karşılaşıldı.");
            }
        }
    }
}
