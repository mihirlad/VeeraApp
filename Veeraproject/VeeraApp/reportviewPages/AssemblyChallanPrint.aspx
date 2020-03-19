<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssemblyChallanPrint.aspx.cs" Inherits="VeeraApp.reportviewPages.AssemblyChallanPrint" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script lang="javaScript" type="text/javascript" src="../crystalreportviewers13/js/crviewer/crv.js"></script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="btnprint" OnClick="btnprint_Click1" runat="server" Text="Print" />
    </div>
        <div>
            <CR:CrystalReportViewer ID="cryrptDeliveryChallan" runat="server" AutoDataBind="true" HasCrystalLogo="False" ToolPanelView="None" />
        </div>
    </form>
</body>
</html>
