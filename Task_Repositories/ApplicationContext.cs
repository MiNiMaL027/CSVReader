using Microsoft.EntityFrameworkCore;
using Task_Domain.Models;

namespace Task_Repositories
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}