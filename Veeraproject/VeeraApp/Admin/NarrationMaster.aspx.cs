using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class NarrationMaster : System.Web.UI.Page
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
                   // FillWorkListMaster(Session["COMP_CODE"].ToString());

                    BtnSave.Enabled = true;
                    Btncalldel.Enabled = false;
                    FillNarrationMaster(Session["COMP_CODE"].ToString());
                }


            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }


        public void FillNarrationMaster(string CompCode)
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = NARRATIONLogicLayer.GetAllNarrationDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                GvNarrationDetails.DataSource = Dv.ToTable(); ;
                GvNarrationDetails.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void clear()
        {
            TxtNarrations.Text = string.Empty;
           
        }

        public void ControllerEnable()
        {
            TxtNarrations.Enabled = true;
        }

        public void ControllerDisable()
        {
            TxtNarrations.Enabled = false;
        }


        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("Insert into NARRATION(NARRN)Values('" + TxtNarrations.Text.Trim() + "')", con);
                int x = Convert.ToInt32(cmd.ExecuteScalar());
                if (x == 0)
                {
                    lblmsg.Text = "NARRATION NOT SAVED.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "NARRATION SAVE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    FillNarrationMaster(Session["COMP_CODE"].ToString());
                    clear();
                }

                con.Close();
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
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("Delete From NARRATION where NARRN ='" + TxtNarrations.Text.Trim() + "' ", con);
                int x = Convert.ToInt32(cmd.ExecuteScalar());
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

        protected void GvNarrationDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Selecta")
                {
                    #region SELECT
                    clear();
                    DataTable dt = NARRATIONLogicLayer.GetAllIDWiseNarrationsDetails(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                   
                        TxtNarrations.Text = dt.Rows[0]["NARRN"].ToString();

                        BtnSave.Enabled = false;
                        Btncalldel.Enabled = true;

                    }
                    #endregion
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}