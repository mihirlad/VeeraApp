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
    public partial class PartyStockMaster : System.Web.UI.Page
    {

        public static string compcode;
        static DataTable DtSearch = new DataTable();
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

                if (!Page.IsPostBack)
                {
                    compcode = Session["COMP_CODE"].ToString();
                    //DivEntry.Visible = false;
                    //DivView.Visible = true;
                    // FillDdlAccountName();
                    //FillDdlProductName();
                    //FillGrid();

                    clear();
                    ControllerEnable();
                    UserRights();
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = true;
                    btnSave.Enabled = true;
                    btnSave.Visible = true;
                    DivEntry.Visible = true;
                    DivView.Visible = false;
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

        public void FillDdlAccountName()
        {
            try
            {
                //string Comp_Code = Session["COMP_CODE"].ToString();

                //DataTable Dt = new DataTable();
                //Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
                //DdlAccountName.DataSource = Dt;
                //DdlAccountName.DataValueField = "ACODE";
                //DdlAccountName.DataTextField = "ANAME";
                //DdlAccountName.DataBind();
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
            SqlCommand cmd = new SqlCommand("select * from ACCOUNTS where COMP_CODE=@COMP_CODE  AND ANAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
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
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select ACODE from ACCOUNTS where ANAME = '" + TxtAccountName.Text + "' and COMP_CODE = " + Session["COMP_CODE"].ToString() , con);
                int x = Convert.ToInt32(cmd.ExecuteScalar());
                if (x == 0)
                {
                    TxtAccountName.BackColor = Color.Red;
                }
                else
                {
                    HfACODE.Value = cmd.ExecuteScalar().ToString();
                    TxtAccountName.BackColor = Color.White;

                    con.Close();

                    getAccountGroupName();
                    FillProductDetailsGrid();
                }

              
            }
            catch (Exception)
            {

                throw;
            }
        }



        public void FillProductDetailsGrid()
        {
            try
            {
                DataTable Dt = new DataTable();
                string ACODE = HfACODE.Value;
                Dt = ACCOUNTS_STOCKMASLogicLayer.GetAllACCOUNTS_STOCKMASDetialsForGrid(ACODE, (Session["COMP_CODE"].ToString()), (Session["USERCODE"].ToString()));
                GvPartyStockDetails.DataSource = Dt;
                GvPartyStockDetails.DataBind();
                errorlbl.Text = "";

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlAccountName(string Id)
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(Comp_Code);


                if (HfACODE.Value.ToString() != "0")
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "ACODE=" + Id;
                    DataTable DtView = Dv.ToTable();
                    TxtAccountName.Text = DtView.Rows[0]["ANAME"].ToString();
                    HfACODE.Value = DtView.Rows[0]["ACODE"].ToString();
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
                //DdlProductName.DataSource = Dt;
                //DdlProductName.DataValueField = "SCODE";
                //DdlProductName.DataTextField = "SNAME";
                //DdlProductName.DataBind();

                if (HfDetailSCode.Value.ToString() != "0")
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "SCODE=" + Id;
                    DataTable DtView = Dv.ToTable();
                    TxtProductName.Text = DtView.Rows[0]["SNAME"].ToString();
                    HfDetailSCode.Value = DtView.Rows[0]["SCODE"].ToString();
                    TxtProductCode.Text= DtView.Rows[0]["PROD_CODE"].ToString();
                    //   TxtCategoryName.Text= DtView.Rows[0]["CAT_CODE"].ToString();
                   

                }
            }
            catch (Exception)
            {

                throw;
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



        
        public void ControllerEnable()
        {
            TxtAccountName.Enabled = true;
            TxtGroupName.Enabled = false;
           TxtProductName.Enabled = true;
            TxtProductCode.Enabled = true;
            TxtCategoryName.Enabled = false;
            TxtRate.Enabled = true;
            TxtDiscount.Enabled = true;
            TxtDiscountRate.Enabled = false;
            DdlRank.Enabled = true;
        }

        public void ControllerDisable()
        {
            TxtAccountName.Enabled = false;
            TxtGroupName.Enabled = false;
            TxtProductName.Enabled = false;
            TxtProductCode.Enabled = false;
            TxtCategoryName.Enabled = false;
            TxtRate.Enabled = false;
            TxtDiscount.Enabled = false;
            TxtDiscountRate.Enabled = false;
            DdlRank.Enabled = false;
        }


        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfCompCode.Value = string.Empty;
            //HfAccountcode.Value = string.Empty;
            //HfStockCode.Value = string.Empty;
            TxtAccountName.Text = string.Empty;
            TxtGroupName.Text = string.Empty;
            TxtProductName.Text = string.Empty;
            TxtProductCode.Text = string.Empty;
            TxtCategoryName.Text = string.Empty;
            TxtRate.Text = string.Empty;
            TxtDiscount.Text = string.Empty;
            TxtDiscountRate.Text = string.Empty;
            DdlRank.SelectedIndex = 0;

            BtncallUpd.Text = "SAVE";

        }

        public void clearNotALL()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfCompCode.Value = string.Empty;
            //HfAccountcode.Value = string.Empty;
            //HfStockCode.Value = string.Empty;
            //TxtAccountName.Text = string.Empty;
            //TxtGroupName.Text = string.Empty;
            TxtProductName.Text = string.Empty;
            TxtProductCode.Text = string.Empty;
            TxtCategoryName.Text = string.Empty;
            TxtRate.Text = string.Empty;
            TxtDiscount.Text = string.Empty;
            TxtDiscountRate.Text = string.Empty;
            DdlRank.SelectedIndex = 0;

            BtncallUpd.Text = "SAVE";

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //clear();
            //ControllerEnable();
            //lblmsg.Text = string.Empty;
            //UserRights();
            //Btncalldel.Visible = false;
            //BtncallUpd.Visible = true;
            //btnSave.Enabled = true;
            //btnSave.Visible = true;
            //DivEntry.Visible = true;
            //DivView.Visible = false;
            //GvPartyStockDetails.DataSource = null;
            //GvPartyStockDetails.DataBind();

            Response.Redirect("~/Admin/Dashboard.aspx");
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
                #region INSERT PARTY STOCK MASTER

                ACCOUNTS_STOCKMASLogicLayer insert = new ACCOUNTS_STOCKMASLogicLayer();

                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.ACODE = HfACODE.Value.Trim();
                insert.SCODE = HfDetailSCode.Value.Trim();

                if (TxtDiscount.Text == string.Empty)
                {
                    insert.DIS_PER = "0";
                }
                else
                {
                    insert.DIS_PER = TxtDiscount.Text.Trim();
                }

                if (TxtRate.Text == string.Empty)
                {
                    insert.RATE = "0";
                }
                else
                {
                    insert.RATE = TxtRate.Text.Trim();
                }

                if (TxtDiscountRate.Text == string.Empty)
                {
                    insert.DIS_RATE = "0";
                }
                else
                {
                    insert.DIS_RATE = TxtDiscountRate.Text.Trim();
                }

                insert.RANK = DdlRank.SelectedValue.Trim().ToUpper();
                insert.ACTIVE = "";
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";
                #endregion

                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = ACCOUNTS_STOCKMASLogicLayer.InsertACCOUNTS_STOCKMASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        clearNotALL();
                        ControllerEnable();
                        UserRights();
                        Btncalldel.Visible = false;
                        BtncallUpd.Visible = true;
                        btnSave.Enabled = true;
                        btnSave.Visible = true;
                        DivEntry.Visible = true;
                        DivView.Visible = false;
                        FillProductDetailsGrid();
                        lblmsg.Text = "PARTY STOCK MASTER  DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "PARTY STOCK MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : PARTY STOCK MASTER DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    string str = ACCOUNTS_STOCKMASLogicLayer.UpdateACCOUNTS_STOCKMASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        clearNotALL();
                        ControllerEnable();
                        UserRights();
                        Btncalldel.Visible = false;
                        BtncallUpd.Visible = true;
                        btnSave.Enabled = true;
                        btnSave.Visible = true;
                        DivEntry.Visible = true;
                        DivView.Visible = false;
                        FillProductDetailsGrid();
                        lblmsg.Text = "PARTY STOCK MASTER  DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "PARTY STOCK MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : PARTY STOCK MASTER DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvPartyStockMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                try
                {
                    GvPartyStockMaster.PageIndex = e.NewPageIndex;
                    clear();
                    FillGrid(Session["COMP_CODE"].ToString());
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvPartyStockMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                //if (e.CommandName == "Deletea")
                //{
                //    #region DELETE
                //    clear();
                //    int id = int.Parse(e.CommandArgument.ToString());

                //    Control ctrl = e.CommandSource as Control;
                //    if (ctrl != null)
                //    {
                //        GridViewRow gvRow = ctrl.Parent.NamingContainer as GridViewRow;

                //        //GridViewRow row = GvPartyStockMaster.Rows[id];

                //        HiddenField HfAccountCodeGrid = (HiddenField)gvRow.FindControl("HfAccountCodeGrid");
                //        HiddenField HfStockCodeGrid = (HiddenField)gvRow.FindControl("HfStockCodeGrid");

                //        DataTable dt = ACCOUNTS_STOCKMASLogicLayer.GetAllIDWiseACCOUNTS_STOCKMASDetials(e.CommandArgument.ToString(), HfAccountCodeGrid.Value, HfStockCodeGrid.Value);
                //        if (dt.Rows.Count > 0)
                //        {
                //            DivEntry.Visible = true;
                //            DivView.Visible = false;

                //            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                //            FillDdlAccountName(dt.Rows[0]["ACODE"].ToString());
                //            getAccountGroupName();
                //            DdlProductName.SelectedValue = dt.Rows[0]["SCODE"].ToString();
                //            //  getProductCode();
                //            getCategoryName();
                //            TxtRate.Text = dt.Rows[0]["RATE"].ToString();
                //            TxtDiscount.Text = dt.Rows[0]["DIS_PER"].ToString();
                //            TxtDiscountRate.Text = dt.Rows[0]["DIS_RATE"].ToString();
                //            DdlRank.SelectedValue = dt.Rows[0]["RANK"].ToString();



                //        }

                //        btnSave.Visible = false;
                //        btnDelete.Visible = true;
                //        Btncalldel.Visible = true;
                //        BtncallUpd.Visible = false;
                //        ControllerDisable();

                //        #endregion
                //    }
                //}

                //if (e.CommandName == "Edita")
                //{
                //    #region Edit
                //    clear();
                //    int id1 = int.Parse(e.CommandArgument.ToString());

                //    Control ctrl1 = e.CommandSource as Control;
                //    if (ctrl1 != null)
                //    {
                //        GridViewRow gvRow = ctrl1.Parent.NamingContainer as GridViewRow;

                //        //GridViewRow row = GvPartyStockMaster.Rows[id];

                //        HiddenField HfAccountCodeGrid = (HiddenField)gvRow.FindControl("HfAccountCodeGrid");
                //        HiddenField HfStockCodeGrid = (HiddenField)gvRow.FindControl("HfStockCodeGrid");

                //        DataTable dt = ACCOUNTS_STOCKMASLogicLayer.GetAllIDWiseACCOUNTS_STOCKMASDetials(e.CommandArgument.ToString(), HfAccountCodeGrid.Value, HfStockCodeGrid.Value);
                //        if (dt.Rows.Count > 0)
                //        {
                //            DivEntry.Visible = true;
                //            DivView.Visible = false;

                //            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                //            FillDdlAccountName(dt.Rows[0]["ACODE"].ToString());
                //            getAccountGroupName();
                //            DdlProductName.SelectedValue = dt.Rows[0]["SCODE"].ToString();
                //            //    getProductCode();
                //            getCategoryName();
                //            TxtRate.Text = dt.Rows[0]["RATE"].ToString();
                //            TxtDiscount.Text = dt.Rows[0]["DIS_PER"].ToString();
                //            TxtDiscountRate.Text = dt.Rows[0]["DIS_RATE"].ToString();
                //            DdlRank.SelectedValue = dt.Rows[0]["RANK"].ToString();


                //            BtncallUpd.Text = "UPDATE";

                //            #endregion

                //        }
                //    }
                //    #region CHECK UPDATE RIGHTS
                //    if (Session["UPDATE"] != null)
                //    {
                //        if (Session["UPDATE"].ToString() == "Y")
                //        {
                //            ControllerEnable();
                //        }
                //        else
                //        {
                //            ControllerDisable();
                //        }
                //    }
                //    #endregion
                //    Btncalldel.Visible = false;
                //    BtncallUpd.Visible = true;
                //    btnSave.Visible = true;
                //    UserRights();
                //}

                //if (e.CommandName == "Viewa")
                //{
                //    #region SET TEXT ON VIEW
                //    clear();
                //    int id2 = int.Parse(e.CommandArgument.ToString());

                //    Control ctrl2 = e.CommandSource as Control;
                //    if (ctrl2 != null)
                //    {
                //        GridViewRow gvRow = ctrl2.Parent.NamingContainer as GridViewRow;

                //        //GridViewRow row = GvPartyStockMaster.Rows[id];

                //        HiddenField HfAccountCodeGrid = (HiddenField)gvRow.FindControl("HfAccountCodeGrid");
                //        HiddenField HfStockCodeGrid = (HiddenField)gvRow.FindControl("HfStockCodeGrid");

                //        DataTable dt = ACCOUNTS_STOCKMASLogicLayer.GetAllIDWiseACCOUNTS_STOCKMASDetials(e.CommandArgument.ToString(), HfAccountCodeGrid.Value, HfStockCodeGrid.Value);
                //        if (dt.Rows.Count > 0)
                //        {
                //            DivEntry.Visible = true;
                //            DivView.Visible = false;

                //            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                //            FillDdlAccountName(dt.Rows[0]["ACODE"].ToString());
                //            getAccountGroupName();
                //            DdlProductName.SelectedValue = dt.Rows[0]["SCODE"].ToString();
                //            //      getProductCode();
                //            getCategoryName();
                //            TxtRate.Text = dt.Rows[0]["RATE"].ToString();
                //            TxtDiscount.Text = dt.Rows[0]["DIS_PER"].ToString();
                //            TxtDiscountRate.Text = dt.Rows[0]["DIS_RATE"].ToString();
                //            DdlRank.SelectedValue = dt.Rows[0]["RANK"].ToString();

                //            #endregion

                //        }
                //        ControllerDisable();
                //        btnSave.Visible = false;
                //        Btncalldel.Visible = false;
                //        BtncallUpd.Visible = false;
                //        UserRights();
                //    }
                //}
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

                Dt = ACCOUNTS_STOCKMASLogicLayer.GetAllACCOUNTS_STOCKMASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvPartyStockMaster.DataSource = Dv.ToTable();
                GvPartyStockMaster.DataBind();
                DtSearch = Dt;
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
                    #region INSERT PARTY STOCK MASTER

                    ACCOUNTS_STOCKMASLogicLayer insert = new ACCOUNTS_STOCKMASLogicLayer();

                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.ACODE = HfACODE.Value.Trim();
                    insert.SCODE = HfDetailSCode.Value.Trim();

                    if (TxtDiscount.Text == string.Empty)
                    {
                        insert.DIS_PER = "0";
                    }
                    else
                    {
                        insert.DIS_PER = TxtDiscount.Text.Trim();
                    }

                    if (TxtRate.Text == string.Empty)
                    {
                        insert.RATE = "0";
                    }
                    else
                    {
                        insert.RATE = TxtRate.Text.Trim();
                    }

                    if (TxtDiscountRate.Text == string.Empty)
                    {
                        insert.DIS_RATE = "0";
                    }
                    else
                    {
                        insert.DIS_RATE = TxtDiscountRate.Text.Trim();
                    }

                    insert.RANK = DdlRank.SelectedValue.Trim().ToUpper();
                    insert.ACTIVE = "";
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";
                    #endregion

                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = ACCOUNTS_STOCKMASLogicLayer.InsertACCOUNTS_STOCKMASDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            clearNotALL();
                            ControllerEnable();
                            UserRights();
                            Btncalldel.Visible = false;
                            BtncallUpd.Visible = true;
                            btnSave.Enabled = true;
                            btnSave.Visible = true;
                            DivEntry.Visible = true;
                            DivView.Visible = false;
                            FillProductDetailsGrid();
                            lblmsg.Text = "PARTY STOCK MASTER  DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            
                           
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "PARTY STOCK MASTER ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : PARTY STOCK MASTER DETAIL NOT SAVED";
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
            try
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE 
                string ACODE = HfACODE.Value;
                string SCODE = HfDetailSCode.Value;
                if (HfCompCode.Value != string.Empty && ACODE.ToString() != string.Empty && SCODE.ToString() != string.Empty)
                {
                    string str = ACCOUNTS_STOCKMASLogicLayer.DeleteACCOUNTS_STOCKMASDetailsByID(HfCompCode.Value, HfACODE.Value, HfDetailSCode.Value);
                    if (str.Contains("successfully"))
                    {
                        clearNotALL();
                        ControllerEnable();
                        UserRights();
                        Btncalldel.Visible = false;
                        BtncallUpd.Visible = true;
                        btnSave.Enabled = true;
                        btnSave.Visible = true;
                        DivEntry.Visible = true;
                        DivView.Visible = false;
                        FillProductDetailsGrid();
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
                        lblmsg.Text = "Error:PARTY STOCK MASTER Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                  
                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlAccountName_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAccountGroupName();
        }


        public void getAccountGroupName()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select G.GROUP_NAME from ACCOUNTS A INNER JOIN GROUP_MAS G ON A.GROUP_CODE= G.GROUP_CODE where ANAME= '" + TxtAccountName.Text.ToString() + "'", con);
                TxtGroupName.Text = cmd.ExecuteScalar().ToString();
                TxtGroupName.Enabled = false;
                con.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void getProductRate()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select SAL_RATE  from STOCK_RATEMAS  where SCODE= '" + HfDetailSCode.Value.ToString() + "'", con);
                TxtRate.Text = cmd.ExecuteScalar().ToString();
              
                con.Close();



            }
            catch (Exception)
            {

                throw;
            }
        }



        //public void getProductCode()
        //{
        //    try
        //    {
        //        System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        //        con.Open();
        //        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select PROD_CODE from STOCK_MAS  where SNAME= '" + DdlProductName.SelectedItem.ToString() + "'", con);
        //        TxtProductCode.Text = cmd.ExecuteScalar().ToString();
        //        TxtProductCode.Enabled = false;
        //        con.Close();



        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        public void getProductName()
        {
            //try
            //{
            //    System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            //    con.Open();
            //    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select SM.SCODE from STOCK_MAS SM INNER JOIN ACCOUNTS_STOCKMAS ASM ON ASM.SCODE= SM.SCODE where  SM.Prod_Code= '" + TxtProductCode.Text.ToString() + "'", con);
            //    DdlProductName.SelectedValue = cmd.ExecuteScalar().ToString();
            //    DdlProductName.Enabled = false;
            //    con.Close();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }


        public void getCategoryName()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select SC.CAT_NAME from STOCK_CATAGORY SC INNER JOIN STOCK_MAS SM ON SM.CAT_CODE= SC.CAT_CODE where  SM.SCODE= '" + HfDetailSCode.Value.ToString() + "'", con);
                TxtCategoryName.Text = cmd.ExecuteScalar().ToString();
                TxtCategoryName.Enabled = false;
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   getProductCode();
           
        }

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtSearch.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtSearch);
                    Dv.RowFilter = "ProductName LIKE '%" + TxtSearch.Text.Trim() + "%' OR ProductCode like '%" + TxtSearch.Text.Trim() + "%' OR AccountName like '%" + TxtSearch.Text.Trim() + "%' OR CategoryName like '%" + TxtSearch.Text.Trim() + "%' ";
                    GvPartyStockMaster.DataSource = Dv.ToTable();
                    GvPartyStockMaster.DataBind();
                }
                else
                {
                    GvPartyStockMaster.DataSource = DtSearch;
                    GvPartyStockMaster.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    

        protected void GvPartyStockDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvPartyStockDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edita")
                {
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

                    #region Edit
                    clear();
                    int id1 = int.Parse(e.CommandArgument.ToString());

                    Control ctrl1 = e.CommandSource as Control;
                    if (ctrl1 != null)
                    {
                        GridViewRow gvRow = ctrl1.Parent.NamingContainer as GridViewRow;

                        //GridViewRow row = GvPartyStockMaster.Rows[id];

                        HiddenField HfAccountCodeGrid = (HiddenField)gvRow.FindControl("HfAccountCodeGrid");
                        HiddenField HfStockCodeGrid = (HiddenField)gvRow.FindControl("HfStockCodeGrid");

                        DataTable dt = ACCOUNTS_STOCKMASLogicLayer.GetAllIDWiseACCOUNTS_STOCKMASDetials(e.CommandArgument.ToString(), HfAccountCodeGrid.Value, HfStockCodeGrid.Value);
                        if (dt.Rows.Count > 0)
                        {
                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            FillDdlAccountName(dt.Rows[0]["ACODE"].ToString());
                            TxtAccountName.Enabled = false;
                            getAccountGroupName();
                            FillTxtProductNameOnUpdate(dt.Rows[0]["SCODE"].ToString());
                            //   getProductCode();
                             getCategoryName();
                            TxtRate.Text = dt.Rows[0]["RATE"].ToString();
                            TxtDiscount.Text = dt.Rows[0]["DIS_PER"].ToString();
                            TxtDiscountRate.Text = dt.Rows[0]["DIS_RATE"].ToString();
                            DdlRank.SelectedValue = dt.Rows[0]["RANK"].ToString();


                            BtncallUpd.Text = "UPDATE";



                        }
                    }

                    #endregion


                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = true;
                    btnSave.Visible = true;
                    UserRights();
                    DivEntry.Visible = true;
                    
                }


                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow gvRow = ctrl.Parent.NamingContainer as GridViewRow;

                        //GridViewRow row = GvPartyStockMaster.Rows[id];

                        HiddenField HfAccountCodeGrid = (HiddenField)gvRow.FindControl("HfAccountCodeGrid");
                        HiddenField HfStockCodeGrid = (HiddenField)gvRow.FindControl("HfStockCodeGrid");

                        DataTable dt = ACCOUNTS_STOCKMASLogicLayer.GetAllIDWiseACCOUNTS_STOCKMASDetials(e.CommandArgument.ToString(), HfAccountCodeGrid.Value, HfStockCodeGrid.Value);
                        if (dt.Rows.Count > 0)
                        {
                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            FillDdlAccountName(dt.Rows[0]["ACODE"].ToString());
                            getAccountGroupName();
                            FillTxtProductNameOnUpdate(dt.Rows[0]["SCODE"].ToString());
                      //      getProductCode();
                            getCategoryName();
                            TxtRate.Text = dt.Rows[0]["RATE"].ToString();
                            TxtDiscount.Text = dt.Rows[0]["DIS_PER"].ToString();
                            TxtDiscountRate.Text = dt.Rows[0]["DIS_RATE"].ToString();
                            DdlRank.SelectedValue = dt.Rows[0]["RANK"].ToString();



                        }

                        btnSave.Visible = false;
                        btnDelete.Visible = true;
                        Btncalldel.Visible = true;
                        BtncallUpd.Visible = false;
                        ControllerDisable();
                        DivEntry.Visible = true;

                        #endregion
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(TxtDiscount.Text==string.Empty)
                {
                    TxtDiscount.Text = "0";
                }
                else
                {
                    TxtDiscountRate.Text = ((Convert.ToDouble(TxtRate.Text) * Convert.ToDouble(TxtDiscount.Text)) / 100).ToString();
                }
              
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtProductCode_TextChanged(object sender, EventArgs e)
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
                getCategoryName();
                getProductRate();
            }
        }

        protected void TxtProductName_TextChanged(object sender, EventArgs e)
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
                getCategoryName();
                getProductRate();
            }
        }
  }
}
