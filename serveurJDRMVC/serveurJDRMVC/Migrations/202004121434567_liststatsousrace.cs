namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class liststatsousrace : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SousRaceRaces", newName: "RaceSousRaces");
            DropPrimaryKey("dbo.RaceSousRaces");
            AddPrimaryKey("dbo.RaceSousRaces", new[] { "Race_Id", "SousRace_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.RaceSousRaces");
            AddPrimaryKey("dbo.RaceSousRaces", new[] { "SousRace_Id", "Race_Id" });
            RenameTable(name: "dbo.RaceSousRaces", newName: "SousRaceRaces");
        }
    }
}
