using System.Security.AccessControl;

namespace ULTİA.DTO.DTO
{
    public class ParaBirimi
    {
        public int ParaBirimiID { get; set; }

        public string ParaBirimiAdi { get; set; }

        public override string ToString()
        {
            return ParaBirimiAdi;
        }
    }
}