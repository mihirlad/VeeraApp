using System;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace VeeraApp.reportviewPages
{
    public partial class Quotation_Item_Print : System.Web.UI.Page
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
                    rd.Load(Server.MapPath("~/reportCrystalrpts/QuotationItem.rpt"));
                    rd.SetDatabaseLogon("sa", "P@s$w0rd");
                    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                    SqlConnection con = new SqlConnection(constr);
                    con.Open();
                    DateTime dtt = Convert.ToDateTime(Session["TRAN_DATE"].ToString());
                    string dat = dtt.ToString("dd MMMM yyyy hh:mm:ss tt");
                    //   SqlDataAdapter da = new SqlDataAdapter("select * from viewQuotationItem where TRAN_NO='15' and TRAN_DATE='2019-03-27 00:00:00.000' and COMP_CODE='101' and QUO_NO='12' and QUO_DATE='2019-03-27 00:00:00.000' and QUO_TYPE='i'", con);
                    SqlCommand cmd = new SqlCommand("select * from viewQuotationItem where TRAN_NO = '" + Session["TRAN_NO"].ToString() + "' AND  TRAN_DATE = '" + dat + "' AND QUO_TYPE = '" + Session["QUO_TYPE"].ToString() + "'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rd.SetDataSource(dt);
                    //  cryquoitem.Refresh();
                    rd.SetParameterValue("isspecification", "NO");
                    rd.SetParameterValue("PARAM_LOGO", Server.MapPath("~/Admin/Company/LH/" + dt.Rows[0]["CMPLOGO"].ToString()));
                    rd.SetParameterValue("CMP_SIGN_LOGO", Server.MapPath("~/Admin/Company/BKP/" + dt.Rows[0]["CMPSIGNLOGO"].ToString()));
                    cryquoitem.Zoom(170);
                    cryquoitem.ReportSource = rd;
                    cryquoitem.DataBind();
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