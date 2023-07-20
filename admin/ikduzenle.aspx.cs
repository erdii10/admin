using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admin
{
    public partial class ikduzenle : System.Web.UI.Page
    {
        public string tc, adsoyad, cinsiyet, medenihal, cocuksay, tel, eposta, adres, dogtar, meslek, baspoz, dosya;

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
            MySqlCommand komut = new MySqlCommand("Select * from ik where Id='" + Request.QueryString["Id"] + "'", baglanti);
            MySqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/msword";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
                HttpContext.Current.Response.Charset = "ISO-8859-9";
                string dosyaAdi = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".doc";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + dosyaAdi);
                StringBuilder HTMLicerik = new StringBuilder();
                HTMLicerik.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\"> " + "<body style=\"text-align: left; width: 750px;\"> " +
                "<center><h2>" + dr["adsoyad"].ToString() + " Cv Formu</h2></center>" +
                "<table  width='700' border='0' cellspacing='7' cellpadding='7'>" +
                    "<tr>" +
                        "<td <td width='150' style='font-weight:bold;'>" + "Tc Kimlik No" + "</td>" +
                        "<td width='5'>:</td>" +
                        "<td>" + dr["tc"].ToString() + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td <td width='150' style='font-weight:bold;'>" + "Adı Soyadı" + "</td>" +
                        "<td width='5'>:</td>" +
                        "<td>" + dr["adsoyad"].ToString() + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td <td width='150' style='font-weight:bold;'>" + "Cinsiyeti" + "</td>" +
                        "<td width='5'>:</td>" +
                        "<td>" + dr["cinsiyet"].ToString() + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td <td width='150' style='font-weight:bold;'>" + "Medeni Hali" + "</td>" +
                        "<td width='5'>:</td>" +
                        "<td>" + dr["medenihal"].ToString() + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td <td width='150' style='font-weight:bold;'>" + "Varsa Çocuk Sayısı" + "</td>" +
                        "<td width='5'>:</td>" +
                        "<td>" + dr["cocuksay"].ToString() + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td <td width='150' style='font-weight:bold;'>" + "Telefon Numarası" + "</td>" +
                        "<td width='5'>:</td>" +
                        "<td>" + dr["tel"].ToString() + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td <td width='150' style='font-weight:bold;'>" + "E-Posta Adresi" + "</td>" +
                        "<td width='5'>:</td>" +
                        "<td>" + dr["eposta"].ToString() + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td <td width='150' style='font-weight:bold;'>" + "Adresi" + "</td>" +
                        "<td width='5'>:</td>" +
                        "<td>" + dr["adres"].ToString() + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td <td width='150' style='font-weight:bold;'>" + "Doğum Tarihi" + "</td>" +
                        "<td width='5'>:</td>" +
                        "<td>" + dr["dogtar"].ToString() + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td <td width='150' style='font-weight:bold;'>" + "Mesleği" + "</td>" +
                        "<td width='5'>:</td>" +
                        "<td>" + dr["meslek"].ToString() + "</td>" +
                    "</tr>" +
                    "<tr>" +
                        "<td <td width='150' style='font-weight:bold;'>" + "Başvurduğu Pozisyon" + "</td>" +
                        "<td width='5'>:</td>" +
                        "<td>" + dr["baspoz"].ToString() + "</td>" +
                    "</tr>" +
                "</table>" + "</body>" + "</html>".ToString());
                HttpContext.Current.Response.Write(HTMLicerik); HttpContext.Current.Response.End(); HttpContext.Current.Response.Flush(); dr.Dispose(); baglanti.Close();
            }
            else { dr.Dispose(); baglanti.Close(); }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
            MySqlCommand komut = new MySqlCommand("Select * from ik where Id='" + Request.QueryString["Id"] + "'", baglanti);
            MySqlDataReader dr = komut.ExecuteReader();
            if (dr["dosyayolu"].ToString() != "")
            {
                string dosyaurl = @Server.MapPath("/file/ik/") + dr["dosyayolu"].ToString();
                string yenidosya = dr["dosyayolu"].ToString(); FileStream fs = new FileStream(dosyaurl, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[(int)fs.Length]; fs.Read(buffer, 0, (int)fs.Length); fs.Close(); Response.Clear();
                Response.AddHeader("Content-Length", buffer.Length.ToString()); Response.AddHeader("Content-Disposition", "attachment; filename=" + yenidosya);
                Response.BinaryWrite(buffer); Response.End(); dr.Dispose(); baglanti.Close();
            }
            else { LinkButton1.Text = "Cv Dosyası Yüklememiştir"; Response.Redirect("ikduzenle.aspx?Id=" + Request.QueryString["Id"]); dr.Dispose(); baglanti.Close(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null)
            {
                if (!Page.IsPostBack)
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("Select * from ik where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    MySqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        tc = dr["tc"].ToString(); adsoyad = dr["adsoyad"].ToString(); cinsiyet = dr["cinsiyet"].ToString(); medenihal = dr["medenihal"].ToString(); cocuksay = dr["cocuksay"].ToString(); tel = dr["tel"].ToString(); eposta = dr["eposta"].ToString(); adres = dr["adres"].ToString(); dogtar = dr["dogtar"].ToString(); meslek = dr["meslek"].ToString(); baspoz = dr["baspoz"].ToString();
                        if (dr["dosyayolu"].ToString() != "") { LinkButton1.Text = "İndirmek İçin Tıklayınız.."; }
                        else { LinkButton1.Text = "Cv Dosyası Yüklememiştir"; } dr.Dispose(); baglanti.Close();
                    }
                    else { dr.Dispose(); baglanti.Close(); }
                }
            }
            else { Response.Redirect("login.aspx"); }
        }
    }
}