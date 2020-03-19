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
    public partial class ViewCashBankVoucher : System.Web.UI.Page
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
                   Session["TRAN_NO"] != null &&
                   Session["TRAN_DATE"] != null &&
                   Session["TRAN_TYPE"] != null
                   )          
                    
                    if (Session["PAGE_HEIGHT"].ToString() == "A4")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/CashBankVoucherReporta4.rpt"));
                    }
                    else if (Session["PAGE_HEIGHT"].ToString() == "A5")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/CashBankVoucherReporta5.rpt"));
                    }

              
             
                DataSet ds = new DataSet();
                ds = AccountReport_Logiclayer.GetCashBankPaymentReceiptVoucherReport(Session["TRAN_NO"].ToString(),Convert.ToDateTime(Session["TRAN_DATE"].ToString()), Session["COMP_CODE"].ToString());
               // ds = AccountReport_Logiclayer.GetCashBankPaymentReceiptVoucherReport(Convert.ToInt32(6).ToString(), Convert.ToDateTime("2019-12-08 00:00:00.000"),Convert.ToInt32(101).ToString());               
                rprt.SetDataSource(ds.Tables[0]);                         

                CrystalReportViewer1.ReportSource = rprt;

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