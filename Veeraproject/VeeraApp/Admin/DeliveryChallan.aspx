<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="DeliveryChallan.aspx.cs" Inherits="VeeraApp.DeliveryChallan" %>

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
                    <h4>GRN PURCHASE</h4>
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


                                    <div style="float: left; height: auto; width: 40%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" class="col-md-3" Text="GRN No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtSerialNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Received Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtReceivedDate" OnTextChanged="TxtReceivedDate_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtValidityDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                                    ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server"
                                                            ControlToValidate="TxtReceivedDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarRec_Date" Format="dd-MM-yyyy" TargetControlID="TxtReceivedDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>


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
                                                        <asp:TextBox ID="TxtChallanDate" CssClass="form-control" runat="server"></asp:TextBox>

                                                        <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtValidityDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                          ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="TxtChallanDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderChallanDate" Format="dd-MM-yyyy" TargetControlID="TxtChallanDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Supplier Name" ForeColor="Blue" runat="server"></asp:Label>
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
                                                        <asp:Label CssClass="label" Text="Remarks" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtRemarks" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td></td>
                                                    <td>
                                                        <asp:Button ID="BtnSelectPO" runat="server" Text="SELECT P.O." CssClass="btn btn-lg btn-primary" Height="33px" CausesValidation="false" OnClick="BtnSelectPO_Click" Width="150px" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="BtnPOProcess" runat="server" Text="P.O. Process" CssClass="btn btn-lg btn-primary" Height="33px" CausesValidation="false" OnClick="BtnPOProcess_Click" Width="150px" />
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
                                    </div>


                                    <div style="float: left; height: auto; width: 40%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
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

                                                        <%-- <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server"
                                                            ControlToValidate="TxtLRDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                        <ajax:CalendarExtender runat="server" ID="CalendarExtenderLRDate" Format="dd-MM-yyyy" TargetControlID="TxtLRDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Checked By" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlCheckedBy" runat="server" ForeColor="Blue" CssClass="form-control">
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator9" runat="server" InitialValue="0"
                                                            ControlToValidate="DdlCheckedBy" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
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

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Confirm By" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtConfirmBy" CssClass="form-control" runat="server"></asp:TextBox>
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
                                                        <asp:Label CssClass="label" Text="Sr No." runat="server"></asp:Label>
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

                                                        <%--    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtValidityDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                      ErrorMessage="INVALID DATE" ForeColor="Red" />

                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                              ControlToValidate="TxtInvoiceDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                       <ajax:CalendarExtender runat="server" ID="CalendarExtenderInvoiceDate" Format="dd-MM-yyyy" TargetControlID="TxtInvoiceDate"></ajax:CalendarExtender>--%>
                                                    </td>
                                                </tr>
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
                                                    <td colspan="2">
                                                        <asp:Button runat="server" ID="btnprintchallan" OnClick="btnprintchallan_Click" Text="View-Challan"   OnClientClick="aspnetForm.target ='_blank';"/>
                                                        <asp:Button runat="server" ID="btnbarcodeprint" OnClick="btnbarcodeprint_Click" OnClientClick="target ='_blank';" Text="Barcode Print" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>


                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div style="clear: both; height: 10px;">
                            </div>


                            <div id="DivQuoteItem" runat="server" class="panel panel-widget top-grids">
                                <div class="chute chute-center text-center">

                                    <asp:UpdatePanel ID="UpdPnl2" runat="server">
                                        <ContentTemplate>

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: brown; text-align: left">DC Details</div>
                                                <asp:GridView ID="GvDCDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvDCDetails_PageIndexChanging1" OnRowCommand="GvDCDetails_RowCommand" OnRowDataBound="GvDCDetails_RowDataBound1"
                                                    PageSize="10" ShowFooter="true">

                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>


                                                        <asp:TemplateField HeaderText="SELECT">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkSelectItem" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="SR.NO.">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfOrdItem_TransDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                <asp:HiddenField ID="HfOrdItem_TransNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                <asp:HiddenField ID="HfOrdItem_SrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />

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
                                                                <asp:TextBox ID="TxtProductName" ForeColor="Blue" Style="width: 300px;" runat="server" OnTextChanged="TxtProductName_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtProductName"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetStockName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT NAME" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:DropDownList runat="server" ID="DdlProductName" OnSelectedIndexChanged="DdlProductName_SelectedIndexChanged1" AutoPostBack="true"></asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="HSN CODE" ControlStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtHsncode" Enabled="false" runat="server"></asp:TextBox>
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

                                                        <asp:TemplateField HeaderText="REC QTY." ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" ID="TxtRecQty" Enabled='<%# Eval("STATUS").ToString().Equals("O") ? true : false  %>' onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("QTY") %>' OnTextChanged="TxtRecQty_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
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
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" ID="TxtDisc" OnTextChanged="TxtDisc_TextChanged" AutoPostBack="true" runat="server" Text='<%#Bind("DIS_PER") %>'></asp:TextBox>
                                                                <%--<asp:RangeValidator runat="server" ID="RangeDis" />--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="GST %." ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdrightalign" Style="text-align: right;" ID="TxtGstRate" runat="server" Text='<%#Bind("GST_RATE") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="BARCODE" ControlStyle-Width="70px">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnBarcode" runat="server" CausesValidation="false" CommandName="ViewBarcode" CommandArgument='<%#Bind("SRNO") %>' ToolTip="View Barcode" Text="VIEW" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
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

                            <div style="clear: both; height: 10px">
                            </div>

                            <asp:UpdatePanel ID="updpanel" runat="server">
                                <ContentTemplate>

                                    <div id="DivChargesDetails" runat="server" style="height: 250px;" class="panel panel-widget top-grids">
                                        <div class="chute chute-center text-center">
                                            <div class="h5" style="color: brown; text-align: left">Charges Details</div>


                                            <div style="float: left; height: auto; width: 50%;">
                                                <div class="col-md-12">
                                                    <table class="col-md-12">
                                                        <tr>
                                                            <td align="right" style="padding-bottom: 10px;">
                                                                <asp:Label CssClass="label" Text="Expense A/C Name-1" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="padding-left: 10px;">
                                                                <asp:DropDownList ID="DdlCreditExpenseACName1" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </td>

                                                            <td align="right" style="padding-bottom: 10px;">
                                                                <asp:Label CssClass="label" Text="Charges Amt." runat="server"></asp:Label>
                                                            </td>
                                                            <td style="padding-left: 10px;">
                                                                <asp:TextBox ID="TxtChargesAmt1" Style="text-align: right;" OnTextChanged="TxtChargesAmt1_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td align="right" style="padding-bottom: 10px;">
                                                                <asp:Label CssClass="label" Text="Expense A/C Name-2" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="padding-left: 10px;">
                                                                <asp:DropDownList ID="DdlCreditExpenseACName2" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right" style="padding-bottom: 10px;">
                                                                <asp:Label CssClass="label" Text="Charges Amt." runat="server"></asp:Label>
                                                            </td>
                                                            <td style="padding-left: 10px;">
                                                                <asp:TextBox ID="TxtChargesAmt2" Style="text-align: right;" OnTextChanged="TxtChargesAmt2_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td></td>
                                                            <td></td>
                                                            <td align="right" style="padding-bottom: 10px;">
                                                                <asp:Label Style="color: red; text-align: left" Text="Total Charges Amt." runat="server"></asp:Label>
                                                            </td>
                                                            <td style="padding-left: 10px;">
                                                                <asp:TextBox ID="TxtChargesTotalAmt" ForeColor="Red" Style="text-align: right;" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr id="DivCreditACExpence3" runat="server">
                                                            <td>
                                                                <asp:Label CssClass="label" Text="Expense A/C Name-3" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DdlCreditExpenseACName3" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:Label CssClass="label" Text="Charges Amt." runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TxtChargesAmt3" Style="text-align: right;" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>



                                            <%--  <div class="col-md-12" runat="server" id="DivCreditACExpence3">
                                                <div class="col-md-4">
                                                    <asp:Label CssClass="label" Text="Expense A/C Name-3" runat="server"></asp:Label>
                                                   
                                                </div>
                                                <div class="col-md-2">
                                                    <asp:Label CssClass="label" Text="Charges Amt." runat="server"></asp:Label>
                                                  
                                                </div>
                                            </div>--%>
                                        </div>
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


    <div id="DivView" runat="server" class="grids">

        <div class="panel panel-widget top-grids">
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />

            <div style="float: right;">
                <asp:Label CssClass="label" Style="color: red;" Text="Search By GRN No./Challan No./Supplier Name/Ckecked Person" runat="server"></asp:Label><br />
                <asp:TextBox ID="TxtSearch" runat="server" Style="width: 100%;" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
        </div>

        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBranchCode" runat="server" />
        <asp:HiddenField ID="HfTranDate" runat="server" />
        <asp:HiddenField ID="HfTranNo" runat="server" />
        <asp:HiddenField ID="HfTranType" runat="server" />
        <asp:HiddenField ID="HfTrnType" runat="server" />
        <asp:HiddenField ID="HfRefTranNo" runat="server" />
        <asp:HiddenField ID="HfRefTranDate" runat="server" />
        <asp:HiddenField ID="HfRowCommandFlag" runat="server" />



        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">


                 <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvDC_Master" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvDC_Master_PageIndexChanging" OnRowCommand="GvDC_Master_RowCommand"
                        OnRowDataBound="GvDC_Master_RowDataBound"
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

                            <asp:TemplateField HeaderText="GRN NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblGRNNo" runat="server" Text='<%#Bind("SERIALNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="RECEIVED DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblReceivedDate" runat="server" Text='<%#Bind("ReceivedDate") %>'></asp:Label>
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

                            <asp:TemplateField HeaderText="SUPPLIER NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblAccountName" runat="server" Text='<%#Bind("AccountName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="CHECKED BY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblCheckedBy" runat="server" Text='<%#Bind("PersonName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CONFIRM ?">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblCheckedConfirm" runat="server" Text='<%#Bind("CHK_Confirm") %>'></asp:Label>
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

                                                        <%-- <asp:TemplateField HeaderText="ORDER QTY.">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtOrderQty" Enabled="false" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                             <FooterTemplate>
                                                                <asp:Label ID="lblSumTotalQty" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="RECEIVED QTY.">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtReceivedQty" Enabled="false" AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="RETURN QTY.">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtReturnQty" Enabled="false" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="BALANCE QTY.">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" runat="server" Enabled="false" ID="TxtBalQty"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>

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



    <script src="js/proton.js"></script>

    <div class="modal fade" tabindex="-1" id="CmpDeleteSelection" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">DELETE PURCHASE DELIVERY CHALLAN DETAIL</h4>
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

                    <h4 class="modal-title">UPDATE PURCHASE DELIVERY CHALLAN DETAIL</h4>
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
    <asp:UpdatePanel ID="UpModalSelectPO" runat="server">
        <ContentTemplate>

            <div class="modal fade" tabindex="-1" id="CmpSelectPO" data-keyboard="false" data-backdrop="static">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">

                            <h4 class="modal-title" style="color: red">Purchase Order</h4>
                        </div>
                        <div class="modal-body">

                            <div id="Div1" runat="server" class="grids">

                                <div class="panel panel-widget top-grids" style="height: 500px; overflow-y: scroll" >
                                    Find
                                <asp:TextBox ID="TxtAMCQuoatationTerms" CssClass="form-control" runat="server"></asp:TextBox>


                                    <div class="h5" style="color: brown; text-align: left">PO Details</div>
                                    <asp:GridView ID="GvForPO" CssClass="table table-vcenter table-condensed table-bordered"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvForPO_PageIndexChanging" OnRowCommand="GvForPO_RowCommand"
                                        PageSize="10" ShowFooter="true">
                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                        <Columns>


                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnSelect" OnClick="btnSelect_Click" runat="server" CausesValidation="false" CommandName="Selecta" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="View" Text="SELECT" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                                    <asp:HiddenField ID="HfOrdItem_TransDate" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                    <asp:HiddenField ID="HfOrdItem_TransNo" runat="server" Value='<%#Bind("TRAN_NO") %>' />

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--  <asp:TemplateField HeaderText="Sr.No.">
                                          <ItemTemplate>
                                              <%#Container.DataItemIndex + 1 %>
                                           </ItemTemplate>
                                        </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Order Ref No">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblOrderRefNo" runat="server" Text='<%#Bind("ORD_NO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Order Date">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblOrderDate" runat="server" Text='<%#Bind("OrderDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>

                                    <center> <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK </button> </center>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="TxtAccountName" />
            <asp:PostBackTrigger ControlID="GvForPO" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function HideModelPurchaseOrder() {
            $("#CmpSelectPO").modal('hide');
        }

        function ShowModelPurchaseOrder() {

            $("#CmpSelectPO").modal('show');

        }
        function SelectionAlert() {

            alert("Must be select Supplier Name !");

        }
    </script>



    <script src="js/proton.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="modal fade" tabindex="-1" id="CmpViewBarcode" data-keyboard="false" data-backdrop="static">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">

                            <h4 class="modal-title" style="color: red">Barcode Details</h4>
                        </div>
                        <div class="modal-body">

                            <div id="Div4" runat="server" class="grids">

                                <div class="panel panel-widget top-grids" style="height: 500px; overflow-y: scroll" >
                                    

                                    <asp:GridView ID="GvViewBarcode" CssClass="table table-vcenter table-condensed table-bordered"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvViewBarcode_PageIndexChanging"
                                        PageSize="10" ShowFooter="true">
                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                        <Columns>


                                            <asp:TemplateField HeaderText="Sr.No.">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex + 1 %>
                                                    <asp:HiddenField ID="HfTransDateGrid" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                    <asp:HiddenField ID="HfTransNoGrid" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="BARCODE">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblbarcode" runat="server" Text='<%#Bind("BARCODE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="STATUS">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblBracodeStatus" runat="server" Text='<%#Bind("STATUS") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="RATE">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblRate" runat="server" Text='<%#Bind("RATE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>

                                    <center> <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK </button> </center>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="TxtAccountName" />
            <asp:PostBackTrigger ControlID="GvForPO" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function HideModelViewBarcode() {
            $("#CmpViewBarcode").modal('hide');
        }

        function ShowModelViewBarcode() {

            $("#CmpViewBarcode").modal('show');

        }

    </script>

</asp:Content>
