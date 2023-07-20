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
    public partial class ik : System.Web.UI.Page
    {
        public string kontrol;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null)
            {
                MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("Select * from ik", baglanti); DataTable dt = new DataTable();
                da.Fill(dt); if (dt.Rows.Count == 0) { kontrol = "yok"; } else { kontrol = "var"; }
                CollSayfala.DataSource = dt.DefaultView; CollSayfala.BindToControl = RptSirala; RptSirala.DataSource = CollSayfala.DataSourcePaged; RptSirala.DataBind();
                dt.Dispose(); baglanti.Close();
            }
            else { Response.Redirect("login.aspx"); }
        }
    }
}