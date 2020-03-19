<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="StockPriceMaster.aspx.cs" Inherits="VeeraApp.PriceMaster" %>

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
                    <h4>STOCK PRICE MASTER</h4>
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

                            <asp:HiddenField ID="HfSrNo" runat="server" />
                            <div class="h5" style="color: brown">STOCK PRICE MASTER</div>

                            <asp:UpdatePanel ID="updpnl" runat="server">
                                <ContentTemplate>




                                    <div class="col-md-12">
                                        <%-- <div class="col-md-1">
                                  <asp:Label CssClass="label" Text="Sr No." runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtSrNo" CssClass="form-control" runat="server"></asp:TextBox>
                               </div>
                                        --%>

                                        <div class="col-md-1">
                                            <asp:Label CssClass="label" Text="From Date" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtFromDate" Style="text-align: center;" CssClass="form-control" runat="server" OnTextChanged="TxtFromDate_TextChange" AutoPostBack="true"></asp:TextBox>

                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtFromDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                ErrorMessage="INVALID DATE" ForeColor="Red"></asp:RegularExpressionValidator>

                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server"
                                                ControlToValidate="TxtFromDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <ajax:CalendarExtender runat="server" ID="CalendarID1" Format="dd-MM-yyyy" TargetControlID="TxtFromDate"></ajax:CalendarExtender>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:Label CssClass="label" Text="To Date" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtToDate" Style="text-align: center;" CssClass="form-control" runat="server" OnTextChanged="TxtToDate_TextChange" AutoPostBack="true"></asp:TextBox>

                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ControlToValidate="TxtToDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                ErrorMessage="INVALID DATE" ForeColor="Red"></asp:RegularExpressionValidator>

                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                ControlToValidate="TxtToDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtToDate"></ajax:CalendarExtender>
                                        </div>

                                        <div class="col-md-4">
                                            <asp:Label CssClass="label" Text="Remark" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtRemark" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="col-md-1">
                                            <asp:Label CssClass="label" Text="Active" runat="server"></asp:Label>
                                            <asp:DropDownList ID="DdlActive" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="Y">ACTICE</asp:ListItem>
                                                <asp:ListItem Value="N">INACTIVE</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>


                                    <div style="clear: both; height: 10px;">
                                    </div>





                                    <div class="panel panel-widget top-grids">
                                        <div class="chute chute-center text-center">

                                            <div class="table-responsive" style="height: 450px; overflow-y: scroll;" id="DivStockGrid" runat="server">
                                                <div class="h5" style="color: brown">STOCK PRICE DETAILS</div>
                                                <asp:GridView ID="GvStockPriceDet" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvStockPriceDet_PageIndexChanging"
                                                    PageSize="10">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="CATEGORY NAME">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfStockCode" runat="server" Value='<%#Bind("SCODE") %>' />
                                                                <asp:Label CssClass="label grdleftalign" ID="lblCategoryName" runat="server" Text='<%#Bind("CategoryName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CODE">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdcenteralign" ID="lblProdCode" runat="server" Text='<%#Bind("PROD_CODE") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PART NO.">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdcenteralign" ID="lblPartNo" runat="server" Text='<%#Bind("PART_NO") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT NAME">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdleftalign" ID="lblProductName" runat="server" Text='<%#Bind("SNAME") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RATE">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtRate" runat="server" Text='<%#Bind("RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CUST.DIS.%">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtCustDis" runat="server" Text='<%#Bind("DIS_PER") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CUSTOMER DIS.RATE">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtCustDisRate" runat="server" Text='<%#Bind("DIS_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DEALER DIS.%">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtDealerDis" runat="server" Text='<%#Bind("DEL_PER") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DEALER RATE">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtDealerRate" runat="server" Text='<%#Bind("DEL_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="MAX DIS.%">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtMaxDis" runat="server" Text='<%#Bind("MAX_PER") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="MAXIMUM RATE">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtMaxRate" runat="server" Text='<%#Bind("MAX_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>


                                </ContentTemplate>
                            </asp:UpdatePanel>

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
        </div>
    </div>




    <div id="DivView" runat="server" class="grids">

        <div class="panel panel-widget top-grids">
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />
        </div>

        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfStockCode" runat="server" />

        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvStockPriceMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvStockPriceMaster_PageIndexChanging" OnRowCommand="GvStockPriceMaster_RowCommand"
                        OnRowDataBound="GvStockPriceMaster_RowDataBound"
                        PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                            <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("SRNO") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SRNO")%>' />

                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("SRNO") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("SRNO") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                    <a href="JavaScript:divexpandcollapse('div<%# Eval("SRNO") %>');">
                                        <img id='imgdiv<%# Eval("SRNO") %>' width="15px" border="0" src="/images/plus.gif" />
                                    </a>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SR NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblSrNo" runat="server" Text='<%#Bind("SRNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="FROM DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblFromDate" runat="server" Text='<%#Bind("FromDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="TO DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblToDate" runat="server" Text='<%#Bind("ToDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="REMARK">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblRemark" runat="server" Text='<%#Bind("REMARK") %>'></asp:Label>

                                    <tr>
                                        <td colspan="100%">
                                            <div id='div<%#Eval("SRNO") %>' class="table-responsive" style="display: none; background-color: lightgray">
                                                <div style="border: 1px solid red; background: #00bcd4; color: white; padding: 1px; border-radius: 7px;">
                                                    <h4>STOCK PRICE DETAILS</h4>
                                                </div>

                                                <asp:GridView ID="GvNestedPriceMasDetails" Style="background: #e6ffee;" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="CATEGORY NAME">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfStockCode" runat="server" Value='<%#Bind("SCODE") %>' />
                                                                <asp:Label CssClass="label grdleftalign" ID="lblCategoryName" runat="server" Text='<%#Bind("CategoryName") %>' Enabled="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CODE">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label" ID="lblProdCode" runat="server" Text='<%#Bind("PROD_CODE") %>' Enabled="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PART NO.">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label" ID="lblPartNo" runat="server" Text='<%#Bind("PART_NO") %>' Enabled="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT NAME">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdleftalign" ID="lblProductName" runat="server" Text='<%#Bind("SNAME") %>' Enabled="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RATE">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdrightalign" ID="TxtRate" runat="server" Text='<%#Bind("RATE") %>' Enabled="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CUST.DIS.%">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdrightalign" ID="TxtCustDis" runat="server" Text='<%#Bind("DIS_PER") %>' Enabled="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CUSTOMER DIS.RATE">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdrightalign" ID="TxtCustDisRate" runat="server" Text='<%#Bind("DIS_RATE") %>' Enabled="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DEALER DIS.%">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdrightalign" ID="TxtDealerDis" runat="server" Text='<%#Bind("DEL_PER") %>' Enabled="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DEALER RATE">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdrightalign" ID="TxtDealerRate" runat="server" Text='<%#Bind("DEL_RATE") %>' Enabled="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="MAX DIS.%">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdrightalign" ID="TxtMaxDis" runat="server" Text='<%#Bind("MAX_PER") %>' Enabled="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="MAXIMUM RATE">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdrightalign" ID="TxtMaxRate" runat="server" Text='<%#Bind("MAX_RATE") %>' Enabled="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    </div>
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

                    <h4 class="modal-title">DELETE STOCK PRICE MASTER DETAIL</h4>
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

                        <h4 class="modal-title">UPDATE STOCK PRICE MASTER DETAIL</h4>
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
