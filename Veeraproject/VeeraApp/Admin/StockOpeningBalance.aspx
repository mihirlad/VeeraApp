<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="StockOpeningBalance.aspx.cs" Inherits="VeeraApp.StockOpeningBalance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script lang="javascript" type="text/javascript">

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
                    <h4>STOCK OPENING BALANCE</h4>
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

                            <asp:UpdatePanel ID="updpnl" runat="server">
                                <ContentTemplate>

                                    <div class="col-md-12">
                                        <div class="col-md-1">
                                            <asp:Label CssClass="label" Text="Date" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtTranDate" CssClass="form-control" runat="server"></asp:TextBox>

                                            <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtTranDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                              ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server"
                                                ControlToValidate="TxtTranDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <ajax:CalendarExtender runat="server" ID="CalendarID1" Format="dd-MM-yyyy" TargetControlID="TxtTranDate"></ajax:CalendarExtender>
                                        </div>


                                        <%-- <div class="col-md-1">
                                    <asp:Label CssClass="label" Text="Sr No." runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtSrNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>--%>

                                        <%-- <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Product Description" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlProductNameDesc" runat="server" CssClass="form-control">
                                    </asp:DropDownList>

                                      <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldDdlBranch" runat="server" InitialValue="0"
                                                                 ControlToValidate="DdlProductNameDesc" ForeColor="Red">*</asp:RequiredFieldValidator>
                                   </div>--%>

                                        <div class="col-md-2">

                                            <asp:Label CssClass="label" Text="Product Code" ForeColor="Blue" runat="server"></asp:Label>
                                            <asp:HiddenField ID="HfDetailSCode" runat="server" />
                                            <asp:TextBox ID="TxtProductCode" CssClass="form-control" ForeColor="Blue" runat="server" OnTextChanged="TxtProductCode_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtProductCode"
                                                MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                ServiceMethod="GetProductCode">
                                            </ajax:AutoCompleteExtender>
                                        </div>

                                        <div class="col-md-4">
                                            <asp:Label CssClass="label" Text="Product Description" ForeColor="Blue" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtProductName" ForeColor="Blue"  runat="server" OnTextChanged="TxtProductName_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtProductName"
                                                MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                ServiceMethod="GetStockName">
                                            </ajax:AutoCompleteExtender>
                                        </div>

                                        <div class="col-md-1">
                                            <asp:Label CssClass="label" Text="Quantity" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtQuantity" Style="text-align: right;" onkeypress="return isNumber(event);" CssClass="form-control" runat="server"></asp:TextBox>

                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                ControlToValidate="TxtQuantity" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-2">
                                            <asp:Label CssClass="label" Text="Rate" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtRate" CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" runat="server" OnTextChanged="TxtRate_TextChanged" AutoPostBack="true"></asp:TextBox>

                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                ControlToValidate="TxtRate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-2">
                                            <asp:Label CssClass="label" Text="Amount" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtAmount" CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

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
                </div>
            </div>
        </div>
    </div>

    <div id="DivView" runat="server" class="grids">


        <div class="panel panel-widget top-grids">
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />

            <div style="float: right;">
                <asp:Label CssClass="label" Style="color: red;" Text="Search By Product Name/Product Code/Sr No." runat="server"></asp:Label><br />
                <asp:TextBox ID="TxtSearch" runat="server" Style="width: 100%;" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>

        </div>

        <%-- <div class="col-md-3" style="float:right">
                <asp:Label CssClass="label" Text="Search By Product Name/Product Code/Sr No." runat="server"></asp:Label>
                <asp:TextBox ID="TxtSearch" CssClass="form-control" runat="server" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
             </div>--%>

        <div style="clear: both; height: 10px"></div>


        <asp:HiddenField ID="HfTransDate" runat="server" />
        <asp:HiddenField ID="HfTransNo" runat="server" />
        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBranchCode" runat="server" />
        <asp:HiddenField ID="HfYearDate1" runat="server" />
        <asp:HiddenField ID="HfSrNo" runat="server" />

        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

               <div class="tabl-respeonsive" style="height: 450px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvStocktOpeningBalance" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvStocktOpeningBalance_PageIndexChanging" OnRowCommand="GvStocktOpeningBalance_RowCommand"
                        PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                            <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <%-- <asp:HiddenField ID="HfTransNo" runat="server" Value='<%#Bind("TRAN_NO")%>' />--%>
                                    <asp:HiddenField ID="HfTransDateGrid" runat="server" Value='<%#Bind("TRAN_DATE")%>' />

                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblDate" runat="server" Text='<%#Bind("TransDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SR NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblSRNO" runat="server" Text='<%#Bind("SRNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PRODUCT CODE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblProductCode" runat="server" Text='<%#Bind("PROD_CODE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PRODUCT DESCRIPTION">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblProductDescription" runat="server" Text='<%#Bind("ProductName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="QUANTITY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign" ID="lblQuantity" runat="server" Text='<%#Bind("QTY") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="RATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign" ID="lblRate" runat="server" Text='<%#Bind("RATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="AMOUNT">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign" ID="lblAmount" runat="server" Text='<%#Bind("AMT") %>'></asp:Label>
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

                    <h4 class="modal-title">DELETE OPENING STOCK MASTER DETAIL</h4>
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

                    <h4 class="modal-title">UPDATE OPENING STOCK MASTER DETAIL</h4>
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
