<%@ Page Title="" Language="C#" MasterPageFile="~/Skin.Master" AutoEventWireup="true" CodeBehind="galeriduzenle.aspx.cs" Inherits="admin.galeriduzenle" %>
<%@ Register assembly="CollectionPager" namespace="SiteUtils" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Kenar">
    <div class="UstBaslik">Galeri <%if (kontrolbaslik == "var"){%><asp:Repeater ID="RptBasliklar" runat="server"><ItemTemplate><span style="font-size:13px;"> > <a href="galeriduzenle.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>" class="IcerikLink"><%#DataBinder.Eval(Container.DataItem,"baslik") %></a> </span></ItemTemplate></asp:Repeater><% }%><%if (kontrolaltbaslik == "var"){%><asp:Repeater ID="RptAltBasliklar" runat="server"><ItemTemplate><span style="font-size:13px;"> > <a><%#DataBinder.Eval(Container.DataItem,"baslik") %></a> </span></ItemTemplate></asp:Repeater><% }%> </div>
    <div id="IcerikTop">
        <a href="galeriekle.aspx" class="IcerikEkle">Kategori Ekle</a>
        <a href="galeri.aspx" class="IcerikListele">Kategori Listele</a>
        <div class="Temizle"></div>
    </div>
    <div class="IcerikTaban">
        <asp:Panel ID="Panel1" runat="server">
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Kategori Başlığı :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox1" CssClass="Text" runat="server" MaxLength="255"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <%if (kontrolresim == "var"){%>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Resim :</div>
                <div style="float:left; padding:5px; margin-right:5px; border:1px solid #CCC;"><img src="/img/gallery/<%=resim %>" width="355" height="270" border="0" /></div>
                <div style="float:left;"><a href="sil.aspx?Id=<%=Id %>&kategori=GaleriKatResim"><img src="/images/sil.jpg" border="0" /></a></div>
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
            <div style="margin-left:8%;"><asp:Button ID="Button1" CssClass="Buton" runat="server" Text="Düzenle" OnClick="Button1_Click" /></div>
            <div id="AltIcerikUst">
                <div style="float:left;">Kategoriye Ait Resimler</div>
                <div style="float:right;"><a href="galeriekle.aspx?Id=<%=Id %>"><img src="/images/ekle.jpg" border="0" /></a></div>
                <div class="Temizle"></div>
            </div>
            <%if (kontrolgaleri == "var"){%>
            <div style="margin-top:20px; width:100%;">
                <asp:Repeater ID="RptSirala" runat="server"><ItemTemplate>
                <div class="IcerikImgBg">
                    <div class="ResimBg"><img src="/img/gallery/<%#DataBinder.Eval(Container.DataItem,"resim")%>" width="100%" height="100%" border="0" /></div>
                    <div class="ResimText">
                        <div><%#DataBinder.Eval(Container.DataItem,"baslik") %></div>
                        <div style="margin-top:5px;"><%#DataBinder.Eval(Container.DataItem,"sira") %></div>
                        <div style="margin-top:5px;">
                            <div style="float:left; margin:5px; margin-left:0px;"><a href="galeriduzenle.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>"><img src="/images/duzenle.jpg" border="0" /></a></div>
                            <div style="float:left; margin:5px; margin-left:0px;"><a href="sil.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>&kategori=Galeri"><img src="/images/sil.jpg" border="0" /></a></div>
                            <div class="Temizle"></div>
                        </div>
                    </div>
                    <div class="Temizle"></div>
                </div>
                </ItemTemplate></asp:Repeater>
                <div class="Temizle"></div>
            </div>
            <div style="margin-top:10px;" align="center">
                <cc1:CollectionPager ID="CollSayfala" runat="server" BackNextDisplay="Buttons"
                BackNextLinkSeparator="" BackNextLocation="Split" BackNextStyle=""
                BackText="<" ControlCssClass="Sayfalama" ControlStyle=""
                FirstText="<<" HideOnSinglePage="True" IgnoreQueryString="True"
                LabelStyle="" LabelText="Sayfalar :" LastText=">>" MaxPages="100"
                NextText=">" PageNumbersDisplay="Numbers" PageNumbersSeparator="&amp;nbsp;"
                PageNumbersStyle="" PageNumberStyle="" PageSize="5" PagingMode="PostBack"
                QueryStringKey="Sayfa"
                ResultsFormat="{2} tane makaleden {0} - {1} arası gösteriliyor"
                ResultsLocation="None" ResultsStyle="" SectionPadding="10" ShowFirstLast="True"
                ShowLabel="False" ShowPageNumbers="True" SliderSize="15" UseSlider="True">
                </cc1:CollectionPager>
            </div>
            <% }%>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <div style="margin-bottom:10px; margin-top:25px;">
                <div style="float:left; width:8%;">Başlık :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox3" CssClass="Text" runat="server" MaxLength="255"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <%if (kontrolresim == "var"){%>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Resim :</div>
                <div style="float:left; padding:5px; margin-right:5px; border:1px solid #CCC;"><img src="/img/gallery/<%=resim %>" width="355" height="270" border="0" /></div>
                <div style="float:left;"><a href="sil.aspx?Id=<%=Id %>&kategori=GaleriResim"><img src="/images/sil.jpg" border="0" /></a></div>
                <div class="Temizle"></div>
            </div>
            <% }%>
            <%else { %>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Resim :</div>
                <div style="float:left; width:92%;"><asp:FileUpload ID="FileUpload2" CssClass="Text" runat="server"/></div>
                <div class="Temizle"></div>
            </div>
            <%} %>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Sıra :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox4" CssClass="Text2" runat="server" MaxLength="5"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-left:8%;"><asp:Button ID="Button2" CssClass="Buton" runat="server" Text="Düzenle" OnClick="Button2_Click" /></div>
        </asp:Panel>
        <div style="margin-top:20px; text-align:center;"><asp:Label ID="Label1" runat="server"></asp:Label></div>
    </div>
</div>
</asp:Content>