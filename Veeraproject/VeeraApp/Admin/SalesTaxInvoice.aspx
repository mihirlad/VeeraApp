﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="SalesTaxInvoice.aspx.cs" Inherits="VeeraApp.SalesTaxInvoice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/model.css" rel="stylesheet" />

     <script type="text/javascript">
        function txtachange() {
            //alert("jigar");
            document.getElementById("btnSubmit").onchange();
        }


        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && charCode != 46 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="SM1" runat="server"></asp:ScriptManager>
    <div class="grids">
        <div class="progressbar-heading grids-heading">

            <span style="float: right;">
                <asp:Label CssClass="label" ID="lblmsg" runat="server"></asp:Label>
            </span>
        </div>
    </div>
    <%-- <a href="SalesTaxInvoice.aspx">SalesTaxInvoice.aspx</a>--%>
    <div style="clear: both; height: 10px">
    </div>

    <div class="grids">
    </div>
    <div class="panel panel-widget forms-panel">
        <div class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title">
                    <h4 id="PageTitlePerfomaInvoice" runat="server">SALES-PERFORMA INVOICE</h4>
                    <h4 id="PageTitleSalesInvoice" runat="server">SALES-TAX INVOICE</h4>
                    <h4 id="PageTitleRetailInvoice" runat="server">SALES-RETAIL INVOICE</h4>
                    <h4 id="PageTiltleCashInvoice" runat="server">CASH INVOICE</h4>
                    <h4 id="PageTitleCashMemoInvoice" runat="server">CASH MEMO INVOICE</h4>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="HfBranchIssueToServiceType" runat="server" />

    <%--  <div style="clear: both; height: 10px">
    </div>--%>


    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">

                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">


                        <%--    <asp:UpdatePanel ID="updpnl" runat="server">
                                <ContentTemplate>--%>

                                    <%--  <asp:HiddenField ID="HfInvoiceBillType" runat="server" />--%>
                                    <asp:HiddenField ID="HfGridsTotalAmount" runat="server" />
                                    <asp:HiddenField ID="HfGridGrossAmount" runat="server" />
                                    <asp:HiddenField ID="HfChargesGridTotalAmount" runat="server" />
                                    <asp:HiddenField ID="HfOtherAmount" runat="server" />
                                    <asp:HiddenField ID="HfTotalSumGSTAmount" runat="server" />
                                    <asp:HiddenField ID="HfTotalSumCGSTAmount" runat="server" />
                                    <asp:HiddenField ID="HfTotalSumSGSTAmount" runat="server" />
                                    <asp:HiddenField ID="HfTotalSumIGSTAmount" runat="server" />
                                    <%-- <div class="h5" style="color: brown">Service Issue To Branch </div>--%>

                                    <div style="float: left; height: auto; width: 35%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label ID="lblCustomerACForChallan" CssClass="label" Text="Customer A/C" ForeColor="Blue" runat="server"></asp:Label>
                                                        <asp:Label ID="lblCashACForBarcode" CssClass="label" Text="Cash A/C" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:HiddenField ID="HfAODEDebit" runat="server" />
                                                        <asp:HiddenField ID="HfACODECredit" runat="server" />
                                                        <asp:TextBox ID="TxtPartyNameDebit" OnTextChanged="TxtPartyNameDebit_TextChanged" AutoPostBack="true" CssClass="form-control" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtPartyNameDebit"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server"
                                                            ControlToValidate="TxtPartyNameDebit" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                <tr id="trConsigneeNameForChallan" runat="server">
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Consignee Name" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:HiddenField ID="HfConsigneePartyCode" runat="server" />
                                                        <asp:TextBox ID="TxtConsigneeName" CssClass="form-control" OnTextChanged="TxtConsigneeName_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="TxtConsigneeName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>

                                                    </td>
                                                </tr>

                                                <tr id="trPartyName" runat="server">
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Party Name" runat="server"></asp:Label>

                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtPartyNameForCashMemo" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteTxtPartyNameForCashMemo" runat="server" TargetControlID="TxtPartyNameForCashMemo"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>



                                                    </td>
                                                </tr>

                                                <tr id="trpartyaddress" runat="server">
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" ID="lblPartyAddress" Text="Party Address" runat="server"></asp:Label>

                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtPartyAddress" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="P.O. NO." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtPONo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="P.O Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtPODate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtServiceDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                          ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <%--<asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtServiceDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderServiceDate" Format="dd-MM-yyyy" TargetControlID="TxtPODate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Dispatched Throught" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtTransportName" CssClass="form-control" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderDispatcher" runat="server" TargetControlID="TxtTransportName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetTransporterName">
                                                        </ajax:AutoCompleteExtender>

                                                        <%--                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtTransportName" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>




                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Vehicle No." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtVehclieNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:Button ID="BtnDriverDetails" runat="server" Text="Driver Details" Height="33px" Width="180px" OnClick="BtnDriverDetails_Click" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="L.R. NO." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtLRNo" CssClass="form-control" runat="server"></asp:TextBox>

                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="L.R. Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtLRDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtLRDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                          ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <%--<asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtLRDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtLRDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="REMARK" runat="server"></asp:Label>
                                                    </td>

                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtRemark" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
                                    </div>


                                    <div style="float: left; height: auto; width: 40%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <%--    <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Excise Inv.No." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtExciseInvNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                     <td></td>
                                                     <td colspan="3" style="padding-left: 10px;">
                                                        <asp:Button runat="server" ID="BtnAllConirm" OnClick="BtnAllConirm_Click" Text="All Confirm" />
                                                      </td>
                                                    </tr>--%>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Inv.No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtInvoiceNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>


                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="D.C.No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtDCNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Inv.Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtInvoiceDate" OnTextChanged="TxtInvoiceDate_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtInvoiceDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                          ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldTxtInvoiceDate" runat="server"
                                                            ControlToValidate="TxtInvoiceDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderInvoiceDate" Format="dd-MM-yyyy" TargetControlID="TxtInvoiceDate"></ajax:CalendarExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="D.C.Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtDCDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtDCDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                          ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <%--<asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtDCDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender5" Format="dd-MM-yyyy" TargetControlID="TxtDCDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <%--<td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Rec.Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">
                                                     <asp:TextBox ID="TxtReceivedDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                     

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtReceivedDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender3" Format="dd-MM-yyyy" TargetControlID="TxtReceivedDate"></ajax:CalendarExtender>
                                                    </td>--%>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Due Days" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtDueDays" OnTextChanged="TxtDueDays_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Confirm ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:DropDownList ID="DdlConfirmFlag" OnTextChanged="DdlConfirmFlag_TextChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                </tr>

                                                <tr>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Due Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtDueDate" OnTextChanged="TxtDueDate_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--<asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtDueDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender4" Format="dd-MM-yyyy" TargetControlID="TxtDueDate"></ajax:CalendarExtender>
                                                    </td>


                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Confirm Date" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtConfirmDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender6" Format="dd-MM-yyyy" TargetControlID="TxtConfirmDate"></ajax:CalendarExtender>
                                                    </td>

                                                </tr>

                                                <tr>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="E-Way Bill" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtEWayBill" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Confirm By" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConfirmBy" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>
                                                <tr>



                                                    <td></td>
                                                    <td style="padding-left: 5px;">
                                                        <asp:Button ID="BtnAddChallan" runat="server" Text="Add Challan" Width="170px" Height="33px" OnClick="BtnAddChallan_Click" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>

                                                    <td></td>
                                                    <td>
                                                        <asp:Button runat="server" ID="btnViewInvoive" OnClick="btnViewInvoive_Click" Text="View-Invoice" OnClientClick="aspnetForm.target ='_blank';" />
                                                    </td>

                                                </tr>


                                            </table>
                                        </div>
                                    </div>


                                    <div style="float: left; height: auto; width: 20%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="GST No." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtGstNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Party Type" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlPartyType" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                            <asp:ListItem Value="LOCAL">LOCAL</asp:ListItem>
                                                            <asp:ListItem Value="CST">CST</asp:ListItem>
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator8" runat="server" InitialValue="0"
                                                            ControlToValidate="DdlPartyType" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Sales Type" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlSalesType" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                            <asp:ListItem Value="R">Retail Invoice</asp:ListItem>
                                                            <asp:ListItem Value="T">Tax Invoice</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Register Type" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlRegisterType" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                            <asp:ListItem Value="A">Against C Form</asp:ListItem>
                                                            <asp:ListItem Value="W">Without C Form</asp:ListItem>
                                                            <asp:ListItem Value="R">Register Dealer</asp:ListItem>
                                                            <asp:ListItem Value="U">Un-Register Dealer</asp:ListItem>
                                                            <asp:ListItem Value="B">Bill Of Supply</asp:ListItem>
                                                            <asp:ListItem Value="N">Non URD</asp:ListItem>
                                                            <asp:ListItem Value="S">SEZ Supplies</asp:ListItem>


                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Tax Cal.Type" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlTaxCalType" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                            <asp:ListItem Value="E">Excluding Tax</asp:ListItem>
                                                            <asp:ListItem Value="I">Including Tax</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Sold Against Form" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtSoldAgainstFrom" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Form Sr No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtFormSrNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Check Post" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtCheckPost" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Figure Flag" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlFigureFlag" runat="server" OnSelectedIndexChanged="DdlFigureFlag_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                            <asp:ListItem Value="R">Round</asp:ListItem>
                                                            <asp:ListItem Value="D">Decimal</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>


                                            </table>
                                        </div>
                                    </div>

                                    <div id="DivBarcodeViewButtons" runat="server" style="width: 45%; height: 65px; float: left;">
                                        <table class="col-md-12">
                                            <tr>
                                                <td style="padding-left: 5px;">
                                                    <asp:Button ID="BtnViewBarcode" runat="server" Text="View Barcode" Width="180px" Height="33px" OnClick="BtnViewBarcode_Click" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                </td>
                                                <td style="padding-left: 5px;">
                                                    <asp:Button ID="BtnAddBarcode" runat="server" Text="Add Barcode" Width="180px" Height="33px" OnClick="BtnAddBarcode_Click" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                </td>
                                                <td style="padding-left: 5px;">
                                                    <asp:Button ID="BtnReturnBarcode" runat="server" Text="Return Barcode" Width="180px" Height="33px" OnClick="BtnReturnBarcode_Click" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                </td>

                                            </tr>
                                        </table>
                                    </div>

                             <%--   </ContentTemplate>
                                 
                            </asp:UpdatePanel>--%>

                            <div style="clear: both; height: 10px;">
                            </div>


                            <div class="panel panel-widget top-grids">
                                <div class="chute chute-center text-center">

                                  <%--  <asp:UpdatePanel ID="UpdPnl2" runat="server" UpdateMode="Conditional">
                                       
                                        <ContentTemplate>--%>

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: brown; text-align: left">Items Detail</div>
                                                <asp:GridView ID="GvStockRecDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvStockRecDetails_PageIndexChanging" OnRowDataBound="GvStockRecDetails_RowDataBound"
                                                    PageSize="10" ShowFooter="true">

                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="SR.NO.">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SR") %>' />
                                                                <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />


                                                                <asp:HiddenField ID="HfRefTranDate" runat="server" Value='<%#Bind("REF_TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfRefTranNo" runat="server" Value='<%#Bind("REF_TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfRefSrNo" runat="server" Value='<%#Bind("REF_SRNO") %>' />

                                                                <asp:HiddenField ID="HfDC_Trandate" runat="server" Value='<%#Bind("DC_TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfDC_TranNo" runat="server" Value='<%#Bind("DC_TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfDC_SrNo" runat="server" Value='<%#Bind("DC_SRNO") %>' />

                                                                <asp:HiddenField ID="HfGSTRate" runat="server" Value='<%#Bind("GST_RATE") %>' />
                                                                <asp:HiddenField ID="HfGSTAmount" runat="server" Value='<%#Bind("GST_AMT") %>' />


                                                                <asp:HiddenField ID="HfAmount" runat="server" Value='<%#Bind("AMT") %>' />
                                                                <asp:HiddenField ID="HfDisAmount" runat="server" Value='<%#Bind("DIS_AMT") %>' />
                                                                <asp:HiddenField ID="HfGrossAmount" runat="server" Value='<%#Bind("G_AMT") %>' />
                                                                <asp:HiddenField ID="HfEntryType" runat="server" Value='<%#Bind("ENTRY_TYPE") %>' />



                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="CHALLAN NO." ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtChallanNo" Text='<%#Bind("CHA_NO") %>' onkeypress="return isNumber(event);" AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CHALLAN DATE" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtChallanDate" Text='<%#Bind("ChallanDate") %>' onkeypress="return isNumber(event);" AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="GRN NO." ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtGRNNo" Text='<%#Bind("SERIALNO") %>' onkeypress="return isNumber(event);" AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT CODE">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtProductCode" ForeColor="Blue" Style="width: 100px;" OnTextChanged="TxtProductCode_TextChanged" runat="server" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtProductCode"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetProductCode">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="HSN CODE" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtHSNCode" onkeypress="return isNumber(event);" Text='<%#Bind("HSN_NO") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT NAME">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtProductName" ForeColor="Blue" Style="width: 350px;" OnTextChanged="TxtProductName_TextChanged" runat="server" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtProductName"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetStockName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT DESCRIPTION" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtProductDescrption" Style="width: 300px;" Text='<%#Bind("PRODUCT_DESC") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="QTY" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtQty" OnTextChanged="TxtQty_TextChanged1" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("QTY") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalQty" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RATE" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtRate" OnTextChanged="TxtRate_TextChanged1" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("RATE") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="DIS %" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtDisRate" OnTextChanged="TxtDisRate_TextChanged" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("DIS_PER") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CGST %" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtCGSTRate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("CGST_RATE") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CGST AMOUNT" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtCGSTAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("CGST_AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblCGSTSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SGST %" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtSGSTRate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("SGST_RATE") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SGST AMOUNT" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtSGSTAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("SGST_AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSGSTSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="IGST %" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtIGSTRate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("IGST_RATE") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="IGST AMOUNT" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtIGSTAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("IGST_AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblIGSTSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="TOTAL AMOUNT" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtTotalAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("T_AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="BtnDeleteRowModelStockDetailGrid" runat="server" OnClick="BtnDeleteRowModelStockDetailGrid_Click" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Button ID="BtnAddRowModelStockDetailGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelStockDetailGrid_Click" CausesValidation="false" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>


                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                     <%--   </ContentTemplate>
                                       
                                    </asp:UpdatePanel>--%>
                                </div>
                            </div>


                            <div style="clear: both; height: 10px;">
                            </div>

                            <div class="panel panel-widget top-grids">
                                <div class="chute chute-center text-center">

                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: brown; text-align: left">Charges Detail</div>
                                                <asp:GridView ID="GvChagresTranDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvChagresTranDetails_PageIndexChanging" OnRowDataBound="GvChagresTranDetails_RowDataBound"
                                                    PageSize="10" ShowFooter="true">

                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="SR.NO.">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SR") %>' />
                                                                <asp:HiddenField ID="HfChargesCode" runat="server" Value='<%#Bind("CCODE") %>' />

                                                                <%-- <asp:HiddenField ID="HfChargesAmount" runat="server" Value='<%#Bind("AMT") %>' />--%>
                                                                <asp:HiddenField ID="HfGSTRate" runat="server" Value='<%#Bind("GST_RATE") %>' />
                                                                <asp:HiddenField ID="HfGSTAmount" runat="server" Value='<%#Bind("GST_AMT") %>' />


                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="HSN CODE" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtHSNCode" onkeypress="return isNumber(event);" Text='<%#Bind("HSN_NO") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="NAME OF THE CHARGES">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtChargesName" ForeColor="Blue" Style="width: 300px;" OnTextChanged="TxtChargesName_TextChanged" runat="server" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtenderTxtChargesName" runat="server" TargetControlID="TxtChargesName"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetChargesName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="QTY" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtQty" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("QTY") %>' OnTextChanged="TxtQty_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalQty" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RATE" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtRate" OnTextChanged="TxtRate_TextChanged" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("PER") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="(+/-)">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" AutoPostBack="true" ID="TxtChargesSign" Text='<%#Bind("SIGN") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="AMT" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtChargesAmount" OnTextChanged="TxtRate_TextChanged" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumGrossAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CGST %" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtCGSTRate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("CGST_RATE") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CGST AMOUNT" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtCGSTAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("CGST_AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblCGSTSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SGST %" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtSGSTRate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("SGST_RATE") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SGST AMOUNT" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtSGSTAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("SGST_AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSGSTSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="IGST %" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtIGSTRate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("IGST_RATE") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="IGST AMOUNT" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtIGSTAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("IGST_AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblIGSTSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="TOTAL AMOUNT" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtTotalAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("T_AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="BtnDeleteRowModelChargesDetailGrid" runat="server" OnClick="BtnDeleteRowModelChargesDetailGrid_Click" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Button ID="BtnAddRowModelChargesDetailGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelChargesDetailGrid_Click" CausesValidation="false" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>


                            <div style="clear: both; height: 10px">
                            </div>

                            <asp:HiddenField ID="HfStockDetailsGridTotal" runat="server" />
                            <asp:HiddenField ID="HfChargesGridTotal" runat="server" />

                            <br />

                            <div style="width: 35%; height: 65px; float: left;">
                                <table class="col-md-12">
                                    <tr>
                                        <td align="right" style="padding-bottom: 10px;">
                                            <asp:Label CssClass="label" Text="Generate Result ?" runat="server"></asp:Label>
                                        </td>
                                        <td style="padding-left: 10px;">
                                            <asp:DropDownList ID="DdlGenerateResult" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="S">SCREEN</asp:ListItem>
                                                <asp:ListItem Value="H">HTML</asp:ListItem>
                                                <asp:ListItem Value="P">EXCEL</asp:ListItem>
                                                <asp:ListItem Value="P">PRINTER</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td align="right" style="padding-bottom: 10px;">
                                            <asp:Label CssClass="label" Text="Print Invoice Copy ?" runat="server"></asp:Label>
                                        </td>

                                        <td style="padding-left: 10px;">
                                            <asp:DropDownList ID="DdlPrintInvoiceCopy" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="A">All Copy</asp:ListItem>
                                                <asp:ListItem Value="O">Original for Receipeint</asp:ListItem>
                                                <asp:ListItem Value="D">Duplicate For Supplier/Transporter</asp:ListItem>
                                                <asp:ListItem Value="T">Triplicate For Supplier</asp:ListItem>
                                                <asp:ListItem Value="E">Extra Copy</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>




                            <asp:UpdatePanel ID="UpdateTotalAmount" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div style="width: 15%; height: 70px; float: right;">

                                        <table class="col-md-12">
                                            <tr>
                                                <td>
                                                    <asp:Label CssClass="label" Text="R.O Amt" runat="server"></asp:Label>
                                                </td>
                                                <td style="padding-left: 10px; padding-bottom: 5PX">
                                                    <asp:TextBox ID="TxtROamt" CssClass="form-control grdleftalign" Style="text-align: right;" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label CssClass="label" Text="Net Amt" ForeColor="Red" runat="server"></asp:Label>
                                                </td>
                                                <td style="padding-left: 10px;">
                                                    <asp:TextBox ID="TxtNetAmt" ForeColor="Red" CssClass="form-control" Style="text-align: right;" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div style="clear: both; height: 10px">
                            </div>

                            <div class="col-md-12">
                                <div class="col-md-2 bs-component mb10">
                                    <asp:Button ID="btnClear" runat="server" Text="EXIT" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnClear_Click"
                                        CausesValidation="false" />
                                </div>
                                <div class="col-md-2 bs-component mb10">
                                    <asp:Button ID="BtncallUpd" Text="UPDATE" runat="server" OnClick="BtncallUpd_Click" CssClass="btn btn-lg btn-primary btn-block" />
                                </div>

                                <div class="col-md-2 bs-component mb10">
                                    <asp:Button ID="Btncalldel" runat="server" Text="DELETE" OnClick="Btncalldel_Click" CssClass="btn btn-lg btn-primary btn-block" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <div id="DivView" runat="server" class="grids">
        <div class="panel panel-widget top-grids">
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />

            <div style="float: right;">
                <asp:Label CssClass="label" Style="color: red;" Text="Search By Invoice No./Customer Account" runat="server"></asp:Label><br />
                <asp:TextBox ID="TxtSearch" runat="server" Style="width: 100%;" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
        </div>

        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBranchCode" runat="server" />
        <asp:HiddenField ID="HfTranDate" runat="server" />
        <asp:HiddenField ID="HfTranNo" runat="server" />
        <asp:HiddenField ID="HfTranType" runat="server" />
        <asp:HiddenField ID="HfTrnType" runat="server" />
        <asp:HiddenField ID="HfTaxType" runat="server" />

        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="table-responsive">
                    <asp:GridView ID="GvTaxInvoiceMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvTaxInvoiceMaster_PageIndexChanging" OnRowCommand="GvTaxInvoiceMaster_RowCommand" OnRowDataBound="GvTaxInvoiceMaster_RowDataBound"
                        PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                            <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <asp:HiddenField ID="HfTranDateGrid" runat="server" Value='<%#Bind("TRAN_DATE")%>' />
                                    <asp:HiddenField ID="HfTranNoGrid" runat="server" Value='<%#Bind("TRAN_NO")%>' />

                                    <asp:HiddenField ID="hfREC_UPD" runat="server" Value='<%#Bind("REC_UPD")%>' />
                                    <asp:HiddenField ID="hfREC_DEL" runat="server" Value='<%#Bind("REC_DEL")%>' />
                                    <asp:HiddenField ID="hfREC_INS" runat="server" Value='<%#Bind("REC_INS")%>' />

                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                    <%--    <a href="JavaScript:divexpandcollapse('div<%# Eval("TRAN_NO") %>');">
                                        <img id='imgdiv<%# Eval("TRAN_NO") %>' width="15px" border="0" src="/images/plus.gif" />
                                    </a>--%>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="INV.DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblInvoiceDate" runat="server" Text='<%#Bind("INV_DT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="INV.NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblInvoiceNo" runat="server" Text='<%#Bind("INV_NUMBER") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CUSTOMER A/C">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblCustPartyName" runat="server" Text='<%#Bind("AccountNameDebit") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PARTY TYPE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblPartyType" runat="server" Text='<%#Bind("PARTY_TYPE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SALES TYPE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblSalesType" runat="server" Text='<%#Bind("SALES_TYPE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="TOTAL AMT.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblTotalAmount" runat="server" Text='<%#Bind("GROSS_AMT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="VAT/GST AMT.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblVatGstAmount" runat="server" Text='<%#Bind("GST_AMT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="OTHERS AMT.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblOtherAmount" runat="server" Text='<%#Bind("OA_AMT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="NET AMT.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblNetAmount" runat="server" Text='<%#Bind("NET_AMT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CONFIRM ?">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblConfirmFlag" runat="server" Text='<%#Bind("CONF_FLAG") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>


    <script src="js/proton.js"></script>

    <div class="modal fade" tabindex="-1" id="CmpDeleteSelection" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">DELETE SALES TAX INVOICE ISSUE TO BRANCH DETAILS</h4>
                </div>
                <div class="modal-body">

                    <span>Are you sure want to delete...!!!</span>
                    <br />

                    <div id="Div5" runat="server" class="grids">

                        <div class="panel panel-widget top-grids">

                            <asp:Button ID="btnDelete" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnDelete_Click" CausesValidation="false" />
                            <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">NO</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function HideModel() {
            $("#CmpDeleteSelection").modal('hide');
        }

        function ShowModel() {

            $("#CmpDeleteSelection").modal('show');

        }
    </script>


    <script src="js/proton.js"></script>

    <div class="modal fade" tabindex="-1" id="CmpUpdateSelection" data-keyboard="false" data-backdrop="static">

        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">UPDATE SALES TAX INVOICE TO BRANCH DETAILS</h4>
                </div>
                <div class="modal-body">


                    <span>Are you sure want to update...!!!</span>
                    <br />

                    <div id="Div6" runat="server" class="grids">

                        <div class="panel panel-widget top-grids">
                            <asp:Button ID="btnSave" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnSave_Click" />
                            <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">NO</button>
                        </div>

                    </div>
                </div>


            </div>
        </div>
    </div>

    <script type="text/javascript">
        function HideModel1() {
            $("#CmpUpdateSelection").modal('hide');
        }

        function ShowModel1() {

            $("#CmpUpdateSelection").modal('show');

        }
    </script>



    <script src="js/proton.js"></script>

    <div class="modal fade" tabindex="-1" id="CmpDriverDetails" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" style="color: red">Driver Details</h4>
                </div>

                <div class="modal-body">
                    <div id="Div7" runat="server" class="grids">
                        <div class="panel panel-widget top-grids">


                            <table style="width: 80%;" border="0">
                                <tr>
                                    <td align="right" style="padding-bottom: 10px;">
                                        <asp:Label CssClass="label" Text="Driver Name" runat="server"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-left: 10px;">
                                        <asp:TextBox ID="TxtDriverName" CssClass="form-control" runat="server"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="right" style="padding-bottom: 10px;">
                                        <asp:Label CssClass="label" Text=" Driver Address" runat="server"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-left: 10px;">
                                        <asp:TextBox ID="TxtDriverAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="right" style="padding-bottom: 10px;">
                                        <asp:Label CssClass="label" Text="M.D.L No." runat="server"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-left: 10px;">
                                        <asp:TextBox ID="TxtMDLNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="right" style="padding-bottom: 10px;">
                                        <asp:Label CssClass="label" Text="Issuing Authority State" runat="server"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-left: 10px;">
                                        <asp:TextBox ID="TxtMDLState" CssClass="form-control" runat="server"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                        <button type="button" style="float: right;" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK</button>
                                    </td>
                                </tr>
                            </table>


                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function HideModelDriverDetails() {
            $("#CmpDriverDetails").modal('hide');
        }

        function ShowModelDriverDetails() {

            $("#CmpDriverDetails").modal('show');

        }

    </script>

    <script type="text/javascript">
        function HideModelDeliveryChallan() {

            $("#CmpAddChallan").modal('hide');
        }

        function ShowModelDeliveryChallan() {

            $("#CmpAddChallan").modal('show');

        }
        function SelectionAlert() {

            alert("Must be select Party Customer Name !");

        }
    </script>


    <script src="js/proton.js"></script>


    <div class="modal fade" tabindex="-1" id="CmpAddChallan" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title" style="color: red">Delivery Challan</h4>
                </div>
                <div class="modal-body">

                    <div id="Div1" runat="server" class="grids">

                        <div class="panel panel-widget top-grids">
                            Find
                            <asp:TextBox ID="TxtAMCQuoatationTerms" CssClass="form-control" runat="server"></asp:TextBox>


                            <div class="h5" style="color: brown; text-align: left">Delivery Challan Details</div>
                            <asp:UpdatePanel ID="UpModalAddChallan" runat="server">
                                <ContentTemplate>

                                    <asp:GridView ID="GvAddDeliveryChallan" CssClass="table table-vcenter table-condensed table-bordered"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvAddDeliveryChallan_PageIndexChanging" OnRowCommand="GvAddDeliveryChallan_RowCommand"
                                        PageSize="10" ShowFooter="true">
                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="Sr.No.">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HfDCTransDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                    <asp:HiddenField ID="HfDCTransNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />


                                                    <%#Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Challan No">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label grdcenteralign" ID="lblChallanNo" runat="server" Text='<%#Bind("CHA_NO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="GRN No">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label grdcenteralign" ID="lblGRNNo" runat="server" Text='<%#Bind("SERIALNO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Challan Date">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label grdcenteralign" ID="lblChallanDate" runat="server" Text='<%#Bind("ChallanDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <%-- <asp:Button ID="btnSelect" OnClick="btnSelect_Click" runat="server" CausesValidation="false" CommandName="Selecta" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="View" Text="SELECT" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>   --%>

                                                    <asp:CheckBox ID="ChkChallanNo" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                    </asp:GridView>


                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnAddChallanProcess" />
                                    <%--     <asp:PostBackTrigger ControlID="TxtPartyNameDebit" />--%>
                                    <asp:PostBackTrigger ControlID="GvAddDeliveryChallan" />


                                </Triggers>

                            </asp:UpdatePanel>
                            <center> <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK </button> </center>
                            <asp:Button ID="btnAddChallanProcess" runat="server" Text="Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnAddChallanProcess_Click" CausesValidation="false" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <script src="js/proton.js"></script>

    <div class="modal fade" tabindex="-1" id="CmpViewBarcode" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" style="color: blue">Barcode Details</h4>

                </div>

                <div class="modal-body">
                    <div id="Div4" runat="server" class="grids">
                        <div class="panel panel-widget top-grids">
                            <asp:UpdatePanel ID="UpdateBarcode" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblbarduperror" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:GridView ID="GvViewBarcode" CssClass="table table-vcenter table-condensed table-bordered" OnPageIndexChanging="GvViewBarcode_PageIndexChanging"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                        PageSize="10" ShowFooter="true">
                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="Sr.No.">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HfStockcode" runat="server" Value='<%#Bind("SCODE") %>' />
                                                    <asp:HiddenField ID="HfBarTranDate" runat="server" Value='<%#Bind("BAR_TRAN_DATE") %>' />
                                                    <asp:HiddenField ID="HfBarTranNo" runat="server" Value='<%#Bind("BAR_TRAN_NO") %>' />
                                                    <asp:HiddenField ID="HfBarSrNo" runat="server" Value='<%#Bind("BAR_SRNO") %>' />
                                                    <%#Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Barcode">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="TxtBarcode" OnTextChanged="TxtBarcode_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("BARCODE") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Qty.">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="TxtQty" runat="server" Text='<%#Bind("QTY") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                </ItemTemplate>
                                                <FooterStyle HorizontalAlign="Right" />
                                                <FooterTemplate>
                                                    <asp:Button ID="BtnAddRowModelBarCode_ViewGrid" OnClick="BtnAddRowModelBarCode_ViewGrid_Click" runat="server" Text="Add New Row" CausesValidation="false" />
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>

                                    <%--  <asp:FileUpload ID="FileUpload1" runat="server"/> --%>
                                    <asp:Button ID="btnAddBarcodeProcess" runat="server" Text="Add Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnAddBarcodeProcess_Click" CausesValidation="false" />
                                    <%--     <asp:Button ID="btnUploadBarcodeProcess" runat="server" Text="Upload Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnUploadBarcodeProcess_Click" CausesValidation="false" />--%>
                                    <asp:Button ID="btnReturnBarcodeProcess" runat="server" Text="Return Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnReturnBarcodeProcess_Click" CausesValidation="false" />

                                    <button type="button" class="btn btn-primary" style="float: right;" data-dismiss="modal" value="NO">BACK </button>


                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="BtnViewBarcode" EventName="click" />
                                    <asp:AsyncPostBackTrigger ControlID="BtnAddBarcode" EventName="click" />
                                    <asp:AsyncPostBackTrigger ControlID="BtnReturnBarcode" EventName="click" />
                                    <%--<asp:AsyncPostBackTrigger ControlID="btnUploadBarcodeProcess" EventName="click" />--%>
                                    <%--<asp:PostBackTrigger ControlID = "btnUploadBarcodeProcess" />--%>
                                </Triggers>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        function HideModelViewBarcode() {
            $("#CmpViewBarcode").modal('hide');
        }

        function ShowModelViewBarcode() {

            $("#CmpViewBarcode").modal('show');

        }

    </script>



</asp:Content>
