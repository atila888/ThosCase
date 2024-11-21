using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThosCase.Data.Models
{
    public class Entity
    {
        public bool Isdeleted { get; set; }
        public DateTime Createddate { get; set; }
        public int Creatoruserid { get; set; }
    }
}
