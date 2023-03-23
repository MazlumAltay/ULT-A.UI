using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using ULTİA.DTO.DTO;

namespace ULTİA
{
    public partial class YeniKayit : Form
    {

        private Kullanici kullanici;

        public YeniKayit()
        {
            InitializeComponent();
        }

        public YeniKayit(Kullanici kullanici) : this()
        {
            this.kullanici = kullanici;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-E6M2A1F\SQLEXPRESS;Initial Catalog=Ultia;Integrated Security=True");
            // null değer girmemin sebebi işlem başlamadan önce bellek oluşturmak.
            SqlTransaction tran = null;
            int etkilenenSatirSayisi = 0;


            try
            {
                conn.Open();
                //yukarıda Null değer girişinden sonra burada işlem oluşturdum ve hata durumuna karşı önlem aldım.
                tran = conn.BeginTransaction();

                SqlCommand cmd = new SqlCommand(
                    "insert into Urun(BarkotAdi, UrunTipiID, MarkaID, ModelID, DepoID, UrunGrubuID,  UrunGarantiliMi, Aciklama, UrununGirisTarihi, UrunEmekliMi, UrunEmeklilikTarihi, UrunGuncelFiyatBilgisi, UrunMaliyetBilgisi, BarkotluMu, KullaniciID, FiyatParaBirimID, UrunMaliyetBilgisiBirimiID )values ( @barkotAdi, @uruntipiid, @markaid, @modelid, 1 , 2, 1, @aciklama, @urunGirisTarihi, 0, 01-01-2030, @urunGuncelFiyatBilgisi, @urunMaliyetBilgisi, 1, @kullaniciid, @fiyatParaBirimid, @urunMaliyetBilgisiBirimid);",
                    conn, tran);
                if (string.IsNullOrEmpty(txtBarkod.Text) || cmbUrunTipi.SelectedItem == null ||
                    cmbMarka.SelectedItem == null || cmbModel.SelectedItem == null ||
                    string.IsNullOrEmpty(rtxtAciklama.Text))
                {
                    MessageBox.Show("Lütfen tüm gerekli alanları doldurunuz.");
                    Temizle();
                }
                else
                {
                    cmd.Parameters.AddWithValue("@barkotAdi", txtBarkod.Text);
                    cmd.Parameters.AddWithValue("@uruntipiid", (cmbUrunTipi.SelectedItem as UrunTipi).UrunTipiID);
                    cmd.Parameters.AddWithValue("@markaid", (cmbMarka.SelectedItem as Marka).MarkaID);
                    cmd.Parameters.AddWithValue("@modelid", (cmbModel.SelectedItem as Model).ModelID);
                    cmd.Parameters.AddWithValue("@aciklama", rtxtAciklama.Text);
                    cmd.Parameters.AddWithValue("@urunGirisTarihi", dtpUrununGirisTarihi.Value);
                    cmd.Parameters.AddWithValue("@urunMaliyetBilgisi", txtUrununMaliyeti.Text);
                    cmd.Parameters.AddWithValue("@urunMaliyetBilgisiBirimid", (cmbUrununParaBirimi.SelectedItem as ParaBirimi).ParaBirimiID);
                    cmd.Parameters.AddWithValue("@urunGuncelFiyatBilgisi", txtUrununGuncelFiyati.Text);
                    cmd.Parameters.AddWithValue("@fiyatParaBirimid", (cmbUrununGuncelFiyatParaBirimi.SelectedItem as ParaBirimi).ParaBirimiID);
                    cmd.Parameters.AddWithValue("@kullaniciid", kullanici.KullaniciID);

                    cmd.Transaction = tran;
                    tran.Commit();
                    //Veritabanı bağlantısı sonrası etkilenen satır sayısını görürüz.
                    etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı...");
                }

            }
            catch (Exception ex)
            {
                tran.Rollback();
            }
            finally
            {
                conn.Close();

            }

        }

        private void YeniKayit_Load(object sender, EventArgs e)
        {
            Temizle();
            UrunTipiYukle();
            MarkaYukle();
            ModelYukle();
            UrunGarantiliMi();
            ÜrününParaBiriminiYükle();
            ÜrününGüncelParaBiriminiYükle();
        }

        private void Temizle()
        {
            txtBarkod.Text = "";
            cmbUrunTipi.SelectedItem = null;
            cmbMarka.SelectedItem = null;
            cmbModel.SelectedItem = null;
            rtxtAciklama.Text = "";
            txtUrununMaliyeti.Text = "";
            cmbUrununParaBirimi.SelectedItem = null;
            txtUrununGuncelFiyati.Text = "";
            cmbUrununGuncelFiyatParaBirimi.SelectedItem = null;
        }

        private void ÜrününGüncelParaBiriminiYükle()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-E6M2A1F\SQLEXPRESS;Initial Catalog=Ultia;Integrated Security=True");

            // SQL sorgusu
            string query = "select * from ParaBirim";

