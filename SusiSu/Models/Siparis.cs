using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SusiSu.Models
{
    public class Siparis
    {
        public int SiparisId { get; set; }
        public DateTime? SiparisTarihi { get; set; } = DateTime.Now;
        public virtual IEnumerable<SiparisDetay> SiparisDetays { get; set; }
        public virtual User Users { get; set; }
      
    }
}