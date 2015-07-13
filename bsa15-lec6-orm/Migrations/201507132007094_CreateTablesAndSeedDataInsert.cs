namespace bsa15_lec6_orm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTablesAndSeedDataInsert : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lectures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MaxTime = c.Time(nullable: false, precision: 7),
                        PassResult = c.Int(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.TestId)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.TestWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Result = c.Int(nullable: false),
                        ExecutionTime = c.Time(nullable: false, precision: 7),
                        Test_TestId = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Test_TestId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Test_TestId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Age = c.Int(nullable: false),
                        City = c.String(),
                        University = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LectureCategories",
                c => new
                    {
                        Lecture_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lecture_Id, t.Category_Id })
                .ForeignKey("dbo.Lectures", t => t.Lecture_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Lecture_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.InstructorLectures",
                c => new
                    {
                        Instructor_Id = c.Int(nullable: false),
                        Lecture_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_Id, t.Lecture_Id })
                .ForeignKey("dbo.Instructors", t => t.Instructor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Lectures", t => t.Lecture_Id, cascadeDelete: true)
                .Index(t => t.Instructor_Id)
                .Index(t => t.Lecture_Id);
            
            CreateTable(
                "dbo.TestQuestion",
                c => new
                    {
                        TestRefId = c.Int(nullable: false),
                        QuestionRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TestRefId, t.QuestionRefId })
                .ForeignKey("dbo.Tests", t => t.TestRefId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionRefId, cascadeDelete: true)
                .Index(t => t.TestRefId)
                .Index(t => t.QuestionRefId);
            
            CreateTable(
                "dbo.UserCategories",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Category_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestWorks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.UserCategories", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TestWorks", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.TestQuestion", "QuestionRefId", "dbo.Questions");
            DropForeignKey("dbo.TestQuestion", "TestRefId", "dbo.Tests");
            DropForeignKey("dbo.Tests", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Questions", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.InstructorLectures", "Lecture_Id", "dbo.Lectures");
            DropForeignKey("dbo.InstructorLectures", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.LectureCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.LectureCategories", "Lecture_Id", "dbo.Lectures");
            DropIndex("dbo.UserCategories", new[] { "Category_Id" });
            DropIndex("dbo.UserCategories", new[] { "User_Id" });
            DropIndex("dbo.TestQuestion", new[] { "QuestionRefId" });
            DropIndex("dbo.TestQuestion", new[] { "TestRefId" });
            DropIndex("dbo.InstructorLectures", new[] { "Lecture_Id" });
            DropIndex("dbo.InstructorLectures", new[] { "Instructor_Id" });
            DropIndex("dbo.LectureCategories", new[] { "Category_Id" });
            DropIndex("dbo.LectureCategories", new[] { "Lecture_Id" });
            DropIndex("dbo.TestWorks", new[] { "User_Id" });
            DropIndex("dbo.TestWorks", new[] { "Test_TestId" });
            DropIndex("dbo.Tests", new[] { "Category_Id" });
            DropIndex("dbo.Questions", new[] { "Category_Id" });
            DropTable("dbo.UserCategories");
            DropTable("dbo.TestQuestion");
            DropTable("dbo.InstructorLectures");
            DropTable("dbo.LectureCategories");
            DropTable("dbo.Users");
            DropTable("dbo.TestWorks");
            DropTable("dbo.Tests");
            DropTable("dbo.Questions");
            DropTable("dbo.Instructors");
            DropTable("dbo.Lectures");
            DropTable("dbo.Categories");
        }
    }
}
