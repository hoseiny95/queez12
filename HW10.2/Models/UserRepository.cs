namespace HW10._2.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;
        public UserRepository()
        {
            _users = Database.users;
        }
        public List<User> GetAll()
        {
            return _users;
            

        }
        public User GetUser(string ncode)
        {
            var myuser = GetAll();
            return  myuser.FirstOrDefault(x => x.Ncode == ncode);
        }
        
    }
}
