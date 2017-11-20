namespace BuzzFeedAndy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Answers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AnswerText = c.String(),
                        QuestionID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.QuestionID_ID)
                .Index(t => t.QuestionID_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuestionID_ID", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "QuestionID_ID" });
            DropTable("dbo.Answers");
        }
    }
}
