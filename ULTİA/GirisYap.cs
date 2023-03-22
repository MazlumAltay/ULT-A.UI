using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using ULTİA.DTO.DTO;

namespace ULTİA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // kullanıcı bilgilerini saklamak üzere oluşturdum.
        Kullanici kullanici = new Kullanici(); 

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-E6M2A1F\SQLEXPRESS;Initial Catalog=Ultia;Integrated Security=True");

        private void btnGirisYap_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kullanici where KullaniciAdi='" + txtKullaniciAd.Text + "' and KullaniciPassword ='" + txtKullaniciSifre.Text + "'", baglanti);

            //SqlDataReader ile okuma işlemi ve satır sayısını kontrol etmek için tanımladım.
            SqlDataReader dr = komut.ExecuteReader();
            //dr.HasRows ile satırlar içerisinde veri olup olmadığını kontrol etmek için tanımladım.
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    kullanici.KullaniciID = dr.GetInt32(0);
                    kullanici.KullaniciAdi = dr.GetString(1);
                    kullanici.EkipID = dr.GetInt32(5);
                    //Listelemede işlemleri yap.
                    //EkipID alınacak
                }
                Listeleme frm = new Listeleme(kullanici);
                frm.Show();
                this.Hide();
                txtKullaniciAd.Clear();
                txtKullaniciSifre.Clear();
                MessageBox.Show("Giriş Başarılı...");
            }
            else
            {
                MessageBox.Show("Kullanıcı bilgileri yanlış!");
                txtKullaniciAd.Clear();
                txtKullaniciSifre.Clear();
            }
            baglanti.Close();

        }

        private void txtKullaniciSifre_TextChanged(object sender, EventArgs e)
        {
            txtKullaniciSifre.PasswordChar = '*';
        }
    }
}
