using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ULTİA.DTO.DTO
{
    public class Sirket
    {
        public int SirketID { get; set; }

        public string SirketAdi { get; set; }

        public Depo DepoID { get; set; }
    }
}
