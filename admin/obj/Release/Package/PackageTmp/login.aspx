<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="admin.login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Admin Panel v3.2</title>
<link type="text/css" rel="stylesheet" href="/scripts/style.css" />
<meta name="viewport" content="width=device-width" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="DivOrtala">
        <div id="Logo"><img src="/images/logo.png" /></div>
        <div id="LoginForms">
            <div style="font-weight:bolder;">Kullanıcı Adı</div>
            <div><asp:TextBox ID="TextBox1" CssClass="LoginTextBox" runat="server"></asp:TextBox></div>
            <div style="margin-top:15px; font-weight:bolder;">Şifre</div>
            <div><asp:TextBox ID="TextBox2" CssClass="LoginTextBox" TextMode="Password" runat="server"></asp:TextBox></div>
            <div style="float:right; margin-top:15px;"><asp:Button ID="Button1" CssClass="LoginButton" runat="server" Text="Giriş" OnClick="Button1_Click" /></div>
            <div class="Temizle"></div>
            <div align="center" style="margin-top:10px;"><asp:Label ID="Label1" runat="server"></asp:Label></div>
        </div>
        <div id="Pass">
            <div style="float:left;"><img src="/images/pass.jpg" border="0" /></div>
            <div style="float:left; padding-left:5px;"><a href="sifre.aspx" style="text-decoration:none; color:#525261;">Şifremi Unuttum ?</a></div>
            <div class="Temizle"></div>
        </div>
    </div>
    </form>
</body>
</html>
