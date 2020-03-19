<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="StockMaster.aspx.cs" Inherits="VeeraApp.StockMaster" %>

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
                    <h4>STOCK MASTER</h4>
                </div>
            </div>
        </div>
    </div>

    <%-- <div style="clear: both; height: 10px">
    </div>--%>

    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">

                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">

                            <div class="h5" style="color: brown">STOCK MASTER</div>

                            <div style="float: left; height: auto; width: 45%;">
                                <div class="col-md-12">
                                    <table class="col-md-12">

                                        <tr>
                                            <td align="right" style="padding-bottom: 10px;">
                                                <asp:Label CssClass="label" Text="Product Code" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding-left: 10px;">
                                                <asp:TextBox ID="TxtProductCode" CssClass="form-control" runat="server"></asp:TextBox>

                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldTxtProductCode" runat="server"
                                                    ControlToValidate="TxtProductCode" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td align="right" style="padding-bottom: 10px;">
                                                <asp:Label CssClass="label" Text="Part No" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding-left: 10px;">
                                                <asp:TextBox ID="TxtPartNo" CssClass="form-control" runat="server"></asp:TextBox>

                                              <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldTxtPartNo" runat="server"
                                                    ControlToValidate="TxtPartNo" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="padding-bottom: 10px;">
                                                <asp:Label CssClass="label" Text="HSN Code" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding-left: 10px;">
                                                <asp:TextBox ID="TxtHsnCode" CssClass="form-control" runat="server" ValidationGroup="NumericValidate"></asp:TextBox>

                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldTxtHsnCode" runat="server"
                                                    ControlToValidate="TxtHsnCode" ForeColor="Red">*</asp:RequiredFieldValidator>

                                                <asp:RegularExpressionValidator ID="RegularExpressionTxtHsnCode" runat="server"
                                                    ControlToValidate="TxtHsnCode"
                                                    ErrorMessage="Only numeric allowed" ForeColor="Red"
                                                    ValidationExpression="^[0-9]*$" ValidationGroup="NumericValidate">Only numeric allowed
                                                </asp:RegularExpressionValidator>
                                            </td>
                                            <td align="right" style="padding-bottom: 10px;">
                                                <asp:Label CssClass="label" Text="UOM" ForeColor="Blue" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding-left: 10px;">
                                                <asp:DropDownList ID="DdlUOM" ForeColor="Blue" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="0">SELECT UOM</asp:ListItem>
                                                </asp:DropDownList>

                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredDdlUOM" runat="server" InitialValue="0"
                                                    ControlToValidate="DdlUOM" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="padding-bottom: 10px;">
                                                <asp:Label CssClass="label" Text="Product Name" runat="server"></asp:Label>
                                            </td>
                                            <td colspan="3" style="padding-left: 10px;">
                                                <asp:TextBox ID="TxtProductName" CssClass="form-control" runat="server"></asp:TextBox>

                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldTxtProductName" runat="server"
                                                    ControlToValidate="TxtProductName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="padding-bottom: 10px;">
                                                <asp:Label CssClass="label" Text="Category Name" ForeColor="Blue" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding-left: 10px;">
                                                <asp:DropDownList ID="DdlCategoryName" runat="server" ForeColor="Blue" CssClass="form-control">
                                                </asp:DropDownList>

                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredDdlCategoryName" runat="server" InitialValue="0"
                                                    ControlToValidate="DdlCategoryName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td align="right" style="padding-bottom: 10px;">
                                                <asp:Label CssClass="label" Text="Order Qty." runat="server"></asp:Label>
                                            </td>
                                            <td style="padding-left: 10px;">
                                                <asp:TextBox ID="TxtOrderQty" Style="text-align: right;" onkeypress="return isNumber(event);" CssClass="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="padding-bottom: 10px;">
                                                <asp:Label CssClass="label" Text="Max Qty."  runat="server"></asp:Label>
                                            </td>
                                            <td style="padding-left: 10px;">
                                                <asp:TextBox ID="TxtMaxQty" CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" runat="server"></asp:TextBox>
                                            </td>
                                            <td align="right" style="padding-bottom: 10px;">
                                                <asp:Label CssClass="label" Text="Min Qty." runat="server"></asp:Label>
                                            </td>
                                            <td style="padding-left: 10px;">
                                                <asp:TextBox ID="TxtMinQty" CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="padding-bottom: 10px;">
                                                <asp:Label CssClass="label" Text="Description" runat="server"></asp:Label>
                                            </td>
                                            <td colspan="3" style="padding-left: 10px;">
                                                <asp:TextBox ID="TxtProductDesription" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="padding-bottom: 10px;">
                                                <asp:Label CssClass="label" Text="Stock Item Active" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding-left: 10px;">
                                                <asp:DropDownList ID="DdlStockActive" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="Y">ACTICE</asp:ListItem>
                                                    <asp:ListItem Value="N">INACTIVE</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>

                            <div class="h5" style="color: brown;">STOCK RATE MASTER</div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div style="float: left; height: auto; width: 45%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Purchase Rate" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtPurchaseRate" Style="text-align: right;" onkeypress="return isNumber(event);" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Sale Rate" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtSalesRate" Style="text-align: right;" onkeypress="return isNumber(event);" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="VAT %" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtVat" Style="text-align: right;" onkeypress="return isNumber(event);" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Additional VAT %" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtAddVat" Style="text-align: right;" onkeypress="return isNumber(event);" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="CST VAT %" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtCstVat" Style="text-align: right;" onkeypress="return isNumber(event);" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="CST Full VAT %" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtCstFullVat" Style="text-align: right;" onkeypress="return isNumber(event);" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="GST %" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtGST" OnTextChanged="TxtGST_TextChanged" Style="text-align: right;" onkeypress="return isNumber(event);" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtGST" ForeColor="Red">*</asp:RequiredFieldValidator>

                                                        <asp:RegularExpressionValidator ID="RegularExpressionTxtGST" runat="server"
                                                            ControlToValidate="TxtGST"
                                                            ErrorMessage="Only numeric allowed" ForeColor="Red"
                                                            ValidationExpression="^[0-9]*$" ValidationGroup="NumericValidate">Only numeric allowed
                                                        </asp:RegularExpressionValidator>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="CGST %" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtCGST" Style="text-align: right;" onkeypress="return isNumber(event);" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="SGST %" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtSGST" Style="text-align: right;" onkeypress="return isNumber(event);" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="IGST %" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtIGST" Style="text-align: right;" onkeypress="return isNumber(event);" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>


                            <div style="clear: both; height: 10px;">
                            </div>



                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-widget top-grids">
                <div class="chute chute-center text-center">



                    <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                        <div class="h5" style="color: brown">BRANCH STOCK BALANCE </div>
                        <asp:GridView ID="GvBranchStock" CssClass="table table-vcenter table-condensed table-bordered"
                            runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvBranchStock_PageIndexChanging"
                            PageSize="10">
                            <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                            <Columns>

                                <asp:TemplateField HeaderText="BRANCH NAME">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HfBranchCode" runat="server" Value='<%#Bind("BRANCH_CODE") %>' />
                                        <asp:Label CssClass="label grdleftalign" ID="lblBranchName" runat="server" Text='<%#Bind("BRANCH_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="PURCHASE RATE">
                                    <ItemTemplate>
                                        <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtPurchaseRate" runat="server" Text='<%#Bind("PUR_RATE") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SALE RATE">
                                    <ItemTemplate>
                                        <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtSaleRate" runat="server" Text='<%#Bind("SAL_RATE") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OPENING QUANTITY">
                                    <ItemTemplate>
                                        <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtOpeningQty" runat="server" Text='<%#Bind("OP_QTY") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MAXIMUM QUANTITY">
                                    <ItemTemplate>
                                        <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtMaxQty" runat="server" Text='<%#Bind("MAX_QTY") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MINIMUM QUANTITY">
                                    <ItemTemplate>
                                        <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtMinQty" runat="server" Text='<%#Bind("MIN_QTY") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ORDER QUANTITY">
                                    <ItemTemplate>
                                        <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtOrdQty" runat="server" Text='<%#Bind("ORDER_QTY") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>



                            </Columns>
                        </asp:GridView>



                    </div>
                </div>
            </div>

            <div style="clear: both; height: 10px;">
            </div>

            <div class="col-md-12">
                <div class="col-md-3 bs-component mb10">
                    <asp:Button ID="btnClear" runat="server" Text="EXIT" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnClear_Click"
                        CausesValidation="false" />
                </div>
                <div class="col-md-3 bs-component mb10">
                    <asp:Button ID="BtncallUpd" Text="UPDATE" runat="server" OnClick="BtncallUpd_Click" CssClass="btn btn-lg btn-primary btn-block" />
                </div>

                <div class="col-md-3 bs-component mb10">
                    <asp:Button ID="Btncalldel" runat="server" Text="DELETE" OnClick="Btncalldel_Click" CssClass="btn btn-lg btn-primary btn-block" />
                </div>
            </div>

        </div>
    </div>


    <div id="DivView" runat="server" class="grids">


        <div class="panel panel-widget top-grids">
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />

            <div style="float: right;">
                <asp:Label CssClass="label" Style="color: red;" Text="Search By Category Name/Product Code/Product Name/HSN Code/Part No" runat="server"></asp:Label><br />
                <asp:TextBox ID="TxtSearch" runat="server" Style="width: 100%;" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>

        </div>

        <%-- <div class="col-md-4">
            <asp:Label CssClass="label" Text="Search By Category Name/Product Code/Product Name/HSN Code/Part No" runat="server"></asp:Label>
            <asp:TextBox ID="TxtSearch" CssClass="form-control" runat="server" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
        </div>--%>

        <div style="clear: both; height: 10px"></div>

        <asp:HiddenField ID="HfStockCode" runat="server" />
        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfYearDate1" runat="server" />

        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="table-responsive" style="height: 500px; overflow-y: scroll">
                <div class="table-responsive">
                    <asp:GridView ID="GvStocktMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvStocktMaster_PageIndexChanging" OnRowCommand="GvStocktMaster_RowCommand"
                        OnRowDataBound="GvStocktMaster_RowDataBound"
                        PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                            <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("SCODE") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <asp:HiddenField ID="HfStockCode" runat="server" Value='<%#Bind("SCODE")%>' />

                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("SCODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("SCODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                    <a href="JavaScript:divexpandcollapse('div<%# Eval("SCODE") %>');">
                                        <img id='imgdiv<%# Eval("SCODE") %>' width="15px" border="0" src="/images/plus.gif" />
                                    </a>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PRODUCT CODE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdcenteralign" ID="lblProductCode" runat="server" Text='<%#Bind("PROD_CODE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PART NO">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdcenteralign" ID="lblPartNo" runat="server" Text='<%#Bind("PART_NO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HSN CODE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdcenteralign" ID="lblHsnCode" runat="server" Text='<%#Bind("HSN_NO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PRODUCT NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblProductName" runat="server" Text='<%#Bind("SNAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UOM">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblUOM" runat="server" Text='<%#Bind("UOM") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CATEGORY NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblCategoryName" runat="server" Text='<%#Bind("CategoryName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--       <asp:TemplateField HeaderText="MAX QTY.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblMaxQty" runat="server" Text='<%#Bind("MAX_QTY") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="MIN QTY.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblMinQty" runat="server" Text='<%#Bind("MIN_QTY") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="ORDER QTY.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblOrderQty" runat="server" Text='<%#Bind("ORDER_QTY") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="PURCHASE RATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblPurchaseRate" runat="server" Text='<%#Bind("PUR_RATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SALE RATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblSaleRate" runat="server" Text='<%#Bind("SAL_RATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="VAT %">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblVatRate" runat="server" Text='<%#Bind("VAT_RATE") %>'></asp:Label>
                                </ItemTemplate>
                                   </asp:TemplateField>
                                <asp:TemplateField HeaderText=" ADDITIONAL VAT %">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblAddRate" runat="server" Text='<%#Bind("ADD_VAT_RATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText=" CST VAT %">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblCstVat" runat="server" Text='<%#Bind("CST_RATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText=" CST FULL VAT %">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblCstFullVat" runat="server" Text='<%#Bind("CSTFULL_RATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="GST">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign" ID="lblGST" runat="server" Text='<%#Bind("GST_RATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CGST">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign" ID="lblCGST" runat="server" Text='<%#Bind("CGST_RATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SGST">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign" ID="lblSGST" runat="server" Text='<%#Bind("SGST_RATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IGST">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign" ID="lblIGST" runat="server" Text='<%#Bind("IGST_RATE") %>'></asp:Label>

                                    <tr>
                                        <td colspan="100%">
                                            <div id='div<%#Eval("SCODE") %>' class="table-responsive" style="display: none; background-color: lightgray">
                                                <div style="border: 1px solid red; background: #00bcd4; color: white; padding: 1px; border-radius: 7px;">
                                                    <h4>BRANCH STOCK BALANCE</h4>
                                                </div>

                                                <asp:GridView ID="GvNestedBranchStock" Style="background: #e6ffee;" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="BRANCH NAME">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfBranchCode" runat="server" Value='<%#Bind("BRANCH_CODE") %>' />
                                                                <asp:Label CssClass="label grdleftalign" ID="lblBranchName" runat="server" Text='<%#Bind("BRANCH_NAME") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PURCHASE RATE">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdrightalign" ID="TxtPurchaseRate" runat="server" Text='<%#Bind("PUR_RATE") %>' Enabled="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SALE RATE">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdrightalign" ID="TxtSaleRate" runat="server" Text='<%#Bind("SAL_RATE") %>' Enabled="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="OPENING QUANTITY">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdrightalign" ID="TxtOpeningQty" runat="server" Text='<%#Bind("OP_QTY") %>' Enabled="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="MAXIMUM QUANTITY">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdrightalign" ID="TxtMaxQty" runat="server" Text='<%#Bind("MAX_QTY") %>' Enabled="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="MINIMUM QUANTITY">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdrightalign" ID="TxtMinQty" runat="server" Text='<%#Bind("MIN_QTY") %>' Enabled="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ORDER QUANTITY">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdrightalign" ID="TxtOrdQty" runat="server" Text='<%#Bind("ORDER_QTY") %>' Enabled="false"></asp:Label>
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

                    <h4 class="modal-title">DELETE STOCK MASTER DETAIL</h4>
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

                    <h4 class="modal-title">UPDATE STOCK MASTER DETAIL</h4>
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
