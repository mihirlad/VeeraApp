<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="AMC_Confirmation.aspx.cs" Inherits="VeeraApp.Admin.AMC_Confirmation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/model.css" rel="stylesheet" />

     <script type="text/javascript">
        function txtachange() {
            //alert("jigar");
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
                    <h4>AMC CONFIRMATION TRANSACTION</h4>
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

                                    <div class="h5" style="color: brown">AMC Master</div>

                                    <asp:HiddenField ID="HfAMC_TYPE" runat="server" />
                                    <div style="float: left; height: auto; width: 35%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="AMC No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="1">
                                                        <asp:TextBox ID="TxtAMCNo" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server"
                                                            ControlToValidate="TxtAMCNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="AMC Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtAMCDate" OnTextChanged="TxtAMCDate_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtValidityDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                          ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtAMCDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderAMCDate" Format="dd-MM-yyyy" TargetControlID="TxtAMCDate"></ajax:CalendarExtender>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Party Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:HiddenField ID="HfACODE" runat="server" />
                                                        <asp:TextBox ID="TxtPartyName" OnTextChanged="TxtPartyName_TextChanged" AutoPostBack="true" CssClass="form-control" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtPartyName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                            ControlToValidate="TxtPartyName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Kind Attn." ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlKindAttn" runat="server" OnSelectedIndexChanged="DdlKindAttn_SelectedIndexChanged" ForeColor="Blue" CssClass="form-control" AutoPostBack="true">
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server"
                                                            ControlToValidate="DdlKindAttn" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:Button runat="server" ID="btnRefresh" OnClick="btnRefresh_Click" CausesValidation="false" CssClass="btn_Refresh" />
                                                        <asp:Button ID="BtnContactDetails" runat="server" Text="Contact Details" OnClick="BtnContactDetails_Click" Height="33px" Width="180px" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Contact Phone" runat="server"></asp:Label>
                                                    </td>


                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConatctPhone" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Contact Email" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtContactEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="AMC Start From Date" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtAMCStartDate" OnTextChanged="TxtAMCStartDate_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server"
                                                            ControlToValidate="TxtAMCStartDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderAMCStartDate" Format="dd-MM-yyyy" TargetControlID="TxtAMCStartDate"></ajax:CalendarExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="AMC To Date" runat="server"></asp:Label>
                                                    </td>


                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtAMCEndDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server"
                                                            ControlToValidate="TxtAMCEndDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderAMCEndDate" Format="dd-MM-yyyy" TargetControlID="TxtAMCEndDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Max.No.of Visit" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtMaxVisitNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="AMC Billing Terms" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlAMCBillingTerm" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                            <asp:ListItem Value="M">Monthly</asp:ListItem>
                                                            <asp:ListItem Value="Q">Quaterly</asp:ListItem>
                                                            <asp:ListItem Value="H">Half Yearly</asp:ListItem>
                                                            <asp:ListItem Value="Y">Yearly</asp:ListItem>
                                                        </asp:DropDownList>


                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredAccountName" runat="server" InitialValue="0"
                                                            ControlToValidate="DdlAMCBillingTerm" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>


                                            </table>
                                        </div>
                                    </div>


                                    <div style="float: left; height: auto; width: 40%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">


                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td align="left" style="padding-left: 10px;">
                                                        <asp:Label CssClass="label" Text="Contact Priority" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Contact Person-1" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:HiddenField ID="HfContactPerson1" runat="server" />
                                                        <asp:TextBox ID="TxtContactPersonName1" CssClass="form-control" OnTextChanged="TxtContactPersonName1_TextChanged" AutoPostBack="true" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderTxtServicePersonName1" runat="server" TargetControlID="TxtContactPersonName1"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetServicePersonName">
                                                        </ajax:AutoCompleteExtender>

                                                        <%--    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtServicePersonName1" ForeColor="Red">*</asp:RequiredFieldValidator>--%>


                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="1">
                                                        <asp:TextBox ID="TxtContactPriority1" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Contact Person-2" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:HiddenField ID="HfContactPerson2" runat="server" />
                                                        <asp:TextBox ID="TxtContactPersonName2" CssClass="form-control" ForeColor="Blue" OnTextChanged="TxtContactPersonName2_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteTxtServicePersonName2" runat="server" TargetControlID="TxtContactPersonName2"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetServicePersonName">
                                                        </ajax:AutoCompleteExtender>

                                                        <%--    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtServicePersonName1" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="1">
                                                        <asp:TextBox ID="TxtContactPriority2" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Contact Person-3" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:HiddenField ID="HfContactPerson3" runat="server" />
                                                        <asp:TextBox ID="TxtContactPersonName3" CssClass="form-control" ForeColor="Blue" OnTextChanged="TxtContactPersonName3_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteTxtServicePersonName3" runat="server" TargetControlID="TxtContactPersonName3"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetServicePersonName">
                                                        </ajax:AutoCompleteExtender>

                                                        <%--    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtServicePersonName1" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="1">
                                                        <asp:TextBox ID="TxtContactPriority3" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Contact Person-4" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:HiddenField ID="HfContactPerson4" runat="server" />
                                                        <asp:TextBox ID="TxtContactPersonName4" CssClass="form-control" ForeColor="Blue" OnTextChanged="TxtContactPersonName4_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteTxtServicePersonName4" runat="server" TargetControlID="TxtContactPersonName4"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetServicePersonName">
                                                        </ajax:AutoCompleteExtender>

                                                        <%--    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtServicePersonName1" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="1">
                                                        <asp:TextBox ID="TxtContactPriority4" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>



                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Prepared By" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="5" style="padding-left: 10px;">

                                                        <asp:HiddenField ID="HfPreparedPersonBy" runat="server" />
                                                        <asp:TextBox ID="TxtPreparedPersonName" CssClass="form-control" ForeColor="Blue" OnTextChanged="TxtPreparedPersonName_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtPreparedPersonName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetServicePersonName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtPreparedPersonName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Remark" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="5">
                                                        <asp:TextBox ID="TxtRemark" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td></td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:Button ID="BtnPartyModelDetails" runat="server" Text="Model Details" Height="33px" Width="180px" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>
                                                    <td></td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:Button ID="BtnBillingDetails" runat="server" Text="Billing Details" Height="33px" Width="180px" OnClick="BtnBillingDetails_Click" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>
                                                    <td></td>
                                                </tr>

                                            </table>
                                        </div>
                                    </div>

                                    <div style="float: left; height: auto; width: 25%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Checked ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
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
                                                    <td style="padding-left: 10px;" colspan="3">
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
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtCheckedBy" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Closed ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:DropDownList ID="DdlClosed" OnSelectedIndexChanged="DdlClosed_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Closed Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtClosedDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtConfirmDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                      ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <%--       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender2" Format="dd-MM-yyyy" TargetControlID="TxtCheckedDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Closed By" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtClosedBy" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Last AMC No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtLastAMCNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Last AMC Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtLastAMCDate" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender3" Format="dd-MM-yyyy" TargetControlID="TxtLastAMCDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
                                    </div>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="BtnContactDetails" />
                                </Triggers>
                            </asp:UpdatePanel>

                            <div style="clear: both; height: 10px;">
                            </div>

                            <div class="panel panel-widget top-grids">
                                <div class="chute chute-center text-center">

                                    <asp:UpdatePanel ID="UpdPnlPartyDetails" runat="server">
                                        <ContentTemplate>

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: brown; text-align: left">AMC Detail</div>
                                                <div style="padding: 10px 10px; float: left">
                                                    <asp:Button runat="server" ID="BtnPartyModelMaster" OnClick="BtnPartyModelMaster_Click" Text="Get Party Model SrNo." CausesValidation="false" CssClass="btn btn-success" />
                                                </div>
                                                <asp:GridView ID="GvAMCDetails" CssClass="table table-vcenter table-condensed table-bordered"  OnRowDataBound="GvAMCDetails_RowDataBound" OnRowCommand="GvAMCDetails_RowCommand"
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
                                                                <asp:HiddenField ID="HfACODE" runat="server" Value='<%#Bind("ACODE") %>' />
                                                                <asp:HiddenField ID="HfPartyRefSrNo" runat="server" Value='<%#Bind("PARTY_REFSRNO") %>' />


                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="PARTY MODEL SR.NO." ControlStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <%-- <asp:TextBox ID="TxtPartyModelSrNo" ForeColor="Blue" Width="250px" Text='<%#Bind("MODEL_SRNO") %>' runat="server" AutoPostBack="true"></asp:TextBox>--%>
                                                                <asp:TextBox ID="TxtPartyModelSrNo" ForeColor="Blue" Width="250px" runat="server" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtPartyModelSrNo"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetPartyModelSrNo">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PARTY SR.NO." ControlStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <%--<asp:TextBox CssClass="form-control grdrightalign" Enabled="false" ID="TxtPartySrNo" Text='<%#Bind("PARTY_SRNO") %>' runat="server"></asp:TextBox>--%>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Enabled="false" ID="TxtPartySrNo" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="MFG.SR.NO." ControlStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <%--<asp:TextBox CssClass="form-control grdrightalign" Enabled="false" ID="TxtMfgSrNo" Text='<%#Bind("MFG_SRNO") %>' runat="server"></asp:TextBox>--%>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Enabled="false" ID="TxtMfgSrNo" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="BRAND NAME" ControlStyle-Width="300px">
                                                            <ItemTemplate>
                                                                <%--   <asp:TextBox CssClass="form-control grdrightalign" Enabled="false" ID="TxtBrandName" Text='<%#Bind("BRAND_NAME") %>' runat="server"></asp:TextBox>--%>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Enabled="false" ID="TxtBrandName" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="BRAND TYPE NAME" ControlStyle-Width="300px">
                                                            <ItemTemplate>
                                                                <%-- <asp:TextBox CssClass="form-control grdrightalign" Enabled="false" ID="TxtBrandTypeName" Text='<%#Bind("BRANDTYPE_NAME") %>' runat="server"></asp:TextBox>--%>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Enabled="false" ID="TxtBrandTypeName" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="MODEL NAME" ControlStyle-Width="300px">
                                                            <ItemTemplate>
                                                                <%--  <asp:TextBox CssClass="form-control grdrightalign" Enabled="false" ID="TxtModelName" Text='<%#Bind("MODEL_NAME") %>' runat="server"></asp:TextBox>--%>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Enabled="false" ID="TxtModelName" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="QTY." ControlStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" OnTextChanged="TxtQty_TextChanged" AutoPostBack="true" ID="TxtQty" runat="server" Text='<%#Bind("QTY") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RATE" ControlStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtRate" OnTextChanged="TxtRate_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="AMOUNT" ControlStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" Style="text-align: right;" Enabled="false" onkeypress="return isNumber(event);" ID="TxtAmount" runat="server" Text='<%#Bind("AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="BtnServiceDetails" runat="server" CommandName="ServiceView" CommandArgument='<%#Bind("TRAN_NO") %>' Text="Service Details" CssClass="btn  btn-primary btn-block" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="BtnDeleteRowModelStockDetailGrid" runat="server" Text="Remove" OnClick="BtnDeleteRowModelStockDetailGrid_Click" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Button ID="BtnAddRowModelStockDetailGrid" runat="server" OnClick="BtnAddRowModelStockDetailGrid_Click" Text="Add New Row" CausesValidation="false" />

                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>

                                            </div>
                                        </ContentTemplate>
                            <%--     <Triggers>
                                 <asp:PostBackTrigger ControlID="BtnServiceDetails" />
                                  <asp:PostBackTrigger ControlID="GvAMCDetails" />
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
                    <asp:GridView ID="GvAMCMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvAMCMaster_PageIndexChanging" OnRowCommand="GvAMCMaster_RowCommand" OnRowDataBound="GvAMCMaster_RowDataBound"
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

                            <asp:TemplateField HeaderText="AMC NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblAMCNo" runat="server" Text='<%#Bind("AMC_NO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="AMC DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblAMCDate" runat="server" Text='<%#Bind("AMC_DATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PARTY NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblPartyName" runat="server" Text='<%#Bind("PartyName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CONTACT PERSON">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblPartContactPerson" runat="server" Text='<%#Bind("CONTACT_PERSON") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="AMC FROM DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblAMCFromDate" runat="server" Text='<%#Bind("AMC_FRDT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="AMC TO DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblAMCToDate" runat="server" Text='<%#Bind("AMC_TODT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PREPARED BY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblPreparedBy" runat="server" Text='<%#Bind("BrokerName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CHECKED ?">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblCheckedFlag" runat="server" Text='<%#Bind("CHK_FLAG") %>'></asp:Label>
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

                    <h4 class="modal-title">DELETE AMC MASTER DETAIL</h4>
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

                        <h4 class="modal-title">UPDATE AMC MASTER DETAIL</h4>
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

    <div class="modalquo fade" tabindex="-1" id="CmpPartyModelSrNo" data-keyboard="false" data-backdrop="static">
        <div class="modalquo-dialog modal-lg">
            <div class="modalquo-content">
                <div class="modalquo-header">
                    <h4 class="modalquo-title" style="color: red">Party Model Details</h4>
                </div>

                <div class="modalquo-body">
                    <div id="Div1" runat="server" class="grids">
                        <div class="panel panel-widget top-grids">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    Find
                                  <asp:TextBox ID="TxtSearchPartyModelSrNo" CssClass="form-control" runat="server"></asp:TextBox>

                                    <asp:GridView ID="GvPartyModelSrNo" CssClass="table table-vcenter table-condensed table-bordered"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvPartyModelSrNo_PageIndexChanging"
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
                                                    <asp:HiddenField ID="HfPartyRefSrNo" runat="server" Value='<%#Bind("SRNO") %>' />

                                                    <asp:CheckBox ID="ChkPartyModelSrNo" runat="server" />

                                                    <%--  <asp:Button ID="btnSelect" runat="server" CausesValidation="false" CommandName="Selecta" CommandArgument='<%#Bind("SRNO") %>' ToolTip="View" Text="SELECT" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>--%>
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


                                    <center> <asp:Button ID="btnAddCPartyModelSrNoProcess" runat="server" Text="Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnAddCPartyModelSrNoProcess_Click" CausesValidation="false" />
                                    <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK </button> </center>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnAddCPartyModelSrNoProcess" />
                                    <asp:PostBackTrigger ControlID="GvPartyModelSrNo" />


                                </Triggers>
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

    <div class="modal fade" tabindex="-1" id="CmpServiceDetails" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" style="color: blue">Service Details</h4>

                </div>

                <div class="modal-body">
                    <div id="Div4" runat="server" class="grids">
                        <div class="panel panel-widget top-grids">
                            <asp:UpdatePanel ID="UpdateServiceDetails" runat="server">
                                <ContentTemplate>

                                    <asp:GridView ID="GvServiceDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                        PageSize="10" ShowFooter="true">
                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="Sr.No.">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HfCompcode" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                    <asp:HiddenField ID="HfServiceTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                    <asp:HiddenField ID="HfServiceTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                    <asp:HiddenField ID="HfServiceSrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                    <%#Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="FROM DATE">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="TxtFromDate" runat="server" Text='<%#Bind("FRDT") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="TO DATE">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="TxtToDate" runat="server" Text='<%#Bind("TODT") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="SERVICE DATE">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="TxtServiceDate" runat="server" Text='<%#Bind("JOBSTART_DATE") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="JOBCARD NO.">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="TxtJobCardNo" runat="server" Text='<%#Bind("JOBCARD_NO") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="STATUS">
                                                <ItemTemplate>
                                                    <asp:DropDownList runat="server" ID="DdlServiceStatus">
                                                        <asp:ListItem Text="PENDING" Value="P"></asp:ListItem>
                                                        <asp:ListItem Text="COMPLETED" Value="C"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                          <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                    </asp:GridView>

                                    <button type="button" class="btn btn-primary" style="float: right;" data-dismiss="modal" value="NO">BACK </button>


                                </ContentTemplate>
                       <%--       <Triggers>
                               <asp:PostBackTrigger ControlID="BtnServiceDetails" />
                                    <asp:PostBackTrigger ControlID="GvAMCDetails" />
                              </Triggers>--%>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        function HideModelServiceDetails() {
            $("#CmpServiceDetails").modal('hide');
        }

        function ShowModelServiceDetails() {
           // alert("123");
            $("#CmpServiceDetails").modal('show');

        }

    </script>



    <script src="js/proton.js"></script>

    <div class="modal fade" tabindex="-1" id="CmpServiceBillDetails" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" style="color: blue">Service Bill Details</h4>

                </div>

                <div class="modal-body">
                    <div id="Div5" runat="server" class="grids">
                        <div class="panel panel-widget top-grids">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>

                                    <asp:GridView ID="GvServiceBillDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                        PageSize="10" ShowFooter="true">
                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="Sr.No.">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="HfCompcode" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                    <asp:HiddenField ID="HfServiceTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                    <asp:HiddenField ID="HfServiceTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                    <asp:HiddenField ID="HfServiceSrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                    <%#Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="FROM DATE">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="TxtFromDate" runat="server" Text='<%#Bind("FRDT") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="TO DATE">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="TxtToDate" runat="server" Text='<%#Bind("TODT") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="INVOICE DATE">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="TxtInvoiceDate" runat="server" Text='<%#Bind("INV_DATE") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="INVOICE NO.">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="TxtInvoiceNo" runat="server" Text='<%#Bind("INV_NO") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="STATUS">
                                                <ItemTemplate>
                                                    <asp:DropDownList runat="server" ID="DdlServiceStatus">
                                                        <asp:ListItem Text="PENDING" Value="P"></asp:ListItem>
                                                        <asp:ListItem Text="COMPLETED" Value="C"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                          <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                    </asp:GridView>

                                    <button type="button" class="btn btn-primary" style="float: right;" data-dismiss="modal" value="NO">BACK </button>


                                </ContentTemplate>
                       <%--       <Triggers>
                               <asp:PostBackTrigger ControlID="BtnServiceDetails" />
                                    <asp:PostBackTrigger ControlID="GvAMCDetails" />
                              </Triggers>--%>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        function HideModelServiceBillDetails() {
            $("#CmpServiceBillDetails").modal('hide');
        }

        function ShowModelServiceBillDetails() {
           // alert("123");
            $("#CmpServiceBillDetails").modal('show');

        }

    </script>



</asp:Content>
