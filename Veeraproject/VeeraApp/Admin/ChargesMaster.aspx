<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="ChargesMaster.aspx.cs" Inherits="VeeraApp.ChargesMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="js/jquery.js"></script>
    <script src="https://code.jquery.com/jquery-1.9.1.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">

        function test() {
            //alert("HELLO");
            var gst = document.getElementsByName("ctl00$ContentPlaceHolder1$TxtGST")["0"].value;

            if (gst == 5) {
                document.getElementsByName("ctl00$ContentPlaceHolder1$TxtCGST").innerHTML = 2.5;
                document.getElementsByName("ctl00$ContentPlaceHolder1$TxtSGST").innerHTML = 2.5;
                document.getElementsByName("ctl00$ContentPlaceHolder1$TxtIGST").innerHTML = gst;
            }
            else if (gst == 12) {
                document.getElementsByName("ctl00$ContentPlaceHolder1$TxtCGST").innerHTML = 6;
                document.getElementsByName("ctl00$ContentPlaceHolder1$TxtSGST").innerHTML = 6;
                document.getElementsByName("ctl00$ContentPlaceHolder1$TxtIGST").innerHTML = gst;
            }
            else if (gst == 18) {
                document.getElementsByName("ctl00$ContentPlaceHolder1$TxtCGST").value = 9;
                //document.getElementById("ctl00$ContentPlaceHolder1$TxtSGST")[0].value = 9;
                $("TxtSGST").val("Dolly Duck");
                document.getElementsByName("ctl00$ContentPlaceHolder1$TxtIGST").value = gst;
            }
            else if (gst == 28) {
                document.getElementsByName("ctl00$ContentPlaceHolder1$TxtCGST").innerHTML = 14;
                document.getElementsByName("ctl00$ContentPlaceHolder1$TxtSGST").innerHTML = 14;
                document.getElementsByName("ctl00$ContentPlaceHolder1$TxtIGST").innerHTML = gst;
            }
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
                    <h4>CHARGES DETAILS</h4>
                </div>
            </div>
        </div>
    </div>

    <%--<div style="clear: both; height: 10px">
    </div>--%>

    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">

                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">

                            <div class="col-md-12">
                                <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Name of the Charges" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtChargesName" CssClass="form-control" runat="server"></asp:TextBox>

                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtChargesName" runat="server"
                                        ControlToValidate="TxtChargesName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="HSN Code" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtHSNCode" CssClass="form-control" runat="server"></asp:TextBox>

                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtHSNCode" runat="server"
                                        ControlToValidate="TxtHSNCode" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <%--   <asp:RegularExpressionValidator ID="YourRegularExpressionValidator" runat="server" 
                                                                      ControlToValidate="TxtHSNCode" 
                                                      ForeColor="Red"  ErrorMessage="Your must enter exactly 6 digits."  
                                                                       ValidationExpression="^\d{6}$">
                                        </asp:RegularExpressionValidator>  --%>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="RATE" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtRate" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="Sign(+/-)" runat="server"></asp:Label>
                                    <%--    <asp:TextBox ID="TxtSign" CssClass="form-control" runat="server"></asp:TextBox>  --%>
                                    <asp:DropDownList ID="DdlSign" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                        <asp:ListItem Value="+">+</asp:ListItem>
                                        <asp:ListItem Value="-">-</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" InitialValue="0"
                                        ControlToValidate="DdlSign" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Name of Accounts" ForeColor="Blue" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlAccountName" runat="server" ForeColor="Blue" CssClass="form-control" OnSelectedIndexChanged="DdlAccountName_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredDdlAccountName" runat="server" InitialValue="0"
                                        ControlToValidate="DdlAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div style="clear: both; height: 10px;">
                            </div>
                            <asp:UpdatePanel ID="upd" runat="server">
                                <ContentTemplate>


                                    <div class="col-md-12">

                                        <%--<div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Name of Charges" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlChanrgesName" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                     </div>--%>
                                        <div class="col-md-3">
                                            <asp:Label CssClass="label" Text="GST %" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtGST" OnTextChanged="TxtGST_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Label CssClass="label" Text="CGST %" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtCGST" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Label CssClass="label" Text="SGST %" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtSGST" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Label CssClass="label" Text="IGST %" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtIGST" CssClass="form-control" runat="server"></asp:TextBox>
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
        </div>
        <asp:HiddenField ID="HfChargesCode" runat="server" />
        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfYearDate1" runat="server" />



        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

              <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvChargestMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvChargestMaster_PageIndexChanging" OnRowCommand="GvChargestMaster_RowCommand"
                        PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                            <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("CCODE") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <asp:HiddenField ID="HfChargesCode" runat="server" Value='<%#Bind("CCODE")%>' />

                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("CCODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("CCODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="NAME OF THE CHARGES">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblNameOfCharge" runat="server" Text='<%#Bind("NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HSN CODE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign" ID="lblHsnCode" runat="server" Text='<%#Bind("HSN_NO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign" ID="lblRate" runat="server" Text='<%#Bind("PER") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SIGN(+/-)">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdcenteralign" ID="lblSign" runat="server" Text='<%#Bind("SIGN") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NAME OF ACCOUNT">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblAccount" runat="server" Text='<%#Bind("AccountName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
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

                    <h4 class="modal-title">DELETE CHARGES DETAILS</h4>
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

                    <h4 class="modal-title">UPDATE CHARGES DETAILS</h4>
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
