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
    public partial class BranchMaster : System.Web.UI.Page
    {
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
                    //  FillDdlCompany();
                    FillGrid(Session["COMP_CODE"].ToString());
                    UserRights();
                    DivEntry.Visible = false;
                    DivView.Visible = true;
                    FillDdlCreditExpenseACName1();
                    FillDdlCreditExpenseACName2();
                    FillDdlCreditExpenseACName3();
                    FillDdlDebitExpenseACName1();
                    FillDdlDebitExpenseACName2();
                    FillDdlDebitExpenseACName3();
                    FillDdlBranchServiceCreditAC();
                    FillDdlBranchServiceDebitAC();
                    FillDdlBranchReceivedCreditAC();
                    FillDdlBranchReceivedDebitAC();

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


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetStateName(string prefixText)
       {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from STATE_MAS where  STATE_NAME like  @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> StateNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StateNames.Add(dt.Rows[i][1].ToString());
            }
            return StateNames;
        }

  

        public void FillDdlCompany()
        {
            try
            {
                //DataTable Dt = COMPANYLogicLayer.GetAllCOMPANYDetials_DDL();
                //DdlCompany.DataSource = Dt;
                //DdlCompany.DataValueField = "COMP_CODE";
                //DdlCompany.DataTextField = "NAME";
                //DdlCompany.DataBind();
               
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlCreditExpenseACName1()
        {
            try
            {
                HfCompCode.Value = Session["COMP_CODE"].ToString();
                string COMPCODE = HfCompCode.Value;
                DataTable Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(COMPCODE);
                DdlCreditExpenseACName1.DataSource = Dt;
                DdlCreditExpenseACName1.DataValueField = "ACODE";
                DdlCreditExpenseACName1.DataTextField = "ANAME";
                DdlCreditExpenseACName1.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlCreditExpenseACName2()
        {
            try
            {
                HfCompCode.Value = Session["COMP_CODE"].ToString();
                string COMPCODE = HfCompCode.Value;
                DataTable Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(COMPCODE);
                DdlCreditExpenseACName2.DataSource = Dt;
                DdlCreditExpenseACName2.DataValueField = "ACODE";
                DdlCreditExpenseACName2.DataTextField = "ANAME";
                DdlCreditExpenseACName2.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlCreditExpenseACName3()
        {
            try
            {
                HfCompCode.Value = Session["COMP_CODE"].ToString();
                string COMPCODE = HfCompCode.Value;
                DataTable Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(COMPCODE);
                DdlCreditExpenseACName3.DataSource = Dt;
                DdlCreditExpenseACName3.DataValueField = "ACODE";
                DdlCreditExpenseACName3.DataTextField = "ANAME";
                DdlCreditExpenseACName3.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlDebitExpenseACName1()
        {
            try
            {
                HfCompCode.Value = Session["COMP_CODE"].ToString();
                string COMPCODE = HfCompCode.Value;
                DataTable Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(COMPCODE);
                DdlDebitExpenseACName1.DataSource = Dt;
                DdlDebitExpenseACName1.DataValueField = "ACODE";
                DdlDebitExpenseACName1.DataTextField = "ANAME";
                DdlDebitExpenseACName1.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlDebitExpenseACName2()
        {
            try
            {
                HfCompCode.Value = Session["COMP_CODE"].ToString();
                string COMPCODE = HfCompCode.Value;
                DataTable Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(COMPCODE);
                DdlDebitExpenseACName2.DataSource = Dt;
                DdlDebitExpenseACName2.DataValueField = "ACODE";
                DdlDebitExpenseACName2.DataTextField = "ANAME";
                DdlDebitExpenseACName2.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlDebitExpenseACName3()
        {
            try
            {
                HfCompCode.Value = Session["COMP_CODE"].ToString();
                string COMPCODE = HfCompCode.Value;
                DataTable Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(COMPCODE);
                DdlDebitExpenseACName3.DataSource = Dt;
                DdlDebitExpenseACName3.DataValueField = "ACODE";
                DdlDebitExpenseACName3.DataTextField = "ANAME";
                DdlDebitExpenseACName3.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlBranchServiceCreditAC()
        {
            try
            {
                HfCompCode.Value = Session["COMP_CODE"].ToString();
                string COMPCODE = HfCompCode.Value;
                DataTable Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(COMPCODE);
                DdlBranchServiceCreditAC.DataSource = Dt;
                DdlBranchServiceCreditAC.DataValueField = "ACODE";
                DdlBranchServiceCreditAC.DataTextField = "ANAME";
                DdlBranchServiceCreditAC.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlBranchServiceDebitAC()
        {
            try
            {
                HfCompCode.Value = Session["COMP_CODE"].ToString();
                string COMPCODE = HfCompCode.Value;
                DataTable Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(COMPCODE);
                DdlBranchServiceDebitAC.DataSource = Dt;
                DdlBranchServiceDebitAC.DataValueField = "ACODE";
                DdlBranchServiceDebitAC.DataTextField = "ANAME";
                DdlBranchServiceDebitAC.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlBranchReceivedCreditAC()
        {
            try
            {
                HfCompCode.Value = Session["COMP_CODE"].ToString();
                string COMPCODE = HfCompCode.Value;
                DataTable Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(COMPCODE);
                DdlBranchReceivedCreditAC.DataSource = Dt;
                DdlBranchReceivedCreditAC.DataValueField = "ACODE";
                DdlBranchReceivedCreditAC.DataTextField = "ANAME";
                DdlBranchReceivedCreditAC.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlBranchReceivedDebitAC()
        {
            try
            {
                HfCompCode.Value = Session["COMP_CODE"].ToString();
                string COMPCODE = HfCompCode.Value;
                DataTable Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(COMPCODE);
                DdlBranchReceivedDebitAC.DataSource = Dt;
                DdlBranchReceivedDebitAC.DataValueField = "ACODE";
                DdlBranchReceivedDebitAC.DataTextField = "ANAME";
                DdlBranchReceivedDebitAC.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ControllersEnable()
        {
            try
            {
                TxtBranchName.Enabled = true;
                //  TxtBranchCode.Text = string.Empty;
                TxtBranchShort.Enabled = true;
                DdlBranchType.Enabled = true;
            //   DdlCompany.Enabled = true;
                TxtBranchAddress1.Enabled = true;
                TxtBranchAddress2.Enabled = true;
                TxtBranchAddress3.Enabled = true;
                TxtBranchPhoneNo.Enabled = true;
                TxtBranchFax.Enabled = true;
                TxtBranchEmailAddress.Enabled = true;
                TxtBranchAutoEmailAddress.Enabled = true;
                DdlCreditExpenseACName1.Enabled = true;
                DdlCreditExpenseACName2.Enabled = true;
                DdlCreditExpenseACName3.Enabled = true;
                DdlDebitExpenseACName1.Enabled = true;
                DdlDebitExpenseACName2.Enabled = true;
                DdlDebitExpenseACName3.Enabled = true;
                DdlBranchServiceCreditAC.Enabled = true;
                DdlBranchServiceDebitAC.Enabled = true;
                TxtBranchState.Enabled = true;
                TxtBranchStateNo.Enabled = true;
                DdlGSTAppllicableFlag.Enabled = true;
                TxtCity.Enabled = true;
                TxtGstAppDate.Enabled = true;
                TxtBranchGSTNo.Enabled = true;
                DdlBranchReceivedDebitAC.Enabled = true;
                DdlBranchReceivedCreditAC.Enabled = true;

              
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ControllersDisable()
        {
            try
            {
                TxtBranchName.Enabled = false;
                //  TxtBranchCode.Text = string.Empty;
                TxtBranchShort.Enabled = false;
                DdlBranchType.Enabled = false;
            //    DdlCompany.Enabled = false;
                TxtBranchAddress1.Enabled = false;
                TxtBranchAddress2.Enabled = false;
                TxtBranchAddress3.Enabled = false;
                TxtBranchPhoneNo.Enabled = false;
                TxtBranchFax.Enabled = false;
                TxtBranchEmailAddress.Enabled = false;
                TxtBranchAutoEmailAddress.Enabled = false;
                DdlCreditExpenseACName1.Enabled = false;
                DdlCreditExpenseACName2.Enabled = false;
                DdlCreditExpenseACName3.Enabled = false;
                DdlDebitExpenseACName1.Enabled = false;
                DdlDebitExpenseACName2.Enabled = false;
                DdlDebitExpenseACName3.Enabled = false;
                DdlBranchServiceCreditAC.Enabled = false;
                DdlBranchServiceDebitAC.Enabled = false;
                TxtBranchState.Enabled = false;
                TxtBranchStateNo.Enabled = false;
                DdlGSTAppllicableFlag.Enabled = false;
                TxtCity.Enabled = false;
                TxtGstAppDate.Enabled = false;
                TxtBranchGSTNo.Enabled = false;
                DdlBranchReceivedDebitAC.Enabled = false;
                DdlBranchReceivedCreditAC.Enabled = false;
               
            }
            catch(Exception)
            {
                throw;
            }
        }


        public void clear()
        {
            try
            {
                DivEntry.Visible = false;
                DivView.Visible = true;
                TxtBranchName.Text = string.Empty;
              //  TxtBranchCode.Text = string.Empty;
                TxtBranchShort.Text = string.Empty;
                DdlBranchType.SelectedIndex = 0;
             //   DdlCompany.SelectedIndex = 0;
                TxtBranchAddress1.Text = string.Empty;
                TxtBranchAddress2.Text = string.Empty;
                TxtBranchAddress3.Text = string.Empty;
                TxtBranchPhoneNo.Text = string.Empty;
                TxtBranchFax.Text = string.Empty;
                TxtBranchEmailAddress.Text = string.Empty;
                TxtBranchAutoEmailAddress.Text = string.Empty;
                DdlCreditExpenseACName1.SelectedIndex = 0;
                DdlCreditExpenseACName2.SelectedIndex = 0;
                DdlCreditExpenseACName3.SelectedIndex = 0;
                DdlDebitExpenseACName1.SelectedIndex = 0;
                DdlDebitExpenseACName2.SelectedIndex = 0;
                DdlDebitExpenseACName3.SelectedIndex = 0;
                DdlBranchServiceCreditAC.SelectedIndex = 0;
                DdlBranchServiceDebitAC.SelectedIndex = 0;
                TxtBranchState.Text = string.Empty;
                TxtBranchStateNo.Text = string.Empty;
                DdlGSTAppllicableFlag.SelectedValue = "N";
                TxtCity.Text = string.Empty;
                TxtGstAppDate.Text = string.Empty;
                TxtBranchGSTNo.Text = string.Empty;
                DdlBranchReceivedDebitAC.SelectedIndex = 0;
                DdlBranchReceivedCreditAC.SelectedIndex = 0;

                BtncallUpd.Text = "SAVE";
               
                Btncalldel.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
              //  btnSave.Text = "SAVE";
                lblmsg.Text = string.Empty;
                UserRights();
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
                HfCompCode.Value = Session["COMP_CODE"].ToString();
                #region INSERT _ UPDATE VALUE
                BRANCH_MASLogicLayer insert = new BRANCH_MASLogicLayer();
                // insert.BRANCH_CODE = TxtBranchCode.Text.Trim().ToUpper(); ;
                insert.BRANCH_CODE = HfBRANCH_CODE.Value.Trim();
                insert.AUTO_MAILID = TxtBranchAutoEmailAddress.Text.Trim();
                insert.BRANCH_ADD1 = TxtBranchAddress1.Text.Trim().ToUpper();
                insert.BRANCH_ADD2 = TxtBranchAddress2.Text.Trim().ToUpper();
                insert.BRANCH_ADD3 = TxtBranchAddress3.Text.Trim().ToUpper();
                insert.BRANCH_EMAIL = TxtBranchEmailAddress.Text.Trim();
                insert.BRANCH_FAX = TxtBranchFax.Text.Trim().Trim().ToUpper();
                insert.BRANCH_NAME = TxtBranchName.Text.Trim().ToUpper(); ;
                insert.BRANCH_PHONE = TxtBranchPhoneNo.Text.Trim().ToUpper();
                insert.BRANCH_SHORT = TxtBranchShort.Text.Trim().ToUpper(); ;
                insert.BRANCH_TYPE = DdlBranchType.SelectedValue.Trim().ToUpper(); ;
                insert.BS_CRACODE = DdlBranchServiceCreditAC.SelectedValue.Trim().ToUpper();
                insert.BS_DRACODE = DdlBranchServiceDebitAC.SelectedValue.Trim().ToUpper();
                insert.COMP_CODE = HfCompCode.Value;
                insert.CRACODE1 = DdlCreditExpenseACName1.SelectedValue.Trim().ToUpper();
                insert.CRACODE2 = DdlCreditExpenseACName2.SelectedValue.Trim().ToUpper();
                insert.CRACODE3 = DdlCreditExpenseACName3.SelectedValue.Trim().ToUpper();
                insert.DRACODE1 = DdlDebitExpenseACName1.SelectedValue.Trim().ToUpper();
                insert.DRACODE2 = DdlDebitExpenseACName2.SelectedValue.Trim().ToUpper();
                insert.DRACODE3 = DdlDebitExpenseACName3.SelectedValue.Trim().ToUpper();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_DATE = string.Empty;
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_DATE = string.Empty;
                insert.BRANCH_STATE = TxtBranchState.Text.Trim().ToUpper();
                insert.BRANCH_STATE_NO = TxtBranchStateNo.Text.Trim();
                insert.GST_APP_FLAG = DdlGSTAppllicableFlag.SelectedValue.Trim().ToUpper();
                if (TxtGstAppDate.Text == string.Empty)
                {
                    insert.GST_APP_DATE = "";
                }
                else
                {
                    insert.GST_APP_DATE = Convert.ToDateTime(TxtGstAppDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }

                insert.BRANCH_GST_NO = TxtBranchGSTNo.Text.Trim().ToUpper();
                insert.BRANCH_PARTY_TYPE = "";
                insert.BRANCH_CITY = TxtCity.Text.Trim().ToUpper();
                insert.BR_DRACODE = DdlBranchReceivedDebitAC.Text.Trim().ToUpper();
                insert.BR_CRACODE = DdlBranchReceivedCreditAC.Text.Trim().ToUpper();

                #endregion



                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = BRANCH_MASLogicLayer.InsertBRANCH_MASDetials(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "BRANCH DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(HfCompCode.Value);
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "BRANCH CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : BRANCH DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    string str = BRANCH_MASLogicLayer.updateBRANCH_MASDetials(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "BRANCH DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(HfCompCode.Value);
                        UserRights();
                    }
                    else if (str.Contains("Already"))
                    {
                        lblmsg.Text = "BRANCH CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : BRANCH DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillGrid(string CompCode)
        {
            try
            {
                HfCompCode.Value = Session["COMP_CODE"].ToString();
                DataTable Dt = new DataTable();
                
                Dt = BRANCH_MASLogicLayer.GetAllBRANCH_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if(CompCode!=string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + HfCompCode.Value;
                }
                GvBranch.DataSource = Dv.ToTable();
                GvBranch.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvBranch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Deletea")
                {
                    #region EDIT
                    clear();
                    DataTable dt = BRANCH_MASLogicLayer.GetAllIDWiseBRANCH_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;
                        // TxtBranchCode.Text = dt.Rows[0]["BRANCH_CODE"].ToString();
                        HfBRANCH_CODE.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                        TxtBranchName.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                        TxtBranchShort.Text = dt.Rows[0]["BRANCH_SHORT"].ToString();
                        DdlBranchType.SelectedValue = dt.Rows[0]["BRANCH_TYPE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBRANCH_CODE.Value = e.CommandArgument.ToString();

                        TxtBranchAddress1.Text = dt.Rows[0]["BRANCH_ADD1"].ToString();
                        TxtBranchAddress2.Text = dt.Rows[0]["BRANCH_ADD2"].ToString();
                        TxtBranchAddress3.Text = dt.Rows[0]["BRANCH_ADD3"].ToString();
                        TxtBranchEmailAddress.Text = dt.Rows[0]["BRANCH_EMAIL"].ToString();
                        TxtBranchAutoEmailAddress.Text = dt.Rows[0]["AUTO_MAILID"].ToString();
                        TxtBranchPhoneNo.Text = dt.Rows[0]["BRANCH_PHONE"].ToString();
                        TxtBranchFax.Text = dt.Rows[0]["BRANCH_FAX"].ToString();
                        DdlCreditExpenseACName1.SelectedValue = dt.Rows[0]["CRACODE1"].ToString();
                        DdlCreditExpenseACName2.SelectedValue = dt.Rows[0]["CRACODE2"].ToString();
                        DdlCreditExpenseACName3.SelectedValue = dt.Rows[0]["CRACODE3"].ToString();
                        DdlDebitExpenseACName1.SelectedValue = dt.Rows[0]["DRACODE1"].ToString();
                        DdlDebitExpenseACName2.SelectedValue = dt.Rows[0]["DRACODE2"].ToString();
                        DdlDebitExpenseACName3.SelectedValue = dt.Rows[0]["DRACODE3"].ToString();
                        DdlBranchServiceCreditAC.SelectedValue = dt.Rows[0]["BS_CRACODE"].ToString();
                        DdlBranchServiceDebitAC.SelectedValue = dt.Rows[0]["BS_DRACODE"].ToString();
                        TxtCity.Text = dt.Rows[0]["BRANCH_CITY"].ToString();
                        TxtBranchState.Text = dt.Rows[0]["BRANCH_STATE"].ToString();
                        TxtBranchStateNo.Text = dt.Rows[0]["BRANCH_STATE_NO"].ToString();
                        DdlGSTAppllicableFlag.SelectedValue = dt.Rows[0]["GST_APP_FLAG"].ToString();
                        TxtGstAppDate.Text = dt.Rows[0]["GST_APP_DATE"].ToString();
                        TxtBranchGSTNo.Text = dt.Rows[0]["BRANCH_GST_NO"].ToString();
                        DdlBranchReceivedCreditAC.SelectedValue = dt.Rows[0]["BR_CRACODE"].ToString();
                        DdlBranchReceivedDebitAC.SelectedValue = dt.Rows[0]["BR_DRACODE"].ToString();
                        //      TxtCreatedBy.Text = dt.Rows[0]["INS_USERID"].ToString();
                        //     TxtCreatedDate.Text = dt.Rows[0]["INS_DATE"].ToString();
                        //     TxtUpdatedBy.Text = dt.Rows[0]["UPD_USERID"].ToString();
                        //     TxtUpdatedDate.Text = dt.Rows[0]["UPD_DATE"].ToString();
                    }
                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    Btncalldel.Visible = true;
                    BtncallUpd.Visible = false;
                    ControllersDisable();
                   
                    #endregion
                }


                if (e.CommandName == "Edita")
                {
                    #region EDIT
                    clear();
                    DataTable dt = BRANCH_MASLogicLayer.GetAllIDWiseBRANCH_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;
                        // TxtBranchCode.Text = dt.Rows[0]["BRANCH_CODE"].ToString();
                        HfBRANCH_CODE.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                        TxtBranchName.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                        TxtBranchShort.Text = dt.Rows[0]["BRANCH_SHORT"].ToString();
                        DdlBranchType.SelectedValue = dt.Rows[0]["BRANCH_TYPE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBRANCH_CODE.Value = e.CommandArgument.ToString();

                        TxtBranchAddress1.Text = dt.Rows[0]["BRANCH_ADD1"].ToString();
                        TxtBranchAddress2.Text = dt.Rows[0]["BRANCH_ADD2"].ToString();
                        TxtBranchAddress3.Text = dt.Rows[0]["BRANCH_ADD3"].ToString();
                        TxtBranchEmailAddress.Text = dt.Rows[0]["BRANCH_EMAIL"].ToString();
                        TxtBranchAutoEmailAddress.Text = dt.Rows[0]["AUTO_MAILID"].ToString();
                        TxtBranchPhoneNo.Text = dt.Rows[0]["BRANCH_PHONE"].ToString();
                        TxtBranchFax.Text = dt.Rows[0]["BRANCH_FAX"].ToString();
                        DdlCreditExpenseACName1.SelectedValue = dt.Rows[0]["CRACODE1"].ToString();
                        DdlCreditExpenseACName2.SelectedValue = dt.Rows[0]["CRACODE2"].ToString();
                        DdlCreditExpenseACName3.SelectedValue = dt.Rows[0]["CRACODE3"].ToString();
                        DdlDebitExpenseACName1.SelectedValue = dt.Rows[0]["DRACODE1"].ToString();
                        DdlDebitExpenseACName2.SelectedValue = dt.Rows[0]["DRACODE2"].ToString();
                        DdlDebitExpenseACName3.SelectedValue = dt.Rows[0]["DRACODE3"].ToString();
                        DdlBranchServiceCreditAC.SelectedValue = dt.Rows[0]["BS_CRACODE"].ToString();
                        DdlBranchServiceDebitAC.SelectedValue = dt.Rows[0]["BS_DRACODE"].ToString();
                        TxtCity.Text= dt.Rows[0]["BRANCH_CITY"].ToString();
                        TxtBranchState.Text= dt.Rows[0]["BRANCH_STATE"].ToString();
                        TxtBranchStateNo.Text= dt.Rows[0]["BRANCH_STATE_NO"].ToString();
                        DdlGSTAppllicableFlag.SelectedValue= dt.Rows[0]["GST_APP_FLAG"].ToString();
                        TxtGstAppDate.Text= dt.Rows[0]["GST_APP_DATE"].ToString();
                        TxtBranchGSTNo.Text= dt.Rows[0]["BRANCH_GST_NO"].ToString();
                        DdlBranchReceivedCreditAC.SelectedValue= dt.Rows[0]["BR_CRACODE"].ToString();
                        DdlBranchReceivedDebitAC.SelectedValue= dt.Rows[0]["BR_DRACODE"].ToString(); 

                    }
                         BtncallUpd.Text = "UPDATE";
                       //  btnSave.Text = "UPDATE";
                    #endregion

                    #region CHECK UPDATE RIGHTS
                    if (Session["UPDATE"] != null)
                    {
                        if (Session["UPDATE"].ToString() == "Y")
                        {
                            ControllersEnable();
                        }
                        else
                        {
                            ControllersDisable();
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

                    DataTable dt = BRANCH_MASLogicLayer.GetAllIDWiseBRANCH_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;
                        // TxtBranchCode.Text = dt.Rows[0]["BRANCH_CODE"].ToString();
                        HfBRANCH_CODE.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                        TxtBranchName.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                        TxtBranchShort.Text = dt.Rows[0]["BRANCH_SHORT"].ToString();
                        DdlBranchType.SelectedValue = dt.Rows[0]["BRANCH_TYPE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBRANCH_CODE.Value = e.CommandArgument.ToString();

                        TxtBranchAddress1.Text = dt.Rows[0]["BRANCH_ADD1"].ToString();
                        TxtBranchAddress2.Text = dt.Rows[0]["BRANCH_ADD2"].ToString();
                        TxtBranchAddress3.Text = dt.Rows[0]["BRANCH_ADD3"].ToString();
                        TxtBranchEmailAddress.Text = dt.Rows[0]["BRANCH_EMAIL"].ToString();
                        TxtBranchAutoEmailAddress.Text = dt.Rows[0]["AUTO_MAILID"].ToString();
                        TxtBranchPhoneNo.Text = dt.Rows[0]["BRANCH_PHONE"].ToString();
                        TxtBranchFax.Text = dt.Rows[0]["BRANCH_FAX"].ToString();
                        DdlCreditExpenseACName1.SelectedValue = dt.Rows[0]["CRACODE1"].ToString();
                        DdlCreditExpenseACName2.SelectedValue = dt.Rows[0]["CRACODE2"].ToString();
                        DdlCreditExpenseACName3.SelectedValue = dt.Rows[0]["CRACODE3"].ToString();
                        DdlDebitExpenseACName1.SelectedValue = dt.Rows[0]["DRACODE1"].ToString();
                        DdlDebitExpenseACName2.SelectedValue = dt.Rows[0]["DRACODE2"].ToString();
                        DdlDebitExpenseACName3.SelectedValue = dt.Rows[0]["DRACODE3"].ToString();
                        DdlBranchServiceCreditAC.SelectedValue = dt.Rows[0]["BS_CRACODE"].ToString();
                        DdlBranchServiceDebitAC.SelectedValue = dt.Rows[0]["BS_DRACODE"].ToString();
                        TxtCity.Text = dt.Rows[0]["BRANCH_CITY"].ToString();
                        TxtBranchState.Text = dt.Rows[0]["BRANCH_STATE"].ToString();
                        TxtBranchStateNo.Text = dt.Rows[0]["BRANCH_STATE_NO"].ToString();
                        DdlGSTAppllicableFlag.SelectedValue = dt.Rows[0]["GST_APP_FLAG"].ToString();
                        TxtGstAppDate.Text = dt.Rows[0]["GST_APP_DATE"].ToString();
                        TxtBranchGSTNo.Text = dt.Rows[0]["BRANCH_GST_NO"].ToString();
                        DdlBranchReceivedCreditAC.SelectedValue = dt.Rows[0]["BR_CRACODE"].ToString();
                        DdlBranchReceivedDebitAC.SelectedValue = dt.Rows[0]["BR_DRACODE"].ToString();
                        //  TxtCreatedBy.Text = dt.Rows[0]["INS_USERID"].ToString();
                        //  TxtCreatedDate.Text = dt.Rows[0]["INS_DATE"].ToString();
                        //  TxtUpdatedBy.Text = dt.Rows[0]["UPD_USERID"].ToString();
                        //  TxtUpdatedDate.Text = dt.Rows[0]["UPD_DATE"].ToString();
                        #endregion
                    }

                    ControllersDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    UserRights();
              //    btnDelete.Visible = true;
              //     btnSave.Text = "UPDATE";
                   

                }
            }

            catch (Exception ex)
            {
                lblmsg.Text = ex.Message.ToString();
            }
        }


        

        protected void GvBranch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvBranch.PageIndex = e.NewPageIndex;
                FillGrid(HfCompCode.Value);
                clear();
            }
            catch (Exception)
            {


            }
        }

        protected void BtnAdd_OnClick(object sender, EventArgs e)
        {
            try
            {
                clear();
                ControllersEnable();
                UserRights();
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



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE  - MIHIR LAD 04-10-2018
                if (HfBRANCH_CODE.Value != string.Empty)
                {
                    string str = BRANCH_MASLogicLayer.DeleteBRANCHDetailsByID(HfBRANCH_CODE.Value);
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
                    FillGrid(HfCompCode.Value);
                    UserRights();

                }
                #endregion
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

        protected void Btncalldel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
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
                    HfCompCode.Value= Session["COMP_CODE"].ToString();

                    BRANCH_MASLogicLayer insert = new BRANCH_MASLogicLayer();
                    // insert.BRANCH_CODE = TxtBranchCode.Text.Trim().ToUpper(); ;
                    insert.BRANCH_CODE = HfBRANCH_CODE.Value.Trim();
                    insert.AUTO_MAILID = TxtBranchAutoEmailAddress.Text.Trim();
                    insert.BRANCH_ADD1 = TxtBranchAddress1.Text.Trim().ToUpper();
                    insert.BRANCH_ADD2 = TxtBranchAddress2.Text.Trim().ToUpper();
                    insert.BRANCH_ADD3 = TxtBranchAddress3.Text.Trim().ToUpper();
                    insert.BRANCH_EMAIL = TxtBranchEmailAddress.Text.Trim();
                    insert.BRANCH_FAX = TxtBranchFax.Text.Trim().Trim().ToUpper();
                    insert.BRANCH_NAME = TxtBranchName.Text.Trim().ToUpper(); 
                    insert.BRANCH_PHONE = TxtBranchPhoneNo.Text.Trim().ToUpper();
                    insert.BRANCH_SHORT = TxtBranchShort.Text.Trim().ToUpper(); ;
                    insert.BRANCH_TYPE = DdlBranchType.SelectedValue.Trim().ToUpper(); 
                    insert.BS_CRACODE = DdlBranchServiceCreditAC.SelectedValue.Trim().ToUpper();
                    insert.BS_DRACODE = DdlBranchServiceDebitAC.SelectedValue.Trim().ToUpper();
                    insert.COMP_CODE = HfCompCode.Value;
                    insert.CRACODE1 = DdlCreditExpenseACName1.SelectedValue.Trim().ToUpper();
                    insert.CRACODE2 = DdlCreditExpenseACName2.SelectedValue.Trim().ToUpper();
                    insert.CRACODE3 = DdlCreditExpenseACName3.SelectedValue.Trim().ToUpper();
                    insert.DRACODE1 = DdlDebitExpenseACName1.SelectedValue.Trim().ToUpper();
                    insert.DRACODE2 = DdlDebitExpenseACName2.SelectedValue.Trim().ToUpper();
                    insert.DRACODE3 = DdlDebitExpenseACName3.SelectedValue.Trim().ToUpper();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL= Session["PC"].ToString();
                    insert.INS_DATE = string.Empty;
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_DATE = string.Empty;
                    insert.BRANCH_STATE = TxtBranchState.Text.Trim().ToUpper();
                    insert.BRANCH_STATE_NO = TxtBranchStateNo.Text.Trim();
                    insert.GST_APP_FLAG = DdlGSTAppllicableFlag.SelectedValue.Trim().ToUpper();
                    if(TxtGstAppDate.Text==string.Empty)
                    {
                        insert.GST_APP_DATE = "";
                    }
                    else
                    {
                        insert.GST_APP_DATE = Convert.ToDateTime(TxtGstAppDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }

                    insert.BRANCH_GST_NO = TxtBranchGSTNo.Text.Trim().ToUpper();
                    insert.BRANCH_PARTY_TYPE = "";
                    insert.BRANCH_CITY = TxtCity.Text.Trim().ToUpper();
                    insert.BR_DRACODE = DdlBranchReceivedDebitAC.Text.Trim().ToUpper();		
                    insert.BR_CRACODE= DdlBranchReceivedCreditAC.Text.Trim().ToUpper();
                  

                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = BRANCH_MASLogicLayer.InsertBRANCH_MASDetials(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "BRANCH DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid(HfCompCode.Value);
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "BRANCH CODE ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : BRANCH DETAIL NOT SAVED";
                            lblmsg.ForeColor = Color.Red;
                        }
                    }
                }
            }
            
            catch (Exception)
            {

                throw;
            }
           
        }

        protected void DdlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FillDdlCreditExpenseACName1();
            //FillDdlCreditExpenseACName2();
            //FillDdlCreditExpenseACName3();
            //FillDdlDebitExpenseACName1();
            //FillDdlDebitExpenseACName2();
            //FillDdlDebitExpenseACName3();
            //FillDdlBranchServiceCreditAC();
            //FillDdlBranchServiceDebitAC();
        }

        protected void TxtBranchState_TextChanged(object sender, EventArgs e)
        {
            try
            {
          
             

                DataTable DtSTATEName = STATE_MASLogicLayer.GetAllSTATE_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                if (TxtBranchState.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtSTATEName);
                    Dv.RowFilter = "STATE_NAME='" + TxtBranchState.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        TxtBranchStateNo.Text = DtView.Rows[0]["STATE_NO"].ToString();
                       
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlGSTAppllicableFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TxtGstAppDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}