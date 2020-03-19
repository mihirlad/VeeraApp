<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="Quotation.aspx.cs" Inherits="VeeraApp.Quotation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/model.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function txtachange() {
            alert("jigar");
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
                    <h4>QUOTATION</h4>
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

                                    <div class="h5" style="color: brown">QUOTATION MASTER</div>

                                    <div style="float: left; height: auto; width: 40%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Quotation No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtQuotationNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Quotation Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtQuotationDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtConfirmDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                              ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtQuotationDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtQuotationDate"></ajax:CalendarExtender>
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
                                                        <asp:Label CssClass="label" Text="Kind Attn." ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlKindAttn" runat="server" ForeColor="Blue" CssClass="form-control" OnSelectedIndexChanged="DdlKindAttn_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" 
                                                            ControlToValidate="DdlKindAttn" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                         <asp:Button runat="server" ID="btnRefresh" OnClick="btnRefresh_Click" CausesValidation="false" CssClass="btn_Refresh" />
                                                        <asp:Button ID="BtnContactDetails" runat="server" Text="Contact Details" Height="33px" Width="180px" OnClick="BtnContactDetails_Click" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Contact Phone" runat="server"></asp:Label>
                                                    </td>


                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConatctPhone" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Contact Email" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtContactEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td colspan="3" style="padding-left: 10px; padding-bottom: 10px">
                                                        <asp:Button ID="BtnSearchPartyModel" runat="server" Text="Search Party Model" Height="33px" Width="250px" OnClick="BtnSearchPartyModel_Click" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Party Ref.No." runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtPartyRefNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px; padding-bottom: 10px">
                                                        <asp:Button ID="BtnSearchModelDetails" runat="server" Text="Search Model Details" Height="33px" Width="250px" OnClick="BtnSearchModelDetails_Click" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Remark" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="4" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtRemark" CssClass="form-control" runat="server"></asp:TextBox>
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
                                                        <asp:Label CssClass="label" Text="Price Terms" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtPriceTerms" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Delivery Terms" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtPaymentTerms" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Delivery Terms" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtDeliveryTerms" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Validity Terms" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtValidityTerms" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Transportation Terms" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtTransportationTerms" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Prepared By" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlPreparedBy" runat="server" ForeColor="Blue" CssClass="form-control">
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" InitialValue="0"
                                                            ControlToValidate="DdlPreparedBy" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>


                                    <div style="float: left; height: auto; width: 20%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Party Type" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlPartyType" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                            <asp:ListItem Value="LOCAL">LOCAL</asp:ListItem>
                                                            <asp:ListItem Value="CST">CST</asp:ListItem>
                                                        </asp:DropDownList>


                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredAccountName" runat="server" InitialValue="0"
                                                            ControlToValidate="DdlPartyType" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Sales Type" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlSalesType" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                            <asp:ListItem Value="R">Retail Invoice</asp:ListItem>
                                                            <asp:ListItem Value="T">Tax Invoice</asp:ListItem>
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" runat="server" InitialValue="0"
                                                            ControlToValidate="DdlSalesType" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Register/CST Type" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlCSTtype" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                            <asp:ListItem Value="A">Against C Form</asp:ListItem>
                                                            <asp:ListItem Value="W">Without C Form</asp:ListItem>
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server" InitialValue="0"
                                                            ControlToValidate="DdlCSTtype" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Order Confirm ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlOrdConfirm" runat="server" OnTextChanged="DdlOrdConfirm_TextChanged" AutoPostBack="true" CssClass="form-control">
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

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtConfirmDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                                ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <%-- <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server"
                                                                ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarID1" Format="dd-MM-yyyy" TargetControlID="TxtConfirmDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Confirm By" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="TxtConfirmBy" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>


                                    <div class="col-md-2">
                                    </div>



                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                            <asp:Label CssClass="label" Text="Subject" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtSubject" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3" id="dvBrandName" runat="server">
                                            <asp:Label CssClass="label" Text="Brand Name" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtBrandName" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3" id="dvcompanyFor" runat="server">
                                            <asp:Label CssClass="label" Text="For" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtFor" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3" id="dvModelName" runat="server">
                                            <asp:Label CssClass="label" Text="Model No." runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtModelNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-12">
                                        <asp:Label CssClass="label" Text="Note" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtNote" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="BtnContactDetails" />
                                </Triggers>
                            </asp:UpdatePanel>

                            <div style="clear: both; height: 10px;">
                            </div>

                            <%--QUOTATION (ITEM) --%>

                            <div id="DivQuoteItem" runat="server" class="panel panel-widget top-grids">
                                <div class="chute chute-center text-center">

                                    <asp:UpdatePanel ID="UpdPnl2" runat="server">
                                        <ContentTemplate>

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: brown">QUOTATION ITEM</div>
                                                <asp:GridView ID="GvQuotation_T" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvQuotation_T_PageIndexChanging" OnRowDataBound="GvQuotation_T_RowDataBound"
                                                    PageSize="10" ShowFooter="true">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Sr.No.">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfQuoT_TransDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfQuoT_TransNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfQuoT_SrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />

                                                                <asp:HiddenField ID="HfAmount" runat="server" Value='<%#Bind("AMT") %>' />
                                                                <asp:HiddenField ID="HfDisAmount" runat="server" Value='<%#Bind("DISC_AMT") %>' />
                                                                <asp:HiddenField ID="HfAddDisAmount" runat="server" Value='<%#Bind("ADD_DISC_AMT") %>' />
                                                                <asp:HiddenField ID="HfGSTAmount" runat="server" Value='<%#Bind("GST_AMT") %>' />
                                                                <asp:HiddenField ID="HfGSTRate" runat="server" Value='<%#Bind("GST_RATE") %>' />

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
                                                                <asp:TextBox ID="TxtProductName" ForeColor="Blue" Style="width: 300px;" runat="server" OnTextChanged="TxtProductName_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtProductName"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetStockName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT NAME" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:DropDownList runat="server" ID="DdlProductName" ForeColor="Blue" OnSelectedIndexChanged="DdlProductName_OnSelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="QTY" ControlStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" onkeypress="return isNumber(event);" Style="text-align: right;" ID="TxtQuantity" runat="server" Text='<%#Bind("QTY") %>' OnTextChanged="TxtQuantity_OnTextChanged" AutoPostBack="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalQty" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RATE" ControlStyle-Width="110px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtRate" runat="server" OnTextChanged="TxtRate_TextChanged" AutoPostBack="true" Text='<%#Bind("RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="DIS.%" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtDisRate" runat="server" OnTextChanged="TxtDisRate_TextChanged" AutoPostBack="true" Text='<%#Bind("DISC_PER") %>'></asp:TextBox>
                                                                <%-- <asp:RangeValidator runat="server" ID="RangeDis" />--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText=" ADD DIS.%" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtAddDisRate" Style="text-align: right;" OnTextChanged="TxtAddDisRate_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("ADD_DISC_PER") %>'></asp:TextBox>
                                                                <%--  <asp:RangeValidator runat="server" ID="RangeAddDis" />--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="AMOUNT" ControlStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtAmount" runat="server" Text='<%#Bind("G_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalGross_AMT" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CGST %" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtCGSTRate" runat="server" Text='<%#Bind("CGST_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CGST Amt." ControlStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtCGSTAmount" runat="server" Text='<%#Bind("CGST_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalCGST_AMT" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SGST %" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtSGSTRate" runat="server" Text='<%#Bind("SGST_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SGST Amt." ControlStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtSGSTAmount" runat="server" Text='<%#Bind("SGST_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalSGST_AMT" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="IGST %" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtIGSTRate" runat="server" Text='<%#Bind("IGST_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="IGST Amt." ControlStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtIGSTAmount" runat="server" Text='<%#Bind("IGST_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalIGST_AMT" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="TOTAL AMOUNT" ControlStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtTotalAmount" runat="server" Text='<%#Bind("T_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="BtnDeleteRowModelQuo_TGrid" runat="server" OnClick="BtnDeleteRowModelQuo_TGrid_Click" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Button ID="BtnAddRowModelQuo_TGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelQuo_TGrid_Click" CausesValidation="false" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>


                            <%--QUOTATION (AMC) --%>

                            <div id="DivQuoteAMC" runat="server" class="panel panel-widget top-grids">
                                <div class="chute chute-center text-center">

                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: brown">QUOTATION AMC</div>
                                                <asp:GridView ID="GvQuotation_TAMC" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvQuotation_TAMC_PageIndexChanging" OnRowDataBound="GvQuotation_TAMC_RowDataBound"
                                                    PageSize="10" ShowFooter="true">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Sr.No.">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfQuoT_TransDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfQuoT_TransNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfQuoT_SrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                <asp:HiddenField ID="HfBrandCodeGrid" runat="server" Value='<%#Bind("BRAND_CODE") %>' />
                                                                <asp:HiddenField ID="HfModelCodeGrid" runat="server" Value='<%#Bind("MODEL_CODE") %>' />

                                                                <asp:HiddenField ID="HfAmount" runat="server" Value='<%#Bind("G_AMT") %>' />
                                                                <%--  <asp:HiddenField ID="HfDisAmount" runat="server" Value='<%#Bind("DISC_AMT") %>' />
                                                                       <asp:HiddenField ID="HfAddDisAmount" runat="server" Value='<%#Bind("ADD_DISC_AMT") %>' />--%>
                                                                <asp:HiddenField ID="HfGSTAmount" runat="server" Value='<%#Bind("GST_AMT") %>' />
                                                                <asp:HiddenField ID="HfGSTRate" runat="server" Value='<%#Bind("GST_RATE") %>' />


                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="BRAND NAME" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:DropDownList runat="server" ID="DdlBrandName" OnSelectedIndexChanged="DdlBrandName_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="BRAND NAME">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtBrandName" ForeColor="Blue" Style="width: 300px;" onkeyup="SetContextKey()" runat="server" OnTextChanged="TxtBrandName_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtenderBrandName" runat="server" TargetControlID="TxtBrandName"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetBrandName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="MODEL NAME" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:DropDownList runat="server" ID="DdlModelName" ForeColor="Blue" OnSelectedIndexChanged="DdlModelName_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="MODEL NAME">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtModelName" ForeColor="Blue" Style="width: 300px;" runat="server" OnTextChanged="TxtModelName_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtenderModelName" runat="server" TargetControlID="TxtModelName"
                                                                    MinimumPrefixLength="1" UseContextKey="true" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetModelName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="MODEL DESCRIPTION" ControlStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtModelDescription" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="QTY" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtQuantity" onkeypress="return isNumber(event);" Style="text-align: right;" runat="server" Text='<%#Bind("QTY") %>' OnTextChanged="TxtQuantity2_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalAMCQty" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RATE" ControlStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtRate" OnTextChanged="TxtRate_TextChanged3" AutoPostBack="true" runat="server" Text='<%#Bind("RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="DIS.%" Visible="false" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtDisRate" runat="server" Text='<%#Bind("DISC_PER") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText=" ADD DIS.%" Visible="false" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtAddDisRate" Style="text-align: right;" runat="server" Text='<%#Bind("ADD_DISC_PER") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="AMOUNT" ControlStyle-Width="120px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtAmount" runat="server" Text='<%#Bind("AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalAMC_AMT" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CGST %" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtCGSTRate" OnTextChanged="TxtCGSTRate_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("CGST_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CGST Amt." ControlStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtCGSTAmount" runat="server" Text='<%#Bind("CGST_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumAMCTotalCGST_AMT" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SGST %" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" onkeypress="return isNumber(event);" Style="text-align: right;" ID="TxtSGSTRate" runat="server" Text='<%#Bind("SGST_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SGST Amt." ControlStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtSGSTAmount" runat="server" Text='<%#Bind("SGST_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumAMCTotalSGST_AMT" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="IGST %" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtIGSTRate" OnTextChanged="TxtIGSTRate_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("IGST_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="IGST Amt." ControlStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtIGSTAmount" runat="server" Text='<%#Bind("IGST_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumAMCTotalIGST_AMT" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="TOTAL AMOUNT" ControlStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtTotalAmount" runat="server" Text='<%#Bind("T_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalAMCAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="BtnDeleteRowModelQuo_TAMCGrid" runat="server" OnClick="BtnDeleteRowModelQuo_TAMCGrid_Click" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>

                                                                <asp:Button ID="BtnAddRowModelQuo_TAMCGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelQuo_TAMCGrid_OnClick" CausesValidation="false" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>


                            <%--QUOTATION CHARGES --%>

                            <div id="DivQuoteCharge" runat="server" class="panel panel-widget top-grids">
                                <div class="chute chute-center text-center">

                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: brown">QUOTATION CHARGES</div>
                                                <asp:GridView ID="GvQuotation_C" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvQuotation_C_PageIndexChanging" OnRowDataBound="GvQuotation_C_RowDataBound"
                                                    PageSize="10" ShowFooter="true">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="SR.NO">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfQuoC_TransDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfQuoC_TransNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfChargesCode" runat="server" Value='<%#Bind("CCODE") %>' />

                                                                <asp:HiddenField ID="HfGSTAmount" runat="server" Value='<%#Bind("GST_AMT") %>' />
                                                                <asp:HiddenField ID="HfGSTRate" runat="server" Value='<%#Bind("GST_RATE") %>' />

                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="NAME OF THE CHARGES">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtChargesName" ForeColor="Blue" Style="width: 300px;" runat="server" OnTextChanged="TxtChargesName_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtenderChargesName" runat="server" TargetControlID="TxtChargesName"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetChragesName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--  <asp:TemplateField HeaderText="NAME OF THE CHARGES">
                                                            <ItemTemplate>
                                                                <asp:DropDownList runat="server" ID="DdlChargesName" OnSelectedIndexChanged="DdlChargesName_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>

                                                        <asp:TemplateField HeaderText="RATE" ControlStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtRate" OnTextChanged="TxtRate_TextChanged1" AutoPostBack="true" runat="server" Text='<%#Bind("PER") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="QTY" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtQuantity" onkeypress="return isNumber(event);" Style="text-align: right;" OnTextChanged="TxtQuantity1_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("QTY") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalCharges_Qty" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CHARGES Amt." ControlStyle-Width="110px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" onkeypress="return isNumber(event);" ID="TxtChargesAmt" Style="text-align: right;" runat="server" Text='<%#Bind("AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalCharge_AMT" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CGST %" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtCGSTRate" Style="text-align: right;" runat="server" Text='<%#Bind("CGST_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CGST Amt." ControlStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtCGSTAmount" Style="text-align: right;" runat="server" Text='<%#Bind("CGST_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalChargesCGST_AMT" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SGST %" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtSGSTRate" Style="text-align: right;" runat="server" Text='<%#Bind("SGST_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SGST Amt." ControlStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtSGSTAmount" Style="text-align: right;" runat="server" Text='<%#Bind("SGST_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalChargesSGST_AMT" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="IGST %" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtIGSTRate" Style="text-align: right;" runat="server" Text='<%#Bind("IGST_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="IGST Amt." ControlStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtIGSTAmount" Style="text-align: right;" runat="server" Text='<%#Bind("IGST_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalChargesIGST_AMT" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="TOTAL AMOUNT" ControlStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtTotalAmount" runat="server" Text='<%#Bind("T_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="BtnDeleteRowModelQuo_CGrid" runat="server" OnClick="BtnDeleteRowModelQuo_CGrid_Click" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Button ID="BtnAddRowModelQuo_CGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelQuo_CGrid_Click" CausesValidation="false" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>

                        <div style="clear: both; height: 10px">
                        </div>

                        <asp:HiddenField ID="HfGrid_C_Total" runat="server" />
                        <asp:HiddenField ID="HfGrid_T_Total" runat="server" />
                        <asp:HiddenField ID="HfGrid_TAMC_Total" runat="server" />

                        <br />

                        <div style="width: 45%; height: 65px; float: left;">
                            <table class="col-md-12">
                                <tr>
                                    <td align="right" style="padding-bottom: 10px;">
                                        <asp:Label CssClass="label" Text="Generate Result ?" runat="server"></asp:Label>
                                    </td>
                                    <td style="padding-left: 10px;">
                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="S">SCREEN</asp:ListItem>
                                            <asp:ListItem Value="H">HTML</asp:ListItem>
                                            <asp:ListItem Value="P">PRINTER</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="TxtFillDiscount" CssClass="form-control" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnFillDiscount" runat="server" Text="Fill Discount %" OnClick="btnFillDiscount_Click" CausesValidation="false" />
                                    </td>
                                </tr>

                                <tr>
                                    <td align="right" style="padding-bottom: 10px;">
                                        <asp:Label CssClass="label" Text="Spcification Print ?" runat="server"></asp:Label>
                                    </td>
                                    <td style="padding-left: 10px;">
                                        <asp:DropDownList ID="DdlSpecificationRst" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="YES">YES</asp:ListItem>
                                            <asp:ListItem Value="NO" Selected="True">NO</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="padding-left: 10px;">
                                        <asp:Button ID="btnqitem" OnClick="btnqitem_Click" runat="server" Text="Print All" CausesValidation="false" CssClass="btn btn-danger btn-block" OnClientClick="aspnetForm.target ='_blank';" />
                                    </td>
                                    <td style="padding-left: 10px;">
                                        <asp:Button ID="Button" runat="server" Text="Print Part" CausesValidation="false" CssClass="btn btn-danger btn-block" />
                                    </td>
                                    <td style="padding-left: 10px;">
                                        <asp:Button ID="Button5" runat="server" Text="Print Labour" CausesValidation="false" CssClass="btn btn-danger btn-block" />
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <div style="width: 35%; height: 70px; float: left; padding-left: 15px;">
                            <table class="col-md-12">
                                <tr>
                                    <td style="padding-left: 10px; padding-bottom: 10px">
                                        <asp:Button ID="Button1" runat="server" Text="Last Sales Item" Width="200" CssClass="btn  btn-success" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 10px; padding-bottom: 10px">
                                        <asp:Button ID="Button2" runat="server" Text="Last Quotation Item" Width="200" CssClass="btn btn-success" />
                                    </td>
                                    <td style="padding-left: 10px;">
                                        <asp:Button ID="Button6" runat="server" Text="Quotation Item Stock" Width="200" CssClass="btn  btn-success" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:UpdatePanel ID="UpdateTotalAmount" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div style="width: 15%; height: 70px; float: right;">

                                    <table class="col-md-12">
                                        <tr>
                                            <td>
                                                <asp:Label CssClass="label" Text="R.O Amt" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding-left: 10px;">
                                                <asp:TextBox ID="TxtROamt" CssClass="form-control grdleftalign" Style="text-align: right;" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
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


    <div id="DivView" runat="server" class="grids">

        <div class="panel panel-widget top-grids">
            <asp:HiddenField ID="HfQuoteType" runat="server" />
            <asp:Button ID="BtnAdd" runat="server" Text="NEW(Item)" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click" />
            <asp:Button ID="BtnNewAMC" runat="server" Text="NEW(AMC)" CssClass="btn btn-lg btn-primary" OnClick="BtnNewAMC_Click" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />

            <div style="float: right;">
                <asp:Label CssClass="label" Style="color: red;" Text="Search By Quotation No./Quotation Type/Supplier Name/Brand Name/Model Name/Prepared By" runat="server"></asp:Label><br />
                <asp:TextBox ID="TxtSearch" runat="server" Style="width: 100%;" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>

        </div>


        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBranchCode" runat="server" />
        <asp:HiddenField ID="HfTranDate" runat="server" />
        <asp:HiddenField ID="HfTranNo" runat="server" />
        <%--  <asp:HiddenField ID="HfQuotationType" runat="server" />--%>

        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvQuotation_M" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvQuotation_M_PageIndexChanging" OnRowCommand="GvQuotation_M_RowCommand"
                        OnRowDataBound="GvQuotation_M_RowDataBound"
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

                                    <%--   <a href="JavaScript:divexpandcollapse('div<%# Eval("MODEL_CODE") %>');">
                                        <img id='imgdiv<%# Eval("MODEL_CODE") %>' width="15px" border="0" src="/images/plus.gif" />
                                    </a>--%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="QUOTATION DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblQuotationDate" runat="server" Text='<%#Bind("QuotationDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="QUOTATION NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblQuotationNo" runat="server" Text='<%#Bind("QUO_NO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="QUOTATION TYPE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblQuotationType" runat="server" Text='<%#Bind("quo_type") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="PARTY NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblPartyName" runat="server" Text='<%#Bind("PARTY_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="BRAND NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblBrandName" runat="server" Text='<%#Bind("BRAND_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="MODEL NAME ">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblModelName" runat="server" Text='<%#Bind("MODEL_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PREPARE BY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblPrepareBy" runat="server" Text='<%#Bind("BrokerName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="ORDER CONFIRM">
                                <ItemTemplate>
                                    <asp:Label ID="lblOrderConfirm" CssClass="label" runat="server" Text='<%# Bind("Confirm_Flag") %>'></asp:Label>
                                    <%-- <asp:DropDownList ID="DdlOrdConfirm" runat="server" ></asp:DropDownList>--%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DUE DAYS">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblDueDays" runat="server"></asp:Label>
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

                    <h4 class="modal-title">DELETE QUOTATION DETAIL</h4>
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

        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">UPDATE QUOTATION DETAIL</h4>
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

    <div class="modal fade" tabindex="-1" id="CmpCopyModelItems" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">


                    <h4 class="modal-title" style="color: red">Search Model Details</h4>
                </div>
                <div class="modal-body">

                    <div id="Div4" runat="server" class="grids">

                        <div class="panel panel-widget top-grids">
                            <asp:UpdatePanel ID="updexportacc" runat="server">
                                <ContentTemplate>
                                    Brand Name
                            <asp:DropDownList ID="DdlBrandNameCopy" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlBrandNameCopy_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                                    Model Name
                            <asp:DropDownList ID="DdlModelNameCopy" runat="server" OnSelectedIndexChanged="DdlModelNameCopy_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                                <asp:ListItem Value="0"></asp:ListItem>
                            </asp:DropDownList>
                                    Model Description
                                        <asp:TextBox ID="TxtModelDescrption" runat="server" CssClass="form-control">
                                        </asp:TextBox>

                                    Search Item
                                          <asp:RadioButton ID="rdBtnAllItem" runat="server" GroupName="ModelItems" />
                                    <asp:Label CssClass="label" Text="All Item" runat="server"></asp:Label>
                                    <asp:RadioButton ID="rdBtnMajorItem" runat="server" GroupName="ModelItems" />
                                    <asp:Label CssClass="label" Text="Major Item" runat="server"></asp:Label>
                                    <asp:RadioButton ID="rdBtnNoramlItem" runat="server" GroupName="ModelItems" />
                                    <asp:Label CssClass="label" Text="Normal Item" runat="server"></asp:Label>


                                    <br />

                                    <asp:Button ID="btnSearchModelItems" runat="server" Text="Search Model Details" CssClass="btn btn-lg btn-success" Width="230px" Height="35px" OnClick="btnSearchModelItems_Click" CausesValidation="false" />


                                    <br />
                                    <br />

                                    <div class="h5" style="color: brown">MODEL ITEM DETAILS</div>

                                    <%--   <asp:UpdatePanel ID="updgridpnl" runat="server">
                                    <ContentTemplate>--%>
                                    <asp:Label ID="errorlbl" runat="server"></asp:Label>
                                    <asp:GridView ID="GvStockModalDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanged="GvStockModalDetails_PageIndexChanged" OnRowCommand="GvStockModalDetails_RowCommand"
                                        PageSize="10" ShowFooter="true">
                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkSelectItem" runat="server" />
                                                    <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PRODUCT NAME">

                                                <ItemTemplate>
                                                    <%-- <asp:DropDownList runat="server" ID="DdlProductName"></asp:DropDownList>--%>
                                                    <asp:Label CssClass="label grdleftalign" ID="lblStockName" runat="server" Text='<%#Bind("SNAME") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="QUANTITY">
                                                <ItemTemplate>
                                                    <%--  <asp:TextBox CssClass="form-control" ID="TxtQuantity" onkeypress="return isNumber(event);" style="text-align:right;" runat="server" Text='<%#Bind("QTY") %>'></asp:TextBox>--%>
                                                    <asp:Label CssClass="label grdleftalign" ID="lblQty" runat="server" Text='<%#Bind("QTY") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkBoxMajor" runat="server" Checked='<%#Convert.ToBoolean(Eval("CHK_MAJOR")) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="N">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkBoxNormal" runat="server" Checked='<%#Convert.ToBoolean(Eval("CHK_NORMAL")) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                      <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                    </asp:GridView>



                                    <%--   </ContentTemplate>
                                </asp:UpdatePanel>--%>
                                    <br />

                                    <asp:Button ID="btnSelectAll" runat="server" Text="Select All Record" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnSelectAll_Click" CausesValidation="false" />
                                    <asp:Button ID="btnDeSelectAll" runat="server" Text="De-Select All Record" CssClass="btn btn-lg btn-primary" Width="220px" Height="35px" OnClick="btnDeSelectAll_Click" CausesValidation="false" />
                                    <br />
                                    <br />
                                    <asp:Button ID="BtnProcessRecord" runat="server" Text="Process Record" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="BtnProcessRecord_Click" CausesValidation="false" />
                                    <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK</button>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <script type="text/javascript">
        function HideModelCopyModelItem() {
            $("#CmpCopyModelItems").modal('hide');
        }

        function ShowModelCopyModelItem() {

            $("#CmpCopyModelItems").modal('show');

        }
    </script>





    <script src="js/proton.js"></script>

    <div class="modalquo fade" tabindex="-1" id="CmpSearchPartyModel" data-keyboard="false" data-backdrop="static">
        <div class="modalquo-dialog">
            <div class="modalquo-content">
                <div class="modalquo-header">
                    <h4 class="modalquo-title" style="color: red">Search Party Model </h4>
                </div>
                <div class="modalquo-body" style="height: auto">
                    <div id="Div1" runat="server" class="grids">
                        <div class="panel panel-widget top-grids">

                            <asp:UpdatePanel ID="UpdPartyModelPopup" runat="server">
                                <ContentTemplate>
                                    <div style="float: left; height: auto; width: 100%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12" border="0">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" ForeColor="Blue" Text=" Name of the Party" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <%--   <asp:TextBox ID="TxtAccountNamePopUp" style="z-index:2;" OnTextChanged="TxtAccountNamePopUp_TextChanged" Width="200px" ForeColor="Blue" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <asp:HiddenField ID="HfAcodePopUp" runat="server" />
                                                            <ajax:AutoCompleteExtender  ID="AutoCompleteTxtAccountNamePopUp" runat="server" TargetControlID="TxtAccountNamePopUp"
                                                                MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                ServiceMethod="GetAccountName">
                                                            </ajax:AutoCompleteExtender>--%>

                                                        <asp:DropDownList ID="DdlAcounntNamePopup" runat="server" OnSelectedIndexChanged="DdlAcounntNamePopup_SelectedIndexChanged" Style="width: 300px;" AutoPostBack="true"></asp:DropDownList>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Model Sr.No" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlModelSrNo" Style="width: 300px;" runat="server" OnSelectedIndexChanged="DdlModelSrNo_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Brand Name" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtBrandNamePopUp" Width="300px" runat="server" CssClass="form-control">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Party Sr.No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtPartySrNo" runat="server" Width="200px" CssClass="form-control">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Model Name" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtModelNamePopup" runat="server" Width="300px" CssClass="form-control">
                                                        </asp:TextBox>
                                                        <asp:HiddenField ID="HfModelCode" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Mfg Sr.No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtMfgSrNo" runat="server" Width="200px" CssClass="form-control">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Model Description" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="ModelDescription" runat="server" Width="300px" CssClass="form-control">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Service Type" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlServiceType" runat="server" Width="200px" AutoPostBack="true" CssClass="form-control">
                                                            <asp:ListItem Value="A">AMC</asp:ListItem>
                                                            <asp:ListItem Value="C">Call Charges</asp:ListItem>
                                                            <asp:ListItem Value="W">Under Warranty</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>


                                    <div class="col-md-11">
                                        <div class="col-md-2">
                                            <asp:HiddenField ID="HfSrNo" runat="server" />
                                            <asp:Label CssClass="label" Text="Search Item" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:RadioButton ID="rdBtnAllItem1" runat="server" Font-Bold="true" GroupName="ModelItems" />
                                            <asp:Label CssClass="label" Text="All Item" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:RadioButton CssClass="radfont" ID="rdBtnMajorItem1" runat="server" GroupName="ModelItems" />
                                            <asp:Label CssClass="label" Text="Major Item" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:RadioButton ID="rdBtnNormalItem1" CssClass="radfont" runat="server" GroupName="ModelItems" />
                                            <asp:Label CssClass="label" Text="Normal Item" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Button ID="BtnPartyModelDetails" runat="server" Text="Search Model Items" CausesValidation="false" CssClass="btn btn-lg btn-success" Width="230px" Height="33px" OnClick="BtnPartyModelDetails_Click" />
                                        </div>
                                    </div>
                                    <br />
                                    <br />

                                    <%--<div class="divider"></div>--%>

                                    <%--  <div class="h5" style="color: brown">MODEL ITEM DETAILS</div>--%>

                                    <div class="col-md-12 h5" style="color: brown">MODEL ITEM DETAILS</div>

                                    <asp:Label ID="LblPartyMOdel" runat="server"></asp:Label>
                                    <asp:GridView ID="GvPartyModelDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvPartyModelDetails_PageIndexChanging" OnRowCommand="GvPartyModelDetails_RowCommand"
                                        PageSize="10" ShowFooter="true">
                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkSelectItem" runat="server" />
                                                    <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PRODUCT NAME">

                                                <ItemTemplate>
                                                    <asp:Label CssClass="label grdleftalign" ID="lblStockName" runat="server" Text='<%#Bind("SNAME") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="QUANTITY">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label grdleftalign" ID="lblQty" runat="server" Text='<%#Bind("QTY") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="M">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkBoxMajor" runat="server" Checked='<%#Convert.ToBoolean(Eval("CHK_MAJOR")) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="N">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkBoxNormal" runat="server" Checked='<%#Convert.ToBoolean(Eval("CHK_NORMAL")) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                         <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                    </asp:GridView>



                                    <asp:Button ID="BtnSelectAllRecord" runat="server" Text="Select All Record" CssClass="btn btn-lg btn-primary" Width="200px" Height="33px" OnClick="BtnSelectAllRecord_Click" CausesValidation="false" />

                                    <asp:Button ID="BtnDeSelectAllRecord" runat="server" Text="De-Select All Record" CssClass="btn btn-lg btn-primary" Width="220px" Height="33px" OnClick="BtnDeSelectAllRecord_Click" CausesValidation="false" />

                                    <asp:Button ID="BtnProcessItem" runat="server" Text="Process Record" CssClass="btn btn-lg btn-primary" Width="200px" Height="33px" OnClick="BtnProcessItem_Click" CausesValidation="false" />

                                    <button type="button" style="float: right;" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK</button>



                                </ContentTemplate>
                                <%--    <Triggers>
                                    <asp:PostBackTrigger ControlID="BtnPartyModelDetails" />
                                </Triggers>--%>
                            </asp:UpdatePanel>



                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <script type="text/javascript">
        function HideModelCmpSearchPartyModel() {
            $("#CmpSearchPartyModel").modal('hide');
        }

        function ShowModelCmpSearchPartyModel() {

            $("#CmpSearchPartyModel").modal('show');

        }
    </script>
</asp:Content>
