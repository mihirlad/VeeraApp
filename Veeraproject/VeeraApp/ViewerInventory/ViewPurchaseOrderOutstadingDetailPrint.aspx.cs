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
    public partial class PurchaseOrderOutstadingDetailReport : System.Web.UI.Page
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
                    Session["ACODE"] != null)

                {
                    DataSet Subds = new DataSet();
                    DataTable DtFilterSub = new DataTable();
                    Subds = InventoryReport_Logiclayer.GetORDER_MASOutStandingDetailSubReport(Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString());
              


                rprt.Load(Server.MapPath("~/ReportInventory/OrderMasterOutStandingMainReport.rpt"));
                rprt.SetDatabaseLogon("veeradatabase", "Veera@welcome!1");

                DataSet ds = new DataSet();
                ds = InventoryReport_Logiclayer.GetORDER_MASDetailsFor_MainReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE_VALUE"].ToString(), Session["ACODE"].ToString(), Convert.ToDateTime(Session["FROM_DATE"].ToString()), Convert.ToDateTime(Session["TO_DATE"].ToString()), Session["TRAN_TYPE"].ToString(), Session["CAT_CODE"] == null ? "0" : Session["CAT_CODE"].ToString(), Session["SCODE"] == null ? "0" : Session["SCODE"].ToString());
               
                rprt.SetDataSource(ds.Tables[0]);

                rprt.Subreports[0].SetDataSource(Subds.Tables[0]);

                rprt.SetParameterValue("Branch_Name", (Session["BRANCH_NAME"].ToString()));
                rprt.SetParameterValue("UserName", (Session["USERNAME"].ToString()));
                rprt.SetParameterValue("FromToDate", Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("dd-MM-yyyy") + " To " + Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("dd-MM-yyyy"));

                CryRptStockOutstanding.Zoom(130);

                CryRptStockOutstanding.ReportSource = rprt;

              }

                else
                {
                    //LOgout Code
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {

        }
    }
}