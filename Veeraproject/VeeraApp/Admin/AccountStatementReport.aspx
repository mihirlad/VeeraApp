<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="AccountStatementReport.aspx.cs" Inherits="VeeraApp.Admin.AccountStatementReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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


    <div style="clear: both; height: 10px">
    </div>

    <div class="grids">
    </div>
    <div class="panel panel-widget forms-panel">
        <div class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title">
                    <h4 id="hdForCashBookStateMent" runat="server">CASH BOOK STATEMENT</h4>
                      <h4 id="hdForBankBookStateMent" runat="server">BANK BOOK STATEMENT</h4>
                     <h4 id="hdForPaymentDetails" runat="server">PAYMENT DETAILS STATEMENT</h4>
                     <h4 id="hdForReceiptDetails" runat="server">RECEIPT DETAILS STATEMENT</h4>
                      <h4 id="hdForJounrnalVoucher" runat="server">JOURNAL VOUCHER STATEMENT</h4>
                     <h4 id="hdDForCreditNote" runat="server">CREDIT NOTE STATEMENT</h4>
                     <h4 id="hdForDebitNote" runat="server">DEBIT NOTE STATEMENT</h4>
                     <h4 id="hdForBankReconiciliation" runat="server">BANK RECONCILIATION STATEMENT</h4>
                </div>
            </div>
        </div>
    </div>

    <%--<div style="clear: both; height: 10px">
    </div>--%>

     <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">

                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">

                            <asp:UpdatePanel ID="updpnl" runat="server">
                                <ContentTemplate>

                                    <asp:HiddenField ID="HfMenuFlag" runat="server" />

                                    <div style="float: center; height: auto; width: 45%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">

                                               <tr id="trAccountGroupName" runat="server">

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Accounts Group Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:HiddenField ID="HfGroupCode" runat="server" />
                                                        <asp:TextBox ID="TxtAccountGroupName" OnTextChanged="TxtAccountGroupName_TextChanged" AutoPostBack="true" ForeColor="blue" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderGroupName" runat="server" TargetControlID="TxtAccountGroupName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountGroupName">
                                                        </ajax:AutoCompleteExtender>
                                                    </td>

                                                </tr>

                                                  <tr id="trAccountName" runat="server">
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Account Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:HiddenField ID="HfACODE" runat="server" />
                                                        <asp:TextBox ID="TxtAccountName" OnTextChanged="TxtAccountName_TextChanged" AutoPostBack="true" CssClass="form-control" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtAccountName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorAName" runat="server"
                                                            ControlToValidate="TxtAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                   <tr id="trPartyName" runat="server"> 
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Party Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:HiddenField ID="HfPartyACODE" runat="server" />
                                                        <asp:TextBox ID="TxtPartyName" OnTextChanged="TxtPartyName_TextChanged"  AutoPostBack="true" CssClass="form-control" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtPartyName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>

                                                     <%--   <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ValidationGroup="ldgrgroupval"
                                                            ControlToValidate="TxtAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="From Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtFromDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ValidationGroup="ldgrgroupval"
                                                            ControlToValidate="TxtFromDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderJobCardDate" Format="dd-MM-yyyy" TargetControlID="TxtFromDate"></ajax:CalendarExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="To Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtToDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ValidationGroup="ldgrgroupval"
                                                            ControlToValidate="TxtToDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtToDate"></ajax:CalendarExtender>
                                                    </td>

                                                </tr>

                                                
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="View Report" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:DropDownList ID="DdlReportView" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="A" Selected="True">All Record</asp:ListItem>
                                                            <asp:ListItem Value="A">Approval Record</asp:ListItem>
                                                            <asp:ListItem Value="N">Non-Approval Record</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                 <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Branch Name" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="5">
                                                         <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control">
                                                         </asp:DropDownList>

                                                <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" InitialValue="0" ValidationGroup="ldgrgroupval"
                                                        ControlToValidate="DdlBranch" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>

                                                </tr>

                                                  <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Generate Screen ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:DropDownList ID="DdlGenerateScreen" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="S" Selected="True">SCREEN</asp:ListItem>
                                                            <asp:ListItem Value="P">PDF</asp:ListItem>
                                                            <asp:ListItem Value="H">HTML</asp:ListItem>
                                                              <asp:ListItem Value="H">Word [RTF]</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                </table>
                                            </div>
                                        </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>

    <center>  <div class="panel panel-widget top-grids">
               <asp:Button ID="BtnRunReport" runat="server" Text="RUN" CssClass="btn btn-lg btn-primary" OnClick="BtnRunReport_Click" ValidationGroup="ldgrgroupval"  />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>
               <asp:Button ID="BtnExit" runat="server" Text="Exit" OnClick="BtnExit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />
             </div>

    </center>

</asp:Content>
