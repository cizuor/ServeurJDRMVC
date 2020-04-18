namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retrapageIgnoreChange4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Persoes", "Stat_Id", "dbo.Stats");
            DropIndex("dbo.Persoes", new[] { "Stat_Id" });
            DropColumn("dbo.Persoes", "Stat_Id");

            DropForeignKey("dbo.Classes", "Stat_Id", "dbo.Stats");
            DropIndex("dbo.Classes", new[] { "Stat_Id" });
            DropColumn("dbo.Classes", "Stat_Id");

            DropForeignKey("dbo.Races", "Stat_Id", "dbo.Stats");
            DropIndex("dbo.Races", new[] { "Stat_Id" });
            DropColumn("dbo.Races", "Stat_Id");

            DropForeignKey("dbo.SousRaces", "Stat_Id", "dbo.Stats");
            DropIndex("dbo.SousRaces", new[] { "Stat_Id" });
            DropColumn("dbo.SousRaces", "Stat_Id");
        }
        
        public override void Down()
        {
        }
    }
}
