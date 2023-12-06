using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2001216311_VuThiHuyenVi_DoAn.Models
{
    public class ThuongHieuu
    {
        [Key]
        public int IdTH { get; set; }
        public string NameTH { get; set; }
    }
}