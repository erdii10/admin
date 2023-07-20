using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Mail;

namespace admin
{
    public partial class elistegonder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] == null) { Response.Redirect("login.aspx"); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MailMessage msg = new MailMessage(); //Mesaj gövdesini tanımlıyoruz...
            msg.Subject = TextBox1.Text + " | Erdi POLAT Admin";
            msg.From = new MailAddress("erdipolat@outlook.com", "Erdi POLAT");
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
            MySqlCommand komut = new MySqlCommand("Select * from elist", baglanti); MySqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) { msg.To.Add(new MailAddress(dr["eposta"].ToString(), dr["adsoyad"].ToString())); }

            //Mesaj içeriğinde HTML karakterler yer alıyor ise aşağıdaki alan TRUE olarak gönderilmeli ki HTML olarak yorumlansın. Yoksa düz yazı olarak gönderilir...
            msg.IsBodyHtml = true;
            msg.Body = TextBox2.Text;
            //SMTP/Gönderici bilgilerinin yer aldığı erişim/doğrulama bilgileri
            SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587); //Bu alanda gönderim yapacak hizmetin smtp adresini ve size verilen portu girmelisiniz.
            NetworkCredential AccountInfo = new NetworkCredential("erdipolat@outlook.com", "erdi123.");
            smtp.UseDefaultCredentials = false; //Standart doğrulama kullanılsın mı? -> Yalnızca gönderici özellikle istiyor ise TRUE işaretlenir.
            smtp.Credentials = AccountInfo;
            smtp.EnableSsl = true; //SSL kullanılarak mı gönderilsin...

            smtp.Send(msg); dr.Dispose(); baglanti.Close(); Response.Redirect("eliste.aspx");
        }
    }
}