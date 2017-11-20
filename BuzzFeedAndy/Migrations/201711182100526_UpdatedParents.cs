namespace BuzzFeedAndy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedParents : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Answers", name: "QuestionID_ID", newName: "Question_ID");
            RenameColumn(table: "dbo.Questions", name: "QuizID_ID", newName: "QuizTitle_ID");
            RenameIndex(table: "dbo.Answers", name: "IX_QuestionID_ID", newName: "IX_Question_ID");
            RenameIndex(table: "dbo.Questions", name: "IX_QuizID_ID", newName: "IX_QuizTitle_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Questions", name: "IX_QuizTitle_ID", newName: "IX_QuizID_ID");
            RenameIndex(table: "dbo.Answers", name: "IX_Question_ID", newName: "IX_QuestionID_ID");
            RenameColumn(table: "dbo.Questions", name: "QuizTitle_ID", newName: "QuizID_ID");
            RenameColumn(table: "dbo.Answers", name: "Question_ID", newName: "QuestionID_ID");
        }
    }
}
