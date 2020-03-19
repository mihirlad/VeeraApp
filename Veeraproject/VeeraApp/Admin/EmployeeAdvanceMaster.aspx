<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeAdvanceMaster.aspx.cs" Inherits="VeeraApp.Admin.LoanAdvanceMaster" %>

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
                    <h4 id="HdForLoanMaster" runat="server">EMPLOYEE LOAN MASTER</h4>
                    <h4 id="HdForAdvanceMaster" runat="server">EMPLOYEE ADVANCE MASTER</h4>
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

                            <asp:UpdatePanel ID="UpdPnl" runat="server">
                                <ContentTemplate>


                                    <div class="h5" style="color: brown">BASIC DETAILS</div>
                                    <div class="auto-style1">
                                        <div class="col-md-12">

                                            <div class="col-md-1">
                                                <asp:Label CssClass="label" Text="Advance Date" runat="server"></asp:Label>
                                                <asp:TextBox ID="TxtLoanDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="TxtLoanDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                <ajax:CalendarExtender runat="server" ID="CalendarExtenderJobCardDate" Format="dd-MM-yyyy" TargetControlID="TxtLoanDate"></ajax:CalendarExtender>
                                            </div>

                                            <div class="col-md-2">

                                                <asp:HiddenField ID="HfEmployeeCode" runat="server" />

                                                <asp:Label CssClass="label" Text="Employee Name" ForeColor="Blue" runat="server"></asp:Label>
                                                <asp:TextBox ID="TxtEmployeeName" CssClass="form-control" OnTextChanged="TxtEmployeeName_TextChanged" AutoPostBack="true" ForeColor="Blue" runat="server"></asp:TextBox>

                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtEmployeeName"
                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                    ServiceMethod="GetEmployeeName">
                                                </ajax:AutoCompleteExtender>
                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredAccountName" runat="server"
                                                    ControlToValidate="TxtEmployeeName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            </div>

                                          <%--  <div class="col-md-1">
                                                <asp:Label CssClass="label" Text="Install Month" runat="server"></asp:Label>
                                                <asp:TextBox ID="TxtInstallMonth" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>--%>

                                            <div class="col-md-1">
                                                <asp:Label CssClass="label" Text="Paid From Date" runat="server"></asp:Label>
                                                <asp:TextBox ID="TxtPaidFromDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="TxtPaidFromDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtPaidFromDate"></ajax:CalendarExtender>
                                            </div>


                                            <div class="col-md-1">
                                                <asp:Label CssClass="label" Text="Paid To Date" runat="server"></asp:Label>
                                                <asp:TextBox ID="TxtPaidToDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server"
                                                    ControlToValidate="TxtPaidToDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                <ajax:CalendarExtender runat="server" ID="CalendarExtender2" Format="dd-MM-yyyy" TargetControlID="TxtPaidToDate"></ajax:CalendarExtender>
                                            </div>


                                            <div class="col-md-1">
                                                <asp:Label CssClass="label" Text="Advance Amount" runat="server"></asp:Label>
                                                <asp:TextBox ID="TxtLoanAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>


                                           <%-- <div class="col-md-1">
                                                <asp:Label CssClass="label" Text="Install Amount" runat="server"></asp:Label>
                                                <asp:TextBox ID="TxtInstallAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>--%>

                                            <div class="col-md-1">
                                                <asp:Label CssClass="label" Text="Paid Amount" runat="server"></asp:Label>
                                                <asp:TextBox ID="TxtPaidAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="col-md-3">
                                                <asp:Label CssClass="label" Text="Remark" runat="server"></asp:Label>
                                                <asp:TextBox ID="TxtRemark" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    
                                </ContentTemplate>
                             </asp:UpdatePanel>


                                    <div style="clear: both; height: 20px;">
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
        <asp:HiddenField ID="HfBranchCode" runat="server" />
        <asp:HiddenField ID="HfTranNo" runat="server" />
        <asp:HiddenField ID="HfTranDate" runat="server" />
        <asp:HiddenField ID="HfLoanType" runat="server" />



        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                   
                    <asp:GridView ID="GvLoanAdvanceMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" ShowFooter="true" OnPageIndexChanging="GvLoanAdvanceMaster_PageIndexChanging" OnRowCommand="GvLoanAdvanceMaster_RowCommand"
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

                            <asp:TemplateField HeaderText="ADVANCE DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdcenteralign" ID="lblLoanDate" runat="server" Text='<%#Bind("LOAN_DATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="EMPLOYEE NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblEmployeeName" runat="server" Text='<%#Bind("EMP_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

<%--                            <asp:TemplateField HeaderText="INSTALL MONTH">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdcenteralign" ID="lblInstallMonth" runat="server" Text='<%#Bind("INSTALL_MONTHS") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                            <asp:TemplateField HeaderText="PAID FROM DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdcenteralign" ID="lblPaidFromDate" runat="server" Text='<%#Bind("FRDT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                               <asp:TemplateField HeaderText="PAID TO DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdcenteralign" ID="lblPaidToDate" runat="server" Text='<%#Bind("TODT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                               <asp:TemplateField HeaderText="ADVANCE AMT.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign" ID="lblLoanAmount" runat="server" Text='<%#Bind("LOAN_AMT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <%--   <asp:TemplateField HeaderText="INSTALL AMT.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign" ID="lblInstallAmount" runat="server" Text='<%#Bind("INSTALL_AMT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                              <asp:TemplateField HeaderText="PAID AMT.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign" ID="lblPaidAmount" runat="server" Text='<%#Bind("PAID_AMT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                              <asp:TemplateField HeaderText="REMARK">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblRemark" runat="server" Text='<%#Bind("REMARK") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="STATUS">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdcenteralign" ID="lblStatus" runat="server" Text='<%#Bind("STATUS") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


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

                    <h4 class="modal-title">DELETE LOAN/ADVANCE DETAIL</h4>
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

                        <h4 class="modal-title">UPDATE LOAN/ADVANCE DETAIL</h4>
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
