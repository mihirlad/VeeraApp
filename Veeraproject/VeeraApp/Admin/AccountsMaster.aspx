<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="AccountsMaster.aspx.cs" Inherits="VeeraApp.AccountsMaster" %>
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
                    <h4>ACCOUNTS MASTER - DETAIL :</h4>
                </div>
            </div>
        </div>
    </div>

   <div style="clear: both; height: 10px">
    </div>

    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <%-- <div class="form-title">
                    <h4>ACCOUNTS DETAIL :</h4>
                </div>--%>
                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">
                              <div class="col-md-12">
                             <%--  <div class="col-md-2">
                                    <asp:textbox id="TxtAccCode" cssclass="form-control" runat="server" placeholder="ACCOUNT CODE"></asp:textbox>
                                    <asp:requiredfieldvalidator display="Dynamic" id="RequireTxtBranchCode" runat="server"
                                        controltovalidate="TxtBranchCode" forecolor="Red">*</asp:requiredfieldvalidator>
                                </div>   --%>

                                <div class="col-md-4">
                                    <asp:Label CssClass="label" Text="Name of the Account " runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtAccountName" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="TxtAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                  <div class="col-md-2">
                                       <asp:Label CssClass="label" Text="Short" runat="server"></asp:Label>
                                      <asp:TextBox ID="TxtAccountShort" CssClass="form-control" runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="TxtAccountShort" ForeColor="Red">*</asp:RequiredFieldValidator>
                                  </div>
                                  <div class="col-md-3">
                                      <asp:Label CssClass="label" Text="Account Group Name" runat="server"></asp:Label>
                                      <asp:TextBox ID="TxtAccountGroupName" CssClass="form-control" runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server"
                                        ControlToValidate="TxtAccountGroupName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                   </div>
                                   <div class="col-md-3">
                                      <asp:Label CssClass="label" Text="Branch Name" runat="server"></asp:Label>
                                       <asp:TextBox ID="TxtBranchName" CssClass="form-control" runat="server"></asp:TextBox>
                                     </div>

                                  <div style="clear: both; height: 10px">
                                 </div>

                                  <div class="col-md-12">
                                      <div class="col-md-3">
                                           <asp:Label CssClass="label" Text="Place Name" runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtPlaceName" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>

                                   <div class="col-md-3">
                                       <asp:Label CssClass="label" Text="Route Name" runat="server"></asp:Label>
                                       <asp:TextBox ID="TxtRouteName" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                      <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="GPS Name" runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtGpsLocation" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>

                                      <div class="col-md-3">
                                           <asp:Label CssClass="label" Text="Marketing Person Name" runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtMktgPersonName" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>
                                  </div>

                                    <div style="clear: both; height: 10px">
                                 </div>
                                  
                                  <div class="col-md-12">
                                      <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="Payment Person Name" runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtPyamentPersonName" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>

                                      <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="Service Person Name" runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtServicePersonName" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>

                                      <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="Contact Person Name" runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtContactPersonName" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>

                                       <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="Vendor Code" runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtVendorCode" CssClass="form-control" runat="server"></asp:TextBox>
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

                                  <div class="col-md-12">
                                      <div class="col-md-3">
                                       <asp:Label CssClass="label" Text="State Name" runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtStateName" CssClass="form-control" runat="server"></asp:TextBox>
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
                                       <asp:Label CssClass="label" Text="Credit Amount" runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtCreditAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>
                                  </div>

                                    <div style="clear: both; height: 10px">
                                 </div>
                                  <div class="col-md-12">
                                      <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="Credit Days" runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtCreditDays" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>
                                       <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="Phone(O)" runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtPhoneO" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>
                                      <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="Phone(M)" runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtPhoneM" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>
                                        <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="Fax" runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtFax" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>
                                  </div>

                                  
                                   <div style="clear: both; height: 10px">
                                 </div>
                                  <div class="col-md-12">
                                      <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="E-Mail Address" runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>
                                      <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="GST No." runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtGSTNo" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>
                                      <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="VAT TIN No." runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtVatTinNo" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>
                                      <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="VAT CST No." runat="server"></asp:Label>
                                          <asp:TextBox ID="TctVatCstNo" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>
                                      </div>

                                   <div style="clear: both; height: 10px">
                                 </div>
                                  <div class="col-md-12">
                                      <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Party Type" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlPartyType" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                        <asp:ListItem Value="L">LOCAL</asp:ListItem>
                                        <asp:ListItem Value="C">CST</asp:ListItem>
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
                                    <asp:DropDownList ID="DdlRegCstType" runat="server" CssClass="form-control">
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
                                        <asp:ListItem Value="M">Manufacturer</asp:ListItem>
                                        <asp:ListItem Value="T">Traders</asp:ListItem>
                                        <asp:ListItem Value="C">Customer</asp:ListItem>
                                    </asp:DropDownList>
                                  </div>
                                  </div>

                                  <div style="clear: both; height: 10px">
                                 </div>

                                    <div class="col-md-12">
                                      <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="ECC No." runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtEccNo" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>
                                         <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="PAN No." runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtPanNo" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>
                                         <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="WEF Date" runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtWefDate" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>
                                          <div class="col-md-3">
                                          <asp:Label CssClass="label" Text="WEF Date" runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtWefDate2" CssClass="form-control" runat="server"></asp:TextBox>
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
                                          <asp:TextBox ID="TxtBnakName" CssClass="form-control" runat="server"></asp:TextBox>
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
                                          <asp:Label CssClass="label" Text="Bank A/C No." runat="server"></asp:Label>
                                          <asp:TextBox ID="TxtBankACNo" CssClass="form-control" runat="server"></asp:TextBox>
                                      </div>
                                     <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="A/C Details Completed?" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlAccDetailComplted" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                        <asp:ListItem Value="Y">YES</asp:ListItem>
                                        <asp:ListItem Value="N">NO</asp:ListItem>  
                                    </asp:DropDownList>
                                  </div>
                                   <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Service Details Completed?" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlServiceDetailComplted" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                        <asp:ListItem Value="Y">YES</asp:ListItem>
                                        <asp:ListItem Value="N">NO</asp:ListItem>  
                                    </asp:DropDownList>
                                       </div>
                                  </div>

                            
                                   <div style="clear: both; height: 10px">
                                 </div>

                                    <div class="col-md-12">
                                      <div class="col-md-3">
                                            <asp:Button ID="BtnHODetails" runat="server" Text="HO Details" OnClick="BtnHODetails_Click" CausesValidation="false" CssClass="btn btn-default btn-primary" />
                                      </div>
                                         <div class="col-md-3">
                                            <asp:Button ID="BtnExportAccount" runat="server" Text="Export Account" OnClick="BtnExportAccount_Click" CssClass="btn btn-default btn-primary" />
                                      </div>
                                         <div class="col-md-3">
                                            <asp:Button ID="BtnContactDetail" runat="server" Text="Contact Details" OnClick="BtnContactDetail_Click" CssClass="btn btn-default  btn-primary" />
                                      </div>
                                         <div class="col-md-3">
                                            <asp:Button ID="BtnModalDetail" runat="server" Text="Model Details" OnClick="BtnModalDetail_Click" CssClass="btn btn-default btn-primary" />
                                      </div>
                                      </div>

                               </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        

          <script src="js/proton.js"></script>


        <div class="modal fade" tabindex="-1" id="CmpHODetails" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        
                        <h4 class="modal-title">HO Details</h4>
                    </div>
                    <div class="modal-body">
                        
                        <div id="Div1" runat="server" class="grids">

                      <div class="panel panel-widget top-grids">

                          <%-- <asp:Label CssClass="label" Text="Conatct Person" runat="server"></asp:Label> --%>
                           Contact Person  <asp:TextBox ID="TxtContactPerson" CssClass="form-control" runat="server"></asp:TextBox>
                           Address    <asp:TextBox ID="TxtHOAddress1" CssClass="form-control" runat="server"></asp:TextBox><br />
                                       <asp:TextBox ID="TxtHOAddress2" CssClass="form-control" runat="server"></asp:TextBox><br />
                                       <asp:TextBox ID="TxtHOAddress3" CssClass="form-control" runat="server"></asp:TextBox>
                            Phone(O)  <asp:TextBox ID="TxtHOPhone1" CssClass="form-control" runat="server"></asp:TextBox>
                            Phone(M)  <asp:TextBox ID="TxtHOPhone2" CssClass="form-control" runat="server"></asp:TextBox>
                            Fax       <asp:TextBox ID="TxtHOFax" CssClass="form-control" runat="server"></asp:TextBox>
                            Email  <asp:TextBox ID="TxtHOEmail" CssClass="form-control" runat="server"></asp:TextBox>

                     <%--   <asp:Button ID="btnDelete" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnDelete_click" CausesValidation="false" />   --%>                    
                        <button type="button" class="btn btn-default btn-primary btn-block"  data-dismiss="modal" value="NO">Back</button>
                </div>

                         </div>
                    </div>


                </div>
            </div>
        </div>

     <script type="text/javascript">
        function HideModel() {
            $("#CmpHODetails").modal('hide');
        }

        function ShowModel() {

            $("#CmpHODetails").modal('show');

        }
    </script>


</asp:Content>
