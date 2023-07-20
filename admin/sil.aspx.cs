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
    public partial class sil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                /*İçerik Kategoriyi Siler*/
                if (Request.QueryString["kategori"] == "IcerikKat")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,resim from contents Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    if (dt.Rows[0]["resim"].ToString() == "")
                    {
                        da.SelectCommand.CommandText = "DELETE FROM contents Where Id='" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "İçerik Kategori Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("icerikler.aspx");
                    }
                    else
                    {
                        System.IO.File.Delete(Server.MapPath("/img/contents/") + dt.Rows[0]["resim"].ToString());
                        da.SelectCommand.CommandText = "DELETE FROM contents Where Id='" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "İçerik Kategori Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("icerikler.aspx");
                    }
                }
                /*içeriği Siler*/
                else if (Request.QueryString["kategori"] == "AltIcerik")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select katid FROM contents Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt); string katid = dt.Rows[0]["katid"].ToString();
                    da.SelectCommand.CommandText = "DELETE FROM contents Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                    da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                    da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "İçerik Silindi");
                    dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("icerikduzenle.aspx?Id=" + katid);
                }
                /*İçerik Kategori Resmini Siler*/
                else if (Request.QueryString["kategori"] == "IcerikKatResim")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,resim from contents Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    System.IO.File.Delete(Server.MapPath("/img/contents/") + dt.Rows[0]["resim"].ToString());
                    MySqlCommand komut = new MySqlCommand("Update contents Set resim=@resim Where Id='" + Request.QueryString["Id"] + "'", baglanti); dt.Dispose(); komut.Parameters.Add("@resim", "");
                    komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                    komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "İçerik Kategori Resmi Silindi");
                    komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("icerikduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                /*İçerik Resmini Siler*/
                else if (Request.QueryString["kategori"] == "IcerikResim")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,resim,katid from contentsimage Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt); string katid = dt.Rows[0]["katid"].ToString();
                    if (dt.Rows[0]["resim"].ToString() == "")
                    {
                        da.SelectCommand.CommandText = "DELETE FROM contentsimage Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "İçerik Resim Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("icerikduzenle.aspx?Id=" + katid);
                    }
                    else
                    {
                        System.IO.File.Delete(Server.MapPath("/img/contents/") + dt.Rows[0]["resim"].ToString());
                        da.SelectCommand.CommandText = "DELETE FROM contentsimage Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "İçerik Resim Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("icerikduzenle.aspx?Id=" + katid);
                    }
                }
                /*İçerikiği Resim Düzenleme Sayfasında Bulunan Resmi Siler*/
                else if (Request.QueryString["kategori"] == "IcerikResimDuzenle")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select resim from contentsimage Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    System.IO.File.Delete(Server.MapPath("/img/contents/") + dt.Rows[0]["resim"].ToString());
                    MySqlCommand komut = new MySqlCommand("Update contentsimage Set resim=@resim Where Id='" + Request.QueryString["Id"] + "'", baglanti); dt.Dispose(); komut.Parameters.Add("@resim", "");
                    komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                    komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Sadece İçerik Resmi Silindi");
                    komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("icerikresimduzenle.aspx?Id=" + Request.QueryString["Id"] + "&kategori=" + Request.QueryString["kategori"] + "");
                }
                /*içerik Dosyasını Siler*/
                else if (Request.QueryString["kategori"] == "IcerikDosya")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,yolu,turu,boyutu,katid from contentsfile Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt); string katid = dt.Rows[0]["katid"].ToString();
                    if (dt.Rows[0]["yolu"].ToString() == "" && dt.Rows[0]["turu"].ToString() == "" & dt.Rows[0]["boyutu"].ToString() == "")
                    {
                        da.SelectCommand.CommandText = "DELETE FROM contentsfile Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "İçerik Dosya Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("icerikduzenle.aspx?Id=" + katid);
                    }
                    else
                    {
                        System.IO.File.Delete(Server.MapPath("/file/contents/") + dt.Rows[0]["yolu"].ToString());
                        da.SelectCommand.CommandText = "DELETE FROM contentsfile Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "içerik Dosya Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("icerikduzenle.aspx?Id=" + katid);
                    }
                }
                /*İçeriğin Dosya Düzenleme Sayfasındaki Dosyayı Siler*/
                else if (Request.QueryString["kategori"] == "IcerikDosyaDuzenle")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select yolu from contentsfile Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    System.IO.File.Delete(Server.MapPath("/file/contents/") + dt.Rows[0]["yolu"].ToString());
                    MySqlCommand komut = new MySqlCommand("Update contentsfile Set yolu=@yolu,turu=@turu,boyutu=@boyutu Where Id='" + Request.QueryString["Id"] + "'", baglanti); dt.Dispose();
                    komut.Parameters.Add("@yolu", ""); komut.Parameters.Add("@turu", ""); komut.Parameters.Add("@boyutu", ""); komut.ExecuteNonQuery();
                    komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                    komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "İçerik Dosya Eki Silindi");
                    komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("icerikdosyaduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                /*Haber Kategoriyi Siler*/
                else if (Request.QueryString["kategori"] == "HaberKat")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("DELETE FROM news Where Id = '" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                    da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Haber Kategori Silindi");
                    dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("haberler.aspx");
                }
                /*Haberi Siler*/
                else if (Request.QueryString["kategori"] == "Haber")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select katid FROM news Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt); string katid = dt.Rows[0]["katid"].ToString();
                    da.SelectCommand.CommandText = "DELETE FROM news Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                    da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                    da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Haber Silindi");
                    dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("haberduzenle.aspx?Id=" + katid);
                }
                /*Haber Resmini Siler*/
                else if (Request.QueryString["kategori"] == "HaberResim")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,resim,katid from newsimage Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt); string katid = dt.Rows[0]["katid"].ToString();
                    if (dt.Rows[0]["resim"].ToString() == "")
                    {
                        da.SelectCommand.CommandText = "DELETE FROM newsimage Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Haber Resim Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("haberduzenle.aspx?Id=" + katid);
                    }
                    else
                    {
                        System.IO.File.Delete(Server.MapPath("/img/news/") + dt.Rows[0]["resim"].ToString());
                        da.SelectCommand.CommandText = "DELETE FROM newsimage Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Haber Resim Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("haberduzenle.aspx?Id=" + katid);
                    }
                }
                /*Haberin Resim Düzenleme Sayfasında Bulunan Resmi Siler*/
                else if (Request.QueryString["kategori"] == "HaberResimDuzenle")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select resim from newsimage Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    System.IO.File.Delete(Server.MapPath("/img/news/") + dt.Rows[0]["resim"].ToString());
                    MySqlCommand komut = new MySqlCommand("Update newsimage Set resim=@resim Where Id='" + Request.QueryString["Id"] + "'", baglanti); dt.Dispose(); komut.Parameters.Add("@resim", "");
                    komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                    komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Sadece Haber Resmi Silindi");
                    komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("haberresimduzenle.aspx?Id=" + Request.QueryString["Id"] + "&kategori=" + Request.QueryString["kategori"] + "");
                }
                /*Haber Dosyasını Siler*/
                else if (Request.QueryString["kategori"] == "HaberDosya")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,yolu,turu,boyutu,katid from newsfile Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt); string katid = dt.Rows[0]["katid"].ToString();
                    if (dt.Rows[0]["yolu"].ToString() == "" && dt.Rows[0]["turu"].ToString() == "" & dt.Rows[0]["boyutu"].ToString() == "")
                    {
                        da.SelectCommand.CommandText = "DELETE FROM newsfile Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Haber Dosya Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("haberduzenle.aspx?Id=" + katid);
                    }
                    else
                    {
                        System.IO.File.Delete(Server.MapPath("/file/news/") + dt.Rows[0]["yolu"].ToString());
                        da.SelectCommand.CommandText = "DELETE FROM newsfile Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Haber Dosya Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("haberduzenle.aspx?Id=" + katid);
                    }
                }
                /*Haberin Dosya Düzenleme Sayfasındaki Dosyayı Siler*/
                else if (Request.QueryString["kategori"] == "HaberDosyaDuzenle")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select yolu from newsfile Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    System.IO.File.Delete(Server.MapPath("/file/news/") + dt.Rows[0]["yolu"].ToString());
                    MySqlCommand komut = new MySqlCommand("Update newsfile Set yolu=@yolu,turu=@turu,boyutu=@boyutu Where Id='" + Request.QueryString["Id"] + "'", baglanti); dt.Dispose();
                    komut.Parameters.Add("@yolu", ""); komut.Parameters.Add("@turu", ""); komut.Parameters.Add("@boyutu", ""); komut.ExecuteNonQuery();
                    komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                    komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Haber Dosya Eki Silindi");
                    komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("haberdosyaduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                /*Soru Siler*/
                else if (Request.QueryString["kategori"] == "Soru")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("DELETE FROM sss Where Id = '" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                    da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Soru Silindi");
                    dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("sss.aspx");
                }
                /*Kullanıcı Siler*/
                else if (Request.QueryString["kategori"] == "Profil")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,resim from users Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    if (Session["Id"].ToString() == Request.QueryString["Id"].ToString())
                    {
                        dt.Dispose(); baglanti.Close(); Response.Redirect("kullanicilar.aspx");
                    }
                    else
                    {
                        if (dt.Rows[0]["resim"].ToString() == "")
                        {
                            da.SelectCommand.CommandText = "DELETE FROM users Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                            da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                            da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Kullanıcı Silindi");
                            dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("kullanicilar.aspx");
                        }
                        else
                        {
                            System.IO.File.Delete(Server.MapPath("/img/profile/") + dt.Rows[0]["resim"].ToString());
                            da.SelectCommand.CommandText = "DELETE FROM users Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                            da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                            da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Kullanıcı Silindi");
                            dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("kullanicilar.aspx");
                        }
                    }
                }
                /*Kullanıcıya Ait Resmi Siler*/
                else if (Request.QueryString["kategori"] == "ProfilResim")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select resim from users Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    System.IO.File.Delete(Server.MapPath("/img/profile/") + dt.Rows[0]["resim"].ToString());
                    MySqlCommand komut = new MySqlCommand("Update users Set resim=@resim Where Id='" + Request.QueryString["Id"] + "'", baglanti); dt.Dispose(); komut.Parameters.Add("@resim", "");
                    komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                    komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Sadece Profil Resmi Silindi");
                    komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("kullaniciduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                /*Zamanlanmış Kategoriyi Siler*/
                else if (Request.QueryString["kategori"] == "ZamanKat")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("DELETE FROM timer Where Id = '" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                    da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Zamanlanmış Kategori Silindi");
                    dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("zaman.aspx");
                }
                /*Zamanlanmış Görevi Siler*/
                else if (Request.QueryString["kategori"] == "Zaman")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,resim,katid from timer Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt); string katid = dt.Rows[0]["katid"].ToString();
                    if (dt.Rows[0]["resim"].ToString() == "")
                    {
                        da.SelectCommand.CommandText = "DELETE FROM timer Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Zamanlanmış Görev Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("zamanduzenle.aspx?Id=" + katid);
                    }
                    else
                    {
                        System.IO.File.Delete(Server.MapPath("/img/timer/") + dt.Rows[0]["resim"].ToString());
                        da.SelectCommand.CommandText = "DELETE FROM timer Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Zamanlanmış Görev Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("zamanduzenle.aspx?Id=" + katid);
                    }
                }
                /*Zamanlanmış Görev Resmini Siler*/
                else if (Request.QueryString["kategori"] == "ZamanResim")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,resim from timer Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    System.IO.File.Delete(Server.MapPath("/img/timer/") + dt.Rows[0]["resim"].ToString());
                    MySqlCommand komut = new MySqlCommand("Update timer Set resim=@resim Where Id='" + Request.QueryString["Id"] + "'", baglanti); dt.Dispose(); komut.Parameters.Add("@resim", "");
                    komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                    komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Göreve Ait Resim Silindi");
                    komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("zamanduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                /*Video Kategoriyi Siler*/
                else if (Request.QueryString["kategori"] == "VideoKat")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("DELETE FROM video Where Id = '" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                    da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Video Kategori Silindi");
                    dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("videolar.aspx");
                }
                /*Video Siler*/
                else if (Request.QueryString["kategori"] == "Video")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,katid from video Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt); string katid = dt.Rows[0]["katid"].ToString();
                    da.SelectCommand.CommandText = "DELETE FROM video Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                    da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                    da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Video Silindi");
                    dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("videoduzenle.aspx?Id=" + katid);
                }
                /*e-Liste Siler*/
                else if (Request.QueryString["kategori"] == "Eliste")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("DELETE FROM elist Where Id = '" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                    da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "E-Liste Silindi");
                    dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("eliste.aspx");
                }
                /*Anket Siler*/
                else if (Request.QueryString["kategori"] == "Anket")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("DELETE FROM survey Where Id = '" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                    da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Anket Silindi");
                    dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("anketler.aspx");
                }
                /*Seçenek Siler*/
                else if (Request.QueryString["kategori"] == "Secenek")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,katid from survey Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt); string katid = dt.Rows[0]["katid"].ToString();
                    da.SelectCommand.CommandText = "DELETE FROM survey Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                    da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                    da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Seçenek Silindi");
                    dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("anketduzenle.aspx?Id=" + katid);
                }
                /*Galeri Kategorisi Siler*/
                else if (Request.QueryString["kategori"] == "GaleriKat")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,resim,katid from gallery Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    if (dt.Rows[0]["resim"].ToString() == "")
                    {
                        da.SelectCommand.CommandText = "DELETE FROM gallery Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Galeri Kategorisi Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("galeri.aspx");
                    }
                    else
                    {
                        System.IO.File.Delete(Server.MapPath("/img/gallery/") + dt.Rows[0]["resim"].ToString());
                        da.SelectCommand.CommandText = "DELETE FROM gallery Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Galeri Kategorisi Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("galeri.aspx");
                    }
                }
                /*Galeri Kategorisi Resmi Siler*/
                else if (Request.QueryString["kategori"] == "GaleriKatResim")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,resim from gallery Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    System.IO.File.Delete(Server.MapPath("/img/gallery/") + dt.Rows[0]["resim"].ToString());
                    MySqlCommand komut = new MySqlCommand("Update gallery Set resim=@resim Where Id='" + Request.QueryString["Id"] + "'", baglanti); dt.Dispose(); komut.Parameters.Add("@resim", "");
                    komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                    komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Galeri Kategori Resmi Silindi");
                    komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("galeriduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                /*Galeri Siler*/
                else if (Request.QueryString["kategori"] == "Galeri")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,resim,katid from gallery Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt); string katid = dt.Rows[0]["katid"].ToString();
                    if (dt.Rows[0]["resim"].ToString() == "")
                    {
                        da.SelectCommand.CommandText = "DELETE FROM gallery Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Galeri Kategorisi Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("galeriduzenle.aspx?Id=" + katid);
                    }
                    else
                    {
                        System.IO.File.Delete(Server.MapPath("/img/gallery/") + dt.Rows[0]["resim"].ToString());
                        da.SelectCommand.CommandText = "DELETE FROM gallery Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Galeri Kategorisi Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("galeriduzenle.aspx?Id=" + katid);
                    }
                }
                /*Sadece Galeri Resmi Siler*/
                else if (Request.QueryString["kategori"] == "GaleriResim")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select resim from gallery Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    System.IO.File.Delete(Server.MapPath("/img/gallery/") + dt.Rows[0]["resim"].ToString());
                    MySqlCommand komut = new MySqlCommand("Update gallery Set resim=@resim Where Id='" + Request.QueryString["Id"] + "'", baglanti); dt.Dispose(); komut.Parameters.Add("@resim", "");
                    komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                    komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Sadece Galeri Resmi Silindi");
                    komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("galeriduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                /*Ik Siler*/
                else if (Request.QueryString["kategori"] == "Ik")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("DELETE FROM ik Where Id = '" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                    da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "İk Başvuru Silindi");
                    dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("ik.aspx");
                }
                /*Slider Kategoriyi Siler*/
                else if (Request.QueryString["kategori"] == "SliderKat")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("DELETE FROM slider Where Id = '" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                    da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Slider Kategori Silindi");
                    dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("slider.aspx");
                }
                /*Slider Siler*/
                else if (Request.QueryString["kategori"] == "Slider")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select Id,resim,katid from slider Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt); string katid = dt.Rows[0]["katid"].ToString();
                    if (dt.Rows[0]["resim"].ToString() == "")
                    {
                        da.SelectCommand.CommandText = "DELETE FROM slider Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Slider Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("sliderduzenle.aspx?Id=" + katid);
                    }
                    else
                    {
                        System.IO.File.Delete(Server.MapPath("/img/slider/") + dt.Rows[0]["resim"].ToString());
                        da.SelectCommand.CommandText = "DELETE FROM slider Where Id = '" + Request.QueryString["Id"] + "'"; dt.Dispose(); dt = new DataTable(); da.Fill(dt);
                        da.SelectCommand.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; dt.Dispose();
                        da.SelectCommand.Parameters.AddWithValue("@personelid", Session["Id"]); da.SelectCommand.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); da.SelectCommand.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); da.SelectCommand.Parameters.AddWithValue("@durum", "Slider Silindi");
                        dt = new DataTable(); da.Fill(dt); dt.Dispose(); baglanti.Close(); Response.Redirect("sliderduzenle.aspx?Id=" + katid);
                    }
                }
                /*Sadece Slider Resmi Siler*/
                else if (Request.QueryString["kategori"] == "SliderResim")
                {
                    MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("Select resim from slider Where Id='" + Request.QueryString["Id"] + "'", baglanti);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    System.IO.File.Delete(Server.MapPath("/img/slider/") + dt.Rows[0]["resim"].ToString());
                    MySqlCommand komut = new MySqlCommand("Update slider Set resim=@resim Where Id='" + Request.QueryString["Id"] + "'", baglanti); dt.Dispose(); komut.Parameters.Add("@resim", "");
                    komut.ExecuteNonQuery(); komut.CommandText = "Insert into logs(personelid,ipadres,bagzamani,durum) Values(@personelid,@ipadres,@bagzamani,@durum)"; komut.Dispose();
                    komut.Parameters.AddWithValue("@personelid", Session["Id"]); komut.Parameters.AddWithValue("@ipadres", HttpContext.Current.Request.UserHostAddress); komut.Parameters.AddWithValue("@bagzamani", DateTime.Now.ToString()); komut.Parameters.AddWithValue("@durum", "Sadece Slider Resmi Silindi");
                    komut.ExecuteNonQuery(); komut.Dispose(); baglanti.Close(); Response.Redirect("sliderduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}