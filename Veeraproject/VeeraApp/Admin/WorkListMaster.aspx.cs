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
    public partial class WorkListMaster : System.Web.UI.Page
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
                    FillWorkListMaster(Session["COMP_CODE"].ToString());

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
            TxtWorkDescrption.Text = string.Empty;
            DdlJobCategory.SelectedIndex = 0;
            
        }

        public void ControllerEnable()
        {
            TxtWorkDescrption.Enabled = true;
            DdlJobCategory.Enabled = true;
        }

        public void ControllerDisable()
        {
            TxtWorkDescrption.Enabled = false;
            DdlJobCategory.Enabled = false;
        }

        public void FillWorkListMaster(string CompCode)
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = WORK_LISTMASLogicLayer.GetAllWork_List_MASDetail(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvStockPriceDet.DataSource = Dv.ToTable(); ;
                GvStockPriceDet.DataBind();
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
                WORK_LISTMASLogicLayer insert = new Veera.LogicLayer.WORK_LISTMASLogicLayer();
                insert.COMP_CODE = Session["COMP_CODE"].ToString();
                //  insert.WORK_CODE = HfWorkCode.Value;
                insert.WORK_NAME = TxtWorkDescrption.Text.Trim();
                insert.JOB_CATCODE = DdlJobCategory.SelectedValue.ToString().Trim();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_DATE = "";
                //insert.UPD_USERID = Session["USERNAME"].ToString();
                //insert.UPD_DATE = "";

                string str = WORK_LISTMASLogicLayer.InsertWORK_LISTMAS(insert);

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "WORK LIST MASTER SAVE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    FillWorkListMaster(Session["COMP_CODE"].ToString());
                    clear();
                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "WORK LIST MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : WORK LIST MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void GvStockPriceDet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Selecta")
                {
                    #region SELECT
                    clear();
                    DataTable dt = WORK_LISTMASLogicLayer.GetAllIDWiseWorklistdetails(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfWorkCode.Value = dt.Rows[0]["WORK_CODE"].ToString();
                        TxtWorkDescrption.Text = dt.Rows[0]["WORK_NAME"].ToString();
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

        protected void BtncallUpd_Click(object sender, EventArgs e)
        {
            try
            {
                WORK_LISTMASLogicLayer insert = new Veera.LogicLayer.WORK_LISTMASLogicLayer();
                insert.COMP_CODE = HfCompCode.Value;
                insert.WORK_CODE = HfWorkCode.Value;
                insert.WORK_NAME = TxtWorkDescrption.Text.Trim();
                insert.JOB_CATCODE = DdlJobCategory.SelectedValue.ToString().Trim();
              //  insert.INS_USERID = Session["USERNAME"].ToString();
               // insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_DATE = "";

                string str = WORK_LISTMASLogicLayer.UpdateWORK_LISTMASDetails(insert);

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "WORK LIST MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    FillWorkListMaster(Session["COMP_CODE"].ToString());
                    clear();
                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "WORK LIST MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : WORK LIST MASTER NOT SAVED";
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
                if (HfWorkCode.Value != string.Empty)
                {
                    string str = WORK_LISTMASLogicLayer.DeleteWORKLISTByID(HfWorkCode.Value.Trim());
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
                    FillWorkListMaster(Session["COMP_CODE"].ToString());
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
            Response.Redirect("~/Admin/DailyWorkTimeCard.aspx");
        }

        protected void BtnClearData_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}