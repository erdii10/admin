<%@ Page Title="" Language="C#" MasterPageFile="~/Skin.Master" AutoEventWireup="true" CodeBehind="ikduzenle.aspx.cs" Inherits="admin.ikduzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="Kenar">
    <div class="UstBaslik">İnsan Kaynakları</div>
    <div id="IcerikTop">
        <a href="ik.aspx" class="IcerikListele">Başvuru Listele</a>
        <div class="Temizle"></div>
    </div>
    <div class="IcerikTaban">
        <div style="margin-bottom:10px;">
            <div style="float:right; width:9%; padding-top:10px;"><asp:LinkButton ID="LinkButton2" runat="server" CssClass="Yazi" OnClick="LinkButton2_Click">Word Olarak Kaydet</asp:LinkButton></div>
            <div style="float:right; width:3%;"><img src="/images/word.jpg" border="0" /></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">TC Kimlik Numarası :</div>
            <div style="float:left; width:92%;"><%=tc %></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Adı Soyadı :</div>
            <div style="float:left; width:92%;"><%=adsoyad %></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Cinsiyeti :</div>
            <div style="float:left; width:92%;"><%=cinsiyet %></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Medeni Hali :</div>
            <div style="float:left; width:92%;"><%=medenihal %></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Varsa Çocuk Sayısı :</div>
            <div style="float:left; width:92%;"><%=cocuksay %></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Telefon Numarası :</div>
            <div style="float:left; width:92%;"><%=tel %></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">E-Posta Adresi :</div>
            <div style="float:left; width:92%;"><%=eposta %></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Adres :</div>
            <div style="float:left; width:92%;"><%=adres %></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Doğum Tarihi :</div>
            <div style="float:left; width:92%;"><%=dogtar %></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Mesleği :</div>
            <div style="float:left; width:92%;"><%=meslek %></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Başvurduğu Pozisyon :</div>
            <div style="float:left; width:92%;"><%=baspoz %></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Yüklediği Cv Dosyası :</div>
            <div style="float:left; width:92%;"><asp:LinkButton ID="LinkButton1" runat="server" CssClass="Yazi" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton></div>
            <div class="Temizle"></div>
        </div>
    </div>
</div>
</asp:Content>