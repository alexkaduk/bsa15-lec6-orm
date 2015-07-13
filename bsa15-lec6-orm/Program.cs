using System;
using System.Runtime.Remoting.Contexts;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using bsa15_lec6_orm.Entities;
using bsa15_lec6_orm.Models;

namespace bsa15_lec6_orm
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new CourseContext();
            Console.WriteLine(ctx.Categories.Count().ToString());

            var bsa = new Bsa();

            bsa.InstructorRating();

            //Console.WriteLine(instructorsName);

            //// тут помилка (((
            //using (var ctx = new CourseContext())
            //{
            //    Console.WriteLine(ctx.Categories.Select(c=>c));
            //}
        }

    }
}
