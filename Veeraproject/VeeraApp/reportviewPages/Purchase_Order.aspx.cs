using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace VeeraApp.reportviewPages
{
    public partial class Purchase_Order : System.Web.UI.Page
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

                    SqlCommand cmd = new SqlCommand("select * from viewPurchaseOrder where TRAN_NO= '" + Session["TRAN_NO"].ToString() + "' AND  TRAN_DATE = '" + dat + "' AND TRAN_TYPE = '" + Session["TRAN_TYPE"].ToString() + "'", con);
                    //  SqlDataAdapter da = new SqlDataAdapter("SELECT COMPANY.COMP_CODE, COMPANY.NAME, COMPANY.ADD1, COMPANY.ADD2, COMPANY.ADD3, COMPANY.PHONE, COMPANY.FAX, COMPANY.EMAIL, COMPANY.YR_START, COMPANY.YR_END, COMPANY.LH_PATH, COMPANY.LH_PATH2, COMPANY.GST_NO, ACCOUNTS.ACODE, ACCOUNTS.ANAME, ACCOUNTS.CONTACT_PER, ACCOUNTS.ADD1 AS Partyadd1, ACCOUNTS.ADD2 AS Partyadd2, ACCOUNTS.ADD3 AS Partyadd3, ACCOUNTS.ADD4, ACCOUNTS.PHONE AS PartyPhone, ACCOUNTS.PHONE_R, ACCOUNTS.PHONE_M, ACCOUNTS.FAX AS PartyFax, ACCOUNTS.EMAIL AS PartyEmail, ORDER_MAS.TRAN_DATE, ORDER_MAS.TRAN_NO, ORDER_MAS.TRAN_TYPE, ORDER_MAS.ORD_NO, ORDER_MAS.ORD_DT, ORDER_MAS.TRANSPORT, ORDER_MAS.ORD_REF, ORDER_MAS.VALID_DAYS, ORDER_MAS.VALID_DATE, ORDER_MAS.GST_RATE, ORDER_MAS.GST_AMT, ORDER_MAS.CGST_RATE, ORDER_MAS.CGST_AMT, ORDER_MAS.SGST_RATE, ORDER_MAS.SGST_AMT, ORDER_MAS.IGST_RATE, ORDER_MAS.IGST_AMT, ORDER_MAS.GROSS_AMT, ORDER_ITEM.SCODE, ORDER_ITEM.QTY, ORDER_ITEM.RATE, ORDER_ITEM.GST_RATE AS Expr7, ORDER_ITEM.DIS_PER, STOCK_MAS.SNAME, STOCK_MAS.UOM, STOCK_MAS.PROD_CODE FROM ACCOUNTS INNER JOIN ORDER_MAS ON ACCOUNTS.COMP_CODE = ORDER_MAS.COMP_CODE AND ACCOUNTS.ACODE = ORDER_MAS.ACODE INNER JOIN ORDER_ITEM ON ORDER_MAS.TRAN_DATE = ORDER_ITEM.TRAN_DATE AND ORDER_MAS.TRAN_NO = ORDER_ITEM.TRAN_NO INNER JOIN COMPANY ON ACCOUNTS.COMP_CODE = COMPANY.COMP_CODE INNER JOIN STOCK_MAS ON ORDER_ITEM.COMP_CODE = STOCK_MAS.COMP_CODE AND ORDER_ITEM.SCODE = STOCK_MAS.SCODE AND COMPANY.COMP_CODE = STOCK_MAS.COMP_CODE where COMPANY.COMP_CODE=101 and COMPANY.YR_START='2017-04-01 00:00:00.000' and COMPANY.YR_END='2018-03-31 00:00:00.000' and ORDER_MAS.TRAN_NO=7 and ORDER_MAS.TRAN_DATE='2019-01-30 00:00:00.000'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "viewPurchaseOrder");
                    rd.Load(Server.MapPath("~/reportCrystalrpts/PurchaseOrder.rpt"));
                    rd.SetDataSource(ds);
                    //rd.DataDefinition.FormulaFields["Logo"].Text = Server.MapPath("~/Admin/Company/LH/"+ ds.Tables[0].Rows[0]["CMPLOGO"].ToString());
                    rd.SetParameterValue("PARAM_LOGO", Server.MapPath("~/Admin/Company/LH/" + ds.Tables[0].Rows[0]["CMPLOGO"].ToString()));
                    rd.SetParameterValue("CMP_SIGN_LOGO", Server.MapPath("~/Admin/Company/BKP/" + ds.Tables[0].Rows[0]["CMPSIGNLOGO"].ToString()));
                    //  rd.DataDefinition["CompSignLogo"].Text = Server.MapPath("~/Admin/Company/BKP_PATH/" + ds.Tables[0].Rows[2]["CMPSIGNLOGO"].ToString());
                    crypurorder.ReportSource = rd;
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