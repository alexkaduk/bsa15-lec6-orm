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
            _courseContext = new CourseContext();
        }

        private static CourseContext _courseContext;

        public void InsertData()
        {
            CreateInstructors();
            CreateCategories();
            InsertLectures();
            InsertQuestions();
            InsertTests();
            InsertUsers();
            InsertTestWork();
        }

        private static void InsertTestWork()
        {
            var testWorks = new List<TestWork>
            {
                new TestWork
                {
                    Id = 101,
                    Result = 90,
                    ExecutionTime = new TimeSpan(0, 25, 0),
                    Test = _courseContext.Tests.SingleOrDefault(t => t.Name == ".Net test bsa15"),
                    User = _courseContext.Users.SingleOrDefault(u => u.Name == "Alex")
                },
                new TestWork
                {
                    Id = 102,
                    Result = 95,
                    ExecutionTime = new TimeSpan(0, 19, 0),
                    Test = _courseContext.Tests.SingleOrDefault(t => t.Name == ".Net test bsa15"),
                    User = _courseContext.Users.SingleOrDefault(u => u.Name == "Jora")
                },
                new TestWork
                {
                    Id = 103,
                    Result = 110,
                    ExecutionTime = new TimeSpan(0, 15, 0),
                    Test = _courseContext.Tests.SingleOrDefault(t => t.Name == ".Net test bsa15"),
                    User = _courseContext.Users.SingleOrDefault(u => u.Name == "Roma")
                },
                new TestWork
                {
                    Id = 104,
                    Result = 110,
                    ExecutionTime = new TimeSpan(0, 28, 0),
                    Test = _courseContext.Tests.SingleOrDefault(t => t.Name == ".Net test bsa15"),
                    User = _courseContext.Users.SingleOrDefault(u => u.Name == "Sergiy")
                },
                new TestWork
                {
                    Id = 105,
                    Result = 105,
                    ExecutionTime = new TimeSpan(0, 18, 0),
                    Test = _courseContext.Tests.SingleOrDefault(t => t.Name == "JS test bsa15"),
                    User = _courseContext.Users.SingleOrDefault(u => u.Name == "Alex")
                },
                new TestWork
                {
                    Id = 106,
                    Result = 80,
                    ExecutionTime = new TimeSpan(0, 17, 0),
                    Test = _courseContext.Tests.SingleOrDefault(t => t.Name == "JS test bsa15"),
                    User = _courseContext.Users.SingleOrDefault(u => u.Name == "Jora")
                },
                new TestWork
                {
                    Id = 107,
                    Result = 70,
                    ExecutionTime = new TimeSpan(0, 22, 0),
                    Test = _courseContext.Tests.SingleOrDefault(t => t.Name == "PHP test bsa15"),
                    User = _courseContext.Users.SingleOrDefault(u => u.Name == "Jora")
                },
                new TestWork
                {
                    Id = 108,
                    Result = 120,
                    ExecutionTime = new TimeSpan(0, 16, 0),
                    Test = _courseContext.Tests.SingleOrDefault(t => t.Name == "PHP test bsa15"),
                    User = _courseContext.Users.SingleOrDefault(u => u.Name == "Roma")
                },
                new TestWork
                {
                    Id = 109,
                    Result = 130,
                    ExecutionTime = new TimeSpan(0, 35, 0),
                    Test = _courseContext.Tests.SingleOrDefault(t => t.Name == "PHP test bsa15"),
                    User = _courseContext.Users.SingleOrDefault(u => u.Name == "Andriy")
                }
            };

            testWorks.ForEach(t => _courseContext.TestWorks.AddOrUpdate(p => p.Id, t));
            _courseContext.SaveChanges();
        }

        private static void InsertUsers()
        {
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
                        _courseContext.Categories.SingleOrDefault(c => c.Name == ".Net"),
                        _courseContext.Categories.SingleOrDefault(c => c.Name == "JS")
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
                        _courseContext.Categories.SingleOrDefault(c => c.Name == ".Net"),
                        _courseContext.Categories.SingleOrDefault(c => c.Name == "JS"),
                        _courseContext.Categories.SingleOrDefault(c => c.Name == "PHP")
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
                        _courseContext.Categories.SingleOrDefault(c => c.Name == ".Net"),
                        _courseContext.Categories.SingleOrDefault(c => c.Name == "PHP")
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
                        _courseContext.Categories.SingleOrDefault(c => c.Name == ".Net")
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
                        _courseContext.Categories.SingleOrDefault(c => c.Name == ".PHP")
                    }
                }
            };

            users.ForEach(u => _courseContext.Users.AddOrUpdate(p => p.Id, u));
            _courseContext.SaveChanges();
        }

        private static void InsertTests()
        {
            var tests = new List<Test>
            {
                new Test
                {
                    TestId = 101,
                    Name = ".Net test bsa15",
                    MaxTime = new TimeSpan(0, 20, 0),
                    PassResult = 100,
                    Category = _courseContext.Categories.SingleOrDefault(c=>c.Name==".Net"),
                    Questions = new List<Question>
                    {
                        _courseContext.Questions.SingleOrDefault(i=>i.Id == 1), _courseContext.Questions.SingleOrDefault(i=>i.Id == 2),
                        _courseContext.Questions.SingleOrDefault(i=>i.Id == 7), _courseContext.Questions.SingleOrDefault(i=>i.Id == 8), 
                        _courseContext.Questions.SingleOrDefault(i=>i.Id == 9), _courseContext.Questions.SingleOrDefault(i=>i.Id == 10), 
                        _courseContext.Questions.SingleOrDefault(i=>i.Id == 11), _courseContext.Questions.SingleOrDefault(i=>i.Id == 12),
                        _courseContext.Questions.SingleOrDefault(i=>i.Id == 13)
                    }
                },
                new Test
                {
                    TestId = 102,
                    Name = "JS test bsa15",
                    MaxTime = new TimeSpan(0, 20, 0),
                    PassResult = 100,
                    Category = _courseContext.Categories.SingleOrDefault(c=>c.Name=="JS"),
                    Questions = new List<Question>
                    {
                        _courseContext.Questions.SingleOrDefault(i=>i.Id == 3), _courseContext.Questions.SingleOrDefault(i=>i.Id == 4),
                        _courseContext.Questions.SingleOrDefault(i=>i.Id == 7), _courseContext.Questions.SingleOrDefault(i=>i.Id == 9),
                        _courseContext.Questions.SingleOrDefault(i=>i.Id == 11), _courseContext.Questions.SingleOrDefault(i=>i.Id == 13)
                    }
                },
                new Test
                {
                    TestId = 103,
                    Name = "PHP test bsa15",
                    MaxTime = new TimeSpan(0, 20, 0),
                    PassResult = 100,
                    Category = _courseContext.Categories.SingleOrDefault(c=>c.Name=="PHP"),
                    Questions = new List<Question>
                    {
                        _courseContext.Questions.SingleOrDefault(i=>i.Id == 5), _courseContext.Questions.SingleOrDefault(i=>i.Id == 6),
                        _courseContext.Questions.SingleOrDefault(i=>i.Id == 7), _courseContext.Questions.SingleOrDefault(i=>i.Id == 9),
                        _courseContext.Questions.SingleOrDefault(i=>i.Id == 11), _courseContext.Questions.SingleOrDefault(i=>i.Id == 13)
                    }
                }
            };

            tests.ForEach(t => _courseContext.Tests.AddOrUpdate(p => p.TestId, t));
            _courseContext.SaveChanges();
        }

        private static void InsertQuestions()
        {
            var questions = new List<Question>
            {
                new Question { Id = 1, Text = ".NET question 1", Category = _courseContext.Categories.SingleOrDefault(c=>c.Name==".Net") },
                new Question { Id = 2, Text = ".NET question 2", Category = _courseContext.Categories.SingleOrDefault(c=>c.Name==".Net") },
                new Question { Id = 3, Text = "JS question 1", Category = _courseContext.Categories.SingleOrDefault(c=>c.Name=="JS") },
                new Question { Id = 4, Text = "JS question 2", Category = _courseContext.Categories.SingleOrDefault(c=>c.Name=="JS") },
                new Question { Id = 5, Text = "PHP question 1", Category = _courseContext.Categories.SingleOrDefault(c=>c.Name=="PHP") },
                new Question { Id = 6, Text = "PHP question 2", Category = _courseContext.Categories.SingleOrDefault(c=>c.Name=="PHP") },
                new Question { Id = 7, Text = "DB question 1", Category = _courseContext.Categories.SingleOrDefault(c=>c.Name=="DB") },
                new Question { Id = 8, Text = "DB question 2", Category = _courseContext.Categories.SingleOrDefault(c=>c.Name=="DB") },
                new Question { Id = 9, Text = "English question 1", Category = _courseContext.Categories.SingleOrDefault(c=>c.Name=="English") },
                new Question { Id = 10, Text = "English question 2", Category = _courseContext.Categories.SingleOrDefault(c=>c.Name=="English") },
                new Question { Id = 11, Text = "OOP question 1", Category = _courseContext.Categories.SingleOrDefault(c=>c.Name=="OOP") },
                new Question { Id = 12, Text = "OOP question 2", Category = _courseContext.Categories.SingleOrDefault(c=>c.Name=="OOP") },
                new Question { Id = 13, Text = "OOP question 3", Category = _courseContext.Categories.SingleOrDefault(c=>c.Name=="OOP") }
            };

            questions.ForEach(q => _courseContext.Questions.AddOrUpdate(p => p.Id, q));
            _courseContext.SaveChanges();
        }

        private static void InsertLectures()
        {
            var lectures = new List<Lecture>
            {
                new Lecture
                {
                    Id = 1001, 
                    Name = "lec1 introduction", 
                    Description = "lec1 description", 
                    Categories = new List<Category>
                    {
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == ".Net"),
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == "JS"),
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == "PHP")
                    },
                    Instructors = new List<Instructor>
                    {
                        _courseContext.Instructors.SingleOrDefault(i=>i.Name == "Bob"),
                        _courseContext.Instructors.SingleOrDefault(i=>i.Name == "Tom"),
                        _courseContext.Instructors.SingleOrDefault(i=>i.Name == "John")
                    }
                },
                new Lecture
                {
                    Id = 1002, 
                    Name = "lec2 modern commercial programming", 
                    Description = "lec2 description", 
                    Categories = new List<Category>
                    {
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == ".Net"),
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == "JS"),
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == "PHP")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        _courseContext.Instructors.SingleOrDefault(i=>i.Name == "Bob")
                    }
                },
                new Lecture
                {
                    Id = 1003, 
                    Name = "lec3 GIT", 
                    Description = "lec3 description", 
                    Categories = new List<Category>
                    {
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == ".Net"),
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == "JS"),
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == "PHP")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        _courseContext.Instructors.SingleOrDefault(i=>i.Name == "Tom")
                    }
                },
                new Lecture { Id = 1004,
                    Name = "lec4 .Net data structures and LINQ", 
                    Description = "lec4 description",
                    Categories = new List<Category>
                    {
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == ".Net")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        _courseContext.Instructors.SingleOrDefault(i=>i.Name == "Tom")
                    }
                },
                new Lecture
                {
                    Id = 1005,
                    Name = "lec5 SQL", 
                    Description = "lec5 description",
                    Categories = new List<Category>
                    {
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == "DB")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        _courseContext.Instructors.SingleOrDefault(i=>i.Name == "Tom")
                    }
                },
                new Lecture { 
                    Id = 1006,
                    Name = "lec6 code testing", 
                    Description = "lec6 description", 
                    Categories = new List<Category>
                    {
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == ".Net"),
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == "JS"),
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == "PHP")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        _courseContext.Instructors.SingleOrDefault(i=>i.Name == "Tom")
                    }
                },
                new Lecture
                {
                    Id = 1007, 
                    Name = "lec7 PHP introduction",
                    Description = "lec7 description", 
                    Categories = new List<Category>
                    {
                         _courseContext.Categories.SingleOrDefault(c=>c.Name == "PHP")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        _courseContext.Instructors.SingleOrDefault(i=>i.Name == "John")
                    }
                },
                new Lecture { Id = 1008, 
                    Name = "lec8 HTML, CSS", 
                    Description = "lec8 description", 
                    Categories = new List<Category>
                    {
                         _courseContext.Categories.SingleOrDefault(c=>c.Name == "JS")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        _courseContext.Instructors.SingleOrDefault(i=>i.Name == "Bob")
                    }
                },
                new Lecture
                {
                    Id = 1009, 
                    Name = "lec9 JS, JQuery",
                    Description = "lec9 description",
                    Categories = new List<Category>
                    {
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == "JS")
                    }, 
                    Instructors = new List<Instructor>
                    {
                        _courseContext.Instructors.SingleOrDefault(i=>i.Name == "Bob")
                    }
                },
                new Lecture
                {
                    Id = 1010, 
                    Name = "lec10 Angular",
                    Description = "lec10 description", 
                    Categories = new List<Category>
                    {
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == "JS")
                    },
                    Instructors = new List<Instructor>
                    {
                        _courseContext.Instructors.SingleOrDefault(i=>i.Name == "Bob")
                    }
                },
                new Lecture
                {
                    Id = 1011, 
                    Name = "lec11 english introduction", 
                    Description = "lec11 description", 
                    Categories = new List<Category>
                    {
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == "English")
                    },
                    Instructors = new List<Instructor>
                    {
                        _courseContext.Instructors.SingleOrDefault(i=>i.Name == "John")
                    }
                },
                new Lecture
                {
                    Id = 1012, 
                    Name = "lec12 OOP introduction",
                    Description = "lec12 description", 
                    Categories = new List<Category>
                    {
                        _courseContext.Categories.SingleOrDefault(c=>c.Name == "OOP")
                    },
                    Instructors = new List<Instructor>
                    {
                        _courseContext.Instructors.SingleOrDefault(i=>i.Name == "Bob"),
                        _courseContext.Instructors.SingleOrDefault(i=>i.Name == "John")
                    }
                }
            };

            lectures.ForEach(l => _courseContext.Lectures.AddOrUpdate(p => p.Id, l));
            _courseContext.SaveChanges();
        }

        private static void CreateCategories()
        {
            var categories = new List<Category>
            {
                new Category { Name = ".Net" },
                new Category { Name = "JS" },
                new Category { Name = "PHP" },
                new Category { Name = "DB" },
                new Category { Name = "OOP" },
                new Category { Name = "English" }
            };
            categories.ForEach(c => _courseContext.Categories.AddOrUpdate(p => p.Name, c));
            _courseContext.SaveChanges();

        }

        private static void CreateInstructors()
        {
            var instructors = new List<Instructor>
            {
                new Instructor { Name = "Bob" },
                new Instructor { Name = "Tom" },
                new Instructor { Name = "John" }
            };
            instructors.ForEach(t => _courseContext.Instructors.AddOrUpdate(p => p.Name, t));
            _courseContext.SaveChanges();
        }

        //1.	Список людей, которые прошли тесты.
        public void UsersPassTest()
        {
            var users = from work in _courseContext.TestWorks
                            where work.Result >= work.Test.PassResult
                            select work;
            
            Console.WriteLine("Task #1");
            foreach (var item in users)
            {
                Console.WriteLine("{0} pass '{1}' (mark {2}, pass mark {3})", item.User.Name, item.Test.Name, item.Result, item.Test.PassResult);
            }
            Console.WriteLine();
        }

        //2.	Список тех, кто прошли тесты успешно и уложилися во время.
        public void UsersPassTestWithGoodTime()
        {
            var users = from work in _courseContext.TestWorks
                        where work.Result >= work.Test.PassResult && work.ExecutionTime<=work.Test.MaxTime
                        select work;

            Console.WriteLine("Task #2");
            foreach (var item in users)
            {
                Console.WriteLine("{0} pass '{1}' with time {4} min (mark {2}, pass mark {3}, pass time {5} min)", item.User.Name, item.Test.Name, item.Result, item.Test.PassResult, item.ExecutionTime.Minutes, item.Test.MaxTime.Minutes);
            }
            Console.WriteLine();
        }

        //3.	Список людей, которые прошли тесты успешно и не уложились во время
        public void UsersPassTestWithBadTime()
        {
            var users = from work in _courseContext.TestWorks
                        where work.Result >= work.Test.PassResult && work.ExecutionTime > work.Test.MaxTime
                        select work;

            Console.WriteLine("Task #3");
            foreach (var item in users)
            {
                Console.WriteLine("{0} pass '{1}' with bad time {4} min (mark {2}, pass mark {3}, pass time {5} min)", item.User.Name, item.Test.Name, item.Result, item.Test.PassResult, item.ExecutionTime.Minutes, item.Test.MaxTime.Minutes);
            }
            Console.WriteLine();
        }

        //4.	Список студентов по городам. (Например: из Львова: 10 студентов, из Киева: 20)
        public void UsersGroupByCity()
        {
            var usersFromCity = from user in _courseContext.Users
                                group user by user.City into g
                                select new
                                {
                                    City = g.Key,
                                    Count = g.Count()
                                };

            Console.WriteLine("Task #4");
            foreach (var item in usersFromCity)
            {
                Console.WriteLine("from {0}: {1} student(s)", item.City, item.Count);
            }
            Console.WriteLine();
        }

        //5.	Список успешных студентов по городам.
        public void UsersPassTestGroupByCity()
        {
            var users =
                _courseContext.TestWorks.Where(
                    tw => (tw. Result >= tw.Test.PassResult))
                    .GroupBy(c => c.User.City, (city, user) => new { City = city, Users = user });

            Console.WriteLine("Task #5");
           
            foreach (var item in users) 
                 {
                     Console.WriteLine("from {0}: {1} student(s)", item.City, item.Users.Count()); 
                     foreach (var s in item.Users) 
                     {
                         Console.WriteLine("\t {0}, {1}, {2}, category '{3}' (result {4}, time {5} min)", s.User.Name, s.User.Email, s.User.University, s.Test.Category.Name, s.Result, s.ExecutionTime.Minutes); 
                     } 
                 } 

            Console.WriteLine();
        }

        //6.	Результат для каждого студента - его баллы, время, баллы в процентах для каждой категории.
        // Кожний тест має у собі кілька питань різноманітних категорій, наприклад, ооп, .нет, бд. 
        // Кожне питання має кількість балів за вірну відповідь, якщо цього не виставляти, то можна рахувати, що вірна відповідь 1 бал. 
        // Таким чином у тесті, наприклад, 5 питань з категорії .нет. Максимально можна набрати 5 балів. Якщо вірно відповів користувач на 3 питання, то це 3 / 5  * 100 = 60%.
        public void UserResultsAndPercentForCategory()
        {
            //var averageByCategory = _courseContext.TestWorks.GroupBy(x => x.Test.Category,
            //    (cat, average) => new { Category = cat, Average = average.Average(y => y.Result) });
            ////.Select(x => new { x.Key.Name, Average = x.Average(y => y.Result) });

            //Console.WriteLine("Task# 9");
            //foreach (var i in averageByCategory)
            //{
            //    Console.WriteLine("Test '{0}' (id {1}) ", i.Category.Name, i.Average);
            //}
            //Console.WriteLine();
        }

        //7.	Рейтинг популярности вопросов в тестах (выводить количество использования данного вопроса в тестах)
        public void QuestionPopularityInTestRating()
        {
            var querty = from q in _courseContext.Questions
                from t in q.Tests
                group q by q.Id
                into g
                let sum = g.Count()
                orderby sum descending, g.Key ascending
                select new
                {
                    Question = g.FirstOrDefault(),
                    Count = sum
                };

            Console.WriteLine("Task# 7");
            foreach (var i in querty)
            {
                Console.WriteLine("Question #{0} have been user {1} times (text: '{2}')...", i.Question.Id.ToString(), i.Count, i.Question.Text.ToString());
            }
            Console.WriteLine();
        }

        //8.	Рейтинг учителей по количеству лекций (Количество прочитанных лекций)
        public void InstructorRating()
        {
            var querty = from i in _courseContext.Instructors
                         from l in i.Lectures
                         group i by i.Id
                             into g
                             let sum = g.Count()
                             orderby sum descending
                             select new
                             {
                                 Instructor = g.FirstOrDefault(),
                                 LectureCount = sum
                             };

            Console.WriteLine("Task# 8");
            foreach (var i in querty)
            {
                Console.WriteLine("Instructor {0} lectures {1} times...", i.Instructor.Name, i.LectureCount);
            }
            Console.WriteLine();
        }

        //9.	Средний бал тестов по категориям, отсортированый по убыванию.
        public void TestAverageResultInCategory()
        {
            var averageByCategory = _courseContext.TestWorks.GroupBy(x => x.Test.Category,
                (cat, average) => new {Category = cat, Average = average.Average(y=>y.Result)});
                //.Select(x => new { x.Key.Name, Average = x.Average(y => y.Result) });

            Console.WriteLine("Task# 9");
            foreach (var i in averageByCategory)
            {
                Console.WriteLine("Category '{0}': average makr {1} ", i.Category.Name, i.Average);
            }
            Console.WriteLine();
        }

        //10.	Рейтинг вопросов по набранным баллам
        public void QuestionResultRating()
        {

        }
    }
}
