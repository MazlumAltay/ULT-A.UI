using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ULTİA.DTO.DTO
{
    public class Urun
    {
        public int UrunID { get; set; }

        public Marka MarkaID { get; set; }

        public Model ModelID { get; set; }

        public Depo DepoID { get; set; }

        public UrunGrubu UrunGrubuID { get; set; }

        public UrunTipi UrunTipiID { get; set; }

        public bool UrunGarantiliMi { get; set; }

        public string Aciklama { get; set; }

        public DateTime UrununGirisTarihi { get; set; }

        public bool UrunEmekliMi { get; set; }

        public DateTime UrunEmeklilikTarihi { get; set; }

        public float UrununGuncelFiyatBilgisi { get; set; }

        public float UrununMaliyetBilgisi { get; set; }

        public bool BarkotluMu { get; set; }

        public Kullanici KullaniciID { get; set; }

        public ParaBirimi FiyatParaBirimiID { get; set; }

        public Birim UrunMaliyetBilgisiBirimID { get; set; }

        public Guid BarkotAdi { get; set; }
    }
}
