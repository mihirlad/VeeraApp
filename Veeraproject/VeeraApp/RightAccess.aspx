<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RightAccess.aspx.cs" Inherits="VeeraApp.RightAccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4 class="auto-style1">USER RIGHTS</h4>
        </div>

        <span style="float: right;">
            <asp:Label ID="lblmsg" runat="server"></asp:Label>
        </span>

        <asp:Button ID="btnCompany" Text="COMPANY" runat="server" OnClick="btnCompany_Click" />
        <asp:Button ID="btnBranch" Text="BRANCH" runat="server" OnClick="btnBranch_Click" />
        <asp:Button ID="btnYear" Text="YEAR" runat="server" OnClick="btnYear_Click" />

        <div class="auto-style1">
            <br />
            <br />

            <div class="auto-style1">

                <asp:DropDownList ID="DdlUser" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlUser_OnSelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0" ForeColor="Red" ErrorMessage="*" ControlToValidate="DdlUser" ValidationGroup="ValidCompany"></asp:RequiredFieldValidator>

                <asp:DropDownList ID="DdlCompany" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlCompany_OnSelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0">-- SELECT COMPANY --</asp:ListItem>
                </asp:DropDownList>

                <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlBranch_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0">-- SELECT BRANCH --</asp:ListItem>
                </asp:DropDownList>



            </div>
            <br />



        </div>

        <div id="DivCompany" runat="server" class="grids">
            <asp:HiddenField ID="HfCOMP_CODE" runat="server" />
            <div class="progressbar-heading grids-heading">
                <h4>COMPANY LIST</h4>
            </div>

            <div class="panel panel-widget top-grids">
                <div class="chute chute-center text-center">

                    <div class="table-responsive">
                        <asp:GridView ID="GridCompany" CssClass="table table-vcenter table-condensed table-bordered"
                            runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GridCompany_PageIndexChanging"
                            OnRowCommand="GridCompany_RowCommand" PageSize="10" Width="500px" OnRowDataBound="GridCompany_RowDataBound">
                            <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                            <Columns>
                                <asp:TemplateField HeaderText="SR.NO.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                        <asp:HiddenField ID="HfCOMP_CODE" runat="server" Value='<%#Bind("COMP_CODE")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--  <asp:TemplateField HeaderText="COMPANY CODE">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompanyCode" runat="server" Text='<%#Bind("COMP_CODE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="COMPANY NAME">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompanyName" runat="server" Text='<%#Bind("NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>

                                        <asp:Button ID="btnAdd" runat="server" CausesValidation="false" CommandName="Adda" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Add" Text="ADD" CssClass="btn btn-link btn-dark"></asp:Button>
                                        <asp:Button ID="btnRemove" runat="server" CausesValidation="false" CommandName="Removea" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Remove" Text="REMOVE" CssClass="btn btn-link btn-dark"></asp:Button>
                                        <%-- <asp:ImageButton ID="btnEdit1" runat="server" CausesValidation="false" ImageUrl="~/Images/edit.png"
                                        CommandName="Edita" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Edit" />--%>
                                        <%--    <asp:ImageButton ID="btnDelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to Delete the Recorder?');"
                                    ImageUrl="~/Images/cross.png" CommandName="Deletea" CommandArgument='<%#Bind("LoginId") %>' ToolTip="Delete" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </div>


        <div id="DivBranch" runat="server" class="grids">
            <asp:HiddenField ID="HfBranch_Code" runat="server" />
            <div class="progressbar-heading grids-heading">
                <h4>BRANCH LIST</h4>
            </div>

            <div class="panel panel-widget top-grids">
                <div class="chute chute-center text-center">

                    <div class="table-responsive">
                        <asp:GridView ID="GridBranch" CssClass="table table-vcenter table-condensed table-bordered"
                            runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GridBranch_PageIndexChanging"
                            OnRowCommand="GridBranch_RowCommand" PageSize="10" Width="500px" OnRowDataBound="GridBranch_RowDataBound">
                            <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                            <Columns>
                                <asp:TemplateField HeaderText="SR.NO.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                        <asp:HiddenField ID="HfBranch_Code" runat="server" Value='<%#Bind("BRANCH_CODE")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--     <asp:TemplateField HeaderText="COMPANY CODE">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompanyCode" runat="server" Text='<%#Bind("COMP_CODE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> --%>

                                <asp:TemplateField HeaderText="BRANCH NAME">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBranchName" runat="server" Text='<%#Bind("BRANCH_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>

                                        <asp:Button ID="btnAdd" runat="server" CausesValidation="false" CommandName="Adda" CommandArgument='<%#Bind("BRANCH_CODE") %>' ToolTip="Edit" Text="ADD" CssClass="btn btn-link btn-dark"></asp:Button>
                                        <asp:Button ID="btnRemove" runat="server" CausesValidation="false" CommandName="Removea" CommandArgument='<%#Bind("BRANCH_CODE") %>' ToolTip="Remove" Text="REMOVE" CssClass="btn btn-link btn-dark"></asp:Button>
                                        <%-- <asp:ImageButton ID="btnEdit1" runat="server" CausesValidation="false" ImageUrl="~/Images/edit.png"
                                        CommandName="Edita" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Edit" />--%>
                                        <%--    <asp:ImageButton ID="btnDelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to Delete the Recorder?');"
                                    ImageUrl="~/Images/cross.png" CommandName="Deletea" CommandArgument='<%#Bind("LoginId") %>' ToolTip="Delete" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </div>



        <div id="DivYear" runat="server" class="grids">
            <asp:HiddenField ID="HfUser_Code" runat="server" />
            <div class="progressbar-heading grids-heading">
                <h4>YEAR LIST</h4>
            </div>

            <div class="panel panel-widget top-grids">
                <div class="chute chute-center text-center">

                    <div class="table-responsive">
                        <asp:GridView ID="GridYear" CssClass="table table-vcenter table-condensed table-bordered"
                            runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GridYear_PageIndexChanging"
                            OnRowCommand="GridYear_RowCommand" PageSize="10" Width="500px" OnRowDataBound="GridYear_RowDataBound">
                            <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                            <Columns>
                                <asp:TemplateField HeaderText="SR.NO.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                        <asp:HiddenField ID="HfYRDT1" runat="server" Value='<%#Bind("YRDT1")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="COMPANY">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompanyCode" runat="server" Text='<%#Bind("CompanyString") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="FINNACIAL YEAR">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStartDate" runat="server" Text='<%#Bind("YearString") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%-- <asp:TemplateField HeaderText="END DATE">
                                <ItemTemplate>
                                    <asp:Label ID="lblEndDate" runat="server" Text='<%#Bind("YRDT2") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>




                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>

                                        <asp:Button ID="btnAdd" runat="server" CausesValidation="false" CommandName="Adda" CommandArgument='<%#Bind("YRDT1") %>' ToolTip="Add" Text="ADD" CssClass="btn btn-link btn-dark"></asp:Button>
                                        <asp:Button ID="btnRemove" runat="server" CausesValidation="false" CommandName="Removea" CommandArgument='<%#Bind("YRDT1") %>' ToolTip="Remove" Text="REMOVE" CssClass="btn btn-link btn-dark"></asp:Button>
                                        <%--<asp:ImageButton ID="btnEdit1" runat="server" CausesValidation="false" ImageUrl="~/Images/edit.png"
                                        CommandName="Edita" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Edit" />--%>
                                        <%--    <asp:ImageButton ID="btnDelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to Delete the Recorder?');"
                                    ImageUrl="~/Images/cross.png" CommandName="Deletea" CommandArgument='<%#Bind("LoginId") %>' ToolTip="Delete" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </div>

    </form>
</body>
</html>
