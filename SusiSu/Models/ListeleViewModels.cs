using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static SusiSu.Enums.Enums;

namespace SusiSu.Models
{
    public class ListeleViewModels
    {
        public Boyut Boy { get; set; }
        public Tur Tur { get; set; }
        public int ToplamStok { get; set; }
        public virtual List<Su> Sus { get; set; }
    }
}