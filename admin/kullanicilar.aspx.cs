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
    public partial class kullanicilar : System.Web.UI.Page
    {
        public string kontrol, sayi, yetki;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] == "9000")
            {
                MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("Select Id,adsoyad from users", baglanti); DataTable dt = new DataTable(); da.Fill(dt);
                if (dt.Rows.Count == 0) { kontrol = "yok"; sayi = "0"; } else { kontrol = "var"; sayi = dt.Rows.Count.ToString(); }
                CollSayfala.DataSource = dt.DefaultView; CollSayfala.BindToControl = RptSirala; RptSirala.DataSource = CollSayfala.DataSourcePaged; RptSirala.DataBind();
                dt.Dispose(); baglanti.Close(); yetki = "var";
            }
            else if (Session["Id"] != null && Session["Id"] != "9000")
            {
                MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("Select Id,kullanicilar from users where Id='" + Session["Id"] + "'", baglanti); DataTable dt = new DataTable(); da.Fill(dt);
                if (dt.Rows[0]["kullanicilar"].ToString() == "1")
                {
                    da.SelectCommand.CommandText = "Select Id,adsoyad from users"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                    if (dt.Rows.Count == 0) { kontrol = "yok"; sayi = "0"; } else { kontrol = "var"; sayi = dt.Rows.Count.ToString(); }
                    CollSayfala.DataSource = dt.DefaultView; CollSayfala.BindToControl = RptSirala; RptSirala.DataSource = CollSayfala.DataSourcePaged; RptSirala.DataBind();
                    dt.Dispose(); baglanti.Close(); yetki = "var";
                }
                else if (dt.Rows[0]["kullanicilar"].ToString() == "0")
                {
                    yetki = "yok"; dt.Dispose(); baglanti.Close();
                }
            }
            else { Response.Redirect("login.aspx"); }
        }
    }
}