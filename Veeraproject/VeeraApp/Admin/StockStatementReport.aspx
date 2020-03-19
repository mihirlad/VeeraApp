<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="StockStatementReport.aspx.cs" Inherits="VeeraApp.Admin.StockStatementReport" %>

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
                    <h4>STOCK STATEMENT REPORTS</h4>
                    
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

    <div class="panel panel-widget top-grids" style="height: auto";>
         <div style="float: center; height: auto; width: 20%;">
                   <div class="col-md-12">
                       <table class="col-md-4">
                        
                           <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnStockListBranchWise" runat="server" Text="Stock List [BranchWise]" OnClick="BtnStockListBranchWise_Click" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>
        
                              </td>
                           </tr>
                           
                         <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnStockListStatement" runat="server" Text="Stock List Statement" CssClass="btn btn-lg btn-primary btn-block" OnClick="BtnStockListStatement_Click"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>
        
                              </td>
                           </tr>

                           <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnStockDetailDateWise" runat="server" Text="Detail Stock-DateWise" CssClass="btn btn-lg btn-primary btn-block" OnClick="BtnStockDetailDateWise_Click"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>
        
                              </td>
                           </tr>

                            <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnStockDetailMonthlyWise" runat="server" Text="Detail Stock-Monthly" CssClass="btn btn-lg btn-primary btn-block" OnClick="BtnStockDetailMonthlyWise_Click"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>
        
                              </td>
                           </tr>

                            <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnStockClosingDetail" runat="server" Text="Closing Stock [Details]" CssClass="btn btn-lg btn-primary btn-block" OnClick="BtnStockClosingDetail_Click"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>
        
                              </td>
                           </tr>

                            <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnMaximumStock" runat="server" Text="MaxiMum Stock" OnClick="BtnMaximumStock_Click" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>
        
                              </td>
                           </tr>

                            <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnMinimumStock" runat="server" Text="MiniMum Stock" OnClick="BtnMinimumStock_Click" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>
        
                              </td>
                           </tr>

                               <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnAllStockWithZero" runat="server" Text="ALL Stock [With Zero]" OnClick="BtnAllStockWithZero_Click" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>
        
                              </td>
                           </tr>

                           
                            <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnBranchStockOneItem" runat="server" Text="Branch Stock [One Item]" CssClass="btn btn-lg btn-primary btn-block" OnClick="BtnBranchStockOneItem_Click"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>
        
                              </td>
                           </tr>

                            <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnBarcodeStockDetailExcise" runat="server" Text="Barcode Stock [Detail-Excise]" CssClass="btn btn-lg btn-primary btn-block" OnClick="BtnBarcodeStockDetailExcise_Click"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>
        
                              </td>
                           </tr>


                     </table>
                 </div>
             </div>

        <div style="float: left; height: auto; width: 20%;">
                   <div class="col-md-12">
                       <table class="col-md-4">

                           <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnBarcodeStockStatus" runat="server" Text="Barcode Stock [STATUS]" OnClick="BtnBarcodeStockStatus_Click" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>      
                              </td>
                           </tr>

                           <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnBarcodeStockWithZeroVlaue" runat="server" Text="Barcode Stock [ZERO VALUE]" OnClick="BtnBarcodeStockWithZeroVlaue_Click" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>      
                              </td>
                           </tr>
                           
                           <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnBarcodeStockDetail" runat="server" Text="Barcode Stock [Detail]" OnClick="BtnBarcodeStockDetail_Click" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>      
                              </td>
                           </tr>

                            <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnBarcodeStockSummary" runat="server" Text="Barcode Stock [Summary]" OnClick="BtnBarcodeStockSummary_Click" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>       
                              </td>
                           </tr>

                            <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnBarcodeStockValue" runat="server" Text="Barcode Stock [Value]" OnClick="BtnBarcodeStockValue_Click" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>       
                              </td>
                           </tr>

                            <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnBarcodeStockHistory" runat="server" Text="Barcode Stock [History]" OnClick="BtnBarcodeStockHistory_Click" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>       
                              </td>
                           </tr>

                            <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnSupplierStockIndent" runat="server" Text="Supplier Stock Indent" OnClick="BtnSupplierStockIndent_Click" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>       
                              </td>
                           </tr>

                            <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnStockIndentWithLastPurchase" runat="server" OnClick="BtnStockIndentWithLastPurchase_Click" Text="Stock Indent with Last Purchase" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>       
                              </td>
                           </tr>

                            <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnSalesDC_DiffBarcodeQty" runat="server" OnClick="BtnSalesDC_DiffBarcodeQty_Click" Text="Sales DC - Diff Barcode Qty" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>       
                              </td>
                           </tr>


                            <tr>
                              <td style="padding-bottom: 10px;" colspan="3">
                                <asp:Button ID="BtnBranchIssueDC_DiffBarcodeQty" runat="server" OnClick="BtnBranchIssueDC_DiffBarcodeQty_Click" Text="Branch Issue - Diff Barcode Qty" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>       
                              </td>
                           </tr>


                           </table>
                       </div>
                  </div>

          <div style="float: left; height: auto; width: 20%;">
                   <div class="col-md-12">
                       <table class="col-md-4">
                                                 
                            <tr>
                              <td style="padding-bottom: 10px; padding-left:30px;"  colspan="3">
                                <asp:Button ID="BtnBarcodeStockPrint" runat="server" Text="Barcode Stock [Print]" OnClick="BtnBarcodeStockPrint_Click" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>       
                              </td>
                           </tr>

                           <tr>
                              <td style="padding-bottom: 10px; padding-left:30px;" colspan="3">
                                <asp:Button ID="BtnUpdateBarcodePrice" runat="server" Text="Update Barcode Price" OnClick="BtnUpdateBarcodePrice_Click" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>       
                              </td>
                           </tr>

                            <tr>
                              <td style="padding-bottom: 10px; padding-left:30px;" colspan="3">
                                <asp:Button ID="BtnDiffQtyStockWithBarcodeStock" runat="server" OnClick="BtnDiffQtyStockWithBarcodeStock_Click" Text="Diff. Qty Stock with Barcode Stock" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>       
                              </td>
                           </tr>

                            <tr>
                              <td style="padding-bottom: 10px; padding-left:30px;" colspan="3">
                                <asp:Button ID="BtnDiffStockBarcodePosting" runat="server" Text="Diff. Stock Barcode Posting" OnClick="BtnDiffStockBarcodePosting_Click" CssClass="btn btn-lg btn-primary btn-block"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>       
                              </td>
                           </tr>

                            <tr>
                              <td style="padding-bottom: 10px; padding-left:30px;" colspan="3">
                                <asp:Button ID="BtnExit" runat="server" Text="Exit" CssClass="btn btn-lg btn-primary btn-block" OnClick="BtnExit_Click"  CausesValidation="true" />   <%--OnClientClick="aspnetForm.target ='_blank';"--%>       
                              </td>
                           </tr>

                           </table>
                       </div>
              </div>


     </div>


    
