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
    public partial class icerikresimsil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                if (Request.QueryString["kategori"] == "alticerikresim")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,resim from contents Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    System.IO.File.Delete(Server.MapPath("/img/contents/") + dt.Rows[0]["resim"].ToString());
                    MySqlCommand komut = new MySqlCommand("Update contents Set resim=@resim Where Id='" + Request.QueryString["Id"] + "'", baglanti); dt.Dispose();
                    komut.Parameters.Add("@resim", ""); komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("icerikduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                else if (Request.QueryString["kategori"] == null)
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,resim from contents Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    System.IO.File.Delete(Server.MapPath("/img/contents/") + dt.Rows[0]["resim"].ToString());
                    MySqlCommand komut = new MySqlCommand("Update contents Set resim=@resim Where Id='" + Request.QueryString["Id"] + "'", baglanti); dt.Dispose();
                    komut.Parameters.Add("@resim", ""); komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("icerikduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}