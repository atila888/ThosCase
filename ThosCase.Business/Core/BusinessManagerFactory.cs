using ThosCase.Business.Helper.DataTable;
using ThosCase.Business.Managers.Interfaces;

namespace ThosCase.Business.Core
{
    public class BusinessManagerFactory
    {
        public IDataTable DataTable { get; }
        public ICategoryManager CategoryManager { get; }
        public IProductManager ProductManager { get; }
        public IUserManager UserManager { get; }
        public BusinessManagerFactory(
            IDataTable dataTable,
            ICategoryManager categoryManager,
            IProductManager productManager,
            IUserManager userManager)
        {
            DataTable = dataTable;
            CategoryManager = categoryManager;
            ProductManager = productManager;
            UserManager = userManager;
        }
    }
}
