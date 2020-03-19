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
    public partial class ViewBranchTransactionStockReceivedPrintReport : System.Web.UI.Page
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
                    Session["REPORT_TYPE"] != null)
                {


                    if (string.IsNullOrEmpty(Session["SCODE"] as string))
                    {
                        Session["SCODE"] = "0";
                    }

                    if (string.IsNullOrEmpty(Session["CAT_CODE"] as string))
                    {
                        Session["CAT_CODE"] = "0";
                    }


                    DataSet ds = new DataSet();
                    DataSet dsSub = new DataSet();
                    DataTable Dt = new DataTable();
                    string HeadingRpt = "[ALL CHALLAN]";

                    if (Session["REPORT_TYPE"].ToString() == "DT_WS")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/BranchReceivedRegister_DateWiseReport.rpt"));

                        Session["BRANCH_CODE_VALUE"].ToString();

                        ds = InventoryReport_Logiclayer.GetBRANCH_RECEIVED_STK_RECMASFor_MainReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE_VALUE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["TRAN_TYPE"].ToString(), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString());

                        // Check ReceivedFlag REC_FLAG From MasterTable

                        Dt = ds.Tables[0];
                        DataView Dv = new DataView(Dt);
                        string FilterStr = string.Empty;
                       
                        if (Session["VIEW_REPORT"].ToString() == "CNF" || Session["VIEW_REPORT"].ToString() == "NCNF")
                        {
                            if (Session["VIEW_REPORT"].ToString() == "CNF")
                            {
                                FilterStr = "REC_FLAG='Yes'";
                                HeadingRpt = "[RECEIVED CHALLAN]";
                            }
                            else
                            {
                                FilterStr = "REC_FLAG='No'";
                                HeadingRpt = "[NON-RECEIVED CHALLAN]";
                            }
                        }

                        if (FilterStr != string.Empty)
                        {
                            Dv.RowFilter = FilterStr;
                        }                       

                        DataTable Dt1 = new DataTable();
                        Dt1 = Dv.ToTable();

                        // end                       

                        rprt.SetDataSource(Dt1);

                        rprt.SetParameterValue("Comp_Name", (Session["COMP_NAME"].ToString()));
                        rprt.SetParameterValue("Branch_Name", (Session["BRANCH_NAME"].ToString()));
                        rprt.SetParameterValue("UserName", (Session["USERNAME"].ToString()));
                        rprt.SetParameterValue("FromToDate", Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("dd-MM-yyyy") + " To " + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).ToString("dd-MM-yyyy"));
                        rprt.SetParameterValue("View_Report", HeadingRpt);

                    }

                    else if (Session["REPORT_TYPE"].ToString() == "DT_WS_DET")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/BranchReceivedRegisterDetails_DateWiseReport.rpt"));

                        Session["BRANCH_CODE_VALUE"].ToString();

                        ds = InventoryReport_Logiclayer.GetBRANCH_RECEIVED_STK_RECMASFor_MainReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE_VALUE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["TRAN_TYPE"].ToString(), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString());

                        dsSub = InventoryReport_Logiclayer.GetBRANCH_RECEIVED_STK_RECMASFor_SubReport(Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString());


                       // Check ReceivedFlag REC_FLAG From MasterTable

                        Dt = ds.Tables[0];
                        DataView Dv = new DataView(Dt);
                        string FilterStr = string.Empty;

                        if (Session["VIEW_REPORT"].ToString() == "CNF" || Session["VIEW_REPORT"].ToString() == "NCNF")
                        {
                            if (Session["VIEW_REPORT"].ToString() == "CNF")
                            {
                                FilterStr = "REC_FLAG='Yes'";
                                HeadingRpt = "[RECEIVED CHALLAN]";
                            }
                            else
                            {
                                FilterStr = "REC_FLAG='No'";
                                HeadingRpt = "[NON-RECEIVED CHALLAN]";
                            }
                        }

                        if (FilterStr != string.Empty)
                        {
                            Dv.RowFilter = FilterStr;
                        }

                        DataTable Dt1 = new DataTable();
                        Dt1 = Dv.ToTable();

                        // end

                      
                        rprt.SetDataSource(Dt1);

                        rprt.Subreports[0].SetDataSource(dsSub.Tables[0]);

                        rprt.SetParameterValue("Comp_Name", (Session["COMP_NAME"].ToString()));
                        rprt.SetParameterValue("Branch_Name", (Session["BRANCH_NAME"].ToString()));
                        rprt.SetParameterValue("UserName", (Session["USERNAME"].ToString()));
                        rprt.SetParameterValue("FromToDate", Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("dd-MM-yyyy") + " To " + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).ToString("dd-MM-yyyy"));
                        rprt.SetParameterValue("View_Report", HeadingRpt);

                    }

                    else if (Session["REPORT_TYPE"].ToString() == "BRANCH_WS")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/BranchReceivedRegister_BranchWiseReport.rpt"));

                        Session["BRANCH_CODE_VALUE"].ToString();

                        ds = InventoryReport_Logiclayer.GetBRANCH_RECEIVED_STK_RECMASFor_MainReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE_VALUE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["TRAN_TYPE"].ToString(), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString());


                     // Check ReceivedFlag REC_FLAG From MasterTable

                        Dt = ds.Tables[0];
                        DataView Dv = new DataView(Dt);
                        string FilterStr = string.Empty;

                        if (Session["VIEW_REPORT"].ToString() == "CNF" || Session["VIEW_REPORT"].ToString() == "NCNF")
                        {
                            if (Session["VIEW_REPORT"].ToString() == "CNF")
                            {
                                FilterStr = "REC_FLAG='Yes'";
                                HeadingRpt = "[RECEIVED CHALLAN]";
                            }
                            else
                            {
                                FilterStr = "REC_FLAG='No'";
                                HeadingRpt = "[NON-RECEIVED CHALLAN]";
                            }
                        }

                        if (FilterStr != string.Empty)
                        {
                            Dv.RowFilter = FilterStr;
                        }

                        DataTable Dt1 = new DataTable();
                        Dt1 = Dv.ToTable();

                        // end

                      
                        rprt.SetDataSource(Dt1);

                        rprt.SetParameterValue("Comp_Name", (Session["COMP_NAME"].ToString()));
                        rprt.SetParameterValue("Branch_Name", (Session["BRANCH_NAME"].ToString()));
                        rprt.SetParameterValue("UserName", (Session["USERNAME"].ToString()));
                        rprt.SetParameterValue("FromToDate", Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("dd-MM-yyyy") + " To " + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).ToString("dd-MM-yyyy"));
                        rprt.SetParameterValue("View_Report", HeadingRpt);

                    }

                    else if (Session["REPORT_TYPE"].ToString() == "BRANCH_WS_DET")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/BranchReceivedRegisterDetails_BranchWiseReport.rpt"));

                        Session["BRANCH_CODE_VALUE"].ToString();

                        ds = InventoryReport_Logiclayer.GetBRANCH_RECEIVED_STK_RECMASFor_MainReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE_VALUE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["TRAN_TYPE"].ToString(), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString());

                        dsSub = InventoryReport_Logiclayer.GetBRANCH_RECEIVED_STK_RECMASFor_SubReport(Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString());

                        // Check ReceivedFlag REC_FLAG From MasterTable

                        Dt = ds.Tables[0];
                        DataView Dv = new DataView(Dt);
                        string FilterStr = string.Empty;

                        if (Session["VIEW_REPORT"].ToString() == "CNF" || Session["VIEW_REPORT"].ToString() == "NCNF")
                        {
                            if (Session["VIEW_REPORT"].ToString() == "CNF")
                            {
                                FilterStr = "REC_FLAG='Yes'";
                                HeadingRpt = "[RECEIVED CHALLAN]";
                            }
                            else
                            {
                                FilterStr = "REC_FLAG='No'";
                                HeadingRpt = "[NON-RECEIVED CHALLAN]";
                            }
                        }

                        if (FilterStr != string.Empty)
                        {
                            Dv.RowFilter = FilterStr;
                        }

                        DataTable Dt1 = new DataTable();
                        Dt1 = Dv.ToTable();

                        // end

                       
                        rprt.SetDataSource(Dt1);

                        rprt.Subreports[0].SetDataSource(dsSub.Tables[0]);

                        rprt.SetParameterValue("Comp_Name", (Session["COMP_NAME"].ToString()));
                        rprt.SetParameterValue("Branch_Name", (Session["BRANCH_NAME"].ToString()));
                        rprt.SetParameterValue("UserName", (Session["USERNAME"].ToString()));
                        rprt.SetParameterValue("FromToDate", Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("dd-MM-yyyy") + " To " + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).ToString("dd-MM-yyyy"));
                        rprt.SetParameterValue("View_Report", HeadingRpt);

                    }

                    else
                    {

                    }
                    rprt.SetDatabaseLogon("veeradatabase", "Veera@welcome!1");

                    CryRptStockReceived.Zoom(120);

                    CryRptStockReceived.ReportSource = rprt;




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