<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="Stock_Issue_ToBranch.aspx.cs" Inherits="VeeraApp.Admin.Stock_Issue_ToBranch" %>

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
                    <h4>STOCK ISSUE TO BRANCH</h4>
                </div>
            </div>
        </div>
    </div>

    <%--  <div style="clear: both; height: 10px">
    </div>--%>

      <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">

                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">

                            <asp:UpdatePanel ID="updpnl" runat="server">
                                <ContentTemplate>

                                 <div class="h5" style="color: brown">Stock Issue To Branch Master</div>

                                    <div style="float: left; height: auto; width: 30%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Challan No." runat="server"></asp:Label>
                                                    </td>
                                                       <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtChallanNo" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server"
                                                            ControlToValidate="TxtChallanNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>

                                                   <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Challan Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtChallanDate"  AutoPostBack="true"  CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtValidityDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                          ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtChallanDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderChallanDate" Format="dd-MM-yyyy" TargetControlID="TxtChallanDate"></ajax:CalendarExtender>
                                                    </td>
                                                    </tr>

                                                <tr>
                                                     <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="FROM BRANCH" runat="server"></asp:Label>
                                                    </td>

                                                      <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtFromBranch" CssClass="form-control" runat="server"></asp:TextBox>
                                                      </td>
                                                </tr>

                                                 <tr>
                                                     <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="TO BRANCH" ForeColor="Blue" runat="server"></asp:Label>
                                                     </td>

                                                      <td colspan="3" style="padding-left: 10px;">
                                                          <asp:HiddenField ID="HfToBranchCode" runat="server" />
                                                        <asp:TextBox ID="TxtToBranch" CssClass="form-control" OnTextChanged="TxtToBranch_TextChanged" AutoPostBack="true" ForeColor="Blue" runat="server"></asp:TextBox>

                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderTxtToBranch" runat="server" TargetControlID="TxtToBranch"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetBranchName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server"
                                                            ControlToValidate="TxtToBranch" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                                        <asp:Label CssClass="label" Text="REMARK" runat="server"></asp:Label>
                                                    </td>

                                                      <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtRemark" CssClass="form-control" runat="server"></asp:TextBox>
                                                      </td>
                                                </tr>

                                                </table>
                                            </div>
                                        </div>


                                      <div style="float: left; height: auto; width: 30%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Transport" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtTransportName" CssClass="form-control" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderDispatcher" runat="server" TargetControlID="TxtTransportName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetTransporterName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtTransportName" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                                        <asp:Label CssClass="label" Text="L.R No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtLRNumber" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="L.R Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtLRDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtValidityDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                              ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                      <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server"
                                                            ControlToValidate="TxtLRDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderLRDate" Format="dd-MM-yyyy" TargetControlID="TxtLRDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                 <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Delivered By" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlDeliveredBy" runat="server" ForeColor="Blue" CssClass="form-control">
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator9" runat="server" InitialValue="0"
                                                            ControlToValidate="DdlDeliveredBy" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                 <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Checked By" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlCheckedBy" runat="server" ForeColor="Blue" CssClass="form-control">
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" InitialValue="0"
                                                            ControlToValidate="DdlCheckedBy" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                </table>
                                            </div>
                                          </div>

                                     <div style="float: left; height: auto; width: 40%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="GST Applicable ?" runat="server"></asp:Label>
                                                    </td>
                                                     <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlGSTApplicable" OnSelectedIndexChanged="DdlGSTApplicable_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    </tr>

                                                  <tr>
                                                       <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Inv.No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtInvoiveNo" CssClass="form-control" runat="server"></asp:TextBox>                        
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Received ?" runat="server"></asp:Label>
                                                    </td>
                                                     <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlReceivedFlag" OnSelectedIndexChanged="DdlReceivedFlag_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                      </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Inv.Date" runat="server"></asp:Label>
                                                    </td>
                                                                                               
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtInvoiveDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                              <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtConfirmDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                      ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <%--       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderConfirmDate" Format="dd-MM-yyyy" TargetControlID="TxtInvoiveDate"></ajax:CalendarExtender>
                                                    </td>

                                                     <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Received Date" runat="server"></asp:Label>
                                                    </td>
                                                                                               
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtReceivedDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtReceivedDate"></ajax:CalendarExtender>
                                                    </td>
                                                 </tr>

                                                 <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="E-Way Bill No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtEWayBillNo" CssClass="form-control" runat="server"></asp:TextBox>                        
                                                    </td>

                                                      <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Received By" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtReceivedBy" CssClass="form-control" runat="server"></asp:TextBox>                        
                                                    </td>
                                                 </tr>

                                                <tr>
                                                     <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Generate Result ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlGenerateResult" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="S">SCREEN</asp:ListItem>
                                                            <asp:ListItem Value="P" Selected="True">PDF</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td></td>
                                                     <td colspan="3" style="padding-left: 10px;">
                                                        <asp:Button runat="server" ID="BtnViewInvioce" OnClientClick="aspnetForm.target ='_blank';" OnClick="BtnViewInvioce_Click" Text="View-Invoice" />
                                                     </td>
                                                </tr>

                                                  <tr>
                                                     <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Generate Result ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlPrintInvoiceCopy" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="A">All Copy</asp:ListItem>
                                                            <asp:ListItem Value="O">Original For Receipient</asp:ListItem>
                                                            <asp:ListItem Value="D">Dulplicate For Supplier /Transporter</asp:ListItem>
                                                            <asp:ListItem Value="T">Triplicate For Supplier</asp:ListItem>
                                                             <asp:ListItem Value="E">Extra Copy</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                      <td></td>
                                                     <td colspan="3" style="padding-left: 10px;">
                                                        <asp:Button runat="server" ID="BtnViewChallan" OnClientClick="aspnetForm.target ='_blank';" OnClick="BtnViewChallan_Click" Text="View-Challan" />
                                                      </td>

                                                </tr>

                                                </table>
                                            </div>
                                         </div>

                                      <div style="width: 45%; height: 65px; float: left;">
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

                                    </ContentTemplate>
                                </asp:UpdatePanel>

                             <div style="clear: both; height: 10px;">
                            </div>

                             <div class="panel panel-widget top-grids">
                                    <div class="chute chute-center text-center">

                                        <asp:UpdatePanel ID="UpdPnl2" runat="server">
                                            <ContentTemplate>

                                                <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                    <div class="h5" style="color: brown; text-align: left">Items Detail</div>
                                                    <asp:GridView ID="GvStockIssueDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvStockIssueDetails_PageIndexChanging" OnRowCommand="GvStockIssueDetails_RowCommand" OnRowDataBound="GvStockIssueDetails_RowDataBound"
                                                        PageSize="10" ShowFooter="true">

                                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="SR.NO.">
                                                                <ItemTemplate>
                                                                <asp:HiddenField ID="HfTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />
                                                             

                                                                <asp:HiddenField ID="HfRefTranDate" runat="server" Value='<%#Bind("REF_TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfRefTranNo" runat="server" Value='<%#Bind("REF_TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfRefSrNo" runat="server" Value='<%#Bind("REF_SRNO") %>' />


                                                                <asp:HiddenField ID="HfGSTAmount" runat="server" Value='<%#Bind("GST_AMT") %>' />
                                                                <asp:HiddenField ID="HfGSTRate" runat="server" Value='<%#Bind("GST_RATE") %>' />
                                                              

                                                                <asp:HiddenField ID="HfDisRate" runat="server" Value='<%#Bind("DIS_PER") %>' />
                                                                <asp:HiddenField ID="HfDisAmount" runat="server" Value='<%#Bind("DIS_AMT") %>' />
                                                                <asp:HiddenField ID="HfGrossAmount" runat="server" Value='<%#Bind("G_AMT") %>' />
                                                                <asp:HiddenField ID="HfStatus" runat="server" Value='<%#Bind("STATUS") %>' />

                                                                    <%#Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="PRODUCT CODE">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="TxtProductCode" ForeColor="Blue" OnTextChanged="TxtProductCode_TextChanged" Style="width: 100px;" runat="server" AutoPostBack="true"></asp:TextBox>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtProductCode"
                                                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                        ServiceMethod="GetProductCode">
                                                                    </ajax:AutoCompleteExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="PRODUCT NAME">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="TxtProductName" ForeColor="Blue" Style="width: 350px;" runat="server" OnTextChanged="TxtProductName_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtProductName"
                                                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                        ServiceMethod="GetStockName">
                                                                    </ajax:AutoCompleteExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                  

                                                            <asp:TemplateField HeaderText="QTY" ControlStyle-Width="70px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdrightalign" ID="TxtQty" OnTextChanged="TxtQty_TextChanged" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("QTY") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                                 <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalQty" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="RATE" ControlStyle-Width="70px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdrightalign" OnTextChanged="TxtRate_TextChanged" ID="TxtRate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("RATE") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                           <asp:TemplateField HeaderText="AMOUNT" ControlStyle-Width="70px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdrightalign" ID="TxtAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                              <FooterTemplate>
                                                                <asp:Label ID="lblSumAmount" ForeColor="Red" runat="server"></asp:Label>
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
                                                                    <asp:TextBox CssClass="form-control grdrightalign" ID="TxtIGSTAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("IGST_AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>                                                                </ItemTemplate>
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
                                                                    <asp:LinkButton ID="BtnDeleteRowModelIssueItemGrid" runat="server" OnClick="BtnDeleteRowModelIssueItemGrid_Click" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                                </ItemTemplate>

                                                                <FooterStyle HorizontalAlign="Right" />
                                                                <FooterTemplate>
                                                                    <asp:Button ID="BtnAddRowModelIssueItemGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelIssueItemGrid_Click" CausesValidation="false" />
                                                                </FooterTemplate>
                                                            </asp:TemplateField>


                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                            
                         

                              <asp:UpdatePanel ID="UpdateTotalAmount" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div style="width: 15%; height: 70px; float: right;">

                                      <asp:HiddenField ID="HfIssueDetailsGrid" runat="server" />

                                        <table class="col-md-12">
                                            <tr>
                                                <td align="right" style="padding-bottom: 10px;">
                                                    <asp:Label CssClass="label" Text="R.O Amt" runat="server"></asp:Label>
                                                </td>
                                                <td style="padding-left: 10px;">
                                                    <asp:TextBox ID="TxtROamt" CssClass="form-control grdleftalign" Style="text-align: right;" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="padding-bottom: 10px;">
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
                <asp:Label CssClass="label" Style="color: red;" Text="Search By Challan No./From Branch/To Branch/Delivered Person" runat="server"></asp:Label><br />
                <asp:TextBox ID="TxtSearch" runat="server" Style="width: 100%;" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
            </div>

             <asp:HiddenField ID="HfCompCode" runat="server" />
             <asp:HiddenField ID="HfBranchCode" runat="server" />
             <asp:HiddenField ID="HfTranDate" runat="server" />
             <asp:HiddenField ID="HfTranNo" runat="server" />
             <asp:HiddenField ID="HfTranType" runat="server" />
         <asp:HiddenField ID="HfRef_TranDate" runat="server" />
          <asp:HiddenField ID="HfRef_TranNo" runat="server" />
       

            <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

              <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvStockIssueBranchMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvStockIssueBranchMaster_PageIndexChanging" OnRowCommand="GvStockIssueBranchMaster_RowCommand" OnRowDataBound="GvStockIssueBranchMaster_RowDataBound"
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


                            <asp:TemplateField HeaderText=" CHALLAN DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblChallanDate" runat="server" Text='<%#Bind("ChallanDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText=" CHALLAN NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblChallanNo" runat="server" Text='<%#Bind("CHA_NO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="FROM BRANCH">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblFromBranch" runat="server" Text='<%#Bind("FromBranchName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                               <asp:TemplateField HeaderText="TO BRANCH">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblToBranch" runat="server" Text='<%#Bind("ToBranchName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="DELIVERED BY NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblDeliveryBy" runat="server" Text='<%#Bind("DeliverPersonName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="RECEIVED ?">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblReceivedFlag" runat="server" Text='<%#Bind("REC_FLAG") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="RECEIVED DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblReceivedDate" runat="server" Text='<%# Eval("REC_DATE").ToString() == "01-01-1900 00:00:00" ? "-" : Convert.ToDateTime(Eval("REC_DATE")).ToString("dd-MM-yyyy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="RECEIVED BY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblReceivedBy" runat="server" Text='<%#Bind("REC_USERID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                       </Columns>
                    </asp:GridView>
                    </div>
                  </div>
                </div>
            </div>
         </div>
    

    <script src="js/proton.js"></script>

    <div class="modal fade" tabindex="-1" id="CmpDeleteSelection" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">DELETE STOCK ISSUE TO BRANCH DETAILS</h4>
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

                    <h4 class="modal-title">UPDATE STOCK ISSUE TO BRANCH DETAILS</h4>
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
                                             <asp:Label CssClass="label" Text="Issuing Authority State"   runat="server"></asp:Label>
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
                                    <asp:GridView ID="GvViewBarcode" CssClass="table table-vcenter table-condensed table-bordered"
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
                                                    <asp:HiddenField ID="HfRate" runat="server" Value='<%#Bind("RATE") %>' />
                                                   <%-- <asp:HiddenField ID="HfAmount" runat="server" Value='<%#Bind("AMT") %>' />--%>

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
                                                    <asp:Button ID="BtnAddRowModelBarCode_ViewGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelBarCode_ViewGrid_Click" CausesValidation="false" />
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>

                                    <asp:FileUpload ID="FileUpload1" runat="server"/>            
                                    <asp:Button ID="btnAddBarcodeProcess" runat="server" Text="Add Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnAddBarcodeProcess_Click" CausesValidation="false" />                              
                                    <asp:Button ID="btnUploadBarcodeProcess" runat="server" Text="Upload Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnUploadBarcodeProcess_Click" CausesValidation="false" />
                                    <asp:Button ID="btnReturnBarcodeProcess" runat="server" Text="Return Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnReturnBarcodeProcess_Click" CausesValidation="false" />
                                    
                                    <button type="button" class="btn btn-primary" style="float: right;" data-dismiss="modal" value="NO">BACK </button>
                                   

                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="BtnViewBarcode" EventName="click" />
                                    <asp:AsyncPostBackTrigger ControlID="BtnAddBarcode" EventName="click" />
                                    <asp:AsyncPostBackTrigger ControlID="BtnReturnBarcode" EventName="click" />
                                      <%--<asp:AsyncPostBackTrigger ControlID="btnUploadBarcodeProcess" EventName="click" />--%>
                                      <asp:PostBackTrigger ControlID = "btnUploadBarcodeProcess" />
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
