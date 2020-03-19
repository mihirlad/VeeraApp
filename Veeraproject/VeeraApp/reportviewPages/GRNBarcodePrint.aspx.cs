using System;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Veera.LogicLayer;
using System.Drawing;

namespace VeeraApp.reportviewPages
{
    public partial class GRNBarcodePrint : System.Web.UI.Page
    {
        ReportDocument rprt = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (Session["COMP_CODE"] != null &&
                //   Session["USERCODE"] != null &&
                //   Session["USERNAME"] != null &&
                //   Session["USERTYPE"] != null &&
                //   Session["COMP_CODE"] != null &&
                //   Session["COMP_NAME"] != null &&
                //   Session["WORK_VIEWFLAG"] != null &&
                //   Session["BRANCH_CODE"] != null &&
                //   Session["BRANCH_NAME"] != null &&
                //   Session["BRANCH_TYPE"] != null &&
                //   Session["FIN_YEAR"] != null &&
                //   Session["FIN_YEAR_END"] != null &&
                //   Session["TRAN_NO"] != null &&
                //   Session["TRAN_DATE"] != null &&
                //   Session["TRAN_TYPE"] != null &&
                //   Session["TRN_TYPE"] != null)


                rprt.Load(Server.MapPath("~/reportCrystalrpts/GRNBarcode2.rpt"));

                rprt.SetDatabaseLogon("veeradatabase", "Veera@welcome!1");

                DataSet ds = new DataSet();


                ds = DC_MASLogicLayer.GetGRNBarcode("101", Convert.ToDateTime("2019-12-23 00:00:00.000"), "10");

                DataTable DtNew = ds.Tables[0];

                

                foreach (DataRow dr in DtNew.Rows) // search whole table
                {
                    if (dr["Barcode"].ToString() != string.Empty) // if id==2
                    {

                        IDAutomation.NetAssembly.FontEncoder FontEncoder = new IDAutomation.NetAssembly.FontEncoder();
                        dr["Barcode"] = FontEncoder.Code128a(dr["Barcode"].ToString());
                        //dr["Barcode"].Font = new Font("IDAutomationC128L", 12, FontStyle.Regular);
                    }

                    if (dr["Barcode1"].ToString() != string.Empty) // if id==2
                    {
                        IDAutomation.NetAssembly.FontEncoder FontEncoder = new IDAutomation.NetAssembly.FontEncoder();
                        dr["Barcode1"] = FontEncoder.Code128b(dr["Barcode1"].ToString());
                    }
                }

                rprt.SetDataSource(DtNew);

                crygrnbarcode.Zoom(300);

                crygrnbarcode.ReportSource = rprt;

            }
            catch (Exception ex)
            {
                Response.AppendToLog(ex.ToString());
            }
        }


        protected void btnprint_Click(object sender, EventArgs e)
        {
            rprt.PrintToPrinter(1, false, 1, 1);
        }
    }
}