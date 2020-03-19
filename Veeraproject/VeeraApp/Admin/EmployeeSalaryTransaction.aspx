<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeSalaryTransaction.aspx.cs" Inherits="VeeraApp.Admin.EmployeeSalaryTransaction" %>

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
                    <h4>EMPLOYEE SALARY TRANSACTION</h4>
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
                            <div class="h5" style="color: brown">SALARY TRANSACTION MASTER</div>

                            <asp:UpdatePanel ID="updpnl" runat="server">
                                <ContentTemplate>


                                    <div style="float: left; height: auto; width: 35%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Salary Date" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtSalaryDate" OnTextChanged="TxtSalaryDate_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtSalaryDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderJobCardDate" Format="dd-MM-yyyy" TargetControlID="TxtSalaryDate"></ajax:CalendarExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Working Hours" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtWorkingHours" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Salary Month" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtSalaryMonth" OnTextChanged="TxtSalaryMonth_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                            ControlToValidate="TxtSalaryMonth" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="MM-yyyy" TargetControlID="TxtSalaryMonth"></ajax:CalendarExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="OT Hours" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtOTHours" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Working Days" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtWorkingDays" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="OT Rate" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtOTRate" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Remark" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="4">
                                                        <asp:TextBox ID="TxtRemark" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Branch Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="4">
                                                        <asp:TextBox ID="TxtBranchName" CssClass="form-control" ForeColor="Blue" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>



                                            </table>
                                        </div>
                                    </div>


                                    <div style="float: left; height: auto; width: 35%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Allow.Hours" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtAllowHours" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Allow.Rate" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtAllowRate" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="PF Rate" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtPFRate" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="FPF Rate" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtFPFRate" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="ESIC Rate (Emp.)" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtESICRateEmp" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="ESIC Rate (Comp.)" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtESICRateComp" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Confirm ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlConfirmFlag" OnSelectedIndexChanged="DdlConfirmFlag_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Confirm Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConfirmDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtConfirmDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                      ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <%--       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderConfirmDate" Format="dd-MM-yyyy" TargetControlID="TxtConfirmDate"></ajax:CalendarExtender>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Confirm By" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="4">
                                                        <asp:TextBox ID="TxtConfirmBy" CssClass="form-control" runat="server"></asp:TextBox>
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
                                                        <asp:Label CssClass="label" Text="Approval ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlApprovalFlag" OnSelectedIndexChanged="DdlApprovalFlag_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Approval Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtApprovalDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtConfirmDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                      ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <%--       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender2" Format="dd-MM-yyyy" TargetControlID="TxtApprovalDate"></ajax:CalendarExtender>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Approval By" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="4">
                                                        <asp:TextBox ID="TxtApprovalBy" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;"></td>

                                                    <td style="padding-left: 15px;" colspan="4">
                                                        <asp:Button ID="BtnProcessEmployeeDetails" runat="server" OnClick="BtnProcessEmployeeDetails_Click" Text="Employee Process" Width="185px" Height="33px"
                                                            CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
                                    </div>


                                    <div style="clear: both; height: 10px;">
                                    </div>

                                    <%--  <div class="container">
                                        <div class="col-md-12">--%>
                                    <div class="panel panel-widget top-grids">
                                        <div class="chute chute-center text-center">

                                            <div class="table-responsive" style="height: 300px; overflow-y: scroll;" id="DivStockGrid" runat="server">
                                                <div class="h5" style="color: brown">EMPLOYEE  DETAILS</div>

                                                <div class="h4">
                                                    <span style="float: left;">
                                                        <asp:Label CssClass="label" ID="lblEmployeeName" Font-Bold="true" Font-Size="Large" ForeColor="red" runat="server"></asp:Label>
                                                    </span>
                                                </div>

                                                <asp:GridView ID="GvEmployeeSalaryTransaction" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvEmployeeSalaryTransaction_PageIndexChanging" OnRowCommand="GvEmployeeSalaryTransaction_RowCommand"
                                                    PageSize="10">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnSelect" runat="server" CausesValidation="false" CommandName="Selecta" CommandArgument='<%#Bind("EMP_CODE") %>' ToolTip="Select" Text="SELECT" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Sr.No." HeaderStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfCompCodeGrid" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                                <asp:HiddenField ID="HfTranDateGrid" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfTranNoGrid" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfEmployeeCodeGrid" runat="server" Value='<%#Bind("EMP_CODE") %>' />
                                                                <asp:HiddenField ID="HfBasicRate" runat="server" Value='<%#Bind("BASIC_RATE") %>' />


                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="REF.CODE">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtEmployeeRefCode" ReadOnly="true" runat="server" Text='<%#Bind("REF_EMPCODE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="EMPLOYEE NAME">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtEmployeeName" ReadOnly="true" runat="server" Text='<%#Bind("EMP_NAME") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="DESIGNATION">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtEmployeeDesignation" ReadOnly="true" runat="server" Text='<%#Bind("EMP_DESIGN") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SALARY FLAG">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtEmployeeSalaryFlag" ReadOnly="true" runat="server" Text='<%#Bind("SAL_FLAG") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PF">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="DdlPFFlag" Text='<%#Bind("PF_FLAG") %>' AutoPostBack="true" runat="server">
                                                                    <asp:ListItem Value="Y">YES</asp:ListItem>
                                                                    <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="ESIC">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="DdlESICFlag" Text='<%#Bind("ESIC_FLAG") %>' AutoPostBack="true" runat="server">
                                                                    <asp:ListItem Value="Y">YES</asp:ListItem>
                                                                    <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="OT">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="DdlOTFlag" Text='<%#Bind("OT_FLAG") %>' AutoPostBack="true" runat="server">
                                                                    <asp:ListItem Value="Y">YES</asp:ListItem>
                                                                    <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                    </Columns>
                                                </asp:GridView>
                                            </div>



                                        </div>
                                    </div>
                                    <%--   </div>
                                </div>--%>




                                    <div style="clear: both; height: 10px;">
                                    </div>



                                    <div style="float: left; height: auto; width: 15%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">

                                                <center>   <div class="h5" style="color: brown">-----DAY/HOURS-----</div> </center>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Present Days" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtPresentDays" CssClass="form-control" runat="server" OnTextChanged="TxtPresentDays_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Total Hours" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtTotalHours" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="OT Hours" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtTotalOTHours" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="OD Hours" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtODHours" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>



                                            </table>
                                        </div>
                                    </div>



                                    <div style="float: left; height: auto; width: 35%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">

                                                <center>   <div class="h5" style="color: brown">-----EARNINGS-----</div> </center>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Basic Rate" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtBasicRate" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Basic Amt." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtBasicAmt" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Conv. Rate" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConvRate" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Conv. Amt." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConvAmt" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;"></td>

                                                    <td style="padding-left: 10px;"></td>

                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="OT Amt." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtOTAmt" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;"></td>

                                                    <td style="padding-left: 10px;"></td>

                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="OD Amt." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtODAmt" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Medical Rate" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtMedicalRate" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Medical Amt." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtMedicalAmt" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="HRA Rate" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtHRARate" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="HRA Amt." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtHRAAmt" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;"></td>

                                                    <td style="padding-left: 10px;"></td>

                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Allowance Amt." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtAllowanceAmt" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;"></td>

                                                    <td style="padding-left: 10px;"></td>

                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Total Amt." ForeColor="Red" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtTotalGrossAmt" ForeColor="Red" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                            </table>
                                        </div>
                                    </div>


                                    <div style="float: left; height: auto; width: 25%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">

                                                <center>   <div class="h5" style="color: brown">-----DEDUCTION-----</div> </center>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Loan Amt." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtLoanAmt" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:CheckBox ID="ChkLoanAmount" OnCheckedChanged="ChkLoanAmount_CheckedChanged" AutoPostBack="true" runat="server" />
                                                    </td>

                                                </tr>


                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Advance Amt." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtAdvanceAmt" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:CheckBox ID="ChkAdvanceAmount" OnCheckedChanged="ChkAdvanceAmount_CheckedChanged" AutoPostBack="true" runat="server" />
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="PF Amt." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtPFAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="FPF Amt." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtFPFAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="ESIC Amt.(Emp)" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtESICAmountEmployee" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="ESIC Amt.(Comp)" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtESICAmountCompany" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="IT Amt." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtITAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Total Amt." ForeColor="Red" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtTotalLessAmount" ForeColor="Red" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
                                    </div>


                                    <div style="float: left; height: auto; width: 20%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">

                                                <center>   <div class="h5" style="color: brown">-----TOTAL-----</div> </center>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Net Salary Amt." ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtNetSalaryAmount" ForeColor="Blue" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 5px;">
                                                        <asp:Label CssClass="label" Text="Pay Salary Amt." ForeColor="Red" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtPaySalaryAmount" ForeColor="red" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                            </table>
                                        </div>
                                    </div>

                                </ContentTemplate>
                                <%--  <Triggers>
                                    <asp:PostBackTrigger ControlID="GvEmployeeSalaryTransaction" />
                                </Triggers>--%>
                            </asp:UpdatePanel>

                        </div>
                    </div>

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


    <div id="DivView" runat="server" class="grids">

        <div class="panel panel-widget top-grids">
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />
        </div>

        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBranchCode" runat="server" />
        <asp:HiddenField ID="HfTranNo" runat="server" />
        <asp:HiddenField ID="HfTranDate" runat="server" />
        <asp:HiddenField ID="HfEmployeeCode" runat="server" />




        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                    <div class="table-responsive">
                        <asp:GridView ID="GvEmployeeSalaryMaster" CssClass="table table-vcenter table-condensed table-bordered"
                            runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvEmployeeSalaryMaster_PageIndexChanging" OnRowCommand="GvEmployeeSalaryMaster_RowCommand"
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


                                <asp:TemplateField HeaderText="SALARY MONTH">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign" ID="lblSalaryMonth" runat="server" Text='<%#Bind("SAL_MONTH") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="SALARY DATE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign" ID="lblSalaryDate" runat="server" Text='<%#Bind("SAL_DATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="WORKING DAYS">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign" ID="lblWorkingDays" runat="server" Text='<%#Bind("WRK_DAYS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="WORKING HOURS">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign" ID="lblWorkingHours" runat="server" Text='<%#Bind("WRK_HOURS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="OT HOURS">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign" ID="lblOTHours" runat="server" Text='<%#Bind("OT_HOURS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="OT RATE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign" ID="lblOTRate" runat="server" Text='<%#Bind("OT_RATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ALLOW HOURS">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign" ID="lblAllowHours" runat="server" Text='<%#Bind("ALLOW_HOURS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ALLOW RATE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign" ID="lblAllowRate" runat="server" Text='<%#Bind("ALLOW_RATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="PF RATE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign" ID="lblPFRate" runat="server" Text='<%#Bind("PF_RATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="FPF RATE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign" ID="lblFPFRate" runat="server" Text='<%#Bind("FPF_RATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ESIC RATE (Emp.)">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign" ID="lblSICEmployeeRate" runat="server" Text='<%#Bind("ESIC_RATE_EMP") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ESIC RATE (Comp.)">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign" ID="lblESICCompanyRate" runat="server" Text='<%#Bind("ESIC_RATE_COMP") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="CONFIRM ?">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign" ID="lblConfirmFlag" runat="server" Text='<%#Bind("CONF_FLAG") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="APPROVAL ?">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign" ID="lblApprovalFlag" runat="server" Text='<%#Bind("CHK_FLAG") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="REMARK ">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign" ID="lblRemark" runat="server" Text='<%#Bind("REMARK") %>'></asp:Label>
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

                    <h4 class="modal-title">DELETE SALARY TRANSACTION DETAIL</h4>
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

                        <h4 class="modal-title">UPDATE SALARY TRANSACTION DETAIL</h4>
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



    <div class="modal fade" tabindex="-1" id="CmpLonaSetoffTransaction" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title" style="color: red">LOAN/ADVANCE DETAILS</h4>
                </div>
                <div class="modal-body">

                    <div id="Div1" runat="server" class="grids">

                        <div class="panel panel-widget top-grids">


                            <div class="h5" style="color: brown; text-align: left">Loan Details</div>

                            <asp:UpdatePanel ID="UpModalAddChallan" runat="server">
                                <ContentTemplate>

                                    <asp:GridView ID="GvLoanSetOffTransaction" CssClass="table table-vcenter table-condensed table-bordered" OnRowDataBound="GvLoanSetOffTransaction_RowDataBound"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                        PageSize="10" ShowFooter="true">
                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="Sr.No.">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HfLoanCompCode" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                    <asp:HiddenField ID="HfLoanRefTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                    <asp:HiddenField ID="HfLoanRefTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                    <asp:HiddenField ID="HfLoanRefType" runat="server" Value='<%#Bind("LOAN_TYPE") %>' />
                                                    <asp:HiddenField ID="HfLoanEMP_CODE" runat="server" Value='<%#Bind("EMP_CODE") %>' />


                                                    <%#Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="LOAN DATE">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label grdcenteralign" ID="lblLoanDate" runat="server" Text='<%#Bind("LOAN_DATE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="LOAN AMT.">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label grdcenteralign" ID="lblLoanAmt" runat="server" Text='<%#Bind("LOAN_AMT") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblSumTotalLoanAmount" ForeColor="Red" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="INSTALL AMT.">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label grdcenteralign" ID="lblInstallAmt" runat="server" Text='<%#Bind("INSTALL_AMT") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="TOTAL PAID AMT.">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label grdcenteralign" ID="lblTotalPaidAmt" runat="server" Text='<%#Bind("PAID_AMT") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblSumTotalPaidAmount" ForeColor="Red" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="O/S AMT.">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label grdcenteralign" ID="lblOSAmt" runat="server" Text='<%#Bind("OutStanding_Amount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblSumTotalOutStandingAmount" ForeColor="Red" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PAID AMT.">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="TxtPaidAmt" OnTextChanged="TxtPaidAmt_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                                 <FooterTemplate>
                                                    <asp:Label ID="lblSumTotalCurrentPaidAmount" ForeColor="Red" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>



                                        </Columns>
                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                    </asp:GridView>


                                </ContentTemplate>
                                <%-- <Triggers>
                                    <asp:PostBackTrigger ControlID="GvAddQuotationDetails" />
                                </Triggers>--%>
                            </asp:UpdatePanel>
                            <center> <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK </button> </center>
                            <%--   <asp:Button ID="btnAddQuotationProcess" runat="server" Text="Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnAddQuotationProcess_Click" CausesValidation="false" />--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function HideModelLoanAdvance() {

            $("#CmpLonaSetoffTransaction").modal('hide');
        }

        function ShowModelLoanAdvance() {

            $("#CmpLonaSetoffTransaction").modal('show');

        }
        function SelectionAlert() {

            alert("Must be select Employee Name !");

        }
    </script>


</asp:Content>
