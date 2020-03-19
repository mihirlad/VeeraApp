using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;


namespace VeeraApp
{
    public partial class PartyContactDetails : System.Web.UI.Page
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
                    FillDdlCompanyName();



                    if (!string.IsNullOrWhiteSpace(Request.QueryString["ACODE"]) && !string.IsNullOrWhiteSpace(Request.QueryString["COMP_CODE"]))
                    {
                        HfCompCode.Value = HttpUtility.UrlDecode(Decrypt(Request.QueryString["COMP_CODE"]));
                        HfACODE.Value = HttpUtility.UrlDecode(Decrypt(Request.QueryString["ACODE"]));


                        lblAccountNameOfParty_relate.Visible = true;
                        tblaccname.Visible = false;
                        //  tblcompname.Visible = false;
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        clear();
                        ControllerEnable();
                        UserRights();
                        Btncalldel.Visible = false;
                        btnSave.Enabled = true;
                        btnSave.Visible = true;
                        DivEntry.Visible = false;
                        DivView.Visible = true;

                        if (!string.IsNullOrWhiteSpace(Request.QueryString["Flag"]))
                        {
                            if (Request.QueryString["Flag"].ToString() == "1")
                            {



                                btnSave.Visible = false;
                                ControllerDisable();
                            }
                        }

                        DataTable Dt = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(HfACODE.Value);
                        if (Dt.Rows.Count > 0)
                        {
                            lblAccountNameOfParty.Text = Dt.Rows[0]["ANAME"].ToString();
                        }
                        FillDdlAccountName();
                    }
                    else
                    {
                        HfCompCode.Value = Session["COMP_CODE"].ToString();
                        HfACODE.Value = string.Empty;
                        //  DdlComapnyName.Visible = true;
                        DdlAccountName.Visible = true;
                        FillDdlAccountName();
                        lblAccountNameOfParty_relate.Visible = false;
                    }
                    FillGrid(HfACODE.Value);
                }
            }

            else
            {
                Response.Redirect("../Login.aspx");
            }
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

        public void FillDdlCompanyName()
        {
            try
            {
                //DataTable Dt = COMPANYLogicLayer.GetAllCOMPANYDetials_DDL();
                //DdlComapnyName.DataSource = Dt;
                //DdlComapnyName.DataValueField = "COMP_CODE";
                //DdlComapnyName.DataTextField = "NAME";
                //DdlComapnyName.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlAccountName()
        {
            try
            {
                string COMPCODE = HfCompCode.Value;
                DataTable Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(COMPCODE);
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
            // HfSR_NO.Value = string.Empty;
            // DdlComapnyName.Enabled = true;
            DdlAccountName.Enabled = true;
            TxtContactName.Enabled = true;
            TxtDesignation.Enabled = true;
            TxtMobileNo.Enabled = true;
            TxtEmailAddress.Enabled = true;
            TxtDob.Enabled = true;
            Chk_Accounts.Enabled = true;
            Chk_General.Enabled = true;
            Chk_Owner.Enabled = true;
            Chk_Purchase.Enabled = true;
            Chk_Service.Enabled = true;
            Chk_SMS.Enabled = true;
            DdlActive.Enabled = true;
            TxtRemarks.Enabled = true;

        }

        public void ControllerDisable()
        {

            // HfSR_NO.Value = string.Empty;
            //  DdlComapnyName.Enabled = false;
            DdlAccountName.Enabled = false;
            TxtContactName.Enabled = false;
            TxtDesignation.Enabled = false;
            TxtMobileNo.Enabled = false;
            TxtEmailAddress.Enabled = false;
            TxtDob.Enabled = false;
            Chk_Accounts.Enabled = false;
            Chk_General.Enabled = false;
            Chk_Owner.Enabled = false;
            Chk_Purchase.Enabled = false;
            Chk_Service.Enabled = false;
            Chk_SMS.Enabled = false;
            DdlActive.Enabled = false;
            TxtRemarks.Enabled = false;
        }

        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfSR_NO.Value = string.Empty;
            //   DdlComapnyName.SelectedIndex = 0;
            DdlAccountName.SelectedIndex = 0;
            TxtContactName.Text = string.Empty;
            TxtDesignation.Text = string.Empty;
            TxtMobileNo.Text = string.Empty;
            TxtEmailAddress.Text = string.Empty;
            TxtDob.Text = string.Empty;
            Chk_Accounts.Checked = false;
            Chk_General.Checked = false;
            Chk_Owner.Checked = false;
            Chk_Purchase.Checked = false;
            Chk_Service.Checked = false;
            Chk_SMS.Checked = false;
            DdlActive.SelectedValue = "N";
            TxtRemarks.Text = string.Empty;


            BtncallUpd.Text = "SAVE";

        }

        //public void FillDdlAccountPartyName()
        //{
        //    try
        //    {
        //        DataTable Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsFor_DDL();
        //        DdlAccountPartyName.DataSource = Dt;
        //        DdlAccountPartyName.DataValueField = "ACODE";
        //        DdlAccountPartyName.DataTextField = "ANAME";
        //        DdlAccountPartyName.DataBind();

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


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


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (HfCompCode.Value == string.Empty)
                {


                    //if (DdlComapnyName.SelectedIndex != 0)
                    //{
                    HfCompCode.Value = Session["COMP_CODE"].ToString();
                    //}

                }
                if (HfACODE.Value == string.Empty)
                {
                    if (DdlAccountName.SelectedIndex != 0)
                    {
                        HfACODE.Value = DdlAccountName.SelectedValue;
                    }
                }
                #region INSERT _ UPDATE VALUE

                if (HfCompCode.Value != string.Empty && HfACODE.Value != string.Empty)
                {
                    ACCOUNTS_DETLogicLayer insert = new ACCOUNTS_DETLogicLayer();
                    insert.COMP_CODE = HfCompCode.Value.Trim();
                    insert.ACODE = HfACODE.Value.Trim();
                    insert.SRNO = HfSR_NO.Value.Trim();
                    insert.CONTACT_NAME = TxtContactName.Text.Trim().ToUpper();
                    insert.DESIGN_NAME = TxtDesignation.Text.Trim().ToUpper();
                    insert.PHONE_NO = TxtMobileNo.Text.Trim().ToUpper();
                    insert.MAIL_ID = TxtEmailAddress.Text.Trim();
                    insert.ACTIVE = DdlActive.SelectedValue.Trim().ToUpper();

                    //insert.DOB = Convert.ToDateTime(TxtDob.Text.Trim()).ToString("MM-dd-yyyy");
                    if (TxtDob.Text == string.Empty)
                    {
                        insert.DOB = "";
                    }
                    else
                    {
                        insert.DOB = Convert.ToDateTime(TxtDob.Text.Trim()).ToString("MM-dd-yyyy");
                    }

                    if (Chk_Accounts.Checked == true)
                    {
                        insert.ACC_FLAG = "Y";

                    }
                    else
                    {
                        insert.ACC_FLAG = "N";
                    }

                    if (Chk_Purchase.Checked == true)
                    {
                        insert.PUR_FLAG = "Y";

                    }
                    else
                    {
                        insert.PUR_FLAG = "N";
                    }
                    if (Chk_Service.Checked == true)
                    {
                        insert.SERVICE_FLAG = "Y";
                    }
                    else
                    {
                        insert.SERVICE_FLAG = "N";
                    }

                    if (Chk_Owner.Checked == true)
                    {
                        insert.OWNER_FLAG = "Y";

                    }
                    else
                    {
                        insert.OWNER_FLAG = "N";
                    }

                    if (Chk_General.Checked == true)
                    {
                        insert.GEN_FLAG = "Y";

                    }
                    else
                    {
                        insert.GEN_FLAG = "N";
                    }

                    if (Chk_SMS.Checked == true)
                    {
                        insert.SMS_FLAG = "Y";

                    }
                    else
                    {
                        insert.SMS_FLAG = "N";
                    }

                    insert.REMARK = TxtRemarks.Text.Trim().ToUpper();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";

                    #endregion


                    if (btnSave.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = ACCOUNTS_DETLogicLayer.InsertACCOUNTS_DETDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "CONTACT DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid(HfACODE.Value);
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "CONTACT CODE ALREADY EXIST.";
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
                        string str = ACCOUNTS_DETLogicLayer.UpdateACCOUNTS_DETDetails(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "CONTACT DETAIL UPDATE SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid(HfACODE.Value);
                            UserRights();
                        }
                        else if (str.Contains("Already"))
                        {
                            lblmsg.Text = "CONTACT CODE ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : CONTACT DETAIL NOT SAVED";
                            lblmsg.ForeColor = Color.Red;
                        }
                    }
                }
                else
                {
                    lblmsg.Text = "ERROR : SELECT COMPANY AND ACCOUNT";
                    lblmsg.ForeColor = Color.Red;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void FillGrid(string Acode)
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = ACCOUNTS_DETLogicLayer.GetAllACCOUNTS_DETDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (Acode != string.Empty)
                {

                    Dv.RowFilter = "ACODE=" + HfACODE.Value;

                }
                DtSearch = Dv.ToTable();
                GvAccContact.DataSource = Dv.ToTable();
                GvAccContact.DataBind();
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

                    #region SAVE

                    if (HfACODE.Value == string.Empty)
                    {
                        if (DdlAccountName.SelectedIndex != 0)
                        {
                            HfACODE.Value = DdlAccountName.SelectedValue;
                        }

                        //if (DdlComapnyName.SelectedIndex != 0)
                        //{
                        //    HfCompCode.Value = DdlComapnyName.SelectedValue;
                        //}
                    }
                    if (HfCompCode.Value == string.Empty)
                    {
                        HfCompCode.Value = Session["COMP_CODE"].ToString();

                    }

                    //   HfCompCode.Value = DdlComapnyName.SelectedValue;
                    //   HfACODE.Value = DdlAccountName.SelectedValue;     
                    if (HfCompCode.Value != string.Empty && HfACODE.Value != string.Empty)
                    {

                        ACCOUNTS_DETLogicLayer insert = new ACCOUNTS_DETLogicLayer();
                        insert.COMP_CODE = HfCompCode.Value.Trim();
                        insert.ACODE = HfACODE.Value.Trim();
                        insert.SRNO = HfSR_NO.Value.Trim();
                        insert.CONTACT_NAME = TxtContactName.Text.Trim().ToUpper();
                        insert.DESIGN_NAME = TxtDesignation.Text.Trim().ToUpper();
                        insert.PHONE_NO = TxtMobileNo.Text.Trim().ToUpper();
                        insert.MAIL_ID = TxtEmailAddress.Text.Trim();
                        insert.ACTIVE = DdlActive.SelectedValue.Trim().ToUpper();
                        if (TxtDob.Text == string.Empty)
                        {
                            insert.DOB = "";
                        }
                        else
                        {
                            insert.DOB = Convert.ToDateTime(TxtDob.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                        }


                        if (Chk_Accounts.Checked == true)
                        {
                            insert.ACC_FLAG = "Y";

                        }
                        else
                        {
                            insert.ACC_FLAG = "N";
                        }

                        if (Chk_Purchase.Checked == true)
                        {
                            insert.PUR_FLAG = "Y";

                        }
                        else
                        {
                            insert.PUR_FLAG = "N";
                        }
                        if (Chk_Service.Checked == true)
                        {
                            insert.SERVICE_FLAG = "Y";
                        }
                        else
                        {
                            insert.SERVICE_FLAG = "N";
                        }

                        if (Chk_Owner.Checked == true)
                        {
                            insert.OWNER_FLAG = "Y";

                        }
                        else
                        {
                            insert.OWNER_FLAG = "N";
                        }

                        if (Chk_General.Checked == true)
                        {
                            insert.GEN_FLAG = "Y";

                        }
                        else
                        {
                            insert.GEN_FLAG = "N";
                        }

                        if (Chk_SMS.Checked == true)
                        {
                            insert.SMS_FLAG = "Y";

                        }
                        else
                        {
                            insert.SMS_FLAG = "N";
                        }

                        insert.REMARK = TxtRemarks.Text.Trim().ToUpper();
                        insert.INS_USERID = Session["USERNAME"].ToString();
                        insert.INS_TERMINAL = Session["PC"].ToString();
                        insert.INS_DATE = "";
                        insert.UPD_USERID = Session["USERNAME"].ToString();
                        insert.UPD_TERMINAL = Session["PC"].ToString();
                        insert.UPD_DATE = "";


                        if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                        {
                            string str = ACCOUNTS_DETLogicLayer.InsertACCOUNTS_DETDetail(insert);
                            if (str.Contains("successfully"))
                            {
                                lblmsg.Text = "CONTACT DETAIL ADD SUCCESSFULLY.";
                                lblmsg.ForeColor = Color.Green;
                                clear();
                                FillGrid(HfACODE.Value);
                                UserRights();
                            }
                            else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                            {
                                lblmsg.Text = "CONTACT CODE ALREADY EXIST.";
                                lblmsg.ForeColor = Color.Red;
                            }
                            else
                            {
                                lblmsg.Text = "ERROR : CONTACT DETAIL NOT SAVED";
                                lblmsg.ForeColor = Color.Red;
                            }
                        }
                        #endregion

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

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }

        protected void GvAccContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvAccContact.PageIndex = e.NewPageIndex;
                FillGrid(HfACODE.Value);
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvAccContact_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataTable dt = ACCOUNTS_DETLogicLayer.GetAllIDWiseACCOUNTS_DETDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        if (HfCompCode.Value == string.Empty && HfACODE.Value == string.Empty)
                        {
                            if (DdlAccountName.SelectedIndex != 0)
                            {
                                HfACODE.Value = DdlAccountName.SelectedValue;
                            }

                            //if (DdlComapnyName.SelectedIndex != 0)
                            //{
                            //    HfCompCode.Value = DdlComapnyName.SelectedValue;
                            //}
                            //HfCompCode.Value = Session["COMP_CODE"].ToString();

                        }
                        FillDdlCompanyName();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        FillDdlAccountName();
                        DdlAccountName.SelectedValue = dt.Rows[0]["ACODE"].ToString();
                        HfSR_NO.Value = dt.Rows[0]["SRNO"].ToString();
                        TxtContactName.Text = dt.Rows[0]["CONTACT_NAME"].ToString();
                        TxtDesignation.Text = dt.Rows[0]["DESIGN_NAME"].ToString();
                        TxtMobileNo.Text = dt.Rows[0]["PHONE_NO"].ToString();
                        TxtEmailAddress.Text = dt.Rows[0]["MAIL_ID"].ToString();
                        TxtDob.Text = Convert.ToDateTime(dt.Rows[0]["DOB"].ToString()).ToString("MM-dd-yyyy");



                        if (dt.Rows[0]["ACC_FLAG"].ToString() == "Y")
                        {
                            Chk_Accounts.Checked = true;

                        }
                        else
                        {
                            Chk_Accounts.Checked = false;
                        }

                        if (dt.Rows[0]["GEN_FLAG"].ToString() == "Y")
                        {
                            Chk_General.Checked = true;

                        }
                        else
                        {
                            Chk_General.Checked = false;
                        }

                        if (dt.Rows[0]["OWNER_FLAG"].ToString() == "Y")
                        {
                            Chk_Owner.Checked = true;

                        }
                        else
                        {
                            Chk_Owner.Checked = false;
                        }

                        if (dt.Rows[0]["PUR_FLAG"].ToString() == "Y")
                        {
                            Chk_Purchase.Checked = true;

                        }
                        else
                        {
                            Chk_Purchase.Checked = false;
                        }

                        if (dt.Rows[0]["SERVICE_FLAG"].ToString() == "Y")
                        {
                            Chk_Service.Checked = true;

                        }
                        else
                        {
                            Chk_Service.Checked = false;
                        }


                        if (dt.Rows[0]["SMS_FLAG"].ToString() == "Y")
                        {
                            Chk_SMS.Checked = true;

                        }
                        else
                        {
                            Chk_SMS.Checked = false;
                        }


                        DdlActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                        TxtRemarks.Text = dt.Rows[0]["REMARK"].ToString();

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
                    DataTable dt = ACCOUNTS_DETLogicLayer.GetAllIDWiseACCOUNTS_DETDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;




                        if (HfCompCode.Value == string.Empty && HfACODE.Value == string.Empty)
                        {
                            if (DdlAccountName.SelectedIndex != 0)
                            {
                                HfACODE.Value = DdlAccountName.SelectedValue;
                            }

                            //if (DdlComapnyName.SelectedIndex != 0)
                            //{
                            //    HfCompCode.Value = DdlComapnyName.SelectedValue;
                            //}

                        }
                        FillDdlCompanyName();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        FillDdlAccountName();
                        DdlAccountName.SelectedValue = dt.Rows[0]["ACODE"].ToString();

                        HfSR_NO.Value = dt.Rows[0]["SRNO"].ToString();
                        TxtContactName.Text = dt.Rows[0]["CONTACT_NAME"].ToString();
                        TxtDesignation.Text = dt.Rows[0]["DESIGN_NAME"].ToString();
                        TxtMobileNo.Text = dt.Rows[0]["PHONE_NO"].ToString();
                        TxtEmailAddress.Text = dt.Rows[0]["MAIL_ID"].ToString();
                        TxtDob.Text = Convert.ToDateTime(dt.Rows[0]["DOB"].ToString()).ToString("MM-dd-yyyy");

                        if (dt.Rows[0]["ACC_FLAG"].ToString() == "Y")
                        {
                            Chk_Accounts.Checked = true;

                        }
                        else
                        {
                            Chk_Accounts.Checked = false;
                        }

                        if (dt.Rows[0]["GEN_FLAG"].ToString() == "Y")
                        {
                            Chk_General.Checked = true;

                        }
                        else
                        {
                            Chk_General.Checked = false;
                        }

                        if (dt.Rows[0]["OWNER_FLAG"].ToString() == "Y")
                        {
                            Chk_Owner.Checked = true;

                        }
                        else
                        {
                            Chk_Owner.Checked = false;
                        }

                        if (dt.Rows[0]["PUR_FLAG"].ToString() == "Y")
                        {
                            Chk_Purchase.Checked = true;

                        }
                        else
                        {
                            Chk_Purchase.Checked = false;
                        }

                        if (dt.Rows[0]["SERVICE_FLAG"].ToString() == "Y")
                        {
                            Chk_Service.Checked = true;

                        }
                        else
                        {
                            Chk_Service.Checked = false;
                        }


                        if (dt.Rows[0]["SMS_FLAG"].ToString() == "Y")
                        {
                            Chk_SMS.Checked = true;

                        }
                        else
                        {
                            Chk_SMS.Checked = false;
                        }


                        DdlActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                        TxtRemarks.Text = dt.Rows[0]["REMARK"].ToString();

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
                    DdlAccountName.Enabled = false;
                    UserRights();
                }



                if (e.CommandName == "Viewa")
                {
                    #region SET TEXT ON VIEW

                    clear();
                    DataTable dt = ACCOUNTS_DETLogicLayer.GetAllIDWiseACCOUNTS_DETDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        if (HfCompCode.Value == string.Empty && HfACODE.Value == string.Empty)
                        {
                            if (DdlAccountName.SelectedIndex != 0)
                            {
                                HfACODE.Value = DdlAccountName.SelectedValue;
                            }

                            //if (DdlComapnyName.SelectedIndex != 0)
                            //{
                            //    HfCompCode.Value = DdlComapnyName.SelectedValue;
                            //}

                        }
                        FillDdlCompanyName();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        FillDdlAccountName();
                        DdlAccountName.SelectedValue = dt.Rows[0]["ACODE"].ToString();
                        HfSR_NO.Value = dt.Rows[0]["SRNO"].ToString();
                        TxtContactName.Text = dt.Rows[0]["CONTACT_NAME"].ToString();
                        TxtDesignation.Text = dt.Rows[0]["DESIGN_NAME"].ToString();
                        TxtMobileNo.Text = dt.Rows[0]["PHONE_NO"].ToString();
                        TxtEmailAddress.Text = dt.Rows[0]["MAIL_ID"].ToString();
                        TxtDob.Text = Convert.ToDateTime(dt.Rows[0]["DOB"].ToString()).ToString("MM-dd-yyyy");

                        if (dt.Rows[0]["ACC_FLAG"].ToString() == "Y")
                        {
                            Chk_Accounts.Checked = true;

                        }
                        else
                        {
                            Chk_Accounts.Checked = false;
                        }

                        if (dt.Rows[0]["GEN_FLAG"].ToString() == "Y")
                        {
                            Chk_General.Checked = true;

                        }
                        else
                        {
                            Chk_General.Checked = false;
                        }

                        if (dt.Rows[0]["OWNER_FLAG"].ToString() == "Y")
                        {
                            Chk_Owner.Checked = true;

                        }
                        else
                        {
                            Chk_Owner.Checked = false;
                        }

                        if (dt.Rows[0]["PUR_FLAG"].ToString() == "Y")
                        {
                            Chk_Purchase.Checked = true;

                        }
                        else
                        {
                            Chk_Purchase.Checked = false;
                        }

                        if (dt.Rows[0]["SERVICE_FLAG"].ToString() == "Y")
                        {
                            Chk_Service.Checked = true;

                        }
                        else
                        {
                            Chk_Service.Checked = false;
                        }


                        if (dt.Rows[0]["SMS_FLAG"].ToString() == "Y")
                        {
                            Chk_SMS.Checked = true;

                        }
                        else
                        {
                            Chk_SMS.Checked = false;
                        }


                        DdlActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                        TxtRemarks.Text = dt.Rows[0]["REMARK"].ToString();

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
                if (HfSR_NO.Value != string.Empty)
                {
                    string str = ACCOUNTS_DETLogicLayer.DeleteACCOUNTS_DETDetailsByID(HfSR_NO.Value);
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
                    FillGrid(HfACODE.Value);
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
                if (TxtSearch.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtSearch);
                    Dv.RowFilter = "CONTACT_NAME like '%" + TxtSearch.Text.Trim() + "%' OR MAIL_ID like '%" + TxtSearch.Text.Trim() + "%' OR AccountName like '%" + TxtSearch.Text.Trim() + "%'";
                    GvAccContact.DataSource = Dv.ToTable();
                    GvAccContact.DataBind();
                }
                else
                {
                    GvAccContact.DataSource = DtSearch;
                    GvAccContact.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        //protected void DdlComapnyName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FillDdlAccountName();
        //}
    }
}