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
            var bsa = new Bsa();

            //bsa.InsertData();

            // Task #1
            bsa.UsersPassTest();

            // Task #2
            bsa.UsersPassTestWithGoodTime();

            // Task #3
            bsa.UsersPassTestWithBadTime();

            // Task #4
            bsa.UsersGroupByCity();

            // Task #5
            bsa.UsersPassTestGroupByCity();


            // Task #7
            bsa.QuestionPopularityInTestRating();

            // Task #8
            bsa.InstructorRating();

            // Task #9
            bsa.TestAverageResultInCategory();

            Console.ReadKey();

        }

    }
}
