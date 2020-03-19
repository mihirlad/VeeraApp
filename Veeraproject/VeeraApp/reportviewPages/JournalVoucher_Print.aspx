<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JournalVoucher_Print.aspx.cs" Inherits="VeeraApp.reportviewPages.JournalVoucher_Print" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


    

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
    <asp:Button ID="btnprint" runat="server" OnClick="btnprint_Click" Text="Print" />
    </div>

        <div>
            <CR:CrystalReportViewer ID="cryJournalvou" runat="server" AutoDataBind="true" HasCrystalLogo="False" ToolPanelView="None"  />
        </div>

    </form>
</body>
</html>
