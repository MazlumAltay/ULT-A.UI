using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ULTİA.DTO.DTO
{
    public class Ekip
    {
        public int EkipID { get; set; }

        public string EkipAdi { get; set; }

        public Sirket SirketID { get; set; }
    }
}
