using MihirValid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;

namespace VeeraApp
{

    public partial class DeliveryChallan : System.Web.UI.Page
    {
        static DataTable DtSearch = new DataTable();
        public static string compcode;
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

                    FillDdlAccountName();
                    FillDCDetailsGrid();
                    SetInitialRow();
                    FillDdlPersonName();
                    CalendarRec_Date.StartDate = Convert.ToDateTime(Session["FIN_YEAR"].ToString());
                    CalendarRec_Date.EndDate = Convert.ToDateTime(Session["FIN_YEAR_END"].ToString());
                    DivCreditACExpence3.Visible = false;

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


        private double TotalGrossAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvDCDetails.Rows.Count; i++)
            {
                string total = (GvDCDetails.Rows[i].FindControl("TxtRate") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

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
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
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

        //public void FillDdlTransporterName()
        //{
        //    try
        //    {

        //        DataTable Dt = new DataTable();
        //        Dt = TRANSPORT_MASLogicLayer.GetAllTRANSPORT_MASDetialsFor_DDL();
        //        DdlTransport.DataSource = Dt;
        //        DdlTransport.DataValueField = "TCODE";
        //        DdlTransport.DataTextField = "TNAME";
        //        DdlTransport.DataBind();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetAccountName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ACCOUNTS where COMP_CODE=@COMP_CODE AND BRANCH_CODE=@BRANCH_CODE  AND ANAME like @name + '%'", con);
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
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select ACODE from ACCOUNTS where ANAME = '" + TxtAccountName.Text + "' and COMP_CODE = " + Session["COMP_CODE"].ToString() , con);
                int x = Convert.ToInt32(cmd.ExecuteScalar());
                if (x == 0)
                {
                    TxtAccountName.BackColor = Color.Red;
                    //GvForPO.DataSource = null;
                    //GvForPO.DataBind();
                }
                else
                {
                    HfACODE.Value = cmd.ExecuteScalar().ToString();
                    TxtAccountName.BackColor = Color.White; con.Close();

                    FillDdlAccountPartyType();
                    FillDdlAccountSalesType();
                    getGSTNo_ByACode();
                    FillPOGridForPopup();
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void FillDdlAccountName()
        {
            //try
            //{
            //    string Comp_Code = Session["COMP_CODE"].ToString();

            //    DataTable Dt = new DataTable();
            //    Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
            //    DdlAccountName.DataSource = Dt;
            //    DdlAccountName.DataValueField = "ACODE";
            //    DdlAccountName.DataTextField = "ANAME";
            //    DdlAccountName.DataBind();

            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        public void FillDdlAccountNameOnUpdate(string Id)
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(Comp_Code);


                //DdlAccountName.DataSource = Dt;
                //DdlAccountName.DataValueField = "ACODE";
                //DdlAccountName.DataTextField = "ANAME";
                //DdlAccountName.DataBind();

                //DdlAccountName.SelectedValue = Id;

                //TxtAccountName.Text = Id;

                if (HfACODE.Value.ToString() != "0")
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "ACODE=" + Id;
                    DataTable DtView = Dv.ToTable();
                    TxtGSTNo.Text = DtView.Rows[0]["GST_NO"].ToString();
                    TxtAccountName.Text = DtView.Rows[0]["ANAME"].ToString();
                    HfACODE.Value = DtView.Rows[0]["ACODE"].ToString();
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

        public void FillDCDetailsGrid()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = DC_DETLogicLayer.GetAllDC_DetailByCompany((Session["COMP_CODE"].ToString()));
                GvDCDetails.DataSource = Dt;
                GvDCDetails.DataBind();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void FillDdlPersonName()
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKER_MASDetialsCompanyWiseFor_DDL(Comp_Code);
                DdlCheckedBy.DataSource = Dt;
                DdlCheckedBy.DataValueField = "BCODE";
                DdlCheckedBy.DataTextField = "BNAME";
                DdlCheckedBy.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void getGSTNo_ByACode()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select GST_NO from ACCOUNTS where ACODE = '" + HfACODE.Value + "'", con);
                TxtGSTNo.Text = cmd.ExecuteScalar().ToString();
                //      TxtGSTNo.Enabled = false;
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlCreditExpenseACName()
        {
            try
            {
                string CompCode = Session["COMP_CODE"].ToString();
                string BranchCode = Session["BRANCH_CODE"].ToString();

                DataTable Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(CompCode);

                DdlCreditExpenseACName1.DataSource = Dt;
                DdlCreditExpenseACName1.DataValueField = "ACODE";
                DdlCreditExpenseACName1.DataTextField = "ANAME";
                DdlCreditExpenseACName1.DataBind();

                DdlCreditExpenseACName2.DataSource = Dt;
                DdlCreditExpenseACName2.DataValueField = "ACODE";
                DdlCreditExpenseACName2.DataTextField = "ANAME";
                DdlCreditExpenseACName2.DataBind();

                DdlCreditExpenseACName3.DataSource = Dt;
                DdlCreditExpenseACName3.DataValueField = "ACODE";
                DdlCreditExpenseACName3.DataTextField = "ANAME";
                DdlCreditExpenseACName3.DataBind();

                DataTable DtSelected = BRANCH_MASLogicLayer.GetIDWiseBRANCH_MASDetialsByCompany(CompCode, BranchCode);
                if (DtSelected.Rows.Count > 0)
                {
                    DdlCreditExpenseACName1.SelectedValue = DtSelected.Rows[0]["CRACODE1"].ToString();
                    DdlCreditExpenseACName2.SelectedValue = DtSelected.Rows[0]["CRACODE2"].ToString();
                    DdlCreditExpenseACName3.SelectedValue = DtSelected.Rows[0]["CRACODE3"].ToString();
                    DdlCreditExpenseACName1.Enabled = false;
                    DdlCreditExpenseACName2.Enabled = false;
                    DdlCreditExpenseACName3.Enabled = false;
                }
                else
                {
                    DdlCreditExpenseACName1.SelectedIndex = 0;
                    DdlCreditExpenseACName2.SelectedIndex = 0;
                    DdlCreditExpenseACName3.SelectedIndex = 0;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillHFDebitExpenseACName()
        {
            try
            {
                string CompCode = Session["COMP_CODE"].ToString();
                string BranchCode = Session["BRANCH_CODE"].ToString();

                DataTable DtSelected = BRANCH_MASLogicLayer.GetIDWiseBRANCH_MASDetialsByCompany(CompCode, BranchCode);
                if (DtSelected.Rows.Count > 0)
                {
                    HfDRACODE1.Value = DtSelected.Rows[0]["DRACODE1"].ToString();
                    HfDRACODE2.Value = DtSelected.Rows[0]["DRACODE2"].ToString();
                    HfDRACODE3.Value = DtSelected.Rows[0]["DRACODE3"].ToString();
                }
                else
                {
                    HfDRACODE1.Value = "0";
                    HfDRACODE2.Value = "0";
                    HfDRACODE3.Value = "0";
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        //protected void DdlAccountName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FillDdlAccountPartyType();
        //    FillDdlAccountSalesType();
        //    getGSTNo_ByACode();
        //}

        public void FillDC_MasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = DC_MASLogicLayer.GetAllDC_MASDetails(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()), HfTranType.Value.ToString(), HfTrnType.Value.ToString());
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvDC_Master.DataSource = Dv.ToTable();
            GvDC_Master.DataBind();

            DtSearch = Dv.ToTable();

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

        public void ControllerEnable()
        {
            TxtSerialNo.Enabled = true;
            TxtTransportName.Enabled = true;
            TxtVehclieNo.Enabled = true;
            TxtInvoiceNo.Enabled = false;
            TxtInvoiceDate.Enabled = false ;
            TxtReceivedDate.Enabled = true;
            TxtGSTNo.Enabled = true;
            TxtLRNumber.Enabled = true;
            TxtLRDate.Enabled = true;
            TxtChallanNo.Enabled = true;
            TxtChallanDate.Enabled = true;
            DdlCheckedBy.Enabled = true;
            TxtAccountName.Enabled = true;
            DdlPartyType.Enabled = true;
            DdlSalesType.Enabled = true;
            DdlConfirm.Enabled = true;
            TxtConfirmDate.Enabled = true;
            TxtConfirmBy.Enabled = true;
            TxtPODate.Enabled = true;
            TxtPONumber.Enabled = true;
            TxtRemarks.Enabled = true;
            DdlCreditExpenseACName1.Enabled = true;
            DdlCreditExpenseACName2.Enabled = true;
            DdlCreditExpenseACName3.Enabled = true;
            TxtChargesAmt1.Enabled = true;
            TxtChargesAmt2.Enabled = true;
            TxtChargesAmt3.Enabled = true;
            TxtChargesTotalAmt.Enabled = true;

            GvDCDetails.Enabled = true;
        }

        public void ControllerDisable()
        {
            TxtSerialNo.Enabled = false;
            TxtTransportName.Enabled = false;
            TxtVehclieNo.Enabled = false;
            TxtInvoiceNo.Enabled = false;
            TxtInvoiceDate.Enabled = false;
            TxtReceivedDate.Enabled = false;
            TxtGSTNo.Enabled = false;
            TxtLRNumber.Enabled = false;
            TxtLRDate.Enabled = false;
            TxtChallanNo.Enabled = false;
            TxtChallanDate.Enabled = false;
            DdlCheckedBy.Enabled = false;
            TxtAccountName.Enabled = false;
            DdlPartyType.Enabled = false;
            DdlSalesType.Enabled = false;
            DdlConfirm.Enabled = false;
            TxtConfirmDate.Enabled = false;
            TxtConfirmBy.Enabled = false;
            TxtPODate.Enabled = false;
            TxtPONumber.Enabled = false;
            TxtRemarks.Enabled = false;
            DdlCreditExpenseACName1.Enabled = false;
            DdlCreditExpenseACName2.Enabled = false;
            DdlCreditExpenseACName3.Enabled = false;
            TxtChargesAmt1.Enabled = false;
            TxtChargesAmt2.Enabled = false;
            TxtChargesAmt3.Enabled = false;
            TxtChargesTotalAmt.Enabled = false;
        }

        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfACODE.Value = string.Empty;
            HfCompCode.Value = string.Empty;
            HfBranchCode.Value = string.Empty;
            HfTranDate.Value = string.Empty;
            HfTranNo.Value = string.Empty;
            //   HfTranType.Value = string.Empty;
            //   HfTrnType.Value = string.Empty;
            TxtSerialNo.Text = string.Empty;
            TxtTransportName.Text = string.Empty;
            TxtVehclieNo.Text = string.Empty;
            TxtInvoiceNo.Text = string.Empty;
            TxtInvoiceDate.Text = string.Empty;
            TxtReceivedDate.Text = string.Empty;
            TxtGSTNo.Text = string.Empty;
            TxtLRNumber.Text = string.Empty;
            TxtLRDate.Text = string.Empty;
            TxtChallanNo.Text = string.Empty;
            TxtChallanDate.Text = string.Empty;
            DdlCheckedBy.SelectedIndex = 0;
            TxtAccountName.Text = string.Empty;
            DdlPartyType.SelectedIndex = 0;
            DdlSalesType.SelectedIndex = 0;
            DdlConfirm.SelectedValue = "N";
            TxtConfirmDate.Text = string.Empty;
            TxtConfirmBy.Text = string.Empty;
            TxtPODate.Text = string.Empty;
            TxtPONumber.Text = string.Empty;
            TxtRemarks.Text = string.Empty;
            //DdlCreditExpenseACName1.SelectedIndex = 0;
            //DdlCreditExpenseACName2.SelectedIndex = 0;
            //DdlCreditExpenseACName3.SelectedIndex = 0;
            TxtChargesAmt1.Text = string.Empty;
            TxtChargesAmt2.Text = string.Empty;
            TxtChargesAmt3.Text = string.Empty;
            TxtChargesTotalAmt.Text = string.Empty;

            ClearSetInitialRow();
            BtncallUpd.Text = "SAVE";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ViewState["CurrentTable"] = null;
            clear();
            lblmsg.Text = string.Empty;
            UserRights();
        }


        protected void TxtReceivedDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string GRN_NO = DC_MASLogicLayer.GetSerialNoDC_MASDetailCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtReceivedDate.Text.Trim()).ToString("yyyy-MM-dd"), HfTranType.Value, HfTrnType.Value);
                if (GRN_NO.Length <= 8)
                {
                    TxtSerialNo.Text = GRN_NO;
                }
                else
                {
                    TxtSerialNo.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
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
            BtnSelectPO.Enabled = true;
            BtnPOProcess.Enabled = true;
            FillDdlCreditExpenseACName();
            FillHFDebitExpenseACName();
           

            TxtReceivedDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            // FillPOGridForPopup();

            //for (int i = 0; i < GvDCDetails.Rows.Count; i++)
            //{
            //    Button btnBarcode= (GvDCDetails.Rows[i].FindControl("btnBarcode") as Button);
            //    btnBarcode.Enabled = false;
            //}
            

           string GRN_NO = DC_MASLogicLayer.GetSerialNoDC_MASDetailCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtReceivedDate.Text.Trim()).ToString("yyyy-MM-dd"), HfTranType.Value, HfTrnType.Value);
            if (GRN_NO.Length <= 8)
            {
                TxtSerialNo.Text = GRN_NO;
            }
            else
            {
                TxtSerialNo.Text = string.Empty;
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
                #region UPDATE DC_MASTER

                #region INSERT DC_MAS FOR PURCHASE

                DC_MASLogicLayer insert = new DC_MASLogicLayer();
                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.BRANCH_CODE = HfBranchCode.Value.Trim();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.TRAN_TYPE = HfTranType.Value.Trim().ToUpper();
                insert.TRN_TYPE = HfTrnType.Value.Trim().ToUpper();
                insert.ACODE = HfACODE.Value.Trim().ToUpper();
                insert.BCODE = DdlCheckedBy.SelectedValue.Trim().ToUpper();
                insert.BAMT = "0";
                insert.CHA_NO = TxtChallanNo.Text.Trim().ToUpper();
                insert.CHA_DT = Convert.ToDateTime(TxtChallanDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                if (TxtSerialNo.Text == string.Empty)
                {
                    insert.SERIALNO = "0";
                }
                else
                {
                    insert.SERIALNO = TxtSerialNo.Text.Trim();
                }

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
                insert.DRIVER_NAME = "";
                insert.DRIVER_ADD = "";
                insert.MDLNO = "";
                insert.MDLSTATE = "";
                insert.REMARK = TxtRemarks.Text.Trim().ToUpper();
                insert.FORM_SRNO = "0";
                insert.CHECKPOST_NAME = "";
                insert.ENDT = "";
                insert.STATUS = "O";

                if (HfRefTranDate.Value == string.Empty)
                {
                    insert.REF_TRAN_DATE = "";
                }
                else
                {
                    insert.REF_TRAN_DATE = Convert.ToDateTime(HfRefTranDate.Value.Trim().ToString()).ToString("MM-dd-yyyy");
                }
                if (HfRefTranNo.Value == string.Empty)
                {
                    insert.REF_TRAN_NO = "0";
                }
                else
                {
                    insert.REF_TRAN_NO = HfRefTranNo.Value.Trim();
                }

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
                    insert.CHK_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.CHK_DATE = "";
                }
                if (DdlConfirm.SelectedValue == "Y")
                {
                    insert.CHK_USERID = TxtConfirmBy.Text.Trim().ToUpper();
                }
                else
                {
                    insert.CHK_USERID = "";
                }
                insert.REC_DT = Convert.ToDateTime(TxtReceivedDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                insert.INV_TRAN_DATE = "";
                insert.INV_TRAN_NO = "0";
                if (TxtChargesTotalAmt.Text == string.Empty)
                {
                    insert.TOT_CAMT = "0";
                }
                else
                {
                    insert.TOT_CAMT = TxtChargesTotalAmt.Text.Trim();
                }


                if (DdlCreditExpenseACName1.SelectedValue != "0")
                {
                    insert.CRACODE1 = DdlCreditExpenseACName1.SelectedValue.Trim();
                }
                else
                {
                    insert.CRACODE1 = null;
                }
                if (DdlCreditExpenseACName2.SelectedValue != "0")
                {
                    insert.CRACODE2 = DdlCreditExpenseACName2.SelectedValue.Trim();
                }
                else
                {
                    insert.CRACODE2 = null;
                }
                if (DdlCreditExpenseACName3.SelectedValue != "0")
                {
                    insert.CRACODE3 = DdlCreditExpenseACName3.SelectedValue.Trim();
                }
                else
                {
                    insert.CRACODE3 = null;
                }

                if (HfDRACODE1.Value != "0")
                {
                    insert.DRACODE1 = HfDRACODE1.Value.Trim();
                }
                else
                {
                    insert.DRACODE1 = null;
                }
                if (HfDRACODE2.Value != "0")
                {
                    insert.DRACODE2 = HfDRACODE2.Value.Trim();
                }
                else
                {
                    insert.DRACODE2 = null;
                }

                if (HfDRACODE3.Value != "0")
                {
                    insert.DRACODE3 = HfDRACODE3.Value.Trim();
                }
                else
                {
                    insert.DRACODE3 = null;
                }


                if (TxtChargesAmt1.Text == string.Empty)
                {
                    insert.EXPAMT1 = "0";
                }
                else
                {
                    insert.EXPAMT1 = TxtChargesAmt1.Text.Trim();
                }

                if (TxtChargesAmt2.Text == string.Empty)
                {
                    insert.EXPAMT2 = "0";
                }
                else
                {
                    insert.EXPAMT2 = TxtChargesAmt2.Text.Trim();
                }

                if (TxtChargesAmt3.Text == string.Empty)
                {
                    insert.EXPAMT3 = "0";
                }
                else
                {
                    insert.EXPAMT3 = TxtChargesAmt1.Text.Trim();
                }

                insert.ACC_TRAN_DATE = "";
                insert.ACC_TRAN_NO = "0";
                insert.GROSS_AMT = "0";
                insert.TOT_AMT = "0";
                insert.INV_NO = "0";
                insert.INV_DT = "";
                insert.CONV_RATE = "0";
                insert.EXCISE_TYPE = "";
                insert.PARTY_REFSRNO = "0";
                insert.UPLOAD_USERID = "";
                insert.UPLOAD_TERMINAL = "";
                insert.UPLOAD_DATE = "";
                insert.UPLOAD_FILENAME = "";
                insert.UPLOAD_FLAG = "";

                #endregion

                #region INSERT DC_DETAILS FOR PURCHASE

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
                        HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                        TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                        // DropDownList DdlProductName = row.FindControl("DdlProductName") as DropDownList;
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

                DataSet str = DC_MASLogicLayer.UpdateDC_MASDetail(insert, validation.RSC(XDoc1.OuterXml));
                string P_Type = "U";

                if (str != null)
                {

                    if (str.Tables.Count > 0)
                    {
                        DataTable DtDetail = str.Tables[0];

                        if (Session["WORK_VIEWFLAG"].ToString() == "B")
                        {
                            for (int d = 0; d < DtDetail.Rows.Count; d++)
                            {

                                string BarCodeStr = DC_MASLogicLayer.GenerateBracodeForPurchaseOrder(P_Type.ToString(), HfCompCode.Value.ToString(), HfBranchCode.Value.ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), TxtSerialNo.Text, DtDetail.Rows[d]["SCODE"].ToString(), DtDetail.Rows[d]["QTY"].ToString(), DtDetail.Rows[d]["RATE"].ToString(), HfTrnType.Value.Trim(), Convert.ToDateTime(DtDetail.Rows[d]["TRAN_DATE"].ToString()), DtDetail.Rows[d]["TRAN_NO"].ToString(), DtDetail.Rows[d]["SRNO"].ToString());
                            }
                        }
                    }

                    lblmsg.Text = "DELIVERY CHALLAN UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillDC_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str != null)
                {
                    lblmsg.Text = "DELIVERY CHALLAN ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : DELIVERY CHALLAN MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }

                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvDC_Master_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvDC_Master.PageIndex = e.NewPageIndex;
                FillDC_MasterGrid(Session["COMP_CODE"].ToString());
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void GvDCDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "ViewBarcode")
                {
                    #region View Barcode

                    //   clear();
                    if (e.CommandArgument.ToString() != string.Empty)
                    {
                        int id = int.Parse(e.CommandArgument.ToString());

                        Control ctrl = e.CommandSource as Control;
                        if (ctrl != null)
                        {
                            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                            HiddenField HfTranDateGrid = (row.FindControl("HfOrdItem_TransDate")) as HiddenField;
                            HiddenField HfTranNoGrid = (row.FindControl("HfOrdItem_TransNo")) as HiddenField;
                            HiddenField HfDetailSCode = (row.FindControl("HfDetailSCode")) as HiddenField;

                            DataTable Dt = BARCODE_MASLogicLayer.GetStockWiseBarcodeDetailsFor_Grid(HfCompCode.Value, HfBranchCode.Value, HfTranNoGrid.Value, Convert.ToDateTime(HfTranDateGrid.Value.ToString()), HfDetailSCode.Value, e.CommandArgument.ToString());

                            GvViewBarcode.DataSource = Dt;
                            GvViewBarcode.DataBind();

                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelViewBarcode", "ShowModelViewBarcode()", true);



                        }
                    }
                    else
                    {
                        
                    }
                        #endregion
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvViewBarcode_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvViewBarcode.PageIndex = e.NewPageIndex;
            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void GvDC_Master_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    //     clear();
                    HfRowCommandFlag.Value = "D";
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataSet ds = DC_MASLogicLayer.GetAllIDWiseDC_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable dtdc = ds.Tables[1];
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
                            TxtSerialNo.Text = dt.Rows[0]["SERIALNO"].ToString();

                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtReceivedDate.Text = Convert.ToDateTime(dt.Rows[0]["REC_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtLRNumber.Text = dt.Rows[0]["LR_NO"].ToString();
                            //  TxtLRDate.Text = Convert.ToDateTime(dt.Rows[0]["LR_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtLRDate.Text = dt.Rows[0]["LR_DATE"].ToString();
                            TxtChallanNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            // TxtChallanDate.Text = Convert.ToDateTime(dt.Rows[0]["CHA_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtChallanDate.Text = dt.Rows[0]["CHA_DT"].ToString();
                            FillDdlPersonName();
                            DdlCheckedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            FillDdlAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            FillDdlAccountPartyType();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            FillDdlAccountSalesType();
                            DdlSalesType.SelectedValue = dt.Rows[0]["SALES_TYPE"].ToString();
                            DdlConfirm.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                      //    TxtConfirmDate.Text = Convert.ToDateTime(dt.Rows[0]["CHK_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtConfirmDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            TxtPONumber.Text = dt.Rows[0]["PO_NO"].ToString();
                            //   TxtPODate.Text = Convert.ToDateTime(dt.Rows[0]["PO_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtPODate.Text = dt.Rows[0]["PO_DT"].ToString();
                            TxtRemarks.Text = dt.Rows[0]["REMARK"].ToString();
                            FillDdlCreditExpenseACName();
                            DdlCreditExpenseACName1.SelectedValue = dt.Rows[0]["CRACODE1"].ToString();
                            FillDdlCreditExpenseACName();
                            DdlCreditExpenseACName2.SelectedValue = dt.Rows[0]["CRACODE2"].ToString();
                            FillDdlCreditExpenseACName();
                            DdlCreditExpenseACName3.SelectedValue = dt.Rows[0]["CRACODE3"].ToString();
                            FillHFDebitExpenseACName();
                            HfDRACODE1.Value = dt.Rows[0]["DRACODE1"].ToString();
                            FillHFDebitExpenseACName();
                            HfDRACODE2.Value = dt.Rows[0]["DRACODE2"].ToString();
                            FillHFDebitExpenseACName();
                            HfDRACODE3.Value = dt.Rows[0]["DRACODE3"].ToString();
                            TxtChargesAmt1.Text = dt.Rows[0]["EXPAMT1"].ToString();
                            TxtChargesAmt2.Text = dt.Rows[0]["EXPAMT2"].ToString();
                            TxtChargesAmt3.Text = dt.Rows[0]["EXPAMT3"].ToString();
                            TxtChargesTotalAmt.Text = dt.Rows[0]["TOT_CAMT"].ToString();
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
                                GvDCDetails.DataSource = dtdc;
                                GvDCDetails.DataBind();
                             //   GvDCDetails.Enabled = false;
                            }

                        


                        }
                    }

                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    Btncalldel.Visible = true;
                    BtncallUpd.Visible = false;
                    BtnSelectPO.Enabled = false;
                    BtnPOProcess.Enabled = false;
                    ControllerDisable();

                    #endregion
                }

                if (e.CommandName == "Edita")
                {
                    #region EDIT
                    //        clear();
                    HfRowCommandFlag.Value = "E";
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataSet ds = DC_MASLogicLayer.GetAllIDWiseDC_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable dtdc = ds.Tables[1];
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
                            TxtSerialNo.Text = dt.Rows[0]["SERIALNO"].ToString();

                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtReceivedDate.Text = Convert.ToDateTime(dt.Rows[0]["REC_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtLRNumber.Text = dt.Rows[0]["LR_NO"].ToString();
                         //  TxtLRDate.Text = Convert.ToDateTime(dt.Rows[0]["LR_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtLRDate.Text = dt.Rows[0]["LR_DATE"].ToString();
                            TxtChallanNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                          // TxtChallanDate.Text = Convert.ToDateTime(dt.Rows[0]["CHA_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtChallanDate.Text = dt.Rows[0]["CHA_DT"].ToString();
                            FillDdlPersonName();
                            DdlCheckedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            FillDdlAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            FillDdlAccountPartyType();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            FillDdlAccountSalesType();
                            DdlSalesType.SelectedValue = dt.Rows[0]["SALES_TYPE"].ToString();
                            DdlConfirm.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            //    TxtConfirmDate.Text = Convert.ToDateTime(dt.Rows[0]["CHK_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtConfirmDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            TxtPONumber.Text = dt.Rows[0]["PO_NO"].ToString();
                            //   TxtPODate.Text = Convert.ToDateTime(dt.Rows[0]["PO_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtPODate.Text = dt.Rows[0]["PO_DT"].ToString();
                            TxtRemarks.Text = dt.Rows[0]["REMARK"].ToString();
                            FillDdlCreditExpenseACName();
                            DdlCreditExpenseACName1.SelectedValue = dt.Rows[0]["CRACODE1"].ToString();
                            FillDdlCreditExpenseACName();
                            DdlCreditExpenseACName2.SelectedValue = dt.Rows[0]["CRACODE2"].ToString();
                            FillDdlCreditExpenseACName();
                            DdlCreditExpenseACName3.SelectedValue = dt.Rows[0]["CRACODE3"].ToString();
                            FillHFDebitExpenseACName();
                            HfDRACODE1.Value = dt.Rows[0]["DRACODE1"].ToString();
                            FillHFDebitExpenseACName();
                            HfDRACODE2.Value = dt.Rows[0]["DRACODE2"].ToString();
                            FillHFDebitExpenseACName();
                            HfDRACODE3.Value = dt.Rows[0]["DRACODE3"].ToString();
                            TxtChargesAmt1.Text = dt.Rows[0]["EXPAMT1"].ToString();
                            TxtChargesAmt2.Text = dt.Rows[0]["EXPAMT2"].ToString();
                            TxtChargesAmt3.Text = dt.Rows[0]["EXPAMT3"].ToString();
                            TxtChargesTotalAmt.Text = dt.Rows[0]["TOT_CAMT"].ToString();
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
                             //   GvDCDetails.Enabled = true;


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
                    BtnSelectPO.Enabled = false;
                    BtnPOProcess.Enabled = false;
                    UserRights();
                }


                if (e.CommandName == "Viewa")
                {
                    HfRowCommandFlag.Value = "V";
                    #region SET TEXT ON VIEW
                    //     clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataSet ds = DC_MASLogicLayer.GetAllIDWiseDC_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable dtdc = ds.Tables[1];
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
                            TxtSerialNo.Text = dt.Rows[0]["SERIALNO"].ToString();

                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtReceivedDate.Text = Convert.ToDateTime(dt.Rows[0]["REC_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtLRNumber.Text = dt.Rows[0]["LR_NO"].ToString();
                            //  TxtLRDate.Text = Convert.ToDateTime(dt.Rows[0]["LR_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtLRDate.Text = dt.Rows[0]["LR_DATE"].ToString();
                            TxtChallanNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            // TxtChallanDate.Text = Convert.ToDateTime(dt.Rows[0]["CHA_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtChallanDate.Text = dt.Rows[0]["CHA_DT"].ToString();
                            FillDdlPersonName();
                            DdlCheckedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            FillDdlAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            FillDdlAccountPartyType();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            FillDdlAccountSalesType();
                            DdlSalesType.SelectedValue = dt.Rows[0]["SALES_TYPE"].ToString();
                            DdlConfirm.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            //    TxtConfirmDate.Text = Convert.ToDateTime(dt.Rows[0]["CHK_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtConfirmDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            TxtPONumber.Text = dt.Rows[0]["PO_NO"].ToString();
                            //   TxtPODate.Text = Convert.ToDateTime(dt.Rows[0]["PO_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtPODate.Text = dt.Rows[0]["PO_DT"].ToString();
                            TxtRemarks.Text = dt.Rows[0]["REMARK"].ToString();
                            FillDdlCreditExpenseACName();
                            DdlCreditExpenseACName1.SelectedValue = dt.Rows[0]["CRACODE1"].ToString();
                            FillDdlCreditExpenseACName();
                            DdlCreditExpenseACName2.SelectedValue = dt.Rows[0]["CRACODE2"].ToString();
                            FillDdlCreditExpenseACName();
                            DdlCreditExpenseACName3.SelectedValue = dt.Rows[0]["CRACODE3"].ToString();
                            FillHFDebitExpenseACName();
                            HfDRACODE1.Value = dt.Rows[0]["DRACODE1"].ToString();
                            FillHFDebitExpenseACName();
                            HfDRACODE2.Value = dt.Rows[0]["DRACODE2"].ToString();
                            FillHFDebitExpenseACName();
                            HfDRACODE3.Value = dt.Rows[0]["DRACODE3"].ToString();
                            TxtChargesAmt1.Text = dt.Rows[0]["EXPAMT1"].ToString();
                            TxtChargesAmt2.Text = dt.Rows[0]["EXPAMT2"].ToString();
                            TxtChargesAmt3.Text = dt.Rows[0]["EXPAMT3"].ToString();
                            TxtChargesTotalAmt.Text = dt.Rows[0]["TOT_CAMT"].ToString();
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
                                GvDCDetails.DataSource = dtdc;
                                GvDCDetails.DataBind();
                             //   GvDCDetails.Enabled = false;
                            }

                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            Session["TRAN_TYPE"] = HfTranType.Value;
                            Session["TRN_TYPE"] = HfTrnType.Value;
                        }
                    }

                    #endregion
                    ControllerDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    BtnSelectPO.Enabled = false;
                    BtnPOProcess.Enabled = false;
                    UserRights();

                }

            }
            catch (Exception ex)
            {

                lblmsg.Text = ex.Message.ToString();
            }
        }

        protected void GvDC_Master_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btnedit = (e.Row.FindControl("btnEdit") as Button);
                    Button btndelete = (e.Row.FindControl("btnDelete") as Button);
                    Label lblchk = (e.Row.FindControl("lblCheckedConfirm") as Label);


                    HiddenField hfREC_UPD = (e.Row.FindControl("hfREC_UPD") as HiddenField);
                    HiddenField hfREC_DEL = (e.Row.FindControl("hfREC_DEL") as HiddenField);
                    HiddenField hfREC_INS = (e.Row.FindControl("hfREC_INS") as HiddenField);


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
            catch (Exception ex)
            {

                Response.AppendToLog(ex.ToString());
            }



            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) // Bind nested grid view with parent grid view
                {

                    string TransNo = ((HiddenField)e.Row.FindControl("HfTranNoGrid")).Value;
                    string TransDate = ((HiddenField)e.Row.FindControl("HfTranDateGrid")).Value;
                    GridView childgrd = (GridView)e.Row.FindControl("GvNestedDCDetails");

                    DataTable Dt = new DataTable();

                    Dt = DC_DETLogicLayer.GetAllWiseID_DC_DET_Detail(TransNo.ToString(), Convert.ToDateTime(TransDate.ToString()));
                    childgrd.DataSource = Dt;
                    childgrd.DataBind();
                    childgrd.Enabled = false;
                }
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
                    #region INSERT DC_MAS FOR PURCHASE

                    DC_MASLogicLayer insert = new DC_MASLogicLayer();
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                    //insert.TRAN_DATE = HfTranDate.Value.Trim();
                    //insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.TRAN_TYPE = HfTranType.Value.Trim().ToUpper();
                    insert.TRN_TYPE = HfTrnType.Value.Trim().ToUpper();
                    insert.ACODE = HfACODE.Value.Trim().ToUpper();
                    insert.BCODE = DdlCheckedBy.SelectedValue.Trim().ToUpper();
                    insert.BAMT = "0";
                    insert.CHA_NO = TxtChallanNo.Text.Trim().ToUpper();
                    insert.CHA_DT = Convert.ToDateTime(TxtChallanDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    if (TxtSerialNo.Text == string.Empty)
                    {
                        insert.SERIALNO = "0";
                    }
                    else
                    {
                        insert.SERIALNO = TxtSerialNo.Text.Trim();
                    }

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
                    insert.DRIVER_NAME = "";
                    insert.DRIVER_ADD = "";
                    insert.MDLNO = "";
                    insert.MDLSTATE = "";
                    insert.REMARK = TxtRemarks.Text.Trim().ToUpper();
                    insert.FORM_SRNO = "0";
                    insert.CHECKPOST_NAME = "";
                    insert.ENDT = "";
                    insert.STATUS = "O";
                    if (HfRefTranDate.Value == string.Empty)
                    {
                        insert.REF_TRAN_DATE = "";
                    }
                    else
                    {
                        insert.REF_TRAN_DATE = Convert.ToDateTime(HfRefTranDate.Value.Trim().ToString()).ToString("MM-dd-yyyy");
                    }
                    if (HfRefTranNo.Value == string.Empty)
                    {
                        insert.REF_TRAN_NO = "0";
                    }
                    else
                    {
                        insert.REF_TRAN_NO = HfRefTranNo.Value.Trim();
                    }
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
                        insert.CHK_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CHK_DATE = "";
                    }
                    if (DdlConfirm.SelectedValue == "Y")
                    {
                        insert.CHK_USERID = TxtConfirmBy.Text.Trim().ToUpper();
                    }
                    else
                    {
                        insert.CHK_USERID = "";
                    }
                    insert.REC_DT = Convert.ToDateTime(TxtReceivedDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    insert.INV_TRAN_DATE = "";
                    insert.INV_TRAN_NO = "0";
                    if (TxtChargesTotalAmt.Text == string.Empty)
                    {
                        insert.TOT_CAMT = "0";
                    }
                    else
                    {
                        insert.TOT_CAMT = TxtChargesTotalAmt.Text.Trim();
                    }

                    if (DdlCreditExpenseACName1.SelectedValue != "0")
                    {
                        insert.CRACODE1 = DdlCreditExpenseACName1.SelectedValue.Trim();
                    }
                    else
                    {
                        insert.CRACODE1 = null;
                    }
                    if (DdlCreditExpenseACName2.SelectedValue != "0")
                    {
                        insert.CRACODE2 = DdlCreditExpenseACName2.SelectedValue.Trim();
                    }
                    else
                    {
                        insert.CRACODE2 = null;
                    }
                    if (DdlCreditExpenseACName3.SelectedValue != "0")
                    {
                        insert.CRACODE3 = DdlCreditExpenseACName3.SelectedValue.Trim();
                    }
                    else
                    {
                        insert.CRACODE3 = null;
                    }

                    if (HfDRACODE1.Value != "0")
                    {
                        insert.DRACODE1 = HfDRACODE1.Value.Trim();
                    }
                    else
                    {
                        insert.DRACODE1 = null;
                    }
                    if (HfDRACODE2.Value != "0")
                    {
                        insert.DRACODE2 = HfDRACODE2.Value.Trim();
                    }
                    else
                    {
                        insert.DRACODE2 = null;
                    }

                    if (HfDRACODE3.Value != "0")
                    {
                        insert.DRACODE3 = HfDRACODE3.Value.Trim();
                    }
                    else
                    {
                        insert.DRACODE3 = null;
                    }


                    if (TxtChargesAmt1.Text == string.Empty)
                    {
                        insert.EXPAMT1 = "0";
                    }
                    else
                    {
                        insert.EXPAMT1 = TxtChargesAmt1.Text.Trim();
                    }

                    if (TxtChargesAmt2.Text == string.Empty)
                    {
                        insert.EXPAMT2 = "0";
                    }
                    else
                    {
                        insert.EXPAMT2 = TxtChargesAmt2.Text.Trim();
                    }

                    if (TxtChargesAmt3.Text == string.Empty)
                    {
                        insert.EXPAMT3 = "0";
                    }
                    else
                    {
                        insert.EXPAMT3 = TxtChargesAmt1.Text.Trim();
                    }

                    insert.ACC_TRAN_DATE = "";
                    insert.ACC_TRAN_NO = "0";
                    insert.GROSS_AMT = "0";
                    insert.TOT_AMT = "0";
                    insert.INV_NO = "0";
                    insert.INV_DT = "";
                    insert.CONV_RATE = "0";
                    insert.EXCISE_TYPE = "";
                    insert.PARTY_REFSRNO = "0";
                    insert.UPLOAD_USERID = "";
                    insert.UPLOAD_TERMINAL = "";
                    insert.UPLOAD_DATE = "";
                    insert.UPLOAD_FILENAME = "";
                    insert.UPLOAD_FLAG = "";

                    #endregion

                    #region INSERT DC_DETAILS FOR PURCHASE

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
                            HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                            TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                            //  DropDownList DdlProductName = row.FindControl("DdlProductName") as DropDownList;
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
                                HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());


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


                    DataSet str = DC_MASLogicLayer.InsertDC_MASDetail(insert, validation.RSC(XDoc1.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"), HfTranType.Value, HfTrnType.Value);


               //     string FlagBarcode = DC_MASLogicLayer.WORK_VIEWFLAG_FROMCOMPANY(Convert.ToInt32(Session["COMP_CODE"]));


                    string P_Type = "I";
                    if (str != null)
                    {
                        if (str.Tables.Count > 0)
                        {
                            DataTable DtDetail = str.Tables[0];
                            if (Session["WORK_VIEWFLAG"].ToString() =="B")
                            {
                                for (int d = 0; d < DtDetail.Rows.Count; d++)
                                {

                                    string BarCodeStr = DC_MASLogicLayer.GenerateBracodeForPurchaseOrder(P_Type.ToString(), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), TxtSerialNo.Text, DtDetail.Rows[d]["SCODE"].ToString(), DtDetail.Rows[d]["QTY"].ToString(), DtDetail.Rows[d]["RATE"].ToString(), HfTrnType.Value.ToString(), Convert.ToDateTime(DtDetail.Rows[d]["TRAN_DATE"].ToString()), DtDetail.Rows[d]["TRAN_NO"].ToString(), DtDetail.Rows[d]["SRNO"].ToString());
                                }
                            }

                        }

                        lblmsg.Text = "DELIVERY CHALLAN SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillDC_MasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str == null)
                    {
                        lblmsg.Text = "DELIVERY CHALLAN ALREADY EXIST.";
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE 
                //  string TranDate = HfTranDate.Value;
                if (HfTranNo.Value != string.Empty && HfTranDate.Value != string.Empty)
                {
                    string str = DC_MASLogicLayer.DeleteDC_MASDetailsByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value.ToString()));
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
                        lblmsg.Text = "Error:Purchase Challan Not Deleted";
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

        protected void GvDCDetails_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GvDCDetails.PageIndex = e.NewPageIndex;
            clear();
            FillDCDetailsGrid();
        }

        protected void GvDCDetails_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField HfDetailSCode = (e.Row.FindControl("HfDetailSCode") as HiddenField);
                    TextBox TxtProductName = (e.Row.FindControl("TxtProductName") as TextBox);
                    TextBox TxtProductCode = (e.Row.FindControl("TxtProductCode") as TextBox);
                    TextBox TxtRate = (e.Row.FindControl("TxtRate") as TextBox);
                    TextBox TxtRecQty = (e.Row.FindControl("TxtRecQty") as TextBox);
                    TextBox TxtGstRate = (e.Row.FindControl("TxtGstRate") as TextBox);
                    TextBox TxtDisc = (e.Row.FindControl("TxtDisc") as TextBox);
                  
                    TextBox TxtHsncode = (TextBox)e.Row.FindControl("TxtHsncode");
                    HiddenField HfStatus = (e.Row.FindControl("HfStatus") as HiddenField);
                    Button btnBarcode = (e.Row.FindControl("btnBarcode") as Button);

                    if(HfRowCommandFlag.Value == "V")
                    {
                        TxtProductCode.Enabled = false;
                        TxtProductName.Enabled = false;
                        TxtRate.Enabled = false;
                        TxtRecQty.Enabled = false;
                        TxtGstRate.Enabled = false;
                        TxtDisc.Enabled = false;
                        TxtHsncode.Enabled = false;
                        btnBarcode.Enabled = true;
                    }
                 

                    if (HfRowCommandFlag.Value == "D")
                    {
                        TxtProductCode.Enabled = false;
                        TxtProductName.Enabled = false;
                        TxtRate.Enabled = false;
                        TxtRecQty.Enabled = false;
                        TxtGstRate.Enabled = false;
                        TxtDisc.Enabled = false;
                        TxtHsncode.Enabled = false;
                        btnBarcode.Enabled = true;
                    }
               
                    if (HfRowCommandFlag.Value == "E")
                    {
                        TxtProductCode.Enabled = true;
                        TxtProductName.Enabled = true;
                        TxtRate.Enabled = true;
                        TxtRecQty.Enabled = true;
                        TxtGstRate.Enabled = true;
                        TxtDisc.Enabled = true;
                        TxtHsncode.Enabled = true;
                        btnBarcode.Enabled = true;
                    }
                 
                    DataTable DtProduct = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();

                    DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);

                    if (!HfStatus.Value.Contains("O"))
                    {
                        //e.Row.Enabled = false;
                        TxtProductName.Enabled = false;
                        TxtProductCode.Enabled = false;
                        TxtHsncode.Enabled = false;
                        TxtRate.Enabled = false;
                        TxtRecQty.Enabled = false;
                        TxtGstRate.Enabled = false;
                        TxtDisc.Enabled = false;

                    }

                    else
                    {
                        btnBarcode.Enabled = true;
                    }

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
                            TxtHsncode.Text = string.Empty;
                        }
                    }


                    if (Session["WORK_VIEWFLAG"].ToString() == "B")
                    {
                        GvDCDetails.Columns[14].Visible = true;                 
                    }
                    else
                    {
                        GvDCDetails.Columns[14].Visible = false;
                      //  e.Row.Cells[14].Visible = false;
                    }

                    }


                    if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblSumTotalREC_QTY = (Label)e.Row.FindControl("lblSumTotalREC_QTY");
                    Label lblSumTotalRate = (Label)e.Row.FindControl("lblSumTotalRate");

                    double lblTotRecQty = TotalReceiveQty();
                    lblSumTotalREC_QTY.Text = lblTotRecQty.ToString();
                }




            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void DdlProductName_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {

                DropDownList ddl = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtHsn = (TextBox)row.Cells[2].FindControl("TxtHsncode");
                TextBox TxtRateString = (TextBox)row.Cells[8].FindControl("TxtRate");
                TextBox TxtGstRateString = (TextBox)row.Cells[10].FindControl("TxtGstRate");

                HiddenField HfCGSTRateString = (HiddenField)row.Cells[0].FindControl("HfCGSTRate");
                HiddenField HfSGSTRateString = (HiddenField)row.Cells[0].FindControl("HfSGSTRate");
                HiddenField HfIGSTRateString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");

                if (ddl.SelectedIndex != 0 && DdlPartyType.SelectedIndex != 0)
                {
                    DataTable DsStock = STOCK_MASLogicLayer.STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(ddl.SelectedValue), DdlPartyType.SelectedValue);
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




                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select HSN_NO from STOCK_MAS where SCODE = '" + ddl.SelectedValue + "'", con);
                TxtHsn.Text = cmd.ExecuteScalar().ToString();
                con.Close();
                TxtHsn.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }


        }


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





            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["ORD_TRAN_DATE"] = string.Empty;
            dr["ORD_TRAN_NO"] = string.Empty;
            dr["ORD_SRNO"] = string.Empty;
            dr["SCODE"] = string.Empty;
            dr["HSN_NO"] = string.Empty;
            dr["QTY"] = string.Empty;
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


            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvDCDetails.DataSource = table;
            GvDCDetails.DataBind();
        }

        private void ClearSetInitialRow()
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


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["ORD_TRAN_DATE"] = string.Empty;
            dr["ORD_TRAN_NO"] = string.Empty;
            dr["ORD_SRNO"] = string.Empty;
            dr["SCODE"] = string.Empty;
            dr["HSN_NO"] = string.Empty;
            dr["QTY"] = string.Empty;
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
            dr["STATUS"] = 'O';


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

        #region CALCULATION FOR GST DC_DET

        protected void TxtRecQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                if (validation.InToNumber(txt.Text.Trim()))
                {

                    Label lblSumTotalREC_QTY = (Label)(GvDCDetails.FooterRow.FindControl("lblSumTotalREC_QTY"));
                    Label lblSumTotalRate = (Label)(GvDCDetails.FooterRow.FindControl("lblSumTotalRate"));

                    TextBox TxtBalQty = (TextBox)row.Cells[7].FindControl("TxtBalQty");
                    TextBox TxtRateString = (TextBox)row.Cells[8].FindControl("TxtRate");
                    HiddenField HfAmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");

                    HiddenField CGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfCGSTRate");
                    HiddenField SGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfSGSTRate");
                    HiddenField CGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfCGSTAmount");
                    HiddenField SGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfSGSTAmount");
                    HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                    HiddenField T_AMTString = (HiddenField)row.Cells[0].FindControl("HfTotalAmount");


                    if (TxtBalQty.Text == string.Empty)
                    {
                        TxtBalQty.Text = "0";
                    }

                    if (Convert.ToDouble(TxtBalQty.Text) >= Convert.ToDouble(txt.Text))
                    {
                        //correct


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Receive Quantity should not be Greater than balance quantity..!!');", true);
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

                        double lblTotRecQty = TotalReceiveQty();
                        lblSumTotalREC_QTY.Text = lblTotRecQty.ToString();

                        //double lblTotAmount = TotalGrossAmount();
                        //lblSumTotalRate.Text = lblTotAmount.ToString();

                    }



                    else
                    {
                        HfAmountString.Value = Convert.ToString(Convert.ToDouble(0));
                    }

                    FillOnGridDetailChanged();


                }
                else
                {
                    //Give Javascript Error message
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Receive Quantity should be Greater than 0 and Must be Number..!!');", true);
                    txt.Focus();


                }
            }

            catch (Exception)
            {

                throw;
            }
        }


        protected void TxtRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtQtyString = (TextBox)row.Cells[7].FindControl("TxtRecQty");
                HiddenField HfAmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");

                Label lblSumTotalREC_QTY = (Label)(GvDCDetails.FooterRow.FindControl("lblSumTotalREC_QTY"));
                Label lblSumTotalRate = (Label)(GvDCDetails.FooterRow.FindControl("lblSumTotalRate"));

                HiddenField CGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfCGSTRate");
                HiddenField SGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfSGSTRate");
                HiddenField CGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfCGSTAmount");
                HiddenField SGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfSGSTAmount");
                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField T_AMTString = (HiddenField)row.Cells[0].FindControl("HfTotalAmount");

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

                    //double lblTotAmount = TotalGrossAmount();
                    //lblSumTotalRate.Text = lblTotAmount.ToString();
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

                        double lblTotAmount = TotalGrossAmount();
                        lblSumTotalRate.Text = lblTotAmount.ToString();
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
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnSelectPO_Click(object sender, EventArgs e)
        {
            try
            {
                if (HfACODE.Value == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SelectionAlert", "SelectionAlert()", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelPurchaseOrder", "ShowModelPurchaseOrder()", true);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnPOProcess_Click(object sender, EventArgs e)
        {
            try
            {
                //SetPreviousData();
                foreach (GridViewRow row in GvDCDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox ChkSelectItem = row.FindControl("ChkSelectItem") as CheckBox;


                        if (ChkSelectItem.Checked != true)
                        {

                            int rowID = row.RowIndex + 1;
                            if (ViewState["CurrentTable"] != null)
                            {
                                DataTable dt = (DataTable)ViewState["CurrentTable"];
                                if (dt.Rows.Count > 1)
                                {

                                    if (row.RowIndex <= dt.Rows.Count - 1)
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
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtChargesAmt1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtChargesAmt1.Text.Trim() != string.Empty && TxtChargesAmt2.Text.Trim() != string.Empty)
                {
                    TxtChargesTotalAmt.Text = Convert.ToString(Convert.ToDouble(TxtChargesAmt1.Text.Trim()) + Convert.ToDouble(TxtChargesAmt2.Text.Trim()));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtChargesAmt2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtChargesAmt1.Text.Trim() != string.Empty && TxtChargesAmt2.Text.Trim() != string.Empty)
                {
                    TxtChargesTotalAmt.Text = Convert.ToString(Convert.ToDouble(TxtChargesAmt1.Text.Trim()) + Convert.ToDouble(TxtChargesAmt2.Text.Trim()));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvForPO_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvForPO.PageIndex = e.NewPageIndex;
            clear();
            FillPOGridForPopup();
        }

        public void FillPOGridForPopup()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = ORDER_MASLogicLayer.GetAllIDWisePO_DetialsForGrid(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), HfACODE.Value);
                GvForPO.DataSource = Dt;
                GvForPO.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvForPO_RowCommand(object sender, GridViewCommandEventArgs e)
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

                        HiddenField HfTranDateGrid = (row.FindControl("HfOrdItem_TransDate")) as HiddenField;

                        DataTable dt = ORDER_ITEMLogicLayer.GetAllWiseID_ORDER_MASDetail(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));


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

                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {


                                dr = table.NewRow();
                                dr["COMP_CODE"] = dt.Rows[i]["COMP_CODE"].ToString();
                                dr["ORD_TRAN_DATE"] = dt.Rows[i]["TRAN_DATE"].ToString();
                                dr["ORD_TRAN_NO"] = dt.Rows[i]["TRAN_NO"].ToString();
                                dr["ORD_SRNO"] = dt.Rows[i]["SRNO"].ToString();
                                dr["SCODE"] = dt.Rows[i]["SCODE"].ToString();
                                dr["HSN_NO"] = dt.Rows[i]["HSN_NO"].ToString();
                                dr["ORD_QTY"] = dt.Rows[i]["QTY"].ToString();
                                dr["REJ_QTY"] = dt.Rows[i]["REJ_QTY"].ToString();
                                dr["KEPT_QTY"] = dt.Rows[i]["KEPT_QTY"].ToString();
                                dr["BAL_QTY"] = dt.Rows[i]["BAL_QTY"].ToString();
                                dr["RATE"] = dt.Rows[i]["RATE"].ToString();
                                dr["DIS_PER"] = dt.Rows[i]["DIS_PER"].ToString();
                                dr["GST_RATE"] = dt.Rows[i]["GST_RATE"].ToString();
                                dr["GST_AMT"] = dt.Rows[i]["GST_AMT"].ToString();
                                dr["CGST_RATE"] = dt.Rows[i]["CGST_RATE"].ToString();
                                dr["CGST_AMT"] = dt.Rows[i]["CGST_AMT"].ToString();
                                dr["SGST_RATE"] = dt.Rows[i]["SGST_RATE"].ToString();
                                dr["SGST_AMT"] = dt.Rows[i]["SGST_AMT"].ToString();
                                dr["IGST_RATE"] = dt.Rows[i]["IGST_RATE"].ToString();
                                dr["IGST_AMT"] = dt.Rows[i]["IGST_AMT"].ToString();
                                dr["AMT"] = dt.Rows[i]["AMT"].ToString();
                                dr["DIS_AMT"] = dt.Rows[i]["DIS_AMT"].ToString();
                                dr["G_AMT"] = dt.Rows[i]["G_AMT"].ToString();
                                dr["T_AMT"] = dt.Rows[i]["T_AMT"].ToString();
                                dr["STATUS"] = dt.Rows[i]["STATUS"].ToString();

                                table.Rows.Add(dr);
                            }

                            ViewState["CurrentTable"] = table;

                            GvDCDetails.DataSource = table;
                            GvDCDetails.DataBind();

                            HfRefTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfRefTranDate.Value = Convert.ToDateTime(dt.Rows[0]["TRAN_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtPODate.Text = Convert.ToDateTime(dt.Rows[0]["ORD_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtPONumber.Text = dt.Rows[0]["ORD_NO"].ToString();

                            DivEntry.Visible = true;
                            DivView.Visible = false;


                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


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
                        FillOnGridDetailChanged();

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
                        FillOnGridDetailChanged();

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

        public void FillOnGridDetailChanged()
        {
            try
            {
                #region Assign To Grid

                int rowIndex = 0;

                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //extract the TextBox values 
                            //TextBox TxtSrNo = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("TxtSrNo");
                            // TextBox TxtProductCode = (TextBox)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("TxtProductCode");

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

                            HiddenField HfDetailSCodeFind = (HiddenField)GvDCDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
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
                            dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCodeFind.Value.Trim();
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

                            rowIndex++;

                        }
                    }
                }

                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtSearch.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtSearch);
                    Dv.RowFilter = "AccountName like '%" + TxtSearch.Text.Trim() + "%' OR Convert(SERIALNO,'System.String') like '%" + TxtSearch.Text.Trim() + "%' OR Convert(CHA_NO, 'System.String') like '%" + TxtSearch.Text.Trim() + "%' OR PersonName Like '" + TxtSearch.Text.Trim() + "' ";
                    GvDC_Master.DataSource = Dv.ToTable();
                    GvDC_Master.DataBind();
                }
                else
                {
                    GvDC_Master.DataSource = DtSearch;
                    GvDC_Master.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            BtnSelectPO.Enabled = false;
        }

      

        protected void btnprintchallan_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>window.open ('~/reportviewPages/GRN_PURCHASE_Print.aspx','_blank');</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../reportviewPages/GRN_PURCHASE_Print.aspx', '_blank');", true);
           // Response.Redirect("~/reportviewPages/GRN_PURCHASE_Print.aspx");
        }

        protected void btnbarcodeprint_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/reportviewPages/GRNBarcodePrint.aspx");            
        }

     
    }
}