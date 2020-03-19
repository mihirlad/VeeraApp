<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="BranchMaster.aspx.cs" Inherits="VeeraApp.Admin.BranchMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="SM1" runat="server"></asp:ScriptManager>
    <div class="grids">
        <div class="progressbar-heading grids-heading">

            <span style="float: right;">
                <asp:Label CssClass="label"  ID="lblmsg" runat="server"></asp:Label>
            </span>
        </div>
        <%--<div class="forms">
            <div class="form-three widget-shadow">
                <div data-example-id="form-validation-states-with-icons">

                    <span class="glyphicon glyphicon-ok form-control-feedback" aria-hidden="true"></span><span id="inputGroupSuccess1Status" class="sr-only"><asp:Label CssClass="label"  ID="lblmsg" runat="server"></asp:Label></span>
                </div>

            </div>
        </div>--%>
    </div>
    <div style="clear: both; height: 10px">
    </div>
    <%--Insert Button BEGIN--%>
    <div class="grids">
    </div>
    <div class="panel panel-widget forms-panel">
        <div class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title">
                    <h4>BRANCH MASTER</h4>
                </div>
            </div>
        </div>
    </div>

    <%--Insert Button END--%>

    <%--<div style="clear: both; height: 10px">
    </div>--%>

    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <%-- <div class="form-title">
                    <h4>BRANCH MASTER - DETAIL :</h4>
                </div>--%>
                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">
                             <asp:UpdatePanel ID="UPDPANEL" runat="server">
                                  <ContentTemplate>

                                <asp:HiddenField ID="HfCompCode" runat="server" />

                             <%-- <div class="col-md-2">
                                    <asp:textbox id="TxtBranchCode" cssclass="form-control" runat="server" placeholder="BRANCH CODE"></asp:textbox>
                                    <asp:requiredfieldvalidator display="Dynamic" id="RequireTxtBranchCode" runat="server"
                                        controltovalidate="TxtBranchCode" forecolor="Red">*</asp:requiredfieldvalidator>

                                </div>--%>
                                     <div class="row" style="width:100%">
                                      <div style="float: left; height: auto; width: 45%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                          <asp:Label CssClass="label"  Text="Branch Name" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                          <asp:TextBox ID="TxtBranchName" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                                             ControlToValidate="TxtBranchName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label"  Text="Short" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;" colspan="1">
                                                         <asp:TextBox ID="TxtBranchShort" CssClass="form-control" runat="server"></asp:TextBox>
                                                         <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                                            ControlToValidate="TxtBranchShort" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                          <asp:Label CssClass="label"  Text="Branch Type" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                          <asp:DropDownList ID="DdlBranchType" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                             <asp:ListItem Value="B">BRANCH OFFICE</asp:ListItem>
                                                             <asp:ListItem Value="H">HEAD OFFICE</asp:ListItem>
                                                         </asp:DropDownList>
                                                         <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server" InitialValue="0"
                                                                       ControlToValidate="DdlBranchType" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                          <asp:Label CssClass="label"  Text="City" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                         <asp:TextBox ID="TxtCity" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                         <asp:Label CssClass="label"  Text="Address1" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                         <asp:TextBox ID="TxtBranchAddress1"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                          <asp:Label CssClass="label"  Text="Address2" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="3" style="padding-left: 10px;">
                                                       <asp:TextBox ID="TxtBranchAddress2" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                         <asp:Label CssClass="label"  Text="Address3" runat="server"></asp:Label>
                                                    </td>
                                                    <td  colspan="3" style="padding-left: 10px;">
                                                       <asp:TextBox ID="TxtBranchAddress3" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                         <asp:Label CssClass="label"  Text="State" ForeColor="Blue" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                          <asp:TextBox ID="TxtBranchState" OnTextChanged="TxtBranchState_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                           <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtBranchState"
                                                             MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                ServiceMethod="GetStateName">
                                                     </ajax:AutoCompleteExtender>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                          <asp:Label CssClass="label"  Text="State No" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtBranchStateNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr> </table>
                                                </div>
                                          </div>
                                         


                                      <div style="float:right; height: auto; width: 45%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label"  Text="Phone No." runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                       <asp:TextBox ID="TxtBranchPhoneNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                          <asp:Label CssClass="label"  Text="Fax" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                         <asp:TextBox ID="TxtBranchFax" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                          <asp:Label CssClass="label"  Text="E-Mail Address" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                      <asp:TextBox ID="TxtBranchEmailAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldEmail" runat="server" ErrorMessage="*" ControlToValidate="TxtBranchEmailAddress"
                                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Please Enter Valid Email ID"
                                                         ControlToValidate="TxtBranchEmailAddress"
                                                         CssClass="requiredFieldValidateStyle" ForeColor="Red"
                                                         ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                  </asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                          <asp:Label CssClass="label"  Text="Auto E-Mail Address" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtBranchAutoEmailAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                           <asp:Label CssClass="label"  Text="GST No.Applicable ?" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlGSTAppllicableFlag" runat="server" OnSelectedIndexChanged="DdlGSTAppllicableFlag_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                                                        <asp:ListItem Value="Y">YES</asp:ListItem>
                                                        <asp:ListItem Value="N" Selected="True">NO</asp:ListItem>
                                                         </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                         <asp:Label CssClass="label"  Text="GST No.Applicable Date" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                     <asp:TextBox ID="TxtGstAppDate" CssClass="form-control" runat="server"></asp:TextBox>

              <%--                                          <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server"
                                                                 ControlToValidate="TxtGstAppDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                                   <ajax:CalendarExtender runat="server" ID="CalendarExtenderAssembleDate" Format="dd-MM-yyyy" TargetControlID="TxtGstAppDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                         <asp:Label CssClass="label"  Text="GST No" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                       <asp:TextBox ID="TxtBranchGSTNo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                </table>
                                            </div>
                                        </div>
                                        
                                          
                              
                           

                            <div style="clear: both; height: 10px;">
                            </div>

                          <div style="float: left; height: auto; width: 75%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                      <asp:Label CssClass="label"  Text="Credit Expense A/C Name 1" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                     <asp:DropDownList ID="DdlCreditExpenseACName1" runat="server" CssClass="form-control">
                                                       <asp:ListItem Value="0"></asp:ListItem>
                                                     </asp:DropDownList>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                         <asp:Label CssClass="label"  Text="Debit Expence A/C Name 1" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                       <asp:DropDownList ID="DdlDebitExpenseACName1" runat="server" CssClass="form-control">
                                                          <asp:ListItem Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    </tr>
                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                         <asp:Label CssClass="label"  Text="Credit Expense A/C Name 2" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                          <asp:DropDownList ID="DdlCreditExpenseACName2" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0"></asp:ListItem>
                                                           </asp:DropDownList>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                       <asp:Label CssClass="label"  Text="Debit Expence A/C Name 2" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                          <asp:DropDownList ID="DdlDebitExpenseACName2" runat="server" CssClass="form-control">
                                                              <asp:ListItem Value="0"></asp:ListItem>
                                                               </asp:DropDownList>
                                                    </td>


                                                  
                                                  
                                                </tr>




                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                         <asp:Label CssClass="label"  Text="Credit Expense A/C Name 3" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                         <asp:DropDownList ID="DdlCreditExpenseACName3" runat="server" CssClass="form-control">
                                                           <asp:ListItem Value="0"></asp:ListItem>
                                                         </asp:DropDownList>
                                                    </td>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label"  Text="Debit Expence A/C Name 3" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                      <asp:DropDownList ID="DdlDebitExpenseACName3" runat="server" CssClass="form-control">
                                                       <asp:ListItem Value="0"></asp:ListItem>
                                                         </asp:DropDownList>
                                                    </td>

                                                   

                                                </tr>

                                                <tr>
                                                      <td align="right" style="padding-bottom: 10px;">
                                                          <asp:Label CssClass="label"  Text="Branch Service Credit A/C Name" runat="server"></asp:Label>
                                                    </td>


                                                      <td style="padding-left: 10px;">
                                                         <asp:DropDownList ID="DdlBranchServiceCreditAC" runat="server" CssClass="form-control">
                                                          <asp:ListItem Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                         <asp:Label CssClass="label"  Text="Branch Service Debit A/C Name" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                         <asp:DropDownList ID="DdlBranchServiceDebitAC" runat="server" CssClass="form-control">
                                                           <asp:ListItem Value="0"></asp:ListItem>
                                                         </asp:DropDownList>
                             
                                                    </td>
                                                </tr>

                                                <tr>
                                                     <td align="right" style="padding-bottom: 10px;">
                                                          <asp:Label CssClass="label"  Text="Branch Received Credit A/C Name" runat="server"></asp:Label>
                                                    </td>
                                                     <td style="padding-left: 10px;">
                                                         <asp:DropDownList ID="DdlBranchReceivedCreditAC" runat="server" CssClass="form-control">
                                                          <asp:ListItem Value="0"></asp:ListItem>
                                                         </asp:DropDownList>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                         <asp:Label CssClass="label"  Text="Branch Received Debit A/C Name" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                          <asp:DropDownList ID="DdlBranchReceivedDebitAC" runat="server" CssClass="form-control">
                                                             <asp:ListItem Value="0"></asp:ListItem>
                                                         </asp:DropDownList>
                                                    </td>
                                                </tr>

                                           </table>
                                      </div>
                              </div>
                              

                              

                                      
                         <%--   <div class="col-md-12">
                            <div class="col-md-6">
                                <asp:Label CssClass="label"  Text="Credit Expense A/C Name 1" runat="server"></asp:Label>
                                 <asp:DropDownList ID="DdlCreditExpenseACName1" runat="server" CssClass="form-control">
                                      <asp:ListItem Value="0"></asp:ListItem>
                                  </asp:DropDownList>
                               </div>
                            <div class="col-md-6">
                                <asp:Label CssClass="label"  Text="Debit Expence A/C Name 1" runat="server"></asp:Label>
                                <asp:DropDownList ID="DdlDebitExpenseACName1" runat="server" CssClass="form-control">
                                     <asp:ListItem Value="0"></asp:ListItem>
                                  </asp:DropDownList>
                               </div>
                            </div>

                            <div class="col-md-12">
                            <div class="col-md-6">
                                <asp:Label CssClass="label"  Text="Credit Expense A/C Name 2" runat="server"></asp:Label>
                                 <asp:DropDownList ID="DdlCreditExpenseACName2" runat="server" CssClass="form-control">
                                      <asp:ListItem Value="0"></asp:ListItem>
                                  </asp:DropDownList>
                              </div>
                            <div class="col-md-6">
                                <asp:Label CssClass="label"  Text="Debit Expence A/C Name 2" runat="server"></asp:Label>
                                  <asp:DropDownList ID="DdlDebitExpenseACName2" runat="server" CssClass="form-control">
                                       <asp:ListItem Value="0"></asp:ListItem>
                                  </asp:DropDownList>
                                </div>
                             </div>

                            <div style="clear: both; height: 10px;">
                            </div>

                            <div class="col-md-12">
                            <div class="col-md-6">
                                <asp:Label CssClass="label"  Text="Credit Expense A/C Name 3" runat="server"></asp:Label>
                                 <asp:DropDownList ID="DdlCreditExpenseACName3" runat="server" CssClass="form-control">
                                      <asp:ListItem Value="0"></asp:ListItem>
                                  </asp:DropDownList>
                              </div>
                            <div class="col-md-6">
                                <asp:Label CssClass="label"  Text="Debit Expence A/C Name 3" runat="server"></asp:Label>
                                 <asp:DropDownList ID="DdlDebitExpenseACName3" runat="server" CssClass="form-control">
                                      <asp:ListItem Value="0"></asp:ListItem>
                                  </asp:DropDownList>
                            
                            </div>
                            </div>--%>


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
                                        <asp:Button ID="Btncalldel" runat="server" Text="DELETE" OnClick="Btncalldel_Click"  CssClass="btn btn-lg btn-primary btn-block" />
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
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" OnClick="BtnAdd_OnClick" CssClass="btn btn-lg btn-primary" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />
        </div>
        <asp:HiddenField ID="HfBRANCH_CODE" runat="server" />
        
         
        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">



                <div class="table-responsive">
                    <asp:GridView ID="GvBranch" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvBranch_PageIndexChanging"
                        OnRowCommand="GvBranch_RowCommand" PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>
                            <%-- <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                  <asp:Button ID="btnEdit" runat="server" CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("BRANCH_CODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn btn-link btn-dark"></asp:Button>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                       <asp:Button ID="btnDelete" runat="server" CausesValidation="false" CommandName="Deletea" OnClientClick="return confirm('Are you sure you want to Delete the Branch Record?');" CommandArgument='<%#Bind("BRANCH_CODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn btn-link btn-dark"></asp:Button>
                                </ItemTemplate>
                                </asp:TemplateField> --%>

                            <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("BRANCH_CODE") %>'  ToolTip="View" BorderStyle="None"><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>
                                    <asp:HiddenField ID="HfBRANCH_CODE" runat="server" Value='<%#Bind("BRANCH_CODE")%>' />

                                    <asp:LinkButton CssClass="spaceleft" ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("BRANCH_CODE") %>' ToolTip="Edit" Text="EDIT" BorderStyle="None"><i class="fa fa-pencil" aria-hidden="true"></i></asp:LinkButton>

                                    <asp:LinkButton CssClass="spaceleft" ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("BRANCH_CODE") %>' ToolTip="Delete" Text="DELETE" BorderStyle="None"><i class="fa fa-trash-o" aria-hidden="true"></i></asp:LinkButton>

                                </ItemTemplate>
                            </asp:TemplateField>


                            <%--<asp:TemplateField HeaderText="SR.NO.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                            </asp:TemplateField> --%>
                            <asp:TemplateField HeaderText="COMPANY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblCompanyName" runat="server" Text='<%#Bind("CompanyName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BRANCH NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign"  ID="lblBranchName" runat="server" Text='<%#Bind("BRANCH_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="BRANCH CODE">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblBranchCode" runat="server" Text='<%#Bind("BRANCH_CODE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SHORT">
                                <ItemTemplate>
                                    <asp:Label CssClass="label"  ID="lblBranchShort" runat="server" Text='<%#Bind("BRANCH_SHORT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField> --%>

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

    <script src="js/proton.js"></script>


        <div class="modal fade" tabindex="-1" id="CmpBranchSelection" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        
                        <h4 class="modal-title">DELETE BRANCH</h4>
                    </div>
                    <div class="modal-body">
                        
                        
                       <span>Are you sure want to delete...!!!</span>
                      <br />
                      
                         <div id="Div1" runat="server" class="grids">

                      <div class="panel panel-widget top-grids">

                                    <asp:Button ID="btnDelete" runat="server" Text="YES"  CssClass="btn btn-lg btn-primary"  OnClick="btnDelete_Click" CausesValidation="false" />
                                    <button type="button" class="btn btn-lg btn-primary"  data-dismiss="modal" value="NO">NO</button>
                          </div>
                         </div>
                        </div>
                     </div>
                </div>
            </div>
     <script type="text/javascript">
        function HideModel() {
            $("#CmpBranchSelection").modal('hide');
        }

        function ShowModel() {

            $("#CmpBranchSelection").modal('show');

        }
    </script>

     <script src="js/proton.js"></script>


        <div class="modal fade" tabindex="-1" id="CmpBranchSelection1" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        
                        <h4 class="modal-title">UPDATE BRANCH</h4>
                    </div>
                    <div class="modal-body">
                        
                        
                       <span>Are you sure want to update...!!!</span>
                      <br />
                      
                         <div id="Div2" runat="server" class="grids">

                      <div class="panel panel-widget top-grids">

                       <asp:Button ID="btnSave" runat="server" Text="YES" CssClass="btn btn-lg btn-primary" OnClick="btnSave_Click" />              
                        <button type="button" class="btn btn-lg btn-primary"  data-dismiss="modal" value="NO">NO</button>
                           </div>

                         </div>
                    </div>


                </div>
            </div>
        </div>

     <script type="text/javascript">
        function HideModel1() {
            $("#CmpBranchSelection1").modal('hide');
        }

        function ShowModel1() {

            $("#CmpBranchSelection1").modal('show');

        }
    </script>

</asp:Content>
