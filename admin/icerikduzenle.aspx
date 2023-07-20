<%@ Page Title="" Language="C#" MasterPageFile="~/Skin.Master" AutoEventWireup="true" validateRequest="false" CodeBehind="icerikduzenle.aspx.cs" Inherits="admin.icerikduzenle" %>
<%@ Register assembly="CollectionPager" namespace="SiteUtils" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="//cdn.ckeditor.com/4.9.2/standard/ckeditor.js"></script>
<script type="text/javascript">
    window.onload = function () {
        var editor = CKEDITOR.replace('<% = TextBox7.ClientID %>');
    };
</script>
<link type="text/css" rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css" />
<script type="text/javascript" src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
<script type="text/javascript">
     $( function() {
         $("#<%=TextBox8.ClientID%>").datepicker({
            dateFormat: "dd.mm.yy",
            //altFormat: "yy-mm-dd", Mysql kaydetme formatı
            //altField: "#tarih-db", Mysql kaydetme formatı
            changeMonth: true,//ayı elle seçmeyi aktif eder
            changeYear: true,//yılı elee seçime izin verir
            maxDate: "+5y+1m +2w",//ileri göre bilme zamanını 2 yıl 1 ay 2 hafta yaptık
            minDate: "-1y-1m -2w",//geriyi göre bilme alanını 1 yıl 1 ay 2 hafta yaptık.bunu istediğiniz gibi ayarlaya bilirsiniz
            monthNames: [ "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" ],
            dayNamesMin: [ "Pa", "Ptz", "Sa", "Ça", "Pe", "Cu", "Ct" ],
            monthNamesShort: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],//ay seçim alanın düzenledik
            nextText: "ileri",//ileri butonun türkçeleştirdik
            prevText: "geri",//buda geri butonu için
            showAnim: "fade",//takvim açılım animasyonu alta tüm animasyon isimleri yazdım 
            firstDay: 1
        });
    });
