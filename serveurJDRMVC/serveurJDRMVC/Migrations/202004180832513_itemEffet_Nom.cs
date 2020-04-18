namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemEffet_Nom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Effets", "Nom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Effets", "Nom");
        }
    }
}
