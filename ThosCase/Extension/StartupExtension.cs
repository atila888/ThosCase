using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ThosCase.Business.Core;
using ThosCase.Business.Helper.DataTable;
using ThosCase.Business.Managers.Implementations;
using ThosCase.Business.Managers.Interfaces;
using ThosCase.DAL.MappingProfile;
using ThosCase.DAL.Repositories.Implementations;
using ThosCase.DAL.Repositories.Interface;
using ThosCase.Data.Models.Context;

namespace ThosCase.Extension
{
    public static class StartupExtension
    {
        public static IConfiguration Configuration { get; set; }
        public static void AddDbContexts(this IServiceCollection services)
        {
            services.AddDbContext<Context>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("ThosConnection"),
                sqlOpt => { sqlOpt.CommandTimeout(750); }), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            services.AddScoped<DbContext, Context>();
        }
        public static void AddDataTables(this IServiceCollection services)
        {
            services.AddScoped<IDataTable, Datatable>();
        }
        public static void AddManagers(this IServiceCollection services)
        {
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<BusinessManagerFactory>();
        }
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductPropertyRepository, ProductPropertyRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
        public static void AddAutoMappins(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new ThosCaseMappingProfile()); });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
