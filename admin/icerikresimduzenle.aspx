<%@ Page Title="" Language="C#" MasterPageFile="~/Skin.Master" AutoEventWireup="true" CodeBehind="icerikresimduzenle.aspx.cs" Inherits="admin.icerikresimduzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="Kenar">
    <div class="UstBaslik">İçerikler <%if (kontrolbaslik == "var"){%><asp:Repeater ID="RptBasliklar" runat="server"><ItemTemplate><span style="font-size:13px;"> > <a href="icerikduzenle.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>" class="IcerikLink"><%#DataBinder.Eval(Container.DataItem,"baslik") %></a> </span></ItemTemplate></asp:Repeater><% }%><%if (kontrolaltbaslik == "var"){%><asp:Repeater ID="RptAltBasliklar" runat="server"><ItemTemplate><span style="font-size:13px;"> > <a><%#DataBinder.Eval(Container.DataItem,"baslik") %></a> </span></ItemTemplate></asp:Repeater><% }%> </div>
    <div id="IcerikTop">
        <a href="icerikekle.aspx" class="IcerikEkle">İçerik Kategori Ekle</a>
        <a href="icerikler.aspx" class="IcerikListele">İçerik Kategori Listele</a>
        <div class="Temizle"></div>
    </div>
    <div class="IcerikTaban">
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Kategori Adı :</div>
            <div style="float:left; width:92%;"><asp:TextBox ID="TextBox1" CssClass="Text" runat="server" MaxLength="255"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <%if (kontrolresim == "var"){%>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Resim :</div>
            <div style="float:left; padding:5px; margin-right:5px; border:1px solid #CCC;"><img src="/img/contents/<%=resim %>" width="355" height="270" border="0" /></div>
            <div style="float:left;"><a href="sil.aspx?Id=<%=Id %>&kategori=<%=kategori %>"><img src="/images/sil.jpg" border="0" /></a></div>
            <div class="Temizle"></div>
        </div>
        <% }%>
        <%else { %>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Kategori Resmi :</div>
            <div style="float:left; width:92%;"><asp:FileUpload ID="FileUpload1" CssClass="Text" runat="server"/></div>
            <div class="Temizle"></div>
        </div>
        <%} %>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Sıra :</div>
            <div style="float:left; width:92%;"><asp:TextBox ID="TextBox2" CssClass="Text2" runat="server" MaxLength="5"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-left:8%; margin-bottom:10px;"><asp:Button ID="Button1" CssClass="Buton" runat="server" Text="Düzenle" OnClick="Button1_Click" /></div>
        <div style="margin-top:20px; text-align:center;"><asp:Label ID="Label1" runat="server"></asp:Label></div>
    </div>
</div>
</asp:Content>