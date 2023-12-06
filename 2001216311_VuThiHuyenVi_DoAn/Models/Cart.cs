using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _2001216311_VuThiHuyenVi_DoAn.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int ProId { get; set; }
        public int Quantity { get; set; }
        public virtual SanPhamm SanPhamm { get; set; }
    }
}