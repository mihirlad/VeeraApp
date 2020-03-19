<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="DesignationMaster.aspx.cs" Inherits="VeeraApp.Admin.DesignationMaster" %>

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
                    <h4>WORK LIST MASTER</h4>
                </div>
            </div>
        </div>
    </div>

    <%--  <div style="clear: both; height: 10px">
    </div>--%>


     <div class="form-body">
        <div class="form-horizontal form-bordered">
            <div class="form-group" style="border-bottom: none;">

                <asp:UpdatePanel ID="UpdPnl" runat="server">
                    <ContentTemplate>


                        <div class="h5" style="color: brown">BASIC DETAILS</div>
                        <div class="auto-style1">
                            <div class="col-md-6">
                                <asp:HiddenField ID="HfDesignCode" runat="server" />
                              
                                <asp:Label CssClass="label" Text="Designation Name" runat="server"></asp:Label>
                                <asp:TextBox ID="TxtDesignationName" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="TxtDesignationName" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-3">
                                <asp:Label CssClass="label" Text="Job Category" runat="server"></asp:Label>
                                <asp:DropDownList ID="DdlJobCategory" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">SELECT TYPE </asp:ListItem>
                                    <asp:ListItem Value="O">OFFICE</asp:ListItem>
                                    <asp:ListItem Value="M">MARKETING</asp:ListItem>
                                    <asp:ListItem Value="T">TECHNICIAN</asp:ListItem>
                                    <asp:ListItem Value="G">GENERAL</asp:ListItem>
           
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldDdlCompanyType" runat="server"
                                    InitialValue="0" ControlToValidate="DdlJobCategory" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>

                              <div class="col-md-1">
                              
                                <asp:Label CssClass="label" Text="Ord" runat="server"></asp:Label>
                                <asp:TextBox ID="TxtOrder" CssClass="form-control" runat="server"></asp:TextBox>
                              
                            </div>

                        </div>
                        </div>
                      </div>

                         <div style="clear: both; height: 20px;">
                          </div>


                        <div class="col-md-12">
                            <div class="col-md-2 bs-component mb10">
                                <asp:Button ID="BtnSave" Text="INSERT" runat="server" OnClick="BtnSave_Click" CssClass="btn btn-lg btn-primary btn-block" />
                            </div>
                            <div class="col-md-2 bs-component mb10">
                                <asp:Button ID="BtncallUpd" Text="UPDATE" runat="server" OnClick="BtncallUpd_Click" CssClass="btn btn-lg btn-primary btn-block" />
                            </div>

                            <div class="col-md-2 bs-component mb10">
                                <asp:Button ID="Btncalldel" runat="server" Text="DELETE" OnClick="Btncalldel_Click" CssClass="btn btn-lg btn-primary btn-block" />
                            </div>

                            <div class="col-md-2 bs-component mb10">
                                <asp:Button ID="btnClear" runat="server" Text="EXIT" OnClick="btnClear_Click" CssClass="btn btn-lg btn-primary btn-block"
                                    CausesValidation="false" />
                            </div>

                            <div class="col-md-2 bs-component mb10">
                                <asp:Button ID="BtnClearData" runat="server" Text="CLEAR DATA" OnClick="BtnClearData_Click" CssClass="btn btn-lg btn-primary btn-block"
                                    CausesValidation="false" />
                            </div>
                        </div>



                        <div style="clear: both; height: 10px;">
                        </div>

                        
                        <div class="panel panel-widget top-grids">
                            <div class="chute chute-center text-center">

                                <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                    <div class="h5" style="color: brown">DESIGNATION LIST DEATILS</div>
                                    <asp:GridView ID="GvDesignationMaster" CssClass="table table-vcenter table-condensed table-bordered"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="false" ShowFooter="true" OnRowCommand="GvDesignationMaster_RowCommand"
                                        PageSize="10">
                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Selecta" CommandArgument='<%#Bind("DESIGN_CODE") %>' ToolTip="View" Text="SELECT" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="DESIGNATION NAME" ControlStyle-Width="350px">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblDesignationName" runat="server" Text='<%#Bind("DESIGN_NAME") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="JOB CATEGORY" ControlStyle-Width="150px">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblJobCategory" runat="server" Text='<%#Bind("JOB_CATCODE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ORDER" ControlStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblOrder" runat="server" Text='<%#Bind("DESIGN_ORD") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="CREATED BY" ControlStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblCreatedBy" runat="server" Text='<%#Bind("INS_USERID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="CREATED DATE" ControlStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblCreatedDate" runat="server" Text='<%#Bind("INS_DATE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="UPDATED BY" ControlStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblUpdatedBy" runat="server" Text='<%#Bind("UPD_USERID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="UPDATED Date" ControlStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblUpdatedDate" runat="server" Text='<%#Bind("UPD_DATE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>



                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>


                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>


</asp:Content>
