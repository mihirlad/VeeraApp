using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraProject2019.ViewerAccount
{
    public partial class ViewAccountCreditDebitNoteStatementPrint : System.Web.UI.Page
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
                Session["VIEW_REPORT"] != null &&
                Session["MENU_FLAG"] != null &&
                Session["TRAN_TYPE"] != null)
                {

                    if (string.IsNullOrEmpty(Session["A_ACODE"] as string))
                    {
                        Session["A_ACODE"] = "0";
                    }

                    if (string.IsNullOrEmpty(Session["P_ACODE"] as string))
                    {
                        Session["P_ACODE"] = "0";
                    }

                    rprt.Load(Server.MapPath("~/ReportAccount/CreditDebitNoteStatementReport.rpt"));
             
                    DataSet ds = new DataSet();
               
                ds = AccountReport_Logiclayer.GetACCOUNTS_JournalVoucherAndCreditNoteDebitStatementForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE_VALUE"].ToString(), Session["TRAN_TYPE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["P_ACODE"].ToString());
                if ((ds.Tables.Count > 0))
                {

                        rprt.SetDataSource(ds.Tables[0]);

                        rprt.SetParameterValue("Branch_Name", (Session["BRANCH_NAME"].ToString()));
                        rprt.SetParameterValue("UserName", (Session["USERNAME"].ToString()));

                        CryRptCreditDebitNote.Zoom(100);
                        CryRptCreditDebitNote.ReportSource = rprt;



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