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
    public partial class sssduzenle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null)
            {
                MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("Select * from sss Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                DataTable dt = new DataTable(); da.Fill(dt);
                if (!Page.IsPostBack)
                {
                    TextBox1.Text = dt.Rows[0]["soru"].ToString(); TextBox2.Text = dt.Rows[0]["cevap"].ToString(); TextBox3.Text = dt.Rows[0]["sira"].ToString();
                    dt.Dispose(); baglanti.Close();
                }
            }
            else { Response.Redirect("login.aspx"); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Ingilizce = TextBox1.Text; Ingilizce = Ingilizce.ToLower(); Ingilizce = Ingilizce.Replace('ö', 'o'); Ingilizce = Ingilizce.Replace('ü', 'u'); Ingilizce = Ingilizce.Replace('ğ', 'g'); Ingilizce = Ingilizce.Replace('ç', 'c'); Ingilizce = Ingilizce.Replace('ş', 's'); Ingilizce = Ingilizce.Replace('ı', 'i'); Ingilizce = Ingilizce.Replace(' ', '-');
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
            MySqlCommand komut = new MySqlCommand("Update sss Set soru=@soru,soruEN=@soruEN,cevap=@cevap,sira=@sira Where Id='" + Request.QueryString["Id"] + "'", baglanti);
            komut.Parameters.Add("@soru", TextBox1.Text); komut.Parameters.Add("@soruEN", Ingilizce); komut.Parameters.Add("@cevap", TextBox2.Text); komut.Parameters.Add("@sira", TextBox3.Text);
            komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
            komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Soru Düzeltmesi Yaptı");
            komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("sssduzenle.aspx?Id=" + Request.QueryString["Id"]);
        }
    }
}