            // Veritabanından verileri çekme işlemi.
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            // ComboBox'a verileri ekleme işlemi.
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ParaBirimi paraBirimi = new ParaBirimi();
                    paraBirimi.ParaBirimiID = reader.GetInt32(0);
                    paraBirimi.ParaBirimiAdi = reader.GetString(1);
                    cmbUrununGuncelFiyatParaBirimi.Items.Add(paraBirimi);
                }
            }
            // Veritabanı bağlantısını kapatma işlemi.
            conn.Close();
        }

        private void ÜrününParaBiriminiYükle()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-E6M2A1F\SQLEXPRESS;Initial Catalog=Ultia;Integrated Security=True");

            // SQL sorgusu
            string query = "select * from ParaBirim";

            // Veritabanından verileri çekme işlemi.
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ParaBirimi paraBirimi = new ParaBirimi();
                    paraBirimi.ParaBirimiID = reader.GetInt32(0);
                    paraBirimi.ParaBirimiAdi = reader.GetString(1);
                    cmbUrununParaBirimi.Items.Add(paraBirimi);
                }
            }

            // Veritabanı bağlantısını kapatma işlemi.
            conn.Close();
        }

        private void UrunGarantiliMi()
        {

            cmbGarantiliMi.Items.Add(true);
            cmbGarantiliMi.Items.Add(false);
        }

        private void ModelYukle()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-E6M2A1F\SQLEXPRESS;Initial Catalog=Ultia;Integrated Security=True");
            string sql = "select * from Model";

            try
            {
                // Veritabanı bağlantısını açma işlemi.
                conn.Open();

                // SQL sorgusunu çalıştırma
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Verileri yüklemek için bir DataTable nesnesi oluşturma işlemi.
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Model model = new Model();
                        model.ModelID = reader.GetInt32(0);
                        model.ModelAdi = reader.GetString(1);
                        cmbModel.Items.Add(model);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda yapılacak işlemler
            }
            finally
            {
                // Veritabanı bağlantısını kapatma
                conn.Close();
            }
        }

        private void MarkaYukle()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-E6M2A1F\SQLEXPRESS;Initial Catalog=Ultia;Integrated Security=True");
            string sql = "select * from Marka";

            try
            {
                // Veritabanı bağlantısını açma
                conn.Open();

                // SQL sorgusunu çalıştırma
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Verileri yüklemek için bir DataTable nesnesi oluşturma
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Marka marka = new Marka();
                        marka.MarkaID = reader.GetInt32(0);
                        marka.MarkaAdi = reader.GetString(1);
                        cmbMarka.Items.Add(marka);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda yapılacak işlemler
            }
            finally
            {
                // Veritabanı bağlantısını kapatma
                conn.Close();
            }
        }

        private void UrunTipiYukle()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-E6M2A1F\SQLEXPRESS;Initial Catalog=Ultia;Integrated Security=True");
            string sql = "select * from UrunTipi";

            try
            {
                // Veritabanı bağlantısını açma
                conn.Open();

                // SQL sorgusunu çalıştırma
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UrunTipi urunTipi = new UrunTipi();
                        urunTipi.UrunTipiID = reader.GetInt32(0);
                        urunTipi.UrunTipiAdi = reader.GetString(1);
                        cmbUrunTipi.Items.Add(urunTipi);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda yapılacak işlemler
            }
            finally
            {
                // Veritabanı bağlantısını kapatma
                conn.Close();
            }
        }

        private void btnRaporListesi_Click(object sender, EventArgs e)
        {
            RaporListesi raporListesi = new RaporListesi();
            raporListesi.Show();
        }
        
        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region MarkaYükle
            //// Seçilen Marka nesnesinden MarkaID değerini alıyoruz.
            //int secilenMarkaID = ((Marka)cmbMarka.SelectedItem).MarkaID;

            //// SQL sorgusunu oluşturdum ve MarkaID'ye göre filtrele işlemi gerçekleştirdim.
            //string sql = "SELECT ModelID, ModelAdi FROM Model WHERE MarkaID = @MarkaID";
            //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-E6M2A1F\SQLEXPRESS;Initial Catalog=Ultia;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand(sql, conn);
            //cmd.Parameters.AddWithValue("@MarkaID", secilenMarkaID);

            //try
            //{
            //    // Veritabanı bağlantısını
            //    conn.Open();

            //    // SQL sorgusunu ile işlemi gerçekleştirme.
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    cmbModel.Items.Clear();
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            Model model = new Model();
            //            model.ModelID = reader.GetInt32(0);
            //            model.ModelAdi = reader.GetString(1);
            //            cmbModel.Items.Add(model);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Hata durumunda yapılacak işlemler.
            //}
            //finally
            //{
            //    // Veritabanı bağlantısını kaptma işlemi.
            //    conn.Close();
            //} 
            #endregion

            if (cmbMarka.SelectedItem != null)
            {
                // Seçilen Marka nesnesinden MarkaID değerini alıyoruz.
                int secilenMarkaID = ((Marka)cmbMarka.SelectedItem).MarkaID;

                // SQL sorgusunu oluşturdum ve MarkaID'ye göre filtrele işlemi gerçekleştirdim.
                string sql = "SELECT ModelID, ModelAdi FROM Model WHERE MarkaID = @MarkaID";
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-E6M2A1F\SQLEXPRESS;Initial Catalog=Ultia;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MarkaID", secilenMarkaID);

                try
                {
                    // Veritabanı bağlantısını
                    conn.Open();

                    // SQL sorgusunu ile işlemi gerçekleştirme.
                    SqlDataReader reader = cmd.ExecuteReader();
                    cmbModel.Items.Clear();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Model model = new Model();
                            model.ModelID = reader.GetInt32(0);
                            model.ModelAdi = reader.GetString(1);
                            cmbModel.Items.Add(model);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda yapılacak işlemler.
                }
                finally
                {
                    // Veritabanı bağlantısını kaptma işlemi.
                    conn.Close();
                }
            }
            else
            {
                // seçim yapılmadığı için bir hata mesajı gösterilebilir
                MessageBox.Show("Lütfen bir marka seçin.");
            }
        }
        
    }
}
