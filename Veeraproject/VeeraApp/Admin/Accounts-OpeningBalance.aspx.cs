using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp
{
    public partial class Accounts_Opening_Balance : System.Web.UI.Page
    {

        static DataTable DtSearch = new DataTable();
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

                if (!Page.IsPostBack)
            {
                DivEntry.Visible = false;
                DivView.Visible = true;
                FillDdlAccountName();
                FillGrid(Session["COMP_CODE"].ToString());

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
        public void FillDdlAccountName()
        {
            try
            {

                DataTable Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(Session["COMP_CODE"].ToString());
                DdlAccountName.DataSource = Dt;
                DdlAccountName.DataValueField = "ACODE";
                DdlAccountName.DataTextField = "ANAME";
                DdlAccountName.DataBind();


            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillLblAccountGroupName()
        {
            try
            {
                string ACODE = DdlAccountName.SelectedValue;
                DataTable Dt = ACCOUNTS_MASLogicLayer.GetIDWiseGROUP_NAMEFor_AccountBal(ACODE);
                if (Dt.Rows.Count > 0)
                {
                    lblAccountGroupName.Text = Dt.Rows[0]["GROUP_NAME"].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }




        public void ControllerEnable()
        {
            // HfAccountCode.Value = string.Empty;
            DdlAccountName.Enabled = true;
            lblAccountGroupName.Enabled = true;
            TxtOpeningBal.Enabled = true;
            DdlAccountType.Enabled = true;
            lblAccountGroupName.Enabled = false;
        }

        public void ControllerDisable()
        {
            // HfAccountCode.Value = string.Empty;
            DdlAccountName.Enabled = false;
            lblAccountGroupName.Enabled = false;
            TxtOpeningBal.Enabled = false;
            DdlAccountType.Enabled = false;
            lblAccountGroupName.Enabled = false;
        }
        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfAccountCode.Value = string.Empty;
            DdlAccountName.SelectedIndex = 0;
            lblAccountGroupName.Text = string.Empty;
            TxtOpeningBal.Text = string.Empty;
            DdlAccountType.SelectedIndex = 0;
            lblAccountGroupName.Text = string.Empty;

            BtncallUpd.Text = "SAVE";
        }
        protected void DdlAccountName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillLblAccountGroupName();
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

        public void FillGrid(string CompCode)
        {
            try
            {
                DataTable Dt = new DataTable();
                HfCompCode.Value = Session["COMP_CODE"].ToString();

                Dt = ACCT_BALLogicLayer.GetAllACCT_BALDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));

                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvAccOpenBal.DataSource = Dv.ToTable();
                GvAccOpenBal.DataBind();
                DtSearch = Dv.ToTable();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvAccOpenBal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvAccOpenBal.PageIndex = e.NewPageIndex;
                FillGrid(Session["COMP_CODE"].ToString());
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvAccOpenBal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();

                    GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
                    HiddenField COMP_CODE = row.FindControl("HfCompCode") as HiddenField;
                    HiddenField Yrdt1 = row.FindControl("HfYRDT1") as HiddenField;
                    string YRDT1 = Yrdt1.Value;

                    DataTable dt = ACCT_BALLogicLayer.GetAllIDWiseACCT_BALDetials(COMP_CODE.Value, e.CommandArgument.ToString(), YRDT1.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        // HfAccountCode.Value = dt.Rows[0][""].ToString();
                        DdlAccountName.SelectedValue = dt.Rows[0]["ACODE"].ToString();
                        TxtOpeningBal.Text = dt.Rows[0]["OP_BAL"].ToString();
                        DdlAccountType.SelectedValue = dt.Rows[0]["ATYPE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfYRDT1.Value = dt.Rows[0]["YRDT1"].ToString();
                        lblAccountGroupName.Text = dt.Rows[0]["GROUP_NAME"].ToString();
                        HfStatus.Value = dt.Rows[0]["STATUS"].ToString();
                    }
                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    Btncalldel.Visible = true;
                    BtncallUpd.Visible = false;
                    ControllerDisable();

                    #endregion
                }

                if (e.CommandName == "Edita")
                {
                    #region EDIT
                    clear();

                    GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
                    HiddenField COMP_CODE = row.FindControl("HfCompCode") as HiddenField;
                    HiddenField Yrdt1 = row.FindControl("HfYRDT1") as HiddenField;
                    string YRDT1 = Yrdt1.Value;

                    DataTable dt = ACCT_BALLogicLayer.GetAllIDWiseACCT_BALDetials(COMP_CODE.Value, e.CommandArgument.ToString(), YRDT1.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        // HfAccountCode.Value = dt.Rows[0][""].ToString();
                        DdlAccountName.SelectedValue = dt.Rows[0]["ACODE"].ToString();
                        TxtOpeningBal.Text = dt.Rows[0]["OP_BAL"].ToString();
                        DdlAccountType.SelectedValue = dt.Rows[0]["ATYPE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfYRDT1.Value = dt.Rows[0]["YRDT1"].ToString();
                        lblAccountGroupName.Text = dt.Rows[0]["GROUP_NAME"].ToString();
                        HfStatus.Value = dt.Rows[0]["STATUS"].ToString();


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
                    clear();

                    GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
                    HiddenField COMP_CODE = row.FindControl("HfCompCode") as HiddenField;
                    HiddenField Yrdt1 = row.FindControl("HfYRDT1") as HiddenField;
                    string YRDT1 = Yrdt1.Value;

                    DataTable dt = ACCT_BALLogicLayer.GetAllIDWiseACCT_BALDetials(COMP_CODE.Value, e.CommandArgument.ToString(), YRDT1.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        // HfAccountCode.Value = dt.Rows[0][""].ToString();
                        DdlAccountName.SelectedValue = dt.Rows[0]["ACODE"].ToString();
                        TxtOpeningBal.Text = dt.Rows[0]["OP_BAL"].ToString();
                        DdlAccountType.SelectedValue = dt.Rows[0]["ATYPE"].ToString();
                        lblAccountGroupName.Text = dt.Rows[0]["GROUP_NAME"].ToString();
                        HfStatus.Value = dt.Rows[0]["STATUS"].ToString();
                        #endregion

                    }

                    ControllerDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    UserRights();
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
                    ACCT_BALLogicLayer insert = new ACCT_BALLogicLayer();
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.ACODE = DdlAccountName.SelectedValue.Trim();
                    insert.YRDT1 = Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd");

                    if (TxtOpeningBal.Text == string.Empty)
                    {
                        insert.OP_BAL = "0";
                    }
                    else
                    {
                        insert.OP_BAL = TxtOpeningBal.Text.Trim();
                    }
                    insert.CUR_BAL = "0";
                    insert.CREDIT_AMT = "0";
                    insert.CREDIT_DAYS = "0";
                    insert.PAID_AMT = "0";
                    insert.STATUS = null;
                    insert.ATYPE = DdlAccountType.SelectedValue.Trim().ToUpper();
                    insert.LESS_AMT = "0";
                    insert.TDS_AMT = "0";
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    //insert.UPD_USERID = Session["USERNAME"].ToString();
                    //insert.UPD_TERMINAL = Session["PC"].ToString();
                    //insert.UPD_DATE = "";


                    //if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    //{
                        string str = ACCT_BALLogicLayer.InsertACCT_BALDetials(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "ACCOUNT OPENING BALANCE DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid(Session["COMP_CODE"].ToString());
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "ACCOUNT OPENING BALANCE ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : ACCOUNT OPENING BALANCE NOT SAVED";
                            lblmsg.ForeColor = Color.Red;
                        }
                 //   }


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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region INSERT _ UPDATE VALUE
                ACCT_BALLogicLayer insert = new ACCT_BALLogicLayer();
                insert.COMP_CODE = HfCompCode.Value.Trim(); //Session["COMP_CODE"].ToString();
                insert.ACODE = DdlAccountName.SelectedValue.Trim();
                insert.YRDT1 = Convert.ToDateTime(HfYRDT1.Value).ToString("yyyy-MM-dd"); //Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd");

                if (TxtOpeningBal.Text == string.Empty)
                {
                    insert.OP_BAL = "0";
                }
                else
                {
                    insert.OP_BAL = TxtOpeningBal.Text.Trim();
                }
                insert.CUR_BAL = "0";
                insert.CREDIT_AMT = "0";
                insert.CREDIT_DAYS = "0";
                insert.PAID_AMT = "0";
                insert.STATUS = HfStatus.Value.Trim().ToString();
                insert.ATYPE = DdlAccountType.SelectedValue.Trim().ToUpper();
                insert.LESS_AMT = "0";
                insert.TDS_AMT = "0";
                //insert.INS_USERID = Session["USERNAME"].ToString();
                //insert.INS_TERMINAL = Session["PC"].ToString();
                //insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";

                #endregion


                //if (btnSave.Text.Trim().ToUpper() == "SAVE")
                //{
                //    string str = ACCT_BALLogicLayer.InsertACCT_BALDetials(insert);
                //    if (str.Contains("successfully"))
                //    {
                //        lblmsg.Text = "ACCOUNT OPENING BALANCE DETAIL SAVE SUCCESSFULLY.";
                //        lblmsg.ForeColor = Color.Green;
                //        clear();
                //        FillGrid(Session["COMP_CODE"].ToString());
                //        UserRights();
                //    }
                //    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                //    {
                //        lblmsg.Text = "ACCOUNT OPENING BALANCE ALREADY EXIST.";
                //        lblmsg.ForeColor = Color.Red;
                //    }
                //    else
                //    {
                //        lblmsg.Text = "ERROR : ACCOUNT OPENING BALANCE NOT SAVED";
                //        lblmsg.ForeColor = Color.Red;
                //    }
                //}
                //else
                //{
                    string str = ACCT_BALLogicLayer.UpdateACCT_BALDetials(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "ACCOUNT OPENING BALANCE UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(Session["COMP_CODE"].ToString());
                        UserRights();
                    }
                    else if (str.Contains("Already"))
                    {
                        lblmsg.Text = "ACCOUNT OPENING BALANCE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : ACCOUNT OPENING BALANCE NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
              //  }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE  
                string ACODE = DdlAccountName.SelectedValue;
                string YRDT1 = HfYRDT1.Value;
                if (HfCompCode.Value != string.Empty && HfYRDT1.Value != string.Empty)
                {
                    string str = ACCT_BALLogicLayer.DeleteACCOUNTS_BALDetailsByID(HfCompCode.Value, ACODE, YRDT1.ToString());
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
                        lblmsg.Text = "Error:Branch Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillGrid(Session["COMP_CODE"].ToString());
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(TxtSearch.Text!=string.Empty)
                {
                    DataView Dv = new DataView(DtSearch);
                    Dv.RowFilter = "AccountName like '%" + TxtSearch.Text.Trim() + "%' ";
                    GvAccOpenBal.DataSource = Dv.ToTable();
                    GvAccOpenBal.DataBind();
                }
                else
                {
                    GvAccOpenBal.DataSource = DtSearch;
                    GvAccOpenBal.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}