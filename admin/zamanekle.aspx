<%@ Page Title="" Language="C#" MasterPageFile="~/Skin.Master" AutoEventWireup="true" CodeBehind="zamanekle.aspx.cs" Inherits="admin.zamanekle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link type="text/css" rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" />
<script type="text/javascript" src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
<script type="text/javascript">
     $( function() {
         $("#<%=TextBox5.ClientID%>").datepicker({
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
    <div class="UstBaslik">Zamanlanmış Görevler</div>
    <div id="IcerikTop">
        <a href="zamanekle.aspx" class="IcerikEkle">Zamanlanmış Kategori Ekle</a>
        <a href="zaman.aspx" class="IcerikListele">Kategori Listele</a>
        <div class="Temizle"></div>
    </div>
    <div class="IcerikTaban">
        <asp:Panel ID="Panel1" runat="server">
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Kategori Adı :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox1" CssClass="Text" runat="server" MaxLength="255"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Sıra :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox2" CssClass="Text2" runat="server" MaxLength="5"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-left:8%;"><asp:Button ID="Button1" CssClass="Buton" runat="server" Text="Ekle" OnClick="Button1_Click" /></div>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <div style="margin-bottom:10px; margin-top:25px;">
                <div style="float:left; width:8%;">Başlık :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox3" CssClass="Text" runat="server" MaxLength="255"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Resim :</div>
                <div style="float:left; width:92%;"><asp:FileUpload ID="FileUpload1" CssClass="Text" runat="server"/></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Url :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox4" CssClass="Text" runat="server" MaxLength="255"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Başlangıç Tarihi :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox5" CssClass="Text4" runat="server" MaxLength="10"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Bitiş Tarihi :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox6" CssClass="Text4" runat="server" MaxLength="10"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Sıra :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox7" CssClass="Text2" runat="server" MaxLength="5"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-left:8%;"><asp:Button ID="Button2" CssClass="Buton" runat="server" Text="Ekle" OnClick="Button2_Click" /></div>
        </asp:Panel>
        <div style="margin-top:20px; text-align:center;"><asp:Label ID="Label1" runat="server"></asp:Label></div>
    </div>
</div>
</asp:Content>