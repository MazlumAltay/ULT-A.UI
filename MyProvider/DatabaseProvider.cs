using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProvider
{
    public class DatabaseProvider
    {
        //private static readonly Lazy<DatabaseProvider> lazy =
        //    new Lazy<DatabaseProvider>(() => new DatabaseProvider());

        //public static DatabaseProvider Instance { get { return lazy.Value; } }

        //private SqlConnection connection;

        //private DatabaseProvider()
        //{
        //    connection = new SqlConnection(@"Data Source=DESKTOP-E6M2A1F\SQLEXPRESS;Initial Catalog=Ultia;Integrated Security=True");
        //}

        //public bool AuthenticateUser(string KullaniciAdi, string KullaniciPassword)
        //{
        //    bool isAuthenticated = false;

        //    try
        //    {
        //        connection.Open();

        //        SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM kullanici WHERE KullaniciAdi=@kullaniciid AND KullaniciPassword=@sifre", connection);
        //        command.Parameters.AddWithValue("@kullaniciid", KullaniciAdi);
        //        command.Parameters.AddWithValue("@sifre", KullaniciPassword);

        //        int count = (int)command.ExecuteScalar();

        //        if (count > 0)
        //        {
        //            isAuthenticated = true;
        //        }
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return isAuthenticated;
        //}
    }
}
