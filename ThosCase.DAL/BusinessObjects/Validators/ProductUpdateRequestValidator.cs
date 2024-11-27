using FluentValidation;
using ThosCase.DAL.BusinessObjects.Request.Product;
using ThosCase.DAL.Repositories.Interface;

namespace ThosCase.DAL.BusinessObjects.Validators
{
    internal class ProductUpdateRequestValidator : AbstractValidator<ProductUpdateRequest>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductUpdateRequestValidator(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Producname).NotNull().NotEmpty().WithMessage("Ürün Adı Boş olamaz");

            RuleFor(x => x.Categoryid).GreaterThan(-1);
            RuleFor(x => x.Categoryid).Must((model, result) =>
            {
                return CategoryIdSearch(model.Categoryid);
            }).WithMessage("Seçilen Kategori Bulunamadı");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Ürün Fiyatı 0 veya - değer olamaz");
        }
        //VALIDASYONDA KULLANILAN PRIVATE METHODLAR
        #region PRIVATE METHODS
        private bool CategoryIdSearch(int categoryid)
        {
            var category = _categoryRepository.FirstOrDefault(x => x.Categoryid == categoryid && x.Isdeleted == false);
            if (category == null)
                return false;
            return true;
        }
        #endregion
    }
}
