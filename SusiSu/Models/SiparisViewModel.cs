using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static SusiSu.Enums.Enums;

namespace SusiSu.Models
{
    public class SiparisViewModel
    {
        public Boyut Boyut { get; set; }
        public Tur Tur { get; set; }
        public int Adet { get; set; }
        public int Fiyat { get; set; }
        public User User { get; set; }
        public List<Su> Su { get; set; }
        public Siparis Siparis { get; set; }

    }
}