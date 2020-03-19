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

namespace VeeraApp
{
    public partial class CashBook : System.Web.UI.Page
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
             Session["INVTYPE_FLAG"] != null &&
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

                    if (!string.IsNullOrWhiteSpace(Request.QueryString["Tran_Type"]) && !string.IsNullOrWhiteSpace(Request.QueryString["Pay_Type"]))
                    {
                        ViewState["Tran_Type"] = Request.QueryString["Tran_Type"];
                        ViewState["Trn_Type"] = Request.QueryString["Pay_Type"];
                    }

                    if (ViewState["Tran_Type"].ToString() == "P" && ViewState["Trn_Type"].ToString() == "C")
                    {
                        HfGroupCode.Value = "-23";
                        hdForCashBookPayment.Visible = true;
                        hdForCashBookReceipt.Visible = false;
                        hdForBankBookPayment.Visible = false;
                        hdForBankBookReceipt.Visible = false;
                    }
                    else if (ViewState["Tran_Type"].ToString() == "R" && ViewState["Trn_Type"].ToString() == "C")
                    {
                        HfGroupCode.Value = "-23";
                        hdForCashBookPayment.Visible = false;
                        hdForCashBookReceipt.Visible = true;
                        hdForBankBookPayment.Visible = false;
                        hdForBankBookReceipt.Visible = false;
                    }
                    else if (ViewState["Tran_Type"].ToString() == "P" && ViewState["Trn_Type"].ToString() == "B")
                    {
                        HfGroupCode.Value = "23";
                        hdForCashBookPayment.Visible = false;
                        hdForCashBookReceipt.Visible = false;
                        hdForBankBookPayment.Visible = true;
                        hdForBankBookReceipt.Visible = false;
                    }
                    else if (ViewState["Tran_Type"].ToString() == "R" && ViewState["Trn_Type"].ToString() == "B")
                    {
                        HfGroupCode.Value = "23";
                        hdForCashBookPayment.Visible = false;
                        hdForCashBookReceipt.Visible = false;
                        hdForBankBookPayment.Visible = false;
                        hdForBankBookReceipt.Visible = true;
                    }


