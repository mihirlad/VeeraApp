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
    public partial class CategoryMaster : System.Web.UI.Page
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
                    FillEmployeeCATEGORYMaster();

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
            HfCategoryCode.Value = string.Empty;
            TxtCategoryName.Text = string.Empty;
            TxtOrder.Text = string.Empty;
        }

        public void ControllerEnable()
        {
            TxtCategoryName.Enabled = true;
            TxtOrder.Enabled = true;
        }

        public void ControllerDisable()
        {
            TxtCategoryName.Enabled = false;
            TxtOrder.Enabled = true;
        }

        public void FillEmployeeCATEGORYMaster()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = CATAGORY_MASLogicLayer.GetAllEmployeeCategory_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));

                GvCategoryMaster.DataSource = Dt;
                GvCategoryMaster.DataBind();
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
                CATAGORY_MASLogicLayer insert = new CATAGORY_MASLogicLayer();

                //insert.CAT_CODE = HfCategoryCode.Value.Trim();
                insert.CAT_NAME = TxtCategoryName.Text.Trim().ToString();
                if(TxtOrder.Text!=string.Empty)
                {
                    insert.ORD_NO = TxtOrder.Text.Trim();
                }
                else
                {
                    insert.ORD_NO = null;
                }
                
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_DATE = "";
                //insert.UPD_USERID = Session["USERNAME"].ToString();
                //insert.UPD_DATE = "";


                string str = CATAGORY_MASLogicLayer.InsertEmployeeCategory_MAS(insert);

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "EMPLOYEE CATEGORY MASTER SAVE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    FillEmployeeCATEGORYMaster();
                    clear();
                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "EMPLOYEE CATEGORY MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR :EMPLOYEE CATEGORY MASTER NOT SAVED";
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

                CATAGORY_MASLogicLayer insert = new CATAGORY_MASLogicLayer();

                insert.CAT_CODE = HfCategoryCode.Value.Trim();
                insert.CAT_NAME = TxtCategoryName.Text.Trim().ToString();
                if (TxtOrder.Text != string.Empty)
                {
                    insert.ORD_NO = TxtOrder.Text.Trim();
                }
                else
                {
                    insert.ORD_NO = null;
                }

                //insert.INS_USERID = Session["USERNAME"].ToString();
                //insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_DATE = "";


                string str = CATAGORY_MASLogicLayer.UpdateEmployeeCategory_MASDetails(insert);

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "EMPLOYEE CATEGORY MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    FillEmployeeCATEGORYMaster();
                    clear();
                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "EMPLOYEE CATEGORY MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR :EMPLOYEE CATEGORY MASTER NOT SAVED";
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
                if (HfCategoryCode.Value != string.Empty)
                {
                    string str = CATAGORY_MASLogicLayer.DeleteEmployeeCategory_MASDetialByID(HfCategoryCode.Value.Trim());
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
                        lblmsg.Text = "Error:Employee Category Master Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    FillEmployeeCATEGORYMaster();
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
            Response.Redirect("~/Admin/Dashboard.aspx");
        }

        protected void BtnClearData_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void GvCategoryMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Selecta")
                {
                    #region SELECT
                    clear();
                    DataTable dt = CATAGORY_MASLogicLayer.GetAllIDWiseEmployeeCategory_MASDetails(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        HfCategoryCode.Value = dt.Rows[0]["CAT_CODE"].ToString();
                        TxtCategoryName.Text = dt.Rows[0]["CAT_NAME"].ToString();
                        TxtOrder.Text = dt.Rows[0]["ORD_NO"].ToString();
                      
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
    }
}