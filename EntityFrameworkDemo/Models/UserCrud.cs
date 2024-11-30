using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Models
{
    public class UserCrud
    {
        private readonly ApplicationDBContext db; // Injected DbContext

        public UserCrud(ApplicationDBContext db)
        {
            this.db = db;
        }

        // Validate user credentials
        public User ValidateUser(User user)
        {
            var res = (from u in db.Users
                         where u.Email == user.Email && u.Password == user.Password
                         select u).FirstOrDefault();

            return res;
            //return db.Users
            //    .FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
        }

        // Add new user
        public int AddUser(User user)
        {
           
                var userExists = (from u in db.Users
                                  where u.Email == user.Email
                                  select u).Any();

                if (userExists)
                {
                    return 0; // User already exists
                }

                db.Users.Add(user);
                return db.SaveChanges(); // Commit changes
            }
        }
}
