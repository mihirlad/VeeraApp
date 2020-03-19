using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp.ViewerInventory
{
    public partial class ViewDeliveryChallanWithDetailsPrint : System.Web.UI.Page
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
                    Session["TRAN_TYPE"] != null &&
                    Session["TRN_TYPE"] != null &&
                    Session["REPORT_TYPE"] != null)
                {


                    if (Session["TRAN_TYPE"].ToString() == "D" && Session["TRN_TYPE"].ToString() == "P" && Session["REPORT_TYPE"].ToString() == "DT_WS_DETAILS")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/DCDetailsDateWisePurchaseReport.rpt"));
                    }
                    else if (Session["TRAN_TYPE"].ToString() == "D" && Session["TRN_TYPE"].ToString() == "S" && Session["REPORT_TYPE"].ToString() == "DT_WS_DETAILS")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/DCDetailsDateWiseSalesReport.rpt"));
                    }

                    else if (Session["TRAN_TYPE"].ToString() == "D" && Session["TRN_TYPE"].ToString() == "P" && Session["REPORT_TYPE"].ToString() == "PT_WS_DETAILS")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/DCDetailsPartyWisePurchaseReport.rpt"));
                    }

                    else if (Session["TRAN_TYPE"].ToString() == "D" && Session["TRN_TYPE"].ToString() == "S" && Session["REPORT_TYPE"].ToString() == "PT_WS_DETAILS")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/DCDetailsPartyWiseSalesReport.rpt"));
                    }



                    if (string.IsNullOrEmpty(Session["ACODE"] as string))
                    {
                        Session["ACODE"] = "0";
                    }


                    rprt.SetDatabaseLogon("veeradatabase", "Veera@welcome!1");

                    DataSet ds = new DataSet();
                    DataSet Subds = new DataSet();
                    DataTable Dt = new DataTable();

                    ds = InventoryReport_Logiclayer.GetINVENTORY_DC_MAS_DateWiseChallanForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE_VALUE"].ToString(), Session["ACODE"].ToString() == null ? "0" : Session["ACODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["TRAN_TYPE"].ToString(), Session["TRN_TYPE"].ToString(), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString());

                    Subds = InventoryReport_Logiclayer.GetINVENTORY_DC_MAS_Detail_DateWiseChallanForSubReport(Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString());

                    string HeadingRpt = "[ALL CHALLAN]";
                    Dt = ds.Tables[0];
                    DataView Dv = new DataView(Dt);
                    string FilterStr = string.Empty;

                    if (Session["VIEW_REPORT"].ToString() == "CNF" || Session["VIEW_REPORT"].ToString() == "NCNF")
                    {
                        if (Session["VIEW_REPORT"].ToString() == "CNF")
                        {
                            FilterStr = "ConfirmFlag='YES'";
                            HeadingRpt = "[CONFIRM CHALLAN]";
                        }
                        else
                        {
                            FilterStr = "ConfirmFlag='NO'";
                            HeadingRpt = "[NON-CONFIRM CHALLAN]";
                        }
                    }
                    else if (Session["VIEW_REPORT"].ToString() == "GBC" || Session["VIEW_REPORT"].ToString() == "NGB")
                    {
                        FilterStr = "GenerateBillFlag='" + Session["VIEW_REPORT"].ToString() + "'";
                        HeadingRpt = "[GENERATE BILL]";
                        if (Session["VIEW_REPORT"].ToString().Contains("N"))
                        {
                            HeadingRpt = "[NON-GENERATE BILL]";
                        }
                    }
                    else if (Session["VIEW_REPORT"].ToString() == "F" || Session["VIEW_REPORT"].ToString() == "C" || Session["VIEW_REPORT"].ToString() == "T")
                    {
                        FilterStr = "DC_TYPE='" + Session["VIEW_REPORT"].ToString() + "'";
                        HeadingRpt = "[FOC CHALLAN]";

                        if (Session["VIEW_REPORT"].ToString().Contains("C"))
                        {
                            HeadingRpt = "[CANCEL CHALLAN]";
                        }
                        else if (Session["VIEW_REPORT"].ToString().Contains("T"))
                        {
                            HeadingRpt = "[RETURNABLE CHALLAN]";
                        }


                    }
                    if (FilterStr != string.Empty)
                    {
                        Dv.RowFilter = FilterStr;
                    }
                    //ConfirmFlag DC_TYPE GenerateBillFlag
                    DataTable Dt1 = new DataTable();
                    Dt1 = Dv.ToTable();
                    rprt.SetDataSource(Dt1);

                    rprt.Subreports[0].SetDataSource(Subds.Tables[0]);

                    rprt.SetParameterValue("Comp_Name", (Session["COMP_NAME"].ToString()));
                    rprt.SetParameterValue("Branch_Name", (Session["BRANCH_NAME"].ToString()));
                    rprt.SetParameterValue("UserName", (Session["USERNAME"].ToString()));
                    rprt.SetParameterValue("FromToDate", Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("dd-MM-yyyy") + " To " + Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("dd-MM-yyyy"));
                    rprt.SetParameterValue("View_Report", HeadingRpt);


                    CryRptDCDetails.Zoom(120);

                    CryRptDCDetails.ReportSource = rprt;




                }
                else
                {
                    //LOgout Code
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