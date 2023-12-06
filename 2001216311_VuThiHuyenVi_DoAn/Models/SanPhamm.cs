using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _2001216311_VuThiHuyenVi_DoAn.Models
{
    public class SanPhamm
    {
        [Key]
        public int IdSP { get; set; }
        public string NameSP { get; set; }
        public string Loai { get; set; }
        public string HinhAnh { get; set; }
        public Nullable<double> GiaCu { get; set; }
        public Nullable<double> GiaMoi { get; set; }
        public Nullable<int> IdTH { get; set; }

        public virtual ThuongHieuu ThuongHieu { get; set; }
    }
}