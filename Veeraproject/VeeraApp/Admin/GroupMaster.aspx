<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="GroupMaster.aspx.cs" Inherits="VeeraApp.Admin.GroupMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- search & sorting--%>

      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0-beta/css/bootstrap.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.16/css/dataTables.bootstrap4.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/responsive/2.1.1/css/responsive.bootstrap4.min.css" />

    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.16/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://cdn.datatables.net/responsive/2.1.1/js/dataTables.responsive.min.js"></script>
    <script src="https://cdn.datatables.net/responsive/2.1.1/js/responsive.bootstrap4.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id$=GvGroupMaster]').prepend($("<thead></thead>").append($('[id$=GvGroupMaster]').find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>

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

    <%--Insert Button BEGIN--%>
    <div class="grids">
        <div class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title">
                    <h4>ACCOUNT GROUP MASTER </h4>
                </div>
            </div>
        </div>
    </div>

    <%--Insert Button END--%>

    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <%--   <div class="form-title">
                    <h4>ACCOUNT GROUP MASTER - DETAIL :</h4>
                </div> --%>
                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">
                            <div class="col-md-12">
                                <%--<div class="col-md-2">
                                    <asp:TextBox id="TxtGroupCode" cssclass="form-control" runat="server" placeholder="GROUP CODE" Visible="false"></asp:TextBox>
                                 </div> --%>
                                <div class="col-md-4">
                                    <asp:Label CssClass="label" Text="Group Name" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtGroupName" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="TxtGroupName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="Group Type" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlGroupType" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                        <asp:ListItem Value="1">LIABILITY</asp:ListItem>
                                        <asp:ListItem Value="2">ASSET</asp:ListItem>
                                        <asp:ListItem Value="3">INCOME</asp:ListItem>
                                        <asp:ListItem Value="4">EXPENSE</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" InitialValue="0"
                                        ControlToValidate="DdlGroupType" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="Group Order" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtGroupOrder" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="TxtGroupOrder" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>


                                <div style="clear: both; height: 10px;">
                                </div>

                                <div class="col-md-12">
                                    <div class="col-md-3 bs-component mb10">
                                        <asp:Button ID="btnClear" runat="server" Text="EXIT" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnClear_click"
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
    </div>







    <div id="DivView" runat="server" class="panel panel-widget top-grids">

        <div class="panel panel-widget top-grids">
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" OnClick="BtnAdd_OnClick" CssClass="btn btn-lg btn-primary" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />
        </div>
        <asp:HiddenField ID="HfGROUP_CODE" runat="server" />


        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

             
                    <div class="table-responsive">

                      <div class="table-responsive" style="height: 500px; overflow-y: scroll">

                        <asp:GridView ID="GvGroupMaster" CssClass="table table-vcenter table-condensed table-bordered"
                            runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvGroupMaster_PageIndexChanging"
                            OnRowCommand="GvGroupMaster_RowCommand">
                            <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                            <Columns>
                                <%-- <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                 <asp:Button ID="btnEdit" runat="server" CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("GROUP_CODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn btn-link btn-dark"></asp:Button>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                       <asp:Button ID="btnDelete" runat="server" CausesValidation="false" CommandName="Deletea" OnClientClick="return confirm('Are you sure you want to Delete the Group Master Record?');" CommandArgument='<%#Bind("GROUP_CODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn btn-link btn-dark"></asp:Button>
                                   </ItemTemplate>
                                </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="ACTION">
                                    <ItemTemplate>

                                        <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("GROUP_CODE") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>
                                        <asp:HiddenField ID="HfGROUP_CODE" runat="server" Value='<%#Bind("GROUP_CODE")%>' />

                                        <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("GROUP_CODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                        <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("GROUP_CODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>


                                    </ItemTemplate>
                                </asp:TemplateField>



                                <%--  <asp:TemplateField HeaderText="SR.NO.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField> --%>

                                <asp:TemplateField HeaderText="GROUP NAME">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdleftalign" ID="lblGroupName" runat="server" Text='<%#Bind("GROUP_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="GROUP TYPE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdleftalign" ID="lblGroupTypeName" runat="server" Text='<%#Bind("GROUP_TYPE_String") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--   <asp:TemplateField HeaderText="GROUP ORDER">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblGroupOrder" runat="server" Text='<%#Bind("GROUP_ORD") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                         <asp:TemplateField HeaderText="GROUP CODE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblGroupCode" runat="server" Text='<%#Bind("GROUP_CODE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="GROUP ORDER">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblGroupOrder" runat="server" Text='<%#Bind("GROUP_ORD") %>'></asp:Label>
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

                    <h4 class="modal-title">DELETE BRANCH</h4>
                </div>
                <div class="modal-body">


                    <span>Are you sure you want to delete...!!!</span>
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


    <div class="modal fade" tabindex="-1" id="CmpBranchSelection1" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">UPDATE GROUP MASTER</h4>
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

    <script type="text/javascript">
        function HideModel1() {
            $("#CmpBranchSelection1").modal('hide');
        }

        function ShowModel1() {

            $("#CmpBranchSelection1").modal('show');

        }
    </script>

</asp:Content>
