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
    public partial class CreditDebitNote : System.Web.UI.Page
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

                    if (!string.IsNullOrWhiteSpace(Request.QueryString["TRAN_TYPE"]))
                    {
                        HfTranType.Value = Request.QueryString["TRAN_TYPE"];
                    }

                    if (HfTranType.Value.ToString() == "A")
                    {
                        hdForCreditNote.Visible = true;
                        hdForDebitNote.Visible = false;
                        lblCreditAccount.Visible = true;
                        lblCreditNarration.Visible = true;



                    }
                    else if (HfTranType.Value.ToString() == "B")
                    {
                        hdForCreditNote.Visible = false;
                        hdForDebitNote.Visible = true;
                    }

                    DivEntry.Visible = false;
                    DivView.Visible = true;
                    //SetInitialRow();
                    SetInitialRowInvoice();
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


        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            TxtVoucherNo.Text = string.Empty;
            TxtVoucherDate.Text = string.Empty;
            HfCreditACODE.Value = string.Empty;
            TxtCreditAccountName.Text = string.Empty;
            TxtCreditAmount.Text = string.Empty;
            TxtCreditNarration.Text = string.Empty;
            DdlCreditSign.SelectedValue = "CR";
            HfDebitACODE.Value = string.Empty;
            TxtDebitAccountName.Text = string.Empty;
            TxtDebitNarration.Text = string.Empty;
            TxtDebitAmount.Text = string.Empty;
            DdlDebitSign.SelectedValue = "DR";
            DdlConfirm.SelectedValue = "N";
            TxtConfirmBy.Text = string.Empty;
            TxtConfirmDate.Text = string.Empty;
            DdlApproval.SelectedValue = "N";
            TxtApprovalBy.Text = string.Empty;
            TxtApprovalDate.Text = string.Empty;

            BtncallUpd.Text = "SAVE";

            SetInitialRowInvoice();

        }


        public void ControllerEnable()
        {
            TxtVoucherNo.Enabled = true;
            TxtVoucherDate.Enabled = true;
            TxtCreditAccountName.Enabled = true;
            TxtCreditAmount.Enabled = true;
            TxtCreditNarration.Enabled = true;
            DdlCreditSign.Enabled = true;
            TxtDebitAccountName.Enabled = true;
            TxtDebitNarration.Enabled = true;
            TxtDebitAmount.Enabled = true;
            DdlDebitSign.Enabled = true;
            DdlConfirm.Enabled = true;
            TxtConfirmBy.Enabled = true;
            TxtConfirmDate.Enabled = true;
            DdlApproval.Enabled = true;
            TxtApprovalBy.Enabled = true;
            TxtApprovalDate.Enabled = true;

        }

        public void ControllerDisable()
        {
            TxtVoucherNo.Enabled = false;
            TxtVoucherDate.Enabled = false;
            TxtCreditAccountName.Enabled = false;
            TxtCreditAmount.Enabled = false;
            TxtCreditNarration.Enabled = false;
            DdlCreditSign.Enabled = false;
            TxtDebitAccountName.Enabled = false;
            TxtDebitNarration.Enabled = false;
            TxtDebitAmount.Enabled = false;
            DdlDebitSign.Enabled = false;
            DdlConfirm.Enabled = false;
            TxtConfirmBy.Enabled = false;
            TxtConfirmDate.Enabled = false;
            DdlApproval.Enabled = false;
            TxtApprovalBy.Enabled = false;
            TxtApprovalDate.Enabled = false;

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

        private double TotalTaxableAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvPayReceiveInvoice.Rows.Count; i++)
            {
                string total = (GvPayReceiveInvoice.Rows[i].FindControl("TxtTaxableAmount") as TextBox).Text;
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
            for (int i = 0; i < GvPayReceiveInvoice.Rows.Count; i++)
            {
                string total = (GvPayReceiveInvoice.Rows[i].FindControl("TxtCGSTAmount") as TextBox).Text;
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
            for (int i = 0; i < GvPayReceiveInvoice.Rows.Count; i++)
            {
                string total = (GvPayReceiveInvoice.Rows[i].FindControl("TxtSGSTAmount") as TextBox).Text;
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
            for (int i = 0; i < GvPayReceiveInvoice.Rows.Count; i++)
            {
                string total = (GvPayReceiveInvoice.Rows[i].FindControl("TxtIGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }

        #endregion


        public void FillPAY_REC_MasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = PAY_REC_MLogicLayer.GetAllPAY_REC_MDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()),HfTranType.Value.Trim().ToString());
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvCreditDebitNoteMaster.DataSource = Dv.ToTable();
            GvCreditDebitNoteMaster.DataBind();

            DtSearch = Dv.ToTable();

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

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetGSTReasonName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select name from gst_reasonmas where name like '%' + @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> gstName = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                gstName.Add(dt.Rows[i][0].ToString());
            }
            return gstName;
        }



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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            lblmsg.Text = string.Empty;
            UserRights();
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
                //   GetGstReason();

                string Voucher_NO = PAY_REC_MLogicLayer.GetVoucherNumber_PAY_REC_MASCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtVoucherDate.Text.Trim()).ToString("yyyy-MM-dd"), HfTranType.Value.ToString());
                if (Voucher_NO.Length <= 8)
                {
                    TxtVoucherNo.Text = Voucher_NO;
                }
                else
                {
                    TxtVoucherNo.Text = string.Empty;
                }

                if (HfTranType.Value.ToString() == "A")
                {
                    lblCreditAccount.Text = "Credit A/ C";
                    lblCreditNarration.Text = "Credit Narration";
                    lblDebitAccounts.Text = "Debit A/ C";
                    lblDebitNarrartion.Text = "Debit Narration";
                    DdlCreditSign.SelectedValue = "CR";
                    DdlDebitSign.SelectedValue = "DR";
                }
                else if (HfTranType.Value.ToString() == "B")
                {
                    lblCreditAccount.Text = "Debit A/ C";
                    lblCreditNarration.Text = "Debit Narration";
                    lblDebitAccounts.Text = "Credit A/ C";
                    lblDebitNarrartion.Text = "Credit Narration";
                    DdlCreditSign.SelectedValue = "DR";
                    DdlDebitSign.SelectedValue = "CR";
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


        protected void TxtCreditAmount_TextChanged(object sender, EventArgs e)
        {
            if (TxtCreditAmount.Text != string.Empty)
            {
                TxtDebitAmount.Text = TxtCreditAmount.Text;
            }
        }

        protected void TxtGSTReason_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select code from gst_reasonmas  where name = '" + TxtGSTReason.Text.Trim() + "'", con);
                int x = Convert.ToInt32(cmd.ExecuteScalar());

                if (x == 0)
                {
                    TxtGSTReason.BackColor = Color.Red;

                }
                else
                {
                    HfGstResonCode.Value = cmd.ExecuteScalar().ToString();
                    TxtGSTReason.BackColor = Color.White; con.Close();
                }
            }
            catch (Exception ex)
            {

                ex.ToString();
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
                    #region INSERT CREDIT NOTE INTO PAY_REC_M 

                    PAY_REC_MLogicLayer insert = new PAY_REC_MLogicLayer();


                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.TRAN_TYPE = HfTranType.Value.Trim();
                    //  insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                    //insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.VOU_DATE = Convert.ToDateTime(TxtVoucherDate.Text.Trim()).ToString("MM-dd-yyyy");
                    insert.VOU_NO = TxtVoucherNo.Text.Trim();

                    if (HfTranType.Value.ToString() == "A")
                    {
                        insert.ACODE = HfCreditACODE.Value.Trim();
                        insert.SIGN = DdlCreditSign.SelectedValue.Trim();//CR
                        insert.NARRN = TxtCreditNarration.Text.Trim();
                        insert.AMT = TxtCreditAmount.Text.Trim();
                    }
                    else if (HfTranType.Value.ToString() == "B")
                    {
                        insert.ACODE = HfDebitACODE.Value.Trim();
                        insert.SIGN = DdlCreditSign.SelectedValue.Trim();//DR
                        insert.NARRN = TxtCreditNarration.Text.Trim();
                        insert.AMT = TxtCreditAmount.Text.Trim();
                    }

                    insert.ENDT = "";
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = "";
                    insert.UPD_DATE = "";
                    insert.RW_CODE = null;
                    insert.FIGURE_FLAG = "";
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
                    insert.TRN_TYPE = "";
                    insert.TRNDT = "";
                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                    insert.CHK_FLAG = DdlApproval.SelectedValue.Trim().ToUpper();
                    if (DdlApproval.SelectedValue.Trim() == "Y")
                    {
                        insert.CHK_DATE = Convert.ToDateTime(TxtApprovalDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CHK_DATE = "";
                    }

                    if (DdlApproval.SelectedValue.Trim() == "Y")
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

                    insert.BCODE = null;
                    insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToString();
                    insert.INV_REASON = HfGstResonCode.Value.Trim().ToString();

                    #endregion


                    #region INSERT INTO PAY_REC_T DETAILS

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int SRNO = 1;

                    if (TxtCreditAccountName.Text != string.Empty && TxtDebitAccountName.Text != null)
                    {


                        XmlElement HandleDetail2 = XDoc1.CreateElement("PAY_REC_Details");

                        HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                        //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                        //HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                        HandleDetail2.SetAttribute("SR", SRNO.ToString());


                        if (HfTranType.Value.ToString() == "A")
                        {
                            HandleDetail2.SetAttribute("DRACODE", HfDebitACODE.Value.Trim());
                            HandleDetail2.SetAttribute("CRACODE", HfCreditACODE.Value.Trim());
                            HandleDetail2.SetAttribute("NARRN", (TxtDebitNarration.Text.Trim()));
                            HandleDetail2.SetAttribute("AMT", (TxtDebitAmount.Text.Trim()));
                            HandleDetail2.SetAttribute("SIGN", (DdlDebitSign.SelectedValue.Trim()));
                            HandleDetail2.SetAttribute("TRAN_TYPE", ("A"));
                        }
                        else if (HfTranType.Value.ToString() == "B")
                        {
                            HandleDetail2.SetAttribute("DRACODE", (HfDebitACODE.Value.Trim()));
                            HandleDetail2.SetAttribute("CRACODE", (HfCreditACODE.Value.Trim()));
                            HandleDetail2.SetAttribute("NARRN", (TxtDebitNarration.Text.Trim()));
                            HandleDetail2.SetAttribute("AMT", (TxtDebitAmount.Text.Trim()));
                            HandleDetail2.SetAttribute("SIGN", (DdlDebitSign.SelectedValue.Trim()));
                            HandleDetail2.SetAttribute("TRAN_TYPE", ("B"));
                        }



                        root1.AppendChild(HandleDetail2);
                        SRNO++;


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
                            HiddenField HfXXX_Type = row.FindControl("HfXXX_Type") as HiddenField;
                            HiddenField HfXXX_Date = row.FindControl("HfXXX_Date") as HiddenField;
                            HiddenField HfXXX_No = row.FindControl("HfXXX_No") as HiddenField;
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
                            TextBox TxtTaxableAmount = row.FindControl("TxtTaxableAmount") as TextBox;
                            TextBox TxtGSTRate = row.FindControl("TxtGSTRate") as TextBox;
                            TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                            TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                            TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;



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
                                HandleDetail3.SetAttribute("TRAN_TYPE", (HfTranType.Value.ToString()));

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

                                if(TxtGSTRate.Text !=string.Empty)
                                {
                                    HandleDetail3.SetAttribute("GST_RATE", (TxtGSTRate.Text.Trim().ToString()));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("GST_RATE", ("0"));
                                }

                                if (HfGST_AMT.Value != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("GST_AMT", (HfGST_AMT.Value.Trim().ToString()));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("GST_AMT", ("0"));
                                }

                                if (HfCGST_RATE.Value != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("CGST_RATE", (HfCGST_RATE.Value.Trim()));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("CGST_RATE", ("0"));
                                }

                                if (TxtCGSTAmount.Text != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text.Trim().ToString()));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("CGST_AMT", ("0"));
                                }


                                if (HfSGST_RATE.Value != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("SGST_RATE", (HfSGST_RATE.Value.Trim()));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("SGST_RATE", ("0"));
                                }


                                if (TxtSGSTAmount.Text != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text.Trim().ToString()));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("SGST_AMT", ("0"));
                                }


                                if (HfIGST_RATE.Value != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("IGST_RATE", (HfIGST_RATE.Value.Trim()));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("IGST_RATE", ("0"));
                                }

                                if (TxtIGSTAmount.Text != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text.Trim().ToString()));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("IGST_AMT", ("0"));
                                }

                                if (TxtTaxableAmount.Text != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("ACT_AMT", (TxtTaxableAmount.Text.Trim().ToString()));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("ACT_AMT", ("0"));
                                }


                                root2.AppendChild(HandleDetail3);
                            //    SR_NO++;

                            }
                        }
                    }

                    #endregion


                    string str = PAY_REC_MLogicLayer.InsertPAY_REC_MDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"), HfTranType.Value.Trim().ToUpper());

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "CREDIT/DEBIT NOTE SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillPAY_REC_MasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "CREDIT/DEBIT NOTE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : CREDIT/DEBIT NOTE NOT SAVED";
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
                    lblmsg.Text = "Error:Credit Debit Note Master Deleted";
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region UPDATE CREDIT/DEBIT NOTE 

                #region INSERT CREDIT NOTE INTO PAY_REC_M 

                PAY_REC_MLogicLayer insert = new PAY_REC_MLogicLayer();


                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.TRAN_TYPE = HfTranType.Value.Trim();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.VOU_DATE = Convert.ToDateTime(TxtVoucherDate.Text.Trim()).ToString("MM-dd-yyyy");
                insert.VOU_NO = TxtVoucherNo.Text.Trim();

                if (HfTranType.Value.ToString() == "A")
                {
                    insert.ACODE = HfCreditACODE.Value.Trim();
                    insert.SIGN = DdlCreditSign.SelectedValue.Trim();//CR
                    insert.NARRN = TxtCreditNarration.Text.Trim();
                    insert.AMT = TxtCreditAmount.Text.Trim();
                }
                else if (HfTranType.Value.ToString() == "B")
                {
                    insert.ACODE = HfDebitACODE.Value.Trim();
                    insert.SIGN = DdlCreditSign.SelectedValue.Trim();//DR
                    insert.NARRN = TxtCreditNarration.Text.Trim();
                    insert.AMT = TxtCreditAmount.Text.Trim();
                }

                insert.ENDT = "";
                //insert.INS_USERID = "";
                //insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_DATE = "";
                insert.RW_CODE = null;
                insert.FIGURE_FLAG = "";
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
                insert.TRN_TYPE = "";
                insert.TRNDT = "";
                insert.BRANCH_CODE = HfBranchCode.Value.Trim();
                insert.CHK_FLAG = DdlApproval.SelectedValue.Trim().ToUpper();
                if (DdlApproval.SelectedValue.Trim() == "Y")
                {
                    insert.CHK_DATE = Convert.ToDateTime(TxtApprovalDate.Text.Trim()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.CHK_DATE = "";
                }

                if (DdlApproval.SelectedValue.Trim() == "Y")
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

                insert.BCODE = null;
                insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToString();
                insert.INV_REASON = HfGstResonCode.Value.Trim().ToString();

                #endregion


                #region INSERT INTO PAY_REC_T DETAILS

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);
                int SRNO = 1;

                if (TxtCreditAccountName.Text != string.Empty && TxtDebitAccountName.Text != null)
                {


                    XmlElement HandleDetail2 = XDoc1.CreateElement("PAY_REC_Details");

                    HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                    HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                    HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                    HandleDetail2.SetAttribute("SR", SRNO.ToString());

                    if (HfTranType.Value.ToString() == "A")
                    {
                        HandleDetail2.SetAttribute("DRACODE", HfDebitACODE.Value.Trim());
                        HandleDetail2.SetAttribute("CRACODE", HfCreditACODE.Value.Trim());
                        HandleDetail2.SetAttribute("NARRN", (TxtDebitNarration.Text.Trim()));
                        HandleDetail2.SetAttribute("AMT", (TxtDebitAmount.Text.Trim()));
                        HandleDetail2.SetAttribute("SIGN", (DdlDebitSign.SelectedValue.Trim()));
                        HandleDetail2.SetAttribute("TRAN_TYPE", ("A"));
                    }
                    else if (HfTranType.Value.ToString() == "B")
                    {
                        HandleDetail2.SetAttribute("DRACODE", (HfDebitACODE.Value.Trim()));
                        HandleDetail2.SetAttribute("CRACODE", (HfCreditACODE.Value.Trim()));
                        HandleDetail2.SetAttribute("NARRN", (TxtDebitNarration.Text.Trim()));
                        HandleDetail2.SetAttribute("AMT", (TxtDebitAmount.Text.Trim()));
                        HandleDetail2.SetAttribute("SIGN", (DdlDebitSign.SelectedValue.Trim()));
                        HandleDetail2.SetAttribute("TRAN_TYPE", ("B"));
                    }




                    root1.AppendChild(HandleDetail2);
                    SRNO++;


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
                        //HiddenField HfTranDateGrid = row.FindControl("HfTranDate") as HiddenField;
                        //HiddenField HfTranNoGrid = row.FindControl("HfTranNo") as HiddenField;
                        //HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                        HiddenField HfSubSrNo = row.FindControl("HfSubSrNo") as HiddenField;
                        HiddenField HfInvACODE = row.FindControl("HfInvACODE") as HiddenField;
                        HiddenField HfXXX_Date = row.FindControl("HfXXX_Date") as HiddenField;
                        HiddenField HfXXX_No = row.FindControl("HfXXX_No") as HiddenField;
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
                        TextBox TxtTaxableAmount = row.FindControl("TxtTaxableAmount") as TextBox;
                        TextBox TxtGSTRate = row.FindControl("TxtGSTRate") as TextBox;
                        TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                        TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                        TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;



                        if (HfInvACODE.Value != string.Empty && HfInvACODE.Value != null)
                        {


                            XmlElement HandleDetail3 = XDoc2.CreateElement("PAY_REC_INVDetails");

                            HandleDetail3.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                            HandleDetail3.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail3.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
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
                            HandleDetail3.SetAttribute("TRAN_TYPE", (HfTranType.Value.ToString()));

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

                            if (TxtGSTRate.Text != string.Empty)
                            {
                                HandleDetail3.SetAttribute("GST_RATE", (TxtGSTRate.Text.Trim().ToString()));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("GST_RATE", ("0"));
                            }

                            if (HfGST_AMT.Value != string.Empty)
                            {
                                HandleDetail3.SetAttribute("GST_AMT", (HfGST_AMT.Value.Trim().ToString()));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("GST_AMT", ("0"));
                            }

                            if (HfCGST_RATE.Value != string.Empty)
                            {
                                HandleDetail3.SetAttribute("CGST_RATE", (HfCGST_RATE.Value.Trim()));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("CGST_RATE", ("0"));
                            }

                            if (TxtCGSTAmount.Text != string.Empty)
                            {
                                HandleDetail3.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text.Trim().ToString()));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("CGST_AMT", ("0"));
                            }


                            if (HfSGST_RATE.Value != string.Empty)
                            {
                                HandleDetail3.SetAttribute("SGST_RATE", (HfSGST_RATE.Value.Trim()));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("SGST_RATE", ("0"));
                            }


                            if (TxtSGSTAmount.Text != string.Empty)
                            {
                                HandleDetail3.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text.Trim().ToString()));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("SGST_AMT", ("0"));
                            }


                            if (HfIGST_RATE.Value != string.Empty)
                            {
                                HandleDetail3.SetAttribute("IGST_RATE", (HfIGST_RATE.Value.Trim()));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("IGST_RATE", ("0"));
                            }

                            if (TxtIGSTAmount.Text != string.Empty)
                            {
                                HandleDetail3.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text.Trim().ToString()));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("IGST_AMT", ("0"));
                            }

                            if (TxtTaxableAmount.Text != string.Empty)
                            {
                                HandleDetail3.SetAttribute("ACT_AMT", (TxtTaxableAmount.Text.Trim().ToString()));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("ACT_AMT", ("0"));
                            }


                            root2.AppendChild(HandleDetail3);
                            //    SR_NO++;

                        }
                    }
                }

                #endregion


                string str = PAY_REC_MLogicLayer.UpdatePAY_REC_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml));

                if (str.Contains("successfully"))
                {

                    lblmsg.Text = "CREDIT / DEBIT NOTE UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillPAY_REC_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "CREDIT / DEBIT NOTE ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : CREDIT / DEBIT NOTE NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }


                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlCreditSign_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DdlDebitSign_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TxtCreditAccountName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtAccountName = new DataTable();


                DtAccountName = ACCOUNTS_MASLogicLayer.GetAllACCOUNTDetialsByComapnyAndBranch(compcode, Branchcode);

                if (HfTranType.Value.ToString() == "A")
                {

                    if (TxtCreditAccountName.Text != null && TxtCreditAccountName.Text.ToString() != string.Empty)
                    {

                        DataView Dv = new DataView(DtAccountName);
                        Dv.RowFilter = "ANAME='" + TxtCreditAccountName.Text.Trim() + "'";
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            HfCreditACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                            DdlPartyType.SelectedValue = DtView.Rows[0]["PARTY_TYPE"].ToString();

                        }

                    }
                    else
                    {
                        TxtCreditAccountName.Text = string.Empty;
                        HfCreditACODE.Value = string.Empty;
                    }
                }

                else if (HfTranType.Value.ToString() == "B")
                {
                    if (TxtCreditAccountName.Text != null && TxtCreditAccountName.Text.ToString() != string.Empty)
                    {

                        DataView Dv = new DataView(DtAccountName);
                        Dv.RowFilter = "ANAME='" + TxtCreditAccountName.Text.Trim() + "'";
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            HfDebitACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                            DdlPartyType.SelectedValue = DtView.Rows[0]["PARTY_TYPE"].ToString();

                        }

                    }
                    else
                    {

                        HfDebitACODE.Value = string.Empty;
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtDebitAccountName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtAccountName = new DataTable();


                DtAccountName = ACCOUNTS_MASLogicLayer.GetAllACCOUNTDetialsByComapnyAndBranch(compcode, Branchcode);

                if (HfTranType.Value.ToString() == "B")
                {
                    if (TxtDebitAccountName.Text != null && TxtDebitAccountName.Text.ToString() != string.Empty)
                    {

                        DataView Dv = new DataView(DtAccountName);
                        Dv.RowFilter = "ANAME='" + TxtDebitAccountName.Text.Trim() + "'";
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            HfCreditACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                            DdlPartyType.SelectedValue = DtView.Rows[0]["PARTY_TYPE"].ToString();

                        }

                    }
                    else
                    {

                        HfDebitACODE.Value = null;
                    }
                }

                else if (HfTranType.Value.ToString() == "A")
                {
                    if (TxtDebitAccountName.Text != null && TxtDebitAccountName.Text.ToString() != string.Empty)
                    {

                        DataView Dv = new DataView(DtAccountName);
                        Dv.RowFilter = "ANAME='" + TxtDebitAccountName.Text.Trim() + "'";
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            HfDebitACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                            DdlPartyType.SelectedValue = DtView.Rows[0]["PARTY_TYPE"].ToString();

                        }
                      
                    }
                    else
                    {

                        HfDebitACODE.Value = string.Empty;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtVoucherDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Voucher_NO = PAY_REC_MLogicLayer.GetVoucherNumber_PAY_REC_MASCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtVoucherDate.Text.Trim()).ToString("yyyy-MM-dd"), HfTranType.Value.ToString());
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
                    Label lblTaxableSumTotalAmount = (Label)e.Row.FindControl("lblTaxableSumTotalAmount");
                    Label lblCGSTSumTotalAmount = (Label)e.Row.FindControl("lblCGSTSumTotalAmount");
                    Label lblSGSTSumTotalAmount = (Label)e.Row.FindControl("lblSGSTSumTotalAmount");
                    Label lblIGSTSumTotalAmount = (Label)e.Row.FindControl("lblIGSTSumTotalAmount");


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

                    double SumTotalTaxableAmt = TotalTaxableAmount();
                    lblTaxableSumTotalAmount.Text = SumTotalTaxableAmt.ToString();

                    double SumTotalCGSTAmt = TotalCGSTAmount();
                    lblCGSTSumTotalAmount.Text = SumTotalCGSTAmt.ToString();

                    double SumTotalSGSTAmt = TotalSGSTAmount();
                    lblSGSTSumTotalAmount.Text = SumTotalSGSTAmt.ToString();

                    double SumTotalIGSTAmt = TotalIGSTAmount();
                    lblIGSTSumTotalAmount.Text = SumTotalIGSTAmt.ToString();
                }
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
                Label lblTaxableSumTotalAmount = (Label)(GvPayReceiveInvoice.FooterRow.FindControl("lblTaxableSumTotalAmount"));
                Label lblCGSTSumTotalAmount = (Label)(GvPayReceiveInvoice.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                Label lblSGSTSumTotalAmount = (Label)(GvPayReceiveInvoice.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                Label lblIGSTSumTotalAmount = (Label)(GvPayReceiveInvoice.FooterRow.FindControl("lblIGSTSumTotalAmount"));


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

                double SumTotalTaxableAmt = TotalTaxableAmount();
                lblTaxableSumTotalAmount.Text = SumTotalTaxableAmt.ToString();

                double SumTotalCGSTAmt = TotalCGSTAmount();
                lblCGSTSumTotalAmount.Text = SumTotalCGSTAmt.ToString();

                double SumTotalSGSTAmt = TotalSGSTAmount();
                lblSGSTSumTotalAmount.Text = SumTotalSGSTAmt.ToString();

                double SumTotalIGSTAmt = TotalIGSTAmount();
                lblIGSTSumTotalAmount.Text = SumTotalIGSTAmt.ToString();


                decimal currbalAmount = 0;
                if (ChkSel.Checked == true)
                {
                    decimal Amount_TD = 0;
                    if (TxtCreditAmount.Text.Trim() != string.Empty)
                    {
                        Amount_TD = Convert.ToDecimal(TxtCreditAmount.Text.Trim());
                        if (Amount_TD > Convert.ToDecimal(TxtBillBalanceAmount.Text.Trim()))
                        {
                            TxtCurrentPaidAmount.Text = TxtBillBalanceAmount.Text.Trim();
                        }
                        else
                        {
                            TxtCurrentPaidAmount.Text = TxtCreditAmount.Text;
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


                        //if (Amount_T.Text != string.Empty && Amount_T.Text != null)
                        //{
                        //    TxtOnAccountAmount.Text = Convert.ToString(Convert.ToDouble(Amount_T.Text) - Convert.ToDouble(SumTotalCurrentPaidAmt));
                        //}

                        //if (Convert.ToInt32(TxtOnAccountAmount.Text) == 0)
                        //{
                        //    DdlOnAccount.SelectedValue = "N";
                        //}
                        //else
                        //{
                        //    DdlOnAccount.SelectedValue = "Y";
                        //}

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

                    double SumTotalTaxableAmt1 = TotalTaxableAmount();
                    lblTaxableSumTotalAmount.Text = SumTotalTaxableAmt1.ToString();

                    double SumTotalCGSTAmt1 = TotalCGSTAmount();
                    lblCGSTSumTotalAmount.Text = SumTotalCGSTAmt1.ToString();

                    double SumTotalSGSTAmt1 = TotalSGSTAmount();
                    lblSGSTSumTotalAmount.Text = SumTotalSGSTAmt1.ToString();

                    double SumTotalIGSTAmt1 = TotalIGSTAmount();
                    lblIGSTSumTotalAmount.Text = SumTotalIGSTAmt1.ToString();


                    //if (Amount_T.Text != string.Empty && Amount_T.Text != null)
                    //{
                    //    TxtOnAccountAmount.Text = Convert.ToString(Convert.ToDouble(Amount_T.Text) - Convert.ToDouble(SumTotalCurrentPaidAmt));
                    //}


                    //if (Convert.ToInt32(TxtOnAccountAmount.Text) == 0)
                    //{
                    //    DdlOnAccount.SelectedValue = "N";
                    //}
                    //else
                    //{
                    //    DdlOnAccount.SelectedValue = "Y";
                    //}


                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnFetchInvoice_Click(object sender, EventArgs e)
        {
            string Credit = "";
            string Debit = "";


            if (HfTranType.Value.ToString() == "A")
            {
                Credit = HfCreditACODE.Value;
                Debit = HfDebitACODE.Value;

            }
            else if (HfTranType.Value.ToString() == "B")
            {
                Credit = HfDebitACODE.Value;
                Debit = HfCreditACODE.Value;

            }

            DataTable Dt = new DataTable();

            Dt = PAY_REC_MLogicLayer.GetPaidRecordFor_CreditDebit_Note(Convert.ToInt32(Session["BRANCH_CODE"].ToString()), Convert.ToInt32(Credit.Trim()), Convert.ToInt32(Debit.Trim()), Convert.ToInt32(Session["COMP_CODE"].ToString()), Convert.ToDateTime(TxtVoucherDate.Text.Trim()), HfTranType.Value.Trim(), HfTranType.Value.Trim(), Convert.ToInt32(Debit), Convert.ToInt32(Credit), 0, Convert.ToDateTime((Session["FIN_YEAR"].ToString())), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()));
            if (Dt.Rows.Count > 0)
            {

                GvPayReceiveInvoice.DataSource = Dt;
                GvPayReceiveInvoice.DataBind();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected Party Outstanding Not Found...!!');", true);
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
                        HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                        HiddenField HfSubSrNo = row.FindControl("HfSubSrNo") as HiddenField;
                        HiddenField HfInvACODE = row.FindControl("HfInvACODE") as HiddenField;
                        HiddenField HfXXX_Type = row.FindControl("HfXXX_Type") as HiddenField;
                        HiddenField HfXXX_No = row.FindControl("HfXXX_No") as HiddenField;
                        HiddenField HfXXX_Date = row.FindControl("HfXXX_Date") as HiddenField;
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
                        TextBox TxtTaxableAmount = row.FindControl("TxtTaxableAmount") as TextBox;
                        TextBox TxtGSTRate = row.FindControl("TxtGSTRate") as TextBox;
                        TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                        TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                        TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;

                        if (ChkSelectBill.Checked==true)
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
                            dr["GST_RATE"] = TxtGSTRate.Text.Trim().ToString();
                            dr["GST_AMT"] = HfGST_AMT.Value.Trim();
                            dr["CGST_RATE"] = HfCGST_RATE.Value.Trim();
                            dr["CGST_AMT"] = TxtCGSTAmount.Text.Trim().ToString();
                            dr["SGST_RATE"] = HfSGST_RATE.Value.Trim();
                            dr["SGST_AMT"] = TxtSGSTAmount.Text.Trim().ToString();
                            dr["IGST_RATE"] = HfIGST_RATE.Value.Trim();
                            dr["IGST_AMT"] = TxtIGSTAmount.Text.Trim().ToString();
                            dr["ACT_AMT"] = TxtTaxableAmount.Text.Trim().ToString();

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

        protected void TxtGSTRate_TextChanged(object sender, EventArgs e)
            {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;


                TextBox TxtTaxableAmountString = (TextBox)row.Cells[13].FindControl("TxtTaxableAmount");
                HiddenField HfCGST_RATE = (HiddenField)row.Cells[0].FindControl("HfCGST_RATE");
                HiddenField HfGST_AMT = (HiddenField)row.Cells[0].FindControl("HfGST_AMT");
                HiddenField HfSGST_RATE = (HiddenField)row.Cells[0].FindControl("HfSGST_RATE"); 
                 HiddenField HfIGST_RATE = (HiddenField)row.Cells[0].FindControl("HfIGST_RATE");


                TextBox TxtCGSTAmount = (TextBox)row.Cells[15].FindControl("TxtCGSTAmount");
                TextBox TxtSGSTAmount = (TextBox)row.Cells[16].FindControl("TxtSGSTAmount");
                TextBox TxtIGSTAmount = (TextBox)row.Cells[17].FindControl("TxtIGSTAmount");



                // Label lblSumTotalREC_QTY = (Label)(GvDCDetailsExStock.FooterRow.FindControl("lblSumTotalEXtraREC_QTY"));


                if (txt.Text.Trim() != string.Empty && TxtTaxableAmountString.Text.Trim() != string.Empty)
                {

                    double TotalGST = ((Convert.ToDouble(TxtTaxableAmountString.Text.Trim()) * Convert.ToDouble(txt.Text.Trim())) / 100);
                    double GST_RATE = Convert.ToDouble(txt.Text);
                    double CGST_RATE = 0;
                    double SGST_RATE = 0;
                    double IGST_RATE = 0;
                    double CGST_AMOUNT = 0;
                    double SGST_AMOUNT = 0;

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                       

                        if(Convert.ToDouble(txt.Text)>0)
                        {
                            CGST_RATE = GST_RATE / 2;
                            SGST_RATE = GST_RATE / 2;
                          

                            HfCGST_RATE.Value = CGST_RATE.ToString();
                            HfSGST_RATE.Value = SGST_RATE.ToString();
                            HfIGST_RATE.Value = null;

                        }


                        if (TotalGST > 0)
                        {
                            CGST_AMOUNT = TotalGST / 2;
                            SGST_AMOUNT = TotalGST / 2;
                        }

                        TxtCGSTAmount.Text = CGST_AMOUNT.ToString();//((Convert.ToDouble(TxtTaxableAmountString.Text.Trim()) * Convert.ToDouble(txt.Text.Trim())) / 100).ToString();
                        TxtSGSTAmount.Text = SGST_AMOUNT.ToString();//((Convert.ToDouble(TxtTaxableAmountString.Text.Trim()) * Convert.ToDouble(txt.Text.Trim())) / 100).ToString();
                        HfGST_AMT.Value = (Convert.ToDouble(TxtCGSTAmount.Text.Trim()) + Convert.ToDouble(TxtSGSTAmount.Text.Trim())).ToString();
                        
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {

                        if (Convert.ToDouble(txt.Text) > 0)
                        {
                            IGST_RATE = GST_RATE;
                            HfIGST_RATE.Value = IGST_RATE.ToString();
                            HfCGST_RATE.Value = null;
                            HfSGST_RATE.Value = null;
                        }

                       TxtIGSTAmount.Text = ((Convert.ToDouble(TxtTaxableAmountString.Text.Trim()) * Convert.ToDouble(txt.Text.Trim())) / 100).ToString();
                        HfGST_AMT.Value = TxtIGSTAmount.Text;
                       
                    }

                    //double lblTotRecQty = TotalExtraReceiveQty();
                    //lblSumTotalREC_QTY.Text = lblTotRecQty.ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtTaxableAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;


                TextBox TxtGSTRateString = (TextBox)row.Cells[14].FindControl("TxtGSTRate");
                HiddenField HfCGST_RATE = (HiddenField)row.Cells[0].FindControl("HfCGST_RATE");
                HiddenField HfGST_AMT = (HiddenField)row.Cells[0].FindControl("HfGST_AMT");
                HiddenField HfSGST_RATE = (HiddenField)row.Cells[0].FindControl("HfSGST_RATE");
                HiddenField HfIGST_RATE = (HiddenField)row.Cells[0].FindControl("HfIGST_RATE");


                TextBox TxtCGSTAmount = (TextBox)row.Cells[15].FindControl("TxtCGSTAmount");
                TextBox TxtSGSTAmount = (TextBox)row.Cells[16].FindControl("TxtSGSTAmount");
                TextBox TxtIGSTAmount = (TextBox)row.Cells[17].FindControl("TxtIGSTAmount");



                // Label lblSumTotalREC_QTY = (Label)(GvDCDetailsExStock.FooterRow.FindControl("lblSumTotalEXtraREC_QTY"));


                if (txt.Text.Trim() != string.Empty && TxtGSTRateString.Text.Trim() != string.Empty)
                {
                    double TotalGST = ((Convert.ToDouble(TxtGSTRateString.Text.Trim()) * Convert.ToDouble(txt.Text.Trim())) / 100);
                    double GST_RATE = Convert.ToDouble(txt.Text);
                    double CGST_RATE = 0;
                    double SGST_RATE = 0;
                    double IGST_RATE = 0;
                    double CGST_AMOUNT = 0;
                    double SGST_AMOUNT = 0;

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                     

                        if (Convert.ToDouble(txt.Text) > 0)
                        {
                            CGST_RATE = GST_RATE / 2;
                            SGST_RATE = GST_RATE / 2;
                            IGST_RATE = GST_RATE;

                            HfCGST_RATE.Value = CGST_RATE.ToString();
                            HfSGST_RATE.Value = SGST_RATE.ToString();
                            HfIGST_RATE.Value = null;

                        }


                      

                        if (TotalGST > 0)
                        {
                            CGST_AMOUNT = TotalGST / 2;
                            SGST_AMOUNT = TotalGST / 2;
                        }

                        TxtCGSTAmount.Text = CGST_AMOUNT.ToString();//((Convert.ToDouble(TxtTaxableAmountString.Text.Trim()) * Convert.ToDouble(txt.Text.Trim())) / 100).ToString();
                        TxtSGSTAmount.Text = SGST_AMOUNT.ToString();//((Convert.ToDouble(TxtTaxableAmountString.Text.Trim()) * Convert.ToDouble(txt.Text.Trim())) / 100).ToString();
                        HfGST_AMT.Value = (Convert.ToDouble(TxtCGSTAmount.Text.Trim()) + Convert.ToDouble(TxtSGSTAmount.Text.Trim())).ToString();

                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        if (Convert.ToDouble(txt.Text) > 0)
                        {
                            IGST_RATE = GST_RATE;
                            HfIGST_RATE.Value = IGST_RATE.ToString();
                            HfCGST_RATE.Value = null;
                            HfSGST_RATE.Value = null;
                        }

                        TxtIGSTAmount.Text = ((Convert.ToDouble(TxtGSTRateString.Text.Trim()) * Convert.ToDouble(txt.Text.Trim())) / 100).ToString();
                        HfGST_AMT.Value = TxtIGSTAmount.Text;

                    }

                    //double lblTotRecQty = TotalExtraReceiveQty();
                    //lblSumTotalREC_QTY.Text = lblTotRecQty.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtCurrentPaidAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                if(txt.Text==string.Empty)
                {
                    txt.Text = "0";
                }

                TextBox TxtBillBalanceAmount = (TextBox)row.Cells[8].FindControl("TxtBillBalanceAmount");
                TextBox TxtCurrentBalAmount = (TextBox)row.Cells[12].FindControl("TxtCurrentBalAmount");

                if(Convert.ToDouble(TxtBillBalanceAmount.Text)>0)
                {
                    TxtCurrentBalAmount.Text = (Convert.ToDouble(TxtBillBalanceAmount.Text.Trim()) - Convert.ToDouble(txt.Text.Trim())).ToString();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillCreditAccountNameOnUpdate(string Id)//A
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Brabch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTWiseComapnyAndBranchForInvoice(Comp_Code, Brabch_Code);

                if (HfTranType.Value.ToString() == "A")
                {

                    if (HfCreditACODE.Value.ToString() != "0" && HfCreditACODE.Value != null && HfCreditACODE.Value.ToString() != string.Empty)
                    {
                        DataView Dv = new DataView(Dt);
                        Dv.RowFilter = "ACODE=" + Id;
                        DataTable DtView = Dv.ToTable();

                        TxtCreditAccountName.Text = DtView.Rows[0]["ANAME"].ToString();
                        HfCreditACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                    }
                    else
                    {
                        TxtCreditAccountName.Text = string.Empty;
                        HfCreditACODE.Value = string.Empty;
                    }

                    lblCreditAccount.Text = "Credit A/ C";
                    lblCreditNarration.Text = "Credit Narration";
                    lblDebitAccounts.Text = "Debit A/ C";
                    lblDebitNarrartion.Text = "Debit Narration";
                    DdlCreditSign.SelectedValue = "CR";
                    DdlDebitSign.SelectedValue = "DR";
                }
                else if (HfTranType.Value.ToString() == "B")
                {
                    if (HfCreditACODE.Value.ToString() != "0" && HfCreditACODE.Value != null && HfCreditACODE.Value.ToString() != string.Empty)
                    {
                        DataView Dv = new DataView(Dt);
                        Dv.RowFilter = "ACODE=" + Id;
                        DataTable DtView = Dv.ToTable();

                        TxtDebitAccountName.Text = DtView.Rows[0]["ANAME"].ToString();
                        //HfDebitACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                    }
                    else
                    {
                        TxtDebitAccountName.Text = string.Empty;
                        HfDebitACODE.Value = string.Empty;
                    }

                    lblCreditAccount.Text = "Debit A/ C";
                    lblCreditNarration.Text = "Debit Narration";
                    lblDebitAccounts.Text = "Credit A/ C";
                    lblDebitNarrartion.Text = "Credit Narration";
                    DdlCreditSign.SelectedValue = "DR";
                    DdlDebitSign.SelectedValue = "CR";
                }


            

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDebitAccountNameOnUpdate(string Id)//B
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Brabch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTWiseComapnyAndBranchForInvoice(Comp_Code, Brabch_Code);

                if (HfTranType.Value.ToString() == "B")
                {

                    if (HfDebitACODE.Value.ToString() != "0" && HfDebitACODE.Value != null && HfDebitACODE.Value.ToString() != string.Empty)
                    {
                        DataView Dv = new DataView(Dt);
                        Dv.RowFilter = "ACODE=" + Id;
                        DataTable DtView = Dv.ToTable();

                        TxtCreditAccountName.Text = DtView.Rows[0]["ANAME"].ToString();
                        //HfCreditACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                    }
                    else
                    {
                        TxtCreditAccountName.Text = string.Empty;
                        HfCreditACODE.Value = string.Empty;
                    }

                    lblCreditAccount.Text = "Debit A/ C";
                    lblCreditNarration.Text = "Debit Narration";
                    lblDebitAccounts.Text = "Credit A/ C";
                    lblDebitNarrartion.Text = "Credit Narration";
                    DdlCreditSign.SelectedValue = "DR";
                    DdlDebitSign.SelectedValue = "CR";

                }
                else if (HfTranType.Value.ToString() == "A")
                {
                    if (HfDebitACODE.Value.ToString() != "0" && HfDebitACODE.Value != null && HfDebitACODE.Value.ToString() != string.Empty)
                    {
                        DataView Dv = new DataView(Dt);
                        Dv.RowFilter = "ACODE=" + Id;
                        DataTable DtView = Dv.ToTable();

                        TxtDebitAccountName.Text = DtView.Rows[0]["ANAME"].ToString();
                        HfDebitACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                    }
                    else
                    {
                        TxtDebitAccountName.Text = string.Empty;
                        HfDebitACODE.Value = string.Empty;
                    }

                    lblCreditAccount.Text = "Credit A/ C";
                    lblCreditNarration.Text = "Credit Narration";
                    lblDebitAccounts.Text = "Debit A/ C";
                    lblDebitNarrartion.Text = "Debit Narration";
                    DdlCreditSign.SelectedValue = "CR";
                    DdlDebitSign.SelectedValue = "DR";
                }


            }
            catch (Exception)
            {

                throw;
            }
        }


        public void GetGstReasonOnUpdate(string inv_code)
        {

            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select name from gst_reasonmas  where code = '" + inv_code.Trim().ToString() + "'", con);
         //   System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select name from gst_reasonmas  where code = inv_code", con);
            string x = cmd.ExecuteScalar().ToString();

            if (x != string.Empty)
            {
                TxtGSTReason.Text = x;
                HfGstResonCode.Value = inv_code;
            }
            else
            {
                TxtGSTReason.Text = string.Empty;
                HfGstResonCode.Value = string.Empty;
            }

        }


        protected void GvCreditDebitNoteMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtVoucherNo.Text = dt.Rows[0]["VOU_NO"].ToString();
                            TxtVoucherDate.Text = Convert.ToDateTime(dt.Rows[0]["VOU_DATE"].ToString()).ToString("dd-MM-yyyy");

                            if (HfTranType.Value.ToString() == "A")
                            {
                                HfCreditACODE.Value = dt.Rows[0]["ACODE"].ToString();
                                FillCreditAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                                TxtCreditAmount.Text = dt.Rows[0]["AMT"].ToString();
                                TxtCreditNarration.Text = dt.Rows[0]["NARRN"].ToString();
                                DdlCreditSign.SelectedValue = dt.Rows[0]["SIGN"].ToString();
                            }
                            else if (HfTranType.Value.ToString() == "B")
                            {
                                HfDebitACODE.Value = dt.Rows[0]["ACODE"].ToString();
                                FillDebitAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                                TxtDebitAmount.Text = dt.Rows[0]["AMT"].ToString();
                                TxtCreditNarration.Text = dt.Rows[0]["NARRN"].ToString();
                                DdlCreditSign.SelectedValue = dt.Rows[0]["SIGN"].ToString();

                            }

                            DdlApproval.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtApprovalDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            TxtApprovalBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            DdlConfirm.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            TxtGSTReason.Text = dt.Rows[0]["INV_REASON"].ToString();
                            GetGstReasonOnUpdate(dt.Rows[0]["INV_REASON"].ToString());

                        }

                        if (DtDetails.Rows.Count > 0)
                        {

                            if (HfTranType.Value.ToString() == "A")
                            {
                                HfCreditACODE.Value = DtDetails.Rows[0]["CRACODE"].ToString();
                                HfDebitACODE.Value = DtDetails.Rows[0]["DRACODE"].ToString();
                                FillDebitAccountNameOnUpdate(DtDetails.Rows[0]["DRACODE"].ToString());
                                TxtDebitAmount.Text = DtDetails.Rows[0]["AMT"].ToString();
                                TxtDebitNarration.Text = DtDetails.Rows[0]["NARRN"].ToString();
                                DdlDebitSign.SelectedValue = DtDetails.Rows[0]["SIGN"].ToString();
                            }
                            else if (HfTranType.Value.ToString() == "B")
                            {
                                HfDebitACODE.Value = DtDetails.Rows[0]["DRACODE"].ToString();
                                HfCreditACODE.Value = DtDetails.Rows[0]["CRACODE"].ToString();
                                FillCreditAccountNameOnUpdate(dt.Rows[0]["CRACODE"].ToString());
                                TxtCreditAmount.Text = dt.Rows[0]["AMT"].ToString();
                                TxtCreditNarration.Text = DtDetails.Rows[0]["NARRN"].ToString();
                                DdlCreditSign.SelectedValue = DtDetails.Rows[0]["SIGN"].ToString();

                            }
                        }


                        Session["TRAN_NO"] = e.CommandArgument.ToString();
                        Session["TRAN_DATE"] = HfTranDate.Value;
                        Session["TRAN_TYPE"] = HfTranType.Value;

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
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtVoucherNo.Text = dt.Rows[0]["VOU_NO"].ToString();
                            TxtVoucherDate.Text = Convert.ToDateTime(dt.Rows[0]["VOU_DATE"].ToString()).ToString("dd-MM-yyyy");

                            if (HfTranType.Value.ToString() == "A")
                            {
                                //Credit
                             //   HfCreditACODE.Value = dt.Rows[0]["ACODE"].ToString();
                             //   FillCreditAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                                TxtCreditAmount.Text = dt.Rows[0]["AMT"].ToString();
                                TxtCreditNarration.Text = dt.Rows[0]["NARRN"].ToString();
                                DdlCreditSign.SelectedValue = dt.Rows[0]["SIGN"].ToString();
                            }
                            else if (HfTranType.Value.ToString() == "B")
                            {
                                //Debit
                             //   HfCreditACODE.Value = dt.Rows[0]["ACODE"].ToString();//Changed 
                            //    FillDebitAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                                TxtCreditAmount.Text = dt.Rows[0]["AMT"].ToString();
                                TxtCreditNarration.Text = dt.Rows[0]["NARRN"].ToString();
                                DdlCreditSign.SelectedValue = dt.Rows[0]["SIGN"].ToString();

                            }

                            DdlApproval.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtApprovalDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            TxtApprovalBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            DdlConfirm.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            TxtGSTReason.Text = dt.Rows[0]["INV_REASON"].ToString();
                            GetGstReasonOnUpdate(dt.Rows[0]["INV_REASON"].ToString());

                        }


                        Session["TRAN_NO"] = e.CommandArgument.ToString();
                        Session["TRAN_DATE"] = HfTranDate.Value;
                        Session["TRAN_TYPE"] = HfTranType.Value;

                        if (DtDetails.Rows.Count > 0)
                        {

                            if (HfTranType.Value.ToString() == "A")
                            {
                                HfCreditACODE.Value = DtDetails.Rows[0]["CRACODE"].ToString();
                                FillCreditAccountNameOnUpdate(DtDetails.Rows[0]["CRACODE"].ToString());
                                HfDebitACODE.Value = DtDetails.Rows[0]["DRACODE"].ToString();
                                FillDebitAccountNameOnUpdate(DtDetails.Rows[0]["DRACODE"].ToString());
                                TxtDebitAmount.Text = DtDetails.Rows[0]["AMT"].ToString();
                                TxtDebitNarration.Text = DtDetails.Rows[0]["NARRN"].ToString();
                                DdlDebitSign.SelectedValue = DtDetails.Rows[0]["SIGN"].ToString();
                            }
                            else if (HfTranType.Value.ToString() == "B")
                            {
                                HfDebitACODE.Value = DtDetails.Rows[0]["DRACODE"].ToString();                                
                                FillDebitAccountNameOnUpdate(DtDetails.Rows[0]["DRACODE"].ToString());
                                HfCreditACODE.Value = DtDetails.Rows[0]["CRACODE"].ToString();
                                FillCreditAccountNameOnUpdate(DtDetails.Rows[0]["CRACODE"].ToString());//changed
                                TxtDebitAmount.Text = DtDetails.Rows[0]["AMT"].ToString();
                                TxtDebitNarration.Text = DtDetails.Rows[0]["NARRN"].ToString();
                                DdlDebitSign.SelectedValue = DtDetails.Rows[0]["SIGN"].ToString();

                            }
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
                                drm["GST_RATE"] = DtInvoiceDetails.Rows[m]["GST_RATE"].ToString();
                                drm["GST_AMT"] = DtInvoiceDetails.Rows[m]["GST_AMT"].ToString();
                                drm["CGST_RATE"] = DtInvoiceDetails.Rows[m]["CGST_AMT"].ToString();
                                drm["CGST_AMT"] = DtInvoiceDetails.Rows[m]["CGST_AMT"].ToString();
                                drm["SGST_RATE"] = DtInvoiceDetails.Rows[m]["SGST_RATE"].ToString();
                                drm["SGST_AMT"] = DtInvoiceDetails.Rows[m]["SGST_AMT"].ToString();
                                drm["IGST_RATE"] = DtInvoiceDetails.Rows[m]["IGST_RATE"].ToString();
                                drm["IGST_AMT"] = DtInvoiceDetails.Rows[m]["IGST_AMT"].ToString();
                                drm["ACT_AMT"] = DtInvoiceDetails.Rows[m]["ACT_AMT"].ToString();
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
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtVoucherNo.Text = dt.Rows[0]["VOU_NO"].ToString();
                            TxtVoucherDate.Text = Convert.ToDateTime(dt.Rows[0]["VOU_DATE"].ToString()).ToString("dd-MM-yyyy");

                            if (HfTranType.Value.ToString() == "A")
                            {
                                HfCreditACODE.Value = dt.Rows[0]["ACODE"].ToString();
                                FillCreditAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                                TxtCreditAmount.Text = dt.Rows[0]["AMT"].ToString();
                                TxtCreditNarration.Text = dt.Rows[0]["NARRN"].ToString();
                                DdlCreditSign.SelectedValue = dt.Rows[0]["SIGN"].ToString();
                            }
                            else if (HfTranType.Value.ToString() == "B")
                            {
                                HfDebitACODE.Value = dt.Rows[0]["ACODE"].ToString();
                                FillDebitAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                                TxtDebitAmount.Text = dt.Rows[0]["AMT"].ToString();
                                TxtCreditNarration.Text = dt.Rows[0]["NARRN"].ToString();
                                DdlCreditSign.SelectedValue = dt.Rows[0]["SIGN"].ToString();

                            }

                            DdlApproval.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtApprovalDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            TxtApprovalBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            DdlConfirm.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            TxtGSTReason.Text = dt.Rows[0]["INV_REASON"].ToString();
                            GetGstReasonOnUpdate(dt.Rows[0]["INV_REASON"].ToString());

                        }


                        Session["TRAN_NO"] = e.CommandArgument.ToString();
                        Session["TRAN_DATE"] = HfTranDate.Value;
                        Session["TRAN_TYPE"] = HfTranType.Value;

                        if (DtDetails.Rows.Count > 0)
                        {

                            if (HfTranType.Value.ToString() == "A")
                            {
                                HfCreditACODE.Value = DtDetails.Rows[0]["CRACODE"].ToString();
                                HfDebitACODE.Value = DtDetails.Rows[0]["DRACODE"].ToString();
                                FillDebitAccountNameOnUpdate(DtDetails.Rows[0]["DRACODE"].ToString());
                                TxtDebitAmount.Text = DtDetails.Rows[0]["AMT"].ToString();
                                TxtDebitNarration.Text = DtDetails.Rows[0]["NARRN"].ToString();
                                DdlDebitSign.SelectedValue = DtDetails.Rows[0]["SIGN"].ToString();
                            }
                            else if (HfTranType.Value.ToString() == "B")
                            {
                                HfDebitACODE.Value = DtDetails.Rows[0]["DRACODE"].ToString();
                                HfCreditACODE.Value = DtDetails.Rows[0]["CRACODE"].ToString();
                                FillCreditAccountNameOnUpdate(dt.Rows[0]["CRACODE"].ToString());
                                TxtCreditAmount.Text = dt.Rows[0]["AMT"].ToString();
                                TxtCreditNarration.Text = DtDetails.Rows[0]["NARRN"].ToString();
                                DdlCreditSign.SelectedValue = DtDetails.Rows[0]["SIGN"].ToString();

                            }
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
            catch (Exception ex)
            {

                ex.ToString();
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

     


        protected void DdlApproval_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (DdlApproval.SelectedValue == "Y")
                {
                    TxtApprovalBy.Text = Session["USERNAME"].ToString();
                    TxtApprovalDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    TxtApprovalBy.Text = "";
                    TxtApprovalDate.Text = "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvCreditDebitNoteMaster_RowDataBound(object sender, GridViewRowEventArgs e)
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
            catch (Exception ex)
            {

                Response.AppendToLog(ex.ToString());
            }
        }

        protected void btnCreditDebitNotePrint_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewCreditDebitNotePrint.aspx', '_blank');", true);
        }
    }
}