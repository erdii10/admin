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
    public partial class zaman : System.Web.UI.Page
    {
        public string kontrol, sayi;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null)
            {
                MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("Select Id,katId,sira,baslik,baslikEN from timer Where katId='0' order by sira", baglanti); DataTable dt = new DataTable();
                da.Fill(dt); if (dt.Rows.Count == 0) { kontrol = "yok"; sayi = "0"; } else { kontrol = "var"; sayi = dt.Rows.Count.ToString(); }
                CollSayfala.DataSource = dt.DefaultView; CollSayfala.BindToControl = RptSirala; RptSirala.DataSource = CollSayfala.DataSourcePaged; RptSirala.DataBind();
                dt.Dispose(); baglanti.Close();
            }
            else { Response.Redirect("login.aspx"); }
        }
    }
}