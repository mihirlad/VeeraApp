<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="Service_Issue_ToBranch.aspx.cs" Inherits="VeeraApp.Admin.Service_Issue__ToBranch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
                    <h4 id="PageTiltle1" runat="server">SERVICE ISSUE TO BRANCH</h4>
                    <h4 id="PageTiltle2" runat="server">SERVICE RECEIVED FROM BRANCH</h4>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="HfBranchIssueToServiceType" runat="server" />

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

                                    <div class="h5" style="color: brown">Service Issue To Branch </div>

                                    <div style="float: left; height: auto; width: 35%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Sr.No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="1">
                                                        <asp:TextBox ID="TxtSrNo" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server"
                                                            ControlToValidate="TxtSrNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>



                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Service Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtServiceDate" OnTextChanged="TxtServiceDate_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtServiceDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                          ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtServiceDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderServiceDate" Format="dd-MM-yyyy" TargetControlID="TxtServiceDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="FROM BRANCH" runat="server"></asp:Label>
                                                    </td>

                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtFromBranch" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="TO BRANCH" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>

                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:HiddenField ID="HfToBranchCode" runat="server" />
                                                        <asp:TextBox ID="TxtToBranch" CssClass="form-control" OnTextChanged="TxtToBranch_TextChanged" AutoPostBack="true" ForeColor="Blue" runat="server"></asp:TextBox>

                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderTxtToBranch" runat="server" TargetControlID="TxtToBranch"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetBranchName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server"
                                                            ControlToValidate="TxtToBranch" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Visit Start Time" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtVisitStartTime" CssClass="form-control" runat="server"></asp:TextBox>

                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Visit Close Time" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtVisitCloseTime" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                             

                                            </table>
                                        </div>
                                    </div>


                                    <div style="float: left; height: auto; width: 30%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Service Person-1" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:HiddenField ID="HfServicePerson1" runat="server" />
                                                        <asp:TextBox ID="TxtServicePersonName1" CssClass="form-control" OnTextChanged="TxtServicePersonName1_TextChanged" AutoPostBack="true" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderTxtServicePersonName1" runat="server" TargetControlID="TxtServicePersonName1"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetServicePersonName">
                                                        </ajax:AutoCompleteExtender>

                                                        <%--    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtServicePersonName1" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Service Person-2" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:HiddenField ID="HfServicePerson2" runat="server" />
                                                        <asp:TextBox ID="TxtServicePersonName2" CssClass="form-control" ForeColor="Blue" OnTextChanged="TxtServicePersonName2_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteTxtServicePersonName2" runat="server" TargetControlID="TxtServicePersonName2"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetServicePersonName">
                                                        </ajax:AutoCompleteExtender>

                                                        <%--    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtServicePersonName1" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Service Person-3" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:HiddenField ID="HfServicePerson3" runat="server" />
                                                        <asp:TextBox ID="TxtServicePersonName3" CssClass="form-control" ForeColor="Blue" OnTextChanged="TxtServicePersonName3_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteTxtServicePersonName3" runat="server" TargetControlID="TxtServicePersonName3"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetServicePersonName">
                                                        </ajax:AutoCompleteExtender>

                                                        <%--    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtServicePersonName1" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Service Person-4" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:HiddenField ID="HfServicePerson4" runat="server" />
                                                        <asp:TextBox ID="TxtServicePersonName4" CssClass="form-control" ForeColor="Blue" OnTextChanged="TxtServicePersonName4_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteTxtServicePersonName4" runat="server" TargetControlID="TxtServicePersonName4"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetServicePersonName">
                                                        </ajax:AutoCompleteExtender>

                                                        <%--    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtServicePersonName1" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Service Person-5" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:HiddenField ID="HfServicePerson5" runat="server" />
                                                        <asp:TextBox ID="TxtServicePersonName5" CssClass="form-control" ForeColor="Blue" OnTextChanged="TxtServicePersonName5_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteTxtServicePersonName5" runat="server" TargetControlID="TxtServicePersonName5"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetServicePersonName">
                                                        </ajax:AutoCompleteExtender>

                                                        <%--    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtServicePersonName1" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Delivered By" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">

                                                        <asp:HiddenField ID="HfDeliveredPersonBy" runat="server" />
                                                        <asp:TextBox ID="TxtDeliveredPersonName" CssClass="form-control" ForeColor="Blue" OnTextChanged="TxtDeliveredPersonName_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtDeliveredPersonName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetServicePersonName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtDeliveredPersonName" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                                        <asp:Label CssClass="label" Text="Job Start Time" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtJobStartTime" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Job Close Time" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtJobCloseTime" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Checked By" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <%--    <asp:DropDownList ID="DdlCheckedBy" runat="server" ForeColor="Blue" CssClass="form-control">
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" InitialValue="0"
                                                            ControlToValidate="DdlCheckedBy" ForeColor="Red">*</asp:RequiredFieldValidator>--%>


                                                        <asp:HiddenField ID="HfCheckedByPerson" runat="server" />
                                                        <asp:TextBox ID="TxtCheckedBy" CssClass="form-control" OnTextChanged="TxtCheckedBy_TextChanged" AutoPostBack="true" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteTxtCheckedBy" runat="server" TargetControlID="TxtCheckedBy"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetServicePersonName">
                                                        </ajax:AutoCompleteExtender>

                                                        <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtCheckedBy" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>

                                                <tr>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="TOTAL CHARGES AMT" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtTotalChargesAmt" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Received ?" ForeColor="Red" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlReceivedFlag" AutoPostBack="true" OnSelectedIndexChanged="DdlReceivedFlag_SelectedIndexChanged" ForeColor="Red" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Received Date" ForeColor="Red" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtReceivedDate" ForeColor="Red" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                       ControlToValidate="TxtConfirmDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtReceivedDate"></ajax:CalendarExtender>
                                                    </td>


                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Received By" ForeColor="Red" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtReceivedBy" CssClass="form-control" ForeColor="Red" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Generate Result ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlPrintInvoiceCopy" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="S">SCREEN</asp:ListItem>
                                                            <asp:ListItem Value="P">PDF</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </td>
                                                    <td></td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:Button runat="server" ID="BtnViewChallan" OnClientClick="aspnetForm.target ='_blank';" OnClick="BtnViewChallan_Click" Text="View-Challan" />
                                                    </td>

                                                </tr>

                                            </table>
                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div style="clear: both; height: 10px;">
                            </div>

                            <div class="panel panel-widget top-grids">
                                <div class="chute chute-center text-center">

                                    <asp:UpdatePanel ID="UpdPnlPartyDetails" runat="server">
                                        <ContentTemplate>

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: brown; text-align: left">Party Detail</div>
                                                <asp:GridView ID="GvBranchPartyTranDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvBranchPartyTranDetails_PageIndexChanging" OnRowCommand="GvBranchPartyTranDetails_RowCommand" OnRowDataBound="GvBranchPartyTranDetails_RowDataBound"
                                                    PageSize="10" ShowFooter="true">

                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="SR.NO.">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                <asp:HiddenField ID="HfACODE" runat="server" Value='<%#Bind("ACODE") %>' />
                                                                <asp:HiddenField ID="HfTotalTime" runat="server" Value='<%#Bind("TOT_TIME") %>' />
                                                                  <asp:HiddenField ID="HfJobCompletedFlag" runat="server" Value='<%#Bind("JOB_COMPFLAG") %>' />

                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="PARTY NAME">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtPartyName" ForeColor="Blue" Width="250px" runat="server" OnTextChanged="TxtPartyName_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtPartyName"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetAccountName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CONTACT PERSON">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtContactPerson" Text='<%#Bind("CONTACT_PERSON") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CONTACT PHONE">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtContactPhone" Text='<%#Bind("CONTACT_PHONE") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="COMPANY REMARK">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtCompanyRemark" Text='<%#Bind("COMPANY_REMARK") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="START TIME">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtJobStartTime" Text='<%#Bind("JOBSTART_TIME") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CLOSE TIME">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtJobCloseTime" Text='<%#Bind("JOBCLOSE_TIME") %>' OnTextChanged="TxtJobCloseTime_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="TOTAL TIME [HH:MM]">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtTotalTime" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="COMPLETED STATUS">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="DdlCompletedStaus" runat="server">
                                                                    <asp:ListItem Text="YES" Value="Y"></asp:ListItem>
                                                                    <asp:ListItem Text="NO" Selected="True" Value="N"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="OWN REMARK">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtOwnRemark" Text='<%#Bind("OWN_REMARK") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="ADD CONTACT DETAILS">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnContactDetais" runat="server" CausesValidation="false" Width="120px" CommandName="ViewContactDetails" CommandArgument='<%#Bind("ACODE") %>' ToolTip="Contact Details" Text="Contact Details" CssClass="btn-danger btn-sm" BorderStyle="None"></asp:Button>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="BtnDeleteRowModelPartyDetailGrid" runat="server" OnClick="BtnDeleteRowModelPartyDetailGrid_Click" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Button ID="BtnAddRowModelPartyDetailGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelPartyDetailGrid_Click" CausesValidation="false" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>

                                        </ContentTemplate>
                                        <Triggers>
                                          <asp:PostBackTrigger ControlID="GvBranchPartyTranDetails" />
                                      </Triggers>
                                      </asp:UpdatePanel>


                                       <%-- <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="GvBranchPartyTranDetails" EventName="RowCommand" />
                                        </Triggers>--%>
                                   

                                </div>
                            </div>


                            <div style="clear: both; height: 10px;">
                            </div>

                            <div class="panel panel-widget top-grids">
                                <div class="chute chute-center text-center">

                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: brown; text-align: left">Charges Detail</div>
                                                <asp:GridView ID="GvChagresTranDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvChagresTranDetails_PageIndexChanging" OnRowCommand="GvChagresTranDetails_RowCommand" OnRowDataBound="GvChagresTranDetails_RowDataBound"
                                                    PageSize="10" ShowFooter="true">

                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="SR.NO.">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfTranDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfTranNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                <asp:HiddenField ID="HfChargesCode" runat="server" Value='<%#Bind("CCODE") %>' />

                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="NAME OF THE CHARGES">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtChargesName" ForeColor="Blue" Style="width: 300px;" runat="server" OnTextChanged="TxtChargesName_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtenderTxtChargesName" runat="server" TargetControlID="TxtChargesName"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetChargesName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CHARGES DESCRIPTION">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtChargesDesription" Text='<%#Bind("CHARGES_DESC") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="AMOUNT">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" OnTextChanged="TxtChargesAmount_TextChanged" AutoPostBack="true" ID="TxtChargesAmount" Text='<%#Bind("AMT") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblISumChargesTotalAmount" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="BtnDeleteRowModelChargesDetailGrid" runat="server" OnClick="BtnDeleteRowModelChargesDetailGrid_Click" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Button ID="BtnAddRowModelChargesDetailGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelChargesDetailGrid_Click" CausesValidation="false" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>


                            <div style="clear: both; height: 10px">
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

            <%--  <div style="float: right;">
                <asp:Label CssClass="label" Style="color: red;" Text="Search By Challan No./From Branch/To Branch/Delivered Person" runat="server"></asp:Label><br />
                <asp:TextBox ID="TxtSearch" runat="server" Style="width: 100%;" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>--%>
        </div>

        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBranchCode" runat="server" />
        <asp:HiddenField ID="HfTranDate" runat="server" />
        <asp:HiddenField ID="HfTranNo" runat="server" />

        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvServiceIssueBranchMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvServiceIssueBranchMaster_PageIndexChanging" OnRowCommand="GvServiceIssueBranchMaster_RowCommand" OnRowDataBound="GvServiceIssueBranchMaster_RowDataBound"
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

                                    <%--    <a href="JavaScript:divexpandcollapse('div<%# Eval("TRAN_NO") %>');">
                                        <img id='imgdiv<%# Eval("TRAN_NO") %>' width="15px" border="0" src="/images/plus.gif" />
                                    </a>--%>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblServiceDate" runat="server" Text='<%#Bind("ServiceDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SR.NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblChallanNo" runat="server" Text='<%#Bind("SRNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="FROM BRANCH">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblFromBranch" runat="server" Text='<%#Bind("FromBranchName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="TO BRANCH">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblToBranch" runat="server" Text='<%#Bind("ToBranchName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DELIVERED BY NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblDeliveryBy" runat="server" Text='<%#Bind("DeliverPersonName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="RECEIVED ?">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblReceivedFlag" runat="server" Text='<%#Bind("REC_FLAG") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="RECEIVED DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblReceivedDate" runat="server" Text='<%# Eval("REC_DATE").ToString() == "01-01-1900 00:00:00" ? "-" : Convert.ToDateTime(Eval("REC_DATE")).ToString("dd-MM-yyyy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="RECEIVED BY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblReceivedBy" runat="server" Text='<%#Bind("REC_USERID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CHECKED BY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="CheckedBy" runat="server" Text='<%#Bind("CheckedPersonName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CHARGES AMT">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblChargesAmt" runat="server" Text='<%#Bind("TOT_CHARGES_AMT") %>'></asp:Label>
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

                    <h4 class="modal-title">DELETE SERIVICE ISSUE TO BRANCH DETAILS</h4>
                </div>
                <div class="modal-body">

                    <span>Are you sure want to delete...!!!</span>
                    <br />

                    <div id="Div5" runat="server" class="grids">

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

                    <h4 class="modal-title">UPDATE STOCK SERIVICE TO BRANCH DETAILS</h4>
                </div>
                <div class="modal-body">


                    <span>Are you sure want to update...!!!</span>
                    <br />

                    <div id="Div6" runat="server" class="grids">

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
