using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ULTİA.DAL;
using ULTİA.DTO.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ListView = System.Windows.Forms.ListView;

namespace ULTİA
{
    public partial class Listeleme : Form
    {
        
        private Kullanici kullanici;
        public Listeleme()
        {
            InitializeComponent();
        }
        
        public Listeleme(Kullanici kullanici): this()
        {
            this.kullanici = kullanici;
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-E6M2A1F\SQLEXPRESS;Initial Catalog=Ultia;Integrated Security=True");

        //public object KullaniciID { get; private set; }

        private void Listeleme_Load(object sender, EventArgs e)
        {
            lblIsim.Text = kullanici.ToString();
            UrunListele();
        }

        private void UrunListele()
        {
            baglanti.Open();

            // Veritabanından verileri çekeceğimiz SQL sorgusunu hazırlıyoruz

            string sql = $@"SELECT Urun.BarkotAdi, UrunTipi.UrunTipiAdi, Urun.UrunGuncelFiyatBilgisi, Marka.MarkaAdi, Model.ModelAdi, Urun.KullaniciID
                    FROM Urun
                    INNER JOIN UrunTipi ON Urun.UrunTipiID = UrunTipi.UrunTipiID
                    INNER JOIN Marka ON Urun.MarkaID = Marka.MarkaID
                    INNER JOIN Model ON Urun.ModelID = Model.ModelID
                    WHERE Urun.KullaniciID = '{kullanici.KullaniciID}'";

            // SqlCommand nesnesi oluşturarak SQL sorgusunu çalıştırıyoruz
            using (SqlCommand command = new SqlCommand(sql, baglanti))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // ListView'a verileri ekliyoruz.
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["BarkotAdi"].ToString());
                        item.SubItems.Add(reader["UrunTipiAdi"].ToString());
                        item.SubItems.Add(reader["UrunGuncelFiyatBilgisi"].ToString());
                        item.SubItems.Add(reader["MarkaAdi"].ToString());
                        item.SubItems.Add(reader["ModelAdi"].ToString());
                        listView1.Items.Add(item);
                    }
                }
            }
            baglanti.Close();
            //inner join Zimmet on Urun.UrunID = Zimmet.ZimmetID
        }

        private void EkipListe()
        {
            baglanti.Open();

            string sql = $@"SELECT * FROM Urun
                    INNER JOIN UrunTipi ON Urun.UrunTipiID = UrunTipi.UrunTipiID
                    INNER JOIN Marka ON Urun.MarkaID = Marka.MarkaID
                    INNER JOIN Model ON Urun.ModelID = Model.ModelID
					inner join Zimmet on Urun.UrunID = Zimmet.ZimmetID
					inner join Kullanici on Zimmet.KullaniciID = Kullanici.KullaniciID
					inner join Ekip on Kullanici.EkipID = Ekip.EkipID
					where Ekip.EkipID = '{kullanici.EkipID}'";

            //using: SqlConnection nesnesinin kullanımını sağlar. Ve İşlem bittiğinde kapatılıp temizlenmesi işlevi.
            using (SqlCommand command = new SqlCommand(sql, baglanti))
            {

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Listbox'a verileri ekliyoruz.
                    while (reader.Read())
                    {

                        ListViewItem item = new ListViewItem(reader["BarkotAdi"].ToString());
                        item.SubItems.Add(reader["UrunTipiAdi"].ToString());
                        item.SubItems.Add(reader["UrunGuncelFiyatBilgisi"].ToString());
                        item.SubItems.Add(reader["MarkaAdi"].ToString());
                        item.SubItems.Add(reader["ModelAdi"].ToString());
                        listView1.Items.Add(item);

                    }
                }
            }
            baglanti.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0 )
            {
                UrunListele();
            }
            else
            {
                listView1.Items.Clear();
                UrunListele();
            }
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            YeniKayit yeniKayit = new YeniKayit(kullanici);
            yeniKayit.Show();
            //this.Hide();
        }

        private void BtnVarlik_Click(object sender, EventArgs e)
        {
            EkipListe();
        }

        private void btnRaporListele_Click(object sender, EventArgs e)
        {
            RaporListesi raporListesi = new RaporListesi();
            raporListesi.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.ShowDialog();

        }
    }
}
