<%@ Page Title="" Language="C#" MasterPageFile="~/Skin.Master" AutoEventWireup="true" CodeBehind="kirp.aspx.cs" Inherits="admin.kirp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="/scripts/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
<script src="/scripts/jquery.min.js" type="text/javascript"></script>
<script src="/scripts/jquery.Jcrop.js" type="text/javascript"></script>
<script type="text/javascript">
    jQuery(document).ready(function () {
        jQuery('#<%=imgCrop.ClientID %>').Jcrop({
            onSelect: storeCoords,
            //Set Image Box Height & Width
            maxSize: [<%=en%>, <%=boy%>],
            boxWidth: <%=genelen%>, boxHeight: <%=genelboy%>
        });
    });
    //Function to store coordinates
    function storeCoords(c) {
        jQuery('#<%=hdnX.ClientID %>').val(c.x);
        jQuery('#<%=hdnY.ClientID %>').val(c.y);
        jQuery('#<%=hdnW.ClientID %>').val(c.w);
        jQuery('#<%=hdnH.ClientID %>').val(c.h);
    };
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="Kenar">
    <div class="IcerikTaban">
        <div style="float:left; width:92%; padding-right:20px; margin-right:20px; border-right:1px solid #CCC;">
            <asp:Image ID="imgCrop" runat="server" />
            <asp:HiddenField ID="hdnX" runat="server" />
            <asp:HiddenField ID="hdnY" runat="server" />
            <asp:HiddenField ID="hdnW" runat="server" />
            <asp:HiddenField ID="hdnH" runat="server" />
        </div>
        <div style="float:left; width:3%;"><asp:Button ID="Button1" CssClass="Buton" runat="server" Text="Kırp" OnClick="Button1_Click" /></div>
        <div class="Temizle"></div>
    </div>
</div>
</asp:Content>