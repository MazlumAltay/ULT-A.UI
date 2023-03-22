using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ULTİA.DTO.DTO;

namespace ULTİA
{
    public partial class RaporListesi : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-E6M2A1F\SQLEXPRESS;Initial Catalog=Ultia;Integrated Security=True");
        public RaporListesi()
        {
            InitializeComponent();
        }

        private void RaporListesi_Load(object sender, EventArgs e)
        {
            UrunListele();
        }

        private void ToplamCiro()
        {
            string connectionString = (@"Data Source=DESKTOP-E6M2A1F\SQLEXPRESS;Initial Catalog=Ultia;Integrated Security=True");
            // Verileri gönderme işlemini yaptım.
            string query =
                "SELECT SUM((Urun.UrunGuncelFiyatBilgisi - Urun.UrunMaliyetBilgisi)) AS ToplamCiro FROM Urun JOIN Kullanici ON Urun.KullaniciID = Kullanici.KullaniciID JOIN Marka ON Urun.MarkaID = Marka.MarkaID JOIN Model ON Urun.ModelID = Model.ModelID";
            int toplamCiro = 0;

            //using: SqlConnection nesnesinin kullanımını sağlar. Ve İşlem bittiğinde kapatılıp temizlenmesi işlevi. Bu sayede manuel olarak nesneyi Dispose etmemize gerek kalmaz. ,using bloğundan çıkılır çıkılmaz GC(Garbage Collector)’ye devredilir ve hemen silinirler(Dispose edilirler).
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    toplamCiro = Convert.ToInt32(reader["ToplamCiro"]);
                }
                reader.Close();
            }
            lblCiro.Text = toplamCiro.ToString();
        }

        private void UrunListele()
        {
            baglanti.Open();

            // Veritabanından verileri çekeceğimiz SQL sorgusunu hazırlıyoruz

            string sql = $@"SELECT Kullanici.KullaniciAdi, Marka.MarkaAdi, Model.ModelAdi, Urun.Aciklama, Urun.UrunMaliyetBilgisi, Urun.UrunGuncelFiyatBilgisi,     Urun.BarkotAdi
                FROM Urun
                JOIN Kullanici ON Urun.KullaniciID = Kullanici.KullaniciID
                JOIN Marka ON Urun.MarkaID = Marka.MarkaID
                JOIN Model ON Urun.ModelID = Model.ModelID;";

            // SqlCommand nesnesi oluşturarak SQL sorgusunu çalıştırıyoruz
            using (SqlCommand command = new SqlCommand(sql, baglanti))
            {
                // Kullanıcının ID'si için parametre ekliyoruz

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // ListView'a verileri ekliyoruz.
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["KullaniciAdi"].ToString());
                        item.SubItems.Add(reader["MarkaAdi"].ToString());
                        item.SubItems.Add(reader["ModelAdi"].ToString());
                        item.SubItems.Add(reader["Aciklama"].ToString());
                        item.SubItems.Add(reader["UrunMaliyetBilgisi"].ToString());
                        item.SubItems.Add(reader["UrunGuncelFiyatBilgisi"].ToString());
                        item.SubItems.Add(reader["BarkotAdi"].ToString());
                        listView1.Items.Add(item);
                    }
                }
            }
            baglanti.Close();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            ToplamCiro();
        }
    }
}
