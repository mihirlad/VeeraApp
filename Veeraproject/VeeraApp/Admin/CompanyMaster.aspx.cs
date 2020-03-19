using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class CompanyMaster : System.Web.UI.Page
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
                FillGrid();
                UserRights();
                FillDdlState();
                DivEntry.Visible = false;
                DivView.Visible = true;
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
                //  btnDelete.Visible = false;
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

        public void ControllerEnable()
        {
            try
            {
                TxtCompanyName.Enabled = true;
                // TxtCompanyCode.Text = string.Empty;
                TxtShort.Enabled = true;
                DdlCompanyType.Enabled = true;
                DdlStockType.Enabled = true;
                TxtYR_END.Enabled = true;
                TxtYR_START.Enabled = true;
                TxtADD1.Enabled = true;
                TxtADD2.Enabled = true;
                TxtADD3.Enabled = true;
                TxtCity.Enabled = true;
                TxtPlace.Enabled = true;
                TxtPhone.Enabled = true;
                TxtDistrict.Enabled = true;
                DdlStateName.Enabled = true;
                TxtStateCode.Enabled = false;
                TxtCountry.Enabled = true;
                TxtPhone.Enabled = true;
                TxtFax.Enabled = true;
                TxtEmailAddress.Enabled = true;
                TxtAutoEmailAddress.Enabled = true;
                TxtBankName.Enabled = true;
                TxtBranchName.Enabled = true;
                TxtIFSC.Enabled = true;
                TxtBankAccNo.Enabled = true;
                TxtAuthorisedPerson.Enabled = true;
                TxtGODTitle.Enabled = true;
                TxtProductDesc.Enabled = true;
                TxtGSTNo.Enabled = true;
                TxtVatTinNo.Enabled = true;
                TxtVatCstNo.Enabled = true;
                TxtEccCNo.Enabled = true;
                TxtPanNo.Enabled = true;
                TxtServiceTaxNo.Enabled = true;
                UploadSignaturePath.Enabled = true;
                UploadInvoiceLogoPath2.Enabled = true;
                UploadInvoiceLogoPath1.Enabled = true;
                UploadScreenPicturePath.Enabled = true;
                DdlStokWorkingFlag.Enabled = true;
                DdlAddDisFlag.Enabled = true;
                DdlInvoiceTypeFlag.Enabled = true;
                DdlStockViewFlag.Enabled = true;
                //Chk_InvoiceLogoFlag.Checked = true;
                //Chk_SignLogoFlag.Checked = true;
                TxtExciseTitle.Enabled = true;
                TxtExciseRange.Enabled = true;
                TxtExciseDivision.Enabled = true;
                TxtCommissionerate.Enabled = true;
                TxtRangeAdd.Enabled = true;
                TxtDivisionAdd.Enabled = true;
                TxtCommisionerateAdd.Enabled = true;
                TxtExcisableGood.Enabled = true;
                TxtExciseRateOfDuty.Enabled = true;
                TxtCETSHTitle1.Enabled = true;
                TxtCETSHTitle2.Enabled = true;
                TxtCETSHTitle3.Enabled = true;
                TxtBasicExciseDuty.Enabled = true;
                TxtEduCess.Enabled = true;
                TxtS_H_EduCess.Enabled = true;
                TxtCETSH1.Enabled = true;
                TxtCETSH2.Enabled = true;
                TxtCETSH3.Enabled = true;
                TxtCertificateTitle1.Enabled = true;
                TxtCertificateTitle2.Enabled = true;
                TxtQuotationSubject.Enabled = true;
                TxtQuoatationBrandName.Enabled = true;
                TxtQuotationFor.Enabled = true;
                TxtQuotationModelNo.Enabled = true;
                TxtQuotationNote.Enabled = true;
                TxtTermsCondition_GST.Enabled = true;
                TxtTermsCondition_VAT.Enabled = true;
               
            }
            catch (Exception)
            {

            }
        }

        public void HtmlButton()
        {

            //HtmlControl BtnRem1 = (HtmlControl)this.FindControl("BtnRem1");
            //HtmlControl BtnRem2 = (HtmlControl)this.FindControl("BtnRem2");
            //HtmlControl BtnRem3 = (HtmlControl)this.FindControl("BtnRem3");
            //HtmlControl BtnRem4 = (HtmlControl)this.FindControl("BtnRem4");
            if (BtncallUpd.Visible == true)
            {
                BtnRem1.Visible = true;
                BtnRem2.Visible = true;
                BtnRem3.Visible = true;
                BtnRem4.Visible = true;
            }
            else
            {
                BtnRem1.Visible = false;
                BtnRem2.Visible = false;
                BtnRem3.Visible = false;
                BtnRem4.Visible = false;
            }
        }

        public void ControllersDisable()
        {
            try
            {
                TxtCompanyName.Enabled = false;
                // TxtCompanyCode.Text = string.Empty;
                TxtShort.Enabled = false;
                DdlCompanyType.Enabled = false;
                DdlStockType.Enabled = false;
                TxtYR_END.Enabled = false;
                TxtYR_START.Enabled = false;
                TxtADD1.Enabled = false;
                TxtADD2.Enabled = false;
                TxtADD3.Enabled = false;
                TxtCity.Enabled = false;
                TxtPlace.Enabled = false;
                TxtPhone.Enabled = false;
                TxtDistrict.Enabled = false;
                DdlStateName.Enabled = false;
                TxtStateCode.Enabled = false;
                TxtCountry.Enabled = false;
                TxtPhone.Enabled = false;
                TxtFax.Enabled = false;
                TxtEmailAddress.Enabled = false;
                TxtAutoEmailAddress.Enabled = false;
                TxtBankName.Enabled = false;
                TxtBranchName.Enabled = false;
                TxtIFSC.Enabled = false;
                TxtBankAccNo.Enabled = false;
                TxtAuthorisedPerson.Enabled = false;
                TxtGODTitle.Enabled = false;
                TxtProductDesc.Enabled = false;
                TxtGSTNo.Enabled = false;
                TxtVatTinNo.Enabled = false;
                TxtVatCstNo.Enabled = false;
                TxtEccCNo.Enabled = false;
                TxtPanNo.Enabled = false;
                TxtServiceTaxNo.Enabled = false;
                UploadSignaturePath.Enabled = false;
                UploadScreenPicturePath.Enabled = false;
                UploadInvoiceLogoPath1.Enabled = false;
                UploadInvoiceLogoPath2.Enabled = false;
                DdlStokWorkingFlag.Enabled = false;
                DdlAddDisFlag.Enabled = false;
                DdlInvoiceTypeFlag.Enabled = false;
                DdlStockViewFlag.Enabled = false;
                //Chk_InvoiceLogoFlag.Checked = false;
                //Chk_SignLogoFlag.Checked = false;
                TxtExciseTitle.Enabled = false;
                TxtExciseRange.Enabled = false;
                TxtExciseDivision.Enabled = false;
                TxtCommissionerate.Enabled = false;
                TxtRangeAdd.Enabled = false;
                TxtDivisionAdd.Enabled = false;
                TxtCommisionerateAdd.Enabled = false;
                TxtExcisableGood.Enabled = false;
                TxtExciseRateOfDuty.Enabled = false;
                TxtCETSHTitle1.Enabled = false;
                TxtCETSHTitle2.Enabled = false;
                TxtCETSHTitle3.Enabled = false;
                TxtBasicExciseDuty.Enabled = false;
                TxtEduCess.Enabled = false;
                TxtS_H_EduCess.Enabled = false;
                TxtCETSH1.Enabled = false;
                TxtCETSH2.Enabled = false;
                TxtCETSH3.Enabled = false;
                TxtCertificateTitle1.Enabled = false;
                TxtCertificateTitle2.Enabled = false;
                TxtQuotationSubject.Enabled = false;
                TxtQuoatationBrandName.Enabled = false;
                TxtQuotationFor.Enabled = false;
                TxtQuotationModelNo.Enabled = false;
                TxtQuotationNote.Enabled = false;
                TxtTermsCondition_GST.Enabled = false;
                TxtTermsCondition_VAT.Enabled = false;

            }
            catch (Exception)
            {

            }
        }

        public void clear()
        {
            try
            {
                hfCOMP_CODE.Value = string.Empty;
                DivEntry.Visible = false;
                DivView.Visible = true;
                TxtCompanyName.Text = string.Empty;
                // TxtCompanyCode.Text = string.Empty;
                TxtShort.Text = string.Empty;
                DdlCompanyType.SelectedIndex = 0;
                DdlStockType.SelectedIndex = 0;
                TxtYR_END.Text = string.Empty;
                TxtYR_START.Text = string.Empty;
                TxtADD1.Text = string.Empty;
                TxtADD2.Text = string.Empty;
                TxtADD3.Text = string.Empty;
                TxtCity.Text = string.Empty;
                TxtPlace.Text = string.Empty;
                TxtPhone.Text = string.Empty;
                TxtDistrict.Text = string.Empty;
                DdlStateName.SelectedIndex = 0;
                TxtStateCode.Text = string.Empty;
                TxtCountry.Text = string.Empty;
                TxtPhone.Text = string.Empty;
                TxtFax.Text = string.Empty;
                TxtEmailAddress.Text = string.Empty;
                TxtAutoEmailAddress.Text = string.Empty;
                TxtBankName.Text = string.Empty;
                TxtBranchName.Text = string.Empty;
                TxtIFSC.Text = string.Empty;
                TxtBankAccNo.Text = string.Empty;
                TxtAuthorisedPerson.Text = string.Empty;
                TxtGODTitle.Text = string.Empty;
                TxtProductDesc.Text = string.Empty;
                TxtGSTNo.Text = string.Empty;
                TxtVatTinNo.Text = string.Empty;
                TxtVatCstNo.Text = string.Empty;
                TxtEccCNo.Text = string.Empty;
                TxtPanNo.Text = string.Empty;
                TxtServiceTaxNo.Text = string.Empty;
                HfUploadSignaturePath.Value = string.Empty;
                HfUploadScreenPicturePath.Value = string.Empty;
                HfUploadInvoiceLogoPath1.Value = string.Empty;
                HfUploadScreenPicturePath.Value = string.Empty;
                DdlStokWorkingFlag.SelectedIndex = 0;
                DdlAddDisFlag.SelectedValue = "N";
                DdlInvoiceTypeFlag.SelectedIndex = 0;
                DdlStockViewFlag.SelectedIndex = 0;
                //Chk_InvoiceLogoFlag.Checked = false;
                //Chk_SignLogoFlag.Checked = false;
                TxtExciseTitle.Text = string.Empty;
                TxtExciseRange.Text = string.Empty;
                TxtExciseDivision.Text = string.Empty;
                TxtCommissionerate.Text = string.Empty;
                TxtRangeAdd.Text = string.Empty;
                TxtDivisionAdd.Text = string.Empty;
                TxtCommisionerateAdd.Text = string.Empty;
                TxtExcisableGood.Text = string.Empty;
                TxtExciseRateOfDuty.Text = string.Empty;
                TxtCETSHTitle1.Text = string.Empty;
                TxtCETSHTitle2.Text = string.Empty;
                TxtCETSHTitle3.Text = string.Empty;
                TxtBasicExciseDuty.Text = string.Empty;
                TxtEduCess.Text = string.Empty;
                TxtS_H_EduCess.Text = string.Empty;
                TxtCETSH1.Text = string.Empty;
                TxtCETSH2.Text = string.Empty;
                TxtCETSH3.Text = string.Empty;
                TxtCertificateTitle1.Text = string.Empty;
                TxtCertificateTitle2.Text = string.Empty;
                TxtQuotationSubject.Text = string.Empty;
                TxtQuoatationBrandName.Text = string.Empty;
                TxtQuotationFor.Text = string.Empty;
                TxtQuotationModelNo.Text = string.Empty;
                TxtQuotationNote.Text = string.Empty;
                TxtTermsCondition_GST.Text = string.Empty;
                TxtTermsCondition_VAT.Text = string.Empty;

                BtncallUpd.Text = "SAVE";
                //btnSave.Text = "SAVE";
                calldel.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnClear_click(object sender, EventArgs e)
        {
            try
            {
                clear();
                //btnSave.Text = "SAVE";
                lblmsg.Text = string.Empty;
                UserRights();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSave_click(object sender, EventArgs e)
        {
            try
            {
                #region INSERT _ UPDATE VALUE
                COMPANYLogicLayer insert = new COMPANYLogicLayer();
                insert.COMP_CODE = hfCOMP_CODE.Value.Trim();
                insert.COMP_TYPE = DdlCompanyType.SelectedValue.Trim().ToUpper();
                insert.NAME = TxtCompanyName.Text.Trim().ToUpper();
                insert.SHORT = TxtShort.Text.Trim().ToUpper();
                insert.STOCK_TYPE = DdlStockType.SelectedValue.Trim().ToUpper();
                insert.ADD1 = TxtADD1.Text.Trim().ToUpper();
                insert.ADD2 = TxtADD2.Text.Trim().ToUpper();
                insert.ADD3 = TxtADD3.Text.Trim().ToUpper();
                insert.ADD_DISFLAG = DdlAddDisFlag.SelectedValue.Trim().ToUpper();
                insert.AUTH_PERSON = TxtAuthorisedPerson.Text.Trim().ToUpper();
                insert.AUTO_MAILID = TxtAutoEmailAddress.Text.Trim();
                insert.BANK_ACCNO = TxtBankAccNo.Text.Trim().Trim().ToUpper();
                insert.BANK_BNAME = TxtBranchName.Text.Trim().ToUpper();
                insert.BANK_IFSCCODE = TxtIFSC.Text.Trim().ToUpper();
                insert.BANK_NAME = TxtBankName.Text.Trim().ToUpper();

                if (Session["UploadSignaturePath"] != null && (!UploadSignaturePath.HasFile))
                {
                    UploadSignaturePath = (FileUpload)Session["UploadSignaturePath"];
                }

                string ExtBKP = HfUploadSignaturePath.Value;
                if (UploadSignaturePath.HasFile)
                {
                    string image = UploadSignaturePath.FileName;
                    ExtBKP = Path.GetExtension(UploadSignaturePath.FileName);
                    //UploadInvoiceLogoPath1.PostedFile.SaveAs(Server.MapPath(".") + "/Admin/images/" + image);
                    //string path = "~/Admin/images/" + image.ToString();
                }
                insert.BKP_PATH = ExtBKP;
                //if (UploadInvoiceLogoPath1.HasFile)
                //{
                //    string image = UploadSignaturePath.FileName;
                //    UploadInvoiceLogoPath1.PostedFile.SaveAs(Server.MapPath(".") + "/Admin/images/" + image);
                //    string path = "~/Admin/images/" + image.ToString();
                //    insert.BKP_PATH = path.ToString();
                //}
                //else
                //{
                //    insert.BKP_PATH = "";
                //}
                insert.CITY = TxtCity.Text.Trim().ToUpper();
                insert.COUNTRY = TxtCountry.Text.Trim().ToUpper();
                insert.CST_NO = TxtVatCstNo.Text.Trim().ToUpper();
                insert.DISTRICT = TxtDistrict.Text.Trim().ToUpper();
                insert.EMAIL = TxtEmailAddress.Text.Trim();
                if (TxtEduCess.Text == string.Empty)
                {
                    insert.EX_CESS_PER = "0";
                }
                else
                {
                    insert.EX_CESS_PER = TxtEduCess.Text.Trim();
                }
                insert.EX_CETH = TxtCETSH1.Text.Trim().ToUpper();
                insert.EX_CETH2 = TxtCETSH2.Text.Trim().ToUpper();
                insert.EX_CETH3 = TxtCETSH3.Text.Trim().ToUpper();
                insert.EX_CETH4 = string.Empty;
                insert.EX_CETH_TITLE = TxtCETSHTitle1.Text.Trim().ToUpper();
                insert.EX_CETH_TITLE2 = TxtCETSHTitle2.Text.Trim().ToUpper();
                insert.EX_CETH_TITLE3 = TxtCETSHTitle3.Text.Trim().ToUpper();
                insert.EX_CETH_TITLE4 = string.Empty;
                insert.EX_COMMISSIONARATE = TxtCommissionerate.Text.Trim().ToUpper();
                insert.EX_COMM_ADD = TxtCommisionerateAdd.Text.Trim().ToUpper();
                insert.EX_DIVISION = TxtExciseDivision.Text.Trim().ToUpper();
                insert.EX_DIV_ADD = TxtDivisionAdd.Text.Trim().ToUpper();
                if (TxtBasicExciseDuty.Text == string.Empty)
                {
                    insert.EX_DUTY_PER = "0";
                }
                else
                {
                    insert.EX_DUTY_PER = TxtBasicExciseDuty.Text.Trim();
                }

                insert.EX_NAME_OF_GOODS = TxtExcisableGood.Text.Trim().ToUpper();
                insert.EX_RANGE = TxtExciseRange.Text.Trim().ToUpper();
                insert.EX_RANGE_ADD = TxtRangeAdd.Text.Trim().ToUpper();
                insert.EX_RATE_OF_DUTY = TxtExciseRateOfDuty.Text.Trim().ToUpper();
                if (TxtS_H_EduCess.Text == string.Empty)
                {
                    insert.EX_SHCESS_PER = "0";
                }
                else
                {
                    insert.EX_SHCESS_PER = TxtS_H_EduCess.Text.Trim();
                }

                insert.EX_TITLE = TxtExciseTitle.Text.Trim().ToUpper();
                insert.EX_TITLE1 = TxtCertificateTitle1.Text.Trim().ToUpper();
                insert.EX_TITLE2 = TxtCertificateTitle2.Text.Trim().ToUpper();
                insert.FAX = TxtFax.Text.Trim().ToUpper();
                insert.GOD_TITLE = TxtGODTitle.Text.Trim().ToUpper();
                insert.GST_NO = TxtGSTNo.Text.Trim().ToUpper();
                insert.INS_DATETIME = string.Empty;
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INVTYPE_FLAG = DdlInvoiceTypeFlag.SelectedValue.Trim().ToUpper();
                if (Chk_InvoiceLogoFlag.Checked == true)
                {
                    insert.INV_LOGO_FLAG = "Y";
                }
                else
                {
                    insert.INV_LOGO_FLAG = "N";
                }

                if (Session["UploadInvoiceLogoPath1"] != null && (!UploadInvoiceLogoPath1.HasFile))
                {
                    UploadInvoiceLogoPath1 = (FileUpload)Session["UploadInvoiceLogoPath1"];
                }
                string ExtLH_PATH = HfUploadInvoiceLogoPath1.Value;
                if (UploadInvoiceLogoPath1.HasFile)
                {
                    string image1 = UploadInvoiceLogoPath1.FileName;
                    ExtLH_PATH = Path.GetExtension(UploadInvoiceLogoPath1.FileName);
                    //UploadInvoiceLogoPath1.PostedFile.SaveAs(Server.MapPath(".") + "/Admin/images/" + image1);
                    //string path1 = "~/Admin/images/" + image1.ToString();
                }
                insert.LH_PATH = ExtLH_PATH;

                if (Session["UploadInvoiceLogoPath2"] != null && (!UploadInvoiceLogoPath2.HasFile))
                {
                    UploadInvoiceLogoPath2 = (FileUpload)Session["UploadInvoiceLogoPath2"];
                }
                string ExtLH_PATH2 = HfUploadInvoiceLogoPath2.Value;
                if (UploadInvoiceLogoPath2.HasFile)
                {
                    string image2 = UploadInvoiceLogoPath2.FileName;
                    ExtLH_PATH2 = Path.GetExtension(UploadInvoiceLogoPath2.FileName);
                    //UploadInvoiceLogoPath2.PostedFile.SaveAs(Server.MapPath(".") + "/Admin/images" + image2);
                    //string path2 = "~/Admin/images/" + image2.ToString();

                }
                insert.LH_PATH2 = ExtLH_PATH2;


                //if (UploadInvoiceLogoPath1.HasFile)
                //{
                //    string image1 = UploadInvoiceLogoPath1.FileName;
                //    UploadInvoiceLogoPath1.PostedFile.SaveAs(Server.MapPath(".") + "/Admin/images/" + image1);
                //    string path1 = "~/Admin/images/" + image1.ToString();
                //    insert.LH_PATH = path1.ToString();
                //}
                //else
                //{
                //    insert.LH_PATH = "";
                //}

                //if (UploadInvoiceLogoPath2.HasFile)
                //{
                //    string image2 = UploadInvoiceLogoPath2.FileName;
                //    UploadInvoiceLogoPath2.PostedFile.SaveAs(Server.MapPath(".") + "/Admin/images" + image2);
                //    string path2 = "~/Admin/images/" + image2.ToString();
                //    insert.LH_PATH2 = path2.ToString();
                //}
                //else
                //{
                //    insert.LH_PATH2 = "";
                //}

                insert.PAN_NO = TxtPanNo.Text.Trim().ToUpper();
                insert.PHONE = TxtPhone.Text.Trim().ToUpper();
                insert.PLACE = TxtPlace.Text.Trim().ToUpper();
                insert.PRODUCT_DESC = TxtProductDesc.Text.Trim().ToUpper();
                insert.QUO_BRAND_NAME = TxtQuoatationBrandName.Text.Trim().ToUpper();
                insert.QUO_MODEL_NAME = TxtQuotationModelNo.Text.Trim().ToUpper();
                insert.QUO_NOTE = TxtQuotationNote.Text.Trim().ToUpper();
                insert.QUO_SUB1 = TxtQuotationSubject.Text.Trim().ToUpper();
                insert.QUO_SUB2 = TxtQuotationFor.Text.Trim().ToUpper();
                insert.QUO_SUB3 = string.Empty;
                insert.QUO_SUB4 = string.Empty;
                insert.REF_COMP_CODE = "0";
                insert.REG_NO = TxtEccCNo.Text.Trim().ToUpper();

                if (Session["UploadScreenPicturePath"] != null && (!UploadScreenPicturePath.HasFile))
                {
                    UploadScreenPicturePath = (FileUpload)Session["UploadScreenPicturePath"];
                }
                string ExtSCREEN_PATH = HfUploadScreenPicturePath.Value;
                if (UploadScreenPicturePath.HasFile)
                {
                    string image3 = UploadScreenPicturePath.FileName;
                    ExtSCREEN_PATH = Path.GetExtension(UploadScreenPicturePath.FileName);
                    //UploadScreenPicturePath.PostedFile.SaveAs(Server.MapPath(".") + "/Admin/images" + image3);
                    //string path3 = "~/Admin/images/" + image3.ToString();

                }
                insert.SCREEN_PATH = ExtSCREEN_PATH;
                //if (UploadScreenPicturePath.HasFile)
                //{
                //    string image3 = UploadScreenPicturePath.FileName;
                //    UploadScreenPicturePath.PostedFile.SaveAs(Server.MapPath(".") + "/Admin/images" + image3);
                //    string path3 = "~/Admin/images/" + image3.ToString();
                //    insert.SCREEN_PATH = path3.ToString();
                //}
                //else
                //{
                //    insert.SCREEN_PATH = "";
                //}

                if (Chk_SignLogoFlag.Checked == true)
                {
                    insert.SIGN_LOGO_FLAG = "Y";

                }
                else
                {
                    insert.SIGN_LOGO_FLAG = "N";
                }

                insert.SST_NO = TxtVatTinNo.Text.Trim().ToUpper();
                insert.STATE = DdlStateName.SelectedItem.ToString().ToUpper();
                insert.STATE_NO = TxtStateCode.Text.Trim().ToUpper();
                insert.STAX_NO = TxtServiceTaxNo.Text.Trim().ToUpper();
                insert.STOCK_VIEWFLAG = DdlStockViewFlag.SelectedValue.Trim().ToUpper();
                insert.TERMS_CONDITION = TxtTermsCondition_VAT.Text.Trim().ToUpper();
                insert.TERMS_CONDITION_GST = TxtTermsCondition_GST.Text.Trim().ToUpper();
                insert.UPD_DATETIME = string.Empty;
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.WORK_VIEWFLAG = DdlStokWorkingFlag.SelectedValue.Trim().ToUpper();
                insert.YR_END = Convert.ToDateTime(TxtYR_END.Text.Trim()).ToString("MM-dd-yyyy");
                insert.YR_START = Convert.ToDateTime(TxtYR_START.Text.Trim()).ToString("MM-dd-yyyy");

                #endregion

                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = COMPANYLogicLayer.InsertCOMPANYDetials(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "Company Detail Add Successfully.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "Company Code already Exist.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "Error : Company Detail Not Save";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    string str = COMPANYLogicLayer.updateCOMPANYDetials(insert);
                    if (str.Contains("successfully"))
                    {
                        if (UploadScreenPicturePath.HasFile)
                        {
                           
                            UploadScreenPicturePath.PostedFile.SaveAs(Server.MapPath(".") + "/Company/SCREEN/" + hfCOMP_CODE.Value + ExtSCREEN_PATH);
                        }

                        if (UploadInvoiceLogoPath2.HasFile)
                        {
                            UploadInvoiceLogoPath2.PostedFile.SaveAs(Server.MapPath(".") + "/Company/LH2/" + hfCOMP_CODE.Value + ExtLH_PATH2);
                        }

                        if (UploadInvoiceLogoPath1.HasFile)
                        {
                            UploadInvoiceLogoPath1.PostedFile.SaveAs(Server.MapPath(".") + "/Company/LH/" + hfCOMP_CODE.Value + ExtLH_PATH);
                        }

                        if (UploadSignaturePath.HasFile)
                        {
                            ((FileUpload)Session["UploadSignaturePath"]).PostedFile.SaveAs(Server.MapPath(".") + "/Company/BKP/" + hfCOMP_CODE.Value + ExtBKP);
                            //UploadSignaturePath.PostedFile.SaveAs(Server.MapPath(".") + "/Company/BKP/" + hfCOMP_CODE.Value + ExtBKP);
                        }

                        lblmsg.Text = "Company Detail Update Successfully.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already"))
                    {
                        lblmsg.Text = "Company Code already Exist.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "Error : Company Detail Not Update";
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
                Dt = COMPANYLogicLayer.GetAllCOMPANYDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                GvCompany.DataSource = Dt;
                GvCompany.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void GvCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region EDIT
                    clear();
                    DataTable dt = COMPANYLogicLayer.GetAllIDWiseCOMPANYDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;
                        //TxtCompanyCode.Text = dt.Rows[0]["COMP_CODE"].ToString();
                        ImgSignaturePath.ImageUrl = "~/Admin/Company/BKP/" + dt.Rows[0]["BKP_PATH_String"].ToString();
                        ImgScreenPicturePath.ImageUrl = "~/Admin/Company/SCREEN/" + dt.Rows[0]["SCREEN_PATH_String"].ToString();
                        ImgInvoiceLogoPath1.ImageUrl = "~/Admin/Company/LH/" + dt.Rows[0]["LH_PATH_String"].ToString();
                        ImgInvoiceLogoPath2.ImageUrl = "~/Admin/Company/LH2/" + dt.Rows[0]["LH_PATH2_String"].ToString();
                        hfCOMP_CODE.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        DdlCompanyType.SelectedValue = dt.Rows[0]["COMP_TYPE"].ToString();
                        TxtCompanyName.Text = dt.Rows[0]["NAME"].ToString();
                        TxtShort.Text = dt.Rows[0]["SHORT"].ToString();
                        DdlStockType.SelectedValue = dt.Rows[0]["STOCK_TYPE"].ToString();
                        TxtYR_END.Text = Convert.ToDateTime(dt.Rows[0]["YR_END"].ToString()).ToString("dd-MM-yyyy");
                        TxtYR_START.Text = Convert.ToDateTime(dt.Rows[0]["YR_START"].ToString()).ToString("dd-MM-yyyy");
                        hfCOMP_CODE.Value = e.CommandArgument.ToString();
                        TxtADD1.Text = dt.Rows[0]["ADD1"].ToString();
                        TxtADD2.Text = dt.Rows[0]["ADD2"].ToString();
                        TxtADD3.Text = dt.Rows[0]["ADD3"].ToString();
                        TxtCity.Text = dt.Rows[0]["CITY"].ToString();
                        TxtPlace.Text = dt.Rows[0]["PLACE"].ToString();
                        TxtDistrict.Text = dt.Rows[0]["DISTRICT"].ToString();

                        FillDdlState();
                        DdlStateName.SelectedValue = dt.Rows[0]["STATE_NO"].ToString();
                        getstateno();
                    //    TxtStateCode.Text = dt.Rows[0]["STATE_NO"].ToString();
                        TxtCountry.Text = dt.Rows[0]["COUNTRY"].ToString();
                        TxtPhone.Text = dt.Rows[0]["PHONE"].ToString();
                        TxtFax.Text = dt.Rows[0]["FAX"].ToString();
                        TxtEmailAddress.Text = dt.Rows[0]["EMAIL"].ToString();
                        TxtAutoEmailAddress.Text = dt.Rows[0]["AUTO_MAILID"].ToString();
                        TxtBankName.Text = dt.Rows[0]["BANK_NAME"].ToString();
                        TxtBranchName.Text = dt.Rows[0]["BANK_BNAME"].ToString();
                        TxtIFSC.Text = dt.Rows[0]["BANK_IFSCCODE"].ToString();
                        TxtBankAccNo.Text = dt.Rows[0]["BANK_ACCNO"].ToString();
                        TxtAuthorisedPerson.Text = dt.Rows[0]["AUTH_PERSON"].ToString();
                        TxtGODTitle.Text = dt.Rows[0]["GOD_TITLE"].ToString();
                        TxtProductDesc.Text = dt.Rows[0]["PRODUCT_DESC"].ToString();
                        TxtGSTNo.Text = dt.Rows[0]["GST_NO"].ToString();
                        TxtVatTinNo.Text = dt.Rows[0]["SST_NO"].ToString();
                        TxtVatCstNo.Text = dt.Rows[0]["CST_NO"].ToString();
                        TxtEccCNo.Text = dt.Rows[0]["REG_NO"].ToString();
                        TxtPanNo.Text = dt.Rows[0]["PAN_NO"].ToString();
                        TxtServiceTaxNo.Text = dt.Rows[0]["STAX_NO"].ToString();
                        DdlStokWorkingFlag.SelectedValue = dt.Rows[0]["WORK_VIEWFLAG"].ToString();
                        DdlAddDisFlag.SelectedValue = dt.Rows[0]["ADD_DISFLAG"].ToString();
                        HfUploadSignaturePath.Value = dt.Rows[0]["BKP_PATH"].ToString();
                        HfUploadScreenPicturePath.Value = dt.Rows[0]["SCREEN_PATH"].ToString();
                        HfUploadInvoiceLogoPath1.Value = dt.Rows[0]["LH_PATH"].ToString();
                        HfUploadInvoiceLogoPath2.Value = dt.Rows[0]["LH_PATH2"].ToString();
                        DdlInvoiceTypeFlag.SelectedValue = dt.Rows[0]["INVTYPE_FLAG"].ToString();
                        DdlStockViewFlag.SelectedValue = dt.Rows[0]["STOCK_VIEWFLAG"].ToString();

                        if (dt.Rows[0]["INV_LOGO_FLAG"].ToString() == "Y")
                        {
                            Chk_InvoiceLogoFlag.Checked = true;

                        }
                        else
                        {
                            Chk_InvoiceLogoFlag.Checked = false;
                        }

                        if (dt.Rows[0]["SIGN_LOGO_FLAG"].ToString() == "Y")
                        {
                            Chk_SignLogoFlag.Checked = true;

                        }
                        else
                        {
                            Chk_SignLogoFlag.Checked = false;
                        }



                    }

                    TxtExciseTitle.Text = dt.Rows[0]["EX_TITLE"].ToString();
                    TxtExciseRange.Text = dt.Rows[0]["EX_RANGE"].ToString();
                    TxtExciseDivision.Text = dt.Rows[0]["EX_DIVISION"].ToString();
                    TxtCommissionerate.Text = dt.Rows[0]["EX_COMMISSIONARATE"].ToString();
                    TxtExciseRateOfDuty.Text = dt.Rows[0]["EX_RATE_OF_DUTY"].ToString();
                    TxtExcisableGood.Text = dt.Rows[0]["EX_NAME_OF_GOODS"].ToString();
                    TxtBasicExciseDuty.Text = dt.Rows[0]["EX_DUTY_PER"].ToString();
                    TxtEduCess.Text = dt.Rows[0]["EX_CESS_PER"].ToString();
                    TxtS_H_EduCess.Text = dt.Rows[0]["EX_SHCESS_PER"].ToString();
                    TxtTermsCondition_VAT.Text = dt.Rows[0]["TERMS_CONDITION"].ToString();
                    TxtTermsCondition_GST.Text = dt.Rows[0]["TERMS_CONDITION_GST"].ToString();
                    TxtQuotationSubject.Text = dt.Rows[0]["QUO_SUB1"].ToString();
                    TxtBranchName.Text = dt.Rows[0]["QUO_BRAND_NAME"].ToString();
                    TxtQuotationFor.Text = dt.Rows[0]["QUO_SUB2"].ToString();
                    TxtQuotationModelNo.Text = dt.Rows[0]["QUO_MODEL_NAME"].ToString();
                    TxtQuotationNote.Text = dt.Rows[0]["QUO_NOTE"].ToString();
                    TxtRangeAdd.Text = dt.Rows[0]["EX_RANGE_ADD"].ToString();
                    TxtDivisionAdd.Text = dt.Rows[0]["EX_DIV_ADD"].ToString();
                    TxtCommisionerateAdd.Text = dt.Rows[0]["EX_COMM_ADD"].ToString();
                    TxtCertificateTitle1.Text = dt.Rows[0]["EX_TITLE1"].ToString();
                    TxtCertificateTitle2.Text = dt.Rows[0]["EX_TITLE2"].ToString();
                    TxtCETSHTitle1.Text = dt.Rows[0]["EX_CETH_TITLE"].ToString();
                    TxtCETSHTitle2.Text = dt.Rows[0]["EX_CETH_TITLE2"].ToString();
                    TxtCETSHTitle3.Text = dt.Rows[0]["EX_CETH_TITLE3"].ToString();
                    TxtCETSH1.Text = dt.Rows[0]["EX_CETH"].ToString();
                    TxtCETSH2.Text = dt.Rows[0]["EX_CETH2"].ToString();
                    TxtCETSH3.Text = dt.Rows[0]["EX_CETH3"].ToString();


                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    calldel.Visible = true;
                    BtncallUpd.Visible = false;
                    HtmlButton();
                    ControllersDisable();
                    #endregion
                }

                if (e.CommandName == "Edita")
                {
                    #region EDIT
                    clear();
                    DataTable dt = COMPANYLogicLayer.GetAllIDWiseCOMPANYDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;
                        //TxtCompanyCode.Text = dt.Rows[0]["COMP_CODE"].ToString();

                        ImgSignaturePath.ImageUrl ="~/Admin/Company/BKP/"+ dt.Rows[0]["BKP_PATH_String"].ToString();
                        ImgScreenPicturePath.ImageUrl= "~/Admin/Company/SCREEN/"  + dt.Rows[0]["SCREEN_PATH_String"].ToString();
                        ImgInvoiceLogoPath1.ImageUrl= "~/Admin/Company/LH/"  + dt.Rows[0]["LH_PATH_String"].ToString();
                        ImgInvoiceLogoPath2.ImageUrl= "~/Admin/Company/LH2/" + dt.Rows[0]["LH_PATH2_String"].ToString();
                        hfCOMP_CODE.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        DdlCompanyType.SelectedValue = dt.Rows[0]["COMP_TYPE"].ToString();
                        TxtCompanyName.Text = dt.Rows[0]["NAME"].ToString();
                        TxtShort.Text = dt.Rows[0]["SHORT"].ToString();
                        DdlStockType.SelectedValue = dt.Rows[0]["STOCK_TYPE"].ToString();
                        TxtYR_END.Text = Convert.ToDateTime(dt.Rows[0]["YR_END"].ToString()).ToString("dd-MM-yyyy");
                        TxtYR_START.Text = Convert.ToDateTime(dt.Rows[0]["YR_START"].ToString()).ToString("dd-MM-yyyy");
                        hfCOMP_CODE.Value = e.CommandArgument.ToString();
                        TxtADD1.Text = dt.Rows[0]["ADD1"].ToString();
                        TxtADD2.Text = dt.Rows[0]["ADD2"].ToString();
                        TxtADD3.Text = dt.Rows[0]["ADD3"].ToString();
                        TxtCity.Text = dt.Rows[0]["CITY"].ToString();
                        TxtPlace.Text = dt.Rows[0]["PLACE"].ToString();
                        TxtDistrict.Text = dt.Rows[0]["DISTRICT"].ToString();

                        FillDdlState();
                        DdlStateName.SelectedValue = dt.Rows[0]["STATE_NO"].ToString();
                        getstateno();
                        // TxtStateCode.Text = dt.Rows[0]["STATE_NO"].ToString();
                        TxtCountry.Text = dt.Rows[0]["COUNTRY"].ToString();
                        TxtPhone.Text = dt.Rows[0]["PHONE"].ToString();
                        TxtFax.Text = dt.Rows[0]["FAX"].ToString();
                        TxtEmailAddress.Text = dt.Rows[0]["EMAIL"].ToString();
                        TxtAutoEmailAddress.Text = dt.Rows[0]["AUTO_MAILID"].ToString();
                        TxtBankName.Text = dt.Rows[0]["BANK_NAME"].ToString();
                        TxtBranchName.Text = dt.Rows[0]["BANK_BNAME"].ToString();
                        TxtIFSC.Text = dt.Rows[0]["BANK_IFSCCODE"].ToString();
                        TxtBankAccNo.Text = dt.Rows[0]["BANK_ACCNO"].ToString();
                        TxtAuthorisedPerson.Text = dt.Rows[0]["AUTH_PERSON"].ToString();
                        TxtGODTitle.Text = dt.Rows[0]["GOD_TITLE"].ToString();
                        TxtProductDesc.Text = dt.Rows[0]["PRODUCT_DESC"].ToString();
                        TxtGSTNo.Text = dt.Rows[0]["GST_NO"].ToString();
                        TxtVatTinNo.Text = dt.Rows[0]["SST_NO"].ToString();
                        TxtVatCstNo.Text = dt.Rows[0]["CST_NO"].ToString();
                        TxtEccCNo.Text = dt.Rows[0]["REG_NO"].ToString();
                        TxtPanNo.Text = dt.Rows[0]["PAN_NO"].ToString();
                        TxtServiceTaxNo.Text = dt.Rows[0]["STAX_NO"].ToString();
                        DdlStokWorkingFlag.SelectedValue = dt.Rows[0]["WORK_VIEWFLAG"].ToString();
                        DdlAddDisFlag.SelectedValue = dt.Rows[0]["ADD_DISFLAG"].ToString();
                        HfUploadSignaturePath.Value = dt.Rows[0]["BKP_PATH"].ToString();
                        HfUploadScreenPicturePath.Value = dt.Rows[0]["SCREEN_PATH"].ToString();
                        HfUploadInvoiceLogoPath1.Value = dt.Rows[0]["LH_PATH"].ToString();
                        HfUploadInvoiceLogoPath2.Value = dt.Rows[0]["LH_PATH2"].ToString();
                        DdlInvoiceTypeFlag.SelectedValue = dt.Rows[0]["INVTYPE_FLAG"].ToString();
                        DdlStockViewFlag.SelectedValue = dt.Rows[0]["STOCK_VIEWFLAG"].ToString();

                        if (dt.Rows[0]["INV_LOGO_FLAG"].ToString() == "Y")
                        {
                            Chk_InvoiceLogoFlag.Checked = true;

                        }
                        else
                        {
                            Chk_InvoiceLogoFlag.Checked = false;
                        }

                        if (dt.Rows[0]["SIGN_LOGO_FLAG"].ToString() == "Y")
                        {
                            Chk_SignLogoFlag.Checked = true;

                        }
                        else
                        {
                            Chk_SignLogoFlag.Checked = false;
                        }



                    }

                    TxtExciseTitle.Text = dt.Rows[0]["EX_TITLE"].ToString();
                    TxtExciseRange.Text = dt.Rows[0]["EX_RANGE"].ToString();
                    TxtExciseDivision.Text = dt.Rows[0]["EX_DIVISION"].ToString();
                    TxtCommissionerate.Text = dt.Rows[0]["EX_COMMISSIONARATE"].ToString();
                    TxtExciseRateOfDuty.Text = dt.Rows[0]["EX_RATE_OF_DUTY"].ToString();
                    TxtExcisableGood.Text = dt.Rows[0]["EX_NAME_OF_GOODS"].ToString();
                    TxtBasicExciseDuty.Text = dt.Rows[0]["EX_DUTY_PER"].ToString();
                    TxtEduCess.Text = dt.Rows[0]["EX_CESS_PER"].ToString();
                    TxtS_H_EduCess.Text = dt.Rows[0]["EX_SHCESS_PER"].ToString();
                    TxtTermsCondition_VAT.Text = dt.Rows[0]["TERMS_CONDITION"].ToString();
                    TxtTermsCondition_GST.Text = dt.Rows[0]["TERMS_CONDITION_GST"].ToString();
                    TxtQuotationSubject.Text = dt.Rows[0]["QUO_SUB1"].ToString();
                    TxtBranchName.Text = dt.Rows[0]["QUO_BRAND_NAME"].ToString();
                    TxtQuotationFor.Text = dt.Rows[0]["QUO_SUB2"].ToString();
                    TxtQuotationModelNo.Text = dt.Rows[0]["QUO_MODEL_NAME"].ToString();
                    TxtQuotationNote.Text = dt.Rows[0]["QUO_NOTE"].ToString();
                    TxtRangeAdd.Text = dt.Rows[0]["EX_RANGE_ADD"].ToString();
                    TxtDivisionAdd.Text = dt.Rows[0]["EX_DIV_ADD"].ToString();
                    TxtCommisionerateAdd.Text = dt.Rows[0]["EX_COMM_ADD"].ToString();
                    TxtCertificateTitle1.Text = dt.Rows[0]["EX_TITLE1"].ToString();
                    TxtCertificateTitle2.Text = dt.Rows[0]["EX_TITLE2"].ToString();
                    TxtCETSHTitle1.Text = dt.Rows[0]["EX_CETH_TITLE"].ToString();
                    TxtCETSHTitle2.Text = dt.Rows[0]["EX_CETH_TITLE2"].ToString();
                    TxtCETSHTitle3.Text = dt.Rows[0]["EX_CETH_TITLE3"].ToString();
                    TxtCETSH1.Text = dt.Rows[0]["EX_CETH"].ToString();
                    TxtCETSH2.Text = dt.Rows[0]["EX_CETH2"].ToString();
                    TxtCETSH3.Text = dt.Rows[0]["EX_CETH3"].ToString();

                    BtncallUpd.Text = "UPDATE";
                    //btnSave.Text = "UPDATE";
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
                            ControllersDisable();
                        }
                    }
                    #endregion
                    btnSave.Visible = true;
                    UserRights();
                    calldel.Visible = false;
                    BtncallUpd.Visible = true;
                    HtmlButton();
                }

                if (e.CommandName == "Viewa")
                {

                    #region SET TEXT ON VIEW
                    clear();

                    DataTable dt = COMPANYLogicLayer.GetAllIDWiseCOMPANYDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;
                        //TxtCompanyCode.Text = dt.Rows[0]["COMP_CODE"].ToString();
                        ImgSignaturePath.ImageUrl = "~/Admin/Company/BKP/" + dt.Rows[0]["BKP_PATH_String"].ToString();
                        ImgScreenPicturePath.ImageUrl = "~/Admin/Company/SCREEN/" + dt.Rows[0]["SCREEN_PATH_String"].ToString();
                        ImgInvoiceLogoPath1.ImageUrl = "~/Admin/Company/LH/" + dt.Rows[0]["LH_PATH_String"].ToString();
                        ImgInvoiceLogoPath2.ImageUrl = "~/Admin/Company/LH2/" + dt.Rows[0]["LH_PATH2_String"].ToString();
                        hfCOMP_CODE.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        DdlCompanyType.SelectedValue = dt.Rows[0]["COMP_TYPE"].ToString();
                        TxtCompanyName.Text = dt.Rows[0]["NAME"].ToString();
                        TxtShort.Text = dt.Rows[0]["SHORT"].ToString();
                        DdlStockType.SelectedValue = dt.Rows[0]["STOCK_TYPE"].ToString();
                        TxtYR_END.Text = Convert.ToDateTime(dt.Rows[0]["YR_END"].ToString()).ToString("dd-MM-yyyy");
                        TxtYR_START.Text = Convert.ToDateTime(dt.Rows[0]["YR_START"].ToString()).ToString("dd-MM-yyyy");
                        hfCOMP_CODE.Value = e.CommandArgument.ToString();
                        TxtADD1.Text = dt.Rows[0]["ADD1"].ToString();
                        TxtADD2.Text = dt.Rows[0]["ADD2"].ToString();
                        TxtADD3.Text = dt.Rows[0]["ADD3"].ToString();
                        TxtCity.Text = dt.Rows[0]["CITY"].ToString();
                        TxtPlace.Text = dt.Rows[0]["PLACE"].ToString();
                        TxtDistrict.Text = dt.Rows[0]["DISTRICT"].ToString();

                        FillDdlState();
                        DdlStateName.SelectedValue = dt.Rows[0]["STATE_NO"].ToString();
                        getstateno();
                        //   TxtStateCode.Text = dt.Rows[0]["STATE_NO"].ToString();
                        TxtCountry.Text = dt.Rows[0]["COUNTRY"].ToString();
                        TxtPhone.Text = dt.Rows[0]["PHONE"].ToString();
                        TxtFax.Text = dt.Rows[0]["FAX"].ToString();
                        TxtEmailAddress.Text = dt.Rows[0]["EMAIL"].ToString();
                        TxtAutoEmailAddress.Text = dt.Rows[0]["AUTO_MAILID"].ToString();
                        TxtBankName.Text = dt.Rows[0]["BANK_NAME"].ToString();
                        TxtBranchName.Text = dt.Rows[0]["BANK_BNAME"].ToString();
                        TxtIFSC.Text = dt.Rows[0]["BANK_IFSCCODE"].ToString();
                        TxtBankAccNo.Text = dt.Rows[0]["BANK_ACCNO"].ToString();
                        TxtAuthorisedPerson.Text = dt.Rows[0]["AUTH_PERSON"].ToString();
                        TxtGODTitle.Text = dt.Rows[0]["GOD_TITLE"].ToString();
                        TxtProductDesc.Text = dt.Rows[0]["PRODUCT_DESC"].ToString();
                        TxtGSTNo.Text = dt.Rows[0]["GST_NO"].ToString();
                        TxtVatTinNo.Text = dt.Rows[0]["SST_NO"].ToString();
                        TxtVatCstNo.Text = dt.Rows[0]["CST_NO"].ToString();
                        TxtEccCNo.Text = dt.Rows[0]["REG_NO"].ToString();
                        TxtPanNo.Text = dt.Rows[0]["PAN_NO"].ToString();
                        TxtServiceTaxNo.Text = dt.Rows[0]["STAX_NO"].ToString();
                        DdlStokWorkingFlag.SelectedValue = dt.Rows[0]["WORK_VIEWFLAG"].ToString();
                        DdlAddDisFlag.SelectedValue = dt.Rows[0]["ADD_DISFLAG"].ToString();
                        //      UploadSignaturePath.Text = dt.Rows[0]["BKP_PATH"].ToString();
                        //      TxtScreenPicturePath.Text = dt.Rows[0]["SCREEN_PATH"].ToString();
                        //       UploadInvoiceLogoPath1.Attributes = dt.Rows[0]["LH_PATH"].ToString();
                        //    TxtInvoiceLogoPath2.Text = dt.Rows[0]["LH_PATH2"].ToString();
                        DdlInvoiceTypeFlag.SelectedValue = dt.Rows[0]["INVTYPE_FLAG"].ToString();
                        DdlStockViewFlag.SelectedValue = dt.Rows[0]["STOCK_VIEWFLAG"].ToString();

                        if (dt.Rows[0]["INV_LOGO_FLAG"].ToString() == "Y")
                        {
                            Chk_InvoiceLogoFlag.Checked = true;

                        }
                        else
                        {
                            Chk_InvoiceLogoFlag.Checked = false;
                        }

                        if (dt.Rows[0]["SIGN_LOGO_FLAG"].ToString() == "Y")
                        {
                            Chk_SignLogoFlag.Checked = true;

                        }
                        else
                        {
                            Chk_SignLogoFlag.Checked = false;
                        }



                    }

                    TxtExciseTitle.Text = dt.Rows[0]["EX_TITLE"].ToString();
                    TxtExciseRange.Text = dt.Rows[0]["EX_RANGE"].ToString();
                    TxtExciseDivision.Text = dt.Rows[0]["EX_DIVISION"].ToString();
                    TxtCommissionerate.Text = dt.Rows[0]["EX_COMMISSIONARATE"].ToString();
                    TxtExciseRateOfDuty.Text = dt.Rows[0]["EX_RATE_OF_DUTY"].ToString();
                    TxtExcisableGood.Text = dt.Rows[0]["EX_NAME_OF_GOODS"].ToString();
                    TxtBasicExciseDuty.Text = dt.Rows[0]["EX_DUTY_PER"].ToString();
                    TxtEduCess.Text = dt.Rows[0]["EX_CESS_PER"].ToString();
                    TxtS_H_EduCess.Text = dt.Rows[0]["EX_SHCESS_PER"].ToString();
                    TxtTermsCondition_VAT.Text = dt.Rows[0]["TERMS_CONDITION"].ToString();
                    TxtTermsCondition_GST.Text = dt.Rows[0]["TERMS_CONDITION_GST"].ToString();
                    TxtQuotationSubject.Text = dt.Rows[0]["QUO_SUB1"].ToString();
                    TxtBranchName.Text = dt.Rows[0]["QUO_BRAND_NAME"].ToString();
                    TxtQuotationFor.Text = dt.Rows[0]["QUO_SUB2"].ToString();
                    TxtQuotationModelNo.Text = dt.Rows[0]["QUO_MODEL_NAME"].ToString();
                    TxtQuotationNote.Text = dt.Rows[0]["QUO_NOTE"].ToString();
                    TxtRangeAdd.Text = dt.Rows[0]["EX_RANGE_ADD"].ToString();
                    TxtDivisionAdd.Text = dt.Rows[0]["EX_DIV_ADD"].ToString();
                    TxtCommisionerateAdd.Text = dt.Rows[0]["EX_COMM_ADD"].ToString();
                    TxtCertificateTitle1.Text = dt.Rows[0]["EX_TITLE1"].ToString();
                    TxtCertificateTitle2.Text = dt.Rows[0]["EX_TITLE2"].ToString();
                    TxtCETSHTitle1.Text = dt.Rows[0]["EX_CETH_TITLE"].ToString();
                    TxtCETSHTitle2.Text = dt.Rows[0]["EX_CETH_TITLE2"].ToString();
                    TxtCETSHTitle3.Text = dt.Rows[0]["EX_CETH_TITLE3"].ToString();
                    TxtCETSH1.Text = dt.Rows[0]["EX_CETH"].ToString();
                    TxtCETSH2.Text = dt.Rows[0]["EX_CETH2"].ToString();
                    TxtCETSH3.Text = dt.Rows[0]["EX_CETH3"].ToString();
                    #endregion

                    ControllersDisable();
                    btnSave.Visible = false;
                    UserRights();
                    calldel.Visible = false;
                    BtncallUpd.Visible = false;
                    HtmlButton();
                    //   btnDelete.Visible = true;
                    //  btnSave.Text = "UPDATE";



                }
            }

            catch (Exception ex)
            {

                lblmsg.Text = ex.Message.ToString();
            }


        }


        protected void GvCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvCompany.PageIndex = e.NewPageIndex;
                FillGrid();
                clear();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnBranchMaster_click(object sender, EventArgs e)
        {

        }

        protected void btnViewAllExcise_click(object sender, EventArgs e)
        {

        }

        protected void BtnAdd_OnClick(object sender, EventArgs e)
        {
            try
            {
                clear();
                ControllerEnable();
                UserRights();
                BtncallUpd.Visible = true;
                btnSave.Enabled = true;
                btnSave.Visible = true;
                DivEntry.Visible = true;
                DivView.Visible = false;

            }
            catch (Exception)
            {

            }

        }



        protected void btnDelete_click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE  - MIHIR LAD 04-10-2018
                if (hfCOMP_CODE.Value != string.Empty)
                {
                    string str = COMPANYLogicLayer.DeleteCOMPANYDetailsByID(hfCOMP_CODE.Value);
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
                        lblmsg.Text = "Error:Company Not Deleted";
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

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }

        protected void calldel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);

        }

        protected void BtncallUpd_Click(object sender, EventArgs e)
        {
            if (BtncallUpd.Text == "UPDATE")
            {
                if (UploadScreenPicturePath.HasFile)
                {
                    Session["UploadScreenPicturePath"] = UploadScreenPicturePath;
                }
                else
                {
                    Session["UploadScreenPicturePath"] = null;
                }

                if (UploadInvoiceLogoPath2.HasFile)
                {
                    Session["UploadInvoiceLogoPath2"] = UploadInvoiceLogoPath2;
                }
                else
                {
                    Session["UploadInvoiceLogoPath2"] = null;
                }

                if (UploadInvoiceLogoPath1.HasFile)
                {
                    Session["UploadInvoiceLogoPath1"] = UploadInvoiceLogoPath1;
                }
                else
                {
                    Session["UploadInvoiceLogoPath1"] = null;
                }

                if (UploadSignaturePath.HasFile)
                {
                    Session["UploadSignaturePath"] = UploadSignaturePath;
                }
                else
                {
                    Session["UploadSignaturePath"] = null;
                }


                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel1", "ShowModel1()", true);
            }
            else
            {

                COMPANYLogicLayer insert = new COMPANYLogicLayer();
                insert.COMP_CODE = hfCOMP_CODE.Value.Trim();
                insert.COMP_TYPE = DdlCompanyType.SelectedValue.Trim().ToUpper();
                insert.NAME = TxtCompanyName.Text.Trim().ToUpper();
                insert.SHORT = TxtShort.Text.Trim().ToUpper();
                insert.STOCK_TYPE = DdlStockType.SelectedValue.Trim().ToUpper();
                insert.ADD1 = TxtADD1.Text.Trim().ToUpper();
                insert.ADD2 = TxtADD2.Text.Trim().ToUpper();
                insert.ADD3 = TxtADD3.Text.Trim().ToUpper();
                insert.ADD_DISFLAG = DdlAddDisFlag.SelectedValue.Trim().ToUpper();
                insert.AUTH_PERSON = TxtAuthorisedPerson.Text.Trim().ToUpper();
                insert.AUTO_MAILID = TxtAutoEmailAddress.Text.Trim();
                insert.BANK_ACCNO = TxtBankAccNo.Text.Trim().Trim().ToUpper();
                insert.BANK_BNAME = TxtBranchName.Text.Trim().ToUpper();
                insert.BANK_IFSCCODE = TxtIFSC.Text.Trim().ToUpper();
                insert.BANK_NAME = TxtBankName.Text.Trim().ToUpper();

                string ExtBKP = "";
                if (UploadSignaturePath.HasFile)
                {
                    string image = UploadSignaturePath.FileName;
                    ExtBKP = Path.GetExtension(UploadSignaturePath.FileName);
                    //UploadInvoiceLogoPath1.PostedFile.SaveAs(Server.MapPath(".") + "/Admin/images/" + image);
                    //string path = "~/Admin/images/" + image.ToString();
                }
                insert.BKP_PATH = ExtBKP;

                insert.CITY = TxtCity.Text.Trim().ToUpper();
                insert.COUNTRY = TxtCountry.Text.Trim().ToUpper();
                insert.CST_NO = TxtVatCstNo.Text.Trim().ToUpper();
                insert.DISTRICT = TxtDistrict.Text.Trim().ToUpper();
                insert.EMAIL = TxtEmailAddress.Text.Trim();
                if (TxtEduCess.Text == string.Empty)
                {
                    insert.EX_CESS_PER = "0";
                }
                else
                {
                    insert.EX_CESS_PER = TxtEduCess.Text.Trim();
                }
                insert.EX_CETH = TxtCETSH1.Text.Trim().ToUpper();
                insert.EX_CETH2 = TxtCETSH2.Text.Trim().ToUpper();
                insert.EX_CETH3 = TxtCETSH3.Text.Trim().ToUpper();
                insert.EX_CETH4 = string.Empty;
                insert.EX_CETH_TITLE = TxtCETSHTitle1.Text.Trim().ToUpper();
                insert.EX_CETH_TITLE2 = TxtCETSHTitle2.Text.Trim().ToUpper();
                insert.EX_CETH_TITLE3 = TxtCETSHTitle3.Text.Trim().ToUpper();
                insert.EX_CETH_TITLE4 = string.Empty;
                insert.EX_COMMISSIONARATE = TxtCommissionerate.Text.Trim().ToUpper();
                insert.EX_COMM_ADD = TxtCommisionerateAdd.Text.Trim().ToUpper();
                insert.EX_DIVISION = TxtExciseDivision.Text.Trim().ToUpper();
                insert.EX_DIV_ADD = TxtDivisionAdd.Text.Trim().ToUpper();
                if (TxtBasicExciseDuty.Text == string.Empty)
                {
                    insert.EX_DUTY_PER = "0";
                }
                else
                {
                    insert.EX_DUTY_PER = TxtBasicExciseDuty.Text.Trim();
                }

                insert.EX_NAME_OF_GOODS = TxtExcisableGood.Text.Trim().ToUpper();
                insert.EX_RANGE = TxtExciseRange.Text.Trim().ToUpper();
                insert.EX_RANGE_ADD = TxtRangeAdd.Text.Trim().ToUpper();
                insert.EX_RATE_OF_DUTY = TxtExciseRateOfDuty.Text.Trim().ToUpper();
                if (TxtS_H_EduCess.Text == string.Empty)
                {
                    insert.EX_SHCESS_PER = "0";
                }
                else
                {
                    insert.EX_SHCESS_PER = TxtS_H_EduCess.Text.Trim();
                }

                insert.EX_TITLE = TxtExciseTitle.Text.Trim().ToUpper();
                insert.EX_TITLE1 = TxtCertificateTitle1.Text.Trim().ToUpper();
                insert.EX_TITLE2 = TxtCertificateTitle2.Text.Trim().ToUpper();
                insert.FAX = TxtFax.Text.Trim().ToUpper();
                insert.GOD_TITLE = TxtGODTitle.Text.Trim().ToUpper();
                insert.GST_NO = TxtGSTNo.Text.Trim().ToUpper();
                insert.INS_DATETIME = string.Empty;
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INVTYPE_FLAG = DdlInvoiceTypeFlag.SelectedValue.Trim().ToUpper();
                if (Chk_InvoiceLogoFlag.Checked == true)
                {
                    insert.INV_LOGO_FLAG = "Y";
                }
                else
                {
                    insert.INV_LOGO_FLAG = "N";
                }

                string ExtLH_PATH = "";
                if (UploadInvoiceLogoPath1.HasFile)
                {
                    string image1 = UploadInvoiceLogoPath1.FileName;
                    ExtLH_PATH = Path.GetExtension(UploadInvoiceLogoPath1.FileName);
                    //UploadInvoiceLogoPath1.PostedFile.SaveAs(Server.MapPath(".") + "/Admin/images/" + image1);
                    //string path1 = "~/Admin/images/" + image1.ToString();
                }
                insert.LH_PATH = ExtLH_PATH;

                string ExtLH_PATH2 = "";
                if (UploadInvoiceLogoPath2.HasFile)
                {
                    string image2 = UploadInvoiceLogoPath2.FileName;
                    ExtLH_PATH2 = Path.GetExtension(UploadInvoiceLogoPath2.FileName);
                    //UploadInvoiceLogoPath2.PostedFile.SaveAs(Server.MapPath(".") + "/Admin/images" + image2);
                    //string path2 = "~/Admin/images/" + image2.ToString();

                }
                insert.LH_PATH2 = ExtLH_PATH2;

                insert.PAN_NO = TxtPanNo.Text.Trim().ToUpper();
                insert.PHONE = TxtPhone.Text.Trim().ToUpper();
                insert.PLACE = TxtPlace.Text.Trim().ToUpper();
                insert.PRODUCT_DESC = TxtProductDesc.Text.Trim().ToUpper();
                insert.QUO_BRAND_NAME = TxtQuoatationBrandName.Text.Trim().ToUpper();
                insert.QUO_MODEL_NAME = TxtQuotationModelNo.Text.Trim().ToUpper();
                insert.QUO_NOTE = TxtQuotationNote.Text.Trim().ToUpper();
                insert.QUO_SUB1 = TxtQuotationSubject.Text.Trim().ToUpper();
                insert.QUO_SUB2 = TxtQuotationFor.Text.Trim().ToUpper();
                insert.QUO_SUB3 = string.Empty;
                insert.QUO_SUB4 = string.Empty;
                insert.REF_COMP_CODE = "0";
                insert.REG_NO = TxtEccCNo.Text.Trim().ToUpper();
                string ExtSCREEN_PATH = "";
                if (UploadScreenPicturePath.HasFile)
                {
                    string image3 = UploadScreenPicturePath.FileName;
                    ExtSCREEN_PATH = Path.GetExtension(UploadScreenPicturePath.FileName);
                    //UploadScreenPicturePath.PostedFile.SaveAs(Server.MapPath(".") + "/Admin/images" + image3);
                    //string path3 = "~/Admin/images/" + image3.ToString();

                }
                insert.SCREEN_PATH = ExtSCREEN_PATH;


                if (Chk_SignLogoFlag.Checked == true)
                {
                    insert.SIGN_LOGO_FLAG = "Y";

                }
                else
                {
                    insert.SIGN_LOGO_FLAG = "N";
                }

                insert.SST_NO = TxtVatTinNo.Text.Trim().ToUpper();
                insert.STATE = DdlStateName.SelectedItem.ToString().ToUpper();
                insert.STATE_NO = TxtStateCode.Text.Trim().ToUpper();
                insert.STAX_NO = TxtServiceTaxNo.Text.Trim().ToUpper();
                insert.STOCK_VIEWFLAG = DdlStockViewFlag.SelectedValue.Trim().ToUpper();
                insert.TERMS_CONDITION = TxtTermsCondition_VAT.Text.Trim().ToUpper();
                insert.TERMS_CONDITION_GST = TxtTermsCondition_GST.Text.Trim().ToUpper();
                insert.UPD_DATETIME = string.Empty;
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.WORK_VIEWFLAG = DdlStokWorkingFlag.SelectedValue.Trim().ToUpper();
                insert.YR_END = Convert.ToDateTime(TxtYR_END.Text.Trim()).ToString("MM-dd-yyyy");
                insert.YR_START = Convert.ToDateTime(TxtYR_START.Text.Trim()).ToString("MM-dd-yyyy");


                if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = COMPANYLogicLayer.InsertCOMPANYDetials(insert);
                    if (str.Length <= 8)
                    {
                        if (UploadScreenPicturePath.HasFile)
                        {
                            UploadScreenPicturePath.PostedFile.SaveAs(Server.MapPath(".") + "/Company/SCREEN/" + str + ExtSCREEN_PATH);
                        }

                        if (UploadInvoiceLogoPath2.HasFile)
                        {
                            UploadInvoiceLogoPath2.PostedFile.SaveAs(Server.MapPath(".") + "/Company/LH2/" + str + ExtLH_PATH2);
                        }

                        if (UploadInvoiceLogoPath1.HasFile)
                        {
                            UploadInvoiceLogoPath1.PostedFile.SaveAs(Server.MapPath(".") + "/Company/LH/" + str + ExtLH_PATH);
                        }

                        if (UploadSignaturePath.HasFile)
                        {
                            UploadSignaturePath.PostedFile.SaveAs(Server.MapPath(".") + "/Company/BKP/" + str + ExtBKP);
                        }
                        lblmsg.Text = "Company Detail Add Successfully.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "Company Code already Exist.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "Error : Company Detail Not Save";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
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

        protected void TxtYR_START_TextChanged(object sender, EventArgs e)
        {
            //DateTime add_Months = Convert.ToDateTime(TxtYR_START.Text).AddMonths(12);
            DateTime add_Months = Convert.ToDateTime(TxtYR_START.Text).AddDays(364);
            TxtYR_END.Text = add_Months.ToString("dd/MM/yyyy");
        }
    }
}
