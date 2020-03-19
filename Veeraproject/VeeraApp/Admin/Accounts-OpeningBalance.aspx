<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="Accounts-OpeningBalance.aspx.cs" Inherits="VeeraApp.Accounts_Opening_Balance" %>

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
                    <h4>ACCOUNTS OPENING BALANCE</h4>
                </div>
            </div>
        </div>
    </div>

    <div style="clear: both; height: 10px">
    </div>

    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">

                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">
                             <asp:UpdatePanel ID="updacc" runat="server">
                                <ContentTemplate>
                            <div class="col-md-12">
                                
                                <div class="col-md-3">
                                   

                                    <asp:Label CssClass="label" Text="Name Of The Accounts" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlAccountName" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlAccountName_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                      <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" InitialValue="0"
                                        ControlToValidate="DdlAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3">
                                    <%--<asp:Label CssClass="label" Text="Accounts Group Name:-" Font-Bold="true" runat="server"></asp:Label>
                                    <asp:Label ID="lblAccountGroupName" Font-Bold="true" ForeColor="#3333cc" runat="server"> </asp:Label> --%>


                                     <asp:Label CssClass="label" Text="Accounts Group Name" runat="server"></asp:Label>
                                    <asp:TextBox ID="lblAccountGroupName" CssClass="form-control" runat="server"></asp:TextBox>


                                </div>
                              
                                <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Opening Balance" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtOpeningBal" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label CssClass="label" Text="Balance Type" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DdlAccountType" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                        <asp:ListItem Value="D">DEBIT</asp:ListItem>
                                        <asp:ListItem Value="C">CREDIT</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" InitialValue="0"
                                        ControlToValidate="DdlAccountType" ForeColor="Red">*</asp:RequiredFieldValidator>
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

             <div style="float:right;">
             <asp:Label CssClass="label" style="color:red;" Text="Search By Account Name" runat="server"></asp:Label><br />
              <asp:TextBox ID="TxtSearch"  runat="server" style="width: 100%;" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>

        </div>

        <%-- <div class="col-md-3">
                <asp:Label CssClass="label" Text="Search By Account Name" runat="server"></asp:Label>
                <asp:TextBox ID="TxtSearch" CssClass="form-control" runat="server" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
         </div>--%>

            <div style="clear: both; height: 10px"></div>

        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfAccountCode" runat="server" />
        <asp:HiddenField ID="HfYRDT1" runat="server" />
        <asp:HiddenField ID="HfStatus" runat="server" />

        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">
                
               <div class="table-responsive" style="height: 500px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvAccOpenBal" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvAccOpenBal_PageIndexChanging" OnRowCommand="GvAccOpenBal_RowCommand"
                        PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                            <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("ACODE") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <asp:HiddenField ID="HfCompCode" runat="server" Value='<%#Bind("COMP_CODE")%>' />
                                  
                                    <asp:HiddenField ID="HfYRDT1" runat="server" Value='<%#Bind("YRDT1")%>' />

                                    <asp:HiddenField ID="HfAccountCode" runat="server" Value='<%#Bind("ACODE")%>' />



                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("ACODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("ACODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="NAME OF ACCOUNTS">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblAccountName" runat="server" Text='<%#Bind("AccountName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="ACCOUNTS GROUP">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblAccounGrouptName" runat="server" Text='<%#Bind("GROUP_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ACCOUNT TYPE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblAccType" runat="server" Text='<%#Bind("ATYPE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
             </div>
           </div>
        </div>
    </div>

      <div class="modal fade" tabindex="-1" id="CmpDeleteSelection" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">DELETE ACCOUNT OPENING BALANCE</h4>
                </div>
                <div class="modal-body">


                    <span>Are you sure want to delete...!!!</span>
                    <br />

                    <div id="Div2" runat="server" class="grids">

                        <div class="panel panel-widget top-grids">

                            <asp:Button ID="btnDelete" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnDelete_Click" CausesValidation="false" />
                            <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">NO</button>
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

                    <h4 class="modal-title">UPDATE ACCOUNT OPENING BALANCE</h4>
                </div>
                <div class="modal-body">


                    <span>Are you sure want to update...!!!</span>
                    <br />

                    <div id="Div3" runat="server" class="grids">

                        <div class="panel panel-widget top-grids">
                            <asp:Button ID="btnSave" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnSave_Click" />
                            <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">NO</button>
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