</script>
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
        <asp:Panel ID="Panel1" runat="server">
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Kategori Adı :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox1" CssClass="Text" runat="server" MaxLength="255"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <%if (kontrolresim == "var"){%>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Resim :</div>
                <div style="float:left; padding:5px; margin-right:5px; border:1px solid #CCC;"><img src="/img/contents/<%=resim %>" width="355" height="270" border="0" /></div>
                <div style="float:left;"><a href="sil.aspx?Id=<%=Id %>&kategori=IcerikKatResim"><img src="/images/sil.jpg" border="0" /></a></div>
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
            <div id="AltIcerikUst">
                <div style="float:left;">Kategoriye Ait Alt İçerikler</div>
                <div style="float:right;"><a href="icerikekle.aspx?Id=<%=Id %>"><img src="/images/ekle.jpg" border="0" /></a></div>
                <div class="Temizle"></div>
            </div>
            <%if (kontrol == "var"){%>
            <div id="IcerikUst" style="margin-top:20px;">
                <div style="float:left; width:5%;">Sıra</div>
                <div style="float:left; width:80%;">Kategori Adı</div>
                <div style="float:left; width:11%;">Alt İçerik Ekle</div>
                <div style="float:left; width:4%;">İşlem</div>
                <div class="Temizle"></div>
            </div>
            <asp:Repeater ID="RptSirala" runat="server"><ItemTemplate>
            <div class="IcerikVeri">
                <div style="float:left; width:5%;"><%#DataBinder.Eval(Container.DataItem,"sira") %></div>
                <div style="float:left; width:81%;"><%#DataBinder.Eval(Container.DataItem,"baslik") %></div>
                <div style="float:left; width:10%;"><a href="icerikekle.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>" class="IcerikLink">İçerik Ekle</a></div>
                <div style="float:left; width:2%;"><a href="icerikduzenle.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>"><img src="/images/duzenle.jpg" border="0" /></a></div>
                <div style="float:left; width:2%;"><a href="sil.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>&kategori=AltIcerik"><img src="/images/sil.jpg" border="0" /></a></div>
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
            <% }%>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <div id="IcerikUst">Meta İçerikleri</div>
            <div style="margin-bottom:10px; margin-top:25px;">
                <div style="float:left; width:8%;">Title :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox3" CssClass="Text" runat="server" MaxLength="50"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Keywords :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox4" CssClass="Text3" runat="server" MaxLength="255" TextMode="MultiLine"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Description :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox5" CssClass="Text" runat="server" MaxLength="100"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div id="IcerikUst">İçerik</div>
            <div style="margin-bottom:10px; margin-top:25px;">
                <div style="float:left; width:8%;">Başlık :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox6" CssClass="Text" runat="server" MaxLength="255"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">İçerik :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox7" TextMode="MultiLine" runat="server"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Tarih :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox8" CssClass="Text4" runat="server" MaxLength="10"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Yazar :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox9" CssClass="Text4" runat="server" MaxLength="100"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-bottom:10px;">
                <div style="float:left; width:8%;">Sıra :</div>
                <div style="float:left; width:92%;"><asp:TextBox ID="TextBox10" CssClass="Text2" runat="server" MaxLength="5"></asp:TextBox></div>
                <div class="Temizle"></div>
            </div>
            <div style="margin-left:8%; margin-bottom:10px;"><asp:Button ID="Button2" CssClass="Buton" runat="server" Text="Düzenle" OnClick="Button2_Click" /></div>
            <div id="AltIcerikUst">
                <div style="float:left;">Alt İçerikler</div>
                <div style="float:right;"><a href="icerikekle.aspx?Id=<%=Id %>"><img src="/images/ekle.jpg" border="0" /></a></div>
                <div class="Temizle"></div>
            </div>
            <%if (kontrolalticerik == "var"){%>
            <div id="IcerikUst" style="margin-top:20px;">
                <div style="float:left; width:5%;">Sıra</div>
                <div style="float:left; width:80%;">Kategori Adı</div>
                <div style="float:left; width:11%;">Alt İçerik Ekle</div>
                <div style="float:left; width:4%;">İşlem</div>
                <div class="Temizle"></div>
            </div>
            <asp:Repeater ID="RptAltSirala" runat="server"><ItemTemplate>
            <div class="IcerikVeri">
                <div style="float:left; width:5%;"><%#DataBinder.Eval(Container.DataItem,"sira") %></div>
                <div style="float:left; width:81%;"><%#DataBinder.Eval(Container.DataItem,"baslik") %></div>
                <div style="float:left; width:10%;"><a href="icerikekle.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>" class="IcerikLink">İçerik Ekle</a></div>
                <div style="float:left; width:2%;"><a href="icerikduzenle.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>"><img src="/images/duzenle.jpg" border="0" /></a></div>
                <div style="float:left; width:2%;"><a href="sil.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>&kategori=AltIcerik"><img src="/images/sil.jpg" border="0" /></a></div>
                <div class="Temizle"></div>
            </div>
            </ItemTemplate></asp:Repeater>
            <div style="margin-top:10px;" align="center">
                <cc1:CollectionPager ID="CollAltIcerik" runat="server" BackNextDisplay="Buttons"
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
            <div id="AltIcerikUst">
                <div style="float:left;">İçeriğe Ait Resimler</div>
                <div style="float:right;"><a href="icerikresimekle.aspx?Id=<%=Id %>&kategori=IcerikResimEkle"><img src="/images/ekle.jpg" border="0" /></a></div>
                <div class="Temizle"></div>
            </div>
            <%if (kontrolresim == "var"){%>
            <div style="margin-top:20px; width:100%;">
                <asp:Repeater ID="RptResimler" runat="server"><ItemTemplate>
                <div class="IcerikImgBg">
                    <div class="ResimBg"><img src="/img/contents/<%#DataBinder.Eval(Container.DataItem,"resim")%>" width="100%" height="100%" border="0" /></div>
                    <div class="ResimText">
                        <div><%#DataBinder.Eval(Container.DataItem,"baslik") %></div>
                        <div style="margin-top:5px;"><%#DataBinder.Eval(Container.DataItem,"sira") %></div>
                        <div style="margin-top:5px;">
                            <div style="float:left; margin:5px; margin-left:0px;"><a href="icerikresimduzenle.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>&kategori=IcerikResimDuzenle"><img src="/images/duzenle.jpg" border="0" /></a></div>
                            <div style="float:left; margin:5px; margin-left:0px;"><a href="sil.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>&kategori=IcerikResim"><img src="/images/sil.jpg" border="0" /></a></div>
                            <div class="Temizle"></div>
                        </div>
                    </div>
                    <div class="Temizle"></div>
                </div>
                </ItemTemplate></asp:Repeater>
                <div class="Temizle"></div>
            </div>
            <div style="margin-top:10px;" align="center">
                <cc1:CollectionPager ID="CollResimler" runat="server" BackNextDisplay="Buttons"
                BackNextLinkSeparator="" BackNextLocation="Split" BackNextStyle=""
                BackText="<" ControlCssClass="Sayfalama" ControlStyle=""
                FirstText="<<" HideOnSinglePage="True" IgnoreQueryString="True"
                LabelStyle="" LabelText="Sayfalar :" LastText=">>" MaxPages="100"
                NextText=">" PageNumbersDisplay="Numbers" PageNumbersSeparator="&amp;nbsp;"
                PageNumbersStyle="" PageNumberStyle="" PageSize="6" PagingMode="PostBack"
                QueryStringKey="Sayfa"
                ResultsFormat="{2} tane makaleden {0} - {1} arası gösteriliyor"
                ResultsLocation="None" ResultsStyle="" SectionPadding="10" ShowFirstLast="True"
                ShowLabel="False" ShowPageNumbers="True" SliderSize="15" UseSlider="True">
                </cc1:CollectionPager>
            </div>
            <%} %>
            <div id="AltIcerikUst">
                <div style="float:left;">İçeriğe Ait Dosyalar</div>
                <div style="float:right;"><a href="icerikdosyaekle.aspx?Id=<%=Id %>"><img src="/images/ekle.jpg" border="0" /></a></div>
                <div class="Temizle"></div>
            </div>
            <%if (kontroldosya == "var"){%>
            <div id="IcerikUst" style="margin-top:20px;">
                <div style="float:left; width:5%;">Sıra</div>
                <div style="float:left; width:81%;">Dosya Adı</div>
                <div style="float:left; width:5%;">Boyut</div>
                <div style="float:left; width:5%;">Tür</div>
                <div style="float:left; width:4%;">İşlem</div>
                <div class="Temizle"></div>
            </div>
            <asp:Repeater ID="RptDosyalar" runat="server"><ItemTemplate>
            <div class="IcerikVeri">
                <div style="float:left; width:5%;"><%#DataBinder.Eval(Container.DataItem,"sira") %></div>
                <div style="float:left; width:81%;"><%#DataBinder.Eval(Container.DataItem,"baslik") %></div>
                <div style="float:left; width:5%;"><%#DataBinder.Eval(Container.DataItem,"boyutu") %></div>
                <div style="float:left; width:5%;"><%#DataBinder.Eval(Container.DataItem,"turu") %></div>
                <div style="float:left; width:2%;"><a href="icerikdosyaduzenle.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>"><img src="/images/duzenle.jpg" border="0" /></a></div>
                <div style="float:left; width:2%;"><a href="sil.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Id") %>&kategori=IcerikDosya"><img src="/images/sil.jpg" border="0" /></a></div>
                <div class="Temizle"></div>
            </div>
            </ItemTemplate></asp:Repeater>
            <div style="margin-top:10px;" align="center">
                <cc1:CollectionPager ID="CollDosyalar" runat="server" BackNextDisplay="Buttons"
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
            <%} %>
        </asp:Panel>
        <div style="margin-top:20px; text-align:center;"><asp:Label ID="Label1" runat="server"></asp:Label></div>
    </div>
</div>
</asp:Content>