using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp
{
    public partial class StockCategoryMaster : System.Web.UI.Page
    {
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
                DivEntry.Visible = false;
                DivView.Visible = true;
                FillGrid(Session["COMP_CODE"].ToString());
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
        public void ControllerEnable()
        {
            //   HfStockCatCode.Value = string.Empty;
            //   HfCompCode.Value = string.Empty;
            TxtStoctCatName.Enabled = true;
            TxtTarrifNo.Enabled = true;
            TxtStockOrder.Enabled = true;
        }
        public void ControllerDisable()
        {
            //   HfStockCatCode.Value = string.Empty;
            //   HfCompCode.Value = string.Empty;
            TxtStoctCatName.Enabled = false;
            TxtTarrifNo.Enabled = false;
            TxtStockOrder.Enabled = false;
        }
        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;


            HfStockCatCode.Value = string.Empty;
            HfCompCode.Value = string.Empty;
            TxtStoctCatName.Text = string.Empty;
            TxtTarrifNo.Text = string.Empty;
            TxtStockOrder.Text = string.Empty;

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
                STOCKCategory_MASLogicLayer insert = new STOCKCategory_MASLogicLayer();
                insert.CAT_CODE = HfStockCatCode.Value.Trim();
                insert.CAT_NAME = TxtStoctCatName.Text.Trim().ToUpper();
                insert.ACTIVE = "";
                insert.PRODUCT_NO = "";
                insert.PRODUCT_DESC = "";  
               
                 if (TxtStoctCatName.Text == string.Empty)
                {
                    insert.ORD_NO = "0";
                }
                else
                {
                    insert.ORD_NO = TxtStockOrder.Text.Trim();
                }
                insert.REF_CAT_CODE = "0";
                insert.CAT_TYPE = "";
                insert.RW_TYPE = "";
                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.CAT_CETHNO = TxtTarrifNo.Text.Trim().ToUpper();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                //  insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                //    insert.UPD_DATE = "";

                #endregion


                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = STOCKCategory_MASLogicLayer.InsertSTOCKCategory_MASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "STOCK CATEGORY DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(Session["COMP_CODE"].ToString());
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "STOCK CATEGORY MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : STOCK CATEGORY DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    string str = STOCKCategory_MASLogicLayer.UpdateSTOCKCategory_MASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "STOCK CATEGORY DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(Session["COMP_CODE"].ToString());
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "STOCK CATEGORY MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : STOCK CATEGORY DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }

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
           
                Dt = STOCKCategory_MASLogicLayer.GetAllSTOCKCategory_MASDetails(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvStockCatMaster.DataSource = Dv.ToTable();
                GvStockCatMaster.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void GvStockCatMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvStockCatMaster.PageIndex = e.NewPageIndex;
                FillGrid(Session["COMP_CODE"].ToString());
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStockCatMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    //    string COMP_CODE = HfCompCode.Value;
                    DataTable dt = STOCKCategory_MASLogicLayer.GetAllIDWiseSTOCKCategory_MASDetail(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfStockCatCode.Value = dt.Rows[0]["CAT_CODE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        TxtStoctCatName.Text = dt.Rows[0]["CAT_NAME"].ToString();
                        TxtTarrifNo.Text = dt.Rows[0]["CAT_CETHNO"].ToString();
                        TxtStockOrder.Text = dt.Rows[0]["ORD_NO"].ToString();


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
                    #region EDIT
                    clear();
                    //    string COMP_CODE = HfCompCode.Value;
                    DataTable dt = STOCKCategory_MASLogicLayer.GetAllIDWiseSTOCKCategory_MASDetail(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfStockCatCode.Value = dt.Rows[0]["CAT_CODE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        TxtStoctCatName.Text = dt.Rows[0]["CAT_NAME"].ToString();
                        TxtTarrifNo.Text = dt.Rows[0]["CAT_CETHNO"].ToString();
                        TxtStockOrder.Text = dt.Rows[0]["ORD_NO"].ToString();

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
                     
                    DataTable dt = STOCKCategory_MASLogicLayer.GetAllIDWiseSTOCKCategory_MASDetail(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfStockCatCode.Value = dt.Rows[0]["CAT_CODE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        TxtStoctCatName.Text = dt.Rows[0]["CAT_NAME"].ToString();
                        TxtTarrifNo.Text = dt.Rows[0]["CAT_CETHNO"].ToString();
                        TxtStockOrder.Text = dt.Rows[0]["ORD_NO"].ToString();

                        #endregion
                    }
                    ControllerDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    UserRights();
                }
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
                    STOCKCategory_MASLogicLayer insert = new STOCKCategory_MASLogicLayer();
                    insert.CAT_CODE = HfStockCatCode.Value.Trim();
                    insert.CAT_NAME = TxtStoctCatName.Text.Trim().ToUpper();
                    insert.ACTIVE = "";
                    insert.PRODUCT_NO = "";
                    insert.PRODUCT_DESC = "";

                    if (TxtStockOrder.Text == string.Empty)
                    {
                        insert.ORD_NO = "0";
                    }
                    else
                    {
                        insert.ORD_NO = TxtStockOrder.Text.Trim();
                    }
                    insert.REF_CAT_CODE = "0";
                    insert.CAT_TYPE = "";
                    insert.RW_TYPE = "";
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.CAT_CETHNO = TxtTarrifNo.Text.Trim().ToUpper();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";


                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = STOCKCategory_MASLogicLayer.InsertSTOCKCategory_MASDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "STOCK CATEGORY DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid(Session["COMP_CODE"].ToString());
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "STOCK CATEGORY MASTER ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : STOCK CATEGORY DETAIL NOT SAVED";
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
               
                if (HfStockCatCode.Value != string.Empty)
                {
                    string str = STOCKCategory_MASLogicLayer.DeleteSTOCKCategory_MASDetailsByID(HfStockCatCode.Value);
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
                        lblmsg.Text = "Error:Stock Category Not Deleted";
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
    }
}