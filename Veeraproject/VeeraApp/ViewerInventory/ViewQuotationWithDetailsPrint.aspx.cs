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
    public partial class ViewQuotationWithDetailsPrint : System.Web.UI.Page
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
                    Session["QUO_TYPE"] != null &&
                    Session["REPORT_TYPE"] != null)
                {

                    if (Session["REPORT_TYPE"].ToString() == "DT_DET")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/QuotationDateWiseDetailsReport.rpt"));
                    }
                    else if (Session["REPORT_TYPE"].ToString() == "PT_DET")
                    {
                        rprt.Load(Server.MapPath("~/ReportInventory/QuotationPartyWiseDetailsReport.rpt"));
                    }
                    else
                    {

                    }

                    rprt.SetDatabaseLogon("veeradatabase", "Veera@welcome!1");

                    DataSet ds = new DataSet();
                    DataSet Subds = new DataSet();

                    ds = InventoryReport_Logiclayer.GetQUOTATION_MASDetailsFor_MainReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE_VALUE"].ToString(), Session["ACODE"].ToString() == null ? "0" : Session["ACODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["QUO_TYPE"].ToString(), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString());

                    Subds = InventoryReport_Logiclayer.GetQUOTATION_MASDetailsFor_SubReport(Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString());

                    if ((ds.Tables.Count > 0))
                    {

                        rprt.SetDataSource(ds.Tables[0]);

                        rprt.Subreports[0].SetDataSource(Subds.Tables[0]);

                        rprt.SetParameterValue("Comp_Name", (Session["COMP_NAME"].ToString()));
                        rprt.SetParameterValue("Branch_Name", (Session["BRANCH_NAME"].ToString()));
                        rprt.SetParameterValue("UserName", (Session["USERNAME"].ToString()));
                        rprt.SetParameterValue("FromToDate", Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("dd-MM-yyyy") + " To " + Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("dd-MM-yyyy"));

                    }

                    CryRptQuoDet.Zoom(120);

                    CryRptQuoDet.ReportSource = rprt;




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