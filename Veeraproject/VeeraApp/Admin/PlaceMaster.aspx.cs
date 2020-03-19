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
    public partial class PlaceMaster : System.Web.UI.Page
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
                FillDdlRouteName();
                FillGrid();
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


        public void FillDdlRouteName()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = ROUTE_MASLogicLayer.GetAllROUTE_MASDetialsFor_DDL();
                DdlRouteName.DataSource = Dt;
                DdlRouteName.DataValueField = "ROUTE_CODE";
                DdlRouteName.DataTextField = "ROUTE_NAME";
                DdlRouteName.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ControllerEnable()
        {
            // HfPlaceCode.Value = string.Empty;
            TxtPlaceName.Enabled = true;
            DdlRouteName.Enabled = true;
            TxtOrder.Enabled = true;
        }

        public void ControllerDisable()
        {
            // HfPlaceCode.Value = string.Empty;
            TxtPlaceName.Enabled = false;
            DdlRouteName.Enabled = false;
            TxtOrder.Enabled = false;
        }
        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfPlaceCode.Value = string.Empty;
            TxtPlaceName.Text = string.Empty;
            DdlRouteName.SelectedIndex = 0;
            TxtOrder.Text = string.Empty;

            BtncallUpd.Text = "SAVE";
        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                clear();
                ControllerEnable();
                UserRights();
                BtncallUpd.Visible = true;
                Btncalldel.Visible = false;
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            lblmsg.Text = string.Empty;
            UserRights();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region INSERT _ UPDATE VALUE

                PLACE_MASLogicLayer insert = new PLACE_MASLogicLayer();
                insert.comp_code = HfCompCode.Value.Trim();
                insert.branch_code = HfBranchCode.Value.Trim();
                insert.STATE_CODE = "0";
                insert.PLACE_CODE = HfPlaceCode.Value.Trim();
                insert.PLACE_NAME = TxtPlaceName.Text.Trim().ToUpper();
                insert.STD_CODE = "0";
                insert.ROUTE_CODE = DdlRouteName.SelectedValue.Trim().ToUpper();
                if (TxtOrder.Text == string.Empty)
                {
                    insert.PLACE_ORD = "0";
                }
                else
                {
                    insert.PLACE_ORD = TxtOrder.Text.Trim();
                }

                #endregion

                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = PLACE_MASLogicLayer.InsertPLACE_MASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "PLACE DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "PLACE CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : PLACE DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    string str = PLACE_MASLogicLayer.UpdatePLACE_MASDetails(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "PLACE DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already"))
                    {
                        lblmsg.Text = "PLACE CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : PLACE DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillGrid()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = PLACE_MASLogicLayer.GetAllPLACE_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                GvPlaceMaster.DataSource = Dt;
                GvPlaceMaster.DataBind();
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

                    PLACE_MASLogicLayer insert = new PLACE_MASLogicLayer();

                    insert.comp_code = Session["COMP_CODE"].ToString();
                    insert.branch_code = Session["BRANCH_CODE"].ToString();
                    insert.STATE_CODE = "0";
                    insert.PLACE_CODE = HfPlaceCode.Value.Trim();
                    insert.PLACE_NAME = TxtPlaceName.Text.Trim().ToUpper();
                    insert.STD_CODE = "0";
                    insert.ROUTE_CODE = DdlRouteName.SelectedValue.Trim().ToUpper();
                    if (TxtOrder.Text == string.Empty)
                    {
                        insert.PLACE_ORD = "0";
                    }
                    else
                    {
                        insert.PLACE_ORD = TxtOrder.Text.Trim();
                    }


                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = PLACE_MASLogicLayer.InsertPLACE_MASDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "PLACE DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid();
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "PLACE CODE ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : PLACE DETAIL NOT SAVED";
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

        protected void GvPlaceMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvPlaceMaster.PageIndex = e.NewPageIndex;
                FillGrid();
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvPlaceMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataTable dt = PLACE_MASLogicLayer.GetAllIDWisePLACE_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["comp_code"].ToString();
                        HfBranchCode.Value = dt.Rows[0]["branch_code"].ToString();
                        HfPlaceCode.Value = dt.Rows[0]["PLACE_CODE"].ToString();
                        TxtPlaceName.Text = dt.Rows[0]["PLACE_NAME"].ToString();
                        DdlRouteName.SelectedValue = dt.Rows[0]["ROUTE_CODE"].ToString();
                        TxtOrder.Text = dt.Rows[0]["PLACE_ORD"].ToString();
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
                    DataTable dt = PLACE_MASLogicLayer.GetAllIDWisePLACE_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["comp_code"].ToString();
                        HfBranchCode.Value = dt.Rows[0]["branch_code"].ToString();
                        HfPlaceCode.Value = dt.Rows[0]["PLACE_CODE"].ToString();
                        TxtPlaceName.Text = dt.Rows[0]["PLACE_NAME"].ToString();
                        DdlRouteName.SelectedValue = dt.Rows[0]["ROUTE_CODE"].ToString();
                        TxtOrder.Text = dt.Rows[0]["PLACE_ORD"].ToString();

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
                    DataTable dt = PLACE_MASLogicLayer.GetAllIDWisePLACE_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["comp_code"].ToString();
                        HfBranchCode.Value = dt.Rows[0]["branch_code"].ToString();
                        HfPlaceCode.Value = dt.Rows[0]["PLACE_CODE"].ToString();
                        TxtPlaceName.Text = dt.Rows[0]["PLACE_NAME"].ToString();
                        DdlRouteName.SelectedValue = dt.Rows[0]["ROUTE_CODE"].ToString();
                        TxtOrder.Text = dt.Rows[0]["PLACE_ORD"].ToString();

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

      
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE  
                if (HfPlaceCode.Value != string.Empty)
                {
                    string str = PLACE_MASLogicLayer.DeletePLACE_MASDetailsByID(HfPlaceCode.Value);
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
                        lblmsg.Text = "Error:Branch Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillGrid();
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