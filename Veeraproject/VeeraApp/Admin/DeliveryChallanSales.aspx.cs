using MihirValid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;

namespace VeeraApp
{
    public partial class DeliveryChallanSales : System.Web.UI.Page
    {
        public static string compcode;
        static DataTable DtSearch = new DataTable();
        public static string Branchcode;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["USERCODE"] != null &&
               Session["USERNAME"] != null &&
               Session["USERTYPE"] != null &&
               Session["COMP_CODE"] != null &&
               Session["COMP_NAME"] != null &&
                Session["WORK_VIEWFLAG"] != null &&
               Session["BRANCH_CODE"] != null &&
               Session["BRANCH_NAME"] != null &&
               Session["BRANCH_TYPE"] != null &&
               Session["FIN_YEAR"] != null &&
               Session["FIN_YEAR_END"] != null &&
               Session["MAC"] != null &&
               Session["PC"] != null &&
               Session["INSERT"] != null &&
               Session["UPDATE"] != null &&
               Session["DELETE"] != null)
            {
                compcode = Session["COMP_CODE"].ToString();
                Branchcode = Session["BRANCH_CODE"].ToString();
                if (!IsPostBack == true)
                {
                    DivEntry.Visible = false;
                    DivView.Visible = true;
                    SetInitialRow();
                    SetInitialRowEx();
                    FillDdlPersonName();
                    CalendarExtenderChallanDate.StartDate = Convert.ToDateTime(Session["FIN_YEAR"].ToString());
                    CalendarExtenderChallanDate.EndDate = Convert.ToDateTime(Session["FIN_YEAR_END"].ToString());

                    if (!string.IsNullOrWhiteSpace(Request.QueryString["TRN_TYPE"]) && !string.IsNullOrWhiteSpace(Request.QueryString["TRAN_TYPE"]))
                    {
                        HfTranType.Value = Request.QueryString["TRAN_TYPE"];
                        HfTrnType.Value = Request.QueryString["TRN_TYPE"];
                    }

                    FillDC_MasterGrid(Session["COMP_CODE"].ToString());


                }
            }

