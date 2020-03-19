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
    public partial class EmployeeLoanMaster : System.Web.UI.Page
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
                    if (!string.IsNullOrWhiteSpace(Request.QueryString["TRAN_TYPE"]))
                    {
                        HfLoanType.Value = Request.QueryString["TRAN_TYPE"];
                    }

                    if (HfLoanType.Value == "L")
                    {
                        HdForAdvanceMaster.Visible = false;
                        HdForLoanMaster.Visible = true;
                    }
                    else if (HfLoanType.Value == "A")
                    {
                        HdForAdvanceMaster.Visible = true;
                        HdForLoanMaster.Visible = false;
                    }


                    DivEntry.Visible = false;
                    DivView.Visible = true;
                    FillLOAN_MasterGrid(Session["COMP_CODE"].ToString());
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
            HfEmployeeCode.Value = string.Empty;

            TxtLoanDate.Text = string.Empty;
            TxtEmployeeName.Text = string.Empty;
            TxtInstallMonth.Text = string.Empty;
            TxtPaidFromDate.Text = string.Empty;
            TxtPaidToDate.Text = string.Empty;
            TxtInstallAmount.Text = string.Empty;
            TxtLoanAmount.Text = string.Empty;
            TxtPaidAmount.Text = string.Empty;
            TxtRemark.Text = string.Empty;

            BtncallUpd.Text = "SAVE";

        }

        public void ControllerEnable()
        {
            TxtLoanDate.Enabled = true;
            TxtEmployeeName.Enabled = true;
            TxtInstallMonth.Enabled = true;
            TxtPaidFromDate.Enabled = true;
            TxtPaidToDate.Enabled = true;
            TxtInstallAmount.Enabled = true;
            TxtLoanAmount.Enabled = true;
            TxtPaidAmount.Enabled = true;
            TxtRemark.Enabled = true;
        }

        public void ControllerDisable()
        {
            TxtLoanDate.Enabled = false;
            TxtEmployeeName.Enabled = false;
            TxtInstallMonth.Enabled = false;
            TxtPaidFromDate.Enabled = false;
            TxtPaidToDate.Enabled = false;
            TxtInstallAmount.Enabled = false;
            TxtLoanAmount.Enabled = false;
            TxtPaidAmount.Enabled = false;
            TxtRemark.Enabled = false;
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
                TxtLoanDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");


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



        public void FillLOAN_MasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = LOAN_MASLogicLayer.GetAllLOAN_MASTERDetail(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()), HfLoanType.Value.ToString());
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvLoanAdvanceMaster.DataSource = Dv.ToTable();
            GvLoanAdvanceMaster.DataBind();

            DtSearch = Dv.ToTable();

        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetEmployeeName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from EMP_MAS where COMP_CODE=@COMP_CODE AND BRANCH_CODE=@BRANCH_CODE AND EMP_NAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            cmd.Parameters.AddWithValue("@BRANCH_CODE", Branchcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> EmpNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmpNames.Add(dt.Rows[i][2].ToString());
            }
            return EmpNames;
        }

        protected void TxtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //DataTable DtEmp = new DataTable();
                //DtEmp = EMP_MASLogicLayer.GetAllEmployeeDetailsOnBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());

                //if (TxtEmployeeName.Text != string.Empty)
                //{
                //    DataView Dv = new DataView(DtEmp);
                //    Dv.RowFilter = "EMP_NAME=" + TxtEmployeeName.Text;
                //    DataTable DtView = Dv.ToTable();
                //    HfEmployeeCode.Value = DtView.Rows[0]["EMP_CODE"].ToString();
                //    TxtEmployeeName.Text = DtView.Rows[0]["EMP_NAME"].ToString();
                //}
                //else
                //{
                //    HfEmployeeCode.Value = string.Empty;
                //}

                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select EMP_CODE from EMP_MAS where EMP_NAME = '" + TxtEmployeeName.Text + "' and COMP_CODE = " + Session["COMP_CODE"].ToString(), con);
                int x = Convert.ToInt32(cmd.ExecuteScalar());
                if (x == 0)
                {
                    TxtEmployeeName.BackColor = Color.Red;
                }
                else
                {
                    HfEmployeeCode.Value = cmd.ExecuteScalar().ToString();
                    TxtEmployeeName.BackColor = Color.White;
                }

                con.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvLoanAdvanceMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }


        public void FillEmployeeNameOnUpdate(string Id)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = EMP_MASLogicLayer.GetAllEmployeeDetailsByCompany(Comp_Code);


                if (HfEmployeeCode.Value.ToString() != "0" && HfEmployeeCode.Value != null && HfEmployeeCode.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "EMP_CODE=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtEmployeeName.Text = DtView.Rows[0]["EMP_NAME"].ToString();
                    HfEmployeeCode.Value = DtView.Rows[0]["EMP_CODE"].ToString();
                }
                else
                {
                    TxtEmployeeName.Text = string.Empty;
                    HfEmployeeCode.Value = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvLoanAdvanceMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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


                        DataTable Dt = LOAN_MASLogicLayer.GetAllIDWiseLOAN_MASTERDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()), HfLoanType.Value.ToString());


                        if (Dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = Dt.Rows[0]["COMP_CODE"].ToString();
                            HfTranDate.Value = Dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = Dt.Rows[0]["TRAN_NO"].ToString();
                            HfLoanType.Value = Dt.Rows[0]["LOAN_TYPE"].ToString();
                            TxtLoanDate.Text = Convert.ToDateTime(Dt.Rows[0]["LOAN_DATE"].ToString()).ToString("dd-MM-yyyy");
                            HfEmployeeCode.Value = Dt.Rows[0]["EMP_CODE"].ToString();
                            FillEmployeeNameOnUpdate(Dt.Rows[0]["EMP_CODE"].ToString());
                            TxtInstallMonth.Text = Dt.Rows[0]["INSTALL_MONTHS"].ToString();
                            TxtPaidFromDate.Text = Convert.ToDateTime(Dt.Rows[0]["FRDT"].ToString()).ToString("dd-MM-yyyy");
                            TxtPaidToDate.Text = Convert.ToDateTime(Dt.Rows[0]["TODT"].ToString()).ToString("dd-MM-yyyy");
                            TxtLoanAmount.Text = Dt.Rows[0]["LOAN_AMT"].ToString();
                            TxtInstallAmount.Text = Dt.Rows[0]["INSTALL_AMT"].ToString();
                            TxtPaidAmount.Text = Dt.Rows[0]["PAID_AMT"].ToString();
                            TxtRemark.Text = Dt.Rows[0]["REMARK"].ToString();

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


                        DataTable Dt = LOAN_MASLogicLayer.GetAllIDWiseLOAN_MASTERDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()), HfLoanType.Value.ToString());


                        if (Dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = Dt.Rows[0]["COMP_CODE"].ToString();
                            HfTranDate.Value = Dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = Dt.Rows[0]["TRAN_NO"].ToString();
                            HfLoanType.Value = Dt.Rows[0]["LOAN_TYPE"].ToString();
                            TxtLoanDate.Text = Convert.ToDateTime(Dt.Rows[0]["LOAN_DATE"].ToString()).ToString("dd-MM-yyyy");
                            HfEmployeeCode.Value = Dt.Rows[0]["EMP_CODE"].ToString();
                            FillEmployeeNameOnUpdate(Dt.Rows[0]["EMP_CODE"].ToString());
                            TxtInstallMonth.Text = Dt.Rows[0]["INSTALL_MONTHS"].ToString();
                            TxtPaidFromDate.Text = Convert.ToDateTime(Dt.Rows[0]["FRDT"].ToString()).ToString("dd-MM-yyyy");
                            TxtPaidToDate.Text = Convert.ToDateTime(Dt.Rows[0]["TODT"].ToString()).ToString("dd-MM-yyyy");
                            TxtLoanAmount.Text = Dt.Rows[0]["LOAN_AMT"].ToString();
                            TxtInstallAmount.Text = Dt.Rows[0]["INSTALL_AMT"].ToString();
                            TxtPaidAmount.Text = Dt.Rows[0]["PAID_AMT"].ToString();
                            TxtRemark.Text = Dt.Rows[0]["REMARK"].ToString();

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


                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataTable Dt = LOAN_MASLogicLayer.GetAllIDWiseLOAN_MASTERDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()), HfLoanType.Value.ToString());


                        if (Dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = Dt.Rows[0]["COMP_CODE"].ToString();
                            HfTranDate.Value = Dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = Dt.Rows[0]["TRAN_NO"].ToString();
                            HfLoanType.Value = Dt.Rows[0]["LOAN_TYPE"].ToString();
                            TxtLoanDate.Text = Convert.ToDateTime(Dt.Rows[0]["LOAN_DATE"].ToString()).ToString("dd-MM-yyyy");
                            HfEmployeeCode.Value = Dt.Rows[0]["EMP_CODE"].ToString();
                            FillEmployeeNameOnUpdate(Dt.Rows[0]["EMP_CODE"].ToString());
                            TxtInstallMonth.Text = Dt.Rows[0]["INSTALL_MONTHS"].ToString();
                            TxtPaidFromDate.Text = Convert.ToDateTime(Dt.Rows[0]["FRDT"].ToString()).ToString("dd-MM-yyyy");
                            TxtPaidToDate.Text = Convert.ToDateTime(Dt.Rows[0]["TODT"].ToString()).ToString("dd-MM-yyyy");
                            TxtLoanAmount.Text = Dt.Rows[0]["LOAN_AMT"].ToString();
                            TxtInstallAmount.Text = Dt.Rows[0]["INSTALL_AMT"].ToString();
                            TxtPaidAmount.Text = Dt.Rows[0]["PAID_AMT"].ToString();
                            TxtRemark.Text = Dt.Rows[0]["REMARK"].ToString();

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
                string str = LOAN_MASLogicLayer.DeleteLOAN_MASDetailsByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value));
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
                    lblmsg.Text = "Error:Loan Master Deleted";
                    lblmsg.ForeColor = Color.Red;
                }
                clear();
                UserRights();
                FillLOAN_MasterGrid(Convert.ToString(Session["COMP_CODE"]));
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
                #region UPDATE LOAN MASTER DETAILS

                LOAN_MASLogicLayer insert = new LOAN_MASLogicLayer();

                insert.COMP_CODE = Session["COMP_CODE"].ToString();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.LOAN_TYPE = HfLoanType.Value.Trim().ToString().ToUpper();
                insert.LOAN_DATE = Convert.ToDateTime(TxtLoanDate.Text.Trim().ToString()).ToString("MM-dd-yyyy");
                if (TxtEmployeeName.Text != string.Empty)
                {
                    insert.EMP_CODE = HfEmployeeCode.Value.Trim();
                }
                insert.FRDT = Convert.ToDateTime(TxtPaidFromDate.Text.Trim().ToString()).ToString("MM-dd-yyyy");
                insert.TODT = Convert.ToDateTime(TxtPaidToDate.Text.Trim().ToString()).ToString("MM-dd-yyyy");
                if (TxtInstallMonth.Text != string.Empty)
                {
                    insert.INSTALL_MONTHS = TxtInstallMonth.Text.Trim();
                }
                else
                {
                    insert.INSTALL_MONTHS = null;
                }

                if (TxtLoanAmount.Text != string.Empty)
                {
                    insert.LOAN_AMT = TxtLoanAmount.Text.Trim();
                }
                else
                {
                    insert.LOAN_AMT = null;
                }

                if (TxtPaidAmount.Text != string.Empty)
                {
                    insert.PAID_AMT = TxtPaidAmount.Text.Trim();
                }
                else
                {
                    insert.PAID_AMT = null;
                }

                if (TxtInstallAmount.Text != string.Empty)
                {
                    insert.INSTALL_AMT = TxtInstallAmount.Text.Trim();
                }
                else
                {
                    insert.INSTALL_AMT = null;
                }

                insert.REMARK = TxtRemark.Text.Trim();
                insert.STATUS = "O";

                #endregion


                string str = LOAN_MASLogicLayer.UpdateLOAN_MASDetail(insert);

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "LOAN MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillLOAN_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "LOAN MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : LOAN MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

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
                    #region INSERT INTO LOAN MASTER DETAILS

                    LOAN_MASLogicLayer insert = new LOAN_MASLogicLayer();

                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    //insert.TRAN_DATE = HfTranDate.Value.Trim();
                    //insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.LOAN_TYPE = HfLoanType.Value.Trim().ToString().ToUpper();
                    insert.LOAN_DATE = Convert.ToDateTime(TxtLoanDate.Text.Trim().ToString()).ToString("MM-dd-yyyy");
                    if (TxtEmployeeName.Text != string.Empty)
                    {
                        insert.EMP_CODE = HfEmployeeCode.Value.Trim();
                    }
                    insert.FRDT = Convert.ToDateTime(TxtPaidFromDate.Text.Trim().ToString()).ToString("MM-dd-yyyy");
                    insert.TODT = Convert.ToDateTime(TxtPaidToDate.Text.Trim().ToString()).ToString("MM-dd-yyyy");
                    if (TxtInstallMonth.Text != string.Empty)
                    {
                        insert.INSTALL_MONTHS = TxtInstallMonth.Text.Trim();
                    }
                    else
                    {
                        insert.INSTALL_MONTHS = null;
                    }

                    if (TxtLoanAmount.Text != string.Empty)
                    {
                        insert.LOAN_AMT = TxtLoanAmount.Text.Trim();
                    }
                    else
                    {
                        insert.LOAN_AMT = null;
                    }

                    if (TxtPaidAmount.Text != string.Empty)
                    {
                        insert.PAID_AMT = TxtPaidAmount.Text.Trim();
                    }
                    else
                    {
                        insert.PAID_AMT = null;
                    }

                    if (TxtInstallAmount.Text != string.Empty)
                    {
                        insert.INSTALL_AMT = TxtInstallAmount.Text.Trim();
                    }
                    else
                    {
                        insert.INSTALL_AMT = null;
                    }

                    insert.REMARK = TxtRemark.Text.Trim();
                    insert.STATUS = "O";

                    #endregion

                    string str = LOAN_MASLogicLayer.InsertLOAN_MASDetail(insert);

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "LOAN MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillLOAN_MasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "LOAN MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : LOAN MASTER NOT SAVED";
                        lblmsg.ForeColor = Color.Red;

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}