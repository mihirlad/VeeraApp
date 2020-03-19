<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeAttendanceMaster.aspx.cs" Inherits="VeeraApp.Admin.EmployeeAttendanceData" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script lang="javascript" type="text/javascript">

        function divexpandcollapse(divname) {

            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);

            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "/images/minus.gif";
            } else {
                div.style.display = "none";
                img.src = "/images/plus.gif";
            }
        }

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && charCode != 46 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

    </script>

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
                    <h4>EMPLOYEE ATTENDANCE DATA</h4>
                </div>
            </div>
        </div>
    </div>


    <%--  <div style="clear: both; height: 10px">
    </div>--%>


     <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">

                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">

                            <asp:HiddenField ID="HfSrNo" runat="server" />
                            <div class="h5" style="color: brown">ATTENDANCE MASTER</div>

                            <asp:UpdatePanel ID="updpnl" runat="server">
                                <ContentTemplate>

                                    <div class="col-md-12">
                             
                                        <div class="col-md-1">
                                            <asp:Label CssClass="label" Text=" Date" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtAttendanceDate" Style="text-align: center;" OnTextChanged="TxtAttendanceDate_TextChanged" CssClass="form-control" runat="server"  AutoPostBack="true"></asp:TextBox>

                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtAttendanceDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                                ErrorMessage="INVALID DATE" ForeColor="Red"></asp:RegularExpressionValidator>

                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server"
                                                ControlToValidate="TxtAttendanceDate" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            <ajax:CalendarExtender runat="server" ID="CalendarID1" Format="dd-MM-yyyy" TargetControlID="TxtAttendanceDate"></ajax:CalendarExtender>
                                        </div>

                                          <div class="col-md-1">
                                            <asp:Label CssClass="label" Text="Holiday" runat="server"></asp:Label>
                                            <asp:DropDownList ID="DdlHolidayFlag" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="Y">YES</asp:ListItem>
                                                <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                         <div class="col-md-4">
                                            <asp:Label CssClass="label" Text="Remark" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtRemark" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                     </div>

                                    

                                  <div style="clear: both; height: 10px;">
                                    </div>

                                    <div class="panel panel-widget top-grids">
                                        <div class="chute chute-center text-center">

                                            <div class="table-responsive" style="height: 450px; overflow-y: scroll;" id="DivStockGrid" runat="server">
                                                <div class="h5" style="color: brown">EMPLOYEE ATTENDANCE DETAILS</div>
                                                <asp:GridView ID="GvEmployeeAttendanceTransaction" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvEmployeeAttendanceTransaction_PageIndexChanging"
                                                    PageSize="10">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                           <asp:TemplateField HeaderText="Sr.No." HeaderStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfCompCodeGrid" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                                <asp:HiddenField ID="HfTranDateGrid" runat="server" Value='<%#Bind("TRAN_DATE") %>' />
                                                                 <asp:HiddenField ID="HfTranNoGrid" runat="server" Value='<%#Bind("TRAN_NO") %>' />
                                                                    <asp:HiddenField ID="HfEmployeeCode" runat="server" Value='<%#Bind("EMP_CODE") %>' />
                                                                 <asp:HiddenField ID="HfPayableAmmount" runat="server" Value='<%#Bind("PAY_AMT") %>' />
                                                                
                   
                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="EMPLOYEE NAME">                                                       
                                                              <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdcenteralign" ID="TxtEmployeeName" ReadOnly="true" runat="server" Text='<%#Bind("EMP_NAME") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRESENT">                                                       
                                                              <ItemTemplate>
                                                                <%--  <asp:Label CssClass="label grdleftalign" ID="lblBracodeStatus" runat="server" Text='<%#Bind("ATTN_FLAG") %>'></asp:Label>--%>

                                                                  <asp:DropDownList ID="DdlAttendanceFlag" OnSelectedIndexChanged="DdlAttendanceFlag_SelectedIndexChanged" Text='<%#Bind("ATTN_FLAG") %>' AutoPostBack="true" runat="server" >
                                                                      <asp:ListItem Value="P" Selected="True">PRESENT</asp:ListItem>
                                                                      <asp:ListItem Value="H">HALF DAY</asp:ListItem>
                                                                      <asp:ListItem Value="A">ABSENT</asp:ListItem>
                                                                  </asp:DropDownList>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="PAYABLE AMT.">                                                       
                                                              <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdleftalign" ReadOnly="true" ID="TxtPayableAmount" runat="server" Text='<%#Bind("PAY_AMT") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="OT HOURS.">                                                       
                                                              <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control grdleftalign" ID="TxtOTHours" runat="server" Text='<%#Bind("OT_HOURS") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        </Columns>
                                                    </asp:GridView>
                                                </div>

                                            </div>
                                           </div>


                                    </ContentTemplate>
                                </asp:UpdatePanel>

                               
                            <div style="clear: both; height: 10px;">
                            </div>


                            <div class="col-md-12">
                                <div class="col-md-2 bs-component mb10">
                                    <asp:Button ID="btnClear" runat="server" Text="EXIT" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnClear_Click"
                                        CausesValidation="false" />
                                </div>
                                <div class="col-md-2 bs-component mb10">
                                    <asp:Button ID="BtncallUpd" Text="UPDATE" runat="server" OnClick="BtncallUpd_Click" CssClass="btn btn-lg btn-primary btn-block" />
                                </div>

                                <div class="col-md-2 bs-component mb10">
                                    <asp:Button ID="Btncalldel" runat="server" Text="DELETE" OnClick="Btncalldel_Click" CssClass="btn btn-lg btn-primary btn-block" />
                                </div>
                            </div>

                            

                            </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>


     <div id="DivView" runat="server" class="grids">

        <div class="panel panel-widget top-grids">
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click1" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />
        </div>

        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBranchCode" runat="server" />
        <asp:HiddenField ID="HfTranNo" runat="server" />
        <asp:HiddenField ID="HfTranDate" runat="server" />
         
        


        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvEmployeeAttendanceMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvEmployeeAttendanceMaster_PageIndexChanging" OnRowCommand="GvEmployeeAttendanceMaster_RowCommand"
                        PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                            <asp:TemplateField HeaderText="ACTION">
                                    <ItemTemplate>
                                        <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                        <asp:HiddenField ID="HfTranDateGrid" runat="server" Value='<%#Bind("TRAN_DATE")%>' />
                                        <asp:HiddenField ID="HfTranNoGrid" runat="server" Value='<%#Bind("TRAN_NO")%>' />

                                        <asp:HiddenField ID="hfREC_UPD" runat="server" Value='<%#Bind("REC_UPD")%>' />
                                        <asp:HiddenField ID="hfREC_DEL" runat="server" Value='<%#Bind("REC_DEL")%>' />
                                        <asp:HiddenField ID="hfREC_INS" runat="server" Value='<%#Bind("REC_INS")%>' />

                                        <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                        <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("TRAN_NO") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                   

                            <asp:TemplateField HeaderText="DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdcenteralign" ID="lblAttendanceDate" runat="server" Text='<%#Bind("ATTN_DATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="HOLIDAY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdcenteralign" ID="lblHoliday" runat="server" Text='<%#Bind("HOLIDAY") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="REMARK">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblRemark" runat="server" Text='<%#Bind("REMARK") %>'></asp:Label>
                                </ItemTemplate>
                              </asp:TemplateField>

                         
                            </Columns>
                        </asp:GridView>
                    </div>
                    
                  </div>
                </div>
            </div>
        </div>


     <script src="js/proton.js"></script>

    <div class="modal fade" tabindex="-1" id="CmpDeleteSelection" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">DELETE ATTENDANCE TRANSACTION DETAIL</h4>
                </div>
                <div class="modal-body">


                    <span>Are you sure want to delete...!!!</span>
                    <br />

                    <div id="Div2" runat="server" class="grids">

                        <div class="panel panel-widget top-grids">

                            <asp:Button ID="btnDelete" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnDelete_Click" CausesValidation="false" />
                            <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">NO</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function HideModel() {
            $("#CmpDeleteSelection").modal('hide');
        }

        function ShowModel() {

            $("#CmpDeleteSelection").modal('show');

        }
    </script>

    <script src="js/proton.js"></script>

    <div class="modal fade" tabindex="-1" id="CmpUpdateSelection" data-keyboard="false" data-backdrop="static">
        12345
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title">UPDATE ATTENDANCE TRANSACTION DETAIL</h4>
                    </div>
                    <div class="modal-body">


                        <span>Are you sure want to update...!!!</span>
                        <br />

                        <div id="Div3" runat="server" class="grids">

                            <div class="panel panel-widget top-grids">
                                <asp:Button ID="btnSave" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnSave_Click" />
                                <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">NO</button>
                            </div>

                        </div>
                    </div>


                </div>
            </div>
    </div>

    <script type="text/javascript">
        function HideModel1() {
            $("#CmpUpdateSelection").modal('hide');
        }

        function ShowModel1() {

            $("#CmpUpdateSelection").modal('show');

        }
    </script>



</asp:Content>
