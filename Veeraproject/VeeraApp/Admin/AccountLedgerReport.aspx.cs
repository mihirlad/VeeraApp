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
    public partial class LedgerReport : System.Web.UI.Page
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

                    if (HfMenuFlag.Value.ToString() == "L")
                    {
                        hdForAccountLedger.Visible = true;
                        hdForAccountLedgerConfirmation.Visible = false;
                        trReportViewforLedger.Visible = true;
                        trReportViewForLedgerLetter.Visible = false;

                    }
                    else if (HfMenuFlag.Value.ToString() == "LC")
                    {

                        hdForAccountLedger.Visible = false;
                        hdForAccountLedgerConfirmation.Visible = true;
                        trReportViewforLedger.Visible = false;
                        trReportViewForLedgerLetter.Visible = true;
                    }

                    TxtFromDate.Text = Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("dd-MM-yyyy");
                    TxtToDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                    TxtLetterDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                    FillOnlyViewAccountName();
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
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


        //** Get Account Name From Account_Master ***//



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

        //protected void TxtAccountName_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataTable DtAccountName = new DataTable();
        //        DtAccountName = ACCOUNTS_MASLogicLayer.GetAllACCOUNTDetialsByComapnyAndBranch(compcode, Branchcode);
        //        if (TxtAccountName.Text != string.Empty)
        //        {
        //            DataView Dv = new DataView(DtAccountName);
        //            Dv.RowFilter = "ANAME='" + TxtAccountName.Text.Trim() + "'";
        //            DataTable DtView = Dv.ToTable();
        //            if (DtView.Rows.Count > 0)
        //            {
        //                HfACODE.Value = DtView.Rows[0]["ACODE"].ToString();
        //            }

        //        }
        //        else
        //        {
        //            HfACODE.Value = null;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        protected void TxtAccountsName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfACODEGrid = (HiddenField)row.Cells[0].FindControl("HfACODEGrid");

                CheckBox ChkSelectAccounts = (CheckBox)row.Cells[0].FindControl("ChkSelectAccounts");
                //  TextBox TxtAccountsNameGrid = (TextBox)row.Cells[1].FindControl("TxtAccountsNameGrid");

                DataTable DtAccountName = new DataTable();

                DtAccountName = ACCOUNTS_MASLogicLayer.GetAllACCOUNTDetialsByComapnyAndBranch(compcode, Branchcode);

                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtAccountName);
                    Dv.RowFilter = "ANAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfACODEGrid.Value = DtView.Rows[0]["ACODE"].ToString();
                        ChkSelectAccounts.Checked = true;
                        ChkSelectAccounts.Enabled = false;
                    }

                }
                else
                {
                    HfACODEGrid.Value = null;
                    ChkSelectAccounts.Checked = false;
                    ChkSelectAccounts.Enabled = true;
                }
            }

            catch (Exception)
            {

                throw;
            }
        }

        public void FillOnlyViewAccountName()
        {
            try
            {
                DataTable dt = new DataTable();
                if (ViewState["AccountsTemp"] != null)
                {
                    dt = (DataTable)ViewState["AccountsTemp"];
                }
                else
                {

                    dt.Columns.Add("ACODE", typeof(System.String));


                    for (int i = 0; i < 10; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["ACODE"] = "";

                        dt.Rows.Add(dr);
                    }
                }

                GvAccountNameDetails.DataSource = dt;
                GvAccountNameDetails.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnRunReport_Click(object sender, EventArgs e)
        {

            string CSV_ACODE = string.Empty;
            for (int i = 0; i < GvAccountNameDetails.Rows.Count; i++)
            {
                HiddenField HfACODEGrid = (HiddenField)GvAccountNameDetails.Rows[i].FindControl("HfACODEGrid");
                if(HfACODEGrid.Value!=string.Empty && HfACODEGrid.Value!=null)
                {
                if (CSV_ACODE != string.Empty)
                {
                    CSV_ACODE = CSV_ACODE + "," + HfACODEGrid.Value;//,2,3,4
                }
                else
                {
                    CSV_ACODE = CSV_ACODE + HfACODEGrid.Value;
                }
                }

            }

            Session["ACODE"] = CSV_ACODE;


            Session["FROM_DATE"] = TxtFromDate.Text.Trim().ToString();
            Session["TO_DATE"] = TxtToDate.Text.Trim().ToString();
            Session["GROUP_CODE"] = HfGroupCode.Value.Trim().ToString();
            //    Session["ACODE"] = HfACODE.Value.Trim().ToString();
            Session["MENU_FLAG"] = HfMenuFlag.Value.Trim().ToString();

            if (HfMenuFlag.Value.ToString() == "L")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountLedgerPrint.aspx', '_blank');", true);
            }
            else if (HfMenuFlag.Value.ToString() == "LC")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountLedgerPrint.aspx', '_blank');", true);
            }


        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }


    }

}