namespace bsa15_lec6_orm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnswerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Correct = c.Boolean(nullable: false),
                        Text = c.String(),
                        Question_Id = c.Int(),
                        TestWork_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .ForeignKey("dbo.TestWorks", t => t.TestWork_Id)
                .Index(t => t.Question_Id)
                .Index(t => t.TestWork_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "TestWork_Id", "dbo.TestWorks");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "TestWork_Id" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropTable("dbo.Answers");
        }
    }
}
