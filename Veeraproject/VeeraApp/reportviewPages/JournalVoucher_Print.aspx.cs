using System;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Veera.LogicLayer;


namespace VeeraApp.reportviewPages
{
    public partial class JournalVoucher_Print : System.Web.UI.Page
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
                Session["TRAN_TYPE"] != null)

                    try
                    {
                        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                        SqlConnection con = new SqlConnection(constr);
                        con.Open();
                        DateTime dtt = Convert.ToDateTime(Session["TRAN_DATE"].ToString());
                        string dat = dtt.ToString("dd MMMM yyyy hh:mm:ss tt");
                        SqlCommand cmd = new SqlCommand("select * from ViewJournalVoucher_M where TRAN_NO= '" + Session["TRAN_NO"].ToString() + "' AND  TRAN_DATE = '" + dat + "' AND  TRAN_TYPE = '" + Session["TRAN_TYPE"].ToString() + "' ", con);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        sda.Fill(ds, "ViewJournalVoucher_M");
                        rd.Load(Server.MapPath("~/reportCrystalrpts/JournalVoucher.rpt"));
                        rd.SetDataSource(ds);
                        //rd.SetParameterValue("PARAM_LOGO", Server.MapPath("~/Admin/Company/LH/" + ds.Tables[0].Rows[0]["CMPLOGO"].ToString()));
                        //rd.SetParameterValue("CMP_SIGN_LOGO", Server.MapPath("~/Admin/Company/BKP/" + ds.Tables[0].Rows[0]["CMPSIGNLOGO"].ToString()));
                        cryJournalvou.ReportSource = rd;
                        con.Close();
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
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}