namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retrapageIgnoreChange2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Persoes", "posX", c => c.Int(nullable: false));
            AddColumn("dbo.Persoes", "posY", c => c.Int(nullable: false));

            DropForeignKey("dbo.ValeurClasseStats", "CLasse_Id", "dbo.Classes");
            DropForeignKey("dbo.StatUtils", "Stat_Id", "dbo.Stats");
            DropForeignKey("dbo.ValeurClasseStats", "Stat_Id", "dbo.Stats");
            DropForeignKey("dbo.ValeurSousRaceStats", "SousRace_Id", "dbo.SousRaces");
            DropForeignKey("dbo.ValeurSousRaceStats", "Stat_Id", "dbo.Stats");
            DropForeignKey("dbo.ValeurRaceStats", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.ValeurRaceStats", "Stat_Id", "dbo.Stats");
            DropForeignKey("dbo.ValeurPersoStats", "Perso_Id", "dbo.Persoes");
            DropForeignKey("dbo.ValeurPersoStats", "Stat_Id", "dbo.Stats");
            DropIndex("dbo.ValeurClasseStats", new[] { "CLasse_Id" });
            DropIndex("dbo.ValeurClasseStats", new[] { "Stat_Id" });
            DropIndex("dbo.StatUtils", new[] { "Stat_Id" });
            DropIndex("dbo.ValeurSousRaceStats", new[] { "SousRace_Id" });
            DropIndex("dbo.ValeurSousRaceStats", new[] { "Stat_Id" });
            DropIndex("dbo.ValeurRaceStats", new[] { "Race_Id" });
            DropIndex("dbo.ValeurRaceStats", new[] { "Stat_Id" });
            DropIndex("dbo.ValeurPersoStats", new[] { "Perso_Id" });
            DropIndex("dbo.ValeurPersoStats", new[] { "Stat_Id" });
            DropTable("dbo.ValeurClasseStats");
            DropTable("dbo.StatUtils");
            DropTable("dbo.ValeurSousRaceStats");
            DropTable("dbo.ValeurRaceStats");
            DropTable("dbo.ValeurPersoStats");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Persoes", "posY");
            DropColumn("dbo.Persoes", "posX");
        }
    }
}
