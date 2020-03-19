<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDeliveryChallanPrint.aspx.cs" Inherits="VeeraApp.ViewerInventory.ViewDeliveryChallanPrint" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="../crystalreportviewers13/js/crviewer/crv.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="btnprint" OnClick="btnprint_Click" runat="server" Text="Print" />
    </div>
    <div>
        <CR:CrystalReportViewer ID="CryRptDecliveryChallan" runat="server" AutoDataBind="true" HasCrystalLogo="False" ToolPanelView="None" />
    </div>
    </form>
</body>
</html>
