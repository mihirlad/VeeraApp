<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="AccountPartyWiseOSReport.aspx.cs" Inherits="VeeraApp.Admin.AccountPartyWiseOSReport" %>

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
                    <h4 id="hdForPartyWiseAgeing" runat="server">PARTY WISE AGEING</h4>
                      <h4 id="hdForPartyWiseOutstanding" runat="server">PARTY WISE O/S</h4>
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

                                                <tr>
                                                    
                                                  <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="As On Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtAsOnDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--<asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ValidationGroup="ldgrgroupval"
                                                            ControlToValidate="TxtAsOnDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtAsOnDate"></ajax:CalendarExtender>
                                                    </td>

                                                   <td align="right" style="padding-bottom: 10px;" id="tdformatlabel" runat="server">
                                                        <asp:Label CssClass="label" Text="View Ageing Format" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3" id="tdAgeingFormatDdl" runat="server">  
                                                        <asp:DropDownList ID="DdlViewAgeingFormat" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="30" Selected="True">30 Days Format</asp:ListItem>
                                                            <asp:ListItem Value="60">60 Days Format</asp:ListItem>
                                                            <asp:ListItem Value="90">90 Days Format</asp:ListItem>
                                                              <asp:ListItem Value="120">120 Days Format</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                </tr>


                                                 <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Name of the Account" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:HiddenField ID="HfACODE" runat="server" />
                                                        <asp:TextBox ID="TxtAccountName" OnTextChanged="TxtAccountName_TextChanged" AutoPostBack="true" CssClass="form-control" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtAccountName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>

                                                     <%--   <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ValidationGroup="ldgrgroupval"
                                                            ControlToValidate="TxtAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>

                                                      <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Person Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:HiddenField ID="HfBCODE" runat="server" />
                                                        <asp:TextBox ID="TxtPersonName" OnTextChanged="TxtPersonName_TextChanged"  AutoPostBack="true" CssClass="form-control" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtPersonName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetPersonName">
                                                        </ajax:AutoCompleteExtender>

                                                     <%--   <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ValidationGroup="ldgrgroupval"
                                                            ControlToValidate="TxtAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>

                                                  <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Report Format" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:DropDownList ID="DdlReportFormat" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="D" Selected="True">DETAILS</asp:ListItem>
                                                            <asp:ListItem Value="S">SUMMARY</asp:ListItem>
                                                            <asp:ListItem Value="L">LEDGER</asp:ListItem>
                                                              <asp:ListItem Value="PD">PERSONWISE DETAILS</asp:ListItem>
                                                            <asp:ListItem Value="PS">PERSONWISE SUMMARY</asp:ListItem>
                                                             <asp:ListItem Value="PL">PERSONWISE LEDGER</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                 </tr>

                                                  <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Branch Name" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="3">
                                                         <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control">
                                                         </asp:DropDownList>

                                                  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" InitialValue="0" ValidationGroup="ldgrgroupval"
                                                        ControlToValidate="DdlBranch" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>

                                                </tr>

                                                 <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="View Report" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:DropDownList ID="DdlViewReport" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="D" Selected="True">DEBTORS</asp:ListItem>
                                                            <asp:ListItem Value="C">CREDITORS</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                 </tr>


                                                
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Generate Screen ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:DropDownList ID="DdlGenerateScreen" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="S" Selected="True">SCREEN</asp:ListItem>
                                                            <asp:ListItem Value="P">PDF</asp:ListItem>
                                                            <asp:ListItem Value="H">HTML</asp:ListItem>
                                                            <asp:ListItem Value="w">WORD[RTF]</asp:ListItem>
                                                             <asp:ListItem Value="T">Text</asp:ListItem>
                                                             <asp:ListItem Value="T">EMAIL</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                </table>
                                            </div>
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
