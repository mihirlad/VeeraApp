<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="AccountLedgerReport.aspx.cs" Inherits="VeeraApp.Admin.LedgerReport" %>

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
                    <h4 id="hdForAccountLedger" runat="server">ACCOUNT LEDGER REPORTS</h4>
                      <h4 id="hdForAccountLedgerConfirmation" runat="server">STATEMENT OF A/C CONFIRMATION </h4>
                </div>
            </div>
        </div>
    </div>

    <%--<div style="clear: both; height: 10px">
    </div>--%>
    <center>
 
    <div  class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">

                <div   class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group"  style="border-bottom: none;">

                           

                            <asp:UpdatePanel ID="updpnl" runat="server">
                                <ContentTemplate>

                                  <asp:HiddenField ID="HfMenuFlag" runat="server" />
                                     <div style="float: center; height: auto; width: 45%;">
                                        <div style=" margin:5px;" class="col-md-12">
                                     <table class="col-md-12">
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
  <tr>

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
                                                </tr>
                                            </table>
                                            </div></div>
                             
                                    <div style="float: center; height: auto; width: 45%;">
                                        <div style=" margin:5px;" class="col-md-12">
                                           
                                            <br>
                                              <div class="table-responsive" style="height: 272px; overflow-y: auto">
                                                <asp:GridView ID="GvAccountNameDetails"  CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                                    PageSize="10" ShowFooter="true" width="0">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

<%--                                                        <asp:TemplateField HeaderText="Sr.No." HeaderStyle-Width="50px">
                                                            <ItemTemplate>
                       
                                                              
                                                            
                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          --%>
                                                        
                                                        <asp:TemplateField HeaderText="NAME OF THE ACCOUNT">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfACODEGrid" runat="server" Value='<%#Bind("ACODE") %>' />
                                                                <asp:TextBox ID="TxtAccountsNameGrid" OnTextChanged="TxtAccountsName_TextChanged" runat="server" Style="width: 450px;" ForeColor="Blue" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtAccountsNameGrid"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetAccountName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkSelectAccounts"  AutoPostBack="true" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        </Columns>
                                                    </asp:GridView>
                                                </div>

                                               
                                           <br />
                                            <table class="col-md-12">

                                              

                                              

                                              <%--  <tr>
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

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ValidationGroup="ldgrgroupval"
                                                            ControlToValidate="TxtAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>--%>

                             

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Transaction View" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:DropDownList ID="DdlTransactionView" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="A" Selected="True">ALL</asp:ListItem>
                                                            <asp:ListItem Value="B">BALANCE</asp:ListItem>
                                                            <asp:ListItem Value="Z">ZERO BALANCE</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Total Selection" ForeColor="red" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:TextBox ID="TxtTotalSelection" ForeColor="Red" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr id="trReportViewforLedger" runat="server">
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Report View" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:DropDownList ID="DdlReportView" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="D" Selected="True">DATE WISE(DETAILS)</asp:ListItem>
                                                            <asp:ListItem Value="M">MONTH WISE(SUMMARY)</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr id="trReportViewForLedgerLetter" runat="server">
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Report View" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:DropDownList ID="DdlReportView1" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="F1" Selected="True">FORMAT-1[DR-CR]</asp:ListItem>
                                                            <asp:ListItem Value="F2">FORMAT-2[DR-CR-BAL]</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                   <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Letter Date" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtLetterDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender3" Format="dd-MM-yyyy" TargetControlID="TxtLetterDate"></ajax:CalendarExtender>
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
        </center>
    <center>  <div class="panel panel-widget top-grids">
               <asp:Button ID="BtnRunReport" runat="server" Text="RUN" CssClass="btn btn-lg btn-primary" OnClick="BtnRunReport_Click" ValidationGroup="ldgrgroupval"  />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>
               <asp:Button ID="BtnExit" runat="server" Text="Exit" OnClick="BtnExit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />
             </div>

    </center>

</asp:Content>
