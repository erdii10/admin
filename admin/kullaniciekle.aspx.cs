using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using System.Security.Cryptography;

namespace admin
{
    public partial class kullaniciekle : System.Web.UI.Page
    {
        private static string calculateSHA512(string str)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            SHA512CryptoServiceProvider cryptoTransformSHA512 = new SHA512CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSHA512.ComputeHash(buffer)).Replace("-", "");
        }

        public string icerikgos, habergos, sssgos, zamangos, videogos, elistegos, anketgos, galerigos, ikgos, slidergos, kullanicigos, iletisimgos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null)
            {
                if (Session["Id"] == "9000")
                {
                    DateTime tarih = DateTime.Now; TextBox6.Text = tarih.ToString("dd.MM.yyyy");
                    icerikgos = "1"; habergos = "1"; sssgos = "1"; zamangos = "1"; videogos = "1"; elistegos = "1";
                    anketgos = "1"; galerigos = "1"; ikgos = "1"; slidergos = "1"; kullanicigos = "1"; iletisimgos = "1";
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string uzanti, resimadi, Ingilizce = TextBox1.Text; Ingilizce = Ingilizce.ToLower(); Ingilizce = Ingilizce.Replace('ö', 'o'); Ingilizce = Ingilizce.Replace('ü', 'u'); Ingilizce = Ingilizce.Replace('ğ', 'g'); Ingilizce = Ingilizce.Replace('ç', 'c'); Ingilizce = Ingilizce.Replace('ş', 's'); Ingilizce = Ingilizce.Replace('ı', 'i'); Ingilizce = Ingilizce.Replace(' ', '-');
                uzanti = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                resimadi = DateTime.Now.Day.ToString() + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
                if (uzanti == ".gif" | uzanti == ".jpg" | uzanti == ".bmp" | uzanti == ".png")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("INSERT INTO users(adsoyad,firma,kadi,sifre,eposta,resim,tarih,icerikler,haberler,sss,zaman,video,eliste,anket,galeri,ik,slider,kullanicilar,iletisim) VALUES(@adsoyad,@firma,@kadi,@sifre,@eposta,@resim,@tarih,@icerikler,@haberler,@sss,@zaman,@video,@eliste,@anket,@galeri,@ik,@slider,@kullanicilar,@iletisim)", baglanti);
                    komut.Parameters.AddWithValue("@adsoyad", TextBox1.Text); komut.Parameters.AddWithValue("@firma", TextBox2.Text); komut.Parameters.AddWithValue("@eposta", TextBox3.Text); komut.Parameters.AddWithValue("@resim", resimadi + uzanti); komut.Parameters.AddWithValue("@kadi", TextBox4.Text); komut.Parameters.AddWithValue("@sifre", calculateSHA512(TextBox5.Text)); komut.Parameters.AddWithValue("@tarih", TextBox6.Text);
                    komut.Parameters.AddWithValue("@icerikler", ((CheckBox1.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@haberler", ((CheckBox2.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@sss", ((CheckBox3.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@zaman", ((CheckBox4.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@video", ((CheckBox5.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@eliste", ((CheckBox6.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@anket", ((CheckBox7.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@galeri", ((CheckBox8.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@ik", ((CheckBox9.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@slider", ((CheckBox10.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@kullanicilar", ((CheckBox11.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@iletisim", ((CheckBox12.Checked) ? 1 : 0));
                    komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                    komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Kullanıcı Ekledi");
                    /*Resmi Orginal Boyutta Kaydetme*/
                    FileUpload1.SaveAs(Server.MapPath("/img/" + resimadi + uzanti));
                    komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close();
                    Response.Redirect("kirp.aspx?Id=" + Request.QueryString["Id"] + "&resimadi=" + resimadi + uzanti + "&kategori=ProfilEkle");
                }
                else { Label1.Text = "Eklenen resim uygun dosya türünde değildir. Tekrar Deneyiniz.."; }
            }
            else
            {
                MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                MySqlCommand komut = new MySqlCommand("INSERT INTO users(adsoyad,firma,kadi,sifre,eposta,tarih,icerikler,haberler,sss,zaman,video,eliste,anket,galeri,ik,slider,kullanicilar,iletisim) VALUES(@adsoyad,@firma,@kadi,@sifre,@eposta,@tarih,@icerikler,@haberler,@sss,@zaman,@video,@eliste,@anket,@galeri,@ik,@slider,@kullanicilar,@iletisim)", baglanti);
                komut.Parameters.AddWithValue("@adsoyad", TextBox1.Text); komut.Parameters.AddWithValue("@firma", TextBox2.Text); komut.Parameters.AddWithValue("@eposta", TextBox3.Text); komut.Parameters.AddWithValue("@kadi", TextBox4.Text); komut.Parameters.AddWithValue("@sifre", calculateSHA512(TextBox5.Text)); komut.Parameters.AddWithValue("@tarih", TextBox6.Text);
                komut.Parameters.AddWithValue("@icerikler", ((CheckBox1.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@haberler", ((CheckBox2.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@sss", ((CheckBox3.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@zaman", ((CheckBox4.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@video", ((CheckBox5.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@eliste", ((CheckBox6.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@anket", ((CheckBox7.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@galeri", ((CheckBox8.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@ik", ((CheckBox9.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@slider", ((CheckBox10.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@kullanicilar", ((CheckBox11.Checked) ? 1 : 0)); komut.Parameters.AddWithValue("@iletisim", ((CheckBox12.Checked) ? 1 : 0));
                komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Kullanıcı Ekledi");
                komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("kullanicilar.aspx");
            }
        }
    }
}