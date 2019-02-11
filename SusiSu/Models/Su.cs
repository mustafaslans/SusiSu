using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static SusiSu.Enums.Enums;

namespace SusiSu.Models
{
    public class Su
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Stok Miktarı")]
        public int StokMiktarı { get; set; }

        [Required]
        public int Fiyat { get; set; }

        [DisplayName("Tür")]
        public Tur Tur { get; set; }
        public Boyut Boy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Üretim Tarihi")]
        public DateTime UretimTarihi { get; set; }

        private DateTime _SonKullanma;

        [Required]
        [DataType(DataType.Date)]
        public DateTime SonKullanmaTarihi
        {
            get { return this.UretimTarihi.AddYears(2); }
            set { _SonKullanma = value; }
        }
        public virtual IEnumerable<SiparisDetay> SiparisDetay { get; set; }

    }
}