using MihirValid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;

namespace VeeraApp
{
    public partial class Quotation : System.Web.UI.Page
    {

        public static string compcode;
        public static double netamount;
        public static double roamount;
        public static string brandname;
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
                Session["DELETE"] != null


                )


            {
                compcode = Session["COMP_CODE"].ToString();
                if (!Page.IsPostBack)
                {
                    DivEntry.Visible = false;
                    DivView.Visible = true;
                    FillDdlAccountName();
                    FillDdlPersonName();
                    FillQuotation_MGrid(Session["COMP_CODE"].ToString());
                    FillQuotation_TGrid();
                    FillQuotation_CGrid();
                    FillQuotation_TAMCGrid();
                    SetInitialRow();
                    SetInitialRow1();
                    SetInitialRow3();


                    string ACODE = Request.QueryString["ACODE"];
                    string COMP_CODE = Request.QueryString["COMP_CODE"];

                    //CalendarExtender1.StartDate.Value.Date = new DateTime("01-04-2018");
                    CalendarExtender1.StartDate = Convert.ToDateTime(Session["FIN_YEAR"].ToString()); //Session["FIN_YEAR"] Replace string
                    //Current date can be select but not future date.  
                    CalendarExtender1.EndDate = Convert.ToDateTime(Session["FIN_YEAR_END"].ToString());//Session["FIN_YEAR_END"] Replace string and Add Session 


                    string FlagAddition = QUOTATION_MLogicLayer.ADD_DISFLAG_FROMCOMPANY(Convert.ToInt32(Session["COMP_CODE"]));
                    if (FlagAddition == "N")
                    {
                        GvQuotation_T.Columns[5].Visible = false;
                    }


                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }





        public void FillNetAmount()
        {
            try
            { 


                if (HfGrid_TAMC_Total.Value == string.Empty)
                {
                    HfGrid_TAMC_Total.Value = "0";
                }
                if (HfGrid_T_Total.Value == string.Empty)
                {
                    HfGrid_T_Total.Value = "0";
                }
                if (HfGrid_C_Total.Value == string.Empty)
                {
                    HfGrid_C_Total.Value = "0";
                }

                double GridmergeTotalAmt = Convert.ToDouble(ViewState["Total_Quotation_T"]) + Convert.ToDouble(ViewState["Total_Quotation_C"]) + Convert.ToDouble(ViewState["Total_Quotation_TAMC"]);




                //double GridmergeTotalAmt = Convert.ToDouble(Grid_TAMC_Total + Grid_C_Total + Grid_T_Total);


                double decimalpoints = Math.Abs(GridmergeTotalAmt - Math.Floor(GridmergeTotalAmt));
                if (decimalpoints > 0.5)
                {
                    double ro = 1 - decimalpoints;

                    TxtROamt.Text = Math.Round(ro, 2).ToString();

                    TxtNetAmt.Text = Convert.ToString(Convert.ToDouble(GridmergeTotalAmt) + ro);
                }

                else
                {

                    double ro = (1 - decimalpoints) - 1;

                    TxtROamt.Text = Math.Round(ro, 2).ToString();

                    TxtNetAmt.Text = Convert.ToString(Math.Floor(GridmergeTotalAmt));
                }
                UpdateTotalAmount.Update();

            }
            catch (Exception)
            {

                throw;
            }
        }


    #region TOTAL OF FOOTER TEMPLETES FOR QUOTATION_T

      private double TotalQuantity_T()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_T.Rows.Count; i++)
            {
                string total = (GvQuotation_T.Rows[i].FindControl("TxtQuantity") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }
       


        private double TotalGrossAmount_T()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_T.Rows.Count; i++)
            {
                string total = (GvQuotation_T.Rows[i].FindControl("TxtAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }



        private double TotalCGSTAmount_T()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_T.Rows.Count; i++)
            {
                string total = (GvQuotation_T.Rows[i].FindControl("TxtCGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalSGSTAmount_T()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_T.Rows.Count; i++)
            {
                string total = (GvQuotation_T.Rows[i].FindControl("TxtSGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalIGSTAmount_T()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_T.Rows.Count; i++)
            {
                string total = (GvQuotation_T.Rows[i].FindControl("TxtIGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }


        private double TotalAmount_T()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_T.Rows.Count; i++)
            {
                string total = (GvQuotation_T.Rows[i].FindControl("TxtTotalAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }


        #endregion


        #region TOTAL OF FOOTER TEMPLETES FOR QUOTATION_C

        private double TotalQuantity_C()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_C.Rows.Count; i++)
            {
                string total = (GvQuotation_C.Rows[i].FindControl("TxtQuantity") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }


        private double TotalGrossAmount_C()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_C.Rows.Count; i++)
            {
                string total = (GvQuotation_C.Rows[i].FindControl("TxtChargesAmt") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }



        private double TotalCGSTAmount_C()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_C.Rows.Count; i++)
            {
                string total = (GvQuotation_C.Rows[i].FindControl("TxtCGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalSGSTAmount_C()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_C.Rows.Count; i++)
            {
                string total = (GvQuotation_C.Rows[i].FindControl("TxtSGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalIGSTAmount_C()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_C.Rows.Count; i++)
            {
                string total = (GvQuotation_C.Rows[i].FindControl("TxtIGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }


        private double TotalAmount_C()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_C.Rows.Count; i++)
            {
                string total = (GvQuotation_C.Rows[i].FindControl("TxtTotalAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        #endregion

        #region TOTAL OF FOOTER TEMPLETES FOR QUOTATION_AMC

        private double TotalQuantity_AMC()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_TAMC.Rows.Count; i++)
            {
                string total = (GvQuotation_TAMC.Rows[i].FindControl("TxtQuantity") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }


        private double TotalGrossAmount_AMC()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_TAMC.Rows.Count; i++)
            {
                string total = (GvQuotation_TAMC.Rows[i].FindControl("TxtAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }



        private double TotalCGSTAmount_AMC()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_TAMC.Rows.Count; i++)
            {
                string total = (GvQuotation_TAMC.Rows[i].FindControl("TxtCGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalSGSTAmount_AMC()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_TAMC.Rows.Count; i++)
            {
                string total = (GvQuotation_TAMC.Rows[i].FindControl("TxtSGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalIGSTAmount_AMC()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_TAMC.Rows.Count; i++)
            {
                string total = (GvQuotation_TAMC.Rows[i].FindControl("TxtIGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }


        private double TotalAmount_AMC()
        {
            double GTotal = 0;
            for (int i = 0; i < GvQuotation_TAMC.Rows.Count; i++)
            {
                string total = (GvQuotation_TAMC.Rows[i].FindControl("TxtTotalAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }

        #endregion

        public void FillQuotation_MGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = QUOTATION_MLogicLayer.GetAllQUOATATION_MASDetails(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvQuotation_M.DataSource = Dv.ToTable();
            GvQuotation_M.DataBind();

            DtSearch = Dv.ToTable();
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
        public static List<string> GetAccountName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ACCOUNTS where COMP_CODE=@COMP_CODE  AND ANAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> ANames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ANames.Add(dt.Rows[i][2].ToString());
            }
            return ANames;
        }


        protected void TxtAccountName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select ACODE from ACCOUNTS where ANAME = '" + TxtAccountName.Text + "'and COMP_CODE = " + Session["COMP_CODE"].ToString() , con);
                int x = Convert.ToInt32(cmd.ExecuteScalar());
                if (x == 0)
                {
                    TxtAccountName.BackColor = Color.Red;
                }
                else
                {
                    HfACODE.Value = cmd.ExecuteScalar().ToString();
                    TxtAccountName.BackColor = Color.White;
                }

                con.Close();

                FillDdlKindAttn();
                FillDdlAccountPartyType();
                FillDdlAccountSalesType();
                FillDdlAccountCSTType();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlAccountNameOnUpdate(string Id)
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(Comp_Code);


                if (HfACODE.Value.ToString() != "0")
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "ACODE=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtAccountName.Text = DtView.Rows[0]["ANAME"].ToString();
                    HfACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlAccountPartyType()
        {
            try
            {
                string ACODE = HfACODE.Value;
                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(ACODE);
                if (Dt.Rows.Count > 0)
                {
                    DdlPartyType.SelectedValue = Dt.Rows[0]["PARTY_TYPE_String"].ToString().ToUpper();
                }
                else
                {
                    DdlPartyType.SelectedIndex = 0;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlAccountSalesType()
        {
            try
            {
                string ACODE = HfACODE.Value;
                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(ACODE);
                if (Dt.Rows.Count > 0)
                {
                    DdlSalesType.SelectedValue = Dt.Rows[0]["SALES_TYPE"].ToString();
                }
                else
                {
                    DdlSalesType.SelectedIndex = 0;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlAccountCSTType()
        {
            try
            {
                string ACODE = HfACODE.Value;
                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(ACODE);
                if (Dt.Rows.Count > 0)
                {
                    DdlCSTtype.SelectedValue = Dt.Rows[0]["CST_TYPE"].ToString();
                }
                else
                {
                    DdlCSTtype.SelectedIndex = 0;
                }

            }
            catch (Exception)
            {

                throw;
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

        public void FillDdlKindAttn()
        {
            try
            {
                string Acc_Code = HfACODE.Value;

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_DETLogicLayer.GetAllParty_Contact_DetialsWIiseAccountFor_DDL(Acc_Code);
                DdlKindAttn.DataSource = Dt;
                DdlKindAttn.DataValueField = "CONTACT_NAME";
                DdlKindAttn.DataTextField = "CONTACT_NAME";
                DdlKindAttn.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void DdlAccountName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDdlKindAttn();
            FillDdlAccountPartyType();
            FillDdlAccountSalesType();
            FillDdlAccountCSTType();
        }

        public void getContactPersonPhoneNo()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select PHONE_NO from ACCOUNTS_DET where CONTACT_NAME = '" + DdlKindAttn.SelectedItem.ToString() + "'", con);
                TxtConatctPhone.Text = cmd.ExecuteScalar().ToString();
                TxtConatctPhone.Enabled = false;
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void getContactPersonEmail()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select MAIL_ID from ACCOUNTS_DET where CONTACT_NAME = '" + DdlKindAttn.SelectedItem.ToString() + "'", con);
                TxtContactEmail.Text = cmd.ExecuteScalar().ToString();
                TxtContactEmail.Enabled = false;
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlKindAttn_SelectedIndexChanged(object sender, EventArgs e)
        {
            getContactPersonPhoneNo();
            getContactPersonEmail();
        }

        public void getQuo_Sub1bByCompany()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select QUO_SUB1 from COMPANY where COMP_CODE = '" + Session["COMP_CODE"].ToString() + "'", con);
                TxtSubject.Text = cmd.ExecuteScalar().ToString();
                TxtSubject.Enabled = false;
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void getQuo_Sub2bByCompany()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select QUO_SUB2 from COMPANY where COMP_CODE = '" + Session["COMP_CODE"].ToString() + "'", con);
                TxtFor.Text = cmd.ExecuteScalar().ToString();
                TxtFor.Enabled = false;
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void getQuo_BrandNameByCompany()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select QUO_BRAND_NAME from COMPANY where COMP_CODE = '" + Session["COMP_CODE"].ToString() + "'", con);
                TxtBrandName.Text = cmd.ExecuteScalar().ToString();
                TxtBrandName.Enabled = false;
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void getQuo_NoteByCompany()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select QUO_MODEL_NAME from COMPANY where COMP_CODE = '" + Session["COMP_CODE"].ToString() + "'", con);
                TxtModelNo.Text = cmd.ExecuteScalar().ToString();
                TxtModelNo.Enabled = false;
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void getQuo_ModelNameByCompany()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select QUO_NOTE from COMPANY where COMP_CODE = '" + Session["COMP_CODE"].ToString() + "'", con);
                TxtNote.Text = cmd.ExecuteScalar().ToString();
                TxtNote.Enabled = false;
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillQuotation_TGrid()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = QUOTATION_TLogicLayer.GetAllQUOTATION_TDetailByCompany((Session["COMP_CODE"].ToString()));
                GvQuotation_T.DataSource = Dt;
                GvQuotation_T.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillQuotation_TAMCGrid()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = QUOTATION_TLogicLayer.GetAllQUOTATION_TAMCDetailByCompany((Session["COMP_CODE"].ToString()));
                GvQuotation_TAMC.DataSource = Dt;
                GvQuotation_TAMC.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillQuotation_CGrid()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = QUOTATION_CLogicLayer.GetAllQUOTATION_CDetailByCompany((Session["COMP_CODE"].ToString()));
                GvQuotation_C.DataSource = Dt;
                GvQuotation_C.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvQuotation_T_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvQuotation_T.PageIndex = e.NewPageIndex;
            clear();
            FillQuotation_TGrid();
        }

        protected void GvQuotation_T_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    //RangeValidator rng = (RangeValidator)e.Row.FindControl("RangeDis");
                    //rng.MinimumValue = "0"; //Set index of min value column
                    //rng.MaximumValue = "100"; //Set index of max value column
                    //rng.ErrorMessage = "Invalid Percentage";
                    //rng.ControlToValidate = "TxtDisRate";
                    //rng.Type = ValidationDataType.Double;
                    //rng.ForeColor = Color.Red;

                    //RangeValidator RangeAddDis = (RangeValidator)e.Row.FindControl("RangeAddDis");
                    //RangeAddDis.MinimumValue = "0"; //Set index of min value column
                    //RangeAddDis.MaximumValue = "100"; //Set index of max value column
                    //RangeAddDis.ErrorMessage = "Invalid Percentage";
                    //RangeAddDis.ControlToValidate = "TxtAddDisRate";
                    //RangeAddDis.Type = ValidationDataType.Double;
                    //RangeAddDis.ForeColor = Color.Red;

                    TextBox TxtDisRate = (e.Row.FindControl("TxtDisRate") as TextBox);
                    TextBox TxtAddDisRate = (e.Row.FindControl("TxtAddDisRate") as TextBox);
                    TxtDisRate.Text = "0";
                    TxtAddDisRate.Text = "0";

                    TextBox TxtProductCode = (e.Row.FindControl("TxtProductCode") as TextBox);
                    TextBox TxtProductName = (e.Row.FindControl("TxtProductName") as TextBox);
                    DropDownList DdlProductName = (e.Row.FindControl("DdlProductName") as DropDownList);
                    HiddenField HfDetailSCode = (e.Row.FindControl("HfDetailSCode") as HiddenField);

                    DataTable DtProduct = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();

                    DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);

                    if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != string.Empty)
                    {
                        DataView Dv = new DataView(DtProduct);
                        Dv.RowFilter = "SCODE=" + HfDetailSCode.Value;
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            TxtProductName.Text = DtView.Rows[0]["SNAME"].ToString();
                            TxtProductCode.Text = DtView.Rows[0]["PROD_CODE"].ToString();
                        }
                        else
                        {
                            TxtProductName.Text = string.Empty;
                            TxtProductCode.Text = string.Empty;
                        }
                    }


                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblSumTotalQty = (Label)e.Row.FindControl("lblSumTotalQty");
                    Label lblSumTotalGross_AMT = (Label)e.Row.FindControl("lblSumTotalGross_AMT");
                    Label lblSumTotalCGST_AMT = (Label)e.Row.FindControl("lblSumTotalCGST_AMT");
                    Label lblSumTotalSGST_AMT = (Label)e.Row.FindControl("lblSumTotalSGST_AMT");
                    Label lblSumTotalIGST_AMT = (Label)e.Row.FindControl("lblSumTotalIGST_AMT");
                    Label lblSumTotalAmount = (Label)e.Row.FindControl("lblSumTotalAmount");

                    double lblTotalQuantity = TotalQuantity_T();
                    lblSumTotalQty.Text = lblTotalQuantity.ToString();

                    double lblTotGamount = TotalGrossAmount_T();
                    lblSumTotalGross_AMT.Text = lblTotGamount.ToString();

                    double lblTotCGSTAmt = TotalCGSTAmount_T();
                    lblSumTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                    double lblTotSGSTAmt = TotalSGSTAmount_T();
                    lblSumTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                    double lblTotIGSTAmt = TotalIGSTAmount_T();
                    lblSumTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                    double lblTotAmount = TotalAmount_T();
                    lblSumTotalAmount.Text = lblTotAmount.ToString();




                    if (lblSumTotalAmount.Text == string.Empty)
                    {
                        lblSumTotalAmount.Text = "0";
                        HfGrid_T_Total.Value = "0";

                    }
                    else
                    {
                           ViewState["Total_Quotation_T"]  = lblSumTotalAmount.Text.Trim();
                          // Grid_T_Total = Convert.ToDecimal(lblSumTotalAmount.Text.Trim());


                    }

                    FillNetAmount();


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region ADD NEW ROW IN QUOATATION_TGRID


        private void ClearQuotation_TGrid()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("PROD_CODE", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("RATE", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("DISC_PER", typeof(string));
            table.Columns.Add("DISC_AMT", typeof(string));
            table.Columns.Add("ADD_DISC_PER", typeof(string));
            table.Columns.Add("ADD_DISC_AMT", typeof(string));
            table.Columns.Add("G_AMT", typeof(string));
            table.Columns.Add("GST_RATE", typeof(string));
            table.Columns.Add("GST_AMT", typeof(string));
            table.Columns.Add("CGST_RATE", typeof(string));
            table.Columns.Add("CGST_AMT", typeof(string));
            table.Columns.Add("SGST_RATE", typeof(string));
            table.Columns.Add("SGST_AMT", typeof(string));
            table.Columns.Add("IGST_RATE", typeof(string));
            table.Columns.Add("IGST_AMT", typeof(string));
            table.Columns.Add("T_AMT", typeof(string));
            //table.Columns.Add("ADD_DISFLAG", typeof(string));


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["SCODE"] = string.Empty;
            dr["PROD_CODE"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["RATE"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["DISC_PER"] = string.Empty;
            dr["DISC_AMT"] = string.Empty;
            dr["ADD_DISC_PER"] = string.Empty;
            dr["ADD_DISC_AMT"] = string.Empty;
            dr["G_AMT"] = string.Empty;
            dr["GST_RATE"] = string.Empty;
            dr["GST_AMT"] = string.Empty;
            dr["CGST_RATE"] = string.Empty;
            dr["CGST_AMT"] = string.Empty;
            dr["SGST_RATE"] = string.Empty;
            dr["SGST_AMT"] = string.Empty;
            dr["IGST_RATE"] = string.Empty;
            dr["IGST_AMT"] = string.Empty;
            dr["T_AMT"] = string.Empty;
            //dr["ADD_DISFLAG"] = string.Empty;

            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvQuotation_T.DataSource = table;
            GvQuotation_T.DataBind();
        }

        private void SetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("PROD_CODE", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("RATE", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("DISC_PER", typeof(string));
            table.Columns.Add("DISC_AMT", typeof(string));
            table.Columns.Add("ADD_DISC_PER", typeof(string));
            table.Columns.Add("ADD_DISC_AMT", typeof(string));
            table.Columns.Add("G_AMT", typeof(string));
            table.Columns.Add("GST_RATE", typeof(string));
            table.Columns.Add("GST_AMT", typeof(string));
            table.Columns.Add("CGST_RATE", typeof(string));
            table.Columns.Add("CGST_AMT", typeof(string));
            table.Columns.Add("SGST_RATE", typeof(string));
            table.Columns.Add("SGST_AMT", typeof(string));
            table.Columns.Add("IGST_RATE", typeof(string));
            table.Columns.Add("IGST_AMT", typeof(string));
            table.Columns.Add("T_AMT", typeof(string));
            //table.Columns.Add("ADD_DISFLAG", typeof(string));


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["SCODE"] = string.Empty;
            dr["PROD_CODE"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["RATE"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["DISC_PER"] = string.Empty;
            dr["DISC_AMT"] = string.Empty;
            dr["ADD_DISC_PER"] = string.Empty;
            dr["ADD_DISC_AMT"] = string.Empty;
            dr["G_AMT"] = string.Empty;
            dr["GST_RATE"] = string.Empty;
            dr["GST_AMT"] = string.Empty;
            dr["CGST_RATE"] = string.Empty;
            dr["CGST_AMT"] = string.Empty;
            dr["SGST_RATE"] = string.Empty;
            dr["SGST_AMT"] = string.Empty;
            dr["IGST_RATE"] = string.Empty;
            dr["IGST_AMT"] = string.Empty;
            dr["T_AMT"] = string.Empty;
            //dr["ADD_DISFLAG"] = string.Empty;

            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvQuotation_T.DataSource = table;
            GvQuotation_T.DataBind();
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
                        //TextBox TxtSrNo = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[1].FindControl("TxtSrNo");
                        Label lblSumTotalQty = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalQty"));
                        Label lblSumTotalGross_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalGross_AMT"));
                        Label lblSumTotalCGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalCGST_AMT"));
                        Label lblSumTotalSGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalSGST_AMT"));
                        Label lblSumTotalIGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalIGST_AMT"));
                        Label lblSumTotalAmount = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalAmount"));

                        HiddenField HfDetailSCode = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtProductCode = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[1].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[2].FindControl("TxtProductName");
                        TextBox TxtQuantity = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[3].FindControl("TxtQuantity");
                        TextBox TxtRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[4].FindControl("TxtRate");
                        TextBox TxtDisRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[5].FindControl("TxtDisRate");
                        TextBox TxtAddDisRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[6].FindControl("TxtAddDisRate");
                        TextBox TxtAmount = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[7].FindControl("TxtAmount");
                        TextBox TxtCGSTRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[8].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[9].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[10].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[11].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[12].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[12].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[14].FindControl("TxtTotalAmount");

                        HiddenField HfAmountString = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        HiddenField HfDisAmount = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                        HiddenField HfAddDisAmount = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfAddDisAmount");
                        HiddenField HfGSTAmount = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfGSTRate = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");

                        //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["PROD_CODE"] = TxtProductCode.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtQuantity.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = HfAmountString.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["DISC_PER"] = TxtDisRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["DISC_AMT"] = HfDisAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["ADD_DISC_PER"] = TxtAddDisRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["ADD_DISC_AMT"] = HfAddDisAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["G_AMT"] = TxtAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["GST_RATE"] = HfGSTRate.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["CGST_RATE"] = TxtCGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["CGST_AMT"] = TxtCGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SGST_RATE"] = TxtSGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SGST_AMT"] = TxtSGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["IGST_RATE"] = TxtIGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["IGST_AMT"] = TxtIGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["T_AMT"] = TxtTotalAmount.Text.Trim();


                        rowIndex++;


                        double lblTotalQuantity = TotalQuantity_T();
                        lblSumTotalQty.Text = lblTotalQuantity.ToString();

                        double lblTotGamount = TotalGrossAmount_T();
                        lblSumTotalGross_AMT.Text = lblTotGamount.ToString();

                        double lblTotCGSTAmt = TotalCGSTAmount_T();
                        lblSumTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                        double lblTotSGSTAmt = TotalSGSTAmount_T();
                        lblSumTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                        double lblTotIGSTAmt = TotalIGSTAmount_T();
                        lblSumTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                        double lblTotAmount = TotalAmount_T();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();

                        if (lblSumTotalAmount.Text == string.Empty)
                        {
                            lblSumTotalAmount.Text = "0";
                            HfGrid_T_Total.Value = "0";
                        }
                        else
                        {
                            ViewState["Total_Quotation_T"] = lblSumTotalAmount.Text.Trim();
                        }

                        FillNetAmount();

                    }

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["SRNO"] = "0";
                    drCurrentRow["SCODE"] = "0";
                    drCurrentRow["PROD_CODE"] = "0";
                    drCurrentRow["QTY"] = "0";
                    drCurrentRow["RATE"] = "0";
                    drCurrentRow["AMT"] = "0";
                    drCurrentRow["DISC_PER"] = "0";
                    drCurrentRow["DISC_AMT"] = "0";
                    drCurrentRow["ADD_DISC_PER"] = "0";
                    drCurrentRow["ADD_DISC_AMT"] = "0";
                    drCurrentRow["G_AMT"] = "0";
                    drCurrentRow["GST_RATE"] = "0";
                    drCurrentRow["GST_AMT"] = "0";
                    drCurrentRow["CGST_RATE"] = "0";
                    drCurrentRow["CGST_AMT"] = "0";
                    drCurrentRow["SGST_RATE"] = "0";
                    drCurrentRow["SGST_AMT"] = "0";
                    drCurrentRow["IGST_RATE"] = "0";
                    drCurrentRow["IGST_AMT"] = "0";
                    drCurrentRow["T_AMT"] = "0";
                    //drCurrentRow["ADD_DISFLAG"] = "N"; 

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvQuotation_T.DataSource = dtCurrentTable;
                    GvQuotation_T.DataBind();
                }
            }

            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousData();
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //TextBox TxtSrNo = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[1].FindControl("TxtSrNo");
                        Label lblSumTotalQty = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalQty"));
                        Label lblSumTotalGross_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalGross_AMT"));
                        Label lblSumTotalCGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalCGST_AMT"));
                        Label lblSumTotalSGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalSGST_AMT"));
                        Label lblSumTotalIGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalIGST_AMT"));
                        Label lblSumTotalAmount = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalAmount"));

                        HiddenField HfDetailSCode = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtProductCode = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[1].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[2].FindControl("TxtProductName");
                        TextBox TxtQuantity = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[3].FindControl("TxtQuantity");
                        TextBox TxtRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[4].FindControl("TxtRate");
                        TextBox TxtDisRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[5].FindControl("TxtDisRate");
                        TextBox TxtAddDisRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[6].FindControl("TxtAddDisRate");
                        TextBox TxtAmount = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[7].FindControl("TxtAmount");
                        TextBox TxtCGSTRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[8].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[9].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[10].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[11].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[12].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[13].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[14].FindControl("TxtTotalAmount");

                        HiddenField HfAmountString = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        HiddenField HfDisAmount = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                        HiddenField HfAddDisAmount = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfAddDisAmount");
                        HiddenField HfGSTAmount = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfGSTRate = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");

                        //TxtSrNo.Text = dt.Rows[i]["SRNO"].ToString();
                        HfDetailSCode.Value = dt.Rows[i]["SCODE"].ToString();
                        TxtProductCode.Text = dt.Rows[i]["PROD_CODE"].ToString();
                        TxtQuantity.Text = dt.Rows[i]["QTY"].ToString();
                        TxtRate.Text = dt.Rows[i]["RATE"].ToString();
                        HfAmountString.Value = dt.Rows[i]["AMT"].ToString();
                        TxtDisRate.Text = dt.Rows[i]["DISC_PER"].ToString();
                        HfDisAmount.Value = dt.Rows[i]["DISC_AMT"].ToString();
                        TxtAddDisRate.Text = dt.Rows[i]["ADD_DISC_PER"].ToString();
                        HfAddDisAmount.Value = dt.Rows[i]["ADD_DISC_AMT"].ToString();
                        TxtAmount.Text = dt.Rows[i]["G_AMT"].ToString();
                        HfGSTRate.Value = dt.Rows[i]["GST_RATE"].ToString();
                        HfGSTAmount.Value = dt.Rows[i]["CGST_AMT"].ToString();
                        TxtCGSTRate.Text = dt.Rows[i]["GST_RATE"].ToString();
                        TxtCGSTAmount.Text = dt.Rows[i]["CGST_AMT"].ToString();
                        TxtSGSTRate.Text = dt.Rows[i]["SGST_RATE"].ToString();
                        TxtSGSTAmount.Text = dt.Rows[i]["SGST_AMT"].ToString();
                        TxtIGSTRate.Text = dt.Rows[i]["IGST_RATE"].ToString();
                        TxtIGSTAmount.Text = dt.Rows[i]["IGST_AMT"].ToString();
                        TxtTotalAmount.Text = dt.Rows[i]["T_AMT"].ToString();

                        rowIndex++;

                        double lblTotalQuantity = TotalQuantity_T();
                        lblSumTotalQty.Text = lblTotalQuantity.ToString();

                        double lblTotGamount = TotalGrossAmount_T();
                        lblSumTotalGross_AMT.Text = lblTotGamount.ToString();

                        double lblTotCGSTAmt = TotalCGSTAmount_T();
                        lblSumTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                        double lblTotSGSTAmt = TotalSGSTAmount_T();
                        lblSumTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                        double lblTotIGSTAmt = TotalIGSTAmount_T();
                        lblSumTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                        double lblTotAmount = TotalAmount_T();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();

                        if (lblSumTotalAmount.Text == string.Empty)
                        {
                            lblSumTotalAmount.Text = "0";
                            HfGrid_T_Total.Value = "0";
                        }
                        else
                        {
                            ViewState["Total_Quotation_T"] = lblSumTotalAmount.Text.Trim();
                        }

                        FillNetAmount();

                    }
                }
            }
        }

        protected void BtnDeleteRowModelQuo_TGrid_Click(object sender, EventArgs e)
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
                GvQuotation_T.DataSource = dt;
                GvQuotation_T.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }

        protected void BtnAddRowModelQuo_TGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        #endregion

        protected void GvQuotation_C_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvQuotation_C.PageIndex = e.NewPageIndex;
            clear();
            FillQuotation_CGrid();
        }


        protected void GvQuotation_C_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    TextBox TxtChargesName = (e.Row.FindControl("TxtChargesName") as TextBox);
                    DropDownList DdlChargesName = (e.Row.FindControl("DdlChargesName") as DropDownList);
                    HiddenField HfChargesCode = (e.Row.FindControl("HfChargesCode") as HiddenField);

                    DataTable DtChargesName = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();

                    DtChargesName = CHARGES_MASLogicLayer.GetAllCHARGESDetialsForComapnyWise_DDL(Comp_Code);

                    //DdlChargesName.DataValueField = "CCODE";
                    //DdlChargesName.DataTextField = "NAME";
                    //DdlChargesName.DataSource = Dt;
                    //DdlChargesName.DataBind();

                    //DdlChargesName.SelectedValue = HfChargesCode.Value;


                    if (HfChargesCode.Value != "0" && HfChargesCode.Value != string.Empty)
                    {
                        DataView Dv = new DataView(DtChargesName);
                        Dv.RowFilter = "CCODE=" + HfChargesCode.Value;
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            TxtChargesName.Text = DtView.Rows[0]["NAME"].ToString();
                        }
                        else
                        {
                            TxtChargesName.Text = string.Empty;

                        }
                    }
                }


                if (e.Row.RowType == DataControlRowType.Footer)
                {

                    Label lblSumTotalCharges_Qty = (Label)e.Row.FindControl("lblSumTotalCharges_Qty");
                    Label lblSumTotalCharge_AMT = (Label)e.Row.FindControl("lblSumTotalCharge_AMT");
                    Label lblSumTotalChargesCGST_AMT = (Label)e.Row.FindControl("lblSumTotalChargesCGST_AMT");
                    Label lblSumTotalChargesSGST_AMT = (Label)e.Row.FindControl("lblSumTotalChargesSGST_AMT");
                    Label lblSumTotalChargesIGST_AMT = (Label)e.Row.FindControl("lblSumTotalChargesIGST_AMT");
                    Label lblSumTotalAmount = (Label)e.Row.FindControl("lblSumTotalAmount");

                    double lblTotalQuantity = TotalQuantity_C();
                    lblSumTotalCharges_Qty.Text = lblTotalQuantity.ToString();

                    double lblTotGamount = TotalGrossAmount_C();
                    lblSumTotalCharge_AMT.Text = lblTotGamount.ToString();

                    double lblTotCGSTAmt = TotalCGSTAmount_C();
                    lblSumTotalChargesCGST_AMT.Text = lblTotCGSTAmt.ToString();

                    double lblTotSGSTAmt = TotalSGSTAmount_C();
                    lblSumTotalChargesSGST_AMT.Text = lblTotSGSTAmt.ToString();

                    double lblTotIGSTAmt = TotalIGSTAmount_C();
                    lblSumTotalChargesIGST_AMT.Text = lblTotIGSTAmt.ToString();

                    double lblTotAmount = TotalAmount_C();
                    lblSumTotalAmount.Text = lblTotAmount.ToString();

                    if (lblSumTotalAmount.Text == string.Empty)
                    {
                        lblSumTotalAmount.Text = "0";
                        HfGrid_C_Total.Value = "0";
                    }
                    else
                    {
                          ViewState["Total_Quotation_C"] = lblSumTotalAmount.Text.Trim();

                          // Grid_C_Total = Convert.ToDecimal(lblSumTotalAmount.Text.Trim());
                    }

                    FillNetAmount();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        #region ADD NEW ROW IN QUOTATION_CGRID

        private void ClearQuotation_CGrid()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            //table.Columns.Add("SR", typeof(string));
            table.Columns.Add("CCODE", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("PER", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("GST_RATE", typeof(string));
            table.Columns.Add("GST_AMT", typeof(string));
            table.Columns.Add("CGST_RATE", typeof(string));
            table.Columns.Add("CGST_AMT", typeof(string));
            table.Columns.Add("SGST_RATE", typeof(string));
            table.Columns.Add("SGST_AMT", typeof(string));
            table.Columns.Add("IGST_RATE", typeof(string));
            table.Columns.Add("IGST_AMT", typeof(string));
            table.Columns.Add("T_AMT", typeof(string));

            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            //dr["SR"] = string.Empty;
            dr["CCODE"] = string.Empty;
            dr["QTY"] = string.Empty; ;
            dr["PER"] = string.Empty; ;
            dr["AMT"] = string.Empty;
            dr["GST_RATE"] = string.Empty;
            dr["GST_AMT"] = string.Empty;
            dr["CGST_RATE"] = string.Empty;
            dr["CGST_AMT"] = string.Empty;
            dr["SGST_RATE"] = string.Empty;
            dr["SGST_AMT"] = string.Empty;
            dr["IGST_RATE"] = string.Empty;
            dr["IGST_AMT"] = string.Empty;
            dr["T_AMT"] = string.Empty; ;

            table.Rows.Add(dr);

            ViewState["CurrentTable_C"] = table;

            GvQuotation_C.DataSource = table;
            GvQuotation_C.DataBind();
        }


        private void SetInitialRow1()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            //table.Columns.Add("SR", typeof(string));
            table.Columns.Add("CCODE", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("PER", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("GST_RATE", typeof(string));
            table.Columns.Add("GST_AMT", typeof(string));
            table.Columns.Add("CGST_RATE", typeof(string));
            table.Columns.Add("CGST_AMT", typeof(string));
            table.Columns.Add("SGST_RATE", typeof(string));
            table.Columns.Add("SGST_AMT", typeof(string));
            table.Columns.Add("IGST_RATE", typeof(string));
            table.Columns.Add("IGST_AMT", typeof(string));
            table.Columns.Add("T_AMT", typeof(string));

            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            //dr["SR"] = string.Empty;
            dr["CCODE"] = string.Empty;
            dr["QTY"] = string.Empty; ;
            dr["PER"] = string.Empty; ;
            dr["AMT"] = string.Empty;
            dr["GST_RATE"] = string.Empty;
            dr["GST_AMT"] = string.Empty;
            dr["CGST_RATE"] = string.Empty;
            dr["CGST_AMT"] = string.Empty;
            dr["SGST_RATE"] = string.Empty;
            dr["SGST_AMT"] = string.Empty;
            dr["IGST_RATE"] = string.Empty;
            dr["IGST_AMT"] = string.Empty;
            dr["T_AMT"] = string.Empty; ;

            table.Rows.Add(dr);

            ViewState["CurrentTable_C"] = table;

            GvQuotation_C.DataSource = table;
            GvQuotation_C.DataBind();
        }

        private void AddNewRowToGrid1()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable_C"] != null)
            {
                DataTable dtCurrentTable_C = (DataTable)ViewState["CurrentTable_C"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable_C.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable_C.Rows.Count; i++)
                    {
                        //extract the TextBox values 
                        //TextBox TxtSr = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtSr");

                        Label lblSumTotalCharges_Qty = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalCharges_Qty"));
                        Label lblSumTotalCharge_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalCharge_AMT"));
                        Label lblSumTotalChargesCGST_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalChargesCGST_AMT"));
                        Label lblSumTotalChargesSGST_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalChargesSGST_AMT"));
                        Label lblSumTotalChargesIGST_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalChargesIGST_AMT"));
                        Label lblSumTotalAmount = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalAmount"));

                        HiddenField HfChargesCode = (HiddenField)GvQuotation_C.Rows[rowIndex].Cells[0].FindControl("HfChargesCode");
                        //   DropDownList DdlChargesName = (DropDownList)GvQuotation_C.Rows[rowIndex].Cells[2].FindControl("DdlChargesName");
                        TextBox TxtChargesName = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtChargesName");
                        TextBox TxtRate = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[2].FindControl("TxtRate");
                        TextBox TxtQuantity = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[3].FindControl("TxtQuantity");
                        TextBox TxtChargesAmt = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[4].FindControl("TxtChargesAmt");
                        TextBox TxtCGSTRate = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[5].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[6].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[7].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[8].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[09].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[10].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[11].FindControl("TxtTotalAmount");


                        HiddenField HfGSTRate = (HiddenField)GvQuotation_C.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                        HiddenField HfGSTAmount = (HiddenField)GvQuotation_C.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");

                        //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["CCODE"] = HfChargesCode.Value.Trim();
                        dtCurrentTable_C.Rows[i - 1]["QTY"] = TxtQuantity.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["PER"] = TxtRate.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["AMT"] = TxtChargesAmt.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["GST_RATE"] = HfGSTRate.Value.Trim();
                        dtCurrentTable_C.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                        dtCurrentTable_C.Rows[i - 1]["CGST_RATE"] = TxtCGSTRate.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["CGST_AMT"] = TxtCGSTAmount.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["SGST_RATE"] = TxtSGSTRate.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["SGST_AMT"] = TxtSGSTAmount.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["IGST_RATE"] = TxtIGSTRate.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["IGST_AMT"] = TxtIGSTAmount.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["T_AMT"] = TxtTotalAmount.Text.Trim();


                        rowIndex++;

                        double lblTotalQuantity = TotalQuantity_C();
                        lblSumTotalCharges_Qty.Text = lblTotalQuantity.ToString();

                        double lblTotGamount = TotalGrossAmount_C();
                        lblSumTotalCharge_AMT.Text = lblTotGamount.ToString();

                        double lblTotCGSTAmt = TotalCGSTAmount_C();
                        lblSumTotalChargesCGST_AMT.Text = lblTotCGSTAmt.ToString();

                        double lblTotSGSTAmt = TotalSGSTAmount_C();
                        lblSumTotalChargesSGST_AMT.Text = lblTotSGSTAmt.ToString();

                        double lblTotIGSTAmt = TotalIGSTAmount_C();
                        lblSumTotalChargesIGST_AMT.Text = lblTotIGSTAmt.ToString();

                        double lblTotAmount = TotalAmount_C();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();

                        if (lblSumTotalAmount.Text == string.Empty)
                        {
                            lblSumTotalAmount.Text = "0";
                            HfGrid_C_Total.Value = "0";
                        }
                        else
                        {
                            // HfGrid_T_Total.Value = lblSumTotalAmount.Text.Trim();

                            ViewState["Total_Quotation_C"] = Convert.ToDecimal(lblSumTotalAmount.Text.Trim());
                        }

                        FillNetAmount();
                    }

                    drCurrentRow = dtCurrentTable_C.NewRow();
                    //drCurrentRow["SR"] = "";
                    drCurrentRow["CCODE"] = "0";
                    drCurrentRow["QTY"] = "0";
                    drCurrentRow["PER"] = "0";
                    drCurrentRow["AMT"] = "0";
                    drCurrentRow["GST_RATE"] = "0";
                    drCurrentRow["GST_AMT"] = "0";
                    drCurrentRow["CGST_RATE"] = "0";
                    drCurrentRow["CGST_AMT"] = "0";
                    drCurrentRow["SGST_RATE"] = "0";
                    drCurrentRow["SGST_AMT"] = "0";
                    drCurrentRow["IGST_RATE"] = "0";
                    drCurrentRow["IGST_AMT"] = "0";
                    drCurrentRow["T_AMT"] = "0";

                    dtCurrentTable_C.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable_C"] = dtCurrentTable_C;

                    GvQuotation_C.DataSource = dtCurrentTable_C;
                    GvQuotation_C.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousData1();
        }

        private void SetPreviousData1()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable_C"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable_C"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //TextBox TxtSr = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtSr");
                        Label lblSumTotalCharges_Qty = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalCharges_Qty"));
                        Label lblSumTotalCharge_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalCharge_AMT"));
                        Label lblSumTotalChargesCGST_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalChargesCGST_AMT"));
                        Label lblSumTotalChargesSGST_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalChargesSGST_AMT"));
                        Label lblSumTotalChargesIGST_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalChargesIGST_AMT"));
                        Label lblSumTotalAmount = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalAmount"));

                        HiddenField HfChargesCode = (HiddenField)GvQuotation_C.Rows[rowIndex].Cells[0].FindControl("HfChargesCode");
                        //   DropDownList DdlChargesName = (DropDownList)GvQuotation_C.Rows[rowIndex].Cells[2].FindControl("DdlChargesName");
                        TextBox TxtChargesName = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtChargesName");
                        TextBox TxtRate = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[2].FindControl("TxtRate");
                        TextBox TxtQuantity = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[3].FindControl("TxtQuantity");
                        TextBox TxtChargesAmt = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[4].FindControl("TxtChargesAmt");
                        TextBox TxtCGSTRate = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[5].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[6].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[7].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[8].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[09].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[10].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[11].FindControl("TxtTotalAmount");

                        HiddenField HfGSTRate = (HiddenField)GvQuotation_C.Rows[rowIndex].Cells[12].FindControl("HfGSTRate");
                        HiddenField HfGSTAmount = (HiddenField)GvQuotation_C.Rows[rowIndex].Cells[12].FindControl("HfGSTAmount");

                        //TxtSr.Text = Convert.ToString(i + 1);
                        HfChargesCode.Value = dt.Rows[i]["CCODE"].ToString();
                        TxtQuantity.Text = dt.Rows[i]["QTY"].ToString();
                        TxtRate.Text = dt.Rows[i]["PER"].ToString();
                        TxtChargesAmt.Text = dt.Rows[i]["AMT"].ToString();
                        HfGSTRate.Value = dt.Rows[i]["GST_RATE"].ToString();
                        HfGSTAmount.Value = dt.Rows[i]["GST_AMT"].ToString();
                        TxtCGSTRate.Text = dt.Rows[i]["CGST_RATE"].ToString();
                        TxtCGSTAmount.Text = dt.Rows[i]["CGST_AMT"].ToString();
                        TxtSGSTRate.Text = dt.Rows[i]["SGST_RATE"].ToString();
                        TxtSGSTAmount.Text = dt.Rows[i]["SGST_AMT"].ToString();
                        TxtIGSTRate.Text = dt.Rows[i]["IGST_RATE"].ToString();
                        TxtIGSTAmount.Text = dt.Rows[i]["IGST_AMT"].ToString();
                        TxtTotalAmount.Text = dt.Rows[i]["T_AMT"].ToString();

                        rowIndex++;

                        double lblTotalQuantity = TotalQuantity_C();
                        lblSumTotalCharges_Qty.Text = lblTotalQuantity.ToString();

                        double lblTotGamount = TotalGrossAmount_C();
                        lblSumTotalCharge_AMT.Text = lblTotGamount.ToString();

                        double lblTotCGSTAmt = TotalCGSTAmount_C();
                        lblSumTotalChargesCGST_AMT.Text = lblTotCGSTAmt.ToString();

                        double lblTotSGSTAmt = TotalSGSTAmount_C();
                        lblSumTotalChargesSGST_AMT.Text = lblTotSGSTAmt.ToString();

                        double lblTotIGSTAmt = TotalIGSTAmount_C();
                        lblSumTotalChargesIGST_AMT.Text = lblTotIGSTAmt.ToString();

                        double lblTotAmount = TotalAmount_C();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();

                        if (lblSumTotalAmount.Text == string.Empty)
                        {
                            lblSumTotalAmount.Text = "0";
                            HfGrid_C_Total.Value = "0";
                        }
                        else
                        {
                            ViewState["Total_Quotation_C"] = lblSumTotalAmount.Text.Trim();
                        }

                        FillNetAmount();
                    }
                }
            }
        }
        protected void BtnAddRowModelQuo_CGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid1();
        }

        protected void BtnDeleteRowModelQuo_CGrid_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex + 1;
            if (ViewState["CurrentTable_C"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable_C"];
                if (dt.Rows.Count > 1)
                {

                    if (gvRow.RowIndex <= dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data
                        dt.Rows.Remove(dt.Rows[rowID - 1]);
                    }
                }
                //Store the current data in ViewState for future reference
                ViewState["CurrentTable_C"] = dt;
                //Re bind the GridView for the updated data
                GvQuotation_C.DataSource = dt;
                GvQuotation_C.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData1();
        }

        #endregion

        protected void DdlOrdConfirm_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlOrdConfirm.SelectedValue == "Y")
                {
                    TxtConfirmBy.Text = Session["USERNAME"].ToString();
                    TxtConfirmDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    TxtConfirmBy.Text = "";
                    TxtConfirmDate.Text = "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ControllerEnable()
        {
            //  TxtROamt.Enabled = true;
            //  TxtNetAmt.Enabled = true;
            TxtQuotationNo.Enabled = false;
            TxtQuotationDate.Enabled = true;
            TxtAccountName.Enabled = true;
            DdlKindAttn.Enabled = true;
            TxtConatctPhone.Enabled = true;
            TxtContactEmail.Enabled = true;
            TxtPartyRefNo.Enabled = true;
            TxtRemark.Enabled = true;
            TxtPaymentTerms.Enabled = true;
            TxtPriceTerms.Enabled = true;
            TxtDeliveryTerms.Enabled = true;
            TxtValidityTerms.Enabled = true;
            TxtTransportationTerms.Enabled = true;
            DdlPreparedBy.Enabled = true;
            DdlPartyType.Enabled = true;
            DdlSalesType.Enabled = true;
            DdlCSTtype.Enabled = true;
            DdlOrdConfirm.Enabled = true;
            TxtConfirmDate.Enabled = true;
            TxtConfirmBy.Enabled = true;
            TxtSubject.Enabled = true;
            TxtModelNo.Enabled = true;
            TxtFor.Enabled = true;
            TxtBrandName.Enabled = true;
            TxtNote.Enabled = true;
           
        }

        public void ControllerDisable()
        {
            TxtROamt.Enabled = false;
            TxtNetAmt.Enabled = false;
            TxtQuotationNo.Enabled = false;
            TxtQuotationDate.Enabled = false;
            TxtAccountName.Enabled = false;
            DdlKindAttn.Enabled = false;
            TxtConatctPhone.Enabled = false;
            TxtContactEmail.Enabled = false;
            TxtPartyRefNo.Enabled = false;
            TxtRemark.Enabled = false;
            TxtPaymentTerms.Enabled = false;
            TxtPriceTerms.Enabled = false;
            TxtDeliveryTerms.Enabled = false;
            TxtValidityTerms.Enabled = false;
            TxtTransportationTerms.Enabled = false;
            DdlPreparedBy.Enabled = false;
            DdlPartyType.Enabled = false;
            DdlSalesType.Enabled = false;
            DdlCSTtype.Enabled = false;
            DdlOrdConfirm.Enabled = false;
            TxtConfirmDate.Enabled = false;
            TxtConfirmBy.Enabled = false;
            TxtSubject.Enabled = false;
            TxtModelNo.Enabled = false;
            TxtFor.Enabled = false;
            TxtBrandName.Enabled = false;
            TxtNote.Enabled = false;

        }

        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;


            HfACODE.Value = string.Empty;
            HfCompCode.Value = string.Empty;
            HfBranchCode.Value = string.Empty;
            HfSrNo.Value = string.Empty;

            //      DdlBrandNameCopy.SelectedIndex = 0;
            //      DdlModelNameCopy.SelectedIndex = 0;
            TxtModelDescrption.Text = string.Empty;
            HfCompCode.Value = string.Empty;
            HfBranchCode.Value = string.Empty;
            HfTranDate.Value = string.Empty;
            HfTranNo.Value = string.Empty;
            TxtQuotationNo.Text = string.Empty;
            TxtQuotationDate.Text = string.Empty;
            TxtAccountName.Text = string.Empty;
      //      DdlKindAttn.SelectedIndex = 0;
            TxtConatctPhone.Text = string.Empty;
            TxtContactEmail.Text = string.Empty;
            TxtPartyRefNo.Text = string.Empty;
            TxtRemark.Text = string.Empty;
            TxtPaymentTerms.Text = string.Empty;
            TxtPriceTerms.Text = string.Empty;
            TxtDeliveryTerms.Text = string.Empty;
            TxtValidityTerms.Text = string.Empty;
            TxtTransportationTerms.Text = string.Empty;
            DdlPreparedBy.SelectedIndex = 0;
            DdlPartyType.SelectedIndex = 0;
            DdlSalesType.SelectedIndex = 0;
            DdlCSTtype.SelectedIndex = 0;
            DdlOrdConfirm.SelectedValue = "N";
            TxtConfirmDate.Text = string.Empty;
            TxtConfirmBy.Text = string.Empty;
            TxtSubject.Text = string.Empty;
            TxtModelNo.Text = string.Empty;
            TxtFor.Text = string.Empty;
            TxtBrandName.Text = string.Empty;
            TxtNote.Text = string.Empty;
            TxtROamt.Text = string.Empty;
            TxtNetAmt.Text = string.Empty;
            lblmsg.Text = string.Empty;

            ClearQuotation_TGrid();
            ClearQuotation_TAMCGrid();
            ClearQuotation_CGrid();

            GvStockModalDetails.DataSource = null;
            GvStockModalDetails.DataBind();


            BtncallUpd.Text = "SAVE";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ViewState["CurrentTable"] = null;
            ViewState["CurrentTable_TAMC"] = null;
            ViewState["CurrentTable_C"] = null;
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
                getQuo_Sub1bByCompany();
                getQuo_Sub2bByCompany();
                getQuo_BrandNameByCompany();
                getQuo_ModelNameByCompany();
                getQuo_NoteByCompany();
                dvcompanyFor.Visible = true;
                dvBrandName.Visible = true;
                dvModelName.Visible = true;
                TxtQuotationDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                TxtPaymentTerms.Text = "BY CHEQUE ON DELIVERY";
                TxtPriceTerms.Text = "EXCLUDING OF GUJARAT TAX";
                TxtDeliveryTerms.Text = "3-4 DAYS";
                TxtValidityTerms.Text = "30 DAYS";
                TxtTransportationTerms.Text = "EXTRA CHARGES";
                HfQuoteType.Value = "I";
                BtnSearchModelDetails.Visible = true;
                BtnSearchPartyModel.Visible = true;
                GvQuotation_C.Enabled = true;
                GvQuotation_T.Enabled = true;
                //  TxtConfirmBy.Text = Session["USERNAME"].ToString();
                string QuotationNo = QUOTATION_MLogicLayer.GetQuoNoQUOATATION_MASDetailCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtQuotationDate.Text.Trim()).ToString("yyyy-MM-dd"));
                if (QuotationNo.Length <= 8)
                {
                    TxtQuotationNo.Text = QuotationNo;
                }
                else
                {
                    TxtQuotationNo.Text = string.Empty;
                }


                DivQuoteItem.Visible = true;
                DivQuoteAMC.Visible = false;




            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/StockModelMaster.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region UPDATE QUOTATION_MAS

                #region INSERT QUOTATION_M

                QUOTATION_MLogicLayer insert = new QUOTATION_MLogicLayer();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim().ToString()).ToString("MM-dd-yyyy");//HfTranDate.Value.Trim();
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.COMP_CODE = HfCompCode.Value.Trim();

                if (TxtQuotationNo.Text == string.Empty)
                {
                    insert.QUO_NO = "0";
                }
                else
                {
                    insert.QUO_NO = TxtQuotationNo.Text.Trim();
                }
                insert.QUO_DATE = Convert.ToDateTime(TxtQuotationDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                insert.PARTY_NAME = TxtAccountName.Text.Trim().ToUpper();
                insert.PARTY_ADD1 = "";
                insert.ENGINE_TYPE = "";
                insert.VEHICLE_NO = "";
                insert.GROSS_AMT = "0";
                insert.CHARGES_AMT = "0";
                if (TxtROamt.Text == string.Empty)
                {
                    insert.RO_AMT = "0";
                }
                else
                {
                    insert.RO_AMT = TxtROamt.Text.Trim();
                }

                insert.DISC_PER = "0";
                insert.DISC_AMT = "0";
                if (TxtNetAmt.Text == string.Empty)
                {
                    insert.NET_AMT = "0";
                }
                else
                {
                    insert.NET_AMT = TxtNetAmt.Text.Trim();
                }

                insert.ENDT = "";
                insert.PRICE_TERMS = TxtPriceTerms.Text.Trim().ToUpper();
                insert.PAYMENT_TERMS = TxtPaymentTerms.Text.Trim().ToUpper();
                insert.DELIVERY_TERMS = TxtDeliveryTerms.Text.Trim().ToUpper();
                insert.VALIDITY_TERMS = TxtValidityTerms.Text.Trim().ToUpper();
                insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                insert.KIND_ATTN = DdlKindAttn.SelectedItem.Text.Trim().ToUpper();
                insert.TRANSPORT_TERMS = TxtTransportationTerms.Text.Trim().ToUpper();
                insert.BRANCH_CODE = HfBranchCode.Value.Trim();
                insert.BCODE = DdlPreparedBy.SelectedValue.Trim();
                insert.SALES_TYPE = DdlSalesType.SelectedValue.Trim().ToUpper();
                insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToUpper();
                insert.CST_TYPE = DdlCSTtype.SelectedValue.Trim().ToUpper();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";
                insert.CONF_FLAG = DdlOrdConfirm.SelectedValue.Trim().ToUpper();
                if (DdlOrdConfirm.SelectedValue == "Y")
                {
                    insert.CONF_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.CONF_DATE = "";
                }

                if (DdlOrdConfirm.SelectedValue == "Y")
                {
                    insert.CONF_USERID = TxtConfirmBy.Text.Trim().ToUpper();
                }
                else
                {
                    insert.CONF_USERID = "";
                }
                insert.PARTY_ADD2 = "";
                insert.PARTY_ADD3 = "";
                insert.PARTY_VAT = "";
                insert.PARTY_CST = "";
                insert.PARTY_PHONE = "";
                insert.ACODE = HfACODE.Value.Trim();
                insert.ATYPE = "";
                insert.PARTY_REFNO = TxtPartyRefNo.Text.Trim().ToUpper();
                insert.BRAND_NAME = TxtBrandName.Text.Trim().ToUpper();
                insert.MODEL_NAME = TxtModelNo.Text.Trim().ToUpper();
                insert.SUB1 = TxtSubject.Text.Trim().ToUpper();
                insert.SUB2 = TxtFor.Text.Trim().ToUpper();
                insert.SUB3 = "";
                insert.SUB4 = "";
                insert.NOTE = TxtNote.Text.Trim().ToUpper();
                insert.QUO_TYPE = HfQuoteType.Value;
                insert.KIND_ATTN_PHONE = TxtConatctPhone.Text.Trim().ToUpper();
                insert.KIND_ATTN_EMAIL = TxtContactEmail.Text.Trim().ToUpper();
                insert.STATUS = "";
                insert.REF_BY = "";
                insert.REF_TRAN_DATE = "";
                insert.REF_TRAN_NO = "0";
                insert.GST_RATE = "0";
                insert.GST_AMT = "0";
                insert.CGST_RATE = "0";
                insert.CGST_AMT = "0";
                insert.SGST_RATE = "0";
                insert.SGST_AMT = "0";
                insert.IGST_RATE = "0";
                insert.IGST_AMT = "0";
                #endregion


                #region INSERT QUOTATION_T FOR ITEM

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);
                int QUO_TSRNO = 1;

                if (HfQuoteType.Value == "I")
                {

                    foreach (GridViewRow row in GvQuotation_T.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {


                            HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                            TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                            TextBox TxtQuantity = row.FindControl("TxtQuantity") as TextBox;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtDisRate = row.FindControl("TxtDisRate") as TextBox;
                            TextBox TxtAddDisRate = row.FindControl("TxtAddDisRate") as TextBox;
                            TextBox TxtAmount = row.FindControl("TxtAmount") as TextBox;
                            TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                            TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                            TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                            TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                            TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                            TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                            TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;


                            if (HfDetailSCode.Value != "0")
                            {

                                XmlElement HandleDetail2 = XDoc1.CreateElement("Quotation_T");
                                HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                                HandleDetail2.SetAttribute("BRANCH_CODE", HfBranchCode.Value.Trim());
                                HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                HiddenField HfAmount = row.FindControl("HfAmount") as HiddenField;
                                HiddenField HfDisAmount = row.FindControl("HfDisAmount") as HiddenField;
                                HiddenField HfAddDisAmount = row.FindControl("HfAddDisAmount") as HiddenField;
                                HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                                HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;

                                HandleDetail2.SetAttribute("SRNO", QUO_TSRNO.ToString());

                                if (HfDetailSCode.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SCODE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value));
                                }

                                if (TxtQuantity.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("QTY", (TxtQuantity.Text));
                                }
                                if (TxtRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("RATE", (TxtRate.Text));
                                }

                                if (HfAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("AMT", (HfAmount.Value));
                                }
                                if (TxtDisRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DISC_PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("DISC_PER", (TxtDisRate.Text));
                                }

                                if (HfDisAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DISC_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("DISC_AMT", (HfDisAmount.Value));
                                }
                                if (TxtAddDisRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("ADD_DISC_PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("ADD_DISC_PER", (TxtAddDisRate.Text));
                                }

                                if (HfAddDisAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("ADD_DISC_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("ADD_DISC_AMT", (HfAddDisAmount.Value));
                                }

                                if (HfGSTRate.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("GST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("GST_RATE", (HfGSTRate.Value));
                                }

                                if (HfGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("GST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("GST_AMT", (HfGSTAmount.Value));
                                }

                                if (TxtAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("G_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("G_AMT", (TxtAmount.Text));
                                }

                                if (TxtCGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CGST_RATE", (TxtCGSTRate.Text));
                                }
                                if (TxtCGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text));
                                }
                                if (TxtSGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SGST_RATE", (TxtSGSTRate.Text));
                                }
                                if (TxtSGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text));
                                }
                                if (TxtIGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("IGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("IGST_RATE", (TxtIGSTRate.Text));
                                }
                                if (TxtIGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("IGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text));
                                }
                                if (TxtTotalAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("T_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("T_AMT", (TxtTotalAmount.Text));
                                }

                                root1.AppendChild(HandleDetail2);
                                QUO_TSRNO++;
                            }
                        }
                    }
                }
                else
                {
                    #region INSERT QUOTATION FOR AMC
                    foreach (GridViewRow row in GvQuotation_TAMC.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            TextBox TxtBrandName = row.FindControl("TxtBrandName") as TextBox;
                            HiddenField HfBrandCodeGrid = row.FindControl("HfBrandCodeGrid") as HiddenField;
                            TextBox TxtModelName = row.FindControl("TxtModelName") as TextBox;
                            HiddenField HfModelCodeGrid = row.FindControl("HfModelCodeGrid") as HiddenField;
                            //DropDownList DdlBrandName = row.FindControl("DdlBrandName") as DropDownList;
                            //DropDownList DdlModelName = row.FindControl("DdlModelName") as DropDownList;
                            TextBox TxtModelDescription = row.FindControl("TxtModelDescription") as TextBox;
                            TextBox TxtQuantity = row.FindControl("TxtQuantity") as TextBox;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtDisRate = row.FindControl("TxtDisRate") as TextBox;
                            TextBox TxtAddDisRate = row.FindControl("TxtAddDisRate") as TextBox;
                            TextBox TxtAmount = row.FindControl("TxtAmount") as TextBox;
                            TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                            TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                            TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                            TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                            TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                            TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                            TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;

                            XmlElement HandleDetail2 = XDoc1.CreateElement("Quotation_T");
                            HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                            HandleDetail2.SetAttribute("BRANCH_CODE", HfBranchCode.Value.Trim());
                            HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                            HiddenField HfAmount = row.FindControl("HfAmount") as HiddenField;
                            HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                            HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;

                            HandleDetail2.SetAttribute("SRNO", QUO_TSRNO.ToString());
                            HandleDetail2.SetAttribute("BRAND_CODE", (HfBrandCodeGrid.Value.Trim()));
                            HandleDetail2.SetAttribute("MODEL_CODE", (HfModelCodeGrid.Value.Trim()));
                            if (TxtQuantity.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("QTY", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("QTY", (TxtQuantity.Text));
                            }
                            if (TxtRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("RATE", (TxtRate.Text));
                            }
                            if (TxtAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("AMT", (TxtAmount.Text));
                            }

                            if (TxtDisRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("DISC_PER", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("DISC_PER", (TxtDisRate.Text));
                            }

                            if (TxtAddDisRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("ADD_DISC_PER", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("ADD_DISC_PER", (TxtAddDisRate.Text));
                            }
                            if (TxtAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("G_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("G_AMT", (TxtAmount.Text));
                            }

                            if (HfGSTRate.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("GST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("GST_RATE", (HfGSTRate.Value));
                            }

                            if (HfGSTAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("GST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("GST_AMT", (HfGSTAmount.Value));
                            }
                            if (TxtCGSTRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("CGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("CGST_RATE", (TxtCGSTRate.Text));
                            }
                            if (TxtCGSTAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("CGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text));
                            }
                            if (TxtSGSTRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("SGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("SGST_RATE", (TxtSGSTRate.Text));
                            }
                            if (TxtSGSTAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("SGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text));
                            }
                            if (TxtIGSTRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("IGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("IGST_RATE", (TxtIGSTRate.Text));
                            }
                            if (TxtIGSTAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("IGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text));
                            }
                            if (TxtTotalAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("T_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("T_AMT", (TxtTotalAmount.Text));
                            }

                            root1.AppendChild(HandleDetail2);
                            QUO_TSRNO++;


                        }
                    }

                    #endregion
                }

                #endregion

                #region INSERT QUOTATION_C

                XmlDocument XDoc2 = new XmlDocument();
                XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                XDoc2.AppendChild(dec2);// Create the root element
                XmlElement root2 = XDoc2.CreateElement("root");
                XDoc2.AppendChild(root2);
                int QUO_CSRNO = 1;

                foreach (GridViewRow row in GvQuotation_C.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        HiddenField HfChargesCode = row.FindControl("HfChargesCode") as HiddenField;
                        //  DropDownList DdlChargesName = row.FindControl("DdlChargesName") as DropDownList;
                        TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                        TextBox TxtQuantity = row.FindControl("TxtQuantity") as TextBox;
                        TextBox TxtChargesAmt = row.FindControl("TxtChargesAmt") as TextBox;
                        TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                        TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                        TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                        TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                        TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                        TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                        TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;

                        if (HfChargesCode.Value != "0")
                        {

                            XmlElement HandleDetail3 = XDoc2.CreateElement("Quotation_C");
                            HandleDetail3.SetAttribute("SR", QUO_CSRNO.ToString());
                            HandleDetail3.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                            HandleDetail3.SetAttribute("BRANCH_CODE", HfBranchCode.Value.Trim());
                            HandleDetail3.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail3.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                            HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                            HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;


                            //if (HfChargesCode.Value != "0")
                            //{
                            //    HandleDetail3.SetAttribute("CCODE", (HfChargesCode.Value));

                            //}
                            //else
                            //{
                            //    HandleDetail3.SetAttribute("CCODE", null);
                            //}

                            HandleDetail3.SetAttribute("CCODE", (HfChargesCode.Value.Trim()));

                            if (TxtRate.Text == string.Empty)
                            {
                                HandleDetail3.SetAttribute("PER", ("0"));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("PER", (TxtRate.Text));
                            }
                            if (TxtQuantity.Text == string.Empty)
                            {
                                HandleDetail3.SetAttribute("QTY", ("0"));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("QTY", (TxtQuantity.Text));
                            }
                            if (TxtChargesAmt.Text == string.Empty)
                            {
                                HandleDetail3.SetAttribute("AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("AMT", (TxtChargesAmt.Text));
                            }

                            if (HfGSTRate.Value == string.Empty)
                            {
                                HandleDetail3.SetAttribute("GST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("GST_RATE", (HfGSTRate.Value));
                            }

                            if (HfGSTAmount.Value == string.Empty)
                            {
                                HandleDetail3.SetAttribute("GST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("GST_AMT", (HfGSTAmount.Value));
                            }
                            if (TxtCGSTRate.Text == string.Empty)
                            {
                                HandleDetail3.SetAttribute("CGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("CGST_RATE", (TxtCGSTRate.Text));
                            }
                            if (TxtCGSTAmount.Text == string.Empty)
                            {
                                HandleDetail3.SetAttribute("CGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text));
                            }
                            if (TxtSGSTRate.Text == string.Empty)
                            {
                                HandleDetail3.SetAttribute("SGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("SGST_RATE", (TxtSGSTRate.Text));
                            }
                            if (TxtSGSTAmount.Text == string.Empty)
                            {
                                HandleDetail3.SetAttribute("SGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text));
                            }
                            if (TxtIGSTRate.Text == string.Empty)
                            {
                                HandleDetail3.SetAttribute("IGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("IGST_RATE", (TxtIGSTRate.Text));
                            }
                            if (TxtIGSTAmount.Text == string.Empty)
                            {
                                HandleDetail3.SetAttribute("IGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text));
                            }
                            if (TxtTotalAmount.Text == string.Empty)
                            {
                                HandleDetail3.SetAttribute("T_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("T_AMT", (TxtTotalAmount.Text));
                            }

                            root2.AppendChild(HandleDetail3);
                            QUO_CSRNO++;
                        }
                    }
                }
                #endregion


                string str = QUOTATION_MLogicLayer.UpdateQUOATATION_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml));

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "QUOTATION MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillQuotation_MGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "QUOTATION MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : QUOTATION MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }

                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvQuotation_M_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvQuotation_M.PageIndex = e.NewPageIndex;
            clear();
            FillQuotation_MGrid(Session["COMP_CODE"].ToString());
        }

        protected void GvQuotation_M_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                  //  clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    //GridViewRow row = GvQuotation_M.Rows[id];
                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataSet ds = QUOTATION_MLogicLayer.GetAllIDWiseQUOATATION_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable dtQt = ds.Tables[1];
                        DataTable dtQc = ds.Tables[2];
                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;
                            HfQuoteType.Value = dt.Rows[0]["QUO_TYPE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            TxtQuotationNo.Text = dt.Rows[0]["QUO_NO"].ToString();
                            TxtQuotationDate.Text = Convert.ToDateTime(dt.Rows[0]["QUO_DATE"].ToString()).ToString("dd-MM-yyyy");//dt.Rows[0]["QUO_DATE"].ToString();
                            FillDdlAccountName();
                            // DdlAccountName.SelectedValue = dt.Rows[0]["ACODE"].ToString();
                            FillDdlAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            FillDdlKindAttn();
                            DdlKindAttn.SelectedValue = dt.Rows[0]["KIND_ATTN"].ToString();
                            getContactPersonPhoneNo();
                            TxtConatctPhone.Text = dt.Rows[0]["KIND_ATTN_PHONE"].ToString();
                            getContactPersonEmail();
                            TxtContactEmail.Text = dt.Rows[0]["KIND_ATTN_EMAIL"].ToString();
                            TxtPartyRefNo.Text = dt.Rows[0]["PARTY_REFNO"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtPaymentTerms.Text = dt.Rows[0]["PAYMENT_TERMS"].ToString();
                            TxtPriceTerms.Text = dt.Rows[0]["PRICE_TERMS"].ToString();
                            TxtDeliveryTerms.Text = dt.Rows[0]["DELIVERY_TERMS"].ToString();
                            TxtValidityTerms.Text = dt.Rows[0]["VALIDITY_TERMS"].ToString();
                            TxtTransportationTerms.Text = dt.Rows[0]["TRANSPORT_TERMS"].ToString();
                            DdlPreparedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            DdlSalesType.SelectedValue = dt.Rows[0]["SALES_TYPE"].ToString();
                            DdlCSTtype.SelectedValue = dt.Rows[0]["CST_TYPE"].ToString();
                            DdlOrdConfirm.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString(); //Convert.ToDateTime(dt.Rows[0]["CONF_DATE"].ToString()).ToString("dd-MM-yyyy"); //
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            TxtSubject.Text = dt.Rows[0]["SUB1"].ToString();
                            TxtModelNo.Text = dt.Rows[0]["MODEL_NAME"].ToString();
                            TxtFor.Text = dt.Rows[0]["SUB2"].ToString();
                            TxtBrandName.Text = dt.Rows[0]["BRAND_NAME"].ToString();
                            TxtNote.Text = dt.Rows[0]["NOTE"].ToString();
                           

                            if (HfQuoteType.Value == "I")
                            {
                                if (dtQt.Rows.Count > 0)
                                {
                                    ViewState["CurrentTable"] = dtQt;
                                    GvQuotation_T.DataSource = dtQt;
                                    GvQuotation_T.DataBind();
                                    GvQuotation_T.Enabled = false;
                                    DivQuoteItem.Visible = true;
                                    DivQuoteAMC.Visible = false;
                                    BtnSearchPartyModel.Visible = true;
                                    BtnSearchModelDetails.Visible = true;


                                }
                            }
                            else
                            {
                                if (dtQt.Rows.Count > 0)
                                {
                                    ViewState["CurrentTable_TAMC"] = dtQt;
                                    GvQuotation_TAMC.DataSource = dtQt;
                                    GvQuotation_TAMC.DataBind();
                                    GvQuotation_TAMC.Enabled = false;
                                    DivQuoteAMC.Visible = true;
                                    DivQuoteItem.Visible = false;
                                    BtnSearchPartyModel.Visible = false;
                                    BtnSearchModelDetails.Visible = false;

                                }
                            }



                            if (dtQc.Rows.Count > 0)
                            {
                                ViewState["CurrentTable_C"] = dtQc;
                                GvQuotation_C.DataSource = dtQc;
                                GvQuotation_C.DataBind();
                                GvQuotation_C.Enabled = false;
                            }


                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            Session["QUO_TYPE"] = HfQuoteType.Value.Trim();

                        }
                    }
                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    Btncalldel.Visible = true;
                    BtncallUpd.Visible = false;
                    ControllerDisable();
                    GvQuotation_T.Enabled = false;
                    GvQuotation_C.Enabled = false;

                    #endregion
                }

                if (e.CommandName == "Edita")
                {
                    #region EDIT
              //      clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    //GridViewRow row = GvQuotation_M.Rows[id];
                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataSet ds = QUOTATION_MLogicLayer.GetAllIDWiseQUOATATION_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable dtQt = ds.Tables[1];
                        DataTable dtQc = ds.Tables[2];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfQuoteType.Value = dt.Rows[0]["QUO_TYPE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            TxtQuotationNo.Text = dt.Rows[0]["QUO_NO"].ToString();
                            TxtQuotationDate.Text = Convert.ToDateTime(dt.Rows[0]["QUO_DATE"].ToString()).ToString("dd-MM-yyyy");//dt.Rows[0]["QUO_DATE"].ToString();
                            FillDdlAccountName();
                            //  DdlAccountName.SelectedValue = dt.Rows[0]["ACODE"].ToString();
                            FillDdlAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            FillDdlKindAttn();
                            DdlKindAttn.SelectedValue = dt.Rows[0]["KIND_ATTN"].ToString();
                            getContactPersonPhoneNo();
                            TxtConatctPhone.Text = dt.Rows[0]["KIND_ATTN_PHONE"].ToString();
                            getContactPersonEmail();
                            TxtContactEmail.Text = dt.Rows[0]["KIND_ATTN_EMAIL"].ToString();
                            TxtPartyRefNo.Text = dt.Rows[0]["PARTY_REFNO"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtPaymentTerms.Text = dt.Rows[0]["PAYMENT_TERMS"].ToString();
                            TxtPriceTerms.Text = dt.Rows[0]["PRICE_TERMS"].ToString();
                            TxtDeliveryTerms.Text = dt.Rows[0]["DELIVERY_TERMS"].ToString();
                            TxtValidityTerms.Text = dt.Rows[0]["VALIDITY_TERMS"].ToString();
                            TxtTransportationTerms.Text = dt.Rows[0]["TRANSPORT_TERMS"].ToString();
                            DdlPreparedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            DdlSalesType.SelectedValue = dt.Rows[0]["SALES_TYPE"].ToString();
                            DdlCSTtype.SelectedValue = dt.Rows[0]["CST_TYPE"].ToString();
                            DdlOrdConfirm.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString(); //Convert.ToDateTime(dt.Rows[0]["CONF_DATE"].ToString()).ToString("dd-MM-yyyy"); //
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            TxtSubject.Text = dt.Rows[0]["SUB1"].ToString();
                            TxtModelNo.Text = dt.Rows[0]["MODEL_NAME"].ToString();
                            TxtFor.Text = dt.Rows[0]["SUB2"].ToString();
                            TxtBrandName.Text = dt.Rows[0]["BRAND_NAME"].ToString();
                            TxtNote.Text = dt.Rows[0]["NOTE"].ToString();
                            TxtQuotationDate.Enabled = false;

                            if (HfQuoteType.Value == "I")
                            {
                                if (dtQt.Rows.Count > 0)
                                {
                                    ViewState["CurrentTable"] = dtQt;
                                    GvQuotation_T.DataSource = dtQt;
                                    GvQuotation_T.DataBind();
                                    GvQuotation_T.Enabled = true;
                                    DivQuoteItem.Visible = true;
                                    DivQuoteAMC.Visible = false;
                                    BtnSearchPartyModel.Visible = true;
                                    BtnSearchModelDetails.Visible = true;
                                }
                            }
                            else
                            {
                                if (dtQt.Rows.Count > 0)
                                {
                                    ViewState["CurrentTable_TAMC"] = dtQt;
                                    GvQuotation_TAMC.DataSource = dtQt;
                                    GvQuotation_TAMC.DataBind();
                                    GvQuotation_TAMC.Enabled = true;
                                    DivQuoteAMC.Visible = true;
                                    DivQuoteItem.Visible = false;
                                    BtnSearchPartyModel.Visible = false;
                                    BtnSearchModelDetails.Visible = false;
                                }
                            }



                            if (dtQc.Rows.Count > 0)
                            {
                                ViewState["CurrentTable_C"] = dtQc;
                                GvQuotation_C.DataSource = dtQc;
                                GvQuotation_C.DataBind();
                                GvQuotation_C.Enabled = true;
                            }


                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            Session["QUO_TYPE"] = HfQuoteType.Value.Trim();

                            BtncallUpd.Text = "UPDATE";

                            #endregion
                        }
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
                    GvQuotation_T.Enabled = true;
                    GvQuotation_C.Enabled = true;
                }

                if (e.CommandName == "Viewa")
                {
                    #region SET TEXT ON VIEW
                //    clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    //GridViewRow row = GvQuotation_M.Rows[id];
                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataSet ds = QUOTATION_MLogicLayer.GetAllIDWiseQUOATATION_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable dtQt = ds.Tables[1];
                        DataTable dtQc = ds.Tables[2];
                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfQuoteType.Value = dt.Rows[0]["QUO_TYPE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            TxtQuotationNo.Text = dt.Rows[0]["QUO_NO"].ToString();
                            TxtQuotationDate.Text = Convert.ToDateTime(dt.Rows[0]["QUO_DATE"].ToString()).ToString("dd-MM-yyyy");//dt.Rows[0]["QUO_DATE"].ToString();
                            FillDdlAccountName();
                            //  DdlAccountName.SelectedValue = dt.Rows[0]["ACODE"].ToString();
                            FillDdlAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            FillDdlKindAttn();
                            DdlKindAttn.SelectedValue = dt.Rows[0]["KIND_ATTN"].ToString();
                            getContactPersonPhoneNo();
                            TxtConatctPhone.Text = dt.Rows[0]["KIND_ATTN_PHONE"].ToString();
                            getContactPersonEmail();
                            TxtContactEmail.Text = dt.Rows[0]["KIND_ATTN_EMAIL"].ToString();
                            TxtPartyRefNo.Text = dt.Rows[0]["PARTY_REFNO"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtPaymentTerms.Text = dt.Rows[0]["PAYMENT_TERMS"].ToString();
                            TxtPriceTerms.Text = dt.Rows[0]["PRICE_TERMS"].ToString();
                            TxtDeliveryTerms.Text = dt.Rows[0]["DELIVERY_TERMS"].ToString();
                            TxtValidityTerms.Text = dt.Rows[0]["VALIDITY_TERMS"].ToString();
                            TxtTransportationTerms.Text = dt.Rows[0]["TRANSPORT_TERMS"].ToString();
                            DdlPreparedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            DdlSalesType.SelectedValue = dt.Rows[0]["SALES_TYPE"].ToString();
                            DdlCSTtype.SelectedValue = dt.Rows[0]["CST_TYPE"].ToString();
                            DdlOrdConfirm.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();// Convert.ToDateTime(dt.Rows[0]["CONF_DATE"].ToString()).ToString("dd-MM-yyyy"); //
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            TxtSubject.Text = dt.Rows[0]["SUB1"].ToString();
                            TxtModelNo.Text = dt.Rows[0]["MODEL_NAME"].ToString();
                            TxtFor.Text = dt.Rows[0]["SUB2"].ToString();
                            TxtBrandName.Text = dt.Rows[0]["BRAND_NAME"].ToString();
                            TxtNote.Text = dt.Rows[0]["NOTE"].ToString();

                            if (HfQuoteType.Value == "I")
                            {
                                if (dtQt.Rows.Count > 0)
                                {
                                    GvQuotation_T.DataSource = dtQt;
                                    GvQuotation_T.DataBind();
                                    GvQuotation_T.Enabled = false;
                                    DivQuoteItem.Visible = true;
                                    DivQuoteAMC.Visible = false;
                                    BtnSearchPartyModel.Visible = true;
                                    BtnSearchModelDetails.Visible = true;
                                }
                            }
                            if (HfQuoteType.Value == "A")
                            {
                                if (dtQt.Rows.Count > 0)
                                {

                                    GvQuotation_TAMC.DataSource = dtQt;
                                    GvQuotation_TAMC.DataBind();
                                    GvQuotation_TAMC.Enabled = false;
                                    DivQuoteAMC.Visible = true;
                                    DivQuoteItem.Visible = false;
                                    BtnSearchPartyModel.Visible = false;
                                    BtnSearchModelDetails.Visible = false;
                                }
                            }



                            if (dtQc.Rows.Count > 0)
                            {
                                ViewState["CurrentTable_C"] = dtQc;
                                GvQuotation_C.DataSource = dtQc;
                                GvQuotation_C.DataBind();
                                GvQuotation_C.Enabled = false;
                            }

                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            Session["QUO_TYPE"] = HfQuoteType.Value.Trim();

                        }
                    }
                    #endregion
                    ControllerDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    UserRights();
                    GvQuotation_T.Enabled = false;
                    GvQuotation_C.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                lblmsg.Text = ex.Message.ToString();
            }
        }

        protected void GvQuotation_M_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label lblQuotationDate = (e.Row.FindControl("lblQuotationDate") as Label);
                    Label lblDueDays = (e.Row.FindControl("lblDueDays") as Label);

                    Button btnedit = (e.Row.FindControl("btnEdit") as Button);
                    Button btndelete = (e.Row.FindControl("btnDelete") as Button);
                    Label lblchk = (e.Row.FindControl("lblOrderConfirm") as Label);

                    HiddenField hfREC_UPD = (e.Row.FindControl("hfREC_UPD") as HiddenField);
                    HiddenField hfREC_DEL = (e.Row.FindControl("hfREC_DEL") as HiddenField);
                    HiddenField hfREC_INS = (e.Row.FindControl("hfREC_INS") as HiddenField);

                    DateTime CurrDate = System.DateTime.Now;

                    decimal diff2 = Convert.ToDecimal((CurrDate - Convert.ToDateTime(lblQuotationDate.Text.ToString())).TotalDays.ToString());
                    lblDueDays.Text = Convert.ToInt32(diff2 - 1).ToString();


                    if (hfREC_INS.Value.ToString() == "Y")
                    {
                        BtnAdd.Enabled = true;
                    }
                    else
                    {
                        BtnAdd.Enabled = false;
                    }

                    if (hfREC_UPD.Value.ToString() == "Y")
                    {


                        if (lblchk.Text == "YES")
                        {
                            if (Session["USERTYPE"].ToString() == "A")
                            {
                                btnedit.Enabled = true;

                            }
                            else
                            {
                                btnedit.Enabled = false;

                            }
                        }
                    }

                    if (hfREC_DEL.Value.ToString() == "Y")
                    {


                        if (lblchk.Text == "YES")
                        {
                            if (Session["USERTYPE"].ToString() == "A")
                            {

                                btndelete.Enabled = true;
                            }
                            else
                            {

                                btndelete.Enabled = false;
                            }
                        }
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
                    #region INSERT QUOTATION_M

                    QUOTATION_MLogicLayer insert = new QUOTATION_MLogicLayer();
                    //insert.TRAN_DATE = HfTranDate.Value.Trim();
                    //insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();

                    if (TxtQuotationNo.Text == string.Empty)
                    {
                        insert.QUO_NO = "0";
                    }
                    else
                    {
                        insert.QUO_NO = TxtQuotationNo.Text.Trim();
                    }
                    insert.QUO_DATE = Convert.ToDateTime(TxtQuotationDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    insert.PARTY_NAME = TxtAccountName.Text.Trim().ToUpper();
                    insert.PARTY_ADD1 = "";
                    insert.ENGINE_TYPE = "";
                    insert.VEHICLE_NO = "";
                    insert.GROSS_AMT = "0";
                    insert.CHARGES_AMT = "0";
                    if (TxtROamt.Text == string.Empty)
                    {
                        insert.RO_AMT = "0";
                    }
                    else
                    {
                        insert.RO_AMT = TxtROamt.Text.Trim();
                    }
                    insert.DISC_PER = "0";
                    insert.DISC_AMT = "0";

                    if (TxtNetAmt.Text == string.Empty)
                    {
                        insert.NET_AMT = "0";
                    }
                    else
                    {
                        insert.NET_AMT = TxtNetAmt.Text.Trim();
                    }
                    insert.ENDT = "";
                    insert.PRICE_TERMS = TxtPriceTerms.Text.Trim().ToUpper();
                    insert.PAYMENT_TERMS = TxtPaymentTerms.Text.Trim().ToUpper();
                    insert.DELIVERY_TERMS = TxtDeliveryTerms.Text.Trim().ToUpper();
                    insert.VALIDITY_TERMS = TxtValidityTerms.Text.Trim().ToUpper();
                    insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                    insert.KIND_ATTN = DdlKindAttn.SelectedItem.Text.Trim().ToUpper();
                    insert.TRANSPORT_TERMS = TxtTransportationTerms.Text.Trim().ToUpper();
                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                    insert.BCODE = DdlPreparedBy.SelectedValue.Trim();
                    insert.SALES_TYPE = DdlSalesType.SelectedValue.Trim().ToUpper();
                    insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToUpper();
                    insert.CST_TYPE = DdlCSTtype.SelectedValue.Trim().ToUpper();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";
                    insert.CONF_FLAG = DdlOrdConfirm.SelectedValue.Trim().ToUpper();
                    if (DdlOrdConfirm.SelectedValue == "Y")
                    {
                        insert.CONF_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CONF_DATE = "";
                    }

                    if (DdlOrdConfirm.SelectedValue == "Y")
                    {
                        insert.CONF_USERID = TxtConfirmBy.Text.Trim().ToUpper();
                    }
                    else
                    {
                        insert.CONF_USERID = "";
                    }

                    insert.PARTY_ADD2 = "";
                    insert.PARTY_ADD3 = "";
                    insert.PARTY_VAT = "";
                    insert.PARTY_CST = "";
                    insert.PARTY_PHONE = "";
                    insert.ACODE = HfACODE.Value.Trim();
                    insert.ATYPE = "";
                    insert.PARTY_REFNO = TxtPartyRefNo.Text.Trim().ToUpper();
                    insert.BRAND_NAME = TxtBrandName.Text.Trim().ToUpper();
                    insert.MODEL_NAME = TxtModelNo.Text.Trim().ToUpper();
                    insert.SUB1 = TxtSubject.Text.Trim().ToUpper();
                    insert.SUB2 = TxtFor.Text.Trim().ToUpper();
                    insert.SUB3 = "";
                    insert.SUB4 = "";
                    insert.NOTE = TxtNote.Text.Trim().ToUpper();
                    insert.QUO_TYPE = HfQuoteType.Value;
                    insert.KIND_ATTN_PHONE = TxtConatctPhone.Text.Trim().ToUpper();
                    insert.KIND_ATTN_EMAIL = TxtContactEmail.Text.Trim().ToUpper();
                    insert.STATUS = "";
                    insert.REF_BY = "";
                    insert.REF_TRAN_DATE = "";
                    insert.REF_TRAN_NO = "0";
                    insert.GST_RATE = "0";
                    insert.GST_AMT = "0";
                    insert.CGST_RATE = "0";
                    insert.CGST_AMT = "0";
                    insert.SGST_RATE = "0";
                    insert.SGST_AMT = "0";
                    insert.IGST_RATE = "0";
                    insert.IGST_AMT = "0";
                    #endregion

                    decimal total_amt_T = 0;
                    decimal total_amt_C = 0;
                    decimal total_amt = 0;




                    #region INSERT QUOTATION_T FOR ITEM


                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int QUO_TSRNO = 1;

                    if (HfQuoteType.Value == "I")
                    {

                        foreach (GridViewRow row in GvQuotation_T.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {

                                HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                                TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                                TextBox TxtQuantity = row.FindControl("TxtQuantity") as TextBox;
                                TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                                TextBox TxtDisRate = row.FindControl("TxtDisRate") as TextBox;
                                TextBox TxtAddDisRate = row.FindControl("TxtAddDisRate") as TextBox;
                                TextBox TxtAmount = row.FindControl("TxtAmount") as TextBox;
                                TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                                TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                                TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                                TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                                TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                                TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                                TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;

                                HiddenField HfAmount = row.FindControl("HfAmount") as HiddenField;
                                HiddenField HfDisAmount = row.FindControl("HfDisAmount") as HiddenField;
                                HiddenField HfAddDisAmount = row.FindControl("HfAddDisAmount") as HiddenField;
                                HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                                HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;

                                if (HfDetailSCode.Value != "0")
                                {

                                    XmlElement HandleDetail2 = XDoc1.CreateElement("Quotation_T");
                                    HandleDetail2.SetAttribute("SRNO", QUO_TSRNO.ToString());
                                    HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                    //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                    //HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());


                                    if (HfDetailSCode.Value == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("SCODE", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value));
                                    }

                                    if (TxtQuantity.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("QTY", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("QTY", (TxtQuantity.Text));
                                    }
                                    if (TxtRate.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("RATE", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("RATE", (TxtRate.Text));
                                    }

                                    if (HfAmount.Value == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("AMT", (HfAmount.Value));
                                    }
                                    if (TxtDisRate.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("DISC_PER", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("DISC_PER", (TxtDisRate.Text));
                                    }

                                    if (HfDisAmount.Value == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("DISC_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("DISC_AMT", (HfDisAmount.Value));
                                    }
                                    if (TxtAddDisRate.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("ADD_DISC_PER", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("ADD_DISC_PER", (TxtAddDisRate.Text));
                                    }

                                    if (HfAddDisAmount.Value == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("ADD_DISC_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("ADD_DISC_AMT", (HfAddDisAmount.Value));
                                    }

                                    if (HfGSTRate.Value == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("GST_RATE", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("GST_RATE", (HfGSTRate.Value));
                                    }

                                    if (HfGSTAmount.Value == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("GST_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("GST_AMT", (HfGSTAmount.Value));
                                    }

                                    if (TxtAmount.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("G_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("G_AMT", (TxtAmount.Text));
                                    }

                                    if (TxtCGSTRate.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("CGST_RATE", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("CGST_RATE", (TxtCGSTRate.Text));
                                    }
                                    if (TxtCGSTAmount.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("CGST_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text));
                                    }
                                    if (TxtSGSTRate.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("SGST_RATE", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("SGST_RATE", (TxtSGSTRate.Text));
                                    }
                                    if (TxtSGSTAmount.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("SGST_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text));
                                    }
                                    if (TxtIGSTRate.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("IGST_RATE", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("IGST_RATE", (TxtIGSTRate.Text));
                                    }
                                    if (TxtIGSTAmount.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("IGST_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text));
                                    }
                                    if (TxtTotalAmount.Text == string.Empty)
                                    {
                                        HandleDetail2.SetAttribute("T_AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail2.SetAttribute("T_AMT", (TxtTotalAmount.Text));
                                        total_amt_T = Convert.ToDecimal(TxtTotalAmount.Text.Trim());
                                    }

                                    root1.AppendChild(HandleDetail2);
                                    QUO_TSRNO++;
                                    
                                }
                            }
                        }
                    }

                    else
                    {
                        #region INSERT QUOATION_T FOR AMC

                        foreach (GridViewRow row in GvQuotation_TAMC.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {
                                TextBox TxtBrandName = row.FindControl("TxtBrandName") as TextBox;
                                HiddenField HfBrandCodeGrid = row.FindControl("HfBrandCodeGrid") as HiddenField;
                                TextBox TxtModelName = row.FindControl("TxtModelName") as TextBox;
                                HiddenField HfModelCodeGrid = row.FindControl("HfModelCodeGrid") as HiddenField;
                                //DropDownList DdlBrandName = row.FindControl("DdlBrandName") as DropDownList;
                                //DropDownList DdlModelName = row.FindControl("DdlModelName") as DropDownList;
                                TextBox TxtModelDescription = row.FindControl("TxtModelDescription") as TextBox;
                                TextBox TxtQuantity = row.FindControl("TxtQuantity") as TextBox;
                                TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                                TextBox TxtDisRate = row.FindControl("TxtDisRate") as TextBox;
                                TextBox TxtAddDisRate = row.FindControl("TxtAddDisRate") as TextBox;
                                TextBox TxtAmount = row.FindControl("TxtAmount") as TextBox;
                                TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                                TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                                TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                                TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                                TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                                TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                                TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;

                                HiddenField HfAmount = row.FindControl("HfAmount") as HiddenField;
                                HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                                HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;

                                XmlElement HandleDetail2 = XDoc1.CreateElement("Quotation_T");
                                HandleDetail2.SetAttribute("SRNO", QUO_TSRNO.ToString());
                                HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                HandleDetail2.SetAttribute("BRAND_CODE", (HfBrandCodeGrid.Value.Trim()));
                                HandleDetail2.SetAttribute("MODEL_CODE", (HfModelCodeGrid.Value.Trim()));
                                if (TxtQuantity.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("QTY", (TxtQuantity.Text));
                                }
                                if (TxtRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("RATE", (TxtRate.Text));
                                }
                                if (TxtAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("AMT", (TxtAmount.Text));
                                }

                                if (TxtDisRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DISC_PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("DISC_PER", (TxtDisRate.Text));
                                }

                                if (TxtAddDisRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("ADD_DISC_PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("ADD_DISC_PER", (TxtAddDisRate.Text));
                                }
                                if (TxtAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("G_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("G_AMT", (TxtAmount.Text));
                                }

                                if (HfGSTRate.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("GST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("GST_RATE", (HfGSTRate.Value));
                                }

                                if (HfGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("GST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("GST_AMT", (HfGSTAmount.Value));
                                }
                                if (TxtCGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CGST_RATE", (TxtCGSTRate.Text));
                                }
                                if (TxtCGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text));
                                }
                                if (TxtSGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SGST_RATE", (TxtSGSTRate.Text));
                                }
                                if (TxtSGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text));
                                }
                                if (TxtIGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("IGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("IGST_RATE", (TxtIGSTRate.Text));
                                }
                                if (TxtIGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("IGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text));
                                }
                                if (TxtTotalAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("T_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("T_AMT", (TxtTotalAmount.Text));
                                    total_amt_T = Convert.ToDecimal(TxtTotalAmount.Text.Trim());
                                }

                                root1.AppendChild(HandleDetail2);
                                QUO_TSRNO++;
                            }
                        }

                        #endregion
                    }
                    #endregion

                    #region INSERT QUOTATION_C

                    XmlDocument XDoc2 = new XmlDocument();
                    XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                    XDoc2.AppendChild(dec2);// Create the root element
                    XmlElement root2 = XDoc2.CreateElement("root");
                    XDoc2.AppendChild(root2);
                    int QUO_CSRNO = 1;

                    foreach (GridViewRow row in GvQuotation_C.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {


                            HiddenField HfChargesCode = row.FindControl("HfChargesCode") as HiddenField;
                            //DropDownList DdlChargesName = row.FindControl("DdlChargesName") as DropDownList;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtQuantity = row.FindControl("TxtQuantity") as TextBox;
                            TextBox TxtChargesAmt = row.FindControl("TxtChargesAmt") as TextBox;
                            TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                            TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                            TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                            TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                            TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                            TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                            TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;

                            if (HfChargesCode.Value != "0" && HfChargesCode.Value != "")
                            {

                                XmlElement HandleDetail3 = XDoc2.CreateElement("Quotation_C");
                                HandleDetail3.SetAttribute("SR", QUO_CSRNO.ToString());
                                HandleDetail3.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail3.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail3.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                                HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;

                                
                                HandleDetail3.SetAttribute("CCODE", (HfChargesCode.Value.Trim()));
                                if (TxtRate.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("PER", (TxtRate.Text));
                                }

                                if (TxtQuantity.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("QTY", (TxtQuantity.Text));
                                }
                                if (TxtChargesAmt.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("AMT", (TxtChargesAmt.Text));
                                }

                                if (HfGSTRate.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("GST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("GST_RATE", (HfGSTRate.Value));
                                }

                                if (HfGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("GST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("GST_AMT", (HfGSTAmount.Value));
                                }
                                if (TxtCGSTRate.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("CGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("CGST_RATE", (TxtCGSTRate.Text));
                                }
                                if (TxtCGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("CGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text));
                                }
                                if (TxtSGSTRate.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("SGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("SGST_RATE", (TxtSGSTRate.Text));
                                }
                                if (TxtSGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("SGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text));
                                }
                                if (TxtIGSTRate.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("IGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("IGST_RATE", (TxtIGSTRate.Text));
                                }
                                if (TxtIGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("IGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text));
                                }
                                if (TxtTotalAmount.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("T_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("T_AMT", (TxtTotalAmount.Text));
                                    total_amt_C = Convert.ToDecimal(TxtTotalAmount.Text.Trim());
                                }

                                root2.AppendChild(HandleDetail3);
                                QUO_CSRNO++;
                            }

                        }
                    }
                    #endregion

                    //total_amt = total_amt_T + total_amt_C;

                    
                    string str = QUOTATION_MLogicLayer.InsertQUOATATION_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"));

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "QUOTATION MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillQuotation_MGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "QUOTATION MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : QUOTATION MASTER NOT SAVED";
                        lblmsg.ForeColor = Color.Red;

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
                //  string TranDate = HfTranDate.Value;
                if (HfTranNo.Value != string.Empty && HfTranDate.Value != string.Empty)
                {
                    string str = QUOTATION_MLogicLayer.DeleteQUOATATION_MASDetailsByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value.ToString()));
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
                        lblmsg.Text = "Error:Quotation Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillQuotation_MGrid(Session["COMP_CODE"].ToString());
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnNewAMC_Click(object sender, EventArgs e)
        {
            clear();
            ControllerEnable();
            UserRights();
            Btncalldel.Visible = false;
            btnSave.Enabled = true;
            btnSave.Visible = true;
            DivEntry.Visible = true;
            DivView.Visible = false;
            TxtSubject.Text = "QUOTATION FOR ANNUAL MAINTENANCE CONTRACT OF YOUR AIR COMPRESSOR.";
            //  getQuo_Sub1bByCompany();
            // getQuo_Sub2bByCompany();
            //getQuo_BrandNameByCompany();
            //getQuo_ModelNameByCompany();
            getQuo_NoteByCompany();
            dvcompanyFor.Visible = false;
            dvBrandName.Visible = false;
            dvModelName.Visible = false;
            TxtQuotationDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            TxtPaymentTerms.Text = "BY CHEQUE ON DELIVERY";
            TxtPriceTerms.Text = "EXCLUDING OF GUJARAT TAX";
            TxtDeliveryTerms.Text = "3-4 DAYS";
            TxtValidityTerms.Text = "30 DAYS";
            TxtTransportationTerms.Text = "EXTRA CHARGES";
            HfQuoteType.Value = "A";
            BtnSearchModelDetails.Visible = false;
            BtnSearchPartyModel.Visible = false;
            GvQuotation_TAMC.Enabled = true;
            GvQuotation_C.Enabled = true;

            string QuotationNo = QUOTATION_MLogicLayer.GetQuoNoQUOATATION_MASDetailCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtQuotationDate.Text.Trim()).ToString("yyyy-MM-dd"));
            if (QuotationNo.Length <= 8)
            {
                TxtQuotationNo.Text = QuotationNo;
            }
            else
            {
                TxtQuotationNo.Text = string.Empty;
            }


            DivQuoteItem.Visible = false;
            DivQuoteAMC.Visible = true;


        }

        protected void GvQuotation_TAMC_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvQuotation_TAMC.PageIndex = e.NewPageIndex;
            clear();
            FillQuotation_TAMCGrid();
        }


        protected void GvQuotation_TAMC_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    TextBox TxtBrandName = (e.Row.FindControl("TxtBrandName") as TextBox);
                    TextBox TxtModelName = (e.Row.FindControl("TxtModelName") as TextBox);
                    DropDownList DdlBrandName = (e.Row.FindControl("DdlBrandName") as DropDownList);
                    DropDownList DdlModelName = (DropDownList)e.Row.FindControl("DdlModelName");
                    HiddenField HfBrandCodeGrid = (e.Row.FindControl("HfBrandCodeGrid") as HiddenField);
                    HiddenField HfModelCodeGrid = (e.Row.FindControl("HfModelCodeGrid") as HiddenField);
                    TextBox TxtModelDescription = (TextBox)e.Row.FindControl("TxtModelDescription");


                    DataTable DtBrandName = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();

                    DtBrandName = STOCK_BRANDMASLogicLayer.GetSTOCKBRANDMAS_BrandNameCompanyWiseFor_Ddl(Comp_Code);

                    if (HfBrandCodeGrid.Value != "0" && HfBrandCodeGrid.Value != string.Empty)
                    {
                        DataView Dv = new DataView(DtBrandName);
                        Dv.RowFilter = "BRAND_CODE=" + HfBrandCodeGrid.Value;
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            TxtBrandName.Text = DtView.Rows[0]["BRAND_NAME"].ToString();

                            if (HfBrandCodeGrid.Value != string.Empty)
                            {

                                DataTable dtModelName = STOCK_MODELMASLogicLayer.GetSTOCK_MODELMAS_ModelNameBrandWiseFor_Ddl(HfBrandCodeGrid.Value);


                                if (HfModelCodeGrid.Value != "0" && HfModelCodeGrid.Value != string.Empty)
                                {
                                    DataView DvModel = new DataView(dtModelName);
                                    DvModel.RowFilter = "MODEL_CODE=" + HfModelCodeGrid.Value;
                                    DataTable DtViewModel = DvModel.ToTable();
                                    if (DtViewModel.Rows.Count > 0)
                                    {
                                        TxtModelName.Text = DtViewModel.Rows[0]["MODEL_NAME"].ToString();
                                    }
                                }


                                if (HfModelCodeGrid.Value != string.Empty)
                                {
                                    DataView DvModel = new DataView(dtModelName);
                                    DvModel.RowFilter = "MODEL_CODE=" + HfModelCodeGrid.Value;
                                    DataTable DtViewModel = DvModel.ToTable();
                                    TxtModelDescription.Text = DtViewModel.Rows[0]["MODEL_DESC"].ToString();
                                }
                            }

                        }
                        else
                        {
                            TxtBrandName.Text = string.Empty;

                        }
                    }

                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {

                    Label lblSumTotalAMCQty = (Label)e.Row.FindControl("lblSumTotalAMCQty");
                    Label lblSumTotalAMC_AMT = (Label)e.Row.FindControl("lblSumTotalAMC_AMT");
                    Label lblSumAMCTotalCGST_AMT = (Label)e.Row.FindControl("lblSumAMCTotalCGST_AMT");
                    Label lblSumAMCTotalSGST_AMT = (Label)e.Row.FindControl("lblSumAMCTotalSGST_AMT");
                    Label lblSumAMCTotalIGST_AMT = (Label)e.Row.FindControl("lblSumAMCTotalIGST_AMT");
                    Label lblSumTotalAMCAmount = (Label)e.Row.FindControl("lblSumTotalAMCAmount");


                    double lblTotalQty = TotalQuantity_AMC();
                    lblSumTotalAMCQty.Text = lblTotalQty.ToString();

                    double lblTotGamount = TotalGrossAmount_AMC();
                    lblSumTotalAMC_AMT.Text = lblTotGamount.ToString();

                    double lblTotCGSTAmt = TotalCGSTAmount_AMC();
                    lblSumAMCTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                    double lblTotSGSTAmt = TotalSGSTAmount_AMC();
                    lblSumAMCTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                    double lblTotIGSTAmt = TotalIGSTAmount_AMC();
                    lblSumAMCTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                    double lblTotAmount = TotalAmount_AMC();
                    lblSumTotalAMCAmount.Text = lblTotAmount.ToString();


                    if (lblSumTotalAMCAmount.Text == string.Empty)
                    {
                        lblSumTotalAMCAmount.Text = "0";
                        HfGrid_TAMC_Total.Value = "0";
                    }
                    else
                    {
                        ViewState["Total_Quotation_TAMC"] = lblSumTotalAMCAmount.Text.Trim();
                       //   decimal Grid_TAMC_Total = Convert.ToDecimal(lblSumTotalAMCAmount.Text.Trim());
                    }



                    FillNetAmount();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void DdlModelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DropDownList ddl = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl.Parent.Parent;
                int idx = row.RowIndex;

                DropDownList DdlModelName = (DropDownList)row.Cells[3].FindControl("DdlModelName");
                TextBox TxtModelDescription = (TextBox)row.Cells[4].FindControl("TxtModelDescription");


                //DataTable dt = new DataTable();
                //string Model_Code = DdlModelName.SelectedValue;
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select MODEL_DESC from STOCK_MODELMAS where MODEL_CODE = '" + DdlModelName.SelectedValue + "'", con);
                TxtModelDescription.Text = cmd.ExecuteScalar().ToString();
                con.Close();
                TxtModelDescription.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }

        }

        #region ADD NEW ROW IN GRID QUOTTATION_TAMC

        private void ClearQuotation_TAMCGrid()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("BRAND_CODE", typeof(string));
            table.Columns.Add("MODEL_CODE", typeof(string));
            table.Columns.Add("MODEL_DESC", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("RATE", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("DISC_PER", typeof(string));
            table.Columns.Add("ADD_DISC_PER", typeof(string));
            table.Columns.Add("G_AMT", typeof(string));
            table.Columns.Add("GST_RATE", typeof(string));
            table.Columns.Add("GST_AMT", typeof(string));
            table.Columns.Add("CGST_RATE", typeof(string));
            table.Columns.Add("CGST_AMT", typeof(string));
            table.Columns.Add("SGST_RATE", typeof(string));
            table.Columns.Add("SGST_AMT", typeof(string));
            table.Columns.Add("IGST_RATE", typeof(string));
            table.Columns.Add("IGST_AMT", typeof(string));
            table.Columns.Add("T_AMT", typeof(string));
            //table.Columns.Add("ADD_DISFLAG", typeof(string));


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["BRAND_CODE"] = string.Empty;
            dr["MODEL_CODE"] = string.Empty;
            dr["MODEL_DESC"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["RATE"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["DISC_PER"] = string.Empty;
            dr["ADD_DISC_PER"] = string.Empty;
            dr["G_AMT"] = string.Empty;
            dr["GST_RATE"] = string.Empty;
            dr["GST_AMT"] = string.Empty;
            dr["CGST_RATE"] = string.Empty;
            dr["CGST_AMT"] = string.Empty;
            dr["SGST_RATE"] = string.Empty;
            dr["SGST_AMT"] = string.Empty;
            dr["IGST_RATE"] = string.Empty;
            dr["IGST_AMT"] = string.Empty;
            dr["T_AMT"] = string.Empty;
            //dr["ADD_DISFLAG"] = string.Empty;

            table.Rows.Add(dr);

            ViewState["CurrentTable_TAMC"] = table;

            GvQuotation_TAMC.DataSource = table;
            GvQuotation_TAMC.DataBind();
        }

        private void SetInitialRow3()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("BRAND_CODE", typeof(string));
            table.Columns.Add("MODEL_CODE", typeof(string));
            table.Columns.Add("MODEL_DESC", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("RATE", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("DISC_PER", typeof(string));
            table.Columns.Add("ADD_DISC_PER", typeof(string));
            table.Columns.Add("G_AMT", typeof(string));
            table.Columns.Add("GST_RATE", typeof(string));
            table.Columns.Add("GST_AMT", typeof(string));
            table.Columns.Add("CGST_RATE", typeof(string));
            table.Columns.Add("CGST_AMT", typeof(string));
            table.Columns.Add("SGST_RATE", typeof(string));
            table.Columns.Add("SGST_AMT", typeof(string));
            table.Columns.Add("IGST_RATE", typeof(string));
            table.Columns.Add("IGST_AMT", typeof(string));
            table.Columns.Add("T_AMT", typeof(string));
            //table.Columns.Add("ADD_DISFLAG", typeof(string));


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["BRAND_CODE"] = string.Empty;
            dr["MODEL_CODE"] = string.Empty;
            dr["MODEL_DESC"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["RATE"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["DISC_PER"] = string.Empty;
            dr["ADD_DISC_PER"] = string.Empty;
            dr["G_AMT"] = string.Empty;
            dr["GST_RATE"] = string.Empty;
            dr["GST_AMT"] = string.Empty;
            dr["CGST_RATE"] = string.Empty;
            dr["CGST_AMT"] = string.Empty;
            dr["SGST_RATE"] = string.Empty;
            dr["SGST_AMT"] = string.Empty;
            dr["IGST_RATE"] = string.Empty;
            dr["IGST_AMT"] = string.Empty;
            dr["T_AMT"] = string.Empty;
            //dr["ADD_DISFLAG"] = string.Empty;

            table.Rows.Add(dr);

            ViewState["CurrentTable_TAMC"] = table;

            GvQuotation_TAMC.DataSource = table;
            GvQuotation_TAMC.DataBind();
        }

        private void AddNewRowToGrid3()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable_TAMC"] != null)
            {
                DataTable dtCurrentTableAMC = (DataTable)ViewState["CurrentTable_TAMC"];
                DataRow drCurrentRow = null;
                if (dtCurrentTableAMC.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTableAMC.Rows.Count; i++)
                    {
                        //if(dtCurrentTableAMC != null)
                        //{



                        //extract the TextBox values 
                        //TextBox TxtSrNo = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[1].FindControl("TxtSrNo");
                        Label lblSumTotalAMCQty = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMCQty"));
                        Label lblSumTotalAMC_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMC_AMT"));
                        Label lblSumAMCTotalCGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalCGST_AMT"));
                        Label lblSumAMCTotalSGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalSGST_AMT"));
                        Label lblSumAMCTotalIGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalIGST_AMT"));
                        Label lblSumTotalAMCAmount = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMCAmount"));

                        HiddenField HfBrandCodeGrid = (HiddenField)GvQuotation_TAMC.Rows[rowIndex].Cells[0].FindControl("HfBrandCodeGrid");
                        TextBox TxtBrandName = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[1].FindControl("TxtBrandName");
                        HiddenField HfModelCodeGrid = (HiddenField)GvQuotation_TAMC.Rows[rowIndex].Cells[0].FindControl("HfModelCodeGrid");
                        TextBox TxtModelName = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[1].FindControl("TxtModelName");
                        DropDownList DdlBrandName = (DropDownList)GvQuotation_TAMC.Rows[rowIndex].Cells[2].FindControl("DdlBrandName");
                        DropDownList DdlModelName = (DropDownList)GvQuotation_TAMC.Rows[rowIndex].Cells[3].FindControl("DdlModelName");
                        TextBox TxtModelDescription = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[4].FindControl("TxtModelDescription");
                        TextBox TxtQuantity = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[5].FindControl("TxtQuantity");
                        TextBox TxtRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[6].FindControl("TxtRate");
                        TextBox TxtDisRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[7].FindControl("TxtDisRate");
                        TextBox TxtAddDisRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[8].FindControl("TxtAddDisRate");
                        TextBox TxtAmount = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[9].FindControl("TxtAmount");
                        TextBox TxtCGSTRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[10].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[11].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[12].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[13].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[14].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[15].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[16].FindControl("TxtTotalAmount");

                        HiddenField HfAmount = (HiddenField)GvQuotation_TAMC.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        HiddenField HfGSTRate = (HiddenField)GvQuotation_TAMC.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                        HiddenField HfGSTAmount = (HiddenField)GvQuotation_TAMC.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");

                        //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();

                        dtCurrentTableAMC.Rows[i - 1]["BRAND_CODE"] = HfBrandCodeGrid.Value.Trim();
                        dtCurrentTableAMC.Rows[i - 1]["MODEL_CODE"] = HfModelCodeGrid.Value.Trim();
                        dtCurrentTableAMC.Rows[i - 1]["QTY"] = TxtQuantity.Text.Trim();
                        dtCurrentTableAMC.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                        dtCurrentTableAMC.Rows[i - 1]["AMT"] = TxtAmount.Text.Trim();//HfAmount.Value.Trim();
                        //dtCurrentTableAMC.Rows[i - 1]["DISC_PER"] = TxtDisRate.Text.Trim();
                        //dtCurrentTableAMC.Rows[i - 1]["ADD_DISC_PER"] = TxtAddDisRate.Text.Trim(); 
                        dtCurrentTableAMC.Rows[i - 1]["G_AMT"] = HfAmount.Value.Trim();
                        dtCurrentTableAMC.Rows[i - 1]["GST_RATE"] = HfGSTRate.Value.Trim();
                        dtCurrentTableAMC.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                        dtCurrentTableAMC.Rows[i - 1]["CGST_RATE"] = TxtCGSTRate.Text.Trim();
                        dtCurrentTableAMC.Rows[i - 1]["CGST_AMT"] = TxtCGSTAmount.Text.Trim();
                        dtCurrentTableAMC.Rows[i - 1]["SGST_RATE"] = TxtSGSTRate.Text.Trim();
                        dtCurrentTableAMC.Rows[i - 1]["SGST_AMT"] = TxtSGSTAmount.Text.Trim();
                        dtCurrentTableAMC.Rows[i - 1]["IGST_RATE"] = TxtIGSTRate.Text.Trim();
                        dtCurrentTableAMC.Rows[i - 1]["IGST_AMT"] = TxtIGSTAmount.Text.Trim();
                        dtCurrentTableAMC.Rows[i - 1]["T_AMT"] = TxtTotalAmount.Text.Trim();


                        rowIndex++;

                        double lblTotalQty = TotalQuantity_AMC();
                        lblSumTotalAMCQty.Text = lblTotalQty.ToString();

                        double lblTotGamount = TotalGrossAmount_AMC();
                        lblSumTotalAMC_AMT.Text = lblTotGamount.ToString();

                        double lblTotCGSTAmt = TotalCGSTAmount_AMC();
                        lblSumAMCTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                        double lblTotSGSTAmt = TotalSGSTAmount_AMC();
                        lblSumAMCTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                        double lblTotIGSTAmt = TotalIGSTAmount_AMC();
                        lblSumAMCTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                        double lblTotAmount = TotalAmount_AMC();
                        lblSumTotalAMCAmount.Text = lblTotAmount.ToString();

                        if (lblSumTotalAMCAmount.Text == string.Empty)
                        {
                            lblSumTotalAMCAmount.Text = "0";
                            HfGrid_T_Total.Value = "0";
                        }
                        else
                        {
                            ViewState["Total_Quotation_TAMC"] = lblSumTotalAMCAmount.Text.Trim();
                        }

                        FillNetAmount();
                        //}
                        //   break;
                    }


                    drCurrentRow = dtCurrentTableAMC.NewRow();
                    //       drCurrentRow["SRNO"] = "";
                    drCurrentRow["BRAND_CODE"] = "0";
                    drCurrentRow["MODEL_CODE"] = "0";
                    //drCurrentRow["MODEL_DESC"] = "";
                    drCurrentRow["QTY"] = "0";
                    drCurrentRow["RATE"] = "0";
                    drCurrentRow["AMT"] = "0";
                    //drCurrentRow["DISC_PER"] = "";
                    //drCurrentRow["ADD_DISC_PER"] = "";
                    drCurrentRow["G_AMT"] = "0";
                    drCurrentRow["GST_RATE"] = "0";
                    drCurrentRow["GST_AMT"] = "0";
                    drCurrentRow["CGST_RATE"] = "0";
                    drCurrentRow["CGST_AMT"] = "0";
                    drCurrentRow["SGST_RATE"] = "0";
                    drCurrentRow["SGST_AMT"] = "0";
                    drCurrentRow["IGST_RATE"] = "0";
                    drCurrentRow["IGST_AMT"] = "0";
                    drCurrentRow["T_AMT"] = "0";
                    //drCurrentRow["ADD_DISFLAG"] = "N"; 

                    dtCurrentTableAMC.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable_TAMC"] = dtCurrentTableAMC;

                    GvQuotation_TAMC.DataSource = dtCurrentTableAMC;
                    GvQuotation_TAMC.DataBind();
                }
            }

            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousData3();
        }

        private void SetPreviousData3()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable_TAMC"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable_TAMC"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //TextBox TxtSrNo = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[1].FindControl("TxtSrNo");
                        Label lblSumTotalAMCQty = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMCQty"));
                        Label lblSumTotalAMC_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMC_AMT"));
                        Label lblSumAMCTotalCGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalCGST_AMT"));
                        Label lblSumAMCTotalSGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalSGST_AMT"));
                        Label lblSumAMCTotalIGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalIGST_AMT"));
                        Label lblSumTotalAMCAmount = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMCAmount"));

                        TextBox TxtBrandName = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[1].FindControl("TxtBrandName");
                        HiddenField HfBrandCodeGrid = (HiddenField)GvQuotation_TAMC.Rows[rowIndex].Cells[0].FindControl("HfBrandCodeGrid");
                        HiddenField HfModelCodeGrid = (HiddenField)GvQuotation_TAMC.Rows[rowIndex].Cells[0].FindControl("HfModelCodeGrid");
                        TextBox TxtModelName = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[1].FindControl("TxtModelName");
                        DropDownList DdlBrandName = (DropDownList)GvQuotation_TAMC.Rows[rowIndex].Cells[2].FindControl("DdlBrandName");
                        DropDownList DdlModelName = (DropDownList)GvQuotation_TAMC.Rows[rowIndex].Cells[3].FindControl("DdlModelName");
                        TextBox TxtModelDescription = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[4].FindControl("TxtModelDescription");
                        TextBox TxtQuantity = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[5].FindControl("TxtQuantity");
                        TextBox TxtRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[6].FindControl("TxtRate");
                        TextBox TxtDisRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[7].FindControl("TxtDisRate");
                        TextBox TxtAddDisRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[8].FindControl("TxtAddDisRate");
                        TextBox TxtAmount = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[9].FindControl("TxtAmount");
                        TextBox TxtCGSTRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[10].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[11].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[12].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[13].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[14].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[15].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[16].FindControl("TxtTotalAmount");

                        HiddenField HfAmount = (HiddenField)GvQuotation_TAMC.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        HiddenField HfGSTRate = (HiddenField)GvQuotation_TAMC.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                        HiddenField HfGSTAmount = (HiddenField)GvQuotation_TAMC.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");


                        //TxtSrNo.Text = dt.Rows[i]["SRNO"].ToString();
                        HfBrandCodeGrid.Value = dt.Rows[i]["BRAND_CODE"].ToString();
                        HfModelCodeGrid.Value = dt.Rows[i]["MODEL_CODE"].ToString();
                        TxtQuantity.Text = dt.Rows[i]["QTY"].ToString();
                        TxtRate.Text = dt.Rows[i]["RATE"].ToString();
                        TxtAmount.Text = dt.Rows[i]["AMT"].ToString();
                        //TxtDisRate.Text = dt.Rows[i]["DISC_PER"].ToString();
                        //TxtAddDisRate.Text = dt.Rows[i]["ADD_DISC_PER"].ToString();
                        HfAmount.Value = dt.Rows[i]["G_AMT"].ToString();
                        HfGSTRate.Value = dt.Rows[i]["GST_RATE"].ToString();
                        HfGSTAmount.Value = dt.Rows[i]["GST_AMT"].ToString();
                        TxtCGSTRate.Text = dt.Rows[i]["CGST_RATE"].ToString();
                        TxtCGSTAmount.Text = dt.Rows[i]["CGST_AMT"].ToString();
                        TxtSGSTRate.Text = dt.Rows[i]["SGST_RATE"].ToString();
                        TxtSGSTAmount.Text = dt.Rows[i]["SGST_AMT"].ToString();
                        TxtIGSTRate.Text = dt.Rows[i]["IGST_RATE"].ToString();
                        TxtIGSTAmount.Text = dt.Rows[i]["IGST_AMT"].ToString();
                        TxtTotalAmount.Text = dt.Rows[i]["T_AMT"].ToString();

                        rowIndex++;

                        double lblTotalQty = TotalQuantity_AMC();
                        lblSumTotalAMCQty.Text = lblTotalQty.ToString();

                        double lblTotGamount = TotalGrossAmount_AMC();
                        lblSumTotalAMC_AMT.Text = lblTotGamount.ToString();

                        double lblTotCGSTAmt = TotalCGSTAmount_AMC();
                        lblSumAMCTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                        double lblTotSGSTAmt = TotalSGSTAmount_AMC();
                        lblSumAMCTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                        double lblTotIGSTAmt = TotalIGSTAmount_AMC();
                        lblSumAMCTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                        double lblTotAmount = TotalAmount_AMC();
                        lblSumTotalAMCAmount.Text = lblTotAmount.ToString();

                        if (lblSumTotalAMCAmount.Text == string.Empty)
                        {
                            lblSumTotalAMCAmount.Text = "0";
                            HfGrid_T_Total.Value = "0";
                        }
                        else
                        {
                            ViewState["Total_Quotation_TAMC"] = lblSumTotalAMCAmount.Text.Trim();
                        }

                        FillNetAmount();
                    }
                }
            }
        }


        #endregion

        protected void BtnDeleteRowModelQuo_TAMCGrid_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex + 1;
            if (ViewState["CurrentTable_TAMC"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable_TAMC"];
                if (dt.Rows.Count > 1)
                {

                    if (gvRow.RowIndex <= dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data
                        dt.Rows.Remove(dt.Rows[rowID - 1]);
                    }
                }
                //Store the current data in ViewState for future reference
                ViewState["CurrentTable_TAMC"] = dt;
                //Re bind the GridView for the updated data
                GvQuotation_TAMC.DataSource = dt;
                GvQuotation_TAMC.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData3();
        }

        protected void BtnAddRowModelQuo_TAMCGrid_OnClick(object sender, EventArgs e)
        {
            AddNewRowToGrid3();
        }



        #region GST CALCULATION FOR QUOUATION_T ITEM


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetProductCode(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from STOCK_MAS where COMP_CODE=@COMP_CODE and PROD_CODE like @PROD_CODE + '%'", con);
            cmd.Parameters.AddWithValue("@PROD_CODE", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> prodCode = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                prodCode.Add(dt.Rows[i][11].ToString());
            }
            return prodCode;
        }


        public void FillOnGridStockDetailChanged()
        {
            try
            {
                #region Assign to table Stock Grid(ITEM)

                int rowIndex = 0;

                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                   
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //extract the TextBox values 
                            //TextBox TxtSrNo = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[1].FindControl("TxtSrNo");
                            Label lblSumTotalQty = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalQty"));
                            Label lblSumTotalGross_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalGross_AMT"));
                            Label lblSumTotalCGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalCGST_AMT"));
                            Label lblSumTotalSGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalSGST_AMT"));
                            Label lblSumTotalIGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalIGST_AMT"));
                            Label lblSumTotalAmount = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalAmount"));

                            HiddenField HfDetailSCode = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                            TextBox TxtProductCode = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[1].FindControl("TxtProductCode");
                            TextBox TxtProductName = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[2].FindControl("TxtProductName");
                            TextBox TxtQuantity = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[3].FindControl("TxtQuantity");
                            TextBox TxtRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[4].FindControl("TxtRate");
                            TextBox TxtDisRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[5].FindControl("TxtDisRate");
                            TextBox TxtAddDisRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[6].FindControl("TxtAddDisRate");
                            TextBox TxtAmount = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[7].FindControl("TxtAmount");
                            TextBox TxtCGSTRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[8].FindControl("TxtCGSTRate");
                            TextBox TxtCGSTAmount = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[9].FindControl("TxtCGSTAmount");
                            TextBox TxtSGSTRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[10].FindControl("TxtSGSTRate");
                            TextBox TxtSGSTAmount = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[11].FindControl("TxtSGSTAmount");
                            TextBox TxtIGSTRate = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[12].FindControl("TxtIGSTRate");
                            TextBox TxtIGSTAmount = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[12].FindControl("TxtIGSTAmount");
                            TextBox TxtTotalAmount = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[14].FindControl("TxtTotalAmount");

                            HiddenField HfAmountString = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                            HiddenField HfDisAmount = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                            HiddenField HfAddDisAmount = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfAddDisAmount");
                            HiddenField HfGSTAmount = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                            HiddenField HfGSTRate = (HiddenField)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");

                            //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["PROD_CODE"] = TxtProductCode.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["QTY"] = TxtQuantity.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["AMT"] = HfAmountString.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["DISC_PER"] = TxtDisRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["DISC_AMT"] = HfDisAmount.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["ADD_DISC_PER"] = TxtAddDisRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["ADD_DISC_AMT"] = HfAddDisAmount.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["G_AMT"] = TxtAmount.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["GST_RATE"] = HfGSTRate.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["CGST_RATE"] = TxtCGSTRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["CGST_AMT"] = TxtCGSTAmount.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["SGST_RATE"] = TxtSGSTRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["SGST_AMT"] = TxtSGSTAmount.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["IGST_RATE"] = TxtIGSTRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["IGST_AMT"] = TxtIGSTAmount.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["T_AMT"] = TxtTotalAmount.Text.Trim();


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
        protected void TxtProductCode_TextChanged(object sender, EventArgs e)
        {
            try
            {

                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");
                TextBox TxtProductName = (TextBox)row.Cells[1].FindControl("TxtProductName");
                TextBox TxtRateString = (TextBox)row.Cells[3].FindControl("TxtRate");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");
                TextBox TxtCGSTRateString = (TextBox)row.Cells[7].FindControl("TxtCGSTRate");
                TextBox TxtSGSTRateString = (TextBox)row.Cells[9].FindControl("TxtSGSTRate");
                TextBox TxtIGSTRateString = (TextBox)row.Cells[11].FindControl("TxtIGSTRate");

                DataTable DtProduct = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtProduct);
                    Dv.RowFilter = "PROD_CODE='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfDetailSCode.Value = DtView.Rows[0]["SCODE"].ToString();
                        TxtProductName.Text = DtView.Rows[0]["SNAME"].ToString();

                        FillOnGridStockDetailChanged();

                        if (txt.Text != string.Empty && DdlPartyType.SelectedIndex != 0)
                        {
                            DataTable DsStock = STOCK_MASLogicLayer.STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(HfDetailSCode.Value), DdlPartyType.SelectedValue);
                            if (DsStock.Rows.Count > 0)
                            {
                                TxtRateString.Text = DsStock.Rows[0]["SAL_RATE"].ToString();
                                HfGSTRate.Value = DsStock.Rows[0]["GST_RATE"].ToString();
                                TxtCGSTRateString.Text = DsStock.Rows[0]["CGST_RATE"].ToString();
                                TxtSGSTRateString.Text = DsStock.Rows[0]["SGST_RATE"].ToString();
                                TxtIGSTRateString.Text = DsStock.Rows[0]["IGST_RATE"].ToString();
                            }
                            else
                            {
                                TxtRateString.Text = "0";
                                HfGSTRate.Value = "0";
                                TxtCGSTRateString.Text = "0";
                                TxtSGSTRateString.Text = "0";
                                TxtIGSTRateString.Text = "0";
                            }
                        }
                        else
                        {
                            TxtRateString.Text = "0";
                            HfGSTRate.Value = "0";
                            TxtCGSTRateString.Text = "0";
                            TxtSGSTRateString.Text = "0";
                            TxtIGSTRateString.Text = "0";
                        }
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
        public static List<string> GetStockName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from STOCK_MAS where COMP_CODE=@COMP_CODE and sname like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> StockNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StockNames.Add(dt.Rows[i][1].ToString());
            }
            return StockNames;
        }

        protected void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");
                TextBox TxtProductCode = (TextBox)row.Cells[1].FindControl("TxtProductCode");
                TextBox TxtRateString = (TextBox)row.Cells[3].FindControl("TxtRate");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");
                TextBox TxtCGSTRateString = (TextBox)row.Cells[7].FindControl("TxtCGSTRate");
                TextBox TxtSGSTRateString = (TextBox)row.Cells[9].FindControl("TxtSGSTRate");
                TextBox TxtIGSTRateString = (TextBox)row.Cells[11].FindControl("TxtIGSTRate");

                DataTable DtProduct = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtProduct);
                    Dv.RowFilter = "SNAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfDetailSCode.Value = DtView.Rows[0]["SCODE"].ToString();
                        TxtProductCode.Text = DtView.Rows[0]["PROD_CODE"].ToString();

                        FillOnGridStockDetailChanged();

                        if (txt.Text != string.Empty && DdlPartyType.SelectedIndex != 0)
                        {
                            DataTable DsStock = STOCK_MASLogicLayer.STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(HfDetailSCode.Value), DdlPartyType.SelectedValue);
                            if (DsStock.Rows.Count > 0)
                            {
                                TxtRateString.Text = DsStock.Rows[0]["SAL_RATE"].ToString();
                                HfGSTRate.Value = DsStock.Rows[0]["GST_RATE"].ToString();
                                TxtCGSTRateString.Text = DsStock.Rows[0]["CGST_RATE"].ToString();
                                TxtSGSTRateString.Text = DsStock.Rows[0]["SGST_RATE"].ToString();
                                TxtIGSTRateString.Text = DsStock.Rows[0]["IGST_RATE"].ToString();
                            }
                            else
                            {
                                TxtRateString.Text = "0";
                                HfGSTRate.Value = "0";
                                TxtCGSTRateString.Text = "0";
                                TxtSGSTRateString.Text = "0";
                                TxtIGSTRateString.Text = "0";
                            }
                        }
                        else
                        {
                            TxtRateString.Text = "0";
                            HfGSTRate.Value = "0";
                            TxtCGSTRateString.Text = "0";
                            TxtSGSTRateString.Text = "0";
                            TxtIGSTRateString.Text = "0";
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlProductName_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    DropDownList ddl = (DropDownList)sender;
            //    GridViewRow row = (GridViewRow)ddl.Parent.Parent;
            //    int idx = row.RowIndex;
            //    TextBox TxtRateString = (TextBox)row.Cells[3].FindControl("TxtRate");
            //    HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");
            //    TextBox TxtCGSTRateString = (TextBox)row.Cells[7].FindControl("TxtCGSTRate");
            //    TextBox TxtSGSTRateString = (TextBox)row.Cells[9].FindControl("TxtSGSTRate");
            //    TextBox TxtIGSTRateString = (TextBox)row.Cells[11].FindControl("TxtIGSTRate");



            //    if (ddl.SelectedIndex != 0 && DdlPartyType.SelectedIndex != 0)
            //    {
            //        DataTable DsStock = STOCK_MASLogicLayer.STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(ddl.SelectedValue), DdlPartyType.SelectedValue);
            //        if (DsStock.Rows.Count > 0)
            //        {
            //            TxtRateString.Text = DsStock.Rows[0]["SAL_RATE"].ToString();
            //            HfGSTRate.Value= DsStock.Rows[0]["GST_RATE"].ToString();
            //            TxtCGSTRateString.Text = DsStock.Rows[0]["CGST_RATE"].ToString();
            //            TxtSGSTRateString.Text = DsStock.Rows[0]["SGST_RATE"].ToString();
            //            TxtIGSTRateString.Text = DsStock.Rows[0]["IGST_RATE"].ToString();
            //        }
            //        else
            //        {
            //            TxtRateString.Text = "0";
            //            HfGSTRate.Value = "0";
            //            TxtCGSTRateString.Text = "0";
            //            TxtSGSTRateString.Text = "0";
            //            TxtIGSTRateString.Text = "0";
            //        }
            //    }
            //    else
            //    {
            //        TxtRateString.Text = "0";
            //        HfGSTRate.Value = "0";
            //        TxtCGSTRateString.Text = "0";
            //        TxtSGSTRateString.Text = "0";
            //        TxtIGSTRateString.Text = "0";
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        protected void TxtQuantity_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                Label lblSumTotalQty = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalQty"));
                Label lblSumTotalGross_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalGross_AMT"));
                Label lblSumTotalCGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalCGST_AMT"));
                Label lblSumTotalSGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalSGST_AMT"));
                Label lblSumTotalIGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalIGST_AMT"));
                Label lblSumTotalAmount = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalAmount"));

                TextBox TxtRateString = (TextBox)row.Cells[3].FindControl("TxtRate");
                TextBox TxtG_AmountString = (TextBox)row.Cells[6].FindControl("TxtAmount");
                HiddenField HfAmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");

                TextBox TxtDisRate = (TextBox)row.Cells[4].FindControl("TxtDisRate");
                HiddenField HfDisAmount = (HiddenField)row.Cells[0].FindControl("HfDisAmount");
                TextBox TxtAddDisRate = (TextBox)row.Cells[6].FindControl("TxtAddDisRate");
                HiddenField HfAddDisAmount = (HiddenField)row.Cells[0].FindControl("HfAddDisAmount");

                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");
                TextBox CGST_RATEString = (TextBox)row.Cells[7].FindControl("TxtCGSTRate");
                TextBox SGST_RATEString = (TextBox)row.Cells[9].FindControl("TxtSGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[8].FindControl("TxtCGSTAmount");
                TextBox SGST_AMTString = (TextBox)row.Cells[10].FindControl("TxtSGSTAmount");
                TextBox T_AMTString = (TextBox)row.Cells[13].FindControl("TxtTotalAmount");

                if (TxtRateString.Text == string.Empty)
                {
                    TxtRateString.Text = "0";
                }

                if (TxtDisRate.Text == string.Empty)
                {
                    TxtDisRate.Text = "0";
                }

                if (TxtAddDisRate.Text == string.Empty)
                {
                    TxtAddDisRate.Text = "0";
                }

                if (txt.Text.Trim() != string.Empty)
                {
                    double adisamt, amt, disamt;

                    amt = (Convert.ToDouble(txt.Text) * Convert.ToDouble(TxtRateString.Text));
                    HfAmountString.Value = Convert.ToString(amt);
                    HfDisAmount.Value = ((amt * Convert.ToDouble(TxtDisRate.Text)) / 100).ToString();
                    disamt = Convert.ToDouble(HfAmountString.Value) - Convert.ToDouble(HfDisAmount.Value);
                    TxtG_AmountString.Text = disamt.ToString();
                    HfAddDisAmount.Value = ((Convert.ToDouble(TxtAddDisRate.Text.Trim()) * disamt) / 100).ToString();
                    adisamt = Convert.ToDouble(TxtG_AmountString.Text) - Convert.ToDouble(HfAddDisAmount.Value);
                    TxtG_AmountString.Text = adisamt.ToString();


                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Text = (((adisamt) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                        SGST_AMTString.Text = (((adisamt) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();

                        double d;
                        d = ((adisamt) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                        T_AMTString.Text = Convert.ToString(d);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        TextBox IGST_RATEString = (TextBox)row.Cells[11].FindControl("TxtIGSTRate");
                        TextBox IGST_AMTString = (TextBox)row.Cells[12].FindControl("TxtIGSTAmount");

                        IGST_AMTString.Text = (((adisamt) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Text;
                        T_AMTString.Text = ((adisamt) + Convert.ToDouble(IGST_AMTString.Text)).ToString();
                    }


                    double lblTotalQuantity = TotalQuantity_T();
                    lblSumTotalQty.Text = lblTotalQuantity.ToString();

                    double lblTotGamount = TotalGrossAmount_T();
                    lblSumTotalGross_AMT.Text = lblTotGamount.ToString();

                    double lblTotCGSTAmt = TotalCGSTAmount_T();
                    lblSumTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                    double lblTotSGSTAmt = TotalSGSTAmount_T();
                    lblSumTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                    double lblTotIGSTAmt = TotalIGSTAmount_T();
                    lblSumTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                    double lblTotAmount = TotalAmount_T();
                    lblSumTotalAmount.Text = lblTotAmount.ToString();


                    if (lblSumTotalAmount.Text == string.Empty)
                    {
                        lblSumTotalAmount.Text = "0";
                        HfGrid_T_Total.Value = "0";

                    }
                    else
                    {
                        ViewState["Total_Quotation_T"] = lblSumTotalAmount.Text.Trim();
                       // Grid_T_Total = Convert.ToDecimal(lblSumTotalAmount.Text.Trim());

                    }

                    FillNetAmount();
                    FillOnGridStockDetailChanged();
                }
                else
                {
                    TxtG_AmountString.Text = Convert.ToString(Convert.ToDouble(0));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;


                Label lblSumTotalQty = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalQty"));
                Label lblSumTotalGross_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalGross_AMT"));
                Label lblSumTotalCGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalCGST_AMT"));
                Label lblSumTotalSGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalSGST_AMT"));
                Label lblSumTotalIGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalIGST_AMT"));
                Label lblSumTotalAmount = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalAmount"));

                TextBox TxtQuantityString = (TextBox)row.Cells[2].FindControl("TxtQuantity");
                TextBox TxtG_AmountString = (TextBox)row.Cells[6].FindControl("TxtAmount");
                HiddenField HfAmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");

                TextBox TxtDisRate = (TextBox)row.Cells[4].FindControl("TxtDisRate");
                HiddenField HfDisAmount = (HiddenField)row.Cells[0].FindControl("HfDisAmount");
                TextBox TxtAddDisRate = (TextBox)row.Cells[6].FindControl("TxtAddDisRate");
                HiddenField HfAddDisAmount = (HiddenField)row.Cells[0].FindControl("HfAddDisAmount");

                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");
                TextBox CGST_RATEString = (TextBox)row.Cells[7].FindControl("TxtCGSTRate");
                TextBox SGST_RATEString = (TextBox)row.Cells[9].FindControl("TxtSGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[8].FindControl("TxtCGSTAmount");
                TextBox SGST_AMTString = (TextBox)row.Cells[10].FindControl("TxtSGSTAmount");
                TextBox T_AMTString = (TextBox)row.Cells[13].FindControl("TxtTotalAmount");

                if (TxtQuantityString.Text == string.Empty)
                {
                    TxtQuantityString.Text = "0";
                }

                if (TxtDisRate.Text == string.Empty)
                {
                    TxtDisRate.Text = "0";
                }

                if (TxtAddDisRate.Text == string.Empty)
                {
                    TxtAddDisRate.Text = "0";
                }

                if (txt.Text.Trim() != string.Empty)
                {
                    double adisamt, amt, disamt;

                    amt = (Convert.ToDouble(txt.Text) * Convert.ToDouble(TxtQuantityString.Text));
                    HfAmountString.Value = Convert.ToString(amt);
                    HfDisAmount.Value = ((amt * Convert.ToDouble(TxtDisRate.Text)) / 100).ToString();
                    disamt = Convert.ToDouble(HfAmountString.Value) - Convert.ToDouble(HfDisAmount.Value);
                    TxtG_AmountString.Text = disamt.ToString();
                    HfAddDisAmount.Value = ((Convert.ToDouble(TxtAddDisRate.Text.Trim()) * disamt) / 100).ToString();
                    adisamt = Convert.ToDouble(TxtG_AmountString.Text) - Convert.ToDouble(HfAddDisAmount.Value);
                    TxtG_AmountString.Text = adisamt.ToString();


                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Text = (((adisamt) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                        SGST_AMTString.Text = (((adisamt) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();

                        double d;
                        d = ((adisamt) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                        T_AMTString.Text = Convert.ToString(d);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        TextBox IGST_RATEString = (TextBox)row.Cells[11].FindControl("TxtIGSTRate");
                        TextBox IGST_AMTString = (TextBox)row.Cells[12].FindControl("TxtIGSTAmount");

                        IGST_AMTString.Text = (((adisamt) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Text;
                        T_AMTString.Text = ((adisamt) + Convert.ToDouble(IGST_AMTString.Text)).ToString();
                    }

                    double lblTotalQuantity = TotalQuantity_T();
                    lblSumTotalQty.Text = lblTotalQuantity.ToString();

                    double lblTotGamount = TotalGrossAmount_T();
                    lblSumTotalGross_AMT.Text = lblTotGamount.ToString();

                    double lblTotCGSTAmt = TotalCGSTAmount_T();
                    lblSumTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                    double lblTotSGSTAmt = TotalSGSTAmount_T();
                    lblSumTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                    double lblTotIGSTAmt = TotalIGSTAmount_T();
                    lblSumTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                    double lblTotAmount = TotalAmount_T();
                    lblSumTotalAmount.Text = lblTotAmount.ToString();

                    if (lblSumTotalAmount.Text == string.Empty)
                    {
                        lblSumTotalAmount.Text = "0";
                        HfGrid_T_Total.Value = "0";
                    }
                    else
                    {
                        ViewState["Total_Quotation_T"] = lblSumTotalAmount.Text.Trim();

                    //  Grid_T_Total = Convert.ToDecimal(lblSumTotalAmount.Text.Trim());
                    }


                    FillNetAmount();
                    FillOnGridStockDetailChanged();
                }
                else
                {
                    TxtG_AmountString.Text = Convert.ToString(Convert.ToDouble(0));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtDisRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                if (validation.ispercentage(txt.Text.Trim()))
                {


                    Label lblSumTotalQty = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalQty"));
                    Label lblSumTotalGross_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalGross_AMT"));
                    Label lblSumTotalCGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalCGST_AMT"));
                    Label lblSumTotalSGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalSGST_AMT"));
                    Label lblSumTotalIGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalIGST_AMT"));
                    Label lblSumTotalAmount = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalAmount"));

                    TextBox TxtRateString = (TextBox)row.Cells[4].FindControl("TxtRate");
                    TextBox TxtQuantityString = (TextBox)row.Cells[3].FindControl("TxtQuantity");
                    HiddenField HfAmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");

                    TextBox CGST_RATEString = (TextBox)row.Cells[7].FindControl("TxtCGSTRate");
                    TextBox SGST_RATEString = (TextBox)row.Cells[9].FindControl("TxtSGSTRate");
                    TextBox CGST_AMTString = (TextBox)row.Cells[8].FindControl("TxtCGSTAmount");
                    TextBox SGST_AMTString = (TextBox)row.Cells[10].FindControl("TxtSGSTAmount");
                    TextBox TxtG_AmountString = (TextBox)row.Cells[6].FindControl("TxtAmount");
                    TextBox T_AMTString = (TextBox)row.Cells[13].FindControl("TxtTotalAmount");

                    HiddenField HfDisAmount = (HiddenField)row.Cells[0].FindControl("HfDisAmount");
                    HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                    HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                    if (txt.Text.Trim() != string.Empty && TxtQuantityString.Text != string.Empty && TxtRateString.Text != string.Empty)
                    {
                        //  HfAmountString.Value = Convert.ToString(Convert.ToDouble(TxtRateString.Text.Trim()) * Convert.ToDouble(TxtQuantityString.Text.Trim()));

                        double disamt, amt;

                        amt = (Convert.ToDouble(TxtRateString.Text) * Convert.ToDouble(TxtQuantityString.Text));
                        HfAmountString.Value = Convert.ToString(amt);

                        HfDisAmount.Value = ((amt * Convert.ToDouble(txt.Text)) / 100).ToString();
                        disamt = Convert.ToDouble(HfAmountString.Value) - Convert.ToDouble(HfDisAmount.Value);
                        TxtG_AmountString.Text = disamt.ToString();

                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            CGST_AMTString.Text = (((disamt) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                            SGST_AMTString.Text = (((disamt) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                            HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                            double d;
                            d = ((disamt) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                            T_AMTString.Text = Convert.ToString(d);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            TextBox IGST_RATEString = (TextBox)row.Cells[11].FindControl("TxtIGSTRate");
                            TextBox IGST_AMTString = (TextBox)row.Cells[12].FindControl("TxtIGSTAmount");

                            IGST_AMTString.Text = (((disamt) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                            HfGSTAmount.Value = IGST_AMTString.Text;
                            T_AMTString.Text = ((disamt) + Convert.ToDouble(IGST_AMTString.Text)).ToString();
                        }

                        double lblTotalQuantity = TotalQuantity_T();
                        lblSumTotalQty.Text = lblTotalQuantity.ToString();

                        double lblTotGamount = TotalGrossAmount_T();
                        lblSumTotalGross_AMT.Text = lblTotGamount.ToString();

                        double lblTotCGSTAmt = TotalCGSTAmount_T();
                        lblSumTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                        double lblTotSGSTAmt = TotalSGSTAmount_T();
                        lblSumTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                        double lblTotIGSTAmt = TotalIGSTAmount_T();
                        lblSumTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                        double lblTotAmount = TotalAmount_T();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();

                        if (lblSumTotalAmount.Text == string.Empty)
                        {
                            lblSumTotalAmount.Text = "0";
                            HfGrid_T_Total.Value = "0";
                        }
                        else
                        {
                            ViewState["Total_Quotation_T"] = lblSumTotalAmount.Text.Trim();

                        //  Grid_T_Total = Convert.ToDecimal(lblSumTotalAmount.Text.Trim());
                        }

                        FillNetAmount();
                        FillOnGridStockDetailChanged();
                    }

                    else
                    {
                        TxtG_AmountString.Text = Convert.ToString(Convert.ToDouble(0));
                    }
                    txt.BackColor = Color.White;
                }
                else
                {
                    //Give Javascript Error message
                    txt.Text = "0";
                    txt.BackColor = Color.Red;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Percentage should be between 0 to 100..!!');", true);
                    txt.Focus();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void TxtAddDisRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                if (validation.ispercentage(txt.Text.Trim()))
                {

                    Label lblSumTotalQty = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalQty"));
                    Label lblSumTotalGross_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalGross_AMT"));
                    Label lblSumTotalCGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalCGST_AMT"));
                    Label lblSumTotalSGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalSGST_AMT"));
                    Label lblSumTotalIGST_AMT = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalIGST_AMT"));
                    Label lblSumTotalAmount = (Label)(GvQuotation_T.FooterRow.FindControl("lblSumTotalAmount"));

                    TextBox TxtRateString = (TextBox)row.Cells[4].FindControl("TxtRate");
                    TextBox TxtQuantityString = (TextBox)row.Cells[3].FindControl("TxtQuantity");

                    HiddenField HfAmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");
                    TextBox TxtG_AmountString = (TextBox)row.Cells[6].FindControl("TxtAmount");

                    TextBox TxtDisRate = (TextBox)row.Cells[5].FindControl("TxtDisRate");
                    HiddenField HfDisAmount = (HiddenField)row.Cells[0].FindControl("HfDisAmount");
                    HiddenField HfAddDisAmount = (HiddenField)row.Cells[0].FindControl("HfAddDisAmount");
                    HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                    HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");


                    TextBox CGST_RATEString = (TextBox)row.Cells[7].FindControl("TxtCGSTRate");
                    TextBox SGST_RATEString = (TextBox)row.Cells[9].FindControl("TxtSGSTRate");
                    TextBox CGST_AMTString = (TextBox)row.Cells[8].FindControl("TxtCGSTAmount");
                    TextBox SGST_AMTString = (TextBox)row.Cells[10].FindControl("TxtSGSTAmount");
                    TextBox T_AMTString = (TextBox)row.Cells[13].FindControl("TxtTotalAmount");

                    if (txt.Text.Trim() != string.Empty && TxtQuantityString.Text != string.Empty && TxtRateString.Text != string.Empty)
                    {
                        //  HfAmountString.Value = Convert.ToString(Convert.ToDouble(TxtRateString.Text.Trim()) * Convert.ToDouble(TxtQuantityString.Text.Trim()));

                        double adisamt, amt, disamt;

                        amt = (Convert.ToDouble(TxtQuantityString.Text) * Convert.ToDouble(TxtRateString.Text));
                        HfAmountString.Value = Convert.ToString(amt);

                        HfDisAmount.Value = ((amt * Convert.ToDouble(TxtDisRate.Text)) / 100).ToString();
                        disamt = Convert.ToDouble(HfAmountString.Value) - Convert.ToDouble(HfDisAmount.Value);
                        TxtG_AmountString.Text = disamt.ToString();

                        HfAddDisAmount.Value = ((Convert.ToDouble(txt.Text.Trim()) * disamt) / 100).ToString();
                        adisamt = Convert.ToDouble(TxtG_AmountString.Text) - Convert.ToDouble(HfAddDisAmount.Value);
                        TxtG_AmountString.Text = adisamt.ToString();



                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            CGST_AMTString.Text = (((adisamt) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                            SGST_AMTString.Text = (((adisamt) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                            HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                            double d;
                            d = ((adisamt) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                            T_AMTString.Text = Convert.ToString(d);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            TextBox IGST_RATEString = (TextBox)row.Cells[11].FindControl("TxtIGSTRate");
                            TextBox IGST_AMTString = (TextBox)row.Cells[12].FindControl("TxtIGSTAmount");

                            IGST_AMTString.Text = (((adisamt) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                            HfGSTAmount.Value = IGST_AMTString.Text;
                            T_AMTString.Text = ((adisamt) + Convert.ToDouble(IGST_AMTString.Text)).ToString();
                        }

                        double lblTotalQuantity = TotalQuantity_T();
                        lblSumTotalQty.Text = lblTotalQuantity.ToString();

                        double lblTotGamount = TotalGrossAmount_T();
                        lblSumTotalGross_AMT.Text = lblTotGamount.ToString();

                        double lblTotCGSTAmt = TotalCGSTAmount_T();
                        lblSumTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                        double lblTotSGSTAmt = TotalSGSTAmount_T();
                        lblSumTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                        double lblTotIGSTAmt = TotalIGSTAmount_T();
                        lblSumTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                        double lblTotAmount = TotalAmount_T();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();

                        if (lblSumTotalAmount.Text == string.Empty)
                        {
                            lblSumTotalAmount.Text = "0";
                            HfGrid_T_Total.Value = "0";
                        }
                        else
                        {
                            ViewState["Total_Quotation_T"] = lblSumTotalAmount.Text.Trim();

                         //  Grid_T_Total = Convert.ToDecimal(lblSumTotalAmount.Text.Trim());
                        }

                        FillNetAmount();
                        FillOnGridStockDetailChanged();
                    }
                    else
                    {
                        TxtG_AmountString.Text = TxtG_AmountString.Text;
                    }
                    txt.BackColor = Color.White;
                }
                else
                {
                    //Give Javascript Error message
                    txt.Text = "0";
                    txt.BackColor = Color.Red;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Percentage should be between 0 to 100..!!');", true);
                    txt.Focus();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region GST CALCULATION FOR QUOUATION_T AMC

        protected void DdlBrandName_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                DropDownList ddl = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl.Parent.Parent;
                int idx = row.RowIndex;

                DropDownList DdlBrandName = (DropDownList)row.Cells[2].FindControl("DdlBrandName");
                DropDownList DdlModelName = (DropDownList)row.Cells[3].FindControl("DdlModelName");

                DataTable dt = new DataTable();
                string Brand_Code = DdlBrandName.SelectedValue;

                dt = STOCK_MODELMASLogicLayer.GetSTOCK_MODELMAS_ModelNameBrandWiseFor_Ddl(Brand_Code);
                DdlModelName.DataValueField = "MODEL_CODE";
                DdlModelName.DataTextField = "MODEL_NAME";
                DdlModelName.DataSource = dt;
                DdlModelName.DataBind();

                // DdlModelName.SelectedValue = HfBrandCodeGrid.Value;


            }
            catch (Exception)
            {

                throw;
            }
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetBrandName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from STOCK_BRANDMAS where COMP_CODE=@COMP_CODE and BRAND_NAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> BrandNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BrandNames.Add(dt.Rows[i][2].ToString());
            }
            return BrandNames;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetModelName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from STOCK_MODELMAS where BRAND_CODE=@BRAND_CODE and MODEL_NAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@BRAND_CODE", brandname);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> ModelNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ModelNames.Add(dt.Rows[i][3].ToString());
            }
            return ModelNames;
        }


        public void FillOnGridModelItemDetailChanged()
        {
            try
            {
                #region Assign to Stock Grid Table(AMC)

                int rowIndex = 0;

                if (ViewState["CurrentTable_TAMC"] != null)
                {
                    DataTable dtCurrentTableAMC = (DataTable)ViewState["CurrentTable_TAMC"];
                 
                    if (dtCurrentTableAMC.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTableAMC.Rows.Count; i++)
                        {
                            //if(dtCurrentTableAMC != null)
                            //{



                            //extract the TextBox values 
                            //TextBox TxtSrNo = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[1].FindControl("TxtSrNo");
                            Label lblSumTotalAMCQty = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMCQty"));
                            Label lblSumTotalAMC_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMC_AMT"));
                            Label lblSumAMCTotalCGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalCGST_AMT"));
                            Label lblSumAMCTotalSGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalSGST_AMT"));
                            Label lblSumAMCTotalIGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalIGST_AMT"));
                            Label lblSumTotalAMCAmount = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMCAmount"));

                            HiddenField HfBrandCodeGrid = (HiddenField)GvQuotation_TAMC.Rows[rowIndex].Cells[0].FindControl("HfBrandCodeGrid");
                            TextBox TxtBrandName = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[1].FindControl("TxtBrandName");
                            HiddenField HfModelCodeGrid = (HiddenField)GvQuotation_TAMC.Rows[rowIndex].Cells[0].FindControl("HfModelCodeGrid");
                            TextBox TxtModelName = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[1].FindControl("TxtModelName");
                            DropDownList DdlBrandName = (DropDownList)GvQuotation_TAMC.Rows[rowIndex].Cells[2].FindControl("DdlBrandName");
                            DropDownList DdlModelName = (DropDownList)GvQuotation_TAMC.Rows[rowIndex].Cells[3].FindControl("DdlModelName");
                            TextBox TxtModelDescription = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[4].FindControl("TxtModelDescription");
                            TextBox TxtQuantity = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[5].FindControl("TxtQuantity");
                            TextBox TxtRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[6].FindControl("TxtRate");
                            TextBox TxtDisRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[7].FindControl("TxtDisRate");
                            TextBox TxtAddDisRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[8].FindControl("TxtAddDisRate");
                            TextBox TxtAmount = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[9].FindControl("TxtAmount");
                            TextBox TxtCGSTRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[10].FindControl("TxtCGSTRate");
                            TextBox TxtCGSTAmount = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[11].FindControl("TxtCGSTAmount");
                            TextBox TxtSGSTRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[12].FindControl("TxtSGSTRate");
                            TextBox TxtSGSTAmount = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[13].FindControl("TxtSGSTAmount");
                            TextBox TxtIGSTRate = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[14].FindControl("TxtIGSTRate");
                            TextBox TxtIGSTAmount = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[15].FindControl("TxtIGSTAmount");
                            TextBox TxtTotalAmount = (TextBox)GvQuotation_TAMC.Rows[rowIndex].Cells[16].FindControl("TxtTotalAmount");

                            HiddenField HfAmount = (HiddenField)GvQuotation_TAMC.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                            HiddenField HfGSTRate = (HiddenField)GvQuotation_TAMC.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                            HiddenField HfGSTAmount = (HiddenField)GvQuotation_TAMC.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");

                            //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();

                            dtCurrentTableAMC.Rows[i - 1]["BRAND_CODE"] = HfBrandCodeGrid.Value.Trim();
                            dtCurrentTableAMC.Rows[i - 1]["MODEL_CODE"] = HfModelCodeGrid.Value.Trim();
                            dtCurrentTableAMC.Rows[i - 1]["QTY"] = TxtQuantity.Text.Trim();
                            dtCurrentTableAMC.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                            dtCurrentTableAMC.Rows[i - 1]["AMT"] = TxtAmount.Text.Trim();
                            dtCurrentTableAMC.Rows[i - 1]["G_AMT"] = HfAmount.Value.Trim();
                            dtCurrentTableAMC.Rows[i - 1]["GST_RATE"] = HfGSTRate.Value.Trim();
                            dtCurrentTableAMC.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                            dtCurrentTableAMC.Rows[i - 1]["CGST_RATE"] = TxtCGSTRate.Text.Trim();
                            dtCurrentTableAMC.Rows[i - 1]["CGST_AMT"] = TxtCGSTAmount.Text.Trim();
                            dtCurrentTableAMC.Rows[i - 1]["SGST_RATE"] = TxtSGSTRate.Text.Trim();
                            dtCurrentTableAMC.Rows[i - 1]["SGST_AMT"] = TxtSGSTAmount.Text.Trim();
                            dtCurrentTableAMC.Rows[i - 1]["IGST_RATE"] = TxtIGSTRate.Text.Trim();
                            dtCurrentTableAMC.Rows[i - 1]["IGST_AMT"] = TxtIGSTAmount.Text.Trim();
                            dtCurrentTableAMC.Rows[i - 1]["T_AMT"] = TxtTotalAmount.Text.Trim();


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


        protected void TxtBrandName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfBrandCodeGrid = (HiddenField)row.Cells[0].FindControl("HfBrandCodeGrid");
                HiddenField HfModelCodeGrid = (HiddenField)row.Cells[0].FindControl("HfModelCodeGrid");
                TextBox TxtModelName = (TextBox)row.Cells[3].FindControl("TxtModelName");
                DropDownList DdlModelName = (DropDownList)row.Cells[3].FindControl("DdlModelName");

                DataTable DtBrand = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtBrand = STOCK_BRANDMASLogicLayer.GetSTOCKBRANDMAS_BrandNameCompanyWiseFor_Ddl(Comp_Code);
                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrand);
                    Dv.RowFilter = "BRAND_NAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfBrandCodeGrid.Value = DtView.Rows[0]["BRAND_CODE"].ToString();
                        brandname = HfBrandCodeGrid.Value;

                        FillOnGridModelItemDetailChanged();

                    }
                }



            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void TxtModelName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfBrandCodeGrid = (HiddenField)row.Cells[0].FindControl("HfBrandCodeGrid");
                HiddenField HfModelCodeGrid = (HiddenField)row.Cells[0].FindControl("HfModelCodeGrid");
                TextBox TxtModelDescription = (TextBox)row.Cells[3].FindControl("TxtModelDescription");

                DataTable DtModel = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtModel = STOCK_MODELMASLogicLayer.GetSTOCK_MODELMAS_ModelNameBrandWiseFor_Ddl(HfBrandCodeGrid.Value);

                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtModel);
                    Dv.RowFilter = "MODEL_NAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfModelCodeGrid.Value = DtView.Rows[0]["MODEL_CODE"].ToString();
                        TxtModelDescription.Text = DtView.Rows[0]["MODEL_DESC"].ToString();

                        FillOnGridModelItemDetailChanged();
                    }

                }



            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtQuantity2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                Label lblSumTotalAMCQty = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMCQty"));
                Label lblSumTotalAMC_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMC_AMT"));
                Label lblSumAMCTotalCGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalCGST_AMT"));
                Label lblSumAMCTotalSGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalSGST_AMT"));
                Label lblSumAMCTotalIGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalIGST_AMT"));
                Label lblSumTotalAMCAmount = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMCAmount"));

                TextBox TxtRateString = (TextBox)row.Cells[5].FindControl("TxtRate");
                TextBox TxtAmountString = (TextBox)row.Cells[8].FindControl("TxtAmount");
                HiddenField HfG_AmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");

                TextBox CGST_RATEString = (TextBox)row.Cells[9].FindControl("TxtCGSTRate");
                TextBox SGST_RATEString = (TextBox)row.Cells[11].FindControl("TxtSGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[10].FindControl("TxtCGSTAmount");
                TextBox SGST_AMTString = (TextBox)row.Cells[12].FindControl("TxtSGSTAmount");
                TextBox T_AMTString = (TextBox)row.Cells[15].FindControl("TxtTotalAmount");
                TextBox IGST_RATEString = (TextBox)row.Cells[13].FindControl("TxtIGSTRate");
                TextBox IGST_AMTString = (TextBox)row.Cells[14].FindControl("TxtIGSTAmount");

                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                if (CGST_RATEString.Text == string.Empty)
                {
                    CGST_RATEString.Text = "0";
                }
                if (SGST_RATEString.Text == string.Empty)
                {
                    SGST_RATEString.Text = "0";
                }
                if (IGST_RATEString.Text == string.Empty)
                {
                    IGST_RATEString.Text = "0";
                }


                if (txt.Text.Trim() != string.Empty && TxtRateString.Text.Trim() != string.Empty)
                {
                    TxtAmountString.Text = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtRateString.Text.Trim()));

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                        SGST_AMTString.Text = CGST_AMTString.Text;
                        SGST_RATEString.Text = CGST_RATEString.Text;

                        HfGSTRate.Value = Convert.ToString(Convert.ToDouble(CGST_RATEString.Text.Trim()) + Convert.ToDouble(SGST_RATEString.Text.Trim())).ToString();
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                        IGST_AMTString.Text = "0";
                        IGST_RATEString.Text = "0";

                        double d;
                        d = ((Convert.ToDouble(TxtAmountString.Text.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                        T_AMTString.Text = Convert.ToString(d);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        CGST_AMTString.Text = "0";
                        SGST_AMTString.Text = "0";
                        SGST_AMTString.Text = "0";
                        SGST_RATEString.Text = "0";

                        HfGSTRate.Value = IGST_RATEString.Text;
                        IGST_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Text;
                        T_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();
                    }

                    double lblTotalQty = TotalQuantity_AMC();
                    lblSumTotalAMCQty.Text = lblTotalQty.ToString();

                    double lblTotGamount = TotalGrossAmount_AMC();
                    lblSumTotalAMC_AMT.Text = lblTotGamount.ToString();

                    double lblTotCGSTAmt = TotalCGSTAmount_AMC();
                    lblSumAMCTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                    double lblTotSGSTAmt = TotalSGSTAmount_AMC();
                    lblSumAMCTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                    double lblTotIGSTAmt = TotalIGSTAmount_AMC();
                    lblSumAMCTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                    double lblTotAmount = TotalAmount_AMC();
                    lblSumTotalAMCAmount.Text = lblTotAmount.ToString();

                    if (lblSumTotalAMCAmount.Text == string.Empty)
                    {
                        lblSumTotalAMCAmount.Text = "0";
                        HfGrid_T_Total.Value = "0";
                    }
                    else
                    {

                        ViewState["Total_Quotation_TAMC"] = lblSumTotalAMCAmount.Text.Trim();
                    }

                    FillNetAmount();
                    FillOnGridModelItemDetailChanged();
                }

                else
                {
                    TxtAmountString.Text = Convert.ToString(Convert.ToDouble(0));
                }
            }

            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtRate_TextChanged3(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                Label lblSumTotalAMCQty = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMCQty"));
                Label lblSumTotalAMC_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMC_AMT"));
                Label lblSumAMCTotalCGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalCGST_AMT"));
                Label lblSumAMCTotalSGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalSGST_AMT"));
                Label lblSumAMCTotalIGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalIGST_AMT"));
                Label lblSumTotalAMCAmount = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMCAmount"));

                TextBox TxtQuantityString = (TextBox)row.Cells[4].FindControl("TxtQuantity");
                TextBox TxtAmountString = (TextBox)row.Cells[8].FindControl("TxtAmount");
                HiddenField HfG_AmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");

                TextBox CGST_RATEString = (TextBox)row.Cells[9].FindControl("TxtCGSTRate");
                TextBox SGST_RATEString = (TextBox)row.Cells[11].FindControl("TxtSGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[10].FindControl("TxtCGSTAmount");
                TextBox SGST_AMTString = (TextBox)row.Cells[12].FindControl("TxtSGSTAmount");
                TextBox T_AMTString = (TextBox)row.Cells[15].FindControl("TxtTotalAmount");
                TextBox IGST_RATEString = (TextBox)row.Cells[13].FindControl("TxtIGSTRate");
                TextBox IGST_AMTString = (TextBox)row.Cells[14].FindControl("TxtIGSTAmount");

                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");


                if (txt.Text.Trim() != string.Empty && TxtQuantityString.Text.Trim() != string.Empty)
                {
                    TxtAmountString.Text = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtQuantityString.Text.Trim()));

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                        SGST_AMTString.Text = CGST_AMTString.Text;
                        SGST_RATEString.Text = CGST_RATEString.Text;

                        HfGSTRate.Value = Convert.ToString(Convert.ToDouble(CGST_RATEString.Text.Trim()) + Convert.ToDouble(SGST_RATEString.Text.Trim())).ToString();
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                        IGST_AMTString.Text = "0";
                        IGST_RATEString.Text = "0";

                        double d;
                        d = ((Convert.ToDouble(TxtAmountString.Text.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                        T_AMTString.Text = Convert.ToString(d);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        CGST_AMTString.Text = "0";
                        SGST_AMTString.Text = "0";
                        SGST_AMTString.Text = "0";
                        SGST_RATEString.Text = "0";

                        IGST_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Text;
                        HfGSTRate.Value = IGST_RATEString.Text;
                        T_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();
                    }

                    double lblTotalQty = TotalQuantity_AMC();
                    lblSumTotalAMCQty.Text = lblTotalQty.ToString();

                    double lblTotGamount = TotalGrossAmount_AMC();
                    lblSumTotalAMC_AMT.Text = lblTotGamount.ToString();

                    double lblTotCGSTAmt = TotalCGSTAmount_AMC();
                    lblSumAMCTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                    double lblTotSGSTAmt = TotalSGSTAmount_AMC();
                    lblSumAMCTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                    double lblTotIGSTAmt = TotalIGSTAmount_AMC();
                    lblSumAMCTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                    double lblTotAmount = TotalAmount_AMC();
                    lblSumTotalAMCAmount.Text = lblTotAmount.ToString();

                    if (lblSumTotalAMCAmount.Text == string.Empty)
                    {
                        lblSumTotalAMCAmount.Text = "0";
                        HfGrid_T_Total.Value = "0";
                    }
                    else
                    {
                        ViewState["Total_Quotation_TAMC"] = lblSumTotalAMCAmount.Text.Trim();

                       // Grid_TAMC_Total = Convert.ToDecimal(lblSumTotalAMCAmount.Text.Trim());
                    }
                   
                    FillNetAmount();
                    FillOnGridModelItemDetailChanged();
                }
                else
                {
                    TxtAmountString.Text = Convert.ToString(Convert.ToDouble(0));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtCGSTRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                Label lblSumTotalAMCQty = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMCQty"));
                Label lblSumTotalAMC_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMC_AMT"));
                Label lblSumAMCTotalCGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalCGST_AMT"));
                Label lblSumAMCTotalSGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalSGST_AMT"));
                Label lblSumAMCTotalIGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalIGST_AMT"));
                Label lblSumTotalAMCAmount = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMCAmount"));

                TextBox TxtQuantityString = (TextBox)row.Cells[4].FindControl("TxtQuantity");
                TextBox TxtRateString = (TextBox)row.Cells[5].FindControl("TxtRate");
                TextBox TxtAmountString = (TextBox)row.Cells[8].FindControl("TxtAmount");

                TextBox CGST_RATEString = (TextBox)row.Cells[9].FindControl("TxtCGSTRate");
                TextBox SGST_RATEString = (TextBox)row.Cells[11].FindControl("TxtSGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[10].FindControl("TxtCGSTAmount");
                TextBox SGST_AMTString = (TextBox)row.Cells[12].FindControl("TxtSGSTAmount");
                TextBox T_AMTString = (TextBox)row.Cells[15].FindControl("TxtTotalAmount");
                TextBox IGST_RATEString = (TextBox)row.Cells[13].FindControl("TxtIGSTRate");
                TextBox IGST_AMTString = (TextBox)row.Cells[14].FindControl("TxtIGSTAmount");

                HiddenField HfG_AmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");
                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                if (TxtQuantityString.Text.Trim() != string.Empty && TxtRateString.Text.Trim() != string.Empty)
                {
                    TxtAmountString.Text = Convert.ToString(Convert.ToDouble(TxtQuantityString.Text.Trim()) * Convert.ToDouble(TxtRateString.Text.Trim()));


                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                      
                        CGST_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                        SGST_AMTString.Text = CGST_AMTString.Text;
                        SGST_RATEString.Text = CGST_RATEString.Text;


                        HfGSTRate.Value = Convert.ToString(Convert.ToDouble(CGST_RATEString.Text.Trim()) + Convert.ToDouble(SGST_RATEString.Text.Trim())).ToString();
                        HfGSTAmount.Value = Convert.ToString(Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();

                        IGST_AMTString.Text = "0";
                        IGST_RATEString.Text = "0";

                        double d;
                        d = ((Convert.ToDouble(TxtAmountString.Text.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                        T_AMTString.Text = Convert.ToString(d);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        CGST_AMTString.Text = "0";
                        SGST_AMTString.Text = "0";
                        SGST_AMTString.Text = "0";
                        SGST_RATEString.Text = "0";

                        HfGSTRate.Value = IGST_RATEString.Text;

                        IGST_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Text;
                        T_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();
                    }

                    double lblTotalQty = TotalQuantity_AMC();
                    lblSumTotalAMCQty.Text = lblTotalQty.ToString();

                    double lblTotGamount = TotalGrossAmount_AMC();
                    lblSumTotalAMC_AMT.Text = lblTotGamount.ToString();

                    double lblTotCGSTAmt = TotalCGSTAmount_AMC();
                    lblSumAMCTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                    double lblTotSGSTAmt = TotalSGSTAmount_AMC();
                    lblSumAMCTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                    double lblTotIGSTAmt = TotalIGSTAmount_AMC();
                    lblSumAMCTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                    double lblTotAmount = TotalAmount_AMC();
                    lblSumTotalAMCAmount.Text = lblTotAmount.ToString();

                    if (lblSumTotalAMCAmount.Text == string.Empty)
                    {
                        lblSumTotalAMCAmount.Text = "0";
                        HfGrid_T_Total.Value = "0";
                    }
                    else
                    {
                        ViewState["Total_Quotation_TAMC"] = lblSumTotalAMCAmount.Text.Trim();
                    }

                    FillNetAmount();
                    FillOnGridModelItemDetailChanged();
                }

                else
                {
                    TxtAmountString.Text = Convert.ToString(Convert.ToDouble(0));
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void TxtIGSTRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                Label lblSumTotalAMCQty = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMCQty"));
                Label lblSumTotalAMC_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMC_AMT"));
                Label lblSumAMCTotalCGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalCGST_AMT"));
                Label lblSumAMCTotalSGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalSGST_AMT"));
                Label lblSumAMCTotalIGST_AMT = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumAMCTotalIGST_AMT"));
                Label lblSumTotalAMCAmount = (Label)(GvQuotation_TAMC.FooterRow.FindControl("lblSumTotalAMCAmount"));

                TextBox TxtQuantityString = (TextBox)row.Cells[4].FindControl("TxtQuantity");
                TextBox TxtRateString = (TextBox)row.Cells[5].FindControl("TxtRate");
                TextBox TxtAmountString = (TextBox)row.Cells[8].FindControl("TxtAmount");

                TextBox CGST_RATEString = (TextBox)row.Cells[9].FindControl("TxtCGSTRate");
                TextBox SGST_RATEString = (TextBox)row.Cells[11].FindControl("TxtSGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[10].FindControl("TxtCGSTAmount");
                TextBox SGST_AMTString = (TextBox)row.Cells[12].FindControl("TxtSGSTAmount");
                TextBox T_AMTString = (TextBox)row.Cells[15].FindControl("TxtTotalAmount");
                TextBox IGST_RATEString = (TextBox)row.Cells[13].FindControl("TxtIGSTRate");
                TextBox IGST_AMTString = (TextBox)row.Cells[14].FindControl("TxtIGSTAmount");

                HiddenField HfG_AmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");
                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                if (TxtQuantityString.Text.Trim() != string.Empty && TxtRateString.Text.Trim() != string.Empty)
                {
                    TxtAmountString.Text = Convert.ToString(Convert.ToDouble(TxtQuantityString.Text.Trim()) * Convert.ToDouble(TxtRateString.Text.Trim()));


                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                        SGST_AMTString.Text = CGST_AMTString.Text;
                        SGST_RATEString.Text = CGST_RATEString.Text;
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                        IGST_AMTString.Text = "0";
                        IGST_RATEString.Text = "0";

                        double d;
                        d = ((Convert.ToDouble(TxtAmountString.Text.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                        T_AMTString.Text = Convert.ToString(d);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {

                        CGST_AMTString.Text = "0";
                        CGST_RATEString.Text = "0";
                        SGST_AMTString.Text = "0";
                        SGST_RATEString.Text = "0";

                        IGST_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();

                        HfGSTRate.Value = IGST_RATEString.Text;
                        HfGSTAmount.Value = IGST_AMTString.Text;
                        
                        T_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();
                    }

                    double lblTotalQty = TotalQuantity_AMC();
                    lblSumTotalAMCQty.Text = lblTotalQty.ToString();

                    double lblTotGamount = TotalGrossAmount_AMC();
                    lblSumTotalAMC_AMT.Text = lblTotGamount.ToString();

                    double lblTotCGSTAmt = TotalCGSTAmount_AMC();
                    lblSumAMCTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                    double lblTotSGSTAmt = TotalSGSTAmount_AMC();
                    lblSumAMCTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                    double lblTotIGSTAmt = TotalIGSTAmount_AMC();
                    lblSumAMCTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                    double lblTotAmount = TotalAmount_AMC();
                    lblSumTotalAMCAmount.Text = lblTotAmount.ToString();

                    if (lblSumTotalAMCAmount.Text == string.Empty)
                    {
                        lblSumTotalAMCAmount.Text = "0";
                        HfGrid_T_Total.Value = "0";
                    }
                    else
                    {
                        ViewState["Total_Quotation_TAMC"] = lblSumTotalAMCAmount.Text.Trim();
                    }

                    FillNetAmount();
                    FillOnGridModelItemDetailChanged();
                }
                else
                {
                    TxtAmountString.Text = Convert.ToString(Convert.ToDouble(0));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region GST CALCULATION FOR QUOUATION_C CHARGES

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetChragesName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CHARGES where COMP_CODE=@COMP_CODE and NAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> ChargesNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargesNames.Add(dt.Rows[i][2].ToString());
            }
            return ChargesNames;
        }

        protected void DdlChargesName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl.Parent.Parent;
                int idx = row.RowIndex;

                string c = ddl.SelectedValue;
                HiddenField HfChargesCode = (HiddenField)row.Cells[0].FindControl("HfChargesCode");
                DropDownList DdlChargesName = (DropDownList)row.Cells[2].FindControl("DdlChargesName");
                TextBox TxtRateString = (TextBox)row.Cells[3].FindControl("TxtRate");
                TextBox TxtCGSTRateString = (TextBox)row.Cells[6].FindControl("TxtCGSTRate");
                TextBox TxtSGSTRateString = (TextBox)row.Cells[8].FindControl("TxtSGSTRate");
                TextBox TxtIGSTRateString = (TextBox)row.Cells[10].FindControl("TxtIGSTRate");

                HiddenField HfGSTRateString = (HiddenField)row.Cells[10].FindControl("HfGSTRate");

                if (ddl.SelectedIndex != 0 && DdlPartyType.SelectedIndex != 0)
                {
                    DataTable DsStock = CHARGES_MASLogicLayer.CHARGES_MAS_CHARGES_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(ddl.SelectedValue), DdlPartyType.SelectedValue);
                    if (DsStock.Rows.Count > 0)
                    {
                        TxtRateString.Text = DsStock.Rows[0]["PER"].ToString();
                        HfGSTRateString.Value = DsStock.Rows[0]["GST_RATE"].ToString();
                        TxtCGSTRateString.Text = DsStock.Rows[0]["CGST_RATE"].ToString();
                        TxtSGSTRateString.Text = DsStock.Rows[0]["SGST_RATE"].ToString();
                        TxtIGSTRateString.Text = DsStock.Rows[0]["IGST_RATE"].ToString();
                    }
                    else
                    {
                        TxtRateString.Text = "0";
                        HfGSTRateString.Value = "0";
                        TxtCGSTRateString.Text = "0";
                        TxtSGSTRateString.Text = "0";
                        TxtIGSTRateString.Text = "0";
                    }
                }
                else
                {
                    TxtRateString.Text = "0";
                    HfGSTRateString.Value = "0";
                    TxtCGSTRateString.Text = "0";
                    TxtSGSTRateString.Text = "0";
                    TxtIGSTRateString.Text = "0";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        public void FillOnGridChargesDetailChanged()
        {
            try
            {
                #region Assign TO Charges Grid Table

                int rowIndex = 0;

                if (ViewState["CurrentTable_C"] != null)
                {
                    DataTable dtCurrentTable_C = (DataTable)ViewState["CurrentTable_C"];
                   
                    if (dtCurrentTable_C.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable_C.Rows.Count; i++)
                        {
                            //extract the TextBox values 
                            //TextBox TxtSr = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtSr");

                            Label lblSumTotalCharges_Qty = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalCharges_Qty"));
                            Label lblSumTotalCharge_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalCharge_AMT"));
                            Label lblSumTotalChargesCGST_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalChargesCGST_AMT"));
                            Label lblSumTotalChargesSGST_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalChargesSGST_AMT"));
                            Label lblSumTotalChargesIGST_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalChargesIGST_AMT"));
                            Label lblSumTotalAmount = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalAmount"));

                            HiddenField HfChargesCode = (HiddenField)GvQuotation_C.Rows[rowIndex].Cells[0].FindControl("HfChargesCode");
                            //   DropDownList DdlChargesName = (DropDownList)GvQuotation_C.Rows[rowIndex].Cells[2].FindControl("DdlChargesName");
                            TextBox TxtChargesName = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtChargesName");
                            TextBox TxtRate = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[2].FindControl("TxtRate");
                            TextBox TxtQuantity = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[3].FindControl("TxtQuantity");                  
                            TextBox TxtChargesAmt = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[4].FindControl("TxtChargesAmt");
                            TextBox TxtCGSTRate = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[5].FindControl("TxtCGSTRate");
                            TextBox TxtCGSTAmount = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[6].FindControl("TxtCGSTAmount");
                            TextBox TxtSGSTRate = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[7].FindControl("TxtSGSTRate");
                            TextBox TxtSGSTAmount = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[8].FindControl("TxtSGSTAmount");
                            TextBox TxtIGSTRate = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[09].FindControl("TxtIGSTRate");
                            TextBox TxtIGSTAmount = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[10].FindControl("TxtIGSTAmount");
                            TextBox TxtTotalAmount = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[11].FindControl("TxtTotalAmount");

                            HiddenField HfGSTRate = (HiddenField)GvQuotation_C.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                            HiddenField HfGSTAmount = (HiddenField)GvQuotation_C.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");

                            //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["CCODE"] = HfChargesCode.Value.Trim();
                            dtCurrentTable_C.Rows[i - 1]["QTY"] = TxtQuantity.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["PER"] = TxtRate.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["AMT"] = TxtChargesAmt.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["GST_RATE"] = HfGSTRate.Value.Trim();
                            dtCurrentTable_C.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                            dtCurrentTable_C.Rows[i - 1]["CGST_RATE"] = TxtCGSTRate.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["CGST_AMT"] = TxtCGSTAmount.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["SGST_RATE"] = TxtSGSTRate.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["SGST_AMT"] = TxtSGSTAmount.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["IGST_RATE"] = TxtIGSTRate.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["IGST_AMT"] = TxtIGSTAmount.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["T_AMT"] = TxtTotalAmount.Text.Trim();


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

        protected void TxtChargesName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                //      string c = ddl.SelectedValue;
                HiddenField HfChargesCode = (HiddenField)row.Cells[0].FindControl("HfChargesCode");
                DropDownList DdlChargesName = (DropDownList)row.Cells[2].FindControl("DdlChargesName");
                TextBox TxtRateString = (TextBox)row.Cells[3].FindControl("TxtRate");
                TextBox TxtCGSTRateString = (TextBox)row.Cells[6].FindControl("TxtCGSTRate");
                TextBox TxtSGSTRateString = (TextBox)row.Cells[8].FindControl("TxtSGSTRate");
                TextBox TxtIGSTRateString = (TextBox)row.Cells[10].FindControl("TxtIGSTRate");

                HiddenField HfGSTRateString = (HiddenField)row.Cells[10].FindControl("HfGSTRate");


                DataTable DtChargesName = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtChargesName = CHARGES_MASLogicLayer.GetAllCHARGESDetialsForComapnyWise_DDL(Comp_Code);
                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtChargesName);
                    Dv.RowFilter = "NAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfChargesCode.Value = DtView.Rows[0]["CCODE"].ToString();
                        
                        FillOnGridChargesDetailChanged();

                        if (HfChargesCode.Value != string.Empty && DdlPartyType.SelectedIndex != 0)
                        {
                            DataTable DsStock = CHARGES_MASLogicLayer.CHARGES_MAS_CHARGES_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(HfChargesCode.Value), DdlPartyType.SelectedValue);
                            if (DsStock.Rows.Count > 0)
                            {
                                TxtRateString.Text = DsStock.Rows[0]["PER"].ToString();
                                HfGSTRateString.Value = DsStock.Rows[0]["GST_RATE"].ToString();
                                TxtCGSTRateString.Text = DsStock.Rows[0]["CGST_RATE"].ToString();
                                TxtSGSTRateString.Text = DsStock.Rows[0]["SGST_RATE"].ToString();
                                TxtIGSTRateString.Text = DsStock.Rows[0]["IGST_RATE"].ToString();
                            }
                            else
                            {
                                TxtRateString.Text = "0";
                                HfGSTRateString.Value = "0";
                                TxtCGSTRateString.Text = "0";
                                TxtSGSTRateString.Text = "0";
                                TxtIGSTRateString.Text = "0";
                            }
                        }
                        else
                        {
                            TxtRateString.Text = "0";
                            HfGSTRateString.Value = "0";
                            TxtCGSTRateString.Text = "0";
                            TxtSGSTRateString.Text = "0";
                            TxtIGSTRateString.Text = "0";
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtQuantity1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                Label lblSumTotalCharges_Qty = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalCharges_Qty"));
                Label lblSumTotalCharge_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalCharge_AMT"));
                Label lblSumTotalChargesCGST_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalChargesCGST_AMT"));
                Label lblSumTotalChargesSGST_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalChargesSGST_AMT"));
                Label lblSumTotalChargesIGST_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalChargesIGST_AMT"));
                Label lblSumTotalAmount = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalAmount"));

                TextBox TxtRateString = (TextBox)row.Cells[2].FindControl("TxtRate");
                TextBox TxtAmountString = (TextBox)row.Cells[4].FindControl("TxtChargesAmt");

                TextBox T_AMTString = (TextBox)row.Cells[11].FindControl("TxtTotalAmount");
                TextBox CGST_RATEString = (TextBox)row.Cells[5].FindControl("TxtCGSTRate");
                TextBox SGST_RATEString = (TextBox)row.Cells[7].FindControl("TxtSGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[6].FindControl("TxtCGSTAmount");
                TextBox SGST_AMTString = (TextBox)row.Cells[8].FindControl("TxtSGSTAmount");

                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                if (txt.Text.Trim() != string.Empty && TxtRateString.Text.Trim() != string.Empty)
                {
                    TxtAmountString.Text = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtRateString.Text.Trim()));


                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                        SGST_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                        double d;
                        d = ((Convert.ToDouble(TxtAmountString.Text.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                        T_AMTString.Text = Convert.ToString(d);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        TextBox IGST_RATEString = (TextBox)row.Cells[9].FindControl("TxtIGSTRate");
                        TextBox IGST_AMTString = (TextBox)row.Cells[10].FindControl("TxtIGSTAmount");

                        IGST_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Text;
                        T_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();
                    }

                    double lblTotalQuantity = TotalQuantity_C();
                    lblSumTotalCharges_Qty.Text = lblTotalQuantity.ToString();

                    double lblTotGamount = TotalGrossAmount_C();
                    lblSumTotalCharge_AMT.Text = lblTotGamount.ToString();

                    double lblTotCGSTAmt = TotalCGSTAmount_C();
                    lblSumTotalChargesCGST_AMT.Text = lblTotCGSTAmt.ToString();

                    double lblTotSGSTAmt = TotalSGSTAmount_C();
                    lblSumTotalChargesSGST_AMT.Text = lblTotSGSTAmt.ToString();

                    double lblTotIGSTAmt = TotalIGSTAmount_C();
                    lblSumTotalChargesIGST_AMT.Text = lblTotIGSTAmt.ToString();

                    double lblTotAmount = TotalAmount_C();
                    lblSumTotalAmount.Text = lblTotAmount.ToString();

                    if (lblSumTotalAmount.Text == string.Empty)
                    {
                        lblSumTotalAmount.Text = "0";
                        HfGrid_C_Total.Value = "0";
                    }
                    else
                    {
                        ViewState["Total_Quotation_C"] = lblSumTotalAmount.Text.Trim();

                       // Grid_C_Total = Convert.ToDecimal(lblSumTotalAmount.Text.Trim());
                    }

                    FillNetAmount();
                    FillOnGridChargesDetailChanged();
                }
                else
                {
                    TxtAmountString.Text = Convert.ToString(Convert.ToDouble(0));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void TxtRate_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                Label lblSumTotalCharges_Qty = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalCharges_Qty"));
                Label lblSumTotalCharge_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalCharge_AMT"));
                Label lblSumTotalChargesCGST_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalChargesCGST_AMT"));
                Label lblSumTotalChargesSGST_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalChargesSGST_AMT"));
                Label lblSumTotalChargesIGST_AMT = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalChargesIGST_AMT"));
                Label lblSumTotalAmount = (Label)(GvQuotation_C.FooterRow.FindControl("lblSumTotalAmount"));

                TextBox TxtQuantityString = (TextBox)row.Cells[2].FindControl("TxtQuantity");
                TextBox TxtAmountString = (TextBox)row.Cells[4].FindControl("TxtChargesAmt");

                TextBox T_AMTString = (TextBox)row.Cells[11].FindControl("TxtTotalAmount");
                TextBox CGST_RATEString = (TextBox)row.Cells[5].FindControl("TxtCGSTRate");
                TextBox SGST_RATEString = (TextBox)row.Cells[7].FindControl("TxtSGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[6].FindControl("TxtCGSTAmount");
                TextBox SGST_AMTString = (TextBox)row.Cells[8].FindControl("TxtSGSTAmount");

                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                if (txt.Text.Trim() != string.Empty && TxtQuantityString.Text.Trim() != string.Empty)
                {
                    TxtAmountString.Text = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtQuantityString.Text.Trim()));


                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                        SGST_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                        double d;
                        d = ((Convert.ToDouble(TxtAmountString.Text.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                        T_AMTString.Text = Convert.ToString(d);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        TextBox IGST_RATEString = (TextBox)row.Cells[9].FindControl("TxtIGSTRate");
                        TextBox IGST_AMTString = (TextBox)row.Cells[10].FindControl("TxtIGSTAmount");

                        IGST_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Text;
                        T_AMTString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();
                    }

                    double lblTotalQuantity = TotalQuantity_C();
                    lblSumTotalCharges_Qty.Text = lblTotalQuantity.ToString();

                    double lblTotGamount = TotalGrossAmount_C();
                    lblSumTotalCharge_AMT.Text = lblTotGamount.ToString();

                    double lblTotCGSTAmt = TotalCGSTAmount_C();
                    lblSumTotalChargesCGST_AMT.Text = lblTotCGSTAmt.ToString();

                    double lblTotSGSTAmt = TotalSGSTAmount_C();
                    lblSumTotalChargesSGST_AMT.Text = lblTotSGSTAmt.ToString();

                    double lblTotIGSTAmt = TotalIGSTAmount_C();
                    lblSumTotalChargesIGST_AMT.Text = lblTotIGSTAmt.ToString();

                    double lblTotAmount = TotalAmount_C();
                    lblSumTotalAmount.Text = lblTotAmount.ToString();

                    if (lblSumTotalAmount.Text == string.Empty)
                    {
                        lblSumTotalAmount.Text = "0";
                        HfGrid_C_Total.Value = "0";
                    }
                    else
                    {
                        ViewState["Total_Quotation_C"] = lblSumTotalAmount.Text.Trim();

                       // Grid_C_Total = Convert.ToDecimal(lblSumTotalAmount.Text.Trim());
                    }
                   
                    FillNetAmount();
                    FillOnGridChargesDetailChanged();
                }

                else
                {
                    TxtAmountString.Text = Convert.ToString(Convert.ToDouble(0));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }






        #endregion

        #region SEARCH MODEL DETAILS BUTTON


        protected void BtnSearchModelDetails_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelCopyModelItem", "ShowModelCopyModelItem()", true);
            FillDdlBrandName();
            FillDdlModelNameByBrand();
            //  FillStockModalDetailGrid();
        }

        public void FillDdlBrandName()
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = STOCK_BRANDMASLogicLayer.GetSTOCKBRANDMAS_BrandNameCompanyWiseFor_Ddl(Comp_Code);
                DdlBrandNameCopy.DataSource = Dt;
                DdlBrandNameCopy.DataValueField = "BRAND_CODE";
                DdlBrandNameCopy.DataTextField = "BRAND_NAME";
                DdlBrandNameCopy.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlModelNameByBrand()
        {
            try
            {
                string Brand_Code = DdlBrandNameCopy.SelectedValue;

                DataTable Dt = new DataTable();
                Dt = STOCK_MODELMASLogicLayer.GetSTOCK_MODELMAS_ModelNameBrandWiseFor_Ddl(Brand_Code);
                DdlModelNameCopy.DataSource = Dt;
                DdlModelNameCopy.DataValueField = "MODEL_CODE";
                DdlModelNameCopy.DataTextField = "MODEL_NAME";
                DdlModelNameCopy.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void getModelDescription()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select MODEL_DESC from STOCK_MODELMAS where MODEL_CODE = '" + DdlModelNameCopy.SelectedValue.Trim() + "'", con);
                TxtModelDescrption.Text = cmd.ExecuteScalar().ToString();
                TxtModelDescrption.Enabled = false;
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlBrandNameCopy_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDdlModelNameByBrand();
        }

        protected void DdlModelNameCopy_SelectedIndexChanged(object sender, EventArgs e)
        {
            getModelDescription();

        }

        public void FillStockModalDetailGrid()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = STOCK_MODELDETLogicLayer.GetAllSTOCK_MODELDETDetailByCompany((Session["COMP_CODE"].ToString()));
                GvStockModalDetails.DataSource = Dt;
                GvStockModalDetails.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSearchModelItems_Click(object sender, EventArgs e)
        {
            try
            {
                string COMP_CODE = Session["COMP_CODE"].ToString();
                string MODEL_CODE = DdlModelNameCopy.SelectedValue;

                if (DdlModelNameCopy.SelectedIndex != 0)
                {
                    DataTable Dt = new DataTable();
                    Dt = STOCK_MODELDETLogicLayer.GetAllSTOCK_MODELDETDetailByCompanyAndModelName(COMP_CODE, MODEL_CODE);

                    DataView dv = new DataView(Dt);

                    if (rdBtnMajorItem.Checked == true)
                    {
                        dv.RowFilter = "CHK_MAJOR='" + "true" + "'";
                    }
                    else if (rdBtnNoramlItem.Checked == true)
                    {
                        dv.RowFilter = "CHK_NORMAL='" + "true" + "'";
                    }
                    else
                    {

                    }



                    DataTable DtView = dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        DataTable table = new DataTable();
                        DataRow dr = null;

                        table.Columns.Add("SNAME", typeof(string));
                        table.Columns.Add("SCODE", typeof(string));
                        table.Columns.Add("QTY", typeof(string));
                        table.Columns.Add("CHK_MAJOR", typeof(string));
                        table.Columns.Add("CHK_NORMAL", typeof(string));
                        //   table.Columns.Add("ORD", typeof(string));

                        if (DtView.Rows.Count > 0)
                        {
                            for (int i = 0; i < DtView.Rows.Count; i++)
                            {

                                dr = table.NewRow();

                                dr["SNAME"] = DtView.Rows[i]["SNAME"].ToString();
                                dr["SCODE"] = DtView.Rows[i]["SCODE"].ToString();
                                dr["QTY"] = DtView.Rows[i]["QTY"].ToString();
                                dr["CHK_MAJOR"] = DtView.Rows[i]["CHK_MAJOR"].ToString();
                                dr["CHK_NORMAL"] = DtView.Rows[i]["CHK_NORMAL"].ToString();
                                //        dr["ORD"] = Dt.Rows[i]["ORD"].ToString();

                                table.Rows.Add(dr);
                            }

                            ViewState["CurrentTable"] = table;

                            GvStockModalDetails.DataSource = table;
                            GvStockModalDetails.DataBind();

                            //DivEntry.Visible = true;
                            //DivView.Visible = false;

                        }
                        errorlbl.Text = "";
                    }
                    else
                    {
                        GvStockModalDetails.DataSource = null;
                        GvStockModalDetails.DataBind();
                        errorlbl.Text = "Record not found";
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStockModalDetails_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GvStockModalDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void BtnProcessRecord_Click(object sender, EventArgs e)
        {
            try
            {
                string str = string.Empty;

                foreach (GridViewRow gvrow in GvStockModalDetails.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("ChkSelectItem");
                    if (chk != null & chk.Checked)
                    {

                        string COMP_CODE = Session["COMP_CODE"].ToString();
                        string MODEL_CODE = DdlModelNameCopy.SelectedValue;

                        DataTable Dt = new DataTable();
                        Dt = STOCK_MODELDETLogicLayer.GetAllSTOCK_MODELDETDetailByCompanyAndModelName(COMP_CODE, MODEL_CODE);


                        DataTable table = new DataTable();
                        DataRow dr = null;

                        table.Columns.Add("COMP_CODE", typeof(string));
                        table.Columns.Add("TRAN_DATE", typeof(string));
                        table.Columns.Add("TRAN_NO", typeof(string));
                        table.Columns.Add("SRNO", typeof(string));
                        table.Columns.Add("SCODE", typeof(string));
                        table.Columns.Add("PROD_CODE", typeof(string));
                        table.Columns.Add("QTY", typeof(string));
                        table.Columns.Add("RATE", typeof(string));
                        table.Columns.Add("AMT", typeof(string));
                        table.Columns.Add("DISC_PER", typeof(string));
                        table.Columns.Add("DISC_AMT", typeof(string));
                        table.Columns.Add("ADD_DISC_PER", typeof(string));
                        table.Columns.Add("ADD_DISC_AMT", typeof(string));
                        table.Columns.Add("G_AMT", typeof(string));
                        table.Columns.Add("GST_RATE", typeof(string));
                        table.Columns.Add("GST_AMT", typeof(string));
                        table.Columns.Add("CGST_RATE", typeof(string));
                        table.Columns.Add("CGST_AMT", typeof(string));
                        table.Columns.Add("SGST_RATE", typeof(string));
                        table.Columns.Add("SGST_AMT", typeof(string));
                        table.Columns.Add("IGST_RATE", typeof(string));
                        table.Columns.Add("IGST_AMT", typeof(string));
                        table.Columns.Add("T_AMT", typeof(string));

                        if (Dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < Dt.Rows.Count; i++)
                            {

                                dr = table.NewRow();
                                dr["COMP_CODE"] = Dt.Rows[i]["COMP_CODE"].ToString();
                                dr["SCODE"] = Dt.Rows[i]["SCODE"].ToString();
                                //dr["PROD_CODE"] = Dt.Rows[i]["PROD_CODE"].ToString();
                                dr["QTY"] = "0";
                                dr["RATE"] = Dt.Rows[i]["RATE"].ToString();
                                dr["GST_RATE"] = Dt.Rows[i]["GST_RATE"].ToString();
                                dr["CGST_RATE"] = Dt.Rows[i]["CGST_RATE"].ToString();
                                dr["SGST_RATE"] = Dt.Rows[i]["SGST_RATE"].ToString();
                                dr["IGST_RATE"] = Dt.Rows[i]["IGST_RATE"].ToString();



                                table.Rows.Add(dr);


                            }

                            ViewState["CurrentTable"] = table;

                            GvQuotation_T.DataSource = table;
                            GvQuotation_T.DataBind();

                            TxtBrandName.Text = Dt.Rows[0]["BRAND_NAME"].ToString();
                            TxtModelNo.Text = Dt.Rows[0]["MODEL_NAME"].ToString();

                            DivEntry.Visible = true;
                            DivView.Visible = false;
                        }


                    }
                }

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModelCopyModelItem()", "HideModelCopyModelItem()", true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GvStockModalDetails.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("ChkSelectItem");
                if (chk.Checked == false)
                {
                    chk.Checked = true;
                }
            }
        }

        protected void btnDeSelectAll_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GvStockModalDetails.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("ChkSelectItem");
                if (chk.Checked == true)
                {
                    chk.Checked = false;
                }
            }
        }

        #endregion

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

        #region CONTACT DETAILS BUTTON

        protected void BtnContactDetails_Click(object sender, EventArgs e)
        {

            if (HfACODE.Value == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Must be select Party Name..!!');", true);

            }
            else
            {
                string COMP_CODE = HttpUtility.UrlEncode(encrypt(Session["COMP_CODE"].ToString()));
                string ACODE = HttpUtility.UrlEncode(encrypt(HfACODE.Value));

                if (btnSave.Visible == true)
                {
                    Response.Write("<script>window.open ('PartyContactDetails.aspx?ACODE=" + ACODE + "&COMP_CODE=" + COMP_CODE + "', '_blank');</script>");
                }
                else
                {
                    Response.Write("<script>window.open ('PartyContactDetails.aspx?ACODE=" + ACODE + "&COMP_CODE=" + COMP_CODE + "&Flag=1', '_blank');</script>");
                }
            }

            // Response.Write("<script>window.open ('PartyContactDetails.aspx?ACODE=" + HfACODE.Value + "&COMP_CODE=" + COMP_CODE + "', '_blank');</script>");
        }

        #endregion



        #region SEARCH PARTY MODEL

        protected void BtnSearchPartyModel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelCmpSearchPartyModel", "ShowModelCmpSearchPartyModel()", true);
            FillDdlAccountName();
        }

        protected void TxtAccountNamePopUp_TextChanged(object sender, EventArgs e)
        {

        }

        public void FillDdlAccountName()
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
                DdlAcounntNamePopup.DataSource = Dt;
                DdlAcounntNamePopup.DataValueField = "ACODE";
                DdlAcounntNamePopup.DataTextField = "ANAME";
                DdlAcounntNamePopup.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlModelSrNo()
        {
            try
            {
                string ACODE = DdlAcounntNamePopup.SelectedValue;

                DataTable Dt = new DataTable();
                Dt = PARTY_MODELMASLogicLayer.GetAllPARTY_MODELMASDetailWisePartyName(ACODE);
                DdlModelSrNo.DataSource = Dt;
                DdlModelSrNo.DataValueField = "MODEL_SRNO";
                DdlModelSrNo.DataTextField = "MODEL_SRNOString";
                DdlModelSrNo.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void DdlAcounntNamePopup_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDdlModelSrNo();
        }

        protected void DdlModelSrNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            string ACODE = DdlAcounntNamePopup.SelectedValue;

            DataTable Dt = new DataTable();
            Dt = PARTY_MODELMASLogicLayer.GetAllPARTY_MODELMASDetailWisePartyName(ACODE);

            if (DdlModelSrNo.SelectedIndex != 0)
            {
                DataView Dv = new DataView(Dt);
                Dv.RowFilter = "MODEL_SRNO='" + DdlModelSrNo.SelectedValue.Trim() + "'";
                DataTable DtView = Dv.ToTable();
                if (DtView.Rows.Count > 0)
                {

                    HfSrNo.Value = DtView.Rows[0]["SRNO"].ToString();
                    TxtBrandNamePopUp.Text = DtView.Rows[0]["BRAND_NAME"].ToString();
                    TxtModelNamePopup.Text = DtView.Rows[0]["MODEL_NAME"].ToString();
                    TxtPartySrNo.Text = DtView.Rows[0]["PARTY_SRNO"].ToString();
                    TxtMfgSrNo.Text = DtView.Rows[0]["MFG_SRNO"].ToString();
                    ModelDescription.Text = DtView.Rows[0]["MODEL_REMARK"].ToString();
                    DdlServiceType.SelectedValue = DtView.Rows[0]["SERVICE_TYPE"].ToString();
                }

            }

        }


        protected void BtnPartyModelDetails_Click(object sender, EventArgs e)
        {
            try
            {
                string COMP_CODE = Session["COMP_CODE"].ToString();
                string SRNO = HfSrNo.Value;
                string ACODE = DdlAcounntNamePopup.SelectedValue;

                if (DdlModelSrNo.SelectedIndex != 0 && DdlAcounntNamePopup.SelectedIndex != 0)
                {
                    DataTable Dt = new DataTable();
                    Dt = PARTY_MODELDETLogicLayer.GetAllPARTY_MODELDETDetailByComapnyAndID(COMP_CODE, ACODE, SRNO);


                    DataView dv = new DataView(Dt);

                    if (rdBtnMajorItem1.Checked == true)
                    {
                        dv.RowFilter = "CHK_MAJOR='" + "true" + "'";
                    }
                    else if (rdBtnNormalItem1.Checked == true)
                    {
                        dv.RowFilter = "CHK_NORMAL='" + "true" + "'";
                    }
                    else
                    {

                    }


                    DataTable DtView = dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        DataTable table = new DataTable();
                        DataRow dr = null;

                        table.Columns.Add("SNAME", typeof(string));
                        table.Columns.Add("SCODE", typeof(string));
                        table.Columns.Add("QTY", typeof(string));
                        table.Columns.Add("CHK_MAJOR", typeof(string));
                        table.Columns.Add("CHK_NORMAL", typeof(string));
                        //   table.Columns.Add("ORD", typeof(string));

                        if (DtView.Rows.Count > 0)
                        {
                            for (int i = 0; i < DtView.Rows.Count; i++)
                            {

                                dr = table.NewRow();

                                dr["SNAME"] = DtView.Rows[i]["SNAME"].ToString();
                                dr["SCODE"] = DtView.Rows[i]["SCODE"].ToString();
                                dr["QTY"] = DtView.Rows[i]["QTY"].ToString();
                                dr["CHK_MAJOR"] = DtView.Rows[i]["CHK_MAJOR"].ToString();
                                dr["CHK_NORMAL"] = DtView.Rows[i]["CHK_NORMAL"].ToString();
                                //        dr["ORD"] = Dt.Rows[i]["ORD"].ToString();

                                table.Rows.Add(dr);
                            }

                            ViewState["CurrentTable"] = table;

                            GvPartyModelDetails.DataSource = table;
                            GvPartyModelDetails.DataBind();

                        }
                        LblPartyMOdel.Text = "";
                    }
                    else
                    {
                        GvPartyModelDetails.DataSource = null;
                        GvPartyModelDetails.DataBind();
                        LblPartyMOdel.Text = "Record not found";
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }




        protected void BtnSelectAllRecord_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GvPartyModelDetails.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("ChkSelectItem");
                if (chk.Checked == false)
                {
                    chk.Checked = true;
                }
            }
        }

        protected void BtnDeSelectAllRecord_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GvPartyModelDetails.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("ChkSelectItem");
                if (chk.Checked == false)
                {
                    chk.Checked = false;
                }
            }
        }

        protected void BtnProcessItem_Click(object sender, EventArgs e)
        {
            try
            {
                string str = string.Empty;
                string COMP_CODE = Session["COMP_CODE"].ToString();
                string ACODE = DdlAcounntNamePopup.SelectedValue;
                string SRNO = HfSrNo.Value;
                HfACODE.Value = ACODE;

                DataTable Dt = new DataTable();
                Dt = PARTY_MODELDETLogicLayer.GetAllPARTY_MODELDETDetailByComapnyAndID(COMP_CODE, ACODE, SRNO);


                foreach (GridViewRow gvrow in GvPartyModelDetails.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("ChkSelectItem");
                    if (chk != null & chk.Checked)
                    {

                        DataTable table = new DataTable();
                        DataRow dr = null;

                        table.Columns.Add("COMP_CODE", typeof(string));
                        table.Columns.Add("TRAN_DATE", typeof(string));
                        table.Columns.Add("TRAN_NO", typeof(string));
                        table.Columns.Add("SRNO", typeof(string));
                        table.Columns.Add("SCODE", typeof(string));
                        table.Columns.Add("PROD_CODE", typeof(string));
                        table.Columns.Add("QTY", typeof(string));
                        table.Columns.Add("RATE", typeof(string));
                        table.Columns.Add("AMT", typeof(string));
                        table.Columns.Add("DISC_PER", typeof(string));
                        table.Columns.Add("DISC_AMT", typeof(string));
                        table.Columns.Add("ADD_DISC_PER", typeof(string));
                        table.Columns.Add("ADD_DISC_AMT", typeof(string));
                        table.Columns.Add("G_AMT", typeof(string));
                        table.Columns.Add("GST_RATE", typeof(string));
                        table.Columns.Add("GST_AMT", typeof(string));
                        table.Columns.Add("CGST_RATE", typeof(string));
                        table.Columns.Add("CGST_AMT", typeof(string));
                        table.Columns.Add("SGST_RATE", typeof(string));
                        table.Columns.Add("SGST_AMT", typeof(string));
                        table.Columns.Add("IGST_RATE", typeof(string));
                        table.Columns.Add("IGST_AMT", typeof(string));
                        table.Columns.Add("T_AMT", typeof(string));

                        if (Dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < Dt.Rows.Count; i++)
                            {

                                dr = table.NewRow();
                                dr["COMP_CODE"] = Dt.Rows[i]["COMP_CODE"].ToString();
                                dr["SCODE"] = Dt.Rows[i]["SCODE"].ToString();
                                //dr["PROD_CODE"] = Dt.Rows[i]["PROD_CODE"].ToString();
                                dr["QTY"] = Dt.Rows[i]["QTY"].ToString();
                                dr["RATE"] = Dt.Rows[i]["RATE"].ToString();
                                dr["GST_RATE"] = Dt.Rows[i]["GST_RATE"].ToString();
                                dr["CGST_RATE"] = Dt.Rows[i]["CGST_RATE"].ToString();
                                dr["SGST_RATE"] = Dt.Rows[i]["SGST_RATE"].ToString();
                                dr["IGST_RATE"] = Dt.Rows[i]["IGST_RATE"].ToString();

                                table.Rows.Add(dr);

                            }

                            ViewState["CurrentTable"] = table;

                            GvQuotation_T.DataSource = table;
                            GvQuotation_T.DataBind();
                        }

                    }

                }

                if (Dt.Rows.Count > 0)
                {
                    TxtAccountName.Text = Dt.Rows[0]["ANAME"].ToString();
                    TxtBrandName.Text = Dt.Rows[0]["BRAND_NAME"].ToString();
                    TxtModelNo.Text = Dt.Rows[0]["MODEL_NAME"].ToString();
                }
                else
                {
                    TxtAccountName.Text = string.Empty;
                    TxtBrandName.Text = string.Empty;
                    TxtModelNo.Text = string.Empty;
                }

                FillDdlKindAttn();
                FillDdlAccountPartyType();
                FillDdlAccountSalesType();
                FillDdlAccountCSTType();

                DivEntry.Visible = true;
                DivView.Visible = false;

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModelCopyModelItem()", "HideModelCopyModelItem()", true);
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvPartyModelDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvPartyModelDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }






        #endregion

        protected void btnFillDiscount_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GvQuotation_T.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)

                {

                    TextBox txtDisBox = (TextBox)row.FindControl("TxtDisRate");
                    txtDisBox.Text = TxtFillDiscount.Text;

                }
            }
        }

        protected void btnqitem_Click(object sender, EventArgs e)
        {
           string QUO_TYPE =Session["QUO_TYPE"].ToString();
            Session["isSpecification"]=DdlSpecificationRst.SelectedValue;

            if(QUO_TYPE == "I")
            {
              //  Response.Redirect("~/reportviewPages/Quotation_Item_Print.aspx");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../reportviewPages/Quotation_Item_Print.aspx', '_blank');", true);
            }
            else
            {
             //   Response.Redirect("~/reportviewPages/Quotation_Amc_Print.aspx");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../reportviewPages/Quotation_Amc_Print.aspx', '_blank');", true);
            }
           
        }

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtSearch.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtSearch);
                    Dv.RowFilter = "PARTY_NAME like '%" + TxtSearch.Text.Trim() + "%' OR Convert(QUO_NO,'System.String') like '%" + TxtSearch.Text.Trim() + "%' OR quo_type like '%" + TxtSearch.Text.Trim() + "%' OR BrokerName Like '%" + TxtSearch.Text.Trim() + "%' OR BRAND_NAME Like '%" + TxtSearch.Text.Trim() + "%' OR MODEL_NAME Like '%" + TxtSearch.Text.Trim() + " ' ";
                    GvQuotation_M.DataSource = Dv.ToTable();
                    GvQuotation_M.DataBind();
                }
                else
                {
                    GvQuotation_M.DataSource = DtSearch;
                    GvQuotation_M.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                FillDdlKindAttn();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}