using MihirValid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;
namespace VeeraApp.Admin
{
    public partial class SalesReturnDCBill : System.Web.UI.Page
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
         Session["INVTYPE_FLAG"] != null &&
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
                    if (!string.IsNullOrWhiteSpace(Request.QueryString["Tran_Type"]) && !string.IsNullOrWhiteSpace(Request.QueryString["Trn_Type"]))
                    {
                        HfTranType.Value = Request.QueryString["Tran_Type"];
                        HfTrnType.Value = Request.QueryString["Trn_Type"];


                        DivEntry.Visible = false;
                        DivView.Visible = true;

                        SetInitialRow();
                        SetInitialRow_ChargesGrid();

                        CalendarInvoiceDate.StartDate = Convert.ToDateTime(Session["FIN_YEAR"].ToString());
                        CalendarInvoiceDate.EndDate = Convert.ToDateTime(Session["FIN_YEAR_END"].ToString());

                        FillREC_ISS_MasterGrid(Session["COMP_CODE"].ToString());
                    }

                }



            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
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
            ViewState["CurrentTable"] = null;
            ViewState["AddChallanTable"] = null;
            ViewState["CurrentTable_C"] = null;
            ViewState["BarcodeTemp"] = null;
            ViewState["BarcodeTempNew"] = null;

            ViewState["TotalGSTAmount_Deatils"] = null;
            ViewState["TotalCGSTAmount_Deatils"] = null;
            ViewState["TotalSGSTAmount_Deatils"] = null;
            ViewState["TotalIGSTAmount_Deatils"] = null;

            ViewState["TotalGSTAmount_Charges"] = null;
            ViewState["TotalCGSTAmount_Charges"] = null;
            ViewState["TotalSGSTAmount_Charges"] = null;
            ViewState["TotalGSTAmount_Charges"] = null;

            ViewState["TotalStockDetailsAmount_Deatils"] = null;
            ViewState["TotalChargesAmount_Deatils"] = null;
            ViewState["TotalCurrentTable_Details"] = null;
            ViewState["TotalCurrentTable_Charges"] = null;

            DivEntry.Visible = false;
            DivView.Visible = true;

            TxtSupplierNameCredit.Text = string.Empty;
            TxtInvoiceNumber.Text = string.Empty;
            TxtInvoiceDate.Text = string.Empty;
            //TxtReceiveDate.Text = string.Empty;
            //TxtPONo.Text = string.Empty;
            //TxtPODate.Text = string.Empty;
            TxtTransportName.Text = string.Empty;
            TxtVehclieNo.Text = string.Empty;
            TxtLRNo.Text = string.Empty;
            TxtLRDate.Text = string.Empty;
            TxtRemark.Text = string.Empty;
            //TxtInvoiceNo.Text = string.Empty;         
            //TxtDueDays.Text = string.Empty;
            //TxtDueDate.Text = string.Empty;
            //TxtEWayBill.Text = string.Empty;
            TxtDCNo.Text = string.Empty;
            TxtDCDate.Text = string.Empty;
            DdlConfirmFlag.SelectedValue = "N";
            TxtConfirmBy.Text = string.Empty;
            TxtConfirmDate.Text = string.Empty;
            TxtGstNo.Text = string.Empty;
            DdlPartyType.SelectedIndex = 0;
            DdlSalesType.SelectedIndex = 0;
            DdlRegisterType.SelectedIndex = 0;
            DdlTaxCalType.SelectedValue = "E";
            DdlFigureFlag.SelectedIndex = 0;
            TxtROamt.Text = string.Empty;
            TxtNetAmt.Text = string.Empty;

            SetInitialRow();
            SetInitialRow_ChargesGrid();
            BtncallUpd.Text = "SAVE";



        }



        public void ControllerEnable()
        {
            TxtSupplierNameCredit.Enabled = true;
            TxtInvoiceNumber.Enabled = false;
            TxtInvoiceDate.Enabled = true;
            TxtExpenseAccount.Enabled = false;
            // TxtReceiveDate.Enabled = true;
            //TxtPONo.Enabled = true;
            //TxtPODate.Enabled = true;
            TxtTransportName.Enabled = true;
            TxtVehclieNo.Enabled = true;
            TxtLRNo.Enabled = true;
            TxtLRDate.Enabled = true;
            TxtRemark.Enabled = true;
            // TxtInvoiceNo.Enabled = true;          
            //TxtDueDays.Enabled = true;
            //TxtDueDate.Enabled = true;
            //TxtEWayBill.Enabled = true;
            TxtDCNo.Enabled = true;
            TxtDCDate.Enabled = true;
            DdlConfirmFlag.Enabled = true;
            TxtConfirmBy.Enabled = true;
            TxtConfirmDate.Enabled = true;
            TxtGstNo.Enabled = true;
            DdlPartyType.Enabled = true;
            DdlSalesType.Enabled = true;
            DdlRegisterType.Enabled = true;
            DdlTaxCalType.Enabled = true;
            DdlFigureFlag.Enabled = true;
            TxtROamt.Enabled = true;
            TxtNetAmt.Enabled = true;

        }


        public void ControllerDisable()
        {
            TxtSupplierNameCredit.Enabled = false;
            TxtInvoiceNumber.Enabled = false;
            TxtInvoiceDate.Enabled = false;
            TxtExpenseAccount.Enabled = false;
            // TxtReceiveDate.Text = string.Empty;
            //TxtPONo.Enabled = false;
            //TxtPODate.Enabled = false;
            TxtTransportName.Enabled = false;
            TxtVehclieNo.Enabled = false;
            TxtLRNo.Enabled = false;
            TxtLRDate.Enabled = false;
            TxtRemark.Enabled = false;
            //TxtInvoiceNo.Enabled = false;           
            //TxtDueDays.Enabled = false;
            //TxtDueDate.Enabled = false;
            //TxtEWayBill.Enabled = false;
            TxtDCNo.Enabled = false;
            TxtDCDate.Enabled = false;
            DdlConfirmFlag.Enabled = false;
            TxtConfirmBy.Enabled = false;
            TxtConfirmDate.Enabled = false;
            TxtGstNo.Enabled = false;
            DdlPartyType.Enabled = false;
            DdlSalesType.Enabled = false;
            DdlRegisterType.Enabled = false;
            DdlTaxCalType.Enabled = false;
            DdlFigureFlag.Enabled = false;
            TxtROamt.Enabled = false;
            TxtNetAmt.Enabled = false;

        }



        protected void DdlConfirmFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlConfirmFlag.SelectedValue == "Y")
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
            catch (Exception)
            {

                throw;
            }
        }

        public void FillREC_ISS_MasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = REC_ISS_MLogicLayer.GetAllREC_ISS_M_DetailsForTaxInvoice(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()), HfTranType.Value.ToString(), HfTrnType.Value.ToString());
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvTaxInvoiceMaster.DataSource = Dv.ToTable();
            GvTaxInvoiceMaster.DataBind();

            DtSearch = Dv.ToTable();

        }

        #region TOTAL OF FOOTER TEMPLETES FOR STOCK_DETAILS GRID

        private double TotalQuantity()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockRecDetails.Rows.Count; i++)
            {
                string total = (GvStockRecDetails.Rows[i].FindControl("TxtQty") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }

        private double TotalHfAmt()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockRecDetails.Rows.Count; i++)
            {
                string total = (GvStockRecDetails.Rows[i].FindControl("HfAmount") as HiddenField).Value;
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
            for (int i = 0; i < GvStockRecDetails.Rows.Count; i++)
            {
                string total = (GvStockRecDetails.Rows[i].FindControl("HfGrossAmount") as HiddenField).Value;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }

        private double TotalCGSTAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockRecDetails.Rows.Count; i++)
            {
                string total = (GvStockRecDetails.Rows[i].FindControl("TxtCGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalSGSTAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockRecDetails.Rows.Count; i++)
            {
                string total = (GvStockRecDetails.Rows[i].FindControl("TxtSGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalIGSTAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockRecDetails.Rows.Count; i++)
            {
                string total = (GvStockRecDetails.Rows[i].FindControl("TxtIGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockRecDetails.Rows.Count; i++)
            {
                string total = (GvStockRecDetails.Rows[i].FindControl("TxtTotalAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        #endregion


        #region TOTALS OF FOOTER TEMPLETES FOR CHARGES GRID

        private double TotalChargesQuantity()
        {
            double GTotal = 0;
            for (int i = 0; i < GvChagresTranDetails.Rows.Count; i++)
            {
                string total = (GvChagresTranDetails.Rows[i].FindControl("TxtQty") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }


        private double TotalChargesGrossAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvChagresTranDetails.Rows.Count; i++)
            {
                string total = (GvChagresTranDetails.Rows[i].FindControl("TxtChargesAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }


        private double TotalChargesCGSTAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvChagresTranDetails.Rows.Count; i++)
            {
                string total = (GvChagresTranDetails.Rows[i].FindControl("TxtCGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }


        private double TotalChargesSGSTAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvChagresTranDetails.Rows.Count; i++)
            {
                string total = (GvChagresTranDetails.Rows[i].FindControl("TxtSGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }


        private double TotalChargesIGSTAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvChagresTranDetails.Rows.Count; i++)
            {
                string total = (GvChagresTranDetails.Rows[i].FindControl("TxtIGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }


        private double TotalChargesTotalAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvChagresTranDetails.Rows.Count; i++)
            {
                string total = (GvChagresTranDetails.Rows[i].FindControl("TxtTotalAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }

        #endregion


        public void FillNetAmount()
        {
            try
            {

                double GridmergeTotalAmt = Convert.ToDouble(ViewState["TotalCurrentTable_Details"]) + Convert.ToDouble(ViewState["TotalCurrentTable_Charges"]);


                double decimalpoints = Math.Abs(GridmergeTotalAmt - Math.Floor(GridmergeTotalAmt));
                if (decimalpoints > 0.5)
                {
                    double ro = 1 - decimalpoints;

                    TxtROamt.Text = Math.Round(ro, 2).ToString();

                    TxtNetAmt.Text = Convert.ToString(Convert.ToDouble(GridmergeTotalAmt) + ro);
                }

                else
                {

                    double ro = (1 - decimalpoints) - 1;

                    TxtROamt.Text = Math.Round(ro, 2).ToString();

                    TxtNetAmt.Text = Convert.ToString(Math.Floor(GridmergeTotalAmt));
                }
                UpdateTotalAmount.Update();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void TotalAmountCalculationInREC_ISS_M()
        {
            try
            {

                HfTotalSumCGSTAmount.Value = Convert.ToDouble(Convert.ToDouble(ViewState["TotalCGSTAmount_Deatils"]) + Convert.ToDouble(ViewState["TotalCGSTAmount_Charges"])).ToString();
                HfTotalSumSGSTAmount.Value = Convert.ToDouble(Convert.ToDouble(ViewState["TotalSGSTAmount_Deatils"]) + Convert.ToDouble(ViewState["TotalSGSTAmount_Charges"])).ToString();
                HfTotalSumIGSTAmount.Value = Convert.ToDouble(Convert.ToDouble(ViewState["TotalIGSTAmount_Deatils"]) + Convert.ToDouble(ViewState["TotalIGSTAmount_Charges"])).ToString();
                HfTotalSumGSTAmount.Value = Convert.ToDouble(Convert.ToDouble(ViewState["TotalGSTAmount_Deatils"]) + Convert.ToDouble(ViewState["TotalGSTAmount_Charges"])).ToString();
                HfGridsTotalAmount.Value = Convert.ToDouble(Convert.ToDouble(ViewState["TotalCurrentTable_Details"]) + Convert.ToDouble(ViewState["TotalCurrentTable_Charges"])).ToString();
                HfGridGrossAmount.Value = Convert.ToDouble(Convert.ToDouble(ViewState["GrossAmtCurrentTable_Details"]) + Convert.ToDouble(ViewState["TotalChargesAmount_Deatils"])).ToString();
                HfChargesGridTotalAmount.Value = Convert.ToDouble(ViewState["TotalCurrentTable_Charges"]).ToString();
                HfOtherAmount.Value = Convert.ToDouble(Convert.ToDouble(TxtROamt.Text) + Convert.ToDouble(ViewState["TotalCurrentTable_Charges"])).ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }

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

        protected void TxtSupplierNameCredit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select ACODE from ACCOUNTS where ANAME = '" + TxtSupplierNameCredit.Text + "' and COMP_CODE = " + Session["COMP_CODE"].ToString(), con);
                int x = Convert.ToInt32(cmd.ExecuteScalar());
                if (x == 0)
                {
                    TxtSupplierNameCredit.BackColor = Color.Red;

                }
                else
                {
                    HfAODECredit.Value = cmd.ExecuteScalar().ToString();
                    TxtSupplierNameCredit.BackColor = Color.White; con.Close();

                    FillAccountGSTNumber();
                    FillDdlAccountPartyType();
                    FillDdlAccountSalesType();
                    FillDdlAccountRegisterType();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtExpenseAccount_TextChanged(object sender, EventArgs e)
        {

        }

        public void FillAccountGSTNumber()
        {
            try
            {
                string ACODE = HfAODECredit.Value;
                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(ACODE);
                if (Dt.Rows.Count > 0)
                {
                    TxtGstNo.Text = Dt.Rows[0]["GST_NO"].ToString();
                }
                else
                {
                    TxtGstNo.Text = string.Empty;
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
                string ACODE = HfAODECredit.Value;
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
                string ACODE = HfAODECredit.Value;
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


        public void FillDdlAccountRegisterType()
        {
            try
            {
                string ACODE = HfAODECredit.Value;
                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(ACODE);
                if (Dt.Rows.Count > 0)
                {
                    DdlRegisterType.SelectedValue = Dt.Rows[0]["CST_TYPE"].ToString();
                }
                else
                {
                    DdlRegisterType.SelectedValue = "0";
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


        protected void TxtInvoiceDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string INV_Number = REC_ISS_MLogicLayer.GetInvoiceNumber(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), HfTranType.Value.ToString(), HfTrnType.Value.ToString(), Convert.ToDateTime(TxtInvoiceDate.Text.Trim()).ToString("yyyy-MM-dd"));
                if (INV_Number.Length <= 8)
                {
                    TxtInvoiceNumber.Text = INV_Number;
                    TxtInvoiceNumber.Enabled = false;
                }
                else
                {
                    TxtInvoiceNumber.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }






        public void GetAccountCode()
        {
            DataTable DtACODE = new DataTable();
            DtACODE = ACCOUNTS_MASLogicLayer.GetAccountsNameForInvoices(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), HfTranType.Value.ToString(), HfTrnType.Value.ToString());
            HfACODEDebit.Value = DtACODE.Rows[0]["DEBIT"].ToString();
            //HfACODEDebit.Value = DtACODE.Rows[0]["DEBIT"].ToString();

            if (HfACODEDebit.Value != string.Empty)
            {
                DataTable DtAName = new DataTable();
                DtAName = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(HfACODEDebit.Value);
                TxtExpenseAccount.Text = DtAName.Rows[0]["ANAME"].ToString();
                TxtExpenseAccount.Enabled = false;

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
                TxtInvoiceDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                //TxtDueDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                //TxtDCDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                DdlPartyType.SelectedValue = "LOCAL";
                DdlSalesType.SelectedValue = "R";
                DdlRegisterType.SelectedValue = "W";
                DdlTaxCalType.SelectedValue = "E";
                GetAccountCode();

                GvStockRecDetails.Enabled = true;
                GvChagresTranDetails.Enabled = true;

                string INV_Number = REC_ISS_MLogicLayer.GetInvoiceNumber(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), HfTranType.Value.ToString(), HfTrnType.Value.ToString(), Convert.ToDateTime(TxtInvoiceDate.Text.Trim()).ToString("yyyy-MM-dd"));
                if (INV_Number.Length <= 8)
                {
                    TxtInvoiceNumber.Text = INV_Number;
                    TxtInvoiceNumber.Enabled = false;
                }
                else
                {
                    TxtInvoiceNumber.Text = string.Empty;
                }

              //  ViewState["CurrentTable"] = null;

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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            lblmsg.Text = string.Empty;
            UserRights();
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

                    if (Convert.ToDecimal(TxtNetAmt.Text) > 0)
                    {

                        #region INSERT REC_ISS_M  DETAILS

                        REC_ISS_MLogicLayer insert = new REC_ISS_MLogicLayer();

                        insert.COMP_CODE = Session["COMP_CODE"].ToString();
                        //insert.TRAN_DATE = HfTranDate.Value.Trim();
                        //insert.TRAN_NO = HfTranNo.Value.Trim();
                        insert.TRAN_TYPE = HfTranType.Value.Trim().ToUpper();
                        insert.TRN_TYPE = HfTrnType.Value.Trim().ToUpper();
                        insert.TAX_TYPE = "";
                        insert.CRACODE = HfAODECredit.Value.Trim();
                        insert.DRACODE = HfACODEDebit.Value.Trim();
                        insert.SALES_TYPE = DdlSalesType.SelectedValue.Trim().ToUpper();
                        insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToUpper();
                        insert.PARTY_NAME = "";
                        insert.PARTY_ADD = "";
                        insert.BCODE = null;
                        insert.BAMT = null;
                        insert.INV_NO = "";
                        insert.INV_NUMBER = TxtInvoiceNumber.Text.Trim().ToUpper();
                        if (TxtInvoiceDate.Text != string.Empty)
                        {
                            insert.INV_DT = Convert.ToDateTime(TxtInvoiceDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                        }

                        insert.REC_DT = "";
                        insert.DUE_DAYS = null;
                        insert.DUE_DATE = "";
                        insert.CHA_NO = TxtDCNo.Text.Trim().ToUpper();
                        if (TxtDCDate.Text != string.Empty)
                        {
                            insert.CHA_DT = Convert.ToDateTime(TxtDCDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                        }
                        insert.PO_NO = null;
                        insert.PO_DT = "";
                        insert.VEHICLE_NO = TxtVehclieNo.Text.Trim().ToUpper();
                        insert.GROSS_AMT = HfGridGrossAmount.Value.Trim();
                        insert.RO_AMT = TxtROamt.Text.Trim();
                        insert.NET_AMT = TxtNetAmt.Text.Trim();
                        insert.PAID_AMT = null;
                        insert.STATUS = "O";
                        insert.ENDT = "";
                        insert.DIS_PER = null;
                        insert.DIS_AMT = null;
                        insert.CHARGES_AMT = HfChargesGridTotalAmount.Value.Trim();
                        insert.PAID_TYPE = "";
                        insert.PARTY_TIN = "";
                        insert.TCODE = null;
                        insert.LR_NO = TxtLRNo.Text.Trim().ToUpper();
                        if (TxtLRDate.Text == string.Empty)
                        {
                            TxtLRDate.Text = "";
                        }
                        else
                        {
                            insert.LR_DATE = Convert.ToDateTime(TxtLRDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                        }

                        insert.PREPARATION_DATE = "";
                        insert.PREPARATION_TIME_HH = null;
                        insert.PREPARATION_TIME_MM = null;
                        insert.REMOVAL_DATE = "";
                        insert.REMOVAL_TIME_HH = null;
                        insert.REMOVAL_TIME_MM = null;
                        insert.CFORM_FLAG = "";
                        insert.CFORM_NO = "";
                        insert.EX_DUTY_PER = null;
                        insert.EX_DUTY_AMT = null;
                        insert.EX_CESS_PER = null;
                        insert.EX_CESS_AMT = null;
                        insert.EX_SHCESS_PER = null;
                        insert.EX_SHCESS_AMT = null;
                        insert.TOT_GROSS_AMT = null;
                        insert.ST_PER = null;
                        insert.ST_AMT = null;
                        insert.ADD_ST_PER = null;
                        insert.ADD_ST_AMT = null;
                        insert.TOT_AMT = "0";
                        insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                        insert.BUYERACODE = null;
                        insert.TRANSPORT = TxtTransportName.Text.Trim().ToUpper();
                        insert.EX_RATE_OF_DUTY = "";
                        insert.FORM_SRNO = null;
                        insert.CHECKPOST_NAME = "";
                        insert.REF_TRAN_DATE = "";
                        insert.REF_TRAN_NO = null;
                        insert.INVBOOK_NO = null;
                        insert.INS_USERID = Session["USERNAME"].ToString();
                        insert.INS_DATE = "";
                        //insert.UPD_USERID = Session["USERNAME"].ToString();
                        //insert.UPD_DATE = "";
                        insert.INVTYPE = Session["INVTYPE_FLAG"].ToString();
                        insert.RW_CODE = null;
                        insert.FIGURE_FLAG = DdlFigureFlag.SelectedValue.Trim().ToUpper();
                        insert.TAX_CALTYPE = DdlTaxCalType.SelectedValue.Trim().ToUpper();
                        insert.TOT_QTY = null;
                        insert.RW_TYPE = "";
                        insert.EX_CYR_PER = null;
                        insert.EX_GROSS_AMT_CYR = null;
                        insert.EX_DUTY_AMT_CYR = null;
                        insert.EX_CESS_AMT_CYR = null;
                        insert.EX_SHCESS_AMT_CYR = null;
                        insert.EX_NYR_PER = null;
                        insert.EX_GROSS_AMT_NYR = null;
                        insert.EX_DUTY_AMT_NYR = null;
                        insert.EX_CESS_AMT_NYR = null;
                        insert.EX_SHCESS_AMT_NYR = null;
                        insert.CHARGES_FLAG = "";
                        insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                        insert.CST_TYPE = DdlRegisterType.SelectedValue.Trim().ToUpper();
                        insert.LESS_AMT = null;
                        insert.TDS_AMT = null;
                        insert.DRIVER_NAME = "";
                        insert.DRIVER_ADD = "";
                        insert.MDLNO = "";
                        insert.MDLSTATE = "";
                        insert.CONF_FLAG = DdlConfirmFlag.SelectedValue.Trim().ToUpper();
                        if (DdlConfirmFlag.SelectedValue == "Y")
                        {
                            insert.CONF_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                        }
                        else
                        {
                            insert.CONF_DATE = "";
                        }

                        if (DdlConfirmFlag.SelectedValue == "Y")
                        {
                            insert.CONF_USERID = Session["USERNAME"].ToString();
                        }
                        else
                        {
                            insert.CONF_USERID = "";
                        }

                        insert.CFORM_ISSFLAG = "";
                        insert.CFORM_TRAN_DATE = "";
                        insert.CFORM_TRAN_NO = null;
                        insert.OA_FLAG = "";
                        insert.OA_AMT = HfOtherAmount.Value.Trim();
                        insert.EXCISE_TYPE = "";
                        insert.EXCISE_PRINTFLAG = "";
                        insert.CHARGES_VAT_AMT = null;
                        insert.GST_RATE = null;
                        insert.GST_AMT = HfTotalSumGSTAmount.Value.Trim();
                        insert.CGST_RATE = null;
                        insert.CGST_AMT = HfTotalSumCGSTAmount.Value.Trim();
                        insert.SGST_RATE = null;
                        insert.SGST_AMT = HfTotalSumSGSTAmount.Value.Trim();
                        insert.IGST_RATE = null;
                        insert.IGST_AMT = HfTotalSumIGSTAmount.Value.Trim();
                        insert.CUSTOM_DUTY_AMT = null;
                        insert.CUSTOM_GST_BAMT = null;
                        insert.CUSTOM_GST_RATE = null;
                        insert.CUSTOM_GST_AMT = null;
                        insert.CUSTOM_TOT_AMT = null;
                        insert.INV_TRAN_DATE = "";
                        insert.INV_TRAN_NO = null;
                        insert.INV_REASON = "";
                        insert.EWAY_BILLNO = "";

                        #endregion

                        #region INSERT INTO REC_ISS_T Stock Details

                        XmlDocument XDoc1 = new XmlDocument();
                        XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                        XDoc1.AppendChild(dec1);// Create the root element
                        XmlElement root1 = XDoc1.CreateElement("root");
                        XDoc1.AppendChild(root1);
                        int SRNODETAIL = 1;
                        foreach (GridViewRow row in GvStockRecDetails.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {

                                HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                                HiddenField HfRefTranDate = row.FindControl("HfRefTranDate") as HiddenField;
                                HiddenField HfRefTranNo = row.FindControl("HfRefTranNo") as HiddenField;
                                HiddenField HfRefSrNo = row.FindControl("HfRefSrNo") as HiddenField;

                                HiddenField HfDC_Trandate = row.FindControl("HfDC_Trandate") as HiddenField;
                                HiddenField HfDC_TranNo = row.FindControl("HfDC_TranNo") as HiddenField;
                                HiddenField HfDC_SrNo = row.FindControl("HfDC_SrNo") as HiddenField;

                                HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                                HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;

                                HiddenField HfAmount = row.FindControl("HfAmount") as HiddenField;
                                HiddenField HfDisAmount = row.FindControl("HfDisAmount") as HiddenField;
                                HiddenField HfGrossAmount = row.FindControl("HfGrossAmount") as HiddenField;
                                HiddenField HfEntryType = row.FindControl("HfEntryType") as HiddenField;

                                TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                                TextBox TxtHSNCode = row.FindControl("TxtHSNCode") as TextBox;
                                TextBox TxtProductDescrption = row.FindControl("TxtProductDescrption") as TextBox;
                                TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                                TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                                TextBox TxtDisRate = row.FindControl("TxtDisRate") as TextBox;
                                TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                                TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                                TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                                TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                                TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                                TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                                TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;


                                if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != null)
                                {


                                    XmlElement HandleDetail2 = XDoc1.CreateElement("REC_ISS_TDetails");
                                    HandleDetail2.SetAttribute("SR", SRNODETAIL.ToString());
                                    HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                    //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                    //HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                    if (HfDetailSCode.Value == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("SCODE", null);
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value));
                                    }

                                    if (TxtHSNCode.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("HSN_NO", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("HSN_NO", (TxtHSNCode.Text));
                                    }

                                    if (TxtProductDescrption.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("PRODUCT_DESC", (""));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("PRODUCT_DESC", (TxtProductDescrption.Text));
                                    }

                                    if (HfRefTranDate.Value != string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("REF_TRAN_DATE", (Convert.ToDateTime(HfRefTranDate.Value).ToString("MM-dd-yyyy")));
                                    }


                                    if (HfRefTranNo.Value != string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("REF_TRAN_NO", (HfRefTranNo.Value.Trim()));
                                    }


                                    if (HfRefSrNo.Value != string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("REF_SRNO", (HfRefSrNo.Value.Trim()));
                                    }


                                    if (TxtQty.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("QTY", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("QTY", (TxtQty.Text.Trim()));
                                    }

                                    if (TxtRate.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("RATE", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("RATE", (TxtRate.Text.Trim()));
                                    }

                                    if (HfAmount.Value == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("AMT", (HfAmount.Value.Trim()));
                                    }


                                    if (TxtDisRate.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("DIS_PER", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("DIS_PER", (TxtDisRate.Text.Trim()));
                                    }

                                    if (HfDisAmount.Value == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("DIS_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("DIS_AMT", (HfDisAmount.Value.Trim()));
                                    }

                                    if (HfGrossAmount.Value == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("G_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("G_AMT", (HfGrossAmount.Value.Trim()));
                                    }

                                    if (HfGSTRate.Value == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("GST_RATE", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("GST_RATE", (HfGSTRate.Value.Trim()));
                                    }

                                    if (HfGSTAmount.Value == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("GST_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("GST_AMT", (HfGSTAmount.Value.Trim()));
                                    }

                                    if (TxtCGSTRate.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("CGST_RATE", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("CGST_RATE", (TxtCGSTRate.Text.Trim()));
                                    }

                                    if (TxtCGSTAmount.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("CGST_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text.Trim()));
                                    }

                                    if (TxtSGSTRate.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("SGST_RATE", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("SGST_RATE", (TxtSGSTRate.Text.Trim()));
                                    }

                                    if (TxtSGSTAmount.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("SGST_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text.Trim()));
                                    }

                                    if (TxtIGSTRate.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("IGST_RATE", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("IGST_RATE", (TxtIGSTRate.Text.Trim()));
                                    }

                                    if (TxtIGSTAmount.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("IGST_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text.Trim()));
                                    }

                                    if (TxtTotalAmount.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("T_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("T_AMT", (TxtTotalAmount.Text.Trim()));
                                    }

                                    HandleDetail2.SetAttribute("ENTRY_TYPE", (HfEntryType.Value.Trim().ToString()));

                                    if (HfDC_Trandate.Value != string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("DC_TRAN_DATE", (Convert.ToDateTime(HfDC_Trandate.Value).ToString("MM-dd-yyyy")));
                                    }


                                    if (HfDC_TranNo.Value != string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("DC_TRAN_NO", (HfDC_TranNo.Value.Trim()));
                                    }

                                    if (HfDC_SrNo.Value != string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("DC_SRNO", (HfDC_SrNo.Value.Trim()));
                                    }


                                    root1.AppendChild(HandleDetail2);
                                    SRNODETAIL++;

                                }

                            }
                        }


                        #endregion


                        #region INSERT CHARGES INTO GRID REC_ISS_C

                        XmlDocument XDoc2 = new XmlDocument();
                        XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                        XDoc2.AppendChild(dec2);// Create the root element
                        XmlElement root2 = XDoc2.CreateElement("root");
                        XDoc2.AppendChild(root2);
                        int CHARGES_SRNO = 1;

                        foreach (GridViewRow row in GvChagresTranDetails.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {


                                HiddenField HfChargesCode = row.FindControl("HfChargesCode") as HiddenField;
                                HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                                HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;

                                TextBox TxtHSNCode = row.FindControl("TxtHSNCode") as TextBox;
                                TextBox TxtChargesName = row.FindControl("TxtChargesName") as TextBox;
                                TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                                TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                                TextBox TxtChargesSign = row.FindControl("TxtChargesSign") as TextBox;
                                TextBox TxtChargesAmount = row.FindControl("TxtChargesAmount") as TextBox;
                                TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                                TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                                TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                                TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                                TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                                TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                                TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;



                                if (HfChargesCode.Value != "0" && HfChargesCode.Value != "")
                                {

                                    XmlElement HandleDetail3 = XDoc2.CreateElement("REC_ISS_ChargesDetails");
                                    HandleDetail3.SetAttribute("SR", CHARGES_SRNO.ToString());
                                    HandleDetail3.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                    //HandleDetail3.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                    //HandleDetail3.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                    HandleDetail3.SetAttribute("CCODE", (HfChargesCode.Value.Trim()));

                                    if (TxtRate.Text == string.Empty)
                                    {
                                        HandleDetail3.SetAttribute("PER", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail3.SetAttribute("PER", (TxtRate.Text));
                                    }

                                    HandleDetail3.SetAttribute("SIGN", (TxtChargesSign.Text.Trim()));
                                    HandleDetail3.SetAttribute("HSN_NO", (TxtHSNCode.Text.Trim()));

                                    if (TxtQty.Text == string.Empty)
                                    {
                                        HandleDetail3.SetAttribute("QTY", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail3.SetAttribute("QTY", (TxtQty.Text));
                                    }

                                    if (TxtChargesAmount.Text == string.Empty)
                                    {
                                        HandleDetail3.SetAttribute("AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail3.SetAttribute("AMT", (TxtChargesAmount.Text));
                                    }

                                    if (HfGSTRate.Value == string.Empty)
                                    {
                                        HandleDetail3.SetAttribute("GST_RATE", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail3.SetAttribute("GST_RATE", (HfGSTRate.Value));
                                    }

                                    if (HfGSTAmount.Value == string.Empty)
                                    {
                                        HandleDetail3.SetAttribute("GST_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail3.SetAttribute("GST_AMT", (HfGSTAmount.Value));
                                    }
                                    if (TxtCGSTRate.Text == string.Empty)
                                    {
                                        HandleDetail3.SetAttribute("CGST_RATE", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail3.SetAttribute("CGST_RATE", (TxtCGSTRate.Text));
                                    }
                                    if (TxtCGSTAmount.Text == string.Empty)
                                    {
                                        HandleDetail3.SetAttribute("CGST_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail3.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text));
                                    }
                                    if (TxtSGSTRate.Text == string.Empty)
                                    {
                                        HandleDetail3.SetAttribute("SGST_RATE", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail3.SetAttribute("SGST_RATE", (TxtSGSTRate.Text));
                                    }
                                    if (TxtSGSTAmount.Text == string.Empty)
                                    {
                                        HandleDetail3.SetAttribute("SGST_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail3.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text));
                                    }
                                    if (TxtIGSTRate.Text == string.Empty)
                                    {
                                        HandleDetail3.SetAttribute("IGST_RATE", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail3.SetAttribute("IGST_RATE", (TxtIGSTRate.Text));
                                    }
                                    if (TxtIGSTAmount.Text == string.Empty)
                                    {
                                        HandleDetail3.SetAttribute("IGST_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail3.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text));
                                    }
                                    if (TxtTotalAmount.Text == string.Empty)
                                    {
                                        HandleDetail3.SetAttribute("T_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail3.SetAttribute("T_AMT", (TxtTotalAmount.Text));
                                    }

                                    root2.AppendChild(HandleDetail3);
                                    CHARGES_SRNO++;

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
                        // int SRNOBARCODE = 1;
                        //foreach (GridViewRow row in GvViewBarcode.Rows)
                        //{
                        //    if (row.RowType == DataControlRowType.DataRow)
                        //    {
                        //        HiddenField HfStockcode = row.FindControl("HfStockcode") as HiddenField;
                        //        HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                        //        HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                        //        HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;
                        //        TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                        //        TextBox TxtQty = row.FindControl("TxtQty") as TextBox;



                        //        XmlElement HandleDetail4 = XDoc3.CreateElement("REC_BarcodeDetails");

                        //        if (TxtBarcode.Text != string.Empty && TxtBarcode.Text != null)
                        //        {
                        //            HandleDetail4.SetAttribute("SRNO", SRNOBARCODE.ToString());
                        //            HandleDetail4.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                        //            //    HandleDetail4.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                        //            //    HandleDetail4.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());


                        //            HandleDetail4.SetAttribute("BAR_TRAN_DATE", Convert.ToDateTime(HfBarTranDate.Value).ToString("MM-dd-yyyy"));


                        //            if (HfBarTranNo.Value == string.Empty)
                        //            {
                        //                HandleDetail4.SetAttribute("BAR_TRAN_NO", ("0"));
                        //            }
                        //            else
                        //            {
                        //                HandleDetail4.SetAttribute("BAR_TRAN_NO", (HfBarTranNo.Value));
                        //            }


                        //            if (HfBarSrNo.Value == string.Empty)
                        //            {
                        //                HandleDetail4.SetAttribute("BAR_SRNO", ("0"));
                        //            }
                        //            else
                        //            {
                        //                HandleDetail4.SetAttribute("BAR_SRNO", (HfBarSrNo.Value));
                        //            }

                        //            if (TxtQty.Text == string.Empty)
                        //            {
                        //                HandleDetail4.SetAttribute("QTY", ("0"));
                        //            }
                        //            else
                        //            {
                        //                HandleDetail4.SetAttribute("QTY", (TxtQty.Text));
                        //            }

                        //            root3.AppendChild(HandleDetail4);
                        //            SRNOBARCODE++;
                        //        }
                        //    }
                        //}

                        #endregion

                        #region INSERT DC MASTER REC ISSUE DETAIL

                        XmlDocument XDocDC = new XmlDocument();
                        XmlDeclaration decDC = XDocDC.CreateXmlDeclaration("1.0", null, null);
                        XDocDC.AppendChild(decDC);// Create the root element
                        XmlElement rootDC = XDocDC.CreateElement("root");
                        XDocDC.AppendChild(rootDC);
                        int SRNODCMASTER = 1;
                        if (ViewState["AddChallanTable"] != null)
                        {
                            DataTable DtDCMASter = (DataTable)ViewState["AddChallanTable"];
                            if (DtDCMASter.Rows.Count > 0)
                            {
                                for (int m = 0; m < DtDCMASter.Rows.Count; m++)
                                {
                                    XmlElement HandleDetailDC = XDocDC.CreateElement("REC_M_DCMAS");
                                    HandleDetailDC.SetAttribute("SRNO", SRNODCMASTER.ToString());
                                    HandleDetailDC.SetAttribute("DC_TRAN_DATE", (Convert.ToDateTime(DtDCMASter.Rows[m]["DCTransDate"].ToString()).ToString("MM-dd-yyyy")));
                                    HandleDetailDC.SetAttribute("DC_TRAN_NO", DtDCMASter.Rows[m]["DCTransNo"].ToString());
                                    rootDC.AppendChild(HandleDetailDC);
                                    SRNODCMASTER++;
                                }
                            }
                        }
                        #endregion

                        string str = REC_ISS_MLogicLayer.InsertREC_ISS_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml), validation.RSC(XDoc3.OuterXml), validation.RSC(XDocDC.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"), HfTranType.Value.ToString(), HfTrnType.Value.ToString());

                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "SALES TAX INVOICE MASTER SAVE SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillREC_ISS_MasterGrid(Session["COMP_CODE"].ToString());
                            UserRights();


                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "SALES TAX INVOICE MASTER ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : SALES TAX INVOICE MASTER NOT SAVED";
                            lblmsg.ForeColor = Color.Red;

                        }
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : Items Details must be input..!";
                        lblmsg.ForeColor = Color.Red;

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region UPDATE REC_ISS M DETAILS FOR PURCHASE

                if (Convert.ToDecimal(TxtNetAmt.Text) > 0)
                {
                    #region INSERT REC_ISS_M  DETAILS

                    REC_ISS_MLogicLayer insert = new REC_ISS_MLogicLayer();

                    insert.COMP_CODE = HfCompCode.Value.Trim();
                    insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.TRAN_TYPE = HfTranType.Value.Trim().ToUpper();
                    insert.TRN_TYPE = HfTrnType.Value.Trim().ToUpper();
                    insert.TAX_TYPE = "";
                    insert.CRACODE = HfAODECredit.Value.Trim();
                    insert.DRACODE = HfACODEDebit.Value.Trim();
                    insert.SALES_TYPE = DdlSalesType.SelectedValue.Trim().ToUpper();
                    insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToUpper();
                    insert.PARTY_NAME = "";
                    insert.PARTY_ADD = "";
                    insert.BCODE = null;
                    insert.BAMT = null;
                    insert.INV_NO = "";
                    insert.INV_NUMBER = TxtInvoiceNumber.Text.Trim().ToUpper();
                    if (TxtInvoiceDate.Text != string.Empty)
                    {
                        insert.INV_DT = Convert.ToDateTime(TxtInvoiceDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    insert.REC_DT = "";
                    insert.DUE_DAYS = null;
                    insert.DUE_DATE = "";
                    insert.CHA_NO = TxtDCNo.Text.Trim().ToUpper();
                    if (TxtDCDate.Text != string.Empty)
                    {
                        insert.CHA_DT = Convert.ToDateTime(TxtDCDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }

                    insert.PO_NO = null;
                    insert.PO_DT = "";
                    insert.VEHICLE_NO = TxtVehclieNo.Text.Trim().ToUpper();
                    insert.GROSS_AMT = HfGridGrossAmount.Value.Trim();
                    insert.RO_AMT = TxtROamt.Text.Trim();
                    insert.NET_AMT = TxtNetAmt.Text.Trim();
                    insert.PAID_AMT = null;
                    insert.STATUS = "O";
                    insert.ENDT = "";
                    insert.DIS_PER = null;
                    insert.DIS_AMT = null;
                    insert.CHARGES_AMT = HfChargesGridTotalAmount.Value.Trim();
                    insert.PAID_TYPE = "";
                    insert.PARTY_TIN = "";
                    insert.TCODE = null;
                    insert.LR_NO = TxtLRNo.Text.Trim().ToUpper();
                    if (TxtLRDate.Text == string.Empty)
                    {
                        TxtLRDate.Text = "";
                    }
                    else
                    {
                        insert.LR_DATE = Convert.ToDateTime(TxtLRDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }

                    insert.PREPARATION_DATE = "";
                    insert.PREPARATION_TIME_HH = null;
                    insert.PREPARATION_TIME_MM = null;
                    insert.REMOVAL_DATE = "";
                    insert.REMOVAL_TIME_HH = null;
                    insert.REMOVAL_TIME_MM = null;
                    insert.CFORM_FLAG = "";
                    insert.CFORM_NO = "";
                    insert.EX_DUTY_PER = null;
                    insert.EX_DUTY_AMT = null;
                    insert.EX_CESS_PER = null;
                    insert.EX_CESS_AMT = null;
                    insert.EX_SHCESS_PER = null;
                    insert.EX_SHCESS_AMT = null;
                    insert.TOT_GROSS_AMT = null;
                    insert.ST_PER = null;
                    insert.ST_AMT = null;
                    insert.ADD_ST_PER = null;
                    insert.ADD_ST_AMT = null;
                    insert.TOT_AMT = "0";
                    insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                    insert.BUYERACODE = null;
                    insert.TRANSPORT = TxtTransportName.Text.Trim().ToUpper();
                    insert.EX_RATE_OF_DUTY = "";
                    insert.FORM_SRNO = null;
                    insert.CHECKPOST_NAME = "";
                    insert.REF_TRAN_DATE = "";
                    insert.REF_TRAN_NO = null;
                    insert.INVBOOK_NO = null;
                    //insert.INS_USERID = Session["USERNAME"].ToString();
                    //insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_DATE = "";
                    insert.INVTYPE = Session["INVTYPE_FLAG"].ToString();
                    insert.RW_CODE = null;
                    insert.FIGURE_FLAG = DdlFigureFlag.SelectedValue.Trim().ToUpper();
                    insert.TAX_CALTYPE = DdlTaxCalType.SelectedValue.Trim().ToUpper();
                    insert.TOT_QTY = null;
                    insert.RW_TYPE = "";
                    insert.EX_CYR_PER = null;
                    insert.EX_GROSS_AMT_CYR = null;
                    insert.EX_DUTY_AMT_CYR = null;
                    insert.EX_CESS_AMT_CYR = null;
                    insert.EX_SHCESS_AMT_CYR = null;
                    insert.EX_NYR_PER = null;
                    insert.EX_GROSS_AMT_NYR = null;
                    insert.EX_DUTY_AMT_NYR = null;
                    insert.EX_CESS_AMT_NYR = null;
                    insert.EX_SHCESS_AMT_NYR = null;
                    insert.CHARGES_FLAG = "";
                    insert.BRANCH_CODE = HfBranchCode.Value.Trim();
                    insert.CST_TYPE = DdlRegisterType.SelectedValue.Trim().ToUpper();
                    insert.LESS_AMT = null;
                    insert.TDS_AMT = null;
                    insert.DRIVER_NAME = "";
                    insert.DRIVER_ADD = "";
                    insert.MDLNO = "";
                    insert.MDLSTATE = "";
                    insert.CONF_FLAG = DdlConfirmFlag.SelectedValue.Trim().ToUpper();
                    if (DdlConfirmFlag.SelectedValue == "Y")
                    {
                        insert.CONF_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CONF_DATE = "";
                    }

                    if (DdlConfirmFlag.SelectedValue == "Y")
                    {
                        insert.CONF_USERID = Session["USERNAME"].ToString();
                    }
                    else
                    {
                        insert.CONF_USERID = "";
                    }

                    insert.CFORM_ISSFLAG = "";
                    insert.CFORM_TRAN_DATE = "";
                    insert.CFORM_TRAN_NO = null;
                    insert.OA_FLAG = "";
                    insert.OA_AMT = HfOtherAmount.Value.Trim();
                    insert.EXCISE_TYPE = "";
                    insert.EXCISE_PRINTFLAG = "";
                    insert.CHARGES_VAT_AMT = null;
                    insert.GST_RATE = null;
                    insert.GST_AMT = HfTotalSumGSTAmount.Value.Trim();
                    insert.CGST_RATE = null;
                    insert.CGST_AMT = HfTotalSumCGSTAmount.Value.Trim();
                    insert.SGST_RATE = null;
                    insert.SGST_AMT = HfTotalSumSGSTAmount.Value.Trim();
                    insert.IGST_RATE = null;
                    insert.IGST_AMT = HfTotalSumIGSTAmount.Value.Trim();
                    insert.CUSTOM_DUTY_AMT = null;
                    insert.CUSTOM_GST_BAMT = null;
                    insert.CUSTOM_GST_RATE = null;
                    insert.CUSTOM_GST_AMT = null;
                    insert.CUSTOM_TOT_AMT = null;
                    insert.INV_TRAN_DATE = "";
                    insert.INV_TRAN_NO = null;
                    insert.INV_REASON = "";
                    insert.EWAY_BILLNO = "";

                    #endregion


                    #region INSERT INTO REC_ISS_T Stock Details

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int SRNODETAIL = 1;
                    foreach (GridViewRow row in GvStockRecDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {

                            HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                            HiddenField HfRefTranDate = row.FindControl("HfRefTranDate") as HiddenField;
                            HiddenField HfRefTranNo = row.FindControl("HfRefTranNo") as HiddenField;
                            HiddenField HfRefSrNo = row.FindControl("HfRefSrNo") as HiddenField;

                            HiddenField HfDC_Trandate = row.FindControl("HfDC_Trandate") as HiddenField;
                            HiddenField HfDC_TranNo = row.FindControl("HfDC_TranNo") as HiddenField;
                            HiddenField HfDC_SrNo = row.FindControl("HfDC_SrNo") as HiddenField;

                            HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                            HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;

                            HiddenField HfAmount = row.FindControl("HfAmount") as HiddenField;
                            HiddenField HfDisAmount = row.FindControl("HfDisAmount") as HiddenField;
                            HiddenField HfGrossAmount = row.FindControl("HfGrossAmount") as HiddenField;
                            HiddenField HfEntryType = row.FindControl("HfEntryType") as HiddenField;

                            TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                            TextBox TxtHSNCode = row.FindControl("TxtHSNCode") as TextBox;
                            TextBox TxtProductDescrption = row.FindControl("TxtProductDescrption") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtDisRate = row.FindControl("TxtDisRate") as TextBox;
                            TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                            TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                            TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                            TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                            TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                            TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                            TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;


                            if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != null)
                            {


                                XmlElement HandleDetail2 = XDoc1.CreateElement("REC_ISS_TDetails");
                                HandleDetail2.SetAttribute("SR", SRNODETAIL.ToString());
                                HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                if (HfDetailSCode.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SCODE", null);
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value));
                                }

                                if (TxtHSNCode.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("HSN_NO", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("HSN_NO", (TxtHSNCode.Text));
                                }

                                if (TxtProductDescrption.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("PRODUCT_DESC", (""));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("PRODUCT_DESC", (TxtProductDescrption.Text));
                                }

                                if (HfRefTranDate.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("REF_TRAN_DATE", (Convert.ToDateTime(HfRefTranDate.Value).ToString("MM-dd-yyyy")));
                                }


                                if (HfRefTranNo.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("REF_TRAN_NO", (HfRefTranNo.Value.Trim()));
                                }


                                if (HfRefSrNo.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("REF_SRNO", (HfRefSrNo.Value.Trim()));
                                }


                                if (TxtQty.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("QTY", (TxtQty.Text.Trim()));
                                }

                                if (TxtRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("RATE", (TxtRate.Text.Trim()));
                                }

                                if (HfAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("AMT", (HfAmount.Value.Trim()));
                                }


                                if (TxtDisRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DIS_PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("DIS_PER", (TxtDisRate.Text.Trim()));
                                }

                                if (HfDisAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DIS_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("DIS_AMT", (HfDisAmount.Value.Trim()));
                                }

                                if (HfGrossAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("G_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("G_AMT", (HfGrossAmount.Value.Trim()));
                                }

                                if (HfGSTRate.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("GST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("GST_RATE", (HfGSTRate.Value.Trim()));
                                }

                                if (HfGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("GST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("GST_AMT", (HfGSTAmount.Value.Trim()));
                                }

                                if (TxtCGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CGST_RATE", (TxtCGSTRate.Text.Trim()));
                                }

                                if (TxtCGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text.Trim()));
                                }

                                if (TxtSGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SGST_RATE", (TxtSGSTRate.Text.Trim()));
                                }

                                if (TxtSGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text.Trim()));
                                }

                                if (TxtIGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("IGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("IGST_RATE", (TxtIGSTRate.Text.Trim()));
                                }

                                if (TxtIGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("IGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text.Trim()));
                                }

                                if (TxtTotalAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("T_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("T_AMT", (TxtTotalAmount.Text.Trim()));
                                }

                                HandleDetail2.SetAttribute("ENTRY_TYPE", (HfEntryType.Value.Trim().ToString()));

                                if (HfDC_Trandate.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DC_TRAN_DATE", (Convert.ToDateTime(HfDC_Trandate.Value).ToString("MM-dd-yyyy")));
                                }


                                if (HfDC_TranNo.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DC_TRAN_NO", (HfDC_TranNo.Value.Trim()));
                                }

                                if (HfDC_SrNo.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DC_SRNO", (HfDC_SrNo.Value.Trim()));
                                }


                                root1.AppendChild(HandleDetail2);
                                SRNODETAIL++;

                            }

                        }
                    }


                    #endregion


                    #region INSERT CHARGES INTO GRID REC_ISS_C

                    XmlDocument XDoc2 = new XmlDocument();
                    XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                    XDoc2.AppendChild(dec2);// Create the root element
                    XmlElement root2 = XDoc2.CreateElement("root");
                    XDoc2.AppendChild(root2);
                    int CHARGES_SRNO = 1;

                    foreach (GridViewRow row in GvChagresTranDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {


                            HiddenField HfChargesCode = row.FindControl("HfChargesCode") as HiddenField;
                            HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                            HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;

                            TextBox TxtHSNCode = row.FindControl("TxtHSNCode") as TextBox;
                            TextBox TxtChargesName = row.FindControl("TxtChargesName") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtChargesSign = row.FindControl("TxtChargesSign") as TextBox;
                            TextBox TxtChargesAmount = row.FindControl("TxtChargesAmount") as TextBox;
                            TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                            TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                            TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                            TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                            TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                            TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                            TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;



                            if (HfChargesCode.Value != "0" && HfChargesCode.Value != "")
                            {

                                XmlElement HandleDetail3 = XDoc2.CreateElement("REC_ISS_ChargesDetails");
                                HandleDetail3.SetAttribute("SR", CHARGES_SRNO.ToString());
                                HandleDetail3.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                HandleDetail3.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                HandleDetail3.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                HandleDetail3.SetAttribute("CCODE", (HfChargesCode.Value.Trim()));

                                if (TxtRate.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("PER", (TxtRate.Text));
                                }

                                HandleDetail3.SetAttribute("SIGN", (TxtChargesSign.Text.Trim()));
                                HandleDetail3.SetAttribute("HSN_NO", (TxtHSNCode.Text.Trim()));

                                if (TxtQty.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("QTY", (TxtQty.Text));
                                }

                                if (TxtChargesAmount.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("AMT", (TxtChargesAmount.Text));
                                }

                                if (HfGSTRate.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("GST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("GST_RATE", (HfGSTRate.Value));
                                }

                                if (HfGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("GST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("GST_AMT", (HfGSTAmount.Value));
                                }
                                if (TxtCGSTRate.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("CGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("CGST_RATE", (TxtCGSTRate.Text));
                                }
                                if (TxtCGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("CGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text));
                                }
                                if (TxtSGSTRate.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("SGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("SGST_RATE", (TxtSGSTRate.Text));
                                }
                                if (TxtSGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("SGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text));
                                }
                                if (TxtIGSTRate.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("IGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("IGST_RATE", (TxtIGSTRate.Text));
                                }
                                if (TxtIGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("IGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text));
                                }
                                if (TxtTotalAmount.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("T_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("T_AMT", (TxtTotalAmount.Text));
                                }

                                root2.AppendChild(HandleDetail3);
                                CHARGES_SRNO++;

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
                    // int SRNOBARCODE = 1;
                    //foreach (GridViewRow row in GvViewBarcode.Rows)
                    //{
                    //    if (row.RowType == DataControlRowType.DataRow)
                    //    {
                    //        HiddenField HfStockcode = row.FindControl("HfStockcode") as HiddenField;
                    //        HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                    //        HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                    //        HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;
                    //        TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                    //        TextBox TxtQty = row.FindControl("TxtQty") as TextBox;



                    //        XmlElement HandleDetail4 = XDoc3.CreateElement("REC_BarcodeDetails");

                    //        if (TxtBarcode.Text != string.Empty && TxtBarcode.Text != null)
                    //        {
                    //            HandleDetail4.SetAttribute("SRNO", SRNOBARCODE.ToString());
                    //            HandleDetail4.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                    //            //    HandleDetail4.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                    //            //    HandleDetail4.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());


                    //            HandleDetail4.SetAttribute("BAR_TRAN_DATE", Convert.ToDateTime(HfBarTranDate.Value).ToString("MM-dd-yyyy"));


                    //            if (HfBarTranNo.Value == string.Empty)
                    //            {
                    //                HandleDetail4.SetAttribute("BAR_TRAN_NO", ("0"));
                    //            }
                    //            else
                    //            {
                    //                HandleDetail4.SetAttribute("BAR_TRAN_NO", (HfBarTranNo.Value));
                    //            }


                    //            if (HfBarSrNo.Value == string.Empty)
                    //            {
                    //                HandleDetail4.SetAttribute("BAR_SRNO", ("0"));
                    //            }
                    //            else
                    //            {
                    //                HandleDetail4.SetAttribute("BAR_SRNO", (HfBarSrNo.Value));
                    //            }

                    //            if (TxtQty.Text == string.Empty)
                    //            {
                    //                HandleDetail4.SetAttribute("QTY", ("0"));
                    //            }
                    //            else
                    //            {
                    //                HandleDetail4.SetAttribute("QTY", (TxtQty.Text));
                    //            }

                    //            root3.AppendChild(HandleDetail4);
                    //            SRNOBARCODE++;
                    //        }
                    //    }
                    //}

                    #endregion


                    #region INSERT DC MASTER REC ISSUE DETAIL

                    XmlDocument XDocDC = new XmlDocument();
                    XmlDeclaration decDC = XDocDC.CreateXmlDeclaration("1.0", null, null);
                    XDocDC.AppendChild(decDC);// Create the root element
                    XmlElement rootDC = XDocDC.CreateElement("root");
                    XDocDC.AppendChild(rootDC);
                    int SRNODCMASTER = 1;
                    if (ViewState["AddChallanTable"] != null)
                    {
                        DataTable DtDCMASter = (DataTable)ViewState["AddChallanTable"];
                        if (DtDCMASter.Rows.Count > 0)
                        {
                            for (int m = 0; m < DtDCMASter.Rows.Count; m++)
                            {
                                XmlElement HandleDetailDC = XDocDC.CreateElement("REC_M_DCMAS");
                                HandleDetailDC.SetAttribute("SRNO", SRNODCMASTER.ToString());
                                HandleDetailDC.SetAttribute("DC_TRAN_DATE", (Convert.ToDateTime(DtDCMASter.Rows[m]["DCTransDate"].ToString()).ToString("MM-dd-yyyy")));
                                HandleDetailDC.SetAttribute("DC_TRAN_NO", DtDCMASter.Rows[m]["DCTransNo"].ToString());
                                rootDC.AppendChild(HandleDetailDC);
                                SRNODCMASTER++;
                            }
                        }
                    }
                    #endregion

                    string str = REC_ISS_MLogicLayer.UpdateREC_ISS_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml), validation.RSC(XDoc3.OuterXml), validation.RSC(XDocDC.OuterXml), HfCompCode.Value, HfBranchCode.Value, Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"), HfTranType.Value.ToString(), HfTrnType.Value.ToString());

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "PURCHASE TAX INVOICE MASTER UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillREC_ISS_MasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "PURCHASE TAX INVOICE MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : PURCHASE TAX INVOICE MASTER NOT SAVED";
                        lblmsg.ForeColor = Color.Red;

                    }
                }
                else
                {
                    lblmsg.Text = "ERROR : Items Details must be input..!";
                    lblmsg.ForeColor = Color.Red;

                }


                #endregion
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void FillDebitACNameOnUpdate(string Id)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Brabch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTWiseComapnyAndBranchForInvoice(Comp_Code, Brabch_Code);


                if (HfACODEDebit.Value.ToString() != "0" && HfACODEDebit.Value != null && HfACODEDebit.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "ACODE=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtExpenseAccount.Text = DtView.Rows[0]["ANAME"].ToString();
                    HfACODEDebit.Value = DtView.Rows[0]["ACODE"].ToString();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillPartySupplierNameOnUpdate(string Id)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Brabch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTWiseComapnyAndBranchForInvoice(Comp_Code, Brabch_Code);


                if (HfAODECredit.Value.ToString() != "0" && HfAODECredit.Value != null && HfAODECredit.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "ACODE=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtSupplierNameCredit.Text = DtView.Rows[0]["ANAME"].ToString();
                    HfAODECredit.Value = DtView.Rows[0]["ACODE"].ToString();
                    TxtGstNo.Text = DtView.Rows[0]["GST_NO"].ToString();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void GvTaxInvoiceMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvTaxInvoiceMaster.PageIndex = e.NewPageIndex;
            clear();
            FillREC_ISS_MasterGrid(Session["COMP_CODE"].ToString());
        }

        protected void GvTaxInvoiceMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btnedit = (e.Row.FindControl("btnEdit") as Button);
                    Button btndelete = (e.Row.FindControl("btnDelete") as Button);
                    Label lblchk = (e.Row.FindControl("lblConfirmFlag") as Label);


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
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvTaxInvoiceMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
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


                        DataSet ds = REC_ISS_MLogicLayer.GetAllIDWiseREC_ISS_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtCharges = ds.Tables[2];

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
                            HfAODECredit.Value = dt.Rows[0]["CRACODE"].ToString();
                            FillPartySupplierNameOnUpdate(dt.Rows[0]["CRACODE"].ToString());
                            HfACODEDebit.Value = dt.Rows[0]["DRACODE"].ToString();
                            FillDebitACNameOnUpdate(dt.Rows[0]["DRACODE"].ToString());
                            //TxtPONo.Text = dt.Rows[0]["PO_NO"].ToString();
                            //TxtPODate.Text = dt.Rows[0]["PO_DT"].ToString();
                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtLRNo.Text = dt.Rows[0]["LR_NO"].ToString();
                            TxtLRDate.Text = dt.Rows[0]["LR_DATE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtInvoiceNumber.Text = dt.Rows[0]["INV_NUMBER"].ToString();
                            TxtInvoiceDate.Text = Convert.ToDateTime(dt.Rows[0]["INV_DT"].ToString()).ToString("dd-MM-yyyy");
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            DdlSalesType.SelectedValue = dt.Rows[0]["SALES_TYPE"].ToString();
                            DdlRegisterType.SelectedValue = dt.Rows[0]["CST_TYPE"].ToString();
                            DdlTaxCalType.SelectedValue = dt.Rows[0]["TAX_CALTYPE"].ToString();
                            TxtDCNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            TxtDCDate.Text = Convert.ToDateTime(dt.Rows[0]["CHA_DT"].ToString()).ToString("dd-MM-yyyy");
                            DdlFigureFlag.SelectedValue = dt.Rows[0]["FIGURE_FLAG"].ToString();

                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            Session["TRAN_TYPE"] = HfTranType.Value;
                            Session["TRN_TYPE"] = HfTrnType.Value;


                            if (DtDetails.Rows.Count > 0)
                            {
                                GvStockRecDetails.DataSource = DtDetails;
                                GvStockRecDetails.DataBind();
                                GvStockRecDetails.Enabled = false;
                            }

                            if (DtCharges.Rows.Count > 0)
                            {
                                GvChagresTranDetails.DataSource = DtCharges;
                                GvChagresTranDetails.DataBind();
                                GvChagresTranDetails.Enabled = false;
                            }


                            btnSave.Visible = false;
                            btnDelete.Visible = true;
                            Btncalldel.Visible = true;
                            BtncallUpd.Visible = false;
                            GvStockRecDetails.Enabled = false;
                            ControllerDisable();
                        }
                    }

                    #endregion
                }

                if (e.CommandName == "Edita")
                {

                    ViewState["CurrentTable"] = null;

                    #region EDIT
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = REC_ISS_MLogicLayer.GetAllIDWiseREC_ISS_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtCharges = ds.Tables[2];
                        DataTable DtChallan = ds.Tables[4];

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
                            HfAODECredit.Value = dt.Rows[0]["CRACODE"].ToString();
                            FillPartySupplierNameOnUpdate(dt.Rows[0]["CRACODE"].ToString());
                            HfACODEDebit.Value = dt.Rows[0]["DRACODE"].ToString();
                            FillDebitACNameOnUpdate(dt.Rows[0]["DRACODE"].ToString());
                            //TxtPONo.Text = dt.Rows[0]["PO_NO"].ToString();
                            //TxtPODate.Text = dt.Rows[0]["PO_DT"].ToString();
                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtLRNo.Text = dt.Rows[0]["LR_NO"].ToString();
                            TxtLRDate.Text = dt.Rows[0]["LR_DATE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtInvoiceNumber.Text = dt.Rows[0]["INV_NUMBER"].ToString();
                            TxtInvoiceDate.Text = Convert.ToDateTime(dt.Rows[0]["INV_DT"].ToString()).ToString("dd-MM-yyyy");
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            DdlSalesType.SelectedValue = dt.Rows[0]["SALES_TYPE"].ToString();
                            DdlRegisterType.SelectedValue = dt.Rows[0]["CST_TYPE"].ToString();
                            DdlTaxCalType.SelectedValue = dt.Rows[0]["TAX_CALTYPE"].ToString();
                            TxtDCNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            TxtDCDate.Text = Convert.ToDateTime(dt.Rows[0]["CHA_DT"].ToString()).ToString("dd-MM-yyyy");
                            DdlFigureFlag.SelectedValue = dt.Rows[0]["FIGURE_FLAG"].ToString();

                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            Session["TRAN_TYPE"] = HfTranType.Value;
                            Session["TRN_TYPE"] = HfTrnType.Value;


                            if (DtDetails.Rows.Count > 0)
                            {

                                #region Assign To Table

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
                                        table.Columns.Add("SR", typeof(string));
                                        table.Columns.Add("REF_TRAN_DATE", typeof(string));
                                        table.Columns.Add("REF_TRAN_NO", typeof(string));
                                        table.Columns.Add("REF_SRNO", typeof(string));
                                        table.Columns.Add("SCODE", typeof(string));
                                        table.Columns.Add("PRODUCT_DESC", typeof(string));
                                        table.Columns.Add("HSN_NO", typeof(string));
                                        table.Columns.Add("QTY", typeof(string));
                                        table.Columns.Add("RATE", typeof(string));
                                        table.Columns.Add("AMT", typeof(string));
                                        table.Columns.Add("DIS_PER", typeof(string));
                                        table.Columns.Add("DIS_AMT", typeof(string));
                                        table.Columns.Add("ADD_DIS_PER", typeof(string));
                                        table.Columns.Add("ADD_DIS_AMT", typeof(string));
                                        table.Columns.Add("G_AMT", typeof(string));
                                        table.Columns.Add("ST_PER", typeof(string));
                                        table.Columns.Add("ST_AMT", typeof(string));
                                        table.Columns.Add("ADD_ST_PER", typeof(string));
                                        table.Columns.Add("ADD_ST_AMT", typeof(string));
                                        table.Columns.Add("DC_TRAN_DATE", typeof(string));
                                        table.Columns.Add("DC_TRAN_NO", typeof(string));
                                        table.Columns.Add("DC_SRNO", typeof(string));
                                        table.Columns.Add("GST_RATE", typeof(string));
                                        table.Columns.Add("GST_AMT", typeof(string));
                                        table.Columns.Add("CGST_RATE", typeof(string));
                                        table.Columns.Add("CGST_AMT", typeof(string));
                                        table.Columns.Add("SGST_RATE", typeof(string));
                                        table.Columns.Add("SGST_AMT", typeof(string));
                                        table.Columns.Add("IGST_RATE", typeof(string));
                                        table.Columns.Add("IGST_AMT", typeof(string));
                                        table.Columns.Add("T_AMT", typeof(string));
                                        table.Columns.Add("INV_TRAN_DATE", typeof(string));
                                        table.Columns.Add("INV_TRAN_NO", typeof(string));
                                        table.Columns.Add("INV_SR", typeof(string));
                                        table.Columns.Add("ENTRY_TYPE", typeof(string));
                                        table.Columns.Add("ENDT", typeof(string));
                                        table.Columns.Add("ACT_RATE", typeof(string));
                                        table.Columns.Add("ACT_AMT", typeof(string));
                                        table.Columns.Add("CAL_RATE", typeof(string));
                                        table.Columns.Add("CAL_AMT", typeof(string));
                                        table.Columns.Add("PART_NO", typeof(string));
                                        table.Columns.Add("ADD_PART_NO", typeof(string));
                                        table.Columns.Add("PER_QTY_WT", typeof(string));
                                        table.Columns.Add("TOT_QTY_WT", typeof(string));
                                        table.Columns.Add("EX_DUTY_AMT", typeof(string));
                                        table.Columns.Add("EX_CESS_AMT", typeof(string));
                                        table.Columns.Add("EX_SHCESS_AMT", typeof(string));
                                        table.Columns.Add("CHA_NO", typeof(string));
                                        table.Columns.Add("SERIALNO", typeof(string));
                                        table.Columns.Add("ChallanDate", typeof(string));
                                    }
                                }

                                for (int m = 0; m < DtDetails.Rows.Count; m++)
                                {
                                    drm = table.NewRow();

                                    drm["SCODE"] = DtDetails.Rows[m]["SCODE"].ToString();
                                    drm["PRODUCT_DESC"] = DtDetails.Rows[m]["PRODUCT_DESC"].ToString();
                                    drm["HSN_NO"] = DtDetails.Rows[m]["HSN_NO"].ToString();
                                    drm["RATE"] = DtDetails.Rows[m]["RATE"].ToString();
                                    drm["QTY"] = DtDetails.Rows[m]["QTY"].ToString();
                                    drm["AMT"] = DtDetails.Rows[m]["AMT"].ToString();
                                    drm["DIS_PER"] = DtDetails.Rows[m]["DIS_PER"].ToString();
                                    drm["DIS_AMT"] = DtDetails.Rows[m]["DIS_AMT"].ToString();
                                    drm["G_AMT"] = DtDetails.Rows[m]["G_AMT"].ToString();
                                    drm["GST_RATE"] = DtDetails.Rows[m]["GST_RATE"].ToString();
                                    drm["GST_AMT"] = DtDetails.Rows[m]["GST_AMT"].ToString();
                                    drm["CGST_RATE"] = DtDetails.Rows[m]["CGST_RATE"].ToString();
                                    drm["CGST_AMT"] = DtDetails.Rows[m]["CGST_AMT"].ToString();
                                    drm["SGST_RATE"] = DtDetails.Rows[m]["SGST_RATE"].ToString();
                                    drm["SGST_AMT"] = DtDetails.Rows[m]["SGST_AMT"].ToString();
                                    drm["IGST_RATE"] = DtDetails.Rows[m]["IGST_RATE"].ToString();
                                    drm["IGST_AMT"] = DtDetails.Rows[m]["IGST_AMT"].ToString();
                                    drm["T_AMT"] = DtDetails.Rows[m]["T_AMT"].ToString();
                                    table.Rows.Add(drm);
                                }


                                #endregion

                                ViewState["CurrentTable"] = table;

                                GvStockRecDetails.DataSource = DtDetails;
                                GvStockRecDetails.DataBind();
                                GvStockRecDetails.Enabled = true;
                            }

                            if (DtCharges.Rows.Count > 0)
                            {

                                ViewState["CurrentTable_C"] = DtCharges;
                                GvChagresTranDetails.DataSource = DtCharges;
                                GvChagresTranDetails.DataBind();
                                GvChagresTranDetails.Enabled = true;
                            }

                            if (DtChallan.Rows.Count > 0)
                            {
                                DataTable tblChallan = new DataTable();


                                #region Define Table

                                DataRow drchallan = null;
                                tblChallan.Columns.Add("DCTransDate", typeof(string));
                                tblChallan.Columns.Add("DCTransNo", typeof(string));

                                #endregion
                                for (int m = 0; m < DtChallan.Rows.Count; m++)
                                {
                                    drchallan = tblChallan.NewRow();
                                    drchallan["DCTransNo"] = DtChallan.Rows[m]["DC_TRAN_NO"].ToString();
                                    drchallan["DCTransDate"] = DtChallan.Rows[m]["DC_TRAN_DATE"].ToString();
                                    tblChallan.Rows.Add(drchallan);
                                }

                                ViewState["AddChallanTable"] = tblChallan;
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
                }


                if (e.CommandName == "Viewa")
                {
                    #region SET TEXT ON VIEW
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = REC_ISS_MLogicLayer.GetAllIDWiseREC_ISS_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtCharges = ds.Tables[2];

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
                            HfAODECredit.Value = dt.Rows[0]["CRACODE"].ToString();
                            FillPartySupplierNameOnUpdate(dt.Rows[0]["CRACODE"].ToString());
                            HfACODEDebit.Value = dt.Rows[0]["DRACODE"].ToString();
                            FillDebitACNameOnUpdate(dt.Rows[0]["DRACODE"].ToString());
                            //TxtPONo.Text = dt.Rows[0]["PO_NO"].ToString();
                            //TxtPODate.Text = dt.Rows[0]["PO_DT"].ToString();
                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtLRNo.Text = dt.Rows[0]["LR_NO"].ToString();
                            TxtLRDate.Text = dt.Rows[0]["LR_DATE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtInvoiceNumber.Text = dt.Rows[0]["INV_NUMBER"].ToString();
                            TxtInvoiceDate.Text = Convert.ToDateTime(dt.Rows[0]["INV_DT"].ToString()).ToString("dd-MM-yyyy");
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            DdlSalesType.SelectedValue = dt.Rows[0]["SALES_TYPE"].ToString();
                            DdlRegisterType.SelectedValue = dt.Rows[0]["CST_TYPE"].ToString();
                            DdlTaxCalType.SelectedValue = dt.Rows[0]["TAX_CALTYPE"].ToString();
                            TxtDCNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            TxtDCDate.Text = Convert.ToDateTime(dt.Rows[0]["CHA_DT"].ToString()).ToString("dd-MM-yyyy");
                            DdlFigureFlag.SelectedValue = dt.Rows[0]["FIGURE_FLAG"].ToString();

                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            Session["TRAN_TYPE"] = HfTranType.Value;
                            Session["TRN_TYPE"] = HfTrnType.Value;


                            if (DtDetails.Rows.Count > 0)
                            {
                                GvStockRecDetails.DataSource = DtDetails;
                                GvStockRecDetails.DataBind();
                                GvStockRecDetails.Enabled = false;
                            }

                            if (DtCharges.Rows.Count > 0)
                            {
                                GvChagresTranDetails.DataSource = DtCharges;
                                GvChagresTranDetails.DataBind();
                                GvChagresTranDetails.Enabled = false;
                            }
                        }
                    }

                    #endregion
                    ControllerDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    UserRights();
                }
            }
            catch (Exception ex)
            {

                lblmsg.Text = ex.Message.ToString();
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
                    string str = REC_ISS_MLogicLayer.DeleteSREC_ISS_M_DetailsTaxInvoiceByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value.ToString()));
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
                        lblmsg.Text = "Error:Purchase Tax Invoice Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillREC_ISS_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }



        #region  BIND STOCK DETAILS GRID

        private void SetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SR", typeof(string));
            table.Columns.Add("REF_TRAN_DATE", typeof(string));
            table.Columns.Add("REF_TRAN_NO", typeof(string));
            table.Columns.Add("REF_SRNO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("PRODUCT_DESC", typeof(string));
            table.Columns.Add("HSN_NO", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("RATE", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("DIS_PER", typeof(string));
            table.Columns.Add("DIS_AMT", typeof(string));
            table.Columns.Add("ADD_DIS_PER", typeof(string));
            table.Columns.Add("ADD_DIS_AMT", typeof(string));
            table.Columns.Add("G_AMT", typeof(string));
            table.Columns.Add("ST_PER", typeof(string));
            table.Columns.Add("ST_AMT", typeof(string));
            table.Columns.Add("ADD_ST_PER", typeof(string));
            table.Columns.Add("ADD_ST_AMT", typeof(string));
            table.Columns.Add("DC_TRAN_DATE", typeof(string));
            table.Columns.Add("DC_TRAN_NO", typeof(string));
            table.Columns.Add("DC_SRNO", typeof(string));
            table.Columns.Add("GST_RATE", typeof(string));
            table.Columns.Add("GST_AMT", typeof(string));
            table.Columns.Add("CGST_RATE", typeof(string));
            table.Columns.Add("CGST_AMT", typeof(string));
            table.Columns.Add("SGST_RATE", typeof(string));
            table.Columns.Add("SGST_AMT", typeof(string));
            table.Columns.Add("IGST_RATE", typeof(string));
            table.Columns.Add("IGST_AMT", typeof(string));
            table.Columns.Add("T_AMT", typeof(string));
            table.Columns.Add("INV_TRAN_DATE", typeof(string));
            table.Columns.Add("INV_TRAN_NO", typeof(string));
            table.Columns.Add("INV_SR", typeof(string));
            table.Columns.Add("ENTRY_TYPE", typeof(string));
            table.Columns.Add("ENDT", typeof(string));
            table.Columns.Add("ACT_RATE", typeof(string));
            table.Columns.Add("ACT_AMT", typeof(string));
            table.Columns.Add("CAL_RATE", typeof(string));
            table.Columns.Add("CAL_AMT", typeof(string));
            table.Columns.Add("PART_NO", typeof(string));
            table.Columns.Add("ADD_PART_NO", typeof(string));
            table.Columns.Add("PER_QTY_WT", typeof(string));
            table.Columns.Add("TOT_QTY_WT", typeof(string));
            table.Columns.Add("EX_DUTY_AMT", typeof(string));
            table.Columns.Add("EX_CESS_AMT", typeof(string));
            table.Columns.Add("EX_SHCESS_AMT", typeof(string));
            table.Columns.Add("CHA_NO", typeof(string));
            table.Columns.Add("SERIALNO", typeof(string));
            table.Columns.Add("ChallanDate", typeof(string));



            dr = table.NewRow();

            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SR"] = string.Empty;
            dr["REF_TRAN_DATE"] = string.Empty;
            dr["REF_TRAN_NO"] = string.Empty;
            dr["REF_SRNO"] = string.Empty;
            dr["SCODE"] = string.Empty;
            dr["PRODUCT_DESC"] = string.Empty;
            dr["HSN_NO"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["RATE"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["DIS_PER"] = string.Empty;
            dr["DIS_AMT"] = string.Empty;
            dr["ADD_DIS_PER"] = string.Empty;
            dr["ADD_DIS_AMT"] = string.Empty;
            dr["G_AMT"] = string.Empty;
            dr["ST_PER"] = string.Empty;
            dr["ST_AMT"] = string.Empty;
            dr["ADD_ST_PER"] = string.Empty;
            dr["ADD_ST_AMT"] = string.Empty;
            dr["DC_TRAN_DATE"] = string.Empty;
            dr["DC_TRAN_NO"] = string.Empty;
            dr["DC_SRNO"] = string.Empty;
            dr["GST_RATE"] = string.Empty;
            dr["GST_AMT"] = string.Empty;
            dr["CGST_RATE"] = string.Empty;
            dr["CGST_AMT"] = string.Empty;
            dr["SGST_RATE"] = string.Empty;
            dr["SGST_AMT"] = string.Empty;
            dr["IGST_RATE"] = string.Empty;
            dr["IGST_AMT"] = string.Empty;
            dr["T_AMT"] = string.Empty;
            dr["INV_TRAN_DATE"] = string.Empty;
            dr["INV_TRAN_NO"] = string.Empty;
            dr["INV_SR"] = string.Empty;
            dr["ENTRY_TYPE"] = string.Empty;
            dr["ENDT"] = string.Empty;
            dr["ACT_RATE"] = string.Empty;
            dr["ACT_AMT"] = string.Empty;
            dr["CAL_RATE"] = string.Empty;
            dr["CAL_AMT"] = string.Empty;
            dr["PART_NO"] = string.Empty;
            dr["ADD_PART_NO"] = string.Empty;
            dr["PER_QTY_WT"] = string.Empty;
            dr["TOT_QTY_WT"] = string.Empty;
            dr["EX_DUTY_AMT"] = string.Empty;
            dr["EX_CESS_AMT"] = string.Empty;
            dr["EX_SHCESS_AMT"] = string.Empty;
            dr["CHA_NO"] = string.Empty;
            dr["SERIALNO"] = string.Empty;
            dr["ChallanDate"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvStockRecDetails.DataSource = table;
            GvStockRecDetails.DataBind();
        }


        private void AddNewRowToStockGrid()
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
                        //TextBox TxtSr = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtSr");



                        Label lblSumTotalQty = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalQty"));
                        Label lblCGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                        Label lblSGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                        Label lblIGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                        Label lblSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalAmount"));


                        HiddenField HfDetailSCode = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        HiddenField HfGSTRate = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                        HiddenField HfGSTAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        HiddenField HfDisAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                        HiddenField HfGrossAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGrossAmount");
                        HiddenField HfEntryType = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfEntryType");


                        TextBox TxtChallanNo = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[1].FindControl("TxtChallanNo");
                        TextBox TxtChallanDate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[2].FindControl("TxtChallanDate");
                        TextBox TxtGRNNo = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[3].FindControl("TxtGRNNo");
                        TextBox TxtProductCode = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[4].FindControl("TxtProductCode");
                        TextBox TxtHSNCode = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[5].FindControl("TxtHSNCode");
                        TextBox TxtProductName = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[6].FindControl("TxtProductName");
                        TextBox TxtProductDescrption = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[7].FindControl("TxtProductDescrption");
                        TextBox TxtQty = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[8].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[9].FindControl("TxtRate");
                        TextBox TxtDisRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[10].FindControl("TxtDisRate");
                        TextBox TxtCGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[11].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[12].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[13].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[14].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[15].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[16].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[17].FindControl("TxtTotalAmount");



                        //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["PRODUCT_DESC"] = TxtProductDescrption.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["HSN_NO"] = TxtHSNCode.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = HfAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["DIS_PER"] = TxtDisRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["DIS_AMT"] = HfDisAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["G_AMT"] = HfGrossAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["GST_RATE"] = HfGSTRate.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["CGST_RATE"] = TxtCGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["CGST_AMT"] = TxtCGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SGST_RATE"] = TxtSGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SGST_AMT"] = TxtSGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["IGST_RATE"] = TxtIGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["IGST_AMT"] = TxtIGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["T_AMT"] = TxtTotalAmount.Text.Trim();

                        rowIndex++;

                        double SumTotalQuantity = TotalQuantity();
                        lblSumTotalQty.Text = SumTotalQuantity.ToString();

                        double SumTotalHfAmount = TotalHfAmt();

                        // double SumTotalGrossAmount = TotalGrossAmount();
                        double SumTotalGrossAmount = TotalHfAmt();

                        double SumTotalCGSTAmount = TotalCGSTAmount();
                        lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                        double SumTotalSGSTAmount = TotalSGSTAmount();
                        lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                        double SumTotalIGSTAmount = TotalIGSTAmount();
                        lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                        double SumTotalAmount = TotalAmount();
                        lblSumTotalAmount.Text = SumTotalAmount.ToString();

                        if (SumTotalGrossAmount.ToString() != string.Empty)
                        {
                            ViewState["GrossAmtCurrentTable_Details"] = SumTotalGrossAmount;
                        }

                        if (lblSumTotalAmount.Text != string.Empty)
                        {

                            ViewState["TotalCurrentTable_Details"] = lblSumTotalAmount.Text.Trim();
                        }

                        if (lblCGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalCGSTAmount_Deatils"] = lblCGSTSumTotalAmount.Text.Trim();
                        }

                        if (lblSGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalSGSTAmount_Deatils"] = lblSGSTSumTotalAmount.Text.Trim();
                        }

                        if (lblIGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalIGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text.Trim();
                        }

                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            ViewState["TotalGSTAmount_Deatils"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            ViewState["TotalGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text;
                        }
                        else { }

                        FillNetAmount();
                        TotalAmountCalculationInREC_ISS_M();

                    }


                    drCurrentRow = dtCurrentTable.NewRow();

                    //drCurrentRow["SR"] = "";
                    drCurrentRow["SCODE"] = "0";
                    drCurrentRow["PRODUCT_DESC"] = "";
                    drCurrentRow["HSN_NO"] = "0";
                    drCurrentRow["RATE"] = "0";
                    drCurrentRow["QTY"] = "0";
                    drCurrentRow["AMT"] = "0";
                    drCurrentRow["DIS_PER"] = "0";
                    drCurrentRow["DIS_AMT"] = "0";
                    drCurrentRow["G_AMT"] = "0";
                    drCurrentRow["GST_RATE"] = "0";
                    drCurrentRow["GST_AMT"] = "0";
                    drCurrentRow["CGST_RATE"] = "0";
                    drCurrentRow["CGST_AMT"] = "0";
                    drCurrentRow["SGST_RATE"] = "0";
                    drCurrentRow["SGST_AMT"] = "0";
                    drCurrentRow["IGST_RATE"] = "0";
                    drCurrentRow["IGST_AMT"] = "0";
                    drCurrentRow["T_AMT"] = "0";


                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvStockRecDetails.DataSource = dtCurrentTable;
                    GvStockRecDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousDataStock_Grid();
        }


        private void SetPreviousDataStock_Grid()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {



                        Label lblSumTotalQty = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalQty"));
                        Label lblCGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                        Label lblSGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                        Label lblIGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                        Label lblSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalAmount"));


                        HiddenField HfDetailSCode = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        HiddenField HfGSTRate = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                        HiddenField HfGSTAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        HiddenField HfDisAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                        HiddenField HfGrossAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGrossAmount");
                        HiddenField HfEntryType = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfEntryType");


                        TextBox TxtChallanNo = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[1].FindControl("TxtChallanNo");
                        TextBox TxtChallanDate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[2].FindControl("TxtChallanDate");
                        TextBox TxtGRNNo = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[3].FindControl("TxtGRNNo");
                        TextBox TxtProductCode = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[4].FindControl("TxtProductCode");
                        TextBox TxtHSNCode = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[5].FindControl("TxtHSNCode");
                        TextBox TxtProductName = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[6].FindControl("TxtProductName");
                        TextBox TxtProductDescrption = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[7].FindControl("TxtProductDescrption");
                        TextBox TxtQty = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[8].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[9].FindControl("TxtRate");
                        TextBox TxtDisRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[10].FindControl("TxtDisRate");
                        TextBox TxtCGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[11].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[12].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[13].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[14].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[15].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[16].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[17].FindControl("TxtTotalAmount");


                        //TxtSr.Text = Convert.ToString(i + 1);
                        HfDetailSCode.Value = dt.Rows[i]["SCODE"].ToString();
                        TxtProductDescrption.Text = dt.Rows[i]["PRODUCT_DESC"].ToString();
                        TxtHSNCode.Text = dt.Rows[i]["HSN_NO"].ToString();
                        TxtRate.Text = dt.Rows[i]["RATE"].ToString();
                        TxtQty.Text = dt.Rows[i]["QTY"].ToString();
                        HfAmount.Value = dt.Rows[i]["AMT"].ToString();
                        TxtDisRate.Text = dt.Rows[i]["DIS_PER"].ToString();
                        HfDisAmount.Value = dt.Rows[i]["DIS_AMT"].ToString();
                        HfGrossAmount.Value = dt.Rows[i]["G_AMT"].ToString();
                        HfGSTRate.Value = dt.Rows[i]["GST_RATE"].ToString();
                        HfGSTAmount.Value = dt.Rows[i]["GST_AMT"].ToString();
                        TxtCGSTRate.Text = dt.Rows[i]["CGST_RATE"].ToString();
                        TxtCGSTAmount.Text = dt.Rows[i]["CGST_AMT"].ToString();
                        TxtSGSTRate.Text = dt.Rows[i]["SGST_RATE"].ToString();
                        TxtSGSTAmount.Text = dt.Rows[i]["SGST_AMT"].ToString();
                        TxtIGSTRate.Text = dt.Rows[i]["IGST_RATE"].ToString();
                        TxtIGSTAmount.Text = dt.Rows[i]["IGST_AMT"].ToString();
                        TxtTotalAmount.Text = dt.Rows[i]["T_AMT"].ToString();

                        rowIndex++;


                        double SumTotalQuantity = TotalQuantity();
                        lblSumTotalQty.Text = SumTotalQuantity.ToString();

                        double SumTotalHfAmount = TotalHfAmt();

                        // double SumTotalGrossAmount = TotalGrossAmount();
                        double SumTotalGrossAmount = TotalHfAmt();

                        double SumTotalCGSTAmount = TotalCGSTAmount();
                        lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                        double SumTotalSGSTAmount = TotalSGSTAmount();
                        lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                        double SumTotalIGSTAmount = TotalIGSTAmount();
                        lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                        double SumTotalAmount = TotalAmount();
                        lblSumTotalAmount.Text = SumTotalAmount.ToString();

                        if (SumTotalGrossAmount.ToString() != string.Empty)
                        {
                            ViewState["GrossAmtCurrentTable_Details"] = SumTotalGrossAmount;
                        }

                        if (lblSumTotalAmount.Text != string.Empty)
                        {

                            ViewState["TotalCurrentTable_Details"] = lblSumTotalAmount.Text.Trim();
                        }

                        if (lblCGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalCGSTAmount_Deatils"] = lblCGSTSumTotalAmount.Text.Trim();
                        }

                        if (lblSGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalSGSTAmount_Deatils"] = lblSGSTSumTotalAmount.Text.Trim();
                        }

                        if (lblIGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalIGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text.Trim();
                        }

                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            ViewState["TotalGSTAmount_Deatils"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            ViewState["TotalGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text;
                        }
                        else { }

                        FillNetAmount();
                        TotalAmountCalculationInREC_ISS_M();


                    }
                }
            }
        }

        protected void BtnDeleteRowModelStockDetailGrid_Click(object sender, EventArgs e)
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
                GvStockRecDetails.DataSource = dt;
                GvStockRecDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousDataStock_Grid();
        }

        protected void BtnAddRowModelStockDetailGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToStockGrid();
        }

        #endregion


        protected void GvStockRecDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvStockRecDetails.PageIndex = e.NewPageIndex;
            clear();
        }

        protected void GvStockRecDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField HfDetailSCode = (e.Row.FindControl("HfDetailSCode") as HiddenField);
                    HiddenField HfAmount = (e.Row.FindControl("HfAmount") as HiddenField);
                    HiddenField HfGrossAmount = (e.Row.FindControl("HfGrossAmount") as HiddenField);
                    TextBox TxtProductName = (e.Row.FindControl("TxtProductName") as TextBox);
                    TextBox TxtProductCode = (e.Row.FindControl("TxtProductCode") as TextBox);

                    TextBox TxtChallanNo = (e.Row.FindControl("TxtChallanNo") as TextBox);
                    TextBox TxtChallanDate = (e.Row.FindControl("TxtChallanDate") as TextBox);
                    TextBox TxtGRNNo = (e.Row.FindControl("TxtGRNNo") as TextBox);
                    TextBox TxtHSNCode = (e.Row.FindControl("TxtHSNCode") as TextBox);
                    TextBox TxtProductDescrption = (e.Row.FindControl("TxtProductDescrption") as TextBox);
                    TextBox TxtQty = (e.Row.FindControl("TxtQty") as TextBox);
                    TextBox TxtRate = (e.Row.FindControl("TxtRate") as TextBox);
                    TextBox TxtDisRate = (e.Row.FindControl("TxtDisRate") as TextBox);
                    TextBox TxtCGSTRate = (e.Row.FindControl("TxtCGSTRate") as TextBox);
                    TextBox TxtCGSTAmount = (e.Row.FindControl("TxtCGSTAmount") as TextBox);
                    TextBox TxtSGSTRate = (e.Row.FindControl("TxtSGSTRate") as TextBox);
                    TextBox TxtSGSTAmount = (e.Row.FindControl("TxtSGSTAmount") as TextBox);
                    TextBox TxtIGSTRate = (e.Row.FindControl("TxtIGSTRate") as TextBox);
                    TextBox TxtIGSTAmount = (e.Row.FindControl("TxtIGSTAmount") as TextBox);
                    TextBox TxtTotalAmount = (e.Row.FindControl("TxtTotalAmount") as TextBox);

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

                        }
                        else
                        {
                            TxtProductName.Text = string.Empty;

                        }
                    }



                    if (HfTranType.Value == "L" && HfTrnType.Value == "R")
                    {

                        TxtProductName.Enabled = false;
                        TxtProductCode.Enabled = false;
                        TxtProductDescrption.Enabled = true;
                        TxtChallanNo.Enabled = false;
                        TxtChallanDate.Enabled = false;
                        TxtGRNNo.Enabled = false;
                        TxtHSNCode.Enabled = false;
                        TxtQty.Enabled = false;
                        TxtRate.Enabled = true;
                        TxtDisRate.Enabled = true;
                        TxtCGSTRate.Enabled = false;
                        TxtCGSTAmount.Enabled = false;
                        TxtSGSTRate.Enabled = false;
                        TxtSGSTAmount.Enabled = false;
                        TxtIGSTRate.Enabled = false;
                        TxtIGSTAmount.Enabled = false;
                        TxtTotalAmount.Enabled = false;
                        GvStockRecDetails.Columns[18].Visible = false;
                    }

                    HfGrossAmount.Value = HfAmount.Value;

                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblSumTotalQty = (Label)e.Row.FindControl("lblSumTotalQty");
                    Label lblCGSTSumTotalAmount = (Label)e.Row.FindControl("lblCGSTSumTotalAmount");
                    Label lblSGSTSumTotalAmount = (Label)e.Row.FindControl("lblSGSTSumTotalAmount");
                    Label lblIGSTSumTotalAmount = (Label)e.Row.FindControl("lblIGSTSumTotalAmount");
                    Label lblSumTotalAmount = (Label)e.Row.FindControl("lblSumTotalAmount");



                    double SumTotalQuantity = TotalQuantity();
                    lblSumTotalQty.Text = SumTotalQuantity.ToString();

                    double SumTotalHfAmount = TotalHfAmt();

                    // double SumTotalGrossAmount = TotalGrossAmount();
                    double SumTotalGrossAmount = TotalHfAmt();

                    double SumTotalCGSTAmount = TotalCGSTAmount();
                    lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                    double SumTotalSGSTAmount = TotalSGSTAmount();
                    lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                    double SumTotalIGSTAmount = TotalIGSTAmount();
                    lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                    double SumTotalAmount = TotalAmount();
                    lblSumTotalAmount.Text = SumTotalAmount.ToString();

                    if (SumTotalGrossAmount.ToString() != string.Empty)
                    {
                        ViewState["GrossAmtCurrentTable_Details"] = SumTotalGrossAmount;
                    }

                    if (lblSumTotalAmount.Text != string.Empty)
                    {

                        ViewState["TotalCurrentTable_Details"] = lblSumTotalAmount.Text.Trim();
                    }

                    if (lblCGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalCGSTAmount_Deatils"] = lblCGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblSGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalSGSTAmount_Deatils"] = lblSGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblIGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalIGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text.Trim();
                    }

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        ViewState["TotalGSTAmount_Deatils"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        ViewState["TotalGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text;
                    }
                    else { }

                    FillNetAmount();
                    TotalAmountCalculationInREC_ISS_M();

                }


            }
            catch (Exception)
            {

                throw;
            }
        }



        #region ADD NEW ROW INTO CHARGES GRID

        private void SetInitialRow_ChargesGrid()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SR", typeof(string));
            table.Columns.Add("CCODE", typeof(string));
            table.Columns.Add("PER", typeof(string));
            table.Columns.Add("SIGN", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("ENDT", typeof(string));
            table.Columns.Add("LAB_DESC", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("ST_PER", typeof(string));
            table.Columns.Add("ST_AMT", typeof(string));
            table.Columns.Add("ADD_ST_PER", typeof(string));
            table.Columns.Add("ADD_ST_AMT", typeof(string));
            table.Columns.Add("HSN_NO", typeof(string));
            table.Columns.Add("GST_RATE", typeof(string));
            table.Columns.Add("GST_AMT", typeof(string));
            table.Columns.Add("CGST_RATE", typeof(string));
            table.Columns.Add("CGST_AMT", typeof(string));
            table.Columns.Add("SGST_RATE", typeof(string));
            table.Columns.Add("SGST_AMT", typeof(string));
            table.Columns.Add("IGST_RATE", typeof(string));
            table.Columns.Add("IGST_AMT", typeof(string));
            table.Columns.Add("T_AMT", typeof(string));



            dr = table.NewRow();


            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SR"] = string.Empty;
            dr["CCODE"] = string.Empty;
            dr["PER"] = string.Empty;
            dr["SIGN"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["ENDT"] = string.Empty;
            dr["LAB_DESC"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["ST_PER"] = string.Empty;
            dr["ST_AMT"] = string.Empty;
            dr["ADD_ST_PER"] = string.Empty;
            dr["ADD_ST_AMT"] = string.Empty;
            dr["HSN_NO"] = string.Empty;
            dr["GST_RATE"] = string.Empty;
            dr["GST_AMT"] = string.Empty;
            dr["CGST_RATE"] = string.Empty;
            dr["CGST_AMT"] = string.Empty;
            dr["SGST_RATE"] = string.Empty;
            dr["SGST_AMT"] = string.Empty;
            dr["IGST_RATE"] = string.Empty;
            dr["IGST_AMT"] = string.Empty;
            dr["T_AMT"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["CurrentTable_C"] = table;

            GvChagresTranDetails.DataSource = table;
            GvChagresTranDetails.DataBind();

        }



        private void AddNewRowToGrid_ChargesGrid()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable_C"] != null)
            {
                DataTable dtCurrentTable_C = (DataTable)ViewState["CurrentTable_C"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable_C.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable_C.Rows.Count; i++)
                    {
                        //extract the TextBox values 
                        //TextBox TxtSr = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtSr");



                        Label lblSumTotalQty = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalQty"));
                        Label lblSumGrossAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumGrossAmount"));
                        Label lblCGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                        Label lblSGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                        Label lblIGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                        Label lblSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalAmount"));


                        HiddenField HfChargesCode = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfChargesCode");

                        TextBox TxtHSNCode = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[1].FindControl("TxtHSNCode");
                        TextBox TxtChargesName = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[2].FindControl("TxtChargesName");
                        TextBox TxtQty = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[3].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[4].FindControl("TxtRate");
                        TextBox TxtChargesSign = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[5].FindControl("TxtChargesSign");
                        TextBox TxtChargesAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[6].FindControl("TxtChargesAmount");
                        TextBox TxtCGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[7].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[8].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[9].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[10].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[11].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[12].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[13].FindControl("TxtTotalAmount");


                        HiddenField HfGSTRate = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                        HiddenField HfGSTAmount = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");

                        //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["CCODE"] = HfChargesCode.Value.Trim();
                        dtCurrentTable_C.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["PER"] = TxtRate.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["HSN_NO"] = TxtHSNCode.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["SIGN"] = TxtChargesSign.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["AMT"] = TxtChargesAmount.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["GST_RATE"] = HfGSTRate.Value.Trim();
                        dtCurrentTable_C.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                        dtCurrentTable_C.Rows[i - 1]["CGST_RATE"] = TxtCGSTRate.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["CGST_AMT"] = TxtCGSTAmount.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["SGST_RATE"] = TxtSGSTRate.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["SGST_AMT"] = TxtSGSTAmount.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["IGST_RATE"] = TxtIGSTRate.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["IGST_AMT"] = TxtIGSTAmount.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["T_AMT"] = TxtTotalAmount.Text.Trim();

                        rowIndex++;

                        double SumTotalQuantity = TotalChargesQuantity();
                        lblSumTotalQty.Text = SumTotalQuantity.ToString();

                        double SumTotalGrossAmt = TotalChargesGrossAmount();
                        lblSumGrossAmount.Text = SumTotalGrossAmt.ToString();

                        double SumTotalCGSTAmount = TotalChargesCGSTAmount();
                        lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                        double SumTotalSGSTAmount = TotalChargesSGSTAmount();
                        lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                        double SumTotalIGSTAmount = TotalChargesIGSTAmount();
                        lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                        double SumTotalAmount = TotalChargesTotalAmount();
                        lblSumTotalAmount.Text = SumTotalAmount.ToString();


                        if (lblSumGrossAmount.Text != string.Empty)
                        {
                            ViewState["TotalChargesAmount_Deatils"] = lblSumGrossAmount.Text;
                        }

                        if (lblSumTotalAmount.Text == string.Empty)
                        {
                            lblSumTotalAmount.Text = "0";
                            HfChargesGridTotal.Value = "0";
                        }
                        else
                        {
                            ViewState["TotalCurrentTable_Charges"] = lblSumTotalAmount.Text.Trim();

                        }

                        if (lblCGSTSumTotalAmount.Text == string.Empty)
                        {
                            lblCGSTSumTotalAmount.Text = "0";
                        }
                        else
                        {
                            ViewState["TotalCGSTAmount_Charges"] = lblCGSTSumTotalAmount.Text.Trim();

                        }

                        if (lblSGSTSumTotalAmount.Text == string.Empty)
                        {
                            lblSGSTSumTotalAmount.Text = "0";
                        }
                        else
                        {
                            ViewState["TotalSGSTAmount_Charges"] = lblSGSTSumTotalAmount.Text.Trim();

                        }

                        if (lblIGSTSumTotalAmount.Text == string.Empty)
                        {
                            lblIGSTSumTotalAmount.Text = "0";
                        }
                        else
                        {
                            ViewState["TotalIGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text.Trim();

                        }

                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            ViewState["TotalGSTAmount_Charges"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            ViewState["TotalGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text;
                        }
                        else { }

                        FillNetAmount();
                        TotalAmountCalculationInREC_ISS_M();
                    }

                    drCurrentRow = dtCurrentTable_C.NewRow();
                    //drCurrentRow["SR"] = "";
                    drCurrentRow["CCODE"] = "0";
                    drCurrentRow["QTY"] = "0";
                    drCurrentRow["PER"] = "0";
                    drCurrentRow["HSN_NO"] = "0";
                    drCurrentRow["SIGN"] = "";
                    drCurrentRow["AMT"] = "0";
                    drCurrentRow["GST_RATE"] = "0";
                    drCurrentRow["GST_AMT"] = "0";
                    drCurrentRow["CGST_RATE"] = "0";
                    drCurrentRow["CGST_AMT"] = "0";
                    drCurrentRow["SGST_RATE"] = "0";
                    drCurrentRow["SGST_AMT"] = "0";
                    drCurrentRow["IGST_RATE"] = "0";
                    drCurrentRow["IGST_AMT"] = "0";
                    drCurrentRow["T_AMT"] = "0";

                    dtCurrentTable_C.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable_C"] = dtCurrentTable_C;

                    GvChagresTranDetails.DataSource = dtCurrentTable_C;
                    GvChagresTranDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousData_ChargesGrid();
        }


        private void SetPreviousData_ChargesGrid()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable_C"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable_C"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        Label lblSumTotalQty = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalQty"));
                        Label lblSumGrossAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumGrossAmount"));
                        Label lblCGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                        Label lblSGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                        Label lblIGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                        Label lblSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalAmount"));

                        HiddenField HfChargesCode = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfChargesCode");

                        TextBox TxtHSNCode = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[1].FindControl("TxtHSNCode");
                        TextBox TxtChargesName = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[2].FindControl("TxtChargesName");
                        TextBox TxtQty = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[3].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[4].FindControl("TxtRate");
                        TextBox TxtChargesSign = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[5].FindControl("TxtChargesSign");
                        TextBox TxtChargesAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[6].FindControl("TxtChargesAmount");
                        TextBox TxtCGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[7].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[8].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[9].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[10].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[11].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[12].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[13].FindControl("TxtTotalAmount");

                        HiddenField HfGSTRate = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                        HiddenField HfGSTAmount = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");

                        //TxtSr.Text = Convert.ToString(i + 1);
                        HfChargesCode.Value = dt.Rows[i]["CCODE"].ToString();
                        TxtQty.Text = dt.Rows[i]["QTY"].ToString();
                        TxtRate.Text = dt.Rows[i]["PER"].ToString();
                        TxtChargesSign.Text = dt.Rows[i]["SIGN"].ToString();
                        TxtHSNCode.Text = dt.Rows[i]["HSN_NO"].ToString();
                        TxtChargesAmount.Text = dt.Rows[i]["AMT"].ToString();
                        HfGSTRate.Value = dt.Rows[i]["GST_RATE"].ToString();
                        HfGSTAmount.Value = dt.Rows[i]["GST_AMT"].ToString();
                        TxtCGSTRate.Text = dt.Rows[i]["CGST_RATE"].ToString();
                        TxtCGSTAmount.Text = dt.Rows[i]["CGST_AMT"].ToString();
                        TxtSGSTRate.Text = dt.Rows[i]["SGST_RATE"].ToString();
                        TxtSGSTAmount.Text = dt.Rows[i]["SGST_AMT"].ToString();
                        TxtIGSTRate.Text = dt.Rows[i]["IGST_RATE"].ToString();
                        TxtIGSTAmount.Text = dt.Rows[i]["IGST_AMT"].ToString();
                        TxtTotalAmount.Text = dt.Rows[i]["T_AMT"].ToString();

                        rowIndex++;

                        double SumTotalQuantity = TotalChargesQuantity();
                        lblSumTotalQty.Text = SumTotalQuantity.ToString();

                        double SumTotalGrossAmt = TotalChargesGrossAmount();
                        lblSumGrossAmount.Text = SumTotalGrossAmt.ToString();

                        double SumTotalCGSTAmount = TotalChargesCGSTAmount();
                        lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                        double SumTotalSGSTAmount = TotalChargesSGSTAmount();
                        lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                        double SumTotalIGSTAmount = TotalChargesIGSTAmount();
                        lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                        double SumTotalAmount = TotalChargesTotalAmount();
                        lblSumTotalAmount.Text = SumTotalAmount.ToString();


                        if (lblSumGrossAmount.Text != string.Empty)
                        {
                            ViewState["TotalChargesAmount_Deatils"] = lblSumGrossAmount.Text;
                        }

                        if (lblSumTotalAmount.Text == string.Empty)
                        {
                            lblSumTotalAmount.Text = "0";
                            HfChargesGridTotal.Value = "0";
                        }
                        else
                        {
                            ViewState["TotalCurrentTable_Charges"] = lblSumTotalAmount.Text.Trim();

                        }

                        if (lblCGSTSumTotalAmount.Text == string.Empty)
                        {
                            lblCGSTSumTotalAmount.Text = "0";
                        }
                        else
                        {
                            ViewState["TotalCGSTAmount_Charges"] = lblCGSTSumTotalAmount.Text.Trim();

                        }

                        if (lblSGSTSumTotalAmount.Text == string.Empty)
                        {
                            lblSGSTSumTotalAmount.Text = "0";
                        }
                        else
                        {
                            ViewState["TotalSGSTAmount_Charges"] = lblSGSTSumTotalAmount.Text.Trim();

                        }

                        if (lblIGSTSumTotalAmount.Text == string.Empty)
                        {
                            lblIGSTSumTotalAmount.Text = "0";
                        }
                        else
                        {
                            ViewState["TotalIGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text.Trim();

                        }

                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            ViewState["TotalGSTAmount_Charges"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            ViewState["TotalGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text;
                        }
                        else { }

                        FillNetAmount();
                        TotalAmountCalculationInREC_ISS_M();
                    }
                }
            }
        }

        protected void BtnDeleteRowModelChargesDetailGrid_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex + 1;
            if (ViewState["CurrentTable_C"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable_C"];
                if (dt.Rows.Count > 1)
                {

                    if (gvRow.RowIndex <= dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data
                        dt.Rows.Remove(dt.Rows[rowID - 1]);
                    }
                }
                //Store the current data in ViewState for future reference
                ViewState["CurrentTable_C"] = dt;
                //Re bind the GridView for the updated data
                GvChagresTranDetails.DataSource = dt;
                GvChagresTranDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData_ChargesGrid();
        }

        protected void BtnAddRowModelChargesDetailGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid_ChargesGrid();
        }

        #endregion


        protected void GvChagresTranDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvChagresTranDetails.PageIndex = e.NewPageIndex;
            clear();

        }

        protected void GvChagresTranDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                decimal Amt = 0;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    HiddenField HfChargesCode = (e.Row.FindControl("HfChargesCode") as HiddenField);
                    TextBox TxtHSNCode = (e.Row.FindControl("TxtHSNCode") as TextBox);
                    TextBox TxtChargesName = (e.Row.FindControl("TxtChargesName") as TextBox);
                    TextBox TxtChargesAmount = (e.Row.FindControl("TxtChargesAmount") as TextBox);
                    TextBox TxtQty = (e.Row.FindControl("TxtQty") as TextBox);
                    TextBox TxtRate = (e.Row.FindControl("TxtRate") as TextBox);
                    TextBox TxtChargesSign = (e.Row.FindControl("TxtChargesSign") as TextBox);


                    DataTable DtChargesName = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();

                    if (TxtChargesAmount.Text != string.Empty)
                    {
                        Amt = Amt + Convert.ToDecimal(TxtChargesAmount.Text);
                    }

                    DtChargesName = CHARGES_MASLogicLayer.GetAllCHARGESDetialsForComapnyWise_DDL(Comp_Code);

                    if (HfChargesCode.Value != "0" && HfChargesCode.Value != string.Empty)
                    {
                        DataView Dv = new DataView(DtChargesName);
                        Dv.RowFilter = "CCODE=" + HfChargesCode.Value;
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            TxtChargesName.Text = DtView.Rows[0]["NAME"].ToString();
                            HfChargesCode.Value = DtView.Rows[0]["CCODE"].ToString();
                            TxtHSNCode.Text = DtView.Rows[0]["HSN_NO"].ToString();
                            TxtChargesSign.Text = DtView.Rows[0]["SIGN"].ToString();
                        }
                        else
                        {
                            TxtChargesName.Text = string.Empty;
                            TxtHSNCode.Text = string.Empty;
                            TxtChargesSign.Text = string.Empty;

                        }
                    }

                }



                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblSumTotalQty = (Label)e.Row.FindControl("lblSumTotalQty");
                    Label lblSumGrossAmount = (Label)e.Row.FindControl("lblSumGrossAmount");
                    Label lblCGSTSumTotalAmount = (Label)e.Row.FindControl("lblCGSTSumTotalAmount");
                    Label lblSGSTSumTotalAmount = (Label)e.Row.FindControl("lblSGSTSumTotalAmount");
                    Label lblIGSTSumTotalAmount = (Label)e.Row.FindControl("lblIGSTSumTotalAmount");
                    Label lblSumTotalAmount = (Label)e.Row.FindControl("lblSumTotalAmount");


                    double SumTotalQuantity = TotalChargesQuantity();
                    lblSumTotalQty.Text = SumTotalQuantity.ToString();

                    double SumTotalGrossAmt = TotalChargesGrossAmount();
                    lblSumGrossAmount.Text = SumTotalGrossAmt.ToString();

                    double SumTotalCGSTAmount = TotalChargesCGSTAmount();
                    lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                    double SumTotalSGSTAmount = TotalChargesSGSTAmount();
                    lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                    double SumTotalIGSTAmount = TotalChargesIGSTAmount();
                    lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                    double SumTotalAmount = TotalChargesTotalAmount();
                    lblSumTotalAmount.Text = SumTotalAmount.ToString();


                    if (lblSumGrossAmount.Text != string.Empty)
                    {
                        ViewState["TotalChargesAmount_Deatils"] = lblSumGrossAmount.Text;
                    }

                    if (lblSumTotalAmount.Text == string.Empty)
                    {
                        lblSumTotalAmount.Text = "0";
                        HfChargesGridTotal.Value = "0";
                    }
                    else
                    {
                        ViewState["TotalCurrentTable_Charges"] = lblSumTotalAmount.Text.Trim();

                    }

                    if (lblCGSTSumTotalAmount.Text == string.Empty)
                    {
                        lblCGSTSumTotalAmount.Text = "0";
                    }
                    else
                    {
                        ViewState["TotalCGSTAmount_Charges"] = lblCGSTSumTotalAmount.Text.Trim();

                    }

                    if (lblSGSTSumTotalAmount.Text == string.Empty)
                    {
                        lblSGSTSumTotalAmount.Text = "0";
                    }
                    else
                    {
                        ViewState["TotalSGSTAmount_Charges"] = lblSGSTSumTotalAmount.Text.Trim();

                    }

                    if (lblIGSTSumTotalAmount.Text == string.Empty)
                    {
                        lblIGSTSumTotalAmount.Text = "0";
                    }
                    else
                    {
                        ViewState["TotalIGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text.Trim();

                    }

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        ViewState["TotalGSTAmount_Charges"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        ViewState["TotalGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text;
                    }
                    else { }

                    FillNetAmount();
                    TotalAmountCalculationInREC_ISS_M();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }



        #region Calculation In CHARGES Grid

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetChargesName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CHARGES where COMP_CODE=@COMP_CODE and NAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> ChargesNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargesNames.Add(dt.Rows[i][2].ToString());
            }
            return ChargesNames;
        }

        public void FillOnGridChargesDetailChanged()
        {
            try
            {
                #region Assign To Charges Grid

                int rowIndex = 0;

                if (ViewState["CurrentTable_C"] != null)
                {
                    DataTable dtCurrentTable_C = (DataTable)ViewState["CurrentTable_C"];

                    if (dtCurrentTable_C.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable_C.Rows.Count; i++)
                        {
                            //extract the TextBox values 
                            //TextBox TxtSr = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtSr");



                            Label lblSumTotalQty = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalQty"));
                            Label lblSumGrossAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumGrossAmount"));
                            Label lblCGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                            Label lblSGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                            Label lblIGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                            Label lblSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalAmount"));


                            HiddenField HfChargesCode = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfChargesCode");

                            TextBox TxtHSNCode = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[1].FindControl("TxtHSNCode");
                            TextBox TxtChargesName = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[2].FindControl("TxtChargesName");
                            TextBox TxtQty = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[3].FindControl("TxtQty");
                            TextBox TxtRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[4].FindControl("TxtRate");
                            TextBox TxtChargesSign = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[5].FindControl("TxtChargesSign");
                            TextBox TxtChargesAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[6].FindControl("TxtChargesAmount");
                            TextBox TxtCGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[7].FindControl("TxtCGSTRate");
                            TextBox TxtCGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[8].FindControl("TxtCGSTAmount");
                            TextBox TxtSGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[9].FindControl("TxtSGSTRate");
                            TextBox TxtSGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[10].FindControl("TxtSGSTAmount");
                            TextBox TxtIGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[11].FindControl("TxtIGSTRate");
                            TextBox TxtIGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[12].FindControl("TxtIGSTAmount");
                            TextBox TxtTotalAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[13].FindControl("TxtTotalAmount");


                            HiddenField HfGSTRate = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                            HiddenField HfGSTAmount = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");

                            //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["CCODE"] = HfChargesCode.Value.Trim();
                            dtCurrentTable_C.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["PER"] = TxtRate.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["HSN_NO"] = TxtHSNCode.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["SIGN"] = TxtChargesSign.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["AMT"] = TxtChargesAmount.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["GST_RATE"] = HfGSTRate.Value.Trim();
                            dtCurrentTable_C.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                            dtCurrentTable_C.Rows[i - 1]["CGST_RATE"] = TxtCGSTRate.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["CGST_AMT"] = TxtCGSTAmount.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["SGST_RATE"] = TxtSGSTRate.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["SGST_AMT"] = TxtSGSTAmount.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["IGST_RATE"] = TxtIGSTRate.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["IGST_AMT"] = TxtIGSTAmount.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["T_AMT"] = TxtTotalAmount.Text.Trim();

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

        protected void TxtChargesName_TextChanged1(object sender, EventArgs e)

        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfChargesCode = (HiddenField)row.Cells[0].FindControl("HfChargesCode");
                TextBox TxtHSNCode = (TextBox)row.Cells[1].FindControl("TxtHSNCode");
                TextBox TxtChargesName = (TextBox)row.Cells[2].FindControl("TxtChargesName");
                TextBox TxtQty = (TextBox)row.Cells[3].FindControl("TxtQty");
                TextBox TxtRateString = (TextBox)row.Cells[4].FindControl("TxtRate");
                TextBox TxtChargesSign = (TextBox)row.Cells[5].FindControl("TxtChargesSign");
                TextBox TxtCGSTRateString = (TextBox)row.Cells[7].FindControl("TxtCGSTRate");
                TextBox TxtSGSTRateString = (TextBox)row.Cells[8].FindControl("TxtSGSTRate");
                TextBox TxtIGSTRateString = (TextBox)row.Cells[9].FindControl("TxtIGSTRate");

                HiddenField HfGSTRateString = (HiddenField)row.Cells[0].FindControl("HfGSTRate");


                DataTable DtChargesName = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtChargesName = CHARGES_MASLogicLayer.GetAllCHARGESDetialsForComapnyWise_DDL(Comp_Code);
                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtChargesName);
                    Dv.RowFilter = "NAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfChargesCode.Value = DtView.Rows[0]["CCODE"].ToString();
                        TxtHSNCode.Text = DtView.Rows[0]["HSN_NO"].ToString();
                        TxtChargesSign.Text = DtView.Rows[0]["SIGN"].ToString();
                        TxtRateString.Text = DtView.Rows[0]["PER"].ToString();
                        FillOnGridChargesDetailChanged();


                        if (HfChargesCode.Value != string.Empty && DdlPartyType.SelectedIndex != 0)
                        {
                            DataTable DsStock = CHARGES_MASLogicLayer.CHARGES_MAS_CHARGES_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(HfChargesCode.Value), DdlPartyType.SelectedValue);
                            if (DsStock.Rows.Count > 0)
                            {

                                TxtRateString.Text = DsStock.Rows[0]["PER"].ToString();
                                HfGSTRateString.Value = DsStock.Rows[0]["GST_RATE"].ToString();
                                TxtCGSTRateString.Text = DsStock.Rows[0]["CGST_RATE"].ToString();
                                TxtSGSTRateString.Text = DsStock.Rows[0]["SGST_RATE"].ToString();
                                TxtIGSTRateString.Text = DsStock.Rows[0]["IGST_RATE"].ToString();
                            }



                            else
                            {
                                //  TxtRateString.Text = "0";
                                HfGSTRateString.Value = "0";
                                TxtCGSTRateString.Text = "0";
                                TxtSGSTRateString.Text = "0";
                                TxtIGSTRateString.Text = "0";
                            }
                        }
                        else
                        {
                            // TxtRateString.Text = "0";
                            HfGSTRateString.Value = "0";
                            TxtCGSTRateString.Text = "0";
                            TxtSGSTRateString.Text = "0";
                            TxtIGSTRateString.Text = "0";
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                Label lblSumTotalQty = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalQty"));
                Label lblSumGrossAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumGrossAmount"));
                Label lblCGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                Label lblSGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                Label lblIGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                Label lblSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalAmount"));

                TextBox TxtRateString = (TextBox)row.Cells[4].FindControl("TxtRate");
                TextBox TxtChargesAmount = (TextBox)row.Cells[6].FindControl("TxtChargesAmount");


                TextBox T_AMTString = (TextBox)row.Cells[13].FindControl("TxtTotalAmount");
                TextBox CGST_RATEString = (TextBox)row.Cells[7].FindControl("TxtCGSTRate");
                TextBox SGST_RATEString = (TextBox)row.Cells[9].FindControl("TxtSGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[8].FindControl("TxtCGSTAmount");
                TextBox SGST_AMTString = (TextBox)row.Cells[10].FindControl("TxtSGSTAmount");

                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                if (txt.Text.Trim() != string.Empty && TxtRateString.Text.Trim() != string.Empty)
                {
                    TxtChargesAmount.Text = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtRateString.Text.Trim()));



                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Text = ((Convert.ToDouble(TxtChargesAmount.Text.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                        SGST_AMTString.Text = ((Convert.ToDouble(TxtChargesAmount.Text.Trim()) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                        double d;
                        d = ((Convert.ToDouble(TxtChargesAmount.Text.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                        T_AMTString.Text = Convert.ToString(d);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        TextBox IGST_RATEString = (TextBox)row.Cells[10].FindControl("TxtIGSTRate");
                        TextBox IGST_AMTString = (TextBox)row.Cells[11].FindControl("TxtIGSTAmount");

                        IGST_AMTString.Text = ((Convert.ToDouble(TxtChargesAmount.Text.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Text;
                        T_AMTString.Text = ((Convert.ToDouble(TxtChargesAmount.Text.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();
                    }



                    double SumTotalQuantity = TotalChargesQuantity();
                    lblSumTotalQty.Text = SumTotalQuantity.ToString();

                    double SumTotalGrossAmt = TotalChargesGrossAmount();
                    lblSumGrossAmount.Text = SumTotalGrossAmt.ToString();

                    double SumTotalCGSTAmount = TotalChargesCGSTAmount();
                    lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                    double SumTotalSGSTAmount = TotalChargesSGSTAmount();
                    lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                    double SumTotalIGSTAmount = TotalChargesIGSTAmount();
                    lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                    double SumTotalAmount = TotalChargesTotalAmount();
                    lblSumTotalAmount.Text = SumTotalAmount.ToString();


                    if (lblSumGrossAmount.Text != string.Empty)
                    {
                        ViewState["TotalChargesAmount_Deatils"] = lblSumGrossAmount.Text;
                    }

                    if (lblSumTotalAmount.Text == string.Empty)
                    {
                        lblSumTotalAmount.Text = "0";
                        HfChargesGridTotal.Value = "0";
                    }
                    else
                    {
                        ViewState["TotalCurrentTable_Charges"] = lblSumTotalAmount.Text.Trim();

                    }

                    if (lblCGSTSumTotalAmount.Text == string.Empty)
                    {
                        lblCGSTSumTotalAmount.Text = "0";
                    }
                    else
                    {
                        ViewState["TotalCGSTAmount_Charges"] = lblCGSTSumTotalAmount.Text.Trim();

                    }

                    if (lblSGSTSumTotalAmount.Text == string.Empty)
                    {
                        lblSGSTSumTotalAmount.Text = "0";
                    }
                    else
                    {
                        ViewState["TotalSGSTAmount_Charges"] = lblSGSTSumTotalAmount.Text.Trim();

                    }

                    if (lblIGSTSumTotalAmount.Text == string.Empty)
                    {
                        lblIGSTSumTotalAmount.Text = "0";
                    }
                    else
                    {
                        ViewState["TotalIGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text.Trim();

                    }

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        ViewState["TotalGSTAmount_Charges"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        ViewState["TotalGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text;
                    }
                    else { }

                    FillNetAmount();
                    TotalAmountCalculationInREC_ISS_M();
                    FillOnGridChargesDetailChanged();
                }




                else
                {
                    TxtChargesAmount.Text = Convert.ToString(Convert.ToDouble(0));
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

                Label lblSumTotalQty = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalQty"));
                Label lblSumGrossAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumGrossAmount"));
                Label lblCGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                Label lblSGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                Label lblIGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                Label lblSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalAmount"));

                TextBox TxtQty = (TextBox)row.Cells[3].FindControl("TxtQty");
                TextBox TxtChargesAmount = (TextBox)row.Cells[6].FindControl("TxtChargesAmount");

                TextBox T_AMTString = (TextBox)row.Cells[13].FindControl("TxtTotalAmount");
                TextBox CGST_RATEString = (TextBox)row.Cells[7].FindControl("TxtCGSTRate");
                TextBox SGST_RATEString = (TextBox)row.Cells[9].FindControl("TxtSGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[8].FindControl("TxtCGSTAmount");
                TextBox SGST_AMTString = (TextBox)row.Cells[10].FindControl("TxtSGSTAmount");

                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                if (TxtQty.Text == string.Empty)
                {
                    TxtQty.Text = "0";
                }


                if (txt.Text.Trim() != string.Empty && TxtQty.Text.Trim() != string.Empty)
                {
                    TxtChargesAmount.Text = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtQty.Text.Trim()));


                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Text = ((Convert.ToDouble(TxtChargesAmount.Text.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                        SGST_AMTString.Text = ((Convert.ToDouble(TxtChargesAmount.Text.Trim()) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                        double d;
                        d = ((Convert.ToDouble(TxtChargesAmount.Text.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                        T_AMTString.Text = Convert.ToString(d);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        TextBox IGST_RATEString = (TextBox)row.Cells[10].FindControl("TxtIGSTRate");
                        TextBox IGST_AMTString = (TextBox)row.Cells[11].FindControl("TxtIGSTAmount");

                        IGST_AMTString.Text = ((Convert.ToDouble(TxtChargesAmount.Text.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Text;
                        T_AMTString.Text = ((Convert.ToDouble(TxtChargesAmount.Text.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();
                    }


                    double SumTotalQuantity = TotalChargesQuantity();
                    lblSumTotalQty.Text = SumTotalQuantity.ToString();

                    double SumTotalGrossAmt = TotalChargesGrossAmount();
                    lblSumGrossAmount.Text = SumTotalGrossAmt.ToString();

                    double SumTotalCGSTAmount = TotalChargesCGSTAmount();
                    lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                    double SumTotalSGSTAmount = TotalChargesSGSTAmount();
                    lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                    double SumTotalIGSTAmount = TotalChargesIGSTAmount();
                    lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                    double SumTotalAmount = TotalChargesTotalAmount();
                    lblSumTotalAmount.Text = SumTotalAmount.ToString();


                    if (lblSumGrossAmount.Text != string.Empty)
                    {
                        ViewState["TotalChargesAmount_Deatils"] = lblSumGrossAmount.Text;
                    }

                    if (lblSumTotalAmount.Text == string.Empty)
                    {
                        lblSumTotalAmount.Text = "0";
                        HfChargesGridTotal.Value = "0";
                    }
                    else
                    {
                        ViewState["TotalCurrentTable_Charges"] = lblSumTotalAmount.Text.Trim();

                    }

                    if (lblCGSTSumTotalAmount.Text == string.Empty)
                    {
                        lblCGSTSumTotalAmount.Text = "0";
                    }
                    else
                    {
                        ViewState["TotalCGSTAmount_Charges"] = lblCGSTSumTotalAmount.Text.Trim();

                    }

                    if (lblSGSTSumTotalAmount.Text == string.Empty)
                    {
                        lblSGSTSumTotalAmount.Text = "0";
                    }
                    else
                    {
                        ViewState["TotalSGSTAmount_Charges"] = lblSGSTSumTotalAmount.Text.Trim();

                    }

                    if (lblIGSTSumTotalAmount.Text == string.Empty)
                    {
                        lblIGSTSumTotalAmount.Text = "0";
                    }
                    else
                    {
                        ViewState["TotalIGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text.Trim();

                    }

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        ViewState["TotalGSTAmount_Charges"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        ViewState["TotalGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text;
                    }
                    else { }

                    FillNetAmount();
                    TotalAmountCalculationInREC_ISS_M();
                    FillOnGridChargesDetailChanged();
                }


                else
                {
                    TxtChargesAmount.Text = Convert.ToString(Convert.ToDouble(0));
                }
            }

            catch (Exception)
            {

                throw;
            }
        }




        #endregion






        #region Calculation For Stock Details Grid


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
                            //TextBox TxtSr = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtSr");



                            Label lblSumTotalQty = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalQty"));
                            Label lblCGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                            Label lblSGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                            Label lblIGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                            Label lblSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalAmount"));


                            HiddenField HfDetailSCode = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                            HiddenField HfGSTRate = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                            HiddenField HfGSTAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                            HiddenField HfAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                            HiddenField HfDisAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                            HiddenField HfGrossAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGrossAmount");
                            HiddenField HfEntryType = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfEntryType");


                            TextBox TxtChallanNo = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[1].FindControl("TxtChallanNo");
                            TextBox TxtChallanDate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[2].FindControl("TxtChallanDate");
                            TextBox TxtGRNNo = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[3].FindControl("TxtGRNNo");
                            TextBox TxtProductCode = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[4].FindControl("TxtProductCode");
                            TextBox TxtHSNCode = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[5].FindControl("TxtHSNCode");
                            TextBox TxtProductName = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[6].FindControl("TxtProductName");
                            TextBox TxtProductDescrption = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[7].FindControl("TxtProductDescrption");
                            TextBox TxtQty = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[8].FindControl("TxtQty");
                            TextBox TxtRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[9].FindControl("TxtRate");
                            TextBox TxtDisRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[10].FindControl("TxtDisRate");
                            TextBox TxtCGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[11].FindControl("TxtCGSTRate");
                            TextBox TxtCGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[12].FindControl("TxtCGSTAmount");
                            TextBox TxtSGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[13].FindControl("TxtSGSTRate");
                            TextBox TxtSGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[14].FindControl("TxtSGSTAmount");
                            TextBox TxtIGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[15].FindControl("TxtIGSTRate");
                            TextBox TxtIGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[16].FindControl("TxtIGSTAmount");
                            TextBox TxtTotalAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[17].FindControl("TxtTotalAmount");



                            //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["PRODUCT_DESC"] = TxtProductDescrption.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["HSN_NO"] = TxtHSNCode.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["AMT"] = HfAmount.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["DIS_PER"] = TxtDisRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["DIS_AMT"] = HfDisAmount.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["G_AMT"] = HfGrossAmount.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["GST_RATE"] = HfGSTRate.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["CGST_RATE"] = TxtCGSTRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["CGST_AMT"] = TxtCGSTAmount.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["SGST_RATE"] = TxtSGSTRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["SGST_AMT"] = TxtSGSTAmount.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["IGST_RATE"] = TxtIGSTRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["IGST_AMT"] = TxtIGSTAmount.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["T_AMT"] = TxtTotalAmount.Text.Trim();

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

        protected void TxtProductCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");
                TextBox TxtProductName = (TextBox)row.Cells[7].FindControl("TxtProductName");
                TextBox TxtHsn = (TextBox)row.Cells[6].FindControl("TxtHSNCode");
                TextBox TxtRateString = (TextBox)row.Cells[10].FindControl("TxtRate");

                HiddenField HfGSTRateString = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                TextBox TxtCGSTRateString = (TextBox)row.Cells[12].FindControl("TxtCGSTRate");
                TextBox TxtSGSTRateString = (TextBox)row.Cells[14].FindControl("TxtSGSTRate");
                TextBox TxtIGSTRateString = (TextBox)row.Cells[16].FindControl("TxtIGSTRate");

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
                                HfGSTRateString.Value = DsStock.Rows[0]["GST_RATE"].ToString();
                                TxtCGSTRateString.Text = DsStock.Rows[0]["CGST_RATE"].ToString();
                                TxtSGSTRateString.Text = DsStock.Rows[0]["SGST_RATE"].ToString();
                                TxtIGSTRateString.Text = DsStock.Rows[0]["IGST_RATE"].ToString();
                            }
                            else
                            {
                                TxtRateString.Text = "0";
                                HfGSTRateString.Value = "0";
                                TxtCGSTRateString.Text = "0";
                                TxtSGSTRateString.Text = "0";
                                TxtIGSTRateString.Text = "0";


                            }
                        }

                        else
                        {
                            TxtRateString.Text = "0";
                            HfGSTRateString.Value = "0";
                            TxtCGSTRateString.Text = "0";
                            TxtSGSTRateString.Text = "0";
                            TxtIGSTRateString.Text = "0";
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

                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");
                TextBox TxtProductCode = (TextBox)row.Cells[5].FindControl("TxtProductCode");
                TextBox TxtHsn = (TextBox)row.Cells[6].FindControl("TxtHSNCode");
                TextBox TxtRateString = (TextBox)row.Cells[10].FindControl("TxtRate");

                HiddenField HfGSTRateString = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                TextBox TxtCGSTRateString = (TextBox)row.Cells[12].FindControl("TxtCGSTRate");
                TextBox TxtSGSTRateString = (TextBox)row.Cells[14].FindControl("TxtSGSTRate");
                TextBox TxtIGSTRateString = (TextBox)row.Cells[16].FindControl("TxtIGSTRate");

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
                                HfGSTRateString.Value = DsStock.Rows[0]["GST_RATE"].ToString();
                                TxtCGSTRateString.Text = DsStock.Rows[0]["CGST_RATE"].ToString();
                                TxtSGSTRateString.Text = DsStock.Rows[0]["SGST_RATE"].ToString();
                                TxtIGSTRateString.Text = DsStock.Rows[0]["IGST_RATE"].ToString();
                            }

                            else
                            {
                                TxtRateString.Text = "0";
                                HfGSTRateString.Value = "0";
                                TxtCGSTRateString.Text = "0";
                                TxtSGSTRateString.Text = "0";
                                TxtIGSTRateString.Text = "0";


                            }
                        }


                        else
                        {
                            TxtRateString.Text = "0";
                            HfGSTRateString.Value = "0";
                            TxtCGSTRateString.Text = "0";
                            TxtSGSTRateString.Text = "0";
                            TxtIGSTRateString.Text = "0";
                        }
                    }


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

                Label lblSumTotalQty = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalQty"));
                Label lblCGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                Label lblSGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                Label lblIGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                Label lblSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalAmount"));

                TextBox TxtQty = (TextBox)row.Cells[9].FindControl("TxtQty");
                HiddenField HfAmount = (HiddenField)row.Cells[0].FindControl("HfAmount");
                HiddenField HfDisAmount = (HiddenField)row.Cells[0].FindControl("HfDisAmount");
                HiddenField HfGrossAmount = (HiddenField)row.Cells[0].FindControl("HfGrossAmount");


                TextBox TxtDisRate = (TextBox)row.Cells[11].FindControl("TxtDisRate");
                TextBox CGST_RATEString = (TextBox)row.Cells[12].FindControl("TxtCGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[13].FindControl("TxtCGSTAmount");
                TextBox SGST_RATEString = (TextBox)row.Cells[14].FindControl("TxtSGSTRate");
                TextBox SGST_AMTString = (TextBox)row.Cells[15].FindControl("TxtSGSTAmount");

                TextBox T_AMTString = (TextBox)row.Cells[17].FindControl("TxtTotalAmount");

                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                if (TxtQty.Text == string.Empty)
                {
                    TxtQty.Text = "0";
                }

                //ViewState["TotalStockDetailsAmount_Deatils"] = txt.Text.Trim();

                if (txt.Text.Trim() != string.Empty && TxtQty.Text.Trim() != string.Empty)
                {
                    HfAmount.Value = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtQty.Text.Trim()));
                    HfGrossAmount.Value = HfAmount.Value;


                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Text = ((Convert.ToDouble(HfAmount.Value.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                        SGST_AMTString.Text = ((Convert.ToDouble(HfAmount.Value.Trim()) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                        double d;
                        d = ((Convert.ToDouble(HfAmount.Value.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                        T_AMTString.Text = Convert.ToString(d);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        TextBox IGST_RATEString = (TextBox)row.Cells[16].FindControl("TxtIGSTRate");
                        TextBox IGST_AMTString = (TextBox)row.Cells[17].FindControl("TxtIGSTAmount");

                        IGST_AMTString.Text = ((Convert.ToDouble(HfAmount.Value.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Text;
                        T_AMTString.Text = ((Convert.ToDouble(HfAmount.Value.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();
                    }





                    double SumTotalQuantity = TotalQuantity();
                    lblSumTotalQty.Text = SumTotalQuantity.ToString();

                    double SumTotalHfAmount = TotalHfAmt();

                  // double SumTotalGrossAmount = TotalGrossAmount();
                    double SumTotalGrossAmount = TotalHfAmt();

                    double SumTotalCGSTAmount = TotalCGSTAmount();
                    lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                    double SumTotalSGSTAmount = TotalSGSTAmount();
                    lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                    double SumTotalIGSTAmount = TotalIGSTAmount();
                    lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                    double SumTotalAmount = TotalAmount();
                    lblSumTotalAmount.Text = SumTotalAmount.ToString();

                    if (SumTotalGrossAmount.ToString() != string.Empty)
                    {
                        ViewState["GrossAmtCurrentTable_Details"] = SumTotalGrossAmount;
                    }

                    if (lblSumTotalAmount.Text != string.Empty)
                    {

                        ViewState["TotalCurrentTable_Details"] = lblSumTotalAmount.Text.Trim();
                    }

                    if (lblCGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalCGSTAmount_Deatils"] = lblCGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblSGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalSGSTAmount_Deatils"] = lblSGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblIGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalIGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text.Trim();
                    }

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        ViewState["TotalGSTAmount_Deatils"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        ViewState["TotalGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text;
                    }
                    else { }

                    FillNetAmount();
                    TotalAmountCalculationInREC_ISS_M();
                    FillOnGridDetailChanged();
                }

                else
                {
                    HfAmount.Value = Convert.ToString(Convert.ToDouble(0));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtDisRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                if (validation.ispercentage(txt.Text.Trim()))
                {

                    Label lblSumTotalQty = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalQty"));
                    Label lblCGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                    Label lblSGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                    Label lblIGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                    Label lblSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalAmount"));

                    TextBox TxtQuantityString = (TextBox)row.Cells[9].FindControl("TxtQty");
                    TextBox TxtRateString = (TextBox)row.Cells[10].FindControl("TxtRate");
                    HiddenField HfAmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");
                    HiddenField HfDisAmount = (HiddenField)row.Cells[0].FindControl("HfDisAmount");
                    HiddenField HfGrossAmount = (HiddenField)row.Cells[0].FindControl("HfGrossAmount");


                    TextBox TxtDisRate = (TextBox)row.Cells[11].FindControl("TxtDisRate");
                    TextBox CGST_RATEString = (TextBox)row.Cells[12].FindControl("TxtCGSTRate");
                    TextBox CGST_AMTString = (TextBox)row.Cells[13].FindControl("TxtCGSTAmount");
                    TextBox SGST_RATEString = (TextBox)row.Cells[14].FindControl("TxtSGSTRate");
                    TextBox SGST_AMTString = (TextBox)row.Cells[15].FindControl("TxtSGSTAmount");

                    TextBox T_AMTString = (TextBox)row.Cells[17].FindControl("TxtTotalAmount");

                    HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                    HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");


                    if (txt.Text.Trim() != string.Empty && TxtQuantityString.Text != string.Empty && TxtRateString.Text != string.Empty)
                    {
                        //  HfAmountString.Value = Convert.ToString(Convert.ToDouble(TxtRateString.Text.Trim()) * Convert.ToDouble(TxtQuantityString.Text.Trim()));

                        double disamt, amt;

                        amt = (Convert.ToDouble(TxtRateString.Text) * Convert.ToDouble(TxtQuantityString.Text));
                        HfAmountString.Value = Convert.ToString(amt);

                        HfDisAmount.Value = ((amt * Convert.ToDouble(txt.Text)) / 100).ToString();
                        disamt = Convert.ToDouble(HfAmountString.Value) - Convert.ToDouble(HfDisAmount.Value);
                        HfGrossAmount.Value = disamt.ToString();


                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            CGST_AMTString.Text = (((disamt) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                            SGST_AMTString.Text = (((disamt) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                            HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                            double d;
                            d = ((disamt) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                            T_AMTString.Text = Convert.ToString(d);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            TextBox IGST_RATEString = (TextBox)row.Cells[11].FindControl("TxtIGSTRate");
                            TextBox IGST_AMTString = (TextBox)row.Cells[12].FindControl("TxtIGSTAmount");

                            IGST_AMTString.Text = (((disamt) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                            HfGSTAmount.Value = IGST_AMTString.Text;
                            T_AMTString.Text = ((disamt) + Convert.ToDouble(IGST_AMTString.Text)).ToString();
                        }



                        double SumTotalQuantity = TotalQuantity();
                        lblSumTotalQty.Text = SumTotalQuantity.ToString();

                        double SumTotalHfAmount = TotalHfAmt();

                         double SumTotalGrossAmount = TotalGrossAmount();
                        //double SumTotalGrossAmount = TotalHfAmt();

                        double SumTotalCGSTAmount = TotalCGSTAmount();
                        lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                        double SumTotalSGSTAmount = TotalSGSTAmount();
                        lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                        double SumTotalIGSTAmount = TotalIGSTAmount();
                        lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                        double SumTotalAmount = TotalAmount();
                        lblSumTotalAmount.Text = SumTotalAmount.ToString();

                        if (SumTotalGrossAmount.ToString() != string.Empty)
                        {
                            ViewState["GrossAmtCurrentTable_Details"] = SumTotalGrossAmount;
                        }

                        if (lblSumTotalAmount.Text != string.Empty)
                        {

                            ViewState["TotalCurrentTable_Details"] = lblSumTotalAmount.Text.Trim();
                        }

                        if (lblCGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalCGSTAmount_Deatils"] = lblCGSTSumTotalAmount.Text.Trim();
                        }

                        if (lblSGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalSGSTAmount_Deatils"] = lblSGSTSumTotalAmount.Text.Trim();
                        }

                        if (lblIGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalIGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text.Trim();
                        }

                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            ViewState["TotalGSTAmount_Deatils"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            ViewState["TotalGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text;
                        }
                        else { }

                        FillNetAmount();
                        TotalAmountCalculationInREC_ISS_M();
                        FillOnGridDetailChanged();
                    }

                    else
                    {
                        HfGrossAmount.Value = Convert.ToString(Convert.ToDouble(0));
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




        protected void TxtQty_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                Label lblSumTotalQty = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalQty"));
                Label lblCGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                Label lblSGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                Label lblIGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                Label lblSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalAmount"));

                TextBox TxtRate = (TextBox)row.Cells[10].FindControl("TxtRate");
                HiddenField HfAmount = (HiddenField)row.Cells[0].FindControl("HfAmount");
                HiddenField HfDisAmount = (HiddenField)row.Cells[0].FindControl("HfDisAmount");
                HiddenField HfGrossAmount = (HiddenField)row.Cells[0].FindControl("HfGrossAmount");


                TextBox TxtDisRate = (TextBox)row.Cells[11].FindControl("TxtDisRate");
                TextBox CGST_RATEString = (TextBox)row.Cells[12].FindControl("TxtCGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[13].FindControl("TxtCGSTAmount");
                TextBox SGST_RATEString = (TextBox)row.Cells[14].FindControl("TxtSGSTRate");
                TextBox SGST_AMTString = (TextBox)row.Cells[15].FindControl("TxtSGSTAmount");

                TextBox T_AMTString = (TextBox)row.Cells[17].FindControl("TxtTotalAmount");

                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                if (TxtRate.Text == string.Empty)
                {
                    TxtRate.Text = "0";
                }

                //  ViewState["TotalStockDetailsAmount_Deatils"] = TxtRate.Text.Trim();

                if (txt.Text.Trim() != string.Empty && TxtRate.Text.Trim() != string.Empty)
                {
                    HfAmount.Value = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtRate.Text.Trim()));
                    HfGrossAmount.Value = HfAmount.Value;


                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Text = ((Convert.ToDouble(HfAmount.Value.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                        SGST_AMTString.Text = ((Convert.ToDouble(HfAmount.Value.Trim()) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                        double d;
                        d = ((Convert.ToDouble(HfAmount.Value.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                        T_AMTString.Text = Convert.ToString(d);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        TextBox IGST_RATEString = (TextBox)row.Cells[16].FindControl("TxtIGSTRate");
                        TextBox IGST_AMTString = (TextBox)row.Cells[17].FindControl("TxtIGSTAmount");

                        IGST_AMTString.Text = ((Convert.ToDouble(HfAmount.Value.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Text;
                        T_AMTString.Text = ((Convert.ToDouble(HfAmount.Value.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();
                    }




                    double SumTotalQuantity = TotalQuantity();
                    lblSumTotalQty.Text = SumTotalQuantity.ToString();

                    double SumTotalHfAmount = TotalHfAmt();

                    // double SumTotalGrossAmount = TotalGrossAmount();
                    double SumTotalGrossAmount = TotalHfAmt();

                    double SumTotalCGSTAmount = TotalCGSTAmount();
                    lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                    double SumTotalSGSTAmount = TotalSGSTAmount();
                    lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                    double SumTotalIGSTAmount = TotalIGSTAmount();
                    lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                    double SumTotalAmount = TotalAmount();
                    lblSumTotalAmount.Text = SumTotalAmount.ToString();

                    if (SumTotalGrossAmount.ToString() != string.Empty)
                    {
                        ViewState["GrossAmtCurrentTable_Details"] = SumTotalGrossAmount;
                    }

                    if (lblSumTotalAmount.Text != string.Empty)
                    {

                        ViewState["TotalCurrentTable_Details"] = lblSumTotalAmount.Text.Trim();
                    }

                    if (lblCGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalCGSTAmount_Deatils"] = lblCGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblSGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalSGSTAmount_Deatils"] = lblSGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblIGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalIGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text.Trim();
                    }

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        ViewState["TotalGSTAmount_Deatils"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        ViewState["TotalGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text;
                    }
                    else { }

                    FillNetAmount();
                    TotalAmountCalculationInREC_ISS_M();
                    FillOnGridDetailChanged();

                }



                else
                {
                    HfAmount.Value = Convert.ToString(Convert.ToDouble(0));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        #endregion



        #region Add Challan Process 



        protected void BtnAddChallan_Click(object sender, EventArgs e)
        {
            try
            {
                if (HfAODECredit.Value == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SelectionAlert", "SelectionAlert()", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelDeliveryChallan", "ShowModelDeliveryChallan()", true);
                    FillDeliveryChallanGridrPopup();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDeliveryChallanGridrPopup()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = DC_MASLogicLayer.GetAllDC_MasWiseComapnyAndACodeForTaxInvoiceBill(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), HfAODECredit.Value,"D".ToString(),"L".ToString());
                GvAddDeliveryChallan.DataSource = Dt;
                GvAddDeliveryChallan.DataBind();

                if (ViewState["AddChallanTable"] != null)
                {
                    foreach (GridViewRow row in GvAddDeliveryChallan.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfDCTransDate = row.FindControl("HfDCTransDate") as HiddenField;
                            HiddenField HfDCTransNo = row.FindControl("HfDCTransNo") as HiddenField;
                            CheckBox ChkChallanNo = row.FindControl("ChkChallanNo") as CheckBox;


                            DataTable Dt1 = (DataTable)ViewState["AddChallanTable"];
                            if (Dt1.Rows.Count > 0)
                            {
                                DataView Dv = new DataView(Dt1);
                                Dv.RowFilter = "DCTransNo='" + HfDCTransNo.Value + "' and DCTransDate='" + HfDCTransDate.Value + "'";
                                DataTable DtFIlter = Dv.ToTable();
                                if (DtFIlter.Rows.Count > 0)
                                {
                                    ChkChallanNo.Checked = true;
                                }
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


        protected void GvAddDeliveryChallan_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GvAddDeliveryChallan.PageIndex = e.NewPageIndex;
            clear();
            FillDeliveryChallanGridrPopup();
        }

        protected void GvAddDeliveryChallan_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void btnAddChallanProcess_Click(object sender, EventArgs e)
        {

            try
            {
                ViewState["AddChallanTable"] = null;

                DataTable tblChallan = new DataTable();


                #region Define Table

                DataRow drchallan = null;
                tblChallan.Columns.Add("DCTransDate", typeof(string));
                tblChallan.Columns.Add("DCTransNo", typeof(string));

                #endregion


                DataTable table = new DataTable();


                #region Define Table

                DataRow dr = null;
                table.Columns.Add("COMP_CODE", typeof(string));
                table.Columns.Add("TRAN_DATE", typeof(string));
                table.Columns.Add("TRAN_NO", typeof(string));
                table.Columns.Add("SR", typeof(string));
                table.Columns.Add("REF_TRAN_DATE", typeof(string));
                table.Columns.Add("REF_TRAN_NO", typeof(string));
                table.Columns.Add("REF_SRNO", typeof(string));
                table.Columns.Add("SCODE", typeof(string));
                table.Columns.Add("PRODUCT_DESC", typeof(string));
                table.Columns.Add("HSN_NO", typeof(string));
                table.Columns.Add("QTY", typeof(string));
                table.Columns.Add("RATE", typeof(string));
                table.Columns.Add("AMT", typeof(string));
                table.Columns.Add("DIS_PER", typeof(string));
                table.Columns.Add("DIS_AMT", typeof(string));
                table.Columns.Add("ADD_DIS_PER", typeof(string));
                table.Columns.Add("ADD_DIS_AMT", typeof(string));
                table.Columns.Add("G_AMT", typeof(string));
                table.Columns.Add("ST_PER", typeof(string));
                table.Columns.Add("ST_AMT", typeof(string));
                table.Columns.Add("ADD_ST_PER", typeof(string));
                table.Columns.Add("ADD_ST_AMT", typeof(string));
                table.Columns.Add("DC_TRAN_DATE", typeof(string));
                table.Columns.Add("DC_TRAN_NO", typeof(string));
                table.Columns.Add("DC_SRNO", typeof(string));
                table.Columns.Add("GST_RATE", typeof(string));
                table.Columns.Add("GST_AMT", typeof(string));
                table.Columns.Add("CGST_RATE", typeof(string));
                table.Columns.Add("CGST_AMT", typeof(string));
                table.Columns.Add("SGST_RATE", typeof(string));
                table.Columns.Add("SGST_AMT", typeof(string));
                table.Columns.Add("IGST_RATE", typeof(string));
                table.Columns.Add("IGST_AMT", typeof(string));
                table.Columns.Add("T_AMT", typeof(string));
                table.Columns.Add("INV_TRAN_DATE", typeof(string));
                table.Columns.Add("INV_TRAN_NO", typeof(string));
                table.Columns.Add("INV_SR", typeof(string));
                table.Columns.Add("ENTRY_TYPE", typeof(string));
                table.Columns.Add("ENDT", typeof(string));
                table.Columns.Add("ACT_RATE", typeof(string));
                table.Columns.Add("ACT_AMT", typeof(string));
                table.Columns.Add("CAL_RATE", typeof(string));
                table.Columns.Add("CAL_AMT", typeof(string));
                table.Columns.Add("PART_NO", typeof(string));
                table.Columns.Add("ADD_PART_NO", typeof(string));
                table.Columns.Add("PER_QTY_WT", typeof(string));
                table.Columns.Add("TOT_QTY_WT", typeof(string));
                table.Columns.Add("EX_DUTY_AMT", typeof(string));
                table.Columns.Add("EX_CESS_AMT", typeof(string));
                table.Columns.Add("EX_SHCESS_AMT", typeof(string));
                table.Columns.Add("CHA_NO", typeof(string));
                table.Columns.Add("SERIALNO", typeof(string));
                table.Columns.Add("ChallanDate", typeof(string));
                #endregion

                foreach (GridViewRow row in GvAddDeliveryChallan.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        //Label TxtBarcode = row.FindControl("lblChallanNo") as Label;
                        //Label lblChallanDate = row.FindControl("lblChallanDate") as Label;
                        //Label lblGRNNo = row.FindControl("lblGRNNo") as Label;
                        HiddenField HfDCTransDate = row.FindControl("HfDCTransDate") as HiddenField;
                        HiddenField HfDCTransNo = row.FindControl("HfDCTransNo") as HiddenField;
                        CheckBox ChkChallanNo = row.FindControl("ChkChallanNo") as CheckBox;

                        if (ChkChallanNo.Checked == true)
                        {
                            drchallan = tblChallan.NewRow();
                            drchallan["DCTransNo"] = HfDCTransNo.Value.ToString();
                            drchallan["DCTransDate"] = HfDCTransDate.Value.ToString();
                            tblChallan.Rows.Add(drchallan);


                            ViewState["AddChallanTable"] = tblChallan;

                            DataSet ds = DC_MASLogicLayer.GetAllIDWiseDC_SALES_MASDetials(HfDCTransNo.Value.ToString(), Convert.ToDateTime(HfDCTransDate.Value.ToString()));
                            DataTable dt = ds.Tables[0];
                            DataTable DtDetails = ds.Tables[1];


                            if (DtDetails.Rows.Count > 0)
                            {
                                for (int i = 0; i < DtDetails.Rows.Count; i++)
                                {

                                    #region Assign Value to Table

                                    dr = table.NewRow();

                                    dr["COMP_CODE"] = DtDetails.Rows[i]["COMP_CODE"].ToString();
                                    //dr["TRAN_DATE"] = DtDetails.Rows[i]["COMP_CODE"].ToString();
                                    //dr["TRAN_NO"] = DtDetails.Rows[i]["COMP_CODE"].ToString();
                                    //dr["SR"] = DtDetails.Rows[i]["COMP_CODE"].ToString();
                                    dr["REF_TRAN_DATE"] = DtDetails.Rows[i]["ORD_TRAN_DATE"].ToString();
                                    dr["REF_TRAN_NO"] = DtDetails.Rows[i]["ORD_TRAN_NO"].ToString();
                                    dr["REF_SRNO"] = DtDetails.Rows[i]["ORD_SRNO"].ToString();
                                    dr["SCODE"] = DtDetails.Rows[i]["SCODE"].ToString();
                                    dr["PRODUCT_DESC"] = DtDetails.Rows[i]["PRODUCT_DESC"].ToString();
                                    dr["HSN_NO"] = DtDetails.Rows[i]["HSN_NO"].ToString();
                                    dr["QTY"] = DtDetails.Rows[i]["QTY"].ToString();
                                    dr["RATE"] = DtDetails.Rows[i]["RATE"].ToString();
                                    dr["AMT"] = DtDetails.Rows[i]["AMT"].ToString();
                                    dr["DIS_PER"] = DtDetails.Rows[i]["DIS_PER"].ToString();
                                    dr["DIS_AMT"] = DtDetails.Rows[i]["DIS_AMT"].ToString();
                                    dr["ADD_DIS_PER"] = string.Empty;
                                    dr["ADD_DIS_AMT"] = string.Empty;
                                    dr["G_AMT"] = DtDetails.Rows[i]["G_AMT"].ToString();
                                    dr["ST_PER"] = string.Empty;
                                    dr["ST_AMT"] = string.Empty;
                                    dr["ADD_ST_PER"] = string.Empty;
                                    dr["ADD_ST_AMT"] = string.Empty;
                                    dr["DC_TRAN_DATE"] = DtDetails.Rows[i]["TRAN_DATE"].ToString();
                                    dr["DC_TRAN_NO"] = DtDetails.Rows[i]["TRAN_NO"].ToString();
                                    dr["DC_SRNO"] = DtDetails.Rows[i]["SRNO"].ToString();
                                    dr["GST_RATE"] = DtDetails.Rows[i]["GST_RATE"].ToString();
                                    dr["GST_AMT"] = DtDetails.Rows[i]["GST_AMT"].ToString();
                                    dr["CGST_RATE"] = DtDetails.Rows[i]["CGST_RATE"].ToString();
                                    dr["CGST_AMT"] = DtDetails.Rows[i]["CGST_AMT"].ToString();
                                    dr["SGST_RATE"] = DtDetails.Rows[i]["SGST_RATE"].ToString();
                                    dr["SGST_AMT"] = DtDetails.Rows[i]["SGST_AMT"].ToString();
                                    dr["IGST_RATE"] = DtDetails.Rows[i]["IGST_RATE"].ToString();
                                    dr["IGST_AMT"] = DtDetails.Rows[i]["IGST_AMT"].ToString();
                                    dr["T_AMT"] = DtDetails.Rows[i]["T_AMT"].ToString();
                                    dr["INV_TRAN_DATE"] = string.Empty;
                                    dr["INV_TRAN_NO"] = string.Empty;
                                    dr["INV_SR"] = string.Empty;
                                    dr["ENTRY_TYPE"] = DtDetails.Rows[i]["ENTRY_TYPE"].ToString();
                                    dr["ENDT"] = DtDetails.Rows[i]["ENDT"].ToString();
                                    dr["ACT_RATE"] = string.Empty;
                                    dr["ACT_AMT"] = string.Empty;
                                    dr["CAL_RATE"] = string.Empty;
                                    dr["CAL_AMT"] = string.Empty;
                                    dr["PART_NO"] = string.Empty;
                                    dr["ADD_PART_NO"] = string.Empty;
                                    dr["PER_QTY_WT"] = string.Empty;
                                    dr["TOT_QTY_WT"] = string.Empty;
                                    dr["EX_DUTY_AMT"] = string.Empty;
                                    dr["EX_CESS_AMT"] = string.Empty;
                                    dr["EX_SHCESS_AMT"] = string.Empty;
                                    dr["CHA_NO"] = dt.Rows[0]["CHA_NO"].ToString();
                                    dr["SERIALNO"] = dt.Rows[0]["SERIALNO"].ToString();
                                    dr["ChallanDate"] = dt.Rows[0]["CHA_DT"].ToString();

                                    #endregion

                                    table.Rows.Add(dr);
                                }

                                ViewState["CurrentTable"] = table;




                            }

                        }
                    }

                }
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModelDeliveryChallan", "HideModelDeliveryChallan()", true);

                GvStockRecDetails.DataSource = table;
                GvStockRecDetails.DataBind();

                DivEntry.Visible = true;
                DivView.Visible = false;

            }
            catch (Exception)
            {

                throw;
            }
        }









        #endregion

        protected void btnViewInvoive_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../reportviewPages/Sales_Tax_Invoice.aspx', '_blank');", true);
        }
    }
}