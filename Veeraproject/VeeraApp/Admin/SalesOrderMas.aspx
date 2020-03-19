<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="SalesOrderMas.aspx.cs" Inherits="VeeraApp.SalesOrderMas" %>

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





    <script src="../js/jQuery-1.10.0min.js" type="text/javascript"></script>
    <script src="../js/jquery.ui1.9.2jquery-ui.min.js" type="text/javascript"></script>
    <link href="../css/jQuery-ui.css"
        rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
        $(function () {
            $("[id$=TxtProductName]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Admin/PurchaseOrderMas.aspx/GetStockName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {

                            debugger;
                            response($.map(data.d, function (item) {
                                console.log(item);
                                return {
                                    label: item.split('~')[0],
                                    val: item.split('~')[1]
                                    // label: item.split('-')[0]
                                    //  val: item.split('-')[0]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    debugger;

                    $("[id$=HfDetailSCode]").val(i.item.val);

                },
                minLength: 1
            });
        });
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
                    <h4>SALES ORDER</h4>
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

                                    <div class="h5" style="color: brown">ORDER MASTER</div>

                                    <div style="float: left; height: auto; width: 30%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" class="col-md-3" Text="Order No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtOrderNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Validity Days" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtValidityDays" OnTextChanged="TxtValidityDays_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Order Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtOrderDate" OnTextChanged="TxtOrderDate_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarOrderDate" Format="dd-MM-yyyy" TargetControlID="TxtOrderDate"></ajax:CalendarExtender>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Validity Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtValidityDate" OnTextChanged="TxtValidityDate_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server"
                                                            ControlToValidate="TxtValidityDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarID1" Format="dd-MM-yyyy" TargetControlID="TxtValidityDate"></ajax:CalendarExtender>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Supplier A/C" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtAccountName" OnTextChanged="TxtAccountName_TextChanged" ForeColor="Blue" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:HiddenField ID="HfACODE" runat="server" />
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtAccountName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>
                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredAccountName" runat="server"
                                                            ControlToValidate="TxtAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>
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

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" InitialValue="0"
                                                            ControlToValidate="DdlPartyType" ForeColor="Red">*</asp:RequiredFieldValidator>
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


                                    <div style="float: left; height: auto; width: 45%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Reference Name" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtOrderReference" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldTxtPartNo" runat="server"
                                                            ControlToValidate="TxtOrderReference" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>


                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Status" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtStatus" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Close Order" ForeColor="Red" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlOrderClose" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="DivOrderRefDate" runat="server">
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Order Ref.Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtOrderRefDate" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                            ControlToValidate="TxtOrderRefDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender2" Format="dd-MM-yyyy" TargetControlID="TxtOrderRefDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Dispatch Thru" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtDispatchThru" ForeColor="Blue" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderDispatcher" runat="server" TargetControlID="TxtDispatchThru"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetTransporterName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server"
                                                            ControlToValidate="TxtDispatchThru" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Order Confirm ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlOrdConfirm" OnSelectedIndexChanged="DdlOrdConfirm_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Prepared By" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlPreparedBy" runat="server" ForeColor="Blue" CssClass="form-control">
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldDdlPreparedBy" runat="server" InitialValue="0"
                                                            ControlToValidate="DdlPreparedBy" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Confirm Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConfirmDate" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtConfirmDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td></td>
                                                    <td style="padding-left: 15px;">
                                                        <asp:Button ID="BtnAddQuotation" runat="server" Text="Add Quotation" Width="180px" Height="33px" OnClick="BtnAddQuotation_Click"
                                                            CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>


                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Confirm By" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConfirmBy" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td colspan="2" style="padding-left: 10px;">
                                                        <asp:Button runat="server" ID="btnprint" OnClientClick="aspnetForm.target ='_blank';" OnClick="btnprint_Click" Text="View-Challan" />
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
                                    </div>

                                    <div style="float: left; height: auto; width: 25%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Auto Indent?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlAutoIndent" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                            <asp:ListItem Value="Indent">Indent Stock Item</asp:ListItem>
                                                            <asp:ListItem Value="NonIndent">Non-Indent Stock Item</asp:ListItem>
                                                            <asp:ListItem Value="Non+Indent">Non + Indent Stock Item</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>


                                                </tr>
                                                <tr>
                                                    <%-- <td>

                                                        <asp:Button ID="btnprint" runat="server" Text="PRINT" CssClass="btn btn-primary" OnClick="btnprint_Click" CausesValidation="false" />
                                                    </td>--%>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>

                                    <%-- <div class="col-md-12">
                                        <div class="col-md-2" id="DivOrderRefDate" runat="server">
                                            <asp:Label CssClass="label" Text="Order Ref.Date" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtOrderRefDate" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                ControlToValidate="TxtOrderRefDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <ajax:CalendarExtender runat="server" ID="CalendarExtender2" Format="dd-MM-yyyy" TargetControlID="TxtOrderRefDate"></ajax:CalendarExtender>
                                        </div>
                                    </div>--%>
                                </ContentTemplate>
                                <Triggers>
                                    <%-- <asp:AsyncPostBackTrigger ControlID="TxtAccountName" EventName="TextChanged" />--%>
                                    <asp:PostBackTrigger ControlID="BtnAddQuotation" />
                                </Triggers>
                            </asp:UpdatePanel>

                            <div style="clear: both; height: 10px;">
                            </div>

                            <%--ORDER (ITEM) --%>

                            <div id="DivQuoteItem" runat="server" class="panel panel-widget top-grids">
                                <div class="chute chute-center text-center">

                                    <asp:UpdatePanel ID="UpdPnl2" runat="server">
                                        <ContentTemplate>

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: brown">ORDER ITEM</div>
                                                <asp:GridView ID="GvOrderItem" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvOrderItem_PageIndexChanging" OnRowDataBound="GvOrderItem_RowDataBound"
                                                    PageSize="10" ShowFooter="true">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Sr.No.">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfOrdItem_TransDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfOrdItem_TransNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfOrdItem_SrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />

                                                                <asp:HiddenField ID="HfAmount" runat="server" Value='<%#Bind("AMT") %>' />
                                                                <asp:HiddenField ID="HfDisAmount" runat="server" Value='<%#Bind("DIS_AMT") %>' />
                                                                <asp:HiddenField ID="HfGSTAmount" runat="server" Value='<%#Bind("GST_AMT") %>' />
                                                                <asp:HiddenField ID="HfGSTRate" runat="server" Value='<%#Bind("GST_RATE") %>' />

                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="PRODUCT CODE">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtProductCode" Style="width: 100px;" runat="server" ForeColor="Blue" OnTextChanged="TxtProductCode_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtProductCode"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetProductCode">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT NAME">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtProductName" Style="width: 300px;" runat="server" ForeColor="Blue" OnTextChanged="TxtProductName_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtProductName"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetStockName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT NO." ControlStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtProductPartNo" runat="server" Text='<%#Bind("ADD_PART_NO") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT NAME" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:DropDownList runat="server" ID="DdlProductName" OnSelectedIndexChanged="DdlProductName_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="UOM" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtUOM" Enabled="false" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="ORDER QTY." ControlStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtOrderQty" Style="text-align: right;" onkeypress="return isNumber(event);" OnTextChanged="TxtOrderQty_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("QTY") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalQty" ForeColor="Red" Style="text-align: right;" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RATE PER QTY." ControlStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" onkeypress="return isNumber(event);" Style="text-align: right;" ID="TxtRatePerQty" OnTextChanged="TxtRatePerQty_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="DIS. %" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" ID="TxtDiscPer" OnTextChanged="TxtDiscPer_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("DIS_PER") %>'></asp:TextBox>
                                                                <%--   <asp:RangeValidator runat="server" ID="RangeDis" />--%>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="AMOUNT" ControlStyle-Width="130px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" ID="TxtGrossAmount" runat="server" Text='<%#Bind("G_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalGrossAmount" Style="text-align: right;" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="CGST %" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" runat="server" ID="TxtCGSTRate" Text='<%#Bind("CGST_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CGST Amt." ControlStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" ID="TxtCGSTAmount" runat="server" Text='<%#Bind("CGST_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalCGST_AMT" Style="text-align: right;" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SGST %" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" ID="TxtSGSTRate" runat="server" Text='<%#Bind("SGST_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SGST Amt." ControlStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" ID="TxtSGSTAmount" runat="server" Text='<%#Bind("SGST_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalSGST_AMT" ForeColor="Red" Style="text-align: right;" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="IGST %" ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" ID="TxtIGSTRate" runat="server" Text='<%#Bind("IGST_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="IGST Amt." ControlStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" ID="TxtIGSTAmount" runat="server" Text='<%#Bind("IGST_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalIGST_AMT" ForeColor="Red" Style="text-align: right;" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="TOTAL AMOUNT" ControlStyle-Width="140px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" ID="TxtTotalAmount" runat="server" Text='<%#Bind("T_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalAmount" Style="text-align: right;" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="KEPT QTY." ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtKeptQty" OnTextChanged="TxtKeptQty_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("KEPT_QTY") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RETURN QTY." ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" ID="TxtReturnQty" onkeypress="return isNumber(event);" OnTextChanged="TxtReturnQty_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("REJ_QTY") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="O/s QTY." ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" ID="TxtOSQty" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="STATUS">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtStatusQty" runat="server" Text='<%#Bind("STATUS") %>'></asp:TextBox>
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

                            <asp:UpdatePanel ID="UpdateTotalAmount" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div style="width: 20%; height: 70px; float: right;">

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


                            <asp:HiddenField ID="HfOrderItem_Grid" runat="server" />

                            <div style="clear: both; height: 10px">
                            </div>


                            <div style="width: 100%; margin: 0 auto;">
                                <div class="col-md-12">
                                    <div class="col-md-1">
                                        <asp:Button ID="btnClear" runat="server" Text="EXIT" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnClear_Click"
                                            CausesValidation="false" />
                                    </div>
                                    <div class="col-md-1">
                                        <asp:Button ID="BtncallUpd" Text="UPDATE" runat="server" OnClick="BtncallUpd_Click" CssClass="btn btn-lg btn-primary btn-block" />
                                    </div>

                                    <div class="col-md-1">
                                        <asp:Button ID="Btncalldel" runat="server" Text="DELETE" OnClick="Btncalldel_Click" CssClass="btn btn-lg btn-primary btn-block" />
                                    </div>
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
                <asp:Label CssClass="label" Style="color: red;" Text="Search By Order No./Supplier Name/Prepared By" runat="server"></asp:Label><br />
                <asp:TextBox ID="TxtSearch" runat="server" Style="width: 100%;" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
        </div>

        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBranchCode" runat="server" />
        <asp:HiddenField ID="HfTranDate" runat="server" />
        <asp:HiddenField ID="HfTranNo" runat="server" />
        <asp:HiddenField ID="HfTransType" runat="server" />


        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                    <div class="table-responsive">
                        <asp:GridView ID="GvOrder_Master" CssClass="table table-vcenter table-condensed table-bordered"
                            runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvOrder_Master_PageIndexChanging" OnRowCommand="GvOrder_Master_RowCommand"
                            OnRowDataBound="GvOrder_Master_RowDataBound"
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

                                        <a href="JavaScript:divexpandcollapse('div<%# Eval("TRAN_NO") %>');">
                                            <img id='imgdiv<%# Eval("TRAN_NO") %>' width="15px" border="0" src="/images/plus.gif" />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ORDER NO.">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="lblOrderNo" runat="server" Text='<%#Bind("ORD_NO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ORDER DATE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign" ID="lblOrderDate" runat="server" Text='<%#Bind("OrderDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="SUPPLIER NAME">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdleftalign" ID="lblAccountName" runat="server" Text='<%#Bind("AccountName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="REFERENCE NAME">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdleftalign" ID="lblReferenceName" runat="server" Text='<%#Bind("ORD_REF") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="PREPARED BY">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdleftalign" ID="lblPreparedBy" runat="server" Text='<%#Bind("PersonName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="NET AMOUNT">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdrightalign" ID="lblNetAmount" runat="server" Text='<%#Bind("NET_AMT") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ORDER CONFIRM ?">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="lblOrderFlag" runat="server" Text='<%#Bind("Order_Confirm") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ORDER CLOSE ?">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="lblOrderClose" runat="server" Text='<%#Bind("Order_Close") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="CREATED BY">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="TxtCreatedBy" runat="server" Text='<%#Bind("INS_USERID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="CREATED DATE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="TxtCreatedDate" runat="server" Text='<%#Bind("INS_DATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="UPDATED BY">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="TxtUpdatedBy" runat="server" Text='<%#Bind("UPD_USERID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="UPDATED DATE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="TxtUpdatedDate" runat="server" Text='<%#Bind("UPD_DATE") %>'></asp:Label>


                                        <tr>
                                            <td colspan="100%">
                                                <div id='div<%#Eval("TRAN_NO") %>' class="table-responsive" style="display: none; background-color: lightgray">
                                                    <div style="border: 1px solid red; background: #00bcd4; color: white; padding: 1px; border-radius: 7px;">
                                                        <h4>ORDER ITEMS</h4>
                                                    </div>

                                                    <asp:GridView ID="GvNestedOrderItem" CssClass="table table-vcenter table-condensed table-bordered"
                                                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvNestedOrderItem_PageIndexChanging"
                                                        PageSize="10">
                                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="Sr.No.">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="HfOrdItem_TransDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                    <asp:HiddenField ID="HfOrdItem_TransNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                    <asp:HiddenField ID="HfOrdItem_SrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                    <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />

                                                                    <%#Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="PRODUCT NO.">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblProductPartNo" runat="server" Text='<%#Bind("ADD_PART_NO") %>'></asp:Label>
                                                                    <asp:HiddenField ID="HfStockCode" runat="server" Value='<%#Bind("SCODE") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="PRODUCT CODE">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblProductCode" runat="server" Text='<%#Bind("PROD_CODE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="PRODUCT NAME">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblProductName" CssClass="label" Text='<%#Bind("SNAME") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="UOM">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblUOM" runat="server" Text='<%#Bind("UOM") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="ORDER QTY.">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblOrderQty" OnTextChanged="TxtOrderQty_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("QTY") %>'></asp:Label>
                                                                </ItemTemplate>

                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="RATE PER QTY.">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblRatePerQty" OnTextChanged="TxtRatePerQty_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("RATE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="AMOUNT">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblAmount" runat="server" Text='<%#Bind("G_AMT") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="CGST %">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" runat="server" ID="lblCGSTRate" Text='<%#Bind("CGST_RATE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="CGST Amt.">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblCGSTAmount" runat="server" Text='<%#Bind("CGST_AMT") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="SGST %">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblSGSTRate" runat="server" Text='<%#Bind("SGST_RATE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="SGST Amt.">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblSGSTAmount" runat="server" Text='<%#Bind("SGST_AMT") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="IGST %">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblIGSTRate" runat="server" Text='<%#Bind("IGST_RATE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="IGST Amt.">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblIGSTAmount" runat="server" Text='<%#Bind("IGST_AMT") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="TOTAL AMOUNT" ControlStyle-Width="150px">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblTotalAmount" runat="server" Text='<%#Bind("T_AMT") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="KEPT QTY.">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblKeptQty" runat="server" Text='<%#Bind("KEPT_QTY") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="RETURN QTY.">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblReturnQty" runat="server" Text='<%#Bind("REJ_QTY") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="O/s QTY.">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblOSQty" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="STATUS">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblStatusQty" runat="server" Text='<%#Bind("STATUS") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>

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

                    <h4 class="modal-title">DELETE PURCHASE ORDER DETAIL</h4>
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

                    <h4 class="modal-title">UPDATE PURCHASE ORDER DETAIL</h4>
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


    <div class="modal fade" tabindex="-1" id="CmpAddQuotation" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title" style="color: red">Quotation Details</h4>
                </div>
                <div class="modal-body">

                    <div id="Div1" runat="server" class="grids">

                        <div class="panel panel-widget top-grids">
                            Find
                            <asp:TextBox ID="TxtAMCQuoatationTerms" CssClass="form-control" runat="server"></asp:TextBox>


                            <div class="h5" style="color: brown; text-align: left">Quotation Details</div>
                             <asp:UpdatePanel ID="UpModalAddChallan" runat="server">
                                <ContentTemplate>

                            <asp:GridView  ID="GvAddQuotationDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                PageSize="10" ShowFooter="true">
                                <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                <Columns>

                                    <asp:TemplateField HeaderText="Sr.No.">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HfQuoTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                            <asp:HiddenField ID="HfQuoTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />


                                            <%#Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="QUOTATION NO.">
                                        <ItemTemplate>
                                            <asp:Label CssClass="label grdcenteralign" ID="lblChallanNo" runat="server" Text='<%#Bind("QUO_NO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="QUOATAION DATE">
                                        <ItemTemplate>
                                            <asp:Label CssClass="label grdcenteralign" ID="lblQuotationDate" runat="server" Text='<%#Bind("QUO_DATE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkQuotationNo" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>
                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                            </asp:GridView>


                             </ContentTemplate>
                                     <Triggers>
                                    <asp:PostBackTrigger ControlID="btnAddQuotationProcess" />
                            
                                    <asp:PostBackTrigger ControlID="GvAddQuotationDetails" />


                                </Triggers>

                            </asp:UpdatePanel>
                            <center> <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK </button> </center>
                            <asp:Button ID="btnAddQuotationProcess" runat="server" Text="Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnAddQuotationProcess_Click" CausesValidation="false" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function HideModelAddQoutation() {

            $("#CmpAddQuotation").modal('hide');
        }

        function ShowModelAddQoutation() {

            $("#CmpAddQuotation").modal('show');

        }
        function SelectionAlert() {

            alert("Must be select Party Customer Name !");

        }
    </script>

</asp:Content>
