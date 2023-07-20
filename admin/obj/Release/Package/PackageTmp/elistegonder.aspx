<%@ Page Title="" Language="C#" MasterPageFile="~/Skin.Master" AutoEventWireup="true" validateRequest="false" CodeBehind="elistegonder.aspx.cs" Inherits="admin.elistegonder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="//cdn.ckeditor.com/4.9.2/standard/ckeditor.js"></script>
<script type="text/javascript">
    window.onload = function () {
        var editor = CKEDITOR.replace('<% = TextBox2.ClientID %>');
    };
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Kenar">
    <div class="UstBaslik">E-Liste</div>
    <div id="IcerikTop">
        <a href="elistegonder.aspx" class="IcerikEkle">Toplu Mail Gönder</a>
        <a href="eliste.aspx" class="IcerikListele">E-Liste</a>
        <div class="Temizle"></div>
    </div>
    <div class="IcerikTaban">
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Konu :</div>
            <div style="float:left; width:92%;"><asp:TextBox ID="TextBox1" CssClass="Text" runat="server" MaxLength="255"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Mesaj :</div>
            <div style="float:left; width:92%;"><asp:TextBox ID="TextBox2" TextMode="MultiLine" runat="server"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-left:8%;"><asp:Button ID="Button1" CssClass="Buton" runat="server" Text="Gönder" OnClick="Button1_Click" /></div>
        <div style="margin-top:20px; text-align:center;"><asp:Label ID="Label1" runat="server"></asp:Label></div>
    </div>
</div>
</asp:Content>