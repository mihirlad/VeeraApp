using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class AccountOpeningBalanceReport : System.Web.UI.Page
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

                    if(HfMenuFlag.Value.ToString()=="OP")
                    {
                        hdForOpBal.Visible = true;
                        hdForTradingAcc.Visible = false;
                        hdForProftLossAcc.Visible = false;
                        hdForBalanceShret.Visible = false;
                        hdForTrdaingProfitLoss.Visible = false;
                    }
                    else if (HfMenuFlag.Value.ToString() == "TR")
                    {
                        hdForOpBal.Visible = false;
                        hdForTradingAcc.Visible = true;
                        hdForProftLossAcc.Visible = false;
                        hdForBalanceShret.Visible = false;
                        hdForTrdaingProfitLoss.Visible = false;
                    }
                    else if (HfMenuFlag.Value.ToString() == "PL")
                    {
                        hdForOpBal.Visible = false;
                        hdForTradingAcc.Visible = false;
                        hdForProftLossAcc.Visible = true;
                        hdForBalanceShret.Visible = false;
                        hdForTrdaingProfitLoss.Visible = false;
                    }
                    else if (HfMenuFlag.Value.ToString() == "BL")
                    {
                        hdForOpBal.Visible = false;
                        hdForTradingAcc.Visible = false;
                        hdForProftLossAcc.Visible = false;
                        hdForBalanceShret.Visible = true;
                        hdForTrdaingProfitLoss.Visible = false;
                    }
                    else if (HfMenuFlag.Value.ToString() == "TRPL")
                    {
                        hdForOpBal.Visible = false;
                        hdForTradingAcc.Visible = false;
                        hdForProftLossAcc.Visible = false;
                        hdForBalanceShret.Visible = false;
                        hdForTrdaingProfitLoss.Visible = true;
                    }
                    else
                    {

                    }


                        TxtAsOnDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            
                    if(Session["USERTYPE"].ToString()=="A")
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
            
                Dt = BRANCH_MASLogicLayer.GetBranchNameCompanyWiseFor_DdlReport(compcode);
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

        protected void BtnRunReport_Click(object sender, EventArgs e)
        {
            if(HfMenuFlag.Value.ToString()=="OP")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountOpenningBalancePrint.aspx', '_blank');", true);
            }
           
            else if (HfMenuFlag.Value.ToString() == "TR")
            {
                Session["ON_DATE"] = TxtAsOnDate.Text.ToString();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountTradingStatementPrint.aspx', '_blank');", true);
            }
            else if (HfMenuFlag.Value.ToString() == "PL")
            {
                Session["ON_DATE"] = TxtAsOnDate.Text.ToString();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountProfitLossStatementPrint.aspx', '_blank');", true);
            }
            else if (HfMenuFlag.Value.ToString() == "TRPL")
            {
                Session["ON_DATE"] = TxtAsOnDate.Text.ToString();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountTrading_ProfitLosstStatement.aspx', '_blank');", true);

            }
            else if (HfMenuFlag.Value.ToString() == "BL")
            {
                Session["ON_DATE"] = TxtAsOnDate.Text.ToString();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewAccountBalanceSheetPrint.aspx', '_blank');", true);
            }
            else
            {

            }


        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }
    }
}