<script src="js/proton.js"></script>

    <div class="modal fade" tabindex="-1" id="CmpViewBarcode" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" style="color: red">Add Barcode Details</h4>

                </div>

                <div class="modal-body">
                    <div id="Div4" runat="server" class="grids">
                        <div class="panel panel-widget top-grids">
                            <asp:UpdatePanel ID="UpdateBarcode" runat="server">
                                <ContentTemplate>

                                    <div class="table-responsive" style="height: 500px; width:300px; overflow-y: scroll">

                                        <asp:Label ID="lblbarduperror" runat="server" ForeColor="Red"></asp:Label>
                                        <div id="DivBarcodeInput" runat="server">
                                            <span style="padding-right: 5px;">Enter No.of Rows Required</span><asp:TextBox ID="TxtBarcodeInputNo" runat="server" OnTextChanged="TxtBarcodeInputNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        </div>
                                     
                                        <asp:GridView ID="GvViewBarcode" CssClass="table table-vcenter table-condensed table-bordered"
                                            runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                            PageSize="10" ShowFooter="true">
                                            <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                            <Columns>

                                                <asp:TemplateField HeaderText="Sr.No.">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Barcode">
                                                    <ItemTemplate>
                                                        <asp:TextBox CssClass="form-control" ID="TxtBarcode"  TabIndex="<%#((GridViewRow)Container).RowIndex %>"  MaxLength="10" AutoPostBack="true" runat="server" Text='<%#Bind("BARCODE") %>'></asp:TextBox>

                                                        <asp:RegularExpressionValidator ID="rvDigits" Display="Dynamic" runat="server" ControlToValidate="TxtBarcode" ErrorMessage="Enter numbers only till 10 digit"  ForeColor="Red" ValidationExpression="[0-9]{10}" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                     

                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                  
                                    <asp:Button ID="btnRunBarcodeProcess" runat="server" Text="Run" CssClass="btn btn-lg btn-primary" OnClick="btnRunBarcodeProcess_Click" Width="200px" Height="35px"  CausesValidation="false" />
                                    <asp:Button ID="btnClearBarcodeProcess" runat="server" Text="Clear Barcode" CssClass="btn btn-lg btn-primary" OnClick="btnClearBarcodeProcess_Click" Width="200px" Height="35px"  CausesValidation="false" />
                                   
                                    <button type="button" class="btn btn-primary" style="float: right;" data-dismiss="modal" value="NO">Exit </button>

                                </ContentTemplate>

                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnRunBarcodeProcess" EventName="click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnClearBarcodeProcess" EventName="click" />                         
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


      <div class="modal fade" tabindex="-1" id="CmpUpdateBarcodePrice" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" style="color: red">Update Barcode Price</h4>

                </div>

                <div class="modal-body">
                    <div id="Div1" runat="server" class="grids">
                        <div class="panel panel-widget top-grids">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

                               <div class="table-responsive">

                                  <div style="float: left; height: auto; width: 20%;">
                                    <div class="col-md-12">
                                       <table class="col-md-4">
                                                 
                                      <tr>
                                       <td style="padding-bottom: 10px; padding-left:30px;"  colspan="3">
                                           <asp:Button ID="BtnOpeningStockBracode" runat="server" OnClick="BtnOpeningStockBracode_Click" Text="Opening Stock Bracode" CssClass="btn btn-lg btn-primary" Width="250px" Height="35px"  CausesValidation="false" />
                                           </td> 
                                        </tr>

                                           <tr>
                                            <td style="padding-bottom: 10px; padding-left:30px;"  colspan="3">
                                                   <asp:Button ID="BtnPurchaseStockBracode" OnClick="BtnPurchaseStockBracode_Click" runat="server" Text="Purchase Stock Barcode" CssClass="btn btn-lg btn-primary" Width="250px" Height="35px"  CausesValidation="false" /></br>
                                           </td>
                                          </tr>

                                            <tr>
                                            <td style="padding-bottom: 10px; padding-left:30px;"  colspan="3">
                                                   <asp:Button ID="BtnAssemblyStockBarcode" runat="server" OnClick="BtnAssemblyStockBarcode_Click" Text="Asselmbly Stock Barcode" CssClass="btn btn-lg btn-primary" Width="250px" Height="35px"  CausesValidation="false" /></br>
                                           </td>
                                          </tr>

                                            <tr>
                                            <td style="padding-bottom: 10px; padding-left:30px;"  colspan="3">
                                                 <asp:Button ID="BtnBranchTransferStockBarcode" runat="server" OnClick="BtnBranchTransferStockBarcode_Click" Text="Branch Transfer Barcode" CssClass="btn btn-lg btn-primary" Width="250px" Height="35px"  CausesValidation="false" /></br>
                                           </td>
                                          </tr>

                                 
                                  
                                         <tr>
                                            <td style="padding-bottom: 10px; padding-left:30px;"  colspan="3">
                                              <button type="button" class="btn btn-primary" style="float: right; width:250px;"  data-dismiss="modal" value="NO">Exit </button>
                                             </td>
                                          </tr>

                                    </table>
                                    </div>
                                 </div>

                                 </div>


                                </ContentTemplate>

                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="BtnOpeningStockBracode" EventName="click" />
                                    <asp:AsyncPostBackTrigger ControlID="BtnPurchaseStockBracode" EventName="click" />    
                                     <asp:AsyncPostBackTrigger ControlID="BtnAssemblyStockBarcode" EventName="click" />
                                    <asp:AsyncPostBackTrigger ControlID="BtnBranchTransferStockBarcode" EventName="click" />                      
                                </Triggers>
                            </asp:UpdatePanel>

                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


    <script type="text/javascript">
        function HideModelUpdateBarcodePrice() {
            $("#CmpUpdateBarcodePrice").modal('hide');
        }

        function ShowModelUpdateBarcodePrice() {

            $("#CmpUpdateBarcodePrice").modal('show');

        }

    </script>



     <div class="modal fade" tabindex="-1" id="CmpUpdateSelection" data-keyboard="false" data-backdrop="static">

        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">UPDATE BARCODE PRICE MASTER</h4>
                </div>
                <div class="modal-body">


                    <span>DO YOU WANT TO UPDATE RECORD...!!!</span>
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




</asp:Content>
