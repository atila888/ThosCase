
namespace ThosCase.Data.Models
{
    public class Entity
    {
        public bool Isdeleted { get; set; }
        public DateTime Createddate { get; set; } = DateTime.Now;
        public int Creatoruserid { get; set; }
    }
}
