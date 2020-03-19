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
    public partial class ViewAccountTrialBalanceSheetPrint1 : System.Web.UI.Page
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


                    if (string.IsNullOrEmpty(Session["GROUP_CODE"] as string))
                    {
                        Session["GROUP_CODE"] = "0";//Session["GROUP_CODE"] == null ? "0" : 
                    }

                    rprt.Load(Server.MapPath("~/ReportAccount/AccountTrialBalanceStatementReport1.rpt"));

                    DataSet ds = new DataSet();
                    //String? GRP_CODE = null;
                    ds = AccountReport_Logiclayer.GetACCOUNTS_TrialBalanceForReport1(Session["COMP_CODE"].ToString(), "R", Session["GROUP_CODE"] == null ? "0" : Session["GROUP_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["ON_DATE"].ToString()), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()));
                    if (ds.Tables.Count > 0)
                    {
                        rprt.SetDataSource(ds.Tables[0]);

                        rprt.SetParameterValue("Branch_Name", (Session["BRANCH_NAME"].ToString()));
                        rprt.SetParameterValue("FromToDate", (Convert.ToDateTime(Session["FIN_YEAR"].ToString())).ToString("dd/MM/yyyy") + " To :" + (Convert.ToDateTime(Session["FIN_YEAR_END"].ToString())).ToString("dd/MM/yyyy")); 
                        rprt.SetParameterValue("INS_USERID", (Session["USERNAME"].ToString()));

                        CryRptTrialBalanaceSheet.ReportSource = rprt;
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