namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatCalculer3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StatUtils", "StatUtile_Id", c => c.Int());
            CreateIndex("dbo.StatUtils", "StatUtile_Id");
            AddForeignKey("dbo.StatUtils", "StatUtile_Id", "dbo.Stats", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StatUtils", "StatUtile_Id", "dbo.Stats");
            DropIndex("dbo.StatUtils", new[] { "StatUtile_Id" });
            DropColumn("dbo.StatUtils", "StatUtile_Id");
        }
    }
}
