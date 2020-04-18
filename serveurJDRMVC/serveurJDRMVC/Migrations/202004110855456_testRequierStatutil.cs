namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testRequierStatutil : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StatUtils", "Stat_Id", "dbo.Stats");
            DropIndex("dbo.StatUtils", new[] { "Stat_Id" });
            AlterColumn("dbo.StatUtils", "Stat_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.StatUtils", "Stat_Id");
            AddForeignKey("dbo.StatUtils", "Stat_Id", "dbo.Stats", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StatUtils", "Stat_Id", "dbo.Stats");
            DropIndex("dbo.StatUtils", new[] { "Stat_Id" });
            AlterColumn("dbo.StatUtils", "Stat_Id", c => c.Int());
            CreateIndex("dbo.StatUtils", "Stat_Id");
            AddForeignKey("dbo.StatUtils", "Stat_Id", "dbo.Stats", "Id");
        }
    }
}
