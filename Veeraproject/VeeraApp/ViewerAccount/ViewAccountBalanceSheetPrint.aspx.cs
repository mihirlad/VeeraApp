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
    public partial class ViewAccountBalanceSheetPrint : System.Web.UI.Page
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
                    rprt.Load(Server.MapPath("~/ReportAccount/AccountBalanceSheetReport.rpt"));
                    rprt.SetDatabaseLogon("veeradatabase", "Veera@welcome!1");

                    DataSet DsBal = new DataSet();

                    DsBal = AccountReport_Logiclayer.GetACCOUNTS_BalanceSheetForReport(Session["COMP_CODE"].ToString(), Convert.ToDateTime(Session["ON_DATE"].ToString()), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()));
                   
                    rprt.SetDataSource(DsBal.Tables[0]);

                //    rprt.SetParameterValue("Branch_Name", (Session["BRANCH_NAME"].ToString()));

                 
                    CryRptBalanceSheet.ReportSource = rprt;



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
            rprt.PrintToPrinter(1, false, 0, 0);
        }
    }
}