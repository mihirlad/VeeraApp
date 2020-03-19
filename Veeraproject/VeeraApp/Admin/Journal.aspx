<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="Journal.aspx.cs" Inherits="VeeraApp.Admin.Journal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/model.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && charCode != 46 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }


    </script>
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
                    <h4>JOURNAL VOUCHER</h4>
                </div>
            </div>
        </div>
    </div>

    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">

                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">
                            <asp:UpdatePanel ID="updpnl" runat="server">
                                <ContentTemplate>

                                    <div class="h5" style="color: brown">JOURNAL VOUCHER</div>

                                    <div style="float: left; height: auto; width: 40%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Voucher No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtVoucherNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Voucher Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtVoucherDate" OnTextChanged="TxtVoucherDate_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtConfirmDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                              ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtVoucherDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtVoucherDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Party Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="4" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtAccountName" OnTextChanged="TxtAccountName_TextChanged" ForeColor="Blue" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:HiddenField ID="HfACODE" runat="server" />
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtAccountName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server"
                                                            ControlToValidate="TxtAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Narration" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="4" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtNarration" OnTextChanged="TxtNarration_TextChanged" ForeColor="Blue" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                         <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="TxtNarration"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetNarrationsName">
                                                        </ajax:AutoCompleteExtender>

                                                     <%--   <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                            ControlToValidate="TxtNarration" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
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
                                                        <asp:Label CssClass="label" Text="Confirm ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlConfirmFlag" OnSelectedIndexChanged="DdlConfirmFlag_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Confirm Date" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConfirmDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender6" Format="dd-MM-yyyy" TargetControlID="TxtConfirmDate"></ajax:CalendarExtender>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConfirmBy" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Approve ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlApproveFlag" OnSelectedIndexChanged="DdlApproveFlag_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Approve Date" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtApproveDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender2" Format="dd-MM-yyyy" TargetControlID="TxtApproveDate"></ajax:CalendarExtender>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtApproveBy" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Amount RS." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Sign" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlSign" OnSelectedIndexChanged="DdlSign_SelectedIndexChanged1" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="DR"  Selected="True">DR</asp:ListItem>
                                                            <asp:ListItem Value="CR">CR</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr>
                                               <td colspan="2">
                                                        <asp:Button runat="server" ID="btnprintFullJournalVoucher" OnClientClick="aspnetForm.target ='_blank';" OnClick="btnprintFullJournalVoucher_Click" Text="View-Full Voucher" />
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Button runat="server" ID="btnprintHalfJournalVoucher" OnClientClick="aspnetForm.target ='_blank';" OnClick="btnprintHalfJournalVoucher_Click" Text="View-Half Voucher" />
                                                    </td>
                                                </tr>
                                                
                                                </table>
                                            </div>
                                           </div>


                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div style="clear: both; height: 10px;">
                            </div>

                            <%--QUOTATION (ITEM) --%>

                            <div id="DivJournalItem" runat="server" class="panel panel-widget top-grids">
                                <div class="chute chute-center text-center">

                                    <asp:UpdatePanel ID="UpdPnl2" runat="server">
                                        <ContentTemplate>

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: brown">Journal Detail</div>
                                                <asp:GridView ID="GvJournalDetail" CssClass="table table-vcenter table-condensed table-bordered" OnRowDataBound="GvJournalDetail_RowDataBound"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" ShowFooter="true">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Sr.No.">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SR") %>' />
                                                                <asp:HiddenField ID="HfDebitACode" runat="server" Value='<%#Bind("DRACODE") %>' />
                                                                <asp:HiddenField ID="HfCreditACode" runat="server" Value='<%#Bind("CRACODE") %>' />
                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name Of Account">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtAccountNameG" OnTextChanged="TxtAccountNameG_TextChanged" ForeColor="Blue" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtAccountNameG"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetAccountName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Narration">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtNarration" CssClass="form-control" runat="server" Text='<%#Bind("NARRN") %>'></asp:TextBox>

                                                                  <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="TxtNarration"
                                                                     MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                     ServiceMethod="GetNarrationsName">
                                                        </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Amount">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtAmount" CssClass="form-control" OnTextChanged="TxtAmount_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                             <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                              </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="DdlSign" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="DR">DR</asp:ListItem>
                                                                    <asp:ListItem Value="CR" Selected="True">CR</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="BtnDeleteRowModelOrder_ItemGrid" runat="server" OnClick="BtnDeleteRowModelOrder_ItemGrid_Click" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Button ID="BtnAddRowModelOrder_ItemGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelOrder_ItemGrid_Click" CausesValidation="false" />
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
            <asp:HiddenField ID="HfQuoteType" runat="server" />
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click" />

            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />

            <div style="float: right;">
                <asp:Label CssClass="label" Style="color: red;" Text="Search " runat="server"></asp:Label><br />
                <asp:TextBox ID="TxtSearch" runat="server" Style="width: 100%;" AutoPostBack="true"></asp:TextBox>
            </div>

        </div>


        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBranchCode" runat="server" />
        <asp:HiddenField ID="HfTranDate" runat="server" />
        <asp:HiddenField ID="HfTranNo" runat="server" />
        <asp:HiddenField ID="HfTranType" runat="server" />

        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                    <div class="table-responsive">
                        <asp:GridView ID="GvJournalMaster" CssClass="table table-vcenter table-condensed table-bordered"
                            runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvJournalMaster_PageIndexChanging" OnRowCommand="GvJournalMaster_RowCommand"
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

                                <asp:TemplateField HeaderText="VOUCHER DATE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="lblQuotationDate" runat="server" Text='<%#Bind("vou_date") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                      <asp:TemplateField HeaderText="VOUCHER NO">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="lblVoucherNo" runat="server" Text='<%#Bind("vou_no") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            <asp:TemplateField HeaderText="NAME OF THE ACCOUNTS">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblAccountsName" runat="server" Text='<%#Bind("PartyName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DESCRIPTION">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblNarrations" runat="server" Text='<%#Bind("NARRN") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                           <asp:TemplateField HeaderText="DEBIT AMT.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblDebitAmount" runat="server" Text='<%#Bind("DebitAmount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                          <asp:TemplateField HeaderText="CREDIT AMT.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblCreditAmount" runat="server" Text='<%#Bind("CreditAmount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="CONFIRM ?">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblCongirmFlag" runat="server" Text='<%#Bind("CONF_FLAG") %>'></asp:Label>
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

    <div class="modal fade" tabindex="-1" id="CmpUpdateSelection" data-keyboard="false" data-backdrop="static">

        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">UPDATE JOURNAL VOUCHER DETAIL</h4>
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


     <script src="js/proton.js"></script>

    <div class="modal fade" tabindex="-1" id="CmpDeleteSelection" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">DELETE JOURNAL VOUCHER MASTER DETAIL</h4>
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

</asp:Content>
