<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="CompanyYearSelection.aspx.cs" Inherits="VeeraApp.Admin.CompanyYearSelection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="../css/model.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:ScriptManager ID="ScriptManger1" runat="server"></asp:ScriptManager>

      <script src="js/proton.js"></script>

        <div class="modalquo fade" tabindex="-1" id="CmpCompanySelection" data-keyboard="false" data-backdrop="static">
            <div class="modalquo-dialog modal-lg">
                <div class="modalquo-content">
                    <div class="modalquo-header">
                        <button type="button" class="close" data-dismiss="modal" style="margin-right: 0px">
                            × 
                        </button>
                        <h4 class="modalquo-title">COMPANY SELECTION</h4>
                    </div>
                    <div class="modalquo-body">
                        <br />
                        <br />
                        <div class="col-md-12">

                            <asp:DropDownList ID="DdlCompany" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlCompany_SelectedIndexChanged" AutoPostBack="true" ValidationGroup="ValidCompany"></asp:DropDownList>
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

                        <div ><center>
                        <asp:Button ID="BtnCompanyLogin" runat="server" class="register" ValidationGroup="ValidCompany" Text="SUBMIT" OnClick="BtnCompanyLogin_Click" />
                            </center>
                        </div>

                    </div>


                </div>
            </div>
        </div>


       <script type="text/javascript">
        function HideModel() {
            $("#CmpCompanySelection").modal('hide');
        }

        function ShowModel() {

            $("#CmpCompanySelection").modal('show');

        }
    </script>

</asp:Content>
