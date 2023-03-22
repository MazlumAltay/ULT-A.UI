using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ULTİA.DTO.DTO
{
    public class Marka
    {
        public int MarkaID { get; set; }

        public string MarkaAdi { get; set; }

        public override string ToString()
        {
            return MarkaAdi;
        }
    }
}
