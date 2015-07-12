using System;
using System.Runtime.Remoting.Contexts;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using bsa15_lec6_orm.Models;

namespace bsa15_lec6_orm
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new Context();

            Console.WriteLine(ctx.ContextID.ToString());

            // тут помилка (((
            //using (Context ctx = new Context())
            //{
            //    Console.WriteLine(ctx.ToString());
            //}
        }
    }
}
