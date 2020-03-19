<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="StockBarcodeAudit.aspx.cs" Inherits="VeeraApp.Admin.StockBarcodeAudit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script lang="javascript" type="text/javascript">

        function divexpandcollapse(divname) {

            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);

            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "/images/minus.gif";
            } else {
                div.style.display = "none";
                img.src = "/images/plus.gif";
            }
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

    <div style="clear: both; height: 10px">
    </div>

    <div class="grids">
    </div>
    <div class="panel panel-widget forms-panel">
        <div class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title">
                    <h4>BARCODE STOCK AUDIT</h4>
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


                                    <div class="h5" style="color: brown">AUDIT MASTER</div>

                                    <div style="float: left; height: auto; width: 40%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Sr.No." ForeColor="Red" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtSrNo" Style="text-align: center;" ForeColor="Red" CssClass="form-control" runat="server"></asp:TextBox>
                                                     </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Audit Start Date" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtStartDate" Style="text-align: center;" CssClass="form-control" runat="server" AutoPostBack="true"></asp:TextBox>

                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtStartDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                            ErrorMessage="INVALID DATE" ForeColor="Red"></asp:RegularExpressionValidator>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server"
                                                            ControlToValidate="TxtStartDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarID1" Format="dd-MM-yyyy" TargetControlID="TxtStartDate"></ajax:CalendarExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Audit End Date" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtEndDate" Style="text-align: center;" CssClass="form-control" runat="server" AutoPostBack="true"></asp:TextBox>

                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ControlToValidate="TxtEndDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                            ErrorMessage="INVALID DATE" ForeColor="Red"></asp:RegularExpressionValidator>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtEndDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtEndDate"></ajax:CalendarExtender>
                                                    </td>

                                                </tr>

                                                <tr>
                                                      <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Prepared By" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:HiddenField ID="HfTPreparedByBCODE" runat="server" />
                                                        <asp:TextBox ID="TxtPreparedBy" CssClass="form-control"  AutoPostBack="true" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderTxtTransactionBy" runat="server" TargetControlID="TxtPreparedBy"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetPersonName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldTxtTransactionBy" runat="server"
                                                            ControlToValidate="TxtPreparedBy" ForeColor="Red">*</asp:RequiredFieldValidator>

                                                    </td>
                                                </tr>

                                                <tr>
                                                     <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Remarks" runat="server"></asp:Label>

                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtRemarks" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                              

                                            </table>
                                        </div>
                                    </div>


                                      <div style="float: left; height: auto; width: 25%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                               <tr>
                                                 
                                                     <td style="padding-bottom: 15px;">
                                                        <asp:Button ID="BtnAddBarcode" runat="server" OnClick="BtnAddBarcode_Click" Text="Add Barcode" Width="180px" Height="33px"
                                                            CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                  
                                                     <td style="padding-bottom: 15px;">
                                                        <asp:Button ID="BtnViewAuditReports" runat="server" Text="View Audit Report" Width="180px" Height="33px"
                                                            CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>
                                                </tr>
                                                </table>
                                            </div>
                                       </div>


                                    
                                    <div style="clear: both; height: 10px;">
                                    </div>

                                    <div class="panel panel-widget top-grids">
                                        <div class="chute chute-center text-center">

                                            <div class="table-responsive" style="height: 450px; overflow-y: scroll;" id="DivStockGrid" runat="server">
                                                <div class="h5" style="color: brown">STOCK BARCODE DETAILS</div>
                                                <asp:GridView ID="GvBarcodeAuditDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvBarcodeAuditDetails_PageIndexChanging"
                                                    PageSize="10">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                           <asp:TemplateField HeaderText="Sr.No." HeaderStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfCompCodeGrid" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                                <asp:HiddenField ID="HfTranDateGrid" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                 <asp:HiddenField ID="HfTranNoGrid" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                  <asp:HiddenField ID="HfSrNoGrid" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                    <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />

                   
                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="BARCODE">                                                       
                                                              <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtBarcode" runat="server" Text='<%#Bind("BARCODE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="STATUS">                                                       
                                                              <ItemTemplate>
                                                                  <asp:Label CssClass="label grdleftalign" ID="lblBracodeStatus" runat="server" Text='<%#Bind("STATUS") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                           <asp:TemplateField HeaderText="PRODUCT CODE">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtProductCode" runat="server" ForeColor="Blue" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtProductCode"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetProductCode">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT NAME">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtProductName" runat="server" ForeColor="Blue"  AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtProductName"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetStockName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="CREATED BY">                                                       
                                                              <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtCreatedBy" runat="server" Text='<%#Bind("INS_USERID") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="CREATED DATE">                                                       
                                                              <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtCreatedDate" runat="server" Text='<%#Bind("INS_DATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        </Columns>
                                                    </asp:GridView>
                                                </div>

                                            </div>
                                           </div>

                                  
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            
                            <div style="clear: both; height: 10px;">
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
        </div>

        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBranchCode" runat="server" />
        <asp:HiddenField ID="HfTranNo" runat="server" />
        <asp:HiddenField ID="HfTranDate" runat="server" />
        


        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvStockBarcodeAuditMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvStockBarcodeAuditMaster_PageIndexChanging" OnRowCommand="GvStockBarcodeAuditMaster_RowCommand"
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

                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                   

                            <asp:TemplateField HeaderText="AUDIT START DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdcenteralign" ID="lblAuditStartDate" runat="server" Text='<%#Bind("START_DATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="AUDIT END DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdcenteralign" ID="lblAuditEndDate" runat="server" Text='<%#Bind("END_DATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="AUDIT PREPARED BY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblAuditPreparedBy" runat="server" Text='<%#Bind("BCODE") %>'></asp:Label>
                                </ItemTemplate>
                              </asp:TemplateField>

                            <asp:TemplateField HeaderText="AUDIT CLOSED ?">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblAuditClosedFlag" runat="server" Text='<%#Bind("CLOSE_FLAG") %>'></asp:Label>
                                </ItemTemplate>
                              </asp:TemplateField>
                             
                              <asp:TemplateField HeaderText="CLOSED DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="labe grdcenteralign" ID="lblAuditClosedDate" runat="server" Text='<%#Bind("CLOSE_DATE") %>'></asp:Label>
                                </ItemTemplate>
                              </asp:TemplateField>

                            <asp:TemplateField HeaderText="CLOSED BY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblAuditClosedBy" runat="server" Text='<%#Bind("CLOSE_USERID") %>'></asp:Label>
                                </ItemTemplate>
                              </asp:TemplateField>

                                <asp:TemplateField HeaderText="REMARK">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblRemark" runat="server" Text='<%#Bind("REMARK") %>'></asp:Label>
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

                    <h4 class="modal-title">DELETE STOCK BARCODE AUDIT DETAIL</h4>
                </div>
                <div class="modal-body">


                    <span>Are you sure want to delete...!!!</span>
                    <br />

                    <div id="Div2" runat="server" class="grids">

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
        12345
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title">UPDATE  STOCK BARCODE AUDIT DETAIL</h4>
                    </div>
                    <div class="modal-body">


                        <span>Are you sure want to update...!!!</span>
                        <br />

                        <div id="Div3" runat="server" class="grids">

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



    
   <%-- <script src="js/proton.js"></script>--%>

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

                                    <div class="table-responsive" style="height: 400px; overflow-y: scroll">

                                        <asp:Label ID="lblbarduperror" runat="server" ForeColor="Red"></asp:Label>
                                        <div id="DivBarcodeInput" runat="server">
                                            <span style="padding-right: 5px;">Enter No.of Rows Required</span><asp:TextBox ID="TxtBarcodeInputNo" runat="server"  OnTextChanged="TxtBarcodeInputNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        </div>
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
                                                        <%#Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Barcode">
                                                    <ItemTemplate>
                                                        <asp:TextBox CssClass="form-control" ID="TxtBarcode" OnTextChanged="TxtBarcode_TextChanged" TabIndex="<%#((GridViewRow)Container).RowIndex %>"  MaxLength="10" AutoPostBack="true" runat="server" Text='<%#Bind("BARRCODE") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Qty.">
                                                    <ItemTemplate>
                                                        <asp:TextBox CssClass="form-control" ID="TxtQty" runat="server" Text='<%#Bind("QTY") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <FooterTemplate>
                                                        <asp:Button ID="BtnAddRowModelBarCode_ViewGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelBarCode_ViewGrid_Click" CausesValidation="false" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>


                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                    <asp:Button ID="btnAddBarcodeProcess" runat="server" Text="Add Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnAddBarcodeProcess_Click" CausesValidation="false" />
                                    <asp:Button ID="btnUploadBarcodeProcess" runat="server" Text="Upload Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnUploadBarcodeProcess_Click" CausesValidation="false" />
                                 <%--   <asp:Button ID="btnReturnBarcodeProcess" runat="server" Text="Return Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnReturnBarcodeProcess_Click" CausesValidation="false" />--%>

                                    <button type="button" class="btn btn-primary" style="float: right;" data-dismiss="modal" value="NO">BACK </button>


                                </ContentTemplate>
                                <Triggers>
                                 <%--   <asp:AsyncPostBackTrigger ControlID="BtnViewBarcode" EventName="click" />--%>
                                    <asp:AsyncPostBackTrigger ControlID="BtnAddBarcode" EventName="click" />
                                 <%--   <asp:AsyncPostBackTrigger ControlID="BtnReturnBarcode" EventName="click" />--%>
                                    <%--<asp:AsyncPostBackTrigger ControlID="btnUploadBarcodeProcess" EventName="click" />--%>
                                    <asp:PostBackTrigger ControlID="btnUploadBarcodeProcess" />
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
