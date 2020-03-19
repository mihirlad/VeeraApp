<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="UserMaster.aspx.cs" Inherits="VeeraApp.UserMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="SM1" runat="server"></asp:ScriptManager>
    <div class="grids">
        <div class="progressbar-heading grids-heading">

            <span style="float: right;">
                <asp:Label CssClass="label"  ID="lblmsg" runat="server"></asp:Label>
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
                    <h4>USER INFORMATION </h4>
                </div>
            </div>
        </div>
    </div>
    <%--Insert Button END--%>


    <div class="panel panel-widget forms-panel">
        <%--Entry Panel BEGIN--%>
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <%-- <div class="form-title">
                    <h4>USER INFORMATION :</h4>
                </div>--%>
                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">
                            <div class="col-md-12">

                                <%-- <div class="col-md-2">
                                    <asp:TextBox id="TxtUserCode" cssclass="form-control" runat="server" placeholder="USER CODE"></asp:TextBox>
                                 </div>--%>

                                <div class="col-md-3">
                                    <asp:Label CssClass="label"  Text="User Name" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="TxtUserName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label CssClass="label"  Text="User Password" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtUserPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="TxtUserPassword" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label CssClass="label"  Text="User Type" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlUserType" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                        <asp:ListItem Value="S">SUPERVISOR</asp:ListItem>
                                        <asp:ListItem Value="O">OPERATOR</asp:ListItem>
                                        <asp:ListItem Value="A">AUTHORISED</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" InitialValue="0"
                                        ControlToValidate="DdlUserType" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>


                                <div class="col-md-2">
                                    <asp:Label CssClass="label"  Text="Select Type" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlUserActive" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="Y">ACTIVE</asp:ListItem>
                                        <asp:ListItem Value="N">INACTIVE</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <%--  <div class="col-md-3">
                                    <asp:TextBox id="TxtDeActivateDate" cssclass="form-control" runat="server" placeholder="DE-ACTIVE-DATE"></asp:TextBox>
                                 </div> --%>

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
                                        <asp:Button ID="Btncalldel" Text="DELETE" OnClick="Btncalldel_Click" runat="server" CssClass="btn btn-lg btn-primary btn-block " />
                                        
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--Entry Panel END--%>




        <%--View BEGIN--%>
        <div id="DivView" runat="server" class="panel panel-widget top-grids">

            <div class="panel panel-widget top-grids">
                <asp:Button ID="BtnAdd" runat="server" Text="NEW" OnClick="BtnAdd_OnClick" CssClass="btn btn-lg btn-primary" />
                <asp:Button runat="server" Text="Exit" ID="BtnExit" OnClick="BtnExit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />
            </div>
            <div style="clear: both; height: 10px"></div>

            <asp:HiddenField ID="HfUSER_CODE" runat="server" />

            <div class="panel panel-widget top-grids">
                <div class="chute chute-center text-center">

                    <div class="table-responsive">
                        <asp:GridView ID="GvUserMas" CssClass="table table-vcenter table-condensed table-bordered"
                            runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvUserMas_PageIndexChanging"
                            OnRowCommand="GvUserMas_RowCommand" PageSize="10">
                            <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                            <Columns>
                                <%-- <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                     <asp:Button ID="btnEdit" runat="server" CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("USERCODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn btn-link btn-dark"></asp:Button>
                                   </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                       <asp:Button ID="btnDelete" runat="server" CausesValidation="false" CommandName="Deletea" OnClientClick="return confirm('Are you sure you want to Delete the User Record?');" CommandArgument='<%#Bind("USERCODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn btn-link btn-dark"></asp:Button>
                                 </ItemTemplate>
                                </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="ACTION">
                                    <ItemTemplate>
                                        <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("USERCODE") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>
                                        <asp:HiddenField ID="HfUSER_CODE" runat="server" Value='<%#Bind("USERCODE")%>' />

                                        <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita"  CommandArgument='<%#Bind("USERCODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                        <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("USERCODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    </ItemTemplate>
                                </asp:TemplateField>


                                <%--      <asp:TemplateField HeaderText="SR.NO.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                
                                <asp:TemplateField HeaderText="USER NAME">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdleftalign"  ID="lblUserName" runat="server" Text='<%#Bind("USERNAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="USER TYPE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdleftalign"  ID="lblUserType" runat="server" Text='<%#Bind("USERTYPE_String") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ACTIVE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdcenteralign"  ID="lblUserActive" runat="server" Text='<%#Bind("ACTIVE_String") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="USER PASSWORD">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblUserPassword" runat="server" Text='<%#Bind("USERPASS") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="USER TYPE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label"  ID="lblUserType" runat="server" Text='<%#Bind("USERTYPE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="DEACTIVE DATE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label"  ID="lblUserDeActiveDate" runat="server" Text='<%#Bind("DEACTIVE_DATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <%--View END--%>
    </div>


     <script src="js/proton.js"></script>


        <div class="modal fade" tabindex="-1" id="CmpBranchSelection" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        
                        <h4 class="modal-title">DELETE USER DETAIL</h4>
                    </div>
                    <div class="modal-body">
                               
                       <span>Are you sure you want to delete...!!!</span>
                      <br />
                      
                         <div id="Div1" runat="server" class="grids">

                      <div class="panel panel-widget top-grids">
                          <asp:Button ID="btnDelete" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnDelete_click" CausesValidation="false" />
                          <button type="button" class="btn btn-lg btn-primary"  data-dismiss="modal" value="NO">NO</button>
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
                        
                        <h4 class="modal-title">UPDATE USER DETAIL</h4>
                    </div>
                    <div class="modal-body">
                        
                        
                       <span>Are you sure want to update...!!!</span>
                      <br />
                      
                         <div id="Div2" runat="server" class="grids">

                      <div class="panel panel-widget top-grids">
                          <asp:Button ID="btnSave" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnSave_click" />
                                                 
                           <button type="button" class="btn btn-lg btn-primary"  data-dismiss="modal" value="NO">NO</button>
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

<%--    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="../quicksearch.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.search_textbox').each(function (i) {
                $(this).quicksearch("[id*=GvUserMas] tr:not(:has(th))", {
                    'testQuery': function (query, txt, row) {
                        return $(row).children(":eq(" + i + ")").text().toLowerCase().indexOf(query[0].toLowerCase()) != -1;
                    }
                });
            });
        });
    </script>
    <style> 
::placeholder { /* Firefox, Chrome, Opera */ 
    color: blue; 
} 
  
:-ms-input-placeholder { /* Internet Explorer 10-11 */ 
    color: red; 
} 
  
::-ms-input-placeholder { /* Microsoft Edge */ 
    color: orange; 
} 
</style> --%>
</asp:Content>
