using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admin
{
    public partial class icerikresimduzenle : System.Web.UI.Page
    {
        public string Id, resim, kontrolresim, katid, kategori, kontrolbaslik, kontrolaltbaslik;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null)
            {
                Id = Request.QueryString["Id"]; kategori = Request.QueryString["kategori"];
                MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("Select katid,baslik,sira,resim from contentsimage Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                DataTable dt = new DataTable(); da.Fill(dt); katid = dt.Rows[0]["katid"].ToString();
                if (!Page.IsPostBack)
                {
                    TextBox1.Text = dt.Rows[0]["baslik"].ToString(); TextBox2.Text = dt.Rows[0]["sira"].ToString(); 
                    if (dt.Rows[0]["resim"].ToString() == "") { kontrolresim = "yok"; }
                    else { kontrolresim = "var"; resim = dt.Rows[0]["resim"].ToString(); }
                    /*Ana Başlıklar*/
                    da.SelectCommand.CommandText = "Select * from contentsimage Where Id='" + Request.QueryString["Id"] + "' order by sira"; dt.Dispose();
                    dt = new DataTable(); da.Fill(dt); if (dt.Rows.Count == 0) { kontrolbaslik = "yok"; }
                    else { kontrolbaslik = "var"; string kate = dt.Rows[0]["katid"].ToString(); da.SelectCommand.CommandText = "Select * from contents Where Id='" + kate + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt); RptBasliklar.DataSource = dt.DefaultView; RptBasliklar.DataBind(); }
                    /*Alt Başlıklar*/
                    da.SelectCommand.CommandText = "Select * from contentsimage Where Id='" + Request.QueryString["Id"] + "'"; dt.Dispose();
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
                string uzanti, resimadi;
                uzanti = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                resimadi = DateTime.Now.Day.ToString() + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
                if (uzanti == ".gif" | uzanti == ".jpg" | uzanti == ".bmp" | uzanti == ".png")
                {
                    string tarih = DateTime.Now.ToString();
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("Update contentsimage Set baslik=@baslik,resim=@resim,sira=@sira Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    komut.Parameters.Add("@baslik", TextBox1.Text); komut.Parameters.Add("@sira", TextBox2.Text); komut.Parameters.AddWithValue("@resim", resimadi + uzanti);
                    komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                    komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "İçerik Resmi Güncelledi");
                    /*Resmi Orginal Boyutta Kaydetme*/
                    FileUpload1.SaveAs(Server.MapPath("/img/" + resimadi + uzanti));
                    komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close();
                    Response.Redirect("kirp.aspx?Id=" + Request.QueryString["Id"] + "&resimadi=" + resimadi + uzanti + "&kategori=" + Request.QueryString["kategori"] + "");
                }
                else { Label1.Text = "Eklenen resim uygun dosya türünde değildir. Tekrar Deneyiniz.."; }
            }
            else
            {
                string tarih = DateTime.Now.ToString();
                MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                MySqlCommand komut = new MySqlCommand("Update contentsimage Set baslik=@baslik,sira=@sira Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                komut.Parameters.Add("@baslik", TextBox1.Text); komut.Parameters.Add("@sira", TextBox2.Text);
                komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "İçerik Resminin Bilgilerini Güncelledi");
                komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("icerikduzenle.aspx?Id=" + katid);
            }
        }
    }
}