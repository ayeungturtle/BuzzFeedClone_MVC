namespace BuzzFeedAndy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuizTitle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuizTitles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QuizTitles");
        }
    }
}
