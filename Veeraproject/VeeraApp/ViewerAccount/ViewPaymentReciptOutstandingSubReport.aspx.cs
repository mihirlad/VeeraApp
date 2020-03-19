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
    public partial class ViewPaymentReciptOutstandingReport : System.Web.UI.Page
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

               //   rprt.Load(Server.MapPath("~/ReportAccount/PaymentReciptOutstandingSubReport.rpt"));
                    rprt.Load(Server.MapPath("~/ReportAccount/PaymentReceiptBillMainReport.rpt"));

                DataSet ds = new DataSet();

                DataSet dssub = new DataSet();
                
               dssub = AccountReport_Logiclayer.GetOutStnadingDataOnPartyNameForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Session["TRAN_TYPE"].ToString(), Convert.ToDateTime(Session["TRAN_DATE"].ToString()),Session["TRAN_NO"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()));

                ds = AccountReport_Logiclayer.GetPaymentReceiptDataForBillReport(Session["COMP_CODE"].ToString(), Convert.ToDateTime(Session["TRAN_DATE"].ToString()), Session["TRAN_NO"].ToString());

                //rprt.Subreports[0].SetParameterValue("@p_comp_code", Session["COMP_CODE"].ToString());
                //rprt.Subreports[0].SetParameterValue("@p_branch_code", Session["BRANCH_CODE"].ToString());
                //rprt.Subreports[0].SetParameterValue("@pay_rec_m_tran_type", Session["TRAN_TYPE"].ToString());
                //rprt.Subreports[0].SetParameterValue("@TRAN_DATE", Session["TRAN_DATE"].ToString());
                //rprt.Subreports[0].SetParameterValue("@TRAN_NO", Session["TRAN_NO"].ToString());
                //rprt.Subreports[0].SetParameterValue("@YRDT1", Session["FIN_YEAR"].ToString());
                //rprt.Subreports[0].SetParameterValue("@YRDT2", Session["FIN_YEAR_END"].ToString());

                rprt.SetDataSource(ds.Tables[0]);

                rprt.Subreports[0].SetDataSource(dssub.Tables[0]);

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