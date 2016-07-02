namespace FootballApi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWonLostDrawnToTeam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "GamesWon", c => c.Int(nullable: false));
            AddColumn("dbo.Teams", "GamesLost", c => c.Int(nullable: false));
            AddColumn("dbo.Teams", "GamesDrawn", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "GamesDrawn");
            DropColumn("dbo.Teams", "GamesLost");
            DropColumn("dbo.Teams", "GamesWon");
        }
    }
}
