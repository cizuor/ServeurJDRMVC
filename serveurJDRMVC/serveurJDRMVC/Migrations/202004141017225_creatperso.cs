namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatperso : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersoViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Definition = c.String(),
                        Classe_Id = c.Int(),
                        Race_Id = c.Int(),
                        SousRace_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.Classe_Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .ForeignKey("dbo.SousRaces", t => t.SousRace_Id)
                .Index(t => t.Classe_Id)
                .Index(t => t.Race_Id)
                .Index(t => t.SousRace_Id);
            
            AddColumn("dbo.Users", "PersoEnCreation_Id", c => c.Int());
            CreateIndex("dbo.Users", "PersoEnCreation_Id");
            AddForeignKey("dbo.Users", "PersoEnCreation_Id", "dbo.PersoViewModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "PersoEnCreation_Id", "dbo.PersoViewModels");
            DropForeignKey("dbo.PersoViewModels", "SousRace_Id", "dbo.SousRaces");
            DropForeignKey("dbo.PersoViewModels", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.PersoViewModels", "Classe_Id", "dbo.Classes");
            DropIndex("dbo.PersoViewModels", new[] { "SousRace_Id" });
            DropIndex("dbo.PersoViewModels", new[] { "Race_Id" });
            DropIndex("dbo.PersoViewModels", new[] { "Classe_Id" });
            DropIndex("dbo.Users", new[] { "PersoEnCreation_Id" });
            DropColumn("dbo.Users", "PersoEnCreation_Id");
            DropTable("dbo.PersoViewModels");
        }
    }
}
