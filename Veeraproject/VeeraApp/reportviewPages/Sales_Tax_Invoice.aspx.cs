using System;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Veera.LogicLayer;

namespace VeeraApp.reportviewPages
{     
    public partial class Sales_Tax_Invoice : System.Web.UI.Page
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
                   rd.Load(Server.MapPath("~/reportCrystalrpts/SalesTaxInvoice.rpt"));
                    rd.SetDatabaseLogon("sa", "P@s$w0rd");
                  
                    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                    SqlConnection con = new SqlConnection(constr);
                    con.Open();
                    DateTime dtt = Convert.ToDateTime(Session["TRAN_DATE"].ToString());
                    string dat = dtt.ToString("dd MMMM yyyy hh:mm:ss tt");
               

                    SqlCommand cmd = new SqlCommand("select * from ViewTaxInvoiceBillForSalesAndPurchase where TRAN_NO = '" + Session["TRAN_NO"].ToString() + "' AND  TRAN_DATE = '" + dat + "'  AND TRAN_TYPE = '" + Session["TRAN_TYPE"].ToString() + "' AND TRN_TYPE = '" + Session["TRN_TYPE"].ToString() + "'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                   // DataTable DtGST = REC_ISS_MLogicLayer.GetGSTRATEGroupByTaxableAmoutForReport(Convert.ToDateTime(Session["TRAN_DATE"].ToString()), Session["TRAN_NO"].ToString());
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rd.SetDataSource(dt);
                    // rd.SetParameterValue("isspecification", "NO");
                    rd.SetParameterValue("PARAM_LOGO", Server.MapPath("~/Admin/Company/LH/" + dt.Rows[0]["CMPLOGO"].ToString()));
                    rd.SetParameterValue("formtype", "-");
                   
                   // rd.Subreports[0].SetParameterValue("@TRAN_DATE",  DtGST.Rows[0]["TRAN_DATE"].ToString());
                   // rd.Subreports[0].SetParameterValue("@TRAN_NO", DtGST.Rows[0]["TRAN_NO"].ToString());

                    if (Session["TRAN_TYPE"].ToString()=="S" && Session["TRN_TYPE"].ToString()=="T")
                    {
                        rd.SetParameterValue("Invoice_Type", "TAX INVOICE");
                    }
                    else if(Session["TRAN_TYPE"].ToString() == "S" && Session["TRN_TYPE"].ToString() == "P")
                    {
                        rd.SetParameterValue("Invoice_Type", "PERFORMA INVOICE");
                    }
                    else if (Session["TRAN_TYPE"].ToString() == "S" && Session["TRN_TYPE"].ToString() == "R")
                    {
                        rd.SetParameterValue("Invoice_Type", "RETAIL INVOICE");
                    }
                    else if (Session["TRAN_TYPE"].ToString() == "P" && Session["TRN_TYPE"].ToString() == "R")
                    {
                        rd.SetParameterValue("Invoice_Type", "PURCHASE INVOICE");
                    }                   
                   else if (Session["TRAN_TYPE"].ToString() == "C" && Session["TRN_TYPE"].ToString() == "R")
                    {
                        rd.SetParameterValue("Invoice_Type", "PURCHASE RETURN BILL");
                    }
                    else if (Session["TRAN_TYPE"].ToString() == "L" && Session["TRN_TYPE"].ToString() == "R")
                    {
                        rd.SetParameterValue("Invoice_Type", "SALES RETURN BILL");
                    }                  
                    else
                    {
                    }

                   
                    cryquoitem.Zoom(150);
                    cryquoitem.ReportSource = rd;
                  
                 
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