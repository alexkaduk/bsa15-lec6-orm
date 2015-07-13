namespace bsa15_lec6_orm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Lecture_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lectures", t => t.Lecture_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Lecture_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Lecture_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lectures", t => t.Lecture_Id)
                .Index(t => t.Lecture_Id);
            
            CreateTable(
                "dbo.Lectures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        Category_Id = c.Int(),
                        Test_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Test_Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MaxTime = c.Time(nullable: false, precision: 7),
                        PassResult = c.Int(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.TestWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Result = c.Int(nullable: false),
                        ExecutionTime = c.Time(nullable: false, precision: 7),
                        Test_Id = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Test_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        Age = c.Int(nullable: false),
                        City = c.String(),
                        University = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestWorks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Categories", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TestWorks", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Questions", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Tests", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Questions", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Instructors", "Lecture_Id", "dbo.Lectures");
            DropForeignKey("dbo.Categories", "Lecture_Id", "dbo.Lectures");
            DropIndex("dbo.TestWorks", new[] { "User_Id" });
            DropIndex("dbo.TestWorks", new[] { "Test_Id" });
            DropIndex("dbo.Tests", new[] { "Category_Id" });
            DropIndex("dbo.Questions", new[] { "Test_Id" });
            DropIndex("dbo.Questions", new[] { "Category_Id" });
            DropIndex("dbo.Instructors", new[] { "Lecture_Id" });
            DropIndex("dbo.Categories", new[] { "User_Id" });
            DropIndex("dbo.Categories", new[] { "Lecture_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.TestWorks");
            DropTable("dbo.Tests");
            DropTable("dbo.Questions");
            DropTable("dbo.Lectures");
            DropTable("dbo.Instructors");
            DropTable("dbo.Categories");
        }
    }
}
