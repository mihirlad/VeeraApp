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
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class BankReconciliation : System.Web.UI.Page
    {
        public static string compcode;
        static DataTable DtSearch = new DataTable();
        public static string Branchcode;


        protected void Page_Load(object sender, EventArgs e)
        {
            compcode = Session["COMP_CODE"].ToString();
            Branchcode = Session["BRANCH_CODE"].ToString();

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
                if (!IsPostBack == true)
                {

                    FillMasterTxtAccountName();
                    FillPAY_REC_MasterGrid(Session["COMP_CODE"].ToString());

                   
                }

           }


            else
            {
                Response.Redirect("../Login.aspx");
            }
        }


        public void FillMasterTxtAccountName()
        {
            try
            {
                DataTable DtFilter = new DataTable();


                DtFilter = ACCOUNTS_MASLogicLayer.GetACCOUNTNameForCashBankBook(Session["COMP_CODE"].ToString(), "23".ToString());
                if (DtFilter.Rows.Count > 0)
                {
                    DataView DvAccount = new DataView(DtFilter);
                    DvAccount.RowFilter = "ACODE>0";
                    DataTable Dt = DvAccount.ToTable();
                    HfAccountCodeOnMasterGrid.Value = Dt.Rows[0]["ACODE"].ToString();
                    if (Convert.ToInt32(HfAccountCodeOnMasterGrid.Value) > 0)
                    {

                        TxtAccountNameOnMasterGrid.Text = Dt.Rows[0]["ANAME"].ToString();
                        HfAccountCodeOnMasterGrid.Value = Dt.Rows[0]["ACODE"].ToString();                       
                    }
                    else
                    {
                       
                        TxtAccountNameOnMasterGrid.Text = string.Empty;
                        HfAccountCodeOnMasterGrid.Value = string.Empty;
                    }
                }
                else
                {
                 
                    TxtAccountNameOnMasterGrid.Text = string.Empty;
                    HfAccountCodeOnMasterGrid.Value = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillPAY_REC_MasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = PAY_REC_MLogicLayer.GetAllPAY_REC_MASDetailsForBankReco(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()), HfAccountCodeOnMasterGrid.Value.ToString());
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvPayReceiveMaster.DataSource = Dv.ToTable();
            GvPayReceiveMaster.DataBind();

          
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

        protected void TxtBankDate_TextChanged(object sender, EventArgs e)
        {
            try
            {

                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                //HiddenField HfCompCodeGrid = (HiddenField)row.Cells[0].FindControl("HfCompCodeGrid");
                //HiddenField HfTranDateGrid = (HiddenField)row.Cells[0].FindControl("HfTranDateGrid");
                //HiddenField HfTranNoGrid = (HiddenField)row.Cells[0].FindControl("HfTranNoGrid");
                //HiddenField HfSrNoGrid = (HiddenField)row.Cells[0].FindControl("HfSrNoGrid");

                HiddenField HfUnsavedGrid = (HiddenField)row.Cells[0].FindControl("HfUnsaved");

                HfUnsavedGrid.Value = "1";
                //TextBox TxtBankDate = (TextBox)row.Cells[9].FindControl("TxtBankDate");
                //TextBox TxtBankRecoRemark = (TextBox)row.Cells[10].FindControl("TxtBankRecoRemark");

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtBankREcoRemark_TextChanged(object sender, EventArgs e)
        {
            try
            {

                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                //HiddenField HfCompCodeGrid = (HiddenField)row.Cells[0].FindControl("HfCompCodeGrid");
                //HiddenField HfTranDateGrid = (HiddenField)row.Cells[0].FindControl("HfTranDateGrid");
                //HiddenField HfTranNoGrid = (HiddenField)row.Cells[0].FindControl("HfTranNoGrid");
                //HiddenField HfSrNoGrid = (HiddenField)row.Cells[0].FindControl("HfSrNoGrid");

                //TextBox TxtBankDate = (TextBox)row.Cells[9].FindControl("TxtBankDate");
                //TextBox TxtBankRecoRemark = (TextBox)row.Cells[10].FindControl("TxtBankRecoRemark");

                HiddenField HfUnsavedGrid = (HiddenField)row.Cells[0].FindControl("HfUnsaved");

                HfUnsavedGrid.Value = "1";


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                #region UPDATE BANK RECONCILIATION DATA
                int flgsave = 0;
                foreach (GridViewRow row in GvPayReceiveMaster.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        HiddenField HfCompCodeGrid = (HiddenField)row.Cells[0].FindControl("HfCompCodeGrid");
                        HiddenField HfTranDateGrid = (HiddenField)row.Cells[0].FindControl("HfTranDateGrid");
                        HiddenField HfTranNoGrid = (HiddenField)row.Cells[0].FindControl("HfTranNoGrid");
                        HiddenField HfSrNoGrid = (HiddenField)row.Cells[0].FindControl("HfSrNoGrid");

                        TextBox TxtBankDate = (TextBox)row.Cells[9].FindControl("TxtBankDate");
                        TextBox TxtBankRecoRemark = (TextBox)row.Cells[10].FindControl("TxtBankRecoRemark");

                        HiddenField HfUnsavedGrid = (HiddenField)row.Cells[0].FindControl("HfUnsaved");

                        PAY_REC_TLogicLayer insert = new PAY_REC_TLogicLayer();

                        insert.BANKDT = Convert.ToDateTime(TxtBankDate.Text.Trim().ToString()).ToString("MM-dd-yyyy");
                        insert.BANK_NARRN = TxtBankRecoRemark.Text.Trim().ToUpper().ToString();

                        if (HfUnsavedGrid.Value == "1")
                        {
                            string str = PAY_REC_MLogicLayer.UpdatePAY_REC_TDetailForBANK_RECO(HfCompCodeGrid.Value.Trim().ToString(), HfTranNoGrid.Value.Trim().ToString(), Convert.ToDateTime(HfTranDateGrid.Value.Trim().ToString()), HfSrNoGrid.Value.Trim().ToString(), Convert.ToDateTime(TxtBankDate.Text.Trim().ToString()), TxtBankRecoRemark.Text.Trim().ToString());
                            if (str.Contains("successfully"))
                            {

                                flgsave = 1;

                            }
                        }

                    }

                }
                FillPAY_REC_MasterGrid(Session["COMP_CODE"].ToString());



                if (flgsave==1)
                {

                    lblmsg.Text = "BANK RECONCILIATION UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    FillPAY_REC_MasterGrid(Session["COMP_CODE"].ToString());

                }
                //else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                //{
                //    lblmsg.Text = "BANK RECONCILIATION ALREADY EXIST.";
                //    lblmsg.ForeColor = Color.Red;
                //}
                else
                {
                    lblmsg.Text = "ERROR : BANK RECONCILIATION NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }

                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }

    
        protected void btnViewBankRecoReport_Click1(object sender, EventArgs e)
        {
            Session["ACODE"] = "407";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewBankReconciliationPrint.aspx', '_blank');", true);
        }
    }
}