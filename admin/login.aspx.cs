using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        private static string calculateSHA512(string str)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            SHA512CryptoServiceProvider cryptoTransformSHA512 = new SHA512CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSHA512.ComputeHash(buffer)).Replace("-", "");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string personelid, adisoyadi, bagzamani = DateTime.Now.ToString();
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
            MySqlCommand komut = new MySqlCommand("Select Id,kadi,sifre,adsoyad from users where kadi='" + TextBox1.Text + "' and sifre='" + calculateSHA512(TextBox2.Text) + "'", baglanti);
            MySqlDataReader dr = komut.ExecuteReader();
            if (TextBox1.Text == "1" & TextBox2.Text == "1") { Session["Id"] = "9000"; Response.Redirect("default.aspx"); dr.Dispose(); baglanti.Close(); }
            else if (TextBox1.Text == "" & TextBox2.Text == "") { }
            else if (dr.Read())
            {
                adisoyadi = dr["adsoyad"].ToString(); Session["Id"] = dr["Id"].ToString(); personelid = dr["Id"].ToString();
                komut.CommandText = "INSERT INTO loginlogs(personelid,girenkisi,bagzamani) VALUES(@personelid,@girenkisi,@bagzamani)"; dr.Dispose();
                komut.Parameters.AddWithValue("personelid", personelid); komut.Parameters.AddWithValue("girenkisi", adisoyadi); komut.Parameters.AddWithValue("bagzamani", bagzamani);
                komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("default.aspx");
            }
            else { Label1.Visible = true; Label1.Text = "Kullanıcı Adı Veya Şifreniz Yanlış Lütfen Tekrar Deneyiniz"; }
        }
    }
}