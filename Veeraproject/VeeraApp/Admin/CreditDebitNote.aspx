<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="CreditDebitNote.aspx.cs" Inherits="VeeraApp.Admin.CreditDebitNote" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../css/model.css" rel="stylesheet" />
    <script type="text/javascript">
        function txtachange() {
            //  alert("jigar");
            document.getElementById("btnSubmit").onchange();
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
                    <h4 id="hdForCreditNote" runat="server">CREDIT NOTE</h4>
                     <h4 id="hdForDebitNote" runat="server">DEBIT NOTE</h4>
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

                                    <asp:HiddenField ID="HfTranType" runat="server" />
                                     <asp:HiddenField ID="HfTrnType" runat="server" />
                                      <asp:HiddenField ID="HfGroupCode" runat="server" />


                                    <div class="h5" style="color: brown">Cash Book Master</div>

                                    <div style="float: left; height: auto; width: 50%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">

                                                <tr>
                                                
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Voucher No" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtVoucherNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="GST Reason" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="8">
                                                        <asp:HiddenField ID="HfGstResonCode" runat="server" />
                                                        <asp:TextBox ID="TxtGSTReason" OnTextChanged="TxtGSTReason_TextChanged" AutoPostBack="true" ForeColor="Blue" CssClass="form-control" runat="server"></asp:TextBox>

                                                         <ajax:AutoCompleteExtender ID="AutoCompleteGetGSTReasonName" runat="server" TargetControlID="TxtGSTReason"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetGSTReasonName">
                                                        </ajax:AutoCompleteExtender>

                                                     <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldTxtGSTReason" runat="server"
                                                            ControlToValidate="TxtGSTReason" ForeColor="Red">*</asp:RequiredFieldValidator>

                                                    </td>
                                                   </tr>

                                                  <tr>
                                                     <td align="right" style="padding-bottom: 10px;">
                                                      <asp:Label CssClass="label" Text="Voucher Date" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtVoucherDate" OnTextChanged="TxtVoucherDate_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtVoucherDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderJobCardDate" Format="dd-MM-yyyy" TargetControlID="TxtVoucherDate"></ajax:CalendarExtender>
                                                    </td>
                                                  </tr>

                                                   <tr>
                                                    <td align="right" style="padding-bottom: 10px;" id="lblCreditAccounttd" runat="server">
                                                        <asp:Label CssClass="label" ID="lblCreditAccount" Text="Credit A/C" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="6">
                                                        <asp:HiddenField ID="HfCreditACODE" runat="server" />
                                                        <asp:TextBox ID="TxtCreditAccountName" OnTextChanged="TxtCreditAccountName_TextChanged"  AutoPostBack="true" CssClass="form-control" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtCreditAccountName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server"
                                                            ControlToValidate="TxtCreditAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>

                                                    <td align="right" style="padding-: 10px;">
                                                        <asp:Label CssClass="label" Text="Amount Rs." ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                   
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtCreditAmount" OnTextChanged="TxtCreditAmount_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Sign" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlCreditSign" OnSelectedIndexChanged="DdlCreditSign_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="DR"  Selected="True">DR</asp:ListItem>
                                                            <asp:ListItem Value="CR">CR</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                </tr>

                                                 <tr>
                                                    <td align="right" style="padding-bottom: 10px;" id="lblCreditNarrationtd" runat="server">
                                                        <asp:Label CssClass="label" ID="lblCreditNarration" Text="Credit Narration" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="8" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtCreditNarration"  ForeColor="Blue" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                         <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="TxtCreditNarration"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetNarrationsName">
                                                        </ajax:AutoCompleteExtender>

                                                     <%--   <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                            ControlToValidate="TxtNarration" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>         


                                                
                                                   <tr>
                                                    <td align="right" style="padding-bottom: 10px;" id="lblDebitAccountstd">
                                                        <asp:Label CssClass="label"  id="lblDebitAccounts" Text="Debit A/C" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="6">
                                                        <asp:HiddenField ID="HfDebitACODE" runat="server" />
                                                        <asp:TextBox ID="TxtDebitAccountName" OnTextChanged="TxtDebitAccountName_TextChanged"  AutoPostBack="true" CssClass="form-control" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtDebitAccountName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                            ControlToValidate="TxtDebitAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>

                                                       
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Amount Rs." ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                   
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtDebitAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Sign" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlDebitSign" OnSelectedIndexChanged="DdlDebitSign_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="DR">DR</asp:ListItem>
                                                            <asp:ListItem Value="CR" Selected="True">CR</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                </tr>

                                                  <tr>
                                                    <td align="right" style="padding-bottom: 10px;" id="lblDebitNarrartiontd">
                                                        <asp:Label CssClass="label"  id="lblDebitNarrartion" Text="Debit Narration" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="8" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtDebitNarration"  ForeColor="Blue" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                         <ajax:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="TxtDebitNarration"
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
                                                        <asp:DropDownList ID="DdlConfirm" OnSelectedIndexChanged="DdlConfirm_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                               
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Confirm Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConfirmDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtConfirmDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                      ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <%--       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderConfirmDate" Format="dd-MM-yyyy" TargetControlID="TxtConfirmDate"></ajax:CalendarExtender>
                                                    </td>

                                                  </tr>

                                                <tr>

                                                  <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Party Type" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlPartyType"  AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="LOCAL"  Selected="True">LOCAL</asp:ListItem>
                                                            <asp:ListItem Value="CST">CST</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Confirm By" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConfirmBy" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                    <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Approval ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlApproval" OnSelectedIndexChanged="DdlApproval_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                               
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Approval Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtApprovalDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtConfirmDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                      ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <%--       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtConfirmDate"></ajax:CalendarExtender>
                                                    </td>

                                                  </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Approval By" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtApprovalBy" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    
                                                   <td></td>
                                                    <td>
                                                        <asp:Button runat="server" ID="btnCreditDebitNotePrint" OnClick="btnCreditDebitNotePrint_Click" Text="View-Report" OnClientClick="aspnetForm.target ='_blank';" />
                                                    </td>

                                                </tr>
                                             
                                                </table>
                                            </div>
                                        </div>



                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>


                       <div style="clear: both; height: 10px;">
                            </div>

                       <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>

                           <div class="col-md-6">
                                <div class="col-md-3">
                                    <asp:Button ID="BtnFetchInvoice" runat="server" OnClick="BtnFetchInvoice_Click" Text="Fetch Invoice" Height="33px" Width="150px" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="BtnInvoiceProcess" runat="server" OnClick="BtnInvoiceProcess_Click" Text="Process" Height="33px" Width="100px" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                </div>
                            </div>

                                    </ContentTemplate>
                           </asp:UpdatePanel>

                               <div style="clear: both; height: 10px;">
                            </div>

                            <%--ACCOUNTS (DETAILS) --%>
                              <div id="Div1" runat="server" class="panel panel-widget top-grids">
                                <div class="chute chute-center text-center">

                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: red">INVOICE AGAINST PAID</div>
                                                <asp:GridView ID="GvPayReceiveInvoice" CssClass="table table-vcenter table-condensed table-bordered" OnRowDataBound="GvPayReceiveInvoice_RowDataBound"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                                    PageSize="10" ShowFooter="true">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Sr.No." HeaderStyle-Width="50px">
                                                            <ItemTemplate>
                                                               <%-- <asp:HiddenField ID="HfTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SR") %>' />--%>

                                                                <asp:HiddenField ID="HfInvACODE" runat="server" Value='<%#Bind("ACODE") %>' />
                                                                 <asp:HiddenField ID="HfXXX_Date" runat="server" Value='<%#Bind("XXX_DATE") %>' />
                                                                 <asp:HiddenField ID="HfXXX_No" runat="server" Value='<%#Bind("XXX_NO") %>' />
                                                                <asp:HiddenField ID="HfXXX_Type" runat="server" Value='<%#Bind("XXX_TYPE") %>' />

                                                                <asp:HiddenField ID="HfGST_AMT" runat="server" Value='<%#Bind("GST_AMT") %>'></asp:HiddenField>
                                                                <asp:HiddenField ID="HfCGST_RATE" runat="server" Value='<%#Bind("CGST_RATE") %>'></asp:HiddenField>
                                                                <asp:HiddenField ID="HfSGST_RATE" runat="server" Value='<%#Bind("SGST_RATE") %>'></asp:HiddenField>
                                                                <asp:HiddenField ID="HfIGST_RATE" runat="server" Value='<%#Bind("IGST_RATE") %>'></asp:HiddenField>

                                                                 <asp:Label ID="lblSubSrNo" runat="server" Text='<%#Bind("SUB_SR") %>'></asp:Label>
                                                            
                                                                <%--<%#Container.DataItemIndex + 1 %>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="BILL DATE">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtBillDate" runat="server" Style="text-align: center;" Text='<%#Bind("inv_date") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="BILL NO.">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtBillNo" runat="server" onkeypress="return isNumber(event);" Style="text-align: center;" Text='<%#Bind("inv_no") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="BILL AMOUNT">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtBillAmount" runat="server" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("bill_amt") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalBillAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderText="TOTAL PAID AMOUNT">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtTotalPaidAmount" runat="server" Text='<%#Bind("bill_paid_amt") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                              <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalPaidAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="LAST PAID DATE">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtLastPaidDate" runat="server" Style="text-align: center;" Text='<%#Bind("last_paiddate") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                       <asp:TemplateField HeaderText="LAST PAID CHEQUE NO.">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtLastPaidChequeNo" runat="server" onkeypress="return isNumber(event);" Style="text-align: center;" Text='<%#Bind("last_paidchqno") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="BILL BALANCE AMT">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtBillBalanceAmount" runat="server" Text='<%#Bind("bal_amt") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                                <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalBillBalanceAmount" ForeColor="Red" onkeypress="return isNumber(event);" Style="text-align: right;" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CURRENT PAID AMT">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtCurrentPaidAmount" OnTextChanged="TxtCurrentPaidAmount_TextChanged" onkeypress="return isNumber(event);" Style="text-align: right;" AutoPostBack="true" ForeColor="Blue" runat="server" Text='<%#Bind("AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                              <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalCurrentPaidAmount" ForeColor="Red"  runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="TDS AMT">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtTDSAmount" runat="server" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("TDS_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                             <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalTDSAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="DISCOUNT AMT">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtDiscountAmount" runat="server" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("LESS_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                             <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalDiscountAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CURRENT BAL. AMOUNT">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtCurrentBalAmount" runat="server" onkeypress="return isNumber(event);" Style="text-align: right;" ForeColor="red" Text='<%#Bind("Bill_Bal_Amt") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                              <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalCurrentBalanceAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                           <asp:TemplateField HeaderText="TAXABLE AMOUNT" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtTaxableAmount" OnTextChanged="TxtTaxableAmount_TextChanged" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("ACT_AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                              <FooterTemplate>
                                                                <asp:Label ID="lblTaxableSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                           <asp:TemplateField HeaderText="GST %" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtGSTRate" OnTextChanged="TxtGSTRate_TextChanged" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("GST_RATE") %>' AutoPostBack="true" runat="server"></asp:TextBox>
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

                                                  
                                                        <asp:TemplateField HeaderText="SGST AMOUNT" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtSGSTAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("SGST_AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSGSTSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                      
                                                        <asp:TemplateField HeaderText="IGST AMOUNT" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtIGSTAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("IGST_AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblIGSTSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Select">
                                                       <ItemTemplate>
                                                       <asp:CheckBox ID="ChkSelectBill" OnCheckedChanged="ChkSelectBill_CheckedChanged" AutoPostBack="true" runat="server" />
                                                    </ItemTemplate>
                                                 </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>                                       

                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>



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


       <div id="DivView" runat="server" class="grids">

        <div class="panel panel-widget top-grids">
       
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click"  />
            <asp:Button ID="btnexit" runat="server" Text="Exit"  CssClass="btn btn-lg btn-primary" CausesValidation="false" OnClick="btnexit_Click" />

            <div style="float: right;">
                <asp:Label CssClass="label" Style="color: red;" Text="Search " runat="server"></asp:Label><br />
                <asp:TextBox ID="TxtSearch" runat="server" Style="width: 100%;" AutoPostBack="true"></asp:TextBox>
            </div>

        </div>


        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBranchCode" runat="server" />
        <asp:HiddenField ID="HfTranDate" runat="server" />
        <asp:HiddenField ID="HfTranNo" runat="server" />


        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                    <div class="table-responsive">
                        <asp:GridView ID="GvCreditDebitNoteMaster" CssClass="table table-vcenter table-condensed table-bordered" OnRowCommand="GvCreditDebitNoteMaster_RowCommand" OnRowDataBound="GvCreditDebitNoteMaster_RowDataBound"
                            runat="server" AutoGenerateColumns="false" AllowPaging="false" 
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
                                        <asp:Label CssClass="label" ID="lblVoucherDate" runat="server" Text='<%#Bind("vou_date") %>'></asp:Label>
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

    <div class="modal fade" tabindex="-1" id="CmpDeleteSelection" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">DELETE CREDIT/DEBIT NOTE DETAIL</h4>
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

                        <h4 class="modal-title">UPDATE CREDIT/DEBIT NOTE DETAIL</h4>
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


</asp:Content>
