using System;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Veera.Controller;
using System.Data.SqlClient;
using System.Configuration;
using Veera.LogicLayer;
using System.Xml;

namespace Veera.DataLayer


{ 
    class DataLayer
    {

    }



    public class COMPANYDataLayer

    {


        public static string InsertCOMPANYDetials(COMPANYLogicLayer COMPANYDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLCOMPANYDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(COMPANYDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, COMPANYDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLCOMPANYDetails = xd.InnerXml;
            string str = "";
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMPANYDetails", strXMLCOMPANYDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "usp_InsertCOMPANYDetail", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateCOMPANYDetials(COMPANYLogicLayer COMPANYDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLCOMPANYDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(COMPANYDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, COMPANYDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLCOMPANYDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMPANYDetails", strXMLCOMPANYDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateCOMPANYDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteCOMPANYDetailsByID(string CompanyID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", CompanyID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteCOMPANYDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllCOMPANYDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllCOMPANYDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllCOMPANYDetials_DDL()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllCOMPANYDetials_DDL").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetAllIDWiseCOMPANYDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseCOMPANYDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetCompanyDetailUserWiseRights(string USERCODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetCompanyDetailUserWiseRights", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllFIN_YEARSDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllFIN_YEARSDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllFIN_YEARSDetialsForGrid(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                //  paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.BigInt);
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllFIN_YEARSDetialsForGrid", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetFIN_YEARSDetailUserWiseRightsAndCompanyWise(string USERCODE, string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.BigInt);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetFIN_YEARSDetailUserWiseRightsAndCompanyWise", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetFIN_YEARSDetailUserWiseRightsAndCompanyWiseForGrid(string USERCODE, string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.BigInt);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetFIN_YEARSDetailUserWiseRightsAndCompanyWiseForGrid", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static string InsertUSER_COMPANY_RIGHTSDetail(string COMP_CODE, string USERCODE)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();


            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertUSER_COMPANY_RIGHTSDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static string DELETEUSER_COMPANY_RIGHTSDetail(string COMP_CODE, string USERCODE)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();


            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DELETEUSER_COMPANY_RIGHTSDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static string InsertUSER_YEARS_RIGHTSDetail(string COMP_CODE, string USERCODE, string YRDT1)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();


            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertUSER_YEARS_RIGHTSDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static string DELETEUSER_YEARS_RIGHTSDetail(string COMP_CODE, string USERCODE, string YRDT1)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();


            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DELETEUSER_YEARS_RIGHTSDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }




        public static DataTable GetAllFinancialYearDetials(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                //  paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.BigInt);
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllFinancialYearDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static string InsertFinancialYearDetials(string COMP_CODE, string YRDT1, string YRDT2)
        {


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                //  paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.BigInt);
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.BigInt);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT2", YRDT2, SqlDbType.DateTime);
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "USP_InsertFinancialYearDetials", paramsToStore);
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }



    public class BRANCH_MASDataLayer

    {


        public static string InsertBRANCH_MASDetials(BRANCH_MASLogicLayer BRANCH_MASDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLBRANCH_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(BRANCH_MASDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, BRANCH_MASDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLBRANCH_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BRANCH_MASDetails", strXMLBRANCH_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "usp_InsertBRANCH_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateBRANCH_MASDetials(BRANCH_MASLogicLayer BRANCH_MASDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLBRANCH_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(BRANCH_MASDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, BRANCH_MASDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLBRANCH_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BRANCH_MASDetails", strXMLBRANCH_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateBRANCH_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                return ex.Message;
            }
        }



        public static string DeleteBRANCHDetailsByID(string BranchID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BranchID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteBRANCHDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllBRANCH_MASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllBRANCH_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetBranchDetailCompanyWiseFor_Ddl(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetBranchDetailCompanyWiseFor_Ddl", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetBranchNameCompanyWiseFor_DdlReport(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetBranchNameCompanyWiseFor_DdlReport", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllIDWiseBRANCH_MASDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseBRANCH_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetIDWiseBRANCH_MASDetialsByCompany(string COMP_CODE, string BRANCH_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.BigInt);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetIDWiseBRANCH_MASDetialsByCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetBranchDetailCompanyWise(string COMP_CODE, string USERCODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.BigInt);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.BigInt);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetBranchDetailCompanyWise", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetBranchDetailUserWiseRightsAndCompanyWise(string USERCODE, string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.BigInt);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetBranchDetailUserWiseRightsAndCompanyWise", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static string InsertUSER_BRANCHDetail(string BRANCH_CODE, string USERCODE, string COMP_CODE)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();


            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);





                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertUSER_BRANCHDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static string DELETEUSER_BRANCHDetail(string BRANCH_CODE, string USERCODE, string COMP_CODE)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();


            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);





                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DELETEUSER_BRANCHDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static string UpdateUSER_BRANCHDetail(string BRANCH_CODE, string USERCODE, string COMP_CODE, string Flag, int Types)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();


            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[5];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@Flag", Flag, SqlDbType.VarChar);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@Types", Types, SqlDbType.Int);



                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateUSER_BRANCHDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
    }



    public class USER_MASDataLayer

    {


        public static string InsertUSER_MASDetail(USER_MASLogicLayer USER_MASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLUSER_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(USER_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, USER_MASDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLUSER_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USER_MASDetails", strXMLUSER_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertUSER_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateUSER_MASDetail(USER_MASLogicLayer USER_MASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLUSER_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(USER_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, USER_MASDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLUSER_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USER_MASDetails", strXMLUSER_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateUSER_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteUSER_MASDetailsByID(string UserID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", UserID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteUSER_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static DataTable GetAllUSER_MASDetials(int UserCode, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@UserCode", UserCode, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllUSER_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllUSER_MASDetials_ForDDl()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllUSER_MASDetials_ForDDl").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllIDWiseUSER_MASDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseUSER_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetUserMasterAuthentication(string USERNAME, string USERPASS)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERNAME", USERNAME, SqlDbType.VarChar);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@USERPASS", USERPASS, SqlDbType.VarChar);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetUserMasterAuthentication", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllUserWiseCompanyRights(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllUserWiseCompanyRights", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


    }

    public class USERLOGINDataLayer

    {


        public static string InsertUSERLOGINDetials(USERLOGINLogicLayer USERLOGINDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLUSERLOGINDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(USERLOGINDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, USERLOGINDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLUSERLOGINDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERLOGINDetails", strXMLUSERLOGINDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "usp_InsertUSERLOGINDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateUSERLOGINDetials(USERLOGINLogicLayer USERLOGINDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLUSERLOGINDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(USERLOGINDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, USERLOGINDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLUSERLOGINDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERLOGINDetails", strXMLUSERLOGINDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateUSERLOGINDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }
        public static DataTable GetAllUSERLOGINDetials()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllUSERLOGINDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseUSERLOGINDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseUSERLOGINDetials").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetMenuWithNullREF_CODE()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetMenuWithNullREF_CODE").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetSubMenuWithNullREF_CODE(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CODE", Id, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSubMenuWithNullREF_CODE", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }


    public class GROUP_MASDataLayer
    {

        public static string InsertGROUPMASTERDetail(GROUP_MASLogicLayer GROUPMASTERDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLGROUPMASTERDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(GROUPMASTERDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, GROUPMASTERDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLGROUPMASTERDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@GROUPMASTERDetails", strXMLGROUPMASTERDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertGROUPMASTERDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }

        }


        public static string UpdateGROUPMASTERDetail(GROUP_MASLogicLayer GROUPMASTERDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLGROUPMASTERDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(GROUPMASTERDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, GROUPMASTERDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLGROUPMASTERDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@GROUPMASTERDetails", strXMLGROUPMASTERDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateGROUPMASTERDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteGROUP_MASDetailsByID(string GroupID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@GROUP_CODE", GroupID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteGROUP_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllGROUP_MASDetials(int UserCode, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@UserCode", UserCode, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllGROUP_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetGROUP_CODEWISEGROUP_MASDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@GROUP_CODE", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetGROUP_CODEWISEGROUP_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllGROUP_MASDetials_DDL()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllGROUP_MASDetials_DDL").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }



    public class ACCOUNTS_MASDataLayer

    {


        public static string InsertACCOUNTDetail(ACCOUNTS_MASLogicLayer ACCOUNTDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLACCOUNTDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ACCOUNTDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ACCOUNTDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLACCOUNTDetails = xd.InnerXml;
            string str = "";
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ACCOUNTDetails", strXMLACCOUNTDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertACCOUNTDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static string UpdateACCOUNTDetails(ACCOUNTS_MASLogicLayer ACCOUNTDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLACCOUNTDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ACCOUNTDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ACCOUNTDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLACCOUNTDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ACCOUNTDetails", strXMLACCOUNTDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateACCOUNTDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteACCOUNTDetailsByID(string AccountID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ACODE", AccountID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteACCOUNTDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static DataTable GetAllACCOUNTSDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllACCOUNTSDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllIDWiseACCOUNTDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseACCOUNTDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllACCOUNTS_MASDetialsFor_DDL()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllACCOUNTS_MASDetialsFor_DDL").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetIDWiseGROUP_NAMEFor_AccountBal(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ACODE", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetIDWiseGROUP_NAMEFor_AccountBal", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetAllGroupCodeWise_PartyDetailsForGrid(string COMP_CODE, string BRANCH_CODE, string GROUP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.BigInt);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.BigInt);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@GROUP_CODE", GROUP_CODE, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllGroupCodeWise_PartyDetailsForGrid", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetAllACCOUNTDetialsByComapnyAndBranch(string COMP_CODE, string BRANCH_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.BigInt);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.BigInt);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllACCOUNTDetialsByComapnyAndBranch", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllACCOUNTWiseComapnyAndBranchForInvoice(string COMP_CODE, string BRANCH_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.BigInt);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.BigInt);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllACCOUNTWiseComapnyAndBranchForInvoice", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAccountsNameForInvoices(string COMP_CODE, string BRANCH_CODE, string TRAN_TYPE, string TRN_TYPE)
        {

            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_tran_type", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_trn_type", TRN_TYPE, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "get_acode", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetACCOUNTNameForCashBankBook(string COMP_CODE, string GROUP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.BigInt);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@GROUP_CODE", GROUP_CODE, SqlDbType.BigInt);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTNameForCash/BankBook", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



    }





    public class ACCT_BALDataLayer

    {


        public static string InsertACCT_BALDetials(ACCT_BALLogicLayer ACCT_BALDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLACCT_BALDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ACCT_BALDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ACCT_BALDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLACCT_BALDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ACCT_BALDetails", strXMLACCT_BALDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "usp_InsertACCT_BALDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static string UpdateACCT_BALDetials(ACCT_BALLogicLayer ACCT_BALDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLACCT_BALDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ACCT_BALDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ACCT_BALDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLACCT_BALDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                //paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                //paramsToStore[1] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                //paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ACCT_BALDetails", strXMLACCT_BALDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateACCT_BALDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }
        public static DataTable GetAllACCT_BALDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try

            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllACCT_BALDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
        public static DataTable GetAllIDWiseACCT_BALDetials(string COMP_CODE, string ACODE, string YRDT1)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseACCT_BALDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static string DeleteACCOUNTS_BALDetailsByID(string COMP_CODE, string ACODE, string YRDT1)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteACCOUNTS_BALDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
    }

    public class ACCOUNTS_DETDataLayer

    {
        public static string InsertACCOUNTS_DETDetail(ACCOUNTS_DETLogicLayer ContactDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLContactDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ContactDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ContactDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLContactDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ContactDetails", strXMLContactDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertACCOUNTS_DETDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }



        public static string UpdateACCOUNTS_DETDetails(ACCOUNTS_DETLogicLayer ContactDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLContactDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ContactDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ContactDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLContactDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ContactDetails", strXMLContactDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateACCOUNTS_DETDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteACCOUNTS_DETDetailsByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SRNO", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteACCOUNTS_DETDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }



        public static DataTable GetAllACCOUNTS_DETDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllACCOUNTS_DETDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllIDWiseACCOUNTS_DETDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseACCOUNTS_DETDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllParty_Contact_DetialsWIiseAccountFor_DDL(string ACODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllParty_Contact_DetialsWIiseAccountFor_DDL", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



    }


    public class BROKER_MASDataLayer
    {
        public static string InsertBROKERDetail(BROKER_MASLogicLayer PersonDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLPersonDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(PersonDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, PersonDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLPersonDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@PersonDetails", strXMLPersonDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertBROKERDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }



        public static string UpdateBROKERDetails(BROKER_MASLogicLayer PersonDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLPersonDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(PersonDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, PersonDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLPersonDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@PersonDetails", strXMLPersonDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateBROKERDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }



        public static string DeleteBROKERDetailsByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BCODE", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteBROKERDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static DataTable GetAllBROKERDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllBROKERDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetAllIDWiseBROKERDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseBROKERDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllBROKER_MASDetialsFor_DDL()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllBROKER_MASDetialsFor_DDL").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllBROKER_MASDetialsCompanyWiseFor_DDL(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllBROKER_MASDetialsCompanyWiseFor_DDL", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllBROKERDetialsWiseComapnyAndBranch(string COMP_CODE, string BRANCH_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.BigInt);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllBROKERDetialsWiseComapnyAndBranch", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }


    public class STATE_MASDataLayer

    {
        public static string InsertSTATE_MASDetail(STATE_MASLogicLayer StateDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStateDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(StateDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, StateDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStateDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@StateDetails", strXMLStateDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertSTATE_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }



        public static string UpdateSTATE_MASDetails(STATE_MASLogicLayer StateDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStateDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(StateDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, StateDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStateDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@StateDetails", strXMLStateDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateSTATE_MASDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }



        public static string DeleteSTATE_MASDetailsByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@STATE_CODE", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteSTATE_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllSTATE_MASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTATE_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllIDWiseSTATE_MASDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseSTATE_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetAllSTATE_MASDetialsFor_DDL()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTATE_MASDetialsFor_DDL").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


    }


    public class PLACE_MASDataLayer
    {
        public static string InsertPLACE_MASDetail(PLACE_MASLogicLayer PlaceDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLPlaceDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(PlaceDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, PlaceDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLPlaceDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@PlaceDetails", strXMLPlaceDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertPLACE_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }



        public static string UpdatePLACE_MASDetails(PLACE_MASLogicLayer PlaceDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLPlaceDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(PlaceDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, PlaceDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLPlaceDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@PlaceDetails", strXMLPlaceDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdatePLACE_MASDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeletePLACE_MASDetailsByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@PLACE_CODE", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeletePLACE_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllPLACE_MASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllPLACE_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllIDWisePLACE_MASDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWisePLACE_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllPLACE_MASDetialsFor_DDL()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllPLACE_MASDetialsFor_DDL").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


    }

    public class ROUTE_MASDataLayer
    {
        public static string InsertROUTE_MASDetail(ROUTE_MASLogicLayer RouteDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLRouteDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(RouteDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, RouteDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLRouteDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@RouteDetails", strXMLRouteDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertROUTE_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }


        public static string UpdateROUTE_MASDetails(ROUTE_MASLogicLayer RouteDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLRouteDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(RouteDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, RouteDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLRouteDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@RouteDetails", strXMLRouteDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateROUTE_MASDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteROUTE_MASDetailsByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ROUTE_CODE", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteROUTE_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllROUTE_MASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllROUTE_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllIDWiseROUTE_MASDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseROUTE_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetAllROUTE_MASDetialsFor_DDL()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllROUTE_MASDetialsFor_DDL").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }




    public class TRANSPORT_MASDataLayer
    {
        public static string InsertTRANSPORT_MASDetail(TRANSPORT_MASLogicLayer TransportDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLTransportDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(TransportDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, TransportDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLTransportDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TransportDetails", strXMLTransportDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertTRANSPORT_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }


        public static string UpdateTRANSPORT_MASDetails(TRANSPORT_MASLogicLayer TransportDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLTransportDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(TransportDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, TransportDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLTransportDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TransportDetails", strXMLTransportDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateTRANSPORT_MASDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }



        public static string DeleteTRANSPORT_MASDetailsByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TCODE", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteTRANSPORT_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllTRANSPORT_MASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllTRANSPORT_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllIDWiseTRANSPORT_MASDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseTRANSPORT_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllTRANSPORT_MASDetialsFor_DDL()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllTRANSPORT_MASDetialsFor_DDL").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }

    public class CHARGES_MASDataLayer
    {
        public static string InsertCHARGESDetail(CHARGES_MASLogicLayer ChargesDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLChargesDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ChargesDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ChargesDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLChargesDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                string str = "";
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ChargesDetails", strXMLChargesDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_InsertCHARGESDetail", paramsToStore).ToString();
                trn.Commit();
                con.Close();

                return str;
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }


        public static string UpdateCHARGESDetails(CHARGES_MASLogicLayer ChargesDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLChargesDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ChargesDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ChargesDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLChargesDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ChargesDetails", strXMLChargesDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateCHARGESDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteCHARGESDetailsByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CCODE", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteCHARGESDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static DataTable GetAllCHARGESDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllCHARGESDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllIDWiseCHARGESDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseCHARGESDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllCHARGESDetialsFor_DDL(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ACODE", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllCHARGESDetialsFor_DDL", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllCHARGESDetialsForComapnyWise_DDL(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllCHARGESDetialsForComapnyWise_DDL", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable CHARGES_MAS_CHARGES_RATEMAS_DetailByAccountPartyType(int CCODE, string PartyType)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CCODE", CCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@PartyType", PartyType, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_CHARGES_MAS_CHARGES_RATEMAS_DetailByAccountPartyType", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }





    public class CHARGES_RATEMASDataLayer
    {
        public static string InsertCHARGES_RATEMASDetail(CHARGES_RATEMASLogicLayer ChargesRateDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLChargesRateDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ChargesRateDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ChargesRateDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLChargesRateDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ChargesRateDetails", strXMLChargesRateDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertCHARGES_RATEMASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }


        public static string UpdateCHARGES_RATEMASDetails(CHARGES_RATEMASLogicLayer ChargesRateDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLChargesRateDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ChargesRateDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ChargesRateDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLChargesRateDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ChargesRateDetails", strXMLChargesRateDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateCHARGES_RATEMASDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }

    }

    public class MENU_MASDataLayer
    {
        public static string InsertMENU_MASDetail(MENU_MASLogicLayer MenuDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLMenuDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(MenuDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, MenuDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLMenuDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@MenuDetails", strXMLMenuDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertMENU_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }

        public static string UpdateMENU_MASDetails(MENU_MASLogicLayer MenuDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLMenuDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(MenuDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, MenuDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLMenuDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@MenuDetails", strXMLMenuDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateMENU_MASDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteMENU_MASDetailsByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CODE", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteMENU_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllMENU_MASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllMENU_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllIDWiseMENU_MASDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Id", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseMENU_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllMENU_MASDetialsFor_DDL()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllMENU_MASDetialsFor_DDL").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllMENU_MASDetialsFor_Grid(int COMP_CODE, int USERCODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllMENU_MASDetialsFor_Grid", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }




    public class USER_RIGHTSDataLayer
    {
        public static string InsertUSER_RIGHTSDetail(USER_RIGHTSLogicLayer MenuDetails, string Detail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLMenuDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(MenuDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, MenuDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLMenuDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@UserRights", strXMLMenuDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@Detail", Detail, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertUSER_RIGHTSDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
    }


    public class EXCISE_RATEMASDataLayer
    {
        public static string InsertEXCISE_RATEMASDetail(EXCISE_RATEMASLogicLayer ExciseRateDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLExciseRateDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ExciseRateDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ExciseRateDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLExciseRateDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                string str = "";
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ExciseRateDetails", strXMLExciseRateDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "[USP_InsertEXCISE_RATEMASDetail]", paramsToStore).ToString();
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }


        public static string UpdateEXCISE_RATEMASDetail(EXCISE_RATEMASLogicLayer ExciseRateDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLExciseRateDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ExciseRateDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ExciseRateDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLExciseRateDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ExciseRateDetails", strXMLExciseRateDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateEXCISE_RATEMASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }

        public static string DeleteEXCISE_RATEMASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteEXCISE_RATEMASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllEXCISE_RATEMASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllEXCISE_RATEMASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetAllIDWiseEXCISE_RATEMASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseEXCISE_RATEMASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }


    public class HSNCODE_MASDataLayer

    {


        public static string InsertHSNCODE_MASDetials(HSNCODE_MASLogicLayer HSNCODE_MASDetail)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLHSNCODE_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(HSNCODE_MASDetail.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, HSNCODE_MASDetail);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLHSNCODE_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@HSNCODE_MASDetails", strXMLHSNCODE_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertHSNCODE_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static string UpdateHSNCODE_MASDetail(HSNCODE_MASLogicLayer HSNCODE_MASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLHSNCODE_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(HSNCODE_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, HSNCODE_MASDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLHSNCODE_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@HSNCODE_MASDetails", strXMLHSNCODE_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateHSNCODE_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }



        public static string DeleteHSNCODE_MASDetialsByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@HSN_CODE", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteHSNCODE_MASDetialsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllHSNCODE_MASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllHSNCODE_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllIDWiseHSNCODE_MASDetials(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@HSN_CODE", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseHSNCODE_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }


    public class UOM_MASDataLayer
    {
        public static string InsertUOM_MASDetail(UOM_MASLogicLayer UOM_MASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLUOM_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(UOM_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, UOM_MASDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLUOM_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@UOM_MASDetails", strXMLUOM_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertUOM_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static string UpdateUOM_MASDetail(UOM_MASLogicLayer UOM_MASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLUOM_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(UOM_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, UOM_MASDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLUOM_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@UOM_MASDetails", strXMLUOM_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateUOM_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteUOM_MASDetailByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@UOM", ID, SqlDbType.VarChar);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteUOM_MASDetailByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllUOM_MASDetail(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllUOM_MASDetail", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllIDWiseUOM_MASDetail(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@UOM", Id, SqlDbType.VarChar);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseUOM_MASDetail", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllUOM_MASDetialsFor_DDL()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllUOM_MASDetialsFor_DDL").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }


    public class STOCKCategory_MASDataLayer
    {
        public static string InsertSTOCKCategory_MASDetail(STOCKCategory_MASLogicLayer StockCat_MASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStockCat_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(StockCat_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, StockCat_MASDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStockCat_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@StockCat_MASDetails", strXMLStockCat_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertSTOCKCategory_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static string UpdateSTOCKCategory_MASDetail(STOCKCategory_MASLogicLayer StockCat_MASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStockCat_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(StockCat_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, StockCat_MASDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStockCat_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@StockCat_MASDetails", strXMLStockCat_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateSTOCKCategory_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteSTOCKCategory_MASDetailsByID(string CAT_CODE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CAT_CODE", CAT_CODE, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteSTOCKCategory_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static DataTable GetAllSTOCKCategory_MASDetails(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCKCategory_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllIDWiseSTOCKCategory_MASDetail(string CAT_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CAT_CODE", CAT_CODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseSTOCKCategory_MASDetail", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllSTOCK_CATAGORYDetialsFor_DDL()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_CATAGORYDetialsFor_DDL").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllSTOCKCategory_MASDetailWiseCompany(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCKCategory_MASDetailWiseCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }


    public class STOCK_MASDataLayer
    {
        public static string InsertSTOCK_MASDetail(STOCK_MASLogicLayer StockMasDetails, STOCK_RATEMASLogicLayer StockRateMasDetails, string DetailMap)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStockMasDetails, strXMLStockRateMasDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(StockMasDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, StockMasDetails);

            System.Xml.Serialization.XmlSerializer xRate = new System.Xml.Serialization.XmlSerializer(StockRateMasDetails.GetType());
            System.IO.MemoryStream streamRate = new System.IO.MemoryStream();
            xRate.Serialize(streamRate, StockRateMasDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStockMasDetails = xd.InnerXml;

            streamRate.Position = 0;
            XmlDocument xdRate = new XmlDocument();
            xdRate.Load(streamRate);
            strXMLStockRateMasDetails = xdRate.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@StockDetails", strXMLStockMasDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@STOCK_RATEMAS", strXMLStockRateMasDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@Detail", DetailMap, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertSTOCK_MASTERDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string GetMaxProductCodeFromStaockMaster()
        {
            string GetId = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                //SqlParameter[] paramsToStore = new SqlParameter[1];
                //paramsToStore[0] = ControllersHelper.GetSqlParameter("@SCODE", ID, SqlDbType.Int);


                GetId = SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "USP_GetProductCode").ToString();
            }
            catch (Exception ex)
            {
            }
            return GetId;
        }




        public static string UpdateSTOCK_MASDetail(STOCK_MASLogicLayer StockMasDetails, STOCK_RATEMASLogicLayer StockRateMasDetails, string DetailMap)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStockMasDetails, strXMLStockRateMasDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(StockMasDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, StockMasDetails);

            System.Xml.Serialization.XmlSerializer xRate = new System.Xml.Serialization.XmlSerializer(StockRateMasDetails.GetType());
            System.IO.MemoryStream streamRate = new System.IO.MemoryStream();
            xRate.Serialize(streamRate, StockRateMasDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStockMasDetails = xd.InnerXml;

            streamRate.Position = 0;
            XmlDocument xdRate = new XmlDocument();
            xdRate.Load(streamRate);
            strXMLStockRateMasDetails = xdRate.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@StockDetails", strXMLStockMasDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@STOCK_RATEMAS", strXMLStockRateMasDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@Detail", DetailMap, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateSTOCK_MASTERDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteSTOCK_MASDetailsByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SCODE", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteSTOCK_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllSTOCK_MASDetails(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetAllIDWiseSTOCK_MASDetail(string ID)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SCODE", ID, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseSTOCK_MASDetail", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType(int SCODE, string PartyType)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@PartyType", PartyType, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllSTOCK_MASDetialsFor_DDL()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_MASDetialsFor_DDL").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllSTOCK_NAMEAUTODetialsWIiseCompany(string comp_code, string searchtext)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", comp_code, SqlDbType.BigInt);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@searchtxt", searchtext, SqlDbType.VarChar);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_NAMEAUTODetialsWIiseCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }

    public class STOCK_RATEMASDataLayer
    {
        public static string InsertSTOCK_RATEMASDetail(STOCK_RATEMASLogicLayer StockRateMasDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStockRateMasDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(StockRateMasDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, StockRateMasDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStockRateMasDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@StockRateMasDetails", strXMLStockRateMasDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertSTOCK_RATEMASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }


        public static string UpdateSTOCK_RATEMASDetail(STOCK_RATEMASLogicLayer StockRateMasDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStockRateMasDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(StockRateMasDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, StockRateMasDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStockRateMasDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@StockRateMasDetails", strXMLStockRateMasDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateSTOCK_RATEMASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }

    }


    public class STOCK_BALDataLayer
    {
        public static string InsertSTOCK_BALDetail(STOCK_BALLogicLayer StockBalDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStockBalDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(StockBalDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, StockBalDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStockBalDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@StockRateMasDetails", strXMLStockBalDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertSTOCK_BALDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllSTOCK_BALDetails(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_BALDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllSTOCK_BALDetailByCompany(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_BALDetailByCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllSTOCK_PRICEDetailByCompany(string COMP_CODE, DateTime FRMDATE, DateTime ToDate)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@FRMDATE", FRMDATE, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@ToDate", ToDate, SqlDbType.DateTime);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_PRICEDetailByCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAll_SCODEWise_STOCK_BAL(string SCODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAll_SCODEWise_STOCK_BAL", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }

    public class STOCK_PRICE_MASDataLayer
    {
        public static string InsertSTOCK_PRICE_MASDetail(STOCK_PRICE_MASLogicLayer PRICE_MASDetails, string DetailMap)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLPRICE_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(PRICE_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, PRICE_MASDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLPRICE_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                string str = "";
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@PRICE_MASDetails", strXMLPRICE_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@Detail", DetailMap, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_InsertSTOCK_PRICE_MASDetail", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string UpdateSTOCK_PRICE_MASDetail(STOCK_PRICE_MASLogicLayer PRICE_MASDetails, string DetailMap)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLPRICE_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(PRICE_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, PRICE_MASDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLPRICE_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@PRICE_MASDetails", strXMLPRICE_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@Detail", DetailMap, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateSTOCK_PRICE_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }

        public static string DeleteSTOCK_PRISE_MASDetailsByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SRNO", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteSTOCK_PRISE_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static DataTable GetAllSTOCK_PRICE_MASDetail(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_PRICE_MASDetail", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataSet GetAllIDWiseSTOCK_PRICE_MASDetail(string ID)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SRNO", ID, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseSTOCK_PRICE_MASDetail", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllWiseSRNO_PRICE_MASDetail(string ID)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SRNO", ID, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllWiseSRNO_PRICE_MASDetail", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



    }


    public class STOCK_BRANDTYPEMASDataLayer
    {
        public static string InsertSTOCK_BRANDTYPEMASDetail(STOCK_BRANDTYPEMASLogicLayer StockBrandMasDetails, string DetailMap)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStockBrandMasDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(StockBrandMasDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, StockBrandMasDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStockBrandMasDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@StockBrandMasDetails", strXMLStockBrandMasDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@Detail", DetailMap, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertSTOCK_BRANDTYPEMASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string UpdateSTOCK_BRANDTYPEMASDetail(STOCK_BRANDTYPEMASLogicLayer StockBrandMasDetails, string DetailMap)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStockBrandMasDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(StockBrandMasDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, StockBrandMasDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStockBrandMasDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@StockBrandMasDetails", strXMLStockBrandMasDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@Detail", DetailMap, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateSTOCK_BRANDTYPEMASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteSTOCK_BRANDTYPEMASDetailsByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BRANDTYPE_CODE", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteSTOCK_BRANDTYPEMASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        public static DataSet GetAllIDWiseSTOCK_BRANDTYPEMASDetail(string ID)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BRANDTYPE_CODE", ID, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseSTOCK_BRANDTYPEMASDetail", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllSTOCK_BRANDTYEPMASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_BRANDTYEPMASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllSTOCK_BRANDTYPEMASDetialsFor_DDL()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_BRANDTYPEMASDetialsFor_DDL").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetSTOCK_BRANDTYPEMASCompanyWiseFor_Ddl(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_BRANDTYPEMASCompanyWiseFor_Ddl", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetStockBrandTypeMasterDetailFilterByBrandTypeCode(string COMP_CODE, string BRANDTYPE_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@comp_code", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@brandtype_code", BRANDTYPE_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetStockBrandTypeMasterDetailFilterByBrandTypeCode", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }

    public class STOCK_BRANDTYPDETDataLayer
    {

        public static DataTable GetAllSTOCK_BRANDTYPEDETAILSDetailByCompany(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_BRANDTYPEDETAILSDetailByCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAll_BRANDTYPE_CODEWise_BRANDTYPE_DETAILS(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BRANDTYPE_CODE", Id, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAll_BRANDTYPE_CODEWise_BRANDTYPE_DETAILS", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }


    public class JOB_COMPMASDataLayer
    {
        public static string InsertJOB_COMPLAIN_MASDetail(JOB_COMPMASLogicLayer JobComplainMasDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLJobComplainMasDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(JobComplainMasDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, JobComplainMasDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLJobComplainMasDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@JobComplainMasDetails", strXMLJobComplainMasDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertJOB_COMPLAIN_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }

        public static string UpdateJOB_COMPLAIN_MASDetail(JOB_COMPMASLogicLayer JobComplainMasDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLJobComplainMasDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(JobComplainMasDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, JobComplainMasDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLJobComplainMasDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@JobComplainMasDetails", strXMLJobComplainMasDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateJOB_COMPLAIN_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteJOB_COMPLAIN_MASDetailByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMPLAIN_CODE", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteJOB_COMPLAIN_MASDetailByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static DataTable GetAllJOB_COMPLAIN_MASDetails(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllJOB_COMPLAIN_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllIDWiseJOB_COMPLAIN_MASDetail(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMPLAIN_CODE", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseJOB_COMPLAIN_MASDetail", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllJOB_COMPLAIN_MASDetialsFor_DDL()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllJOB_COMPLAIN_MASDetialsFor_DDL").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllJOB_COMPLAIN_MASDetialsByCompany(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllJOB_COMPLAIN_MASDetialsByCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


    }


    public class BRAND_COMPMASDataLayer
    {
        public static string InsertBRAND_COMPLAIN_MASDetail(BRAND_COMPMASLogicLayer BrandComplainMasDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLBrandComplainMasDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(BrandComplainMasDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, BrandComplainMasDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLBrandComplainMasDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BrandComplainMasDetails", strXMLBrandComplainMasDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertBRAND_COMPLAIN_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }

        public static string UpdateBRAND_COMPLAIN_MASDetail(BRAND_COMPMASLogicLayer BrandComplainMasDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLBrandComplainMasDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(BrandComplainMasDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, BrandComplainMasDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLBrandComplainMasDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BrandComplainMasDetails", strXMLBrandComplainMasDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateBRAND_COMPLAIN_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteBRAND_COMPLAIN_MASDetailByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMPLAIN_SRNO", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteBRAND_COMPLAIN_MASDetailByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllBRAND_COMPLAIN_MASDetail(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllBRAND_COMPLAIN_MASDetail", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllIDWiseBRAND_COMPLAIN_MASDetail(string ID)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMPLAIN_SRNO", ID, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseBRAND_COMPLAIN_MASDetail", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }

    public class OP_STOCK_BALDataLayer
    {
        public static string InsertSTOCK_OP_BALDetail(OP_STOCK_BALLogicLayer Stock_OpBalDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStock_OpBalDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Stock_OpBalDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, Stock_OpBalDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStock_OpBalDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Stock_OpBalDetails", strXMLStock_OpBalDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertSTOCK_OP_BALDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }

        }


        public static string UpdateBRAND_COMPLAIN_MASDetail(OP_STOCK_BALLogicLayer Stock_OpBalDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStock_OpBalDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Stock_OpBalDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, Stock_OpBalDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStock_OpBalDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Stock_OpBalDetails", strXMLStock_OpBalDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateSTOCK_OP_BALDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteSTOCK_OP_BALDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteSTOCK_OP_BALDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllIDWiseSTOCK_OP_BALDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseSTOCK_OP_BALDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllSTOCK_OP_BALDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_OP_BALDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }

    public class ACCOUNTS_STOCKMASDataLayer
    {
        public static string InsertACCOUNTS_STOCKMASDetail(ACCOUNTS_STOCKMASLogicLayer AccountStockMasDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLAccountStockMasDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(AccountStockMasDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, AccountStockMasDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLAccountStockMasDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@AccountStockMasDetails", strXMLAccountStockMasDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertACCOUNTS_STOCKMASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }

        }

        public static string UpdateACCOUNTS_STOCKMASDetail(ACCOUNTS_STOCKMASLogicLayer AccountStockMasDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLAccountStockMasDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(AccountStockMasDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, AccountStockMasDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLAccountStockMasDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@AccountStockMasDetails", strXMLAccountStockMasDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateACCOUNTS_STOCKMASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteACCOUNTS_STOCKMASDetailsByID(string COMP_CODE, string ACODE, string SCODE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteACCOUNTS_STOCKMASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllIDWiseACCOUNTS_STOCKMASDetials(string COMP_CODE, string ACODE, string SCODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseACCOUNTS_STOCKMASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllACCOUNTS_STOCKMASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllACCOUNTS_STOCKMASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllACCOUNTS_STOCKMASDetialsForGrid(string ACODE, string COMP_CODE, string USERCODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@UserCode", USERCODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllACCOUNTS_STOCKMASDetialsForGrid", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }





    public class STOCK_BRANDMASDataLayer
    {
        public static string InsertSTOCK_BRANDMASDetail(STOCK_BRANDMASLogicLayer StockBrandMasDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStockBrandMasDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(StockBrandMasDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, StockBrandMasDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStockBrandMasDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@StockBrandMasDetails", strXMLStockBrandMasDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertSTOCK_BRANDMASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }

        }


        public static string UpdateSTOCK_BRANDMASDetail(STOCK_BRANDMASLogicLayer StockBrandMasDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStockBrandMasDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(StockBrandMasDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, StockBrandMasDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStockBrandMasDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@StockBrandMasDetails", strXMLStockBrandMasDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateSTOCK_BRANDMASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteSTOCK_BRANDMASDetailByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BRAND_CODE", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteSTOCK_BRANDMASDetailByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }



        public static DataTable GetAllSTOCK_BRANDMASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_BRANDMASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }




        public static DataTable GetAllIDWiseSTOCK_BRANDMASDetail(string ID)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BRAND_CODE", ID, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseSTOCK_BRANDMASDetail", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetSTOCKBRANDMAS_BrandNameCompanyWiseFor_Ddl(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCKBRANDMAS_BrandNameCompanyWiseFor_Ddl", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }


    public class STOCK_MODELMASDataLayer
    {
        public static string InsertSTOCK_MODELMASDetail(STOCK_MODELMASLogicLayer StockModelMaster, string StockModelDetails, string DetailMap)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStockModelMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(StockModelMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, StockModelMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStockModelMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@StockModelMaster", strXMLStockModelMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@StockModelDetails", StockModelDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@StockModelCost", DetailMap, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertSTOCK_MODELMASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }

        }


        public static string UpdateSTOCK_MODELMASDetail(STOCK_MODELMASLogicLayer StockModelMaster, string StockModelDetails, string DetailMap)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLStockModelMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(StockModelMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, StockModelMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLStockModelMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@StockModelMaster", strXMLStockModelMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@StockModelDetails", StockModelDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@StockModelCost", DetailMap, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateSTOCK_MODELMASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }

        }



        public static string DeleteSTOCK_MODELMASDetailsByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@MODEL_CODE", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteSTOCK_MODELMASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }



        public static DataSet GetAllIDWiseSTOCK_MODELMASDetail(string ID)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@MODEL_CODE", ID, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseSTOCK_MODELMASDetail", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllSTOCK_MODELMASDetials(int USERCODE, int COMP_CODE, int BRAND_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@BRAND_CODE", BRAND_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_MODELMASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetSTOCK_MODELMAS_ModelNameCompanyWiseFor_Ddl(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_MODELMAS_ModelNameCompanyWiseFor_Ddl", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetSTOCK_MODELMAS_ModelNameBrandWiseFor_Ddl(string Id)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BRAND_CODE", Id, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_MODELMAS_ModelNameBrandWiseFor_Ddl", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetModelDescBymodelName(string MODEL_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@MODEL_CODE", MODEL_CODE, SqlDbType.BigInt);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetModelDescBymodelName", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllBRANDS_MODELSDetailByCompanyForGrid(string COMP_CODE, DateTime FromDate, DateTime ToDate)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.BigInt);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@FRMDATE", FromDate, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TODATE", ToDate, SqlDbType.DateTime);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllBRANDS_MODELSDetailByCompanyForGrid", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


    }

    public class STOCK_MODELCOSTDataLayer
    {
        public static DataTable GetAllSTOCK_MODELCOSTSDetailByCompany(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_MODELCOSTSDetailByCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAll_MODELCODEEWise_STOCK_MODELCOST(string MODEL_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@MODEL_CODE", MODEL_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAll_MODELCODEEWise_STOCK_MODELCOST", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }


    public class STOCK_MODELDETDataLayer
    {
        public static DataTable GetAllSTOCK_MODELDETDetailByCompany(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_MODELDETDetailByCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllSTOCK_MODELDETDetailByCompanyAndModelName(string COMP_CODE, string MODEL_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@MODEL_CODE", MODEL_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_MODELDETDetailByCompanyAndModelName", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAll_MODELCODEEWise_STOCK_MODELDET(string MODEL_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@MODEL_CODE", MODEL_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAll_MODELCODEEWise_STOCK_MODELDET", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }




    public class PARTY_MODELMASDataLayer
    {
        public static string InsertPARTY_MODELMASDetail(PARTY_MODELMASLogicLayer PARTY_MODELMASDetails, string DetailMap)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLPARTY_MODELMASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(PARTY_MODELMASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, PARTY_MODELMASDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLPARTY_MODELMASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@PARTY_MODELMASDetails", strXMLPARTY_MODELMASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@Detail", DetailMap, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertPARTY_MODELMASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string UpdatePARTY_MODELMASDetail(PARTY_MODELMASLogicLayer PARTY_MODELMASDetails, string DetailMap)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLPARTY_MODELMASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(PARTY_MODELMASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, PARTY_MODELMASDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLPARTY_MODELMASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@PARTY_MODELMASDetails", strXMLPARTY_MODELMASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@Detail", DetailMap, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdatePARTY_MODELMASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeletePARTY_MODELMASDetailsByID(string ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SRNO", ID, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeletePARTY_MODELMASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataSet GetAllIDWisePARTY_MODELMASDetail(string ID)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SRNO", ID, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWisePARTY_MODELMASDetail", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllPARTY_MODELMASDetail(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllPARTY_MODELMASDetail", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static string Get_model_srno(int acode, int comp_code)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@acode", acode, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@comp_code", comp_code, SqlDbType.Int);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "get_model_srno", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllPARTY_MODELMASDetailWisePartyName(string ACODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllPARTY_MODELMASDetailWisePartyName", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllPARTY_MODELMASDetailWisePartyNameForGrid(string ACODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllPARTY_MODELMASDetailWisePartyNameForGrid", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllIDWisePARTY_MODELMASDetailForDC(string SRNO)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SRNO", SRNO, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWisePARTY_MODELMASDetailForDC", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllIDWisePARTY_MODELMASDetailForJobcard(string SRNO)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SRNO", SRNO, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWisePARTY_MODELMASDetailForJobcard", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataSet GETAMC_MASDetailsForJobcardMsater(string ACODE,string PARTYREFSRNO)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@PARTYREFNO", PARTYREFSRNO, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GETAMC_MASDetailsForJobcardMsater", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


    }

    public class PARTY_MODELDETDataLayer
    {
        public static DataTable GetAllPARTY_MODELDETDetailByCompany(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllPARTY_MODELDETDetailByCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAll_PARTY_MODELDETWiseSrNo(string SRNO)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SRNO", SRNO, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAll_PARTY_MODELDETWiseSrNo", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllPARTY_MODELDETDetailByComapnyAndID(string COMP_CODE, string ACODE, string SRNO)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@SRNO", SRNO, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllPARTY_MODELDETDetailByComapnyAndID", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }


    public class QUOTATION_MDataLayer
    {

        public static string InsertQUOATATION_MASDetail(QUOTATION_MLogicLayer Quotation_M, string Quotation_T, string Quotation_C, string COMP_CODE, string BRANCH_CODE, string YRDT1)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLQuotation_M, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Quotation_M.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, Quotation_M);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLQuotation_M = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Quotation_M", strXMLQuotation_M, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@Quotation_T", Quotation_T, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@Quotation_C", Quotation_C, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertQUOATATION_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }

        }


        public static string UpdateQUOATATION_MASDetail(QUOTATION_MLogicLayer Quotation_M, string Quotation_T, string Quotation_C)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLQuotation_M, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Quotation_M.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, Quotation_M);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLQuotation_M = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Quotation_M", strXMLQuotation_M, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@Quotation_T", Quotation_T, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@Quotation_C", Quotation_C, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateQUOATATION_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }

        public static string DeleteQUOATATION_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteQUOATATION_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllQUOATATION_MASDetails(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllQUOATATION_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static string ADD_DISFLAG_FROMCOMPANY(int comp_code)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", comp_code, SqlDbType.Int);
                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_ADD_DISFLAG_FROMCOMPANY", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static string GetQuoNoQUOATATION_MASDetailCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string QuoDate)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@QuoDate", QuoDate, SqlDbType.DateTime);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_GetQuoNoQUOATATION_MASDetailCompanyBranchYearWise", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();


                return ex.Message;

            }
        }

        public static DataSet GetAllIDWiseQUOATATION_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseQUOATATION_MASDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllQUOATATION_MASDetialsByACODE(string COMP_CODE, string BRANCH_CODE, string ACODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllQUOATATION_MASDetialsByACODE", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



    }


    public class QUOTATION_TDataLayer
    {

        public static DataTable GetAllQUOTATION_TDetailByCompany(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllQUOTATION_TDetailByCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllQUOTATION_TAMCDetailByCompany(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllQUOTATION_TAMCDetailByCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }


    public class QUOTATION_CDataLayer
    {
        public static DataTable GetAllQUOTATION_CDetailByCompany(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllQUOTATION_CDetailByCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }

    public class ORDER_MASDataLayer
    {


        public static string InsertORDER_MASDetail(ORDER_MASLogicLayer Order_Master, string Order_Item, string Order_MasQoutation, string COMP_CODE, string BRANCH_CODE, string TRAN_TYPE , string YRDT1)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLOrder_Master, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Order_Master.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, Order_Master);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLOrder_Master = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@OrderMaster", strXMLOrder_Master, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OrderItem", Order_Item, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OrderMasQoutation", Order_MasQoutation, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertORDER_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }

        }


        public static string UpdateORDER_MASDetail(ORDER_MASLogicLayer Order_Master, string Order_Item, string Order_MasQoutation)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLOrder_Master, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Order_Master.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, Order_Master);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLOrder_Master = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@OrderMaster", strXMLOrder_Master, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OrderItem", Order_Item, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OrderMasQoutation", Order_MasQoutation, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateORDER_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }



        public static string DeleteORDER_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteORDER_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataSet GetAllIDWiseORDER_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseORDER_MASDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllORDER_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllORDER_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllSales_ORDER_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE)
        {
            DataTable GetAllDetail = new DataTable();
            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSales_ORDER_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static string GetOrderNoORDER_MASDetailCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string OrderDate , string TRAN_TYPE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[5];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OrderDate", OrderDate, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_GetOrderNoORDER_MASDetailCompanyBranchYearWise", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();


                return ex.Message;

            }
        }



        public static DataTable GetAllIDWisePO_DetialsForGrid(string COMP_CODE, string BRANCH_CODE, string ACODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWisePO_DetialsForGrid", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }

    public class ORDER_ITEMDataLayer
    {

        public static DataTable GetAllORDER_ITEMDetailByCompany(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllORDER_ITEMDetailByCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllWiseID_ORDER_MASDetail(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllWiseID_ORDER_MASDetail", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


    }


    public class DC_MASDataLayer
    {
        public static DataSet InsertDC_MASDetail(DC_MASLogicLayer DCMaster, string DCDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string TRN_TYPE)
        {
            DataSet Ds = new DataSet();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLDCMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(DCMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, DCMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLDCMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@DCMaster", strXMLDCMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@DCDetails", DCDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@TRN_TYPE", TRN_TYPE, SqlDbType.VarChar);

                Ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "USP_InsertDC_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return Ds;
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return null;
                }
                else
                {

                    return null;
                }
            }

        }

        public static DataSet UpdateDC_MASDetail(DC_MASLogicLayer DCMaster, string DCDetails)
        {

            DataSet Ds = new DataSet();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLDCMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(DCMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, DCMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLDCMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@DCMaster", strXMLDCMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@DCDetails", DCDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                Ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "USP_UpdateDC_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return Ds;

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return null;

            }
        }

        public static string DeleteDC_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteDC_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static DataSet GetAllIDWiseDC_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseDC_MASDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllDC_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE, string TRN_TYPE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TRN_TYPE", TRN_TYPE, SqlDbType.VarChar);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllDC_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static string GetSerialNoDC_MASDetailCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string ReceivedDate, string TRAN_TYPE, string TRN_TYPE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[6];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@REC_DATE", ReceivedDate, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@TRN_TYPE", TRN_TYPE, SqlDbType.VarChar);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_GetSerialNoDC_MASDetailCompanyBranchYearWise", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();


                return ex.Message;

            }
        }

        public static DataTable GetAllIDWiseDC_MasForPOGrid(string COMP_CODE, string BRANCH_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseDC_MasForPOGrid", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static string GenerateBracodeForPurchaseOrder(string p_Type, string p_comp_code, string p_branch_code, DateTime p_yrdt1, string p_grnno, string p_scode, string p_qty, string p_rate, string p_tran_type, DateTime p_tran_date, string p_tran_no, string p_srno)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[12];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_type", p_Type, SqlDbType.VarChar);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.BigInt);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.BigInt);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_grnno", p_grnno, SqlDbType.BigInt);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.BigInt);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_qty", p_qty, SqlDbType.Float);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_rate", p_rate, SqlDbType.Float);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@p_tran_type", p_tran_type, SqlDbType.VarChar);
                paramsToStore[9] = ControllersHelper.GetSqlParameter("@p_tran_date", p_tran_date, SqlDbType.DateTime);
                paramsToStore[10] = ControllersHelper.GetSqlParameter("@p_tran_no", p_tran_no, SqlDbType.BigInt);
                paramsToStore[11] = ControllersHelper.GetSqlParameter("@p_srno", p_srno, SqlDbType.BigInt);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "generate_barcode", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return "success";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                return ex.Message;
            }
        }

        public static string WORK_VIEWFLAG_FROMCOMPANY(int comp_code)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", comp_code, SqlDbType.Int);
                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_WORK_VIEWFLAG_FROM_COMPANY", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "";
                }
                else
                {
                    return ex.Message;
                }
            }
        }



        public static DataTable GetAllDC_MasWiseComapnyAndACodeForTaxInvoiceBill(string COMP_CODE, string BRANCH_CODE, string ACODE, string TRAN_TYPE, string TRN_TYPE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[5];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@TRN_TYPE", TRN_TYPE, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllDC_MasWiseComapnyAndACodeForTaxInvoiceChallanBill", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetGRNBarcode(string comp_code, DateTime TRAN_DATE, string TRAN_NO)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@comp_code", comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetGRNBarcode_ForPrint", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        // DC_SALES_MASER DATALAYER

        public static string InsertDC_SALES_MASDetail(DC_MASLogicLayer DCMaster, string DCDetails, string ExtraDCDetails, string BarcodeDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string TRN_TYPE)
        {



            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLDCMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(DCMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, DCMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLDCMaster = xd.InnerXml;



            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[10];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@DCMaster", strXMLDCMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@DCDetails", DCDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@ExtraDCDetails", ExtraDCDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@BarcodeDetails", BarcodeDetails, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[9] = ControllersHelper.GetSqlParameter("@TRN_TYPE", TRN_TYPE, SqlDbType.VarChar);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertDC_SALES_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {


                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }

        }


        public static string UpdateDC_SALES_MASDetail(DC_MASLogicLayer DCMaster, string DCDetails, string BarcodeDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLDCMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(DCMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, DCMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLDCMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@DCMaster", strXMLDCMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@DCDetails", DCDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@BarcodeDetails", BarcodeDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateDC_SALES_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteDC_SALES_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteDC_SALES_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static string GetChallanNoDC_MASDetailCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string ChallanDate, string TRAN_TYPE, string TRN_TYPE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[6];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@CHA_DT", ChallanDate, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@TRN_TYPE", TRN_TYPE, SqlDbType.VarChar);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_GetChallanNumber", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();


                return ex.Message;

            }
        }


        public static DataTable GetAllDC_SALES_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE, string TRN_TYPE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TRN_TYPE", TRN_TYPE, SqlDbType.VarChar);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllDC_SALES_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataSet GetAllIDWiseDC_SALES_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseDC_SALES_MASDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllDC_MasWiseComapnyAndACodeForSalesInvoice(string COMP_CODE, string BRANCH_CODE, string ACODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllDC_MasWiseComapnyAndACodeForSalesInvoice", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static string UpdateDC_MAS_StatusWhenGenerateBill(DateTime TRAN_DATE, string TRAN_NO)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);

                //paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                //paramsToStore[3] = ControllersHelper.GetSqlParameter("@TRN_TYPE", TRN_TYPE, SqlDbType.VarChar);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateDC_MAS_StatusWhenGenerateBill", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        // DC_MAS FOR PURCHASE RETURN (DC_SALES)


        public static string InsertPurchaseReturn_DeliveryChallan_MASDetail(DC_MASLogicLayer DCMaster, string DCDetails, string ExtraDCDetails, string BarcodeDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string TRN_TYPE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLDCMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(DCMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, DCMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLDCMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[10];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@DCMaster", strXMLDCMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@DCDetails", DCDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@ExtraDCDetails", ExtraDCDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@BarcodeDetails", BarcodeDetails, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[9] = ControllersHelper.GetSqlParameter("@TRN_TYPE", TRN_TYPE, SqlDbType.VarChar);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertPurchaseReturn_DeliveryChallan_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {


                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }

        }


        public static DataTable GetAllPurchaseReturn_DC_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE, string TRN_TYPE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TRN_TYPE", TRN_TYPE, SqlDbType.VarChar);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllPurchaseReturn_DC_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


    }


    public class DC_DETDataLayer
    {
        public static DataTable GetAllDC_DetailByCompany(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllDC_DetailByCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllWiseID_DC_DET_Detail(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllWiseID_DC_DET_Detail", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllDC_DetailByCompanyForSales(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllDC_DetailByCompanyForSales", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }


    public class BARCODE_MASDataLayer

    {
        public static DataTable GetStockWiseBarcodeDetailsFor_Grid(string COMP_CODE, string BRANCH_CODE, string TRAN_NO, DateTime TRAN_DATE, string SCODE, string SRNO)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[6];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@SRNO", SRNO, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetStockWiseBarcodeDetailsFor_Grid", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetBarcodeDetail_WiseBarcodeNo(string BARCODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BARCODE", BARCODE, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetBarcodeDetail_WiseBarcodeNo", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetBarcodeDetail_ForDeAssembleTransaction(string BARCODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BARCODE", BARCODE, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetBarcodeDetail_ForDeAssembleTransaction", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetBarcodeDetailsFor_DeAseembleBarcodeGrid(string COMP_CODE, string BRANCH_CODE, string TRAN_NO, DateTime TRAN_DATE, string SRNO)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[5];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@SRNO", SRNO, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetBarcodeDetailsFor_DeAseembleBarcodeGrid", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }

    public class DC_MAS_BARCODEDataLayer
    {

    }



    public class ASS_TRANMASDataLayer
    {

        public static string InsertASSEMBLE_TRAN_MASDetailNew(ASS_TRANMASLogicLayer ASS_TRANMaster, string ASS_TRANDetails, string BarcodeDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string WORK_VIEWFLAG)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLASS_TRANMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ASS_TRANMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ASS_TRANMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLASS_TRANMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[9];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ASS_TRANMaster", strXMLASS_TRANMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@ASS_TRANDetails", ASS_TRANDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@BarcodeDetails", BarcodeDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@WORK_VIEWFLAG", WORK_VIEWFLAG, SqlDbType.VarChar);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertASSEMBLE_TRAN_MASDetailNew", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {


                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }

        }



        public static string UpdateASSEMBLE_TRAN_MASDetail(ASS_TRANMASLogicLayer ASS_TRANMaster, string ASS_TRANDetails, string BarcodeDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string WORK_VIEWFLAG)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLASS_TRANMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ASS_TRANMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ASS_TRANMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLASS_TRANMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[9];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ASS_TRANMaster", strXMLASS_TRANMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@ASS_TRANDetails", ASS_TRANDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@BarcodeDetails", BarcodeDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@WORK_VIEWFLAG", WORK_VIEWFLAG, SqlDbType.VarChar);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateASSEMBLE_TRAN_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteASSEMBLE_TRAN_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteASSEMBLE_TRAN_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static string GetSrNo_ForAssembleTransaction(string COMP_CODE, string BRANCH_CODE, string YRDT1, string AssembleDate, string TRAN_TYPE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[5];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TRNDT", AssembleDate, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_GetSrNo_ForAssembleTransaction", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();


                return ex.Message;

            }
        }



        public static DataTable GetAllASSEMBLE_TRAN_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllASSEMBLE_TRAN_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetAllIDWiseASSEMBLE_TRAN_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetAllIDWiseASSEMBLE_TRAN_MASDetialsNew", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }




        // DE-ASSEMBLE TRANSACTION MATER DATALAYER


        public static DataSet InsertDE_ASSEMBLE_TRAN_MASDetail(ASS_TRANMASLogicLayer ASS_TRANMaster, string ASS_TRANDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE)
        {
            DataSet Ds = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLASS_TRANMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ASS_TRANMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ASS_TRANMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLASS_TRANMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ASS_TRANMaster", strXMLASS_TRANMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@ASS_TRANDetails", ASS_TRANDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);


                Ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "USP_InsertDE_ASSEMBLE_TRAN_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return Ds;
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return null;
                }
                else
                {

                    return null;
                }
            }

        }


        public static DataSet UpdateDE_ASSEMBLE_TRAN_MASDetail(ASS_TRANMASLogicLayer ASS_TRANMaster, string ASS_TRANDetails)
        {
            DataSet Ds = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLASS_TRANMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ASS_TRANMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ASS_TRANMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLASS_TRANMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ASS_TRANMaster", strXMLASS_TRANMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@ASS_TRANDetails", ASS_TRANDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                Ds = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "USP_UpdateDE_ASSEMBLE_TRAN_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return Ds;

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return null;

            }
        }



        public static DataTable GetAllDE_ASSEMBLE_TRAN_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllDE_ASSEMBLE_TRAN_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetAllIDWiseDE_ASSEMBLE_TRAN_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseDE_ASSEMBLE_TRAN_MASDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }


    public class STK_IRMASDataLayer
    {

        public static string InsertSTOCK_ISSUE_BRANCH_MASDetail(STK_IRMASLogicLayer STK_IRMASMaster, string STK_IRDETDetails, string BarcodeDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLSTK_IRMASMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(STK_IRMASMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, STK_IRMASMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLSTK_IRMASMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@STK_IRMASMaster", strXMLSTK_IRMASMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@STK_IRDETDetails", STK_IRDETDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@BarcodeDetails", BarcodeDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);



                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertSTOCK_ISSUE_BRANCH_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {


                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }

        }


        public static string UpdateSTOCK_ISSUE_BRANCH_MASDetail(STK_IRMASLogicLayer STK_IRMASMaster, string STK_IRDETDetails, string BarcodeDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string WORK_VIEWFLAG)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLSTK_IRMASMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(STK_IRMASMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, STK_IRMASMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLSTK_IRMASMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[9];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@STK_IRMASMaster", strXMLSTK_IRMASMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@STK_IRDETDetails", STK_IRDETDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@BarcodeDetails", BarcodeDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@WORK_VIEWFLAG", WORK_VIEWFLAG, SqlDbType.VarChar);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateSTOCK_ISSUE_BRANCH_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteSTOCK_ISSUE_TO_BRANCHDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteSTOCK_ISSUE_TO_BRANCHDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static DataSet GetAllIDWiseSTOCK_ISSUE_BRANCH_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "usp_GetAllIDWiseSTOCK_ISSUE_BRANCH_MASDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllSTOCK_ISSUE_BRANCH_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_ISSUE_BRANCH_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static string GetChal_NoSTOCK_IRMASDetailCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string ChallanDtae, string TRAN_TYPE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[5];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@CHA_DT", ChallanDtae, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
             
                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_GetChal_NoSTOCK_IRMASDetailCompanyBranchYearWise", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();


                return ex.Message;

            }

        }



        public static DataTable GetPartytypeGSTApplicableBranchWise(string COMP_CODE, string FROM_BRANCH, string TO_BRANCH, DateTime INI_DATE)
        {
            DataTable Dt = new DataTable();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CompCode", COMP_CODE, SqlDbType.Float);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@FromBranch", FROM_BRANCH, SqlDbType.Float);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@ToBranch", TO_BRANCH, SqlDbType.Float);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@InitDate", INI_DATE, SqlDbType.DateTime);


                Dt = SqlHelper.ExecuteDataset(trn, CommandType.StoredProcedure, "USP_GetPartytypeGSTApplicableBranchWise", paramsToStore).Tables[0];
                trn.Commit();
                con.Close();
                return Dt;

            }
            catch (Exception ex)
            {


                trn.Rollback();
                con.Close();

                return null;
            }

        }


        public static DataSet GetDeAssemblyBarcode(string comp_code, DateTime TRAN_DATE, string TRAN_NO)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@comp_code", comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetDeAssemblyBarcode_ForPrint", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



    }

    public class STK_IRDETDataLayer
    {
    }

    public class STK_IRMAS_BARCODEDataLayer
    {

    }

    public class BRANCH_RECMASDataLayer
    {


        public static string UpdateBRANCH_REC_MASDetail(BRANCH_RECMASLogicLayer BRANCH_RECMASMaster)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLBRANCH_RECMASMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(BRANCH_RECMASMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, BRANCH_RECMASMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLBRANCH_RECMASMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BRANCH_RECMaster", strXMLBRANCH_RECMASMaster, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateBRANCH_REC_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static DataTable GetAllBRANCH_REC_MASDetails(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllBRANCH_REC_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetAllIDWiseBRANCH_REC_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseBRANCH_REC_MASDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetAllBRANCH_RECMAS_BARCODEDetailByCompanyAndBranch(string COMP_CODE, string BRANCH_CODE, string TRAN_NO, DateTime TRAN_DATE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllBRANCH_RECMAS_BARCODEDetailByCompanyAndBranch", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }


    public class BRANCH_TRANMASDataLayer
    {

        public static string InsertSERVICE_ISSUE_TOBRANCH_MASDetail(BRANCH_TRANMASLogicLayer BRANCH_TRANMASMaster, string BRANCH_TRAN_PARTYDetails, string BRANCH_TRANDETDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLBRANCH_TRANMASMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(BRANCH_TRANMASMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, BRANCH_TRANMASMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLBRANCH_TRANMASMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BRANCH_TRANMASMaster", strXMLBRANCH_TRANMASMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_TRAN_PARTYDetails", BRANCH_TRAN_PARTYDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@BRANCH_TRANDETDetails", BRANCH_TRANDETDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertSERVICE_ISSUE_TOBRANCH_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {


                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }

        }

        public static string UpdateSERVICE_ISSUE_BRANCH_MASDetail(BRANCH_TRANMASLogicLayer BRANCH_TRANMASMaster, string BRANCH_TRAN_PARTYDetails, string BRANCH_TRANDETDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLBRANCH_TRANMASMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(BRANCH_TRANMASMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, BRANCH_TRANMASMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLBRANCH_TRANMASMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@BRANCH_TRANMASMaster", strXMLBRANCH_TRANMASMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_TRAN_PARTYDetails", BRANCH_TRAN_PARTYDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@BRANCH_TRANDETDetails", BRANCH_TRANDETDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateSERVICE_ISSUE_BRANCH_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }

        public static string DeleteSERVICE_ISSUE_TO_BRANCHDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteSERVICE_ISSUE_TO_BRANCHDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static string GetSerialNumberForServiceIssueToBranch(string COMP_CODE, string BRANCH_CODE, string YRDT1, string ServiceDate)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TRNDT", ServiceDate, SqlDbType.DateTime);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_GetSerialNumberForServiceIssueToBranch", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();


                return ex.Message;

            }
        }

        public static DataSet GetAllIDWiseSERVICE_ISSUE_BRANCH_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseSERVICE_ISSUE_BRANCH_MASDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllSERVICE_ISSUE_BRANCH_MASDetails(int USERCODE, int COMP_CODE, int BRANCH_CODE, string Service_Type)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@Service_Type", Service_Type, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSERVICE_ISSUE_BRANCH_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }



    public class INDENT_MASDataLayer
    {
        public static string InsertSTOCK_INDENT_ISSUE_TOBRANCH_MASDetail(INDENT_MASLogicLayer INDENT_MASMaster, string INDENT_DETDetails, string INDENT_CATDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLINDENT_MASMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(INDENT_MASMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, INDENT_MASMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLINDENT_MASMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@INDENT_MASMaster", strXMLINDENT_MASMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@INDENT_DETDetails", INDENT_DETDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@INDENT_CATDetails", INDENT_CATDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertSTOCK_INDENT_ISSUE_TOBRANCH_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {


                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }

        }


        public static string UpdateSTOCK_INDENT_ISSUE_TOBRANCH_MASDetail(INDENT_MASLogicLayer INDENT_MASMaster, string INDENT_DETDetails, string INDENT_CATDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLINDENT_MASMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(INDENT_MASMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, INDENT_MASMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLINDENT_MASMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@INDENT_MASMaster", strXMLINDENT_MASMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@INDENT_DETDetails", INDENT_DETDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@INDENT_CATDetails", INDENT_CATDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateSTOCK_INDENT_ISSUE_TOBRANCH_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }



        public static string GetIndentNumberForStockIndentIssueToBranch(string COMP_CODE, string BRANCH_CODE, string YRDT1, string IndentDate)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@INDDT", IndentDate, SqlDbType.DateTime);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_GetIndentNumberForStockIndentIssueToBranch", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();


                return ex.Message;

            }
        }


        public static DataTable GetAllSTOCK_INDENT_ISSUE_BRANCH_MASDetails(int USERCODE, int COMP_CODE, int BRANCH_CODE, string Indent_BranchType)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@Indent_BranchType", Indent_BranchType, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSTOCK_INDENT_ISSUE_BRANCH_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetAllIDWiseSTOCK_INDENT_ISSUE_BRANCH_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseSTOCK_INDENT_ISSUE_BRANCH_MASDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }


    public class REC_ISS_MDataLayer
    {

        public static string InsertREC_ISS_MASDetail(REC_ISS_MLogicLayer REC_ISS_Master, string REC_ISS_TDetails, string REC_ISS_ChargesDetails, string REC_BarcodeDetails, string REC_DC_MASTER_Details, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string TRN_TYPE)

        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLREC_ISS_Master, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(REC_ISS_Master.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, REC_ISS_Master);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLREC_ISS_Master = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[11];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@REC_ISS_Master", strXMLREC_ISS_Master, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@REC_ISS_TDetails", REC_ISS_TDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@REC_ISS_ChargesDetails", REC_ISS_ChargesDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@REC_BarcodeDetails", REC_BarcodeDetails, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@REC_DC_MASTER_Details", REC_DC_MASTER_Details, SqlDbType.Xml);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[9] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[10] = ControllersHelper.GetSqlParameter("@TRN_TYPE", TRN_TYPE, SqlDbType.VarChar);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertREC_ISS_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {


                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }

        }



        public static string UpdateREC_ISS_MASDetail(REC_ISS_MLogicLayer REC_ISS_Master, string REC_ISS_TDetails, string REC_ISS_ChargesDetails, string REC_BarcodeDetails, string REC_DC_MASTER_Details, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string TRN_TYPE)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLREC_ISS_Master, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(REC_ISS_Master.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, REC_ISS_Master);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLREC_ISS_Master = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[11];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@REC_ISS_Master", strXMLREC_ISS_Master, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@REC_ISS_TDetails", REC_ISS_TDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@REC_ISS_ChargesDetails", REC_ISS_ChargesDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@REC_BarcodeDetails", REC_BarcodeDetails, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[9] = ControllersHelper.GetSqlParameter("@TRN_TYPE", TRN_TYPE, SqlDbType.VarChar);
                paramsToStore[10] = ControllersHelper.GetSqlParameter("@REC_DC_MASTER_Details", REC_DC_MASTER_Details, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateREC_ISS_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteSREC_ISS_M_DetailsTaxInvoiceByID(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteSREC_ISS_M_DetailsTaxInvoiceByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static string GetInvoiceNumber(string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE, string TRN_TYPE, string InvoiceDate)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[6];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@TRN_TYPE", TRN_TYPE, SqlDbType.VarChar);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@INV_DT", InvoiceDate, SqlDbType.DateTime);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_GetInvoiceNumber", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();


                return ex.Message;

            }
        }


        public static DataTable GetAllREC_ISS_M_DetailsForTaxInvoice(int USERCODE, int COMP_CODE, string TRAN_TYPE, string TRN_TYPE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TRN_TYPE", TRN_TYPE, SqlDbType.VarChar);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllREC_ISS_M_DetailsForTaxInvoice", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetAllIDWiseREC_ISS_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseREC_ISS_MASDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetGSTRATEGroupByTaxableAmoutForReport(DateTime TRAN_DATE, string TRAN_NO)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetGSTRATEGroupByTaxableAmoutForReport", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetAllIDWiseREC_ISS_MASDetialsForJobcard(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@REF_TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@REF_TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseREC_ISS_MASDetialsForJobcard", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }





        public static string DeleteREC_ISS_M_DetailByIDForJobacard(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@REF_TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@REF_TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteREC_ISS_M_DetailByIDForJobacard", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


    }


    public class AMC_RATEMASDataLayer
    {
        public static string InsertAMC_RATE_MASDetail(AMC_RATEMASLogicLayer AMC_RATEMaster, string AMC_RATEDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLAMC_RATEMaster, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(AMC_RATEMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, AMC_RATEMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLAMC_RATEMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                string str = "";
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@AMC_RATEMaster", strXMLAMC_RATEMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@AMC_RATEDetails", AMC_RATEDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_InsertAMC_RATE_MASDetail", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string UpdateAMC_RATE_MASDetail(AMC_RATEMASLogicLayer AMC_RATEMaster, string AMC_RATEDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLAMC_RATEMaster, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(AMC_RATEMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, AMC_RATEMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLAMC_RATEMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@AMC_RATEMaster", strXMLAMC_RATEMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@AMC_RATEDetails", AMC_RATEDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateAMC_RATE_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteAMC_RATE_MASDetailsByID(string SRNO)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SRNO", SRNO, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteAMC_RATE_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static DataSet GetAllIDWiseAMC_RATE_MASDetail(string SRNO)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SRNO", SRNO, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseAMC_RATE_MASDetail", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllAMC_RATE_MASDetail(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllAMC_RATE_MASDetail", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



    }

    public class WORK_LISTMASDataLayer
    {
        public static string InsertWORK_LISTMAS(WORK_LISTMASLogicLayer WORK_LISTMASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLWORK_LISTMASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(WORK_LISTMASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, WORK_LISTMASDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLWORK_LISTMASDetails = xd.InnerXml;
            string str = "";
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@WORK_LISTMASDetails", strXMLWORK_LISTMASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                str = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertWORK_LISTMAS", paramsToStore).ToString();
                trn.Commit();
                con.Close();

                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static DataTable GetAllWork_List_MASDetail(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllWORKLISTDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllIDWiseWorklistdetails(string workcode)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Workcode", workcode, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseWorklistdetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static string UpdateWORK_LISTMASDetails(WORK_LISTMASLogicLayer Work_ListDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLWork_ListDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Work_ListDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, Work_ListDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLWork_ListDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@WORK_LISTMASDetails", strXMLWork_ListDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateWORK_LISTMASDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }

        public static string DeleteWORKLISTByID(string WORKCODE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@WORK_CODE", WORKCODE, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteWORKLISTByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static DataTable GetWORK_LISTMASDetailsCompanyWise(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetWORK_LISTMASDetailsCompanyWise", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }

    public class DAILY_WORKMASDataLayer
    {
        public static string InsertDAILY_WORKMASDetail(DAILY_WORKMASLogicLayer DailyWorkMaster, string DailyWorkDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLDailyWorkMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(DailyWorkMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, DailyWorkMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLDailyWorkMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[6];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@DailyWorkMaster", strXMLDailyWorkMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@DailyWorkDetails", DailyWorkDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertDAILY_WORKMASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }

        }




        public static string GetSrNoDAILY_WORKMASCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRNDT)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TRNDT", TRNDT, SqlDbType.DateTime);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_GetSrNoDAILY_WORKMASCompanyBranchYearWise", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();


                return ex.Message;

            }
        }


        public static string UpdateDAILY_WORKMASDetail(DAILY_WORKMASLogicLayer DailyWorkMaster, string DailyWorkDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLDailyWorkMaster, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(DailyWorkMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, DailyWorkMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLDailyWorkMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@DailyWorkMaster", strXMLDailyWorkMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@DailyWorkDetails", DailyWorkDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateDAILY_WORKMASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }

        public static string DeleteDAILY_WORKMASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteDAILY_WORKMASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllDAILY_WORKMASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllDAILY_WORKMASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetAllIDWiseDAILY_WORKMASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseDAILY_WORKMASDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


    }

    public class AMC_MASDataLayer
    {

        public static string InsertAMC_MASDetail(AMC_MASLogicLayer AMCMaster, string AMCDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string AMC_TYPE)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLAMCMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(AMCMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, AMCMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLAMCMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@AMCMaster", strXMLAMCMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@AMCDetails", AMCDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@AMC_TYPE", AMC_TYPE, SqlDbType.VarChar);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertAMC_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();

                return "Details successfully Added...";
            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }

        }



        public static string GetAmcNumber_AMC_MASCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string AMC_DATE, string AMC_TYPE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[5];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@AMC_DATE", AMC_DATE, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@AMC_TYPE", AMC_TYPE, SqlDbType.VarChar);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_GetAmcNumber_AMC_MASCompanyBranchYearWise", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();


                return ex.Message;

            }
        }


        public static string DeleteAMC_MASByID(string TRAN_NO, DateTime TRAN_DATE , string AMC_TYPE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@AMC_TYPE", AMC_TYPE, SqlDbType.VarChar);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteAMC_MASByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static DataSet GetAllIDWiseAMC_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseAMC_MASDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static string UpdateAMC_MASDetail(AMC_MASLogicLayer AMCMaster, string AMCDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLAMCMaster, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(AMCMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, AMCMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLAMCMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@AMCMaster", strXMLAMCMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@AMCDetails", AMCDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateAMC_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static DataTable GetAllAMC_MASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllAMC_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllWARRANTY_MASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllWARRANTY_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable generate_service_bill_record(string p_type, string Comp_Code, string Tran_Date, string Tran_No, string Billing_Terms)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[5];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_type", p_type, SqlDbType.VarChar);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_comp_code", Comp_Code, SqlDbType.Int);             
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_tran_date", Tran_Date, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_tran_no", Tran_No, SqlDbType.Int);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_terms", Billing_Terms, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "generate_service_bill_record", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }




        public static DataTable generate_service_record(string p_type, string Comp_Code, string Tran_Date, string Tran_No, string p_srno, string p_visit)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[6];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_type", p_type, SqlDbType.VarChar);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_comp_code", Comp_Code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_tran_date", Tran_Date, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_tran_no", Tran_No, SqlDbType.Int);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_srno", p_srno, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_visit", p_visit, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "generate_service_record", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


    }




    public class AMC_SERVICE_DETDataLayer
    {
        public static DataTable GetAllAMC_SERVICE_DetialsForGrid(string COMP_CODE, DateTime TRAN_DATE ,string TRAN_NO , string SRNO)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@SRNO", SRNO, SqlDbType.Int);
              


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllAMC_SERVICE_DetialsForGrid", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }



    public class job_cancelMASDataLayer
    {
        public static string InsertJOBCANCLEMASTER(job_cancelmasLogicLayer JOBCANCLEMASTERMASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLJOBCANCLEMASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(JOBCANCLEMASTERMASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, JOBCANCLEMASTERMASDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLJOBCANCLEMASDetails = xd.InnerXml;
            string str = "";
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@JOB_CANCLEMASDetails", strXMLJOBCANCLEMASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_InsertJOBCANCLEMASTER", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static DataTable GetAllJOB_CANCLE_MASDetail(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllJOB_CANCLEDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllIDWiseJOBCANCLEdetails(string cancel_code)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@cancel_code", cancel_code, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWisejobcancledetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static string UpdateWORK_LISTMASDetails(job_cancelmasLogicLayer JOB_CANCLEDETAILS)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLJOB_CANCLEDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(JOB_CANCLEDETAILS.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, JOB_CANCLEDETAILS);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLJOB_CANCLEDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@JOB_CANCLEMASDetails", strXMLJOB_CANCLEDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateJOB_CANCLEMASDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }

        public static string DeleteWORKLISTByID(string cancel_code)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@cancel_code", cancel_code, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteJOBCANCLEByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        public static DataTable GetAllJOB_CancelMasterByCompany(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllJOB_CancelMasterByCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }

    public class PARTY_STOCK_MASDataLayer
    {
        public static DataTable GetPartyStockMasterDetailsFilterByACODE(string COMP_CODE,string ACODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetPartyStockMasterDetailsFilterByACODE", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }


    public class JOBCARD_MASDataLayer
    {

        public static string InsertJOBCARD_MASDetail(JOBCARD_MASLogicLayer JOBCARDMaster,string JOBCARD_COMPLAINDetails, string JOBCARD_SERVICEDetails, string JOBCARD_REMARKDetails, string JOBCARD_SERVICE_USE_ITEMDetails, string JOBCARD_LAB_CHARGEDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLJOBCARDMaster, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(JOBCARDMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, JOBCARDMaster);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLJOBCARDMaster = xd.InnerXml;
            string str = "";
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[10];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@JOBCARDMaster", strXMLJOBCARDMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@JOBCARD_COMPLAINDetails", JOBCARD_COMPLAINDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@JOBCARD_SERVICEDetails", JOBCARD_SERVICEDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@JOBCARD_REMARKDetails", JOBCARD_REMARKDetails, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@JOBCARD_SERVICE_USE_ITEMDetails", JOBCARD_SERVICE_USE_ITEMDetails, SqlDbType.Xml);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@JOBCARD_LAB_CHARGEDetails", JOBCARD_LAB_CHARGEDetails, SqlDbType.Xml);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[9] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);


                str = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertJOBCARD_MASDetail", paramsToStore).ToString();
                trn.Commit();
                con.Close();

                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }


        public static string UpdateJOBCARD_MASDetail(JOBCARD_MASLogicLayer JOBCARDMaster, string JOBCARD_COMPLAINDetails, string JOBCARD_SERVICEDetails, string JOBCARD_REMARKDetails, string JOBCARD_SERVICE_USE_ITEMDetails, string JOBCARD_LAB_CHARGEDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLJOBCARDMaster, strXMLQutPut = "<root></root>";

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(JOBCARDMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, JOBCARDMaster);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLJOBCARDMaster = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[7];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@JOBCARDMaster", strXMLJOBCARDMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@JOBCARD_COMPLAINDetails", JOBCARD_COMPLAINDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@JOBCARD_SERVICEDetails", JOBCARD_SERVICEDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@JOBCARD_REMARKDetails", JOBCARD_REMARKDetails, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@JOBCARD_SERVICE_USE_ITEMDetails", JOBCARD_SERVICE_USE_ITEMDetails, SqlDbType.Xml);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@JOBCARD_LAB_CHARGEDetails", JOBCARD_LAB_CHARGEDetails, SqlDbType.Xml);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateJOBCARD_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }



        public static string GetJOBCARDNumber_JOBCARDMASCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string JOBCARD_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@JOBCARD_DATE", JOBCARD_DATE, SqlDbType.DateTime);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_GetJOBCARDNumber_JOBCARDMASCompanyBranchYearWise", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();


                return ex.Message;

            }
        }


        public static DataSet GetAllIDWiseJOBCARD_MASTERDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseJOBCARD_MASTERDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetAllJOBCARD_MASTERDetails(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllJOBCARD_MASTERDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetLastJOBCARD_MASDetailsOnAcodeAndPartyRefNo(string ACODE, string PARTY_REFNO)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@PARTY_REFNO", PARTY_REFNO, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetLastJOBCARD_MASDetailsOnAcodeAndPartyRefNo", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static string DeleteJOBCARD_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteJOBCARD_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetIDWiseJOBCARD_MASForServiceBillDetails(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetIDWiseJOBCARD_MASForServiceBillDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static string jobcard_mas_with_rec_iss_m(string JOBCARDMaster, string JOBCARD_LAB_CHARGEDetails, string YRDT1, string YRDT2, string USER_ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLJOBCARDMaster, strXMLQutPut = "<root></root>";
            //System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(JOBCARDMaster.GetType());
            //System.IO.MemoryStream stream = new System.IO.MemoryStream();
            //x.Serialize(stream, JOBCARDMaster);
            //stream.Position = 0;
            //XmlDocument xd = new XmlDocument();
            //xd.Load(stream);
            //strXMLJOBCARDMaster = xd.InnerXml;
            string str = "";
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[6];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@JOBCARD_MASDetails", JOBCARDMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@JOBCARD_LAB_CHARGEDetails", JOBCARD_LAB_CHARGEDetails, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@YRDT2", YRDT2, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@UserId", USER_ID, SqlDbType.Int);


                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_jobcard_mas_with_rec_iss_m", paramsToStore).ToString();
                trn.Commit();
                con.Close();

                return str;

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }

    }



    public class jobcard_assign_logDataLayer
    {
        public static DataTable GetJOBCARD_ASSIGN_LOGDetailsForGrid(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetJOBCARD_ASSIGN_LOGDetailsForGrid", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }
    }





    public class PAY_REC_MDataLayer
    {
        public static string InsertPAY_REC_MDetail(PAY_REC_MLogicLayer PayReceiveMaster, string PAY_REC_Details, string PAY_REC_INVDetails, string COMP_CODE, string BRANCH_CODE, string YRDT1, string TRAN_TYPE)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLPayReceiveMaster, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(PayReceiveMaster.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, PayReceiveMaster);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLPayReceiveMaster = xd.InnerXml;
            string str = "";
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@PAY_REC_Master", strXMLPayReceiveMaster, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@PAY_REC_Details", PAY_REC_Details, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@PAY_REC_INVDetails", PAY_REC_INVDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime); 
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);



                str = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertPAY_REC_MDetail", paramsToStore).ToString();
                trn.Commit();
                con.Close();

                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {

                    return ex.Message;
                }
            }
        }



        public static string UpdatePAY_REC_MASDetail(PAY_REC_MLogicLayer PAY_REC_Master, string PAY_REC_Details, string PAY_REC_INVDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLPAY_REC_Master, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(PAY_REC_Master.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, PAY_REC_Master);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLPAY_REC_Master = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@PAY_REC_Master", strXMLPAY_REC_Master, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@PAY_REC_Details", PAY_REC_Details, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@PAY_REC_INVDetails", PAY_REC_INVDetails, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdatePAY_REC_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }





        public static string UpdatePAY_REC_TDetailForBANK_RECO(string COMP_CODE ,string TRAN_NO , DateTime TRAN_DATE , string SR_NO, DateTime BANK_DATE , string REMARK)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
         

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[6];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@SR_NO", SR_NO, SqlDbType.Int);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@BANK_DATE", BANK_DATE, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@REMARK", REMARK, SqlDbType.VarChar);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdatePAY_REC_TDetailForBANK_RECO", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeletePAY_REC_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeletePAY_REC_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }



        public static string GetVoucherNumber_PAY_REC_MASCompanyBranchYearWise(string COMP_CODE, string BRANCH_CODE, string YRDT1, string VOU_DATE, string TRAN_TYPE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string str;
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[5];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@VOU_DATE", VOU_DATE, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);

                str = SqlHelper.ExecuteScalar(trn, CommandType.StoredProcedure, "USP_GetVoucherNumber_PAY_REC_MASCompanyBranchYearWise", paramsToStore).ToString();
                trn.Commit();
                con.Close();
                return str;

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();


                return ex.Message;

            }
        }


        public static DataSet GetAllIDWisePAY_REC_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWisePAY_REC_MASDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetAllPAY_REC_MASDetails(int USERCODE, int COMP_CODE, string TRAN_TYPE, string ACODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllPAY_REC_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllPAY_REC_MDetials(int USERCODE, int COMP_CODE, string TRAN_TYPE )
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllPAY_REC_MDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllPAY_REC_MASDetailsForBankReco(int USERCODE, int COMP_CODE, string ACODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllPAY_REC_MASDetailsForBankReco", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetPaidRecordForPAY_REC_INV(int p_branch_code, int pay_rec_t_acode,int p_comp_code, DateTime pay_rec_m_vou_date, string pay_rec_m_tran_type, string p_tran_type, int pay_rec_t_dracode, int pay_rec_t_cracode, int pay_rec_inv_tot_rec, DateTime YRDT1, DateTime YRDT2)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[11];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@pay_rec_t_acode", pay_rec_t_acode, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@pay_rec_m_vou_date", pay_rec_m_vou_date, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@pay_rec_m_tran_type", pay_rec_m_tran_type, SqlDbType.VarChar);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_tran_type", p_tran_type, SqlDbType.VarChar);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@pay_rec_t_dracode", pay_rec_t_dracode, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@pay_rec_t_cracode", pay_rec_t_cracode, SqlDbType.Int);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@pay_rec_inv_tot_rec", pay_rec_inv_tot_rec, SqlDbType.Int);
                paramsToStore[9] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[10] = ControllersHelper.GetSqlParameter("@YRDT2", YRDT2, SqlDbType.DateTime);



                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "get_paid_record", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

   



    public static DataTable GetPaidRecordFor_CreditDebit_Note(int p_branch_code,int pay_rec_m_acode, int pay_rec_t_acode, int p_comp_code, DateTime pay_rec_m_vou_date, string pay_rec_m_tran_type, string p_tran_type, int pay_rec_t_dracode, int pay_rec_t_cracode, int pay_rec_inv_tot_rec, DateTime YRDT1, DateTime YRDT2)
    {
        DataTable GetAllDetail = new DataTable();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        try
        {
            SqlParameter[] paramsToStore = new SqlParameter[12];
            paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
            paramsToStore[1] = ControllersHelper.GetSqlParameter("@pay_rec_m_acode", pay_rec_m_acode, SqlDbType.Int);
            paramsToStore[2] = ControllersHelper.GetSqlParameter("@pay_rec_t_acode", pay_rec_t_acode, SqlDbType.Int);
            paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
            paramsToStore[4] = ControllersHelper.GetSqlParameter("@pay_rec_m_vou_date", pay_rec_m_vou_date, SqlDbType.DateTime);
            paramsToStore[5] = ControllersHelper.GetSqlParameter("@pay_rec_m_tran_type", pay_rec_m_tran_type, SqlDbType.VarChar);
            paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_tran_type", p_tran_type, SqlDbType.VarChar);
            paramsToStore[7] = ControllersHelper.GetSqlParameter("@pay_rec_t_dracode", pay_rec_t_dracode, SqlDbType.Int);
            paramsToStore[8] = ControllersHelper.GetSqlParameter("@pay_rec_t_cracode", pay_rec_t_cracode, SqlDbType.Int);
            paramsToStore[9] = ControllersHelper.GetSqlParameter("@pay_rec_inv_tot_rec", pay_rec_inv_tot_rec, SqlDbType.Int);
            paramsToStore[10] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
            paramsToStore[11] = ControllersHelper.GetSqlParameter("@YRDT2", YRDT2, SqlDbType.DateTime);



            GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "get_paid_record_Credit_Debit", paramsToStore).Tables[0];
        }
        catch (Exception ex)
        {
                VeeraApp.VeeraExceptionLog.SendErrorToText(ex);
            }
        return GetAllDetail;
    }



}





   public class NARRATIONDataLayer
    {
        public static DataTable GetAllNarrationDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllNarrationDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllIDWiseNarrationsDetails(string Narran)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@NARRN", Narran, SqlDbType.VarChar);
             
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseNarrationsDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }



    public class DESIGN_MASDataLayer
    {
        public static string InsertDESIGNATION_MAS(DESIGN_MASLogicLayer DESIGN_LISTMASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLDESIGN_LISTMASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(DESIGN_LISTMASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, DESIGN_LISTMASDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLDESIGN_LISTMASDetails = xd.InnerXml;
            string str = "";
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@DESIGN_MASDetails", strXMLDESIGN_LISTMASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                str = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertDESIGNATION_MAS", paramsToStore).ToString();
                trn.Commit();
                con.Close();

                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }



        public static string UpdateDESIGNATION_MASDetails(DESIGN_MASLogicLayer DESIGN_LISTMASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLDESIGN_LISTMASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(DESIGN_LISTMASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, DESIGN_LISTMASDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLDESIGN_LISTMASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@DESIGN_MASDetails", strXMLDESIGN_LISTMASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateDESIGNATION_MASDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }



        public static DataTable GetAllDESIGNATION_MASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllDESIGNATION_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataTable GetAllIDWiseDESIGNATION_MASDetails(string DesignCode)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@Design_Code", DesignCode, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseDESIGNATION_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static string DeleteDESIGNTAION_MASDetaislByID(string DESIGN_CODE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@DESIGN_CODE", DESIGN_CODE, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteDESIGNTAION_MASDetaislByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllDESIGNATION_MASDetialsForEmp()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
             
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllDESIGNATION_MASDetialsForEmp").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


    }




    public class CATAGORY_MASDataLayer
    {

        public static string InsertEmployeeCategory_MAS(CATAGORY_MASLogicLayer CATEGORY_MASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLCATEGORY_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(CATEGORY_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, CATEGORY_MASDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLCATEGORY_MASDetails = xd.InnerXml;
            string str = "";
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CATEGORY_MASDetails", strXMLCATEGORY_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                str = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertEmployeeCategory_MAS", paramsToStore).ToString();
                trn.Commit();
                con.Close();

                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }



        public static string UpdateEmployeeCategory_MASDetails(CATAGORY_MASLogicLayer CATEGORY_MASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLCATEGORY_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(CATEGORY_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, CATEGORY_MASDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLCATEGORY_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CATEGORY_MASDetails", strXMLCATEGORY_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateEmployeeCategory_MASDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }



        public static DataTable GetAllEmployeeCategory_MASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllEmployeeCategory_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetAllIDWiseEmployeeCategory_MASDetails(string CategoryCode)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CATEGORY_CODE", CategoryCode, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseEmployeeCategory_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static string DeleteEmployeeCategory_MASDetialByID(string CATEGORY_CODE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CATEGORY_CODE", CATEGORY_CODE, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteEmployeeCategory_MASDetialByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllEmployeeCATEGORY_MASForEmp()
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllEmployeeCATEGORY_MASForEmp").Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


    }




    public class EMP_MASDataLayer
    {

        public static string InsertEMPLOYEE_MASDetails(EMP_MASLogicLayer EMPLOYEE_MASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLEMPLOYEE_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(EMPLOYEE_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, EMPLOYEE_MASDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLEMPLOYEE_MASDetails = xd.InnerXml;
            string str = "";
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@EMPLOYEE_MASDetails", strXMLEMPLOYEE_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                str = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertEMPLOYEE_MASDetails", paramsToStore).ToString();
                trn.Commit();
                con.Close();

                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static string UpdateEMPLOYEE_MASDetails(EMP_MASLogicLayer EMPLOYEE_MASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLEMPLOYEE_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(EMPLOYEE_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, EMPLOYEE_MASDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLEMPLOYEE_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@EMPLOYEE_MASDetails", strXMLEMPLOYEE_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateEMPLOYEE_MASDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();                
                return ex.Message;

            }
        }


        public static string DeleteEMPLOYEE_MASDetaislByID(string EMPLOYEE_CODE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@EMPLOYEE_CODE", EMPLOYEE_CODE, SqlDbType.Int);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteEMPLOYEE_MASDetaislByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllIDWiseEMPLOYEE_MASDetails(string EMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@EMPLOYEE_CODE", EMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseEMPLOYEE_MASDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


      

        public static DataTable GetAllEMPLOYEE_MASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllEMPLOYEE_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllEmployeeSalDetailsForAttenMas(string COMP_CODE, DateTime ATTN_DATE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@ATTN_DATE", ATTN_DATE, SqlDbType.DateTime);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllEmployeeSalDetailsForAttenMas", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllEmployeeDetailsOnBranch(string COMP_CODE, string BRANCH_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllEmployeeDetailsOnBranch", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataTable GetAllEmployeeDetailsByCompany(string COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllEmployeeDetailsByCompany", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



    }



    public class INCREMENT_MASDataLayer
    {
        public static string InsertINCREMENT_TRAN_MASDetail(INCREMENT_MASLogicLayer INCREMENT_MASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLINCREMENT_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(INCREMENT_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, INCREMENT_MASDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLINCREMENT_MASDetails = xd.InnerXml;
            string str = "";
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@INCREMENT_MASDetails", strXMLINCREMENT_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                str = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertINCREMENT_TRAN_MASDetail", paramsToStore).ToString();
                trn.Commit();
                con.Close();

                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }



        public static string UpdateINCREMENT_TRAN_MASDetail(INCREMENT_MASLogicLayer INCREMENT_MASDetails, string INCREMENT_TRAN_Details)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLINCREMENT_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(INCREMENT_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, INCREMENT_MASDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLINCREMENT_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@INCREMENT_MASDetails", strXMLINCREMENT_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@INCREMENT_TRANSDetails", INCREMENT_TRAN_Details, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateINCREMENT_TRAN_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string UpdateEMPLOYEE_MASDetails(EMP_MASLogicLayer EMPLOYEE_MASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLEMPLOYEE_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(EMPLOYEE_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, EMPLOYEE_MASDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLEMPLOYEE_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@EMPLOYEE_MASDetails", strXMLEMPLOYEE_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateEMPLOYEE_MASDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }



        public static DataTable GetAllINCREMENT_MASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllINCREMENT_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }




        public static DataSet GetAllIDWiseINCREMENT_MASDetails(string COMP_CODE, string YRDT1)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseINCREMENT_MASDetails", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetAllIDWiseINCREMENT_MAS_TRANSACTION_Details(string COMP_CODE, string YRDT1)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseINCREMENT_MAS_TRANSACTION_Details", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static string DeleteINCREMENT_TRAN_MASDetaislByID(string COMP_CODE, string YRDT1)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteINCREMENT_TRAN_MASDetaislByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllEMPLOYEE_INCREMENT_TRANDetailsByEmp_Code(string COMP_CODE, string EMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@EMP_CODE", EMP_CODE, SqlDbType.Int);
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllEMPLOYEE_INCREMENT_TRANDetailsByEmp_Code", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


    }


    public class ATTN_MASDataLayer
    {
        public static string InsertATTENDANCE_MASDetail(ATTN_MASLogicLayer ATTN_MASDetails, string ATTN_TRAN_Details)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLATTN_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ATTN_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ATTN_MASDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLATTN_MASDetails = xd.InnerXml;
            string str = "";
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ATTN_MASTER", strXMLATTN_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@ATTN_TRAN_Details", ATTN_TRAN_Details, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                str = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertATTENDANCE_MASDetail", paramsToStore).ToString();
                trn.Commit();
                con.Close();

                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static string UpdateATTENDANCE_MASDetail(ATTN_MASLogicLayer ATTN_MASDetails, string ATTN_TRAN_Details)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLATTN_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ATTN_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, ATTN_MASDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLATTN_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@ATTN_MASTER", strXMLATTN_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@ATTN_TRAN_Details", ATTN_TRAN_Details, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateATTENDANCE_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }




        public static string DeleteATTENDANCE_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteATTENDANCE_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllATTENDANCE_MASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllATTENDANCE_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetAllIDWiseATTENDANCE_MASDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseATTENDANCE_MASDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }


    public class GENERAL_MASDataLayer
    {
        public static string InsertGENERAL_MASDetails(GENERAL_MASLogicLayer GENERAL_MASDetails, string COMP_CODE, string TRAN_TYPE)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLGENERAL_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(GENERAL_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, GENERAL_MASDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLGENERAL_MASDetails = xd.InnerXml;
            string str = "";
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@GENERAL_MASDetails", strXMLGENERAL_MASDetails, SqlDbType.Xml);              
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);

                str = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertGENERAL_MASDetails", paramsToStore).ToString();
                trn.Commit();
                con.Close();

                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }



        public static string UpdateGENERAL_MASDetails(GENERAL_MASLogicLayer GENERAL_MASDetails, string COMP_CODE, string TRAN_TYPE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLGENERAL_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(GENERAL_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, GENERAL_MASDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLGENERAL_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@GENERAL_MASDetails", strXMLGENERAL_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateGENERAL_MASDetails", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteGENERAL_MASDetaislByID(string COMP_CODE, string TRAN_NO, string TRAN_TYPE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteGENERAL_MASDetaislByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllIDWiseGENERAL_MASDetials(string COMP_CODE, string TRAN_NO, string TRAN_TYPE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseGENERAL_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllGENERAL_MASDetials(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllGENERAL_MASDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }


    public class LOAN_MASDataLayer
    {
        public static string InsertLOAN_MASDetail(LOAN_MASLogicLayer LOAN_MASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLLOAN_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(LOAN_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, LOAN_MASDetails);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLLOAN_MASDetails = xd.InnerXml;
            string str = "";
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@LOAN_MASDetails", strXMLLOAN_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                str = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertLOAN_MASDetail", paramsToStore).ToString();
                trn.Commit();
                con.Close();

                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static string UpdateLOAN_MASDetail(LOAN_MASLogicLayer LOAN_MASDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLLOAN_MASDetails, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(LOAN_MASDetails.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, LOAN_MASDetails);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLLOAN_MASDetails = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@LOAN_MASDetails", strXMLLOAN_MASDetails, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);


                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateLOAN_MASDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }

        public static string DeleteLOAN_MASDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
               
                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteLOAN_MASDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }


        public static DataTable GetAllIDWiseLOAN_MASTERDetials(string TRAN_NO, DateTime TRAN_DATE, string LOAN_TYPE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@LOAN_TYPE", LOAN_TYPE, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseLOAN_MASTERDetials", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllLOAN_MASTERDetail(int USERCODE, int COMP_CODE, string LOAN_TYPE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@LOAN_TYPE", LOAN_TYPE, SqlDbType.VarChar);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllLOAN_MASTERDetail", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllLOAN_MASTERDetailForSAL_PAIDGrid(string COMP_CODE, string EMP_CODE, string LOAN_TYPE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@EMP_CODE", EMP_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@LOAN_TYPE", LOAN_TYPE, SqlDbType.VarChar);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllLOAN_MASTERDetailForSAL_PAIDGrid", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

    }



    public class SAL_MASDataLayer
    {
        public static string InsertSALARY_TransactionDetail(SAL_MASLogicLayer SAL_MAS_Details, string SAL_TRAN_Details, string SAL_TRAN_PAID_Details)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLSAL_MAS_Details, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(SAL_MAS_Details.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, SAL_MAS_Details);
            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLSAL_MAS_Details = xd.InnerXml;
            string str = "";
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SAL_MAS_Details", strXMLSAL_MAS_Details, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@SAL_TRAN_Details", SAL_TRAN_Details, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@SAL_TRAN_PAID_Details", SAL_TRAN_PAID_Details, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                str = SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_InsertSALARY_TransactionDetail", paramsToStore).ToString();
                trn.Commit();
                con.Close();

                return "Details successfully Added...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Details already in  List";
                }
                else
                {
                    return ex.Message;
                }
            }
        }



        public static string UpdateSALARY_TrasactionDetail(SAL_MASLogicLayer SAL_MAS_Details, string SAL_TRAN_Details, string SAL_TRAN_PAID_Details)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string strXMLSAL_MAS_Details, strXMLQutPut = "<root></root>";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(SAL_MAS_Details.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            x.Serialize(stream, SAL_MAS_Details);

            stream.Position = 0;
            XmlDocument xd = new XmlDocument();
            xd.Load(stream);
            strXMLSAL_MAS_Details = xd.InnerXml;

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@SAL_MAS_Details", strXMLSAL_MAS_Details, SqlDbType.Xml);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@SAL_TRAN_Details", SAL_TRAN_Details, SqlDbType.Xml);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@SAL_TRAN_PAID_Details", SAL_TRAN_PAID_Details, SqlDbType.Xml);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@OutPut", strXMLQutPut, SqlDbType.Xml);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_UpdateSALARY_TrasactionDetail", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string DeleteSALARY_TransactionDetailsByID(string TRAN_NO, DateTime TRAN_DATE)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "USP_DeleteSALARY_TransactionDetailsByID", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Deleted...";

            }
            catch (Exception ex)
            {
                trn.Rollback();
                con.Close();

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    return "Cannot Delete This Record It Used by Other Data";
                }
                else
                {
                    return ex.Message;
                }
            }
        }



        public static DataSet GetAllIDWiseSALARY_TransactionDetials(string TRAN_NO, DateTime TRAN_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
             
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllIDWiseSALARY_TransactionDetials", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetAllSALARY_TransactionDetails(int USERCODE, int COMP_CODE)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERCODE", USERCODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
             

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSALARY_TransactionDetails", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetAllSALARY_TRANDetialsByEMP_CODE(string TRAN_NO, DateTime TRAN_DATE, string EMP_CODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@EMP_CODE", EMP_CODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetAllSALARY_TRANDetialsByEMP_CODE", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }






    }

    public class AccountReport_Datalayer
    {
        public static DataSet GetCashBankPaymentReceiptVoucherReport(string TRAN_NO, DateTime TRAN_DATE, string COMP_CODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetCashBankPaymentReceiptVoucherReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetCreditDebitNoteDataForReport(string COMP_CODE, DateTime TRAN_DATE, string TRAN_NO)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetCreditDebitNoteDataForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetJournalVoucherDataForReport(string COMP_CODE, DateTime TRAN_DATE, string TRAN_NO)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetJournalVoucherDataForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetBankReceiptDetailsForChequeReport(string COMP_CODE, DateTime TRAN_DATE, string TRAN_NO, string ACODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetBankReceiptDetailsForChequeReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetBankReconciliationDataForReport(string COMP_CODE, string ACODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetBankReconciliationDataForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetBankReconciliationDataForReport2()
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                //SqlParameter[] paramsToStore = new SqlParameter[2];
                //paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                //paramsToStore[1] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetBankReconciliationDataForReport2");
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetPaymentReceiptDataForBillReport(string COMP_CODE, DateTime TRAN_DATE, string TRAN_NO)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
           


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetPaymentReceiptDataForBillReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetOutStnadingDataOnPartyNameForReport(string COMP_CODE, string BRANCH_CODE, string TRAN_TYPE, DateTime TRAN_DATE, string TRAN_NO, DateTime YRDT1, DateTime YRDT2)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@pay_rec_m_tran_type", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TRAN_DATE", TRAN_DATE, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@TRAN_NO", TRAN_NO, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@YRDT1", YRDT1, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@YRDT2", YRDT2, SqlDbType.DateTime);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetOutStnadingDataOnPartyNameForReport",paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetAccountsLedgerDeatilsOnPartyNameForReport(string COMP_CODE, string BRANCH_CODE, string GROPU_CODE, string ACODE,  DateTime YRDT1, DateTime YRDT2, DateTime FROM_DATE, DateTime TO_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_group_code", GROPU_CODE, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_acode", ACODE, SqlDbType.VarChar);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt1", YRDT1, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_yrdt2", YRDT2, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@P_fromDate", FROM_DATE, SqlDbType.DateTime);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@P_toDate", TO_DATE, SqlDbType.DateTime);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_LedgerDeatilsOnPartyNameForReport_MHL", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetACCOUNTS_OpenningBalanceForReport(string COMP_CODE, DateTime YRDT1)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_yrdt1", YRDT1, SqlDbType.DateTime);
          


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_OpenningBalanceForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataTable GetACCOUNTS_TradingAndProfitMainDetailsForReport(string p_comp_code, string p_atype, DateTime p_ondt, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {


                SqlParameter[] paramsToStore = new SqlParameter[5];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_atype", p_atype, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_ondt", p_ondt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_TradingAndProfitMainDetailsForReport", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataSet GetACCOUNTS_TradingAndProfitMainDetailsForReport_MHL(string p_comp_code, string p_atype, DateTime p_ondt, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[5];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_atype", p_atype, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_ondt", p_ondt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);



                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_TradingAndProfitMainDetailsForReport_MHL", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetACCOUNTS_TradingDetailsForReport(string p_comp_code, string p_atype, DateTime p_ondt, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[5];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_atype", p_atype, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_ondt", p_ondt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);



                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_TradingDetailsForReport_MHL", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetACCOUNTS_ProfitAndLossStatementForReport(string p_comp_code, string p_atype, DateTime p_ondt, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[5];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_atype", p_atype, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_ondt", p_ondt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_ProfitAndLossStatementForReport_MHL", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetACCOUNTS_TrialBalanceForReport2(string p_comp_code, string p_group_code, DateTime p_ondt, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[5];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_group_code", p_group_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_ondt", p_ondt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_TrialBalanceForReport2_MHL", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetACCOUNTS_TrialBalanceForReport1(string p_comp_code, string p_atype, string p_group_code, DateTime p_frdt, DateTime p_todt, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_atype", p_atype, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_group_code", p_group_code, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_frdt", p_frdt, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime); 

                 GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_TrialBalanceForReport1_MHL", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetACCOUNTS_BalanceSheetForReport(string p_comp_code, DateTime p_ondt, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_ondt", p_ondt, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);

               SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "get_entry_bs", paramsToStore);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_BalanceSheetForReport_MHL", paramsToStore);

                
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }




        public static DataTable GetACCOUNTS_PartyWise_AgeingMainReport(string p_comp_code, string p_branch_code, DateTime p_ondt, string p_atype, DateTime p_yrdt1, DateTime p_yrdt2, string p_acode, string p_report)
        {
            DataTable GetAllDetail = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {


                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_ondt", p_ondt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_atype", p_atype, SqlDbType.VarChar);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_acode", p_acode, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_report", p_report, SqlDbType.VarChar);



                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_PartyWise_AgeingMainReport", paramsToStore).Tables[0];
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataSet GetACCOUNTS_PartyWise_AgeingReport(string p_comp_code, string p_branch_code, DateTime p_ondt, string p_atype, DateTime p_yrdt1, DateTime p_yrdt2, string p_acode, string p_report)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_ondt", p_ondt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_atype", p_atype, SqlDbType.VarChar);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_acode", p_acode, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_report", p_report, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_PartyWise_AgeingReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetACCOUNTS_PartyWise_AgeingReport_PersonWise(string p_comp_code, string p_branch_code, DateTime p_ondt, string p_atype, DateTime p_yrdt1, DateTime p_yrdt2, string p_acode, string p_report, string BCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[9];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_ondt", p_ondt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_atype", p_atype, SqlDbType.VarChar);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_acode", p_acode, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_report", p_report, SqlDbType.VarChar);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@BCODE", BCODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_PartyWise_AgeingReport_PersonWise", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetACCOUNTS_PartyWise_AgeingReport_Summary(string p_comp_code, string p_branch_code, DateTime p_ondt, string p_atype, DateTime p_yrdt1, DateTime p_yrdt2, string p_acode, string p_report)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_ondt", p_ondt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_atype", p_atype, SqlDbType.VarChar);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_acode", p_acode, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_report", p_report, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_PartyWise_AgeingReport_Summary", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataSet GetACCOUNTS_PartyWise_AgeingReport_Summary_PersonWise(string p_comp_code, string p_branch_code, DateTime p_ondt, string p_atype, DateTime p_yrdt1, DateTime p_yrdt2, string p_acode, string p_report, string BCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[9];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_ondt", p_ondt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_atype", p_atype, SqlDbType.VarChar);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_acode", p_acode, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_report", p_report, SqlDbType.VarChar);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@BCODE", BCODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_PartyWise_AgeingReport_Summary_PersonWise", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetACCOUNTS_PartyWise_OutstadingReport(string p_comp_code, string p_branch_code, DateTime p_ondt, string p_atype, DateTime p_yrdt1, DateTime p_yrdt2, string p_acode, string p_report)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_ondt", p_ondt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_atype", p_atype, SqlDbType.VarChar);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_acode", p_acode, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_report", p_report, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Xtemp_USP_GetACCOUNTS_PartyWise_OutstadingReport_MHL", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetACCOUNTS_PartyWise_OutstadingReport_PersonWise(string p_comp_code, string p_branch_code, DateTime p_ondt, string p_atype, DateTime p_yrdt1, DateTime p_yrdt2, string p_acode, string p_report,string BCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[9];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_ondt", p_ondt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_atype", p_atype, SqlDbType.VarChar);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_acode", p_acode, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_report", p_report, SqlDbType.VarChar);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@BCODE", BCODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Xtemp_USP_GetACCOUNTS_PartyWise_OutstadingReport_PersonWise_MHL", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataSet GetACCOUNTS_CashBookStatementDetailsForReport(string COMP_CODE, string BRANCH_CODE, string GROPU_CODE, string ACODE, DateTime YRDT1, DateTime YRDT2, DateTime FROM_DATE, DateTime TO_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", BRANCH_CODE, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_group_code", GROPU_CODE, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_acode", ACODE, SqlDbType.VarChar);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt1", YRDT1, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_yrdt2", YRDT2, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@P_fromDate", FROM_DATE, SqlDbType.DateTime);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@P_toDate", TO_DATE, SqlDbType.DateTime); 


                 GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_CashBookStatementDetailsForReport_MHL", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataSet GetACCOUNTS_BankBookStatementDetailsForReport(string COMP_CODE, string BRANCH_CODE, string GROPU_CODE, string ACODE, DateTime YRDT1, DateTime YRDT2, DateTime FROM_DATE, DateTime TO_DATE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", BRANCH_CODE, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_group_code", GROPU_CODE, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_acode", ACODE, SqlDbType.VarChar);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt1", YRDT1, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_yrdt2", YRDT2, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@P_fromDate", FROM_DATE, SqlDbType.DateTime);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@P_toDate", TO_DATE, SqlDbType.DateTime);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_BankBookStatementDetailsForReport_MHL", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }




        public static DataSet GetACCOUNTS_PaymentReceiptDetailsForReport(string COMP_CODE, string BRANCH_CODE,DateTime FROM_DATE, DateTime TO_DATE, string CRACODE ,string DRACODE, string TRAN_TYPE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@FROM_DATE", FROM_DATE, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TO_DATE", TO_DATE, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@CRACODE", CRACODE, SqlDbType.VarChar);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@DRACODE", DRACODE, SqlDbType.VarChar);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_PaymentReceiptDetailsForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        
        public static DataSet GetACCOUNTS_JournalVoucherAndCreditNoteDebitStatementForReport(string p_comp_code, string p_branch_code,string p_tran_type, DateTime p_yrdt1, DateTime p_yrdt2, DateTime p_frdt, DateTime p_todt, string p_acode)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_tran_type", p_tran_type, SqlDbType.VarChar);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_frdt", p_frdt, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_acode", p_acode, SqlDbType.Int);
                
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_JournalVoucherAndCreditNoteDebitStatementForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataSet GetACCOUNT_DetailsListForReport(string COMP_CODE, string BRANCH_CODE, string GROUP_CODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[3];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@GROUP_CODE", GROUP_CODE, SqlDbType.Int);
              
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNT_DetailsListForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataSet GetACCOUNTS_CustomerContactDetailsForReport(string COMP_CODE, string BRANCH_CODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);
              
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_CustomerContactDetailsForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetACCOUNTS_SupplierContactDetailsForReport(string COMP_CODE, string BRANCH_CODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_SupplierContactDetailsForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetACCOUNTS_USERLOGINDetailsForReport(string USERNAME)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@USERNAME", USERNAME, SqlDbType.VarChar);
               

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetACCOUNTS_USERLOGINDetailsForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


    }




    public class InventoryReport_Datalayer
    {

        public static DataSet GetORDER_MASDetailsFor_MainReport(string COMP_CODE, string BRANCH_CODE, string ACODE, DateTime FROM_DATE, DateTime TO_DATE,string TRAN_TYPE, string CAT_CODE, string SCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@FROM_DATE", FROM_DATE, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@TO_DATE", TO_DATE, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@CAT_CODE", CAT_CODE, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetORDER_MASDetailsFor_MainReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


       

        public static DataSet GetORDER_MASDetailsFor_SubReport(string CAT_CODE, string SCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CAT_CODE", CAT_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);
              
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetORDER_MASDetailsFor_SubReport",paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetORDER_MASOutStandingDetailSubReport(string CAT_CODE, string SCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CAT_CODE", CAT_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetORDER_MASOutStandingDetailSubReport",paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetINVENTORY_DC_MAS_DateWiseChallanForReport(string COMP_CODE, string BRANCH_CODE, string ACODE, DateTime FROM_DATE, DateTime TO_DATE, string TRAN_TYPE, string TRN_TYPE, string CAT_CODE, string SCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[9];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@FROM_DATE", FROM_DATE, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@TO_DATE", TO_DATE, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@TRN_TYPE", TRN_TYPE, SqlDbType.VarChar);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@CAT_CODE", CAT_CODE, SqlDbType.Int);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetINVENTORY_DC_MAS_DateWiseChallanForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetINVENTORY_DC_MAS_Detail_DateWiseChallanForSubReport(string CAT_CODE, string SCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CAT_CODE", CAT_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetINVENTORY_DC_MAS_Detail_DateWiseChallanForSubReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetQUOTATION_MASDetailsFor_MainReport(string COMP_CODE, string BRANCH_CODE, string ACODE, DateTime FROM_DATE, DateTime TO_DATE, string QUO_TYPE, string CAT_CODE, string SCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@FROM_DATE", FROM_DATE, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@TO_DATE", TO_DATE, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@QUO_TYPE", QUO_TYPE, SqlDbType.VarChar);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@CAT_CODE", CAT_CODE, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetQUOTATION_MASDetailsFor_MainReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetQUOTATION_MASDetailsFor_SubReport(string CAT_CODE, string SCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CAT_CODE", CAT_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetQUOTATION_MASDetailsFor_SubReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }




        public static DataSet GetASSEMBLE_MASDetailsFor_MainReport(string COMP_CODE, string BRANCH_CODE, DateTime FROM_DATE, DateTime TO_DATE, string TRAN_TYPE, string CAT_CODE, string SCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@FROM_DATE", FROM_DATE, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TO_DATE", TO_DATE, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@CAT_CODE", CAT_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetASSEMBLE_MASDetailsFor_MainReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetASSEMBLE_MASDetailsFor_SubReport(string CAT_CODE, string SCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CAT_CODE", CAT_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetASSEMBLE_MASDetailsFor_SubReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetREC_ISS_M_Sales_Purchase_For_Register_Report(string COMP_CODE, string BRANCH_CODE, string ACODE, DateTime FROM_DATE, DateTime TO_DATE, string TRAN_TYPE, string TRN_TYPE, string CAT_CODE, string SCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[9];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@ACODE", ACODE, SqlDbType.Int);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@FROM_DATE", FROM_DATE, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@TO_DATE", TO_DATE, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@TRN_TYPE", TRN_TYPE, SqlDbType.VarChar);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@CAT_CODE", CAT_CODE, SqlDbType.Int);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetREC_ISS_M_Sales_Purchase_For_Register_Report", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetBRANCH_ISSUE_STK_IRMASFor_MainReport(string COMP_CODE, string BRANCH_CODE, DateTime FROM_DATE, DateTime TO_DATE, string TRAN_TYPE, string CAT_CODE, string SCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@FROM_DATE", FROM_DATE, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TO_DATE", TO_DATE, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@CAT_CODE", CAT_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetBRANCH_ISSUE_STK_IRMASFor_MainReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetBRANCH_ISSUE_STK_IRMASFor_SubReport(string CAT_CODE, string SCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CAT_CODE", CAT_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetBRANCH_ISSUE_STK_IRMASFor_SubReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetBRANCH_RECEIVED_STK_RECMASFor_MainReport(string COMP_CODE, string BRANCH_CODE, DateTime FROM_DATE, DateTime TO_DATE, string TRAN_TYPE, string CAT_CODE, string SCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@COMP_CODE", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@BRANCH_CODE", BRANCH_CODE, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@FROM_DATE", FROM_DATE, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@TO_DATE", TO_DATE, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@TRAN_TYPE", TRAN_TYPE, SqlDbType.VarChar);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@CAT_CODE", CAT_CODE, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetBRANCH_RECEIVED_STK_RECMASFor_MainReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetBRANCH_RECEIVED_STK_RECMASFor_SubReport(string CAT_CODE, string SCODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@CAT_CODE", CAT_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@SCODE", SCODE, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetBRANCH_RECEIVED_STK_RECMASFor_SubReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



    }



    public class StockStatementReport_DataLayer
    {
        public static DataSet GetSTOCKLIST_STATEMENTForReport(string COMP_CODE, string CAT_CODE)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", COMP_CODE, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_cat_code", CAT_CODE, SqlDbType.Int);
             
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCKLIST_STATEMENTForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetSTOCKLIST_BranchWiseForReport(string p_comp_code, string p_cat_code, DateTime p_todt, DateTime p_yrdt1)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[4];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCKLIST_BranchWiseForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetSTOCK_DetailDateWiseForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, string p_cat_code, string p_scode, DateTime p_yrdt1 , DateTime p_yrdt2)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_frdt", p_frdt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_DetailDateWiseForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetSTOCK_DetailsMonthlyWiseForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, string p_cat_code, string p_scode, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_frdt", p_frdt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_DetailsMonthlyWiseForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetSTOCK_ClosingDetailForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, string p_cat_code, string p_scode, DateTime p_yrdt1, DateTime p_yrdt2)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_frdt", p_frdt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_ClosingDetailForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetSTOCK_Maximum_Minimum_StatementForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, string p_cat_code, string p_scode, DateTime p_yrdt1, DateTime p_yrdt2, string p_report)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[9];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_frdt", p_frdt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@p_report", p_report, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_Maximum_Minimum_StatementForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetSTOCK_BranchOneItemDetailForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, string p_cat_code, string p_scode, DateTime p_yrdt1, DateTime p_yrdt2, string p_scode_flag, string p_userid)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[10];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_frdt", p_frdt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@p_scode_flag", p_scode_flag, SqlDbType.VarChar);
                paramsToStore[9] = ControllersHelper.GetSqlParameter("@p_userid", p_userid, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_BranchOneItemDetailForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetSTOCK_BarcodeStockDetailExciseForReport(string p_comp_code, string p_branch_code, DateTime p_todt, string p_cat_code, string p_scode, string p_fin_year, string cp_usertype)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_fin_year", p_fin_year, SqlDbType.VarChar);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@cp_usertype", cp_usertype, SqlDbType.VarChar);
             
                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_BarcodeStockDetailExciseForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetSTOCK_BarcodeStock_Status_BarcodeStock_ZeroValue_ForReport(string p_comp_code, string p_branch_code, DateTime p_todt, string p_cat_code, string p_scode, string p_fin_year, string p_report)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_fin_year", p_fin_year, SqlDbType.VarChar);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_report", p_report, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_BarcodeStock_Status_BarcodeStock_ZeroValue_ForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetSTOCK_Barcode_Stock_Detail_ForReport(string p_comp_code, string p_branch_code, DateTime p_todt, string p_cat_code, string p_scode, string p_fin_year, string cp_usertype)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_fin_year", p_fin_year, SqlDbType.VarChar);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@cp_usertype", cp_usertype, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_Barcode_Stock_Detail_ForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetSTOCK_Barcode_Stock_Summary_ForReport(string p_comp_code, string p_branch_code, DateTime p_todt, string p_cat_code, string p_scode, string p_fin_year, string cp_usertype)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_fin_year", p_fin_year, SqlDbType.VarChar);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@cp_usertype", cp_usertype, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_Barcode_Stock_Summary_ForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetSTOCK_Barcode_Stock_Value_ForReport(string p_comp_code, string p_branch_code, DateTime p_todt, string p_cat_code, string p_scode, string p_fin_year, string cp_usertype)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.VarChar);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_fin_year", p_fin_year, SqlDbType.VarChar);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@cp_usertype", cp_usertype, SqlDbType.VarChar);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_Barcode_Stock_Value_ForReport", paramsToStore);
            }
          catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetSTOCK_Barcode_stock_HistoryForReport(string p_comp_code)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[1];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_Barcode_stock_HistoryForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetSTOCK_Barcode_stock_printForReport(string p_comp_code, string p_branch_code)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[2];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_Barcode_stock_printForReport", paramsToStore);

            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetSTOCK_Supplier_Stock_IndentForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, string p_acode, DateTime p_yrdt1, DateTime p_yrdt2, string p_cat_code, string p_scode)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[9];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_frdt", p_frdt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_acode", p_acode, SqlDbType.VarChar);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_Supplier_Stock_IndentForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }

        public static DataSet GetSTOCK_stock_indent_with_last_purchaseForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, DateTime p_yrdt1, DateTime p_yrdt2, string p_cat_code, string p_scode)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_frdt", p_frdt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                //paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_acode", p_acode, SqlDbType.VarChar);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.Int);
          

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_stock_indent_with_last_purchaseForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static DataSet GetSTOCK_Diff_Qty_Stock_with_BarcodeStockForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, string p_fin_year,  string p_cat_code, string p_scode)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[7];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_frdt", p_frdt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_fin_year", p_fin_year, SqlDbType.VarChar);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_Diff_Qty_Stock_with_BarcodeStockForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetSTOCK_Diff_Stock_Barcode_PostingForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, DateTime p_yrdt1, DateTime p_yrdt2, string p_cat_code, string p_scode)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[8];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_frdt", p_frdt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.Int);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_Diff_Stock_Barcode_PostingForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }



        public static DataSet GetSTOCK_sales_DC_diff_barcode_qtyForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, string p_party_code, DateTime p_yrdt1, DateTime p_yrdt2, string p_cat_code, string p_scode, string p_tran_type, string p_trn_type)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[11];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_frdt", p_frdt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_party_code", p_party_code, SqlDbType.Int);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.Int);
                paramsToStore[9] = ControllersHelper.GetSqlParameter("@p_tran_type", p_tran_type, SqlDbType.VarChar);
                paramsToStore[10] = ControllersHelper.GetSqlParameter("@p_trn_type", p_trn_type, SqlDbType.VarChar);


                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_sales_DC_diff_barcode_qtyForReport_MHL", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }




        public static DataSet GetSTOCK_branch_issue_diff_barcode_qtyForReport(string p_comp_code, string p_branch_code, DateTime p_frdt, DateTime p_todt, DateTime p_yrdt1, DateTime p_yrdt2, string p_cat_code, string p_scode, string p_tran_type)
        {
            DataSet GetAllDetail = new DataSet();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            try
            {

                SqlParameter[] paramsToStore = new SqlParameter[9];
                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_branch_code", p_branch_code, SqlDbType.Int);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_frdt", p_frdt, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_todt", p_todt, SqlDbType.DateTime);
                paramsToStore[4] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[5] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[6] = ControllersHelper.GetSqlParameter("@p_cat_code", p_cat_code, SqlDbType.Int);
                paramsToStore[7] = ControllersHelper.GetSqlParameter("@p_scode", p_scode, SqlDbType.Int);
                paramsToStore[8] = ControllersHelper.GetSqlParameter("@p_tran_type", p_tran_type, SqlDbType.VarChar);
             

                GetAllDetail = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "USP_GetSTOCK_branch_issue_diff_barcode_qtyForReport", paramsToStore);
            }
            catch (Exception ex)
            {
            }
            return GetAllDetail;
        }


        public static string upd_op_stock_barcode_price(string p_comp_code, DateTime p_yrdt1, DateTime p_yrdt2, string p_Types)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
         
            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_Types", p_Types, SqlDbType.VarChar);
           
                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "upd_op_stock_barcode_price", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string upd_purchase_stock_barcode_price(string p_comp_code, DateTime p_yrdt1, DateTime p_yrdt2, string p_Types)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_Types", p_Types, SqlDbType.VarChar);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "upd_purchase_stock_barcode_price", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }


        public static string upd_assemble_stock_barcode_price(string p_comp_code, DateTime p_yrdt1, DateTime p_yrdt2, string p_Types)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_Types", p_Types, SqlDbType.VarChar);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "upd_assemble_stock_barcode_price", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }

        public static string upd_xfer_stock_barcode_price(string p_comp_code, DateTime p_yrdt1, DateTime p_yrdt2, string p_Types)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();

            SqlTransaction trn = con.BeginTransaction();
            try
            {
                SqlParameter[] paramsToStore = new SqlParameter[4];

                paramsToStore[0] = ControllersHelper.GetSqlParameter("@p_comp_code", p_comp_code, SqlDbType.Int);
                paramsToStore[1] = ControllersHelper.GetSqlParameter("@p_yrdt1", p_yrdt1, SqlDbType.DateTime);
                paramsToStore[2] = ControllersHelper.GetSqlParameter("@p_yrdt2", p_yrdt2, SqlDbType.DateTime);
                paramsToStore[3] = ControllersHelper.GetSqlParameter("@p_Types", p_Types, SqlDbType.VarChar);

                SqlHelper.ExecuteNonQuery(trn, CommandType.StoredProcedure, "upd_xfer_stock_barcode_price", paramsToStore);
                trn.Commit();
                con.Close();
                return "Details successfully Updated...";

            }
            catch (Exception ex)
            {

                trn.Rollback();
                con.Close();
                return ex.Message;

            }
        }

    }

}


































