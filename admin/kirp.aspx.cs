using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Drawing2D;
using System.IO;

namespace admin
{
    public partial class kirp : System.Web.UI.Page
    {
        static byte[] CropImage(string sImagePath, int iWidth, int iHeight, int iX, int iY)
        {
            try
            {
                using (System.Drawing.Image oOriginalImage = System.Drawing.Image.FromFile(sImagePath))
                {
                    using (System.Drawing.Bitmap oBitmap = new System.Drawing.Bitmap(iWidth, iHeight))
                    {
                        oBitmap.SetResolution(oOriginalImage.HorizontalResolution, oOriginalImage.VerticalResolution);
                        using (System.Drawing.Graphics Graphic = System.Drawing.Graphics.FromImage(oBitmap))
                        {
                            Graphic.SmoothingMode = SmoothingMode.AntiAlias;
                            Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            Graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            Graphic.DrawImage(oOriginalImage, new System.Drawing.Rectangle(0, 0, iWidth, iHeight), iX, iY, iWidth, iHeight, System.Drawing.GraphicsUnit.Pixel);
                            MemoryStream oMemoryStream = new MemoryStream();
                            oBitmap.Save(oMemoryStream, oOriginalImage.RawFormat);
                            return oMemoryStream.GetBuffer();
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        private string m_sImageNameUserUpload = "";
        public int en, boy, genelen, genelboy;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] == null) { Response.Redirect("login.aspx"); }
            else
            {
                imgCrop.ImageUrl = "/img/" + Request.QueryString["resimadi"];
                if (Request.QueryString["kategori"] == "IcerikKat")
                {
                    en = 355; boy = 270; genelen = 1024; genelboy = 768;
                }
                else if (Request.QueryString["kategori"] == "Icerik")
                {
                    en = 355; boy = 270; genelen = 1024; genelboy = 768;
                }
                else if (Request.QueryString["kategori"] == "IcerikResimDuzenle")
                {
                    en = 1000; boy = 400; genelen = 1024; genelboy = 768;
                }
                else if (Request.QueryString["kategori"] == "IcerikResimEkle")
                {
                    en = 1000; boy = 400; genelen = 1024; genelboy = 768;
                }
                else if (Request.QueryString["kategori"] == "Haber")
                {
                    en = 355; boy = 270; genelen = 1024; genelboy = 768;
                }
                else if (Request.QueryString["kategori"] == "HaberResimDuzenle")
                {
                    en = 1000; boy = 400; genelen = 1024; genelboy = 768;
                }
                else if (Request.QueryString["kategori"] == "HaberResimEkle")
                {
                    en = 1000; boy = 400; genelen = 1024; genelboy = 768;
                }
                else if (Request.QueryString["kategori"] == "ProfilEkle")
                {
                    en = 44; boy = 41; genelen = 350; genelboy = 326;
                }
                else if (Request.QueryString["kategori"] == "ProfilDuzenle")
                {
                    en = 44; boy = 41; genelen = 350; genelboy = 326;
                }
                else if (Request.QueryString["kategori"] == "Gorev")
                {
                    en = 1024; boy = 768; genelen = 2048; genelboy = 1536;
                }
                else if (Request.QueryString["kategori"] == "GaleriKat")
                {
                    en = 1024; boy = 768; genelen = 2048; genelboy = 1536;
                }
                else if (Request.QueryString["kategori"] == "Galeri")
                {
                    en = 1024; boy = 768; genelen = 2048; genelboy = 1536;
                }
                else if (Request.QueryString["kategori"] == "GaleriDuzelt")
                {
                    en = 1024; boy = 768; genelen = 2048; genelboy = 1536;
                }
                else if (Request.QueryString["kategori"] == "SliderEkle")
                {
                    en = 1024; boy = 768; genelen = 2048; genelboy = 1536;
                }
                else if (Request.QueryString["kategori"] == "SliderDuzelt")
                {
                    en = 1024; boy = 768; genelen = 2048; genelboy = 1536;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (hdnW.Value != "")
            {
                string sImagePathImages = Server.MapPath("/img/");
                m_sImageNameUserUpload = Request.QueryString["resimadi"];
                // Get Width, Height, X & Y coordinates from hidden field which gets value when you select an area to crop.
                int iWidth = Convert.ToInt32(hdnW.Value);
                int iHeight = Convert.ToInt32(hdnH.Value);
                int iXCoord = Convert.ToInt32(hdnX.Value);
                int iYCoord = Convert.ToInt32(hdnY.Value);
                //Call CropImage method defined below
                if (Request.QueryString["kategori"] == "IcerikKat")
                {
                    byte[] byt_CropImage = CropImage(sImagePathImages + m_sImageNameUserUpload, iWidth, iHeight, iXCoord, iYCoord);
                    using (MemoryStream oMemoryStream = new MemoryStream(byt_CropImage, 0, byt_CropImage.Length))
                    {
                        oMemoryStream.Write(byt_CropImage, 0, byt_CropImage.Length);
                        using (System.Drawing.Image oCroppedImage = System.Drawing.Image.FromStream(oMemoryStream, true))
                        {
                            string sSaveTo = sImagePathImages + "/contents/" + m_sImageNameUserUpload;
                            oCroppedImage.Save(sSaveTo, oCroppedImage.RawFormat);
                        }
                    }
                    File.Delete(MapPath("/img/" + m_sImageNameUserUpload));
                    Response.Redirect("icerikler.aspx");
                }
                else if (Request.QueryString["kategori"] == "Icerik")
                {
                    
                    byte[] byt_CropImage = CropImage(sImagePathImages + m_sImageNameUserUpload, iWidth, iHeight, iXCoord, iYCoord);
                    using (MemoryStream oMemoryStream = new MemoryStream(byt_CropImage, 0, byt_CropImage.Length))
                    {
                        oMemoryStream.Write(byt_CropImage, 0, byt_CropImage.Length);
                        using (System.Drawing.Image oCroppedImage = System.Drawing.Image.FromStream(oMemoryStream, true))
                        {
                            string sSaveTo = sImagePathImages + "/contents/" + m_sImageNameUserUpload;
                            oCroppedImage.Save(sSaveTo, oCroppedImage.RawFormat);
                        }
                    }
                    File.Delete(MapPath("/img/" + m_sImageNameUserUpload));
                    Response.Redirect("icerikduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                else if (Request.QueryString["kategori"] == "IcerikResimDuzenle")
                {
                    
                    byte[] byt_CropImage = CropImage(sImagePathImages + m_sImageNameUserUpload, iWidth, iHeight, iXCoord, iYCoord);
                    using (MemoryStream oMemoryStream = new MemoryStream(byt_CropImage, 0, byt_CropImage.Length))
                    {
                        oMemoryStream.Write(byt_CropImage, 0, byt_CropImage.Length);
                        using (System.Drawing.Image oCroppedImage = System.Drawing.Image.FromStream(oMemoryStream, true))
                        {
                            string sSaveTo = sImagePathImages + "/contents/" + m_sImageNameUserUpload;
                            oCroppedImage.Save(sSaveTo, oCroppedImage.RawFormat);
                        }
                    }
                    File.Delete(MapPath("/img/" + m_sImageNameUserUpload));
                    Response.Redirect("icerikresimduzenle.aspx?Id=" + Request.QueryString["Id"] + "&kategori=" + Request.QueryString["kategori"] + "");
                }
                else if (Request.QueryString["kategori"] == "IcerikResimEkle")
                {
                    
                    byte[] byt_CropImage = CropImage(sImagePathImages + m_sImageNameUserUpload, iWidth, iHeight, iXCoord, iYCoord);
                    using (MemoryStream oMemoryStream = new MemoryStream(byt_CropImage, 0, byt_CropImage.Length))
                    {
                        oMemoryStream.Write(byt_CropImage, 0, byt_CropImage.Length);
                        using (System.Drawing.Image oCroppedImage = System.Drawing.Image.FromStream(oMemoryStream, true))
                        {
                            string sSaveTo = sImagePathImages + "/contents/" + m_sImageNameUserUpload;
                            oCroppedImage.Save(sSaveTo, oCroppedImage.RawFormat);
                        }
                    }
                    File.Delete(MapPath("/img/" + m_sImageNameUserUpload));
                    Response.Redirect("icerikduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                else if (Request.QueryString["kategori"] == "Haber")
                {

                    byte[] byt_CropImage = CropImage(sImagePathImages + m_sImageNameUserUpload, iWidth, iHeight, iXCoord, iYCoord);
                    using (MemoryStream oMemoryStream = new MemoryStream(byt_CropImage, 0, byt_CropImage.Length))
                    {
                        oMemoryStream.Write(byt_CropImage, 0, byt_CropImage.Length);
                        using (System.Drawing.Image oCroppedImage = System.Drawing.Image.FromStream(oMemoryStream, true))
                        {
                            string sSaveTo = sImagePathImages + "/news/" + m_sImageNameUserUpload;
                            oCroppedImage.Save(sSaveTo, oCroppedImage.RawFormat);
                        }
                    }
                    File.Delete(MapPath("/img/" + m_sImageNameUserUpload));
                    Response.Redirect("haberduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                else if (Request.QueryString["kategori"] == "HaberResimDuzenle")
                {

                    byte[] byt_CropImage = CropImage(sImagePathImages + m_sImageNameUserUpload, iWidth, iHeight, iXCoord, iYCoord);
                    using (MemoryStream oMemoryStream = new MemoryStream(byt_CropImage, 0, byt_CropImage.Length))
                    {
                        oMemoryStream.Write(byt_CropImage, 0, byt_CropImage.Length);
                        using (System.Drawing.Image oCroppedImage = System.Drawing.Image.FromStream(oMemoryStream, true))
                        {
                            string sSaveTo = sImagePathImages + "/news/" + m_sImageNameUserUpload;
                            oCroppedImage.Save(sSaveTo, oCroppedImage.RawFormat);
                        }
                    }
                    File.Delete(MapPath("/img/" + m_sImageNameUserUpload));
                    Response.Redirect("haberresimduzenle.aspx?Id=" + Request.QueryString["Id"] + "&kategori=" + Request.QueryString["kategori"] + "");
                }
                else if (Request.QueryString["kategori"] == "HaberResimEkle")
                {

                    byte[] byt_CropImage = CropImage(sImagePathImages + m_sImageNameUserUpload, iWidth, iHeight, iXCoord, iYCoord);
                    using (MemoryStream oMemoryStream = new MemoryStream(byt_CropImage, 0, byt_CropImage.Length))
                    {
                        oMemoryStream.Write(byt_CropImage, 0, byt_CropImage.Length);
                        using (System.Drawing.Image oCroppedImage = System.Drawing.Image.FromStream(oMemoryStream, true))
                        {
                            string sSaveTo = sImagePathImages + "/news/" + m_sImageNameUserUpload;
                            oCroppedImage.Save(sSaveTo, oCroppedImage.RawFormat);
                        }
                    }
                    File.Delete(MapPath("/img/" + m_sImageNameUserUpload));
                    Response.Redirect("haberduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                else if (Request.QueryString["kategori"] == "ProfilEkle")
                {

                    byte[] byt_CropImage = CropImage(sImagePathImages + m_sImageNameUserUpload, iWidth, iHeight, iXCoord, iYCoord);
                    using (MemoryStream oMemoryStream = new MemoryStream(byt_CropImage, 0, byt_CropImage.Length))
                    {
                        oMemoryStream.Write(byt_CropImage, 0, byt_CropImage.Length);
                        using (System.Drawing.Image oCroppedImage = System.Drawing.Image.FromStream(oMemoryStream, true))
                        {
                            string sSaveTo = sImagePathImages + "/profile/" + m_sImageNameUserUpload;
                            oCroppedImage.Save(sSaveTo, oCroppedImage.RawFormat);
                        }
                    }
                    File.Delete(MapPath("/img/" + m_sImageNameUserUpload));
                    Response.Redirect("kullanicilar.aspx");
                }
                else if (Request.QueryString["kategori"] == "ProfilDuzenle")
                {

                    byte[] byt_CropImage = CropImage(sImagePathImages + m_sImageNameUserUpload, iWidth, iHeight, iXCoord, iYCoord);
                    using (MemoryStream oMemoryStream = new MemoryStream(byt_CropImage, 0, byt_CropImage.Length))
                    {
                        oMemoryStream.Write(byt_CropImage, 0, byt_CropImage.Length);
                        using (System.Drawing.Image oCroppedImage = System.Drawing.Image.FromStream(oMemoryStream, true))
                        {
                            string sSaveTo = sImagePathImages + "/profile/" + m_sImageNameUserUpload;
                            oCroppedImage.Save(sSaveTo, oCroppedImage.RawFormat);
                        }
                    }
                    File.Delete(MapPath("/img/" + m_sImageNameUserUpload));
                    Response.Redirect("kullaniciduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                else if (Request.QueryString["kategori"] == "Gorev")
                {

                    byte[] byt_CropImage = CropImage(sImagePathImages + m_sImageNameUserUpload, iWidth, iHeight, iXCoord, iYCoord);
                    using (MemoryStream oMemoryStream = new MemoryStream(byt_CropImage, 0, byt_CropImage.Length))
                    {
                        oMemoryStream.Write(byt_CropImage, 0, byt_CropImage.Length);
                        using (System.Drawing.Image oCroppedImage = System.Drawing.Image.FromStream(oMemoryStream, true))
                        {
                            string sSaveTo = sImagePathImages + "/timer/" + m_sImageNameUserUpload;
                            oCroppedImage.Save(sSaveTo, oCroppedImage.RawFormat);
                        }
                    }
                    File.Delete(MapPath("/img/" + m_sImageNameUserUpload));
                    Response.Redirect("zamanduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                else if (Request.QueryString["kategori"] == "GaleriKat")
                {

                    byte[] byt_CropImage = CropImage(sImagePathImages + m_sImageNameUserUpload, iWidth, iHeight, iXCoord, iYCoord);
                    using (MemoryStream oMemoryStream = new MemoryStream(byt_CropImage, 0, byt_CropImage.Length))
                    {
                        oMemoryStream.Write(byt_CropImage, 0, byt_CropImage.Length);
                        using (System.Drawing.Image oCroppedImage = System.Drawing.Image.FromStream(oMemoryStream, true))
                        {
                            string sSaveTo = sImagePathImages + "/gallery/" + m_sImageNameUserUpload;
                            oCroppedImage.Save(sSaveTo, oCroppedImage.RawFormat);
                        }
                    }
                    File.Delete(MapPath("/img/" + m_sImageNameUserUpload));
                    Response.Redirect("galeri.aspx");
                }
                else if (Request.QueryString["kategori"] == "Galeri")
                {

                    byte[] byt_CropImage = CropImage(sImagePathImages + m_sImageNameUserUpload, iWidth, iHeight, iXCoord, iYCoord);
                    using (MemoryStream oMemoryStream = new MemoryStream(byt_CropImage, 0, byt_CropImage.Length))
                    {
                        oMemoryStream.Write(byt_CropImage, 0, byt_CropImage.Length);
                        using (System.Drawing.Image oCroppedImage = System.Drawing.Image.FromStream(oMemoryStream, true))
                        {
                            string sSaveTo = sImagePathImages + "/gallery/" + m_sImageNameUserUpload;
                            oCroppedImage.Save(sSaveTo, oCroppedImage.RawFormat);
                        }
                    }
                    File.Delete(MapPath("/img/" + m_sImageNameUserUpload));
                    Response.Redirect("galeriduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                else if (Request.QueryString["kategori"] == "GaleriDuzelt")
                {

                    byte[] byt_CropImage = CropImage(sImagePathImages + m_sImageNameUserUpload, iWidth, iHeight, iXCoord, iYCoord);
                    using (MemoryStream oMemoryStream = new MemoryStream(byt_CropImage, 0, byt_CropImage.Length))
                    {
                        oMemoryStream.Write(byt_CropImage, 0, byt_CropImage.Length);
                        using (System.Drawing.Image oCroppedImage = System.Drawing.Image.FromStream(oMemoryStream, true))
                        {
                            string sSaveTo = sImagePathImages + "/gallery/" + m_sImageNameUserUpload;
                            oCroppedImage.Save(sSaveTo, oCroppedImage.RawFormat);
                        }
                    }
                    File.Delete(MapPath("/img/" + m_sImageNameUserUpload));
                    Response.Redirect("galeriduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                else if (Request.QueryString["kategori"] == "SliderEkle")
                {

                    byte[] byt_CropImage = CropImage(sImagePathImages + m_sImageNameUserUpload, iWidth, iHeight, iXCoord, iYCoord);
                    using (MemoryStream oMemoryStream = new MemoryStream(byt_CropImage, 0, byt_CropImage.Length))
                    {
                        oMemoryStream.Write(byt_CropImage, 0, byt_CropImage.Length);
                        using (System.Drawing.Image oCroppedImage = System.Drawing.Image.FromStream(oMemoryStream, true))
                        {
                            string sSaveTo = sImagePathImages + "/slider/" + m_sImageNameUserUpload;
                            oCroppedImage.Save(sSaveTo, oCroppedImage.RawFormat);
                        }
                    }
                    File.Delete(MapPath("/img/" + m_sImageNameUserUpload));
                    Response.Redirect("sliderduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
                else if (Request.QueryString["kategori"] == "SliderDuzelt")
                {

                    byte[] byt_CropImage = CropImage(sImagePathImages + m_sImageNameUserUpload, iWidth, iHeight, iXCoord, iYCoord);
                    using (MemoryStream oMemoryStream = new MemoryStream(byt_CropImage, 0, byt_CropImage.Length))
                    {
                        oMemoryStream.Write(byt_CropImage, 0, byt_CropImage.Length);
                        using (System.Drawing.Image oCroppedImage = System.Drawing.Image.FromStream(oMemoryStream, true))
                        {
                            string sSaveTo = sImagePathImages + "/slider/" + m_sImageNameUserUpload;
                            oCroppedImage.Save(sSaveTo, oCroppedImage.RawFormat);
                        }
                    }
                    File.Delete(MapPath("/img/" + m_sImageNameUserUpload));
                    Response.Redirect("sliderduzenle.aspx?Id=" + Request.QueryString["Id"]);
                }
            }
        }
    }
}