﻿using CrystalDecisions.CrystalReports.Engine;
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
    public partial class ViewAccountPartyWiseOutstandingPrint : System.Web.UI.Page
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
                Session["VIEW_REPORT"] != null &&
              //  Session["ON_DATE"] != null &&
                Session["MENU_FLAG"] != null &&
                Session["REPORT_FORMAT"]!=null)
                {

                    if (string.IsNullOrEmpty(Session["ACODE"] as string))
                    {
                        Session["ACODE"] = "0";
                    }

                    if (string.IsNullOrEmpty(Session["BCODE"] as string))
                    {
                        Session["BCODE"] = "0";
                    }

                    if(string.IsNullOrEmpty(Session["ON_DATE"] as string))
                    {
                        Session["ON_DATE"] = "1900-01-01 00:00:00.000";
                    }

                    DataSet ds = new DataSet();

                    if (Session["REPORT_FORMAT"].ToString() == "D")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/AccountPartyWiseOutStadingDetailReport.rpt"));

                        ds = AccountReport_Logiclayer.GetACCOUNTS_PartyWise_OutstadingReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["ON_DATE"]), "R", Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), Session["ACODE"] == null ? "0" : Session["ACODE"].ToString(), Session["VIEW_REPORT"].ToString());
                    }
                    else if (Session["REPORT_FORMAT"].ToString() == "S")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/AccountPartyWiseOutStadingSummaryReport.rpt"));

                        ds = AccountReport_Logiclayer.GetACCOUNTS_PartyWise_OutstadingReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["ON_DATE"]), "R", Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), Session["ACODE"] == null ? "0" : Session["ACODE"].ToString(), Session["VIEW_REPORT"].ToString());
                    }

                    else if (Session["REPORT_FORMAT"].ToString() == "L")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/AccountPartyWiseOutStadingLedgerReport.rpt"));

                        ds = AccountReport_Logiclayer.GetACCOUNTS_PartyWise_OutstadingReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["ON_DATE"]), "R", Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), Session["ACODE"] == null ? "0" : Session["ACODE"].ToString(), Session["VIEW_REPORT"].ToString());
                    }

                    else if (Session["REPORT_FORMAT"].ToString() == "PD")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/AccountPartyWiseOutStadingDetailPersonWiseReport.rpt"));

                        ds = AccountReport_Logiclayer.GetACCOUNTS_PartyWise_OutstadingReport_PersonWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["ON_DATE"]), "R", Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), Session["ACODE"] == null ? "0" : Session["ACODE"].ToString(), Session["VIEW_REPORT"].ToString(), Session["BCODE"] == null ? "0" : Session["BCODE"].ToString());
                    }

                    else if (Session["REPORT_FORMAT"].ToString() == "PS")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/AccountPartyWiseOutStadingDetailPersonWiseReport.rpt"));

                        ds = AccountReport_Logiclayer.GetACCOUNTS_PartyWise_OutstadingReport_PersonWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["ON_DATE"]), "R", Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), Session["ACODE"] == null ? "0" : Session["ACODE"].ToString(), Session["VIEW_REPORT"].ToString(), Session["BCODE"] == null ? "0" : Session["BCODE"].ToString());
                    }

                    else if (Session["REPORT_FORMAT"].ToString() == "PL")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/AccountPartyWiseOutStadingDetailPersonWiseReport.rpt"));

                        ds = AccountReport_Logiclayer.GetACCOUNTS_PartyWise_OutstadingReport_PersonWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["ON_DATE"]), "R", Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), Session["ACODE"] == null ? "0" : Session["ACODE"].ToString(), Session["VIEW_REPORT"].ToString(), Session["BCODE"] == null ? "0" : Session["BCODE"].ToString());
                    }



                    //  ds = AccountReport_Logiclayer.GetACCOUNTS_PartyWise_OutstadingReport("101", "508", Convert.ToDateTime("2020-01-11 00:00:00.000"), "R", Convert.ToDateTime("2019-04-01 00:00:00.000"), Convert.ToDateTime("2020-03-31 00:00:00.000"), "403", "C");
                    if ((ds.Tables.Count > 0))
                    {

                        rprt.SetDataSource(ds.Tables[0]);
                        rprt.SetParameterValue("Comp_Name", (Session["COMP_NAME"].ToString()));
                        rprt.SetParameterValue("Branch_Name", (Session["BRANCH_NAME"].ToString()));
                        rprt.SetParameterValue("UserName", (Session["USERNAME"].ToString()));
                        CrysRptOutStanding.Zoom(150);
                        CrysRptOutStanding.ReportSource = rprt;

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