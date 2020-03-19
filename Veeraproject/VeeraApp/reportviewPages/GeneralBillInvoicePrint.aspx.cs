using System;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Veera.LogicLayer;

namespace VeeraApp.reportviewPages
{
    public partial class GeneralBillInvoicePrint : System.Web.UI.Page
    {
        ReportDocument rd = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (
                 Session["TRAN_NO"] != null &&
                 Session["TRAN_DATE"] != null &&
                 Session["TRAN_TYPE"] != null &&
                 Session["TRN_TYPE"] != null)
                {
                    rd.Load(Server.MapPath("~/reportCrystalrpts/GeneralBillInvoice.rpt"));
                    rd.SetDatabaseLogon("sa", "P@s$w0rd");
                    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                    SqlConnection con = new SqlConnection(constr);
                    con.Open();
                    DateTime dtt = Convert.ToDateTime(Session["TRAN_DATE"].ToString());
                    string dat = dtt.ToString("dd MMMM yyyy hh:mm:ss tt");


                    SqlCommand cmd = new SqlCommand("select * from ViewTaxInvoiceBillForSalesAndPurchase where TRAN_NO = '" + Session["TRAN_NO"].ToString() + "' AND  TRAN_DATE = '" + dat + "'  AND TRAN_TYPE = '" + Session["TRAN_TYPE"].ToString() + "' AND TRN_TYPE = '" + Session["TRN_TYPE"].ToString() + "'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);                  
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rd.SetDataSource(dt);
                    // rd.SetParameterValue("isspecification", "NO");
                    rd.SetParameterValue("PARAM_LOGO", Server.MapPath("~/Admin/Company/LH/" + dt.Rows[0]["CMPLOGO"].ToString()));
                    rd.SetParameterValue("formtype", "-");

                    if (Session["TRAN_TYPE"].ToString() == "G" && Session["TRN_TYPE"].ToString() == "R")
                    {
                        rd.SetParameterValue("Invoice_Type", "TAX INVOICE");
                    }
                    else
                    {
                    }

                 
                    CryGenInvoice.ReportSource = rd;
                    CryGenInvoice.DataBind();

                    con.Close();
                }

                else
                {
                    //session error
                }
            }
            catch (Exception ex)
            {
                Response.AppendToLog(ex.ToString());
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                rd.SetParameterValue("formtype", "Original");
                rd.PrintToPrinter(1, false, 0, 0);
                rd.SetParameterValue("formtype", "Duplicate");
                rd.PrintToPrinter(1, false, 0, 0);
                rd.SetParameterValue("formtype", "Triplicate ");
                rd.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
