namespace FootballApi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameWeek = c.Int(nullable: false),
                        HomeTeamName = c.String(nullable: false, maxLength: 128),
                        AwayTeamName = c.String(nullable: false, maxLength: 128),
                        HomeGoals = c.Int(nullable: false),
                        AwayGoals = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.AwayTeamName)
                .ForeignKey("dbo.Teams", t => t.HomeTeamName)
                .Index(t => new { t.GameWeek, t.HomeTeamName, t.AwayTeamName }, unique: true, name: "IX_GameResultUnique");
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Score = c.Int(nullable: false),
                        GamesPlayed = c.Int(nullable: false),
                        GoalsScored = c.Int(nullable: false),
                        GoalsLost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameResults", "HomeTeamName", "dbo.Teams");
            DropForeignKey("dbo.GameResults", "AwayTeamName", "dbo.Teams");
            DropIndex("dbo.GameResults", "IX_GameResultUnique");
            DropTable("dbo.Teams");
            DropTable("dbo.GameResults");
        }
    }
}
