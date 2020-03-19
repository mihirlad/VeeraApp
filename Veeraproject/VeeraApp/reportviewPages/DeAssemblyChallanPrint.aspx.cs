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
    public partial class DeAssemblyChallanPrint : System.Web.UI.Page
    {
        ReportDocument rd = new ReportDocument();
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
                   Session["TRAN_TYPE"] != null)

                    rd.Load(Server.MapPath("~/reportCrystalrpts/DeAssembleTransactionReport.rpt"));
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                DateTime dtt = Convert.ToDateTime(Session["TRAN_DATE"].ToString());
                string dat = dtt.ToString("dd MMMM yyyy hh:mm:ss tt");
              //   SqlCommand cmd = new SqlCommand("select * from dbo.DeViewAssembly where TRAN_NO=8 order by srno asc", con);
                SqlCommand cmd = new SqlCommand("select * from DeViewAssembly where TRAN_NO= '" + Session["TRAN_NO"].ToString() + "' AND  TRAN_DATE = '" + dat + "' AND TRAN_TYPE = '" + Session["TRAN_TYPE"].ToString() + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rd.SetDataSource(dt);
                //rd.SetParameterValue("CMP_SIGN_LOGO", Server.MapPath("~/Admin/Company/BKP/" + dt.Rows[0]["CMPSIGNLOGO"].ToString()));
                cryrptDeliveryChallan.ReportSource = rd;
                cryrptDeliveryChallan.DataBind();
                con.Close();

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