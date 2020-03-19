<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="PartyStockMaster.aspx.cs" Inherits="VeeraApp.PartyStockMaster" %>

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


    <asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updpnl" runat="server">
        <ContentTemplate>
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
                            <h4>PARTY STOCK MASTER</h4>
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



                                    <div style="float: left; height: auto; width: 100%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Account Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtAccountName" OnTextChanged="TxtAccountName_TextChanged" ForeColor="Blue" AutoPostBack="true" Width="350px" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:HiddenField ID="HfACODE" runat="server" />
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtAccountName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldDdlBranch" runat="server" InitialValue="0"
                                                            ControlToValidate="TxtAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Accounts Group Name" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtGroupName" CssClass="form-control" Width="350px" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Product Code" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtProductCode" ForeColor="Blue" CssClass="form-control" Width="200px" OnTextChanged="TxtProductCode_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                         <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtProductCode"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetProductCode">
                                                                </ajax:AutoCompleteExtender>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Product Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <%--<td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlProductName" runat="server" Width="350px" OnSelectedIndexChanged="DdlProductName_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" InitialValue="0"
                                                            ControlToValidate="TxtProductName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>--%>
                                                    <td style="padding-left: 10px;">
                                                        <asp:HiddenField ID="HfDetailSCode" runat="server" />
                                                         <asp:TextBox ID="TxtProductName" ForeColor="Blue" Style="width: 350px;" runat="server" OnTextChanged="TxtProductName_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="TxtProductName"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetStockName">
                                                                </ajax:AutoCompleteExtender>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Category Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtCategoryName" Width="350px" ForeColor="Blue" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Rate" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtRate" CssClass="form-control" Width="200px" onkeypress="return isNumber(event);" Style="text-align: right;" runat="server"></asp:TextBox>

                                                        <%--<asp:RegularExpressionValidator id="myRegex" runat="server"
                                                                ControlToValidate="TxtRate" ValidationExpression="^[0-9]{1,5}(\.[0-9]{0,2})?$"
                                                                 ErrorMessage="Decimal out of range" ForeColor="Red" />--%>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Dis. %" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtDiscount" OnTextChanged="TxtDiscount_TextChanged" Width="200px" AutoPostBack="true" CssClass="form-control" onkeypress="return isNumber(event);" Style="text-align: right;" runat="server"></asp:TextBox>

                                                        <%--  <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server"
                                                                              ControlToValidate="TxtDiscount" ValidationExpression="^[0-9]{1,5}(\.[0-9]{0,2})?$"
                                                                         ErrorMessage="Decimal out of range" ForeColor="Red" />--%>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Dis.Rate" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">

                                                        <asp:TextBox ID="TxtDiscountRate" CssClass="form-control" Width="200px" onkeypress="return isNumber(event);" Style="text-align: right;" runat="server"></asp:TextBox>

                                                        <%--    <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server"
                                                                    ControlToValidate="TxtDiscountRate" ValidationExpression="^[0-9]{1,5}(\.[0-9]{0,2})?$"
                                                                 ErrorMessage="Decimal out of range" ForeColor="Red" />    --%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Rank" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlRank" runat="server" Width="350px" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT RANK TYPE</asp:ListItem>
                                                            <asp:ListItem Value="A">A</asp:ListItem>
                                                            <asp:ListItem Value="B">B</asp:ListItem>
                                                            <asp:ListItem Value="C">C</asp:ListItem>
                                                            <asp:ListItem Value="D">D</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
                                    </div>



                                    <div style="clear: both; height: 10px;">
                                    </div>


                                    <div class="panel panel-widget top-grids">
                                        <div class="chute chute-center text-center">

                                            <%-- <asp:UpdatePanel ID="UpdPnl2" runat="server">
                                        <ContentTemplate>--%>

                                            <div class="table-responsive">
                                                <div class="h5" style="color: brown">PARTY STOCK DETAILS</div>
                                                <asp:Label ID="errorlbl" runat="server"></asp:Label>
                                                <asp:GridView ID="GvPartyStockDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvPartyStockDetails_PageIndexChanging" OnRowCommand="GvPartyStockDetails_RowCommand"
                                                    PageSize="10" ShowFooter="true">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Sr.No.">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex + 1 %>

                                                                <asp:HiddenField ID="HfAccountCodeGrid" runat="server" Value='<%#Bind("ACODE")%>' />
                                                                <asp:HiddenField ID="HfStockCodeGrid" runat="server" Value='<%#Bind("SCODE")%>' />

                                                                <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                                                <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CATEGORY NAME">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdleftalign" ID="lblCategoryName" runat="server" Text='<%#Bind("CategoryName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT CODE">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label" ID="lblProductCode" runat="server" Text='<%#Bind("ProductCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT NAME">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdleftalign" ID="lblProductName" runat="server" Text='<%#Bind("ProductName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RATE">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdrightalign" ID="lblRate" runat="server" Text='<%#Bind("RATE") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <%--   </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                        </div>
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


        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="DivView" runat="server" class="grids">


        <div class="panel panel-widget top-grids">
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />

            <div style="float: right;">
                <asp:Label CssClass="label" Style="color: red;" Text="Search By Account Name/Product Name/Product Code/CategoryName" runat="server"></asp:Label><br />
                <asp:TextBox ID="TxtSearch" runat="server" Style="width: 100%;" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
        </div>

        <div style="clear: both; height: 10px"></div>

        <asp:HiddenField ID="HfCompCode" runat="server" />
        <%-- <asp:HiddenField ID="HfAccountcode" runat="server" />
        <asp:HiddenField ID="HfStockCode" runat="server" />--%>

        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="table-responsive">
                    <asp:GridView ID="GvPartyStockMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvPartyStockMaster_PageIndexChanging" OnRowCommand="GvPartyStockMaster_RowCommand"
                        PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                            <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <%--  <asp:HiddenField ID="HfCompCode" runat="server" Value='<%#Bind("COMP_CODE")%>' />--%>
                                    <asp:HiddenField ID="HfAccountCodeGrid" runat="server" Value='<%#Bind("ACODE")%>' />
                                    <%-- <asp:HiddenField ID="HfStockCodeGrid" runat="server" Value='<%#Bind("SCODE")%>' />--%>

                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="NAME OF ACCOUNT">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblAccountName" runat="server" Text='<%#Bind("AccountName") %>'></asp:Label>
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
                                    </ItemTemplate>
                                </asp:TemplateField>

                            <%--    <asp:TemplateField HeaderText="CATEGORY NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblCategoryName" runat="server" Text='<%#Bind("CategoryName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PRODUCT CODE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblProductCode" runat="server" Text='<%#Bind("ProductCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PRODUCT NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblProductName" runat="server" Text='<%#Bind("ProductName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="RATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign" ID="lblRate" runat="server" Text='<%#Bind("RATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>


    <script src="js/proton.js"></script>

    <div class="modal fade" tabindex="-1" id="CmpDeleteSelection" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">DELETE PARTY STOCK MASTER DETAIL</h4>
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

                    <h4 class="modal-title">UPDATE PARTY STOCK MASTER DETAIL</h4>
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
