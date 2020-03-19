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
    public partial class ViewBankReconciliationPrint : System.Web.UI.Page
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
                   Session["ACODE"] != null
                   )

                    
            
                rprt.Load(Server.MapPath("~/ReportAccount/BankReconciliationReport.rpt"));
                rprt.SetDatabaseLogon("veeradatabase", "Veera@welcome!1");

                DataSet ds = new DataSet();
                ds = AccountReport_Logiclayer.GetBankReconciliationDataForReport(Session["COMP_CODE"].ToString(), Session["ACODE"].ToString());
                rprt.SetParameterValue("compyear", (Session["FIN_YEAR"].ToString() + "-" + Session["FIN_YEAR_END"].ToString()));
                 //  rprt.SetParameterValue("ACODE", Convert.ToInt32(Session["ACODE"].ToString()));
                rprt.SetDataSource(ds.Tables[0]);

                CrystalReportBankReconciliation.ReportSource = rprt;


                

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