namespace ULTİA.DTO.DTO
{
    public class UrunTipi
    {
        public int UrunTipiID { get; set; }

        public string UrunTipiAdi { get; set; }

        public override string ToString()
        {
            return UrunTipiAdi;
        }
    }
}