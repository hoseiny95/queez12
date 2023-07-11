namespace HW10._2.Models
{
    public class Database
    {
        public static List<User> users;
        static Database()
        {

            var allusers = new List<User>()
            {
                new User(){Fname = "masi",Lname = "hsn",Phone = "9124375594" , Ncode ="2134567845" },
               
               
                 new User() { Fname = "ali",Lname = "hasani",Phone = "9121536599" , Ncode = "2143132345" },
                
                  new User(){Fname = "mahdi",Lname = "afshar",Phone = "9128542014" , Ncode ="2183425677" }
            };
            users = allusers;
        }
    }
}
