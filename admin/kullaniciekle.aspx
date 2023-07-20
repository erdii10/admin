<%@ Page Title="" Language="C#" MasterPageFile="~/Skin.Master" AutoEventWireup="true" CodeBehind="kullaniciekle.aspx.cs" Inherits="admin.kullaniciekle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link type="text/css" rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" />
<script type="text/javascript" src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
<script type="text/javascript">
     $( function() {
         $("#<%=TextBox6.ClientID%>").datepicker({
            dateFormat: "dd.mm.yy",
            //altFormat: "yy-mm-dd", Mysql kaydetme formatı
            //altField: "#tarih-db", Mysql kaydetme formatı
            changeMonth: true,//ayı elle seçmeyi aktif eder
            changeYear: true,//yılı elee seçime izin verir
            maxDate: "+5y+1m +2w",//ileri göre bilme zamanını 2 yıl 1 ay 2 hafta yaptık
            minDate: "-1y-1m -2w",//geriyi göre bilme alanını 1 yıl 1 ay 2 hafta yaptık.bunu istediğiniz gibi ayarlaya bilirsiniz
            monthNames: [ "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" ],
            dayNamesMin: [ "Pa", "Ptz", "Sa", "Ça", "Pe", "Cu", "Ct" ],
            monthNamesShort: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],//ay seçim alanın düzenledik
            nextText: "ileri",//ileri butonun türkçeleştirdik
            prevText: "geri",//buda geri butonu için
            showAnim: "fade",//takvim açılım animasyonu alta tüm animasyon isimleri yazdım 
            firstDay: 1
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="Kenar">
    <div class="UstBaslik">Kullanıcılar</div>
    <div id="IcerikTop">
        <a href="kullaniciekle.aspx" class="IcerikEkle">Kullanıcı Ekle</a>
        <a href="kullanicilar.aspx" class="IcerikListele">Kullanıcı Listele</a>
        <div class="Temizle"></div>
    </div>
    <div class="IcerikTaban">
        <div style="margin-bottom:10px; float:left;">
            <div style="float:left;">Ad Soyad :</div>
            <div style="float:left; margin-left:5px;"><asp:TextBox ID="TextBox1" CssClass="Text4" Width="85%" runat="server" MaxLength="255"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px; float:left;">
            <div style="float:left;">Firma Adı :</div>
            <div style="float:left; margin-left:5px;"><asp:TextBox ID="TextBox2" CssClass="Text4" Width="85%" runat="server" MaxLength="255"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px; float:left;">
            <div style="float:left;">E-Posta :</div>
            <div style="float:left; margin-left:5px;"><asp:TextBox ID="TextBox3" CssClass="Text4" Width="85%" runat="server" MaxLength="255"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px; float:left;">
            <div style="float:left;">Resim :</div>
            <div style="float:left; margin-left:5px;"><asp:FileUpload ID="FileUpload1" CssClass="Text4" Width="85%" runat="server"/></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px; float:left;">
            <div style="float:left;">Kullanıcı Adı :</div>
            <div style="float:left; margin-left:5px;"><asp:TextBox ID="TextBox4" CssClass="Text4" Width="85%" runat="server" MaxLength="255"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px; float:left;">
            <div style="float:left;">Şifre :</div>
            <div style="float:left; margin-left:5px;"><asp:TextBox ID="TextBox5" CssClass="Text4" Width="85%" runat="server" TextMode="Password" MaxLength="255"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px; float:left;">
            <div style="float:left;">Tarih :</div>
            <div style="float:left; margin-left:5px;"><asp:TextBox ID="TextBox6" CssClass="Text4" Width="85%" runat="server" MaxLength="10"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div class="Temizle"></div>
        <div style="margin-top:25px; height:1px; background-color:#ccc;"></div>
        <div style="margin-top:25px;">
            <div style="float:left; width:150px;">
		        <div style="float:left;"><asp:CheckBox ID="CheckBox1" runat="server" onclick="javascript:this.value=((this.checked)?'1':'0');" Text="İçerikler" /></div>
		        <div class="Temizle"></div>
	        </div>
            <div style="float:left; width:150px;">
		        <div style="float:left;"><asp:CheckBox ID="CheckBox2" runat="server" onclick="javascript:this.value=((this.checked)?'1':'0');" Text="Haberler" /></div>
		        <div class="Temizle"></div>
	        </div>
            <div style="float:left; width:150px;">
		        <div style="float:left;"><asp:CheckBox ID="CheckBox3" runat="server" onclick="javascript:this.value=((this.checked)?'1':'0');" Text="S.S.S." /></div>
		        <div class="Temizle"></div>
	        </div>
            <div style="float:left; width:150px;">
		        <div style="float:left;"><asp:CheckBox ID="CheckBox4" runat="server" onclick="javascript:this.value=((this.checked)?'1':'0');" Text="Zamanlayıcı" /></div>
		        <div class="Temizle"></div>
	        </div>
            <div style="float:left; width:150px;">
		        <div style="float:left;"><asp:CheckBox ID="CheckBox5" runat="server" onclick="javascript:this.value=((this.checked)?'1':'0');" Text="Videolar" /></div>
		        <div class="Temizle"></div>
	        </div>
            <div style="float:left; width:150px;">
		        <div style="float:left;"><asp:CheckBox ID="CheckBox6" runat="server" onclick="javascript:this.value=((this.checked)?'1':'0');" Text="E-Liste" /></div>
		        <div class="Temizle"></div>
	        </div>
            <div style="float:left; width:150px;">
		        <div style="float:left;"><asp:CheckBox ID="CheckBox7" runat="server" onclick="javascript:this.value=((this.checked)?'1':'0');" Text="Anket" /></div>
		        <div class="Temizle"></div>
	        </div>
            <div style="float:left; width:150px;">
		        <div style="float:left;"><asp:CheckBox ID="CheckBox8" runat="server" onclick="javascript:this.value=((this.checked)?'1':'0');" Text="Galeri" /></div>
		        <div class="Temizle"></div>
	        </div>
            <div style="float:left; width:150px;">
		        <div style="float:left;"><asp:CheckBox ID="CheckBox9" runat="server" onclick="javascript:this.value=((this.checked)?'1':'0');" Text="İnsan Kaynakları" /></div>
		        <div class="Temizle"></div>
	        </div>
            <div style="float:left; width:150px;">
		        <div style="float:left;"><asp:CheckBox ID="CheckBox10" runat="server" onclick="javascript:this.value=((this.checked)?'1':'0');" Text="Slider" /></div>
		        <div class="Temizle"></div>
	        </div>
            <div style="float:left; width:150px;">
		        <div style="float:left;"><asp:CheckBox ID="CheckBox11" runat="server" onclick="javascript:this.value=((this.checked)?'1':'0');" Text="Kullanıcılar" /></div>
		        <div class="Temizle"></div>
	        </div>
            <div style="float:left; width:150px;">
		        <div style="float:left;"><asp:CheckBox ID="CheckBox12" runat="server" onclick="javascript:this.value=((this.checked)?'1':'0');" Text="İletişim" /></div>
		        <div class="Temizle"></div>
	        </div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-top:25px;"><asp:Button ID="Button1" CssClass="Buton" runat="server" Text="Ekle" OnClick="Button1_Click" /></div>
        <div style="margin-top:20px; text-align:center;"><asp:Label ID="Label1" runat="server"></asp:Label></div>
    </div>
</div>
</asp:Content>