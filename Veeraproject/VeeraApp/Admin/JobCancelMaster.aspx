<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="JobCancelMaster.aspx.cs" Inherits="VeeraApp.Admin.JobCancelMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="SM1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdPnl" runat="server">
        <ContentTemplate>
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
                            <h4>JOB CANCEL MASTER</h4>
                        </div>
                    </div>
                </div>
            </div>

            <div class="form-body">
                <div class="form-horizontal form-bordered">
                    <div class="form-group" style="border-bottom: none;">


                        <%--     <div class="h5" style="color: brown">JOB CARD DETAILS</div>--%>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:HiddenField ID="HfCancelCode" runat="server" />
                                <asp:HiddenField ID="HfCompCode" runat="server" />
                                <asp:Label CssClass="label" Text="Cancel Description" runat="server"></asp:Label>
                                <asp:TextBox TextMode="MultiLine" ID="TxtCancelDescrption" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="TxtCancelDescrption" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                    <div class="h5" style="color: brown">JOB CANCLE DETAILS</div>
                                    <asp:GridView ID="GvJobCancleDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                        runat="server" AutoGenerateColumns="false" AllowPaging="false" ShowFooter="true" OnRowCommand="GvJobCancleDetails_RowCommand"
                                        PageSize="10">
                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Selecta" CommandArgument='<%#Bind("cancel_code") %>' ToolTip="View" Text="SELECT" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="WORK DESCRIPTION" ControlStyle-Width="350px">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblWorkDescription" runat="server" Text='<%#Bind("cancel_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="CREATED BY" ControlStyle-Width="350px">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblCreatedBy" runat="server" Text='<%#Bind("ins_userid") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="CREATED DATE" ControlStyle-Width="350px">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblCreatedDate" runat="server" Text='<%#Bind("ins_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="UPDATED BY" ControlStyle-Width="350px">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblUpdatedBy" runat="server" Text='<%#Bind("upd_userid") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="UPDATED Date" ControlStyle-Width="350px">
                                                <ItemTemplate>
                                                    <asp:Label CssClass="label" ID="lblUpdatedDate" runat="server" Text='<%#Bind("upd_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
