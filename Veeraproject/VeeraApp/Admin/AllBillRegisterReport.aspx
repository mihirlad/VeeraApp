<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="AllBillRegisterReport.aspx.cs" Inherits="VeeraApp.Admin.AllBillRegisterReport" %>

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
                    <h4 id="H1" runat="server">PURCHASE REGISTER</h4>
                     <h4 id="H2" runat="server">GENERAL PURCHASE REGISTER</h4>
                     <h4 id="H3" runat="server">SALES + SERVICE BILL REGISTER</h4>
                    <h4 id="H4" runat="server">SERVICE BILL REGISTER</h4>
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

                                    <div style="float: center; height: auto; width: 40%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">

                                               <asp:HiddenField ID="HfTranType" runat="server" />
                                                <asp:HiddenField ID="HfTrnType" runat="server" />

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="From Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtFromDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ValidationGroup="ldgrgroupval"
                                                            ControlToValidate="TxtFromDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderJobCardDate" Format="dd-MM-yyyy" TargetControlID="TxtFromDate"></ajax:CalendarExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="To Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtToDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ValidationGroup="ldgrgroupval"
                                                            ControlToValidate="TxtToDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtToDate"></ajax:CalendarExtender>
                                                    </td>

                                                </tr>

                                                 <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Party Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:HiddenField ID="HfACODE" runat="server" />
                                                        <asp:TextBox ID="TxtAccountName" OnTextChanged="TxtAccountName_TextChanged" AutoPostBack="true" CssClass="form-control" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtAccountName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>

                                                      <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server"
                                                            ControlToValidate="TxtAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Category Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:HiddenField ID="HfCATCODE" runat="server" />
                                                        <asp:TextBox ID="TxtCategoryName" OnTextChanged="TxtCategoryName_TextChanged" ForeColor="Blue" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="TxtCategoryName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetCategoryName">
                                                        </ajax:AutoCompleteExtender>
                                                    </td>
                                                </tr>



                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Product Code" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:HiddenField ID="HfProductCode" runat="server" />
                                                        <asp:TextBox ID="TxtProductCode" OnTextChanged="TxtProductCode_TextChanged" ForeColor="Blue" CssClass="form-control" runat="server"  AutoPostBack="true"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtProductCode"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetProductCode">
                                                        </ajax:AutoCompleteExtender>
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Product Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:HiddenField ID="HfSCODE" runat="server" />
                                                        <asp:TextBox ID="TxtProductName" OnTextChanged="TxtProductName_TextChanged" ForeColor="Blue" CssClass="form-control" runat="server" AutoPostBack="true"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="TxtProductName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetStockName">
                                                        </ajax:AutoCompleteExtender>
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Branch Name" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="3">
                                                         <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control">
                                                         </asp:DropDownList>

                                                <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server" InitialValue="0" ValidationGroup="ldgrgroupval"
                                                        ControlToValidate="DdlBranch" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>

                                                </tr>

                                                
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="View Result ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:DropDownList ID="DdlViewResult" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="S" Selected="True">SCREEN</asp:ListItem>
                                                            <asp:ListItem Value="P">PDF</asp:ListItem>
                                                            <asp:ListItem Value="H">HTML</asp:ListItem>
                                                            <asp:ListItem Value="W">WORD [RTTF]</asp:ListItem>

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

       <center> 
     
              <div style="float: center; height: auto; width: 40%;">
                   <div class="col-md-12">
                       <table class="col-md-4">
                           
                           <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnItemWisePartyWise" runat="server" Text="ItemWise + PartyWise Register" CssClass="btn btn-lg btn-primary btn-block" OnClick="BtnItemWisePartyWise_Click" CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>
                              </td>
                           </tr>

                            <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnPartyWiseItemWise" runat="server" Text="PartyWise + ItemWise Register" CssClass="btn btn-lg btn-primary btn-block" OnClick="BtnPartyWiseItemWise_Click"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>
                              </td>
                           </tr>

                          <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnPartyWiseBillWise" runat="server" Text="PartyWise + BillWise Register" CssClass="btn btn-lg btn-primary btn-block" OnClick="BtnPartyWiseBillWise_Click"  CausesValidation="true" />    <%--OnClientClick="aspnetForm.target ='_blank';"--%>
                              </td>
                           </tr>

                      <tr>
                        <td style="padding-bottom: 10px;">
                            <asp:Button ID="BtnExit" runat="server" Text="Exit" OnClick="BtnExit_Click" CssClass="btn btn-lg btn-primary btn-block" CausesValidation="false" />
                        </td>
                          </tr>

                      </table>
                    </div>
                </div>

       </center>

</asp:Content>
