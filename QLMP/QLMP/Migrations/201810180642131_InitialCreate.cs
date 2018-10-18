namespace QLMP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CongDungs",
                c => new
                    {
                        MaCongDung = c.String(nullable: false, maxLength: 128),
                        TenCongDung = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaCongDung);
            
            CreateTable(
                "dbo.MyPhams",
                c => new
                    {
                        MaMP = c.String(nullable: false, maxLength: 128),
                        TenMP = c.String(nullable: false, maxLength: 50),
                        ThuongHieu = c.String(),
                        TenCongDung = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaMP)
                .ForeignKey("dbo.CongDungs", t => t.TenCongDung)
                .Index(t => t.TenCongDung);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyPhams", "TenCongDung", "dbo.CongDungs");
            DropIndex("dbo.MyPhams", new[] { "TenCongDung" });
            DropTable("dbo.MyPhams");
            DropTable("dbo.CongDungs");
        }
    }
}
