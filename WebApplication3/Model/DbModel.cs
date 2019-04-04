using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Model
{
    public class DbModel : DbContext
    {
        public DbModel(DbContextOptions<DbModel> options) : base(options) {
        }

        public DbSet<Test> Tests { get; set; }
    }
}
