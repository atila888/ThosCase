using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThosCase.Business.Managers.Interfaces;

namespace ThosCase.Business.Core
{
    public class BusinessManagerFactory
    {
        public ICategoryManager CategoryManager { get;}
        public BusinessManagerFactory(
            ICategoryManager categoryManager) 
        {
            CategoryManager = categoryManager;
        }
    }
}
