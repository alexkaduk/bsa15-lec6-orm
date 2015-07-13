using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using bsa15_lec6_orm.Models;

namespace bsa15_lec6_orm.Entities
{
   // public class CourseContextInitializer : DropCreateDatabaseIfModelChanges<CourseContext>
    public class CourseContextInitializer : CreateDatabaseIfNotExists<CourseContext>
    {
        protected override void Seed(CourseContext courseContext)
        {
            var instructors = new List<Instructor>
            {
                new Instructor { Name = "Bob" },
                new Instructor { Name = "Tom" },
                new Instructor { Name = "John" }
            };
            instructors.ForEach(t => courseContext.Instructors.AddOrUpdate(p => p.Name, t));
            courseContext.SaveChanges();

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

            var lectures = new List<Lecture>
            {
                new Lecture
                {
                    Id = 1001, 
                    Name = "lec1 introduction", 
                    Description = "lec1 description", 
                    Categories = new List<Category>
                    {
                        courseContext.Categories.SingleOrDefault(c=>c.Name == ".Net"),
                        courseContext.Categories.SingleOrDefault(c=>c.Name == "JS"),
                        courseContext.Categories.SingleOrDefault(c=>c.Name == "PHP")
                    },
                    Instructors = new List<Instructor>
                    {
                        courseContext.Instructors.SingleOrDefault(i=>i.Name == "Bob"),
                        courseContext.Instructors.SingleOrDefault(i=>i.Name == "Tom"),
                        courseContext.Instructors.SingleOrDefault(i=>i.Name == "John")
                    }
                },
                new Lecture
                {
                    Id = 1002, 
                    Name = "lec2 modern commercial programming", 
                    Description = "lec2 description", 
                    Categories = new List<Category>
                    {
                        courseContext.Categories.SingleOrDefault(c=>c.Name == ".Net"),
                        courseContext.Categories.SingleOrDefault(c=>c.Name == "JS"),
                        courseContext.Categories.SingleOrDefault(c=>c.Name == "PHP")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        courseContext.Instructors.SingleOrDefault(i=>i.Name == "Bob")
                    }
                },
                new Lecture
                {
                    Id = 1003, 
                    Name = "lec3 GIT", 
                    Description = "lec3 description", 
                    Categories = new List<Category>
                    {
                        courseContext.Categories.SingleOrDefault(c=>c.Name == ".Net"),
                        courseContext.Categories.SingleOrDefault(c=>c.Name == "JS"),
                        courseContext.Categories.SingleOrDefault(c=>c.Name == "PHP")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        courseContext.Instructors.SingleOrDefault(i=>i.Name == "Tom")
                    }
                },
                new Lecture { Id = 1004,
                    Name = "lec4 .Net data structures and LINQ", 
                    Description = "lec4 description",
                    Categories = new List<Category>
                    {
                        courseContext.Categories.SingleOrDefault(c=>c.Name == ".Net")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        courseContext.Instructors.SingleOrDefault(i=>i.Name == "Tom")
                    }
                },
                new Lecture
                {
                    Id = 1005,
                    Name = "lec5 SQL", 
                    Description = "lec5 description",
                    Categories = new List<Category>
                    {
                        courseContext.Categories.SingleOrDefault(c=>c.Name == "DB")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        courseContext.Instructors.SingleOrDefault(i=>i.Name == "Tom")
                    }
                },
                new Lecture { 
                    Id = 1006,
                    Name = "lec6 code testing", 
                    Description = "lec6 description", 
                    Categories = new List<Category>
                    {
                        courseContext.Categories.SingleOrDefault(c=>c.Name == ".Net"),
                        courseContext.Categories.SingleOrDefault(c=>c.Name == "JS"),
                        courseContext.Categories.SingleOrDefault(c=>c.Name == "PHP")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        courseContext.Instructors.SingleOrDefault(i=>i.Name == "Tom")
                    }
                },
                new Lecture
                {
                    Id = 1007, 
                    Name = "lec7 PHP introduction",
                    Description = "lec7 description", 
                    Categories = new List<Category>
                    {
                         courseContext.Categories.SingleOrDefault(c=>c.Name == "PHP")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        courseContext.Instructors.SingleOrDefault(i=>i.Name == "John")
                    }
                },
                new Lecture { Id = 1008, 
                    Name = "lec8 HTML, CSS", 
                    Description = "lec8 description", 
                    Categories = new List<Category>
                    {
                         courseContext.Categories.SingleOrDefault(c=>c.Name == "JS")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        courseContext.Instructors.SingleOrDefault(i=>i.Name == "Bob")
                    }
                },
                new Lecture
                {
                    Id = 1009, 
                    Name = "lec9 JS, JQuery",
                    Description = "lec9 description",
                    Categories = new List<Category>
                    {
                        courseContext.Categories.SingleOrDefault(c=>c.Name == "JS")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        courseContext.Instructors.SingleOrDefault(i=>i.Name == "Bob")
                    }
                },
                new Lecture
                {
                    Id = 1010, 
                    Name = "lec10 Angular",
                    Description = "lec10 description", 
                    Categories = new List<Category>
                    {
                        courseContext.Categories.SingleOrDefault(c=>c.Name == "JS")
                    },
                    Instructors = new List<Instructor>
                    {
                        courseContext.Instructors.SingleOrDefault(i=>i.Name == "Bob")
                    }
                },
                new Lecture
                {
                    Id = 1011, 
                    Name = "lec11 english introduction", 
                    Description = "lec11 description", 
                    Categories = new List<Category>
                    {
                        courseContext.Categories.SingleOrDefault(c=>c.Name == "English")
                    },
                    Instructors = new List<Instructor>
                    {
                        courseContext.Instructors.SingleOrDefault(i=>i.Name == "John")
                    }
                },
                new Lecture
                {
                    Id = 1012, 
                    Name = "lec12 OOP introduction",
                    Description = "lec12 description", 
                    Categories = new List<Category>
                    {
                        courseContext.Categories.SingleOrDefault(c=>c.Name == "OOP")
                    },
                    Instructors = new List<Instructor>
                    {
                        courseContext.Instructors.SingleOrDefault(i=>i.Name == "Bob"),
                        courseContext.Instructors.SingleOrDefault(i=>i.Name == "John")
                    }
                }
            };

            lectures.ForEach(l => courseContext.Lectures.AddOrUpdate(p => p.Id, l));
            courseContext.SaveChanges();

            var questions = new List<Question>
            {
                new Question { Id = 1, Text = ".NET question 1", Category = courseContext.Categories.SingleOrDefault(c=>c.Name==".Net") },
                new Question { Id = 2, Text = ".NET question 2", Category = courseContext.Categories.SingleOrDefault(c=>c.Name==".Net") },
                new Question { Id = 3, Text = "JS question 1", Category = courseContext.Categories.SingleOrDefault(c=>c.Name=="JS") },
                new Question { Id = 4, Text = "JS question 2", Category = courseContext.Categories.SingleOrDefault(c=>c.Name=="JS") },
                new Question { Id = 5, Text = "PHP question 1", Category = courseContext.Categories.SingleOrDefault(c=>c.Name=="PHP") },
                new Question { Id = 6, Text = "PHP question 2", Category = courseContext.Categories.SingleOrDefault(c=>c.Name=="PHP") },
                new Question { Id = 7, Text = "DB question 1", Category = courseContext.Categories.SingleOrDefault(c=>c.Name=="DB") },
                new Question { Id = 8, Text = "DB question 2", Category = courseContext.Categories.SingleOrDefault(c=>c.Name=="DB") },
                new Question { Id = 9, Text = "English question 1", Category = courseContext.Categories.SingleOrDefault(c=>c.Name=="English") },
                new Question { Id = 10, Text = "English question 2", Category = courseContext.Categories.SingleOrDefault(c=>c.Name=="English") },
                new Question { Id = 11, Text = "OOP question 1", Category = courseContext.Categories.SingleOrDefault(c=>c.Name=="OOP") },
                new Question { Id = 12, Text = "OOP question 2", Category = courseContext.Categories.SingleOrDefault(c=>c.Name=="OOP") },
                new Question { Id = 13, Text = "OOP question 3", Category = courseContext.Categories.SingleOrDefault(c=>c.Name=="OOP") }
            };

            questions.ForEach(q => courseContext.Questions.AddOrUpdate(p => p.Id, q));
            courseContext.SaveChanges();

            var tests = new List<Test>
            {
                new Test
                {
                    TestId = 101,
                    Name = ".NET test bsa15",
                    MaxTime = new TimeSpan(0, 20, 0),
                    PassResult = 100,
                    Category = courseContext.Categories.SingleOrDefault(c=>c.Name==".Net"),
                    Questions = new List<Question>
                    {
                        courseContext.Questions.SingleOrDefault(i=>i.Id == 1), courseContext.Questions.SingleOrDefault(i=>i.Id == 2),
                        courseContext.Questions.SingleOrDefault(i=>i.Id == 7), courseContext.Questions.SingleOrDefault(i=>i.Id == 8), 
                        courseContext.Questions.SingleOrDefault(i=>i.Id == 9), courseContext.Questions.SingleOrDefault(i=>i.Id == 10), 
                        courseContext.Questions.SingleOrDefault(i=>i.Id == 11), courseContext.Questions.SingleOrDefault(i=>i.Id == 12),
                        courseContext.Questions.SingleOrDefault(i=>i.Id == 13)
                    }
                },
                new Test
                {
                    TestId = 102,
                    Name = "JS test bsa15",
                    MaxTime = new TimeSpan(0, 20, 0),
                    PassResult = 100,
                    Category = courseContext.Categories.SingleOrDefault(c=>c.Name=="JS"),
                    Questions = new List<Question>
                    {
                        courseContext.Questions.SingleOrDefault(i=>i.Id == 3), courseContext.Questions.SingleOrDefault(i=>i.Id == 4),
                        courseContext.Questions.SingleOrDefault(i=>i.Id == 7), courseContext.Questions.SingleOrDefault(i=>i.Id == 9),
                        courseContext.Questions.SingleOrDefault(i=>i.Id == 11), courseContext.Questions.SingleOrDefault(i=>i.Id == 13)
                    }
                },
                new Test
                {
                    TestId = 103,
                    Name = "PHP test bsa15",
                    MaxTime = new TimeSpan(0, 20, 0),
                    PassResult = 100,
                    Category = courseContext.Categories.SingleOrDefault(c=>c.Name=="PHP"),
                    Questions = new List<Question>
                    {
                        courseContext.Questions.SingleOrDefault(i=>i.Id == 5), courseContext.Questions.SingleOrDefault(i=>i.Id == 6),
                        courseContext.Questions.SingleOrDefault(i=>i.Id == 7), courseContext.Questions.SingleOrDefault(i=>i.Id == 9),
                        courseContext.Questions.SingleOrDefault(i=>i.Id == 11), courseContext.Questions.SingleOrDefault(i=>i.Id == 13)
                    }
                }
            };

            tests.ForEach(t => courseContext.Tests.AddOrUpdate(p => p.TestId, t));
            courseContext.SaveChanges();

            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "Alex",
                    Email = "alex@i.ua",
                    Age = 20,
                    City = "Kyiv",
                    University = "KPI",
                    Categories = new List<Category>
                    {
                        courseContext.Categories.SingleOrDefault(c => c.Name == ".Net"),
                        courseContext.Categories.SingleOrDefault(c => c.Name == "JS")
                    }
                },
                new User
                {
                    Id = 2,
                    Name = "Jora",
                    Email = "jora@i.ua",
                    Age = 22,
                    City = "Lviv",
                    University = "Lviv Politechnic",
                    Categories = new List<Category>
                    {
                        courseContext.Categories.SingleOrDefault(c => c.Name == ".Net"),
                        courseContext.Categories.SingleOrDefault(c => c.Name == "JS"),
                        courseContext.Categories.SingleOrDefault(c => c.Name == "PHP")
                    }
                },
                new User
                {
                    Id = 3,
                    Name = "Roma",
                    Email = "roma@i.ua",
                    Age = 25,
                    City = "Kyiv",
                    University = "NaUKMA",
                    Categories = new List<Category>
                    {
                        courseContext.Categories.SingleOrDefault(c => c.Name == ".Net"),
                        courseContext.Categories.SingleOrDefault(c => c.Name == "PHP")
                    }
                },
                new User
                {
                    Id = 4,
                    Name = "Sergiy",
                    Email = "sergiy@i.ua",
                    Age = 27,
                    City = "Vinnytsia",
                    University = "VNTU",
                    Categories = new List<Category>
                    {
                        courseContext.Categories.SingleOrDefault(c => c.Name == ".Net")
                    }
                },
                new User
                {
                    Id = 5,
                    Name = "Andriy",
                    Email = "andriy@i.ua",
                    Age = 30,
                    City = "Odesa",
                    University = "OPU",
                    Categories = new List<Category>
                    {
                        courseContext.Categories.SingleOrDefault(c => c.Name == ".PHP")
                    }
                }
            };

