namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemEffet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ValeurBuffStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valeur = c.Int(nullable: false),
                        Stat_Id = c.Int(),
                        Perso_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stats", t => t.Stat_Id)
                .ForeignKey("dbo.Persoes", t => t.Perso_Id)
                .Index(t => t.Stat_Id)
                .Index(t => t.Perso_Id);
            
            CreateTable(
                "dbo.EffetAppliquers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdEffet = c.Int(nullable: false),
                        Penetration = c.Int(nullable: false),
                        MinHit = c.Int(nullable: false),
                        MaxHit = c.Int(nullable: false),
                        CoefStatReduc = c.Int(nullable: false),
                        ValeurBase = c.Int(nullable: false),
                        Drain = c.Int(nullable: false),
                        TailleDee = c.Int(nullable: false),
                        NbDee = c.Int(nullable: false),
                        Bonus = c.Int(nullable: false),
                        Reduction = c.Int(nullable: false),
                        TourRestant = c.Int(nullable: false),
                        EffetBonus = c.Boolean(nullable: false),
                        Actif = c.Boolean(nullable: false),
                        BuffDrain = c.Int(nullable: false),
                        BuffTotal = c.Int(nullable: false),
                        Lanceur_Id = c.Int(),
                        StatAffecter_Id = c.Int(),
                        StatReduc_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persoes", t => t.Lanceur_Id)
                .ForeignKey("dbo.Stats", t => t.StatAffecter_Id)
                .ForeignKey("dbo.Stats", t => t.StatReduc_Id)
                .Index(t => t.Lanceur_Id)
                .Index(t => t.StatAffecter_Id)
                .Index(t => t.StatReduc_Id);
            
            CreateTable(
                "dbo.Effets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChanceEffetBonus = c.Int(nullable: false),
                        TempsAvantEffetBonus = c.Int(nullable: false),
                        Penetration = c.Int(nullable: false),
                        MinHit = c.Int(nullable: false),
                        MaxHit = c.Int(nullable: false),
                        DureMin = c.Int(nullable: false),
                        DureMax = c.Int(nullable: false),
                        CoefStatUtil = c.Int(nullable: false),
                        CoefStatReduc = c.Int(nullable: false),
                        Cible = c.Int(nullable: false),
                        CumulMax = c.Int(nullable: false),
                        ChanceResist = c.Int(nullable: false),
                        ValeurBase = c.Int(nullable: false),
                        Drain = c.Int(nullable: false),
                        TailleDee = c.Int(nullable: false),
                        NbDee = c.Int(nullable: false),
                        Effet_Id = c.Int(),
                        StatAffecter_Id = c.Int(),
                        StatReduc_Id = c.Int(),
                        StatResist_Id = c.Int(),
                        StatUtil_Id = c.Int(),
                        EffetAppliquer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Effets", t => t.Effet_Id)
                .ForeignKey("dbo.Stats", t => t.StatAffecter_Id)
                .ForeignKey("dbo.Stats", t => t.StatReduc_Id)
                .ForeignKey("dbo.Stats", t => t.StatResist_Id)
                .ForeignKey("dbo.Stats", t => t.StatUtil_Id)
                .ForeignKey("dbo.EffetAppliquers", t => t.EffetAppliquer_Id)
                .Index(t => t.Effet_Id)
                .Index(t => t.StatAffecter_Id)
                .Index(t => t.StatReduc_Id)
                .Index(t => t.StatResist_Id)
                .Index(t => t.StatUtil_Id)
                .Index(t => t.EffetAppliquer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EffetAppliquers", "StatReduc_Id", "dbo.Stats");
            DropForeignKey("dbo.EffetAppliquers", "StatAffecter_Id", "dbo.Stats");
            DropForeignKey("dbo.Effets", "EffetAppliquer_Id", "dbo.EffetAppliquers");
            DropForeignKey("dbo.Effets", "StatUtil_Id", "dbo.Stats");
            DropForeignKey("dbo.Effets", "StatResist_Id", "dbo.Stats");
            DropForeignKey("dbo.Effets", "StatReduc_Id", "dbo.Stats");
            DropForeignKey("dbo.Effets", "StatAffecter_Id", "dbo.Stats");
            DropForeignKey("dbo.Effets", "Effet_Id", "dbo.Effets");
            DropForeignKey("dbo.EffetAppliquers", "Lanceur_Id", "dbo.Persoes");
            DropForeignKey("dbo.ValeurBuffStats", "Perso_Id", "dbo.Persoes");
            DropForeignKey("dbo.ValeurBuffStats", "Stat_Id", "dbo.Stats");
            DropIndex("dbo.Effets", new[] { "EffetAppliquer_Id" });
            DropIndex("dbo.Effets", new[] { "StatUtil_Id" });
            DropIndex("dbo.Effets", new[] { "StatResist_Id" });
            DropIndex("dbo.Effets", new[] { "StatReduc_Id" });
            DropIndex("dbo.Effets", new[] { "StatAffecter_Id" });
            DropIndex("dbo.Effets", new[] { "Effet_Id" });
            DropIndex("dbo.EffetAppliquers", new[] { "StatReduc_Id" });
            DropIndex("dbo.EffetAppliquers", new[] { "StatAffecter_Id" });
            DropIndex("dbo.EffetAppliquers", new[] { "Lanceur_Id" });
            DropIndex("dbo.ValeurBuffStats", new[] { "Perso_Id" });
            DropIndex("dbo.ValeurBuffStats", new[] { "Stat_Id" });
            DropTable("dbo.Effets");
            DropTable("dbo.EffetAppliquers");
            DropTable("dbo.ValeurBuffStats");
        }
    }
}