                    DivEntry.Visible = false;
                    DivView.Visible = true;
                    SetInitialRow();
                    SetInitialRowInvoice();
                    FillMasterTxtAccountName();
                    FillPAY_REC_MasterGrid(Session["COMP_CODE"].ToString());


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

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetNarrationsName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from NARRATION WHERE NARRN like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> Narration = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Narration.Add(dt.Rows[i][0].ToString());
            }
            return Narration;
        }

        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            //ViewState["CurrentTable"] = null;
            //ViewState["InvoiceTable"] = null;
            SetInitialRow();
            SetInitialRowInvoice();

            HfCompCode.Value = string.Empty;
            HfBranchCode.Value = string.Empty;
            HfTranDate.Value = string.Empty;
            HfTranNo.Value = string.Empty;
            HfTranType.Value = string.Empty;
            TxtVoucherNo.Text = string.Empty;
            TxtVoucherDate.Text = string.Empty;
            DdlTransactionType.SelectedIndex = 0;
            TxtCuurentBalance.Text = string.Empty;
            TxtAccountName.Text = string.Empty;
            TxtTransactionBy.Text = string.Empty;
            DdlConfirm.SelectedValue = "N";
            TxtConfirmBy.Text = string.Empty;
            TxtConfirmDate.Text = string.Empty;
            DdlAuthorized.SelectedValue = "N";
            TxtAuthorizedBy.Text = string.Empty;
            TxtAuthorizedDate.Text = string.Empty;
            DdlOnAccount.SelectedValue = "N";
            TxtOnAccountAmount.Text = string.Empty;

            BtncallUpd.Text = "SAVE";





        }

        public void ControllerEnable()
        {

            TxtVoucherNo.Enabled = true;
            TxtVoucherDate.Enabled = true;
            DdlTransactionType.Enabled = false;
            TxtCuurentBalance.Enabled = true;
            TxtAccountName.Enabled = true;
            TxtTransactionBy.Enabled = true;
            DdlConfirm.Enabled = true;
            TxtConfirmBy.Enabled = true;
            TxtConfirmDate.Enabled = true;
            DdlAuthorized.Enabled = true;
            TxtAuthorizedBy.Enabled = true;
            TxtAuthorizedDate.Enabled = true;
            DdlOnAccount.Enabled = false;
            TxtOnAccountAmount.Enabled = false;

        }

        public void ControllerDisable()
        {

            TxtVoucherNo.Enabled = false;
            TxtVoucherDate.Enabled = false;
            DdlTransactionType.Enabled = false;
            TxtCuurentBalance.Enabled = false;
            TxtAccountName.Enabled = false;
            TxtTransactionBy.Enabled = false;
            DdlConfirm.Enabled = false;
            TxtConfirmBy.Enabled = false;
            TxtConfirmDate.Enabled = false;
            DdlAuthorized.Enabled = false;
            TxtAuthorizedBy.Enabled = false;
            TxtAuthorizedDate.Enabled = false;
            DdlOnAccount.Enabled = false;
            TxtOnAccountAmount.Enabled = false;
        }


        public void FillPAY_REC_MasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = PAY_REC_MLogicLayer.GetAllPAY_REC_MASDetails(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()), ViewState["Tran_Type"].ToString(), HfAccountCodeOnMasterGrid.Value.ToString());
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvPayReceiveMaster.DataSource = Dv.ToTable();
            GvPayReceiveMaster.DataBind();

            DtSearch = Dv.ToTable();

        }


        #region TOTAL OF FOOTER TEMPLETES FOR PAY_REC_INV GRID

        private double TotalBillAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvPayReceiveInvoice.Rows.Count; i++)
            {
                string total = (GvPayReceiveInvoice.Rows[i].FindControl("TxtBillAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }

        private double TotalPaidAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvPayReceiveInvoice.Rows.Count; i++)
            {
                string total = (GvPayReceiveInvoice.Rows[i].FindControl("TxtTotalPaidAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }

        private double TotalBillBalanceAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvPayReceiveInvoice.Rows.Count; i++)
            {
                string total = (GvPayReceiveInvoice.Rows[i].FindControl("TxtBillBalanceAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }

        private double TotalCurrentPaidAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvPayReceiveInvoice.Rows.Count; i++)
            {
                string total = (GvPayReceiveInvoice.Rows[i].FindControl("TxtCurrentPaidAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }


        private double TotalCurrentBalanceAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvPayReceiveInvoice.Rows.Count; i++)
            {
                string total = (GvPayReceiveInvoice.Rows[i].FindControl("TxtCurrentBalAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }

        private double TotalTDSAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvPayReceiveInvoice.Rows.Count; i++)
            {
                string total = (GvPayReceiveInvoice.Rows[i].FindControl("TxtTDSAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }


        private double TotalDiscountAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvPayReceiveInvoice.Rows.Count; i++)
            {
                string total = (GvPayReceiveInvoice.Rows[i].FindControl("TxtDiscountAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }

        #endregion


        #region ADD NEW ROW ACCOUNT DETALS GRID


        private void SetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SR", typeof(string));
            table.Columns.Add("DRACODE", typeof(string));
            table.Columns.Add("CRACODE", typeof(string));
            table.Columns.Add("SIGN", typeof(string));
            table.Columns.Add("NARRN", typeof(string));
            table.Columns.Add("CHQ_NO", typeof(string));
            table.Columns.Add("CHQ_DT", typeof(string));
            table.Columns.Add("BANKDT", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("STATUS", typeof(string));
            table.Columns.Add("ENDT", typeof(string));
            table.Columns.Add("DR_PAID_AMT", typeof(string));
            table.Columns.Add("CR_PAID_AMT", typeof(string));
            table.Columns.Add("BILL_NO", typeof(string));
            table.Columns.Add("BILL_DATE", typeof(string));
            table.Columns.Add("BILL_AMT", typeof(string));
            table.Columns.Add("T_RATE", typeof(string));
            table.Columns.Add("T_AMT", typeof(string));
            table.Columns.Add("S_RATE", typeof(string));
            table.Columns.Add("S_AMT", typeof(string));
            table.Columns.Add("TOT_TDS", typeof(string));
            table.Columns.Add("TDSACODE", typeof(string));
            table.Columns.Add("TRAN_TYPE", typeof(string));
            table.Columns.Add("BANK_NARRN", typeof(string));
            table.Columns.Add("PARTY_BANK", typeof(string));
            table.Columns.Add("OA_AMT", typeof(string));
            table.Columns.Add("OA_FLAG", typeof(string));
            table.Columns.Add("PARTY_TYPE", typeof(string));


            dr = table.NewRow();


            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SR"] = string.Empty;
            dr["DRACODE"] = string.Empty;
            dr["CRACODE"] = string.Empty;
            dr["SIGN"] = string.Empty;
            dr["NARRN"] = string.Empty;
            dr["CHQ_NO"] = string.Empty;
            dr["CHQ_DT"] = string.Empty;
            dr["BANKDT"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["STATUS"] = string.Empty;
            dr["ENDT"] = string.Empty;
            dr["DR_PAID_AMT"] = string.Empty;
            dr["CR_PAID_AMT"] = string.Empty;
            dr["BILL_NO"] = string.Empty;
            dr["BILL_DATE"] = string.Empty;
            dr["BILL_AMT"] = string.Empty;
            dr["T_RATE"] = string.Empty;
            dr["T_AMT"] = string.Empty;
            dr["S_RATE"] = string.Empty;
            dr["S_AMT"] = string.Empty;
            dr["TOT_TDS"] = string.Empty;
            dr["TDSACODE"] = string.Empty;
            dr["BANK_NARRN"] = string.Empty;
            dr["PARTY_BANK"] = string.Empty;
            dr["OA_AMT"] = string.Empty;
            dr["OA_FLAG"] = string.Empty;
            dr["PARTY_TYPE"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvPayReceiveDetails.DataSource = table;
            GvPayReceiveDetails.DataBind();

        }




        private void AddNewRowToAcccountGrid()
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



                        HiddenField HfCompCode = (HiddenField)GvPayReceiveDetails.Rows[rowIndex].Cells[0].FindControl("HfCompCode");
                        HiddenField HfTranDate = (HiddenField)GvPayReceiveDetails.Rows[rowIndex].Cells[0].FindControl("HfTranDate");
                        HiddenField HfTranNo = (HiddenField)GvPayReceiveDetails.Rows[rowIndex].Cells[0].FindControl("HfTranNo");
                        HiddenField HfSrNo = (HiddenField)GvPayReceiveDetails.Rows[rowIndex].Cells[0].FindControl("HfSrNo");
                        HiddenField HfDebitAcode = (HiddenField)GvPayReceiveDetails.Rows[rowIndex].Cells[0].FindControl("HfDebitAcode");
                        HiddenField HfCreditAcode = (HiddenField)GvPayReceiveDetails.Rows[rowIndex].Cells[0].FindControl("HfCreditAcode");

                        TextBox TxtPartyName = (TextBox)GvPayReceiveDetails.Rows[rowIndex].Cells[1].FindControl("TxtPartyName");
                        TextBox TxtNarrnDescription = (TextBox)GvPayReceiveDetails.Rows[rowIndex].Cells[2].FindControl("TxtNarrnDescription");
                        TextBox TxtPartyBankName = (TextBox)GvPayReceiveDetails.Rows[rowIndex].Cells[3].FindControl("TxtPartyBankName");
                        TextBox TxtChequeNo = (TextBox)GvPayReceiveDetails.Rows[rowIndex].Cells[4].FindControl("TxtChequeNo");
                        TextBox TxtChequeDate = (TextBox)GvPayReceiveDetails.Rows[rowIndex].Cells[5].FindControl("TxtChequeDate");
                        TextBox TxtBankDate = (TextBox)GvPayReceiveDetails.Rows[rowIndex].Cells[6].FindControl("TxtBankDate");
                        TextBox TxtAmount = (TextBox)GvPayReceiveDetails.Rows[rowIndex].Cells[7].FindControl("TxtAmount");


                        //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["DRACODE"] = HfDebitAcode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["CRACODE"] = HfCreditAcode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["NARRN"] = TxtNarrnDescription.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["PARTY_BANK"] = TxtPartyBankName.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["CHQ_NO"] = TxtChequeNo.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["CHQ_DT"] = TxtChequeDate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["BANKDT"] = TxtBankDate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = TxtAmount.Text.Trim();


                        rowIndex++;

                    }


                    drCurrentRow = dtCurrentTable.NewRow();


                    //drCurrentRow["COMP_CODE"] = "0";
                    //drCurrentRow["TRAN_DATE"] = "";
                    //drCurrentRow["TRAN_NO"] = "0";
                    //drCurrentRow["SR"] = "0";
                    drCurrentRow["DRACODE"] = "0";
                    drCurrentRow["CRACODE"] = "0";
                    drCurrentRow["NARRN"] = "";
                    drCurrentRow["PARTY_BANK"] = "";
                    drCurrentRow["CHQ_NO"] = "";
                    drCurrentRow["CHQ_DT"] = "";
                    drCurrentRow["BANKDT"] = "";
                    drCurrentRow["AMT"] = "";


                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvPayReceiveDetails.DataSource = dtCurrentTable;
                    GvPayReceiveDetails.DataBind();


                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousDataAccountGrid();
        }



        private void SetPreviousDataAccountGrid()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        HiddenField HfCompCode = (HiddenField)GvPayReceiveDetails.Rows[rowIndex].Cells[0].FindControl("HfCompCode");
                        HiddenField HfTranDate = (HiddenField)GvPayReceiveDetails.Rows[rowIndex].Cells[0].FindControl("HfTranDate");
                        HiddenField HfTranNo = (HiddenField)GvPayReceiveDetails.Rows[rowIndex].Cells[0].FindControl("HfTranNo");
                        HiddenField HfSrNo = (HiddenField)GvPayReceiveDetails.Rows[rowIndex].Cells[0].FindControl("HfSrNo");
                        HiddenField HfDebitAcode = (HiddenField)GvPayReceiveDetails.Rows[rowIndex].Cells[0].FindControl("HfDebitAcode");
                        HiddenField HfCreditAcode = (HiddenField)GvPayReceiveDetails.Rows[rowIndex].Cells[0].FindControl("HfCreditAcode");

                        TextBox TxtPartyName = (TextBox)GvPayReceiveDetails.Rows[rowIndex].Cells[1].FindControl("TxtPartyName");
                        TextBox TxtNarrnDescription = (TextBox)GvPayReceiveDetails.Rows[rowIndex].Cells[2].FindControl("TxtNarrnDescription");
                        TextBox TxtPartyBankName = (TextBox)GvPayReceiveDetails.Rows[rowIndex].Cells[3].FindControl("TxtPartyBankName");
                        TextBox TxtChequeNo = (TextBox)GvPayReceiveDetails.Rows[rowIndex].Cells[4].FindControl("TxtChequeNo");
                        TextBox TxtChequeDate = (TextBox)GvPayReceiveDetails.Rows[rowIndex].Cells[5].FindControl("TxtChequeDate");
                        TextBox TxtBankDate = (TextBox)GvPayReceiveDetails.Rows[rowIndex].Cells[6].FindControl("TxtBankDate");
                        TextBox TxtAmount = (TextBox)GvPayReceiveDetails.Rows[rowIndex].Cells[7].FindControl("TxtAmount");



                        HfDebitAcode.Value = dt.Rows[i]["DRACODE"].ToString();
                        HfCreditAcode.Value = dt.Rows[i]["CRACODE"].ToString();
                        TxtNarrnDescription.Text = dt.Rows[i]["NARRN"].ToString();
                        TxtPartyBankName.Text = dt.Rows[i]["PARTY_BANK"].ToString();
                        TxtChequeNo.Text = dt.Rows[i]["CHQ_NO"].ToString();
                        TxtChequeDate.Text = dt.Rows[i]["CHQ_DT"].ToString();
                        TxtBankDate.Text = dt.Rows[i]["BANKDT"].ToString();
                        TxtAmount.Text = dt.Rows[i]["AMT"].ToString();

                        rowIndex++;


                    }
                }
            }
        }


        protected void BtnDeleteRowModelAccountGrid_Click(object sender, EventArgs e)
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
                GvPayReceiveDetails.DataSource = dt;
                GvPayReceiveDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousDataAccountGrid();
        }

        protected void BtnAddRowModelAccountGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToAcccountGrid();
        }


        #endregion


        private void SetInitialRowInvoice()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SR", typeof(string));
            table.Columns.Add("SUB_SR", typeof(string));
            table.Columns.Add("XXX_TYPE", typeof(string));
            table.Columns.Add("XXX_DATE", typeof(string));
            table.Columns.Add("XXX_NO", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("ENDT", typeof(string));
            table.Columns.Add("TRAN_TYPE", typeof(string));
            table.Columns.Add("ACODE", typeof(string));
            table.Columns.Add("LESS_AMT", typeof(string));
            table.Columns.Add("TDS_AMT", typeof(string));
            table.Columns.Add("GST_RATE", typeof(string));
            table.Columns.Add("GST_AMT", typeof(string));
            table.Columns.Add("CGST_RATE", typeof(string));
            table.Columns.Add("CGST_AMT", typeof(string));
            table.Columns.Add("SGST_RATE", typeof(string));
            table.Columns.Add("SGST_AMT", typeof(string));
            table.Columns.Add("IGST_RATE", typeof(string));
            table.Columns.Add("IGST_AMT", typeof(string));
            table.Columns.Add("ACT_AMT", typeof(string));

            table.Columns.Add("inv_date", typeof(string));
            table.Columns.Add("inv_no", typeof(string));
            table.Columns.Add("bill_amt", typeof(string));
            table.Columns.Add("bill_paid_amt", typeof(string));
            table.Columns.Add("last_paiddate", typeof(string));
            table.Columns.Add("last_paidchqno", typeof(string));
            table.Columns.Add("bal_amt", typeof(string));
            table.Columns.Add("Bill_Bal_Amt", typeof(string));


            dr = table.NewRow();


            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SR"] = string.Empty;
            dr["SUB_SR"] = string.Empty;
            dr["XXX_TYPE"] = string.Empty;
            dr["XXX_DATE"] = string.Empty;
            dr["XXX_NO"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["ENDT"] = string.Empty;
            dr["TRAN_TYPE"] = string.Empty;
            dr["ACODE"] = string.Empty;
            dr["LESS_AMT"] = string.Empty;
            dr["TDS_AMT"] = string.Empty;
            dr["GST_RATE"] = string.Empty;
            dr["GST_AMT"] = string.Empty;
            dr["CGST_RATE"] = string.Empty;
            dr["CGST_AMT"] = string.Empty;
            dr["SGST_RATE"] = string.Empty;
            dr["SGST_AMT"] = string.Empty;
            dr["IGST_RATE"] = string.Empty;
            dr["IGST_AMT"] = string.Empty;
            dr["ACT_AMT"] = string.Empty;

            dr["inv_date"] = string.Empty;
            dr["inv_no"] = string.Empty;
            dr["bill_amt"] = string.Empty;
            dr["bill_paid_amt"] = string.Empty;
            dr["last_paiddate"] = string.Empty;
            dr["last_paidchqno"] = string.Empty;
            dr["bal_amt"] = string.Empty;
            dr["Bill_Bal_Amt"] = string.Empty;





            table.Rows.Add(dr);

            ViewState["InvoiceTable"] = table;

            GvPayReceiveInvoice.DataSource = table;
            GvPayReceiveInvoice.DataBind();

        }


        public void FillMasterTxtAccountName()
        {
            try
            {
                DataTable DtFilter = new DataTable();

                HiddenField HfDebitAcode = (HiddenField)GvPayReceiveDetails.Rows[0].FindControl("HfDebitAcode");
                HiddenField HfCreditAcode = (HiddenField)GvPayReceiveDetails.Rows[0].FindControl("HfCreditAcode");

                DtFilter = ACCOUNTS_MASLogicLayer.GetACCOUNTNameForCashBankBook(Session["COMP_CODE"].ToString(), HfGroupCode.Value.ToString());
                if (DtFilter.Rows.Count > 0)
                {
                    DataView DvAccount = new DataView(DtFilter);
                    DvAccount.RowFilter = "ACODE>0";
                    DataTable Dt = DvAccount.ToTable();
                    HfACODE.Value = Dt.Rows[0]["ACODE"].ToString();
                    if (Convert.ToInt32(HfACODE.Value) > 0)
                    {
                        TxtAccountName.Text = Dt.Rows[0]["ANAME"].ToString();
                        HfACODE.Value = Dt.Rows[0]["ACODE"].ToString();


                        TxtAccountNameOnMasterGrid.Text = Dt.Rows[0]["ANAME"].ToString();
                        HfAccountCodeOnMasterGrid.Value = Dt.Rows[0]["ACODE"].ToString();

                        if (HfTranType.Value == "R")
                        {
                            HfCreditAcode.Value = "";
                            HfDebitAcode.Value = Dt.Rows[0]["ACODE"].ToString();
                        }
                        else
                        {
                            HfDebitAcode.Value = "";
                            HfCreditAcode.Value = Dt.Rows[0]["ACODE"].ToString();
                        }
                    }
                    else
                    {
                        TxtAccountName.Text = string.Empty;
                        HfACODE.Value = string.Empty;
                        TxtAccountNameOnMasterGrid.Text = string.Empty;
                        HfAccountCodeOnMasterGrid.Value = string.Empty;
                    }
                }
                else
                {
                    TxtAccountName.Text = string.Empty;
                    HfACODE.Value = string.Empty;
                    TxtAccountNameOnMasterGrid.Text = string.Empty;
                    HfAccountCodeOnMasterGrid.Value = string.Empty;
                }

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





        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetPersonName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from BROKER where COMP_CODE=@COMP_CODE and BRANCH_CODE=@BRANCH_CODE and BNAME like @BNAME + '%'", con);
            cmd.Parameters.AddWithValue("@BNAME", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            cmd.Parameters.AddWithValue("@BRANCH_CODE", Branchcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> BrokerName = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BrokerName.Add(dt.Rows[i][3].ToString());
            }
            return BrokerName;
        }

        protected void TxtTransactionBy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtTransactionBy.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtTransactionBy.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfTransactionBCODE.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
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
                TxtVoucherDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                FillMasterTxtAccountName();

                string Voucher_NO = PAY_REC_MLogicLayer.GetVoucherNumber_PAY_REC_MASCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtVoucherDate.Text.Trim()).ToString("yyyy-MM-dd"), ViewState["Tran_Type"].ToString());
                if (Voucher_NO.Length <= 8)
                {
                    TxtVoucherNo.Text = Voucher_NO;
                }
                else
                {
                    TxtVoucherNo.Text = string.Empty;
                }

                if (ViewState["Tran_Type"].ToString() == "R")
                {
                    DdlTransactionType.SelectedValue = "R";
                }
                else if (ViewState["Tran_Type"].ToString() == "P")
                {
                    DdlTransactionType.SelectedValue = "P";
                }


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


        protected void TxtVoucherDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Voucher_NO = PAY_REC_MLogicLayer.GetVoucherNumber_PAY_REC_MASCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtVoucherDate.Text.Trim()).ToString("yyyy-MM-dd"), ViewState["Tran_Type"].ToString());
                if (Voucher_NO.Length <= 8)
                {
                    TxtVoucherNo.Text = Voucher_NO;
                }
                else
                {
                    TxtVoucherNo.Text = string.Empty;
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
                #region UPDATE PAY_REC_MASTER TRANSACTION DETAILS

                PAY_REC_MLogicLayer insert = new PAY_REC_MLogicLayer();

                insert.COMP_CODE = Session["COMP_CODE"].ToString();
                insert.TRAN_TYPE = DdlTransactionType.SelectedValue.Trim().ToUpper();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.VOU_DATE = Convert.ToDateTime(TxtVoucherDate.Text.Trim()).ToString("MM-dd-yyyy");
                insert.VOU_NO = TxtVoucherNo.Text.Trim();
                insert.ACODE = HfACODE.Value.Trim();
                insert.SIGN = null;
                insert.NARRN = null;
                insert.AMT = null;
                insert.ENDT = "";
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = "";
                insert.UPD_DATE = "";
                insert.RW_CODE = null;
                insert.RW_TYPE = "";
                insert.FIGURE_FLAG = null;
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
                insert.TRN_TYPE = HfTrnType.Value.Trim().ToUpper();
                insert.TRNDT = null;
                insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                insert.CHK_FLAG = DdlAuthorized.SelectedValue.Trim().ToUpper();
                if (DdlAuthorized.SelectedValue.Trim() == "Y")
                {
                    insert.CHK_DATE = Convert.ToDateTime(TxtAuthorizedDate.Text.Trim()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.CHK_DATE = "";
                }

                if (DdlAuthorized.SelectedValue.Trim() == "Y")
                {
                    insert.CHK_USERID = Session["USERNAME"].ToString();
                }
                else
                {
                    insert.CHK_USERID = "";
                }

                insert.CONF_FLAG = DdlConfirm.SelectedValue.Trim().ToUpper();
                if (DdlConfirm.SelectedValue.Trim() == "Y")
                {
                    insert.CONF_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.CONF_DATE = "";
                }

                if (DdlConfirm.SelectedValue.Trim() == "Y")
                {
                    insert.CONF_USERID = Session["USERNAME"].ToString();
                }
                else
                {
                    insert.CONF_USERID = "";
                }

                insert.BCODE = HfTransactionBCODE.Value.Trim();

                #endregion


                #region INSERT INTO PAY_REC_T DETAILS

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);
                int SRNO = 1;

                foreach (GridViewRow row in GvPayReceiveDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                        HiddenField HfTranNo = row.FindControl("HfTranNo") as HiddenField;
                        HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                        HiddenField HfDebitAcode = row.FindControl("HfDebitAcode") as HiddenField;
                        HiddenField HfCreditAcode = row.FindControl("HfCreditAcode") as HiddenField;
                        HiddenField HfTran_Type = row.FindControl("HfTran_Type") as HiddenField;


                        HiddenField HfACODEInner = row.FindControl("HfACODEInner") as HiddenField;
                        TextBox TxtPartyName = row.FindControl("TxtPartyName") as TextBox;
                        TextBox TxtNarrnDescription = row.FindControl("TxtNarrnDescription") as TextBox;
                        TextBox TxtPartyBankName = row.FindControl("TxtPartyBankName") as TextBox;
                        TextBox TxtChequeNo = row.FindControl("TxtChequeNo") as TextBox;
                        TextBox TxtChequeDate = row.FindControl("TxtChequeDate") as TextBox;
                        TextBox TxtBankDate = row.FindControl("TxtBankDate") as TextBox;
                        TextBox TxtAmount = row.FindControl("TxtAmount") as TextBox;


                        if (TxtPartyName.Text != string.Empty && TxtPartyName.Text != null)
                        {


                            XmlElement HandleDetail2 = XDoc1.CreateElement("PAY_REC_Details");

                            HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                            HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                            HandleDetail2.SetAttribute("SR", SRNO.ToString());

                            if (DdlTransactionType.SelectedValue == "R")
                            {
                                HandleDetail2.SetAttribute("DRACODE", HfACODE.Value.Trim());
                                HandleDetail2.SetAttribute("CRACODE", HfACODEInner.Value.Trim());
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("DRACODE", (HfACODEInner.Value.Trim()));
                                HandleDetail2.SetAttribute("CRACODE", (HfACODE.Value));
                            }



                            HandleDetail2.SetAttribute("NARRN", (TxtNarrnDescription.Text.Trim()));
                            HandleDetail2.SetAttribute("PARTY_BANK", (TxtPartyBankName.Text.Trim()));
                            HandleDetail2.SetAttribute("CHQ_NO", (TxtChequeNo.Text.Trim()));
                            if (TxtChequeDate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("CHQ_DT", "");
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("CHQ_DT", Convert.ToDateTime(TxtChequeDate.Text.Trim()).ToString("MM-dd-yyyy"));
                            }

                            if (TxtBankDate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("BANKDT", "");
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("BANKDT", Convert.ToDateTime(TxtBankDate.Text.Trim()).ToString("MM-dd-yyyy"));
                            }

                            if (TxtAmount.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("AMT", (TxtAmount.Text.Trim()));
                            }

                            HandleDetail2.SetAttribute("TRAN_TYPE", (DdlTransactionType.SelectedValue.Trim()));

                            HandleDetail2.SetAttribute("OA_FLAG", (DdlOnAccount.SelectedValue.ToString()));

                            if (TxtOnAccountAmount.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("OA_AMT", (TxtOnAccountAmount.Text.Trim()));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("OA_AMT", ("0"));
                            }

                            root1.AppendChild(HandleDetail2);
                            SRNO++;


                        }

                    }
                }


                #endregion


                #region INSERT INTO PAY RECEICE INVOICE DETAILS TO GRID


                XmlDocument XDoc2 = new XmlDocument();
                XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                XDoc2.AppendChild(dec2);// Create the root element
                XmlElement root2 = XDoc2.CreateElement("root");
                XDoc2.AppendChild(root2);
                int SR = 1;


                foreach (GridViewRow row in GvPayReceiveInvoice.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                        HiddenField HfTranNo = row.FindControl("HfTranNo") as HiddenField;
                        HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                        HiddenField HfSubSrNo = row.FindControl("HfSubSrNo") as HiddenField;
                        HiddenField HfInvACODE = row.FindControl("HfInvACODE") as HiddenField;
                        HiddenField HfXXX_Date = row.FindControl("HfXXX_Date") as HiddenField;
                        HiddenField HfXXX_No = row.FindControl("HfXXX_No") as HiddenField;
                        HiddenField HfXXX_Type = row.FindControl("HfXXX_Type") as HiddenField;

                        Label lblSubSrNo = row.FindControl("lblSubSrNo") as Label;

                        TextBox TxtBillDate = row.FindControl("TxtBillDate") as TextBox;
                        TextBox TxtBillNo = row.FindControl("TxtBillNo") as TextBox;
                        TextBox TxtBillAmount = row.FindControl("TxtBillAmount") as TextBox;
                        TextBox TxtTotalPaidAmount = row.FindControl("TxtTotalPaidAmount") as TextBox;
                        TextBox TxtLastPaidDate = row.FindControl("TxtLastPaidDate") as TextBox;
                        TextBox TxtLastPaidChequeNo = row.FindControl("TxtLastPaidChequeNo") as TextBox;
                        TextBox TxtBillBalanceAmount = row.FindControl("TxtBillBalanceAmount") as TextBox;
                        TextBox TxtCurrentPaidAmount = row.FindControl("TxtCurrentPaidAmount") as TextBox;
                        TextBox TxtTDSAmount = row.FindControl("TxtTDSAmount") as TextBox;
                        TextBox TxtDiscountAmount = row.FindControl("TxtDiscountAmount") as TextBox;
                        TextBox TxtCurrentBalAmount = row.FindControl("TxtCurrentBalAmount") as TextBox;


                        if (HfInvACODE.Value != string.Empty && HfInvACODE.Value != null)
                        {


                            XmlElement HandleDetail3 = XDoc2.CreateElement("PAY_REC_INVDetails");

                            HandleDetail3.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                            HandleDetail3.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail3.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                            HandleDetail3.SetAttribute("SR", (SR.ToString()));
                            if (lblSubSrNo.Text != string.Empty)
                            {
                                HandleDetail3.SetAttribute("SUB_SR", (lblSubSrNo.Text.ToString()));
                            }

                            HandleDetail3.SetAttribute("XXX_TYPE", (HfXXX_Type.Value.ToString()));

                            if (HfXXX_Date.Value != string.Empty)
                            {
                                HandleDetail3.SetAttribute("XXX_DATE", (Convert.ToDateTime(HfXXX_Date.Value.Trim()).ToString("MM-dd-yyyy")));
                            }

                            if (HfXXX_No.Value != string.Empty)
                            {
                                HandleDetail3.SetAttribute("XXX_NO", (HfXXX_No.Value.ToString()));
                            }

                            if (TxtCurrentPaidAmount.Text != string.Empty)
                            {
                                HandleDetail3.SetAttribute("AMT", (TxtCurrentPaidAmount.Text.ToString()));
                            }

                            if (HfInvACODE.Value != string.Empty)
                            {
                                HandleDetail3.SetAttribute("ACODE", (HfInvACODE.Value.Trim()));
                            }
                            HandleDetail3.SetAttribute("TRAN_TYPE", (DdlTransactionType.SelectedValue.ToString()));

                            if (TxtDiscountAmount.Text != string.Empty)
                            {
                                HandleDetail3.SetAttribute("LESS_AMT", (TxtDiscountAmount.Text.ToString()));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("LESS_AMT", ("0"));
                            }

                            if (TxtTDSAmount.Text != string.Empty)
                            {
                                HandleDetail3.SetAttribute("TDS_AMT", (TxtTDSAmount.Text.ToString()));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("TDS_AMT", ("0"));
                            }




                            root2.AppendChild(HandleDetail3);
                            SR++;

                        }
                    }
                }

                #endregion



                string str = PAY_REC_MLogicLayer.UpdatePAY_REC_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml));

                if (str.Contains("successfully"))
                {

                    lblmsg.Text = "PAY RECEIVE MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillPAY_REC_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "PAY RECEIVE MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : PAY RECEIVE MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

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

                    #region INSERT PAY RECEIVE MASTER DETAILS

                    PAY_REC_MLogicLayer insert = new PAY_REC_MLogicLayer();

                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.TRAN_TYPE = DdlTransactionType.SelectedValue.Trim().ToUpper();
                    //  insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                    //insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.VOU_DATE = Convert.ToDateTime(TxtVoucherDate.Text.Trim()).ToString("MM-dd-yyyy");
                    insert.VOU_NO = TxtVoucherNo.Text.Trim();
                    insert.ACODE = HfACODE.Value.Trim();
                    insert.SIGN = null;
                    insert.NARRN = null;
                    insert.AMT = null;
                    insert.ENDT = "";
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = "";
                    insert.UPD_DATE = "";
                    insert.RW_CODE = null;
                    insert.RW_TYPE = "";
                    insert.FIGURE_FLAG = null;
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
                    insert.TRN_TYPE = HfTrnType.Value.Trim().ToUpper();
                    insert.TRNDT = null;
                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                    insert.CHK_FLAG = DdlAuthorized.SelectedValue.Trim().ToUpper();
                    if (DdlAuthorized.SelectedValue.Trim() == "Y")
                    {
                        insert.CHK_DATE = Convert.ToDateTime(TxtAuthorizedDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CHK_DATE = "";
                    }

                    if (DdlAuthorized.SelectedValue.Trim() == "Y")
                    {
                        insert.CHK_USERID = Session["USERNAME"].ToString();
                    }
                    else
                    {
                        insert.CHK_USERID = "";
                    }

                    insert.CONF_FLAG = DdlConfirm.SelectedValue.Trim().ToUpper();
                    if (DdlConfirm.SelectedValue.Trim() == "Y")
                    {
                        insert.CONF_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CONF_DATE = "";
                    }

                    if (DdlConfirm.SelectedValue.Trim() == "Y")
                    {
                        insert.CONF_USERID = Session["USERNAME"].ToString();
                    }
                    else
                    {
                        insert.CONF_USERID = "";
                    }

                    insert.BCODE = HfTransactionBCODE.Value.Trim();

                    #endregion


                    #region INSERT INTO PAY_REC_T DETAILS

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int SRNO = 1;

                    foreach (GridViewRow row in GvPayReceiveDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                            HiddenField HfTranNo = row.FindControl("HfTranNo") as HiddenField;
                            HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                            HiddenField HfDebitAcode = row.FindControl("HfDebitAcode") as HiddenField;
                            HiddenField HfCreditAcode = row.FindControl("HfCreditAcode") as HiddenField;
                            HiddenField HfACODEInner = row.FindControl("HfACODEInner") as HiddenField;
                            HiddenField HfTran_Type = row.FindControl("HfTran_Type") as HiddenField;

                            TextBox TxtPartyName = row.FindControl("TxtPartyName") as TextBox;
                            TextBox TxtNarrnDescription = row.FindControl("TxtNarrnDescription") as TextBox;
                            TextBox TxtPartyBankName = row.FindControl("TxtPartyBankName") as TextBox;
                            TextBox TxtChequeNo = row.FindControl("TxtChequeNo") as TextBox;
                            TextBox TxtChequeDate = row.FindControl("TxtChequeDate") as TextBox;
                            TextBox TxtBankDate = row.FindControl("TxtBankDate") as TextBox;
                            TextBox TxtAmount = row.FindControl("TxtAmount") as TextBox;


                            if (TxtPartyName.Text != string.Empty && TxtPartyName.Text != null)
                            {


                                XmlElement HandleDetail2 = XDoc1.CreateElement("PAY_REC_Details");

                                HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                                HandleDetail2.SetAttribute("SR", SRNO.ToString());

                                if (DdlTransactionType.SelectedValue == "R")
                                {
                                    HandleDetail2.SetAttribute("DRACODE", HfACODE.Value.Trim());
                                    HandleDetail2.SetAttribute("CRACODE", HfACODEInner.Value.Trim());
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("DRACODE", (HfACODEInner.Value.Trim()));
                                    HandleDetail2.SetAttribute("CRACODE", (HfACODE.Value));
                                }

                                HandleDetail2.SetAttribute("NARRN", (TxtNarrnDescription.Text.Trim()));
                                HandleDetail2.SetAttribute("PARTY_BANK", (TxtPartyBankName.Text.Trim()));
                                HandleDetail2.SetAttribute("CHQ_NO", (TxtChequeNo.Text.Trim()));
                                if (TxtChequeDate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CHQ_DT", "");
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CHQ_DT", Convert.ToDateTime(TxtChequeDate.Text.Trim()).ToString("MM-dd-yyyy"));
                                }

                                if (TxtBankDate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("BANKDT", "");
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("BANKDT", Convert.ToDateTime(TxtBankDate.Text.Trim()).ToString("MM-dd-yyyy"));
                                }


                                if (TxtAmount.Text != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("AMT", (TxtAmount.Text.Trim()));
                                }

                                HandleDetail2.SetAttribute("TRAN_TYPE", (DdlTransactionType.SelectedValue.Trim()));

                                HandleDetail2.SetAttribute("OA_FLAG", (DdlOnAccount.SelectedValue.ToString()));

                                if (TxtOnAccountAmount.Text != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("OA_AMT", (TxtOnAccountAmount.Text.Trim()));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("OA_AMT", ("0"));
                                }

                                root1.AppendChild(HandleDetail2);
                                SRNO++;


                            }

                        }
                    }


                    #endregion


                    #region INSERT INTO PAY RECEICE INVOICE DETAILS TO GRID


                    XmlDocument XDoc2 = new XmlDocument();
                    XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                    XDoc2.AppendChild(dec2);// Create the root element
                    XmlElement root2 = XDoc2.CreateElement("root");
                    XDoc2.AppendChild(root2);
                    int SR_NO = 1;



                    foreach (GridViewRow row in GvPayReceiveInvoice.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                            HiddenField HfTranNo = row.FindControl("HfTranNo") as HiddenField;
                            HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                            HiddenField HfSubSrNo = row.FindControl("HfSubSrNo") as HiddenField;
                            HiddenField HfInvACODE = row.FindControl("HfInvACODE") as HiddenField;
                            HiddenField HfXXX_Date = row.FindControl("HfXXX_Date") as HiddenField;
                            HiddenField HfXXX_No = row.FindControl("HfXXX_No") as HiddenField;
                            HiddenField HfXXX_Type = row.FindControl("HfXXX_Type") as HiddenField;

                            Label lblSubSrNo = row.FindControl("lblSubSrNo") as Label;

                            TextBox TxtBillDate = row.FindControl("TxtBillDate") as TextBox;
                            TextBox TxtBillNo = row.FindControl("TxtBillNo") as TextBox;
                            TextBox TxtBillAmount = row.FindControl("TxtBillAmount") as TextBox;
                            TextBox TxtTotalPaidAmount = row.FindControl("TxtTotalPaidAmount") as TextBox;
                            TextBox TxtLastPaidDate = row.FindControl("TxtLastPaidDate") as TextBox;
                            TextBox TxtLastPaidChequeNo = row.FindControl("TxtLastPaidChequeNo") as TextBox;
                            TextBox TxtBillBalanceAmount = row.FindControl("TxtBillBalanceAmount") as TextBox;
                            TextBox TxtCurrentPaidAmount = row.FindControl("TxtCurrentPaidAmount") as TextBox;
                            TextBox TxtTDSAmount = row.FindControl("TxtTDSAmount") as TextBox;
                            TextBox TxtDiscountAmount = row.FindControl("TxtDiscountAmount") as TextBox;
                            TextBox TxtCurrentBalAmount = row.FindControl("TxtCurrentBalAmount") as TextBox;


                            if (HfInvACODE.Value != string.Empty && HfInvACODE.Value != null)
                            {


                                XmlElement HandleDetail3 = XDoc2.CreateElement("PAY_REC_INVDetails");

                                HandleDetail3.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail3.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail3.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                                HandleDetail3.SetAttribute("SR", (SR_NO.ToString()));
                                if (lblSubSrNo.Text != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("SUB_SR", (lblSubSrNo.Text.ToString()));
                                }

                                HandleDetail3.SetAttribute("XXX_TYPE", (HfXXX_Type.Value.ToString()));

                                if (HfXXX_Date.Value != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("XXX_DATE", (Convert.ToDateTime(HfXXX_Date.Value.Trim()).ToString("MM-dd-yyyy")));
                                }

                                if (HfXXX_No.Value != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("XXX_NO", (HfXXX_No.Value.ToString()));
                                }

                                if (TxtCurrentPaidAmount.Text != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("AMT", (TxtCurrentPaidAmount.Text.ToString()));
                                }

                                if (HfInvACODE.Value != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("ACODE", (HfInvACODE.Value.Trim()));
                                }
                                HandleDetail3.SetAttribute("TRAN_TYPE", (DdlTransactionType.SelectedValue.ToString()));

                                if (TxtDiscountAmount.Text != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("LESS_AMT", (TxtDiscountAmount.Text.ToString()));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("LESS_AMT", ("0"));
                                }

                                if (TxtTDSAmount.Text != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("TDS_AMT", (TxtTDSAmount.Text.ToString()));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("TDS_AMT", ("0"));
                                }

                               



                                root2.AppendChild(HandleDetail3);
                              //  SR_NO++;

                            }
                        }
                    }

                    #endregion


                    string str = PAY_REC_MLogicLayer.InsertPAY_REC_MDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"), DdlTransactionType.SelectedValue.Trim().ToUpper());

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "PAY RECEIVE MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillPAY_REC_MasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "PAY RECEIVE MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : PAY RECEIVE MASTER NOT SAVED";
                        lblmsg.ForeColor = Color.Red;

                    }
                }


            }
            catch (Exception)
            {

                throw;
            }
        }




        public void FillAccountNameOnUpdate(string Id)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Brabch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTWiseComapnyAndBranchForInvoice(Comp_Code, Brabch_Code);


                if (HfACODE.Value.ToString() != "0" && HfACODE.Value != null && HfACODE.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "ACODE=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtAccountName.Text = DtView.Rows[0]["ANAME"].ToString();
                    HfACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                }
                else
                {
                    TxtAccountName.Text = string.Empty;
                    HfACODE.Value = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }



        public void FillTransactionByPersonOnUpdate(string TransactionPerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfTransactionBCODE.Value.ToString() != "0" && HfTransactionBCODE.Value.ToString() != null && HfTransactionBCODE.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + TransactionPerson;
                    DataTable DtView = Dv.ToTable();

                    TxtTransactionBy.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfTransactionBCODE.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtTransactionBy.Text = string.Empty;
                    HfTransactionBCODE.Value = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvPayReceiveMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvPayReceiveMaster.PageIndex = e.NewPageIndex;
            FillPAY_REC_MasterGrid(Session["COMP_CODE"].ToString());
            clear();
        }

        protected void GvPayReceiveMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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


                        DataSet ds = PAY_REC_MLogicLayer.GetAllIDWisePAY_REC_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtInvoiceDetails = ds.Tables[2];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            DdlTransactionType.SelectedValue = dt.Rows[0]["TRAN_TYPE"].ToString();
                            HfACODE.Value = dt.Rows[0]["ACODE"].ToString();
                            FillAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            TxtVoucherDate.Text = Convert.ToDateTime(dt.Rows[0]["VOU_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtVoucherNo.Text = dt.Rows[0]["VOU_NO"].ToString();
                            HfTransactionBCODE.Value = dt.Rows[0]["BCODE"].ToString();
                            FillTransactionByPersonOnUpdate(dt.Rows[0]["BCODE"].ToString());
                            DdlAuthorized.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtAuthorizedDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            TxtAuthorizedBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            DdlConfirm.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();

                        }

                        Session["TRAN_NO"] = e.CommandArgument.ToString();
                        Session["TRAN_DATE"] = HfTranDate.Value;
                        Session["TRAN_TYPE"] = DdlTransactionType.SelectedValue;
                        Session["ACODE"] = HfACODE.Value.Trim();


                        if (DtDetails.Rows.Count > 0)
                        {
                            GvPayReceiveDetails.DataSource = DtDetails;
                            GvPayReceiveDetails.DataBind();

                            TxtOnAccountAmount.Text = DtDetails.Rows[0]["OA_AMT"].ToString();
                            DdlOnAccount.SelectedValue = DtDetails.Rows[0]["OA_FLAG"].ToString();
                        }

                        if (DtInvoiceDetails.Rows.Count > 0)
                        {
                            GvPayReceiveInvoice.DataSource = DtInvoiceDetails;
                            GvPayReceiveInvoice.DataBind();
                        }


                        btnSave.Visible = false;
                        btnDelete.Visible = true;
                        Btncalldel.Visible = true;
                        BtncallUpd.Visible = false;
                        ControllerDisable();

                    }

                    #endregion
                }



                if (e.CommandName == "Edita")
                {
                    #region EDIT
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = PAY_REC_MLogicLayer.GetAllIDWisePAY_REC_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtInvoiceDetails = ds.Tables[2];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            DdlTransactionType.SelectedValue = dt.Rows[0]["TRAN_TYPE"].ToString();
                            HfACODE.Value = dt.Rows[0]["ACODE"].ToString();
                            FillAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            TxtVoucherDate.Text = Convert.ToDateTime(dt.Rows[0]["VOU_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtVoucherNo.Text = dt.Rows[0]["VOU_NO"].ToString();
                            HfTransactionBCODE.Value = dt.Rows[0]["BCODE"].ToString();
                            FillTransactionByPersonOnUpdate(dt.Rows[0]["BCODE"].ToString());
                            DdlAuthorized.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtAuthorizedDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            TxtAuthorizedBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            DdlConfirm.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();

                        }

                        Session["TRAN_NO"] = e.CommandArgument.ToString();
                        Session["TRAN_DATE"] = HfTranDate.Value;
                        Session["TRAN_TYPE"] = DdlTransactionType.SelectedValue;
                        Session["ACODE"] = HfACODE.Value.Trim();



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
                                    table.Columns.Add("DRACODE", typeof(string));
                                    table.Columns.Add("CRACODE", typeof(string));
                                    table.Columns.Add("SIGN", typeof(string));
                                    table.Columns.Add("NARRN", typeof(string));
                                    table.Columns.Add("CHQ_NO", typeof(string));
                                    table.Columns.Add("CHQ_DT", typeof(string));
                                    table.Columns.Add("BANKDT", typeof(string));
                                    table.Columns.Add("AMT", typeof(string));
                                    table.Columns.Add("STATUS", typeof(string));
                                    table.Columns.Add("ENDT", typeof(string));
                                    table.Columns.Add("DR_PAID_AMT", typeof(string));
                                    table.Columns.Add("CR_PAID_AMT", typeof(string));
                                    table.Columns.Add("BILL_NO", typeof(string));
                                    table.Columns.Add("BILL_DATE", typeof(string));
                                    table.Columns.Add("BILL_AMT", typeof(string));
                                    table.Columns.Add("T_RATE", typeof(string));
                                    table.Columns.Add("T_AMT", typeof(string));
                                    table.Columns.Add("S_RATE", typeof(string));
                                    table.Columns.Add("S_AMT", typeof(string));
                                    table.Columns.Add("TOT_TDS", typeof(string));
                                    table.Columns.Add("TDSACODE", typeof(string));
                                    table.Columns.Add("TRAN_TYPE", typeof(string));
                                    table.Columns.Add("BANK_NARRN", typeof(string));
                                    table.Columns.Add("PARTY_BANK", typeof(string));
                                    table.Columns.Add("OA_AMT", typeof(string));
                                    table.Columns.Add("OA_FLAG", typeof(string));
                                    table.Columns.Add("PARTY_TYPE", typeof(string));
                                }
                            }
                            for (int m = 0; m < DtDetails.Rows.Count; m++)
                            {
                                drm = table.NewRow();

                                drm["COMP_CODE"] = DtDetails.Rows[m]["COMP_CODE"].ToString();
                                drm["TRAN_DATE"] = DtDetails.Rows[m]["TRAN_DATE"].ToString();
                                drm["TRAN_NO"] = DtDetails.Rows[m]["TRAN_NO"].ToString();
                                drm["SR"] = DtDetails.Rows[m]["SR"].ToString();
                                drm["DRACODE"] = DtDetails.Rows[m]["DRACODE"].ToString();
                                drm["CRACODE"] = DtDetails.Rows[m]["CRACODE"].ToString();
                                drm["SIGN"] = DtDetails.Rows[m]["SIGN"].ToString();
                                drm["NARRN"] = DtDetails.Rows[m]["NARRN"].ToString();
                                drm["CHQ_NO"] = DtDetails.Rows[m]["CHQ_NO"].ToString();
                                drm["CHQ_DT"] = DtDetails.Rows[m]["CHQ_DT"].ToString();
                                drm["BANKDT"] = DtDetails.Rows[m]["BANKDT"].ToString();
                                drm["AMT"] = DtDetails.Rows[m]["AMT"].ToString();
                                drm["STATUS"] = DtDetails.Rows[m]["STATUS"].ToString();
                                drm["ENDT"] = DtDetails.Rows[m]["ENDT"].ToString();
                                drm["DR_PAID_AMT"] = DtDetails.Rows[m]["DR_PAID_AMT"].ToString();
                                drm["CR_PAID_AMT"] = DtDetails.Rows[m]["CR_PAID_AMT"].ToString();
                                drm["BILL_NO"] = DtDetails.Rows[m]["BILL_NO"].ToString();
                                drm["BILL_DATE"] = DtDetails.Rows[m]["BILL_DATE"].ToString();
                                drm["BILL_AMT"] = DtDetails.Rows[m]["BILL_AMT"].ToString();
                                drm["T_RATE"] = DtDetails.Rows[m]["T_RATE"].ToString();
                                drm["T_AMT"] = DtDetails.Rows[m]["T_AMT"].ToString();
                                drm["S_RATE"] = DtDetails.Rows[m]["S_RATE"].ToString();
                                drm["S_AMT"] = DtDetails.Rows[m]["S_AMT"].ToString();
                                drm["TOT_TDS"] = DtDetails.Rows[m]["TOT_TDS"].ToString();
                                drm["TDSACODE"] = DtDetails.Rows[m]["TDSACODE"].ToString();
                                drm["BANK_NARRN"] = DtDetails.Rows[m]["BANK_NARRN"].ToString();
                                drm["PARTY_BANK"] = DtDetails.Rows[m]["PARTY_BANK"].ToString();
                                drm["OA_AMT"] = DtDetails.Rows[m]["OA_AMT"].ToString();
                                drm["OA_FLAG"] = DtDetails.Rows[m]["OA_FLAG"].ToString();
                                drm["PARTY_TYPE"] = DtDetails.Rows[m]["PARTY_TYPE"].ToString();

                                TxtOnAccountAmount.Text = DtDetails.Rows[m]["OA_AMT"].ToString();
                                DdlOnAccount.SelectedValue = DtDetails.Rows[m]["OA_FLAG"].ToString();

                                table.Rows.Add(drm);
                            }

                       


                        #endregion
                        ViewState["CurrentTable"] = DtDetails;
                        GvPayReceiveDetails.DataSource = DtDetails;
                        GvPayReceiveDetails.DataBind();

                        }

                  if (DtInvoiceDetails.Rows.Count > 0)
                {
                    #region Assign To table


                    DataTable table = new DataTable();
                    DataRow drm = null;
                    if (ViewState["InvoiceTable"] != null)
                    {
                        table = (DataTable)ViewState["InvoiceTable"];
                    }
                    else
                    {
                        if (table.Rows.Count <= 0)
                        {
                            table.Columns.Add("COMP_CODE", typeof(string));
                            table.Columns.Add("TRAN_DATE", typeof(string));
                            table.Columns.Add("TRAN_NO", typeof(string));
                            table.Columns.Add("SR", typeof(string));
                            table.Columns.Add("SUB_SR", typeof(string));
                            table.Columns.Add("XXX_TYPE", typeof(string));
                            table.Columns.Add("XXX_DATE", typeof(string));
                            table.Columns.Add("XXX_NO", typeof(string));
                            table.Columns.Add("AMT", typeof(string));
                            table.Columns.Add("ENDT", typeof(string));
                            table.Columns.Add("TRAN_TYPE", typeof(string));
                            table.Columns.Add("ACODE", typeof(string));
                            table.Columns.Add("LESS_AMT", typeof(string));
                            table.Columns.Add("TDS_AMT", typeof(string));
                            table.Columns.Add("GST_RATE", typeof(string));
                            table.Columns.Add("GST_AMT", typeof(string));
                            table.Columns.Add("CGST_RATE", typeof(string));
                            table.Columns.Add("CGST_AMT", typeof(string));
                            table.Columns.Add("SGST_RATE", typeof(string));
                            table.Columns.Add("SGST_AMT", typeof(string));
                            table.Columns.Add("IGST_RATE", typeof(string));
                            table.Columns.Add("IGST_AMT", typeof(string));
                            table.Columns.Add("ACT_AMT", typeof(string));

                            table.Columns.Add("inv_date", typeof(string));
                            table.Columns.Add("inv_no", typeof(string));
                            table.Columns.Add("bill_amt", typeof(string));
                            table.Columns.Add("bill_paid_amt", typeof(string));
                            table.Columns.Add("last_paiddate", typeof(string));
                            table.Columns.Add("last_paidchqno", typeof(string));
                            table.Columns.Add("bal_amt", typeof(string));
                            table.Columns.Add("Bill_Bal_Amt", typeof(string));


                        }
                    }

                    for (int m = 0; m < DtInvoiceDetails.Rows.Count; m++)
                    {
                        drm = table.NewRow();

                        //drm["COMP_CODE"] = DtInvoiceDetails.Rows[m]["COMP_CODE"].ToString();
                        //drm["TRAN_DATE"] = DtInvoiceDetails.Rows[m]["TRAN_DATE"].ToString();
                        //drm["TRAN_NO"] = DtInvoiceDetails.Rows[m]["TRAN_NO"].ToString();
                        //drm["SR"] = DtInvoiceDetails.Rows[m]["SR"].ToString();
                        drm["SUB_SR"] = DtInvoiceDetails.Rows[m]["SUB_SR"].ToString();
                        drm["XXX_TYPE"] = DtInvoiceDetails.Rows[m]["XXX_TYPE"].ToString();
                        drm["XXX_DATE"] = DtInvoiceDetails.Rows[m]["XXX_DATE"].ToString();
                        drm["XXX_NO"] = DtInvoiceDetails.Rows[m]["XXX_NO"].ToString();
                        drm["AMT"] = DtInvoiceDetails.Rows[m]["AMT"].ToString();
                        drm["ENDT"] = DtInvoiceDetails.Rows[m]["ENDT"].ToString();
                        drm["TRAN_TYPE"] = DtInvoiceDetails.Rows[m]["TRAN_TYPE"].ToString();
                        drm["ACODE"] = DtInvoiceDetails.Rows[m]["ACODE"].ToString();
                        drm["LESS_AMT"] = DtInvoiceDetails.Rows[m]["LESS_AMT"].ToString();
                        drm["TDS_AMT"] = DtInvoiceDetails.Rows[m]["TDS_AMT"].ToString();
                        //drm["GST_RATE"] = DtInvoiceDetails.Rows[m]["GST_RATE"].ToString();
                        //drm["GST_AMT"] = DtInvoiceDetails.Rows[m]["GST_AMT"].ToString();
                        //drm["CGST_RATE"] = DtInvoiceDetails.Rows[m]["CGST_AMT"].ToString();
                        //drm["CGST_AMT"] = DtInvoiceDetails.Rows[m]["CGST_AMT"].ToString();
                        //drm["SGST_RATE"] = DtInvoiceDetails.Rows[m]["SGST_RATE"].ToString();
                        //drm["SGST_AMT"] = DtInvoiceDetails.Rows[m]["SGST_AMT"].ToString();
                        //drm["IGST_RATE"] = DtInvoiceDetails.Rows[m]["IGST_RATE"].ToString();
                        //drm["IGST_AMT"] = DtInvoiceDetails.Rows[m]["IGST_AMT"].ToString();
                        //drm["ACT_AMT"] = DtInvoiceDetails.Rows[m]["ACT_AMT"].ToString();
                         drm["inv_date"] = DtInvoiceDetails.Rows[m]["inv_date"].ToString();
                        drm["inv_no"] = DtInvoiceDetails.Rows[m]["inv_no"].ToString();
                        drm["bill_amt"] = DtInvoiceDetails.Rows[m]["bill_amt"].ToString();
                        drm["bill_paid_amt"] = DtInvoiceDetails.Rows[m]["bill_paid_amt"].ToString();
                        drm["last_paiddate"] = DtInvoiceDetails.Rows[m]["last_paiddate"].ToString();
                        drm["last_paidchqno"] = DtInvoiceDetails.Rows[m]["last_paidchqno"].ToString();
                        drm["bal_amt"] = DtInvoiceDetails.Rows[m]["bal_amt"].ToString();
                        drm["Bill_Bal_Amt"] = DtInvoiceDetails.Rows[m]["Bill_Bal_Amt"].ToString();

                        table.Rows.Add(drm);

                    }


                    #endregion

                    ViewState["InvoiceTable"] = table;
                    GvPayReceiveInvoice.DataSource = DtInvoiceDetails;
                    GvPayReceiveInvoice.DataBind();
                }

                BtncallUpd.Text = "UPDATE";

                #endregion

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


                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = PAY_REC_MLogicLayer.GetAllIDWisePAY_REC_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtInvoiceDetails = ds.Tables[2];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            DdlTransactionType.SelectedValue = dt.Rows[0]["TRAN_TYPE"].ToString();
                            HfACODE.Value = dt.Rows[0]["ACODE"].ToString();
                            FillAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            TxtVoucherDate.Text = Convert.ToDateTime(dt.Rows[0]["VOU_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtVoucherNo.Text = dt.Rows[0]["VOU_NO"].ToString();
                            HfTransactionBCODE.Value = dt.Rows[0]["BCODE"].ToString();
                            FillTransactionByPersonOnUpdate(dt.Rows[0]["BCODE"].ToString());
                            DdlAuthorized.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtAuthorizedDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            TxtAuthorizedBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            DdlConfirm.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();

                        }

                        Session["TRAN_NO"] = e.CommandArgument.ToString();
                        Session["TRAN_DATE"] = HfTranDate.Value;
                        Session["TRAN_TYPE"] = DdlTransactionType.SelectedValue;
                        Session["ACODE"] = HfACODE.Value.Trim();


                        if (DtDetails.Rows.Count > 0)
                        {
                            GvPayReceiveDetails.DataSource = DtDetails;
                            GvPayReceiveDetails.DataBind();

                            TxtOnAccountAmount.Text = DtDetails.Rows[0]["OA_AMT"].ToString();
                            DdlOnAccount.SelectedValue = DtDetails.Rows[0]["OA_FLAG"].ToString();
                        }

                        if (DtInvoiceDetails.Rows.Count > 0)
                        {
                            GvPayReceiveInvoice.DataSource = DtInvoiceDetails;
                            GvPayReceiveInvoice.DataBind();
                        }

                        #endregion
                        ControllerDisable();
                        btnSave.Visible = false;
                        Btncalldel.Visible = false;
                        BtncallUpd.Visible = false;
                        UserRights();
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
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
        }


        protected void Btncalldel_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE  
                string str = PAY_REC_MLogicLayer.DeletePAY_REC_MASDetailsByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value));
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
                    lblmsg.Text = "Error:Pay Received Master Deleted";
                    lblmsg.ForeColor = Color.Red;
                }
                clear();
                UserRights();
                FillPAY_REC_MasterGrid(Convert.ToString(Session["COMP_CODE"]));
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtPartyName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfCreditAcode = (HiddenField)row.Cells[0].FindControl("HfCreditAcode");
                HiddenField HfDebitAcode = (HiddenField)row.Cells[0].FindControl("HfDebitAcode");
                HiddenField HfACODEInner = (HiddenField)row.Cells[0].FindControl("HfACODEInner");
                TextBox TxtPartyName = (TextBox)row.Cells[1].FindControl("TxtPartyName");

                DataTable DtAccountName = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();


                DtAccountName = ACCOUNTS_MASLogicLayer.GetAllACCOUNTDetialsByComapnyAndBranch(Comp_Code, Branchcode);

                if (DdlTransactionType.SelectedValue == "P")
                {

                    if (txt.Text != string.Empty)
                    {
                        DataView Dv = new DataView(DtAccountName);
                        Dv.RowFilter = "ANAME='" + txt.Text.Trim() + "'";
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            HfCreditAcode.Value = DtView.Rows[0]["ACODE"].ToString();

                            HfACODEInner.Value = DtView.Rows[0]["ACODE"].ToString();
                            //  FillOnGridChargesDetailChanged();
                        }
                        else
                        {
                            HfCreditAcode.Value = null;

                            HfACODEInner.Value = null;
                        }
                    }
                }
                else if (DdlTransactionType.SelectedValue == "R")
                {
                    DataView Dv = new DataView(DtAccountName);
                    Dv.RowFilter = "ANAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfDebitAcode.Value = DtView.Rows[0]["ACODE"].ToString();

                        HfACODEInner.Value = DtView.Rows[0]["ACODE"].ToString();
                        //  FillOnGridChargesDetailChanged();
                    }
                    else
                    {
                        HfDebitAcode.Value = null;

                        HfACODEInner.Value = null;
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvPayReceiveDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField HfDebitAcode = (e.Row.FindControl("HfDebitAcode") as HiddenField);
                    HiddenField HfCreditAcode = (e.Row.FindControl("HfCreditAcode") as HiddenField);
                    HiddenField HfACODEInner = (e.Row.FindControl("HfACODEInner") as HiddenField);

                    TextBox TxtPartyName = (e.Row.FindControl("TxtPartyName") as TextBox);

                    TextBox TxtPartyBankName = (e.Row.FindControl("TxtPartyBankName") as TextBox);
                    TextBox TxtChequeNo = (e.Row.FindControl("TxtChequeNo") as TextBox);
                    TextBox TxtChequeDate = (e.Row.FindControl("TxtChequeDate") as TextBox);
                    TextBox TxtBankDate = (e.Row.FindControl("TxtBankDate") as TextBox);

                    #region HIDE BANK COLUMNS DURING CASH TRANSATION
                    
                    if(ViewState["Trn_Type"].ToString()=="C")
                    {
                        GvPayReceiveDetails.Columns[3].Visible = false;
                        GvPayReceiveDetails.Columns[4].Visible = false;
                        GvPayReceiveDetails.Columns[5].Visible = false;
                        GvPayReceiveDetails.Columns[6].Visible = false;
                    }
                    else if (ViewState["Trn_Type"].ToString() == "B")
                    {
                        GvPayReceiveDetails.Columns[3].Visible = true;
                        GvPayReceiveDetails.Columns[4].Visible = true;
                        GvPayReceiveDetails.Columns[5].Visible = true;
                        GvPayReceiveDetails.Columns[6].Visible = true;
                    }

                    #endregion



                    #region GET ACCOUNT NAME ON UPDATE

                    DataTable DtAccountName = new DataTable();

                    DtAccountName = ACCOUNTS_MASLogicLayer.GetAllACCOUNTDetialsByComapnyAndBranch(compcode, Branchcode);

                    if (DdlTransactionType.SelectedValue == "P")
                    {

                        if (HfDebitAcode.Value != string.Empty && HfDebitAcode.Value != null)
                        {
                            DataView Dv = new DataView(DtAccountName);
                            Dv.RowFilter = "ACODE='" + HfDebitAcode.Value.Trim() + "'";
                            DataTable DtView = Dv.ToTable();
                            if (DtView.Rows.Count > 0)
                            {
                                HfDebitAcode.Value = DtView.Rows[0]["ACODE"].ToString();
                                HfACODEInner.Value = DtView.Rows[0]["ACODE"].ToString();
                                TxtPartyName.Text = DtView.Rows[0]["ANAME"].ToString();
                            }
                            else
                            {
                                HfACODEInner.Value = string.Empty;
                                HfDebitAcode.Value = null;
                                TxtPartyName.Text = string.Empty;
                            }
                        }
                    }
                    else if (DdlTransactionType.SelectedValue == "R")
                    {
                        if (HfCreditAcode.Value != string.Empty && HfCreditAcode.Value != null)
                        {

                            DataView Dv = new DataView(DtAccountName);
                            Dv.RowFilter = "ACODE='" + HfCreditAcode.Value.Trim() + "'";
                            DataTable DtView = Dv.ToTable();
                            if (DtView.Rows.Count > 0)
                            {
                                HfCreditAcode.Value = DtView.Rows[0]["ACODE"].ToString();
                                HfACODEInner.Value = DtView.Rows[0]["ACODE"].ToString();
                                TxtPartyName.Text = DtView.Rows[0]["ANAME"].ToString();
                            }
                            else
                            {
                                HfACODEInner.Value = string.Empty;
                                HfCreditAcode.Value = null;
                                TxtPartyName.Text = string.Empty;
                            }
                        }
                    }



                    #endregion


                }




            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtAccountNameOnMasterGrid_TextChanged(object sender, EventArgs e)
        {
            #region Fill MASTER Grid On ACODE

            try
            {
                DataTable Dt = new DataTable();

                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTWiseComapnyAndBranchForInvoice(compcode, Branchcode);


                if (TxtAccountNameOnMasterGrid.Text != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "ANAME='" + TxtAccountNameOnMasterGrid.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfAccountCodeOnMasterGrid.Value = DtView.Rows[0]["ACODE"].ToString();
                    }
                    else
                    {
                        HfAccountCodeOnMasterGrid.Value = null;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            #endregion
        }

        protected void BtnFetchInvoice_Click(object sender, EventArgs e)
        {


            for (int i = 0; i < GvPayReceiveDetails.Rows.Count; i++)
            {
                HiddenField HfDebitAcode = (HiddenField)GvPayReceiveDetails.Rows[i].FindControl("HfDebitAcode");
                HiddenField HfCreditAcode = (HiddenField)GvPayReceiveDetails.Rows[i].FindControl("HfCreditAcode");
                HiddenField HfTranNo = (HiddenField)GvPayReceiveDetails.Rows[i].FindControl("HfTranNo");
                HiddenField HfSrNo = (HiddenField)GvPayReceiveDetails.Rows[i].FindControl("HfSrNo");
                HiddenField HfXXX_Type = (HiddenField)GvPayReceiveDetails.Rows[i].FindControl("HfXXX_Type");

                HiddenField HfACODEInner = (HiddenField)GvPayReceiveDetails.Rows[i].FindControl("HfACODEInner");

                string Debit, Credit;
                if (DdlTransactionType.SelectedValue == "P")
                {
                    Credit = HfACODE.Value.Trim();
                    Debit = HfACODEInner.Value.Trim();
                }
                else
                {
                    Credit = HfACODEInner.Value.Trim();
                    Debit = HfACODE.Value.Trim();
                }

                DataTable Dt = new DataTable();
                Dt = PAY_REC_MLogicLayer.GetPaidRecordForPAY_REC_INV(Convert.ToInt32(Session["BRANCH_CODE"].ToString()), Convert.ToInt32(HfACODEInner.Value.Trim()), Convert.ToInt32(Session["COMP_CODE"].ToString()), Convert.ToDateTime(TxtVoucherDate.Text.Trim()), ViewState["Tran_Type"].ToString(), ViewState["Tran_Type"].ToString(), Convert.ToInt32(Debit), Convert.ToInt32(Credit), 0, Convert.ToDateTime((Session["FIN_YEAR"].ToString())), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()));

                if(Dt.Rows.Count > 0)
                {
                    GvPayReceiveInvoice.DataSource = Dt;
                    GvPayReceiveInvoice.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected Party Outstanding Not Found...!!');", true);
                }

                
            }
        }

        protected void BtnInvoiceProcess_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                DataRow dr = null;
                table.Columns.Add("COMP_CODE", typeof(string));
                table.Columns.Add("TRAN_DATE", typeof(string));
                table.Columns.Add("TRAN_NO", typeof(string));
                table.Columns.Add("SR", typeof(string));
                table.Columns.Add("SUB_SR", typeof(string));
                table.Columns.Add("XXX_TYPE", typeof(string));
                table.Columns.Add("XXX_DATE", typeof(string));
                table.Columns.Add("XXX_NO", typeof(string));
                table.Columns.Add("AMT", typeof(string));
                table.Columns.Add("ENDT", typeof(string));
                table.Columns.Add("TRAN_TYPE", typeof(string));
                table.Columns.Add("ACODE", typeof(string));
                table.Columns.Add("LESS_AMT", typeof(string));
                table.Columns.Add("TDS_AMT", typeof(string));
                table.Columns.Add("GST_RATE", typeof(string));
                table.Columns.Add("GST_AMT", typeof(string));
                table.Columns.Add("CGST_RATE", typeof(string));
                table.Columns.Add("CGST_AMT", typeof(string));
                table.Columns.Add("SGST_RATE", typeof(string));
                table.Columns.Add("SGST_AMT", typeof(string));
                table.Columns.Add("IGST_RATE", typeof(string));
                table.Columns.Add("IGST_AMT", typeof(string));
                table.Columns.Add("ACT_AMT", typeof(string));

                table.Columns.Add("inv_date", typeof(string));
                table.Columns.Add("inv_no", typeof(string));
                table.Columns.Add("bill_amt", typeof(string));
                table.Columns.Add("bill_paid_amt", typeof(string));
                table.Columns.Add("last_paiddate", typeof(string));
                table.Columns.Add("last_paidchqno", typeof(string));
                table.Columns.Add("bal_amt", typeof(string));
                table.Columns.Add("Bill_Bal_Amt", typeof(string));


                foreach (GridViewRow row in GvPayReceiveInvoice.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox ChkSelectBill = row.FindControl("ChkSelectBill") as CheckBox;
                        HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                        HiddenField HfTranNo = row.FindControl("HfTranNo") as HiddenField;
                        HiddenField HfXXX_No = row.FindControl("HfXXX_No") as HiddenField;
                        HiddenField HfXXX_Date = row.FindControl("HfXXX_Date") as HiddenField;
                        HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                        HiddenField HfSubSrNo = row.FindControl("HfSubSrNo") as HiddenField;
                        HiddenField HfInvACODE = row.FindControl("HfInvACODE") as HiddenField;
                        HiddenField HfXXX_Type = row.FindControl("HfXXX_Type") as HiddenField;
                        HiddenField HfGST_AMT = row.FindControl("HfGST_AMT") as HiddenField;
                        HiddenField HfCGST_RATE = row.FindControl("HfCGST_RATE") as HiddenField;
                        HiddenField HfSGST_RATE = row.FindControl("HfSGST_RATE") as HiddenField;
                        HiddenField HfIGST_RATE = row.FindControl("HfIGST_RATE") as HiddenField;

                        Label lblSubSrNo = row.FindControl("lblSubSrNo") as Label;

                        TextBox TxtBillDate = row.FindControl("TxtBillDate") as TextBox;
                        TextBox TxtBillNo = row.FindControl("TxtBillNo") as TextBox;
                        TextBox TxtBillAmount = row.FindControl("TxtBillAmount") as TextBox;
                        TextBox TxtTotalPaidAmount = row.FindControl("TxtTotalPaidAmount") as TextBox;
                        TextBox TxtLastPaidDate = row.FindControl("TxtLastPaidDate") as TextBox;
                        TextBox TxtLastPaidChequeNo = row.FindControl("TxtLastPaidChequeNo") as TextBox;
                        TextBox TxtBillBalanceAmount = row.FindControl("TxtBillBalanceAmount") as TextBox;
                        TextBox TxtCurrentPaidAmount = row.FindControl("TxtCurrentPaidAmount") as TextBox;
                        TextBox TxtTDSAmount = row.FindControl("TxtTDSAmount") as TextBox;
                        TextBox TxtDiscountAmount = row.FindControl("TxtDiscountAmount") as TextBox;
                        TextBox TxtCurrentBalAmount = row.FindControl("TxtCurrentBalAmount") as TextBox;

                        if (ChkSelectBill.Checked == true)
                        {

                            dr = table.NewRow();


                            dr["COMP_CODE"] = string.Empty;
                            dr["TRAN_DATE"] = string.Empty;
                            dr["TRAN_NO"] = string.Empty;
                            dr["SR"] = string.Empty;
                            dr["SUB_SR"] = lblSubSrNo.Text.Trim();
                            dr["XXX_TYPE"] = HfXXX_Type.Value.Trim();
                            dr["XXX_DATE"] = HfXXX_Date.Value.Trim().ToString();
                            dr["XXX_NO"] = HfXXX_No.Value.Trim().ToString();
                            dr["AMT"] = TxtCurrentPaidAmount.Text.Trim().ToString();
                            dr["ENDT"] = string.Empty;
                            dr["TRAN_TYPE"] = HfTranType.Value.Trim();
                            dr["ACODE"] = HfInvACODE.Value.Trim();
                            dr["LESS_AMT"] = TxtDiscountAmount.Text.Trim().ToString();
                            dr["TDS_AMT"] = TxtTDSAmount.Text.Trim().ToString();
                            dr["GST_RATE"] = string.Empty;
                            dr["GST_AMT"] = string.Empty;
                            dr["CGST_RATE"] = string.Empty;
                            dr["CGST_AMT"] = string.Empty;
                            dr["SGST_RATE"] = string.Empty;
                            dr["SGST_AMT"] = string.Empty;
                            dr["IGST_RATE"] = string.Empty;
                            dr["IGST_AMT"] = string.Empty;
                            dr["ACT_AMT"] = string.Empty;

                            dr["inv_date"] = TxtBillDate.Text.Trim().ToString();
                            dr["inv_no"] = TxtBillNo.Text.Trim().ToString();
                            dr["bill_amt"] = TxtBillAmount.Text.Trim().ToString();
                            dr["bill_paid_amt"] = TxtTotalPaidAmount.Text.Trim().ToString();
                            dr["last_paiddate"] = TxtLastPaidDate.Text.Trim().ToString();
                            dr["last_paidchqno"] = TxtLastPaidChequeNo.Text.Trim().ToString();
                            dr["bal_amt"] = TxtBillBalanceAmount.Text.Trim().ToString();
                            dr["Bill_Bal_Amt"] = TxtCurrentPaidAmount.Text.Trim().ToString();


                            table.Rows.Add(dr);


                        }

                    }

                }

                ViewState["ProcessInvoiceTable"] = table;

                GvPayReceiveInvoice.DataSource = table;
                GvPayReceiveInvoice.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void ChkSelectBill_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox ChkSel = (CheckBox)sender;
                GridViewRow row = (GridViewRow)ChkSel.Parent.Parent;
                int idx = row.RowIndex;

                TextBox Amount_T = (TextBox)GvPayReceiveDetails.Rows[0].FindControl("TxtAmount");

                TextBox TxtBillBalanceAmount = (TextBox)row.Cells[8].FindControl("TxtBillBalanceAmount");
                TextBox TxtCurrentPaidAmount = (TextBox)row.Cells[9].FindControl("TxtCurrentPaidAmount");
                TextBox TxtCurrentBalAmount = (TextBox)row.Cells[12].FindControl("TxtCurrentBalAmount");

                Label lblSumTotalBillAmount = (Label)(GvPayReceiveInvoice.FooterRow.FindControl("lblSumTotalBillAmount"));
                Label lblSumTotalPaidAmount = (Label)(GvPayReceiveInvoice.FooterRow.FindControl("lblSumTotalPaidAmount"));
                Label lblSumTotalBillBalanceAmount = (Label)(GvPayReceiveInvoice.FooterRow.FindControl("lblSumTotalBillBalanceAmount"));
                Label lblSumTotalCurrentPaidAmount = (Label)(GvPayReceiveInvoice.FooterRow.FindControl("lblSumTotalCurrentPaidAmount"));
                Label lblSumTotalCurrentBalanceAmount = (Label)(GvPayReceiveInvoice.FooterRow.FindControl("lblSumTotalCurrentBalanceAmount"));
                Label lblSumTotalTDSAmount = (Label)(GvPayReceiveInvoice.FooterRow.FindControl("lblSumTotalTDSAmount"));
                Label lblSumTotalDiscountAmount = (Label)(GvPayReceiveInvoice.FooterRow.FindControl("lblSumTotalDiscountAmount"));


                double SumTotalBillAmt = TotalBillAmount();
                lblSumTotalBillAmount.Text = SumTotalBillAmt.ToString();

                double SumTotalPaidAmt = TotalPaidAmount();
                lblSumTotalPaidAmount.Text = SumTotalPaidAmt.ToString();

                double SumTotalBillBalanceAmt = TotalBillBalanceAmount();
                lblSumTotalBillBalanceAmount.Text = SumTotalBillBalanceAmt.ToString();

                double SumTotalTDSAmt = TotalTDSAmount();
                lblSumTotalTDSAmount.Text = SumTotalTDSAmt.ToString();

                double SumTotalDiscountAmt = TotalDiscountAmount();
                lblSumTotalDiscountAmount.Text = SumTotalDiscountAmt.ToString();



                decimal currbalAmount = 0;
                if (ChkSel.Checked == true)
                {
                    decimal Amount_TD = 0;
                    if(Amount_T.Text.Trim()!=string.Empty)
                    {
                        Amount_TD = Convert.ToDecimal(Amount_T.Text.Trim());
                        if (Amount_TD > Convert.ToDecimal(TxtBillBalanceAmount.Text.Trim()))
                        {
                            TxtCurrentPaidAmount.Text = TxtBillBalanceAmount.Text.Trim();
                        }
                        else
                        {
                            TxtCurrentPaidAmount.Text = Amount_T.Text;
                        }

                    }

                    

                    if (TxtCurrentPaidAmount.Text != string.Empty && TxtCurrentPaidAmount.Text != null)
                    {
                        currbalAmount = Convert.ToDecimal(TxtBillBalanceAmount.Text) - Convert.ToDecimal(TxtCurrentPaidAmount.Text);
                      
                        TxtCurrentBalAmount.Text = Convert.ToString(currbalAmount);
                     

                        double SumTotalCurrentPaidAmt = TotalCurrentPaidAmount();
                        lblSumTotalCurrentPaidAmount.Text = SumTotalCurrentPaidAmt.ToString();


                        double SumTotalCurrentBalanceAmt = TotalCurrentBalanceAmount();
                        lblSumTotalCurrentBalanceAmount.Text = SumTotalCurrentBalanceAmt.ToString();

                       
                        if (Amount_T.Text != string.Empty && Amount_T.Text != null)
                        {
                            TxtOnAccountAmount.Text = Convert.ToString(Convert.ToDouble(Amount_T.Text) - Convert.ToDouble(SumTotalCurrentPaidAmt));
                        }

                        if (Convert.ToInt32(TxtOnAccountAmount.Text) == 0)
                        {
                            DdlOnAccount.SelectedValue = "N";
                        }
                        else
                        {
                            DdlOnAccount.SelectedValue = "Y";
                        }

                    }
                }

                else
                {
                    TxtCurrentPaidAmount.Text = "0";

                    currbalAmount = Convert.ToDecimal(TxtBillBalanceAmount.Text) - Convert.ToDecimal(TxtCurrentPaidAmount.Text);
                    TxtCurrentBalAmount.Text = Convert.ToString(currbalAmount);

                    double SumTotalCurrentPaidAmt = TotalCurrentPaidAmount();
                    lblSumTotalCurrentPaidAmount.Text = SumTotalCurrentPaidAmt.ToString();

                    double SumTotalCurrentBalanceAmt = TotalCurrentBalanceAmount();
                    lblSumTotalCurrentBalanceAmount.Text = SumTotalCurrentBalanceAmt.ToString();

                    double SumTotalTDSAmt1 = TotalTDSAmount();
                    lblSumTotalTDSAmount.Text = SumTotalTDSAmt1.ToString();

                    double SumTotalDiscountAmt1 = TotalDiscountAmount();
                    lblSumTotalDiscountAmount.Text = SumTotalDiscountAmt1.ToString();


                    if (Amount_T.Text != string.Empty && Amount_T.Text != null)
                    {
                        TxtOnAccountAmount.Text = Convert.ToString(Convert.ToDouble(Amount_T.Text) - Convert.ToDouble(SumTotalCurrentPaidAmt));
                    }


                    if (Convert.ToInt32(TxtOnAccountAmount.Text) == 0)
                    {
                        DdlOnAccount.SelectedValue = "N";
                    }
                    else
                    {
                        DdlOnAccount.SelectedValue = "Y";
                    }

                  
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void GvPayReceiveInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblSumTotalBillAmount = (Label)e.Row.FindControl("lblSumTotalBillAmount");
                    Label lblSumTotalPaidAmount = (Label)e.Row.FindControl("lblSumTotalPaidAmount");
                    Label lblSumTotalBillBalanceAmount = (Label)e.Row.FindControl("lblSumTotalBillBalanceAmount");
                    Label lblSumTotalCurrentPaidAmount = (Label)e.Row.FindControl("lblSumTotalCurrentPaidAmount");
                    Label lblSumTotalCurrentBalanceAmount = (Label)e.Row.FindControl("lblSumTotalCurrentBalanceAmount");
                    Label lblSumTotalTDSAmount = (Label)e.Row.FindControl("lblSumTotalTDSAmount");
                    Label lblSumTotalDiscountAmount = (Label)e.Row.FindControl("lblSumTotalDiscountAmount");


                    double SumTotalBillAmt = TotalBillAmount();
                    lblSumTotalBillAmount.Text = SumTotalBillAmt.ToString();

                    double SumTotalPaidAmt = TotalPaidAmount();
                    lblSumTotalPaidAmount.Text = SumTotalPaidAmt.ToString();

                    double SumTotalBillBalanceAmt = TotalBillBalanceAmount();
                    lblSumTotalBillBalanceAmount.Text = SumTotalBillBalanceAmt.ToString();

                    double SumTotalCurrentPaidAmt = TotalCurrentPaidAmount();
                    lblSumTotalCurrentPaidAmount.Text = SumTotalCurrentPaidAmt.ToString();

                    double SumTotalCurrentBalanceAmt = TotalCurrentBalanceAmount();
                    lblSumTotalCurrentBalanceAmount.Text = SumTotalCurrentBalanceAmt.ToString();

                    double SumTotalTDSAmt = TotalTDSAmount();
                    lblSumTotalTDSAmount.Text = SumTotalTDSAmt.ToString();

                    double SumTotalDiscountAmt = TotalDiscountAmount();
                    lblSumTotalDiscountAmount.Text = SumTotalDiscountAmt.ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlConfirm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlAuthorized_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlAuthorized.SelectedValue == "Y")
                {
                    TxtAuthorizedBy.Text = Session["USERNAME"].ToString();
                    TxtAuthorizedDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    TxtAuthorizedBy.Text = "";
                    TxtAuthorizedDate.Text = "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvPayReceiveMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btnedit = (e.Row.FindControl("btnEdit") as Button);
                    Button btndelete = (e.Row.FindControl("btnDelete") as Button);
                    Label lblchk = (e.Row.FindControl("lblCongirmFlag") as Label);

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

        protected void btnViewVoucherFullPrint_Click(object sender, EventArgs e)
        {
            Session["PAGE_HEIGHT"] = "A4";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewCashBankVoucher.aspx', '_blank');", true);
        }

        protected void btnViewVoucherHalfPrint_Click(object sender, EventArgs e)
        {
            Session["PAGE_HEIGHT"] = "A5";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewCashBankVoucher.aspx', '_blank');", true);
        }

        protected void btnPrintBankChequeSlip_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewBankDepositChequeSlip.aspx', '_blank');", true);
        }

        protected void btnPrintReceiptBill_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewPaymentReciptOutstandingSubReport.aspx', '_blank');", true);
        }
    }
}