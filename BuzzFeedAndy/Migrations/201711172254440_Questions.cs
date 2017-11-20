namespace BuzzFeedAndy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Questions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        QuizID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuizTitles", t => t.QuizID_ID)
                .Index(t => t.QuizID_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "QuizID_ID", "dbo.QuizTitles");
            DropIndex("dbo.Questions", new[] { "QuizID_ID" });
            DropTable("dbo.Questions");
        }
    }
}
