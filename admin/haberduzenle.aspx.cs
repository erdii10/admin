using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace admin
{
    public partial class haberduzenle : System.Web.UI.Page
    {
        public string kontrol, Id, kontrolresim, kontroldosya, kontrolbaslik, kontrolaltbaslik;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null)
            {
                string katid; Id = Request.QueryString["Id"];
                MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("Select katid,baslik,sira,resim from news Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                DataTable dt = new DataTable(); da.Fill(dt); katid = dt.Rows[0]["katid"].ToString();
                if (katid == "0")
                {
                    Panel2.Visible = false; Panel1.Visible = true;
                    if (!Page.IsPostBack)
                    {
                        TextBox1.Text = dt.Rows[0]["baslik"].ToString(); TextBox2.Text = dt.Rows[0]["sira"].ToString();
                        /*Kategori Alt Haber*/
                        da.SelectCommand.CommandText = "Select Id,katId,sira,baslik,baslikEN from news Where katid='" + Request.QueryString["Id"] + "' order by sira"; dt.Dispose();
                        dt = new DataTable(); da.Fill(dt); if (dt.Rows.Count == 0) { kontrol = "yok"; } else { kontrol = "var"; }
                        CollSayfala.DataSource = dt.DefaultView; CollSayfala.BindToControl = RptSirala; RptSirala.DataSource = CollSayfala.DataSourcePaged; RptSirala.DataBind();
                        dt.Dispose(); baglanti.Close();
                    }
                }
                else
                {
                    Panel2.Visible = true; Panel1.Visible = false;
                    if (!Page.IsPostBack)
                    {
                        da.SelectCommand.CommandText = "Select * from news Where Id='" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        TextBox3.Text = dt.Rows[0]["title"].ToString(); TextBox4.Text = dt.Rows[0]["keywords"].ToString(); TextBox5.Text = dt.Rows[0]["description"].ToString();
                        TextBox6.Text = dt.Rows[0]["baslik"].ToString(); TextBox7.Text = dt.Rows[0]["icerik"].ToString(); TextBox8.Text = dt.Rows[0]["tarih"].ToString();
                        TextBox9.Text = dt.Rows[0]["yazar"].ToString(); TextBox10.Text = dt.Rows[0]["sira"].ToString();
                        /*İçerik Resim*/
                        da.SelectCommand.CommandText = "Select * from newsimage Where katid='" + Request.QueryString["Id"] + "' order by sira"; dt.Dispose();
                        dt = new DataTable(); da.Fill(dt); if (dt.Rows.Count == 0) { kontrolresim = "yok"; } else { kontrolresim = "var"; CollResimler.DataSource = dt.DefaultView; CollResimler.BindToControl = RptResimler; RptResimler.DataSource = CollResimler.DataSourcePaged; RptResimler.DataBind(); }
                        /*---------------------------------------------------------------------------------------*/
                        /*İçerik Dosya*/
                        da.SelectCommand.CommandText = "Select * from newsfile Where katid='" + Request.QueryString["Id"] + "' order by sira"; dt.Dispose();
                        dt = new DataTable(); da.Fill(dt); if (dt.Rows.Count == 0) { kontroldosya = "yok"; } else { kontroldosya = "var"; CollDosyalar.DataSource = dt.DefaultView; CollDosyalar.BindToControl = RptDosyalar; RptDosyalar.DataSource = CollDosyalar.DataSourcePaged; RptDosyalar.DataBind(); }
                        /*---------------------------------------------------------------------------------------*/
                        /*Ana Başlıklar*/
                        da.SelectCommand.CommandText = "Select * from news Where Id='" + Request.QueryString["Id"] + "' order by sira"; dt.Dispose();
                        dt = new DataTable(); da.Fill(dt); if (dt.Rows.Count == 0) { kontrolbaslik = "yok"; }
                        else { kontrolbaslik = "var"; string kate = dt.Rows[0]["katid"].ToString(); da.SelectCommand.CommandText = "Select * from news Where Id='" + kate + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt); RptBasliklar.DataSource = dt.DefaultView; RptBasliklar.DataBind(); }
                        /*Alt Başlıklar*/
                        da.SelectCommand.CommandText = "Select * from news Where Id='" + Request.QueryString["Id"] + "'"; dt.Dispose();
                        dt = new DataTable(); da.Fill(dt); if (dt.Rows.Count == 0) { kontrolaltbaslik = "yok"; } else { kontrolaltbaslik = "var"; RptAltBasliklar.DataSource = dt.DefaultView; RptAltBasliklar.DataBind(); }
                        dt.Dispose(); baglanti.Close();
                    }
                }
            }
            else { Response.Redirect("login.aspx"); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Ingilizce = TextBox1.Text; Ingilizce = Ingilizce.ToLower(); Ingilizce = Ingilizce.Replace('ö', 'o'); Ingilizce = Ingilizce.Replace('ü', 'u'); Ingilizce = Ingilizce.Replace('ğ', 'g'); Ingilizce = Ingilizce.Replace('ç', 'c'); Ingilizce = Ingilizce.Replace('ş', 's'); Ingilizce = Ingilizce.Replace('ı', 'i'); Ingilizce = Ingilizce.Replace(' ', '-');
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
            MySqlCommand komut = new MySqlCommand("Update news Set baslik=@baslik,sira=@sira,baslikEN=@baslikEN Where Id='" + Request.QueryString["Id"] + "'", baglanti);
            komut.Parameters.Add("@baslik", TextBox1.Text); komut.Parameters.Add("@baslikEN", Ingilizce); komut.Parameters.Add("@sira", TextBox2.Text);
            komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
            komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Haber Kategori Düzeltmesi Yaptı");
            komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("haberduzenle.aspx?Id=" + Request.QueryString["Id"]);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string Ingilizce = TextBox6.Text; Ingilizce = Ingilizce.ToLower(); Ingilizce = Ingilizce.Replace('ö', 'o'); Ingilizce = Ingilizce.Replace('ü', 'u'); Ingilizce = Ingilizce.Replace('ğ', 'g'); Ingilizce = Ingilizce.Replace('ç', 'c'); Ingilizce = Ingilizce.Replace('ş', 's'); Ingilizce = Ingilizce.Replace('ı', 'i'); Ingilizce = Ingilizce.Replace(' ', '-');
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
            MySqlCommand komut = new MySqlCommand("Update news Set title=@title,keywords=@keywords,description=@description,baslik=@baslik,baslikEN=@baslikEN,icerik=@icerik,tarih=@tarih,yazar=@yazar,sira=@sira Where Id='" + Request.QueryString["Id"] + "'", baglanti);
            komut.Parameters.Add("@title", TextBox3.Text); komut.Parameters.Add("@keywords", TextBox4.Text); komut.Parameters.Add("@description", TextBox5.Text);
            komut.Parameters.Add("@baslik", TextBox6.Text); komut.Parameters.Add("@baslikEN", Ingilizce); komut.Parameters.Add("@icerik", TextBox7.Text);
            komut.Parameters.Add("@tarih", TextBox8.Text); komut.Parameters.Add("@yazar", TextBox9.Text); komut.Parameters.Add("@sira", TextBox10.Text);
            komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
            komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Haber Düzeltmesi Yaptı");
            komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("haberduzenle.aspx?Id=" + Request.QueryString["Id"]);
        }
    }
}