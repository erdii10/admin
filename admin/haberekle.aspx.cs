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
    public partial class haberekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null)
            {
                string id = Request.QueryString["Id"];
                if (id == null) { Panel2.Visible = false; Panel1.Visible = true; }
                else { Panel2.Visible = true; Panel1.Visible = false; }
                if (Session["Id"] == "9000") { TextBox9.Text = "Admin"; }
                else
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select adsoyad from users Where Id='" + Session["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt); TextBox9.Text = dt.Rows[0]["adsoyad"].ToString(); dt.Dispose(); baglanti.Close();
                }
            }
            else { Response.Redirect("login.aspx"); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Ingilizce, tarih = DateTime.Now.ToString();
            Ingilizce = TextBox1.Text; Ingilizce = Ingilizce.ToLower(); Ingilizce = Ingilizce.Replace('ö', 'o'); Ingilizce = Ingilizce.Replace('ü', 'u'); Ingilizce = Ingilizce.Replace('ğ', 'g'); Ingilizce = Ingilizce.Replace('ç', 'c'); Ingilizce = Ingilizce.Replace('ş', 's'); Ingilizce = Ingilizce.Replace('ı', 'i'); Ingilizce = Ingilizce.Replace(' ', '-');
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
            MySqlCommand komut = new MySqlCommand("INSERT INTO news(katid,baslik,baslikEN,sira) VALUES(@katid,@baslik,@baslikEN,@sira)", baglanti);
            komut.Parameters.AddWithValue("@katid", "0"); komut.Parameters.AddWithValue("@baslik", TextBox1.Text); komut.Parameters.AddWithValue("@baslikEN", Ingilizce); komut.Parameters.AddWithValue("@sira", TextBox2.Text);
            komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
            komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", tarih); komut.Parameters.AddWithValue("@durum", "Haber Kategori Ekledi");
            komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("haberler.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string Ingilizce, tarih = DateTime.Now.ToString();
            Ingilizce = TextBox6.Text; Ingilizce = Ingilizce.ToLower(); Ingilizce = Ingilizce.Replace('ö', 'o'); Ingilizce = Ingilizce.Replace('ü', 'u'); Ingilizce = Ingilizce.Replace('ğ', 'g'); Ingilizce = Ingilizce.Replace('ç', 'c'); Ingilizce = Ingilizce.Replace('ş', 's'); Ingilizce = Ingilizce.Replace('ı', 'i'); Ingilizce = Ingilizce.Replace(' ', '-');
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
            MySqlCommand komut = new MySqlCommand("INSERT INTO news(katid,title,keywords,description,baslik,baslikEN,icerik,tarih,yazar,sira) VALUES(@katid,@title,@keywords,@description,@baslik,@baslikEN,@icerik,@tarih,@yazar,@sira)", baglanti);
            komut.Parameters.AddWithValue("@katid", Request.QueryString["Id"]); komut.Parameters.AddWithValue("@title", TextBox3.Text); komut.Parameters.AddWithValue("@keywords", TextBox4.Text); komut.Parameters.AddWithValue("@description", TextBox5.Text);
            komut.Parameters.AddWithValue("@baslik", TextBox6.Text); komut.Parameters.AddWithValue("@baslikEN", Ingilizce); komut.Parameters.AddWithValue("@icerik", TextBox7.Text);
            komut.Parameters.AddWithValue("@tarih", TextBox8.Text); komut.Parameters.AddWithValue("@yazar", TextBox9.Text); komut.Parameters.AddWithValue("@sira", TextBox10.Text);
            komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
            komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", tarih); komut.Parameters.AddWithValue("@durum", "Haber Ekledi");
            komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("haberduzenle.aspx?Id=" + Request.QueryString["Id"] + "");
        }
    }
}