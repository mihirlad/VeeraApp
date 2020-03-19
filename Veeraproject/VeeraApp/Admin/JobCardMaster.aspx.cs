using MihirValid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;

namespace VeeraApp
{
    public partial class JobCardMaster : System.Web.UI.Page
    {
        public static string compcode;
        static DataTable DtSearch = new DataTable();
        public static string Branchcode;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["USERCODE"] != null &&
               Session["USERNAME"] != null &&
               Session["USERTYPE"] != null &&
               Session["COMP_CODE"] != null &&
               Session["COMP_NAME"] != null &&
               Session["WORK_VIEWFLAG"] != null &&
               Session["BRANCH_CODE"] != null &&
               Session["INVTYPE_FLAG"] != null &&
               Session["BRANCH_NAME"] != null &&
               Session["BRANCH_TYPE"] != null &&
               Session["FIN_YEAR"] != null &&
               Session["FIN_YEAR_END"] != null &&
               Session["MAC"] != null &&
               Session["PC"] != null &&
               Session["INSERT"] != null &&
               Session["UPDATE"] != null &&
               Session["DELETE"] != null)
            {
                compcode = Session["COMP_CODE"].ToString();
                Branchcode = Session["BRANCH_CODE"].ToString();
                if (!IsPostBack == true)
                {
                    DivEntry.Visible = false;
                    DivView.Visible = true;

                    string JOBCARDMASTER = Request.QueryString["JCM"];
                    string AMCTYPE = Request.QueryString["A"];
                    string TRAN_NO = Request.QueryString["TRAN_NO"];
                    string TRAN_DATE = Request.QueryString["TRAN_DATE"];

                    CalendarExtenderJobCardDate.StartDate = Convert.ToDateTime(Session["FIN_YEAR"].ToString());
                    CalendarExtenderJobCardDate.EndDate = Convert.ToDateTime(Session["FIN_YEAR_END"].ToString());

                    FillJOBCARDMasterGrid(Session["COMP_CODE"].ToString());


                }
            }

