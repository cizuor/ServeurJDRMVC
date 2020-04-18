namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatCibleStatUtil4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.StatUtils", name: "Stat_Id", newName: "StatUtile_Id");
            RenameIndex(table: "dbo.StatUtils", name: "IX_Stat_Id", newName: "IX_StatUtile_Id");
            AddColumn("dbo.StatUtils", "Valeur", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StatUtils", "Valeur");
            RenameIndex(table: "dbo.StatUtils", name: "IX_StatUtile_Id", newName: "IX_Stat_Id");
            RenameColumn(table: "dbo.StatUtils", name: "StatUtile_Id", newName: "Stat_Id");
        }
    }
}
