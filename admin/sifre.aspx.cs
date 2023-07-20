using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace admin
{
    public partial class sifre : System.Web.UI.Page
    {
        private static string calculateSHA512(string str)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            SHA512CryptoServiceProvider cryptoTransformSHA512 = new SHA512CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSHA512.ComputeHash(buffer)).Replace("-", "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.AppSettings["Baglanti"]); baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select * from users Where eposta='" + TextBox1.Text + "'", baglanti); MySqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                string eposta = dr["eposta"].ToString(), adsoyad = dr["adsoyad"].ToString();
                if (TextBox2.Text == TextBox3.Text)
                {
                    komut.CommandText = "Update users Set sifre=@sifre Where eposta = '" + TextBox1.Text + "'"; komut.Dispose(); dr.Dispose();
                    komut.Parameters.Add("@sifre", calculateSHA512(TextBox3.Text)); komut.ExecuteNonQuery(); baglanti.Close();
                    MailMessage msg = new MailMessage(); //Mesaj gövdesini tanımlıyoruz...
                    msg.Subject = TextBox1.Text + " | Erdi POLAT Admin";
                    msg.From = new MailAddress("erdipolat@outlook.com", "Erdi POLAT");
                    msg.To.Add(new MailAddress(eposta, adsoyad));

                    //Mesaj içeriğinde HTML karakterler yer alıyor ise aşağıdaki alan TRUE olarak gönderilmeli ki HTML olarak yorumlansın. Yoksa düz yazı olarak gönderilir...
                    msg.IsBodyHtml = false;
                    msg.Body = "Yeni Şifreniz=" + TextBox3.Text;
                    //SMTP/Gönderici bilgilerinin yer aldığı erişim/doğrulama bilgileri
                    SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587); //Bu alanda gönderim yapacak hizmetin smtp adresini ve size verilen portu girmelisiniz.
                    NetworkCredential AccountInfo = new NetworkCredential("erdipolat@outlook.com", "erdi123.");
                    smtp.UseDefaultCredentials = false; //Standart doğrulama kullanılsın mı? -> Yalnızca gönderici özellikle istiyor ise TRUE işaretlenir.
                    smtp.Credentials = AccountInfo;
                    smtp.EnableSsl = true; //SSL kullanılarak mı gönderilsin...

                    smtp.Send(msg); Response.Redirect("login.aspx");
                }
                else
                {
                    Label1.Text = "Yazmış Olduğunuz Şifreler Aynı Değil!"; dr.Dispose(); baglanti.Close();
                }
            }
            else
            {
                Label1.Text = "E-Posta Adresiniz Doğru Değil!"; dr.Dispose(); baglanti.Close();
            }
        }
    }
}