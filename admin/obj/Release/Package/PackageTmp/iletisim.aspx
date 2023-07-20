<%@ Page Title="" Language="C#" MasterPageFile="~/Skin.Master" AutoEventWireup="true" CodeBehind="iletisim.aspx.cs" Inherits="admin.iletisim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="Kenar">
    <%if (harita != ""){%>
            
        <div class="IcerikTaban"><iframe src="<%=harita %>" width="<%=en %>" height="<%=boy %>" style="border:0;" allowfullscreen="" loading="lazy"></iframe></div><% } %>
    <div class="IcerikTaban">
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Harita Kodu :</div>
            <div style="float:left; width:92%;"><asp:TextBox ID="TextBox1" CssClass="Text" runat="server"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Harita En :</div>
            <div style="float:left; width:92%;"><asp:TextBox ID="TextBox2" CssClass="Text2" runat="server" MaxLength="4"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Harita Boy :</div>
            <div style="float:left; width:92%;"><asp:TextBox ID="TextBox3" CssClass="Text2" runat="server" MaxLength="4"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Adres :</div>
            <div style="float:left; width:92%;"><asp:TextBox ID="TextBox4" CssClass="Text" runat="server"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Telefon :</div>
            <div style="float:left; width:92%;"><asp:TextBox ID="TextBox5" CssClass="Text" runat="server"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">E-Posta :</div>
            <div style="float:left; width:92%;"><asp:TextBox ID="TextBox6" CssClass="Text" runat="server"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-left:8%;"><asp:Button ID="Button1" CssClass="Buton" runat="server" Text="Düzenle" OnClick="Button1_Click" /></div>
    </div>
</div>
</asp:Content>