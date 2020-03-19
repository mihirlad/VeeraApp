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
    public partial class MiscellaneousStatementReport : System.Web.UI.Page
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

                    if (HfMenuFlag.Value.ToString() == "DLT")
                    {
                        h1.Visible = true;
                        h2.Visible = false;
                        h3.Visible = false;
                        h4.Visible = false;
                        h5.Visible = false;
                        h6.Visible = false;
                        h7.Visible = false;

                        trUserName.Visible = false;
                        trAccountGroupName.Visible = false;
                        trViewReport.Visible = false;
                        trFromToDate.Visible = true;
                    }
                    else if (HfMenuFlag.Value.ToString() == "DFT")
                    {
                        h1.Visible = false;
                        h2.Visible = true;
                        h3.Visible = false;
                        h4.Visible = false;
                        h5.Visible = false;
                        h6.Visible = false;
                        h7.Visible = false;

                        trUserName.Visible = false;
                        trAccountGroupName.Visible = false;
                        trViewReport.Visible = false;
                        trFromToDate.Visible = true;
                    }

                    else if (HfMenuFlag.Value.ToString() == "AL")
                    {
                        h1.Visible = false;
                        h2.Visible = false;
                        h3.Visible = true;
                        h4.Visible = false;
                        h5.Visible = false;
                        h6.Visible = false;
                        h7.Visible = false;

                        trUserName.Visible = false;
                        trAccountGroupName.Visible = true;
                        trFromToDate.Visible = false;
                        trViewReport.Visible = false;
                    }

                    else if (HfMenuFlag.Value.ToString() == "ALL")
                    {
                        h1.Visible = false;
                        h2.Visible = false;
                        h3.Visible = false;
                        h4.Visible = true;
                        h5.Visible = false;
                        h6.Visible = false;
                        h7.Visible = false;

                        trUserName.Visible = false;
                        trAccountGroupName.Visible = true;
                        trFromToDate.Visible = false;
                        trViewReport.Visible = false;
                    }

                    else if (HfMenuFlag.Value.ToString() == "CCL")
                    {
                        h1.Visible = false;
                        h2.Visible = false;
                        h3.Visible = false;
                        h4.Visible = false;
                        h5.Visible = true;
                        h6.Visible = false;
                        h7.Visible = false;

                        trUserName.Visible = false;
                        trAccountGroupName.Visible = false;
                        trFromToDate.Visible = false;
                        trViewReport.Visible = true;

                    }

                    else if (HfMenuFlag.Value.ToString() == "SCL")
                    {
                        h1.Visible = false;
                        h2.Visible = false;
                        h3.Visible = false;
                        h4.Visible = false;
                        h5.Visible = false;
                        h6.Visible = true;
                        h7.Visible = false;

                        trUserName.Visible = false;
                        trAccountGroupName.Visible = false;
                        trFromToDate.Visible = false;
                        trViewReport.Visible = true;


                    }

                    else if (HfMenuFlag.Value.ToString() == "ULD")
                    {
                        h1.Visible = false;
                        h2.Visible = false;
                        h3.Visible = false;
                        h4.Visible = false;
                        h5.Visible = false;
                        h6.Visible = false;
                        h7.Visible = true;

                        trUserName.Visible = true;
                        trAccountGroupName.Visible = false;
                        trFromToDate.Visible = true;
                        trViewReport.Visible = false;
                    }

                    TxtFromDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                    TxtToDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

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


        //** Get USER NAME From USER_MAS ***//

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string>GetUserName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from USER_MAS WHERE USERNAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> UserName = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserName.Add(dt.Rows[i][1].ToString());
            }
            return UserName;
        }


        //** Get Group Name From Group_Master ***//

        static int Group_Code = 0;

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetAccountGroupName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from GROUP_MAS WHERE GROUP_NAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> Narration = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Narration.Add(dt.Rows[i][2].ToString());
            }
            return Narration;
        }

        protected void TxtAccountGroupName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtGroup = new DataTable();
                DtGroup = GROUP_MASLogicLayer.GetAllGROUP_MASDetials_DDL();
                if (TxtAccountGroupName.Text != string.Empty && TxtAccountGroupName.Text != null)
                {
                    DataView Dv = new DataView(DtGroup);
                    Dv.RowFilter = "GROUP_NAME='" + TxtAccountGroupName.Text.Trim().ToString() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfGroupCode.Value = DtView.Rows[0]["GROUP_CODE"].ToString();
                        Group_Code = Convert.ToInt32(DtView.Rows[0]["GROUP_CODE"].ToString());
                    }
                    else
                    {
                        Group_Code = 0;
                    }

                }
                else
                {
                    HfGroupCode.Value = null;
                    Group_Code = 0;
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
            Session["FROM_DATE"] = TxtFromDate.Text.Trim().ToString();
            Session["TO_DATE"] = TxtToDate.Text.Trim().ToString();
            Session["GROUP_CODE"] = HfGroupCode.Value.Trim();
            Session["VIEW_REPORT"] = DdlReportView.SelectedValue.Trim().ToString();

            if (HfMenuFlag.Value.ToString() == "DLT")
            {
               // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountPartyWiseAgeingPrint.aspx', '_blank');", true);
            }

            if (HfMenuFlag.Value.ToString() == "DFT")
            {
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountPartyWiseAgeingPrint.aspx', '_blank');", true);
            }

            if (HfMenuFlag.Value.ToString() == "ALL")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountMiscellaneousStatementPrint.aspx', '_blank');", true);
            }

            if (HfMenuFlag.Value.ToString() == "AL")
            {
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountMiscellaneousStatementPrint.aspx', '_blank');", true);
            }

            if (HfMenuFlag.Value.ToString() == "CCL")
            {
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountMiscellaneousStatementPrint.aspx', '_blank');", true);
            }

            if (HfMenuFlag.Value.ToString() == "SCL")
            {
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountMiscellaneousStatementPrint.aspx', '_blank');", true);
            }

            if (HfMenuFlag.Value.ToString() == "ULD")
            {
                Session["USER_LOGIN_NAME"] = TxtUserName.Text.Trim().ToString();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountMiscellaneousStatementPrint.aspx', '_blank');", true);
            }
        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }
    }
}