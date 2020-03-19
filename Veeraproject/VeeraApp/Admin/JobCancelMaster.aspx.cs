using MihirValid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class JobCancelMaster : System.Web.UI.Page
    {
        public static string CompCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            CompCode = Session["COMP_CODE"].ToString();
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
                    FillJOB_CANCLEMaster(Session["COMP_CODE"].ToString());
                }


            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        public void clear()
        {
            HfCancelCode.Value = string.Empty;
            HfCompCode.Value = string.Empty;
            TxtCancelDescrption.Text = string.Empty;
        }

        public void ControllerEnable()
        {
            TxtCancelDescrption.Enabled = true;

        }

        public void ControllerDisable()
        {
            TxtCancelDescrption.Enabled = false;

        }

        public void FillJOB_CANCLEMaster(string CompCode)
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = job_cancelmasLogicLayer.GetAllJOB_CANCLE_MASDetail(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvJobCancleDetails.DataSource = Dv.ToTable(); ;
                GvJobCancleDetails.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                job_cancelmasLogicLayer insert = new job_cancelmasLogicLayer();
                insert.comp_code = Session["COMP_CODE"].ToString();                
                insert.cancel_name = TxtCancelDescrption.Text.Trim();                
                insert.ins_userid = Session["USERNAME"].ToString();
                insert.ins_date = "";
                insert.upd_userid = Session["USERNAME"].ToString();
                insert.upd_date = "";

                string str = job_cancelmasLogicLayer.Insertjob_cancelmasDetials(insert);

                if (str.Length <= 8)
                {
                    lblmsg.Text = "JOB CANCLE MASTER SAVE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    FillJOB_CANCLEMaster(Session["COMP_CODE"].ToString());
                    clear();
                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "JOB CANCLE MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : JOB CANCLE MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void BtncallUpd_Click(object sender, EventArgs e)
        {
            try
            {
                job_cancelmasLogicLayer insert = new job_cancelmasLogicLayer();
                insert.comp_code = HfCompCode.Value;
                insert.cancel_code = HfCancelCode.Value;
                insert.cancel_name= TxtCancelDescrption.Text.Trim();                
                //  insert.INS_USERID = Session["USERNAME"].ToString();
                // insert.INS_DATE = "";
                insert.upd_userid= Session["USERNAME"].ToString();
                insert.upd_date = "";

                string str = job_cancelmasLogicLayer.UpdateWORK_LISTMASDetails(insert);

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "JOB CANCLE MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    FillJOB_CANCLEMaster(Session["COMP_CODE"].ToString());
                    clear();
                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "JOB CANCLE MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : JOB CANCLE MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

   

        protected void Btncalldel_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE  
                if (HfCancelCode.Value != string.Empty)
                {
                    string str = job_cancelmasLogicLayer.DeleteWORKLISTByID(HfCancelCode.Value.Trim());
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
                        lblmsg.Text = "Error:Work List Master Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    FillJOB_CANCLEMaster(Session["COMP_CODE"].ToString());
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
            Response.Redirect("~/Admin/JobCardMaster.aspx");
        }

        protected void BtnClearData_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void GvJobCancleDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Selecta")
                {
                    #region SELECT
                    clear();
                    DataTable dt = job_cancelmasLogicLayer.GetAllIDWiseJOBCANCLEdetails(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfCancelCode.Value = dt.Rows[0]["cancel_code"].ToString();
                        TxtCancelDescrption.Text = dt.Rows[0]["cancel_name"].ToString();                        
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}