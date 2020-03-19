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
    public partial class ViewStockStatementPrint : System.Web.UI.Page
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
                    Session["REPORT_TYPE"] != null)
                   {

                    if (string.IsNullOrEmpty(Session["ACODE"] as string))
                    {
                        Session["ACODE"] = "0";
                    }

                    if (string.IsNullOrEmpty(Session["CAT_CODE"] as string))
                    {
                        Session["CAT_CODE"] = "0";
                    }

                    if (string.IsNullOrEmpty(Session["SCODE"] as string))
                    {
                        Session["SCODE"] = "0";
                    }

                    DataSet ds = new DataSet();

                    if (Session["REPORT_TYPE"].ToString() == "STOCK_LIST_STATEMENT")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockListStatemenReport.rpt"));

                        ds = StockStatementReport_LogicLayer.GetSTOCKLIST_STATEMENTForReport(Session["COMP_CODE"].ToString(), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString());
                    }

                    else if (Session["REPORT_TYPE"].ToString() == "STOCK_LIST_BRANCHWISE")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockListBranchWiseReport.rpt"));

                     //  ds = StockStatementReport_LogicLayer.GetSTOCKLIST_BranchWiseForReport(Session["COMP_CODE"].ToString(), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Convert.ToDateTime(Session["TO_DATE"].ToString()), Convert.ToDateTime(Session["FIN_YEAR"].ToString()));

                        ds = StockStatementReport_LogicLayer.GetSTOCKLIST_BranchWiseForReport("101" ,"0", Convert.ToDateTime("2020-02-08 00:00:00.000"), Convert.ToDateTime("2018-04-01 00:00:00.000"));
                    }

                    else if (Session["REPORT_TYPE"].ToString() == "STOCK_DETAIL_DATEWISE")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockDetailDateWiseReport.rpt"));

                         ds = StockStatementReport_LogicLayer.GetSTOCK_DetailDateWiseForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()));                      
                    }

                    else if (Session["REPORT_TYPE"].ToString() == "STOCK_DETAIL_MONTHWISE")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockDetailMonthWiseReport.rpt"));

                        ds = StockStatementReport_LogicLayer.GetSTOCK_DetailsMonthlyWiseForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()));
                    }

                    else if (Session["REPORT_TYPE"].ToString() == "STOCK_CLOSING_DETAIL")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockClosingDetailsReport.rpt"));

                        ds = StockStatementReport_LogicLayer.GetSTOCK_ClosingDetailForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()));
                    }

                    else if (Session["REPORT_TYPE"].ToString() == "MAXIMUM_STOCK")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockMaximum_Minimum_AllReport.rpt"));

                        Session["P_REPORT"].ToString();

                     //   ds = StockStatementReport_LogicLayer.GetSTOCK_Maximum_Minimum_StatementForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), Session["P_REPORT"].ToString());

                        ds = StockStatementReport_LogicLayer.GetSTOCK_Maximum_Minimum_StatementForReport("101", "508", Convert.ToDateTime("2018-04-01 00:00:00.000"), Convert.ToDateTime("2019-02-10 00:00:00.000"), "0", "0", Convert.ToDateTime("2018-04-01 00:00:00.000"), Convert.ToDateTime("2019-03-31 00:00:00.000"), "MAX");
                    }

                    else if (Session["REPORT_TYPE"].ToString() == "MINIMUM_STOCK")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockMaximum_Minimum_AllReport.rpt"));

                        Session["P_REPORT"].ToString();

                        //   ds = StockStatementReport_LogicLayer.GetSTOCK_Maximum_Minimum_StatementForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), Session["P_REPORT"].ToString());

                        ds = StockStatementReport_LogicLayer.GetSTOCK_Maximum_Minimum_StatementForReport("101", "508", Convert.ToDateTime("2018-04-01 00:00:00.000"), Convert.ToDateTime("2019-02-10 00:00:00.000"), "0", "0", Convert.ToDateTime("2018-04-01 00:00:00.000"), Convert.ToDateTime("2019-03-31 00:00:00.000"), "MIN");
                    }

                    else if (Session["REPORT_TYPE"].ToString() == "ALL_STOCK_WITH_ZERO")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockMaximum_Minimum_AllReport.rpt"));

                        Session["P_REPORT"].ToString();

                        //   ds = StockStatementReport_LogicLayer.GetSTOCK_Maximum_Minimum_StatementForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), Session["P_REPORT"].ToString());

                        ds = StockStatementReport_LogicLayer.GetSTOCK_Maximum_Minimum_StatementForReport("101", "508", Convert.ToDateTime("2018-04-01 00:00:00.000"), Convert.ToDateTime("2019-02-10 00:00:00.000"), "0", "0", Convert.ToDateTime("2018-04-01 00:00:00.000"), Convert.ToDateTime("2019-03-31 00:00:00.000"), "ALL");
                    }

                   else if (Session["REPORT_TYPE"].ToString() == "BRANCH_STOCK_ONE_ITEM")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockBranchOneItemReport.rpt"));

                        Session["P_SCODE_FLAG"].ToString();

                         ds = StockStatementReport_LogicLayer.GetSTOCK_BranchOneItemDetailForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), Session["P_SCODE_FLAG"].ToString(), Session["USERNAME"].ToString());

                       //  ds = StockStatementReport_LogicLayer.GetSTOCK_Maximum_Minimum_StatementForReport("101", "508", Convert.ToDateTime("2018-04-01 00:00:00.000"), Convert.ToDateTime("2019-02-10 00:00:00.000"), "0", "0", Convert.ToDateTime("2018-04-01 00:00:00.000"), Convert.ToDateTime("2019-03-31 00:00:00.000"), "ALL");
                    }

                    else if (Session["REPORT_TYPE"].ToString() == "BARCODE_STOCK_DETAIL_EXCISE")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockBarcodeDetailExciseReport.rpt"));

                        string fin_Years = Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy") + "-" + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).ToString("yyyy");

                        Session["P_USERTYPE"].ToString();

                        ds = StockStatementReport_LogicLayer.GetSTOCK_BarcodeStockDetailExciseForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString(), fin_Years.ToString(), Session["P_USERTYPE"].ToString());
                    }

                    else if (Session["REPORT_TYPE"].ToString() == "BARCODE_STOCK_STATUS")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/Stock_BarcodeStatus_BarcodeZeroValueReport.rpt"));

                        string fin_Years = Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy") + "-" + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).ToString("yyyy");

                        Session["P_REPORT"].ToString();

                        ds = StockStatementReport_LogicLayer.GetSTOCK_BarcodeStock_Status_BarcodeStock_ZeroValue_ForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString(), fin_Years.ToString(), Session["P_REPORT"].ToString());

                    }

                    else if (Session["REPORT_TYPE"].ToString() == "BARCODE_STOCK_WITH_ZERO_VALUE")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/Stock_BarcodeStatus_BarcodeZeroValueReport.rpt"));

                        string fin_Years = Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy") + "-" + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).ToString("yyyy");

                        Session["P_REPORT"].ToString();

                        ds = StockStatementReport_LogicLayer.GetSTOCK_BarcodeStock_Status_BarcodeStock_ZeroValue_ForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString(), fin_Years.ToString(), Session["P_REPORT"].ToString());

                    }

                    else if (Session["REPORT_TYPE"].ToString() == "BARCODE_STOCK_DETAIL")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/Stock_BarcodeStock[Detail]Report.rpt"));

                        string fin_Years = Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy") + "-" + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).ToString("yyyy");

                        string cp_usertype =  Session["USERTYPE"].ToString();

                        ds = StockStatementReport_LogicLayer.GetSTOCK_Barcode_Stock_Detail_ForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString(), fin_Years.ToString(), cp_usertype.ToString());

                    }


                    else if (Session["REPORT_TYPE"].ToString() == "BARCODE_STOCK_SUMMARY")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/Stock_BarcodeStock[Summary]Report.rpt"));

                        string fin_Years = Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy") + "-" + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).ToString("yyyy");

                        string cp_usertype = Session["USERTYPE"].ToString();

                        ds = StockStatementReport_LogicLayer.GetSTOCK_Barcode_Stock_Summary_ForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString(), fin_Years.ToString(), cp_usertype.ToString());

                    }


                    else if (Session["REPORT_TYPE"].ToString() == "BARCODE_STOCK_VALUE")
                    {
                        //rprt.Load(Server.MapPath("~/ReportInventory/Stock_BarcodeStock[Value]Report.rpt"));
                        rprt.Load(Server.MapPath("~/ReportInventory/TestCrossTabReport.rpt"));

                        string fin_Years = Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy") + "-" + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).ToString("yyyy");

                       string cp_usertype = Session["USERTYPE"].ToString();

                       // ds = StockStatementReport_LogicLayer.GetSTOCK_Barcode_Stock_Value_ForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString(), fin_Years.ToString(), cp_usertype.ToString());

                        ds = StockStatementReport_LogicLayer.GetSTOCK_Barcode_Stock_Value_ForReport(Session["COMP_CODE"].ToString(), "0", Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString(), fin_Years.ToString(), cp_usertype.ToString());

                    }

                    else if (Session["REPORT_TYPE"].ToString() == "BARCODE_STOCK_HISTORY")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockBarcodeHistoryDetailReport.rpt"));

                        ds = StockStatementReport_LogicLayer.GetSTOCK_Barcode_stock_HistoryForReport(Session["COMP_CODE"].ToString());
                   
                    }

                    else if (Session["REPORT_TYPE"].ToString() == "BARCODE_STOCK_PRINT")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockBarcodePrintReport.rpt"));

                        ds = StockStatementReport_LogicLayer.GetSTOCK_Barcode_stock_printForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());

                    }


                    else if (Session["REPORT_TYPE"].ToString() == "SUPPLIER_STOCK_INDENT")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockSupplierStockIndentReport.rpt"));

                     //   ds = StockStatementReport_LogicLayer.GetSTOCK_Supplier_Stock_IndentForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["ACODE"] == null ? "0" : Session["ACODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString());

                        ds = StockStatementReport_LogicLayer.GetSTOCK_Supplier_Stock_IndentForReport("101", "508", Convert.ToDateTime("2018-04-01 00:00:00.000"), Convert.ToDateTime("2019-03-05 00:00:00.000"),"0", Convert.ToDateTime("2018-04-01 00:00:00.000"), Convert.ToDateTime("2019-03-31 00:00:00.000"), "0", "0");


                    }


                    else if (Session["REPORT_TYPE"].ToString() == "STOCK_INDENT_WITH_LAST_PURCHASE")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockIndentWithLastPurchaseReport.rpt"));

                 
                      //  ds = StockStatementReport_LogicLayer.GetSTOCK_stock_indent_with_last_purchaseForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["ACODE"] == null ? "0" : Session["ACODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString());

                         ds = StockStatementReport_LogicLayer.GetSTOCK_stock_indent_with_last_purchaseForReport("101","508", Convert.ToDateTime("2018-04-01 00:00:00.000"), Convert.ToDateTime("2019-02-10 00:00:00.000"), Convert.ToDateTime("2018-04-01 00:00:00.000"), Convert.ToDateTime("2019-03-31 00:00:00.000"), "0", "0");

                    }


                    else if (Session["REPORT_TYPE"].ToString() == "DIFF_QTY_STOCK_WITH_BARCODE_STOCK")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockDiffQtyStockwithBarcodeStockReport.rpt"));

                        string fin_Years = Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy") + "-" + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).ToString("yyyy");

                        ds = StockStatementReport_LogicLayer.GetSTOCK_Diff_Qty_Stock_with_BarcodeStockForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), fin_Years.ToString(), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString());

                    }

                    else if (Session["REPORT_TYPE"].ToString() == "DIFF_STOCK_BARCODE_POSTING")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockDiffStockBarcodePostingReport.rpt"));

                        ds = StockStatementReport_LogicLayer.GetSTOCK_Diff_Stock_Barcode_PostingForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString());

                    }

                    else if (Session["REPORT_TYPE"].ToString() == "SALES_DC_DIFF_BARCODE_QTY")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockSalesDCDiffBarcodeQtyReport.rpt"));

                        ds = StockStatementReport_LogicLayer.GetSTOCK_sales_DC_diff_barcode_qtyForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["ACODE"] == null ? "0" : Session["ACODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString(),"D","S");
                    }

                    else if (Session["REPORT_TYPE"].ToString() == "BRANCH_ISSUE_DIFF_BARCODE_QTY")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/StockBranchIssueDiffBarcodeQtyReport.rpt"));

                        ds = StockStatementReport_LogicLayer.GetSTOCK_branch_issue_diff_barcode_qtyForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString(), "BI");

                    }


                    else
                    {
                         
                    }


                    rprt.SetDatabaseLogon("veeradatabase", "Veera@welcome!1");

                    if ((ds.Tables.Count > 0))
                    {

                        rprt.SetDataSource(ds.Tables[0]);

                        rprt.SetParameterValue("Comp_Name", (Session["COMP_NAME"].ToString()));
                        rprt.SetParameterValue("Branch_Name", (Session["BRANCH_NAME"].ToString()));
                        rprt.SetParameterValue("UserName", (Session["USERNAME"].ToString()));
                        rprt.SetParameterValue("FromToDate", Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("dd-MM-yyyy") + " To " + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).ToString("dd-MM-yyyy"));
                    }


                    CryRptStockList.Zoom(120);

                    CryRptStockList.ReportSource = rprt;




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