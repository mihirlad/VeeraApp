<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeGeneralMaster.aspx.cs" Inherits="VeeraApp.Admin.EmployeeGeneralMaster" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

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
                    <h4>SALARY GENERAL MASTER</h4>
                </div>
            </div>
        </div>
    </div>

    <asp:UpdatePanel ID="updpnl" runat="server">
        <ContentTemplate>

            <div class="panel panel-widget forms-panel">
                <div id="DivEntry" runat="server" class="forms">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">

                        <div class="form-body">
                            <div class="form-horizontal form-bordered">
                                <div class="form-group" style="border-bottom: none;">



                                    <asp:HiddenField ID="HfTranNo" runat="server" />
                                    <asp:HiddenField ID="HfTranType" runat="server" />
                                    <asp:HiddenField ID="HfCompCode" runat="server" />

                                    <div style="margin: 30px 30px 30px 30px">
                                        <div class="row">
                                            <div style="border: solid 1px black; margin-left: 100px; height: 300px" class="col-md-5 col-sm-5 well">
                                                <div style="width: 100%; border-bottom: 1px solid black; border-radius: 8px; height: 20px;">
                                                    <center>PF Calculate Master</center>
                                                </div>
                                                <%-- Start --%>

                                                <div class="panel panel-widget top-grids">
                                                    <div class="chute chute-center text-center">

                                                        <div class="table-responsive" style="height: 150px; overflow-y: scroll;" id="DivPFCALGrid" runat="server">

                                                            <asp:GridView ID="GvPFCalculateMaster" CssClass="table table-vcenter table-condensed table-bordered" OnRowCommand="GvPFCalculateMaster_RowCommand"
                                                                runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                                                PageSize="10">
                                                                <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                                <Columns>

                                                                    <asp:TemplateField HeaderText="FROM DATE">
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="HfCompCodeGrid" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                                            <asp:HiddenField ID="HfTranTypeGrid" runat="server" Value='<%#Bind("TRAN_TYPE") %>' />
                                                                            <asp:HiddenField ID="HfTranNoGrid" runat="server" Value='<%#Bind("TRAN_NO") %>' />

                                                                            <asp:TextBox CssClass="form-control grdcenteralign" Enabled="false" ID="TxtFromDate" runat="server" Text='<%#Bind("FRDT") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="TO DATE">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox CssClass="form-control grdcenteralign" Enabled="false" ID="TxtToDate" runat="server" Text='<%#Bind("TODT") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="PF RATE">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox CssClass="form-control grdcenteralign" Enabled="false" ID="TxtPFRate" runat="server" Text='<%#Bind("CAL_RATE1") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="EPF RATE">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtEPFRate" Enabled="false" runat="server" Text='<%#Bind("CAL_RATE2") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="btnSelectRow" runat="server" CausesValidation="false" CommandName="Selecta" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Select" Text="EDIT" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                       <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                              <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>


                                                        </div>
                                                    </div>
                                                </div>

                                                <div style="clear: both; height: 10px;">
                                                </div>


                                                <asp:Button ID="BtnAddPF" runat="server" Text="ADD" OnClick="BtnAddPF_Click" CausesValidation="false" CssClass="btn btn-lg btn-primary" />
                                                <asp:Button ID="BtnExitPF" runat="server" Text="Exit" CssClass="btn btn-lg btn-primary" CausesValidation="false" />


                                            </div>

                                            <div style="border: solid 1px black; margin-left: 100px; height: 300px" class="col-md-5 col-sm-5 well">
                                                <div style="width: 100%; border-bottom: 1px solid black; height: 20px; border-radius: 8px;">
                                                    <center>ESIC Calculate Master</center>
                                                </div>
                                                <%-- Start --%>

                                                <div class="panel panel-widget top-grids">
                                                    <div class="chute chute-center text-center">

                                                        <div class="table-responsive" style="height: 150px; overflow-y: scroll;" id="DivEPFCALGrid" runat="server">

                                                            <asp:GridView ID="GvESICCalculateMaster" CssClass="table table-vcenter table-condensed table-bordered" OnRowCommand="GvESICCalculateMaster_RowCommand"
                                                                runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                                                PageSize="10">
                                                                <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                                <Columns>

                                                                    <asp:TemplateField HeaderText="FROM DATE">
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="HfCompCodeGrid" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                                            <asp:HiddenField ID="HfTranTypeGrid" runat="server" Value='<%#Bind("TRAN_TYPE") %>' />
                                                                            <asp:HiddenField ID="HfTranNoGrid" runat="server" Value='<%#Bind("TRAN_NO") %>' />

                                                                            <asp:TextBox CssClass="form-control grdcenteralign" Enabled="false" ID="TxtFromDate" runat="server" Text='<%#Bind("FRDT") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="TO DATE">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox CssClass="form-control grdcenteralign" Enabled="false" ID="TxtToDate" runat="server" Text='<%#Bind("TODT") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="EMPLOYEE RATE">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox CssClass="form-control grdcenteralign" Enabled="false" ID="TxtEmployeeRate" runat="server" Text='<%#Bind("CAL_RATE1") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="COMPANY RATE">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox CssClass="form-control grdcenteralign" Enabled="false" ID="TxtCompanyRate" runat="server" Text='<%#Bind("CAL_RATE2") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="btnSelectRow" runat="server" CausesValidation="false" CommandName="Selecta" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Select" Text="EDIT" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                              <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>

                                                        </div>
                                                    </div>
                                                </div>

                                                <div style="clear: both; height: 10px;">
                                                </div>


                                                <asp:Button ID="BtnAddESIC" runat="server" Text="ADD" CausesValidation="false" OnClick="BtnAddESIC_Click" CssClass="btn btn-lg btn-primary" />
                                                <asp:Button ID="BtnExitESIC" runat="server" Text="Exit" CssClass="btn btn-lg btn-primary" CausesValidation="false" />

                                            </div>
                                        </div>
                                        <br />


                                        <div class="row">
                                            <div style="border: solid 1px black; margin-left: 100px; height: 300px" class="col-md-5 col-sm-5 well">
                                                <div style="width: 100%; border-bottom: 1px solid black; height: 20px; border-radius: 8px;">
                                                    <center>OT Calculate Master</center>
                                                </div>
                                                <%-- Start --%>


                                                <div class="panel panel-widget top-grids">
                                                    <div class="chute chute-center text-center">

                                                        <div class="table-responsive" style="height: 150px; overflow-y: scroll;" id="Div1" runat="server">

                                                            <asp:GridView ID="GvOTCalculateMaster" CssClass="table table-vcenter table-condensed table-bordered" OnRowCommand="GvOTCalculateMaster_RowCommand"
                                                                runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                                                PageSize="10">
                                                                <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                                <Columns>

                                                                    <asp:TemplateField HeaderText="FROM DATE">
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="HfCompCodeGrid" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                                            <asp:HiddenField ID="HfTranTypeGrid" runat="server" Value='<%#Bind("TRAN_TYPE") %>' />
                                                                            <asp:HiddenField ID="HfTranNoGrid" runat="server" Value='<%#Bind("TRAN_NO") %>' />

                                                                            <asp:TextBox CssClass="form-control grdcenteralign" Enabled="false" ID="TxtFromDate" runat="server" Text='<%#Bind("FRDT") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="TO DATE">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox CssClass="form-control grdcenteralign" Enabled="false" ID="TxtToDate" runat="server" Text='<%#Bind("TODT") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="WORKING HOURS">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox CssClass="form-control grdcenteralign" Enabled="false" ID="TxtWorkingHours" runat="server" Text='<%#Bind("WRK_HOURS") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="> HOURS">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox CssClass="form-control grdcenteralign" Enabled="false" ID="TxtCalculateHours" runat="server" Text='<%#Bind("CAL_HOURS") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="CAL.RATE">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox CssClass="form-control grdcenteralign" Enabled="false" ID="TxtCalculateRate1" runat="server" Text='<%#Bind("CAL_RATE1") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="btnSelectRow" runat="server" CausesValidation="false" CommandName="Selecta" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Select" Text="EDIT" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                      <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                              <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>

                                                        </div>
                                                    </div>
                                                </div>

                                                <div style="clear: both; height: 10px;">
                                                </div>


                                                <asp:Button ID="BtnAddOT" runat="server" Text="ADD" OnClick="BtnAddOT_Click" CausesValidation="false" CssClass="btn btn-lg btn-primary" />
                                                <asp:Button ID="BtnExitOT" runat="server" Text="Exit" CssClass="btn btn-lg btn-primary" CausesValidation="false" />

                                            </div>
                                            <div style="border: solid 1px black; margin-left: 100px; height: 300px" class="col-md-5 col-sm-5 well">
                                                <div style="width: 100%; border-bottom: 1px solid black; height: 20px; border-radius: 8px;">
                                                    <center>Allowance Calculate Master</center>
                                                </div>
                                                <%-- Start --%>

                                                <div class="panel panel-widget top-grids">
                                                    <div class="chute chute-center text-center">

                                                        <div class="table-responsive" style="height: 150px; overflow-y: scroll;" id="Div2" runat="server">

                                                            <asp:GridView ID="GvAllowanceClaculateMaster" CssClass="table table-vcenter table-condensed table-bordered" OnRowCommand="GvAllowanceClaculateMaster_RowCommand"
                                                                runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                                                PageSize="10">
                                                                <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                                <Columns>

                                                                    <asp:TemplateField HeaderText="FROM DATE">
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="HfCompCodeGrid" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                                            <asp:HiddenField ID="HfTranTypeGrid" runat="server" Value='<%#Bind("TRAN_TYPE") %>' />
                                                                            <asp:HiddenField ID="HfTranNoGrid" runat="server" Value='<%#Bind("TRAN_NO") %>' />

                                                                            <asp:TextBox CssClass="form-control grdcenteralign" Enabled="false" ID="TxtFromDate" runat="server" Text='<%#Bind("FRDT") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="TO DATE">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox CssClass="form-control grdcenteralign" Enabled="false" ID="TxtToDate" runat="server" Text='<%#Bind("TODT") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="> HOURS">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox CssClass="form-control grdcenteralign" Enabled="false" ID="TxtCalculateHours" runat="server" Text='<%#Bind("CAL_HOURS") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="CAL.RATE">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox CssClass="form-control grdcenteralign" Enabled="false" ID="TxtCalculateRate1" runat="server" Text='<%#Bind("CAL_RATE1") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="btnSelectRow" runat="server" CausesValidation="false" CommandName="Selecta" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Select" Text="EDIT" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                      <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                              <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>


                                                                </Columns>
                                                            </asp:GridView>

                                                        </div>
                                                    </div>
                                                </div>


                                                <div style="clear: both; height: 10px;">
                                                </div>


                                                <asp:Button ID="BtnAddAllowance" runat="server" Text="ADD" OnClick="BtnAddAllowance_Click" CausesValidation="false" CssClass="btn btn-lg btn-primary" />
                                                <asp:Button ID="BtnExitAllowance" runat="server" Text="Exit" CssClass="btn btn-lg btn-primary" CausesValidation="false" />

                                            </div>
                                        </div>
                                    </div>
      


    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <script src="js/proton.js"></script>

    <div class="modal fade" tabindex="-1" id="CmpSaveSelectionForPF" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">SAVE PF CALCULATION  DETAIL</h4>
                </div>
                <div class="modal-body">

                    <div class="col-md-12">

                        <div class="col-md-3">
                            <asp:Label CssClass="label" Text="From Date" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtPFFromDate" runat="server"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" ValidationGroup="validPF" runat="server" ControlToValidate="TxtPFFromDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                ErrorMessage="INVALID DATE" ForeColor="Red"></asp:RegularExpressionValidator>

                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ValidationGroup="validPF"
                                ControlToValidate="TxtPFFromDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <ajax:CalendarExtender runat="server" ID="CalendarID1" Format="dd-MM-yyyy" TargetControlID="TxtPFFromDate"></ajax:CalendarExtender>
                        </div>

                        <div class="col-md-3">
                            <asp:Label CssClass="label" Text="To Date" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtPFToDate" runat="server"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ValidationGroup="validPF" ControlToValidate="TxtPFToDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                ErrorMessage="INVALID DATE" ForeColor="Red"></asp:RegularExpressionValidator>

                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ValidationGroup="validPF"
                                ControlToValidate="TxtPFToDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtPFToDate"></ajax:CalendarExtender>
                        </div>

                        <div class="col-md-3">
                            <asp:Label CssClass="label" Text="PF Rate" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdrightalign" ID="TxtPFRate" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-3">
                            <asp:Label CssClass="label" Text="FPF Rate" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdrightalign" ID="TxtPFFPFRate" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div style="clear: both; height: 10px;">
                    </div>

                    <div id="Div3" runat="server" class="grids">
                        <center>
                        <div class="panel panel-widget top-grids">
                            <asp:Button ID="btnSavePFData" runat="server" Text="SAVE" CssClass="btn btn-lg btn-primary" ValidationGroup="validPF" OnClick="btnSavePFData_Click" />
                            <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">CLOSE</button>
                        </div>
                         </center>

                    </div>
                </div>


            </div>
        </div>
    </div>

    <script type="text/javascript">
        function HideModelSavePF() {
        
            $("#CmpSaveSelectionForPF").modal('hide');
        }

        function ShowModelSavePF() {

            $("#CmpSaveSelectionForPF").modal('show');

        }
    </script>



    <div class="modal fade" tabindex="-1" id="CmpSaveSelectionForESIC" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">SAVE ESIC CALCULATION  DETAIL</h4>
                </div>
                <div class="modal-body">

                    <div class="col-md-12">

                        <div class="col-md-3">
                            <asp:Label CssClass="label" Text="From Date" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtESICFromDate" runat="server"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" ValidationGroup="validESIC" runat="server" ControlToValidate="TxtESICFromDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                ErrorMessage="INVALID DATE" ForeColor="Red"></asp:RegularExpressionValidator>

                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ValidationGroup="validESIC"
                                ControlToValidate="TxtESICFromDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <ajax:CalendarExtender runat="server" ID="CalendarExtender2" Format="dd-MM-yyyy" TargetControlID="TxtESICFromDate"></ajax:CalendarExtender>
                        </div>

                        <div class="col-md-3">
                            <asp:Label CssClass="label" Text="To Date" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtESICToDate" runat="server"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" Display="Dynamic" runat="server" ValidationGroup="validESIC" ControlToValidate="TxtESICToDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                ErrorMessage="INVALID DATE" ForeColor="Red"></asp:RegularExpressionValidator>

                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ValidationGroup="validESIC"
                                ControlToValidate="TxtESICToDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <ajax:CalendarExtender runat="server" ID="CalendarExtender3" Format="dd-MM-yyyy" TargetControlID="TxtESICToDate"></ajax:CalendarExtender>
                        </div>

                        <div class="col-md-3">
                            <asp:Label CssClass="label" Text="Employee Rate" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdrightalign" ID="TxtESICEmployeeRate" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-3">
                            <asp:Label CssClass="label" Text="Company Rate" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdrightalign" ID="TxtESICCompanyRate" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div style="clear: both; height: 10px;">
                    </div>

                    <div id="Div4" runat="server" class="grids">
                        <center>
                        <div class="panel panel-widget top-grids">
                            <asp:Button ID="btnSaveESICData" runat="server" Text="SAVE" ValidationGroup="validESIC" CssClass="btn btn-lg btn-primary" OnClick="btnSaveESICData_Click" />
                            <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">CLOSE</button>
                        </div>
                        </center>
                    </div>
                </div>


            </div>
        </div>
    </div>

    <script type="text/javascript">
        function HideModelSaveESIC() {
            $("#CmpSaveSelectionForESIC").modal('hide');
        }

        function ShowModelSaveESIC() {

            $("#CmpSaveSelectionForESIC").modal('show');

        }
    </script>



    <div class="modal fade" tabindex="-1" id="CmpSaveSelectionForOT" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">SAVE OT CALCULATION  DETAIL</h4>
                </div>
                <div class="modal-body">

                    <div class="col-md-12">

                        <div class="col-md-3">
                            <asp:Label CssClass="label" Text="From Date" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtOTFromDate" runat="server"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Display="Dynamic" runat="server" ValidationGroup="validOT" ControlToValidate="TxtOTFromDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                ErrorMessage="INVALID DATE" ForeColor="Red"></asp:RegularExpressionValidator>

                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server" ValidationGroup="validOT"
                                ControlToValidate="TxtOTFromDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <ajax:CalendarExtender runat="server" ID="CalendarExtender4" Format="dd-MM-yyyy" TargetControlID="TxtOTFromDate"></ajax:CalendarExtender>
                        </div>

                        <div class="col-md-3">
                            <asp:Label CssClass="label" Text="To Date" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtOTToDate" runat="server"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" Display="Dynamic" runat="server" ValidationGroup="validOT" ControlToValidate="TxtOTToDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                ErrorMessage="INVALID DATE" ForeColor="Red"></asp:RegularExpressionValidator>

                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server" ValidationGroup="validOT"
                                ControlToValidate="TxtOTToDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <ajax:CalendarExtender runat="server" ID="CalendarExtender5" Format="dd-MM-yyyy" TargetControlID="TxtOTToDate"></ajax:CalendarExtender>
                        </div>

                        <div class="col-md-2">
                            <asp:Label CssClass="label" Text="Working Hours" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdrightalign" ID="TxtOTWorkingHours" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-2">
                            <asp:Label CssClass="label" Text="> Hours" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdrightalign" ID="TxtOTCalculateHours" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-2">
                            <asp:Label CssClass="label" Text="Cal. Rate" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdrightalign" ID="TxtOTCalculateRate1" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div style="clear: both; height: 10px;">
                    </div>


                    <div id="Div5" runat="server" class="grids">
                        <center>
                        <div class="panel panel-widget top-grids">
                            <asp:Button ID="BtnSaveOTData" runat="server" Text="SAVE" CssClass="btn btn-lg btn-primary" ValidationGroup="validOT" OnClick="BtnSaveOTData_Click" />
                            <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">CLOSE</button>
                        </div>
                        </center>
                    </div>
                </div>


            </div>
        </div>
    </div>

    <script type="text/javascript">
        function HideModelSaveOT() {
            $("#CmpSaveSelectionForOT").modal('hide');
        }

        function ShowModelSaveOT() {

            $("#CmpSaveSelectionForOT").modal('show');

        }
    </script>



    <div class="modal fade" tabindex="-1" id="CmpSaveSelectionForAllowance" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">SAVE ALLOWANCE CALCULATION  DETAIL</h4>
                </div>
                <div class="modal-body">


                    <div class="col-md-12">

                        <div class="col-md-3">
                            <asp:Label CssClass="label" Text="From Date" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtAllowanceFromDate" runat="server"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" Display="Dynamic" runat="server" ControlToValidate="TxtAllowanceFromDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                ErrorMessage="INVALID DATE" ValidationGroup="validAllowance" ForeColor="Red"></asp:RegularExpressionValidator>

                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" runat="server" ValidationGroup="validAllowance"
                                ControlToValidate="TxtAllowanceFromDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <ajax:CalendarExtender runat="server" ID="CalendarExtender6" Format="dd-MM-yyyy" TargetControlID="TxtAllowanceFromDate"></ajax:CalendarExtender>
                        </div>

                        <div class="col-md-3">
                            <asp:Label CssClass="label" Text="To Date" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtAllowanceToDate" runat="server"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" Display="Dynamic" ValidationGroup="validAllowance" runat="server" ControlToValidate="TxtAllowanceToDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                ErrorMessage="INVALID DATE" ForeColor="Red"></asp:RegularExpressionValidator>

                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator8" runat="server" ValidationGroup="validAllowance"
                                ControlToValidate="TxtAllowanceToDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <ajax:CalendarExtender runat="server" ID="CalendarExtender7" Format="dd-MM-yyyy" TargetControlID="TxtAllowanceToDate"></ajax:CalendarExtender>
                        </div>


                        <div class="col-md-2">
                            <asp:Label CssClass="label" Text="> Hours" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdrightalign" ID="TxtAllowanceCalculateHours" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-2">
                            <asp:Label CssClass="label" Text="Cal. Rate" runat="server"></asp:Label>
                            <asp:TextBox CssClass="form-control grdrightalign" ID="TxtAllowanceCalculateRate1" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div style="clear: both; height: 10px;">
                    </div>

                    <div id="Div6" runat="server" class="grids">
                        <center>
                        <div class="panel panel-widget top-grids">
                            <asp:Button ID="BtnSaveAllowanceData" runat="server" Text="SAVE" CssClass="btn btn-lg btn-primary" ValidationGroup="validAllowance" OnClick="BtnSaveAllowanceData_Click" />
                            <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">CLOSE</button>
                        </div>
                        </center>
                    </div>
                </div>


            </div>
        </div>
    </div>

    <script type="text/javascript">
        function HideModelSaveAllowance() {
            $("#CmpSaveSelectionForAllowance").modal('hide');
        }

        function ShowModelSaveAllowance() {

            $("#CmpSaveSelectionForAllowance").modal('show');

        }
    </script>


         </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSavePFData" />
            <asp:PostBackTrigger ControlID="btnSaveESICData" />
            <asp:PostBackTrigger ControlID="BtnSaveOTData" />
            <asp:PostBackTrigger ControlID="BtnSaveAllowanceData" />
        </Triggers>
    </asp:UpdatePanel>



    <script src="js/proton.js"></script>

    <div class="modal fade" tabindex="-1" id="CmpDeleteSelectionPF" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">DELETE PF CALCULATION MASTER DETAIL</h4>
                </div>
                <div class="modal-body">


                    <span>Are you sure want to delete...!!!</span>
                    <br />

                    <div id="Div7" runat="server" class="grids">

                        <div class="panel panel-widget top-grids">

                            <asp:Button ID="btnDeletePF" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnDeletePF_Click" CausesValidation="false" />
                            <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">NO</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function HideModelDeletePF() {
            $("#CmpDeleteSelectionPF").modal('hide');
        }

        function ShowModelDeletePF() {

            $("#CmpDeleteSelectionPF").modal('show');

        }
    </script>
    

      <div class="modal fade" tabindex="-1" id="CmpDeleteSelectionESIC" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">DELETE ESIC CALCULATION MASTER DETAIL</h4>
                </div>
                <div class="modal-body">


                    <span>Are you sure want to delete...!!!</span>
                    <br />

                    <div id="Div8" runat="server" class="grids">

                        <div class="panel panel-widget top-grids">

                            <asp:Button ID="btnDeleteESIC" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnDeleteESIC_Click" CausesValidation="false" />
                            <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">NO</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function HideModelDeleteESIC() {
            $("#CmpDeleteSelectionESIC").modal('hide');
        }

        function ShowModelDeleteESIC() {

            $("#CmpDeleteSelectionESIC").modal('show');

        }
    </script>

     <div class="modal fade" tabindex="-1" id="CmpDeleteSelectionOT" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">DELETE OT CALCULATION MASTER DETAIL</h4>
                </div>
                <div class="modal-body">


                    <span>Are you sure want to delete...!!!</span>
                    <br />

                    <div id="Div9" runat="server" class="grids">

                        <div class="panel panel-widget top-grids">

                            <asp:Button ID="btnDeleteOT" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnDeleteOT_Click" CausesValidation="false" />
                            <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">NO</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function HideModelDeleteOT() {
            $("#CmpDeleteSelectionOT").modal('hide');
        }

        function ShowModelDeleteOT() {

            $("#CmpDeleteSelectionOT").modal('show');

        }
    </script>

      <div class="modal fade" tabindex="-1" id="CmpDeleteSelectionAllowance" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">DELETE ALLOWANCE CALCULATION MASTER DETAIL</h4>
                </div>
                <div class="modal-body">


                    <span>Are you sure want to delete...!!!</span>
                    <br />

                    <div id="Div10" runat="server" class="grids">

                        <div class="panel panel-widget top-grids">

                            <asp:Button ID="btnDeleteAllowance" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnDeleteAllowance_Click" CausesValidation="false" />
                            <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">NO</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function HideModelDeleteAllowance() {
            $("#CmpDeleteSelectionAllowance").modal('hide');
        }

        function ShowModelDeleteAllowance() {

            $("#CmpDeleteSelectionAllowance").modal('show');

        }
    </script>

</asp:Content>
