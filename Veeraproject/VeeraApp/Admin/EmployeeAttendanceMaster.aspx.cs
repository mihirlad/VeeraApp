using MihirValid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class EmployeeAttendanceData : System.Web.UI.Page
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
                Session["BRANCH_CODE"] != null &&
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
                    FillATTENDANCE_MasterGrid(Session["COMP_CODE"].ToString());
                    SetInitialRowEmpTransaction();
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

            TxtAttendanceDate.Text = string.Empty;
            TxtRemark.Text = string.Empty;
            DdlHolidayFlag.SelectedValue = "N";

            BtncallUpd.Text = "SAVE";

            SetInitialRowEmpTransaction();


        }

        public void ControllerEnable()
        {
            TxtAttendanceDate.Enabled = true;
            TxtRemark.Enabled = true;
            DdlHolidayFlag.Enabled = true;
        }

        public void ControllerDisable()
        {
            TxtAttendanceDate.Enabled = false;
            TxtRemark.Enabled = false;
            DdlHolidayFlag.Enabled = false;
        }

        private void SetInitialRowEmpTransaction()
        {
            DataTable table = new DataTable();
            DataRow dr = null;

            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("EMP_CODE", typeof(string));
            table.Columns.Add("ATTN_FLAG", typeof(string));
            table.Columns.Add("PAY_AMT", typeof(string));
            table.Columns.Add("OT_HOURS", typeof(string));
            table.Columns.Add("INS_USERID", typeof(string));
            table.Columns.Add("INS_TERMINAL", typeof(string));
            table.Columns.Add("INS_DATE", typeof(string));
            table.Columns.Add("UPD_USERID", typeof(string));
            table.Columns.Add("UPD_TERMINAL", typeof(string));
            table.Columns.Add("UPD_DATE", typeof(string));
            table.Columns.Add("EMP_NAME", typeof(string));
           


            dr = table.NewRow();


            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["EMP_CODE"] = string.Empty;
            dr["ATTN_FLAG"] = "P";
            dr["PAY_AMT"] = string.Empty;
            dr["OT_HOURS"] = string.Empty;
            dr["INS_USERID"] = string.Empty;
            dr["INS_TERMINAL"] = string.Empty;
            dr["INS_DATE"] = string.Empty;
            dr["UPD_USERID"] = string.Empty;
            dr["UPD_TERMINAL"] = string.Empty;
            dr["UPD_DATE"] = string.Empty;
            dr["EMP_NAME"] = string.Empty;
          

            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvEmployeeAttendanceTransaction.DataSource = table;
            GvEmployeeAttendanceTransaction.DataBind();

        }

        protected void GvEmployeeAttendanceTransaction_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        public void FillATTENDANCE_MasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = ATTN_MASLogicLayer.GetAllATTENDANCE_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvEmployeeAttendanceMaster.DataSource = Dv.ToTable();
            GvEmployeeAttendanceMaster.DataBind();

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
                    #region INSERT INTO ATTENDANCE MASTER

                    ATTN_MASLogicLayer insert = new ATTN_MASLogicLayer();

                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    //insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                    //insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.ATTN_DATE = Convert.ToDateTime(TxtAttendanceDate.Text.Trim()).ToString("MM-dd-yyyy");
                    insert.HOLIDAY = DdlHolidayFlag.SelectedValue.Trim().ToUpper().ToString();
                    insert.REMARK = TxtRemark.Text.Trim().ToUpper().ToString();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    //insert.UPD_USERID = Session["USERNAME"].ToString();
                    //insert.UPD_TERMINAL = Session["PC"].ToString();
                    //insert.UPD_DATE = "";
                    insert.CONF_FLAG = null;
                    insert.CONF_DATE = null;
                    insert.CONF_USERID = null;

                    #endregion


                    #region INSERT INTO ATTENDANCE TRANSACTION DETAILS

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);


                    foreach (GridViewRow row in GvEmployeeAttendanceTransaction.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfCompCodeGrid = row.FindControl("HfCompCodeGrid") as HiddenField;
                            HiddenField HfTranDateGrid = row.FindControl("HfTranDateGrid") as HiddenField;
                            HiddenField HfTranNoGrid = row.FindControl("HfTranNoGrid") as HiddenField;
                            HiddenField HfEmployeeCode = row.FindControl("HfEmployeeCode") as HiddenField;

                            TextBox TxtEmployeeName = row.FindControl("TxtEmployeeName") as TextBox;
                            TextBox TxtPayableAmount = row.FindControl("TxtPayableAmount") as TextBox;
                            TextBox TxtOTHours = row.FindControl("TxtOTHours") as TextBox;
                            DropDownList DdlAttendanceFlag = row.FindControl("DdlAttendanceFlag") as DropDownList;



                            if (HfEmployeeCode.Value != string.Empty && HfEmployeeCode.Value != null)
                            {


                                XmlElement HandleDetail2 = XDoc1.CreateElement("ATTN_TRAN_Details");

                                HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail2.SetAttribute("TRAN_DATE", (Convert.ToDateTime(HfTranDate.Value.Trim())).ToString("yyyy-MM-dd"));
                                //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());

                                HandleDetail2.SetAttribute("EMP_CODE", HfEmployeeCode.Value.Trim());

                                HandleDetail2.SetAttribute("ATTN_FLAG", DdlAttendanceFlag.SelectedValue.Trim().ToUpper().ToString());


                                if (TxtPayableAmount.Text != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("PAY_AMT", TxtPayableAmount.Text.Trim());
                                }

                                if (TxtOTHours.Text != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("OT_HOURS", TxtOTHours.Text.Trim());
                                }
                                //else
                                //{
                                //    HandleDetail2.SetAttribute("OT_HOURS",null);
                                //}

                                HandleDetail2.SetAttribute("INS_USERID", Session["USERNAME"].ToString());
                                HandleDetail2.SetAttribute("INS_TERMINAL", Session["PC"].ToString());
                                HandleDetail2.SetAttribute("INS_DATE", (""));
                                //HandleDetail2.SetAttribute("UPD_USERID", Session["USERNAME"].ToString());
                                //HandleDetail2.SetAttribute("UPD_TERMINAL", Session["PC"].ToString());
                                //HandleDetail2.SetAttribute("UPD_DATE", (""));


                                root1.AppendChild(HandleDetail2);


                            }
                        }
                    }

                    #endregion


                    string str = ATTN_MASLogicLayer.InsertATTENDANCE_MASDetail(insert, validation.RSC(XDoc1.OuterXml));

                    if (str.Contains("successfully"))
                    {

                        lblmsg.Text = "ATTENDACE TRANSACTION MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillATTENDANCE_MasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "ATTENDACE TRANSACTION MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : ATTENDACE TRANSACTION MASTER NOT SAVED";
                        lblmsg.ForeColor = Color.Red;

                    }


                }
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
                //  TxtAttendanceDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
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

        protected void GvEmployeeAttendanceMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvEmployeeAttendanceMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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


                        DataSet ds = ATTN_MASLogicLayer.GetAllIDWiseATTENDANCE_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            TxtAttendanceDate.Text = Convert.ToDateTime(dt.Rows[0]["ATTN_DATE"].ToString()).ToString("dd-MM-yyyy");
                            DdlHolidayFlag.SelectedValue = dt.Rows[0]["HOLIDAY"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                        }

                        if (DtDetails.Rows.Count > 0)
                        {
                            GvEmployeeAttendanceTransaction.DataSource = DtDetails;
                            GvEmployeeAttendanceTransaction.DataBind();
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


                        DataSet ds = ATTN_MASLogicLayer.GetAllIDWiseATTENDANCE_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            TxtAttendanceDate.Text = Convert.ToDateTime(dt.Rows[0]["ATTN_DATE"].ToString()).ToString("dd-MM-yyyy");
                            DdlHolidayFlag.SelectedValue = dt.Rows[0]["HOLIDAY"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                        }

                        if (DtDetails.Rows.Count > 0)
                        {
                            GvEmployeeAttendanceTransaction.DataSource = DtDetails;
                            GvEmployeeAttendanceTransaction.DataBind();
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


                        DataSet ds = ATTN_MASLogicLayer.GetAllIDWiseATTENDANCE_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            TxtAttendanceDate.Text = Convert.ToDateTime(dt.Rows[0]["ATTN_DATE"].ToString()).ToString("dd-MM-yyyy");
                            DdlHolidayFlag.SelectedValue = dt.Rows[0]["HOLIDAY"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                        }

                        if (DtDetails.Rows.Count > 0)
                        {
                            GvEmployeeAttendanceTransaction.DataSource = DtDetails;
                            GvEmployeeAttendanceTransaction.DataBind();
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
            catch (Exception EX)
            {

                EX.ToString();
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
                string str = ATTN_MASLogicLayer.DeleteATTENDANCE_MASDetailsByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value));
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
                    lblmsg.Text = "Error:Attendance Master Deleted";
                    lblmsg.ForeColor = Color.Red;
                }
                clear();
                UserRights();
                FillATTENDANCE_MasterGrid(Convert.ToString(Session["COMP_CODE"]));
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
                #region UPDATE ATTENDANCE TRANSATION DETAILS

                #region INSERT INTO ATTENDANCE MASTER

                ATTN_MASLogicLayer insert = new ATTN_MASLogicLayer();

                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.ATTN_DATE = Convert.ToDateTime(TxtAttendanceDate.Text.Trim()).ToString("MM-dd-yyyy");
                insert.HOLIDAY = DdlHolidayFlag.SelectedValue.Trim().ToUpper().ToString();
                insert.REMARK = TxtRemark.Text.Trim().ToUpper().ToString();
                //insert.INS_USERID = Session["USERNAME"].ToString();
                //insert.INS_TERMINAL = Session["PC"].ToString();
                //insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";
                insert.CONF_FLAG = null;
                insert.CONF_DATE = null;
                insert.CONF_USERID = null;

                #endregion


                #region INSERT INTO ATTENDANCE TRANSACTION DETAILS

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);


                foreach (GridViewRow row in GvEmployeeAttendanceTransaction.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfCompCodeGrid = row.FindControl("HfCompCodeGrid") as HiddenField;
                        HiddenField HfTranDateGrid = row.FindControl("HfTranDateGrid") as HiddenField;
                        HiddenField HfTranNoGrid = row.FindControl("HfTranNoGrid") as HiddenField;
                        HiddenField HfEmployeeCode = row.FindControl("HfEmployeeCode") as HiddenField;

                        TextBox TxtEmployeeName = row.FindControl("TxtEmployeeName") as TextBox;
                        TextBox TxtPayableAmount = row.FindControl("TxtPayableAmount") as TextBox;
                        TextBox TxtOTHours = row.FindControl("TxtOTHours") as TextBox;
                        DropDownList DdlAttendanceFlag = row.FindControl("DdlAttendanceFlag") as DropDownList;



                        if (HfEmployeeCode.Value != string.Empty && HfEmployeeCode.Value != null)
                        {


                            XmlElement HandleDetail2 = XDoc1.CreateElement("ATTN_TRAN_Details");

                            HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                            HandleDetail2.SetAttribute("TRAN_DATE", (Convert.ToDateTime(HfTranDate.Value.Trim())).ToString("yyyy-MM-dd"));
                            HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());

                            HandleDetail2.SetAttribute("EMP_CODE", HfEmployeeCode.Value.Trim());

                            HandleDetail2.SetAttribute("ATTN_FLAG", DdlAttendanceFlag.SelectedValue.Trim().ToUpper().ToString());


                            if (TxtPayableAmount.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("PAY_AMT", TxtPayableAmount.Text.Trim());
                            }

                            if (TxtOTHours.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("OT_HOURS", TxtOTHours.Text.Trim());
                            }
                            //else
                            //{
                            //    HandleDetail2.SetAttribute("OT_HOURS",null);
                            //}

                            //HandleDetail2.SetAttribute("INS_USERID", Session["USERNAME"].ToString());
                            //HandleDetail2.SetAttribute("INS_TERMINAL", Session["PC"].ToString());
                            //HandleDetail2.SetAttribute("INS_DATE", (""));
                            HandleDetail2.SetAttribute("UPD_USERID", Session["USERNAME"].ToString());
                            HandleDetail2.SetAttribute("UPD_TERMINAL", Session["PC"].ToString());
                            HandleDetail2.SetAttribute("UPD_DATE", (""));


                            root1.AppendChild(HandleDetail2);


                        }
                    }
                }

                #endregion

                string str = ATTN_MASLogicLayer.UpdateATTENDANCE_MASDetail(insert, validation.RSC(XDoc1.OuterXml));

                if (str.Contains("successfully"))
                {

                    lblmsg.Text = "ATTENDACE TRANSACTION MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillATTENDANCE_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "ATTENDACE TRANSACTION MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : ATTENDACE TRANSACTION MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }


                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillEMPLOYEEAttendanceTranDetails()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = EMP_MASLogicLayer.GetAllEmployeeSalDetailsForAttenMas(Session["COMP_CODE"].ToString(), Convert.ToDateTime(TxtAttendanceDate.Text.Trim()));

                GvEmployeeAttendanceTransaction.DataSource = Dt;
                GvEmployeeAttendanceTransaction.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtAttendanceDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FillEMPLOYEEAttendanceTranDetails();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlAttendanceFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList DdlAttnFlag = (DropDownList)sender;
                GridViewRow row = (GridViewRow)DdlAttnFlag.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfPayableAmmount = (HiddenField)row.Cells[0].FindControl("HfPayableAmmount");
                HiddenField HfEmployeeCode = (HiddenField)row.Cells[0].FindControl("HfEmployeeCode");
                TextBox TxtPayableAmount = (TextBox)row.Cells[3].FindControl("TxtPayableAmount");
                TextBox TxtOTHours = (TextBox)row.Cells[4].FindControl("TxtOTHours");

                //HfPayableAmmount.Value = TxtPayableAmount.Text;

                if (TxtPayableAmount.Text == string.Empty)
                {
                    TxtPayableAmount.Text = "0";
                }

                if (DdlAttnFlag.SelectedValue == "P")
                {
                    TxtPayableAmount.Text = HfPayableAmmount.Value;
                }
                if (DdlAttnFlag.SelectedValue == "H")
                {
                    TxtPayableAmount.Text = (Convert.ToDouble(HfPayableAmmount.Value) / 2).ToString();
                }
                else if (DdlAttnFlag.SelectedValue == "A")
                {
                    TxtPayableAmount.Text = "0";
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

     
    }
}