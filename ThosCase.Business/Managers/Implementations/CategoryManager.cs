using AutoMapper;
using ThosCase.Business.Managers.Interfaces;
using ThosCase.DAL.BusinessObjects.Request.Category;
using ThosCase.DAL.BusinessObjects.Response.Category;
using ThosCase.DAL.BusinessObjects.Validators;
using ThosCase.DAL.Repositories.Interface;
using ThosCase.Data.Models.Context;

namespace ThosCase.Business.Managers.Implementations
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<CategoryResponse>> GetAllCategory()
        {
            List<CategoryResponse> categoryResponses = new List<CategoryResponse>();

            var result = await _categoryRepository.FindAsync(x => x.Isdeleted == false);
            _mapper.Map(result.ToList(), categoryResponses);

            return categoryResponses;
        }
        public async Task<bool> SaveAsync(CategorySaveRequest categorySaveRequest)
        {
            categorySaveRequest.Validate(_categoryRepository);

            var category = new Category();
            _mapper.Map(categorySaveRequest, category);
            try
            {
                await _categoryRepository.AddAsync(category);
                _categoryRepository.SaveAsync();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Kategori Kaydedilirken hata ile karşılaşıldı.");
            }
        }
        public async Task<bool> UpdateAsync(CategoryUpdateRequest categoryUpdateRequest)
        {
            categoryUpdateRequest.Validate(_categoryRepository);

            try
            {
                var category = await _categoryRepository.FirstOrDefaultAsync(x => x.Categoryid == categoryUpdateRequest.Categoryid);
                _mapper.Map(categoryUpdateRequest, category);
                _categoryRepository.SaveAsync();
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
                    var category = await _categoryRepository.FirstOrDefaultAsync(x => x.Categoryid == id);
                    if (category != null)
                    {
                        category.Isdeleted = true;
                        _categoryRepository.SaveAsync();

                        return true;
                    }
                }
                return false;

            }
            catch (Exception)
            {
                throw new Exception("Kategori Silinirken hata ile karşılaşıldı.");
            }
        }
    }
}
