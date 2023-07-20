using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace admin
{
    public partial class iletisim : System.Web.UI.Page
    {
        public string harita, en, boy;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null)
            {
                MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from contact", baglanti);
                MySqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    if (!Page.IsPostBack)
                    {
                        harita = dr["harita"].ToString(); en = dr["en"].ToString(); boy = dr["boy"].ToString();
                        TextBox1.Text = dr["harita"].ToString(); TextBox2.Text = dr["en"].ToString(); TextBox3.Text = dr["boy"].ToString(); TextBox4.Text = dr["adres"].ToString(); TextBox5.Text = dr["telefon"].ToString(); TextBox6.Text = dr["eposta"].ToString();
                        dr.Dispose(); baglanti.Close();
                    }
                }
            }
            else { Response.Redirect("login.aspx"); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
            MySqlCommand komut = new MySqlCommand("Update contact Set harita=@harita,en=@en,boy=@boy,adres=@adres,telefon=@telefon,eposta=@eposta", baglanti);
            komut.Parameters.Add("@harita", TextBox1.Text); komut.Parameters.Add("@en", TextBox2.Text); komut.Parameters.Add("@boy", TextBox3.Text); komut.Parameters.Add("@adres", TextBox4.Text); komut.Parameters.Add("@telefon", TextBox5.Text); komut.Parameters.Add("@eposta", TextBox6.Text);
            komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
            komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "İletişim Düzeltme Yaptı");
            komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("iletisim.aspx");
        }
    }
}