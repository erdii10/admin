<%@ Page Title="" Language="C#" MasterPageFile="~/Skin.Master" AutoEventWireup="true" validateRequest="false" CodeBehind="icerikdosyaekle.aspx.cs" Inherits="admin.icerikdosyaekle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="Kenar">
    <div class="UstBaslik">İçerikler</div>
    <div id="IcerikTop">
        <a href="icerikekle.aspx" class="IcerikEkle">İçerik Kategori Ekle</a>
        <a href="icerikler.aspx" class="IcerikListele">İçerik Kategori Listele</a>
        <div class="Temizle"></div>
    </div>
    <div class="IcerikTaban">
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Dosya Adı :</div>
            <div style="float:left; width:92%;"><asp:TextBox ID="TextBox1" CssClass="Text" runat="server" MaxLength="150"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Açıklama :</div>
            <div style="float:left; width:92%;"><asp:TextBox ID="TextBox2" CssClass="Text3" runat="server" MaxLength="255" TextMode="MultiLine"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Dosya :</div>
            <div style="float:left; width:92%;"><asp:FileUpload ID="FileUpload1" CssClass="Text" runat="server"/></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Sıra :</div>
            <div style="float:left; width:92%;"><asp:TextBox ID="TextBox3" CssClass="Text2" runat="server" MaxLength="5"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-left:8%;"><asp:Button ID="Button1" CssClass="Buton" runat="server" Text="Ekle" OnClick="Button1_Click" /></div>
        <div style="margin-top:20px; text-align:center;"><asp:Label ID="Label1" runat="server"></asp:Label></div>
    </div>
</div>
</asp:Content>