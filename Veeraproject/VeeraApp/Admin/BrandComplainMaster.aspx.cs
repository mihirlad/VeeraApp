using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp
{
    public partial class BrandComplainMaster : System.Web.UI.Page
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
                    if (!string.IsNullOrWhiteSpace(Request.QueryString["BRANDTYPE_CODE"]) && !string.IsNullOrWhiteSpace(Request.QueryString["COMP_CODE"]))
                    {
                        HfCompCode.Value = Request.QueryString["COMP_CODE"];
                        DdlBrandTypeName.SelectedValue = Request.QueryString["BRANDTYPE_CODE"];
                    }

                    DivEntry.Visible = false;
                    DivView.Visible = true;
                    FillDdlComaplainDescription();
                    FillDdlBrandTypeName();
                    FillGrid(DdlBrandTypeName.SelectedValue);

                 

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
                throw;
            }
        }
        public void FillDdlComaplainDescription()
        {
            try
            {
                DataTable Dt = JOB_COMPMASLogicLayer.GetAllJOB_COMPLAIN_MASDetialsFor_DDL();
                DdlComplainDescription.DataSource = Dt;
                DdlComplainDescription.DataValueField = "COMPLAIN_CODE";
                DdlComplainDescription.DataTextField = "COMPLAIN_DESC";
                DdlComplainDescription.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlBrandTypeName()
        {
            try
            {
                DataTable Dt = STOCK_BRANDTYPEMASLogicLayer.GetAllSTOCK_BRANDTYPEMASDetialsFor_DDL();
                DdlBrandTypeName.DataSource = Dt;
                DdlBrandTypeName.DataValueField = "BRANDTYPE_CODE";
                DdlBrandTypeName.DataTextField = "BRANDTYPE_NAME";
                DdlBrandTypeName.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ControllerEnable()
        {
            DdlComplainDescription.Enabled = true;
            //  TxtComplainChecklist.Enabled = true;
            DdlBrandTypeName.Enabled = true;
        }

        public void ControllerDisable()
        {
            DdlComplainDescription.Enabled = false;
            //  TxtComplainChecklist.Enabled = false;
            DdlBrandTypeName.Enabled = false;
        }
        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfCompCode.Value = string.Empty;
            HfComplainSrNo.Value = string.Empty;
            DdlComplainDescription.SelectedIndex = 0;
            TxtComplainChecklist.Text = string.Empty;
           // DdlBrandTypeName.SelectedIndex = 0;

            BtncallUpd.Text = "SAVE";
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
                lblmsg.Text = string.Empty;
                UserRights();
            }
            catch (Exception)
            {

                throw;
            }
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
                DdlBrandTypeName.Enabled = false;

                //if (!string.IsNullOrWhiteSpace(Request.QueryString["BRANDTYPE_CODE"]) && !string.IsNullOrWhiteSpace(Request.QueryString["COMP_CODE"]))
                //{
                //    HfCompCode.Value = Request.QueryString["COMP_CODE"];
                //    DdlBrandTypeName.SelectedValue = Request.QueryString["BRANDTYPE_CODE"];
                //    DdlBrandTypeName.Enabled = false;
                //}

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/StockBrandTypeMaster.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                #region UPDATE BRAND COMPLAIN MASTER 

                BRAND_COMPMASLogicLayer insert = new BRAND_COMPMASLogicLayer();
                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.COMPLAIN_SRNO = HfComplainSrNo.Value.Trim();
                insert.BRANDTYPE_CODE = DdlBrandTypeName.SelectedValue.Trim().ToUpper();
                insert.COMPLAIN_CODE = DdlComplainDescription.SelectedValue.Trim().ToUpper();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";
                #endregion

                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = BRAND_COMPMASLogicLayer.InsertBRAND_COMPLAIN_MASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "BRAND COMPALIN MASTER DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(DdlBrandTypeName.SelectedValue);
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "BRAND COMPLAIN CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR :BRAND COMPLAIN MASTER DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }

                else
                {

                    string str = BRAND_COMPMASLogicLayer.UpdateBRAND_COMPLAIN_MASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "BRAND COMPALIN MASTER DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(DdlBrandTypeName.SelectedValue);
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "BRAND COMPLAIN CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR :BRAND COMPLAIN MASTER DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void FillGrid(string BrandTypeCode)
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = BRAND_COMPMASLogicLayer.GetAllBRAND_COMPLAIN_MASDetail(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if(BrandTypeCode != string.Empty)
                {
                    Dv.RowFilter = "BRANDTYPE_CODE=" + DdlBrandTypeName.SelectedValue.Trim();

                }

                GvBrandComplainMaster.DataSource = Dv.ToTable();
                GvBrandComplainMaster.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvBrandComplainMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvBrandComplainMaster.PageIndex = e.NewPageIndex;
                FillGrid(DdlBrandTypeName.SelectedValue);
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvBrandComplainMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataTable dt = BRAND_COMPMASLogicLayer.GetAllIDWiseBRAND_COMPLAIN_MASDetail(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfComplainSrNo.Value = dt.Rows[0]["COMPLAIN_SRNO"].ToString();
                        DdlComplainDescription.SelectedValue = dt.Rows[0]["COMPLAIN_CODE"].ToString();
                        getComplainCheckList();
                        //  TxtComplainChecklist.Text = dt.Rows[0][""].ToString();
                        DdlBrandTypeName.SelectedValue = dt.Rows[0]["BRANDTYPE_CODE"].ToString();

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
                    DataTable dt = BRAND_COMPMASLogicLayer.GetAllIDWiseBRAND_COMPLAIN_MASDetail(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfComplainSrNo.Value = dt.Rows[0]["COMPLAIN_SRNO"].ToString();
                        DdlComplainDescription.SelectedValue = dt.Rows[0]["COMPLAIN_CODE"].ToString();
                        getComplainCheckList();
                        //  TxtComplainChecklist.Text = dt.Rows[0][""].ToString();
                        DdlBrandTypeName.SelectedValue = dt.Rows[0]["BRANDTYPE_CODE"].ToString();

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
                    DataTable dt = BRAND_COMPMASLogicLayer.GetAllIDWiseBRAND_COMPLAIN_MASDetail(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfComplainSrNo.Value = dt.Rows[0]["COMPLAIN_SRNO"].ToString();
                        DdlComplainDescription.SelectedValue = dt.Rows[0]["COMPLAIN_CODE"].ToString();
                        getComplainCheckList();
                        //  TxtComplainChecklist.Text = dt.Rows[0][""].ToString();
                        DdlBrandTypeName.SelectedValue = dt.Rows[0]["BRANDTYPE_CODE"].ToString();

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
                    #region INSERT BRAND COMPLAIN MASTER 

                    BRAND_COMPMASLogicLayer insert = new BRAND_COMPMASLogicLayer();
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.COMPLAIN_SRNO = HfComplainSrNo.Value.Trim();
                    insert.BRANDTYPE_CODE = DdlBrandTypeName.SelectedValue.Trim().ToUpper();
                    insert.COMPLAIN_CODE = DdlComplainDescription.SelectedValue.Trim().ToUpper();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";
                    #endregion

                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = BRAND_COMPMASLogicLayer.InsertBRAND_COMPLAIN_MASDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "BRAND COMPALIN MASTER DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid(DdlBrandTypeName.SelectedValue);
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "BRAND COMPLAIN CODE ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR :BRAND COMPLAIN MASTER DETAIL NOT SAVED";
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
                if (HfComplainSrNo.Value != string.Empty)
                {
                    string str =BRAND_COMPMASLogicLayer.DeleteBRAND_COMPLAIN_MASDetailByID(HfComplainSrNo.Value);
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
                        lblmsg.Text = "Error:Brand Complain Master Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillGrid(DdlBrandTypeName.SelectedValue);
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlComplainDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            getComplainCheckList();
        }

        public void getComplainCheckList()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select COMPLAIN_CHECK from JOB_COMPMAS where COMPLAIN_DESC= '" + DdlComplainDescription.SelectedItem.ToString() + "'", con);
                TxtComplainChecklist.Text = cmd.ExecuteScalar().ToString();           
                TxtComplainChecklist.Enabled = false;
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}