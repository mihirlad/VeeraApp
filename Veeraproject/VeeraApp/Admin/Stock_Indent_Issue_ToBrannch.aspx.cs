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
using MihirValid;

namespace VeeraApp.Admin
{
    public partial class Stock_Indent_Issue_ToBrannch : System.Web.UI.Page
    {
        public static string compcode;
        public static string Branchcode;
        public static string StockCategoryCode;
        static DataTable DtSearch = new DataTable();

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
                    CalendarExtenderIndentDate.StartDate = Convert.ToDateTime(Session["FIN_YEAR"].ToString());
                    CalendarExtenderIndentDate.EndDate = Convert.ToDateTime(Session["FIN_YEAR_END"].ToString());

                    if (!string.IsNullOrWhiteSpace(Request.QueryString["Indent_Branch"]))
                    {
                        HfStockIndetBranchType.Value = Request.QueryString["Indent_Branch"];
                    }

                    FillSTOCK_INDENT_ISSUE_TOBRANCH_MasterGrid(Session["COMP_CODE"].ToString());

                    if (HfStockIndetBranchType.Value == "T")
                    {

                        PageTiltle1.Visible = true;
                        PageTiltle2.Visible = false;
                        BtnAdd.Enabled = true;
                    }

                    else if (HfStockIndetBranchType.Value == "F")
                    {

                        PageTiltle1.Visible = false;
                        PageTiltle2.Visible = true;
                        BtnAdd.Enabled = false;

                    }
                    else
                    { }
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

        public void FillSTOCK_INDENT_ISSUE_TOBRANCH_MasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = INDENT_MASLogicLayer.GetAllSTOCK_INDENT_ISSUE_BRANCH_MASDetails(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()), Convert.ToInt32(Session["BRANCH_CODE"].ToString()),HfStockIndetBranchType.Value.ToString());
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvStockIndentToBranchMaster.DataSource = Dv.ToTable();
            GvStockIndentToBranchMaster.DataBind();

