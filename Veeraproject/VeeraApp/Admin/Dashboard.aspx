<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="VeeraApp.Admin.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <div class="progressbar-heading grids-heading">
            <h2 class="main_heading">Dashboard</h2>
            <span style="float: right;">
                <asp:Label CssClass="label"  ID="lblmsg" runat="server"></asp:Label>
            </span>
        </div>
        <div class="dashbord_img"> <asp:Image ID="imgdash" runat="server"  /></div>

        <%--<div class="forms">
            <div class="form-three widget-shadow">
                <div data-example-id="form-validation-states-with-icons">

                    <span class="glyphicon glyphicon-ok form-control-feedback" aria-hidden="true"></span><span id="inputGroupSuccess1Status" class="sr-only"><asp:Label CssClass="label"  ID="lblmsg" runat="server"></asp:Label></span>
                </div><a href="Dashboard.aspx">Dashboard.aspx</a>

            </div>
        </div>--%>
    </div>
</asp:Content>
