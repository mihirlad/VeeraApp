<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="StockModelMaster.aspx.cs" Inherits="VeeraApp.StockModelMaster" %>
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
                    <h4>STOCK BRAND MASTER</h4>
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

                             <div class="h5">BRAND MASTER</div>
                            <div class="col-md-12">
                                <div class="col-md-3">
                                  <asp:Label CssClass="label" Text="Brand Name" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtBrandName" CssClass="form-control" runat="server"></asp:TextBox>

                                     <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldTxtProductName" runat="server"
                                        ControlToValidate="TxtBrandName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>

                                 <div class="col-md-3">
                                  <asp:Label CssClass="label" Text="Model Type Name" ForeColor="Blue" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlModelTypeName" ForeColor="Blue" runat="server" CssClass="form-control">
                                    </asp:DropDownList>

                                      <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredDdlCategoryName" runat="server" InitialValue="0"
                                        ControlToValidate="DdlModelTypeName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                <div style="padding-top:20px">
                                <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="AMC Quotation Term" runat="server"></asp:Label>
                                    <%--<asp:CheckBox ID="ChkQuotationTerms" runat="server" OnCheckedChanged="ChkQuotationTerms_CheckedChanged" AutoPostBack="true" />--%>
                                    <asp:LinkButton ID="lnkQuotationTerms" runat="server" OnClick="lnkQuotationTerms_Click" CausesValidation="false"><i class="fa fa-external-link" aria-hidden="true"></i></asp:LinkButton>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="AMC Term" runat="server"></asp:Label>
                                    <%--<asp:CheckBox ID="ChkAMCTerms" runat="server" OnCheckedChanged="ChkAMCTerms_CheckedChanged" AutoPostBack="true" />--%>
                                    <asp:LinkButton ID="lnkAMCTerms" runat="server" OnClick="lnkAMCTerms_Click" CausesValidation="false"><i class="fa fa-external-link" aria-hidden="true"></i></asp:LinkButton>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="Warranty Term" runat="server"></asp:Label>
                                    <%--<asp:CheckBox ID="ChkWarrantyTerms" runat="server" OnCheckedChanged="ChkWarrantyTerms_CheckedChanged" AutoPostBack="true" />--%>
                                    <asp:LinkButton ID="lnkWarrantyTerms" runat="server" OnClick="lnkWarrantyTerms_Click" CausesValidation="false"><i class="fa fa-external-link" aria-hidden="true"></i></asp:LinkButton>
                                </div></div>
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
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />
        </div>
       
        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBrandCode" runat="server" />

           <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">
                
                
             <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">
         
                 <div class="table-responsive">
                    <asp:GridView ID="GvStockBrandMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvStockBrandMaster_PageIndexChanging" OnRowCommand="GvStockBrandMaster_RowCommand"
                         PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                             <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("BRAND_CODE") %>'  ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <asp:HiddenField ID="HfBrandCodeGrid" runat="server" Value='<%#Bind("BRAND_CODE")%>' />
                                    <asp:HiddenField ID="HfCompCodeGrid" runat="server" Value='<%#Bind("COMP_CODE")%>' />

                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("BRAND_CODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("BRAND_CODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnAddModelMaster" runat="server" Text="ADD MODEL" CausesValidation="false" CommandName="AddModel" CommandArgument='<%#Bind("BRAND_CODE") %>' ToolTip="Add Model" />

                                </ItemTemplate>
                                 </asp:TemplateField>     
                            
                             <asp:TemplateField HeaderText="BRAND NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblBrandName" runat="server" Text='<%#Bind("BRAND_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="MODEL TYPE NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblModelTypeName" runat="server" Text='<%#Bind("BrandTypeName") %>'></asp:Label>
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
                        
                        <h4 class="modal-title">DELETE BRAND MASTER DETAIL</h4>
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
          12345
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        
                        <h4 class="modal-title">UPDATE BRAND MASTER DETAIL</h4>
                    </div>
                    <div class="modal-body">
                        
                        
                       <span>Are you sure want to update...!!!</span>
                      <br />
                      
                         <div id="Div3" runat="server" class="grids">

                      <div class="panel panel-widget top-grids">
                          <asp:Button ID="btnSave" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnSave_Click" />
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


    
        <script src="js/proton.js"></script>


        <div class="modal fade" tabindex="-1" id="CmpAMCQuoatationTerms" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title">AMC Quotation Terms</h4>
                    </div>
                    <div class="modal-body">

                        <div id="Div1" runat="server" class="grids">

                            <div class="panel panel-widget top-grids">
                                AMC Quotations Terms & Condition
                            <asp:TextBox ID="TxtAMCQuoatationTerms" CssClass="form-control" runat="server" TextMode="MultiLine" Height="200px"></asp:TextBox>
                           <center>
                                <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK </button> </center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            function HideModelAMCQuotationTerms() {
                $("#CmpAMCQuoatationTerms").modal('hide');
            }

            function ShowModelAMCQuotationTerms() {

                $("#CmpAMCQuoatationTerms").modal('show');

            }
        </script>



     <script src="js/proton.js"></script>


        <div class="modal fade" tabindex="-1" id="CmpAMCTerms" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title">AMC Terms</h4>
                    </div>
                    <div class="modal-body">

                        <div id="Div4" runat="server" class="grids">

                            <div class="panel panel-widget top-grids">
                                AMC Confirmation Terms & Condition
                            <asp:TextBox ID="TxtAMCTerms" CssClass="form-control" runat="server" TextMode="MultiLine" Height="200px"></asp:TextBox>
                           
                            <CENTER>  <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK</button> </CENTER> 
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            function HideModelAMCTerms() {
                $("#CmpAMCTerms").modal('hide');
            }

            function ShowModelAMCTerms() {

                $("#CmpAMCTerms").modal('show');

            }
        </script>

    
     <script src="js/proton.js"></script>


        <div class="modal fade" tabindex="-1" id="CmpWarrantyTerms" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title">Warranty Terms</h4>
                    </div>
                    <div class="modal-body">

                        <div id="Div5" runat="server" class="grids">

                            <div class="panel panel-widget top-grids">
                                Warranty Terms & Condition
                            <asp:TextBox ID="TxtWarrantyTerms" CssClass="form-control" runat="server" TextMode="MultiLine" Height="200px"></asp:TextBox>
                          
                              <CENTER>  <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK</button></CENTER>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            function HideModelWarrantyTerms() {
                $("#CmpWarrantyTerms").modal('hide');
            }

            function ShowModelWarrantyTerms() {

                $("#CmpWarrantyTerms").modal('show');

            }
        </script>



</asp:Content>
