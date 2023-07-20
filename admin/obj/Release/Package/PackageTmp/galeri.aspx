<%@ Page Title="" Language="C#" MasterPageFile="~/Skin.Master" AutoEventWireup="true" CodeBehind="galeri.aspx.cs" Inherits="admin.galeri" %>
<%@ Register assembly="CollectionPager" namespace="SiteUtils" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="Kenar">
    <div class="UstBaslik">Galeri</div>
    <div id="IcerikTop">
        <a href="galeriekle.aspx" class="IcerikEkle">Kategori Ekle</a>
        <span style="margin-top:5px; position:absolute; left:47%;">Toplam <%=sayi %> Kategori</span>
        <a href="galeri.aspx" class="IcerikListele">Kategori Listele</a>
        <div class="Temizle"></div>
    </div>
    <%if (kontrol == "var"){%>
    <div class="IcerikTaban">
        <div id="IcerikUst">
            <div style="float:left; width:5%;">Sıra</div>
            <div style="float:left; width:81%;">Kategori Adı</div>
            <div style="float:left; width:10%;">Resim Ekle</div>
            <div style="float:left; width:4%;">İşlem</div>
            <div class="Temizle"></div>
        </div>
        <asp:Repeater ID="RptSirala" runat="server"><ItemTemplate>
        <div class="IcerikVeri">
            <div style="float:left; width:5%;"><%#DataBinder.Eval(Container.DataItem,"sira") %></div>
            <div style="float:left; width:81%;"><%#DataBinder.Eval(Container.DataItem,"baslik") %></div>
            <div style="float:left; width:10%;"><a href="galeriekle.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>" class="IcerikLink">Resim Ekle</a></div>
            <div style="float:left; width:2%;"><a href="galeriduzenle.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>"><img src="/images/duzenle.jpg" border="0" /></a></div>
            <div style="float:left; width:2%;"><a href="sil.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>&kategori=GaleriKat"><img src="/images/sil.jpg" border="0" /></a></div>
            <div class="Temizle"></div>
        </div>
        </ItemTemplate></asp:Repeater>
        <div style="margin-top:10px;" align="center">
            <cc1:CollectionPager ID="CollSayfala" runat="server" BackNextDisplay="Buttons"
            BackNextLinkSeparator="" BackNextLocation="Split" BackNextStyle=""
            BackText="<" ControlCssClass="Sayfalama" ControlStyle=""
            FirstText="<<" HideOnSinglePage="True" IgnoreQueryString="True"
            LabelStyle="" LabelText="Sayfalar :" LastText=">>" MaxPages="100"
            NextText=">" PageNumbersDisplay="Numbers" PageNumbersSeparator="&amp;nbsp;"
            PageNumbersStyle="" PageNumberStyle="" PageSize="15" PagingMode="PostBack"
            QueryStringKey="Sayfa"
            ResultsFormat="{2} tane makaleden {0} - {1} arası gösteriliyor"
            ResultsLocation="None" ResultsStyle="" SectionPadding="10" ShowFirstLast="True"
            ShowLabel="False" ShowPageNumbers="True" SliderSize="15" UseSlider="True">
            </cc1:CollectionPager>
        </div>
    </div>
    <% }%>
</div>
</asp:Content>