using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;
using MihirValid;

namespace VeeraApp
{
    public partial class StockMaster : System.Web.UI.Page
    {
        static DataTable DtSearch = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERCODE"] != null &&
            Session["USERNAME"] != null &&
            Session["USERTYPE"] != null &&
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
                    FillGrid(Session["COMP_CODE"].ToString());
                    FillDdlUOM();
                    FillDdlCategoryName();


                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }


        //public void FillDdlBranch()
        //{
        //    try
        //    {
        //        DataTable Dt = new DataTable();
        //        HfCompCode.Value = Session["COMP_CODE"].ToString();
        //        string COMPANYCODE = HfCompCode.Value;

        //        Dt = BRANCH_MASLogicLayer.GetBranchDetailCompanyWiseFor_Ddl(COMPANYCODE);
        //        GvBranchStock.DataSource = Dt;
        //        GvBranchStock.DataValueField = "BRANCH_CODE";
        //        GvBranchStock.DataTextField = "BRANCH_NAME";
        //        GvBranchStock.DataBind();


        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        public void FillBranchGrid()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = STOCK_BALLogicLayer.GetAllSTOCK_BALDetailByCompany((Session["COMP_CODE"].ToString()));
                GvBranchStock.DataSource = Dt;
                GvBranchStock.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillMaxProductCode()
        {
            try
            {
                string GetId;
                GetId = STOCK_MASLogicLayer.GetMaxProductCodeFromStaockMaster();

                TxtProductCode.Text = GetId;

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
        public void ControllerEnable()
        {
            TxtProductCode.Enabled = false;
            TxtProductName.Enabled = true;
            TxtPartNo.Enabled = true;
            TxtHsnCode.Enabled = true;
            DdlUOM.Enabled = true;
            DdlCategoryName.Enabled = true;
            TxtMaxQty.Enabled = true;
            TxtMinQty.Enabled = true;
            TxtOrderQty.Enabled = true;
            TxtProductDesription.Enabled = true;
            DdlStockActive.Enabled = true;
            TxtPurchaseRate.Enabled = true;
            TxtSalesRate.Enabled = true;
            TxtVat.Enabled = true;
            TxtAddVat.Enabled = true;
            TxtCstVat.Enabled = true;
            TxtCstFullVat.Enabled = true;
            TxtGST.Enabled = true;
            TxtCGST.Enabled = true;
            TxtSGST.Enabled = true;
            TxtIGST.Enabled = true;
        }


        public void ControllerDisable()
        {
            TxtProductCode.Enabled = false;
            TxtProductName.Enabled = false;
            TxtPartNo.Enabled = false;
            TxtHsnCode.Enabled = false;
            DdlUOM.Enabled = false;
            DdlCategoryName.Enabled = false;
            TxtMaxQty.Enabled = false;
            TxtMinQty.Enabled = false;
            TxtOrderQty.Enabled = false;
            TxtProductDesription.Enabled = false;
            DdlStockActive.Enabled = false;
            TxtPurchaseRate.Enabled = false;
            TxtSalesRate.Enabled = false;
            TxtVat.Enabled = false;
            TxtAddVat.Enabled = false;
            TxtCstVat.Enabled = false;
            TxtCstFullVat.Enabled = false;
            TxtGST.Enabled = false;
            TxtCGST.Enabled = false;
            TxtSGST.Enabled = false;
            TxtIGST.Enabled = false;
        }
        public void clear()
        {

            DivEntry.Visible = false;
            DivView.Visible = true;

            HfStockCode.Value = string.Empty;
            HfCompCode.Value = string.Empty;
            HfYearDate1.Value = string.Empty;
            TxtProductCode.Text = string.Empty;
            TxtPartNo.Text = string.Empty;
            TxtProductName.Text = string.Empty;
            TxtHsnCode.Text = string.Empty;
            DdlUOM.SelectedItem.Text = string.Empty;
            DdlCategoryName.SelectedIndex = 0;
            TxtMaxQty.Text = string.Empty;
            TxtMinQty.Text = string.Empty;
            TxtOrderQty.Text = string.Empty;
            TxtProductDesription.Text = string.Empty;
            DdlStockActive.SelectedIndex = 0;
            TxtPurchaseRate.Text = string.Empty;
            TxtSalesRate.Text = string.Empty;
            TxtVat.Text = string.Empty;
            TxtAddVat.Text = string.Empty;
            TxtCstVat.Text = string.Empty;
            TxtCstFullVat.Text = string.Empty;
            TxtGST.Text = string.Empty;
            TxtCGST.Text = string.Empty;
            TxtSGST.Text = string.Empty;
            TxtIGST.Text = string.Empty;


            BtncallUpd.Text = "SAVE";


        }

        public void FillDdlUOM()
        {
            try
            {
                DataTable Dt = UOM_MASLogicLayer.GetAllUOM_MASDetialsFor_DDL();
                DdlUOM.DataSource = Dt;
                DdlUOM.DataValueField = "UOMString";
                DdlUOM.DataTextField = "UOMString";
                DdlUOM.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlCategoryName()
        {
            try
            {
                DataTable Dt = STOCKCategory_MASLogicLayer.GetAllSTOCK_CATAGORYDetialsFor_DDL();
                DdlCategoryName.DataSource = Dt;
                DdlCategoryName.DataValueField = "CAT_CODE";
                DdlCategoryName.DataTextField = "CAT_NAME";
                DdlCategoryName.DataBind();

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
                FillBranchGrid();
                FillMaxProductCode();

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
                #region INSERT _ UPDATE VALUE

                #region STOCKMASTER
                STOCK_MASLogicLayer insert = new STOCK_MASLogicLayer();

                insert.SCODE = HfStockCode.Value.Trim();
                insert.SNAME = TxtProductName.Text.Trim().ToUpper();
                insert.PART_NO = TxtPartNo.Text.Trim();
                insert.UOM = DdlUOM.SelectedItem.Text.Trim().ToUpper();
                insert.CAT_CODE = DdlCategoryName.SelectedValue.Trim();

                if (TxtMinQty.Text == string.Empty)
                {
                    insert.MIN_QTY = "0";
                }
                else
                {
                    insert.MIN_QTY = TxtMinQty.Text.Trim();
                }

                if (TxtMaxQty.Text == string.Empty)
                {
                    insert.MAX_QTY = "0";
                }
                else
                {
                    insert.MAX_QTY = TxtMaxQty.Text.Trim();
                }

                insert.C_ACODE = "11";
                insert.S_ACODE = "12";
                insert.O_ACODE = "3";
                insert.ACTIVE = DdlStockActive.SelectedValue.Trim().ToUpper();
                insert.PROD_CODE = TxtProductCode.Text.Trim().ToUpper();
                insert.COMP_CODE = HfCompCode.Value;  //Session["COMP_CODE"].ToString();

                if (TxtOrderQty.Text == string.Empty)
                {
                    insert.ORDER_QTY = "0";
                }
                else
                {
                    insert.ORDER_QTY = TxtOrderQty.Text.Trim();
                }

                if (TxtHsnCode.Text == string.Empty)
                {
                    insert.HSN_NO = "0";
                }
                else
                {
                    insert.HSN_NO = TxtHsnCode.Text.Trim();
                }
                insert.PRODUCT_DESC = TxtProductDesription.Text.Trim().ToUpper();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";
                insert.ACODE = "0";

                #endregion

                #region STOCKRATE
                STOCK_RATEMASLogicLayer InsertRate = new STOCK_RATEMASLogicLayer();

                InsertRate.SCODE = HfStockCode.Value;
                InsertRate.COMP_CODE = HfCompCode.Value;  //Session["COMP_CODE"].ToString();//HfCompCode.Value; 
                InsertRate.YRDT1 = HfYearDate1.Value;    //Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd");//HfYearDate1.Value; 
                if (TxtPurchaseRate.Text == string.Empty)
                {
                    InsertRate.PUR_RATE = "0";
                }
                else
                {
                    InsertRate.PUR_RATE = TxtPurchaseRate.Text.Trim();
                }

                if (TxtSalesRate.Text == string.Empty)
                {
                    InsertRate.SAL_RATE = "0";
                }
                else
                {
                    InsertRate.SAL_RATE = TxtSalesRate.Text.Trim();
                }


                if (TxtVat.Text == string.Empty)
                {
                    InsertRate.VAT_RATE = "0";
                }
                else
                {
                    InsertRate.VAT_RATE = TxtVat.Text.Trim();
                }

                if (TxtAddVat.Text == string.Empty)
                {
                    InsertRate.ADD_VAT_RATE = "0";
                }
                else
                {
                    InsertRate.ADD_VAT_RATE = TxtAddVat.Text.Trim();
                }

                if (TxtCstVat.Text == string.Empty)
                {
                    InsertRate.CST_RATE = "0";
                }
                else
                {
                    InsertRate.CST_RATE = TxtCstVat.Text.Trim();
                }

                if (TxtCstFullVat.Text == string.Empty)
                {
                    InsertRate.CSTFULL_RATE = "0";
                }
                else
                {
                    InsertRate.CSTFULL_RATE = TxtCstFullVat.Text.Trim();
                }

                if (TxtGST.Text == string.Empty)
                {
                    InsertRate.GST_RATE = "0";
                }
                else
                {
                    InsertRate.GST_RATE = TxtGST.Text.Trim();
                }

                if (TxtCGST.Text == string.Empty)
                {
                    InsertRate.CGST_RATE = "0";
                }
                else
                {
                    InsertRate.CGST_RATE = TxtCGST.Text.Trim();
                }

                if (TxtSGST.Text == string.Empty)
                {
                    InsertRate.SGST_RATE = "0";
                }
                else
                {
                    InsertRate.SGST_RATE = TxtSGST.Text.Trim();
                }

                if (TxtIGST.Text == string.Empty)
                {
                    InsertRate.IGST_RATE = "0";
                }
                else
                {
                    InsertRate.IGST_RATE = TxtIGST.Text.Trim();
                }

                InsertRate.INS_USERID = Session["USERNAME"].ToString();
                InsertRate.INS_TERMINAL = Session["PC"].ToString();
                InsertRate.INS_DATE = "";
                InsertRate.UPD_USERID = Session["USERNAME"].ToString();
                InsertRate.UPD_TERMINAL = Session["PC"].ToString();
                InsertRate.UPD_DATE = "";

                #endregion

                #region MAP_STOCKBAL
                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);

                foreach (GridViewRow row in GvBranchStock.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfCompCodeVal = row.FindControl("HfCompCode") as HiddenField;
                        HiddenField HfStockCodeVAL = row.FindControl("HfStockCode") as HiddenField;
                        HiddenField HfYearDateVal = row.FindControl("HfYearDate1") as HiddenField;
                        TextBox TxtPurchaseRate = row.FindControl("TxtPurchaseRate") as TextBox;
                        TextBox TxtSaleRate = row.FindControl("TxtSaleRate") as TextBox;
                        TextBox TxtOpeningQty = row.FindControl("TxtOpeningQty") as TextBox;
                        TextBox TxtMaxQty = row.FindControl("TxtMaxQty") as TextBox;
                        TextBox TxtMinQty = row.FindControl("TxtMinQty") as TextBox;
                        TextBox TxtOrdQty = row.FindControl("TxtOrdQty") as TextBox;
                        Label lblBranchCode = row.FindControl("lblBranchName") as Label;
                        HiddenField HfBranchCode = row.FindControl("HfBranchCode") as HiddenField;

                        XmlElement HandleDetail2 = XDoc1.CreateElement("Detail");
                        HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());

                        HandleDetail2.SetAttribute("YRDT1", Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"));
                        if (TxtPurchaseRate.Text == string.Empty)
                        {
                            HandleDetail2.SetAttribute("PUR_RATE", ("0"));
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("PUR_RATE", (TxtPurchaseRate.Text));
                        }
                        if (TxtSaleRate.Text == string.Empty)
                        {
                            HandleDetail2.SetAttribute("SAL_RATE", ("0"));
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("SAL_RATE", (TxtSaleRate.Text));
                        }
                        if (TxtOpeningQty.Text == string.Empty)
                        {
                            HandleDetail2.SetAttribute("OP_QTY", ("0"));
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("OP_QTY", (TxtOpeningQty.Text));
                        }
                        if (TxtMaxQty.Text == string.Empty)
                        {
                            HandleDetail2.SetAttribute("MAX_QTY", ("0"));
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("MAX_QTY", (TxtMaxQty.Text));
                        }
                        if (TxtMinQty.Text == string.Empty)
                        {
                            HandleDetail2.SetAttribute("MIN_QTY", ("0"));
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("MIN_QTY", (TxtMinQty.Text));
                        }
                        if (TxtOrderQty.Text == string.Empty)
                        {
                            HandleDetail2.SetAttribute("ORDER_QTY", ("0"));
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("ORDER_QTY", (TxtOrdQty.Text));
                        }
                        HandleDetail2.SetAttribute("BRANCH_CODE", (HfBranchCode.Value));

                        HandleDetail2.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));
                        HandleDetail2.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));
                        HandleDetail2.SetAttribute("INS_DATE", (""));
                        HandleDetail2.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));
                        HandleDetail2.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));
                        HandleDetail2.SetAttribute("UPD_DATE", (""));
                        root1.AppendChild(HandleDetail2);
                    }
                }
                #endregion

                string str = STOCK_MASLogicLayer.UpdateSTOCK_MASDetail(insert, InsertRate, (XDoc1.OuterXml));

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "STOCK MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillGrid(Session["COMP_CODE"].ToString());
                    UserRights();
                   

                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "STOCK MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : STOCK MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }

                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillGrid(string CompCode)
        {
            try
            {
            
                DataTable Dt = new DataTable();

                Dt = STOCK_MASLogicLayer.GetAllSTOCK_MASDetails(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvStocktMaster.DataSource = Dv.ToTable();
                GvStocktMaster.DataBind();
                DtSearch = Dv.ToTable();
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void GvStocktMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvStocktMaster.PageIndex = e.NewPageIndex;
                FillGrid(Session["COMP_CODE"].ToString());
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStocktMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataSet ds = STOCK_MASLogicLayer.GetAllIDWiseSTOCK_MASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable dtBal = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfStockCode.Value = dt.Rows[0]["SCODE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfYearDate1.Value = dt.Rows[0]["YRDT1"].ToString();
                        TxtProductCode.Text = dt.Rows[0]["PROD_CODE"].ToString();
                        TxtPartNo.Text = dt.Rows[0]["PART_NO"].ToString();
                        TxtProductName.Text = dt.Rows[0]["SNAME"].ToString();
                        TxtHsnCode.Text = dt.Rows[0]["HSN_NO"].ToString();
                        DdlUOM.SelectedItem.Text = dt.Rows[0]["UOM"].ToString();
                        DdlCategoryName.SelectedValue = dt.Rows[0]["CAT_CODE"].ToString();
                        TxtMaxQty.Text = dt.Rows[0]["MAX_QTY"].ToString();
                        TxtMinQty.Text = dt.Rows[0]["MIN_QTY"].ToString();
                        TxtOrderQty.Text = dt.Rows[0]["ORDER_QTY"].ToString();
                        TxtProductDesription.Text = dt.Rows[0]["PRODUCT_DESC"].ToString();
                        DdlStockActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                        TxtPurchaseRate.Text = dt.Rows[0]["PUR_RATE"].ToString();
                        TxtSalesRate.Text = dt.Rows[0]["SAL_RATE"].ToString();
                        TxtVat.Text = dt.Rows[0]["VAT_RATE"].ToString();
                        TxtAddVat.Text = dt.Rows[0]["ADD_VAT_RATE"].ToString();
                        TxtCstVat.Text = dt.Rows[0]["CST_RATE"].ToString();
                        TxtCstFullVat.Text = dt.Rows[0]["CSTFULL_RATE"].ToString();
                        TxtGST.Text = dt.Rows[0]["GST_RATE"].ToString();
                        TxtCGST.Text = dt.Rows[0]["CGST_RATE"].ToString();
                        TxtSGST.Text = dt.Rows[0]["SGST_RATE"].ToString();
                        TxtIGST.Text = dt.Rows[0]["IGST_RATE"].ToString();
                        if (dtBal.Rows.Count > 0)
                        {
                            GvBranchStock.DataSource = dtBal;
                            GvBranchStock.DataBind();
                        }
                    }
                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    Btncalldel.Visible = true;
                    BtncallUpd.Visible = false;
                    ControllerDisable();
                    GvBranchStock.Enabled = false;

                    #endregion
                }

                if (e.CommandName == "Edita")
                {
                    #region EDIT
                    clear();
                    DataSet ds = STOCK_MASLogicLayer.GetAllIDWiseSTOCK_MASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable dtBal = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfStockCode.Value = dt.Rows[0]["SCODE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfYearDate1.Value = dt.Rows[0]["YRDT1"].ToString();
                        TxtProductCode.Text = dt.Rows[0]["PROD_CODE"].ToString();
                        TxtPartNo.Text = dt.Rows[0]["PART_NO"].ToString();
                        TxtProductName.Text = dt.Rows[0]["SNAME"].ToString();
                        TxtHsnCode.Text = dt.Rows[0]["HSN_NO"].ToString();
                        DdlUOM.SelectedItem.Text = dt.Rows[0]["UOM"].ToString();
                        DdlCategoryName.SelectedValue = dt.Rows[0]["CAT_CODE"].ToString();
                        TxtMaxQty.Text = dt.Rows[0]["MAX_QTY"].ToString();
                        TxtMinQty.Text = dt.Rows[0]["MIN_QTY"].ToString();
                        TxtOrderQty.Text = dt.Rows[0]["ORDER_QTY"].ToString();
                        TxtProductDesription.Text = dt.Rows[0]["PRODUCT_DESC"].ToString();
                        DdlStockActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                        TxtPurchaseRate.Text = dt.Rows[0]["PUR_RATE"].ToString();
                        TxtSalesRate.Text = dt.Rows[0]["SAL_RATE"].ToString();
                        TxtVat.Text = dt.Rows[0]["VAT_RATE"].ToString();
                        TxtAddVat.Text = dt.Rows[0]["ADD_VAT_RATE"].ToString();
                        TxtCstVat.Text = dt.Rows[0]["CST_RATE"].ToString();
                        TxtCstFullVat.Text = dt.Rows[0]["CSTFULL_RATE"].ToString();
                        TxtGST.Text = dt.Rows[0]["GST_RATE"].ToString();
                        TxtCGST.Text = dt.Rows[0]["CGST_RATE"].ToString();
                        TxtSGST.Text = dt.Rows[0]["SGST_RATE"].ToString();
                        TxtIGST.Text = dt.Rows[0]["IGST_RATE"].ToString();
                        if (dtBal.Rows.Count > 0)
                        {
                            GvBranchStock.DataSource = dtBal;
                            GvBranchStock.DataBind();
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
                    GvBranchStock.Enabled = true;

                    if (Session["USERTYPE"].ToString() =="A" )
                    {
                        TxtProductCode.Enabled = true;
                    }
                    else
                    {
                        TxtProductCode.Enabled = false;
                    }
                 



                    //FillBranchGrid();

                }

                if (e.CommandName == "Viewa")
                {
                    #region SET TEXT ON VIEW
                    clear();
                    DataSet ds = STOCK_MASLogicLayer.GetAllIDWiseSTOCK_MASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable dtBal = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfStockCode.Value = dt.Rows[0]["SCODE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfYearDate1.Value = dt.Rows[0]["YRDT1"].ToString();
                        TxtProductCode.Text = dt.Rows[0]["PROD_CODE"].ToString();
                        TxtPartNo.Text = dt.Rows[0]["PART_NO"].ToString();
                        TxtProductName.Text = dt.Rows[0]["SNAME"].ToString();
                        TxtHsnCode.Text = dt.Rows[0]["HSN_NO"].ToString();
                        DdlUOM.SelectedItem.Text = dt.Rows[0]["UOM"].ToString();
                        DdlCategoryName.SelectedValue = dt.Rows[0]["CAT_CODE"].ToString();
                        TxtMaxQty.Text = dt.Rows[0]["MAX_QTY"].ToString();
                        TxtMinQty.Text = dt.Rows[0]["MIN_QTY"].ToString();
                        TxtOrderQty.Text = dt.Rows[0]["ORDER_QTY"].ToString();
                        TxtProductDesription.Text = dt.Rows[0]["PRODUCT_DESC"].ToString();
                        DdlStockActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                        TxtPurchaseRate.Text = dt.Rows[0]["PUR_RATE"].ToString();
                        TxtSalesRate.Text = dt.Rows[0]["SAL_RATE"].ToString();
                        TxtVat.Text = dt.Rows[0]["VAT_RATE"].ToString();
                        TxtAddVat.Text = dt.Rows[0]["ADD_VAT_RATE"].ToString();
                        TxtCstVat.Text = dt.Rows[0]["CST_RATE"].ToString();
                        TxtCstFullVat.Text = dt.Rows[0]["CSTFULL_RATE"].ToString();
                        TxtGST.Text = dt.Rows[0]["GST_RATE"].ToString();
                        TxtCGST.Text = dt.Rows[0]["CGST_RATE"].ToString();
                        TxtSGST.Text = dt.Rows[0]["SGST_RATE"].ToString();
                        TxtIGST.Text = dt.Rows[0]["IGST_RATE"].ToString();
                        if (dtBal.Rows.Count > 0)
                        {
                            GvBranchStock.DataSource = dtBal;
                            GvBranchStock.DataBind();
                        }

                    }

                    #endregion
                    ControllerDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    UserRights();
                    GvBranchStock.Enabled = false;
                    // FillBranchGrid();
                }
            }
            catch (Exception ex)
            {

                lblmsg.Text = ex.Message.ToString();
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

                    #region STOCKMASTER
                    STOCK_MASLogicLayer insert = new STOCK_MASLogicLayer();

                    insert.SCODE = HfStockCode.Value.Trim();
                    insert.SNAME = TxtProductName.Text.Trim().ToUpper();
                    insert.PART_NO = TxtPartNo.Text.Trim().ToUpper();
                    insert.UOM = DdlUOM.SelectedItem.Text.Trim().ToUpper();
                    insert.CAT_CODE = DdlCategoryName.SelectedValue.Trim();

                    if (TxtMinQty.Text == string.Empty)
                    {
                        insert.MIN_QTY = "0";
                    }
                    else
                    {
                        insert.MIN_QTY = TxtMinQty.Text.Trim();
                    }

                    if (TxtMaxQty.Text == string.Empty)
                    {
                        insert.MAX_QTY = "0";
                    }
                    else
                    {
                        insert.MAX_QTY = TxtMaxQty.Text.Trim();
                    }

                    insert.C_ACODE = "11";
                    insert.S_ACODE = "12";
                    insert.O_ACODE = "3";
                    insert.ACTIVE = DdlStockActive.SelectedValue.Trim().ToUpper();
                    insert.PROD_CODE = TxtProductCode.Text.Trim().ToUpper();
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();

                    if (TxtOrderQty.Text == string.Empty)
                    {
                        insert.ORDER_QTY = "0";
                    }
                    else
                    {
                        insert.ORDER_QTY = TxtOrderQty.Text.Trim();
                    }

                    if (TxtHsnCode.Text == string.Empty)
                    {
                        insert.HSN_NO = "0";
                    }
                    else
                    {
                        insert.HSN_NO = TxtHsnCode.Text.Trim();
                    }
                    insert.PRODUCT_DESC = TxtProductDesription.Text.Trim().ToUpper();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";
                    insert.ACODE = "0";

                    #endregion

                    #region STOCKRATE
                    STOCK_RATEMASLogicLayer InsertRate = new STOCK_RATEMASLogicLayer();

                    InsertRate.SCODE = HfStockCode.Value;
                    InsertRate.COMP_CODE = Session["COMP_CODE"].ToString();//HfCompCode.Value; 
                    InsertRate.YRDT1 = Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd");//HfYearDate1.Value; 
                    if (TxtPurchaseRate.Text == string.Empty)
                    {
                        InsertRate.PUR_RATE = "0";
                    }
                    else
                    {
                        InsertRate.PUR_RATE = TxtPurchaseRate.Text.Trim();
                    }

                    if (TxtSalesRate.Text == string.Empty)
                    {
                        InsertRate.SAL_RATE = "0";
                    }
                    else
                    {
                        InsertRate.SAL_RATE = TxtSalesRate.Text.Trim();
                    }


                    if (TxtVat.Text == string.Empty)
                    {
                        InsertRate.VAT_RATE = "0";
                    }
                    else
                    {
                        InsertRate.VAT_RATE = TxtVat.Text.Trim();
                    }

                    if (TxtAddVat.Text == string.Empty)
                    {
                        InsertRate.ADD_VAT_RATE = "0";
                    }
                    else
                    {
                        InsertRate.ADD_VAT_RATE = TxtAddVat.Text.Trim();
                    }

                    if (TxtCstVat.Text == string.Empty)
                    {
                        InsertRate.CST_RATE = "0";
                    }
                    else
                    {
                        InsertRate.CST_RATE = TxtCstVat.Text.Trim();
                    }

                    if (TxtCstFullVat.Text == string.Empty)
                    {
                        InsertRate.CSTFULL_RATE = "0";
                    }
                    else
                    {
                        InsertRate.CSTFULL_RATE = TxtCstFullVat.Text.Trim();
                    }

                    if (TxtGST.Text == string.Empty)
                    {
                        InsertRate.GST_RATE = "0";
                    }
                    else
                    {
                        InsertRate.GST_RATE = TxtGST.Text.Trim();
                    }

                    if (TxtCGST.Text == string.Empty)
                    {
                        InsertRate.CGST_RATE = "0";
                    }
                    else
                    {
                        InsertRate.CGST_RATE = TxtCGST.Text.Trim();
                    }

                    if (TxtSGST.Text == string.Empty)
                    {
                        InsertRate.SGST_RATE = "0";
                    }
                    else
                    {
                        InsertRate.SGST_RATE = TxtSGST.Text.Trim();
                    }

                    if (TxtIGST.Text == string.Empty)
                    {
                        InsertRate.IGST_RATE = "0";
                    }
                    else
                    {
                        InsertRate.IGST_RATE = TxtIGST.Text.Trim();
                    }

                    InsertRate.INS_USERID = Session["USERNAME"].ToString();
                    InsertRate.INS_TERMINAL = Session["PC"].ToString();
                    InsertRate.INS_DATE = "";
                    InsertRate.UPD_USERID = Session["USERNAME"].ToString();
                    InsertRate.UPD_TERMINAL = Session["PC"].ToString();
                    InsertRate.UPD_DATE = "";

                    #endregion

                    //insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    //insert.SCODE = HfStockCode.Value;
                    //insert.YRDT1 = Convert.ToDateTime(HfYearDate1.Value.Trim()).ToString("yyyy-MM-dd");
                    #region MAP_STOCKBAL
                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);

                    foreach (GridViewRow row in GvBranchStock.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfCompCodeVal = row.FindControl("HfCompCode") as HiddenField;
                            HiddenField HfStockCodeVAL = row.FindControl("HfStockCode") as HiddenField;
                            HiddenField HfYearDateVal = row.FindControl("HfYearDate1") as HiddenField;
                            TextBox TxtPurchaseRate = row.FindControl("TxtPurchaseRate") as TextBox;
                            TextBox TxtSaleRate = row.FindControl("TxtSaleRate") as TextBox;
                            TextBox TxtOpeningQty = row.FindControl("TxtOpeningQty") as TextBox;
                            TextBox TxtMaxQty = row.FindControl("TxtMaxQty") as TextBox;
                            TextBox TxtMinQty = row.FindControl("TxtMinQty") as TextBox;
                            TextBox TxtOrdQty = row.FindControl("TxtOrdQty") as TextBox;
                            Label lblBranchCode = row.FindControl("lblBranchName") as Label;
                            HiddenField HfBranchCode = row.FindControl("HfBranchCode") as HiddenField;

                            XmlElement HandleDetail2 = XDoc1.CreateElement("Detail");
                            HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());


                            HandleDetail2.SetAttribute("YRDT1", Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"));
                            if(TxtPurchaseRate.Text==string.Empty)
                            {
                                HandleDetail2.SetAttribute("PUR_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("PUR_RATE", (TxtPurchaseRate.Text));
                            }
                           if(TxtSaleRate.Text==string.Empty)
                            {
                                HandleDetail2.SetAttribute("SAL_RATE", ("0"));
                            }
                           else
                            {
                                HandleDetail2.SetAttribute("SAL_RATE", (TxtSaleRate.Text));
                            }
                            if(TxtOpeningQty.Text==string.Empty)
                            {
                                HandleDetail2.SetAttribute("OP_QTY", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("OP_QTY", (TxtOpeningQty.Text));
                            }
                            if(TxtMaxQty.Text==string.Empty)
                            {
                                HandleDetail2.SetAttribute("MAX_QTY", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("MAX_QTY", (TxtMaxQty.Text));
                            }
                           if(TxtMinQty.Text==string.Empty)
                            {
                                HandleDetail2.SetAttribute("MIN_QTY", ("0"));
                            }
                           else
                            {
                                HandleDetail2.SetAttribute("MIN_QTY", (TxtMinQty.Text));
                            }
                           if(TxtOrderQty.Text==string.Empty)
                            {
                                HandleDetail2.SetAttribute("ORDER_QTY", ("0"));
                            }
                           else
                            {
                                HandleDetail2.SetAttribute("ORDER_QTY", (TxtOrdQty.Text));
                            }
                           
                            HandleDetail2.SetAttribute("BRANCH_CODE", (HfBranchCode.Value));

                            HandleDetail2.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));
                            HandleDetail2.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));
                            HandleDetail2.SetAttribute("INS_DATE", (""));
                            HandleDetail2.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));
                            HandleDetail2.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));
                            HandleDetail2.SetAttribute("UPD_DATE", (""));
                            root1.AppendChild(HandleDetail2);
                        }
                    }
                    #endregion

                    string str = STOCK_MASLogicLayer.InsertSTOCK_MASDetail(insert, InsertRate, validation.RSC(XDoc1.OuterXml));

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "STOCK MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(Session["COMP_CODE"].ToString());
                        UserRights();

                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "STOCK MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : STOCK MASTER NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }


                    //    STOCK_MASLogicLayer insert = new STOCK_MASLogicLayer();
                    //    insert.SCODE = HfStockCode.Value.Trim();
                    //    insert.SNAME = TxtProductName.Text.Trim().ToUpper();
                    //    insert.PART_NO = TxtPartNo.Text.Trim();
                    //    insert.UOM = DdlUOM.SelectedItem.Text.Trim().ToUpper();
                    //    insert.CAT_CODE = DdlCategoryName.SelectedValue.Trim();

                    //    if (TxtMinQty.Text == string.Empty)
                    //    {
                    //        insert.MIN_QTY = "0";
                    //    }
                    //    else
                    //    {
                    //        insert.MIN_QTY = TxtMinQty.Text.Trim();
                    //    }

                    //    if (TxtMaxQty.Text == string.Empty)
                    //    {
                    //        insert.MAX_QTY = "0";
                    //    }
                    //    else
                    //    {
                    //        insert.MAX_QTY = TxtMaxQty.Text.Trim();
                    //    }

                    //    insert.C_ACODE = "11";
                    //    insert.S_ACODE = "12";
                    //    insert.O_ACODE = "3";
                    //    insert.ACTIVE = DdlStockActive.SelectedValue.Trim().ToUpper();
                    //    insert.PROD_CODE = TxtProductCode.Text.Trim().ToUpper();
                    //    insert.COMP_CODE = Session["COMP_CODE"].ToString();

                    //    if (TxtOrderQty.Text == string.Empty)
                    //    {
                    //        insert.ORDER_QTY = "0";
                    //    }
                    //    else
                    //    {
                    //        insert.ORDER_QTY = TxtOrderQty.Text.Trim();
                    //    }

                    //    if (TxtHsnCode.Text == string.Empty)
                    //    {
                    //        insert.HSN_NO = "0";
                    //    }
                    //    else
                    //    {
                    //        insert.HSN_NO = TxtHsnCode.Text.Trim();
                    //    }
                    //    insert.PRODUCT_DESC = TxtProductDesription.Text.Trim().ToUpper();
                    //    insert.INS_USERID = Session["USERNAME"].ToString();
                    //    insert.INS_TERMINAL = Session["PC"].ToString();
                    //    insert.INS_DATE = "";
                    //    insert.UPD_USERID = Session["USERNAME"].ToString();
                    //    insert.UPD_TERMINAL = Session["PC"].ToString();
                    //    insert.UPD_DATE = "";
                    //    insert.ACODE = "0";


                    //    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    //    {
                    //        string str = STOCK_MASLogicLayer.InsertSTOCK_MASDetail(insert);
                    //        if (str.Length <= 8)
                    //        {
                    //            //INSERT CHARGE RATE
                    //            STOCK_RATEMASLogicLayer InsertRate = new STOCK_RATEMASLogicLayer();

                    //            InsertRate.SCODE = str;
                    //            InsertRate.COMP_CODE = Session["COMP_CODE"].ToString();
                    //            InsertRate.YRDT1 = Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd");
                    //            if (TxtPurchaseRate.Text == string.Empty)
                    //            {
                    //                InsertRate.PUR_RATE = "0";
                    //            }
                    //            else
                    //            {
                    //                InsertRate.PUR_RATE = TxtPurchaseRate.Text.Trim();
                    //            }

                    //            if (TxtSalesRate.Text == string.Empty)
                    //            {
                    //                InsertRate.SAL_RATE = "0";
                    //            }
                    //            else
                    //            {
                    //                InsertRate.SAL_RATE = TxtSalesRate.Text.Trim();
                    //            }


                    //            if (TxtVat.Text == string.Empty)
                    //            {
                    //                InsertRate.VAT_RATE = "0";
                    //            }
                    //            else
                    //            {
                    //                InsertRate.VAT_RATE = TxtVat.Text.Trim();
                    //            }

                    //            if (TxtAddVat.Text == string.Empty)
                    //            {
                    //                InsertRate.ADD_VAT_RATE = "0";
                    //            }
                    //            else
                    //            {
                    //                InsertRate.ADD_VAT_RATE = TxtAddVat.Text.Trim();
                    //            }

                    //            if (TxtCstVat.Text == string.Empty)
                    //            {
                    //                InsertRate.CST_RATE = "0";
                    //            }
                    //            else
                    //            {
                    //                InsertRate.CST_RATE = TxtCstVat.Text.Trim();
                    //            }

                    //            if (TxtCstFullVat.Text == string.Empty)
                    //            {
                    //                InsertRate.CSTFULL_RATE = "0";
                    //            }
                    //            else
                    //            {
                    //                InsertRate.CSTFULL_RATE = TxtCstFullVat.Text.Trim();
                    //            }

                    //            if (TxtGST.Text == string.Empty)
                    //            {
                    //                InsertRate.GST_RATE = "0";
                    //            }
                    //            else
                    //            {
                    //                InsertRate.GST_RATE = TxtGST.Text.Trim();
                    //            }

                    //            if (TxtCGST.Text == string.Empty)
                    //            {
                    //                InsertRate.CGST_RATE = "0";
                    //            }
                    //            else
                    //            {
                    //                InsertRate.CGST_RATE = TxtCGST.Text.Trim();
                    //            }

                    //            if (TxtSGST.Text == string.Empty)
                    //            {
                    //                InsertRate.SGST_RATE = "0";
                    //            }
                    //            else
                    //            {
                    //                InsertRate.SGST_RATE = TxtSGST.Text.Trim();
                    //            }

                    //            if (TxtIGST.Text == string.Empty)
                    //            {
                    //                InsertRate.IGST_RATE = "0";
                    //            }
                    //            else
                    //            {
                    //                InsertRate.IGST_RATE = TxtIGST.Text.Trim();
                    //            }

                    //            InsertRate.INS_USERID = Session["USERNAME"].ToString();
                    //            InsertRate.INS_TERMINAL = Session["PC"].ToString();
                    //            InsertRate.INS_DATE = "";
                    //            InsertRate.UPD_USERID = Session["USERNAME"].ToString();
                    //            InsertRate.UPD_TERMINAL = Session["PC"].ToString();
                    //            InsertRate.UPD_DATE = "";

                    //            STOCK_RATEMASLogicLayer.InsertSTOCK_RATEMASDetail(InsertRate);

                    //            lblmsg.Text = "STOCK MASTER DETAIL ADD SUCCESSFULLY.";
                    //            lblmsg.ForeColor = Color.Green;
                    //            clear();
                    //            FillGrid();
                    //            UserRights();
                    //        }
                    //        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    //        {
                    //            lblmsg.Text = "STOCK CODE ALREADY EXIST.";
                    //            lblmsg.ForeColor = Color.Red;
                    //        }
                    //        else
                    //        {
                    //            lblmsg.Text = "ERROR : STOCK MASTER DETAIL NOT SAVED";
                    //            lblmsg.ForeColor = Color.Red;
                    //        }
                    //    }

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
                if (HfStockCode.Value != string.Empty)
                {
                    string str = STOCK_MASLogicLayer.DeleteSTOCK_MASDetailsByID(HfStockCode.Value);
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
                        lblmsg.Text = "Error:Stock Master Not Deleted";
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

        protected void TxtGST_TextChanged(object sender, EventArgs e)
        {
            int tax;
            tax = Convert.ToInt32(TxtGST.Text);
            if (tax == 0)
            {
                TxtCGST.Text = "0";
                TxtSGST.Text = "0";
                TxtIGST.Text = "0";
            }
            else if (tax == 5)
            {
                TxtCGST.Text = "2.5";
                TxtSGST.Text = "2.5";
                TxtIGST.Text = "5";
            }
            else if (tax == 12)
            {
                TxtCGST.Text = "6";
                TxtSGST.Text = "6";
                TxtIGST.Text = "12";
            }
            else if (tax == 18)
            {
                TxtCGST.Text = "9";
                TxtSGST.Text = "9";
                TxtIGST.Text = "18";
            }
            else if (tax == 28)
            {
                TxtCGST.Text = "14";
                TxtSGST.Text = "14";
                TxtIGST.Text = "28";
            }
        }

        protected void GvBranchStock_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvBranchStock.PageIndex = e.NewPageIndex;
                FillBranchGrid();
                clear();
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
                if (TxtSearch.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtSearch);
                    Dv.RowFilter = "CategoryName like '%" + TxtSearch.Text.Trim() + "%' OR PROD_CODE like '%" + TxtSearch.Text.Trim() + "%' OR SNAME like '%" + TxtSearch.Text.Trim() + "%' OR Convert(HSN_NO, 'System.String') like '%" + TxtSearch.Text.Trim() + "%' OR PART_NO like '%" + TxtSearch.Text.Trim() + "%'";
                    GvStocktMaster.DataSource = Dv.ToTable();
                    GvStocktMaster.DataBind();

                }
                else
                {
                    GvStocktMaster.DataSource = DtSearch;
                    GvStocktMaster.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStocktMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) // Bind nested grid view with parent grid view
                {
                    string Id = ((HiddenField)e.Row.FindControl("HfStockCode")).Value;
                    GridView childgrd = (GridView)e.Row.FindControl("GvNestedBranchStock");

                    DataTable Dt = new DataTable();

                    Dt = STOCK_BALLogicLayer.GetAll_SCODEWise_STOCK_BAL(Id);
                    childgrd.DataSource = Dt;
                    childgrd.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
