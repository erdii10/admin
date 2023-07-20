using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace admin
{
    public partial class sssekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] == null){Response.Redirect("login.aspx");}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Ingilizce;
            Ingilizce = TextBox1.Text; Ingilizce = Ingilizce.ToLower(); Ingilizce = Ingilizce.Replace('ö', 'o'); Ingilizce = Ingilizce.Replace('ü', 'u'); Ingilizce = Ingilizce.Replace('ğ', 'g'); Ingilizce = Ingilizce.Replace('ç', 'c'); Ingilizce = Ingilizce.Replace('ş', 's'); Ingilizce = Ingilizce.Replace('ı', 'i'); Ingilizce = Ingilizce.Replace(' ', '-');
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
            MySqlCommand komut = new MySqlCommand("INSERT INTO sss(soru,soruEN,cevap,sira) VALUES(@soru,@soruEN,@cevap,@sira)", baglanti);
            komut.Parameters.AddWithValue("@soru", TextBox1.Text); komut.Parameters.AddWithValue("@soruEN", Ingilizce); komut.Parameters.AddWithValue("@cevap", TextBox2.Text); komut.Parameters.AddWithValue("@sira", TextBox3.Text);
            komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
            komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Soru Ekledi");
            komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("sss.aspx");
        }
    }
}