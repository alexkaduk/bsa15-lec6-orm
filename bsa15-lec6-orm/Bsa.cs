using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bsa15_lec6_orm.Entities;
using bsa15_lec6_orm.Models;

namespace bsa15_lec6_orm
{
    class Bsa
    {
        public Bsa()
        {
            courseContext = new CourseContext();
        }

        private readonly CourseContext courseContext;

        List<TestWork> testWorks;
        List<User> users;


        // 8.	Рейтинг учителей по количеству лекций (Количество прочитанных лекций)
        public void InstructorRating()
        {
            #region Add data to Instructor table

            var instructors = new List<Instructor>
            {
                new Instructor { Name = "Bob" },
                new Instructor { Name = "Tom" },
                new Instructor { Name = "John" }
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

            #region Add data to Lecture table

            var lectures = new List<Lecture>
            {
                new Lecture
                {
                    Id = 1001, 
                    Name = "lec1 introduction", 
                    Description = "lec1 description", 
                    Categories = new List<Category>
                    {
                        categories.Single(c=>c.Name == ".Net"),
                        categories.Single(c=>c.Name == "JS"),
                        categories.Single(c=>c.Name == "PHP")
                    },
                    Instructors = new List<Instructor>
                    {
                        instructors.Single(i=>i.Name == "Bob"),
                        instructors.Single(i=>i.Name == "Tom"),
                        instructors.Single(i=>i.Name == "John")
                    }
                },
                new Lecture
                {
                    Id = 1002, 
                    Name = "lec2 modern commercial programming", 
                    Description = "lec2 description", 
                    Categories = new List<Category>
                    {
                        categories.Single(c=>c.Name == ".Net"),
                        categories.Single(c=>c.Name == "JS"),
                        categories.Single(c=>c.Name == "PHP")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        instructors.Single(i=>i.Name == "Bob")
                    }
                },
                new Lecture
                {
                    Id = 1003, 
                    Name = "lec3 GIT", 
                    Description = "lec3 description", 
                    Categories = new List<Category>
                    {
                        categories.Single(c=>c.Name == ".Net"),
                        categories.Single(c=>c.Name == "JS"),
                        categories.Single(c=>c.Name == "PHP")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        instructors.Single(i=>i.Name == "Tom")
                    }
                },
                new Lecture { Id = 1004,
                    Name = "lec4 .Net data structures and LINQ", 
                    Description = "lec4 description",
                    Categories = new List<Category>
                    {
                        categories.Single(c=>c.Name == ".Net")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        instructors.Single(i=>i.Name == "Tom")
                    }
                },
                new Lecture
                {
                    Id = 1005,
                    Name = "lec5 SQL", 
                    Description = "lec5 description",
                    Categories = new List<Category>
                    {
                        categories.Single(c=>c.Name == "DB")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        instructors.Single(i=>i.Name == "Tom")
                    }
                },
                new Lecture { 
                    Id = 1006,
                    Name = "lec6 code testing", 
                    Description = "lec6 description", 
                    Categories = new List<Category>
                    {
                        categories.Single(c=>c.Name == ".Net"),
                        categories.Single(c=>c.Name == "JS"),
                        categories.Single(c=>c.Name == "PHP")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        instructors.Single(i=>i.Name == "Tom")
                    }
                },
                new Lecture
                {
                    Id = 1007, 
                    Name = "lec7 PHP introduction",
                    Description = "lec7 description", 
                    Categories = new List<Category>
                    {
                         categories.Single(c=>c.Name == "PHP")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        instructors.Single(i=>i.Name == "John")
                    }
                },
                new Lecture { Id = 1008, 
                    Name = "lec8 HTML, CSS", 
                    Description = "lec8 description", 
                    Categories = new List<Category>
                    {
                         categories.Single(c=>c.Name == "JS")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        instructors.Single(i=>i.Name == "Bob")
                    }
                },
                new Lecture
                {
                    Id = 1009, 
                    Name = "lec9 JS, JQuery",
                    Description = "lec9 description",
                    Categories = new List<Category>
                    {
                        categories.Single(c=>c.Name == "JS")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        instructors.Single(i=>i.Name == "Bob")
                    }
                },
                new Lecture
                {
                    Id = 1010, 
                    Name = "lec10 Angular",
                    Description = "lec10 description", 
                    Categories = new List<Category>
                    {
                        categories.Single(c=>c.Name == "JS")
                    },
                    Instructors = new List<Instructor>
                    {
                        instructors.Single(i=>i.Name == "Bob")
                    }
                },
                new Lecture
                {
                    Id = 1011, 
                    Name = "lec11 english introduction", 
                    Description = "lec11 description", 
                    Categories = new List<Category>
                    {
                        categories.Single(c=>c.Name == "English")
                    },
                    Instructors = new List<Instructor>
                    {
                        instructors.Single(i=>i.Name == "John")
                    }
                },
                new Lecture
                {
                    Id = 1012, 
                    Name = "lec12 OOP introduction",
                    Description = "lec12 description", 
                    Categories = new List<Category>
                    {
                        categories.Single(c=>c.Name == "OOP")
                    },
                    Instructors = new List<Instructor>
                    {
                        instructors.Single(i=>i.Name == "Bob"),
                        instructors.Single(i=>i.Name == "John")
                    }
                }
            };

            lectures.ForEach(l => courseContext.Lectures.AddOrUpdate(p => p.Id, l));
            courseContext.SaveChanges();

            #endregion

            #region Add data to Question table

            var questions = new List<Question>
            {
                new Question { Id = 1, Text = ".NET question 1", Category = categories[0] },
                new Question { Id = 2, Text = ".NET question 2", Category = categories[0] },
                new Question { Id = 3, Text = "JS question 1", Category = categories[1] },
                new Question { Id = 4, Text = "JS question 2", Category = categories[1] },
                new Question { Id = 5, Text = "PHP question 1", Category = categories[2] },
                new Question { Id = 6, Text = "PHP question 2", Category = categories[2] },
                new Question { Id = 7, Text = "DB question 1", Category = categories[3] },
                new Question { Id = 8, Text = "DB question 2", Category = categories[3] },
                new Question { Id = 9, Text = "English question 1", Category = categories[4] },
                new Question { Id = 10, Text = "English question 2", Category = categories[4] },
                new Question { Id = 11, Text = "OOP question 1", Category = categories[5] },
                new Question { Id = 12, Text = "OOP question 2", Category = categories[5] },
                new Question { Id = 13, Text = "OOP question 3", Category = categories[5] }
            };

            questions.ForEach(q => courseContext.Questions.AddOrUpdate(p => p.Id, q));
            courseContext.SaveChanges();

            #endregion

            #region Add data to Test table

            var tests = new List<Test>
            {
                new Test
                {
                    Id = 101,
                    Name = ".NET test bsa15",
                    MaxTime = new TimeSpan(0, 20, 0),
                    PassResult = 100,
                    Category = categories[0],
                    Questions = new List<Question>
                    {
                        questions.Single(i=>i.Id == 1), questions.Single(i=>i.Id == 2),
                        questions.Single(i=>i.Id == 7), questions.Single(i=>i.Id == 8), 
                        questions.Single(i=>i.Id == 9), questions.Single(i=>i.Id == 10), 
                        questions.Single(i=>i.Id == 11), questions.Single(i=>i.Id == 12),
                        questions.Single(i=>i.Id == 13)
                    }
                },
                new Test
                {
                    Id = 102,
                    Name = ".JS test bsa15",
                    MaxTime = new TimeSpan(0, 20, 0),
                    PassResult = 100,
                    Category = categories[1],
                    Questions = new List<Question>
                    {
                        questions.Single(i=>i.Id == 3), questions.Single(i=>i.Id == 4),
                        questions.Single(i=>i.Id == 7), questions.Single(i=>i.Id == 9),
                        questions.Single(i=>i.Id == 11), questions.Single(i=>i.Id == 13)
                    }
                },
                new Test
                {
                    Id = 103,
                    Name = ".PHP test bsa15",
                    MaxTime = new TimeSpan(0, 20, 0),
                    PassResult = 100,
                    Category = categories[2],
                    Questions = new List<Question>
                    {
                        questions.Single(i=>i.Id == 5), questions.Single(i=>i.Id == 6),
                        questions.Single(i=>i.Id == 7), questions.Single(i=>i.Id == 9),
                        questions.Single(i=>i.Id == 11), questions.Single(i=>i.Id == 13)
                    }
                }
            };

            tests.ForEach(t => courseContext.Tests.AddOrUpdate(p => p.Id, t));
            courseContext.SaveChanges();

            #endregion

            #region Add data to User table

            users = new List<User>
            {
                new User {  Name = "Alex", Email = "alex@i.ua", Age = 20, City = "Kyiv", University = "KPI", 
                            Categories = new List<Category>
                            {
                                categories.Single(c=>c.Name == ".NET"),
                                categories.Single(c=>c.Name == "JS")
                            }
                },
                new User {  Name = "Jora", Email = "jora@i.ua", Age = 22, City = "Lviv", University = "Lviv Politechnic", 
                            Categories = new List<Category>
                            {
                                categories.Single(c=>c.Name == ".NET"),
                                categories.Single(c=>c.Name == "JS"),
                                categories.Single(c=>c.Name == "PHP")
                            }
                },
                new User {  Name = "Roma", Email = "roma@i.ua", Age = 25, City = "Kyiv", University = "NaUKMA", 
                            Categories = new List<Category>
                            {
                                categories.Single(c=>c.Name == ".NET"),
                                categories.Single(c=>c.Name == "PHP")
                            }
                },
                new User {  Name = "Sergiy", Email = "sergiy@i.ua", Age = 27, City = "Vinnytsia", University = "VNTU", 
                            Categories = new List<Category>
                            {
                                categories.Single(c=>c.Name == ".NET")
                            }
                },
                new User {  Name = "Andriy", Email = "andriy@i.ua", Age = 30, City = "Odesa", University = "OPU", 
                            Categories = new List<Category>
                            {
                                categories.Single(c=>c.Name == ".PHP")
                            }
                }

            };

            //users = new List<User>
            //{
            //    //new User {  Name = "Alex", Email = "alex@i.ua", Age = 20, City = "Kyiv", University = "KPI"} 
                            
            //    new User {  Name = "Alex", Email = "alex@i.ua", Age = 20, City = "Kyiv", University = "KPI", 
            //                Categories = new List<Category>
            //                {
            //                    categories.Single(c=>c.Name == ".NET"),
            //                    categories.Single(c=>c.Name == "JS")
            //                },
            //                TestWorks = new List<TestWork>
            //                {
            //                    testWorks.Single(i=>i.Id == 101),
            //                    testWorks.Single(i=>i.Id == 105)
            //                }
            //    },
            //    new User {  Name = "Jora", Email = "jora@i.ua", Age = 22, City = "Lviv", University = "Lviv Politechnic", 
            //                Categories = new List<Category>
            //                {
            //                    categories.Single(c=>c.Name == ".NET"),
            //                    categories.Single(c=>c.Name == "JS"),
            //                    categories.Single(c=>c.Name == "PHP")
            //                },
            //                TestWorks = new List<TestWork>
            //                {
            //                    testWorks.Single(i=>i.Id == 102),
            //                    testWorks.Single(i=>i.Id == 106),
            //                    testWorks.Single(i=>i.Id == 107)
            //                }
            //    },
            //    new User {  Name = "Roma", Email = "roma@i.ua", Age = 25, City = "Kyiv", University = "NaUKMA", 
            //                Categories = new List<Category>
            //                {
            //                    categories.Single(c=>c.Name == ".NET"),
            //                    categories.Single(c=>c.Name == "PHP")
            //                },
            //                TestWorks = new List<TestWork>
            //                {
            //                    testWorks.Single(i=>i.Id == 103),
            //                    testWorks.Single(i=>i.Id == 108)
            //                }
            //    },
            //    new User {  Name = "Sergiy", Email = "sergiy@i.ua", Age = 27, City = "Vinnytsia", University = "VNTU", 
            //                Categories = new List<Category>
            //                {
            //                    categories.Single(c=>c.Name == ".NET")
            //                },
            //                TestWorks = new List<TestWork>
            //                {
            //                    testWorks.Single(i=>i.Id == 104)
            //                }
            //    },
            //    new User {  Name = "Andriy", Email = "andriy@i.ua", Age = 30, City = "Odesa", University = "OPU", 
            //                Categories = new List<Category>
            //                {
            //                    categories.Single(c=>c.Name == ".PHP")
            //                },
            //                TestWorks = new List<TestWork>
            //                {
            //                    testWorks.Single(i=>i.Id == 109)
            //                }
            //    }

            //};

            users.ForEach(u => courseContext.Users.AddOrUpdate(p => p.Id, u));
            courseContext.SaveChanges();

            #endregion

            #region Add data to TestWokr table

            testWorks = new List<TestWork>
            {
                new TestWork
                {
                    Id = 101,
                    Result = 90,
                    ExecutionTime = new TimeSpan(0, 25, 0),
                    Test = tests.Single(t=>t.Id==101),
                    User = users.Single(u=>u.Name == "Alex")
                },
                new TestWork
                {
                    Id = 102,
                    Result = 95,
                    ExecutionTime = new TimeSpan(0, 19, 0),
                    Test = tests.Single(t=>t.Id==101),
                    User = users.Single(u=>u.Name == "Jora")
                },
                new TestWork
                {
                    Id = 103,
                    Result = 110,
                    ExecutionTime = new TimeSpan(0, 15, 0),
                    Test = tests.Single(t=>t.Id==101),
                    User = users.Single(u=>u.Name == "Roma")
                },
                new TestWork
                {
                    Id = 104,
                    Result = 110,
                    ExecutionTime = new TimeSpan(0, 28, 0),
                    Test = tests.Single(t=>t.Id==101),
                    User = users.Single(u=>u.Name == "Sergey")
                },
                new TestWork
                {
                    Id = 105,
                    Result = 105,
                    ExecutionTime = new TimeSpan(0, 18, 0),
                    Test = tests.Single(t=>t.Id==102),
                    User = users.Single(u=>u.Name == "Alex")
                },
                new TestWork
                {
                    Id = 106,
                    Result = 80,
                    ExecutionTime = new TimeSpan(0, 17, 0),
                    Test = tests.Single(t=>t.Id==102),
                    User = users.Single(u=>u.Name == "Jora")
                },
                new TestWork
                {
                    Id = 107,
                    Result = 70,
                    ExecutionTime = new TimeSpan(0, 22, 0),
                    Test = tests.Single(t=>t.Id==103),
                    User = users.Single(u=>u.Name == "Jora")
                },
                new TestWork
                {
                    Id = 108,
                    Result = 120,
                    ExecutionTime = new TimeSpan(0, 16, 0),
                    Test = tests.Single(t=>t.Id==103),
                    User = users.Single(u=>u.Name == "Roma")
                },
                new TestWork
                {
                    Id = 109,
                    Result = 130,
                    ExecutionTime = new TimeSpan(0, 35, 0),
                    Test = tests.Single(t=>t.Id==103),
                    User = users.Single(u=>u.Name == "Andriy")
                }
            };

            testWorks.ForEach(t => courseContext.TestWorks.AddOrUpdate(p => p.Id, t));
            courseContext.SaveChanges();

            #endregion

            



            //var querty = from i in _ctx.Instructors
            //    from l in i.Lectures
            //    group i by i.Id
            //    into g
            //    let sum = g.Count()
            //    orderby sum descending
            //    select new
            //    {
            //        Instructor = g.FirstOrDefault(),
            //        LectureCount = sum
            //    };

            //Console.WriteLine("Task# 8");
            //foreach (var i in querty)
            //{
            //    Console.WriteLine("Instructor {0} lectures {1} times...", i.Instructor.Name, i.LectureCount);
            //}
            //Console.WriteLine();



        }
    }
}
