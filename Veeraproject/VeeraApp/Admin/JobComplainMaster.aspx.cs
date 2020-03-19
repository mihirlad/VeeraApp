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
    public partial class JobComplainMaster : System.Web.UI.Page
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


                    if (!string.IsNullOrWhiteSpace(Request.QueryString["BRANDTYPE_CODE"]) && !string.IsNullOrWhiteSpace(Request.QueryString["COMP_CODE"]))
                    {
                        HfCompCode.Value = Request.QueryString["COMP_CODE"];
                        HfBrandTypeCode.Value = Request.QueryString["BRANDTYPE_CODE"];
                    }
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
        public void ControllerEnable()
        {
            TxtComplainDescription.Enabled = true;
            TxtComplainChecklist.Enabled = true;
        }

        public void ControllerDisable()
        {
            TxtComplainDescription.Enabled = false;
            TxtComplainChecklist.Enabled = false;
        }
        public void clear()
        {

            DivEntry.Visible = false;
            DivView.Visible = true;

            HfCompCode.Value = string.Empty;
            HfComplainCode.Value = string.Empty;
            TxtComplainDescription.Text = string.Empty;
            TxtComplainChecklist.Text = string.Empty;


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
            Response.Redirect("~/Admin/StockBrandTypeMaster.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region INSERT JOB COMPLAIN MASTER MASTER 

                JOB_COMPMASLogicLayer insert = new JOB_COMPMASLogicLayer();
                insert.COMP_CODE = Session["COMP_CODE"].ToString();
                insert.COMPLAIN_CODE = HfComplainCode.Value.Trim();
                insert.BRANDTYPE_CODE = HfBrandTypeCode.Value.Trim();
                insert.COMPLAIN_DESC = TxtComplainDescription.Text.Trim().ToUpper();
                insert.COMPLAIN_CHECK = TxtComplainChecklist.Text.Trim().ToUpper();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";
                #endregion

                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = JOB_COMPMASLogicLayer.InsertJOB_COMPLAIN_MASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "COMPALIN MASTER DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(Session["COMP_CODE"].ToString());
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "COMPLAIN CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : COMPLAIN MASTER DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                        string str = JOB_COMPMASLogicLayer.UpdateJOB_COMPLAIN_MASDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "COMPALIN MASTER DETAIL UPDATE SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid(Session["COMP_CODE"].ToString());
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "COMPLAIN CODE ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : COMPLAIN MASTER DETAIL NOT SAVED";
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

                Dt = JOB_COMPMASLogicLayer.GetAllJOB_COMPLAIN_MASDetails(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvJobComplainMaster.DataSource = Dv.ToTable();
                GvJobComplainMaster.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvJobComplainMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvJobComplainMaster.PageIndex = e.NewPageIndex;
                FillGrid(Session["COMP_CODE"].ToString());
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvJobComplainMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataTable dt = JOB_COMPMASLogicLayer.GetAllIDWiseJOB_COMPLAIN_MASDetail(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfBrandTypeCode.Value = dt.Rows[0]["BRANDTYPE_CODE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfComplainCode.Value = dt.Rows[0]["COMPLAIN_CODE"].ToString();
                        TxtComplainDescription.Text = dt.Rows[0]["COMPLAIN_DESC"].ToString();
                        TxtComplainChecklist.Text = dt.Rows[0]["COMPLAIN_CHECK"].ToString();
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
                    DataTable dt = JOB_COMPMASLogicLayer.GetAllIDWiseJOB_COMPLAIN_MASDetail(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfBrandTypeCode.Value = dt.Rows[0]["BRANDTYPE_CODE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfComplainCode.Value = dt.Rows[0]["COMPLAIN_CODE"].ToString();
                        TxtComplainDescription.Text = dt.Rows[0]["COMPLAIN_DESC"].ToString();
                        TxtComplainChecklist.Text = dt.Rows[0]["COMPLAIN_CHECK"].ToString();


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
                    DataTable dt = JOB_COMPMASLogicLayer.GetAllIDWiseJOB_COMPLAIN_MASDetail(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfBrandTypeCode.Value = dt.Rows[0]["BRANDTYPE_CODE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfComplainCode.Value = dt.Rows[0]["COMPLAIN_CODE"].ToString();
                        TxtComplainDescription.Text = dt.Rows[0]["COMPLAIN_DESC"].ToString();
                        TxtComplainChecklist.Text = dt.Rows[0]["COMPLAIN_CHECK"].ToString();


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
                    #region INSERT JOB COMPLAIN MASTER MASTER 

                    JOB_COMPMASLogicLayer insert = new JOB_COMPMASLogicLayer();
                    insert.COMP_CODE= Session["COMP_CODE"].ToString();
                    insert.COMPLAIN_CODE = HfComplainCode.Value.Trim();
                    insert.BRANDTYPE_CODE = HfBrandTypeCode.Value.Trim();
                    insert.COMPLAIN_DESC = TxtComplainDescription.Text.Trim().ToUpper();
                    insert.COMPLAIN_CHECK = TxtComplainChecklist.Text.Trim().ToUpper();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";
                    #endregion

                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = JOB_COMPMASLogicLayer.InsertJOB_COMPLAIN_MASDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "COMPALIN MASTER DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid(Session["COMP_CODE"].ToString());
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "COMPLAIN CODE ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : COMPLAIN MASTER DETAIL NOT SAVED";
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
                if (HfComplainCode.Value != string.Empty)
                {
                    string str = JOB_COMPMASLogicLayer.DeleteJOB_COMPLAIN_MASDetailByID(HfComplainCode.Value);
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
                        lblmsg.Text = "Error:Complain Master Not Deleted";
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