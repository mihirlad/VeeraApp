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
    public partial class PurchaseOrderReport : System.Web.UI.Page
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
                    if (!string.IsNullOrWhiteSpace(Request.QueryString["TRAN_TYPE"]))
                    {
                        HfTranType.Value = Request.QueryString["TRAN_TYPE"];
                    }

                    if(HfTranType.Value.ToString()=="P")
                    {
                        HdForPurchase.Visible = true;
                        HdForSales.Visible = false;
                    }
                    else if (HfTranType.Value.ToString() == "S")
                    {
                        HdForPurchase.Visible = false;
                        HdForSales.Visible = true;
                    }
                    else
                    {

                    }

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
                    TxtProductCode.Text = string.Empty;
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
                    TxtProductCode.Text = string.Empty;
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


        protected void BtnDateWise_OrderDetailsReport_Click(object sender, EventArgs e)
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

            Session["REPORT_VIEW"] = "1";

            if(TxtFromDate.Text!=string.Empty)
            {
                Session["FROM_DATE"] = TxtFromDate.Text.Trim().ToString();
            }
            else
            {
                Session["FROM_DATE"] = null;
            }
           
            if(TxtToDate.Text!=string.Empty)
            {
                Session["TO_DATE"] = TxtToDate.Text.Trim().ToString();
            }
            else
            {
                Session["TO_DATE"] = null;
            }

            if(HfACODE.Value!=string.Empty)
            {
                Session["ACODE"] = HfACODE.Value.Trim().ToString();
            }
            else
            {
                Session["ACODE"] = null;
            }
            
            if(HfTranType.Value!=string.Empty)
            {
                Session["TRAN_TYPE"] = HfTranType.Value.Trim().ToString();
            }
            else
            {
                Session["TRAN_TYPE"] = null;
            }
          
            if(HfCATCODE.Value!=string.Empty)
            {
                Session["CAT_CODE"] = HfCATCODE.Value.Trim().ToString();
            }
            else
            {
                Session["CAT_CODE"] = null;
            }

            if(HfProductCode.Value!=string.Empty)
            {
                Session["PROD_CODE"] = HfProductCode.Value.Trim().ToString();
            }
            else
            {
                Session["PROD_CODE"] = null;
            }

            if(HfSCODE.Value!=string.Empty)
            {
                Session["SCODE"] = HfSCODE.Value.Trim().ToString();
            }
            else
            {
                Session["SCODE"] = null;
            }
           
            

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewPurchaseOrderPrint.aspx', '_blank');", true);

        }

        protected void BtnPartyWise_OrderDetailsReport_Click(object sender, EventArgs e)
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

            Session["REPORT_VIEW"] = "2";

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

            if (HfTranType.Value != string.Empty)
            {
                Session["TRAN_TYPE"] = HfTranType.Value.Trim().ToString();
            }
            else
            {
                Session["TRAN_TYPE"] = null;
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



            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewPurchaseOrderPrint.aspx', '_blank');", true);

        }

        protected void BtnPartyWise_OutstandingDetailsReport_Click(object sender, EventArgs e)
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

            if (HfTranType.Value != string.Empty)
            {
                Session["TRAN_TYPE"] = HfTranType.Value.Trim().ToString();
            }
            else
            {
                Session["TRAN_TYPE"] = null;
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

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerInventory/ViewPurchaseOrderOutstadingDetailPrint.aspx', '_blank');", true);
        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }

        public void SessionClear()
        {
            try
            {
                Session["BRANCH_CODE_VALUE"] = null;
                Session["FROM_DATE"] = null;
                Session["TO_DATE"] = null;
                Session["TRAN_TYPE"] = null;
                Session["ACODE"] = null;
                Session["CAT_CODE"] = null;
                Session["PROD_CODE"] = null;
                Session["SCODE"] = null;
                Session["REPORT_VIEW"] = null;


            }
            catch (Exception)
            {
            }
        }


    }
}