using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Models
{
    public class ApplicationDBContext : DbContext
    {
        // override configuration that we need at app level
           public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
           {

           }



        // LINQ  --> conversion DBset --> SQL  -> exec
        // Entity <Employee> 
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
    }
}


