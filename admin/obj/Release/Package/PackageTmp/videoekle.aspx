<%@ Page Title="" Language="C#" MasterPageFile="~/Skin.Master" AutoEventWireup="true" CodeBehind="videoekle.aspx.cs" Inherits="admin.videoekle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="Kenar">
    <div class="UstBaslik">Videolar</div>
    <div id="IcerikTop">
        <a href="videoekle.aspx" class="IcerikEkle">Video Kategori Ekle</a>
        <a href="videolar.aspx" class="IcerikListele">Kategori Listele</a>
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
                <div style="float:left; width:8%;">Url :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox4" CssClass="Text" runat="server" MaxLength="255"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Sıra :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox5" CssClass="Text2" runat="server" MaxLength="5"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-left:8%;"><asp:Button ID="Button2" CssClass="Buton" runat="server" Text="Ekle" OnClick="Button2_Click" /></div>
        </asp:Panel>
        <div style="margin-top:20px; text-align:center;"><asp:Label ID="Label1" runat="server"></asp:Label></div>
    </div>
</div>
</asp:Content>