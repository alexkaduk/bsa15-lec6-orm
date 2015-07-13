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
            // base.Seed(courseContext);
        }
    }
}
