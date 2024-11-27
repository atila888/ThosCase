using AutoMapper;
using ThosCase.DAL.BusinessObjects.Request.Category;
using ThosCase.DAL.BusinessObjects.Request.Product;
using ThosCase.DAL.BusinessObjects.Request.User;
using ThosCase.DAL.BusinessObjects.Response.Category;
using ThosCase.DAL.BusinessObjects.Response.Product;
using ThosCase.DAL.BusinessObjects.Response.User;
using ThosCase.Data.Models.Context;

namespace ThosCase.DAL.MappingProfile
{
    public class ThosCaseMappingProfile : Profile
    {
        public ThosCaseMappingProfile()
        {
            CreateMap<Category, CategoryResponse>();
            CreateMap<CategorySaveRequest, Category>();
            CreateMap<CategoryUpdateRequest, Category>();

            CreateMap<Product, ProductResponse>();
            CreateMap<ProductSaveRequest, Product>();
            CreateMap<ProductUpdateRequest, Product>();

            CreateMap<User, UserResponse>();
            CreateMap<UserSaveRequest, User>();
            CreateMap<UserUpdateRequest, User>();
        }
    }
}
