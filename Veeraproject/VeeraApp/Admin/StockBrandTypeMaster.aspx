<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Main.Master" AutoEventWireup="true" CodeBehind="StockBrandTypeMaster.aspx.cs" Inherits="VeeraApp.StockBrandTypeMaster" %>

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
                    <h4>STOCK BRAND TYPE MASTER</h4>
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

                         <div class="h5"  style="color:brown">STOCK BRAND TYPE MASTER</div> 

                            <div class="col-md-12">
                                <div class="col-md-4" style="padding-top: 5px;">
                                    <asp:Label CssClass="label" Text="Brand Type Name" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtBrandTypeName" style="width:75%" runat="server"></asp:TextBox>

                                     <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldTxtProductName" runat="server"
                                        ControlToValidate="TxtBrandTypeName" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-2">
                                    <asp:Button ID="BtnBrandComplainMaster" runat="server" Text="Complain Details" Height="33px" OnClick="BtnBrandComplainMaster_Click" CssClass="btn btn-md btn-danger btn-block" />
                                </div>

                                <div class="col-md-2">
                                    <asp:Button ID="BtnViewReports" runat="server" Text="View Check List Report" Height="33px" OnClick="BtnViewReports_Click" CssClass="btn btn-md btn-danger btn-block" />
                                </div>
                                
                                <div class="col-md-2">
                                     <asp:Button ID="BtnJobComplainMas" runat="server" Text="Complain Master" Height="33px" OnClick="BtnJobComplainMas_Click" CssClass="btn btn-md btn-danger btn-block" />
                                </div>
                            </div>

                            <div style="clear: both; height: 10px">
                            </div>

                           
                            <%-- <div class="col-md-12">
                                <div class="col-md-4">
                                    <asp:Label CssClass="label" Text="Work Desription" runat="server"></asp:Label>
                                    <asp:TextBox ID="TxtWorkDescription" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                            </div>--%>



                            <div style="clear: both; height: 10px;">
                            </div>


                            <%-- <div class="h5">STOCK BRAND TYPE DETAILS</div>--%>
                            <asp:UpdatePanel ID="updgvmaster" runat="server">
                                <ContentTemplate>

                                    <div class="panel panel-widget top-grids">
                                        <div class="chute chute-center text-center">


                                            <div class="table-responsive" style="height: 272px; overflow-y: scroll">
                                                 <div class="h5" style="color:brown">STOCK BRAND TYPE DETAILS</div>
                                                <asp:GridView ID="GvStockBrandTypeDetail" CssClass="table table-vcenter table-condensed table-bordered" ShowFooter="true"
                                                    runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GvStockBrandTypeDetail_PageIndexChanging" OnRowCommand="GvStockBrandTypeDetail_RowCommand"
                                                    PageSize="10">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>
                                                        <%--<asp:BoundField DataField="SRNO" HeaderText="SR NO." />--%>

                                                        <asp:TemplateField HeaderText="SR.NO.">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <%--  <asp:TemplateField HeaderText="SRNO">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="HfStockCode" runat="server" Value='<%#Bind("BRANDTYPE_CODE") %>' />
                                                 <asp:Label CssClass="label" ID="lblSrNo" runat="server" Text='<%#Bind("SRNO") %>'></asp:Label>
                                                          <asp:TextBox CssClass="form-control" ID="TxtSrNo" runat="server" Text='<%#Bind("SRNO") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>

                                                        <asp:TemplateField HeaderText="Work Decsription">
                                                            <ItemTemplate>

                                                                <%--  <asp:Label CssClass="label" ID="lblWorkDescrition" runat="server" Text='<%#Bind("DESC_NAME") %>'></asp:Label>--%>
                                                                <asp:TextBox CssClass="form-control" ID="TxtWorkDescrition" runat="server" Text='<%#Bind("DESC_NAME") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="OPTION-1">
                                                            <ItemTemplate>
                                                                <%--<asp:Label CssClass="label" ID="lblRESULT_1_1" runat="server" Text='<%#Bind("RESULT_1_1") %>'></asp:Label>--%>
                                                                <asp:TextBox CssClass="form-control" ID="TxtRESULT_1_1" runat="server" Text='<%#Bind("RESULT_1_1") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="OPTION-2">
                                                            <ItemTemplate>
                                                                <%--  <asp:Label CssClass="label" ID="lblRESULT_1_2" runat="server" Text='<%#Bind("RESULT_1_2") %>'></asp:Label>--%>
                                                                <asp:TextBox CssClass="form-control" ID="TxtRESULT_1_2" runat="server" Text='<%#Bind("RESULT_1_2") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRINT">
                                                            <ItemTemplate>
                                                                <%--    <asp:Label CssClass="label" ID="lblPRINT_FLAG_1" runat="server" Text='<%#Bind("PRINT_FLAG_1") %>'></asp:Label>--%>
                                                                <asp:DropDownList runat="server" ID="DdlPrintFlag1">
                                                                    <asp:ListItem Text="YES" Value="Y"></asp:ListItem>
                                                                    <asp:ListItem Text="NO" Value="N"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CHECKING-1">
                                                            <ItemTemplate>
                                                                <%--  <asp:Label CssClass="label" ID="lblRESULT_2_1" runat="server" Text='<%#Bind("RESULT_2_1") %>'></asp:Label>--%>
                                                                <asp:TextBox CssClass="form-control" ID="TxtRESULT_2_1" runat="server" Text='<%#Bind("RESULT_2_1") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CHECKING-2">
                                                            <ItemTemplate>
                                                                <%--  <asp:Label CssClass="label" ID="lblRESULT_2_2" runat="server" Text='<%#Bind("RESULT_2_2") %>'></asp:Label>--%>
                                                                <asp:TextBox CssClass="form-control" ID="TxtRESULT_2_2" runat="server" Text='<%#Bind("RESULT_2_2") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PRINT">
                                                            <ItemTemplate>
                                                                <%--  <asp:Label CssClass="label" ID="lblPRINT_FLAG_2" runat="server" Text='<%#Bind("PRINT_FLAG_2") %>'></asp:Label>--%>
                                                                <asp:DropDownList runat="server" ID="DdlPrintFlag2">
                                                                    <asp:ListItem Text="YES" Value="Y"></asp:ListItem>
                                                                    <asp:ListItem Text="NO" Value="N"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="REMARK-1">
                                                            <ItemTemplate>
                                                                <%--  <asp:Label CssClass="label" ID="lblRESULT_3_1" runat="server" Text='<%#Bind("RESULT_3_1") %>'></asp:Label>--%>
                                                                <asp:TextBox CssClass="form-control" ID="TxtRESULT_3_1" runat="server" Text='<%#Bind("RESULT_3_1") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="REMARK-2">
                                                            <ItemTemplate>
                                                                <%--<asp:Label CssClass="label" ID="lblRESULT_3_2" runat="server" Text='<%#Bind("RESULT_3_2") %>'></asp:Label>--%>
                                                                <asp:TextBox CssClass="form-control" ID="TxtRESULT_3_2" runat="server" Text='<%#Bind("RESULT_3_2") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRINT">
                                                            <ItemTemplate>
                                                                <%-- <asp:Label CssClass="label" ID="lblPRINT_FLAG_3" runat="server" Text='<%#Bind("PRINT_FLAG_3") %>'></asp:Label>--%>
                                                                <asp:DropDownList runat="server" ID="DdlPrintFlag3">
                                                                    <asp:ListItem Text="YES" Value="Y"></asp:ListItem>
                                                                    <asp:ListItem Text="NO" Value="N"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButtonDeleteRow" runat="server" OnClick="LinkButtonDeleteRow_Click" Text="Remove" Font-Underline="true">Remove</asp:LinkButton>
                                                            </ItemTemplate>

                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click" />
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>

                                                <%--<asp:Button ID="BtnAddRow" runat="server" Text="ADD ROW" CssClass="btn btn-lg btn-primary" OnClick="BtnAddRow_Click" />--%>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>


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


    <div id="DivView" runat="server" class="grids">

        <div class="panel panel-widget top-grids">
            <asp:Button ID="BtnAdd" runat="server" Text="NEW" CssClass="btn btn-lg btn-primary" OnClick="BtnAdd_Click" />
            <asp:Button ID="btnexit" runat="server" Text="Exit" OnClick="btnexit_Click" CssClass="btn btn-lg btn-primary" CausesValidation="false" />
        </div>
        <asp:HiddenField ID="HfBrandTypeCode" runat="server" />
        <asp:HiddenField ID="HfCompCode" runat="server" />
        <asp:HiddenField ID="HfSrNo" runat="server" />

        <div class="panel panel-widget top-grids">
            <div class="chute chute-center text-center">

              <div class="tabl-respeonsive" style="height: 500px; overflow-y: scroll">

                <div class="table-responsive">
                    <asp:GridView ID="GvStocktBrandTypeMaster" CssClass="table table-vcenter table-condensed table-bordered"
                        runat="server" AutoGenerateColumns="false" AllowPaging="false" OnPageIndexChanging="GvStocktBrandTypeMaster_PageIndexChanging" OnRowCommand="GvStocktBrandTypeMaster_RowCommand" 
                        OnRowDataBound="GvStocktBrandTypeMaster_RowDataBound"
                        PageSize="10">
                        <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                        <Columns>

                            <asp:TemplateField HeaderText="ACTION">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" CausesValidation="false" CommandName="Viewa" CommandArgument='<%#Bind("BRANDTYPE_CODE") %>' ToolTip="View" Text="VIEW" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>
                                    <asp:HiddenField ID="HfBrandTypeCode" runat="server" Value='<%#Bind("BRANDTYPE_CODE")%>' />

                                    <asp:Button ID="btnEdit" runat="server" Enabled='<%# Eval("REC_UPD").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Edita" CommandArgument='<%#Bind("BRANDTYPE_CODE") %>' ToolTip="Edit" Text="EDIT" CssClass="btn-primary  btn-sm" BorderStyle="None"></asp:Button>

                                    <asp:Button ID="btnDelete" runat="server" Enabled='<%# Eval("REC_DEL").ToString().Equals("Y") %>' CausesValidation="false" CommandName="Deletea" CommandArgument='<%#Bind("BRANDTYPE_CODE") %>' ToolTip="Delete" Text="DELETE" CssClass="btn-primary btn-sm" BorderStyle="None"></asp:Button>

                                    <a href="JavaScript:divexpandcollapse('div<%# Eval("BRANDTYPE_CODE") %>');">
                                        <img id='imgdiv<%# Eval("BRANDTYPE_CODE") %>' width="15px" border="0" src="/images/plus.gif" />
                                    </a>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="BRANDTYPE NAME">
                                <ItemTemplate>
                                    <asp:Label CssClass="label grdleftalign" ID="lblBrandTypeName" runat="server" Text='<%#Bind("BRANDTYPE_NAME") %>'></asp:Label>

                                    <tr>
                                        <td colspan="100%">
                                            <div id='div<%#Eval("BRANDTYPE_CODE") %>' class="table-responsive" style="display: none; background-color: lightgray">
                                              <div style="border:1px solid red; background:#00bcd4; color:white; padding:1px; border-radius:7px;">
                                                   <h4>STOCK BRAND TYPE DETAILS</h4>
                                               </div>

                                                <asp:GridView ID="GvNestedStockBrandTypeDetail" style="background:#e6ffee;" CssClass="table table-vcenter table-condensed table-bordered" ShowFooter="true"
                                                    runat="server" AutoGenerateColumns="false">
                                                    <PagerStyle CssClass="pagination pagination-sm remove-margin" />
                                                    <Columns>
                                                        <%--<asp:BoundField DataField="SRNO" HeaderText="SR NO." />--%>

                                                        <asp:TemplateField HeaderText="SR.NO.">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Work Decsription">
                                                            <ItemTemplate>

                                                                <%--  <asp:Label CssClass="label" ID="lblWorkDescrition" runat="server" Text='<%#Bind("DESC_NAME") %>'></asp:Label>--%>
                                                                <asp:TextBox CssClass="form-control" ID="TxtWorkDescrition" runat="server" Text='<%#Bind("DESC_NAME") %>' Enabled="false"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="OPTION-1">
                                                            <ItemTemplate>
                                                                <%--<asp:Label CssClass="label" ID="lblRESULT_1_1" runat="server" Text='<%#Bind("RESULT_1_1") %>'></asp:Label>--%>
                                                                <asp:TextBox CssClass="form-control" ID="TxtRESULT_1_1" runat="server" Text='<%#Bind("RESULT_1_1") %>' Enabled="false"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="OPTION-2">
                                                            <ItemTemplate>
                                                                <%--  <asp:Label CssClass="label" ID="lblRESULT_1_2" runat="server" Text='<%#Bind("RESULT_1_2") %>'></asp:Label>--%>
                                                                <asp:TextBox CssClass="form-control" ID="TxtRESULT_1_2" runat="server" Text='<%#Bind("RESULT_1_2") %>' Enabled="false"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRINT">
                                                            <ItemTemplate>
                                                                <%--    <asp:Label CssClass="label" ID="lblPRINT_FLAG_1" runat="server" Text='<%#Bind("PRINT_FLAG_1") %>'></asp:Label>--%>
                                                                <asp:DropDownList runat="server" ID="DdlPrintFlag1" Enabled="false">
                                                                    <asp:ListItem Text="YES" Value="Y"></asp:ListItem>
                                                                    <asp:ListItem Text="NO" Value="N"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CHECKING-1">
                                                            <ItemTemplate>
                                                                <%--  <asp:Label CssClass="label" ID="lblRESULT_2_1" runat="server" Text='<%#Bind("RESULT_2_1") %>'></asp:Label>--%>
                                                                <asp:TextBox CssClass="form-control" ID="TxtRESULT_2_1" runat="server" Text='<%#Bind("RESULT_2_1") %>' Enabled="false"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CHECKING-2">
                                                            <ItemTemplate>
                                                                <%--  <asp:Label CssClass="label" ID="lblRESULT_2_2" runat="server" Text='<%#Bind("RESULT_2_2") %>'></asp:Label>--%>
                                                                <asp:TextBox CssClass="form-control" ID="TxtRESULT_2_2" runat="server" Text='<%#Bind("RESULT_2_2") %>' Enabled="false"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PRINT">
                                                            <ItemTemplate>
                                                                <%--  <asp:Label CssClass="label" ID="lblPRINT_FLAG_2" runat="server" Text='<%#Bind("PRINT_FLAG_2") %>'></asp:Label>--%>
                                                                <asp:DropDownList runat="server" ID="DdlPrintFlag2" Enabled="false">
                                                                    <asp:ListItem Text="YES" Value="Y"></asp:ListItem>
                                                                    <asp:ListItem Text="NO" Value="N"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="REMARK-1">
                                                            <ItemTemplate>
                                                                <%--  <asp:Label CssClass="label" ID="lblRESULT_3_1" runat="server" Text='<%#Bind("RESULT_3_1") %>'></asp:Label>--%>
                                                                <asp:TextBox CssClass="form-control" ID="TxtRESULT_3_1" runat="server" Text='<%#Bind("RESULT_3_1") %>' Enabled="false"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="REMARK-2">
                                                            <ItemTemplate>
                                                                <%--<asp:Label CssClass="label" ID="lblRESULT_3_2" runat="server" Text='<%#Bind("RESULT_3_2") %>'></asp:Label>--%>
                                                                <asp:TextBox CssClass="form-control" ID="TxtRESULT_3_2" runat="server" Text='<%#Bind("RESULT_3_2") %>' Enabled="false"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PRINT">
                                                            <ItemTemplate>
                                                                <%-- <asp:Label CssClass="label" ID="lblPRINT_FLAG_3" runat="server" Text='<%#Bind("PRINT_FLAG_3") %>'></asp:Label>--%>
                                                                <asp:DropDownList runat="server" ID="DdlPrintFlag3" Enabled="false">
                                                                    <asp:ListItem Text="YES" Value="Y"></asp:ListItem>
                                                                    <asp:ListItem Text="NO" Value="N"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
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

                    <h4 class="modal-title">DELETE STOCK PRICE MASTER DETAIL</h4>
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
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">UPDATE STOCK PRICE MASTER DETAIL</h4>
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
