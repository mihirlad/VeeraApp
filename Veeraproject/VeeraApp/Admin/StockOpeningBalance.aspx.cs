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

namespace VeeraApp
{
    public partial class StockOpeningBalance : System.Web.UI.Page
    {
        public static string compcode;
        static DataTable DtSearch = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            compcode = Session["COMP_CODE"].ToString();
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

                if (!Page.IsPostBack)
            {
                DivEntry.Visible = false;
                DivView.Visible = true;
                FillDdlProductName();
                FillGrid(Session["COMP_CODE"].ToString());
            }
        }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }


        public void FillDdlProductName()
        {
            try
            {
                //DataTable Dt = new DataTable();
                //Dt = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsFor_DDL();
                //DdlProductNameDesc.DataSource = Dt;
                //DdlProductNameDesc.DataValueField = "SCODE";
                //DdlProductNameDesc.DataTextField = "SNAME";
                //DdlProductNameDesc.DataBind();
            }
            catch (Exception)
            {

                throw;
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
                        HfDetailSCode.Value = DtView.Rows[0]["SCODE"].ToString();
                        TxtProductName.Text = DtView.Rows[0]["SNAME"].ToString();
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
                        HfDetailSCode.Value = DtView.Rows[0]["SCODE"].ToString();
                        TxtProductCode.Text = DtView.Rows[0]["PROD_CODE"].ToString();

                    }

                }


            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillTxtProductNameOnUpdate(string Id)
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);


                if (HfDetailSCode.Value.ToString() != "0")
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "SCODE=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtProductName.Text = DtView.Rows[0]["SNAME"].ToString();
                    HfDetailSCode.Value = DtView.Rows[0]["SCODE"].ToString();
                    TxtProductCode.Text = DtView.Rows[0]["PROD_CODE"].ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ControllerEnable()
        {
            TxtTranDate.Enabled = true;
        //    TxtSrNo.Enabled = true;
            TxtProductCode.Enabled = true;
            TxtProductName.Enabled = true;
            TxtQuantity.Enabled = true;
            TxtAmount.Enabled = false;
            TxtRate.Enabled = true;
        }

        public void ControllerDisable()
        {
            TxtTranDate.Enabled = false;
            //  TxtSrNo.Enabled = false;
            TxtProductCode.Enabled = false;
            TxtProductName.Enabled = false;
            TxtQuantity.Enabled = false;
            TxtAmount.Enabled = false;
            TxtRate.Enabled = false;
        }

        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfTransDate.Value = string.Empty;
            HfTransNo.Value = string.Empty;
            HfCompCode.Value = string.Empty;
            HfBranchCode.Value = string.Empty;
            HfYearDate1.Value = string.Empty;
            TxtTranDate.Text = string.Empty;
            //    TxtSrNo.Text = string.Empty;
            TxtProductCode.Text = string.Empty;
            TxtProductName.Text = string.Empty;
            TxtQuantity.Text = string.Empty;
            TxtAmount.Text = string.Empty;
            TxtRate.Text = string.Empty;

            BtncallUpd.Text = "SAVE";

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

                TxtTranDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region INSERT OPENING STOCK MASTER

                OP_STOCK_BALLogicLayer insert = new OP_STOCK_BALLogicLayer();
                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.BRANCH_CODE = HfBranchCode.Value.Trim();
                insert.TRAN_DATE = Convert.ToDateTime(HfTransDate.Value.Trim().ToString()).ToString("MM-dd-yyyy"); //HfTransDate.Value.Trim();
                insert.TRAN_NO = HfTransNo.Value.Trim();
                insert.YRDT1 = Convert.ToDateTime(HfYearDate1.Value.Trim()).ToString("yyyy-MM-dd");
                insert.TRNDT = Convert.ToDateTime(TxtTranDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");//TxtTranDate.Text.Trim();
                insert.SRNO = HfSrNo.Value.Trim();
                insert.SCODE = HfDetailSCode.Value.Trim().ToUpper();

                if (TxtQuantity.Text == string.Empty)
                {
                    insert.QTY = "0";
                }
                else
                {
                    insert.QTY = TxtQuantity.Text.Trim();
                }

                if (TxtRate.Text == string.Empty)
                {
                    insert.RATE = "0";
                }
                else
                {
                    insert.RATE = TxtRate.Text.Trim();
                }

                if (TxtAmount.Text == string.Empty)
                {
                    insert.AMT = "0";
                }
                else
                {
                    insert.AMT = TxtAmount.Text.Trim();
                }

                insert.REMARK = "";
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";

                #endregion


                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = OP_STOCK_BALLogicLayer.InsertSTOCK_OP_BALDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "STOCK OPENING BALANCE DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(Session["COMP_CODE"].ToString());
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "STOCK OPENING BALANCE MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : STOCK OPENING BALANCE DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {

                    string str = OP_STOCK_BALLogicLayer.UpdateBRAND_COMPLAIN_MASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "STOCK OPENING BALANCE DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(Session["COMP_CODE"].ToString());
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "STOCK OPENING BALANCE MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : STOCK OPENING BALANCE DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStocktOpeningBalance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvStocktOpeningBalance.PageIndex = e.NewPageIndex;
                clear();
                FillGrid(Session["COMP_CODE"].ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStocktOpeningBalance_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    GridViewRow row = GvStocktOpeningBalance.Rows[id];

                    HiddenField HfTranDateGrid = (row.FindControl("HfTransDateGrid")) as HiddenField;

                    DataTable dt = OP_STOCK_BALLogicLayer.GetAllIDWiseSTOCK_OP_BALDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                        HfYearDate1.Value = dt.Rows[0]["YRDT1"].ToString();
                        HfTransDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                        HfTransNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                        HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        TxtTranDate.Text = Convert.ToDateTime(dt.Rows[0]["TRNDT"].ToString()).ToString("dd-MM-yyyy");
                        TxtQuantity.Text = dt.Rows[0]["QTY"].ToString();
                        TxtRate.Text = dt.Rows[0]["RATE"].ToString();
                        TxtAmount.Text = dt.Rows[0]["AMT"].ToString();
                     //   HfDetailSCode.Value = dt.Rows[0]["SCODE"].ToString();
                        FillTxtProductNameOnUpdate(dt.Rows[0]["SCODE"].ToString());

                    }

                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    Btncalldel.Visible = true;
                    BtncallUpd.Visible = false;
                    ControllerDisable();

                    #endregion
                }

                if (e.CommandName == "Edita")
                {
                    #region Edit
                    clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    GridViewRow row = GvStocktOpeningBalance.Rows[id];

                    HiddenField HfTranDateGrid = (row.FindControl("HfTransDateGrid")) as HiddenField;

                    DataTable dt = OP_STOCK_BALLogicLayer.GetAllIDWiseSTOCK_OP_BALDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                        HfYearDate1.Value = dt.Rows[0]["YRDT1"].ToString();
                        HfTransDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                        HfTransNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                        HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        TxtTranDate.Text = Convert.ToDateTime(dt.Rows[0]["TRNDT"].ToString()).ToString("dd-MM-yyyy");
                        TxtQuantity.Text = dt.Rows[0]["QTY"].ToString();
                        TxtRate.Text = dt.Rows[0]["RATE"].ToString();
                        TxtAmount.Text = dt.Rows[0]["AMT"].ToString();
                   //     HfDetailSCode.Value = dt.Rows[0]["SCODE"].ToString();
                        FillTxtProductNameOnUpdate(dt.Rows[0]["SCODE"].ToString());

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
                    clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    GridViewRow row = GvStocktOpeningBalance.Rows[id];

                    HiddenField HfTranDateGrid = (row.FindControl("HfTransDateGrid")) as HiddenField;

                    DataTable dt = OP_STOCK_BALLogicLayer.GetAllIDWiseSTOCK_OP_BALDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                        HfYearDate1.Value = dt.Rows[0]["YRDT1"].ToString();
                        HfTransDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                        HfTransNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                        HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        TxtTranDate.Text = Convert.ToDateTime(dt.Rows[0]["TRNDT"].ToString()).ToString("dd-MM-yyyy");
                        TxtQuantity.Text = dt.Rows[0]["QTY"].ToString();
                        TxtRate.Text = dt.Rows[0]["RATE"].ToString();
                        TxtAmount.Text = dt.Rows[0]["AMT"].ToString();
                        //     HfDetailSCode.Value = dt.Rows[0]["SCODE"].ToString();
                        FillTxtProductNameOnUpdate(dt.Rows[0]["SCODE"].ToString());


                        #endregion
                    }

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

        public void FillGrid(string CompCode)
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = OP_STOCK_BALLogicLayer.GetAllSTOCK_OP_BALDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvStocktOpeningBalance.DataSource = Dv.ToTable();
                GvStocktOpeningBalance.DataBind();
                DtSearch = Dv.ToTable();
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
                   
                    OP_STOCK_BALLogicLayer insert = new OP_STOCK_BALLogicLayer();

                    insert.COMP_CODE= Session["COMP_CODE"].ToString();
                    insert.BRANCH_CODE= Session["BRANCH_CODE"].ToString();
                //  insert.TRAN_DATE = Convert.ToDateTime(TxtTranDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy"); //HfTransDate.Value.Trim();
                 //   insert.TRAN_NO = HfTransNo.Value.Trim();
                    insert.YRDT1= Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd");
                    insert.TRNDT = Convert.ToDateTime(TxtTranDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");//TxtTranDate.Text.Trim();
                    insert.SRNO = HfSrNo.Value.Trim();
                    insert.SCODE = HfDetailSCode.Value.Trim().ToUpper();
                    
                     if (TxtQuantity.Text == string.Empty)
                    {
                        insert.QTY = "0";
                    }
                    else
                    {
                        insert.QTY = TxtQuantity.Text.Trim();
                    }

                    if (TxtRate.Text == string.Empty)
                    {
                        insert.RATE = "0";
                    }
                    else
                    {
                        insert.RATE = TxtRate.Text.Trim();
                    }

                    if (TxtAmount.Text == string.Empty)
                    {
                        insert.AMT = "0";
                    }
                    else
                    {
                        insert.AMT = TxtAmount.Text.Trim();
                    }

                    insert.REMARK = "";
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";

                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = OP_STOCK_BALLogicLayer.InsertSTOCK_OP_BALDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "STOCK OPENING BALANCE DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid(Session["COMP_CODE"].ToString());
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "STOCK OPENING BALANCE MASTER ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : STOCK OPENING BALANCE DETAIL NOT SAVED";
                            lblmsg.ForeColor = Color.Red;
                        }
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
                if (HfTransNo.Value != string.Empty && HfTransDate.Value != string.Empty)
                {
                    string str = OP_STOCK_BALLogicLayer.DeleteSTOCK_OP_BALDetailsByID(HfTransNo.Value, Convert.ToDateTime(HfTransDate.Value.ToString()));
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
                        lblmsg.Text = "Error:STOCK OPENING BALANCE Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillGrid(Session["COMP_CODE"].ToString());
                    UserRights();

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
                if(TxtSearch.Text!=string.Empty)
                {
                    DataView Dv = new DataView(DtSearch);
                    Dv.RowFilter = "ProductName LIKE '%" + TxtSearch.Text.Trim() + "%' OR PROD_CODE like '%" + TxtSearch.Text.Trim() + "%' OR Convert(SRNO,'System.String') like '%" + TxtSearch.Text.Trim() + "%' ";
                    GvStocktOpeningBalance.DataSource = Dv.ToTable();
                    GvStocktOpeningBalance.DataBind();
                }
                else
                {
                    GvStocktOpeningBalance.DataSource = DtSearch;
                    GvStocktOpeningBalance.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtRate_TextChanged(object sender, EventArgs e)
        {
            TxtAmount.Text = (Convert.ToDouble(TxtQuantity.Text) * Convert.ToDouble(TxtRate.Text)).ToString();
        }




    }
}