<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="StockCategoryMaster.aspx.cs" Inherits="VeeraApp.StockCategoryMaster" %>
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
                    <h4>STOCK CATEGORY MASTER</h4>
                </div>
            </div>
        </div>
    </div>

   <%-- <div style="clear: both; height: 10px">
    </div>--%>

    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">

                  <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">

                            <div class="col-md-12">
                              <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Category Name" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtStoctCatName" CssClass="form-control" runat="server"></asp:TextBox>

                                      <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtStoctCatName" runat="server"
                                        ControlToValidate="TxtStoctCatName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                  </div>
                                 <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="Tariff No." runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtTarrifNo" CssClass="form-control" runat="server"></asp:TextBox>

                                     <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldTxtTarrifNo" runat="server"
                                        ControlToValidate="TxtTarrifNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                  </div>
                                 <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="Order" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtStockOrder" CssClass="form-control" runat="server"></asp:TextBox>

                                     <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldTxtStockOrder" runat="server"
                                        ControlToValidate="TxtStockOrder" ForeColor="Red">*</asp:RequiredFieldValidator>
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
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />
        </div>
        <asp:HiddenField ID="HfStockCatCode" runat="server" />
        <asp:HiddenField ID="HfCompCode" runat="server" />

          <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                 <div class="tabl-respeonsive" style="height: 450px; overflow-y: scroll">

                 <div class="table-responsive">
                    <asp:GridView ID="GvStockCatMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvStockCatMaster_PageIndexChanging" OnRowCommand="GvStockCatMaster_RowCommand"
                         PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                             <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("CAT_CODE") %>'  ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <asp:HiddenField ID="HfStockCatCode" runat="server" Value='<%#Bind("CAT_CODE")%>' />

                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("CAT_CODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("CAT_CODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                </ItemTemplate>
                             </asp:TemplateField>

                             <asp:TemplateField HeaderText="CATEGORY NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblStockCatName" runat="server" Text='<%#Bind("CAT_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="TARIFF NO.">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblStockTariffNo" runat="server" Text='<%#Bind("CAT_CETHNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ORDER">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblStockOrder" runat="server" Text='<%#Bind("ORD_NO") %>'></asp:Label>
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
                        
                        <h4 class="modal-title">DELETE STOCK CATEGORY DETAILS</h4>
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
                        
                        <h4 class="modal-title">UPDATE STOCK CATEGORY DETAILS</h4>
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
