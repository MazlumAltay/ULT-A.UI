using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ULTİA.DTO.DTO
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }

        public string KullaniciAdi { get; set; }

        public int EkipID { get; set; }

        public override string ToString()
        {
            return KullaniciAdi;
        }
    }
}
