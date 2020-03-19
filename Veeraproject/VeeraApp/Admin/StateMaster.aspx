<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="StateMaster.aspx.cs" Inherits="VeeraApp.StateMaster" %>
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
                    <h4>STATE MASTER</h4>
                </div>
            </div>
        </div>
    </div>


<%--    <div style="clear: both; height: 10px">
    </div>--%>

     <div class="grids">
    </div>
    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">

                  <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">
                            <div class="col-md-12">
                               
                                <div class="col-md-1">
                                    <asp:Label CssClass="label" Text="State Code" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtStateNo" CssClass="form-control" runat="server"></asp:TextBox>
                                     <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtStateNo" runat="server"
                                        ControlToValidate="TxtStateNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="State Name" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtStateName" CssClass="form-control" runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtStateName" runat="server"
                                        ControlToValidate="TxtStateName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                 <div class="col-md-2">
                                    <asp:Label CssClass="label"  Text="State Type" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlStateType" runat="server" CssClass="form-control">
                                         <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                          <asp:ListItem Value="STATE">STATE</asp:ListItem>
                                         <asp:ListItem Value="UT">UT</asp:ListItem>
                                        </asp:DropDownList>
                                      <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredDdlStateType" runat="server" InitialValue="0"
                                             ControlToValidate="DdlStateType" ForeColor="Red">*</asp:RequiredFieldValidator>
                                   </div>
                                 <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="State Short" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtStateShort" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="State Capital" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtStateCapital" CssClass="form-control" runat="server"></asp:TextBox>
                                     <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtStateCapital" runat="server"
                                        ControlToValidate="TxtStateCapital" ForeColor="Red">*</asp:RequiredFieldValidator>
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
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" OnClick="BtnAdd_Click" CssClass="btn btn-lg btn-primary" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />
        </div>
        <asp:HiddenField ID="HfStateCode" runat="server" />

          <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="table-responsive">
                    <asp:GridView ID="GvStateMaster" AllowSorting="true" OnSorting="GvStateMaster_Sorting" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="true" AllowPaging="true" OnPageIndexChanging="GvStateMaster_PageIndexChanging" OnRowCommand="GvStateMaster_RowCommand"
                         PageSize="500">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                             <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("STATE_CODE") %>'  ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <asp:HiddenField ID="HfStateCode" runat="server" Value='<%#Bind("STATE_CODE")%>' />

                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("STATE_CODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("STATE_CODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                </ItemTemplate>
                             </asp:TemplateField>

                            <asp:TemplateField HeaderText="STATE NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblStateName" runat="server" SortExpression="STATE_NAME" Text='<%#Bind("STATE_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="STATE CODE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblStateNo" runat="server" SortExpression="STATE_NO" Text='<%#Bind("STATE_NO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="STATE TYPE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblStateType" runat="server" SortExpression="STATE_TYPE" Text='<%#Bind("STATE_TYPE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="STATE CAPITAL">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblStateCapital" runat="server" SortExpression="STATE_CAPITAL" Text='<%#Bind("STATE_CAPITAL") %>'></asp:Label>
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
                        
                        <h4 class="modal-title">DELETE STATE DETAIL</h4>
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
                        
                        <h4 class="modal-title">UPDATE STATE DETAIL</h4>
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
