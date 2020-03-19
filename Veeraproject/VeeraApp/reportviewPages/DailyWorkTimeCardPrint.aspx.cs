using System;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Veera.LogicLayer;


namespace VeeraApp.reportviewPages
{
    public partial class DailyWorkTimeCardPrint : System.Web.UI.Page
    {
        ReportDocument rd = new ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (
                  Session["TRAN_NO"] != null &&
                  Session["TRAN_DATE"] != null)
                {
                    rd.Load(Server.MapPath("~/reportCrystalrpts/DailyWorkJobMaster.rpt"));

                    rd.SetDatabaseLogon("sa", "P@s$w0rd");

                    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                    SqlConnection con = new SqlConnection(constr);
                    con.Open();
                    DateTime dtt = Convert.ToDateTime(Session["TRAN_DATE"].ToString());
                    string dat = dtt.ToString("dd MMMM yyyy hh:mm:ss tt");

                    SqlCommand cmd = new SqlCommand("select * from ViewDailyWorkJobMaster where TRAN_NO = '" + Session["TRAN_NO"].ToString() + "' AND  TRAN_DATE = '" + dat + "' ", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rd.SetDataSource(dt);
                    rd.SetParameterValue("PARAM_LOGO", Server.MapPath("~/Admin/Company/LH/" + dt.Rows[0]["CMPLOGO"].ToString()));

                    CryDailyWorkTimeRpt.ReportSource = rd;

                    con.Close();
                }

                else
                {
                    //sesssion Error
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            rd.PrintToPrinter(1, false, 0, 0);
        }
    }
}