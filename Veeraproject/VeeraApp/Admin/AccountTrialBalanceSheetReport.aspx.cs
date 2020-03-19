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
    public partial class AccountTrialBalanceSheetReport : System.Web.UI.Page
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
            List<string> GroupName = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GroupName.Add(dt.Rows[i][2].ToString());
            }
            return GroupName;
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


            }
            catch (Exception)
            {

                throw;
            }
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
                    }

                }
                else
                {
                    HfGroupCode.Value = null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnRunReport_Click(object sender, EventArgs e)
        {
            if(HfMenuFlag.Value.ToString()=="OTC")
            {

                Session["ON_DATE"] = TxtAsOnDate.Text.ToString();
                Session["GROUP_CODE"] = HfGroupCode.Value.ToString();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountTrialBalanceSheetPrint1.aspx', '_blank');", true);
            }

            if (HfMenuFlag.Value.ToString() == "C")
            {
                Session["ON_DATE"] = TxtAsOnDate.Text.ToString();
                Session["GROUP_CODE"] = HfGroupCode.Value.ToString();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountTrialBalanceSheetPrint2.aspx', '_blank');", true);

            }

        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }

    }
}