using bl_poc_ms_person.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl_poc_ms_person.Tests
{
    public class BaseTests
    {
        protected ApplicationDbContext BuildContext(string nameDb)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(nameDb).Options;

            var dbContext = new ApplicationDbContext(options);
            return dbContext;
        }
    }
}
