<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="Menu_Rights.aspx.cs" Inherits="VeeraApp.Menu_Rights" %>

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
                    <h4>MENU RIGHTS</h4>
                </div>
            </div>
        </div>
    </div>

   <%-- <div style="clear: both; height: 10px">
    </div>--%>

    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">

               <asp:UpdatePanel ID="updpanel" runat="server">
                             <ContentTemplate>
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">

                            <div class="col-md-12">
                                <div class="col-md-3">
                                    <asp:DropDownList ID="DdlCompany" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlCompany_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">-- SELECT COMPANY --</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="DdlUser" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlUser_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0" ForeColor="Red" ErrorMessage="*" ControlToValidate="DdlUser" ValidationGroup="ValidCompany"></asp:RequiredFieldValidator>
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


    <div id="DivView" runat="server" class="panel panel-widget top-grids">
        <div class="chute chute-center text-center">

            <div class="table-responsive">
                <asp:UpdatePanel ID="updGRID" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridMainMenu" CssClass="table table-vcenter table-condensed table-bordered"
                            runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GridMainMenu_PageIndexChanging"
                            PageSize="10">
                            <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                            <Columns>
                                <asp:TemplateField HeaderText="SR.NO." Visible="true">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="CODE" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="lblCode" runat="server" Text='<%#Bind("CODE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="MENU NAME">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label grdleftalign" ID="lblCompanyName" runat="server" Text='<%#Bind("NAME") %>'></asp:Label>
                                        <asp:HiddenField ID="HfCODE" runat="server" Value='<%#Bind("CODE")%>' />
                                        <asp:HiddenField ID="HfSYSCODE" runat="server" Value='<%#Bind("SYSCODE")%>' />
                                        <asp:HiddenField ID="HfREF_CODE" runat="server" Value='<%#Bind("REF_CODE")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="VIEW">
                                    <ItemTemplate>

                                        <label class="switch">
                                            <asp:CheckBox ID="chkMenuView" runat="server" Checked='<%#Eval("MENU_VIEW").ToString()=="Y"?true:false %>' />
                                            <span class="slider round"></span>
                                        </label>
                                        <asp:Button ID="btnViewAdd" runat="server" CausesValidation="false" CommandName="ViewAdda" CommandArgument='<%#Bind("CODE") %>' ToolTip="Add" Text="ADD" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>
                                        <asp:Button ID="btnViewRemove" runat="server" CausesValidation="false" CommandName="ViewRemovea" CommandArgument='<%#Bind("CODE") %>' ToolTip="Remove" Text="REMOVE" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="INSERT">
                                    <ItemTemplate>

                                        <label class="switch">
                                            <asp:CheckBox ID="chkMenuInsert" runat="server" Checked='<%#Eval("REC_INS").ToString()=="Y"?true:false %>' />
                                            <span class="slider round"></span>
                                        </label>
                                        <asp:Button ID="btnInsertAdd" runat="server" CausesValidation="false" CommandName="InsertAdda" CommandArgument='<%#Bind("CODE") %>' ToolTip="Add" Text="ADD" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>
                                        <asp:Button ID="btnInsertRemove" runat="server" CausesValidation="false" CommandName="InsertRemovea" CommandArgument='<%#Bind("CODE") %>' ToolTip="Remove" Text="REMOVE" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="UPDATE">
                                    <ItemTemplate>

                                        <label class="switch">
                                            <asp:CheckBox ID="chkMenuUpdate" runat="server" Checked='<%#Eval("REC_UPD").ToString()=="Y"?true:false %>' />
                                            <span class="slider round"></span>
                                        </label>
                                        <asp:Button ID="btnUpdateAdd" runat="server" CausesValidation="false" CommandName="UpdateAdda" CommandArgument='<%#Bind("CODE") %>' ToolTip="Add" Text="ADD" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>
                                        <asp:Button ID="btnUpdateRemove" runat="server" CausesValidation="false" CommandName="UpdateRemovea" CommandArgument='<%#Bind("CODE") %>' ToolTip="Remove" Text="REMOVE" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="DELETE">
                                    <ItemTemplate>

                                        <label class="switch">
                                            <asp:CheckBox ID="chkMenuDelete" runat="server" Checked='<%#Eval("REC_DEL").ToString()=="Y"?true:false %>' />
                                            <span class="slider round"></span>
                                        </label>
                                        <asp:Button ID="btnDeleteAdd" runat="server" CausesValidation="false" CommandName="DeleteAdda" CommandArgument='<%#Bind("CODE") %>' ToolTip="Add" Text="ADD" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>
                                        <asp:Button ID="btnDeleteRemove" runat="server" CausesValidation="false" CommandName="DeleteRemovea" CommandArgument='<%#Bind("CODE") %>' ToolTip="Remove" Text="REMOVE" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="UNCONFIRM">
                                    <ItemTemplate>

                                        <label class="switch">
                                            <asp:CheckBox ID="chkUnConfirm" runat="server" Checked='<%#Eval("UNCONFIRM").ToString()=="Y"?true:false %>' />
                                            <span class="slider round"></span>
                                        </label>
                                        <asp:Button ID="btnUnformAdd" runat="server" CausesValidation="false" CommandName="DeleteAdda" CommandArgument='<%#Bind("CODE") %>' ToolTip="Add" Text="ADD" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>
                                        <asp:Button ID="btnUnformRemove" runat="server" CausesValidation="false" CommandName="DeleteRemovea" CommandArgument='<%#Bind("CODE") %>' ToolTip="Remove" Text="REMOVE" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="APPROVAL">
                                    <ItemTemplate>

                                        <label class="switch">
                                            <asp:CheckBox ID="chkApproval" runat="server" Checked='<%#Eval("APPROVAL").ToString()=="Y"?true:false %>' />
                                            <span class="slider round"></span>
                                        </label>
                                        <asp:Button ID="btnApprovalAdd" runat="server" CausesValidation="false" CommandName="DeleteAdda" CommandArgument='<%#Bind("CODE") %>' ToolTip="Add" Text="ADD" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>
                                        <asp:Button ID="btnApprovaleRemove" runat="server" CausesValidation="false" CommandName="DeleteRemovea" CommandArgument='<%#Bind("CODE") %>' ToolTip="Remove" Text="REMOVE" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="AUTHORISE">
                                    <ItemTemplate>

                                        <label class="switch">
                                            <asp:CheckBox ID="chkAuthorise" runat="server" Checked='<%#Eval("AUTHORISE").ToString()=="Y"?true:false %>' />
                                            <span class="slider round"></span>
                                        </label>
                                        <asp:Button ID="btnAuthoriseAdd" runat="server" CausesValidation="false" CommandName="DeleteAdda" CommandArgument='<%#Bind("CODE") %>' ToolTip="Add" Text="ADD" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>
                                        <asp:Button ID="btnAuthoriseRemove" runat="server" CausesValidation="false" CommandName="DeleteRemovea" CommandArgument='<%#Bind("CODE") %>' ToolTip="Remove" Text="REMOVE" CssClass="btn btn-link btn-dark" Visible="false"></asp:Button>

                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

     <div class="panel panel-widget forms-panel">
        <div id="Div1" runat="server" class="forms">

            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">

                         
                           <div class="col-md-3">
                                <asp:Button ID="btnSAVE" runat="server" OnClick="btnSAVE_Click" Text="SAVE" CssClass="btn btn-lg btn-primary btn-block" />

                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="btnEXIT" runat="server" OnClick="btnEXIT_Click" Text="EXIT" CssClass="btn btn-lg btn-primary btn-block" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
