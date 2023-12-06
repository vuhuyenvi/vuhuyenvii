namespace _2001216311_VuThiHuyenVi_DoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SanPhamm_IdSP = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SanPhamms", t => t.SanPhamm_IdSP)
                .Index(t => t.SanPhamm_IdSP);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "SanPhamm_IdSP", "dbo.SanPhamms");
            DropIndex("dbo.Carts", new[] { "SanPhamm_IdSP" });
            DropTable("dbo.Carts");
        }
    }
}
