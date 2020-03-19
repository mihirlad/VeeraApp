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
    public partial class ViewAccountLedgerPrint : System.Web.UI.Page
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
                 Session["FROM_DATE"] != null &&
                 Session["TO_DATE"] != null &&
                 Session["MENU_FLAG"] != null)
                {

                    if (string.IsNullOrEmpty(Session["GROUP_CODE"] as string))
                    {
                        Session["GROUP_CODE"] = "0";
                    }

                    if (string.IsNullOrEmpty(Session["ACODE"] as string))
                    {
                        Session["ACODE"] = "0";
                    }


                    if(Session["MENU_FLAG"].ToString()=="L")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/AccountWiseLedgerReport.rpt"));
                    }
                    else if (Session["MENU_FLAG"].ToString() == "LC")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/AccountWiseLegderConfirmationReport.rpt"));
                    }

                  

                   DataSet ds = new DataSet();
                   ds = AccountReport_Logiclayer.GetAccountsLedgerDeatilsOnPartyNameForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Session["GROUP_CODE"] == null ? "0" : Session["GROUP_CODE"].ToString(), Session["ACODE"] == null ? "0" : Session["ACODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()));

                if ((ds.Tables.Count > 0))
                {

                     rprt.SetDataSource(ds.Tables[0]);
                     rprt.SetParameterValue("fromto", (Session["FROM_DATE"].ToString() + " To " + Session["TO_DATE"].ToString()));
                     CryRptLedger.ReportSource = rprt;

                    

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
            rprt.PrintToPrinter(1, false, 0, 0);
        }
    }
}