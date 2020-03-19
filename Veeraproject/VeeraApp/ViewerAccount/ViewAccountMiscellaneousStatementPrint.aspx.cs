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
    public partial class ViewAccountMiscellaneousStatementPrint : System.Web.UI.Page
    {
        ReportDocument rprt = new ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            CryRptMiscStatement.Zoom(200);
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
                 Session["MENU_FLAG"] != null &&
                 Session["VIEW_REPORT"] != null)
                {

                    if (string.IsNullOrEmpty(Session["GROUP_CODE"] as string))
                    {
                        Session["GROUP_CODE"] = "0";
                    }


                    if (Session["MENU_FLAG"].ToString() == "AL")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/MiscAccountListReport.rpt"));

                        DataSet ds = new DataSet();
                        ds = AccountReport_Logiclayer.GetACCOUNT_DetailsListForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Session["GROUP_CODE"] == null ? "0" : Session["GROUP_CODE"].ToString());

                        if ((ds.Tables.Count > 0))
                        {

                            rprt.SetDataSource(ds.Tables[0]);

                            CryRptMiscStatement.ReportSource = rprt;

                        }
                    }

                    else if (Session["MENU_FLAG"].ToString() == "ALL")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/MiscAccountLabelListReport.rpt"));

                        DataSet ds = new DataSet();
                        ds = AccountReport_Logiclayer.GetACCOUNT_DetailsListForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Session["GROUP_CODE"] == null ? "0" : Session["GROUP_CODE"].ToString());

                        if ((ds.Tables.Count > 0))
                        {

                            rprt.SetDataSource(ds.Tables[0]);

                            CryRptMiscStatement.ReportSource = rprt;

                        }
                    }

                    else if (Session["MENU_FLAG"].ToString() == "CCL")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/MiscCustomerContactDetailsReport.rpt"));

                        DataSet ds = new DataSet();
                        ds = AccountReport_Logiclayer.GetACCOUNTS_CustomerContactDetailsForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());

                        if ((ds.Tables.Count > 0))
                        {

                            rprt.SetDataSource(ds.Tables[0]);

                            rprt.SetParameterValue("UserName", (Session["USERNAME"].ToString()));

                            CryRptMiscStatement.ReportSource = rprt;

                        }
                    }

                    else if (Session["MENU_FLAG"].ToString() == "SCL")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/MiscCustomerContactDetailsReport.rpt"));

                        DataSet ds = new DataSet();
                        ds = AccountReport_Logiclayer.GetACCOUNTS_SupplierContactDetailsForReport(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());

                        if ((ds.Tables.Count > 0))
                        {

                            rprt.SetDataSource(ds.Tables[0]);

                            rprt.SetParameterValue("UserName", (Session["USERNAME"].ToString()));

                            CryRptMiscStatement.ReportSource = rprt;

                        }
                    }

                    else if (Session["MENU_FLAG"].ToString() == "ULD")
                    {
                        rprt.Load(Server.MapPath("~/ReportAccount/MiscUserLoginDetailsReport.rpt"));


                        if (string.IsNullOrEmpty(Session["USER_LOGIN_NAME"] as string))
                            {
                            Session["USER_LOGIN_NAME"] = "0";
                            }
                        DataSet ds = new DataSet();
                        ds = AccountReport_Logiclayer.GetACCOUNTS_USERLOGINDetailsForReport(Session["USER_LOGIN_NAME"].ToString());

                        if ((ds.Tables.Count > 0))
                        {

                            rprt.SetDataSource(ds.Tables[0]);

                            rprt.SetParameterValue("UserName", (Session["USERNAME"].ToString()));
                            rprt.SetParameterValue("Comp_Name", (Session["COMP_NAME"].ToString()));
                            rprt.SetParameterValue("Branch_Name", (Session["BRANCH_NAME"].ToString()));
                            rprt.SetParameterValue("FromToDate", (Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("dd-mm-yyyy") + " To " + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).ToString("dd-mm-yyyy")));

                            CryRptMiscStatement.ReportSource = rprt;

                        }
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
            rprt.PrintToPrinter(1, false, 3, 3);
        }
    }
}