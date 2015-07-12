using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using bsa15_lec6_orm.Models;

namespace bsa15_lec6_orm.Entities
{
    public class CourseContextInitializer : DropCreateDatabaseIfModelChanges<CourseContext>
    //public class CourseContextInitializer : CreateDatabaseIfNotExists<CourseContext> 
    {
        protected override void Seed(CourseContext courseContext)
        {
            #region Add data to Lecture table
            var lectures = new List<Lecture>
            {
                new Lecture { Id = 1001, Name = "lec1 introduction", Description = "lec1 description", Categories = new List<Category>(), Instructors = new List<Instructor>() },
                new Lecture { Id = 1002, Name = "lec2 modern commercial programming", Description = "lec2 description", Categories = new List<Category>(), Instructors = new List<Instructor>() },
                new Lecture { Id = 1003, Name = "lec3 GIT", Description = "lec6 description", Categories = new List<Category>(), Instructors = new List<Instructor>() },
                new Lecture { Id = 1004, Name = "lec4 .Net data structures and LINQ", Description = "lec4 description", Categories = new List<Category>(), Instructors = new List<Instructor>() },
                new Lecture { Id = 1005, Name = "lec5 SQL", Description = "lec5 description", Categories = new List<Category>(), Instructors = new List<Instructor>() },
                new Lecture { Id = 1006, Name = "lec6 code testing", Description = "lec6 description", Categories = new List<Category>(), Instructors = new List<Instructor>() },
                new Lecture { Id = 1007, Name = "lec7 PHP introduction", Description = "lec7 description", Categories = new List<Category>(), Instructors = new List<Instructor>() },
                new Lecture { Id = 1008, Name = "lec8 HTML, CSS", Description = "lec8 description", Categories = new List<Category>(), Instructors = new List<Instructor>() },
                new Lecture { Id = 1009, Name = "lec9 JS, JQuery", Description = "lec9 description", Categories = new List<Category>(), Instructors = new List<Instructor>() },
                new Lecture { Id = 1010, Name = "lec10 Angular", Description = "lec10 description", Categories = new List<Category>(), Instructors = new List<Instructor>() },
                new Lecture { Id = 1011, Name = "lec11 english introduction", Description = "lec11 description", Categories = new List<Category>(), Instructors = new List<Instructor>() },
                new Lecture { Id = 1012, Name = "lec12 OOP introduction", Description = "lec12 description", Categories = new List<Category>(), Instructors = new List<Instructor>() }
            };

            lectures.ForEach(l => courseContext.Lectures.AddOrUpdate(p => p.Id, l));
            courseContext.SaveChanges();
            #endregion

            #region Add data to Instructor table
            var instructors = new List<Instructor>
            {
                new Instructor { Name = "Dima" },
                new Instructor { Name = "Anton" },
                new Instructor { Name = "Alex" }
            };
            instructors.ForEach(t => courseContext.Instructors.AddOrUpdate(p => p.Name, t));
            courseContext.SaveChanges();
            #endregion

            #region Add data to Category table
            var categories = new List<Category>
            {
                new Category { Name = ".Net" },
                new Category { Name = "JS" },
                new Category { Name = "PHP" },
                new Category { Name = "DB" },
                new Category { Name = "OOP" },
                new Category { Name = "English" }
            };
            categories.ForEach(c => courseContext.Categories.AddOrUpdate(p => p.Name, c));
            courseContext.SaveChanges();
            #endregion

            #region Add instructor to Lecture table
            AddInstructorToLecture(courseContext, 1001, "Dima");
            AddInstructorToLecture(courseContext, 1001, "Anton");
            AddInstructorToLecture(courseContext, 1001, "Alex");
            AddInstructorToLecture(courseContext, 1002, "Dima");
            AddInstructorToLecture(courseContext, 1003, "Anton");
            AddInstructorToLecture(courseContext, 1004, "Anton");
            AddInstructorToLecture(courseContext, 1005, "Anton");
            AddInstructorToLecture(courseContext, 1006, "Anton");
            AddInstructorToLecture(courseContext, 1007, "Alex");
            AddInstructorToLecture(courseContext, 1008, "Dima");
            AddInstructorToLecture(courseContext, 1009, "Dima");
            AddInstructorToLecture(courseContext, 1010, "Dima");
            AddInstructorToLecture(courseContext, 1011, "Alex");
            AddInstructorToLecture(courseContext, 1012, "Dima");
            AddInstructorToLecture(courseContext, 1012, "Alex");
            courseContext.SaveChanges();
            #endregion

            #region Add categoty to Lecture table
            AddCategotyToLecture(courseContext, 1001, ".Net");
            AddCategotyToLecture(courseContext, 1001, "JS");
            AddCategotyToLecture(courseContext, 1001, "PHP");
            AddCategotyToLecture(courseContext, 1002, ".Net");
            AddCategotyToLecture(courseContext, 1002, "JS");
            AddCategotyToLecture(courseContext, 1002, "PHP");
            AddCategotyToLecture(courseContext, 1003, ".Net");
            AddCategotyToLecture(courseContext, 1003, "JS");
            AddCategotyToLecture(courseContext, 1003, "PHP");
            AddCategotyToLecture(courseContext, 1004, ".Net");
            AddCategotyToLecture(courseContext, 1005, "DB");
            AddCategotyToLecture(courseContext, 1006, ".Net");
            AddCategotyToLecture(courseContext, 1006, "JS");
            AddCategotyToLecture(courseContext, 1006, "PHP");
            AddCategotyToLecture(courseContext, 1007, "PHP");
            AddCategotyToLecture(courseContext, 1008, "JS");
            AddCategotyToLecture(courseContext, 1009, "JS");
            AddCategotyToLecture(courseContext, 1010, "JS");
            AddCategotyToLecture(courseContext, 1011, "English");
            AddCategotyToLecture(courseContext, 1012, "OOP");
            courseContext.SaveChanges();
            #endregion

            base.Seed(courseContext);
        }

        static void AddInstructorToLecture(CourseContext courseContext, int lectureId, string instructorName)
        {
            var lec = courseContext.Lectures.Single(l => l.Id == lectureId);
            lec.Instructors.Add(courseContext.Instructors.Single(t => t.Name == instructorName));
        }

        static void AddCategotyToLecture(CourseContext courseContext, int lectureId, string categoryName)
        {
            var lec = courseContext.Lectures.SingleOrDefault(l => l.Id == lectureId);
            lec.Categories.Add(courseContext.Categories.Single(t => t.Name == categoryName));
        }

    }
}
