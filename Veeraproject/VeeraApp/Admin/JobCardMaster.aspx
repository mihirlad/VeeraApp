<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="JobCardMaster.aspx.cs" Inherits="VeeraApp.JobCardMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/model.css" rel="stylesheet" />
    <script type="text/javascript">
        function txtachange() {
            //  alert("jigar");
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
                    <h4>JOBCARD MASTER</h4>
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

                                 

                                    <div class="h5" style="color: brown">JobCard Master</div>

                                    <div style="float: left; height: auto; width: 35%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="JobCard No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtJobCardNo" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorTxtJobCardNo" runat="server"
                                                            ControlToValidate="TxtJobCardNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="JobCard Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtJobCardDate" OnTextChanged="TxtJobCardDate_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtValidityDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                          ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtJobCardDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderJobCardDate" Format="dd-MM-yyyy" TargetControlID="TxtJobCardDate"></ajax:CalendarExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="JobCard Time" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtJobCardTime" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                            ControlToValidate="TxtJobCardTime" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionTxtJobCardTime" Display="Dynamic" runat="server" ControlToValidate="TxtJobCardTime" ValidationExpression="^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"
                                                            ErrorMessage="Valid Time HH:MM" ForeColor="Red" />
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="P.O No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtPONumber" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="P.O Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtPODate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtValidityDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                                     ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <%-- <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server"
                                                            ControlToValidate="TxtPODate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderPODate" Format="dd-MM-yyyy" TargetControlID="TxtPODate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Party Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:HiddenField ID="HfACODE" runat="server" />
                                                        <asp:TextBox ID="TxtPartyName" OnTextChanged="TxtPartyName_TextChanged" AutoPostBack="true" CssClass="form-control" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtPartyName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server"
                                                            ControlToValidate="TxtPartyName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Conatct Person" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="5" style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlContactPerson" runat="server" OnSelectedIndexChanged="DdlContactPerson_SelectedIndexChanged" ForeColor="Blue" CssClass="form-control" AutoPostBack="true">
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidatorDdlContactPerson" runat="server"
                                                            ControlToValidate="DdlContactPerson" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:Button ID="BtnContactDetails" runat="server" OnClick="BtnContactDetails_Click" Text="Contact Details" Height="33px" Width="180px" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                        <asp:Button runat="server" ID="btnRefreshContactDetails" OnClick="btnRefreshContactDetails_Click" CausesValidation="false" CssClass="btn_Refresh" />

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Contact Phone" runat="server"></asp:Label>
                                                    </td>


                                                    <td colspan="5" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtContactPhone" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Contact Email" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:TextBox ID="TxtContactEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Complain Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtComplainDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtValidityDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                          ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server"
                                                            ControlToValidate="TxtComplainDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtComplainDate"></ajax:CalendarExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Complain Time" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtComplainTime" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RegularExpressionValidator ID="RegularExpressionTxtComplainTime" Display="Dynamic" runat="server" ControlToValidate="TxtComplainTime" ValidationExpression="^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"
                                                            ErrorMessage="Valid Time HH:MM" ForeColor="Red" />

                                                    </td>
                                                </tr>

                                                <tr>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Complain Person" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="5" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtComplainPerson" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Complain Phone" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="5" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtComplainPhone" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Customer Remarks" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="5" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtCustomerRemark" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
                                    </div>


                                    <div style="float: left; height: auto; width: 35%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">

                                                <tr>
                                                    <asp:HiddenField ID="HfPartRefSrNo" runat="server" />
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Party Model SrNo" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtPartyModelSrNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtPartyModelSrNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>

                                                    <td style="padding-left: 5px;">
                                                        <asp:Button ID="BtnGetPartyModelSrNo" OnClick="BtnGetPartyModelSrNo_Click" runat="server" Text="Get Model No" CausesValidation="false" />
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:Button ID="BtnPartyModelDetails" OnClick="BtnPartyModelDetails_Click" runat="server" Text="Model Details" Height="33px" Width="180px" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>
                                                    <td style="padding-left: 2px;">
                                                        <asp:Button runat="server" ID="BtnRefreshPartyModelSrNo" CausesValidation="false" CssClass="btn_Refresh" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Party Sr.No." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtPartySrNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Mfg Sr.No." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtMfgSrNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Brand Name" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtBrandName" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Brand Type Name" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:HiddenField ID="HfBrandTypeCode" runat="server" />
                                                        <asp:HiddenField ID="HfBrandTypeSrNo" runat="server" />
                                                        <asp:TextBox ID="TxtBrandTypeName" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Model Name" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtModelName" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Service Type" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:DropDownList ID="DdlServiceType" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                            <asp:ListItem Value="A">AMC</asp:ListItem>
                                                            <asp:ListItem Value="C">Call Charges</asp:ListItem>
                                                            <asp:ListItem Value="W">Under Warranty</asp:ListItem>
                                                        </asp:DropDownList>


                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredDdlServiceType" runat="server" InitialValue="0"
                                                            ControlToValidate="DdlServiceType" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>

                                                </tr>

                                                <tr>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="AMC No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">
                                                        <asp:TextBox ID="TxtAMCNo" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" runat="server"
                                                            ControlToValidate="TxtAMCNo" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:Button ID="BtnViewAMC" runat="server" OnClick="BtnViewAMC_Click" Text="View AMC" Height="33px" Width="120px" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>


                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="AMC From Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtAMCFromDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%-- <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" runat="server"
                                                            ControlToValidate="TxtAMCFromDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderTxtFromDate" Format="dd-MM-yyyy" TargetControlID="TxtAMCFromDate"></ajax:CalendarExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="AMC To Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtAMCToDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--<asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator8" runat="server"
                                                            ControlToValidate="TxtAMCToDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderTxtToDate" Format="dd-MM-yyyy" TargetControlID="TxtAMCToDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Job Assign Person" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="2">

                                                        <asp:HiddenField ID="HfJobAssignPersonName" runat="server" />
                                                        <asp:TextBox ID="TxtJobAssignPersonName" OnTextChanged="TxtJobAssignPersonName_TextChanged" CssClass="form-control" ForeColor="Blue" AutoPostBack="true" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtJobAssignPersonName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetServicePersonName">
                                                        </ajax:AutoCompleteExtender>

                                                        <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtJobAssignPersonName" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>


                                                    <td style="padding-left: 10px;" colspan="1">
                                                        <asp:Button ID="BtnViewAssignLog" runat="server" OnClick="BtnViewAssignLog_Click" Text="View" Height="33px" Width="100px" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Job Assign Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtJobAssignDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator9" runat="server"
                                                            ControlToValidate="TxtJobAssignDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderTxtJobAssignDate" Format="dd-MM-yyyy" TargetControlID="TxtJobAssignDate"></ajax:CalendarExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Job Assign Time" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtJobAssignTime" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RegularExpressionValidator ID="RegularExpressionTxtJobAssignTime" Display="Dynamic" runat="server" ControlToValidate="TxtJobAssignTime" ValidationExpression="^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"
                                                            ErrorMessage="Valid Time HH:MM" ForeColor="Red" />
                                                    </td>
                                                </tr>

                                                <tr>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Remark" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtRemark" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <%--   <tr>
                                                    <td>
                                                        <asp:Button ID="BtnViewRecord" runat="server" Text="View Record" Height="33px" Width="150px" OnClick="BtnViewRecord_Click" CausesValidation="false" CssClass="btn btn-success btn-sm" />
                                                    </td>
                                                    </tr>--%>
                                            </table>
                                        </div>
                                    </div>

                                    <div style="float: left; height: auto; width: 30%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">

                                                <tr>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Running Hours" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtRunningHours" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Loading Hours" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtLoadingHours" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Job Start Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtJobStartDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator11" runat="server"
                                                            ControlToValidate="TxtJobStartDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender2" Format="dd-MM-yyyy" TargetControlID="TxtJobStartDate"></ajax:CalendarExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Job Start Time" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtJobStartTime" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RegularExpressionValidator ID="RegularExpressionTxtJobStartTime" Display="Dynamic" runat="server" ControlToValidate="TxtJobStartTime" ValidationExpression="^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"
                                                            ErrorMessage="Valid Time HH:MM" ForeColor="Red" />
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Job Close Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtJobCloseDate" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator12" runat="server"
                                                            ControlToValidate="TxtJobCloseDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender3" Format="dd-MM-yyyy" TargetControlID="TxtJobCloseDate"></ajax:CalendarExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Job Close Time" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtJobCloseTime" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RegularExpressionValidator ID="RegularExpressionTxtJobCloseTime" Display="Dynamic" runat="server" ControlToValidate="TxtJobCloseTime" ValidationExpression="^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"
                                                            ErrorMessage="Valid Time HH:MM" ForeColor="Red" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Signature Person" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtSignaturePerson" CssClass="form-control" ForeColor="Blue" AutoPostBack="true" runat="server"></asp:TextBox>

                                                        <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldTxtSignaturePerson" runat="server"
                                                            ControlToValidate="TxtSignaturePerson" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Signature Phone" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtSignaturePhone" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Closed ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlClosed" OnSelectedIndexChanged="DdlClosed_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Next Service Date" ForeColor="Red" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtNextServiceDate" ForeColor="Red" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--<asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFielTxtNextServiceDate" runat="server"
                                                            ControlToValidate="TxtNextServiceDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender4" Format="dd-MM-yyyy" TargetControlID="TxtNextServiceDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Closed Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtClosedDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtConfirmDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                      ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <%--       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender5" Format="dd-MM-yyyy" TargetControlID="TxtClosedDate"></ajax:CalendarExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Closed By" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtClosedBy" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Last JobCard No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtLastJobCardNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Last JobCard Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtLastJobCardDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtConfirmDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                      ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <%--       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender6" Format="dd-MM-yyyy" TargetControlID="TxtLastJobCardDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Last Running Hours" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtLastRunningHours" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text=" Last Loading Hours" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtLastLoadingHours" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Cancel Description" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">

                                                        <asp:HiddenField ID="HfCancelCode" runat="server" />
                                                        <asp:TextBox ID="TxtCancelDescription" CssClass="form-control" ForeColor="Blue" OnTextChanged="TxtCancelDescription_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="TxtCancelDescription"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetCancelJobName">
                                                        </ajax:AutoCompleteExtender>

                                                        <%--                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator13" runat="server"
                                                            ControlToValidate="TxtCancelDescription" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>

                                                    <td style="padding-left: 10px;">

                                                        <asp:Button runat="server" ID="BtnJobCancelMaster" OnClick="BtnJobCancelMaster_Click" OnClientClick="aspnetForm.target ='_blank';" Text="+" CausesValidation="false" />

                                                    </td>

                                                </tr>
                                                <td align="right" style="padding-bottom: 10px;">
                                                    <asp:Label CssClass="label" Text="Cancel Remark" runat="server"></asp:Label>
                                                </td>
                                                <td style="padding-left: 10px;" colspan="4">
                                                    <asp:TextBox ID="TxtCancelRemark" CssClass="form-control" runat="server"></asp:TextBox>
                                                </td>
                                                <tr>
                                                </tr>

                                            </table>
                                        </div>
                                    </div>

                                    <div style="clear: both; height: 20px;">
                                    </div>


                                    <ajax:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="350px" Width="1600px" Font-Bold="true">

                                        <ajax:TabPanel runat="server" ID="TabPanel1" HeaderText="Complain Details">
                                            <%--  <HeaderTemplate>
                                               <div style="float: left;">
                                                    <img src="images/accept.png" />
                                                </div>
                                                <div style="text-align: center; padding-left: 15px; font-size: medium;">Complain Details</div>
                                            </HeaderTemplate>--%>
                                            <ContentTemplate>

                                                <div class="table-responsive" style="height: 272px; overflow-y: scroll">

                                                    <asp:GridView ID="GvJobCardComplain" CssClass="table table-vcenter table-condensed table-bordered" OnRowDataBound="GvJobCardComplain_RowDataBound"
                                                        runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                                        PageSize="10" ShowFooter="true">

                                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="SR.NO." HeaderStyle-Width="50px">
                                                                <ItemTemplate>

                                                                    <asp:HiddenField ID="HfCompCode" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                                    <asp:HiddenField ID="HfTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                    <asp:HiddenField ID="HfTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                    <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                    <asp:HiddenField ID="HfComplainCode" runat="server" Value='<%#Bind("COMPLAIN_CODE") %>' />



                                                                    <%#Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="COMPLAIN DESCRIPTION">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="TxtComplainDescription" OnTextChanged="TxtComplainDescription_TextChanged" ForeColor="Blue" CssClass="form-control" runat="server" AutoPostBack="true"></asp:TextBox>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtenderTxtComplainDescription" runat="server" TargetControlID="TxtComplainDescription"
                                                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                        ServiceMethod="GetComplainDesciption">
                                                                    </ajax:AutoCompleteExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="COMPLAIN CHECKING DETAILS">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdrightalign" Enabled="false" ID="TxtComplainCheckingDetails" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderStyle-Width="150px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="BtnDeleteRowJobCardComplainGrid" runat="server" OnClick="BtnDeleteRowJobCardComplainGrid_Click" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Button ID="BtnAddRowJobCardComplainGrid" runat="server" OnClick="BtnAddRowJobCardComplainGrid_Click" Text="Add New Row" CausesValidation="false" />

                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>

                                            </ContentTemplate>
                                        </ajax:TabPanel>

                                        <ajax:TabPanel ID="TabPanel2" runat="server" HeaderText="Service Deatils">
                                            <ContentTemplate>


                                                <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                    <%-- <div class="h5" style="color:brown">STOCK BRAND TYPE DETAILS</div>--%>

                                                    <asp:Button ID="BtnFetchServiceData" runat="server" Text="Fetch Service Data" OnClick="BtnFetchServiceData_Click" Height="33px" Width="180px" CausesValidation="false" CssClass="btn btn-danger btn-sm" />
                                                    <div style="clear: both; height: 10px;"></div>

                                                    <asp:GridView ID="GvServiceDetail" CssClass="table table-vcenter table-condensed table-bordered" ShowFooter="true" OnRowDataBound="GvServiceDetail_RowDataBound"
                                                        runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                                        PageSize="10">
                                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="SR.NO.">
                                                                <ItemTemplate>


                                                                    <%--  <asp:HiddenField ID="HfCompCode" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                                    <asp:HiddenField ID="HfTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                    <asp:HiddenField ID="HfTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                    <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SRNO") %>' />--%>

                                                                    <asp:HiddenField ID="HfBrandTypeCodeGrid" runat="server" Value='<%#Bind("BRANDTYPE_CODE") %>'></asp:HiddenField>
                                                                    <asp:HiddenField ID="HfBrandTypeSrNo" runat="server" Value='<%#Bind("BRANDTYPE_SRNO") %>'></asp:HiddenField>

                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="Work Decsription" HeaderStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblWorkDescrition" runat="server" Text='<%#Bind("DESC_NAME") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="OPTION-1" HeaderStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblRESULT_1_1" runat="server" Text='<%#Bind("RESULT_1_1") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Result" HeaderStyle-Width="50px">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="CheckBoxOption1" OnCheckedChanged="CheckBoxOption1_CheckedChanged" Checked='<%#Convert.ToBoolean(Eval("RESULT_FLAG_1_1")) %>' AutoPostBack="true" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="OPTION-2" HeaderStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblRESULT_1_2" runat="server" Text='<%#Bind("RESULT_1_2") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="Result" HeaderStyle-Width="50px">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="CheckBoxOption2" OnCheckedChanged="CheckBoxOption2_CheckedChanged" Checked='<%#Convert.ToBoolean(Eval("RESULT_FLAG_1_2")) %>' AutoPostBack="true" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="PRINT">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblPRINT_FLAG_1" runat="server" Text='<%#Bind("PRINT_FLAG_1") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="CHECKING-1" HeaderStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblRESULT_2_1" runat="server" Text='<%#Bind("RESULT_2_1") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Result" HeaderStyle-Width="50px">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="CheckBoxChecking1" OnCheckedChanged="CheckBoxChecking1_CheckedChanged" Checked='<%#Convert.ToBoolean(Eval("RESULT_FLAG_2_1")) %>' AutoPostBack="true" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="CHECKING-2" HeaderStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblRESULT_2_2" runat="server" Text='<%#Bind("RESULT_2_2") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Result" HeaderStyle-Width="50px">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="CheckBoxChecking2" OnCheckedChanged="CheckBoxChecking2_CheckedChanged" Checked='<%#Convert.ToBoolean(Eval("RESULT_FLAG_2_2")) %>' AutoPostBack="true" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="PRINT">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblPRINT_FLAG_2" runat="server" Text='<%#Bind("PRINT_FLAG_2") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="REMARK-1" HeaderStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblRESULT_3_1" runat="server" Text='<%#Bind("RESULT_3_1") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Result" HeaderStyle-Width="50px">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="CheckBoxRemark1" OnCheckedChanged="CheckBoxRemark1_CheckedChanged" Checked='<%#Convert.ToBoolean(Eval("RESULT_FLAG_3_1")) %>' AutoPostBack="true" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="REMARK-2" HeaderStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblRESULT_3_2" runat="server" Text='<%#Bind("RESULT_3_2") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Result" HeaderStyle-Width="50px">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="CheckBoxRemark2" AutoPostBack="true" OnCheckedChanged="CheckBoxRemark2_CheckedChanged" Checked='<%#Convert.ToBoolean(Eval("RESULT_FLAG_3_2")) %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="PRINT">
                                                                <ItemTemplate>
                                                                    <asp:Label CssClass="label" ID="lblPRINT_FLAG_3" runat="server" Text='<%#Bind("PRINT_FLAG_3") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                    </asp:GridView>

                                                </div>



                                            </ContentTemplate>
                                        </ajax:TabPanel>

                                        <ajax:TabPanel ID="TabPanel3" runat="server" HeaderText="Service Remarks">
                                            <ContentTemplate>

                                                <div class="table-responsive" style="height: 272px; overflow-y: scroll">

                                                    <asp:GridView ID="GvServiceRemarks" CssClass="table table-vcenter table-condensed table-bordered"
                                                        runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                                        PageSize="10" ShowFooter="true">

                                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="SR.NO." HeaderStyle-Width="50px">
                                                                <ItemTemplate>

                                                                    <asp:HiddenField ID="HfCompCode" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                                    <asp:HiddenField ID="HfTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                    <asp:HiddenField ID="HfTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                    <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SRNO") %>' />


                                                                    <%#Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="SERVICE REMARK">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdrightalign" ID="TxtServiceRemark" Text='<%#Bind("REMARK") %>' runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderStyle-Width="150px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="BtnDeleteRowServiceRemarkGrid" runat="server" OnClick="BtnDeleteRowServiceRemarkGrid_Click" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Button ID="BtnAddRowServiceRemarkGrid" runat="server" OnClick="BtnAddRowServiceRemarkGrid_Click" Text="Add New Row" CausesValidation="false" />

                                                                </FooterTemplate>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                    </asp:GridView>
                                                </div>

                                            </ContentTemplate>
                                        </ajax:TabPanel>

                                        <ajax:TabPanel ID="TabPanel4" runat="server" HeaderText="Service Person">
                                            <ContentTemplate>

                                                <div style="float: left; height: auto; width: 40%;">
                                                    <div class="col-md-12">
                                                        <table class="col-md-12">

                                                            <tr>
                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Service Person-1" ForeColor="Blue" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:HiddenField ID="HfServicePeronBCODE1" runat="server" />
                                                                    <asp:TextBox ID="TxtServicePerson1" CssClass="form-control" OnTextChanged="TxtServicePerson1_TextChanged" AutoPostBack="true" ForeColor="Blue" runat="server"></asp:TextBox>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtenderTxtServicePersonName1" runat="server" TargetControlID="TxtServicePerson1"
                                                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                        ServiceMethod="GetServicePersonName">
                                                                    </ajax:AutoCompleteExtender>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Service Person-2" ForeColor="Blue" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:HiddenField ID="HfServicePeronBCODE2" runat="server" />
                                                                    <asp:TextBox ID="TxtServicePerson2" CssClass="form-control" OnTextChanged="TxtServicePerson2_TextChanged" AutoPostBack="true" ForeColor="Blue" runat="server"></asp:TextBox>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtenderTxtServicePerson2" runat="server" TargetControlID="TxtServicePerson2"
                                                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                        ServiceMethod="GetServicePersonName">
                                                                    </ajax:AutoCompleteExtender>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Service Person-3" ForeColor="Blue" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:HiddenField ID="HfServicePeronBCODE3" runat="server" />
                                                                    <asp:TextBox ID="TxtServicePerson3" CssClass="form-control" AutoPostBack="true" OnTextChanged="TxtServicePerson3_TextChanged" ForeColor="Blue" runat="server"></asp:TextBox>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtenderTxtServicePerson3" runat="server" TargetControlID="TxtServicePerson3"
                                                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                        ServiceMethod="GetServicePersonName">
                                                                    </ajax:AutoCompleteExtender>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Service Person-4" ForeColor="Blue" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:HiddenField ID="HfServicePeronBCODE4" runat="server" />
                                                                    <asp:TextBox ID="TxtServicePerson4" CssClass="form-control" OnTextChanged="TxtServicePerson4_TextChanged" AutoPostBack="true" ForeColor="Blue" runat="server"></asp:TextBox>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtenderTxtServicePerson4" runat="server" TargetControlID="TxtServicePerson4"
                                                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                        ServiceMethod="GetServicePersonName">
                                                                    </ajax:AutoCompleteExtender>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Service Person-5" ForeColor="Blue" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:HiddenField ID="HfServicePeronBCODE5" runat="server" />
                                                                    <asp:TextBox ID="TxtServicePerson5" CssClass="form-control" OnTextChanged="TxtServicePerson5_TextChanged" AutoPostBack="true" ForeColor="Blue" runat="server"></asp:TextBox>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtenderTxtServicePerson5" runat="server" TargetControlID="TxtServicePerson5"
                                                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                        ServiceMethod="GetServicePersonName">
                                                                    </ajax:AutoCompleteExtender>
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
                                                                    <asp:Label CssClass="label" Text="Profit (%)" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:TextBox ID="TxtServicePersonProfitPer1" OnTextChanged="TxtServicePersonProfitPer1_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </td>

                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label " Text="Profit Amt." runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:TextBox ID="TxtServicePersonProfitAmt1" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Profit (%)" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:TextBox ID="TxtServicePersonProfitPer2" OnTextChanged="TxtServicePersonProfitPer2_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </td>

                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Profit Amt." runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:TextBox ID="TxtServicePersonProfitAmt2" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Profit (%)" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:TextBox ID="TxtServicePersonProfitPer3" OnTextChanged="TxtServicePersonProfitPer3_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </td>

                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Profit Amt." runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:TextBox ID="TxtServicePersonProfitAmt3" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Profit (%)" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:TextBox ID="TxtServicePersonProfitPer4" OnTextChanged="TxtServicePersonProfitPer4_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </td>

                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Profit Amt." runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:TextBox ID="TxtServicePersonProfitAmt4" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Profit (%)" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:TextBox ID="TxtServicePersonProfitPer5" OnTextChanged="TxtServicePersonProfitPer5_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </td>

                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Profit Amt." runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:TextBox ID="TxtServicePersonProfitAmt5" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Total Profit (%)" ForeColor="Red" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:TextBox ID="TxtProfitTotalPercentage" ReadOnly="true" ForeColor="Red" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </td>

                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Total Profit Amt." ForeColor="Red" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:TextBox ID="TxtProfitTotalAmount" ForeColor="Red" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>


                                                        </table>
                                                    </div>
                                                </div>

                                            </ContentTemplate>
                                        </ajax:TabPanel>

                                        <ajax:TabPanel ID="TabPanel5" runat="server" HeaderText="Service Used Item">
                                            <ContentTemplate>

                                                <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                    <div class="h5" style="color: brown; text-align: left">Service Used Item Details</div>
                                                    <asp:GridView ID="GvServiceUseItem" CssClass="table table-vcenter table-condensed table-bordered"
                                                        runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                                        PageSize="10" ShowFooter="true">

                                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="SR.NO." HeaderStyle-Width="50px">
                                                                <ItemTemplate>
                                                                    <%--  <asp:HiddenField ID="HfTransDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                    <asp:HiddenField ID="HfTransNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                    <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SRNO") %>' />--%>
                                                                    <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("scode") %>' />

                                                                    <asp:HiddenField ID="HfRefTranDate" runat="server" Value='<%#Bind("REF_TRAN_DATE") %>' />
                                                                    <asp:HiddenField ID="HfRefTranNo" runat="server" Value='<%#Bind("REF_TRAN_NO") %>' />
                                                                    <asp:HiddenField ID="HfRefSrNo" runat="server" Value='<%#Bind("REF_SRNO") %>' />

                                                                    <%#Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="PRODUCT NAME" ControlStyle-Width="250px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="TxtProductName" Style="width: 300px;" ForeColor="Blue" Enabled="false" Text='<%#Bind("sname") %>' runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="PRODUCT CODE" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="TxtProductCode" ForeColor="Blue" Enabled="false" Style="width: 100px;" Text='<%#Bind("prod_code") %>' runat="server" AutoPostBack="true"></asp:TextBox>

                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="CHALLAN DATE" HeaderStyle-Width="150px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control" ID="TxtChallanDate" Enabled="false" Text='<%#Bind("cha_dt") %>' runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="CHALLAN NO." HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control" ID="TxtChallnNo" Enabled="false" Text='<%#Bind("cha_no") %>' runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="QTY" HeaderStyle-Width="80px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdrightalign" ID="TxtQty" Enabled="false" Text='<%#Bind("qty") %>' Style="text-align: right;" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="RETURN QTY" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" Enabled="false" Text='<%#Bind("ret_qty") %>' ID="TxtReturnQty" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="TOTAL USE QTY" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdrightalign" ID="TxtTotUseQty" Enabled="false" Text='<%#Bind("use_qty") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="BALANCE QTY" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" Enabled="false" Text='<%#Bind("bal_qty") %>' runat="server" ID="TxtBalanceQty"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="USE QTY" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" ID="TxtUseQty" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="SELECT" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="ChkSelectItem" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                    </asp:GridView>

                                                </div>



                                                <div style="width: 50%; height: 65px; float: left;">
                                                    <table class="col-md-12">
                                                        <tr>
                                                            <td style="padding-left: 5px;">
                                                                <asp:Button ID="BtnFetchServiceUseItem" runat="server" OnClick="BtnFetchServiceUseItem_Click" Text="Fetch Data" Height="33px" Width="150px" CausesValidation="false" CssClass="btn btn-success btn-sm" />
                                                            </td>
                                                            <td style="padding-left: 5px;">
                                                                <asp:Button ID="BtnProcess" runat="server" Text="Process" Height="33px" Width="150px" CausesValidation="false" CssClass="btn btn-success btn-sm" />
                                                            </td>
                                                            <td style="padding-left: 5px;">
                                                                <asp:Button ID="BtnSelectAll" runat="server" Text="Select All" Height="33px" Width="180px" CausesValidation="false" CssClass="btn btn-success btn-sm" />
                                                            </td>
                                                            <td style="padding-left: 5px;">
                                                                <asp:Button ID="BtnDeSelectAll" runat="server" Text="De-Select All" Height="33px" Width="180px" CausesValidation="false" CssClass="btn btn-success btn-sm" />
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </div>

                                            </ContentTemplate>
                                        </ajax:TabPanel>

                                        <ajax:TabPanel ID="TabPanel6" runat="server" HeaderText="Labour Charges">
                                            <ContentTemplate>

                                                <div class="table-responsive" style="height: 200px; overflow-y: scroll">
                                                    <div class="h5" style="color: brown; text-align: left">Labour Charges Detail</div>
                                                    <asp:GridView ID="GvLabourChagresDetails" CssClass="table table-vcenter table-condensed table-bordered" OnRowDataBound="GvLabourChagresDetails_RowDataBound"
                                                        runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                                        PageSize="10" ShowFooter="true">

                                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="SR.NO.">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="HfCompCode" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                                    <asp:HiddenField ID="HfTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                    <asp:HiddenField ID="HfTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                    <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                    <asp:HiddenField ID="HfChargesCode" runat="server" Value='<%#Bind("CCODE") %>' />

                                                                    <%-- <asp:HiddenField ID="HfChargesAmount" runat="server" Value='<%#Bind("AMT") %>' />--%>

                                                                    <%#Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="NAME OF THE CHARGES">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="TxtChargesName" ForeColor="Blue" OnTextChanged="TxtChargesName_TextChanged" Style="width: 300px;" runat="server" AutoPostBack="true"></asp:TextBox>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtenderTxtChargesName" runat="server" TargetControlID="TxtChargesName"
                                                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                        ServiceMethod="GetChargesName">
                                                                    </ajax:AutoCompleteExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="CHARGES DESCRIPTION" HeaderStyle-Width="350px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdleftalign" ID="TxtChargesDescription" Style="text-align: left;" Text='<%#Bind("LAB_DESC") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="QTY" HeaderStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdrightalign" ID="TxtQty" OnTextChanged="TxtQty_TextChanged" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("QTY") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblSumTotalQty" ForeColor="Red" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="RATE" HeaderStyle-Width="150px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdrightalign" ID="TxtRate" OnTextChanged="TxtRate_TextChanged" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("RATE") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="AMT">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdrightalign" Enabled="false" ID="TxtChargesAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblTotalChargesAmount" ForeColor="Red" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="REMARKS" HeaderStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control grdleftalign" ID="TxtRemarks" Style="text-align: left;" Text='<%#Bind("REMARK") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <%--<asp:TemplateField HeaderText="CGST %" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtCGSTRate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("CGST_RATE") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>                                     
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CGST AMOUNT" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtCGSTAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("CGST_AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblCGSTSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SGST %" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtSGSTRate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("SGST_RATE") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SGST AMOUNT" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtSGSTAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("SGST_AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                             <FooterTemplate>
                                                                <asp:Label ID="lblSGSTSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="IGST %" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtIGSTRate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("IGST_RATE") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="IGST AMOUNT" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtIGSTAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("IGST_AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                             <FooterTemplate>
                                                                <asp:Label ID="lblIGSTSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="TOTAL AMOUNT" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtTotalAmount" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("T_AMT") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                             <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>--%>

                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="BtnDeleteRowLabourChargesDetailGrid" OnClick="BtnDeleteRowLabourChargesDetailGrid_Click" runat="server" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                                </ItemTemplate>

                                                                <FooterStyle HorizontalAlign="left" />
                                                                <FooterTemplate>
                                                                    <asp:Button ID="BtnAddRowLabourChargesDetailGrid" OnClick="BtnAddRowLabourChargesDetailGrid_Click" runat="server" Text="Add New Row" CausesValidation="false" />
                                                                </FooterTemplate>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                    </asp:GridView>
                                                </div>

                                                <div style="float: right; height: auto; width: 40%;">
                                                    <div class="col-md-12">
                                                        <table class="col-md-12">

                                                            <tr>

                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="TOTAL" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:TextBox ID="TxtTotalChargesAmt" CssClass="form-control" Style="text-align: right;" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>


                                                            <tr>
                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Service Tax %" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:TextBox ID="TxtServiceTaxPer" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </td>

                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Amount" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:TextBox ID="TxtServiceTaxAmt" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="R.O Amt" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px; padding-bottom: 5PX">
                                                                    <asp:TextBox ID="TxtROamt" CssClass="form-control grdleftalign" ReadOnly="true" Style="text-align: right;" runat="server"></asp:TextBox>
                                                                </td>

                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="PROFIT %" ForeColor="#ff0080" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px; padding-bottom: 5PX">
                                                                    <asp:TextBox ID="TxtProfitPercentageJobMas" OnTextChanged="TxtProfitPercentageJobMas_TextChanged" AutoPostBack="true" ForeColor="#ff0080" CssClass="form-control grdleftalign" Style="text-align: right;" runat="server"></asp:TextBox>
                                                                </td>

                                                            </tr>

                                                            <tr>

                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="Net Amount" ForeColor="Red" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px;">
                                                                    <asp:TextBox ID="TxtNetAmt" ForeColor="Red" ReadOnly="true" CssClass="form-control" Style="text-align: right;" runat="server"></asp:TextBox>
                                                                </td>

                                                                <td align="right" style="padding-bottom: 10px;">
                                                                    <asp:Label CssClass="label" Text="PROFIT AMOUNT" ForeColor="#ff0080" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="padding-left: 10px; padding-bottom: 5PX">
                                                                    <asp:TextBox ID="TxtProfitAmountJobMas" ForeColor="#ff0080" ReadOnly="true" CssClass="form-control grdleftalign" Style="text-align: right;" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </div>
                                                </div>

                                            </ContentTemplate>
                                        </ajax:TabPanel>


                                        <ajax:TabPanel ID="TabPanel7" runat="server" HeaderText="Service Bill">
                                            <ContentTemplate>

                                                <div style="width: 50%; height: 65px; float: left;">
                                                    <table class="col-md-12">

                                                        <tr>
                                                            <td align="right" style="padding-bottom: 10px;">
                                                                <asp:Label CssClass="label" Text="Invoice No." runat="server"></asp:Label>
                                                            </td>
                                                            <td style="padding-left: 10px;">
                                                                <asp:TextBox ID="TxtInvoiceNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="padding-bottom: 10px;">
                                                                <asp:Label CssClass="label" Text="Invoice Date" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="padding-left: 10px;">
                                                                <asp:TextBox ID="TxtInvoiceDate" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="padding-bottom: 10px;">
                                                                <asp:Label CssClass="label" Text="Invoice Time" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="padding-left: 10px;">
                                                                <asp:TextBox ID="TxtInvoiceTime" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td></td>
                                                            <td style="padding-left: 5px;">
                                                                <asp:Button ID="BtnGenerateBill" runat="server" Text="Generate Bill" OnClick="BtnGenerateBill_Click" Height="33px" Width="150px" CausesValidation="false" CssClass="btn btn-success btn-sm" />
                                                            </td>
                                                            <td></td>
                                                            <td style="padding-left: 5px;">
                                                                <asp:Button ID="BtnViewRecord" runat="server" Text="View Record" Height="33px" Width="150px" OnClick="BtnViewRecord_Click" CausesValidation="false" CssClass="btn btn-success btn-sm" />
                                                            </td>
                                                            <td></td>
                                                            <td style="padding-left: 5px;">
                                                                <asp:Button ID="BtnDeleteRecord" runat="server" Text="Delete Record" Height="33px" Width="150px" OnClick="BtnDeleteRecord_Click" CausesValidation="false" CssClass="btn btn-success btn-sm" />
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td align="right" style="padding-bottom: 10px;">
                                                                <asp:Label CssClass="label" Text="View Result" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="padding-left: 10px;">
                                                                <asp:DropDownList ID="DdlViewResult" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="0">SELECT TYPE </asp:ListItem>
                                                                    <asp:ListItem Value="S">SCREEN</asp:ListItem>
                                                                    <asp:ListItem Value="P">PRINTER</asp:ListItem>
                                                                    <asp:ListItem Value="F">PDF</asp:ListItem>

                                                                </asp:DropDownList>
                                                                <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldDdlCompanyType" runat="server"
                                                            InitialValue="0" ControlToValidate="DdlViewResult" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td align="right" style="padding-bottom: 10px;">
                                                                <asp:Label CssClass="label" Text="Print Invoice Copy" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="padding-left: 10px;">
                                                                <asp:DropDownList ID="DdlPrintInvoiceCopy" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="0">SELECT TYPE </asp:ListItem>
                                                                    <asp:ListItem Value="A">All Copy</asp:ListItem>
                                                                    <asp:ListItem Value="O">Original For Buyer</asp:ListItem>
                                                                    <asp:ListItem Value="D">Duplicate For Transport</asp:ListItem>
                                                                    <asp:ListItem Value="T">Triplicate For Assessee</asp:ListItem>
                                                                    <asp:ListItem Value="E">Extra Copy</asp:ListItem>

                                                                </asp:DropDownList>
                                                                <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldDdlCompanyType" runat="server"
                                                            InitialValue="0" ControlToValidate="DdlJobCategory" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td></td>
                                                            <td style="padding-left: 5px;">
                                                                <asp:Button runat="server" ID="BtnViewInvoice" OnClick="BtnViewInvoice_Click" Text="View Invoice" OnClientClick="aspnetForm.target ='_blank';" />
                                                            </td>
                                                            <td></td>
                                                            <td style="padding-left: 5px;">
                                                                <asp:Button runat="server" ID="BtnPrintCover" Text="Print Cover" OnClientClick="aspnetForm.target ='_blank';" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>

                                            </ContentTemplate>

                                        </ajax:TabPanel>

                                    </ajax:TabContainer>



                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="BtnPartyModelDetails" />
                                    <asp:PostBackTrigger ControlID="BtnViewAMC" />
                                    <%--   <asp:PostBackTrigger ControlID="BtnViewRecord" />--%>
                                    <%-- <asp:AsyncPostBackTrigger ControlID="BtnViewRecord" EventName="BtnViewRecord_Click" />--%>
                                    <asp:PostBackTrigger ControlID="TabContainer1$TabPanel7$BtnViewRecord" />
                                </Triggers>
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
        <asp:HiddenField ID="HfAMC_TRAN_DATE" runat="server" />
        <asp:HiddenField ID="HfAMC_TRAN_NO" runat="server" />
        <asp:HiddenField ID="HfAMC_SRNO" runat="server" />
        <asp:HiddenField ID="HfRef_TranNo" runat="server" />
         <asp:HiddenField ID="HfRef_TranDate" runat="server" />
                                   

        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvJobCardMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvJobCardMaster_PageIndexChanging" OnRowCommand="GvJobCardMaster_RowCommand" OnRowDataBound="GvJobCardMaster_RowDataBound"
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

                            <asp:TemplateField HeaderText="JOBCARD NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblJobCardNo" runat="server" Text='<%#Bind("JOBCARD_NO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="JOBCARD DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblJobCardDate" runat="server" Text='<%#Bind("JOBCARD_DATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="JOBCARD TIME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblJobCardTime" runat="server" Text='<%#Bind("JOBCARD_TIME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PARTY NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblPartyName" runat="server" Text='<%#Bind("PartyName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SERVICE TYPE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblServiceType" runat="server" Text='<%#Bind("SERVICE_TYPE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="OUR MODEL SR.NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblModelSrNo" runat="server" Text='<%#Bind("MODEL_SRNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PARTY SR.NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblPartySrNo" runat="server" Text='<%#Bind("PARTY_SRNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="MFG.SR.NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblMenufectureSrNo" runat="server" Text='<%#Bind("MFG_SRNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="BRAND NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblBrandName" runat="server" Text='<%#Bind("Brand_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="MODEL NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblModelName" runat="server" Text='<%#Bind("Model_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CLOSED ?">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblClosedFlag" runat="server" Text='<%#Bind("CLOSE_FLAG") %>'></asp:Label>
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

                    <h4 class="modal-title">DELETE JOBCARD MASTER DETAIL</h4>
                </div>
                <div class="modal-body">


                    <span>Are you sure want to delete...!!!</span>
                    <br />

                    <div id="Div1" runat="server" class="grids">

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

                        <h4 class="modal-title">UPDATE JOBCARD MASTER DETAIL</h4>
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

    <div class="modal fade" tabindex="-1" id="CmpPartyModelSrNo" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" style="color: red">Party Model Details</h4>
                </div>

                <div class="modal-body">
                    <div id="Div2" runat="server" class="grids">
                        <div class="panel panel-widget top-grids">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    Find
                                  <asp:TextBox ID="TxtSearchPartyModelSrNo" CssClass="form-control" runat="server"></asp:TextBox>

                                    <asp:GridView ID="GvPartyModelSrNo" CssClass="table table-vcenter table-condensed table-bordered"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnRowCommand="GvPartyModelSrNo_RowCommand"
                                        PageSize="10" ShowFooter="true">
                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="Sr.No.">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HfCompCodeModel" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                    <asp:HiddenField ID="HfBranchCodeModel" runat="server" Value='<%#Bind("BRANCH_CODE") %>' />

                                                    <asp:Button ID="btnSelect" runat="server" CausesValidation="false" CommandName="Selecta" CommandArgument='<%#Bind("SRNO") %>' ToolTip="View" Text="SELECT" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Model Sr.No.">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblModelSrNo" runat="server" Text='<%#Bind("MODEL_SRNO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Party Sr.No.">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblPartySrNo" runat="server" Text='<%#Bind("PARTY_SRNO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Mfg Sr.No.">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblMfgSrNo" runat="server" Text='<%#Bind("MFG_SRNO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Brand Name">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblBrandName" runat="server" Text='<%#Bind("BRAND_NAME") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Model Name">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblModelName" runat="server" Text='<%#Bind("MODEL_NAME") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                    </asp:GridView>

                                    <center> <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK </button> </center>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--   <Triggers>
            <asp:PostBackTrigger ControlID="TxtAccountName" />
            <asp:PostBackTrigger ControlID="GvForPO" />
        </Triggers>--%>

    <script type="text/javascript">
        function HideModelPartyModelSrNo() {
            $("#CmpPartyModelSrNo").modal('hide');
        }

        function ShowModelPartyModelSrNo() {

            $("#CmpPartyModelSrNo").modal('show');

        }
        function SelectionAlert() {

            alert("Must be select Customer Name !");

        }

    </script>




    <script src="js/proton.js"></script>

    <div class="modal fade" tabindex="-1" id="CmpJobCardAssignLog" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" style="color: red">Jobcard Assign Person Detals</h4>
                </div>

                <div class="modal-body">
                    <div id="Div4" runat="server" class="grids">
                        <div class="panel panel-widget top-grids">

                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>

                                    <asp:GridView ID="GvJobardAssignPerson" CssClass="table table-vcenter table-condensed table-bordered"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                        PageSize="10" ShowFooter="true">
                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="Sr.No.">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex + 1 %>

                                                    <asp:HiddenField ID="HfCompCode" runat="server" Value='<%#Bind("comp_code") %>' />
                                                    <asp:HiddenField ID="HfTran_No" runat="server" Value='<%#Bind("tran_date") %>' />
                                                    <asp:HiddenField ID="HfTran_Date" runat="server" Value='<%#Bind("tran_no") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="ASSIGN PERSON NAME">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblAssignPerson" runat="server" Text='<%#Bind("BANME") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ASSIGN PERSON DATE">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblassign_date" runat="server" Text='<%#Bind("assign_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ASSIGN PERSON TIME">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblassign_time" runat="server" Text='<%#Bind("assign_time") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                    </asp:GridView>

                                    <center> <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK </button> </center>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        function HideModelAssignPersonsName() {
            $("#CmpJobCardAssignLog").modal('hide');
        }

        function ShowModelAssignPersonsName() {

            $("#CmpJobCardAssignLog").modal('show');

        }


    </script>

</asp:Content>
