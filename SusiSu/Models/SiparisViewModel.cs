using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SusiSu.Models
{
    public class SiparisViewModel
    {
        public int Adet { get; set; }
        public int Fiyat { get; set; }
        public User User { get; set; }
        public List<Su> Su { get; set; }
        public Siparis Siparis { get; set; }

    }
}