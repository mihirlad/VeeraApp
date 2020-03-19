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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;

namespace VeeraApp
{
    public partial class DailyWorkTimeCard : System.Web.UI.Page
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

                    CalendarExtenderWorkDate.StartDate = Convert.ToDateTime(Session["FIN_YEAR"].ToString());
                    CalendarExtenderWorkDate.EndDate = Convert.ToDateTime(Session["FIN_YEAR_END"].ToString());
                    FillDdlPersonName();
                    FillDAILY_WORKMASGrid(Session["COMP_CODE"].ToString());

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

        public void FillDdlPersonName()
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKER_MASDetialsCompanyWiseFor_DDL(Comp_Code);
                DdlPreparedBy.DataSource = Dt;
                DdlPreparedBy.DataValueField = "BCODE";
                DdlPreparedBy.DataTextField = "BNAME";
                DdlPreparedBy.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfCompCode.Value = string.Empty;
            HfBranchCode.Value = string.Empty;
            TxtWorkDate.Text = string.Empty;
            TxtSrNo.Text = string.Empty;
            TxtEmployeeName.Text = string.Empty;
            DdlJobCategory.SelectedIndex = 0;
            DdlPreparedBy.SelectedIndex = 0;
            DdlConfirm.SelectedValue = "N";
            DdlChecked.SelectedValue = "N";
            TxtConfirmDate.Text = string.Empty;
            TxtCheckedDate.Text = string.Empty;
            TxtCheckedBy.Text = string.Empty;

