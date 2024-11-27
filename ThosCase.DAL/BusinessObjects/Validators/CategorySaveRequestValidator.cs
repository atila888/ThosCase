using FluentValidation;
using ThosCase.DAL.BusinessObjects.Request.Category;
using ThosCase.DAL.Repositories.Interface;

namespace ThosCase.DAL.BusinessObjects.Validators
{
    internal class CategorySaveRequestValidator : AbstractValidator<CategorySaveRequest>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategorySaveRequestValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Categoryname).NotNull().NotEmpty().WithMessage("Kategori Adı boş olamaz");
            RuleFor(x => x.Categoryname).Must((model, result) =>
            {
                return CategoryNameSearch(model.Categoryname);
            }).WithMessage("Kategori Adı Zaten Kullanılıyor");

            RuleFor(x => x.Parentcategoryid).GreaterThan(-1);
        }
        //VALIDASYONDA KULLANILAN PRIVATE METHODLAR
        #region PRIVATE METHODS
        private bool CategoryNameSearch(string categoryname)
        {
            var category = _categoryRepository.FirstOrDefault(x => x.Categoryname == categoryname && x.Isdeleted == false);
            if (category != null)
                return false;
            return true;
        }
        #endregion
    }
}
