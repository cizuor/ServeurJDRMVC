namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatCibleStatUtil : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StatUtils", "Stat_Id", "dbo.Stats");
            DropIndex("dbo.StatUtils", new[] { "Stat_Id" });
            AddColumn("dbo.StatUtils", "StatCible_Id", c => c.Int(nullable: false));
            AddColumn("dbo.StatUtils", "StatUtile_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.StatUtils", "Stat_Id", c => c.Int());
            CreateIndex("dbo.StatUtils", "StatCible_Id");
            CreateIndex("dbo.StatUtils", "StatUtile_Id");
            CreateIndex("dbo.StatUtils", "Stat_Id");
            AddForeignKey("dbo.StatUtils", "StatCible_Id", "dbo.Stats", "Id", cascadeDelete: false);
            AddForeignKey("dbo.StatUtils", "StatUtile_Id", "dbo.Stats", "Id", cascadeDelete: false);
            AddForeignKey("dbo.StatUtils", "Stat_Id", "dbo.Stats", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StatUtils", "Stat_Id", "dbo.Stats");
            DropForeignKey("dbo.StatUtils", "StatUtile_Id", "dbo.Stats");
            DropForeignKey("dbo.StatUtils", "StatCible_Id", "dbo.Stats");
            DropIndex("dbo.StatUtils", new[] { "Stat_Id" });
            DropIndex("dbo.StatUtils", new[] { "StatUtile_Id" });
            DropIndex("dbo.StatUtils", new[] { "StatCible_Id" });
            AlterColumn("dbo.StatUtils", "Stat_Id", c => c.Int(nullable: false));
            DropColumn("dbo.StatUtils", "StatUtile_Id");
            DropColumn("dbo.StatUtils", "StatCible_Id");
            CreateIndex("dbo.StatUtils", "Stat_Id");
            AddForeignKey("dbo.StatUtils", "Stat_Id", "dbo.Stats", "Id", cascadeDelete: true);
        }
    }
}
