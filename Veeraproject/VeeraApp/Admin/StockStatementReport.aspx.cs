using MihirValid;
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
    public partial class StockStatementReport : System.Web.UI.Page
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
                    TxtFromDate.Text = Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("dd-MM-yyyy");
                    TxtToDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                    if (Session["USERTYPE"].ToString() == "A")
                    {
                        FillDdlBranchOnCompCode();
                    }
                    else
                    {
                        FillDdlBranchOnBranchCode();
                    }
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
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
        public static List<string> GetCategoryName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from STOCK_CATAGORY where COMP_CODE=@COMP_CODE and CAT_NAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> CatNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CatNames.Add(dt.Rows[i][1].ToString());
            }
            return CatNames;
        }

        static int Cat_Code = 0;
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetProductCode(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd;
            if (Cat_Code == 0)
            {
                cmd = new SqlCommand("select * from STOCK_MAS where COMP_CODE=@COMP_CODE and PROD_CODE like @PROD_CODE + '%'", con);
            }
            else
            {
                cmd = new SqlCommand("select * from STOCK_MAS where COMP_CODE=@COMP_CODE and PROD_CODE like @PROD_CODE + '%' and CAT_CODE=@CAT_CODE", con);
                cmd.Parameters.AddWithValue("@CAT_CODE", Cat_Code);
            }

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
            SqlCommand cmd;

            if (Cat_Code == 0)
            {
                cmd = new SqlCommand("select * from STOCK_MAS where COMP_CODE=@COMP_CODE and sname like @name + '%'", con);
            }
            else
            {
                cmd = new SqlCommand("select * from STOCK_MAS where COMP_CODE=@COMP_CODE and sname like @name + '%' and CAT_CODE=@CAT_CODE", con);
                cmd.Parameters.AddWithValue("@CAT_CODE", Cat_Code);
            }

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

        protected void TxtCategoryName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtCategory = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtCategory = STOCKCategory_MASLogicLayer.GetAllSTOCKCategory_MASDetailWiseCompany(Comp_Code);
                if (TxtCategoryName.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtCategory);
                    Dv.RowFilter = "CAT_NAME='" + TxtCategoryName.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfCATCODE.Value = DtView.Rows[0]["CAT_CODE"].ToString();
                        Cat_Code = Convert.ToInt32(DtView.Rows[0]["CAT_CODE"].ToString());
                    }
                    else
                    {
                        HfCATCODE.Value = string.Empty;
                        Cat_Code = 0;
                    }

                }
                else
                {
                    HfCATCODE.Value = string.Empty;
                    Cat_Code = 0;
                }
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
                DataTable DtProduct = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
                if (TxtProductCode.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtProduct);
                    Dv.RowFilter = "PROD_CODE='" + TxtProductCode.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfSCODE.Value = DtView.Rows[0]["SCODE"].ToString();
                        TxtProductName.Text = DtView.Rows[0]["SNAME"].ToString();

                    }
                    else
                    {
                        HfSCODE.Value = string.Empty;
                        TxtProductName.Text = string.Empty;
                    }
                }

                else
                {
                    HfSCODE.Value = string.Empty;
                    TxtProductName.Text = string.Empty;
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
                DataTable DtProduct = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
                if (TxtProductName.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtProduct);
                    Dv.RowFilter = "SNAME='" + TxtProductName.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfSCODE.Value = DtView.Rows[0]["SCODE"].ToString();
                        TxtProductCode.Text = DtView.Rows[0]["PROD_CODE"].ToString();

                    }

                    else
                    {
                        HfSCODE.Value = string.Empty;
                        TxtProductCode.Text = string.Empty;
                    }
                }
                else
                {
                    HfSCODE.Value = string.Empty;
                    TxtProductName.Text = string.Empty;
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

        public void SessionClear()
        {
            try
            {
                Session["BRANCH_CODE_VALUE"] = null;
                Session["FROM_DATE"] = null;
                Session["FROM_DATE"] = null;
                Session["TO_DATE"] = null;
                Session["ACODE"] = null;
                Session["CAT_CODE"] = null;
                Session["PROD_CODE"] = null;
                Session["SCODE"] = null;
                Session["REPORT_VIEW"] = null;
                Session["P_REPORT"] = null;


            }
            catch (Exception)
            {
            }
        }

        protected void BtnStockListBranchWise_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "STOCK_LIST_BRANCHWISE";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }

        protected void BtnStockListStatement_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "STOCK_LIST_STATEMENT";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }

        protected void BtnStockDetailDateWise_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "STOCK_DETAIL_DATEWISE";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);

        }

        protected void BtnStockDetailMonthlyWise_Click(object sender, EventArgs e)
        {

            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "STOCK_DETAIL_MONTHWISE";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);


        }

        protected void BtnStockClosingDetail_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "STOCK_CLOSING_DETAIL";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);

        }

        protected void BtnMaximumStock_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "MAXIMUM_STOCK";

            Session["P_REPORT"] = "MAX";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }

        protected void BtnMinimumStock_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "MINIMUM_STOCK";

            Session["P_REPORT"] = "MIN";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }

        protected void BtnAllStockWithZero_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "ALL_STOCK_WITH_ZERO";

            Session["P_REPORT"] = "ALL";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }

        protected void BtnBranchStockOneItem_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "BRANCH_STOCK_ONE_ITEM";
            Session["P_SCODE_FLAG"] = "N";

           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }

        protected void BtnBarcodeStockDetailExcise_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "BARCODE_STOCK_DETAIL_EXCISE";
            Session["P_USERTYPE"] = Session["USERTYPE"].ToString();



            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }

        protected void BtnBarcodeStockStatus_Click(object sender, EventArgs e)
        {
             SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "BARCODE_STOCK_STATUS";
            Session["P_REPORT"] = "D";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }

        protected void BtnBarcodeStockWithZeroVlaue_Click(object sender, EventArgs e)
        {
             SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "BARCODE_STOCK_WITH_ZERO_VALUE";
            Session["P_REPORT"] = "Z";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }

        protected void BtnBarcodeStockDetail_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "BARCODE_STOCK_DETAIL";
         
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }

        protected void BtnBarcodeStockSummary_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "BARCODE_STOCK_SUMMARY";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }

        protected void BtnBarcodeStockValue_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "BARCODE_STOCK_VALUE";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }




        protected void BtnBarcodeStockHistory_Click(object sender, EventArgs e)
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

            ViewState["BARCODE_TYPE"] = "History";
        }


        protected void BtnBarcodeStockPrint_Click(object sender, EventArgs e)
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

            ViewState["BARCODE_TYPE"] = "Print";
        }



        #region BARCODE PROCESS ON THE POPUP MODEL 

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

                    dt.Columns.Add("BARCODE", typeof(System.String));

                    for (int i = 0; i < 50; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["BARCODE"] = "";
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


                dt.Columns.Add("BARCODE", typeof(System.String));


                for (int i = 0; i < 50; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["BARCODE"] = "";


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
                        dvBlankFilter.RowFilter = "BARCODE<>''";
                        dtCurrentTable = dvBlankFilter.ToTable();



                        //NEW BLOCK FOR ADD SECOND ROW ISSUE  ON 13-09-2019
                        foreach (GridViewRow row in GvViewBarcode.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {
                                TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;

                                if (TxtBarcode.Text.Trim() != string.Empty)
                                {
                                    DataView dv = new DataView(dtCurrentTable);
                                    dv.RowFilter = "BARCODE='" + TxtBarcode.Text.Trim() + "'";
                                    DataTable dtCurrentTableFilter = new DataTable();
                                    dtCurrentTableFilter = dv.ToTable();
                                    if (dtCurrentTableFilter.Rows.Count <= 0)
                                    {
                                        dr = dtCurrentTable.NewRow();

                                        dr["BARCODE"] = TxtBarcode.Text.Trim();

                                    }
                                }
                            }
                        }
                        //*****//
                    }
                    else
                    {
                        dtCurrentTable.Columns.Add("BARCODE", typeof(System.String));

                        foreach (GridViewRow row in GvViewBarcode.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {
                                TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;


                                if (TxtBarcode.Text.Trim() != string.Empty)
                                {
                                    dr = dtCurrentTable.NewRow();

                                    dr["BARCODE"] = TxtBarcode.Text.Trim();

                                    dtCurrentTable.Rows.Add(dr);
                                }
                            }
                        }
                    }



                    for (int j = 0; j < Convert.ToInt32(TxtBarcodeInputNo.Text.Trim()); j++)
                    {
                        dr = dtCurrentTable.NewRow();

                        dr["BARCODE"] = "";

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

        protected void btnRunBarcodeProcess_Click(object sender, EventArgs e)
        {
            try
            {
                int sid = 1, id;

                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();

                string sqlStr = "Delete from BARCODE_HIS_TEMP ";

                using (var cmd = new SqlCommand(sqlStr, con))
                {
                    id = Convert.ToInt32(cmd.ExecuteNonQuery());

                }


                foreach (GridViewRow row in GvViewBarcode.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;

                        if (TxtBarcode.Text != string.Empty && TxtBarcode.Text != null)
                        {

                            var sql = "INSERT INTO BARCODE_HIS_TEMP(SID,BARCODE) VALUES(@SID,@BARCODE)";
                            using (var cmd = new SqlCommand(sql, con))
                            {
                                cmd.Parameters.AddWithValue("@BARCODE", TxtBarcode.Text);
                                cmd.Parameters.AddWithValue("@SID", sid);

                                cmd.ExecuteNonQuery();


                            }
                            sid++;

                        }

                    }

                }

                #region PAGE REDIRECT 


                SessionClear();

                //MIHIR LAD
                string csv_branch = GetBranchList();

                if (csv_branch != string.Empty)
                {
                    Session["BRANCH_CODE_VALUE"] = csv_branch;
                }
                else
                {
                    Session["BRANCH_CODE_VALUE"] = null;
                }
                //

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

                if (HfACODE.Value != string.Empty)
                {
                    Session["ACODE"] = HfACODE.Value.Trim().ToString();
                }
                else
                {
                    Session["ACODE"] = null;
                }

                if (HfCATCODE.Value != string.Empty)
                {
                    Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
                }
                else
                {
                    Session["CAT_CODE"] = null;
                }

                if (HfProductCode.Value != string.Empty)
                {
                    Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
                }
                else
                {
                    Session["PROD_CODE"] = null;
                }

                if (HfSCODE.Value != string.Empty)
                {
                    Session["SCODE"] = HfSCODE.Value.Trim().ToString();
                }
                else
                {
                    Session["SCODE"] = null;
                }

                if (ViewState["BARCODE_TYPE"].ToString() == "History")
                {
                    Session["REPORT_TYPE"] = "BARCODE_STOCK_HISTORY";

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
                }

                else if (ViewState["BARCODE_TYPE"].ToString() == "Print")
                {
                    Session["REPORT_TYPE"] = "BARCODE_STOCK_PRINT";

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
                }


                #endregion

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnClearBarcodeProcess_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GvViewBarcode.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                    TxtBarcode.Text = string.Empty;
                }
            }
        }


        #endregion


        protected void BtnSupplierStockIndent_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "SUPPLIER_STOCK_INDENT";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);

        }

        protected void BtnStockIndentWithLastPurchase_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "STOCK_INDENT_WITH_LAST_PURCHASE";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }




        protected void BtnDiffQtyStockWithBarcodeStock_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "DIFF_QTY_STOCK_WITH_BARCODE_STOCK";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }

        protected void BtnDiffStockBarcodePosting_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "DIFF_STOCK_BARCODE_POSTING";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }



        protected void BtnSalesDC_DiffBarcodeQty_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "SALES_DC_DIFF_BARCODE_QTY";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }

        protected void BtnBranchIssueDC_DiffBarcodeQty_Click(object sender, EventArgs e)
        {
            SessionClear();

            //MIHIR LAD
            string csv_branch = GetBranchList();

            if (csv_branch != string.Empty)
            {
                Session["BRANCH_CODE_VALUE"] = csv_branch;
            }
            else
            {
                Session["BRANCH_CODE_VALUE"] = null;
            }
            //

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

            if (HfACODE.Value != string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }

            if (HfCATCODE.Value != string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if (HfProductCode.Value != string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if (HfSCODE.Value != string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }


            Session["REPORT_TYPE"] = "BRANCH_ISSUE_DIFF_BARCODE_QTY";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewStockStatementPrint.aspx', '_blank');", true);
        }


        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }


        protected void BtnUpdateBarcodePrice_Click(object sender, EventArgs e)
        {
            //ViewState["PopupBarCodeUpdate"] = 1;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelUpdateBarcodePrice", "ShowModelUpdateBarcodePrice()", true);
        }



        protected void BtnOpeningStockBracode_Click(object sender, EventArgs e)
        {
         
                ViewState["P_TYPE"] = null;

                if (btnSave.Text == "YES")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel1", "ShowModel1()", true);
                    ViewState["P_TYPE"] = "OP_STOCK_BARCODE";
                }         
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModel1", "HideModel11()", true);
                }

        }

        protected void BtnPurchaseStockBracode_Click(object sender, EventArgs e)
        {

            ViewState["P_TYPE"] = null;

            if (btnSave.Text == "YES")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel1", "ShowModel1()", true);
                ViewState["P_TYPE"] = "PURCHASE_STOCK_BARCODE";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModel1", "HideModel11()", true);
            }

        }

        protected void BtnAssemblyStockBarcode_Click(object sender, EventArgs e)
        {
            ViewState["P_TYPE"] = null;

            if (btnSave.Text == "YES")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel1", "ShowModel1()", true);
                ViewState["P_TYPE"] = "ASSEMBLY_STOCK_BARCODE";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModel1", "HideModel11()", true);
            }

        }

        protected void BtnBranchTransferStockBarcode_Click(object sender, EventArgs e)
        {
            ViewState["P_TYPE"] = null;

            if (btnSave.Text == "YES")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel1", "ShowModel1()", true);
                ViewState["P_TYPE"] = "XFER_STOCK_BARCODE";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModel1", "HideModel11()", true);
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["P_TYPE"].ToString() == "OP_STOCK_BARCODE")
                {
                    string str = StockStatementReport_LogicLayer.upd_op_stock_barcode_price(Session["COMP_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), "OP");

                    if (str.Contains("successfully"))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sucessfully Record Updated')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error')", true);
                    }
                }

                else if(ViewState["P_TYPE"].ToString() == "PURCHASE_STOCK_BARCODE")
                {
                    string str = StockStatementReport_LogicLayer.upd_purchase_stock_barcode_price(Session["COMP_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), "OP");

                    if (str.Contains("successfully"))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sucessfully Record Updated')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error')", true);
                    }
                }

                else if (ViewState["P_TYPE"].ToString() == "ASSEMBLY_STOCK_BARCODE")
                {
                    string str = StockStatementReport_LogicLayer.upd_assemble_stock_barcode_price(Session["COMP_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), "OP");

                    if (str.Contains("successfully"))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sucessfully Record Updated')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error')", true);
                    }
                }

                else if (ViewState["P_TYPE"].ToString() == "XFER_STOCK_BARCODE")
                {
                    string str = StockStatementReport_LogicLayer.upd_xfer_stock_barcode_price(Session["COMP_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), "OP");

                    if (str.Contains("successfully"))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sucessfully Record Updated')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error')", true);
                    }
                }

                else
                {

                }

            }
            catch (Exception)
            {

                throw;
            }

           

            
        }
    }
}