using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace admin
{
    public partial class videoekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null)
            {
                string id = Request.QueryString["Id"];
                if (id == null) { Panel2.Visible = false; Panel1.Visible = true; }
                else { Panel2.Visible = true; Panel1.Visible = false; }
            }
            else { Response.Redirect("login.aspx"); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Ingilizce;
            Ingilizce = TextBox1.Text; Ingilizce = Ingilizce.ToLower(); Ingilizce = Ingilizce.Replace('ö', 'o'); Ingilizce = Ingilizce.Replace('ü', 'u'); Ingilizce = Ingilizce.Replace('ğ', 'g'); Ingilizce = Ingilizce.Replace('ç', 'c'); Ingilizce = Ingilizce.Replace('ş', 's'); Ingilizce = Ingilizce.Replace('ı', 'i'); Ingilizce = Ingilizce.Replace(' ', '-');
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
            MySqlCommand komut = new MySqlCommand("INSERT INTO video(katid,baslik,baslikEN,sira) VALUES(@katid,@baslik,@baslikEN,@sira)", baglanti);
            komut.Parameters.AddWithValue("@katid", "0"); komut.Parameters.AddWithValue("@baslik", TextBox1.Text); komut.Parameters.AddWithValue("@baslikEN", Ingilizce); komut.Parameters.AddWithValue("@sira", TextBox2.Text);
            komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
            komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Video Kategorisi Ekledi");
            komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("videolar.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string Ingilizce = TextBox3.Text; Ingilizce = Ingilizce.ToLower(); Ingilizce = Ingilizce.Replace('ö', 'o'); Ingilizce = Ingilizce.Replace('ü', 'u'); Ingilizce = Ingilizce.Replace('ğ', 'g'); Ingilizce = Ingilizce.Replace('ç', 'c'); Ingilizce = Ingilizce.Replace('ş', 's'); Ingilizce = Ingilizce.Replace('ı', 'i'); Ingilizce = Ingilizce.Replace(' ', '-');
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
            MySqlCommand komut = new MySqlCommand("INSERT INTO video(katid,baslik,baslikEN,url,sira) VALUES(@katid,@baslik,@baslikEN,@url,@sira)", baglanti);
            komut.Parameters.AddWithValue("@katid", Request.QueryString["Id"]); komut.Parameters.AddWithValue("@baslik", TextBox3.Text); komut.Parameters.AddWithValue("@baslikEN", Ingilizce);
            komut.Parameters.AddWithValue("@url", TextBox4.Text); komut.Parameters.AddWithValue("@sira", TextBox5.Text);
            komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
            komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Video Ekledi");
            komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("videoduzenle.aspx?Id=" + Request.QueryString["Id"] + "");
        }
    }
}