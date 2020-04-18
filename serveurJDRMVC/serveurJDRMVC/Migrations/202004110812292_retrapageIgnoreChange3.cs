namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retrapageIgnoreChange3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ValeurClasseStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valeur = c.Int(nullable: false),
                        CLasse_Id = c.Int(),
                        Stat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.CLasse_Id)
                .ForeignKey("dbo.Stats", t => t.Stat_Id)
                .Index(t => t.CLasse_Id)
                .Index(t => t.Stat_Id);
            
            CreateTable(
                "dbo.StatUtils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valeur = c.Int(nullable: false),
                        Stat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stats", t => t.Stat_Id)
                .Index(t => t.Stat_Id);
            
            CreateTable(
                "dbo.ValeurSousRaceStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valeur = c.Int(nullable: false),
                        SousRace_Id = c.Int(),
                        Stat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SousRaces", t => t.SousRace_Id)
                .ForeignKey("dbo.Stats", t => t.Stat_Id)
                .Index(t => t.SousRace_Id)
                .Index(t => t.Stat_Id);
            
            CreateTable(
                "dbo.ValeurRaceStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valeur = c.Int(nullable: false),
                        Race_Id = c.Int(),
                        Stat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .ForeignKey("dbo.Stats", t => t.Stat_Id)
                .Index(t => t.Race_Id)
                .Index(t => t.Stat_Id);
            
            CreateTable(
                "dbo.ValeurPersoStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valeur = c.Int(nullable: false),
                        Perso_Id = c.Int(),
                        Stat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persoes", t => t.Perso_Id)
                .ForeignKey("dbo.Stats", t => t.Stat_Id)
                .Index(t => t.Perso_Id)
                .Index(t => t.Stat_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ValeurPersoStats", "Stat_Id", "dbo.Stats");
            DropForeignKey("dbo.ValeurPersoStats", "Perso_Id", "dbo.Persoes");
            DropForeignKey("dbo.ValeurRaceStats", "Stat_Id", "dbo.Stats");
            DropForeignKey("dbo.ValeurRaceStats", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.ValeurSousRaceStats", "Stat_Id", "dbo.Stats");
            DropForeignKey("dbo.ValeurSousRaceStats", "SousRace_Id", "dbo.SousRaces");
            DropForeignKey("dbo.ValeurClasseStats", "Stat_Id", "dbo.Stats");
            DropForeignKey("dbo.StatUtils", "Stat_Id", "dbo.Stats");
            DropForeignKey("dbo.ValeurClasseStats", "CLasse_Id", "dbo.Classes");
            DropIndex("dbo.ValeurPersoStats", new[] { "Stat_Id" });
            DropIndex("dbo.ValeurPersoStats", new[] { "Perso_Id" });
            DropIndex("dbo.ValeurRaceStats", new[] { "Stat_Id" });
            DropIndex("dbo.ValeurRaceStats", new[] { "Race_Id" });
            DropIndex("dbo.ValeurSousRaceStats", new[] { "Stat_Id" });
            DropIndex("dbo.ValeurSousRaceStats", new[] { "SousRace_Id" });
            DropIndex("dbo.StatUtils", new[] { "Stat_Id" });
            DropIndex("dbo.ValeurClasseStats", new[] { "Stat_Id" });
            DropIndex("dbo.ValeurClasseStats", new[] { "CLasse_Id" });
            DropTable("dbo.ValeurPersoStats");
            DropTable("dbo.ValeurRaceStats");
            DropTable("dbo.ValeurSousRaceStats");
            DropTable("dbo.StatUtils");
            DropTable("dbo.ValeurClasseStats");
        }
    }
}
