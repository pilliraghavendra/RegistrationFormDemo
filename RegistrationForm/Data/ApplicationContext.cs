using Microsoft.EntityFrameworkCore;
using RegistrationForm.Models;
namespace RegistrationForm.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options)
        {
        
        }
        public DbSet<Registration> LoginForms { get; set; }
    }
}
