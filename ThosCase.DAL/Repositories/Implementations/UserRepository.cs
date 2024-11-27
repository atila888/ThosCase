using Microsoft.EntityFrameworkCore;
using ThosCase.DAL.Core;
using ThosCase.DAL.Repositories.Interface;
using ThosCase.Data.Models.Context;

namespace ThosCase.DAL.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {

        }
        public Context Context => Context as Context;
    }
}
