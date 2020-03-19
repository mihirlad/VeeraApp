using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;
using System.Data.SqlClient;

namespace VeeraApp
{
    public partial class StateMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERCODE"] != null &&
              Session["USERNAME"] != null &&
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


        public void ControllerEnable()
        {
            //  HfStateCode.Value = string.Empty;
            TxtStateName.Enabled = true;
            TxtStateNo.Enabled = true;
            DdlStateType.Enabled = true;
            TxtStateShort.Enabled = true;
            TxtStateCapital.Enabled = true;
        }

        public void ControllerDisable()
        {
            //  HfStateCode.Value = string.Empty;
            TxtStateName.Enabled = false;
            TxtStateNo.Enabled = false;
            DdlStateType.Enabled = false;
            TxtStateShort.Enabled = false;
            TxtStateCapital.Enabled = false;
        }
        public void clear()
        {

            DivEntry.Visible = false;
            DivView.Visible = true;

       //   HfStateCode.Value = string.Empty;
            TxtStateName.Text = string.Empty;
            TxtStateNo.Text = string.Empty;
            DdlStateType.SelectedIndex = 0;
            TxtStateShort.Text = string.Empty;
            TxtStateCapital.Text = string.Empty;

            BtncallUpd.Text = "SAVE";

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

                STATE_MASLogicLayer insert = new STATE_MASLogicLayer();
                insert.STATE_CODE = HfStateCode.Value.Trim();
                insert.STATE_NAME = TxtStateName.Text.Trim().ToUpper();
                insert.STATE_TYPE = DdlStateType.SelectedValue.Trim().ToUpper();
                insert.STATE_NO = TxtStateNo.Text.Trim().ToUpper();
                insert.STATE_SHORT = TxtStateShort.Text.Trim().ToUpper();
                insert.STATE_CAPITAL = TxtStateCapital.Text.Trim().ToUpper();

                #endregion
                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = STATE_MASLogicLayer.InsertSTATE_MASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "STATE DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "STATE CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : STATE DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    string str = STATE_MASLogicLayer.UpdateSTATE_MASDetails(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "STATE DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already"))
                    {
                        lblmsg.Text = "STATE CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : STATE DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string SortDirection
        {
            get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }

        public void FillGrid(string sortExpression = null)
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = STATE_MASLogicLayer.GetAllSTATE_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));

                if (sortExpression != null)
                {
                    DataView dv = Dt.AsDataView();
                    this.SortDirection = this.SortDirection == "ASC" ? "DESC" : "ASC";
                    dv.Sort = sortExpression + " " + this.SortDirection;
                    GvStateMaster.DataSource = dv;
                    GvStateMaster.DataBind();
                }
                else
                {
                    GvStateMaster.DataSource = Dt;
                    GvStateMaster.DataBind();
                }


              //  GvStateMaster.DataSource = Dt;
              //  GvStateMaster.DataBind();
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
                    STATE_MASLogicLayer insert = new STATE_MASLogicLayer();
                    insert.STATE_CODE = HfStateCode.Value.Trim();
                    insert.STATE_NAME = TxtStateName.Text.Trim().ToUpper();
                    insert.STATE_TYPE = DdlStateType.SelectedValue.Trim().ToUpper();
                    insert.STATE_NO = TxtStateNo.Text.Trim().ToUpper();
                    insert.STATE_SHORT = TxtStateShort.Text.Trim().ToUpper();
                    insert.STATE_CAPITAL = TxtStateCapital.Text.Trim().ToUpper();

                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = STATE_MASLogicLayer.InsertSTATE_MASDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "STATE DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid();
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "STATE CODE ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : STATE DETAIL NOT SAVED";
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

        protected void GvStateMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                GvStateMaster.PageIndex = e.NewPageIndex;
                FillGrid();
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStateMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataTable dt = STATE_MASLogicLayer.GetAllIDWiseSTATE_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfStateCode.Value = dt.Rows[0]["STATE_CODE"].ToString();
                        TxtStateName.Text = dt.Rows[0]["STATE_NAME"].ToString();
                        TxtStateNo.Text = dt.Rows[0]["STATE_NO"].ToString();
                        DdlStateType.SelectedValue = dt.Rows[0]["STATE_TYPE"].ToString();
                        TxtStateShort.Text = dt.Rows[0]["STATE_SHORT"].ToString();
                        TxtStateCapital.Text = dt.Rows[0]["STATE_CAPITAL"].ToString();
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
                    DataTable dt = STATE_MASLogicLayer.GetAllIDWiseSTATE_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfStateCode.Value = dt.Rows[0]["STATE_CODE"].ToString();
                        TxtStateName.Text = dt.Rows[0]["STATE_NAME"].ToString();
                        TxtStateNo.Text = dt.Rows[0]["STATE_NO"].ToString();
                        DdlStateType.SelectedValue = dt.Rows[0]["STATE_TYPE"].ToString();
                        TxtStateShort.Text = dt.Rows[0]["STATE_SHORT"].ToString();
                        TxtStateCapital.Text = dt.Rows[0]["STATE_CAPITAL"].ToString();

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
                    DataTable dt = STATE_MASLogicLayer.GetAllIDWiseSTATE_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfStateCode.Value = dt.Rows[0]["STATE_CODE"].ToString();
                        TxtStateName.Text = dt.Rows[0]["STATE_NAME"].ToString();
                        TxtStateNo.Text = dt.Rows[0]["STATE_NO"].ToString();
                        DdlStateType.SelectedValue = dt.Rows[0]["STATE_TYPE"].ToString();
                        TxtStateShort.Text = dt.Rows[0]["STATE_SHORT"].ToString();
                        TxtStateCapital.Text = dt.Rows[0]["STATE_CAPITAL"].ToString();

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
                if (HfStateCode.Value != string.Empty)
                {
                    string str = STATE_MASLogicLayer.DeleteSTATE_MASDetailsByID(HfStateCode.Value);
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

        protected void GvStateMaster_Sorting(object sender, GridViewSortEventArgs e)
        {
            this.FillGrid(e.SortExpression);
        }
    }
}