<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="PersonMaster.aspx.cs" Inherits="VeeraApp.BrokerMaster" %>
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
                    <h4>PERSON INFORMATION MASTER</h4>
                </div>
            </div>
        </div>
    </div>


<%--    <div style="clear: both; height: 10px">
    </div>--%>
    <asp:HiddenField ID="HfCompCode" runat="server" />
    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">

                  <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">
                            <div class="col-md-12">
                               
                                <div class="col-md-3">
                                    <asp:Label CssClass="label"  Text="Person Name" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtPersonName" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtPersonName" runat="server"
                                         ControlToValidate="TxtPersonName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                 <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Address" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtAddress1" CssClass="form-control" runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtAddress1" runat="server"
                                         ControlToValidate="TxtAddress1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                 <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Phone(O)" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtPhoneO" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Phone(M)" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtPhoneM" CssClass="form-control" runat="server"></asp:TextBox>
                                     <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldTxtPhoneM" runat="server"
                                                                ControlToValidate="TxtPhoneM" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                </div>

                             <div style="clear: both; height: 10px">
                            </div>

                            <div class="col-md-12">
                                  <asp:UpdatePanel ID="UpdatePanelBranch" runat="server">
                                    <ContentTemplate>

                                     <%--<div class="col-md-2">
                                    <asp:Label CssClass="label"  Text="Company Name" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlCompany" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlCompany_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                     <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldDdlCompany" runat="server" InitialValue="0"
                                                                 ControlToValidate="DdlCompany" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>--%>
                                <div class="col-md-2">
                                    <asp:Label CssClass="label"  Text="Branch Name" ForeColor="Blue" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlBranch" runat="server" ForeColor="Blue" CssClass="form-control">
                                      <%--  <asp:ListItem Value="0"></asp:ListItem>--%>
                                       </asp:DropDownList>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldDdlBranch" runat="server" InitialValue="0"
                                                                 ControlToValidate="DdlBranch" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                  </ContentTemplate>
                                </asp:UpdatePanel>

                                <div class="col-md-2">
                                    <asp:Label CssClass="label"  Text="Active" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlActive" runat="server" CssClass="form-control">
                                          <asp:ListItem Value="Y">YES</asp:ListItem>
                                         <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                        </asp:DropDownList>
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
       

           <div style="float:right;">
                <asp:Label CssClass="label" style="color:red;" Text="Search By Person Name/Phone No./Company Name" runat="server"></asp:Label>
                <asp:TextBox ID="TxtSearch" CssClass="form-control" runat="server" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>

          </div>
            <div style="clear: both; height: 10px"></div>

        <asp:HiddenField ID="HfBCode" runat="server" />

          <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                  <div class="table-responsive">
                    <asp:GridView ID="GvPersonMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvPersonMaster_PageIndexChanging" OnRowCommand="GvPersonMaster_RowCommand"
                         PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                             <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("BCODE") %>'  ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <asp:HiddenField ID="HfBCode" runat="server" Value='<%#Bind("BCODE")%>' />

                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("BCODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("BCODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                </ItemTemplate>
                           </asp:TemplateField>

                           <%--<asp:TemplateField HeaderText="SR.NO.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                            </asp:TemplateField> --%>
                            <asp:TemplateField HeaderText="PERSON NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblPersonName" runat="server" Text='<%#Bind("BNAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%--  <asp:TemplateField HeaderText="ACTIVE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblActive" runat="server" Text='<%#Bind("ACTIVE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                              <asp:TemplateField HeaderText="ADDRESS">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblAddress" runat="server" Text='<%#Bind("BADD") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="PHONE (O)">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblPHONE_O" runat="server" Text='<%#Bind("PHONE_O") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="PHONE (M)">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblPHONE_M" runat="server" Text='<%#Bind("PHONE_M") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="COMPANY NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblCompanyName" runat="server" Text='<%#Bind("CompanyName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="BRANCH NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblBranchName" runat="server" Text='<%#Bind("BranchName") %>'></asp:Label>
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
                        
                        <h4 class="modal-title">DELETE PERSON DETAIL</h4>
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
                        
                        <h4 class="modal-title">UPDATE PERSON DETAIL</h4>
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
