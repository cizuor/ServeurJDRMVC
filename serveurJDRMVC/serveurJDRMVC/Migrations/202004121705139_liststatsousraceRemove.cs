namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class liststatsousraceRemove : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RaceSousRaces", newName: "SousRaceRaces");
            DropPrimaryKey("dbo.SousRaceRaces");
            AddPrimaryKey("dbo.SousRaceRaces", new[] { "SousRace_Id", "Race_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SousRaceRaces");
            AddPrimaryKey("dbo.SousRaceRaces", new[] { "Race_Id", "SousRace_Id" });
            RenameTable(name: "dbo.SousRaceRaces", newName: "RaceSousRaces");
        }
    }
}
