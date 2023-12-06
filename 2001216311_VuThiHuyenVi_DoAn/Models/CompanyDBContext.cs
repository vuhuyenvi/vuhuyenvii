using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace _2001216311_VuThiHuyenVi_DoAn.Models
{
    public class CompanyDBContext:DbContext
    {
        public CompanyDBContext() : base("MyConnectionString") { }
        public DbSet<ThuongHieuu> ThuongHieuu { get; set; }
        public DbSet<SanPhamm> SanPhamm { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Cart> Cart { get; set; }
    }
}