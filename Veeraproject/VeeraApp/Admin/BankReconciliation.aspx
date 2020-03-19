<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="BankReconciliation.aspx.cs" Inherits="VeeraApp.Admin.BankReconciliation" %>

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
                    <h4>BANK RECONCILIATION</h4>
                </div>
            </div>
        </div>
    </div>

    <%--  <div style="clear: both; height: 10px">
    </div>--%>


    <div id="DivView" runat="server" class="grids">

        <div class="panel panel-widget top-grids">
            <%--  <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />--%>

            <asp:Label CssClass="label" Style="color: red;" Text="ACCOUNT NAME" runat="server"></asp:Label>
            <asp:TextBox ID="TxtAccountNameOnMasterGrid" OnTextChanged="TxtAccountNameOnMasterGrid_TextChanged" ForeColor="Blue" runat="server" Style="width: 25%;" AutoPostBack="true"></asp:TextBox>
            <asp:HiddenField ID="HfAccountCodeOnMasterGrid" runat="server" />

            <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtAccountNameOnMasterGrid"
                MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                ServiceMethod="GetAccountName">
            </ajax:AutoCompleteExtender>

        </div>


        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                    <div class="table-responsive">
                        <asp:GridView ID="GvPayReceiveMaster" CssClass="table table-vcenter table-condensed table-bordered"
                            runat="server" AutoGenerateColumns="false" AllowPaging="false"
                            PageSize="10">
                            <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                            <Columns>

                                <%--      <asp:TemplateField HeaderText="ACTION">
                                    <ItemTemplate>

                                        <asp:HiddenField ID="hfREC_UPD" runat="server" Value='<%#Bind("REC_UPD")%>' />
                                        <asp:HiddenField ID="hfREC_DEL" runat="server" Value='<%#Bind("REC_DEL")%>' />
                                        <asp:HiddenField ID="hfREC_INS" runat="server" Value='<%#Bind("REC_INS")%>' />

                                        <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    
                                        <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                        <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                    </ItemTemplate>
                                </asp:TemplateField>--%>


                                <asp:TemplateField HeaderText="DATE">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HfCompCodeGrid" runat="server" Value='<%#Bind("COMP_CODE")%>' />
                                        <asp:HiddenField ID="HfTranDateGrid" runat="server" Value='<%#Bind("TRAN_DATE")%>' />
                                        <asp:HiddenField ID="HfTranNoGrid" runat="server" Value='<%#Bind("TRAN_NO")%>' />
                                        <asp:HiddenField ID="HfSrNoGrid" runat="server" Value='<%#Bind("SR")%>' />

                                        <asp:HiddenField ID="HfUnsaved" runat="server" />
                                        <asp:Label CssClass="label" ID="lblVoucherDate" runat="server" Text='<%#Bind("VOU_DATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="BRANCH NAME">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="lblBranchName" runat="server" Text='<%#Bind("branch_code") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="VOUCHER NO">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="lblVoucherNo" runat="server" Text='<%#Bind("VOU_NO") %>'></asp:Label>
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

                                <asp:TemplateField HeaderText="CHEQUE NO.">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="lblChequeNo" runat="server" Text='<%#Bind("chq_no") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="CHEQUE DATE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="lblChequeDate" runat="server" Text='<%#Bind("chq_dt") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="DEBIT AMOUNT">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="lblDebitAmount" runat="server" Text='<%#Bind("DebitAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="CREDIT AMOUNT">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="lblCreditAmount" runat="server" Text='<%#Bind("CreditAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="BANK DATE" HeaderStyle-ForeColor="Red" HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:TextBox CssClass="form-control" ID="TxtBankDate" ForeColor="Red" OnTextChanged="TxtBankDate_TextChanged" AutoPostBack="true" Text='<%#Bind("BANKDT") %>' runat="server"></asp:TextBox>

                                         <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtBankDate"></ajax:CalendarExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="RECO. REMARK" HeaderStyle-ForeColor="Red" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TxtBankRecoRemark" CssClass="form-control" ForeColor="Red" OnTextChanged="TxtBankREcoRemark_TextChanged" AutoPostBack="true" Text='<%#Bind("bank_narrn") %>' runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>




                            </Columns>
                        </asp:GridView>
                    </div>

                </div>
            </div>
        </div>

        <div style="clear: both; height: 20px">
        </div>

        <div class="col-md-12">
            <div class="col-md-2 bs-component mb10">
                <asp:Button ID="BtnSAVE" runat="server" Text="SAVE" OnClick="BtnSAVE_Click" CssClass="btn btn-lg btn-primary btn-block" />
            </div>
            <div class="col-md-2 bs-component mb10">
                <asp:Button ID="btnExit" runat="server" Text="EXIT" OnClick="btnExit_Click" CssClass="btn btn-lg btn-primary btn-block" 
                    CausesValidation="false" />
            </div>

             <div class="col-md-2 bs-component mb10">
               <asp:Button runat="server" ID="btnViewBankRecoReport"  OnClick="btnViewBankRecoReport_Click1" Text="View-Report" OnClientClick="aspnetForm.target ='_blank';" />
            </div>
        </div>

    </div>

</asp:Content>
