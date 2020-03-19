using System;
using System.Data;
using Veera.DataLayer;

namespace Veera.LogicLayer

{

    class LogicLayer
    {

    }



    public class COMPANYLogicLayer

    {

        string _COMP_CODE, _NAME, _SHORT, _COMP_TYPE, _STOCK_TYPE, _ADD1, _ADD2, _ADD3, _CITY, _AUTH_PERSON, _PHONE, _FAX, _EMAIL, _YR_START, _YR_END, _SST_NO, _CST_NO, _REG_NO, _INV_LOGO_FLAG, _SIGN_LOGO_FLAG, _PRODUCT_DESC, _GOD_TITLE, _EX_TITLE, _EX_RANGE, _EX_DIVISION, _EX_COMMISSIONARATE, _EX_RATE_OF_DUTY, _EX_NAME_OF_GOODS, _EX_CETH, _EX_TITLE1, _EX_TITLE2, _TERMS_CONDITION, _PLACE, _DISTRICT, _STATE, _COUNTRY, _LH_PATH, _BKP_PATH, _INVTYPE_FLAG, _PAN_NO, _EX_CETH_TITLE, _EX_CETH2, _EX_CETH_TITLE2, _EX_CETH3, _EX_CETH_TITLE3, _EX_CETH4, _EX_CETH_TITLE4, _EX_DUTY_PER, _EX_CESS_PER, _EX_SHCESS_PER, _STOCK_VIEWFLAG, _EX_DIV_ADD, _EX_COMM_ADD, _EX_RANGE_ADD, _BANK_NAME, _BANK_BNAME, _BANK_IFSCCODE, _BANK_ACCNO, _STAX_NO, _WORK_VIEWFLAG, _SCREEN_PATH, _REF_COMP_CODE, _LH_PATH2, _QUO_BRAND_NAME, _QUO_MODEL_NAME, _QUO_SUB1, _QUO_SUB2, _QUO_SUB3, _QUO_SUB4, _QUO_NOTE, _AUTO_MAILID, _GST_NO, _ADD_DISFLAG, _STATE_NO, _TERMS_CONDITION_GST, _INS_USERID, _INS_TERMINAL, _INS_DATETIME, _UPD_USERID, _UPD_TERMINAL, _UPD_DATETIME;

        public COMPANYLogicLayer()
        {
            _COMP_CODE = "  ";
            _NAME = "  ";
            _SHORT = "  ";
            _COMP_TYPE = "  ";
            _STOCK_TYPE = "  ";
            _ADD1 = "  ";
            _ADD2 = "  ";
            _ADD3 = "  ";
            _CITY = "  ";
            _AUTH_PERSON = "  ";
            _PHONE = "  ";
            _FAX = "  ";
            _EMAIL = "  ";
            _YR_START = "  ";
            _YR_END = "  ";
            _SST_NO = "  ";
            _CST_NO = "  ";
            _REG_NO = "  ";
            _INV_LOGO_FLAG = "  ";
            _SIGN_LOGO_FLAG = "  ";
            _PRODUCT_DESC = "  ";
            _GOD_TITLE = "  ";
            _EX_TITLE = "  ";
            _EX_RANGE = "  ";
            _EX_DIVISION = "  ";
            _EX_COMMISSIONARATE = "  ";
            _EX_RATE_OF_DUTY = "  ";
            _EX_NAME_OF_GOODS = "  ";
            _EX_CETH = "  ";
            _EX_TITLE1 = "  ";
            _EX_TITLE2 = "  ";
            _TERMS_CONDITION = "  ";
            _PLACE = "  ";
            _DISTRICT = "  ";
            _STATE = "  ";
            _COUNTRY = "  ";
            _LH_PATH = "  ";
            _BKP_PATH = "  ";
            _INVTYPE_FLAG = "  ";
            _PAN_NO = "  ";
            _EX_CETH_TITLE = "  ";
            _EX_CETH2 = "  ";
            _EX_CETH_TITLE2 = "  ";
            _EX_CETH3 = "  ";
            _EX_CETH_TITLE3 = "  ";
            _EX_CETH4 = "  ";
            _EX_CETH_TITLE4 = "  ";
            _EX_DUTY_PER = "  ";
            _EX_CESS_PER = "  ";
            _EX_SHCESS_PER = "  ";
            _STOCK_VIEWFLAG = "  ";
            _EX_DIV_ADD = "  ";
            _EX_COMM_ADD = "  ";
            _EX_RANGE_ADD = "  ";
            _BANK_NAME = "  ";
            _BANK_BNAME = "  ";
            _BANK_IFSCCODE = "  ";
            _BANK_ACCNO = "  ";
            _STAX_NO = "  ";
            _WORK_VIEWFLAG = "  ";
            _SCREEN_PATH = "  ";
            _REF_COMP_CODE = "  ";
            _LH_PATH2 = "  ";
            _QUO_BRAND_NAME = "  ";
            _QUO_MODEL_NAME = "  ";
            _QUO_SUB1 = "  ";
            _QUO_SUB2 = "  ";
            _QUO_SUB3 = "  ";
            _QUO_SUB4 = "  ";
            _QUO_NOTE = "  ";
            _AUTO_MAILID = "  ";
            _GST_NO = "  ";
            _ADD_DISFLAG = "  ";
            _STATE_NO = "  ";
            _TERMS_CONDITION_GST = "  ";
            _INS_USERID = "  ";
            _INS_TERMINAL = "  ";
            _INS_DATETIME = "  ";
            _UPD_USERID = "  ";
            _UPD_TERMINAL = "  ";
            _UPD_DATETIME = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string NAME { get { return _NAME; } set { _NAME = value; } }
        public string SHORT { get { return _SHORT; } set { _SHORT = value; } }
        public string COMP_TYPE { get { return _COMP_TYPE; } set { _COMP_TYPE = value; } }
        public string STOCK_TYPE { get { return _STOCK_TYPE; } set { _STOCK_TYPE = value; } }
        public string ADD1 { get { return _ADD1; } set { _ADD1 = value; } }
        public string ADD2 { get { return _ADD2; } set { _ADD2 = value; } }
        public string ADD3 { get { return _ADD3; } set { _ADD3 = value; } }
        public string CITY { get { return _CITY; } set { _CITY = value; } }
        public string AUTH_PERSON { get { return _AUTH_PERSON; } set { _AUTH_PERSON = value; } }
        public string PHONE { get { return _PHONE; } set { _PHONE = value; } }
        public string FAX { get { return _FAX; } set { _FAX = value; } }
        public string EMAIL { get { return _EMAIL; } set { _EMAIL = value; } }
        public string YR_START { get { return _YR_START; } set { _YR_START = value; } }
        public string YR_END { get { return _YR_END; } set { _YR_END = value; } }
        public string SST_NO { get { return _SST_NO; } set { _SST_NO = value; } }
        public string CST_NO { get { return _CST_NO; } set { _CST_NO = value; } }
        public string REG_NO { get { return _REG_NO; } set { _REG_NO = value; } }
        public string INV_LOGO_FLAG { get { return _INV_LOGO_FLAG; } set { _INV_LOGO_FLAG = value; } }
        public string SIGN_LOGO_FLAG { get { return _SIGN_LOGO_FLAG; } set { _SIGN_LOGO_FLAG = value; } }
        public string PRODUCT_DESC { get { return _PRODUCT_DESC; } set { _PRODUCT_DESC = value; } }
        public string GOD_TITLE { get { return _GOD_TITLE; } set { _GOD_TITLE = value; } }
        public string EX_TITLE { get { return _EX_TITLE; } set { _EX_TITLE = value; } }
        public string EX_RANGE { get { return _EX_RANGE; } set { _EX_RANGE = value; } }
        public string EX_DIVISION { get { return _EX_DIVISION; } set { _EX_DIVISION = value; } }
        public string EX_COMMISSIONARATE { get { return _EX_COMMISSIONARATE; } set { _EX_COMMISSIONARATE = value; } }
        public string EX_RATE_OF_DUTY { get { return _EX_RATE_OF_DUTY; } set { _EX_RATE_OF_DUTY = value; } }
        public string EX_NAME_OF_GOODS { get { return _EX_NAME_OF_GOODS; } set { _EX_NAME_OF_GOODS = value; } }
        public string EX_CETH { get { return _EX_CETH; } set { _EX_CETH = value; } }
        public string EX_TITLE1 { get { return _EX_TITLE1; } set { _EX_TITLE1 = value; } }
        public string EX_TITLE2 { get { return _EX_TITLE2; } set { _EX_TITLE2 = value; } }
        public string TERMS_CONDITION { get { return _TERMS_CONDITION; } set { _TERMS_CONDITION = value; } }
        public string PLACE { get { return _PLACE; } set { _PLACE = value; } }
        public string DISTRICT { get { return _DISTRICT; } set { _DISTRICT = value; } }
        public string STATE { get { return _STATE; } set { _STATE = value; } }
        public string COUNTRY { get { return _COUNTRY; } set { _COUNTRY = value; } }
        public string LH_PATH { get { return _LH_PATH; } set { _LH_PATH = value; } }
        public string BKP_PATH { get { return _BKP_PATH; } set { _BKP_PATH = value; } }
        public string INVTYPE_FLAG { get { return _INVTYPE_FLAG; } set { _INVTYPE_FLAG = value; } }
        public string PAN_NO { get { return _PAN_NO; } set { _PAN_NO = value; } }
        public string EX_CETH_TITLE { get { return _EX_CETH_TITLE; } set { _EX_CETH_TITLE = value; } }
        public string EX_CETH2 { get { return _EX_CETH2; } set { _EX_CETH2 = value; } }
        public string EX_CETH_TITLE2 { get { return _EX_CETH_TITLE2; } set { _EX_CETH_TITLE2 = value; } }
        public string EX_CETH3 { get { return _EX_CETH3; } set { _EX_CETH3 = value; } }
        public string EX_CETH_TITLE3 { get { return _EX_CETH_TITLE3; } set { _EX_CETH_TITLE3 = value; } }
        public string EX_CETH4 { get { return _EX_CETH4; } set { _EX_CETH4 = value; } }
        public string EX_CETH_TITLE4 { get { return _EX_CETH_TITLE4; } set { _EX_CETH_TITLE4 = value; } }
        public string EX_DUTY_PER { get { return _EX_DUTY_PER; } set { _EX_DUTY_PER = value; } }
        public string EX_CESS_PER { get { return _EX_CESS_PER; } set { _EX_CESS_PER = value; } }
        public string EX_SHCESS_PER { get { return _EX_SHCESS_PER; } set { _EX_SHCESS_PER = value; } }
        public string STOCK_VIEWFLAG { get { return _STOCK_VIEWFLAG; } set { _STOCK_VIEWFLAG = value; } }
        public string EX_DIV_ADD { get { return _EX_DIV_ADD; } set { _EX_DIV_ADD = value; } }
        public string EX_COMM_ADD { get { return _EX_COMM_ADD; } set { _EX_COMM_ADD = value; } }
        public string EX_RANGE_ADD { get { return _EX_RANGE_ADD; } set { _EX_RANGE_ADD = value; } }
        public string BANK_NAME { get { return _BANK_NAME; } set { _BANK_NAME = value; } }
        public string BANK_BNAME { get { return _BANK_BNAME; } set { _BANK_BNAME = value; } }
        public string BANK_IFSCCODE { get { return _BANK_IFSCCODE; } set { _BANK_IFSCCODE = value; } }
        public string BANK_ACCNO { get { return _BANK_ACCNO; } set { _BANK_ACCNO = value; } }
        public string STAX_NO { get { return _STAX_NO; } set { _STAX_NO = value; } }
        public string WORK_VIEWFLAG { get { return _WORK_VIEWFLAG; } set { _WORK_VIEWFLAG = value; } }
        public string SCREEN_PATH { get { return _SCREEN_PATH; } set { _SCREEN_PATH = value; } }
        public string REF_COMP_CODE { get { return _REF_COMP_CODE; } set { _REF_COMP_CODE = value; } }
        public string LH_PATH2 { get { return _LH_PATH2; } set { _LH_PATH2 = value; } }
        public string QUO_BRAND_NAME { get { return _QUO_BRAND_NAME; } set { _QUO_BRAND_NAME = value; } }
        public string QUO_MODEL_NAME { get { return _QUO_MODEL_NAME; } set { _QUO_MODEL_NAME = value; } }
        public string QUO_SUB1 { get { return _QUO_SUB1; } set { _QUO_SUB1 = value; } }
        public string QUO_SUB2 { get { return _QUO_SUB2; } set { _QUO_SUB2 = value; } }
        public string QUO_SUB3 { get { return _QUO_SUB3; } set { _QUO_SUB3 = value; } }
        public string QUO_SUB4 { get { return _QUO_SUB4; } set { _QUO_SUB4 = value; } }
        public string QUO_NOTE { get { return _QUO_NOTE; } set { _QUO_NOTE = value; } }
        public string AUTO_MAILID { get { return _AUTO_MAILID; } set { _AUTO_MAILID = value; } }
        public string GST_NO { get { return _GST_NO; } set { _GST_NO = value; } }
        public string ADD_DISFLAG { get { return _ADD_DISFLAG; } set { _ADD_DISFLAG = value; } }
        public string STATE_NO { get { return _STATE_NO; } set { _STATE_NO = value; } }
        public string TERMS_CONDITION_GST { get { return _TERMS_CONDITION_GST; } set { _TERMS_CONDITION_GST = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATETIME { get { return _INS_DATETIME; } set { _INS_DATETIME = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATETIME { get { return _UPD_DATETIME; } set { _UPD_DATETIME = value; } }


        public static string InsertCOMPANYDetials(COMPANYLogicLayer COMPANYDetail)
        {
            return COMPANYDataLayer.InsertCOMPANYDetials(COMPANYDetail);
        }

        public static string updateCOMPANYDetials(COMPANYLogicLayer COMPANYDetail)
        {
            return COMPANYDataLayer.UpdateCOMPANYDetials(COMPANYDetail);
        }


        public static string DeleteCOMPANYDetailsByID(String CompanyID)
        {
            return COMPANYDataLayer.DeleteCOMPANYDetailsByID(CompanyID);
        }


        public static DataTable GetAllCOMPANYDetials(int USERCODE, int COMP_CODE)
        {
            return COMPANYDataLayer.GetAllCOMPANYDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllCOMPANYDetials_DDL()
        {
            return COMPANYDataLayer.GetAllCOMPANYDetials_DDL();
        }

        public static DataTable GetAllIDWiseCOMPANYDetials(String Id)
        {
            return COMPANYDataLayer.GetAllIDWiseCOMPANYDetials(Id);
        }

        public static DataTable GetCompanyDetailUserWiseRights(string USERCODE)
        {
            return COMPANYDataLayer.GetCompanyDetailUserWiseRights(USERCODE);
        }

        public static DataTable GetAllFIN_YEARSDetials()
        {
            return COMPANYDataLayer.GetAllFIN_YEARSDetials();
        }

        public static DataTable GetAllFIN_YEARSDetialsForGrid(string COMP_CODE)
        {
            return COMPANYDataLayer.GetAllFIN_YEARSDetialsForGrid(COMP_CODE);
        }



        public static DataTable GetFIN_YEARSDetailUserWiseRightsAndCompanyWise(string USERCODE, string COMP_CODE)
        {
            return COMPANYDataLayer.GetFIN_YEARSDetailUserWiseRightsAndCompanyWise(USERCODE, COMP_CODE);
        }

        public static DataTable GetFIN_YEARSDetailUserWiseRightsAndCompanyWiseForGrid(string USERCODE, string COMP_CODE)
        {
            return COMPANYDataLayer.GetFIN_YEARSDetailUserWiseRightsAndCompanyWiseForGrid(USERCODE, COMP_CODE);
        }

        public static string InsertUSER_COMPANY_RIGHTSDetail(string COMP_CODE, string USERCODE)
        {
            return COMPANYDataLayer.InsertUSER_COMPANY_RIGHTSDetail(COMP_CODE, USERCODE);
        }

        public static string DELETEUSER_COMPANY_RIGHTSDetail(string COMP_CODE, string USERCODE)
        {
            return COMPANYDataLayer.DELETEUSER_COMPANY_RIGHTSDetail(COMP_CODE, USERCODE);
        }

        public static string InsertUSER_YEARS_RIGHTSDetail(string COMP_CODE, string USERCODE, string YRDT1)
        {
            return COMPANYDataLayer.InsertUSER_YEARS_RIGHTSDetail(COMP_CODE, USERCODE, YRDT1);
        }

        public static string DELETEUSER_YEARS_RIGHTSDetail(string COMP_CODE, string USERCODE, string YRDT1)
        {
            return COMPANYDataLayer.DELETEUSER_YEARS_RIGHTSDetail(COMP_CODE, USERCODE, YRDT1);
        }

        public static DataTable GetAllFinancialYearDetials(string COMP_CODE)
        {
            return COMPANYDataLayer.GetAllFinancialYearDetials(COMP_CODE);
        }
        public static string InsertFinancialYearDetials(string COMP_CODE, string YRDT1, string YRDT2)
        {
            return COMPANYDataLayer.InsertFinancialYearDetials(COMP_CODE, YRDT1, YRDT2);
        }



    }

    public class BRANCH_MASLogicLayer

    {

        string _COMP_CODE, _BRANCH_CODE, _BRANCH_NAME, _BRANCH_SHORT, _BRANCH_TYPE, _BRANCH_ADD1, _BRANCH_ADD2, _BRANCH_ADD3, _BRANCH_PHONE, _BRANCH_FAX, _BRANCH_EMAIL, _CRACODE1, _DRACODE1, _CRACODE2, _DRACODE2, _CRACODE3, _DRACODE3, _AUTO_MAILID, _BS_CRACODE, _BS_DRACODE, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE, _BRANCH_STATE, _BRANCH_STATE_NO, _GST_APP_FLAG, _GST_APP_DATE, _BRANCH_GST_NO, _BRANCH_PARTY_TYPE, _BRANCH_CITY, _BR_DRACODE, _BR_CRACODE;

        public BRANCH_MASLogicLayer()
        {
            _COMP_CODE = "  ";
            _BRANCH_CODE = "  ";
            _BRANCH_NAME = "  ";
            _BRANCH_SHORT = "  ";
            _BRANCH_TYPE = "  ";
            _BRANCH_ADD1 = "  ";
            _BRANCH_ADD2 = "  ";
            _BRANCH_ADD3 = "  ";
            _BRANCH_PHONE = "  ";
            _BRANCH_FAX = "  ";
            _BRANCH_EMAIL = "  ";
            _CRACODE1 = "  ";
            _DRACODE1 = "  ";
            _CRACODE2 = "  ";
            _DRACODE2 = "  ";
            _CRACODE3 = "  ";
            _DRACODE3 = "  ";
            _AUTO_MAILID = "  ";
            _BS_CRACODE = "  ";
            _BS_DRACODE = "  ";
            _INS_USERID = "  ";
            _INS_TERMINAL = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_TERMINAL = "  ";
            _UPD_DATE = "  ";
            _BRANCH_STATE = " ";
            _BRANCH_STATE_NO = " ";
            _GST_APP_FLAG = " ";
            _GST_APP_DATE = " ";
            _BRANCH_GST_NO = " ";
            _BRANCH_PARTY_TYPE = " ";
            _BRANCH_CITY = " ";
            _BR_DRACODE = " ";
            _BR_CRACODE = " ";



        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string BRANCH_NAME { get { return _BRANCH_NAME; } set { _BRANCH_NAME = value; } }
        public string BRANCH_SHORT { get { return _BRANCH_SHORT; } set { _BRANCH_SHORT = value; } }
        public string BRANCH_TYPE { get { return _BRANCH_TYPE; } set { _BRANCH_TYPE = value; } }
        public string BRANCH_ADD1 { get { return _BRANCH_ADD1; } set { _BRANCH_ADD1 = value; } }
        public string BRANCH_ADD2 { get { return _BRANCH_ADD2; } set { _BRANCH_ADD2 = value; } }
        public string BRANCH_ADD3 { get { return _BRANCH_ADD3; } set { _BRANCH_ADD3 = value; } }
        public string BRANCH_PHONE { get { return _BRANCH_PHONE; } set { _BRANCH_PHONE = value; } }
        public string BRANCH_FAX { get { return _BRANCH_FAX; } set { _BRANCH_FAX = value; } }
        public string BRANCH_EMAIL { get { return _BRANCH_EMAIL; } set { _BRANCH_EMAIL = value; } }
        public string CRACODE1 { get { return _CRACODE1; } set { _CRACODE1 = value; } }
        public string DRACODE1 { get { return _DRACODE1; } set { _DRACODE1 = value; } }
        public string CRACODE2 { get { return _CRACODE2; } set { _CRACODE2 = value; } }
        public string DRACODE2 { get { return _DRACODE2; } set { _DRACODE2 = value; } }
        public string CRACODE3 { get { return _CRACODE3; } set { _CRACODE3 = value; } }
        public string DRACODE3 { get { return _DRACODE3; } set { _DRACODE3 = value; } }
        public string AUTO_MAILID { get { return _AUTO_MAILID; } set { _AUTO_MAILID = value; } }
        public string BS_CRACODE { get { return _BS_CRACODE; } set { _BS_CRACODE = value; } }
        public string BS_DRACODE { get { return _BS_DRACODE; } set { _BS_DRACODE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string BRANCH_STATE_NO { get { return _BRANCH_STATE_NO; } set { _BRANCH_STATE_NO = value; } }
        public string BRANCH_STATE { get { return _BRANCH_STATE; } set { _BRANCH_STATE = value; } }
        public string GST_APP_FLAG { get { return _GST_APP_FLAG; } set { _GST_APP_FLAG = value; } }
        public string GST_APP_DATE { get { return _GST_APP_DATE; } set { _GST_APP_DATE = value; } }
        public string BRANCH_GST_NO { get { return _BRANCH_GST_NO; } set { _BRANCH_GST_NO = value; } }
        public string BRANCH_PARTY_TYPE { get { return _BRANCH_PARTY_TYPE; } set { _BRANCH_PARTY_TYPE = value; } }
        public string BRANCH_CITY { get { return _BRANCH_CITY; } set { _BRANCH_CITY = value; } }
        public string BR_DRACODE { get { return _BR_DRACODE; } set { _BR_DRACODE = value; } }
        public string BR_CRACODE { get { return _BR_CRACODE; } set { _BR_CRACODE = value; } }




        public static string InsertBRANCH_MASDetials(BRANCH_MASLogicLayer BRANCH_MASDetail)
        {
            return BRANCH_MASDataLayer.InsertBRANCH_MASDetials(BRANCH_MASDetail);
        }

        public static string updateBRANCH_MASDetials(BRANCH_MASLogicLayer BRANCH_MASDetail)
        {
            return BRANCH_MASDataLayer.UpdateBRANCH_MASDetials(BRANCH_MASDetail);
        }

        public static string DeleteBRANCHDetailsByID(string BranchID)
        {
            return BRANCH_MASDataLayer.DeleteBRANCHDetailsByID(BranchID);
        }

        public static DataTable GetAllBRANCH_MASDetials(int USERCODE, int COMP_CODE)
        {
            return BRANCH_MASDataLayer.GetAllBRANCH_MASDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetBranchDetailCompanyWiseFor_Ddl(string COMP_CODE)
        {
            return BRANCH_MASDataLayer.GetBranchDetailCompanyWiseFor_Ddl(COMP_CODE);
        }

        public static DataTable GetBranchNameCompanyWiseFor_DdlReport(string COMP_CODE)
        {
            return BRANCH_MASDataLayer.GetBranchNameCompanyWiseFor_DdlReport(COMP_CODE);
        }

        public static DataTable GetAllIDWiseBRANCH_MASDetials(string Id)
        {
            return BRANCH_MASDataLayer.GetAllIDWiseBRANCH_MASDetials(Id);
        }

        public static DataTable GetIDWiseBRANCH_MASDetialsByCompany(string COMP_CODE, string BRANCH_CODE)
        {
            return BRANCH_MASDataLayer.GetIDWiseBRANCH_MASDetialsByCompany(COMP_CODE, BRANCH_CODE);
        }
        public static DataTable GetBranchDetailUserWiseRightsAndCompanyWise(string USERCODE, string COMP_CODE)
        {
            return BRANCH_MASDataLayer.GetBranchDetailUserWiseRightsAndCompanyWise(USERCODE, COMP_CODE);
        }


        public static DataTable GetBranchDetailCompanyWise(string COMP_CODE, string USERCODE)
        {
            return BRANCH_MASDataLayer.GetBranchDetailCompanyWise(COMP_CODE, USERCODE);
        }

        public static string InsertUSER_BRANCHDetail(string BRANCH_CODE, string USERCODE, string COMP_CODE)
        {
            return BRANCH_MASDataLayer.InsertUSER_BRANCHDetail(BRANCH_CODE, USERCODE, COMP_CODE);
        }

        public static string DELETEUSER_BRANCHDetail(string BRANCH_CODE, string USERCODE, string COMP_CODE)
        {
            return BRANCH_MASDataLayer.DELETEUSER_BRANCHDetail(BRANCH_CODE, USERCODE, COMP_CODE);
        }

        public static string UpdateUSER_BRANCHDetail(string BRANCH_CODE, string USERCODE, string COMP_CODE, string Flag, int Types)
        {
            return BRANCH_MASDataLayer.UpdateUSER_BRANCHDetail(BRANCH_CODE, USERCODE, COMP_CODE, Flag, Types);
        }

    }

    public class USER_MASLogicLayer

    {

        string _USERCODE, _USERNAME, _USERPASS, _USERTYPE, _ACTIVE, _DEACTIVE_DATE;

        public USER_MASLogicLayer()
        {
            _USERCODE = "  ";
            _USERNAME = "  ";
            _USERPASS = "  ";
            _USERTYPE = "  ";
            _ACTIVE = "  ";
            _DEACTIVE_DATE = "  ";


        }
        public string USERCODE { get { return _USERCODE; } set { _USERCODE = value; } }
        public string USERNAME { get { return _USERNAME; } set { _USERNAME = value; } }
        public string USERPASS { get { return _USERPASS; } set { _USERPASS = value; } }
        public string USERTYPE { get { return _USERTYPE; } set { _USERTYPE = value; } }
        public string ACTIVE { get { return _ACTIVE; } set { _ACTIVE = value; } }
        public string DEACTIVE_DATE { get { return _DEACTIVE_DATE; } set { _DEACTIVE_DATE = value; } }


        public static string InsertUSER_MASDetail(USER_MASLogicLayer USER_MASDetails)
        {
            return USER_MASDataLayer.InsertUSER_MASDetail(USER_MASDetails);
        }

        public static string UpdateUSER_MASDetail(USER_MASLogicLayer USER_MASDetails)
        {
            return USER_MASDataLayer.UpdateUSER_MASDetail(USER_MASDetails);
        }

        public static string DeleteUSER_MASDetailsByID(String UserID)
        {
            return USER_MASDataLayer.DeleteUSER_MASDetailsByID(UserID);
        }

        public static DataTable GetAllUSER_MASDetials(int UserCode, int COMP_CODE)
        {
            return USER_MASDataLayer.GetAllUSER_MASDetials(UserCode, COMP_CODE);
        }

        public static DataTable GetAllUSER_MASDetials_ForDDl()
        {
            return USER_MASDataLayer.GetAllUSER_MASDetials_ForDDl();
        }


        public static DataTable GetAllIDWiseUSER_MASDetials(String Id)
        {
            return USER_MASDataLayer.GetAllIDWiseUSER_MASDetials(Id);
        }

        public static DataTable GetUserMasterAuthentication(string USERNAME, string USERPASS)
        {
            return USER_MASDataLayer.GetUserMasterAuthentication(USERNAME, USERPASS);
        }

        public static DataTable GetAllUserWiseCompanyRights(string Id)
        {
            return USER_MASDataLayer.GetAllUserWiseCompanyRights(Id);
        }
    }

    public class USERLOGINLogicLayer

    {

        string _LOGNO, _USERNAME, _MAC_ID, _LCL_ID, _LOGDT;

        public USERLOGINLogicLayer()
        {
            _LOGNO = "  ";
            _USERNAME = "  ";
            _MAC_ID = "  ";
            _LCL_ID = "  ";
            _LOGDT = "  ";


        }
        public string LOGNO { get { return _LOGNO; } set { _LOGNO = value; } }
        public string USERNAME { get { return _USERNAME; } set { _USERNAME = value; } }
        public string MAC_ID { get { return _MAC_ID; } set { _MAC_ID = value; } }
        public string LCL_ID { get { return _LCL_ID; } set { _LCL_ID = value; } }
        public string LOGDT { get { return _LOGDT; } set { _LOGDT = value; } }


        public static string InsertUSERLOGINDetials(USERLOGINLogicLayer USERLOGINDetail)
        {
            return USERLOGINDataLayer.InsertUSERLOGINDetials(USERLOGINDetail);
        }

        public static string updateUSERLOGINDetials(USERLOGINLogicLayer USERLOGINDetail)
        {
            return USERLOGINDataLayer.UpdateUSERLOGINDetials(USERLOGINDetail);
        }

        public static DataTable GetAllUSERLOGINDetials()
        {
            return USERLOGINDataLayer.GetAllUSERLOGINDetials();
        }

        public static DataTable GetAllIDWiseUSERLOGINDetials(String Id)
        {
            return USERLOGINDataLayer.GetAllIDWiseUSERLOGINDetials(Id);
        }

        public static DataTable GetMenuWithNullREF_CODE()
        {
            return USERLOGINDataLayer.GetMenuWithNullREF_CODE();
        }

        public static DataTable GetSubMenuWithNullREF_CODE(string Id)
        {
            return USERLOGINDataLayer.GetSubMenuWithNullREF_CODE(Id);
        }
    }


    public class GROUP_MASLogicLayer
    {
        string _GROUP_TYPE, _GROUP_CODE, _GROUP_NAME, _GROUP_ORD;

        public GROUP_MASLogicLayer()
        {
            _GROUP_TYPE = " ";
            _GROUP_CODE = " ";
            _GROUP_NAME = " ";
            _GROUP_ORD = " ";

        }

        public string GROUP_TYPE { get { return _GROUP_TYPE; } set { _GROUP_TYPE = value; } }
        public string GROUP_CODE { get { return _GROUP_CODE; } set { _GROUP_CODE = value; } }
        public string GROUP_NAME { get { return _GROUP_NAME; } set { _GROUP_NAME = value; } }
        public string GROUP_ORD { get { return _GROUP_ORD; } set { _GROUP_ORD = value; } }



        public static string InsertGROUPMASTERDetail(GROUP_MASLogicLayer GROUP_MAS)
        {
            return GROUP_MASDataLayer.InsertGROUPMASTERDetail(GROUP_MAS);
        }

        public static string UpdateGROUPMASTERDetail(GROUP_MASLogicLayer GROUP_MAS)
        {
            return GROUP_MASDataLayer.UpdateGROUPMASTERDetail(GROUP_MAS);
        }

        public static string DeleteGROUP_MASDetailsByID(String GroupID)
        {
            return GROUP_MASDataLayer.DeleteGROUP_MASDetailsByID(GroupID);
        }

        public static DataTable GetAllGROUP_MASDetials(int UserCode, int COMP_CODE)
        {
            return GROUP_MASDataLayer.GetAllGROUP_MASDetials(UserCode, COMP_CODE);
        }
        public static DataTable GetGROUP_CODEWISEGROUP_MASDetials(string Id)
        {
            return GROUP_MASDataLayer.GetGROUP_CODEWISEGROUP_MASDetials(Id);
        }

        public static DataTable GetAllGROUP_MASDetials_DDL()
        {
            return GROUP_MASDataLayer.GetAllGROUP_MASDetials_DDL();
        }
    }


    public class FIN_YEARSLogicLayer
    {
        string _COMP_CODE, _YRDT1, _YRDT2, _ACTIVE, _LOCKFLAG, _FRDT, _TODT, _ACTIVE1;

        public FIN_YEARSLogicLayer()
        {
            _COMP_CODE = " ";
            _YRDT1 = " ";
            _YRDT2 = " ";
            _ACTIVE = " ";
            _LOCKFLAG = " ";
            _FRDT = " ";
            _TODT = " ";
            _ACTIVE1 = " ";

        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string YRDT1 { get { return _YRDT1; } set { _YRDT1 = value; } }
        public string YRDT2 { get { return _YRDT2; } set { _YRDT2 = value; } }
        public string ACTIVE { get { return _ACTIVE; } set { _ACTIVE = value; } }
        public string LOCKFLAG { get { return _LOCKFLAG; } set { _LOCKFLAG = value; } }
        public string FRDT { get { return _FRDT; } set { _FRDT = value; } }
        public string TODT { get { return _TODT; } set { _TODT = value; } }
        public string ACTIVE1 { get { return _ACTIVE1; } set { _ACTIVE1 = value; } }



    }



    public class ACCOUNTS_MASLogicLayer
    {
        string _COMP_CODE, _ACODE, _ANAME, _SHORT, _GROUP_CODE, _ACTIVE, _CONTACT_PER, _CREDIT_AMT, _CREDIT_DAYS, _ADD1, _ADD2, _ADD3, _ADD4, _PHONE, _PHONE_R, _PHONE_M, _FAX, _EMAIL,
               _SST_NO, _CST_NO, _PARTY_TYPE, _SALES_TYPE, _PL_PER, _REG_NO, _CITY, _PLACE, _DISTRICT, _STATE, _COUNTRY, _AC_CODE, _ST_PER, _ADD_ST_PER, _ATYPE, _EX_RANGE, _EX_DIVISION,
              _CE_NO, _BRANCH_CODE, _PAN_NO, _CST_TYPE, _STAX_NO, _EX_COMM, _BANK_NAME, _BANK_BRANCH, _BANK_ADD, _BANK_IFSC, _BANK_ACCNO, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID,
              _UPD_TERMINAL, _UPD_DATE, _CHQ_REPNAME, _PLACE_CODE, _MKTG_BCODE, _ACC_BCODE, _WORK_BCODE, _BANK_MICRO, _GPS_LOCNO, _ACC_COMPFLAG, _WORK_COMPFLAG, _MKTG_FLAG, _XFER_TYPE,
              _XFER_USERID, _XFER_TERMINAL, _XFER_DATE, _HO_CONTACT_PER, _HO_ADD1, _HO_ADD2, _HO_ADD3, _HO_PHONE, _HO_PHONE_M, _HO_FAX, _HO_EMAIL, _BUSINESS_TYPE, _SST_DATE, _CST_DATE,
              _GST_NO, _STATE_NO, _RCM_FLAG, _GST_RATE, _VENDOR_CODE;

        public ACCOUNTS_MASLogicLayer()
        {
            _COMP_CODE = "";
            _ACODE = "";
            _ANAME = "";
            _SHORT = "";
            _GROUP_CODE = "";
            _ACTIVE = "";
            _CONTACT_PER = "";
            _CREDIT_AMT = "";
            _CREDIT_DAYS = "";
            _ADD1 = "";
            _ADD2 = "";
            _ADD3 = "";
            _ADD4 = "";
            _PHONE = "";
            _PHONE_R = "";
            _PHONE_M = "";
            _FAX = "";
            _EMAIL = "";
            _SST_NO = "";
            _CST_NO = "";
            _PARTY_TYPE = "";
            _SALES_TYPE = "";
            _PL_PER = "";
            _REG_NO = "";
            _CITY = "";
            _PLACE = "";
            _DISTRICT = "";
            _STATE = "";
            _COUNTRY = "";
            _AC_CODE = "";
            _ST_PER = "";
            _ADD_ST_PER = "";
            _ATYPE = "";
            _EX_RANGE = "";
            _EX_DIVISION = "";
            _CE_NO = "";
            _BRANCH_CODE = "";
            _PAN_NO = "";
            _CST_TYPE = "";
            _STAX_NO = "";
            _EX_COMM = "";
            _BANK_NAME = "";
            _BANK_BRANCH = "";
            _BANK_ADD = "";
            _BANK_IFSC = "";
            _BANK_ACCNO = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
            _CHQ_REPNAME = "";
            _PLACE_CODE = "";
            _MKTG_BCODE = "";
            _ACC_BCODE = "";
            _WORK_BCODE = "";
            _BANK_MICRO = "";
            _GPS_LOCNO = "";
            _ACC_COMPFLAG = "";
            _WORK_COMPFLAG = "";
            _MKTG_FLAG = "";
            _XFER_TYPE = "";
            _XFER_USERID = "";
            _XFER_TERMINAL = "";
            _XFER_DATE = "";
            _HO_CONTACT_PER = "";
            _HO_ADD1 = "";
            _HO_ADD2 = "";
            _HO_ADD3 = "";
            _HO_PHONE = "";
            _HO_PHONE_M = "";
            _HO_FAX = "";
            _HO_EMAIL = "";
            _BUSINESS_TYPE = "";
            _SST_DATE = "";
            _CST_DATE = "";
            _GST_NO = "";
            _STATE_NO = "";
            _RCM_FLAG = "";
            _GST_RATE = "";
            _VENDOR_CODE = "";
        }


        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string ANAME { get { return _ANAME; } set { _ANAME = value; } }
        public string SHORT { get { return _SHORT; } set { _SHORT = value; } }
        public string GROUP_CODE { get { return _GROUP_CODE; } set { _GROUP_CODE = value; } }
        public string ACTIVE { get { return _ACTIVE; } set { _ACTIVE = value; } }
        public string CONTACT_PER { get { return _CONTACT_PER; } set { _CONTACT_PER = value; } }
        public string CREDIT_AMT { get { return _CREDIT_AMT; } set { _CREDIT_AMT = value; } }
        public string CREDIT_DAYS { get { return _CREDIT_DAYS; } set { _CREDIT_DAYS = value; } }
        public string ADD1 { get { return _ADD1; } set { _ADD1 = value; } }
        public string ADD2 { get { return _ADD2; } set { _ADD2 = value; } }
        public string ADD3 { get { return _ADD3; } set { _ADD3 = value; } }
        public string ADD4 { get { return _ADD4; } set { _ADD4 = value; } }
        public string PHONE { get { return _PHONE; } set { _PHONE = value; } }
        public string PHONE_R { get { return _PHONE_R; } set { _PHONE_R = value; } }
        public string PHONE_M { get { return _PHONE_M; } set { _PHONE_M = value; } }
        public string FAX { get { return _FAX; } set { _FAX = value; } }
        public string EMAIL { get { return _EMAIL; } set { _EMAIL = value; } }
        public string SST_NO { get { return _SST_NO; } set { _SST_NO = value; } }
        public string CST_NO { get { return _CST_NO; } set { _CST_NO = value; } }
        public string PARTY_TYPE { get { return _PARTY_TYPE; } set { _PARTY_TYPE = value; } }
        public string SALES_TYPE { get { return _SALES_TYPE; } set { _SALES_TYPE = value; } }
        public string PL_PER { get { return _PL_PER; } set { _PL_PER = value; } }
        public string REG_NO { get { return _REG_NO; } set { _REG_NO = value; } }
        public string CITY { get { return _CITY; } set { _CITY = value; } }
        public string PLACE { get { return _PLACE; } set { _PLACE = value; } }
        public string DISTRICT { get { return _DISTRICT; } set { _DISTRICT = value; } }
        public string STATE { get { return _STATE; } set { _STATE = value; } }
        public string COUNTRY { get { return _COUNTRY; } set { _COUNTRY = value; } }
        public string AC_CODE { get { return _AC_CODE; } set { _AC_CODE = value; } }
        public string ST_PER { get { return _ST_PER; } set { _ST_PER = value; } }
        public string ADD_ST_PER { get { return _ADD_ST_PER; } set { _ADD_ST_PER = value; } }
        public string ATYPE { get { return _ATYPE; } set { _ATYPE = value; } }
        public string EX_RANGE { get { return _EX_RANGE; } set { _EX_RANGE = value; } }
        public string EX_DIVISION { get { return _EX_DIVISION; } set { _EX_DIVISION = value; } }
        public string CE_NO { get { return _CE_NO; } set { _CE_NO = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string PAN_NO { get { return _PAN_NO; } set { _PAN_NO = value; } }
        public string CST_TYPE { get { return _CST_TYPE; } set { _CST_TYPE = value; } }
        public string STAX_NO { get { return _STAX_NO; } set { _STAX_NO = value; } }
        public string EX_COMM { get { return _EX_COMM; } set { _EX_COMM = value; } }
        public string BANK_NAME { get { return _BANK_NAME; } set { _BANK_NAME = value; } }
        public string BANK_BRANCH { get { return _BANK_BRANCH; } set { _BANK_BRANCH = value; } }
        public string BANK_ADD { get { return _BANK_ADD; } set { _BANK_ADD = value; } }
        public string BANK_IFSC { get { return _BANK_IFSC; } set { _BANK_IFSC = value; } }
        public string BANK_ACCNO { get { return _BANK_ACCNO; } set { _BANK_ACCNO = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string CHQ_REPNAME { get { return _CHQ_REPNAME; } set { _CHQ_REPNAME = value; } }
        public string PLACE_CODE { get { return _PLACE_CODE; } set { _PLACE_CODE = value; } }
        public string MKTG_BCODE { get { return _MKTG_BCODE; } set { _MKTG_BCODE = value; } }
        public string ACC_BCODE { get { return _ACC_BCODE; } set { _ACC_BCODE = value; } }
        public string WORK_BCODE { get { return _WORK_BCODE; } set { _WORK_BCODE = value; } }
        public string BANK_MICRO { get { return _BANK_MICRO; } set { _BANK_MICRO = value; } }
        public string GPS_LOCNO { get { return _GPS_LOCNO; } set { _GPS_LOCNO = value; } }
        public string ACC_COMPFLAG { get { return _ACC_COMPFLAG; } set { _ACC_COMPFLAG = value; } }
        public string WORK_COMPFLAG { get { return _WORK_COMPFLAG; } set { _WORK_COMPFLAG = value; } }
        public string MKTG_FLAG { get { return _MKTG_FLAG; } set { _MKTG_FLAG = value; } }
        public string XFER_TYPE { get { return _XFER_TYPE; } set { _XFER_TYPE = value; } }
        public string XFER_USERID { get { return _XFER_USERID; } set { _XFER_USERID = value; } }
        public string XFER_TERMINAL { get { return _XFER_TERMINAL; } set { _XFER_TERMINAL = value; } }
        public string XFER_DATE { get { return _XFER_DATE; } set { _XFER_DATE = value; } }
        public string HO_CONTACT_PER { get { return _HO_CONTACT_PER; } set { _HO_CONTACT_PER = value; } }
        public string HO_ADD1 { get { return _HO_ADD1; } set { _HO_ADD1 = value; } }
        public string HO_ADD2 { get { return _HO_ADD2; } set { _HO_ADD2 = value; } }
        public string HO_ADD3 { get { return _HO_ADD3; } set { _HO_ADD3 = value; } }
        public string HO_PHONE { get { return _HO_PHONE; } set { _HO_PHONE = value; } }
        public string HO_PHONE_M { get { return _HO_PHONE_M; } set { _HO_PHONE_M = value; } }
        public string HO_FAX { get { return _HO_FAX; } set { _HO_FAX = value; } }
        public string HO_EMAIL { get { return _HO_EMAIL; } set { _HO_EMAIL = value; } }
        public string BUSINESS_TYPE { get { return _BUSINESS_TYPE; } set { _BUSINESS_TYPE = value; } }
        public string SST_DATE { get { return _SST_DATE; } set { _SST_DATE = value; } }
        public string CST_DATE { get { return _CST_DATE; } set { _CST_DATE = value; } }
        public string GST_NO { get { return _GST_NO; } set { _GST_NO = value; } }
        public string STATE_NO { get { return _STATE_NO; } set { _STATE_NO = value; } }
        public string RCM_FLAG { get { return _RCM_FLAG; } set { _RCM_FLAG = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string VENDOR_CODE { get { return _VENDOR_CODE; } set { _VENDOR_CODE = value; } }



        public static string InsertACCOUNTDetail(ACCOUNTS_MASLogicLayer ACCOUNTDetails)
        {
            return ACCOUNTS_MASDataLayer.InsertACCOUNTDetail(ACCOUNTDetails);
        }

        public static string UpdateACCOUNTDetails(ACCOUNTS_MASLogicLayer ACCOUNTDetails)
        {
            return ACCOUNTS_MASDataLayer.UpdateACCOUNTDetails(ACCOUNTDetails);
        }


        public static string DeleteACCOUNTDetailsByID(String AccountID)
        {
            return ACCOUNTS_MASDataLayer.DeleteACCOUNTDetailsByID(AccountID);
        }

        public static DataTable GetAllACCOUNTSDetials(int USERCODE, int COMP_CODE)
        {
            return ACCOUNTS_MASDataLayer.GetAllACCOUNTSDetials(USERCODE, COMP_CODE);
        }


        public static DataTable GetAllIDWiseACCOUNTDetials(String Id)
        {
            return ACCOUNTS_MASDataLayer.GetAllIDWiseACCOUNTDetials(Id);
        }

        public static DataTable GetAllACCOUNTS_MASDetialsFor_DDL()
        {
            return ACCOUNTS_MASDataLayer.GetAllACCOUNTS_MASDetialsFor_DDL();
        }

        public static DataTable GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(string Id)
        {
            return ACCOUNTS_MASDataLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(Id);
        }

        public static DataTable GetIDWiseGROUP_NAMEFor_AccountBal(String Id)
        {
            return ACCOUNTS_MASDataLayer.GetIDWiseGROUP_NAMEFor_AccountBal(Id);
        }


        public static DataTable GetAllGroupCodeWise_PartyDetailsForGrid(string COMP_CODE, string BRANCH_CODE, string GROUP_CODE)
        {
            return ACCOUNTS_MASDataLayer.GetAllGroupCodeWise_PartyDetailsForGrid(COMP_CODE, BRANCH_CODE, GROUP_CODE);
        }

        public static DataTable GetAllACCOUNTDetialsByComapnyAndBranch(string COMP_CODE, string BRANCH_CODE)
        {
            return ACCOUNTS_MASDataLayer.GetAllACCOUNTDetialsByComapnyAndBranch(COMP_CODE, BRANCH_CODE);
        }

        public static DataTable GetAllACCOUNTWiseComapnyAndBranchForInvoice(string COMP_CODE, string BRANCH_CODE)
        {
            return ACCOUNTS_MASDataLayer.GetAllACCOUNTWiseComapnyAndBranchForInvoice(COMP_CODE, BRANCH_CODE);
        }

        public static DataTable GetAccountsNameForInvoices(string COMP_CODE, string BRANCH_CODE, string TRAN_TYPE, string TRN_TYPE)
        {
            return ACCOUNTS_MASDataLayer.GetAccountsNameForInvoices(COMP_CODE, BRANCH_CODE, TRAN_TYPE, TRN_TYPE);
        }


        public static DataTable GetACCOUNTNameForCashBankBook(string COMP_CODE, string GROUP_CODE)
        {
            return ACCOUNTS_MASDataLayer.GetACCOUNTNameForCashBankBook(COMP_CODE, GROUP_CODE);
        }
    }


    public class ACCOUNTS_DETLogicLayer
    {
        string _COMP_CODE, _ACODE, _SRNO, _CONTACT_NAME, _DESIGN_NAME, _PHONE_NO, _MAIL_ID, _ACTIVE, _DOB, _ACC_FLAG, _PUR_FLAG, _SERVICE_FLAG, _OWNER_FLAG,
               _GEN_FLAG, _SMS_FLAG, _REMARK, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public ACCOUNTS_DETLogicLayer()
        {
            _COMP_CODE = "";
            _ACODE = "";
            _SRNO = "";
            _CONTACT_NAME = "";
            _DESIGN_NAME = "";
            _PHONE_NO = "";
            _MAIL_ID = "";
            _ACTIVE = "";
            _DOB = "";
            _ACC_FLAG = "";
            _PUR_FLAG = "";
            _SERVICE_FLAG = "";
            _OWNER_FLAG = "";
            _GEN_FLAG = "";
            _SMS_FLAG = "";
            _REMARK = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";

        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string CONTACT_NAME { get { return _CONTACT_NAME; } set { _CONTACT_NAME = value; } }
        public string DESIGN_NAME { get { return _DESIGN_NAME; } set { _DESIGN_NAME = value; } }
        public string PHONE_NO { get { return _PHONE_NO; } set { _PHONE_NO = value; } }
        public string MAIL_ID { get { return _MAIL_ID; } set { _MAIL_ID = value; } }
        public string ACTIVE { get { return _ACTIVE; } set { _ACTIVE = value; } }
        public string DOB { get { return _DOB; } set { _DOB = value; } }
        public string ACC_FLAG { get { return _ACC_FLAG; } set { _ACC_FLAG = value; } }
        public string PUR_FLAG { get { return _PUR_FLAG; } set { _PUR_FLAG = value; } }
        public string SERVICE_FLAG { get { return _SERVICE_FLAG; } set { _SERVICE_FLAG = value; } }
        public string OWNER_FLAG { get { return _OWNER_FLAG; } set { _OWNER_FLAG = value; } }
        public string GEN_FLAG { get { return _GEN_FLAG; } set { _GEN_FLAG = value; } }
        public string SMS_FLAG { get { return _SMS_FLAG; } set { _SMS_FLAG = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


        public static string InsertACCOUNTS_DETDetail(ACCOUNTS_DETLogicLayer ContactDetails)
        {
            return ACCOUNTS_DETDataLayer.InsertACCOUNTS_DETDetail(ContactDetails);
        }


        public static string UpdateACCOUNTS_DETDetails(ACCOUNTS_DETLogicLayer ContactDetails)
        {
            return ACCOUNTS_DETDataLayer.UpdateACCOUNTS_DETDetails(ContactDetails);
        }


        public static string DeleteACCOUNTS_DETDetailsByID(string ID)
        {
            return ACCOUNTS_DETDataLayer.DeleteACCOUNTS_DETDetailsByID(ID);
        }


        public static DataTable GetAllACCOUNTS_DETDetials(int USERCODE, int COMP_CODE)
        {
            return ACCOUNTS_DETDataLayer.GetAllACCOUNTS_DETDetials(USERCODE, COMP_CODE);
        }


        public static DataTable GetAllIDWiseACCOUNTS_DETDetials(string ID)
        {
            return ACCOUNTS_DETDataLayer.GetAllIDWiseACCOUNTS_DETDetials(ID);
        }

        public static DataTable GetAllParty_Contact_DetialsWIiseAccountFor_DDL(string ACODE)
        {
            return ACCOUNTS_DETDataLayer.GetAllParty_Contact_DetialsWIiseAccountFor_DDL(ACODE);
        }
    }

    public class ACCT_BALLogicLayer

    {

        string _COMP_CODE, _ACODE, _YRDT1, _OP_BAL, _CUR_BAL, _CREDIT_AMT, _CREDIT_DAYS, _PAID_AMT, _STATUS, _ATYPE, _LESS_AMT, _TDS_AMT, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public ACCT_BALLogicLayer()
        {
            _COMP_CODE = "  ";
            _ACODE = "  ";
            _YRDT1 = "  ";
            _OP_BAL = "  ";
            _CUR_BAL = "  ";
            _CREDIT_AMT = "  ";
            _CREDIT_DAYS = "  ";
            _PAID_AMT = "  ";
            _STATUS = "  ";
            _ATYPE = "  ";
            _LESS_AMT = "  ";
            _TDS_AMT = "  ";
            _INS_USERID = "  ";
            _INS_TERMINAL = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_TERMINAL = "  ";
            _UPD_DATE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string YRDT1 { get { return _YRDT1; } set { _YRDT1 = value; } }
        public string OP_BAL { get { return _OP_BAL; } set { _OP_BAL = value; } }
        public string CUR_BAL { get { return _CUR_BAL; } set { _CUR_BAL = value; } }
        public string CREDIT_AMT { get { return _CREDIT_AMT; } set { _CREDIT_AMT = value; } }
        public string CREDIT_DAYS { get { return _CREDIT_DAYS; } set { _CREDIT_DAYS = value; } }
        public string PAID_AMT { get { return _PAID_AMT; } set { _PAID_AMT = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string ATYPE { get { return _ATYPE; } set { _ATYPE = value; } }
        public string LESS_AMT { get { return _LESS_AMT; } set { _LESS_AMT = value; } }
        public string TDS_AMT { get { return _TDS_AMT; } set { _TDS_AMT = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


        public static string InsertACCT_BALDetials(ACCT_BALLogicLayer ACCT_BALDetail)
        {
            return ACCT_BALDataLayer.InsertACCT_BALDetials(ACCT_BALDetail);
        }

        public static string UpdateACCT_BALDetials(ACCT_BALLogicLayer ACCT_BALDetail)
        {
            return ACCT_BALDataLayer.UpdateACCT_BALDetials(ACCT_BALDetail);
        }

        public static DataTable GetAllACCT_BALDetials(int USERCODE, int COMP_CODE)
        {
            return ACCT_BALDataLayer.GetAllACCT_BALDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllIDWiseACCT_BALDetials(string COMP_CODE, string ACODE, string YRDT1)
        {
            return ACCT_BALDataLayer.GetAllIDWiseACCT_BALDetials(COMP_CODE, ACODE, YRDT1);
        }

        public static string DeleteACCOUNTS_BALDetailsByID(string COMP_CODE, string ACODE, string YRDT1)
        {
            return ACCT_BALDataLayer.DeleteACCOUNTS_BALDetailsByID(COMP_CODE, ACODE, YRDT1);
        }


    }

    public class BROKER_MASLogicLayer
    {
        string _COMP_CODE, _BRANCH_CODE, _BCODE, _BNAME, _BADD, _BADD2, _BADD3, _PHONE_O, _PHONE_M, _ACODE, _PER, _ACTIVE,
               _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public BROKER_MASLogicLayer()
        {
            _COMP_CODE = "";
            _BRANCH_CODE = "";
            _BCODE = "";
            _BNAME = "";
            _BADD = "";
            _BADD2 = "";
            _BADD3 = "";
            _PHONE_O = "";
            _PHONE_M = "";
            _ACODE = "";
            _PER = "";
            _ACTIVE = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string BCODE { get { return _BCODE; } set { _BCODE = value; } }
        public string BNAME { get { return _BNAME; } set { _BNAME = value; } }
        public string BADD { get { return _BADD; } set { _BADD = value; } }
        public string BADD2 { get { return _BADD2; } set { _BADD2 = value; } }
        public string BADD3 { get { return _BADD3; } set { _BADD3 = value; } }
        public string PHONE_O { get { return _PHONE_O; } set { _PHONE_O = value; } }
        public string PHONE_M { get { return _PHONE_M; } set { _PHONE_M = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string PER { get { return _PER; } set { _PER = value; } }
        public string ACTIVE { get { return _ACTIVE; } set { _ACTIVE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


        public static string InsertBROKERDetail(BROKER_MASLogicLayer PersonDetails)
        {
            return BROKER_MASDataLayer.InsertBROKERDetail(PersonDetails);
        }

        public static string UpdateBROKERDetails(BROKER_MASLogicLayer PersonDetails)
        {
            return BROKER_MASDataLayer.UpdateBROKERDetails(PersonDetails);
        }

        public static string DeleteBROKERDetailsByID(string ID)
        {
            return BROKER_MASDataLayer.DeleteBROKERDetailsByID(ID);
        }

        public static DataTable GetAllBROKERDetials(int USERCODE, int COMP_CODE)
        {
            return BROKER_MASDataLayer.GetAllBROKERDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllIDWiseBROKERDetials(string Id)
        {
            return BROKER_MASDataLayer.GetAllIDWiseBROKERDetials(Id);
        }

        public static DataTable GetAllBROKER_MASDetialsFor_DDL()
        {
            return BROKER_MASDataLayer.GetAllBROKER_MASDetialsFor_DDL();
        }

        public static DataTable GetAllBROKER_MASDetialsCompanyWiseFor_DDL(string Id)
        {
            return BROKER_MASDataLayer.GetAllBROKER_MASDetialsCompanyWiseFor_DDL(Id);
        }

        public static DataTable GetAllBROKERDetialsWiseComapnyAndBranch(string COMP_CODE, string BRANCH_CODE)
        {
            return BROKER_MASDataLayer.GetAllBROKERDetialsWiseComapnyAndBranch(COMP_CODE, BRANCH_CODE);
        }
    }


    public class STATE_MASLogicLayer
    {
        string _STATE_CODE, _STATE_NAME, _STATE_TYPE, _STATE_NO, _STATE_SHORT, _STATE_CAPITAL;

        public STATE_MASLogicLayer()
        {
            _STATE_CODE = "";
            _STATE_NAME = "";
            _STATE_TYPE = "";
            _STATE_NO = "";
            _STATE_SHORT = "";
            _STATE_CAPITAL = "";
        }

        public string STATE_CODE { get { return _STATE_CODE; } set { _STATE_CODE = value; } }
        public string STATE_NAME { get { return _STATE_NAME; } set { _STATE_NAME = value; } }
        public string STATE_TYPE { get { return _STATE_TYPE; } set { _STATE_TYPE = value; } }
        public string STATE_NO { get { return _STATE_NO; } set { _STATE_NO = value; } }
        public string STATE_SHORT { get { return _STATE_SHORT; } set { _STATE_SHORT = value; } }
        public string STATE_CAPITAL { get { return _STATE_CAPITAL; } set { _STATE_CAPITAL = value; } }


        public static string InsertSTATE_MASDetail(STATE_MASLogicLayer StateDetails)
        {
            return STATE_MASDataLayer.InsertSTATE_MASDetail(StateDetails);
        }

        public static string UpdateSTATE_MASDetails(STATE_MASLogicLayer StateDetails)
        {
            return STATE_MASDataLayer.UpdateSTATE_MASDetails(StateDetails);
        }

        public static string DeleteSTATE_MASDetailsByID(string ID)
        {
            return STATE_MASDataLayer.DeleteSTATE_MASDetailsByID(ID);
        }

        public static DataTable GetAllSTATE_MASDetials(int USERCODE, int COMP_CODE)
        {
            return STATE_MASDataLayer.GetAllSTATE_MASDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllIDWiseSTATE_MASDetials(string Id)
        {
            return STATE_MASDataLayer.GetAllIDWiseSTATE_MASDetials(Id);
        }

        public static DataTable GetAllSTATE_MASDetialsFor_DDL()
        {
            return STATE_MASDataLayer.GetAllSTATE_MASDetialsFor_DDL();
        }

    }


    public class PLACE_MASLogicLayer
    {
        string _comp_code, _branch_code, _STATE_CODE, _PLACE_CODE, _PLACE_NAME, _STD_CODE, _ROUTE_CODE, _PLACE_ORD;

        public PLACE_MASLogicLayer()
        {
            _comp_code = "";
            _branch_code = "";
            _STATE_CODE = "";
            _PLACE_CODE = "";
            _PLACE_NAME = "";
            _STD_CODE = "";
            _ROUTE_CODE = "";
            _PLACE_ORD = "";
        }
        public string comp_code { get { return _comp_code; } set { _comp_code = value; } }
        public string branch_code { get { return _branch_code; } set { _branch_code = value; } }
        public string STATE_CODE { get { return _STATE_CODE; } set { _STATE_CODE = value; } }
        public string PLACE_CODE { get { return _PLACE_CODE; } set { _PLACE_CODE = value; } }
        public string PLACE_NAME { get { return _PLACE_NAME; } set { _PLACE_NAME = value; } }
        public string STD_CODE { get { return _STD_CODE; } set { _STD_CODE = value; } }
        public string ROUTE_CODE { get { return _ROUTE_CODE; } set { _ROUTE_CODE = value; } }
        public string PLACE_ORD { get { return _PLACE_ORD; } set { _PLACE_ORD = value; } }


        public static string InsertPLACE_MASDetail(PLACE_MASLogicLayer PlaceDetails)
        {
            return PLACE_MASDataLayer.InsertPLACE_MASDetail(PlaceDetails);
        }

        public static string UpdatePLACE_MASDetails(PLACE_MASLogicLayer PlaceDetails)
        {
            return PLACE_MASDataLayer.UpdatePLACE_MASDetails(PlaceDetails);
        }

        public static string DeletePLACE_MASDetailsByID(string ID)
        {
            return PLACE_MASDataLayer.DeletePLACE_MASDetailsByID(ID);
        }

        public static DataTable GetAllPLACE_MASDetials(int USERCODE, int COMP_CODE)
        {
            return PLACE_MASDataLayer.GetAllPLACE_MASDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllIDWisePLACE_MASDetials(string Id)
        {
            return PLACE_MASDataLayer.GetAllIDWisePLACE_MASDetials(Id);
        }

        public static DataTable GetAllPLACE_MASDetialsFor_DDL()
        {
            return PLACE_MASDataLayer.GetAllPLACE_MASDetialsFor_DDL();
        }

    }


    public class ROUTE_MASLogicLayer
    {
        string _comp_code, _branch_code, _ROUTE_CODE, _ROUTE_NAME, _ROUTE_ORD;

        public ROUTE_MASLogicLayer()
        {
            _comp_code = "";
            _branch_code = "";
            _ROUTE_CODE = "";
            _ROUTE_NAME = "";
            _ROUTE_ORD = "";
        }

        public string comp_code { get { return _comp_code; } set { _comp_code = value; } }
        public string branch_code { get { return _branch_code; } set { _branch_code = value; } }
        public string ROUTE_CODE { get { return _ROUTE_CODE; } set { _ROUTE_CODE = value; } }
        public string ROUTE_NAME { get { return _ROUTE_NAME; } set { _ROUTE_NAME = value; } }
        public string ROUTE_ORD { get { return _ROUTE_ORD; } set { _ROUTE_ORD = value; } }


        public static string InsertROUTE_MASDetail(ROUTE_MASLogicLayer RouteDetails)
        {
            return ROUTE_MASDataLayer.InsertROUTE_MASDetail(RouteDetails);
        }
        public static string UpdateROUTE_MASDetails(ROUTE_MASLogicLayer RouteDetails)
        {
            return ROUTE_MASDataLayer.UpdateROUTE_MASDetails(RouteDetails);
        }

        public static string DeleteROUTE_MASDetailsByID(string ID)
        {
            return ROUTE_MASDataLayer.DeleteROUTE_MASDetailsByID(ID);
        }

        public static DataTable GetAllROUTE_MASDetials(int USERCODE, int COMP_CODE)
        {
            return ROUTE_MASDataLayer.GetAllROUTE_MASDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllIDWiseROUTE_MASDetials(string Id)
        {
            return ROUTE_MASDataLayer.GetAllIDWiseROUTE_MASDetials(Id);
        }

        public static DataTable GetAllROUTE_MASDetialsFor_DDL()
        {
            return ROUTE_MASDataLayer.GetAllROUTE_MASDetialsFor_DDL();
        }

    }


    public class TRANSPORT_MASLogicLayer
    {
        string _TCODE, _TNAME, _CONTACT_PER, _ADD1, _ADD2, _ADD3, _PHONE_O, _PHONE_M, _FAX, _EMAIL, _VEHICLE_NO, _MDLNO, _MDLSTATE, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public TRANSPORT_MASLogicLayer()
        {
            _TCODE = "";
            _TNAME = "";
            _CONTACT_PER = "";
            _ADD1 = "";
            _ADD2 = "";
            _ADD3 = "";
            _PHONE_O = "";
            _PHONE_M = "";
            _FAX = "";
            _EMAIL = "";
            _VEHICLE_NO = "";
            _MDLNO = "";
            _MDLSTATE = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
        }

        public string TCODE { get { return _TCODE; } set { _TCODE = value; } }
        public string TNAME { get { return _TNAME; } set { _TNAME = value; } }
        public string CONTACT_PER { get { return _CONTACT_PER; } set { _CONTACT_PER = value; } }
        public string ADD1 { get { return _ADD1; } set { _ADD1 = value; } }
        public string ADD2 { get { return _ADD2; } set { _ADD3 = value; } }
        public string ADD3 { get { return _ADD3; } set { _ADD3 = value; } }
        public string PHONE_O { get { return _PHONE_O; } set { _PHONE_O = value; } }
        public string PHONE_M { get { return _PHONE_M; } set { _PHONE_M = value; } }
        public string FAX { get { return _FAX; } set { _FAX = value; } }
        public string EMAIL { get { return _EMAIL; } set { _EMAIL = value; } }
        public string VEHICLE_NO { get { return _VEHICLE_NO; } set { _VEHICLE_NO = value; } }
        public string MDLNO { get { return _MDLNO; } set { _MDLNO = value; } }
        public string MDLSTATE { get { return _MDLSTATE; } set { _MDLSTATE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }

        public static string InsertTRANSPORT_MASDetail(TRANSPORT_MASLogicLayer TransportDetails)
        {
            return TRANSPORT_MASDataLayer.InsertTRANSPORT_MASDetail(TransportDetails);
        }

        public static string UpdateTRANSPORT_MASDetails(TRANSPORT_MASLogicLayer TransportDetails)
        {
            return TRANSPORT_MASDataLayer.UpdateTRANSPORT_MASDetails(TransportDetails);
        }

        public static string DeleteTRANSPORT_MASDetailsByID(string ID)
        {
            return TRANSPORT_MASDataLayer.DeleteTRANSPORT_MASDetailsByID(ID);
        }

        public static DataTable GetAllTRANSPORT_MASDetials(int USERCODE, int COMP_CODE)
        {
            return TRANSPORT_MASDataLayer.GetAllTRANSPORT_MASDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllIDWiseTRANSPORT_MASDetials(string Id)
        {
            return TRANSPORT_MASDataLayer.GetAllIDWiseTRANSPORT_MASDetials(Id);
        }

        public static DataTable GetAllTRANSPORT_MASDetialsFor_DDL()
        {
            return TRANSPORT_MASDataLayer.GetAllTRANSPORT_MASDetialsFor_DDL();
        }
    }


    public class CHARGES_MASLogicLayer
    {
        string _COMP_CODE, _CCODE, _NAME, _PER, _SIGN, _ACODE, _HSN_NO, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public CHARGES_MASLogicLayer()
        {
            _COMP_CODE = "";
            _CCODE = "";
            _NAME = "";
            _PER = "";
            _SIGN = "";
            _ACODE = "";
            _HSN_NO = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";

        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string CCODE { get { return _CCODE; } set { _CCODE = value; } }
        public string NAME { get { return _NAME; } set { _NAME = value; } }
        public string PER { get { return _PER; } set { _PER = value; } }
        public string SIGN { get { return _SIGN; } set { _SIGN = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string HSN_NO { get { return _HSN_NO; } set { _HSN_NO = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }

        public static string InsertCHARGESDetail(CHARGES_MASLogicLayer ChargesDetails)
        {
            return CHARGES_MASDataLayer.InsertCHARGESDetail(ChargesDetails);
        }

        public static string UpdateCHARGESDetails(CHARGES_MASLogicLayer ChargesDetails)
        {
            return CHARGES_MASDataLayer.UpdateCHARGESDetails(ChargesDetails);
        }
        public static string DeleteCHARGESDetailsByID(string ID)
        {
            return CHARGES_MASDataLayer.DeleteCHARGESDetailsByID(ID);
        }

        public static DataTable GetAllCHARGESDetials(int USERCODE, int COMP_CODE)
        {
            return CHARGES_MASDataLayer.GetAllCHARGESDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllIDWiseCHARGESDetials(string Id)
        {
            return CHARGES_MASDataLayer.GetAllIDWiseCHARGESDetials(Id);
        }

        public static DataTable GetAllCHARGESDetialsFor_DDL(string Id)
        {
            return CHARGES_MASDataLayer.GetAllCHARGESDetialsFor_DDL(Id);
        }

        public static DataTable GetAllCHARGESDetialsForComapnyWise_DDL(string COMP_CODE)
        {
            return CHARGES_MASDataLayer.GetAllCHARGESDetialsForComapnyWise_DDL(COMP_CODE);
        }

        public static DataTable CHARGES_MAS_CHARGES_RATEMAS_DetailByAccountPartyType(int CCODE, string PartyType)
        {
            return CHARGES_MASDataLayer.CHARGES_MAS_CHARGES_RATEMAS_DetailByAccountPartyType(CCODE, PartyType);
        }
    }


    public class CHARGES_RATEMASLogicLayer
    {
        string _COMP_CODE, _CCODE, _YRDT1, _GST_RATE, _CGST_RATE, _SGST_RATE, _IGST_RATE, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public CHARGES_RATEMASLogicLayer()
        {
            _COMP_CODE = "";
            _CCODE = "";
            _YRDT1 = "";
            _GST_RATE = "";
            _CGST_RATE = "";
            _SGST_RATE = "";
            _IGST_RATE = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string CCODE { get { return _CCODE; } set { _CCODE = value; } }
        public string YRDT1 { get { return _YRDT1; } set { _YRDT1 = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


        public static string InsertCHARGES_RATEMASDetail(CHARGES_RATEMASLogicLayer ChargesRateDetails)
        {
            return CHARGES_RATEMASDataLayer.InsertCHARGES_RATEMASDetail(ChargesRateDetails);
        }

        public static string UpdateCHARGES_RATEMASDetails(CHARGES_RATEMASLogicLayer ChargesRateDetails)
        {
            return CHARGES_RATEMASDataLayer.UpdateCHARGES_RATEMASDetails(ChargesRateDetails);
        }

    }


    public class MENU_MASLogicLayer
    {
        string _SYSCODE, _CODE, _NAME, _REF_CODE, _MENU_NAME, _MENU_ORD;

        public MENU_MASLogicLayer()
        {
            _SYSCODE = "";
            _CODE = "";
            _NAME = "";
            _REF_CODE = "";
            _MENU_NAME = "";
            _MENU_ORD = "";
        }

        public string SYSCODE { get { return _SYSCODE; } set { _SYSCODE = value; } }
        public string CODE { get { return _CODE; } set { _CODE = value; } }
        public string NAME { get { return _NAME; } set { _NAME = value; } }
        public string REF_CODE { get { return _REF_CODE; } set { _REF_CODE = value; } }
        public string MENU_NAME { get { return _MENU_NAME; } set { _MENU_NAME = value; } }
        public string MENU_ORD { get { return _MENU_ORD; } set { _MENU_ORD = value; } }


        public static string InsertMENU_MASDetail(MENU_MASLogicLayer MenuDetails)
        {
            return MENU_MASDataLayer.InsertMENU_MASDetail(MenuDetails);
        }

        public static string UpdateMENU_MASDetails(MENU_MASLogicLayer MenuDetails)
        {
            return MENU_MASDataLayer.UpdateMENU_MASDetails(MenuDetails);
        }

        public static string DeleteMENU_MASDetailsByID(string ID)
        {
            return MENU_MASDataLayer.DeleteMENU_MASDetailsByID(ID);
        }

        public static DataTable GetAllMENU_MASDetials(int USERCODE, int COMP_CODE)
        {
            return MENU_MASDataLayer.GetAllMENU_MASDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllIDWiseMENU_MASDetials(string Id)
        {
            return MENU_MASDataLayer.GetAllIDWiseMENU_MASDetials(Id);
        }

        public static DataTable GetAllMENU_MASDetialsFor_DDL()
        {
            return MENU_MASDataLayer.GetAllMENU_MASDetialsFor_DDL();
        }

        public static DataTable GetAllMENU_MASDetialsFor_Grid(int COMP_CODE, int USERCODE)
        {
            return MENU_MASDataLayer.GetAllMENU_MASDetialsFor_Grid(COMP_CODE, USERCODE);
        }

    }



    public class USER_RIGHTSLogicLayer
    {
        string _COMP_CODE, _USERCODE, _SYSCODE, _CODE, _REF_CODE, _MENU_VIEW, _REC_INS, _REC_UPD, _REC_DEL, _UNCONFIRM, _APPROVAL, _AUTHORISE;

        public USER_RIGHTSLogicLayer()
        {
            _COMP_CODE = "";
            _USERCODE = "";
            _SYSCODE = "";
            _CODE = "";
            _REF_CODE = "";
            _MENU_VIEW = "";
            _REC_INS = "";
            _REC_UPD = "";
            _REC_DEL = "";
            _UNCONFIRM = "";
            _APPROVAL = "";
            _AUTHORISE = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string USERCODE { get { return _USERCODE; } set { _USERCODE = value; } }
        public string SYSCODE { get { return _SYSCODE; } set { _SYSCODE = value; } }
        public string CODE { get { return _CODE; } set { _CODE = value; } }
        public string REF_CODE { get { return _REF_CODE; } set { _REF_CODE = value; } }
        public string MENU_VIEW { get { return _MENU_VIEW; } set { _MENU_VIEW = value; } }
        public string REC_INS { get { return _REC_INS; } set { _REC_INS = value; } }
        public string REC_UPD { get { return _REC_UPD; } set { _REC_UPD = value; } }
        public string REC_DEL { get { return _REC_DEL; } set { _REC_DEL = value; } }
        public string UNCONFIRM { get { return _UNCONFIRM; } set { _UNCONFIRM = value; } }
        public string APPROVAL { get { return _APPROVAL; } set { _APPROVAL = value; } }
        public string AUTHORISE { get { return _AUTHORISE; } set { _AUTHORISE = value; } }

        public static string InsertUSER_RIGHTSDetail(USER_RIGHTSLogicLayer UserDetail, string Detail)
        {
            return USER_RIGHTSDataLayer.InsertUSER_RIGHTSDetail(UserDetail, Detail);
        }

    }

    public class EXCISE_RATEMASLogicLayer
    {
        string _TRAN_DATE, _TRAN_NO, _FRDT, _TODT, _EX_DUTY_PER, _EX_DUTY_TITLE, _EX_CESS_PER, _EX_CESS_TITLE, _EX_SHCESS_PER, _EX_SHCESS_TITLE, _GST_RATE, _CGST_RATE,
               _SGST_RATE, _IGST_RATE, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public EXCISE_RATEMASLogicLayer()
        {
            _TRAN_DATE = "";
            _TRAN_NO = "";
            _FRDT = "";
            _TODT = "";
            _EX_DUTY_PER = "";
            _EX_DUTY_TITLE = "";
            _EX_CESS_PER = "";
            _EX_CESS_TITLE = "";
            _EX_SHCESS_PER = "";
            _EX_SHCESS_TITLE = "";
            _GST_RATE = "";
            _CGST_RATE = "";
            _SGST_RATE = "";
            _IGST_RATE = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
        }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string FRDT { get { return _FRDT; } set { _FRDT = value; } }
        public string TODT { get { return _TODT; } set { _TODT = value; } }
        public string EX_DUTY_PER { get { return _EX_DUTY_PER; } set { _EX_DUTY_PER = value; } }
        public string EX_DUTY_TITLE { get { return _EX_DUTY_TITLE; } set { _EX_DUTY_TITLE = value; } }
        public string EX_CESS_PER { get { return _EX_CESS_PER; } set { _EX_CESS_PER = value; } }
        public string EX_CESS_TITLE { get { return _EX_CESS_TITLE; } set { _EX_CESS_TITLE = value; } }
        public string EX_SHCESS_PER { get { return _EX_SHCESS_PER; } set { _EX_SHCESS_PER = value; } }
        public string EX_SHCESS_TITLE { get { return _EX_SHCESS_TITLE; } set { _EX_SHCESS_TITLE = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


        public static string InsertEXCISE_RATEMASDetail(EXCISE_RATEMASLogicLayer ExciseRateDetails)
        {
            return EXCISE_RATEMASDataLayer.InsertEXCISE_RATEMASDetail(ExciseRateDetails);
        }

        public static string UpdateEXCISE_RATEMASDetail(EXCISE_RATEMASLogicLayer ExciseRateDetails)
        {
            return EXCISE_RATEMASDataLayer.UpdateEXCISE_RATEMASDetail(ExciseRateDetails);
        }

        public static string DeleteCHARGESDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {
            return EXCISE_RATEMASDataLayer.DeleteEXCISE_RATEMASDetailsByID(TRAN_NO, TRAN_DATE);
        }


        public static DataTable GetAllEXCISE_RATEMASDetials(int USERCODE, int COMP_CODE)
        {
            return EXCISE_RATEMASDataLayer.GetAllEXCISE_RATEMASDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllIDWiseEXCISE_RATEMASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return EXCISE_RATEMASDataLayer.GetAllIDWiseEXCISE_RATEMASDetials(TRAN_NO, TRAN_DATE);
        }
    }



    public class HSNCODE_MASLogicLayer

    {

        string _COMP_CODE, _HSN_CODE, _HSN_NO, _HSN_DESC, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public HSNCODE_MASLogicLayer()
        {
            _COMP_CODE = "  ";
            _HSN_CODE = "  ";
            _HSN_NO = "  ";
            _HSN_DESC = "  ";
            _INS_USERID = "  ";
            _INS_TERMINAL = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_TERMINAL = "  ";
            _UPD_DATE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string HSN_CODE { get { return _HSN_CODE; } set { _HSN_CODE = value; } }
        public string HSN_NO { get { return _HSN_NO; } set { _HSN_NO = value; } }
        public string HSN_DESC { get { return _HSN_DESC; } set { _HSN_DESC = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


        public static string InsertHSNCODE_MASDetials(HSNCODE_MASLogicLayer HSNCODE_MASDetail)
        {
            return HSNCODE_MASDataLayer.InsertHSNCODE_MASDetials(HSNCODE_MASDetail);
        }

        public static string UpdateHSNCODE_MASDetail(HSNCODE_MASLogicLayer HSNCODE_MASDetail)
        {
            return HSNCODE_MASDataLayer.UpdateHSNCODE_MASDetail(HSNCODE_MASDetail);
        }

        public static DataTable GetAllHSNCODE_MASDetials(int COMP_CODE, int USERCODE)
        {
            return HSNCODE_MASDataLayer.GetAllHSNCODE_MASDetials(COMP_CODE, USERCODE);
        }

        public static string DeleteHSNCODE_MASDetialsByID(string ID)
        {
            return HSNCODE_MASDataLayer.DeleteHSNCODE_MASDetialsByID(ID);
        }

        public static DataTable GetAllIDWiseHSNCODE_MASDetials(string Id)
        {
            return HSNCODE_MASDataLayer.GetAllIDWiseHSNCODE_MASDetials(Id);
        }
    }


    public class UOM_MASLogicLayer
    {
        string _UOM, _UOM_DESC, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public UOM_MASLogicLayer()
        {
            _UOM = "";
            _UOM_DESC = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
        }

        public string UOM { get { return _UOM; } set { _UOM = value; } }
        public string UOM_DESC { get { return _UOM_DESC; } set { _UOM_DESC = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }

        public static string InsertUOM_MASDetail(UOM_MASLogicLayer UOM_MASDetails)
        {
            return UOM_MASDataLayer.InsertUOM_MASDetail(UOM_MASDetails);
        }

        public static string UpdateUOM_MASDetail(UOM_MASLogicLayer UOM_MASDetails)
        {
            return UOM_MASDataLayer.UpdateUOM_MASDetail(UOM_MASDetails);
        }

        public static string DeleteUOM_MASDetailByID(string ID)
        {
            return UOM_MASDataLayer.DeleteUOM_MASDetailByID(ID);
        }

        public static DataTable GetAllUOM_MASDetail(int COMP_CODE, int USERCODE)
        {
            return UOM_MASDataLayer.GetAllUOM_MASDetail(COMP_CODE, USERCODE);
        }

        public static DataTable GetAllIDWiseUOM_MASDetail(string Id)
        {
            return UOM_MASDataLayer.GetAllIDWiseUOM_MASDetail(Id);
        }

        public static DataTable GetAllUOM_MASDetialsFor_DDL()
        {
            return UOM_MASDataLayer.GetAllUOM_MASDetialsFor_DDL();
        }
    }


    public class STOCKCategory_MASLogicLayer
    {
        string _CAT_CODE, _CAT_NAME, _ACTIVE, _PRODUCT_NO, _PRODUCT_DESC, _ORD_NO, _REF_CAT_CODE, _CAT_TYPE, _RW_TYPE, _COMP_CODE, _CAT_CETHNO,
               _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public STOCKCategory_MASLogicLayer()
        {
            _CAT_CODE = "";
            _CAT_NAME = "";
            _ACTIVE = "";
            _PRODUCT_NO = "";
            _PRODUCT_DESC = "";
            _ORD_NO = "";
            _REF_CAT_CODE = "";
            _CAT_TYPE = "";
            _RW_TYPE = "";
            _COMP_CODE = "";
            _CAT_CETHNO = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
        }

        public string CAT_CODE { get { return _CAT_CODE; } set { _CAT_CODE = value; } }
        public string CAT_NAME { get { return _CAT_NAME; } set { _CAT_NAME = value; } }
        public string ACTIVE { get { return _ACTIVE; } set { _ACTIVE = value; } }
        public string PRODUCT_NO { get { return _PRODUCT_NO; } set { _PRODUCT_NO = value; } }
        public string PRODUCT_DESC { get { return _PRODUCT_DESC; } set { _PRODUCT_DESC = value; } }
        public string ORD_NO { get { return _ORD_NO; } set { _ORD_NO = value; } }
        public string REF_CAT_CODE { get { return _REF_CAT_CODE; } set { _REF_CAT_CODE = value; } }
        public string CAT_TYPE { get { return _CAT_TYPE; } set { _CAT_TYPE = value; } }
        public string RW_TYPE { get { return _RW_TYPE; } set { _RW_TYPE = value; } }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string CAT_CETHNO { get { return _CAT_CETHNO; } set { _CAT_CETHNO = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }

        public static string InsertSTOCKCategory_MASDetail(STOCKCategory_MASLogicLayer StockCat_MASDetails)
        {
            return STOCKCategory_MASDataLayer.InsertSTOCKCategory_MASDetail(StockCat_MASDetails);
        }

        public static string UpdateSTOCKCategory_MASDetail(STOCKCategory_MASLogicLayer StockCat_MASDetails)
        {
            return STOCKCategory_MASDataLayer.UpdateSTOCKCategory_MASDetail(StockCat_MASDetails);
        }

        public static string DeleteSTOCKCategory_MASDetailsByID(string CAT_CODE)
        {
            return STOCKCategory_MASDataLayer.DeleteSTOCKCategory_MASDetailsByID(CAT_CODE);
        }

        public static DataTable GetAllSTOCKCategory_MASDetails(int COMP_CODE, int USERCODE)
        {
            return STOCKCategory_MASDataLayer.GetAllSTOCKCategory_MASDetails(COMP_CODE, USERCODE);
        }

        public static DataTable GetAllIDWiseSTOCKCategory_MASDetail(string CAT_CODE)
        {
            return STOCKCategory_MASDataLayer.GetAllIDWiseSTOCKCategory_MASDetail(CAT_CODE);
        }

        public static DataTable GetAllSTOCK_CATAGORYDetialsFor_DDL()
        {
            return STOCKCategory_MASDataLayer.GetAllSTOCK_CATAGORYDetialsFor_DDL();
        }

        public static DataTable GetAllSTOCKCategory_MASDetailWiseCompany(string COMP_CODE)
        {
            return STOCKCategory_MASDataLayer.GetAllSTOCKCategory_MASDetailWiseCompany(COMP_CODE);
        }
    }

    public class STOCK_MASLogicLayer
    {
        string _SCODE, _SNAME, _PART_NO, _UOM, _CAT_CODE, _MIN_QTY, _MAX_QTY, _C_ACODE, _S_ACODE, _O_ACODE, _ACTIVE, _PROD_CODE, _COMP_CODE, _ORDER_QTY,
               _PRODUCT_DESC, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE, _ACODE, _HSN_NO;

        public STOCK_MASLogicLayer()
        {
            _SCODE = "";
            _SNAME = "";
            _PART_NO = "";
            _UOM = "";
            _CAT_CODE = "";
            _MIN_QTY = "";
            _MAX_QTY = "";
            _C_ACODE = "";
            _S_ACODE = "";
            _O_ACODE = "";
            _ACTIVE = "";
            _PROD_CODE = "";
            _COMP_CODE = "";
            _ORDER_QTY = "";
            _PRODUCT_DESC = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
            _ACODE = "";
            _HSN_NO = "";
        }

        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string SNAME { get { return _SNAME; } set { _SNAME = value; } }
        public string PART_NO { get { return _PART_NO; } set { _PART_NO = value; } }
        public string UOM { get { return _UOM; } set { _UOM = value; } }
        public string CAT_CODE { get { return _CAT_CODE; } set { _CAT_CODE = value; } }
        public string MIN_QTY { get { return _MIN_QTY; } set { _MIN_QTY = value; } }
        public string MAX_QTY { get { return _MAX_QTY; } set { _MAX_QTY = value; } }
        public string C_ACODE { get { return _C_ACODE; } set { _C_ACODE = value; } }
        public string S_ACODE { get { return _S_ACODE; } set { _S_ACODE = value; } }
        public string O_ACODE { get { return _O_ACODE; } set { _O_ACODE = value; } }
        public string ACTIVE { get { return _ACTIVE; } set { _ACTIVE = value; } }
        public string PROD_CODE { get { return _PROD_CODE; } set { _PROD_CODE = value; } }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string ORDER_QTY { get { return _ORDER_QTY; } set { _ORDER_QTY = value; } }
        public string PRODUCT_DESC { get { return _PRODUCT_DESC; } set { _PRODUCT_DESC = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string HSN_NO { get { return _HSN_NO; } set { _HSN_NO = value; } }

        public static string InsertSTOCK_MASDetail(STOCK_MASLogicLayer StockMasDetails, STOCK_RATEMASLogicLayer strXMLStockRateMasDetails, string DetailMap)
        {
            return STOCK_MASDataLayer.InsertSTOCK_MASDetail(StockMasDetails, strXMLStockRateMasDetails, DetailMap);
        }

        public static string UpdateSTOCK_MASDetail(STOCK_MASLogicLayer StockMasDetails, STOCK_RATEMASLogicLayer strXMLStockRateMasDetails, string DetailMap)
        {
            return STOCK_MASDataLayer.UpdateSTOCK_MASDetail(StockMasDetails, strXMLStockRateMasDetails, DetailMap);
        }

        public static string GetMaxProductCodeFromStaockMaster()
        {
            return STOCK_MASDataLayer.GetMaxProductCodeFromStaockMaster();
        }
        public static string DeleteSTOCK_MASDetailsByID(string ID)
        {
            return STOCK_MASDataLayer.DeleteSTOCK_MASDetailsByID(ID);
        }

        public static DataTable GetAllSTOCK_MASDetails(int COMP_CODE, int USERCODE)
        {
            return STOCK_MASDataLayer.GetAllSTOCK_MASDetails(COMP_CODE, USERCODE);
        }

        public static DataSet GetAllIDWiseSTOCK_MASDetail(string ID)
        {
            return STOCK_MASDataLayer.GetAllIDWiseSTOCK_MASDetail(ID);
        }
        public static DataTable STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType(int SCODE, string PartyType)
        {
            return STOCK_MASDataLayer.STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType(SCODE, PartyType);
        }
        public static DataTable GetAllSTOCK_MASDetialsFor_DDL()
        {
            return STOCK_MASDataLayer.GetAllSTOCK_MASDetialsFor_DDL();
        }

        public static DataTable GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(string Id)
        {
            return STOCK_MASDataLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Id);
        }

        public static DataTable GetAllSTOCK_NAMEAUTODetialsWIiseCompany(string comp_code, string searchtext)
        {
            return STOCK_MASDataLayer.GetAllSTOCK_NAMEAUTODetialsWIiseCompany(comp_code, searchtext);
        }
    }

    public class STOCK_RATEMASLogicLayer
    {
        string _COMP_CODE, _SCODE, _YRDT1, _PUR_RATE, _SAL_RATE, _VAT_RATE, _ADD_VAT_RATE, _CST_RATE, _CSTFULL_RATE, _GST_RATE, _CGST_RATE, _SGST_RATE,
                _IGST_RATE, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public STOCK_RATEMASLogicLayer()
        {
            _COMP_CODE = "";
            _SCODE = "";
            _YRDT1 = "";
            _PUR_RATE = "";
            _SAL_RATE = "";
            _VAT_RATE = "";
            _ADD_VAT_RATE = "";
            _CST_RATE = "";
            _CSTFULL_RATE = "";
            _GST_RATE = "";
            _CGST_RATE = "";
            _SGST_RATE = "";
            _IGST_RATE = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string YRDT1 { get { return _YRDT1; } set { _YRDT1 = value; } }
        public string PUR_RATE { get { return _PUR_RATE; } set { _PUR_RATE = value; } }
        public string SAL_RATE { get { return _SAL_RATE; } set { _SAL_RATE = value; } }
        public string VAT_RATE { get { return _VAT_RATE; } set { _VAT_RATE = value; } }
        public string ADD_VAT_RATE { get { return _ADD_VAT_RATE; } set { _ADD_VAT_RATE = value; } }
        public string CST_RATE { get { return _CST_RATE; } set { _CST_RATE = value; } }
        public string CSTFULL_RATE { get { return _CSTFULL_RATE; } set { _CSTFULL_RATE = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


        public static string InsertSTOCK_RATEMASDetail(STOCK_RATEMASLogicLayer StockRateMasDetails)
        {
            return STOCK_RATEMASDataLayer.InsertSTOCK_RATEMASDetail(StockRateMasDetails);
        }

        public static string UpdateSTOCK_RATEMASDetail(STOCK_RATEMASLogicLayer StockRateMasDetails)
        {
            return STOCK_RATEMASDataLayer.UpdateSTOCK_RATEMASDetail(StockRateMasDetails);
        }

    }



    public class STOCK_BALLogicLayer
    {
        string _COMP_CODE, _SCODE, _YRDT1, _OP_QTY, _OP_RATE, _CUR_BAL, _CUR_RATE, _PUR_RATE, _SAL_RATE, _VAT_RATE, _ADD_VAT_RATE, _OP_QTY_D, _OP_RATE_D, _BRANCH_CODE, _MIN_QTY,
                  _MAX_QTY, _ORDER_QTY, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public STOCK_BALLogicLayer()
        {
            _COMP_CODE = "";
            _SCODE = "";
            _YRDT1 = "";
            _OP_QTY = "";
            _OP_RATE = "";
            _CUR_BAL = "";
            _CUR_RATE = "";
            _PUR_RATE = "";
            _SAL_RATE = "";
            _VAT_RATE = "";
            _ADD_VAT_RATE = "";
            _OP_QTY_D = "";
            _OP_RATE_D = "";
            _BRANCH_CODE = "";
            _MIN_QTY = "";
            _MAX_QTY = "";
            _ORDER_QTY = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string YRDT1 { get { return _YRDT1; } set { _YRDT1 = value; } }
        public string OP_QTY { get { return _OP_QTY; } set { _OP_QTY = value; } }
        public string OP_RATE { get { return _OP_RATE; } set { _OP_RATE = value; } }
        public string CUR_BAL { get { return _CUR_BAL; } set { _CUR_BAL = value; } }
        public string CUR_RATE { get { return _CUR_RATE; } set { _CUR_RATE = value; } }
        public string PUR_RATE { get { return _PUR_RATE; } set { _PUR_RATE = value; } }
        public string SAL_RATE { get { return _SAL_RATE; } set { _SAL_RATE = value; } }
        public string VAT_RATE { get { return _VAT_RATE; } set { _VAT_RATE = value; } }
        public string ADD_VAT_RATE { get { return _ADD_VAT_RATE; } set { _ADD_VAT_RATE = value; } }
        public string OP_QTY_D { get { return _OP_QTY_D; } set { _OP_QTY_D = value; } }
        public string OP_RATE_D { get { return _OP_RATE_D; } set { _OP_RATE_D = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string MIN_QTY { get { return _MIN_QTY; } set { _MIN_QTY = value; } }
        public string MAX_QTY { get { return _MAX_QTY; } set { _MAX_QTY = value; } }
        public string ORDER_QTY { get { return _ORDER_QTY; } set { _ORDER_QTY = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


        public static string InsertSTOCK_BALDetail(STOCK_BALLogicLayer StockBalDetails)
        {
            return STOCK_BALDataLayer.InsertSTOCK_BALDetail(StockBalDetails);
        }

        public static DataTable GetAllSTOCK_BALDetails(int COMP_CODE, int USERCODE)
        {
            return STOCK_BALDataLayer.GetAllSTOCK_BALDetails(COMP_CODE, USERCODE);
        }

        public static DataTable GetAllSTOCK_BALDetailByCompany(string COMP_CODE)
        {
            return STOCK_BALDataLayer.GetAllSTOCK_BALDetailByCompany(COMP_CODE);
        }
        public static DataTable GetAllSTOCK_PRICEDetailByCompany(string COMP_CODE, DateTime FRMDATE, DateTime ToDate)
        {
            return STOCK_BALDataLayer.GetAllSTOCK_PRICEDetailByCompany(COMP_CODE, FRMDATE, ToDate);
        }

        public static DataTable GetAll_SCODEWise_STOCK_BAL(string SCODE)
        {
            return STOCK_BALDataLayer.GetAll_SCODEWise_STOCK_BAL(SCODE);
        }

    }


    public class STOCK_PRICE_MASLogicLayer
    {
        string _COMP_CODE, _SRNO, _FRDT, _TODT, _REMARK, _ACTIVE, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public STOCK_PRICE_MASLogicLayer()
        {
            _COMP_CODE = "";
            _SRNO = "";
            _FRDT = "";
            _TODT = "";
            _REMARK = "";
            _ACTIVE = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string FRDT { get { return _FRDT; } set { _FRDT = value; } }
        public string TODT { get { return _TODT; } set { _TODT = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string ACTIVE { get { return _ACTIVE; } set { _ACTIVE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }

        public static string InsertSTOCK_PRICE_MASDetail(STOCK_PRICE_MASLogicLayer PRICE_MASDetails, string DetailMap)
        {
            return STOCK_PRICE_MASDataLayer.InsertSTOCK_PRICE_MASDetail(PRICE_MASDetails, DetailMap);
        }

        public static string UpdateSTOCK_PRICE_MASDetail(STOCK_PRICE_MASLogicLayer PRICE_MASDetails, string DetailMap)
        {
            return STOCK_PRICE_MASDataLayer.UpdateSTOCK_PRICE_MASDetail(PRICE_MASDetails, DetailMap);
        }

        public static string DeleteSTOCK_PRISE_MASDetailsByID(string ID)
        {
            return STOCK_PRICE_MASDataLayer.DeleteSTOCK_PRISE_MASDetailsByID(ID);
        }
        public static DataTable GetAllSTOCK_PRICE_MASDetail(int COMP_CODE, int USERCODE)
        {
            return STOCK_PRICE_MASDataLayer.GetAllSTOCK_PRICE_MASDetail(COMP_CODE, USERCODE);
        }

        public static DataSet GetAllIDWiseSTOCK_PRICE_MASDetail(string ID)
        {
            return STOCK_PRICE_MASDataLayer.GetAllIDWiseSTOCK_PRICE_MASDetail(ID);
        }

        public static DataTable GetAllWiseSRNO_PRICE_MASDetail(string ID)
        {
            return STOCK_PRICE_MASDataLayer.GetAllWiseSRNO_PRICE_MASDetail(ID);
        }
    }

    public class STOCK_PRICE_DETLogicLayer
    {
        string _COMP_CODE, _SRNO, _SCODE, _RATE, _DIS_PER, _DIS_RATE, _DEL_PER, _DEL_RATE, _MAX_PER, _MAX_RATE, _REMARK, _INS_USERID, _INS_TERMINAL,
               _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public STOCK_PRICE_DETLogicLayer()
        {
            _COMP_CODE = "";
            _SRNO = "";
            _SCODE = "";
            _RATE = "";
            _DIS_PER = "";
            _DIS_RATE = "";
            _DEL_PER = "";
            _DEL_RATE = "";
            _MAX_PER = "";
            _MAX_RATE = "";
            _REMARK = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string DIS_PER { get { return _DIS_PER; } set { _DIS_PER = value; } }
        public string DIS_RATE { get { return _DIS_RATE; } set { _DIS_RATE = value; } }
        public string DEL_PER { get { return _DEL_PER; } set { _DEL_PER = value; } }
        public string DEL_RATE { get { return _DEL_RATE; } set { _DEL_RATE = value; } }
        public string MAX_PER { get { return _MAX_PER; } set { _MAX_PER = value; } }
        public string MAX_RATE { get { return _MAX_RATE; } set { _MAX_RATE = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
    }


    public class STOCK_BRANDTYPEMASLogicLayer
    {
        string _COMP_CODE, _BRANDTYPE_CODE, _BRANDTYPE_NAME, _BRANDTYPE_REMARK, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public STOCK_BRANDTYPEMASLogicLayer()
        {
            _COMP_CODE = "";
            _BRANDTYPE_CODE = "";
            _BRANDTYPE_NAME = "";
            _BRANDTYPE_REMARK = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANDTYPE_CODE { get { return _BRANDTYPE_CODE; } set { _BRANDTYPE_CODE = value; } }
        public string BRANDTYPE_NAME { get { return _BRANDTYPE_NAME; } set { _BRANDTYPE_NAME = value; } }
        public string BRANDTYPE_REMARK { get { return _BRANDTYPE_REMARK; } set { _BRANDTYPE_REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }

        public static string InsertSTOCK_BRANDTYPEMASDetail(STOCK_BRANDTYPEMASLogicLayer StockBrandMasDetails, string DetailMap)
        {
            return STOCK_BRANDTYPEMASDataLayer.InsertSTOCK_BRANDTYPEMASDetail(StockBrandMasDetails, DetailMap);
        }

        public static string UpdateSTOCK_BRANDTYPEMASDetail(STOCK_BRANDTYPEMASLogicLayer StockBrandMasDetails, string DetailMap)
        {
            return STOCK_BRANDTYPEMASDataLayer.UpdateSTOCK_BRANDTYPEMASDetail(StockBrandMasDetails, DetailMap);
        }

        public static string DeleteSTOCK_BRANDTYPEMASDetailsByID(string ID)
        {
            return STOCK_BRANDTYPEMASDataLayer.DeleteSTOCK_BRANDTYPEMASDetailsByID(ID);
        }
        public static DataSet GetAllIDWiseSTOCK_BRANDTYPEMASDetail(string ID)
        {
            return STOCK_BRANDTYPEMASDataLayer.GetAllIDWiseSTOCK_BRANDTYPEMASDetail(ID);
        }
        public static DataTable GetAllSTOCK_BRANDTYEPMASDetials(int COMP_CODE, int USERCODE)
        {
            return STOCK_BRANDTYPEMASDataLayer.GetAllSTOCK_BRANDTYEPMASDetials(COMP_CODE, USERCODE);
        }

        public static DataTable GetAllSTOCK_BRANDTYPEMASDetialsFor_DDL()
        {
            return STOCK_BRANDTYPEMASDataLayer.GetAllSTOCK_BRANDTYPEMASDetialsFor_DDL();
        }


        public static DataTable GetSTOCK_BRANDTYPEMASCompanyWiseFor_Ddl(string Id)
        {
            return STOCK_BRANDTYPEMASDataLayer.GetSTOCK_BRANDTYPEMASCompanyWiseFor_Ddl(Id);
        }


        public static DataTable GetStockBrandTypeMasterDetailFilterByBrandTypeCode(string COMP_CODE, string BRANDTYPE_CODE)
        {
            return STOCK_BRANDTYPEMASDataLayer.GetStockBrandTypeMasterDetailFilterByBrandTypeCode(COMP_CODE, BRANDTYPE_CODE);
        }
    }

    public class STOCK_BRANDTYPDETLogicLayer
    {
        string _COMP_CODE, _BRANDTYPE_CODE, _SRNO, _DESC_NAME, _RESULT_1_1, _RESULT_1_2, _RESULT_2_1, _RESULT_2_2, _RESULT_3_1, _RESULT_3_2, _PRINT_FLAG_1, _PRINT_FLAG_2,
               _PRINT_FLAG_3, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public STOCK_BRANDTYPDETLogicLayer()
        {
            _COMP_CODE = "";
            _BRANDTYPE_CODE = "";
            _SRNO = "";
            _DESC_NAME = "";
            _RESULT_1_1 = "";
            _RESULT_1_2 = "";
            _RESULT_2_1 = "";
            _RESULT_2_2 = "";
            _RESULT_3_1 = "";
            _RESULT_3_2 = "";
            _PRINT_FLAG_1 = "";
            _PRINT_FLAG_2 = "";
            _PRINT_FLAG_3 = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANDTYPE_CODE { get { return _BRANDTYPE_CODE; } set { _BRANDTYPE_CODE = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string DESC_NAME { get { return _DESC_NAME; } set { _DESC_NAME = value; } }
        public string RESULT_1_1 { get { return _RESULT_1_1; } set { _RESULT_1_1 = value; } }
        public string RESULT_1_2 { get { return _RESULT_1_2; } set { _RESULT_1_2 = value; } }
        public string RESULT_2_1 { get { return _RESULT_2_1; } set { _RESULT_2_1 = value; } }
        public string RESULT_2_2 { get { return _RESULT_2_2; } set { _RESULT_2_2 = value; } }
        public string RESULT_3_1 { get { return _RESULT_3_1; } set { _RESULT_3_1 = value; } }
        public string RESULT_3_2 { get { return _RESULT_3_2; } set { _RESULT_3_2 = value; } }
        public string PRINT_FLAG_1 { get { return _PRINT_FLAG_1; } set { _PRINT_FLAG_1 = value; } }
        public string PRINT_FLAG_2 { get { return _PRINT_FLAG_2; } set { _PRINT_FLAG_2 = value; } }
        public string PRINT_FLAG_3 { get { return _PRINT_FLAG_3; } set { _PRINT_FLAG_3 = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }



        public static DataTable GetAllSTOCK_BRANDTYPEDETAILSDetailByCompany(string COMP_CODE)
        {
            return STOCK_BRANDTYPDETDataLayer.GetAllSTOCK_BRANDTYPEDETAILSDetailByCompany(COMP_CODE);
        }

        public static DataTable GetAll_BRANDTYPE_CODEWise_BRANDTYPE_DETAILS(string Id)
        {
            return STOCK_BRANDTYPDETDataLayer.GetAll_BRANDTYPE_CODEWise_BRANDTYPE_DETAILS(Id);
        }
    }


    public class JOB_COMPMASLogicLayer
    {
        string _COMP_CODE, _BRANDTYPE_CODE, _COMPLAIN_CODE, _COMPLAIN_DESC, _COMPLAIN_CHECK, _INS_USERID, _INS_DATE, _INS_TERMINAL, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public JOB_COMPMASLogicLayer()
        {
            _COMP_CODE = "";
            _BRANDTYPE_CODE = "";
            _COMPLAIN_CODE = "";
            _COMPLAIN_DESC = "";
            _COMPLAIN_CHECK = "";
            _INS_USERID = "";
            _INS_DATE = "";
            _INS_TERMINAL = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANDTYPE_CODE { get { return _BRANDTYPE_CODE; } set { _BRANDTYPE_CODE = value; } }
        public string COMPLAIN_CODE { get { return _COMPLAIN_CODE; } set { _COMPLAIN_CODE = value; } }
        public string COMPLAIN_DESC { get { return _COMPLAIN_DESC; } set { _COMPLAIN_DESC = value; } }
        public string COMPLAIN_CHECK { get { return _COMPLAIN_CHECK; } set { _COMPLAIN_CHECK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }

        public static string InsertJOB_COMPLAIN_MASDetail(JOB_COMPMASLogicLayer JobComplainMasDetails)
        {
            return JOB_COMPMASDataLayer.InsertJOB_COMPLAIN_MASDetail(JobComplainMasDetails);
        }

        public static string UpdateJOB_COMPLAIN_MASDetail(JOB_COMPMASLogicLayer JobComplainMasDetails)
        {
            return JOB_COMPMASDataLayer.UpdateJOB_COMPLAIN_MASDetail(JobComplainMasDetails);
        }

        public static string DeleteJOB_COMPLAIN_MASDetailByID(string ID)
        {
            return JOB_COMPMASDataLayer.DeleteJOB_COMPLAIN_MASDetailByID(ID);
        }

        public static DataTable GetAllJOB_COMPLAIN_MASDetails(int COMP_CODE, int USERCODE)
        {
            return JOB_COMPMASDataLayer.GetAllJOB_COMPLAIN_MASDetails(COMP_CODE, USERCODE);
        }

        public static DataTable GetAllIDWiseJOB_COMPLAIN_MASDetail(string ID)
        {
            return JOB_COMPMASDataLayer.GetAllIDWiseJOB_COMPLAIN_MASDetail(ID);
        }

        public static DataTable GetAllJOB_COMPLAIN_MASDetialsFor_DDL()
        {
            return JOB_COMPMASDataLayer.GetAllJOB_COMPLAIN_MASDetialsFor_DDL();
        }

        public static DataTable GetAllJOB_COMPLAIN_MASDetialsByCompany(string COMP_CODE)
        {
            return JOB_COMPMASDataLayer.GetAllJOB_COMPLAIN_MASDetialsByCompany(COMP_CODE);
        }
    }

    public class BRAND_COMPMASLogicLayer
    {
        string _COMP_CODE, _COMPLAIN_SRNO, _BRANDTYPE_CODE, _COMPLAIN_CODE, _INS_USERID, _INS_DATE, _INS_TERMINAL, _UPD_USERID, _UPD_DATE, _UPD_TERMINAL;

        public BRAND_COMPMASLogicLayer()
        {
            _COMP_CODE = "";
            _COMPLAIN_SRNO = "";
            _BRANDTYPE_CODE = "";
            _COMPLAIN_CODE = "";
            _INS_USERID = "";
            _INS_DATE = "";
            _INS_TERMINAL = "";
            _UPD_USERID = "";
            _UPD_DATE = "";
            _UPD_TERMINAL = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string COMPLAIN_SRNO { get { return _COMPLAIN_SRNO; } set { _COMPLAIN_SRNO = value; } }
        public string BRANDTYPE_CODE { get { return _BRANDTYPE_CODE; } set { _BRANDTYPE_CODE = value; } }
        public string COMPLAIN_CODE { get { return _COMPLAIN_CODE; } set { _COMPLAIN_CODE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }

        public static string InsertBRAND_COMPLAIN_MASDetail(BRAND_COMPMASLogicLayer BrandComplainMasDetails)
        {
            return BRAND_COMPMASDataLayer.InsertBRAND_COMPLAIN_MASDetail(BrandComplainMasDetails);
        }

        public static string UpdateBRAND_COMPLAIN_MASDetail(BRAND_COMPMASLogicLayer BrandComplainMasDetails)
        {
            return BRAND_COMPMASDataLayer.UpdateBRAND_COMPLAIN_MASDetail(BrandComplainMasDetails);
        }

        public static string DeleteBRAND_COMPLAIN_MASDetailByID(string ID)
        {
            return BRAND_COMPMASDataLayer.DeleteBRAND_COMPLAIN_MASDetailByID(ID);
        }

        public static DataTable GetAllBRAND_COMPLAIN_MASDetail(int COMP_CODE, int USERCODE)
        {
            return BRAND_COMPMASDataLayer.GetAllBRAND_COMPLAIN_MASDetail(COMP_CODE, USERCODE);
        }

        public static DataTable GetAllIDWiseBRAND_COMPLAIN_MASDetail(string ID)
        {
            return BRAND_COMPMASDataLayer.GetAllIDWiseBRAND_COMPLAIN_MASDetail(ID);
        }
    }


    public class OP_STOCK_BALLogicLayer
    {
        string _COMP_CODE, _BRANCH_CODE, _TRAN_DATE, _TRAN_NO, _YRDT1, _TRNDT, _SRNO, _SCODE, _QTY, _RATE, _AMT, _REMARK,
               _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public OP_STOCK_BALLogicLayer()
        {
            _COMP_CODE = "";
            _BRANCH_CODE = "";
            _TRAN_DATE = "";
            _TRAN_NO = "";
            _YRDT1 = "";
            _TRNDT = "";
            _SRNO = "";
            _SCODE = "";
            _QTY = "";
            _RATE = "";
            _AMT = "";
            _REMARK = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";

        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string YRDT1 { get { return _YRDT1; } set { _YRDT1 = value; } }
        public string TRNDT { get { return _TRNDT; } set { _TRNDT = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


        public static string InsertSTOCK_OP_BALDetail(OP_STOCK_BALLogicLayer Stock_OpBalDetails)
        {
            return OP_STOCK_BALDataLayer.InsertSTOCK_OP_BALDetail(Stock_OpBalDetails);
        }

        public static string UpdateBRAND_COMPLAIN_MASDetail(OP_STOCK_BALLogicLayer Stock_OpBalDetails)
        {
            return OP_STOCK_BALDataLayer.UpdateBRAND_COMPLAIN_MASDetail(Stock_OpBalDetails);
        }


        public static string DeleteSTOCK_OP_BALDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {
            return OP_STOCK_BALDataLayer.DeleteSTOCK_OP_BALDetailsByID(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetAllIDWiseSTOCK_OP_BALDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return OP_STOCK_BALDataLayer.GetAllIDWiseSTOCK_OP_BALDetials(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetAllSTOCK_OP_BALDetials(int COMP_CODE, int USERCODE)
        {
            return OP_STOCK_BALDataLayer.GetAllSTOCK_OP_BALDetials(COMP_CODE, USERCODE);
        }

    }



    public class ACCOUNTS_STOCKMASLogicLayer
    {
        string _COMP_CODE, _ACODE, _SCODE, _DIS_PER, _RATE, _DIS_RATE, _RANK, _ACTIVE, _INS_USERID, _INS_TERMINAL, _INS_DATE,
               _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public ACCOUNTS_STOCKMASLogicLayer()
        {
            _COMP_CODE = "";
            _ACODE = "";
            _SCODE = "";
            _DIS_PER = "";
            _RATE = "";
            _DIS_RATE = "";
            _RANK = "";
            _ACTIVE = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string DIS_PER { get { return _DIS_PER; } set { _DIS_PER = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string DIS_RATE { get { return _DIS_RATE; } set { _DIS_RATE = value; } }
        public string RANK { get { return _RANK; } set { _RANK = value; } }
        public string ACTIVE { get { return _ACTIVE; } set { _ACTIVE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


        public static string InsertACCOUNTS_STOCKMASDetail(ACCOUNTS_STOCKMASLogicLayer AccountStockMasDetails)
        {
            return ACCOUNTS_STOCKMASDataLayer.InsertACCOUNTS_STOCKMASDetail(AccountStockMasDetails);
        }

        public static string UpdateACCOUNTS_STOCKMASDetail(ACCOUNTS_STOCKMASLogicLayer AccountStockMasDetails)
        {
            return ACCOUNTS_STOCKMASDataLayer.UpdateACCOUNTS_STOCKMASDetail(AccountStockMasDetails);
        }

        public static string DeleteACCOUNTS_STOCKMASDetailsByID(string COMP_CODE, string ACODE, string SCODE)
        {
            return ACCOUNTS_STOCKMASDataLayer.DeleteACCOUNTS_STOCKMASDetailsByID(COMP_CODE, ACODE, SCODE);
        }

        public static DataTable GetAllIDWiseACCOUNTS_STOCKMASDetials(string COMP_CODE, string ACODE, string SCODE)
        {
            return ACCOUNTS_STOCKMASDataLayer.GetAllIDWiseACCOUNTS_STOCKMASDetials(COMP_CODE, ACODE, SCODE);
        }

        public static DataTable GetAllACCOUNTS_STOCKMASDetials(int USERCODE, int COMP_CODE)
        {
            return ACCOUNTS_STOCKMASDataLayer.GetAllACCOUNTS_STOCKMASDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllACCOUNTS_STOCKMASDetialsForGrid(string ACODE, string COMP_CODE, string USERCODE)
        {
            return ACCOUNTS_STOCKMASDataLayer.GetAllACCOUNTS_STOCKMASDetialsForGrid(ACODE, COMP_CODE, USERCODE);
        }
    }


    public class STOCK_BRANDMASLogicLayer
    {
        string _COMP_CODE, _BRAND_CODE, _BRAND_NAME, _BRANDTYPE_CODE, _BRAND_TERMS, _BRAND_AMC_TERMS, _BRAND_WARRANTY_TERMS,
               _INS_USERID, _INS_DATE, _INS_TERMINAL, _UPD_USERID, _UPD_DATE, _UPD_TERMINAL;

        public STOCK_BRANDMASLogicLayer()
        {
            _COMP_CODE = "";
            _BRAND_CODE = "";
            _BRAND_NAME = "";
            _BRANDTYPE_CODE = "";
            _BRAND_TERMS = "";
            _BRAND_AMC_TERMS = "";
            _BRAND_WARRANTY_TERMS = "";
            _INS_USERID = "";
            _INS_DATE = "";
            _INS_TERMINAL = "";
            _UPD_USERID = "";
            _UPD_DATE = "";
            _UPD_TERMINAL = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRAND_CODE { get { return _BRAND_CODE; } set { _BRAND_CODE = value; } }
        public string BRAND_NAME { get { return _BRAND_NAME; } set { _BRAND_NAME = value; } }
        public string BRANDTYPE_CODE { get { return _BRANDTYPE_CODE; } set { _BRANDTYPE_CODE = value; } }
        public string BRAND_TERMS { get { return _BRAND_TERMS; } set { _BRAND_TERMS = value; } }
        public string BRAND_AMC_TERMS { get { return _BRAND_AMC_TERMS; } set { _BRAND_AMC_TERMS = value; } }
        public string BRAND_WARRANTY_TERMS { get { return _BRAND_WARRANTY_TERMS; } set { _BRAND_WARRANTY_TERMS = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


        public static string InsertSTOCK_BRANDMASDetail(STOCK_BRANDMASLogicLayer StockBrandMasDetails)
        {
            return STOCK_BRANDMASDataLayer.InsertSTOCK_BRANDMASDetail(StockBrandMasDetails);
        }

        public static string UpdateSTOCK_BRANDMASDetail(STOCK_BRANDMASLogicLayer StockBrandMasDetails)
        {
            return STOCK_BRANDMASDataLayer.UpdateSTOCK_BRANDMASDetail(StockBrandMasDetails);
        }

        public static string DeleteSTOCK_BRANDMASDetailByID(string ID)
        {
            return STOCK_BRANDMASDataLayer.DeleteSTOCK_BRANDMASDetailByID(ID);
        }

        public static DataTable GetAllIDWiseSTOCK_BRANDMASDetail(string ID)
        {
            return STOCK_BRANDMASDataLayer.GetAllIDWiseSTOCK_BRANDMASDetail(ID);
        }


        public static DataTable GetAllSTOCK_BRANDMASDetials(int USERCODE, int COMP_CODE)
        {
            return STOCK_BRANDMASDataLayer.GetAllSTOCK_BRANDMASDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetSTOCKBRANDMAS_BrandNameCompanyWiseFor_Ddl(string Id)
        {
            return STOCK_BRANDMASDataLayer.GetSTOCKBRANDMAS_BrandNameCompanyWiseFor_Ddl(Id);
        }
    }


    public class STOCK_MODELMASLogicLayer
    {
        string _COMP_CODE, _BRAND_CODE, _MODEL_CODE, _MODEL_NAME, _MODEL_DESC, _INS_USERID, _INS_DATE, _INS_TERMINAL, _UPD_USERID, _UPD_DATE, _UPD_TERMINAL;

        public STOCK_MODELMASLogicLayer()
        {
            _COMP_CODE = "";
            _BRAND_CODE = "";
            _MODEL_CODE = "";
            _MODEL_NAME = "";
            _MODEL_DESC = "";
            _INS_USERID = "";
            _INS_DATE = "";
            _INS_TERMINAL = "";
            _UPD_USERID = "";
            _UPD_DATE = "";
            _UPD_TERMINAL = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRAND_CODE { get { return _BRAND_CODE; } set { _BRAND_CODE = value; } }
        public string MODEL_CODE { get { return _MODEL_CODE; } set { _MODEL_CODE = value; } }
        public string MODEL_NAME { get { return _MODEL_NAME; } set { _MODEL_NAME = value; } }
        public string MODEL_DESC { get { return _MODEL_DESC; } set { _MODEL_DESC = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


        public static string InsertSTOCK_MODELMASDetail(STOCK_MODELMASLogicLayer StockModelMaster, string StockModelDetails, string DetailMap)
        {
            return STOCK_MODELMASDataLayer.InsertSTOCK_MODELMASDetail(StockModelMaster, StockModelDetails, DetailMap);
        }

        public static string UpdateSTOCK_MODELMASDetail(STOCK_MODELMASLogicLayer StockModelMaster, string StockModelDetails, string DetailMap)
        {
            return STOCK_MODELMASDataLayer.UpdateSTOCK_MODELMASDetail(StockModelMaster, StockModelDetails, DetailMap);
        }

        public static string DeleteSTOCK_MODELMASDetailsByID(string ID)
        {
            return STOCK_MODELMASDataLayer.DeleteSTOCK_MODELMASDetailsByID(ID);
        }

        public static DataTable GetAllSTOCK_MODELMASDetials(int USERCODE, int COMP_CODE, int BRAND_CODE)
        {
            return STOCK_MODELMASDataLayer.GetAllSTOCK_MODELMASDetials(USERCODE, COMP_CODE, BRAND_CODE);
        }

        public static DataSet GetAllIDWiseSTOCK_MODELMASDetail(string ID)
        {
            return STOCK_MODELMASDataLayer.GetAllIDWiseSTOCK_MODELMASDetail(ID);
        }


        public static DataTable GetSTOCK_MODELMAS_ModelNameCompanyWiseFor_Ddl(string Id)
        {
            return STOCK_MODELMASDataLayer.GetSTOCK_MODELMAS_ModelNameCompanyWiseFor_Ddl(Id);
        }

        public static DataTable GetSTOCK_MODELMAS_ModelNameBrandWiseFor_Ddl(string Id)
        {
            return STOCK_MODELMASDataLayer.GetSTOCK_MODELMAS_ModelNameBrandWiseFor_Ddl(Id);
        }

        public static DataTable GetModelDescBymodelName(string MODEL_CODE)
        {
            return STOCK_MODELMASDataLayer.GetModelDescBymodelName(MODEL_CODE);
        }

        public static DataTable GetAllBRANDS_MODELSDetailByCompanyForGrid(string COMP_CODE, DateTime FromDate, DateTime ToDate)
        {
            return STOCK_MODELMASDataLayer.GetAllBRANDS_MODELSDetailByCompanyForGrid(COMP_CODE, FromDate, ToDate);
        }
    }

    public class STOCK_MODELDETLogicLayer
    {
        string _COMP_CODE, _MODEL_CODE, _SCODE, _QTY, _REMARK, _CHK_MAJOR, _CHK_NORMAL, _ORD, _INS_USERID, _INS_DATE,
               _INS_TERMINAL, _UPD_USERID, _UPD_DATE, _UPD_TERMINAL;

        public STOCK_MODELDETLogicLayer()
        {
            _COMP_CODE = "";
            _MODEL_CODE = "";
            _SCODE = "";
            _QTY = "";
            _REMARK = "";
            _CHK_MAJOR = "";
            _CHK_NORMAL = "";
            _ORD = "";
            _INS_USERID = "";
            _INS_DATE = "";
            _INS_TERMINAL = "";
            _UPD_USERID = "";
            _UPD_DATE = "";
            _UPD_TERMINAL = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string MODEL_CODE { get { return _MODEL_CODE; } set { _MODEL_CODE = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string CHK_MAJOR { get { return _CHK_MAJOR; } set { _CHK_MAJOR = value; } }
        public string CHK_NORMAL { get { return _CHK_NORMAL; } set { _CHK_NORMAL = value; } }
        public string ORD { get { return _ORD; } set { _ORD = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }

        public static DataTable GetAllSTOCK_MODELDETDetailByCompany(string COMP_CODE)
        {
            return STOCK_MODELDETDataLayer.GetAllSTOCK_MODELDETDetailByCompany(COMP_CODE);
        }

        public static DataTable GetAllSTOCK_MODELDETDetailByCompanyAndModelName(string COMP_CODE, string MODEL_CODE)
        {
            return STOCK_MODELDETDataLayer.GetAllSTOCK_MODELDETDetailByCompanyAndModelName(COMP_CODE, MODEL_CODE);
        }


        public static DataTable GetAll_MODELCODEEWise_STOCK_MODELDET(string MODEL_CODE)
        {
            return STOCK_MODELDETDataLayer.GetAll_MODELCODEEWise_STOCK_MODELDET(MODEL_CODE);
        }
    }


    public class STOCK_MODELCOSTLogicLayer
    {
        string _COMP_CODE, _MODEL_CODE, _SRNO, _FRAMT, _TOAMT, _COST_LEVEL, _INS_USERID, _INS_DATE,
               _INS_TERMINAL, _UPD_USERID, _UPD_DATE, _UPD_TERMINAL;

        public STOCK_MODELCOSTLogicLayer()
        {
            _COMP_CODE = "";
            _MODEL_CODE = "";
            _SRNO = "";
            _FRAMT = "";
            _TOAMT = "";
            _COST_LEVEL = "";
            _INS_USERID = "";
            _INS_DATE = "";
            _INS_TERMINAL = "";
            _UPD_USERID = "";
            _UPD_DATE = "";
            _UPD_TERMINAL = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string MODEL_CODE { get { return _MODEL_CODE; } set { _MODEL_CODE = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string FRAMT { get { return _FRAMT; } set { _FRAMT = value; } }
        public string TOAMT { get { return _TOAMT; } set { _TOAMT = value; } }
        public string COST_LEVEL { get { return _COST_LEVEL; } set { _COST_LEVEL = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


        public static DataTable GetAllSTOCK_MODELCOSTSDetailByCompany(string COMP_CODE)
        {
            return STOCK_MODELCOSTDataLayer.GetAllSTOCK_MODELCOSTSDetailByCompany(COMP_CODE);
        }

        public static DataTable GetAll_MODELCODEEWise_STOCK_MODELCOST(string MODEL_CODE)
        {
            return STOCK_MODELCOSTDataLayer.GetAll_MODELCODEEWise_STOCK_MODELCOST(MODEL_CODE);
        }

    }


    public class PARTY_MODELMASLogicLayer
    {
        string _COMP_CODE, _BRANCH_CODE, _ACODE, _SRNO, _MODEL_SRNO, _PARTY_SRNO, _BRAND_CODE, _MODEL_CODE, _MODEL_REMARK, _ACTIVE, _MFG_SRNO, _SERVICE_TYPE, _BCODE, _REMARK,
                _AMC_TRAN_DATE, _AMC_TRAN_NO, _AMC_SRNO, _INSTALL_DATE, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public PARTY_MODELMASLogicLayer()
        {
            _COMP_CODE = "";
            _BRANCH_CODE = "";
            _ACODE = "";
            _SRNO = "";
            _MODEL_SRNO = "";
            _PARTY_SRNO = "";
            _BRAND_CODE = "";
            _MODEL_CODE = "";
            _MODEL_REMARK = "";
            _ACTIVE = "";
            _MFG_SRNO = "";
            _SERVICE_TYPE = "";
            _BCODE = "";
            _REMARK = "";
            _AMC_TRAN_DATE = "";
            _AMC_TRAN_NO = "";
            _AMC_SRNO = "";
            _INSTALL_DATE = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string MODEL_SRNO { get { return _MODEL_SRNO; } set { _MODEL_SRNO = value; } }
        public string PARTY_SRNO { get { return _PARTY_SRNO; } set { _PARTY_SRNO = value; } }
        public string BRAND_CODE { get { return _BRAND_CODE; } set { _BRAND_CODE = value; } }
        public string MODEL_CODE { get { return _MODEL_CODE; } set { _MODEL_CODE = value; } }
        public string MODEL_REMARK { get { return _MODEL_REMARK; } set { _MODEL_REMARK = value; } }
        public string ACTIVE { get { return _ACTIVE; } set { _ACTIVE = value; } }
        public string MFG_SRNO { get { return _MFG_SRNO; } set { _MFG_SRNO = value; } }
        public string SERVICE_TYPE { get { return _SERVICE_TYPE; } set { _SERVICE_TYPE = value; } }
        public string BCODE { get { return _BCODE; } set { _BCODE = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string AMC_TRAN_DATE { get { return _AMC_TRAN_DATE; } set { _AMC_TRAN_DATE = value; } }
        public string AMC_TRAN_NO { get { return _AMC_TRAN_NO; } set { _AMC_TRAN_NO = value; } }
        public string AMC_SRNO { get { return _AMC_SRNO; } set { _AMC_SRNO = value; } }
        public string INSTALL_DATE { get { return _INSTALL_DATE; } set { _INSTALL_DATE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }

        public static string InsertPARTY_MODELMASDetail(PARTY_MODELMASLogicLayer PARTY_MODELMASDetails, string DetailMap)
        {
            return PARTY_MODELMASDataLayer.InsertPARTY_MODELMASDetail(PARTY_MODELMASDetails, DetailMap);
        }

        public static string UpdatePARTY_MODELMASDetail(PARTY_MODELMASLogicLayer PARTY_MODELMASDetails, string DetailMap)
        {
            return PARTY_MODELMASDataLayer.UpdatePARTY_MODELMASDetail(PARTY_MODELMASDetails, DetailMap);
        }

        public static string DeletePARTY_MODELMASDetailsByID(string ID)
        {
            return PARTY_MODELMASDataLayer.DeletePARTY_MODELMASDetailsByID(ID);
        }

        public static DataSet GetAllIDWisePARTY_MODELMASDetail(string ID)
        {
            return PARTY_MODELMASDataLayer.GetAllIDWisePARTY_MODELMASDetail(ID);
        }

        public static DataTable GetAllPARTY_MODELMASDetail(int USERCODE, int COMP_CODE)
        {
            return PARTY_MODELMASDataLayer.GetAllPARTY_MODELMASDetail(USERCODE, COMP_CODE);
        }

        public static string Get_model_srno(int acode, int comp_code)
        {
            return PARTY_MODELMASDataLayer.Get_model_srno(acode, comp_code);
        }


        public static DataTable GetAllPARTY_MODELMASDetailWisePartyName(string ACODE)
        {
            return PARTY_MODELMASDataLayer.GetAllPARTY_MODELMASDetailWisePartyName(ACODE);
        }

        public static DataTable GetAllPARTY_MODELMASDetailWisePartyNameForGrid(string ACODE)
        {
            return PARTY_MODELMASDataLayer.GetAllPARTY_MODELMASDetailWisePartyNameForGrid(ACODE);
        }

        public static DataTable GetAllIDWisePARTY_MODELMASDetailForDC(string SRNO)
        {
            return PARTY_MODELMASDataLayer.GetAllIDWisePARTY_MODELMASDetailForDC(SRNO);
        }


        public static DataTable GetAllIDWisePARTY_MODELMASDetailForJobcard(string SRNO)
        {
            return PARTY_MODELMASDataLayer.GetAllIDWisePARTY_MODELMASDetailForJobcard(SRNO);
        }

        public static DataSet GETAMC_MASDetailsForJobcardMsater(string ACODE, string PARTYREFSRNO)
        {
            return PARTY_MODELMASDataLayer.GETAMC_MASDetailsForJobcardMsater(ACODE, PARTYREFSRNO);
        }

    }


    public class PARTY_MODELDETLogicLayer
    {
        string _COMP_CODE, _ACODE, _SRNO, _SUB_SRNO, _SCODE, _QTY, _REMARK, _CHK_MAJOR, _CHK_NORMAL, _ORD, _INS_USERID,
                _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public PARTY_MODELDETLogicLayer()
        {
            _COMP_CODE = "";
            _ACODE = "";
            _SRNO = "";
            _SUB_SRNO = "";
            _SCODE = "";
            _QTY = "";
            _REMARK = "";
            _CHK_MAJOR = "";
            _CHK_NORMAL = "";
            _ORD = "";
            _INS_USERID = "";
            _INS_TERMINAL = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_TERMINAL = "";
            _UPD_DATE = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string SUB_SRNO { get { return _SUB_SRNO; } set { _SUB_SRNO = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string CHK_MAJOR { get { return _CHK_MAJOR; } set { _CHK_MAJOR = value; } }
        public string CHK_NORMAL { get { return _CHK_NORMAL; } set { _CHK_NORMAL = value; } }
        public string ORD { get { return _ORD; } set { _ORD = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


        public static DataTable GetAllPARTY_MODELDETDetailByCompany(string COMP_CODE)
        {
            return PARTY_MODELDETDataLayer.GetAllPARTY_MODELDETDetailByCompany(COMP_CODE);
        }

        public static DataTable GetAll_PARTY_MODELDETWiseSrNo(string SRNO)
        {
            return PARTY_MODELDETDataLayer.GetAll_PARTY_MODELDETWiseSrNo(SRNO);
        }



        public static DataTable GetAllPARTY_MODELDETDetailByComapnyAndID(string COMP_CODE, string ACODE, string SRNO)
        {
            return PARTY_MODELDETDataLayer.GetAllPARTY_MODELDETDetailByComapnyAndID(COMP_CODE, ACODE, SRNO);
        }
    }



    public class QUOTATION_MLogicLayer
    {
        string _TRAN_DATE, _TRAN_NO, _COMP_CODE, _QUO_NO, _QUO_DATE, _PARTY_NAME, _PARTY_ADD1, _ENGINE_TYPE, _VEHICLE_NO, _GROSS_AMT, _CHARGES_AMT, _RO_AMT, _DISC_PER,
               _DISC_AMT, _NET_AMT, _ENDT, _PRICE_TERMS, _PAYMENT_TERMS, _DELIVERY_TERMS, _VALIDITY_TERMS, _REMARK, _KIND_ATTN, _TRANSPORT_TERMS, _BRANCH_CODE, _BCODE,
               _SALES_TYPE, _PARTY_TYPE, _CST_TYPE, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE, _CONF_FLAG, _CONF_DATE, _CONF_USERID,
               _PARTY_ADD2, _PARTY_ADD3, _PARTY_VAT, _PARTY_CST, _PARTY_PHONE, _ACODE, _ATYPE, _PARTY_REFNO, _BRAND_NAME, _MODEL_NAME, _SUB1, _SUB2, _SUB3, _SUB4, _NOTE,
              _QUO_TYPE, _KIND_ATTN_PHONE, _KIND_ATTN_EMAIL, _STATUS, _REF_BY, _REF_TRAN_DATE, _REF_TRAN_NO, _GST_RATE, _GST_AMT, _CGST_RATE, _CGST_AMT, _SGST_RATE, _SGST_AMT, _IGST_RATE, _IGST_AMT;

        public QUOTATION_MLogicLayer()
        {
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _COMP_CODE = "  ";
            _QUO_NO = "  ";
            _QUO_DATE = "  ";
            _PARTY_NAME = "  ";
            _PARTY_ADD1 = "  ";
            _ENGINE_TYPE = "  ";
            _VEHICLE_NO = "  ";
            _GROSS_AMT = "  ";
            _CHARGES_AMT = "  ";
            _RO_AMT = "  ";
            _DISC_PER = "  ";
            _DISC_AMT = "  ";
            _NET_AMT = "  ";
            _ENDT = "  ";
            _PRICE_TERMS = "  ";
            _PAYMENT_TERMS = "  ";
            _DELIVERY_TERMS = "  ";
            _VALIDITY_TERMS = "  ";
            _REMARK = "  ";
            _KIND_ATTN = "  ";
            _TRANSPORT_TERMS = "  ";
            _BRANCH_CODE = "  ";
            _BCODE = "  ";
            _SALES_TYPE = "  ";
            _PARTY_TYPE = "  ";
            _CST_TYPE = "  ";
            _INS_USERID = "  ";
            _INS_TERMINAL = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_TERMINAL = "  ";
            _UPD_DATE = "  ";
            _CONF_FLAG = "  ";
            _CONF_DATE = "  ";
            _CONF_USERID = "  ";
            _PARTY_ADD2 = "  ";
            _PARTY_ADD3 = "  ";
            _PARTY_VAT = "  ";
            _PARTY_CST = "  ";
            _PARTY_PHONE = "  ";
            _ACODE = "  ";
            _ATYPE = "  ";
            _PARTY_REFNO = "  ";
            _BRAND_NAME = "  ";
            _MODEL_NAME = "  ";
            _SUB1 = "  ";
            _SUB2 = "  ";
            _SUB3 = "  ";
            _SUB4 = "  ";
            _NOTE = "  ";
            _QUO_TYPE = "  ";
            _KIND_ATTN_PHONE = "  ";
            _KIND_ATTN_EMAIL = "  ";
            _STATUS = "  ";
            _REF_BY = "  ";
            _REF_TRAN_DATE = "  ";
            _REF_TRAN_NO = "  ";
            _GST_RATE = "  ";
            _GST_AMT = "  ";
            _CGST_RATE = "  ";
            _CGST_AMT = "  ";
            _SGST_RATE = "  ";
            _SGST_AMT = "  ";
            _IGST_RATE = "  ";
            _IGST_AMT = "  ";


        }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string QUO_NO { get { return _QUO_NO; } set { _QUO_NO = value; } }
        public string QUO_DATE { get { return _QUO_DATE; } set { _QUO_DATE = value; } }
        public string PARTY_NAME { get { return _PARTY_NAME; } set { _PARTY_NAME = value; } }
        public string PARTY_ADD1 { get { return _PARTY_ADD1; } set { _PARTY_ADD1 = value; } }
        public string ENGINE_TYPE { get { return _ENGINE_TYPE; } set { _ENGINE_TYPE = value; } }
        public string VEHICLE_NO { get { return _VEHICLE_NO; } set { _VEHICLE_NO = value; } }
        public string GROSS_AMT { get { return _GROSS_AMT; } set { _GROSS_AMT = value; } }
        public string CHARGES_AMT { get { return _CHARGES_AMT; } set { _CHARGES_AMT = value; } }
        public string RO_AMT { get { return _RO_AMT; } set { _RO_AMT = value; } }
        public string DISC_PER { get { return _DISC_PER; } set { _DISC_PER = value; } }
        public string DISC_AMT { get { return _DISC_AMT; } set { _DISC_AMT = value; } }
        public string NET_AMT { get { return _NET_AMT; } set { _NET_AMT = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string PRICE_TERMS { get { return _PRICE_TERMS; } set { _PRICE_TERMS = value; } }
        public string PAYMENT_TERMS { get { return _PAYMENT_TERMS; } set { _PAYMENT_TERMS = value; } }
        public string DELIVERY_TERMS { get { return _DELIVERY_TERMS; } set { _DELIVERY_TERMS = value; } }
        public string VALIDITY_TERMS { get { return _VALIDITY_TERMS; } set { _VALIDITY_TERMS = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string KIND_ATTN { get { return _KIND_ATTN; } set { _KIND_ATTN = value; } }
        public string TRANSPORT_TERMS { get { return _TRANSPORT_TERMS; } set { _TRANSPORT_TERMS = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string BCODE { get { return _BCODE; } set { _BCODE = value; } }
        public string SALES_TYPE { get { return _SALES_TYPE; } set { _SALES_TYPE = value; } }
        public string PARTY_TYPE { get { return _PARTY_TYPE; } set { _PARTY_TYPE = value; } }
        public string CST_TYPE { get { return _CST_TYPE; } set { _CST_TYPE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string CONF_FLAG { get { return _CONF_FLAG; } set { _CONF_FLAG = value; } }
        public string CONF_DATE { get { return _CONF_DATE; } set { _CONF_DATE = value; } }
        public string CONF_USERID { get { return _CONF_USERID; } set { _CONF_USERID = value; } }
        public string PARTY_ADD2 { get { return _PARTY_ADD2; } set { _PARTY_ADD2 = value; } }
        public string PARTY_ADD3 { get { return _PARTY_ADD3; } set { _PARTY_ADD3 = value; } }
        public string PARTY_VAT { get { return _PARTY_VAT; } set { _PARTY_VAT = value; } }
        public string PARTY_CST { get { return _PARTY_CST; } set { _PARTY_CST = value; } }
        public string PARTY_PHONE { get { return _PARTY_PHONE; } set { _PARTY_PHONE = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string ATYPE { get { return _ATYPE; } set { _ATYPE = value; } }
        public string PARTY_REFNO { get { return _PARTY_REFNO; } set { _PARTY_REFNO = value; } }
        public string BRAND_NAME { get { return _BRAND_NAME; } set { _BRAND_NAME = value; } }
        public string MODEL_NAME { get { return _MODEL_NAME; } set { _MODEL_NAME = value; } }
        public string SUB1 { get { return _SUB1; } set { _SUB1 = value; } }
        public string SUB2 { get { return _SUB2; } set { _SUB2 = value; } }
        public string SUB3 { get { return _SUB3; } set { _SUB3 = value; } }
        public string SUB4 { get { return _SUB4; } set { _SUB4 = value; } }
        public string NOTE { get { return _NOTE; } set { _NOTE = value; } }
        public string QUO_TYPE { get { return _QUO_TYPE; } set { _QUO_TYPE = value; } }
        public string KIND_ATTN_PHONE { get { return _KIND_ATTN_PHONE; } set { _KIND_ATTN_PHONE = value; } }
        public string KIND_ATTN_EMAIL { get { return _KIND_ATTN_EMAIL; } set { _KIND_ATTN_EMAIL = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string REF_BY { get { return _REF_BY; } set { _REF_BY = value; } }
        public string REF_TRAN_DATE { get { return _REF_TRAN_DATE; } set { _REF_TRAN_DATE = value; } }
        public string REF_TRAN_NO { get { return _REF_TRAN_NO; } set { _REF_TRAN_NO = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string GST_AMT { get { return _GST_AMT; } set { _GST_AMT = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string CGST_AMT { get { return _CGST_AMT; } set { _CGST_AMT = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string SGST_AMT { get { return _SGST_AMT; } set { _SGST_AMT = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }

        public static string InsertQUOATATION_MASDetail(QUOTATION_MLogicLayer Quotation_M, string Quotation_T, string Quotation_C, string COMP_CODE, string BRANCH_CODE, string YRDT1)
        {
            return QUOTATION_MDataLayer.InsertQUOATATION_MASDetail(Quotation_M, Quotation_T, Quotation_C, COMP_CODE, BRANCH_CODE, YRDT1);
        }

        public static string UpdateQUOATATION_MASDetail(QUOTATION_MLogicLayer Quotation_M, string Quotation_T, string Quotation_C)
        {
            return QUOTATION_MDataLayer.UpdateQUOATATION_MASDetail(Quotation_M, Quotation_T, Quotation_C);
        }

        public static string DeleteQUOATATION_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {
            return QUOTATION_MDataLayer.DeleteQUOATATION_MASDetailsByID(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetAllQUOATATION_MASDetails(int USERCODE, int COMP_CODE)
        {
            return QUOTATION_MDataLayer.GetAllQUOATATION_MASDetails(USERCODE, COMP_CODE);
        }

        public static string ADD_DISFLAG_FROMCOMPANY(int comp_code)
        {
            return QUOTATION_MDataLayer.ADD_DISFLAG_FROMCOMPANY(comp_code);
        }
        public static string GetQuoNoQUOATATION_MASDetailCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string QuoDate)
        {
            return QUOTATION_MDataLayer.GetQuoNoQUOATATION_MASDetailCompanyBranchYearWise(COMP_CODE, BRANCH_CODE, YRDT1, QuoDate);
        }

        public static DataSet GetAllIDWiseQUOATATION_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return QUOTATION_MDataLayer.GetAllIDWiseQUOATATION_MASDetials(TRAN_NO, TRAN_DATE);
        }


        public static DataTable GetAllQUOATATION_MASDetialsByACODE(string COMP_CODE, string BRANCH_CODE, string ACODE)
        {
            return QUOTATION_MDataLayer.GetAllQUOATATION_MASDetialsByACODE(COMP_CODE, BRANCH_CODE, ACODE);
        }


    }



    public class QUOTATION_TLogicLayer

    {
        string _TRAN_DATE, _TRAN_NO, _SRNO, _SCODE, _QTY, _RATE, _AMT, _CAL_RATE, _CAL_AMT, _DISC_PER, _DISC_AMT, _ACT_RATE, _ACT_AMT, _ST_PER, _ST_AMT, _ADD_ST_PER, _ADD_ST_AMT, _T_AMT, _PRODUCT_DESC,
              _EXCISE_PER, _EXCISE_AMT, _G_AMT, _COMP_CODE, _BRAND_CODE, _MODEL_CODE, _ADD_DISC_PER, _ADD_DISC_AMT, _GST_RATE, _GST_AMT, _CGST_RATE, _CGST_AMT, _SGST_RATE, _SGST_AMT, _IGST_RATE, _IGST_AMT;

        public QUOTATION_TLogicLayer()
        {
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _SCODE = "  ";
            _QTY = "  ";
            _RATE = "  ";
            _AMT = "  ";
            _CAL_RATE = "  ";
            _CAL_AMT = "  ";
            _DISC_PER = "  ";
            _DISC_AMT = "  ";
            _ACT_RATE = "  ";
            _ACT_AMT = "  ";
            _ST_PER = "  ";
            _ST_AMT = "  ";
            _ADD_ST_PER = "  ";
            _ADD_ST_AMT = "  ";
            _T_AMT = "  ";
            _PRODUCT_DESC = "  ";
            _EXCISE_PER = "  ";
            _EXCISE_AMT = "  ";
            _G_AMT = "  ";
            _COMP_CODE = "  ";
            _BRAND_CODE = "  ";
            _MODEL_CODE = "  ";
            _ADD_DISC_PER = "  ";
            _ADD_DISC_AMT = "  ";
            _GST_RATE = "  ";
            _GST_AMT = "  ";
            _CGST_RATE = "  ";
            _CGST_AMT = "  ";
            _SGST_RATE = "  ";
            _SGST_AMT = "  ";
            _IGST_RATE = "  ";
            _IGST_AMT = "  ";


        }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string CAL_RATE { get { return _CAL_RATE; } set { _CAL_RATE = value; } }
        public string CAL_AMT { get { return _CAL_AMT; } set { _CAL_AMT = value; } }
        public string DISC_PER { get { return _DISC_PER; } set { _DISC_PER = value; } }
        public string DISC_AMT { get { return _DISC_AMT; } set { _DISC_AMT = value; } }
        public string ACT_RATE { get { return _ACT_RATE; } set { _ACT_RATE = value; } }
        public string ACT_AMT { get { return _ACT_AMT; } set { _ACT_AMT = value; } }
        public string ST_PER { get { return _ST_PER; } set { _ST_PER = value; } }
        public string ST_AMT { get { return _ST_AMT; } set { _ST_AMT = value; } }
        public string ADD_ST_PER { get { return _ADD_ST_PER; } set { _ADD_ST_PER = value; } }
        public string ADD_ST_AMT { get { return _ADD_ST_AMT; } set { _ADD_ST_AMT = value; } }
        public string T_AMT { get { return _T_AMT; } set { _T_AMT = value; } }
        public string PRODUCT_DESC { get { return _PRODUCT_DESC; } set { _PRODUCT_DESC = value; } }
        public string EXCISE_PER { get { return _EXCISE_PER; } set { _EXCISE_PER = value; } }
        public string EXCISE_AMT { get { return _EXCISE_AMT; } set { _EXCISE_AMT = value; } }
        public string G_AMT { get { return _G_AMT; } set { _G_AMT = value; } }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRAND_CODE { get { return _BRAND_CODE; } set { _BRAND_CODE = value; } }
        public string MODEL_CODE { get { return _MODEL_CODE; } set { _MODEL_CODE = value; } }
        public string ADD_DISC_PER { get { return _ADD_DISC_PER; } set { _ADD_DISC_PER = value; } }
        public string ADD_DISC_AMT { get { return _ADD_DISC_AMT; } set { _ADD_DISC_AMT = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string GST_AMT { get { return _GST_AMT; } set { _GST_AMT = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string CGST_AMT { get { return _CGST_AMT; } set { _CGST_AMT = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string SGST_AMT { get { return _SGST_AMT; } set { _SGST_AMT = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }


        public static DataTable GetAllQUOTATION_TDetailByCompany(string COMP_CODE)
        {
            return QUOTATION_TDataLayer.GetAllQUOTATION_TDetailByCompany(COMP_CODE);
        }

        public static DataTable GetAllQUOTATION_TAMCDetailByCompany(string COMP_CODE)
        {
            return QUOTATION_TDataLayer.GetAllQUOTATION_TAMCDetailByCompany(COMP_CODE);
        }
    }


    public class QUOTATION_CLogicLayer

    {
        string _TRAN_DATE, _TRAN_NO, _SR, _CCODE, _QTY, _PER, _SIGN, _AMT, _ENDT, _COMP_CODE, _GST_RATE, _GST_AMT, _CGST_RATE, _CGST_AMT, _SGST_RATE, _SGST_AMT, _IGST_RATE, _IGST_AMT, _T_AMT;

        public QUOTATION_CLogicLayer()
        {
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SR = "  ";
            _CCODE = "  ";
            _QTY = "  ";
            _PER = "  ";
            _SIGN = "  ";
            _AMT = "  ";
            _ENDT = "  ";
            _COMP_CODE = "  ";
            _GST_RATE = "  ";
            _GST_AMT = "  ";
            _CGST_RATE = "  ";
            _CGST_AMT = "  ";
            _SGST_RATE = "  ";
            _SGST_AMT = "  ";
            _IGST_RATE = "  ";
            _IGST_AMT = "  ";
            _T_AMT = "  ";


        }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SR { get { return _SR; } set { _SR = value; } }
        public string CCODE { get { return _CCODE; } set { _CCODE = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string PER { get { return _PER; } set { _PER = value; } }
        public string SIGN { get { return _SIGN; } set { _SIGN = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string GST_AMT { get { return _GST_AMT; } set { _GST_AMT = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string CGST_AMT { get { return _CGST_AMT; } set { _CGST_AMT = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string SGST_AMT { get { return _SGST_AMT; } set { _SGST_AMT = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }
        public string T_AMT { get { return _T_AMT; } set { _T_AMT = value; } }

        public static DataTable GetAllQUOTATION_CDetailByCompany(string COMP_CODE)
        {
            return QUOTATION_CDataLayer.GetAllQUOTATION_CDetailByCompany(COMP_CODE);
        }
    }


    public class ORDER_MASLogicLayer
    {
        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _TRAN_TYPE, _ORD_NO, _ORD_DT, _ACODE, _TRANSPORT, _ORD_REF, _REMARK, _TOT_QTY, _TOT_KEPT, _TOT_REJ,
               _STATUS, _CLOSE_ORDER, _ENDT, _ST_PER, _ST_AMT, _ADD_ST_PER, _ADD_ST_AMT, _NET_AMT, _PROJECT_NO, _DRAWING_NO, _ORD_REFDATETIME, _DRIVER_NAME,
               _DRIVER_ADD, _MDLNO, _MDLSTATE, _EX_DUTY_PER, _EX_DUTY_AMT, _EX_CESS_PER, _EX_CESS_AMT, _EX_SHCESS_PER, _EX_SHCESS_AMT, _RO_AMT, _BRANCH_CODE,
               _BCODE, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE, _CONF_FLAG, _CONF_DATE, _CONF_USERID, _VALID_DAYS, _VALID_DATE,
              _FIN_YEAR, _OS_YEAR, _PARTY_TYPE, _GST_RATE, _GST_AMT, _CGST_RATE, _CGST_AMT, _SGST_RATE, _SGST_AMT, _IGST_RATE, _IGST_AMT, _GROSS_AMT;

        public ORDER_MASLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _TRAN_TYPE = "  ";
            _ORD_NO = "  ";
            _ORD_DT = "  ";
            _ACODE = "  ";
            _TRANSPORT = "  ";
            _ORD_REF = "  ";
            _REMARK = "  ";
            _TOT_QTY = "  ";
            _TOT_KEPT = "  ";
            _TOT_REJ = "  ";
            _STATUS = "  ";
            _CLOSE_ORDER = "  ";
            _ENDT = "  ";
            _ST_PER = "  ";
            _ST_AMT = "  ";
            _ADD_ST_PER = "  ";
            _ADD_ST_AMT = "  ";
            _NET_AMT = "  ";
            _PROJECT_NO = "  ";
            _DRAWING_NO = "  ";
            _ORD_REFDATETIME = "  ";
            _DRIVER_NAME = "  ";
            _DRIVER_ADD = "  ";
            _MDLNO = "  ";
            _MDLSTATE = "  ";
            _EX_DUTY_PER = "  ";
            _EX_DUTY_AMT = "  ";
            _EX_CESS_PER = "  ";
            _EX_CESS_AMT = "  ";
            _EX_SHCESS_PER = "  ";
            _EX_SHCESS_AMT = "  ";
            _RO_AMT = "  ";
            _BRANCH_CODE = "  ";
            _BCODE = "  ";
            _INS_USERID = "  ";
            _INS_TERMINAL = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_TERMINAL = "  ";
            _UPD_DATE = "  ";
            _CONF_FLAG = "  ";
            _CONF_DATE = "  ";
            _CONF_USERID = "  ";
            _VALID_DAYS = "  ";
            _VALID_DATE = "  ";
            _FIN_YEAR = "  ";
            _OS_YEAR = "  ";
            _PARTY_TYPE = "  ";
            _GST_RATE = "  ";
            _GST_AMT = "  ";
            _CGST_RATE = "  ";
            _CGST_AMT = "  ";
            _SGST_RATE = "  ";
            _SGST_AMT = "  ";
            _IGST_RATE = "  ";
            _IGST_AMT = "  ";
            _GROSS_AMT = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string TRAN_TYPE { get { return _TRAN_TYPE; } set { _TRAN_TYPE = value; } }
        public string ORD_NO { get { return _ORD_NO; } set { _ORD_NO = value; } }
        public string ORD_DT { get { return _ORD_DT; } set { _ORD_DT = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string TRANSPORT { get { return _TRANSPORT; } set { _TRANSPORT = value; } }
        public string ORD_REF { get { return _ORD_REF; } set { _ORD_REF = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string TOT_QTY { get { return _TOT_QTY; } set { _TOT_QTY = value; } }
        public string TOT_KEPT { get { return _TOT_KEPT; } set { _TOT_KEPT = value; } }
        public string TOT_REJ { get { return _TOT_REJ; } set { _TOT_REJ = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string CLOSE_ORDER { get { return _CLOSE_ORDER; } set { _CLOSE_ORDER = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string ST_PER { get { return _ST_PER; } set { _ST_PER = value; } }
        public string ST_AMT { get { return _ST_AMT; } set { _ST_AMT = value; } }
        public string ADD_ST_PER { get { return _ADD_ST_PER; } set { _ADD_ST_PER = value; } }
        public string ADD_ST_AMT { get { return _ADD_ST_AMT; } set { _ADD_ST_AMT = value; } }
        public string NET_AMT { get { return _NET_AMT; } set { _NET_AMT = value; } }
        public string PROJECT_NO { get { return _PROJECT_NO; } set { _PROJECT_NO = value; } }
        public string DRAWING_NO { get { return _DRAWING_NO; } set { _DRAWING_NO = value; } }
        public string ORD_REFDATETIME { get { return _ORD_REFDATETIME; } set { _ORD_REFDATETIME = value; } }
        public string DRIVER_NAME { get { return _DRIVER_NAME; } set { _DRIVER_NAME = value; } }
        public string DRIVER_ADD { get { return _DRIVER_ADD; } set { _DRIVER_ADD = value; } }
        public string MDLNO { get { return _MDLNO; } set { _MDLNO = value; } }
        public string MDLSTATE { get { return _MDLSTATE; } set { _MDLSTATE = value; } }
        public string EX_DUTY_PER { get { return _EX_DUTY_PER; } set { _EX_DUTY_PER = value; } }
        public string EX_DUTY_AMT { get { return _EX_DUTY_AMT; } set { _EX_DUTY_AMT = value; } }
        public string EX_CESS_PER { get { return _EX_CESS_PER; } set { _EX_CESS_PER = value; } }
        public string EX_CESS_AMT { get { return _EX_CESS_AMT; } set { _EX_CESS_AMT = value; } }
        public string EX_SHCESS_PER { get { return _EX_SHCESS_PER; } set { _EX_SHCESS_PER = value; } }
        public string EX_SHCESS_AMT { get { return _EX_SHCESS_AMT; } set { _EX_SHCESS_AMT = value; } }
        public string RO_AMT { get { return _RO_AMT; } set { _RO_AMT = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string BCODE { get { return _BCODE; } set { _BCODE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string CONF_FLAG { get { return _CONF_FLAG; } set { _CONF_FLAG = value; } }
        public string CONF_DATE { get { return _CONF_DATE; } set { _CONF_DATE = value; } }
        public string CONF_USERID { get { return _CONF_USERID; } set { _CONF_USERID = value; } }
        public string VALID_DAYS { get { return _VALID_DAYS; } set { _VALID_DAYS = value; } }
        public string VALID_DATE { get { return _VALID_DATE; } set { _VALID_DATE = value; } }
        public string FIN_YEAR { get { return _FIN_YEAR; } set { _FIN_YEAR = value; } }
        public string OS_YEAR { get { return _OS_YEAR; } set { _OS_YEAR = value; } }
        public string PARTY_TYPE { get { return _PARTY_TYPE; } set { _PARTY_TYPE = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string GST_AMT { get { return _GST_AMT; } set { _GST_AMT = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string CGST_AMT { get { return _CGST_AMT; } set { _CGST_AMT = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string SGST_AMT { get { return _SGST_AMT; } set { _SGST_AMT = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }
        public string GROSS_AMT { get { return _GROSS_AMT; } set { _GROSS_AMT = value; } }


        public static string InsertORDER_MASDetail(ORDER_MASLogicLayer Order_Master, string Order_Item, string Order_MasQoutation, string COMP_CODE, string BRANCH_CODE, string TRAN_TYPE, string YRDT1)
        {
            return ORDER_MASDataLayer.InsertORDER_MASDetail(Order_Master, Order_Item, Order_MasQoutation, COMP_CODE, BRANCH_CODE, TRAN_TYPE, YRDT1);
        }

        public static string UpdateORDER_MASDetail(ORDER_MASLogicLayer Order_Master, string Order_Item, string Order_MasQoutation)
        {
            return ORDER_MASDataLayer.UpdateORDER_MASDetail(Order_Master, Order_Item, Order_MasQoutation);
        }

        public static string DeleteORDER_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {
            return ORDER_MASDataLayer.DeleteORDER_MASDetailsByID(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetAllORDER_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE)
        {
            return ORDER_MASDataLayer.GetAllORDER_MASDetails(USERCODE, COMP_CODE, TRAN_TYPE);
        }

        public static DataTable GetAllSales_ORDER_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE)
        {
            return ORDER_MASDataLayer.GetAllSales_ORDER_MASDetails(USERCODE, COMP_CODE, TRAN_TYPE);
        }

        public static DataSet GetAllIDWiseORDER_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return ORDER_MASDataLayer.GetAllIDWiseORDER_MASDetials(TRAN_NO, TRAN_DATE);
        }

        public static string GetOrderNoORDER_MASDetailCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string OrderDate, string TRAN_TYPE)
        {
            return ORDER_MASDataLayer.GetOrderNoORDER_MASDetailCompanyBranchYearWise(COMP_CODE, BRANCH_CODE, YRDT1, OrderDate, TRAN_TYPE);
        }

        public static DataTable GetAllIDWisePO_DetialsForGrid(string COMP_CODE, string BRANCH_CODE, string ACODE)
        {
            return ORDER_MASDataLayer.GetAllIDWisePO_DetialsForGrid(COMP_CODE, BRANCH_CODE, ACODE);
        }

    }


    public class ORDER_ITEMLogicLayer

    {
        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _SCODE, _ORD_DESC, _QTY, _KEPT_QTY, _REJ_QTY, _RATE, _AMT, _STATUS, _CLOSE_ITEM, _ENDT,
               _ADD_PART_NO, _DIS_PER, _PCS_WT, _DIS_AMT, _T_AMT, _CAL_TYPE, _REQ_TRAN_DATE, _REQ_TRAN_NO, _REQ_SRNO, _GST_RATE, _GST_AMT, _CGST_RATE,
              _CGST_AMT, _SGST_RATE, _SGST_AMT, _IGST_RATE, _IGST_AMT, _G_AMT;

        public ORDER_ITEMLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _SCODE = "  ";
            _ORD_DESC = "  ";
            _QTY = "  ";
            _KEPT_QTY = "  ";
            _REJ_QTY = "  ";
            _RATE = "  ";
            _AMT = "  ";
            _STATUS = "  ";
            _CLOSE_ITEM = "  ";
            _ENDT = "  ";
            _ADD_PART_NO = "  ";
            _DIS_PER = "  ";
            _PCS_WT = "  ";
            _DIS_AMT = "  ";
            _T_AMT = "  ";
            _CAL_TYPE = "  ";
            _REQ_TRAN_DATE = "  ";
            _REQ_TRAN_NO = "  ";
            _REQ_SRNO = "  ";
            _GST_RATE = "  ";
            _GST_AMT = "  ";
            _CGST_RATE = "  ";
            _CGST_AMT = "  ";
            _SGST_RATE = "  ";
            _SGST_AMT = "  ";
            _IGST_RATE = "  ";
            _IGST_AMT = "  ";
            _G_AMT = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string ORD_DESC { get { return _ORD_DESC; } set { _ORD_DESC = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string KEPT_QTY { get { return _KEPT_QTY; } set { _KEPT_QTY = value; } }
        public string REJ_QTY { get { return _REJ_QTY; } set { _REJ_QTY = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string CLOSE_ITEM { get { return _CLOSE_ITEM; } set { _CLOSE_ITEM = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string ADD_PART_NO { get { return _ADD_PART_NO; } set { _ADD_PART_NO = value; } }
        public string DIS_PER { get { return _DIS_PER; } set { _DIS_PER = value; } }
        public string PCS_WT { get { return _PCS_WT; } set { _PCS_WT = value; } }
        public string DIS_AMT { get { return _DIS_AMT; } set { _DIS_AMT = value; } }
        public string T_AMT { get { return _T_AMT; } set { _T_AMT = value; } }
        public string CAL_TYPE { get { return _CAL_TYPE; } set { _CAL_TYPE = value; } }
        public string REQ_TRAN_DATE { get { return _REQ_TRAN_DATE; } set { _REQ_TRAN_DATE = value; } }
        public string REQ_TRAN_NO { get { return _REQ_TRAN_NO; } set { _REQ_TRAN_NO = value; } }
        public string REQ_SRNO { get { return _REQ_SRNO; } set { _REQ_SRNO = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string GST_AMT { get { return _GST_AMT; } set { _GST_AMT = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string CGST_AMT { get { return _CGST_AMT; } set { _CGST_AMT = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string SGST_AMT { get { return _SGST_AMT; } set { _SGST_AMT = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }
        public string G_AMT { get { return _G_AMT; } set { _G_AMT = value; } }

        public static DataTable GetAllORDER_ITEMDetailByCompany(string COMP_CODE)
        {
            return ORDER_ITEMDataLayer.GetAllORDER_ITEMDetailByCompany(COMP_CODE);
        }

        public static DataTable GetAllWiseID_ORDER_MASDetail(string TRAN_NO, DateTime TRAN_DATE)
        {
            return ORDER_ITEMDataLayer.GetAllWiseID_ORDER_MASDetail(TRAN_NO, TRAN_DATE);
        }
    }


    public class DC_MASLogicLayer

    {

        string _COMP_CODE, _BRANCH_CODE, _TRAN_DATE, _TRAN_NO, _TRAN_TYPE, _TRN_TYPE, _ACODE, _BCODE, _BAMT, _CHA_NO, _CHA_DT, _SERIALNO, _PO_NO, _PO_DT,
               _VEHICLE_NO, _TCODE, _TRANSPORT, _LR_NO, _LR_DATE, _DRIVER_NAME, _DRIVER_ADD, _MDLNO, _MDLSTATE, _REMARK, _FORM_SRNO, _CHECKPOST_NAME, _ENDT,
               _STATUS, _REF_TRAN_DATE, _REF_TRAN_NO, _CLOSE_CHALLAN, _TOT_RET, _TOT_QTY, _PARTY_TYPE, _SALES_TYPE, _TERM_CODE, _LC_TRAN_DATE, _LC_TRAN_NO,
               _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE, _DEL_CONF_FLAG, _DEL_CONF_DATE, _CHK_FLAG, _CHK_DATE, _CHK_USERID, _REC_DT, _INV_TRAN_DATE,
               _INV_TRAN_NO, _TOT_CAMT, _CRACODE1, _DRACODE1, _CRACODE2, _DRACODE2, _CRACODE3, _DRACODE3, _EXPAMT1, _EXPAMT2, _EXPAMT3, _ACC_TRAN_DATE,
               _ACC_TRAN_NO, _GROSS_AMT, _TOT_AMT, _INV_NO, _INV_DT, _CONV_RATE, _EXCISE_TYPE, _PARTY_REFSRNO, _UPLOAD_USERID, _UPLOAD_TERMINAL, _UPLOAD_DATE,
               _UPLOAD_FILENAME, _UPLOAD_FLAG, _DC_TYPE;

        public DC_MASLogicLayer()
        {
            _COMP_CODE = "  ";
            _BRANCH_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _TRAN_TYPE = "  ";
            _TRN_TYPE = "  ";
            _ACODE = "  ";
            _BCODE = "  ";
            _BAMT = "  ";
            _CHA_NO = "  ";
            _CHA_DT = "  ";
            _SERIALNO = "  ";
            _PO_NO = "  ";
            _PO_DT = "  ";
            _VEHICLE_NO = "  ";
            _TCODE = "  ";
            _TRANSPORT = "  ";
            _LR_NO = "  ";
            _LR_DATE = "  ";
            _DRIVER_NAME = "  ";
            _DRIVER_ADD = "  ";
            _MDLNO = "  ";
            _MDLSTATE = "  ";
            _REMARK = "  ";
            _FORM_SRNO = "  ";
            _CHECKPOST_NAME = "  ";
            _ENDT = "  ";
            _STATUS = "  ";
            _REF_TRAN_DATE = "  ";
            _REF_TRAN_NO = "  ";
            _CLOSE_CHALLAN = "  ";
            _TOT_RET = "  ";
            _TOT_QTY = "  ";
            _PARTY_TYPE = "  ";
            _SALES_TYPE = "  ";
            _TERM_CODE = "  ";
            _LC_TRAN_DATE = "  ";
            _LC_TRAN_NO = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _DEL_CONF_FLAG = "  ";
            _DEL_CONF_DATE = "  ";
            _CHK_FLAG = "  ";
            _CHK_DATE = "  ";
            _CHK_USERID = "  ";
            _REC_DT = "  ";
            _INV_TRAN_DATE = "  ";
            _INV_TRAN_NO = "  ";
            _TOT_CAMT = "  ";
            _CRACODE1 = "  ";
            _DRACODE1 = "  ";
            _CRACODE2 = "  ";
            _DRACODE2 = "  ";
            _CRACODE3 = "  ";
            _DRACODE3 = "  ";
            _EXPAMT1 = "  ";
            _EXPAMT2 = "  ";
            _EXPAMT3 = "  ";
            _ACC_TRAN_DATE = "  ";
            _ACC_TRAN_NO = "  ";
            _GROSS_AMT = "  ";
            _TOT_AMT = "  ";
            _INV_NO = "  ";
            _INV_DT = "  ";
            _CONV_RATE = "  ";
            _EXCISE_TYPE = "  ";
            _PARTY_REFSRNO = "  ";
            _UPLOAD_USERID = "  ";
            _UPLOAD_TERMINAL = "  ";
            _UPLOAD_DATE = "  ";
            _UPLOAD_FILENAME = "  ";
            _UPLOAD_FLAG = "  ";
            _DC_TYPE = "";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string TRAN_TYPE { get { return _TRAN_TYPE; } set { _TRAN_TYPE = value; } }
        public string TRN_TYPE { get { return _TRN_TYPE; } set { _TRN_TYPE = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string BCODE { get { return _BCODE; } set { _BCODE = value; } }
        public string BAMT { get { return _BAMT; } set { _BAMT = value; } }
        public string CHA_NO { get { return _CHA_NO; } set { _CHA_NO = value; } }
        public string CHA_DT { get { return _CHA_DT; } set { _CHA_DT = value; } }
        public string SERIALNO { get { return _SERIALNO; } set { _SERIALNO = value; } }
        public string PO_NO { get { return _PO_NO; } set { _PO_NO = value; } }
        public string PO_DT { get { return _PO_DT; } set { _PO_DT = value; } }
        public string VEHICLE_NO { get { return _VEHICLE_NO; } set { _VEHICLE_NO = value; } }
        public string TCODE { get { return _TCODE; } set { _TCODE = value; } }
        public string TRANSPORT { get { return _TRANSPORT; } set { _TRANSPORT = value; } }
        public string LR_NO { get { return _LR_NO; } set { _LR_NO = value; } }
        public string LR_DATE { get { return _LR_DATE; } set { _LR_DATE = value; } }
        public string DRIVER_NAME { get { return _DRIVER_NAME; } set { _DRIVER_NAME = value; } }
        public string DRIVER_ADD { get { return _DRIVER_ADD; } set { _DRIVER_ADD = value; } }
        public string MDLNO { get { return _MDLNO; } set { _MDLNO = value; } }
        public string MDLSTATE { get { return _MDLSTATE; } set { _MDLSTATE = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string FORM_SRNO { get { return _FORM_SRNO; } set { _FORM_SRNO = value; } }
        public string CHECKPOST_NAME { get { return _CHECKPOST_NAME; } set { _CHECKPOST_NAME = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string REF_TRAN_DATE { get { return _REF_TRAN_DATE; } set { _REF_TRAN_DATE = value; } }
        public string REF_TRAN_NO { get { return _REF_TRAN_NO; } set { _REF_TRAN_NO = value; } }
        public string CLOSE_CHALLAN { get { return _CLOSE_CHALLAN; } set { _CLOSE_CHALLAN = value; } }
        public string TOT_RET { get { return _TOT_RET; } set { _TOT_RET = value; } }
        public string TOT_QTY { get { return _TOT_QTY; } set { _TOT_QTY = value; } }
        public string PARTY_TYPE { get { return _PARTY_TYPE; } set { _PARTY_TYPE = value; } }
        public string SALES_TYPE { get { return _SALES_TYPE; } set { _SALES_TYPE = value; } }
        public string TERM_CODE { get { return _TERM_CODE; } set { _TERM_CODE = value; } }
        public string LC_TRAN_DATE { get { return _LC_TRAN_DATE; } set { _LC_TRAN_DATE = value; } }
        public string LC_TRAN_NO { get { return _LC_TRAN_NO; } set { _LC_TRAN_NO = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string DEL_CONF_FLAG { get { return _DEL_CONF_FLAG; } set { _DEL_CONF_FLAG = value; } }
        public string DEL_CONF_DATE { get { return _DEL_CONF_DATE; } set { _DEL_CONF_DATE = value; } }
        public string CHK_FLAG { get { return _CHK_FLAG; } set { _CHK_FLAG = value; } }
        public string CHK_DATE { get { return _CHK_DATE; } set { _CHK_DATE = value; } }
        public string CHK_USERID { get { return _CHK_USERID; } set { _CHK_USERID = value; } }
        public string REC_DT { get { return _REC_DT; } set { _REC_DT = value; } }
        public string INV_TRAN_DATE { get { return _INV_TRAN_DATE; } set { _INV_TRAN_DATE = value; } }
        public string INV_TRAN_NO { get { return _INV_TRAN_NO; } set { _INV_TRAN_NO = value; } }
        public string TOT_CAMT { get { return _TOT_CAMT; } set { _TOT_CAMT = value; } }
        public string CRACODE1 { get { return _CRACODE1; } set { _CRACODE1 = value; } }
        public string DRACODE1 { get { return _DRACODE1; } set { _DRACODE1 = value; } }
        public string CRACODE2 { get { return _CRACODE2; } set { _CRACODE2 = value; } }
        public string DRACODE2 { get { return _DRACODE2; } set { _DRACODE2 = value; } }
        public string CRACODE3 { get { return _CRACODE3; } set { _CRACODE3 = value; } }
        public string DRACODE3 { get { return _DRACODE3; } set { _DRACODE3 = value; } }
        public string EXPAMT1 { get { return _EXPAMT1; } set { _EXPAMT1 = value; } }
        public string EXPAMT2 { get { return _EXPAMT2; } set { _EXPAMT2 = value; } }
        public string EXPAMT3 { get { return _EXPAMT3; } set { _EXPAMT3 = value; } }
        public string ACC_TRAN_DATE { get { return _ACC_TRAN_DATE; } set { _ACC_TRAN_DATE = value; } }
        public string ACC_TRAN_NO { get { return _ACC_TRAN_NO; } set { _ACC_TRAN_NO = value; } }
        public string GROSS_AMT { get { return _GROSS_AMT; } set { _GROSS_AMT = value; } }
        public string TOT_AMT { get { return _TOT_AMT; } set { _TOT_AMT = value; } }
        public string INV_NO { get { return _INV_NO; } set { _INV_NO = value; } }
        public string INV_DT { get { return _INV_DT; } set { _INV_DT = value; } }
        public string CONV_RATE { get { return _CONV_RATE; } set { _CONV_RATE = value; } }
        public string EXCISE_TYPE { get { return _EXCISE_TYPE; } set { _EXCISE_TYPE = value; } }
        public string PARTY_REFSRNO { get { return _PARTY_REFSRNO; } set { _PARTY_REFSRNO = value; } }
        public string UPLOAD_USERID { get { return _UPLOAD_USERID; } set { _UPLOAD_USERID = value; } }
        public string UPLOAD_TERMINAL { get { return _UPLOAD_TERMINAL; } set { _UPLOAD_TERMINAL = value; } }
        public string UPLOAD_DATE { get { return _UPLOAD_DATE; } set { _UPLOAD_DATE = value; } }
        public string UPLOAD_FILENAME { get { return _UPLOAD_FILENAME; } set { _UPLOAD_FILENAME = value; } }
        public string UPLOAD_FLAG { get { return _UPLOAD_FLAG; } set { _UPLOAD_FLAG = value; } }
        public string DC_TYPE { get { return _DC_TYPE; } set { _DC_TYPE = value; } }

        public static DataSet InsertDC_MASDetail(DC_MASLogicLayer DCMaster, string DCDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string TRN_TYPE)
        {
            return DC_MASDataLayer.InsertDC_MASDetail(DCMaster, DCDetails, COMP_CODE, BRANCH_CODE, YRDT1, TRAN_TYPE, TRN_TYPE);
        }

        public static DataSet UpdateDC_MASDetail(DC_MASLogicLayer DCMaster, string DCDetails)
        {
            return DC_MASDataLayer.UpdateDC_MASDetail(DCMaster, DCDetails);
        }

        public static string DeleteDC_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {
            return DC_MASDataLayer.DeleteDC_MASDetailsByID(TRAN_NO, TRAN_DATE);
        }

        public static DataSet GetAllIDWiseDC_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return DC_MASDataLayer.GetAllIDWiseDC_MASDetials(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetAllDC_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE, string TRN_TYPE)
        {
            return DC_MASDataLayer.GetAllDC_MASDetails(USERCODE, COMP_CODE, TRAN_TYPE, TRN_TYPE);
        }

        public static string GetSerialNoDC_MASDetailCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string ReceivedDate, string TRAN_TYPE, string TRN_TYPE)
        {
            return DC_MASDataLayer.GetSerialNoDC_MASDetailCompanyBranchYearWise(COMP_CODE, BRANCH_CODE, YRDT1, ReceivedDate, TRAN_TYPE, TRN_TYPE);
        }

        public static DataTable GetAllIDWiseDC_MasForPOGrid(string COMP_CODE, string BRANCH_CODE)
        {
            return DC_MASDataLayer.GetAllIDWiseDC_MasForPOGrid(COMP_CODE, BRANCH_CODE);
        }

        public static string GenerateBracodeForPurchaseOrder(string p_Type, string p_comp_code, string p_branch_code, DateTime p_yrdt1, string p_grnno, string p_scode, string p_qty, string p_rate, string p_tran_type, DateTime p_tran_date, string p_tran_no, string p_srno)
        {
            return DC_MASDataLayer.GenerateBracodeForPurchaseOrder(p_Type, p_comp_code, p_branch_code, p_yrdt1, p_grnno, p_scode, p_qty, p_rate, p_tran_type, p_tran_date, p_tran_no, p_srno);
        }


        public static string WORK_VIEWFLAG_FROMCOMPANY(int comp_code)
        {
            return DC_MASDataLayer.WORK_VIEWFLAG_FROMCOMPANY(comp_code);
        }
        public static DataTable GetAllDC_MasWiseComapnyAndACodeForTaxInvoiceBill(string COMP_CODE, string BRANCH_CODE, string ACODE, string TRAN_TYPE, string TRN_TYPE)
        {
            return DC_MASDataLayer.GetAllDC_MasWiseComapnyAndACodeForTaxInvoiceBill(COMP_CODE, BRANCH_CODE, ACODE, TRAN_TYPE, TRN_TYPE);
        }

        public static string UpdateDC_MAS_StatusWhenGenerateBill(DateTime TRAN_DATE, string TRAN_NO)
        {
            return DC_MASDataLayer.UpdateDC_MAS_StatusWhenGenerateBill(TRAN_DATE, TRAN_NO);
        }

        public static DataSet GetGRNBarcode(string comp_code, DateTime TRAN_DATE, string TRAN_NO)
        {
            return DC_MASDataLayer.GetGRNBarcode(comp_code, TRAN_DATE, TRAN_NO);
        }

        // DC_MASTER LOGIC LAYER FOR SALES

        public static string InsertDC_SALES_MASDetail(DC_MASLogicLayer DCMaster, string DCDetails, string ExtraDCDetails, string BarcodeDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string TRN_TYPE)
        {
            return DC_MASDataLayer.InsertDC_SALES_MASDetail(DCMaster, DCDetails, ExtraDCDetails, BarcodeDetails, COMP_CODE, BRANCH_CODE, YRDT1, TRAN_TYPE, TRN_TYPE);
        }
        public static string UpdateDC_SALES_MASDetail(DC_MASLogicLayer DCMaster, string DCDetails, string BarcodeDetails)
        {
            return DC_MASDataLayer.UpdateDC_SALES_MASDetail(DCMaster, DCDetails, BarcodeDetails);
        }

        public static string GetChallanNoDC_MASDetailCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string ChallanDate, string TRAN_TYPE, string TRN_TYPE)
        {
            return DC_MASDataLayer.GetChallanNoDC_MASDetailCompanyBranchYearWise(COMP_CODE, BRANCH_CODE, YRDT1, ChallanDate, TRAN_TYPE, TRN_TYPE);
        }

        public static string DeleteDC_SALES_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {
            return DC_MASDataLayer.DeleteDC_SALES_MASDetailsByID(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetAllDC_SALES_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE, string TRN_TYPE)
        {
            return DC_MASDataLayer.GetAllDC_SALES_MASDetails(USERCODE, COMP_CODE, TRAN_TYPE, TRN_TYPE);
        }

        public static DataSet GetAllIDWiseDC_SALES_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return DC_MASDataLayer.GetAllIDWiseDC_SALES_MASDetials(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetAllDC_MasWiseComapnyAndACodeForSalesInvoice(string COMP_CODE, string BRANCH_CODE, string ACODE)
        {
            return DC_MASDataLayer.GetAllDC_MasWiseComapnyAndACodeForSalesInvoice(COMP_CODE, BRANCH_CODE, ACODE);
        }


        // DC_MAS FOR PURCHASE RETURN (DC_SALES)

        public static string InsertPurchaseReturn_DeliveryChallan_MASDetail(DC_MASLogicLayer DCMaster, string DCDetails, string ExtraDCDetails, string BarcodeDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string TRN_TYPE)
        {
            return DC_MASDataLayer.InsertPurchaseReturn_DeliveryChallan_MASDetail(DCMaster, DCDetails, ExtraDCDetails, BarcodeDetails, COMP_CODE, BRANCH_CODE, YRDT1, TRAN_TYPE, TRN_TYPE);
        }

        public static DataTable GetAllPurchaseReturn_DC_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE, string TRN_TYPE)
        {
            return DC_MASDataLayer.GetAllPurchaseReturn_DC_MASDetails(USERCODE, COMP_CODE, TRAN_TYPE, TRN_TYPE);
        }

    }

    public class DC_DETLogicLayer

    {
        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _ORD_TRAN_DATE, _ORD_TRAN_NO, _ORD_SRNO, _SCODE, _PRODUCT_DESC, _ADD_PART_NO, _UOM, _QTY, _QTY_WT,
               _RATE, _AMT, _DIS_PER, _DIS_AMT, _G_AMT, _ST_PER, _ST_AMT, _ADD_ST_PER, _ADD_ST_AMT, _T_AMT, _ENDT, _STATUS, _RET_QTY, _CLOSE_ITEM, _CAL_TYPE,
               _F_AMT, _F_RATE, _T_RATE, _ENTRY_TYPE, _RATE_FE, _AMT_RS, _AMT_RS_RATE, _CUSTOM_PER, _CUSTOM_AMT, _CUSTOM_RATE, _EX_DUTY_PER, _EX_DUTY_AMT,
               _EX_DUTY_RATE, _EX_CESS_PER, _EX_CESS_AMT, _EX_CESS_RATE, _EX_SHCESS_PER, _EX_SHCESS_AMT, _EX_SHCESS_RATE, _EX_CVD_PER, _EX_CVD_AMT, _EX_CVD_RATE,
               _ASS_AMT, _ASS_RATE, _TOT_ASS_AMT, _TOT_ASS_RATE, _TOT_DUTY_AMT, _TOT_DUTY_RATE, _TOT_MOD_AMT, _TOT_MOD_RATE, _AMT_FE, _ADD_DIS_PER, _ADD_DIS_AMT,
               _CAL_RATE, _CAL_AMT, _ACT_RATE, _ACT_AMT, _GST_RATE, _GST_AMT, _CGST_RATE, _CGST_AMT, _SGST_RATE, _SGST_AMT, _IGST_RATE, _IGST_AMT;

        public DC_DETLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _ORD_TRAN_DATE = "  ";
            _ORD_TRAN_NO = "  ";
            _ORD_SRNO = "  ";
            _SCODE = "  ";
            _PRODUCT_DESC = "  ";
            _ADD_PART_NO = "  ";
            _UOM = "  ";
            _QTY = "  ";
            _QTY_WT = "  ";
            _RATE = "  ";
            _AMT = "  ";
            _DIS_PER = "  ";
            _DIS_AMT = "  ";
            _G_AMT = "  ";
            _ST_PER = "  ";
            _ST_AMT = "  ";
            _ADD_ST_PER = "  ";
            _ADD_ST_AMT = "  ";
            _T_AMT = "  ";
            _ENDT = "  ";
            _STATUS = "  ";
            _RET_QTY = "  ";
            _CLOSE_ITEM = "  ";
            _CAL_TYPE = "  ";
            _F_AMT = "  ";
            _F_RATE = "  ";
            _T_RATE = "  ";
            _ENTRY_TYPE = "  ";
            _RATE_FE = "  ";
            _AMT_RS = "  ";
            _AMT_RS_RATE = "  ";
            _CUSTOM_PER = "  ";
            _CUSTOM_AMT = "  ";
            _CUSTOM_RATE = "  ";
            _EX_DUTY_PER = "  ";
            _EX_DUTY_AMT = "  ";
            _EX_DUTY_RATE = "  ";
            _EX_CESS_PER = "  ";
            _EX_CESS_AMT = "  ";
            _EX_CESS_RATE = "  ";
            _EX_SHCESS_PER = "  ";
            _EX_SHCESS_AMT = "  ";
            _EX_SHCESS_RATE = "  ";
            _EX_CVD_PER = "  ";
            _EX_CVD_AMT = "  ";
            _EX_CVD_RATE = "  ";
            _ASS_AMT = "  ";
            _ASS_RATE = "  ";
            _TOT_ASS_AMT = "  ";
            _TOT_ASS_RATE = "  ";
            _TOT_DUTY_AMT = "  ";
            _TOT_DUTY_RATE = "  ";
            _TOT_MOD_AMT = "  ";
            _TOT_MOD_RATE = "  ";
            _AMT_FE = "  ";
            _ADD_DIS_PER = "  ";
            _ADD_DIS_AMT = "  ";
            _CAL_RATE = "  ";
            _CAL_AMT = "  ";
            _ACT_RATE = "  ";
            _ACT_AMT = "  ";
            _GST_RATE = "  ";
            _GST_AMT = "  ";
            _CGST_RATE = "  ";
            _CGST_AMT = "  ";
            _SGST_RATE = "  ";
            _SGST_AMT = "  ";
            _IGST_RATE = "  ";
            _IGST_AMT = "  ";

        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string ORD_TRAN_DATE { get { return _ORD_TRAN_DATE; } set { _ORD_TRAN_DATE = value; } }
        public string ORD_TRAN_NO { get { return _ORD_TRAN_NO; } set { _ORD_TRAN_NO = value; } }
        public string ORD_SRNO { get { return _ORD_SRNO; } set { _ORD_SRNO = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string PRODUCT_DESC { get { return _PRODUCT_DESC; } set { _PRODUCT_DESC = value; } }
        public string ADD_PART_NO { get { return _ADD_PART_NO; } set { _ADD_PART_NO = value; } }
        public string UOM { get { return _UOM; } set { _UOM = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string QTY_WT { get { return _QTY_WT; } set { _QTY_WT = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string DIS_PER { get { return _DIS_PER; } set { _DIS_PER = value; } }
        public string DIS_AMT { get { return _DIS_AMT; } set { _DIS_AMT = value; } }
        public string G_AMT { get { return _G_AMT; } set { _G_AMT = value; } }
        public string ST_PER { get { return _ST_PER; } set { _ST_PER = value; } }
        public string ST_AMT { get { return _ST_AMT; } set { _ST_AMT = value; } }
        public string ADD_ST_PER { get { return _ADD_ST_PER; } set { _ADD_ST_PER = value; } }
        public string ADD_ST_AMT { get { return _ADD_ST_AMT; } set { _ADD_ST_AMT = value; } }
        public string T_AMT { get { return _T_AMT; } set { _T_AMT = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string RET_QTY { get { return _RET_QTY; } set { _RET_QTY = value; } }
        public string CLOSE_ITEM { get { return _CLOSE_ITEM; } set { _CLOSE_ITEM = value; } }
        public string CAL_TYPE { get { return _CAL_TYPE; } set { _CAL_TYPE = value; } }
        public string F_AMT { get { return _F_AMT; } set { _F_AMT = value; } }
        public string F_RATE { get { return _F_RATE; } set { _F_RATE = value; } }
        public string T_RATE { get { return _T_RATE; } set { _T_RATE = value; } }
        public string ENTRY_TYPE { get { return _ENTRY_TYPE; } set { _ENTRY_TYPE = value; } }
        public string RATE_FE { get { return _RATE_FE; } set { _RATE_FE = value; } }
        public string AMT_RS { get { return _AMT_RS; } set { _AMT_RS = value; } }
        public string AMT_RS_RATE { get { return _AMT_RS_RATE; } set { _AMT_RS_RATE = value; } }
        public string CUSTOM_PER { get { return _CUSTOM_PER; } set { _CUSTOM_PER = value; } }
        public string CUSTOM_AMT { get { return _CUSTOM_AMT; } set { _CUSTOM_AMT = value; } }
        public string CUSTOM_RATE { get { return _CUSTOM_RATE; } set { _CUSTOM_RATE = value; } }
        public string EX_DUTY_PER { get { return _EX_DUTY_PER; } set { _EX_DUTY_PER = value; } }
        public string EX_DUTY_AMT { get { return _EX_DUTY_AMT; } set { _EX_DUTY_AMT = value; } }
        public string EX_DUTY_RATE { get { return _EX_DUTY_RATE; } set { _EX_DUTY_RATE = value; } }
        public string EX_CESS_PER { get { return _EX_CESS_PER; } set { _EX_CESS_PER = value; } }
        public string EX_CESS_AMT { get { return _EX_CESS_AMT; } set { _EX_CESS_AMT = value; } }
        public string EX_CESS_RATE { get { return _EX_CESS_RATE; } set { _EX_CESS_RATE = value; } }
        public string EX_SHCESS_PER { get { return _EX_SHCESS_PER; } set { _EX_SHCESS_PER = value; } }
        public string EX_SHCESS_AMT { get { return _EX_SHCESS_AMT; } set { _EX_SHCESS_AMT = value; } }
        public string EX_SHCESS_RATE { get { return _EX_SHCESS_RATE; } set { _EX_SHCESS_RATE = value; } }
        public string EX_CVD_PER { get { return _EX_CVD_PER; } set { _EX_CVD_PER = value; } }
        public string EX_CVD_AMT { get { return _EX_CVD_AMT; } set { _EX_CVD_AMT = value; } }
        public string EX_CVD_RATE { get { return _EX_CVD_RATE; } set { _EX_CVD_RATE = value; } }
        public string ASS_AMT { get { return _ASS_AMT; } set { _ASS_AMT = value; } }
        public string ASS_RATE { get { return _ASS_RATE; } set { _ASS_RATE = value; } }
        public string TOT_ASS_AMT { get { return _TOT_ASS_AMT; } set { _TOT_ASS_AMT = value; } }
        public string TOT_ASS_RATE { get { return _TOT_ASS_RATE; } set { _TOT_ASS_RATE = value; } }
        public string TOT_DUTY_AMT { get { return _TOT_DUTY_AMT; } set { _TOT_DUTY_AMT = value; } }
        public string TOT_DUTY_RATE { get { return _TOT_DUTY_RATE; } set { _TOT_DUTY_RATE = value; } }
        public string TOT_MOD_AMT { get { return _TOT_MOD_AMT; } set { _TOT_MOD_AMT = value; } }
        public string TOT_MOD_RATE { get { return _TOT_MOD_RATE; } set { _TOT_MOD_RATE = value; } }
        public string AMT_FE { get { return _AMT_FE; } set { _AMT_FE = value; } }
        public string ADD_DIS_PER { get { return _ADD_DIS_PER; } set { _ADD_DIS_PER = value; } }
        public string ADD_DIS_AMT { get { return _ADD_DIS_AMT; } set { _ADD_DIS_AMT = value; } }
        public string CAL_RATE { get { return _CAL_RATE; } set { _CAL_RATE = value; } }
        public string CAL_AMT { get { return _CAL_AMT; } set { _CAL_AMT = value; } }
        public string ACT_RATE { get { return _ACT_RATE; } set { _ACT_RATE = value; } }
        public string ACT_AMT { get { return _ACT_AMT; } set { _ACT_AMT = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string GST_AMT { get { return _GST_AMT; } set { _GST_AMT = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string CGST_AMT { get { return _CGST_AMT; } set { _CGST_AMT = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string SGST_AMT { get { return _SGST_AMT; } set { _SGST_AMT = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }


        public static DataTable GetAllDC_DetailByCompany(string COMP_CODE)
        {
            return DC_DETDataLayer.GetAllDC_DetailByCompany(COMP_CODE);
        }

        public static DataTable GetAllWiseID_DC_DET_Detail(string TRAN_NO, DateTime TRAN_DATE)
        {
            return DC_DETDataLayer.GetAllWiseID_DC_DET_Detail(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetAllDC_DetailByCompanyForSales(string COMP_CODE)
        {
            return DC_DETDataLayer.GetAllDC_DetailByCompanyForSales(COMP_CODE);
        }

    }




    public class BARCODE_MASLogicLayer

    {

        string _COMP_CODE, _BRANCH_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _OP_TRAN_DATE, _OP_TRAN_NO, _PUR_TRAN_DATE, _PUR_TRAN_NO, _PUR_SRNO, _BR_TRAN_DATE, _BR_TRAN_NO, _BR_SRNO, _TRAN_TYPE, _SCODE, _BARCODE, _STATUS, _BR_SR, _FIN_YEAR, _BARCODE_NO, _RATE, _ASS_TRAN_DATE, _ASS_TRAN_NO, _OS_YEAR, _STKDT, _USE_BY, _USE_DATE, _USE_NO, _USE_TRAN_DATE, _USE_TRAN_NO, _USE_SRNO, _ASS_SRNO;

        public BARCODE_MASLogicLayer()
        {
            _COMP_CODE = "  ";
            _BRANCH_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _OP_TRAN_DATE = "  ";
            _OP_TRAN_NO = "  ";
            _PUR_TRAN_DATE = "  ";
            _PUR_TRAN_NO = "  ";
            _PUR_SRNO = "  ";
            _BR_TRAN_DATE = "  ";
            _BR_TRAN_NO = "  ";
            _BR_SRNO = "  ";
            _TRAN_TYPE = "  ";
            _SCODE = "  ";
            _BARCODE = "  ";
            _STATUS = "  ";
            _BR_SR = "  ";
            _FIN_YEAR = "  ";
            _BARCODE_NO = "  ";
            _RATE = "  ";
            _ASS_TRAN_DATE = "  ";
            _ASS_TRAN_NO = "  ";
            _OS_YEAR = "  ";
            _STKDT = "  ";
            _USE_BY = "  ";
            _USE_DATE = "  ";
            _USE_NO = "  ";
            _USE_TRAN_DATE = "  ";
            _USE_TRAN_NO = "  ";
            _USE_SRNO = "  ";
            _ASS_SRNO = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string OP_TRAN_DATE { get { return _OP_TRAN_DATE; } set { _OP_TRAN_DATE = value; } }
        public string OP_TRAN_NO { get { return _OP_TRAN_NO; } set { _OP_TRAN_NO = value; } }
        public string PUR_TRAN_DATE { get { return _PUR_TRAN_DATE; } set { _PUR_TRAN_DATE = value; } }
        public string PUR_TRAN_NO { get { return _PUR_TRAN_NO; } set { _PUR_TRAN_NO = value; } }
        public string PUR_SRNO { get { return _PUR_SRNO; } set { _PUR_SRNO = value; } }
        public string BR_TRAN_DATE { get { return _BR_TRAN_DATE; } set { _BR_TRAN_DATE = value; } }
        public string BR_TRAN_NO { get { return _BR_TRAN_NO; } set { _BR_TRAN_NO = value; } }
        public string BR_SRNO { get { return _BR_SRNO; } set { _BR_SRNO = value; } }
        public string TRAN_TYPE { get { return _TRAN_TYPE; } set { _TRAN_TYPE = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string BARCODE { get { return _BARCODE; } set { _BARCODE = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string BR_SR { get { return _BR_SR; } set { _BR_SR = value; } }
        public string FIN_YEAR { get { return _FIN_YEAR; } set { _FIN_YEAR = value; } }
        public string BARCODE_NO { get { return _BARCODE_NO; } set { _BARCODE_NO = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string ASS_TRAN_DATE { get { return _ASS_TRAN_DATE; } set { _ASS_TRAN_DATE = value; } }
        public string ASS_TRAN_NO { get { return _ASS_TRAN_NO; } set { _ASS_TRAN_NO = value; } }
        public string OS_YEAR { get { return _OS_YEAR; } set { _OS_YEAR = value; } }
        public string STKDT { get { return _STKDT; } set { _STKDT = value; } }
        public string USE_BY { get { return _USE_BY; } set { _USE_BY = value; } }
        public string USE_DATE { get { return _USE_DATE; } set { _USE_DATE = value; } }
        public string USE_NO { get { return _USE_NO; } set { _USE_NO = value; } }
        public string USE_TRAN_DATE { get { return _USE_TRAN_DATE; } set { _USE_TRAN_DATE = value; } }
        public string USE_TRAN_NO { get { return _USE_TRAN_NO; } set { _USE_TRAN_NO = value; } }
        public string USE_SRNO { get { return _USE_SRNO; } set { _USE_SRNO = value; } }
        public string ASS_SRNO { get { return _ASS_SRNO; } set { _ASS_SRNO = value; } }


        public static DataTable GetStockWiseBarcodeDetailsFor_Grid(string COMP_CODE, string BRANCH_CODE, string TRAN_NO, DateTime TRAN_DATE, string SCODE, string SRNO)
        {
            return BARCODE_MASDataLayer.GetStockWiseBarcodeDetailsFor_Grid(COMP_CODE, BRANCH_CODE, TRAN_NO, TRAN_DATE, SCODE, SRNO);
        }

        public static DataTable GetBarcodeDetail_WiseBarcodeNo(string BARCODE)
        {
            return BARCODE_MASDataLayer.GetBarcodeDetail_WiseBarcodeNo(BARCODE);
        }

        public static DataTable GetBarcodeDetail_ForDeAssembleTransaction(string BARCODE)
        {
            return BARCODE_MASDataLayer.GetBarcodeDetail_ForDeAssembleTransaction(BARCODE);
        }

        public static DataTable GetBarcodeDetailsFor_DeAseembleBarcodeGrid(string COMP_CODE, string BRANCH_CODE, string TRAN_NO, DateTime TRAN_DATE, string SRNO)
        {
            return BARCODE_MASDataLayer.GetBarcodeDetailsFor_DeAseembleBarcodeGrid(COMP_CODE, BRANCH_CODE, TRAN_NO, TRAN_DATE, SRNO);
        }
    }



    public class DC_MAS_BARCODELogicLayer
    {
        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _BAR_TRAN_DATE, _BAR_TRAN_NO, _BAR_SRNO, _QTY;

        public DC_MAS_BARCODELogicLayer()
        {
            _COMP_CODE = "";
            _TRAN_DATE = "";
            _TRAN_NO = "";
            _SRNO = "";
            _BAR_TRAN_DATE = "";
            _BAR_TRAN_NO = "";
            _BAR_SRNO = "";
            _QTY = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string BAR_TRAN_DATE { get { return _BAR_TRAN_DATE; } set { _BAR_TRAN_DATE = value; } }
        public string BAR_TRAN_NO { get { return _BAR_TRAN_NO; } set { _BAR_TRAN_NO = value; } }
        public string BAR_SRNO { get { return _BAR_SRNO; } set { _BAR_SRNO = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }

    }



    public class ASS_TRANMASLogicLayer

    {

        string _COMP_CODE, _BRANCH_CODE, _TRAN_DATE, _TRAN_NO, _TRAN_TYPE, _TRNDT, _SRNO, _SCODE, _BCODE, _QTY, _RATE, _AMT, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE, _AUTH_FLAG, _AUTH_DATE, _AUTH_USERID, _REMARK, _ENDT, _STATUS, _PART_AMT, _LAB_AMT, _BAR_TRAN_DATE, _BAR_TRAN_NO, _BAR_SRNO, _CONF_FLAG, _CONF_DATE, _CONF_USERID;

        public ASS_TRANMASLogicLayer()
        {
            _COMP_CODE = "  ";
            _BRANCH_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _TRAN_TYPE = "  ";
            _TRNDT = "  ";
            _SRNO = "  ";
            _SCODE = "  ";
            _BCODE = "  ";
            _QTY = "  ";
            _RATE = "  ";
            _AMT = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _AUTH_FLAG = "  ";
            _AUTH_DATE = "  ";
            _AUTH_USERID = "  ";
            _REMARK = "  ";
            _ENDT = "  ";
            _STATUS = "  ";
            _PART_AMT = "  ";
            _LAB_AMT = "  ";
            _BAR_TRAN_DATE = "  ";
            _BAR_TRAN_NO = "  ";
            _BAR_SRNO = "  ";
            _CONF_FLAG = "";
            _CONF_DATE = "";
            _CONF_USERID = "";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string TRAN_TYPE { get { return _TRAN_TYPE; } set { _TRAN_TYPE = value; } }
        public string TRNDT { get { return _TRNDT; } set { _TRNDT = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string BCODE { get { return _BCODE; } set { _BCODE = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string AUTH_FLAG { get { return _AUTH_FLAG; } set { _AUTH_FLAG = value; } }
        public string AUTH_DATE { get { return _AUTH_DATE; } set { _AUTH_DATE = value; } }
        public string AUTH_USERID { get { return _AUTH_USERID; } set { _AUTH_USERID = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string PART_AMT { get { return _PART_AMT; } set { _PART_AMT = value; } }
        public string LAB_AMT { get { return _LAB_AMT; } set { _LAB_AMT = value; } }
        public string BAR_TRAN_DATE { get { return _BAR_TRAN_DATE; } set { _BAR_TRAN_DATE = value; } }
        public string BAR_TRAN_NO { get { return _BAR_TRAN_NO; } set { _BAR_TRAN_NO = value; } }
        public string BAR_SRNO { get { return _BAR_SRNO; } set { _BAR_SRNO = value; } }
        public string CONF_FLAG { get { return _CONF_FLAG; } set { _CONF_FLAG = value; } }
        public string CONF_DATE { get { return _CONF_DATE; } set { _CONF_DATE = value; } }
        public string CONF_USERID { get { return _CONF_USERID; } set { _CONF_USERID = value; } }

        public static string InsertASSEMBLE_TRAN_MASDetailNew(ASS_TRANMASLogicLayer ASS_TRANMaster, string ASS_TRANDetails, string BarcodeDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string WORK_VIEWFLAG)
        {
            return ASS_TRANMASDataLayer.InsertASSEMBLE_TRAN_MASDetailNew(ASS_TRANMaster, ASS_TRANDetails, BarcodeDetails, COMP_CODE, BRANCH_CODE, YRDT1, TRAN_TYPE, WORK_VIEWFLAG);
        }

        public static string UpdateASSEMBLE_TRAN_MASDetail(ASS_TRANMASLogicLayer ASS_TRANMaster, string ASS_TRANDetails, string BarcodeDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string WORK_VIEWFLAG)
        {
            return ASS_TRANMASDataLayer.UpdateASSEMBLE_TRAN_MASDetail(ASS_TRANMaster, ASS_TRANDetails, BarcodeDetails, COMP_CODE, BRANCH_CODE, YRDT1, TRAN_TYPE, WORK_VIEWFLAG);
        }

        public static string DeleteASSEMBLE_TRAN_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {
            return ASS_TRANMASDataLayer.DeleteASSEMBLE_TRAN_MASDetailsByID(TRAN_NO, TRAN_DATE);
        }

        public static string GetSrNo_ForAssembleTransaction(string COMP_CODE, string BRANCH_CODE, string YRDT1, string AssembleDate, string TRAN_TYPE)
        {
            return ASS_TRANMASDataLayer.GetSrNo_ForAssembleTransaction(COMP_CODE, BRANCH_CODE, YRDT1, AssembleDate, TRAN_TYPE);
        }

        public static DataTable GetAllASSEMBLE_TRAN_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE)
        {
            return ASS_TRANMASDataLayer.GetAllASSEMBLE_TRAN_MASDetails(USERCODE, COMP_CODE, TRAN_TYPE);
        }

        public static DataSet GetAllIDWiseASSEMBLE_TRAN_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return ASS_TRANMASDataLayer.GetAllIDWiseASSEMBLE_TRAN_MASDetials(TRAN_NO, TRAN_DATE);
        }


        // ASSEMBLE TRANSATION MASTER LOGICLAYER

        public static DataSet InsertDE_ASSEMBLE_TRAN_MASDetail(ASS_TRANMASLogicLayer ASS_TRANMaster, string ASS_TRANDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE)
        {
            return ASS_TRANMASDataLayer.InsertDE_ASSEMBLE_TRAN_MASDetail(ASS_TRANMaster, ASS_TRANDetails, COMP_CODE, BRANCH_CODE, YRDT1, TRAN_TYPE);
        }
        public static DataSet UpdateDE_ASSEMBLE_TRAN_MASDetail(ASS_TRANMASLogicLayer ASS_TRANMaster, string ASS_TRANDetails)
        {
            return ASS_TRANMASDataLayer.UpdateDE_ASSEMBLE_TRAN_MASDetail(ASS_TRANMaster, ASS_TRANDetails);
        }

        public static DataTable GetAllDE_ASSEMBLE_TRAN_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE)
        {
            return ASS_TRANMASDataLayer.GetAllDE_ASSEMBLE_TRAN_MASDetails(USERCODE, COMP_CODE, TRAN_TYPE);
        }

        public static DataSet GetAllIDWiseDE_ASSEMBLE_TRAN_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return ASS_TRANMASDataLayer.GetAllIDWiseDE_ASSEMBLE_TRAN_MASDetials(TRAN_NO, TRAN_DATE);
        }


    }


    public class ASS_TRANDETLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _SCODE, _QTY, _RATE, _AMT, _ENDT, _STATUS, _PER;

        public ASS_TRANDETLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _SCODE = "  ";
            _QTY = "  ";
            _RATE = "  ";
            _AMT = "  ";
            _ENDT = "  ";
            _STATUS = "  ";
            _PER = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string PER { get { return _PER; } set { _PER = value; } }


    }



    public class ASS_USE_BARCODELogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _BAR_TRAN_DATE, _BAR_TRAN_NO, _BAR_SRNO, _QTY, _RATE, _AMT;

        public ASS_USE_BARCODELogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _BAR_TRAN_DATE = "  ";
            _BAR_TRAN_NO = "  ";
            _BAR_SRNO = "  ";
            _QTY = "  ";
            _RATE = "  ";
            _AMT = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string BAR_TRAN_DATE { get { return _BAR_TRAN_DATE; } set { _BAR_TRAN_DATE = value; } }
        public string BAR_TRAN_NO { get { return _BAR_TRAN_NO; } set { _BAR_TRAN_NO = value; } }
        public string BAR_SRNO { get { return _BAR_SRNO; } set { _BAR_SRNO = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }

    }



    public class STK_IRMASLogicLayer

    {

        string _COMP_CODE, _BRANCH_CODE, _TRAN_DATE, _TRAN_NO, _TRAN_TYPE, _TO_BRANCH_CODE, _CHA_NO, _CHA_DT, _SERIALNO, _VEHICLE_NO, _TCODE, _TRANSPORT, _LR_NO, _LR_DATE, _DRIVER_NAME, _DRIVER_ADD, _MDLNO, _MDLSTATE, _REMARK, _FORM_SRNO, _CHECKPOST_NAME, _TOT_QTY, _TOT_AMT, _ENDT, _STATUS, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE, _REF_TRAN_DATE, _REF_TRAN_NO, _ISS_FLAG, _REC_FLAG, _REC_USERID, _REC_DATE, _BCODE, _CHK_FLAG, _CHK_DATE, _CHK_USERID, _CHK_BCODE, _GST_APP_FLAG, _PARTY_TYPE, _INV_NUMBER, _INV_DT, _EWAY_BILLNO, _GST_RATE, _GST_AMT, _CGST_RATE, _CGST_AMT, _SGST_RATE, _SGST_AMT, _IGST_RATE, _IGST_AMT, _RO_AMT, _NET_AMT, _TO_BRANCH_ACODE;

        public STK_IRMASLogicLayer()
        {
            _COMP_CODE = "  ";
            _BRANCH_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _TRAN_TYPE = "  ";
            _TO_BRANCH_CODE = "  ";
            _CHA_NO = "  ";
            _CHA_DT = "  ";
            _SERIALNO = "  ";
            _VEHICLE_NO = "  ";
            _TCODE = "  ";
            _TRANSPORT = "  ";
            _LR_NO = "  ";
            _LR_DATE = "  ";
            _DRIVER_NAME = "  ";
            _DRIVER_ADD = "  ";
            _MDLNO = "  ";
            _MDLSTATE = "  ";
            _REMARK = "  ";
            _FORM_SRNO = "  ";
            _CHECKPOST_NAME = "  ";
            _TOT_QTY = "  ";
            _TOT_AMT = "  ";
            _ENDT = "  ";
            _STATUS = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _REF_TRAN_DATE = "  ";
            _REF_TRAN_NO = "  ";
            _ISS_FLAG = "  ";
            _REC_FLAG = "  ";
            _REC_USERID = "  ";
            _REC_DATE = "  ";
            _BCODE = "  ";
            _CHK_FLAG = "  ";
            _CHK_DATE = "  ";
            _CHK_USERID = "  ";
            _CHK_BCODE = "  ";
            _GST_APP_FLAG = "  ";
            _PARTY_TYPE = "  ";
            _INV_NUMBER = "  ";
            _INV_DT = "  ";
            _EWAY_BILLNO = "  ";
            _GST_RATE = "  ";
            _GST_AMT = "  ";
            _CGST_RATE = "  ";
            _CGST_AMT = "  ";
            _SGST_RATE = "  ";
            _SGST_AMT = "  ";
            _IGST_RATE = "  ";
            _IGST_AMT = "  ";
            _RO_AMT = "  ";
            _NET_AMT = "  ";
            _TO_BRANCH_ACODE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string TRAN_TYPE { get { return _TRAN_TYPE; } set { _TRAN_TYPE = value; } }
        public string TO_BRANCH_CODE { get { return _TO_BRANCH_CODE; } set { _TO_BRANCH_CODE = value; } }
        public string CHA_NO { get { return _CHA_NO; } set { _CHA_NO = value; } }
        public string CHA_DT { get { return _CHA_DT; } set { _CHA_DT = value; } }
        public string SERIALNO { get { return _SERIALNO; } set { _SERIALNO = value; } }
        public string VEHICLE_NO { get { return _VEHICLE_NO; } set { _VEHICLE_NO = value; } }
        public string TCODE { get { return _TCODE; } set { _TCODE = value; } }
        public string TRANSPORT { get { return _TRANSPORT; } set { _TRANSPORT = value; } }
        public string LR_NO { get { return _LR_NO; } set { _LR_NO = value; } }
        public string LR_DATE { get { return _LR_DATE; } set { _LR_DATE = value; } }
        public string DRIVER_NAME { get { return _DRIVER_NAME; } set { _DRIVER_NAME = value; } }
        public string DRIVER_ADD { get { return _DRIVER_ADD; } set { _DRIVER_ADD = value; } }
        public string MDLNO { get { return _MDLNO; } set { _MDLNO = value; } }
        public string MDLSTATE { get { return _MDLSTATE; } set { _MDLSTATE = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string FORM_SRNO { get { return _FORM_SRNO; } set { _FORM_SRNO = value; } }
        public string CHECKPOST_NAME { get { return _CHECKPOST_NAME; } set { _CHECKPOST_NAME = value; } }
        public string TOT_QTY { get { return _TOT_QTY; } set { _TOT_QTY = value; } }
        public string TOT_AMT { get { return _TOT_AMT; } set { _TOT_AMT = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string REF_TRAN_DATE { get { return _REF_TRAN_DATE; } set { _REF_TRAN_DATE = value; } }
        public string REF_TRAN_NO { get { return _REF_TRAN_NO; } set { _REF_TRAN_NO = value; } }
        public string ISS_FLAG { get { return _ISS_FLAG; } set { _ISS_FLAG = value; } }
        public string REC_FLAG { get { return _REC_FLAG; } set { _REC_FLAG = value; } }
        public string REC_USERID { get { return _REC_USERID; } set { _REC_USERID = value; } }
        public string REC_DATE { get { return _REC_DATE; } set { _REC_DATE = value; } }
        public string BCODE { get { return _BCODE; } set { _BCODE = value; } }
        public string CHK_FLAG { get { return _CHK_FLAG; } set { _CHK_FLAG = value; } }
        public string CHK_DATE { get { return _CHK_DATE; } set { _CHK_DATE = value; } }
        public string CHK_USERID { get { return _CHK_USERID; } set { _CHK_USERID = value; } }
        public string CHK_BCODE { get { return _CHK_BCODE; } set { _CHK_BCODE = value; } }
        public string GST_APP_FLAG { get { return _GST_APP_FLAG; } set { _GST_APP_FLAG = value; } }
        public string PARTY_TYPE { get { return _PARTY_TYPE; } set { _PARTY_TYPE = value; } }
        public string INV_NUMBER { get { return _INV_NUMBER; } set { _INV_NUMBER = value; } }
        public string INV_DT { get { return _INV_DT; } set { _INV_DT = value; } }
        public string EWAY_BILLNO { get { return _EWAY_BILLNO; } set { _EWAY_BILLNO = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string GST_AMT { get { return _GST_AMT; } set { _GST_AMT = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string CGST_AMT { get { return _CGST_AMT; } set { _CGST_AMT = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string SGST_AMT { get { return _SGST_AMT; } set { _SGST_AMT = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }
        public string RO_AMT { get { return _RO_AMT; } set { _RO_AMT = value; } }
        public string NET_AMT { get { return _NET_AMT; } set { _NET_AMT = value; } }
        public string TO_BRANCH_ACODE { get { return _TO_BRANCH_ACODE; } set { _TO_BRANCH_ACODE = value; } }


        public static string InsertSTOCK_ISSUE_BRANCH_MASDetail(STK_IRMASLogicLayer STK_IRMASMaster, string STK_IRDETDetails, string BarcodeDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE)
        {
            return STK_IRMASDataLayer.InsertSTOCK_ISSUE_BRANCH_MASDetail(STK_IRMASMaster, STK_IRDETDetails, BarcodeDetails, COMP_CODE, BRANCH_CODE, YRDT1, TRAN_TYPE);
        }

        public static string UpdateSTOCK_ISSUE_BRANCH_MASDetail(STK_IRMASLogicLayer STK_IRMASMaster, string STK_IRDETDetails, string BarcodeDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string WORK_VIEWFLAG)
        {
            return STK_IRMASDataLayer.UpdateSTOCK_ISSUE_BRANCH_MASDetail(STK_IRMASMaster, STK_IRDETDetails, BarcodeDetails, COMP_CODE, BRANCH_CODE, YRDT1, TRAN_TYPE, WORK_VIEWFLAG);
        }

        public static string DeleteSTOCK_ISSUE_TO_BRANCHDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {
            return STK_IRMASDataLayer.DeleteSTOCK_ISSUE_TO_BRANCHDetailsByID(TRAN_NO, TRAN_DATE);
        }

        public static DataSet GetAllIDWiseSTOCK_ISSUE_BRANCH_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return STK_IRMASDataLayer.GetAllIDWiseSTOCK_ISSUE_BRANCH_MASDetials(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetAllSTOCK_ISSUE_BRANCH_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE)
        {
            return STK_IRMASDataLayer.GetAllSTOCK_ISSUE_BRANCH_MASDetails(USERCODE, COMP_CODE, TRAN_TYPE);
        }

        public static DataTable GetPartytypeGSTApplicableBranchWise(string COMP_CODE, string FROM_BRANCH, string TO_BRANCH, DateTime INI_DATE)
        {

            return STK_IRMASDataLayer.GetPartytypeGSTApplicableBranchWise(COMP_CODE, FROM_BRANCH, TO_BRANCH, INI_DATE);
        }


        public static string GetChal_NoSTOCK_IRMASDetailCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string ChallanDtae, string TRAN_TYPE)
        {
            return STK_IRMASDataLayer.GetChal_NoSTOCK_IRMASDetailCompanyBranchYearWise(COMP_CODE, BRANCH_CODE, YRDT1, ChallanDtae, TRAN_TYPE);
        }

        public static DataSet GetDeAssemblyBarcode(string comp_code, DateTime TRAN_DATE, string TRAN_NO)
        {
            return STK_IRMASDataLayer.GetDeAssemblyBarcode(comp_code, TRAN_DATE, TRAN_NO);
        }


    }


        public class STK_IRDETLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _REF_TRAN_DATE, _REF_TRAN_NO, _REF_SRNO, _SCODE, _QTY, _RATE, _AMT, _DIS_PER, _DIS_AMT, _G_AMT, _ST_PER, _ST_AMT, _ADD_ST_PER, _ADD_ST_AMT, _T_AMT, _ENDT, _STATUS, _GST_RATE, _GST_AMT, _CGST_RATE, _CGST_AMT, _SGST_RATE, _SGST_AMT, _IGST_RATE, _IGST_AMT;

        public STK_IRDETLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _REF_TRAN_DATE = "  ";
            _REF_TRAN_NO = "  ";
            _REF_SRNO = "  ";
            _SCODE = "  ";
            _QTY = "  ";
            _RATE = "  ";
            _AMT = "  ";
            _DIS_PER = "  ";
            _DIS_AMT = "  ";
            _G_AMT = "  ";
            _ST_PER = "  ";
            _ST_AMT = "  ";
            _ADD_ST_PER = "  ";
            _ADD_ST_AMT = "  ";
            _T_AMT = "  ";
            _ENDT = "  ";
            _STATUS = "  ";
            _GST_RATE = "  ";
            _GST_AMT = "  ";
            _CGST_RATE = "  ";
            _CGST_AMT = "  ";
            _SGST_RATE = "  ";
            _SGST_AMT = "  ";
            _IGST_RATE = "  ";
            _IGST_AMT = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string REF_TRAN_DATE { get { return _REF_TRAN_DATE; } set { _REF_TRAN_DATE = value; } }
        public string REF_TRAN_NO { get { return _REF_TRAN_NO; } set { _REF_TRAN_NO = value; } }
        public string REF_SRNO { get { return _REF_SRNO; } set { _REF_SRNO = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string DIS_PER { get { return _DIS_PER; } set { _DIS_PER = value; } }
        public string DIS_AMT { get { return _DIS_AMT; } set { _DIS_AMT = value; } }
        public string G_AMT { get { return _G_AMT; } set { _G_AMT = value; } }
        public string ST_PER { get { return _ST_PER; } set { _ST_PER = value; } }
        public string ST_AMT { get { return _ST_AMT; } set { _ST_AMT = value; } }
        public string ADD_ST_PER { get { return _ADD_ST_PER; } set { _ADD_ST_PER = value; } }
        public string ADD_ST_AMT { get { return _ADD_ST_AMT; } set { _ADD_ST_AMT = value; } }
        public string T_AMT { get { return _T_AMT; } set { _T_AMT = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string GST_AMT { get { return _GST_AMT; } set { _GST_AMT = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string CGST_AMT { get { return _CGST_AMT; } set { _CGST_AMT = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string SGST_AMT { get { return _SGST_AMT; } set { _SGST_AMT = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }

    }


    public class STK_IRMAS_BARCODELogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _BAR_TRAN_DATE, _BAR_TRAN_NO, _BAR_SRNO, _QTY, _RATE, _AMT;

        public STK_IRMAS_BARCODELogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _BAR_TRAN_DATE = "  ";
            _BAR_TRAN_NO = "  ";
            _BAR_SRNO = "  ";
            _QTY = "  ";
            _RATE = "  ";
            _AMT = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string BAR_TRAN_DATE { get { return _BAR_TRAN_DATE; } set { _BAR_TRAN_DATE = value; } }
        public string BAR_TRAN_NO { get { return _BAR_TRAN_NO; } set { _BAR_TRAN_NO = value; } }
        public string BAR_SRNO { get { return _BAR_SRNO; } set { _BAR_SRNO = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
    }




    public class BRANCH_RECMASLogicLayer

    {

        string _COMP_CODE, _BRANCH_CODE, _TRAN_DATE, _TRAN_NO, _TRAN_TYPE, _TO_BRANCH_CODE, _CHA_NO, _CHA_DT, _SERIALNO, _VEHICLE_NO, _TCODE, _TRANSPORT, _LR_NO, _LR_DATE, _DRIVER_NAME, _DRIVER_ADD, _MDLNO, _MDLSTATE, _REMARK, _FORM_SRNO, _CHECKPOST_NAME, _TOT_QTY, _TOT_AMT, _ENDT, _STATUS, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE, _REF_TRAN_DATE, _REF_TRAN_NO, _ISS_FLAG, _REC_FLAG, _REC_USERID, _REC_DATE, _GST_APP_FLAG, _PARTY_TYPE, _INV_NO, _INV_DT, _EWAY_BILLNO, _GST_RATE, _GST_AMT, _CGST_RATE, _CGST_AMT, _SGST_RATE, _SGST_AMT, _IGST_RATE, _IGST_AMT, _RO_AMT, _NET_AMT, _FROM_BRANCH_ACODE;

        public BRANCH_RECMASLogicLayer()
        {
            _COMP_CODE = "  ";
            _BRANCH_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _TRAN_TYPE = "  ";
            _TO_BRANCH_CODE = "  ";
            _CHA_NO = "  ";
            _CHA_DT = "  ";
            _SERIALNO = "  ";
            _VEHICLE_NO = "  ";
            _TCODE = "  ";
            _TRANSPORT = "  ";
            _LR_NO = "  ";
            _LR_DATE = "  ";
            _DRIVER_NAME = "  ";
            _DRIVER_ADD = "  ";
            _MDLNO = "  ";
            _MDLSTATE = "  ";
            _REMARK = "  ";
            _FORM_SRNO = "  ";
            _CHECKPOST_NAME = "  ";
            _TOT_QTY = "  ";
            _TOT_AMT = "  ";
            _ENDT = "  ";
            _STATUS = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _REF_TRAN_DATE = "  ";
            _REF_TRAN_NO = "  ";
            _ISS_FLAG = "  ";
            _REC_FLAG = "  ";
            _REC_USERID = "  ";
            _REC_DATE = "  ";
            _GST_APP_FLAG = "  ";
            _PARTY_TYPE = "  ";
            _INV_NO = "  ";
            _INV_DT = "  ";
            _EWAY_BILLNO = "  ";
            _GST_RATE = "  ";
            _GST_AMT = "  ";
            _CGST_RATE = "  ";
            _CGST_AMT = "  ";
            _SGST_RATE = "  ";
            _SGST_AMT = "  ";
            _IGST_RATE = "  ";
            _IGST_AMT = "  ";
            _RO_AMT = "  ";
            _NET_AMT = "  ";
            _FROM_BRANCH_ACODE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string TRAN_TYPE { get { return _TRAN_TYPE; } set { _TRAN_TYPE = value; } }
        public string TO_BRANCH_CODE { get { return _TO_BRANCH_CODE; } set { _TO_BRANCH_CODE = value; } }
        public string CHA_NO { get { return _CHA_NO; } set { _CHA_NO = value; } }
        public string CHA_DT { get { return _CHA_DT; } set { _CHA_DT = value; } }
        public string SERIALNO { get { return _SERIALNO; } set { _SERIALNO = value; } }
        public string VEHICLE_NO { get { return _VEHICLE_NO; } set { _VEHICLE_NO = value; } }
        public string TCODE { get { return _TCODE; } set { _TCODE = value; } }
        public string TRANSPORT { get { return _TRANSPORT; } set { _TRANSPORT = value; } }
        public string LR_NO { get { return _LR_NO; } set { _LR_NO = value; } }
        public string LR_DATE { get { return _LR_DATE; } set { _LR_DATE = value; } }
        public string DRIVER_NAME { get { return _DRIVER_NAME; } set { _DRIVER_NAME = value; } }
        public string DRIVER_ADD { get { return _DRIVER_ADD; } set { _DRIVER_ADD = value; } }
        public string MDLNO { get { return _MDLNO; } set { _MDLNO = value; } }
        public string MDLSTATE { get { return _MDLSTATE; } set { _MDLSTATE = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string FORM_SRNO { get { return _FORM_SRNO; } set { _FORM_SRNO = value; } }
        public string CHECKPOST_NAME { get { return _CHECKPOST_NAME; } set { _CHECKPOST_NAME = value; } }
        public string TOT_QTY { get { return _TOT_QTY; } set { _TOT_QTY = value; } }
        public string TOT_AMT { get { return _TOT_AMT; } set { _TOT_AMT = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string REF_TRAN_DATE { get { return _REF_TRAN_DATE; } set { _REF_TRAN_DATE = value; } }
        public string REF_TRAN_NO { get { return _REF_TRAN_NO; } set { _REF_TRAN_NO = value; } }
        public string ISS_FLAG { get { return _ISS_FLAG; } set { _ISS_FLAG = value; } }
        public string REC_FLAG { get { return _REC_FLAG; } set { _REC_FLAG = value; } }
        public string REC_USERID { get { return _REC_USERID; } set { _REC_USERID = value; } }
        public string REC_DATE { get { return _REC_DATE; } set { _REC_DATE = value; } }
        public string GST_APP_FLAG { get { return _GST_APP_FLAG; } set { _GST_APP_FLAG = value; } }
        public string PARTY_TYPE { get { return _PARTY_TYPE; } set { _PARTY_TYPE = value; } }
        public string INV_NO { get { return _INV_NO; } set { _INV_NO = value; } }
        public string INV_DT { get { return _INV_DT; } set { _INV_DT = value; } }
        public string EWAY_BILLNO { get { return _EWAY_BILLNO; } set { _EWAY_BILLNO = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string GST_AMT { get { return _GST_AMT; } set { _GST_AMT = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string CGST_AMT { get { return _CGST_AMT; } set { _CGST_AMT = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string SGST_AMT { get { return _SGST_AMT; } set { _SGST_AMT = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }
        public string RO_AMT { get { return _RO_AMT; } set { _RO_AMT = value; } }
        public string NET_AMT { get { return _NET_AMT; } set { _NET_AMT = value; } }
        public string FROM_BRANCH_ACODE { get { return _FROM_BRANCH_ACODE; } set { _FROM_BRANCH_ACODE = value; } }

        public static string UpdateBRANCH_REC_MASDetail(BRANCH_RECMASLogicLayer BRANCH_RECMASMaster)
        {
            return BRANCH_RECMASDataLayer.UpdateBRANCH_REC_MASDetail(BRANCH_RECMASMaster);
        }
        public static DataTable GetAllBRANCH_REC_MASDetails(int USERCODE, int COMP_CODE)
        {
            return BRANCH_RECMASDataLayer.GetAllBRANCH_REC_MASDetails(USERCODE, COMP_CODE);
        }

        public static DataSet GetAllIDWiseBRANCH_REC_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return BRANCH_RECMASDataLayer.GetAllIDWiseBRANCH_REC_MASDetials(TRAN_NO, TRAN_DATE);
        }


        public static DataTable GetAllBRANCH_RECMAS_BARCODEDetailByCompanyAndBranch(string COMP_CODE, string BRANCH_CODE, string TRAN_NO, DateTime TRAN_DATE)
        {
            return BRANCH_RECMASDataLayer.GetAllBRANCH_RECMAS_BARCODEDetailByCompanyAndBranch(COMP_CODE, BRANCH_CODE, TRAN_NO, TRAN_DATE);
        }
    }



    public class BRANCH_RECDETLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _REF_TRAN_DATE, _REF_TRAN_NO, _REF_SRNO, _SCODE, _QTY, _RATE, _AMT, _DIS_PER, _DIS_AMT, _G_AMT, _ST_PER, _ST_AMT, _ADD_ST_PER, _ADD_ST_AMT, _T_AMT, _ENDT, _STATUS, _GST_RATE, _GST_AMT, _CGST_RATE, _CGST_AMT, _SGST_RATE, _SGST_AMT, _IGST_RATE, _IGST_AMT;

        public BRANCH_RECDETLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _REF_TRAN_DATE = "  ";
            _REF_TRAN_NO = "  ";
            _REF_SRNO = "  ";
            _SCODE = "  ";
            _QTY = "  ";
            _RATE = "  ";
            _AMT = "  ";
            _DIS_PER = "  ";
            _DIS_AMT = "  ";
            _G_AMT = "  ";
            _ST_PER = "  ";
            _ST_AMT = "  ";
            _ADD_ST_PER = "  ";
            _ADD_ST_AMT = "  ";
            _T_AMT = "  ";
            _ENDT = "  ";
            _STATUS = "  ";
            _GST_RATE = "  ";
            _GST_AMT = "  ";
            _CGST_RATE = "  ";
            _CGST_AMT = "  ";
            _SGST_RATE = "  ";
            _SGST_AMT = "  ";
            _IGST_RATE = "  ";
            _IGST_AMT = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string REF_TRAN_DATE { get { return _REF_TRAN_DATE; } set { _REF_TRAN_DATE = value; } }
        public string REF_TRAN_NO { get { return _REF_TRAN_NO; } set { _REF_TRAN_NO = value; } }
        public string REF_SRNO { get { return _REF_SRNO; } set { _REF_SRNO = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string DIS_PER { get { return _DIS_PER; } set { _DIS_PER = value; } }
        public string DIS_AMT { get { return _DIS_AMT; } set { _DIS_AMT = value; } }
        public string G_AMT { get { return _G_AMT; } set { _G_AMT = value; } }
        public string ST_PER { get { return _ST_PER; } set { _ST_PER = value; } }
        public string ST_AMT { get { return _ST_AMT; } set { _ST_AMT = value; } }
        public string ADD_ST_PER { get { return _ADD_ST_PER; } set { _ADD_ST_PER = value; } }
        public string ADD_ST_AMT { get { return _ADD_ST_AMT; } set { _ADD_ST_AMT = value; } }
        public string T_AMT { get { return _T_AMT; } set { _T_AMT = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string GST_AMT { get { return _GST_AMT; } set { _GST_AMT = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string CGST_AMT { get { return _CGST_AMT; } set { _CGST_AMT = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string SGST_AMT { get { return _SGST_AMT; } set { _SGST_AMT = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }

    }

    public class BRANCH_RECMAS_BARCODELogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _BAR_TRAN_DATE, _BAR_TRAN_NO, _BAR_SRNO, _REF_TRAN_DATE, _REF_TRAN_NO, _REF_SRNO, _QTY, _RATE, _AMT, _ENDT;

        public BRANCH_RECMAS_BARCODELogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _BAR_TRAN_DATE = "  ";
            _BAR_TRAN_NO = "  ";
            _BAR_SRNO = "  ";
            _REF_TRAN_DATE = "  ";
            _REF_TRAN_NO = "  ";
            _REF_SRNO = "  ";
            _QTY = "  ";
            _RATE = "  ";
            _AMT = "  ";
            _ENDT = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string BAR_TRAN_DATE { get { return _BAR_TRAN_DATE; } set { _BAR_TRAN_DATE = value; } }
        public string BAR_TRAN_NO { get { return _BAR_TRAN_NO; } set { _BAR_TRAN_NO = value; } }
        public string BAR_SRNO { get { return _BAR_SRNO; } set { _BAR_SRNO = value; } }
        public string REF_TRAN_DATE { get { return _REF_TRAN_DATE; } set { _REF_TRAN_DATE = value; } }
        public string REF_TRAN_NO { get { return _REF_TRAN_NO; } set { _REF_TRAN_NO = value; } }
        public string REF_SRNO { get { return _REF_SRNO; } set { _REF_SRNO = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
    }



    public class BRANCH_TRANMASLogicLayer

    {

        string _COMP_CODE, _BRANCH_CODE, _TRAN_DATE, _TRAN_NO, _TRNDT, _SRNO, _TO_BRANCH_CODE, _VISIT_BCODE1, _VISIT_BCODE2, _VISIT_BCODE3, _VISIT_BCODE4, _VISIT_BCODE5, _VISITSTART_TIME, _VISITCLOSE_TIME, _JOBSTART_TIME, _JOBCLOSE_TIME, _TOT_CHARGES_AMT, _BCODE, _REC_BCODE, _REC_FLAG, _REC_DATE, _REC_USERID, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_DATE, _UPD_TERMINAL;

        public BRANCH_TRANMASLogicLayer()
        {
            _COMP_CODE = "  ";
            _BRANCH_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _TRNDT = "  ";
            _SRNO = "  ";
            _TO_BRANCH_CODE = "  ";
            _VISIT_BCODE1 = "  ";
            _VISIT_BCODE2 = "  ";
            _VISIT_BCODE3 = "  ";
            _VISIT_BCODE4 = "  ";
            _VISIT_BCODE5 = "  ";
            _VISITSTART_TIME = "  ";
            _VISITCLOSE_TIME = "  ";
            _JOBSTART_TIME = "  ";
            _JOBCLOSE_TIME = "  ";
            _TOT_CHARGES_AMT = "  ";
            _BCODE = "  ";
            _REC_BCODE = "  ";
            _REC_FLAG = "  ";
            _REC_DATE = "  ";
            _REC_USERID = "  ";
            _INS_USERID = "  ";
            _INS_TERMINAL = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _UPD_TERMINAL = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string TRNDT { get { return _TRNDT; } set { _TRNDT = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string TO_BRANCH_CODE { get { return _TO_BRANCH_CODE; } set { _TO_BRANCH_CODE = value; } }
        public string VISIT_BCODE1 { get { return _VISIT_BCODE1; } set { _VISIT_BCODE1 = value; } }
        public string VISIT_BCODE2 { get { return _VISIT_BCODE2; } set { _VISIT_BCODE2 = value; } }
        public string VISIT_BCODE3 { get { return _VISIT_BCODE3; } set { _VISIT_BCODE3 = value; } }
        public string VISIT_BCODE4 { get { return _VISIT_BCODE4; } set { _VISIT_BCODE4 = value; } }
        public string VISIT_BCODE5 { get { return _VISIT_BCODE5; } set { _VISIT_BCODE5 = value; } }
        public string VISITSTART_TIME { get { return _VISITSTART_TIME; } set { _VISITSTART_TIME = value; } }
        public string VISITCLOSE_TIME { get { return _VISITCLOSE_TIME; } set { _VISITCLOSE_TIME = value; } }
        public string JOBSTART_TIME { get { return _JOBSTART_TIME; } set { _JOBSTART_TIME = value; } }
        public string JOBCLOSE_TIME { get { return _JOBCLOSE_TIME; } set { _JOBCLOSE_TIME = value; } }
        public string TOT_CHARGES_AMT { get { return _TOT_CHARGES_AMT; } set { _TOT_CHARGES_AMT = value; } }
        public string BCODE { get { return _BCODE; } set { _BCODE = value; } }
        public string REC_BCODE { get { return _REC_BCODE; } set { _REC_BCODE = value; } }
        public string REC_FLAG { get { return _REC_FLAG; } set { _REC_FLAG = value; } }
        public string REC_DATE { get { return _REC_DATE; } set { _REC_DATE = value; } }
        public string REC_USERID { get { return _REC_USERID; } set { _REC_USERID = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }

        public static string InsertSERVICE_ISSUE_TOBRANCH_MASDetail(BRANCH_TRANMASLogicLayer BRANCH_TRANMASMaster, string BRANCH_TRAN_PARTYDetails, string BRANCH_TRANDETDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1)
        {
            return BRANCH_TRANMASDataLayer.InsertSERVICE_ISSUE_TOBRANCH_MASDetail(BRANCH_TRANMASMaster, BRANCH_TRAN_PARTYDetails, BRANCH_TRANDETDetails, COMP_CODE, BRANCH_CODE, YRDT1);
        }

        public static string UpdateSERVICE_ISSUE_BRANCH_MASDetail(BRANCH_TRANMASLogicLayer BRANCH_TRANMASMaster, string BRANCH_TRAN_PARTYDetails, string BRANCH_TRANDETDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1)
        {
            return BRANCH_TRANMASDataLayer.UpdateSERVICE_ISSUE_BRANCH_MASDetail(BRANCH_TRANMASMaster, BRANCH_TRAN_PARTYDetails, BRANCH_TRANDETDetails, COMP_CODE, BRANCH_CODE, YRDT1);
        }

        public static string DeleteSERVICE_ISSUE_TO_BRANCHDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {
            return BRANCH_TRANMASDataLayer.DeleteSERVICE_ISSUE_TO_BRANCHDetailsByID(TRAN_NO, TRAN_DATE);
        }

        public static string GetSerialNumberForServiceIssueToBranch(string COMP_CODE, string BRANCH_CODE, string YRDT1, string ServiceDate)
        {
            return BRANCH_TRANMASDataLayer.GetSerialNumberForServiceIssueToBranch(COMP_CODE, BRANCH_CODE, YRDT1, ServiceDate);
        }

        public static DataSet GetAllIDWiseSERVICE_ISSUE_BRANCH_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return BRANCH_TRANMASDataLayer.GetAllIDWiseSERVICE_ISSUE_BRANCH_MASDetials(TRAN_NO, TRAN_DATE);
        }


        public static DataTable GetAllSERVICE_ISSUE_BRANCH_MASDetails(int USERCODE, int COMP_CODE, int BRANCH_CODE, string Service_Type)
        {
            return BRANCH_TRANMASDataLayer.GetAllSERVICE_ISSUE_BRANCH_MASDetails(USERCODE, COMP_CODE, BRANCH_CODE, Service_Type);
        }

    }


    public class BRANCH_TRAN_PARTYLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _ACODE, _CONTACT_PERSON, _CONTACT_PHONE, _COMPANY_REMARK, _JOBSTART_TIME, _JOBCLOSE_TIME, _JOB_COMPFLAG, _OWN_REMARK, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_DATE, _UPD_TERMINAL, _TOT_TIME;

        public BRANCH_TRAN_PARTYLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _ACODE = "  ";
            _CONTACT_PERSON = "  ";
            _CONTACT_PHONE = "  ";
            _COMPANY_REMARK = "  ";
            _JOBSTART_TIME = "  ";
            _JOBCLOSE_TIME = "  ";
            _JOB_COMPFLAG = "  ";
            _OWN_REMARK = "  ";
            _INS_USERID = "  ";
            _INS_TERMINAL = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _UPD_TERMINAL = "  ";
            _TOT_TIME = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string CONTACT_PERSON { get { return _CONTACT_PERSON; } set { _CONTACT_PERSON = value; } }
        public string CONTACT_PHONE { get { return _CONTACT_PHONE; } set { _CONTACT_PHONE = value; } }
        public string COMPANY_REMARK { get { return _COMPANY_REMARK; } set { _COMPANY_REMARK = value; } }
        public string JOBSTART_TIME { get { return _JOBSTART_TIME; } set { _JOBSTART_TIME = value; } }
        public string JOBCLOSE_TIME { get { return _JOBCLOSE_TIME; } set { _JOBCLOSE_TIME = value; } }
        public string JOB_COMPFLAG { get { return _JOB_COMPFLAG; } set { _JOB_COMPFLAG = value; } }
        public string OWN_REMARK { get { return _OWN_REMARK; } set { _OWN_REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string TOT_TIME { get { return _TOT_TIME; } set { _TOT_TIME = value; } }



    }


    public class BRANCH_TRANDETLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _CCODE, _CHARGES_DESC, _AMT, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public BRANCH_TRANDETLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _CCODE = "  ";
            _CHARGES_DESC = "  ";
            _AMT = "  ";
            _INS_USERID = "  ";
            _INS_TERMINAL = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_TERMINAL = "  ";
            _UPD_DATE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string CCODE { get { return _CCODE; } set { _CCODE = value; } }
        public string CHARGES_DESC { get { return _CHARGES_DESC; } set { _CHARGES_DESC = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }




    }



    public class INDENT_MASLogicLayer

    {

        string _COMP_CODE, _BRANCH_CODE, _TRAN_DATE, _TRAN_NO, _INDDT, _INDNO, _BCODE, _REMARK, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE, _REC_FLAG, _REC_USERID, _REC_DATE, _ENDT, _STATUS, _CAT_CODE, _INDENT_TYPE, _TO_BRANCH_CODE, _CHK_FLAG, _CHK_USERID, _CHK_DATE, _CLOSE_FLAG, _CLOSE_USERID, _CLOSE_DATE;

        public INDENT_MASLogicLayer()
        {
            _COMP_CODE = "  ";
            _BRANCH_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _INDDT = "  ";
            _INDNO = "  ";
            _BCODE = "  ";
            _REMARK = "  ";
            _INS_USERID = "  ";
            _INS_TERMINAL = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_TERMINAL = "  ";
            _UPD_DATE = "  ";
            _REC_FLAG = "  ";
            _REC_USERID = "  ";
            _REC_DATE = "  ";
            _ENDT = "  ";
            _STATUS = "  ";
            _CAT_CODE = "  ";
            _INDENT_TYPE = "  ";
            _TO_BRANCH_CODE = "  ";
            _CHK_FLAG = "  ";
            _CHK_USERID = "  ";
            _CHK_DATE = "  ";
            _CLOSE_FLAG = "  ";
            _CLOSE_USERID = "  ";
            _CLOSE_DATE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string INDDT { get { return _INDDT; } set { _INDDT = value; } }
        public string INDNO { get { return _INDNO; } set { _INDNO = value; } }
        public string BCODE { get { return _BCODE; } set { _BCODE = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string REC_FLAG { get { return _REC_FLAG; } set { _REC_FLAG = value; } }
        public string REC_USERID { get { return _REC_USERID; } set { _REC_USERID = value; } }
        public string REC_DATE { get { return _REC_DATE; } set { _REC_DATE = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string CAT_CODE { get { return _CAT_CODE; } set { _CAT_CODE = value; } }
        public string INDENT_TYPE { get { return _INDENT_TYPE; } set { _INDENT_TYPE = value; } }
        public string TO_BRANCH_CODE { get { return _TO_BRANCH_CODE; } set { _TO_BRANCH_CODE = value; } }
        public string CHK_FLAG { get { return _CHK_FLAG; } set { _CHK_FLAG = value; } }
        public string CHK_USERID { get { return _CHK_USERID; } set { _CHK_USERID = value; } }
        public string CHK_DATE { get { return _CHK_DATE; } set { _CHK_DATE = value; } }
        public string CLOSE_FLAG { get { return _CLOSE_FLAG; } set { _CLOSE_FLAG = value; } }
        public string CLOSE_USERID { get { return _CLOSE_USERID; } set { _CLOSE_USERID = value; } }
        public string CLOSE_DATE { get { return _CLOSE_DATE; } set { _CLOSE_DATE = value; } }

        public static string InsertSTOCK_INDENT_ISSUE_TOBRANCH_MASDetail(INDENT_MASLogicLayer INDENT_MASMaster, string INDENT_DETDetails, string INDENT_CATDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1)
        {
            return INDENT_MASDataLayer.InsertSTOCK_INDENT_ISSUE_TOBRANCH_MASDetail(INDENT_MASMaster, INDENT_DETDetails, INDENT_CATDetails, COMP_CODE, BRANCH_CODE, YRDT1);
        }

        public static string UpdateSTOCK_INDENT_ISSUE_TOBRANCH_MASDetail(INDENT_MASLogicLayer INDENT_MASMaster, string INDENT_DETDetails, string INDENT_CATDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1)
        {
            return INDENT_MASDataLayer.UpdateSTOCK_INDENT_ISSUE_TOBRANCH_MASDetail(INDENT_MASMaster, INDENT_DETDetails, INDENT_CATDetails, COMP_CODE, BRANCH_CODE, YRDT1);
        }

        public static string GetIndentNumberForStockIndentIssueToBranch(string COMP_CODE, string BRANCH_CODE, string YRDT1, string IndentDate)
        {
            return INDENT_MASDataLayer.GetIndentNumberForStockIndentIssueToBranch(COMP_CODE, BRANCH_CODE, YRDT1, IndentDate);
        }


        public static DataTable GetAllSTOCK_INDENT_ISSUE_BRANCH_MASDetails(int USERCODE, int COMP_CODE, int BRANCH_CODE, string Indent_BranchType)
        {
            return INDENT_MASDataLayer.GetAllSTOCK_INDENT_ISSUE_BRANCH_MASDetails(USERCODE, COMP_CODE, BRANCH_CODE, Indent_BranchType);
        }

        public static DataSet GetAllIDWiseSTOCK_INDENT_ISSUE_BRANCH_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return INDENT_MASDataLayer.GetAllIDWiseSTOCK_INDENT_ISSUE_BRANCH_MASDetials(TRAN_NO, TRAN_DATE);
        }


    }



    public class INDENT_DETLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _SCODE, _MIN_QTY, _MAX_QTY, _STK_QTY, _ORD_QTY, _ACODE, _LAST_PURDATETIME, _LAST_PURRATE, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE, _ENDT, _STATUS, _CAT_CODE, _BRSTK_QTY, _REQORD_QTY, _REMARK;

        public INDENT_DETLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _SCODE = "  ";
            _MIN_QTY = "  ";
            _MAX_QTY = "  ";
            _STK_QTY = "  ";
            _ORD_QTY = "  ";
            _ACODE = "  ";
            _LAST_PURDATETIME = "  ";
            _LAST_PURRATE = "  ";
            _INS_USERID = "  ";
            _INS_TERMINAL = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_TERMINAL = "  ";
            _UPD_DATE = "  ";
            _ENDT = "  ";
            _STATUS = "  ";
            _CAT_CODE = "  ";
            _BRSTK_QTY = "  ";
            _REQORD_QTY = "  ";
            _REMARK = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string MIN_QTY { get { return _MIN_QTY; } set { _MIN_QTY = value; } }
        public string MAX_QTY { get { return _MAX_QTY; } set { _MAX_QTY = value; } }
        public string STK_QTY { get { return _STK_QTY; } set { _STK_QTY = value; } }
        public string ORD_QTY { get { return _ORD_QTY; } set { _ORD_QTY = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string LAST_PURDATETIME { get { return _LAST_PURDATETIME; } set { _LAST_PURDATETIME = value; } }
        public string LAST_PURRATE { get { return _LAST_PURRATE; } set { _LAST_PURRATE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string CAT_CODE { get { return _CAT_CODE; } set { _CAT_CODE = value; } }
        public string BRSTK_QTY { get { return _BRSTK_QTY; } set { _BRSTK_QTY = value; } }
        public string REQORD_QTY { get { return _REQORD_QTY; } set { _REQORD_QTY = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }


    }



    public class INDENT_CATLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _CAT_CODE, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public INDENT_CATLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _CAT_CODE = "  ";
            _INS_USERID = "  ";
            _INS_TERMINAL = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_TERMINAL = "  ";
            _UPD_DATE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string CAT_CODE { get { return _CAT_CODE; } set { _CAT_CODE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }



    }



    public class REC_ISS_MLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _TRAN_TYPE, _TRN_TYPE, _TAX_TYPE, _CRACODE, _DRACODE, _SALES_TYPE, _PARTY_TYPE, _PARTY_NAME, _PARTY_ADD, _BCODE, _BAMT, _INV_NO, _INV_NUMBER, _INV_DT, _REC_DT, _DUE_DAYS, _DUE_DATE, _CHA_NO, _CHA_DT, _PO_NO, _PO_DT, _VEHICLE_NO, _GROSS_AMT, _RO_AMT, _NET_AMT, _PAID_AMT, _STATUS, _ENDT, _DIS_PER, _DIS_AMT, _CHARGES_AMT, _PAID_TYPE, _PARTY_TIN, _TCODE, _LR_NO, _LR_DATE, _PREPARATION_DATE, _PREPARATION_TIME_HH, _PREPARATION_TIME_MM, _REMOVAL_DATE, _REMOVAL_TIME_HH, _REMOVAL_TIME_MM, _CFORM_FLAG, _CFORM_NO, _EX_DUTY_PER, _EX_DUTY_AMT, _EX_CESS_PER, _EX_CESS_AMT, _EX_SHCESS_PER, _EX_SHCESS_AMT, _TOT_GROSS_AMT, _ST_PER, _ST_AMT, _ADD_ST_PER, _ADD_ST_AMT, _TOT_AMT, _REMARK, _BUYERACODE, _TRANSPORT, _EX_RATE_OF_DUTY, _FORM_SRNO, _CHECKPOST_NAME, _REF_TRAN_DATE, _REF_TRAN_NO, _INVBOOK_NO, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE, _INVTYPE, _RW_CODE, _FIGURE_FLAG, _TAX_CALTYPE, _TOT_QTY, _RW_TYPE, _EX_CYR_PER, _EX_GROSS_AMT_CYR, _EX_DUTY_AMT_CYR, _EX_CESS_AMT_CYR, _EX_SHCESS_AMT_CYR, _EX_NYR_PER, _EX_GROSS_AMT_NYR, _EX_DUTY_AMT_NYR, _EX_CESS_AMT_NYR, _EX_SHCESS_AMT_NYR, _CHARGES_FLAG, _BRANCH_CODE, _CST_TYPE, _LESS_AMT, _TDS_AMT, _DRIVER_NAME, _DRIVER_ADD, _MDLNO, _MDLSTATE, _CONF_FLAG, _CONF_DATE, _CONF_USERID, _CFORM_ISSFLAG, _CFORM_TRAN_DATE, _CFORM_TRAN_NO, _OA_FLAG, _OA_AMT, _EXCISE_TYPE, _EXCISE_PRINTFLAG, _CHARGES_VAT_AMT, _GST_RATE, _GST_AMT, _CGST_RATE, _CGST_AMT, _SGST_RATE, _SGST_AMT, _IGST_RATE, _IGST_AMT, _CUSTOM_DUTY_AMT, _CUSTOM_GST_BAMT, _CUSTOM_GST_RATE, _CUSTOM_GST_AMT, _CUSTOM_TOT_AMT, _INV_TRAN_DATE, _INV_TRAN_NO, _INV_REASON, _EWAY_BILLNO;

        public REC_ISS_MLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _TRAN_TYPE = "  ";
            _TRN_TYPE = "  ";
            _TAX_TYPE = "  ";
            _CRACODE = "  ";
            _DRACODE = "  ";
            _SALES_TYPE = "  ";
            _PARTY_TYPE = "  ";
            _PARTY_NAME = "  ";
            _PARTY_ADD = "  ";
            _BCODE = "  ";
            _BAMT = "  ";
            _INV_NO = "  ";
            _INV_NUMBER = "  ";
            _INV_DT = "  ";
            _REC_DT = "  ";
            _DUE_DAYS = "  ";
            _DUE_DATE = "  ";
            _CHA_NO = "  ";
            _CHA_DT = "  ";
            _PO_NO = "  ";
            _PO_DT = "  ";
            _VEHICLE_NO = "  ";
            _GROSS_AMT = "  ";
            _RO_AMT = "  ";
            _NET_AMT = "  ";
            _PAID_AMT = "  ";
            _STATUS = "  ";
            _ENDT = "  ";
            _DIS_PER = "  ";
            _DIS_AMT = "  ";
            _CHARGES_AMT = "  ";
            _PAID_TYPE = "  ";
            _PARTY_TIN = "  ";
            _TCODE = "  ";
            _LR_NO = "  ";
            _LR_DATE = "  ";
            _PREPARATION_DATE = "  ";
            _PREPARATION_TIME_HH = "  ";
            _PREPARATION_TIME_MM = "  ";
            _REMOVAL_DATE = "  ";
            _REMOVAL_TIME_HH = "  ";
            _REMOVAL_TIME_MM = "  ";
            _CFORM_FLAG = "  ";
            _CFORM_NO = "  ";
            _EX_DUTY_PER = "  ";
            _EX_DUTY_AMT = "  ";
            _EX_CESS_PER = "  ";
            _EX_CESS_AMT = "  ";
            _EX_SHCESS_PER = "  ";
            _EX_SHCESS_AMT = "  ";
            _TOT_GROSS_AMT = "  ";
            _ST_PER = "  ";
            _ST_AMT = "  ";
            _ADD_ST_PER = "  ";
            _ADD_ST_AMT = "  ";
            _TOT_AMT = "  ";
            _REMARK = "  ";
            _BUYERACODE = "  ";
            _TRANSPORT = "  ";
            _EX_RATE_OF_DUTY = "  ";
            _FORM_SRNO = "  ";
            _CHECKPOST_NAME = "  ";
            _REF_TRAN_DATE = "  ";
            _REF_TRAN_NO = "  ";
            _INVBOOK_NO = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _INVTYPE = "  ";
            _RW_CODE = "  ";
            _FIGURE_FLAG = "  ";
            _TAX_CALTYPE = "  ";
            _TOT_QTY = "  ";
            _RW_TYPE = "  ";
            _EX_CYR_PER = "  ";
            _EX_GROSS_AMT_CYR = "  ";
            _EX_DUTY_AMT_CYR = "  ";
            _EX_CESS_AMT_CYR = "  ";
            _EX_SHCESS_AMT_CYR = "  ";
            _EX_NYR_PER = "  ";
            _EX_GROSS_AMT_NYR = "  ";
            _EX_DUTY_AMT_NYR = "  ";
            _EX_CESS_AMT_NYR = "  ";
            _EX_SHCESS_AMT_NYR = "  ";
            _CHARGES_FLAG = "  ";
            _BRANCH_CODE = "  ";
            _CST_TYPE = "  ";
            _LESS_AMT = "  ";
            _TDS_AMT = "  ";
            _DRIVER_NAME = "  ";
            _DRIVER_ADD = "  ";
            _MDLNO = "  ";
            _MDLSTATE = "  ";
            _CONF_FLAG = "  ";
            _CONF_DATE = "  ";
            _CONF_USERID = "  ";
            _CFORM_ISSFLAG = "  ";
            _CFORM_TRAN_DATE = "  ";
            _CFORM_TRAN_NO = "  ";
            _OA_FLAG = "  ";
            _OA_AMT = "  ";
            _EXCISE_TYPE = "  ";
            _EXCISE_PRINTFLAG = "  ";
            _CHARGES_VAT_AMT = "  ";
            _GST_RATE = "  ";
            _GST_AMT = "  ";
            _CGST_RATE = "  ";
            _CGST_AMT = "  ";
            _SGST_RATE = "  ";
            _SGST_AMT = "  ";
            _IGST_RATE = "  ";
            _IGST_AMT = "  ";
            _CUSTOM_DUTY_AMT = "  ";
            _CUSTOM_GST_BAMT = "  ";
            _CUSTOM_GST_RATE = "  ";
            _CUSTOM_GST_AMT = "  ";
            _CUSTOM_TOT_AMT = "  ";
            _INV_TRAN_DATE = "  ";
            _INV_TRAN_NO = "  ";
            _INV_REASON = "  ";
            _EWAY_BILLNO = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string TRAN_TYPE { get { return _TRAN_TYPE; } set { _TRAN_TYPE = value; } }
        public string TRN_TYPE { get { return _TRN_TYPE; } set { _TRN_TYPE = value; } }
        public string TAX_TYPE { get { return _TAX_TYPE; } set { _TAX_TYPE = value; } }
        public string CRACODE { get { return _CRACODE; } set { _CRACODE = value; } }
        public string DRACODE { get { return _DRACODE; } set { _DRACODE = value; } }
        public string SALES_TYPE { get { return _SALES_TYPE; } set { _SALES_TYPE = value; } }
        public string PARTY_TYPE { get { return _PARTY_TYPE; } set { _PARTY_TYPE = value; } }
        public string PARTY_NAME { get { return _PARTY_NAME; } set { _PARTY_NAME = value; } }
        public string PARTY_ADD { get { return _PARTY_ADD; } set { _PARTY_ADD = value; } }
        public string BCODE { get { return _BCODE; } set { _BCODE = value; } }
        public string BAMT { get { return _BAMT; } set { _BAMT = value; } }
        public string INV_NO { get { return _INV_NO; } set { _INV_NO = value; } }
        public string INV_NUMBER { get { return _INV_NUMBER; } set { _INV_NUMBER = value; } }
        public string INV_DT { get { return _INV_DT; } set { _INV_DT = value; } }
        public string REC_DT { get { return _REC_DT; } set { _REC_DT = value; } }
        public string DUE_DAYS { get { return _DUE_DAYS; } set { _DUE_DAYS = value; } }
        public string DUE_DATE { get { return _DUE_DATE; } set { _DUE_DATE = value; } }
        public string CHA_NO { get { return _CHA_NO; } set { _CHA_NO = value; } }
        public string CHA_DT { get { return _CHA_DT; } set { _CHA_DT = value; } }
        public string PO_NO { get { return _PO_NO; } set { _PO_NO = value; } }
        public string PO_DT { get { return _PO_DT; } set { _PO_DT = value; } }
        public string VEHICLE_NO { get { return _VEHICLE_NO; } set { _VEHICLE_NO = value; } }
        public string GROSS_AMT { get { return _GROSS_AMT; } set { _GROSS_AMT = value; } }
        public string RO_AMT { get { return _RO_AMT; } set { _RO_AMT = value; } }
        public string NET_AMT { get { return _NET_AMT; } set { _NET_AMT = value; } }
        public string PAID_AMT { get { return _PAID_AMT; } set { _PAID_AMT = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string DIS_PER { get { return _DIS_PER; } set { _DIS_PER = value; } }
        public string DIS_AMT { get { return _DIS_AMT; } set { _DIS_AMT = value; } }
        public string CHARGES_AMT { get { return _CHARGES_AMT; } set { _CHARGES_AMT = value; } }
        public string PAID_TYPE { get { return _PAID_TYPE; } set { _PAID_TYPE = value; } }
        public string PARTY_TIN { get { return _PARTY_TIN; } set { _PARTY_TIN = value; } }
        public string TCODE { get { return _TCODE; } set { _TCODE = value; } }
        public string LR_NO { get { return _LR_NO; } set { _LR_NO = value; } }
        public string LR_DATE { get { return _LR_DATE; } set { _LR_DATE = value; } }
        public string PREPARATION_DATE { get { return _PREPARATION_DATE; } set { _PREPARATION_DATE = value; } }
        public string PREPARATION_TIME_HH { get { return _PREPARATION_TIME_HH; } set { _PREPARATION_TIME_HH = value; } }
        public string PREPARATION_TIME_MM { get { return _PREPARATION_TIME_MM; } set { _PREPARATION_TIME_MM = value; } }
        public string REMOVAL_DATE { get { return _REMOVAL_DATE; } set { _REMOVAL_DATE = value; } }
        public string REMOVAL_TIME_HH { get { return _REMOVAL_TIME_HH; } set { _REMOVAL_TIME_HH = value; } }
        public string REMOVAL_TIME_MM { get { return _REMOVAL_TIME_MM; } set { _REMOVAL_TIME_MM = value; } }
        public string CFORM_FLAG { get { return _CFORM_FLAG; } set { _CFORM_FLAG = value; } }
        public string CFORM_NO { get { return _CFORM_NO; } set { _CFORM_NO = value; } }
        public string EX_DUTY_PER { get { return _EX_DUTY_PER; } set { _EX_DUTY_PER = value; } }
        public string EX_DUTY_AMT { get { return _EX_DUTY_AMT; } set { _EX_DUTY_AMT = value; } }
        public string EX_CESS_PER { get { return _EX_CESS_PER; } set { _EX_CESS_PER = value; } }
        public string EX_CESS_AMT { get { return _EX_CESS_AMT; } set { _EX_CESS_AMT = value; } }
        public string EX_SHCESS_PER { get { return _EX_SHCESS_PER; } set { _EX_SHCESS_PER = value; } }
        public string EX_SHCESS_AMT { get { return _EX_SHCESS_AMT; } set { _EX_SHCESS_AMT = value; } }
        public string TOT_GROSS_AMT { get { return _TOT_GROSS_AMT; } set { _TOT_GROSS_AMT = value; } }
        public string ST_PER { get { return _ST_PER; } set { _ST_PER = value; } }
        public string ST_AMT { get { return _ST_AMT; } set { _ST_AMT = value; } }
        public string ADD_ST_PER { get { return _ADD_ST_PER; } set { _ADD_ST_PER = value; } }
        public string ADD_ST_AMT { get { return _ADD_ST_AMT; } set { _ADD_ST_AMT = value; } }
        public string TOT_AMT { get { return _TOT_AMT; } set { _TOT_AMT = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string BUYERACODE { get { return _BUYERACODE; } set { _BUYERACODE = value; } }
        public string TRANSPORT { get { return _TRANSPORT; } set { _TRANSPORT = value; } }
        public string EX_RATE_OF_DUTY { get { return _EX_RATE_OF_DUTY; } set { _EX_RATE_OF_DUTY = value; } }
        public string FORM_SRNO { get { return _FORM_SRNO; } set { _FORM_SRNO = value; } }
        public string CHECKPOST_NAME { get { return _CHECKPOST_NAME; } set { _CHECKPOST_NAME = value; } }
        public string REF_TRAN_DATE { get { return _REF_TRAN_DATE; } set { _REF_TRAN_DATE = value; } }
        public string REF_TRAN_NO { get { return _REF_TRAN_NO; } set { _REF_TRAN_NO = value; } }
        public string INVBOOK_NO { get { return _INVBOOK_NO; } set { _INVBOOK_NO = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string INVTYPE { get { return _INVTYPE; } set { _INVTYPE = value; } }
        public string RW_CODE { get { return _RW_CODE; } set { _RW_CODE = value; } }
        public string FIGURE_FLAG { get { return _FIGURE_FLAG; } set { _FIGURE_FLAG = value; } }
        public string TAX_CALTYPE { get { return _TAX_CALTYPE; } set { _TAX_CALTYPE = value; } }
        public string TOT_QTY { get { return _TOT_QTY; } set { _TOT_QTY = value; } }
        public string RW_TYPE { get { return _RW_TYPE; } set { _RW_TYPE = value; } }
        public string EX_CYR_PER { get { return _EX_CYR_PER; } set { _EX_CYR_PER = value; } }
        public string EX_GROSS_AMT_CYR { get { return _EX_GROSS_AMT_CYR; } set { _EX_GROSS_AMT_CYR = value; } }
        public string EX_DUTY_AMT_CYR { get { return _EX_DUTY_AMT_CYR; } set { _EX_DUTY_AMT_CYR = value; } }
        public string EX_CESS_AMT_CYR { get { return _EX_CESS_AMT_CYR; } set { _EX_CESS_AMT_CYR = value; } }
        public string EX_SHCESS_AMT_CYR { get { return _EX_SHCESS_AMT_CYR; } set { _EX_SHCESS_AMT_CYR = value; } }
        public string EX_NYR_PER { get { return _EX_NYR_PER; } set { _EX_NYR_PER = value; } }
        public string EX_GROSS_AMT_NYR { get { return _EX_GROSS_AMT_NYR; } set { _EX_GROSS_AMT_NYR = value; } }
        public string EX_DUTY_AMT_NYR { get { return _EX_DUTY_AMT_NYR; } set { _EX_DUTY_AMT_NYR = value; } }
        public string EX_CESS_AMT_NYR { get { return _EX_CESS_AMT_NYR; } set { _EX_CESS_AMT_NYR = value; } }
        public string EX_SHCESS_AMT_NYR { get { return _EX_SHCESS_AMT_NYR; } set { _EX_SHCESS_AMT_NYR = value; } }
        public string CHARGES_FLAG { get { return _CHARGES_FLAG; } set { _CHARGES_FLAG = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string CST_TYPE { get { return _CST_TYPE; } set { _CST_TYPE = value; } }
        public string LESS_AMT { get { return _LESS_AMT; } set { _LESS_AMT = value; } }
        public string TDS_AMT { get { return _TDS_AMT; } set { _TDS_AMT = value; } }
        public string DRIVER_NAME { get { return _DRIVER_NAME; } set { _DRIVER_NAME = value; } }
        public string DRIVER_ADD { get { return _DRIVER_ADD; } set { _DRIVER_ADD = value; } }
        public string MDLNO { get { return _MDLNO; } set { _MDLNO = value; } }
        public string MDLSTATE { get { return _MDLSTATE; } set { _MDLSTATE = value; } }
        public string CONF_FLAG { get { return _CONF_FLAG; } set { _CONF_FLAG = value; } }
        public string CONF_DATE { get { return _CONF_DATE; } set { _CONF_DATE = value; } }
        public string CONF_USERID { get { return _CONF_USERID; } set { _CONF_USERID = value; } }
        public string CFORM_ISSFLAG { get { return _CFORM_ISSFLAG; } set { _CFORM_ISSFLAG = value; } }
        public string CFORM_TRAN_DATE { get { return _CFORM_TRAN_DATE; } set { _CFORM_TRAN_DATE = value; } }
        public string CFORM_TRAN_NO { get { return _CFORM_TRAN_NO; } set { _CFORM_TRAN_NO = value; } }
        public string OA_FLAG { get { return _OA_FLAG; } set { _OA_FLAG = value; } }
        public string OA_AMT { get { return _OA_AMT; } set { _OA_AMT = value; } }
        public string EXCISE_TYPE { get { return _EXCISE_TYPE; } set { _EXCISE_TYPE = value; } }
        public string EXCISE_PRINTFLAG { get { return _EXCISE_PRINTFLAG; } set { _EXCISE_PRINTFLAG = value; } }
        public string CHARGES_VAT_AMT { get { return _CHARGES_VAT_AMT; } set { _CHARGES_VAT_AMT = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string GST_AMT { get { return _GST_AMT; } set { _GST_AMT = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string CGST_AMT { get { return _CGST_AMT; } set { _CGST_AMT = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string SGST_AMT { get { return _SGST_AMT; } set { _SGST_AMT = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }
        public string CUSTOM_DUTY_AMT { get { return _CUSTOM_DUTY_AMT; } set { _CUSTOM_DUTY_AMT = value; } }
        public string CUSTOM_GST_BAMT { get { return _CUSTOM_GST_BAMT; } set { _CUSTOM_GST_BAMT = value; } }
        public string CUSTOM_GST_RATE { get { return _CUSTOM_GST_RATE; } set { _CUSTOM_GST_RATE = value; } }
        public string CUSTOM_GST_AMT { get { return _CUSTOM_GST_AMT; } set { _CUSTOM_GST_AMT = value; } }
        public string CUSTOM_TOT_AMT { get { return _CUSTOM_TOT_AMT; } set { _CUSTOM_TOT_AMT = value; } }
        public string INV_TRAN_DATE { get { return _INV_TRAN_DATE; } set { _INV_TRAN_DATE = value; } }
        public string INV_TRAN_NO { get { return _INV_TRAN_NO; } set { _INV_TRAN_NO = value; } }
        public string INV_REASON { get { return _INV_REASON; } set { _INV_REASON = value; } }
        public string EWAY_BILLNO { get { return _EWAY_BILLNO; } set { _EWAY_BILLNO = value; } }

        public static string InsertREC_ISS_MASDetail(REC_ISS_MLogicLayer REC_ISS_Master, string REC_ISS_TDetails, string REC_ISS_ChargesDetails, string REC_BarcodeDetails, string REC_DC_MASTER_Details, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string TRN_TYPE)
        {
            return REC_ISS_MDataLayer.InsertREC_ISS_MASDetail(REC_ISS_Master, REC_ISS_TDetails, REC_ISS_ChargesDetails, REC_BarcodeDetails, REC_DC_MASTER_Details, COMP_CODE, BRANCH_CODE, YRDT1, TRAN_TYPE, TRN_TYPE);
        }


        public static string UpdateREC_ISS_MASDetail(REC_ISS_MLogicLayer REC_ISS_Master, string REC_ISS_TDetails, string REC_ISS_ChargesDetails, string REC_BarcodeDetails, string REC_DC_MASTER_Details, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string TRN_TYPE)
        {
            return REC_ISS_MDataLayer.UpdateREC_ISS_MASDetail(REC_ISS_Master, REC_ISS_TDetails, REC_ISS_ChargesDetails, REC_BarcodeDetails, REC_DC_MASTER_Details, COMP_CODE, BRANCH_CODE, YRDT1, TRAN_TYPE, TRN_TYPE);
        }

        public static string DeleteSREC_ISS_M_DetailsTaxInvoiceByID(string TRAN_NO, DateTime TRAN_DATE)
        {
            return REC_ISS_MDataLayer.DeleteSREC_ISS_M_DetailsTaxInvoiceByID(TRAN_NO, TRAN_DATE);
        }

        public static string GetInvoiceNumber(string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string TRN_TYPE, string InvoiceDate)
        {
            return REC_ISS_MDataLayer.GetInvoiceNumber(COMP_CODE, BRANCH_CODE, YRDT1, TRAN_TYPE, TRN_TYPE, InvoiceDate);
        }

        public static DataTable GetAllREC_ISS_M_DetailsForTaxInvoice(int USERCODE, int COMP_CODE, string TRAN_TYPE, string TRN_TYPE)
        {
            return REC_ISS_MDataLayer.GetAllREC_ISS_M_DetailsForTaxInvoice(USERCODE, COMP_CODE, TRAN_TYPE, TRN_TYPE);
        }

        public static DataSet GetAllIDWiseREC_ISS_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return REC_ISS_MDataLayer.GetAllIDWiseREC_ISS_MASDetials(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetGSTRATEGroupByTaxableAmoutForReport(DateTime TRAN_DATE, string TRAN_NO)
        {
            return REC_ISS_MDataLayer.GetGSTRATEGroupByTaxableAmoutForReport(TRAN_DATE, TRAN_NO);
        }

        public static DataSet GetAllIDWiseREC_ISS_MASDetialsForJobcard(string TRAN_NO, DateTime TRAN_DATE)
        {
            return REC_ISS_MDataLayer.GetAllIDWiseREC_ISS_MASDetialsForJobcard(TRAN_NO, TRAN_DATE);
        }

        public static string DeleteREC_ISS_M_DetailByIDForJobacard(string TRAN_NO, DateTime TRAN_DATE)
        {
            return REC_ISS_MDataLayer.DeleteREC_ISS_M_DetailByIDForJobacard(TRAN_NO, TRAN_DATE);
        }

    }


    public class REC_ISS_TLogicLayer

    {

        string _TRAN_DATE, _TRAN_NO, _SR, _REF_TRAN_DATE, _REF_TRAN_NO, _REF_SRNO, _SCODE, _PRODUCT_DESC, _QTY, _RATE, _AMT, _DIS_PER, _DIS_AMT, _G_AMT, _ST_PER, _ST_AMT, _ADD_ST_PER, _ADD_ST_AMT, _T_AMT, _ENDT, _ACT_RATE, _ACT_AMT, _CAL_RATE, _CAL_AMT, _PART_NO, _ADD_PART_NO, _PER_QTY_WT, _TOT_QTY_WT, _QTY_WT, _EX_DUTY_AMT, _EX_CESS_AMT, _EX_SHCESS_AMT, _COMP_CODE, _DC_TRAN_DATE, _DC_TRAN_NO, _DC_SRNO, _ENTRY_TYPE, _ADD_DIS_PER, _ADD_DIS_AMT, _GST_RATE, _GST_AMT, _CGST_RATE, _CGST_AMT, _SGST_RATE, _SGST_AMT, _IGST_RATE, _IGST_AMT, _HSN_NO, _INV_TRAN_DATE, _INV_TRAN_NO, _INV_SR;

        public REC_ISS_TLogicLayer()
        {
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SR = "  ";
            _REF_TRAN_DATE = "  ";
            _REF_TRAN_NO = "  ";
            _REF_SRNO = "  ";
            _SCODE = "  ";
            _PRODUCT_DESC = "  ";
            _QTY = "  ";
            _RATE = "  ";
            _AMT = "  ";
            _DIS_PER = "  ";
            _DIS_AMT = "  ";
            _G_AMT = "  ";
            _ST_PER = "  ";
            _ST_AMT = "  ";
            _ADD_ST_PER = "  ";
            _ADD_ST_AMT = "  ";
            _T_AMT = "  ";
            _ENDT = "  ";
            _ACT_RATE = "  ";
            _ACT_AMT = "  ";
            _CAL_RATE = "  ";
            _CAL_AMT = "  ";
            _PART_NO = "  ";
            _ADD_PART_NO = "  ";
            _PER_QTY_WT = "  ";
            _TOT_QTY_WT = "  ";
            _QTY_WT = "  ";
            _EX_DUTY_AMT = "  ";
            _EX_CESS_AMT = "  ";
            _EX_SHCESS_AMT = "  ";
            _COMP_CODE = "  ";
            _DC_TRAN_DATE = "  ";
            _DC_TRAN_NO = "  ";
            _DC_SRNO = "  ";
            _ENTRY_TYPE = "  ";
            _ADD_DIS_PER = "  ";
            _ADD_DIS_AMT = "  ";
            _GST_RATE = "  ";
            _GST_AMT = "  ";
            _CGST_RATE = "  ";
            _CGST_AMT = "  ";
            _SGST_RATE = "  ";
            _SGST_AMT = "  ";
            _IGST_RATE = "  ";
            _IGST_AMT = "  ";
            _HSN_NO = "  ";
            _INV_TRAN_DATE = "  ";
            _INV_TRAN_NO = "  ";
            _INV_SR = "  ";


        }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SR { get { return _SR; } set { _SR = value; } }
        public string REF_TRAN_DATE { get { return _REF_TRAN_DATE; } set { _REF_TRAN_DATE = value; } }
        public string REF_TRAN_NO { get { return _REF_TRAN_NO; } set { _REF_TRAN_NO = value; } }
        public string REF_SRNO { get { return _REF_SRNO; } set { _REF_SRNO = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string PRODUCT_DESC { get { return _PRODUCT_DESC; } set { _PRODUCT_DESC = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string DIS_PER { get { return _DIS_PER; } set { _DIS_PER = value; } }
        public string DIS_AMT { get { return _DIS_AMT; } set { _DIS_AMT = value; } }
        public string G_AMT { get { return _G_AMT; } set { _G_AMT = value; } }
        public string ST_PER { get { return _ST_PER; } set { _ST_PER = value; } }
        public string ST_AMT { get { return _ST_AMT; } set { _ST_AMT = value; } }
        public string ADD_ST_PER { get { return _ADD_ST_PER; } set { _ADD_ST_PER = value; } }
        public string ADD_ST_AMT { get { return _ADD_ST_AMT; } set { _ADD_ST_AMT = value; } }
        public string T_AMT { get { return _T_AMT; } set { _T_AMT = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string ACT_RATE { get { return _ACT_RATE; } set { _ACT_RATE = value; } }
        public string ACT_AMT { get { return _ACT_AMT; } set { _ACT_AMT = value; } }
        public string CAL_RATE { get { return _CAL_RATE; } set { _CAL_RATE = value; } }
        public string CAL_AMT { get { return _CAL_AMT; } set { _CAL_AMT = value; } }
        public string PART_NO { get { return _PART_NO; } set { _PART_NO = value; } }
        public string ADD_PART_NO { get { return _ADD_PART_NO; } set { _ADD_PART_NO = value; } }
        public string PER_QTY_WT { get { return _PER_QTY_WT; } set { _PER_QTY_WT = value; } }
        public string TOT_QTY_WT { get { return _TOT_QTY_WT; } set { _TOT_QTY_WT = value; } }
        public string QTY_WT { get { return _QTY_WT; } set { _QTY_WT = value; } }
        public string EX_DUTY_AMT { get { return _EX_DUTY_AMT; } set { _EX_DUTY_AMT = value; } }
        public string EX_CESS_AMT { get { return _EX_CESS_AMT; } set { _EX_CESS_AMT = value; } }
        public string EX_SHCESS_AMT { get { return _EX_SHCESS_AMT; } set { _EX_SHCESS_AMT = value; } }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string DC_TRAN_DATE { get { return _DC_TRAN_DATE; } set { _DC_TRAN_DATE = value; } }
        public string DC_TRAN_NO { get { return _DC_TRAN_NO; } set { _DC_TRAN_NO = value; } }
        public string DC_SRNO { get { return _DC_SRNO; } set { _DC_SRNO = value; } }
        public string ENTRY_TYPE { get { return _ENTRY_TYPE; } set { _ENTRY_TYPE = value; } }
        public string ADD_DIS_PER { get { return _ADD_DIS_PER; } set { _ADD_DIS_PER = value; } }
        public string ADD_DIS_AMT { get { return _ADD_DIS_AMT; } set { _ADD_DIS_AMT = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string GST_AMT { get { return _GST_AMT; } set { _GST_AMT = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string CGST_AMT { get { return _CGST_AMT; } set { _CGST_AMT = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string SGST_AMT { get { return _SGST_AMT; } set { _SGST_AMT = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }
        public string HSN_NO { get { return _HSN_NO; } set { _HSN_NO = value; } }
        public string INV_TRAN_DATE { get { return _INV_TRAN_DATE; } set { _INV_TRAN_DATE = value; } }
        public string INV_TRAN_NO { get { return _INV_TRAN_NO; } set { _INV_TRAN_NO = value; } }
        public string INV_SR { get { return _INV_SR; } set { _INV_SR = value; } }



    }



    public class REC_ISS_CLogicLayer

    {

        string _TRAN_DATE, _TRAN_NO, _SR, _CCODE, _PER, _SIGN, _AMT, _ENDT, _COMP_CODE, _LAB_DESC, _QTY, _ST_PER, _ST_AMT, _ADD_ST_PER, _ADD_ST_AMT, _T_AMT, _GST_RATE, _GST_AMT, _CGST_RATE, _CGST_AMT, _SGST_RATE, _SGST_AMT, _IGST_RATE, _IGST_AMT, _HSN_NO;

        public REC_ISS_CLogicLayer()
        {
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SR = "  ";
            _CCODE = "  ";
            _PER = "  ";
            _SIGN = "  ";
            _AMT = "  ";
            _ENDT = "  ";
            _COMP_CODE = "  ";
            _LAB_DESC = "  ";
            _QTY = "  ";
            _ST_PER = "  ";
            _ST_AMT = "  ";
            _ADD_ST_PER = "  ";
            _ADD_ST_AMT = "  ";
            _T_AMT = "  ";
            _GST_RATE = "  ";
            _GST_AMT = "  ";
            _CGST_RATE = "  ";
            _CGST_AMT = "  ";
            _SGST_RATE = "  ";
            _SGST_AMT = "  ";
            _IGST_RATE = "  ";
            _IGST_AMT = "  ";
            _HSN_NO = "  ";


        }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SR { get { return _SR; } set { _SR = value; } }
        public string CCODE { get { return _CCODE; } set { _CCODE = value; } }
        public string PER { get { return _PER; } set { _PER = value; } }
        public string SIGN { get { return _SIGN; } set { _SIGN = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string LAB_DESC { get { return _LAB_DESC; } set { _LAB_DESC = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string ST_PER { get { return _ST_PER; } set { _ST_PER = value; } }
        public string ST_AMT { get { return _ST_AMT; } set { _ST_AMT = value; } }
        public string ADD_ST_PER { get { return _ADD_ST_PER; } set { _ADD_ST_PER = value; } }
        public string ADD_ST_AMT { get { return _ADD_ST_AMT; } set { _ADD_ST_AMT = value; } }
        public string T_AMT { get { return _T_AMT; } set { _T_AMT = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string GST_AMT { get { return _GST_AMT; } set { _GST_AMT = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string CGST_AMT { get { return _CGST_AMT; } set { _CGST_AMT = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string SGST_AMT { get { return _SGST_AMT; } set { _SGST_AMT = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }
        public string HSN_NO { get { return _HSN_NO; } set { _HSN_NO = value; } }



    }


    public class REC_ISS_BARCODELogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _BAR_TRAN_DATE, _BAR_TRAN_NO, _BAR_SRNO, _QTY;

        public REC_ISS_BARCODELogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _BAR_TRAN_DATE = "  ";
            _BAR_TRAN_NO = "  ";
            _BAR_SRNO = "  ";
            _QTY = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string BAR_TRAN_DATE { get { return _BAR_TRAN_DATE; } set { _BAR_TRAN_DATE = value; } }
        public string BAR_TRAN_NO { get { return _BAR_TRAN_NO; } set { _BAR_TRAN_NO = value; } }
        public string BAR_SRNO { get { return _BAR_SRNO; } set { _BAR_SRNO = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }

    }

    public class AMC_RATEMASLogicLayer

    {

        string _COMP_CODE, _SRNO, _FRDT, _TODT, _REMARK, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE, _ACTIVE;

        public AMC_RATEMASLogicLayer()
        {
            _COMP_CODE = "  ";
            _SRNO = "  ";
            _FRDT = "  ";
            _TODT = "  ";
            _REMARK = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _ACTIVE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string FRDT { get { return _FRDT; } set { _FRDT = value; } }
        public string TODT { get { return _TODT; } set { _TODT = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string ACTIVE { get { return _ACTIVE; } set { _ACTIVE = value; } }

        public static string InsertAMC_RATE_MASDetail(AMC_RATEMASLogicLayer AMC_RATEMaster, string AMC_RATEDetails)
        {
            return AMC_RATEMASDataLayer.InsertAMC_RATE_MASDetail(AMC_RATEMaster, AMC_RATEDetails);
        }

        public static string UpdateAMC_RATE_MASDetail(AMC_RATEMASLogicLayer AMC_RATEMaster, string AMC_RATEDetails)
        {
            return AMC_RATEMASDataLayer.UpdateAMC_RATE_MASDetail(AMC_RATEMaster, AMC_RATEDetails);
        }

        public static string DeleteAMC_RATE_MASDetailsByID(string SRNO)
        {
            return AMC_RATEMASDataLayer.DeleteAMC_RATE_MASDetailsByID(SRNO);
        }

        public static DataSet GetAllIDWiseAMC_RATE_MASDetail(string SRNO)
        {
            return AMC_RATEMASDataLayer.GetAllIDWiseAMC_RATE_MASDetail(SRNO);
        }

        public static DataTable GetAllAMC_RATE_MASDetail(int USERCODE, int COMP_CODE)
        {
            return AMC_RATEMASDataLayer.GetAllAMC_RATE_MASDetail(USERCODE, COMP_CODE);
        }

    }


    public class AMC_RATEDETLogicLayer

    {

        string _COMP_CODE, _SRNO, _SUB_SRNO, _BRAND_CODE, _MODEL_CODE, _AMC_RATE, _MAX_DIS_PER, _MAX_DIS_RATE, _MIN_DIS_PER, _MIN_DIS_RATE, _PER_SERVICE_RATE, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE, _REMARK;

        public AMC_RATEDETLogicLayer()
        {
            _COMP_CODE = "  ";
            _SRNO = "  ";
            _SUB_SRNO = "  ";
            _BRAND_CODE = "  ";
            _MODEL_CODE = "  ";
            _AMC_RATE = "  ";
            _MAX_DIS_PER = "  ";
            _MAX_DIS_RATE = "  ";
            _MIN_DIS_PER = "  ";
            _MIN_DIS_RATE = "  ";
            _PER_SERVICE_RATE = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _REMARK = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string SUB_SRNO { get { return _SUB_SRNO; } set { _SUB_SRNO = value; } }
        public string BRAND_CODE { get { return _BRAND_CODE; } set { _BRAND_CODE = value; } }
        public string MODEL_CODE { get { return _MODEL_CODE; } set { _MODEL_CODE = value; } }
        public string AMC_RATE { get { return _AMC_RATE; } set { _AMC_RATE = value; } }
        public string MAX_DIS_PER { get { return _MAX_DIS_PER; } set { _MAX_DIS_PER = value; } }
        public string MAX_DIS_RATE { get { return _MAX_DIS_RATE; } set { _MAX_DIS_RATE = value; } }
        public string MIN_DIS_PER { get { return _MIN_DIS_PER; } set { _MIN_DIS_PER = value; } }
        public string MIN_DIS_RATE { get { return _MIN_DIS_RATE; } set { _MIN_DIS_RATE = value; } }
        public string PER_SERVICE_RATE { get { return _PER_SERVICE_RATE; } set { _PER_SERVICE_RATE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }




    }

    public class WORK_LISTMASLogicLayer
    {
        string _COMP_CODE, _WORK_CODE, _WORK_NAME, _JOB_CATCODE, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE;

        public WORK_LISTMASLogicLayer()
        {
            _COMP_CODE = "";
            _WORK_NAME = "";
            _WORK_CODE = "";
            _JOB_CATCODE = "";
            _INS_USERID = "";
            _INS_DATE = "";
            _UPD_USERID = "";
            _UPD_DATE = "";
        }

        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string WORK_CODE { get { return _WORK_CODE; } set { _WORK_CODE = value; } }
        public string WORK_NAME { get { return _WORK_NAME; } set { _WORK_NAME = value; } }
        public string JOB_CATCODE { get { return _JOB_CATCODE; } set { _JOB_CATCODE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }

        public static string InsertWORK_LISTMAS(WORK_LISTMASLogicLayer WORK_LISTMASDetails)
        {
            return WORK_LISTMASDataLayer.InsertWORK_LISTMAS(WORK_LISTMASDetails);
        }
        public static DataTable GetAllWork_List_MASDetail(int USERCODE, int COMP_CODE)
        {
            return WORK_LISTMASDataLayer.GetAllWork_List_MASDetail(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllIDWiseWorklistdetails(string workcode)
        {
            return WORK_LISTMASDataLayer.GetAllIDWiseWorklistdetails(workcode);
        }

        public static string UpdateWORK_LISTMASDetails(WORK_LISTMASLogicLayer Work_ListDetails)
        {
            return WORK_LISTMASDataLayer.UpdateWORK_LISTMASDetails(Work_ListDetails);
        }

        public static string DeleteWORKLISTByID(string WORKCODE)
        {
            return WORK_LISTMASDataLayer.DeleteWORKLISTByID(WORKCODE);
        }


        public static DataTable GetWORK_LISTMASDetailsCompanyWise(string COMP_CODE)
        {
            return WORK_LISTMASDataLayer.GetWORK_LISTMASDetailsCompanyWise(COMP_CODE);
        }



    }






    public class DAILY_WORKMASLogicLayer

    {

        string _COMP_CODE, _BRANCH_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _TRNDT, _EMP_CODE, _USERCODE, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE, _CONF_FLAG, _CONF_DATE, _CHK_FLAG, _CHK_DATE, _CHK_USERID, _BCODE;

        public DAILY_WORKMASLogicLayer()
        {
            _COMP_CODE = "  ";
            _BRANCH_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _TRNDT = "  ";
            _EMP_CODE = "  ";
            _USERCODE = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _CONF_FLAG = "  ";
            _CONF_DATE = "  ";
            _CHK_FLAG = "  ";
            _CHK_DATE = "  ";
            _CHK_USERID = "  ";
            _BCODE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string TRNDT { get { return _TRNDT; } set { _TRNDT = value; } }
        public string EMP_CODE { get { return _EMP_CODE; } set { _EMP_CODE = value; } }
        public string USERCODE { get { return _USERCODE; } set { _USERCODE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string CONF_FLAG { get { return _CONF_FLAG; } set { _CONF_FLAG = value; } }
        public string CONF_DATE { get { return _CONF_DATE; } set { _CONF_DATE = value; } }
        public string CHK_FLAG { get { return _CHK_FLAG; } set { _CHK_FLAG = value; } }
        public string CHK_DATE { get { return _CHK_DATE; } set { _CHK_DATE = value; } }
        public string CHK_USERID { get { return _CHK_USERID; } set { _CHK_USERID = value; } }
        public string BCODE { get { return _BCODE; } set { _BCODE = value; } }

        public static string InsertDAILY_WORKMASDetail(DAILY_WORKMASLogicLayer DailyWorkMaster, string DailyWorkDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1)
        {
            return DAILY_WORKMASDataLayer.InsertDAILY_WORKMASDetail(DailyWorkMaster, DailyWorkDetails, COMP_CODE, BRANCH_CODE, YRDT1);
        }

        public static string GetSrNoDAILY_WORKMASCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRNDT)
        {
            return DAILY_WORKMASDataLayer.GetSrNoDAILY_WORKMASCompanyBranchYearWise(COMP_CODE, BRANCH_CODE, YRDT1, TRNDT);
        }

        public static string DeleteDAILY_WORKMASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {
            return DAILY_WORKMASDataLayer.DeleteDAILY_WORKMASDetailsByID(TRAN_NO, TRAN_DATE);
        }

        public static string UpdateDAILY_WORKMASDetail(DAILY_WORKMASLogicLayer DailyWorkMaster, string DailyWorkDetails)
        {
            return DAILY_WORKMASDataLayer.UpdateDAILY_WORKMASDetail(DailyWorkMaster, DailyWorkDetails);
        }
        public static DataSet GetAllIDWiseDAILY_WORKMASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return DAILY_WORKMASDataLayer.GetAllIDWiseDAILY_WORKMASDetials(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetAllDAILY_WORKMASDetials(int USERCODE, int COMP_CODE)
        {
            return DAILY_WORKMASDataLayer.GetAllDAILY_WORKMASDetials(USERCODE, COMP_CODE);
        }

    }


    public class DAILY_WORKDETLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _FRTIME, _TOTIME, _VISIT_PLACE, _WORK_DESC, _REMARK, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE, _WORK_FROM, _WORK_CODE;

        public DAILY_WORKDETLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _FRTIME = "  ";
            _TOTIME = "  ";
            _VISIT_PLACE = "  ";
            _WORK_DESC = "  ";
            _REMARK = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _WORK_FROM = "  ";
            _WORK_CODE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string FRTIME { get { return _FRTIME; } set { _FRTIME = value; } }
        public string TOTIME { get { return _TOTIME; } set { _TOTIME = value; } }
        public string VISIT_PLACE { get { return _VISIT_PLACE; } set { _VISIT_PLACE = value; } }
        public string WORK_DESC { get { return _WORK_DESC; } set { _WORK_DESC = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string WORK_FROM { get { return _WORK_FROM; } set { _WORK_FROM = value; } }
        public string WORK_CODE { get { return _WORK_CODE; } set { _WORK_CODE = value; } }


    }




    public class AMC_MASLogicLayer

    {

        string _COMP_CODE, _BRANCH_CODE, _TRAN_DATE, _TRAN_NO, _AMC_NO, _AMC_DATE, _ACODE, _CONTACT_PERSON, _CONTACT_PHONE, _CONTACT_EMAIL, _AMC_FRDT, _AMC_TODT, _MAX_VISIT, _BILL_TERMS, _ASSIGN_BCODE1, _ASSIGN_BCODE2, _ASSIGN_BCODE3, _ASSIGN_BCODE4, _ASSIGN_BCODE1_P, _ASSIGN_BCODE2_P, _ASSIGN_BCODE3_P, _ASSIGN_BCODE4_P, _BCODE, _REMARK, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE, _CLOSE_FLAG, _CLOSE_DATE, _CLOSE_USERID, _CHK_FLAG, _CHK_DATE, _CHK_USERID, _AMC_TYPE, _INV_TRAN_DATE, _INV_TRAN_NO, _AMC_TRAN_DATE, _AMC_TRAN_NO, _SERVICE_START_DATE, _BILL_START_DATE;

        public AMC_MASLogicLayer()
        {
            _COMP_CODE = "  ";
            _BRANCH_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _AMC_NO = "  ";
            _AMC_DATE = "  ";
            _ACODE = "  ";
            _CONTACT_PERSON = "  ";
            _CONTACT_PHONE = "  ";
            _CONTACT_EMAIL = "  ";
            _AMC_FRDT = "  ";
            _AMC_TODT = "  ";
            _MAX_VISIT = "  ";
            _BILL_TERMS = "  ";
            _ASSIGN_BCODE1 = "  ";
            _ASSIGN_BCODE2 = "  ";
            _ASSIGN_BCODE3 = "  ";
            _ASSIGN_BCODE4 = "  ";
            _ASSIGN_BCODE1_P = "  ";
            _ASSIGN_BCODE2_P = "  ";
            _ASSIGN_BCODE3_P = "  ";
            _ASSIGN_BCODE4_P = "  ";
            _BCODE = "  ";
            _REMARK = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _CLOSE_FLAG = "  ";
            _CLOSE_DATE = "  ";
            _CLOSE_USERID = "  ";
            _CHK_FLAG = "  ";
            _CHK_DATE = "  ";
            _CHK_USERID = "  ";
            _AMC_TYPE = "  ";
            _INV_TRAN_DATE = "  ";
            _INV_TRAN_NO = "  ";
            _AMC_TRAN_DATE = "  ";
            _AMC_TRAN_NO = "  ";
            _SERVICE_START_DATE = "  ";
            _BILL_START_DATE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string AMC_NO { get { return _AMC_NO; } set { _AMC_NO = value; } }
        public string AMC_DATE { get { return _AMC_DATE; } set { _AMC_DATE = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string CONTACT_PERSON { get { return _CONTACT_PERSON; } set { _CONTACT_PERSON = value; } }
        public string CONTACT_PHONE { get { return _CONTACT_PHONE; } set { _CONTACT_PHONE = value; } }
        public string CONTACT_EMAIL { get { return _CONTACT_EMAIL; } set { _CONTACT_EMAIL = value; } }
        public string AMC_FRDT { get { return _AMC_FRDT; } set { _AMC_FRDT = value; } }
        public string AMC_TODT { get { return _AMC_TODT; } set { _AMC_TODT = value; } }
        public string MAX_VISIT { get { return _MAX_VISIT; } set { _MAX_VISIT = value; } }
        public string BILL_TERMS { get { return _BILL_TERMS; } set { _BILL_TERMS = value; } }
        public string ASSIGN_BCODE1 { get { return _ASSIGN_BCODE1; } set { _ASSIGN_BCODE1 = value; } }
        public string ASSIGN_BCODE2 { get { return _ASSIGN_BCODE2; } set { _ASSIGN_BCODE2 = value; } }
        public string ASSIGN_BCODE3 { get { return _ASSIGN_BCODE3; } set { _ASSIGN_BCODE3 = value; } }
        public string ASSIGN_BCODE4 { get { return _ASSIGN_BCODE4; } set { _ASSIGN_BCODE4 = value; } }
        public string ASSIGN_BCODE1_P { get { return _ASSIGN_BCODE1_P; } set { _ASSIGN_BCODE1_P = value; } }
        public string ASSIGN_BCODE2_P { get { return _ASSIGN_BCODE2_P; } set { _ASSIGN_BCODE2_P = value; } }
        public string ASSIGN_BCODE3_P { get { return _ASSIGN_BCODE3_P; } set { _ASSIGN_BCODE3_P = value; } }
        public string ASSIGN_BCODE4_P { get { return _ASSIGN_BCODE4_P; } set { _ASSIGN_BCODE4_P = value; } }
        public string BCODE { get { return _BCODE; } set { _BCODE = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string CLOSE_FLAG { get { return _CLOSE_FLAG; } set { _CLOSE_FLAG = value; } }
        public string CLOSE_DATE { get { return _CLOSE_DATE; } set { _CLOSE_DATE = value; } }
        public string CLOSE_USERID { get { return _CLOSE_USERID; } set { _CLOSE_USERID = value; } }
        public string CHK_FLAG { get { return _CHK_FLAG; } set { _CHK_FLAG = value; } }
        public string CHK_DATE { get { return _CHK_DATE; } set { _CHK_DATE = value; } }
        public string CHK_USERID { get { return _CHK_USERID; } set { _CHK_USERID = value; } }
        public string AMC_TYPE { get { return _AMC_TYPE; } set { _AMC_TYPE = value; } }
        public string INV_TRAN_DATE { get { return _INV_TRAN_DATE; } set { _INV_TRAN_DATE = value; } }
        public string INV_TRAN_NO { get { return _INV_TRAN_NO; } set { _INV_TRAN_NO = value; } }
        public string AMC_TRAN_DATE { get { return _AMC_TRAN_DATE; } set { _AMC_TRAN_DATE = value; } }
        public string AMC_TRAN_NO { get { return _AMC_TRAN_NO; } set { _AMC_TRAN_NO = value; } }
        public string SERVICE_START_DATE { get { return _SERVICE_START_DATE; } set { _SERVICE_START_DATE = value; } }
        public string BILL_START_DATE { get { return _BILL_START_DATE; } set { _BILL_START_DATE = value; } }

        public static string InsertAMC_MASDetail(AMC_MASLogicLayer AMCMaster, string AMCDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string AMC_TYPE)
        {
            return AMC_MASDataLayer.InsertAMC_MASDetail(AMCMaster, AMCDetails, COMP_CODE, BRANCH_CODE, YRDT1, AMC_TYPE);
        }
        public static string GetAmcNumber_AMC_MASCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string AMC_DATE, string AMC_TYPE)
        {
            return AMC_MASDataLayer.GetAmcNumber_AMC_MASCompanyBranchYearWise(COMP_CODE, BRANCH_CODE, YRDT1, AMC_DATE, AMC_TYPE);
        }

        public static DataTable GetAllAMC_MASDetials(int USERCODE, int COMP_CODE)
        {
            return AMC_MASDataLayer.GetAllAMC_MASDetials(USERCODE, COMP_CODE);
        }

        public static DataSet GetAllIDWiseAMC_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return AMC_MASDataLayer.GetAllIDWiseAMC_MASDetials(TRAN_NO, TRAN_DATE);
        }

        public static string UpdateAMC_MASDetail(AMC_MASLogicLayer AMCMaster, string AMCDetails)
        {
            return AMC_MASDataLayer.UpdateAMC_MASDetail(AMCMaster, AMCDetails);
        }
        public static string DeleteAMC_MASByID(string TRAN_NO, DateTime TRAN_DATE, string AMC_TYPE)
        {
            return AMC_MASDataLayer.DeleteAMC_MASByID(TRAN_NO, TRAN_DATE, AMC_TYPE);
        }

        public static DataTable GetAllWARRANTY_MASDetials(int USERCODE, int COMP_CODE)
        {
            return AMC_MASDataLayer.GetAllWARRANTY_MASDetials(USERCODE, COMP_CODE);
        }


        public static DataTable generate_service_bill_record(string p_type, string Comp_Code, string Tran_Date, string Tran_No, string Billing_Terms)
        {
            return AMC_MASDataLayer.generate_service_bill_record(p_type, Comp_Code, Tran_Date, Tran_No, Billing_Terms);
        }

        public static DataTable generate_service_record(string p_type, string Comp_Code, string Tran_Date, string Tran_No, string p_srno, string p_visit)
        {
            return AMC_MASDataLayer.generate_service_record(p_type, Comp_Code, Tran_Date, Tran_No, p_srno, p_visit);
        }
    }


    public class AMC_DETLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _ACODE, _PARTY_REFSRNO, _QTY, _RATE, _AMT;

        public AMC_DETLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _ACODE = "  ";
            _PARTY_REFSRNO = "  ";
            _QTY = "  ";
            _RATE = "  ";
            _AMT = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string PARTY_REFSRNO { get { return _PARTY_REFSRNO; } set { _PARTY_REFSRNO = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }

    }


    public class AMC_SERVICE_DETLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _SUB_SRNO, _FRDT, _TODT, _JOBCARD_TRAN_DATE, _JOBCARD_TRAN_NO, _JOBSTART_DATE, _JOBCARD_NO, _STATUS, _AUTO_RECORD;

        public AMC_SERVICE_DETLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _SUB_SRNO = "  ";
            _FRDT = "  ";
            _TODT = "  ";
            _JOBCARD_TRAN_DATE = "  ";
            _JOBCARD_TRAN_NO = "  ";
            _JOBSTART_DATE = "  ";
            _JOBCARD_NO = "  ";
            _STATUS = "  ";
            _AUTO_RECORD = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string SUB_SRNO { get { return _SUB_SRNO; } set { _SUB_SRNO = value; } }
        public string FRDT { get { return _FRDT; } set { _FRDT = value; } }
        public string TODT { get { return _TODT; } set { _TODT = value; } }
        public string JOBCARD_TRAN_DATE { get { return _JOBCARD_TRAN_DATE; } set { _JOBCARD_TRAN_DATE = value; } }
        public string JOBCARD_TRAN_NO { get { return _JOBCARD_TRAN_NO; } set { _JOBCARD_TRAN_NO = value; } }
        public string JOBSTART_DATE { get { return _JOBSTART_DATE; } set { _JOBSTART_DATE = value; } }
        public string JOBCARD_NO { get { return _JOBCARD_NO; } set { _JOBCARD_NO = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string AUTO_RECORD { get { return _AUTO_RECORD; } set { _AUTO_RECORD = value; } }


        public static DataTable GetAllAMC_SERVICE_DetialsForGrid(string COMP_CODE, DateTime TRAN_DATE, string TRAN_NO, string SRNO)
        {
            return AMC_SERVICE_DETDataLayer.GetAllAMC_SERVICE_DetialsForGrid(COMP_CODE, TRAN_DATE, TRAN_NO, SRNO);
        }

    }


    public class AMC_BILL_DETLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _FRDT, _TODT, _INV_TRAN_DATE, _INV_TRAN_NO, _INV_DATE, _INV_NO, _STATUS;

        public AMC_BILL_DETLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _FRDT = "  ";
            _TODT = "  ";
            _INV_TRAN_DATE = "  ";
            _INV_TRAN_NO = "  ";
            _INV_DATE = "  ";
            _INV_NO = "  ";
            _STATUS = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string FRDT { get { return _FRDT; } set { _FRDT = value; } }
        public string TODT { get { return _TODT; } set { _TODT = value; } }
        public string INV_TRAN_DATE { get { return _INV_TRAN_DATE; } set { _INV_TRAN_DATE = value; } }
        public string INV_TRAN_NO { get { return _INV_TRAN_NO; } set { _INV_TRAN_NO = value; } }
        public string INV_DATE { get { return _INV_DATE; } set { _INV_DATE = value; } }
        public string INV_NO { get { return _INV_NO; } set { _INV_NO = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }



    }


    public class job_cancelmasLogicLayer

    {


        string _comp_code, _cancel_code, _cancel_name, _ins_userid, _ins_date, _upd_userid, _upd_date;

        public job_cancelmasLogicLayer()
        {
            _comp_code = "  ";
            _cancel_code = "  ";
            _cancel_name = "  ";
            _ins_userid = "  ";
            _ins_date = "  ";
            _upd_userid = "  ";
            _upd_date = "  ";


        }
        public string comp_code { get { return _comp_code; } set { _comp_code = value; } }
        public string cancel_code { get { return _cancel_code; } set { _cancel_code = value; } }
        public string cancel_name { get { return _cancel_name; } set { _cancel_name = value; } }
        public string ins_userid { get { return _ins_userid; } set { _ins_userid = value; } }
        public string ins_date { get { return _ins_date; } set { _ins_date = value; } }
        public string upd_userid { get { return _upd_userid; } set { _upd_userid = value; } }
        public string upd_date { get { return _upd_date; } set { _upd_date = value; } }


        public static string Insertjob_cancelmasDetials(job_cancelmasLogicLayer JOBCANCLEMASTERMASDetails)
        {
            return job_cancelMASDataLayer.InsertJOBCANCLEMASTER(JOBCANCLEMASTERMASDetails);

        }

        public static DataTable GetAllJOB_CANCLE_MASDetail(int USERCODE, int COMP_CODE)
        {
            return job_cancelMASDataLayer.GetAllJOB_CANCLE_MASDetail(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllIDWiseJOBCANCLEdetails(string cancel_code)
        {
            return job_cancelMASDataLayer.GetAllIDWiseJOBCANCLEdetails(cancel_code);
        }


        public static string UpdateWORK_LISTMASDetails(job_cancelmasLogicLayer JOB_CANCLEDETAILS)
        {
            return job_cancelMASDataLayer.UpdateWORK_LISTMASDetails(JOB_CANCLEDETAILS);
        }

        public static string DeleteWORKLISTByID(string cancel_code)
        {
            return job_cancelMASDataLayer.DeleteWORKLISTByID(cancel_code);
        }

        public static DataTable GetAllJOB_CancelMasterByCompany(string COMP_CODE)
        {
            return job_cancelMASDataLayer.GetAllJOB_CancelMasterByCompany(COMP_CODE);
        }


    }


    public class PARTY_STOCK_MASLogicLayer

    {

        string _COMP_CODE, _BRANCH_CODE, _TRAN_TYPE, _TRN_TYPE, _ACODE, _TRAN_DATE, _TRAN_NO, _SRNO, _INV_TRAN_DATE, _INV_TRAN_NO, _INV_SRNO, _SCODE, _QTY, _RATE, _AMT, _DIS_PER, _DIS_AMT, _GROSS_AMT, _ST_PER, _ST_AMT, _ADD_ST_PER, _ADD_ST_AMT, _TOT_AMT, _RET_QTY, _USE_QTY, _ENDT, _STATUS;

        public PARTY_STOCK_MASLogicLayer()
        {
            _COMP_CODE = "  ";
            _BRANCH_CODE = "  ";
            _TRAN_TYPE = "  ";
            _TRN_TYPE = "  ";
            _ACODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _INV_TRAN_DATE = "  ";
            _INV_TRAN_NO = "  ";
            _INV_SRNO = "  ";
            _SCODE = "  ";
            _QTY = "  ";
            _RATE = "  ";
            _AMT = "  ";
            _DIS_PER = "  ";
            _DIS_AMT = "  ";
            _GROSS_AMT = "  ";
            _ST_PER = "  ";
            _ST_AMT = "  ";
            _ADD_ST_PER = "  ";
            _ADD_ST_AMT = "  ";
            _TOT_AMT = "  ";
            _RET_QTY = "  ";
            _USE_QTY = "  ";
            _ENDT = "  ";
            _STATUS = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string TRAN_TYPE { get { return _TRAN_TYPE; } set { _TRAN_TYPE = value; } }
        public string TRN_TYPE { get { return _TRN_TYPE; } set { _TRN_TYPE = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string INV_TRAN_DATE { get { return _INV_TRAN_DATE; } set { _INV_TRAN_DATE = value; } }
        public string INV_TRAN_NO { get { return _INV_TRAN_NO; } set { _INV_TRAN_NO = value; } }
        public string INV_SRNO { get { return _INV_SRNO; } set { _INV_SRNO = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string DIS_PER { get { return _DIS_PER; } set { _DIS_PER = value; } }
        public string DIS_AMT { get { return _DIS_AMT; } set { _DIS_AMT = value; } }
        public string GROSS_AMT { get { return _GROSS_AMT; } set { _GROSS_AMT = value; } }
        public string ST_PER { get { return _ST_PER; } set { _ST_PER = value; } }
        public string ST_AMT { get { return _ST_AMT; } set { _ST_AMT = value; } }
        public string ADD_ST_PER { get { return _ADD_ST_PER; } set { _ADD_ST_PER = value; } }
        public string ADD_ST_AMT { get { return _ADD_ST_AMT; } set { _ADD_ST_AMT = value; } }
        public string TOT_AMT { get { return _TOT_AMT; } set { _TOT_AMT = value; } }
        public string RET_QTY { get { return _RET_QTY; } set { _RET_QTY = value; } }
        public string USE_QTY { get { return _USE_QTY; } set { _USE_QTY = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }

        public static DataTable GetPartyStockMasterDetailsFilterByACODE(string COMP_CODE, string ACODE)
        {
            return PARTY_STOCK_MASDataLayer.GetPartyStockMasterDetailsFilterByACODE(COMP_CODE, ACODE);
        }

    }




    public class JOBCARD_MASLogicLayer

    {

        string _COMP_CODE, _BRANCH_CODE, _TRAN_DATE, _TRAN_NO, _JOBCARD_NO, _JOBCARD_DATE, _JOBCARD_TIME, _ACODE, _CONTACT_PERSON, _CONTACT_PHONE, _CONTACT_EMAIL, _COMPLAIN_DATE, _COMPLAIN_TIME, _COMPLAIN_PERSON, _COMPLAIN_PHONE, _PARTY_REFSRNO, _RUNNING_HRS, _LOADING_HRS, _JOBSTART_DATE, _JOBSTART_TIME, _JOBCLOSE_DATE, _JOBCLOSE_TIME, _BCODE1, _BCODE2, _BCODE3, _BCODE4, _BCODE5, _BCODE1_PER, _BCODE2_PER, _BCODE3_PER, _BCODE4_PER, _BCODE5_PER, _BCODE1_AMT, _BCODE2_AMT, _BCODE3_AMT, _BCODE4_AMT, _BCODE5_AMT, _REF_TRAN_DATE, _REF_TRAN_NO, _GROSS_AMT, _EX_DUTY_PER, _EX_DUTY_AMT, _EX_CESS_PER, _EX_CESS_AMT, _EX_SHCESS_PER, _EX_SHCESS_AMT, _RO_AMT, _NET_AMT, _PROFIT_PER, _PROFIT_AMT, _REMARK, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE, _CLOSE_FLAG, _CLOSE_DATE, _CLOSE_USERID, _CHK_FLAG, _CHK_DATE, _CHK_USERID, _ASSIGN_BCODE, _ASSIGN_DATE, _ASSIGN_TIME, _INV_NUMBER, _INV_DATE, _INV_TIME, _CUSTOMER_REMARK, _LAST_JOBCARD_NO, _LAST_JOBCARD_DATE, _LAST_RUNNING_HRS, _LAST_LOADING_HRS, _SIGN_PERSON, _SIGN_PHONE, _SERVICE_TYPE, _AMC_TRAN_DATE, _AMC_TRAN_NO, _AMC_SRNO, _AMC_SUB_SRNO, _NEXT_SERVICE_DATE, _STATUS, _LAST_TRAN_DATE, _LAST_TRAN_NO, _PO_NO, _PO_DT, _COMPLAIN_TYPE, _COMPLAIN_NO, _TRAN_FROM, _CANCEL_CODE, _CANCEL_REMARK, _cancel_date, _cancel_time, _cancel_bcode, _cancel_userid;

        public JOBCARD_MASLogicLayer()
        {
            _COMP_CODE = "  ";
            _BRANCH_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _JOBCARD_NO = "  ";
            _JOBCARD_DATE = "  ";
            _JOBCARD_TIME = "  ";
            _ACODE = "  ";
            _CONTACT_PERSON = "  ";
            _CONTACT_PHONE = "  ";
            _CONTACT_EMAIL = "  ";
            _COMPLAIN_DATE = "  ";
            _COMPLAIN_TIME = "  ";
            _COMPLAIN_PERSON = "  ";
            _COMPLAIN_PHONE = "  ";
            _PARTY_REFSRNO = "  ";
            _RUNNING_HRS = "  ";
            _LOADING_HRS = "  ";
            _JOBSTART_DATE = "  ";
            _JOBSTART_TIME = "  ";
            _JOBCLOSE_DATE = "  ";
            _JOBCLOSE_TIME = "  ";
            _BCODE1 = "  ";
            _BCODE2 = "  ";
            _BCODE3 = "  ";
            _BCODE4 = "  ";
            _BCODE5 = "  ";
            _BCODE1_PER = "  ";
            _BCODE2_PER = "  ";
            _BCODE3_PER = "  ";
            _BCODE4_PER = "  ";
            _BCODE5_PER = "  ";
            _BCODE1_AMT = "  ";
            _BCODE2_AMT = "  ";
            _BCODE3_AMT = "  ";
            _BCODE4_AMT = "  ";
            _BCODE5_AMT = "  ";
            _REF_TRAN_DATE = "  ";
            _REF_TRAN_NO = "  ";
            _GROSS_AMT = "  ";
            _EX_DUTY_PER = "  ";
            _EX_DUTY_AMT = "  ";
            _EX_CESS_PER = "  ";
            _EX_CESS_AMT = "  ";
            _EX_SHCESS_PER = "  ";
            _EX_SHCESS_AMT = "  ";
            _RO_AMT = "  ";
            _NET_AMT = "  ";
            _PROFIT_PER = "  ";
            _PROFIT_AMT = "  ";
            _REMARK = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _CLOSE_FLAG = "  ";
            _CLOSE_DATE = "  ";
            _CLOSE_USERID = "  ";
            _CHK_FLAG = "  ";
            _CHK_DATE = "  ";
            _CHK_USERID = "  ";
            _ASSIGN_BCODE = "  ";
            _ASSIGN_DATE = "  ";
            _ASSIGN_TIME = "  ";
            _INV_NUMBER = "  ";
            _INV_DATE = "  ";
            _INV_TIME = "  ";
            _CUSTOMER_REMARK = "  ";
            _LAST_JOBCARD_NO = "  ";
            _LAST_JOBCARD_DATE = "  ";
            _LAST_RUNNING_HRS = "  ";
            _LAST_LOADING_HRS = "  ";
            _SIGN_PERSON = "  ";
            _SIGN_PHONE = "  ";
            _SERVICE_TYPE = "  ";
            _AMC_TRAN_DATE = "  ";
            _AMC_TRAN_NO = "  ";
            _AMC_SRNO = "  ";
            _AMC_SUB_SRNO = "  ";
            _NEXT_SERVICE_DATE = "  ";
            _STATUS = "  ";
            _LAST_TRAN_DATE = "  ";
            _LAST_TRAN_NO = "  ";
            _PO_NO = "  ";
            _PO_DT = "  ";
            _COMPLAIN_TYPE = "  ";
            _COMPLAIN_NO = "  ";
            _TRAN_FROM = "  ";
            _CANCEL_CODE = "  ";
            _CANCEL_REMARK = "  ";
            _cancel_date = "  ";
            _cancel_time = "  ";
            _cancel_bcode = "  ";
            _cancel_userid = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string JOBCARD_NO { get { return _JOBCARD_NO; } set { _JOBCARD_NO = value; } }
        public string JOBCARD_DATE { get { return _JOBCARD_DATE; } set { _JOBCARD_DATE = value; } }
        public string JOBCARD_TIME { get { return _JOBCARD_TIME; } set { _JOBCARD_TIME = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string CONTACT_PERSON { get { return _CONTACT_PERSON; } set { _CONTACT_PERSON = value; } }
        public string CONTACT_PHONE { get { return _CONTACT_PHONE; } set { _CONTACT_PHONE = value; } }
        public string CONTACT_EMAIL { get { return _CONTACT_EMAIL; } set { _CONTACT_EMAIL = value; } }
        public string COMPLAIN_DATE { get { return _COMPLAIN_DATE; } set { _COMPLAIN_DATE = value; } }
        public string COMPLAIN_TIME { get { return _COMPLAIN_TIME; } set { _COMPLAIN_TIME = value; } }
        public string COMPLAIN_PERSON { get { return _COMPLAIN_PERSON; } set { _COMPLAIN_PERSON = value; } }
        public string COMPLAIN_PHONE { get { return _COMPLAIN_PHONE; } set { _COMPLAIN_PHONE = value; } }
        public string PARTY_REFSRNO { get { return _PARTY_REFSRNO; } set { _PARTY_REFSRNO = value; } }
        public string RUNNING_HRS { get { return _RUNNING_HRS; } set { _RUNNING_HRS = value; } }
        public string LOADING_HRS { get { return _LOADING_HRS; } set { _LOADING_HRS = value; } }
        public string JOBSTART_DATE { get { return _JOBSTART_DATE; } set { _JOBSTART_DATE = value; } }
        public string JOBSTART_TIME { get { return _JOBSTART_TIME; } set { _JOBSTART_TIME = value; } }
        public string JOBCLOSE_DATE { get { return _JOBCLOSE_DATE; } set { _JOBCLOSE_DATE = value; } }
        public string JOBCLOSE_TIME { get { return _JOBCLOSE_TIME; } set { _JOBCLOSE_TIME = value; } }
        public string BCODE1 { get { return _BCODE1; } set { _BCODE1 = value; } }
        public string BCODE2 { get { return _BCODE2; } set { _BCODE2 = value; } }
        public string BCODE3 { get { return _BCODE3; } set { _BCODE3 = value; } }
        public string BCODE4 { get { return _BCODE4; } set { _BCODE4 = value; } }
        public string BCODE5 { get { return _BCODE5; } set { _BCODE5 = value; } }
        public string BCODE1_PER { get { return _BCODE1_PER; } set { _BCODE1_PER = value; } }
        public string BCODE2_PER { get { return _BCODE2_PER; } set { _BCODE2_PER = value; } }
        public string BCODE3_PER { get { return _BCODE3_PER; } set { _BCODE3_PER = value; } }
        public string BCODE4_PER { get { return _BCODE4_PER; } set { _BCODE4_PER = value; } }
        public string BCODE5_PER { get { return _BCODE5_PER; } set { _BCODE5_PER = value; } }
        public string BCODE1_AMT { get { return _BCODE1_AMT; } set { _BCODE1_AMT = value; } }
        public string BCODE2_AMT { get { return _BCODE2_AMT; } set { _BCODE2_AMT = value; } }
        public string BCODE3_AMT { get { return _BCODE3_AMT; } set { _BCODE3_AMT = value; } }
        public string BCODE4_AMT { get { return _BCODE4_AMT; } set { _BCODE4_AMT = value; } }
        public string BCODE5_AMT { get { return _BCODE5_AMT; } set { _BCODE5_AMT = value; } }
        public string REF_TRAN_DATE { get { return _REF_TRAN_DATE; } set { _REF_TRAN_DATE = value; } }
        public string REF_TRAN_NO { get { return _REF_TRAN_NO; } set { _REF_TRAN_NO = value; } }
        public string GROSS_AMT { get { return _GROSS_AMT; } set { _GROSS_AMT = value; } }
        public string EX_DUTY_PER { get { return _EX_DUTY_PER; } set { _EX_DUTY_PER = value; } }
        public string EX_DUTY_AMT { get { return _EX_DUTY_AMT; } set { _EX_DUTY_AMT = value; } }
        public string EX_CESS_PER { get { return _EX_CESS_PER; } set { _EX_CESS_PER = value; } }
        public string EX_CESS_AMT { get { return _EX_CESS_AMT; } set { _EX_CESS_AMT = value; } }
        public string EX_SHCESS_PER { get { return _EX_SHCESS_PER; } set { _EX_SHCESS_PER = value; } }
        public string EX_SHCESS_AMT { get { return _EX_SHCESS_AMT; } set { _EX_SHCESS_AMT = value; } }
        public string RO_AMT { get { return _RO_AMT; } set { _RO_AMT = value; } }
        public string NET_AMT { get { return _NET_AMT; } set { _NET_AMT = value; } }
        public string PROFIT_PER { get { return _PROFIT_PER; } set { _PROFIT_PER = value; } }
        public string PROFIT_AMT { get { return _PROFIT_AMT; } set { _PROFIT_AMT = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string CLOSE_FLAG { get { return _CLOSE_FLAG; } set { _CLOSE_FLAG = value; } }
        public string CLOSE_DATE { get { return _CLOSE_DATE; } set { _CLOSE_DATE = value; } }
        public string CLOSE_USERID { get { return _CLOSE_USERID; } set { _CLOSE_USERID = value; } }
        public string CHK_FLAG { get { return _CHK_FLAG; } set { _CHK_FLAG = value; } }
        public string CHK_DATE { get { return _CHK_DATE; } set { _CHK_DATE = value; } }
        public string CHK_USERID { get { return _CHK_USERID; } set { _CHK_USERID = value; } }
        public string ASSIGN_BCODE { get { return _ASSIGN_BCODE; } set { _ASSIGN_BCODE = value; } }
        public string ASSIGN_DATE { get { return _ASSIGN_DATE; } set { _ASSIGN_DATE = value; } }
        public string ASSIGN_TIME { get { return _ASSIGN_TIME; } set { _ASSIGN_TIME = value; } }
        public string INV_NUMBER { get { return _INV_NUMBER; } set { _INV_NUMBER = value; } }
        public string INV_DATE { get { return _INV_DATE; } set { _INV_DATE = value; } }
        public string INV_TIME { get { return _INV_TIME; } set { _INV_TIME = value; } }
        public string CUSTOMER_REMARK { get { return _CUSTOMER_REMARK; } set { _CUSTOMER_REMARK = value; } }
        public string LAST_JOBCARD_NO { get { return _LAST_JOBCARD_NO; } set { _LAST_JOBCARD_NO = value; } }
        public string LAST_JOBCARD_DATE { get { return _LAST_JOBCARD_DATE; } set { _LAST_JOBCARD_DATE = value; } }
        public string LAST_RUNNING_HRS { get { return _LAST_RUNNING_HRS; } set { _LAST_RUNNING_HRS = value; } }
        public string LAST_LOADING_HRS { get { return _LAST_LOADING_HRS; } set { _LAST_LOADING_HRS = value; } }
        public string SIGN_PERSON { get { return _SIGN_PERSON; } set { _SIGN_PERSON = value; } }
        public string SIGN_PHONE { get { return _SIGN_PHONE; } set { _SIGN_PHONE = value; } }
        public string SERVICE_TYPE { get { return _SERVICE_TYPE; } set { _SERVICE_TYPE = value; } }
        public string AMC_TRAN_DATE { get { return _AMC_TRAN_DATE; } set { _AMC_TRAN_DATE = value; } }
        public string AMC_TRAN_NO { get { return _AMC_TRAN_NO; } set { _AMC_TRAN_NO = value; } }
        public string AMC_SRNO { get { return _AMC_SRNO; } set { _AMC_SRNO = value; } }
        public string AMC_SUB_SRNO { get { return _AMC_SUB_SRNO; } set { _AMC_SUB_SRNO = value; } }
        public string NEXT_SERVICE_DATE { get { return _NEXT_SERVICE_DATE; } set { _NEXT_SERVICE_DATE = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string LAST_TRAN_DATE { get { return _LAST_TRAN_DATE; } set { _LAST_TRAN_DATE = value; } }
        public string LAST_TRAN_NO { get { return _LAST_TRAN_NO; } set { _LAST_TRAN_NO = value; } }
        public string PO_NO { get { return _PO_NO; } set { _PO_NO = value; } }
        public string PO_DT { get { return _PO_DT; } set { _PO_DT = value; } }
        public string COMPLAIN_TYPE { get { return _COMPLAIN_TYPE; } set { _COMPLAIN_TYPE = value; } }
        public string COMPLAIN_NO { get { return _COMPLAIN_NO; } set { _COMPLAIN_NO = value; } }
        public string TRAN_FROM { get { return _TRAN_FROM; } set { _TRAN_FROM = value; } }
        public string CANCEL_CODE { get { return _CANCEL_CODE; } set { _CANCEL_CODE = value; } }
        public string CANCEL_REMARK { get { return _CANCEL_REMARK; } set { _CANCEL_REMARK = value; } }
        public string cancel_date { get { return _cancel_date; } set { _cancel_date = value; } }
        public string cancel_time { get { return _cancel_time; } set { _cancel_time = value; } }
        public string cancel_bcode { get { return _cancel_bcode; } set { _cancel_bcode = value; } }
        public string cancel_userid { get { return _cancel_userid; } set { _cancel_userid = value; } }

        public static string InsertJOBCARD_MASDetail(JOBCARD_MASLogicLayer JOBCARDMaster, string JOBCARD_COMPLAINDetails, string JOBCARD_SERVICEDetails, string JOBCARD_REMARKDetails, string JOBCARD_SERVICE_USE_ITEMDetails, string JOBCARD_LAB_CHARGEDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1)
        {
            return JOBCARD_MASDataLayer.InsertJOBCARD_MASDetail(JOBCARDMaster, JOBCARD_COMPLAINDetails, JOBCARD_SERVICEDetails, JOBCARD_REMARKDetails, JOBCARD_SERVICE_USE_ITEMDetails, JOBCARD_LAB_CHARGEDetails, COMP_CODE, BRANCH_CODE, YRDT1);
        }

        public static string UpdateJOBCARD_MASDetail(JOBCARD_MASLogicLayer JOBCARDMaster, string JOBCARD_COMPLAINDetails, string JOBCARD_SERVICEDetails, string JOBCARD_REMARKDetails, string JOBCARD_SERVICE_USE_ITEMDetails, string JOBCARD_LAB_CHARGEDetails)
        {
            return JOBCARD_MASDataLayer.UpdateJOBCARD_MASDetail(JOBCARDMaster, JOBCARD_COMPLAINDetails, JOBCARD_SERVICEDetails, JOBCARD_REMARKDetails, JOBCARD_SERVICE_USE_ITEMDetails, JOBCARD_LAB_CHARGEDetails);
        }

        public static string GetJOBCARDNumber_JOBCARDMASCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string JOBCARD_DATE)
        {
            return JOBCARD_MASDataLayer.GetJOBCARDNumber_JOBCARDMASCompanyBranchYearWise(COMP_CODE, BRANCH_CODE, YRDT1, JOBCARD_DATE);
        }

        public static DataSet GetAllIDWiseJOBCARD_MASTERDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return JOBCARD_MASDataLayer.GetAllIDWiseJOBCARD_MASTERDetials(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetAllJOBCARD_MASTERDetails(int USERCODE, int COMP_CODE)
        {
            return JOBCARD_MASDataLayer.GetAllJOBCARD_MASTERDetails(USERCODE, COMP_CODE);
        }

        public static DataTable GetLastJOBCARD_MASDetailsOnAcodeAndPartyRefNo(string ACODE, string PARTY_REFNO)
        {
            return JOBCARD_MASDataLayer.GetLastJOBCARD_MASDetailsOnAcodeAndPartyRefNo(ACODE, PARTY_REFNO);
        }

        public static string DeleteJOBCARD_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {
            return JOBCARD_MASDataLayer.DeleteJOBCARD_MASDetailsByID(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetIDWiseJOBCARD_MASForServiceBillDetails(string TRAN_NO, DateTime TRAN_DATE)
        {
            return JOBCARD_MASDataLayer.GetIDWiseJOBCARD_MASForServiceBillDetails(TRAN_NO, TRAN_DATE);
        }


        public static string jobcard_mas_with_rec_iss_m(string JOBCARDMaster, string JOBCARD_LAB_CHARGEDetails, string YRDT1, string YRDT2, string USER_ID)
        {
            return JOBCARD_MASDataLayer.jobcard_mas_with_rec_iss_m(JOBCARDMaster, JOBCARD_LAB_CHARGEDetails, YRDT1, YRDT2, USER_ID);
        }

    }



    public class JOBCARD_COMPLAINLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _COMPLAIN_DESC, _REMARK, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE, _COMPLAIN_CODE;

        public JOBCARD_COMPLAINLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _COMPLAIN_DESC = "  ";
            _REMARK = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _COMPLAIN_CODE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string COMPLAIN_DESC { get { return _COMPLAIN_DESC; } set { _COMPLAIN_DESC = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string COMPLAIN_CODE { get { return _COMPLAIN_CODE; } set { _COMPLAIN_CODE = value; } }



    }


    public class JOBCARD_LABLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _CCODE, _LAB_DESC, _QTY, _RATE, _AMT, _REMARK, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE;

        public JOBCARD_LABLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _CCODE = "  ";
            _LAB_DESC = "  ";
            _QTY = "  ";
            _RATE = "  ";
            _AMT = "  ";
            _REMARK = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string CCODE { get { return _CCODE; } set { _CCODE = value; } }
        public string LAB_DESC { get { return _LAB_DESC; } set { _LAB_DESC = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }
        public string RATE { get { return _RATE; } set { _RATE = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }

    }


    public class JOBCARD_SERVICELogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _BRANDTYPE_CODE, _BRANDTYPE_SRNO, _RESULT_FLAG_1_1, _RESULT_FLAG_2_1, _RESULT_FLAG_3_1, _REMARK, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE, _RESULT_FLAG_1_2, _RESULT_FLAG_2_2, _RESULT_FLAG_3_2;

        public JOBCARD_SERVICELogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _BRANDTYPE_CODE = "  ";
            _BRANDTYPE_SRNO = "  ";
            _RESULT_FLAG_1_1 = "  ";
            _RESULT_FLAG_2_1 = "  ";
            _RESULT_FLAG_3_1 = "  ";
            _REMARK = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _RESULT_FLAG_1_2 = "  ";
            _RESULT_FLAG_2_2 = "  ";
            _RESULT_FLAG_3_2 = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string BRANDTYPE_CODE { get { return _BRANDTYPE_CODE; } set { _BRANDTYPE_CODE = value; } }
        public string BRANDTYPE_SRNO { get { return _BRANDTYPE_SRNO; } set { _BRANDTYPE_SRNO = value; } }
        public string RESULT_FLAG_1_1 { get { return _RESULT_FLAG_1_1; } set { _RESULT_FLAG_1_1 = value; } }
        public string RESULT_FLAG_2_1 { get { return _RESULT_FLAG_2_1; } set { _RESULT_FLAG_2_1 = value; } }
        public string RESULT_FLAG_3_1 { get { return _RESULT_FLAG_3_1; } set { _RESULT_FLAG_3_1 = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string RESULT_FLAG_1_2 { get { return _RESULT_FLAG_1_2; } set { _RESULT_FLAG_1_2 = value; } }
        public string RESULT_FLAG_2_2 { get { return _RESULT_FLAG_2_2; } set { _RESULT_FLAG_2_2 = value; } }
        public string RESULT_FLAG_3_2 { get { return _RESULT_FLAG_3_2; } set { _RESULT_FLAG_3_2 = value; } }


    }



    public class JOBCARD_SERVICE_REMARKLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _REMARK, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE;

        public JOBCARD_SERVICE_REMARKLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _REMARK = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }



    }


    public class JOBCARD_USE_ITEMLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SRNO, _SCODE, _REF_TRAN_DATE, _REF_TRAN_NO, _REF_SRNO, _QTY;

        public JOBCARD_USE_ITEMLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SRNO = "  ";
            _SCODE = "  ";
            _REF_TRAN_DATE = "  ";
            _REF_TRAN_NO = "  ";
            _REF_SRNO = "  ";
            _QTY = "  ";

        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string SCODE { get { return _SCODE; } set { _SCODE = value; } }
        public string REF_TRAN_DATE { get { return _REF_TRAN_DATE; } set { _REF_TRAN_DATE = value; } }
        public string REF_TRAN_NO { get { return _REF_TRAN_NO; } set { _REF_TRAN_NO = value; } }
        public string REF_SRNO { get { return _REF_SRNO; } set { _REF_SRNO = value; } }
        public string QTY { get { return _QTY; } set { _QTY = value; } }


    }


    public class jobcard_assign_logLogicLayer

    {

        string _comp_code, _tran_date, _tran_no, _srno, _assign_bcode, _assign_date, _assign_time;

        public jobcard_assign_logLogicLayer()
        {
            _comp_code = "  ";
            _tran_date = "  ";
            _tran_no = "  ";
            _srno = "  ";
            _assign_bcode = "  ";
            _assign_date = "  ";
            _assign_time = "  ";


        }
        public string comp_code { get { return _comp_code; } set { _comp_code = value; } }
        public string tran_date { get { return _tran_date; } set { _tran_date = value; } }
        public string tran_no { get { return _tran_no; } set { _tran_no = value; } }
        public string srno { get { return _srno; } set { _srno = value; } }
        public string assign_bcode { get { return _assign_bcode; } set { _assign_bcode = value; } }
        public string assign_date { get { return _assign_date; } set { _assign_date = value; } }
        public string assign_time { get { return _assign_time; } set { _assign_time = value; } }

        public static DataTable GetJOBCARD_ASSIGN_LOGDetailsForGrid(string TRAN_NO, DateTime TRAN_DATE)
        {
            return jobcard_assign_logDataLayer.GetJOBCARD_ASSIGN_LOGDetailsForGrid(TRAN_NO, TRAN_DATE);
        }

    }




    public class PAY_REC_MLogicLayer

    {

        string _COMP_CODE, _TRAN_TYPE, _TRAN_DATE, _TRAN_NO, _VOU_DATE, _VOU_NO, _ACODE, _SIGN, _NARRN, _AMT, _ENDT, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE, _RW_CODE, _RW_TYPE, _FIGURE_FLAG, _EX_DUTY_PER, _EX_DUTY_AMT, _EX_CESS_PER, _EX_CESS_AMT, _EX_SHCESS_PER, _EX_SHCESS_AMT, _TOT_GROSS_AMT, _ST_PER, _ST_AMT, _ADD_ST_PER, _ADD_ST_AMT, _TRN_TYPE, _TRNDT, _BRANCH_CODE, _CHK_FLAG, _CHK_DATE, _CHK_USERID, _CONF_FLAG, _CONF_DATE, _CONF_USERID, _BCODE, _PARTY_TYPE, _INV_REASON;

        public PAY_REC_MLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_TYPE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _VOU_DATE = "  ";
            _VOU_NO = "  ";
            _ACODE = "  ";
            _SIGN = "  ";
            _NARRN = "  ";
            _AMT = "  ";
            _ENDT = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _RW_CODE = "  ";
            _RW_TYPE = "  ";
            _FIGURE_FLAG = "  ";
            _EX_DUTY_PER = "  ";
            _EX_DUTY_AMT = "  ";
            _EX_CESS_PER = "  ";
            _EX_CESS_AMT = "  ";
            _EX_SHCESS_PER = "  ";
            _EX_SHCESS_AMT = "  ";
            _TOT_GROSS_AMT = "  ";
            _ST_PER = "  ";
            _ST_AMT = "  ";
            _ADD_ST_PER = "  ";
            _ADD_ST_AMT = "  ";
            _TRN_TYPE = "  ";
            _TRNDT = "  ";
            _BRANCH_CODE = "  ";
            _CHK_FLAG = "  ";
            _CHK_DATE = "  ";
            _CHK_USERID = "  ";
            _CONF_FLAG = "  ";
            _CONF_DATE = "  ";
            _CONF_USERID = "  ";
            _BCODE = "  ";
            _PARTY_TYPE = " ";
            _INV_REASON = " ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_TYPE { get { return _TRAN_TYPE; } set { _TRAN_TYPE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string VOU_DATE { get { return _VOU_DATE; } set { _VOU_DATE = value; } }
        public string VOU_NO { get { return _VOU_NO; } set { _VOU_NO = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string SIGN { get { return _SIGN; } set { _SIGN = value; } }
        public string NARRN { get { return _NARRN; } set { _NARRN = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string RW_CODE { get { return _RW_CODE; } set { _RW_CODE = value; } }
        public string RW_TYPE { get { return _RW_TYPE; } set { _RW_TYPE = value; } }
        public string FIGURE_FLAG { get { return _FIGURE_FLAG; } set { _FIGURE_FLAG = value; } }
        public string EX_DUTY_PER { get { return _EX_DUTY_PER; } set { _EX_DUTY_PER = value; } }
        public string EX_DUTY_AMT { get { return _EX_DUTY_AMT; } set { _EX_DUTY_AMT = value; } }
        public string EX_CESS_PER { get { return _EX_CESS_PER; } set { _EX_CESS_PER = value; } }
        public string EX_CESS_AMT { get { return _EX_CESS_AMT; } set { _EX_CESS_AMT = value; } }
        public string EX_SHCESS_PER { get { return _EX_SHCESS_PER; } set { _EX_SHCESS_PER = value; } }
        public string EX_SHCESS_AMT { get { return _EX_SHCESS_AMT; } set { _EX_SHCESS_AMT = value; } }
        public string TOT_GROSS_AMT { get { return _TOT_GROSS_AMT; } set { _TOT_GROSS_AMT = value; } }
        public string ST_PER { get { return _ST_PER; } set { _ST_PER = value; } }
        public string ST_AMT { get { return _ST_AMT; } set { _ST_AMT = value; } }
        public string ADD_ST_PER { get { return _ADD_ST_PER; } set { _ADD_ST_PER = value; } }
        public string ADD_ST_AMT { get { return _ADD_ST_AMT; } set { _ADD_ST_AMT = value; } }
        public string TRN_TYPE { get { return _TRN_TYPE; } set { _TRN_TYPE = value; } }
        public string TRNDT { get { return _TRNDT; } set { _TRNDT = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string CHK_FLAG { get { return _CHK_FLAG; } set { _CHK_FLAG = value; } }
        public string CHK_DATE { get { return _CHK_DATE; } set { _CHK_DATE = value; } }
        public string CHK_USERID { get { return _CHK_USERID; } set { _CHK_USERID = value; } }
        public string CONF_FLAG { get { return _CONF_FLAG; } set { _CONF_FLAG = value; } }
        public string CONF_DATE { get { return _CONF_DATE; } set { _CONF_DATE = value; } }
        public string CONF_USERID { get { return _CONF_USERID; } set { _CONF_USERID = value; } }
        public string BCODE { get { return _BCODE; } set { _BCODE = value; } }
        public string PARTY_TYPE { get { return _PARTY_TYPE; } set { _PARTY_TYPE = value; } }
        public string INV_REASON { get { return _INV_REASON; } set { _INV_REASON = value; } }


        public static string InsertPAY_REC_MDetail(PAY_REC_MLogicLayer PayReceiveMaster, string PAY_REC_Details, string PAY_REC_INVDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE)
        {
            return PAY_REC_MDataLayer.InsertPAY_REC_MDetail(PayReceiveMaster, PAY_REC_Details, PAY_REC_INVDetails, COMP_CODE, BRANCH_CODE, YRDT1, TRAN_TYPE);
        }

        public static string UpdatePAY_REC_MASDetail(PAY_REC_MLogicLayer PAY_REC_Master, string PAY_REC_Details, string PAY_REC_INVDetails)
        {
            return PAY_REC_MDataLayer.UpdatePAY_REC_MASDetail(PAY_REC_Master, PAY_REC_Details, PAY_REC_INVDetails);
        }

        public static string UpdatePAY_REC_TDetailForBANK_RECO(string COMP_CODE, string TRAN_NO, DateTime TRAN_DATE, string SR_NO, DateTime BANK_DATE, string REMARK)
        {
            return PAY_REC_MDataLayer.UpdatePAY_REC_TDetailForBANK_RECO(COMP_CODE, TRAN_NO, TRAN_DATE, SR_NO, BANK_DATE, REMARK);
        }


        public static string DeletePAY_REC_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {
            return PAY_REC_MDataLayer.DeletePAY_REC_MASDetailsByID(TRAN_NO, TRAN_DATE);
        }

        public static string GetVoucherNumber_PAY_REC_MASCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string VOU_DATE, string TRAN_TYPE)
        {
            return PAY_REC_MDataLayer.GetVoucherNumber_PAY_REC_MASCompanyBranchYearWise(COMP_CODE, BRANCH_CODE, YRDT1, VOU_DATE, TRAN_TYPE);
        }

        public static DataSet GetAllIDWisePAY_REC_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return PAY_REC_MDataLayer.GetAllIDWisePAY_REC_MASDetials(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetAllPAY_REC_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE, string ACODE)
        {
            return PAY_REC_MDataLayer.GetAllPAY_REC_MASDetails(USERCODE, COMP_CODE, TRAN_TYPE, ACODE);
        }


        public static DataTable GetAllPAY_REC_MDetials(int USERCODE, int COMP_CODE, string TRAN_TYPE)
        {
            return PAY_REC_MDataLayer.GetAllPAY_REC_MDetials(USERCODE, COMP_CODE, TRAN_TYPE);
        }

        public static DataTable GetAllPAY_REC_MASDetailsForBankReco(int USERCODE, int COMP_CODE, string ACODE)
        {
            return PAY_REC_MDataLayer.GetAllPAY_REC_MASDetailsForBankReco(USERCODE, COMP_CODE, ACODE);
        }

        public static DataTable GetPaidRecordForPAY_REC_INV(int p_branch_code, int pay_rec_t_acode, int p_comp_code, DateTime pay_rec_m_vou_date, string pay_rec_m_tran_type, string p_tran_type, int pay_rec_t_dracode, int pay_rec_t_cracode, int pay_rec_inv_tot_rec, DateTime YRDT1, DateTime YRDT2)
        {
            return PAY_REC_MDataLayer.GetPaidRecordForPAY_REC_INV(p_branch_code, pay_rec_t_acode, p_comp_code, pay_rec_m_vou_date, pay_rec_m_tran_type, p_tran_type, pay_rec_t_dracode, pay_rec_t_cracode, pay_rec_inv_tot_rec, YRDT1, YRDT2);
        }


        public static DataTable GetPaidRecordFor_CreditDebit_Note(int p_branch_code, int pay_rec_m_acode, int pay_rec_t_acode, int p_comp_code, DateTime pay_rec_m_vou_date, string pay_rec_m_tran_type, string p_tran_type, int pay_rec_t_dracode, int pay_rec_t_cracode, int pay_rec_inv_tot_rec, DateTime YRDT1, DateTime YRDT2)
        {
            return PAY_REC_MDataLayer.GetPaidRecordFor_CreditDebit_Note(p_branch_code, pay_rec_m_acode, pay_rec_t_acode, p_comp_code, pay_rec_m_vou_date, pay_rec_m_tran_type, p_tran_type, pay_rec_t_dracode, pay_rec_t_cracode, pay_rec_inv_tot_rec, YRDT1, YRDT2);
        }

    }





    public class PAY_REC_TLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SR, _DRACODE, _CRACODE, _SIGN, _NARRN, _CHQ_NO, _CHQ_DT, _BANKDT, _AMT, _ENDT, _STATUS, _DR_PAID_AMT, _CR_PAID_AMT, _BILL_NO, _BILL_DATE, _BILL_AMT, _T_RATE, _T_AMT, _S_RATE, _S_AMT, _C_RATE, _C_AMT, _TOT_TDS, _TDSACODE, _TRAN_TYPE, _TRN_TYPE, _BANK_NARRN, _PARTY_BANK, _OA_AMT, _OA_FLAG, _PARTY_TYPE;

        public PAY_REC_TLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SR = "  ";
            _DRACODE = "  ";
            _CRACODE = "  ";
            _SIGN = "  ";
            _NARRN = "  ";
            _CHQ_NO = "  ";
            _CHQ_DT = "  ";
            _BANKDT = "  ";
            _AMT = "  ";
            _ENDT = "  ";
            _STATUS = "  ";
            _DR_PAID_AMT = "  ";
            _CR_PAID_AMT = "  ";
            _BILL_NO = "  ";
            _BILL_DATE = "  ";
            _BILL_AMT = "  ";
            _T_RATE = "  ";
            _T_AMT = "  ";
            _S_RATE = "  ";
            _S_AMT = "  ";
            _C_RATE = "  ";
            _C_AMT = "  ";
            _TOT_TDS = "  ";
            _TDSACODE = "  ";
            _TRAN_TYPE = "  ";
            _TRN_TYPE = "  ";
            _BANK_NARRN = "  ";
            _PARTY_BANK = "  ";
            _OA_AMT = "  ";
            _OA_FLAG = "  ";
            _PARTY_TYPE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SR { get { return _SR; } set { _SR = value; } }
        public string DRACODE { get { return _DRACODE; } set { _DRACODE = value; } }
        public string CRACODE { get { return _CRACODE; } set { _CRACODE = value; } }
        public string SIGN { get { return _SIGN; } set { _SIGN = value; } }
        public string NARRN { get { return _NARRN; } set { _NARRN = value; } }
        public string CHQ_NO { get { return _CHQ_NO; } set { _CHQ_NO = value; } }
        public string CHQ_DT { get { return _CHQ_DT; } set { _CHQ_DT = value; } }
        public string BANKDT { get { return _BANKDT; } set { _BANKDT = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string DR_PAID_AMT { get { return _DR_PAID_AMT; } set { _DR_PAID_AMT = value; } }
        public string CR_PAID_AMT { get { return _CR_PAID_AMT; } set { _CR_PAID_AMT = value; } }
        public string BILL_NO { get { return _BILL_NO; } set { _BILL_NO = value; } }
        public string BILL_DATE { get { return _BILL_DATE; } set { _BILL_DATE = value; } }
        public string BILL_AMT { get { return _BILL_AMT; } set { _BILL_AMT = value; } }
        public string T_RATE { get { return _T_RATE; } set { _T_RATE = value; } }
        public string T_AMT { get { return _T_AMT; } set { _T_AMT = value; } }
        public string S_RATE { get { return _S_RATE; } set { _S_RATE = value; } }
        public string S_AMT { get { return _S_AMT; } set { _S_AMT = value; } }
        public string C_RATE { get { return _C_RATE; } set { _C_RATE = value; } }
        public string C_AMT { get { return _C_AMT; } set { _C_AMT = value; } }
        public string TOT_TDS { get { return _TOT_TDS; } set { _TOT_TDS = value; } }
        public string TDSACODE { get { return _TDSACODE; } set { _TDSACODE = value; } }
        public string TRAN_TYPE { get { return _TRAN_TYPE; } set { _TRAN_TYPE = value; } }
        public string TRN_TYPE { get { return _TRN_TYPE; } set { _TRN_TYPE = value; } }
        public string BANK_NARRN { get { return _BANK_NARRN; } set { _BANK_NARRN = value; } }
        public string PARTY_BANK { get { return _PARTY_BANK; } set { _PARTY_BANK = value; } }
        public string OA_AMT { get { return _OA_AMT; } set { _OA_AMT = value; } }
        public string OA_FLAG { get { return _OA_FLAG; } set { _OA_FLAG = value; } }
        public string PARTY_TYPE { get { return _PARTY_TYPE; } set { _PARTY_TYPE = value; } }



    }



    public class PAY_REC_INVLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SR, _SUB_SR, _XXX_TYPE, _XXX_DATE, _XXX_NO, _AMT, _ENDT, _TRAN_TYPE, _ACODE, _LESS_AMT, _TDS_AMT, _GST_RATE, _GST_AMT, _CGST_RATE, _CGST_AMT, _SGST_RATE, _SGST_AMT, _IGST_RATE, _IGST_AMT, _ACT_AMT;

        public PAY_REC_INVLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SR = "  ";
            _SUB_SR = "  ";
            _XXX_TYPE = "  ";
            _XXX_DATE = "  ";
            _XXX_NO = "  ";
            _AMT = "  ";
            _ENDT = "  ";
            _TRAN_TYPE = "  ";
            _ACODE = "  ";
            _LESS_AMT = "  ";
            _TDS_AMT = "  ";
            _GST_RATE = "  ";
            _GST_AMT = "  ";
            _CGST_RATE = "  ";
            _CGST_AMT = "  ";
            _SGST_RATE = "  ";
            _SGST_AMT = "  ";
            _IGST_RATE = "  ";
            _IGST_AMT = "  ";
            _ACT_AMT = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SR { get { return _SR; } set { _SR = value; } }
        public string SUB_SR { get { return _SUB_SR; } set { _SUB_SR = value; } }
        public string XXX_TYPE { get { return _XXX_TYPE; } set { _XXX_TYPE = value; } }
        public string XXX_DATE { get { return _XXX_DATE; } set { _XXX_DATE = value; } }
        public string XXX_NO { get { return _XXX_NO; } set { _XXX_NO = value; } }
        public string AMT { get { return _AMT; } set { _AMT = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string TRAN_TYPE { get { return _TRAN_TYPE; } set { _TRAN_TYPE = value; } }
        public string ACODE { get { return _ACODE; } set { _ACODE = value; } }
        public string LESS_AMT { get { return _LESS_AMT; } set { _LESS_AMT = value; } }
        public string TDS_AMT { get { return _TDS_AMT; } set { _TDS_AMT = value; } }
        public string GST_RATE { get { return _GST_RATE; } set { _GST_RATE = value; } }
        public string GST_AMT { get { return _GST_AMT; } set { _GST_AMT = value; } }
        public string CGST_RATE { get { return _CGST_RATE; } set { _CGST_RATE = value; } }
        public string CGST_AMT { get { return _CGST_AMT; } set { _CGST_AMT = value; } }
        public string SGST_RATE { get { return _SGST_RATE; } set { _SGST_RATE = value; } }
        public string SGST_AMT { get { return _SGST_AMT; } set { _SGST_AMT = value; } }
        public string IGST_RATE { get { return _IGST_RATE; } set { _IGST_RATE = value; } }
        public string IGST_AMT { get { return _IGST_AMT; } set { _IGST_AMT = value; } }
        public string ACT_AMT { get { return _ACT_AMT; } set { _ACT_AMT = value; } }




    }




    public class NARRATIONLogicLayer

    {

        string _NARRN;

        public NARRATIONLogicLayer()
        {
            _NARRN = "  ";


        }
        public string NARRN { get { return _NARRN; } set { _NARRN = value; } }

        public static DataTable GetAllNarrationDetials(int USERCODE, int COMP_CODE)
        {
            return NARRATIONDataLayer.GetAllNarrationDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllIDWiseNarrationsDetails(string Narran)
        {
            return NARRATIONDataLayer.GetAllIDWiseNarrationsDetails(Narran);
        }


    }



    public class DESIGN_MASLogicLayer
    {

        string _DESIGN_CODE, _DESIGN_NAME, _DESIGN_ORD, _JOB_CATCODE, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE;

        public DESIGN_MASLogicLayer()
        {
            _DESIGN_CODE = "  ";
            _DESIGN_NAME = "  ";
            _DESIGN_ORD = "  ";
            _JOB_CATCODE = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";


        }
        public string DESIGN_CODE { get { return _DESIGN_CODE; } set { _DESIGN_CODE = value; } }
        public string DESIGN_NAME { get { return _DESIGN_NAME; } set { _DESIGN_NAME = value; } }
        public string DESIGN_ORD { get { return _DESIGN_ORD; } set { _DESIGN_ORD = value; } }
        public string JOB_CATCODE { get { return _JOB_CATCODE; } set { _JOB_CATCODE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


        public static string InsertDESIGNATION_MAS(DESIGN_MASLogicLayer DESIGN_LISTMASDetails)
        {
            return DESIGN_MASDataLayer.InsertDESIGNATION_MAS(DESIGN_LISTMASDetails);
        }

        public static string UpdateDESIGNATION_MASDetails(DESIGN_MASLogicLayer DESIGN_LISTMASDetails)
        {
            return DESIGN_MASDataLayer.UpdateDESIGNATION_MASDetails(DESIGN_LISTMASDetails);
        }

        public static DataTable GetAllDESIGNATION_MASDetials(int USERCODE, int COMP_CODE)
        {
            return DESIGN_MASDataLayer.GetAllDESIGNATION_MASDetials(USERCODE, USERCODE);
        }


        public static DataTable GetAllIDWiseDESIGNATION_MASDetails(string DesignCode)
        {
            return DESIGN_MASDataLayer.GetAllIDWiseDESIGNATION_MASDetails(DesignCode);
        }


        public static string DeleteDESIGNTAION_MASDetaislByID(string DESIGN_CODE)
        {
            return DESIGN_MASDataLayer.DeleteDESIGNTAION_MASDetaislByID(DESIGN_CODE);
        }

        public static DataTable GetAllDESIGNATION_MASDetialsForEmp()
        {
            return DESIGN_MASDataLayer.GetAllDESIGNATION_MASDetialsForEmp();
        }

    }



    public class CATAGORY_MASLogicLayer

    {

        string _CAT_CODE, _CAT_NAME, _ORD_NO, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE;

        public CATAGORY_MASLogicLayer()
        {
            _CAT_CODE = "  ";
            _CAT_NAME = "  ";
            _ORD_NO = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";


        }
        public string CAT_CODE { get { return _CAT_CODE; } set { _CAT_CODE = value; } }
        public string CAT_NAME { get { return _CAT_NAME; } set { _CAT_NAME = value; } }
        public string ORD_NO { get { return _ORD_NO; } set { _ORD_NO = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


        public static string InsertEmployeeCategory_MAS(CATAGORY_MASLogicLayer CATEGORY_MASDetails)
        {
            return CATAGORY_MASDataLayer.InsertEmployeeCategory_MAS(CATEGORY_MASDetails);
        }

        public static string UpdateEmployeeCategory_MASDetails(CATAGORY_MASLogicLayer CATEGORY_MASDetails)
        {
            return CATAGORY_MASDataLayer.UpdateEmployeeCategory_MASDetails(CATEGORY_MASDetails);
        }

        public static DataTable GetAllEmployeeCategory_MASDetials(int USERCODE, int COMP_CODE)
        {
            return CATAGORY_MASDataLayer.GetAllEmployeeCategory_MASDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllIDWiseEmployeeCategory_MASDetails(string CategoryCode)
        {
            return CATAGORY_MASDataLayer.GetAllIDWiseEmployeeCategory_MASDetails(CategoryCode);
        }

        public static string DeleteEmployeeCategory_MASDetialByID(string CATEGORY_CODE)
        {
            return CATAGORY_MASDataLayer.DeleteEmployeeCategory_MASDetialByID(CATEGORY_CODE);
        }

        public static DataTable GetAllEmployeeCATEGORY_MASForEmp()
        {
            return CATAGORY_MASDataLayer.GetAllEmployeeCATEGORY_MASForEmp();
        }

    }



    public class EMP_MASLogicLayer

    {

        string _COMP_CODE, _EMP_CODE, _EMP_NAME, _EMP_ADD1, _EMP_ADD2, _EMP_ADD3, _EMP_ADD4, _EMP_PHONE_R, _EMP_PHONE_M, _JOIN_DATE, _LEFT_DATE, _PF_FLAG, _PF_NO, _ESIC_FLAG, _ESIC_NO, _PAN_NO, _CAT_CODE, _SAL_FLAG, _BASIC_RATE, _CONV_RATE, _MEDICAL_RATE, _HRA_RATE, _BASIC_RATE1, _CONV_RATE1, _MEDICAL_RATE1, _HRA_RATE1, _ACTIVE, _ENDT, _OT_FLAG, _BRANCH_CODE, _CRACODE1, _DRACODE1, _EMP_REFNAME, _EMP_REFPHONE, _PER_ADD1, _PER_ADD2, _PER_ADD3, _PER_ADD4, _PER_PHONE_R, _PER_PHONE_M, _PER_REFNAME, _PER_REFPHONE, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE, _ADHAR_NO, _DESIGN_CODE, _REF_EMPCODE, _DOB_DATE, _HOME_LATITUDE, _HOME_LONGITUDE;

        public EMP_MASLogicLayer()
        {
            _COMP_CODE = "  ";
            _EMP_CODE = "  ";
            _EMP_NAME = "  ";
            _EMP_ADD1 = "  ";
            _EMP_ADD2 = "  ";
            _EMP_ADD3 = "  ";
            _EMP_ADD4 = "  ";
            _EMP_PHONE_R = "  ";
            _EMP_PHONE_M = "  ";
            _JOIN_DATE = "  ";
            _LEFT_DATE = "  ";
            _PF_FLAG = "  ";
            _PF_NO = "  ";
            _ESIC_FLAG = "  ";
            _ESIC_NO = "  ";
            _PAN_NO = "  ";
            _CAT_CODE = "  ";
            _SAL_FLAG = "  ";
            _BASIC_RATE = "  ";
            _CONV_RATE = "  ";
            _MEDICAL_RATE = "  ";
            _HRA_RATE = "  ";
            _BASIC_RATE1 = "  ";
            _CONV_RATE1 = "  ";
            _MEDICAL_RATE1 = "  ";
            _HRA_RATE1 = "  ";
            _ACTIVE = "  ";
            _ENDT = "  ";
            _OT_FLAG = "  ";
            _BRANCH_CODE = "  ";
            _CRACODE1 = "  ";
            _DRACODE1 = "  ";
            _EMP_REFNAME = "  ";
            _EMP_REFPHONE = "  ";
            _PER_ADD1 = "  ";
            _PER_ADD2 = "  ";
            _PER_ADD3 = "  ";
            _PER_ADD4 = "  ";
            _PER_PHONE_R = "  ";
            _PER_PHONE_M = "  ";
            _PER_REFNAME = "  ";
            _PER_REFPHONE = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";
            _ADHAR_NO = "  ";
            _DESIGN_CODE = "  ";
            _REF_EMPCODE = "  ";
            _DOB_DATE = "  ";
            _HOME_LATITUDE = "  ";
            _HOME_LONGITUDE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string EMP_CODE { get { return _EMP_CODE; } set { _EMP_CODE = value; } }
        public string EMP_NAME { get { return _EMP_NAME; } set { _EMP_NAME = value; } }
        public string EMP_ADD1 { get { return _EMP_ADD1; } set { _EMP_ADD1 = value; } }
        public string EMP_ADD2 { get { return _EMP_ADD2; } set { _EMP_ADD2 = value; } }
        public string EMP_ADD3 { get { return _EMP_ADD3; } set { _EMP_ADD3 = value; } }
        public string EMP_ADD4 { get { return _EMP_ADD4; } set { _EMP_ADD4 = value; } }
        public string EMP_PHONE_R { get { return _EMP_PHONE_R; } set { _EMP_PHONE_R = value; } }
        public string EMP_PHONE_M { get { return _EMP_PHONE_M; } set { _EMP_PHONE_M = value; } }
        public string JOIN_DATE { get { return _JOIN_DATE; } set { _JOIN_DATE = value; } }
        public string LEFT_DATE { get { return _LEFT_DATE; } set { _LEFT_DATE = value; } }
        public string PF_FLAG { get { return _PF_FLAG; } set { _PF_FLAG = value; } }
        public string PF_NO { get { return _PF_NO; } set { _PF_NO = value; } }
        public string ESIC_FLAG { get { return _ESIC_FLAG; } set { _ESIC_FLAG = value; } }
        public string ESIC_NO { get { return _ESIC_NO; } set { _ESIC_NO = value; } }
        public string PAN_NO { get { return _PAN_NO; } set { _PAN_NO = value; } }
        public string CAT_CODE { get { return _CAT_CODE; } set { _CAT_CODE = value; } }
        public string SAL_FLAG { get { return _SAL_FLAG; } set { _SAL_FLAG = value; } }
        public string BASIC_RATE { get { return _BASIC_RATE; } set { _BASIC_RATE = value; } }
        public string CONV_RATE { get { return _CONV_RATE; } set { _CONV_RATE = value; } }
        public string MEDICAL_RATE { get { return _MEDICAL_RATE; } set { _MEDICAL_RATE = value; } }
        public string HRA_RATE { get { return _HRA_RATE; } set { _HRA_RATE = value; } }
        public string BASIC_RATE1 { get { return _BASIC_RATE1; } set { _BASIC_RATE1 = value; } }
        public string CONV_RATE1 { get { return _CONV_RATE1; } set { _CONV_RATE1 = value; } }
        public string MEDICAL_RATE1 { get { return _MEDICAL_RATE1; } set { _MEDICAL_RATE1 = value; } }
        public string HRA_RATE1 { get { return _HRA_RATE1; } set { _HRA_RATE1 = value; } }
        public string ACTIVE { get { return _ACTIVE; } set { _ACTIVE = value; } }
        public string ENDT { get { return _ENDT; } set { _ENDT = value; } }
        public string OT_FLAG { get { return _OT_FLAG; } set { _OT_FLAG = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string CRACODE1 { get { return _CRACODE1; } set { _CRACODE1 = value; } }
        public string DRACODE1 { get { return _DRACODE1; } set { _DRACODE1 = value; } }
        public string EMP_REFNAME { get { return _EMP_REFNAME; } set { _EMP_REFNAME = value; } }
        public string EMP_REFPHONE { get { return _EMP_REFPHONE; } set { _EMP_REFPHONE = value; } }
        public string PER_ADD1 { get { return _PER_ADD1; } set { _PER_ADD1 = value; } }
        public string PER_ADD2 { get { return _PER_ADD2; } set { _PER_ADD2 = value; } }
        public string PER_ADD3 { get { return _PER_ADD3; } set { _PER_ADD3 = value; } }
        public string PER_ADD4 { get { return _PER_ADD4; } set { _PER_ADD4 = value; } }
        public string PER_PHONE_R { get { return _PER_PHONE_R; } set { _PER_PHONE_R = value; } }
        public string PER_PHONE_M { get { return _PER_PHONE_M; } set { _PER_PHONE_M = value; } }
        public string PER_REFNAME { get { return _PER_REFNAME; } set { _PER_REFNAME = value; } }
        public string PER_REFPHONE { get { return _PER_REFPHONE; } set { _PER_REFPHONE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string ADHAR_NO { get { return _ADHAR_NO; } set { _ADHAR_NO = value; } }
        public string DESIGN_CODE { get { return _DESIGN_CODE; } set { _DESIGN_CODE = value; } }
        public string REF_EMPCODE { get { return _REF_EMPCODE; } set { _REF_EMPCODE = value; } }
        public string DOB_DATE { get { return _DOB_DATE; } set { _DOB_DATE = value; } }
        public string HOME_LATITUDE { get { return _HOME_LATITUDE; } set { _HOME_LATITUDE = value; } }
        public string HOME_LONGITUDE { get { return _HOME_LONGITUDE; } set { _HOME_LONGITUDE = value; } }



        public static string InsertEMPLOYEE_MASDetails(EMP_MASLogicLayer EMPLOYEE_MASDetails)
        {
            return EMP_MASDataLayer.InsertEMPLOYEE_MASDetails(EMPLOYEE_MASDetails);
        }

        public static string UpdateEMPLOYEE_MASDetails(EMP_MASLogicLayer EMPLOYEE_MASDetails)
        {
            return EMP_MASDataLayer.UpdateEMPLOYEE_MASDetails(EMPLOYEE_MASDetails);
        }

        public static string DeleteEMPLOYEE_MASDetaislByID(string EMPLOYEE_CODE)
        {
            return EMP_MASDataLayer.DeleteEMPLOYEE_MASDetaislByID(EMPLOYEE_CODE);
        }

        public static DataTable GetAllIDWiseEMPLOYEE_MASDetails(string EMP_CODE)
        {
            return EMP_MASDataLayer.GetAllIDWiseEMPLOYEE_MASDetails(EMP_CODE);
        }

        public static DataTable GetAllEMPLOYEE_MASDetials(int USERCODE, int COMP_CODE)
        {
            return EMP_MASDataLayer.GetAllEMPLOYEE_MASDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllEmployeeSalDetailsForAttenMas(string COMP_CODE, DateTime ATTN_DATE)
        {
            return EMP_MASDataLayer.GetAllEmployeeSalDetailsForAttenMas(COMP_CODE, ATTN_DATE);
        }

        public static DataTable GetAllEmployeeDetailsOnBranch(string COMP_CODE, string BRANCH_CODE)
        {
            return EMP_MASDataLayer.GetAllEmployeeDetailsOnBranch(COMP_CODE, BRANCH_CODE);
        }

        public static DataTable GetAllEmployeeDetailsByCompany(string COMP_CODE)
        {
            return EMP_MASDataLayer.GetAllEmployeeDetailsByCompany(COMP_CODE);
        }

    }



    public class INCREMENT_MASLogicLayer

    {

        string _COMP_CODE, _YRDT1, _YRDT2, _ACTIVE, _REMARK, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE;

        public INCREMENT_MASLogicLayer()
        {
            _COMP_CODE = "  ";
            _YRDT1 = "  ";
            _YRDT2 = "  ";
            _ACTIVE = "  ";
            _REMARK = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";

        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string YRDT1 { get { return _YRDT1; } set { _YRDT1 = value; } }
        public string YRDT2 { get { return _YRDT2; } set { _YRDT2 = value; } }
        public string ACTIVE { get { return _ACTIVE; } set { _ACTIVE = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }

        public static string InsertINCREMENT_TRAN_MASDetail(INCREMENT_MASLogicLayer INCREMENT_MASDetails)
        {
            return INCREMENT_MASDataLayer.InsertINCREMENT_TRAN_MASDetail(INCREMENT_MASDetails);
        }

        public static string UpdateINCREMENT_TRAN_MASDetail(INCREMENT_MASLogicLayer INCREMENT_MASDetails, string INCREMENT_TRAN_Details)
        {
            return INCREMENT_MASDataLayer.UpdateINCREMENT_TRAN_MASDetail(INCREMENT_MASDetails, INCREMENT_TRAN_Details);
        }

        public static DataTable GetAllINCREMENT_MASDetials(int USERCODE, int COMP_CODE)
        {
            return INCREMENT_MASDataLayer.GetAllINCREMENT_MASDetials(USERCODE, COMP_CODE);
        }

        public static string DeleteINCREMENT_TRAN_MASDetaislByID(string COMP_CODE, string YRDT1)
        {
            return INCREMENT_MASDataLayer.DeleteINCREMENT_TRAN_MASDetaislByID(COMP_CODE, YRDT1);
        }

        public static DataSet GetAllIDWiseINCREMENT_MASDetails(string COMP_CODE, string YRDT1)
        {
            return INCREMENT_MASDataLayer.GetAllIDWiseINCREMENT_MASDetails(COMP_CODE, YRDT1);
        }

        public static DataSet GetAllIDWiseINCREMENT_MAS_TRANSACTION_Details(string COMP_CODE, string YRDT1)
        {
            return INCREMENT_MASDataLayer.GetAllIDWiseINCREMENT_MAS_TRANSACTION_Details(COMP_CODE, YRDT1);
        }

        public static DataTable GetAllEMPLOYEE_INCREMENT_TRANDetailsByEmp_Code(string COMP_CODE, string EMP_CODE)
        {
            return INCREMENT_MASDataLayer.GetAllEMPLOYEE_INCREMENT_TRANDetailsByEmp_Code(COMP_CODE, EMP_CODE);
        }

    }


    public class INCREMENT_TRANLogicLayer

    {

        string _COMP_CODE, _YRDT1, _EMP_CODE, _BASIC_RATE, _CONV_RATE, _MEDICAL_RATE, _HRA_RATE, _OLD_BASIC_RATE, _OLD_CONV_RATE, _OLD_MEDICAL_RATE, _OLD_HRA_RATE, _REMARK, _INS_USERID, _INS_DATE, _UPD_USERID, _UPD_DATE;

        public INCREMENT_TRANLogicLayer()
        {
            _COMP_CODE = "  ";
            _YRDT1 = "  ";
            _EMP_CODE = "  ";
            _BASIC_RATE = "  ";
            _CONV_RATE = "  ";
            _MEDICAL_RATE = "  ";
            _HRA_RATE = "  ";
            _OLD_BASIC_RATE = "  ";
            _OLD_CONV_RATE = "  ";
            _OLD_MEDICAL_RATE = "  ";
            _OLD_HRA_RATE = "  ";
            _REMARK = "  ";
            _INS_USERID = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_DATE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string YRDT1 { get { return _YRDT1; } set { _YRDT1 = value; } }
        public string EMP_CODE { get { return _EMP_CODE; } set { _EMP_CODE = value; } }
        public string BASIC_RATE { get { return _BASIC_RATE; } set { _BASIC_RATE = value; } }
        public string CONV_RATE { get { return _CONV_RATE; } set { _CONV_RATE = value; } }
        public string MEDICAL_RATE { get { return _MEDICAL_RATE; } set { _MEDICAL_RATE = value; } }
        public string HRA_RATE { get { return _HRA_RATE; } set { _HRA_RATE = value; } }
        public string OLD_BASIC_RATE { get { return _OLD_BASIC_RATE; } set { _OLD_BASIC_RATE = value; } }
        public string OLD_CONV_RATE { get { return _OLD_CONV_RATE; } set { _OLD_CONV_RATE = value; } }
        public string OLD_MEDICAL_RATE { get { return _OLD_MEDICAL_RATE; } set { _OLD_MEDICAL_RATE = value; } }
        public string OLD_HRA_RATE { get { return _OLD_HRA_RATE; } set { _OLD_HRA_RATE = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }


    }



    public class ATTN_MASLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _ATTN_DATE, _HOLIDAY, _REMARK, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE, _CONF_FLAG, _CONF_DATE, _CONF_USERID;

        public ATTN_MASLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _ATTN_DATE = "  ";
            _HOLIDAY = "  ";
            _REMARK = "  ";
            _INS_USERID = "  ";
            _INS_TERMINAL = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_TERMINAL = "  ";
            _UPD_DATE = "  ";
            _CONF_FLAG = "  ";
            _CONF_DATE = "  ";
            _CONF_USERID = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string ATTN_DATE { get { return _ATTN_DATE; } set { _ATTN_DATE = value; } }
        public string HOLIDAY { get { return _HOLIDAY; } set { _HOLIDAY = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string CONF_FLAG { get { return _CONF_FLAG; } set { _CONF_FLAG = value; } }
        public string CONF_DATE { get { return _CONF_DATE; } set { _CONF_DATE = value; } }
        public string CONF_USERID { get { return _CONF_USERID; } set { _CONF_USERID = value; } }

        public static string InsertATTENDANCE_MASDetail(ATTN_MASLogicLayer ATTN_MASDetails, string ATTN_TRAN_Details)
        {
            return ATTN_MASDataLayer.InsertATTENDANCE_MASDetail(ATTN_MASDetails, ATTN_TRAN_Details);
        }

        public static string UpdateATTENDANCE_MASDetail(ATTN_MASLogicLayer ATTN_MASDetails, string ATTN_TRAN_Details)
        {
            return ATTN_MASDataLayer.UpdateATTENDANCE_MASDetail(ATTN_MASDetails, ATTN_TRAN_Details);
        }

        public static string DeleteATTENDANCE_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {
            return ATTN_MASDataLayer.DeleteATTENDANCE_MASDetailsByID(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetAllATTENDANCE_MASDetials(int USERCODE, int COMP_CODE)
        {
            return ATTN_MASDataLayer.GetAllATTENDANCE_MASDetials(USERCODE, COMP_CODE);
        }

        public static DataSet GetAllIDWiseATTENDANCE_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return ATTN_MASDataLayer.GetAllIDWiseATTENDANCE_MASDetials(TRAN_NO, TRAN_DATE);
        }

    }


    public class ATTN_TRANLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _EMP_CODE, _ATTN_FLAG, _PAY_AMT, _OT_HOURS, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE;

        public ATTN_TRANLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _EMP_CODE = "  ";
            _ATTN_FLAG = "  ";
            _PAY_AMT = "  ";
            _OT_HOURS = "  ";
            _INS_USERID = "  ";
            _INS_TERMINAL = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_TERMINAL = "  ";
            _UPD_DATE = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string EMP_CODE { get { return _EMP_CODE; } set { _EMP_CODE = value; } }
        public string ATTN_FLAG { get { return _ATTN_FLAG; } set { _ATTN_FLAG = value; } }
        public string PAY_AMT { get { return _PAY_AMT; } set { _PAY_AMT = value; } }
        public string OT_HOURS { get { return _OT_HOURS; } set { _OT_HOURS = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }




    }



    public class GENERAL_MASLogicLayer

    {

        string _COMP_CODE, _TRAN_TYPE, _TRAN_NO, _FRDT, _TODT, _WRK_HOURS, _CAL_HOURS, _CAL_RATE1, _CAL_RATE2;

        public GENERAL_MASLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_TYPE = "  ";
            _TRAN_NO = "  ";
            _FRDT = "  ";
            _TODT = "  ";
            _WRK_HOURS = "  ";
            _CAL_HOURS = "  ";
            _CAL_RATE1 = "  ";
            _CAL_RATE2 = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_TYPE { get { return _TRAN_TYPE; } set { _TRAN_TYPE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string FRDT { get { return _FRDT; } set { _FRDT = value; } }
        public string TODT { get { return _TODT; } set { _TODT = value; } }
        public string WRK_HOURS { get { return _WRK_HOURS; } set { _WRK_HOURS = value; } }
        public string CAL_HOURS { get { return _CAL_HOURS; } set { _CAL_HOURS = value; } }
        public string CAL_RATE1 { get { return _CAL_RATE1; } set { _CAL_RATE1 = value; } }
        public string CAL_RATE2 { get { return _CAL_RATE2; } set { _CAL_RATE2 = value; } }


        public static string InsertGENERAL_MASDetails(GENERAL_MASLogicLayer GENERAL_MASDetails, string COMP_CODE, string TRAN_TYPE)
        {
            return GENERAL_MASDataLayer.InsertGENERAL_MASDetails(GENERAL_MASDetails, COMP_CODE, TRAN_TYPE);
        }

        public static string UpdateGENERAL_MASDetails(GENERAL_MASLogicLayer GENERAL_MASDetails, string COMP_CODE, string TRAN_TYPE)
        {
            return GENERAL_MASDataLayer.UpdateGENERAL_MASDetails(GENERAL_MASDetails, COMP_CODE, TRAN_TYPE);
        }

        public static string DeleteGENERAL_MASDetaislByID(string COMP_CODE, string TRAN_NO, string TRAN_TYPE)
        {
            return GENERAL_MASDataLayer.DeleteGENERAL_MASDetaislByID(COMP_CODE, TRAN_NO, TRAN_TYPE);
        }

        public static DataTable GetAllGENERAL_MASDetials(int USERCODE, int COMP_CODE)
        {
            return GENERAL_MASDataLayer.GetAllGENERAL_MASDetials(USERCODE, COMP_CODE);
        }

        public static DataTable GetAllIDWiseGENERAL_MASDetials(string COMP_CODE, string TRAN_NO, string TRAN_TYPE)
        {
            return GENERAL_MASDataLayer.GetAllIDWiseGENERAL_MASDetials(COMP_CODE, TRAN_NO, TRAN_TYPE);
        }
    }

    public class LOAN_MASLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _LOAN_TYPE, _LOAN_DATE, _EMP_CODE, _FRDT, _TODT, _LOAN_AMT, _PAID_AMT, _INSTALL_AMT, _REMARK, _STATUS, _INSTALL_MONTHS;

        public LOAN_MASLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _LOAN_TYPE = "  ";
            _LOAN_DATE = "  ";
            _EMP_CODE = "  ";
            _FRDT = "  ";
            _TODT = "  ";
            _LOAN_AMT = "  ";
            _PAID_AMT = "  ";
            _INSTALL_AMT = "  ";
            _REMARK = "  ";
            _STATUS = "  ";
            _INSTALL_MONTHS = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string LOAN_TYPE { get { return _LOAN_TYPE; } set { _LOAN_TYPE = value; } }
        public string LOAN_DATE { get { return _LOAN_DATE; } set { _LOAN_DATE = value; } }
        public string EMP_CODE { get { return _EMP_CODE; } set { _EMP_CODE = value; } }
        public string FRDT { get { return _FRDT; } set { _FRDT = value; } }
        public string TODT { get { return _TODT; } set { _TODT = value; } }
        public string LOAN_AMT { get { return _LOAN_AMT; } set { _LOAN_AMT = value; } }
        public string PAID_AMT { get { return _PAID_AMT; } set { _PAID_AMT = value; } }
        public string INSTALL_AMT { get { return _INSTALL_AMT; } set { _INSTALL_AMT = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
        public string INSTALL_MONTHS { get { return _INSTALL_MONTHS; } set { _INSTALL_MONTHS = value; } }

        public static string InsertLOAN_MASDetail(LOAN_MASLogicLayer LOAN_MASDetails)
        {
            return LOAN_MASDataLayer.InsertLOAN_MASDetail(LOAN_MASDetails);
        }

        public static string UpdateLOAN_MASDetail(LOAN_MASLogicLayer LOAN_MASDetails)
        {
            return LOAN_MASDataLayer.UpdateLOAN_MASDetail(LOAN_MASDetails);
        }

        public static string DeleteLOAN_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {
            return LOAN_MASDataLayer.DeleteLOAN_MASDetailsByID(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetAllIDWiseLOAN_MASTERDetials(string TRAN_NO, DateTime TRAN_DATE, string LOAN_TYPE)
        {
            return LOAN_MASDataLayer.GetAllIDWiseLOAN_MASTERDetials(TRAN_NO, TRAN_DATE, LOAN_TYPE);
        }

        public static DataTable GetAllLOAN_MASTERDetail(int USERCODE, int COMP_CODE, string LOAN_TYPE)
        {
            return LOAN_MASDataLayer.GetAllLOAN_MASTERDetail(USERCODE, COMP_CODE, LOAN_TYPE);
        }

        public static DataTable GetAllLOAN_MASTERDetailForSAL_PAIDGrid(string COMP_CODE, string EMP_CODE, string LOAN_TYPE)
        {
            return LOAN_MASDataLayer.GetAllLOAN_MASTERDetailForSAL_PAIDGrid(COMP_CODE, EMP_CODE, LOAN_TYPE);
        }


    }



    public class SAL_MASLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _SAL_DATE, _SAL_MONTH, _WRK_DAYS, _WRK_HOURS, _OT_HOURS, _OT_RATE, _ALLOW_HOURS, _ALLOW_RATE, _PF_RATE, _FPF_RATE, _REMARK, _ESIC_RATE_EMP, _ESIC_RATE_COMP, _BRANCH_CODE, _INS_USERID, _INS_TERMINAL, _INS_DATE, _UPD_USERID, _UPD_TERMINAL, _UPD_DATE, _CONF_FLAG, _CONF_DATE, _CONF_USERID, _CHK_FLAG, _CHK_DATE, _CHK_USERID;

        public SAL_MASLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _SAL_DATE = "  ";
            _SAL_MONTH = "  ";
            _WRK_DAYS = "  ";
            _WRK_HOURS = "  ";
            _OT_HOURS = "  ";
            _OT_RATE = "  ";
            _ALLOW_HOURS = "  ";
            _ALLOW_RATE = "  ";
            _PF_RATE = "  ";
            _FPF_RATE = "  ";
            _REMARK = "  ";
            _ESIC_RATE_EMP = "  ";
            _ESIC_RATE_COMP = "  ";
            _BRANCH_CODE = "  ";
            _INS_USERID = "  ";
            _INS_TERMINAL = "  ";
            _INS_DATE = "  ";
            _UPD_USERID = "  ";
            _UPD_TERMINAL = "  ";
            _UPD_DATE = "  ";
            _CONF_FLAG = "  ";
            _CONF_DATE = "  ";
            _CONF_USERID = "  ";
            _CHK_FLAG = "  ";
            _CHK_DATE = "  ";
            _CHK_USERID = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string SAL_DATE { get { return _SAL_DATE; } set { _SAL_DATE = value; } }
        public string SAL_MONTH { get { return _SAL_MONTH; } set { _SAL_MONTH = value; } }
        public string WRK_DAYS { get { return _WRK_DAYS; } set { _WRK_DAYS = value; } }
        public string WRK_HOURS { get { return _WRK_HOURS; } set { _WRK_HOURS = value; } }
        public string OT_HOURS { get { return _OT_HOURS; } set { _OT_HOURS = value; } }
        public string OT_RATE { get { return _OT_RATE; } set { _OT_RATE = value; } }
        public string ALLOW_HOURS { get { return _ALLOW_HOURS; } set { _ALLOW_HOURS = value; } }
        public string ALLOW_RATE { get { return _ALLOW_RATE; } set { _ALLOW_RATE = value; } }
        public string PF_RATE { get { return _PF_RATE; } set { _PF_RATE = value; } }
        public string FPF_RATE { get { return _FPF_RATE; } set { _FPF_RATE = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }
        public string ESIC_RATE_EMP { get { return _ESIC_RATE_EMP; } set { _ESIC_RATE_EMP = value; } }
        public string ESIC_RATE_COMP { get { return _ESIC_RATE_COMP; } set { _ESIC_RATE_COMP = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string INS_USERID { get { return _INS_USERID; } set { _INS_USERID = value; } }
        public string INS_TERMINAL { get { return _INS_TERMINAL; } set { _INS_TERMINAL = value; } }
        public string INS_DATE { get { return _INS_DATE; } set { _INS_DATE = value; } }
        public string UPD_USERID { get { return _UPD_USERID; } set { _UPD_USERID = value; } }
        public string UPD_TERMINAL { get { return _UPD_TERMINAL; } set { _UPD_TERMINAL = value; } }
        public string UPD_DATE { get { return _UPD_DATE; } set { _UPD_DATE = value; } }
        public string CONF_FLAG { get { return _CONF_FLAG; } set { _CONF_FLAG = value; } }
        public string CONF_DATE { get { return _CONF_DATE; } set { _CONF_DATE = value; } }
        public string CONF_USERID { get { return _CONF_USERID; } set { _CONF_USERID = value; } }
        public string CHK_FLAG { get { return _CHK_FLAG; } set { _CHK_FLAG = value; } }
        public string CHK_DATE { get { return _CHK_DATE; } set { _CHK_DATE = value; } }
        public string CHK_USERID { get { return _CHK_USERID; } set { _CHK_USERID = value; } }

        public static string InsertSALARY_TransactionDetail(SAL_MASLogicLayer SAL_MAS_Details, string SAL_TRAN_Details, string SAL_TRAN_PAID_Details)
        {
            return SAL_MASDataLayer.InsertSALARY_TransactionDetail(SAL_MAS_Details, SAL_TRAN_Details, SAL_TRAN_PAID_Details);
        }

        public static string UpdateSALARY_TrasactionDetail(SAL_MASLogicLayer SAL_MAS_Details, string SAL_TRAN_Details, string SAL_TRAN_PAID_Details)
        {
            return SAL_MASDataLayer.UpdateSALARY_TrasactionDetail(SAL_MAS_Details, SAL_TRAN_Details, SAL_TRAN_PAID_Details);
        }

        public static string DeleteSALARY_TransactionDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {
            return SAL_MASDataLayer.DeleteSALARY_TransactionDetailsByID(TRAN_NO, TRAN_DATE);
        }

        public static DataSet GetAllIDWiseSALARY_TransactionDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            return SAL_MASDataLayer.GetAllIDWiseSALARY_TransactionDetials(TRAN_NO, TRAN_DATE);
        }

        public static DataTable GetAllSALARY_TransactionDetails(int USERCODE, int COMP_CODE)
        {
            return SAL_MASDataLayer.GetAllSALARY_TransactionDetails(USERCODE, COMP_CODE);
        }

        public static DataSet GetAllSALARY_TRANDetialsByEMP_CODE(string TRAN_NO, DateTime TRAN_DATE, string EMP_CODE)
        {
            return SAL_MASDataLayer.GetAllSALARY_TRANDetialsByEMP_CODE(TRAN_NO, TRAN_DATE, EMP_CODE);
        }

    }



    public class SAL_TRANLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _EMP_CODE, _TOT_DAY, _TOT_HOURS, _OT_HOURS, _OD_HOURS, _ALLOW_DAYS, _BASIC_RATE, _BASIC_AMT, _CONV_RATE, _CONV_AMT, _OT_AMT, _OD_AMT, _MEDICAL_RATE, _MEDICAL_AMT, _HRA_RATE, _HRA_AMT, _ALLOW_AMT, _GROSS_AMT, _PF_AMT, _FPF_AMT, _ESIC_AMT_EMP, _ESIC_AMT_COMP, _IT_AMT, _LOAN_AMT, _ADVANCE_AMT, _TOT_LESS_AMT, _NET_AMT, _PAY_AMT, _BASIC_RATE1, _BASIC_AMT1, _CONV_RATE1, _CONV_AMT1, _OT_AMT1, _OD_AMT1, _MEDICAL_RATE1, _MEDICAL_AMT1, _HRA_RATE1, _HRA_AMT1, _ALLOW_AMT1, _GROSS_AMT1, _PF_AMT1, _FPF_AMT1, _ESIC_AMT1_EMP, _ESIC_AMT1_COMP, _IT_AMT1, _LOAN_AMT1, _ADVANCE_AMT1, _TOT_LESS_AMT1, _NET_AMT1, _PAY_AMT1;

        public SAL_TRANLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _EMP_CODE = "  ";
            _TOT_DAY = "  ";
            _TOT_HOURS = "  ";
            _OT_HOURS = "  ";
            _OD_HOURS = "  ";
            _ALLOW_DAYS = "  ";
            _BASIC_RATE = "  ";
            _BASIC_AMT = "  ";
            _CONV_RATE = "  ";
            _CONV_AMT = "  ";
            _OT_AMT = "  ";
            _OD_AMT = "  ";
            _MEDICAL_RATE = "  ";
            _MEDICAL_AMT = "  ";
            _HRA_RATE = "  ";
            _HRA_AMT = "  ";
            _ALLOW_AMT = "  ";
            _GROSS_AMT = "  ";
            _PF_AMT = "  ";
            _FPF_AMT = "  ";
            _ESIC_AMT_EMP = "  ";
            _ESIC_AMT_COMP = "  ";
            _IT_AMT = "  ";
            _LOAN_AMT = "  ";
            _ADVANCE_AMT = "  ";
            _TOT_LESS_AMT = "  ";
            _NET_AMT = "  ";
            _PAY_AMT = "  ";
            _BASIC_RATE1 = "  ";
            _BASIC_AMT1 = "  ";
            _CONV_RATE1 = "  ";
            _CONV_AMT1 = "  ";
            _OT_AMT1 = "  ";
            _OD_AMT1 = "  ";
            _MEDICAL_RATE1 = "  ";
            _MEDICAL_AMT1 = "  ";
            _HRA_RATE1 = "  ";
            _HRA_AMT1 = "  ";
            _ALLOW_AMT1 = "  ";
            _GROSS_AMT1 = "  ";
            _PF_AMT1 = "  ";
            _FPF_AMT1 = "  ";
            _ESIC_AMT1_EMP = "  ";
            _ESIC_AMT1_COMP = "  ";
            _IT_AMT1 = "  ";
            _LOAN_AMT1 = "  ";
            _ADVANCE_AMT1 = "  ";
            _TOT_LESS_AMT1 = "  ";
            _NET_AMT1 = "  ";
            _PAY_AMT1 = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string EMP_CODE { get { return _EMP_CODE; } set { _EMP_CODE = value; } }
        public string TOT_DAY { get { return _TOT_DAY; } set { _TOT_DAY = value; } }
        public string TOT_HOURS { get { return _TOT_HOURS; } set { _TOT_HOURS = value; } }
        public string OT_HOURS { get { return _OT_HOURS; } set { _OT_HOURS = value; } }
        public string OD_HOURS { get { return _OD_HOURS; } set { _OD_HOURS = value; } }
        public string ALLOW_DAYS { get { return _ALLOW_DAYS; } set { _ALLOW_DAYS = value; } }
        public string BASIC_RATE { get { return _BASIC_RATE; } set { _BASIC_RATE = value; } }
        public string BASIC_AMT { get { return _BASIC_AMT; } set { _BASIC_AMT = value; } }
        public string CONV_RATE { get { return _CONV_RATE; } set { _CONV_RATE = value; } }
        public string CONV_AMT { get { return _CONV_AMT; } set { _CONV_AMT = value; } }
        public string OT_AMT { get { return _OT_AMT; } set { _OT_AMT = value; } }
        public string OD_AMT { get { return _OD_AMT; } set { _OD_AMT = value; } }
        public string MEDICAL_RATE { get { return _MEDICAL_RATE; } set { _MEDICAL_RATE = value; } }
        public string MEDICAL_AMT { get { return _MEDICAL_AMT; } set { _MEDICAL_AMT = value; } }
        public string HRA_RATE { get { return _HRA_RATE; } set { _HRA_RATE = value; } }
        public string HRA_AMT { get { return _HRA_AMT; } set { _HRA_AMT = value; } }
        public string ALLOW_AMT { get { return _ALLOW_AMT; } set { _ALLOW_AMT = value; } }
        public string GROSS_AMT { get { return _GROSS_AMT; } set { _GROSS_AMT = value; } }
        public string PF_AMT { get { return _PF_AMT; } set { _PF_AMT = value; } }
        public string FPF_AMT { get { return _FPF_AMT; } set { _FPF_AMT = value; } }
        public string ESIC_AMT_EMP { get { return _ESIC_AMT_EMP; } set { _ESIC_AMT_EMP = value; } }
        public string ESIC_AMT_COMP { get { return _ESIC_AMT_COMP; } set { _ESIC_AMT_COMP = value; } }
        public string IT_AMT { get { return _IT_AMT; } set { _IT_AMT = value; } }
        public string LOAN_AMT { get { return _LOAN_AMT; } set { _LOAN_AMT = value; } }
        public string ADVANCE_AMT { get { return _ADVANCE_AMT; } set { _ADVANCE_AMT = value; } }
        public string TOT_LESS_AMT { get { return _TOT_LESS_AMT; } set { _TOT_LESS_AMT = value; } }
        public string NET_AMT { get { return _NET_AMT; } set { _NET_AMT = value; } }
        public string PAY_AMT { get { return _PAY_AMT; } set { _PAY_AMT = value; } }
        public string BASIC_RATE1 { get { return _BASIC_RATE1; } set { _BASIC_RATE1 = value; } }
        public string BASIC_AMT1 { get { return _BASIC_AMT1; } set { _BASIC_AMT1 = value; } }
        public string CONV_RATE1 { get { return _CONV_RATE1; } set { _CONV_RATE1 = value; } }
        public string CONV_AMT1 { get { return _CONV_AMT1; } set { _CONV_AMT1 = value; } }
        public string OT_AMT1 { get { return _OT_AMT1; } set { _OT_AMT1 = value; } }
        public string OD_AMT1 { get { return _OD_AMT1; } set { _OD_AMT1 = value; } }
        public string MEDICAL_RATE1 { get { return _MEDICAL_RATE1; } set { _MEDICAL_RATE1 = value; } }
        public string MEDICAL_AMT1 { get { return _MEDICAL_AMT1; } set { _MEDICAL_AMT1 = value; } }
        public string HRA_RATE1 { get { return _HRA_RATE1; } set { _HRA_RATE1 = value; } }
        public string HRA_AMT1 { get { return _HRA_AMT1; } set { _HRA_AMT1 = value; } }
        public string ALLOW_AMT1 { get { return _ALLOW_AMT1; } set { _ALLOW_AMT1 = value; } }
        public string GROSS_AMT1 { get { return _GROSS_AMT1; } set { _GROSS_AMT1 = value; } }
        public string PF_AMT1 { get { return _PF_AMT1; } set { _PF_AMT1 = value; } }
        public string FPF_AMT1 { get { return _FPF_AMT1; } set { _FPF_AMT1 = value; } }
        public string ESIC_AMT1_EMP { get { return _ESIC_AMT1_EMP; } set { _ESIC_AMT1_EMP = value; } }
        public string ESIC_AMT1_COMP { get { return _ESIC_AMT1_COMP; } set { _ESIC_AMT1_COMP = value; } }
        public string IT_AMT1 { get { return _IT_AMT1; } set { _IT_AMT1 = value; } }
        public string LOAN_AMT1 { get { return _LOAN_AMT1; } set { _LOAN_AMT1 = value; } }
        public string ADVANCE_AMT1 { get { return _ADVANCE_AMT1; } set { _ADVANCE_AMT1 = value; } }
        public string TOT_LESS_AMT1 { get { return _TOT_LESS_AMT1; } set { _TOT_LESS_AMT1 = value; } }
        public string NET_AMT1 { get { return _NET_AMT1; } set { _NET_AMT1 = value; } }
        public string PAY_AMT1 { get { return _PAY_AMT1; } set { _PAY_AMT1 = value; } }



    }



    public class SAL_TRAN_PAIDLogicLayer

    {

        string _COMP_CODE, _TRAN_DATE, _TRAN_NO, _EMP_CODE, _SRNO, _REF_TRAN_DATE, _REF_TRAN_NO, _REF_LOAN_TYPE, _PAID_AMT, _REMARK;

        public SAL_TRAN_PAIDLogicLayer()
        {
            _COMP_CODE = "  ";
            _TRAN_DATE = "  ";
            _TRAN_NO = "  ";
            _EMP_CODE = "  ";
            _SRNO = "  ";
            _REF_TRAN_DATE = "  ";
            _REF_TRAN_NO = "  ";
            _REF_LOAN_TYPE = "  ";
            _PAID_AMT = "  ";
            _REMARK = "  ";


        }
        public string COMP_CODE { get { return _COMP_CODE; } set { _COMP_CODE = value; } }
        public string TRAN_DATE { get { return _TRAN_DATE; } set { _TRAN_DATE = value; } }
        public string TRAN_NO { get { return _TRAN_NO; } set { _TRAN_NO = value; } }
        public string EMP_CODE { get { return _EMP_CODE; } set { _EMP_CODE = value; } }
        public string SRNO { get { return _SRNO; } set { _SRNO = value; } }
        public string REF_TRAN_DATE { get { return _REF_TRAN_DATE; } set { _REF_TRAN_DATE = value; } }
        public string REF_TRAN_NO { get { return _REF_TRAN_NO; } set { _REF_TRAN_NO = value; } }
        public string REF_LOAN_TYPE { get { return _REF_LOAN_TYPE; } set { _REF_LOAN_TYPE = value; } }
        public string PAID_AMT { get { return _PAID_AMT; } set { _PAID_AMT = value; } }
        public string REMARK { get { return _REMARK; } set { _REMARK = value; } }





    }

    public class AccountReport_Logiclayer
    {
        public static DataSet GetCashBankPaymentReceiptVoucherReport(string TRAN_NO, DateTime TRAN_DATE, string COMP_CODE)
        {
            return AccountReport_Datalayer.GetCashBankPaymentReceiptVoucherReport(TRAN_NO, TRAN_DATE, COMP_CODE);
        }



        public static DataSet GetCreditDebitNoteDataForReport(string COMP_CODE, DateTime TRAN_DATE, string TRAN_NO)
        {
            return AccountReport_Datalayer.GetCreditDebitNoteDataForReport(COMP_CODE, TRAN_DATE, TRAN_NO);
        }


        public static DataSet GetJournalVoucherDataForReport(string COMP_CODE, DateTime TRAN_DATE, string TRAN_NO)
        {
            return AccountReport_Datalayer.GetJournalVoucherDataForReport(COMP_CODE, TRAN_DATE, TRAN_NO);
        }


        public static DataSet GetBankReceiptDetailsForChequeReport(string COMP_CODE, DateTime TRAN_DATE, string TRAN_NO, string ACODE)
        {
            return AccountReport_Datalayer.GetBankReceiptDetailsForChequeReport(COMP_CODE, TRAN_DATE, TRAN_NO,ACODE);
        }


        public static DataSet GetBankReconciliationDataForReport(string COMP_CODE, string ACODE)
        {
            return AccountReport_Datalayer.GetBankReconciliationDataForReport(COMP_CODE, ACODE);
        }

        public static DataSet GetBankReconciliationDataForReport2()
        {
            return AccountReport_Datalayer.GetBankReconciliationDataForReport2();
        }

        public static DataSet GetPaymentReceiptDataForBillReport(string COMP_CODE, DateTime TRAN_DATE, string TRAN_NO)
        {
            return AccountReport_Datalayer.GetPaymentReceiptDataForBillReport(COMP_CODE, TRAN_DATE, TRAN_NO);
        }

        public static DataSet GetOutStnadingDataOnPartyNameForReport(string COMP_CODE, string BRANCH_CODE, string TRAN_TYPE, DateTime TRAN_DATE, string TRAN_NO, DateTime YRDT1, DateTime YRDT2)
        {
            return AccountReport_Datalayer.GetOutStnadingDataOnPartyNameForReport(COMP_CODE,BRANCH_CODE,TRAN_TYPE,TRAN_DATE,TRAN_NO,YRDT1,YRDT2);
        }

        public static DataSet GetAccountsLedgerDeatilsOnPartyNameForReport(string COMP_CODE, string BRANCH_CODE, string GROPU_CODE, string ACODE, DateTime YRDT1, DateTime YRDT2, DateTime FROM_DATE, DateTime TO_DATE)
        {
            return AccountReport_Datalayer.GetAccountsLedgerDeatilsOnPartyNameForReport(COMP_CODE, BRANCH_CODE, GROPU_CODE, ACODE, YRDT1, YRDT2, FROM_DATE, TO_DATE);
        }

        public static DataSet GetACCOUNTS_OpenningBalanceForReport(string COMP_CODE, DateTime YRDT1)
        {
            return AccountReport_Datalayer.GetACCOUNTS_OpenningBalanceForReport(COMP_CODE, YRDT1);
        }

        public static DataTable GetACCOUNTS_TradingAndProfitMainDetailsForReport(string p_comp_code, string p_atype, DateTime p_ondt, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            return AccountReport_Datalayer.GetACCOUNTS_TradingAndProfitMainDetailsForReport(p_comp_code, p_atype, p_ondt, p_yrdt1, p_yrdt2);
        }

        public static DataSet GetACCOUNTS_TradingAndProfitMainDetailsForReport_MHL(string p_comp_code, string p_atype, DateTime p_ondt, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            return AccountReport_Datalayer.GetACCOUNTS_TradingAndProfitMainDetailsForReport_MHL(p_comp_code, p_atype, p_ondt, p_yrdt1, p_yrdt2);
        }
            public static DataSet GetACCOUNTS_TradingDetailsForReport(string p_comp_code, string p_atype, DateTime p_ondt, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            return AccountReport_Datalayer.GetACCOUNTS_TradingDetailsForReport(p_comp_code, p_atype, p_ondt, p_yrdt1, p_yrdt2);
        }

        public static DataSet GetACCOUNTS_ProfitAndLossStatementForReport(string p_comp_code, string p_atype, DateTime p_ondt, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            return AccountReport_Datalayer.GetACCOUNTS_ProfitAndLossStatementForReport(p_comp_code, p_atype, p_ondt, p_yrdt1, p_yrdt2);
        }

        public static DataSet GetACCOUNTS_TrialBalanceForReport2(string p_comp_code, string p_group_code, DateTime p_ondt, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            return AccountReport_Datalayer.GetACCOUNTS_TrialBalanceForReport2(p_comp_code, p_group_code, p_ondt, p_yrdt1, p_yrdt2);
        }

        public static DataSet GetACCOUNTS_TrialBalanceForReport1(string p_comp_code, string p_atype, string p_group_code, DateTime p_frdt, DateTime p_todt, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            return AccountReport_Datalayer.GetACCOUNTS_TrialBalanceForReport1(p_comp_code, p_atype, p_group_code, p_frdt, p_todt, p_yrdt1, p_yrdt2);
        }

        public static DataSet GetACCOUNTS_BalanceSheetForReport(string p_comp_code, DateTime p_ondt, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            return AccountReport_Datalayer.GetACCOUNTS_BalanceSheetForReport(p_comp_code, p_ondt, p_yrdt1, p_yrdt2);
        }

        public static DataTable GetACCOUNTS_PartyWise_AgeingMainReport(string p_comp_code, string p_branch_code, DateTime p_ondt, string p_atype, DateTime p_yrdt1, DateTime p_yrdt2, string p_acode, string p_report)
        {
            return AccountReport_Datalayer.GetACCOUNTS_PartyWise_AgeingMainReport(p_comp_code, p_branch_code, p_ondt, p_atype, p_yrdt1, p_yrdt2, p_acode, p_report);
        }

        public static DataSet GetACCOUNTS_PartyWise_AgeingReport(string p_comp_code, string p_branch_code, DateTime p_ondt, string p_atype, DateTime p_yrdt1, DateTime p_yrdt2, string p_acode, string p_report)
        {
            return AccountReport_Datalayer.GetACCOUNTS_PartyWise_AgeingReport(p_comp_code, p_branch_code, p_ondt, p_atype, p_yrdt1, p_yrdt2, p_acode, p_report);
        }

        public static DataSet GetACCOUNTS_PartyWise_AgeingReport_PersonWise(string p_comp_code, string p_branch_code, DateTime p_ondt, string p_atype, DateTime p_yrdt1, DateTime p_yrdt2, string p_acode, string p_report, string BCODE)
        {
            return AccountReport_Datalayer.GetACCOUNTS_PartyWise_AgeingReport_PersonWise(p_comp_code, p_branch_code, p_ondt, p_atype, p_yrdt1, p_yrdt2, p_acode, p_report, BCODE);
        }

        public static DataSet GetACCOUNTS_PartyWise_AgeingReport_Summary(string p_comp_code, string p_branch_code, DateTime p_ondt, string p_atype, DateTime p_yrdt1, DateTime p_yrdt2, string p_acode, string p_report)
        {
            return AccountReport_Datalayer.GetACCOUNTS_PartyWise_AgeingReport_Summary(p_comp_code, p_branch_code, p_ondt, p_atype, p_yrdt1, p_yrdt2, p_acode, p_report);
        }

        public static DataSet GetACCOUNTS_PartyWise_AgeingReport_Summary_PersonWise(string p_comp_code, string p_branch_code, DateTime p_ondt, string p_atype, DateTime p_yrdt1, DateTime p_yrdt2, string p_acode, string p_report, string BCODE)
        {
            return AccountReport_Datalayer.GetACCOUNTS_PartyWise_AgeingReport_Summary_PersonWise(p_comp_code, p_branch_code, p_ondt, p_atype, p_yrdt1, p_yrdt2, p_acode, p_report, BCODE);
        }

        public static DataSet GetACCOUNTS_PartyWise_OutstadingReport(string p_comp_code, string p_branch_code, DateTime p_ondt, string p_atype, DateTime p_yrdt1, DateTime p_yrdt2, string p_acode, string p_report)
        {
            return AccountReport_Datalayer.GetACCOUNTS_PartyWise_OutstadingReport(p_comp_code, p_branch_code, p_ondt, p_atype, p_yrdt1, p_yrdt2, p_acode, p_report);
        }

        public static DataSet GetACCOUNTS_PartyWise_OutstadingReport_PersonWise(string p_comp_code, string p_branch_code, DateTime p_ondt, string p_atype, DateTime p_yrdt1, DateTime p_yrdt2, string p_acode, string p_report, string BCODE)
        {
            return AccountReport_Datalayer.GetACCOUNTS_PartyWise_OutstadingReport_PersonWise(p_comp_code, p_branch_code, p_ondt, p_atype, p_yrdt1, p_yrdt2, p_acode, p_report,BCODE);
        }


        public static DataSet GetACCOUNTS_CashBookStatementDetailsForReport(string COMP_CODE, string BRANCH_CODE, string GROPU_CODE, string ACODE, DateTime YRDT1, DateTime YRDT2, DateTime FROM_DATE, DateTime TO_DATE)
        {           
            return AccountReport_Datalayer.GetACCOUNTS_CashBookStatementDetailsForReport(COMP_CODE, BRANCH_CODE, GROPU_CODE, ACODE, YRDT1, YRDT2, FROM_DATE, TO_DATE);
        }

        public static DataSet GetACCOUNTS_BankBookStatementDetailsForReport(string COMP_CODE, string BRANCH_CODE, string GROPU_CODE, string ACODE, DateTime YRDT1, DateTime YRDT2, DateTime FROM_DATE, DateTime TO_DATE)
        {
            return AccountReport_Datalayer.GetACCOUNTS_BankBookStatementDetailsForReport(COMP_CODE, BRANCH_CODE, GROPU_CODE, ACODE, YRDT1, YRDT2, FROM_DATE, TO_DATE);
        }

        public static DataSet GetACCOUNTS_PaymentReceiptDetailsForReport(string COMP_CODE, string BRANCH_CODE, DateTime FROM_DATE, DateTime TO_DATE, string CRACODE, string DRACODE, string TRAN_TYPE)
        {
            return AccountReport_Datalayer.GetACCOUNTS_PaymentReceiptDetailsForReport(COMP_CODE, BRANCH_CODE, FROM_DATE, TO_DATE, CRACODE, DRACODE, TRAN_TYPE);
        }

        public static DataSet GetACCOUNTS_JournalVoucherAndCreditNoteDebitStatementForReport(string p_comp_code, string p_branch_code, string p_tran_type, DateTime p_yrdt1, DateTime p_yrdt2, DateTime p_frdt, DateTime p_todt, string p_acode)
        {
            return AccountReport_Datalayer.GetACCOUNTS_JournalVoucherAndCreditNoteDebitStatementForReport(p_comp_code, p_branch_code, p_tran_type, p_yrdt1, p_yrdt2, p_frdt, p_todt, p_acode);
        }

        public static DataSet GetACCOUNT_DetailsListForReport(string COMP_CODE, string BRANCH_CODE, string GROUP_CODE)
        {
            return AccountReport_Datalayer.GetACCOUNT_DetailsListForReport(COMP_CODE, BRANCH_CODE, GROUP_CODE);
        }

        public static DataSet GetACCOUNTS_CustomerContactDetailsForReport(string COMP_CODE, string BRANCH_CODE)
        {
            return AccountReport_Datalayer.GetACCOUNTS_CustomerContactDetailsForReport(COMP_CODE, BRANCH_CODE);
        }

        public static DataSet GetACCOUNTS_SupplierContactDetailsForReport(string COMP_CODE, string BRANCH_CODE)
        {
            return AccountReport_Datalayer.GetACCOUNTS_SupplierContactDetailsForReport(COMP_CODE, BRANCH_CODE);
        }

        public static DataSet GetACCOUNTS_USERLOGINDetailsForReport(string USERNAME)
        {
            return AccountReport_Datalayer.GetACCOUNTS_USERLOGINDetailsForReport(USERNAME);
        }

        }


        public class InventoryReport_Logiclayer
       {
        public static DataSet GetORDER_MASDetailsFor_MainReport(string COMP_CODE, string BRANCH_CODE, string ACODE, DateTime FROM_DATE, DateTime TO_DATE, string TRAN_TYPE, string CAT_CODE, string SCODE)
        {
            return InventoryReport_Datalayer.GetORDER_MASDetailsFor_MainReport(COMP_CODE, BRANCH_CODE, ACODE, FROM_DATE, TO_DATE, TRAN_TYPE, CAT_CODE, SCODE);
        }

        public static DataSet GetORDER_MASDetailsFor_SubReport(string CAT_CODE, string SCODE)
        {
            return InventoryReport_Datalayer.GetORDER_MASDetailsFor_SubReport(CAT_CODE, SCODE);
        }


        public static DataSet GetORDER_MASOutStandingDetailSubReport(string CAT_CODE, string SCODE)
        {
            return InventoryReport_Datalayer.GetORDER_MASOutStandingDetailSubReport(CAT_CODE, SCODE);
        }


        public static DataSet GetINVENTORY_DC_MAS_DateWiseChallanForReport(string COMP_CODE, string BRANCH_CODE, string ACODE, DateTime FROM_DATE, DateTime TO_DATE, string TRAN_TYPE, string TRN_TYPE, string CAT_CODE, string SCODE)
        {
            return InventoryReport_Datalayer.GetINVENTORY_DC_MAS_DateWiseChallanForReport(COMP_CODE, BRANCH_CODE, ACODE, FROM_DATE, TO_DATE, TRAN_TYPE, TRN_TYPE, CAT_CODE, SCODE);
        }

        public static DataSet GetINVENTORY_DC_MAS_Detail_DateWiseChallanForSubReport(string CAT_CODE, string SCODE)
        {
            return InventoryReport_Datalayer.GetINVENTORY_DC_MAS_Detail_DateWiseChallanForSubReport(CAT_CODE, SCODE);
        }


        public static DataSet GetQUOTATION_MASDetailsFor_MainReport(string COMP_CODE, string BRANCH_CODE, string ACODE, DateTime FROM_DATE, DateTime TO_DATE, string QUO_TYPE, string CAT_CODE, string SCODE)
        {
           return InventoryReport_Datalayer.GetQUOTATION_MASDetailsFor_MainReport(COMP_CODE, BRANCH_CODE, ACODE, FROM_DATE, TO_DATE, QUO_TYPE, CAT_CODE, SCODE);
        }

        public static DataSet GetQUOTATION_MASDetailsFor_SubReport(string CAT_CODE, string SCODE)
        {
            return InventoryReport_Datalayer.GetQUOTATION_MASDetailsFor_SubReport(CAT_CODE, SCODE);
        }

        public static DataSet GetASSEMBLE_MASDetailsFor_MainReport(string COMP_CODE, string BRANCH_CODE, DateTime FROM_DATE, DateTime TO_DATE, string TRAN_TYPE, string CAT_CODE, string SCODE)
        {
            return InventoryReport_Datalayer.GetASSEMBLE_MASDetailsFor_MainReport(COMP_CODE, BRANCH_CODE, FROM_DATE, TO_DATE, TRAN_TYPE, CAT_CODE, SCODE);
        }

        public static DataSet GetASSEMBLE_MASDetailsFor_SubReport(string CAT_CODE, string SCODE)
        {
            return InventoryReport_Datalayer.GetASSEMBLE_MASDetailsFor_SubReport(CAT_CODE, SCODE);
        }

        public static DataSet GetREC_ISS_M_Sales_Purchase_For_Register_Report(string COMP_CODE, string BRANCH_CODE, string ACODE, DateTime FROM_DATE, DateTime TO_DATE, string TRAN_TYPE, string TRN_TYPE, string CAT_CODE, string SCODE)
        {
            return InventoryReport_Datalayer.GetREC_ISS_M_Sales_Purchase_For_Register_Report(COMP_CODE, BRANCH_CODE, ACODE, FROM_DATE, TO_DATE, TRAN_TYPE, TRN_TYPE, CAT_CODE, SCODE);
        }

        public static DataSet GetBRANCH_ISSUE_STK_IRMASFor_MainReport(string COMP_CODE, string BRANCH_CODE, DateTime FROM_DATE, DateTime TO_DATE, string TRAN_TYPE, string CAT_CODE, string SCODE)
        {
            return InventoryReport_Datalayer.GetBRANCH_ISSUE_STK_IRMASFor_MainReport(COMP_CODE, BRANCH_CODE, FROM_DATE, TO_DATE, TRAN_TYPE, CAT_CODE, SCODE);
        }

        public static DataSet GetBRANCH_ISSUE_STK_IRMASFor_SubReport(string CAT_CODE, string SCODE)
        {
            return InventoryReport_Datalayer.GetBRANCH_ISSUE_STK_IRMASFor_SubReport(CAT_CODE, SCODE);
        }

        public static DataSet GetBRANCH_RECEIVED_STK_RECMASFor_MainReport(string COMP_CODE, string BRANCH_CODE, DateTime FROM_DATE, DateTime TO_DATE, string TRAN_TYPE, string CAT_CODE, string SCODE)
        {
            return InventoryReport_Datalayer.GetBRANCH_RECEIVED_STK_RECMASFor_MainReport(COMP_CODE, BRANCH_CODE, FROM_DATE, TO_DATE, TRAN_TYPE, CAT_CODE, SCODE);
        }

        public static DataSet GetBRANCH_RECEIVED_STK_RECMASFor_SubReport(string CAT_CODE, string SCODE)
        {
            return InventoryReport_Datalayer.GetBRANCH_RECEIVED_STK_RECMASFor_SubReport(CAT_CODE, SCODE);
        }


        }


        public class StockStatementReport_LogicLayer
    {
        public static DataSet GetSTOCKLIST_STATEMENTForReport(string COMP_CODE, string CAT_CODE)
        {
            return StockStatementReport_DataLayer.GetSTOCKLIST_STATEMENTForReport(COMP_CODE,CAT_CODE);
        }

        public static DataSet GetSTOCKLIST_BranchWiseForReport(string p_comp_code, string p_cat_code, DateTime p_todt, DateTime p_yrdt1)
        {
            return StockStatementReport_DataLayer.GetSTOCKLIST_BranchWiseForReport(p_comp_code, p_cat_code, p_todt, p_yrdt1);
        }

        public static DataSet GetSTOCK_DetailDateWiseForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, string p_cat_code, string p_scode, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            return StockStatementReport_DataLayer.GetSTOCK_DetailDateWiseForReport(p_comp_code, p_branch_code, p_frdt, p_todt, p_cat_code, p_scode, p_yrdt1, p_yrdt2);
        }

        public static DataSet GetSTOCK_DetailsMonthlyWiseForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, string p_cat_code, string p_scode, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            return StockStatementReport_DataLayer.GetSTOCK_DetailsMonthlyWiseForReport(p_comp_code, p_branch_code, p_frdt, p_todt, p_cat_code, p_scode, p_yrdt1, p_yrdt2);
        }

        public static DataSet GetSTOCK_ClosingDetailForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, string p_cat_code, string p_scode, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            return StockStatementReport_DataLayer.GetSTOCK_DetailsMonthlyWiseForReport(p_comp_code, p_branch_code, p_frdt, p_todt, p_cat_code, p_scode, p_yrdt1, p_yrdt2);
        }


        public static DataSet GetSTOCK_Maximum_Minimum_StatementForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, string p_cat_code, string p_scode, DateTime p_yrdt1, DateTime p_yrdt2, string p_report)
        {
            return StockStatementReport_DataLayer.GetSTOCK_Maximum_Minimum_StatementForReport(p_comp_code, p_branch_code, p_frdt, p_todt, p_cat_code, p_scode, p_yrdt1, p_yrdt2, p_report);
        }

        public static DataSet GetSTOCK_BranchOneItemDetailForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, string p_cat_code, string p_scode, DateTime p_yrdt1, DateTime p_yrdt2, string p_scode_flag, string p_userid)
        {
            return StockStatementReport_DataLayer.GetSTOCK_BranchOneItemDetailForReport(p_comp_code, p_branch_code, p_frdt, p_todt, p_cat_code, p_scode, p_yrdt1, p_yrdt2, p_scode_flag,p_userid);
        }

        public static DataSet GetSTOCK_BarcodeStockDetailExciseForReport(string p_comp_code, string p_branch_code, DateTime p_todt, string p_cat_code, string p_scode, string p_fin_year, string cp_usertype)
        {
            return StockStatementReport_DataLayer.GetSTOCK_BarcodeStockDetailExciseForReport(p_comp_code, p_branch_code, p_todt, p_cat_code, p_scode, p_fin_year, cp_usertype);
        }

        public static DataSet GetSTOCK_BarcodeStock_Status_BarcodeStock_ZeroValue_ForReport(string p_comp_code, string p_branch_code, DateTime p_todt, string p_cat_code, string p_scode, string p_fin_year, string p_report)
        {
            return StockStatementReport_DataLayer.GetSTOCK_BarcodeStock_Status_BarcodeStock_ZeroValue_ForReport(p_comp_code, p_branch_code, p_todt, p_cat_code, p_scode, p_fin_year, p_report);
        }


        public static DataSet GetSTOCK_Barcode_Stock_Detail_ForReport(string p_comp_code, string p_branch_code, DateTime p_todt, string p_cat_code, string p_scode, string p_fin_year, string cp_usertype)
        {
            return StockStatementReport_DataLayer.GetSTOCK_Barcode_Stock_Detail_ForReport(p_comp_code, p_branch_code, p_todt, p_cat_code, p_scode, p_fin_year, cp_usertype);
        }

        public static DataSet GetSTOCK_Barcode_Stock_Summary_ForReport(string p_comp_code, string p_branch_code, DateTime p_todt, string p_cat_code, string p_scode, string p_fin_year, string cp_usertype)
        {
            return StockStatementReport_DataLayer.GetSTOCK_Barcode_Stock_Summary_ForReport(p_comp_code, p_branch_code, p_todt, p_cat_code, p_scode, p_fin_year, cp_usertype);
        }

        public static DataSet GetSTOCK_Barcode_Stock_Value_ForReport(string p_comp_code, string p_branch_code, DateTime p_todt, string p_cat_code, string p_scode, string p_fin_year, string cp_usertype)
        {
            return StockStatementReport_DataLayer.GetSTOCK_Barcode_Stock_Value_ForReport(p_comp_code, p_branch_code, p_todt, p_cat_code, p_scode, p_fin_year, cp_usertype);
        }


        public static DataSet GetSTOCK_Barcode_stock_HistoryForReport(string p_comp_code)
        {
            return StockStatementReport_DataLayer.GetSTOCK_Barcode_stock_HistoryForReport(p_comp_code);
        }

        public static DataSet GetSTOCK_Barcode_stock_printForReport(string p_comp_code, string p_branch_code)
        {
            return StockStatementReport_DataLayer.GetSTOCK_Barcode_stock_printForReport(p_comp_code, p_branch_code);
        }

        public static DataSet GetSTOCK_Supplier_Stock_IndentForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, string p_acode, DateTime p_yrdt1, DateTime p_yrdt2, string p_cat_code, string p_scode)
        {
            return StockStatementReport_DataLayer.GetSTOCK_Supplier_Stock_IndentForReport(p_comp_code, p_branch_code, p_frdt, p_todt, p_acode, p_yrdt1, p_yrdt2, p_cat_code, p_scode);
        }

        public static DataSet GetSTOCK_stock_indent_with_last_purchaseForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, DateTime p_yrdt1, DateTime p_yrdt2, string p_cat_code, string p_scode)
        {
            return StockStatementReport_DataLayer.GetSTOCK_stock_indent_with_last_purchaseForReport(p_comp_code, p_branch_code, p_frdt, p_todt, p_yrdt1, p_yrdt2,  p_cat_code,  p_scode);
        }

        public static DataSet GetSTOCK_Diff_Qty_Stock_with_BarcodeStockForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, string p_fin_year, string p_cat_code, string p_scode)
        {
            return StockStatementReport_DataLayer.GetSTOCK_Diff_Qty_Stock_with_BarcodeStockForReport(p_comp_code, p_branch_code, p_frdt, p_todt, p_fin_year, p_cat_code, p_scode);
        }

        public static DataSet GetSTOCK_Diff_Stock_Barcode_PostingForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, DateTime p_yrdt1, DateTime p_yrdt2, string p_cat_code, string p_scode)
        {
            return StockStatementReport_DataLayer.GetSTOCK_Diff_Stock_Barcode_PostingForReport(p_comp_code, p_branch_code, p_frdt, p_todt, p_yrdt1, p_yrdt2, p_cat_code, p_scode);
        }


        public static DataSet GetSTOCK_sales_DC_diff_barcode_qtyForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, string p_party_code, DateTime p_yrdt1, DateTime p_yrdt2, string p_cat_code, string p_scode, string p_tran_type, string p_trn_type)
        {
            return StockStatementReport_DataLayer.GetSTOCK_sales_DC_diff_barcode_qtyForReport( p_comp_code,  p_branch_code,  p_frdt,  p_todt,  p_party_code,  p_yrdt1,  p_yrdt2,  p_cat_code,  p_scode,  p_tran_type,  p_trn_type);
        }


        public static DataSet GetSTOCK_branch_issue_diff_barcode_qtyForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, DateTime p_yrdt1, DateTime p_yrdt2, string p_cat_code, string p_scode, string p_tran_type)
        {
            return StockStatementReport_DataLayer.GetSTOCK_branch_issue_diff_barcode_qtyForReport(p_comp_code, p_branch_code, p_frdt, p_todt, p_yrdt1, p_yrdt2, p_cat_code, p_scode, p_tran_type);
        }

        public static string upd_op_stock_barcode_price(string p_comp_code, DateTime p_yrdt1, DateTime p_yrdt2, string p_Types)
        {
            return StockStatementReport_DataLayer.upd_op_stock_barcode_price(p_comp_code, p_yrdt1, p_yrdt2, p_Types);
        }

        public static string upd_purchase_stock_barcode_price(string p_comp_code, DateTime p_yrdt1, DateTime p_yrdt2, string p_Types)
        {
            return StockStatementReport_DataLayer.upd_purchase_stock_barcode_price(p_comp_code, p_yrdt1, p_yrdt2, p_Types);
        }

        public static string upd_assemble_stock_barcode_price(string p_comp_code, DateTime p_yrdt1, DateTime p_yrdt2, string p_Types)
        {
            return StockStatementReport_DataLayer.upd_assemble_stock_barcode_price(p_comp_code, p_yrdt1, p_yrdt2, p_Types);
        }

        public static string upd_xfer_stock_barcode_price(string p_comp_code, DateTime p_yrdt1, DateTime p_yrdt2, string p_Types)
        {
            return StockStatementReport_DataLayer.upd_xfer_stock_barcode_price(p_comp_code, p_yrdt1, p_yrdt2, p_Types);
        }


    }

    }















