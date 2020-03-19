<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="AccountMaster.aspx.cs" Inherits="VeeraApp.Admin.AccountMaster" %>

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
        <%--<div class="forms">
            <div class="form-three widget-shadow">
                <div data-example-id="form-validation-states-with-icons">

                    <span class="glyphicon glyphicon-ok form-control-feedback" aria-hidden="true"></span><span id="inputGroupSuccess1Status" class="sr-only"><asp:Label CssClass="label"  ID="lblmsg" runat="server"></asp:Label></span>
                </div>

            </div>
        </div>--%>
    </div>
    <div style="clear: both; height: 10px">
    </div>

    <div class="grids">
    </div>
    <div class="panel panel-widget forms-panel">
        <div class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title">
                    <h4>ACCOUNTS MASTER</h4>
                </div>
            </div>
        </div>
    </div>

    <div style="clear: both; height: 10px">
    </div>

    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">

                            <div class="col-md-12">
                                <%-- <div class="col-md-2">
                                    <asp:textbox id="TxtAccountCode" cssclass="form-control" runat="server" placeholder="BRANCH CODE"></asp:textbox>
                                    <asp:requiredfieldvalidator display="Dynamic" id="RequireTxtAccountCode" runat="server"
                                        controltovalidate="TxtAccountCode" forecolor="Red">*</asp:requiredfieldvalidator
                                </div>--%>

                                <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Name of the Accounts" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtAccountName" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtAccountName" runat="server"
                                        ControlToValidate="TxtAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="Short" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtAccountShort" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtAccountShort" runat="server"
                                        ControlToValidate="TxtAccountShort" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Accounts Group Name" ForeColor="Blue" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlAccountGroupName" runat="server" ForeColor="Blue" CssClass="form-control">
                                    </asp:DropDownList>

                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" InitialValue="0"
                                        ControlToValidate="DdlAccountGroupName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-1">
                                    <asp:Label CssClass="label" Text="Profit/Loss(%)" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtProLossPer" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanelBranch" runat="server">
                                    <ContentTemplate>

                                        <%--   <div class="col-md-2">
                                    <asp:Label CssClass="label"  Text="Company Name" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlCompany" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlCompany_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>  --%>
                                        <div class="col-md-3">
                                            <asp:Label CssClass="label" Text="Branch Name" runat="server"></asp:Label>
                                            <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" InitialValue="0"
                                                ControlToValidate="DdlBranch" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>

                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div style="clear: both; height: 10px">
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>

                                        <div class="col-md-12">
                                            <div class="col-md-3">
                                                <asp:HiddenField ID="HfPlaceCode" runat="server" />
                                                <asp:Label CssClass="label" Text="Place Name" ForeColor="Blue" runat="server"></asp:Label>
                                                <asp:DropDownList ID="DdlPlaceName" runat="server" ForeColor="Blue" CssClass="form-control" OnSelectedIndexChanged="DdlPlaceName_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                              <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" InitialValue="0"
                                                    ControlToValidate="DdlPlaceName" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label CssClass="label" Text="Route Name" runat="server"></asp:Label>
                                                <asp:TextBox ID="TxtRouteName" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="col-md-3">
                                                <asp:Label CssClass="label" Text="GPS Name" runat="server"></asp:Label>
                                                <asp:TextBox ID="TxtGpsLocation" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label CssClass="label" Text="Vendor Code" runat="server"></asp:Label>
                                                <asp:TextBox ID="TxtVendorCode" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div style="clear: both; height: 10px">
                                </div>

                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Marketing Person Name" ForeColor="Blue" runat="server"></asp:Label>
                                        <asp:DropDownList ID="DdlMrkgPersonName" runat="server" ForeColor="Blue" CssClass="form-control">
                                        </asp:DropDownList>
                                      <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server" InitialValue="0"
                                            ControlToValidate="DdlMrkgPersonName" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Payment Person Name" ForeColor="Blue" runat="server"></asp:Label>
                                        <asp:DropDownList ID="DdlPaymentPersonName" runat="server" ForeColor="Blue" CssClass="form-control">
                                        </asp:DropDownList>
                                      <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server" InitialValue="0"
                                            ControlToValidate="DdlPaymentPersonName" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Service Person Name" ForeColor="Blue" runat="server"></asp:Label>
                                        <asp:DropDownList ID="DdlServicePersonName" runat="server" ForeColor="Blue" CssClass="form-control">
                                        </asp:DropDownList>
                                       <%-- <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server" InitialValue="0"
                                            ControlToValidate="DdlServicePersonName" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Contact Person" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtContactPersonName" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px">
                                </div>

                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Address1" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtAddress1" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Address2" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtAddress2" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Address3" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtAddress3" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="City" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtCity" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px">
                                </div>

                                <asp:UpdatePanel ID="upd" runat="server">
                                    <ContentTemplate>



                                        <div class="col-md-12">
                                            <div class="col-md-3">
                                                <asp:HiddenField ID="HfStateCode" runat="server" />
                                                <asp:Label CssClass="label" Text="State Name" ForeColor="Blue" runat="server"></asp:Label>
                                                <asp:DropDownList ID="DdlStateName" AutoPostBack="true" ForeColor="Blue" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" runat="server" InitialValue="0"
                                                    ControlToValidate="DdlStateName" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label CssClass="label" Text="State Code" runat="server"></asp:Label>
                                                <asp:TextBox ID="TxtStateCode" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label CssClass="label" Text="Country" runat="server"></asp:Label>
                                                <asp:TextBox ID="TxtCountry" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label CssClass="label" Text="Phone(O)" runat="server"></asp:Label>
                                                <asp:TextBox ID="TxtPhoneO" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div style="clear: both; height: 10px">
                                </div>

                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Phone(M)" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtPhoneM" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Fax" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtFax" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Email" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server"></asp:TextBox>

                                        <asp:RequiredFieldValidator ID="RequiredFieldEmail" runat="server" ErrorMessage="*" ControlToValidate="TxtEmail"
                                            ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Please Enter Valid Email ID"
                                            ControlToValidate="TxtEmail"
                                            CssClass="requiredFieldValidateStyle" ForeColor="Red"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                        </asp:RegularExpressionValidator>

                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="GST No." runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtGstNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px">
                                </div>

                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Party Type" runat="server"></asp:Label>
                                        <asp:DropDownList ID="DdlPartyType" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                            <asp:ListItem Value="C">CST</asp:ListItem>
                                            <asp:ListItem Value="L">LOCAL</asp:ListItem>
                                            <asp:ListItem Value="I">IMPORT</asp:ListItem>
                                            <asp:ListItem Value="E">EXPORT</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Sales Type" runat="server"></asp:Label>
                                        <asp:DropDownList ID="DdlSalesType" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                            <asp:ListItem Value="R">Retail Invoice</asp:ListItem>
                                            <asp:ListItem Value="T">Tax Invoice</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Register/CST Type" runat="server"></asp:Label>
                                        <asp:DropDownList ID="DdlRegisterCstType" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                            <asp:ListItem Value="A">Against C Form</asp:ListItem>
                                            <asp:ListItem Value="W">Without C Form</asp:ListItem>
                                            <asp:ListItem Value="R">Register Dealer</asp:ListItem>
                                            <asp:ListItem Value="U">Un-Register Dealer</asp:ListItem>
                                            <asp:ListItem Value="B">Bill of Supply</asp:ListItem>
                                            <asp:ListItem Value="N">Non URD</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Business Type" runat="server"></asp:Label>
                                        <asp:DropDownList ID="DdlBusinessType" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                            <asp:ListItem Value="D">Dealer</asp:ListItem>
                                            <asp:ListItem Value="M">Manufecturer</asp:ListItem>
                                            <asp:ListItem Value="T">Traders</asp:ListItem>
                                            <asp:ListItem Value="C">Customer</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px">
                                </div>


                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="VAT TIN No." runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtVatTinNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="W.E.F Date" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtVatTinDate" CssClass="form-control" runat="server"></asp:TextBox>

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtVatTinDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                            ErrorMessage="INVALID DATE" ForeColor="Red" />
                                        <ajax:CalendarExtender runat="server" ID="CalendarID1" Format="dd-MM-yyyy" TargetControlID="TxtVatTinDate"></ajax:CalendarExtender>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="VAT CST No." runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtVatCstNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="W.E.F Date" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtVatCstDate" CssClass="form-control" runat="server"></asp:TextBox>

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ControlToValidate="TxtVatCstDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                            ErrorMessage="INVALID DATE" ForeColor="Red" />
                                        <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtVatCstDate"></ajax:CalendarExtender>
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px">
                                </div>

                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Credit Amount" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtCreditAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Credit Days" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtCreditDays" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="ECC No." runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtEccNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="PAN No." runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtPanNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px">
                                </div>

                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Stax No." runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtStaxNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Bank Name" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtBankName" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Branch Name" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtBankBranchName" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="IFSC Code" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtIfscCode" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px">
                                </div>

                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Micro Code" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtMicroCode" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Bank Account No." runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtBankAccountNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label CssClass="label" Text="Cheque Report Name" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtChequeReportName" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label CssClass="label" Text="A/C Details Completed?" runat="server"></asp:Label>
                                        <asp:DropDownList ID="DdlACDetailsConfirm" runat="server" CssClass="form-control">           
                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label CssClass="label" Text="Service Details Completed?" runat="server"></asp:Label>
                                        <asp:DropDownList ID="DdlServiceDetailsConfirm" runat="server" CssClass="form-control">       
                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>


                                <div style="clear: both; height: 10px">
                                </div>

                                <div class="col-md-12">
                                    <div class="col-md-3 bs-component mb10">
                                        <asp:Button ID="BtnHODetails" runat="server" Text="HO Details" OnClick="BtnHODetails_Click" CausesValidation="false" CssClass="btn btn-lg btn-primary btn-block" />
                                    </div>
                                    <div class="col-md-3 bs-component mb10">
                                        <asp:Button ID="BtnContactDetail" runat="server" Text="Contact Details" OnClick="BtnContactDetail_Click" CssClass="btn btn-lg btn-primary btn-block" CausesValidation="false" />
                                    </div>
                                    <div class="col-md-3 bs-component mb10">
                                        <asp:Button ID="BtnModalDetails" runat="server" Text="Model Details" OnClick="BtnModalDetails_Click" CssClass="btn btn-lg btn-primary btn-block" />
                                    </div>
                                    <div class="col-md-3 bs-component mb10">
                                        <asp:Button ID="BtnExportAccount" runat="server" Text="Export Account" OnClick="BtnExportAccount_Click" CssClass="btn btn-lg btn-primary btn-block" />
                                    </div>
                                </div>

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
                <asp:Button ID="BtnAdd" runat="server" Text="NEW" OnClick="BtnAdd_Click" CausesValidation="false" CssClass="btn btn-lg btn-primary" />
                <asp:Button runat="server" ID="btnExit" Text="Exit" OnClick="btnExit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />

              <div style="float:right;">
             <asp:Label CssClass="label" style="color:red;" Text="Search By Account Name/GST No." runat="server"></asp:Label><br />
              <asp:TextBox ID="TxtSearch"  AutoCompleteType="Disabled" runat="server" style="width: 100%;" OnTextChanged="TxtSearch_OnTextChanged" AutoPostBack="true"></asp:TextBox>
            </div>

            </div>
          <%--  <div class="col-md-3">
                <asp:Label CssClass="label" Text="Search By Account Name/GST No." runat="server"></asp:Label>
                <asp:TextBox ID="TxtSearch" CssClass="form-control" runat="server" OnTextChanged="TxtSearch_OnTextChanged" AutoPostBack="true"></asp:TextBox>
            </div>--%>

            <div style="clear: both; height: 10px"></div>
            <asp:HiddenField ID="hfACC_CODE" runat="server" />
            <asp:HiddenField ID="hfCOMP_CODE" runat="server" />
          <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                <ContentTemplate>--%>




                    <%-- <div class="progressbar-heading grids-heading">
                    <h4>ACCOUNTS LIST</h4>
                </div>--%>


                    <div class="panel panel-widget top-grids">
                        <div class="chute chute-center text-center">

                            <div class="table-responsive">
                            <%--    <table class="table table-vcenter table-condensed table-bordered">
                                    <tr>
                                        <td>
                                            <span>Action</span> 
                                        </td>
                                        <td>
                                            <span>NAME OF THE ACCOUNTS</span> <br />
                                             <asp:TextBox runat="server" CssClass="srcbox" ClientIDMode="Static" OnTextChanged="TxtSrcAname_TextChanged" ID="TxtSrcAname" AutoPostBack="true"></asp:TextBox>                                                
                                        </td>
                                         <td>
                                            <span>NAME OF THE ACCOUNTS GROUP</span> 
                                        </td>
                                         <td>
                                            <span>GST NO.</span> 
                                        </td>
                                         <td>
                                            <span>CREATED BY</span> 
                                        </td>
                                         <td>
                                            <span>CREATED DATE</span> 
                                        </td>
                                         <td>
                                            <span>UPDATED BY</span> 
                                        </td>
                                         <td>
                                            <span>UPDATED DATE</span> 
                                        </td>
                                    </tr>
                                </table>--%>

                               <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                                <asp:GridView ID="GvAccount" ShowHeader="true" CssClass="table table-vcenter table-condensed table-bordered"
                                    runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvAccount_PageIndexChanging"
                                    OnRowCommand="GvAccount_RowCommand" PageSize="10">
                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="HfACC_CODE" runat="server" Value='<%#Bind("ACODE")%>' />

                                                <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("ACODE") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                                <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("ACODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                                <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("ACODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <%--<asp:TemplateField HeaderText="SR.NO.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                            </asp:TemplateField> --%>
                                        <asp:TemplateField HeaderText="NAME OF THE ACCOUNTS">
                                            <HeaderTemplate>
                                                <span>NAME OF THE ACCOUNTS</span><br />
                                                <asp:TextBox runat="server" CssClass="srcbox" ClientIDMode="Static" OnTextChanged="TxtSrcAname_TextChanged" ID="TxtSrcAname" AutoPostBack="true"></asp:TextBox> 
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label CssClass="label grdleftalign" ID="lblAccountName" runat="server" Text='<%#Bind("ANAME") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="NAME OF THE ACCOUNTS GROUP">
                                            <ItemTemplate>
                                                <asp:Label CssClass="label grdleftalign" ID="lblAccountsGroupName" runat="server" Text='<%#Bind("AccountGroupName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="GST NO.">
                                            <ItemTemplate>
                                                <asp:Label CssClass="label grdleftalign" ID="lblGSTNo" runat="server" Text='<%#Bind("GST_NO") %>'></asp:Label>
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

                                    </Columns>

                                </asp:GridView>
                            </div>
                        </div>
                     </div>
                    </div>
               <%-- </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TxtSearch"/>
                      <asp:AsyncPostBackTrigger ControlID="GvAccount"/>
                   <asp:AsyncPostBackTrigger ControlID="TxtSearch"/>
                     <asp:AsyncPostBackTrigger ControlID="TxtSearch"/>
                </Triggers>
            </asp:UpdatePanel>--%>

        </div>

        <script src="js/proton.js"></script>


        <div class="modal fade" tabindex="-1" id="CmpHoDetails" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title">HO Details</h4>
                    </div>
                    <div class="modal-body">

                        <div id="Div1" runat="server" class="grids">

                            <div class="panel panel-widget top-grids">
                                Conatct Person 
                            <asp:TextBox ID="TxtHoContactPerson" CssClass="form-control" runat="server"></asp:TextBox>
                                Address  
                            <asp:TextBox ID="TxtHoAddress1" CssClass="form-control" runat="server"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="TxtHoAddress2" CssClass="form-control" runat="server"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="TxtHoAddress3" CssClass="form-control" runat="server"></asp:TextBox>
                                Phone(O)  
                            <asp:TextBox ID="TxtHoPhoneO" CssClass="form-control" runat="server"></asp:TextBox>
                                Phone(M)  
                            <asp:TextBox ID="TxtHoPhoneM" CssClass="form-control" runat="server"></asp:TextBox>
                                Fax       
                            <asp:TextBox ID="TxtHoFax" CssClass="form-control" runat="server"></asp:TextBox>
                                Email     
                            <asp:TextBox ID="TxtHoEmail" CssClass="form-control" runat="server"></asp:TextBox>

                                <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            function HideModelHo() {
                $("#CmpHoDetails").modal('hide');
            }

            function ShowModelHo() {

                $("#CmpHoDetails").modal('show');

            }
        </script>


        <script src="js/proton.js"></script>


        <div class="modal fade" tabindex="-1" id="CmpExportAccount" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title">Export Account</h4>
                    </div>
                    <div class="modal-body">

                        <div id="Div4" runat="server" class="grids">

                            <div class="panel panel-widget top-grids">
                                <asp:UpdatePanel ID="updexportacc" runat="server">
                                    <ContentTemplate>
                                        To Company Name 
                            <asp:DropDownList ID="DdlToCompanyExport" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlToCompanyExport_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>


                                        To Branch Name
                            <asp:DropDownList ID="DdlToBranchExport" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0"></asp:ListItem>
                            </asp:DropDownList>

                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <br />

                                <asp:Button ID="BtnExportAcc" runat="server" Text="Export Account" CssClass="btn btn-lg btn-primary" Width="200px" OnClick="BtnExportAcc_Click" CausesValidation="false" />
                                <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            function HideModelExportAcc() {
                $("#CmpExportAccount").modal('hide');
            }

            function ShowModelExportAcc() {

                $("#CmpExportAccount").modal('show');

            }
        </script>

        <script src="js/proton.js"></script>


        <div class="modal fade" tabindex="-1" id="CmpBranchSelection" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title">DELETE ACCOUNT</h4>
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
                $("#CmpBranchSelection").modal('hide');
            }

            function ShowModel() {

                $("#CmpBranchSelection").modal('show');

            }
        </script>

        <script src="js/proton.js"></script>


        <div class="modal fade" tabindex="-1" id="CmpBranchSelection1" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title">UPDATE ACCOUNT</h4>
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
                $("#CmpBranchSelection1").modal('hide');
            }

            function ShowModel1() {

                $("#CmpBranchSelection1").modal('show');

            }
        </script>
</asp:Content>
