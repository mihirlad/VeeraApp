<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchase_Order.aspx.cs" Inherits="VeeraApp.reportviewPages.Purchase_Order" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script lang="javaScript" type="text/javascript" src="../crystalreportviewers13/js/crviewer/crv.js"></script> 

    <%--<script type="text/javascript" src="../crystalreportviewers13/js/crviewer/crv.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnprint" runat="server" OnClick="btnprint_Click" Text="Print" />
    <div>
        <CR:CrystalReportViewer ID="crypurorder" runat="server" AutoDataBind="true" HasCrystalLogo="False" ToolPanelView="None" />
    </div>
    </form>
</body>
</html>

<%-- <%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %> --%>