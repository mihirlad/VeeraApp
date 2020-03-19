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
    public partial class BrokerMaster : System.Web.UI.Page
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
        //      FillDdlCompany();
                FillDdlBranch();
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
        public void ControllerEnable()
        {
           // HfBCode.Value = string.Empty;
            TxtPersonName.Enabled = true;
            TxtAddress1.Enabled = true;
            TxtPhoneM.Enabled = true;
            TxtPhoneO.Enabled = true;
         //   DdlCompany.Enabled = true;
            DdlBranch.Enabled = true;
            DdlActive.Enabled = true;
        }

        public void ControllerDisable()
        {

            // HfBCode.Value = string.Empty;
            TxtPersonName.Enabled = false;
            TxtAddress1.Enabled = false;
            TxtPhoneM.Enabled = false;
            TxtPhoneO.Enabled = false;
          //  DdlCompany.Enabled = false;
            DdlBranch.Enabled = false;
            DdlActive.Enabled = false;
        }
        public void clear()
        {

            DivEntry.Visible = false;
            DivView.Visible = true;

            HfBCode.Value = string.Empty;
            TxtPersonName.Text = string.Empty;
            TxtAddress1.Text = string.Empty;
            TxtPhoneO.Text = string.Empty;
            TxtPhoneM.Text = string.Empty;
      //      DdlCompany.SelectedIndex = 0;
            DdlBranch.SelectedIndex = 0;
            DdlActive.SelectedValue = "N";

            BtncallUpd.Text = "SAVE";
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

        public void FillDdlBranch()
        {
            try
            {
                DataTable Dt = new DataTable();
                HfCompCode.Value= Session["COMP_CODE"].ToString();
                string COMPANYCODE = HfCompCode.Value;

                Dt = BRANCH_MASLogicLayer.GetBranchDetailCompanyWiseFor_Ddl(COMPANYCODE);
                DdlBranch.DataSource = Dt;
                DdlBranch.DataValueField = "BRANCH_CODE";
                DdlBranch.DataTextField = "BRANCH_NAME";
                DdlBranch.DataBind();


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  FillDdlBranch();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region INSERT _ UPDATE VALUE

                HfCompCode.Value = Session["COMP_CODE"].ToString();
                BROKER_MASLogicLayer insert = new BROKER_MASLogicLayer();
                insert.COMP_CODE = HfCompCode.Value;
                insert.BRANCH_CODE = DdlBranch.SelectedValue.Trim().ToUpper();
                insert.BCODE = HfBCode.Value.Trim();
                insert.BNAME = TxtPersonName.Text.Trim().ToUpper();
                insert.BADD = TxtAddress1.Text.Trim().ToUpper();
                insert.BADD2 = "";
                insert.BADD3 = "";
                insert.PHONE_O = TxtPhoneO.Text.Trim().ToUpper();
                insert.PHONE_M = TxtPhoneM.Text.Trim().ToUpper();
                insert.ACODE = "0";
                insert.PER = "0";
                insert.ACTIVE = DdlActive.SelectedValue.Trim().ToUpper();
                insert.INS_USERID= Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID= Session["USERNAME"].ToString();
                insert.UPD_TERMINAL= Session["PC"].ToString();
                insert.UPD_DATE = "";

                #endregion

                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = BROKER_MASLogicLayer.InsertBROKERDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "PERSON DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(Session["COMP_CODE"].ToString());
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "PERSON CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : CONTACT DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    string str = BROKER_MASLogicLayer.UpdateBROKERDetails(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "PERSON DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(Session["COMP_CODE"].ToString());
                        UserRights();
                    }
                    else if (str.Contains("Already"))
                    {
                        lblmsg.Text = "PERSON CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : PERSON DETAIL NOT SAVED";
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
              //  HfCompCode.Value = Session["COMP_CODE"].ToString();
                DataTable Dt = new DataTable();

                Dt = BROKER_MASLogicLayer.GetAllBROKERDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvPersonMaster.DataSource = Dv.ToTable();
                GvPersonMaster.DataBind();
                DtSearch = Dv.ToTable();
            }
            catch (Exception)
            {

                throw;
            }
        }

            //public void FillGrid()
            //{
            //    try
            //    {
            //        DataTable Dt = new DataTable();

            //        Dt = BROKER_MASLogicLayer.GetAllBROKERDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
            //        GvPersonMaster.DataSource = Dt;
            //       GvPersonMaster.DataBind();

            //    catch (Exception)
            //    {

            //        throw;
            //    }
            //}

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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            lblmsg.Text = string.Empty;
            UserRights();
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
                    BROKER_MASLogicLayer insert = new BROKER_MASLogicLayer();
                    insert.COMP_CODE = HfCompCode.Value;
                    insert.BRANCH_CODE = DdlBranch.SelectedValue.Trim().ToUpper();
                    insert.BCODE = HfBCode.Value.Trim();
                    insert.BNAME = TxtPersonName.Text.Trim().ToUpper();
                    insert.BADD = TxtAddress1.Text.Trim().ToUpper();
                    insert.BADD2 = "";
                    insert.BADD3 = "";
                    insert.PHONE_O = TxtPhoneO.Text.Trim().ToUpper();
                    insert.PHONE_M = TxtPhoneM.Text.Trim().ToUpper();
                    insert.ACODE = "0";
                    insert.PER = "0";
                    insert.ACTIVE = DdlActive.SelectedValue.Trim().ToUpper();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";


                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = BROKER_MASLogicLayer.InsertBROKERDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "PERSON DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid(Session["COMP_CODE"].ToString());
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "PERSON CODE ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : PERSON DETAIL NOT SAVED";
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

        protected void Btncalldel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
        }

        protected void GvPersonMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvPersonMaster.PageIndex = e.NewPageIndex;
                FillGrid(Session["COMP_CODE"].ToString());
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvPersonMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataTable dt = BROKER_MASLogicLayer.GetAllIDWiseBROKERDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfBCode.Value = dt.Rows[0]["BCODE"].ToString();
                        TxtPersonName.Text = dt.Rows[0]["BNAME"].ToString();
                        TxtAddress1.Text = dt.Rows[0]["BADD"].ToString();
                        TxtPhoneO.Text = dt.Rows[0]["PHONE_O"].ToString();
                        TxtPhoneM.Text = dt.Rows[0]["PHONE_M"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        FillDdlBranch();
                        DdlBranch.SelectedValue = dt.Rows[0]["BRANCH_CODE"].ToString();
                        DdlActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
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
                    DataTable dt = BROKER_MASLogicLayer.GetAllIDWiseBROKERDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfBCode.Value = dt.Rows[0]["BCODE"].ToString();
                        TxtPersonName.Text = dt.Rows[0]["BNAME"].ToString();
                        TxtAddress1.Text = dt.Rows[0]["BADD"].ToString();
                        TxtPhoneO.Text = dt.Rows[0]["PHONE_O"].ToString();
                        TxtPhoneM.Text = dt.Rows[0]["PHONE_M"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        FillDdlBranch();
                        DdlBranch.SelectedValue = dt.Rows[0]["BRANCH_CODE"].ToString();
                        DdlActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();

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
                    DataTable dt = BROKER_MASLogicLayer.GetAllIDWiseBROKERDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfBCode.Value = dt.Rows[0]["BCODE"].ToString();
                        TxtPersonName.Text = dt.Rows[0]["BNAME"].ToString();
                        TxtAddress1.Text = dt.Rows[0]["BADD"].ToString();
                        TxtPhoneO.Text = dt.Rows[0]["PHONE_O"].ToString();
                        TxtPhoneM.Text = dt.Rows[0]["PHONE_M"].ToString();
                         HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        FillDdlBranch();
                        DdlBranch.SelectedValue = dt.Rows[0]["BRANCH_CODE"].ToString();
                        DdlActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();

                        #endregion
                    }
                       ControllerDisable();
                       btnSave.Visible = false;
                       Btncalldel.Visible = false;
                       BtncallUpd.Visible = false;
                       UserRights();
                }

            }

            catch (Exception ex)
            {

                lblmsg.Text = ex.Message.ToString();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                #region  DELETE  
                if (HfBCode.Value != string.Empty)
                {
                    string str = BROKER_MASLogicLayer.DeleteBROKERDetailsByID(HfBCode.Value);
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
                        lblmsg.Text = "Error:Person Master Not Deleted";
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
                    Dv.RowFilter = "BNAME like '%" + TxtSearch.Text.Trim() + "%' OR PHONE_O like '%" + TxtSearch.Text.Trim() + "%' OR PHONE_M like '%" + TxtSearch.Text.Trim() + "%' OR CompanyName like '%" + TxtSearch.Text.Trim() + "%'";
                    GvPersonMaster.DataSource = Dv.ToTable();
                    GvPersonMaster.DataBind();
                }
                else
                {
                    GvPersonMaster.DataSource = DtSearch;
                    GvPersonMaster.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}