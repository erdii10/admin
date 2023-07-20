using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admin
{
    public partial class Skin : System.Web.UI.MasterPage
    {
        public string resim,resimkontrol, icerikgos, habergos, sssgos, zamangos, videogos, elistegos, anketgos, galerigos, ikgos, slidergos, kullanicigos, iletisimgos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] == "9000")
            {
                lbladsoyad.Text = "Erdi Polat"; resimkontrol = "yok"; icerikgos = "1"; habergos = "1"; sssgos = "1"; zamangos = "1"; videogos = "1"; elistegos = "1"; anketgos = "1"; galerigos = "1"; ikgos = "1"; slidergos = "1"; kullanicigos = "1"; iletisimgos = "1";
            }
            else if (Session["Id"] != null && Session["Id"] != " ")
            {
                MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                MySqlCommand komut = new MySqlCommand("Select * from users where Id='" + Session["Id"] + "'", baglanti);
                MySqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    resimkontrol = "var"; lbladsoyad.Text = dr["adsoyad"].ToString(); resim = dr["resim"].ToString();
                    if (dr["icerikler"].ToString() == "1") { icerikgos = "1"; } else { icerikgos = "0"; }
                    if (dr["haberler"].ToString() == "1") { habergos = "1"; } else { habergos = "0"; }
                    if (dr["sss"].ToString() == "1") { sssgos = "1"; } else { sssgos = "0"; }
                    if (dr["zaman"].ToString() == "1") { zamangos = "1"; } else { zamangos = "0"; }
                    if (dr["video"].ToString() == "1") { videogos = "1"; } else { videogos = "0"; }
                    if (dr["eliste"].ToString() == "1") { elistegos = "1"; } else { elistegos = "0"; }
                    if (dr["anket"].ToString() == "1") { anketgos = "1"; } else { anketgos = "0"; }
                    if (dr["galeri"].ToString() == "1") { galerigos = "1"; } else { galerigos = "0"; }
                    if (dr["ik"].ToString() == "1") { ikgos = "1"; } else { ikgos = "0"; }
                    if (dr["slider"].ToString() == "1") { slidergos = "1"; } else { slidergos = "0"; }
                    if (dr["kullanicilar"].ToString() == "1") { kullanicigos = "1"; } else { kullanicigos = "0"; }
                    if (dr["iletisim"].ToString() == "1") { iletisimgos = "1"; } else { iletisimgos = "0"; }
                    dr.Dispose(); baglanti.Close();
                }
                else
                {
                    dr.Dispose(); baglanti.Close();
                }
            }
            else if (Session["Id"] == null && Session["Id"] == " ")
            {
                lbladsoyad.Text = "Yetkisiz Kişi"; resimkontrol = "yok"; icerikgos = "0"; habergos = "0"; sssgos = "0"; zamangos = "0"; videogos = "0"; elistegos = "0"; anketgos = "0"; galerigos = "0"; ikgos = "0"; slidergos = "0"; kullanicigos = "0"; iletisimgos = "0";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon(); Response.Redirect("login.aspx");
        }
    }
}