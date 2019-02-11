namespace SusiSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SiparisDetays", "Su_Id", "dbo.Sus");
            DropIndex("dbo.SiparisDetays", new[] { "Su_Id" });
            RenameColumn(table: "dbo.SiparisDetays", name: "Su_Id", newName: "SuID");
            AlterColumn("dbo.SiparisDetays", "SuID", c => c.Int(nullable: false));
            CreateIndex("dbo.SiparisDetays", "SuID");
            AddForeignKey("dbo.SiparisDetays", "SuID", "dbo.Sus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SiparisDetays", "SuID", "dbo.Sus");
            DropIndex("dbo.SiparisDetays", new[] { "SuID" });
            AlterColumn("dbo.SiparisDetays", "SuID", c => c.Int());
            RenameColumn(table: "dbo.SiparisDetays", name: "SuID", newName: "Su_Id");
            CreateIndex("dbo.SiparisDetays", "Su_Id");
            AddForeignKey("dbo.SiparisDetays", "Su_Id", "dbo.Sus", "Id");
        }
    }
}
