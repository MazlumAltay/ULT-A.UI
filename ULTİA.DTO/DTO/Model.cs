using System.Security.AccessControl;

namespace ULTİA.DTO.DTO
{
    public class Model
    {
        public int ModelID { get; set; }

        public string ModelAdi { get; set; }

        public Marka MarkaID { get; set; }

        public override string ToString()
        {
            return ModelAdi;
        }
    }
}