            else
            {
                Response.Redirect("../Login.aspx");
            }
        }


        public void UserRights()
        {
            try
            {
                //   btnDelete.Visible = false;
                if (Session["INSERT"] != null)
                {
                    if (Session["INSERT"].ToString() == "Y")
                    {
                        BtnAdd.Visible = true;
                    }
                    else
                    {
                        BtnAdd.Visible = false;
                    }
                }


                if (Session["UPDATE"] != null)
                {
                    if (Session["UPDATE"].ToString() == "Y")
                    {
                        // btnSave.Enabled = true;
                    }
                    else
                    {
                        // btnSave.Enabled = false;
                    }
                }


                if (Session["DELETE"] != null)
                {
                    if (Session["DELETE"].ToString() == "Y")
                    {
                        //  btnDelete.Enabled = true;
                    }
                    else
                    {
                        // btnDelete.Enabled = false;
                    }
                }

            }
            catch (Exception)
            {
            }
        }


        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            TxtJobCardDate.Text = string.Empty;
            TxtJobCardNo.Text = string.Empty;
            TxtJobCardTime.Text = string.Empty;
            TxtPODate.Text = string.Empty;
            TxtPONumber.Text = string.Empty;
            TxtPartyName.Text = string.Empty;
            //    DdlContactPerson.SelectedIndex = 0;
            TxtContactPhone.Text = string.Empty;
            TxtContactEmail.Text = string.Empty;
            TxtComplainDate.Text = string.Empty;
            TxtComplainTime.Text = string.Empty;
            TxtComplainPerson.Text = string.Empty;
            TxtComplainPhone.Text = string.Empty;
            TxtCustomerRemark.Text = string.Empty;
            TxtPartyModelSrNo.Text = string.Empty;
            TxtPartySrNo.Text = string.Empty;
            TxtBrandName.Text = string.Empty;
            TxtBrandTypeName.Text = string.Empty;
            TxtModelName.Text = string.Empty;
            DdlServiceType.SelectedIndex = 0;
            TxtAMCNo.Text = string.Empty;
            TxtAMCFromDate.Text = string.Empty;
            TxtAMCToDate.Text = string.Empty;
            TxtJobAssignPersonName.Text = string.Empty;
            TxtJobAssignDate.Text = string.Empty;
            TxtJobAssignTime.Text = string.Empty;
            TxtRemark.Text = string.Empty;
            TxtCancelDescription.Text = string.Empty;
            TxtRunningHours.Text = string.Empty;
            TxtLoadingHours.Text = string.Empty;
            TxtJobStartDate.Text = string.Empty;
            TxtJobCloseDate.Text = string.Empty;
            TxtJobStartTime.Text = string.Empty;
            TxtJobCloseTime.Text = string.Empty;
            TxtSignaturePerson.Text = string.Empty;
            TxtSignaturePhone.Text = string.Empty;
            DdlClosed.SelectedValue = "N";
            TxtNextServiceDate.Text = string.Empty;
            TxtClosedBy.Text = string.Empty;
            TxtClosedDate.Text = string.Empty;
            TxtLastJobCardNo.Text = string.Empty;
            TxtLastJobCardDate.Text = string.Empty;
            TxtLastLoadingHours.Text = string.Empty;
            TxtLastRunningHours.Text = string.Empty;
            TxtServicePerson1.Text = string.Empty;
            TxtServicePerson2.Text = string.Empty;
            TxtServicePerson3.Text = string.Empty;
            TxtServicePerson4.Text = string.Empty;
            TxtServicePerson5.Text = string.Empty;
            TxtServicePersonProfitPer1.Text = string.Empty;
            TxtServicePersonProfitPer2.Text = string.Empty;
            TxtServicePersonProfitPer3.Text = string.Empty;
            TxtServicePersonProfitPer4.Text = string.Empty;
            TxtServicePersonProfitPer5.Text = string.Empty;
            TxtServicePersonProfitAmt1.Text = string.Empty;
            TxtServicePersonProfitAmt2.Text = string.Empty;
            TxtServicePersonProfitAmt3.Text = string.Empty;
            TxtServicePersonProfitAmt4.Text = string.Empty;
            TxtServicePersonProfitAmt5.Text = string.Empty;
            TxtProfitTotalPercentage.Text = string.Empty;
            TxtProfitTotalAmount.Text = string.Empty;
            TxtCancelRemark.Text = string.Empty;
            TxtInvoiceDate.Text = string.Empty;
            TxtInvoiceTime.Text = string.Empty;
            TxtInvoiceNo.Text = string.Empty;

            BtncallUpd.Text = "SAVE";

            SetInitialRowJobCardComplain();
            SetInitialRowServiceRemarks();
            SetInitialRowLabourCharges();
            SetInitialRowServiceDetails();
            SetInitialRowServiceUseItem();


        }

        public void ControllerEnable()
        {
            TxtJobCardDate.Enabled = true;
            TxtJobCardNo.Enabled = false;
            TxtJobCardTime.Enabled = true;
            TxtPODate.Enabled = true;
            TxtPONumber.Enabled = true;
            TxtPartyName.Enabled = true;
            DdlContactPerson.Enabled = true;
            TxtContactPhone.Enabled = true;
            TxtContactEmail.Enabled = true;
            TxtComplainDate.Enabled = true;
            TxtComplainTime.Enabled = true;
            TxtComplainPerson.Enabled = true;
            TxtComplainPhone.Enabled = true;
            TxtCustomerRemark.Enabled = true;
            TxtPartyModelSrNo.Enabled = false;
            TxtPartySrNo.Enabled = false;
            TxtMfgSrNo.Enabled = false;
            TxtBrandName.Enabled = false;
            TxtBrandTypeName.Enabled = false;
            TxtModelName.Enabled = false;
            DdlServiceType.Enabled = false;
            TxtAMCNo.Enabled = false;
            TxtAMCFromDate.Enabled = false;
            TxtAMCToDate.Enabled = false;
            TxtJobAssignPersonName.Enabled = true;
            TxtJobAssignDate.Enabled = true;
            TxtJobAssignTime.Enabled = true;
            TxtRemark.Enabled = true;
            TxtCancelDescription.Enabled = true;
            TxtRunningHours.Enabled = true;
            TxtLoadingHours.Enabled = true;
            TxtJobStartDate.Enabled = true;
            TxtJobCloseDate.Enabled = true;
            TxtJobStartTime.Enabled = true;
            TxtJobCloseTime.Enabled = true;
            TxtSignaturePerson.Enabled = true;
            TxtSignaturePhone.Enabled = true;
            DdlClosed.Enabled = true;
            TxtNextServiceDate.Enabled = true;
            TxtClosedBy.Enabled = true;
            TxtClosedDate.Enabled = true;
            TxtLastJobCardNo.Enabled = true;
            TxtLastJobCardDate.Enabled = true;
            TxtLastLoadingHours.Enabled = true;
            TxtLastRunningHours.Enabled = true;
            TxtServicePerson1.Enabled = true;
            TxtServicePerson2.Enabled = true;
            TxtServicePerson3.Enabled = true;
            TxtServicePerson4.Enabled = true;
            TxtServicePerson5.Enabled = true;
            TxtServicePersonProfitPer1.Enabled = true;
            TxtServicePersonProfitPer2.Enabled = true;
            TxtServicePersonProfitPer3.Enabled = true;
            TxtServicePersonProfitPer4.Enabled = true;
            TxtServicePersonProfitPer5.Enabled = true;
            TxtServicePersonProfitAmt1.Enabled = true;
            TxtServicePersonProfitAmt2.Enabled = true;
            TxtServicePersonProfitAmt3.Enabled = true;
            TxtServicePersonProfitAmt4.Enabled = true;
            TxtServicePersonProfitAmt5.Enabled = true;
            TxtProfitTotalPercentage.Enabled = true;
            TxtProfitTotalAmount.Enabled = true;
            TxtCancelRemark.Enabled = true;
            TxtInvoiceDate.Enabled = false;
            TxtInvoiceTime.Enabled = false;
            TxtInvoiceNo.Enabled = false;
        }

        public void ControllerDisabe()
        {
            TxtJobCardDate.Enabled = false;
            TxtJobCardNo.Enabled = false;
            TxtJobCardTime.Enabled = false;
            TxtPODate.Enabled = false;
            TxtPONumber.Enabled = false;
            TxtPartyName.Enabled = false;
            DdlContactPerson.Enabled = false;
            TxtContactPhone.Enabled = false;
            TxtContactEmail.Enabled = false;
            TxtComplainDate.Enabled = false;
            TxtComplainTime.Enabled = false;
            TxtComplainPerson.Enabled = false;
            TxtComplainPhone.Enabled = false;
            TxtCustomerRemark.Enabled = false;
            TxtPartyModelSrNo.Enabled = false;
            TxtPartySrNo.Enabled = false;
            TxtMfgSrNo.Enabled = false;
            TxtBrandName.Enabled = false;
            TxtBrandTypeName.Enabled = false;
            TxtModelName.Enabled = false;
            DdlServiceType.Enabled = false;
            TxtAMCNo.Enabled = false;
            TxtAMCFromDate.Enabled = false;
            TxtAMCToDate.Enabled = false;
            TxtJobAssignPersonName.Enabled = false;
            TxtJobAssignDate.Enabled = false;
            TxtJobAssignTime.Enabled = false;
            TxtRemark.Enabled = false;
            TxtCancelDescription.Enabled = false;
            TxtRunningHours.Enabled = false;
            TxtLoadingHours.Enabled = false;
            TxtJobStartDate.Enabled = false;
            TxtJobCloseDate.Enabled = false;
            TxtJobStartTime.Enabled = false;
            TxtJobCloseTime.Enabled = false;
            TxtSignaturePerson.Enabled = false;
            TxtSignaturePhone.Enabled = false;
            DdlClosed.Enabled = false;
            TxtNextServiceDate.Enabled = false;
            TxtClosedBy.Enabled = false;
            TxtClosedDate.Enabled = false;
            TxtLastJobCardNo.Enabled = false;
            TxtLastJobCardDate.Enabled = false;
            TxtLastLoadingHours.Enabled = false;
            TxtLastRunningHours.Enabled = false;
            TxtServicePerson1.Enabled = false;
            TxtServicePerson2.Enabled = false;
            TxtServicePerson3.Enabled = false;
            TxtServicePerson4.Enabled = false;
            TxtServicePerson5.Enabled = false;
            TxtServicePersonProfitPer1.Enabled = false;
            TxtServicePersonProfitPer2.Enabled = false;
            TxtServicePersonProfitPer3.Enabled = false;
            TxtServicePersonProfitPer4.Enabled = false;
            TxtServicePersonProfitPer5.Enabled = false;
            TxtServicePersonProfitAmt1.Enabled = false;
            TxtServicePersonProfitAmt2.Enabled = false;
            TxtServicePersonProfitAmt3.Enabled = false;
            TxtServicePersonProfitAmt4.Enabled = false;
            TxtServicePersonProfitAmt5.Enabled = false;
            TxtProfitTotalPercentage.Enabled = false;
            TxtProfitTotalAmount.Enabled = false;
            TxtCancelRemark.Enabled = false;
            TxtInvoiceDate.Enabled = false;
            TxtInvoiceTime.Enabled = false;
            TxtInvoiceNo.Enabled = false;

        }


        public void FillNetAmount()
        {
            try
            {

                double GridChargesTotalAmt = Convert.ToDouble(TxtTotalChargesAmt.Text.Trim());


                double decimalpoints = Math.Abs(GridChargesTotalAmt - Math.Floor(GridChargesTotalAmt));
                if (decimalpoints > 0.5)
                {
                    double ro = 1 - decimalpoints;

                    TxtROamt.Text = Math.Round(ro, 2).ToString();

                    TxtNetAmt.Text = Convert.ToString(Convert.ToDouble(GridChargesTotalAmt) + ro);
                }

                else
                {

                    double ro = (1 - decimalpoints) - 1;

                    TxtROamt.Text = Math.Round(ro, 2).ToString();

                    TxtNetAmt.Text = Convert.ToString(Math.Floor(GridChargesTotalAmt));
                }
                //      UpdateTotalAmount.Update();

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            lblmsg.Text = string.Empty;
            UserRights();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
                ControllerEnable();
                UserRights();
                Btncalldel.Visible = false;
                BtncallUpd.Visible = true;
                btnSave.Enabled = true;
                btnSave.Visible = true;
                DivEntry.Visible = true;
                DivView.Visible = false;
                TxtJobCardDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                TxtJobCardTime.Text = System.DateTime.Now.ToString("HH:mm");
                BtnViewAssignLog.Enabled = false;

                string JOBCARD_NO = JOBCARD_MASLogicLayer.GetJOBCARDNumber_JOBCARDMASCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtJobCardDate.Text.Trim()).ToString("yyyy-MM-dd"));
                if (JOBCARD_NO.Length <= 8)
                {
                    TxtJobCardNo.Text = JOBCARD_NO;
                }
                else
                {
                    TxtJobCardNo.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCancelJobName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from job_cancelmas where COMP_CODE=@COMP_CODE and cancel_name like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> JobNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                JobNames.Add(dt.Rows[i][2].ToString());
            }
            return JobNames;
        }

        protected void TxtCancelDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtCancelJob = new DataTable();
                DtCancelJob = job_cancelmasLogicLayer.GetAllJOB_CancelMasterByCompany(Session["COMP_CODE"].ToString());
                if (TxtCancelDescription.Text != string.Empty && TxtCancelDescription.Text != null)
                {
                    DataView Dv = new DataView(DtCancelJob);
                    Dv.RowFilter = "cancel_name= '" + TxtCancelDescription.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfCancelCode.Value = DtView.Rows[0]["cancel_code"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtncallUpd_Click(object sender, EventArgs e)
        {
            try
            {
                if (BtncallUpd.Text == "UPDATE")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel1", "ShowModel1()", true);
                }
                else
                {
                    #region INSERT DATA INTO JOBCARD MASTER 

                    JOBCARD_MASLogicLayer insert = new JOBCARD_MASLogicLayer();

                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                    //insert.TRAN_DATE = HfTranDate.Value.Trim();
                    //insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.JOBCARD_NO = TxtJobCardNo.Text.Trim();
                    insert.JOBCARD_DATE = Convert.ToDateTime(TxtJobCardDate.Text.Trim()).ToString("MM-dd-yyyy");
                    insert.JOBCARD_TIME = TxtJobCardTime.Text.Trim();
                    insert.ACODE = HfACODE.Value.Trim();
                    insert.CONTACT_PERSON = DdlContactPerson.SelectedValue.Trim().ToUpper();
                    insert.CONTACT_PHONE = TxtContactPhone.Text.Trim();
                    insert.CONTACT_EMAIL = TxtContactEmail.Text.Trim();
                    insert.COMPLAIN_DATE = Convert.ToDateTime(TxtComplainDate.Text.Trim()).ToString("MM-dd-yyyy");
                    insert.COMPLAIN_TIME = TxtComplainTime.Text.Trim();
                    insert.COMPLAIN_PERSON = TxtComplainPerson.Text.Trim().ToUpper();
                    insert.COMPLAIN_PHONE = TxtComplainPhone.Text.Trim().ToUpper();
                    insert.PARTY_REFSRNO = HfPartRefSrNo.Value.Trim();
                    if (TxtRunningHours.Text == string.Empty)
                    {
                        insert.RUNNING_HRS = null;
                    }
                    else
                    {
                        insert.RUNNING_HRS = TxtRunningHours.Text.Trim();
                    }
                    if (TxtLoadingHours.Text == string.Empty)
                    {
                        insert.LOADING_HRS = null;
                    }
                    else
                    {
                        insert.LOADING_HRS = TxtLoadingHours.Text.Trim();
                    }

                    if (TxtJobStartDate.Text == string.Empty)
                    {
                        insert.JOBSTART_DATE = "";
                    }
                    else
                    {
                        insert.JOBSTART_DATE = Convert.ToDateTime(TxtJobStartDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }

                    if (TxtJobCloseDate.Text == string.Empty)
                    {
                        insert.JOBCLOSE_DATE = "";
                    }
                    else
                    {
                        insert.JOBCLOSE_DATE = Convert.ToDateTime(TxtJobCloseDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }

                    if (TxtJobStartTime.Text == string.Empty)
                    {
                        insert.JOBSTART_TIME = "";
                    }
                    else
                    {
                        insert.JOBSTART_TIME = TxtJobStartTime.Text.Trim();
                    }

                    if (TxtJobCloseTime.Text == string.Empty)
                    {
                        insert.JOBCLOSE_TIME = "";
                    }
                    else
                    {
                        insert.JOBCLOSE_TIME = TxtJobCloseTime.Text.Trim();
                    }

                    if (TxtServicePerson1.Text == string.Empty)
                    {
                        insert.BCODE1 = null;
                    }
                    else
                    {
                        insert.BCODE1 = HfServicePeronBCODE1.Value.Trim();
                    }

                    if (TxtServicePerson2.Text == string.Empty)
                    {
                        insert.BCODE2 = null;
                    }
                    else
                    {
                        insert.BCODE2 = HfServicePeronBCODE2.Value.Trim();
                    }

                    if (TxtServicePerson3.Text == string.Empty)
                    {
                        insert.BCODE3 = null;
                    }
                    else
                    {
                        insert.BCODE3 = HfServicePeronBCODE3.Value.Trim();
                    }

                    if (TxtServicePerson4.Text == string.Empty)
                    {
                        insert.BCODE4 = null;
                    }
                    else
                    {
                        insert.BCODE4 = HfServicePeronBCODE4.Value.Trim();
                    }

                    if (TxtServicePerson5.Text == string.Empty)
                    {
                        insert.BCODE5 = null;
                    }
                    else
                    {
                        insert.BCODE5 = HfServicePeronBCODE5.Value.Trim();
                    }

                    if (TxtServicePersonProfitPer1.Text == string.Empty)
                    {
                        insert.BCODE1_PER = null;
                    }
                    else
                    {
                        insert.BCODE1_PER = TxtServicePersonProfitPer1.Text.Trim();
                    }

                    if (TxtServicePersonProfitPer2.Text == string.Empty)
                    {
                        insert.BCODE2_PER = null;
                    }
                    else
                    {
                        insert.BCODE2_PER = TxtServicePersonProfitPer2.Text.Trim();
                    }

                    if (TxtServicePersonProfitPer3.Text == string.Empty)
                    {
                        insert.BCODE3_PER = null;
                    }
                    else
                    {
                        insert.BCODE3_PER = TxtServicePersonProfitPer3.Text.Trim();
                    }

                    if (TxtServicePersonProfitPer4.Text == string.Empty)
                    {
                        insert.BCODE4_PER = null;
                    }
                    else
                    {
                        insert.BCODE4_PER = TxtServicePersonProfitPer4.Text.Trim();
                    }

                    if (TxtServicePersonProfitPer5.Text == string.Empty)
                    {
                        insert.BCODE5_PER = null;
                    }
                    else
                    {
                        insert.BCODE5_PER = TxtServicePersonProfitPer5.Text.Trim();
                    }

                    if (TxtServicePersonProfitAmt1.Text == string.Empty)
                    {
                        insert.BCODE1_AMT = null;
                    }
                    else
                    {
                        insert.BCODE1_AMT = TxtServicePersonProfitAmt1.Text.Trim();
                    }

                    if (TxtServicePersonProfitAmt2.Text == string.Empty)
                    {
                        insert.BCODE2_AMT = null;
                    }
                    else
                    {
                        insert.BCODE2_AMT = TxtServicePersonProfitAmt2.Text.Trim();
                    }

                    if (TxtServicePersonProfitAmt3.Text == string.Empty)
                    {
                        insert.BCODE3_AMT = null;
                    }
                    else
                    {
                        insert.BCODE3_AMT = TxtServicePersonProfitAmt3.Text.Trim();
                    }

                    if (TxtServicePersonProfitAmt4.Text == string.Empty)
                    {
                        insert.BCODE4_AMT = null;
                    }
                    else
                    {
                        insert.BCODE4_AMT = TxtServicePersonProfitAmt4.Text.Trim();
                    }

                    if (TxtServicePersonProfitAmt5.Text == string.Empty)
                    {
                        insert.BCODE5_AMT = null;
                    }
                    else
                    {
                        insert.BCODE5_AMT = TxtServicePersonProfitAmt5.Text.Trim();
                    }

                    insert.REF_TRAN_DATE = null;
                    insert.REF_TRAN_NO = null;
                    insert.GROSS_AMT = null;
                    if (TxtServiceTaxPer.Text == string.Empty)
                    {
                        insert.EX_DUTY_PER = null;
                    }
                    else
                    {
                        insert.EX_DUTY_PER = TxtServiceTaxPer.Text.Trim();
                    }

                    if (TxtServiceTaxAmt.Text == string.Empty)
                    {
                        insert.EX_DUTY_AMT = null;
                    }
                    else
                    {
                        insert.EX_DUTY_AMT = TxtServiceTaxAmt.Text.Trim();
                    }

                    insert.EX_CESS_PER = null;
                    insert.EX_CESS_AMT = null;
                    insert.EX_SHCESS_PER = null;
                    insert.EX_SHCESS_AMT = null;
                    insert.RO_AMT = null;
                    insert.NET_AMT = null;

                    if (TxtProfitPercentageJobMas.Text == string.Empty)
                    {
                        insert.PROFIT_PER = null;
                    }
                    else
                    {
                        insert.PROFIT_PER = TxtProfitPercentageJobMas.Text.Trim();
                    }

                    if (TxtProfitAmountJobMas.Text == string.Empty)
                    {

                        insert.PROFIT_AMT = null;
                    }
                    else
                    {
                        insert.PROFIT_AMT = TxtProfitAmountJobMas.Text.Trim();
                    }
                    insert.REMARK = TxtRemark.Text.Trim();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_DATE = "";
                    insert.CLOSE_FLAG = DdlClosed.SelectedValue.Trim().ToUpper();
                    if (DdlClosed.SelectedValue.ToString() == "Y")
                    {
                        insert.CLOSE_DATE = Convert.ToDateTime(TxtClosedDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CLOSE_DATE = "";
                    }

                    if (DdlClosed.SelectedValue.ToString() == "Y")
                    {
                        insert.CLOSE_USERID = TxtClosedBy.Text.Trim().ToUpper();
                    }
                    else
                    {
                        insert.CLOSE_USERID = "";
                    }

                    insert.CHK_FLAG = null;
                    insert.CHK_DATE = null;
                    insert.CHK_USERID = null;

                    if (TxtJobAssignPersonName.Text == string.Empty)
                    {
                        insert.ASSIGN_BCODE = null;
                    }
                    else
                    {
                        insert.ASSIGN_BCODE = HfJobAssignPersonName.Value.Trim();
                    }

                    if (TxtJobAssignDate.Text == string.Empty)
                    {
                        insert.ASSIGN_DATE = "";
                    }
                    else
                    {
                        insert.ASSIGN_DATE = Convert.ToDateTime(TxtJobAssignDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }

                    if (TxtJobAssignTime.Text == string.Empty)
                    {
                        insert.ASSIGN_TIME = "";
                    }
                    else
                    {
                        insert.ASSIGN_TIME = TxtJobAssignTime.Text.Trim();
                    }

                    insert.INV_NUMBER = null;
                    insert.INV_DATE = null;
                    insert.INV_TIME = null;
                    insert.CUSTOMER_REMARK = TxtCustomerRemark.Text.Trim().ToUpper();
                    if (TxtLastJobCardNo.Text == string.Empty)
                    {
                        insert.LAST_JOBCARD_NO = null;
                    }
                    else
                    {
                        insert.LAST_JOBCARD_NO = TxtLastJobCardNo.Text.Trim();
                    }

                    if (TxtLastJobCardDate.Text == string.Empty)
                    {
                        insert.LAST_JOBCARD_DATE = "";
                    }
                    else
                    {
                        insert.LAST_JOBCARD_DATE = Convert.ToDateTime(TxtLastJobCardDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }

                    if (TxtLastRunningHours.Text == string.Empty)
                    {
                        insert.LAST_RUNNING_HRS = null;
                    }
                    else
                    {
                        insert.LAST_RUNNING_HRS = TxtLastRunningHours.Text.Trim();
                    }

                    if (TxtLastLoadingHours.Text == string.Empty)
                    {
                        insert.LAST_LOADING_HRS = null;
                    }
                    else
                    {
                        insert.LAST_LOADING_HRS = TxtLastLoadingHours.Text.Trim();
                    }

                    insert.SIGN_PERSON = TxtSignaturePerson.Text.Trim().ToUpper();
                    insert.SIGN_PHONE = TxtSignaturePhone.Text.Trim();
                    insert.SERVICE_TYPE = DdlServiceType.SelectedValue.Trim().ToUpper();
                    insert.AMC_TRAN_DATE = Convert.ToDateTime(HfAMC_TRAN_DATE.Value.ToString()).ToString("MM-dd-yyyy");
                    insert.AMC_TRAN_NO = HfAMC_TRAN_NO.Value.Trim();
                    insert.AMC_SRNO = HfAMC_SRNO.Value.Trim();
                    insert.AMC_SUB_SRNO = null;
                    if (TxtNextServiceDate.Text == string.Empty)
                    {
                        insert.NEXT_SERVICE_DATE = "";
                    }
                    else
                    {
                        insert.NEXT_SERVICE_DATE = Convert.ToDateTime(TxtNextServiceDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }

                    insert.STATUS = "";
                    insert.LAST_TRAN_DATE = null;
                    insert.LAST_TRAN_NO = null;
                    insert.PO_NO = TxtPONumber.Text.Trim();
                    if (TxtPODate.Text == string.Empty)
                    {
                        TxtPODate.Text = "";
                    }
                    else
                    {
                        insert.PO_DT = Convert.ToDateTime(TxtPODate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    insert.COMPLAIN_TYPE = null;
                    insert.COMPLAIN_NO = null;
                    insert.TRAN_FROM = "J";

                    if (TxtCancelDescription.Text == string.Empty)
                    {
                        insert.CANCEL_CODE = null;
                    }
                    else
                    {
                        insert.CANCEL_CODE = HfCancelCode.Value.Trim();
                    }

                    insert.CANCEL_REMARK = TxtCancelRemark.Text.Trim();
                    insert.cancel_date = null;
                    insert.cancel_time = null;
                    insert.cancel_bcode = null;
                    insert.cancel_userid = null;

                    #endregion

                    #region INSERT INTO COMPLAIN DETAILS GRID

                    XmlDocument XDoc_JobComplain = new XmlDocument();
                    XmlDeclaration dec1 = XDoc_JobComplain.CreateXmlDeclaration("1.0", null, null);
                    XDoc_JobComplain.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc_JobComplain.CreateElement("root");
                    XDoc_JobComplain.AppendChild(root1);
                    int ComplainSRNO = 1;

                    foreach (GridViewRow row in GvJobCardComplain.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                            HiddenField HfTranNo = row.FindControl("HfTranNo") as HiddenField;
                            HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                            HiddenField HfComplainCode = row.FindControl("HfComplainCode") as HiddenField;

                            TextBox TxtComplainDescription = row.FindControl("TxtComplainDescription") as TextBox;
                            TextBox TxtComplainCheckingDetails = row.FindControl("TxtComplainCheckingDetails") as TextBox;



                            if (HfComplainCode.Value != "0" && HfComplainCode.Value != string.Empty && HfComplainCode.Value != null)
                            {

                                XmlElement HandleDetail1 = XDoc_JobComplain.CreateElement("JOBCARD_COMPLAINDetails");
                                HandleDetail1.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail1.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail1.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                                HandleDetail1.SetAttribute("SRNO", ComplainSRNO.ToString());
                                HandleDetail1.SetAttribute("COMPLAIN_DESC", TxtComplainCheckingDetails.Text.Trim());
                                HandleDetail1.SetAttribute("REMARK", "");
                                HandleDetail1.SetAttribute("INS_USERID", Session["USERNAME"].ToString());
                                HandleDetail1.SetAttribute("INS_DATE", "");
                                HandleDetail1.SetAttribute("UPD_USERID", Session["USERNAME"].ToString());
                                HandleDetail1.SetAttribute("UPD_DATE", "");
                                HandleDetail1.SetAttribute("COMPLAIN_CODE", HfComplainCode.Value.Trim());

                                root1.AppendChild(HandleDetail1);
                                ComplainSRNO++;
                            }



                        }
                    }

                    #endregion

                    #region INSERT INTO JOBCARD SERVICE DETAILS GRID

                    XmlDocument XDoc_ServiceDetail = new XmlDocument();
                    XmlDeclaration dec2 = XDoc_ServiceDetail.CreateXmlDeclaration("1.0", null, null);
                    XDoc_ServiceDetail.AppendChild(dec2);// Create the root element
                    XmlElement root2 = XDoc_ServiceDetail.CreateElement("root");
                    XDoc_ServiceDetail.AppendChild(root2);
                    int ServiceSRNO = 1;

                    foreach (GridViewRow row in GvServiceDetail.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {

                            HiddenField HfBrandTypeCodeGrid = row.FindControl("HfBrandTypeCodeGrid") as HiddenField;
                            HiddenField HfBrandTypeSrNo = row.FindControl("HfBrandTypeSrNo") as HiddenField;

                            CheckBox CheckBoxOption1 = row.FindControl("CheckBoxOption1") as CheckBox;
                            CheckBox CheckBoxOption2 = row.FindControl("CheckBoxOption2") as CheckBox;
                            CheckBox CheckBoxChecking1 = row.FindControl("CheckBoxChecking1") as CheckBox;
                            CheckBox CheckBoxChecking2 = row.FindControl("CheckBoxChecking2") as CheckBox;
                            CheckBox CheckBoxRemark1 = row.FindControl("CheckBoxRemark1") as CheckBox;
                            CheckBox CheckBoxRemark2 = row.FindControl("CheckBoxRemark2") as CheckBox;
                            CheckBox TxtComplainDescription = row.FindControl("TxtComplainDescription") as CheckBox;




                            if (HfBrandTypeCodeGrid.Value != "0" && HfBrandTypeCodeGrid.Value != string.Empty && HfBrandTypeCodeGrid.Value != null)
                            {

                                XmlElement HandleDetail2 = XDoc_ServiceDetail.CreateElement("JOBCARD_SERVICEDetails");
                                HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                                HandleDetail2.SetAttribute("SRNO", ServiceSRNO.ToString());
                                HandleDetail2.SetAttribute("BRANDTYPE_CODE", HfBrandTypeCodeGrid.Value.Trim());
                                HandleDetail2.SetAttribute("BRANDTYPE_SRNO", HfBrandTypeSrNo.Value.Trim());

                                if (CheckBoxOption1.Checked == true)
                                {
                                    HandleDetail2.SetAttribute("RESULT_FLAG_1_1", "Y");
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("RESULT_FLAG_1_1", "N");
                                }

                                if (CheckBoxChecking1.Checked == true)
                                {
                                    HandleDetail2.SetAttribute("RESULT_FLAG_2_1", "Y");
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("RESULT_FLAG_2_1", "N");
                                }

                                if (CheckBoxRemark1.Checked == true)
                                {
                                    HandleDetail2.SetAttribute("RESULT_FLAG_3_1", "Y");
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("RESULT_FLAG_3_1", "N");
                                }

                                HandleDetail2.SetAttribute("REMARK", "");
                                HandleDetail2.SetAttribute("INS_USERID", Session["USERNAME"].ToString());
                                HandleDetail2.SetAttribute("INS_DATE", "");
                                HandleDetail2.SetAttribute("UPD_USERID", Session["USERNAME"].ToString());
                                HandleDetail2.SetAttribute("UPD_DATE", "");

                                if (CheckBoxOption2.Checked == true)
                                {
                                    HandleDetail2.SetAttribute("RESULT_FLAG_1_2", "Y");
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("RESULT_FLAG_1_2", "N");
                                }

                                if (CheckBoxChecking2.Checked == true)
                                {
                                    HandleDetail2.SetAttribute("RESULT_FLAG_2_2", "Y");
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("RESULT_FLAG_2_2", "N");
                                }

                                if (CheckBoxRemark2.Checked == true)
                                {
                                    HandleDetail2.SetAttribute("RESULT_FLAG_3_2", "Y");
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("RESULT_FLAG_3_2", "N");
                                }

                                root2.AppendChild(HandleDetail2);
                                ServiceSRNO++;

                            }




                        }

                    }

                    #endregion

                    #region INSERT INTO JOBCARD SERVICE REMARKS INTO GRID


                    XmlDocument XDoc_ServiceRemark = new XmlDocument();
                    XmlDeclaration dec3 = XDoc_ServiceRemark.CreateXmlDeclaration("1.0", null, null);
                    XDoc_ServiceRemark.AppendChild(dec3);// Create the root element
                    XmlElement root3 = XDoc_ServiceRemark.CreateElement("root");
                    XDoc_ServiceRemark.AppendChild(root3);
                    int RemarkSRNO = 1;

                    foreach (GridViewRow row in GvServiceRemarks.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {

                            HiddenField HfCompCode = row.FindControl("HfCompCode") as HiddenField;
                            HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                            HiddenField HfTranNo = row.FindControl("HfTranNo") as HiddenField;
                            HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;

                            TextBox TxtServiceRemark = row.FindControl("TxtServiceRemark") as TextBox;



                            if (TxtServiceRemark.Text != string.Empty && TxtServiceRemark.Text != null)
                            {

                                XmlElement HandleDetail3 = XDoc_ServiceRemark.CreateElement("JOBCARD_REMARKDetails");

                                HandleDetail3.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail3.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail3.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                                HandleDetail3.SetAttribute("SRNO", RemarkSRNO.ToString());
                                HandleDetail3.SetAttribute("REMARK", TxtServiceRemark.Text.Trim());
                                HandleDetail3.SetAttribute("INS_DATE", "");
                                HandleDetail3.SetAttribute("INS_USERID", Session["USERNAME"].ToString());
                                HandleDetail3.SetAttribute("UPD_DATE", "");
                                HandleDetail3.SetAttribute("UPD_USERID", Session["USERNAME"].ToString());
                                root3.AppendChild(HandleDetail3);
                                RemarkSRNO++;


                            }




                        }
                    }


                    #endregion


                    #region INSERT INTO SERVICE USE ITEM INTO GRID

                    XmlDocument XDoc_ServiceUseItem = new XmlDocument();
                    XmlDeclaration dec4 = XDoc_ServiceUseItem.CreateXmlDeclaration("1.0", null, null);
                    XDoc_ServiceUseItem.AppendChild(dec4);// Create the root element
                    XmlElement root4 = XDoc_ServiceUseItem.CreateElement("root");
                    XDoc_ServiceUseItem.AppendChild(root4);
                    int UseItemSRNO = 1;

                    foreach (GridViewRow row in GvServiceUseItem.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {

                            HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                            HiddenField HfRefTranDate = row.FindControl("HfRefTranDate") as HiddenField;
                            HiddenField HfRefTranNo = row.FindControl("HfRefTranNo") as HiddenField;
                            HiddenField HfRefSrNo = row.FindControl("HfRefSrNo") as HiddenField;

                            TextBox TxtUseQty = row.FindControl("TxtUseQty") as TextBox;



                            if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != string.Empty && HfDetailSCode.Value != null)
                            {


                                XmlElement HandleDetail4 = XDoc_ServiceUseItem.CreateElement("JOBCARD_SERVICE_USE_ITEMDetails");
                                HandleDetail4.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail4.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail4.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                                HandleDetail4.SetAttribute("SRNO", UseItemSRNO.ToString());
                                HandleDetail4.SetAttribute("SCODE", HfDetailSCode.Value.Trim());
                                HandleDetail4.SetAttribute("REF_TRAN_DATE", Convert.ToDateTime(HfRefTranDate.Value.Trim()).ToString("MM-dd-yyyy"));
                                HandleDetail4.SetAttribute("REF_TRAN_NO", HfRefTranNo.Value.Trim());
                                HandleDetail4.SetAttribute("REF_SRNO", HfRefSrNo.Value.Trim());
                                HandleDetail4.SetAttribute("QTY", TxtUseQty.Text.Trim());


                                root4.AppendChild(HandleDetail4);
                                UseItemSRNO++;

                            }


                        }
                    }

                    #endregion

                    #region INSERT INTO SERVICE LABOURS CHARGES Details GRID


                    XmlDocument XDoc_LabourCharges = new XmlDocument();
                    XmlDeclaration dec5 = XDoc_LabourCharges.CreateXmlDeclaration("1.0", null, null);
                    XDoc_LabourCharges.AppendChild(dec5);// Create the root element
                    XmlElement root5 = XDoc_LabourCharges.CreateElement("root");
                    XDoc_LabourCharges.AppendChild(root5);
                    int ChargesSRNO = 1;

                    foreach (GridViewRow row in GvLabourChagresDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {

                            HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                            HiddenField HfTranNo = row.FindControl("HfTranNo") as HiddenField;
                            HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                            HiddenField HfChargesCode = row.FindControl("HfChargesCode") as HiddenField;

                            TextBox TxtChargesDescription = row.FindControl("TxtChargesDescription") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtChargesAmount = row.FindControl("TxtChargesAmount") as TextBox;
                            TextBox TxtRemarks = row.FindControl("TxtRemarks") as TextBox;



                            if (HfChargesCode.Value != "0" && HfChargesCode.Value != string.Empty && HfChargesCode.Value != null)
                            {


                                XmlElement HandleDetail5 = XDoc_LabourCharges.CreateElement("JOBCARD_LAB_CHARGEDetails");
                                HandleDetail5.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail5.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail5.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                                HandleDetail5.SetAttribute("SRNO", ChargesSRNO.ToString());
                                HandleDetail5.SetAttribute("CCODE", HfChargesCode.Value.Trim());
                                HandleDetail5.SetAttribute("LAB_DESC", TxtChargesDescription.Text.Trim());
                                if (TxtQty.Text == string.Empty)
                                {
                                    HandleDetail5.SetAttribute("QTY", "0");
                                }
                                else
                                {
                                    HandleDetail5.SetAttribute("QTY", TxtQty.Text.Trim());
                                }

                                if (TxtRate.Text == string.Empty)
                                {
                                    HandleDetail5.SetAttribute("RATE", "0");
                                }
                                else
                                {
                                    HandleDetail5.SetAttribute("RATE", TxtRate.Text.Trim());
                                }

                                if (TxtChargesAmount.Text == string.Empty)
                                {
                                    HandleDetail5.SetAttribute("AMT", "0");
                                }
                                else
                                {
                                    HandleDetail5.SetAttribute("AMT", TxtChargesAmount.Text.Trim());
                                }

                                HandleDetail5.SetAttribute("REMARK", TxtRemarks.Text.Trim());
                                HandleDetail5.SetAttribute("INS_DATE", "");
                                HandleDetail5.SetAttribute("INS_USERID", Session["USERNAME"].ToString());
                                HandleDetail5.SetAttribute("UPD_DATE", "");
                                HandleDetail5.SetAttribute("UPD_USERID", Session["USERNAME"].ToString());
                                root5.AppendChild(HandleDetail5);
                                ChargesSRNO++;
                            }





                        }
                    }

                    #endregion


                    if (TxtProfitTotalPercentage.Text == "100" || TxtProfitTotalPercentage.Text == "0" || TxtProfitTotalPercentage.Text == string.Empty)
                    {


                        string str = JOBCARD_MASLogicLayer.InsertJOBCARD_MASDetail(insert, validation.RSC(XDoc_JobComplain.OuterXml), validation.RSC(XDoc_ServiceDetail.OuterXml), validation.RSC(XDoc_ServiceRemark.OuterXml), validation.RSC(XDoc_ServiceUseItem.OuterXml), validation.RSC(XDoc_LabourCharges.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"));

                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "JOBCARD MASTER SAVE SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillJOBCARDMasterGrid(Session["COMP_CODE"].ToString());
                            UserRights();


                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "JOBCARD MASTER ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : JOBCARD MASTER NOT SAVED";
                            lblmsg.ForeColor = Color.Red;

                        }

                    }

                    else
                    {
                        lblmsg.Text = "ERROR :TOTAL PERCENTAGE SHOULD BE 100%";
                        lblmsg.ForeColor = Color.Red;

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillJOBCARDMasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = JOBCARD_MASLogicLayer.GetAllJOBCARD_MASTERDetails(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvJobCardMaster.DataSource = Dv.ToTable();
            GvJobCardMaster.DataBind();

            DtSearch = Dv.ToTable();

        }


        public void FillAccountNameOnUpdate(string Id)
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(Comp_Code);


                if (HfACODE.Value.ToString() != "0")
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "ACODE=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtPartyName.Text = DtView.Rows[0]["ANAME"].ToString();
                    HfACODE.Value = DtView.Rows[0]["ACODE"].ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlPartModelySrNoOnUpdate(string Id)
        {
            try
            {
                string PartySRNO = HfPartRefSrNo.Value;

                DataTable Dt = new DataTable();
                Dt = PARTY_MODELMASLogicLayer.GetAllIDWisePARTY_MODELMASDetailForJobcard(PartySRNO);


                if (HfPartRefSrNo.Value.ToString() != "0" && HfPartRefSrNo.Value != null)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "SRNO=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtPartyModelSrNo.Text = DtView.Rows[0]["MODEL_SRNO"].ToString();
                    TxtPartySrNo.Text = DtView.Rows[0]["PARTY_SRNO"].ToString();
                    TxtMfgSrNo.Text = DtView.Rows[0]["MFG_SRNO"].ToString();
                    TxtBrandName.Text = DtView.Rows[0]["BRAND_NAME"].ToString();
                    TxtBrandTypeName.Text = DtView.Rows[0]["BRANDTYPE_NAME"].ToString();
                    TxtModelName.Text = DtView.Rows[0]["MODEL_NAME"].ToString();
                    DdlServiceType.SelectedValue = Dt.Rows[0]["SERVICE_TYPE"].ToString();
                    HfBrandTypeCode.Value = Dt.Rows[0]["BRANDTYPE_CODE"].ToString();
                    HfBrandTypeSrNo.Value = Dt.Rows[0]["BRANDTYPE_SRNO"].ToString();

                    if (DdlServiceType.SelectedValue == "W" || DdlServiceType.SelectedValue == "A")
                    {
                        TxtAMCNo.Text = Dt.Rows[0]["AMC_NO"].ToString();
                        TxtAMCFromDate.Text = Convert.ToDateTime(Dt.Rows[0]["AMC_FRDT"].ToString()).ToString("dd-MM-yyyy");
                        TxtAMCToDate.Text = Convert.ToDateTime(Dt.Rows[0]["AMC_TODT"].ToString()).ToString("dd-MM-yyyy");
                    }



                }
                else
                {
                    TxtPartyModelSrNo.Text = string.Empty;
                    TxtPartySrNo.Text = string.Empty;
                    TxtMfgSrNo.Text = string.Empty;
                    TxtBrandName.Text = string.Empty;
                    TxtBrandTypeName.Text = string.Empty;
                    TxtModelName.Text = string.Empty;
                    DdlServiceType.SelectedValue = string.Empty;
                    HfBrandTypeCode.Value = string.Empty;
                    HfBrandTypeSrNo.Value = string.Empty;
                    TxtAMCNo.Text = string.Empty;
                    TxtAMCFromDate.Text = string.Empty;
                    TxtAMCToDate.Text = string.Empty;
                }



            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillJobAssignPersonOnUpdate(string JobAssignPerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfJobAssignPersonName.Value.ToString() != "0" && HfJobAssignPersonName.Value.ToString() != null && HfJobAssignPersonName.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + JobAssignPerson;
                    DataTable DtView = Dv.ToTable();

                    TxtJobAssignPersonName.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfJobAssignPersonName.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtJobAssignPersonName.Text = string.Empty;
                    HfJobAssignPersonName.Value = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillServicePersonOnUpdate1(string ServicePerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfServicePeronBCODE1.Value.ToString() != "0" && HfServicePeronBCODE1.Value.ToString() != null && HfServicePeronBCODE1.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ServicePerson;
                    DataTable DtView = Dv.ToTable();

                    TxtServicePerson1.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfServicePeronBCODE1.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtServicePerson1.Text = string.Empty;
                    HfServicePeronBCODE1.Value = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillServicePersonOnUpdate2(string ServicePerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfServicePeronBCODE2.Value.ToString() != "0" && HfServicePeronBCODE2.Value.ToString() != null && HfServicePeronBCODE2.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ServicePerson;
                    DataTable DtView = Dv.ToTable();

                    TxtServicePerson2.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfServicePeronBCODE2.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtServicePerson2.Text = string.Empty;
                    HfServicePeronBCODE2.Value = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillServicePersonOnUpdate3(string ServicePerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfServicePeronBCODE3.Value.ToString() != "0" && HfServicePeronBCODE3.Value.ToString() != null && HfServicePeronBCODE3.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ServicePerson;
                    DataTable DtView = Dv.ToTable();

                    TxtServicePerson3.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfServicePeronBCODE3.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtServicePerson3.Text = string.Empty;
                    HfServicePeronBCODE3.Value = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillServicePersonOnUpdate4(string ServicePerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfServicePeronBCODE4.Value.ToString() != "0" && HfServicePeronBCODE4.Value.ToString() != null && HfServicePeronBCODE4.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ServicePerson;
                    DataTable DtView = Dv.ToTable();

                    TxtServicePerson4.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfServicePeronBCODE4.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtServicePerson4.Text = string.Empty;
                    HfServicePeronBCODE4.Value = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillServicePersonOnUpdate5(string ServicePerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfServicePeronBCODE5.Value.ToString() != "0" && HfServicePeronBCODE5.Value.ToString() != null && HfServicePeronBCODE5.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ServicePerson;
                    DataTable DtView = Dv.ToTable();

                    TxtServicePerson5.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfServicePeronBCODE5.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtServicePerson5.Text = string.Empty;
                    HfServicePeronBCODE5.Value = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void Btncalldel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE  
                string str = JOBCARD_MASLogicLayer.DeleteJOBCARD_MASDetailsByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value));
                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "Record Deleted Successfully";
                    lblmsg.ForeColor = Color.Green;
                }
                else if (str.Contains("Cannot"))
                {
                    lblmsg.Text = "Cannot Delete This Record It Used by Other Data";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "Error:JOBCARD Master Deleted";
                    lblmsg.ForeColor = Color.Red;
                }
                clear();
                UserRights();
                FillJOBCARDMasterGrid(Convert.ToString(Session["COMP_CODE"]));
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvJobCardMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvJobCardMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataSet ds = JOBCARD_MASLogicLayer.GetAllIDWiseJOBCARD_MASTERDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable dtComplainDetails = ds.Tables[1];
                        DataTable dtServiceDetails = ds.Tables[2];
                        DataTable dtServiceRemaks = ds.Tables[3];
                        DataTable dtServiceUseItem = ds.Tables[4];
                        DataTable dtLabourCharges = ds.Tables[5];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;


                            HfRef_TranDate.Value = dt.Rows[0]["REF_TRAN_DATE"].ToString();
                            HfRef_TranNo.Value = dt.Rows[0]["REF_TRAN_NO"].ToString();
                            HfAMC_TRAN_DATE.Value = dt.Rows[0]["AMC_TRAN_DATE"].ToString();
                            HfAMC_TRAN_NO.Value = dt.Rows[0]["AMC_TRAN_NO"].ToString();
                            HfAMC_SRNO.Value = dt.Rows[0]["AMC_SRNO"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            TxtJobCardNo.Text = dt.Rows[0]["JOBCARD_NO"].ToString();
                            TxtJobCardDate.Text = Convert.ToDateTime(dt.Rows[0]["JOBCARD_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtJobCardTime.Text = dt.Rows[0]["JOBCARD_TIME"].ToString();
                            TxtPONumber.Text = dt.Rows[0]["PO_NO"].ToString();
                            TxtPODate.Text = dt.Rows[0]["PO_DT"].ToString();
                            FillAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            FillContactPersonNameByParty();
                            DdlContactPerson.SelectedValue = dt.Rows[0]["CONTACT_PERSON"].ToString();
                            TxtContactPhone.Text = dt.Rows[0]["CONTACT_PHONE"].ToString();
                            TxtContactEmail.Text = dt.Rows[0]["CONTACT_EMAIL"].ToString();
                            TxtComplainDate.Text = Convert.ToDateTime(dt.Rows[0]["COMPLAIN_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtComplainTime.Text = dt.Rows[0]["COMPLAIN_TIME"].ToString();
                            TxtComplainPerson.Text = dt.Rows[0]["COMPLAIN_PERSON"].ToString();
                            TxtComplainPhone.Text = dt.Rows[0]["COMPLAIN_PHONE"].ToString();
                            TxtCustomerRemark.Text = dt.Rows[0]["CUSTOMER_REMARK"].ToString();
                            HfPartRefSrNo.Value = dt.Rows[0]["PARTY_REFSRNO"].ToString();
                            FillDdlPartModelySrNoOnUpdate(HfPartRefSrNo.Value);
                            HfJobAssignPersonName.Value = dt.Rows[0]["ASSIGN_BCODE"].ToString();
                            FillJobAssignPersonOnUpdate(dt.Rows[0]["ASSIGN_BCODE"].ToString());
                            TxtJobAssignDate.Text = dt.Rows[0]["ASSIGN_DATE"].ToString();
                            TxtJobAssignTime.Text = dt.Rows[0]["ASSIGN_TIME"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtRunningHours.Text = dt.Rows[0]["RUNNING_HRS"].ToString();
                            TxtLoadingHours.Text = dt.Rows[0]["LOADING_HRS"].ToString();
                            TxtJobStartDate.Text = dt.Rows[0]["JOBSTART_DATE"].ToString();
                            TxtJobStartTime.Text = dt.Rows[0]["JOBSTART_TIME"].ToString();
                            TxtJobCloseDate.Text = dt.Rows[0]["JOBCLOSE_DATE"].ToString();
                            TxtJobCloseTime.Text = dt.Rows[0]["JOBCLOSE_TIME"].ToString();
                            HfServicePeronBCODE1.Value = dt.Rows[0]["BCODE1"].ToString();
                            FillServicePersonOnUpdate1(HfServicePeronBCODE1.Value);
                            HfServicePeronBCODE2.Value = dt.Rows[0]["BCODE2"].ToString();
                            FillServicePersonOnUpdate2(HfServicePeronBCODE2.Value);
                            HfServicePeronBCODE3.Value = dt.Rows[0]["BCODE3"].ToString();
                            FillServicePersonOnUpdate3(HfServicePeronBCODE3.Value);
                            HfServicePeronBCODE4.Value = dt.Rows[0]["BCODE4"].ToString();
                            FillServicePersonOnUpdate4(HfServicePeronBCODE4.Value);
                            HfServicePeronBCODE5.Value = dt.Rows[0]["BCODE5"].ToString();
                            FillServicePersonOnUpdate5(HfServicePeronBCODE5.Value);
                            TxtServicePersonProfitPer1.Text = dt.Rows[0]["BCODE1_PER"].ToString();
                            TxtServicePersonProfitPer2.Text = dt.Rows[0]["BCODE2_PER"].ToString();
                            TxtServicePersonProfitPer3.Text = dt.Rows[0]["BCODE3_PER"].ToString();
                            TxtServicePersonProfitPer4.Text = dt.Rows[0]["BCODE4_PER"].ToString();
                            TxtServicePersonProfitPer5.Text = dt.Rows[0]["BCODE5_PER"].ToString();
                            TxtServicePersonProfitAmt1.Text = dt.Rows[0]["BCODE1_AMT"].ToString();
                            TxtServicePersonProfitAmt2.Text = dt.Rows[0]["BCODE2_AMT"].ToString();
                            TxtServicePersonProfitAmt3.Text = dt.Rows[0]["BCODE3_AMT"].ToString();
                            TxtServicePersonProfitAmt4.Text = dt.Rows[0]["BCODE4_AMT"].ToString();
                            TxtServicePersonProfitAmt5.Text = dt.Rows[0]["BCODE5_AMT"].ToString();
                            TotalServicePersonProfitPercentageAndAmountOnUpdate();
                            TxtServiceTaxPer.Text = dt.Rows[0]["EX_DUTY_PER"].ToString();
                            TxtServiceTaxAmt.Text = dt.Rows[0]["EX_DUTY_AMT"].ToString();
                            TxtROamt.Text = dt.Rows[0]["RO_AMT"].ToString();
                            TxtNetAmt.Text = dt.Rows[0]["NET_AMT"].ToString();
                            TxtProfitAmountJobMas.Text = dt.Rows[0]["PROFIT_AMT"].ToString();
                            TxtProfitPercentageJobMas.Text = dt.Rows[0]["PROFIT_PER"].ToString();
                            TxtSignaturePerson.Text = dt.Rows[0]["SIGN_PERSON"].ToString();
                            TxtSignaturePhone.Text = dt.Rows[0]["SIGN_PHONE"].ToString();
                            TxtNextServiceDate.Text = dt.Rows[0]["NEXT_SERVICE_DATE"].ToString();
                            DdlClosed.SelectedValue = dt.Rows[0]["CLOSE_FLAG"].ToString();
                            TxtClosedDate.Text = dt.Rows[0]["CLOSE_DATE"].ToString();
                            TxtClosedBy.Text = dt.Rows[0]["CLOSE_USERID"].ToString();
                            HfAMC_TRAN_DATE.Value = Convert.ToDateTime(dt.Rows[0]["AMC_TRAN_DATE"].ToString()).ToString("dd-MM-yyyy");
                            HfAMC_TRAN_NO.Value = dt.Rows[0]["AMC_TRAN_NO"].ToString();
                            HfAMC_SRNO.Value = dt.Rows[0]["AMC_SRNO"].ToString();
                            TxtInvoiceNo.Text = dt.Rows[0]["INV_NUMBER"].ToString();
                            TxtInvoiceDate.Text = dt.Rows[0]["INV_DATE"].ToString();
                            TxtInvoiceTime.Text = dt.Rows[0]["INV_TIME"].ToString();


                            if (dtComplainDetails.Rows.Count > 0)
                            {
                                GvJobCardComplain.DataSource = dtComplainDetails;
                                GvJobCardComplain.DataBind();
                            }

                            if (dtServiceDetails.Rows.Count > 0)
                            {
                                GvServiceDetail.DataSource = dtServiceDetails;
                                GvServiceDetail.DataBind();
                            }

                            if (dtServiceRemaks.Rows.Count > 0)
                            {
                                GvServiceRemarks.DataSource = dtServiceRemaks;
                                GvServiceRemarks.DataBind();
                            }

                            if (dtServiceUseItem.Rows.Count > 0)
                            {
                                GvServiceUseItem.DataSource = dtServiceUseItem;
                                GvServiceUseItem.DataBind();
                            }

                            if (dtLabourCharges.Rows.Count > 0)
                            {
                                GvLabourChagresDetails.DataSource = dtLabourCharges;
                                GvLabourChagresDetails.DataBind();
                            }

                        }
                        btnSave.Visible = false;
                        btnDelete.Visible = true;
                        Btncalldel.Visible = true;
                        BtncallUpd.Visible = false;
                        BtnViewAssignLog.Enabled = true;
                        ControllerEnable();
                    }

                    #endregion
                }


                if (e.CommandName == "Edita")
                {
                    #region EDIT
                    clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataSet ds = JOBCARD_MASLogicLayer.GetAllIDWiseJOBCARD_MASTERDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable dtComplainDetails = ds.Tables[1];
                        DataTable dtServiceDetails = ds.Tables[2];
                        DataTable dtServiceRemaks = ds.Tables[3];
                        DataTable dtServiceUseItem = ds.Tables[4];
                        DataTable dtLabourCharges = ds.Tables[5];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfRef_TranDate.Value = dt.Rows[0]["REF_TRAN_DATE"].ToString();
                            HfRef_TranNo.Value = dt.Rows[0]["REF_TRAN_NO"].ToString();
                            HfAMC_TRAN_DATE.Value = dt.Rows[0]["AMC_TRAN_DATE"].ToString();
                            HfAMC_TRAN_NO.Value = dt.Rows[0]["AMC_TRAN_NO"].ToString();
                            HfAMC_SRNO.Value = dt.Rows[0]["AMC_SRNO"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            TxtJobCardNo.Text = dt.Rows[0]["JOBCARD_NO"].ToString();
                            TxtJobCardDate.Text = Convert.ToDateTime(dt.Rows[0]["JOBCARD_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtJobCardTime.Text = dt.Rows[0]["JOBCARD_TIME"].ToString();
                            TxtPONumber.Text = dt.Rows[0]["PO_NO"].ToString();
                            TxtPODate.Text = dt.Rows[0]["PO_DT"].ToString();
                            FillAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            FillContactPersonNameByParty();
                            DdlContactPerson.SelectedValue = dt.Rows[0]["CONTACT_PERSON"].ToString();
                            TxtContactPhone.Text = dt.Rows[0]["CONTACT_PHONE"].ToString();
                            TxtContactEmail.Text = dt.Rows[0]["CONTACT_EMAIL"].ToString();
                            TxtComplainDate.Text = Convert.ToDateTime(dt.Rows[0]["COMPLAIN_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtComplainTime.Text = dt.Rows[0]["COMPLAIN_TIME"].ToString();
                            TxtComplainPerson.Text = dt.Rows[0]["COMPLAIN_PERSON"].ToString();
                            TxtComplainPhone.Text = dt.Rows[0]["COMPLAIN_PHONE"].ToString();
                            TxtCustomerRemark.Text = dt.Rows[0]["CUSTOMER_REMARK"].ToString();
                            HfPartRefSrNo.Value = dt.Rows[0]["PARTY_REFSRNO"].ToString();
                            FillDdlPartModelySrNoOnUpdate(HfPartRefSrNo.Value);
                            HfJobAssignPersonName.Value = dt.Rows[0]["ASSIGN_BCODE"].ToString();
                            FillJobAssignPersonOnUpdate(dt.Rows[0]["ASSIGN_BCODE"].ToString());
                            TxtJobAssignDate.Text = dt.Rows[0]["ASSIGN_DATE"].ToString();
                            TxtJobAssignTime.Text = dt.Rows[0]["ASSIGN_TIME"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtRunningHours.Text = dt.Rows[0]["RUNNING_HRS"].ToString();
                            TxtLoadingHours.Text = dt.Rows[0]["LOADING_HRS"].ToString();
                            TxtJobStartDate.Text = dt.Rows[0]["JOBSTART_DATE"].ToString();
                            TxtJobStartTime.Text = dt.Rows[0]["JOBSTART_TIME"].ToString();
                            TxtJobCloseDate.Text = dt.Rows[0]["JOBCLOSE_DATE"].ToString();
                            TxtJobCloseTime.Text = dt.Rows[0]["JOBCLOSE_TIME"].ToString();
                            HfServicePeronBCODE1.Value = dt.Rows[0]["BCODE1"].ToString();
                            FillServicePersonOnUpdate1(HfServicePeronBCODE1.Value);
                            HfServicePeronBCODE2.Value = dt.Rows[0]["BCODE2"].ToString();
                            FillServicePersonOnUpdate2(HfServicePeronBCODE2.Value);
                            HfServicePeronBCODE3.Value = dt.Rows[0]["BCODE3"].ToString();
                            FillServicePersonOnUpdate3(HfServicePeronBCODE3.Value);
                            HfServicePeronBCODE4.Value = dt.Rows[0]["BCODE4"].ToString();
                            FillServicePersonOnUpdate4(HfServicePeronBCODE4.Value);
                            HfServicePeronBCODE5.Value = dt.Rows[0]["BCODE5"].ToString();
                            FillServicePersonOnUpdate5(HfServicePeronBCODE5.Value);
                            TxtServicePersonProfitPer1.Text = dt.Rows[0]["BCODE1_PER"].ToString();
                            TxtServicePersonProfitPer2.Text = dt.Rows[0]["BCODE2_PER"].ToString();
                            TxtServicePersonProfitPer3.Text = dt.Rows[0]["BCODE3_PER"].ToString();
                            TxtServicePersonProfitPer4.Text = dt.Rows[0]["BCODE4_PER"].ToString();
                            TxtServicePersonProfitPer5.Text = dt.Rows[0]["BCODE5_PER"].ToString();
                            TxtServicePersonProfitAmt1.Text = dt.Rows[0]["BCODE1_AMT"].ToString();
                            TxtServicePersonProfitAmt2.Text = dt.Rows[0]["BCODE2_AMT"].ToString();
                            TxtServicePersonProfitAmt3.Text = dt.Rows[0]["BCODE3_AMT"].ToString();
                            TxtServicePersonProfitAmt4.Text = dt.Rows[0]["BCODE4_AMT"].ToString();
                            TxtServicePersonProfitAmt5.Text = dt.Rows[0]["BCODE5_AMT"].ToString();
                            TotalServicePersonProfitPercentageAndAmountOnUpdate();
                            TxtServiceTaxPer.Text = dt.Rows[0]["EX_DUTY_PER"].ToString();
                            TxtServiceTaxAmt.Text = dt.Rows[0]["EX_DUTY_AMT"].ToString();
                            TxtROamt.Text = dt.Rows[0]["RO_AMT"].ToString();
                            TxtNetAmt.Text = dt.Rows[0]["NET_AMT"].ToString();
                            TxtProfitAmountJobMas.Text = dt.Rows[0]["PROFIT_AMT"].ToString();
                            TxtProfitPercentageJobMas.Text = dt.Rows[0]["PROFIT_PER"].ToString();
                            TxtSignaturePerson.Text = dt.Rows[0]["SIGN_PERSON"].ToString();
                            TxtSignaturePhone.Text = dt.Rows[0]["SIGN_PHONE"].ToString();
                            TxtNextServiceDate.Text = dt.Rows[0]["NEXT_SERVICE_DATE"].ToString();
                            DdlClosed.SelectedValue = dt.Rows[0]["CLOSE_FLAG"].ToString();
                            TxtClosedDate.Text = dt.Rows[0]["CLOSE_DATE"].ToString();
                            TxtClosedBy.Text = dt.Rows[0]["CLOSE_USERID"].ToString();
                            HfAMC_TRAN_DATE.Value = Convert.ToDateTime(dt.Rows[0]["AMC_TRAN_DATE"].ToString()).ToString("dd-MM-yyyy");
                            HfAMC_TRAN_NO.Value = dt.Rows[0]["AMC_TRAN_NO"].ToString();
                            HfAMC_SRNO.Value = dt.Rows[0]["AMC_SRNO"].ToString();
                            TxtInvoiceNo.Text = dt.Rows[0]["INV_NUMBER"].ToString();
                            TxtInvoiceDate.Text = dt.Rows[0]["INV_DATE"].ToString();
                            TxtInvoiceTime.Text = dt.Rows[0]["INV_TIME"].ToString();

                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            //Session["TRAN_TYPE"] = HfTranType.Value;
                            //Session["TRN_TYPE"] = HfTrnType.Value;

                            if (dtComplainDetails.Rows.Count > 0)
                            {
                                #region Assign To JobCard Detail Table

                                DataTable table = new DataTable();
                                DataRow drm = null;
                                if (ViewState["TableJobCardComplain"] != null)
                                {
                                    table = (DataTable)ViewState["TableJobCardComplain"];
                                }
                                else
                                {
                                    if (table.Rows.Count <= 0)
                                    {
                                        table.Columns.Add("COMP_CODE", typeof(string));
                                        table.Columns.Add("TRAN_DATE", typeof(string));
                                        table.Columns.Add("TRAN_NO", typeof(string));
                                        table.Columns.Add("SRNO", typeof(string));
                                        table.Columns.Add("COMPLAIN_DESC", typeof(string));
                                        table.Columns.Add("REMARK", typeof(string));
                                        table.Columns.Add("INS_USERID", typeof(string));
                                        table.Columns.Add("INS_DATE", typeof(string));
                                        table.Columns.Add("UPD_USERID", typeof(string));
                                        table.Columns.Add("UPD_DATE", typeof(string));
                                        table.Columns.Add("COMPLAIN_CODE", typeof(string));
                                        table.Columns.Add("COMPLAIN_CHECK", typeof(string));
                                    }
                                }

                                for (int m = 0; m < dtComplainDetails.Rows.Count; m++)
                                {
                                    drm = table.NewRow();

                                    drm["COMP_CODE"] = dtComplainDetails.Rows[m]["COMP_CODE"].ToString();
                                    drm["TRAN_DATE"] = dtComplainDetails.Rows[m]["TRAN_DATE"].ToString();
                                    drm["TRAN_NO"] = dtComplainDetails.Rows[m]["TRAN_NO"].ToString();
                                    drm["SRNO"] = dtComplainDetails.Rows[m]["SRNO"].ToString();
                                    drm["COMPLAIN_CODE"] = dtComplainDetails.Rows[m]["COMPLAIN_CODE"].ToString();
                                    drm["COMPLAIN_DESC"] = dtComplainDetails.Rows[m]["COMPLAIN_DESC"].ToString();


                                    table.Rows.Add(drm);
                                }

                                #endregion

                                ViewState["TableJobCardComplain"] = dtComplainDetails;
                                GvJobCardComplain.DataSource = dtComplainDetails;
                                GvJobCardComplain.DataBind();

                            }



                            if (dtServiceDetails.Rows.Count > 0)
                            {
                                #region Assign to Jobcard Service Details Table

                                DataTable table = new DataTable();
                                DataRow drm = null;

                                if (ViewState["TableServiceDetails"] != null)
                                {
                                    table = (DataTable)ViewState["TableServiceDetails"];
                                }
                                else
                                {
                                    if (table.Rows.Count <= 0)
                                    {

                                        table.Columns.Add("COMP_CODE", typeof(string));
                                        table.Columns.Add("TRAN_DATE", typeof(string));
                                        table.Columns.Add("TRAN_NO", typeof(string));
                                        table.Columns.Add("SRNO", typeof(string));
                                        table.Columns.Add("BRANDTYPE_CODE", typeof(string));
                                        table.Columns.Add("BRANDTYPE_SRNO", typeof(string));
                                        table.Columns.Add("RESULT_FLAG_1_1", typeof(string));
                                        table.Columns.Add("RESULT_FLAG_2_1", typeof(string));
                                        table.Columns.Add("RESULT_FLAG_3_1", typeof(string));
                                        table.Columns.Add("REMARK", typeof(string));
                                        table.Columns.Add("INS_USERID", typeof(string));
                                        table.Columns.Add("INS_DATE", typeof(string));
                                        table.Columns.Add("UPD_USERID", typeof(string));
                                        table.Columns.Add("UPD_DATE", typeof(string));
                                        table.Columns.Add("RESULT_FLAG_1_2", typeof(string));
                                        table.Columns.Add("RESULT_FLAG_2_2", typeof(string));
                                        table.Columns.Add("RESULT_FLAG_3_2", typeof(string));

                                        table.Columns.Add("DESC_NAME", typeof(string));
                                        table.Columns.Add("RESULT_1_1", typeof(string));
                                        table.Columns.Add("RESULT_1_2", typeof(string));
                                        table.Columns.Add("RESULT_2_1", typeof(string));
                                        table.Columns.Add("RESULT_2_2", typeof(string));
                                        table.Columns.Add("RESULT_3_1", typeof(string));
                                        table.Columns.Add("RESULT_3_2", typeof(string));
                                        table.Columns.Add("PRINT_FLAG_1", typeof(string));
                                        table.Columns.Add("PRINT_FLAG_2", typeof(string));
                                        table.Columns.Add("PRINT_FLAG_3", typeof(string));




                                    }
                                }

                                for (int m = 0; m < dtServiceDetails.Rows.Count; m++)
                                {
                                    drm = table.NewRow();

                                    drm["COMP_CODE"] = dtServiceDetails.Rows[m]["COMP_CODE"].ToString();
                                    drm["TRAN_DATE"] = dtServiceDetails.Rows[m]["TRAN_DATE"].ToString();
                                    drm["TRAN_NO"] = dtServiceDetails.Rows[m]["TRAN_NO"].ToString();
                                    drm["SRNO"] = dtServiceDetails.Rows[m]["SRNO"].ToString();
                                    drm["BRANDTYPE_CODE"] = dtServiceDetails.Rows[m]["BRANDTYPE_CODE"].ToString();
                                    drm["BRANDTYPE_SRNO"] = dtServiceDetails.Rows[m]["BRANDTYPE_SRNO"].ToString();
                                    drm["RESULT_FLAG_1_1"] = dtServiceDetails.Rows[m]["RESULT_FLAG_1_1"].ToString();
                                    drm["RESULT_FLAG_2_1"] = dtServiceDetails.Rows[m]["RESULT_FLAG_2_1"].ToString();
                                    drm["RESULT_FLAG_3_1"] = dtServiceDetails.Rows[m]["RESULT_FLAG_3_1"].ToString();
                                    drm["RESULT_FLAG_1_2"] = dtServiceDetails.Rows[m]["RESULT_FLAG_1_2"].ToString();
                                    drm["RESULT_FLAG_2_2"] = dtServiceDetails.Rows[m]["RESULT_FLAG_2_2"].ToString();
                                    drm["RESULT_FLAG_3_2"] = dtServiceDetails.Rows[m]["RESULT_FLAG_3_2"].ToString();

                                    table.Rows.Add(drm);
                                }

                                #endregion

                                ViewState["TableServiceDetails"] = dtServiceDetails;
                                GvServiceDetail.DataSource = dtServiceDetails;
                                GvServiceDetail.DataBind();
                            }

                            if (dtServiceRemaks.Rows.Count > 0)
                            {
                                #region Assign to Jobcard Service Remarks Table

                                DataTable table = new DataTable();
                                DataRow drm = null;

                                if (ViewState["TableServiceRemarks"] != null)
                                {
                                    table = (DataTable)ViewState["TableServiceRemarks"];
                                }
                                else
                                {
                                    if (table.Rows.Count <= 0)
                                    {

                                        table.Columns.Add("COMP_CODE", typeof(string));
                                        table.Columns.Add("TRAN_DATE", typeof(string));
                                        table.Columns.Add("TRAN_NO", typeof(string));
                                        table.Columns.Add("SRNO", typeof(string));
                                        table.Columns.Add("REMARK", typeof(string));
                                        table.Columns.Add("INS_USERID", typeof(string));
                                        table.Columns.Add("INS_DATE", typeof(string));
                                        table.Columns.Add("UPD_USERID", typeof(string));
                                        table.Columns.Add("UPD_DATE", typeof(string));



                                    }
                                }

                                for (int m = 0; m < dtServiceRemaks.Rows.Count; m++)
                                {
                                    drm = table.NewRow();


                                    drm["COMP_CODE"] = dtServiceRemaks.Rows[m]["COMP_CODE"].ToString();
                                    drm["TRAN_DATE"] = dtServiceRemaks.Rows[m]["TRAN_DATE"].ToString();
                                    drm["TRAN_NO"] = dtServiceRemaks.Rows[m]["TRAN_NO"].ToString();
                                    drm["SRNO"] = dtServiceRemaks.Rows[m]["SRNO"].ToString();
                                    drm["REMARK"] = dtServiceRemaks.Rows[m]["REMARK"].ToString();
                                    drm["INS_USERID"] = dtServiceRemaks.Rows[m]["INS_USERID"].ToString();
                                    drm["INS_DATE"] = dtServiceRemaks.Rows[m]["INS_DATE"].ToString();
                                    drm["UPD_USERID"] = dtServiceRemaks.Rows[m]["UPD_USERID"].ToString();
                                    drm["UPD_DATE"] = dtServiceRemaks.Rows[m]["UPD_DATE"].ToString();

                                    table.Rows.Add(drm);
                                }

                                #endregion

                                ViewState["TableServiceRemarks"] = dtServiceRemaks;
                                GvServiceRemarks.DataSource = dtServiceRemaks;
                                GvServiceRemarks.DataBind();
                            }

                            if (dtServiceUseItem.Rows.Count > 0)
                            {
                                #region Assign to Jobcard Service Use Item Grid Table

                                DataTable table = new DataTable();
                                DataRow drm = null;

                                if (ViewState["TableServiceUseItem"] != null)
                                {
                                    table = (DataTable)ViewState["TableServiceUseItem"];
                                }
                                else
                                {
                                    if (table.Rows.Count <= 0)
                                    {
                                        table.Columns.Add("COMP_CODE", typeof(string));
                                        table.Columns.Add("TRAN_DATE", typeof(string));
                                        table.Columns.Add("TRAN_NO", typeof(string));
                                        table.Columns.Add("SRNO", typeof(string));
                                        table.Columns.Add("SCODE", typeof(string));
                                        table.Columns.Add("REF_TRAN_DATE", typeof(string));
                                        table.Columns.Add("REF_TRAN_NO", typeof(string));
                                        table.Columns.Add("REF_SRNO", typeof(string));
                                        table.Columns.Add("QTY", typeof(string));

                                        table.Columns.Add("sname", typeof(string));
                                        table.Columns.Add("prod_code", typeof(string));
                                        table.Columns.Add("cha_dt", typeof(string));
                                        table.Columns.Add("cha_no", typeof(string));
                                        table.Columns.Add("qty", typeof(string));
                                        table.Columns.Add("ret_qty", typeof(string));
                                        table.Columns.Add("use_qty", typeof(string));
                                        table.Columns.Add("bal_qty", typeof(string));

                                    }
                                }

                                for (int m = 0; m < dtServiceUseItem.Rows.Count; m++)
                                {
                                    drm = table.NewRow();

                                    drm["COMP_CODE"] = dtServiceUseItem.Rows[m]["COMP_CODE"].ToString();
                                    drm["TRAN_DATE"] = dtServiceUseItem.Rows[m]["TRAN_DATE"].ToString();
                                    drm["TRAN_NO"] = dtServiceUseItem.Rows[m]["TRAN_NO"].ToString();
                                    drm["SRNO"] = dtServiceUseItem.Rows[m]["SRNO"].ToString();
                                    drm["SCODE"] = dtServiceUseItem.Rows[m]["SCODE"].ToString();
                                    drm["REF_TRAN_DATE"] = dtServiceUseItem.Rows[m]["REF_TRAN_DATE"].ToString();
                                    drm["REF_TRAN_NO"] = dtServiceUseItem.Rows[m]["REF_TRAN_NO"].ToString();
                                    drm["REF_SRNO"] = dtServiceUseItem.Rows[m]["REF_SRNO"].ToString();
                                    drm["QTY"] = dtServiceUseItem.Rows[m]["QTY"].ToString();

                                    table.Rows.Add(drm);

                                }

                                #endregion

                                ViewState["TableServiceUseItem"] = table;
                                GvServiceUseItem.DataSource = dtServiceUseItem;
                                GvServiceUseItem.DataBind();
                            }

                            if (dtLabourCharges.Rows.Count > 0)
                            {

                                #region Assign to Labour Charges Into table

                                DataTable table = new DataTable();
                                DataRow drm = null;

                                if (ViewState["TableLabourCharges"] != null)
                                {
                                    table = (DataTable)ViewState["TableLabourCharges"];
                                }
                                else
                                {
                                    if (table.Rows.Count <= 0)
                                    {

                                        table.Columns.Add("COMP_CODE", typeof(string));
                                        table.Columns.Add("TRAN_DATE", typeof(string));
                                        table.Columns.Add("TRAN_NO", typeof(string));
                                        table.Columns.Add("SRNO", typeof(string));
                                        table.Columns.Add("CCODE", typeof(string));
                                        table.Columns.Add("QTY", typeof(string));
                                        table.Columns.Add("RATE", typeof(string));
                                        table.Columns.Add("AMT", typeof(string));
                                        table.Columns.Add("LAB_DESC", typeof(string));
                                        table.Columns.Add("REMARK", typeof(string));
                                        table.Columns.Add("INS_USERID", typeof(string));
                                        table.Columns.Add("INS_DATE", typeof(string));
                                        table.Columns.Add("UPD_USERID", typeof(string));
                                        table.Columns.Add("UPD_DATE", typeof(string));
                                        //table.Columns.Add("GST_RATE", typeof(string));
                                        //table.Columns.Add("GST_AMT", typeof(string));
                                        //table.Columns.Add("CGST_RATE", typeof(string));
                                        //table.Columns.Add("CGST_AMT", typeof(string));
                                        //table.Columns.Add("SGST_RATE", typeof(string));
                                        //table.Columns.Add("SGST_AMT", typeof(string));
                                        //table.Columns.Add("IGST_RATE", typeof(string));
                                        //table.Columns.Add("IGST_AMT", typeof(string));
                                        //table.Columns.Add("T_AMT", typeof(string));

                                    }
                                }

                                for (int m = 0; m < dtLabourCharges.Rows.Count; m++)
                                {
                                    drm = table.NewRow();

                                    drm["COMP_CODE"] = dtLabourCharges.Rows[m]["COMP_CODE"].ToString();
                                    drm["TRAN_DATE"] = dtLabourCharges.Rows[m]["TRAN_DATE"].ToString();
                                    drm["TRAN_NO"] = dtLabourCharges.Rows[m]["TRAN_NO"].ToString();
                                    drm["SRNO"] = dtLabourCharges.Rows[m]["SRNO"].ToString();
                                    drm["CCODE"] = dtLabourCharges.Rows[m]["CCODE"].ToString();
                                    drm["QTY"] = dtLabourCharges.Rows[m]["QTY"].ToString();
                                    drm["RATE"] = dtLabourCharges.Rows[m]["RATE"].ToString();
                                    drm["AMT"] = dtLabourCharges.Rows[m]["AMT"].ToString();
                                    drm["LAB_DESC"] = dtLabourCharges.Rows[m]["LAB_DESC"].ToString();
                                    drm["REMARK"] = dtLabourCharges.Rows[m]["REMARK"].ToString();
                                    drm["INS_USERID"] = dtLabourCharges.Rows[m]["INS_USERID"].ToString();
                                    drm["INS_DATE"] = dtLabourCharges.Rows[m]["INS_DATE"].ToString();
                                    drm["UPD_USERID"] = dtLabourCharges.Rows[m]["UPD_USERID"].ToString();
                                    drm["UPD_DATE"] = dtLabourCharges.Rows[m]["UPD_DATE"].ToString();
                                    //dr["GST_RATE"] = string.Empty;
                                    //dr["GST_AMT"] = string.Empty;
                                    //dr["CGST_RATE"] = string.Empty;
                                    //dr["CGST_AMT"] = string.Empty;
                                    //dr["SGST_RATE"] = string.Empty;
                                    //dr["SGST_AMT"] = string.Empty;
                                    //dr["IGST_RATE"] = string.Empty;
                                    //dr["IGST_AMT"] = string.Empty;
                                    //dr["T_AMT"] = string.Empty;


                                    table.Rows.Add(drm);
                                }

                                #endregion

                                ViewState["TableLabourCharges"] = dtLabourCharges;
                                GvLabourChagresDetails.DataSource = dtLabourCharges;
                                GvLabourChagresDetails.DataBind();
                            }



                            BtncallUpd.Text = "UPDATE";

                            #endregion

                        }
                    }

                    #region CHECK UPDATE RIGHTS
                    if (Session["UPDATE"] != null)
                    {
                        if (Session["UPDATE"].ToString() == "Y")
                        {
                            ControllerEnable();
                        }
                        else
                        {
                            ControllerDisabe();
                        }
                    }
                    #endregion
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = true;
                    btnSave.Visible = true;
                    BtnViewAssignLog.Enabled = true;
                    UserRights();
                }


                if (e.CommandName == "Viewa")
                {
                    #region VIEW ON TEXTBOX
                    clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataSet ds = JOBCARD_MASLogicLayer.GetAllIDWiseJOBCARD_MASTERDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable dtComplainDetails = ds.Tables[1];
                        DataTable dtServiceDetails = ds.Tables[2];
                        DataTable dtServiceRemaks = ds.Tables[3];
                        DataTable dtServiceUseItem = ds.Tables[4];
                        DataTable dtLabourCharges = ds.Tables[5];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfAMC_TRAN_DATE.Value = dt.Rows[0]["AMC_TRAN_DATE"].ToString();
                            HfAMC_TRAN_NO.Value = dt.Rows[0]["AMC_TRAN_NO"].ToString();
                            HfAMC_SRNO.Value = dt.Rows[0]["AMC_SRNO"].ToString();
                            HfRef_TranDate.Value = dt.Rows[0]["REF_TRAN_DATE"].ToString();
                            HfRef_TranNo.Value = dt.Rows[0]["REF_TRAN_NO"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            TxtJobCardNo.Text = dt.Rows[0]["JOBCARD_NO"].ToString();
                            TxtJobCardDate.Text = Convert.ToDateTime(dt.Rows[0]["JOBCARD_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtJobCardTime.Text = dt.Rows[0]["JOBCARD_TIME"].ToString();
                            TxtPONumber.Text = dt.Rows[0]["PO_NO"].ToString();
                            TxtPODate.Text = dt.Rows[0]["PO_DT"].ToString();
                            FillAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            FillContactPersonNameByParty();
                            DdlContactPerson.SelectedValue = dt.Rows[0]["CONTACT_PERSON"].ToString();
                            TxtContactPhone.Text = dt.Rows[0]["CONTACT_PHONE"].ToString();
                            TxtContactEmail.Text = dt.Rows[0]["CONTACT_EMAIL"].ToString();
                            TxtComplainDate.Text = Convert.ToDateTime(dt.Rows[0]["COMPLAIN_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtComplainTime.Text = dt.Rows[0]["COMPLAIN_TIME"].ToString();
                            TxtComplainPerson.Text = dt.Rows[0]["COMPLAIN_PERSON"].ToString();
                            TxtComplainPhone.Text = dt.Rows[0]["COMPLAIN_PHONE"].ToString();
                            TxtCustomerRemark.Text = dt.Rows[0]["CUSTOMER_REMARK"].ToString();
                            HfPartRefSrNo.Value = dt.Rows[0]["PARTY_REFSRNO"].ToString();
                            FillDdlPartModelySrNoOnUpdate(HfPartRefSrNo.Value);
                            HfJobAssignPersonName.Value = dt.Rows[0]["ASSIGN_BCODE"].ToString();
                            FillJobAssignPersonOnUpdate(dt.Rows[0]["ASSIGN_BCODE"].ToString());
                            TxtJobAssignDate.Text = dt.Rows[0]["ASSIGN_DATE"].ToString();
                            TxtJobAssignTime.Text = dt.Rows[0]["ASSIGN_TIME"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtRunningHours.Text = dt.Rows[0]["RUNNING_HRS"].ToString();
                            TxtLoadingHours.Text = dt.Rows[0]["LOADING_HRS"].ToString();
                            TxtJobStartDate.Text = dt.Rows[0]["JOBSTART_DATE"].ToString();
                            TxtJobStartTime.Text = dt.Rows[0]["JOBSTART_TIME"].ToString();
                            TxtJobCloseDate.Text = dt.Rows[0]["JOBCLOSE_DATE"].ToString();
                            TxtJobCloseTime.Text = dt.Rows[0]["JOBCLOSE_TIME"].ToString();
                            HfServicePeronBCODE1.Value = dt.Rows[0]["BCODE1"].ToString();
                            FillServicePersonOnUpdate1(HfServicePeronBCODE1.Value);
                            HfServicePeronBCODE2.Value = dt.Rows[0]["BCODE2"].ToString();
                            FillServicePersonOnUpdate2(HfServicePeronBCODE2.Value);
                            HfServicePeronBCODE3.Value = dt.Rows[0]["BCODE3"].ToString();
                            FillServicePersonOnUpdate3(HfServicePeronBCODE3.Value);
                            HfServicePeronBCODE4.Value = dt.Rows[0]["BCODE4"].ToString();
                            FillServicePersonOnUpdate4(HfServicePeronBCODE4.Value);
                            HfServicePeronBCODE5.Value = dt.Rows[0]["BCODE5"].ToString();
                            FillServicePersonOnUpdate5(HfServicePeronBCODE5.Value);
                            TxtServicePersonProfitPer1.Text = dt.Rows[0]["BCODE1_PER"].ToString();
                            TxtServicePersonProfitPer2.Text = dt.Rows[0]["BCODE2_PER"].ToString();
                            TxtServicePersonProfitPer3.Text = dt.Rows[0]["BCODE3_PER"].ToString();
                            TxtServicePersonProfitPer4.Text = dt.Rows[0]["BCODE4_PER"].ToString();
                            TxtServicePersonProfitPer5.Text = dt.Rows[0]["BCODE5_PER"].ToString();
                            TxtServicePersonProfitAmt1.Text = dt.Rows[0]["BCODE1_AMT"].ToString();
                            TxtServicePersonProfitAmt2.Text = dt.Rows[0]["BCODE2_AMT"].ToString();
                            TxtServicePersonProfitAmt3.Text = dt.Rows[0]["BCODE3_AMT"].ToString();
                            TxtServicePersonProfitAmt4.Text = dt.Rows[0]["BCODE4_AMT"].ToString();
                            TxtServicePersonProfitAmt5.Text = dt.Rows[0]["BCODE5_AMT"].ToString();
                            TotalServicePersonProfitPercentageAndAmountOnUpdate();
                            TxtServiceTaxPer.Text = dt.Rows[0]["EX_DUTY_PER"].ToString();
                            TxtServiceTaxAmt.Text = dt.Rows[0]["EX_DUTY_AMT"].ToString();
                            TxtROamt.Text = dt.Rows[0]["RO_AMT"].ToString();
                            TxtNetAmt.Text = dt.Rows[0]["NET_AMT"].ToString();
                            TxtProfitAmountJobMas.Text = dt.Rows[0]["PROFIT_AMT"].ToString();
                            TxtProfitPercentageJobMas.Text = dt.Rows[0]["PROFIT_PER"].ToString();
                            TxtSignaturePerson.Text = dt.Rows[0]["SIGN_PERSON"].ToString();
                            TxtSignaturePhone.Text = dt.Rows[0]["SIGN_PHONE"].ToString();
                            TxtNextServiceDate.Text = dt.Rows[0]["NEXT_SERVICE_DATE"].ToString();
                            DdlClosed.SelectedValue = dt.Rows[0]["CLOSE_FLAG"].ToString();
                            TxtClosedDate.Text = dt.Rows[0]["CLOSE_DATE"].ToString();
                            TxtClosedBy.Text = dt.Rows[0]["CLOSE_USERID"].ToString();
                            HfAMC_TRAN_DATE.Value = Convert.ToDateTime(dt.Rows[0]["AMC_TRAN_DATE"].ToString()).ToString("dd-MM-yyyy");
                            HfAMC_TRAN_NO.Value = dt.Rows[0]["AMC_TRAN_NO"].ToString();
                            HfAMC_SRNO.Value = dt.Rows[0]["AMC_SRNO"].ToString();
                            TxtInvoiceNo.Text = dt.Rows[0]["INV_NUMBER"].ToString();
                            TxtInvoiceDate.Text = dt.Rows[0]["INV_DATE"].ToString();
                            TxtInvoiceTime.Text = dt.Rows[0]["INV_TIME"].ToString();

                            if (dtComplainDetails.Rows.Count > 0)
                            {
                                GvJobCardComplain.DataSource = dtComplainDetails;
                                GvJobCardComplain.DataBind();
                            }

                            if (dtServiceDetails.Rows.Count > 0)
                            {
                                GvServiceDetail.DataSource = dtServiceDetails;
                                GvServiceDetail.DataBind();
                            }

                            if (dtServiceRemaks.Rows.Count > 0)
                            {
                                GvServiceRemarks.DataSource = dtServiceRemaks;
                                GvServiceRemarks.DataBind();
                            }

                            if (dtServiceUseItem.Rows.Count > 0)
                            {
                                GvServiceUseItem.DataSource = dtServiceUseItem;
                                GvServiceUseItem.DataBind();
                            }

                            if (dtLabourCharges.Rows.Count > 0)
                            {
                                GvLabourChagresDetails.DataSource = dtLabourCharges;
                                GvLabourChagresDetails.DataBind();
                            }

                        }
                    }

                    #endregion
                    ControllerDisabe();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    UserRights();
                    BtnViewAssignLog.Enabled = true;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region UPDATE JOBCARD MASTER DETAILS

                #region INSERT DATA INTO JOBCARD MASTER 

                JOBCARD_MASLogicLayer insert = new JOBCARD_MASLogicLayer();

                insert.COMP_CODE = Session["COMP_CODE"].ToString();
                insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.JOBCARD_NO = TxtJobCardNo.Text.Trim();
                insert.JOBCARD_DATE = Convert.ToDateTime(TxtJobCardDate.Text.Trim()).ToString("MM-dd-yyyy");
                insert.JOBCARD_TIME = TxtJobCardTime.Text.Trim();
                insert.ACODE = HfACODE.Value.Trim();
                insert.CONTACT_PERSON = DdlContactPerson.SelectedValue.Trim().ToUpper();
                insert.CONTACT_PHONE = TxtContactPhone.Text.Trim();
                insert.CONTACT_EMAIL = TxtContactEmail.Text.Trim();
                insert.COMPLAIN_DATE = Convert.ToDateTime(TxtComplainDate.Text.Trim()).ToString("MM-dd-yyyy");
                insert.COMPLAIN_TIME = TxtComplainTime.Text.Trim();
                insert.COMPLAIN_PERSON = TxtComplainPerson.Text.Trim().ToUpper();
                insert.COMPLAIN_PHONE = TxtComplainPhone.Text.Trim().ToUpper();
                insert.PARTY_REFSRNO = HfPartRefSrNo.Value.Trim();
                if (TxtRunningHours.Text == string.Empty)
                {
                    insert.RUNNING_HRS = null;
                }
                else
                {
                    insert.RUNNING_HRS = TxtRunningHours.Text.Trim();
                }
                if (TxtLoadingHours.Text == string.Empty)
                {
                    insert.LOADING_HRS = null;
                }
                else
                {
                    insert.LOADING_HRS = TxtLoadingHours.Text.Trim();
                }

                if (TxtJobStartDate.Text == string.Empty)
                {
                    insert.JOBSTART_DATE = "";
                }
                else
                {
                    insert.JOBSTART_DATE = Convert.ToDateTime(TxtJobStartDate.Text.Trim()).ToString("MM-dd-yyyy");
                }

                if (TxtJobCloseDate.Text == string.Empty)
                {
                    insert.JOBCLOSE_DATE = "";
                }
                else
                {
                    insert.JOBCLOSE_DATE = Convert.ToDateTime(TxtJobCloseDate.Text.Trim()).ToString("MM-dd-yyyy");
                }

                if (TxtJobStartTime.Text == string.Empty)
                {
                    insert.JOBSTART_TIME = "";
                }
                else
                {
                    insert.JOBSTART_TIME = TxtJobStartTime.Text.Trim();
                }

                if (TxtJobCloseTime.Text == string.Empty)
                {
                    insert.JOBCLOSE_TIME = "";
                }
                else
                {
                    insert.JOBCLOSE_TIME = TxtJobCloseTime.Text.Trim();
                }

                if (TxtServicePerson1.Text == string.Empty)
                {
                    insert.BCODE1 = null;
                }
                else
                {
                    insert.BCODE1 = HfServicePeronBCODE1.Value.Trim();
                }

                if (TxtServicePerson2.Text == string.Empty)
                {
                    insert.BCODE2 = null;
                }
                else
                {
                    insert.BCODE2 = HfServicePeronBCODE2.Value.Trim();
                }

                if (TxtServicePerson3.Text == string.Empty)
                {
                    insert.BCODE3 = null;
                }
                else
                {
                    insert.BCODE3 = HfServicePeronBCODE3.Value.Trim();
                }

                if (TxtServicePerson4.Text == string.Empty)
                {
                    insert.BCODE4 = null;
                }
                else
                {
                    insert.BCODE4 = HfServicePeronBCODE4.Value.Trim();
                }

                if (TxtServicePerson5.Text == string.Empty)
                {
                    insert.BCODE5 = null;
                }
                else
                {
                    insert.BCODE5 = HfServicePeronBCODE5.Value.Trim();
                }

                if (TxtServicePersonProfitPer1.Text == string.Empty)
                {
                    insert.BCODE1_PER = null;
                }
                else
                {
                    insert.BCODE1_PER = TxtServicePersonProfitPer1.Text.Trim();
                }

                if (TxtServicePersonProfitPer2.Text == string.Empty)
                {
                    insert.BCODE2_PER = null;
                }
                else
                {
                    insert.BCODE2_PER = TxtServicePersonProfitPer2.Text.Trim();
                }

                if (TxtServicePersonProfitPer3.Text == string.Empty)
                {
                    insert.BCODE3_PER = null;
                }
                else
                {
                    insert.BCODE3_PER = TxtServicePersonProfitPer3.Text.Trim();
                }

                if (TxtServicePersonProfitPer4.Text == string.Empty)
                {
                    insert.BCODE4_PER = null;
                }
                else
                {
                    insert.BCODE4_PER = TxtServicePersonProfitPer4.Text.Trim();
                }

                if (TxtServicePersonProfitPer5.Text == string.Empty)
                {
                    insert.BCODE5_PER = null;
                }
                else
                {
                    insert.BCODE5_PER = TxtServicePersonProfitPer5.Text.Trim();
                }

                if (TxtServicePersonProfitAmt1.Text == string.Empty)
                {
                    insert.BCODE1_AMT = null;
                }
                else
                {
                    insert.BCODE1_AMT = TxtServicePersonProfitAmt1.Text.Trim();
                }

                if (TxtServicePersonProfitAmt2.Text == string.Empty)
                {
                    insert.BCODE2_AMT = null;
                }
                else
                {
                    insert.BCODE2_AMT = TxtServicePersonProfitAmt2.Text.Trim();
                }

                if (TxtServicePersonProfitAmt3.Text == string.Empty)
                {
                    insert.BCODE3_AMT = null;
                }
                else
                {
                    insert.BCODE3_AMT = TxtServicePersonProfitAmt3.Text.Trim();
                }

                if (TxtServicePersonProfitAmt4.Text == string.Empty)
                {
                    insert.BCODE4_AMT = null;
                }
                else
                {
                    insert.BCODE4_AMT = TxtServicePersonProfitAmt4.Text.Trim();
                }

                if (TxtServicePersonProfitAmt5.Text == string.Empty)
                {
                    insert.BCODE5_AMT = null;
                }
                else
                {
                    insert.BCODE5_AMT = TxtServicePersonProfitAmt5.Text.Trim();
                }

                insert.REF_TRAN_DATE = null;
                insert.REF_TRAN_NO = null;
                insert.GROSS_AMT = null;
                if (TxtServiceTaxPer.Text == string.Empty)
                {
                    insert.EX_DUTY_PER = null;
                }
                else
                {
                    insert.EX_DUTY_PER = TxtServiceTaxPer.Text.Trim();
                }

                if (TxtServiceTaxAmt.Text == string.Empty)
                {
                    insert.EX_DUTY_AMT = null;
                }
                else
                {
                    insert.EX_DUTY_AMT = TxtServiceTaxAmt.Text.Trim();
                }

                insert.EX_CESS_PER = null;
                insert.EX_CESS_AMT = null;
                insert.EX_SHCESS_PER = null;
                insert.EX_SHCESS_AMT = null;

                if (TxtROamt.Text == string.Empty)
                {
                    insert.RO_AMT = null;
                }
                else
                {
                    insert.RO_AMT = TxtROamt.Text.Trim();
                }

                if (TxtNetAmt.Text == string.Empty)
                {
                    insert.NET_AMT = null;
                }
                else
                {
                    insert.NET_AMT = TxtNetAmt.Text.Trim();
                }


                if (TxtProfitPercentageJobMas.Text == string.Empty)
                {
                    insert.PROFIT_PER = null;
                }
                else
                {
                    insert.PROFIT_PER = TxtProfitPercentageJobMas.Text.Trim();
                }

                if (TxtProfitAmountJobMas.Text == string.Empty)
                {

                    insert.PROFIT_AMT = null;
                }
                else
                {
                    insert.PROFIT_AMT = TxtProfitAmountJobMas.Text.Trim();
                }
                insert.REMARK = TxtRemark.Text.Trim();
                //insert.INS_USERID = Session["USERNAME"].ToString();
                //insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_DATE = "";
                insert.CLOSE_FLAG = DdlClosed.SelectedValue.Trim().ToUpper();
                if (DdlClosed.SelectedValue.ToString() == "Y")
                {
                    insert.CLOSE_DATE = Convert.ToDateTime(TxtClosedDate.Text.Trim()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.CLOSE_DATE = "";
                }

                if (DdlClosed.SelectedValue.ToString() == "Y")
                {
                    insert.CLOSE_USERID = TxtClosedBy.Text.Trim().ToUpper();
                }
                else
                {
                    insert.CLOSE_USERID = "";
                }

                insert.CHK_FLAG = null;
                insert.CHK_DATE = null;
                insert.CHK_USERID = null;

                if (TxtJobAssignPersonName.Text == string.Empty)
                {
                    insert.ASSIGN_BCODE = null;
                }
                else
                {
                    insert.ASSIGN_BCODE = HfJobAssignPersonName.Value.Trim();
                }

                if (TxtJobAssignDate.Text == string.Empty)
                {
                    insert.ASSIGN_DATE = "";
                }
                else
                {
                    insert.ASSIGN_DATE = Convert.ToDateTime(TxtJobAssignDate.Text.Trim()).ToString("MM-dd-yyyy");
                }

                if (TxtJobAssignTime.Text == string.Empty)
                {
                    insert.ASSIGN_TIME = "";
                }
                else
                {
                    insert.ASSIGN_TIME = TxtJobAssignTime.Text.Trim();
                }

                insert.INV_NUMBER = null;
                insert.INV_DATE = null;
                insert.INV_TIME = null;
                insert.CUSTOMER_REMARK = TxtCustomerRemark.Text.Trim().ToUpper();
                if (TxtLastJobCardNo.Text == string.Empty)
                {
                    insert.LAST_JOBCARD_NO = null;
                }
                else
                {
                    insert.LAST_JOBCARD_NO = TxtLastJobCardNo.Text.Trim();
                }

                if (TxtLastJobCardDate.Text == string.Empty)
                {
                    insert.LAST_JOBCARD_DATE = "";
                }
                else
                {
                    insert.LAST_JOBCARD_DATE = Convert.ToDateTime(TxtLastJobCardDate.Text.Trim()).ToString("MM-dd-yyyy");
                }

                if (TxtLastRunningHours.Text == string.Empty)
                {
                    insert.LAST_RUNNING_HRS = null;
                }
                else
                {
                    insert.LAST_RUNNING_HRS = TxtLastRunningHours.Text.Trim();
                }

                if (TxtLastLoadingHours.Text == string.Empty)
                {
                    insert.LAST_LOADING_HRS = null;
                }
                else
                {
                    insert.LAST_LOADING_HRS = TxtLastLoadingHours.Text.Trim();
                }

                insert.SIGN_PERSON = TxtSignaturePerson.Text.Trim().ToUpper();
                insert.SIGN_PHONE = TxtSignaturePhone.Text.Trim();
                insert.SERVICE_TYPE = DdlServiceType.SelectedValue.Trim().ToUpper();
                insert.AMC_TRAN_DATE = Convert.ToDateTime(HfAMC_TRAN_DATE.Value.ToString()).ToString("MM-dd-yyyy");
                insert.AMC_TRAN_NO = HfAMC_TRAN_NO.Value.Trim();
                insert.AMC_SRNO = HfAMC_SRNO.Value.Trim();
                insert.AMC_SUB_SRNO = null;
                if (TxtNextServiceDate.Text == string.Empty)
                {
                    insert.NEXT_SERVICE_DATE = "";
                }
                else
                {
                    insert.NEXT_SERVICE_DATE = Convert.ToDateTime(TxtNextServiceDate.Text.Trim()).ToString("MM-dd-yyyy");
                }

                insert.STATUS = "";
                insert.LAST_TRAN_DATE = null;
                insert.LAST_TRAN_NO = null;
                insert.PO_NO = TxtPONumber.Text.Trim();
                if (TxtPODate.Text == string.Empty)
                {
                    TxtPODate.Text = "";
                }
                else
                {
                    insert.PO_DT = Convert.ToDateTime(TxtPODate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                insert.COMPLAIN_TYPE = null;
                insert.COMPLAIN_NO = null;
                insert.TRAN_FROM = "J";

                if (TxtCancelDescription.Text == string.Empty)
                {
                    insert.CANCEL_CODE = null;
                }
                else
                {
                    insert.CANCEL_CODE = HfCancelCode.Value.Trim();
                }

                insert.CANCEL_REMARK = TxtCancelRemark.Text.Trim();
                insert.cancel_date = null;
                insert.cancel_time = null;
                insert.cancel_bcode = null;
                insert.cancel_userid = null;

                #endregion

                #region INSERT INTO COMPLAIN DETAILS GRID

                XmlDocument XDoc_JobComplain = new XmlDocument();
                XmlDeclaration dec1 = XDoc_JobComplain.CreateXmlDeclaration("1.0", null, null);
                XDoc_JobComplain.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc_JobComplain.CreateElement("root");
                XDoc_JobComplain.AppendChild(root1);
                int ComplainSRNO = 1;

                foreach (GridViewRow row in GvJobCardComplain.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                        HiddenField HfTranNo = row.FindControl("HfTranNo") as HiddenField;
                        HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                        HiddenField HfComplainCode = row.FindControl("HfComplainCode") as HiddenField;

                        TextBox TxtComplainDescription = row.FindControl("TxtComplainDescription") as TextBox;
                        TextBox TxtComplainCheckingDetails = row.FindControl("TxtComplainCheckingDetails") as TextBox;



                        if (HfComplainCode.Value != "0" && HfComplainCode.Value != string.Empty && HfComplainCode.Value != null)
                        {

                            XmlElement HandleDetail1 = XDoc_JobComplain.CreateElement("JOBCARD_COMPLAINDetails");
                            HandleDetail1.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                            HandleDetail1.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail1.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                            HandleDetail1.SetAttribute("SRNO", ComplainSRNO.ToString());
                            HandleDetail1.SetAttribute("COMPLAIN_DESC", TxtComplainCheckingDetails.Text.Trim());
                            HandleDetail1.SetAttribute("REMARK", "");
                            HandleDetail1.SetAttribute("INS_USERID", Session["USERNAME"].ToString());
                            HandleDetail1.SetAttribute("INS_DATE", "");
                            HandleDetail1.SetAttribute("UPD_USERID", Session["USERNAME"].ToString());
                            HandleDetail1.SetAttribute("UPD_DATE", "");
                            HandleDetail1.SetAttribute("COMPLAIN_CODE", HfComplainCode.Value.Trim());

                            root1.AppendChild(HandleDetail1);
                            ComplainSRNO++;
                        }



                    }
                }

                #endregion

                #region INSERT INTO JOBCARD SERVICE DETAILS GRID

                XmlDocument XDoc_ServiceDetail = new XmlDocument();
                XmlDeclaration dec2 = XDoc_ServiceDetail.CreateXmlDeclaration("1.0", null, null);
                XDoc_ServiceDetail.AppendChild(dec2);// Create the root element
                XmlElement root2 = XDoc_ServiceDetail.CreateElement("root");
                XDoc_ServiceDetail.AppendChild(root2);
                int ServiceSRNO = 1;

                foreach (GridViewRow row in GvServiceDetail.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        HiddenField HfBrandTypeCodeGrid = row.FindControl("HfBrandTypeCodeGrid") as HiddenField;
                        HiddenField HfBrandTypeSrNo = row.FindControl("HfBrandTypeSrNo") as HiddenField;

                        CheckBox CheckBoxOption1 = row.FindControl("CheckBoxOption1") as CheckBox;
                        CheckBox CheckBoxOption2 = row.FindControl("CheckBoxOption2") as CheckBox;
                        CheckBox CheckBoxChecking1 = row.FindControl("CheckBoxChecking1") as CheckBox;
                        CheckBox CheckBoxChecking2 = row.FindControl("CheckBoxChecking2") as CheckBox;
                        CheckBox CheckBoxRemark1 = row.FindControl("CheckBoxRemark1") as CheckBox;
                        CheckBox CheckBoxRemark2 = row.FindControl("CheckBoxRemark2") as CheckBox;
                        CheckBox TxtComplainDescription = row.FindControl("TxtComplainDescription") as CheckBox;




                        if (HfBrandTypeCodeGrid.Value != "0" && HfBrandTypeCodeGrid.Value != string.Empty && HfBrandTypeCodeGrid.Value != null)
                        {

                            XmlElement HandleDetail2 = XDoc_ServiceDetail.CreateElement("JOBCARD_SERVICEDetails");
                            HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                            HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                            HandleDetail2.SetAttribute("SRNO", ServiceSRNO.ToString());
                            HandleDetail2.SetAttribute("BRANDTYPE_CODE", HfBrandTypeCodeGrid.Value.Trim());
                            HandleDetail2.SetAttribute("BRANDTYPE_SRNO", HfBrandTypeSrNo.Value.Trim());

                            if (CheckBoxOption1.Checked == true)
                            {
                                HandleDetail2.SetAttribute("RESULT_FLAG_1_1", "Y");
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("RESULT_FLAG_1_1", "N");
                            }

                            if (CheckBoxChecking1.Checked == true)
                            {
                                HandleDetail2.SetAttribute("RESULT_FLAG_2_1", "Y");
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("RESULT_FLAG_2_1", "N");
                            }

                            if (CheckBoxRemark1.Checked == true)
                            {
                                HandleDetail2.SetAttribute("RESULT_FLAG_3_1", "Y");
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("RESULT_FLAG_3_1", "N");
                            }

                            HandleDetail2.SetAttribute("REMARK", "");
                            HandleDetail2.SetAttribute("INS_USERID", Session["USERNAME"].ToString());
                            HandleDetail2.SetAttribute("INS_DATE", "");
                            HandleDetail2.SetAttribute("UPD_USERID", Session["USERNAME"].ToString());
                            HandleDetail2.SetAttribute("UPD_DATE", "");

                            if (CheckBoxOption2.Checked == true)
                            {
                                HandleDetail2.SetAttribute("RESULT_FLAG_1_2", "Y");
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("RESULT_FLAG_1_2", "N");
                            }

                            if (CheckBoxChecking2.Checked == true)
                            {
                                HandleDetail2.SetAttribute("RESULT_FLAG_2_2", "Y");
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("RESULT_FLAG_2_2", "N");
                            }

                            if (CheckBoxRemark2.Checked == true)
                            {
                                HandleDetail2.SetAttribute("RESULT_FLAG_3_2", "Y");
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("RESULT_FLAG_3_2", "N");
                            }

                            root2.AppendChild(HandleDetail2);
                            ServiceSRNO++;

                        }




                    }

                }

                #endregion

                #region INSERT INTO JOBCARD SERVICE REMARKS INTO GRID


                XmlDocument XDoc_ServiceRemark = new XmlDocument();
                XmlDeclaration dec3 = XDoc_ServiceRemark.CreateXmlDeclaration("1.0", null, null);
                XDoc_ServiceRemark.AppendChild(dec3);// Create the root element
                XmlElement root3 = XDoc_ServiceRemark.CreateElement("root");
                XDoc_ServiceRemark.AppendChild(root3);
                int RemarkSRNO = 1;

                foreach (GridViewRow row in GvServiceRemarks.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        HiddenField HfCompCode = row.FindControl("HfCompCode") as HiddenField;
                        HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                        HiddenField HfTranNo = row.FindControl("HfTranNo") as HiddenField;
                        HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;

                        TextBox TxtServiceRemark = row.FindControl("TxtServiceRemark") as TextBox;



                        if (TxtServiceRemark.Text != string.Empty && TxtServiceRemark.Text != null)
                        {

                            XmlElement HandleDetail3 = XDoc_ServiceRemark.CreateElement("JOBCARD_REMARKDetails");

                            HandleDetail3.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                            HandleDetail3.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail3.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                            HandleDetail3.SetAttribute("SRNO", RemarkSRNO.ToString());
                            HandleDetail3.SetAttribute("REMARK", TxtServiceRemark.Text.Trim());
                            HandleDetail3.SetAttribute("INS_DATE", "");
                            HandleDetail3.SetAttribute("INS_USERID", Session["USERNAME"].ToString());
                            HandleDetail3.SetAttribute("UPD_DATE", "");
                            HandleDetail3.SetAttribute("UPD_USERID", Session["USERNAME"].ToString());
                            root3.AppendChild(HandleDetail3);
                            RemarkSRNO++;


                        }




                    }
                }


                #endregion


                #region INSERT INTO SERVICE USE ITEM INTO GRID

                XmlDocument XDoc_ServiceUseItem = new XmlDocument();
                XmlDeclaration dec4 = XDoc_ServiceUseItem.CreateXmlDeclaration("1.0", null, null);
                XDoc_ServiceUseItem.AppendChild(dec4);// Create the root element
                XmlElement root4 = XDoc_ServiceUseItem.CreateElement("root");
                XDoc_ServiceUseItem.AppendChild(root4);
                int UseItemSRNO = 1;

                foreach (GridViewRow row in GvServiceUseItem.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                        HiddenField HfRefTranDate = row.FindControl("HfRefTranDate") as HiddenField;
                        HiddenField HfRefTranNo = row.FindControl("HfRefTranNo") as HiddenField;
                        HiddenField HfRefSrNo = row.FindControl("HfRefSrNo") as HiddenField;

                        TextBox TxtUseQty = row.FindControl("TxtUseQty") as TextBox;



                        if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != string.Empty && HfDetailSCode.Value != null)
                        {


                            XmlElement HandleDetail4 = XDoc_ServiceUseItem.CreateElement("JOBCARD_SERVICE_USE_ITEMDetails");
                            HandleDetail4.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                            HandleDetail4.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail4.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                            HandleDetail4.SetAttribute("SRNO", UseItemSRNO.ToString());
                            HandleDetail4.SetAttribute("SCODE", HfDetailSCode.Value.Trim());
                            HandleDetail4.SetAttribute("REF_TRAN_DATE", Convert.ToDateTime(HfRefTranDate.Value.Trim()).ToString("MM-dd-yyyy"));
                            HandleDetail4.SetAttribute("REF_TRAN_NO", HfRefTranNo.Value.Trim());
                            HandleDetail4.SetAttribute("REF_SRNO", HfRefSrNo.Value.Trim());
                            HandleDetail4.SetAttribute("QTY", TxtUseQty.Text.Trim());


                            root4.AppendChild(HandleDetail4);
                            UseItemSRNO++;

                        }


                    }
                }

                #endregion

                #region INSERT INTO SERVICE LABOURS CHARGES Details GRID


                XmlDocument XDoc_LabourCharges = new XmlDocument();
                XmlDeclaration dec5 = XDoc_LabourCharges.CreateXmlDeclaration("1.0", null, null);
                XDoc_LabourCharges.AppendChild(dec5);// Create the root element
                XmlElement root5 = XDoc_LabourCharges.CreateElement("root");
                XDoc_LabourCharges.AppendChild(root5);
                int ChargesSRNO = 1;

                foreach (GridViewRow row in GvLabourChagresDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                        HiddenField HfTranNo = row.FindControl("HfTranNo") as HiddenField;
                        HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                        HiddenField HfChargesCode = row.FindControl("HfChargesCode") as HiddenField;

                        TextBox TxtChargesDescription = row.FindControl("TxtChargesDescription") as TextBox;
                        TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                        TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                        TextBox TxtChargesAmount = row.FindControl("TxtChargesAmount") as TextBox;
                        TextBox TxtRemarks = row.FindControl("TxtRemarks") as TextBox;



                        if (HfChargesCode.Value != "0" && HfChargesCode.Value != string.Empty && HfChargesCode.Value != null)
                        {


                            XmlElement HandleDetail5 = XDoc_LabourCharges.CreateElement("JOBCARD_LAB_CHARGEDetails");
                            HandleDetail5.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                            HandleDetail5.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail5.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                            HandleDetail5.SetAttribute("SRNO", ChargesSRNO.ToString());
                            HandleDetail5.SetAttribute("CCODE", HfChargesCode.Value.Trim());
                            HandleDetail5.SetAttribute("LAB_DESC", TxtChargesDescription.Text.Trim());
                            if (TxtQty.Text == string.Empty)
                            {
                                HandleDetail5.SetAttribute("QTY", "0");
                            }
                            else
                            {
                                HandleDetail5.SetAttribute("QTY", TxtQty.Text.Trim());
                            }

                            if (TxtRate.Text == string.Empty)
                            {
                                HandleDetail5.SetAttribute("RATE", "0");
                            }
                            else
                            {
                                HandleDetail5.SetAttribute("RATE", TxtRate.Text.Trim());
                            }

                            if (TxtChargesAmount.Text == string.Empty)
                            {
                                HandleDetail5.SetAttribute("AMT", "0");
                            }
                            else
                            {
                                HandleDetail5.SetAttribute("AMT", TxtChargesAmount.Text.Trim());
                            }

                            HandleDetail5.SetAttribute("REMARK", TxtRemarks.Text.Trim());
                            HandleDetail5.SetAttribute("INS_DATE", "");
                            HandleDetail5.SetAttribute("INS_USERID", Session["USERNAME"].ToString());
                            HandleDetail5.SetAttribute("UPD_DATE", "");
                            HandleDetail5.SetAttribute("UPD_USERID", Session["USERNAME"].ToString());
                            root5.AppendChild(HandleDetail5);
                            ChargesSRNO++;
                        }

                    }
                }

                #endregion

                if (TxtProfitTotalPercentage.Text == "100" || TxtProfitTotalPercentage.Text == "0" || TxtProfitTotalPercentage.Text == string.Empty)
                {

                    string str = JOBCARD_MASLogicLayer.UpdateJOBCARD_MASDetail(insert, validation.RSC(XDoc_JobComplain.OuterXml), validation.RSC(XDoc_ServiceDetail.OuterXml), validation.RSC(XDoc_ServiceRemark.OuterXml), validation.RSC(XDoc_ServiceUseItem.OuterXml), validation.RSC(XDoc_LabourCharges.OuterXml));

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "JOBCARD MASTER UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillJOBCARDMasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "JOBCARD MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : JOBCARD MASTER NOT UPDATED";
                        lblmsg.ForeColor = Color.Red;

                    }

                }

                else
                {
                    lblmsg.Text = "ERROR :TOTAL PERCENTAGE SHOULD BE 100%";
                    lblmsg.ForeColor = Color.Red;

                }

                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void TxtJobCardDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string JOBCARD_NO = JOBCARD_MASLogicLayer.GetJOBCARDNumber_JOBCARDMASCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtJobCardDate.Text.Trim()).ToString("yyyy-MM-dd"));
                if (JOBCARD_NO.Length <= 8)
                {
                    TxtJobCardNo.Text = JOBCARD_NO;
                }
                else
                {
                    TxtJobCardNo.Text = string.Empty;
                }

                TxtJobCardTime.Text = System.DateTime.Now.ToString("HH:MM");

            }
            catch (Exception)
            {

                throw;
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetAccountName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from ACCOUNTS where COMP_CODE=@COMP_CODE AND BRANCH_CODE=@BRANCH_CODE AND ANAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            cmd.Parameters.AddWithValue("@BRANCH_CODE", Branchcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> ANames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ANames.Add(dt.Rows[i][2].ToString());
            }
            return ANames;
        }


        protected void TxtPartyName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select ACODE from ACCOUNTS where ANAME = '" + TxtPartyName.Text + "' and COMP_CODE = " + Session["COMP_CODE"].ToString(), con);
                int x = Convert.ToInt32(cmd.ExecuteScalar());
                if (x == 0)
                {
                    TxtPartyName.BackColor = Color.Red;
                }
                else
                {
                    HfACODE.Value = cmd.ExecuteScalar().ToString();
                    TxtPartyName.BackColor = Color.White; con.Close();
                    FillContactPersonNameByParty();


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillContactPersonNameByParty()
        {
            try
            {
                string Acc_Code = HfACODE.Value;

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_DETLogicLayer.GetAllParty_Contact_DetialsWIiseAccountFor_DDL(Acc_Code);
                DdlContactPerson.DataSource = Dt;
                DdlContactPerson.DataValueField = "CONTACT_NAME";
                DdlContactPerson.DataTextField = "CONTACT_NAME";
                DdlContactPerson.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlContactPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                getContactPersonPhoneNo();
                getContactPersonEmail();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void getContactPersonPhoneNo()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select PHONE_NO from ACCOUNTS_DET where CONTACT_NAME = '" + DdlContactPerson.SelectedItem.ToString() + "' and ACODE = " + HfACODE.Value.ToString(), con);
                TxtContactPhone.Text = cmd.ExecuteScalar().ToString();
                TxtContactPhone.Enabled = false;
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void getContactPersonEmail()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select MAIL_ID from ACCOUNTS_DET where CONTACT_NAME = '" + DdlContactPerson.SelectedItem.ToString() + "' and ACODE = " + HfACODE.Value.ToString(), con);
                TxtContactEmail.Text = cmd.ExecuteScalar().ToString();
                TxtContactEmail.Enabled = false;
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnContactDetails_Click(object sender, EventArgs e)
        {

            if (HfACODE.Value == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Must be select Party Name..!!');", true);

            }
            else
            {
                string COMP_CODE = HttpUtility.UrlEncode(encrypt(Session["COMP_CODE"].ToString()));
                string ACODE = HttpUtility.UrlEncode(encrypt(HfACODE.Value));

                if (btnSave.Visible == true)
                {
                    Response.Write("<script>window.open ('PartyContactDetails.aspx?ACODE=" + ACODE + "&COMP_CODE=" + COMP_CODE + "', '_blank');</script>");
                }
                else
                {
                    Response.Write("<script>window.open ('PartyContactDetails.aspx?ACODE=" + ACODE + "&COMP_CODE=" + COMP_CODE + "&Flag=1', '_blank');</script>");
                }
            }
        }

        public string encrypt(string encryptString)
        {
            string EncryptionKey = "mihirlad9021";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }

        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "mihirlad9021";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        protected void btnRefreshContactDetails_Click(object sender, EventArgs e)
        {

        }

        public void FillPartyModelSrNo()
        {
            try
            {
                string ACODE = HfACODE.Value;

                DataTable Dt = new DataTable();
                Dt = PARTY_MODELMASLogicLayer.GetAllPARTY_MODELMASDetailWisePartyNameForGrid(ACODE);

                GvPartyModelSrNo.DataSource = Dt;
                GvPartyModelSrNo.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnGetPartyModelSrNo_Click(object sender, EventArgs e)
        {

            try
            {
                if (HfACODE.Value == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SelectionAlert", "SelectionAlert()", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelPartyModelSrNo", "ShowModelPartyModelSrNo()", true);

                    FillPartyModelSrNo();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvPartyModelSrNo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Selecta")
                {

                    // clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfCompCodeModel = (row.FindControl("HfCompCodeModel")) as HiddenField;
                        HiddenField HfBranchCodeModel = (row.FindControl("HfBranchCodeModel")) as HiddenField;


                        DataTable Dt = PARTY_MODELMASLogicLayer.GetAllIDWisePARTY_MODELMASDetailForJobcard(e.CommandArgument.ToString());

                        if (Dt.Rows.Count > 0)
                        {
                            HfPartRefSrNo.Value = Dt.Rows[0]["SRNO"].ToString();
                            TxtPartyModelSrNo.Text = Dt.Rows[0]["MODEL_SRNO"].ToString();
                            TxtPartySrNo.Text = Dt.Rows[0]["PARTY_SRNO"].ToString();
                            TxtMfgSrNo.Text = Dt.Rows[0]["MFG_SRNO"].ToString();
                            TxtBrandName.Text = Dt.Rows[0]["BRAND_NAME"].ToString();
                            TxtModelName.Text = Dt.Rows[0]["MODEL_NAME"].ToString();
                            TxtBrandTypeName.Text = Dt.Rows[0]["BRANDTYPE_NAME"].ToString();
                            DdlServiceType.SelectedValue = Dt.Rows[0]["SERVICE_TYPE"].ToString();
                            HfBrandTypeCode.Value = Dt.Rows[0]["BRANDTYPE_CODE"].ToString();
                            HfBrandTypeSrNo.Value = Dt.Rows[0]["BRANDTYPE_SRNO"].ToString();
                            HfAMC_TRAN_DATE.Value = Convert.ToDateTime(Dt.Rows[0]["AMC_TRAN_DATE"].ToString()).ToString();
                            HfAMC_TRAN_NO.Value = Dt.Rows[0]["AMC_TRAN_NO"].ToString();
                            HfAMC_SRNO.Value = Dt.Rows[0]["AMC_SRNO"].ToString();


                            if (DdlServiceType.SelectedValue == "W" || DdlServiceType.SelectedValue == "A")
                            {
                                TxtAMCNo.Text = Dt.Rows[0]["AMC_NO"].ToString();
                                TxtAMCFromDate.Text = Convert.ToDateTime(Dt.Rows[0]["AMC_FRDT"].ToString()).ToString("dd-MM-yyyy");
                                TxtAMCToDate.Text = Convert.ToDateTime(Dt.Rows[0]["AMC_TODT"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                TxtAMCNo.Text = string.Empty;
                                TxtAMCFromDate.Text = string.Empty;
                                TxtAMCToDate.Text = string.Empty;
                            }

                        }
                        else
                        {

                        }

                        DataTable DtLastJobcard = new DataTable();
                        DtLastJobcard = JOBCARD_MASLogicLayer.GetLastJOBCARD_MASDetailsOnAcodeAndPartyRefNo(HfACODE.Value.ToString(), HfPartRefSrNo.Value.ToString());
                        if (DtLastJobcard.Rows.Count > 0)
                        {
                            TxtLastJobCardNo.Text = DtLastJobcard.Rows[0]["JOBCARD_NO"].ToString();
                            TxtLastJobCardDate.Text = Convert.ToDateTime(DtLastJobcard.Rows[0]["JOBCARD_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtLastLoadingHours.Text = DtLastJobcard.Rows[0]["LOADING_HRS"].ToString();
                            TxtLastRunningHours.Text = DtLastJobcard.Rows[0]["RUNNING_HRS"].ToString();
                        }
                        else
                        {
                            TxtLastJobCardNo.Text = string.Empty;
                            TxtLastJobCardDate.Text = string.Empty;
                            TxtLastLoadingHours.Text = string.Empty;
                            TxtLastRunningHours.Text = string.Empty;
                        }

                    }

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModelPartyModelSrNo", "HideModelPartyModelSrNo()", true);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnPartyModelDetails_Click(object sender, EventArgs e)
        {
            try
            {
                string COMP_CODE = Session["COMP_CODE"].ToString();
                string ACODE = HfACODE.Value;

                if (HfACODE.Value == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SelectionAlert", "SelectionAlert()", true);
                }
                else
                {
                    Response.Write("<script>window.open ('PartyModelMaster.aspx?ACODE=" + ACODE + "&COMP_CODE=" + COMP_CODE + "', '_blank');</script>");
                }


            }

            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnJobCancelMaster_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../admin/JobCancelMaster.aspx', '_blank');", true);
        }


        protected void TxtJobAssignPersonName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtJobAssignPersonName.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtJobAssignPersonName.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfJobAssignPersonName.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region ADD NEW ROW INTO JOBCARD COMPLAIN DETAILS GRID


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetComplainDesciption(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from JOB_COMPMAS where COMP_CODE=@COMP_CODE AND COMPLAIN_DESC like  + @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> ComplainDesc = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ComplainDesc.Add(dt.Rows[i][3].ToString());
            }
            return ComplainDesc;
        }

        protected void TxtComplainDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtComplainCheckingDetails = (TextBox)row.Cells[2].FindControl("TxtComplainCheckingDetails");

                HiddenField HfComplainCode = (HiddenField)row.Cells[0].FindControl("HfComplainCode");

                DataTable DtComplain = new DataTable();
                DtComplain = JOB_COMPMASLogicLayer.GetAllJOB_COMPLAIN_MASDetialsByCompany(Session["COMP_CODE"].ToString());
                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtComplain);
                    Dv.RowFilter = "COMPLAIN_DESC='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfComplainCode.Value = DtView.Rows[0]["COMPLAIN_CODE"].ToString();
                        TxtComplainCheckingDetails.Text = DtView.Rows[0]["COMPLAIN_CHECK"].ToString();

                    }
                    else
                    {
                        HfComplainCode.Value = string.Empty;
                        TxtComplainCheckingDetails.Text = string.Empty;
                    }
                    FillGvJobCardComplainGridOnUpdate();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetInitialRowJobCardComplain()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("COMPLAIN_DESC", typeof(string));
            table.Columns.Add("REMARK", typeof(string));
            table.Columns.Add("INS_USERID", typeof(string));
            table.Columns.Add("INS_DATE", typeof(string));
            table.Columns.Add("UPD_USERID", typeof(string));
            table.Columns.Add("UPD_DATE", typeof(string));
            table.Columns.Add("COMPLAIN_CODE", typeof(string));
            table.Columns.Add("COMPLAIN_CHECK", typeof(string));

            dr = table.NewRow();

            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["COMPLAIN_DESC"] = string.Empty;
            dr["REMARK"] = string.Empty;
            dr["INS_USERID"] = string.Empty;
            dr["INS_DATE"] = string.Empty;
            dr["UPD_USERID"] = string.Empty;
            dr["UPD_DATE"] = string.Empty;
            dr["COMPLAIN_CODE"] = string.Empty;
            dr["COMPLAIN_CHECK"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["TableJobCardComplain"] = table;

            GvJobCardComplain.DataSource = table;
            GvJobCardComplain.DataBind();
        }


        private void AddNewRowToJobCardComplainGrid()
        {
            int rowIndex = 0;

            if (ViewState["TableJobCardComplain"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["TableJobCardComplain"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values 
                        //TextBox TxtSr = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtSr");

                        HiddenField HfCompCode = (HiddenField)GvJobCardComplain.Rows[rowIndex].Cells[0].FindControl("HfCompCode");
                        HiddenField HfTranDate = (HiddenField)GvJobCardComplain.Rows[rowIndex].Cells[0].FindControl("HfTranDate");
                        HiddenField HfTranNo = (HiddenField)GvJobCardComplain.Rows[rowIndex].Cells[0].FindControl("HfTranNo");
                        HiddenField HfSrNo = (HiddenField)GvJobCardComplain.Rows[rowIndex].Cells[0].FindControl("HfSrNo");
                        HiddenField HfComplainCode = (HiddenField)GvJobCardComplain.Rows[rowIndex].Cells[0].FindControl("HfComplainCode");


                        TextBox TxtComplainDescription = (TextBox)GvJobCardComplain.Rows[rowIndex].Cells[1].FindControl("TxtComplainDescription");
                        TextBox TxtComplainCheckingDetails = (TextBox)GvJobCardComplain.Rows[rowIndex].Cells[2].FindControl("TxtComplainCheckingDetails");


                        //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["COMPLAIN_DESC"] = TxtComplainDescription.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["COMPLAIN_CODE"] = HfComplainCode.Value.Trim();
                        //dtCurrentTable.Rows[i - 1]["COMPLAIN_CHECK"] = TxtComplainCheckingDetails.Text.Trim();



                        rowIndex++;

                    }


                    drCurrentRow = dtCurrentTable.NewRow();


                    //drCurrentRow["COMP_CODE"] = "0";
                    //drCurrentRow["TRAN_DATE"] = "";
                    //drCurrentRow["TRAN_NO"] = "0";
                    //drCurrentRow["SRNO"] = "0";
                    drCurrentRow["COMPLAIN_CODE"] = "0";
                    drCurrentRow["COMPLAIN_DESC"] = "";
                    //    drCurrentRow["COMPLAIN_CHECK"] = "";
                    //drCurrentRow["REMARK"] = "";
                    //drCurrentRow["INS_USERID"] = "";
                    //drCurrentRow["INS_DATE"] = "";
                    //drCurrentRow["UPD_USERID"] = "";
                    //drCurrentRow["UPD_DATE"] = "";



                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["TableJobCardComplain"] = dtCurrentTable;

                    GvJobCardComplain.DataSource = dtCurrentTable;
                    GvJobCardComplain.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousDataToJobCardComplainGrid();
        }


        private void SetPreviousDataToJobCardComplainGrid()
        {
            int rowIndex = 0;
            if (ViewState["TableJobCardComplain"] != null)
            {
                DataTable dt = (DataTable)ViewState["TableJobCardComplain"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        HiddenField HfCompCode = (HiddenField)GvJobCardComplain.Rows[rowIndex].Cells[0].FindControl("HfCompCode");
                        HiddenField HfTranDate = (HiddenField)GvJobCardComplain.Rows[rowIndex].Cells[0].FindControl("HfTranDate");
                        HiddenField HfTranNo = (HiddenField)GvJobCardComplain.Rows[rowIndex].Cells[0].FindControl("HfTranNo");
                        HiddenField HfSrNo = (HiddenField)GvJobCardComplain.Rows[rowIndex].Cells[0].FindControl("HfSrNo");
                        HiddenField HfComplainCode = (HiddenField)GvJobCardComplain.Rows[rowIndex].Cells[0].FindControl("HfComplainCode");


                        TextBox TxtComplainDescription = (TextBox)GvJobCardComplain.Rows[rowIndex].Cells[1].FindControl("TxtComplainDescription");
                        TextBox TxtComplainCheckingDetails = (TextBox)GvJobCardComplain.Rows[rowIndex].Cells[2].FindControl("TxtComplainCheckingDetails");

                        HfComplainCode.Value = dt.Rows[i]["COMPLAIN_CODE"].ToString();
                        TxtComplainDescription.Text = dt.Rows[i]["COMPLAIN_DESC"].ToString();
                        //  TxtComplainCheckingDetails.Text = dt.Rows[i]["COMPLAIN_CHECK"].ToString();


                        rowIndex++;

                    }
                }
            }
        }

        protected void BtnDeleteRowJobCardComplainGrid_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex + 1;
            if (ViewState["TableJobCardComplain"] != null)
            {
                DataTable dt = (DataTable)ViewState["TableJobCardComplain"];
                if (dt.Rows.Count > 1)
                {

                    if (gvRow.RowIndex <= dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data
                        dt.Rows.Remove(dt.Rows[rowID - 1]);
                    }
                }
                //Store the current data in ViewState for future reference
                ViewState["TableJobCardComplain"] = dt;
                //Re bind the GridView for the updated data
                GvJobCardComplain.DataSource = dt;
                GvJobCardComplain.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousDataToJobCardComplainGrid();
        }

        protected void BtnAddRowJobCardComplainGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToJobCardComplainGrid();
        }


        public void FillGvJobCardComplainGridOnUpdate()
        {

            try
            {
                #region Assign to JOBCARD COMPLAIN GRID

                int rowIndex = 0;

                if (ViewState["TableJobCardComplain"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["TableJobCardComplain"];

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //extract the TextBox values 
                            //TextBox TxtSr = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtSr");

                            HiddenField HfCompCode = (HiddenField)GvJobCardComplain.Rows[rowIndex].Cells[0].FindControl("HfCompCode");
                            HiddenField HfTranDate = (HiddenField)GvJobCardComplain.Rows[rowIndex].Cells[0].FindControl("HfTranDate");
                            HiddenField HfTranNo = (HiddenField)GvJobCardComplain.Rows[rowIndex].Cells[0].FindControl("HfTranNo");
                            HiddenField HfSrNo = (HiddenField)GvJobCardComplain.Rows[rowIndex].Cells[0].FindControl("HfSrNo");
                            HiddenField HfComplainCode = (HiddenField)GvJobCardComplain.Rows[rowIndex].Cells[0].FindControl("HfComplainCode");


                            TextBox TxtComplainDescription = (TextBox)GvJobCardComplain.Rows[rowIndex].Cells[1].FindControl("TxtComplainDescription");
                            TextBox TxtComplainCheckingDetails = (TextBox)GvJobCardComplain.Rows[rowIndex].Cells[2].FindControl("TxtComplainCheckingDetails");


                            //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["COMPLAIN_DESC"] = TxtComplainDescription.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["COMPLAIN_CODE"] = HfComplainCode.Value.Trim();
                            // dtCurrentTable.Rows[i - 1]["COMPLAIN_CHECKING"] = TxtComplainCheckingDetails.Text.Trim();


                            rowIndex++;

                        }
                    }
                }

                #endregion
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void GvJobCardComplain_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField HfComplainCode = (e.Row.FindControl("HfComplainCode") as HiddenField);
                    TextBox TxtComplainDescription = (e.Row.FindControl("TxtComplainDescription") as TextBox);
                    TextBox TxtComplainCheckingDetails = (e.Row.FindControl("TxtComplainCheckingDetails") as TextBox);

                    DataTable DtComplain = new DataTable();
                    DtComplain = JOB_COMPMASLogicLayer.GetAllIDWiseJOB_COMPLAIN_MASDetail(HfComplainCode.Value);

                    if (HfComplainCode.Value != string.Empty && HfComplainCode.Value != null)
                    {
                        DataView Dv = new DataView(DtComplain);
                        Dv.RowFilter = "COMPLAIN_CODE=" + HfComplainCode.Value;
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            TxtComplainDescription.Text = DtView.Rows[0]["COMPLAIN_DESC"].ToString();
                            TxtComplainCheckingDetails.Text = DtView.Rows[0]["COMPLAIN_CHECK"].ToString();
                        }
                        else
                        {
                            TxtComplainDescription.Text = string.Empty;
                            TxtComplainCheckingDetails.Text = string.Empty;
                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region ADD NEW ROW INTO SERVICE REMARK GRID

        private void SetInitialRowServiceRemarks()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("REMARK", typeof(string));
            table.Columns.Add("INS_USERID", typeof(string));
            table.Columns.Add("INS_DATE", typeof(string));
            table.Columns.Add("UPD_USERID", typeof(string));
            table.Columns.Add("UPD_DATE", typeof(string));

            dr = table.NewRow();

            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["REMARK"] = string.Empty;
            dr["INS_USERID"] = string.Empty;
            dr["INS_DATE"] = string.Empty;
            dr["UPD_USERID"] = string.Empty;
            dr["UPD_DATE"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["TableServiceRemarks"] = table;

            GvServiceRemarks.DataSource = table;
            GvServiceRemarks.DataBind();
        }


        private void AddNewRowToServiceRemarksGrid()
        {
            int rowIndex = 0;

            if (ViewState["TableServiceRemarks"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["TableServiceRemarks"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values 
                        //TextBox TxtSr = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtSr");

                        HiddenField HfCompCode = (HiddenField)GvServiceRemarks.Rows[rowIndex].Cells[0].FindControl("HfCompCode");
                        HiddenField HfTranDate = (HiddenField)GvServiceRemarks.Rows[rowIndex].Cells[0].FindControl("HfTranDate");
                        HiddenField HfTranNo = (HiddenField)GvServiceRemarks.Rows[rowIndex].Cells[0].FindControl("HfTranNo");
                        HiddenField HfSrNo = (HiddenField)GvServiceRemarks.Rows[rowIndex].Cells[0].FindControl("HfSrNo");

                        TextBox TxtServiceRemark = (TextBox)GvServiceRemarks.Rows[rowIndex].Cells[1].FindControl("TxtServiceRemark");


                        //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();

                        dtCurrentTable.Rows[i - 1]["REMARK"] = TxtServiceRemark.Text.Trim();



                        rowIndex++;

                    }


                    drCurrentRow = dtCurrentTable.NewRow();

                    //drCurrentRow["SR"] = "";
                    //drCurrentRow["COMP_CODE"] = "0";
                    //drCurrentRow["TRAN_DATE"] = "";
                    //drCurrentRow["TRAN_NO"] = "0";
                    //drCurrentRow["SRNO"] = "0";
                    drCurrentRow["REMARK"] = "";
                    //drCurrentRow["INS_USERID"] = "";
                    //drCurrentRow["INS_DATE"] = "";
                    //drCurrentRow["UPD_USERID"] = "";
                    //drCurrentRow["UPD_DATE"] = "";


                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["TableServiceRemarks"] = dtCurrentTable;

                    GvServiceRemarks.DataSource = dtCurrentTable;
                    GvServiceRemarks.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousDataToServiceRemarksGrid();
        }



        private void SetPreviousDataToServiceRemarksGrid()
        {
            int rowIndex = 0;
            if (ViewState["TableServiceRemarks"] != null)
            {
                DataTable dt = (DataTable)ViewState["TableServiceRemarks"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        HiddenField HfCompCode = (HiddenField)GvServiceRemarks.Rows[rowIndex].Cells[0].FindControl("HfCompCode");
                        HiddenField HfTranDate = (HiddenField)GvServiceRemarks.Rows[rowIndex].Cells[0].FindControl("HfTranDate");
                        HiddenField HfTranNo = (HiddenField)GvServiceRemarks.Rows[rowIndex].Cells[0].FindControl("HfTranNo");
                        HiddenField HfSrNo = (HiddenField)GvServiceRemarks.Rows[rowIndex].Cells[0].FindControl("HfSrNo");

                        TextBox TxtServiceRemark = (TextBox)GvServiceRemarks.Rows[rowIndex].Cells[1].FindControl("TxtServiceRemark");


                        TxtServiceRemark.Text = dt.Rows[i]["REMARK"].ToString();

                        rowIndex++;

                    }
                }
            }
        }

        protected void BtnDeleteRowServiceRemarkGrid_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex + 1;
            if (ViewState["TableServiceRemarks"] != null)
            {
                DataTable dt = (DataTable)ViewState["TableServiceRemarks"];
                if (dt.Rows.Count > 1)
                {

                    if (gvRow.RowIndex <= dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data
                        dt.Rows.Remove(dt.Rows[rowID - 1]);
                    }
                }
                //Store the current data in ViewState for future reference
                ViewState["TableServiceRemarks"] = dt;
                //Re bind the GridView for the updated data
                GvServiceRemarks.DataSource = dt;
                GvServiceRemarks.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousDataToServiceRemarksGrid();
        }

        protected void BtnAddRowServiceRemarkGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToServiceRemarksGrid();
        }

        #endregion

        #region GET SERVICE PERSON NAME AND BCODE

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetServicePersonName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from BROKER where COMP_CODE=@COMP_CODE and BRANCH_CODE=@BRANCH_CODE and BNAME like @BNAME + '%'", con);
            cmd.Parameters.AddWithValue("@BNAME", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            cmd.Parameters.AddWithValue("@BRANCH_CODE", Branchcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> BrokerName = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BrokerName.Add(dt.Rows[i][3].ToString());
            }
            return BrokerName;
        }

        protected void TxtServicePerson1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtServicePerson1.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtServicePerson1.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfServicePeronBCODE1.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtServicePerson2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtServicePerson2.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtServicePerson2.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfServicePeronBCODE2.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtServicePerson3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtServicePerson3.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtServicePerson3.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfServicePeronBCODE3.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtServicePerson4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtServicePerson4.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtServicePerson4.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfServicePeronBCODE4.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtServicePerson5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtServicePerson5.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtServicePerson5.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfServicePeronBCODE5.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void TotalServicePersonProfitPercentageAndAmountOnUpdate()
        {
            try
            {
                if (TxtServicePersonProfitPer1.Text == string.Empty)
                {
                    TxtServicePersonProfitPer1.Text = "0";
                    TxtServicePersonProfitAmt1.Text = "0";
                }
                if (TxtServicePersonProfitPer2.Text == string.Empty)
                {
                    TxtServicePersonProfitPer2.Text = "0";
                    TxtServicePersonProfitAmt2.Text = "0";
                }
                if (TxtServicePersonProfitPer3.Text == string.Empty)
                {
                    TxtServicePersonProfitPer3.Text = "0";
                    TxtServicePersonProfitAmt3.Text = "0";
                }
                if (TxtServicePersonProfitPer4.Text == string.Empty)
                {
                    TxtServicePersonProfitPer4.Text = "0";
                    TxtServicePersonProfitAmt4.Text = "0";
                }
                if (TxtServicePersonProfitPer5.Text == string.Empty)
                {
                    TxtServicePersonProfitPer5.Text = "0";
                    TxtServicePersonProfitAmt5.Text = "0";
                }


                TxtProfitTotalPercentage.Text = Convert.ToString(Convert.ToDouble(TxtServicePersonProfitPer1.Text) + Convert.ToDouble(TxtServicePersonProfitPer2.Text) + Convert.ToDouble(TxtServicePersonProfitPer3.Text) + Convert.ToDouble(TxtServicePersonProfitPer4.Text) + Convert.ToDouble(TxtServicePersonProfitPer5.Text)).ToString();

                TxtProfitTotalAmount.Text = Convert.ToString(Convert.ToDouble(TxtServicePersonProfitAmt1.Text) + Convert.ToDouble(TxtServicePersonProfitAmt2.Text) + Convert.ToDouble(TxtServicePersonProfitAmt3.Text) + Convert.ToDouble(TxtServicePersonProfitAmt4.Text) + Convert.ToDouble(TxtServicePersonProfitAmt5.Text)).ToString();
            }
            catch (Exception)
            {

                throw;
            }


        }


        protected void TxtServicePersonProfitPer1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtProfitAmountJobMas.Text != string.Empty && TxtProfitAmountJobMas.Text != null)
                {
                    if (validation.ispercentage(TxtServicePersonProfitPer1.Text.Trim()))
                    {
                        TxtServicePersonProfitAmt1.Text = ((Convert.ToDouble(TxtProfitAmountJobMas.Text) * Convert.ToDouble(TxtServicePersonProfitPer1.Text)) / 100).ToString();
                        TxtServicePersonProfitAmt1.Enabled = false;

                        TxtServicePersonProfitPer1.BackColor = Color.White;
                    }

                    else
                    {
                        TxtServicePersonProfitPer1.Text = "0";
                        TxtServicePersonProfitPer1.BackColor = Color.Red;
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Percentage should be between 0 to 100..!!');", true);
                        TxtServicePersonProfitPer1.Focus();
                    }

                    if (TxtServicePersonProfitPer1.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer1.Text = "0";
                        TxtServicePersonProfitAmt1.Text = "0";
                    }
                    if (TxtServicePersonProfitPer2.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer2.Text = "0";
                        TxtServicePersonProfitAmt2.Text = "0";
                    }
                    if (TxtServicePersonProfitPer3.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer3.Text = "0";
                        TxtServicePersonProfitAmt3.Text = "0";
                    }
                    if (TxtServicePersonProfitPer4.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer4.Text = "0";
                        TxtServicePersonProfitAmt4.Text = "0";
                    }
                    if (TxtServicePersonProfitPer5.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer5.Text = "0";
                        TxtServicePersonProfitAmt5.Text = "0";
                    }

                    if (TxtServicePersonProfitPer1.Text != string.Empty)
                    {
                        TxtProfitTotalPercentage.Text = Convert.ToString(Convert.ToDouble(TxtServicePersonProfitPer1.Text) + Convert.ToDouble(TxtServicePersonProfitPer2.Text) + Convert.ToDouble(TxtServicePersonProfitPer3.Text) + Convert.ToDouble(TxtServicePersonProfitPer4.Text) + Convert.ToDouble(TxtServicePersonProfitPer5.Text)).ToString();

                        TxtProfitTotalAmount.Text = Convert.ToString(Convert.ToDouble(TxtServicePersonProfitAmt1.Text) + Convert.ToDouble(TxtServicePersonProfitAmt2.Text) + Convert.ToDouble(TxtServicePersonProfitAmt3.Text) + Convert.ToDouble(TxtServicePersonProfitAmt4.Text) + Convert.ToDouble(TxtServicePersonProfitAmt5.Text)).ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtServicePersonProfitPer2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtProfitAmountJobMas.Text != string.Empty && TxtProfitAmountJobMas.Text != null)
                {
                    if (validation.ispercentage(TxtServicePersonProfitPer2.Text.Trim()))
                    {
                        TxtServicePersonProfitAmt2.Text = ((Convert.ToDouble(TxtProfitAmountJobMas.Text) * Convert.ToDouble(TxtServicePersonProfitPer2.Text)) / 100).ToString();
                        TxtServicePersonProfitAmt2.Enabled = false;

                        TxtServicePersonProfitPer2.BackColor = Color.White;
                    }

                    else
                    {
                        TxtServicePersonProfitPer2.Text = "0";
                        TxtServicePersonProfitPer2.BackColor = Color.Red;
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Percentage should be between 0 to 100..!!');", true);
                        TxtServicePersonProfitPer2.Focus();
                    }

                    if (TxtServicePersonProfitPer1.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer1.Text = "0";
                        TxtServicePersonProfitAmt1.Text = "0";
                    }
                    if (TxtServicePersonProfitPer2.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer2.Text = "0";
                        TxtServicePersonProfitAmt2.Text = "0";
                    }
                    if (TxtServicePersonProfitPer3.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer3.Text = "0";
                        TxtServicePersonProfitAmt3.Text = "0";
                    }
                    if (TxtServicePersonProfitPer4.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer4.Text = "0";
                        TxtServicePersonProfitAmt4.Text = "0";
                    }
                    if (TxtServicePersonProfitPer5.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer5.Text = "0";
                        TxtServicePersonProfitAmt5.Text = "0";
                    }

                    if (TxtServicePersonProfitPer2.Text != string.Empty)
                    {

                        TxtProfitTotalPercentage.Text = Convert.ToString(Convert.ToDouble(TxtServicePersonProfitPer1.Text) + Convert.ToDouble(TxtServicePersonProfitPer2.Text) + Convert.ToDouble(TxtServicePersonProfitPer3.Text) + Convert.ToDouble(TxtServicePersonProfitPer4.Text) + Convert.ToDouble(TxtServicePersonProfitPer5.Text)).ToString();

                        TxtProfitTotalAmount.Text = Convert.ToString(Convert.ToDouble(TxtServicePersonProfitAmt1.Text) + Convert.ToDouble(TxtServicePersonProfitAmt2.Text) + Convert.ToDouble(TxtServicePersonProfitAmt3.Text) + Convert.ToDouble(TxtServicePersonProfitAmt4.Text) + Convert.ToDouble(TxtServicePersonProfitAmt5.Text)).ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtServicePersonProfitPer3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtProfitAmountJobMas.Text != string.Empty && TxtProfitAmountJobMas.Text != null)
                {
                    if (validation.ispercentage(TxtServicePersonProfitPer3.Text.Trim()))
                    {
                        TxtServicePersonProfitAmt3.Text = ((Convert.ToDouble(TxtProfitAmountJobMas.Text) * Convert.ToDouble(TxtServicePersonProfitPer3.Text)) / 100).ToString();
                        TxtServicePersonProfitAmt3.Enabled = false;

                        TxtServicePersonProfitPer3.BackColor = Color.White;
                    }

                    else
                    {
                        TxtServicePersonProfitPer3.Text = "0";
                        TxtServicePersonProfitPer3.BackColor = Color.Red;
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Percentage should be between 0 to 100..!!');", true);
                        TxtServicePersonProfitPer3.Focus();
                    }

                    if (TxtServicePersonProfitPer1.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer1.Text = "0";
                        TxtServicePersonProfitAmt1.Text = "0";
                    }
                    if (TxtServicePersonProfitPer2.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer2.Text = "0";
                        TxtServicePersonProfitAmt2.Text = "0";
                    }
                    if (TxtServicePersonProfitPer3.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer3.Text = "0";
                        TxtServicePersonProfitAmt3.Text = "0";
                    }
                    if (TxtServicePersonProfitPer4.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer4.Text = "0";
                        TxtServicePersonProfitAmt4.Text = "0";
                    }
                    if (TxtServicePersonProfitPer5.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer5.Text = "0";
                        TxtServicePersonProfitAmt5.Text = "0";
                    }

                    if (TxtServicePersonProfitPer3.Text != string.Empty)
                    {
                        TxtProfitTotalPercentage.Text = Convert.ToString(Convert.ToDouble(TxtServicePersonProfitPer1.Text) + Convert.ToDouble(TxtServicePersonProfitPer2.Text) + Convert.ToDouble(TxtServicePersonProfitPer3.Text) + Convert.ToDouble(TxtServicePersonProfitPer4.Text) + Convert.ToDouble(TxtServicePersonProfitPer5.Text)).ToString();

                        TxtProfitTotalAmount.Text = Convert.ToString(Convert.ToDouble(TxtServicePersonProfitAmt1.Text) + Convert.ToDouble(TxtServicePersonProfitAmt2.Text) + Convert.ToDouble(TxtServicePersonProfitAmt3.Text) + Convert.ToDouble(TxtServicePersonProfitAmt4.Text) + Convert.ToDouble(TxtServicePersonProfitAmt5.Text)).ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtServicePersonProfitPer4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtProfitAmountJobMas.Text != string.Empty && TxtProfitAmountJobMas.Text != null)
                {
                    if (validation.ispercentage(TxtServicePersonProfitPer4.Text.Trim()))
                    {
                        TxtServicePersonProfitAmt4.Text = ((Convert.ToDouble(TxtProfitAmountJobMas.Text) * Convert.ToDouble(TxtServicePersonProfitPer4.Text)) / 100).ToString();
                        TxtServicePersonProfitAmt4.Enabled = false;

                        TxtServicePersonProfitPer4.BackColor = Color.White;
                    }

                    else
                    {
                        TxtServicePersonProfitPer4.Text = "0";
                        TxtServicePersonProfitPer4.BackColor = Color.Red;
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Percentage should be between 0 to 100..!!');", true);
                        TxtServicePersonProfitPer4.Focus();
                    }
                    if (TxtServicePersonProfitPer1.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer1.Text = "0";
                        TxtServicePersonProfitAmt1.Text = "0";
                    }
                    if (TxtServicePersonProfitPer2.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer2.Text = "0";
                        TxtServicePersonProfitAmt2.Text = "0";
                    }
                    if (TxtServicePersonProfitPer3.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer3.Text = "0";
                        TxtServicePersonProfitAmt3.Text = "0";
                    }
                    if (TxtServicePersonProfitPer4.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer4.Text = "0";
                        TxtServicePersonProfitAmt4.Text = "0";
                    }
                    if (TxtServicePersonProfitPer5.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer5.Text = "0";
                        TxtServicePersonProfitAmt5.Text = "0";
                    }

                    if (TxtServicePersonProfitPer4.Text != string.Empty)
                    {
                        TxtProfitTotalPercentage.Text = Convert.ToString(Convert.ToDouble(TxtServicePersonProfitPer1.Text) + Convert.ToDouble(TxtServicePersonProfitPer2.Text) + Convert.ToDouble(TxtServicePersonProfitPer3.Text) + Convert.ToDouble(TxtServicePersonProfitPer4.Text) + Convert.ToDouble(TxtServicePersonProfitPer5.Text)).ToString();

                        TxtProfitTotalAmount.Text = Convert.ToString(Convert.ToDouble(TxtServicePersonProfitAmt1.Text) + Convert.ToDouble(TxtServicePersonProfitAmt2.Text) + Convert.ToDouble(TxtServicePersonProfitAmt3.Text) + Convert.ToDouble(TxtServicePersonProfitAmt4.Text) + Convert.ToDouble(TxtServicePersonProfitAmt5.Text)).ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtServicePersonProfitPer5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtProfitAmountJobMas.Text != string.Empty && TxtProfitAmountJobMas.Text != null)
                {
                    if (validation.ispercentage(TxtServicePersonProfitPer5.Text.Trim()))
                    {
                        TxtServicePersonProfitAmt5.Text = ((Convert.ToDouble(TxtProfitAmountJobMas.Text) * Convert.ToDouble(TxtServicePersonProfitPer5.Text)) / 100).ToString();
                        TxtServicePersonProfitAmt5.Enabled = false;

                        TxtServicePersonProfitPer5.BackColor = Color.White;
                    }

                    else
                    {
                        TxtServicePersonProfitPer5.Text = "0";
                        TxtServicePersonProfitPer5.BackColor = Color.Red;
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Percentage should be between 0 to 100..!!');", true);
                        TxtServicePersonProfitPer5.Focus();
                    }

                    if (TxtServicePersonProfitPer1.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer1.Text = "0";
                        TxtServicePersonProfitAmt1.Text = "0";
                    }
                    if (TxtServicePersonProfitPer2.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer2.Text = "0";
                        TxtServicePersonProfitAmt2.Text = "0";
                    }
                    if (TxtServicePersonProfitPer3.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer3.Text = "0";
                        TxtServicePersonProfitAmt3.Text = "0";
                    }
                    if (TxtServicePersonProfitPer4.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer4.Text = "0";
                        TxtServicePersonProfitAmt4.Text = "0";
                    }
                    if (TxtServicePersonProfitPer5.Text == string.Empty)
                    {
                        TxtServicePersonProfitPer5.Text = "0";
                        TxtServicePersonProfitAmt5.Text = "0";
                    }

                    if (TxtServicePersonProfitPer5.Text != string.Empty)
                    {
                        TxtProfitTotalPercentage.Text = Convert.ToString(Convert.ToDouble(TxtServicePersonProfitPer1.Text) + Convert.ToDouble(TxtServicePersonProfitPer2.Text) + Convert.ToDouble(TxtServicePersonProfitPer3.Text) + Convert.ToDouble(TxtServicePersonProfitPer4.Text) + Convert.ToDouble(TxtServicePersonProfitPer5.Text)).ToString();

                        TxtProfitTotalAmount.Text = Convert.ToString(Convert.ToDouble(TxtServicePersonProfitAmt1.Text) + Convert.ToDouble(TxtServicePersonProfitAmt2.Text) + Convert.ToDouble(TxtServicePersonProfitAmt3.Text) + Convert.ToDouble(TxtServicePersonProfitAmt4.Text) + Convert.ToDouble(TxtServicePersonProfitAmt5.Text)).ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion




        #region ADD NEW ROW INTO LABOUR CHARGES GRID


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetChargesName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CHARGES where COMP_CODE=@COMP_CODE and NAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> ChargesNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargesNames.Add(dt.Rows[i][2].ToString());
            }
            return ChargesNames;
        }


        private void SetInitialRowLabourCharges()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("CCODE", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("RATE", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("LAB_DESC", typeof(string));
            table.Columns.Add("REMARK", typeof(string));
            table.Columns.Add("INS_USERID", typeof(string));
            table.Columns.Add("INS_DATE", typeof(string));
            table.Columns.Add("UPD_USERID", typeof(string));
            table.Columns.Add("UPD_DATE", typeof(string));
            //table.Columns.Add("GST_RATE", typeof(string));
            //table.Columns.Add("GST_AMT", typeof(string));
            //table.Columns.Add("CGST_RATE", typeof(string));
            //table.Columns.Add("CGST_AMT", typeof(string));
            //table.Columns.Add("SGST_RATE", typeof(string));
            //table.Columns.Add("SGST_AMT", typeof(string));
            //table.Columns.Add("IGST_RATE", typeof(string));
            //table.Columns.Add("IGST_AMT", typeof(string));
            //table.Columns.Add("T_AMT", typeof(string));



            dr = table.NewRow();


            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["CCODE"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["RATE"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["LAB_DESC"] = string.Empty;
            dr["REMARK"] = string.Empty;
            dr["INS_USERID"] = string.Empty;
            dr["INS_DATE"] = string.Empty;
            dr["UPD_USERID"] = string.Empty;
            dr["UPD_DATE"] = string.Empty;
            //dr["GST_RATE"] = string.Empty;
            //dr["GST_AMT"] = string.Empty;
            //dr["CGST_RATE"] = string.Empty;
            //dr["CGST_AMT"] = string.Empty;
            //dr["SGST_RATE"] = string.Empty;
            //dr["SGST_AMT"] = string.Empty;
            //dr["IGST_RATE"] = string.Empty;
            //dr["IGST_AMT"] = string.Empty;
            //dr["T_AMT"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["TableLabourCharges"] = table;

            GvLabourChagresDetails.DataSource = table;
            GvLabourChagresDetails.DataBind();

        }



        private void AddNewRowToLabourChargesGrid()
        {
            int rowIndex = 0;

            if (ViewState["TableLabourCharges"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["TableLabourCharges"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values 
                        //TextBox TxtSr = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtSr");

                        Label lblTotalChargesAmount = (Label)(GvLabourChagresDetails.FooterRow.FindControl("lblTotalChargesAmount"));

                        HiddenField HfCompCode = (HiddenField)GvLabourChagresDetails.Rows[rowIndex].Cells[0].FindControl("HfCompCode");
                        HiddenField HfTranDate = (HiddenField)GvLabourChagresDetails.Rows[rowIndex].Cells[0].FindControl("HfTranDate");
                        HiddenField HfTranNo = (HiddenField)GvLabourChagresDetails.Rows[rowIndex].Cells[0].FindControl("HfTranNo");
                        HiddenField HfSrNo = (HiddenField)GvLabourChagresDetails.Rows[rowIndex].Cells[0].FindControl("HfSrNo");
                        HiddenField HfChargesCode = (HiddenField)GvLabourChagresDetails.Rows[rowIndex].Cells[0].FindControl("HfChargesCode");

                        TextBox TxtChargesName = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[1].FindControl("TxtChargesName");
                        TextBox TxtChargesDescription = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[2].FindControl("TxtChargesDescription");
                        TextBox TxtQty = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[3].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[4].FindControl("TxtRate");
                        TextBox TxtChargesAmount = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[5].FindControl("TxtChargesAmount");
                        TextBox TxtRemarks = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[6].FindControl("TxtRemarks");


                        //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["CCODE"] = HfChargesCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = TxtChargesAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["LAB_DESC"] = TxtChargesDescription.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["REMARK"] = TxtRemarks.Text.Trim();

                        rowIndex++;

                        double SumTotalChargesAmt = TotalChargesAmount();
                        lblTotalChargesAmount.Text = SumTotalChargesAmt.ToString();
                        TxtTotalChargesAmt.Text = lblTotalChargesAmount.Text;
                        FillNetAmount();


                    }


                    drCurrentRow = dtCurrentTable.NewRow();

                    //drCurrentRow["SR"] = "";
                    //drCurrentRow["COMP_CODE"] = "0";
                    //drCurrentRow["TRAN_DATE"] = "";
                    //drCurrentRow["TRAN_NO"] = "0";
                    //drCurrentRow["SRNO"] = "0";
                    drCurrentRow["CCODE"] = "0";
                    drCurrentRow["LAB_DESC"] = "";
                    drCurrentRow["QTY"] = "0";
                    drCurrentRow["RATE"] = "0";
                    drCurrentRow["AMT"] = "0";
                    drCurrentRow["REMARK"] = "";
                    //drCurrentRow["INS_USERID"] = "";
                    //drCurrentRow["INS_DATE"] = "";
                    //drCurrentRow["UPD_USERID"] = "";
                    //drCurrentRow["UPD_DATE"] = "";



                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["TableLabourCharges"] = dtCurrentTable;

                    GvLabourChagresDetails.DataSource = dtCurrentTable;
                    GvLabourChagresDetails.DataBind();


                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousDataToLabourChargesGrid();
        }


        private void SetPreviousDataToLabourChargesGrid()
        {
            int rowIndex = 0;
            if (ViewState["TableLabourCharges"] != null)
            {
                DataTable dt = (DataTable)ViewState["TableLabourCharges"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Label lblTotalChargesAmount = (Label)(GvLabourChagresDetails.FooterRow.FindControl("lblTotalChargesAmount"));

                        HiddenField HfCompCode = (HiddenField)GvLabourChagresDetails.Rows[rowIndex].Cells[0].FindControl("HfCompCode");
                        HiddenField HfTranDate = (HiddenField)GvLabourChagresDetails.Rows[rowIndex].Cells[0].FindControl("HfTranDate");
                        HiddenField HfTranNo = (HiddenField)GvLabourChagresDetails.Rows[rowIndex].Cells[0].FindControl("HfTranNo");
                        HiddenField HfSrNo = (HiddenField)GvLabourChagresDetails.Rows[rowIndex].Cells[0].FindControl("HfSrNo");
                        HiddenField HfChargesCode = (HiddenField)GvLabourChagresDetails.Rows[rowIndex].Cells[0].FindControl("HfChargesCode");

                        TextBox TxtChargesName = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[1].FindControl("TxtChargesName");
                        TextBox TxtChargesDescription = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[2].FindControl("TxtChargesDescription");
                        TextBox TxtQty = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[3].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[4].FindControl("TxtRate");
                        TextBox TxtChargesAmount = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[5].FindControl("TxtChargesAmount");
                        TextBox TxtRemarks = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[6].FindControl("TxtRemarks");


                        HfChargesCode.Value = dt.Rows[i]["CCODE"].ToString();
                        TxtChargesDescription.Text = dt.Rows[i]["LAB_DESC"].ToString();
                        TxtQty.Text = dt.Rows[i]["QTY"].ToString();
                        TxtRate.Text = dt.Rows[i]["RATE"].ToString();
                        TxtChargesAmount.Text = dt.Rows[i]["AMT"].ToString();
                        TxtRemarks.Text = dt.Rows[i]["REMARK"].ToString();


                        rowIndex++;

                        double SumTotalChargesAmt = TotalChargesAmount();
                        lblTotalChargesAmount.Text = SumTotalChargesAmt.ToString();
                        TxtTotalChargesAmt.Text = lblTotalChargesAmount.Text;
                        FillNetAmount();


                    }
                }
            }
        }


        protected void BtnDeleteRowLabourChargesDetailGrid_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex + 1;
            if (ViewState["TableLabourCharges"] != null)
            {
                DataTable dt = (DataTable)ViewState["TableLabourCharges"];
                if (dt.Rows.Count > 1)
                {

                    if (gvRow.RowIndex <= dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data
                        dt.Rows.Remove(dt.Rows[rowID - 1]);
                    }
                }
                //Store the current data in ViewState for future reference
                ViewState["TableLabourCharges"] = dt;
                //Re bind the GridView for the updated data
                GvLabourChagresDetails.DataSource = dt;
                GvLabourChagresDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousDataToLabourChargesGrid();
        }

        protected void BtnAddRowLabourChargesDetailGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToLabourChargesGrid();
        }


        protected void TxtChargesName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfChargesCode = (HiddenField)row.Cells[0].FindControl("HfChargesCode");
                TextBox TxtChargesName = (TextBox)row.Cells[1].FindControl("TxtChargesName");
                TextBox TxtQty = (TextBox)row.Cells[3].FindControl("TxtQty");


                DataTable DtChargesName = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtChargesName = CHARGES_MASLogicLayer.GetAllCHARGESDetialsForComapnyWise_DDL(Comp_Code);
                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtChargesName);
                    Dv.RowFilter = "NAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfChargesCode.Value = DtView.Rows[0]["CCODE"].ToString();

                        FillOnGridChargesDetailChanged();

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void TxtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtRateString = (TextBox)row.Cells[5].FindControl("TxtRate");
                TextBox TxtChargesAmount = (TextBox)row.Cells[6].FindControl("TxtChargesAmount");

                Label lblTotalChargesAmount = (Label)(GvLabourChagresDetails.FooterRow.FindControl("lblTotalChargesAmount"));

                if (TxtRateString.Text == string.Empty)
                {
                    TxtRateString.Text = "0";
                }

                if (txt.Text.Trim() != string.Empty && TxtRateString.Text.Trim() != string.Empty)
                {
                    TxtChargesAmount.Text = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtRateString.Text.Trim()));

                }


                FillOnGridChargesDetailChanged();

                double SumTotalChargesAmt = TotalChargesAmount();
                lblTotalChargesAmount.Text = SumTotalChargesAmt.ToString();
                TxtTotalChargesAmt.Text = lblTotalChargesAmount.Text;
                FillNetAmount();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    TextBox txt = (TextBox)sender;
                    GridViewRow row = (GridViewRow)txt.Parent.Parent;
                    int idx = row.RowIndex;

                    TextBox TxtQtyString = (TextBox)row.Cells[4].FindControl("TxtQty");
                    TextBox TxtChargesAmount = (TextBox)row.Cells[6].FindControl("TxtChargesAmount");

                    Label lblTotalChargesAmount = (Label)(GvLabourChagresDetails.FooterRow.FindControl("lblTotalChargesAmount"));


                    if (TxtQtyString.Text == string.Empty)
                    {
                        TxtQtyString.Text = "0";
                    }

                    if (txt.Text.Trim() != string.Empty && TxtQtyString.Text.Trim() != string.Empty)
                    {
                        TxtChargesAmount.Text = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtQtyString.Text.Trim()));

                    }


                    FillOnGridChargesDetailChanged();
                    double SumTotalChargesAmt = TotalChargesAmount();
                    lblTotalChargesAmount.Text = SumTotalChargesAmt.ToString();
                    TxtTotalChargesAmt.Text = lblTotalChargesAmount.Text;
                    FillNetAmount();

                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillOnGridChargesDetailChanged()
        {
            try
            {
                #region Assign To Labour Charges Grid Into Table

                int rowIndex = 0;

                if (ViewState["TableLabourCharges"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["TableLabourCharges"];

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //extract the TextBox values 
                            //TextBox TxtSr = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtSr");

                            HiddenField HfCompCode = (HiddenField)GvLabourChagresDetails.Rows[rowIndex].Cells[0].FindControl("HfCompCode");
                            HiddenField HfTranDate = (HiddenField)GvLabourChagresDetails.Rows[rowIndex].Cells[0].FindControl("HfTranDate");
                            HiddenField HfTranNo = (HiddenField)GvLabourChagresDetails.Rows[rowIndex].Cells[0].FindControl("HfTranNo");
                            HiddenField HfSrNo = (HiddenField)GvLabourChagresDetails.Rows[rowIndex].Cells[0].FindControl("HfSrNo");
                            HiddenField HfChargesCode = (HiddenField)GvLabourChagresDetails.Rows[rowIndex].Cells[0].FindControl("HfChargesCode");

                            TextBox TxtChargesName = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[1].FindControl("TxtChargesName");
                            TextBox TxtChargesDescription = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[2].FindControl("TxtChargesDescription");
                            TextBox TxtQty = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[3].FindControl("TxtQty");
                            TextBox TxtRate = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[4].FindControl("TxtRate");
                            TextBox TxtChargesAmount = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[5].FindControl("TxtChargesAmount");
                            TextBox TxtRemarks = (TextBox)GvLabourChagresDetails.Rows[rowIndex].Cells[6].FindControl("TxtRemarks");


                            //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["CCODE"] = HfChargesCode.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["AMT"] = TxtChargesAmount.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["LAB_DESC"] = TxtChargesDescription.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["REMARK"] = TxtRemarks.Text.Trim();




                            rowIndex++;

                        }
                    }
                }

                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvLabourChagresDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    HiddenField HfChargesCode = (e.Row.FindControl("HfChargesCode") as HiddenField);

                    TextBox TxtChargesName = (e.Row.FindControl("TxtChargesName") as TextBox);


                    DataTable DtChargesName = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();

                    DtChargesName = CHARGES_MASLogicLayer.GetAllCHARGESDetialsForComapnyWise_DDL(Comp_Code);

                    if (HfChargesCode.Value != "0" && HfChargesCode.Value != string.Empty)
                    {
                        DataView Dv = new DataView(DtChargesName);
                        Dv.RowFilter = "CCODE=" + HfChargesCode.Value;
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            TxtChargesName.Text = DtView.Rows[0]["NAME"].ToString();
                            HfChargesCode.Value = DtView.Rows[0]["CCODE"].ToString();

                        }
                        else
                        {
                            TxtChargesName.Text = string.Empty;
                            HfChargesCode.Value = string.Empty;
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        private double TotalChargesAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvLabourChagresDetails.Rows.Count; i++)
            {
                string total = (GvLabourChagresDetails.Rows[i].FindControl("TxtChargesAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }


        protected void TxtProfitPercentageJobMas_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (TxtNetAmt.Text != string.Empty && TxtNetAmt.Text != null)
                {
                    if (validation.ispercentage(TxtProfitPercentageJobMas.Text.Trim()))
                    {
                        TxtProfitAmountJobMas.Text = ((Convert.ToDouble(TxtNetAmt.Text) * Convert.ToDouble(TxtProfitPercentageJobMas.Text)) / 100).ToString();
                        // TxtProfitAmountJobMas.Enabled = false;

                        TxtProfitPercentageJobMas.BackColor = Color.White;
                    }

                    else
                    {
                        TxtProfitPercentageJobMas.Text = "0";
                        TxtProfitPercentageJobMas.BackColor = Color.Red;
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Percentage should be between 0 to 100..!!');", true);
                        TxtProfitPercentageJobMas.Focus();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region FETCH DATA INTO SERVICE DETAILS GRID


        private void SetInitialRowServiceDetails()
        {
            DataTable table = new DataTable();
            DataRow dr = null;

            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("BRANDTYPE_CODE", typeof(string));
            table.Columns.Add("BRANDTYPE_SRNO", typeof(string));
            table.Columns.Add("RESULT_FLAG_1_1", typeof(string));
            table.Columns.Add("RESULT_FLAG_2_1", typeof(string));
            table.Columns.Add("RESULT_FLAG_3_1", typeof(string));
            table.Columns.Add("REMARK", typeof(string));
            table.Columns.Add("INS_USERID", typeof(string));
            table.Columns.Add("INS_DATE", typeof(string));
            table.Columns.Add("UPD_USERID", typeof(string));
            table.Columns.Add("UPD_DATE", typeof(string));
            table.Columns.Add("RESULT_FLAG_1_2", typeof(string));
            table.Columns.Add("RESULT_FLAG_2_2", typeof(string));
            table.Columns.Add("RESULT_FLAG_3_2", typeof(string));

            table.Columns.Add("DESC_NAME", typeof(string));
            table.Columns.Add("RESULT_1_1", typeof(string));
            table.Columns.Add("RESULT_1_2", typeof(string));
            table.Columns.Add("RESULT_2_1", typeof(string));
            table.Columns.Add("RESULT_2_2", typeof(string));
            table.Columns.Add("RESULT_3_1", typeof(string));
            table.Columns.Add("RESULT_3_2", typeof(string));
            table.Columns.Add("PRINT_FLAG_1", typeof(string));
            table.Columns.Add("PRINT_FLAG_2", typeof(string));
            table.Columns.Add("PRINT_FLAG_3", typeof(string));


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["BRANDTYPE_CODE"] = string.Empty;
            dr["BRANDTYPE_SRNO"] = string.Empty;
            dr["RESULT_FLAG_1_1"] = "false";
            dr["RESULT_FLAG_2_1"] = "false";
            dr["RESULT_FLAG_3_1"] = "false";
            dr["REMARK"] = string.Empty;
            dr["INS_USERID"] = string.Empty;
            dr["INS_DATE"] = string.Empty;
            dr["UPD_USERID"] = string.Empty;
            dr["UPD_DATE"] = string.Empty;
            dr["RESULT_FLAG_1_2"] = "false";
            dr["RESULT_FLAG_2_2"] = "false";
            dr["RESULT_FLAG_3_2"] = "false";

            dr["DESC_NAME"] = string.Empty;
            dr["RESULT_1_1"] = string.Empty;
            dr["RESULT_1_2"] = string.Empty;
            dr["RESULT_2_1"] = string.Empty;
            dr["RESULT_2_2"] = string.Empty;
            dr["RESULT_3_1"] = string.Empty;
            dr["RESULT_3_2"] = string.Empty;
            dr["PRINT_FLAG_1"] = string.Empty;
            dr["PRINT_FLAG_2"] = string.Empty;
            dr["PRINT_FLAG_3"] = string.Empty;

            table.Rows.Add(dr);

            ViewState["TableServiceDetails"] = table;

            GvServiceDetail.DataSource = table;
            GvServiceDetail.DataBind();
        }



        protected void CheckBoxOption1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox txt = (CheckBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                CheckBox CheckBoxOption1 = (CheckBox)row.Cells[3].FindControl("CheckBoxOption1");
                CheckBox CheckBoxOption2 = (CheckBox)row.Cells[5].FindControl("CheckBoxOption2");

                if (CheckBoxOption1.Checked == true)
                {
                    CheckBoxOption2.Checked = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void CheckBoxOption2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox txt = (CheckBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                CheckBox CheckBoxOption1 = (CheckBox)row.Cells[3].FindControl("CheckBoxOption1");
                CheckBox CheckBoxOption2 = (CheckBox)row.Cells[5].FindControl("CheckBoxOption2");

                if (CheckBoxOption2.Checked == true)
                {
                    CheckBoxOption1.Checked = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void CheckBoxChecking1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox txt = (CheckBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                CheckBox CheckBoxChecking1 = (CheckBox)row.Cells[8].FindControl("CheckBoxChecking1");
                CheckBox CheckBoxChecking2 = (CheckBox)row.Cells[10].FindControl("CheckBoxChecking2");

                if (CheckBoxChecking1.Checked == true)
                {
                    CheckBoxChecking2.Checked = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void CheckBoxChecking2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox txt = (CheckBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                CheckBox CheckBoxChecking1 = (CheckBox)row.Cells[8].FindControl("CheckBoxChecking1");
                CheckBox CheckBoxChecking2 = (CheckBox)row.Cells[10].FindControl("CheckBoxChecking2");

                if (CheckBoxChecking2.Checked == true)
                {
                    CheckBoxChecking1.Checked = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void CheckBoxRemark1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox txt = (CheckBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                CheckBox CheckBoxRemark1 = (CheckBox)row.Cells[13].FindControl("CheckBoxRemark1");
                CheckBox CheckBoxRemark2 = (CheckBox)row.Cells[15].FindControl("CheckBoxRemark2");

                if (CheckBoxRemark1.Checked == true)
                {
                    CheckBoxRemark2.Checked = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void CheckBoxRemark2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox txt = (CheckBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                CheckBox CheckBoxRemark1 = (CheckBox)row.Cells[13].FindControl("CheckBoxRemark1");
                CheckBox CheckBoxRemark2 = (CheckBox)row.Cells[15].FindControl("CheckBoxRemark2");

                if (CheckBoxRemark2.Checked == true)
                {
                    CheckBoxRemark1.Checked = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillServiceDetailsGrid()
        {
            DataTable Dt = new DataTable();
            Dt = STOCK_BRANDTYPEMASLogicLayer.GetStockBrandTypeMasterDetailFilterByBrandTypeCode(Session["COMP_CODE"].ToString(), HfBrandTypeCode.Value.ToString());
            GvServiceDetail.DataSource = Dt;
            GvServiceDetail.DataBind();
        }

        protected void BtnFetchServiceData_Click(object sender, EventArgs e)
        {
            if (HfBrandTypeCode.Value != string.Empty)
            {
                FillServiceDetailsGrid();
            }

        }


        protected void GvServiceDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //if(e.Row.RowType==DataControlRowType.DataRow)
                //{
                //    CheckBox CheckBoxOption1 = (e.Row.FindControl("CheckBoxOption1") as CheckBox);
                //    CheckBox CheckBoxOption2 = (e.Row.FindControl("CheckBoxOption2") as CheckBox);
                //    CheckBox CheckBoxChecking1 = (e.Row.FindControl("CheckBoxChecking1") as CheckBox);
                //    CheckBox CheckBoxChecking2 = (e.Row.FindControl("CheckBoxChecking2") as CheckBox);
                //    CheckBox CheckBoxRemark1 = (e.Row.FindControl("CheckBoxRemark1") as CheckBox);
                //    CheckBox CheckBoxRemark2 = (e.Row.FindControl("CheckBoxRemark2") as CheckBox);

                //    DataSet Ds = JOBCARD_MASLogicLayer.GetAllIDWiseJOBCARD_MASTERDetials(HfTranNo.Value.ToString(), Convert.ToDateTime(HfTranDate.Value));
                //    DataTable DtService = Ds.Tables[2];
                //    if (DtService.Rows[0]["RESULT_FLAG_1_1"].ToString()=="Y")
                //    {
                //        CheckBoxOption1.Checked = true;
                //    }
                //    else
                //    {
                //        CheckBoxOption1.Checked = false;
                //    }

                //    if (DtService.Rows[0]["RESULT_FLAG_2_1"].ToString() == "Y")
                //    {
                //        CheckBoxOption2.Checked = true;
                //    }
                //    else
                //    {
                //        CheckBoxOption2.Checked = false;
                //    }

                //}


            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region FETCH DATA INTO SERVICE USED ITEM GRID


        private void SetInitialRowServiceUseItem()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("REF_TRAN_DATE", typeof(string));
            table.Columns.Add("REF_TRAN_NO", typeof(string));
            table.Columns.Add("REF_SRNO", typeof(string));
            table.Columns.Add("QTY", typeof(string));

            table.Columns.Add("sname", typeof(string));
            table.Columns.Add("prod_code", typeof(string));
            table.Columns.Add("cha_dt", typeof(string));
            table.Columns.Add("cha_no", typeof(string));
            table.Columns.Add("qty", typeof(string));
            table.Columns.Add("ret_qty", typeof(string));
            table.Columns.Add("use_qty", typeof(string));
            table.Columns.Add("bal_qty", typeof(string));




            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["SCODE"] = string.Empty;
            dr["REF_TRAN_DATE"] = string.Empty;
            dr["REF_TRAN_NO"] = string.Empty;
            dr["REF_SRNO"] = string.Empty;
            dr["QTY"] = string.Empty;

            dr["sname"] = string.Empty;
            dr["prod_code"] = string.Empty;
            dr["cha_dt"] = string.Empty;
            dr["cha_no"] = string.Empty;
            dr["qty"] = string.Empty;
            dr["ret_qty"] = string.Empty;
            dr["use_qty"] = string.Empty;
            dr["bal_qty"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["TableServiceUseItem"] = table;

            GvServiceUseItem.DataSource = table;
            GvServiceUseItem.DataBind();
        }


        public void FillServiceUseItemsGrid()
        {
            DataTable Dt = new DataTable();
            Dt = PARTY_STOCK_MASLogicLayer.GetPartyStockMasterDetailsFilterByACODE(Session["COMP_CODE"].ToString(), HfACODE.Value.ToString());
            GvServiceUseItem.DataSource = Dt;
            GvServiceUseItem.DataBind();
        }

        protected void BtnFetchServiceUseItem_Click(object sender, EventArgs e)
        {
            if (HfACODE.Value != string.Empty)
            {
                FillServiceUseItemsGrid();
            }
        }



        #endregion



        #region  GENERATE SERVICE BILL

        public void FillServiceBillDetail()
        {
            DataTable dt = new DataTable();
            dt = JOBCARD_MASLogicLayer.GetIDWiseJOBCARD_MASForServiceBillDetails(HfTranNo.Value.ToString(), Convert.ToDateTime(HfTranDate.Value.ToString()));
            if (dt.Rows.Count > 0)
            {
                TxtInvoiceNo.Text = dt.Rows[0]["INV_NUMBER"].ToString();
                TxtInvoiceTime.Text = dt.Rows[0]["INV_TIME"].ToString();
                TxtInvoiceDate.Text = dt.Rows[0]["INV_DATE"].ToString();
                HfRef_TranDate.Value= dt.Rows[0]["REF_TRAN_DATE"].ToString();
                HfRef_TranNo.Value = dt.Rows[0]["REF_TRAN_NO"].ToString();
            }
            else
            {
                TxtInvoiceNo.Text = string.Empty;
                TxtInvoiceTime.Text = string.Empty;
                TxtInvoiceDate.Text = string.Empty;
                HfRef_TranDate.Value = string.Empty;
                HfRef_TranNo.Value = string.Empty;
            }

        }

        protected void BtnGenerateBill_Click(object sender, EventArgs e)
        {
            try
            {


                #region XML FOR JOBCARD MASTER DETAILS

                XmlDocument XDoc_JobcardMaster = new XmlDocument();
                XmlDeclaration dec = XDoc_JobcardMaster.CreateXmlDeclaration("1.0", null, null);
                XDoc_JobcardMaster.AppendChild(dec);// Create the root element
                XmlElement root = XDoc_JobcardMaster.CreateElement("root");
                XDoc_JobcardMaster.AppendChild(root);


                XmlElement HandleDetail = XDoc_JobcardMaster.CreateElement("JOBCARD_MASDetails");
                HandleDetail.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                HandleDetail.SetAttribute("BRANCH_CODE", Session["BRANCH_CODE"].ToString());
                HandleDetail.SetAttribute("TRAN_DATE", Convert.ToDateTime(HfTranDate.Value.Trim().ToString()).ToString("yyyy-MM-dd"));
                HandleDetail.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                HandleDetail.SetAttribute("JOBCARD_NO", TxtJobCardNo.Text.Trim());
                HandleDetail.SetAttribute("JOBCARD_DATE", TxtJobCardDate.Text.Trim());
                HandleDetail.SetAttribute("JOBCARD_TIME", TxtJobCardTime.Text.Trim());
                HandleDetail.SetAttribute("ACODE", HfACODE.Value.Trim());

                if (HfRef_TranNo.Value.Trim() != string.Empty)
                {
                    HandleDetail.SetAttribute("REF_TRAN_NO", HfRef_TranNo.Value.Trim());
                }
                if (HfRef_TranDate.Value.Trim() != string.Empty)
                {
                     HandleDetail.SetAttribute("REF_TRAN_DATE", Convert.ToDateTime(HfRef_TranDate.Value.Trim().ToString()).ToString("yyyy-MM-dd"));
                }

                if (HfAMC_TRAN_NO.Value.Trim() != string.Empty)
                {
                    HandleDetail.SetAttribute("AMC_TRAN_NO", HfAMC_TRAN_NO.Value.Trim());
                }
                if (HfAMC_TRAN_DATE.Value.Trim() != string.Empty)
                {
                    HandleDetail.SetAttribute("AMC_TRAN_DATE", Convert.ToDateTime(HfAMC_TRAN_DATE.Value.Trim().ToString()).ToString("yyyy-MM-dd"));
                }
                if (HfAMC_SRNO.Value.Trim() != string.Empty)
                {
                    HandleDetail.SetAttribute("AMC_SRNO", HfAMC_SRNO.Value.Trim());
                }

                //  HandleDetail.SetAttribute("REF_TRAN_NO", HfRef_TranNo.Value.Trim()!=string.Empty ? HfRef_TranNo.Value.Trim():"0");
                //    HandleDetail.SetAttribute("REF_TRAN_DATE", HfRef_TranDate.Value.Trim() != string.Empty ? Convert.ToDateTime(HfRef_TranDate.Value.Trim().ToString()).ToString("yyyy-MM-dd") : DBNull.Value.ToString());
                //    HandleDetail.SetAttribute("REF_TRAN_DATE", HfRef_TranDate.Value.Trim().ToString());

                //HandleDetail.SetAttribute("REF_TRAN_DATE",null);
                //HandleDetail.SetAttribute("REF_TRAN_NO", null);
                //HandleDetail.SetAttribute("GROSS_AMT", null);
                //HandleDetail.SetAttribute("EX_DUTY_PER", null);
                //HandleDetail.SetAttribute("EX_DUTY_AMT", null);
                //HandleDetail.SetAttribute("EX_CESS_PER", null);
                //HandleDetail.SetAttribute("EX_CESS_AMT", null);
                //HandleDetail.SetAttribute("EX_SHCESS_PER", null);
                //HandleDetail.SetAttribute("EX_SHCESS_AMT", null);
                //HandleDetail.SetAttribute("INV_DATE", null);
                //HandleDetail.SetAttribute("INV_TIME", null);

                HandleDetail.SetAttribute("RO_AMT", (TxtROamt.Text.Trim() == string.Empty ? "0" : TxtROamt.Text.Trim()));
                HandleDetail.SetAttribute("NET_AMT", (TxtNetAmt.Text.Trim() == string.Empty ? "0" : TxtNetAmt.Text.Trim()));
                HandleDetail.SetAttribute("REMARK", TxtRemark.Text.Trim());
                HandleDetail.SetAttribute("ASSIGN_BCODE", HfJobAssignPersonName.Value.Trim());
                HandleDetail.SetAttribute("CLOSE_FLAG", DdlClosed.SelectedValue.Trim());

                root.AppendChild(HandleDetail);

                #endregion

                #region XML FOR SERVICE LABOURS CHARGES GRID

                XmlDocument XDoc_LabourCharges = new XmlDocument();
                XmlDeclaration dec5 = XDoc_LabourCharges.CreateXmlDeclaration("1.0", null, null);
                XDoc_LabourCharges.AppendChild(dec5);// Create the root element
                XmlElement root5 = XDoc_LabourCharges.CreateElement("root");
                XDoc_LabourCharges.AppendChild(root5);
                int ChargesSRNO = 1;

                foreach (GridViewRow row in GvLabourChagresDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                        HiddenField HfTranNo = row.FindControl("HfTranNo") as HiddenField;
                        HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                        HiddenField HfChargesCode = row.FindControl("HfChargesCode") as HiddenField;

                        TextBox TxtChargesDescription = row.FindControl("TxtChargesDescription") as TextBox;
                        TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                        TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                        TextBox TxtChargesAmount = row.FindControl("TxtChargesAmount") as TextBox;
                        TextBox TxtRemarks = row.FindControl("TxtRemarks") as TextBox;



                        if (HfChargesCode.Value != "0" && HfChargesCode.Value != string.Empty && HfChargesCode.Value != null)
                        {


                            XmlElement HandleDetail5 = XDoc_LabourCharges.CreateElement("JOBCARD_LAB_CHARGEDetails");
                            HandleDetail5.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                            HandleDetail5.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail5.SetAttribute("TRAN_DATE", Convert.ToDateTime(HfTranDate.Value.Trim().ToString()).ToString("yyyy-MM-dd"));
                            HandleDetail5.SetAttribute("SR", ChargesSRNO.ToString());
                            HandleDetail5.SetAttribute("CCODE", HfChargesCode.Value.Trim());
                            HandleDetail5.SetAttribute("LAB_DESC", TxtChargesDescription.Text.Trim());
                            if (TxtQty.Text == string.Empty)
                            {
                                HandleDetail5.SetAttribute("QTY", "0");
                            }
                            else
                            {
                                HandleDetail5.SetAttribute("QTY", TxtQty.Text.Trim());
                            }

                            if (TxtRate.Text == string.Empty)
                            {
                                HandleDetail5.SetAttribute("PER", "0");
                            }
                            else
                            {
                                HandleDetail5.SetAttribute("PER", TxtRate.Text.Trim());
                            }

                            if (TxtChargesAmount.Text == string.Empty)
                            {
                                HandleDetail5.SetAttribute("AMT", "0");
                            }
                            else
                            {
                                HandleDetail5.SetAttribute("AMT", TxtChargesAmount.Text.Trim());
                            }


                            //HandleDetail5.SetAttribute("ST_PER", null);
                            //HandleDetail5.SetAttribute("ST_AMT", null);
                            //HandleDetail5.SetAttribute("ADD_ST_PER", null);
                            //HandleDetail5.SetAttribute("ADD_ST_AMT", null);
                            //HandleDetail5.SetAttribute("T_AMT", null);
                            //HandleDetail5.SetAttribute("GST_RATE", null);
                            //HandleDetail5.SetAttribute("GST_AMT", null);
                            //HandleDetail5.SetAttribute("CGST_RATE", null);
                            //HandleDetail5.SetAttribute("CGST_AMT", null);
                            //HandleDetail5.SetAttribute("SGST_RATE", null);
                            //HandleDetail5.SetAttribute("SGST_AMT", null);
                            //HandleDetail5.SetAttribute("IGST_RATE", null);
                            //HandleDetail5.SetAttribute("GST_AMT", null);
                            //HandleDetail5.SetAttribute("HSN_NO", null);

                            root5.AppendChild(HandleDetail5);
                            ChargesSRNO++;
                        }
                    }
                }

                #endregion

                string str = JOBCARD_MASLogicLayer.jobcard_mas_with_rec_iss_m(validation.RSC(XDoc_JobcardMaster.OuterXml), (validation.RSC(XDoc_LabourCharges.OuterXml)), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).ToString("yyyy-MM-dd"), Session["USERCODE"].ToString());

                if (str.Contains("Successfully"))
                {
                    //lblmsg.Text = str;
                    FillServiceBillDetail();
                    //lblmsg.ForeColor = Color.Green;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + str + "');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + str + "');", true);
                    // lblmsg.Text = str;
                    // lblmsg.ForeColor = Color.Red;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnViewRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtInvoiceNo.Text == string.Empty || TxtInvoiceNo.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error..Service Bill is not generated.!!');", true);

                }
                else
                {
                    string TRAN_NO = HttpUtility.UrlEncode(encrypt(HfTranNo.Value.ToString()));
                    string TRAN_DATE = HttpUtility.UrlEncode(encrypt(Convert.ToDateTime(HfTranDate.Value.ToString()).ToString("yyyy-MM-dd")));

                    if (btnSave.Visible == true)
                    {
                        Response.Write("<script>window.open ('ServiceInvoiceBill.aspx?TRAN_DATE=" + TRAN_DATE + "&TRAN_NO=" + TRAN_NO + "', '_blank');</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.open ('ServiceInvoiceBill.aspx?TRAN_DATE=" + TRAN_DATE + "&TRAN_NO=" + TRAN_NO + "&Flag=1', '_blank');</script>");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (HfRef_TranNo.Value != string.Empty && HfRef_TranDate.Value != string.Empty)
                {

                    #region  DELETE  SERVICE BILL
                    string str = REC_ISS_MLogicLayer.DeleteREC_ISS_M_DetailByIDForJobacard(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value));
                    if (str.Contains("successfully"))
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Service Bill is Deleted.!!');", true);

                        TxtInvoiceNo.Text = string.Empty;
                        TxtInvoiceTime.Text = string.Empty;
                        TxtInvoiceDate.Text = string.Empty;
                        HfRef_TranNo.Value = string.Empty;
                        HfRef_TranDate.Value = string.Empty;

                    }
                    else if (str.Contains("Cannot"))
                    {
                        lblmsg.Text = "Cannot Delete This Record It Used by Other Data";
                        lblmsg.ForeColor = Color.Red;
                    }


                    else
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Service Bill is Not Deleted.!!');", true);
                    }



                    #endregion
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Service Bill Not Exist.!!');", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        protected void DdlClosed_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (DdlClosed.SelectedValue == "Y")
                {
                    TxtClosedBy.Text = Session["USERNAME"].ToString();
                    TxtClosedDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                    BtnGenerateBill.Enabled = true;

                }
                else
                {
                    TxtClosedBy.Text = "";
                    TxtClosedDate.Text = "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvJobCardMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btnedit = (e.Row.FindControl("btnEdit") as Button);
                    Button btndelete = (e.Row.FindControl("btnDelete") as Button);
                    Label lblClosedFlag = (e.Row.FindControl("lblClosedFlag") as Label);

                    HiddenField hfREC_UPD = (e.Row.FindControl("hfREC_UPD") as HiddenField);
                    HiddenField hfREC_DEL = (e.Row.FindControl("hfREC_DEL") as HiddenField);
                    HiddenField hfREC_INS = (e.Row.FindControl("hfREC_INS") as HiddenField);



                    if (hfREC_INS.Value.ToString() == "Y")
                    {
                        BtnAdd.Enabled = true;
                    }
                    else
                    {
                        BtnAdd.Enabled = false;
                    }

                    if (hfREC_UPD.Value.ToString() == "Y")
                    {


                        if (lblClosedFlag.Text == "YES")
                        {
                            if (Session["USERTYPE"].ToString() == "A")
                            {
                                btnedit.Enabled = true;

                            }
                            else
                            {
                                btnedit.Enabled = false;

                            }
                        }
                    }

                    if (hfREC_DEL.Value.ToString() == "Y")
                    {


                        if (lblClosedFlag.Text == "YES")
                        {
                            if (Session["USERTYPE"].ToString() == "A")
                            {

                                btndelete.Enabled = true;
                            }
                            else
                            {

                                btndelete.Enabled = false;
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {

                Response.AppendToLog(ex.ToString());
            }
        }


        public void FillJOBCARDAssignLogName()
        {
            DataTable dt = new DataTable();
            dt = jobcard_assign_logLogicLayer.GetJOBCARD_ASSIGN_LOGDetailsForGrid(HfTranNo.Value.ToString(), Convert.ToDateTime(HfTranDate.Value.ToString()));
            GvJobardAssignPerson.DataSource = dt;
            GvJobardAssignPerson.DataBind();
        }

        protected void BtnViewAssignLog_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelAssignPersonsName", "ShowModelAssignPersonsName()", true);

            FillJOBCARDAssignLogName();
        }

        protected void BtnViewAMC_Click(object sender, EventArgs e)
        {
            // Response.Redirect("~/Admin/AMC_Confirmation.aspx");

            try
            {

                string JOBCARDMASTER = HttpUtility.UrlEncode(encrypt("JCM"));
                string AMCTYPE = HttpUtility.UrlEncode(encrypt("A"));

                if (btnSave.Visible == true)
                {
                    Response.Write("<script>window.open ('AMC_Confirmation.aspx?JOBCARD=" + JOBCARDMASTER + "&AMCTYPE=" + AMCTYPE + "', '_blank');</script>");
                }
                else
                {
                    Response.Write("<script>window.open ('AMC_Confirmation.aspx?JOBCARD=" + JOBCARDMASTER + "&AMCTYPE=" + AMCTYPE + " &Flag=1', '_blank');</script>");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnViewInvoice_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../reportviewPages/JobCardServiceBillInvoice.aspx', '_blank');", true);
        }
    }
}

