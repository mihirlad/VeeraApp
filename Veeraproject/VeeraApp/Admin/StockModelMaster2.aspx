<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="StockModelMaster2.aspx.cs" Inherits="VeeraApp.StockModelMaster2" %>

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
                    <h4>STOCK MODEL MASTER</h4>

                </div>
            </div>
        </div>
    </div>
    
          BRAND NAME :-   <asp:Label style="padding-right:5px; margin:0;color:red;" ID="lblBrandname" runat="server" ></asp:Label>
         MODEL TYPE NAME :-  <asp:Label style="padding-left:0; margin:0;color:red;" ID="lblModeltypename" runat="server" ></asp:Label>
       
    <%--  <div style="clear: both; height: 10px">
    </div>--%>

   

     
    <div class="panel panel-widget forms-panel">
        <div id="DivEntry" runat="server" class="forms">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">

                <div class="form-body">
                    <div class="form-horizontal form-bordered">
                        <div class="form-group" style="border-bottom: none;">

                             <asp:UpdatePanel ID="udpmas" runat="server">
                              <ContentTemplate>
                            <div class="h5" style="color:brown">STOCK MODEL MASTER</div>
                            <div class="col-md-12">
                                <div class="col-md-3">
                                    <asp:Label CssClass="label" Text="Model Name" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtModelName" CssClass="form-control" runat="server"></asp:TextBox>

                                       <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldTxtProductName" runat="server"
                                        ControlToValidate="TxtModelName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label CssClass="label" Text="Model Description" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtModelDescription" CssClass="form-control" runat="server"></asp:TextBox>

                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="TxtModelDescription" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>

                                 <div class="col-md-2">
                                     <asp:Button ID="BtnCopyModelItem" runat="server" Text="Copy Model Item" Height="33px" OnClick="BtnCopyModelItem_Click" CssClass="btn btn-danger btn-block"/>
                                </div>
                            </div>

                               </ContentTemplate>
                           </asp:UpdatePanel>
                            <div style="clear: both; height: 10px;">
                            </div>

                         

                            <div style="border: 1px solid blue; width: 49%; height:auto; float: right">


                                <div class="panel panel-widget top-grids">
                                    <div class="chute chute-center text-center">

                                        <asp:UpdatePanel ID="UpdPnl" runat="server">
                                            <ContentTemplate>

                                                <div class="table-responsive" style="height: 300px; overflow-y: scroll">
                                                       <div class="h5" style="color:brown">STOCK MODEL COST</div>
                                                    <asp:GridView ID="GvStockModelCost" CssClass="table table-vcenter table-condensed table-bordered"
                                                        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvStockModelCost_PageIndexChanging"
                                                        PageSize="10" ShowFooter="true" OnRowDataBound="GvStockModelCost_RowDataBound">
                                                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="FROM AMOUNT">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="HfCostlevel" runat="server" Value='<%#Bind("COST_LEVEL") %>' />
                                                                         <%--   <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SRNO") %>' />--%>

                                                                    <asp:TextBox CssClass="form-control" ID="TxtFromAmt" onkeypress="return isNumber(event);" style="text-align:right;" runat="server" Text='<%#Bind("FRAMT") %>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="TO AMOUNT">
                                                                <ItemTemplate>
                                                                    <asp:TextBox CssClass="form-control" ID="TxtToAmt" onkeypress="return isNumber(event);" style="text-align:right;" runat="server" Text='<%#Bind("TOAMT") %>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="COST LEVEL">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList runat="server" ID="DdlCostlevel">
                                                                        <asp:ListItem Text="LOW" Value="L"></asp:ListItem>
                                                                        <asp:ListItem Text="MEDIUM" Value="M"></asp:ListItem>
                                                                        <asp:ListItem Text="HIGH" Value="H"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="BtnDeleteRowModelCostGrid" runat="server" OnClick="BtnDeleteRowModelCostGrid_Click" Text="Remove" Font-Underline="true">Remove</asp:LinkButton>
                                                                </ItemTemplate>

                                                                <FooterStyle HorizontalAlign="Right" />
                                                                <FooterTemplate>
                                                                    <asp:Button ID="BtnAddRowModelCostGrid" runat="server" Text="Add New Row" OnClick="BtnAddRowModelCostGrid_Click" />
                                                                </FooterTemplate>
                                                            </asp:TemplateField>


                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>



                                <%--  --%>

                                <div style="border: 1px solid blue; width: 49%; height:auto; float: left">


                                    <div class="panel panel-widget top-grids">
                                        <div class="chute chute-center text-center">

                                            <asp:UpdatePanel ID="UpdPnl2" runat="server">
                                                <ContentTemplate>



                                                    <div class="table-responsive" style="height: 300px; overflow-y: scroll">
                                                        <div class="h5" style="color:brown">STOCK MODEL DETAILS</div>
                                                        <asp:GridView ID="GvStockModalDetails" CssClass="table table-vcenter table-condensed table-bordered"
                                                            runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvStockModalDetails_PageIndexChanging" OnRowDataBound="GvStockModalDetails_RowDataBound"
                                                            PageSize="10" ShowFooter="true">
                                                            <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                            <Columns>

                                                             <asp:TemplateField HeaderText="Sr.No.">
                                                                 <ItemTemplate>
                                                                       <%#Container.DataItemIndex + 1 %>
                                                                 </ItemTemplate>
                                                              </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="ORDER">
                                                                    <ItemTemplate>
                                                                        <asp:HiddenField ID="HfDetailSCode" runat="server" Value='<%#Bind("SCODE") %>' />
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
                                                                <asp:TextBox ID="TxtProductName" ForeColor="Blue" Style="width: 300px;" runat="server" OnTextChanged="TxtProductName_TextChanged"  AutoPostBack="true"></asp:TextBox>
                                                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtProductName"
                                                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000"
                                                                    ServiceMethod="GetStockName">
                                                                </ajax:AutoCompleteExtender>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="PRODUCT NAME" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlProductName_SelectedIndexChanged" ID="DdlProductName"></asp:DropDownList>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="QUANTITY">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox CssClass="form-control" ID="TxtQuantity" onkeypress="return isNumber(event);" style="text-align:right;" runat="server" Text='<%#Bind("QTY") %>'></asp:TextBox>
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
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>

                                <div style="clear: both; height: 10px">
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
    </div>
    <div id="DivView" runat="server" class="grids">

        <div class="panel panel-widget top-grids">
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />
        </div>
        

        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfBrandCode" runat="server" />
        <asp:HiddenField ID="HfModelCode" runat="server" />
        <asp:HiddenField ID="HfSrNo" runat="server" />

        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">
                
                 <div class="tabl-respeonsive" style="height: 450px; overflow-y: scroll">
         
                <div class="table-responsive">
                    <asp:GridView ID="GvStockModelMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvStockModelMaster_PageIndexChanging" OnRowCommand="GvStockModelMaster_RowCommand"
                        OnRowDataBound="GvStockModelMaster_RowDataBound"
                        PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                            <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("MODEL_CODE") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <asp:HiddenField ID="HfBrandCodeGrid" runat="server" Value='<%#Bind("BRAND_CODE")%>' />
                                    <asp:HiddenField ID="HfCompCodeGrid" runat="server" Value='<%#Bind("COMP_CODE")%>' />
                                    <asp:HiddenField ID="HfModelCodeGrid" runat="server" Value='<%#Bind("MODEL_CODE")%>' />

                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("MODEL_CODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("MODEL_CODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                    <a href="JavaScript:divexpandcollapse('div<%# Eval("MODEL_CODE") %>');">
                                        <img id='imgdiv<%# Eval("MODEL_CODE") %>' width="15px" border="0" src="/images/plus.gif" />
                                    </a>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="MODEL NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblModelName" runat="server" Text='<%#Bind("MODEL_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="MODEL DESCRIPTION">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblModelDescrption" runat="server" Text='<%#Bind("MODEL_DESC") %>'></asp:Label>

                                    <tr>
                                        <td colspan="100%">
                                            <div id='div<%#Eval("MODEL_CODE") %>' class="table-responsive" style="display: none; background-color: lightgray">
                                                <div style="border:1px solid red; background:#00bcd4; color:white; padding:1px; border-radius:7px;">
                                                   <h4>STOCK MODEL DETAILS</h4>
                                               </div>
                                                <asp:GridView ID="GvNestedStockModalDetails" style="background:#e6ffee;" CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                                    PageSize="10" ShowFooter="true">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="ORDER">
                                                            <ItemTemplate>
                                                                <asp:Label   ID="TxtOrder" CssClass="label grdcenteralign" runat="server" Text='<%#Bind("ORD") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT NAME">
                                                            <ItemTemplate>
                                                                <%--<asp:DropDownList runat="server" ID="DdlProductName"></asp:DropDownList>--%>
                                                                <asp:Label ID="lblproductname" CssClass="label grdleftalign" Text='<%#Bind("ProductName") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRODUCT CODE">
                                                            <ItemTemplate>
                                                                <asp:Label CssClass="label grdcenteralign" ID="TxtProductCode" runat="server" Text='<%#Bind("ProductCode") %>'></asp:Label>
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

                                                                <%--  <tr>
                                                                    <td colspan="100%">
                                                                        <div id='div<%#Eval("MODEL_CODE") %>' class="table-responsive" style="display: none; background-color: lightgray">          
                                                                        </div>
                                                                    </td>
                                                                </tr>--%>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>



                                                    </Columns>
                                                </asp:GridView>

                                               <div style="border:1px solid red; background:#00bcd4; color:white; padding:1px; border-radius:7px;">
                                                   <h4>STOCK MODEL COST</h4>
                                               </div>
                                                
                                                <asp:GridView ID="GvNestedStockModelCost" style="background:#e6ffee;"  CssClass="table table-vcenter table-condensed table-bordered"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="FROM AMOUNT">
                                                            <ItemTemplate>
                                                                <%--  <asp:HiddenField ID="HfModelCode" runat="server" Value='<%#Bind("MODEL_CODE") %>' />
                                                                          <asp:HiddenField ID="HfSrNo" runat="server" Value='<%#Bind("SRNO") %>' />--%>

                                                                <asp:Label  ID="TxtFromAmt" CssClass="label grdrightalign" runat="server" Text='<%#Bind("FRAMT") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="TO AMOUNT">
                                                            <ItemTemplate>
                                                                <asp:Label ID="TxtToAmt" CssClass="label grdrightalign" runat="server" Text='<%#Bind("TOAMT") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="COST LEVEL">
                                                            <ItemTemplate>
                                                              <%--  <asp:DropDownList runat="server" ID="DdlCostlevel">
                                                                    <asp:ListItem Text="LOW" Value="L"></asp:ListItem>
                                                                    <asp:ListItem Text="MEDIUM" Value="M"></asp:ListItem>
                                                                    <asp:ListItem Text="HIGH" Value="H"></asp:ListItem>
                                                                </asp:DropDownList>--%>
                                                                <asp:Label ID="lblcostlevel" CssClass="label grdleftalign" runat="server" Text='<%#Bind("costlevel") %>'> </asp:Label>
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



     <script src="js/proton.js"></script>

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
        </script>

</asp:Content>
