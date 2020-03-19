using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class HSNCodeMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if  (Session["USERCODE"] != null &&
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

            TxtHsnNo.Enabled = true;
            TxtProductName.Enabled = true;
        }

        public void ControllerDisable()
        {

            TxtHsnNo.Enabled = false;
            TxtProductName.Enabled = false;
        }
        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfCompCode.Value = string.Empty;
            HfHsnCode.Value = string.Empty;
            TxtHsnNo.Text = string.Empty;
            TxtProductName.Text = string.Empty;

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
                HSNCODE_MASLogicLayer insert = new HSNCODE_MASLogicLayer();
                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.HSN_CODE = HfHsnCode.Value.Trim();

                if (TxtHsnNo.Text == string.Empty)
                {
                    insert.HSN_NO = "0";
                }
                else
                {
                    insert.HSN_NO = TxtHsnNo.Text.Trim();
                }
                insert.HSN_DESC = TxtProductName.Text.Trim().ToUpper();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                //    insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                //    insert.UPD_DATE = "";

                #endregion
                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = HSNCODE_MASLogicLayer.InsertHSNCODE_MASDetials(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "HSN CODE DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(Session["COMP_CODE"].ToString());
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "HSN CODE MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : HSN CODE DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }

                }
                else
                {
                    string str = HSNCODE_MASLogicLayer.UpdateHSNCODE_MASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "HSN CODE DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(Session["COMP_CODE"].ToString());
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "HSN CODE MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : HSN CODE DETAIL NOT SAVED";
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

                Dt = HSNCODE_MASLogicLayer.GetAllHSNCODE_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvHsnCodeMaster.DataSource = Dv.ToTable();
                GvHsnCodeMaster.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvHsnCodeMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvHsnCodeMaster.PageIndex = e.NewPageIndex;
                FillGrid(Session["COMP_CODE"].ToString());
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvHsnCodeMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataTable dt = HSNCODE_MASLogicLayer.GetAllIDWiseHSNCODE_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfHsnCode.Value = dt.Rows[0]["HSN_CODE"].ToString();
                        TxtHsnNo.Text = dt.Rows[0]["HSN_NO"].ToString();
                        TxtProductName.Text = dt.Rows[0]["HSN_DESC"].ToString();
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
                    DataTable dt = HSNCODE_MASLogicLayer.GetAllIDWiseHSNCODE_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfHsnCode.Value = dt.Rows[0]["HSN_CODE"].ToString();
                        TxtHsnNo.Text = dt.Rows[0]["HSN_NO"].ToString();
                        TxtProductName.Text = dt.Rows[0]["HSN_DESC"].ToString();


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
                    DataTable dt = HSNCODE_MASLogicLayer.GetAllIDWiseHSNCODE_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfHsnCode.Value = dt.Rows[0]["HSN_CODE"].ToString();
                        TxtHsnNo.Text = dt.Rows[0]["HSN_NO"].ToString();
                        TxtProductName.Text = dt.Rows[0]["HSN_DESC"].ToString();

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
                    HSNCODE_MASLogicLayer insert = new HSNCODE_MASLogicLayer();
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.HSN_CODE = HfHsnCode.Value.Trim();

                    if (TxtHsnNo.Text == string.Empty)
                    {
                        insert.HSN_NO = "0";
                    }
                    else
                    {
                        insert.HSN_NO = TxtHsnNo.Text.Trim();
                    }
                    insert.HSN_DESC = TxtProductName.Text.Trim().ToUpper();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";

                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = HSNCODE_MASLogicLayer.InsertHSNCODE_MASDetials(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "HSN CODE DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid(Session["COMP_CODE"].ToString());
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "HSN CODE MASTER ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : HSN CODE DETAIL NOT SAVED";
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
                if (HfHsnCode.Value != string.Empty)
                {
                    string str = HSNCODE_MASLogicLayer.DeleteHSNCODE_MASDetialsByID(HfHsnCode.Value);
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
                        lblmsg.Text = "Error:HSN Code Not Deleted";
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