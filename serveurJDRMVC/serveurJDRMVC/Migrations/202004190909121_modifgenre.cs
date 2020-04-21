namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifgenre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
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
                "dbo.ValeurGenreStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valeur = c.Int(nullable: false),
                        Stat_Id = c.Int(),
                        Genre_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stats", t => t.Stat_Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .Index(t => t.Stat_Id)
                .Index(t => t.Genre_Id);
            
            AddColumn("dbo.Effets", "Genre_Id", c => c.Int());
            AddColumn("dbo.Effets", "Genre_Id1", c => c.Int());
            AddColumn("dbo.Effets", "Genre_Id2", c => c.Int());
            AddColumn("dbo.Effets", "Genre_Id3", c => c.Int());
            CreateIndex("dbo.Effets", "Genre_Id");
            CreateIndex("dbo.Effets", "Genre_Id1");
            CreateIndex("dbo.Effets", "Genre_Id2");
            CreateIndex("dbo.Effets", "Genre_Id3");
            AddForeignKey("dbo.Effets", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Effets", "Genre_Id1", "dbo.Genres", "Id");
            AddForeignKey("dbo.Effets", "Genre_Id2", "dbo.Genres", "Id");
            AddForeignKey("dbo.Effets", "Genre_Id3", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ValeurGenreStats", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.ValeurGenreStats", "Stat_Id", "dbo.Stats");
            DropForeignKey("dbo.Effets", "Genre_Id3", "dbo.Genres");
            DropForeignKey("dbo.Effets", "Genre_Id2", "dbo.Genres");
            DropForeignKey("dbo.Effets", "Genre_Id1", "dbo.Genres");
            DropForeignKey("dbo.Effets", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.ValeurGenreStats", new[] { "Genre_Id" });
            DropIndex("dbo.ValeurGenreStats", new[] { "Stat_Id" });
            DropIndex("dbo.Effets", new[] { "Genre_Id3" });
            DropIndex("dbo.Effets", new[] { "Genre_Id2" });
            DropIndex("dbo.Effets", new[] { "Genre_Id1" });
            DropIndex("dbo.Effets", new[] { "Genre_Id" });
            DropColumn("dbo.Effets", "Genre_Id3");
            DropColumn("dbo.Effets", "Genre_Id2");
            DropColumn("dbo.Effets", "Genre_Id1");
            DropColumn("dbo.Effets", "Genre_Id");
            DropTable("dbo.ValeurGenreStats");
            DropTable("dbo.Genres");
        }
    }
}
