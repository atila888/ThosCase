using Microsoft.EntityFrameworkCore;
using ThosCase.DAL.Core;
using ThosCase.DAL.Repositories.Interface;
using ThosCase.Data.Models.Context;

namespace ThosCase.DAL.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {

        }
        public Context Context => Context as Context;
    }
}
