<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="CompanyMaster.aspx.cs" Inherits="VeeraApp.Admin.CompanyMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="js/jquery.js"></script>
    <script src="https://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //var Btn = document.getElementById("ContentPlaceHolder1_BtncallUpd");
            //if (Btn != null) {
            //    $(Btn).not(':visible')
            //    {
            //        alert("1");
            //        document.getElementById("BtnRem1").style.visibility = 'visible';
            //        document.getElementById("BtnRem2").style.visibility = 'visible';
            //        document.getElementById("BtnRem3").style.visibility = 'visible';
            //        document.getElementById("BtnRem4").style.visibility = 'visible';
            //    }

            //    $(Btn).is(':visible')
            //    {
            //        alert("2");
            //        document.getElementById("BtnRem1").style.visibility = 'hidden';
            //        document.getElementById("BtnRem2").style.visibility = 'hidden';
            //        document.getElementById("BtnRem3").style.visibility = 'hidden';
            //        document.getElementById("BtnRem4").style.visibility = 'hidden';
            //    }

            //}
            // id = "BtnRem2"
            //}
        });
    </script>
    <script lang="javascript" type="text/javascript">

        function RemoveImages(id) {

            if (id == 1) {

                document.getElementById("ContentPlaceHolder1_HfUploadSignaturePath").value = ' ';
                document.getElementById("ContentPlaceHolder1_ImgSignaturePath").src = "/Admin/Company/SCREEN/NoImage.jpg";
            }
            else if (id == 2) {
                document.getElementById("ContentPlaceHolder1_HfUploadScreenPicturePath").value = ' ';
                document.getElementById("ContentPlaceHolder1_ImgScreenPicturePath").src = "/Admin/Company/SCREEN/NoImage.jpg";
            }
            else if (id == 3) {

                document.getElementById("ContentPlaceHolder1_HfUploadInvoiceLogoPath1").value = ' ';
                document.getElementById("ContentPlaceHolder1_ImgInvoiceLogoPath1").src = "/Admin/Company/SCREEN/NoImage.jpg";
            }
            else if (id == 4) {
                document.getElementById("ContentPlaceHolder1_HfUploadInvoiceLogoPath2").value = ' ';
                document.getElementById("ContentPlaceHolder1_ImgInvoiceLogoPath2").src = "/Admin/Company/SCREEN/NoImage.jpg";

            }
        }


        function startvalue() {
            $('#TxtYR_START').datepicker();
            $('#TxtYR_END').datepicker();
        }

        function getdate() {
            var tt = document.getElementsByName("ctl00$ContentPlaceHolder1$TxtYR_START")["0"].value;
            
            var newdate = new Date(tt);
            newdate.setDate(newdate.getDate() + 365);
            var dd = newdate.getDate();
            var mm = newdate.getMonth() + 1;
            var y = newdate.getFullYear();

            if (dd < 10) {
                dd = '0' + dd;
            }
            if (mm < 10) {
                mm = '0' + mm;
            }

            var someFormattedDate = mm + '-' + dd + '-' + y;

            document.getElementsByName('ctl00$ContentPlaceHolder1$TxtYR_END')["0"].value = someFormattedDate;
        }

    </script>

    <style type="text/css">
        .auto-style1 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 100%;
            left: 7px;
            top: -3px;
            padding-left: 1px;
            padding-right: 10px;
        }
    </style>

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

                    <span class="glyphicon glyphicon-ok form-control-feedback" aria-hidden="true"></span><span id="inputGroupSuccess1Status" class="sr-only"><asp:Label CssClass="label"   ID="lblmsg" runat="server"></asp:Label></span>
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
                    <h4>COMPANY MASTER</h4>
                </div>
            </div>
        </div>
    </div>

    <%--Insert Button END--%>

  <%--  <div style="clear: both; height: 10px">
    </div>--%>

    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <%-- <div class="form-title">
                    <h4>COMPANY DETAIL :</h4>
                </div>--%>
                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">

                            <%--     <ajax:TabContainer ID="TabContainerCompany"  runat="server" ActiveTabIndex="0">
                             <ajax:TabPanel ID="TabBasicDetail" runat="server" style="height:18px;" HeaderText="BASIC DETAIL">
                                    <ContentTemplate>--%>
                            <div class="h5"  style="color:brown">BASIC DETAILS</div>
                            <div class="auto-style1">
                                <%-- <div class="col-md-1">
                                                <asp:TextBox ID="TxtCompanyCode" CssClass="form-control" runat="server" placeholder="COMPANY CODE"></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequireTxtCompanyCode" runat="server"
                                                    ControlToValidate="TxtCompanyCode" ForeColor="Red">*</asp:RequiredFieldValidator>

                                            </div>--%>
                                <asp:UpdatePanel ID="updpnl" runat="server">
                                    <ContentTemplate>

                                   
                                <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Company Name" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtCompanyName" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="TxtCompanyName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label CssClass="label" Text="Short" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtShort" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="TxtShort" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="Company Type" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlCompanyType" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">SELECT TYPE </asp:ListItem>
                                        <asp:ListItem Value="P">PARTNERSHIP</asp:ListItem>
                                        <asp:ListItem Value="R">PROPRITORSHIP</asp:ListItem>
                                        <asp:ListItem Value="L">PVT.LTD.</asp:ListItem>
                                        <asp:ListItem Value="T">TRUST</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldDdlCompanyType" runat="server"
                                InitialValue="0" ControlToValidate="DdlCompanyType" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="Stock Type" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlStockType" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                        <asp:ListItem Value="S">STOCK WISE</asp:ListItem>
                                        <asp:ListItem Value="M">MANNUAL</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldDdlStockType" runat="server"
                                InitialValue="0" ControlToValidate="DdlStockType" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>


                                <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="Start Date" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtYR_START" CssClass="form-control" runat="server" OnTextChanged="TxtYR_START_TextChanged" AutoPostBack="true"></asp:TextBox>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtYR_START" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                        ErrorMessage="INVALID DATE" ForeColor="Red" />

                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server"
                                        ControlToValidate="TxtYR_START" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <ajax:CalendarExtender runat="server" ID="CalendarID1" Format="dd-MM-yyyy" TargetControlID="TxtYR_START"></ajax:CalendarExtender>

                                </div>

                                <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="End Date" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtYR_END" CssClass="form-control" runat="server"></asp:TextBox>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ControlToValidate="TxtYR_END" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                        ErrorMessage="INVALID DATE" ForeColor="Red" />

                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server"
                                        ControlToValidate="TxtYR_END" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtYR_END"></ajax:CalendarExtender>

                                </div>
                                 </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div style="clear: both; height: 10px;">
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <asp:Label CssClass="label" Text="Address1" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtADD1" CssClass="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label CssClass="label" Text="Address2" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtADD2" CssClass="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                                </div>

                                <div class="col-md-4">
                                    <asp:Label CssClass="label" Text="Address3" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtADD3" CssClass="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                                </div>
                            </div>
                            <div style="clear: both; height: 10px;">
                            </div>
                            <div class="col-md-12">

                                <div class="col-md-4">
                                    <asp:Label CssClass="label" Text="City" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtCity" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label CssClass="label" Text="Place" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtPlace" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label CssClass="label" Text="District" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtDistrict" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div style="clear: both; height: 10px;">
                            </div>

                            <asp:UpdatePanel ID="UPDPANEL" runat="server">
                                <ContentTemplate>

                             <div class="col-md-12">

                                <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="State" runat="server"></asp:Label>
                                  <%--  <asp:TextBox ID="TxtState" CssClass="form-control" runat="server"></asp:TextBox> --%> 
                                    <asp:DropDownList ID="DdlStateName" AutoPostBack="true" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged" runat="server" CssClass="form-control">
                                        </asp:DropDownList>

                                       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" runat="server" InitialValue="0"
                                             ControlToValidate="DdlStateName" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                    <asp:Label CssClass="label" Text="Phone" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtPhone" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 </div>
                                 </ContentTemplate>
                            </asp:UpdatePanel>

                                <div style="clear: both; height: 10px;">
                                </div>
                                <div class="col-md-12">

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Fax" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtFax" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="E-Mail Address" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtEmailAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldEmail" runat="server" ErrorMessage="*" ControlToValidate="TxtEmailAddress"
                                            ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Please Enter Valid Email ID"
                                            ControlToValidate="TxtEmailAddress"
                                            CssClass="requiredFieldValidateStyle" ForeColor="Red"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                        </asp:RegularExpressionValidator>


                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Auto E-Mail Address" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtAutoEmailAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <%-- </ContentTemplate>
                                </ajax:TabPanel>

                              <ajax:TabPanel ID="TabPanelBankDetail" runat="server" style="height:18px;" HeaderText="BANK DETAIL">
                                    <ContentTemplate> --%>
                                <div class="h5"  style="color:brown">BANK DETAILS</div>
                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Bank Name" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtBankName" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Branch Name" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtBranchName" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="IFSC Code" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtIFSC" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Bank A/C No." runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtBankAccNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div style="clear: both; height: 10px;"></div>
                                <div class="col-md-12">

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Authorised Person" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtAuthorisedPerson" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="GOD Title" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtGODTitle" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Product Description " runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtProductDesc" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="GST No." runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtGSTNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px;"></div>
                                <div class="col-md-12">

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="VAT TIN No." runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtVatTinNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="VAT CST No." runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtVatCstNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="ECC No." runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtEccCNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="PAN No." runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtPanNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px;"></div>
                                <div class="col-md-12">

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Service TAX No." runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtServiceTaxNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Stock Working Flag" runat="server"></asp:Label>
                                        <asp:DropDownList ID="DdlStokWorkingFlag" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                            <asp:ListItem Value="B">BARCODE BASE</asp:ListItem>
                                            <asp:ListItem Value="I">ITEM BASE</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Add Dis.Flag" runat="server"></asp:Label>
                                        <asp:DropDownList ID="DdlAddDisFlag" runat="server" CssClass="form-control">
                                           <%-- <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>--%>
                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                            <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Signature Path" runat="server"></asp:Label>
                                        <%-- <asp:TextBox ID="TxtSignaturePath" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                        <asp:FileUpload ID="UploadSignaturePath" runat="server" />
                                        <asp:HiddenField ID="HfUploadSignaturePath" runat="server" />
                                        <asp:Image ID="ImgSignaturePath" runat="server" Height="50" Width="50" />&nbsp;&nbsp;
                                        <input type="button" id="BtnRem1" runat="server" value="X" style="color: red" onclick="RemoveImages(1);" />

                                    </div>
                                </div>

                                <div style="clear: both; height: 10px;"></div>
                                <div class="col-md-12">

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Screen Picture Path" runat="server"></asp:Label>
                                        <%-- <asp:TextBox ID="TxtScreenPicturePath" CssClass="form-control" runat="server"></asp:TextBox>  --%>
                                        <asp:FileUpload ID="UploadScreenPicturePath" runat="server" />
                                        <asp:HiddenField ID="HfUploadScreenPicturePath" runat="server" />
                                        <asp:Image ID="ImgScreenPicturePath" runat="server" Height="50" Width="50" />
                                        <input type="button" id="BtnRem2" runat="server" value="X" style="color: red" onclick="RemoveImages(2);" />
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Invoice Logo Flag" runat="server"></asp:Label>
                                        <asp:CheckBox ID="Chk_InvoiceLogoFlag" CssClass="form-control" runat="server" Text="INVOICE LOGO FLAG" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Sign Logo Flag" runat="server"></asp:Label>
                                        <asp:CheckBox ID="Chk_SignLogoFlag" CssClass="form-control" runat="server" Text="SIGN LOGO FLAG" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Invoice Logo Path-1" runat="server"></asp:Label>
                                        <%--  <asp:TextBox ID="TxtInvoiceLogoPath1" CssClass="form-control" runat="server"></asp:TextBox> --%>
                                        <asp:FileUpload ID="UploadInvoiceLogoPath1" runat="server" />
                                        <asp:HiddenField ID="HfUploadInvoiceLogoPath1" runat="server" />
                                        <asp:Image ID="ImgInvoiceLogoPath1" runat="server" Height="50" Width="50" />
                                        <input type="button" id="BtnRem3" runat="server" value="X" style="color: red" onclick="RemoveImages(3);" />
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px;"></div>
                                <div class="col-md-12">

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Invoice Logo Path-2" runat="server"></asp:Label>
                                        <%-- <asp:TextBox ID="TxtInvoiceLogoPath2" CssClass="form-control" runat="server"></asp:TextBox> --%>
                                        <asp:FileUpload ID="UploadInvoiceLogoPath2" runat="server" />
                                        <asp:HiddenField ID="HfUploadInvoiceLogoPath2" runat="server" />
                                        <asp:Image ID="ImgInvoiceLogoPath2" runat="server" Height="50" Width="50" />
                                        <input type="button" id="BtnRem4" runat="server" value="X" style="color: red" onclick="RemoveImages(4);" />
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Invoice Type Flag" runat="server"></asp:Label>
                                        <asp:DropDownList ID="DdlInvoiceTypeFlag" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">SELECT TYPE </asp:ListItem>
                                            <asp:ListItem Value="E">EXCISE </asp:ListItem>
                                            <asp:ListItem Value="N">NON EXCISE</asp:ListItem>
                                            <asp:ListItem Value="T">TRADING</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Stock View Flag" runat="server"></asp:Label>
                                        <asp:DropDownList ID="DdlStockViewFlag" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                            <asp:ListItem Value="C">CATEGORY WISE</asp:ListItem>
                                            <asp:ListItem Value="I">ITEM WISE</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <%--     </ContentTemplate>
                                </ajax:TabPanel>

                                 <ajax:TabPanel ID="TabExcise" runat="server" style="height:18px;" HeaderText="EXICISE DETAIL">
                                   <ContentTemplate>--%>
                                <div style="clear: both; height: 10px;"></div>
                                <div class="h5"  style="color:brown">EXCISE DETAILS</div>
                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Excise Title" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtExciseTitle" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Excise Range" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtExciseRange" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Range Address" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtRangeAdd" CssClass="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Excise Division" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtExciseDivision" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px;"></div>
                                <div class="col-md-12">

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Division Address" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtDivisionAdd" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Commisionerate" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtCommissionerate" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Commisionerate Address" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtCommisionerateAdd" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>


                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Excise Rate Of Duty" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtExciseRateOfDuty" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px;"></div>
                                <div class="col-md-12">

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Basic Excise Duty%" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtBasicExciseDuty" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TxtBasicExciseDuty" ForeColor="Red"
                                            ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" ErrorMessage="Enter Only Numeric Value">
                                        </asp:RegularExpressionValidator>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Name Of Excisable Goods" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtExcisableGood" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Edu.CESS%" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtEduCess" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TxtEduCess" ForeColor="Red"
                                            ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" ErrorMessage="Enter Only Numeric Value">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="S & H Edu.CESS%" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtS_H_EduCess" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TxtS_H_EduCess" ForeColor="Red"
                                            ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" ErrorMessage="Enter Only Numeric Value">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px;"></div>
                                <div class="col-md-12">

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Excise CETSH Title 1" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtCETSHTitle1" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Excise CETSH-1" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtCETSH1" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Excise CETSH Title 2" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtCETSHTitle2" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Excise CETSH-2" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtCETSH2" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px;"></div>
                                <div class="col-md-12">

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Excise CETSH Title 3" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtCETSHTitle3" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Excise CETSH-3" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtCETSH3" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>


                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Certificate Title-1" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtCertificateTitle1" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Certificate Title-2" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtCertificateTitle2" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px;"></div>
                                <div class="col-md-12">

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Terms & Condition-VAT" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtTermsCondition_VAT" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Terms & Condition-GST" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtTermsCondition_GST" CssClass="form-control" runat="server"></asp:TextBox>

                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Quotation Subject" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtQuotationSubject" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>


                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Quotation Brand Name" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtQuoatationBrandName" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px;"></div>
                                <div class="col-md-12">


                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Quotation For" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtQuotationFor" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>



                                    <div class="col-md-3">
                                        <asp:Label CssClass="label" Text="Quotation Model No." runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtQuotationModelNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>



                                    <div class="col-md-6">
                                        <asp:Label CssClass="label" Text="Quotation Note" runat="server"></asp:Label>
                                        <asp:TextBox ID="TxtQuotationNote" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <%-- </ContentTemplate>
                                </ajax:TabPanel>
                                 </ajax:TabContainer> --%>




                                <div class="col-md-3" style="display: none;">
                                    <asp:Button ID="btnBranchMaster" runat="server" Text="Branch Master" CssClass="btn btn-lg btn-success btn-block" OnClick="btnBranchMaster_click" />
                                </div>
                                <div class="col-md-3" style="display: none;">
                                    <asp:Button ID="btnViewAllExcise" runat="server" Text="View All Excise" CssClass="btn btn-lg btn-success btn-block" OnClick="btnViewAllExcise_click" />
                                </div>




                                <div style="clear: both; height: 10px;">
                                </div>

                                <div class="col-md-12">
                                    <div class="col-md-3 bs-component mb10">
                                        <asp:Button ID="btnClear" runat="server" Text="EXIT" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnClear_click"
                                            CausesValidation="false" />
                                    </div>
                                    <div class="col-md-3 bs-component mb10">
                                        <asp:Button ID="BtncallUpd" runat="server" Text="UPDATE" OnClick="BtncallUpd_Click" CssClass="btn btn-lg btn-primary btn-block" />

                                    </div>
                                    <div class="col-md-3 bs-component mb10">
                                        <asp:Button ID="calldel" runat="server" Text="DELETE" OnClick="calldel_Click" CssClass="btn btn-lg btn-primary btn-block" />
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
                <asp:Button ID="BtnAdd" runat="server" Text="NEW" OnClick="BtnAdd_OnClick" CausesValidation="false" CssClass="btn btn-lg btn-primary" />
                <asp:Button runat="server" ID="btnExit" Text="Exit" OnClick="btnExit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />
            </div>
            <div style="clear: both; height: 10px"></div>



            <asp:HiddenField ID="hfCOMP_CODE" runat="server" />
            <%-- <div class="progressbar-heading grids-heading">
                    <h4>COMPANY LIST</h4>
                </div>--%>

            <div class="panel panel-widget top-grids">
                <div class="chute chute-center text-center">



                    <div class="table-responsive">
                        <asp:GridView ID="GvCompany" CssClass="table table-vcenter table-condensed table-bordered"
                            runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvCompany_PageIndexChanging"
                            OnRowCommand="GvCompany_RowCommand">
                            <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                            <Columns>
                                <%-- <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button ID="btnEdit" runat="server" CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn btn-link btn-dark"></asp:Button>
                                     </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" CausesValidation="false" CommandName="Deletea" OnClientClick="return confirm('Are you sure you want to Delete the Recorder?');" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn btn-link btn-dark"></asp:Button>
                                        </ItemTemplate>  
                                    </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="ACTION">
                                    <ItemTemplate>
                                        <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>
                                        <asp:HiddenField ID="hfCOMP_CODE" runat="server" Value='<%#Bind("COMP_CODE")%>' />

                                        <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                        <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    </ItemTemplate>
                                </asp:TemplateField>


                                <%-- <asp:TemplateField HeaderText="SR.NO.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="COMPANY NAME">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdleftalign" ID="lblCompanyName" runat="server" Text='<%#Bind("NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="COMPANY CODE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label"   ID="lblCOMP_CODE" runat="server" Text='<%#Bind("COMP_CODE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SHORT">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label"   ID="lblSHORT" runat="server" Text='<%#Bind("SHORT") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </div>


    </div>


    <script src="js/proton.js"></script>


    <div class="modal fade" tabindex="-1" id="CmpBranchSelection" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">DELETE COMPANY</h4>
                </div>
                <div class="modal-body">


                    <span>Are you sure want to delete...!!!</span>
                    <br />

                    <div id="Div1" runat="server" class="grids">

                        <div class="panel panel-widget top-grids">

                            <asp:Button ID="btnDelete" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnDelete_click" CausesValidation="false" />
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

    <%-- <asp:UpdatePanel ID="UpConfirm" runat="server">
        <ContentTemplate>--%>

    <div class="modal fade" tabindex="-1" id="CmpBranchSelection1" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">UPDATE COMPANY</h4>
                </div>
                <div class="modal-body">


                    <span>Are you sure want to update...!!!</span>
                    <br />

                    <div id="Div2" runat="server" class="grids">

                        <div class="panel panel-widget top-grids">

                            <asp:Button ID="btnSave" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnSave_click" />
                            <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">NO</button>
                        </div>

                    </div>
                </div>


            </div>
        </div>
    </div>
    <%-- </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtncallUpd" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>--%>
    <script type="text/javascript">
        function HideModel1() {
            $("#CmpBranchSelection1").modal('hide');
        }

        function ShowModel1() {

            $("#CmpBranchSelection1").modal('show');

        }
    </script>

</asp:Content>
