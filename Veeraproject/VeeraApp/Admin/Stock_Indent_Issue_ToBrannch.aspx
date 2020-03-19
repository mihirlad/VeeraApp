<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="Stock_Indent_Issue_ToBrannch.aspx.cs" Inherits="VeeraApp.Admin.Stock_Indent_Issue_ToBrannch" %>

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
                    <h4 id="PageTiltle1" runat="server">STOCK INDENT ISSUE TO BRANCH</h4>
                    <h4 id="PageTiltle2" runat="server">STOCK INDENT RECEIVED FROM BRANCH</h4>
                </div>
            </div>
        </div>
    </div>

        <asp:HiddenField ID="HfStockIndetBranchType" runat="server" />

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

                                  <div class="h5" style="color: brown">Service Issue To Branch </div>

                                    <div style="float: left; height: auto; width: 40%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Indent No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtIndentNo" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server"
                                                            ControlToValidate="TxtIndentNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>

                                                   <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="From Branch" ForeColor="Red" runat="server"></asp:Label>
                                                    </td>

                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtFromBranch" CssClass="form-control" ForeColor="Red" runat="server"></asp:TextBox>
                                                    </td>

                                                 </tr>

                                                <tr>
                                                         
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Indent Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtIndentDate" OnTextChanged="TxtIndentDate_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtServiceDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                          ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtIndentDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderIndentDate" Format="dd-MM-yyyy" TargetControlID="TxtIndentDate"></ajax:CalendarExtender>
                                                    </td>

                                                   <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="To Branch" ForeColor="Blue" runat="server"></asp:Label>
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
                                                        <asp:Label CssClass="label" Text="Prepared By" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">

                                                        <asp:HiddenField ID="HfPreparedBy" runat="server" />
                                                        <asp:TextBox ID="TxtPreparedBy" CssClass="form-control" ForeColor="Blue" OnTextChanged="TxtPreparedBy_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtPreparedBy"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetPreparedPersonName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtPreparedBy" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                     <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Indent Type" Font-Size="Medium" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                         <asp:RadioButton ID="RdIBtn_IndenTypeStockLevel" runat="server" Text="From Stock Level" OnCheckedChanged="RdIBtn_IndenTypeStockLevel_CheckedChanged"  GroupName="StockIndent" AutoPostBack="true"/>
                                                    </td>
                                                 </tr>

                                                <tr>
                                                    <td></td>

                                                    <td style="padding-left: 10px;">
                                                         <asp:RadioButton ID="RdBtn_IndentTypeExtraSpend" runat="server" Text="Extra Spend Order" OnCheckedChanged="RdBtn_IndentTypeExtraSpend_CheckedChanged" GroupName="StockIndent" AutoPostBack="true"/>
                                                    </td>
                                                </tr>

                                                 <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Remark" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtRemark" CssClass="form-control"  runat="server"></asp:TextBox>
                                                     </td>
                                                 </tr>

                                              </table>
                                            </div>
                                        </div>


                                      <div style="float: left; height: auto; width: 35%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Confirm ?"  runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlConfirmFlag" OnSelectedIndexChanged="DdlConfirmFlag_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Received ?"  runat="server"></asp:Label>
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
                                                        <asp:Label CssClass="label" Text="Confirm Date" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConfirmDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtConfirmDate"></ajax:CalendarExtender>
                                                    </td>

                                                     <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Received Date" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtReceivedDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtReceivedDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender2" Format="dd-MM-yyyy" TargetControlID="TxtReceivedDate"></ajax:CalendarExtender>
                                                    </td>

                                                  </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Confirm By" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConfirmBy" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Received By" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtReceivedBy" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td></td>
                                                    <td> </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Closed ?"  runat="server"></asp:Label>
                                                    </td>

                                                      <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlClosedFlag" OnSelectedIndexChanged="DdlClosedBy_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td></td>
                                                    <td>
                                                          <asp:Button ID="btnAddStockCategory" runat="server" OnClick="btnAddStockCategory_Click"  CausesValidation="false" Width="140px" Text="Add Stock Category" CssClass="btn-danger btn-sm"></asp:Button>
                                                    </td>
 
                                                     <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Closed Date" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtClosedDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtClosedDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender3" Format="dd-MM-yyyy" TargetControlID="TxtClosedDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td></td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:Button runat="server" ID="BtnViewIndentReport" OnClientClick="aspnetForm.target ='_blank';" OnClick="BtnViewIndentReport_Click" Text="View-Indent Report" />
                                                     </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Closed By" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtClosedBy" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                </table>
                                            </div>
                                          </div>


                                    </ContentTemplate>
                                </asp:UpdatePanel>

                             <div style="clear: both; height: 10px;">
                            </div>

                            <div class="panel panel-widget top-grids">
                                <div class="chute chute-center text-center">

                                    <asp:UpdatePanel ID="UpdPnlPartyDetails" runat="server">
                                        <ContentTemplate>

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: brown; text-align: left">Stock Detail</div>
                                                <asp:GridView ID="GvStockIndentDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvStockIndentDetails_PageIndexChanging" OnRowCommand="GvStockIndentDetails_RowCommand" OnRowDataBound="GvStockIndentDetails_RowDataBound"
                                                    PageSize="10" ShowFooter="true">

                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="SR.NO.">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                  <asp:HiddenField ID="HfCategoryCode" runat="server" Value='<%#Bind("CAT_CODE") %>' />
                                                                <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />
                                                              

                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="STOCK CATEGORY">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtStockCategoryName" ForeColor="Blue" Width="250px" runat="server" OnTextChanged="TxtStockCategoryName_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtenderStockCategory" runat="server" TargetControlID="TxtStockCategoryName"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetStockCategoryName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="PRODUCT CODE">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="TxtProductCode" ForeColor="Blue" Style="width: 100px;" runat="server" OnTextChanged="TxtProductCode_TextChanged" AutoPostBack="true"></asp:TextBox>
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

                                                          <asp:TemplateField HeaderText=" MAX.QTY">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtMaxQty"  onkeypress="return isNumber(event);" Style="text-align: center;" Text='<%#Bind("MAX_QTY") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                         <asp:TemplateField HeaderText=" MIN.QTY">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtMinQty"  onkeypress="return isNumber(event);" Style="text-align: center;" Text='<%#Bind("MIN_QTY") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                          </asp:TemplateField>
                                                        
                                                         <asp:TemplateField HeaderText=" STOCK QTY" ControlStyle-ForeColor="Red">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtStockQty"  onkeypress="return isNumber(event);" Style="text-align: center;" Text='<%#Bind("STK_QTY") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="INDENT QTY">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtOrderQty"  onkeypress="return isNumber(event);" Style="text-align: center;" Text='<%#Bind("ORD_QTY") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                          <asp:TemplateField HeaderText=" TO BRANCH STOCK" ControlStyle-ForeColor="Red">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtToBranchStock"  onkeypress="return isNumber(event);" Style="text-align: center;" Text='<%#Bind("BRSTK_QTY") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                         <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="BtnDeleteRowModelStockItemGrid" runat="server" OnClick="BtnDeleteRowModelStockItemGrid_Click" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                                </ItemTemplate>

                                                             <FooterStyle HorizontalAlign="Right" />
                                                                <FooterTemplate>
                                                                    <asp:Button ID="BtnAddRowModelStockItemGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelStockItemGrid_Click" CausesValidation="false" />
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

         <%--   <div style="float: right;">
                <asp:Label CssClass="label" Style="color: red;" Text="Search By Challan No./From Branch/To Branch/Delivered Person" runat="server"></asp:Label><br />
                <asp:TextBox ID="TxtSearch" runat="server" Style="width: 100%;" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>--%>
            </div>

             <asp:HiddenField ID="HfCompCode" runat="server" />
             <asp:HiddenField ID="HfBranchCode" runat="server" />
             <asp:HiddenField ID="HfTranDate" runat="server" />
             <asp:HiddenField ID="HfTranNo" runat="server" />
         

            <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

              <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvStockIndentToBranchMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvStockIndentToBranchMaster_PageIndexChanging" OnRowCommand="GvStockIndentToBranchMaster_RowCommand" OnRowDataBound="GvStockIndentToBranchMaster_RowDataBound"
                        PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                            <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <asp:HiddenField ID="HfTranDateGrid" runat="server" Value='<%#Bind("TRAN_DATE")%>' />
                                    <asp:HiddenField ID="HfTranNoGrid" runat="server" Value='<%#Bind("TRAN_NO")%>' />

                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                <%--    <a href="JavaScript:divexpandcollapse('div<%# Eval("TRAN_NO") %>');">
                                        <img id='imgdiv<%# Eval("TRAN_NO") %>' width="15px" border="0" src="/images/plus.gif" />
                                    </a>--%>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="INDENT DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblIndentDate" runat="server" Text='<%#Bind("IndentDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="INDENT NO">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblIndentNo" runat="server" Text='<%#Bind("INDNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="INDENT TYPE ?">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblIndentType" runat="server" Text='<%#Bind("INDENT_TYPE") %>'></asp:Label>
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
                         
                             <asp:TemplateField HeaderText="PREPARED BY NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblPreparedBy" runat="server" Text='<%#Bind("PreparedByName") %>'></asp:Label>
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
                          
                             <asp:TemplateField HeaderText="CLOSED ?">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblClosedFlag" runat="server" Text='<%#Bind("CLOSE_FLAG") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                               <asp:TemplateField HeaderText="CLOSED DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblClosedDate" runat="server" Text='<%# Eval("CLOSE_DATE").ToString() == "01-01-1900 00:00:00" ? "-" : Convert.ToDateTime(Eval("REC_DATE")).ToString("dd-MM-yyyy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="CLOSED BY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblClosedBy" runat="server" Text='<%#Bind("CLOSE_USERID") %>'></asp:Label>
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

                    <h4 class="modal-title">DELETE STOCK INDENT ISSUE TO BRANCH</h4>
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

                    <h4 class="modal-title">UPDATE STOCK INDENT ISSUE TO BRANCH</h4>
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
    <asp:UpdatePanel ID="UpModalStockCategory" runat="server">
        <ContentTemplate>

            <div class="modal fade" tabindex="-1" id="CmpStockCategory" data-keyboard="false" data-backdrop="static">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">

                            <h4 class="modal-title" style="color: red">Stock Category</h4>
                        </div>
                        <div class="modal-body">

                            <div id="Div1" runat="server" class="grids">

                                <div class="panel panel-widget top-grids">
                              

                                    <div class="h5" style="color: brown; text-align: left">Stock Category</div>
                                    <asp:GridView ID="GvStockCategory" CssClass="table table-vcenter table-condensed table-bordered"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvStockCategory_PageIndexChanging"
                                        PageSize="10" ShowFooter="true">
                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                        <Columns>


                                           <%-- <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnSelect" OnClick="btnSelect_Click" runat="server" CausesValidation="false" CommandName="Selecta" CommandArgument='<%#Bind("CAT_CODE") %>' ToolTip="View" Text="SELECT" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>                        
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                      <asp:TemplateField HeaderText="Sr.No.">
                                          <ItemTemplate>
                                              <%#Container.DataItemIndex + 1 %>
                                                  <asp:HiddenField ID="HfCategoryCodePopUp" runat="server" Value='<%#Bind("CAT_CODE") %>' />
                                           </ItemTemplate>
                                        </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Stock Category">
                                                <ItemTemplate>
                                               <%--     <asp:Label CssClass="label" ID="lblStockCtaegoryName" runat="server" Text='<%#Bind("CAT_NAME") %>'></asp:Label>--%>
                                                      <asp:TextBox ID="TxtStockCategoryNamePopUp" ForeColor="Blue" Width="250px" runat="server" AutoPostBack="true" Text='<%#Bind("CAT_NAME") %>'></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtenderStockCategory" runat="server" TargetControlID="TxtStockCategoryNamePopUp"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetStockCategoryName">
                                                        </ajax:AutoCompleteExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField>
                                                <ItemTemplate>
                                                </ItemTemplate>
                                                <FooterStyle HorizontalAlign="Right" />
                                                <FooterTemplate>
                                                    <asp:Button ID="BtnAddRowModelStock_CategoryGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelStock_CategoryGrid_Click" CausesValidation="false" />
                                                </FooterTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>

                                      <asp:Button ID="btnIndentProcess" runat="server" Text="Indent Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnIndentProcess_Click" CausesValidation="false" />    
                                    <center> <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK </button> </center>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
          <%--  <asp:PostBackTrigger ControlID="TxtAccountName" />--%>
            <asp:PostBackTrigger ControlID="GvStockCategory" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function HideModelStockCtaegory() {
            $("#CmpStockCategory").modal('hide');
        }

        function ShowModelStockCategory() {

            $("#CmpStockCategory").modal('show');

        }
 
    </script>



</asp:Content>
