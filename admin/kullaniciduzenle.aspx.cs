using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace admin
{
    public partial class kullaniciduzenle : System.Web.UI.Page
    {
        private static string calculateSHA512(string str)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            SHA512CryptoServiceProvider cryptoTransformSHA512 = new SHA512CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSHA512.ComputeHash(buffer)).Replace("-", "");
        }

        public string kontrolresim, resim, Id, kontrolyetki, kullaniciId;
        protected void Page_Load(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select * from users Where Id='" + Request.QueryString["Id"].ToString() + "'", baglanti);
            DataTable dt = new DataTable(); da.Fill(dt); Id = Request.QueryString["Id"]; kullaniciId = dt.Rows[0]["Id"].ToString();
            if (!Page.IsPostBack)
            {
                if (Session["Id"] != null && Session["Id"].ToString() != Id)
                {
                    kontrolyetki = "var";
                    if (dt.Rows[0]["resim"].ToString() == "") { kontrolresim = "yok"; }
                    else { kontrolresim = "var"; resim = dt.Rows[0]["resim"].ToString(); }
                    TextBox1.Text = dt.Rows[0]["adsoyad"].ToString(); TextBox2.Text = dt.Rows[0]["firma"].ToString(); TextBox3.Text = dt.Rows[0]["eposta"].ToString(); TextBox4.Text = dt.Rows[0]["kadi"].ToString();
                    TextBox6.Text = dt.Rows[0]["tarih"].ToString();
                    if (dt.Rows[0]["icerikler"].ToString() == "1") { CheckBox1.Checked = true; } else { CheckBox1.Checked = false; }
                    if (dt.Rows[0]["haberler"].ToString() == "1") { CheckBox2.Checked = true; } else { CheckBox2.Checked = false; }
                    if (dt.Rows[0]["sss"].ToString() == "1") { CheckBox3.Checked = true; } else { CheckBox3.Checked = false; }
                    if (dt.Rows[0]["zaman"].ToString() == "1") { CheckBox4.Checked = true; } else { CheckBox4.Checked = false; }
                    if (dt.Rows[0]["video"].ToString() == "1") { CheckBox5.Checked = true; } else { CheckBox5.Checked = false; }
                    if (dt.Rows[0]["eliste"].ToString() == "1") { CheckBox6.Checked = true; } else { CheckBox6.Checked = false; }
                    if (dt.Rows[0]["anket"].ToString() == "1") { CheckBox7.Checked = true; } else { CheckBox7.Checked = false; }
                    if (dt.Rows[0]["galeri"].ToString() == "1") { CheckBox8.Checked = true; } else { CheckBox8.Checked = false; }
                    if (dt.Rows[0]["ik"].ToString() == "1") { CheckBox9.Checked = true; } else { CheckBox9.Checked = false; }
                    if (dt.Rows[0]["slider"].ToString() == "1") { CheckBox10.Checked = true; } else { CheckBox10.Checked = false; }
                    if (dt.Rows[0]["kullanicilar"].ToString() == "1") { CheckBox11.Checked = true; } else { CheckBox11.Checked = false; }
                    if (dt.Rows[0]["iletisim"].ToString() == "1") { CheckBox12.Checked = true; } else { CheckBox12.Checked = false; }
                    dt.Dispose(); baglanti.Close();
                }
                else if (Session["Id"].ToString() == dt.Rows[0]["Id"].ToString())
                {
                    kontrolyetki = "yok";
                    if (dt.Rows[0]["resim"].ToString() == "") { kontrolresim = "yok"; }
                    else { kontrolresim = "var"; resim = dt.Rows[0]["resim"].ToString(); }
                    TextBox1.Text = dt.Rows[0]["adsoyad"].ToString(); TextBox2.Text = dt.Rows[0]["firma"].ToString(); TextBox3.Text = dt.Rows[0]["eposta"].ToString(); TextBox4.Text = dt.Rows[0]["kadi"].ToString();
                    TextBox6.Text = dt.Rows[0]["tarih"].ToString(); dt.Dispose(); baglanti.Close();
                }
                else { Response.Redirect("login.aspx"); }
            }
            dt.Dispose(); baglanti.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["Id"] != null && Session["Id"].ToString() != Id)
            {
                if (FileUpload1.HasFile)
                {
                    string uzanti, resimadi, Ingilizce = TextBox1.Text; Ingilizce = Ingilizce.ToLower(); Ingilizce = Ingilizce.Replace('ö', 'o'); Ingilizce = Ingilizce.Replace('ü', 'u'); Ingilizce = Ingilizce.Replace('ğ', 'g'); Ingilizce = Ingilizce.Replace('ç', 'c'); Ingilizce = Ingilizce.Replace('ş', 's'); Ingilizce = Ingilizce.Replace('ı', 'i'); Ingilizce = Ingilizce.Replace(' ', '-');
                    uzanti = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                    resimadi = DateTime.Now.Day.ToString() + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
                    if (uzanti == ".gif" | uzanti == ".jpg" | uzanti == ".bmp" | uzanti == ".png")
                    {
                        MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                        MySqlCommand komut = new MySqlCommand("Update users Set adsoyad=@adsoyad,firma=@firma,eposta=@eposta,tarih=@tarih,resim=@resim,kadi=@kadi,icerikler=@icerikler,haberler=@haberler,sss=@sss,zaman=@zaman,video=@video,eliste=@eliste,anket=@anket,galeri=@galeri,ik=@ik,slider=@slider,kullanicilar=@kullanicilar,iletisim=@iletisim Where Id='" + Request.QueryString["Id"].ToString() + "'", baglanti);
                        komut.Parameters.Add("@adsoyad", TextBox1.Text); komut.Parameters.Add("@firma", TextBox2.Text); komut.Parameters.Add("@eposta", TextBox3.Text); komut.Parameters.Add("@kadi", TextBox4.Text);
                        komut.Parameters.Add("@tarih", TextBox6.Text); komut.Parameters.Add("@resim", resimadi + uzanti); komut.Parameters.Add("@icerikler", ((CheckBox1.Checked ? '1' : '0'))); komut.Parameters.Add("@haberler", ((CheckBox2.Checked ? '1' : '0')));
                        komut.Parameters.Add("@sss", ((CheckBox3.Checked ? '1' : '0'))); komut.Parameters.Add("@zaman", ((CheckBox4.Checked ? '1' : '0'))); komut.Parameters.Add("@video", ((CheckBox5.Checked ? '1' : '0')));
                        komut.Parameters.Add("@eliste", ((CheckBox6.Checked ? '1' : '0'))); komut.Parameters.Add("@anket", ((CheckBox7.Checked ? '1' : '0'))); komut.Parameters.Add("@galeri", ((CheckBox8.Checked ? '1' : '0')));
                        komut.Parameters.Add("@ik", ((CheckBox9.Checked ? '1' : '0'))); komut.Parameters.Add("@slider", ((CheckBox10.Checked ? '1' : '0'))); komut.Parameters.Add("@kullanicilar", ((CheckBox11.Checked ? '1' : '0')));
                        komut.Parameters.Add("@iletisim", ((CheckBox12.Checked ? '1' : '0')));
                        komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                        komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Kullanıcı Düzenlendi");
                        /*Resmi Orginal Boyutta Kaydetme*/
                        FileUpload1.SaveAs(Server.MapPath("/img/" + resimadi + uzanti));
                        komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close();
                        Response.Redirect("kirp.aspx?Id=" + Request.QueryString["Id"] + "&resimadi=" + resimadi + uzanti + "&kategori=ProfilDuzenle");
                    }
                    else { Label1.Text = "Eklenen resim uygun dosya türünde değildir. Tekrar Deneyiniz.."; }
                }
                else
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("Update users Set adsoyad=@adsoyad,firma=@firma,eposta=@eposta,tarih=@tarih,kadi=@kadi,icerikler=@icerikler,haberler=@haberler,sss=@sss,zaman=@zaman,video=@video,eliste=@eliste,anket=@anket,galeri=@galeri,ik=@ik,slider=@slider,kullanicilar=@kullanicilar,iletisim=@iletisim Where Id='" + Request.QueryString["Id"].ToString() + "'", baglanti);
                    komut.Parameters.Add("@adsoyad", TextBox1.Text); komut.Parameters.Add("@firma", TextBox2.Text); komut.Parameters.Add("@eposta", TextBox3.Text); komut.Parameters.Add("@kadi", TextBox4.Text);
                    komut.Parameters.Add("@tarih", TextBox6.Text); komut.Parameters.Add("@icerikler", ((CheckBox1.Checked ? '1' : '0'))); komut.Parameters.Add("@haberler", ((CheckBox2.Checked ? '1' : '0')));
                    komut.Parameters.Add("@sss", ((CheckBox3.Checked ? '1' : '0'))); komut.Parameters.Add("@zaman", ((CheckBox4.Checked ? '1' : '0'))); komut.Parameters.Add("@video", ((CheckBox5.Checked ? '1' : '0')));
                    komut.Parameters.Add("@eliste", ((CheckBox6.Checked ? '1' : '0'))); komut.Parameters.Add("@anket", ((CheckBox7.Checked ? '1' : '0'))); komut.Parameters.Add("@galeri", ((CheckBox8.Checked ? '1' : '0')));
                    komut.Parameters.Add("@ik", ((CheckBox9.Checked ? '1' : '0'))); komut.Parameters.Add("@slider", ((CheckBox10.Checked ? '1' : '0'))); komut.Parameters.Add("@kullanicilar", ((CheckBox11.Checked ? '1' : '0')));
                    komut.Parameters.Add("@iletisim", ((CheckBox12.Checked ? '1' : '0')));
                    komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                    komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Kullanıcı Düzenlendi");
                    komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close();
                    Response.Redirect("kullaniciduzenle.aspx?Id=" + Request.QueryString["Id"].ToString());
                }
            }
            else
            {
                if (FileUpload1.HasFile)
                {
                    string uzanti, resimadi, Ingilizce = TextBox1.Text; Ingilizce = Ingilizce.ToLower(); Ingilizce = Ingilizce.Replace('ö', 'o'); Ingilizce = Ingilizce.Replace('ü', 'u'); Ingilizce = Ingilizce.Replace('ğ', 'g'); Ingilizce = Ingilizce.Replace('ç', 'c'); Ingilizce = Ingilizce.Replace('ş', 's'); Ingilizce = Ingilizce.Replace('ı', 'i'); Ingilizce = Ingilizce.Replace(' ', '-');
                    uzanti = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                    resimadi = DateTime.Now.Day.ToString() + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
                    if (uzanti == ".gif" | uzanti == ".jpg" | uzanti == ".bmp" | uzanti == ".png")
                    {
                        if (Request.QueryString["Id"] != kullaniciId)
                        {
                            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                            MySqlCommand komut = new MySqlCommand("Update users Set adsoyad=@adsoyad,firma=@firma,eposta=@eposta,tarih=@tarih,resim=@resim,kadi=@kadi,icerikler=@icerikler,haberler=@haberler,sss=@sss,zaman=@zaman,video=@video,eliste=@eliste,anket=@anket,galeri=@galeri,ik=@ik,slider=@slider,kullanicilar=@kullanicilar,iletisim=@iletisim Where Id='" + Request.QueryString["Id"].ToString() + "'", baglanti);
                            komut.Parameters.Add("@adsoyad", TextBox1.Text); komut.Parameters.Add("@firma", TextBox2.Text); komut.Parameters.Add("@eposta", TextBox3.Text); komut.Parameters.Add("@kadi", TextBox4.Text);
                            komut.Parameters.Add("@tarih", TextBox6.Text); komut.Parameters.Add("@resim", resimadi + uzanti); komut.Parameters.Add("@icerikler", ((CheckBox1.Checked ? '1' : '0'))); komut.Parameters.Add("@haberler", ((CheckBox2.Checked ? '1' : '0')));
                            komut.Parameters.Add("@sss", ((CheckBox3.Checked ? '1' : '0'))); komut.Parameters.Add("@zaman", ((CheckBox4.Checked ? '1' : '0'))); komut.Parameters.Add("@video", ((CheckBox5.Checked ? '1' : '0')));
                            komut.Parameters.Add("@eliste", ((CheckBox6.Checked ? '1' : '0'))); komut.Parameters.Add("@anket", ((CheckBox7.Checked ? '1' : '0'))); komut.Parameters.Add("@galeri", ((CheckBox8.Checked ? '1' : '0')));
                            komut.Parameters.Add("@ik", ((CheckBox9.Checked ? '1' : '0'))); komut.Parameters.Add("@slider", ((CheckBox10.Checked ? '1' : '0'))); komut.Parameters.Add("@kullanicilar", ((CheckBox11.Checked ? '1' : '0')));
                            komut.Parameters.Add("@iletisim", ((CheckBox12.Checked ? '1' : '0')));
                            komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                            komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Kullanıcı Düzenlendi");
                            /*Resmi Orginal Boyutta Kaydetme*/
                            FileUpload1.SaveAs(Server.MapPath("/img/" + resimadi + uzanti));
                            komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close();
                            Response.Redirect("kirp.aspx?Id=" + Request.QueryString["Id"] + "&resimadi=" + resimadi + uzanti + "&kategori=ProfilDuzenle");
                        }
                        else if (Request.QueryString["Id"] == kullaniciId)
                        {
                            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                            MySqlCommand komut = new MySqlCommand("Update users Set adsoyad=@adsoyad,firma=@firma,eposta=@eposta,tarih=@tarih,resim=@resim,kadi=@kadi Where Id='" + Request.QueryString["Id"].ToString() + "'", baglanti);
                            komut.Parameters.Add("@adsoyad", TextBox1.Text); komut.Parameters.Add("@firma", TextBox2.Text); komut.Parameters.Add("@eposta", TextBox3.Text); komut.Parameters.Add("@kadi", TextBox4.Text);
                            komut.Parameters.Add("@tarih", TextBox6.Text); komut.Parameters.Add("@resim", resimadi + uzanti);
                            komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                            komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Kullanıcı Düzenlendi");
                            /*Resmi Orginal Boyutta Kaydetme*/
                            FileUpload1.SaveAs(Server.MapPath("/img/" + resimadi + uzanti));
                            komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close();
                            Response.Redirect("kirp.aspx?Id=" + Request.QueryString["Id"] + "&resimadi=" + resimadi + uzanti + "&kategori=ProfilDuzenle");
                        }
                    }
                    else { Label1.Text = "Eklenen resim uygun dosya türünde değildir. Tekrar Deneyiniz.."; }
                }
                else
                {
                    if (Request.QueryString["Id"] != kullaniciId)
                    {
                        MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                        MySqlCommand komut = new MySqlCommand("Update users Set adsoyad=@adsoyad,firma=@firma,eposta=@eposta,tarih=@tarih,kadi=@kadi,icerikler=@icerikler,haberler=@haberler,sss=@sss,zaman=@zaman,video=@video,eliste=@eliste,anket=@anket,galeri=@galeri,ik=@ik,slider=@slider,kullanicilar=@kullanicilar,iletisim=@iletisim Where Id='" + Request.QueryString["Id"].ToString() + "'", baglanti);
                        komut.Parameters.Add("@adsoyad", TextBox1.Text); komut.Parameters.Add("@firma", TextBox2.Text); komut.Parameters.Add("@eposta", TextBox3.Text); komut.Parameters.Add("@kadi", TextBox4.Text);
                        komut.Parameters.Add("@tarih", TextBox6.Text);komut.Parameters.Add("@icerikler", ((CheckBox1.Checked ? '1' : '0'))); komut.Parameters.Add("@haberler", ((CheckBox2.Checked ? '1' : '0')));
                        komut.Parameters.Add("@sss", ((CheckBox3.Checked ? '1' : '0'))); komut.Parameters.Add("@zaman", ((CheckBox4.Checked ? '1' : '0'))); komut.Parameters.Add("@video", ((CheckBox5.Checked ? '1' : '0')));
                        komut.Parameters.Add("@eliste", ((CheckBox6.Checked ? '1' : '0'))); komut.Parameters.Add("@anket", ((CheckBox7.Checked ? '1' : '0'))); komut.Parameters.Add("@galeri", ((CheckBox8.Checked ? '1' : '0')));
                        komut.Parameters.Add("@ik", ((CheckBox9.Checked ? '1' : '0'))); komut.Parameters.Add("@slider", ((CheckBox10.Checked ? '1' : '0'))); komut.Parameters.Add("@kullanicilar", ((CheckBox11.Checked ? '1' : '0')));
                        komut.Parameters.Add("@iletisim", ((CheckBox12.Checked ? '1' : '0')));
                        komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                        komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Kullanıcı Düzenlendi");
                        komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close();
                        Response.Redirect("kullaniciduzenle.aspx?Id=" + Request.QueryString["Id"].ToString());
                    }
                    else if (Request.QueryString["Id"] == kullaniciId)
                    {
                        MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                        MySqlCommand komut = new MySqlCommand("Update users Set adsoyad=@adsoyad,firma=@firma,eposta=@eposta,tarih=@tarih,kadi=@kadi Where Id='" + Request.QueryString["Id"].ToString() + "'", baglanti);
                        komut.Parameters.Add("@adsoyad", TextBox1.Text); komut.Parameters.Add("@firma", TextBox2.Text); komut.Parameters.Add("@eposta", TextBox3.Text); komut.Parameters.Add("@kadi", TextBox4.Text);
                        komut.Parameters.Add("@tarih", TextBox6.Text);
                        komut.ExecuteNonQuery(); komut.CommandText = "INSERT INTO logs(personelid,ipadres,bagzamani,durum) VALUES(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                        komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Kullanıcı Düzenlendi");
                        komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close();
                        Response.Redirect("kullaniciduzenle.aspx?Id=" + Request.QueryString["Id"].ToString());
                    }
                }
            }
        }

        protected void btnhatirlat_Click(object sender, EventArgs e)
        {
            if (TextBox8.Text == TextBox9.Text)
            {
                MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                MySqlCommand komut = new MySqlCommand("Update users Set sifre=@sifre Where eposta='" + TextBox3.Text + "'", baglanti);
                komut.Parameters.Add("@sifre", calculateSHA512(TextBox9.Text)); komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close();
                Response.Redirect("kullaniciduzenle.aspx?Id=" + Request.QueryString["Id"].ToString());
            }
            else { Label1.Text = "Yazmış Olduğunuz Şifreler Aynı Değil!"; }
        }
    }
}