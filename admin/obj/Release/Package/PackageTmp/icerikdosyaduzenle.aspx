<%@ Page Title="" Language="C#" MasterPageFile="~/Skin.Master" AutoEventWireup="true" CodeBehind="icerikdosyaduzenle.aspx.cs" Inherits="admin.icerikdosyaduzenle" %>
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
            <div style="float:left; width:8%;">Dosya Adı :</div>
            <div style="float:left; width:92%;"><asp:TextBox ID="TextBox1" CssClass="Text" runat="server" MaxLength="150"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Açıklama :</div>
            <div style="float:left; width:92%;"><asp:TextBox ID="TextBox2" CssClass="Text3" runat="server" MaxLength="255" TextMode="MultiLine"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <%if (kontroldosya == "yok"){%>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Dosya :</div>
            <div style="float:left; width:92%;"><asp:FileUpload ID="FileUpload1" CssClass="Text" runat="server"/></div>
            <div class="Temizle"></div>
        </div>
        <% } %>
        <%else { %>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Dosya :</div>
            <div style="float:left; width:33px;">
                <%if (icon == "word") { %><img src="/images/word.jpg" border="0" /><%} %>
                <%if (icon == "excel") { %><img src="/images/excel.jpg" border="0" /><%} %>
                <%if (icon == "power") { %><img src="/images/power.jpg" border="0" /><%} %>
                <%if (icon == "access") { %><img src="/images/access.jpg" border="0" /><%} %>
                <%if (icon == "html") { %><img src="/images/html.jpg" border="0" /><%} %>
                <%if (icon == "pdf") { %><img src="/images/pdf.jpg" border="0" /><%} %>
            </div>
            <div style="float:left; margin-left:10px;"><%=dosyaadi %></div>
            <div style="float:left; margin-left:5px;"><a href="sil.aspx?Id=<%=Id %>&kategori=IcerikDosyaDuzenle"><img src="/images/sil.jpg" border="0" /></a></div>
            <div class="Temizle"></div>
        </div>
        <%} %>
        <div style="margin-bottom:10px;">
            <div style="float:left; width:8%;">Sıra :</div>
            <div style="float:left; width:92%;"><asp:TextBox ID="TextBox3" CssClass="Text2" runat="server" MaxLength="5"></asp:TextBox></div>
            <div class="Temizle"></div>
        </div>
        <div style="margin-left:8%;"><asp:Button ID="Button1" CssClass="Buton" runat="server" Text="Düzenle" OnClick="Button1_Click" /></div>
        <div style="margin-top:20px; text-align:center;"><asp:Label ID="Label1" runat="server"></asp:Label></div>
    </div>
</div>
</asp:Content>