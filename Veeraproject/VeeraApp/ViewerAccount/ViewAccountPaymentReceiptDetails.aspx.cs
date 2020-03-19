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
    public partial class View_AccountPaymentReceiptDetails : System.Web.UI.Page
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

                    rprt.Load(Server.MapPath("~/ReportAccount/AccountPaymentsReceiptDetailsReport.rpt"));

                    DataSet ds = new DataSet();
                    ds = AccountReport_Logiclayer.GetACCOUNTS_PaymentReceiptDetailsForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE_VALUE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["A_ACODE"] == null ? "0" : Session["A_ACODE"].ToString(), Session["P_ACODE"] == null ? "0" : Session["P_ACODE"].ToString(),Session["TRAN_TYPE"].ToString());

                    if ((ds.Tables.Count > 0))
                    {

                        rprt.SetDataSource(ds.Tables[0]);

                        rprt.SetParameterValue("Branch_Name", (Session["BRANCH_NAME"].ToString()));
                        rprt.SetParameterValue("UserName", (Session["USERNAME"].ToString()));

                        CryRptPayRecDetails.ReportSource = rprt;
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