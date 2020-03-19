﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="TransportMaster.aspx.cs" Inherits="VeeraApp.TransportMaster" %>
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
                    <h4>TRANSPORT DETAILS</h4>
                </div>
            </div>
        </div>
    </div>

<%--    <div style="clear: both; height: 10px">
    </div>--%>

       <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">

                  <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">

                            <div class="col-md-12">
                              <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Transport Name" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtTransportName" CssClass="form-control" runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTransportName" runat="server"
                                        ControlToValidate="TxtTransportName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Vehicle No" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtVehicleNo" CssClass="form-control" runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtVehicleNo" runat="server"
                                        ControlToValidate="TxtVehicleNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>

                                   <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Contact Person" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtContactPerson" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtContactPerson" runat="server"
                                        ControlToValidate="TxtContactPerson" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                 <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Address" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtAddress1" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtAddress1" runat="server"
                                             ControlToValidate="TxtAddress1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                  <div style="clear: both; height: 10px">
                                     </div>

                               <div class="col-md-12">
                                 <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="MDL No." runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtMDLNo" CssClass="form-control" runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtMDLNo" runat="server"
                                        ControlToValidate="TxtMDLNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="MDL State" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtMDLState" CssClass="form-control" runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtMDLState" runat="server"
                                        ControlToValidate="TxtMDLState" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                 <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Phone(O)" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtPhoneO" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Phone(M)" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtPhoneM" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtPhoneM" runat="server"
                                        ControlToValidate="TxtPhoneM" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                   </div>

                                   <div style="clear: both; height: 10px">
                                     </div>
                                  <div class="col-md-12">
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
                                    <asp:Button ID="Btncalldel" runat="server" Text="DELETE" OnClick="Btncalldel_Click"  CssClass="btn btn-lg btn-primary btn-block" />
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
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" OnClick="BtnAdd_Click" CssClass="btn btn-lg btn-primary" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />
        </div>
        <asp:HiddenField ID="HfTransportCode" runat="server" />

          <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

               <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvTransportMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvTransportMaster_PageIndexChanging" OnRowCommand="GvTransportMaster_RowCommand"
                         PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                             <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("TCODE") %>'  ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <asp:HiddenField ID="HfTransportCode" runat="server" Value='<%#Bind("TCODE")%>' />

                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("TCODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("TCODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                </ItemTemplate>
                             </asp:TemplateField>

                            <asp:TemplateField HeaderText="TRANSPORT NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblTransportName" runat="server" Text='<%#Bind("TNAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VEHICLE NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblVehicleNo" runat="server" Text='<%#Bind("VEHICLE_NO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Contact Person">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblContactPerson" runat="server" Text='<%#Bind("CONTACT_PER") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Address">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblAddress" runat="server" Text='<%#Bind("ADD1") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="MDL NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdcenteralign"  ID="lblMDLNo" runat="server" Text='<%#Bind("MDLNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="MDL STATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblMDState" runat="server" Text='<%#Bind("MDLSTATE") %>'></asp:Label>
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
                        
                        <h4 class="modal-title">DELETE TRANSPORT DETAILS</h4>
                    </div>
                    <div class="modal-body">
                           
                       <span>Are you sure want to delete...!!!</span>
                      <br />
                      
                         <div id="Div2" runat="server" class="grids">

                      <div class="panel panel-widget top-grids">

                                    <asp:Button ID="btnDelete" runat="server" Text="YES"  CssClass="btn btn-lg btn-primary" OnClick="btnDelete_Click" CausesValidation="false" />
                                    <button type="button" class="btn btn-lg btn-primary"  data-dismiss="modal" value="NO">NO</button>
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
                        
                        <h4 class="modal-title">UPDATE TRANSPORT DETAILS</h4>
                    </div>
                    <div class="modal-body">
                        
                        
                       <span>Are you sure want to update...!!!</span>
                      <br />
                      
                         <div id="Div3" runat="server" class="grids">

                      <div class="panel panel-widget top-grids">
                          <asp:Button ID="btnSave" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnSave_Click"/>
                           <button type="button" class="btn btn-lg btn-primary"  data-dismiss="modal" value="NO">NO</button>
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
