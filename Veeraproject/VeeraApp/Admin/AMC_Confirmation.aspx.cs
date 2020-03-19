using System;
using MihirValid;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;
using System.Text;
using System.Security.Cryptography;

namespace VeeraApp.Admin
{
    public partial class AMC_Confirmation : System.Web.UI.Page
    {
        public static string compcode;
        static DataTable DtSearch = new DataTable();
        public static string Branchcode;
        public static string Acode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERCODE"] != null &&
           Session["USERNAME"] != null &&
           Session["USERTYPE"] != null &&
           Session["COMP_CODE"] != null &&
           Session["COMP_NAME"] != null &&
            Session["WORK_VIEWFLAG"] != null &&
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
                if (!IsPostBack == true)
                {
                    DivEntry.Visible = false;
                    DivView.Visible = true;

                    if (!string.IsNullOrWhiteSpace(Request.QueryString["AMC_TYPE"])==true)
                    {
                        HfAMC_TYPE.Value = Request.QueryString["AMC_TYPE"];
                    }
                    else                   
                    if (!string.IsNullOrWhiteSpace(Request.QueryString["JOBCARD"]) && !string.IsNullOrWhiteSpace(Request.QueryString["AMCTYPE"]))
                    {
                        string JOBCARDMASTER = HttpUtility.UrlDecode(Decrypt(Request.QueryString["JOBCARD"]));
                        HfAMC_TYPE.Value= HttpUtility.UrlDecode(Decrypt(Request.QueryString["AMCTYPE"]));


                        clear();
                        ControllerEnable();
                        UserRights();
                        Btncalldel.Visible = false;
                        BtncallUpd.Visible = true;
                        btnSave.Enabled = true;
                        btnSave.Visible = true;
                        DivEntry.Visible = true;
                        DivView.Visible = false;
                        TxtAMCDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");



                        string AMC_NO = AMC_MASLogicLayer.GetAmcNumber_AMC_MASCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtAMCDate.Text.Trim()).ToString("yyyy-MM-dd"), HfAMC_TYPE.Value.ToString());
                        if (AMC_NO.Length <= 8)
                        {
                            TxtAMCNo.Text = AMC_NO;
                        }
                        else
                        {
                            TxtAMCNo.Text = string.Empty;
                        }


                      




                        if (!string.IsNullOrWhiteSpace(Request.QueryString["Flag"]))
                        {
                            if (Request.QueryString["Flag"].ToString() == "1")
                            {



                                btnSave.Visible = false;
                                ControllerDisable();
                            }
                        }
                    }

                    

