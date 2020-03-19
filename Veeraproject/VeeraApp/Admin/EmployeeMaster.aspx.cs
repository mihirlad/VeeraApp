using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class EmployeeMaster : System.Web.UI.Page
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
                    SetInitialRowIncrement();
                    FillDdlBranchName();
                    FillEMPLOYEE_MASTERGrid(Session["COMP_CODE"].ToString());
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

            HfCompCode.Value = string.Empty;
            HfBranchCode.Value = string.Empty;
            HfEmployeeCode.Value = string.Empty;
            HfCreditExpenceACODE.Value = string.Empty;
            HfDebitExpenceACODE.Value = string.Empty;

            TxtRefEmpCode.Text = string.Empty;
            TxtEmployeeName.Text = string.Empty;
            TxtJobCategory.Text = string.Empty;
            TxtDesignation.Text = string.Empty;
            DdlBranchName.SelectedValue = "0";
            TxtCreditExpenceACName.Text = string.Empty;
            TxtDebitExpenceACName.Text = string.Empty;
            TxtEmpCurrentADD1.Text = string.Empty;
            TxtEmpCurrentADD2.Text = string.Empty;
            TxtEmpCurrentADD3.Text = string.Empty;
            TxtEmpCurrentADD4.Text = string.Empty;
            TxtEmpCurrentPhone_M.Text = string.Empty;
            TxtEmpCurrentPhone_R.Text = string.Empty;
            TxtEmpPermanantADD1.Text = string.Empty;
            TxtEmpPermanantADD2.Text = string.Empty;
            TxtEmpPermanantADD3.Text = string.Empty;
            TxtEmpPermanantADD4.Text = string.Empty;
            TxtEmpPermanantPhone_M.Text = string.Empty;
            TxtEmpPermanantPhone_R.Text = string.Empty;
            TxtEmpCurrentRefContactName.Text = string.Empty;
            TxtEmpCurrentRefContactPhone.Text = string.Empty;
            TxtEmpPermanentRefContactName.Text = string.Empty;
            TxtEmpPermanentRefContactPhone.Text = string.Empty;
            TxtJoinDate.Text = string.Empty;
            TxtLeftDate.Text = string.Empty;
            TxtBirthDate.Text = string.Empty;
            TxtPANNo.Text = string.Empty;
            TxtAadharCardNo.Text = string.Empty;
            DdlActiveFlag.SelectedValue = "0";
            DdlSalaryFlag.SelectedValue = "0";

            SetInitialRowIncrement();

            BtncallUpd.Text = "SAVE";


        }


        public void ControllerEnable()
        {
            TxtRefEmpCode.Enabled = true;
            TxtEmployeeName.Enabled = true;
            TxtJobCategory.Enabled = true;
            TxtDesignation.Enabled = true;
            DdlBranchName.Enabled = true;
            TxtCreditExpenceACName.Enabled = true;
            TxtDebitExpenceACName.Enabled = true;
            TxtEmpCurrentADD1.Enabled = true;
            TxtEmpCurrentADD2.Enabled = true;
            TxtEmpCurrentADD3.Enabled = true;
            TxtEmpCurrentADD4.Enabled = true;
            TxtEmpCurrentPhone_M.Enabled = true;
            TxtEmpCurrentPhone_R.Enabled = true;
            TxtEmpPermanantADD1.Enabled = true;
            TxtEmpPermanantADD2.Enabled = true;
            TxtEmpPermanantADD3.Enabled = true;
            TxtEmpPermanantADD4.Enabled = true;
            TxtEmpPermanantPhone_M.Enabled = true;
            TxtEmpPermanantPhone_R.Enabled = true;
            TxtEmpCurrentRefContactName.Enabled = true;
            TxtEmpCurrentRefContactPhone.Enabled = true;
            TxtEmpPermanentRefContactName.Enabled = true;
            TxtEmpPermanentRefContactPhone.Enabled = true;
            TxtJoinDate.Enabled = true;
            TxtLeftDate.Enabled = true;
            TxtBirthDate.Enabled = true;
            TxtPANNo.Enabled = true;
            TxtAadharCardNo.Enabled = true;
            DdlSalaryFlag.Enabled = true;
            DdlActiveFlag.Enabled = true;

        }


        public void ControllerDisable()
        {
            TxtRefEmpCode.Enabled = false;
            TxtEmployeeName.Enabled = false;
            TxtJobCategory.Enabled = false;
            TxtDesignation.Enabled = false;
            DdlBranchName.Enabled = false;
            TxtCreditExpenceACName.Enabled = false;
            TxtDebitExpenceACName.Enabled = false;
            TxtEmpCurrentADD1.Enabled = false;
            TxtEmpCurrentADD2.Enabled = false;
            TxtEmpCurrentADD3.Enabled = false;
            TxtEmpCurrentADD4.Enabled = false;
            TxtEmpCurrentPhone_M.Enabled = false;
            TxtEmpCurrentPhone_R.Enabled = false;
            TxtEmpPermanantADD1.Enabled = false;
            TxtEmpPermanantADD2.Enabled = false;
            TxtEmpPermanantADD3.Enabled = false;
            TxtEmpPermanantADD4.Enabled = false;
            TxtEmpPermanantPhone_M.Enabled = false;
            TxtEmpPermanantPhone_R.Enabled = false;
            TxtEmpCurrentRefContactName.Enabled = false;
            TxtEmpCurrentRefContactPhone.Enabled = false;
            TxtEmpPermanentRefContactName.Enabled = false;
            TxtEmpPermanentRefContactPhone.Enabled = false;
            TxtJoinDate.Enabled = false;
            TxtLeftDate.Enabled = false;
            TxtBirthDate.Enabled = false;
            TxtPANNo.Enabled = false;
            TxtAadharCardNo.Enabled = false;
            DdlSalaryFlag.Enabled = false;
            DdlActiveFlag.Enabled = false; 
        }


        private void SetInitialRowIncrement()
        {

      
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("YRDT1", typeof(string));
            table.Columns.Add("EMP_CODE", typeof(string));
            table.Columns.Add("BASIC_RATE", typeof(string));
            table.Columns.Add("CONV_RATE", typeof(string));
            table.Columns.Add("MEDICAL_RATE", typeof(string));
            table.Columns.Add("HRA_RATE", typeof(string));
            table.Columns.Add("OLD_BASIC_RATE", typeof(string));
            table.Columns.Add("OLD_CONV_RATE", typeof(string));
            table.Columns.Add("OLD_MEDICAL_RATE", typeof(string));
            table.Columns.Add("OLD_HRA_RATE", typeof(string));
            table.Columns.Add("REMARK", typeof(string));
            table.Columns.Add("INS_USERID", typeof(string));
            table.Columns.Add("INS_DATE", typeof(string));
            table.Columns.Add("UPD_USERID", typeof(string));
            table.Columns.Add("UPD_DATE", typeof(string));
            table.Columns.Add("YRDT2", typeof(string));

            dr = table.NewRow();

            dr["COMP_CODE"] = string.Empty;
            dr["YRDT1"] = string.Empty;
            dr["EMP_CODE"] = string.Empty;
            dr["BASIC_RATE"] = string.Empty;
            dr["CONV_RATE"] = string.Empty;
            dr["MEDICAL_RATE"] = string.Empty;
            dr["HRA_RATE"] = string.Empty;
            dr["OLD_BASIC_RATE"] = string.Empty;
            dr["OLD_CONV_RATE"] = string.Empty;
            dr["OLD_MEDICAL_RATE"] = string.Empty;
            dr["OLD_HRA_RATE"] = string.Empty;
            dr["REMARK"] = string.Empty;
            dr["INS_USERID"] = string.Empty;
            dr["INS_DATE"] = string.Empty;
            dr["UPD_USERID"] = string.Empty;
            dr["UPD_DATE"] = string.Empty;
            dr["YRDT2"] = string.Empty;



            table.Rows.Add(dr);

            ViewState["IncrementTranTable"] = table;

            GvIncrementTransactionDetails.DataSource = table;
            GvIncrementTransactionDetails.DataBind();

        }


        public void FillDdlBranchName()
        {
            try
            {
                DataTable Dt = new DataTable();
                // string COMPANYCODE = DdlCompany.SelectedValue;

                Dt = BRANCH_MASLogicLayer.GetBranchDetailCompanyWiseFor_Ddl(compcode);
                DdlBranchName.DataSource = Dt;
                DdlBranchName.DataValueField = "BRANCH_CODE";
                DdlBranchName.DataTextField = "BRANCH_NAME";
                DdlBranchName.DataBind();


            }
            catch (Exception)
            {

                throw;
            }
        }



        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetEmployeeDesignationName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from DESIGN_MAS WHERE DESIGN_NAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> Designation = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Designation.Add(dt.Rows[i][1].ToString());
            }
            return Designation;
        }



        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetEmployeeJobCategory(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CATAGORY_MAS WHERE CAT_NAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> Cat_Name = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cat_Name.Add(dt.Rows[i][1].ToString());
            }
            return Cat_Name;
        }



        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetAccountName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ACCOUNTS where COMP_CODE=@COMP_CODE AND BRANCH_CODE=@BRANCH_CODE  AND ANAME like @name + '%'", con);
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


        protected void TxtJobCategory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtCategoryName = new DataTable();
                DtCategoryName = CATAGORY_MASLogicLayer.GetAllEmployeeCATEGORY_MASForEmp();

                if (TxtJobCategory.Text != string.Empty)
                {


                    DataView Dv = new DataView(DtCategoryName);
                    Dv.RowFilter = "CAT_NAME='" + TxtJobCategory.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfCategoryCode.Value = DtView.Rows[0]["CAT_CODE"].ToString();
                        TxtJobCategory.Text = DtView.Rows[0]["CAT_NAME"].ToString();

                    }
                }
                else
                {

                    HfCategoryCode.Value = string.Empty;
                    TxtJobCategory.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void TxtDesignation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtDesignName = new DataTable();
                DtDesignName = DESIGN_MASLogicLayer.GetAllDESIGNATION_MASDetialsForEmp();

                if (TxtDesignation.Text != string.Empty)
                {


                    DataView Dv = new DataView(DtDesignName);
                    Dv.RowFilter = "DESIGN_NAME='" + TxtDesignation.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfDesignationCode.Value = DtView.Rows[0]["DESIGN_CODE"].ToString();
                        TxtDesignation.Text = DtView.Rows[0]["DESIGN_NAME"].ToString();

                    }
                }
                else
                {

                    HfDesignationCode.Value = string.Empty;
                    TxtDesignation.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }          
        }



        protected void TxtCreditExpenceACName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtAccountName = new DataTable();

                DtAccountName = ACCOUNTS_MASLogicLayer.GetAllACCOUNTDetialsByComapnyAndBranch(compcode, Branchcode);
                if (TxtCreditExpenceACName.Text != string.Empty && TxtCreditExpenceACName.Text != null)
                {
                    DataView Dv = new DataView(DtAccountName);
                    Dv.RowFilter = "ANAME='" + TxtCreditExpenceACName.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfCreditExpenceACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                        TxtCreditExpenceACName.Text = DtView.Rows[0]["ANAME"].ToString();
                        //    DdlPartyType.SelectedValue = DtView.Rows[0]["PARTY_TYPE"].ToString();

                    }
                    else
                    {

                        HfCreditExpenceACODE.Value = string.Empty;
                        TxtCreditExpenceACName.Text = string.Empty;
                    }
                }
              
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtDebitExpenceACName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtAccountName = new DataTable();

                DtAccountName = ACCOUNTS_MASLogicLayer.GetAllACCOUNTDetialsByComapnyAndBranch(compcode, Branchcode);
                if (TxtDebitExpenceACName.Text != string.Empty && TxtDebitExpenceACName.Text != null)
                {
                    DataView Dv = new DataView(DtAccountName);
                    Dv.RowFilter = "ANAME='" + TxtDebitExpenceACName.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfDebitExpenceACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                        TxtDebitExpenceACName.Text = DtView.Rows[0]["ANAME"].ToString();
                  //    DdlPartyType.SelectedValue = DtView.Rows[0]["PARTY_TYPE"].ToString();

                    }
                    else
                    {

                        HfDebitExpenceACODE.Value = string.Empty;
                        TxtDebitExpenceACName.Text = string.Empty;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
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
                TxtJoinDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            lblmsg.Text = string.Empty;
            UserRights();
        }


        public void FillEMPLOYEE_MASTERGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = EMP_MASLogicLayer.GetAllEMPLOYEE_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvEmployeeMaster.DataSource = Dv.ToTable();
            GvEmployeeMaster.DataBind();

            DtSearch = Dv.ToTable();

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
                    #region INSERT INTO EMPLOYEE MASTER DETAILS

                    EMP_MASLogicLayer insert = new EMP_MASLogicLayer();

                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.EMP_CODE = HfEmployeeCode.Value.Trim();
                    insert.EMP_NAME = TxtEmployeeName.Text.Trim().ToUpper().ToString();
                    insert.EMP_ADD1 = TxtEmpCurrentADD1.Text.Trim().ToUpper().ToString();
                    insert.EMP_ADD2 = TxtEmpCurrentADD2.Text.Trim().ToUpper().ToString();
                    insert.EMP_ADD3 = TxtEmpCurrentADD3.Text.Trim().ToUpper().ToString();
                    insert.EMP_ADD4 = TxtEmpCurrentADD4.Text.Trim().ToUpper().ToString();
                    insert.EMP_PHONE_R = TxtEmpCurrentPhone_R.Text.Trim().ToString();
                    insert.EMP_PHONE_M = TxtEmpCurrentPhone_M.Text.Trim().ToString();
                    if(TxtJoinDate.Text!=string.Empty)
                    {
                        insert.JOIN_DATE = Convert.ToDateTime(TxtJoinDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.JOIN_DATE = "";
                    }
                  
                    if(TxtLeftDate.Text!=string.Empty)
                    {
                        insert.LEFT_DATE = Convert.ToDateTime(TxtLeftDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.LEFT_DATE ="";
                    }
                    
                    insert.PF_FLAG = null;
                    insert.PF_NO = null;
                    insert.ESIC_FLAG = null;
                    insert.ESIC_NO = null;
                    insert.PAN_NO = TxtPANNo.Text.Trim().ToString();
                    if(TxtJobCategory.Text!=string.Empty)
                    {
                        insert.CAT_CODE = HfCategoryCode.Value.Trim();
                    }
                    else
                    {
                        insert.CAT_CODE = null;
                    }

                    insert.SAL_FLAG = DdlSalaryFlag.SelectedValue.Trim().ToString();
                    insert.BASIC_RATE = null;
                    insert.CONV_RATE = null;
                    insert.MEDICAL_RATE = null;
                    insert.HRA_RATE = null;
                    insert.BASIC_RATE1 = null;
                    insert.CONV_RATE1 = null;
                    insert.MEDICAL_RATE1 = null;
                    insert.HRA_RATE1 = null;
                    insert.ACTIVE = DdlActiveFlag.SelectedValue.Trim().ToString();
                    insert.ENDT = "";
                    insert.OT_FLAG = null;
                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();

                    if(TxtCreditExpenceACName.Text!=string.Empty)
                    {
                        insert.CRACODE1 = HfCreditExpenceACODE.Value.Trim();
                    }
                    else
                    {
                        insert.CRACODE1 = null;
                    }
                  
                    if(TxtDebitExpenceACName.Text!=string.Empty)
                    {
                        insert.DRACODE1 = HfDebitExpenceACODE.Value.Trim();
                    }
                    else
                    {
                        insert.DRACODE1 = null;
                    }

                    insert.EMP_REFNAME = TxtEmpCurrentRefContactName.Text.Trim().ToUpper().ToString();
                    insert.EMP_REFPHONE = TxtEmpCurrentRefContactPhone.Text.Trim().ToUpper().ToString();
                    insert.PER_ADD1 = TxtEmpPermanantADD1.Text.Trim().ToUpper().ToString();
                    insert.PER_ADD2 = TxtEmpPermanantADD2.Text.Trim().ToUpper().ToString();
                    insert.PER_ADD3 = TxtEmpPermanantADD3.Text.Trim().ToUpper().ToString();
                    insert.PER_ADD4 = TxtEmpPermanantADD4.Text.Trim().ToUpper().ToString();
                    insert.PER_PHONE_R = TxtEmpPermanantPhone_R.Text.Trim().ToString();
                    insert.PER_PHONE_M = TxtEmpPermanantPhone_M.Text.Trim().ToString();
                    insert.PER_REFNAME = TxtEmpPermanentRefContactName.Text.Trim().ToUpper().ToString();
                    insert.PER_REFPHONE = TxtEmpPermanentRefContactPhone.Text.Trim().ToUpper().ToString();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_DATE =  "";
                    //insert.UPD_USERID = Session["USERNAME"].ToString();
                    //insert.UPD_DATE = "";
                    insert.ADHAR_NO = TxtAadharCardNo.Text.Trim().ToString();
                    if(TxtDesignation.Text!=string.Empty)
                    {
                        insert.DESIGN_CODE = HfDesignationCode.Value.Trim();
                    }
                    else
                    {
                        insert.DESIGN_CODE = null;
                    }

                    insert.REF_EMPCODE = TxtRefEmpCode.Text.Trim();
                    if(TxtBirthDate.Text!=string.Empty)
                    {
                        insert.DOB_DATE = Convert.ToDateTime(TxtBirthDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.DOB_DATE = "";
                    }
                 
                    insert.HOME_LATITUDE = null;
                    insert.HOME_LONGITUDE = null;


                    string str = EMP_MASLogicLayer.InsertEMPLOYEE_MASDetails(insert);

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "EMPLOYEE MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillEMPLOYEE_MASTERGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "EMPLOYEE MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : EMPLOYEE MASTER NOT SAVED";
                        lblmsg.ForeColor = Color.Red;

                    }

                    #endregion
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Btncalldel_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE  

                string str = EMP_MASLogicLayer.DeleteEMPLOYEE_MASDetaislByID(HfEmployeeCode.Value.Trim());
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
                    lblmsg.Text = "Error:Employee Master Deleted";
                    lblmsg.ForeColor = Color.Red;
                }
                clear();
                UserRights();
                FillEMPLOYEE_MASTERGrid(Convert.ToString(Session["COMP_CODE"]));

                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region UPDATE EMPLOYEE MASTER DETAILS

                #region INSERT INTO EMPLOYEE MASTER DETAILS

                EMP_MASLogicLayer insert = new EMP_MASLogicLayer();

                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.EMP_CODE = HfEmployeeCode.Value.Trim();
                insert.EMP_NAME = TxtEmployeeName.Text.Trim().ToUpper().ToString();
                insert.EMP_ADD1 = TxtEmpCurrentADD1.Text.Trim().ToUpper().ToString();
                insert.EMP_ADD2 = TxtEmpCurrentADD2.Text.Trim().ToUpper().ToString();
                insert.EMP_ADD3 = TxtEmpCurrentADD3.Text.Trim().ToUpper().ToString();
                insert.EMP_ADD4 = TxtEmpCurrentADD4.Text.Trim().ToUpper().ToString();
                insert.EMP_PHONE_R = TxtEmpCurrentPhone_R.Text.Trim().ToString();
                insert.EMP_PHONE_M = TxtEmpCurrentPhone_M.Text.Trim().ToString();
                if (TxtJoinDate.Text != string.Empty)
                {
                    insert.JOIN_DATE = Convert.ToDateTime(TxtJoinDate.Text.Trim()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.JOIN_DATE = "";
                }

                if (TxtLeftDate.Text != string.Empty)
                {
                    insert.LEFT_DATE = Convert.ToDateTime(TxtLeftDate.Text.Trim()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.LEFT_DATE = "";
                }

                insert.PF_FLAG = null;
                insert.PF_NO = null;
                insert.ESIC_FLAG = null;
                insert.ESIC_NO = null;
                insert.PAN_NO = TxtPANNo.Text.Trim().ToString();
                if (TxtJobCategory.Text != string.Empty)
                {
                    insert.CAT_CODE = HfCategoryCode.Value.Trim();
                }
                else
                {
                    insert.CAT_CODE = null;
                }

                insert.SAL_FLAG = DdlSalaryFlag.SelectedValue.Trim().ToString();
                insert.BASIC_RATE = null;
                insert.CONV_RATE = null;
                insert.MEDICAL_RATE = null;
                insert.HRA_RATE = null;
                insert.BASIC_RATE1 = null;
                insert.CONV_RATE1 = null;
                insert.MEDICAL_RATE1 = null;
                insert.HRA_RATE1 = null;
                insert.ACTIVE = DdlActiveFlag.SelectedValue.Trim().ToString();
                insert.ENDT = "";
                insert.OT_FLAG = null;
                insert.BRANCH_CODE = HfBranchCode.Value.Trim();

                if (TxtCreditExpenceACName.Text != string.Empty)
                {
                    insert.CRACODE1 = HfCreditExpenceACODE.Value.Trim();
                }
                else
                {
                    insert.CRACODE1 = null;
                }

                if (TxtDebitExpenceACName.Text != string.Empty)
                {
                    insert.DRACODE1 = HfDebitExpenceACODE.Value.Trim();
                }
                else
                {
                    insert.DRACODE1 = null;
                }

                insert.EMP_REFNAME = TxtEmpCurrentRefContactName.Text.Trim().ToUpper().ToString();
                insert.EMP_REFPHONE = TxtEmpCurrentRefContactPhone.Text.Trim().ToUpper().ToString();
                insert.PER_ADD1 = TxtEmpPermanantADD1.Text.Trim().ToUpper().ToString();
                insert.PER_ADD2 = TxtEmpPermanantADD2.Text.Trim().ToUpper().ToString();
                insert.PER_ADD3 = TxtEmpPermanantADD3.Text.Trim().ToUpper().ToString();
                insert.PER_ADD4 = TxtEmpPermanantADD4.Text.Trim().ToUpper().ToString();
                insert.PER_PHONE_R = TxtEmpPermanantPhone_R.Text.Trim().ToString();
                insert.PER_PHONE_M = TxtEmpPermanantPhone_M.Text.Trim().ToString();
                insert.PER_REFNAME = TxtEmpPermanentRefContactName.Text.Trim().ToUpper().ToString();
                insert.PER_REFPHONE = TxtEmpPermanentRefContactPhone.Text.Trim().ToUpper().ToString();
                //insert.INS_USERID = Session["USERNAME"].ToString();
                //insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_DATE = "";
                insert.ADHAR_NO = TxtAadharCardNo.Text.Trim().ToString();
                if (TxtDesignation.Text != string.Empty)
                {
                    insert.DESIGN_CODE = HfDesignationCode.Value.Trim();
                }
                else
                {
                    insert.DESIGN_CODE = null;
                }

                insert.REF_EMPCODE = TxtRefEmpCode.Text.Trim();
                if (TxtBirthDate.Text != string.Empty)
                {
                    insert.DOB_DATE = Convert.ToDateTime(TxtBirthDate.Text.Trim()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.DOB_DATE = "";
                }

                insert.HOME_LATITUDE = null;
                insert.HOME_LONGITUDE = null;
                string str = EMP_MASLogicLayer.UpdateEMPLOYEE_MASDetails(insert);

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "EMPLOYEE MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillEMPLOYEE_MASTERGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "EMPLOYEE MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : EMPLOYEE MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }

                #endregion

                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

      

        public void FillCategoryNameOnUpdate(string Cat_Code)
        {
            try
            {
                DataTable DtCategoryName = new DataTable();
                DtCategoryName = CATAGORY_MASLogicLayer.GetAllEmployeeCATEGORY_MASForEmp();

                if (Cat_Code != string.Empty && Cat_Code!=null)
                {

                    DataView Dv = new DataView(DtCategoryName);
                    Dv.RowFilter = "CAT_CODE='" + Cat_Code.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfCategoryCode.Value = DtView.Rows[0]["CAT_CODE"].ToString();
                        TxtJobCategory.Text = DtView.Rows[0]["CAT_NAME"].ToString();

                    }
                }
                else
                {

                    HfCategoryCode.Value = string.Empty;
                    TxtJobCategory.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDesignationNameOnUpdate(string Design_Code)
        {
            try
            {
                DataTable DtDesignName = new DataTable();
                DtDesignName = DESIGN_MASLogicLayer.GetAllDESIGNATION_MASDetialsForEmp();

                if (Design_Code != string.Empty && Design_Code!=null)
                {

                    DataView Dv = new DataView(DtDesignName);
                    Dv.RowFilter = "DESIGN_CODE='" + Design_Code.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfDesignationCode.Value = DtView.Rows[0]["DESIGN_CODE"].ToString();
                        TxtDesignation.Text = DtView.Rows[0]["DESIGN_NAME"].ToString();

                    }
                }
                else
                {

                    HfDesignationCode.Value = string.Empty;
                    TxtDesignation.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillCreditAccountNameOnUpdate(string CRACODE)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Brabch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTWiseComapnyAndBranchForInvoice(Comp_Code, Brabch_Code);

                    if (HfCreditExpenceACODE.Value.ToString() != "0" && HfCreditExpenceACODE.Value != null && HfCreditExpenceACODE.Value.ToString() != string.Empty)
                    {
                        DataView Dv = new DataView(Dt);
                        Dv.RowFilter = "ACODE=" + CRACODE;
                        DataTable DtView = Dv.ToTable();

                        TxtCreditExpenceACName.Text = DtView.Rows[0]["ANAME"].ToString();
                        HfCreditExpenceACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                    }
                    else
                    {
                    TxtCreditExpenceACName.Text = string.Empty;
                    HfCreditExpenceACODE.Value = string.Empty;
                    }
                         
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDebitAccountNameOnUpdate(string DRACODE)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Brabch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTWiseComapnyAndBranchForInvoice(Comp_Code, Brabch_Code);

                if (HfDebitExpenceACODE.Value.ToString() != "0" && HfDebitExpenceACODE.Value != null && HfDebitExpenceACODE.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "ACODE=" + DRACODE;
                    DataTable DtView = Dv.ToTable();

                    TxtDebitExpenceACName.Text = DtView.Rows[0]["ANAME"].ToString();
                    HfDebitExpenceACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                }
                else
                {
                    TxtDebitExpenceACName.Text = string.Empty;
                    HfDebitExpenceACODE.Value = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillIncreamentTransactionGridOnUpdate(string Comp_Code, string Emp_Code)
        {
            try
            {
                if(Comp_Code!=string.Empty && Emp_Code!=string.Empty)
                {
                    DataTable Dt = new DataTable();
                    Dt = INCREMENT_MASLogicLayer.GetAllEMPLOYEE_INCREMENT_TRANDetailsByEmp_Code(Comp_Code, Emp_Code);
                    GvIncrementTransactionDetails.DataSource = Dt;
                    GvIncrementTransactionDetails.DataBind();
                    GvIncrementTransactionDetails.Enabled = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvEmployeeMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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


                        DataTable dt = EMP_MASLogicLayer.GetAllIDWiseEMPLOYEE_MASDetails(e.CommandArgument.ToString());


                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfEmployeeCode.Value = dt.Rows[0]["EMP_CODE"].ToString();
                            TxtRefEmpCode.Text = dt.Rows[0]["REF_EMPCODE"].ToString();
                            TxtEmployeeName.Text = dt.Rows[0]["EMP_NAME"].ToString();
                            TxtJobCategory.Text = dt.Rows[0]["CAT_CODE"].ToString();
                            FillCategoryNameOnUpdate(dt.Rows[0]["CAT_CODE"].ToString());
                            TxtDesignation.Text = dt.Rows[0]["DESIGN_CODE"].ToString();
                            FillDesignationNameOnUpdate(dt.Rows[0]["DESIGN_CODE"].ToString());
                            DdlBranchName.Text = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfCreditExpenceACODE.Value = dt.Rows[0]["CRACODE1"].ToString();
                            FillCreditAccountNameOnUpdate(dt.Rows[0]["CRACODE1"].ToString());
                            HfDebitExpenceACODE.Value = dt.Rows[0]["DRACODE1"].ToString();
                            FillDebitAccountNameOnUpdate(dt.Rows[0]["DRACODE1"].ToString());
                            TxtEmpCurrentADD1.Text= dt.Rows[0]["EMP_ADD1"].ToString();
                            TxtEmpCurrentADD2.Text = dt.Rows[0]["EMP_ADD2"].ToString();
                            TxtEmpCurrentADD3.Text = dt.Rows[0]["EMP_ADD3"].ToString();
                            TxtEmpCurrentADD4.Text = dt.Rows[0]["EMP_ADD4"].ToString();
                            TxtEmpPermanantADD1.Text = dt.Rows[0]["PER_ADD1"].ToString();
                            TxtEmpPermanantADD2.Text = dt.Rows[0]["PER_ADD2"].ToString();
                            TxtEmpPermanantADD3.Text = dt.Rows[0]["PER_ADD3"].ToString();
                            TxtEmpPermanantADD4.Text = dt.Rows[0]["PER_ADD4"].ToString();
                            TxtEmpCurrentPhone_M.Text = dt.Rows[0]["EMP_PHONE_M"].ToString();
                            TxtEmpCurrentPhone_R.Text = dt.Rows[0]["EMP_PHONE_R"].ToString();
                            TxtEmpPermanantPhone_M.Text = dt.Rows[0]["PER_PHONE_M"].ToString();
                            TxtEmpPermanantPhone_R.Text = dt.Rows[0]["PER_PHONE_R"].ToString();
                            TxtEmpCurrentRefContactName.Text = dt.Rows[0]["EMP_REFNAME"].ToString();
                            TxtEmpCurrentRefContactPhone.Text = dt.Rows[0]["EMP_REFPHONE"].ToString();
                            TxtEmpPermanentRefContactName.Text = dt.Rows[0]["PER_REFNAME"].ToString();
                            TxtEmpPermanentRefContactPhone.Text = dt.Rows[0]["PER_REFPHONE"].ToString();
                            TxtJoinDate.Text = Convert.ToDateTime(dt.Rows[0]["JOIN_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtLeftDate.Text = dt.Rows[0]["LEFT_DATE"].ToString();
                            TxtBirthDate.Text = Convert.ToDateTime(dt.Rows[0]["DOB_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtPANNo.Text = dt.Rows[0]["PAN_NO"].ToString();
                            TxtAadharCardNo.Text = dt.Rows[0]["ADHAR_NO"].ToString();
                            DdlActiveFlag.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                            DdlSalaryFlag.SelectedValue = dt.Rows[0]["SAL_FLAG"].ToString();

                            FillIncreamentTransactionGridOnUpdate(HfCompCode.Value.ToString(), HfEmployeeCode.Value.ToString());
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

                        DataTable dt = EMP_MASLogicLayer.GetAllIDWiseEMPLOYEE_MASDetails(e.CommandArgument.ToString());


                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfEmployeeCode.Value = dt.Rows[0]["EMP_CODE"].ToString();
                            TxtRefEmpCode.Text = dt.Rows[0]["REF_EMPCODE"].ToString();
                            TxtEmployeeName.Text = dt.Rows[0]["EMP_NAME"].ToString();
                            TxtJobCategory.Text = dt.Rows[0]["CAT_CODE"].ToString();
                            FillCategoryNameOnUpdate(dt.Rows[0]["CAT_CODE"].ToString());
                            TxtDesignation.Text = dt.Rows[0]["DESIGN_CODE"].ToString();
                            FillDesignationNameOnUpdate(dt.Rows[0]["DESIGN_CODE"].ToString());
                            DdlBranchName.Text = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfCreditExpenceACODE.Value = dt.Rows[0]["CRACODE1"].ToString();
                            FillCreditAccountNameOnUpdate(dt.Rows[0]["CRACODE1"].ToString());
                            HfDebitExpenceACODE.Value = dt.Rows[0]["DRACODE1"].ToString();
                            FillDebitAccountNameOnUpdate(dt.Rows[0]["DRACODE1"].ToString());
                            TxtEmpCurrentADD1.Text = dt.Rows[0]["EMP_ADD1"].ToString();
                            TxtEmpCurrentADD2.Text = dt.Rows[0]["EMP_ADD2"].ToString();
                            TxtEmpCurrentADD3.Text = dt.Rows[0]["EMP_ADD3"].ToString();
                            TxtEmpCurrentADD4.Text = dt.Rows[0]["EMP_ADD4"].ToString();
                            TxtEmpPermanantADD1.Text = dt.Rows[0]["PER_ADD1"].ToString();
                            TxtEmpPermanantADD2.Text = dt.Rows[0]["PER_ADD2"].ToString();
                            TxtEmpPermanantADD3.Text = dt.Rows[0]["PER_ADD3"].ToString();
                            TxtEmpPermanantADD4.Text = dt.Rows[0]["PER_ADD4"].ToString();
                            TxtEmpCurrentPhone_M.Text = dt.Rows[0]["EMP_PHONE_M"].ToString();
                            TxtEmpCurrentPhone_R.Text = dt.Rows[0]["EMP_PHONE_R"].ToString();
                            TxtEmpPermanantPhone_M.Text = dt.Rows[0]["PER_PHONE_M"].ToString();
                            TxtEmpPermanantPhone_R.Text = dt.Rows[0]["PER_PHONE_R"].ToString();
                            TxtEmpCurrentRefContactName.Text = dt.Rows[0]["EMP_REFNAME"].ToString();
                            TxtEmpCurrentRefContactPhone.Text = dt.Rows[0]["EMP_REFPHONE"].ToString();
                            TxtEmpPermanentRefContactName.Text = dt.Rows[0]["PER_REFNAME"].ToString();
                            TxtEmpPermanentRefContactPhone.Text = dt.Rows[0]["PER_REFPHONE"].ToString();
                            TxtJoinDate.Text = Convert.ToDateTime(dt.Rows[0]["JOIN_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtLeftDate.Text = dt.Rows[0]["LEFT_DATE"].ToString();
                            TxtBirthDate.Text = Convert.ToDateTime(dt.Rows[0]["DOB_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtPANNo.Text = dt.Rows[0]["PAN_NO"].ToString();
                            TxtAadharCardNo.Text = dt.Rows[0]["ADHAR_NO"].ToString();
                            DdlActiveFlag.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                            DdlSalaryFlag.SelectedValue = dt.Rows[0]["SAL_FLAG"].ToString();

                            FillIncreamentTransactionGridOnUpdate(HfCompCode.Value.ToString(), HfEmployeeCode.Value.ToString());


                        }

                    }

                    BtncallUpd.Text = "UPDATE";

                    #endregion
               

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


                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataTable dt = EMP_MASLogicLayer.GetAllIDWiseEMPLOYEE_MASDetails(e.CommandArgument.ToString());


                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfEmployeeCode.Value = dt.Rows[0]["EMP_CODE"].ToString();
                            TxtRefEmpCode.Text = dt.Rows[0]["REF_EMPCODE"].ToString();
                            TxtEmployeeName.Text = dt.Rows[0]["EMP_NAME"].ToString();
                            TxtJobCategory.Text = dt.Rows[0]["CAT_CODE"].ToString();
                            FillCategoryNameOnUpdate(dt.Rows[0]["CAT_CODE"].ToString());
                            TxtDesignation.Text = dt.Rows[0]["DESIGN_CODE"].ToString();
                            FillDesignationNameOnUpdate(dt.Rows[0]["DESIGN_CODE"].ToString());
                            DdlBranchName.Text = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfCreditExpenceACODE.Value = dt.Rows[0]["CRACODE1"].ToString();
                            FillCreditAccountNameOnUpdate(dt.Rows[0]["CRACODE1"].ToString());
                            HfDebitExpenceACODE.Value = dt.Rows[0]["DRACODE1"].ToString();
                            FillDebitAccountNameOnUpdate(dt.Rows[0]["DRACODE1"].ToString());
                            TxtEmpCurrentADD1.Text = dt.Rows[0]["EMP_ADD1"].ToString();
                            TxtEmpCurrentADD2.Text = dt.Rows[0]["EMP_ADD2"].ToString();
                            TxtEmpCurrentADD3.Text = dt.Rows[0]["EMP_ADD3"].ToString();
                            TxtEmpCurrentADD4.Text = dt.Rows[0]["EMP_ADD4"].ToString();
                            TxtEmpPermanantADD1.Text = dt.Rows[0]["PER_ADD1"].ToString();
                            TxtEmpPermanantADD2.Text = dt.Rows[0]["PER_ADD2"].ToString();
                            TxtEmpPermanantADD3.Text = dt.Rows[0]["PER_ADD3"].ToString();
                            TxtEmpPermanantADD4.Text = dt.Rows[0]["PER_ADD4"].ToString();
                            TxtEmpCurrentPhone_M.Text = dt.Rows[0]["EMP_PHONE_M"].ToString();
                            TxtEmpCurrentPhone_R.Text = dt.Rows[0]["EMP_PHONE_R"].ToString();
                            TxtEmpPermanantPhone_M.Text = dt.Rows[0]["PER_PHONE_M"].ToString();
                            TxtEmpPermanantPhone_R.Text = dt.Rows[0]["PER_PHONE_R"].ToString();
                            TxtEmpCurrentRefContactName.Text = dt.Rows[0]["EMP_REFNAME"].ToString();
                            TxtEmpCurrentRefContactPhone.Text = dt.Rows[0]["EMP_REFPHONE"].ToString();
                            TxtEmpPermanentRefContactName.Text = dt.Rows[0]["PER_REFNAME"].ToString();
                            TxtEmpPermanentRefContactPhone.Text = dt.Rows[0]["PER_REFPHONE"].ToString();
                            TxtJoinDate.Text = Convert.ToDateTime(dt.Rows[0]["JOIN_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtLeftDate.Text = dt.Rows[0]["LEFT_DATE"].ToString();
                            TxtBirthDate.Text = Convert.ToDateTime(dt.Rows[0]["DOB_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtPANNo.Text = dt.Rows[0]["PAN_NO"].ToString();
                            TxtAadharCardNo.Text = dt.Rows[0]["ADHAR_NO"].ToString();
                            DdlActiveFlag.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                            DdlSalaryFlag.SelectedValue = dt.Rows[0]["SAL_FLAG"].ToString();

                            FillIncreamentTransactionGridOnUpdate(HfCompCode.Value.ToString(), HfEmployeeCode.Value.ToString());
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
            catch (Exception ex)
            {

                ex.ToString();
            }
        }

        protected void GvEmployeeMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvEmployeeMaster.PageIndex = e.NewPageIndex;
            FillEMPLOYEE_MASTERGrid(Session["COMP_CODE"].ToString());
            clear();
        }

        protected void BtnAddDesignation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/DesignationMaster.aspx");
        }
    }
}