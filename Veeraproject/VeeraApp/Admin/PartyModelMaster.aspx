<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="PartyModelMaster.aspx.cs" Inherits="VeeraApp.PartyModelMaster" %>

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
                    <h4>PARTY MODEL MASTER</h4>
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

                          


                             <div class="h5" style="color:brown">PARTY MODEL MASTER</div>
                              <div class="col-md-12">
                                <div class="col-md-3">
                                  <asp:Label CssClass="label" Text="Name of the Party Name" ForeColor="Blue" runat="server"></asp:Label>
                              <%--    <asp:DropDownList ID="DdlAccountName" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlAccountName_OnSelectedIndexChanged" AutoPostBack="true">
                                  </asp:DropDownList>   --%>

                                         <asp:TextBox ID="TxtAccountName" OnTextChanged="TxtAccountName_TextChanged" AutoPostBack="true" ForeColor="Blue" CssClass="form-control" runat="server"></asp:TextBox>
                                          <asp:HiddenField ID="HfACODE" runat="server" />
                                         <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtAccountName"
                                                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                            ServiceMethod="GetAccountName">
                                         </ajax:AutoCompleteExtender>
 
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredDdlCategoryName" runat="server" InitialValue="0"
                                        ControlToValidate="TxtAccountName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                  </div>

                                    <div class="col-md-1">
                                   <asp:Label CssClass="label" Text="Model Sr.No." runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtModelSrNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                  <div class="col-md-1">
                                   <asp:Label CssClass="label" Text="Party Sr.No." runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtPartySrNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                   <div class="col-md-2">
                                  <asp:Label CssClass="label" Text="Brand Name" ForeColor="Blue" runat="server"></asp:Label>
                                  <asp:DropDownList ID="DdlBrandName" runat="server" ForeColor="Blue" CssClass="form-control" OnSelectedIndexChanged="DdlBrandName_SelectedIndexChanged" AutoPostBack="true">
                                  </asp:DropDownList>

                                  <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" InitialValue="0"
                                        ControlToValidate="DdlBrandName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                   </div>
                                  <div class="col-md-2">
                                  <asp:Label CssClass="label" Text="Model Name" ForeColor="Blue" runat="server"></asp:Label>
                                  <asp:DropDownList ID="DdlModelName" runat="server" ForeColor="Blue" CssClass="form-control">
                                  </asp:DropDownList>

                                   <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" InitialValue="0"
                                        ControlToValidate="DdlModelName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>

                                       
                                   <div class="col-md-2">
                                   <asp:Label CssClass="label" Text="Model Remark" runat="server"></asp:Label>
                                   <asp:TextBox ID="TxtModelRemark" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-1">
                                   <asp:Label CssClass="label" Text="Active" runat="server"></asp:Label>
                                   <asp:DropDownList ID="DdlActive" runat="server" CssClass="form-control">
                                       <asp:ListItem Value="Y">YES</asp:ListItem>
                                       <asp:ListItem Value="N">NO</asp:ListItem>
                                   </asp:DropDownList>

                                    </div>
                                  </div>

                                 <div style="clear: both; height: 10px">
                                 </div>

                                  <div style="float: left; height: auto; width: 60%;">
                                      <div class="col-md-12">
                                       <table class="col-md-12">
                                        <tr>
                                            <td align="right" style="padding-bottom: 10px;">
                                                 <asp:Label CssClass="label" Text="Mfg.Sr.No." runat="server"></asp:Label>
                                            </td>
                                            <td style="padding-left: 10px;">
                                                  <asp:TextBox ID="TxtMfgSrNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </td>
                                            <td align="right" style="padding-bottom: 10px;">
                                                 <asp:Label CssClass="label" Text="Installation Date" runat="server"></asp:Label>
                                            </td>
                                            <td style="padding-left: 10px;">
                                                <asp:TextBox ID="TxtInstallationDate" CssClass="form-control" runat="server"></asp:TextBox>

                                           <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ControlToValidate="TxtInstallationDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                            ErrorMessage="INVALID DATE" ForeColor="Red" ></asp:RegularExpressionValidator>

                                      <%-- <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                            ControlToValidate="TxtToDate" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                            <ajax:CalendarExtender runat="server" ID="CalendarExtender1" Format="dd-MM-yyyy" TargetControlID="TxtInstallationDate"></ajax:CalendarExtender>
                                            </td>
                                            </tr>
                                           <tr>
                                               <td align="right" style="padding-bottom: 10px;">
                                                    <asp:Label CssClass="label" Text="Service Type" runat="server"></asp:Label>
                                               </td>
                                               <td style="padding-left: 10px;">
                                                    <asp:DropDownList ID="DdlServiceType" runat="server" CssClass="form-control">
                                                      <asp:ListItem Value="0">Select Type</asp:ListItem>
                                                      <asp:ListItem Value="A">AMC</asp:ListItem>
                                                      <asp:ListItem Value="C">Call Charges</asp:ListItem>
                                                      <asp:ListItem Value="W">Under Warranty</asp:ListItem>
                                                   </asp:DropDownList>

                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" InitialValue="0"
                                            ControlToValidate="DdlServiceType" ForeColor="Red">*</asp:RequiredFieldValidator>
                                                </td>
                                               <td align="right" style="padding-bottom: 10px;">
                                                    <asp:Label CssClass="label" Text="Service Person Name" ForeColor="Blue" runat="server"></asp:Label>
                                               </td>
                                               <td style="padding-left: 10px;">
                                                <asp:DropDownList ID="DdlServicePersonName" runat="server" ForeColor="Blue" CssClass="form-control">
                                                  </asp:DropDownList>

                                               <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server" InitialValue="0"
                                                       ControlToValidate="DdlServicePersonName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td align="right" style="padding-bottom: 10px;">
                                                       <asp:Label CssClass="label" Text="Last AMC No." runat="server"></asp:Label>
                                               </td>
                                               <td style="padding-left: 10px;">
                                                     <asp:TextBox ID="TxtLastAMCNo" CssClass="form-control" runat="server"></asp:TextBox>
                                               </td>
                                               <td align="right" style="padding-bottom: 10px;">
                                                   <asp:Label CssClass="label" Text="Last AMC Date" runat="server"></asp:Label>
                                               </td>
                                               <td style="padding-left: 10px;">
                                                    <asp:TextBox ID="TxtLastAMCDate" CssClass="form-control" runat="server"></asp:TextBox>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td align="right" style="padding-bottom: 10px;">
                                                   <asp:Label CssClass="label" Text="AMC From Date" runat="server"></asp:Label>
                                               </td>
                                               <td style="padding-left: 10px;">
                                                    <asp:TextBox ID="TxtAMCFromDate" CssClass="form-control" runat="server"></asp:TextBox>
                                               </td>
                                               <td align="right" style="padding-bottom: 10px;">
                                                     <asp:Label CssClass="label" Text="AMC To Date" runat="server"></asp:Label>
                                               </td>
                                               <td  style="padding-left: 10px;">
                                                     <asp:TextBox ID="TxtToDate" CssClass="form-control" runat="server"></asp:TextBox>
                                               </td>
                                             
                                           </tr>
                                           <tr>
                                               <td align="right" style="padding-bottom: 10px;">
                                                   <asp:Label CssClass="label" Text="Other Remarks" runat="server"></asp:Label>
                                               </td>
                                               <td colspan="3" style="padding-left: 10px;">
                                                     <asp:TextBox ID="TxtOtherRemarks" CssClass="form-control" runat="server"></asp:TextBox>
                                               </td>
                                                 <td>
                                                   
                                     <asp:Button ID="BtnCopyModelItem" runat="server" Text="Copy Model Item" Height="33px" OnClick="BtnCopyModelItem_Click" CssClass="btn btn-danger btn-block"/>
                               
                                               </td>
                                           </tr>
                                        </table>
                                    </div>
                                </div>


                                 
                                  <%--  </ContentTemplate>
                                </asp:UpdatePanel>--%>

                              <div style="clear: both; height: 10px;">
                                </div>

                            

                             <div class="panel panel-widget top-grids">
                                        <div class="chute chute-center text-center">

                                            <%--<asp:UpdatePanel ID="UpdPnl2" runat="server">
                                                <ContentTemplate>--%>



                                                    <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                        <div class="h5" style="color:brown">PARTY MODEL DETAILS</div>
                                                        <asp:GridView ID="GvPartyModalDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                                            runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvPartyModalDetails_PageIndexChanging" OnRowDataBound="GvPartyModalDetails_RowDataBound"
                                                            PageSize="10" ShowFooter="true">
                                                            <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                            <Columns>

                                                                <asp:TemplateField HeaderText="ORDER" ControlStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />
                                                                         <asp:HiddenField ID="HfDetailACode" runat="server" Value='<%#Bind("ACODE") %>' />
                                                                          <asp:HiddenField ID="HfDetailSrNo" runat="server" Value='<%#Bind("SRNO") %>' />
                                                                        <asp:TextBox CssClass="form-control" ID="TxtOrder" runat="server" Text='<%#Bind("ORD") %>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>


                                                             <asp:TemplateField HeaderText="PRODUCT CODE">
                                                                  <ItemTemplate>
                                                                   <asp:TextBox ID="TxtProductCode" ForeColor="Blue" Style="width: 100px;" runat="server" OnTextChanged="TxtProductCode_TextChanged"  AutoPostBack="true"></asp:TextBox>
                                                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtenderProdCode" runat="server" TargetControlID="TxtProductCode"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetProductCode">
                                                                </ajax:AutoCompleteExtender>
                                                              </ItemTemplate>
                                                           </asp:TemplateField>

                                                       <asp:TemplateField HeaderText="PRODUCT NAME">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TxtProductName" ForeColor="Blue" Style="width: 400px;" runat="server" OnTextChanged="TxtProductName_TextChanged"  AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtProductName"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetStockName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="PRODUCT NAME" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList runat="server" ForeColor="Blue" ID="DdlProductName"></asp:DropDownList>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                 <asp:TemplateField HeaderText="QUANTITY" ControlStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox CssClass="form-control" ID="TxtQuantity"  onkeypress="return isNumber(event);" style="text-align:right;" runat="server" Text='<%#Bind("QTY") %>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="M">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ChkBoxMajor" runat="server" Checked='<%#Convert.ToBoolean(Eval("CHK_MAJOR")) %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="N">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ChkBoxNormal" runat="server" Checked='<%#Convert.ToBoolean(Eval("CHK_NORMAL")) %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="BtnDeleteRowModelDetailGrid" runat="server" OnClick="BtnDeleteRowModelDetailGrid_Click" Text="Remove" Font-Underline="true">Remove</asp:LinkButton>
                                                                    </ItemTemplate>

                                                                    <FooterStyle HorizontalAlign="Right" />
                                                                    <FooterTemplate>
                                                                        <asp:Button ID="BtnAddRowModelDetailGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelDetailGrid_Click" />
                                                                    </FooterTemplate>
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
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />

         <div style="float:right;">
             <asp:Label CssClass="label" style="color:red;" Text="Search By Account Name/Brand Name/Model Name" runat="server"></asp:Label><br />
              <asp:TextBox ID="TxtSearch"  runat="server" style="width: 100%;" OnTextChanged="TxtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
        </div>
        

        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBranchCode" runat="server" />
        <asp:HiddenField ID="HfAccountCode" runat="server" />
        <asp:HiddenField ID="HfSrNo" runat="server" />
        <asp:HiddenField ID="HfSubSrNo" runat="server" />

        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

                <div class="tabl-respeonsive" style="height: 450px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvPartyModelMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvPartyModelMaster_PageIndexChanging" OnRowCommand="GvPartyModelMaster_RowCommand" 
                        OnRowDataBound="GvPartyModelMaster_RowDataBound"
                        
                        PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                            <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("SRNO") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <asp:HiddenField ID="HfBranchCodeGrid" runat="server" Value='<%#Bind("BRANCH_CODE")%>' />
                                    <asp:HiddenField ID="HfCompCodeGrid" runat="server" Value='<%#Bind("COMP_CODE")%>' />
                                    <asp:HiddenField ID="HfSrNoGrid" runat="server" Value='<%#Bind("SRNO")%>' />

                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("SRNO") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("SRNO") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                      <a href="JavaScript:divexpandcollapse('div<%# Eval("SRNO") %>');">
                                        <img id='imgdiv<%# Eval("SRNO") %>' width="15px" border="0" src="/images/plus.gif" />
                                    </a>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ACCOUNT NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblAccountName" runat="server" Text='<%#Bind("AccountName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="BRAND NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblBrandName" runat="server" Text='<%#Bind("BrandName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                               <asp:TemplateField HeaderText="MODEL NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblModelName" runat="server" Text='<%#Bind("ModelName") %>'></asp:Label>


                                      <tr>
                                        <td colspan="100%">
                                            <div id='div<%#Eval("SRNO") %>' class="table-responsive" style="display: none; background-color: lightgray">
                                                <div style="border:1px solid red; background:#00bcd4; color:white; padding:1px; border-radius:7px;">
                                                   <h4>PARTY MODEL DETAILS</h4>
                                               </div>

                                                <asp:GridView ID="GvNestedPartyModalDetails" style="background:#e6ffee;" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                                    PageSize="10">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="ORDER">
                                                            <ItemTemplate>
                                                                <asp:Label  ID="TxtOrder" runat="server" CssClass="label grdcenteralign" Text='<%#Bind("ORD") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT NAME">
                                                            <ItemTemplate>
                                                                <%--<asp:DropDownList runat="server" ID="DdlProductName"></asp:DropDownList>--%>
                                                                <asp:Label ID="lblproductname" CssClass="label grdcenteralign" Text='<%#Bind("ProductName") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT CODE">
                                                            <ItemTemplate>
                                                                <asp:Label ID="TxtProductCode" CssClass="label grdcenteralign" runat="server" Text='<%#Bind("ProductCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="QUANTITY">
                                                            <ItemTemplate>
                                                                <asp:Label  ID="TxtQuantity" CssClass="label grdcenteralign" runat="server" Text='<%#Bind("QTY") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="M">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkBoxMajor" Enabled="false" runat="server" Checked='<%#Convert.ToBoolean(Eval("CHK_MAJOR")) %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="N">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkBoxNormal" Enabled="false" runat="server" Checked='<%#Convert.ToBoolean(Eval("CHK_NORMAL")) %>' />
                                                           </ItemTemplate>
                                                   </asp:TemplateField>

                                                 </Columns>
                                                </asp:GridView>
                                              </div>
                                           </td>
                                        </tr>
                                    </div>
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

                    <h4 class="modal-title">DELETE MODEL MASTER DETAIL</h4>
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

                        <h4 class="modal-title">UPDATE MODEL MASTER DETAIL</h4>
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




    <%--  <script src="js/proton.js"></script>

        <div class="modal fade" tabindex="-1" id="CmpCopyModelItems" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title" style="color:red">Copy Model Items</h4>
                    </div>
                    <div class="modal-body">

                        <div id="Div4" runat="server" class="grids">

                            <div class="panel panel-widget top-grids">
                                <asp:UpdatePanel ID="updexportacc" runat="server">
                                    <ContentTemplate>
                                        Brand Name
                            <asp:DropDownList ID="DdlBrandNameCopy" runat="server" CssClass="form-control" OnSelectedIndexChanged="DdlBrandNameCopy_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>

                                        Model Name
                            <asp:DropDownList ID="DdlModelNameCopy" runat="server" OnSelectedIndexChanged="DdlModelNameCopy_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                                <asp:ListItem Value="0"></asp:ListItem>
                            </asp:DropDownList>

                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <br />

                                <asp:Button ID="BtnCopyProcess" runat="server" Text="Copy Process" CssClass="btn btn-lg btn-primary" Width="200px" OnClick="BtnCopyProcess_Click"  CausesValidation="false" />
                                <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal" value="NO">BACK</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            function HideModelCopyModelItem() {
                $("#CmpCopyModelItems").modal('hide');
            }

            function ShowModelCopyModelItem() {

                $("#CmpCopyModelItems").modal('show');

            }
        </script>--%>

</asp:Content>
