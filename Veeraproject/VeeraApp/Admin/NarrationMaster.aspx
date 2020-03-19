<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="NarrationMaster.aspx.cs" Inherits="VeeraApp.Admin.NarrationMaster" %>

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
                    <h4>NARRATIONS DATA</h4>
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
                            <div class="col-md-12">
                                <asp:Label CssClass="label" Text="Types Of Narrations" runat="server"></asp:Label>
                                <asp:TextBox ID="TxtNarrations" CssClass="form-control" runat="server"></asp:TextBox>

                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="TxtNarrations" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                        </div>


                        
                          <div style="clear: both; height: 20px;">
                          </div>


                        <div class="col-md-12">
                            <div class="col-md-2 bs-component mb10">
                                <asp:Button ID="BtnSave" Text="INSERT" runat="server" OnClick="BtnSave_Click" CssClass="btn btn-lg btn-primary btn-block" />
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
                                    <div class="h5" style="color: brown">NARRATION DEATILS</div>
                                    <asp:GridView ID="GvNarrationDetails" CssClass="table table-vcenter table-condensed table-bordered" OnRowCommand="GvNarrationDetails_RowCommand"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="false" ShowFooter="true"
                                        PageSize="10">
                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Selecta" CommandArgument='<%#Bind("NARRN") %>' ToolTip="View" Text="SELECT" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="NARRATIONS" ControlStyle-Width="350px">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblWorkDescription" runat="server" Text='<%#Bind("NARRN") %>'></asp:Label>
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
