namespace ThosCase.DAL.BusinessObjects.Request.User
{
    public class UserUpdateRequest
    {
        public int Userid { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }
        public string password { get; set; }
    }
}
