namespace bsa15_lec6_orm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBaseAndInsertData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InstructorLectures", "Lecture_Id", "dbo.Lectures");
            DropForeignKey("dbo.InstructorLectures", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.LectureCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.LectureCategories", "Lecture_Id", "dbo.Lectures");
            DropIndex("dbo.InstructorLectures", new[] { "Lecture_Id" });
            DropIndex("dbo.InstructorLectures", new[] { "Instructor_Id" });
            DropIndex("dbo.LectureCategories", new[] { "Category_Id" });
            DropIndex("dbo.LectureCategories", new[] { "Lecture_Id" });
            DropTable("dbo.InstructorLectures");
            DropTable("dbo.LectureCategories");
            DropTable("dbo.Instructors");
            DropTable("dbo.Lectures");
            DropTable("dbo.Categories");
        }
    }
}
