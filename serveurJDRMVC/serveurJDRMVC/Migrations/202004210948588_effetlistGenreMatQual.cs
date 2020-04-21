namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class effetlistGenreMatQual : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Effets", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Effets", "Genre_Id1", "dbo.Genres");
            DropForeignKey("dbo.Effets", "Genre_Id2", "dbo.Genres");
            DropForeignKey("dbo.Effets", "Genre_Id3", "dbo.Genres");
            DropIndex("dbo.Effets", new[] { "Genre_Id" });
            DropIndex("dbo.Effets", new[] { "Genre_Id1" });
            DropIndex("dbo.Effets", new[] { "Genre_Id2" });
            DropIndex("dbo.Effets", new[] { "Genre_Id3" });
            CreateTable(
                "dbo.EffetActivables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Activation = c.Int(nullable: false),
                        Effet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Effets", t => t.Effet_Id)
                .Index(t => t.Effet_Id);
            
            CreateTable(
                "dbo.Materiels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeMat = c.Int(nullable: false),
                        Prix = c.Int(nullable: false),
                        Poid = c.Int(nullable: false),
                        Nom = c.String(),
                        Definition = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ValeurMaterielStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valeur = c.Int(nullable: false),
                        Stat_Id = c.Int(),
                        Materiel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stats", t => t.Stat_Id)
                .ForeignKey("dbo.Materiels", t => t.Materiel_Id)
                .Index(t => t.Stat_Id)
                .Index(t => t.Materiel_Id);
            
            CreateTable(
                "dbo.Qualites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeMat = c.Int(nullable: false),
                        Prix = c.Int(nullable: false),
                        Poid = c.Int(nullable: false),
                        Nom = c.String(),
                        Definition = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ValeurQualiteStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valeur = c.Int(nullable: false),
                        Stat_Id = c.Int(),
                        Qualite_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stats", t => t.Stat_Id)
                .ForeignKey("dbo.Qualites", t => t.Qualite_Id)
                .Index(t => t.Stat_Id)
                .Index(t => t.Qualite_Id);
            
            CreateTable(
                "dbo.GenreEffetActivables",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        EffetActivable_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.EffetActivable_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.EffetActivables", t => t.EffetActivable_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.EffetActivable_Id);
            
            CreateTable(
                "dbo.MaterielEffetActivables",
                c => new
                    {
                        Materiel_Id = c.Int(nullable: false),
                        EffetActivable_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Materiel_Id, t.EffetActivable_Id })
                .ForeignKey("dbo.Materiels", t => t.Materiel_Id, cascadeDelete: true)
                .ForeignKey("dbo.EffetActivables", t => t.EffetActivable_Id, cascadeDelete: true)
                .Index(t => t.Materiel_Id)
                .Index(t => t.EffetActivable_Id);
            
            CreateTable(
                "dbo.QualiteEffetActivables",
                c => new
                    {
                        Qualite_Id = c.Int(nullable: false),
                        EffetActivable_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Qualite_Id, t.EffetActivable_Id })
                .ForeignKey("dbo.Qualites", t => t.Qualite_Id, cascadeDelete: true)
                .ForeignKey("dbo.EffetActivables", t => t.EffetActivable_Id, cascadeDelete: true)
                .Index(t => t.Qualite_Id)
                .Index(t => t.EffetActivable_Id);
            
            DropColumn("dbo.Effets", "Genre_Id");
            DropColumn("dbo.Effets", "Genre_Id1");
            DropColumn("dbo.Effets", "Genre_Id2");
            DropColumn("dbo.Effets", "Genre_Id3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Effets", "Genre_Id3", c => c.Int());
            AddColumn("dbo.Effets", "Genre_Id2", c => c.Int());
            AddColumn("dbo.Effets", "Genre_Id1", c => c.Int());
            AddColumn("dbo.Effets", "Genre_Id", c => c.Int());
            DropForeignKey("dbo.ValeurQualiteStats", "Qualite_Id", "dbo.Qualites");
            DropForeignKey("dbo.ValeurQualiteStats", "Stat_Id", "dbo.Stats");
            DropForeignKey("dbo.QualiteEffetActivables", "EffetActivable_Id", "dbo.EffetActivables");
            DropForeignKey("dbo.QualiteEffetActivables", "Qualite_Id", "dbo.Qualites");
            DropForeignKey("dbo.ValeurMaterielStats", "Materiel_Id", "dbo.Materiels");
            DropForeignKey("dbo.ValeurMaterielStats", "Stat_Id", "dbo.Stats");
            DropForeignKey("dbo.MaterielEffetActivables", "EffetActivable_Id", "dbo.EffetActivables");
            DropForeignKey("dbo.MaterielEffetActivables", "Materiel_Id", "dbo.Materiels");
            DropForeignKey("dbo.GenreEffetActivables", "EffetActivable_Id", "dbo.EffetActivables");
            DropForeignKey("dbo.GenreEffetActivables", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.EffetActivables", "Effet_Id", "dbo.Effets");
            DropIndex("dbo.QualiteEffetActivables", new[] { "EffetActivable_Id" });
            DropIndex("dbo.QualiteEffetActivables", new[] { "Qualite_Id" });
            DropIndex("dbo.MaterielEffetActivables", new[] { "EffetActivable_Id" });
            DropIndex("dbo.MaterielEffetActivables", new[] { "Materiel_Id" });
            DropIndex("dbo.GenreEffetActivables", new[] { "EffetActivable_Id" });
            DropIndex("dbo.GenreEffetActivables", new[] { "Genre_Id" });
            DropIndex("dbo.ValeurQualiteStats", new[] { "Qualite_Id" });
            DropIndex("dbo.ValeurQualiteStats", new[] { "Stat_Id" });
            DropIndex("dbo.ValeurMaterielStats", new[] { "Materiel_Id" });
            DropIndex("dbo.ValeurMaterielStats", new[] { "Stat_Id" });
            DropIndex("dbo.EffetActivables", new[] { "Effet_Id" });
            DropTable("dbo.QualiteEffetActivables");
            DropTable("dbo.MaterielEffetActivables");
            DropTable("dbo.GenreEffetActivables");
            DropTable("dbo.ValeurQualiteStats");
            DropTable("dbo.Qualites");
            DropTable("dbo.ValeurMaterielStats");
            DropTable("dbo.Materiels");
            DropTable("dbo.EffetActivables");
            CreateIndex("dbo.Effets", "Genre_Id3");
            CreateIndex("dbo.Effets", "Genre_Id2");
            CreateIndex("dbo.Effets", "Genre_Id1");
            CreateIndex("dbo.Effets", "Genre_Id");
            AddForeignKey("dbo.Effets", "Genre_Id3", "dbo.Genres", "Id");
            AddForeignKey("dbo.Effets", "Genre_Id2", "dbo.Genres", "Id");
            AddForeignKey("dbo.Effets", "Genre_Id1", "dbo.Genres", "Id");
            AddForeignKey("dbo.Effets", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