            else
            {
                Response.Redirect("../Login.aspx");
            }
        }






        private double TotalReceiveQty()
        {
            double GTotal = 0;
            for (int i = 0; i < GvDCDetails.Rows.Count; i++)
            {
                string total = (GvDCDetails.Rows[i].FindControl("TxtRecQty") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);

            }
            return GTotal;

        }

        private double TotalExtraReceiveQty()
        {
            double GTotal = 0;
            for (int i = 0; i < GvDCDetailsExStock.Rows.Count; i++)
            {
                string total = (GvDCDetailsExStock.Rows[i].FindControl("TxtRecQty") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);

            }
            return GTotal;

        }

        public void FillDC_MasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = DC_MASLogicLayer.GetAllDC_SALES_MASDetails(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()), HfTranType.Value.ToString(), HfTrnType.Value.ToString());
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }

            if (TxtSearch.Text != string.Empty)
            {
                Dv.RowFilter = "AccountName like '%" + TxtSearch.Text.Trim() + "%' OR Convert(CHA_NO, 'System.String') like '%" + TxtSearch.Text.Trim() + "%' OR PersonName Like '" + TxtSearch.Text.Trim() + "' ";
            }

            GvDCSalesMaster.DataSource = Dv.ToTable();
            GvDCSalesMaster.DataBind();

            DtSearch = Dv.ToTable();

        }


        public void UserRights()
        {
            try
            {
                //   btnDelete.Visible = false;
                if (Session["INSERT"] != null)
                {
                    if (Session["INSERT"].ToString() == "Y")
                    {
                        BtnAdd.Visible = true;
                    }
                    else
                    {
                        BtnAdd.Visible = false;
                    }
                }


                if (Session["UPDATE"] != null)
                {
                    if (Session["UPDATE"].ToString() == "Y")
                    {
                        // btnSave.Enabled = true;
                    }
                    else
                    {
                        // btnSave.Enabled = false;
                    }
                }


                if (Session["DELETE"] != null)
                {
                    if (Session["DELETE"].ToString() == "Y")
                    {
                        //  btnDelete.Enabled = true;
                    }
                    else
                    {
                        // btnDelete.Enabled = false;
                    }
                }

            }
            catch (Exception)
            {
            }
        }

        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            ViewState["BarcodeTemp"] = null;
            ViewState["BarcodeTempNew"] = null;
            ViewState["CurrentTable"] = null;

            HfACODE.Value = string.Empty;
            HfCompCode.Value = string.Empty;
            HfBranchCode.Value = string.Empty;

            lblbarduperror.Text = string.Empty;
            TxtChallanNo.Text = string.Empty;
            TxtChallanDate.Text = string.Empty;
            TxtAccountName.Text = string.Empty;
            TxtGSTNo.Text = string.Empty;
            TxtPartyModelSrNo.Text = string.Empty;
            TxtPartySrNo.Text = string.Empty;
            TxtMfgSrNo.Text = string.Empty;
            TxtBrandName.Text = string.Empty;
            TxtBrandTypeName.Text = string.Empty;
            TxtModelName.Text = string.Empty;
            TxtPODate.Text = string.Empty;
            TxtPONumber.Text = string.Empty;
            TxtTransportName.Text = string.Empty;
            TxtVehclieNo.Text = string.Empty;
            TxtDriverAddress.Text = string.Empty;
            TxtDriverName.Text = string.Empty;
            TxtMDLNo.Text = string.Empty;
            TxtMDLState.Text = string.Empty;
            TxtLRDate.Text = string.Empty;
            TxtLRNumber.Text = string.Empty;
            DdlDeliveredBy.SelectedIndex = 0;
            DdlConfirm.SelectedValue = "N";
            TxtConfirmBy.Text = string.Empty;
            TxtConfirmDate.Text = string.Empty;
            TxtRemark.Text = string.Empty;
            DdlPartyType.SelectedIndex = 0;
            DdlSalesType.SelectedIndex = 0;
            TxtCheckPost.Text = string.Empty;
            TxtFormSrNo.Text = string.Empty;
            TxtInvoiceNo.Text = string.Empty;
            TxtInvoiceDate.Text = string.Empty;
            DdlChallanType.SelectedIndex = 0;


            SetInitialRow();
            SetInitialRowEx();
            BtncallUpd.Text = "SAVE";
        }


        public void ControllerEnable()
        {
            TxtChallanNo.Enabled = true;
            TxtChallanDate.Enabled = true;
            TxtAccountName.Enabled = true;
            TxtGSTNo.Enabled = true;
            TxtPartyModelSrNo.Enabled = true;
            TxtPartySrNo.Enabled = false;
            TxtMfgSrNo.Enabled = false;
            TxtBrandName.Enabled = false;
            TxtBrandTypeName.Enabled = false;
            TxtModelName.Enabled = false;
            TxtPODate.Enabled = true;
            TxtPONumber.Enabled = true;
            TxtTransportName.Enabled = true;
            TxtVehclieNo.Enabled = true;
            TxtDriverAddress.Enabled = true;
            TxtDriverName.Enabled = true;
            TxtMDLNo.Enabled = true;
            TxtMDLState.Enabled = true;
            TxtLRDate.Enabled = true;
            TxtLRNumber.Enabled = true;
            DdlDeliveredBy.Enabled = true;
            DdlConfirm.Enabled = true;
            TxtConfirmBy.Enabled = true;
            TxtConfirmDate.Enabled = true;
            TxtRemark.Enabled = true;
            DdlPartyType.Enabled = true;
            DdlSalesType.Enabled = true;
            TxtCheckPost.Enabled = true;
            TxtFormSrNo.Enabled = true;
            TxtInvoiceNo.Enabled = false;
            TxtInvoiceDate.Enabled = false;
            DdlChallanType.Enabled = true;
        }

        public void ControllerDisable()
        {
            TxtChallanNo.Enabled = false;
            TxtChallanDate.Enabled = false;
            TxtAccountName.Enabled = false;
            TxtGSTNo.Enabled = false;
            TxtPartyModelSrNo.Enabled = false;
            TxtPartySrNo.Enabled = false;
            TxtMfgSrNo.Enabled = false;
            TxtBrandName.Enabled = false;
            TxtBrandTypeName.Enabled = false;
            TxtModelName.Enabled = false;
            TxtPODate.Enabled = false;
            TxtPONumber.Enabled = false;
            TxtTransportName.Enabled = false;
            TxtVehclieNo.Enabled = false;
            TxtDriverAddress.Enabled = false;
            TxtDriverName.Enabled = false;
            TxtMDLNo.Enabled = false;
            TxtMDLState.Enabled = false;
            TxtLRDate.Enabled = false;
            TxtLRNumber.Enabled = false;
            DdlDeliveredBy.Enabled = false;
            DdlConfirm.Enabled = false;
            TxtConfirmBy.Enabled = false;
            TxtConfirmDate.Enabled = false;
            TxtRemark.Enabled = false;
            DdlPartyType.Enabled = false;
            DdlSalesType.Enabled = false;
            TxtCheckPost.Enabled = false;
            TxtFormSrNo.Enabled = false;
            TxtInvoiceNo.Enabled = false;
            TxtInvoiceDate.Enabled = false;
            DdlChallanType.Enabled = false;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetAccountName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from ACCOUNTS where COMP_CODE=@COMP_CODE AND BRANCH_CODE=@BRANCH_CODE AND ANAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            cmd.Parameters.AddWithValue("@BRANCH_CODE", Branchcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> ANames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ANames.Add(dt.Rows[i][2].ToString());
            }
            return ANames;
        }

        protected void TxtAccountName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select ACODE from ACCOUNTS where ANAME = '" + TxtAccountName.Text + "' and COMP_CODE = " + Session["COMP_CODE"].ToString(), con);
                int x = Convert.ToInt32(cmd.ExecuteScalar());
                if (x == 0)
                {
                    TxtAccountName.BackColor = Color.Red;
                }
                else
                {
                    HfACODE.Value = cmd.ExecuteScalar().ToString();
                    TxtAccountName.BackColor = Color.White; con.Close();

                    FillDdlAccountPartyType();
                    FillDdlAccountSalesType();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlAccountNameOnUpdate(string Id)
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(Comp_Code);


                if (HfACODE.Value.ToString() != "0")
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "ACODE=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtAccountName.Text = DtView.Rows[0]["ANAME"].ToString();
                    HfACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                    TxtGSTNo.Text = DtView.Rows[0]["GST_NO"].ToString();


                }



            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlPartModelySrNoOnUpdate(string Id)
        {
            try
            {
                string PartySRNO = HfPartRefSrNo.Value;

                DataTable Dt = new DataTable();
                Dt = PARTY_MODELMASLogicLayer.GetAllIDWisePARTY_MODELMASDetailForDC(PartySRNO);


                if (HfPartRefSrNo.Value.ToString() != "0")
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "SRNO=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtPartyModelSrNo.Text = DtView.Rows[0]["MODEL_SRNO"].ToString();
                    TxtPartySrNo.Text = DtView.Rows[0]["PARTY_SRNO"].ToString();
                    TxtMfgSrNo.Text = DtView.Rows[0]["MFG_SRNO"].ToString();
                    TxtBrandName.Text = DtView.Rows[0]["BRAND_NAME"].ToString();
                    TxtBrandTypeName.Text = DtView.Rows[0]["BRANDTYPE_NAME"].ToString();
                    TxtModelName.Text = DtView.Rows[0]["MODEL_NAME"].ToString();



                }



            }
            catch (Exception)
            {

                throw;
            }
        }



        public void FillDdlAccountPartyType()
        {
            try
            {
                string ACODE = HfACODE.Value;
                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(ACODE);
                if (Dt.Rows.Count > 0)
                {
                    DdlPartyType.SelectedValue = Dt.Rows[0]["PARTY_TYPE_String"].ToString().ToUpper();
                }
                else
                {
                    DdlPartyType.SelectedValue = "0";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlAccountSalesType()
        {
            try
            {
                string ACODE = HfACODE.Value;
                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(ACODE);
                if (Dt.Rows.Count > 0)
                {
                    DdlSalesType.SelectedValue = Dt.Rows[0]["SALES_TYPE"].ToString();
                }
                else
                {
                    DdlSalesType.SelectedValue = "0";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetTransporterName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from TRANSPORT_MAS where TNAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> TNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TNames.Add(dt.Rows[i][1].ToString());
            }
            return TNames;
        }

        public void FillDdlPersonName()
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKER_MASDetialsCompanyWiseFor_DDL(Comp_Code);
                DdlDeliveredBy.DataSource = Dt;
                DdlDeliveredBy.DataValueField = "BCODE";
                DdlDeliveredBy.DataTextField = "BNAME";
                DdlDeliveredBy.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlConfirm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlConfirm.SelectedValue == "Y")
            {
                TxtConfirmBy.Text = Session["USERNAME"].ToString();
                TxtConfirmDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            }
            else
            {
                TxtConfirmBy.Text = "";
                TxtConfirmDate.Text = "";
            }
        }



        protected void BtnPartyModelDetails_Click(object sender, EventArgs e)
        {
            try
            {
                string COMP_CODE = Session["COMP_CODE"].ToString();
                string ACODE = HfACODE.Value;

                if (HfACODE.Value == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SelectionAlert", "SelectionAlert()", true);
                }
                else
                {
                    Response.Write("<script>window.open ('PartyModelMaster.aspx?ACODE=" + ACODE + "&COMP_CODE=" + COMP_CODE + "', '_blank');</script>");
                    //  Server.Transfer("PartyModelMaster.aspx?ACODE=" + ACODE + "&COMP_CODE=" + COMP_CODE,false);
                }


            }

            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnDriverDetails_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelDriverDetails", "ShowModelDriverDetails()", true);
        }


        #region Get Customer Button For PopUp


        protected void BtnGetCustomerDet_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelCustomerDetail", "ShowModelCustomerDetail()", true);
            FillCustomerGridForPopup();
        }

        public void FillCustomerGridForPopup()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = ACCOUNTS_MASLogicLayer.GetAllGroupCodeWise_PartyDetailsForGrid(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), "24");
                GvCustomerDetails.DataSource = Dt;
                GvCustomerDetails.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvCustomerDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvCustomerDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Selecta")
                {

                    // clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfCompCodeCust = (row.FindControl("HfCompCodeCust")) as HiddenField;
                        HiddenField HfBranchCodeCust = (row.FindControl("HfBranchCodeCust")) as HiddenField;

                        DataTable dt = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(e.CommandArgument.ToString());

                        TxtAccountName.Text = dt.Rows[0]["ANAME"].ToString();
                        HfACODE.Value = dt.Rows[0]["ACODE"].ToString();
                        TxtGSTNo.Text = dt.Rows[0]["GST_NO"].ToString();
                    }
                }

                FillDdlAccountPartyType();
                FillDdlAccountSalesType();

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModelCustomerDetail", "HideModelCustomerDetail()", true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Get Party Model Popup



        protected void BtnGetPartyModelSrNo_Click(object sender, EventArgs e)
        {
            try
            {
                if (HfACODE.Value == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SelectionAlert", "SelectionAlert()", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelPartyModelSrNo", "ShowModelPartyModelSrNo()", true);

                    FillPartyModelSrNo();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillPartyModelSrNo()
        {
            try
            {
                string ACODE = HfACODE.Value;

                DataTable Dt = new DataTable();
                Dt = PARTY_MODELMASLogicLayer.GetAllPARTY_MODELMASDetailWisePartyNameForGrid(ACODE);

                GvPartyModelSrNo.DataSource = Dt;
                GvPartyModelSrNo.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvPartyModelSrNo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvPartyModelSrNo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Selecta")
                {

                    // clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfCompCodeModel = (row.FindControl("HfCompCodeModel")) as HiddenField;
                        HiddenField HfBranchCodeModel = (row.FindControl("HfBranchCodeModel")) as HiddenField;

                        DataTable Dt = PARTY_MODELMASLogicLayer.GetAllIDWisePARTY_MODELMASDetailForDC(e.CommandArgument.ToString());

                        HfPartRefSrNo.Value = Dt.Rows[0]["SRNO"].ToString();
                        TxtPartyModelSrNo.Text = Dt.Rows[0]["MODEL_SRNO"].ToString();
                        TxtPartySrNo.Text = Dt.Rows[0]["PARTY_SRNO"].ToString();
                        TxtMfgSrNo.Text = Dt.Rows[0]["MFG_SRNO"].ToString();
                        TxtBrandName.Text = Dt.Rows[0]["BRAND_NAME"].ToString();
                        TxtModelName.Text = Dt.Rows[0]["MODEL_NAME"].ToString();
                        TxtBrandTypeName.Text = Dt.Rows[0]["BRANDTYPE_NAME"].ToString();
                    }
                }

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModelPartyModelSrNo", "HideModelPartyModelSrNo()", true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion


        protected void BtnViewBarcode_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelViewBarcode", "ShowModelViewBarcode()", true);
            FillOnlyViewBarcodePopup();

            Button AddNewBracodeBtn = (Button)(GvViewBarcode.FooterRow.FindControl("BtnAddRowModelBarCode_ViewGrid"));

            btnAddBarcodeProcess.Visible = false;
            btnUploadBarcodeProcess.Visible = false;
            btnReturnBarcodeProcess.Visible = false;
            FileUpload1.Visible = false;
            AddNewBracodeBtn.Visible = false;
            DivBarcodeInput.Visible = false;



        }

        protected void BtnAddBarcode_Click(object sender, EventArgs e)
        {
            ViewState["BarcodeTempNew"] = null;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelViewBarcode", "ShowModelViewBarcode()", true);
            FillViewBarcodePopup(1);
            foreach (GridViewRow row in GvViewBarcode.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                    TxtBarcode.Focus();
                }
            }
            btnAddBarcodeProcess.Visible = true;
            btnUploadBarcodeProcess.Visible = true;
            btnReturnBarcodeProcess.Visible = false;
            FileUpload1.Visible = true;
            DivBarcodeInput.Visible = true;

        }

        protected void BtnReturnBarcode_Click(object sender, EventArgs e)
        {
            ViewState["BarcodeTempNew"] = null;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelViewBarcode", "ShowModelViewBarcode()", true);
            FillViewBarcodePopup(2);

            btnAddBarcodeProcess.Visible = false;
            btnUploadBarcodeProcess.Visible = false;
            btnReturnBarcodeProcess.Visible = true;
            FileUpload1.Visible = false;
            DivBarcodeInput.Visible = true;

        }


        #region BARCODE PROCESS IN GRID      

        protected void TxtBarcodeInputNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtBarcodeInputNo.Text.Trim() != string.Empty && validation.isNumberWithoutComa(TxtBarcodeInputNo.Text.Trim()))
                {
                    DataTable dtCurrentTableBlankFilter = new DataTable();
                    DataTable dtCurrentTable = new DataTable();
                    DataRow dr = null;
                    if (ViewState["BarcodeTempNew"] != null)
                    {
                        dtCurrentTableBlankFilter = (DataTable)ViewState["BarcodeTempNew"];

                        DataView dvBlankFilter = new DataView(dtCurrentTableBlankFilter);
                        dvBlankFilter.RowFilter = "BARRCODE<>''";
                        dtCurrentTable = dvBlankFilter.ToTable();



                        //NEW BLOCK FOR ADD SECOND ROW ISSUE  ON 13-09-2019
                        foreach (GridViewRow row in GvViewBarcode.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {
                                TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                                TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                                HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                                HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                                HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;

                                if (TxtBarcode.Text.Trim() != string.Empty)
                                {
                                    DataView dv = new DataView(dtCurrentTable);
                                    dv.RowFilter = "BARRCODE='" + TxtBarcode.Text.Trim() + "'";
                                    DataTable dtCurrentTableFilter = new DataTable();
                                    dtCurrentTableFilter = dv.ToTable();
                                    if (dtCurrentTableFilter.Rows.Count <= 0)
                                    {
                                        dr = dtCurrentTable.NewRow();
                                        //dr = dtCurrentTable.Rows[dtCurrentTable.Rows.Count - 1];

                                        dr["BARRCODE"] = TxtBarcode.Text.Trim();
                                        dr["QTY"] = TxtQty.Text.Trim();
                                        dr["SCODE"] = "";
                                        dr["BAR_TRAN_DATE"] = HfBarTranDate.Value;
                                        dr["BAR_TRAN_NO"] = HfBarTranNo.Value;
                                        dr["BAR_SRNO"] = HfBarSrNo.Value;
                                        dtCurrentTable.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                        //*****//
                    }
                    else
                    {
                        dtCurrentTable.Columns.Add("BARRCODE", typeof(System.String));
                        dtCurrentTable.Columns.Add("QTY", typeof(System.String));
                        dtCurrentTable.Columns.Add("SCODE", typeof(System.String));
                        dtCurrentTable.Columns.Add("BAR_TRAN_DATE", typeof(System.String));
                        dtCurrentTable.Columns.Add("BAR_TRAN_NO", typeof(System.String));
                        dtCurrentTable.Columns.Add("BAR_SRNO", typeof(System.String));

                        foreach (GridViewRow row in GvViewBarcode.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {
                                TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                                TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                                HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                                HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                                HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;

                                if (TxtBarcode.Text.Trim() != string.Empty)
                                {
                                    dr = dtCurrentTable.NewRow();

                                    dr["BARRCODE"] = TxtBarcode.Text.Trim();
                                    dr["QTY"] = TxtQty.Text.Trim();
                                    dr["SCODE"] = "";
                                    dr["BAR_TRAN_DATE"] = HfBarTranDate.Value;
                                    dr["BAR_TRAN_NO"] = HfBarTranNo.Value;
                                    dr["BAR_SRNO"] = HfBarSrNo.Value;
                                    dtCurrentTable.Rows.Add(dr);
                                }
                            }
                        }
                    }



                    for (int j = 0; j < Convert.ToInt32(TxtBarcodeInputNo.Text.Trim()); j++)
                    {
                        dr = dtCurrentTable.NewRow();

                        dr["BARRCODE"] = "";
                        dr["QTY"] = "";
                        dr["SCODE"] = "";
                        dr["BAR_TRAN_DATE"] = "";
                        dr["BAR_TRAN_NO"] = "";
                        dr["BAR_SRNO"] = "";

                        dtCurrentTable.Rows.Add(dr);
                    }
                    ViewState["BarcodeTempNew"] = dtCurrentTable;

                    GvViewBarcode.DataSource = dtCurrentTable;
                    GvViewBarcode.DataBind();
                    TxtBarcodeInputNo.Text = string.Empty;
                }
                else
                {
                    //alert
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('invalid number')", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void TxtBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {


                List<string> list = new List<string>();
                foreach (GridViewRow row in GvViewBarcode.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                        HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                        HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                        HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;
                        Label lblmsg = row.FindControl("lblmsg") as Label;

                        if (TxtBarcode.Text == "")
                        {

                        }
                        else
                        {
                            list.Add(TxtBarcode.Text);
                        }
                    }
                }

                string[] name = list.ToArray();

                HasDuplicates(name);
                if (dupbarcode == "")
                {
                    //DataTable DtBarcodeTemp = new DataTable();
                    //if (ViewState["BarcodeTemp"] != null)
                    //{
                    //    DtBarcodeTemp = (DataTable)ViewState["BarcodeTemp"];
                    //}
                    //else
                    //{
                    //    DtBarcodeTemp.Columns.Add("BARRCODE", typeof(string));
                    //    DtBarcodeTemp.Columns.Add("QTY", typeof(string));
                    //    DtBarcodeTemp.Columns.Add("SCODE", typeof(string));
                    //    DtBarcodeTemp.Columns.Add("BAR_TRAN_DATE", typeof(string));
                    //    DtBarcodeTemp.Columns.Add("BAR_TRAN_NO", typeof(string));
                    //    DtBarcodeTemp.Columns.Add("BAR_SRNO", typeof(string));
                    //}


                    //foreach (GridViewRow row in GvViewBarcode.Rows)
                    //{
                    //    if (row.RowType == DataControlRowType.DataRow)
                    //    {

                    TextBox txt = (TextBox)sender;
                    GridViewRow rowinner = (GridViewRow)txt.Parent.Parent;
                    int idx = rowinner.RowIndex;

                    TextBox TxtBarcodeinner = (TextBox)rowinner.Cells[1].FindControl("TxtBarcode");
                    TextBox TxtQtyinner = (TextBox)rowinner.Cells[2].FindControl("TxtQty");
                    Label lblmsg = (Label)rowinner.Cells[3].FindControl("lblmsg");

                    //TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                    //        TextBox TxtQty = row.FindControl("TxtQty") as TextBox;


                    DataTable DtBarcode = new DataTable();
                    DtBarcode = BARCODE_MASLogicLayer.GetBarcodeDetail_WiseBarcodeNo(TxtBarcodeinner.Text.Trim());
                    DataView Dv = new DataView(DtBarcode);
                    Dv.RowFilter = "STATUSFlag='O'";
                    DataTable FilterBarcode = Dv.ToTable();


                    //DataView DvBarcodeTemptable = new DataView(DtBarcodeTemp);
                    //DvBarcodeTemptable.RowFilter = "BARRCODE='" + TxtBarcode.Text.Trim() + "'";
                    //DataTable DtBarcodeTempFiltertable = DvBarcodeTemptable.ToTable();

                    //if (DtBarcodeTempFiltertable.Rows.Count <= 0)
                    //{
                    if (FilterBarcode.Rows.Count > 0)
                    {

                        TxtQtyinner.Text = "1";
                        TxtBarcodeinner.ForeColor = Color.Black;
                        lblmsg.Text = string.Empty;
                        TextBox nexTextbox = GvViewBarcode.Rows[name.Length].Cells[1].FindControl("TxtBarcode") as TextBox;

                        //nexTextbox.Text = "jigar";
                        //nexTextbox.Focus();
                    }
                    else
                    {
                        //alert
                        //  lblbarduperror.Text = "Barcode is not available..! " ;
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Barcode is not available..!!');", true);
                        TxtBarcodeinner.ForeColor = Color.Red;
                        TxtBarcodeinner.Focus();
                    }
                    int index = ((TextBox)sender).TabIndex;
                    TextBox TxtBarcodeMove = (TextBox)GvViewBarcode.Rows[index + 1].FindControl("TxtBarcode");
                    TxtBarcodeMove.Focus();
                    //TxtBarcodeMove.BackColor = Color.Gray;

                    //}
                    //else
                    //{
                    //    TxtBarcode.ForeColor = Color.Red;


                    //}

                    //    }
                    //}
                    //GvViewBarcode.DataSource = DtBarcodeTemp;
                    //GvViewBarcode.DataBind();
                    lblbarduperror.Text = string.Empty;
                    //GvViewBarcode.Rows[idx].FindControl("TxtBarcode").Focus();
                }
                else
                {
                    //lblbarduperror.Text = "Duplicate Barcode Found! Details:- " + dupbarcode.TrimEnd(',');
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Duplicate Barcode Found!Details:-" + dupbarcode.TrimEnd(',') + "');", true);
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillOnlyViewBarcodePopup()
        {
            try
            {
                DataTable dt = new DataTable();
                if (ViewState["BarcodeTemp"] != null)
                {
                    dt = (DataTable)ViewState["BarcodeTemp"];
                }
                else
                {

                    dt.Columns.Add("BARRCODE", typeof(System.String));
                    dt.Columns.Add("QTY", typeof(System.String));
                    dt.Columns.Add("SCODE", typeof(System.String));
                    dt.Columns.Add("BAR_TRAN_DATE", typeof(System.String));
                    dt.Columns.Add("BAR_TRAN_NO", typeof(System.String));
                    dt.Columns.Add("BAR_SRNO", typeof(System.String));

                    for (int i = 0; i < 50; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["BARRCODE"] = "";
                        dr["QTY"] = "";
                        dr["SCODE"] = "";
                        dr["BAR_TRAN_DATE"] = "";
                        dr["BAR_TRAN_NO"] = "";
                        dr["BAR_SRNO"] = "";
                        dt.Rows.Add(dr);
                    }
                }

                GvViewBarcode.DataSource = dt;
                GvViewBarcode.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillViewBarcodePopup(int C)
        {
            try
            {
                DataTable dt = new DataTable();


                dt.Columns.Add("BARRCODE", typeof(System.String));
                dt.Columns.Add("QTY", typeof(System.String));
                dt.Columns.Add("SCODE", typeof(System.String));
                dt.Columns.Add("BAR_TRAN_DATE", typeof(System.String));
                dt.Columns.Add("BAR_TRAN_NO", typeof(System.String));
                dt.Columns.Add("BAR_SRNO", typeof(System.String));


                for (int i = 0; i < 50; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["BARRCODE"] = "";
                    dr["QTY"] = "";
                    dr["SCODE"] = "";
                    dr["BAR_TRAN_DATE"] = "";
                    dr["BAR_TRAN_NO"] = "";
                    dr["BAR_SRNO"] = "";

                    dt.Rows.Add(dr);
                }
                if (C == 1)
                {
                    //ViewState["BarcodeTemp"] = dt;
                }
                GvViewBarcode.DataSource = dt;
                GvViewBarcode.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void BtnAddRowModelBarCode_ViewGrid_Click(object sender, EventArgs e)
        {

            AddNewRowBarcodeView();
        }


        protected void AddNewRowBarcodeView()
        {
            try
            {

                //if (ViewState["BarcodeTemp"] != null)
                //{
                //    DataTable dtCurrentTable = (DataTable)ViewState["BarcodeTemp"];
                //    DataRow dr = null;
                //    if (dtCurrentTable.Rows.Count > 0)
                //    {
                //        dr = dtCurrentTable.NewRow();

                //        dr["BARRCODE"] = "";
                //        dr["QTY"] = "";
                //        dr["SCODE"] = "";
                //        dr["BAR_TRAN_DATE"] = "";
                //        dr["BAR_TRAN_NO"] = "";
                //        dr["BAR_SRNO"] = "";




                //        dtCurrentTable.Rows.Add(dr);
                //        ViewState["BarcodeTemp"] = dtCurrentTable;

                //        GvViewBarcode.DataSource = dtCurrentTable;
                //        GvViewBarcode.DataBind();
                //    }
                //}
                //else
                //{
                DataTable dtCurrentTableBlankFilter = new DataTable();
                DataTable dtCurrentTable = new DataTable();
                DataRow dr = null;
                if (ViewState["BarcodeTempNew"] != null)
                {
                    dtCurrentTableBlankFilter = (DataTable)ViewState["BarcodeTempNew"];

                    DataView dvBlankFilter = new DataView(dtCurrentTableBlankFilter);
                    dvBlankFilter.RowFilter = "BARRCODE<>''";
                    dtCurrentTable = dvBlankFilter.ToTable();

                    //dtCurrentTable = (DataTable)ViewState["BarcodeTempNew"];

                    //NEW BLOCK FOR ADD SECOND ROW ISSUE  ON 13-09-2019
                    foreach (GridViewRow row in GvViewBarcode.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                            HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                            HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;

                            if (TxtBarcode.Text.Trim() != string.Empty)
                            {
                                DataView dv = new DataView(dtCurrentTable);
                                dv.RowFilter = "BARRCODE='" + TxtBarcode.Text.Trim() + "'";
                                DataTable dtCurrentTableFilter = new DataTable();
                                dtCurrentTableFilter = dv.ToTable();
                                if (dtCurrentTableFilter.Rows.Count <= 0)
                                {
                                    dr = dtCurrentTable.NewRow();
                                    //dr = dtCurrentTable.Rows[dtCurrentTable.Rows.Count - 1];

                                    dr["BARRCODE"] = TxtBarcode.Text.Trim();
                                    dr["QTY"] = TxtQty.Text.Trim();
                                    dr["SCODE"] = "";
                                    dr["BAR_TRAN_DATE"] = HfBarTranDate.Value;
                                    dr["BAR_TRAN_NO"] = HfBarTranNo.Value;
                                    dr["BAR_SRNO"] = HfBarSrNo.Value;
                                    dtCurrentTable.Rows.Add(dr);
                                }
                            }
                        }
                    }
                    //*****//
                }
                else
                {
                    dtCurrentTable.Columns.Add("BARRCODE", typeof(System.String));
                    dtCurrentTable.Columns.Add("QTY", typeof(System.String));
                    dtCurrentTable.Columns.Add("SCODE", typeof(System.String));
                    dtCurrentTable.Columns.Add("BAR_TRAN_DATE", typeof(System.String));
                    dtCurrentTable.Columns.Add("BAR_TRAN_NO", typeof(System.String));
                    dtCurrentTable.Columns.Add("BAR_SRNO", typeof(System.String));

                    foreach (GridViewRow row in GvViewBarcode.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                            HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                            HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;

                            if (TxtBarcode.Text.Trim() != string.Empty)
                            {
                                dr = dtCurrentTable.NewRow();

                                dr["BARRCODE"] = TxtBarcode.Text.Trim();
                                dr["QTY"] = TxtQty.Text.Trim();
                                dr["SCODE"] = "";
                                dr["BAR_TRAN_DATE"] = HfBarTranDate.Value;
                                dr["BAR_TRAN_NO"] = HfBarTranNo.Value;
                                dr["BAR_SRNO"] = HfBarSrNo.Value;
                                dtCurrentTable.Rows.Add(dr);
                            }
                        }
                    }
                }





                dr = dtCurrentTable.NewRow();

                dr["BARRCODE"] = "";
                dr["QTY"] = "";
                dr["SCODE"] = "";
                dr["BAR_TRAN_DATE"] = "";
                dr["BAR_TRAN_NO"] = "";
                dr["BAR_SRNO"] = "";

                dtCurrentTable.Rows.Add(dr);

                ViewState["BarcodeTempNew"] = dtCurrentTable;

                GvViewBarcode.DataSource = dtCurrentTable;
                GvViewBarcode.DataBind();


                //}
            }
            catch (Exception)
            {

                throw;
            }
        }




        public bool CheckforDuplicates(string[] array)
        {
            var duplicates = array
             .GroupBy(p => p)
             .Where(g => g.Count() > 1)
             .Select(g => g.Key);
            return (duplicates.Count() > 0);
        }
        public string dupbarcode = "";
        private void HasDuplicates(string[] arrayList)
        {
            List<string> vals = new List<string>();
            foreach (string s in arrayList)
            {
                if (vals.Contains(s))
                {
                    dupbarcode = dupbarcode + s + ",";
                }
                vals.Add(s);
            }
        }

        protected void btnAddBarcodeProcess_Click(object sender, EventArgs e)
        {
            try
            {


                List<string> list = new List<string>();
                foreach (GridViewRow row in GvViewBarcode.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                        HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                        HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                        HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;

                        if (TxtBarcode.Text == "")
                        {

                        }
                        else
                        {
                            list.Add(TxtBarcode.Text);
                        }
                    }
                }

                string[] name = list.ToArray();

                HasDuplicates(name);
                if (dupbarcode == "")
                {
                    DataTable DtBarcodeTemp = new DataTable();
                    if (ViewState["BarcodeTemp"] != null)
                    {
                        DtBarcodeTemp = (DataTable)ViewState["BarcodeTemp"];
                    }
                    else
                    {
                        DtBarcodeTemp.Columns.Add("BARRCODE", typeof(string));
                        DtBarcodeTemp.Columns.Add("QTY", typeof(string));
                        DtBarcodeTemp.Columns.Add("SCODE", typeof(string));
                        DtBarcodeTemp.Columns.Add("BAR_TRAN_DATE", typeof(string));
                        DtBarcodeTemp.Columns.Add("BAR_TRAN_NO", typeof(string));
                        DtBarcodeTemp.Columns.Add("BAR_SRNO", typeof(string));
                    }


                    foreach (GridViewRow row in GvViewBarcode.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                            HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                            HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;
                            Label lblmsg = row.FindControl("lblmsg") as Label;
                            lblmsg.Text = string.Empty;

                            DataTable DtBarcode = new DataTable();
                            DtBarcode = BARCODE_MASLogicLayer.GetBarcodeDetail_WiseBarcodeNo(TxtBarcode.Text.Trim());
                            DataView Dv = new DataView(DtBarcode);
                            Dv.RowFilter = "STATUSFlag='O'";
                            DataTable FilterBarcode = Dv.ToTable();


                            DataView DvBarcodeTemptable = new DataView(DtBarcodeTemp);
                            DvBarcodeTemptable.RowFilter = "BARRCODE='" + TxtBarcode.Text.Trim() + "'";
                            DataTable DtBarcodeTempFiltertable = DvBarcodeTemptable.ToTable();

                            if (DtBarcodeTempFiltertable.Rows.Count <= 0)
                            {
                                if (FilterBarcode.Rows.Count > 0)
                                {
                                    HfBarTranNo.Value = FilterBarcode.Rows[0]["TRAN_NO"].ToString();
                                    HfBarTranDate.Value = FilterBarcode.Rows[0]["TRAN_DATE"].ToString();
                                    HfBarSrNo.Value = FilterBarcode.Rows[0]["SRNO"].ToString();

                                    #region Add Product INTO LIST AND CHECK IF EXIST

                                    DataTable table = new DataTable();
                                    DataRow dr = null;
                                    if (ViewState["CurrentTable"] != null)
                                    {
                                        table = (DataTable)ViewState["CurrentTable"];
                                    }
                                    else
                                    {
                                        if (table.Rows.Count <= 0)
                                        {
                                            table.Columns.Add("COMP_CODE", typeof(string));
                                            table.Columns.Add("TRAN_DATE", typeof(string));
                                            table.Columns.Add("TRAN_NO", typeof(string));
                                            table.Columns.Add("SRNO", typeof(string));
                                            table.Columns.Add("ORD_TRAN_DATE", typeof(string));
                                            table.Columns.Add("ORD_TRAN_NO", typeof(string));
                                            table.Columns.Add("ORD_SRNO", typeof(string));
                                            table.Columns.Add("SCODE", typeof(string));
                                            table.Columns.Add("HSN_NO", typeof(string));
                                            table.Columns.Add("QTY", typeof(string));
                                            table.Columns.Add("ORD_QTY", typeof(string));
                                            table.Columns.Add("REJ_QTY", typeof(string));
                                            table.Columns.Add("KEPT_QTY", typeof(string));
                                            table.Columns.Add("BAL_QTY", typeof(string));
                                            table.Columns.Add("RATE", typeof(string));
                                            table.Columns.Add("DIS_PER", typeof(string));
                                            table.Columns.Add("GST_RATE", typeof(string));
                                            table.Columns.Add("GST_AMT", typeof(string));
                                            table.Columns.Add("CGST_RATE", typeof(string));
                                            table.Columns.Add("CGST_AMT", typeof(string));
                                            table.Columns.Add("SGST_RATE", typeof(string));
                                            table.Columns.Add("SGST_AMT", typeof(string));
                                            table.Columns.Add("IGST_RATE", typeof(string));
                                            table.Columns.Add("IGST_AMT", typeof(string));
                                            table.Columns.Add("AMT", typeof(string));
                                            table.Columns.Add("DIS_AMT", typeof(string));
                                            table.Columns.Add("G_AMT", typeof(string));
                                            table.Columns.Add("T_AMT", typeof(string));
                                            table.Columns.Add("STATUS", typeof(string));
                                            table.Columns.Add("ENTRY_TYPE", typeof(string));

                                        }
                                    }


                                    string HfAmountString = "";
                                    string CGST_AMTString = "";
                                    string SGST_AMTString = "";
                                    string HfGSTAmount = "";
                                    string IGST_AMTString = "";
                                    string T_AMTString = "";


                                    if (table.Rows.Count > 0)
                                    {
                                        DataView Dvtable = new DataView(table);
                                        Dvtable.RowFilter = "SCODE=" + FilterBarcode.Rows[0]["SCODE"].ToString();
                                        DataTable DtFilterTable = Dvtable.ToTable();
                                        if (DtFilterTable.Rows.Count > 0)
                                        {
                                            //Update Qty
                                            foreach (DataRow drlp in table.Rows) // search whole table
                                            {
                                                if (drlp["SCODE"].ToString() == FilterBarcode.Rows[0]["SCODE"].ToString())
                                                {
                                                    drlp["QTY"] = (Convert.ToDouble(drlp["QTY"]) + 1);

                                                    #region Calculation For Change Qty

                                                    if (FilterBarcode.Rows[0]["RATE"].ToString().Trim() != string.Empty)
                                                    {
                                                        HfAmountString = Convert.ToString(Convert.ToDouble(FilterBarcode.Rows[0]["RATE"].ToString().Trim()) * Convert.ToDouble(drlp["QTY"]));


                                                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                                                        {
                                                            CGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["CGST_RATE"].ToString())) / 100).ToString();
                                                            SGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["SGST_RATE"].ToString())) / 100).ToString();
                                                            HfGSTAmount = (Convert.ToDouble(CGST_AMTString.Trim()) + Convert.ToDouble(SGST_AMTString.Trim())).ToString();
                                                            double d;
                                                            d = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(CGST_AMTString)) + (Convert.ToDouble(SGST_AMTString)));
                                                            T_AMTString = Convert.ToString(d);
                                                        }
                                                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                                                        {
                                                            //HiddenField IGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");
                                                            //HiddenField IGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfIGSTAmount");

                                                            IGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["IGST_RATE"].ToString())) / 100).ToString();
                                                            HfGSTAmount = IGST_AMTString;
                                                            T_AMTString = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(IGST_AMTString))).ToString();
                                                        }

                                                    }
                                                    #endregion


                                                    drlp["GST_AMT"] = HfGSTAmount;

                                                    drlp["CGST_AMT"] = CGST_AMTString;

                                                    drlp["SGST_AMT"] = SGST_AMTString;

                                                    drlp["IGST_AMT"] = IGST_AMTString;

                                                    drlp["AMT"] = HfAmountString;
                                                    break;
                                                }
                                            }




                                            dr = DtBarcodeTemp.NewRow();
                                            dr["BARRCODE"] = TxtBarcode.Text.Trim();
                                            dr["QTY"] = "1";
                                            dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
                                            dr["BAR_TRAN_DATE"] = FilterBarcode.Rows[0]["TRAN_DATE"].ToString();
                                            dr["BAR_TRAN_NO"] = FilterBarcode.Rows[0]["TRAN_NO"].ToString();
                                            dr["BAR_SRNO"] = FilterBarcode.Rows[0]["SRNO"].ToString();
                                            DtBarcodeTemp.Rows.Add(dr);
                                        }
                                        else
                                        {

                                            #region Calculation


                                            if (FilterBarcode.Rows[0]["RATE"].ToString().Trim() != string.Empty)
                                            {
                                                HfAmountString = Convert.ToString(Convert.ToDouble(FilterBarcode.Rows[0]["RATE"].ToString().Trim()) * Convert.ToDouble(1));


                                                if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                                                {
                                                    CGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["CGST_RATE"].ToString())) / 100).ToString();
                                                    SGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["SGST_RATE"].ToString())) / 100).ToString();
                                                    HfGSTAmount = (Convert.ToDouble(CGST_AMTString.Trim()) + Convert.ToDouble(SGST_AMTString.Trim())).ToString();
                                                    double d;
                                                    d = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(CGST_AMTString)) + (Convert.ToDouble(SGST_AMTString)));
                                                    T_AMTString = Convert.ToString(d);
                                                }
                                                else if (DdlPartyType.SelectedValue.ToString() == "CST")
                                                {
                                                    //HiddenField IGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");
                                                    //HiddenField IGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfIGSTAmount");

                                                    IGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["IGST_RATE"].ToString())) / 100).ToString();
                                                    HfGSTAmount = IGST_AMTString;
                                                    T_AMTString = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(IGST_AMTString))).ToString();
                                                }

                                            }

                                            else
                                            {
                                                HfAmountString = Convert.ToString(Convert.ToDouble(0));
                                            }

                                            #endregion
                                            //Add New Row Product
                                            dr = table.NewRow();
                                            dr["COMP_CODE"] = 0;
                                            dr["TRAN_DATE"] = string.Empty;
                                            dr["TRAN_NO"] = string.Empty;
                                            dr["SRNO"] = string.Empty;
                                            dr["ORD_TRAN_DATE"] = string.Empty;
                                            dr["ORD_TRAN_NO"] = string.Empty;
                                            dr["ORD_SRNO"] = string.Empty;
                                            dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
                                            dr["HSN_NO"] = string.Empty;
                                            dr["QTY"] = "1";
                                            dr["ORD_QTY"] = string.Empty;
                                            dr["REJ_QTY"] = string.Empty;
                                            dr["KEPT_QTY"] = string.Empty;
                                            dr["BAL_QTY"] = string.Empty;
                                            dr["RATE"] = FilterBarcode.Rows[0]["RATE"].ToString();
                                            dr["DIS_PER"] = string.Empty;
                                            dr["GST_RATE"] = FilterBarcode.Rows[0]["GST_RATE"].ToString();
                                            dr["GST_AMT"] = HfGSTAmount;
                                            dr["CGST_RATE"] = CGST_AMTString != string.Empty ? FilterBarcode.Rows[0]["CGST_RATE"].ToString() : "";
                                            dr["CGST_AMT"] = CGST_AMTString;
                                            dr["SGST_RATE"] = SGST_AMTString != string.Empty ? FilterBarcode.Rows[0]["SGST_RATE"].ToString() : "";
                                            dr["SGST_AMT"] = SGST_AMTString;
                                            dr["IGST_RATE"] = IGST_AMTString != string.Empty ? FilterBarcode.Rows[0]["IGST_RATE"].ToString() : "";
                                            dr["IGST_AMT"] = IGST_AMTString;
                                            dr["AMT"] = HfAmountString;
                                            dr["DIS_AMT"] = string.Empty;
                                            dr["G_AMT"] = string.Empty;
                                            dr["T_AMT"] = T_AMTString;
                                            dr["STATUS"] = string.Empty;
                                            dr["ENTRY_TYPE"] = string.Empty;
                                            table.Rows.Add(dr);

                                            dr = DtBarcodeTemp.NewRow();
                                            dr["BARRCODE"] = TxtBarcode.Text.Trim();
                                            dr["QTY"] = "1";
                                            dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
                                            dr["BAR_TRAN_DATE"] = FilterBarcode.Rows[0]["TRAN_DATE"].ToString();
                                            dr["BAR_TRAN_NO"] = FilterBarcode.Rows[0]["TRAN_NO"].ToString();
                                            dr["BAR_SRNO"] = FilterBarcode.Rows[0]["SRNO"].ToString();
                                            DtBarcodeTemp.Rows.Add(dr);
                                        }

                                    }
                                    else
                                    {


                                        #region Calculation


                                        if (FilterBarcode.Rows[0]["RATE"].ToString().Trim() != string.Empty)
                                        {
                                            HfAmountString = Convert.ToString(Convert.ToDouble(FilterBarcode.Rows[0]["RATE"].ToString().Trim()) * Convert.ToDouble(1));


                                            if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                                            {
                                                CGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["CGST_RATE"].ToString())) / 100).ToString();
                                                SGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["SGST_RATE"].ToString())) / 100).ToString();
                                                HfGSTAmount = (Convert.ToDouble(CGST_AMTString.Trim()) + Convert.ToDouble(SGST_AMTString.Trim())).ToString();
                                                double d;
                                                d = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(CGST_AMTString)) + (Convert.ToDouble(SGST_AMTString)));
                                                T_AMTString = Convert.ToString(d);
                                            }
                                            else if (DdlPartyType.SelectedValue.ToString() == "CST")
                                            {
                                                //HiddenField IGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");
                                                //HiddenField IGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfIGSTAmount");

                                                IGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["IGST_RATE"].ToString())) / 100).ToString();
                                                HfGSTAmount = IGST_AMTString;
                                                T_AMTString = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(IGST_AMTString))).ToString();
                                            }

                                        }

                                        else
                                        {
                                            HfAmountString = Convert.ToString(Convert.ToDouble(0));
                                        }

                                        #endregion


                                        //Add New Row Product
                                        dr = table.NewRow();
                                        dr["COMP_CODE"] = 0;
                                        dr["TRAN_DATE"] = string.Empty;
                                        dr["TRAN_NO"] = string.Empty;
                                        dr["SRNO"] = string.Empty;
                                        dr["ORD_TRAN_DATE"] = string.Empty;
                                        dr["ORD_TRAN_NO"] = string.Empty;
                                        dr["ORD_SRNO"] = string.Empty;
                                        dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
                                        dr["HSN_NO"] = string.Empty;
                                        dr["QTY"] = "1";
                                        dr["ORD_QTY"] = string.Empty;
                                        dr["REJ_QTY"] = string.Empty;
                                        dr["KEPT_QTY"] = string.Empty;
                                        dr["BAL_QTY"] = string.Empty;
                                        dr["RATE"] = FilterBarcode.Rows[0]["RATE"].ToString();
                                        dr["DIS_PER"] = string.Empty;
                                        dr["GST_RATE"] = FilterBarcode.Rows[0]["GST_RATE"].ToString();
                                        dr["GST_AMT"] = HfGSTAmount;
                                        dr["CGST_RATE"] = CGST_AMTString != string.Empty ? FilterBarcode.Rows[0]["CGST_RATE"].ToString() : "";
                                        dr["CGST_AMT"] = CGST_AMTString;
                                        dr["SGST_RATE"] = SGST_AMTString != string.Empty ? FilterBarcode.Rows[0]["SGST_RATE"].ToString() : "";
                                        dr["SGST_AMT"] = SGST_AMTString;
                                        dr["IGST_RATE"] = IGST_AMTString != string.Empty ? FilterBarcode.Rows[0]["IGST_RATE"].ToString() : "";
                                        dr["IGST_AMT"] = IGST_AMTString;
                                        dr["AMT"] = HfAmountString;
                                        dr["DIS_AMT"] = string.Empty;
                                        dr["G_AMT"] = string.Empty;
                                        dr["T_AMT"] = T_AMTString;
                                        dr["STATUS"] = string.Empty;
                                        dr["ENTRY_TYPE"] = string.Empty;
                                        table.Rows.Add(dr);

                                        dr = DtBarcodeTemp.NewRow();
                                        dr["BARRCODE"] = TxtBarcode.Text.Trim();
                                        dr["QTY"] = "1";
                                        dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
                                        dr["BAR_TRAN_DATE"] = FilterBarcode.Rows[0]["TRAN_DATE"].ToString();
                                        dr["BAR_TRAN_NO"] = FilterBarcode.Rows[0]["TRAN_NO"].ToString();
                                        dr["BAR_SRNO"] = FilterBarcode.Rows[0]["SRNO"].ToString();

                                        DtBarcodeTemp.Rows.Add(dr);
                                    }

                                    ViewState["BarcodeTemp"] = DtBarcodeTemp;


                                    DataView DvFilterNull = new DataView(table);
                                    DvFilterNull.RowFilter = "SCODE<>0";
                                    DataTable DtFilterNull = DvFilterNull.ToTable();


                                    ViewState["CurrentTable"] = DtFilterNull;

                                    GvDCDetails.DataSource = DtFilterNull;
                                    GvDCDetails.DataBind();

                                    #endregion

                                    lblmsg.Text = "added..! ";
                                    lblmsg.ForeColor = Color.Green;
                                }
                                else
                                {
                                    //alert
                                    //  lblbarduperror.Text = "Barcode is not available..! " ;
                                    // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Barcode is not available..!!');", true);
                                    TxtBarcode.ForeColor = Color.Red;
                                }

                            }
                            else
                            {
                                TxtBarcode.ForeColor = Color.Red;
                                lblmsg.Text = "Already added..! ";
                                lblmsg.ForeColor = Color.Red;
                            }

                        }
                    }
                    //GvViewBarcode.DataSource = DtBarcodeTemp;
                    //GvViewBarcode.DataBind();

                }
                else
                {
                    lblbarduperror.Text = "Duplicate Barcode Found! Details:- " + dupbarcode.TrimEnd(',');
                }
            }

            catch (Exception ex)
            {

                throw;
            }
        }

        #region  IMPORT EXCEL DATA TO GRIDVIEW


        protected void btnUploadBarcodeProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile == true)
                {
                    string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                    string FilePath = Server.MapPath(FolderPath + FileName);

                    FileUpload1.SaveAs(FilePath);
                    DataTable DtCust = ImportExceltoDatatable(FilePath);

                    DataTable DtBarcodeTemp = new DataTable();
                    DtBarcodeTemp.Columns.Add("BARRCODE", typeof(string));
                    DtBarcodeTemp.Columns.Add("QTY", typeof(string));
                    DtBarcodeTemp.Columns.Add("SCODE", typeof(string));
                    DtBarcodeTemp.Columns.Add("BAR_TRAN_DATE", typeof(string));
                    DtBarcodeTemp.Columns.Add("BAR_TRAN_NO", typeof(string));
                    DtBarcodeTemp.Columns.Add("BAR_SRNO", typeof(string));

                    DataRow dr = null;

                    for (int i = 0; i < DtCust.Rows.Count; i++)
                    {
                        dr = DtBarcodeTemp.NewRow();
                        dr["BARRCODE"] = DtCust.Rows[i]["BARRCODE"].ToString();
                        dr["QTY"] = "1";
                        dr["SCODE"] = string.Empty;
                        dr["BAR_TRAN_DATE"] = string.Empty;
                        dr["BAR_TRAN_NO"] = string.Empty;
                        dr["BAR_SRNO"] = string.Empty;
                        DtBarcodeTemp.Rows.Add(dr);
                    }

                    GvViewBarcode.DataSource = DtBarcodeTemp;
                    GvViewBarcode.DataBind();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelViewBarcode", "ShowModelViewBarcode()", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable ImportExceltoDatatable(string filepath)
        {
            // string sqlquery= "Select * From [SheetName$] Where YourCondition";
            string sqlquery = "Select * From [Sheet1$]";
            DataSet ds = new DataSet();
            string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
            OleDbConnection con = new OleDbConnection(constring + "");
            OleDbDataAdapter da = new OleDbDataAdapter(sqlquery, con);
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }




        #endregion

        protected void btnReturnBarcodeProcess_Click(object sender, EventArgs e)
        {
            try
            {
                int Flag = 0;

                foreach (GridViewRow row in GvViewBarcode.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        TextBox TxtBarcodeCheck = row.FindControl("TxtBarcode") as TextBox;
                        if (TxtBarcodeCheck.Text.Trim() != string.Empty)
                        {
                            if (TxtBarcodeCheck.ForeColor.Name.ToString() == "Red".ToString())
                            {
                                Flag = 1;
                                break;
                            }
                        }
                    }
                }

                if (Flag == 0)
                {
                    DataTable DtBarcodeTemp = new DataTable();
                    if (ViewState["BarcodeTemp"] != null)
                    {
                        DtBarcodeTemp = (DataTable)ViewState["BarcodeTemp"];
                    }




                    if (DtBarcodeTemp.Rows.Count > 0)
                    {
                        lblbarduperror.Text = string.Empty;
                        foreach (GridViewRow row in GvViewBarcode.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {
                                TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                                TextBox TxtQty = row.FindControl("TxtQty") as TextBox;

                                if (TxtBarcode.Text.Trim() != string.Empty)
                                {
                                    DataView DvBarcodeTemptable = new DataView(DtBarcodeTemp);
                                    DvBarcodeTemptable.RowFilter = "BARRCODE='" + TxtBarcode.Text.Trim() + "'";
                                    DataTable DtBarcodeTempFiltertable = DvBarcodeTemptable.ToTable();



                                    if (DtBarcodeTempFiltertable.Rows.Count > 0)
                                    {
                                        for (int i = DtBarcodeTemp.Rows.Count - 1; i >= 0; i--)
                                        {
                                            DataRow drReturn = DtBarcodeTemp.Rows[i];

                                            if (drReturn["BARRCODE"].ToString() == TxtBarcode.Text.Trim())
                                            {
                                                if (Convert.ToInt32(drReturn["QTY"]) == Convert.ToInt32(TxtQty.Text.Trim()))
                                                {
                                                    drReturn.Delete();
                                                }
                                                else if (Convert.ToInt32(drReturn["QTY"].ToString()) > Convert.ToInt32(TxtQty.Text.Trim()))
                                                {
                                                    drReturn["QTY"] = (Convert.ToInt32(drReturn["QTY"]) - Convert.ToInt32(TxtQty.Text.Trim()));
                                                }
                                                else
                                                {
                                                    lblbarduperror.Text = "Return Qty more than issue Qty !";
                                                }
                                            }

                                        }
                                        DtBarcodeTemp.AcceptChanges();
                                        ViewState["BarcodeTemp"] = DtBarcodeTemp;

                                        #region Return Product INTO LIST AND CHECK IF EXIST

                                        DataTable table = new DataTable();

                                        if (ViewState["CurrentTable"] != null)
                                        {
                                            table = (DataTable)ViewState["CurrentTable"];
                                        }
                                        else
                                        {
                                            if (table.Rows.Count <= 0)
                                            {
                                                table.Columns.Add("COMP_CODE", typeof(string));
                                                table.Columns.Add("TRAN_DATE", typeof(string));
                                                table.Columns.Add("TRAN_NO", typeof(string));
                                                table.Columns.Add("SRNO", typeof(string));
                                                table.Columns.Add("ORD_TRAN_DATE", typeof(string));
                                                table.Columns.Add("ORD_TRAN_NO", typeof(string));
                                                table.Columns.Add("ORD_SRNO", typeof(string));
                                                table.Columns.Add("SCODE", typeof(string));
                                                table.Columns.Add("HSN_NO", typeof(string));
                                                table.Columns.Add("QTY", typeof(string));
                                                table.Columns.Add("ORD_QTY", typeof(string));
                                                table.Columns.Add("REJ_QTY", typeof(string));
                                                table.Columns.Add("KEPT_QTY", typeof(string));
                                                table.Columns.Add("BAL_QTY", typeof(string));
                                                table.Columns.Add("RATE", typeof(string));
                                                table.Columns.Add("DIS_PER", typeof(string));
                                                table.Columns.Add("GST_RATE", typeof(string));
                                                table.Columns.Add("GST_AMT", typeof(string));
                                                table.Columns.Add("CGST_RATE", typeof(string));
                                                table.Columns.Add("CGST_AMT", typeof(string));
                                                table.Columns.Add("SGST_RATE", typeof(string));
                                                table.Columns.Add("SGST_AMT", typeof(string));
                                                table.Columns.Add("IGST_RATE", typeof(string));
                                                table.Columns.Add("IGST_AMT", typeof(string));
                                                table.Columns.Add("AMT", typeof(string));
                                                table.Columns.Add("DIS_AMT", typeof(string));
                                                table.Columns.Add("G_AMT", typeof(string));
                                                table.Columns.Add("T_AMT", typeof(string));
                                                table.Columns.Add("STATUS", typeof(string));
                                                table.Columns.Add("ENTRY_TYPE", typeof(string));

                                            }
                                        }



                                        if (table.Rows.Count > 0)
                                        {
                                            DataView Dvtable = new DataView(table);
                                            Dvtable.RowFilter = "SCODE=" + DtBarcodeTempFiltertable.Rows[0]["SCODE"].ToString();
                                            DataTable DtFilterTable = Dvtable.ToTable();
                                            if (DtFilterTable.Rows.Count > 0)
                                            {
                                                //Update Qty
                                                foreach (DataRow drlp in table.Rows) // search whole table
                                                {
                                                    if (drlp["SCODE"].ToString() == DtBarcodeTempFiltertable.Rows[0]["SCODE"].ToString())
                                                    {
                                                        if ((Convert.ToDouble(drlp["QTY"]) - 1) == 0)
                                                        {
                                                            drlp.Delete();
                                                        }
                                                        else
                                                        {

                                                            drlp["QTY"] = (Convert.ToDouble(drlp["QTY"]) - 1);
                                                        }

                                                        break;

                                                    }
                                                }
                                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Barcode Return Sucessfully..!!');", true);

                                            }
                                        }

                                        ViewState["CurrentTable"] = table;

                                        if (table.Rows.Count <= 0)
                                        {
                                            SetInitialRow();
                                        }


                                        #endregion
                                    }
                                    else
                                    {
                                        TxtBarcode.ForeColor = Color.Red;
                                    }

                                }
                            }
                        }

                        if (DtBarcodeTemp.Rows.Count <= 0)
                        {

                            //dt.Columns.Add("BARRCODE", typeof(System.String));
                            //dt.Columns.Add("QTY", typeof(System.String));
                            //dt.Columns.Add("SCODE", typeof(System.String));
                            //dt.Columns.Add("BAR_TRAN_DATE", typeof(System.String));
                            //dt.Columns.Add("BAR_TRAN_NO", typeof(System.String));
                            //dt.Columns.Add("BAR_SRNO", typeof(System.String));

                            for (int i = 0; i < 1; i++)
                            {
                                DataRow dr = DtBarcodeTemp.NewRow();
                                dr["BARRCODE"] = "";
                                dr["QTY"] = "";
                                dr["SCODE"] = "";
                                dr["BAR_TRAN_DATE"] = "";
                                dr["BAR_TRAN_NO"] = "";
                                dr["BAR_SRNO"] = "";
                                DtBarcodeTemp.Rows.Add(dr);
                            }
                        }

                        GvViewBarcode.DataSource = DtBarcodeTemp;
                        GvViewBarcode.DataBind();


                    }
                    else
                    {
                        lblbarduperror.Text = "Barcode not exist";
                        SetInitialRow();
                    }
                    GvDCDetails.DataSource = (DataTable)ViewState["CurrentTable"];
                    GvDCDetails.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid Barcode..!!');", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        public void FillDCDetailsGrid()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = DC_DETLogicLayer.GetAllDC_DetailByCompanyForSales((Session["COMP_CODE"].ToString()));
                GvDCDetails.DataSource = Dt;
                GvDCDetails.DataBind();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #region ADD NEW ROW IIN DC_DETAILS GRID

        private void SetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("ORD_TRAN_DATE", typeof(string));
            table.Columns.Add("ORD_TRAN_NO", typeof(string));
            table.Columns.Add("ORD_SRNO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("HSN_NO", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("ORD_QTY", typeof(string));
            table.Columns.Add("REJ_QTY", typeof(string));
            table.Columns.Add("KEPT_QTY", typeof(string));
            table.Columns.Add("BAL_QTY", typeof(string));
            table.Columns.Add("RATE", typeof(string));
            table.Columns.Add("DIS_PER", typeof(string));
            table.Columns.Add("GST_RATE", typeof(string));
            table.Columns.Add("GST_AMT", typeof(string));
            table.Columns.Add("CGST_RATE", typeof(string));
            table.Columns.Add("CGST_AMT", typeof(string));
            table.Columns.Add("SGST_RATE", typeof(string));
            table.Columns.Add("SGST_AMT", typeof(string));
            table.Columns.Add("IGST_RATE", typeof(string));
            table.Columns.Add("IGST_AMT", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("DIS_AMT", typeof(string));
            table.Columns.Add("G_AMT", typeof(string));
            table.Columns.Add("T_AMT", typeof(string));
            table.Columns.Add("STATUS", typeof(string));
            table.Columns.Add("ENTRY_TYPE", typeof(string));





            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["ORD_TRAN_DATE"] = string.Empty;
            dr["ORD_TRAN_NO"] = string.Empty;
            dr["ORD_SRNO"] = string.Empty;
            dr["SCODE"] = "0";
            dr["HSN_NO"] = string.Empty;
            dr["QTY"] = "0";
            dr["ORD_QTY"] = string.Empty;
            dr["REJ_QTY"] = string.Empty;
            dr["KEPT_QTY"] = string.Empty;
            dr["BAL_QTY"] = string.Empty;
            dr["RATE"] = string.Empty;
            dr["DIS_PER"] = string.Empty;
            dr["GST_RATE"] = string.Empty;
            dr["GST_AMT"] = string.Empty;
            dr["CGST_RATE"] = string.Empty;
            dr["CGST_AMT"] = string.Empty;
            dr["SGST_RATE"] = string.Empty;
            dr["SGST_AMT"] = string.Empty;
            dr["IGST_RATE"] = string.Empty;
            dr["IGST_AMT"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["DIS_AMT"] = string.Empty;
            dr["G_AMT"] = string.Empty;
            dr["T_AMT"] = string.Empty;
            dr["STATUS"] = string.Empty;
            dr["ENTRY_TYPE"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvDCDetails.DataSource = table;
            GvDCDetails.DataBind();
        }


        private void AddNewRowToGrid()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values 
                        //TextBox TxtSrNo = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("TxtSrNo");
                        // TextBox TxtProductCode = (TextBox)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("TxtProductCode");

                        Label lblSumTotalREC_QTY = (Label)(GvDCDetails.FooterRow.FindControl("lblSumTotalREC_QTY"));
                        Label lblSumTotalRate = (Label)(GvDCDetails.FooterRow.FindControl("lblSumTotalRate"));

                        HiddenField HfOrderTranDate = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfOrderTranDate");
                        HiddenField HfOrderTranNo = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfOrderTranNo");
                        HiddenField HfOrderSrNo = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfOrderSrNo");
                        HiddenField HfEntryType = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfEntryType");

                        HiddenField HfGSTAmount = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfCGSTRate = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfCGSTRate");
                        HiddenField HfCGSTAmount = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfCGSTAmount");
                        HiddenField HfSGSTRate = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfSGSTRate");
                        HiddenField HfSGSTAmount = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfSGSTAmount");
                        HiddenField HfIGSTRate = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfIGSTRate");
                        HiddenField HfIGSTAmount = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfIGSTAmount");

                        HiddenField HfAmount = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        HiddenField HfDisAmount = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                        HiddenField HfGrossAmount = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfGrossAmount");
                        HiddenField HfTotalAmount = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfTotalAmount");
                        HiddenField HfStatus = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfStatus");

                        HiddenField HfDetailSCode = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtProductName = (TextBox)GvDCDetails.Rows[rowIndex].Cells[1].FindControl("TxtProductName");
                        TextBox TxtHsncode = (TextBox)GvDCDetails.Rows[rowIndex].Cells[2].FindControl("TxtHsncode");
                        TextBox TxtOrderQty = (TextBox)GvDCDetails.Rows[rowIndex].Cells[3].FindControl("TxtOrderQty");
                        TextBox TxtReceivedQty = (TextBox)GvDCDetails.Rows[rowIndex].Cells[4].FindControl("TxtReceivedQty");
                        TextBox TxtReturnQty = (TextBox)GvDCDetails.Rows[rowIndex].Cells[5].FindControl("TxtReturnQty");
                        TextBox TxtBalQty = (TextBox)GvDCDetails.Rows[rowIndex].Cells[6].FindControl("TxtBalQty");
                        TextBox TxtRecQty = (TextBox)GvDCDetails.Rows[rowIndex].Cells[7].FindControl("TxtRecQty");
                        TextBox TxtRate = (TextBox)GvDCDetails.Rows[rowIndex].Cells[8].FindControl("TxtRate");
                        TextBox TxtDisc = (TextBox)GvDCDetails.Rows[rowIndex].Cells[9].FindControl("TxtDisc");
                        TextBox TxtGstRate = (TextBox)GvDCDetails.Rows[rowIndex].Cells[10].FindControl("TxtGstRate");


                        //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();

                        if (HfOrderTranDate.Value.Trim() != string.Empty)
                        {
                            dtCurrentTable.Rows[i - 1]["ORD_TRAN_DATE"] = Convert.ToDateTime(HfOrderTranDate.Value.Trim()).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            dtCurrentTable.Rows[i - 1]["ORD_TRAN_DATE"] = DBNull.Value;
                        }

                        if (HfOrderTranNo.Value.Trim() != string.Empty)
                        {
                            dtCurrentTable.Rows[i - 1]["ORD_TRAN_NO"] = HfOrderTranNo.Value.Trim();
                        }
                        else
                        {
                            dtCurrentTable.Rows[i - 1]["ORD_TRAN_NO"] = DBNull.Value;
                        }
                        if (HfOrderSrNo.Value.Trim() != string.Empty)
                        {
                            dtCurrentTable.Rows[i - 1]["ORD_SRNO"] = HfOrderSrNo.Value.Trim();
                        }
                        else
                        {
                            dtCurrentTable.Rows[i - 1]["ORD_SRNO"] = DBNull.Value;
                        }

                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["ENTRY_TYPE"] = HfEntryType.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["HSN_NO"] = TxtHsncode.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtRecQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["ORD_QTY"] = TxtOrderQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["KEPT_QTY"] = TxtReceivedQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["REJ_QTY"] = TxtReturnQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["BAL_QTY"] = TxtBalQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["DIS_PER"] = TxtDisc.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["GST_RATE"] = TxtGstRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["CGST_RATE"] = HfCGSTRate.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["CGST_AMT"] = HfCGSTAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["SGST_RATE"] = HfSGSTRate.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["SGST_AMT"] = HfSGSTAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["IGST_RATE"] = HfIGSTRate.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["IGST_AMT"] = HfIGSTAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = HfAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["DIS_AMT"] = HfDisAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["G_AMT"] = HfGrossAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["T_AMT"] = HfTotalAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["STATUS"] = HfStatus.Value.Trim();
                        //Status
                        rowIndex++;


                        double lblTotRecQty = TotalReceiveQty();
                        lblSumTotalREC_QTY.Text = lblTotRecQty.ToString();

                    }

                    drCurrentRow = dtCurrentTable.NewRow();

                    //drCurrentRow["SRNO"] = "";
                    drCurrentRow["ORD_TRAN_DATE"] = DBNull.Value;
                    drCurrentRow["ORD_TRAN_NO"] = DBNull.Value;
                    drCurrentRow["ORD_SRNO"] = DBNull.Value;
                    drCurrentRow["ENTRY_TYPE"] = "";
                    drCurrentRow["SCODE"] = "0";
                    drCurrentRow["HSN_NO"] = "0";
                    drCurrentRow["QTY"] = "0";
                    drCurrentRow["ORD_QTY"] = "0";
                    drCurrentRow["KEPT_QTY"] = "0";
                    drCurrentRow["REJ_QTY"] = "0";
                    drCurrentRow["BAL_QTY"] = "0";
                    drCurrentRow["RATE"] = "0";
                    drCurrentRow["DIS_PER"] = "0";
                    drCurrentRow["GST_RATE"] = "0";
                    drCurrentRow["GST_AMT"] = "0";
                    drCurrentRow["CGST_RATE"] = "0";
                    drCurrentRow["CGST_AMT"] = "0";
                    drCurrentRow["SGST_RATE"] = "0";
                    drCurrentRow["SGST_AMT"] = "0";
                    drCurrentRow["IGST_RATE"] = "0";
                    drCurrentRow["IGST_AMT"] = "0";
                    drCurrentRow["AMT"] = "0";
                    drCurrentRow["DIS_AMT"] = "0";
                    drCurrentRow["G_AMT"] = "0";
                    drCurrentRow["T_AMT"] = "0";
                    drCurrentRow["STATUS"] = "O";

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvDCDetails.DataSource = dtCurrentTable;
                    GvDCDetails.DataBind();
                }
            }

            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousData();
        }


        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        //TextBox TxtSrNo = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("TxtSrNo");
                        // TextBox TxtProductCode = (TextBox)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("TxtProductCode");

                        Label lblSumTotalREC_QTY = (Label)(GvDCDetails.FooterRow.FindControl("lblSumTotalREC_QTY"));
                        Label lblSumTotalRate = (Label)(GvDCDetails.FooterRow.FindControl("lblSumTotalRate"));

                        HiddenField HfOrderTranDate = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfOrderTranDate");
                        HiddenField HfOrderTranNo = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfOrderTranNo");
                        HiddenField HfOrderSrNo = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfOrderSrNo");
                        HiddenField HfEntryType = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfEntryType");

                        HiddenField HfGSTAmount = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfCGSTRate = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfCGSTRate");
                        HiddenField HfCGSTAmount = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfCGSTAmount");
                        HiddenField HfSGSTRate = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfSGSTRate");
                        HiddenField HfSGSTAmount = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfSGSTAmount");
                        HiddenField HfIGSTRate = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfIGSTRate");
                        HiddenField HfIGSTAmount = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfIGSTAmount");

                        HiddenField HfStatus = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfStatus");
                        HiddenField HfAmount = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        HiddenField HfDisAmount = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                        HiddenField HfGrossAmount = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfGrossAmount");
                        HiddenField HfTotalAmount = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfTotalAmount");


                        HiddenField HfDetailSCode = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtProductName = (TextBox)GvDCDetails.Rows[rowIndex].Cells[1].FindControl("TxtProductName");
                        TextBox TxtHsncode = (TextBox)GvDCDetails.Rows[rowIndex].Cells[2].FindControl("TxtHsncode");
                        TextBox TxtOrderQty = (TextBox)GvDCDetails.Rows[rowIndex].Cells[3].FindControl("TxtOrderQty");
                        TextBox TxtReceivedQty = (TextBox)GvDCDetails.Rows[rowIndex].Cells[4].FindControl("TxtReceivedQty");
                        TextBox TxtReturnQty = (TextBox)GvDCDetails.Rows[rowIndex].Cells[5].FindControl("TxtReturnQty");
                        TextBox TxtBalQty = (TextBox)GvDCDetails.Rows[rowIndex].Cells[6].FindControl("TxtBalQty");
                        TextBox TxtRecQty = (TextBox)GvDCDetails.Rows[rowIndex].Cells[7].FindControl("TxtRecQty");
                        TextBox TxtRate = (TextBox)GvDCDetails.Rows[rowIndex].Cells[8].FindControl("TxtRate");
                        TextBox TxtDisc = (TextBox)GvDCDetails.Rows[rowIndex].Cells[9].FindControl("TxtDisc");
                        TextBox TxtGstRate = (TextBox)GvDCDetails.Rows[rowIndex].Cells[10].FindControl("TxtGstRate");


                        //TxtSrNo.Text = dt.Rows[i]["SRNO"].ToString();
                        HfStatus.Value = dt.Rows[i]["STATUS"].ToString();
                        HfEntryType.Value = dt.Rows[i]["ENTRY_TYPE"].ToString();
                        HfOrderTranDate.Value = dt.Rows[i]["ORD_TRAN_DATE"].ToString();
                        HfOrderTranNo.Value = dt.Rows[i]["ORD_TRAN_NO"].ToString();
                        HfOrderSrNo.Value = dt.Rows[i]["ORD_SRNO"].ToString();
                        HfDetailSCode.Value = dt.Rows[i]["SCODE"].ToString();
                        TxtHsncode.Text = dt.Rows[i]["HSN_NO"].ToString();
                        TxtRecQty.Text = dt.Rows[i]["QTY"].ToString();
                        TxtOrderQty.Text = dt.Rows[i]["ORD_QTY"].ToString();
                        TxtReceivedQty.Text = dt.Rows[i]["KEPT_QTY"].ToString();
                        TxtReturnQty.Text = dt.Rows[i]["REJ_QTY"].ToString();
                        TxtBalQty.Text = dt.Rows[i]["BAL_QTY"].ToString();
                        TxtRate.Text = dt.Rows[i]["RATE"].ToString();
                        TxtDisc.Text = dt.Rows[i]["DIS_PER"].ToString();
                        TxtGstRate.Text = dt.Rows[i]["GST_RATE"].ToString();
                        HfGSTAmount.Value = dt.Rows[i]["GST_AMT"].ToString();
                        HfCGSTRate.Value = dt.Rows[i]["CGST_RATE"].ToString();
                        HfCGSTAmount.Value = dt.Rows[i]["CGST_AMT"].ToString();
                        HfSGSTRate.Value = dt.Rows[i]["SGST_RATE"].ToString();
                        HfSGSTAmount.Value = dt.Rows[i]["SGST_AMT"].ToString();
                        HfIGSTRate.Value = dt.Rows[i]["IGST_RATE"].ToString();
                        HfIGSTAmount.Value = dt.Rows[i]["IGST_AMT"].ToString();
                        HfIGSTAmount.Value = dt.Rows[i]["AMT"].ToString();
                        HfIGSTAmount.Value = dt.Rows[i]["DIS_AMT"].ToString();
                        HfIGSTAmount.Value = dt.Rows[i]["G_AMT"].ToString();
                        HfIGSTAmount.Value = dt.Rows[i]["T_AMT"].ToString();

                        rowIndex++;


                        double lblTotRecQty = TotalReceiveQty();
                        lblSumTotalREC_QTY.Text = lblTotRecQty.ToString();

                    }
                }
            }
        }


        protected void BtnDeleteRowModelDC_DetailsGrid_Click(object sender, EventArgs e)
        {

            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex + 1;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {

                    if (gvRow.RowIndex <= dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data
                        dt.Rows.Remove(dt.Rows[rowID - 1]);
                    }
                }
                //Store the current data in ViewState for future reference
                ViewState["CurrentTable"] = dt;
                //Re bind the GridView for the updated data
                GvDCDetails.DataSource = dt;
                GvDCDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }

        protected void BtnAddRowModelDC_DetailsGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        #endregion

        protected void GvDCDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDCDetails.PageIndex = e.NewPageIndex;
            clear();
            FillDCDetailsGrid();

        }

        protected void GvDCDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GvDCDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    TextBox TxtProductName = (e.Row.FindControl("TxtProductName") as TextBox);
                    TextBox TxtProductCode = (e.Row.FindControl("TxtProductCode") as TextBox);
                    TextBox TxtHsncode = (e.Row.FindControl("TxtHsncode") as TextBox);
                    TextBox TxtRecQty = (e.Row.FindControl("TxtRecQty") as TextBox);
                    HiddenField HfDetailSCode = (e.Row.FindControl("HfDetailSCode") as HiddenField);

                    DataTable DtProduct = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();

                    DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);


                    if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != string.Empty)
                    {
                        DataView Dv = new DataView(DtProduct);
                        Dv.RowFilter = "SCODE=" + HfDetailSCode.Value;
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            TxtProductName.Text = DtView.Rows[0]["SNAME"].ToString();
                            TxtProductCode.Text = DtView.Rows[0]["PROD_CODE"].ToString();
                            TxtHsncode.Text = DtView.Rows[0]["HSN_NO"].ToString();

                        }
                        else
                        {
                            TxtProductName.Text = string.Empty;
                            TxtProductCode.Text = string.Empty;
                            TxtHsncode.Text = string.Empty;

                        }
                    }



                    if (Session["WORK_VIEWFLAG"].ToString() == "B")
                    {

                        TxtProductName.Enabled = false;
                        TxtProductCode.Enabled = false;
                        TxtHsncode.Enabled = false;
                        TxtRecQty.Enabled = false;
                    }
                    else
                    {
                        TxtProductName.Enabled = true;
                        TxtProductCode.Enabled = true;
                        TxtHsncode.Enabled = true;
                        TxtRecQty.Enabled = true;
                    }

                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblSumTotalREC_QTY = (Label)e.Row.FindControl("lblSumTotalREC_QTY");

                    double lblTotRecQty = TotalReceiveQty();
                    lblSumTotalREC_QTY.Text = lblTotRecQty.ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        #region ADD NEW ROW IN EXTRA ITEM GRID

        private void SetInitialRowEx()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("ORD_TRAN_DATE", typeof(string));
            table.Columns.Add("ORD_TRAN_NO", typeof(string));
            table.Columns.Add("ORD_SRNO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("PRODUCT_DESC", typeof(string));
            table.Columns.Add("HSN_NO", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("RATE", typeof(string));
            table.Columns.Add("DIS_PER", typeof(string));
            table.Columns.Add("GST_RATE", typeof(string));
            table.Columns.Add("GST_AMT", typeof(string));
            table.Columns.Add("CGST_RATE", typeof(string));
            table.Columns.Add("CGST_AMT", typeof(string));
            table.Columns.Add("SGST_RATE", typeof(string));
            table.Columns.Add("SGST_AMT", typeof(string));
            table.Columns.Add("IGST_RATE", typeof(string));
            table.Columns.Add("IGST_AMT", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("DIS_AMT", typeof(string));
            table.Columns.Add("G_AMT", typeof(string));
            table.Columns.Add("T_AMT", typeof(string));
            table.Columns.Add("STATUS", typeof(string));
            table.Columns.Add("ENTRY_TYPE", typeof(string));

            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["ORD_TRAN_DATE"] = string.Empty;
            dr["ORD_TRAN_NO"] = string.Empty;
            dr["ORD_SRNO"] = string.Empty;
            dr["SCODE"] = "0";
            dr["PRODUCT_DESC"] = string.Empty;
            dr["HSN_NO"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["RATE"] = string.Empty;
            dr["DIS_PER"] = string.Empty;
            dr["GST_RATE"] = string.Empty;
            dr["GST_AMT"] = string.Empty;
            dr["CGST_RATE"] = string.Empty;
            dr["CGST_AMT"] = string.Empty;
            dr["SGST_RATE"] = string.Empty;
            dr["SGST_AMT"] = string.Empty;
            dr["IGST_RATE"] = string.Empty;
            dr["IGST_AMT"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["DIS_AMT"] = string.Empty;
            dr["G_AMT"] = string.Empty;
            dr["T_AMT"] = string.Empty;
            dr["STATUS"] = string.Empty;
            dr["ENTRY_TYPE"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["CurrentTable_Ex"] = table;

            GvDCDetailsExStock.DataSource = table;
            GvDCDetailsExStock.DataBind();
        }


        private void AddNewRowToGridEx()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable_Ex"] != null)
            {
                DataTable dtCurrentTableEx = (DataTable)ViewState["CurrentTable_Ex"];
                DataRow drCurrentRowEx = null;
                if (dtCurrentTableEx.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTableEx.Rows.Count; i++)
                    {
                        //extract the TextBox values 

                        Label lblSumTotalREC_QTY = (Label)(GvDCDetailsExStock.FooterRow.FindControl("lblSumTotalEXtraREC_QTY"));
                        Label lblSumTotalRate = (Label)(GvDCDetailsExStock.FooterRow.FindControl("lblSumTotalRate"));

                        HiddenField HfOrderTranDate = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfOrderTranDate");
                        HiddenField HfOrderTranNo = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfOrderTranNo");
                        HiddenField HfOrderSrNo = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfOrderSrNo");
                        HiddenField HfEntryType = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfEntryType");

                        HiddenField HfGSTAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfCGSTRate = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfCGSTRate");
                        HiddenField HfCGSTAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfCGSTAmount");
                        HiddenField HfSGSTRate = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfSGSTRate");
                        HiddenField HfSGSTAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfSGSTAmount");
                        HiddenField HfIGSTRate = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfIGSTRate");
                        HiddenField HfIGSTAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfIGSTAmount");

                        HiddenField HfAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        HiddenField HfDisAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                        HiddenField HfGrossAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfGrossAmount");
                        HiddenField HfTotalAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfTotalAmount");
                        HiddenField HfStatus = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfStatus");

                        HiddenField HfDetailSCode = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtProductName = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[2].FindControl("TxtProductName");
                        TextBox TxtExProductDesc = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[3].FindControl("TxtExProductDesc");
                        TextBox TxtRecQty = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[5].FindControl("TxtRecQty");
                        TextBox TxtRate = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[6].FindControl("TxtRate");
                        TextBox TxtDisc = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[7].FindControl("TxtDisc");
                        TextBox TxtGstRate = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[8].FindControl("TxtGstRate");


                        //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();

                        if (HfOrderTranDate.Value.Trim() != string.Empty)
                        {
                            dtCurrentTableEx.Rows[i - 1]["ORD_TRAN_DATE"] = Convert.ToDateTime(HfOrderTranDate.Value.Trim()).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            dtCurrentTableEx.Rows[i - 1]["ORD_TRAN_DATE"] = DBNull.Value;
                        }

                        if (HfOrderTranNo.Value.Trim() != string.Empty)
                        {
                            dtCurrentTableEx.Rows[i - 1]["ORD_TRAN_NO"] = HfOrderTranNo.Value.Trim();
                        }
                        else
                        {
                            dtCurrentTableEx.Rows[i - 1]["ORD_TRAN_NO"] = DBNull.Value;
                        }
                        if (HfOrderSrNo.Value.Trim() != string.Empty)
                        {
                            dtCurrentTableEx.Rows[i - 1]["ORD_SRNO"] = HfOrderSrNo.Value.Trim();
                        }
                        else
                        {
                            dtCurrentTableEx.Rows[i - 1]["ORD_SRNO"] = DBNull.Value;
                        }

                        dtCurrentTableEx.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["ENTRY_TYPE"] = HfEntryType.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["PRODUCT_DESC"] = TxtExProductDesc.Text.Trim();
                        dtCurrentTableEx.Rows[i - 1]["QTY"] = TxtRecQty.Text.Trim();
                        dtCurrentTableEx.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                        dtCurrentTableEx.Rows[i - 1]["DIS_PER"] = TxtDisc.Text.Trim();
                        dtCurrentTableEx.Rows[i - 1]["GST_RATE"] = TxtGstRate.Text.Trim();
                        dtCurrentTableEx.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["CGST_RATE"] = HfCGSTRate.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["CGST_AMT"] = HfCGSTAmount.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["SGST_RATE"] = HfSGSTRate.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["SGST_AMT"] = HfSGSTAmount.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["IGST_RATE"] = HfIGSTRate.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["IGST_AMT"] = HfIGSTAmount.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["AMT"] = HfAmount.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["DIS_AMT"] = HfDisAmount.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["G_AMT"] = HfGrossAmount.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["T_AMT"] = HfTotalAmount.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["STATUS"] = HfStatus.Value.Trim();
                        //Status
                        rowIndex++;

                        double lblTotRecQty = TotalExtraReceiveQty();
                        lblSumTotalREC_QTY.Text = lblTotRecQty.ToString();

                    }

                    drCurrentRowEx = dtCurrentTableEx.NewRow();

                    //drCurrentRow["SRNO"] = "";
                    drCurrentRowEx["ORD_TRAN_DATE"] = DBNull.Value;
                    drCurrentRowEx["ORD_TRAN_NO"] = DBNull.Value;
                    drCurrentRowEx["ORD_SRNO"] = DBNull.Value;
                    drCurrentRowEx["ENTRY_TYPE"] = "";
                    drCurrentRowEx["SCODE"] = "0";
                    drCurrentRowEx["PRODUCT_DESC"] = "";
                    drCurrentRowEx["QTY"] = "0";
                    drCurrentRowEx["RATE"] = "0";
                    drCurrentRowEx["DIS_PER"] = "0";
                    drCurrentRowEx["GST_RATE"] = "0";
                    drCurrentRowEx["GST_AMT"] = "0";
                    drCurrentRowEx["CGST_RATE"] = "0";
                    drCurrentRowEx["CGST_AMT"] = "0";
                    drCurrentRowEx["SGST_RATE"] = "0";
                    drCurrentRowEx["SGST_AMT"] = "0";
                    drCurrentRowEx["IGST_RATE"] = "0";
                    drCurrentRowEx["IGST_AMT"] = "0";
                    drCurrentRowEx["AMT"] = "0";
                    drCurrentRowEx["DIS_AMT"] = "0";
                    drCurrentRowEx["G_AMT"] = "0";
                    drCurrentRowEx["T_AMT"] = "0";
                    drCurrentRowEx["STATUS"] = "O";

                    dtCurrentTableEx.Rows.Add(drCurrentRowEx);
                    ViewState["CurrentTable_Ex"] = dtCurrentTableEx;

                    GvDCDetailsExStock.DataSource = dtCurrentTableEx;
                    GvDCDetailsExStock.DataBind();
                }
            }

            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousDataEx();
        }


        private void SetPreviousDataEx()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable_Ex"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable_Ex"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        //TextBox TxtSrNo = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("TxtSrNo");
                        // TextBox TxtProductCode = (TextBox)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("TxtProductCode");

                        Label lblSumTotalREC_QTY = (Label)(GvDCDetailsExStock.FooterRow.FindControl("lblSumTotalEXtraREC_QTY"));
                        Label lblSumTotalRate = (Label)(GvDCDetailsExStock.FooterRow.FindControl("lblSumTotalRate"));

                        HiddenField HfOrderTranDate = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfOrderTranDate");
                        HiddenField HfOrderTranNo = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfOrderTranNo");
                        HiddenField HfOrderSrNo = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfOrderSrNo");
                        HiddenField HfEntryType = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfEntryType");

                        HiddenField HfGSTAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfCGSTRate = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfCGSTRate");
                        HiddenField HfCGSTAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfCGSTAmount");
                        HiddenField HfSGSTRate = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfSGSTRate");
                        HiddenField HfSGSTAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfSGSTAmount");
                        HiddenField HfIGSTRate = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfIGSTRate");
                        HiddenField HfIGSTAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfIGSTAmount");

                        HiddenField HfStatus = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfStatus");
                        HiddenField HfAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        HiddenField HfDisAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                        HiddenField HfGrossAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfGrossAmount");
                        HiddenField HfTotalAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfTotalAmount");


                        HiddenField HfDetailSCode = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtProductName = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[2].FindControl("TxtProductName");
                        TextBox TxtExProductDesc = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[3].FindControl("TxtExProductDesc");
                        TextBox TxtRecQty = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[5].FindControl("TxtRecQty");
                        TextBox TxtRate = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[6].FindControl("TxtRate");
                        TextBox TxtDisc = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[7].FindControl("TxtDisc");
                        TextBox TxtGstRate = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[8].FindControl("TxtGstRate");


                        //TxtSrNo.Text = dt.Rows[i]["SRNO"].ToString();
                        HfStatus.Value = dt.Rows[i]["STATUS"].ToString();
                        HfEntryType.Value = dt.Rows[i]["ENTRY_TYPE"].ToString();
                        HfOrderTranDate.Value = dt.Rows[i]["ORD_TRAN_DATE"].ToString();
                        HfOrderTranNo.Value = dt.Rows[i]["ORD_TRAN_NO"].ToString();
                        HfOrderSrNo.Value = dt.Rows[i]["ORD_SRNO"].ToString();
                        HfDetailSCode.Value = dt.Rows[i]["SCODE"].ToString();
                        TxtExProductDesc.Text = dt.Rows[i]["PRODUCT_DESC"].ToString();
                        TxtRecQty.Text = dt.Rows[i]["QTY"].ToString();
                        TxtRate.Text = dt.Rows[i]["RATE"].ToString();
                        TxtDisc.Text = dt.Rows[i]["DIS_PER"].ToString();
                        TxtGstRate.Text = dt.Rows[i]["GST_RATE"].ToString();
                        HfGSTAmount.Value = dt.Rows[i]["GST_AMT"].ToString();
                        HfCGSTRate.Value = dt.Rows[i]["CGST_RATE"].ToString();
                        HfCGSTAmount.Value = dt.Rows[i]["CGST_AMT"].ToString();
                        HfSGSTRate.Value = dt.Rows[i]["SGST_RATE"].ToString();
                        HfSGSTAmount.Value = dt.Rows[i]["SGST_AMT"].ToString();
                        HfIGSTRate.Value = dt.Rows[i]["IGST_RATE"].ToString();
                        HfIGSTAmount.Value = dt.Rows[i]["IGST_AMT"].ToString();
                        HfIGSTAmount.Value = dt.Rows[i]["AMT"].ToString();
                        HfIGSTAmount.Value = dt.Rows[i]["DIS_AMT"].ToString();
                        HfIGSTAmount.Value = dt.Rows[i]["G_AMT"].ToString();
                        HfIGSTAmount.Value = dt.Rows[i]["T_AMT"].ToString();

                        rowIndex++;

                        double lblTotRecQty = TotalExtraReceiveQty();
                        lblSumTotalREC_QTY.Text = lblTotRecQty.ToString();

                    }
                }
            }
        }


        protected void BtnDeleteRowModelDC_ExStockGrid_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
                int rowID = gvRow.RowIndex + 1;
                if (ViewState["CurrentTable_Ex"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentTable_Ex"];
                    if (dt.Rows.Count > 1)
                    {

                        if (gvRow.RowIndex <= dt.Rows.Count - 1)
                        {
                            //Remove the Selected Row data
                            dt.Rows.Remove(dt.Rows[rowID - 1]);
                        }
                    }
                    //Store the current data in ViewState for future reference
                    ViewState["CurrentTable_Ex"] = dt;
                    //Re bind the GridView for the updated data
                    GvDCDetailsExStock.DataSource = dt;
                    GvDCDetailsExStock.DataBind();
                }

                //Set Previous Data on Postbacks
                SetPreviousDataEx();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnAddRowModelDC_ExStockGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGridEx();
        }

        #endregion

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetProductCode(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from STOCK_MAS where COMP_CODE=@COMP_CODE and PROD_CODE like @PROD_CODE + '%'", con);
            cmd.Parameters.AddWithValue("@PROD_CODE", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> prodCode = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                prodCode.Add(dt.Rows[i][11].ToString());
            }
            return prodCode;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetStockName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from STOCK_MAS where COMP_CODE=@COMP_CODE and sname like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> StockNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StockNames.Add(dt.Rows[i][1].ToString());
            }
            return StockNames;
        }

        public void FillOnGridExtraStockDetailChanged()
        {
            #region Assign To Extra Stock Grid 

            int rowIndex = 0;

            if (ViewState["CurrentTable_Ex"] != null)
            {
                DataTable dtCurrentTableEx = (DataTable)ViewState["CurrentTable_Ex"];

                if (dtCurrentTableEx.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTableEx.Rows.Count; i++)
                    {
                        //extract the TextBox values 

                        Label lblSumTotalREC_QTY = (Label)(GvDCDetailsExStock.FooterRow.FindControl("lblSumTotalEXtraREC_QTY"));
                        Label lblSumTotalRate = (Label)(GvDCDetailsExStock.FooterRow.FindControl("lblSumTotalRate"));

                        HiddenField HfOrderTranDate = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfOrderTranDate");
                        HiddenField HfOrderTranNo = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfOrderTranNo");
                        HiddenField HfOrderSrNo = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfOrderSrNo");
                        HiddenField HfEntryType = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfEntryType");

                        HiddenField HfGSTAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfCGSTRate = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfCGSTRate");
                        HiddenField HfCGSTAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfCGSTAmount");
                        HiddenField HfSGSTRate = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfSGSTRate");
                        HiddenField HfSGSTAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfSGSTAmount");
                        HiddenField HfIGSTRate = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfIGSTRate");
                        HiddenField HfIGSTAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfIGSTAmount");

                        HiddenField HfAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        HiddenField HfDisAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                        HiddenField HfGrossAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfGrossAmount");
                        HiddenField HfTotalAmount = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfTotalAmount");
                        HiddenField HfStatus = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfStatus");

                        HiddenField HfDetailSCode = (HiddenField)GvDCDetailsExStock.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtProductName = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[2].FindControl("TxtProductName");
                        TextBox TxtExProductDesc = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[3].FindControl("TxtExProductDesc");
                        TextBox TxtRecQty = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[5].FindControl("TxtRecQty");
                        TextBox TxtRate = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[6].FindControl("TxtRate");
                        TextBox TxtDisc = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[7].FindControl("TxtDisc");
                        TextBox TxtGstRate = (TextBox)GvDCDetailsExStock.Rows[rowIndex].Cells[8].FindControl("TxtGstRate");


                        //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();

                        if (HfOrderTranDate.Value.Trim() != string.Empty)
                        {
                            dtCurrentTableEx.Rows[i - 1]["ORD_TRAN_DATE"] = Convert.ToDateTime(HfOrderTranDate.Value.Trim()).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            dtCurrentTableEx.Rows[i - 1]["ORD_TRAN_DATE"] = DBNull.Value;
                        }

                        if (HfOrderTranNo.Value.Trim() != string.Empty)
                        {
                            dtCurrentTableEx.Rows[i - 1]["ORD_TRAN_NO"] = HfOrderTranNo.Value.Trim();
                        }
                        else
                        {
                            dtCurrentTableEx.Rows[i - 1]["ORD_TRAN_NO"] = DBNull.Value;
                        }
                        if (HfOrderSrNo.Value.Trim() != string.Empty)
                        {
                            dtCurrentTableEx.Rows[i - 1]["ORD_SRNO"] = HfOrderSrNo.Value.Trim();
                        }
                        else
                        {
                            dtCurrentTableEx.Rows[i - 1]["ORD_SRNO"] = DBNull.Value;
                        }

                        dtCurrentTableEx.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["ENTRY_TYPE"] = HfEntryType.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["PRODUCT_DESC"] = TxtExProductDesc.Text.Trim();
                        dtCurrentTableEx.Rows[i - 1]["QTY"] = TxtRecQty.Text.Trim();
                        dtCurrentTableEx.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                        dtCurrentTableEx.Rows[i - 1]["DIS_PER"] = TxtDisc.Text.Trim();
                        dtCurrentTableEx.Rows[i - 1]["GST_RATE"] = TxtGstRate.Text.Trim();
                        dtCurrentTableEx.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["CGST_RATE"] = HfCGSTRate.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["CGST_AMT"] = HfCGSTAmount.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["SGST_RATE"] = HfSGSTRate.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["SGST_AMT"] = HfSGSTAmount.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["IGST_RATE"] = HfIGSTRate.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["IGST_AMT"] = HfIGSTAmount.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["AMT"] = HfAmount.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["DIS_AMT"] = HfDisAmount.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["G_AMT"] = HfGrossAmount.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["T_AMT"] = HfTotalAmount.Value.Trim();
                        dtCurrentTableEx.Rows[i - 1]["STATUS"] = HfStatus.Value.Trim();
                        //Status
                        rowIndex++;
                    }
                }
            }

            #endregion
        }

        protected void TxtProductCodeEx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtProductNameEx = (TextBox)row.Cells[2].FindControl("TxtProductNameEx");
                TextBox TxtRateString = (TextBox)row.Cells[7].FindControl("TxtRate");
                TextBox TxtGstRateString = (TextBox)row.Cells[8].FindControl("TxtGstRate");

                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");
                HiddenField HfCGSTRateString = (HiddenField)row.Cells[0].FindControl("HfCGSTRate");
                HiddenField HfSGSTRateString = (HiddenField)row.Cells[0].FindControl("HfSGSTRate");
                HiddenField HfIGSTRateString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");


                DataTable DtProduct = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtProduct);
                    Dv.RowFilter = "PROD_CODE='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfDetailSCode.Value = DtView.Rows[0]["SCODE"].ToString();
                        TxtProductNameEx.Text = DtView.Rows[0]["SNAME"].ToString();

                        FillOnGridExtraStockDetailChanged();

                        if (txt.Text != string.Empty && DdlPartyType.SelectedIndex != 0)
                        {
                            DataTable DsStock = STOCK_MASLogicLayer.STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(HfDetailSCode.Value), DdlPartyType.SelectedValue);
                            if (DsStock.Rows.Count > 0)
                            {
                                TxtRateString.Text = DsStock.Rows[0]["SAL_RATE"].ToString();
                                TxtGstRateString.Text = DsStock.Rows[0]["GST_RATE"].ToString();
                                HfCGSTRateString.Value = DsStock.Rows[0]["CGST_RATE"].ToString();
                                HfSGSTRateString.Value = DsStock.Rows[0]["SGST_RATE"].ToString();
                                HfIGSTRateString.Value = DsStock.Rows[0]["IGST_RATE"].ToString();
                            }
                            else
                            {
                                TxtRateString.Text = "0";
                                TxtGstRateString.Text = "0";
                                HfCGSTRateString.Value = "0";
                                HfSGSTRateString.Value = "0";
                                HfIGSTRateString.Value = "0";


                            }
                        }
                        else
                        {
                            TxtRateString.Text = "0";
                            TxtGstRateString.Text = "0";
                            HfCGSTRateString.Value = "0";
                            HfSGSTRateString.Value = "0";
                            HfIGSTRateString.Value = "0";

                        }


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtProductNameEx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;


                TextBox TxtProductCodeEx = (TextBox)row.Cells[2].FindControl("TxtProductCodeEx");
                TextBox TxtRateString = (TextBox)row.Cells[7].FindControl("TxtRate");
                TextBox TxtGstRateString = (TextBox)row.Cells[8].FindControl("TxtGstRate");

                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");
                HiddenField HfCGSTRateString = (HiddenField)row.Cells[0].FindControl("HfCGSTRate");
                HiddenField HfSGSTRateString = (HiddenField)row.Cells[0].FindControl("HfSGSTRate");
                HiddenField HfIGSTRateString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");


                DataTable DtProduct = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtProduct);
                    Dv.RowFilter = "SNAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfDetailSCode.Value = DtView.Rows[0]["SCODE"].ToString();
                        TxtProductCodeEx.Text = DtView.Rows[0]["PROD_CODE"].ToString();

                        FillOnGridExtraStockDetailChanged();

                        if (txt.Text != string.Empty && DdlPartyType.SelectedIndex != 0)
                        {
                            DataTable DsStock = STOCK_MASLogicLayer.STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(HfDetailSCode.Value), DdlPartyType.SelectedValue);
                            if (DsStock.Rows.Count > 0)
                            {
                                TxtRateString.Text = DsStock.Rows[0]["SAL_RATE"].ToString();
                                TxtGstRateString.Text = DsStock.Rows[0]["GST_RATE"].ToString();
                                HfCGSTRateString.Value = DsStock.Rows[0]["CGST_RATE"].ToString();
                                HfSGSTRateString.Value = DsStock.Rows[0]["SGST_RATE"].ToString();
                                HfIGSTRateString.Value = DsStock.Rows[0]["IGST_RATE"].ToString();
                            }
                            else
                            {
                                TxtRateString.Text = "0";
                                TxtGstRateString.Text = "0";
                                HfCGSTRateString.Value = "0";
                                HfSGSTRateString.Value = "0";
                                HfIGSTRateString.Value = "0";


                            }
                        }
                        else
                        {
                            TxtRateString.Text = "0";
                            TxtGstRateString.Text = "0";
                            HfCGSTRateString.Value = "0";
                            HfSGSTRateString.Value = "0";
                            HfIGSTRateString.Value = "0";

                        }


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvDCDetailsExStock_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvDCDetailsExStock_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GvDCDetailsExStock_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    TextBox TxtProductNameEx = (e.Row.FindControl("TxtProductNameEx") as TextBox);
                    TextBox TxtProductCodeEx = (e.Row.FindControl("TxtProductCodeEx") as TextBox);
                    HiddenField HfDetailSCode = (e.Row.FindControl("HfDetailSCode") as HiddenField);

                    DataTable DtProduct = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();

                    DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);


                    if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != string.Empty)
                    {
                        DataView Dv = new DataView(DtProduct);
                        Dv.RowFilter = "SCODE=" + HfDetailSCode.Value;
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            TxtProductNameEx.Text = DtView.Rows[0]["SNAME"].ToString();
                            TxtProductCodeEx.Text = DtView.Rows[0]["PROD_CODE"].ToString();



                        }
                        else
                        {
                            TxtProductNameEx.Text = string.Empty;
                            TxtProductCodeEx.Text = string.Empty;


                        }
                    }

                }


                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblSumTotalREC_QTY = (Label)e.Row.FindControl("lblSumTotalEXtraREC_QTY");

                    double lblTotRecQty = TotalExtraReceiveQty();
                    lblSumTotalREC_QTY.Text = lblTotRecQty.ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ViewState["CurrentTable"] = null;
            ViewState["CurrentTable_Ex"] = null;
            clear();
            lblmsg.Text = string.Empty;
            UserRights();

            //  ViewState["CurrentTable"] = null;
            //   ViewState["BarcodeTemp"] = null;
        }

        protected void TxtChallanDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string CHALLAN_NO = DC_MASLogicLayer.GetChallanNoDC_MASDetailCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtChallanDate.Text.Trim()).ToString("yyyy-MM-dd"), HfTranType.Value, HfTrnType.Value);
                if (CHALLAN_NO.Length <= 8)
                {
                    TxtChallanNo.Text = CHALLAN_NO;
                }
                else
                {
                    TxtChallanNo.Text = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
                ControllerEnable();
                UserRights();
                Btncalldel.Visible = false;
                BtncallUpd.Visible = true;
                btnSave.Enabled = true;
                btnSave.Visible = true;
                DivEntry.Visible = true;
                DivView.Visible = false;
                BtnAddBarcode.Enabled = true;
                BtnViewBarcode.Enabled = true;
                BtnReturnBarcode.Enabled = true;
                TxtChallanDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                divConfirm.Visible = false;
                divConfirmBy.Visible = false;

                GvDCDetailsExStock.Enabled = true;



                if (Session["WORK_VIEWFLAG"].ToString() == "B")
                {
                    BtnAddBarcode.Visible = true;
                    BtnViewBarcode.Visible = true;
                    BtnReturnBarcode.Visible = true;

                }
                else
                {
                    BtnAddBarcode.Visible = false;
                    BtnViewBarcode.Visible = false;
                    BtnReturnBarcode.Visible = false;
                }

                string CHALLAN_NO = DC_MASLogicLayer.GetChallanNoDC_MASDetailCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtChallanDate.Text.Trim()).ToString("yyyy-MM-dd"), HfTranType.Value, HfTrnType.Value);
                if (CHALLAN_NO.Length <= 8)
                {
                    TxtChallanNo.Text = CHALLAN_NO;
                }
                else
                {
                    TxtChallanNo.Text = string.Empty;
                }



                ViewState["CurrentTable"] = null;


            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region UPDATE DC_MAS_SALES

                #region INSERT DC_MAS MASTER FOR SALES

                DC_MASLogicLayer insert = new DC_MASLogicLayer();
                insert.COMP_CODE = Session["COMP_CODE"].ToString();
                insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.TRAN_TYPE = HfTranType.Value.Trim().ToUpper();
                insert.TRN_TYPE = HfTrnType.Value.Trim().ToUpper();
                insert.ACODE = HfACODE.Value.Trim();
                insert.BCODE = DdlDeliveredBy.SelectedValue.Trim();
                insert.BAMT = "0";
                insert.CHA_NO = TxtChallanNo.Text.Trim().ToUpper();
                insert.CHA_DT = Convert.ToDateTime(TxtChallanDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                insert.SERIALNO = "0";
                if (TxtPONumber.Text == string.Empty)
                {
                    insert.PO_NO = "0";
                }
                else
                {
                    insert.PO_NO = TxtPONumber.Text.Trim().ToUpper();
                }
                if (TxtPODate.Text == string.Empty)
                {
                    insert.PO_DT = "";
                }
                else
                {
                    insert.PO_DT = Convert.ToDateTime(TxtPODate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                insert.VEHICLE_NO = TxtVehclieNo.Text.Trim().ToUpper();
                insert.TCODE = "0";
                insert.TRANSPORT = TxtTransportName.Text.Trim().ToUpper();
                insert.LR_NO = TxtLRNumber.Text.Trim().ToUpper();
                if (TxtLRDate.Text == string.Empty)
                {
                    insert.LR_DATE = "";
                }
                else
                {
                    insert.LR_DATE = Convert.ToDateTime(TxtLRDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                insert.DRIVER_NAME = TxtDriverName.Text.Trim().ToUpper();
                insert.DRIVER_ADD = TxtDriverAddress.Text.Trim().ToUpper();
                insert.MDLNO = TxtMDLNo.Text.Trim().ToUpper();
                insert.MDLSTATE = TxtMDLState.Text.Trim().ToUpper();
                insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                if (TxtFormSrNo.Text == string.Empty)
                {
                    insert.FORM_SRNO = "0";
                }
                else
                {
                    insert.FORM_SRNO = TxtFormSrNo.Text.Trim().ToUpper();
                }

                insert.CHECKPOST_NAME = TxtCheckPost.Text.Trim().ToUpper();
                insert.ENDT = "";
                insert.STATUS = "O";
                insert.REF_TRAN_DATE = "";
                insert.REF_TRAN_NO = "0";
                insert.CLOSE_CHALLAN = "";
                insert.TOT_RET = "0";
                insert.TOT_QTY = "0";
                insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToUpper();
                insert.SALES_TYPE = DdlSalesType.SelectedValue.Trim().ToUpper();
                insert.TERM_CODE = "0";
                insert.LC_TRAN_DATE = "";
                insert.LC_TRAN_NO = "0";
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_DATE = "";
                insert.DEL_CONF_FLAG = "";
                insert.DEL_CONF_DATE = "";

                insert.CHK_FLAG = DdlConfirm.SelectedValue.Trim().ToUpper();
                if (DdlConfirm.SelectedValue == "Y")
                {
                    insert.CHK_USERID = TxtConfirmBy.Text.Trim().ToUpper();
                }
                else
                {
                    insert.CHK_USERID = "";
                }
                if (DdlConfirm.SelectedValue == "Y")
                {
                    insert.CHK_DATE = insert.CHK_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.CHK_DATE = "";
                }

                insert.REC_DT = "";
                insert.INV_TRAN_DATE = "";
                insert.INV_TRAN_NO = "0";
                insert.TOT_CAMT = "0";

                if (HfCRACODE1.Value == "0")
                {
                    insert.CRACODE1 = HfDRACODE1.Value.Trim();
                }
                else
                {
                    insert.CRACODE1 = null;
                }
                if (HfCRACODE2.Value == "0")
                {
                    insert.CRACODE2 = HfDRACODE1.Value.Trim();
                }
                else
                {
                    insert.CRACODE2 = null;
                }
                if (HfCRACODE3.Value == "0")
                {
                    insert.CRACODE3 = HfDRACODE1.Value.Trim();
                }
                else
                {
                    insert.CRACODE3 = null;
                }

                if (HfDRACODE1.Value == "0")
                {
                    insert.DRACODE1 = HfDRACODE1.Value.Trim();
                }
                else
                {
                    insert.DRACODE1 = null;
                }
                if (HfDRACODE2.Value == "0")
                {
                    insert.DRACODE2 = HfDRACODE2.Value.Trim();
                }
                else
                {
                    insert.DRACODE2 = null;
                }

                if (HfDRACODE3.Value == "0")
                {
                    insert.DRACODE3 = HfDRACODE3.Value.Trim();
                }
                else
                {
                    insert.DRACODE3 = null;
                }

                insert.EXPAMT1 = "0";
                insert.EXPAMT2 = "0";
                insert.EXPAMT3 = "0";

                insert.ACC_TRAN_DATE = "";
                insert.ACC_TRAN_NO = "0";
                insert.GROSS_AMT = "0";
                insert.TOT_AMT = "0";
                insert.INV_NO = "0";
                insert.INV_DT = "";
                insert.CONV_RATE = "0";
                insert.EXCISE_TYPE = "";
                if (HfPartRefSrNo.Value == string.Empty)
                {
                    insert.PARTY_REFSRNO = "0";
                }
                else
                {
                    insert.PARTY_REFSRNO = HfPartRefSrNo.Value.Trim();
                }
                insert.UPLOAD_USERID = "";
                insert.UPLOAD_TERMINAL = "";
                insert.UPLOAD_DATE = "";
                insert.UPLOAD_FILENAME = "";
                insert.UPLOAD_FLAG = "";
                insert.DC_TYPE = DdlChallanType.SelectedValue.Trim().ToUpper();

                #endregion

                #region INSERT DC_DET FOR SALES

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);
                int SRNODETAIL = 1;

                foreach (GridViewRow row in GvDCDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfEntryType = row.FindControl("HfEntryType") as HiddenField;
                        HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                        TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                        TextBox TxtHsncode = row.FindControl("TxtHsncode") as TextBox;
                        TextBox TxtOrderQty = row.FindControl("TxtOrderQty") as TextBox;
                        TextBox TxtReceivedQty = row.FindControl("TxtReceivedQty") as TextBox;
                        TextBox TxtReturnQty = row.FindControl("TxtReturnQty") as TextBox;
                        TextBox TxtBalQty = row.FindControl("TxtBalQty") as TextBox;
                        TextBox TxtRecQty = row.FindControl("TxtRecQty") as TextBox;
                        TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                        TextBox TxtDisc = row.FindControl("TxtDisc") as TextBox;
                        TextBox TxtGstRate = row.FindControl("TxtGstRate") as TextBox;

                        HiddenField HfOrderTranDate = row.FindControl("HfOrderTranDate") as HiddenField;
                        HiddenField HfOrderTranNo = row.FindControl("HfOrderTranNo") as HiddenField;
                        HiddenField HfOrderSrNo = row.FindControl("HfOrderSrNo") as HiddenField;

                        HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;
                        HiddenField HfCGSTRate = row.FindControl("HfCGSTRate") as HiddenField;
                        HiddenField HfCGSTAmount = row.FindControl("HfCGSTAmount") as HiddenField;
                        HiddenField HfSGSTRate = row.FindControl("HfSGSTRate") as HiddenField;
                        HiddenField HfSGSTAmount = row.FindControl("HfSGSTAmount") as HiddenField;
                        HiddenField HfIGSTRate = row.FindControl("HfIGSTRate") as HiddenField;
                        HiddenField HfIGSTAmount = row.FindControl("HfIGSTAmount") as HiddenField;

                        HiddenField HfAmount = row.FindControl("HfAmount") as HiddenField;
                        HiddenField HfDisAmount = row.FindControl("HfDisAmount") as HiddenField;
                        HiddenField HfGrossAmount = row.FindControl("HfGrossAmount") as HiddenField;
                        HiddenField HfTotalAmount = row.FindControl("HfTotalAmount") as HiddenField;

                        if (HfDetailSCode.Value != "0")
                        {

                            XmlElement HandleDetail2 = XDoc1.CreateElement("DCDetails");
                            HandleDetail2.SetAttribute("SRNO", SRNODETAIL.ToString());
                            HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                            HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                            HandleDetail2.SetAttribute("ENTRY_TYPE", ("R"));

                            if (HfDetailSCode.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("SCODE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value));
                            }

                            if (TxtRecQty.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("QTY", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("QTY", (TxtRecQty.Text));
                            }

                            if (TxtRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("RATE", (TxtRate.Text));
                            }

                            if (TxtDisc.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("DIS_PER", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("DIS_PER", (TxtDisc.Text));
                            }

                            if (TxtGstRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("GST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("GST_RATE", (TxtGstRate.Text));
                            }

                            if (HfGSTAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("GST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("GST_AMT", (HfGSTAmount.Value));
                            }

                            if (HfCGSTRate.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("CGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("CGST_RATE", (HfCGSTRate.Value));
                            }

                            if (HfCGSTAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("CGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("CGST_AMT", (HfCGSTAmount.Value));
                            }

                            if (HfSGSTRate.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("SGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("SGST_RATE", (HfSGSTRate.Value));
                            }

                            if (HfSGSTAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("SGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("SGST_AMT", (HfSGSTAmount.Value));
                            }


                            if (HfIGSTRate.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("IGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("IGST_RATE", (HfIGSTRate.Value));
                            }

                            if (HfIGSTAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("IGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("IGST_AMT", (HfIGSTAmount.Value));
                            }


                            if (HfAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("AMT", (HfAmount.Value));
                            }

                            if (HfDisAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("DIS_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("DIS_AMT", (HfDisAmount.Value));
                            }

                            if (HfGrossAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("G_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("G_AMT", (HfGrossAmount.Value));
                            }

                            if (HfTotalAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("T_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("T_AMT", (HfTotalAmount.Value));
                            }

                            if (HfOrderTranDate.Value != string.Empty)
                            {

                                HandleDetail2.SetAttribute("ORD_TRAN_DATE", Convert.ToDateTime(HfOrderTranDate.Value).ToString("MM-dd-yyyy"));
                            }

                            if (HfOrderTranNo.Value != string.Empty)
                            {

                                HandleDetail2.SetAttribute("ORD_TRAN_NO", (HfOrderTranNo.Value));
                            }
                            if (HfOrderSrNo.Value != string.Empty)
                            {

                                HandleDetail2.SetAttribute("ORD_SRNO", (HfOrderSrNo.Value));
                            }


                            root1.AppendChild(HandleDetail2);
                            SRNODETAIL++;
                        }
                    }
                }
                #endregion

                #region INSERT EXTRA DC_DETAILS GRID FOR SALES

                XmlDocument XDoc2 = new XmlDocument();
                XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                XDoc2.AppendChild(dec2);// Create the root element
                XmlElement root2 = XDoc2.CreateElement("root");
                XDoc2.AppendChild(root2);

                foreach (GridViewRow row in GvDCDetailsExStock.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfEntryType = row.FindControl("HfEntryType") as HiddenField;
                        HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                        TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                        TextBox TxtExProductDesc = row.FindControl("TxtExProductDesc") as TextBox;
                        TextBox TxtRecQty = row.FindControl("TxtRecQty") as TextBox;
                        TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                        TextBox TxtDisc = row.FindControl("TxtDisc") as TextBox;
                        TextBox TxtGstRate = row.FindControl("TxtGstRate") as TextBox;

                        HiddenField HfOrderTranDate = row.FindControl("HfOrderTranDate") as HiddenField;
                        HiddenField HfOrderTranNo = row.FindControl("HfOrderTranNo") as HiddenField;
                        HiddenField HfOrderSrNo = row.FindControl("HfOrderSrNo") as HiddenField;

                        HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;
                        HiddenField HfCGSTRate = row.FindControl("HfCGSTRate") as HiddenField;
                        HiddenField HfCGSTAmount = row.FindControl("HfCGSTAmount") as HiddenField;
                        HiddenField HfSGSTRate = row.FindControl("HfSGSTRate") as HiddenField;
                        HiddenField HfSGSTAmount = row.FindControl("HfSGSTAmount") as HiddenField;
                        HiddenField HfIGSTRate = row.FindControl("HfIGSTRate") as HiddenField;
                        HiddenField HfIGSTAmount = row.FindControl("HfIGSTAmount") as HiddenField;

                        HiddenField HfAmount = row.FindControl("HfAmount") as HiddenField;
                        HiddenField HfDisAmount = row.FindControl("HfDisAmount") as HiddenField;
                        HiddenField HfGrossAmount = row.FindControl("HfGrossAmount") as HiddenField;
                        HiddenField HfTotalAmount = row.FindControl("HfTotalAmount") as HiddenField;

                        if (HfDetailSCode.Value != "0")
                        {

                            XmlElement HandleDetail2 = XDoc1.CreateElement("DCDetails");
                            HandleDetail2.SetAttribute("SRNO", SRNODETAIL.ToString());
                            HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                            HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                            HandleDetail2.SetAttribute("ENTRY_TYPE", ("E"));

                            if (HfDetailSCode.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("SCODE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value));
                            }

                            HandleDetail2.SetAttribute("PRODUCT_DESC", (TxtExProductDesc.Text));

                            if (TxtRecQty.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("QTY", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("QTY", (TxtRecQty.Text));
                            }

                            if (TxtRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("RATE", (TxtRate.Text));
                            }

                            if (TxtDisc.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("DIS_PER", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("DIS_PER", (TxtDisc.Text));
                            }

                            if (TxtGstRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("GST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("GST_RATE", (TxtGstRate.Text));
                            }

                            if (HfGSTAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("GST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("GST_AMT", (HfGSTAmount.Value));
                            }

                            if (HfCGSTRate.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("CGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("CGST_RATE", (HfCGSTRate.Value));
                            }

                            if (HfCGSTAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("CGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("CGST_AMT", (HfCGSTAmount.Value));
                            }

                            if (HfSGSTRate.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("SGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("SGST_RATE", (HfSGSTRate.Value));
                            }

                            if (HfSGSTAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("SGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("SGST_AMT", (HfSGSTAmount.Value));
                            }


                            if (HfIGSTRate.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("IGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("IGST_RATE", (HfIGSTRate.Value));
                            }

                            if (HfIGSTAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("IGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("IGST_AMT", (HfIGSTAmount.Value));
                            }


                            if (HfAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("AMT", (HfAmount.Value));
                            }

                            if (HfDisAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("DIS_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("DIS_AMT", (HfDisAmount.Value));
                            }

                            if (HfGrossAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("G_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("G_AMT", (HfGrossAmount.Value));
                            }

                            if (HfTotalAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("T_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("T_AMT", (HfTotalAmount.Value));
                            }


                            root1.AppendChild(HandleDetail2);
                            SRNODETAIL++;
                        }
                    }
                }

                #endregion

                #region INSERT BARCODE DETAILS INTO DC_MAS_BARCODE TABLE

                XmlDocument XDoc3 = new XmlDocument();
                XmlDeclaration dec3 = XDoc3.CreateXmlDeclaration("1.0", null, null);
                XDoc3.AppendChild(dec3);// Create the root element
                XmlElement root3 = XDoc3.CreateElement("root");
                XDoc3.AppendChild(root3);
                int SRNOBARCODE = 1;
                if (ViewState["BarcodeTemp"] != null)
                {
                    DataTable DtBarcodeTemp = (DataTable)ViewState["BarcodeTemp"];
                    if (DtBarcodeTemp.Rows.Count > 0)
                    {
                        for (int i = 0; i < DtBarcodeTemp.Rows.Count; i++)
                        {

                            XmlElement HandleDetail4 = XDoc3.CreateElement("BarcodeDetails");


                            if (DtBarcodeTemp.Rows[i]["BARRCODE"].ToString() != string.Empty)
                            {
                                HandleDetail4.SetAttribute("SRNO", SRNOBARCODE.ToString());
                                HandleDetail4.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                HandleDetail4.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                HandleDetail4.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());


                                HandleDetail4.SetAttribute("BAR_TRAN_DATE", Convert.ToDateTime(DtBarcodeTemp.Rows[i]["BAR_TRAN_DATE"].ToString()).ToString("MM-dd-yyyy"));


                                if (DtBarcodeTemp.Rows[i]["BAR_TRAN_NO"].ToString() == string.Empty)
                                {
                                    HandleDetail4.SetAttribute("BAR_TRAN_NO", ("0"));
                                }
                                else
                                {
                                    HandleDetail4.SetAttribute("BAR_TRAN_NO", (DtBarcodeTemp.Rows[i]["BAR_TRAN_NO"].ToString()));
                                }


                                if (DtBarcodeTemp.Rows[i]["BAR_SRNO"].ToString() == string.Empty)
                                {
                                    HandleDetail4.SetAttribute("BAR_SRNO", ("0"));
                                }
                                else
                                {
                                    HandleDetail4.SetAttribute("BAR_SRNO", (DtBarcodeTemp.Rows[i]["BAR_SRNO"].ToString()));
                                }

                                if (DtBarcodeTemp.Rows[i]["QTY"].ToString() == string.Empty)
                                {
                                    HandleDetail4.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail4.SetAttribute("QTY", (DtBarcodeTemp.Rows[i]["QTY"].ToString()));
                                }

                                root3.AppendChild(HandleDetail4);
                                SRNOBARCODE++;
                            }
                        }
                    }
                }
                #endregion



                string str = DC_MASLogicLayer.UpdateDC_SALES_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc3.OuterXml));

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "DC MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillDC_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "DC MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : DC MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }

                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtncallUpd_Click(object sender, EventArgs e)
        {
            try
            {
                if (BtncallUpd.Text == "UPDATE")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel1", "ShowModel1()", true);
                }
                else
                {
                    #region INSERT DC_MAS MASTER FOR SALES

                    DC_MASLogicLayer insert = new DC_MASLogicLayer();
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                    //insert.TRAN_DATE = HfTranDate.Value.Trim();
                    //insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.TRAN_TYPE = HfTranType.Value.Trim().ToUpper();
                    insert.TRN_TYPE = HfTrnType.Value.Trim().ToUpper();
                    insert.ACODE = HfACODE.Value.Trim();
                    insert.BCODE = DdlDeliveredBy.SelectedValue.Trim();
                    insert.BAMT = "0";
                    insert.CHA_NO = TxtChallanNo.Text.Trim().ToUpper();
                    insert.CHA_DT = Convert.ToDateTime(TxtChallanDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    insert.SERIALNO = "0";
                    if (TxtPONumber.Text == string.Empty)
                    {
                        insert.PO_NO = "0";
                    }
                    else
                    {
                        insert.PO_NO = TxtPONumber.Text.Trim().ToUpper();
                    }
                    if (TxtPODate.Text == string.Empty)
                    {
                        insert.PO_DT = "";
                    }
                    else
                    {
                        insert.PO_DT = Convert.ToDateTime(TxtPODate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    insert.VEHICLE_NO = TxtVehclieNo.Text.Trim().ToUpper();
                    insert.TCODE = "0";
                    insert.TRANSPORT = TxtTransportName.Text.Trim().ToUpper();

                    if (TxtLRDate.Text == string.Empty)
                    {
                        insert.LR_DATE = "";
                    }
                    else
                    {
                        insert.LR_DATE = Convert.ToDateTime(TxtLRDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    insert.LR_NO = TxtLRNumber.Text.Trim().ToUpper();

                    insert.DRIVER_NAME = TxtDriverName.Text.Trim().ToUpper();
                    insert.DRIVER_ADD = TxtDriverAddress.Text.Trim().ToUpper();
                    insert.MDLNO = TxtMDLNo.Text.Trim().ToUpper();
                    insert.MDLSTATE = TxtMDLState.Text.Trim().ToUpper();
                    insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                    if (TxtFormSrNo.Text == string.Empty)
                    {
                        insert.FORM_SRNO = "0";
                    }
                    else
                    {
                        insert.FORM_SRNO = TxtFormSrNo.Text.Trim().ToUpper();
                    }

                    insert.CHECKPOST_NAME = TxtCheckPost.Text.Trim().ToUpper();
                    insert.ENDT = "";
                    insert.STATUS = "O";
                    insert.REF_TRAN_DATE = "";
                    insert.REF_TRAN_NO = "0";
                    insert.CLOSE_CHALLAN = "";
                    insert.TOT_RET = "0";
                    insert.TOT_QTY = "0";
                    insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToUpper();
                    insert.SALES_TYPE = DdlSalesType.SelectedValue.Trim().ToUpper();
                    insert.TERM_CODE = "0";
                    insert.LC_TRAN_DATE = "";
                    insert.LC_TRAN_NO = "0";
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_DATE = "";
                    insert.DEL_CONF_FLAG = "";
                    insert.DEL_CONF_DATE = "";

                    insert.CHK_FLAG = DdlConfirm.SelectedValue.Trim().ToUpper();
                    if (DdlConfirm.SelectedValue == "Y")
                    {
                        insert.CHK_USERID = TxtConfirmBy.Text.Trim().ToUpper();
                    }
                    else
                    {
                        insert.CHK_USERID = "";
                    }
                    if (DdlConfirm.SelectedValue == "Y")
                    {
                        insert.CHK_DATE = insert.CHK_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CHK_DATE = "";
                    }

                    insert.REC_DT = "";
                    insert.INV_TRAN_DATE = "";
                    insert.INV_TRAN_NO = "0";
                    insert.TOT_CAMT = "0";

                    if (HfCRACODE1.Value == "0")
                    {
                        insert.CRACODE1 = HfDRACODE1.Value.Trim();
                    }
                    else
                    {
                        insert.CRACODE1 = null;
                    }
                    if (HfCRACODE2.Value == "0")
                    {
                        insert.CRACODE2 = HfDRACODE1.Value.Trim();
                    }
                    else
                    {
                        insert.CRACODE2 = null;
                    }
                    if (HfCRACODE3.Value == "0")
                    {
                        insert.CRACODE3 = HfDRACODE1.Value.Trim();
                    }
                    else
                    {
                        insert.CRACODE3 = null;
                    }

                    if (HfDRACODE1.Value == "0")
                    {
                        insert.DRACODE1 = HfDRACODE1.Value.Trim();
                    }
                    else
                    {
                        insert.DRACODE1 = null;
                    }
                    if (HfDRACODE2.Value == "0")
                    {
                        insert.DRACODE2 = HfDRACODE2.Value.Trim();
                    }
                    else
                    {
                        insert.DRACODE2 = null;
                    }

                    if (HfDRACODE3.Value == "0")
                    {
                        insert.DRACODE3 = HfDRACODE3.Value.Trim();
                    }
                    else
                    {
                        insert.DRACODE3 = null;
                    }

                    insert.EXPAMT1 = "0";
                    insert.EXPAMT2 = "0";
                    insert.EXPAMT3 = "0";

                    insert.ACC_TRAN_DATE = "";
                    insert.ACC_TRAN_NO = "0";
                    insert.GROSS_AMT = "0";
                    insert.TOT_AMT = "0";
                    insert.INV_NO = "0";
                    insert.INV_DT = "";
                    insert.CONV_RATE = "0";
                    insert.EXCISE_TYPE = "";
                    if (HfPartRefSrNo.Value == string.Empty)
                    {
                        insert.PARTY_REFSRNO = "0";
                    }
                    else
                    {
                        insert.PARTY_REFSRNO = HfPartRefSrNo.Value.Trim();
                    }
                    insert.UPLOAD_USERID = "";
                    insert.UPLOAD_TERMINAL = "";
                    insert.UPLOAD_DATE = "";
                    insert.UPLOAD_FILENAME = "";
                    insert.UPLOAD_FLAG = "";
                    insert.DC_TYPE = DdlChallanType.SelectedValue.Trim().ToUpper();

                    #endregion


                    #region INSERT DC_DET FOR SALES

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int SRNODETAIL = 1;
                    foreach (GridViewRow row in GvDCDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfEntryType = row.FindControl("HfEntryType") as HiddenField;
                            HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                            TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                            TextBox TxtHsncode = row.FindControl("TxtHsncode") as TextBox;
                            TextBox TxtOrderQty = row.FindControl("TxtOrderQty") as TextBox;
                            TextBox TxtReceivedQty = row.FindControl("TxtReceivedQty") as TextBox;
                            TextBox TxtReturnQty = row.FindControl("TxtReturnQty") as TextBox;
                            TextBox TxtBalQty = row.FindControl("TxtBalQty") as TextBox;
                            TextBox TxtRecQty = row.FindControl("TxtRecQty") as TextBox;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtDisc = row.FindControl("TxtDisc") as TextBox;
                            TextBox TxtGstRate = row.FindControl("TxtGstRate") as TextBox;

                            HiddenField HfOrderTranDate = row.FindControl("HfOrderTranDate") as HiddenField;
                            HiddenField HfOrderTranNo = row.FindControl("HfOrderTranNo") as HiddenField;
                            HiddenField HfOrderSrNo = row.FindControl("HfOrderSrNo") as HiddenField;

                            HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;
                            HiddenField HfCGSTRate = row.FindControl("HfCGSTRate") as HiddenField;
                            HiddenField HfCGSTAmount = row.FindControl("HfCGSTAmount") as HiddenField;
                            HiddenField HfSGSTRate = row.FindControl("HfSGSTRate") as HiddenField;
                            HiddenField HfSGSTAmount = row.FindControl("HfSGSTAmount") as HiddenField;
                            HiddenField HfIGSTRate = row.FindControl("HfIGSTRate") as HiddenField;
                            HiddenField HfIGSTAmount = row.FindControl("HfIGSTAmount") as HiddenField;

                            HiddenField HfAmount = row.FindControl("HfAmount") as HiddenField;
                            HiddenField HfDisAmount = row.FindControl("HfDisAmount") as HiddenField;
                            HiddenField HfGrossAmount = row.FindControl("HfGrossAmount") as HiddenField;
                            HiddenField HfTotalAmount = row.FindControl("HfTotalAmount") as HiddenField;

                            if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != null)
                            {


                                XmlElement HandleDetail2 = XDoc1.CreateElement("DCDetails");
                                HandleDetail2.SetAttribute("SRNO", SRNODETAIL.ToString());
                                HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());


                                HandleDetail2.SetAttribute("ENTRY_TYPE", ("R"));

                                if (HfDetailSCode.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SCODE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value));
                                }

                                if (TxtRecQty.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("QTY", (TxtRecQty.Text));
                                }

                                if (TxtRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("RATE", (TxtRate.Text));
                                }

                                if (TxtDisc.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DIS_PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("DIS_PER", (TxtDisc.Text));
                                }

                                if (TxtGstRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("GST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("GST_RATE", (TxtGstRate.Text));
                                }

                                if (HfGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("GST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("GST_AMT", (HfGSTAmount.Value));
                                }

                                if (HfCGSTRate.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CGST_RATE", (HfCGSTRate.Value));
                                }

                                if (HfCGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CGST_AMT", (HfCGSTAmount.Value));
                                }

                                if (HfSGSTRate.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SGST_RATE", (HfSGSTRate.Value));
                                }

                                if (HfSGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SGST_AMT", (HfSGSTAmount.Value));
                                }


                                if (HfIGSTRate.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("IGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("IGST_RATE", (HfIGSTRate.Value));
                                }

                                if (HfIGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("IGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("IGST_AMT", (HfIGSTAmount.Value));
                                }


                                if (HfAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("AMT", (HfAmount.Value));
                                }

                                if (HfDisAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DIS_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("DIS_AMT", (HfDisAmount.Value));
                                }

                                if (HfGrossAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("G_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("G_AMT", (HfGrossAmount.Value));
                                }

                                if (HfTotalAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("T_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("T_AMT", (HfTotalAmount.Value));
                                }

                                if (HfOrderTranDate.Value != string.Empty)
                                {

                                    HandleDetail2.SetAttribute("ORD_TRAN_DATE", Convert.ToDateTime(HfOrderTranDate.Value).ToString("MM-dd-yyyy"));
                                }

                                if (HfOrderTranNo.Value != string.Empty)
                                {

                                    HandleDetail2.SetAttribute("ORD_TRAN_NO", (HfOrderTranNo.Value));
                                }
                                if (HfOrderSrNo.Value != string.Empty)
                                {

                                    HandleDetail2.SetAttribute("ORD_SRNO", (HfOrderSrNo.Value));
                                }


                                root1.AppendChild(HandleDetail2);
                                SRNODETAIL++;

                            }
                        }
                    }
                    #endregion

                    #region INSERT EXTRA DC_DETAILS GRID FOR SALES

                    XmlDocument XDoc2 = new XmlDocument();
                    XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                    XDoc2.AppendChild(dec2);// Create the root element
                    XmlElement root2 = XDoc2.CreateElement("root");
                    XDoc2.AppendChild(root2);
                    int SRNOEXTRA = 1;

                    foreach (GridViewRow row in GvDCDetailsExStock.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfEntryType = row.FindControl("HfEntryType") as HiddenField;
                            HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                            TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                            TextBox TxtExProductDesc = row.FindControl("TxtExProductDesc") as TextBox;
                            TextBox TxtRecQty = row.FindControl("TxtRecQty") as TextBox;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtDisc = row.FindControl("TxtDisc") as TextBox;
                            TextBox TxtGstRate = row.FindControl("TxtGstRate") as TextBox;

                            HiddenField HfOrderTranDate = row.FindControl("HfOrderTranDate") as HiddenField;
                            HiddenField HfOrderTranNo = row.FindControl("HfOrderTranNo") as HiddenField;
                            HiddenField HfOrderSrNo = row.FindControl("HfOrderSrNo") as HiddenField;

                            HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;
                            HiddenField HfCGSTRate = row.FindControl("HfCGSTRate") as HiddenField;
                            HiddenField HfCGSTAmount = row.FindControl("HfCGSTAmount") as HiddenField;
                            HiddenField HfSGSTRate = row.FindControl("HfSGSTRate") as HiddenField;
                            HiddenField HfSGSTAmount = row.FindControl("HfSGSTAmount") as HiddenField;
                            HiddenField HfIGSTRate = row.FindControl("HfIGSTRate") as HiddenField;
                            HiddenField HfIGSTAmount = row.FindControl("HfIGSTAmount") as HiddenField;

                            HiddenField HfAmount = row.FindControl("HfAmount") as HiddenField;
                            HiddenField HfDisAmount = row.FindControl("HfDisAmount") as HiddenField;
                            HiddenField HfGrossAmount = row.FindControl("HfGrossAmount") as HiddenField;
                            HiddenField HfTotalAmount = row.FindControl("HfTotalAmount") as HiddenField;

                            if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != null)
                            {
                                XmlElement HandleDetail3 = XDoc2.CreateElement("ExtraDCDetails");

                                HandleDetail3.SetAttribute("SRNO", SRNODETAIL.ToString());
                                HandleDetail3.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                HandleDetail3.SetAttribute("ENTRY_TYPE", ("E"));

                                if (HfDetailSCode.Value != "0")
                                {
                                    HandleDetail3.SetAttribute("SCODE", (HfDetailSCode.Value));
                                }
                                else
                                {

                                    HandleDetail3.SetAttribute("SCODE", ("0"));
                                }

                                HandleDetail3.SetAttribute("PRODUCT_DESC", (TxtExProductDesc.Text));

                                if (TxtRecQty.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("QTY", (TxtRecQty.Text));
                                }

                                if (TxtRate.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("RATE", (TxtRate.Text));
                                }

                                if (TxtDisc.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("DIS_PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("DIS_PER", (TxtDisc.Text));
                                }

                                if (TxtGstRate.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("GST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("GST_RATE", (TxtGstRate.Text));
                                }

                                if (HfGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("GST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("GST_AMT", (HfGSTAmount.Value));
                                }

                                if (HfCGSTRate.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("CGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("CGST_RATE", (HfCGSTRate.Value));
                                }

                                if (HfCGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("CGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("CGST_AMT", (HfCGSTAmount.Value));
                                }

                                if (HfSGSTRate.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("SGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("SGST_RATE", (HfSGSTRate.Value));
                                }

                                if (HfSGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("SGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("SGST_AMT", (HfSGSTAmount.Value));
                                }


                                if (HfIGSTRate.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("IGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("IGST_RATE", (HfIGSTRate.Value));
                                }

                                if (HfIGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("IGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("IGST_AMT", (HfIGSTAmount.Value));
                                }


                                if (HfAmount.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("AMT", (HfAmount.Value));
                                }

                                if (HfDisAmount.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("DIS_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("DIS_AMT", (HfDisAmount.Value));
                                }

                                if (HfGrossAmount.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("G_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("G_AMT", (HfGrossAmount.Value));
                                }

                                if (HfTotalAmount.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("T_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("T_AMT", (HfTotalAmount.Value));
                                }


                                root2.AppendChild(HandleDetail3);
                                SRNOEXTRA++;
                            }
                        }
                    }


                    #endregion

                    #region INSERT BARCODE DETAILS INTO DC_MAS_BARCODE TABLE

                    XmlDocument XDoc3 = new XmlDocument();
                    XmlDeclaration dec3 = XDoc3.CreateXmlDeclaration("1.0", null, null);
                    XDoc3.AppendChild(dec3);// Create the root element
                    XmlElement root3 = XDoc3.CreateElement("root");
                    XDoc3.AppendChild(root3);
                    int SRNOBARCODE = 1;
                    if (ViewState["BarcodeTemp"] != null)
                    {
                        DataTable DtBarcodeTemp = (DataTable)ViewState["BarcodeTemp"];
                        if (DtBarcodeTemp.Rows.Count > 0)
                        {
                            for (int i = 0; i < DtBarcodeTemp.Rows.Count; i++)
                            {

                                XmlElement HandleDetail4 = XDoc3.CreateElement("BarcodeDetails");

                                if (DtBarcodeTemp.Rows[i]["BARRCODE"].ToString() != string.Empty)
                                {
                                    HandleDetail4.SetAttribute("SRNO", SRNOBARCODE.ToString());
                                    HandleDetail4.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                    //    HandleDetail4.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                    //    HandleDetail4.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());


                                    HandleDetail4.SetAttribute("BAR_TRAN_DATE", Convert.ToDateTime(DtBarcodeTemp.Rows[i]["BAR_TRAN_DATE"].ToString()).ToString("MM-dd-yyyy"));


                                    if (DtBarcodeTemp.Rows[i]["BAR_TRAN_NO"].ToString() == string.Empty)
                                    {
                                        HandleDetail4.SetAttribute("BAR_TRAN_NO", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail4.SetAttribute("BAR_TRAN_NO", (DtBarcodeTemp.Rows[i]["BAR_TRAN_NO"].ToString()));
                                    }


                                    if (DtBarcodeTemp.Rows[i]["BAR_SRNO"].ToString() == string.Empty)
                                    {
                                        HandleDetail4.SetAttribute("BAR_SRNO", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail4.SetAttribute("BAR_SRNO", (DtBarcodeTemp.Rows[i]["BAR_SRNO"].ToString()));
                                    }

                                    if (DtBarcodeTemp.Rows[i]["QTY"].ToString() == string.Empty)
                                    {
                                        HandleDetail4.SetAttribute("QTY", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail4.SetAttribute("QTY", (DtBarcodeTemp.Rows[i]["QTY"].ToString()));
                                    }


                                    root3.AppendChild(HandleDetail4);
                                    SRNOBARCODE++;
                                }
                            }
                        }
                    }

                    #endregion


                    string str = DC_MASLogicLayer.InsertDC_SALES_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml), validation.RSC(XDoc3.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"), HfTranType.Value.ToString(), HfTrnType.Value.ToString());

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "DEIVERY CHALLAN MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillDC_MasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "DELIVERY CHALLAN MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : DELIVERY CHALLAN MASTER NOT SAVED";
                        lblmsg.ForeColor = Color.Red;

                    }


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Btncalldel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
        }

        protected void GvDCSalesMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDCSalesMaster.PageIndex = e.NewPageIndex;
            clear();
            FillDC_MasterGrid(Session["COMP_CODE"].ToString());
        }

        protected void GvDCSalesMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //   ViewState["BarcodeTemp"] = null;

                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = DC_MASLogicLayer.GetAllIDWiseDC_SALES_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtBarcode = ds.Tables[2];

                        DataView DvDC = new DataView(DtDetails);
                        DvDC.RowFilter = "ENTRY_TYPE='R'";
                        DataTable dtdc = DvDC.ToTable();

                        DataView DvXC = new DataView(DtDetails);
                        DvXC.RowFilter = "ENTRY_TYPE='E'";
                        DataTable dtxc = DvXC.ToTable();
                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            HfTrnType.Value = dt.Rows[0]["TRN_TYPE"].ToString();
                            TxtChallanNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            TxtChallanDate.Text = Convert.ToDateTime(dt.Rows[0]["CHA_DT"].ToString()).ToString("dd-MM-yyyy");
                            FillDdlAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            HfPartRefSrNo.Value = dt.Rows[0]["PARTY_REFSRNO"].ToString();
                            FillDdlPartModelySrNoOnUpdate(HfPartRefSrNo.Value);
                            TxtPONumber.Text = dt.Rows[0]["PO_NO"].ToString();
                            TxtPODate.Text = dt.Rows[0]["PO_DT"].ToString();
                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtDriverName.Text = dt.Rows[0]["DRIVER_NAME"].ToString();
                            TxtDriverAddress.Text = dt.Rows[0]["DRIVER_ADD"].ToString();
                            TxtMDLNo.Text = dt.Rows[0]["MDLNO"].ToString();
                            TxtMDLState.Text = dt.Rows[0]["MDLSTATE"].ToString();
                            TxtLRNumber.Text = dt.Rows[0]["LR_NO"].ToString();
                            TxtLRDate.Text = dt.Rows[0]["LR_DATE"].ToString();
                            DdlDeliveredBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            DdlConfirm.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            DdlSalesType.SelectedValue = dt.Rows[0]["SALES_TYPE"].ToString();
                            TxtCheckPost.Text = dt.Rows[0]["CHECKPOST_NAME"].ToString();
                            TxtFormSrNo.Text = dt.Rows[0]["FORM_SRNO"].ToString();
                            DdlChallanType.SelectedValue = dt.Rows[0]["DC_TYPE"].ToString();
                            TxtInvoiceNo.Text = dt.Rows[0]["InvoicenNumber"].ToString();
                            if (dt.Rows[0]["InvoicenDate"].ToString() != string.Empty)
                            {
                                TxtInvoiceDate.Text = Convert.ToDateTime(dt.Rows[0]["InvoicenDate"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                TxtInvoiceDate.Text = string.Empty;
                            }

                            if (dtdc.Rows.Count > 0)
                            {
                                ViewState["CurrentTable"] = dtdc;
                                GvDCDetails.DataSource = dtdc;
                                GvDCDetails.DataBind();
                                GvDCDetails.Enabled = false;
                            }


                            if (dtxc.Rows.Count > 0)
                            {
                                ViewState["CurrentTable_Ex"] = dtxc;
                                GvDCDetailsExStock.DataSource = dtxc;
                                GvDCDetailsExStock.DataBind();
                                GvDCDetailsExStock.Enabled = false;
                            }

                            if (DtBarcode.Rows.Count > 0)
                            {
                                ViewState["BarcodeTemp"] = DtBarcode;
                                GvViewBarcode.DataSource = DtBarcode;
                                GvViewBarcode.DataBind();
                            }


                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            Session["TRAN_TYPE"] = HfTranType.Value;
                            Session["TRN_TYPE"] = HfTrnType.Value;

                        }

                        btnSave.Visible = false;
                        btnDelete.Visible = true;
                        Btncalldel.Visible = true;
                        BtncallUpd.Visible = false;
                        BtnAddBarcode.Enabled = false;
                        BtnViewBarcode.Enabled = true;
                        BtnReturnBarcode.Enabled = false;
                        divConfirm.Visible = true;
                        divConfirmBy.Visible = true;
                        ControllerDisable();

                        #endregion
                    }
                }



                if (e.CommandName == "Edita")
                {
                    #region EDIT
                    //  clear();
                    ViewState["CurrentTable"] = null;

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = DC_MASLogicLayer.GetAllIDWiseDC_SALES_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtBarcode = ds.Tables[2];

                        DataView DvDC = new DataView(DtDetails);
                        DvDC.RowFilter = "ENTRY_TYPE='R'";
                        DataTable dtdc = DvDC.ToTable();

                        DataView DvXC = new DataView(DtDetails);
                        DvXC.RowFilter = "ENTRY_TYPE='E'";
                        DataTable dtxc = DvXC.ToTable();
                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            HfTrnType.Value = dt.Rows[0]["TRN_TYPE"].ToString();
                            TxtChallanNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            TxtChallanDate.Text = Convert.ToDateTime(dt.Rows[0]["CHA_DT"].ToString()).ToString("dd-MM-yyyy");
                            FillDdlAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            HfPartRefSrNo.Value = dt.Rows[0]["PARTY_REFSRNO"].ToString();
                            FillDdlPartModelySrNoOnUpdate(HfPartRefSrNo.Value);
                            TxtPONumber.Text = dt.Rows[0]["PO_NO"].ToString();
                            TxtPODate.Text = dt.Rows[0]["PO_DT"].ToString();
                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtDriverName.Text = dt.Rows[0]["DRIVER_NAME"].ToString();
                            TxtDriverAddress.Text = dt.Rows[0]["DRIVER_ADD"].ToString();
                            TxtMDLNo.Text = dt.Rows[0]["MDLNO"].ToString();
                            TxtMDLState.Text = dt.Rows[0]["MDLSTATE"].ToString();
                            TxtLRNumber.Text = dt.Rows[0]["LR_NO"].ToString();
                            TxtLRDate.Text = dt.Rows[0]["LR_DATE"].ToString();
                            DdlDeliveredBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            DdlConfirm.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            DdlSalesType.SelectedValue = dt.Rows[0]["SALES_TYPE"].ToString();
                            TxtCheckPost.Text = dt.Rows[0]["CHECKPOST_NAME"].ToString();
                            TxtFormSrNo.Text = dt.Rows[0]["FORM_SRNO"].ToString();
                            DdlChallanType.SelectedValue = dt.Rows[0]["DC_TYPE"].ToString();
                            TxtInvoiceNo.Text = dt.Rows[0]["InvoicenNumber"].ToString();
                            if (dt.Rows[0]["InvoicenDate"].ToString() != string.Empty)
                            {
                                TxtInvoiceDate.Text = Convert.ToDateTime(dt.Rows[0]["InvoicenDate"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                TxtInvoiceDate.Text = string.Empty;
                            }

                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            Session["TRAN_TYPE"] = HfTranType.Value;
                            Session["TRN_TYPE"] = HfTrnType.Value;


                            if (dtdc.Rows.Count > 0)
                            {
                                #region Assign Table

                                DataTable table = new DataTable();
                                DataRow drm = null;
                                if (ViewState["CurrentTable"] != null)
                                {
                                    table = (DataTable)ViewState["CurrentTable"];
                                }
                                else
                                {
                                    if (table.Rows.Count <= 0)
                                    {
                                        table.Columns.Add("COMP_CODE", typeof(string));
                                        table.Columns.Add("TRAN_DATE", typeof(string));
                                        table.Columns.Add("TRAN_NO", typeof(string));
                                        table.Columns.Add("SRNO", typeof(string));
                                        table.Columns.Add("ORD_TRAN_DATE", typeof(string));
                                        table.Columns.Add("ORD_TRAN_NO", typeof(string));
                                        table.Columns.Add("ORD_SRNO", typeof(string));
                                        table.Columns.Add("SCODE", typeof(string));
                                        table.Columns.Add("HSN_NO", typeof(string));
                                        table.Columns.Add("QTY", typeof(string));
                                        table.Columns.Add("ORD_QTY", typeof(string));
                                        table.Columns.Add("REJ_QTY", typeof(string));
                                        table.Columns.Add("KEPT_QTY", typeof(string));
                                        table.Columns.Add("BAL_QTY", typeof(string));
                                        table.Columns.Add("RATE", typeof(string));
                                        table.Columns.Add("DIS_PER", typeof(string));
                                        table.Columns.Add("GST_RATE", typeof(string));
                                        table.Columns.Add("GST_AMT", typeof(string));
                                        table.Columns.Add("CGST_RATE", typeof(string));
                                        table.Columns.Add("CGST_AMT", typeof(string));
                                        table.Columns.Add("SGST_RATE", typeof(string));
                                        table.Columns.Add("SGST_AMT", typeof(string));
                                        table.Columns.Add("IGST_RATE", typeof(string));
                                        table.Columns.Add("IGST_AMT", typeof(string));
                                        table.Columns.Add("AMT", typeof(string));
                                        table.Columns.Add("DIS_AMT", typeof(string));
                                        table.Columns.Add("G_AMT", typeof(string));
                                        table.Columns.Add("T_AMT", typeof(string));
                                        table.Columns.Add("STATUS", typeof(string));
                                        table.Columns.Add("ENTRY_TYPE", typeof(string));

                                    }
                                }
                                for (int m = 0; m < dtdc.Rows.Count; m++)
                                {
                                    drm = table.NewRow();
                                    drm["COMP_CODE"] = dtdc.Rows[m]["COMP_CODE"].ToString();
                                    drm["TRAN_DATE"] = dtdc.Rows[m]["TRAN_DATE"].ToString();
                                    drm["TRAN_NO"] = dtdc.Rows[m]["TRAN_NO"].ToString();
                                    drm["SRNO"] = dtdc.Rows[m]["SRNO"].ToString();
                                    drm["ORD_TRAN_DATE"] = dtdc.Rows[m]["ORD_TRAN_DATE"].ToString();
                                    drm["ORD_TRAN_NO"] = dtdc.Rows[m]["ORD_TRAN_NO"].ToString();
                                    drm["ORD_SRNO"] = dtdc.Rows[m]["ORD_SRNO"].ToString();
                                    drm["SCODE"] = dtdc.Rows[m]["SCODE"].ToString();
                                    drm["HSN_NO"] = dtdc.Rows[m]["HSN_NO"].ToString();
                                    drm["QTY"] = dtdc.Rows[m]["QTY"].ToString();
                                    drm["ORD_QTY"] = dtdc.Rows[m]["ORD_QTY"].ToString();
                                    drm["REJ_QTY"] = dtdc.Rows[m]["REJ_QTY"].ToString();
                                    drm["KEPT_QTY"] = dtdc.Rows[m]["KEPT_QTY"].ToString();
                                    drm["BAL_QTY"] = dtdc.Rows[m]["BAL_QTY"].ToString();
                                    drm["RATE"] = dtdc.Rows[m]["RATE"].ToString();
                                    drm["DIS_PER"] = dtdc.Rows[m]["DIS_PER"].ToString();
                                    drm["GST_RATE"] = dtdc.Rows[m]["GST_RATE"].ToString();
                                    drm["GST_AMT"] = dtdc.Rows[m]["GST_AMT"].ToString();
                                    drm["CGST_RATE"] = dtdc.Rows[m]["CGST_RATE"].ToString();
                                    drm["CGST_AMT"] = dtdc.Rows[m]["CGST_AMT"].ToString();
                                    drm["SGST_RATE"] = dtdc.Rows[m]["SGST_RATE"].ToString();
                                    drm["SGST_AMT"] = dtdc.Rows[m]["SGST_AMT"].ToString();
                                    drm["IGST_RATE"] = dtdc.Rows[m]["IGST_RATE"].ToString();
                                    drm["IGST_AMT"] = dtdc.Rows[m]["IGST_AMT"].ToString();
                                    drm["AMT"] = dtdc.Rows[m]["AMT"].ToString();
                                    drm["DIS_AMT"] = dtdc.Rows[m]["DIS_AMT"].ToString();
                                    drm["G_AMT"] = dtdc.Rows[m]["G_AMT"].ToString();
                                    drm["T_AMT"] = dtdc.Rows[m]["T_AMT"].ToString();
                                    drm["STATUS"] = dtdc.Rows[m]["STATUS"].ToString();
                                    drm["ENTRY_TYPE"] = dtdc.Rows[m]["ENTRY_TYPE"].ToString();
                                    table.Rows.Add(drm);
                                }


                                #endregion

                                ViewState["CurrentTable"] = table;
                                GvDCDetails.DataSource = dtdc;
                                GvDCDetails.DataBind();
                                GvDCDetails.Enabled = true;


                            }


                            if (dtxc.Rows.Count > 0)
                            {

                                ViewState["CurrentTable_Ex"] = dtxc;
                                GvDCDetailsExStock.DataSource = dtxc;
                                GvDCDetailsExStock.DataBind();
                                GvDCDetailsExStock.Enabled = true;
                            }

                            if (DtBarcode.Rows.Count > 0)
                            {
                                ViewState["BarcodeTemp"] = DtBarcode;
                                GvViewBarcode.DataSource = DtBarcode;
                                GvViewBarcode.DataBind();
                            }

                            BtncallUpd.Text = "UPDATE";

                            #endregion
                        }
                    }

                    #region CHECK UPDATE RIGHTS
                    if (Session["UPDATE"] != null)
                    {
                        if (Session["UPDATE"].ToString() == "Y")
                        {
                            ControllerEnable();
                        }
                        else
                        {
                            ControllerDisable();
                        }
                    }
                    #endregion
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = true;
                    btnSave.Visible = true;
                    UserRights();
                    BtnAddBarcode.Enabled = true;
                    BtnViewBarcode.Enabled = true;
                    BtnReturnBarcode.Enabled = true;
                    divConfirm.Visible = true;
                    divConfirmBy.Visible = true;
                }


                if (e.CommandName == "Viewa")
                {
                    #region  SET TEXT ON VIEW
                    //  clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = DC_MASLogicLayer.GetAllIDWiseDC_SALES_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtBarcode = ds.Tables[2];

                        DataView DvDC = new DataView(DtDetails);
                        DvDC.RowFilter = "ENTRY_TYPE='R'";
                        DataTable dtdc = DvDC.ToTable();

                        DataView DvXC = new DataView(DtDetails);
                        DvXC.RowFilter = "ENTRY_TYPE='E'";
                        DataTable dtxc = DvXC.ToTable();
                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            HfTrnType.Value = dt.Rows[0]["TRN_TYPE"].ToString();
                            TxtChallanNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            TxtChallanDate.Text = Convert.ToDateTime(dt.Rows[0]["CHA_DT"].ToString()).ToString("dd-MM-yyyy");
                            FillDdlAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            HfPartRefSrNo.Value = dt.Rows[0]["PARTY_REFSRNO"].ToString();
                            FillDdlPartModelySrNoOnUpdate(HfPartRefSrNo.Value);
                            TxtPONumber.Text = dt.Rows[0]["PO_NO"].ToString();
                            TxtPODate.Text = dt.Rows[0]["PO_DT"].ToString();
                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtDriverName.Text = dt.Rows[0]["DRIVER_NAME"].ToString();
                            TxtDriverAddress.Text = dt.Rows[0]["DRIVER_ADD"].ToString();
                            TxtMDLNo.Text = dt.Rows[0]["MDLNO"].ToString();
                            TxtMDLState.Text = dt.Rows[0]["MDLSTATE"].ToString();
                            TxtLRNumber.Text = dt.Rows[0]["LR_NO"].ToString();
                            TxtLRDate.Text = dt.Rows[0]["LR_DATE"].ToString();
                            DdlDeliveredBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            DdlConfirm.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            DdlSalesType.SelectedValue = dt.Rows[0]["SALES_TYPE"].ToString();
                            TxtCheckPost.Text = dt.Rows[0]["CHECKPOST_NAME"].ToString();
                            TxtFormSrNo.Text = dt.Rows[0]["FORM_SRNO"].ToString();
                            DdlChallanType.SelectedValue = dt.Rows[0]["DC_TYPE"].ToString();
                            TxtInvoiceNo.Text = dt.Rows[0]["InvoicenNumber"].ToString();
                            if (dt.Rows[0]["InvoicenDate"].ToString() != string.Empty)
                            {
                                TxtInvoiceDate.Text = Convert.ToDateTime(dt.Rows[0]["InvoicenDate"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                TxtInvoiceDate.Text = string.Empty;
                            }


                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            Session["TRAN_TYPE"] = HfTranType.Value;
                            Session["TRN_TYPE"] = HfTrnType.Value;

                            if (dtdc.Rows.Count > 0)
                            {
                                ViewState["CurrentTable"] = dtdc;
                                GvDCDetails.DataSource = dtdc;
                                GvDCDetails.DataBind();
                                GvDCDetails.Enabled = false;
                            }


                            if (dtxc.Rows.Count > 0)
                            {
                                ViewState["CurrentTable_Ex"] = dtxc;
                                GvDCDetailsExStock.DataSource = dtxc;
                                GvDCDetailsExStock.DataBind();
                                GvDCDetailsExStock.Enabled = false;
                            }

                            if (DtBarcode.Rows.Count > 0)
                            {
                                ViewState["BarcodeTemp"] = DtBarcode;
                                GvViewBarcode.DataSource = DtBarcode;
                                GvViewBarcode.DataBind();
                            }

                        }
                    }
                    #endregion
                    ControllerDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    BtnAddBarcode.Enabled = false;
                    BtnViewBarcode.Enabled = true;
                    BtnReturnBarcode.Enabled = false;
                    divConfirm.Visible = true;
                    divConfirmBy.Visible = true;
                    UserRights();

                }
            }
            catch (Exception ex)
            {

                lblmsg.Text = ex.Message.ToString();
            }
        }

        protected void GvDCSalesMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) // Bind nested grid view with parent grid view
                {

                    string TransNo = ((HiddenField)e.Row.FindControl("HfTranNoGrid")).Value;
                    string TransDate = ((HiddenField)e.Row.FindControl("HfTranDateGrid")).Value;
                    GridView childgrd = (GridView)e.Row.FindControl("GvNestedDCDetails");
                    GridView childgrdEx = (GridView)e.Row.FindControl("GvNestedExtraDCDetails");

                    Button btnedit = (e.Row.FindControl("btnEdit") as Button);
                    Button btndelete = (e.Row.FindControl("btnDelete") as Button);
                    Label lblchk = (e.Row.FindControl("lblCheckedConfirm") as Label);

                    HiddenField hfREC_UPD = (e.Row.FindControl("hfREC_UPD") as HiddenField);
                    HiddenField hfREC_DEL = (e.Row.FindControl("hfREC_DEL") as HiddenField);
                    HiddenField hfREC_INS = (e.Row.FindControl("hfREC_INS") as HiddenField);

                    DataTable DtDetails = new DataTable();

                    DtDetails = DC_DETLogicLayer.GetAllWiseID_DC_DET_Detail(TransNo.ToString(), Convert.ToDateTime(TransDate.ToString()));

                    DataView DvDC = new DataView(DtDetails);
                    DvDC.RowFilter = "ENTRY_TYPE='R'";
                    DataTable dtdc = DvDC.ToTable();

                    DataView DvXS = new DataView(DtDetails);
                    DvXS.RowFilter = "ENTRY_TYPE='E'";
                    DataTable dtxc = DvXS.ToTable();

                    childgrd.DataSource = dtdc;
                    childgrd.DataBind();
                    childgrd.Enabled = false;

                    childgrdEx.DataSource = dtxc;
                    childgrdEx.DataBind();
                    childgrdEx.Enabled = false;

                    if (hfREC_INS.Value.ToString() == "Y")
                    {
                        BtnAdd.Enabled = true;
                    }
                    else
                    {
                        BtnAdd.Enabled = false;
                    }

                    if (hfREC_UPD.Value.ToString() == "Y")
                    {


                        if (lblchk.Text == "YES")
                        {
                            if (Session["USERTYPE"].ToString() == "A")
                            {
                                btnedit.Enabled = true;

                            }
                            else
                            {
                                btnedit.Enabled = false;

                            }
                        }
                    }

                    if (hfREC_DEL.Value.ToString() == "Y")
                    {


                        if (lblchk.Text == "YES")
                        {
                            if (Session["USERTYPE"].ToString() == "A")
                            {

                                btndelete.Enabled = true;
                            }
                            else
                            {

                                btndelete.Enabled = false;
                            }
                        }
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE 
                //  string TranDate = HfTranDate.Value;
                if (HfTranNo.Value != string.Empty && HfTranDate.Value != string.Empty)
                {
                    string str = DC_MASLogicLayer.DeleteDC_SALES_MASDetailsByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value.ToString()));
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "Record Deleted Successfully";
                        lblmsg.ForeColor = Color.Green;
                    }
                    else if (str.Contains("Cannot"))
                    {
                        lblmsg.Text = "Cannot Delete This Record It Used by Other Data";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "Error:Delivery Challan Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillDC_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void TxtProductCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtProductName = (TextBox)row.Cells[1].FindControl("TxtProductName");
                TextBox TxtHsn = (TextBox)row.Cells[2].FindControl("TxtHsncode");
                TextBox TxtRateString = (TextBox)row.Cells[8].FindControl("TxtRate");
                TextBox TxtGstRateString = (TextBox)row.Cells[10].FindControl("TxtGstRate");

                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");
                HiddenField HfCGSTRateString = (HiddenField)row.Cells[0].FindControl("HfCGSTRate");
                HiddenField HfSGSTRateString = (HiddenField)row.Cells[0].FindControl("HfSGSTRate");
                HiddenField HfIGSTRateString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");


                DataTable DtProduct = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtProduct);
                    Dv.RowFilter = "PROD_CODE='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfDetailSCode.Value = DtView.Rows[0]["SCODE"].ToString();
                        TxtProductName.Text = DtView.Rows[0]["SNAME"].ToString();
                        TxtHsn.Text = DtView.Rows[0]["HSN_NO"].ToString();
                        // FillOnGridDetailChanged();

                        if (txt.Text != string.Empty && DdlPartyType.SelectedIndex != 0)
                        {
                            DataTable DsStock = STOCK_MASLogicLayer.STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(HfDetailSCode.Value), DdlPartyType.SelectedValue);
                            if (DsStock.Rows.Count > 0)
                            {
                                TxtRateString.Text = DsStock.Rows[0]["SAL_RATE"].ToString();
                                TxtGstRateString.Text = DsStock.Rows[0]["GST_RATE"].ToString();
                                HfCGSTRateString.Value = DsStock.Rows[0]["CGST_RATE"].ToString();
                                HfSGSTRateString.Value = DsStock.Rows[0]["SGST_RATE"].ToString();
                                HfIGSTRateString.Value = DsStock.Rows[0]["IGST_RATE"].ToString();
                            }
                            else
                            {
                                TxtRateString.Text = "0";
                                TxtGstRateString.Text = "0";
                                HfCGSTRateString.Value = "0";
                                HfSGSTRateString.Value = "0";
                                HfIGSTRateString.Value = "0";


                            }
                        }
                        else
                        {
                            TxtRateString.Text = "0";
                            TxtGstRateString.Text = "0";
                            HfCGSTRateString.Value = "0";
                            HfSGSTRateString.Value = "0";
                            HfIGSTRateString.Value = "0";

                        }


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtProductCode = (TextBox)row.Cells[1].FindControl("TxtProductCode");
                TextBox TxtHsn = (TextBox)row.Cells[2].FindControl("TxtHsncode");
                TextBox TxtRateString = (TextBox)row.Cells[8].FindControl("TxtRate");
                TextBox TxtGstRateString = (TextBox)row.Cells[10].FindControl("TxtGstRate");

                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");
                HiddenField HfCGSTRateString = (HiddenField)row.Cells[0].FindControl("HfCGSTRate");
                HiddenField HfSGSTRateString = (HiddenField)row.Cells[0].FindControl("HfSGSTRate");
                HiddenField HfIGSTRateString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");


                DataTable DtProduct = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtProduct);
                    Dv.RowFilter = "SNAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfDetailSCode.Value = DtView.Rows[0]["SCODE"].ToString();
                        TxtProductCode.Text = DtView.Rows[0]["PROD_CODE"].ToString();
                        TxtHsn.Text = DtView.Rows[0]["HSN_NO"].ToString();
                        //   FillOnGridDetailChanged();

                        if (txt.Text != string.Empty && DdlPartyType.SelectedIndex != 0)
                        {
                            DataTable DsStock = STOCK_MASLogicLayer.STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(HfDetailSCode.Value), DdlPartyType.SelectedValue);
                            if (DsStock.Rows.Count > 0)
                            {
                                TxtRateString.Text = DsStock.Rows[0]["SAL_RATE"].ToString();
                                TxtGstRateString.Text = DsStock.Rows[0]["GST_RATE"].ToString();
                                HfCGSTRateString.Value = DsStock.Rows[0]["CGST_RATE"].ToString();
                                HfSGSTRateString.Value = DsStock.Rows[0]["SGST_RATE"].ToString();
                                HfIGSTRateString.Value = DsStock.Rows[0]["IGST_RATE"].ToString();
                            }
                            else
                            {
                                TxtRateString.Text = "0";
                                TxtGstRateString.Text = "0";
                                HfCGSTRateString.Value = "0";
                                HfSGSTRateString.Value = "0";
                                HfIGSTRateString.Value = "0";


                            }
                        }
                        else
                        {
                            TxtRateString.Text = "0";
                            TxtGstRateString.Text = "0";
                            HfCGSTRateString.Value = "0";
                            HfSGSTRateString.Value = "0";
                            HfIGSTRateString.Value = "0";

                        }


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region GST CALCULATION FOR BARCODE DC_DETAILS GRID

        protected void TxtRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;


                TextBox TxtQtyString = (TextBox)row.Cells[7].FindControl("TxtRecQty");
                TextBox TxtDiscRate = (TextBox)row.Cells[7].FindControl("TxtDisc");
                HiddenField HfAmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");
                HiddenField HfGrossAmount = (HiddenField)row.Cells[0].FindControl("HfGrossAmount");

                Label lblSumTotalREC_QTY = (Label)(GvDCDetails.FooterRow.FindControl("lblSumTotalREC_QTY"));


                HiddenField CGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfCGSTRate");
                HiddenField SGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfSGSTRate");
                HiddenField CGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfCGSTAmount");
                HiddenField SGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfSGSTAmount");
                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField T_AMTString = (HiddenField)row.Cells[0].FindControl("HfTotalAmount");

                if (TxtQtyString.Text == string.Empty)
                {
                    TxtQtyString.Text = "0"; ;
                }

                if (txt.Text.Trim() != string.Empty && TxtQtyString.Text.Trim() != string.Empty)
                {
                    HfAmountString.Value = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtQtyString.Text.Trim()));


                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Value = ((Convert.ToDouble(HfAmountString.Value.Trim()) * Convert.ToDouble(CGST_RATEString.Value)) / 100).ToString();
                        SGST_AMTString.Value = ((Convert.ToDouble(HfAmountString.Value.Trim()) * Convert.ToDouble(SGST_RATEString.Value)) / 100).ToString();
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Value.Trim()) + Convert.ToDouble(SGST_AMTString.Value.Trim())).ToString();
                        double d;
                        d = ((Convert.ToDouble(HfAmountString.Value.Trim())) + (Convert.ToDouble(CGST_AMTString.Value)) + (Convert.ToDouble(SGST_AMTString.Value)));
                        T_AMTString.Value = Convert.ToString(d);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        HiddenField IGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");
                        HiddenField IGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfIGSTAmount");

                        IGST_AMTString.Value = ((Convert.ToDouble(HfAmountString.Value.Trim()) * Convert.ToDouble(IGST_RATEString.Value)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Value;
                        T_AMTString.Value = ((Convert.ToDouble(HfAmountString.Value.Trim())) + (Convert.ToDouble(IGST_AMTString.Value))).ToString();
                    }

                    double lblTotRecQty = TotalReceiveQty();
                    lblSumTotalREC_QTY.Text = lblTotRecQty.ToString();

                }

                else
                {
                    HfAmountString.Value = Convert.ToString(Convert.ToDouble(0));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtDisc_TextChanged(object sender, EventArgs e)
        {
            try
            {


                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                if (validation.ispercentage(txt.Text.Trim()))
                {


                    TextBox TxtQtyString = (TextBox)row.Cells[7].FindControl("TxtRecQty");
                    TextBox TxtRateString = (TextBox)row.Cells[8].FindControl("TxtRate");

                    Label lblSumTotalREC_QTY = (Label)(GvDCDetails.FooterRow.FindControl("lblSumTotalREC_QTY"));
                    Label lblSumTotalRate = (Label)(GvDCDetails.FooterRow.FindControl("lblSumTotalRate"));

                    HiddenField HfAmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");
                    HiddenField HfDisAmountString = (HiddenField)row.Cells[0].FindControl("HfDisAmount");
                    HiddenField HfGrossAmount = (HiddenField)row.Cells[0].FindControl("HfGrossAmount");

                    HiddenField CGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfCGSTRate");
                    HiddenField SGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfSGSTRate");
                    HiddenField CGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfCGSTAmount");
                    HiddenField SGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfSGSTAmount");
                    HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                    HiddenField T_AMTString = (HiddenField)row.Cells[0].FindControl("HfTotalAmount");

                    if (TxtQtyString.Text == string.Empty)
                    {
                        TxtQtyString.Text = "0";
                    }
                    if (TxtRateString.Text == string.Empty)
                    {
                        TxtRateString.Text = "0";
                    }

                    if (txt.Text.Trim() != string.Empty && TxtQtyString.Text.Trim() != string.Empty && TxtRateString.Text.Trim() != string.Empty)
                    {

                        double x, amt;

                        HfAmountString.Value = ((Convert.ToDouble(TxtQtyString.Text.Trim()) * Convert.ToDouble(TxtRateString.Text.Trim())).ToString());
                        x = ((Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(HfAmountString.Value.Trim())) / 100);
                        HfDisAmountString.Value = Convert.ToString(x);
                        HfGrossAmount.Value = (Convert.ToDouble(HfAmountString.Value) - x).ToString();
                        amt = Convert.ToDouble(HfGrossAmount.Value);


                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            CGST_AMTString.Value = (((amt) * Convert.ToDouble(CGST_RATEString.Value)) / 100).ToString();
                            SGST_AMTString.Value = (((amt) * Convert.ToDouble(SGST_RATEString.Value)) / 100).ToString();
                            HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Value.Trim()) + Convert.ToDouble(SGST_AMTString.Value.Trim())).ToString();
                            double d;
                            d = ((amt) + (Convert.ToDouble(CGST_AMTString.Value)) + (Convert.ToDouble(SGST_AMTString.Value)));
                            T_AMTString.Value = Convert.ToString(d);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            HiddenField IGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");
                            HiddenField IGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfIGSTAmount");

                            IGST_AMTString.Value = (((amt) * Convert.ToDouble(IGST_RATEString.Value)) / 100).ToString();
                            HfGSTAmount.Value = IGST_AMTString.Value;
                            T_AMTString.Value = ((amt) + Convert.ToDouble(IGST_AMTString.Value)).ToString();
                        }

                        double lblTotRecQty = TotalReceiveQty();
                        lblSumTotalREC_QTY.Text = lblTotRecQty.ToString();
                    }
                    else
                    {
                        HfAmountString.Value = Convert.ToString(Convert.ToDouble(0));


                    }
                    txt.BackColor = Color.White;
                }
                else
                {
                    //Give Javascript Error message
                    txt.Text = "0";
                    txt.BackColor = Color.Red;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Percentage should be between 0 to 100..!!');", true);
                    txt.Focus();
                }

            }

            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        #region GST CALCULATION FOR BARCODE DC_DETAILS EXTRA STOCK GRID


        protected void TxtRecQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;



                Label lblSumTotalREC_QTY = (Label)(GvDCDetailsExStock.FooterRow.FindControl("lblSumTotalEXtraREC_QTY"));
                TextBox TxtRateString = (TextBox)row.Cells[4].FindControl("TxtRate");

                HiddenField HfAmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");

                HiddenField CGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfCGSTRate");
                HiddenField SGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfSGSTRate");
                HiddenField CGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfCGSTAmount");
                HiddenField SGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfSGSTAmount");
                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField T_AMTString = (HiddenField)row.Cells[0].FindControl("HfTotalAmount");

                if (TxtRateString.Text == string.Empty)
                {
                    TxtRateString.Text = "0";
                }

                if (txt.Text.Trim() != string.Empty && TxtRateString.Text.Trim() != string.Empty)
                {
                    HfAmountString.Value = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtRateString.Text.Trim()));


                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Value = ((Convert.ToDouble(HfAmountString.Value.Trim()) * Convert.ToDouble(CGST_RATEString.Value)) / 100).ToString();
                        SGST_AMTString.Value = ((Convert.ToDouble(HfAmountString.Value.Trim()) * Convert.ToDouble(SGST_RATEString.Value)) / 100).ToString();
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Value.Trim()) + Convert.ToDouble(SGST_AMTString.Value.Trim())).ToString();
                        double d;
                        d = ((Convert.ToDouble(HfAmountString.Value.Trim())) + (Convert.ToDouble(CGST_AMTString.Value)) + (Convert.ToDouble(SGST_AMTString.Value)));
                        T_AMTString.Value = Convert.ToString(d);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        HiddenField IGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");
                        HiddenField IGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfIGSTAmount");

                        IGST_AMTString.Value = ((Convert.ToDouble(HfAmountString.Value.Trim()) * Convert.ToDouble(IGST_RATEString.Value)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Value;
                        T_AMTString.Value = ((Convert.ToDouble(HfAmountString.Value.Trim())) + (Convert.ToDouble(IGST_AMTString.Value))).ToString();
                    }

                    double lblTotRecQty = TotalExtraReceiveQty();
                    lblSumTotalREC_QTY.Text = lblTotRecQty.ToString();

                }



                else
                {
                    HfAmountString.Value = Convert.ToString(Convert.ToDouble(0));
                }

            }


            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtRate_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtQtyString = (TextBox)row.Cells[7].FindControl("TxtRecQty");
                HiddenField HfAmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");

                Label lblSumTotalREC_QTY = (Label)(GvDCDetailsExStock.FooterRow.FindControl("lblSumTotalEXtraREC_QTY"));

                HiddenField CGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfCGSTRate");
                HiddenField SGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfSGSTRate");
                HiddenField CGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfCGSTAmount");
                HiddenField SGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfSGSTAmount");
                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField T_AMTString = (HiddenField)row.Cells[0].FindControl("HfTotalAmount");

                if (TxtQtyString.Text == string.Empty)
                {
                    TxtQtyString.Text = "0";
                }

                if (txt.Text.Trim() != string.Empty && TxtQtyString.Text.Trim() != string.Empty)
                {
                    HfAmountString.Value = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtQtyString.Text.Trim()));


                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Value = ((Convert.ToDouble(HfAmountString.Value.Trim()) * Convert.ToDouble(CGST_RATEString.Value)) / 100).ToString();
                        SGST_AMTString.Value = ((Convert.ToDouble(HfAmountString.Value.Trim()) * Convert.ToDouble(SGST_RATEString.Value)) / 100).ToString();
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Value.Trim()) + Convert.ToDouble(SGST_AMTString.Value.Trim())).ToString();
                        double d;
                        d = ((Convert.ToDouble(HfAmountString.Value.Trim())) + (Convert.ToDouble(CGST_AMTString.Value)) + (Convert.ToDouble(SGST_AMTString.Value)));
                        T_AMTString.Value = Convert.ToString(d);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        HiddenField IGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");
                        HiddenField IGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfIGSTAmount");

                        IGST_AMTString.Value = ((Convert.ToDouble(HfAmountString.Value.Trim()) * Convert.ToDouble(IGST_RATEString.Value)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Value;
                        T_AMTString.Value = ((Convert.ToDouble(HfAmountString.Value.Trim())) + (Convert.ToDouble(IGST_AMTString.Value))).ToString();
                    }

                    double lblTotRecQty = TotalExtraReceiveQty();
                    lblSumTotalREC_QTY.Text = lblTotRecQty.ToString();
                }

                else
                {
                    HfAmountString.Value = Convert.ToString(Convert.ToDouble(0));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtDisc_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;


                if (validation.ispercentage(txt.Text.Trim()))
                {

                    TextBox TxtQtyString = (TextBox)row.Cells[7].FindControl("TxtRecQty");
                    TextBox TxtRateString = (TextBox)row.Cells[5].FindControl("TxtRate");

                    Label lblSumTotalREC_QTY = (Label)(GvDCDetailsExStock.FooterRow.FindControl("lblSumTotalEXtraREC_QTY"));

                    HiddenField HfAmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");
                    HiddenField HfDisAmountString = (HiddenField)row.Cells[0].FindControl("HfDisAmount");
                    HiddenField HfGrossAmount = (HiddenField)row.Cells[0].FindControl("HfGrossAmount");

                    HiddenField CGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfCGSTRate");
                    HiddenField SGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfSGSTRate");
                    HiddenField CGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfCGSTAmount");
                    HiddenField SGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfSGSTAmount");
                    HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                    HiddenField T_AMTString = (HiddenField)row.Cells[0].FindControl("HfTotalAmount");

                    if (txt.Text.Trim() != string.Empty && TxtQtyString.Text.Trim() != string.Empty && TxtRateString.Text.Trim() != string.Empty)
                    {

                        double x, amt;

                        HfAmountString.Value = ((Convert.ToDouble(TxtQtyString.Text.Trim()) * Convert.ToDouble(TxtRateString.Text.Trim())).ToString());
                        x = ((Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(HfAmountString.Value.Trim())) / 100);
                        HfDisAmountString.Value = Convert.ToString(x);
                        HfGrossAmount.Value = (Convert.ToDouble(HfAmountString.Value) - x).ToString();
                        amt = Convert.ToDouble(HfGrossAmount.Value);


                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            CGST_AMTString.Value = (((amt) * Convert.ToDouble(CGST_RATEString.Value)) / 100).ToString();
                            SGST_AMTString.Value = (((amt) * Convert.ToDouble(SGST_RATEString.Value)) / 100).ToString();
                            HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Value.Trim()) + Convert.ToDouble(SGST_AMTString.Value.Trim())).ToString();
                            double d;
                            d = ((amt) + (Convert.ToDouble(CGST_AMTString.Value)) + (Convert.ToDouble(SGST_AMTString.Value)));
                            T_AMTString.Value = Convert.ToString(d);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            HiddenField IGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");
                            HiddenField IGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfIGSTAmount");

                            IGST_AMTString.Value = (((amt) * Convert.ToDouble(IGST_RATEString.Value)) / 100).ToString();
                            HfGSTAmount.Value = IGST_AMTString.Value;
                            T_AMTString.Value = ((amt) + Convert.ToDouble(IGST_AMTString.Value)).ToString();
                        }

                        double lblTotRecQty = TotalExtraReceiveQty();
                        lblSumTotalREC_QTY.Text = lblTotRecQty.ToString();

                    }
                    else
                    {
                        HfAmountString.Value = Convert.ToString(Convert.ToDouble(0));


                    }
                    txt.BackColor = Color.White;
                }
                else
                {
                    //Give Javascript Error message
                    txt.Text = "0";
                    txt.BackColor = Color.Red;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Percentage should be between 0 to 100..!!');", true);
                    txt.Focus();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        #endregion

        protected void GvNestedDCDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvNestedExtraDCDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtSearch.Text != string.Empty)
                {
                    //       Session["TxtSearchData"] = TxtSearch.Text.Trim();

                    DataView Dv = new DataView(DtSearch);
                    Dv.RowFilter = "AccountName like '%" + TxtSearch.Text.Trim() + "%' OR Convert(CHA_NO, 'System.String') like '%" + TxtSearch.Text.Trim() + "%' OR PersonName Like '" + TxtSearch.Text.Trim() + "' ";
                    GvDCSalesMaster.DataSource = Dv.ToTable();
                    GvDCSalesMaster.DataBind();
                }
                else
                {
                    GvDCSalesMaster.DataSource = DtSearch;
                    GvDCSalesMaster.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnprintchallan_Click(object sender, EventArgs e)
        {

            //  Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('~/reportviewPages/Delivery_Challan_Print.aspx','_newtab');", true);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../reportviewPages/Delivery_Challan_Print.aspx', '_blank');", true);

            // Response.Redirect("~/reportviewPages/Delivery_Challan_Print.aspx");
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            FillPartyModelSrNo();
        }


    }
}