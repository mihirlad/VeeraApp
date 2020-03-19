<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeMaster.aspx.cs" Inherits="VeeraApp.Admin.EmployeeMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

          <link href="../css/model.css" rel="stylesheet" />
    <script type="text/javascript">
        function txtachange() {
            //  alert("jigar");
            document.getElementById("btnSubmit").onchange();
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
                    <h4>EMPLOYEE MASTER</h4>
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

                            <asp:UpdatePanel ID="updpnl" runat="server">
                                <ContentTemplate>

                                 <asp:HiddenField ID="HfEmployeeCode" runat="server" />


                                    <div class="h5" style="color: brown">Employee Master</div>


                                    <div class="col-md-12">
                                        <div class="col-md-1">
                                           <asp:Label CssClass="label" Text="Ref.Emp.Code" runat="server"></asp:Label>
                                            <asp:TextBox ID="TxtRefEmpCode"  AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="col-md-3">
                                               <asp:Label CssClass="label" Text="Employee Name" runat="server"></asp:Label>
                                             <asp:TextBox ID="TxtEmployeeName"  AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>

                                        
                                        <div class="col-md-1">
                                            <asp:HiddenField ID="HfCategoryCode" runat="server" />

                                               <asp:Label CssClass="label" Text="Job Category" ForeColor="Blue" runat="server"></asp:Label>
                                             <asp:TextBox ID="TxtJobCategory" OnTextChanged="TxtJobCategory_TextChanged"  AutoPostBack="true" CssClass="form-control" ForeColor="Blue" runat="server"></asp:TextBox>

                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtenderTxtJobCategory" runat="server" TargetControlID="TxtJobCategory"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetEmployeeJobCategory">
                                                        </ajax:AutoCompleteExtender>
                                        </div>

                                          
                                        <div class="col-md-2">
                                              <asp:HiddenField ID="HfDesignationCode" runat="server" />

                                               <asp:Label CssClass="label" Text="Designation" ForeColor="Blue" runat="server"></asp:Label>
                                             <asp:TextBox ID="TxtDesignation" OnTextChanged="TxtDesignation_TextChanged"  AutoPostBack="true" CssClass="form-control" ForeColor="Blue" runat="server"></asp:TextBox>

                                            <ajax:AutoCompleteExtender ID="AutoCompleteTxtDesignation" runat="server" TargetControlID="TxtDesignation"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetEmployeeDesignationName">
                                             </ajax:AutoCompleteExtender>
                                        </div>

                                      <div class="col-md-1">
                                            <asp:Label CssClass="label" Text="Branch Name" runat="server"></asp:Label>
                                            <asp:DropDownList ID="DdlBranchName" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" InitialValue="0"
                                             ControlToValidate="DdlBranchName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </div>


                                         <div class="col-md-2">
                                               <asp:HiddenField ID="HfCreditExpenceACODE" runat="server" />

                                               <asp:Label CssClass="label" Text="Credit Expence A/C Name " runat="server"></asp:Label>
                                             <asp:TextBox ID="TxtCreditExpenceACName" OnTextChanged="TxtCreditExpenceACName_TextChanged"  AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                            <ajax:AutoCompleteExtender ID="AutoCompleteTxtCreditExpenceACName" runat="server" TargetControlID="TxtCreditExpenceACName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>
                                        </div>


                                         <div class="col-md-2">
                                               <asp:HiddenField ID="HfDebitExpenceACODE" runat="server" />

                                               <asp:Label CssClass="label" Text="Debit Expence A/C Name " runat="server"></asp:Label>
                                             <asp:TextBox ID="TxtDebitExpenceACName" OnTextChanged="TxtDebitExpenceACName_TextChanged"  AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>

                                            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtDebitExpenceACName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                                        </ajax:AutoCompleteExtender>
                                        </div>


                                    </div>

                                      <div style="clear: both; height: 10px;">
                                       </div>

                                       <div style="float: left; height: auto; width: 70%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">

                                                <tr>                                                
                                                    <td align="right" style="padding-bottom: 10px;">
                                                      <asp:Label CssClass="label" Text="Current Address 1" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtEmpCurrentADD1"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>


                                                   <td align="right" style="padding-bottom: 10px;">
                                                      <asp:Label CssClass="label" Text="Permanant Address 1" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                       <asp:TextBox ID="TxtEmpPermanantADD1"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                
                                                    </tr>    
                                                
                                                  <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="ADD 2" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtEmpCurrentADD2"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                           <asp:Label CssClass="label" Text="ADD 2" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                       <asp:TextBox ID="TxtEmpPermanantADD2"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                  </tr> 

                                                <tr>
                                                   <td align="right" style="padding-bottom: 10px;">
                                                          <asp:Label CssClass="label" Text="ADD 3" runat="server"></asp:Label>
                                                   </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtEmpCurrentADD3"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                           <asp:Label CssClass="label" Text="ADD 3" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                       <asp:TextBox ID="TxtEmpPermanantADD3"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                 <tr>
                                                   <td align="right" style="padding-bottom: 10px;">
                                                          <asp:Label CssClass="label" Text="ADD 3" runat="server"></asp:Label>
                                                   </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtEmpCurrentADD4"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                           <asp:Label CssClass="label" Text="ADD 4" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                       <asp:TextBox ID="TxtEmpPermanantADD4"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                     <td align="right" style="padding-bottom: 10px;">
                                                      <asp:Label CssClass="label" Text="Phone(R) " runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtEmpCurrentPhone_R"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>


                                                    <td align="right" style="padding-bottom: 10px;">
                                                      <asp:Label CssClass="label" Text="Phone(R) " runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtEmpPermanantPhone_R"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>


                                                <tr>

                                                   <td align="right" style="padding-bottom: 10px;">
                                                      <asp:Label CssClass="label" Text="Phone(M) " runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtEmpCurrentPhone_M"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                      <asp:Label CssClass="label" Text="Phone(M) " runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtEmpPermanantPhone_M"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                <tr>

                                                   <td align="right" style="padding-bottom: 10px;">
                                                      <asp:Label CssClass="label" Text="Ref.Contact Person" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtEmpCurrentRefContactName"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                     <td align="right" style="padding-bottom: 10px;">
                                                      <asp:Label CssClass="label" Text="Ref.Contact Person" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtEmpPermanentRefContactName"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                </tr>

                                                
                                                <tr>

                                                   <td align="right" style="padding-bottom: 10px;">
                                                      <asp:Label CssClass="label" Text="Ref.Contact Phone" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtEmpCurrentRefContactPhone"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                     <td align="right" style="padding-bottom: 10px;">
                                                      <asp:Label CssClass="label" Text="Ref.Contact Phone" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtEmpPermanentRefContactPhone"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>

                                                   </tr>
 
                                                </table>
                                            </div>
                                        </div>

                                       <div style="float: left; height: auto; width: 30%;">
                                        <div class="col-md-12">
                                            <table class="col-md-12">
                                             
                                                <tr>
                                                      <td align="right" style="padding-bottom: 10px;">
                                                      <asp:Label CssClass="label" Text="Join Date" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtJoinDate"  CssClass="form-control" runat="server"></asp:TextBox>

                                                         <ajax:CalendarExtender runat="server" ID="CalendarExtenderJobCardDate" Format="dd-MM-yyyy" TargetControlID="TxtJoinDate"></ajax:CalendarExtender>
                                                    </td>

                                                  <td align="right" style="padding-bottom: 10px; padding-left:10px;">
                                                      <asp:Label CssClass="label" Text="Left Date" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtLeftDate"  CssClass="form-control" runat="server"></asp:TextBox>

                                                         <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtLeftDate"></ajax:CalendarExtender>
                                                    </td>

                                                 </tr>

                                                <tr>
                                                        <td align="right" style="padding-bottom: 10px;">
                                                      <asp:Label CssClass="label" Text="Birth Date" runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="TxtBirthDate"  CssClass="form-control" runat="server"></asp:TextBox>

                                                         <ajax:CalendarExtender runat="server" ID="CalendarExtender2" Format="dd-MM-yyyy" TargetControlID="TxtBirthDate"></ajax:CalendarExtender>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                      <asp:Label CssClass="label" Text="PAN No." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="4">
                                                        <asp:TextBox ID="TxtPANNo"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                  <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                      <asp:Label CssClass="label" Text="Aadhar Card No." runat="server"></asp:Label>
                                                    </td>

                                                    <td style="padding-left: 10px;" colspan="4"> 
                                                        <asp:TextBox ID="TxtAadharCardNo"  CssClass="form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Salary Flag" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlSalaryFlag"  AutoPostBack="true" runat="server" CssClass="form-control">
                                                             <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                            <asp:ListItem Value="F">Fix</asp:ListItem>
                                                          <asp:ListItem Value="W">Wages</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                    <td align="right" style="padding-bottom: 10px;">
                                                        <asp:Label CssClass="label" Text="Active" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:DropDownList ID="DdlActiveFlag"  AutoPostBack="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">SELECT TYPE</asp:ListItem>
                                                            <asp:ListItem Value="A">Active</asp:ListItem>
                                                            <asp:ListItem Value="I">In-Active</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td></td>
                                                   <td style="padding-left: 15px;">
                                                        <asp:Button ID="BtnAddDesignation" runat="server" Text="Add Designation" Width="180px" Height="33px" OnClick="BtnAddDesignation_Click"
                                                            CausesValidation="false" CssClass="btn btn-danger btn-lg" />
                                                    </td>
                                                </tr>

                                                </table>
                                            </div>
                                           </div>

                                    </ContentTemplate>
                                    </asp:UpdatePanel>

                              <div style="clear: both; height: 10px;">
                            </div>


                              <%--INCREMENT (DETAILS) --%>

                            <div id="DivQuoteItem" runat="server" class="panel panel-widget top-grids">
                                <div class="chute chute-center text-center">

                                    <asp:UpdatePanel ID="UpdPnl2" runat="server">
                                        <ContentTemplate>

                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                <div class="h5" style="color: brown">INCREMENT DETAILS</div>
                                                <asp:GridView ID="GvIncrementTransactionDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                                    PageSize="10" ShowFooter="true">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Sr.No." HeaderStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HfCompCode" runat="server" Value='<%#Bind("COMP_CODE") %>' />
                                                                <asp:HiddenField ID="HfYearDate1" runat="server" Value='<%#Bind("YRDT1") %>' />
                                                                <asp:HiddenField ID="HfEmpCode" runat="server" Value='<%#Bind("EMP_CODE") %>' />
                                                               
                                                            
                                                                <%#Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="FROM DATE">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtFromDate" runat="server" CssClass="form-control" Text='<%#Bind("YRDT1") %>' Style="text-align: center" AutoPostBack="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="TO DATE">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtToDate" runat="server" CssClass="form-control" Text='<%#Bind("YRDT2") %>' Style="text-align: center"  AutoPostBack="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                     
                    
                                                        <asp:TemplateField HeaderText="BASIC RATE" HeaderStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtBasicRate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("BASIC_RATE") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="CONV. RATE" HeaderStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtConvRate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("CONV_RATE") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="MEDICAL RATE" HeaderStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtMedicalRate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("MEDICAL_RATE") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                          <asp:TemplateField HeaderText="HRA RATE" HeaderStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtHRARate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("HRA_RATE") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="OLD BASIC RATE" HeaderStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtOldBasicRate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("OLD_BASIC_RATE") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="OLD CONV. RATE" HeaderStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtOldConvRate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("OLD_CONV_RATE") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="OLD MEDICAL RATE" HeaderStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtOldMedicalRate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("OLD_MEDICAL_RATE") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                          <asp:TemplateField HeaderText="OLD HRA RATE" HeaderStyle-Width="150px">
                                                            <ItemTemplate>
                                                                <asp:TextBox CssClass="form-control" ID="TxtOldHRARate" onkeypress="return isNumber(event);" Style="text-align: right;" Text='<%#Bind("OLD_HRA_RATE") %>' runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        </Columns>
                                                </asp:GridView>

                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                            
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
       
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click"  />
            <asp:Button ID="btnexit" runat="server" Text="Exit"  CssClass="btn btn-lg btn-primary" CausesValidation="false" OnClick="btnexit_Click" />

            <div style="float: right;">
                <asp:Label CssClass="label" Style="color: red;" Text="Search " runat="server"></asp:Label><br />
                <asp:TextBox ID="TxtSearch" runat="server" Style="width: 100%;" AutoPostBack="true"></asp:TextBox>
            </div>

        </div>


        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBranchCode" runat="server" />
      
             <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                    <div class="table-responsive">
                        <asp:GridView ID="GvEmployeeMaster" CssClass="table table-vcenter table-condensed table-bordered" OnRowCommand="GvEmployeeMaster_RowCommand" OnPageIndexChanging="GvEmployeeMaster_PageIndexChanging"
                            runat="server" AutoGenerateColumns="false" AllowPaging="false" 
                            PageSize="10">
                            <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                            <Columns>

                                <asp:TemplateField HeaderText="ACTION">
                                    <ItemTemplate>
                                        <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("EMP_CODE") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                        <asp:HiddenField ID="HfCompCode" runat="server" Value='<%#Bind("COMP_CODE")%>' />
                                        <asp:HiddenField ID="HfEmpCode" runat="server" Value='<%#Bind("EMP_CODE")%>' />

                                        <asp:HiddenField ID="hfREC_UPD" runat="server" Value='<%#Bind("REC_UPD")%>' />
                                        <asp:HiddenField ID="hfREC_DEL" runat="server" Value='<%#Bind("REC_DEL")%>' />
                                        <asp:HiddenField ID="hfREC_INS" runat="server" Value='<%#Bind("REC_INS")%>' />

                                        <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("EMP_CODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                        <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("EMP_CODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>


                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="REF.EMP CODE">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="lblRefEmpCode" runat="server" Text='<%#Bind("REF_EMPCODE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="EMPLOYEE NAME">
                                    <ItemTemplate>
                                        <asp:Label CssClass="label" ID="lblEmployeeName" runat="server" Text='<%#Bind("EMP_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            <asp:TemplateField HeaderText="JOB CATEGORY">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblJobCategory" runat="server" Text='<%#Bind("CategoryName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DESIGNATION">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblDesignation" runat="server" Text='<%#Bind("DesignationName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CREDIT EXPENCE A/C NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblCreditAccountName" runat="server" Text='<%#Bind("CreditAccountName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                                
                            <asp:TemplateField HeaderText="DEBIT EXPENCE A/C NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label" ID="lblDebitAccountName" runat="server" Text='<%#Bind("DebitAccountName") %>'></asp:Label>
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

                    <h4 class="modal-title">DELETE EMPLOYEE MASTER DETAIL</h4>
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

                        <h4 class="modal-title">UPDATE EMPLOYEE MASTER DETAIL</h4>
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
