using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class MenuMaster : System.Web.UI.Page
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
                FillDdlRefCode();
            }
        }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        public void FillDdlRefCode()
        {
            try
            {
                DataTable Dt = MENU_MASLogicLayer.GetAllMENU_MASDetialsFor_DDL();
                DdlReferenceCode.DataSource = Dt;
                DdlReferenceCode.DataValueField = "CODE";
                DdlReferenceCode.DataTextField = "NAME";
                DdlReferenceCode.DataBind();

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
            TxtCode.Enabled = true;
            TxtName.Enabled = true;
            DdlReferenceCode.Enabled = true;
            TxtMenuName.Enabled = true;
            TxtMenuOrder.Enabled = true;

        }

        public void ControllerDisable()
        {
            TxtCode.Enabled = false;
            TxtName.Enabled = false;
            DdlReferenceCode.Enabled = false;
            TxtMenuName.Enabled = false;
            TxtMenuOrder.Enabled = false;

        }
        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            TxtCode.Text = string.Empty;
            TxtName.Text = string.Empty;
            DdlReferenceCode.SelectedIndex = 0;
            TxtMenuName.Text = string.Empty;
            TxtMenuOrder.Text = string.Empty;

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
                MENU_MASLogicLayer insert = new MENU_MASLogicLayer();

            //    insert.SYSCODE = "";
                if (TxtCode.Text == string.Empty)
                {
                    insert.CODE = "0";
                }
                else
                {
                    insert.CODE = TxtCode.Text.Trim();
                }
                insert.NAME = TxtName.Text.Trim();
                insert.REF_CODE=DdlReferenceCode.SelectedValue.Trim().ToUpper();
                insert.MENU_NAME = TxtMenuName.Text.Trim().ToUpper();

                if (TxtMenuOrder.Text == string.Empty)
                {
                    insert.MENU_ORD = "0";
                }
                else
                {
                    insert.MENU_ORD = TxtMenuOrder.Text.Trim();
                }

                #endregion

                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = MENU_MASLogicLayer.InsertMENU_MASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "MENU DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "MENU CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : MENU DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }

                else
                {
                    string str = MENU_MASLogicLayer.UpdateMENU_MASDetails(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "MENU DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already"))
                    {
                        lblmsg.Text = "MENU CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : MENU DETAIL NOT SAVED";
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

                Dt = MENU_MASLogicLayer.GetAllMENU_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                GvMenutMaster.DataSource = Dt;
                GvMenutMaster.DataBind();
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvMenutMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvMenutMaster.PageIndex = e.NewPageIndex;
                FillGrid();
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvMenutMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataTable dt = MENU_MASLogicLayer.GetAllIDWiseMENU_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        TxtCode.Text = dt.Rows[0]["CODE"].ToString();
                        TxtName.Text = dt.Rows[0]["NAME"].ToString();
                        FillDdlRefCode();
                        if (dt.Rows[0]["REF_CODE"].ToString() != string.Empty)
                        {
                            DdlReferenceCode.SelectedValue = dt.Rows[0]["REF_CODE"].ToString();
                        }
                        TxtMenuName.Text = dt.Rows[0]["MENU_NAME"].ToString();
                        TxtMenuOrder.Text = dt.Rows[0]["MENU_ORD"].ToString();

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
                    DataTable dt = MENU_MASLogicLayer.GetAllIDWiseMENU_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        TxtCode.Text = dt.Rows[0]["CODE"].ToString();
                        TxtName.Text = dt.Rows[0]["NAME"].ToString();
                       
                        FillDdlRefCode();
                        if (dt.Rows[0]["REF_CODE"].ToString() != string.Empty)
                        {
                            DdlReferenceCode.SelectedValue = dt.Rows[0]["REF_CODE"].ToString();
                        }
                        TxtMenuName.Text = dt.Rows[0]["MENU_NAME"].ToString();
                        TxtMenuOrder.Text = dt.Rows[0]["MENU_ORD"].ToString();

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
                    DataTable dt = MENU_MASLogicLayer.GetAllIDWiseMENU_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        TxtCode.Text = dt.Rows[0]["CODE"].ToString();
                        TxtName.Text = dt.Rows[0]["NAME"].ToString();
                        FillDdlRefCode();
                        if (dt.Rows[0]["REF_CODE"].ToString() != string.Empty)
                        {
                            DdlReferenceCode.SelectedValue = dt.Rows[0]["REF_CODE"].ToString();
                        }
                        TxtMenuName.Text = dt.Rows[0]["MENU_NAME"].ToString();
                        TxtMenuOrder.Text = dt.Rows[0]["MENU_ORD"].ToString();

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
                    MENU_MASLogicLayer insert = new MENU_MASLogicLayer();

                  //  insert.SYSCODE = "";
                    if (TxtCode.Text == string.Empty)
                    {
                        insert.CODE = "0";
                    }
                    else
                    {
                        insert.CODE = TxtCode.Text.Trim();
                    }
                    insert.NAME = TxtName.Text.Trim();
                    insert.REF_CODE = DdlReferenceCode.SelectedValue.Trim().ToUpper();
                    insert.MENU_NAME = TxtMenuName.Text.Trim().ToUpper();

                    if (TxtMenuOrder.Text == string.Empty)
                    {
                        insert.MENU_ORD = "0";
                    }
                    else
                    {
                        insert.MENU_ORD = TxtMenuOrder.Text.Trim();
                    }

                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = MENU_MASLogicLayer.InsertMENU_MASDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "MENU DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid();
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "MENU CODE ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : MENU DETAIL NOT SAVED";
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
                if (TxtCode.Text != string.Empty)
                {
                    string str = MENU_MASLogicLayer.DeleteMENU_MASDetailsByID(TxtCode.Text);
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