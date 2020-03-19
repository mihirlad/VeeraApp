<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VeeraApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login :: VEERA COMPRESSOR</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Colored Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!-- bootstrap-css -->
    <link rel="stylesheet" href="css/bootstrap.css" />
    <!-- //bootstrap-css -->
    <!-- Custom CSS -->
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <!-- font CSS -->
    <link href='//fonts.googleapis.com/css?family=Roboto:400,100,100italic,300,300italic,400italic,500,500italic,700,700italic,900,900italic' rel='stylesheet' type='text/css' />
    <!-- font-awesome icons -->
    <link rel="stylesheet" href="css/font.css" type="text/css" />
    <link href="css/font-awesome.css" rel="stylesheet" />

    <script src="js/jquery.js"></script>
    <script src="js/bootstrap.js"></script>
    <%--<script src="js/app_1.js"></script>--%>
    <!-- //font-awesome icons -->
    <style type="text/css">
        .modal1 {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 40%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }

        .center {
            z-index: 1000;
            margin: 10% 35%;
            padding: 0px;
            width: 130px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }

            .center img {
                height: 128px;
                width: 128px;
            }
    </style>


    <script type="text/javascript">
        function HideModel() {
            $("#CmpBranchSelection").modal('hide');
        }

        function ShowModel() {

            $("#CmpBranchSelection").modal('show');

        }
    </script>
</head>
<body class="signup-body">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="Sc1" runat="server"></asp:ScriptManager>
        <div class="agile-signup">

            <div class="content2">
                <div class="grids-heading gallery-heading signup-heading">
                    <h2>LOGIN</h2>
                </div>

                <asp:TextBox ID="TxtUserName" runat="server" placeholder="User Name" ValidationGroup="ValidLogin"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequireTxtUserName" runat="server" Display="Static" ErrorMessage="*" ForeColor="Red" ControlToValidate="TxtUserName" ValidationGroup="ValidLogin"></asp:RequiredFieldValidator>

                <asp:TextBox ID="TxtPassword" runat="server" placeholder="Password" TextMode="Password" ValidationGroup="ValidLogin"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Static" ErrorMessage="*" ForeColor="Red" ControlToValidate="TxtPassword" ValidationGroup="ValidLogin"></asp:RequiredFieldValidator>

                <asp:Button ID="BtnLogin" runat="server" class="register" Text="Login" OnClick="BtnLogin_click" ValidationGroup="ValidLogin" />

                <div class="signin-text">
                    <div class="text-center">
                        <asp:Label CssClass="label"  ID="lblMsg" runat="server"></asp:Label>
                    </div>
                </div>
             
            
            </div>

          
        </div>

        <script src="js/proton.js"></script>

        <div class="modal fade" tabindex="-1" id="CmpBranchSelection" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" style="margin-right: 0px">
                            × 
                        </button>
                        <h4 class="modal-title">COMPANY SELECTION</h4>
                    </div>
                    <div class="modal-body">
                        <br />
                        <br />
                        <div class="col-md-12">

                            <asp:DropDownList ID="DdlCompany" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlCompany_OnSelectedIndexChanged" AutoPostBack="true" ValidationGroup="ValidCompany"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequireCompany" runat="server" InitialValue="0" ForeColor="Red" ErrorMessage="*" ControlToValidate="DdlCompany" ValidationGroup="ValidCompany"></asp:RequiredFieldValidator>

                        </div>
                        <asp:UpdatePanel ID="UpdatePanel2"
                            runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="DdlCompany" EventName="SelectedIndexChanged" />

                            </Triggers>
                            <ContentTemplate>
                                <div class="col-md-12">

                                    <asp:DropDownList ID="DdlBranch" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">-- SELECT BRANCH --</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredDdlBranch" runat="server" InitialValue="0" ForeColor="Red" ErrorMessage="*" ControlToValidate="DdlBranch" ValidationGroup="ValidCompany"></asp:RequiredFieldValidator>

                                </div>
                                <div class="col-md-12">

                                    <asp:DropDownList ID="DdlFinYear" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">-- SELECT YEAR --</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredDdlFinYear" runat="server" InitialValue="" ForeColor="Red" ErrorMessage="*" ControlToValidate="DdlFinYear" ValidationGroup="ValidCompany"></asp:RequiredFieldValidator>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div><center>
                        <asp:Button ID="BtnCompanyLogin" runat="server" class="register" ValidationGroup="ValidCompany" Text="SUBMIT" OnClick="BtnCompanyLogin_click" />
                            </center>
                        </div>

                    </div>


                </div>
            </div>
        </div>


    </form>
</body>
</html>
