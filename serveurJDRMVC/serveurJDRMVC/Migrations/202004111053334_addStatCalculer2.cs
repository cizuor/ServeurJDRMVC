namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatCalculer2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StatUtils", "StatUtile_Id", "dbo.Stats");
            DropIndex("dbo.StatUtils", new[] { "StatUtile_Id" });
            DropColumn("dbo.StatUtils", "StatUtile_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StatUtils", "StatUtile_Id", c => c.Int());
            CreateIndex("dbo.StatUtils", "StatUtile_Id");
            AddForeignKey("dbo.StatUtils", "StatUtile_Id", "dbo.Stats", "Id");
        }
    }
}
