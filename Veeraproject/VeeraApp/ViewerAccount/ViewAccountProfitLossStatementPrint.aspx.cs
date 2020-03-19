using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp.ViewerAccount
{
    public partial class ViewAccountProfitLossPrint : System.Web.UI.Page
    {
        ReportDocument rprt = new ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["COMP_CODE"] != null &&
                 Session["USERCODE"] != null &&
                 Session["USERNAME"] != null &&
                 Session["USERTYPE"] != null &&
                 Session["COMP_CODE"] != null &&
                 Session["COMP_NAME"] != null &&
                 Session["WORK_VIEWFLAG"] != null &&
                 Session["BRANCH_CODE"] != null &&
                 Session["BRANCH_NAME"] != null &&
                 Session["BRANCH_TYPE"] != null &&
                 Session["FIN_YEAR"] != null &&
                 Session["FIN_YEAR_END"] != null &&
                 Session["ON_DATE"] != null)

                {
                    rprt.Load(Server.MapPath("~/ReportAccount/AccountProfitLossStatementReport.rpt"));

                    DataSet ds = new DataSet();
                    ds = AccountReport_Logiclayer.GetACCOUNTS_ProfitAndLossStatementForReport(Session["COMP_CODE"].ToString(), "R", Convert.ToDateTime(Session["ON_DATE"].ToString()), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()));

                    if ((ds.Tables.Count > 0))
                    {

                        rprt.SetDataSource(ds.Tables[0]);

                        rprt.SetParameterValue("Branch_Name", (Session["BRANCH_NAME"].ToString()));

                        CryRptProfitLoss.ReportSource = rprt;
                    }

                }
                else
                {
                    //LOgOut Code
                }
            }
            catch (Exception Ex)
            {

                Response.AppendToLog(Ex.ToString());
            }

        }

        protected void btnprint_Click(object sender, EventArgs e)
        {

        }
    }
}