<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="DailyWorkTimeCard.aspx.cs" Inherits="VeeraApp.DailyWorkTimeCard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" lang="javascript">
        function StartTime() {
            var StartTime = document.getElementsByName("ctl00$ContentPlaceHolder1$GvDailyWorkDetails$ctl02$TxtFromTime")["0"].value;
            var EndTime = document.getElementsByName("ctl00$ContentPlaceHolder1$GvDailyWorkDetails$ctl02$TxtToTime")["0"].value;
            if (StartTime < EndTime) {
                alert("End time should be greater than Start Time.");
            }
            //else {
            //    alert("Start time is greater than End Time.");
            //}
        }

        function EndTime() {
            var StartTime = document.getElementsByName("ctl00$ContentPlaceHolder1$GvDailyWorkDetails$ctl02$TxtFromTime")["0"].value;
            var EndTime = document.getElementsByName("ctl00$ContentPlaceHolder1$GvDailyWorkDetails$ctl02$TxtToTime")["0"].value;
            if (StartTime < EndTime) {
                //alert("Correct Time");
            }
            else
            {
                alert("Start time should be Less than End Time.");
            }
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
                    <h4>DAILY WORK TIME CARD</h4>
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

                                    <div class="h5" style="color: brown">Daily Work Time Card</div>

                                    <div style="float: left; height: auto; width: 40%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtWorkDate" AutoPostBack="true" OnTextChanged="TxtWorkDate_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtValidityDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                          ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtWorkDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderWorkDate" Format="dd-MM-yyyy" TargetControlID="TxtWorkDate"></ajax:CalendarExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Sr.No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtSrNo" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server"
                                                            ControlToValidate="TxtSrNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Employee Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:HiddenField ID="HfEmployeeCode" runat="server" />
                                                        <asp:TextBox ID="TxtEmployeeName" OnTextChanged="TxtEmployeeName_TextChanged" ForeColor="Blue" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                       <ajax:AutoCompleteExtender ID="AutoCompleteExtenderWorkDescription" runat="server" TargetControlID="TxtEmployeeName"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetEmployeeName">
                                                                </ajax:AutoCompleteExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Job Category" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlJobCategory" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE </asp:ListItem>
                                                            <asp:ListItem Value="O">OFFICE</asp:ListItem>
                                                            <asp:ListItem Value="M">MARKETING</asp:ListItem>
                                                            <asp:ListItem Value="T">TECHNICIAN</asp:ListItem>
                                                            <asp:ListItem Value="G">GENERAL</asp:ListItem>
                                                             <asp:ListItem Value="A">ALL</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldDdlCompanyType" runat="server"
                                                            InitialValue="0" ControlToValidate="DdlJobCategory" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Prepared By" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlPreparedBy" runat="server" ForeColor="Blue" CssClass="form-control">
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator9" runat="server" InitialValue="0"
                                                            ControlToValidate="DdlPreparedBy" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Work List Master" runat="server"></asp:Label>
                                                    </td>

                                                    <td colspan="3" style="padding-left: 10px;">

                                                        <asp:Button runat="server" ID="BtnWorkListMaster" OnClick="BtnWorkListMaster_Click" OnClientClick="aspnetForm.target ='_blank';" Text="+" CausesValidation="false" />

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
                                                        <asp:Label CssClass="label" Text="Confirm ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlConfirm" OnSelectedIndexChanged="DdlConfirm_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
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

                                                        <%--       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderConfirmDate" Format="dd-MM-yyyy" TargetControlID="TxtConfirmDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Checked ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlChecked" OnSelectedIndexChanged="DdlChecked_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Checked Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtCheckedDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtConfirmDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                      ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <%--       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtCheckedDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Checked By" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtCheckedBy" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>

                                        </div>
                                    </div>

                                    <div style="float: left; height: auto; width: 25%;">
                                        <asp:Button runat="server" ID="btnviewreport" OnClick="btnviewreport_Click" Text="View-Report"   OnClientClick="aspnetForm.target ='_blank';"/>
                                    </div>

                                    <div style="clear: both; height: 10px;">
                                    </div>

                                    <div class="panel panel-widget top-grids">
                                        <div class="chute chute-center text-center">

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: brown">WORK LIST DETAILS</div>
                                                <asp:GridView ID="GvDailyWorkDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="false" ShowFooter="true"
                                                    PageSize="10">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>


                                                        <asp:TemplateField HeaderText="SR.NO.">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                <asp:HiddenField ID="HfWorkCode" runat="server" Value='<%#Bind("WORK_CODE") %>' />

                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="FROM TIME" ControlStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtFromTime" CssClass="form-control" runat="server" onchange='return StartTime();' AutoPostBack="true" Text='<%#Bind("FRTIME") %>'></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionTxtFromTime" Display="Dynamic" runat="server" ControlToValidate="TxtFromTime" ValidationExpression="^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"
                                                                    ErrorMessage="Valid Time HH:MM" ForeColor="Red" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="TO TIME" ControlStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtToTime" CssClass="form-control" runat="server" onchange='return EndTime();' AutoPostBack="true" Text='<%#Bind("TOTIME") %>'></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionTxtToTime" Display="Dynamic" runat="server" ControlToValidate="TxtToTime" ValidationExpression="^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"
                                                                    ErrorMessage="Valid Time HH:MM" ForeColor="Red" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="VISIT DESCRIPTION" ControlStyle-Width="350px">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtVisitDescription" CssClass="form-control" runat="server" Text='<%#Bind("VISIT_PLACE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="WORK DESCRIPTION" ControlStyle-Width="350px">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtWorkDescription" ForeColor="Blue" CssClass="form-control" OnTextChanged="TxtWorkDescription_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("WORK_DESC") %>'></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtenderWorkDescription" runat="server" TargetControlID="TxtWorkDescription"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetWorListName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="REMARK" ControlStyle-Width="350px">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtRemark" CssClass="form-control" runat="server" Text='<%#Bind("REMARK") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="BtnDeleteRowModelDC_DetailsGrid" runat="server" OnClick="BtnDeleteRowModelDC_DetailsGrid_Click" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                            </ItemTemplate>

                                                            <FooterTemplate>
                                                                <asp:Button ID="BtnAddRowModelDC_DetailsGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelDC_DetailsGrid_Click" CausesValidation="false" />
                                                            </FooterTemplate>
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
        <asp:HiddenField ID="HfBranchCode" runat="server" />
        <asp:HiddenField ID="HfTranNo" runat="server" />
        <asp:HiddenField ID="HfTranDate" runat="server" />

        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                 <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvDailyWorkCardMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvDailyWorkCardMaster_PageIndexChanging" OnRowCommand="GvDailyWorkCardMaster_RowCommand"
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

                            <asp:TemplateField HeaderText="SR NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblSrNo" runat="server" Text='<%#Bind("SRNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblDate" runat="server" Text='<%#Bind("TranDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="EMPLOYEE NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblEmployeeName" runat="server" Text='<%#Bind("EMP_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PREPARED BY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblPreparedBy" runat="server" Text='<%#Bind("BrokerName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CHECKED ?">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblCheckedFlag" runat="server" Text='<%#Bind("Checked_Flag") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CHECKED DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblCheckedDate" runat="server" Text='<%#Bind("CHK_DATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CHECKED BY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblCheckedBy" runat="server" Text='<%#Bind("CHK_USERID") %>'></asp:Label>
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

                    <h4 class="modal-title">DELETE DAILY WORK CARD MASTER DETAIL</h4>
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

                        <h4 class="modal-title">UPDATE DAILY WORK CARD MASTER DETAIL</h4>
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
