using System.Data.Entity;
using bsa15_lec6_orm.Models;

namespace bsa15_lec6_orm.Entities
{
    public class CourseContext : DbContext
    {
        public CourseContext() : base("OrmBD")
        {
            Database.SetInitializer<CourseContext>(new CourseContextInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, bsa15_lec6_orm.Migrations.Configuration>("OrmBD"));
        }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestWork> TestWorks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Test>()
                        .HasMany<Question>(t => t.Questions)
                        .WithMany(q => q.Tests)
                        .Map(qt =>
                        {
                            qt.MapLeftKey("TestRefId");
                            qt.MapRightKey("QuestionRefId");
                            qt.ToTable("TestQuestion");
                        });

            //modelBuilder.Entity<User>()
            //            .HasMany<Category>(u => u.Categories)
            //            .WithMany(c => c.Users)
            //            .Map(cu =>
            //            {
            //                cu.MapLeftKey("UserRefId");
            //                cu.MapRightKey("CategoryRefId");
            //                cu.ToTable("UserCategory");
            //            });

            //// Configure StudentId as PK for StudentAddress
            //modelBuilder.Entity<TestWork>()
            //    .HasKey(e => e.TestId);

            //// Configure StudentId as FK for StudentAddress
            //modelBuilder.Entity<TestWork>()
            //            .HasRequired(tw => tw.Test)
            //            .WithOptional(t => t.TestWork); 

        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Student>()
        //                .HasMany<Course>(s => s.Courses)
        //                .WithMany(c => c.Students)
        //                .Map(cs =>
        //                {
        //                    cs.MapLeftKey("StudentRefId");
        //                    cs.MapRightKey("CourseRefId");
        //                    cs.ToTable("StudentCourse");
        //                });

        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