            DtSearch = Dv.ToTable();

        }

        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            TxtIndentNo.Text = string.Empty;
            TxtIndentDate.Text = string.Empty;
            TxtFromBranch.Text = string.Empty;
            TxtToBranch.Text = string.Empty;
            TxtPreparedBy.Text = string.Empty;
            TxtRemark.Text = string.Empty;
            DdlReceivedFlag.SelectedValue = "N";
            TxtReceivedDate.Text = string.Empty;
            TxtReceivedBy.Text = string.Empty;
            DdlConfirmFlag.SelectedValue = "N";
            TxtConfirmBy.Text = string.Empty;
            TxtConfirmDate.Text = string.Empty;
            DdlClosedFlag.SelectedValue = "N";
            TxtClosedDate.Text = string.Empty;
            TxtClosedBy.Text = string.Empty;
            RdBtn_IndentTypeExtraSpend.Checked = false;
            RdIBtn_IndenTypeStockLevel.Checked = false;

            SetInitialRow();
            BtncallUpd.Text = "SAVE";
        }


        public void ControllerEnable()
        {
            TxtIndentNo.Enabled = false;
            TxtIndentDate.Enabled = true;
            TxtFromBranch.Enabled = false;
            TxtToBranch.Enabled = true;
            TxtPreparedBy.Enabled = true;
            TxtRemark.Enabled = true;
            DdlReceivedFlag.Enabled = true;
            TxtReceivedDate.Enabled = true;
            TxtReceivedBy.Enabled = true;
            DdlConfirmFlag.Enabled = true;
            TxtConfirmBy.Enabled = true;
            TxtConfirmDate.Enabled = true;
            DdlClosedFlag.Enabled = true;
            TxtClosedDate.Enabled = true;
            TxtClosedBy.Enabled = true;

            if (HfStockIndetBranchType.Value == "T")
            {


                DdlReceivedFlag.Enabled = false;
                TxtReceivedBy.Enabled = false;
                TxtReceivedDate.Enabled = false;

            }

            else if (HfStockIndetBranchType.Value == "F")
            {

                DdlReceivedFlag.Enabled = true;
                TxtReceivedBy.Enabled = true;
                TxtReceivedDate.Enabled = true;


            }
        }

        public void ControllerDisable()
        {
            TxtIndentNo.Enabled = false;
            TxtIndentDate.Enabled = false;
            TxtFromBranch.Enabled = false;
            TxtToBranch.Enabled = false;
            TxtPreparedBy.Enabled = false;
            TxtRemark.Enabled = false;
            DdlReceivedFlag.Enabled = false;
            TxtReceivedDate.Enabled = false;
            TxtReceivedBy.Enabled = false;
            DdlConfirmFlag.Enabled = false;
            TxtConfirmBy.Enabled = false;
            TxtConfirmDate.Enabled = false;
            DdlClosedFlag.Enabled = false;
            TxtClosedDate.Enabled = false;
            TxtClosedBy.Enabled = false;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetBranchName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from BRANCH_MAS where COMP_CODE=@COMP_CODE and BRANCH_NAME like @BRANCH_NAME + '%'", con);
            cmd.Parameters.AddWithValue("@BRANCH_NAME", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> BranchName = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BranchName.Add(dt.Rows[i][2].ToString());
            }
            return BranchName;
        }

      
        protected void TxtToBranch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select BRANCH_CODE from BRANCH_MAS where BRANCH_NAME = '" + TxtToBranch.Text + "' and COMP_CODE = " + Session["COMP_CODE"].ToString(), con);
                int x = Convert.ToInt32(cmd.ExecuteScalar());
                if (x == 0)
                {
                    TxtToBranch.BackColor = Color.Red;
                }
                else
                {
                    HfToBranchCode.Value = cmd.ExecuteScalar().ToString();
                    TxtToBranch.BackColor = Color.White; con.Close();


                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string>GetPreparedPersonName(string prefixText)
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

        protected void TxtPreparedBy_TextChanged(object sender, EventArgs e)
        {
            try
            {

                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtPreparedBy.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtPreparedBy.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfPreparedBy.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtIndentDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string IndentNO = INDENT_MASLogicLayer.GetIndentNumberForStockIndentIssueToBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtIndentDate.Text.Trim()).ToString("yyyy-MM-dd"));
                if (IndentNO.Length <= 8)
                {
                    TxtIndentNo.Text = IndentNO;
                    TxtIndentNo.Enabled = false;
                }
                else
                {
                    TxtIndentNo.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void RdIBtn_IndenTypeStockLevel_CheckedChanged(object sender, EventArgs e)
        {
            if(RdIBtn_IndenTypeStockLevel.Checked==true)
            {
                btnAddStockCategory.Enabled = true;
            }
        }

        protected void RdBtn_IndentTypeExtraSpend_CheckedChanged(object sender, EventArgs e)
        {
            if (RdBtn_IndentTypeExtraSpend.Checked == true)
            {
                btnAddStockCategory.Enabled = false;
            }
        }

      
        protected void DdlReceivedFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlReceivedFlag.SelectedValue == "Y")
                {
                    TxtReceivedBy.Text = Session["USERNAME"].ToString();
                    TxtReceivedDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    TxtReceivedBy.Text = "";
                    TxtReceivedDate.Text = "";
                }
            }
            catch (Exception)
            {

                throw;
            }
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

        protected void DdlClosedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlClosedFlag.SelectedValue == "Y")
                {
                    TxtClosedBy.Text = Session["USERNAME"].ToString();
                    TxtClosedDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    TxtClosedBy.Text = "";
                    TxtClosedDate.Text = "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillFromBranchOnUpdate(string Id)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BRANCH_MASLogicLayer.GetBranchDetailCompanyWiseFor_Ddl(Comp_Code);


                if (HfBranchCode.Value.ToString() != "0")
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BRANCH_CODE=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtFromBranch.Text = DtView.Rows[0]["BRANCH_NAME"].ToString();
                    HfBranchCode.Value = DtView.Rows[0]["BRANCH_CODE"].ToString();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillPreparedByPersonName(string ServicePerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfPreparedBy.Value.ToString() != "0" && HfPreparedBy.Value.ToString() != null && HfPreparedBy.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ServicePerson;
                    DataTable DtView = Dv.ToTable();

                    TxtPreparedBy.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfPreparedBy.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtPreparedBy.Text = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillToBranchOnUpdate(string Id)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BRANCH_MASLogicLayer.GetBranchDetailCompanyWiseFor_Ddl(Comp_Code);


                if (HfToBranchCode.Value.ToString() != "0")
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BRANCH_CODE=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtToBranch.Text = DtView.Rows[0]["BRANCH_NAME"].ToString();
                    HfToBranchCode.Value = DtView.Rows[0]["BRANCH_CODE"].ToString();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        #region FETCH INDEDT STOCK INTO GRID


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetStockCategoryName(string prefixText)
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
            List<string> StockCategory = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StockCategory.Add(dt.Rows[i][1].ToString());
            }
            return StockCategory;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetStockName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from STOCK_MAS where COMP_CODE=@COMP_CODE and CAT_CODE=@CAT_CODE and sname like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            cmd.Parameters.AddWithValue("@CAT_CODE", StockCategoryCode);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> StockNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StockNames.Add(dt.Rows[i][1].ToString());
            }
            return StockNames;
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetProductCode(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from STOCK_MAS where COMP_CODE=@COMP_CODE and CAT_CODE=@CAT_CODE and PROD_CODE like @PROD_CODE + '%'", con);
            cmd.Parameters.AddWithValue("@PROD_CODE", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            cmd.Parameters.AddWithValue("@CAT_CODE", StockCategoryCode);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> prodCode = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                prodCode.Add(dt.Rows[i][11].ToString());
            }
            return prodCode;
        }


        protected void TxtStockCategoryName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfCategoryCode = (HiddenField)row.Cells[0].FindControl("HfCategoryCode");
                TextBox TxtProductName = (TextBox)row.Cells[1].FindControl("TxtProductName");
                TextBox TxtProductCode = (TextBox)row.Cells[1].FindControl("TxtProductCode");
                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");

                DataTable DtProduct = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtProduct = STOCKCategory_MASLogicLayer.GetAllSTOCKCategory_MASDetailWiseCompany(Comp_Code);
                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtProduct);
                    Dv.RowFilter = "CAT_NAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfCategoryCode.Value= DtView.Rows[0]["CAT_CODE"].ToString();
                        StockCategoryCode = HfCategoryCode.Value;



                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillOnGridStockDetailChanged()
        {
            #region MyRegion

            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
             
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values 

                        HiddenField HfDetailSCode = (HiddenField)GvStockIndentDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        HiddenField HfCategoryCode = (HiddenField)GvStockIndentDetails.Rows[rowIndex].Cells[0].FindControl("HfCategoryCode");


                        TextBox TxtStockCategoryName = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[1].FindControl("TxtStockCategoryName");
                        TextBox TxtProductCode = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[3].FindControl("TxtProductName");
                        TextBox TxtMaxQty = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[4].FindControl("TxtMaxQty");
                        TextBox TxtMinQty = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[5].FindControl("TxtMinQty");
                        TextBox TxtStockQty = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[6].FindControl("TxtStockQty");
                        TextBox TxtOrderQty = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[7].FindControl("TxtOrderQty");
                        TextBox TxtToBranchStock = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[8].FindControl("TxtToBranchStock");



                        //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();

                        dtCurrentTable.Rows[i - 1]["CAT_CODE"] = HfCategoryCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["MAX_QTY"] = TxtMaxQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["MIN_QTY"] = TxtMinQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["STK_QTY"] = TxtStockQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["ORD_QTY"] = TxtOrderQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["BRSTK_QTY"] = TxtToBranchStock.Text.Trim();

                        rowIndex++;

                    }
                }
            }
          
                        #endregion
                    }

        protected void TxtProductCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtProductName = (TextBox)row.Cells[1].FindControl("TxtProductName");
                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");

                TextBox TxtMaxQty = (TextBox)row.Cells[1].FindControl("TxtMaxQty");
                TextBox TxtMinQty = (TextBox)row.Cells[1].FindControl("TxtMinQty");


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

                        TxtProductName.Text = DtView.Rows[0]["SNAME"].ToString();
                        HfDetailSCode.Value = DtView.Rows[0]["SCODE"].ToString();
                        TxtMaxQty.Text = DtView.Rows[0]["MAX_QTY"].ToString();
                        TxtMinQty.Text = DtView.Rows[0]["MIN_QTY"].ToString();

                        FillOnGridStockDetailChanged();
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
                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");


                TextBox TxtMaxQty = (TextBox)row.Cells[1].FindControl("TxtMaxQty");
                TextBox TxtMinQty = (TextBox)row.Cells[1].FindControl("TxtMinQty");

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

                        TxtProductCode.Text = DtView.Rows[0]["PROD_CODE"].ToString();
                        HfDetailSCode.Value = DtView.Rows[0]["SCODE"].ToString();
                        TxtMaxQty.Text = DtView.Rows[0]["MAX_QTY"].ToString();
                        TxtMinQty.Text = DtView.Rows[0]["MIN_QTY"].ToString();

                        FillOnGridStockDetailChanged();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

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
                TxtFromBranch.Text = Session["BRANCH_NAME"].ToString();
                TxtIndentDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                string IndentNO = INDENT_MASLogicLayer.GetIndentNumberForStockIndentIssueToBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtIndentDate.Text.Trim()).ToString("yyyy-MM-dd"));
                if (IndentNO.Length <= 8)
                {
                    TxtIndentNo.Text = IndentNO;
                    TxtIndentNo.Enabled = false;
                }
                else
                {
                    TxtIndentNo.Text = string.Empty;
                }

              
                
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            lblmsg.Text = string.Empty;
            UserRights();
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }

        protected void GvStockIndentDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvStockIndentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GvStockIndentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    TextBox TxtStockCategoryName = (e.Row.FindControl("TxtStockCategoryName") as TextBox);
                    TextBox TxtProductCode = (e.Row.FindControl("TxtProductCode") as TextBox);
                    TextBox TxtProductName = (e.Row.FindControl("TxtProductName") as TextBox);
                    HiddenField HfCategoryCode = (e.Row.FindControl("HfCategoryCode") as HiddenField);
                    HiddenField HfDetailSCode = (e.Row.FindControl("HfDetailSCode") as HiddenField);

                    DataTable DtStockCat = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();

                    DtStockCat = STOCKCategory_MASLogicLayer.GetAllSTOCKCategory_MASDetailWiseCompany(Comp_Code);

                    if (HfCategoryCode.Value != "0" && HfCategoryCode.Value != string.Empty)
                    {
                        DataView Dv = new DataView(DtStockCat);
                        Dv.RowFilter = "CAT_CODE=" + HfCategoryCode.Value;
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            TxtStockCategoryName.Text = DtView.Rows[0]["CAT_NAME"].ToString();
                        }
                        else
                        {
                            TxtStockCategoryName.Text = string.Empty;

                        }
                    }

                    DataTable DtProduct = new DataTable();
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
                            TxtProductCode.Text = string.Empty;

                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region ADD NEW ROW INTO STOCK INDENT GRID

        private void SetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("MIN_QTY", typeof(string));
            table.Columns.Add("MAX_QTY", typeof(string));
            table.Columns.Add("STK_QTY", typeof(string));
            table.Columns.Add("ORD_QTY", typeof(string));
            table.Columns.Add("ACODE", typeof(string));
            table.Columns.Add("LAST_PURDATETIME", typeof(string));
            table.Columns.Add("LAST_PURRATE", typeof(string));
            table.Columns.Add("CAT_CODE", typeof(string));
            table.Columns.Add("BRSTK_QTY", typeof(string));
            table.Columns.Add("REQORD_QTY", typeof(string));
            table.Columns.Add("REMARK", typeof(string));
            table.Columns.Add("STATUS", typeof(string));
            table.Columns.Add("ENDT", typeof(string));
            table.Columns.Add("INS_USERID", typeof(string));
            table.Columns.Add("INS_TERMINAL", typeof(string));
            table.Columns.Add("INS_DATE", typeof(string));
            table.Columns.Add("UPD_USERID", typeof(string));
            table.Columns.Add("UPD_TERMINAL", typeof(string));
            table.Columns.Add("UPD_DATE", typeof(string));
         



            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["SCODE"] = string.Empty;
            dr["MIN_QTY"] = string.Empty;
            dr["MAX_QTY"] = string.Empty;
            dr["STK_QTY"] = string.Empty;
            dr["ORD_QTY"] = string.Empty;
            dr["ACODE"] = string.Empty;
            dr["LAST_PURDATETIME"] = string.Empty;
            dr["LAST_PURRATE"] = string.Empty;
            dr["CAT_CODE"] = string.Empty;
            dr["BRSTK_QTY"] = string.Empty;
            dr["REQORD_QTY"] = string.Empty;
            dr["REMARK"] = string.Empty;
            dr["STATUS"] = string.Empty;
            dr["ENDT"] = string.Empty;
            dr["INS_USERID"] = string.Empty;
            dr["INS_TERMINAL"] = string.Empty;
            dr["INS_DATE"] = string.Empty;
            dr["UPD_USERID"] = string.Empty;
            dr["UPD_TERMINAL"] = string.Empty;
            dr["UPD_DATE"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvStockIndentDetails.DataSource = table;
            GvStockIndentDetails.DataBind();
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

                        HiddenField HfDetailSCode = (HiddenField)GvStockIndentDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        HiddenField HfCategoryCode = (HiddenField)GvStockIndentDetails.Rows[rowIndex].Cells[0].FindControl("HfCategoryCode");
                       

                        TextBox TxtStockCategoryName = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[1].FindControl("TxtStockCategoryName");
                        TextBox TxtProductCode = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[3].FindControl("TxtProductName");
                        TextBox TxtMaxQty = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[4].FindControl("TxtMaxQty");
                        TextBox TxtMinQty = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[5].FindControl("TxtMinQty");
                        TextBox TxtStockQty = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[6].FindControl("TxtStockQty");
                        TextBox TxtOrderQty = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[7].FindControl("TxtOrderQty");
                        TextBox TxtToBranchStock = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[8].FindControl("TxtToBranchStock");



                        //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();

                        dtCurrentTable.Rows[i - 1]["CAT_CODE"] = HfCategoryCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["MAX_QTY"] = TxtMaxQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["MIN_QTY"] = TxtMinQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["STK_QTY"] = TxtStockQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["ORD_QTY"] = TxtOrderQty.Text.Trim();                       
                        dtCurrentTable.Rows[i - 1]["BRSTK_QTY"] = TxtToBranchStock.Text.Trim();
                       
                        rowIndex++;

                    }

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["CAT_CODE"] = "0";
                    drCurrentRow["SCODE"] = "0";
                    drCurrentRow["MAX_QTY"] = "0";
                    drCurrentRow["MIN_QTY"] = "0";
                    drCurrentRow["STK_QTY"] = "0";
                    drCurrentRow["ORD_QTY"] = "0";
                    drCurrentRow["BRSTK_QTY"] = "0";
                
                

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvStockIndentDetails.DataSource = dtCurrentTable;
                    GvStockIndentDetails.DataBind();


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

                        HiddenField HfDetailSCode = (HiddenField)GvStockIndentDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        HiddenField HfCategoryCode = (HiddenField)GvStockIndentDetails.Rows[rowIndex].Cells[0].FindControl("HfCategoryCode");

                        TextBox TxtStockCategoryName = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[1].FindControl("TxtStockCategoryName");
                        TextBox TxtProductCode = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[3].FindControl("TxtProductName");
                        TextBox TxtMaxQty = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[4].FindControl("TxtMaxQty");
                        TextBox TxtMinQty = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[5].FindControl("TxtMinQty");
                        TextBox TxtStockQty = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[6].FindControl("TxtStockQty");
                        TextBox TxtOrderQty = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[7].FindControl("TxtOrderQty");
                        TextBox TxtToBranchStock = (TextBox)GvStockIndentDetails.Rows[rowIndex].Cells[8].FindControl("TxtToBranchStock");


                        //TxtSrNo.Text = dt.Rows[i]["SRNO"].ToString();
                        HfCategoryCode.Value= dt.Rows[i]["CAT_CODE"].ToString();
                        HfDetailSCode.Value = dt.Rows[i]["SCODE"].ToString();
                        TxtMaxQty.Text = dt.Rows[i]["MAX_QTY"].ToString();
                        TxtMinQty.Text = dt.Rows[i]["MIN_QTY"].ToString();
                        TxtOrderQty.Text = dt.Rows[i]["ORD_QTY"].ToString();
                        TxtStockQty.Text = dt.Rows[i]["STK_QTY"].ToString();
                        TxtToBranchStock.Text = dt.Rows[i]["BRSTK_QTY"].ToString();
                       
                        rowIndex++;

                     
                    }
                }
            }
        }


        protected void BtnDeleteRowModelStockItemGrid_Click(object sender, EventArgs e)
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
                GvStockIndentDetails.DataSource = dt;
                GvStockIndentDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }

        protected void BtnAddRowModelStockItemGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }


        #endregion

    
        protected void BtnViewIndentReport_Click(object sender, EventArgs e)
        {

        }

        protected void GvStockIndentToBranchMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GvStockIndentToBranchMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvStockIndentToBranchMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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


                        DataSet ds = INDENT_MASLogicLayer.GetAllIDWiseSTOCK_INDENT_ISSUE_BRANCH_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtIndentDet = ds.Tables[1];
                        DataTable DtIndentCat = ds.Tables[2];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            FillFromBranchOnUpdate(dt.Rows[0]["BRANCH_CODE"].ToString());
                            FillToBranchOnUpdate(dt.Rows[0]["TO_BRANCH_CODE"].ToString());
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            TxtIndentNo.Text= dt.Rows[0]["INDNO"].ToString();
                            TxtIndentDate.Text = Convert.ToDateTime(dt.Rows[0]["INDDT"].ToString()).ToString("dd-MM-yyyy");
                            HfPreparedBy.Value = dt.Rows[0]["BCODE"].ToString();
                            FillPreparedByPersonName(dt.Rows[0]["BCODE"].ToString());
                            TxtRemark.Text= dt.Rows[0]["REMARK"].ToString();
                            DdlReceivedFlag.SelectedValue= dt.Rows[0]["REC_FLAG"].ToString();
                            TxtReceivedBy.Text= dt.Rows[0]["REC_USERID"].ToString();
                            TxtReceivedDate.Text= dt.Rows[0]["REC_DATE"].ToString();
                            DdlConfirmFlag.SelectedValue= dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtConfirmBy.Text= dt.Rows[0]["CHK_USERID"].ToString(); ;
                            TxtConfirmDate.Text= dt.Rows[0]["CHK_DATE"].ToString();
                            DdlClosedFlag.SelectedValue= dt.Rows[0]["CLOSE_FLAG"].ToString();
                            TxtClosedBy.Text= dt.Rows[0]["CLOSE_USERID"].ToString();
                            TxtClosedDate.Text= dt.Rows[0]["CLOSE_DATE"].ToString();

                            if (dt.Rows[0]["INDENT_TYPE"].ToString() == "S")
                            {
                                RdIBtn_IndenTypeStockLevel.Checked = true;
                                RdBtn_IndentTypeExtraSpend.Checked = false;
                                btnAddStockCategory.Enabled = true;
                            }
                            else if(dt.Rows[0]["INDENT_TYPE"].ToString() == "E")
                            {
                                RdIBtn_IndenTypeStockLevel.Checked = false;
                                RdBtn_IndentTypeExtraSpend.Checked = true;
                                btnAddStockCategory.Enabled = false;
                            }


                            if (DtIndentDet.Rows.Count > 0)
                            {
                                GvStockIndentDetails.DataSource = DtIndentDet;
                                GvStockIndentDetails.DataBind();
                                GvStockIndentDetails.Enabled = false;
                                
                            }

                            btnSave.Visible = false;
                            btnDelete.Visible = true;
                            Btncalldel.Visible = true;
                            BtncallUpd.Visible = false;
                            ControllerDisable();

                            #endregion

                        }
                    }
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


                        DataSet ds = INDENT_MASLogicLayer.GetAllIDWiseSTOCK_INDENT_ISSUE_BRANCH_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtIndentDet = ds.Tables[1];
                        DataTable DtIndentCat = ds.Tables[2];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            FillFromBranchOnUpdate(dt.Rows[0]["BRANCH_CODE"].ToString());
                            FillToBranchOnUpdate(dt.Rows[0]["TO_BRANCH_CODE"].ToString());
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            TxtIndentNo.Text = dt.Rows[0]["INDNO"].ToString();
                            TxtIndentDate.Text = Convert.ToDateTime(dt.Rows[0]["INDDT"].ToString()).ToString("dd-MM-yyyy");
                            HfPreparedBy.Value = dt.Rows[0]["BCODE"].ToString();
                            FillPreparedByPersonName(dt.Rows[0]["BCODE"].ToString());
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            DdlReceivedFlag.SelectedValue = dt.Rows[0]["REC_FLAG"].ToString();
                            TxtReceivedBy.Text = dt.Rows[0]["REC_USERID"].ToString();
                            TxtReceivedDate.Text = dt.Rows[0]["REC_DATE"].ToString();
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CHK_USERID"].ToString(); ;
                            TxtConfirmDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            DdlClosedFlag.SelectedValue = dt.Rows[0]["CLOSE_FLAG"].ToString();
                            TxtClosedBy.Text = dt.Rows[0]["CLOSE_USERID"].ToString();
                            TxtClosedDate.Text = dt.Rows[0]["CLOSE_DATE"].ToString();

                            if (dt.Rows[0]["INDENT_TYPE"].ToString() == "S")
                            {
                                RdIBtn_IndenTypeStockLevel.Checked = true;
                                RdBtn_IndentTypeExtraSpend.Checked = false;
                                btnAddStockCategory.Enabled = true;
                            }
                            else if (dt.Rows[0]["INDENT_TYPE"].ToString() == "E")
                            {
                                RdIBtn_IndenTypeStockLevel.Checked = false;
                                RdBtn_IndentTypeExtraSpend.Checked = true;
                                btnAddStockCategory.Enabled = true;
                            }

                            if (DtIndentDet.Rows.Count > 0)
                            {
                                GvStockIndentDetails.DataSource = DtIndentDet;
                                GvStockIndentDetails.DataBind();
                                GvStockIndentDetails.Enabled = true;
                                ViewState["CurrentTable"] = DtIndentDet;

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


                        DataSet ds = INDENT_MASLogicLayer.GetAllIDWiseSTOCK_INDENT_ISSUE_BRANCH_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtIndentDet = ds.Tables[1];
                        DataTable DtIndentCat = ds.Tables[2];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            FillFromBranchOnUpdate(dt.Rows[0]["BRANCH_CODE"].ToString());
                            FillToBranchOnUpdate(dt.Rows[0]["TO_BRANCH_CODE"].ToString());
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            TxtIndentNo.Text = dt.Rows[0]["INDNO"].ToString();
                            TxtIndentDate.Text = Convert.ToDateTime(dt.Rows[0]["INDDT"].ToString()).ToString("dd-MM-yyyy");
                            HfPreparedBy.Value = dt.Rows[0]["BCODE"].ToString();
                            FillPreparedByPersonName(dt.Rows[0]["BCODE"].ToString());
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            DdlReceivedFlag.SelectedValue = dt.Rows[0]["REC_FLAG"].ToString();
                            TxtReceivedBy.Text = dt.Rows[0]["REC_USERID"].ToString();
                            TxtReceivedDate.Text = dt.Rows[0]["REC_DATE"].ToString();
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CHK_USERID"].ToString(); ;
                            TxtConfirmDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            DdlClosedFlag.SelectedValue = dt.Rows[0]["CLOSE_FLAG"].ToString();
                            TxtClosedBy.Text = dt.Rows[0]["CLOSE_USERID"].ToString();
                            TxtClosedDate.Text = dt.Rows[0]["CLOSE_DATE"].ToString();

                            if (dt.Rows[0]["INDENT_TYPE"].ToString() == "S")
                            {
                                RdIBtn_IndenTypeStockLevel.Checked = true;
                                RdBtn_IndentTypeExtraSpend.Checked = false;
                                btnAddStockCategory.Enabled = true;
                            }
                            else if (dt.Rows[0]["INDENT_TYPE"].ToString() == "E")
                            {
                                RdIBtn_IndenTypeStockLevel.Checked = false;
                                RdBtn_IndentTypeExtraSpend.Checked = true;
                                btnAddStockCategory.Enabled = false;
                            }

                            if (DtIndentDet.Rows.Count > 0)
                            {
                                GvStockIndentDetails.DataSource = DtIndentDet;
                                GvStockIndentDetails.DataBind();
                                GvStockIndentDetails.Enabled = false;

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

      

        protected void btnDelete_Click(object sender, EventArgs e)
        {


        }

        protected void Btncalldel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region UPDATE STOCK INDENT TO BRANCH

                #region INSERT STOCK INDENT ISSUE TO BRANCH DETAILS

                INDENT_MASLogicLayer insert = new INDENT_MASLogicLayer();

                insert.COMP_CODE = Session["COMP_CODE"].ToString();
                insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.INDDT = Convert.ToDateTime(TxtIndentDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                insert.INDNO = TxtIndentNo.Text.Trim();
                insert.BCODE = HfPreparedBy.Value.Trim();
                insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";
                insert.REC_FLAG = DdlReceivedFlag.SelectedValue.Trim().ToUpper();
                if (DdlReceivedFlag.SelectedValue == "Y")
                {
                    insert.REC_USERID = TxtReceivedBy.Text.Trim().ToUpper();
                }
                else
                {
                    insert.REC_USERID = "";
                }

                if (DdlReceivedFlag.SelectedValue == "Y")
                {
                    insert.REC_DATE = Convert.ToDateTime(TxtReceivedDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.REC_DATE = "";
                }

                insert.ENDT = "";
                insert.STATUS = "";
                insert.CAT_CODE = null;
                if (RdIBtn_IndenTypeStockLevel.Checked == true)
                {
                    insert.INDENT_TYPE = "S";
                }
                else if (RdBtn_IndentTypeExtraSpend.Checked == true)

                {
                    insert.INDENT_TYPE = "E";
                }

                insert.TO_BRANCH_CODE = HfToBranchCode.Value.Trim();
                insert.CHK_FLAG = DdlConfirmFlag.SelectedValue.Trim().ToUpper();
                if (DdlConfirmFlag.SelectedValue == "Y")
                {
                    insert.CHK_USERID = TxtConfirmBy.Text.Trim().ToUpper();
                }
                else
                {
                    insert.CHK_USERID = "";
                }

                if (DdlConfirmFlag.SelectedValue == "Y")
                {
                    insert.CHK_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.CHK_DATE = "";
                }

                insert.CLOSE_FLAG = DdlClosedFlag.SelectedValue.Trim().ToUpper();
                if (DdlClosedFlag.SelectedValue == "Y")
                {
                    insert.CLOSE_USERID = TxtClosedBy.Text.Trim().ToUpper();
                }
                else
                {
                    insert.CLOSE_USERID = "";
                }

                if (DdlClosedFlag.SelectedValue == "Y")
                {
                    insert.CLOSE_DATE = Convert.ToDateTime(TxtClosedDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.CLOSE_DATE = "";
                }

                #endregion

                #region INSERT INDENT DETAILS INTO GRID

                System.Xml.XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);
                int SRNODETAIL = 1;
                foreach (GridViewRow row in GvStockIndentDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        HiddenField HfCategoryCode = row.FindControl("HfCategoryCode") as HiddenField;
                        HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;

                        TextBox TxtStockCategoryName = row.FindControl("TxtStockCategoryName") as TextBox;
                        TextBox TxtProductCode = row.FindControl("TxtProductCode") as TextBox;
                        TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                        TextBox TxtMaxQty = row.FindControl("TxtMaxQty") as TextBox;
                        TextBox TxtMinQty = row.FindControl("TxtMinQty") as TextBox;
                        TextBox TxtStockQty = row.FindControl("TxtStockQty") as TextBox;
                        TextBox TxtOrderQty = row.FindControl("TxtOrderQty") as TextBox;
                        TextBox TxtToBranchStock = row.FindControl("TxtToBranchStock") as TextBox;

                        if (TxtStockCategoryName.Text != string.Empty && TxtStockCategoryName.Text != null)
                        {


                            XmlElement HandleDetail2 = XDoc1.CreateElement("INDENT_DETDetails");
                            HandleDetail2.SetAttribute("SRNO", SRNODETAIL.ToString());
                            HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                            HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                            if (TxtStockCategoryName.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("CAT_CODE", null);
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("CAT_CODE", (HfCategoryCode.Value));
                            }

                            if (TxtProductName.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("SCODE", null);
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value));
                            }

                            if (TxtMaxQty.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("MAX_QTY", null);
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("MAX_QTY", (TxtMaxQty.Text.Trim()));
                            }

                            if (TxtMinQty.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("MIN_QTY", null);
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("MIN_QTY", (TxtMinQty.Text.Trim()));
                            }

                            if (TxtStockQty.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("STK_QTY", null);
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("STK_QTY", (TxtStockQty.Text.Trim()));
                            }

                            if (TxtOrderQty.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("ORD_QTY", null);
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("ORD_QTY", (TxtOrderQty.Text.Trim()));
                            }

                            if (TxtToBranchStock.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("BRSTK_QTY", null);
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("BRSTK_QTY", (TxtToBranchStock.Text.Trim()));
                            }

                            HandleDetail2.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));

                            HandleDetail2.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));

                            HandleDetail2.SetAttribute("INS_DATE", "");

                            HandleDetail2.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));

                            HandleDetail2.SetAttribute("UPD_DATE", "");

                            HandleDetail2.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));

                            root1.AppendChild(HandleDetail2);
                            SRNODETAIL++;
                        }
                    }
                }

                #endregion


                #region INSERT STOCK CATEGORY DETAILS INTO GRID 

                XmlDocument XDoc2 = new XmlDocument();
                XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                XDoc2.AppendChild(dec2);// Create the root element
                XmlElement root2 = XDoc2.CreateElement("root");
                XDoc2.AppendChild(root2);
                int SRNOCAT = 1;

                foreach (GridViewRow row in GvStockIndentDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfCategoryCode = row.FindControl("HfCategoryCode") as HiddenField;
                        TextBox TxtStockCategoryName = row.FindControl("TxtStockCategoryName") as TextBox;


                        XmlElement HandleDetail3 = XDoc2.CreateElement("INDENT_CATDetails");

                        if (TxtStockCategoryName.Text != string.Empty && TxtStockCategoryName.Text != null)
                        {
                            HandleDetail3.SetAttribute("SRNO", SRNOCAT.ToString());
                            HandleDetail3.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                            HandleDetail3.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail3.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                            if (TxtStockCategoryName.Text == string.Empty)
                            {
                                HandleDetail3.SetAttribute("CAT_CODE", null);
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("CAT_CODE", (HfCategoryCode.Value.Trim()));
                            }

                            HandleDetail3.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));

                            HandleDetail3.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));

                            HandleDetail3.SetAttribute("INS_DATE", "");

                            HandleDetail3.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));

                            HandleDetail3.SetAttribute("UPD_DATE", "");

                            HandleDetail3.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));

                            root2.AppendChild(HandleDetail3);
                            SRNOCAT++;


                        }
                    }
                }

                #endregion

                string str = INDENT_MASLogicLayer.UpdateSTOCK_INDENT_ISSUE_TOBRANCH_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"));


                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "STOCK INDENT ISSUE TO BRANCH MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillSTOCK_INDENT_ISSUE_TOBRANCH_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "STOCK INDENT  ISSUE TO BRANCH MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : STOCK INDENT ISSUE TO BRANCH MASTER NOT SAVED";
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
                    try
                    {
                        #region INSERT STOCK INDENT ISSUE TO BRANCH DETAILS

                        INDENT_MASLogicLayer insert = new INDENT_MASLogicLayer();

                        insert.COMP_CODE   = Session["COMP_CODE"].ToString();
                        insert.BRANCH_CODE  = Session["BRANCH_CODE"].ToString();
                        //insert.TRAN_DATE = HfTranDate.Value.Trim();
                        //insert.TRAN_NO = HfTranNo.Value.Trim();
                        insert.INDDT  = Convert.ToDateTime(TxtIndentDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                        insert.INDNO = TxtIndentNo.Text.Trim();
                        insert.BCODE = HfPreparedBy.Value.Trim();
                        insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                        insert.INS_USERID = Session["USERNAME"].ToString();
                        insert.INS_TERMINAL  = Session["PC"].ToString();
                        insert.INS_DATE = "";
                        insert.UPD_USERID = Session["USERNAME"].ToString();
                        insert.UPD_TERMINAL = Session["PC"].ToString();
                        insert.UPD_DATE = "";
                        insert.REC_FLAG = DdlReceivedFlag.SelectedValue.Trim().ToUpper();
                        if(DdlReceivedFlag.SelectedValue == "Y")
                        {
                            insert.REC_USERID = TxtReceivedBy.Text.Trim().ToUpper();
                        }
                        else
                        {
                            insert.REC_USERID = "";
                        }
                         
                        if(DdlReceivedFlag.SelectedValue == "Y")
                        {
                            insert.REC_DATE = Convert.ToDateTime(TxtReceivedDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                        }
                        else
                        {
                            insert.REC_DATE = "";
                        }

                        insert.ENDT = "";
                        insert.STATUS = "";
                        insert.CAT_CODE = null;
                        if(RdIBtn_IndenTypeStockLevel.Checked==true)
                        {
                            insert.INDENT_TYPE = "S";
                        }
                        else if (RdBtn_IndentTypeExtraSpend.Checked == true)

                        {
                            insert.INDENT_TYPE = "E";
                        }
                      
                        insert.TO_BRANCH_CODE = HfToBranchCode.Value.Trim();
                        insert.CHK_FLAG = DdlConfirmFlag.SelectedValue.Trim().ToUpper();
                        if(DdlConfirmFlag.SelectedValue == "Y")
                        {
                            insert.CHK_USERID = TxtConfirmBy.Text.Trim().ToUpper();
                        }
                        else
                        {
                            insert.CHK_USERID = "";
                        }
                       
                        if(DdlConfirmFlag.SelectedValue == "Y")
                        {
                            insert.CHK_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                        }
                        else
                        {
                            insert.CHK_DATE = "";
                        }

                        insert.CLOSE_FLAG = DdlClosedFlag.SelectedValue.Trim().ToUpper();
                        if (DdlClosedFlag.SelectedValue == "Y")
                        {
                            insert.CLOSE_USERID = TxtClosedBy.Text.Trim().ToUpper();
                        }
                        else
                        {
                            insert.CLOSE_USERID = "";
                        }

                        if(DdlClosedFlag.SelectedValue == "Y")
                        {
                            insert.CLOSE_DATE = Convert.ToDateTime(TxtClosedDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                        }
                        else
                        {
                            insert.CLOSE_DATE = "";
                        }

                        #endregion

                        #region INSERT INDENT DETAILS INTO GRID

                        System.Xml.XmlDocument XDoc1 = new XmlDocument();
                        XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                        XDoc1.AppendChild(dec1);// Create the root element
                        XmlElement root1 = XDoc1.CreateElement("root");
                        XDoc1.AppendChild(root1);
                        int SRNODETAIL = 1;
                        foreach (GridViewRow row in GvStockIndentDetails.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {

                                HiddenField HfCategoryCode = row.FindControl("HfCategoryCode") as HiddenField;
                                HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;

                                TextBox TxtStockCategoryName = row.FindControl("TxtStockCategoryName") as TextBox;
                                TextBox TxtProductCode = row.FindControl("TxtProductCode") as TextBox;
                                TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                                TextBox TxtMaxQty = row.FindControl("TxtMaxQty") as TextBox;
                                TextBox TxtMinQty = row.FindControl("TxtMinQty") as TextBox;
                                TextBox TxtStockQty = row.FindControl("TxtStockQty") as TextBox;
                                TextBox TxtOrderQty = row.FindControl("TxtOrderQty") as TextBox;
                                TextBox TxtToBranchStock = row.FindControl("TxtToBranchStock") as TextBox;

                                if (TxtStockCategoryName.Text != string.Empty && TxtStockCategoryName.Text != null)
                                {


                                    XmlElement HandleDetail2 = XDoc1.CreateElement("INDENT_DETDetails");
                                    HandleDetail2.SetAttribute("SRNO", SRNODETAIL.ToString());
                                    HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                    //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                    //HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                    if (TxtStockCategoryName.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("CAT_CODE", null);
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("CAT_CODE", (HfCategoryCode.Value));
                                    }

                                    if (TxtProductName.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("SCODE", null);
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value));
                                    }

                                    if (TxtMaxQty.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("MAX_QTY", null);
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("MAX_QTY", (TxtMaxQty.Text.Trim()));
                                    }

                                    if (TxtMinQty.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("MIN_QTY", null);
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("MIN_QTY", (TxtMinQty.Text.Trim()));
                                    }

                                    if (TxtStockQty.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("STK_QTY", null);
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("STK_QTY", (TxtStockQty.Text.Trim()));
                                    }

                                    if (TxtOrderQty.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("ORD_QTY", null);
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("ORD_QTY", (TxtOrderQty.Text.Trim()));
                                    }

                                    if (TxtToBranchStock.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("BRSTK_QTY", null);
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("BRSTK_QTY", (TxtToBranchStock.Text.Trim()));
                                    }

                                    HandleDetail2.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));

                                    HandleDetail2.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));

                                    HandleDetail2.SetAttribute("INS_DATE", "");

                                    HandleDetail2.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));

                                    HandleDetail2.SetAttribute("UPD_DATE", "");

                                    HandleDetail2.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));

                                    root1.AppendChild(HandleDetail2);
                                    SRNODETAIL++;
                                }
                            }
                        }

                        #endregion


                        #region INSERT STOCK CATEGORY DETAILS INTO GRID 

                        XmlDocument XDoc2 = new XmlDocument();
                        XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                        XDoc2.AppendChild(dec2);// Create the root element
                        XmlElement root2 = XDoc2.CreateElement("root");
                        XDoc2.AppendChild(root2);
                        int SRNOCAT = 1;

                        foreach (GridViewRow row in GvStockIndentDetails.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {
                                HiddenField HfCategoryCode = row.FindControl("HfCategoryCode") as HiddenField;
                                TextBox TxtStockCategoryName = row.FindControl("TxtStockCategoryName") as TextBox;
                             

                                XmlElement HandleDetail3 = XDoc2.CreateElement("INDENT_CATDetails");

                                if (TxtStockCategoryName.Text != string.Empty && TxtStockCategoryName.Text != null)
                                {
                                    HandleDetail3.SetAttribute("SRNO", SRNOCAT.ToString());
                                    HandleDetail3.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                    //    HandleDetail4.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                    //    HandleDetail4.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                    if (TxtStockCategoryName.Text == string.Empty)
                                    {
                                        HandleDetail3.SetAttribute("CAT_CODE", null);
                                    }
                                    else
                                    {
                                        HandleDetail3.SetAttribute("CAT_CODE", (HfCategoryCode.Value.Trim()));
                                    }

                                    HandleDetail3.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));

                                    HandleDetail3.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));

                                    HandleDetail3.SetAttribute("INS_DATE", "");

                                    HandleDetail3.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));

                                    HandleDetail3.SetAttribute("UPD_DATE", "");

                                    HandleDetail3.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));

                                    root2.AppendChild(HandleDetail3);
                                    SRNOCAT++;


                                }
                            }
                        }

                        #endregion

                       string str = INDENT_MASLogicLayer.InsertSTOCK_INDENT_ISSUE_TOBRANCH_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"));

                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "STOCK INDENT ISSUE BRANCH MASTER SAVE SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillSTOCK_INDENT_ISSUE_TOBRANCH_MasterGrid(Session["COMP_CODE"].ToString());
                            UserRights();


                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "STOCK INDENT ISSUE BRANCH MASTER ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : STOCK INDENT ISSUE BRANCH MASTER NOT SAVED";
                            lblmsg.ForeColor = Color.Red;

                        }
                    }

                     
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvStockCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvStockCategory.PageIndex = e.NewPageIndex;
            clear();
            FillStockCategoryForPopupGrid();
        }

        protected void btnAddStockCategory_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelStockCategory", "ShowModelStockCategory()", true);

            //FillStockCategoryForPopupGrid();
            FillOnlyStockCategoryPopup();
        }

        public void FillStockCategoryForPopupGrid()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = STOCKCategory_MASLogicLayer.GetAllSTOCKCategory_MASDetailWiseCompany(Session["COMP_CODE"].ToString());
                GvStockCategory.DataSource = Dt;
                GvStockCategory.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }



        public void FillOnlyStockCategoryPopup()
        {
            try
            {
                DataTable dt = new DataTable();
                if (ViewState["StockCatTemp"] != null)
                {
                    dt = (DataTable)ViewState["BarcodeTemp"];
                }
                else
                {

                    dt.Columns.Add("CAT_NAME", typeof(System.String));
                    dt.Columns.Add("CAT_CODE", typeof(System.String));


                    for (int i = 0; i < 10; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["CAT_NAME"] = "";
                        dr["CAT_CODE"] = "";

                        dt.Rows.Add(dr);
                    }
                }

                GvStockCategory.DataSource = dt;
                GvStockCategory.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void BtnAddRowModelStock_CategoryGrid_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtCurrentTable = new DataTable();
                DataRow dr = null;
                if (ViewState["StockCatTempNew"] != null)
                {
                    dtCurrentTable = (DataTable)ViewState["StockCatTempNew"];
                }
                else
                {
                    dtCurrentTable.Columns.Add("CAT_CODE", typeof(System.String));
                    dtCurrentTable.Columns.Add("CAT_NAME", typeof(System.String));
                    
                    foreach (GridViewRow row in GvStockCategory.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            TextBox TxtStockCategoryNamePopUp = row.FindControl("TxtStockCategoryNamePopUp") as TextBox;
                            HiddenField HfCategoryCodePopUp = row.FindControl("HfCategoryCodePopUp") as HiddenField;

                            if (TxtStockCategoryNamePopUp.Text.Trim() != string.Empty)
                            {
                                dr = dtCurrentTable.NewRow();

                                dr["CAT_NAME"] = TxtStockCategoryNamePopUp.Text.Trim();
                                dr["CAT_CODE"] = HfCategoryCodePopUp.Value.Trim();
                              
                                dtCurrentTable.Rows.Add(dr);
                            }
                        }
                    }
                }





                dr = dtCurrentTable.NewRow();

                dr["CAT_NAME"] = "";
                dr["CAT_CODE"] = "";
              
                dtCurrentTable.Rows.Add(dr);

                ViewState["StockCatTempNew"] = dtCurrentTable;

                GvStockCategory.DataSource = dtCurrentTable;
                GvStockCategory.DataBind();


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnIndentProcess_Click(object sender, EventArgs e)
        {

        }
    }
}