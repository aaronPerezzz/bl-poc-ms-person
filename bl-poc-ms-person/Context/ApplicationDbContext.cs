using bl_poc_ms_person.Models;
using Microsoft.EntityFrameworkCore;

namespace bl_poc_ms_person.Context
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Persons> Persons { get; set; }
    }
}
