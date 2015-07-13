namespace bsa15_lec6_orm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Lecture_Id", "dbo.Lectures");
            DropForeignKey("dbo.Categories", "User_Id", "dbo.Users");
            DropIndex("dbo.Categories", new[] { "Lecture_Id" });
            DropIndex("dbo.Categories", new[] { "User_Id" });
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
            
            DropColumn("dbo.Categories", "Lecture_Id");
            DropColumn("dbo.Categories", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "User_Id", c => c.Int());
            AddColumn("dbo.Categories", "Lecture_Id", c => c.Int());
            DropForeignKey("dbo.UserCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.UserCategories", "User_Id", "dbo.Users");
            DropForeignKey("dbo.LectureCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.LectureCategories", "Lecture_Id", "dbo.Lectures");
            DropIndex("dbo.UserCategories", new[] { "Category_Id" });
            DropIndex("dbo.UserCategories", new[] { "User_Id" });
            DropIndex("dbo.LectureCategories", new[] { "Category_Id" });
            DropIndex("dbo.LectureCategories", new[] { "Lecture_Id" });
            DropTable("dbo.UserCategories");
            DropTable("dbo.LectureCategories");
            CreateIndex("dbo.Categories", "User_Id");
            CreateIndex("dbo.Categories", "Lecture_Id");
            AddForeignKey("dbo.Categories", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Categories", "Lecture_Id", "dbo.Lectures", "Id");
        }
    }
}
