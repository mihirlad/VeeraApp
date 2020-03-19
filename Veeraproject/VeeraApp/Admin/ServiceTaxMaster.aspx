<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="ServiceTaxMaster.aspx.cs" Inherits="VeeraApp.ServiceTaxMaster" %>

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
                    <h4>SERVICE TAX MASTER</h4>
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
                             <div class="col-md-12">
 
                                 <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="From Date" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtFromDate" CssClass="form-control" runat="server"></asp:TextBox>

                                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtFromDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                            ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                     <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server"
                                            ControlToValidate="TxtFromDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                     <ajax:CalendarExtender runat="server" ID="CalendarID1" Format="dd-MM-yyyy" TargetControlID="TxtFromDate"></ajax:CalendarExtender>
                                     </div>
                                  <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="To Date" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtToDate" CssClass="form-control" runat="server"></asp:TextBox>

                                   <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ControlToValidate="TxtToDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                            ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                     <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                            ControlToValidate="TxtToDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                     <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtToDate"></ajax:CalendarExtender>
                                   </div>
                                  <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="GST %" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtGST" OnTextChanged="TxtGST_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="CGST %" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtCGST" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="SGST %" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtSGST" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="IGST %" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtIGST" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                             </div>

                             <div style="clear: both; height: 10px">
                            </div>

                            <div class="col-md-12">
                                <div class="col-md-1">
                                    <asp:Label CssClass="label" Text="TAX-1 %" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtTax1" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                  <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="TAX-1 Title" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtTitle1" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                  <div class="col-md-1">
                                    <asp:Label CssClass="label" Text="TAX-2 %" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtTax2" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                  <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="TAX-2 Title" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtTitle2" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="col-md-1">
                                    <asp:Label CssClass="label" Text="TAX-3 %" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtTax3" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                  <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="TAX-3 Title" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtTitle3" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                           </ContentTemplate>
                            </asp:UpdatePanel>
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
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" OnClick="BtnAdd_Click" CssClass="btn btn-lg btn-primary" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />
        </div>
        <asp:HiddenField ID="HfTranNo" runat="server" />
        <asp:HiddenField ID="HfTranDate" runat="server" />

          <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                 <div class="table-responsive">
                    <asp:GridView ID="GvServiceTaxMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvServiceTaxMaster_PageIndexChanging" OnRowCommand="GvServiceTaxMaster_RowCommand"
                         PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                             <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("TRAN_NO") %>'  ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <%--<asp:HiddenField ID="HfTranNo" runat="server" Value='<%#Bind("TRAN_NO")%>' />--%>
                                      <asp:HiddenField ID="HfTranDateGrid" runat="server" Value='<%#Bind("TRAN_DATE")%>' />
                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                </ItemTemplate>
                           </asp:TemplateField>
                            
                           <%--<asp:TemplateField HeaderText="SR.NO.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                            </asp:TemplateField> --%>
                            <asp:TemplateField HeaderText="FROM DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblFromDate" runat="server" Text='<%#Bind("FromDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="TO DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblToDate" runat="server" Text='<%#Bind("ToDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="GST">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign"  ID="lblGST" runat="server" Text='<%#Bind("GST_RATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="CGST">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign"  ID="lblCGST" runat="server" Text='<%#Bind("CGST_RATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="SGST">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign"  ID="lblSGST" runat="server" Text='<%#Bind("SGST_RATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="IGST">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdrightalign"  ID="lblIGST" runat="server" Text='<%#Bind("IGST_RATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                     </div>
                 </div>
            </div>
        </div>


      <script src="js/proton.js"></script>

        <div class="modal fade" tabindex="-1" id="CmpDeleteSelection" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        
                        <h4 class="modal-title">DELETE SERVICE DETAIL</h4>
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
                        
                        <h4 class="modal-title">UPDATE SERVICE TAX DETAIL</h4>
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
