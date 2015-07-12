using System.Data.Entity;
using bsa15_lec6_orm.Models;

namespace bsa15_lec6_orm.Entities
{
    public class Context : DbContext
    {
        public Context() : base("OrmBD")
        {
            Database.SetInitializer<Context>(new ContextInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, bsa15_lec6_orm.Migrations.Configuration>("OrmBD"));
        }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Category> Categories { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
