using MihirValid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class EmployeeSalaryTransaction : System.Web.UI.Page
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

                if (!Page.IsPostBack)
                {
                    DivEntry.Visible = false;
                    DivView.Visible = true;
                    SetInitialRow();
                    FillSALARY_MasterGrid(Session["COMP_CODE"].ToString());
                    //   FillBranchName();
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
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
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

            HfCompCode.Value = string.Empty;
            HfBranchCode.Value = string.Empty;
            HfTranDate.Value = string.Empty;
            HfTranNo.Value = string.Empty;

            TxtSalaryDate.Text = string.Empty;
            TxtSalaryMonth.Text = string.Empty;
            TxtWorkingDays.Text = string.Empty;
            TxtWorkingHours.Text = string.Empty;
            TxtOTRate.Text = string.Empty;
            TxtOTHours.Text = string.Empty;
            TxtRemark.Text = string.Empty;
            TxtBranchName.Text = string.Empty;
            TxtAllowRate.Text = string.Empty;
            TxtAllowHours.Text = string.Empty;
            TxtPFRate.Text = string.Empty;
            TxtFPFAmount.Text = string.Empty;
            TxtESICRateComp.Text = string.Empty;
            TxtESICRateEmp.Text = string.Empty;
            DdlConfirmFlag.SelectedValue = "N";
            TxtConfirmBy.Text = string.Empty;
            TxtConfirmDate.Text = string.Empty;
            DdlApprovalFlag.SelectedValue = "N";
            TxtApprovalBy.Text = string.Empty;
            TxtApprovalDate.Text = string.Empty;

            TxtPresentDays.Text = string.Empty;
            TxtTotalHours.Text = string.Empty;
            TxtOTHours.Text = string.Empty;
            TxtODHours.Text = string.Empty;
            TxtBasicRate.Text = string.Empty;
            TxtConvRate.Text = string.Empty;
            TxtMedicalRate.Text = string.Empty;
            TxtHRARate.Text = string.Empty;
            TxtBasicAmt.Text = string.Empty;
            TxtConvAmt.Text = string.Empty;
            TxtOTAmt.Text = string.Empty;
            TxtODAmt.Text = string.Empty;
            TxtMedicalAmt.Text = string.Empty;
            TxtHRAAmt.Text = string.Empty;
            TxtAllowanceAmt.Text = string.Empty;
            TxtTotalGrossAmt.Text = string.Empty;
            TxtLoanAmt.Text = string.Empty;
            TxtAdvanceAmt.Text = string.Empty;
            TxtPFAmount.Text = string.Empty;
            TxtFPFAmount.Text = string.Empty;
            TxtESICAmountCompany.Text = string.Empty;
            TxtESICAmountEmployee.Text = string.Empty;
            TxtITAmount.Text = string.Empty;
            TxtTotalLessAmount.Text = string.Empty;
            TxtNetSalaryAmount.Text = string.Empty;
            TxtPaySalaryAmount.Text = string.Empty;

            lblEmployeeName.Text = string.Empty;

            SetInitialRow();

            BtncallUpd.Text = "SAVE";
        }


        public void ClearSalaryTransaction()
        {
            TxtPresentDays.Text = string.Empty;
            TxtTotalHours.Text = string.Empty;
            TxtOTHours.Text = string.Empty;
            TxtODHours.Text = string.Empty;
            TxtBasicRate.Text = string.Empty;
            TxtConvRate.Text = string.Empty;
            TxtMedicalRate.Text = string.Empty;
            TxtHRARate.Text = string.Empty;
            TxtBasicAmt.Text = string.Empty;
            TxtConvAmt.Text = string.Empty;
            TxtOTAmt.Text = string.Empty;
            TxtODAmt.Text = string.Empty;
            TxtMedicalAmt.Text = string.Empty;
            TxtHRAAmt.Text = string.Empty;
            TxtAllowanceAmt.Text = string.Empty;
            TxtTotalGrossAmt.Text = string.Empty;
            TxtLoanAmt.Text = string.Empty;
            TxtAdvanceAmt.Text = string.Empty;
            TxtPFAmount.Text = string.Empty;
            TxtFPFAmount.Text = string.Empty;
            TxtESICAmountCompany.Text = string.Empty;
            TxtESICAmountEmployee.Text = string.Empty;
            TxtITAmount.Text = string.Empty;
            TxtTotalLessAmount.Text = string.Empty;
            TxtNetSalaryAmount.Text = string.Empty;
            TxtPaySalaryAmount.Text = string.Empty;
            ChkLoanAmount.Checked = false;
            ChkAdvanceAmount.Checked = false;
        }

        public void ControllerEnable()
        {
            TxtSalaryDate.Enabled = true;
            TxtSalaryMonth.Enabled = true;
            TxtWorkingDays.Enabled = true;
            TxtWorkingHours.Enabled = true;
            TxtOTRate.Enabled = true;
            TxtOTHours.Enabled = true;
            TxtRemark.Enabled = true;
            TxtBranchName.Enabled = true;
            TxtAllowRate.Enabled = true;
            TxtAllowHours.Enabled = true;
            TxtPFRate.Enabled = true;
            TxtFPFRate.Enabled = true;
            TxtESICRateComp.Enabled = true;
            TxtESICRateEmp.Enabled = true;
            DdlConfirmFlag.Enabled = true;
            TxtConfirmBy.Enabled = true;
            TxtConfirmDate.Enabled = true;
            DdlApprovalFlag.Enabled = true;
            TxtApprovalBy.Enabled = true;
            TxtApprovalDate.Enabled = true;

            TxtPresentDays.Enabled = true;
            TxtTotalHours.Enabled = true;
            TxtTotalOTHours.Enabled = true;
            TxtODHours.Enabled = true;
            TxtBasicRate.Enabled = true;
            TxtConvRate.Enabled = true;
            TxtMedicalRate.Enabled = true;
            TxtHRARate.Enabled = true;
            TxtBasicAmt.Enabled = false;
            TxtConvAmt.Enabled = true;
            TxtOTAmt.Enabled = true;
            TxtODAmt.Enabled = true;
            TxtMedicalAmt.Enabled = true;
            TxtHRAAmt.Enabled = true;
            TxtAllowanceAmt.Enabled = true;
            TxtTotalGrossAmt.Enabled = true;
            TxtLoanAmt.Enabled = true;
            TxtAdvanceAmt.Enabled = true;
            TxtPFAmount.Enabled = true;
            TxtFPFAmount.Enabled = true;
            TxtESICAmountCompany.Enabled = true;
            TxtESICAmountEmployee.Enabled = true;
            TxtITAmount.Enabled = true;
            TxtTotalLessAmount.Enabled = true;
            TxtNetSalaryAmount.Enabled = false;
            TxtPaySalaryAmount.Enabled = false;
        }

        public void ControllerDisable()
        {
            TxtSalaryDate.Enabled = false;
            TxtSalaryMonth.Enabled = false;
            TxtWorkingDays.Enabled = false;
            TxtWorkingHours.Enabled = false;
            TxtOTRate.Enabled = false;
            TxtOTHours.Enabled = false;
            TxtRemark.Enabled = false;
            TxtBranchName.Enabled = false;
            TxtAllowRate.Enabled = false;
            TxtAllowHours.Enabled = false;
            TxtPFRate.Enabled = false;
            TxtFPFRate.Enabled = false;
            TxtESICRateComp.Enabled = false;
            TxtESICRateEmp.Enabled = false;
            DdlConfirmFlag.Enabled = false;
            TxtConfirmBy.Enabled = false;
            TxtConfirmDate.Enabled = false;
            DdlApprovalFlag.Enabled = false;
            TxtApprovalBy.Enabled = false;
            TxtApprovalDate.Enabled = false;

            TxtPresentDays.Enabled = false;
            TxtTotalHours.Enabled = false;
            TxtTotalOTHours.Enabled = false;
            TxtODHours.Enabled = false;
            TxtBasicRate.Enabled = false;
            TxtConvRate.Enabled = false;
            TxtMedicalRate.Enabled = false;
            TxtHRARate.Enabled = false;
            TxtBasicAmt.Enabled = false;
            TxtConvAmt.Enabled = false;
            TxtOTAmt.Enabled = false;
            TxtODAmt.Enabled = false;
            TxtMedicalAmt.Enabled = false;
            TxtHRAAmt.Enabled = false;
            TxtAllowanceAmt.Enabled = false;
            TxtTotalGrossAmt.Enabled = false;
            TxtLoanAmt.Enabled = false;
            TxtAdvanceAmt.Enabled = false;
            TxtPFAmount.Enabled = false;
            TxtFPFAmount.Enabled = false;
            TxtESICAmountCompany.Enabled = false;
            TxtESICAmountEmployee.Enabled = false;
            TxtITAmount.Enabled = false;
            TxtTotalLessAmount.Enabled = false;
            TxtNetSalaryAmount.Enabled = false;
            TxtPaySalaryAmount.Enabled = false;
        }


        #region TOTAL CALCULATION OF LOAN SETOFF GRID

        private double TotalLoanAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvLoanSetOffTransaction.Rows.Count; i++)
            {
                string total = (GvLoanSetOffTransaction.Rows[i].FindControl("lblLoanAmt") as Label).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }


        private double TotalPaidAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvLoanSetOffTransaction.Rows.Count; i++)
            {
                string total = (GvLoanSetOffTransaction.Rows[i].FindControl("lblTotalPaidAmt") as Label).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }

        private double TotalOutStandingAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvLoanSetOffTransaction.Rows.Count; i++)
            {
                string total = (GvLoanSetOffTransaction.Rows[i].FindControl("lblOSAmt") as Label).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }

        private double TotalCurrentPaidAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvLoanSetOffTransaction.Rows.Count; i++)
            {
                string total = (GvLoanSetOffTransaction.Rows[i].FindControl("TxtPaidAmt") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }


        #endregion

        public void FillBranchName()
        {
            DataTable Dt = new DataTable();
            Dt = BRANCH_MASLogicLayer.GetIDWiseBRANCH_MASDetialsByCompany(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
            TxtBranchName.Text = Dt.Rows[0]["BRANCH_NAME"].ToString();
            HfBranchCode.Value = Dt.Rows[0]["BRANCH_CODE"].ToString();
            TxtBranchName.Enabled = false;
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
                TxtSalaryDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                TxtWorkingHours.Text = "8";
                TxtOTHours.Text = "200";
                TxtOTRate.Text = "1";
                FillBranchName();
                

                //  GvEmployeeSalaryTransaction.Columns[0].Visible = false;
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


        protected void TxtSalaryDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TxtWorkingHours.Text = "8";
                TxtOTHours.Text = "200";
                TxtOTRate.Text = "1";
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtSalaryMonth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtSalaryMonth.Text.Trim() != string.Empty)
                {
                    //11 - 2019
                    string M = string.Empty, Y = string.Empty;
                    string str = TxtSalaryMonth.Text.Trim();

                    string[] word = str.Split('-');

                    foreach (string s in word)
                    {
                        if (M == string.Empty)
                        {
                            M = s;
                        }
                        else
                        {
                            Y = s;
                        }
                    }
                    DateTime StartDate = new DateTime(Convert.ToInt32(Y), Convert.ToInt32(M), 1);
                    int days = DateTime.DaysInMonth(Convert.ToInt32(Y), Convert.ToInt32(M));
                    DateTime EndDate = StartDate.AddDays(days - 1);
                    int ExcludeWEdays = GetNumberOfWorkingDaysJeroen(StartDate, EndDate);

                    TxtWorkingDays.Text = ExcludeWEdays.ToString();
                    TxtRemark.Text = "Salary For The Month Of " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(M)) + " - " + Y;

                }
                else
                {
                    TxtWorkingDays.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetNumberOfWorkingDaysJeroen(DateTime start, DateTime stop)
        {
            int days = 0;
            while (start <= stop)
            {
                if (start.DayOfWeek != DayOfWeek.Sunday)
                {
                    ++days;
                }
                start = start.AddDays(1);
            }
            return days;
        }

        private void SetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("EMP_CODE", typeof(string));
            table.Columns.Add("REF_EMPCODE", typeof(string));
            table.Columns.Add("EMP_NAME", typeof(string));
            table.Columns.Add("EMP_DESIGN", typeof(string));
            table.Columns.Add("PF_FLAG", typeof(string));
            table.Columns.Add("SAL_FLAG", typeof(string));
            table.Columns.Add("ESIC_FLAG", typeof(string));
            table.Columns.Add("OT_FLAG", typeof(string));
            table.Columns.Add("BASIC_RATE", typeof(string));


            dr = table.NewRow();


            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["EMP_CODE"] = string.Empty;
            dr["REF_EMPCODE"] = string.Empty;
            dr["EMP_NAME"] = string.Empty;
            dr["EMP_DESIGN"] = string.Empty;
            dr["SAL_FLAG"] = string.Empty;
            dr["BASIC_RATE"] = string.Empty;
            dr["PF_FLAG"] = "N";
            dr["ESIC_FLAG"] = "N";
            dr["OT_FLAG"] = "N";




            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvEmployeeSalaryTransaction.DataSource = table;
            GvEmployeeSalaryTransaction.DataBind();

        }

        public void FillSALARY_MasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = SAL_MASLogicLayer.GetAllSALARY_TransactionDetails(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvEmployeeSalaryMaster.DataSource = Dv.ToTable();
            GvEmployeeSalaryMaster.DataBind();

            DtSearch = Dv.ToTable();

        }


        protected void GvEmployeeSalaryTransaction_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

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
                    #region INSERT INTO EMPLOYEE SALARY MASTER

                    SAL_MASLogicLayer insert = new SAL_MASLogicLayer();

                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    //insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                    //insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.SAL_DATE = Convert.ToDateTime(TxtSalaryDate.Text.Trim()).ToString("MM-dd-yyyy");
                    insert.SAL_MONTH = Convert.ToDateTime(TxtSalaryMonth.Text.Trim()).ToString("MM-dd-yyyy");

                    if (TxtWorkingDays.Text != string.Empty)
                    {
                        insert.WRK_DAYS = TxtWorkingDays.Text.Trim();
                    }
                    else
                    {
                        insert.WRK_DAYS = "0";
                    }

                    if (TxtWorkingHours.Text != string.Empty)
                    {
                        insert.WRK_HOURS = TxtWorkingHours.Text.Trim();
                    }
                    else
                    {
                        insert.WRK_HOURS = "0";
                    }

                    if (TxtOTHours.Text != string.Empty)
                    {
                        insert.OT_HOURS = TxtOTHours.Text.Trim();
                    }
                    else
                    {
                        insert.OT_HOURS = "0";
                    }

                    if (TxtOTRate.Text != string.Empty)
                    {
                        insert.OT_RATE = TxtOTRate.Text.Trim();
                    }
                    else
                    {
                        insert.OT_RATE = "0";
                    }


                    if (TxtAllowHours.Text != string.Empty)
                    {
                        insert.ALLOW_HOURS = TxtAllowHours.Text.Trim();
                    }
                    else
                    {
                        insert.ALLOW_HOURS = "0";
                    }


                    if (TxtAllowRate.Text != string.Empty)
                    {
                        insert.ALLOW_RATE = TxtAllowRate.Text.Trim();
                    }
                    else
                    {
                        insert.ALLOW_RATE = "0";
                    }

                    if (TxtPFRate.Text != string.Empty)
                    {
                        insert.PF_RATE = TxtPFRate.Text.Trim();
                    }
                    else
                    {
                        insert.PF_RATE = "0";
                    }


                    if (TxtFPFRate.Text != string.Empty)
                    {
                        insert.FPF_RATE = TxtFPFRate.Text.Trim();
                    }
                    else
                    {
                        insert.FPF_RATE = "0";
                    }

                    insert.REMARK = TxtRemark.Text.Trim().ToString();

                    if (TxtESICRateEmp.Text != string.Empty)
                    {
                        insert.ESIC_RATE_EMP = TxtESICRateEmp.Text.Trim();
                    }
                    else
                    {
                        insert.ESIC_RATE_EMP = "0";
                    }

                    if (TxtESICAmountCompany.Text != string.Empty)
                    {
                        insert.ESIC_RATE_COMP = TxtESICAmountCompany.Text.Trim();
                    }
                    else
                    {
                        insert.ESIC_RATE_COMP = "0";
                    }

                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    //insert.UPD_USERID = Session["USERNAME"].ToString();
                    //insert.UPD_TERMINAL  = Session["PC"].ToString();
                    //insert.UPD_DATE = "";
                    insert.CONF_FLAG = DdlConfirmFlag.SelectedValue.Trim().ToString();
                    if (DdlConfirmFlag.SelectedValue == "Y")
                    {
                        insert.CONF_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CONF_DATE = "";
                    }

                    if (DdlConfirmFlag.SelectedValue == "Y")
                    {
                        insert.CONF_USERID = TxtConfirmBy.Text.Trim().ToString();
                    }
                    else
                    {
                        insert.CONF_USERID = null;
                    }

                    insert.CHK_FLAG = DdlApprovalFlag.SelectedValue.Trim().ToString();
                    if (DdlApprovalFlag.SelectedValue == "Y")
                    {
                        insert.CHK_DATE = Convert.ToDateTime(TxtApprovalDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CHK_DATE = "";
                    }

                    if (DdlApprovalFlag.SelectedValue == "Y")
                    {
                        insert.CHK_USERID = TxtApprovalBy.Text.Trim().ToString();
                    }
                    else
                    {
                        insert.CHK_USERID = null;
                    }


                    #endregion



                    #region INSERT INTO SALARY TRANSACTION DETAILS


                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);

                    DataTable dtCurrentEmpLIstTable = (DataTable)ViewState["ModifyEmpList"];
                    foreach (DataRow dr in dtCurrentEmpLIstTable.Rows)
                    {
                        //if (dr["EMP_CODE"].ToString() == e.CommandArgument.ToString())
                        //{
                        //    if (dr["PRESENT_DAY"].ToString() != "0")
                        //    {
                        TxtPresentDays.Text = dr["PRESENT_DAY"].ToString();
                        TxtBasicRate.Text = dr["BASIC_RATE"].ToString();
                        CalculationSalary(Convert.ToDouble(dr["BASIC_RATE"].ToString()), Convert.ToDouble(TxtPresentDays.Text.Trim()));
                        if (dr["EMP_CODE"].ToString() != string.Empty)
                        {


                            XmlElement HandleDetail2 = XDoc1.CreateElement("SAL_TRAN_Details");

                            HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                            HandleDetail2.SetAttribute("EMP_CODE", dr["EMP_CODE"].ToString());


                            if (TxtPresentDays.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("TOT_DAY", TxtPresentDays.Text.Trim());
                            }

                            if (TxtTotalHours.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("TOT_HOURS", TxtTotalHours.Text.Trim());
                            }

                            if (TxtTotalOTHours.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("OT_HOURS", TxtTotalOTHours.Text.Trim());
                            }


                            if (TxtODHours.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("OD_HOURS", TxtODHours.Text.Trim());
                            }

                            //      HandleDetail2.SetAttribute("ALLOW_DAYS", HfCompCode.Value.Trim());

                            if (TxtBasicRate.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("BASIC_RATE", TxtBasicRate.Text.Trim());
                            }

                            if (TxtBasicAmt.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("BASIC_AMT", TxtBasicAmt.Text.Trim());
                            }

                            if (TxtConvRate.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("CONV_RATE", TxtConvRate.Text.Trim());
                            }

                            if (TxtConvAmt.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("CONV_AMT", TxtConvAmt.Text.Trim());
                            }

                            if (TxtOTAmt.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("OT_AMT", TxtOTAmt.Text.Trim());
                            }

                            if (TxtODAmt.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("OD_AMT", TxtODAmt.Text.Trim());
                            }

                            if (TxtMedicalRate.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("MEDICAL_RATE", TxtMedicalRate.Text.Trim());
                            }

                            if (TxtMedicalAmt.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("MEDICAL_AMT", TxtMedicalAmt.Text.Trim());
                            }

                            if (TxtHRARate.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("HRA_RATE", TxtHRARate.Text.Trim());
                            }

                            if (TxtHRAAmt.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("HRA_AMT", TxtHRAAmt.Text.Trim());
                            }

                            if (TxtAllowanceAmt.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("ALLOW_AMT", TxtAllowanceAmt.Text.Trim());
                            }

                            if (TxtTotalGrossAmt.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("GROSS_AMT", TxtTotalGrossAmt.Text.Trim());
                            }

                            if (TxtPFAmount.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("PF_AMT", TxtPFAmount.Text.Trim());
                            }

                            if (TxtFPFAmount.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("FPF_AMT", TxtFPFAmount.Text.Trim());
                            }


                            if (TxtESICAmountEmployee.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("ESIC_AMT_EMP", TxtESICAmountEmployee.Text.Trim());
                            }

                            if (TxtESICAmountCompany.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("ESIC_AMT_COMP", TxtESICAmountCompany.Text.Trim());
                            }

                            if (TxtITAmount.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("IT_AMT", TxtITAmount.Text.Trim());
                            }

                            if (TxtLoanAmt.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("LOAN_AMT", TxtLoanAmt.Text.Trim());
                            }

                            if (TxtAdvanceAmt.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("ADVANCE_AMT", TxtAdvanceAmt.Text.Trim());
                            }

                            if (TxtTotalLessAmount.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("TOT_LESS_AMT", TxtTotalLessAmount.Text.Trim());
                            }

                            if (TxtNetSalaryAmount.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("NET_AMT", TxtNetSalaryAmount.Text.Trim());
                            }

                            if (TxtPaySalaryAmount.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("PAY_AMT", TxtPaySalaryAmount.Text.Trim());
                            }

                            root1.AppendChild(HandleDetail2);

                        }

                        //CALL CLEAR CALCULATION TEXT

                        ClearSalaryTransaction();

                      
                    }

                

                    #endregion

                    #region INSERT INTO SALARY PAID TRANSACTION DETAILS

                    XmlDocument XDocPaid = new XmlDocument();
                    XmlDeclaration decPaid = XDocPaid.CreateXmlDeclaration("1.0", null, null);
                    XDocPaid.AppendChild(decPaid);// Create the root element
                    XmlElement rootPaid = XDocPaid.CreateElement("root");
                    XDocPaid.AppendChild(rootPaid);
                    int SRNO = 1;

                    foreach (GridViewRow row in GvLoanSetOffTransaction.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {

                            HiddenField HfLoanCompCode = row.FindControl("HfLoanCompCode") as HiddenField;
                            HiddenField HfLoanRefTranDate = row.FindControl("HfLoanRefTranDate") as HiddenField;
                            HiddenField HfLoanRefTranNo = row.FindControl("HfLoanRefTranNo") as HiddenField;
                            HiddenField HfLoanRefType = row.FindControl("HfLoanRefType") as HiddenField;
                            HiddenField HfLoanEMP_CODE = row.FindControl("HfLoanEMP_CODE") as HiddenField;


                            Label lblLoanDate = row.FindControl("lblLoanDate") as Label;
                            Label lblLoanAmt = row.FindControl("lblLoanAmt") as Label;
                            Label lblInstallAmt = row.FindControl("lblInstallAmt") as Label;
                            Label lblTotalPaidAmt = row.FindControl("lblTotalPaidAmt") as Label;
                            Label lblOSAmt = row.FindControl("lblOSAmt") as Label;
                            TextBox TxtPaidAmt = row.FindControl("TxtPaidAmt") as TextBox;

                            if (HfLoanEMP_CODE.Value != string.Empty && HfLoanEMP_CODE.Value != null)
                            {
                                XmlElement HandleDetail3 = XDocPaid.CreateElement("SAL_TRAN_PAID_Details");

                                HandleDetail3.SetAttribute("COMP_CODE", HfLoanCompCode.Value.Trim());
                                //HandleDetail3.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                                //HandleDetail3.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                HandleDetail3.SetAttribute("SRNO", SRNO.ToString().Trim());

                                if (HfLoanEMP_CODE.Value != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("EMP_CODE", HfLoanEMP_CODE.Value.Trim());
                                }
                                HandleDetail3.SetAttribute("REF_TRAN_DATE", Convert.ToDateTime(HfLoanRefTranDate.Value.Trim()).ToString("yyyy-MM-dd"));
                                HandleDetail3.SetAttribute("REF_TRAN_NO", HfLoanRefTranNo.Value.Trim());
                                HandleDetail3.SetAttribute("REF_LOAN_TYPE", HfLoanRefType.Value.Trim());
                                if (TxtPaidAmt.Text != string.Empty)
                                {
                                    HandleDetail3.SetAttribute("PAID_AMT", TxtPaidAmt.Text.Trim());
                                }
                                HandleDetail3.SetAttribute("REMARK", null);



                                rootPaid.AppendChild(HandleDetail3);
                                SRNO++;

                            }

                        }

                    }

                    #endregion

                    string str = SAL_MASLogicLayer.InsertSALARY_TransactionDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDocPaid.OuterXml));

                    if (str.Contains("successfully"))
                    {

                        lblmsg.Text = "SALARY TRANSACTION MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillSALARY_MasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "SALARY TRANSACTION MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : SALARY TRANSACTIONMASTER NOT SAVED";
                        lblmsg.ForeColor = Color.Red;

                    }




                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillBranchNameOnUpdate(string BRANCH_CODE)
        {
            if(BRANCH_CODE!=string.Empty)
            {
                DataTable Dt = new DataTable();
                Dt = BRANCH_MASLogicLayer.GetIDWiseBRANCH_MASDetialsByCompany(HfCompCode.Value.ToString(),BRANCH_CODE.ToString());
                TxtBranchName.Text = Dt.Rows[0]["BRANCH_NAME"].ToString();
                HfBranchCode.Value = Dt.Rows[0]["BRANCH_CODE"].ToString();
                TxtBranchName.Enabled = false;
            }
            else
            {
                TxtBranchName.Text = string.Empty;
                HfBranchCode.Value = string.Empty;
            }
         
        }

        protected void GvEmployeeSalaryMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvEmployeeSalaryMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = SAL_MASLogicLayer.GetAllIDWiseSALARY_TransactionDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.Trim()));
                        DataTable dtSalMas = ds.Tables[0];
                        DataTable dtSalTran = ds.Tables[1];
                        DataTable dtSalPaidTran = ds.Tables[2];

                        if (dtSalTran.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dtSalMas.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dtSalMas.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dtSalMas.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dtSalMas.Rows[0]["TRAN_NO"].ToString();
                            FillBranchNameOnUpdate(dtSalMas.Rows[0]["BRANCH_CODE"].ToString());
                            TxtSalaryDate.Text = Convert.ToDateTime(dtSalMas.Rows[0]["SAL_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtSalaryMonth.Text = Convert.ToDateTime(dtSalMas.Rows[0]["SAL_MONTH"].ToString()).ToString("MM-yyyy");
                            TxtWorkingDays.Text = dtSalMas.Rows[0]["WRK_DAYS"].ToString();
                            TxtWorkingHours.Text = dtSalMas.Rows[0]["WRK_HOURS"].ToString();
                            TxtOTRate.Text = dtSalMas.Rows[0]["OT_RATE"].ToString();
                            TxtOTHours.Text = dtSalMas.Rows[0]["OT_HOURS"].ToString();
                            TxtRemark.Text = dtSalMas.Rows[0]["REMARK"].ToString();
                           // TxtBranchName.Text = dtSalMas.Rows[0]["BRANCH_CODE"].ToString();
                            TxtAllowRate.Text = dtSalMas.Rows[0]["ALLOW_RATE"].ToString();
                            TxtAllowHours.Text = dtSalMas.Rows[0]["ALLOW_HOURS"].ToString();
                            TxtPFRate.Text = dtSalMas.Rows[0]["PF_RATE"].ToString();
                            TxtFPFRate.Text = dtSalMas.Rows[0]["FPF_RATE"].ToString();
                            TxtESICRateComp.Text = dtSalMas.Rows[0]["ESIC_RATE_COMP"].ToString();
                            TxtESICRateEmp.Text = dtSalMas.Rows[0]["ESIC_RATE_EMP"].ToString();
                            DdlConfirmFlag.SelectedValue = dtSalMas.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmBy.Text = dtSalMas.Rows[0]["CONF_USERID"].ToString();
                            TxtConfirmDate.Text = dtSalMas.Rows[0]["CONF_DATE"].ToString();
                            DdlApprovalFlag.SelectedValue = dtSalMas.Rows[0]["CHK_FLAG"].ToString();
                            TxtApprovalBy.Text = dtSalMas.Rows[0]["CHK_USERID"].ToString();
                            TxtApprovalDate.Text = dtSalMas.Rows[0]["CHK_DATE"].ToString();

                        }

                        if (dtSalTran.Rows.Count > 0)
                        {
                            if (ViewState["ModifyEmpList"] == null)
                            {
                                DataTable table = new DataTable();
                                DataRow dr = null;
                                table.Columns.Add("EMP_CODE", typeof(string));
                                table.Columns.Add("BASIC_RATE", typeof(string));
                                table.Columns.Add("PRESENT_DAY", typeof(string));

                                //DataTable Dt = new DataTable();
                                //dtSalTran = EMP_MASLogicLayer.GetAllEmployeeDetailsOnBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());

                                for (int i = 0; i < dtSalTran.Rows.Count; i++)
                                {
                                    dr = table.NewRow();
                                    dr["EMP_CODE"] = dtSalTran.Rows[i]["EMP_CODE"].ToString();
                                    dr["BASIC_RATE"] = dtSalTran.Rows[i]["BASIC_RATE"].ToString();
                                    dr["PRESENT_DAY"] = dtSalTran.Rows[i]["TOT_DAY"].ToString();
                                    table.Rows.Add(dr);
                                }

                                ViewState["ModifyEmpList"] = table;
                            }

                            GvEmployeeSalaryTransaction.DataSource = dtSalTran;
                            GvEmployeeSalaryTransaction.DataBind();

                        }

                        if (dtSalPaidTran.Rows.Count > 0)
                        {
                            //GvLoanSetOffTransaction.DataSource = dtSalPaidTran;
                            //GvLoanSetOffTransaction.DataBind();
                        }


                        btnSave.Visible = false;
                        btnDelete.Visible = true;
                        Btncalldel.Visible = true;
                        BtncallUpd.Visible = false;
                        ControllerDisable();


                    }
                    #endregion
                }


                if (e.CommandName == "Edita")
                {
                    #region EDIT
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = SAL_MASLogicLayer.GetAllIDWiseSALARY_TransactionDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.Trim()));
                        DataTable dtSalMas = ds.Tables[0];
                        DataTable dtSalTran = ds.Tables[1];
                        DataTable dtSalPaidTran = ds.Tables[2];

                        if (dtSalTran.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dtSalMas.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dtSalMas.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dtSalMas.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dtSalMas.Rows[0]["TRAN_NO"].ToString();
                            FillBranchNameOnUpdate(dtSalMas.Rows[0]["BRANCH_CODE"].ToString());
                            TxtSalaryDate.Text = Convert.ToDateTime(dtSalMas.Rows[0]["SAL_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtSalaryMonth.Text = Convert.ToDateTime(dtSalMas.Rows[0]["SAL_MONTH"].ToString()).ToString("MM-yyyy");
                            TxtWorkingDays.Text = dtSalMas.Rows[0]["WRK_DAYS"].ToString();
                            TxtWorkingHours.Text = dtSalMas.Rows[0]["WRK_HOURS"].ToString();
                            TxtOTRate.Text = dtSalMas.Rows[0]["OT_RATE"].ToString();
                            TxtOTHours.Text = dtSalMas.Rows[0]["OT_HOURS"].ToString();
                            TxtRemark.Text = dtSalMas.Rows[0]["REMARK"].ToString();
                        //    TxtBranchName.Text = dtSalMas.Rows[0]["BRANCH_CODE"].ToString();
                            TxtAllowRate.Text = dtSalMas.Rows[0]["ALLOW_RATE"].ToString();
                            TxtAllowHours.Text = dtSalMas.Rows[0]["ALLOW_HOURS"].ToString();
                            TxtPFRate.Text = dtSalMas.Rows[0]["PF_RATE"].ToString();
                            TxtFPFRate.Text = dtSalMas.Rows[0]["FPF_RATE"].ToString();
                            TxtESICRateComp.Text = dtSalMas.Rows[0]["ESIC_RATE_COMP"].ToString();
                            TxtESICRateEmp.Text = dtSalMas.Rows[0]["ESIC_RATE_EMP"].ToString();
                            DdlConfirmFlag.SelectedValue = dtSalMas.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmBy.Text = dtSalMas.Rows[0]["CONF_USERID"].ToString();
                            TxtConfirmDate.Text = dtSalMas.Rows[0]["CONF_DATE"].ToString();
                            DdlApprovalFlag.SelectedValue = dtSalMas.Rows[0]["CHK_FLAG"].ToString();
                            TxtApprovalBy.Text = dtSalMas.Rows[0]["CHK_USERID"].ToString();
                            TxtApprovalDate.Text = dtSalMas.Rows[0]["CHK_DATE"].ToString();

                        }

                        if (dtSalTran.Rows.Count > 0)
                        {
                            if (ViewState["ModifyEmpList"] == null)
                            {
                                DataTable table = new DataTable();
                                DataRow dr = null;
                                table.Columns.Add("EMP_CODE", typeof(string));
                                table.Columns.Add("BASIC_RATE", typeof(string));
                                table.Columns.Add("PRESENT_DAY", typeof(string));

                                //DataTable Dt = new DataTable();
                                //dtSalTran = EMP_MASLogicLayer.GetAllEmployeeDetailsOnBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());

                                for (int i = 0; i < dtSalTran.Rows.Count; i++)
                                {
                                    dr = table.NewRow();
                                    dr["EMP_CODE"] = dtSalTran.Rows[i]["EMP_CODE"].ToString();
                                    dr["BASIC_RATE"] = dtSalTran.Rows[i]["BASIC_RATE"].ToString();
                                    dr["PRESENT_DAY"] = dtSalTran.Rows[i]["TOT_DAY"].ToString();
                                    table.Rows.Add(dr);
                                }

                                ViewState["ModifyEmpList"] = table;
                            }

                            GvEmployeeSalaryTransaction.DataSource = dtSalTran;
                            GvEmployeeSalaryTransaction.DataBind();

                        }

                        if (dtSalPaidTran.Rows.Count > 0)
                        {
                            //GvLoanSetOffTransaction.DataSource = dtSalPaidTran;
                            //GvLoanSetOffTransaction.DataBind();
                        }

                        BtncallUpd.Text = "UPDATE";

                        #endregion

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
                            ControllerDisable();
                        }
                    }
                    #endregion
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = true;
                    btnSave.Visible = true;
                    UserRights();

                }


                if (e.CommandName == "Viewa")
                {
                    #region SET TEXT ON VIEW
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = SAL_MASLogicLayer.GetAllIDWiseSALARY_TransactionDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.Trim()));
                        DataTable dtSalMas = ds.Tables[0];
                        DataTable dtSalTran = ds.Tables[1];
                        DataTable dtSalPaidTran = ds.Tables[2];

                        if (dtSalTran.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dtSalMas.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dtSalMas.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dtSalMas.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dtSalMas.Rows[0]["TRAN_NO"].ToString();
                            FillBranchNameOnUpdate(dtSalMas.Rows[0]["BRANCH_CODE"].ToString());
                            TxtSalaryDate.Text = Convert.ToDateTime(dtSalMas.Rows[0]["SAL_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtSalaryMonth.Text = Convert.ToDateTime(dtSalMas.Rows[0]["SAL_MONTH"].ToString()).ToString("MM-yyyy");
                            TxtWorkingDays.Text = dtSalMas.Rows[0]["WRK_DAYS"].ToString();
                            TxtWorkingHours.Text = dtSalMas.Rows[0]["WRK_HOURS"].ToString();
                            TxtOTRate.Text = dtSalMas.Rows[0]["OT_RATE"].ToString();
                            TxtOTHours.Text = dtSalMas.Rows[0]["OT_HOURS"].ToString();
                            TxtRemark.Text = dtSalMas.Rows[0]["REMARK"].ToString();
                       //     TxtBranchName.Text = dtSalMas.Rows[0]["BRANCH_CODE"].ToString();
                            TxtAllowRate.Text = dtSalMas.Rows[0]["ALLOW_RATE"].ToString();
                            TxtAllowHours.Text = dtSalMas.Rows[0]["ALLOW_HOURS"].ToString();
                            TxtPFRate.Text = dtSalMas.Rows[0]["PF_RATE"].ToString();
                            TxtFPFRate.Text = dtSalMas.Rows[0]["FPF_RATE"].ToString();
                            TxtESICRateComp.Text = dtSalMas.Rows[0]["ESIC_RATE_COMP"].ToString();
                            TxtESICRateEmp.Text = dtSalMas.Rows[0]["ESIC_RATE_EMP"].ToString();
                            DdlConfirmFlag.SelectedValue = dtSalMas.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmBy.Text = dtSalMas.Rows[0]["CONF_USERID"].ToString();
                            TxtConfirmDate.Text = dtSalMas.Rows[0]["CONF_DATE"].ToString();
                            DdlApprovalFlag.SelectedValue = dtSalMas.Rows[0]["CHK_FLAG"].ToString();
                            TxtApprovalBy.Text = dtSalMas.Rows[0]["CHK_USERID"].ToString();
                            TxtApprovalDate.Text = dtSalMas.Rows[0]["CHK_DATE"].ToString();

                        }

                        if (dtSalTran.Rows.Count > 0)
                        {
                            if (ViewState["ModifyEmpList"] == null)
                            {
                                DataTable table = new DataTable();
                                DataRow dr = null;
                                table.Columns.Add("EMP_CODE", typeof(string));
                                table.Columns.Add("BASIC_RATE", typeof(string));
                                table.Columns.Add("PRESENT_DAY", typeof(string));

                                //DataTable Dt = new DataTable();
                                //dtSalTran = EMP_MASLogicLayer.GetAllEmployeeDetailsOnBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());

                                for (int i = 0; i < dtSalTran.Rows.Count; i++)
                                {
                                    dr = table.NewRow();
                                    dr["EMP_CODE"] = dtSalTran.Rows[i]["EMP_CODE"].ToString();
                                    dr["BASIC_RATE"] = dtSalTran.Rows[i]["BASIC_RATE"].ToString();
                                    dr["PRESENT_DAY"] = dtSalTran.Rows[i]["TOT_DAY"].ToString();
                                    table.Rows.Add(dr);
                                }

                                ViewState["ModifyEmpList"] = table;
                            }

                            GvEmployeeSalaryTransaction.DataSource = dtSalTran;
                            GvEmployeeSalaryTransaction.DataBind();

                        }

                        if (dtSalPaidTran.Rows.Count > 0)
                        {
                            //GvLoanSetOffTransaction.DataSource = dtSalPaidTran;
                            //GvLoanSetOffTransaction.DataBind();
                        }
                    
                    #endregion
                    ControllerDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    UserRights();
                }
            }


        }
            catch (Exception Ex)
            {

                Ex.ToString();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
        }

        protected void Btncalldel_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE  
                string str = SAL_MASLogicLayer.DeleteSALARY_TransactionDetailsByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value));
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
                    lblmsg.Text = "Error:Salary Master Deleted";
                    lblmsg.ForeColor = Color.Red;
                }
                clear();
                UserRights();
                FillSALARY_MasterGrid(Convert.ToString(Session["COMP_CODE"]));
                #endregion
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
                #region UPDATE SALARY TRANSACTION

                #region INSERT INTO EMPLOYEE SALARY MASTER

                SAL_MASLogicLayer insert = new SAL_MASLogicLayer();

                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.SAL_DATE = Convert.ToDateTime(TxtSalaryDate.Text.Trim()).ToString("MM-dd-yyyy");
                insert.SAL_MONTH = Convert.ToDateTime(TxtSalaryMonth.Text.Trim()).ToString("MM-dd-yyyy");

                if (TxtWorkingDays.Text != string.Empty)
                {
                    insert.WRK_DAYS = TxtWorkingDays.Text.Trim();
                }
                else
                {
                    insert.WRK_DAYS = "0";
                }

                if (TxtWorkingHours.Text != string.Empty)
                {
                    insert.WRK_HOURS = TxtWorkingHours.Text.Trim();
                }
                else
                {
                    insert.WRK_HOURS = "0";
                }

                if (TxtOTHours.Text != string.Empty)
                {
                    insert.OT_HOURS = TxtOTHours.Text.Trim();
                }
                else
                {
                    insert.OT_HOURS = "0";
                }

                if (TxtOTRate.Text != string.Empty)
                {
                    insert.OT_RATE = TxtOTRate.Text.Trim();
                }
                else
                {
                    insert.OT_RATE = "0";
                }


                if (TxtAllowHours.Text != string.Empty)
                {
                    insert.ALLOW_HOURS = TxtAllowHours.Text.Trim();
                }
                else
                {
                    insert.ALLOW_HOURS = "0";
                }


                if (TxtAllowRate.Text != string.Empty)
                {
                    insert.ALLOW_RATE = TxtAllowRate.Text.Trim();
                }
                else
                {
                    insert.ALLOW_RATE = "0";
                }

                if (TxtPFRate.Text != string.Empty)
                {
                    insert.PF_RATE = TxtPFRate.Text.Trim();
                }
                else
                {
                    insert.PF_RATE = "0";
                }


                if (TxtFPFRate.Text != string.Empty)
                {
                    insert.FPF_RATE = TxtFPFRate.Text.Trim();
                }
                else
                {
                    insert.FPF_RATE = "0";
                }

                insert.REMARK = TxtRemark.Text.Trim().ToString();

                if (TxtESICRateEmp.Text != string.Empty)
                {
                    insert.ESIC_RATE_EMP = TxtESICRateEmp.Text.Trim();
                }
                else
                {
                    insert.ESIC_RATE_EMP = "0";
                }

                if (TxtESICAmountCompany.Text != string.Empty)
                {
                    insert.ESIC_RATE_COMP = TxtESICAmountCompany.Text.Trim();
                }
                else
                {
                    insert.ESIC_RATE_COMP = "0";
                }

                insert.BRANCH_CODE = HfBranchCode.Value.Trim();
                //insert.INS_USERID = Session["USERNAME"].ToString();
                //insert.INS_TERMINAL = Session["PC"].ToString();
                //insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";
                insert.CONF_FLAG = DdlConfirmFlag.SelectedValue.Trim().ToString();
                if (DdlConfirmFlag.SelectedValue == "Y")
                {
                    insert.CONF_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.CONF_DATE = "";
                }

                if (DdlConfirmFlag.SelectedValue == "Y")
                {
                    insert.CONF_USERID = TxtConfirmBy.Text.Trim().ToString();
                }
                else
                {
                    insert.CONF_USERID = null;
                }

                insert.CHK_FLAG = DdlApprovalFlag.SelectedValue.Trim().ToString();
                if (DdlApprovalFlag.SelectedValue == "Y")
                {
                    insert.CHK_DATE = Convert.ToDateTime(TxtApprovalDate.Text.Trim()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.CHK_DATE = "";
                }

                if (DdlApprovalFlag.SelectedValue == "Y")
                {
                    insert.CHK_USERID = TxtApprovalBy.Text.Trim().ToString();
                }
                else
                {
                    insert.CHK_USERID = null;
                }


                #endregion



                #region INSERT INTO SALARY TRANSACTION DETAILS


                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);

                DataTable dtCurrentEmpLIstTable = (DataTable)ViewState["ModifyEmpList"];
                foreach (DataRow dr in dtCurrentEmpLIstTable.Rows)
                {
                    //if (dr["EMP_CODE"].ToString() == e.CommandArgument.ToString())
                    //{
                    //    if (dr["PRESENT_DAY"].ToString() != "0")
                    //    {
                    TxtPresentDays.Text = dr["PRESENT_DAY"].ToString();
                    TxtBasicRate.Text = dr["BASIC_RATE"].ToString();
                    CalculationSalary(Convert.ToDouble(dr["BASIC_RATE"].ToString()), Convert.ToDouble(TxtPresentDays.Text.Trim()));
                    if (dr["EMP_CODE"].ToString() != string.Empty)
                    {


                        XmlElement HandleDetail2 = XDoc1.CreateElement("SAL_TRAN_Details");

                        HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                        HandleDetail2.SetAttribute("EMP_CODE", dr["EMP_CODE"].ToString());


                        if (TxtPresentDays.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("TOT_DAY", TxtPresentDays.Text.Trim());
                        }

                        if (TxtTotalHours.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("TOT_HOURS", TxtTotalHours.Text.Trim());
                        }

                        if (TxtTotalOTHours.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("OT_HOURS", TxtTotalOTHours.Text.Trim());
                        }


                        if (TxtODHours.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("OD_HOURS", TxtODHours.Text.Trim());
                        }

                        //      HandleDetail2.SetAttribute("ALLOW_DAYS", HfCompCode.Value.Trim());

                        if (TxtBasicRate.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("BASIC_RATE", TxtBasicRate.Text.Trim());
                        }

                        if (TxtBasicAmt.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("BASIC_AMT", TxtBasicAmt.Text.Trim());
                        }

                        if (TxtConvRate.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("CONV_RATE", TxtConvRate.Text.Trim());
                        }

                        if (TxtConvAmt.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("CONV_AMT", TxtConvAmt.Text.Trim());
                        }

                        if (TxtOTAmt.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("OT_AMT", TxtOTAmt.Text.Trim());
                        }

                        if (TxtODAmt.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("OD_AMT", TxtODAmt.Text.Trim());
                        }

                        if (TxtMedicalRate.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("MEDICAL_RATE", TxtMedicalRate.Text.Trim());
                        }

                        if (TxtMedicalAmt.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("MEDICAL_AMT", TxtMedicalAmt.Text.Trim());
                        }

                        if (TxtHRARate.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("HRA_RATE", TxtHRARate.Text.Trim());
                        }

                        if (TxtHRAAmt.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("HRA_AMT", TxtHRAAmt.Text.Trim());
                        }

                        if (TxtAllowanceAmt.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("ALLOW_AMT", TxtAllowanceAmt.Text.Trim());
                        }

                        if (TxtTotalGrossAmt.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("GROSS_AMT", TxtTotalGrossAmt.Text.Trim());
                        }

                        if (TxtPFAmount.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("PF_AMT", TxtPFAmount.Text.Trim());
                        }

                        if (TxtFPFAmount.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("FPF_AMT", TxtFPFAmount.Text.Trim());
                        }


                        if (TxtESICAmountEmployee.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("ESIC_AMT_EMP", TxtESICAmountEmployee.Text.Trim());
                        }

                        if (TxtESICAmountCompany.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("ESIC_AMT_COMP", TxtESICAmountCompany.Text.Trim());
                        }

                        if (TxtITAmount.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("IT_AMT", TxtITAmount.Text.Trim());
                        }

                        if (TxtLoanAmt.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("LOAN_AMT", TxtLoanAmt.Text.Trim());
                        }

                        if (TxtAdvanceAmt.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("ADVANCE_AMT", TxtAdvanceAmt.Text.Trim());
                        }

                        if (TxtTotalLessAmount.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("TOT_LESS_AMT", TxtTotalLessAmount.Text.Trim());
                        }

                        if (TxtNetSalaryAmount.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("NET_AMT", TxtNetSalaryAmount.Text.Trim());
                        }

                        if (TxtPaySalaryAmount.Text != string.Empty)
                        {
                            HandleDetail2.SetAttribute("PAY_AMT", TxtPaySalaryAmount.Text.Trim());
                        }

                        root1.AppendChild(HandleDetail2);

                    }

                    //CALL CLEAR CALCULATION TEXT

                    ClearSalaryTransaction();

                    //    }
                    //}
                }



                #endregion

                #region INSERT INTO SALARY PAID TRANSACTION DETAILS

                XmlDocument XDocPaid = new XmlDocument();
                XmlDeclaration decPaid = XDocPaid.CreateXmlDeclaration("1.0", null, null);
                XDocPaid.AppendChild(decPaid);// Create the root element
                XmlElement rootPaid = XDocPaid.CreateElement("root");
                XDocPaid.AppendChild(rootPaid);
                int SRNO = 1;

                foreach (GridViewRow row in GvLoanSetOffTransaction.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        HiddenField HfLoanCompCode = row.FindControl("HfLoanCompCode") as HiddenField;
                        HiddenField HfLoanRefTranDate = row.FindControl("HfLoanRefTranDate") as HiddenField;
                        HiddenField HfLoanRefTranNo = row.FindControl("HfLoanRefTranNo") as HiddenField;
                        HiddenField HfLoanRefType = row.FindControl("HfLoanRefType") as HiddenField;
                        HiddenField HfLoanEMP_CODE = row.FindControl("HfLoanEMP_CODE") as HiddenField;


                        Label lblLoanDate = row.FindControl("lblLoanDate") as Label;
                        Label lblLoanAmt = row.FindControl("lblLoanAmt") as Label;
                        Label lblInstallAmt = row.FindControl("lblInstallAmt") as Label;
                        Label lblTotalPaidAmt = row.FindControl("lblTotalPaidAmt") as Label;
                        Label lblOSAmt = row.FindControl("lblOSAmt") as Label;
                        TextBox TxtPaidAmt = row.FindControl("TxtPaidAmt") as TextBox;

                        if (HfEmployeeCode.Value != string.Empty && HfEmployeeCode.Value != null)
                        {
                            XmlElement HandleDetail3 = XDocPaid.CreateElement("SAL_TRAN_PAID_Details");

                            HandleDetail3.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                            //HandleDetail3.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                            //HandleDetail3.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail3.SetAttribute("SRNO", SRNO.ToString().Trim());

                            if (HfEmployeeCode.Value != string.Empty)
                            {
                                HandleDetail3.SetAttribute("EMP_CODE", HfEmployeeCode.Value.Trim());
                            }
                            HandleDetail3.SetAttribute("REF_TRAN_DATE", Convert.ToDateTime(HfLoanRefTranDate.Value.Trim()).ToString("MM-dd-yyyy"));
                            HandleDetail3.SetAttribute("REF_TRAN_NO", HfLoanRefTranNo.Value.Trim());
                            HandleDetail3.SetAttribute("REF_LOAN_TYPE", HfLoanRefType.Value.Trim());
                            if (TxtPaidAmt.Text != string.Empty)
                            {
                                HandleDetail3.SetAttribute("PAID_AMT", TxtPaidAmt.Text.Trim());
                            }
                            HandleDetail3.SetAttribute("REMARK", null);



                            rootPaid.AppendChild(HandleDetail3);
                            SRNO++;

                        }

                    }

                }

                #endregion

                string str = SAL_MASLogicLayer.UpdateSALARY_TrasactionDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDocPaid.OuterXml));

                if (str.Contains("successfully"))
                {

                    lblmsg.Text = "SALARY TRANSACTION MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillSALARY_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "SALARY TRANSACTION MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : SALARY TRANSACTIONMASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }


                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void BtnProcessEmployeeDetails_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["ModifyEmpList"] = null;

                DataTable table = new DataTable();
                DataRow dr = null;
                table.Columns.Add("EMP_CODE", typeof(string));
                table.Columns.Add("BASIC_RATE", typeof(string));
                table.Columns.Add("PRESENT_DAY", typeof(string));

                DataTable Dt = new DataTable();
                Dt = EMP_MASLogicLayer.GetAllEmployeeDetailsOnBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    dr = table.NewRow();
                    dr["EMP_CODE"] = Dt.Rows[i]["EMP_CODE"].ToString();
                    dr["BASIC_RATE"] = Dt.Rows[i]["BASIC_RATE"].ToString();
                    dr["PRESENT_DAY"] = "0";
                    table.Rows.Add(dr);
                }



                ViewState["ModifyEmpList"] = table;

                //DataTable dtCurrentTable = (DataTable)ViewState["ModifyEmpList"];

                GvEmployeeSalaryTransaction.DataSource = Dt;
                GvEmployeeSalaryTransaction.DataBind();




            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void GvEmployeeSalaryTransaction_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Selecta")
                {
                    //  clear();
                    ClearSalaryTransaction();
                    #region SELECT


                    //int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;

                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;
                        HiddenField HfTranNoGrid = (row.FindControl("HfTranNoGrid")) as HiddenField;
                        HiddenField HfBasicRate = (row.FindControl("HfBasicRate")) as HiddenField;
                        TextBox TxtEmployeeName = (row.FindControl("TxtEmployeeName")) as TextBox;

                        HfEmployeeCode.Value = e.CommandArgument.ToString();
                        TxtBasicRate.Text = HfBasicRate.Value.Trim();

                        //Display Name on label of Selected Employee

                        lblEmployeeName.Text = TxtEmployeeName.Text;

                        ///***////
                        ///
                        if (HfTranNoGrid.Value != string.Empty && HfTranDateGrid.Value != string.Empty)
                        {
                            DataSet ds = SAL_MASLogicLayer.GetAllSALARY_TRANDetialsByEMP_CODE(HfTranNoGrid.Value.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()), e.CommandArgument.ToString());
                            DataTable DtSalTran = ds.Tables[0];
                            if (DtSalTran.Rows.Count > 0)
                            {

                                TxtPresentDays.Text = DtSalTran.Rows[0]["TOT_DAY"].ToString();
                                TxtTotalHours.Text = DtSalTran.Rows[0]["TOT_HOURS"].ToString();
                                TxtTotalOTHours.Text = DtSalTran.Rows[0]["OT_HOURS"].ToString();
                                TxtODHours.Text = DtSalTran.Rows[0]["OD_HOURS"].ToString();
                                TxtBasicRate.Text = DtSalTran.Rows[0]["BASIC_RATE"].ToString();
                                TxtConvRate.Text = DtSalTran.Rows[0]["CONV_RATE"].ToString();
                                TxtMedicalRate.Text = DtSalTran.Rows[0]["MEDICAL_RATE"].ToString();
                                TxtHRARate.Text = DtSalTran.Rows[0]["HRA_RATE"].ToString();
                                TxtBasicAmt.Text = DtSalTran.Rows[0]["BASIC_AMT"].ToString();
                                TxtConvAmt.Text = DtSalTran.Rows[0]["CONV_AMT"].ToString();
                                TxtOTAmt.Text = DtSalTran.Rows[0]["OT_AMT"].ToString();
                                TxtODAmt.Text = DtSalTran.Rows[0]["OD_AMT"].ToString();
                                TxtMedicalAmt.Text = DtSalTran.Rows[0]["MEDICAL_AMT"].ToString();
                                TxtHRAAmt.Text = DtSalTran.Rows[0]["HRA_AMT"].ToString();
                                TxtAllowanceAmt.Text = DtSalTran.Rows[0]["ALLOW_AMT"].ToString();
                                TxtTotalGrossAmt.Text = DtSalTran.Rows[0]["GROSS_AMT"].ToString();
                                TxtLoanAmt.Text = DtSalTran.Rows[0]["LOAN_AMT"].ToString();
                                TxtAdvanceAmt.Text = DtSalTran.Rows[0]["ADVANCE_AMT"].ToString();
                                TxtPFAmount.Text = DtSalTran.Rows[0]["PF_AMT"].ToString();
                                TxtFPFAmount.Text = DtSalTran.Rows[0]["FPF_AMT"].ToString();
                                TxtESICAmountCompany.Text = DtSalTran.Rows[0]["ESIC_AMT_COMP"].ToString();
                                TxtESICAmountEmployee.Text = DtSalTran.Rows[0]["ESIC_AMT_EMP"].ToString();
                                TxtITAmount.Text = DtSalTran.Rows[0]["IT_AMT"].ToString();
                                TxtTotalLessAmount.Text = DtSalTran.Rows[0]["TOT_LESS_AMT"].ToString();
                                TxtNetSalaryAmount.Text = DtSalTran.Rows[0]["NET_AMT"].ToString();
                                TxtPaySalaryAmount.Text = DtSalTran.Rows[0]["PAY_AMT"].ToString();

                            }
                            else
                            {
                                DataTable dtCurrentEmpLIstTable = (DataTable)ViewState["ModifyEmpList"];
                                foreach (DataRow dr in dtCurrentEmpLIstTable.Rows)
                                {
                                    if (dr["EMP_CODE"].ToString() == e.CommandArgument.ToString())
                                    {
                                        if (dr["PRESENT_DAY"].ToString() != "0")
                                        {
                                            TxtPresentDays.Text = dr["PRESENT_DAY"].ToString();
                                            CalculationSalary(Convert.ToDouble(TxtBasicRate.Text.Trim()), Convert.ToDouble(TxtPresentDays.Text.Trim()));
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            DataTable dtCurrentEmpLIstTable = (DataTable)ViewState["ModifyEmpList"];
                            foreach (DataRow dr in dtCurrentEmpLIstTable.Rows)
                            {
                                if (dr["EMP_CODE"].ToString() == e.CommandArgument.ToString())
                                {
                                    if (dr["PRESENT_DAY"].ToString() != "0")
                                    {
                                        TxtPresentDays.Text = dr["PRESENT_DAY"].ToString();
                                        CalculationSalary(Convert.ToDouble(TxtBasicRate.Text.Trim()), Convert.ToDouble(TxtPresentDays.Text.Trim()));
                                    }
                                }
                            }
                        }

                        #endregion
                    }
                }

            }


            catch (Exception ex)
            {

                throw;
            }
        }



        public void CalculationSalary(double BasicRate, double PresentDay)
        {
            try
            {
                //Calculation Of salary and Assign value to Textbox

                if (TxtBasicAmt.Text == string.Empty)
                {
                    TxtBasicAmt.Text = "0";
                }

                if (TxtConvAmt.Text == string.Empty)
                {
                    TxtConvAmt.Text = "0";
                }

                if (TxtODAmt.Text == string.Empty)
                {
                    TxtODAmt.Text = "0";
                }

                if (TxtOTAmt.Text == string.Empty)
                {
                    TxtOTAmt.Text = "0";
                }

                if (TxtMedicalAmt.Text == string.Empty)
                {
                    TxtMedicalAmt.Text = "0";
                }

                if (TxtHRAAmt.Text == string.Empty)
                {
                    TxtHRAAmt.Text = "0";
                }

                if (TxtAllowanceAmt.Text == string.Empty)
                {
                    TxtAllowanceAmt.Text = "0";
                }


                if (TxtTotalLessAmount.Text == string.Empty)
                {
                    TxtTotalLessAmount.Text = "0";
                }

                // ** CALCULATE PER DAY SALARY ON BASIC RATE

                double PerDaySal = 0;
                double basicAmt = 0;
                double TotGrossAmount = 0;

                if (BasicRate.ToString() != string.Empty && BasicRate.ToString() != null && PresentDay.ToString() != string.Empty && PresentDay.ToString() != null)
                {
                    PerDaySal = BasicRate / 26;

                    basicAmt = (PerDaySal * PresentDay);

                    basicAmt = Math.Round(basicAmt, 2);

                    TxtBasicAmt.Text = Convert.ToString(basicAmt);

                   


                }

                //****

                // CALCULATE TOTAL GROSS AMOUNT



                TotGrossAmount = Convert.ToDouble(TxtBasicAmt.Text.Trim()) + Convert.ToDouble(TxtConvAmt.Text.Trim()) + Convert.ToDouble(TxtODAmt.Text.Trim()) + Convert.ToDouble(TxtOTAmt.Text.Trim()) + Convert.ToDouble(TxtMedicalAmt.Text.Trim()) + Convert.ToDouble(TxtHRAAmt.Text.Trim()) + Convert.ToDouble(TxtAllowanceAmt.Text.Trim());

                TotGrossAmount = Math.Round(TotGrossAmount, 2);

                TxtTotalGrossAmt.Text = TotGrossAmount.ToString();

                //****


                // ** CALCULATE NET SALARY AMOUNT

                double NetPayAmt = 0;

                if (TxtTotalGrossAmt.Text != string.Empty && TxtTotalLessAmount.Text != string.Empty)
                {
                    NetPayAmt = Convert.ToDouble(TxtTotalGrossAmt.Text) - Convert.ToDouble(TxtTotalLessAmount.Text);
                    TxtNetSalaryAmount.Text = NetPayAmt.ToString();


                    double RoundOffNetAmt = Math.Abs(NetPayAmt - Math.Floor(NetPayAmt));
                    if (RoundOffNetAmt > 0.5)
                    {
                        double ro = 1 - RoundOffNetAmt;

                        TxtNetSalaryAmount.Text = Convert.ToString(Convert.ToDouble(NetPayAmt) + ro);
                    }

                    else
                    {
                        double ro = (1 - RoundOffNetAmt) - 1;

                        TxtNetSalaryAmount.Text = Convert.ToString(Math.Floor(NetPayAmt));
                    }

                }

                ///****


                //** CALCULATE PAY SALARY AMOUNT

                double divbyFive = 5;
                double tempdivNo;

                if (TxtNetSalaryAmount.Text != string.Empty && TxtNetSalaryAmount.Text != null)
                {
                    double GridmergeTotalAmt = Convert.ToDouble(TxtNetSalaryAmount.Text) / divbyFive;

                    double decimalpoints = Math.Abs(GridmergeTotalAmt - Math.Floor(GridmergeTotalAmt));
                    if (decimalpoints > 0.5)
                    {
                        double ro = 1 - decimalpoints;

                        tempdivNo =Convert.ToDouble(GridmergeTotalAmt) + ro;

                        TxtPaySalaryAmount.Text = Convert.ToString(tempdivNo * divbyFive);


                    }

                    else
                    {

                        double ro = (1 - decimalpoints) - 1;

                        tempdivNo = Convert.ToDouble(GridmergeTotalAmt) + ro;

                        TxtPaySalaryAmount.Text = Convert.ToString(tempdivNo * divbyFive);
                    }
                   
                }


                //***




            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtPresentDays_TextChanged(object sender, EventArgs e)
        {
            if (TxtPresentDays.Text.Trim() != string.Empty)
            {
                DataTable dtCurrentEmpLIstTable = (DataTable)ViewState["ModifyEmpList"];
                foreach (DataRow dr in dtCurrentEmpLIstTable.Rows)
                {
                    if (dr["EMP_CODE"].ToString() == HfEmployeeCode.Value)
                    {
                        dr["PRESENT_DAY"] = TxtPresentDays.Text.Trim();
                        //dr["PRESENT_DAY"] = TxtPresentDays.Text.Trim();
                        CalculationSalary(Convert.ToDouble(TxtBasicRate.Text.Trim()), Convert.ToDouble(TxtPresentDays.Text.Trim()));
                    }
                }
            }
        }


        protected void ChkLoanAmount_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkLoanAmount.Checked == true)
                {

                    foreach (GridViewRow row in GvEmployeeSalaryTransaction.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfLoanEMP_CODE = row.FindControl("HfLoanEMP_CODE") as HiddenField;
                            Label lblLoanAmt = row.FindControl("lblLoanAmt") as Label;
                            Label lblTotalPaidAmt = row.FindControl("lblTotalPaidAmt") as Label;
                            Label lblOSAmt = row.FindControl("lblOSAmt") as Label;                    
                           

                            if (HfEmployeeCode.Value == string.Empty)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SelectionAlert", "SelectionAlert()", true);
                            }
                            else
                            {

                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelLoanAdvance", "ShowModelLoanAdvance()", true);

                                DataTable Dt = new DataTable();
                                Dt = LOAN_MASLogicLayer.GetAllLOAN_MASTERDetailForSAL_PAIDGrid(Session["COMP_CODE"].ToString(), HfEmployeeCode.Value.ToString(), "L".ToString());
                                GvLoanSetOffTransaction.DataSource = Dt;
                                GvLoanSetOffTransaction.DataBind();

                                Label lblSumTotalLoanAmount = (Label)(GvLoanSetOffTransaction.FooterRow.FindControl("lblSumTotalLoanAmount"));
                                Label lblSumTotalPaidAmount = (Label)(GvLoanSetOffTransaction.FooterRow.FindControl("lblSumTotalPaidAmount"));
                                Label lblSumTotalOutStandingAmount = (Label)(GvLoanSetOffTransaction.FooterRow.FindControl("lblSumTotalOutStandingAmount"));
                                Label lblSumTotalCurrentPaidAmount = (Label)(GvLoanSetOffTransaction.FooterRow.FindControl("lblSumTotalCurrentPaidAmount"));

                                double SumTotalLoanAmount = TotalLoanAmount();
                                lblSumTotalLoanAmount.Text = SumTotalLoanAmount.ToString();

                                double SumTotalPaidAmount = TotalPaidAmount();
                                lblSumTotalPaidAmount.Text = SumTotalPaidAmount.ToString();

                                double SumTotalOutStandingAmount = TotalOutStandingAmount();
                                lblSumTotalOutStandingAmount.Text = SumTotalOutStandingAmount.ToString();

                                double SumTotalCurrentPaidAmount = TotalCurrentPaidAmount();
                                lblSumTotalCurrentPaidAmount.Text = SumTotalCurrentPaidAmount.ToString();

                                TxtLoanAmt.Text = lblSumTotalLoanAmount.Text;


                            }

                           
                        }
                    }
                }

                else
                {
                    TxtLoanAmt.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ChkAdvanceAmount_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkAdvanceAmount.Checked == true)
                {

                    foreach (GridViewRow row in GvEmployeeSalaryTransaction.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfLoanEMP_CODE = row.FindControl("HfLoanEMP_CODE") as HiddenField;

                            if (HfEmployeeCode.Value == string.Empty)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SelectionAlert", "SelectionAlert()", true);
                            }
                            else
                            {

                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelLoanAdvance", "ShowModelLoanAdvance()", true);

                                DataTable Dt = new DataTable();
                                Dt = LOAN_MASLogicLayer.GetAllLOAN_MASTERDetailForSAL_PAIDGrid(Session["COMP_CODE"].ToString(), HfEmployeeCode.Value.ToString(), "A".ToString());
                                GvLoanSetOffTransaction.DataSource = Dt;
                                GvLoanSetOffTransaction.DataBind();

                                Label lblSumTotalLoanAmount = (Label)(GvLoanSetOffTransaction.FooterRow.FindControl("lblSumTotalLoanAmount"));
                                Label lblSumTotalPaidAmount = (Label)(GvLoanSetOffTransaction.FooterRow.FindControl("lblSumTotalPaidAmount"));
                                Label lblSumTotalOutStandingAmount = (Label)(GvLoanSetOffTransaction.FooterRow.FindControl("lblSumTotalOutStandingAmount"));
                                Label lblSumTotalCurrentPaidAmount = (Label)(GvLoanSetOffTransaction.FooterRow.FindControl("lblSumTotalCurrentPaidAmount"));

                                double SumTotalLoanAmount = TotalLoanAmount();
                                lblSumTotalLoanAmount.Text = SumTotalLoanAmount.ToString();

                                double SumTotalPaidAmount = TotalPaidAmount();
                                lblSumTotalPaidAmount.Text = SumTotalPaidAmount.ToString();

                                double SumTotalOutStandingAmount = TotalOutStandingAmount();
                                lblSumTotalOutStandingAmount.Text = SumTotalOutStandingAmount.ToString();

                                double SumTotalCurrentPaidAmount = TotalCurrentPaidAmount();
                                lblSumTotalCurrentPaidAmount.Text = SumTotalCurrentPaidAmount.ToString();

                                TxtAdvanceAmt.Text = lblSumTotalLoanAmount.Text;
                            }
                        }
                      }

                    }

                else
                {
                    TxtAdvanceAmt.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtPaidAmt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                Label lblSumTotalLoanAmount = (Label)(GvLoanSetOffTransaction.FooterRow.FindControl("lblSumTotalLoanAmount"));
                Label lblSumTotalPaidAmount = (Label)(GvLoanSetOffTransaction.FooterRow.FindControl("lblSumTotalPaidAmount"));
                Label lblSumTotalOutStandingAmount = (Label)(GvLoanSetOffTransaction.FooterRow.FindControl("lblSumTotalOutStandingAmount"));
                Label lblSumTotalCurrentPaidAmount = (Label)(GvLoanSetOffTransaction.FooterRow.FindControl("lblSumTotalCurrentPaidAmount"));

                double SumTotalLoanAmount = TotalLoanAmount();
                lblSumTotalLoanAmount.Text = SumTotalLoanAmount.ToString();

                double SumTotalPaidAmount = TotalPaidAmount();
                lblSumTotalPaidAmount.Text = SumTotalPaidAmount.ToString();

                double SumTotalOutStandingAmount = TotalOutStandingAmount();
                lblSumTotalOutStandingAmount.Text = SumTotalOutStandingAmount.ToString();

                double SumTotalCurrentPaidAmount = TotalCurrentPaidAmount();
                lblSumTotalCurrentPaidAmount.Text = SumTotalCurrentPaidAmount.ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvLoanSetOffTransaction_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    //Label lblSumTotalLoanAmount = (Label)e.Row.FindControl("lblSumTotalLoanAmount");
                    //Label lblSumTotalPaidAmount = (Label)e.Row.FindControl("lblSumTotalPaidAmount");
                    //Label lblSumTotalOutStandingAmount = (Label)e.Row.FindControl("lblSumTotalOutStandingAmount");
                    //Label lblSumTotalCurrentPaidAmount = (Label)e.Row.FindControl("lblSumTotalCurrentPaidAmount");
                

                    //double SumTotalLoanAmount = TotalLoanAmount();
                    //lblSumTotalLoanAmount.Text = SumTotalLoanAmount.ToString();

                    //double SumTotalPaidAmount = TotalPaidAmount();
                    //lblSumTotalPaidAmount.Text = SumTotalPaidAmount.ToString();

                    //double SumTotalOutStandingAmount = TotalOutStandingAmount();
                    //lblSumTotalOutStandingAmount.Text = SumTotalOutStandingAmount.ToString();

                    //double SumTotalCurrentPaidAmount = TotalCurrentPaidAmount();
                    //lblSumTotalCurrentPaidAmount.Text = SumTotalCurrentPaidAmount.ToString();


                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlConfirmFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlConfirmFlag.SelectedValue == "Y")
                {
                    TxtConfirmBy.Text = Session["USERNAME"].ToString();
                    TxtConfirmDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    TxtConfirmBy.Text = "";
                    TxtConfirmDate.Text = "";
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void DdlApprovalFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (DdlApprovalFlag.SelectedValue == "Y")
                    {
                        TxtApprovalBy.Text = Session["USERNAME"].ToString();
                        TxtApprovalDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        TxtApprovalBy.Text = "";
                        TxtApprovalDate.Text = "";
                    }
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
    }
}