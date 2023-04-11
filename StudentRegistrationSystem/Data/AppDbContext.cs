using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //To change the name of any specific table
        /*protected override void OnModelCreating(ModelBuilder objmodel)
        {
            objmodel.Entity<Student>().ToTable("StudentNew");
        }*/

        public DbSet<Student> Students { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<StudentHobby> StudentHobbies { get; set; }
    }
}
