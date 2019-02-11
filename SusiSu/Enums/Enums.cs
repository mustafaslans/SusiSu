using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SusiSu.Enums
{
    public class Enums
    {
        public enum Tur
        {
            Cam,
            Plastik
        }
        public enum Boyut
        {
            //[Display(Name = "1 Litre")]
            [Description("1 lt")]
            Küçük,
            //[Display(Name = "5 Litre")]
            [Description("5 lt")]
            Orta,
            //[Display(Name = "10 Litre")]
            [Description("10 lt")]
            Büyük,
            //[Display(Name = "20 Litre")]
            [Description("20 lt")]
            Damacana
        }
    }
}