<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="PartyContactDetails.aspx.cs" Inherits="VeeraApp.PartyContactDetails" %>

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
                    <h4>PARTY CONTACT DETAILS</h4>
                </div>
            </div>
        </div>
    </div>
   


   <%-- <div style="clear: both; height: 10px">
    </div>--%>

    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">

                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">

                            <div class="col-md-12">
                             <div>
                                  <asp:Label CssClass="label" ID="lblAccountNameOfParty_relate" Text="Name of the Party:-" Font-Bold="true" Font-Size="Larger" runat="server"></asp:Label>
                                  <asp:Label ID="lblAccountNameOfParty" Font-Bold="true" Font-Size="Larger" ForeColor="#3333cc" runat="server"></asp:Label>
                                </div>
                                 </div>
                           
                            <div style="clear: both; height:10px"></div>

                                <asp:HiddenField ID="HfCompCode" runat="server" />
                                <asp:HiddenField ID="HfACODE" runat="server" />

                            <asp:UpdatePanel ID="UPDTABLE" runat="server">
                                <ContentTemplate>

                               
                          <div class="container">
                                <div class="col-md-6">
                                <table class="table table-responsive">
                                    <tbody>
                                         
                                    
                                       <%--   <tr id="tblcompname" runat="server">
                                               <td>
                                                   <asp:Label CssClass="label" Text="Company Name" runat="server"></asp:Label>
                                            </td>
                                          <td>
                                               <asp:DropDownList ID="DdlComapnyName" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlComapnyName_SelectedIndexChanged" AutoPostBack="true">
                                                 
                                               </asp:DropDownList>
                                            </td>
                                        </tr> --%>
                                          <tr id="tblaccname" runat="server">
                                            <td>
                                                <asp:Label CssClass="label" Text="Account Name" ForeColor="Blue" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                               <asp:DropDownList ID="DdlAccountName" runat="server" ForeColor="Blue" CssClass="form-control">
                                                     <asp:ListItem Value="0"></asp:ListItem>
                                               </asp:DropDownList>
                                               
                                            </td>
                                           </tr>
                                     
                                         
                                        <tr>
                                            <td>
                                                  <asp:Label CssClass="label" Text="Contact Name" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                              <asp:TextBox ID="TxtContactName" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtContactName" runat="server"
                                                     ControlToValidate="TxtContactName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label CssClass="label" Text="Designation" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:TextBox ID="TxtDesignation" CssClass="form-control" runat="server"></asp:TextBox>
                                                 <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtDesignation" runat="server"
                                                     ControlToValidate="TxtDesignation" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                  <asp:Label CssClass="label" Text="Only Mobile No." runat="server"></asp:Label>
                                              </td>
                                            <td>
                                                <asp:TextBox ID="TxtMobileNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                 <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredTxtMobileNo" runat="server"
                                                     ControlToValidate="TxtMobileNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label CssClass="label" Text="Email ID" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                          <asp:TextBox ID="TxtEmailAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldEmail" runat="server" ErrorMessage="*" ControlToValidate="TxtEmailAddress"
                                                                             ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionTxtEmailAddress" runat="server" ErrorMessage="Please Enter Valid Email ID"
                                                                        ControlToValidate="TxtEmailAddress"
                                                                        CssClass="requiredFieldValidateStyle" ForeColor="Red"
                                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                 </asp:RegularExpressionValidator>

                                            </td>
                                        </tr>
                                        <tr>
                                          <td>
                                                <asp:Label CssClass="label" Text="Birth Date" runat="server"></asp:Label>
                                         </td>
                                            <td>
                                              <asp:TextBox ID="TxtDob" CssClass="form-control" runat="server"></asp:TextBox>

                                     <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="TxtDob" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                            ErrorMessage="INVALID DATE" ForeColor="Red" />--%>

                                    <%--   <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server"
                                            ControlToValidate="TxtDob" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                     <ajax:CalendarExtender runat="server" ID="CalendarID1" Format="dd-MM-yyyy" TargetControlID="TxtDob"></ajax:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                  <asp:Label CssClass="label" Text="Accounts" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:CheckBox ID="Chk_Accounts" CssClass="form-control" runat="server" Text="Accounts" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label CssClass="label" Text="Purchase" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                  <asp:CheckBox ID="Chk_Purchase" CssClass="form-control" runat="server" Text="Purchase" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label CssClass="label" Text="Service" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:CheckBox ID="Chk_Service" CssClass="form-control" runat="server" Text="Service" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label CssClass="label" Text="Owner" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="Chk_Owner" CssClass="form-control" runat="server" Text="Owner" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label CssClass="label" Text="General" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="Chk_General" CssClass="form-control" runat="server" Text="General" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:Label CssClass="label" Text="SMS" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:CheckBox ID="Chk_SMS" CssClass="form-control" runat="server" Text="SMS" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label CssClass="label" Text="Active" runat="server"></asp:Label>

                                            </td>
                                            <td>
                                      <asp:DropDownList ID="DdlActive" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="Y">YES</asp:ListItem>
                                        <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                      </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label CssClass="label" Text="Remarks" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:TextBox ID="TxtRemarks" CssClass="form-control" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </tbody>
                                   </table>
                                   </div>
                                 </div> 
                             </ContentTemplate>
                            </asp:UpdatePanel>
                            <div style="clear: both; height: 10px;">
                            </div>

                            <div class="col-md-12">
                                <div class="col-md-3 bs-component mb10">
                                    <asp:Button ID="btnClear" runat="server" Text="EXIT" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnClear_Click"
                                        CausesValidation="false" />
                                </div>
                                <div class="col-md-3 bs-component mb10">
                                    <asp:Button ID="BtncallUpd" Text="UPDATE" runat="server" OnClick="BtncallUpd_Click" CssClass="btn btn-lg btn-primary btn-block" />
                                </div>

                                <div class="col-md-3 bs-component mb10">
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
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" OnClick="BtnAdd_Click" CssClass="btn btn-lg btn-primary" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />

              <div style="float:right;">
             <asp:Label CssClass="label" style="color:red;" Text="Search By Contact Name/Mail-Id/Party Name" runat="server"></asp:Label><br />
              <asp:TextBox ID="TxtSearch"  runat="server" style="width: 100%;" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>

        </div>

         <%-- <div class="col-md-3">
                <asp:Label CssClass="label" Text="Search By Name/Mail-Id/Party Name" runat="server"></asp:Label>
                <asp:TextBox ID="TxtSearch" CssClass="form-control" runat="server" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>--%>

          <div style="clear: both; height: 10px"></div>

        <asp:HiddenField ID="HfSR_NO" runat="server" />

        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

               <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvAccContact" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvAccContact_PageIndexChanging" OnRowCommand="GvAccContact_RowCommand"
                         PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                             <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("SRNO") %>'  ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <asp:HiddenField ID="HfSR_NO" runat="server" Value='<%#Bind("SRNO")%>' />

                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("SRNO") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("SRNO") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                </ItemTemplate>
                           </asp:TemplateField>

                            
                            <%--<asp:TemplateField HeaderText="SR.NO.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                            </asp:TemplateField> --%>
                              <asp:TemplateField HeaderText="NAME OF THE PARTY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblAccountName" runat="server" Text='<%#Bind("AccountName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CONTACT NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblContactName" runat="server" Text='<%#Bind("CONTACT_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DESIGNATION">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblDesignation" runat="server" Text='<%#Bind("DESIGN_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                         <%--   <asp:TemplateField HeaderText="MOBILE NO">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblPhoneNo" runat="server" Text='<%#Bind("PHONE_NO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EMAIL">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblMailId" runat="server" Text='<%#Bind("MAIL_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> --%>
                            
                             <asp:TemplateField HeaderText="ACCOUNTS">
                                <ItemTemplate>
                                     <asp:CheckBox ID="chkAccountFlag" Enabled="false" runat="server" Checked='<%#Convert.ToBoolean(Eval("ACC_FLAG_String")) %>'  />
                                   <%-- <asp:Label CssClass="label"  ID="lblAccounts" runat="server" Text='<%#Bind("ACC_FLAG") %>'></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="PURCHASE">
                                <ItemTemplate>
                                      <asp:CheckBox ID="chkPurchaseFlag" Enabled="false" runat="server" Checked='<%#Convert.ToBoolean(Eval("PUR_FLAG_String")) %>'  />
                                   <%-- <asp:Label CssClass="label"  ID="lblPurchase" runat="server" Text='<%#Bind("PUR_FLAG") %>'></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SERVICE">
                                <ItemTemplate>
                                      <asp:CheckBox ID="chkServiceFlag" Enabled="false" runat="server" Checked='<%#Convert.ToBoolean(Eval("SERVICE_FLAG_String")) %>'  />
                                   <%-- <asp:Label CssClass="label"  ID="lblService" runat="server" Text='<%#Bind("SERVICE_FLAG") %>'></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="OWNER">
                                <ItemTemplate>
                                      <asp:CheckBox ID="chkOwnerFlag" Enabled="false" runat="server" Checked='<%#Convert.ToBoolean(Eval("OWNER_FLAG_String")) %>'  />
                                   <%-- <asp:Label CssClass="label"  ID="lblOwner" runat="server" Text='<%#Bind("OWNER_FLAG") %>'></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="GENERAL">
                                <ItemTemplate>
                                      <asp:CheckBox ID="chkGeneralFlag" Enabled="false" runat="server" Checked='<%#Convert.ToBoolean(Eval("GEN_FLAG_String")) %>'  />
                                    <%--<asp:Label CssClass="label"  ID="lblGeneral" runat="server" Text='<%#Bind("GEN_FLAG") %>'></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="SMS">
                                <ItemTemplate>
                                      <asp:CheckBox ID="chkSmsFlag" Enabled="false" runat="server" Checked='<%#Convert.ToBoolean(Eval("SMS_FLAG_String")) %>'  />
                                    <%--<asp:Label CssClass="label"  ID="lblsms" runat="server" Text='<%#Bind("SMS_FLAG") %>'></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>

                                 <asp:TemplateField HeaderText="CREATED BY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="TxtCreatedBy" runat="server" Text='<%#Bind("INS_USERID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CREATED DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="TxtCreatedDate" runat="server" Text='<%#Bind("INS_DATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="UPDATED BY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="TxtUpdatedBy" runat="server" Text='<%#Bind("UPD_USERID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="UPDATED DATE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="TxtUpdatedDate" runat="server" Text='<%#Bind("UPD_DATE") %>'></asp:Label>
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
                        
                        <h4 class="modal-title">DELETE CONTACT DETAIL</h4>
                    </div>
                    <div class="modal-body">
                        
                        
                       <span>Are you sure want to delete...!!!</span>
                      <br />
                      
                         <div id="Div2" runat="server" class="grids">

                      <div class="panel panel-widget top-grids">

                                    <asp:Button ID="btnDelete" runat="server" Text="YES"  CssClass="btn btn-lg btn-primary" OnClick="btnDelete_Click" CausesValidation="false" />
                                    <button type="button" class="btn btn-lg btn-primary"  data-dismiss="modal" value="NO">NO</button>
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
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        
                        <h4 class="modal-title">UPDATE CONTACT DETAIL</h4>
                    </div>
                    <div class="modal-body">
                        
                        
                       <span>Are you sure want to update...!!!</span>
                      <br />
                      
                         <div id="Div3" runat="server" class="grids">

                      <div class="panel panel-widget top-grids">
                          <asp:Button ID="btnSave" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnSave_Click"/>
                           <button type="button" class="btn btn-lg btn-primary"  data-dismiss="modal" value="NO">NO</button>
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
