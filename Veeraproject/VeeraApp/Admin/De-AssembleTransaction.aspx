<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="De-AssembleTransaction.aspx.cs" Inherits="VeeraApp.Admin.De_AssembleTransaction" %>

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
                    <h4>DE-ASSEMBLY TRANSACTION</h4>
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

                                    <div class="h5" style="color: brown">De-Assemble Transaction Master</div>

                                    <asp:HiddenField ID="hfSCODE" runat="server" />
                                    <asp:HiddenField ID="HfAmount" runat="server" />

                                    <div class="col-md-12">
                                        <div class="col-md-1">
                                            <asp:Label CssClass="label" Text="Sr No." runat="server" ForeColor="Red"></asp:Label>
                                            <asp:TextBox ID="TxtSrNo" CssClass="form-control" runat="server" ForeColor="Red"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server"
                                                ControlToValidate="TxtSrNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-2">
                                            <asp:Label CssClass="label" Text="Assembly Date" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtAssemblyDate" OnTextChanged="TxtAssemblyDate_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                ControlToValidate="TxtAssemblyDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <ajax:CalendarExtender runat="server" ID="CalendarExtenderAssembleDate" Format="dd-MM-yyyy" TargetControlID="TxtAssemblyDate"></ajax:CalendarExtender>
                                        </div>
                                        

                                        <asp:Panel runat="server" ID="authorisedflag">
                                        <div class="col-md-2">
                                              <asp:Label CssClass="label" Text="AUTHORISED ?" runat="server"></asp:Label>
                                               <asp:DropDownList ID="DdlAuthoriseFlag" OnSelectedIndexChanged="DdlAuthoriseFlag_SelectedIndexChanged" AutoPostBack="true" runat="server" Width="200px" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="N">NO</asp:ListItem>
                                                </asp:DropDownList>
                                        </div>

                                        <div class="col-md-2">
                                              <asp:Label CssClass="label" Text="AUTHORISED DATE" runat="server"></asp:Label>
                                             <asp:TextBox ID="TxtAuthorisedDate" Width="200px" CssClass="form-control" runat="server"></asp:TextBox>

                                                       <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                              ControlToValidate="TxtAuthorisedDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtAuthorisedDate"></ajax:CalendarExtender>
                                        </div>

                                        <div class="col-md-2">
                                              <asp:Label CssClass="label" Text="AUTHORISED BY" runat="server"></asp:Label>
                                                <asp:TextBox ID="TxtAuthorisedBy" Width="200px" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                            </asp:Panel>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="col-md-2">
                                            <asp:Label CssClass="label" Text="Barcode" ForeColor="Blue" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtBarcode" ForeColor="Blue" OnTextChanged="TxtBarcode_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:Label CssClass="label" Text="Product Code" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtProductCode" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtProductCode"
                                                MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                ServiceMethod="GetProductCode">
                                            </ajax:AutoCompleteExtender>
                                        </div>

                                        <div class="col-md-6">
                                            <asp:Label CssClass="label" Text="Product Name" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtProductName" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtProductName"
                                                MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                ServiceMethod="GetStockName">
                                            </ajax:AutoCompleteExtender>
                                        </div>

                                        <div class="col-md-1">
                                            <asp:Label CssClass="label" Text="Qty" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtQty" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Label CssClass="label" Text="Rate" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtRate" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>

                                    </div>


                                    <div style="float: left; height: auto; width: 95%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="left" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Prepared By" runat="server" ForeColor="Blue"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="DdlPreparedBy" Width="300px" runat="server" ForeColor="Blue" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px; float: right">
                                                        <asp:Label CssClass="label" Text="CONFIRMED ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlConfirmFlag" runat="server" OnSelectedIndexChanged="DdlConfirmFlag_SelectedIndexChanged" AutoPostBack="true" Width="200px" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="N">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                    <td></td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="View Result ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlViewResult" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="S">SCREEN</asp:ListItem>
                                                            <asp:ListItem Value="P">PDF</asp:ListItem>
                                                            <asp:ListItem Value="E">EXCEL</asp:ListItem>
                                                            <asp:ListItem Value="H">HTML</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>



                                                </tr>

                                                <tr>
                                                    <td align="left" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Remark" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtRemark" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px; float: right">
                                                        <asp:Label CssClass="label" Text="CONFIRMED DATE" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConfirmDate" Width="200px" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%-- <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                              ControlToValidate="TxtAuthorisedDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarTxtConfirmDate" Format="dd-MM-yyyy" TargetControlID="TxtConfirmDate"></ajax:CalendarExtender>
                                                    </td>

                                                    <td></td>
                                                    <td></td>
                                                    <td colspan="2" style="padding-left: 10px;">
                                                        <asp:Button runat="server" ID="BtnPrintchallan" OnClick="BtnPrintchallan_Click" OnClientClick="aspnetForm.target ='_blank';" Text="View-Challan" />
                                                        <asp:Button runat="server" ID="btnPrintBarcode" OnClick="btnPrintBarcode_Click" OnClientClick="aspnetForm.target ='_blank';" Text="View-Barcode" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td align="right" style="padding-bottom: 10px; float: right">
                                                        <asp:Label CssClass="label" Text="CONFIRMED BY" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConfirmedBy" Width="200px" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                            </table>


                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div style="clear: both; height: 20px;">
                            </div>
                           
                            <div id="pnlfullwidth" runat="server" style="border: 1px solid blue; width: 55%; height: auto; float: left">

                                <div class="panel panel-widget top-grids">
                                    <div class="chute chute-center text-center">

                                        <asp:UpdatePanel ID="UpdPnl2" runat="server">
                                            <ContentTemplate>

                                                <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                    <div class="h5" style="color: brown; text-align: left">De-Assemble Parts Detail</div>
                                                    <asp:GridView ID="GvDeAssemblyPartDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvDeAssemblyPartDetails_PageIndexChanging" OnRowDataBound="GvDeAssemblyPartDetails_RowDataBound"
                                                        PageSize="10" ShowFooter="true">

                                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="SR.">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="HfTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                    <asp:HiddenField ID="HfTransNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                    <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                    <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />
                                                                    <asp:HiddenField ID="HfStatus" runat="server" Value='<%#Bind("STATUS") %>' />
                                                                    <asp:HiddenField ID="HfAmount" runat="server" Value='<%#Bind("AMT") %>' />

                                                                    <%#Container.DataItemIndex + 1 %>
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
                                                                    <asp:TextBox ID="TxtProductName" ForeColor="Blue" Style="width: 350px;" OnTextChanged="TxtProductName_TextChanged" runat="server" AutoPostBack="true"></asp:TextBox>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtProductName"
                                                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                        ServiceMethod="GetStockName">
                                                                    </ajax:AutoCompleteExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="QTY" ControlStyle-Width="70px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdrightalign" OnTextChanged="TxtQty_TextChanged" ID="TxtQty" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("QTY") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                                 <FooterTemplate>
                                                                    <asp:Label ID="lblSumTotalQuantity" ForeColor="Red" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="RATE(Per).%" ControlStyle-Width="70px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdrightalign" ID="TxtRatePer" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("PER") %>' OnTextChanged="TxtRatePer_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                                 <FooterTemplate>
                                                                    <asp:Label ID="lblSumTotalRatePercentage" ForeColor="Red" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="RATE" ControlStyle-Width="70px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdrightalign" ID="TxtRate" ForeColor="Red" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("RATE") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblSumTotalRate" ForeColor="Red" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="BtnDeleteRowModelDeAssemblePartsGrid" runat="server" OnClick="BtnDeleteRowModelDeAssemblePartsGrid_Click" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                                </ItemTemplate>

                                                                <FooterStyle HorizontalAlign="Right" />
                                                                <FooterTemplate>
                                                                    <asp:Button ID="BtnAddRowModelDeAssemblePartsGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelDeAssemblePartsGrid_Click" CausesValidation="false" />
                                                                </FooterTemplate>
                                                            </asp:TemplateField>



                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                </div>
                                            </ContentTemplate>
                                         <%--   <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="GvDeAssemblyPartDetails" EventName="OnRowDataBound" />
                                            </Triggers>--%>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>


                                <div id="barcodegrid" runat="server" style="border: 1px solid blue; width: 40%; height: auto; float: right">


                                    <div class="panel panel-widget top-grids">
                                        <div class="chute chute-center text-center">

                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>

                                                    <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                        <div class="h5" style="color: brown; text-align: left">New Barcode Details</div>


                                                        <asp:GridView ID="GvNewBarcodeGrid" CssClass="table table-vcenter table-condensed table-bordered"
                                                            runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvNewBarcodeGrid_PageIndexChanging"
                                                            PageSize="10" ShowFooter="true">
                                                            <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                            <Columns>


                                                                <%--   <asp:TemplateField HeaderText="Sr.No.">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex + 1 %>
                                                             </ItemTemplate>
                                                        </asp:TemplateField>--%>

                                                                <asp:TemplateField HeaderText="BARCODE">
                                                                    <ItemTemplate>
                                                                        <asp:HiddenField ID="HfTransDateGrid" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                        <asp:HiddenField ID="HfTransNoGrid" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                      <%-- <asp:HiddenField ID="HfBarTranDate" runat="server" Value='<%#Bind("BAR_TRAN_DATE") %>' />
                                                                        <asp:HiddenField ID="HfBarTranNo" runat="server" Value='<%#Bind("BAR_TRAN_NO") %>' />
                                                                        <asp:HiddenField ID="HfBarSrNo" runat="server" Value='<%#Bind("BAR_SRNO") %>' />--%>
                                                                         <asp:HiddenField ID="HfBarTranDate" runat="server" Value='<%#Bind("ASS_TRAN_DATE") %>' />
                                                                        <asp:HiddenField ID="HfBarTranNo" runat="server" Value='<%#Bind("ASS_TRAN_NO") %>' />
                                                                        <asp:HiddenField ID="HfBarSrNo" runat="server" Value='<%#Bind("ASS_SRNO") %>' />
                                                                        <asp:HiddenField ID="HfStockcode" runat="server" Value='<%#Bind("SCODE") %>' />
                                                                       <%-- <asp:HiddenField ID="HfQty" runat="server" Value='<%#Bind("QTY") %>' />--%>
                                                                     <%--   <asp:HiddenField ID="HfAmount" runat="server" Value='<%#Bind("AMT") %>' />--%>

                                                                        <asp:TextBox CssClass="form-control" ID="TxtBarcode" runat="server" Text='<%#Bind("BARCODE") %>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="STATUS">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox CssClass="form-control" ID="TxtBracodeStatus" runat="server" Text='<%#Bind("STATUS") %>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="RATE">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox CssClass="form-control" ID="TxtRate" runat="server" Text='<%#Bind("RATE") %>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
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

              <div style="float: right;">
                <asp:Label CssClass="label" Style="color: red;" Text="Sr No./Product Code/Product Name/Preapared By Person" runat="server"></asp:Label><br />
                <asp:TextBox ID="TxtSearch" runat="server" Style="width: 100%;" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
        </div>

        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBranchCode" runat="server" />
        <asp:HiddenField ID="HfTranDate" runat="server" />
        <asp:HiddenField ID="HfTranNo" runat="server" />
        <asp:HiddenField ID="HfTranType" runat="server" />

        <asp:HiddenField ID="HfBar_Tran_No" runat="server" />
        <asp:HiddenField ID="HfBar_Tran_Date" runat="server" />
        <asp:HiddenField ID="HfBar_SrNo" runat="server" />

        <asp:HiddenField ID="HfASSEMBLE_TRAN_NO" runat="server" />
        <asp:HiddenField ID="HfASEEMBLE_TRAN_DATE" runat="server" />


        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

               <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvDe_AssembleTransactionMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvDe_AssembleTransactionMaster_PageIndexChanging" OnRowCommand="GvDe_AssembleTransactionMaster_RowCommand" OnRowDataBound="GvDe_AssembleTransactionMaster_RowDataBound"
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


                            <asp:TemplateField HeaderText="DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblAssembleDate" runat="server" Text='<%#Bind("AssembleDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SR.NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblSrno" runat="server" Text='<%#Bind("SRNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PRODUCT CODE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblProductCode" runat="server" Text='<%#Bind("ProductCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PRODUCT NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblProductName" runat="server" Text='<%#Bind("ProductName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PREPARED BY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblPreparedBy" runat="server" Text='<%#Bind("PersonName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="AUTHORISED ?">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblAuthorisedFlag" runat="server" Text='<%#Bind("AUTH_FLAG_Confirm") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="AUTHORISED DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblAuthorisedDate" runat="server" Text='<%# Eval("AUTH_DATE").ToString() == "01-01-1900 00:00:00" ? "-" : Convert.ToDateTime(Eval("AUTH_DATE")).ToString("dd-MM-yyyy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="AUTHORISED BY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblAuthorisedBy" runat="server" Text='<%#Bind("AUTH_USERID") %>'></asp:Label>
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

                    <h4 class="modal-title">DELETE DE-ASSEMBLE TRANSACTION DETAILS</h4>
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

                    <h4 class="modal-title">UPDATE DE-ASSEMBLE TRANSACTION DETAIL</h4>
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


</asp:Content>
