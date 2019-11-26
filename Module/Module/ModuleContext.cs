using ModuleDal.Models;
using System.Data.Entity;

namespace ModuleDal
{
    public class ModuleContext : DbContext
    {
        public ModuleContext() : base(@"Server=DESKTOP-R04KCA7; DataBase=Module;Initial Catalog=Task;Trusted_Connection=True;")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