            BtncallUpd.Text = "SAVE";
        }

        public void ControllerEnable()
        {

            TxtWorkDate.Enabled = true;
            TxtSrNo.Enabled = false;
            TxtEmployeeName.Enabled = true;
            DdlJobCategory.Enabled = true;
            DdlPreparedBy.Enabled = true;
            DdlConfirm.Enabled = true;
            DdlChecked.Enabled = true;
            TxtConfirmDate.Enabled = true;
            TxtCheckedDate.Enabled = true;
            TxtCheckedBy.Enabled = true;
        }

        public void ControllerDisable()
        {

            TxtWorkDate.Enabled = false;
            TxtSrNo.Enabled = false;
            TxtEmployeeName.Enabled = false;
            DdlJobCategory.Enabled = false;
            DdlPreparedBy.Enabled = false;
            DdlConfirm.Enabled = false;
            DdlChecked.Enabled = false;
            TxtConfirmDate.Enabled = false;
            TxtCheckedDate.Enabled = false;
            TxtCheckedBy.Enabled = false;
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
                SetInitialRow();
                TxtWorkDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                string SrNo = DAILY_WORKMASLogicLayer.GetSrNoDAILY_WORKMASCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtWorkDate.Text.Trim()).ToString("yyyy-MM-dd"));
                if (SrNo.Length <= 8)
                {
                    TxtSrNo.Text = SrNo;
                }
                else
                {
                    TxtSrNo.Text = string.Empty;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void TxtWorkDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string SrNo = DAILY_WORKMASLogicLayer.GetSrNoDAILY_WORKMASCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtWorkDate.Text.Trim()).ToString("yyyy-MM-dd"));
                if (SrNo.Length <= 8)
                {
                    TxtSrNo.Text = SrNo;
                }
                else
                {
                    TxtSrNo.Text = string.Empty;
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            lblmsg.Text = string.Empty;
            UserRights();
        }


        public void FillDAILY_WORKMASGrid(string CompCode)
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = DAILY_WORKMASLogicLayer.GetAllDAILY_WORKMASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvDailyWorkCardMaster.DataSource = Dv.ToTable(); ;
                GvDailyWorkCardMaster.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region ADD NEW ROW INTO GRID

        private void SetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("FRTIME", typeof(string));
            table.Columns.Add("TOTIME", typeof(string));
            table.Columns.Add("VISIT_PLACE", typeof(string));
            table.Columns.Add("WORK_DESC", typeof(string));
            table.Columns.Add("REMARK", typeof(string));
            table.Columns.Add("INS_USERID", typeof(string));
            table.Columns.Add("INS_DATE", typeof(string));
            table.Columns.Add("UPD_USERID", typeof(string));
            table.Columns.Add("UPD_DATE", typeof(string));
            table.Columns.Add("WORK_FROM", typeof(string));
            table.Columns.Add("WORK_CODE", typeof(string));


            dr = table.NewRow();

            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["FRTIME"] = string.Empty;
            dr["TOTIME"] = string.Empty;
            dr["VISIT_PLACE"] = string.Empty;
            dr["WORK_DESC"] = string.Empty;
            dr["REMARK"] = string.Empty;
            dr["INS_USERID"] = string.Empty;
            dr["INS_DATE"] = string.Empty;
            dr["UPD_USERID"] = string.Empty;
            dr["UPD_DATE"] = string.Empty;
            dr["WORK_FROM"] = string.Empty;
            dr["WORK_CODE"] = string.Empty;

            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvDailyWorkDetails.DataSource = table;
            GvDailyWorkDetails.DataBind();
        }


        private void AddNewRowToGrid()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values 
                        //TextBox TxtSr = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtSr");

                        HiddenField HfTranDate = (HiddenField)GvDailyWorkDetails.Rows[rowIndex].Cells[0].FindControl("HfTranDate");
                        HiddenField HfTranNo = (HiddenField)GvDailyWorkDetails.Rows[rowIndex].Cells[0].FindControl("HfTranNo");
                        HiddenField HfSrNo = (HiddenField)GvDailyWorkDetails.Rows[rowIndex].Cells[0].FindControl("HfSrNo");

                        TextBox TxtFromTime = (TextBox)GvDailyWorkDetails.Rows[rowIndex].Cells[1].FindControl("TxtFromTime");
                        TextBox TxtToTime = (TextBox)GvDailyWorkDetails.Rows[rowIndex].Cells[2].FindControl("TxtToTime");
                        TextBox TxtVisitDescription = (TextBox)GvDailyWorkDetails.Rows[rowIndex].Cells[3].FindControl("TxtVisitDescription");
                        TextBox TxtWorkDescription = (TextBox)GvDailyWorkDetails.Rows[rowIndex].Cells[4].FindControl("TxtWorkDescription");
                        TextBox TxtRemark = (TextBox)GvDailyWorkDetails.Rows[rowIndex].Cells[5].FindControl("TxtRemark");
                      

                        //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["FRTIME"] = TxtFromTime.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["TOTIME"] = TxtToTime.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["VISIT_PLACE"] = TxtVisitDescription.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["WORK_DESC"] = TxtWorkDescription.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["REMARK"] = TxtRemark.Text.Trim();
                      



                        rowIndex++;

                    }


                    drCurrentRow = dtCurrentTable.NewRow();

                    //drCurrentRow["SR"] = "";
                    drCurrentRow["FRTIME"] = "";
                    drCurrentRow["TOTIME"] = "";
                    drCurrentRow["VISIT_PLACE"] = "";
                    drCurrentRow["WORK_DESC"] = "";
                    drCurrentRow["REMARK"] = "";
                  


                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvDailyWorkDetails.DataSource = dtCurrentTable;
                    GvDailyWorkDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousDataToGrid();
        }



        private void SetPreviousDataToGrid()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        HiddenField HfTranDate = (HiddenField)GvDailyWorkDetails.Rows[rowIndex].Cells[0].FindControl("HfTranDate");
                        HiddenField HfTranNo = (HiddenField)GvDailyWorkDetails.Rows[rowIndex].Cells[0].FindControl("HfTranNo");
                        HiddenField HfSrNo = (HiddenField)GvDailyWorkDetails.Rows[rowIndex].Cells[0].FindControl("HfSrNo");

                        TextBox TxtFromTime = (TextBox)GvDailyWorkDetails.Rows[rowIndex].Cells[1].FindControl("TxtFromTime");
                        TextBox TxtToTime = (TextBox)GvDailyWorkDetails.Rows[rowIndex].Cells[2].FindControl("TxtToTime");
                        TextBox TxtVisitDescription = (TextBox)GvDailyWorkDetails.Rows[rowIndex].Cells[3].FindControl("TxtVisitDescription");
                        TextBox TxtWorkDescription = (TextBox)GvDailyWorkDetails.Rows[rowIndex].Cells[4].FindControl("TxtWorkDescription");
                        TextBox TxtRemark = (TextBox)GvDailyWorkDetails.Rows[rowIndex].Cells[5].FindControl("TxtRemark");



                        TxtFromTime.Text = dt.Rows[i]["FRTIME"].ToString();
                        TxtToTime.Text = dt.Rows[i]["TOTIME"].ToString();
                        TxtVisitDescription.Text = dt.Rows[i]["VISIT_PLACE"].ToString();
                        TxtWorkDescription.Text = dt.Rows[i]["WORK_DESC"].ToString();
                        TxtRemark.Text = dt.Rows[i]["REMARK"].ToString();
                     
                        rowIndex++;

                    }
                }
            }
        }



        protected void BtnDeleteRowModelDC_DetailsGrid_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex + 1;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {

                    if (gvRow.RowIndex <= dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data
                        dt.Rows.Remove(dt.Rows[rowID - 1]);
                    }
                }
                //Store the current data in ViewState for future reference
                ViewState["CurrentTable"] = dt;
                //Re bind the GridView for the updated data
                GvDailyWorkDetails.DataSource = dt;
                GvDailyWorkDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousDataToGrid();
        }

        protected void BtnAddRowModelDC_DetailsGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        #endregion


        public void FillOnGridWorkDetailsOnUpdate()
        {
            try
            {
                #region Assign to Grid

                int rowIndex = 0;

                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                   
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //extract the TextBox values 
                            //TextBox TxtSr = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtSr");

                            HiddenField HfTranDate = (HiddenField)GvDailyWorkDetails.Rows[rowIndex].Cells[0].FindControl("HfTranDate");
                            HiddenField HfTranNo = (HiddenField)GvDailyWorkDetails.Rows[rowIndex].Cells[0].FindControl("HfTranNo");
                            HiddenField HfSrNo = (HiddenField)GvDailyWorkDetails.Rows[rowIndex].Cells[0].FindControl("HfSrNo");

                            TextBox TxtFromTime = (TextBox)GvDailyWorkDetails.Rows[rowIndex].Cells[1].FindControl("TxtFromTime");
                            TextBox TxtToTime = (TextBox)GvDailyWorkDetails.Rows[rowIndex].Cells[2].FindControl("TxtToTime");
                            TextBox TxtVisitDescription = (TextBox)GvDailyWorkDetails.Rows[rowIndex].Cells[3].FindControl("TxtVisitDescription");
                            TextBox TxtWorkDescription = (TextBox)GvDailyWorkDetails.Rows[rowIndex].Cells[4].FindControl("TxtWorkDescription");
                            TextBox TxtRemark = (TextBox)GvDailyWorkDetails.Rows[rowIndex].Cells[5].FindControl("TxtRemark");


                            //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["FRTIME"] = TxtFromTime.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["TOTIME"] = TxtToTime.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["VISIT_PLACE"] = TxtVisitDescription.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["WORK_DESC"] = TxtWorkDescription.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["REMARK"] = TxtRemark.Text.Trim();

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


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetEmployeeName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from EMP_MAS where COMP_CODE=@COMP_CODE and EMP_NAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> EmployeeNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmployeeNames.Add(dt.Rows[i][2].ToString());
            }
            return EmployeeNames;
        }


        protected void TxtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtEmpName = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtEmpName = EMP_MASLogicLayer.GetAllEmployeeDetailsByCompany(Comp_Code);
                if (TxtEmployeeName.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtEmpName);
                    Dv.RowFilter = "EMP_NAME='" + TxtEmployeeName.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfEmployeeCode.Value = DtView.Rows[0]["EMP_CODE"].ToString();

                    }
                    else
                    {
                        HfEmployeeCode.Value = null;
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetWorListName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from WORK_LISTMAS where COMP_CODE=@COMP_CODE and WORK_NAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> WorkNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WorkNames.Add(dt.Rows[i][2].ToString());
            }
            return WorkNames;
        }

        protected void TxtWorkDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
               

                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtWorkDescription = (TextBox)row.Cells[5].FindControl("TxtWorkDescription");
                HiddenField HfWorkCode = (HiddenField)row.Cells[0].FindControl("HfWorkCode");
              

                DataTable DtWorkName = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtWorkName = WORK_LISTMASLogicLayer.GetWORK_LISTMASDetailsCompanyWise(Comp_Code);
                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtWorkName);
                    Dv.RowFilter = "WORK_NAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfWorkCode.Value = DtView.Rows[0]["WORK_CODE"].ToString();

                        FillOnGridWorkDetailsOnUpdate();
                   }
                    else
                    {
                        HfWorkCode = null;
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
                    #region INSERT DATA INTO DAILY WORK MASTER

                    DAILY_WORKMASLogicLayer insert = new DAILY_WORKMASLogicLayer();

                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                    //insert.TRAN_DATE = HfTranDate.Value.Trim();
                    //insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.SRNO = TxtSrNo.Text.Trim();
                    insert.TRNDT = Convert.ToDateTime(TxtWorkDate.Text.Trim()).ToString("MM-dd-yyyy");

                    if(TxtEmployeeName.Text!=string.Empty)
                    {
                        insert.EMP_CODE = HfEmployeeCode.Value.Trim();
                    }
                    else
                    {
                        insert.EMP_CODE = null;
                    }
                   
                    insert.USERCODE = Session["USERCODE"].ToString();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_DATE = "";
                    insert.CONF_FLAG = DdlConfirm.SelectedValue.Trim().ToUpper();
                    if (DdlConfirm.SelectedValue.ToString() == "Y")
                    {
                        insert.CONF_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CONF_DATE = "";
                    }

                    insert.CHK_FLAG = DdlChecked.SelectedValue.Trim().ToUpper();
                    if (DdlChecked.SelectedValue.ToString() == "Y")
                    {
                        insert.CHK_DATE = Convert.ToDateTime(TxtCheckedDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CHK_DATE = "";
                    }

                    if (DdlChecked.SelectedValue.ToString() == "Y")
                    {
                        insert.CHK_USERID = TxtCheckedBy.Text.Trim().ToUpper();
                    }
                    else
                    {
                        insert.CHK_USERID = "";
                    }

                    insert.BCODE = DdlPreparedBy.SelectedValue.Trim();

                    #endregion

                    #region INSERT DATA INTO DAILY WORK_MAS DETAILS

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int SRNO = 1;

                    foreach (GridViewRow row in GvDailyWorkDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                            HiddenField HfTranNo = row.FindControl("HfTranNo") as HiddenField;
                            HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                            HiddenField HfWorkCode = row.FindControl("HfWorkCode") as HiddenField;

                            TextBox TxtFromTime = row.FindControl("TxtFromTime") as TextBox;
                            TextBox TxtToTime = row.FindControl("TxtToTime") as TextBox;
                            TextBox TxtVisitDescription = row.FindControl("TxtVisitDescription") as TextBox;
                            TextBox TxtWorkDescription = row.FindControl("TxtWorkDescription") as TextBox;
                            TextBox TxtRemark = row.FindControl("TxtRemark") as TextBox;

                            XmlElement HandleDetail2 = XDoc1.CreateElement("DailyWorkDetails");
                            HandleDetail2.SetAttribute("SRNO", SRNO.ToString());
                            HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                            //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            //HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                            HandleDetail2.SetAttribute("FRTIME", Convert.ToDateTime(TxtWorkDate.Text.Trim()+" "+TxtFromTime.Text.Trim()).ToString("MM-dd-yyyy hh:mm"));
                            HandleDetail2.SetAttribute("TOTIME", Convert.ToDateTime(TxtWorkDate.Text.Trim() + " " + TxtToTime.Text.Trim()).ToString("MM-dd-yyyy hh:mm"));//(TxtToTime.Text.Trim()));
                            HandleDetail2.SetAttribute("VISIT_PLACE", (TxtVisitDescription.Text.Trim()));
                            HandleDetail2.SetAttribute("WORK_DESC", (TxtWorkDescription.Text.Trim()));
                            HandleDetail2.SetAttribute("REMARK", (TxtRemark.Text.Trim()));
                            HandleDetail2.SetAttribute("INS_USERID", Session["USERNAME"].ToString());
                            HandleDetail2.SetAttribute("INS_DATE", "");
                            HandleDetail2.SetAttribute("UPD_USERID", Session["USERNAME"].ToString());
                            HandleDetail2.SetAttribute("UPD_DATE", "");
                            HandleDetail2.SetAttribute("WORK_FROM", "");
                            HandleDetail2.SetAttribute("WORK_CODE",HfWorkCode.Value.Trim());

                            root1.AppendChild(HandleDetail2);
                            SRNO++;

                        }
                    }

                
                #endregion

                string str = DAILY_WORKMASLogicLayer.InsertDAILY_WORKMASDetail(insert, validation.RSC(XDoc1.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"));

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "DAILY WORK MASTER SAVE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillDAILY_WORKMASGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "DAILY WORK MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : DAILY WORK MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }

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
                #region UPDATE DAILY WORK MASTER

                #region INSERT DATA INTO DAILY WORK MASTER

                DAILY_WORKMASLogicLayer insert = new DAILY_WORKMASLogicLayer();

                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.BRANCH_CODE =HfBranchCode.Value.Trim();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.SRNO = TxtSrNo.Text.Trim();
                insert.TRNDT = Convert.ToDateTime(TxtWorkDate.Text.Trim()).ToString("MM-dd-yyyy");

                if (TxtEmployeeName.Text != string.Empty)
                {
                    insert.EMP_CODE = HfEmployeeCode.Value.Trim();
                }
                else
                {
                    insert.EMP_CODE = null;
                }

                insert.USERCODE = Session["USERCODE"].ToString();
                //insert.INS_USERID = Session["USERNAME"].ToString();
                //insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_DATE = "";
                insert.CONF_FLAG = DdlConfirm.SelectedValue.Trim().ToUpper();
                if (DdlConfirm.SelectedValue.ToString() == "Y")
                {
                    insert.CONF_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.CONF_DATE = "";
                }

                insert.CHK_FLAG = DdlChecked.SelectedValue.Trim().ToUpper();
                if (DdlChecked.SelectedValue.ToString() == "Y")
                {
                    insert.CHK_DATE = Convert.ToDateTime(TxtCheckedDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.CHK_DATE = "";
                }

                if (DdlChecked.SelectedValue.ToString() == "Y")
                {
                    insert.CHK_USERID = TxtCheckedBy.Text.Trim().ToUpper();
                }
                else
                {
                    insert.CHK_USERID = "";
                }

                insert.BCODE = DdlPreparedBy.SelectedValue.Trim();

                #endregion

                #region INSERT DATA INTO DAILY WORK_MAS DETAILS

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);
                int SRNO = 1;

                foreach (GridViewRow row in GvDailyWorkDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                        HiddenField HfTranNo = row.FindControl("HfTranNo") as HiddenField;
                        HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                        HiddenField HfWorkCode = row.FindControl("HfWorkCode") as HiddenField;

                        TextBox TxtFromTime = row.FindControl("TxtFromTime") as TextBox;
                        TextBox TxtToTime = row.FindControl("TxtToTime") as TextBox;
                        TextBox TxtVisitDescription = row.FindControl("TxtVisitDescription") as TextBox;
                        TextBox TxtWorkDescription = row.FindControl("TxtWorkDescription") as TextBox;
                        TextBox TxtRemark = row.FindControl("TxtRemark") as TextBox;

                        XmlElement HandleDetail2 = XDoc1.CreateElement("DailyWorkDetails");
                        HandleDetail2.SetAttribute("SRNO", SRNO.ToString());
                        HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                        HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                        HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                        HandleDetail2.SetAttribute("FRTIME", Convert.ToDateTime(TxtWorkDate.Text.Trim() + " " + TxtFromTime.Text.Trim()).ToString("MM-dd-yyyy hh:mm"));
                        HandleDetail2.SetAttribute("TOTIME", Convert.ToDateTime(TxtWorkDate.Text.Trim() + " " + TxtToTime.Text.Trim()).ToString("MM-dd-yyyy hh:mm"));//(TxtToTime.Text.Trim()));
                        HandleDetail2.SetAttribute("VISIT_PLACE", (TxtVisitDescription.Text.Trim()));
                        HandleDetail2.SetAttribute("WORK_DESC", (TxtWorkDescription.Text.Trim()));
                        HandleDetail2.SetAttribute("REMARK", (TxtRemark.Text.Trim()));
                        HandleDetail2.SetAttribute("INS_USERID", Session["USERNAME"].ToString());
                        HandleDetail2.SetAttribute("INS_DATE", "");
                        HandleDetail2.SetAttribute("UPD_USERID", Session["USERNAME"].ToString());
                        HandleDetail2.SetAttribute("UPD_DATE", "");
                        HandleDetail2.SetAttribute("WORK_FROM", "");
                        HandleDetail2.SetAttribute("WORK_CODE", HfWorkCode.Value.Trim());

                        root1.AppendChild(HandleDetail2);
                        SRNO++;

                    }
                }


                #endregion

                string str = DAILY_WORKMASLogicLayer.UpdateDAILY_WORKMASDetail(insert, validation.RSC(XDoc1.OuterXml));

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "DAILY WORK MASTER UPDATE  SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillDAILY_WORKMASGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "DAILY WORK MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : DAILY WORK MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }
                #endregion
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
                if (HfTranNo.Value != string.Empty && HfTranDate.Value != string.Empty)
                {
                    string str = DAILY_WORKMASLogicLayer.DeleteDAILY_WORKMASDetailsByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value.ToString()));
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
                        lblmsg.Text = "Error:Daily Work List Master Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillDAILY_WORKMASGrid(Session["COMP_CODE"].ToString());
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvDailyWorkCardMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvDailyWorkDetails.PageIndex = e.NewPageIndex;
                FillDAILY_WORKMASGrid(Session["COMP_CODE"].ToString());
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillEmployeeNameOnUpdate(string Emp_Code)
        {
            try
            {
                DataTable DtEmpName = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtEmpName = EMP_MASLogicLayer.GetAllEmployeeDetailsByCompany(Comp_Code);
                if (HfEmployeeCode.Value != string.Empty && HfEmployeeCode.Value!=null)
                {
                    DataView Dv = new DataView(DtEmpName);
                    Dv.RowFilter = "EMP_CODE='" + Emp_Code.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        TxtEmployeeName.Text = DtView.Rows[0]["EMP_NAME"].ToString();

                    }
                    
                }
                else
                {
                    TxtEmployeeName.Text = null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvDailyWorkCardMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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

                        DataSet ds = DAILY_WORKMASLogicLayer.GetAllIDWiseDAILY_WORKMASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable dtWork = ds.Tables[1];
                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfEmployeeCode.Value = dt.Rows[0]["EMP_CODE"].ToString();
                            FillEmployeeNameOnUpdate(dt.Rows[0]["EMP_CODE"].ToString());
                            TxtSrNo.Text = dt.Rows[0]["SRNO"].ToString();
                            TxtWorkDate.Text = Convert.ToDateTime(dt.Rows[0]["TRNDT"].ToString()).ToString("dd-MM-yyyy");
                            TxtEmployeeName.Text = dt.Rows[0]["EMP_CODE"].ToString();
                        //    DdlJobCategory.SelectedValue = dt.Rows[0]["BRANCH_CODE"].ToString();
                            DdlPreparedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            DdlConfirm.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            DdlChecked.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtCheckedBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            TxtCheckedDate.Text= dt.Rows[0]["CHK_DATE"].ToString();
                            Session["TRAN_NO"] = HfTranNo.Value;
                            Session["TRAN_DATE"] = HfTranDate.Value;

                            if (dtWork.Rows.Count > 0)
                            {
                                GvDailyWorkDetails.DataSource = dtWork;
                                GvDailyWorkDetails.DataBind();

                                GvDailyWorkDetails.Enabled = false;
                            }
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
                    #region Edit
                    clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataSet ds = DAILY_WORKMASLogicLayer.GetAllIDWiseDAILY_WORKMASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable dtWork = ds.Tables[1];
                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;


                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfEmployeeCode.Value = dt.Rows[0]["EMP_CODE"].ToString();
                            FillEmployeeNameOnUpdate(dt.Rows[0]["EMP_CODE"].ToString());
                            TxtSrNo.Text = dt.Rows[0]["SRNO"].ToString();
                            TxtWorkDate.Text = Convert.ToDateTime(dt.Rows[0]["TRNDT"].ToString()).ToString("dd-MM-yyyy");                    
                            //    DdlJobCategory.SelectedValue = dt.Rows[0]["BRANCH_CODE"].ToString();
                            DdlPreparedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            DdlConfirm.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            DdlChecked.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtCheckedBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            TxtCheckedDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            Session["TRAN_NO"] = HfTranNo.Value;
                            Session["TRAN_DATE"] = HfTranDate.Value;
                            if (dtWork.Rows.Count > 0)
                            {
                                GvDailyWorkDetails.DataSource = dtWork;
                                GvDailyWorkDetails.DataBind();

                                GvDailyWorkDetails.Enabled = true;
                                ViewState["CurrentTable"] =dtWork;
                            }
                            BtncallUpd.Text = "UPDATE";
                        }
                    }
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
                    clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataSet ds = DAILY_WORKMASLogicLayer.GetAllIDWiseDAILY_WORKMASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable dtWork = ds.Tables[1];
                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;


                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfEmployeeCode.Value = dt.Rows[0]["EMP_CODE"].ToString();
                            FillEmployeeNameOnUpdate(dt.Rows[0]["EMP_CODE"].ToString());
                            TxtSrNo.Text = dt.Rows[0]["SRNO"].ToString();
                            TxtWorkDate.Text = Convert.ToDateTime(dt.Rows[0]["TRNDT"].ToString()).ToString("dd-MM-yyyy");
                            TxtEmployeeName.Text = dt.Rows[0]["EMP_CODE"].ToString();
                            //    DdlJobCategory.SelectedValue = dt.Rows[0]["BRANCH_CODE"].ToString();
                            DdlPreparedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            DdlConfirm.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            DdlChecked.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtCheckedBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            TxtCheckedDate.Text = dt.Rows[0]["CHK_DATE"].ToString();

                            Session["TRAN_NO"] = HfTranNo.Value;
                            Session["TRAN_DATE"] = HfTranDate.Value;

                            if (dtWork.Rows.Count > 0)
                            {
                                GvDailyWorkDetails.DataSource = dtWork;
                                GvDailyWorkDetails.DataBind();

                                GvDailyWorkDetails.Enabled = false;
                            }
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
            catch (Exception)
            {

                throw;
            }
        }


     
        protected void BtnWorkListMaster_Click(object sender, EventArgs e)
        {
            //  Response.Redirect("~/Admin/WorkListMaster.aspx");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../admin/WorkListMaster.aspx', '_blank');", true);
        }

        protected void DdlConfirm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlConfirm.SelectedValue == "Y")
                {
                    TxtConfirmDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {                
                    TxtConfirmDate.Text = "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlChecked_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlChecked.SelectedValue == "Y")
                {
                    TxtCheckedBy.Text = Session["USERNAME"].ToString();
                    TxtCheckedDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    TxtCheckedBy.Text = "";
                    TxtCheckedDate.Text = "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnviewreport_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../reportviewPages/DailyWorkTimeCardPrint.aspx', '_blank');", true);
        }

    
    }
}