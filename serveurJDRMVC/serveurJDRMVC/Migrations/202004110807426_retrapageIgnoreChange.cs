namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retrapageIgnoreChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ValeurPersoStats",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Valeur = c.Int(nullable: false),
                    Perso_Id = c.Int(),
                    Stat_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ValeurRaceStats",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Valeur = c.Int(nullable: false),
                    Race_Id = c.Int(),
                    Stat_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ValeurSousRaceStats",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Valeur = c.Int(nullable: false),
                    SousRace_Id = c.Int(),
                    Stat_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.StatUtils",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Valeur = c.Int(nullable: false),
                    Stat_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ValeurClasseStats",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Valeur = c.Int(nullable: false),
                    CLasse_Id = c.Int(),
                    Stat_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id);

            CreateIndex("dbo.ValeurPersoStats", "Stat_Id");
            CreateIndex("dbo.ValeurPersoStats", "Perso_Id");
            CreateIndex("dbo.ValeurRaceStats", "Stat_Id");
            CreateIndex("dbo.ValeurRaceStats", "Race_Id");
            CreateIndex("dbo.ValeurSousRaceStats", "Stat_Id");
            CreateIndex("dbo.ValeurSousRaceStats", "SousRace_Id");
            CreateIndex("dbo.StatUtils", "Stat_Id");
            CreateIndex("dbo.ValeurClasseStats", "Stat_Id");
            CreateIndex("dbo.ValeurClasseStats", "CLasse_Id");
            AddForeignKey("dbo.ValeurPersoStats", "Stat_Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.ValeurPersoStats", "Perso_Id", "dbo.Persoes", "Id");
            AddForeignKey("dbo.ValeurRaceStats", "Stat_Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.ValeurRaceStats", "Race_Id", "dbo.Races", "Id");
            AddForeignKey("dbo.ValeurSousRaceStats", "Stat_Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.ValeurSousRaceStats", "SousRace_Id", "dbo.SousRaces", "Id");
            AddForeignKey("dbo.ValeurClasseStats", "Stat_Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.StatUtils", "Stat_Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.ValeurClasseStats", "CLasse_Id", "dbo.Classes", "Id");



            /*DropForeignKey("dbo.ValeurClasseStats", "CLasse_Id", "dbo.Classes");
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
            DropTable("dbo.ValeurPersoStats");*/
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ValeurPersoStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valeur = c.Int(nullable: false),
                        Perso_Id = c.Int(),
                        Stat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ValeurRaceStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valeur = c.Int(nullable: false),
                        Race_Id = c.Int(),
                        Stat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ValeurSousRaceStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valeur = c.Int(nullable: false),
                        SousRace_Id = c.Int(),
                        Stat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatUtils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valeur = c.Int(nullable: false),
                        Stat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ValeurClasseStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valeur = c.Int(nullable: false),
                        CLasse_Id = c.Int(),
                        Stat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ValeurPersoStats", "Stat_Id");
            CreateIndex("dbo.ValeurPersoStats", "Perso_Id");
            CreateIndex("dbo.ValeurRaceStats", "Stat_Id");
            CreateIndex("dbo.ValeurRaceStats", "Race_Id");
            CreateIndex("dbo.ValeurSousRaceStats", "Stat_Id");
            CreateIndex("dbo.ValeurSousRaceStats", "SousRace_Id");
            CreateIndex("dbo.StatUtils", "Stat_Id");
            CreateIndex("dbo.ValeurClasseStats", "Stat_Id");
            CreateIndex("dbo.ValeurClasseStats", "CLasse_Id");
            AddForeignKey("dbo.ValeurPersoStats", "Stat_Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.ValeurPersoStats", "Perso_Id", "dbo.Persoes", "Id");
            AddForeignKey("dbo.ValeurRaceStats", "Stat_Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.ValeurRaceStats", "Race_Id", "dbo.Races", "Id");
            AddForeignKey("dbo.ValeurSousRaceStats", "Stat_Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.ValeurSousRaceStats", "SousRace_Id", "dbo.SousRaces", "Id");
            AddForeignKey("dbo.ValeurClasseStats", "Stat_Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.StatUtils", "Stat_Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.ValeurClasseStats", "CLasse_Id", "dbo.Classes", "Id");
        }
    }
}
