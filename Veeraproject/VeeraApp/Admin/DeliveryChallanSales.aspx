<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="DeliveryChallanSales.aspx.cs" Inherits="VeeraApp.DeliveryChallanSales" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/model.css" rel="stylesheet" />

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




        function movetoNext(current) {

            //   alert(current.value.length);
            if (current.value.length == 10) {
                //eerst de td vinden ipv $(this).next anders werkt het niet
                $(current).next('tr').find('input[type=text]').focus();
            }

            //if (current.value.length >= current.maxLength) {

            //    document.getElementById(nextFieldID).focus();
            //}
        }



        $(document).ready(function () {
            //$('.GvViewBarcode input[type=text]').keyup(function (e) {
            //    //if (e.keyCode == 13) {
            //    alert(this.value.length);
            //    if (this.value.length == 10) {
            //        //eerst de td vinden ipv $(this).next anders werkt het niet
            //        $(this).closest('td').next('td').find('input[type=text]').focus();
            //    }
            //    //} else {
            //    //    return;
            //    //}
            //});
        });




    </script>


   <%-- search & sorting--%>

   
     <%-- search & sorting--%>

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
                    <h4>DELIVERY CHALLAN-SALES</h4>
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

                                    <div class="h5" style="color: brown">Delivery Challan Master</div>

                                    <asp:HiddenField ID="HfDRACODE1" runat="server" />
                                    <asp:HiddenField ID="HfDRACODE2" runat="server" />
                                    <asp:HiddenField ID="HfDRACODE3" runat="server" />
                                    <asp:HiddenField ID="HfCRACODE1" runat="server" />
                                    <asp:HiddenField ID="HfCRACODE2" runat="server" />
                                    <asp:HiddenField ID="HfCRACODE3" runat="server" />


                                    <div style="float: left; height: auto; width: 40%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Challan No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtChallanNo" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server"
                                                            ControlToValidate="TxtChallanNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Challan Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtChallanDate" OnTextChanged="TxtChallanDate_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtValidityDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                          ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtChallanDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderChallanDate" Format="dd-MM-yyyy" TargetControlID="TxtChallanDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Customer Name" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtAccountName" OnTextChanged="TxtAccountName_TextChanged" ForeColor="Blue" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:HiddenField ID="HfACODE" runat="server" />
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtAccountName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" runat="server"
                                                            ControlToValidate="TxtAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="BtnGetCustomerDet" runat="server" Text="Get Customer" OnClick="BtnGetCustomerDet_Click" CausesValidation="false" />
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="GST No." runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtGSTNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" ForeColor="Blue" Text="Party Model Sr.No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtPartyModelSrNo" Width="120px" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                            ControlToValidate="TxtPartyModelSrNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="BtnGetPartyModelSrNo" runat="server" Text="Get Model No" OnClick="BtnGetPartyModelSrNo_Click" CausesValidation="false" />
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:Button ID="BtnPartyModelDetails" runat="server" Text="Model Details" Height="33px" Width="180px" OnClick="BtnPartyModelDetails_Click" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>
                                                    <td style="padding-left: 2px;">
                                                        <asp:Button runat="server" ID="btnRefresh" OnClick="btnRefresh_Click" CausesValidation="false" CssClass="btn_Refresh" />
                                                    </td>

                                                    <td></td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Party Sr No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtPartySrNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Mfg.Sr.No." runat="server"></asp:Label>
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


                                            </table>
                                        </div>
                                    </div>

                                    <div style="float: left; height: auto; width: 35%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="P.O No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtPONumber" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="P.O Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
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
                                                        <asp:Label CssClass="label" Text="Transport" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtTransportName" CssClass="form-control" ForeColor="Blue" runat="server"></asp:TextBox>
                                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtenderDispatcher" runat="server" TargetControlID="TxtTransportName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetTransporterName">
                                                        </ajax:AutoCompleteExtender>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server"
                                                            ControlToValidate="TxtTransportName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Vehicle No." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtVehclieNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:Button ID="BtnDriverDetails" runat="server" Text="Driver Details" Height="33px" Width="180px" OnClick="BtnDriverDetails_Click" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="L.R No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtLRNumber" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="L.R Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtLRDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtValidityDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                              ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <%--  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server"
                                                            ControlToValidate="TxtLRDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderLRDate" Format="dd-MM-yyyy" TargetControlID="TxtLRDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Delivered By" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlDeliveredBy" runat="server" ForeColor="Blue" CssClass="form-control">
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator9" runat="server" InitialValue="0"
                                                            ControlToValidate="DdlDeliveredBy" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                <tr id="divConfirm" runat="server">
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text=" DeliveryConfirm ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlConfirm" OnSelectedIndexChanged="DdlConfirm_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr id="divConfirmBy" runat="server">
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

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Confirm By" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConfirmBy" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Remark" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtRemark" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>


                                            </table>
                                        </div>
                                    </div>


                                    <div style="float: left; height: auto; width: 20%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Party Type" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlPartyType" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                            <asp:ListItem Value="LOCAL">LOCAL</asp:ListItem>
                                                            <asp:ListItem Value="CST">CST</asp:ListItem>
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator8" runat="server" InitialValue="0"
                                                            ControlToValidate="DdlPartyType" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Sales Type" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlSalesType" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                            <asp:ListItem Value="R">Retail Invoice</asp:ListItem>
                                                            <asp:ListItem Value="T">Tax Invoice</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Check Post" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtCheckPost" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Form Sr.No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtFormSrNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Invoice No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtInvoiceNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Invoice Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px; padding-top: 10px;" colspan="3">
                                                        <asp:TextBox ID="TxtInvoiceDate" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Challan Type" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px; padding-top: 10px;">
                                                        <asp:DropDownList ID="DdlChallanType" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                            <asp:ListItem Value="R">Regular</asp:ListItem>
                                                            <asp:ListItem Value="F">FOC</asp:ListItem>
                                                            <asp:ListItem Value="C">Cancel</asp:ListItem>
                                                            <asp:ListItem Value="T">Returndable</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Button runat="server" ID="btnprintchallan" OnClientClick="aspnetForm.target ='_blank';" OnClick="btnprintchallan_Click" Text="View-Challan" />
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
                                    </div>


                                    <div style="width: 45%; height: 65px; float: left;">
                                        <table class="col-md-12">
                                            <tr>
                                                <td style="padding-left: 5px;">
                                                    <asp:Button ID="BtnViewBarcode" runat="server" Text="View Barcode" Width="180px" Height="33px" OnClick="BtnViewBarcode_Click" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                </td>
                                                <td style="padding-left: 5px;">
                                                    <asp:Button ID="BtnAddBarcode" runat="server" Text="Add Barcode" Width="180px" Height="33px" OnClick="BtnAddBarcode_Click" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                </td>
                                                <td style="padding-left: 5px;">
                                                    <asp:Button ID="BtnReturnBarcode" runat="server" Text="Return Barcode" Width="180px" Height="33px" OnClick="BtnReturnBarcode_Click" CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="BtnPartyModelDetails" />
                                    <%-- <asp:AsyncPostBackTrigger ControlID="BtnPartyModelDetails" EventName="click" />--%>
                                </Triggers>
                            </asp:UpdatePanel>



                            <div style="clear: both; height: 10px;">
                            </div>

                            <div id="DivDCItem" runat="server" class="panel panel-widget top-grids">
                                <div class="chute chute-center text-center">

                                    <asp:UpdatePanel ID="UpdPnl2" runat="server">
                                        <ContentTemplate>

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: brown; text-align: left">Barcode Items Details</div>
                                                <asp:GridView ID="GvDCDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvDCDetails_PageIndexChanging" OnRowCommand="GvDCDetails_RowCommand" OnRowDataBound="GvDCDetails_RowDataBound"
                                                    PageSize="10" ShowFooter="true">

                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>


                                                        <%--  <asp:TemplateField HeaderText="SELECT">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkSelectItem" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>

                                                        <asp:TemplateField HeaderText="SR.NO.">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfOrdItem_TransDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfOrdItem_TransNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfOrdItem_SrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />
                                                                <asp:HiddenField ID="HfEntryType" runat="server" Value='<%#Bind("ENTRY_TYPE") %>' />

                                                                <asp:HiddenField ID="HfOrderTranDate" runat="server" Value='<%#Bind("ORD_TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfOrderTranNo" runat="server" Value='<%#Bind("ORD_TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfOrderSrNo" runat="server" Value='<%#Bind("ORD_SRNO") %>' />

                                                                <asp:HiddenField ID="HfGSTAmount" runat="server" Value='<%#Bind("GST_AMT") %>' />
                                                                <asp:HiddenField ID="HfCGSTRate" runat="server" Value='<%#Bind("CGST_RATE") %>' />
                                                                <asp:HiddenField ID="HfCGSTAmount" runat="server" Value='<%#Bind("CGST_AMT") %>' />
                                                                <asp:HiddenField ID="HfSGSTRate" runat="server" Value='<%#Bind("SGST_RATE") %>' />
                                                                <asp:HiddenField ID="HfSGSTAmount" runat="server" Value='<%#Bind("SGST_AMT") %>' />
                                                                <asp:HiddenField ID="HfIGSTRate" runat="server" Value='<%#Bind("IGST_RATE") %>' />
                                                                <asp:HiddenField ID="HfIGSTAmount" runat="server" Value='<%#Bind("IGST_AMT") %>' />

                                                                <asp:HiddenField ID="HfAmount" runat="server" Value='<%#Bind("AMT") %>' />
                                                                <asp:HiddenField ID="HfDisAmount" runat="server" Value='<%#Bind("DIS_AMT") %>' />
                                                                <asp:HiddenField ID="HfGrossAmount" runat="server" Value='<%#Bind("G_AMT") %>' />
                                                                <asp:HiddenField ID="HfTotalAmount" runat="server" Value='<%#Bind("T_AMT") %>' />
                                                                <asp:HiddenField ID="HfStatus" runat="server" Value='<%#Bind("STATUS") %>' />

                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="PRODUCT CODE">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtProductCode" ForeColor="Blue" Style="width: 100px;" runat="server" OnTextChanged="TxtProductCode_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtProductCode"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetProductCode">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="PRODUCT NAME">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtProductName" ForeColor="Blue" Style="width: 350px;" OnTextChanged="TxtProductName_TextChanged" runat="server" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtProductName"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetStockName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="HSN CODE" ControlStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtHsncode" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="ORDER QTY." ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtOrderQty" Style="text-align: right;" runat="server" Text='<%#Bind("ORD_QTY") %>' Enabled="false"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalQty" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RECEIVED QTY." ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" ID="TxtReceivedQty" runat="server" Text='<%#Bind("KEPT_QTY") %>' Enabled="false"></asp:TextBox>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RETURN QTY." ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" ID="TxtReturnQty" runat="server" Text='<%#Bind("REJ_QTY") %>' Enabled="false"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="BALANCE QTY." ControlStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" runat="server" ID="TxtBalQty" Text='<%#Bind("BAL_QTY") %>' Enabled="false"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="ISSUE QTY." ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtRecQty" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("QTY") %>' AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalREC_QTY" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RATE" ControlStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtRate" OnTextChanged="TxtRate_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalRate" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="DIS. %" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtDisc" OnTextChanged="TxtDisc_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("DIS_PER") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="GST %." ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtGstRate" runat="server" Text='<%#Bind("GST_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="BtnDeleteRowModelDC_DetailsGrid" runat="server" OnClick="BtnDeleteRowModelDC_DetailsGrid_Click" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Button ID="BtnAddRowModelDC_DetailsGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelDC_DetailsGrid_Click" CausesValidation="false" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>


                            <div id="DivExtraItem" runat="server" class="panel panel-widget top-grids">
                                <div class="chute chute-center text-center">

                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: brown; text-align: left">Extra Items Details</div>
                                                <asp:GridView ID="GvDCDetailsExStock" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvDCDetailsExStock_PageIndexChanging" OnRowCommand="GvDCDetailsExStock_RowCommand" OnRowDataBound="GvDCDetailsExStock_RowDataBound"
                                                    PageSize="10" ShowFooter="true">

                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="SR.NO.">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfDCTransDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfDCTransNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfDCSrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />
                                                                <asp:HiddenField ID="HfEntryType" runat="server" Value='<%#Bind("ENTRY_TYPE") %>' />

                                                                <asp:HiddenField ID="HfOrderTranDate" runat="server" Value='<%#Bind("ORD_TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfOrderTranNo" runat="server" Value='<%#Bind("ORD_TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfOrderSrNo" runat="server" Value='<%#Bind("ORD_SRNO") %>' />

                                                                <asp:HiddenField ID="HfGSTAmount" runat="server" Value='<%#Bind("GST_AMT") %>' />
                                                                <asp:HiddenField ID="HfCGSTRate" runat="server" Value='<%#Bind("CGST_RATE") %>' />
                                                                <asp:HiddenField ID="HfCGSTAmount" runat="server" Value='<%#Bind("CGST_AMT") %>' />
                                                                <asp:HiddenField ID="HfSGSTRate" runat="server" Value='<%#Bind("SGST_RATE") %>' />
                                                                <asp:HiddenField ID="HfSGSTAmount" runat="server" Value='<%#Bind("SGST_AMT") %>' />
                                                                <asp:HiddenField ID="HfIGSTRate" runat="server" Value='<%#Bind("IGST_RATE") %>' />
                                                                <asp:HiddenField ID="HfIGSTAmount" runat="server" Value='<%#Bind("IGST_AMT") %>' />

                                                                <asp:HiddenField ID="HfAmount" runat="server" Value='<%#Bind("AMT") %>' />
                                                                <asp:HiddenField ID="HfDisAmount" runat="server" Value='<%#Bind("DIS_AMT") %>' />
                                                                <asp:HiddenField ID="HfGrossAmount" runat="server" Value='<%#Bind("G_AMT") %>' />
                                                                <asp:HiddenField ID="HfTotalAmount" runat="server" Value='<%#Bind("T_AMT") %>' />
                                                                <asp:HiddenField ID="HfStatus" runat="server" Value='<%#Bind("STATUS") %>' />

                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="PRODUCT CODE">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtProductCodeEx" ForeColor="Blue" Style="width: 100px;" runat="server" OnTextChanged="TxtProductCodeEx_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtProductCodeEx"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetProductCode">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="PRODUCT NAME">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtProductNameEx" ForeColor="Blue" Style="width: 350px;" runat="server" OnTextChanged="TxtProductNameEx_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtProductNameEx"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetStockName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="EXTRA PRODUCT DESCRIPTION" ControlStyle-Width="400px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtExProductDesc" Text='<%#Bind("PRODUCT_DESC") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="ISSUE QTY." ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtRecQty" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("QTY") %>' OnTextChanged="TxtRecQty_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalEXtraREC_QTY" ForeColor="Red" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RATE" ControlStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" onkeypress="return isNumber(event);" ID="TxtRate" OnTextChanged="TxtRate_TextChanged1" AutoPostBack="true" runat="server" Text='<%#Bind("RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalRate" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="DIS. %" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" ID="TxtDisc" OnTextChanged="TxtDisc_TextChanged1" AutoPostBack="true" runat="server" Text='<%#Bind("DIS_PER") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="GST %." ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" ID="TxtGstRate" runat="server" Text='<%#Bind("GST_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="BtnDeleteRowModelDC_ExStockGrid" runat="server" OnClick="BtnDeleteRowModelDC_ExStockGrid_Click" Text="Remove" Font-Underline="true" CausesValidation="false">Remove</asp:LinkButton>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Button ID="BtnAddRowModelDC_ExStockGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelDC_ExStockGrid_Click" CausesValidation="false" />
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
                                <div class="col-md-1 bs-component mb10">
                                    <asp:Button ID="btnClear" runat="server" Text="EXIT" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnClear_Click"
                                        CausesValidation="false" />
                                </div>
                                <div class="col-md-1 bs-component mb10">
                                    <asp:Button ID="BtncallUpd" Text="UPDATE" runat="server" OnClick="BtncallUpd_Click" CssClass="btn btn-lg btn-primary btn-block" />
                                </div>

                                <div class="col-md-1 bs-component mb10">
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

            <div style="float: right;">
                <asp:Label CssClass="label" Style="color: red;" Text="Challan No./Supplier Name/Delivered Person" runat="server"></asp:Label><br />
                <asp:TextBox ID="TxtSearch" runat="server" Style="width: 100%;" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
        </div>


        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBranchCode" runat="server" />
        <asp:HiddenField ID="HfTranDate" runat="server" />
        <asp:HiddenField ID="HfTranNo" runat="server" />
        <asp:HiddenField ID="HfTranType" runat="server" />
        <asp:HiddenField ID="HfTrnType" runat="server" />
        <asp:HiddenField ID="HfPartRefSrNo" runat="server" />


        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">


                   <div class="table-responsive" style="height: 500px; overflow-y: scroll">
                <div class="table-responsive">
                    <asp:GridView ID="GvDCSalesMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvDCSalesMaster_PageIndexChanging" OnRowCommand="GvDCSalesMaster_RowCommand" OnRowDataBound="GvDCSalesMaster_RowDataBound"
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

                                    <a href="JavaScript:divexpandcollapse('div<%# Eval("TRAN_NO") %>');">
                                        <img id='imgdiv<%# Eval("TRAN_NO") %>' width="15px" border="0" src="/images/plus.gif" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="CHALLAN NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblChallanNo" runat="server" Text='<%#Bind("CHA_NO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CHALLAN DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblChallanDate" runat="server" Text='<%#Bind("ChallanDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CUSTOMER NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblAccountName" runat="server" Text='<%#Bind("AccountName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="DELIVERED BY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblCheckedBy" runat="server" Text='<%#Bind("PersonName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CONFIRM ?">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblCheckedConfirm" runat="server" Text='<%#Bind("CHK_FLAG_Confirm") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CONFIRM DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblConfirmDate" runat="server" Text='<%# Eval("CHK_DATE").ToString() == "01-01-1900 00:00:00" ? "-" : Convert.ToDateTime(Eval("CHK_DATE")).ToString("dd-MM-yyyy") %>'></asp:Label>
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

                                    <tr>
                                        <td colspan="100%">
                                            <div id='div<%#Eval("TRAN_NO") %>' class="table-responsive" style="display: none; background-color: lightgray">
                                                <div style="border: 1px solid red; background: #00bcd4; color: white; padding: 1px; border-radius: 7px;">
                                                    <h4>DELIVERY CHALLAN DETAILS</h4>
                                                </div>


                                                <asp:GridView ID="GvNestedDCDetails" Style="background: #e6ffee;" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvNestedDCDetails_PageIndexChanging"
                                                    PageSize="10">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Sr.No.">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfOrdItem_TransDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfOrdItem_TransNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfOrdItem_SrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />

                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT CODE">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="lable" ID="TxtProductCode" runat="server" Text='<%#Bind("PROD_CODE") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT NAME">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblProductName" CssClass="label" Text='<%#Bind("SNAME") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="HSN CODE">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label" ID="TxtHsncode" runat="server" Text='<%#Bind("HSN_NO") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="REC QTY.">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label" ID="TxtRecQty" runat="server" Text='<%#Bind("QTY") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RATE">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label" ID="TxtRate" runat="server" Text='<%#Bind("RATE") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="DIS. %">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label" ID="TxtDisc" AutoPostBack="true" runat="server" Text='<%#Bind("DIS_PER") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="GST %.">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label" ID="TxtGstRate" runat="server" Text='<%#Bind("GST_RATE") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                    </Columns>
                                                </asp:GridView>


                                                <div style="border: 1px solid red; background: #00bcd4; color: white; padding: 1px; border-radius: 7px;">
                                                    <h4>EXTRA STOCK ITEM DETAILS</h4>
                                                </div>

                                                <asp:GridView ID="GvNestedExtraDCDetails" CssClass="table table-vcenter table-condensed table-bordered" Style="background: #e6ffee;"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvNestedExtraDCDetails_PageIndexChanging"
                                                    PageSize="10">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Sr.No.">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfOrdItem_TransDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfOrdItem_TransNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfOrdItem_SrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />

                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT CODE">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="lable" ID="TxtProductCode" runat="server" Text='<%#Bind("PROD_CODE") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT NAME">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="lblProductName" CssClass="label" Text='<%#Bind("SNAME") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="REC QTY.">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label" ID="TxtRecQty" runat="server" Text='<%#Bind("QTY") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RATE">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label" ID="TxtRate" runat="server" Text='<%#Bind("RATE") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="DIS. %">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label" ID="TxtDisc" AutoPostBack="true" runat="server" Text='<%#Bind("DIS_PER") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="GST %.">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label" ID="TxtGstRate" runat="server" Text='<%#Bind("GST_RATE") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                    </Columns>
                                                </asp:GridView>

                                            </div>
                                        </td>
                                    </tr>

                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
                 </div>
            </div>
        </div>



    </div>


    <%--<script src="js/proton.js"></script>--%>

    <div class="modal fade" tabindex="-1" id="CmpDeleteSelection" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">DELETE SALES DELIVERY CHALLAN DETAIL</h4>
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

    <%--<script src="js/proton.js"></script>--%>

    <div class="modal fade" tabindex="-1" id="CmpUpdateSelection" data-keyboard="false" data-backdrop="static">

        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">UPDATE SALES DELIVERY CHALLAN DETAIL</h4>
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


   <%-- <script src="js/proton.js"></script>--%>

    <div class="modalquo fade" tabindex="-1" id="CmpSelectCustomer" data-keyboard="false" data-backdrop="static">
        <div class="modalquo-dialog modal-lg">
            <div class="modalquo-content">
                <div class="modalquo-header">
                    <h4 class="modalquo-title" style="color: red">Customer Details</h4>
                </div>

                <div class="modalquo-body">
                    <div id="Div1" runat="server" class="grids">
                        <div class="panel panel-widget top-grids">

                            <asp:UpdatePanel ID="UpCustomerDetails" runat="server">
                                <ContentTemplate>
                                    Find
                                  <asp:TextBox ID="TxtSearchCustomerName" CssClass="form-control" runat="server"></asp:TextBox>

                                    <asp:GridView ID="GvCustomerDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvCustomerDetails_PageIndexChanging" OnRowCommand="GvCustomerDetails_RowCommand"
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
                                                    <asp:HiddenField ID="HfCompCodeCust" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                    <asp:HiddenField ID="HfBranchCodeCust" runat="server" Value='<%#Bind("BRANCH_CODE") %>' />

                                                    <asp:Button ID="btnSelect" OnClick="btnSelect_Click" runat="server" CausesValidation="false" CommandName="Selecta" CommandArgument='<%#Bind("ACODE") %>' ToolTip="View" Text="SELECT" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Name of Accounts">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblAccountName" runat="server" Text='<%#Bind("ANAME") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Address">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblAddress" runat="server" Text='<%#Bind("ADD1") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Account Group Name">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblGroupName" runat="server" Text='<%#Bind("GROUP_NAME") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
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
        function HideModelCustomerDetail() {
            $("#CmpSelectCustomer").modal('hide');
        }

        function ShowModelCustomerDetail() {

            $("#CmpSelectCustomer").modal('show');

        }

    </script>


   <%-- <script src="js/proton.js"></script>--%>

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
                                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvPartyModelSrNo_PageIndexChanging" OnRowCommand="GvPartyModelSrNo_RowCommand"
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



    <%--<script src="js/proton.js"></script>--%>


    <div class="modal fade" tabindex="-1" id="CmpDriverDetails" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" style="color: red">Driver Details</h4>
                </div>

                <div class="modal-body">
                    <div id="Div7" runat="server" class="grids">
                        <div class="panel panel-widget top-grids">


                            <table style="width: 80%;" border="0">
                                <tr>
                                    <td align="right" style="padding-bottom: 10px;">
                                        <asp:Label CssClass="label" Text="Driver Name" runat="server"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-left: 10px;">
                                        <asp:TextBox ID="TxtDriverName" CssClass="form-control" runat="server"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="right" style="padding-bottom: 10px;">
                                        <asp:Label CssClass="label" Text=" Driver Address" runat="server"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-left: 10px;">
                                        <asp:TextBox ID="TxtDriverAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="right" style="padding-bottom: 10px;">
                                        <asp:Label CssClass="label" Text="M.D.L No." runat="server"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-left: 10px;">
                                        <asp:TextBox ID="TxtMDLNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="right" style="padding-bottom: 10px;">` 
                                                <asp:Label CssClass="label" Text="Issuing Authority State" runat="server"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-left: 10px;">
                                        <asp:TextBox ID="TxtMDLState" CssClass="form-control" runat="server"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                        <button type="button" style="float: right;" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK</button>
                                    </td>
                                </tr>
                            </table>


                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>



    <script type="text/javascript">
        function HideModelDriverDetails() {
            $("#CmpDriverDetails").modal('hide');
        }

        function ShowModelDriverDetails() {

            $("#CmpDriverDetails").modal('show');

        }

    </script>



   <%-- <script src="js/proton.js"></script>--%>

    <div class="modal fade" tabindex="-1" id="CmpViewBarcode" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" style="color: blue">Barcode Details</h4>

                </div>

                <div class="modal-body">
                    <div id="Div4" runat="server" class="grids">
                        <div class="panel panel-widget top-grids">
                            <asp:UpdatePanel ID="UpdateBarcode" runat="server">
                                <ContentTemplate>

                                    <div class="table-responsive" style="height: 400px; overflow-y: scroll">

                                        <asp:Label ID="lblbarduperror" runat="server" ForeColor="Red"></asp:Label>
                                        <div id="DivBarcodeInput" runat="server">
                                            <span style="padding-right: 5px;">Enter No.of Rows Required</span><asp:TextBox ID="TxtBarcodeInputNo" runat="server" OnTextChanged="TxtBarcodeInputNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        </div>
                                        <asp:GridView ID="GvViewBarcode" CssClass="table table-vcenter table-condensed table-bordered"
                                            runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                            PageSize="10" ShowFooter="true">
                                            <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                            <Columns>

                                                <asp:TemplateField HeaderText="Sr.No.">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="HfStockcode" runat="server" Value='<%#Bind("SCODE") %>' />
                                                        <asp:HiddenField ID="HfBarTranDate" runat="server" Value='<%#Bind("BAR_TRAN_DATE") %>' />
                                                        <asp:HiddenField ID="HfBarTranNo" runat="server" Value='<%#Bind("BAR_TRAN_NO") %>' />
                                                        <asp:HiddenField ID="HfBarSrNo" runat="server" Value='<%#Bind("BAR_SRNO") %>' />
                                                        <%#Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Barcode">
                                                    <ItemTemplate>
                                                        <asp:TextBox CssClass="form-control" ID="TxtBarcode" OnTextChanged="TxtBarcode_TextChanged" TabIndex="<%#((GridViewRow)Container).RowIndex %>"  MaxLength="10" AutoPostBack="true" runat="server" Text='<%#Bind("BARRCODE") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Qty.">
                                                    <ItemTemplate>
                                                        <asp:TextBox CssClass="form-control" ID="TxtQty" runat="server" Text='<%#Bind("QTY") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <FooterTemplate>
                                                        <asp:Button ID="BtnAddRowModelBarCode_ViewGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelBarCode_ViewGrid_Click" CausesValidation="false" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>


                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                    <asp:Button ID="btnAddBarcodeProcess" runat="server" Text="Add Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnAddBarcodeProcess_Click" CausesValidation="false" />
                                    <asp:Button ID="btnUploadBarcodeProcess" runat="server" Text="Upload Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnUploadBarcodeProcess_Click" CausesValidation="false" />
                                    <asp:Button ID="btnReturnBarcodeProcess" runat="server" Text="Return Process" CssClass="btn btn-lg btn-primary" Width="200px" Height="35px" OnClick="btnReturnBarcodeProcess_Click" CausesValidation="false" />

                                    <button type="button" class="btn btn-primary" style="float: right;" data-dismiss="modal" value="NO">BACK </button>


                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="BtnViewBarcode" EventName="click" />
                                    <asp:AsyncPostBackTrigger ControlID="BtnAddBarcode" EventName="click" />
                                    <asp:AsyncPostBackTrigger ControlID="BtnReturnBarcode" EventName="click" />
                                    <%--<asp:AsyncPostBackTrigger ControlID="btnUploadBarcodeProcess" EventName="click" />--%>
                                    <asp:PostBackTrigger ControlID="btnUploadBarcodeProcess" />
                                </Triggers>
                            </asp:UpdatePanel>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        function HideModelViewBarcode() {
            $("#CmpViewBarcode").modal('hide');
        }

        function ShowModelViewBarcode() {

            $("#CmpViewBarcode").modal('show');

        }

    </script>



    <%-- <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0-beta/css/bootstrap.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.16/css/dataTables.bootstrap4.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/responsive/2.1.1/css/responsive.bootstrap4.min.css" />--%>

    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.16/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://cdn.datatables.net/responsive/2.1.1/js/dataTables.responsive.min.js"></script>
    <script src="https://cdn.datatables.net/responsive/2.1.1/js/responsive.bootstrap4.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id$=GvDCSalesMaster]').prepend($("<thead></thead>").append($('[id$=GvDCSalesMaster]').find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>

</asp:Content>
