using System;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace VeeraApp.reportviewPages
{
    public partial class Ouotation_Amc_Print : System.Web.UI.Page
    {
        ReportDocument rd = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
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
                 Session["QUO_TYPE"] != null)

             try
              {
                rd.Load(Server.MapPath("~/reportCrystalrpts/QuotationAmc.rpt"));
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                rd.SetDatabaseLogon("sa", "P@s$w0rd");
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                DateTime dtt = Convert.ToDateTime(Session["TRAN_DATE"].ToString());
                string dat = dtt.ToString("dd MMMM yyyy hh:mm:ss tt");
                SqlCommand cmd = new SqlCommand("select * from viewQuotationAMC where TRAN_NO = '" + Session["TRAN_NO"].ToString() + "' AND  TRAN_DATE = '" + dat + "' AND QUO_TYPE = '" + Session["QUO_TYPE"].ToString() + "'", con);
              //  SqlCommand cmd = new SqlCommand("select * from viewQuotationAMC where TRAN_NO='16' and QUO_TYPE='A'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rd.SetDataSource(dt);
                rd.SetParameterValue("isspecification", "YES");
                rd.SetParameterValue("PARAM_LOGO", Server.MapPath("~/Admin/Company/LH/" + dt.Rows[0]["CMPLOGO"].ToString()));
                rd.SetParameterValue("CMP_SIGN_LOGO", Server.MapPath("~/Admin/Company/BKP/" + dt.Rows[0]["CMPSIGNLOGO"].ToString()));
                cryquoamc.ReportSource = rd;
                cryquoamc.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.AppendToLog(ex.ToString());
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            rd.PrintToPrinter(1, false, 0, 0);
        }
    }
}