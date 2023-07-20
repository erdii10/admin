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
    public partial class zamanekle : System.Web.UI.Page
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
            string Ingilizce, tarih = DateTime.Now.ToString();
            Ingilizce = TextBox1.Text; Ingilizce = Ingilizce.ToLower(); Ingilizce = Ingilizce.Replace('ö', 'o'); Ingilizce = Ingilizce.Replace('ü', 'u'); Ingilizce = Ingilizce.Replace('ğ', 'g'); Ingilizce = Ingilizce.Replace('ç', 'c'); Ingilizce = Ingilizce.Replace('ş', 's'); Ingilizce = Ingilizce.Replace('ı', 'i'); Ingilizce = Ingilizce.Replace(' ', '-');
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
            MySqlCommand komut = new MySqlCommand("INSERT INTO timer(katid,baslik,baslikEN,sira) VALUES(@katid,@baslik,@baslikEN,@sira)", baglanti);
            komut.Parameters.AddWithValue("@katid", "0"); komut.Parameters.AddWithValue("@baslik", TextBox1.Text); komut.Parameters.AddWithValue("@baslikEN", Ingilizce); komut.Parameters.AddWithValue("@sira", TextBox2.Text);
            komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
            komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", tarih); komut.Parameters.AddWithValue("@durum", "Zamanlanmış Görev Kategorisi Ekledi");
            komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("zaman.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string uzanti, resimadi, Ingilizce = TextBox3.Text; Ingilizce = Ingilizce.ToLower(); Ingilizce = Ingilizce.Replace('ö', 'o'); Ingilizce = Ingilizce.Replace('ü', 'u'); Ingilizce = Ingilizce.Replace('ğ', 'g'); Ingilizce = Ingilizce.Replace('ç', 'c'); Ingilizce = Ingilizce.Replace('ş', 's'); Ingilizce = Ingilizce.Replace('ı', 'i'); Ingilizce = Ingilizce.Replace(' ', '-');
                uzanti = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                resimadi = DateTime.Now.Day.ToString() + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
                if (uzanti == ".gif" | uzanti == ".jpg" | uzanti == ".bmp" | uzanti == ".png")
                {
                    string tarih = DateTime.Now.ToString();
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("INSERT INTO timer(katid,baslik,baslikEN,resim,url,bastarih,bittarih,sira) VALUES(@katid,@baslik,@baslikEN,@resim,@url,@bastarih,@bittarih,@sira)", baglanti);
                    komut.Parameters.AddWithValue("@katid", Request.QueryString["Id"]); komut.Parameters.AddWithValue("@baslik", TextBox3.Text); komut.Parameters.AddWithValue("@baslikEN", Ingilizce); komut.Parameters.AddWithValue("@resim", resimadi + uzanti);
                    komut.Parameters.AddWithValue("@url", TextBox4.Text); komut.Parameters.AddWithValue("@bastarih", TextBox5.Text); komut.Parameters.AddWithValue("@bittarih", TextBox6.Text); komut.Parameters.AddWithValue("@sira", TextBox7.Text);
                    komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                    komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", tarih); komut.Parameters.AddWithValue("@durum", "Resimli Zamanlanmış Görev Ekledi");
                    /*Resmi Orginal Boyutta Kaydetme*/
                    FileUpload1.SaveAs(Server.MapPath("/img/" + resimadi + uzanti));
                    komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close();
                    Response.Redirect("kirp.aspx?Id=" + Request.QueryString["Id"] + "&resimadi=" + resimadi + uzanti + "&kategori=Gorev");
                }
                else { Label1.Text = "Eklenen resim uygun dosya türünde değildir. Tekrar Deneyiniz.."; }
            }
            else
            {
                string tarih = DateTime.Now.ToString();
                string Ingilizce = TextBox3.Text; Ingilizce = Ingilizce.ToLower(); Ingilizce = Ingilizce.Replace('ö', 'o'); Ingilizce = Ingilizce.Replace('ü', 'u'); Ingilizce = Ingilizce.Replace('ğ', 'g'); Ingilizce = Ingilizce.Replace('ç', 'c'); Ingilizce = Ingilizce.Replace('ş', 's'); Ingilizce = Ingilizce.Replace('ı', 'i'); Ingilizce = Ingilizce.Replace(' ', '-');
                MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                MySqlCommand komut = new MySqlCommand("INSERT INTO timer(katid,baslik,baslikEN,url,bastarih,bittarih,sira) VALUES(@katid,@baslik,@baslikEN,@url,@bastarih,@bittarih,@sira)", baglanti);
                komut.Parameters.AddWithValue("@katid", Request.QueryString["Id"]); komut.Parameters.AddWithValue("@baslik", TextBox3.Text); komut.Parameters.AddWithValue("@baslikEN", Ingilizce);
                komut.Parameters.AddWithValue("@url", TextBox4.Text); komut.Parameters.AddWithValue("@bastarih", TextBox5.Text); komut.Parameters.AddWithValue("@bittarih", TextBox6.Text); komut.Parameters.AddWithValue("@sira", TextBox7.Text);
                komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", tarih); komut.Parameters.AddWithValue("@durum", "Resimsiz Zamanlanmış Görev Ekledi");
                komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("zamanduzenle.aspx?Id=" + Request.QueryString["Id"] + "");
            }
        }
    }
}