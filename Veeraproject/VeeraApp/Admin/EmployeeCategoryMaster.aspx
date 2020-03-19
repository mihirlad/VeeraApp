<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeCategoryMaster.aspx.cs" Inherits="VeeraApp.Admin.CategoryMaster" %>
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
                    <h4>EMPLOYEE CATEGORY MASTER</h4>
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


                        <div class="h5" style="color: brown">CATEGORY MASTER</div>
                        <div class="auto-style1">
                            <div class="col-md-5">
                                <asp:HiddenField ID="HfCategoryCode" runat="server" />
                              
                                <asp:Label CssClass="label" Text="Category Name" runat="server"></asp:Label>
                                <asp:TextBox ID="TxtCategoryName" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="TxtCategoryName" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>

                              <div class="col-md-1">
                              
                                <asp:Label CssClass="label" Text="Order" runat="server"></asp:Label>
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
                                <asp:Button ID="Btncalldel" runat="server" Text="DELETE"  OnClick="Btncalldel_Click" CssClass="btn btn-lg btn-primary btn-block" />
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
                                    <div class="h5" style="color: brown">CATEGORY LIST DEATILS</div>
                                    <asp:GridView ID="GvCategoryMaster" CssClass="table table-vcenter table-condensed table-bordered"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="false" ShowFooter="true" OnRowCommand="GvCategoryMaster_RowCommand"
                                        PageSize="10">
                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Selecta" CommandArgument='<%#Bind("CAT_CODE") %>' ToolTip="View" Text="SELECT" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="CATEGORY NAME" ControlStyle-Width="350px">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblCategoryName" runat="server" Text='<%#Bind("CAT_NAME") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                            
                                            <asp:TemplateField HeaderText="ORDER" ControlStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblOrder" runat="server" Text='<%#Bind("ORD_NO") %>'></asp:Label>
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
