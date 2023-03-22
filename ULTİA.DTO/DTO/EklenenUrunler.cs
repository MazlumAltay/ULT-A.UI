using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ULTİA.DTO.DTO
{
    public class EklenenUrunler
    {
        public int EklenenUrunlerID { get; set; }

        public Urun UrunID { get; set; }

        public Kullanici KullaniciID { get; set; }
    }
}
