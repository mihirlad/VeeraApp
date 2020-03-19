<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="User_Rights_Access.aspx.cs" Inherits="VeeraApp.User_Rights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .switch {
            position: relative;
            display: inline-block;
            width: 50px;
            height: 22px;
        }

            .switch input {
                display: none;
            }

        .slider {
            position: absolute;
            cursor: pointer;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: #ccc;
            -webkit-transition: .4s;
            transition: .4s;
        }

            .slider:before {
                position: absolute;
                content: "";
                height: 15px;
                width: 15px;
                left: 4px;
                bottom: 4px;
                background-color: white;
                -webkit-transition: .4s;
                transition: .4s;
            }

        input:checked + .slider {
            background-color: #2196F3;
        }

        input:focus + .slider {
            box-shadow: 0 0 1px #2196F3;
        }

        input:checked + .slider:before {
            -webkit-transform: translateX(26px);
            -ms-transform: translateX(26px);
            transform: translateX(26px);
        }

        /* Rounded sliders */
        .slider.round {
            border-radius: 34px;
        }

            .slider.round:before {
                border-radius: 50%;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="Sc1" runat="server"></asp:ScriptManager>
    <span style="float: right;">
        <asp:Label CssClass="label"  ID="lblmsg" runat="server"></asp:Label>
    </span>
    <div style="clear: both; height: 10px">
    </div>

    <div id="DivSelection" runat="server" class="grids">
        <div class="panel panel-widget top-grids">
            <asp:Button ID="btnCompany" Text="COMPANY" runat="server" CssClass="btn btn-lg btn-primary" OnClick="btnCompany_Click" />
            <asp:Button ID="btnBranch" Text="BRANCH" runat="server" OnClick="btnBranch_Click" CssClass="btn btn-lg btn-primary" />
            <asp:Button ID="btnYear" Text="YEAR" runat="server" OnClick="btnYear_Click" CssClass="btn btn-lg btn-primary" />
            <asp:Button ID="BtnMenuRight" Text="MENU RIGHTS" runat="server" Width="150px" OnClick="BtnMenuRight_Click" CssClass="btn btn-lg btn-primary" />
        </div>
    </div>


    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">

             <asp:UpdatePanel ID="updpanel" runat="server">
                                <ContentTemplate>

            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title">
                    <h4>USER RIGHTS</h4>
                </div>
                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">
                           

                            <div class="row col-md-12">
                                <div class="row col-md-1"></div>
                                <div class="row col-md-2">
                                    <asp:DropDownList ID="DdlUser" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlUser_OnSelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0" ForeColor="Red" ErrorMessage="*" ControlToValidate="DdlUser" ValidationGroup="ValidCompany"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row col-md-1"></div>
                                <div class="row col-md-3">
                                    <asp:DropDownList ID="DdlCompany" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlCompany_OnSelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">-- SELECT COMPANY --</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="row col-md-1"></div>
                                <div class="row col-md-2">
                                    <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlBranch_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">-- SELECT BRANCH --</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                
                            
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                                    
        </ContentTemplate>
     </asp:UpdatePanel>
        </div>
    </div>

    <div style="clear: both; height: 10px"></div>

    <div id="DivCompany" runat="server" class="grids">
        <asp:HiddenField ID="HfCOMP_CODE" runat="server" />
        <div class="progressbar-heading grids-heading">
            <h4>COMPANY LIST</h4>
        </div>

        <%-- <asp:HiddenField ID="HfGROUP_CODE" runat="server" />--%>


        <div id="DivView" runat="server" class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="table-responsive">
                    <asp:UpdatePanel ID="UpdateCompany" runat="server">
                        <ContentTemplate>


                            <asp:GridView ID="GridCompany" CssClass="table table-vcenter table-condensed table-bordered"
                                runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GridCompany_PageIndexChanging"
                                OnRowCommand="GridCompany_RowCommand" PageSize="10" OnRowDataBound="GridCompany_RowDataBound">
                                <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SR.NO." Visible="false">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--     <asp:TemplateField HeaderText="COMPANY CODE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblCompanyCode" runat="server" Text='<%#Bind("COMP_CODE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                                    <asp:TemplateField HeaderText="COMPANY NAME">
                                        <ItemTemplate>
                                            <asp:Label CssClass="label grdleftalign"  ID="lblCompanyName" runat="server" Text='<%#Bind("NAME") %>'></asp:Label>
                                            <asp:HiddenField ID="HfCOMP_CODE" runat="server" Value='<%#Bind("COMP_CODE")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="ACTION">
                                        <ItemTemplate>

                                            <label class="switch">
                                                <asp:CheckBox ID="chkCompany" runat="server" OnCheckedChanged="chkCompany_OnCheckedChanged" AutoPostBack="true" />
                                                <span class="slider round"></span>
                                            </label>

                                            <asp:Button ID="btnAdd" runat="server" CausesValidation="false" CommandName="Adda" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Add" Text="ADD" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>
                                            <asp:Button ID="btnRemove" runat="server" CausesValidation="false" CommandName="Removea" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Remove" Text="REMOVE" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>
                                            <%-- <asp:ImageButton ID="btnEdit1" runat="server" CausesValidation="false" ImageUrl="~/Images/edit.png"
                                        CommandName="Edita" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Edit" />--%>
                                            <%--    <asp:ImageButton ID="btnDelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to Delete the Recorder?');"
                                    ImageUrl="~/Images/cross.png" CommandName="Deletea" CommandArgument='<%#Bind("LoginId") %>' ToolTip="Delete" />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <%-- <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="chkCompany" EventName="OnCheckedChanged" />
                        </Triggers>--%>
                    </asp:UpdatePanel>
                </div>

            </div>
        </div>
    </div>

    <div id="DivBranch" runat="server" class="grids">
        <asp:HiddenField ID="HfBranch_Code" runat="server" />
        <div class="progressbar-heading grids-heading">
            <h4>BRANCH LIST</h4>
        </div>

        <div id="Div1" class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="table-responsive">
                    <asp:UpdatePanel ID="UpdateBranch" runat="server">
                        <ContentTemplate>

                            <asp:GridView ID="GridBranch" CssClass="table table-vcenter table-condensed table-bordered"
                                runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GridBranch_PageIndexChanging"
                                OnRowCommand="GridBranch_RowCommand" PageSize="10" >
                                <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SR.NO." Visible="false">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--     <asp:TemplateField HeaderText="COMPANY CODE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblCompanyCode" runat="server" Text='<%#Bind("COMP_CODE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> --%>

                                    <asp:TemplateField HeaderText="BRANCH NAME">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HfBranch_Code" runat="server" Value='<%#Bind("BRANCH_CODE")%>' />
                                            <asp:Label CssClass="label grdleftalign"  ID="lblBranchName" runat="server" Text='<%#Bind("BRANCH_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="DEFAULT">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkBranchDefault" runat="server" Checked='<%#Convert.ToBoolean(Eval("DEFAULT_FLAGBool")) %>' OnCheckedChanged="chkBranchDefault_CheckedChanged" AutoPostBack="true" />
                                            <%--  <asp:Label CssClass="label"  ID="lblDefault" runat="server" Text='<%#Bind("[DEFAULT_FLAG]") %>'></asp:Label>  --%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="APPROVAL">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkBranchApproval" runat="server" Checked='<%#Convert.ToBoolean(Eval("APPROVAL_FLAGBool")) %>' OnCheckedChanged="chkBranchApproval_CheckedChanged" AutoPostBack="true" />
                                            <%--   <asp:Label CssClass="label"  ID="lblApproval" runat="server" Text='<%#Bind("APPROVAL_FLAG") %>'></asp:Label> --%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="ACTION">
                                        <ItemTemplate>

                                            <label class="switch">
                                                <asp:CheckBox ID="chkBranch" runat="server" Checked='<%#Convert.ToBoolean(Eval("assign")) %>' OnCheckedChanged="chkBranch_OnCheckedChanged" AutoPostBack="true" />
                                                <span class="slider round"></span>
                                            </label>

                                            <asp:Button ID="btnAdd" runat="server" CausesValidation="false" CommandName="Adda" CommandArgument='<%#Bind("BRANCH_CODE") %>' ToolTip="Edit" Text="ADD" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>
                                            <asp:Button ID="btnRemove" runat="server" CausesValidation="false" CommandName="Removea" CommandArgument='<%#Bind("BRANCH_CODE") %>' ToolTip="Remove" Text="REMOVE" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>
                                            <%-- <asp:ImageButton ID="btnEdit1" runat="server" CausesValidation="false" ImageUrl="~/Images/edit.png"
                                        CommandName="Edita" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Edit" />--%>
                                            <%--    <asp:ImageButton ID="btnDelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to Delete the Recorder?');"
                                    ImageUrl="~/Images/cross.png" CommandName="Deletea" CommandArgument='<%#Bind("LoginId") %>' ToolTip="Delete" />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>



    <div id="DivYear" runat="server" class="grids">
        <asp:HiddenField ID="HfUser_Code" runat="server" />
        <div class="progressbar-heading grids-heading">
            <h4>YEAR LIST</h4>
        </div>


        <div id="Div2" runat="server" class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="table-responsive">
                    <asp:UpdatePanel ID="UpdateFinYear" runat="server">
                        <ContentTemplate>

                            <asp:GridView ID="GridYear" CssClass="table table-vcenter table-condensed table-bordered"
                                runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GridYear_PageIndexChanging"
                                OnRowCommand="GridYear_RowCommand" PageSize="10" OnRowDataBound="GridYear_RowDataBound">
                                <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SR.NO." Visible="false">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="COMPANY">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HfYRDT1" runat="server" Value='<%#Bind("YRDT1")%>' />
                                            <asp:Label CssClass="label grdleftalign"  ID="lblCompanyCode" runat="server" Text='<%#Bind("CompanyString") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="FINACIAL YEAR">
                                        <ItemTemplate>
                                            <asp:Label CssClass="label"  ID="lblStartDate" runat="server" Text='<%#Bind("YearString") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%-- <asp:TemplateField HeaderText="END DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblEndDate" runat="server" Text='<%#Bind("YRDT2") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>




                                    <asp:TemplateField HeaderText="ACTION">
                                        <ItemTemplate>

                                            <label class="switch">
                                                <asp:CheckBox ID="chkFinYear" runat="server" OnCheckedChanged="chkFinYear_OnCheckedChanged" AutoPostBack="true" />
                                                <span class="slider round"></span>
                                            </label>

                                            <asp:Button ID="btnAdd" runat="server" CausesValidation="false" CommandName="Adda" CommandArgument='<%#Bind("YRDT1") %>' ToolTip="Add" Text="ADD" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>
                                            <asp:Button ID="btnRemove" runat="server" CausesValidation="false" CommandName="Removea" CommandArgument='<%#Bind("YRDT1") %>' ToolTip="Remove" Text="REMOVE" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>
                                            <%--<asp:ImageButton ID="btnEdit1" runat="server" CausesValidation="false" ImageUrl="~/Images/edit.png"
                                        CommandName="Edita" CommandArgument='<%#Bind("COMP_CODE") %>' ToolTip="Edit" />--%>
                                            <%--    <asp:ImageButton ID="btnDelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to Delete the Recorder?');"
                                    ImageUrl="~/Images/cross.png" CommandName="Deletea" CommandArgument='<%#Bind("LoginId") %>' ToolTip="Delete" />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

    </div>



    <div style="clear: both; height: 10px"></div>
    <div class="col-md-12">
        <div class="col-md-4">
            <asp:Button ID="BtnExit" runat="server" OnClick="BtnExit_OnClick" Text="EXIT" CssClass="btn btn-lg btn-primary btn-block" />
        </div>
    </div>

</asp:Content>
