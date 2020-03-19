<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="MiscellaneousStatementReport.aspx.cs" Inherits="VeeraApp.Admin.MiscellaneousStatementReport" %>

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
                    <h4 id="h1" runat="server">DAILY TRANSACTION STATEMENT</h4>
                      <h4 id="h2" runat="server">DIFFERENCE TRANSACTION STATEMENT</h4>
                      <h4 id="h3" runat="server">ACCOUNTS LIST</h4>
                      <h4 id="h4" runat="server">ACCOUNTS LABEL LIST</h4>
                     <h4 id="h5" runat="server">CUSTOMER CONTACT LIST</h4>
                     <h4 id="h6" runat="server">SUPPLIER CONTACT LIST</h4>
                     <h4 id="h7" runat="server">USER LOGIN DETAILS</h4>
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

                                      
                                                 <tr id="trUserName" runat="server">

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="User Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:HiddenField ID="HfUserCode" runat="server" />
                                                        <asp:TextBox ID="TxtUserName" AutoPostBack="true" ForeColor="blue" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtUserName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetUserName">
                                                        </ajax:AutoCompleteExtender>
                                                    </td>

                                                </tr>

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

                                               <tr id="trFromToDate" runat="server">
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="From Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtFromDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" 
                                                            ControlToValidate="TxtFromDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtFromDate"></ajax:CalendarExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="To Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtToDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" 
                                                            ControlToValidate="TxtToDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender2" Format="dd-MM-yyyy" TargetControlID="TxtToDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                 <tr id="trViewReport" runat="server">
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="View Report" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:DropDownList ID="DdlReportView" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="A" Selected="True">All Party</asp:ListItem>
                                                            <asp:ListItem Value="B">NO Email Address in Contact Details</asp:ListItem>
                                                            <asp:ListItem Value="C">NO Email Address in O/S Report</asp:ListItem>
                                                            <asp:ListItem Value="D">NO Phone No. Address in Contact Details</asp:ListItem>

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

                                                  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" InitialValue="0" ValidationGroup="ldgrgroupval"
                                                        ControlToValidate="DdlBranch" ForeColor="Red">*</asp:RequiredFieldValidator>
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