                    FillAMCMasterGrid(Session["COMP_CODE"].ToString());
                    CalendarExtenderAMCDate.StartDate = Convert.ToDateTime(Session["FIN_YEAR"].ToString());
                    CalendarExtenderAMCDate.EndDate = Convert.ToDateTime(Session["FIN_YEAR_END"].ToString());

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
                        // btnSave.Enabled = true;
                    }
                    else
                    {
                        // btnSave.Enabled = false;
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





     
        

        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfCompCode.Value = string.Empty;
            HfBranchCode.Value = string.Empty;
            HfTranDate.Value = string.Empty;
            HfTranNo.Value = string.Empty;
            HfACODE.Value = string.Empty;

            TxtAMCNo.Text = string.Empty;
            TxtAMCDate.Text = string.Empty;
            TxtPartyName.Text = string.Empty;
            //  DdlKindAttn.SelectedIndex = 0;
            TxtConatctPhone.Text = string.Empty;
            TxtContactEmail.Text = string.Empty;
            TxtAMCStartDate.Text = string.Empty;
            TxtAMCEndDate.Text = string.Empty;
            TxtMaxVisitNo.Text = string.Empty;
            DdlAMCBillingTerm.SelectedIndex = 0;
            TxtContactPersonName1.Text = string.Empty;
            TxtContactPersonName2.Text = string.Empty;
            TxtContactPersonName3.Text = string.Empty;
            TxtContactPersonName4.Text = string.Empty;
            TxtContactPriority1.Text = string.Empty;
            TxtContactPriority2.Text = string.Empty;
            TxtContactPriority3.Text = string.Empty;
            TxtContactPriority4.Text = string.Empty;
            TxtPreparedPersonName.Text = string.Empty;
            TxtRemark.Text = string.Empty;
            DdlChecked.SelectedValue = "N";
            TxtCheckedBy.Text = string.Empty;
            TxtCheckedDate.Text = string.Empty;
            DdlClosed.SelectedValue = "N";
            TxtClosedBy.Text = string.Empty;
            TxtClosedDate.Text = string.Empty;
            TxtLastAMCDate.Text = string.Empty;
            TxtLastAMCNo.Text = string.Empty;

            BtncallUpd.Text = "SAVE";

         //   ViewState["CurrentTable"] = null;

            SetInitialRow();
        }

        public void ControllerEnable()
        {
            TxtAMCNo.Enabled = false;
            TxtAMCDate.Enabled = true;
            TxtPartyName.Enabled = true;
            DdlKindAttn.Enabled = true;
            TxtConatctPhone.Enabled = true;
            TxtContactEmail.Enabled = true;
            TxtAMCStartDate.Enabled = true;
            TxtAMCEndDate.Enabled = true;
            TxtMaxVisitNo.Enabled = true;
            DdlAMCBillingTerm.Enabled = true;
            TxtContactPersonName1.Enabled = true;
            TxtContactPersonName2.Enabled = true;
            TxtContactPersonName3.Enabled = true;
            TxtContactPersonName4.Enabled = true;
            TxtContactPriority1.Enabled = true;
            TxtContactPriority2.Enabled = true;
            TxtContactPriority3.Enabled = true;
            TxtContactPriority4.Enabled = true;
            TxtPreparedPersonName.Enabled = true;
            TxtRemark.Enabled = true;
            DdlChecked.Enabled = true;
            TxtCheckedBy.Enabled = true;
            TxtCheckedDate.Enabled = true;
            DdlClosed.Enabled = true;
            TxtClosedBy.Enabled = true;
            TxtClosedDate.Enabled = true;
            TxtLastAMCDate.Enabled = true;
            TxtLastAMCNo.Enabled = true;
        }

        public void ControllerDisable()
        {
            TxtAMCNo.Enabled = false;
            TxtAMCDate.Enabled = false;
            TxtPartyName.Enabled = false;
            DdlKindAttn.Enabled = false;
            TxtConatctPhone.Enabled = false;
            TxtContactEmail.Enabled = false;
            TxtAMCStartDate.Enabled = false;
            TxtAMCEndDate.Enabled = false;
            TxtMaxVisitNo.Enabled = false;
            DdlAMCBillingTerm.Enabled = false;
            TxtContactPersonName1.Enabled = false;
            TxtContactPersonName2.Enabled = false;
            TxtContactPersonName3.Enabled = false;
            TxtContactPersonName4.Enabled = false;
            TxtContactPriority1.Enabled = false;
            TxtContactPriority2.Enabled = false;
            TxtContactPriority3.Enabled = false;
            TxtContactPriority4.Enabled = false;
            TxtPreparedPersonName.Enabled = false;
            TxtRemark.Enabled = false;
            DdlChecked.Enabled = false;
            TxtCheckedBy.Enabled = false;
            TxtCheckedDate.Enabled = false;
            DdlClosed.Enabled = false;
            TxtClosedBy.Enabled = false;
            TxtClosedDate.Enabled = false;
            TxtLastAMCDate.Enabled = false;
            TxtLastAMCNo.Enabled = false;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetAccountName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ACCOUNTS where COMP_CODE=@COMP_CODE AND BRANCH_CODE=@BRANCH_CODE  AND ANAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            cmd.Parameters.AddWithValue("@BRANCH_CODE", Branchcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> ANames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ANames.Add(dt.Rows[i][2].ToString());
            }
            return ANames;
        }


        protected void TxtPartyName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select ACODE from ACCOUNTS where ANAME = '" + TxtPartyName.Text + "'and COMP_CODE = " + Session["COMP_CODE"].ToString(), con);
                int x = Convert.ToInt32(cmd.ExecuteScalar());
                HfACODE.Value = string.Empty;
                if (x == 0)
                {
                    TxtPartyName.BackColor = Color.Red;
                }
                else
                {
                    HfACODE.Value = cmd.ExecuteScalar().ToString();
                    Acode = HfACODE.Value;
                    TxtPartyName.BackColor = Color.White;
                }

                con.Close();

                FillDdlKindAttn();

            }
            catch (Exception)
            {

                throw;
            }
        }

        #region CONTACT DETAILS BUTTON

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

        protected void DdlKindAttn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                getContactPersonPhoneNo();
                getContactPersonEmail();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void getContactPersonPhoneNo()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select PHONE_NO from ACCOUNTS_DET where CONTACT_NAME = '" + DdlKindAttn.SelectedItem.ToString() + "' and ACODE = " + HfACODE.Value.ToString(), con);
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
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select MAIL_ID from ACCOUNTS_DET where CONTACT_NAME = '" + DdlKindAttn.SelectedItem.ToString() + "' and ACODE = " + HfACODE.Value.ToString(), con);
                TxtContactEmail.Text = cmd.ExecuteScalar().ToString();
                TxtContactEmail.Enabled = false;
                con.Close();
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



        #endregion


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetServicePersonName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from BROKER where COMP_CODE=@COMP_CODE and BRANCH_CODE=@BRANCH_CODE and BNAME like @BNAME + '%'", con);
            cmd.Parameters.AddWithValue("@BNAME", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            cmd.Parameters.AddWithValue("@BRANCH_CODE", Branchcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> BrokerName = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BrokerName.Add(dt.Rows[i][3].ToString());
            }
            return BrokerName;
        }

        #region ADD NEW ROW TO AMC DETAILS GRID


        private void SetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("ACODE", typeof(string));
            table.Columns.Add("PARTY_REFSRNO", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("RATE", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("MODEL_SRNO", typeof(string));
            table.Columns.Add("PARTY_SRNO", typeof(string));
            table.Columns.Add("MFG_SRNO", typeof(string));
            table.Columns.Add("BRAND_NAME", typeof(string));
            table.Columns.Add("BRANDTYPE_NAME", typeof(string));
            table.Columns.Add("MODEL_NAME", typeof(string));


            dr = table.NewRow();

            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["ACODE"] = string.Empty;
            dr["PARTY_REFSRNO"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["RATE"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["MODEL_SRNO"] = string.Empty;
            dr["PARTY_SRNO"] = string.Empty;
            dr["MFG_SRNO"] = string.Empty;
            dr["BRAND_NAME"] = string.Empty;
            dr["BRANDTYPE_NAME"] = string.Empty;
            dr["MODEL_NAME"] = string.Empty;

            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvAMCDetails.DataSource = table;
            GvAMCDetails.DataBind();
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
                        //TextBox TxtSr = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtSr");

                        HiddenField HfCompCode = (HiddenField)GvAMCDetails.Rows[rowIndex].Cells[0].FindControl("HfCompCode");
                        HiddenField HfTranDate = (HiddenField)GvAMCDetails.Rows[rowIndex].Cells[0].FindControl("HfTranDate");
                        HiddenField HfTranNo = (HiddenField)GvAMCDetails.Rows[rowIndex].Cells[0].FindControl("HfTranNo");
                        HiddenField HfSrNo = (HiddenField)GvAMCDetails.Rows[rowIndex].Cells[0].FindControl("HfSrNo");
                        HiddenField HfACODE = (HiddenField)GvAMCDetails.Rows[rowIndex].Cells[0].FindControl("HfACODE");
                        HiddenField HfPartyRefSrNo = (HiddenField)GvAMCDetails.Rows[rowIndex].Cells[0].FindControl("HfPartyRefSrNo");



                        TextBox TxtPartyModelSrNo = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[1].FindControl("TxtPartyModelSrNo");
                        TextBox TxtPartySrNo = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[2].FindControl("TxtPartySrNo");
                        TextBox TxtMfgSrNo = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[3].FindControl("TxtMfgSrNo");
                        TextBox TxtBrandName = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[4].FindControl("TxtBrandName");
                        TextBox TxtBrandTypeName = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[5].FindControl("TxtBrandTypeName");
                        TextBox TxtModelName = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[6].FindControl("TxtModelName");
                        TextBox TxtQty = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[7].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[8].FindControl("TxtRate");
                        TextBox TxtAmount = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[9].FindControl("TxtAmount");




                        //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["ACODE"] = HfACODE.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["PARTY_REFSRNO"] = HfPartyRefSrNo.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = TxtAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["MODEL_SRNO"] = TxtPartyModelSrNo.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["PARTY_SRNO"] = TxtPartySrNo.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["MFG_SRNO"] = TxtMfgSrNo.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["BRAND_NAME"] = TxtBrandName.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["BRANDTYPE_NAME"] = TxtBrandTypeName.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["MODEL_NAME"] = TxtModelName.Text.Trim();

                        rowIndex++;

                    }


                    drCurrentRow = dtCurrentTable.NewRow();

                    //drCurrentRow["SR"] = "";
                    drCurrentRow["ACODE"] = "0";
                    drCurrentRow["PARTY_REFSRNO"] = "0";
                    drCurrentRow["RATE"] = "0";
                    drCurrentRow["QTY"] = "0";
                    drCurrentRow["AMT"] = "0";
                    drCurrentRow["MODEL_SRNO"] = "0";
                    drCurrentRow["PARTY_SRNO"] = "0";
                    drCurrentRow["MFG_SRNO"] = "0";
                    drCurrentRow["BRAND_NAME"] = "";
                    drCurrentRow["BRANDTYPE_NAME"] = "";
                    drCurrentRow["MODEL_NAME"] = "";

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvAMCDetails.DataSource = dtCurrentTable;
                    GvAMCDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousDataToGrid();
        }

        private void SetPreviousDataToGrid()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        HiddenField HfCompCode = (HiddenField)GvAMCDetails.Rows[rowIndex].Cells[0].FindControl("HfCompCode");
                        HiddenField HfTranDate = (HiddenField)GvAMCDetails.Rows[rowIndex].Cells[0].FindControl("HfTranDate");
                        HiddenField HfTranNo = (HiddenField)GvAMCDetails.Rows[rowIndex].Cells[0].FindControl("HfTranNo");
                        HiddenField HfSrNo = (HiddenField)GvAMCDetails.Rows[rowIndex].Cells[0].FindControl("HfSrNo");
                        HiddenField HfACODE = (HiddenField)GvAMCDetails.Rows[rowIndex].Cells[0].FindControl("HfACODE");
                        HiddenField HfPartyRefSrNo = (HiddenField)GvAMCDetails.Rows[rowIndex].Cells[0].FindControl("HfPartyRefSrNo");



                        TextBox TxtPartyModelSrNo = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[1].FindControl("TxtPartyModelSrNo");
                        TextBox TxtPartySrNo = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[2].FindControl("TxtPartySrNo");
                        TextBox TxtMfgSrNo = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[3].FindControl("TxtMfgSrNo");
                        TextBox TxtBrandName = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[4].FindControl("TxtBrandName");
                        TextBox TxtBrandTypeName = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[5].FindControl("TxtBrandTypeName");
                        TextBox TxtModelName = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[6].FindControl("TxtModelName");
                        TextBox TxtQty = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[7].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[8].FindControl("TxtRate");
                        TextBox TxtAmount = (TextBox)GvAMCDetails.Rows[rowIndex].Cells[9].FindControl("TxtAmount");



                        HfACODE.Value = dt.Rows[i]["ACODE"].ToString();
                        HfPartyRefSrNo.Value = dt.Rows[i]["PARTY_REFSRNO"].ToString();
                        TxtQty.Text = dt.Rows[i]["QTY"].ToString();
                        TxtRate.Text = dt.Rows[i]["RATE"].ToString();
                        TxtAmount.Text = dt.Rows[i]["AMT"].ToString();
                        TxtPartyModelSrNo.Text = dt.Rows[i]["MODEL_SRNO"].ToString();
                        TxtPartySrNo.Text = dt.Rows[i]["PARTY_SRNO"].ToString();
                        TxtMfgSrNo.Text = dt.Rows[i]["MFG_SRNO"].ToString();
                        TxtBrandName.Text = dt.Rows[i]["BRAND_NAME"].ToString();
                        TxtBrandTypeName.Text = dt.Rows[i]["BRANDTYPE_NAME"].ToString();
                        TxtModelName.Text = dt.Rows[i]["MODEL_NAME"].ToString();

                        rowIndex++;

                    }
                }
            }
        }


        protected void BtnDeleteRowModelStockDetailGrid_Click(object sender, EventArgs e)
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
                GvAMCDetails.DataSource = dt;
                GvAMCDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousDataToGrid();
        }

        protected void BtnAddRowModelStockDetailGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }


        #endregion


        protected void TxtContactPersonName1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtContactPersonName1.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtContactPersonName1.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfContactPerson1.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtContactPersonName2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtContactPersonName2.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtContactPersonName2.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfContactPerson2.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtContactPersonName3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtContactPersonName3.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtContactPersonName3.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfContactPerson3.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtContactPersonName4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtContactPersonName4.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtContactPersonName4.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfContactPerson4.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtPreparedPersonName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtPreparedPersonName.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtPreparedPersonName.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfPreparedPersonBy.Value = DtView.Rows[0]["BCODE"].ToString();
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
        public static List<string> GetPartyModelSrNo(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from PARTY_MODELMAS where COMP_CODE=@COMP_CODE and ACODE=@ACODE and MODEL_SRNO like @MODEL_SRNO + '%'", con);
            cmd.Parameters.AddWithValue("@MODEL_SRNO", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            cmd.Parameters.AddWithValue("@ACODE", Acode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> PartyModelSrNo = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PartyModelSrNo.Add(dt.Rows[i][4].ToString());
            }
            return PartyModelSrNo;
        }


        protected void GvAMCDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField HfACODEGrid = (e.Row.FindControl("HfACODE") as HiddenField);
                    HiddenField HfPartyRefSrNo = (e.Row.FindControl("HfPartyRefSrNo") as HiddenField);
                    TextBox TxtPartyModelSrNo = (e.Row.FindControl("TxtPartyModelSrNo") as TextBox);
                    TextBox TxtPartySrNo = (e.Row.FindControl("TxtPartySrNo") as TextBox);
                    TextBox TxtMfgSrNo = (e.Row.FindControl("TxtMfgSrNo") as TextBox);
                    TextBox TxtBrandName = (e.Row.FindControl("TxtBrandName") as TextBox);
                    TextBox TxtBrandTypeName = (e.Row.FindControl("TxtBrandTypeName") as TextBox);
                    TextBox TxtModelName = (e.Row.FindControl("TxtModelName") as TextBox);


                    DataTable Dt = new DataTable();

                    Dt = PARTY_MODELMASLogicLayer.GetAllIDWisePARTY_MODELMASDetailForDC(HfPartyRefSrNo.Value);


                    if (HfPartyRefSrNo.Value != "0" && HfPartyRefSrNo.Value != string.Empty)
                    {
                        DataView Dv = new DataView(Dt);
                        Dv.RowFilter = "SRNO=" + HfPartyRefSrNo.Value;
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            //HfPartyRefSrNo.Value = DtView.Rows[0]["PARTY_REFSRNO"].ToString();
                            TxtPartyModelSrNo.Text = DtView.Rows[0]["MODEL_SRNO"].ToString();
                            TxtPartySrNo.Text = DtView.Rows[0]["PARTY_SRNO"].ToString();
                            TxtMfgSrNo.Text = DtView.Rows[0]["MFG_SRNO"].ToString();
                            TxtBrandTypeName.Text = DtView.Rows[0]["BRANDTYPE_NAME"].ToString();
                            TxtBrandName.Text = DtView.Rows[0]["BRAND_NAME"].ToString();
                            TxtModelName.Text = DtView.Rows[0]["MODEL_NAME"].ToString();



                        }
                        else
                        {
                            //  HfPartyRefSrNo.Value = string.Empty;
                            TxtPartyModelSrNo.Text = string.Empty;
                            TxtPartySrNo.Text = string.Empty;
                            TxtMfgSrNo.Text = string.Empty;
                            TxtBrandTypeName.Text = string.Empty;
                            TxtBrandName.Text = string.Empty;
                            TxtModelName.Text = string.Empty;

                        }
                    }

                }
            }



            catch (Exception)
            {

                throw;
            }
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
                TxtAMCDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                BtnBillingDetails.Enabled = false;

             

                string AMC_NO = AMC_MASLogicLayer.GetAmcNumber_AMC_MASCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtAMCDate.Text.Trim()).ToString("yyyy-MM-dd"), HfAMC_TYPE.Value.ToString());
                if (AMC_NO.Length <= 8)
                {
                    TxtAMCNo.Text = AMC_NO;
                }
                else
                {
                    TxtAMCNo.Text = string.Empty;
                }


                SetInitialRow();

            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void TxtAMCDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string AMC_NO = AMC_MASLogicLayer.GetAmcNumber_AMC_MASCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtAMCDate.Text.Trim()).ToString("yyyy-MM-dd"), HfAMC_TYPE.Value.ToString());
                if (AMC_NO.Length <= 8)
                {
                    TxtAMCNo.Text = AMC_NO;
                }
                else
                {
                    TxtAMCNo.Text = string.Empty;
                }
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

        public void FillAMCMasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = AMC_MASLogicLayer.GetAllAMC_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvAMCMaster.DataSource = Dv.ToTable();
            GvAMCMaster.DataBind();

            DtSearch = Dv.ToTable();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region INSERT DATA INTO AMC MASTER

                AMC_MASLogicLayer insert = new AMC_MASLogicLayer();

                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.BRANCH_CODE = HfBranchCode.Value.Trim();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.AMC_NO = TxtAMCNo.Text.Trim();
                insert.AMC_DATE = Convert.ToDateTime(TxtAMCDate.Text.Trim()).ToString("MM-dd-yyyy");
                insert.ACODE = HfACODE.Value.Trim();
                insert.CONTACT_PERSON = DdlKindAttn.SelectedValue.Trim().ToUpper();
                insert.CONTACT_PHONE = TxtConatctPhone.Text.Trim();
                insert.CONTACT_EMAIL = TxtContactEmail.Text.Trim();
                insert.AMC_FRDT = Convert.ToDateTime(TxtAMCStartDate.Text.Trim()).ToString("MM-dd-yyyy");
                insert.AMC_TODT = Convert.ToDateTime(TxtAMCEndDate.Text.Trim()).ToString("MM-dd-yyyy");
                insert.MAX_VISIT = TxtMaxVisitNo.Text.Trim();
                insert.BILL_TERMS = DdlAMCBillingTerm.SelectedValue.Trim().ToString();

                if (TxtContactPersonName1.Text == string.Empty)
                {
                    insert.ASSIGN_BCODE1 = null;
                }
                else
                {
                    insert.ASSIGN_BCODE1 = HfContactPerson1.Value.Trim();
                }

                if (TxtContactPersonName2.Text == string.Empty)
                {
                    insert.ASSIGN_BCODE2 = null;
                }
                else
                {
                    insert.ASSIGN_BCODE2 = HfContactPerson2.Value.Trim();
                }

                if (TxtContactPersonName3.Text == string.Empty)
                {
                    insert.ASSIGN_BCODE3 = null;
                }
                else
                {
                    insert.ASSIGN_BCODE3 = HfContactPerson3.Value.Trim();
                }

                if (TxtContactPersonName4.Text == string.Empty)
                {
                    insert.ASSIGN_BCODE4 = null;
                }
                else
                {
                    insert.ASSIGN_BCODE4 = HfContactPerson4.Value.Trim();
                }

                if (TxtContactPriority1.Text == string.Empty)
                {
                    insert.ASSIGN_BCODE1_P = null;
                }
                else
                {
                    insert.ASSIGN_BCODE1_P = TxtContactPriority1.Text.Trim();
                }

                if (TxtContactPriority2.Text == string.Empty)
                {
                    insert.ASSIGN_BCODE2_P = null;
                }
                else
                {
                    insert.ASSIGN_BCODE2_P = TxtContactPriority2.Text.Trim();
                }

                if (TxtContactPriority3.Text == string.Empty)
                {
                    insert.ASSIGN_BCODE3_P = null;
                }
                else
                {
                    insert.ASSIGN_BCODE3_P = TxtContactPriority3.Text.Trim();
                }

                if (TxtContactPriority4.Text == string.Empty)
                {
                    insert.ASSIGN_BCODE4_P = null;
                }
                else
                {
                    insert.ASSIGN_BCODE4_P = TxtContactPriority4.Text.Trim();
                }

                if (TxtPreparedPersonName.Text == string.Empty)
                {
                    insert.BCODE = null;
                }
                else
                {
                    insert.BCODE = HfPreparedPersonBy.Value.Trim();
                }

                insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                //insert.INS_USERID = Session["USERNAME"].ToString();
                //insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_DATE = "";
                insert.CLOSE_FLAG = DdlClosed.SelectedValue.Trim().ToUpper();
                if (DdlClosed.SelectedValue.ToString() == "Y")
                {
                    insert.CLOSE_DATE = Convert.ToDateTime(TxtClosedDate.Text.Trim()).ToString("MM-dd-yyyy");
                }

                if (DdlClosed.SelectedValue.ToString() == "Y")
                {
                    insert.CLOSE_USERID = TxtClosedBy.Text.Trim().ToUpper();
                }

                insert.CHK_FLAG = DdlChecked.SelectedValue.Trim().ToString();
                if (DdlChecked.SelectedValue.ToString() == "Y")
                {
                    insert.CHK_DATE = Convert.ToDateTime(TxtCheckedDate.Text.Trim()).ToString("MM-dd-yyyy");
                }
                if (DdlChecked.SelectedValue.ToString() == "Y")
                {
                    insert.CHK_USERID = TxtCheckedBy.Text.Trim().ToUpper();
                }

                insert.AMC_TYPE = HfAMC_TYPE.Value.ToString();
                insert.INV_TRAN_DATE = null;
                insert.INV_TRAN_NO = null;
                insert.AMC_TRAN_DATE = null;
                insert.AMC_TRAN_NO = null;
                insert.SERVICE_START_DATE = null;
                insert.BILL_START_DATE = null;

                #endregion

                #region INSERT INTO AMC DETAILS GRID

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);
                int SRNO = 1;

                foreach (GridViewRow row in GvAMCDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                        HiddenField HfTranNo = row.FindControl("HfTranNo") as HiddenField;
                        HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                        HiddenField HfACODE = row.FindControl("HfACODE") as HiddenField;
                        HiddenField HfPartyRefSrNo = row.FindControl("HfPartyRefSrNo") as HiddenField;

                        TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                        TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                        TextBox TxtAmount = row.FindControl("TxtAmount") as TextBox;

                        if (TxtPartyName.Text != string.Empty && TxtPartyName.Text != null)
                        {


                            XmlElement HandleDetail2 = XDoc1.CreateElement("AMCDetails");

                            HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                            HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                            HandleDetail2.SetAttribute("SRNO", SRNO.ToString());

                            if (TxtPartyName.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("ACODE", null);
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("ACODE", (HfACODE.Value));
                            }

                            if (HfPartyRefSrNo.Value != string.Empty)
                            {
                                HandleDetail2.SetAttribute("PARTY_REFSRNO", (HfPartyRefSrNo.Value.Trim()));
                            }

                            if (TxtQty.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("QTY", (TxtQty.Text.Trim()));
                            }

                            if (TxtRate.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("RATE", (TxtRate.Text.Trim()));
                            }

                            if (TxtAmount.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("AMT", (TxtAmount.Text.Trim()));
                            }

                            root1.AppendChild(HandleDetail2);
                            SRNO++;
                        }
                    }

                }

                #endregion

                #region INSERT INTO SERVICE DETAILS GRID


                //    XmlDocument XDoc2 = new XmlDocument();
                //    XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                //    XDoc1.AppendChild(dec1);// Create the root element
                //    XmlElement root2 = XDoc2.CreateElement("root");
                //    XDoc1.AppendChild(root2);
                //    int SUBSRNO = 1;

                //    foreach (GridViewRow row in GvServiceBillDetails.Rows)
                //    {
                //        if (row.RowType == DataControlRowType.DataRow)
                //        {

                //        HiddenField HfCompcode = row.FindControl("HfCompcode") as HiddenField;
                //        HiddenField HfServiceTranDate = row.FindControl("HfServiceTranDate") as HiddenField;
                //        HiddenField HfServiceTranNo = row.FindControl("HfServiceTranNo") as HiddenField;
                //        HiddenField HfServiceSrNo = row.FindControl("HfServiceSrNo") as HiddenField;

                //        TextBox TxtFromDate = row.FindControl("TxtFromDate") as TextBox;
                //        TextBox TxtToDate = row.FindControl("TxtToDate") as TextBox;
                //        TextBox TxtServiceDate = row.FindControl("TxtServiceDate") as TextBox;
                //        TextBox TxtJobCardNo = row.FindControl("TxtJobCardNo") as TextBox;
                //        DropDownList DdlServiceStatus = row.FindControl("DdlServiceStatus") as DropDownList;

                //        XmlElement HandleServiceDetail = XDoc2.CreateElement("ServiceDetails");

                //        //HandleServiceDetail.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                //        //HandleServiceDetail.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                //        //HandleServiceDetail.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                //        //HandleServiceDetail.SetAttribute("SRNO", SRNO.ToString());

                //        HandleServiceDetail.SetAttribute("SUBSRNO", SUBSRNO.ToString());
                //        HandleServiceDetail.SetAttribute("FRDT", TxtFromDate.Text.Trim());
                //        HandleServiceDetail.SetAttribute("TODT", TxtToDate.Text.Trim());
                //        HandleServiceDetail.SetAttribute("JOBCARD_TRAN_DATE", null);
                //        HandleServiceDetail.SetAttribute("JOBCARD_TRAN_NO",null);
                //        HandleServiceDetail.SetAttribute("JOBCARD_NO", TxtJobCardNo.Text.Trim());
                //        HandleServiceDetail.SetAttribute("JOBSTART_DATE", TxtServiceDate.Text.Trim());
                //        HandleServiceDetail.SetAttribute("STATUS", DdlServiceStatus.SelectedValue.Trim());
                //        HandleServiceDetail.SetAttribute("AUTO_RECORD", null);

                //        root1.AppendChild(HandleServiceDetail);
                //        SUBSRNO++;



                //    }
                // }

                 #endregion

                   string str = AMC_MASLogicLayer.UpdateAMC_MASDetail(insert,validation.RSC(XDoc1.OuterXml));

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "AMC MASTER UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillAMCMasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "AMC MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : AMC MASTER NOT UPDATED";
                        lblmsg.ForeColor = Color.Red;

                    }
                
              
            }
            catch (Exception ex)
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
                    #region INSERT DATA INTO AMC MASTER

                    AMC_MASLogicLayer insert = new AMC_MASLogicLayer();

                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                    //insert.TRAN_DATE = HfTranDate.Value.Trim();
                    //insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.AMC_NO = TxtAMCNo.Text.Trim();
                    insert.AMC_DATE = Convert.ToDateTime(TxtAMCDate.Text.Trim()).ToString("MM-dd-yyyy");
                    insert.ACODE = HfACODE.Value.Trim();
                    insert.CONTACT_PERSON = DdlKindAttn.SelectedValue.Trim().ToUpper();
                    insert.CONTACT_PHONE = TxtConatctPhone.Text.Trim();
                    insert.CONTACT_EMAIL = TxtContactEmail.Text.Trim();
                    insert.AMC_FRDT = Convert.ToDateTime(TxtAMCStartDate.Text.Trim()).ToString("MM-dd-yyyy");
                    insert.AMC_TODT = Convert.ToDateTime(TxtAMCEndDate.Text.Trim()).ToString("MM-dd-yyyy");
                    insert.MAX_VISIT = TxtMaxVisitNo.Text.Trim();
                    insert.BILL_TERMS = DdlAMCBillingTerm.SelectedValue.Trim().ToString();

                    if (TxtContactPersonName1.Text == string.Empty)
                    {
                        insert.ASSIGN_BCODE1 = null;
                    }
                    else
                    {
                        insert.ASSIGN_BCODE1 = HfContactPerson1.Value.Trim();
                    }

                    if (TxtContactPersonName2.Text == string.Empty)
                    {
                        insert.ASSIGN_BCODE2 = null;
                    }
                    else
                    {
                        insert.ASSIGN_BCODE2 = HfContactPerson2.Value.Trim();
                    }

                    if (TxtContactPersonName3.Text == string.Empty)
                    {
                        insert.ASSIGN_BCODE3 = null;
                    }
                    else
                    {
                        insert.ASSIGN_BCODE3 = HfContactPerson3.Value.Trim();
                    }

                    if (TxtContactPersonName4.Text == string.Empty)
                    {
                        insert.ASSIGN_BCODE4 = null;
                    }
                    else
                    {
                        insert.ASSIGN_BCODE4 = HfContactPerson4.Value.Trim();
                    }

                    if (TxtContactPriority1.Text == string.Empty)
                    {
                        insert.ASSIGN_BCODE1_P = null;
                    }
                    else
                    {
                        insert.ASSIGN_BCODE1_P = TxtContactPriority1.Text.Trim();
                    }

                    if (TxtContactPriority2.Text == string.Empty)
                    {
                        insert.ASSIGN_BCODE2_P = null;
                    }
                    else
                    {
                        insert.ASSIGN_BCODE2_P = TxtContactPriority2.Text.Trim();
                    }

                    if (TxtContactPriority3.Text == string.Empty)
                    {
                        insert.ASSIGN_BCODE3_P = null;
                    }
                    else
                    {
                        insert.ASSIGN_BCODE3_P = TxtContactPriority3.Text.Trim();
                    }

                    if (TxtContactPriority4.Text == string.Empty)
                    {
                        insert.ASSIGN_BCODE4_P = null;
                    }
                    else
                    {
                        insert.ASSIGN_BCODE4_P = TxtContactPriority4.Text.Trim();
                    }

                    if (TxtPreparedPersonName.Text == string.Empty)
                    {
                        insert.BCODE = null;
                    }
                    else
                    {
                        insert.BCODE = HfPreparedPersonBy.Value.Trim();
                    }

                    insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_DATE = "";
                    insert.CLOSE_FLAG = DdlClosed.SelectedValue.Trim().ToUpper();
                    if (DdlClosed.SelectedValue.ToString() == "Y")
                    {
                        insert.CLOSE_DATE = Convert.ToDateTime(TxtClosedDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }

                    if (DdlClosed.SelectedValue.ToString() == "Y")
                    {
                        insert.CLOSE_USERID = TxtClosedBy.Text.Trim().ToUpper();
                    }

                    insert.CHK_FLAG = DdlChecked.SelectedValue.Trim().ToString();
                    if (DdlChecked.SelectedValue.ToString() == "Y")
                    {
                        insert.CHK_DATE = Convert.ToDateTime(TxtCheckedDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }
                    if (DdlChecked.SelectedValue.ToString() == "Y")
                    {
                        insert.CHK_USERID = TxtCheckedBy.Text.Trim().ToUpper();
                    }

                    insert.AMC_TYPE = "A";
                    insert.INV_TRAN_DATE = null;
                    insert.INV_TRAN_NO = null;
                    insert.AMC_TRAN_DATE = null;
                    insert.AMC_TRAN_NO = null;
                    insert.SERVICE_START_DATE = null;
                    insert.BILL_START_DATE = null;

                    #endregion

                    #region INSERT INTO AMC DETAILS GRID

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int SRNO = 1;

                    foreach (GridViewRow row in GvAMCDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                            HiddenField HfTranNo = row.FindControl("HfTranNo") as HiddenField;
                            HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                            HiddenField HfACODE = row.FindControl("HfACODE") as HiddenField;
                            HiddenField HfPartyRefSrNo = row.FindControl("HfPartyRefSrNo") as HiddenField;

                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtAmount = row.FindControl("TxtAmount") as TextBox;

                            if (TxtPartyName.Text != string.Empty && TxtPartyName.Text != null)
                            {


                                XmlElement HandleDetail2 = XDoc1.CreateElement("AMCDetails");

                                HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                                HandleDetail2.SetAttribute("SRNO", SRNO.ToString());

                                if (TxtPartyName.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("ACODE", null);
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("ACODE", (HfACODE.Value));
                                }

                                if (HfPartyRefSrNo.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("PARTY_REFSRNO", (HfPartyRefSrNo.Value.Trim()));
                                }

                                if (TxtQty.Text != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("QTY", (TxtQty.Text.Trim()));
                                }

                                if (TxtRate.Text != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("RATE", (TxtRate.Text.Trim()));
                                }

                                if (TxtAmount.Text != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("AMT", (TxtAmount.Text.Trim()));
                                }

                                root1.AppendChild(HandleDetail2);
                                SRNO++;
                            }
                        }

                    }
                    #endregion


                    string str = AMC_MASLogicLayer.InsertAMC_MASDetail(insert,validation.RSC(XDoc1.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"), HfAMC_TYPE.Value.ToString());

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "AMC MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillAMCMasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "AMC MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : AMC MASTER NOT SAVED";
                        lblmsg.ForeColor = Color.Red;

                    }
                }

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
                string str = AMC_MASLogicLayer.DeleteAMC_MASByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value), HfAMC_TYPE.Value.ToString());
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
                    lblmsg.Text = "Error:AMC Master Deleted";
                    lblmsg.ForeColor = Color.Red;
                }
                clear();
                UserRights();
                FillAMCMasterGrid(Convert.ToString(Session["COMP_CODE"]));
                #endregion
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        protected void Btncalldel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
        }

        public void FillAccountNameOnUpdate(string Id)
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

                    TxtPartyName.Text = DtView.Rows[0]["ANAME"].ToString();
                    HfACODE.Value = DtView.Rows[0]["ACODE"].ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillContactPersonOnUpdate1(string ContactPerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfContactPerson1.Value.ToString() != "0" && HfContactPerson1.Value.ToString() != null && HfContactPerson1.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ContactPerson;
                    DataTable DtView = Dv.ToTable();

                    TxtContactPersonName1.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfContactPerson1.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtContactPersonName1.Text = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillContactPersonOnUpdate2(string ContactPerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfContactPerson2.Value.ToString() != "0" && HfContactPerson2.Value.ToString() != null && HfContactPerson2.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ContactPerson;
                    DataTable DtView = Dv.ToTable();

                    TxtContactPersonName2.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfContactPerson2.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtContactPersonName2.Text = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillContactPersonOnUpdate3(string ContactPerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfContactPerson3.Value.ToString() != "0" && HfContactPerson3.Value.ToString() != null && HfContactPerson3.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ContactPerson;
                    DataTable DtView = Dv.ToTable();

                    TxtContactPersonName3.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfContactPerson3.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtContactPersonName3.Text = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillContactPersonOnUpdate4(string ContactPerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfContactPerson4.Value.ToString() != "0" && HfContactPerson4.Value.ToString() != null && HfContactPerson4.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ContactPerson;
                    DataTable DtView = Dv.ToTable();

                    TxtContactPersonName4.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfContactPerson4.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtContactPersonName4.Text = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillPreparedPersonOnUpdate(string ContactPerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfPreparedPersonBy.Value.ToString() != "0" && HfPreparedPersonBy.Value.ToString() != null && HfPreparedPersonBy.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ContactPerson;
                    DataTable DtView = Dv.ToTable();

                    TxtPreparedPersonName.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfPreparedPersonBy.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtPreparedPersonName.Text = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvAMCMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvAMCMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataSet ds = AMC_MASLogicLayer.GetAllIDWiseAMC_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable details = ds.Tables[1];
                        DataTable DtServiceDetail = ds.Tables[2];
                        DataTable DtBillDetail = ds.Tables[3];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;


                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfAMC_TYPE.Value = dt.Rows[0]["AMC_TYPE"].ToString();
                            TxtAMCNo.Text = dt.Rows[0]["AMC_NO"].ToString();
                            TxtAMCDate.Text = Convert.ToDateTime(dt.Rows[0]["AMC_DATE"].ToString()).ToString("dd-MM-yyyy");
                            FillAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            FillDdlKindAttn();
                            DdlKindAttn.SelectedValue = dt.Rows[0]["CONTACT_PERSON"].ToString();
                            TxtConatctPhone.Text = dt.Rows[0]["CONTACT_PHONE"].ToString();
                            TxtContactEmail.Text = dt.Rows[0]["CONTACT_EMAIL"].ToString();
                            TxtAMCStartDate.Text = Convert.ToDateTime(dt.Rows[0]["AMC_FRDT"].ToString()).ToString("dd-MM-yyyy");
                            TxtAMCEndDate.Text = Convert.ToDateTime(dt.Rows[0]["AMC_TODT"].ToString()).ToString("dd-MM-yyyy");
                            TxtMaxVisitNo.Text = dt.Rows[0]["MAX_VISIT"].ToString();
                            DdlAMCBillingTerm.SelectedValue = dt.Rows[0]["BILL_TERMS"].ToString();
                            HfContactPerson1.Value = dt.Rows[0]["ASSIGN_BCODE1"].ToString();
                            FillContactPersonOnUpdate1(dt.Rows[0]["ASSIGN_BCODE1"].ToString());
                            HfContactPerson2.Value = dt.Rows[0]["ASSIGN_BCODE2"].ToString();
                            FillContactPersonOnUpdate2(dt.Rows[0]["ASSIGN_BCODE2"].ToString());
                            HfContactPerson3.Value = dt.Rows[0]["ASSIGN_BCODE3"].ToString();
                            FillContactPersonOnUpdate3(dt.Rows[0]["ASSIGN_BCODE3"].ToString());
                            HfContactPerson4.Value = dt.Rows[0]["ASSIGN_BCODE4"].ToString();
                            FillContactPersonOnUpdate4(dt.Rows[0]["ASSIGN_BCODE4"].ToString());
                            TxtContactPriority1.Text = dt.Rows[0]["ASSIGN_BCODE1_P"].ToString();
                            TxtContactPriority2.Text = dt.Rows[0]["ASSIGN_BCODE2_P"].ToString();
                            TxtContactPriority3.Text = dt.Rows[0]["ASSIGN_BCODE3_P"].ToString();
                            TxtContactPriority4.Text = dt.Rows[0]["ASSIGN_BCODE4"].ToString();
                            HfPreparedPersonBy.Value = dt.Rows[0]["BCODE"].ToString();
                            FillPreparedPersonOnUpdate(dt.Rows[0]["BCODE"].ToString());
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            DdlClosed.SelectedValue = dt.Rows[0]["CLOSE_FLAG"].ToString();
                            TxtClosedBy.Text = dt.Rows[0]["CLOSE_USERID"].ToString();
                            TxtClosedDate.Text = dt.Rows[0]["CLOSE_DATE"].ToString();
                            DdlChecked.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtCheckedBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            TxtCheckedDate.Text = dt.Rows[0]["CHK_DATE"].ToString();

                            if (details.Rows.Count > 0)
                            {
                                GvAMCDetails.DataSource = details;
                                GvAMCDetails.DataBind();

                                GvAMCDetails.Enabled = false;
                            }

                            if (DtServiceDetail.Rows.Count > 0)
                            {
                                GvServiceDetails.DataSource = DtServiceDetail;
                                GvServiceDetails.DataBind();
                            }

                            if (DtBillDetail.Rows.Count > 0)
                            {
                                GvServiceBillDetails.DataSource = DtBillDetail;
                                GvServiceBillDetails.DataBind();
                            }
                        }
                        btnSave.Visible = false;
                        btnDelete.Visible = true;
                        Btncalldel.Visible = true;
                        BtncallUpd.Visible = false;
                        BtnBillingDetails.Enabled = true;
                        ControllerDisable();

                    }

                }
                #endregion

                if (e.CommandName == "Edita")
                {
                    #region EDIT
                    clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataSet ds = AMC_MASLogicLayer.GetAllIDWiseAMC_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable details = ds.Tables[1];
                        DataTable DtServiceDetail = ds.Tables[2];
                        DataTable DtBillDetail = ds.Tables[3];
                

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;


                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfAMC_TYPE.Value = dt.Rows[0]["AMC_TYPE"].ToString();
                            TxtAMCNo.Text = dt.Rows[0]["AMC_NO"].ToString();
                            TxtAMCDate.Text = Convert.ToDateTime(dt.Rows[0]["AMC_DATE"].ToString()).ToString("dd-MM-yyyy");
                            FillAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            FillDdlKindAttn();
                            DdlKindAttn.SelectedValue = dt.Rows[0]["CONTACT_PERSON"].ToString();
                            TxtConatctPhone.Text = dt.Rows[0]["CONTACT_PHONE"].ToString();
                            TxtContactEmail.Text = dt.Rows[0]["CONTACT_EMAIL"].ToString();
                            TxtAMCStartDate.Text = Convert.ToDateTime(dt.Rows[0]["AMC_FRDT"].ToString()).ToString("dd-MM-yyyy");
                            TxtAMCEndDate.Text = Convert.ToDateTime(dt.Rows[0]["AMC_TODT"].ToString()).ToString("dd-MM-yyyy");
                            TxtMaxVisitNo.Text = dt.Rows[0]["MAX_VISIT"].ToString();
                            DdlAMCBillingTerm.SelectedValue = dt.Rows[0]["BILL_TERMS"].ToString();
                            HfContactPerson1.Value = dt.Rows[0]["ASSIGN_BCODE1"].ToString();
                            FillContactPersonOnUpdate1(dt.Rows[0]["ASSIGN_BCODE1"].ToString());
                            HfContactPerson2.Value = dt.Rows[0]["ASSIGN_BCODE2"].ToString();
                            FillContactPersonOnUpdate2(dt.Rows[0]["ASSIGN_BCODE2"].ToString());
                            HfContactPerson3.Value = dt.Rows[0]["ASSIGN_BCODE3"].ToString();
                            FillContactPersonOnUpdate3(dt.Rows[0]["ASSIGN_BCODE3"].ToString());
                            HfContactPerson4.Value = dt.Rows[0]["ASSIGN_BCODE4"].ToString();
                            FillContactPersonOnUpdate4(dt.Rows[0]["ASSIGN_BCODE4"].ToString());
                            TxtContactPriority1.Text = dt.Rows[0]["ASSIGN_BCODE1_P"].ToString();
                            TxtContactPriority2.Text = dt.Rows[0]["ASSIGN_BCODE2_P"].ToString();
                            TxtContactPriority3.Text = dt.Rows[0]["ASSIGN_BCODE3_P"].ToString();
                            TxtContactPriority4.Text = dt.Rows[0]["ASSIGN_BCODE4"].ToString();
                            HfPreparedPersonBy.Value = dt.Rows[0]["BCODE"].ToString();
                            FillPreparedPersonOnUpdate(dt.Rows[0]["BCODE"].ToString());
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            DdlClosed.SelectedValue = dt.Rows[0]["CLOSE_FLAG"].ToString();
                            TxtClosedBy.Text = dt.Rows[0]["CLOSE_USERID"].ToString();
                            TxtClosedDate.Text = dt.Rows[0]["CLOSE_DATE"].ToString();
                            DdlChecked.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtCheckedBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            TxtCheckedDate.Text = dt.Rows[0]["CHK_DATE"].ToString();

                            if (details.Rows.Count > 0)
                            {

                                #region Assign To Table

                                DataTable table = new DataTable();
                                DataRow drm = null;
                                if (ViewState["CurrentTable"] != null)
                                {
                                    table = (DataTable)ViewState["CurrentTable"];
                                }
                                else
                                {
                                    if (table.Rows.Count <= 0)
                                    {

                                        table.Columns.Add("COMP_CODE", typeof(string));
                                        table.Columns.Add("TRAN_DATE", typeof(string));
                                        table.Columns.Add("TRAN_NO", typeof(string));
                                        table.Columns.Add("SRNO", typeof(string));
                                        table.Columns.Add("ACODE", typeof(string));
                                        table.Columns.Add("PARTY_REFSRNO", typeof(string));
                                        table.Columns.Add("QTY", typeof(string));
                                        table.Columns.Add("RATE", typeof(string));
                                        table.Columns.Add("AMT", typeof(string));
                                        table.Columns.Add("MODEL_SRNO", typeof(string));
                                        table.Columns.Add("PARTY_SRNO", typeof(string));
                                        table.Columns.Add("MFG_SRNO", typeof(string));
                                        table.Columns.Add("BRAND_NAME", typeof(string));
                                        table.Columns.Add("BRANDTYPE_NAME", typeof(string));
                                        table.Columns.Add("MODEL_NAME", typeof(string));
                                    }
                                }

                                for (int m = 0; m < details.Rows.Count; m++)
                                {
                                    drm = table.NewRow();

                                    drm["COMP_CODE"] = details.Rows[m]["COMP_CODE"].ToString();
                                    drm["TRAN_DATE"] = details.Rows[m]["TRAN_DATE"].ToString();
                                    drm["TRAN_NO"] = details.Rows[m]["TRAN_NO"].ToString();
                                    drm["SRNO"] = details.Rows[m]["SRNO"].ToString();
                                    drm["ACODE"] = details.Rows[m]["ACODE"].ToString();
                                    drm["PARTY_REFSRNO"] = details.Rows[m]["PARTY_REFSRNO"].ToString();
                                    drm["QTY"] = details.Rows[m]["QTY"].ToString();
                                    drm["RATE"] = details.Rows[m]["RATE"].ToString();
                                    drm["AMT"] = details.Rows[m]["AMT"].ToString();

                                    table.Rows.Add(drm);

                                }



                                #endregion

                                ViewState["CurrentTable"] = table;
                                GvAMCDetails.DataSource = details;
                                GvAMCDetails.DataBind();

                                GvAMCDetails.Enabled = true;
                            }


                            if(DtServiceDetail.Rows.Count > 0)
                            {
                                GvServiceDetails.DataSource = DtServiceDetail;
                                GvServiceDetails.DataBind();
                            }

                            if (DtBillDetail.Rows.Count > 0)
                            {
                                GvServiceBillDetails.DataSource = DtBillDetail;
                                GvServiceBillDetails.DataBind();
                            }


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
                    BtnBillingDetails.Enabled = true;
                    UserRights();

                }


                if (e.CommandName == "Viewa")
                {
                    #region VIEW ON TEXTBOX
                    clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataSet ds = AMC_MASLogicLayer.GetAllIDWiseAMC_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable details = ds.Tables[1];
                        DataTable DtServiceDetail = ds.Tables[2];
                        DataTable DtBillDetail = ds.Tables[3];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;


                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfAMC_TYPE.Value = dt.Rows[0]["AMC_TYPE"].ToString();
                            TxtAMCNo.Text = dt.Rows[0]["AMC_NO"].ToString();
                            TxtAMCDate.Text = Convert.ToDateTime(dt.Rows[0]["AMC_DATE"].ToString()).ToString("dd-MM-yyyy");
                            FillAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            FillDdlKindAttn();
                            DdlKindAttn.SelectedValue = dt.Rows[0]["CONTACT_PERSON"].ToString();
                            TxtConatctPhone.Text = dt.Rows[0]["CONTACT_PHONE"].ToString();
                            TxtContactEmail.Text = dt.Rows[0]["CONTACT_EMAIL"].ToString();
                            TxtAMCStartDate.Text = Convert.ToDateTime(dt.Rows[0]["AMC_FRDT"].ToString()).ToString("dd-MM-yyyy");
                            TxtAMCEndDate.Text = Convert.ToDateTime(dt.Rows[0]["AMC_TODT"].ToString()).ToString("dd-MM-yyyy");
                            TxtMaxVisitNo.Text = dt.Rows[0]["MAX_VISIT"].ToString();
                            DdlAMCBillingTerm.SelectedValue = dt.Rows[0]["BILL_TERMS"].ToString();
                            HfContactPerson1.Value = dt.Rows[0]["ASSIGN_BCODE1"].ToString();
                            FillContactPersonOnUpdate1(dt.Rows[0]["ASSIGN_BCODE1"].ToString());
                            HfContactPerson2.Value = dt.Rows[0]["ASSIGN_BCODE2"].ToString();
                            FillContactPersonOnUpdate2(dt.Rows[0]["ASSIGN_BCODE2"].ToString());
                            HfContactPerson3.Value = dt.Rows[0]["ASSIGN_BCODE3"].ToString();
                            FillContactPersonOnUpdate3(dt.Rows[0]["ASSIGN_BCODE3"].ToString());
                            HfContactPerson4.Value = dt.Rows[0]["ASSIGN_BCODE4"].ToString();
                            FillContactPersonOnUpdate4(dt.Rows[0]["ASSIGN_BCODE4"].ToString());
                            TxtContactPriority1.Text = dt.Rows[0]["ASSIGN_BCODE1_P"].ToString();
                            TxtContactPriority2.Text = dt.Rows[0]["ASSIGN_BCODE2_P"].ToString();
                            TxtContactPriority3.Text = dt.Rows[0]["ASSIGN_BCODE3_P"].ToString();
                            TxtContactPriority4.Text = dt.Rows[0]["ASSIGN_BCODE4"].ToString();
                            HfPreparedPersonBy.Value = dt.Rows[0]["BCODE"].ToString();
                            FillPreparedPersonOnUpdate(dt.Rows[0]["BCODE"].ToString());
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            DdlClosed.SelectedValue = dt.Rows[0]["CLOSE_FLAG"].ToString();
                            TxtClosedBy.Text = dt.Rows[0]["CLOSE_USERID"].ToString();
                            TxtClosedDate.Text = dt.Rows[0]["CLOSE_DATE"].ToString();
                            DdlChecked.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtCheckedBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            TxtCheckedDate.Text = dt.Rows[0]["CHK_DATE"].ToString();

                            if (details.Rows.Count > 0)
                            {
                                GvAMCDetails.DataSource = details;
                                GvAMCDetails.DataBind();

                                GvAMCDetails.Enabled = false;
                            }

                            if (DtServiceDetail.Rows.Count > 0)
                            {
                                GvServiceDetails.DataSource = DtServiceDetail;
                                GvServiceDetails.DataBind();
                            }

                            if (DtBillDetail.Rows.Count > 0)
                            {
                                GvServiceBillDetails.DataSource = DtBillDetail;
                                GvServiceBillDetails.DataBind();
                            }
                        }
                    }

                    #endregion
                    ControllerDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    BtnBillingDetails.Enabled = true;
                    UserRights();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvAMCMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btnedit = (e.Row.FindControl("btnEdit") as Button);
                    Button btndelete = (e.Row.FindControl("btnDelete") as Button);
                    Label lblClosedFlag = (e.Row.FindControl("lblClosedFlag") as Label);

                    HiddenField hfREC_UPD = (e.Row.FindControl("hfREC_UPD") as HiddenField);
                    HiddenField hfREC_DEL = (e.Row.FindControl("hfREC_DEL") as HiddenField);
                    HiddenField hfREC_INS = (e.Row.FindControl("hfREC_INS") as HiddenField);



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


                        if (lblClosedFlag.Text == "YES")
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


                        if (lblClosedFlag.Text == "YES")
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
            catch (Exception ex)
            {

                Response.AppendToLog(ex.ToString());
            }
        }

        public void FillPartyModelSrNo()
        {
            try
            {
                string ACODE = HfACODE.Value;

                DataTable Dt = new DataTable();
                Dt = PARTY_MODELMASLogicLayer.GetAllPARTY_MODELMASDetailWisePartyNameForGrid(ACODE);

                GvPartyModelSrNo.DataSource = Dt;
                GvPartyModelSrNo.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnPartyModelMaster_Click(object sender, EventArgs e)
        {
            try
            {
                GvPartyModelSrNo.DataSource = null;
                GvPartyModelSrNo.DataBind();

                if (HfACODE.Value == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SelectionAlert", "SelectionAlert()", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelPartyModelSrNo", "ShowModelPartyModelSrNo()", true);

                    FillPartyModelSrNo();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvPartyModelSrNo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnAddCPartyModelSrNoProcess_Click(object sender, EventArgs e)
        {
            try
            {
                #region ASSIGN VALUE TO AMC DETAILS GRID

                DataTable table = new DataTable();

                DataRow dr = null;

                table.Columns.Add("COMP_CODE", typeof(string));
                table.Columns.Add("TRAN_DATE", typeof(string));
                table.Columns.Add("TRAN_NO", typeof(string));
                table.Columns.Add("SRNO", typeof(string));
                table.Columns.Add("ACODE", typeof(string));
                table.Columns.Add("PARTY_REFSRNO", typeof(string));
                table.Columns.Add("QTY", typeof(string));
                table.Columns.Add("RATE", typeof(string));
                table.Columns.Add("AMT", typeof(string));
                table.Columns.Add("MODEL_SRNO", typeof(string));
                table.Columns.Add("PARTY_SRNO", typeof(string));
                table.Columns.Add("MFG_SRNO", typeof(string));
                table.Columns.Add("BRAND_NAME", typeof(string));
                table.Columns.Add("BRANDTYPE_NAME", typeof(string));
                table.Columns.Add("MODEL_NAME", typeof(string));

                foreach (GridViewRow row in GvPartyModelSrNo.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfCompCodeModel = row.FindControl("HfCompCodeModel") as HiddenField;
                        HiddenField HfBranchCodeModel = row.FindControl("HfBranchCodeModel") as HiddenField;
                        HiddenField HfPartyRefSrNo = row.FindControl("HfPartyRefSrNo") as HiddenField;
                        CheckBox ChkPartyModelSrNo = row.FindControl("ChkPartyModelSrNo") as CheckBox;

                        if (ChkPartyModelSrNo.Checked == true)
                        {

                            DataTable Dt = PARTY_MODELMASLogicLayer.GetAllIDWisePARTY_MODELMASDetailForDC(HfPartyRefSrNo.Value.ToString());



                            if (Dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < Dt.Rows.Count; i++)
                                {

                                    #region Assign Value to Table

                                    dr = table.NewRow();

                                    //dr["COMP_CODE"] = string.Empty;
                                    //dr["TRAN_DATE"] = string.Empty;
                                    //dr["TRAN_NO"] = string.Empty;
                                    //dr["SRNO"] = string.Empty;
                                    dr["ACODE"] = Dt.Rows[0]["ACODE"].ToString();
                                    dr["PARTY_REFSRNO"] = Dt.Rows[0]["SRNO"].ToString();
                                    //dr["QTY"] = string.Empty;
                                    //dr["RATE"] = string.Empty;
                                    //dr["AMT"] = string.Empty;
                                    dr["MODEL_SRNO"] = Dt.Rows[0]["MODEL_SRNO"].ToString();
                                    dr["PARTY_SRNO"] = Dt.Rows[0]["PARTY_SRNO"].ToString();
                                    dr["MFG_SRNO"] = Dt.Rows[0]["MFG_SRNO"].ToString();
                                    dr["BRAND_NAME"] = Dt.Rows[0]["BRAND_NAME"].ToString();
                                    dr["BRANDTYPE_NAME"] = Dt.Rows[0]["BRANDTYPE_NAME"].ToString();
                                    dr["MODEL_NAME"] = Dt.Rows[0]["MODEL_NAME"].ToString();

                                    #endregion

                                    table.Rows.Add(dr);

                                }

                                ViewState["CurrentTable"] = table;
                            }

                        }

                    }
                }

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModelPartyModelSrNo", " HideModelPartyModelSrNo()", true);

                GvAMCDetails.DataSource = table;
                GvAMCDetails.DataBind();

                DivEntry.Visible = true;
                DivView.Visible = false;


                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }



        #region Calculation of Rate and Quantity

        protected void TxtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {

                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtRateString = (TextBox)row.Cells[9].FindControl("TxtRate");
                TextBox TxtAmountString = (TextBox)row.Cells[10].FindControl("TxtAmount");


                if (TxtRateString.Text == string.Empty)
                {
                    TxtRateString.Text = "0";
                }

                if (txt.Text.Trim() != string.Empty && TxtRateString.Text.Trim() != string.Empty)
                {
                    TxtAmountString.Text = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtRateString.Text.Trim()));
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

                TextBox TxtQtyString = (TextBox)row.Cells[8].FindControl("TxtQty");
                TextBox TxtAmountString = (TextBox)row.Cells[10].FindControl("TxtAmount");


                if (TxtQtyString.Text == string.Empty)
                {
                    TxtQtyString.Text = "0";
                }

                if (txt.Text.Trim() != string.Empty && TxtQtyString.Text.Trim() != string.Empty)
                {
                    TxtAmountString.Text = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtQtyString.Text.Trim()));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        protected void TxtAMCStartDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime add_Months = Convert.ToDateTime(TxtAMCStartDate.Text).AddDays(365);
                TxtAMCEndDate.Text = add_Months.ToString("dd/MM/yyyy");
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlClosed_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                if (DdlClosed.SelectedValue == "Y")
                {
                    TxtClosedBy.Text = Session["USERNAME"].ToString();
                    TxtClosedDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    TxtClosedBy.Text = "";
                    TxtClosedDate.Text = "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlChecked_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (DdlChecked.SelectedValue == "Y")
                {
                    TxtCheckedBy.Text = Session["USERNAME"].ToString();
                    TxtCheckedDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    TxtCheckedBy.Text = "";
                    TxtCheckedDate.Text = "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        //protected void BtnServiceDetails_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (HfACODE.Value == string.Empty)
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SelectionAlert", "SelectionAlert()", true);
        //        }
        //        else
        //        {

        //            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelServiceDetails", "ShowModelServiceDetails()", true);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        protected void GvAMCDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "ServiceView")
                {
                    #region MyRegion

                    if (e.CommandArgument.ToString() != string.Empty)
                    {
                        int id = int.Parse(e.CommandArgument.ToString());

                        Control ctrl = e.CommandSource as Control;
                        if (ctrl != null)
                        {
                            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                            HiddenField HfTranDateGrid = (row.FindControl("HfTranDate")) as HiddenField;
                            HiddenField HfTranNo = (row.FindControl("HfTranNo")) as HiddenField;
                            HiddenField HfSrNo = (row.FindControl("HfSrNo")) as HiddenField;



                            DataTable Dt = new DataTable();

                            Dt = AMC_SERVICE_DETLogicLayer.GetAllAMC_SERVICE_DetialsForGrid(Session["COMP_CODE"].ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()), e.CommandArgument.ToString(), HfSrNo.Value);
                            GvServiceDetails.DataSource = Dt;
                            GvServiceDetails.DataBind();

                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelServiceDetails", "ShowModelServiceDetails()", true);

                            #endregion

                        }
                    }
                }
                else
                {

                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }

     
        protected void BtnBillingDetails_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelServiceBillDetails", "ShowModelServiceBillDetails()", true);
         //   FillGvServiceBillDetails();
        }

  
    }
}