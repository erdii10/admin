using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace admin
{
    public partial class haberdosyaduzenle : System.Web.UI.Page
    {
        public string Id, kontroldosya, icon, dosyaadi, katid, kontrolbaslik, kontrolaltbaslik;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null)
            {
                Id = Request.QueryString["Id"];
                MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("Select katid,baslik,aciklama,yolu,turu,sira from newsfile Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                DataTable dt = new DataTable(); da.Fill(dt); katid = dt.Rows[0]["katid"].ToString();
                if (!Page.IsPostBack)
                {
                    TextBox1.Text = dt.Rows[0]["baslik"].ToString(); TextBox2.Text = dt.Rows[0]["aciklama"].ToString(); TextBox3.Text = dt.Rows[0]["sira"].ToString();
                    if (dt.Rows[0]["yolu"].ToString() == "") { kontroldosya = "yok"; }
                    else
                    {
                        kontroldosya = "var";
                        if (dt.Rows[0]["turu"].ToString() == ".docx") { icon = "word"; } else if (dt.Rows[0]["turu"].ToString() == ".doc") { icon = "word"; } else if (dt.Rows[0]["turu"].ToString() == ".pdf") { icon = "pdf"; } else if (dt.Rows[0]["turu"].ToString() == ".xlsx") { icon = "excel"; } else if (dt.Rows[0]["turu"].ToString() == ".xls") { icon = "excel"; } else if (dt.Rows[0]["turu"].ToString() == ".pptx") { icon = "power"; } else if (dt.Rows[0]["turu"].ToString() == ".ppt") { icon = "power"; } else if (dt.Rows[0]["turu"].ToString() == ".accb") { icon = "access"; } else if (dt.Rows[0]["turu"].ToString() == ".mdb") { icon = "access"; } else if (dt.Rows[0]["turu"].ToString() == ".html") { icon = "html"; } else if (dt.Rows[0]["turu"].ToString() == ".htm") { icon = "html"; }
                        dosyaadi = dt.Rows[0]["yolu"].ToString();
                    }
                    /*Ana Başlıklar*/
                    da.SelectCommand.CommandText = "Select * from newsfile Where Id='" + Request.QueryString["Id"] + "' order by sira"; dt.Dispose();
                    dt = new DataTable(); da.Fill(dt); if (dt.Rows.Count == 0) { kontrolbaslik = "yok"; }
                    else { kontrolbaslik = "var"; string kate = dt.Rows[0]["katid"].ToString(); da.SelectCommand.CommandText = "Select * from news Where Id='" + kate + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt); RptBasliklar.DataSource = dt.DefaultView; RptBasliklar.DataBind(); }
                    /*Alt Başlıklar*/
                    da.SelectCommand.CommandText = "Select * from newsfile Where Id='" + Request.QueryString["Id"] + "'"; dt.Dispose();
                    dt = new DataTable(); da.Fill(dt); if (dt.Rows.Count == 0) { kontrolaltbaslik = "yok"; } else { kontrolaltbaslik = "var"; RptAltBasliklar.DataSource = dt.DefaultView; RptAltBasliklar.DataBind(); }
                }
                dt.Dispose(); baglanti.Close();

            }
            else { Response.Redirect("login.aspx"); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string sonuc, uzanti, fulluzanti, dosyaadi;
                dosyaadi = DateTime.Now.Year.ToString() + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
                fulluzanti = FileUpload1.FileName; uzanti = fulluzanti.Substring(fulluzanti.IndexOf("."), (fulluzanti.Length - fulluzanti.IndexOf(".")));
                double sadeboyut, dosyaboyutu = FileUpload1.PostedFile.ContentLength;
                if (dosyaboyutu < 5000000)
                {
                    if (dosyaboyutu < 1048576)
                    {
                        sadeboyut = dosyaboyutu / 1024; sonuc = sadeboyut.ToString(); sonuc = sonuc.Substring(0, 3) + " Kb";
                        FileUpload1.SaveAs(Server.MapPath("/file/news/" + dosyaadi + uzanti));
                        MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                        MySqlCommand komut = new MySqlCommand("Update newsfile Set baslik=@baslik,aciklama=@aciklama,yolu=@yolu,turu=@turu,boyutu=@boyutu,sira=@sira Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                        komut.Parameters.Add("@baslik", TextBox1.Text); komut.Parameters.Add("@aciklama", TextBox2.Text); komut.Parameters.Add("@yolu", dosyaadi + uzanti);
                        komut.Parameters.Add("@turu", uzanti); komut.Parameters.Add("@boyutu", sonuc); komut.Parameters.Add("@sira", TextBox3.Text);
                        komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                        komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Haber Dosya Güncelledi");
                        komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("haberduzenle.aspx?Id=" + katid);
                    }
                    else if (dosyaboyutu < 1073741824)
                    {
                        sadeboyut = dosyaboyutu / 1048576; sonuc = sadeboyut.ToString(); sonuc = sonuc.Substring(0, 4) + " Mb";
                        FileUpload1.SaveAs(Server.MapPath("/file/news/" + dosyaadi + uzanti));
                        MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                        MySqlCommand komut = new MySqlCommand("Update newsfile Set baslik=@baslik,aciklama=@aciklama,yolu=@yolu,turu=@turu,boyutu=@boyutu,sira=@sira Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                        komut.Parameters.Add("@baslik", TextBox1.Text); komut.Parameters.Add("@aciklama", TextBox2.Text); komut.Parameters.Add("@yolu", dosyaadi + uzanti);
                        komut.Parameters.Add("@turu", uzanti); komut.Parameters.Add("@boyutu", sonuc); komut.Parameters.Add("@sira", TextBox3.Text);
                        komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                        komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Haber Dosya Güncelledi");
                        komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("haberduzenle.aspx?Id=" + katid);
                    }
                }
                else
                {
                    Label1.Text = "Dosyanın boyutu 5 Mb'dan fazla olamaz.";
                }
            }
            else
            {
                string tarih = DateTime.Now.ToString();
                MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                MySqlCommand komut = new MySqlCommand("Update newsfile Set baslik=@baslik,aciklama=@aciklama,sira=@sira Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                komut.Parameters.Add("@baslik", TextBox1.Text); komut.Parameters.Add("@aciklama", TextBox2.Text); komut.Parameters.Add("@sira", TextBox3.Text);
                komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Haber Dosya İçerik Güncelledi");
                komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("haberduzenle.aspx?Id=" + katid);
            }
        }
    }
}