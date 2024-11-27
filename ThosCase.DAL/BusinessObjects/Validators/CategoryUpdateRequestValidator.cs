using FluentValidation;
using ThosCase.DAL.BusinessObjects.Request.Category;
using ThosCase.DAL.Repositories.Interface;

namespace ThosCase.DAL.BusinessObjects.Validators
{
    internal class CategoryUpdateRequestValidator : AbstractValidator<CategoryUpdateRequest>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryUpdateRequestValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Categoryid).GreaterThan(-1);
            RuleFor(x => x.Categoryname).Must((model, result) =>
            {
                return CategoryIdSearch(model.Categoryid);
            }).WithMessage("Id Sistemde bulunamadı");

            RuleFor(x => x.Categoryname).NotNull().NotEmpty().WithMessage("Kategori Adı boş olamaz");
            RuleFor(x => x.Categoryname).Must((model, result) =>
            {
                return CategoryNameSearch(model.Categoryname);
            }).WithMessage("Kategori Adı Zaten Kullanılıyor");

            RuleFor(x => x.Parentcategoryid).GreaterThan(-1);
        }

        //VALIDASYONDA KULLANILAN PRIVATE DB METHODLAR
        #region PRIVATE METHODS
        private bool CategoryNameSearch(string categoryname)
        {
            var category = _categoryRepository.FirstOrDefault(x => x.Categoryname == categoryname);
            if (category != null)
                return false;
            return true;
        }
        private bool CategoryIdSearch(int categoryid)
        {
            if (categoryid != 0)
            {
                var category = _categoryRepository.FirstOrDefault(x => x.Categoryid == categoryid);

                if (category == null)
                    return false;
                return true;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
