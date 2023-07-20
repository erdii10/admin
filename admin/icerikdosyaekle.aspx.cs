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
    public partial class icerikdosyaekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null){} else { Response.Redirect("login.aspx"); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sonuc, uzanti, fulluzanti, dosyaadi ;
            dosyaadi = DateTime.Now.Year.ToString() + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
            if (FileUpload1.HasFile)
            {
                fulluzanti = FileUpload1.FileName; uzanti = fulluzanti.Substring(fulluzanti.IndexOf("."), (fulluzanti.Length - fulluzanti.IndexOf(".")));
                double sadeboyut, dosyaboyutu = FileUpload1.PostedFile.ContentLength;
                if (dosyaboyutu < 5000000)
                {
                    if (dosyaboyutu < 1048576)
                    {
                        sadeboyut = dosyaboyutu / 1024; sonuc = sadeboyut.ToString(); sonuc = sonuc.Substring(0, 3) + " Kb";
                        FileUpload1.SaveAs(Server.MapPath("/file/contents/" + dosyaadi + uzanti));
                        MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                        MySqlCommand komut = new MySqlCommand("INSERT INTO contentsfile(katid,baslik,aciklama,yolu,turu,boyutu,sira) VALUES(@katid,@baslik,@aciklama,@yolu,@turu,@boyutu,@sira)", baglanti);
                        komut.Parameters.AddWithValue("@katid", Request.QueryString["Id"].ToString()); komut.Parameters.AddWithValue("@baslik", TextBox1.Text); komut.Parameters.AddWithValue("@aciklama", TextBox2.Text); komut.Parameters.AddWithValue("@yolu", dosyaadi + uzanti); komut.Parameters.AddWithValue("@turu", uzanti); komut.Parameters.AddWithValue("@boyutu", sonuc); komut.Parameters.AddWithValue("@sira", TextBox3.Text);
                        komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                        komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "İçeriğe Dosya Ekledi");
                        komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("icerikduzenle.aspx?Id=" + Request.QueryString["Id"].ToString());
                    }
                    else if (dosyaboyutu < 1073741824)
                    {
                        sadeboyut = dosyaboyutu / 1048576; sonuc = sadeboyut.ToString(); sonuc = sonuc.Substring(0, 4) + " Mb";
                        FileUpload1.SaveAs(Server.MapPath("/file/contents/" + dosyaadi + uzanti));
                        MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                        MySqlCommand komut = new MySqlCommand("INSERT INTO contentsfile(katid,baslik,aciklama,yolu,turu,boyutu,sira) VALUES(@katid,@baslik,@aciklama,@yolu,@turu,@boyutu,@sira)", baglanti);
                        komut.Parameters.AddWithValue("@katid", Request.QueryString["Id"].ToString()); komut.Parameters.AddWithValue("@baslik", TextBox1.Text); komut.Parameters.AddWithValue("@aciklama", TextBox2.Text); komut.Parameters.AddWithValue("@yolu", dosyaadi + uzanti); komut.Parameters.AddWithValue("@turu", uzanti); komut.Parameters.AddWithValue("@boyutu", sonuc); komut.Parameters.AddWithValue("@sira", TextBox3.Text);
                        komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                        komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "İçeriğe Dosya Ekledi");
                        komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("icerikduzenle.aspx?Id=" + Request.QueryString["Id"].ToString());
                    }
                }
                else
                {
                    Label1.Text = "Dosyanın boyutu 5 Mb'dan fazla olamaz.";
                }
            }
            else
            {
                Label1.Text = "Dosya eklemeyi unuttunuz.";
            }
        }
    }
}