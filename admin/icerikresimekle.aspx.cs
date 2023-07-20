using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admin
{
    public partial class icerikresimekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null){} else { Response.Redirect("login.aspx"); }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string uzanti, resimadi, tarih = DateTime.Now.ToString();
            if (FileUpload1.HasFile)
            {
                uzanti = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                resimadi = DateTime.Now.Day.ToString() + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
                if (uzanti == ".gif" | uzanti == ".jpg" | uzanti == ".bmp" | uzanti == ".png")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("INSERT INTO contentsimage(katid,baslik,resim,sira) VALUES(@katid,@baslik,@resim,@sira)", baglanti);
                    komut.Parameters.AddWithValue("@katid", Request.QueryString["Id"]); komut.Parameters.AddWithValue("@baslik", TextBox1.Text);
                    komut.Parameters.AddWithValue("@sira", TextBox2.Text); komut.Parameters.AddWithValue("@resim", resimadi + uzanti);
                    komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                    komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", tarih); komut.Parameters.AddWithValue("@durum", "İçeriğe Resim Ekledi");
                    /*Resmi Orginal Boyutta Kaydetme*/
                    FileUpload1.SaveAs(Server.MapPath("/img/" + resimadi + uzanti));
                    komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close();
                    Response.Redirect("kirp.aspx?Id=" + Request.QueryString["Id"] + "&resimadi=" + resimadi + uzanti + "&kategori=" + Request.QueryString["kategori"] + "");
                }
                else { Label1.Text = "Eklenen resim uygun dosya türünde değildir. Tekrar Deneyiniz.."; }
            }
            else
            {
                MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                MySqlCommand komut = new MySqlCommand("INSERT INTO contentsimage(katid,baslik,sira) VALUES(@katid,@baslik,@sira)", baglanti);
                komut.Parameters.AddWithValue("@katid", Request.QueryString["Id"]); komut.Parameters.AddWithValue("@baslik", TextBox1.Text);
                komut.Parameters.AddWithValue("@sira", TextBox2.Text);
                komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", tarih); komut.Parameters.AddWithValue("@durum", "İçeriğe Resimsiz Resim Bilgisi Ekledi");
                komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("icerikduzenle.aspx?Id=" + Request.QueryString["Id"]);
            }
        }
    }
}