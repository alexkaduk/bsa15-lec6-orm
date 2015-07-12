using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using bsa15_lec6_orm.Models;

namespace bsa15_lec6_orm.Entities
{
    public class ContextInitializer : CreateDatabaseIfNotExists<Context> //DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            #region Add data to lectures
            var lectures = new List<Lecture>
            {
                new Lecture { Id = 1001, Name = "lec1: introduction", Description = "lec1 description", Categories = new List<Category>(), Instructors = new List<Instructor>() },
                new Lecture { Id = 1002, Name = "lec2: modern commercial programming", Description = "lec2 description", Categories = new List<Category>(), Instructors = new List<Instructor>() },
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

            lectures.ForEach(l => context.Lectures.AddOrUpdate(p => p.Id, l));
            context.SaveChanges();
            #endregion

            #region Add data to instructors
            var instructors = new List<Instructor>
            {
                new Instructor { Name = "Dima" },
                new Instructor { Name = "Anton" },
                new Instructor { Name = "Alex" }
            };
            instructors.ForEach(t => context.Instructors.AddOrUpdate(p => p.Name, t));
            context.SaveChanges();
            #endregion

            #region Add data to categories
            var categories = new List<Category>
            {
                new Category { Name = ".Net" },
                new Category { Name = "JS" },
                new Category { Name = "PHP" },
                new Category { Name = "DB" },
                new Category { Name = "OOP" },
                new Category { Name = "English" }
            };
            categories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
            #endregion

            #region Add teacher to lecture
            AddInstructorToLecture(context, 1001, "Dima");
            AddInstructorToLecture(context, 1001, "Anton");
            AddInstructorToLecture(context, 1001, "Alex");
            AddInstructorToLecture(context, 1002, "Dima");
            AddInstructorToLecture(context, 1003, "Anton");
            AddInstructorToLecture(context, 1004, "Anton");
            AddInstructorToLecture(context, 1005, "Anton");
            AddInstructorToLecture(context, 1006, "Anton");
            AddInstructorToLecture(context, 1007, "Alex");
            AddInstructorToLecture(context, 1008, "Dima");
            AddInstructorToLecture(context, 1009, "Dima");
            AddInstructorToLecture(context, 1010, "Dima");
            AddInstructorToLecture(context, 1011, "Alex");
            AddInstructorToLecture(context, 1012, "Dima");
            AddInstructorToLecture(context, 1012, "Alex");
            context.SaveChanges();
            #endregion

            #region Add categoty to lecture
            AddCategotyToLecture(context, 1001, ".Net");
            AddCategotyToLecture(context, 1001, "JS");
            AddCategotyToLecture(context, 1001, "PHP");
            AddCategotyToLecture(context, 1002, ".Net");
            AddCategotyToLecture(context, 1002, "JS");
            AddCategotyToLecture(context, 1002, "PHP");
            AddCategotyToLecture(context, 1003, ".Net");
            AddCategotyToLecture(context, 1003, "JS");
            AddCategotyToLecture(context, 1003, "PHP");
            AddCategotyToLecture(context, 1004, ".Net");
            AddCategotyToLecture(context, 1005, "DB");
            AddCategotyToLecture(context, 1006, ".Net");
            AddCategotyToLecture(context, 1006, "JS");
            AddCategotyToLecture(context, 1006, "PHP");
            AddCategotyToLecture(context, 1007, "PHP");
            AddCategotyToLecture(context, 1008, "JS");
            AddCategotyToLecture(context, 1009, "JS");
            AddCategotyToLecture(context, 1010, "JS");
            AddCategotyToLecture(context, 1011, "English");
            AddCategotyToLecture(context, 1012, "OOP");
            context.SaveChanges();
            #endregion

            base.Seed(context);
        }

        static void AddInstructorToLecture(Context context, int lectureId, string instructorName)
        {
            var lec = context.Lectures.SingleOrDefault(l => l.Id == lectureId);
            lec.Instructors.Add(context.Instructors.Single(t => t.Name == instructorName));
        }

        static void AddCategotyToLecture(Context context, int lectureId, string categoryName)
        {
            var lec = context.Lectures.SingleOrDefault(l => l.Id == lectureId);
            lec.Categories.Add(context.Categories.Single(t => t.Name == categoryName));
        }

    }
}