            users.ForEach(u => courseContext.Users.AddOrUpdate(p => p.Id, u));
            courseContext.SaveChanges();

            var testWorks = new List<TestWork>
            {
                new TestWork
                {
                    Id = 101,
                    Result = 90,
                    ExecutionTime = new TimeSpan(0, 25, 0),
                    Test = courseContext.Tests.SingleOrDefault(t => t.Name == ".NET test bsa15"),
                    User = courseContext.Users.SingleOrDefault(u => u.Name == "Alex")
                },
                new TestWork
                {
                    Id = 102,
                    Result = 95,
                    ExecutionTime = new TimeSpan(0, 19, 0),
                    Test = courseContext.Tests.SingleOrDefault(t => t.Name == ".NET test bsa15"),
                    User = courseContext.Users.SingleOrDefault(u => u.Name == "Jora")
                },
                new TestWork
                {
                    Id = 103,
                    Result = 110,
                    ExecutionTime = new TimeSpan(0, 15, 0),
                    Test = courseContext.Tests.SingleOrDefault(t => t.Name == ".NET test bsa15"),
                    User = courseContext.Users.SingleOrDefault(u => u.Name == "Roma")
                },
                new TestWork
                {
                    Id = 104,
                    Result = 110,
                    ExecutionTime = new TimeSpan(0, 28, 0),
                    Test = courseContext.Tests.SingleOrDefault(t => t.Name == ".NET test bsa15"),
                    User = courseContext.Users.SingleOrDefault(u => u.Name == "Sergiy")
                },
                new TestWork
                {
                    Id = 105,
                    Result = 105,
                    ExecutionTime = new TimeSpan(0, 18, 0),
                    Test = courseContext.Tests.SingleOrDefault(t => t.Name == ".JS test bsa15"),
                    User = courseContext.Users.SingleOrDefault(u => u.Name == "Alex")
                },
                new TestWork
                {
                    Id = 106,
                    Result = 80,
                    ExecutionTime = new TimeSpan(0, 17, 0),
                    Test = courseContext.Tests.SingleOrDefault(t => t.Name == ".JS test bsa15"),
                    User = courseContext.Users.SingleOrDefault(u => u.Name == "Jora")
                },
                new TestWork
                {
                    Id = 107,
                    Result = 70,
                    ExecutionTime = new TimeSpan(0, 22, 0),
                    Test = courseContext.Tests.SingleOrDefault(t => t.Name == ".PHP test bsa15"),
                    User = courseContext.Users.SingleOrDefault(u => u.Name == "Jora")
                },
                new TestWork
                {
                    Id = 108,
                    Result = 120,
                    ExecutionTime = new TimeSpan(0, 16, 0),
                    Test = courseContext.Tests.SingleOrDefault(t => t.Name == ".PHP test bsa15"),
                    User = courseContext.Users.SingleOrDefault(u => u.Name == "Roma")
                },
                new TestWork
                {
                    Id = 109,
                    Result = 130,
                    ExecutionTime = new TimeSpan(0, 35, 0),
                    Test = courseContext.Tests.SingleOrDefault(t => t.Name == ".PHP test bsa15"),
                    User = courseContext.Users.SingleOrDefault(u => u.Name == "Andriy")
                }
            };

            testWorks.ForEach(t => courseContext.TestWorks.AddOrUpdate(p => p.Id, t));
            courseContext.SaveChanges();

            base.Seed(courseContext);
        }
    }
}
