using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class AccountStatementReport : System.Web.UI.Page
    {

        public static string compcode;
        public static string Branchcode;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERCODE"] != null &&
             Session["USERNAME"] != null &&
             Session["USERTYPE"] != null &&
             Session["COMP_CODE"] != null &&
             Session["COMP_NAME"] != null &&
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

                if (!Page.IsPostBack)
                {
                    if (!string.IsNullOrWhiteSpace(Request.QueryString["MENU_FLAG"]))
                    {
                        HfMenuFlag.Value = Request.QueryString["MENU_FLAG"];
                    }

                    if (HfMenuFlag.Value.ToString() == "CB")
                    {
                        HfGroupCode.Value = "-23";

                        hdForCashBookStateMent.Visible = true;
                        hdForBankBookStateMent.Visible = false;
                        hdForPaymentDetails.Visible = false;
                        hdForReceiptDetails.Visible = false;
                        hdForJounrnalVoucher.Visible = false;
                        hdDForCreditNote.Visible = false;
                        hdForDebitNote.Visible = false;
                        hdForBankReconiciliation.Visible = false;

                        trAccountGroupName.Visible = false;
                        trAccountName.Visible = true;
                        trPartyName.Visible = false;


                    }
                    else if (HfMenuFlag.Value.ToString() == "BB")
                    {
                        HfGroupCode.Value = "23";

                        hdForCashBookStateMent.Visible = false;
                        hdForBankBookStateMent.Visible = true;
                        hdForPaymentDetails.Visible = false;
                        hdForReceiptDetails.Visible = false;
                        hdForJounrnalVoucher.Visible = false;
                        hdDForCreditNote.Visible = false;
                        hdForDebitNote.Visible = false;
                        hdForBankReconiciliation.Visible = false;

                        trAccountGroupName.Visible = false;
                        trAccountName.Visible = true;
                        trPartyName.Visible = false;
                    }

                    else if (HfMenuFlag.Value.ToString() == "PD")
                    {
                        hdForCashBookStateMent.Visible = false;
                        hdForBankBookStateMent.Visible = false;
                        hdForPaymentDetails.Visible = true;
                        hdForReceiptDetails.Visible = false;
                        hdForJounrnalVoucher.Visible = false;
                        hdDForCreditNote.Visible = false;
                        hdForDebitNote.Visible = false;
                        hdForBankReconiciliation.Visible = false;

                        trAccountGroupName.Visible = true;
                        trAccountName.Visible = true;
                        trPartyName.Visible = true;
                    }
                    else if (HfMenuFlag.Value.ToString() == "RD")
                    {
                        hdForCashBookStateMent.Visible = false;
                        hdForBankBookStateMent.Visible = false;
                        hdForPaymentDetails.Visible = false;
                        hdForReceiptDetails.Visible = true;
                        hdForJounrnalVoucher.Visible = false;
                        hdDForCreditNote.Visible = false;
                        hdForDebitNote.Visible = false;
                        hdForBankReconiciliation.Visible = false;

                        trAccountGroupName.Visible = true;
                        trAccountName.Visible = true;
                        trPartyName.Visible = true;
                    }
                    else if (HfMenuFlag.Value.ToString() == "JV")
                    {
                        hdForCashBookStateMent.Visible = false;
                        hdForBankBookStateMent.Visible = false;
                        hdForPaymentDetails.Visible = false;
                        hdForReceiptDetails.Visible = false;
                        hdForJounrnalVoucher.Visible = true;
                        hdDForCreditNote.Visible = false;
                        hdForDebitNote.Visible = false;
                        hdForBankReconiciliation.Visible = false;

                        trAccountGroupName.Visible = true;
                        trAccountName.Visible = false;
                        trPartyName.Visible = true;
                    }
                    else if (HfMenuFlag.Value.ToString() == "CN")
                    {

                        hdForCashBookStateMent.Visible = false;
                        hdForBankBookStateMent.Visible = false;
                        hdForPaymentDetails.Visible = false;
                        hdForReceiptDetails.Visible = false;
                        hdForJounrnalVoucher.Visible = false;
                        hdDForCreditNote.Visible = true;
                        hdForDebitNote.Visible = false;
                        hdForBankReconiciliation.Visible = false;

                        trAccountGroupName.Visible = true;
                        trAccountName.Visible = false;
                        trPartyName.Visible = true;
                    }
                    else if (HfMenuFlag.Value.ToString() == "DN")
                    {
                        hdForCashBookStateMent.Visible = false;
                        hdForBankBookStateMent.Visible = false;
                        hdForPaymentDetails.Visible = false;
                        hdForReceiptDetails.Visible = false;
                        hdForJounrnalVoucher.Visible = false;
                        hdDForCreditNote.Visible = false;
                        hdForDebitNote.Visible = true;
                        hdForBankReconiciliation.Visible = false;

                        trAccountGroupName.Visible = true;
                        trAccountName.Visible = false;
                        trPartyName.Visible = true;
                    }
                    else if (HfMenuFlag.Value.ToString() == "BR")
                    {

                        HfGroupCode.Value = "23";

                        hdForCashBookStateMent.Visible = false;
                        hdForBankBookStateMent.Visible = false;
                        hdForPaymentDetails.Visible = false;
                        hdForReceiptDetails.Visible = false;
                        hdForJounrnalVoucher.Visible = false;
                        hdDForCreditNote.Visible = false;
                        hdForDebitNote.Visible = false;
                        hdForBankReconiciliation.Visible = true;

                        trAccountGroupName.Visible = false;
                        trAccountName.Visible = true;
                        trPartyName.Visible = false;

                    }


                    if (Session["USERTYPE"].ToString() == "A")
                    {
                        FillDdlBranchOnCompCode();
                    }
                    else
                    {
                        FillDdlBranchOnBranchCode();
                    }


                    TxtFromDate.Text = Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("dd-MM-yyyy");
                    TxtToDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                    FillTxtAccountName();
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }


        public void FillTxtAccountName()
        {
            try
            {
                DataTable DtFilter = new DataTable();

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

                    }

                    else
                    {
                        TxtAccountName.Text = string.Empty;
                        HfACODE.Value = string.Empty;                    
                    }

                }


            }
            catch (Exception)
            {

                throw;
            }
        }



        public void FillDdlBranchOnCompCode()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = BRANCH_MASLogicLayer.GetBranchNameCompanyWiseFor_DdlReport(compcode);
                DdlBranch.DataSource = Dt;
                DdlBranch.DataValueField = "BRANCH_CODE";
                DdlBranch.DataTextField = "BRANCH_NAME";
                DdlBranch.DataBind();

                DdlBranch.SelectedValue = Session["BRANCH_CODE"].ToString();
                DdlBranch.Enabled = true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlBranchOnBranchCode()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = BRANCH_MASLogicLayer.GetAllIDWiseBRANCH_MASDetials(Branchcode);
                DdlBranch.DataSource = Dt;
                DdlBranch.DataValueField = "BRANCH_CODE";
                DdlBranch.DataTextField = "BRANCH_NAME";
                DdlBranch.DataBind();
                DdlBranch.Enabled = false;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetBranchList()
        {
            #region CSV_FOR BRANCH

            string CSV_BRANCHCODE = "";

            if (DdlBranch.SelectedIndex == 0)
            {
                DataTable DtAllBranch = new DataTable();

                DtAllBranch = BRANCH_MASLogicLayer.GetBranchNameCompanyWiseFor_DdlReport(compcode);

                for (int i = 0; i < DtAllBranch.Rows.Count; i++)
                {
                    string Ids = DtAllBranch.Rows[i]["BRANCH_CODE"].ToString();


                    if (Ids != string.Empty && Ids != null && Ids != "0")
                    {
                        if (CSV_BRANCHCODE != string.Empty)
                        {
                            CSV_BRANCHCODE = CSV_BRANCHCODE + "," + Ids;//,2,3,4
                        }
                        else
                        {
                            CSV_BRANCHCODE = CSV_BRANCHCODE + Ids;
                        }
                    }

                }
            }
            else
            {
                CSV_BRANCHCODE = DdlBranch.SelectedValue.ToString();//Single Value
            }

            #endregion

            return CSV_BRANCHCODE;
        }


        //** Get Group Name From Group_Master ***//

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetAccountGroupName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from GROUP_MAS WHERE GROUP_NAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> Narration = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Narration.Add(dt.Rows[i][2].ToString());
            }
            return Narration;
        }


        protected void TxtAccountGroupName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtGroup = new DataTable();
                DtGroup = GROUP_MASLogicLayer.GetAllGROUP_MASDetials_DDL();
                if (TxtAccountGroupName.Text != string.Empty && TxtAccountGroupName.Text != null)
                {
                    DataView Dv = new DataView(DtGroup);
                    Dv.RowFilter = "GROUP_NAME='" + TxtAccountGroupName.Text.Trim().ToString() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfGroupCode.Value = DtView.Rows[0]["GROUP_CODE"].ToString();
                        Group_Code = Convert.ToInt32(DtView.Rows[0]["GROUP_CODE"].ToString());
                    }
                    else
                    {
                        Group_Code = 0;
                    }

                }
                else
                {
                    HfGroupCode.Value = null;
                    Group_Code = 0;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        static int Group_Code = 0;

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetAccountName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd;
            if (Group_Code == 0)
            {
                cmd = new SqlCommand("select * from ACCOUNTS where COMP_CODE=@COMP_CODE AND BRANCH_CODE=@BRANCH_CODE  AND ANAME like @name + '%'", con);
            }
            else
            {
                cmd = new SqlCommand("select * from ACCOUNTS where COMP_CODE=@COMP_CODE AND BRANCH_CODE=@BRANCH_CODE  AND ANAME like @name + '%'  and GROUP_CODE=@GROUP_CODE", con);
                cmd.Parameters.AddWithValue("@GROUP_CODE", Group_Code);
            }

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
                DataTable DtAccountName = new DataTable();
                DtAccountName = ACCOUNTS_MASLogicLayer.GetAllACCOUNTDetialsByComapnyAndBranch(compcode, Branchcode);
                if (TxtAccountName.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtAccountName);
                    Dv.RowFilter = "ANAME='" + TxtAccountName.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                    }

                }
                else
                {
                    HfACODE.Value = null;
                }
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
                DataTable DtAccountName = new DataTable();
                DtAccountName = ACCOUNTS_MASLogicLayer.GetAllACCOUNTDetialsByComapnyAndBranch(compcode, Branchcode);
                if (TxtPartyName.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtAccountName);
                    Dv.RowFilter = "ANAME='" + TxtPartyName.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfPartyACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                    }

                }
                else
                {
                    HfPartyACODE.Value = null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnRunReport_Click(object sender, EventArgs e)
        {
            SessionClear();

            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }

            if (TxtFromDate.Text != string.Empty)
            {
                Session["FROM_DATE"] = TxtFromDate.Text.Trim().ToString();
            }
            else
            {
                Session["FROM_DATE"] = null;
            }

            if (TxtToDate.Text != string.Empty)
            {
                Session["TO_DATE"] = TxtToDate.Text.Trim().ToString();
            }
            else
            {
                Session["TO_DATE"] = null;
            }
            Session["VIEW_REPORT"] = DdlReportView.SelectedValue.Trim().ToString();

            if (HfGroupCode.Value != string.Empty)
            {
                Session["GROUP_CODE"] = HfGroupCode.Value.Trim().ToString();
            }
            else
            {
                Session["GROUP_CODE"] = null;
            }

            Session["A_ACODE"] = HfACODE.Value.Trim().ToString();
            Session["P_ACODE"] = HfPartyACODE.Value.Trim().ToString();
            Session["MENU_FLAG"] = HfMenuFlag.Value.Trim().ToString();
           
            if (HfMenuFlag.Value.ToString() == "CB")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewCashAndBankBookStatementPrint.aspx', '_blank');", true);
            }
            else if (HfMenuFlag.Value.ToString() == "BB")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewCashAndBankBookStatementPrint.aspx', '_blank');", true);
            }

            else if (HfMenuFlag.Value.ToString() == "PD")
            {
                Session["TRAN_TYPE"] = "P";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountPaymentReceiptDetails.aspx', '_blank');", true);
            }

            else if (HfMenuFlag.Value.ToString() == "RD")
            {
                Session["TRAN_TYPE"] = "R";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountPaymentReceiptDetails.aspx', '_blank');", true);
            }

            else if(HfMenuFlag.Value.ToString() == "JV")
            {
                Session["TRAN_TYPE"] = "J";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountCreditDebitNoteStatementPrint.aspx', '_blank');", true);
            }

            else if (HfMenuFlag.Value.ToString() == "CN")
            {
                Session["TRAN_TYPE"] = "A";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountCreditDebitNoteStatementPrint.aspx', '_blank');", true);
            }

            else if (HfMenuFlag.Value.ToString() == "DN")
            {
                Session["TRAN_TYPE"] = "B";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountCreditDebitNoteStatementPrint.aspx', '_blank');", true);
            }

        }

        public void SessionClear()
        {
            try
            {
                Session["BRANCH_CODE_VALUE"] = null;
                Session["FROM_DATE"] = null;
                Session["TO_DATE"] = null;
                Session["TRAN_TYPE"] = null;
                Session["A_ACODE"] = null;
                Session["P_ACODE"] = null;
                Session["GROUP_CODE"] = null;
                Session["VIEW_REPORT"] = null;

            }
            catch (Exception)
            {
            }
        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }

     
    }
}