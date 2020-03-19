using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class AccountPartyWiseOSReport : System.Web.UI.Page
    {
        public static string compcode;
        public static string Branchcode;

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
                compcode = Session["COMP_CODE"].ToString();
                Branchcode = Session["BRANCH_CODE"].ToString();

                if (!Page.IsPostBack)
                {
                    if (!string.IsNullOrWhiteSpace(Request.QueryString["MENU_FLAG"]))
                    {
                        HfMenuFlag.Value = Request.QueryString["MENU_FLAG"];
                    }

                    if (HfMenuFlag.Value.ToString() == "AG")
                    {
                        hdForPartyWiseAgeing.Visible = true;
                        hdForPartyWiseOutstanding.Visible = false;
                        tdformatlabel.Visible = true;
                        tdAgeingFormatDdl.Visible = true;



                    }
                    else if (HfMenuFlag.Value.ToString() == "OS")
                    {

                        hdForPartyWiseAgeing.Visible = false;
                        hdForPartyWiseOutstanding.Visible = true;
                        tdformatlabel.Visible = false;
                        tdAgeingFormatDdl.Visible = false;

                    }
                   
                    TxtAsOnDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                    if (Session["USERTYPE"].ToString() == "A")
                    {
                        FillDdlBranchOnCompCode();
                    }
                    else
                    {
                        FillDdlBranchOnBranchCode();
                    }

                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        //** Get BRANCH Name From BRANCH_MAS ***//

        public void FillDdlBranchOnCompCode()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = BRANCH_MASLogicLayer.GetBranchDetailCompanyWiseFor_Ddl(compcode);
                DdlBranch.DataSource = Dt;
                DdlBranch.DataValueField = "BRANCH_CODE";
                DdlBranch.DataTextField = "BRANCH_NAME";
                DdlBranch.DataBind();

                DdlBranch.SelectedValue = Session["BRANCH_CODE"].ToString();
                DdlBranch.Enabled = true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlBranchOnBranchCode()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = BRANCH_MASLogicLayer.GetAllIDWiseBRANCH_MASDetials(Branchcode);
                DdlBranch.DataSource = Dt;
                DdlBranch.DataValueField = "BRANCH_CODE";
                DdlBranch.DataTextField = "BRANCH_NAME";
                DdlBranch.DataBind();
                DdlBranch.Enabled = false;


            }
            catch (Exception)
            {

                throw;
            }
        }


        //** Get Account Name From Account_Master ***//

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetAccountName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ACCOUNTS where COMP_CODE=@COMP_CODE AND BRANCH_CODE=@BRANCH_CODE  AND ANAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            cmd.Parameters.AddWithValue("@BRANCH_CODE", Branchcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> ANames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ANames.Add(dt.Rows[i][2].ToString());
            }
            return ANames;
        }

        protected void TxtAccountName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtAccountName = new DataTable();
                DtAccountName = ACCOUNTS_MASLogicLayer.GetAllACCOUNTDetialsByComapnyAndBranch(compcode, Branchcode);
                if (TxtAccountName.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtAccountName);
                    Dv.RowFilter = "ANAME='" + TxtAccountName.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                    }

                }
                else
                {
                    HfACODE.Value = null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //** Get Person Name From BROKER ***//

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetPersonName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
       //     SqlCommand cmd = new SqlCommand("select * from BROKER where COMP_CODE=@COMP_CODE and BRANCH_CODE=@BRANCH_CODE and BNAME like @BNAME + '%'", con);
            SqlCommand cmd = new SqlCommand("select * from BROKER where COMP_CODE=@COMP_CODE and BNAME like @BNAME + '%'", con);
            cmd.Parameters.AddWithValue("@BNAME", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
       //     cmd.Parameters.AddWithValue("@BRANCH_CODE", Branchcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> BrokerName = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BrokerName.Add(dt.Rows[i][3].ToString());
            }
            return BrokerName;
        }

  
        protected void TxtPersonName_TextChanged(object sender, EventArgs e)
        {

            try
            {
                DataTable DtBrokerName = new DataTable();

              //  DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKER_MASDetialsCompanyWiseFor_DDL(Session["COMP_CODE"].ToString());
                if (TxtPersonName.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtPersonName.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfBCODE.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                    else
                    {
                        HfBCODE.Value = null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void BtnRunReport_Click(object sender, EventArgs e)
        { 
            Session["MENU_FLAG"] = HfMenuFlag.Value.Trim();
            Session["ON_DATE"] = TxtAsOnDate.Text.Trim().ToString();
            Session["ACODE"] = HfACODE.Value.Trim();
            Session["BCODE"] = HfBCODE.Value.Trim();
            Session["VIEW_REPORT"] = DdlViewReport.SelectedValue.Trim().ToString();
            Session["REPORT_FORMAT"] = DdlReportFormat.SelectedValue.Trim().ToString();

            
            if (HfMenuFlag.Value.ToString() == "AG")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountPartyWiseAgeingPrint.aspx', '_blank');", true);
            }
           
            else if (HfMenuFlag.Value.ToString() == "OS")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountPartyWiseOutstandingPrint.aspx', '_blank');", true);
            }
        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }


    }
}