using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Data.Model;
namespace StudentAdminPortal.API.Data.Context
{
    public class StudentAdminContext : DbContext
    {
        public StudentAdminContext(DbContextOptions<StudentAdminContext> options): base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}
