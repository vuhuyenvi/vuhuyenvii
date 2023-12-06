namespace _2001216311_VuThiHuyenVi_DoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SanPhamms",
                c => new
                    {
                        IdSP = c.Int(nullable: false, identity: true),
                        NameSP = c.String(),
                        Loai = c.String(),
                        HinhAnh = c.String(),
                        GiaCu = c.Double(),
                        GiaMoi = c.Double(),
                        IdTH = c.Int(),
                    })
                .PrimaryKey(t => t.IdSP)
                .ForeignKey("dbo.ThuongHieuus", t => t.IdTH)
                .Index(t => t.IdTH);
            
            CreateTable(
                "dbo.ThuongHieuus",
                c => new
                    {
                        IdTH = c.Int(nullable: false, identity: true),
                        NameTH = c.String(),
                    })
                .PrimaryKey(t => t.IdTH);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhamms", "IdTH", "dbo.ThuongHieuus");
            DropIndex("dbo.SanPhamms", new[] { "IdTH" });
            DropTable("dbo.ThuongHieuus");
            DropTable("dbo.SanPhamms");
        }
    }
}
