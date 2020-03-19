using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;


namespace VeeraApp.Admin
{
    public partial class EmployeeGeneralMaster : System.Web.UI.Page
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

                    //   DivEntry.Visible = false;
                    //  DivView.Visible = true;

                    FillGENEARL_MASTERGrid(Session["COMP_CODE"].ToString());

                    //SetInitialRowForPFGrid();
                    //SetInitialRowForESICGrid();
                    //SetInitialRowForOTGrid();
                    //SetInitialRowForAllowanceGrid();

                }
            }

            else
            {
                Response.Redirect("../Login.aspx");
            }

        }


        public void clear()
        {
            HfCompCode.Value = string.Empty;
            HfTranNo.Value = string.Empty;
            HfTranType.Value = string.Empty;

            TxtPFFromDate.Text = string.Empty;
            TxtPFToDate.Text = string.Empty;
            TxtPFRate.Text = string.Empty;
            TxtPFFPFRate.Text = string.Empty;

            TxtESICFromDate.Text = string.Empty;
            TxtESICToDate.Text = string.Empty;
            TxtESICCompanyRate.Text = string.Empty;
            TxtESICEmployeeRate.Text = string.Empty;

            TxtOTFromDate.Text = string.Empty;
            TxtOTToDate.Text = string.Empty;
            TxtOTWorkingHours.Text = string.Empty;
            TxtOTCalculateHours.Text = string.Empty;
            TxtOTCalculateRate1.Text = string.Empty;

            TxtAllowanceFromDate.Text = string.Empty;
            TxtAllowanceToDate.Text = string.Empty;
            TxtAllowanceCalculateRate1.Text = string.Empty;
            TxtAllowanceCalculateHours.Text = string.Empty;

            btnSavePFData.Text = "SAVE";
            btnSaveESICData.Text = "SAVE";
            BtnSaveOTData.Text = "SAVE";
            BtnSaveAllowanceData.Text = "SAVE";

        }

        public void ControllerEnable()
        {

            TxtPFFromDate.Enabled = true;
            TxtPFToDate.Enabled = true;
            TxtPFRate.Enabled = true;
            TxtPFFPFRate.Enabled = true;

            TxtESICFromDate.Enabled = true;
            TxtESICToDate.Enabled = true;
            TxtESICCompanyRate.Enabled = true;
            TxtESICEmployeeRate.Enabled = true;

            TxtOTFromDate.Enabled = true;
            TxtOTToDate.Enabled = true;
            TxtOTWorkingHours.Enabled = true;
            TxtOTCalculateHours.Enabled = true;
            TxtOTCalculateRate1.Enabled = true;

            TxtAllowanceFromDate.Enabled = true;
            TxtAllowanceToDate.Enabled = true;
            TxtAllowanceCalculateRate1.Enabled = true;
            TxtAllowanceCalculateHours.Enabled = true;
        }


        public void ControllerDisable()
        {

            TxtPFFromDate.Enabled = false;
            TxtPFToDate.Enabled = false;
            TxtPFRate.Enabled = false;
            TxtPFFPFRate.Enabled = false;

            TxtESICFromDate.Enabled = false;
            TxtESICToDate.Enabled = false;
            TxtESICCompanyRate.Enabled = false;
            TxtESICEmployeeRate.Enabled = false;

            TxtOTFromDate.Enabled = false;
            TxtOTToDate.Enabled = false;
            TxtOTWorkingHours.Enabled = false;
            TxtOTCalculateHours.Enabled = false;
            TxtOTCalculateRate1.Enabled = false;

            TxtAllowanceFromDate.Enabled = false;
            TxtAllowanceToDate.Enabled = false;
            TxtAllowanceCalculateRate1.Enabled = false;
            TxtAllowanceCalculateHours.Enabled = false;
        }


        private void SetInitialRowForPFGrid()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_TYPE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("FRDT", typeof(string));
            table.Columns.Add("TODT", typeof(string));
            table.Columns.Add("WRK_HOURS", typeof(string));
            table.Columns.Add("CAL_HOURS", typeof(string));
            table.Columns.Add("CAL_RATE1", typeof(string));
            table.Columns.Add("CAL_RATE2", typeof(string));


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_TYPE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["FRDT"] = string.Empty;
            dr["TODT"] = string.Empty;
            dr["WRK_HOURS"] = string.Empty;
            dr["CAL_HOURS"] = string.Empty;
            dr["CAL_RATE1"] = string.Empty;
            dr["CAL_RATE2"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["PFCalculateTable"] = table;

            GvPFCalculateMaster.DataSource = table;
            GvPFCalculateMaster.DataBind();

        }



        private void SetInitialRowForESICGrid()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_TYPE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("FRDT", typeof(string));
            table.Columns.Add("TODT", typeof(string));
            table.Columns.Add("WRK_HOURS", typeof(string));
            table.Columns.Add("CAL_HOURS", typeof(string));
            table.Columns.Add("CAL_RATE1", typeof(string));
            table.Columns.Add("CAL_RATE2", typeof(string));


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_TYPE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["FRDT"] = string.Empty;
            dr["TODT"] = string.Empty;
            dr["WRK_HOURS"] = string.Empty;
            dr["CAL_HOURS"] = string.Empty;
            dr["CAL_RATE1"] = string.Empty;
            dr["CAL_RATE2"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["ESICCalculateTable"] = table;

            GvESICCalculateMaster.DataSource = table;
            GvESICCalculateMaster.DataBind();
        }


        private void SetInitialRowForOTGrid()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_TYPE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("FRDT", typeof(string));
            table.Columns.Add("TODT", typeof(string));
            table.Columns.Add("WRK_HOURS", typeof(string));
            table.Columns.Add("CAL_HOURS", typeof(string));
            table.Columns.Add("CAL_RATE1", typeof(string));
            table.Columns.Add("CAL_RATE2", typeof(string));


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_TYPE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["FRDT"] = string.Empty;
            dr["TODT"] = string.Empty;
            dr["WRK_HOURS"] = string.Empty;
            dr["CAL_HOURS"] = string.Empty;
            dr["CAL_RATE1"] = string.Empty;
            dr["CAL_RATE2"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["OTCalculateTable"] = table;

            GvOTCalculateMaster.DataSource = table;
            GvOTCalculateMaster.DataBind();
        }



        private void SetInitialRowForAllowanceGrid()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_TYPE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("FRDT", typeof(string));
            table.Columns.Add("TODT", typeof(string));
            table.Columns.Add("WRK_HOURS", typeof(string));
            table.Columns.Add("CAL_HOURS", typeof(string));
            table.Columns.Add("CAL_RATE1", typeof(string));
            table.Columns.Add("CAL_RATE2", typeof(string));


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_TYPE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["FRDT"] = string.Empty;
            dr["TODT"] = string.Empty;
            dr["WRK_HOURS"] = string.Empty;
            dr["CAL_HOURS"] = string.Empty;
            dr["CAL_RATE1"] = string.Empty;
            dr["CAL_RATE2"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["AllowanceCalculateTable"] = table;

            GvAllowanceClaculateMaster.DataSource = table;
            GvAllowanceClaculateMaster.DataBind();
        }


        protected void BtnAddPF_Click(object sender, EventArgs e)
        {
            clear();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelSavePF", "ShowModelSavePF()", true);

           
        }

        protected void BtnAddESIC_Click(object sender, EventArgs e)
        {
            clear();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelSaveESIC", "ShowModelSaveESIC()", true);
          
        }

        protected void BtnAddOT_Click(object sender, EventArgs e)
        {
            clear();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelSaveOT", "ShowModelSaveOT()", true);
        }

        protected void BtnAddAllowance_Click(object sender, EventArgs e)
        {
            clear();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelSaveAllowance", "ShowModelSaveAllowance()", true);

        }


        public void FillGENEARL_MASTERGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = GENERAL_MASLogicLayer.GetAllGENERAL_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));

           

            DataView DvP = new DataView(Dt);
            DvP.RowFilter = "TRAN_TYPE='P'";

            DataView DvE = new DataView(Dt);
            DvE.RowFilter = "TRAN_TYPE='E'";

            DataView DvO = new DataView(Dt);
            DvO.RowFilter = "TRAN_TYPE='O'";

            DataView DvA = new DataView(Dt);
            DvA.RowFilter = "TRAN_TYPE='A'";


            GvPFCalculateMaster.DataSource = DvP.ToTable();
            GvPFCalculateMaster.DataBind();

            GvESICCalculateMaster.DataSource = DvE.ToTable();
            GvESICCalculateMaster.DataBind();

            GvOTCalculateMaster.DataSource = DvO.ToTable();
            GvOTCalculateMaster.DataBind();

            GvAllowanceClaculateMaster.DataSource = DvA.ToTable();
            GvAllowanceClaculateMaster.DataBind();

            //DtSearch = Dv.ToTable();

        }


        public void InsertGeneralMaster(string COMP_CODE, string TRAN_TYPE, string FROM_DATE, string TO_DATE, string WORKING_HOURS, string CAL_HOURS, string CAL_RATE1, string CAL_RATE2)
        {
            //Save COde

            #region INSERT DATA INTO GENERAL MASTER

            GENERAL_MASLogicLayer insert = new GENERAL_MASLogicLayer();

            insert.COMP_CODE = Session["COMP_CODE"].ToString();
            insert.TRAN_TYPE = TRAN_TYPE.ToString().ToUpper();
            //insert.TRAN_NO = HfTranNo.Value.Trim();
            insert.FRDT = Convert.ToDateTime(FROM_DATE.Trim()).ToString("MM-dd-yyyy"); // FROM_DATE.ToString();
            insert.TODT = Convert.ToDateTime(TO_DATE.Trim()).ToString("MM-dd-yyyy");  //TO_DATE.ToString();

            if (WORKING_HOURS != string.Empty)
            {
                insert.WRK_HOURS = WORKING_HOURS.Trim();
            }
            else
            {
                insert.WRK_HOURS = null;
            }

            if (CAL_HOURS != string.Empty)
            {
                insert.CAL_HOURS = CAL_HOURS.Trim();
            }
            else
            {
                insert.CAL_HOURS = null;
            }

            if (CAL_RATE1 != string.Empty)
            {
                insert.CAL_RATE1 = CAL_RATE1.Trim();
            }
            else
            {
                insert.CAL_RATE1 = null;
            }

            if (CAL_RATE2 != string.Empty)
            {
                insert.CAL_RATE2 = CAL_RATE2.Trim();
            }
            else
            {
                insert.CAL_RATE2 = null;
            }

            #endregion

            if (btnSavePFData.Text == "SAVE")
            {

                string str = GENERAL_MASLogicLayer.InsertGENERAL_MASDetails(insert, Session["COMP_CODE"].ToString(), TRAN_TYPE.ToString());

                if (str.Contains("successfully"))
                {

                    lblmsg.Text = "EMPLOYEE GENERAL MASTER SAVE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillGENEARL_MASTERGrid(Session["COMP_CODE"].ToString());
                    //     UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "AEMPLOYEE GENERAL MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : EMPLOYEE GENERAL MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }
            }
            else
            {
                insert.TRAN_NO = HfTranNo.Value.Trim();
                
                string str = GENERAL_MASLogicLayer.UpdateGENERAL_MASDetails(insert, HfCompCode.Value.ToString(), HfTranType.Value.ToString());
    

                if (str.Contains("successfully"))
                {

                    lblmsg.Text = "EMPLOYEE GENERAL MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillGENEARL_MASTERGrid(Session["COMP_CODE"].ToString());
                  


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "AEMPLOYEE GENERAL MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : EMPLOYEE GENERAL MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }
            }


        }

        protected void btnSavePFData_Click(object sender, EventArgs e)
        {
            //PF CONTROLS

            InsertGeneralMaster(Session["COMP_CODE"].ToString(),"P", TxtPFFromDate.Text.ToString(), TxtPFToDate.Text.ToString(),string.Empty, string.Empty, TxtPFRate.Text.ToString(), TxtPFFPFRate.Text.ToString());
            
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModelSavePF", "HideModelSavePF()", true);

        }

        protected void btnSaveESICData_Click(object sender, EventArgs e)
        {
            //ESIC CONTROL
            InsertGeneralMaster(Session["COMP_CODE"].ToString(), "E", TxtESICFromDate.Text.ToString(), TxtESICToDate.Text.ToString(), string.Empty, string.Empty, TxtESICEmployeeRate.Text.ToString(), TxtESICCompanyRate.Text.ToString());

            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModelSaveESIC", "HideModelSaveESIC()", true);
           
        }

        protected void BtnSaveOTData_Click(object sender, EventArgs e)
        {
            // OT CONTROL
            InsertGeneralMaster(Session["COMP_CODE"].ToString(), "O", TxtOTFromDate.Text.ToString(), TxtOTToDate.Text.ToString(), TxtOTWorkingHours.Text.ToString(), TxtOTCalculateHours.Text.ToString(), TxtOTCalculateRate1.Text.ToString(), string.Empty);

            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModelSaveOT", "HideModelSaveOT()", true);
          
        }

        protected void BtnSaveAllowanceData_Click(object sender, EventArgs e)
        {
            // ALLOWANCE CONTROL
            InsertGeneralMaster(Session["COMP_CODE"].ToString(), "A", TxtAllowanceFromDate.Text.ToString(), TxtAllowanceToDate.Text.ToString(), string.Empty , TxtAllowanceCalculateHours.Text.ToString(), TxtAllowanceCalculateRate1.Text.ToString(), string.Empty);

            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModelSaveAllowance", "HideModelSaveAllowance()", true);
        }



        protected void GvPFCalculateMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Selecta")
                {
                    #region DELETE
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfCompCodeGrid = (row.FindControl("HfCompCodeGrid")) as HiddenField;
                        HiddenField HfTranTypeGrid = (row.FindControl("HfTranTypeGrid")) as HiddenField; 

                         DataTable dt = GENERAL_MASLogicLayer.GetAllIDWiseGENERAL_MASDetials(HfCompCodeGrid.Value.Trim().ToString(),e.CommandArgument.ToString(),HfTranTypeGrid.Value.Trim().ToString());

                        if (dt.Rows.Count > 0)
                        {
                          

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtPFFromDate.Text = Convert.ToDateTime(dt.Rows[0]["FRDT"].ToString()).ToString("dd-MM-yyyy");
                            TxtPFToDate.Text = Convert.ToDateTime(dt.Rows[0]["TODT"].ToString()).ToString("dd-MM-yyyy");
                            TxtPFRate.Text = dt.Rows[0]["CAL_RATE1"].ToString();
                            TxtPFFPFRate.Text = dt.Rows[0]["CAL_RATE2"].ToString();

                            btnSavePFData.Text = "UPDATE";
                        }

                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelSavePF", "ShowModelSavePF()", true);

                    }

                    #endregion

                }


                if (e.CommandName == "Deletea")
                {
                    #region SELECT ROW
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfCompCodeGrid = (row.FindControl("HfCompCodeGrid")) as HiddenField;
                        HiddenField HfTranTypeGrid = (row.FindControl("HfTranTypeGrid")) as HiddenField;

                        DataTable dt = GENERAL_MASLogicLayer.GetAllIDWiseGENERAL_MASDetials(HfCompCodeGrid.Value.Trim().ToString(), e.CommandArgument.ToString(), HfTranTypeGrid.Value.Trim().ToString());

                        if (dt.Rows.Count > 0)
                        {


                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtPFFromDate.Text = Convert.ToDateTime(dt.Rows[0]["FRDT"].ToString()).ToString("dd-MM-yyyy");
                            TxtPFToDate.Text = Convert.ToDateTime(dt.Rows[0]["TODT"].ToString()).ToString("dd-MM-yyyy");
                            TxtPFRate.Text = dt.Rows[0]["CAL_RATE1"].ToString();
                            TxtPFFPFRate.Text = dt.Rows[0]["CAL_RATE2"].ToString();

                        }

                    }
                    #endregion

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelDeletePF", "ShowModelDeletePF()", true);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvESICCalculateMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Selecta")
                {
                    #region DELETE
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfCompCodeGrid = (row.FindControl("HfCompCodeGrid")) as HiddenField;
                        HiddenField HfTranTypeGrid = (row.FindControl("HfTranTypeGrid")) as HiddenField;

                        DataTable dt = GENERAL_MASLogicLayer.GetAllIDWiseGENERAL_MASDetials(HfCompCodeGrid.Value.Trim().ToString(), e.CommandArgument.ToString(), HfTranTypeGrid.Value.Trim().ToString());

                        if (dt.Rows.Count > 0)
                        {


                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtESICFromDate.Text = dt.Rows[0]["FRDT"].ToString();
                            TxtESICToDate.Text = dt.Rows[0]["TODT"].ToString();
                            TxtESICEmployeeRate.Text = dt.Rows[0]["CAL_RATE1"].ToString();
                            TxtESICCompanyRate.Text = dt.Rows[0]["CAL_RATE2"].ToString();

                            btnSaveESICData.Text = "UPDATE";
                        }

                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelSaveESIC", "ShowModelSaveESIC()", true);

                    }

                    #endregion

                }

                if (e.CommandName == "Deletea")
                {
                    #region SELECT ROW
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfCompCodeGrid = (row.FindControl("HfCompCodeGrid")) as HiddenField;
                        HiddenField HfTranTypeGrid = (row.FindControl("HfTranTypeGrid")) as HiddenField;

                        DataTable dt = GENERAL_MASLogicLayer.GetAllIDWiseGENERAL_MASDetials(HfCompCodeGrid.Value.Trim().ToString(), e.CommandArgument.ToString(), HfTranTypeGrid.Value.Trim().ToString());

                        if (dt.Rows.Count > 0)
                        {



                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtESICFromDate.Text = dt.Rows[0]["FRDT"].ToString();
                            TxtESICToDate.Text = dt.Rows[0]["TODT"].ToString();
                            TxtESICEmployeeRate.Text = dt.Rows[0]["CAL_RATE1"].ToString();
                            TxtESICCompanyRate.Text = dt.Rows[0]["CAL_RATE2"].ToString();
                        }

                    }
                    #endregion

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelDeleteESIC", "ShowModelDeleteESIC()", true);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvOTCalculateMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Selecta")
                {
                    #region DELETE
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfCompCodeGrid = (row.FindControl("HfCompCodeGrid")) as HiddenField;
                        HiddenField HfTranTypeGrid = (row.FindControl("HfTranTypeGrid")) as HiddenField;

                        DataTable dt = GENERAL_MASLogicLayer.GetAllIDWiseGENERAL_MASDetials(HfCompCodeGrid.Value.Trim().ToString(), e.CommandArgument.ToString(), HfTranTypeGrid.Value.Trim().ToString());

                        if (dt.Rows.Count > 0)
                        {


                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtOTFromDate.Text = dt.Rows[0]["FRDT"].ToString();
                            TxtOTToDate.Text = dt.Rows[0]["TODT"].ToString();
                            TxtOTWorkingHours.Text = dt.Rows[0]["WRK_HOURS"].ToString();
                            TxtOTCalculateHours.Text = dt.Rows[0]["CAL_HOURS"].ToString();
                            TxtOTCalculateRate1.Text = dt.Rows[0]["CAL_RATE1"].ToString();
                            

                            BtnSaveOTData.Text = "UPDATE";
                        }

                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelSaveOT", "ShowModelSaveOT()", true);

                    }

                    #endregion

                }


                if (e.CommandName == "Deletea")
                {
                    #region SELECT ROW
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfCompCodeGrid = (row.FindControl("HfCompCodeGrid")) as HiddenField;
                        HiddenField HfTranTypeGrid = (row.FindControl("HfTranTypeGrid")) as HiddenField;

                        DataTable dt = GENERAL_MASLogicLayer.GetAllIDWiseGENERAL_MASDetials(HfCompCodeGrid.Value.Trim().ToString(), e.CommandArgument.ToString(), HfTranTypeGrid.Value.Trim().ToString());

                        if (dt.Rows.Count > 0)
                        {


                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtOTFromDate.Text = dt.Rows[0]["FRDT"].ToString();
                            TxtOTToDate.Text = dt.Rows[0]["TODT"].ToString();
                            TxtOTWorkingHours.Text = dt.Rows[0]["WRK_HOURS"].ToString();
                            TxtOTCalculateHours.Text = dt.Rows[0]["CAL_HOURS"].ToString();
                            TxtOTCalculateRate1.Text = dt.Rows[0]["CAL_RATE1"].ToString();

                        }

                    }
                    #endregion

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelDeleteOT", "ShowModelDeleteOT()", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvAllowanceClaculateMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Selecta")
                {
                    #region SELECT ROW
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfCompCodeGrid = (row.FindControl("HfCompCodeGrid")) as HiddenField;
                        HiddenField HfTranTypeGrid = (row.FindControl("HfTranTypeGrid")) as HiddenField;

                        DataTable dt = GENERAL_MASLogicLayer.GetAllIDWiseGENERAL_MASDetials(HfCompCodeGrid.Value.Trim().ToString(), e.CommandArgument.ToString(), HfTranTypeGrid.Value.Trim().ToString());

                        if (dt.Rows.Count > 0)
                        {


                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtAllowanceFromDate.Text = dt.Rows[0]["FRDT"].ToString();
                            TxtAllowanceToDate.Text = dt.Rows[0]["TODT"].ToString();
                            TxtAllowanceCalculateHours.Text = dt.Rows[0]["CAL_HOURS"].ToString();
                            TxtAllowanceCalculateRate1.Text = dt.Rows[0]["CAL_RATE1"].ToString();


                            BtnSaveAllowanceData.Text = "UPDATE";
                        }

                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelSaveAllowance", "ShowModelSaveAllowance()", true);

                    }

                    #endregion

                }


                if (e.CommandName == "Deletea")
                {
                    #region SELECT ROW
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfCompCodeGrid = (row.FindControl("HfCompCodeGrid")) as HiddenField;
                        HiddenField HfTranTypeGrid = (row.FindControl("HfTranTypeGrid")) as HiddenField;

                        DataTable dt = GENERAL_MASLogicLayer.GetAllIDWiseGENERAL_MASDetials(HfCompCodeGrid.Value.Trim().ToString(), e.CommandArgument.ToString(), HfTranTypeGrid.Value.Trim().ToString());

                        if (dt.Rows.Count > 0)
                        {


                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtAllowanceFromDate.Text = dt.Rows[0]["FRDT"].ToString();
                            TxtAllowanceToDate.Text = dt.Rows[0]["TODT"].ToString();
                            TxtAllowanceCalculateHours.Text = dt.Rows[0]["CAL_HOURS"].ToString();
                            TxtAllowanceCalculateRate1.Text = dt.Rows[0]["CAL_RATE1"].ToString();


                        }

                    }
                    #endregion

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelDeleteAllowance", "ShowModelDeleteAllowance()", true);
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnDeletePF_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE  PF MASTER
                string str = GENERAL_MASLogicLayer.DeleteGENERAL_MASDetaislByID(HfCompCode.Value.ToString(),HfTranNo.Value.ToString(),HfTranType.Value.ToString());
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
                    lblmsg.Text = "Error:PF Calculate Master Deleted";
                    lblmsg.ForeColor = Color.Red;
                }
                clear();
                FillGENEARL_MASTERGrid(Convert.ToString(Session["COMP_CODE"]));
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnDeleteESIC_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE  ESIC MASTER
                string str = GENERAL_MASLogicLayer.DeleteGENERAL_MASDetaislByID(HfCompCode.Value.ToString(), HfTranNo.Value.ToString(), HfTranType.Value.ToString());
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
                    lblmsg.Text = "Error:ESIC Calculate Master Deleted";
                    lblmsg.ForeColor = Color.Red;
                }
                clear();
                FillGENEARL_MASTERGrid(Convert.ToString(Session["COMP_CODE"]));
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnDeleteOT_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE  OT MASTER

                string str = GENERAL_MASLogicLayer.DeleteGENERAL_MASDetaislByID(HfCompCode.Value.ToString(), HfTranNo.Value.ToString(), HfTranType.Value.ToString());
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
                    lblmsg.Text = "Error:OT Calculate Master Deleted";
                    lblmsg.ForeColor = Color.Red;
                }
                clear();
                FillGENEARL_MASTERGrid(Convert.ToString(Session["COMP_CODE"]));
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnDeleteAllowance_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE  ALLOWANCE MASTER

                string str = GENERAL_MASLogicLayer.DeleteGENERAL_MASDetaislByID(HfCompCode.Value.ToString(), HfTranNo.Value.ToString(), HfTranType.Value.ToString());
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
                    lblmsg.Text = "Error:Allowance Calculate Master Deleted";
                    lblmsg.ForeColor = Color.Red;
                }
                clear();
                FillGENEARL_MASTERGrid(Convert.ToString(Session["COMP_CODE"]));
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}