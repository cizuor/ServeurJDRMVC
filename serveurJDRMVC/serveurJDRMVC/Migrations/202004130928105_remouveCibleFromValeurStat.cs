namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remouveCibleFromValeurStat : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ValeurClasseStats", new[] { "CLasse_Id" });
            CreateIndex("dbo.ValeurClasseStats", "Classe_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ValeurClasseStats", new[] { "Classe_Id" });
            CreateIndex("dbo.ValeurClasseStats", "CLasse_Id");
        }
    }
}
