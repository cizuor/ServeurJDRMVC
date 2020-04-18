namespace serveurJDRMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatCalculer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StatUtils", "StatCible_Id", "dbo.Stats");
            DropForeignKey("dbo.StatUtils", "Stat_Id", "dbo.Stats");
            DropIndex("dbo.StatUtils", new[] { "StatCible_Id" });
            CreateTable(
                "dbo.StatCalculers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Stats", "StatCalculer_Id", c => c.Int());
            AddColumn("dbo.StatUtils", "StatCalculer_Id", c => c.Int());
            CreateIndex("dbo.Stats", "StatCalculer_Id");
            CreateIndex("dbo.StatUtils", "StatCalculer_Id");
            AddForeignKey("dbo.StatUtils", "StatCalculer_Id", "dbo.StatCalculers", "Id");
            AddForeignKey("dbo.Stats", "StatCalculer_Id", "dbo.StatCalculers", "Id");
            DropColumn("dbo.StatUtils", "StatCible_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StatUtils", "Stat_Id", c => c.Int());
            AddColumn("dbo.StatUtils", "StatCible_Id", c => c.Int());
            DropForeignKey("dbo.Stats", "StatCalculer_Id", "dbo.StatCalculers");
            DropForeignKey("dbo.StatUtils", "StatCalculer_Id", "dbo.StatCalculers");
            DropIndex("dbo.StatUtils", new[] { "StatCalculer_Id" });
            DropIndex("dbo.Stats", new[] { "StatCalculer_Id" });
            DropColumn("dbo.StatUtils", "StatCalculer_Id");
            DropColumn("dbo.Stats", "StatCalculer_Id");
            DropTable("dbo.StatCalculers");
            CreateIndex("dbo.StatUtils", "Stat_Id");
            CreateIndex("dbo.StatUtils", "StatCible_Id");
            AddForeignKey("dbo.StatUtils", "Stat_Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.StatUtils", "StatCible_Id", "dbo.Stats", "Id");
        }
    }
}
