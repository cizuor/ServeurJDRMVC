namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatCibleStatUtil3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StatUtils", "StatCible_Id", "dbo.Stats");
            DropForeignKey("dbo.StatUtils", "StatUtile_Id", "dbo.Stats");
            DropIndex("dbo.StatUtils", new[] { "StatCible_Id" });
            DropIndex("dbo.StatUtils", new[] { "StatUtile_Id" });
            DropColumn("dbo.StatUtils", "Valeur");
            DropColumn("dbo.StatUtils", "StatCible_Id");
            DropColumn("dbo.StatUtils", "StatUtile_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StatUtils", "StatUtile_Id", c => c.Int());
            AddColumn("dbo.StatUtils", "StatCible_Id", c => c.Int());
            AddColumn("dbo.StatUtils", "Valeur", c => c.Int(nullable: false));
            CreateIndex("dbo.StatUtils", "StatUtile_Id");
            CreateIndex("dbo.StatUtils", "StatCible_Id");
            AddForeignKey("dbo.StatUtils", "StatUtile_Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.StatUtils", "StatCible_Id", "dbo.Stats", "Id");
        }
    }
}
