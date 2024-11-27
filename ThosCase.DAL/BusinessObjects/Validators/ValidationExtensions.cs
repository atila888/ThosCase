using FluentValidation;
using ThosCase.DAL.BusinessObjects.Request.Category;
using ThosCase.DAL.BusinessObjects.Request.Product;
using ThosCase.DAL.BusinessObjects.Request.User;
using ThosCase.DAL.Repositories.Interface;

namespace ThosCase.DAL.BusinessObjects.Validators
{
    public static class ValidationExtensions
    {
        public static void Validate(this CategorySaveRequest @object, ICategoryRepository categoryRepository)
        {
            var rules = new CategorySaveRequestValidator(categoryRepository);
            rules.ValidateAndThrow(@object);
        }
        public static void Validate(this CategoryUpdateRequest @object, ICategoryRepository categoryRepository)
        {
            var rules = new CategoryUpdateRequestValidator(categoryRepository);
            rules.ValidateAndThrow(@object);
        }
        public static void Validate(this ProductSaveRequest @object, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            var rules = new ProductSaveRequestValidator(productRepository, categoryRepository);
            rules.ValidateAndThrow(@object);
        }
        public static void Validate(this ProductUpdateRequest @object, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            var rules = new ProductUpdateRequestValidator(productRepository, categoryRepository);
            rules.ValidateAndThrow(@object);
        }
        public static void Validate(this UserSaveRequest @object, IUserRepository userRepository)
        {
            var rules = new UserSaveRequestValidator(userRepository);
            rules.ValidateAndThrow(@object);
        }
        public static void Validate(this UserUpdateRequest @object, IUserRepository userRepository)
        {
            var rules = new UserUpdateRequestValidator(userRepository);
            rules.ValidateAndThrow(@object);
        }
    }
}
