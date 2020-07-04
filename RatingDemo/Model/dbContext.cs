using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class dbContext : DbContext
    {
        public dbContext() : base("dbContext")
        {
           
        }

        public  DbSet<Employee> Employees { get; set; }
        public  DbSet<Rating> Ratings { get; set; }
        public DbSet<Servicecs> Services { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
