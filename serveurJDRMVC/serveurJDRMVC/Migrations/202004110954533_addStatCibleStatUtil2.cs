namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatCibleStatUtil2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StatUtils", "StatCible_Id", "dbo.Stats");
            DropForeignKey("dbo.StatUtils", "StatUtile_Id", "dbo.Stats");
            DropIndex("dbo.StatUtils", new[] { "StatCible_Id" });
            DropIndex("dbo.StatUtils", new[] { "StatUtile_Id" });
            AlterColumn("dbo.StatUtils", "StatCible_Id", c => c.Int());
            AlterColumn("dbo.StatUtils", "StatUtile_Id", c => c.Int());
            CreateIndex("dbo.StatUtils", "StatCible_Id");
            CreateIndex("dbo.StatUtils", "StatUtile_Id");
            AddForeignKey("dbo.StatUtils", "StatCible_Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.StatUtils", "StatUtile_Id", "dbo.Stats", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StatUtils", "StatUtile_Id", "dbo.Stats");
            DropForeignKey("dbo.StatUtils", "StatCible_Id", "dbo.Stats");
            DropIndex("dbo.StatUtils", new[] { "StatUtile_Id" });
            DropIndex("dbo.StatUtils", new[] { "StatCible_Id" });
            AlterColumn("dbo.StatUtils", "StatUtile_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.StatUtils", "StatCible_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.StatUtils", "StatUtile_Id");
            CreateIndex("dbo.StatUtils", "StatCible_Id");
            AddForeignKey("dbo.StatUtils", "StatUtile_Id", "dbo.Stats", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StatUtils", "StatCible_Id", "dbo.Stats", "Id", cascadeDelete: true);
        }
    }
}
