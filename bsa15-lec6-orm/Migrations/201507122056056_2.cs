namespace bsa15_lec6_orm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instructors", "Lecture_Id", "dbo.Lectures");
            DropIndex("dbo.Instructors", new[] { "Lecture_Id" });
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
            
            DropColumn("dbo.Instructors", "Lecture_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instructors", "Lecture_Id", c => c.Int());
            DropForeignKey("dbo.InstructorLectures", "Lecture_Id", "dbo.Lectures");
            DropForeignKey("dbo.InstructorLectures", "Instructor_Id", "dbo.Instructors");
            DropIndex("dbo.InstructorLectures", new[] { "Lecture_Id" });
            DropIndex("dbo.InstructorLectures", new[] { "Instructor_Id" });
            DropTable("dbo.InstructorLectures");
            CreateIndex("dbo.Instructors", "Lecture_Id");
            AddForeignKey("dbo.Instructors", "Lecture_Id", "dbo.Lectures", "Id");
        }
    }
}
