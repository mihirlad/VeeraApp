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
    public partial class RouteMaster : System.Web.UI.Page
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
            //  HfRouteCode.Value = string.Empty;
            TxtRouteName.Enabled = true;
            TxtOrder.Enabled = true;
        }

        public void ControllerDisable()
        {
            //  HfRouteCode.Value = string.Empty;
            TxtRouteName.Enabled = false;
            TxtOrder.Enabled = false;
        }
        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfRouteCode.Value = string.Empty;
            TxtRouteName.Text = string.Empty;
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

                ROUTE_MASLogicLayer insert = new ROUTE_MASLogicLayer();
                insert.comp_code = HfCompCode.Value.Trim();
                insert.branch_code = HfBranchCode.Value.Trim();
                insert.ROUTE_CODE = HfRouteCode.Value.Trim();
                insert.ROUTE_NAME = TxtRouteName.Text.Trim().ToUpper();
                if (TxtOrder.Text == string.Empty)
                {
                    insert.ROUTE_ORD = "0";
                }
                else
                {
                    insert.ROUTE_ORD = TxtOrder.Text.Trim();
                }
              
                #endregion

                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = ROUTE_MASLogicLayer.InsertROUTE_MASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "ROUTE DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "ROUTE CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : ROUTE DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    string str = ROUTE_MASLogicLayer.UpdateROUTE_MASDetails(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "ROUTE DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already"))
                    {
                        lblmsg.Text = "ROUTE CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : ROUTE DETAIL NOT SAVED";
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

                Dt = ROUTE_MASLogicLayer.GetAllROUTE_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                GvRouteMaster.DataSource = Dt;
                GvRouteMaster.DataBind();
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
                    ROUTE_MASLogicLayer insert = new ROUTE_MASLogicLayer();
                    insert.comp_code = Session["COMP_CODE"].ToString();
                    insert.branch_code = Session["BRANCH_CODE"].ToString();
                    insert.ROUTE_CODE = HfRouteCode.Value.Trim();
                    insert.ROUTE_NAME = TxtRouteName.Text.Trim().ToUpper();
                    if (TxtOrder.Text == string.Empty)
                    {
                        insert.ROUTE_ORD = "0";
                    }
                    else
                    {
                        insert.ROUTE_ORD = TxtOrder.Text.Trim();
                    }

                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = ROUTE_MASLogicLayer.InsertROUTE_MASDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "ROUTE DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid();
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "ROUTE CODE ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : ROUTE DETAIL NOT SAVED";
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
                if (HfRouteCode.Value != string.Empty)
                {
                    string str = ROUTE_MASLogicLayer.DeleteROUTE_MASDetailsByID(HfRouteCode.Value);
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

        protected void GvRouteMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                GvRouteMaster.PageIndex = e.NewPageIndex;
                FillGrid();
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvRouteMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataTable dt = ROUTE_MASLogicLayer.GetAllIDWiseROUTE_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["comp_code"].ToString();
                        HfBranchCode.Value = dt.Rows[0]["branch_code"].ToString();
                        HfRouteCode.Value = dt.Rows[0]["ROUTE_CODE"].ToString();
                        TxtRouteName.Text = dt.Rows[0]["ROUTE_NAME"].ToString();
                        TxtOrder.Text = dt.Rows[0]["ROUTE_ORD"].ToString();

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
                    DataTable dt = ROUTE_MASLogicLayer.GetAllIDWiseROUTE_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["comp_code"].ToString();
                        HfBranchCode.Value = dt.Rows[0]["branch_code"].ToString();
                        HfRouteCode.Value = dt.Rows[0]["ROUTE_CODE"].ToString();
                        TxtRouteName.Text = dt.Rows[0]["ROUTE_NAME"].ToString();
                        TxtOrder.Text = dt.Rows[0]["ROUTE_ORD"].ToString();

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
                    DataTable dt = ROUTE_MASLogicLayer.GetAllIDWiseROUTE_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["comp_code"].ToString();
                        HfBranchCode.Value = dt.Rows[0]["branch_code"].ToString();
                        HfRouteCode.Value = dt.Rows[0]["ROUTE_CODE"].ToString();
                        TxtRouteName.Text = dt.Rows[0]["ROUTE_NAME"].ToString();
                        TxtOrder.Text = dt.Rows[0]["ROUTE_ORD"].ToString();

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
    }
}
