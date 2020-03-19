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
    public partial class ViewCashAndBankBookStatementPrint : System.Web.UI.Page
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

                    if (string.IsNullOrEmpty(Session["A_ACODE"] as string))
                    {
                        Session["A_ACODE"] = "0";
                    }

                    DataSet ds = new DataSet();

                    if (Session["MENU_FLAG"].ToString() == "CB")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/AccountCashBookStatementReport.rpt"));

                        ds = AccountReport_Logiclayer.GetACCOUNTS_CashBookStatementDetailsForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE_VALUE"].ToString(), Session["GROUP_CODE"] == null ? "0" : Session["GROUP_CODE"].ToString(), Session["A_ACODE"] == null ? "0" : Session["A_ACODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()));
                    }
                    else if (Session["MENU_FLAG"].ToString() == "BB")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/AccountBankBookStatementReport.rpt"));

                        ds = AccountReport_Logiclayer.GetACCOUNTS_BankBookStatementDetailsForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE_VALUE"].ToString(), Session["GROUP_CODE"] == null ? "0" : Session["GROUP_CODE"].ToString(), Session["A_ACODE"] == null ? "0" : Session["A_ACODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()));
                    }



                    if ((ds.Tables.Count > 0))
                    {

                        rprt.SetDataSource(ds.Tables[0]);
                        rprt.SetParameterValue("Comp_Name", (Session["COMP_NAME"].ToString()));
                        rprt.SetParameterValue("Branch_Name", (Session["BRANCH_NAME"].ToString()));
                        rprt.SetParameterValue("Ins_UserId", (Session["USERNAME"].ToString()));
                        rprt.SetParameterValue("fromto", (Session["FROM_DATE"].ToString() + " To " + Session["TO_DATE"].ToString()));

                        CryRptCashBankBook.Zoom(125);

                        CryRptCashBankBook.ReportSource = rprt;

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