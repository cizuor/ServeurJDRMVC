namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatCibleStatUtil5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StatUtils", "StatUtile_Id", "dbo.Stats");
            AddColumn("dbo.StatUtils", "StatCible_Id", c => c.Int());
            CreateIndex("dbo.StatUtils", "StatCible_Id");
            AddForeignKey("dbo.StatUtils", "StatCible_Id", "dbo.Stats", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StatUtils", "Stat_Id", "dbo.Stats");
            DropForeignKey("dbo.StatUtils", "StatCible_Id", "dbo.Stats");
            DropIndex("dbo.StatUtils", new[] { "StatCible_Id" });
            DropColumn("dbo.StatUtils", "StatCible_Id");
            AddForeignKey("dbo.StatUtils", "StatUtile_Id", "dbo.Stats", "Id");
        }
    }
}
