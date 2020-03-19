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
    public partial class DesignationMaster : System.Web.UI.Page
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
                   FillDesignationListMaster();

                    BtnSave.Enabled = true;
                    BtncallUpd.Enabled = false;
                    Btncalldel.Enabled = false;
                }


            }
            else
            {
                Response.Redirect("../Login.aspx");
            }

        }


        public void clear()
        {
            HfDesignCode.Value = string.Empty;
            TxtDesignationName.Text = string.Empty;
            DdlJobCategory.SelectedIndex = 0;
            TxtOrder.Text = string.Empty;
        }

        public void ControllerEnable()
        {
            TxtDesignationName.Enabled = true;
            DdlJobCategory.Enabled = true;
            TxtOrder.Enabled = true;
        }

        public void ControllerDisable()
        {
            TxtDesignationName.Enabled = false;
            DdlJobCategory.Enabled = false;
            TxtOrder.Enabled = true;
        }


        public void FillDesignationListMaster()
        {
            try
            {
                DataTable Dt = new DataTable();

               Dt = DESIGN_MASLogicLayer.GetAllDESIGNATION_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));

                GvDesignationMaster.DataSource = Dt;
                GvDesignationMaster.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvDesignationMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Selecta")
                {
                    #region SELECT
                    clear();
                    DataTable dt = DESIGN_MASLogicLayer.GetAllIDWiseDESIGNATION_MASDetails(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                       
                        HfDesignCode.Value = dt.Rows[0]["DESIGN_CODE"].ToString();
                        TxtDesignationName.Text = dt.Rows[0]["DESIGN_NAME"].ToString();
                        TxtOrder.Text = dt.Rows[0]["DESIGN_ORD"].ToString();
                        DdlJobCategory.SelectedValue = dt.Rows[0]["JOB_CATCODE"].ToString();

                        BtnSave.Enabled = false;
                        BtncallUpd.Enabled = true;
                        Btncalldel.Enabled = true;

                    }
                    #endregion
                }
            }

            catch (Exception ex)
            {

                throw;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DESIGN_MASLogicLayer insert = new DESIGN_MASLogicLayer();

                //insert.DESIGN_CODE = HfDesignCode.Value.Trim();
                insert.DESIGN_NAME = TxtDesignationName.Text.Trim().ToString();
                if(TxtOrder.Text!=string.Empty)
                {
                    insert.DESIGN_ORD = TxtOrder.Text.Trim().ToString();
                }
                else
                {
                    insert.DESIGN_ORD = null;
                }
               
                insert.JOB_CATCODE = DdlJobCategory.SelectedValue.Trim().ToString();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_DATE = "";
                //insert.UPD_USERID = Session["USERNAME"].ToString();
                //insert.UPD_DATE = "";

               string str = DESIGN_MASLogicLayer.InsertDESIGNATION_MAS(insert);

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "DESIGNATION MASTER SAVE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                   FillDesignationListMaster();
                    clear();
                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "DESIGNATION MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : DESIGNATION MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;
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
                DESIGN_MASLogicLayer insert = new DESIGN_MASLogicLayer();

                insert.DESIGN_CODE = HfDesignCode.Value.Trim();
                insert.DESIGN_NAME = TxtDesignationName.Text.Trim().ToString();
                insert.DESIGN_ORD = TxtOrder.Text.Trim().ToString();
                insert.JOB_CATCODE = DdlJobCategory.SelectedValue.Trim().ToString();
                //insert.INS_USERID = Session["USERNAME"].ToString();
                //insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_DATE = "";

               string str = DESIGN_MASLogicLayer.UpdateDESIGNATION_MASDetails(insert);

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "DESIGNATION MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    FillDesignationListMaster();
                    clear();
                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "DESIGNATION MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : DESIGNATION MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;
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
                #region  DELETE  
                if (HfDesignCode.Value != string.Empty)
                {
                    string str = DESIGN_MASLogicLayer.DeleteDESIGNTAION_MASDetaislByID(HfDesignCode.Value.Trim());
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
                        lblmsg.Text = "Error: Designation Master Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    FillDesignationListMaster();
                    clear();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EmployeeMaster.aspx");
        }

        protected void BtnClearData_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}