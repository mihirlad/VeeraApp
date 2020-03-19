using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeeraApp.reportviewPages
{
    public partial class Delivery_Challan_Print : System.Web.UI.Page
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
                    rd.Load(Server.MapPath("~/reportCrystalrpts/DeliveryChallan.rpt"));
                    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                    SqlConnection con = new SqlConnection(constr);
                    con.Open();


                    DateTime dtt = Convert.ToDateTime(Session["TRAN_DATE"].ToString());
                    string dat = dtt.ToString("dd MMMM yyyy hh:mm:ss tt");
                    SqlCommand cmd = new SqlCommand("select * from viewDeliveryChallan where TRAN_NO= '" + Session["TRAN_NO"].ToString() + "' AND  TRAN_DATE = '" + dat + "' AND TRAN_TYPE = '" + Session["TRAN_TYPE"].ToString() + "' AND TRN_TYPE = '" + Session["TRN_TYPE"].ToString() + "' ", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rd.SetDataSource(dt);
                //    rd.Subreports(rd.SetDataSource(dt));

                    rd.SetParameterValue("CMP_SIGN_LOGO", Server.MapPath("~/Admin/Company/BKP/" + dt.Rows[0]["CMPSIGNLOGO"].ToString()));

                    rd.SetParameterValue("Formtype1", ".");
                    rd.SetParameterValue("Formtype2", ".");

                    if (Session["TRAN_TYPE"].ToString() == "D" && Session["TRN_TYPE"].ToString() == "S")
                    {
                        rd.SetParameterValue("Invoice_Type", "DELIVERY CHALLAN");
                    }
                    else if (Session["TRAN_TYPE"].ToString() == "D" && Session["TRN_TYPE"].ToString() == "C")
                    {
                        rd.SetParameterValue("Invoice_Type", "PURCHASE RETURN DELIVERY CHALLAN");
                    }

                    cryrptDeliveryChallan.ReportSource = rd;
                    cryrptDeliveryChallan.DataBind();
                    
                    


                   
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            try
            {               
                rd.SetParameterValue("Formtype1", "ORIGINAL");
                rd.SetParameterValue("Formtype2", "TRIPLICATE");
                rd.PrintToPrinter(1, false, 0, 0);
                rd.SetParameterValue("Formtype1", "DUPLICATE");
                rd.SetParameterValue("Formtype2", "EXTRA COPY");
                rd.PrintToPrinter(1, false, 0, 0);
               
            }
            catch (Exception ex)
            {

                Response.AppendToLog(ex.ToString());
            }
        }
    }
}