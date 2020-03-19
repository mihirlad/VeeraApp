using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;
using System.Drawing;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace VeeraApp.Admin
{
    public partial class AccountMaster : System.Web.UI.Page
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
                    FillDdlAccountGroupName();
                    FillDdlBranch();
                    FillDdlPlace();
                    FillDdlState();
                    FillDdlMarketingPerson();
                    FillDdlAccountPerson();
                    FillDdlServicePerson();
                    FillGrid();
                    FillDdlToCompanyExport();


                    string ACODE = Request.QueryString["ACODE"];
                    string COMP_CODE = Request.QueryString["COMP_CODE"];


                    TxtVatCstDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                    TxtVatTinDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                }

                if (ViewState["txtsearchData"] != null)
                {

                     TextBox TxtSrcAname = GvAccount.HeaderRow.FindControl("TxtSrcAname") as TextBox;                 
                    TxtSrcAname.Text = ViewState["txtsearchData"].ToString();
                }


            }
            else
            {
                Response.Redirect("~/../Login.aspx");
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

        public void FillDdlAccountGroupName()
        {
            try
            {
                DataTable Dt = GROUP_MASLogicLayer.GetAllGROUP_MASDetials_DDL();
                DdlAccountGroupName.DataSource = Dt;
                DdlAccountGroupName.DataValueField = "GROUP_CODE";
                DdlAccountGroupName.DataTextField = "GROUP_NAME";
                DdlAccountGroupName.DataBind();

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
                //string COMPANYCODE = DdlCompany.SelectedValue;

                Dt = BRANCH_MASLogicLayer.GetBranchDetailCompanyWiseFor_Ddl(Session["COMP_CODE"].ToString());
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

        public void FillDdlBranchEdit(string CompCode)
        {
            try
            {
                DataTable Dt = new DataTable();
                // string COMPANYCODE = DdlCompany.SelectedValue;

                Dt = BRANCH_MASLogicLayer.GetBranchDetailCompanyWiseFor_Ddl(CompCode);
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

        public void FillDdlPlace()
        {
            try
            {
                DataTable Dt = PLACE_MASLogicLayer.GetAllPLACE_MASDetialsFor_DDL();
                DdlPlaceName.DataSource = Dt;
                DdlPlaceName.DataValueField = "PLACE_CODE";
                DdlPlaceName.DataTextField = "PLACE_NAME";
                DdlPlaceName.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlState()
        {
            try
            {
                DataTable Dt = STATE_MASLogicLayer.GetAllSTATE_MASDetialsFor_DDL();
                DdlStateName.DataSource = Dt;
                DdlStateName.DataValueField = "STATE_CODE";
                DdlStateName.DataTextField = "STATE_NAME";
                DdlStateName.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlMarketingPerson()
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = BROKER_MASLogicLayer.GetAllBROKER_MASDetialsCompanyWiseFor_DDL(Comp_Code);
                DdlMrkgPersonName.DataSource = Dt;
                DdlMrkgPersonName.DataValueField = "BCODE";
                DdlMrkgPersonName.DataTextField = "BNAME";
                DdlMrkgPersonName.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlAccountPerson()
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = BROKER_MASLogicLayer.GetAllBROKER_MASDetialsCompanyWiseFor_DDL(Comp_Code);
                DdlPaymentPersonName.DataSource = Dt;
                DdlPaymentPersonName.DataValueField = "BCODE";
                DdlPaymentPersonName.DataTextField = "BNAME";
                DdlPaymentPersonName.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlServicePerson()
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = BROKER_MASLogicLayer.GetAllBROKER_MASDetialsCompanyWiseFor_DDL(Comp_Code);
                DdlServicePersonName.DataSource = Dt;
                DdlServicePersonName.DataValueField = "BCODE";
                DdlServicePersonName.DataTextField = "BNAME";
                DdlServicePersonName.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlBrokerNameOnUpdate()
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = BROKER_MASLogicLayer.GetAllBROKER_MASDetialsCompanyWiseFor_DDL(Comp_Code);

                DdlMrkgPersonName.DataSource = Dt;
                DdlMrkgPersonName.DataValueField = "BCODE";
                DdlMrkgPersonName.DataTextField = "BNAME";
                DdlMrkgPersonName.DataBind();

                DdlPaymentPersonName.DataSource = Dt;
                DdlPaymentPersonName.DataValueField = "BCODE";
                DdlPaymentPersonName.DataTextField = "BNAME";
                DdlPaymentPersonName.DataBind();

                DdlServicePersonName.DataSource = Dt;
                DdlServicePersonName.DataValueField = "BCODE";
                DdlServicePersonName.DataTextField = "BNAME";
                DdlServicePersonName.DataBind();

               

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlToCompanyExport()
        {
            try
            {
                DataTable Dt = COMPANYLogicLayer.GetAllCOMPANYDetials_DDL();
                DdlToCompanyExport.DataSource = Dt;
                DdlToCompanyExport.DataValueField = "COMP_CODE";
                DdlToCompanyExport.DataTextField = "NAME";
                DdlToCompanyExport.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlToBranchExport()
        {
            try
            {
                DataTable Dt = new DataTable();
                string COMPANYCODE = DdlToCompanyExport.SelectedValue;

                Dt = BRANCH_MASLogicLayer.GetBranchDetailCompanyWiseFor_Ddl(COMPANYCODE);
                DdlToBranchExport.DataSource = Dt;
                DdlToBranchExport.DataValueField = "BRANCH_CODE";
                DdlToBranchExport.DataTextField = "BRANCH_NAME";
                DdlToBranchExport.DataBind();


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ControlllerEnable()
        {
            TxtAccountName.Enabled = true;
            TxtAccountShort.Enabled = true;
            DdlAccountGroupName.Enabled = true;
            TxtProLossPer.Enabled = true;
            //  DdlCompany.Enabled = true;
            DdlBranch.Enabled = true;
            DdlPlaceName.Enabled = true;
            TxtRouteName.Enabled = false;
            TxtGpsLocation.Enabled = true;
            DdlMrkgPersonName.Enabled = true;
            DdlPaymentPersonName.Enabled = true;
            DdlServicePersonName.Enabled = true;
            TxtContactPersonName.Enabled = true;
            TxtVendorCode.Enabled = true;
            TxtAddress1.Enabled = true;
            TxtAddress2.Enabled = true;
            TxtAddress3.Enabled = true;
            TxtCity.Enabled = true;
            DdlStateName.Enabled = true;
            TxtStateCode.Enabled = false;
            TxtCountry.Enabled = true;
            DdlPartyType.Enabled = true;
            DdlSalesType.Enabled = true;
            DdlRegisterCstType.Enabled = true;
            DdlBusinessType.Enabled = true;
            TxtCreditAmount.Enabled = true;
            TxtCreditDays.Enabled = true;
            TxtPhoneO.Enabled = true;
            TxtPhoneM.Enabled = true;
            TxtFax.Enabled = true;
            TxtEmail.Enabled = true;
            TxtGstNo.Enabled = true;
            TxtVatCstNo.Enabled = true;
            TxtVatCstDate.Enabled = true;
            TxtVatTinNo.Enabled = true;
            TxtVatTinDate.Enabled = true;
            TxtEccNo.Enabled = true;
            TxtPanNo.Enabled = true;
            TxtStaxNo.Enabled = true;
            TxtBankName.Enabled = true;
            TxtBankBranchName.Enabled = true;
            TxtIfscCode.Enabled = true;
            TxtMicroCode.Enabled = true;
            TxtBankAccountNo.Enabled = true;
            DdlACDetailsConfirm.Enabled = true;
            DdlServiceDetailsConfirm.Enabled = true;
            TxtHoContactPerson.Enabled = true;
            TxtHoAddress1.Enabled = true;
            TxtHoAddress2.Enabled = true;
            TxtHoAddress3.Enabled = true;
            TxtHoPhoneM.Enabled = true;
            TxtHoPhoneO.Enabled = true;
            TxtHoEmail.Enabled = true;
            TxtHoFax.Enabled = true;
            TxtChequeReportName.Enabled = true;
        }


        public void ControllerDisable()
        {
            TxtAccountName.Enabled = false;
            TxtAccountShort.Enabled = false;
            DdlAccountGroupName.Enabled = false;
            TxtProLossPer.Enabled = false;
            //   DdlCompany.Enabled = false;
            DdlBranch.Enabled = false;
            DdlPlaceName.Enabled = false;
            TxtRouteName.Enabled = false;
            TxtGpsLocation.Enabled = false;
            DdlMrkgPersonName.Enabled = false;
            DdlPaymentPersonName.Enabled = false;
            DdlServicePersonName.Enabled = false;
            TxtContactPersonName.Enabled = false;
            TxtVendorCode.Enabled = false;
            TxtAddress1.Enabled = false;
            TxtAddress2.Enabled = false;
            TxtAddress3.Enabled = false;
            TxtCity.Enabled = false;
            DdlStateName.Enabled = false;
            TxtStateCode.Enabled = false;
            TxtCountry.Enabled = false;
            DdlPartyType.Enabled = false;
            DdlSalesType.Enabled = false;
            DdlRegisterCstType.Enabled = false;
            DdlBusinessType.Enabled = false;
            TxtCreditAmount.Enabled = false;
            TxtCreditDays.Enabled = false;
            TxtPhoneO.Enabled = false;
            TxtPhoneM.Enabled = false;
            TxtFax.Enabled = false;
            TxtEmail.Enabled = false;
            TxtGstNo.Enabled = false;
            TxtVatCstNo.Enabled = false;
            TxtVatCstDate.Enabled = false;
            TxtVatTinNo.Enabled = false;
            TxtVatTinDate.Enabled = false;
            TxtEccNo.Enabled = false;
            TxtPanNo.Enabled = false;
            TxtStaxNo.Enabled = false;
            TxtBankName.Enabled = false;
            TxtBankBranchName.Enabled = false;
            TxtIfscCode.Enabled = false;
            TxtMicroCode.Enabled = false;
            TxtBankAccountNo.Enabled = false;
            DdlACDetailsConfirm.Enabled = false;
            DdlServiceDetailsConfirm.Enabled = false;
            TxtHoContactPerson.Enabled = false;
            TxtHoAddress1.Enabled = false;
            TxtHoAddress2.Enabled = false;
            TxtHoAddress3.Enabled = false;
            TxtHoPhoneM.Enabled = false;
            TxtHoPhoneO.Enabled = false;
            TxtHoEmail.Enabled = false;
            TxtHoFax.Enabled = false;
            TxtChequeReportName.Enabled = false;
        }

        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;
            TxtAccountName.Text = string.Empty;
            TxtAccountShort.Text = string.Empty;
            DdlAccountGroupName.SelectedIndex = 0;
            TxtProLossPer.Text = string.Empty;
            //   DdlCompany.SelectedIndex = 0;
            FillDdlBranch();
            DdlBranch.SelectedIndex = 0;
            DdlPlaceName.SelectedIndex = 0;
            TxtRouteName.Text = string.Empty;
            TxtGpsLocation.Text = string.Empty;
            DdlMrkgPersonName.SelectedIndex = 0;
            DdlPaymentPersonName.SelectedIndex = 0;
            DdlServicePersonName.SelectedIndex = 0;
            TxtContactPersonName.Text = string.Empty;
            TxtVendorCode.Text = string.Empty;
            TxtAddress1.Text = string.Empty;
            TxtAddress2.Text = string.Empty;
            TxtAddress3.Text = string.Empty;
            TxtCity.Text = string.Empty;
            DdlStateName.SelectedIndex = 0;
            TxtStateCode.Text = string.Empty;
            TxtCountry.Text = string.Empty;
            DdlPartyType.SelectedIndex = 0;
            DdlSalesType.SelectedIndex = 0;
            DdlRegisterCstType.SelectedIndex = 0;
            DdlBusinessType.SelectedIndex = 0;
            TxtCreditAmount.Text = string.Empty;
            TxtCreditDays.Text = string.Empty;
            TxtPhoneO.Text = string.Empty;
            TxtPhoneM.Text = string.Empty;
            TxtFax.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            TxtGstNo.Text = string.Empty;
            TxtVatCstNo.Text = string.Empty;
            TxtVatCstDate.Text = string.Empty;
            TxtVatTinNo.Text = string.Empty;
            TxtVatTinDate.Text = string.Empty;
            TxtEccNo.Text = string.Empty;
            TxtPanNo.Text = string.Empty;
            TxtStaxNo.Text = string.Empty;
            TxtBankName.Text = string.Empty;
            TxtBankBranchName.Text = string.Empty;
            TxtIfscCode.Text = string.Empty;
            TxtMicroCode.Text = string.Empty;
            TxtBankAccountNo.Text = string.Empty;
            DdlACDetailsConfirm.SelectedValue = "N";
            DdlServiceDetailsConfirm.SelectedValue = "N";
            TxtHoContactPerson.Text = string.Empty;
            TxtHoAddress1.Text = string.Empty;
            TxtHoAddress2.Text = string.Empty;
            TxtHoAddress3.Text = string.Empty;
            TxtHoPhoneM.Text = string.Empty;
            TxtHoPhoneO.Text = string.Empty;
            TxtHoEmail.Text = string.Empty;
            TxtHoFax.Text = string.Empty;
            TxtChequeReportName.Text = string.Empty;


            BtncallUpd.Text = "SAVE";


        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            //  btnSave.Text = "SAVE";
            lblmsg.Text = string.Empty;
            UserRights();
        }

        //protected void DdlCompany_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FillDdlBranch();
        //}

        protected void BtnHODetails_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelHo", "ShowModelHo()", true);
        }


        public string encrypt(string encryptString)
        {
            string EncryptionKey = "mihirlad9021";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
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

        protected void BtnContactDetail_Click(object sender, EventArgs e)
        {
            string COMP_CODE = HttpUtility.UrlEncode(encrypt(Session["COMP_CODE"].ToString()));
            string ACODE = HttpUtility.UrlEncode(encrypt(hfACC_CODE.Value));


            if (btnSave.Visible == true)
            {
                Response.Write("<script>window.open ('PartyContactDetails.aspx?ACODE=" + ACODE + "&COMP_CODE=" + COMP_CODE + "', '_blank');</script>");
            }
            else
            {
                Response.Write("<script>window.open ('PartyContactDetails.aspx?ACODE=" + hfACC_CODE.Value + "&COMP_CODE=" + hfCOMP_CODE.Value + "&Flag=1', '_blank');</script>");
            }
            //  Response.Redirect("~/Admin/PartyContactDetails.aspx?ACODE=" + hfACC_CODE.Value + "&COMP_CODE=" +hfCOMP_CODE.Value);
        }

        protected void BtnModalDetails_Click(object sender, EventArgs e)
        {

        }

        protected void BtnExportAccount_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelExportAcc", "ShowModelExportAcc()", true);
        }


        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
                ControlllerEnable();
                UserRights();
                Btncalldel.Visible = false;
                BtncallUpd.Visible = true;
                btnSave.Enabled = true;
                btnSave.Visible = true;
                DivEntry.Visible = true;
                DivView.Visible = false;
                BtnContactDetail.Enabled = false;
                BtnModalDetails.Enabled = false;
                BtnExportAccount.Enabled = false;

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region INSERT _ UPDATE VALUE


                //   
                ACCOUNTS_MASLogicLayer insert = new ACCOUNTS_MASLogicLayer();
                insert.COMP_CODE = hfCOMP_CODE.Value.Trim();
                insert.ACODE = hfACC_CODE.Value.Trim();
                insert.ANAME = TxtAccountName.Text.Trim().ToUpper();
                insert.SHORT = TxtAccountShort.Text.Trim().ToUpper();
                insert.GROUP_CODE = DdlAccountGroupName.SelectedValue.Trim().ToUpper();
                insert.ACTIVE = "";
                insert.CONTACT_PER = TxtContactPersonName.Text.Trim().ToUpper();
                if (TxtCreditAmount.Text == string.Empty)
                {
                    insert.CREDIT_AMT = "0";
                }
                else
                {
                    insert.CREDIT_AMT = TxtCreditAmount.Text.Trim();
                }

                if (TxtCreditDays.Text == string.Empty)
                {
                    insert.CREDIT_DAYS = "0";
                }
                else
                {
                    insert.CREDIT_DAYS = TxtCreditDays.Text.Trim();
                }

                insert.ADD1 = TxtAddress1.Text.Trim().ToUpper();
                insert.ADD2 = TxtAddress2.Text.Trim().ToUpper();
                insert.ADD3 = TxtAddress3.Text.Trim().ToUpper();
                insert.ADD4 = "";
                insert.PHONE = TxtPhoneO.Text.Trim().ToUpper();
                insert.PHONE_R = "";
                insert.PHONE_M = TxtPhoneM.Text.Trim().ToUpper();
                insert.FAX = TxtFax.Text.Trim().ToUpper();
                insert.EMAIL = TxtEmail.Text.Trim();
                insert.SST_NO = TxtVatTinNo.Text.Trim().ToUpper();
                insert.CST_NO = TxtVatCstNo.Text.Trim().ToUpper();
                insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToUpper();
                insert.SALES_TYPE = DdlSalesType.SelectedValue.Trim().ToUpper();
                if (TxtProLossPer.Text == string.Empty)
                {
                    insert.PL_PER = "0";
                }
                else
                {
                    insert.PL_PER = TxtProLossPer.Text.Trim();
                }

                insert.REG_NO = "";
                insert.CITY = TxtCity.Text.Trim().ToUpper();
                if (DdlPlaceName.SelectedValue == "0")
                {
                    insert.PLACE = "";
                    insert.PLACE_CODE = null;
                }
                else
                {
                    insert.PLACE = DdlPlaceName.SelectedItem.Text.ToString().ToUpper();
                    insert.PLACE_CODE = HfPlaceCode.Value;
                }
                insert.DISTRICT = "";
                insert.STATE = DdlStateName.SelectedItem.ToString().ToUpper();
                insert.COUNTRY = TxtCountry.Text.Trim().ToUpper();
                insert.AC_CODE = "0";
                insert.ST_PER = "0";
                insert.ADD_ST_PER = "0";
                insert.ATYPE = "";
                insert.EX_RANGE = "";
                insert.EX_DIVISION = "";
                insert.CE_NO = TxtEccNo.Text.Trim().ToUpper();
                insert.BRANCH_CODE = DdlBranch.SelectedValue.Trim().ToUpper();
                insert.PAN_NO = TxtPanNo.Text.Trim().ToUpper();
                insert.CST_TYPE = DdlRegisterCstType.SelectedValue.Trim().ToUpper();
                insert.STAX_NO = TxtStaxNo.Text.Trim().ToUpper();
                insert.EX_COMM = "";
                insert.BANK_NAME = TxtBankName.Text.Trim().ToUpper();
                insert.BANK_BRANCH = TxtBankBranchName.Text.Trim().ToUpper();
                insert.BANK_ADD = "";
                insert.BANK_IFSC = TxtIfscCode.Text.Trim().ToUpper();
                insert.BANK_ACCNO = TxtBankAccountNo.Text.Trim().ToUpper();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";
                insert.CHQ_REPNAME = TxtChequeReportName.Text.Trim().ToUpper();

                if (DdlMrkgPersonName.SelectedValue == "0")
                {
                    insert.MKTG_BCODE = null;
                }
                else
                {

                    insert.MKTG_BCODE = DdlMrkgPersonName.SelectedValue.Trim();
                }


                if (DdlPaymentPersonName.SelectedValue == "0")
                {
                    insert.WORK_BCODE = null;
                }
                else
                {

                    insert.WORK_BCODE = DdlPaymentPersonName.SelectedValue.Trim();
                }


                if (DdlServicePersonName.SelectedValue == "0")
                {

                    insert.ACC_BCODE = null;
                }
                else
                {
                    insert.ACC_BCODE = DdlServicePersonName.SelectedValue.Trim();
                }

                //insert.MKTG_BCODE = DdlMrkgPersonName.SelectedValue.Trim().ToUpper();
                //insert.ACC_BCODE = DdlPaymentPersonName.SelectedValue.Trim().ToUpper();
                //insert.WORK_BCODE = DdlServicePersonName.SelectedValue.Trim().ToUpper();
                insert.BANK_MICRO = TxtMicroCode.Text.Trim().ToUpper();
                insert.GPS_LOCNO = TxtGpsLocation.Text.Trim().ToUpper();
                insert.ACC_COMPFLAG = DdlACDetailsConfirm.SelectedValue.Trim().ToUpper();
                insert.WORK_COMPFLAG = DdlServiceDetailsConfirm.SelectedValue.Trim().ToUpper();
                insert.MKTG_FLAG = "";
                insert.XFER_TYPE = "";
                insert.XFER_USERID = "";
                insert.XFER_TERMINAL = "";
                insert.XFER_DATE = "";
                insert.HO_CONTACT_PER = TxtHoContactPerson.Text.Trim().ToUpper();
                insert.HO_ADD1 = TxtHoAddress1.Text.Trim().ToUpper();
                insert.HO_ADD2 = TxtHoAddress2.Text.Trim().ToUpper();
                insert.HO_ADD3 = TxtHoAddress3.Text.Trim().ToUpper();
                insert.HO_PHONE = TxtHoPhoneO.Text.Trim().ToUpper();
                insert.HO_PHONE_M = TxtHoPhoneM.Text.Trim().ToUpper();
                insert.HO_FAX = TxtHoFax.Text.Trim().ToUpper();
                insert.HO_EMAIL = TxtHoEmail.Text.Trim();
                insert.BUSINESS_TYPE = DdlBusinessType.SelectedValue.Trim().ToUpper();
                if (TxtVatTinDate.Text.Trim() != string.Empty)
                {
                    insert.SST_DATE = Convert.ToDateTime(TxtVatTinDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                if (TxtVatCstDate.Text.Trim() != string.Empty)
                {
                    insert.CST_DATE = Convert.ToDateTime(TxtVatCstDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }

                insert.GST_NO = TxtGstNo.Text.Trim().ToUpper();
                insert.STATE_NO = TxtStateCode.Text.Trim().ToUpper();
                insert.RCM_FLAG = "";
                insert.GST_RATE = "0";
                insert.VENDOR_CODE = TxtVendorCode.Text.Trim().ToUpper();

                #endregion

                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = ACCOUNTS_MASLogicLayer.InsertACCOUNTDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "ACCOUNTS DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "ACCOUNTS CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : ACCOUNTS DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    string str = ACCOUNTS_MASLogicLayer.UpdateACCOUNTDetails(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "ACCOUNTS DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already"))
                    {
                        lblmsg.Text = "ACCOUNTS CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : ACCOUNTS DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillGrid()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTSDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (TxtSearch.Text != string.Empty)
                {
                    Dv.RowFilter = "GST_NO like '%" + TxtSearch.Text.Trim() + "%' OR ANAME like '%" + TxtSearch.Text.Trim() + "%'";
                }

                GvAccount.DataSource = Dv.ToTable();
                GvAccount.DataBind();

                //GvAccount.DataSource = Dt;
                //GvAccount.DataBind();
                DtSearch = Dv.ToTable();
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void GvAccount_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvAccount.PageIndex = e.NewPageIndex;
                FillGrid();
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlPlaceNameOnUpdate(string Id)
        {
            try
            {
                
                DataTable Dt = new DataTable();
                Dt = PLACE_MASLogicLayer.GetAllPLACE_MASDetialsFor_DDL();


                if (HfPlaceCode.Value.ToString() != "0" && HfPlaceCode.Value != null && HfPlaceCode.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "PLACE_CODE=" + Id;
                    DataTable DtView = Dv.ToTable();

                    DdlPlaceName.SelectedValue= DtView.Rows[0]["PLACE_CODE"].ToString();
                    HfPlaceCode.Value = DtView.Rows[0]["PLACE_CODE"].ToString();
               
                }
                else
                {
                    DdlPlaceName.SelectedIndex = 0;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvAccount_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Deletea")
                {
                    #region EDIT
                    clear();
                    DataTable dt = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        hfCOMP_CODE.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        hfACC_CODE.Value = dt.Rows[0]["ACODE"].ToString();
                        TxtAccountName.Text = dt.Rows[0]["ANAME"].ToString();
                        TxtAccountShort.Text = dt.Rows[0]["SHORT"].ToString();
                        DdlAccountGroupName.SelectedValue = dt.Rows[0]["GROUP_CODE"].ToString();
                        TxtProLossPer.Text = dt.Rows[0]["PL_PER"].ToString();
                        FillDdlBranchEdit(dt.Rows[0]["COMP_CODE"].ToString());
                        DdlBranch.SelectedValue = dt.Rows[0]["BRANCH_CODE"].ToString();
                        FillDdlPlace();
                        HfPlaceCode.Value = dt.Rows[0]["PLACE_CODE"].ToString();
                        FillDdlPlaceNameOnUpdate(dt.Rows[0]["PLACE_CODE"].ToString());
                        //    DdlPlaceName.SelectedValue = dt.Rows[0]["PLACE_CODE"].ToString();
                        getrootname();
                        //    TxtRouteName.Text = "";//dt.Rows[0][""].ToString();
                        TxtGpsLocation.Text = dt.Rows[0]["GPS_LOCNO"].ToString();
                        FillDdlBrokerNameOnUpdate();

                        if (string.IsNullOrEmpty(dt.Rows[0]["MKTG_BCODE"].ToString()))//
                        {
                            DdlMrkgPersonName.SelectedIndex = 0;
                        }
                        else
                        {
                            DdlMrkgPersonName.SelectedValue = dt.Rows[0]["MKTG_BCODE"].ToString();
                        }

                        if (string.IsNullOrEmpty(dt.Rows[0]["ACC_BCODE"].ToString()))
                        {
                            DdlPaymentPersonName.SelectedIndex = 0;
                        }
                        else
                        {
                            DdlPaymentPersonName.SelectedValue = dt.Rows[0]["ACC_BCODE"].ToString();
                        }

                        if (string.IsNullOrEmpty(dt.Rows[0]["WORK_BCODE"].ToString()))
                        {
                            DdlServicePersonName.SelectedIndex = 0;
                        }
                        else
                        {
                            DdlServicePersonName.SelectedValue = dt.Rows[0]["WORK_BCODE"].ToString();
                        }


                        TxtContactPersonName.Text = dt.Rows[0]["CONTACT_PER"].ToString();
                        TxtVendorCode.Text = dt.Rows[0]["VENDOR_CODE"].ToString();
                        TxtAddress1.Text = dt.Rows[0]["ADD1"].ToString();
                        TxtAddress2.Text = dt.Rows[0]["ADD2"].ToString();
                        TxtAddress3.Text = dt.Rows[0]["ADD3"].ToString();
                        TxtCity.Text = dt.Rows[0]["CITY"].ToString();
                        //   string x = dt.Rows[0]["STATE"].ToString();
                        HfStateCode.Value = dt.Rows[0]["STATE_CODE"].ToString();
                        FillDdlState();
                        DdlStateName.SelectedValue = dt.Rows[0]["STATE_CODE"].ToString();
                        // getstateno();
                        TxtStateCode.Text = dt.Rows[0]["STATE_NO"].ToString();
                        TxtCountry.Text = dt.Rows[0]["COUNTRY"].ToString();
                        DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                        DdlSalesType.SelectedValue = dt.Rows[0]["SALES_TYPE"].ToString();
                        DdlRegisterCstType.SelectedValue = dt.Rows[0]["CST_TYPE"].ToString();
                        DdlBusinessType.SelectedValue = dt.Rows[0]["BUSINESS_TYPE"].ToString();
                        TxtCreditAmount.Text = dt.Rows[0]["CREDIT_AMT"].ToString();
                        TxtCreditDays.Text = dt.Rows[0]["CREDIT_DAYS"].ToString();
                        TxtPhoneO.Text = dt.Rows[0]["PHONE"].ToString();
                        TxtPhoneM.Text = dt.Rows[0]["PHONE_M"].ToString();
                        TxtFax.Text = dt.Rows[0]["FAX"].ToString();
                        TxtEmail.Text = dt.Rows[0]["EMAIL"].ToString();
                        TxtGstNo.Text = dt.Rows[0]["GST_NO"].ToString();
                        TxtVatCstNo.Text = dt.Rows[0]["CST_NO"].ToString();
                        TxtVatCstDate.Text = dt.Rows[0]["CST_DATE"].ToString();//Convert.ToDateTime(dt.Rows[0]["CST_DATE"].ToString()).ToString("MM-dd-yyyy");; 
                        TxtVatTinNo.Text = dt.Rows[0]["SST_NO"].ToString();
                        TxtVatTinDate.Text = dt.Rows[0]["SST_DATE"].ToString();//Convert.ToDateTime(dt.Rows[0]["SST_DATE"].ToString()).ToString("MM-dd-yyyy");;
                        TxtEccNo.Text = dt.Rows[0]["CE_NO"].ToString();
                        TxtPanNo.Text = dt.Rows[0]["PAN_NO"].ToString();
                        TxtStaxNo.Text = dt.Rows[0]["STAX_NO"].ToString();
                        TxtBankName.Text = dt.Rows[0]["BANK_NAME"].ToString();
                        TxtBankBranchName.Text = dt.Rows[0]["BANK_BRANCH"].ToString();
                        TxtIfscCode.Text = dt.Rows[0]["BANK_IFSC"].ToString();
                        TxtMicroCode.Text = dt.Rows[0]["BANK_MICRO"].ToString();
                        TxtBankAccountNo.Text = dt.Rows[0]["BANK_ACCNO"].ToString();
                        DdlACDetailsConfirm.SelectedValue = dt.Rows[0]["ACC_COMPFLAG"].ToString();
                        DdlServiceDetailsConfirm.SelectedValue = dt.Rows[0]["WORK_COMPFLAG"].ToString();
                        TxtHoContactPerson.Text = dt.Rows[0]["HO_CONTACT_PER"].ToString();
                        TxtHoAddress1.Text = dt.Rows[0]["HO_ADD1"].ToString();
                        TxtHoAddress2.Text = dt.Rows[0]["HO_ADD2"].ToString();
                        TxtHoAddress3.Text = dt.Rows[0]["HO_ADD3"].ToString();
                        TxtHoPhoneM.Text = dt.Rows[0]["HO_PHONE"].ToString();
                        TxtHoPhoneO.Text = dt.Rows[0]["HO_PHONE_M"].ToString();
                        TxtHoEmail.Text = dt.Rows[0]["HO_EMAIL"].ToString();
                        TxtHoFax.Text = dt.Rows[0]["HO_FAX"].ToString();
                        TxtChequeReportName.Text = dt.Rows[0]["CHQ_REPNAME"].ToString();


                    }

                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    Btncalldel.Visible = true;
                    BtncallUpd.Visible = false;
                    BtnHODetails.Enabled = false;
                    BtnContactDetail.Enabled = false;
                    BtnModalDetails.Enabled = false;
                    BtnExportAccount.Enabled = false;
                    ControllerDisable();

                    #endregion
                }



                if (e.CommandName == "Edita")
                {
                    #region EDIT
                    //     clear();
                    DataTable dt = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                     
                        hfCOMP_CODE.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        hfACC_CODE.Value = dt.Rows[0]["ACODE"].ToString();
                        TxtAccountName.Text = dt.Rows[0]["ANAME"].ToString();
                        TxtAccountShort.Text = dt.Rows[0]["SHORT"].ToString();
                        DdlAccountGroupName.SelectedValue = dt.Rows[0]["GROUP_CODE"].ToString();
                        TxtProLossPer.Text = dt.Rows[0]["PL_PER"].ToString();
                        FillDdlBranchEdit(dt.Rows[0]["COMP_CODE"].ToString());
                        DdlBranch.SelectedValue = dt.Rows[0]["BRANCH_CODE"].ToString();
                        FillDdlPlace();
                        HfPlaceCode.Value= dt.Rows[0]["PLACE_CODE"].ToString();
                        FillDdlPlaceNameOnUpdate(dt.Rows[0]["PLACE_CODE"].ToString());
                    //    DdlPlaceName.SelectedValue = dt.Rows[0]["PLACE_CODE"].ToString();
                        getrootname();
                      //    TxtRouteName.Text = "";//dt.Rows[0][""].ToString();
                        TxtGpsLocation.Text = dt.Rows[0]["GPS_LOCNO"].ToString();
                        FillDdlBrokerNameOnUpdate();

                        if (string.IsNullOrEmpty(dt.Rows[0]["MKTG_BCODE"].ToString()))//
                        {
                            DdlMrkgPersonName.SelectedIndex = 0;
                        }
                        else
                        {
                            DdlMrkgPersonName.SelectedValue = dt.Rows[0]["MKTG_BCODE"].ToString();
                        }

                        if (string.IsNullOrEmpty(dt.Rows[0]["ACC_BCODE"].ToString()))
                        {
                            DdlPaymentPersonName.SelectedIndex = 0;
                        }
                        else
                        {
                            DdlPaymentPersonName.SelectedValue = dt.Rows[0]["ACC_BCODE"].ToString();
                        }

                        if (string.IsNullOrEmpty(dt.Rows[0]["WORK_BCODE"].ToString()))
                        {
                            DdlServicePersonName.SelectedIndex = 0;
                        }
                        else
                        {
                            DdlServicePersonName.SelectedValue = dt.Rows[0]["WORK_BCODE"].ToString();
                        }

                       
                        TxtContactPersonName.Text = dt.Rows[0]["CONTACT_PER"].ToString();
                        TxtVendorCode.Text = dt.Rows[0]["VENDOR_CODE"].ToString();
                        TxtAddress1.Text = dt.Rows[0]["ADD1"].ToString();
                        TxtAddress2.Text = dt.Rows[0]["ADD2"].ToString();
                        TxtAddress3.Text = dt.Rows[0]["ADD3"].ToString();
                        TxtCity.Text = dt.Rows[0]["CITY"].ToString();
                    //   string x = dt.Rows[0]["STATE"].ToString();
                        HfStateCode.Value= dt.Rows[0]["STATE_CODE"].ToString();
                        FillDdlState();
                        DdlStateName.SelectedValue = dt.Rows[0]["STATE_CODE"].ToString();
                       // getstateno();
                        TxtStateCode.Text = dt.Rows[0]["STATE_NO"].ToString();
                        TxtCountry.Text = dt.Rows[0]["COUNTRY"].ToString();
                        DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                        DdlSalesType.SelectedValue = dt.Rows[0]["SALES_TYPE"].ToString();
                        DdlRegisterCstType.SelectedValue = dt.Rows[0]["CST_TYPE"].ToString();
                        DdlBusinessType.SelectedValue = dt.Rows[0]["BUSINESS_TYPE"].ToString();
                        TxtCreditAmount.Text = dt.Rows[0]["CREDIT_AMT"].ToString();
                        TxtCreditDays.Text = dt.Rows[0]["CREDIT_DAYS"].ToString();
                        TxtPhoneO.Text = dt.Rows[0]["PHONE"].ToString();
                        TxtPhoneM.Text = dt.Rows[0]["PHONE_M"].ToString();
                        TxtFax.Text = dt.Rows[0]["FAX"].ToString();
                        TxtEmail.Text = dt.Rows[0]["EMAIL"].ToString();
                        TxtGstNo.Text = dt.Rows[0]["GST_NO"].ToString();
                        TxtVatCstNo.Text = dt.Rows[0]["CST_NO"].ToString();
                        TxtVatCstDate.Text = dt.Rows[0]["CST_DATE"].ToString();//Convert.ToDateTime(dt.Rows[0]["CST_DATE"].ToString()).ToString("MM-dd-yyyy");; 
                        TxtVatTinNo.Text = dt.Rows[0]["SST_NO"].ToString();
                        TxtVatTinDate.Text = dt.Rows[0]["SST_DATE"].ToString();//Convert.ToDateTime(dt.Rows[0]["SST_DATE"].ToString()).ToString("MM-dd-yyyy");;
                        TxtEccNo.Text = dt.Rows[0]["CE_NO"].ToString();
                        TxtPanNo.Text = dt.Rows[0]["PAN_NO"].ToString();
                        TxtStaxNo.Text = dt.Rows[0]["STAX_NO"].ToString();
                        TxtBankName.Text = dt.Rows[0]["BANK_NAME"].ToString();
                        TxtBankBranchName.Text = dt.Rows[0]["BANK_BRANCH"].ToString();
                        TxtIfscCode.Text = dt.Rows[0]["BANK_IFSC"].ToString();
                        TxtMicroCode.Text = dt.Rows[0]["BANK_MICRO"].ToString();
                        TxtBankAccountNo.Text = dt.Rows[0]["BANK_ACCNO"].ToString();
                        DdlACDetailsConfirm.SelectedValue = dt.Rows[0]["ACC_COMPFLAG"].ToString();
                        DdlServiceDetailsConfirm.SelectedValue = dt.Rows[0]["WORK_COMPFLAG"].ToString();
                        TxtHoContactPerson.Text = dt.Rows[0]["HO_CONTACT_PER"].ToString();
                        TxtHoAddress1.Text = dt.Rows[0]["HO_ADD1"].ToString();
                        TxtHoAddress2.Text = dt.Rows[0]["HO_ADD2"].ToString();
                        TxtHoAddress3.Text = dt.Rows[0]["HO_ADD3"].ToString();
                        TxtHoPhoneM.Text = dt.Rows[0]["HO_PHONE"].ToString();
                        TxtHoPhoneO.Text = dt.Rows[0]["HO_PHONE_M"].ToString();
                        TxtHoEmail.Text = dt.Rows[0]["HO_EMAIL"].ToString();
                        TxtHoFax.Text = dt.Rows[0]["HO_FAX"].ToString();
                        TxtChequeReportName.Text = dt.Rows[0]["CHQ_REPNAME"].ToString();


                        BtncallUpd.Text = "UPDATE";

                        #endregion
                    }

                    #region CHECK UPDATE RIGHTS
                    if (Session["UPDATE"] != null)
                    {
                        if (Session["UPDATE"].ToString() == "Y")
                        {
                            ControlllerEnable();
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
                    BtnContactDetail.Enabled = true;
                    BtnHODetails.Enabled = true;
                    BtnModalDetails.Enabled = true;
                    BtnExportAccount.Enabled = true;
                    UserRights();
                }


                if (e.CommandName == "Viewa")
                {

                    #region SET TEXT ON VIEW
                    clear();

                    DataTable dt = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        hfCOMP_CODE.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        hfACC_CODE.Value = dt.Rows[0]["ACODE"].ToString();
                        TxtAccountName.Text = dt.Rows[0]["ANAME"].ToString();
                        TxtAccountShort.Text = dt.Rows[0]["SHORT"].ToString();
                        DdlAccountGroupName.SelectedValue = dt.Rows[0]["GROUP_CODE"].ToString();
                        TxtProLossPer.Text = dt.Rows[0]["PL_PER"].ToString();
                        FillDdlBranchEdit(dt.Rows[0]["COMP_CODE"].ToString());
                        DdlBranch.SelectedValue = dt.Rows[0]["BRANCH_CODE"].ToString();
                        FillDdlPlace();
                        HfPlaceCode.Value = dt.Rows[0]["PLACE_CODE"].ToString();
                        FillDdlPlaceNameOnUpdate(dt.Rows[0]["PLACE_CODE"].ToString());
                        //    DdlPlaceName.SelectedValue = dt.Rows[0]["PLACE_CODE"].ToString();
                        getrootname();
                        //    TxtRouteName.Text = "";//dt.Rows[0][""].ToString();
                        TxtGpsLocation.Text = dt.Rows[0]["GPS_LOCNO"].ToString();
                        FillDdlBrokerNameOnUpdate();

                        if (string.IsNullOrEmpty(dt.Rows[0]["MKTG_BCODE"].ToString()))//
                        {
                            DdlMrkgPersonName.SelectedIndex = 0;
                        }
                        else
                        {
                            DdlMrkgPersonName.SelectedValue = dt.Rows[0]["MKTG_BCODE"].ToString();
                        }

                        if (string.IsNullOrEmpty(dt.Rows[0]["ACC_BCODE"].ToString()))
                        {
                            DdlPaymentPersonName.SelectedIndex = 0;
                        }
                        else
                        {
                            DdlPaymentPersonName.SelectedValue = dt.Rows[0]["ACC_BCODE"].ToString();
                        }

                        if (string.IsNullOrEmpty(dt.Rows[0]["WORK_BCODE"].ToString()))
                        {
                            DdlServicePersonName.SelectedIndex = 0;
                        }
                        else
                        {
                            DdlServicePersonName.SelectedValue = dt.Rows[0]["WORK_BCODE"].ToString();
                        }


                        TxtContactPersonName.Text = dt.Rows[0]["CONTACT_PER"].ToString();
                        TxtVendorCode.Text = dt.Rows[0]["VENDOR_CODE"].ToString();
                        TxtAddress1.Text = dt.Rows[0]["ADD1"].ToString();
                        TxtAddress2.Text = dt.Rows[0]["ADD2"].ToString();
                        TxtAddress3.Text = dt.Rows[0]["ADD3"].ToString();
                        TxtCity.Text = dt.Rows[0]["CITY"].ToString();
                        //   string x = dt.Rows[0]["STATE"].ToString();
                        HfStateCode.Value = dt.Rows[0]["STATE_CODE"].ToString();
                        FillDdlState();
                        DdlStateName.SelectedValue = dt.Rows[0]["STATE_CODE"].ToString();
                        // getstateno();
                        TxtStateCode.Text = dt.Rows[0]["STATE_NO"].ToString();
                        TxtCountry.Text = dt.Rows[0]["COUNTRY"].ToString();
                        DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                        DdlSalesType.SelectedValue = dt.Rows[0]["SALES_TYPE"].ToString();
                        DdlRegisterCstType.SelectedValue = dt.Rows[0]["CST_TYPE"].ToString();
                        DdlBusinessType.SelectedValue = dt.Rows[0]["BUSINESS_TYPE"].ToString();
                        TxtCreditAmount.Text = dt.Rows[0]["CREDIT_AMT"].ToString();
                        TxtCreditDays.Text = dt.Rows[0]["CREDIT_DAYS"].ToString();
                        TxtPhoneO.Text = dt.Rows[0]["PHONE"].ToString();
                        TxtPhoneM.Text = dt.Rows[0]["PHONE_M"].ToString();
                        TxtFax.Text = dt.Rows[0]["FAX"].ToString();
                        TxtEmail.Text = dt.Rows[0]["EMAIL"].ToString();
                        TxtGstNo.Text = dt.Rows[0]["GST_NO"].ToString();
                        TxtVatCstNo.Text = dt.Rows[0]["CST_NO"].ToString();
                        TxtVatCstDate.Text = dt.Rows[0]["CST_DATE"].ToString();//Convert.ToDateTime(dt.Rows[0]["CST_DATE"].ToString()).ToString("MM-dd-yyyy");; 
                        TxtVatTinNo.Text = dt.Rows[0]["SST_NO"].ToString();
                        TxtVatTinDate.Text = dt.Rows[0]["SST_DATE"].ToString();//Convert.ToDateTime(dt.Rows[0]["SST_DATE"].ToString()).ToString("MM-dd-yyyy");;
                        TxtEccNo.Text = dt.Rows[0]["CE_NO"].ToString();
                        TxtPanNo.Text = dt.Rows[0]["PAN_NO"].ToString();
                        TxtStaxNo.Text = dt.Rows[0]["STAX_NO"].ToString();
                        TxtBankName.Text = dt.Rows[0]["BANK_NAME"].ToString();
                        TxtBankBranchName.Text = dt.Rows[0]["BANK_BRANCH"].ToString();
                        TxtIfscCode.Text = dt.Rows[0]["BANK_IFSC"].ToString();
                        TxtMicroCode.Text = dt.Rows[0]["BANK_MICRO"].ToString();
                        TxtBankAccountNo.Text = dt.Rows[0]["BANK_ACCNO"].ToString();
                        DdlACDetailsConfirm.SelectedValue = dt.Rows[0]["ACC_COMPFLAG"].ToString();
                        DdlServiceDetailsConfirm.SelectedValue = dt.Rows[0]["WORK_COMPFLAG"].ToString();
                        TxtHoContactPerson.Text = dt.Rows[0]["HO_CONTACT_PER"].ToString();
                        TxtHoAddress1.Text = dt.Rows[0]["HO_ADD1"].ToString();
                        TxtHoAddress2.Text = dt.Rows[0]["HO_ADD2"].ToString();
                        TxtHoAddress3.Text = dt.Rows[0]["HO_ADD3"].ToString();
                        TxtHoPhoneM.Text = dt.Rows[0]["HO_PHONE"].ToString();
                        TxtHoPhoneO.Text = dt.Rows[0]["HO_PHONE_M"].ToString();
                        TxtHoEmail.Text = dt.Rows[0]["HO_EMAIL"].ToString();
                        TxtHoFax.Text = dt.Rows[0]["HO_FAX"].ToString();
                        TxtChequeReportName.Text = dt.Rows[0]["CHQ_REPNAME"].ToString();


                        #endregion
                    }

                    ControllerDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    BtnHODetails.Enabled = true;
                    BtnContactDetail.Enabled = false;
                    BtnModalDetails.Enabled = false;
                    BtnExportAccount.Enabled = false;
                    UserRights();
                }
            }
            catch (Exception ex)
            {

                lblmsg.Text = ex.Message.ToString();
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
                    ACCOUNTS_MASLogicLayer insert = new ACCOUNTS_MASLogicLayer();

                    //   insert.ACODE = hfACC_CODE.Value.Trim();
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.ACODE = hfACC_CODE.Value.Trim();
                    insert.ANAME = TxtAccountName.Text.Trim().ToUpper();
                    insert.SHORT = TxtAccountShort.Text.Trim().ToUpper();
                    insert.GROUP_CODE = DdlAccountGroupName.SelectedValue.Trim().ToUpper();
                    insert.ACTIVE = "";
                    insert.CONTACT_PER = TxtContactPersonName.Text.Trim().ToUpper();
                    if (TxtCreditAmount.Text == string.Empty)
                    {
                        insert.CREDIT_AMT = "0";
                    }
                    else
                    {
                        insert.CREDIT_AMT = TxtCreditAmount.Text.Trim();
                    }

                    if (TxtCreditDays.Text == string.Empty)
                    {
                        insert.CREDIT_DAYS = "0";
                    }
                    else
                    {
                        insert.CREDIT_DAYS = TxtCreditDays.Text.Trim();
                    }

                    insert.ADD1 = TxtAddress1.Text.Trim().ToUpper();
                    insert.ADD2 = TxtAddress2.Text.Trim().ToUpper();
                    insert.ADD3 = TxtAddress3.Text.Trim().ToUpper();
                    insert.ADD4 = "";
                    insert.PHONE = TxtPhoneO.Text.Trim().ToUpper();
                    insert.PHONE_R = "";
                    insert.PHONE_M = TxtPhoneM.Text.Trim().ToUpper();
                    insert.FAX = TxtFax.Text.Trim().ToUpper();
                    insert.EMAIL = TxtEmail.Text.Trim();
                    insert.SST_NO = TxtVatTinNo.Text.Trim().ToUpper();
                    insert.CST_NO = TxtVatCstNo.Text.Trim().ToUpper();
                    insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToUpper();
                    insert.SALES_TYPE = DdlSalesType.SelectedValue.Trim().ToUpper();
                    if (TxtProLossPer.Text == string.Empty)
                    {
                        insert.PL_PER = "0";
                    }
                    else
                    {
                        insert.PL_PER = TxtProLossPer.Text.Trim();
                    }

                    insert.REG_NO = "";
                    insert.CITY = TxtCity.Text.Trim().ToUpper();
                    if (DdlPlaceName.SelectedValue == "0")
                    {
                        insert.PLACE = "";
                        insert.PLACE_CODE = null;
                    }
                    else
                    {
                        insert.PLACE = DdlPlaceName.SelectedItem.Text.ToString().ToUpper();
                        insert.PLACE_CODE = HfPlaceCode.Value;
                    }
                    insert.DISTRICT = "";
                    insert.STATE = DdlStateName.SelectedItem.ToString().ToUpper();
                    insert.COUNTRY = TxtCountry.Text.Trim().ToUpper();
                    insert.AC_CODE = "0";
                    insert.ST_PER = "0";
                    insert.ADD_ST_PER = "0";
                    insert.ATYPE = "";
                    insert.EX_RANGE = "";
                    insert.EX_DIVISION = "";
                    insert.CE_NO = TxtEccNo.Text.Trim().ToUpper();
                    insert.BRANCH_CODE = DdlBranch.SelectedValue.Trim().ToUpper();
                    insert.PAN_NO = TxtPanNo.Text.Trim().ToUpper();
                    insert.CST_TYPE = DdlRegisterCstType.SelectedValue.Trim().ToUpper();
                    insert.STAX_NO = TxtStaxNo.Text.Trim().ToUpper();
                    insert.EX_COMM = "";
                    insert.BANK_NAME = TxtBankName.Text.Trim().ToUpper();
                    insert.BANK_BRANCH = TxtBankBranchName.Text.Trim().ToUpper();
                    insert.BANK_ADD = "";
                    insert.BANK_IFSC = TxtIfscCode.Text.Trim().ToUpper();
                    insert.BANK_ACCNO = TxtBankAccountNo.Text.Trim().ToUpper();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    //insert.UPD_USERID = Session["USERNAME"].ToString();
                    //insert.UPD_TERMINAL = Session["PC"].ToString();
                    //insert.UPD_DATE = "";
                    insert.CHQ_REPNAME = TxtChequeReportName.Text.Trim().ToUpper();


                    if (DdlMrkgPersonName.SelectedValue == "0")
                    {
                        insert.MKTG_BCODE = null;
                    }
                    else
                    {

                        insert.MKTG_BCODE = DdlMrkgPersonName.SelectedValue.Trim();
                    }


                    if (DdlPaymentPersonName.SelectedValue == "0")
                    {
                        insert.WORK_BCODE = null;
                    }
                    else
                    {

                        insert.WORK_BCODE = DdlPaymentPersonName.SelectedValue.Trim();
                    }


                    if (DdlServicePersonName.SelectedValue == "0")
                    {

                        insert.ACC_BCODE = null;
                    }
                    else
                    {
                        insert.ACC_BCODE = DdlServicePersonName.SelectedValue.Trim();
                    }

                    //insert.MKTG_BCODE = DdlMrkgPersonName.SelectedValue.Trim().ToUpper();
                    //insert.ACC_BCODE = DdlPaymentPersonName.SelectedValue.Trim().ToUpper();
                    //insert.WORK_BCODE = DdlServicePersonName.SelectedValue.Trim().ToUpper();
                    insert.BANK_MICRO = TxtMicroCode.Text.Trim().ToUpper();
                    insert.GPS_LOCNO = TxtGpsLocation.Text.Trim().ToUpper();
                    insert.ACC_COMPFLAG = DdlACDetailsConfirm.SelectedValue.Trim().ToUpper();
                    insert.WORK_COMPFLAG = DdlServiceDetailsConfirm.SelectedValue.Trim().ToUpper();
                    insert.MKTG_FLAG = "";
                    insert.XFER_TYPE = "";
                    insert.XFER_USERID = "";
                    insert.XFER_TERMINAL = "";
                    insert.XFER_DATE = "";
                    insert.HO_CONTACT_PER = TxtHoContactPerson.Text.Trim().ToUpper();
                    insert.HO_ADD1 = TxtHoAddress1.Text.Trim().ToUpper();
                    insert.HO_ADD2 = TxtHoAddress2.Text.Trim().ToUpper();
                    insert.HO_ADD3 = TxtHoAddress3.Text.Trim().ToUpper();
                    insert.HO_PHONE = TxtHoPhoneO.Text.Trim().ToUpper();
                    insert.HO_PHONE_M = TxtHoPhoneM.Text.Trim().ToUpper();
                    insert.HO_FAX = TxtHoFax.Text.Trim().ToUpper();
                    insert.HO_EMAIL = TxtHoEmail.Text.Trim();
                    insert.BUSINESS_TYPE = DdlBusinessType.SelectedValue.Trim().ToUpper();
                    if (TxtVatTinDate.Text.Trim() != string.Empty)
                    {
                        insert.SST_DATE = Convert.ToDateTime(TxtVatTinDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    if (TxtVatCstDate.Text.Trim() != string.Empty)
                    {
                        insert.CST_DATE = Convert.ToDateTime(TxtVatCstDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    insert.GST_NO = TxtGstNo.Text.Trim().ToUpper();
                    insert.STATE_NO = TxtStateCode.Text.Trim().ToUpper();
                    insert.RCM_FLAG = "";
                    insert.GST_RATE = "0";
                    insert.VENDOR_CODE = TxtVendorCode.Text.Trim().ToUpper();

                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = ACCOUNTS_MASLogicLayer.InsertACCOUNTDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "ACCOUNTS DETAIL SAVE SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid();
                            UserRights();
                        }
                        else if (str.Contains("Already"))
                        {
                            lblmsg.Text = "ACCOUNTS CODE ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : ACCOUNTS DETAIL NOT SAVED";
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE  
                if (hfACC_CODE.Value != string.Empty)
                {
                    string str = ACCOUNTS_MASLogicLayer.DeleteACCOUNTDetailsByID(hfACC_CODE.Value);
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
                        lblmsg.Text = "Error:Account Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillGrid();
                    UserRights();

                }
                #endregion
            }

            catch (Exception)
            {
                throw;
            }
        }

        protected void DdlPlaceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            HfPlaceCode.Value = DdlPlaceName.SelectedValue;
            getrootname();
        }

        private void getrootname()
        {
            try
            {
                if (HfPlaceCode.Value.ToString() != "0" && HfPlaceCode.Value != null && HfPlaceCode.Value.ToString() != string.Empty)
                { 
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT ROUTE_MAS.ROUTE_NAME FROM PLACE_MAS INNER JOIN ROUTE_MAS ON PLACE_MAS.ROUTE_CODE = ROUTE_MAS.ROUTE_CODE where PLACE_MAS.PLACE_CODE = '" + HfPlaceCode.Value.ToString() + "'", con);
                TxtRouteName.Text = cmd.ExecuteScalar().ToString();
                TxtRouteName.Enabled = false;
                con.Close();
               }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            getstateno();
        }

        public void getstateno()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select state_no from state_mas where state_name = '" + DdlStateName.SelectedItem.ToString() + "'", con);
                TxtStateCode.Text = cmd.ExecuteScalar().ToString();
                TxtStateCode.Enabled = false;
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }


        }

        protected void BtnExportAcc_Click(object sender, EventArgs e)
        {
            try
            {
                ACCOUNTS_MASLogicLayer insert = new ACCOUNTS_MASLogicLayer();
                insert.COMP_CODE = DdlToCompanyExport.SelectedValue.Trim().ToUpper();
                insert.ACODE = hfACC_CODE.Value.Trim();
                insert.ANAME = TxtAccountName.Text.Trim().ToUpper();
                insert.SHORT = TxtAccountShort.Text.Trim().ToUpper();
                insert.GROUP_CODE = DdlAccountGroupName.SelectedValue.Trim().ToUpper();
                insert.ACTIVE = "";
                insert.CONTACT_PER = TxtContactPersonName.Text.Trim().ToUpper();
                if (TxtCreditAmount.Text == string.Empty)
                {
                    insert.CREDIT_AMT = "0";
                }
                else
                {
                    insert.CREDIT_AMT = TxtCreditAmount.Text.Trim();
                }

                if (TxtCreditDays.Text == string.Empty)
                {
                    insert.CREDIT_DAYS = "0";
                }
                else
                {
                    insert.CREDIT_DAYS = TxtCreditDays.Text.Trim();
                }

                insert.ADD1 = TxtAddress1.Text.Trim().ToUpper();
                insert.ADD2 = TxtAddress2.Text.Trim().ToUpper();
                insert.ADD3 = TxtAddress3.Text.Trim().ToUpper();
                insert.ADD4 = "";
                insert.PHONE = TxtPhoneO.Text.Trim().ToUpper();
                insert.PHONE_R = "";
                insert.PHONE_M = TxtPhoneM.Text.Trim().ToUpper();
                insert.FAX = TxtFax.Text.Trim().ToUpper();
                insert.EMAIL = TxtEmail.Text.Trim();
                insert.SST_NO = TxtVatTinNo.Text.Trim().ToUpper();
                insert.CST_NO = TxtVatCstNo.Text.Trim().ToUpper();
                insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToUpper();
                insert.SALES_TYPE = DdlSalesType.SelectedValue.Trim().ToUpper();
                if (TxtProLossPer.Text == string.Empty)
                {
                    insert.PL_PER = "0";
                }
                else
                {
                    insert.PL_PER = TxtProLossPer.Text.Trim();
                }

                insert.REG_NO = "";
                insert.CITY = TxtCity.Text.Trim().ToUpper();
                insert.PLACE = DdlPlaceName.SelectedItem.Text.ToString().ToUpper();
                insert.PLACE_CODE = DdlPlaceName.SelectedValue;
                insert.DISTRICT = "";
                insert.STATE = DdlStateName.SelectedItem.ToString().ToUpper();
                insert.COUNTRY = TxtCountry.Text.Trim().ToUpper();
                insert.AC_CODE = "0";
                insert.ST_PER = "0";
                insert.ADD_ST_PER = "0";
                insert.ATYPE = "";
                insert.EX_RANGE = "";
                insert.EX_DIVISION = "";
                insert.CE_NO = TxtEccNo.Text.Trim().ToUpper();
                insert.BRANCH_CODE = DdlToBranchExport.SelectedValue.Trim().ToUpper();
                insert.PAN_NO = TxtPanNo.Text.Trim().ToUpper();
                insert.CST_TYPE = DdlRegisterCstType.SelectedValue.Trim().ToUpper();
                insert.STAX_NO = TxtStaxNo.Text.Trim().ToUpper();
                insert.EX_COMM = "";
                insert.BANK_NAME = TxtBankName.Text.Trim().ToUpper();
                insert.BANK_BRANCH = TxtBankBranchName.Text.Trim().ToUpper();
                insert.BANK_ADD = "";
                insert.BANK_IFSC = TxtIfscCode.Text.Trim().ToUpper();
                insert.BANK_ACCNO = TxtBankAccountNo.Text.Trim().ToUpper();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";
                insert.CHQ_REPNAME = TxtChequeReportName.Text.Trim().ToUpper();

                insert.MKTG_BCODE = DdlMrkgPersonName.SelectedValue.Trim().ToUpper();
                insert.ACC_BCODE = DdlPaymentPersonName.SelectedValue.Trim().ToUpper();
                insert.WORK_BCODE = DdlServicePersonName.SelectedValue.Trim().ToUpper();
                insert.BANK_MICRO = TxtMicroCode.Text.Trim().ToUpper();
                insert.GPS_LOCNO = TxtGpsLocation.Text.Trim().ToUpper();
                insert.ACC_COMPFLAG = DdlACDetailsConfirm.SelectedValue.Trim().ToUpper();
                insert.WORK_COMPFLAG = DdlServiceDetailsConfirm.SelectedValue.Trim().ToUpper();
                insert.MKTG_FLAG = "";
                insert.XFER_TYPE = "";
                insert.XFER_USERID = "";
                insert.XFER_TERMINAL = "";
                insert.XFER_DATE = "";
                insert.HO_CONTACT_PER = TxtHoContactPerson.Text.Trim().ToUpper();
                insert.HO_ADD1 = TxtHoAddress1.Text.Trim().ToUpper();
                insert.HO_ADD2 = TxtHoAddress2.Text.Trim().ToUpper();
                insert.HO_ADD3 = TxtHoAddress3.Text.Trim().ToUpper();
                insert.HO_PHONE = TxtHoPhoneO.Text.Trim().ToUpper();
                insert.HO_PHONE_M = TxtHoPhoneM.Text.Trim().ToUpper();
                insert.HO_FAX = TxtHoFax.Text.Trim().ToUpper();
                insert.HO_EMAIL = TxtHoEmail.Text.Trim();
                insert.BUSINESS_TYPE = DdlBusinessType.SelectedValue.Trim().ToUpper();
                insert.SST_DATE = TxtVatTinDate.Text.Trim().ToUpper();
                insert.CST_DATE = TxtVatCstDate.Text.Trim().ToUpper();
                insert.GST_NO = TxtGstNo.Text.Trim().ToUpper();
                insert.STATE_NO = TxtStateCode.Text.Trim().ToUpper();
                insert.RCM_FLAG = "";
                insert.GST_RATE = "0";
                insert.VENDOR_CODE = TxtVendorCode.Text.Trim().ToUpper();


                if (btnSave.Text.Trim().ToUpper() == "YES")
                {
                    string str = ACCOUNTS_MASLogicLayer.InsertACCOUNTDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "ACCOUNTS DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "ACCOUNTS CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : ACCOUNTS DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlToCompanyExport_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDdlToBranchExport();
        }


        protected void TxtSearch_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtSearch.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtSearch);
                    Dv.RowFilter = "GST_NO like '%" + TxtSearch.Text.Trim() + "%' OR ANAME like '%" + TxtSearch.Text.Trim() + "%'";
                    GvAccount.DataSource = Dv.ToTable();
                    GvAccount.DataBind();
                }
                else
                {
                    GvAccount.DataSource = DtSearch;
                    GvAccount.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void SearchDataOnGrid(string prmsearch)
        {
            try
            {
             
                if (prmsearch != string.Empty)
                {
                   
                    DataView Dv = new DataView(DtSearch);
                    Dv.RowFilter = "GST_NO like '%" + prmsearch.Trim() + "%' OR ANAME like '%" + prmsearch.Trim() + "%'";
                    GvAccount.DataSource = Dv.ToTable();
                    GvAccount.DataBind();
                  
                }
                else
                {
                    GvAccount.DataSource = DtSearch;
                    GvAccount.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtSrcAname_TextChanged(object sender, EventArgs e)

        {
            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.Parent.Parent;
            int idx = row.RowIndex;

            TextBox TxtSrcAname = (TextBox)row.Cells[1].FindControl("TxtSrcAname");
            ViewState["txtsearchData"] = TxtSrcAname.Text;
            SearchDataOnGrid(TxtSrcAname.Text);
           

        }
    }

}