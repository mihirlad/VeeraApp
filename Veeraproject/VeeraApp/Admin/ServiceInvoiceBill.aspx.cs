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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;


namespace VeeraApp.Admin
{
    public partial class ServiceInvoiceBill : System.Web.UI.Page
    {

        public static string compcode;
        static DataTable DtSearch = new DataTable();
        public static string Branchcode;

        protected void Page_Load(object sender, EventArgs e)

        {

            if (Session["USERCODE"] != null &&
             Session["USERNAME"] != null &&
             Session["USERTYPE"] != null &&
             Session["COMP_CODE"] != null &&
             Session["COMP_NAME"] != null &&
             Session["WORK_VIEWFLAG"] != null &&
             Session["INVTYPE_FLAG"] != null &&
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

                    SetInitialRow();
                    SetInitialRow_ChargesGrid();


                    CalendarExtenderInvoiceDate.StartDate = Convert.ToDateTime(Session["FIN_YEAR"].ToString());
                    CalendarExtenderInvoiceDate.EndDate = Convert.ToDateTime(Session["FIN_YEAR_END"].ToString());

                    if (!string.IsNullOrWhiteSpace(Request.QueryString["Tran_Type"]) && !string.IsNullOrWhiteSpace(Request.QueryString["Trn_Type"]))
                    {
                        HfTranType.Value = Request.QueryString["Tran_Type"];
                        HfTrnType.Value = Request.QueryString["Trn_Type"];
                    }


                    if (!string.IsNullOrWhiteSpace(Request.QueryString["TRAN_NO"]) && !string.IsNullOrWhiteSpace(Request.QueryString["TRAN_DATE"]))
                    {
        
                        HfJobcard_TranNo.Value = HttpUtility.UrlDecode(Decrypt(Request.QueryString["TRAN_NO"]));
                        HfJobcard_TranDate.Value = HttpUtility.UrlDecode(Decrypt(Request.QueryString["TRAN_DATE"]));

                        #region From JobCard

                        #region SET TEXT ON VIEW


                        DataSet ds = REC_ISS_MLogicLayer.GetAllIDWiseREC_ISS_MASDetialsForJobcard(HfJobcard_TranNo.Value, Convert.ToDateTime(HfJobcard_TranDate.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtCharges = ds.Tables[2];
                        DataTable DtBarcode = ds.Tables[3];


                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfRef_TranDate.Value = dt.Rows[0]["REF_TRAN_DATE"].ToString();
                            HfRef_TranNo.Value = dt.Rows[0]["REF_TRAN_NO"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            HfTrnType.Value = dt.Rows[0]["TRN_TYPE"].ToString();
                            HfACODECredit.Value = dt.Rows[0]["CRACODE"].ToString();
                            HfAODEDebit.Value = dt.Rows[0]["DRACODE"].ToString();
                            FillPartyNameOnUpdate(dt.Rows[0]["DRACODE"].ToString());
                            TxtPONo.Text = dt.Rows[0]["PO_NO"].ToString();
                            TxtPODate.Text = dt.Rows[0]["PO_DT"].ToString();
                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtDriverName.Text = dt.Rows[0]["DRIVER_NAME"].ToString();
                            TxtDriverAddress.Text = dt.Rows[0]["DRIVER_ADD"].ToString();
                            TxtMDLNo.Text = dt.Rows[0]["MDLNO"].ToString();
                            TxtMDLState.Text = dt.Rows[0]["MDLSTATE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtInvoiceNo.Text = dt.Rows[0]["INV_NUMBER"].ToString();
                            TxtInvoiceDate.Text = Convert.ToDateTime(dt.Rows[0]["INV_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtDueDate.Text = Convert.ToDateTime(dt.Rows[0]["DUE_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtDueDays.Text = dt.Rows[0]["DUE_DAYS"].ToString();
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            // TxtGstNo.Text = dt.Rows[0]["BRANCH_CODE"].ToString();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            DdlRegisterType.SelectedValue = dt.Rows[0]["CST_TYPE"].ToString();
                            DdlFigureFlag.SelectedValue = dt.Rows[0]["FIGURE_FLAG"].ToString();
                            HfServicePerson.Value = dt.Rows[0]["BCODE"].ToString();
                            FillServicePerson(dt.Rows[0]["BCODE"].ToString());
                            TxtJobCardNo.Text= dt.Rows[0]["JOBCARD_NO"].ToString();
                            TxtJobCardDate.Text = Convert.ToDateTime(dt.Rows[0]["JOBCARD_DATE"].ToString()).ToString("dd-MM-yyyy");

                            if (DtDetails.Rows.Count > 0)
                            {
                                GvStockRecDetails.DataSource = DtDetails;
                                GvStockRecDetails.DataBind();
                                GvStockRecDetails.Enabled = false;
                            }

                            if (DtCharges.Rows.Count > 0)
                            {
                                GvChagresTranDetails.DataSource = DtCharges;
                                GvChagresTranDetails.DataBind();
                                GvChagresTranDetails.Enabled = false;
                            }

                            if (DtBarcode.Rows.Count > 0)
                            {
                                ViewState["BarcodeTemp"] = DtBarcode;
                                GvViewBarcode.DataSource = DtBarcode;
                                GvViewBarcode.DataBind();
                            }


                            Session["TRAN_NO"] = HfJobcard_TranNo.Value;
                            Session["TRAN_DATE"] = HfJobcard_TranDate.Value;


                            Session["TRAN_TYPE"] = HfTranType.Value;
                            Session["TRN_TYPE"] = HfTrnType.Value;

                        }


                        #endregion
                        ControllerDisable();
                        btnSave.Visible = false;
                        Btncalldel.Visible = false;
                        BtncallUpd.Visible = false;
                        UserRights();

                        #endregion
                    }



                    FillREC_ISS_MasterGrid(Session["COMP_CODE"].ToString());

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


        protected void TxtServicePerson_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtServicePerson.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtServicePerson.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfServicePerson.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillServicePerson(string ServicePerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfServicePerson.Value.ToString() != "0" && HfServicePerson.Value.ToString() != null && HfServicePerson.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ServicePerson;
                    DataTable DtView = Dv.ToTable();

                    TxtServicePerson.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfServicePerson.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtServicePerson.Text = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void DdlConfirmFlag_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlConfirmFlag.SelectedValue == "Y")
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


        public void GetAccountCode()
        {
            DataTable DtACODE = new DataTable();
            DtACODE = ACCOUNTS_MASLogicLayer.GetAccountsNameForInvoices(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), HfTranType.Value.ToString(), HfTrnType.Value.ToString());
            HfACODECredit.Value = DtACODE.Rows[0]["CREDIT"].ToString();
            HfAODEDebit.Value = DtACODE.Rows[0]["DEBIT"].ToString();

            if (HfAODEDebit.Value != string.Empty)
            {
                DataTable DtAName = new DataTable();
                DtAName = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(HfAODEDebit.Value);
                TxtPartyNameDebit.Text = DtAName.Rows[0]["ANAME"].ToString();
                TxtPartyNameDebit.Enabled = false;


            }

        }

        public void clear()
        {
            ViewState["CurrentTable"] = null;
            ViewState["AddChallanTable"] = null;
            ViewState["CurrentTable_C"] = null;
            ViewState["BarcodeTemp"] = null;
            ViewState["BarcodeTempNew"] = null;

            ViewState["TotalGSTAmount_Deatils"] = null;
            ViewState["TotalCGSTAmount_Deatils"] = null;
            ViewState["TotalSGSTAmount_Deatils"] = null;
            ViewState["TotalIGSTAmount_Deatils"] = null;

            ViewState["TotalGSTAmount_Charges"] = null;
            ViewState["TotalCGSTAmount_Charges"] = null;
            ViewState["TotalSGSTAmount_Charges"] = null;
            ViewState["TotalGSTAmount_Charges"] = null;

            ViewState["TotalStockDetailsAmount_Deatils"] = null;
            ViewState["TotalChargesAmount_Deatils"] = null;
            ViewState["TotalCurrentTable_Details"] = null;
            ViewState["TotalCurrentTable_Charges"] = null;

            DivEntry.Visible = false;
            DivView.Visible = true;

            TxtPartyNameDebit.Text = string.Empty;
            TxtPONo.Text = string.Empty;
            TxtPODate.Text = string.Empty;
            TxtTransportName.Text = string.Empty;
            TxtVehclieNo.Text = string.Empty;
            TxtDriverName.Text = string.Empty;
            TxtDriverAddress.Text = string.Empty;
            TxtMDLNo.Text = string.Empty;
            TxtMDLState.Text = string.Empty;
            TxtRemark.Text = string.Empty;
            TxtInvoiceNo.Text = string.Empty;
            TxtInvoiceDate.Text = string.Empty;
            TxtDueDays.Text = string.Empty;
            TxtDueDate.Text = string.Empty;
            DdlConfirmFlag.SelectedValue = "N";
            TxtConfirmBy.Text = string.Empty;
            TxtConfirmDate.Text = string.Empty;
            TxtGstNo.Text = string.Empty;
            DdlPartyType.SelectedIndex = 0;
            DdlRegisterType.SelectedIndex = 0;
            DdlFigureFlag.SelectedIndex = 0;
            TxtROamt.Text = string.Empty;
            TxtNetAmt.Text = string.Empty;
            TxtServicePerson.Text = string.Empty;
            TxtJobCardDate.Text = string.Empty;
            TxtJobCardNo.Text = string.Empty;
            lblmsg.Text = string.Empty;

            SetInitialRow();
            SetInitialRow_ChargesGrid();
            BtncallUpd.Text = "SAVE";



        }

        public void ControllerEnable()
        {
            TxtPartyNameDebit.Enabled = true;
            TxtPONo.Enabled = true;
            TxtPODate.Enabled = true;
            TxtTransportName.Enabled = true;
            TxtVehclieNo.Enabled = true;
            TxtDriverName.Enabled = true;
            TxtDriverAddress.Enabled = true;
            TxtMDLNo.Enabled = true;
            TxtMDLState.Enabled = true;
            TxtRemark.Enabled = true;
            TxtInvoiceNo.Enabled = false;
            TxtInvoiceDate.Enabled = true;
            TxtDueDays.Enabled = true;
            TxtDueDate.Enabled = true;
            DdlConfirmFlag.Enabled = true;
            TxtConfirmBy.Enabled = true;
            TxtConfirmDate.Enabled = true;
            TxtGstNo.Enabled = true;
            DdlPartyType.Enabled = true;
            DdlRegisterType.Enabled = true;
            DdlFigureFlag.Enabled = true;
            TxtROamt.Enabled = true;
            TxtNetAmt.Enabled = true;
            TxtServicePerson.Enabled = true;
            TxtJobCardDate.Enabled = false;
            TxtJobCardNo.Enabled = false;

        }

        public void ControllerDisable()
        {
            TxtPartyNameDebit.Enabled = false;
            TxtPONo.Enabled = false;
            TxtPODate.Enabled = false;
            TxtTransportName.Enabled = false;
            TxtVehclieNo.Enabled = false;
            TxtDriverName.Enabled = false;
            TxtDriverAddress.Enabled = false;
            TxtMDLNo.Enabled = false;
            TxtMDLState.Enabled = false;
            TxtRemark.Enabled = false;
            TxtInvoiceNo.Enabled = false;
            TxtInvoiceDate.Enabled = false;
            TxtDueDays.Enabled = false;
            TxtDueDate.Enabled = false;
            DdlConfirmFlag.Enabled = false;
            TxtConfirmBy.Enabled = false;
            TxtConfirmDate.Enabled = false;
            TxtGstNo.Enabled = false;
            DdlPartyType.Enabled = false;
            DdlRegisterType.Enabled = false;
            DdlFigureFlag.Enabled = false;
            TxtROamt.Enabled = false;
            TxtNetAmt.Enabled = false;
            TxtServicePerson.Enabled = false;
            TxtJobCardDate.Enabled = false;
            TxtJobCardNo.Enabled = false;

        }



        #region TOTAL OF FOOTER TEMPLETES FOR STOCK_DETAILS GRID

        private double TotalQuantity()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockRecDetails.Rows.Count; i++)
            {
                string total = (GvStockRecDetails.Rows[i].FindControl("TxtQty") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }


        private double TotalHfAmt()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockRecDetails.Rows.Count; i++)
            {
                string total = (GvStockRecDetails.Rows[i].FindControl("HfAmount") as HiddenField).Value;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }

        private double TotalGrossAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockRecDetails.Rows.Count; i++)
            {
                string total = (GvStockRecDetails.Rows[i].FindControl("HfGrossAmount") as HiddenField).Value;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }

        private double TotalCGSTAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockRecDetails.Rows.Count; i++)
            {
                string total = (GvStockRecDetails.Rows[i].FindControl("TxtCGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalSGSTAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockRecDetails.Rows.Count; i++)
            {
                string total = (GvStockRecDetails.Rows[i].FindControl("TxtSGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalIGSTAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockRecDetails.Rows.Count; i++)
            {
                string total = (GvStockRecDetails.Rows[i].FindControl("TxtIGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockRecDetails.Rows.Count; i++)
            {
                string total = (GvStockRecDetails.Rows[i].FindControl("TxtTotalAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        #endregion


        #region TOTALS OF FOOTER TEMPLETES FOR CHARGES GRID

        private double TotalChargesQuantity()
        {
            double GTotal = 0;
            for (int i = 0; i < GvChagresTranDetails.Rows.Count; i++)
            {
                string total = (GvChagresTranDetails.Rows[i].FindControl("TxtQty") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }


        private double TotalChargesGrossAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvChagresTranDetails.Rows.Count; i++)
            {
                string total = (GvChagresTranDetails.Rows[i].FindControl("TxtChargesAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }


        private double TotalChargesCGSTAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvChagresTranDetails.Rows.Count; i++)
            {
                string total = (GvChagresTranDetails.Rows[i].FindControl("TxtCGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }


        private double TotalChargesSGSTAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvChagresTranDetails.Rows.Count; i++)
            {
                string total = (GvChagresTranDetails.Rows[i].FindControl("TxtSGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }


        private double TotalChargesIGSTAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvChagresTranDetails.Rows.Count; i++)
            {
                string total = (GvChagresTranDetails.Rows[i].FindControl("TxtIGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }


        private double TotalChargesTotalAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvChagresTranDetails.Rows.Count; i++)
            {
                string total = (GvChagresTranDetails.Rows[i].FindControl("TxtTotalAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;
        }

        #endregion


        public void FillNetAmount()
        {
            try
            {


                if (HfStockDetailsGridTotal.Value == string.Empty)
                {
                    HfStockDetailsGridTotal.Value = "0";
                }
                if (HfChargesGridTotal.Value == string.Empty)
                {
                    HfChargesGridTotal.Value = "0";
                }

                if(HfRef_TranNo.Value!=string.Empty && HfRef_TranDate.Value!=string.Empty)
                {
                    double GridmergeTotalAmt = Convert.ToDouble(ViewState["TotalCurrentTable_Details"]) + Convert.ToDouble(ViewState["TotalChargesAmount_Deatils"]);

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


                else
                {
                    double GridmergeTotalAmt = Convert.ToDouble(ViewState["TotalCurrentTable_Details"]) + Convert.ToDouble(ViewState["TotalCurrentTable_Charges"]);

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

            


              

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void TotalAmountCalculationInREC_ISS_M()
        {
            try
            {

                HfTotalSumCGSTAmount.Value = Convert.ToDouble(Convert.ToDouble(ViewState["TotalCGSTAmount_Deatils"]) + Convert.ToDouble(ViewState["TotalCGSTAmount_Charges"])).ToString();
                HfTotalSumSGSTAmount.Value = Convert.ToDouble(Convert.ToDouble(ViewState["TotalSGSTAmount_Deatils"]) + Convert.ToDouble(ViewState["TotalSGSTAmount_Charges"])).ToString();
                HfTotalSumIGSTAmount.Value = Convert.ToDouble(Convert.ToDouble(ViewState["TotalIGSTAmount_Deatils"]) + Convert.ToDouble(ViewState["TotalIGSTAmount_Charges"])).ToString();
                HfTotalSumGSTAmount.Value = Convert.ToDouble(Convert.ToDouble(ViewState["TotalGSTAmount_Deatils"]) + Convert.ToDouble(ViewState["TotalGSTAmount_Charges"])).ToString();
                HfGridsTotalAmount.Value = Convert.ToDouble(Convert.ToDouble(ViewState["TotalCurrentTable_Details"]) + Convert.ToDouble(ViewState["TotalCurrentTable_Charges"])).ToString();
                HfGridGrossAmount.Value = Convert.ToDouble(Convert.ToDouble(ViewState["GrossAmtCurrentTable_Details"]) + Convert.ToDouble(ViewState["TotalChargesAmount_Deatils"])).ToString();
                HfChargesGridTotalAmount.Value = Convert.ToDouble(ViewState["TotalCurrentTable_Charges"]).ToString();
                HfOtherAmount.Value = Convert.ToDouble(Convert.ToDouble(TxtROamt.Text) + Convert.ToDouble(ViewState["TotalCurrentTable_Charges"])).ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillREC_ISS_MasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = REC_ISS_MLogicLayer.GetAllREC_ISS_M_DetailsForTaxInvoice(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()), HfTranType.Value.ToString(), HfTrnType.Value.ToString());
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvTaxInvoiceMaster.DataSource = Dv.ToTable();
            GvTaxInvoiceMaster.DataBind();

            DtSearch = Dv.ToTable();

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


        protected void TxtPartyNameDebit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select ACODE from ACCOUNTS where ANAME = '" + TxtPartyNameDebit.Text + "' and COMP_CODE = " + Session["COMP_CODE"].ToString(), con);
                int x = Convert.ToInt32(cmd.ExecuteScalar());
                if (x == 0)
                {
                    TxtPartyNameDebit.BackColor = Color.Red;

                }
                else
                {
                    HfAODEDebit.Value = cmd.ExecuteScalar().ToString();
                    TxtPartyNameDebit.BackColor = Color.White; con.Close();

                    FillAccountGSTNumber();
                    FillDdlAccountPartyType();
                    FillDdlAccountRegisterType();
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public void FillAccountGSTNumber()
        {
            try
            {
                string ACODE = HfAODEDebit.Value;
                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(ACODE);
                if (Dt.Rows.Count > 0)
                {
                    TxtGstNo.Text = Dt.Rows[0]["GST_NO"].ToString();
                }
                else
                {
                    TxtGstNo.Text = string.Empty;
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
                string ACODE = HfAODEDebit.Value;
                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(ACODE);
                if (Dt.Rows.Count > 0)
                {
                    DdlPartyType.SelectedValue = Dt.Rows[0]["PARTY_TYPE_String"].ToString().ToUpper();
                }
                else
                {
                    DdlPartyType.SelectedValue = "0";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlAccountRegisterType()
        {
            try
            {
                string ACODE = HfAODEDebit.Value;
                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(ACODE);
                if (Dt.Rows.Count > 0)
                {
                    DdlRegisterType.SelectedValue = Dt.Rows[0]["CST_TYPE"].ToString();
                }
                else
                {
                    DdlRegisterType.SelectedValue = "0";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetTransporterName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from TRANSPORT_MAS where TNAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> TNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TNames.Add(dt.Rows[i][1].ToString());
            }
            return TNames;
        }





        protected void btnClear_Click(object sender, EventArgs e)
        {
            //    ViewState["CurrentTable"] = null;
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
                TxtPONo.Text = "VERBAL";
                DdlPartyType.SelectedValue = "LOCAL";
                DdlRegisterType.SelectedValue = "W";
                TxtInvoiceDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                TxtDueDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                GetAccountCode();
                GvStockRecDetails.Enabled = true;
                GvChagresTranDetails.Enabled = true;




                string INV_Number = REC_ISS_MLogicLayer.GetInvoiceNumber(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), HfTranType.Value.ToString(), HfTrnType.Value.ToString(), Convert.ToDateTime(TxtInvoiceDate.Text.Trim()).ToString("yyyy-MM-dd"));
                if (INV_Number.Length <= 8)
                {
                    TxtInvoiceNo.Text = INV_Number;
                    TxtInvoiceNo.Enabled = false;
                }
                else
                {
                    TxtInvoiceNo.Text = string.Empty;
                }

                if (HfTrnType.Value.ToString() == "C" || HfTrnType.Value.ToString() == "M" || HfTrnType.Value.ToString() == "T")
                {
                    ViewState["CurrentTable"] = null;
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

        protected void TxtInvoiceDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string INV_Number = REC_ISS_MLogicLayer.GetInvoiceNumber(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), HfTranType.Value.ToString(), HfTrnType.Value.ToString(), Convert.ToDateTime(TxtInvoiceDate.Text.Trim()).ToString("yyyy-MM-dd"));
                if (INV_Number.Length <= 8)
                {
                    TxtInvoiceNo.Text = INV_Number;
                    TxtInvoiceNo.Enabled = false;
                }
                else
                {
                    TxtInvoiceNo.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }






        protected void GvStockRecDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }



        protected void GvStockRecDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField HfDetailSCode = (e.Row.FindControl("HfDetailSCode") as HiddenField);
                    HiddenField HfAmount = (e.Row.FindControl("HfAmount") as HiddenField);
                    HiddenField HfGrossAmount = (e.Row.FindControl("HfGrossAmount") as HiddenField);
                    TextBox TxtProductName = (e.Row.FindControl("TxtProductName") as TextBox);
                    TextBox TxtProductCode = (e.Row.FindControl("TxtProductCode") as TextBox);

                    TextBox TxtChallanNo = (e.Row.FindControl("TxtChallanNo") as TextBox);
                    TextBox TxtChallanDate = (e.Row.FindControl("TxtChallanDate") as TextBox);
                    TextBox TxtGRNNo = (e.Row.FindControl("TxtGRNNo") as TextBox);
                    TextBox TxtHSNCode = (e.Row.FindControl("TxtHSNCode") as TextBox);
                    TextBox TxtProductDescrption = (e.Row.FindControl("TxtProductDescrption") as TextBox);
                    TextBox TxtQty = (e.Row.FindControl("TxtQty") as TextBox);
                    TextBox TxtRate = (e.Row.FindControl("TxtRate") as TextBox);
                    TextBox TxtDisRate = (e.Row.FindControl("TxtDisRate") as TextBox);
                    TextBox TxtCGSTRate = (e.Row.FindControl("TxtCGSTRate") as TextBox);
                    TextBox TxtCGSTAmount = (e.Row.FindControl("TxtCGSTAmount") as TextBox);
                    TextBox TxtSGSTRate = (e.Row.FindControl("TxtSGSTRate") as TextBox);
                    TextBox TxtSGSTAmount = (e.Row.FindControl("TxtSGSTAmount") as TextBox);
                    TextBox TxtIGSTRate = (e.Row.FindControl("TxtIGSTRate") as TextBox);
                    TextBox TxtIGSTAmount = (e.Row.FindControl("TxtIGSTAmount") as TextBox);
                    TextBox TxtTotalAmount = (e.Row.FindControl("TxtTotalAmount") as TextBox);

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

                        }
                    }



                    if (Session["WORK_VIEWFLAG"].ToString() == "B")
                    {

                        TxtProductName.Enabled = false;
                        TxtProductCode.Enabled = false;
                        TxtQty.Enabled = false;
                    }
                    else
                    {
                        TxtProductName.Enabled = true;
                        TxtProductCode.Enabled = true;
                        TxtQty.Enabled = true;
                    }

                    if (HfTranType.Value == "S" && HfTrnType.Value == "P")
                    {

                        TxtProductName.Enabled = true;
                        TxtProductCode.Enabled = true;
                        TxtProductDescrption.Enabled = true;
                        TxtChallanNo.Enabled = false;
                        TxtChallanDate.Enabled = false;
                        TxtGRNNo.Enabled = false;
                        TxtHSNCode.Enabled = false;
                        TxtQty.Enabled = true;
                        TxtRate.Enabled = true;
                        TxtDisRate.Enabled = true;
                        TxtCGSTRate.Enabled = false;
                        TxtCGSTAmount.Enabled = false;
                        TxtSGSTRate.Enabled = false;
                        TxtSGSTAmount.Enabled = false;
                        TxtIGSTRate.Enabled = false;
                        TxtIGSTAmount.Enabled = false;
                        TxtTotalAmount.Enabled = false;
                        GvStockRecDetails.Columns[18].Visible = true;
                    }

                    if (HfTranType.Value == "S" && HfTrnType.Value == "T")
                    {

                        TxtProductName.Enabled = false;
                        TxtProductCode.Enabled = false;
                        TxtProductDescrption.Enabled = true;
                        TxtChallanNo.Enabled = false;
                        TxtChallanDate.Enabled = false;
                        TxtGRNNo.Enabled = false;
                        TxtHSNCode.Enabled = false;
                        TxtQty.Enabled = false;
                        TxtRate.Enabled = true;
                        TxtDisRate.Enabled = true;
                        TxtCGSTRate.Enabled = false;
                        TxtCGSTAmount.Enabled = false;
                        TxtSGSTRate.Enabled = false;
                        TxtSGSTAmount.Enabled = false;
                        TxtIGSTRate.Enabled = false;
                        TxtIGSTAmount.Enabled = false;
                        TxtTotalAmount.Enabled = false;
                        GvStockRecDetails.Columns[18].Visible = false;


                    }

                    if (HfTranType.Value == "S" && HfTrnType.Value == "R")
                    {
                        TxtProductName.Enabled = true;
                        TxtProductCode.Enabled = true;
                        TxtProductDescrption.Enabled = true;
                        TxtChallanNo.Enabled = false;
                        TxtChallanDate.Enabled = false;
                        TxtGRNNo.Enabled = false;
                        TxtHSNCode.Enabled = false;
                        TxtQty.Enabled = true;
                        TxtRate.Enabled = true;
                        TxtDisRate.Enabled = true;
                        TxtCGSTRate.Enabled = false;
                        TxtCGSTAmount.Enabled = false;
                        TxtSGSTRate.Enabled = false;
                        TxtSGSTAmount.Enabled = false;
                        TxtIGSTRate.Enabled = false;
                        TxtIGSTAmount.Enabled = false;
                        TxtTotalAmount.Enabled = false;
                        GvStockRecDetails.Columns[18].Visible = true;

                    }


                    else if (HfTranType.Value == "S" && HfTrnType.Value == "M")
                    {
                        TxtProductName.Enabled = false;
                        TxtProductCode.Enabled = false;
                        TxtProductDescrption.Enabled = true;
                        TxtChallanNo.Enabled = false;
                        TxtChallanDate.Enabled = false;
                        TxtGRNNo.Enabled = false;
                        TxtHSNCode.Enabled = false;
                        TxtQty.Enabled = false;
                        TxtRate.Enabled = true;
                        TxtDisRate.Enabled = true;
                        TxtCGSTRate.Enabled = false;
                        TxtCGSTAmount.Enabled = false;
                        TxtSGSTRate.Enabled = false;
                        TxtSGSTAmount.Enabled = false;
                        TxtIGSTRate.Enabled = false;
                        TxtIGSTAmount.Enabled = false;
                        TxtTotalAmount.Enabled = false;
                        GvStockRecDetails.Columns[18].Visible = false;

                    }

                    else if (HfTranType.Value == "S" && HfTrnType.Value == "C")
                    {
                        TxtProductName.Enabled = false;
                        TxtProductCode.Enabled = false;
                        TxtProductDescrption.Enabled = true;
                        TxtChallanNo.Enabled = false;
                        TxtChallanDate.Enabled = false;
                        TxtGRNNo.Enabled = false;
                        TxtHSNCode.Enabled = false;
                        TxtQty.Enabled = false;
                        TxtRate.Enabled = true;
                        TxtDisRate.Enabled = true;
                        TxtCGSTRate.Enabled = false;
                        TxtCGSTAmount.Enabled = false;
                        TxtSGSTRate.Enabled = false;
                        TxtSGSTAmount.Enabled = false;
                        TxtIGSTRate.Enabled = false;
                        TxtIGSTAmount.Enabled = false;
                        TxtTotalAmount.Enabled = false;
                        GvStockRecDetails.Columns[18].Visible = false;

                    }


                    HfGrossAmount.Value = HfAmount.Value;

                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblSumTotalQty = (Label)e.Row.FindControl("lblSumTotalQty");
                    Label lblCGSTSumTotalAmount = (Label)e.Row.FindControl("lblCGSTSumTotalAmount");
                    Label lblSGSTSumTotalAmount = (Label)e.Row.FindControl("lblSGSTSumTotalAmount");
                    Label lblIGSTSumTotalAmount = (Label)e.Row.FindControl("lblIGSTSumTotalAmount");
                    Label lblSumTotalAmount = (Label)e.Row.FindControl("lblSumTotalAmount");


                    double SumTotalQuantity = TotalQuantity();
                    lblSumTotalQty.Text = SumTotalQuantity.ToString();

                    double SumTotalHfAmount = TotalHfAmt();

                    // double SumTotalGrossAmount = TotalGrossAmount();
                    double SumTotalGrossAmount = TotalHfAmt();

                    double SumTotalCGSTAmount = TotalCGSTAmount();
                    lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                    double SumTotalSGSTAmount = TotalSGSTAmount();
                    lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                    double SumTotalIGSTAmount = TotalIGSTAmount();
                    lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                    double SumTotalAmount = TotalAmount();
                    lblSumTotalAmount.Text = SumTotalAmount.ToString();

                    if (SumTotalGrossAmount.ToString() != string.Empty)
                    {
                        ViewState["GrossAmtCurrentTable_Details"] = SumTotalGrossAmount;
                    }

                    if (lblSumTotalAmount.Text != string.Empty)
                    {

                        ViewState["TotalCurrentTable_Details"] = lblSumTotalAmount.Text.Trim();
                    }

                    if (lblCGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalCGSTAmount_Deatils"] = lblCGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblSGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalSGSTAmount_Deatils"] = lblSGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblIGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalIGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text.Trim();
                    }

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        ViewState["TotalGSTAmount_Deatils"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        ViewState["TotalGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text;
                    }
                    else { }

                    FillNetAmount();
                    TotalAmountCalculationInREC_ISS_M();


                }


            }
            catch (Exception)
            {

                throw;
            }
        }



        #region  BIND STOCK DETAILS GRID

        private void SetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SR", typeof(string));
            table.Columns.Add("REF_TRAN_DATE", typeof(string));
            table.Columns.Add("REF_TRAN_NO", typeof(string));
            table.Columns.Add("REF_SRNO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("PRODUCT_DESC", typeof(string));
            table.Columns.Add("HSN_NO", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("RATE", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("DIS_PER", typeof(string));
            table.Columns.Add("DIS_AMT", typeof(string));
            table.Columns.Add("ADD_DIS_PER", typeof(string));
            table.Columns.Add("ADD_DIS_AMT", typeof(string));
            table.Columns.Add("G_AMT", typeof(string));
            table.Columns.Add("ST_PER", typeof(string));
            table.Columns.Add("ST_AMT", typeof(string));
            table.Columns.Add("ADD_ST_PER", typeof(string));
            table.Columns.Add("ADD_ST_AMT", typeof(string));
            table.Columns.Add("DC_TRAN_DATE", typeof(string));
            table.Columns.Add("DC_TRAN_NO", typeof(string));
            table.Columns.Add("DC_SRNO", typeof(string));
            table.Columns.Add("GST_RATE", typeof(string));
            table.Columns.Add("GST_AMT", typeof(string));
            table.Columns.Add("CGST_RATE", typeof(string));
            table.Columns.Add("CGST_AMT", typeof(string));
            table.Columns.Add("SGST_RATE", typeof(string));
            table.Columns.Add("SGST_AMT", typeof(string));
            table.Columns.Add("IGST_RATE", typeof(string));
            table.Columns.Add("IGST_AMT", typeof(string));
            table.Columns.Add("T_AMT", typeof(string));
            table.Columns.Add("INV_TRAN_DATE", typeof(string));
            table.Columns.Add("INV_TRAN_NO", typeof(string));
            table.Columns.Add("INV_SR", typeof(string));
            table.Columns.Add("ENTRY_TYPE", typeof(string));
            table.Columns.Add("ENDT", typeof(string));
            table.Columns.Add("ACT_RATE", typeof(string));
            table.Columns.Add("ACT_AMT", typeof(string));
            table.Columns.Add("CAL_RATE", typeof(string));
            table.Columns.Add("CAL_AMT", typeof(string));
            table.Columns.Add("PART_NO", typeof(string));
            table.Columns.Add("ADD_PART_NO", typeof(string));
            table.Columns.Add("PER_QTY_WT", typeof(string));
            table.Columns.Add("TOT_QTY_WT", typeof(string));
            table.Columns.Add("EX_DUTY_AMT", typeof(string));
            table.Columns.Add("EX_CESS_AMT", typeof(string));
            table.Columns.Add("EX_SHCESS_AMT", typeof(string));
            table.Columns.Add("CHA_NO", typeof(string));
            table.Columns.Add("SERIALNO", typeof(string));
            table.Columns.Add("ChallanDate", typeof(string));



            dr = table.NewRow();

            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SR"] = string.Empty;
            dr["REF_TRAN_DATE"] = string.Empty;
            dr["REF_TRAN_NO"] = string.Empty;
            dr["REF_SRNO"] = string.Empty;
            dr["SCODE"] = string.Empty;
            dr["PRODUCT_DESC"] = string.Empty;
            dr["HSN_NO"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["RATE"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["DIS_PER"] = string.Empty;
            dr["DIS_AMT"] = string.Empty;
            dr["ADD_DIS_PER"] = string.Empty;
            dr["ADD_DIS_AMT"] = string.Empty;
            dr["G_AMT"] = string.Empty;
            dr["ST_PER"] = string.Empty;
            dr["ST_AMT"] = string.Empty;
            dr["ADD_ST_PER"] = string.Empty;
            dr["ADD_ST_AMT"] = string.Empty;
            dr["DC_TRAN_DATE"] = string.Empty;
            dr["DC_TRAN_NO"] = string.Empty;
            dr["DC_SRNO"] = string.Empty;
            dr["GST_RATE"] = string.Empty;
            dr["GST_AMT"] = string.Empty;
            dr["CGST_RATE"] = string.Empty;
            dr["CGST_AMT"] = string.Empty;
            dr["SGST_RATE"] = string.Empty;
            dr["SGST_AMT"] = string.Empty;
            dr["IGST_RATE"] = string.Empty;
            dr["IGST_AMT"] = string.Empty;
            dr["T_AMT"] = string.Empty;
            dr["INV_TRAN_DATE"] = string.Empty;
            dr["INV_TRAN_NO"] = string.Empty;
            dr["INV_SR"] = string.Empty;
            dr["ENTRY_TYPE"] = string.Empty;
            dr["ENDT"] = string.Empty;
            dr["ACT_RATE"] = string.Empty;
            dr["ACT_AMT"] = string.Empty;
            dr["CAL_RATE"] = string.Empty;
            dr["CAL_AMT"] = string.Empty;
            dr["PART_NO"] = string.Empty;
            dr["ADD_PART_NO"] = string.Empty;
            dr["PER_QTY_WT"] = string.Empty;
            dr["TOT_QTY_WT"] = string.Empty;
            dr["EX_DUTY_AMT"] = string.Empty;
            dr["EX_CESS_AMT"] = string.Empty;
            dr["EX_SHCESS_AMT"] = string.Empty;
            dr["CHA_NO"] = string.Empty;
            dr["SERIALNO"] = string.Empty;
            dr["ChallanDate"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvStockRecDetails.DataSource = table;
            GvStockRecDetails.DataBind();
        }


        private void AddNewRowToStockGrid()
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



                        Label lblSumTotalQty = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalQty"));
                        Label lblCGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                        Label lblSGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                        Label lblIGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                        Label lblSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalAmount"));


                        HiddenField HfDetailSCode = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        HiddenField HfGSTRate = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                        HiddenField HfGSTAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        HiddenField HfDisAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                        HiddenField HfGrossAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGrossAmount");
                        HiddenField HfEntryType = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfEntryType");


                        TextBox TxtChallanNo = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[1].FindControl("TxtChallanNo");
                        TextBox TxtChallanDate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[2].FindControl("TxtChallanDate");
                        TextBox TxtGRNNo = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[3].FindControl("TxtGRNNo");
                        TextBox TxtProductCode = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[4].FindControl("TxtProductCode");
                        TextBox TxtHSNCode = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[5].FindControl("TxtHSNCode");
                        TextBox TxtProductName = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[6].FindControl("TxtProductName");
                        TextBox TxtProductDescrption = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[7].FindControl("TxtProductDescrption");
                        TextBox TxtQty = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[8].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[9].FindControl("TxtRate");
                        TextBox TxtDisRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[10].FindControl("TxtDisRate");
                        TextBox TxtCGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[11].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[12].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[13].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[14].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[15].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[16].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[17].FindControl("TxtTotalAmount");



                        //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["PRODUCT_DESC"] = TxtProductDescrption.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["HSN_NO"] = TxtHSNCode.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = HfAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["DIS_PER"] = TxtDisRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["DIS_AMT"] = HfDisAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["G_AMT"] = HfGrossAmount.Value.Trim();
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

                        double SumTotalQuantity = TotalQuantity();
                        lblSumTotalQty.Text = SumTotalQuantity.ToString();

                        double SumTotalHfAmount = TotalHfAmt();

                        // double SumTotalGrossAmount = TotalGrossAmount();
                        double SumTotalGrossAmount = TotalHfAmt();

                        double SumTotalCGSTAmount = TotalCGSTAmount();
                        lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                        double SumTotalSGSTAmount = TotalSGSTAmount();
                        lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                        double SumTotalIGSTAmount = TotalIGSTAmount();
                        lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                        double SumTotalAmount = TotalAmount();
                        lblSumTotalAmount.Text = SumTotalAmount.ToString();

                        if (SumTotalGrossAmount.ToString() != string.Empty)
                        {
                            ViewState["GrossAmtCurrentTable_Details"] = SumTotalGrossAmount;
                        }

                        if (lblSumTotalAmount.Text != string.Empty)
                        {

                            ViewState["TotalCurrentTable_Details"] = lblSumTotalAmount.Text.Trim();
                        }

                        if (lblCGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalCGSTAmount_Deatils"] = lblCGSTSumTotalAmount.Text.Trim();
                        }

                        if (lblSGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalSGSTAmount_Deatils"] = lblSGSTSumTotalAmount.Text.Trim();
                        }

                        if (lblIGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalIGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text.Trim();
                        }

                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            ViewState["TotalGSTAmount_Deatils"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            ViewState["TotalGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text;
                        }
                        else { }

                        FillNetAmount();
                        TotalAmountCalculationInREC_ISS_M();
                    }


                    drCurrentRow = dtCurrentTable.NewRow();

                    //drCurrentRow["SR"] = "";
                    drCurrentRow["SCODE"] = "0";
                    drCurrentRow["PRODUCT_DESC"] = "";
                    drCurrentRow["HSN_NO"] = "0";
                    drCurrentRow["RATE"] = "0";
                    drCurrentRow["QTY"] = "0";
                    drCurrentRow["AMT"] = "0";
                    drCurrentRow["DIS_PER"] = "0";
                    drCurrentRow["DIS_AMT"] = "0";
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

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvStockRecDetails.DataSource = dtCurrentTable;
                    GvStockRecDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousDataStock_Grid();
        }

        private void SetPreviousDataStock_Grid()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {



                        Label lblSumTotalQty = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalQty"));
                        Label lblCGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                        Label lblSGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                        Label lblIGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                        Label lblSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalAmount"));


                        HiddenField HfDetailSCode = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        HiddenField HfGSTRate = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                        HiddenField HfGSTAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        HiddenField HfDisAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                        HiddenField HfGrossAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGrossAmount");
                        HiddenField HfEntryType = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfEntryType");


                        TextBox TxtChallanNo = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[1].FindControl("TxtChallanNo");
                        TextBox TxtChallanDate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[2].FindControl("TxtChallanDate");
                        TextBox TxtGRNNo = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[3].FindControl("TxtGRNNo");
                        TextBox TxtProductCode = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[4].FindControl("TxtProductCode");
                        TextBox TxtHSNCode = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[5].FindControl("TxtHSNCode");
                        TextBox TxtProductName = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[6].FindControl("TxtProductName");
                        TextBox TxtProductDescrption = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[7].FindControl("TxtProductDescrption");
                        TextBox TxtQty = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[8].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[9].FindControl("TxtRate");
                        TextBox TxtDisRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[10].FindControl("TxtDisRate");
                        TextBox TxtCGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[11].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[12].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[13].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[14].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[15].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[16].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[17].FindControl("TxtTotalAmount");


                        //TxtSr.Text = Convert.ToString(i + 1);
                        HfDetailSCode.Value = dt.Rows[i]["SCODE"].ToString();
                        TxtProductDescrption.Text = dt.Rows[i]["PRODUCT_DESC"].ToString();
                        TxtHSNCode.Text = dt.Rows[i]["HSN_NO"].ToString();
                        TxtRate.Text = dt.Rows[i]["RATE"].ToString();
                        TxtQty.Text = dt.Rows[i]["QTY"].ToString();
                        HfAmount.Value = dt.Rows[i]["AMT"].ToString();
                        TxtDisRate.Text = dt.Rows[i]["DIS_PER"].ToString();
                        HfDisAmount.Value = dt.Rows[i]["DIS_AMT"].ToString();
                        HfGrossAmount.Value = dt.Rows[i]["G_AMT"].ToString();
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

                        double SumTotalQuantity = TotalQuantity();
                        lblSumTotalQty.Text = SumTotalQuantity.ToString();

                        double SumTotalHfAmount = TotalHfAmt();

                        // double SumTotalGrossAmount = TotalGrossAmount();
                        double SumTotalGrossAmount = TotalHfAmt();

                        double SumTotalCGSTAmount = TotalCGSTAmount();
                        lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                        double SumTotalSGSTAmount = TotalSGSTAmount();
                        lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                        double SumTotalIGSTAmount = TotalIGSTAmount();
                        lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                        double SumTotalAmount = TotalAmount();
                        lblSumTotalAmount.Text = SumTotalAmount.ToString();

                        if (SumTotalGrossAmount.ToString() != string.Empty)
                        {
                            ViewState["GrossAmtCurrentTable_Details"] = SumTotalGrossAmount;
                        }

                        if (lblSumTotalAmount.Text != string.Empty)
                        {

                            ViewState["TotalCurrentTable_Details"] = lblSumTotalAmount.Text.Trim();
                        }

                        if (lblCGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalCGSTAmount_Deatils"] = lblCGSTSumTotalAmount.Text.Trim();
                        }

                        if (lblSGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalSGSTAmount_Deatils"] = lblSGSTSumTotalAmount.Text.Trim();
                        }

                        if (lblIGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalIGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text.Trim();
                        }

                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            ViewState["TotalGSTAmount_Deatils"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            ViewState["TotalGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text;
                        }
                        else { }

                        FillNetAmount();
                        TotalAmountCalculationInREC_ISS_M();


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
                GvStockRecDetails.DataSource = dt;
                GvStockRecDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousDataStock_Grid();
        }

        protected void BtnAddRowModelStockDetailGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToStockGrid();
        }

        #endregion


        #region ADD NEW ROW INTO CHARGES GRID

        private void SetInitialRow_ChargesGrid()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SR", typeof(string));
            table.Columns.Add("CCODE", typeof(string));
            table.Columns.Add("PER", typeof(string));
            table.Columns.Add("SIGN", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("ENDT", typeof(string));
            table.Columns.Add("LAB_DESC", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("ST_PER", typeof(string));
            table.Columns.Add("ST_AMT", typeof(string));
            table.Columns.Add("ADD_ST_PER", typeof(string));
            table.Columns.Add("ADD_ST_AMT", typeof(string));
            table.Columns.Add("HSN_NO", typeof(string));
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
            dr["SR"] = string.Empty;
            dr["CCODE"] = string.Empty;
            dr["PER"] = string.Empty;
            dr["SIGN"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["ENDT"] = string.Empty;
            dr["LAB_DESC"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["ST_PER"] = string.Empty;
            dr["ST_AMT"] = string.Empty;
            dr["ADD_ST_PER"] = string.Empty;
            dr["ADD_ST_AMT"] = string.Empty;
            dr["HSN_NO"] = string.Empty;
            dr["GST_RATE"] = string.Empty;
            dr["GST_AMT"] = string.Empty;
            dr["CGST_RATE"] = string.Empty;
            dr["CGST_AMT"] = string.Empty;
            dr["SGST_RATE"] = string.Empty;
            dr["SGST_AMT"] = string.Empty;
            dr["IGST_RATE"] = string.Empty;
            dr["IGST_AMT"] = string.Empty;
            dr["T_AMT"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["CurrentTable_C"] = table;

            GvChagresTranDetails.DataSource = table;
            GvChagresTranDetails.DataBind();



        }



        private void AddNewRowToGrid_ChargesGrid()
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



                        Label lblSumTotalQty = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalQty"));
                        Label lblSumGrossAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumGrossAmount"));
                        Label lblCGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                        Label lblSGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                        Label lblIGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                        Label lblSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalAmount"));


                        HiddenField HfChargesCode = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfChargesCode");

                        TextBox TxtHSNCode = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[1].FindControl("TxtHSNCode");
                        TextBox TxtChargesName = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[2].FindControl("TxtChargesName");
                        TextBox TxtChargesDescription = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[3].FindControl("TxtChargesDescription");
                        TextBox TxtQty = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[4].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[5].FindControl("TxtRate");
                        TextBox TxtChargesSign = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[6].FindControl("TxtChargesSign");
                        TextBox TxtChargesAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[7].FindControl("TxtChargesAmount");
                        TextBox TxtCGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[8].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[9].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[10].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[11].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[12].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[13].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[14].FindControl("TxtTotalAmount");


                        HiddenField HfGSTRate = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                        HiddenField HfGSTAmount = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");

                        //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["CCODE"] = HfChargesCode.Value.Trim();
                        dtCurrentTable_C.Rows[i - 1]["LAB_DESC"] = TxtChargesDescription.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["PER"] = TxtRate.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["HSN_NO"] = TxtHSNCode.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["SIGN"] = TxtChargesSign.Text.Trim();
                        dtCurrentTable_C.Rows[i - 1]["AMT"] = TxtChargesAmount.Text.Trim();
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
                        double SumTotalQuantity = TotalChargesQuantity();
                        lblSumTotalQty.Text = SumTotalQuantity.ToString();

                        double SumTotalGrossAmt = TotalChargesGrossAmount();
                        lblSumGrossAmount.Text = SumTotalGrossAmt.ToString();

                        double SumTotalCGSTAmount = TotalChargesCGSTAmount();
                        lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                        double SumTotalSGSTAmount = TotalChargesSGSTAmount();
                        lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                        double SumTotalIGSTAmount = TotalChargesIGSTAmount();
                        lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                        double SumTotalAmount = TotalChargesTotalAmount();
                        lblSumTotalAmount.Text = SumTotalAmount.ToString();


                        if (lblSumGrossAmount.Text != string.Empty)
                        {
                            ViewState["TotalChargesAmount_Deatils"] = lblSumGrossAmount.Text;
                        }

                        if (lblSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalCurrentTable_Charges"] = lblSumTotalAmount.Text.Trim();
                        }

                        if (lblCGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalCGSTAmount_Charges"] = lblCGSTSumTotalAmount.Text.Trim();
                        }

                        if (lblSGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalSGSTAmount_Charges"] = lblSGSTSumTotalAmount.Text.Trim();
                        }

                        if (lblIGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalIGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text.Trim();
                        }

                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            ViewState["TotalGSTAmount_Charges"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            ViewState["TotalGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text;
                        }
                        else { }

                        FillNetAmount();
                        TotalAmountCalculationInREC_ISS_M();

                    }

                    drCurrentRow = dtCurrentTable_C.NewRow();
                    //drCurrentRow["SR"] = "";
                    drCurrentRow["CCODE"] = "0";
                    drCurrentRow["LAB_DESC"] = "";
                    drCurrentRow["QTY"] = "0";
                    drCurrentRow["PER"] = "0";
                    drCurrentRow["HSN_NO"] = "0";
                    drCurrentRow["SIGN"] = "";
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

                    GvChagresTranDetails.DataSource = dtCurrentTable_C;
                    GvChagresTranDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousData_ChargesGrid();
        }


        private void SetPreviousData_ChargesGrid()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable_C"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable_C"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        Label lblSumTotalQty = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalQty"));
                        Label lblSumGrossAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumGrossAmount"));
                        Label lblCGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                        Label lblSGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                        Label lblIGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                        Label lblSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalAmount"));

                        HiddenField HfChargesCode = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfChargesCode");

                        TextBox TxtHSNCode = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[1].FindControl("TxtHSNCode");
                        TextBox TxtChargesName = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[2].FindControl("TxtChargesName");
                        TextBox TxtChargesDescription = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[3].FindControl("TxtChargesDescription");
                        TextBox TxtQty = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[4].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[5].FindControl("TxtRate");
                        TextBox TxtChargesSign = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[6].FindControl("TxtChargesSign");
                        TextBox TxtChargesAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[7].FindControl("TxtChargesAmount");
                        TextBox TxtCGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[8].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[9].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[10].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[11].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[12].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[13].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[14].FindControl("TxtTotalAmount");

                        HiddenField HfGSTRate = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                        HiddenField HfGSTAmount = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");

                        //TxtSr.Text = Convert.ToString(i + 1);
                        HfChargesCode.Value = dt.Rows[i]["CCODE"].ToString();
                        TxtChargesDescription.Text = dt.Rows[i]["LAB_DESC"].ToString();
                        TxtQty.Text = dt.Rows[i]["QTY"].ToString();
                        TxtRate.Text = dt.Rows[i]["PER"].ToString();
                        TxtChargesSign.Text = dt.Rows[i]["SIGN"].ToString();
                        TxtHSNCode.Text = dt.Rows[i]["HSN_NO"].ToString();
                        TxtChargesAmount.Text = dt.Rows[i]["AMT"].ToString();
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

                        double SumTotalQuantity = TotalChargesQuantity();
                        lblSumTotalQty.Text = SumTotalQuantity.ToString();

                        double SumTotalGrossAmt = TotalChargesGrossAmount();
                        lblSumGrossAmount.Text = SumTotalGrossAmt.ToString();

                        double SumTotalCGSTAmount = TotalChargesCGSTAmount();
                        lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                        double SumTotalSGSTAmount = TotalChargesSGSTAmount();
                        lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                        double SumTotalIGSTAmount = TotalChargesIGSTAmount();
                        lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                        double SumTotalAmount = TotalChargesTotalAmount();
                        lblSumTotalAmount.Text = SumTotalAmount.ToString();


                        if (lblSumGrossAmount.Text != string.Empty)
                        {
                            ViewState["TotalChargesAmount_Deatils"] = lblSumGrossAmount.Text;
                        }

                        if (lblSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalCurrentTable_Charges"] = lblSumTotalAmount.Text.Trim();
                        }

                        if (lblCGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalCGSTAmount_Charges"] = lblCGSTSumTotalAmount.Text.Trim();
                        }

                        if (lblSGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalSGSTAmount_Charges"] = lblSGSTSumTotalAmount.Text.Trim();
                        }

                        if (lblIGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalIGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text.Trim();
                        }

                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            ViewState["TotalGSTAmount_Charges"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            ViewState["TotalGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text;
                        }
                        else { }

                        FillNetAmount();
                        TotalAmountCalculationInREC_ISS_M();


                    }
                }
            }
        }

        protected void BtnDeleteRowModelChargesDetailGrid_Click(object sender, EventArgs e)
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
                GvChagresTranDetails.DataSource = dt;
                GvChagresTranDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData_ChargesGrid();
        }

        protected void BtnAddRowModelChargesDetailGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid_ChargesGrid();
        }

        #endregion


        #region Calculation In CHARGES Grid

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetChargesName(string prefixText)
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


        public void FillOnGridChargesDetailChanged()
        {
            try
            {
                #region Assign To Charges Grid

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



                            Label lblSumTotalQty = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalQty"));
                            Label lblSumGrossAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumGrossAmount"));
                            Label lblCGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                            Label lblSGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                            Label lblIGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                            Label lblSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalAmount"));


                            HiddenField HfChargesCode = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfChargesCode");

                            TextBox TxtHSNCode = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[1].FindControl("TxtHSNCode");
                            TextBox TxtChargesName = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[2].FindControl("TxtChargesName");
                            TextBox TxtChargesDescription = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[3].FindControl("TxtChargesDescription");
                            TextBox TxtQty = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[4].FindControl("TxtQty");
                            TextBox TxtRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[5].FindControl("TxtRate");
                            TextBox TxtChargesSign = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[6].FindControl("TxtChargesSign");
                            TextBox TxtChargesAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[7].FindControl("TxtChargesAmount");
                            TextBox TxtCGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[8].FindControl("TxtCGSTRate");
                            TextBox TxtCGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[9].FindControl("TxtCGSTAmount");
                            TextBox TxtSGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[10].FindControl("TxtSGSTRate");
                            TextBox TxtSGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[11].FindControl("TxtSGSTAmount");
                            TextBox TxtIGSTRate = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[12].FindControl("TxtIGSTRate");
                            TextBox TxtIGSTAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[13].FindControl("TxtIGSTAmount");
                            TextBox TxtTotalAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[14].FindControl("TxtTotalAmount");


                            HiddenField HfGSTRate = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                            HiddenField HfGSTAmount = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");

                            //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["CCODE"] = HfChargesCode.Value.Trim();
                            dtCurrentTable_C.Rows[i - 1]["LAB_DESC"] = TxtChargesDescription.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["PER"] = TxtRate.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["HSN_NO"] = TxtHSNCode.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["SIGN"] = TxtChargesSign.Text.Trim();
                            dtCurrentTable_C.Rows[i - 1]["AMT"] = TxtChargesAmount.Text.Trim();
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

                HiddenField HfChargesCode = (HiddenField)row.Cells[0].FindControl("HfChargesCode");
                TextBox TxtHSNCode = (TextBox)row.Cells[1].FindControl("TxtHSNCode");
                TextBox TxtChargesName = (TextBox)row.Cells[2].FindControl("TxtChargesName");
                TextBox TxtQty = (TextBox)row.Cells[3].FindControl("TxtQty");
                TextBox TxtRateString = (TextBox)row.Cells[4].FindControl("TxtRate");
                TextBox TxtChargesSign = (TextBox)row.Cells[5].FindControl("TxtChargesSign");
                TextBox TxtCGSTRateString = (TextBox)row.Cells[7].FindControl("TxtCGSTRate");
                TextBox TxtSGSTRateString = (TextBox)row.Cells[8].FindControl("TxtSGSTRate");
                TextBox TxtIGSTRateString = (TextBox)row.Cells[9].FindControl("TxtIGSTRate");

                HiddenField HfGSTRateString = (HiddenField)row.Cells[0].FindControl("HfGSTRate");


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
                        TxtHSNCode.Text = DtView.Rows[0]["HSN_NO"].ToString();
                        TxtChargesSign.Text = DtView.Rows[0]["SIGN"].ToString();
                        TxtRateString.Text = DtView.Rows[0]["PER"].ToString();
                        FillOnGridChargesDetailChanged();

                        if (HfChargesCode.Value != string.Empty && DdlPartyType.SelectedIndex != 0)
                        {
                            DataTable DsStock = CHARGES_MASLogicLayer.CHARGES_MAS_CHARGES_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(HfChargesCode.Value), DdlPartyType.SelectedValue);
                            if (DsStock.Rows.Count > 0)
                            {

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
                            //   TxtRateString.Text = "0";
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

        protected void TxtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                Label lblSumTotalQty = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalQty"));
                Label lblSumGrossAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumGrossAmount"));
                Label lblCGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                Label lblSGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                Label lblIGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                Label lblSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalAmount"));

                TextBox TxtRateString = (TextBox)row.Cells[5].FindControl("TxtRate");
                TextBox TxtChargesAmount = (TextBox)row.Cells[7].FindControl("TxtChargesAmount");


                TextBox T_AMTString = (TextBox)row.Cells[14].FindControl("TxtTotalAmount");
                TextBox CGST_RATEString = (TextBox)row.Cells[8].FindControl("TxtCGSTRate");
                TextBox SGST_RATEString = (TextBox)row.Cells[10].FindControl("TxtSGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[9].FindControl("TxtCGSTAmount");
                TextBox SGST_AMTString = (TextBox)row.Cells[11].FindControl("TxtSGSTAmount");

                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                if (txt.Text.Trim() != string.Empty && TxtRateString.Text.Trim() != string.Empty)
                {
                    TxtChargesAmount.Text = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtRateString.Text.Trim()));



                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Text = ((Convert.ToDouble(TxtChargesAmount.Text.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                        SGST_AMTString.Text = ((Convert.ToDouble(TxtChargesAmount.Text.Trim()) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                        double d;
                        d = ((Convert.ToDouble(TxtChargesAmount.Text.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                        T_AMTString.Text = Convert.ToString(d);

                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        TextBox IGST_RATEString = (TextBox)row.Cells[10].FindControl("TxtIGSTRate");
                        TextBox IGST_AMTString = (TextBox)row.Cells[11].FindControl("TxtIGSTAmount");

                        IGST_AMTString.Text = ((Convert.ToDouble(TxtChargesAmount.Text.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Text;
                        T_AMTString.Text = ((Convert.ToDouble(TxtChargesAmount.Text.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();

                    }



                    double SumTotalQuantity = TotalChargesQuantity();
                    lblSumTotalQty.Text = SumTotalQuantity.ToString();

                    double SumTotalGrossAmt = TotalChargesGrossAmount();
                    lblSumGrossAmount.Text = SumTotalGrossAmt.ToString();

                    double SumTotalCGSTAmount = TotalChargesCGSTAmount();
                    lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                    double SumTotalSGSTAmount = TotalChargesSGSTAmount();
                    lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                    double SumTotalIGSTAmount = TotalChargesIGSTAmount();
                    lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                    double SumTotalAmount = TotalChargesTotalAmount();
                    lblSumTotalAmount.Text = SumTotalAmount.ToString();


                    if (lblSumGrossAmount.Text != string.Empty)
                    {
                        ViewState["TotalChargesAmount_Deatils"] = lblSumGrossAmount.Text;
                    }

                    if (lblSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalCurrentTable_Charges"] = lblSumTotalAmount.Text.Trim();
                    }

                    if (lblCGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalCGSTAmount_Charges"] = lblCGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblSGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalSGSTAmount_Charges"] = lblSGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblIGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalIGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text.Trim();
                    }

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        ViewState["TotalGSTAmount_Charges"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        ViewState["TotalGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text;
                    }
                    else { }

                    FillNetAmount();
                    TotalAmountCalculationInREC_ISS_M();
                    FillOnGridChargesDetailChanged();

                }

                else
                {
                    TxtChargesAmount.Text = Convert.ToString(Convert.ToDouble(0));
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

                Label lblSumTotalQty = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalQty"));
                Label lblSumGrossAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumGrossAmount"));
                Label lblCGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                Label lblSGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                Label lblIGSTSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                Label lblSumTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblSumTotalAmount"));

                TextBox TxtQty = (TextBox)row.Cells[4].FindControl("TxtQty");
                TextBox TxtChargesAmount = (TextBox)row.Cells[7].FindControl("TxtChargesAmount");

                TextBox T_AMTString = (TextBox)row.Cells[14].FindControl("TxtTotalAmount");
                TextBox CGST_RATEString = (TextBox)row.Cells[8].FindControl("TxtCGSTRate");
                TextBox SGST_RATEString = (TextBox)row.Cells[10].FindControl("TxtSGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[9].FindControl("TxtCGSTAmount");
                TextBox SGST_AMTString = (TextBox)row.Cells[11].FindControl("TxtSGSTAmount");

                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                if (TxtQty.Text == string.Empty)
                {
                    TxtQty.Text = "0";
                }


                if (txt.Text.Trim() != string.Empty && TxtQty.Text.Trim() != string.Empty)
                {
                    TxtChargesAmount.Text = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtQty.Text.Trim()));

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Text = ((Convert.ToDouble(TxtChargesAmount.Text.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                        SGST_AMTString.Text = ((Convert.ToDouble(TxtChargesAmount.Text.Trim()) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                        double d;
                        d = ((Convert.ToDouble(TxtChargesAmount.Text.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                        T_AMTString.Text = Convert.ToString(d);

                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        TextBox IGST_RATEString = (TextBox)row.Cells[10].FindControl("TxtIGSTRate");
                        TextBox IGST_AMTString = (TextBox)row.Cells[11].FindControl("TxtIGSTAmount");

                        IGST_AMTString.Text = ((Convert.ToDouble(TxtChargesAmount.Text.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Text;
                        T_AMTString.Text = ((Convert.ToDouble(TxtChargesAmount.Text.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();

                    }


                    double SumTotalQuantity = TotalChargesQuantity();
                    lblSumTotalQty.Text = SumTotalQuantity.ToString();

                    double SumTotalGrossAmt = TotalChargesGrossAmount();
                    lblSumGrossAmount.Text = SumTotalGrossAmt.ToString();

                    double SumTotalCGSTAmount = TotalChargesCGSTAmount();
                    lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                    double SumTotalSGSTAmount = TotalChargesSGSTAmount();
                    lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                    double SumTotalIGSTAmount = TotalChargesIGSTAmount();
                    lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                    double SumTotalAmount = TotalChargesTotalAmount();
                    lblSumTotalAmount.Text = SumTotalAmount.ToString();


                    if (lblSumGrossAmount.Text != string.Empty)
                    {
                        ViewState["TotalChargesAmount_Deatils"] = lblSumGrossAmount.Text;
                    }

                    if (lblSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalCurrentTable_Charges"] = lblSumTotalAmount.Text.Trim();
                    }

                    if (lblCGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalCGSTAmount_Charges"] = lblCGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblSGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalSGSTAmount_Charges"] = lblSGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblIGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalIGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text.Trim();
                    }

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        ViewState["TotalGSTAmount_Charges"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        ViewState["TotalGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text;
                    }
                    else { }

                    FillNetAmount();
                    TotalAmountCalculationInREC_ISS_M();
                    FillOnGridChargesDetailChanged();

                }
                else
                {
                    TxtChargesAmount.Text = Convert.ToString(Convert.ToDouble(0));
                }
            }

            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        protected void GvChagresTranDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvChagresTranDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    HiddenField HfChargesCode = (e.Row.FindControl("HfChargesCode") as HiddenField);
                    TextBox TxtHSNCode = (e.Row.FindControl("TxtHSNCode") as TextBox);
                    TextBox TxtChargesName = (e.Row.FindControl("TxtChargesName") as TextBox);
                    TextBox TxtChargesAmount = (e.Row.FindControl("TxtChargesAmount") as TextBox);
                    TextBox TxtQty = (e.Row.FindControl("TxtQty") as TextBox);
                    TextBox TxtRate = (e.Row.FindControl("TxtRate") as TextBox);
                    TextBox TxtChargesSign = (e.Row.FindControl("TxtChargesSign") as TextBox);


                    DataTable DtChargesName = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();

                    DtChargesName = CHARGES_MASLogicLayer.GetAllCHARGESDetialsForComapnyWise_DDL(Comp_Code);

                    if (HfChargesCode.Value != "0" && HfChargesCode.Value != string.Empty)
                    {
                        DataView Dv = new DataView(DtChargesName);
                        Dv.RowFilter = "CCODE=" + HfChargesCode.Value;
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            TxtChargesName.Text = DtView.Rows[0]["NAME"].ToString();
                            HfChargesCode.Value = DtView.Rows[0]["CCODE"].ToString();
                            TxtHSNCode.Text = DtView.Rows[0]["HSN_NO"].ToString();
                            TxtChargesSign.Text = DtView.Rows[0]["SIGN"].ToString();
                        }
                        else
                        {
                            TxtChargesName.Text = string.Empty;
                            TxtHSNCode.Text = string.Empty;
                            TxtChargesSign.Text = string.Empty;

                        }
                    }

                }


                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblSumTotalQty = (Label)e.Row.FindControl("lblSumTotalQty");
                    Label lblSumGrossAmount = (Label)e.Row.FindControl("lblSumGrossAmount");
                    Label lblCGSTSumTotalAmount = (Label)e.Row.FindControl("lblCGSTSumTotalAmount");
                    Label lblSGSTSumTotalAmount = (Label)e.Row.FindControl("lblSGSTSumTotalAmount");
                    Label lblIGSTSumTotalAmount = (Label)e.Row.FindControl("lblIGSTSumTotalAmount");
                    Label lblSumTotalAmount = (Label)e.Row.FindControl("lblSumTotalAmount");


                    double SumTotalQuantity = TotalChargesQuantity();
                    lblSumTotalQty.Text = SumTotalQuantity.ToString();

                    double SumTotalGrossAmt = TotalChargesGrossAmount();
                    lblSumGrossAmount.Text = SumTotalGrossAmt.ToString();

                    double SumTotalCGSTAmount = TotalChargesCGSTAmount();
                    lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                    double SumTotalSGSTAmount = TotalChargesSGSTAmount();
                    lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                    double SumTotalIGSTAmount = TotalChargesIGSTAmount();
                    lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                    double SumTotalAmount = TotalChargesTotalAmount();
                    lblSumTotalAmount.Text = SumTotalAmount.ToString();


                    if (lblSumGrossAmount.Text != string.Empty)
                    {
                        ViewState["TotalChargesAmount_Deatils"] = lblSumGrossAmount.Text;
                    }

                    if (lblSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalCurrentTable_Charges"] = lblSumTotalAmount.Text.Trim();
                    }

                    if (lblCGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalCGSTAmount_Charges"] = lblCGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblSGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalSGSTAmount_Charges"] = lblSGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblIGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalIGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text.Trim();
                    }

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        ViewState["TotalGSTAmount_Charges"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        ViewState["TotalGSTAmount_Charges"] = lblIGSTSumTotalAmount.Text;
                    }
                    else { }

                    FillNetAmount();
                    TotalAmountCalculationInREC_ISS_M();

                }



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
                #region UPDATE SALES TAX INVOICE DATA
                if (Convert.ToDecimal(TxtNetAmt.Text) > 0)
                {
                    #region INSERT STOCK ISSUE TO BRANCH MASTER

                    REC_ISS_MLogicLayer insert = new REC_ISS_MLogicLayer();

                    insert.COMP_CODE = HfCompCode.Value.Trim();
                    insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                    insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.TRAN_TYPE = HfTranType.Value.Trim().ToUpper();
                    insert.TRN_TYPE = HfTrnType.Value.Trim().ToUpper();
                    insert.TAX_TYPE = "";
                    insert.CRACODE = HfACODECredit.Value.Trim();
                    insert.DRACODE = HfAODEDebit.Value.Trim();
                    insert.SALES_TYPE = "";
                    insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToUpper();
                    insert.PARTY_NAME = "";
                    insert.PARTY_ADD = "";
                    insert.BCODE = HfServicePerson.Value.Trim();
                    insert.BAMT = null;
                    insert.INV_NO = null;
                    insert.INV_NUMBER = TxtInvoiceNo.Text.Trim().ToUpper();
                    insert.INV_DT = Convert.ToDateTime(TxtInvoiceDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    insert.REC_DT = "";
                    if (TxtDueDays.Text == string.Empty)
                    {
                        insert.DUE_DAYS = null;
                    }
                    else
                    {
                        insert.DUE_DAYS = TxtDueDays.Text.Trim().ToUpper();
                    }

                    insert.DUE_DATE = Convert.ToDateTime(TxtDueDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    insert.CHA_NO = "";
                    insert.CHA_DT = "";
                    insert.PO_NO = TxtPONo.Text.Trim();
                    if (TxtPODate.Text == string.Empty)
                    {
                        TxtPODate.Text = "";
                    }
                    else
                    {
                        insert.PO_DT = Convert.ToDateTime(TxtPODate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }

                    insert.VEHICLE_NO = TxtVehclieNo.Text.Trim().ToUpper();
                    insert.GROSS_AMT = HfGridGrossAmount.Value.Trim();
                    insert.RO_AMT = TxtROamt.Text.Trim();
                    insert.NET_AMT = TxtNetAmt.Text.Trim();
                    insert.PAID_AMT = null;
                    insert.STATUS = "O";
                    insert.ENDT = "";
                    insert.DIS_PER = null;
                    insert.DIS_AMT = null;
                    insert.CHARGES_AMT = HfChargesGridTotalAmount.Value.Trim();
                    insert.PAID_TYPE = "";
                    insert.PARTY_TIN = "";
                    insert.TCODE = null;
                    insert.LR_NO = "";
                    insert.LR_DATE = "";
                    insert.PREPARATION_DATE = "";
                    insert.PREPARATION_TIME_HH = null;
                    insert.PREPARATION_TIME_MM = null;
                    insert.REMOVAL_DATE = "";
                    insert.REMOVAL_TIME_HH = null;
                    insert.REMOVAL_TIME_MM = null;
                    insert.CFORM_FLAG = "";
                    insert.CFORM_NO = "";
                    insert.EX_DUTY_PER = null;
                    insert.EX_DUTY_AMT = null;
                    insert.EX_CESS_PER = null;
                    insert.EX_CESS_AMT = null;
                    insert.EX_SHCESS_PER = null;
                    insert.EX_SHCESS_AMT = null;
                    insert.TOT_GROSS_AMT = null;
                    insert.ST_PER = null;
                    insert.ST_AMT = null;
                    insert.ADD_ST_PER = null;
                    insert.ADD_ST_AMT = null;
                    insert.TOT_AMT = "0";
                    insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                    insert.BUYERACODE = null;
                    insert.TRANSPORT = TxtTransportName.Text.Trim().ToUpper();
                    insert.EX_RATE_OF_DUTY = "";
                    insert.FORM_SRNO = null;
                    insert.CHECKPOST_NAME = "";
                    insert.REF_TRAN_DATE = "";
                    insert.REF_TRAN_NO = null;
                    insert.INVBOOK_NO = null;
                    //insert.INS_USERID = Session["USERNAME"].ToString();
                    //insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_DATE = "";
                    insert.INVTYPE = Session["INVTYPE_FLAG"].ToString();
                    insert.RW_CODE = null;
                    insert.FIGURE_FLAG = DdlFigureFlag.SelectedValue.Trim().ToUpper();
                    insert.TAX_CALTYPE = ""; ;
                    insert.TOT_QTY = null;
                    insert.RW_TYPE = "";
                    insert.EX_CYR_PER = null;
                    insert.EX_GROSS_AMT_CYR = null;
                    insert.EX_DUTY_AMT_CYR = null;
                    insert.EX_CESS_AMT_CYR = null;
                    insert.EX_SHCESS_AMT_CYR = null;
                    insert.EX_NYR_PER = null;
                    insert.EX_GROSS_AMT_NYR = null;
                    insert.EX_DUTY_AMT_NYR = null;
                    insert.EX_CESS_AMT_NYR = null;
                    insert.EX_SHCESS_AMT_NYR = null;
                    insert.CHARGES_FLAG = "";
                    insert.BRANCH_CODE = HfBranchCode.Value.Trim();
                    insert.CST_TYPE = DdlRegisterType.SelectedValue.Trim().ToUpper();
                    insert.LESS_AMT = null;
                    insert.TDS_AMT = null;
                    insert.DRIVER_NAME = TxtDriverName.Text.Trim().ToUpper();
                    insert.DRIVER_ADD = TxtDriverAddress.Text.Trim().ToUpper();
                    insert.MDLNO = TxtMDLNo.Text.Trim().ToUpper();
                    insert.MDLSTATE = TxtMDLState.Text.Trim().ToUpper();
                    insert.CONF_FLAG = DdlConfirmFlag.SelectedValue.Trim().ToUpper();
                    if (DdlConfirmFlag.SelectedValue == "Y")
                    {
                        insert.CONF_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CONF_DATE = "";
                    }

                    if (DdlConfirmFlag.SelectedValue == "Y")
                    {
                        insert.CONF_USERID = Session["USERNAME"].ToString();
                    }
                    else
                    {
                        insert.CONF_USERID = "";
                    }

                    insert.CFORM_ISSFLAG = "";
                    insert.CFORM_TRAN_DATE = "";
                    insert.CFORM_TRAN_NO = null;
                    insert.OA_FLAG = "";
                    insert.OA_AMT = HfOtherAmount.Value.Trim();
                    insert.EXCISE_TYPE = "";
                    insert.EXCISE_PRINTFLAG = "";
                    insert.CHARGES_VAT_AMT = null;
                    insert.GST_RATE = null;
                    insert.GST_AMT = HfTotalSumGSTAmount.Value.Trim();
                    insert.CGST_RATE = null;
                    insert.CGST_AMT = HfTotalSumCGSTAmount.Value.Trim();
                    insert.SGST_RATE = null;
                    insert.SGST_AMT = HfTotalSumSGSTAmount.Value.Trim();
                    insert.IGST_RATE = null;
                    insert.IGST_AMT = HfTotalSumIGSTAmount.Value.Trim();
                    insert.CUSTOM_DUTY_AMT = null;
                    insert.CUSTOM_GST_BAMT = null;
                    insert.CUSTOM_GST_RATE = null;
                    insert.CUSTOM_GST_AMT = null;
                    insert.CUSTOM_TOT_AMT = null;
                    insert.INV_TRAN_DATE = "";
                    insert.INV_TRAN_NO = null;
                    insert.INV_REASON = "";
                    insert.EWAY_BILLNO = "";


                    #endregion

                    #region INSERT INTO REC_ISS_T Stock Details

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int SRNODETAIL = 1;
                    foreach (GridViewRow row in GvStockRecDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {

                            HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                            HiddenField HfRefTranDate = row.FindControl("HfRefTranDate") as HiddenField;
                            HiddenField HfRefTranNo = row.FindControl("HfRefTranNo") as HiddenField;
                            HiddenField HfRefSrNo = row.FindControl("HfRefSrNo") as HiddenField;

                            HiddenField HfDC_Trandate = row.FindControl("HfDC_Trandate") as HiddenField;
                            HiddenField HfDC_TranNo = row.FindControl("HfDC_TranNo") as HiddenField;
                            HiddenField HfDC_SrNo = row.FindControl("HfDC_SrNo") as HiddenField;

                            HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                            HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;

                            HiddenField HfAmount = row.FindControl("HfAmount") as HiddenField;
                            HiddenField HfDisAmount = row.FindControl("HfDisAmount") as HiddenField;
                            HiddenField HfGrossAmount = row.FindControl("HfGrossAmount") as HiddenField;
                            HiddenField HfEntryType = row.FindControl("HfEntryType") as HiddenField;

                            TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                            TextBox TxtHSNCode = row.FindControl("TxtHSNCode") as TextBox;
                            TextBox TxtProductDescrption = row.FindControl("TxtProductDescrption") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtDisRate = row.FindControl("TxtDisRate") as TextBox;
                            TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                            TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                            TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                            TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                            TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                            TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                            TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;


                            if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != null && HfDetailSCode.Value != string.Empty)
                            {


                                XmlElement HandleDetail2 = XDoc1.CreateElement("REC_ISS_TDetails");
                                HandleDetail2.SetAttribute("SR", SRNODETAIL.ToString());
                                HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                if (HfDetailSCode.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SCODE", null);
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value));
                                }

                                if (TxtHSNCode.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("HSN_NO", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("HSN_NO", (TxtHSNCode.Text));
                                }

                                if (TxtProductDescrption.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("PRODUCT_DESC", (""));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("PRODUCT_DESC", (TxtProductDescrption.Text));
                                }

                                if (HfRefTranDate.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("REF_TRAN_DATE", (Convert.ToDateTime(HfRefTranDate.Value).ToString("MM-dd-yyyy")));
                                }


                                if (HfRefTranNo.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("REF_TRAN_NO", (HfRefTranNo.Value.Trim()));
                                }


                                if (HfRefSrNo.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("REF_SRNO", (HfRefSrNo.Value.Trim()));
                                }


                                if (TxtQty.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("QTY", (TxtQty.Text.Trim()));
                                }

                                if (TxtRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("RATE", (TxtRate.Text.Trim()));
                                }

                                if (HfAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("AMT", (HfAmount.Value.Trim()));
                                }


                                if (TxtDisRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DIS_PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("DIS_PER", (TxtDisRate.Text.Trim()));
                                }

                                if (HfDisAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DIS_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("DIS_AMT", (HfDisAmount.Value.Trim()));
                                }

                                if (HfGrossAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("G_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("G_AMT", (HfGrossAmount.Value.Trim()));
                                }

                                if (HfGSTRate.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("GST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("GST_RATE", (HfGSTRate.Value.Trim()));
                                }

                                if (HfGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("GST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("GST_AMT", (HfGSTAmount.Value.Trim()));
                                }

                                if (TxtCGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CGST_RATE", (TxtCGSTRate.Text.Trim()));
                                }

                                if (TxtCGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text.Trim()));
                                }

                                if (TxtSGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SGST_RATE", (TxtSGSTRate.Text.Trim()));
                                }

                                if (TxtSGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text.Trim()));
                                }

                                if (TxtIGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("IGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("IGST_RATE", (TxtIGSTRate.Text.Trim()));
                                }

                                if (TxtIGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("IGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text.Trim()));
                                }

                                if (TxtTotalAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("T_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("T_AMT", (TxtTotalAmount.Text.Trim()));
                                }

                                HandleDetail2.SetAttribute("ENTRY_TYPE", (HfEntryType.Value.Trim().ToString()));

                                if (HfDC_Trandate.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DC_TRAN_DATE", (Convert.ToDateTime(HfDC_Trandate.Value).ToString("MM-dd-yyyy")));
                                }


                                if (HfDC_TranNo.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DC_TRAN_NO", (HfDC_TranNo.Value.Trim()));
                                }

                                if (HfDC_SrNo.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DC_SRNO", (HfDC_SrNo.Value.Trim()));
                                }


                                root1.AppendChild(HandleDetail2);
                                SRNODETAIL++;

                            }

                        }
                    }


                    #endregion

                    #region INSERT CHARGES INTO GRID REC_ISS_C

                    XmlDocument XDoc2 = new XmlDocument();
                    XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                    XDoc2.AppendChild(dec2);// Create the root element
                    XmlElement root2 = XDoc2.CreateElement("root");
                    XDoc2.AppendChild(root2);
                    int CHARGES_SRNO = 1;

                    foreach (GridViewRow row in GvChagresTranDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {


                            HiddenField HfChargesCode = row.FindControl("HfChargesCode") as HiddenField;
                            HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                            HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;

                            TextBox TxtHSNCode = row.FindControl("TxtHSNCode") as TextBox;
                            TextBox TxtChargesName = row.FindControl("TxtChargesName") as TextBox;
                            TextBox TxtChargesDescription = row.FindControl("TxtChargesDescription") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtChargesSign = row.FindControl("TxtChargesSign") as TextBox;
                            TextBox TxtChargesAmount = row.FindControl("TxtChargesAmount") as TextBox;
                            TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                            TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                            TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                            TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                            TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                            TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                            TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;



                            if (HfChargesCode.Value != "0" && HfChargesCode.Value != null && HfChargesCode.Value != string.Empty)
                            {

                                XmlElement HandleDetail3 = XDoc2.CreateElement("REC_ISS_ChargesDetails");
                                HandleDetail3.SetAttribute("SR", CHARGES_SRNO.ToString());
                                HandleDetail3.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                HandleDetail3.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                HandleDetail3.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                HandleDetail3.SetAttribute("CCODE", (HfChargesCode.Value.Trim()));

                                if (TxtChargesDescription.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("LAB_DESC", (""));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("LAB_DESC", (TxtChargesDescription.Text));
                                }

                                if (TxtRate.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("PER", (TxtRate.Text));
                                }

                                HandleDetail3.SetAttribute("SIGN", (TxtChargesSign.Text.Trim()));
                                HandleDetail3.SetAttribute("HSN_NO", (TxtHSNCode.Text.Trim()));

                                if (TxtQty.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("QTY", (TxtQty.Text));
                                }

                                if (TxtChargesAmount.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("AMT", (TxtChargesAmount.Text));
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
                                CHARGES_SRNO++;

                            }

                        }
                    }


                    #endregion

                    #region INSERT BARCODE DETAILS INTO DC_MAS_BARCODE TABLE

                    XmlDocument XDoc3 = new XmlDocument();
                    XmlDeclaration dec3 = XDoc3.CreateXmlDeclaration("1.0", null, null);
                    XDoc3.AppendChild(dec3);// Create the root element
                    XmlElement root3 = XDoc3.CreateElement("root");
                    XDoc3.AppendChild(root3);
                    int SRNOBARCODE = 1;

                    if (ViewState["BarcodeTemp"] != null)
                    {
                        DataTable DtBarcodeTemp = (DataTable)ViewState["BarcodeTemp"];
                        if (DtBarcodeTemp.Rows.Count > 0)
                        {
                            for (int i = 0; i < DtBarcodeTemp.Rows.Count; i++)
                            {

                                XmlElement HandleDetail4 = XDoc3.CreateElement("REC_BarcodeDetails");

                                if (DtBarcodeTemp.Rows[i]["BARCODE"].ToString() != string.Empty)
                                {
                                    HandleDetail4.SetAttribute("SRNO", SRNOBARCODE.ToString());
                                    HandleDetail4.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                    HandleDetail4.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                    HandleDetail4.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());


                                    HandleDetail4.SetAttribute("BAR_TRAN_DATE", Convert.ToDateTime(DtBarcodeTemp.Rows[i]["BAR_TRAN_DATE"].ToString()).ToString("MM-dd-yyyy"));


                                    if (DtBarcodeTemp.Rows[i]["BAR_TRAN_NO"].ToString() == string.Empty)
                                    {
                                        HandleDetail4.SetAttribute("BAR_TRAN_NO", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail4.SetAttribute("BAR_TRAN_NO", (DtBarcodeTemp.Rows[i]["BAR_TRAN_NO"].ToString()));
                                    }


                                    if (DtBarcodeTemp.Rows[i]["BAR_SRNO"].ToString() == string.Empty)
                                    {
                                        HandleDetail4.SetAttribute("BAR_SRNO", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail4.SetAttribute("BAR_SRNO", (DtBarcodeTemp.Rows[i]["BAR_SRNO"].ToString()));
                                    }

                                    if (DtBarcodeTemp.Rows[i]["QTY"].ToString() == string.Empty)
                                    {
                                        HandleDetail4.SetAttribute("QTY", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail4.SetAttribute("QTY", (DtBarcodeTemp.Rows[i]["QTY"].ToString()));
                                    }

                                    root3.AppendChild(HandleDetail4);
                                    SRNOBARCODE++;
                                }
                            }
                        }
                    }

                    #endregion

                    #region INSERT DC MASTER REC ISSUE DETAIL

                    XmlDocument XDocDC = new XmlDocument();
                    XmlDeclaration decDC = XDocDC.CreateXmlDeclaration("1.0", null, null);
                    XDocDC.AppendChild(decDC);// Create the root element
                    XmlElement rootDC = XDocDC.CreateElement("root");
                    XDocDC.AppendChild(rootDC);
                    int SRNODCMASTER = 1;
                    if (ViewState["AddChallanTable"] != null)
                    {
                        DataTable DtDCMASter = (DataTable)ViewState["AddChallanTable"];
                        if (DtDCMASter.Rows.Count > 0)
                        {
                            for (int m = 0; m < DtDCMASter.Rows.Count; m++)
                            {
                                XmlElement HandleDetailDC = XDocDC.CreateElement("REC_M_DCMAS");
                                HandleDetailDC.SetAttribute("SRNO", SRNODCMASTER.ToString());
                                HandleDetailDC.SetAttribute("DC_TRAN_DATE", (Convert.ToDateTime(DtDCMASter.Rows[m]["DCTransDate"].ToString()).ToString("MM-dd-yyyy")));
                                HandleDetailDC.SetAttribute("DC_TRAN_NO", DtDCMASter.Rows[m]["DCTransNo"].ToString());
                                rootDC.AppendChild(HandleDetailDC);
                                SRNODCMASTER++;
                            }
                        }
                    }
                    #endregion

                    string str = REC_ISS_MLogicLayer.UpdateREC_ISS_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml), validation.RSC(XDoc3.OuterXml), validation.RSC(XDocDC.OuterXml), HfCompCode.Value, HfBranchCode.Value, Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"), HfTranType.Value.ToString(), HfTrnType.Value.ToString());

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "SALES TAX INVOICE MASTER UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillREC_ISS_MasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "SALES TAX INVOICE MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : SALES TAX INVOICE MASTER NOT SAVED";
                        lblmsg.ForeColor = Color.Red;

                    }
                }
                else
                {
                    lblmsg.Text = "ERROR : Items Details must be input..!";
                    lblmsg.ForeColor = Color.Red;

                }


                #endregion
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

                    #region INSERT REC_ISS_M  DETAILS

                    REC_ISS_MLogicLayer insert = new REC_ISS_MLogicLayer();

                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    //insert.TRAN_DATE = HfTranDate.Value.Trim();
                    //insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.TRAN_TYPE = HfTranType.Value.Trim().ToUpper();
                    insert.TRN_TYPE = HfTrnType.Value.Trim().ToUpper();
                    insert.TAX_TYPE = "";
                    insert.CRACODE = HfACODECredit.Value.Trim();
                    insert.DRACODE = HfAODEDebit.Value.Trim();
                    insert.SALES_TYPE = "";
                    insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToUpper();
                    insert.PARTY_NAME = "";
                    insert.PARTY_ADD = "";
                    insert.BCODE = HfServicePerson.Value.Trim();
                    insert.BAMT = null;
                    insert.INV_NO = null;
                    insert.INV_NUMBER = TxtInvoiceNo.Text.Trim().ToUpper();
                    insert.INV_DT = Convert.ToDateTime(TxtInvoiceDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    insert.REC_DT = "";
                    if (TxtDueDays.Text == string.Empty)
                    {
                        insert.DUE_DAYS = null;
                    }
                    else
                    {
                        insert.DUE_DAYS = TxtDueDays.Text.Trim().ToUpper();
                    }

                    insert.DUE_DATE = Convert.ToDateTime(TxtDueDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    insert.CHA_NO = "";
                    insert.CHA_DT = "";
                    insert.PO_NO = TxtPONo.Text.Trim();
                    if (TxtPODate.Text == string.Empty)
                    {
                        TxtPODate.Text = "";
                    }
                    else
                    {
                        insert.PO_DT = Convert.ToDateTime(TxtPODate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }

                    insert.VEHICLE_NO = TxtVehclieNo.Text.Trim().ToUpper();
                    insert.GROSS_AMT = HfGridGrossAmount.Value.Trim();
                    insert.RO_AMT = TxtROamt.Text.Trim();
                    insert.NET_AMT = TxtNetAmt.Text.Trim();
                    insert.PAID_AMT = null;
                    insert.STATUS = "O";
                    insert.ENDT = "";
                    insert.DIS_PER = null;
                    insert.DIS_AMT = null;
                    insert.CHARGES_AMT = HfChargesGridTotalAmount.Value.Trim();
                    insert.PAID_TYPE = "";
                    insert.PARTY_TIN = "";
                    insert.TCODE = null;
                    insert.LR_NO = "";
                    insert.LR_DATE = "";
                    insert.PREPARATION_DATE = "";
                    insert.PREPARATION_TIME_HH = null;
                    insert.PREPARATION_TIME_MM = null;
                    insert.REMOVAL_DATE = "";
                    insert.REMOVAL_TIME_HH = null;
                    insert.REMOVAL_TIME_MM = null;
                    insert.CFORM_FLAG = "";
                    insert.CFORM_NO = "";
                    insert.EX_DUTY_PER = null;
                    insert.EX_DUTY_AMT = null;
                    insert.EX_CESS_PER = null;
                    insert.EX_CESS_AMT = null;
                    insert.EX_SHCESS_PER = null;
                    insert.EX_SHCESS_AMT = null;
                    insert.TOT_GROSS_AMT = null;
                    insert.ST_PER = null;
                    insert.ST_AMT = null;
                    insert.ADD_ST_PER = null;
                    insert.ADD_ST_AMT = null;
                    insert.TOT_AMT = "0";
                    insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                    insert.BUYERACODE = null;
                    insert.TRANSPORT = TxtTransportName.Text.Trim().ToUpper();
                    insert.EX_RATE_OF_DUTY = "";
                    insert.FORM_SRNO = null;
                    insert.CHECKPOST_NAME = "";
                    insert.REF_TRAN_DATE = "";
                    insert.REF_TRAN_NO = null;
                    insert.INVBOOK_NO = null;
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_DATE = "";
                    //insert.UPD_USERID = Session["USERNAME"].ToString();
                    //insert.UPD_DATE = "";
                    insert.INVTYPE = Session["INVTYPE_FLAG"].ToString();
                    insert.RW_CODE = null;
                    insert.FIGURE_FLAG = DdlFigureFlag.SelectedValue.Trim().ToUpper();
                    insert.TAX_CALTYPE = "";
                    insert.TOT_QTY = null;
                    insert.RW_TYPE = "";
                    insert.EX_CYR_PER = null;
                    insert.EX_GROSS_AMT_CYR = null;
                    insert.EX_DUTY_AMT_CYR = null;
                    insert.EX_CESS_AMT_CYR = null;
                    insert.EX_SHCESS_AMT_CYR = null;
                    insert.EX_NYR_PER = null;
                    insert.EX_GROSS_AMT_NYR = null;
                    insert.EX_DUTY_AMT_NYR = null;
                    insert.EX_CESS_AMT_NYR = null;
                    insert.EX_SHCESS_AMT_NYR = null;
                    insert.CHARGES_FLAG = "";
                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                    insert.CST_TYPE = DdlRegisterType.SelectedValue.Trim().ToUpper();
                    insert.LESS_AMT = null;
                    insert.TDS_AMT = null;
                    insert.DRIVER_NAME = TxtDriverName.Text.Trim().ToUpper();
                    insert.DRIVER_ADD = TxtDriverAddress.Text.Trim().ToUpper();
                    insert.MDLNO = TxtMDLNo.Text.Trim().ToUpper();
                    insert.MDLSTATE = TxtMDLState.Text.Trim().ToUpper();
                    insert.CONF_FLAG = DdlConfirmFlag.SelectedValue.Trim().ToUpper();
                    if (DdlConfirmFlag.SelectedValue == "Y")
                    {
                        insert.CONF_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CONF_DATE = "";
                    }

                    if (DdlConfirmFlag.SelectedValue == "Y")
                    {
                        insert.CONF_USERID = Session["USERNAME"].ToString();
                    }
                    else
                    {
                        insert.CONF_USERID = "";
                    }

                    insert.CFORM_ISSFLAG = "";
                    insert.CFORM_TRAN_DATE = "";
                    insert.CFORM_TRAN_NO = null;
                    insert.OA_FLAG = "";
                    insert.OA_AMT = HfOtherAmount.Value.Trim();
                    insert.EXCISE_TYPE = "";
                    insert.EXCISE_PRINTFLAG = "";
                    insert.CHARGES_VAT_AMT = null;
                    insert.GST_RATE = null;
                    insert.GST_AMT = HfTotalSumGSTAmount.Value.Trim();
                    insert.CGST_RATE = null;
                    insert.CGST_AMT = HfTotalSumCGSTAmount.Value.Trim();
                    insert.SGST_RATE = null;
                    insert.SGST_AMT = HfTotalSumSGSTAmount.Value.Trim();
                    insert.IGST_RATE = null;
                    insert.IGST_AMT = HfTotalSumIGSTAmount.Value.Trim();
                    insert.CUSTOM_DUTY_AMT = null;
                    insert.CUSTOM_GST_BAMT = null;
                    insert.CUSTOM_GST_RATE = null;
                    insert.CUSTOM_GST_AMT = null;
                    insert.CUSTOM_TOT_AMT = null;
                    insert.INV_TRAN_DATE = "";
                    insert.INV_TRAN_NO = null;
                    insert.INV_REASON = "";
                    insert.EWAY_BILLNO = "";
                    #endregion

                    #region INSERT INTO REC_ISS_T Stock Details

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int SRNODETAIL = 1;
                    foreach (GridViewRow row in GvStockRecDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {

                            HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                            HiddenField HfRefTranDate = row.FindControl("HfRefTranDate") as HiddenField;
                            HiddenField HfRefTranNo = row.FindControl("HfRefTranNo") as HiddenField;
                            HiddenField HfRefSrNo = row.FindControl("HfRefSrNo") as HiddenField;

                            HiddenField HfDC_Trandate = row.FindControl("HfDC_Trandate") as HiddenField;
                            HiddenField HfDC_TranNo = row.FindControl("HfDC_TranNo") as HiddenField;
                            HiddenField HfDC_SrNo = row.FindControl("HfDC_SrNo") as HiddenField;

                            HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                            HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;

                            HiddenField HfAmount = row.FindControl("HfAmount") as HiddenField;
                            HiddenField HfDisAmount = row.FindControl("HfDisAmount") as HiddenField;
                            HiddenField HfGrossAmount = row.FindControl("HfGrossAmount") as HiddenField;
                            HiddenField HfEntryType = row.FindControl("HfEntryType") as HiddenField;

                            TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                            TextBox TxtHSNCode = row.FindControl("TxtHSNCode") as TextBox;
                            TextBox TxtProductDescrption = row.FindControl("TxtProductDescrption") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtDisRate = row.FindControl("TxtDisRate") as TextBox;
                            TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                            TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                            TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                            TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                            TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                            TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                            TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;


                            if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != null && HfDetailSCode.Value != string.Empty)
                            {


                                XmlElement HandleDetail2 = XDoc1.CreateElement("REC_ISS_TDetails");
                                HandleDetail2.SetAttribute("SR", SRNODETAIL.ToString());
                                HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                if (HfDetailSCode.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SCODE", null);
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value));
                                }

                                if (TxtHSNCode.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("HSN_NO", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("HSN_NO", (TxtHSNCode.Text));
                                }

                                if (TxtProductDescrption.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("PRODUCT_DESC", (""));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("PRODUCT_DESC", (TxtProductDescrption.Text));
                                }

                                if (HfRefTranDate.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("REF_TRAN_DATE", (Convert.ToDateTime(HfRefTranDate.Value).ToString("MM-dd-yyyy")));
                                }


                                if (HfRefTranNo.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("REF_TRAN_NO", (HfRefTranNo.Value.Trim()));
                                }


                                if (HfRefSrNo.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("REF_SRNO", (HfRefSrNo.Value.Trim()));
                                }


                                if (TxtQty.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("QTY", (TxtQty.Text.Trim()));
                                }

                                if (TxtRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("RATE", (TxtRate.Text.Trim()));
                                }

                                if (HfAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("AMT", (HfAmount.Value.Trim()));
                                }


                                if (TxtDisRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DIS_PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("DIS_PER", (TxtDisRate.Text.Trim()));
                                }

                                if (HfDisAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DIS_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("DIS_AMT", (HfDisAmount.Value.Trim()));
                                }

                                if (HfGrossAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("G_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("G_AMT", (HfGrossAmount.Value.Trim()));
                                }

                                if (HfGSTRate.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("GST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("GST_RATE", (HfGSTRate.Value.Trim()));
                                }

                                if (HfGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("GST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("GST_AMT", (HfGSTAmount.Value.Trim()));
                                }

                                if (TxtCGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CGST_RATE", (TxtCGSTRate.Text.Trim()));
                                }

                                if (TxtCGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text.Trim()));
                                }

                                if (TxtSGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SGST_RATE", (TxtSGSTRate.Text.Trim()));
                                }

                                if (TxtSGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text.Trim()));
                                }

                                if (TxtIGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("IGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("IGST_RATE", (TxtIGSTRate.Text.Trim()));
                                }

                                if (TxtIGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("IGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text.Trim()));
                                }

                                if (TxtTotalAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("T_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("T_AMT", (TxtTotalAmount.Text.Trim()));
                                }

                                HandleDetail2.SetAttribute("ENTRY_TYPE", (HfEntryType.Value.Trim().ToString()));

                                if (HfDC_Trandate.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DC_TRAN_DATE", (Convert.ToDateTime(HfDC_Trandate.Value).ToString("MM-dd-yyyy")));
                                }


                                if (HfDC_TranNo.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DC_TRAN_NO", (HfDC_TranNo.Value.Trim()));
                                }

                                if (HfDC_SrNo.Value != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DC_SRNO", (HfDC_SrNo.Value.Trim()));
                                }


                                root1.AppendChild(HandleDetail2);
                                SRNODETAIL++;

                            }

                        }
                    }


                    #endregion


                    #region INSERT CHARGES INTO GRID REC_ISS_C

                    XmlDocument XDoc2 = new XmlDocument();
                    XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                    XDoc2.AppendChild(dec2);// Create the root element
                    XmlElement root2 = XDoc2.CreateElement("root");
                    XDoc2.AppendChild(root2);
                    int CHARGES_SRNO = 1;

                    foreach (GridViewRow row in GvChagresTranDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {


                            HiddenField HfChargesCode = row.FindControl("HfChargesCode") as HiddenField;
                            HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                            HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;

                            TextBox TxtHSNCode = row.FindControl("TxtHSNCode") as TextBox;
                            TextBox TxtChargesName = row.FindControl("TxtChargesName") as TextBox;
                            TextBox TxtChargesDescription = row.FindControl("TxtChargesDescription") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtChargesSign = row.FindControl("TxtChargesSign") as TextBox;
                            TextBox TxtChargesAmount = row.FindControl("TxtChargesAmount") as TextBox;
                            TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                            TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                            TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                            TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                            TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                            TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                            TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;



                            if (HfChargesCode.Value != "0" && HfChargesCode.Value != "" && HfChargesCode.Value != string.Empty)
                            {

                                XmlElement HandleDetail3 = XDoc2.CreateElement("REC_ISS_ChargesDetails");
                                HandleDetail3.SetAttribute("SR", CHARGES_SRNO.ToString());
                                HandleDetail3.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail3.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail3.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                HandleDetail3.SetAttribute("CCODE", (HfChargesCode.Value.Trim()));

                                if (TxtChargesDescription.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("LAB_DESC", (""));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("LAB_DESC", (TxtChargesDescription.Text));
                                }

                                if (TxtRate.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("PER", (TxtRate.Text));
                                }

                                HandleDetail3.SetAttribute("SIGN", (TxtChargesSign.Text.Trim()));
                                HandleDetail3.SetAttribute("HSN_NO", (TxtHSNCode.Text.Trim()));

                                if (TxtQty.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("QTY", (TxtQty.Text));
                                }

                                if (TxtChargesAmount.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("AMT", (TxtChargesAmount.Text));
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
                                CHARGES_SRNO++;

                            }

                        }
                    }


                    #endregion

                    #region INSERT BARCODE DETAILS INTO DC_MAS_BARCODE TABLE

                    XmlDocument XDoc3 = new XmlDocument();
                    XmlDeclaration dec3 = XDoc3.CreateXmlDeclaration("1.0", null, null);
                    XDoc3.AppendChild(dec3);// Create the root element
                    XmlElement root3 = XDoc3.CreateElement("root");
                    XDoc3.AppendChild(root3);
                    int SRNOBARCODE = 1;
                    //foreach (GridViewRow row in GvViewBarcode.Rows)
                    //{
                    //    if (row.RowType == DataControlRowType.DataRow)
                    //    {
                    //        HiddenField HfStockcode = row.FindControl("HfStockcode") as HiddenField;
                    //        HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                    //        HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                    //        HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;
                    //        TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                    //        TextBox TxtQty = row.FindControl("TxtQty") as TextBox;



                    //        XmlElement HandleDetail4 = XDoc3.CreateElement("REC_BarcodeDetails");

                    //        if (TxtBarcode.Text != string.Empty && TxtBarcode.Text != null)
                    //        {
                    //            HandleDetail4.SetAttribute("SRNO", SRNOBARCODE.ToString());
                    //            HandleDetail4.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                    //            //    HandleDetail4.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                    //            //    HandleDetail4.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());


                    //            HandleDetail4.SetAttribute("BAR_TRAN_DATE", Convert.ToDateTime(HfBarTranDate.Value).ToString("MM-dd-yyyy"));


                    //            if (HfBarTranNo.Value == string.Empty)
                    //            {
                    //                HandleDetail4.SetAttribute("BAR_TRAN_NO", ("0"));
                    //            }
                    //            else
                    //            {
                    //                HandleDetail4.SetAttribute("BAR_TRAN_NO", (HfBarTranNo.Value));
                    //            }


                    //            if (HfBarSrNo.Value == string.Empty)
                    //            {
                    //                HandleDetail4.SetAttribute("BAR_SRNO", ("0"));
                    //            }
                    //            else
                    //            {
                    //                HandleDetail4.SetAttribute("BAR_SRNO", (HfBarSrNo.Value));
                    //            }

                    //            if (TxtQty.Text == string.Empty)
                    //            {
                    //                HandleDetail4.SetAttribute("QTY", ("0"));
                    //            }
                    //            else
                    //            {
                    //                HandleDetail4.SetAttribute("QTY", (TxtQty.Text));
                    //           }


                    if (ViewState["BarcodeTemp"] != null)
                    {
                        DataTable DtBarcodeTemp = (DataTable)ViewState["BarcodeTemp"];
                        if (DtBarcodeTemp.Rows.Count > 0)
                        {
                            for (int i = 0; i < DtBarcodeTemp.Rows.Count; i++)
                            {

                                XmlElement HandleDetail4 = XDoc3.CreateElement("REC_BarcodeDetails");

                                if (DtBarcodeTemp.Rows[i]["BARCODE"].ToString() != string.Empty)
                                {
                                    HandleDetail4.SetAttribute("SRNO", SRNOBARCODE.ToString());
                                    HandleDetail4.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                    //    HandleDetail4.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                    //    HandleDetail4.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());


                                    HandleDetail4.SetAttribute("BAR_TRAN_DATE", Convert.ToDateTime(DtBarcodeTemp.Rows[i]["BAR_TRAN_DATE"].ToString()).ToString("MM-dd-yyyy"));


                                    if (DtBarcodeTemp.Rows[i]["BAR_TRAN_NO"].ToString() == string.Empty)
                                    {
                                        HandleDetail4.SetAttribute("BAR_TRAN_NO", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail4.SetAttribute("BAR_TRAN_NO", (DtBarcodeTemp.Rows[i]["BAR_TRAN_NO"].ToString()));
                                    }


                                    if (DtBarcodeTemp.Rows[i]["BAR_SRNO"].ToString() == string.Empty)
                                    {
                                        HandleDetail4.SetAttribute("BAR_SRNO", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail4.SetAttribute("BAR_SRNO", (DtBarcodeTemp.Rows[i]["BAR_SRNO"].ToString()));
                                    }

                                    if (DtBarcodeTemp.Rows[i]["QTY"].ToString() == string.Empty)
                                    {
                                        HandleDetail4.SetAttribute("QTY", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail4.SetAttribute("QTY", (DtBarcodeTemp.Rows[i]["QTY"].ToString()));
                                    }


                                    root3.AppendChild(HandleDetail4);
                                    SRNOBARCODE++;
                                }
                            }
                        }
                    }
                    #endregion

                    #region INSERT DC MASTER REC ISSUE DETAIL

                    XmlDocument XDocDC = new XmlDocument();
                    XmlDeclaration decDC = XDocDC.CreateXmlDeclaration("1.0", null, null);
                    XDocDC.AppendChild(decDC);// Create the root element
                    XmlElement rootDC = XDocDC.CreateElement("root");
                    XDocDC.AppendChild(rootDC);
                    int SRNODCMASTER = 1;
                    if (ViewState["AddChallanTable"] != null)
                    {
                        DataTable DtDCMASter = (DataTable)ViewState["AddChallanTable"];
                        if (DtDCMASter.Rows.Count > 0)
                        {
                            for (int m = 0; m < DtDCMASter.Rows.Count; m++)
                            {
                                XmlElement HandleDetailDC = XDocDC.CreateElement("REC_M_DCMAS");
                                HandleDetailDC.SetAttribute("SRNO", SRNODCMASTER.ToString());
                                HandleDetailDC.SetAttribute("DC_TRAN_DATE", (Convert.ToDateTime(DtDCMASter.Rows[m]["DCTransDate"].ToString()).ToString("MM-dd-yyyy")));
                                HandleDetailDC.SetAttribute("DC_TRAN_NO", DtDCMASter.Rows[m]["DCTransNo"].ToString());
                                rootDC.AppendChild(HandleDetailDC);
                                SRNODCMASTER++;
                            }
                        }
                    }
                    #endregion

                    string str = REC_ISS_MLogicLayer.InsertREC_ISS_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml), validation.RSC(XDoc3.OuterXml), validation.RSC(XDocDC.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"), HfTranType.Value.ToString(), HfTrnType.Value.ToString());

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "SALES TAX INVOICE MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillREC_ISS_MasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "SALES TAX INVOICE MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : SALES TAX INVOICE MASTER NOT SAVED";
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
                    string str = REC_ISS_MLogicLayer.DeleteSREC_ISS_M_DetailsTaxInvoiceByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value.ToString()));
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
                        lblmsg.Text = "Error:Sales Tax Invoice Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillREC_ISS_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillPartyNameOnUpdate(string Id)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Brabch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTWiseComapnyAndBranchForInvoice(Comp_Code, Brabch_Code);


                if (HfAODEDebit.Value.ToString() != "0" && HfAODEDebit.Value != null && HfAODEDebit.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "ACODE=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtPartyNameDebit.Text = DtView.Rows[0]["ANAME"].ToString();
                    HfAODEDebit.Value = DtView.Rows[0]["ACODE"].ToString();
                    TxtGstNo.Text = DtView.Rows[0]["GST_NO"].ToString();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void GvTaxInvoiceMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btnedit = (e.Row.FindControl("btnEdit") as Button);
                    Button btndelete = (e.Row.FindControl("btnDelete") as Button);
                    Label lblchk = (e.Row.FindControl("lblConfirmFlag") as Label);

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
            catch (Exception ex)
            {

                Response.AppendToLog(ex.ToString());
            }
        }

        protected void GvTaxInvoiceMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvTaxInvoiceMaster.PageIndex = e.NewPageIndex;
            FillREC_ISS_MasterGrid(Session["COMP_CODE"].ToString());
            clear();
        }

        protected void GvTaxInvoiceMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ViewState["BarcodeTemp"] = null;
                //ViewState["CurrentTable"] = null;
                //ViewState["CurrentTable_C"] = null;


                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = REC_ISS_MLogicLayer.GetAllIDWiseREC_ISS_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtBarcode = ds.Tables[3];
                        DataTable DtCharges = ds.Tables[2];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            HfTrnType.Value = dt.Rows[0]["TRN_TYPE"].ToString();
                            HfACODECredit.Value = dt.Rows[0]["CRACODE"].ToString();
                            HfAODEDebit.Value = dt.Rows[0]["DRACODE"].ToString();
                            FillPartyNameOnUpdate(dt.Rows[0]["DRACODE"].ToString());
                            TxtPONo.Text = dt.Rows[0]["PO_NO"].ToString();
                            TxtPODate.Text = dt.Rows[0]["PO_DT"].ToString();
                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtDriverName.Text = dt.Rows[0]["DRIVER_NAME"].ToString();
                            TxtDriverAddress.Text = dt.Rows[0]["DRIVER_ADD"].ToString();
                            TxtMDLNo.Text = dt.Rows[0]["MDLNO"].ToString();
                            TxtMDLState.Text = dt.Rows[0]["MDLSTATE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtInvoiceNo.Text = dt.Rows[0]["INV_NUMBER"].ToString();
                            TxtInvoiceDate.Text = Convert.ToDateTime(dt.Rows[0]["INV_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtDueDate.Text = Convert.ToDateTime(dt.Rows[0]["DUE_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtDueDays.Text = dt.Rows[0]["DUE_DAYS"].ToString();
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            // TxtGstNo.Text = dt.Rows[0]["BRANCH_CODE"].ToString();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            DdlRegisterType.SelectedValue = dt.Rows[0]["CST_TYPE"].ToString();
                            DdlFigureFlag.SelectedValue = dt.Rows[0]["FIGURE_FLAG"].ToString();
                            HfServicePerson.Value = dt.Rows[0]["BCODE"].ToString();
                            FillServicePerson(dt.Rows[0]["BCODE"].ToString());
                            TxtJobCardNo.Text = dt.Rows[0]["JOBCARD_NO"].ToString();
                            TxtJobCardDate.Text = dt.Rows[0]["JOBCARD_DATE"].ToString();


                            if (DtDetails.Rows.Count > 0)
                            {
                                GvStockRecDetails.DataSource = DtDetails;
                                GvStockRecDetails.DataBind();
                                GvStockRecDetails.Enabled = false;
                            }

                            if (DtCharges.Rows.Count > 0)
                            {
                                GvChagresTranDetails.DataSource = DtCharges;
                                GvChagresTranDetails.DataBind();
                                GvChagresTranDetails.Enabled = false;
                            }

                            if (DtBarcode.Rows.Count > 0)
                            {
                                ViewState["BarcodeTemp"] = DtBarcode;
                                GvViewBarcode.DataSource = DtBarcode;
                                GvViewBarcode.DataBind();
                            }


                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            Session["TRAN_TYPE"] = HfTranType.Value;
                            Session["TRN_TYPE"] = HfTrnType.Value;


                            btnSave.Visible = false;
                            btnDelete.Visible = true;
                            Btncalldel.Visible = true;
                            BtncallUpd.Visible = false;
                            GvStockRecDetails.Enabled = false;
                            ControllerDisable();
                        }
                    }

                    #endregion
                }


                if (e.CommandName == "Edita")
                {
                    ViewState["CurrentTable"] = null;
                    #region EDIT
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = REC_ISS_MLogicLayer.GetAllIDWiseREC_ISS_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtCharges = ds.Tables[2];
                        DataTable DtBarcode = ds.Tables[3];
                        DataTable DtChallan = ds.Tables[4];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            HfTrnType.Value = dt.Rows[0]["TRN_TYPE"].ToString();
                            HfAODEDebit.Value = dt.Rows[0]["DRACODE"].ToString();
                            HfACODECredit.Value = dt.Rows[0]["CRACODE"].ToString();
                            FillPartyNameOnUpdate(dt.Rows[0]["DRACODE"].ToString());
                            TxtPONo.Text = dt.Rows[0]["PO_NO"].ToString();
                            TxtPODate.Text = dt.Rows[0]["PO_DT"].ToString();
                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtDriverName.Text = dt.Rows[0]["DRIVER_NAME"].ToString();
                            TxtDriverAddress.Text = dt.Rows[0]["DRIVER_ADD"].ToString();
                            TxtMDLNo.Text = dt.Rows[0]["MDLNO"].ToString();
                            TxtMDLState.Text = dt.Rows[0]["MDLSTATE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtInvoiceNo.Text = dt.Rows[0]["INV_NUMBER"].ToString();
                            TxtInvoiceDate.Text = Convert.ToDateTime(dt.Rows[0]["INV_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtDueDate.Text = Convert.ToDateTime(dt.Rows[0]["DUE_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtDueDays.Text = dt.Rows[0]["DUE_DAYS"].ToString();
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            // TxtGstNo.Text = dt.Rows[0]["BRANCH_CODE"].ToString();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            DdlRegisterType.SelectedValue = dt.Rows[0]["CST_TYPE"].ToString();
                            DdlFigureFlag.SelectedValue = dt.Rows[0]["FIGURE_FLAG"].ToString();
                            HfServicePerson.Value = dt.Rows[0]["BCODE"].ToString();
                            FillServicePerson(dt.Rows[0]["BCODE"].ToString());
                            TxtJobCardNo.Text = dt.Rows[0]["JOBCARD_NO"].ToString();
                            TxtJobCardDate.Text = dt.Rows[0]["JOBCARD_DATE"].ToString();


                            if (DtDetails.Rows.Count > 0)
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
                                        table.Columns.Add("SR", typeof(string));
                                        table.Columns.Add("REF_TRAN_DATE", typeof(string));
                                        table.Columns.Add("REF_TRAN_NO", typeof(string));
                                        table.Columns.Add("REF_SRNO", typeof(string));
                                        table.Columns.Add("SCODE", typeof(string));
                                        table.Columns.Add("PRODUCT_DESC", typeof(string));
                                        table.Columns.Add("HSN_NO", typeof(string));
                                        table.Columns.Add("QTY", typeof(string));
                                        table.Columns.Add("RATE", typeof(string));
                                        table.Columns.Add("AMT", typeof(string));
                                        table.Columns.Add("DIS_PER", typeof(string));
                                        table.Columns.Add("DIS_AMT", typeof(string));
                                        table.Columns.Add("ADD_DIS_PER", typeof(string));
                                        table.Columns.Add("ADD_DIS_AMT", typeof(string));
                                        table.Columns.Add("G_AMT", typeof(string));
                                        table.Columns.Add("ST_PER", typeof(string));
                                        table.Columns.Add("ST_AMT", typeof(string));
                                        table.Columns.Add("ADD_ST_PER", typeof(string));
                                        table.Columns.Add("ADD_ST_AMT", typeof(string));
                                        table.Columns.Add("DC_TRAN_DATE", typeof(string));
                                        table.Columns.Add("DC_TRAN_NO", typeof(string));
                                        table.Columns.Add("DC_SRNO", typeof(string));
                                        table.Columns.Add("GST_RATE", typeof(string));
                                        table.Columns.Add("GST_AMT", typeof(string));
                                        table.Columns.Add("CGST_RATE", typeof(string));
                                        table.Columns.Add("CGST_AMT", typeof(string));
                                        table.Columns.Add("SGST_RATE", typeof(string));
                                        table.Columns.Add("SGST_AMT", typeof(string));
                                        table.Columns.Add("IGST_RATE", typeof(string));
                                        table.Columns.Add("IGST_AMT", typeof(string));
                                        table.Columns.Add("T_AMT", typeof(string));
                                        table.Columns.Add("INV_TRAN_DATE", typeof(string));
                                        table.Columns.Add("INV_TRAN_NO", typeof(string));
                                        table.Columns.Add("INV_SR", typeof(string));
                                        table.Columns.Add("ENTRY_TYPE", typeof(string));
                                        table.Columns.Add("ENDT", typeof(string));
                                        table.Columns.Add("ACT_RATE", typeof(string));
                                        table.Columns.Add("ACT_AMT", typeof(string));
                                        table.Columns.Add("CAL_RATE", typeof(string));
                                        table.Columns.Add("CAL_AMT", typeof(string));
                                        table.Columns.Add("PART_NO", typeof(string));
                                        table.Columns.Add("ADD_PART_NO", typeof(string));
                                        table.Columns.Add("PER_QTY_WT", typeof(string));
                                        table.Columns.Add("TOT_QTY_WT", typeof(string));
                                        table.Columns.Add("EX_DUTY_AMT", typeof(string));
                                        table.Columns.Add("EX_CESS_AMT", typeof(string));
                                        table.Columns.Add("EX_SHCESS_AMT", typeof(string));
                                        //table.Columns.Add("CHA_NO", typeof(string));
                                        //table.Columns.Add("SERIALNO", typeof(string));
                                        //table.Columns.Add("ChallanDate", typeof(string));
                                    }
                                }

                                for (int m = 0; m < DtDetails.Rows.Count; m++)
                                {
                                    drm = table.NewRow();

                                    drm["SCODE"] = DtDetails.Rows[m]["SCODE"].ToString();
                                    drm["PRODUCT_DESC"] = DtDetails.Rows[m]["PRODUCT_DESC"].ToString();
                                    drm["HSN_NO"] = DtDetails.Rows[m]["HSN_NO"].ToString();
                                    drm["RATE"] = DtDetails.Rows[m]["RATE"].ToString();
                                    drm["QTY"] = DtDetails.Rows[m]["QTY"].ToString();
                                    drm["AMT"] = DtDetails.Rows[m]["AMT"].ToString();
                                    drm["DIS_PER"] = DtDetails.Rows[m]["DIS_PER"].ToString();
                                    drm["DIS_AMT"] = DtDetails.Rows[m]["DIS_AMT"].ToString();
                                    drm["G_AMT"] = DtDetails.Rows[m]["G_AMT"].ToString();
                                    drm["GST_RATE"] = DtDetails.Rows[m]["GST_RATE"].ToString();
                                    drm["GST_AMT"] = DtDetails.Rows[m]["GST_AMT"].ToString();
                                    drm["CGST_RATE"] = DtDetails.Rows[m]["CGST_RATE"].ToString();
                                    drm["CGST_AMT"] = DtDetails.Rows[m]["CGST_AMT"].ToString();
                                    drm["SGST_RATE"] = DtDetails.Rows[m]["SGST_RATE"].ToString();
                                    drm["SGST_AMT"] = DtDetails.Rows[m]["SGST_AMT"].ToString();
                                    drm["IGST_RATE"] = DtDetails.Rows[m]["IGST_RATE"].ToString();
                                    drm["IGST_AMT"] = DtDetails.Rows[m]["IGST_AMT"].ToString();
                                    drm["T_AMT"] = DtDetails.Rows[m]["T_AMT"].ToString();
                                    table.Rows.Add(drm);
                                }


                                #endregion

                                ViewState["CurrentTable"] = table;
                                GvStockRecDetails.DataSource = DtDetails;
                                GvStockRecDetails.DataBind();
                                GvStockRecDetails.Enabled = true;



                            }

                            if (DtCharges.Rows.Count > 0)
                            {
                                ViewState["CurrentTable_C"] = DtCharges;
                                GvChagresTranDetails.DataSource = DtCharges;
                                GvChagresTranDetails.DataBind();
                                GvChagresTranDetails.Enabled = true;

                            }

                            if (DtBarcode.Rows.Count > 0)
                            {
                                ViewState["BarcodeTemp"] = DtBarcode;
                                GvViewBarcode.DataSource = DtBarcode;
                                GvViewBarcode.DataBind();
                            }


                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            Session["TRAN_TYPE"] = HfTranType.Value;
                            Session["TRN_TYPE"] = HfTrnType.Value;

                            if (DtChallan.Rows.Count > 0)
                            {
                                DataTable tblChallan = new DataTable();


                                #region Define Table

                                DataRow drchallan = null;
                                tblChallan.Columns.Add("DCTransDate", typeof(string));
                                tblChallan.Columns.Add("DCTransNo", typeof(string));

                                #endregion
                                for (int m = 0; m < DtChallan.Rows.Count; m++)
                                {
                                    drchallan = tblChallan.NewRow();
                                    drchallan["DCTransNo"] = DtChallan.Rows[m]["DC_TRAN_NO"].ToString();
                                    drchallan["DCTransDate"] = DtChallan.Rows[m]["DC_TRAN_DATE"].ToString();
                                    tblChallan.Rows.Add(drchallan);
                                }

                                ViewState["AddChallanTable"] = tblChallan;
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
                    UserRights();
                }




                if (e.CommandName == "Viewa")
                {
                    #region SET TEXT ON VIEW
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = REC_ISS_MLogicLayer.GetAllIDWiseREC_ISS_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtCharges = ds.Tables[2];
                        DataTable DtBarcode = ds.Tables[3];


                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfRef_TranDate.Value = dt.Rows[0]["REF_TRAN_DATE"].ToString();
                            HfRef_TranNo.Value = dt.Rows[0]["REF_TRAN_NO"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            HfTrnType.Value = dt.Rows[0]["TRN_TYPE"].ToString();
                            HfACODECredit.Value = dt.Rows[0]["CRACODE"].ToString();
                            HfAODEDebit.Value = dt.Rows[0]["DRACODE"].ToString();
                            FillPartyNameOnUpdate(dt.Rows[0]["DRACODE"].ToString());
                            TxtPONo.Text = dt.Rows[0]["PO_NO"].ToString();
                            TxtPODate.Text = dt.Rows[0]["PO_DT"].ToString();
                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtDriverName.Text = dt.Rows[0]["DRIVER_NAME"].ToString();
                            TxtDriverAddress.Text = dt.Rows[0]["DRIVER_ADD"].ToString();
                            TxtMDLNo.Text = dt.Rows[0]["MDLNO"].ToString();
                            TxtMDLState.Text = dt.Rows[0]["MDLSTATE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtInvoiceNo.Text = dt.Rows[0]["INV_NUMBER"].ToString();
                            TxtInvoiceDate.Text = Convert.ToDateTime(dt.Rows[0]["INV_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtDueDate.Text = Convert.ToDateTime(dt.Rows[0]["DUE_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtDueDays.Text = dt.Rows[0]["DUE_DAYS"].ToString();
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            // TxtGstNo.Text = dt.Rows[0]["BRANCH_CODE"].ToString();
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            DdlRegisterType.SelectedValue = dt.Rows[0]["CST_TYPE"].ToString();
                            DdlFigureFlag.SelectedValue = dt.Rows[0]["FIGURE_FLAG"].ToString();
                            HfServicePerson.Value = dt.Rows[0]["BCODE"].ToString();
                            FillServicePerson(dt.Rows[0]["BCODE"].ToString());
                            TxtJobCardNo.Text = dt.Rows[0]["JOBCARD_NO"].ToString();
                            TxtJobCardDate.Text = dt.Rows[0]["JOBCARD_DATE"].ToString();


                            if (DtDetails.Rows.Count > 0)
                            {
                                GvStockRecDetails.DataSource = DtDetails;
                                GvStockRecDetails.DataBind();
                                GvStockRecDetails.Enabled = false;
                            }

                            if (DtCharges.Rows.Count > 0)
                            {
                                GvChagresTranDetails.DataSource = DtCharges;
                                GvChagresTranDetails.DataBind();
                                GvChagresTranDetails.Enabled = false;
                            }

                            if (DtBarcode.Rows.Count > 0)
                            {
                                ViewState["BarcodeTemp"] = DtBarcode;
                                GvViewBarcode.DataSource = DtBarcode;
                                GvViewBarcode.DataBind();
                            }


                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            Session["TRAN_TYPE"] = HfTranType.Value;
                            Session["TRN_TYPE"] = HfTrnType.Value;

                        }
                    }

                    #endregion
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




        #region Add Challan Process 


        protected void GvAddDeliveryChallan_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }


        protected void GvAddDeliveryChallan_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        //protected void BtnAddChallan_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (HfAODEDebit.Value == string.Empty)
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SelectionAlert", "SelectionAlert()", true);
        //        }
        //        else
        //        {

        //            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelDeliveryChallan", "ShowModelDeliveryChallan()", true);
        //            FillDeliveryChallanGridrPopup();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        //public void FillDeliveryChallanGridrPopup()
        //{
        //    try
        //    {
        //        DataTable Dt = new DataTable();

        //        Dt = DC_MASLogicLayer.GetAllDC_MasWiseComapnyAndACodeForTaxInvoiceBill(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), HfAODEDebit.Value, "D".ToString(), "S".ToString());
        //        GvAddDeliveryChallan.DataSource = Dt;
        //        GvAddDeliveryChallan.DataBind();

        //        if (ViewState["AddChallanTable"] != null)
        //        {
        //            foreach (GridViewRow row in GvAddDeliveryChallan.Rows)
        //            {
        //                if (row.RowType == DataControlRowType.DataRow)
        //                {
        //                    HiddenField HfDCTransDate = row.FindControl("HfDCTransDate") as HiddenField;
        //                    HiddenField HfDCTransNo = row.FindControl("HfDCTransNo") as HiddenField;
        //                    CheckBox ChkChallanNo = row.FindControl("ChkChallanNo") as CheckBox;


        //                    DataTable Dt1 = (DataTable)ViewState["AddChallanTable"];
        //                    if (Dt1.Rows.Count > 0)
        //                    {
        //                        DataView Dv = new DataView(Dt1);
        //                        Dv.RowFilter = "DCTransNo='" + HfDCTransNo.Value + "' and DCTransDate='" + HfDCTransDate.Value + "'";
        //                        DataTable DtFIlter = Dv.ToTable();
        //                        if (DtFIlter.Rows.Count > 0)
        //                        {
        //                            ChkChallanNo.Checked = true;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        //protected void btnAddChallanProcess_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        ViewState["AddChallanTable"] = null;

        //        DataTable tblChallan = new DataTable();


        //        #region Define Table

        //        DataRow drchallan = null;
        //        tblChallan.Columns.Add("DCTransDate", typeof(string));
        //        tblChallan.Columns.Add("DCTransNo", typeof(string));

        //        #endregion


        //        DataTable table = new DataTable();


        //        #region Define Table

        //        DataRow dr = null;
        //        table.Columns.Add("COMP_CODE", typeof(string));
        //        table.Columns.Add("TRAN_DATE", typeof(string));
        //        table.Columns.Add("TRAN_NO", typeof(string));
        //        table.Columns.Add("SR", typeof(string));
        //        table.Columns.Add("REF_TRAN_DATE", typeof(string));
        //        table.Columns.Add("REF_TRAN_NO", typeof(string));
        //        table.Columns.Add("REF_SRNO", typeof(string));
        //        table.Columns.Add("SCODE", typeof(string));
        //        table.Columns.Add("PRODUCT_DESC", typeof(string));
        //        table.Columns.Add("HSN_NO", typeof(string));
        //        table.Columns.Add("QTY", typeof(string));
        //        table.Columns.Add("RATE", typeof(string));
        //        table.Columns.Add("AMT", typeof(string));
        //        table.Columns.Add("DIS_PER", typeof(string));
        //        table.Columns.Add("DIS_AMT", typeof(string));
        //        table.Columns.Add("ADD_DIS_PER", typeof(string));
        //        table.Columns.Add("ADD_DIS_AMT", typeof(string));
        //        table.Columns.Add("G_AMT", typeof(string));
        //        table.Columns.Add("ST_PER", typeof(string));
        //        table.Columns.Add("ST_AMT", typeof(string));
        //        table.Columns.Add("ADD_ST_PER", typeof(string));
        //        table.Columns.Add("ADD_ST_AMT", typeof(string));
        //        table.Columns.Add("DC_TRAN_DATE", typeof(string));
        //        table.Columns.Add("DC_TRAN_NO", typeof(string));
        //        table.Columns.Add("DC_SRNO", typeof(string));
        //        table.Columns.Add("GST_RATE", typeof(string));
        //        table.Columns.Add("GST_AMT", typeof(string));
        //        table.Columns.Add("CGST_RATE", typeof(string));
        //        table.Columns.Add("CGST_AMT", typeof(string));
        //        table.Columns.Add("SGST_RATE", typeof(string));
        //        table.Columns.Add("SGST_AMT", typeof(string));
        //        table.Columns.Add("IGST_RATE", typeof(string));
        //        table.Columns.Add("IGST_AMT", typeof(string));
        //        table.Columns.Add("T_AMT", typeof(string));
        //        table.Columns.Add("INV_TRAN_DATE", typeof(string));
        //        table.Columns.Add("INV_TRAN_NO", typeof(string));
        //        table.Columns.Add("INV_SR", typeof(string));
        //        table.Columns.Add("ENTRY_TYPE", typeof(string));
        //        table.Columns.Add("ENDT", typeof(string));
        //        table.Columns.Add("ACT_RATE", typeof(string));
        //        table.Columns.Add("ACT_AMT", typeof(string));
        //        table.Columns.Add("CAL_RATE", typeof(string));
        //        table.Columns.Add("CAL_AMT", typeof(string));
        //        table.Columns.Add("PART_NO", typeof(string));
        //        table.Columns.Add("ADD_PART_NO", typeof(string));
        //        table.Columns.Add("PER_QTY_WT", typeof(string));
        //        table.Columns.Add("TOT_QTY_WT", typeof(string));
        //        table.Columns.Add("EX_DUTY_AMT", typeof(string));
        //        table.Columns.Add("EX_CESS_AMT", typeof(string));
        //        table.Columns.Add("EX_SHCESS_AMT", typeof(string));
        //        table.Columns.Add("CHA_NO", typeof(string));
        //        table.Columns.Add("SERIALNO", typeof(string));
        //        table.Columns.Add("ChallanDate", typeof(string));
        //        #endregion

        //        foreach (GridViewRow row in GvAddDeliveryChallan.Rows)
        //        {
        //            if (row.RowType == DataControlRowType.DataRow)
        //            {
        //                //Label TxtBarcode = row.FindControl("lblChallanNo") as Label;
        //                //Label lblChallanDate = row.FindControl("lblChallanDate") as Label;
        //                //Label lblGRNNo = row.FindControl("lblGRNNo") as Label;
        //                HiddenField HfDCTransDate = row.FindControl("HfDCTransDate") as HiddenField;
        //                HiddenField HfDCTransNo = row.FindControl("HfDCTransNo") as HiddenField;
        //                CheckBox ChkChallanNo = row.FindControl("ChkChallanNo") as CheckBox;

        //                if (ChkChallanNo.Checked == true)
        //                {
        //                    drchallan = tblChallan.NewRow();
        //                    drchallan["DCTransNo"] = HfDCTransNo.Value.ToString();
        //                    drchallan["DCTransDate"] = HfDCTransDate.Value.ToString();
        //                    tblChallan.Rows.Add(drchallan);


        //                    ViewState["AddChallanTable"] = tblChallan;

        //                    DataSet ds = DC_MASLogicLayer.GetAllIDWiseDC_SALES_MASDetials(HfDCTransNo.Value.ToString(), Convert.ToDateTime(HfDCTransDate.Value.ToString()));
        //                    DataTable dt = ds.Tables[0];
        //                    DataTable DtDetails = ds.Tables[1];


        //                    if (DtDetails.Rows.Count > 0)
        //                    {
        //                        for (int i = 0; i < DtDetails.Rows.Count; i++)
        //                        {

        //                            #region Assign Value to Table

        //                            dr = table.NewRow();

        //                            dr["COMP_CODE"] = DtDetails.Rows[i]["COMP_CODE"].ToString();
        //                            //dr["TRAN_DATE"] = DtDetails.Rows[i]["COMP_CODE"].ToString();
        //                            //dr["TRAN_NO"] = DtDetails.Rows[i]["COMP_CODE"].ToString();
        //                            //dr["SR"] = DtDetails.Rows[i]["COMP_CODE"].ToString();
        //                            dr["REF_TRAN_DATE"] = DtDetails.Rows[i]["ORD_TRAN_DATE"].ToString();
        //                            dr["REF_TRAN_NO"] = DtDetails.Rows[i]["ORD_TRAN_NO"].ToString();
        //                            dr["REF_SRNO"] = DtDetails.Rows[i]["ORD_SRNO"].ToString();
        //                            dr["SCODE"] = DtDetails.Rows[i]["SCODE"].ToString();
        //                            dr["PRODUCT_DESC"] = DtDetails.Rows[i]["PRODUCT_DESC"].ToString();
        //                            dr["HSN_NO"] = DtDetails.Rows[i]["HSN_NO"].ToString();
        //                            dr["QTY"] = DtDetails.Rows[i]["QTY"].ToString();
        //                            dr["RATE"] = DtDetails.Rows[i]["RATE"].ToString();
        //                            dr["AMT"] = DtDetails.Rows[i]["AMT"].ToString();
        //                            dr["DIS_PER"] = DtDetails.Rows[i]["DIS_PER"].ToString();
        //                            dr["DIS_AMT"] = DtDetails.Rows[i]["DIS_AMT"].ToString();
        //                            dr["ADD_DIS_PER"] = string.Empty;
        //                            dr["ADD_DIS_AMT"] = string.Empty;
        //                            dr["G_AMT"] = DtDetails.Rows[i]["G_AMT"].ToString();
        //                            dr["ST_PER"] = string.Empty;
        //                            dr["ST_AMT"] = string.Empty;
        //                            dr["ADD_ST_PER"] = string.Empty;
        //                            dr["ADD_ST_AMT"] = string.Empty;
        //                            dr["DC_TRAN_DATE"] = DtDetails.Rows[i]["TRAN_DATE"].ToString();
        //                            dr["DC_TRAN_NO"] = DtDetails.Rows[i]["TRAN_NO"].ToString();
        //                            dr["DC_SRNO"] = DtDetails.Rows[i]["SRNO"].ToString();
        //                            dr["GST_RATE"] = DtDetails.Rows[i]["GST_RATE"].ToString();
        //                            dr["GST_AMT"] = DtDetails.Rows[i]["GST_AMT"].ToString();
        //                            dr["CGST_RATE"] = DtDetails.Rows[i]["CGST_RATE"].ToString();
        //                            dr["CGST_AMT"] = DtDetails.Rows[i]["CGST_AMT"].ToString();
        //                            dr["SGST_RATE"] = DtDetails.Rows[i]["SGST_RATE"].ToString();
        //                            dr["SGST_AMT"] = DtDetails.Rows[i]["SGST_AMT"].ToString();
        //                            dr["IGST_RATE"] = DtDetails.Rows[i]["IGST_RATE"].ToString();
        //                            dr["IGST_AMT"] = DtDetails.Rows[i]["IGST_AMT"].ToString();
        //                            dr["T_AMT"] = DtDetails.Rows[i]["T_AMT"].ToString();
        //                            dr["INV_TRAN_DATE"] = string.Empty;
        //                            dr["INV_TRAN_NO"] = string.Empty;
        //                            dr["INV_SR"] = string.Empty;
        //                            dr["ENTRY_TYPE"] = DtDetails.Rows[i]["ENTRY_TYPE"].ToString();
        //                            dr["ENDT"] = DtDetails.Rows[i]["ENDT"].ToString();
        //                            dr["ACT_RATE"] = string.Empty;
        //                            dr["ACT_AMT"] = string.Empty;
        //                            dr["CAL_RATE"] = string.Empty;
        //                            dr["CAL_AMT"] = string.Empty;
        //                            dr["PART_NO"] = string.Empty;
        //                            dr["ADD_PART_NO"] = string.Empty;
        //                            dr["PER_QTY_WT"] = string.Empty;
        //                            dr["TOT_QTY_WT"] = string.Empty;
        //                            dr["EX_DUTY_AMT"] = string.Empty;
        //                            dr["EX_CESS_AMT"] = string.Empty;
        //                            dr["EX_SHCESS_AMT"] = string.Empty;
        //                            dr["CHA_NO"] = dt.Rows[0]["CHA_NO"].ToString();
        //                            dr["SERIALNO"] = dt.Rows[0]["SERIALNO"].ToString();
        //                            dr["ChallanDate"] = dt.Rows[0]["CHA_DT"].ToString();

        //                            #endregion

        //                            table.Rows.Add(dr);
        //                        }

        //                        ViewState["CurrentTable"] = table;




        //                    }

        //                }
        //            }

        //        }
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModelDeliveryChallan", "HideModelDeliveryChallan()", true);

        //        GvStockRecDetails.DataSource = table;
        //        GvStockRecDetails.DataBind();

        //        DivEntry.Visible = true;
        //        DivView.Visible = false;


        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        #endregion



        #region BARCODE PROCESS IN STOCK DETAILS


        protected void GvViewBarcode_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }


        //public void FillOnlyViewBarcodePopup()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        if (ViewState["BarcodeTemp"] != null)
        //        {
        //            dt = (DataTable)ViewState["BarcodeTemp"];
        //        }
        //        else
        //        {

        //            dt.Columns.Add("BARCODE", typeof(System.String));
        //            dt.Columns.Add("QTY", typeof(System.String));
        //            dt.Columns.Add("SCODE", typeof(System.String));
        //            dt.Columns.Add("BAR_TRAN_DATE", typeof(System.String));
        //            dt.Columns.Add("BAR_TRAN_NO", typeof(System.String));
        //            dt.Columns.Add("BAR_SRNO", typeof(System.String));

        //            for (int i = 0; i < 10; i++)
        //            {
        //                DataRow dr = dt.NewRow();
        //                dr["BARCODE"] = "";
        //                dr["QTY"] = "";
        //                dr["SCODE"] = "";
        //                dr["BAR_TRAN_DATE"] = "";
        //                dr["BAR_TRAN_NO"] = "";
        //                dr["BAR_SRNO"] = "";
        //                dt.Rows.Add(dr);
        //            }
        //        }

        //        GvViewBarcode.DataSource = dt;
        //        GvViewBarcode.DataBind();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}



        //public void FillViewBarcodePopup(int C)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();


        //        dt.Columns.Add("BARCODE", typeof(System.String));
        //        dt.Columns.Add("QTY", typeof(System.String));
        //        dt.Columns.Add("SCODE", typeof(System.String));
        //        dt.Columns.Add("BAR_TRAN_DATE", typeof(System.String));
        //        dt.Columns.Add("BAR_TRAN_NO", typeof(System.String));
        //        dt.Columns.Add("BAR_SRNO", typeof(System.String));


        //        for (int i = 0; i < 10; i++)
        //        {
        //            DataRow dr = dt.NewRow();
        //            dr["BARCODE"] = "";
        //            dr["QTY"] = "";
        //            dr["SCODE"] = "";
        //            dr["BAR_TRAN_DATE"] = "";
        //            dr["BAR_TRAN_NO"] = "";
        //            dr["BAR_SRNO"] = "";

        //            dt.Rows.Add(dr);
        //        }
        //        if (C == 1)
        //        {
        //            //ViewState["BarcodeTemp"] = dt;
        //        }
        //        GvViewBarcode.DataSource = dt;
        //        GvViewBarcode.DataBind();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //protected void BtnViewBarcode_Click(object sender, EventArgs e)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelViewBarcode", "ShowModelViewBarcode()", true);
        //    FillOnlyViewBarcodePopup();

        //    Button AddNewBracodeBtn = (Button)(GvViewBarcode.FooterRow.FindControl("BtnAddRowModelBarCode_ViewGrid"));

        //    btnAddBarcodeProcess.Visible = false;
        //    btnReturnBarcodeProcess.Visible = false;
        //    AddNewBracodeBtn.Visible = false;
        //}

        //protected void BtnAddBarcode_Click(object sender, EventArgs e)
        //{
        //    ViewState["BarcodeTempNew"] = null;
        //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelViewBarcode", "ShowModelViewBarcode()", true);
        //    FillViewBarcodePopup(1);

        //    btnAddBarcodeProcess.Visible = true;
        //    btnReturnBarcodeProcess.Visible = false;
        //}

        //protected void BtnReturnBarcode_Click(object sender, EventArgs e)
        //{
        //    ViewState["BarcodeTempNew"] = null;
        //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelViewBarcode", "ShowModelViewBarcode()", true);
        //    FillViewBarcodePopup(2);

        //    btnAddBarcodeProcess.Visible = false;
        //    btnReturnBarcodeProcess.Visible = true;

        //}



        //public bool CheckforDuplicates(string[] array)
        //{
        //    var duplicates = array
        //     .GroupBy(p => p)
        //     .Where(g => g.Count() > 1)
        //     .Select(g => g.Key);
        //    return (duplicates.Count() > 0);
        //}
        //public string dupbarcode = "";
        //private void HasDuplicates(string[] arrayList)
        //{
        //    List<string> vals = new List<string>();
        //    foreach (string s in arrayList)
        //    {
        //        if (vals.Contains(s))
        //        {
        //            dupbarcode = dupbarcode + s + ",";
        //        }
        //        vals.Add(s);
        //    }
        //}


        //protected void btnAddBarcodeProcess_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        List<string> list = new List<string>();
        //        foreach (GridViewRow row in GvViewBarcode.Rows)
        //        {
        //            if (row.RowType == DataControlRowType.DataRow)
        //            {
        //                TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
        //                HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
        //                HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
        //                HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;

        //                if (TxtBarcode.Text == "")
        //                {

        //                }
        //                else
        //                {
        //                    list.Add(TxtBarcode.Text);
        //                }
        //            }
        //        }

        //        string[] name = list.ToArray();

        //        HasDuplicates(name);
        //        if (dupbarcode == "")
        //        {
        //            DataTable DtBarcodeTemp = new DataTable();
        //            if (ViewState["BarcodeTemp"] != null)
        //            {
        //                DtBarcodeTemp = (DataTable)ViewState["BarcodeTemp"];
        //            }
        //            else
        //            {
        //                DtBarcodeTemp.Columns.Add("BARCODE", typeof(string));
        //                DtBarcodeTemp.Columns.Add("QTY", typeof(string));
        //                DtBarcodeTemp.Columns.Add("SCODE", typeof(string));
        //                DtBarcodeTemp.Columns.Add("BAR_TRAN_DATE", typeof(string));
        //                DtBarcodeTemp.Columns.Add("BAR_TRAN_NO", typeof(string));
        //                DtBarcodeTemp.Columns.Add("BAR_SRNO", typeof(string));
        //            }


        //            foreach (GridViewRow row in GvViewBarcode.Rows)
        //            {
        //                if (row.RowType == DataControlRowType.DataRow)
        //                {
        //                    TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
        //                    TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
        //                    HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
        //                    HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
        //                    HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;


        //                    DataTable DtBarcode = new DataTable();
        //                    DtBarcode = BARCODE_MASLogicLayer.GetBarcodeDetail_WiseBarcodeNo(TxtBarcode.Text.Trim());
        //                    DataView Dv = new DataView(DtBarcode);
        //                    Dv.RowFilter = "STATUSFlag='O'";
        //                    DataTable FilterBarcode = Dv.ToTable();


        //                    DataView DvBarcodeTemptable = new DataView(DtBarcodeTemp);
        //                    DvBarcodeTemptable.RowFilter = "BARCODE='" + TxtBarcode.Text.Trim() + "'";
        //                    DataTable DtBarcodeTempFiltertable = DvBarcodeTemptable.ToTable();

        //                    if (DtBarcodeTempFiltertable.Rows.Count <= 0)
        //                    {
        //                        if (FilterBarcode.Rows.Count > 0)
        //                        {
        //                            HfBarTranNo.Value = FilterBarcode.Rows[0]["TRAN_NO"].ToString();
        //                            HfBarTranDate.Value = FilterBarcode.Rows[0]["TRAN_DATE"].ToString();
        //                            HfBarSrNo.Value = FilterBarcode.Rows[0]["SRNO"].ToString();


        //                            #region Add Product INTO LIST AND CHECK IF EXIST

        //                            DataTable table = new DataTable();
        //                            DataRow dr = null;
        //                            if (ViewState["CurrentTable"] != null)
        //                            {
        //                                table = (DataTable)ViewState["CurrentTable"];
        //                            }
        //                            else
        //                            {
        //                                if (table.Rows.Count <= 0)
        //                                {

        //                                    table.Columns.Add("COMP_CODE", typeof(string));
        //                                    table.Columns.Add("TRAN_DATE", typeof(string));
        //                                    table.Columns.Add("TRAN_NO", typeof(string));
        //                                    table.Columns.Add("SR", typeof(string));
        //                                    table.Columns.Add("REF_TRAN_DATE", typeof(string));
        //                                    table.Columns.Add("REF_TRAN_NO", typeof(string));
        //                                    table.Columns.Add("REF_SRNO", typeof(string));
        //                                    table.Columns.Add("SCODE", typeof(string));
        //                                    table.Columns.Add("PRODUCT_DESC", typeof(string));
        //                                    table.Columns.Add("HSN_NO", typeof(string));
        //                                    table.Columns.Add("QTY", typeof(string));
        //                                    table.Columns.Add("RATE", typeof(string));
        //                                    table.Columns.Add("AMT", typeof(string));
        //                                    table.Columns.Add("DIS_PER", typeof(string));
        //                                    table.Columns.Add("DIS_AMT", typeof(string));
        //                                    table.Columns.Add("ADD_DIS_PER", typeof(string));
        //                                    table.Columns.Add("ADD_DIS_AMT", typeof(string));
        //                                    table.Columns.Add("G_AMT", typeof(string));
        //                                    table.Columns.Add("ST_PER", typeof(string));
        //                                    table.Columns.Add("ST_AMT", typeof(string));
        //                                    table.Columns.Add("ADD_ST_PER", typeof(string));
        //                                    table.Columns.Add("ADD_ST_AMT", typeof(string));
        //                                    table.Columns.Add("DC_TRAN_DATE", typeof(string));
        //                                    table.Columns.Add("DC_TRAN_NO", typeof(string));
        //                                    table.Columns.Add("DC_SRNO", typeof(string));
        //                                    table.Columns.Add("GST_RATE", typeof(string));
        //                                    table.Columns.Add("GST_AMT", typeof(string));
        //                                    table.Columns.Add("CGST_RATE", typeof(string));
        //                                    table.Columns.Add("CGST_AMT", typeof(string));
        //                                    table.Columns.Add("SGST_RATE", typeof(string));
        //                                    table.Columns.Add("SGST_AMT", typeof(string));
        //                                    table.Columns.Add("IGST_RATE", typeof(string));
        //                                    table.Columns.Add("IGST_AMT", typeof(string));
        //                                    table.Columns.Add("T_AMT", typeof(string));
        //                                    table.Columns.Add("INV_TRAN_DATE", typeof(string));
        //                                    table.Columns.Add("INV_TRAN_NO", typeof(string));
        //                                    table.Columns.Add("INV_SR", typeof(string));
        //                                    table.Columns.Add("ENTRY_TYPE", typeof(string));
        //                                    table.Columns.Add("ENDT", typeof(string));
        //                                    table.Columns.Add("ACT_RATE", typeof(string));
        //                                    table.Columns.Add("ACT_AMT", typeof(string));
        //                                    table.Columns.Add("CAL_RATE", typeof(string));
        //                                    table.Columns.Add("CAL_AMT", typeof(string));
        //                                    table.Columns.Add("PART_NO", typeof(string));
        //                                    table.Columns.Add("ADD_PART_NO", typeof(string));
        //                                    table.Columns.Add("PER_QTY_WT", typeof(string));
        //                                    table.Columns.Add("TOT_QTY_WT", typeof(string));
        //                                    table.Columns.Add("EX_DUTY_AMT", typeof(string));
        //                                    table.Columns.Add("EX_CESS_AMT", typeof(string));
        //                                    table.Columns.Add("EX_SHCESS_AMT", typeof(string));
        //                                    table.Columns.Add("CHA_NO", typeof(string));
        //                                    table.Columns.Add("SERIALNO", typeof(string));
        //                                    table.Columns.Add("ChallanDate", typeof(string));

        //                                }
        //                            }


        //                            string HfAmountString = "";
        //                            string CGST_AMTString = "";
        //                            string SGST_AMTString = "";
        //                            string HfGSTAmount = "";
        //                            string IGST_AMTString = "";
        //                            string T_AMTString = "";


        //                            if (table.Rows.Count > 0)
        //                            {
        //                                DataView Dvtable = new DataView(table);
        //                                Dvtable.RowFilter = "SCODE=" + FilterBarcode.Rows[0]["SCODE"].ToString();
        //                                DataTable DtFilterTable = Dvtable.ToTable();
        //                                if (DtFilterTable.Rows.Count > 0)
        //                                {
        //                                    //Update Qty
        //                                    foreach (DataRow drlp in table.Rows) // search whole table
        //                                    {
        //                                        if (drlp["SCODE"].ToString() == FilterBarcode.Rows[0]["SCODE"].ToString())
        //                                        {
        //                                            drlp["QTY"] = (Convert.ToDouble(drlp["QTY"]) + 1);

        //                                            #region Calculation For Change Qty

        //                                            if (FilterBarcode.Rows[0]["RATE"].ToString().Trim() != string.Empty)
        //                                            {
        //                                                HfAmountString = Convert.ToString(Convert.ToDouble(FilterBarcode.Rows[0]["RATE"].ToString().Trim()) * Convert.ToDouble(drlp["QTY"]));
        //                                                T_AMTString = HfAmountString;

        //                                                //if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
        //                                                //{
        //                                                //    CGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["CGST_RATE"].ToString())) / 100).ToString();
        //                                                //    SGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["SGST_RATE"].ToString())) / 100).ToString();
        //                                                //    HfGSTAmount = (Convert.ToDouble(CGST_AMTString.Trim()) + Convert.ToDouble(SGST_AMTString.Trim())).ToString();
        //                                                //    double d;
        //                                                //    d = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(CGST_AMTString)) + (Convert.ToDouble(SGST_AMTString)));
        //                                                //    T_AMTString = Convert.ToString(d);
        //                                                //}
        //                                                //else if (DdlPartyType.SelectedValue.ToString() == "CST")
        //                                                //{
        //                                                //    //HiddenField IGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");
        //                                                //    //HiddenField IGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfIGSTAmount");

        //                                                //    IGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["IGST_RATE"].ToString())) / 100).ToString();
        //                                                //    HfGSTAmount = IGST_AMTString;
        //                                                //    T_AMTString = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(IGST_AMTString))).ToString();
        //                                                //}

        //                                            }
        //                                            #endregion


        //                                            drlp["GST_AMT"] = HfGSTAmount;

        //                                            drlp["CGST_AMT"] = CGST_AMTString;

        //                                            drlp["SGST_AMT"] = SGST_AMTString;

        //                                            drlp["IGST_AMT"] = IGST_AMTString;

        //                                            drlp["AMT"] = HfAmountString;
        //                                            break;
        //                                        }
        //                                    }




        //                                    dr = DtBarcodeTemp.NewRow();
        //                                    dr["BARCODE"] = TxtBarcode.Text.Trim();
        //                                    dr["QTY"] = "1";
        //                                    dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
        //                                    dr["BAR_TRAN_DATE"] = FilterBarcode.Rows[0]["TRAN_DATE"].ToString();
        //                                    dr["BAR_TRAN_NO"] = FilterBarcode.Rows[0]["TRAN_NO"].ToString();
        //                                    dr["BAR_SRNO"] = FilterBarcode.Rows[0]["SRNO"].ToString();
        //                                    DtBarcodeTemp.Rows.Add(dr);
        //                                }
        //                                else
        //                                {

        //                                    #region Calculation


        //                                    if (FilterBarcode.Rows[0]["RATE"].ToString().Trim() != string.Empty)
        //                                    {
        //                                        HfAmountString = Convert.ToString(Convert.ToDouble(FilterBarcode.Rows[0]["RATE"].ToString().Trim()) * Convert.ToDouble(1));
        //                                        T_AMTString = HfAmountString;

        //                                        //if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
        //                                        //{
        //                                        //    CGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["CGST_RATE"].ToString())) / 100).ToString();
        //                                        //    SGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["SGST_RATE"].ToString())) / 100).ToString();
        //                                        //    HfGSTAmount = (Convert.ToDouble(CGST_AMTString.Trim()) + Convert.ToDouble(SGST_AMTString.Trim())).ToString();
        //                                        //    double d;
        //                                        //    d = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(CGST_AMTString)) + (Convert.ToDouble(SGST_AMTString)));
        //                                        //    T_AMTString = Convert.ToString(d);
        //                                        //}
        //                                        //else if (DdlPartyType.SelectedValue.ToString() == "CST")
        //                                        //{
        //                                        //    //HiddenField IGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");
        //                                        //    //HiddenField IGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfIGSTAmount");

        //                                        //    IGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["IGST_RATE"].ToString())) / 100).ToString();
        //                                        //    HfGSTAmount = IGST_AMTString;
        //                                        //    T_AMTString = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(IGST_AMTString))).ToString();
        //                                        //}

        //                                    }

        //                                    else
        //                                    {
        //                                        HfAmountString = Convert.ToString(Convert.ToDouble(0));
        //                                    }

        //                                    #endregion

        //                                    //Add New Row Product
        //                                    dr = table.NewRow();

        //                                    dr["COMP_CODE"] = 0;
        //                                    dr["TRAN_DATE"] = string.Empty;
        //                                    dr["TRAN_NO"] = string.Empty;
        //                                    dr["SR"] = string.Empty;
        //                                    dr["REF_TRAN_DATE"] = string.Empty;
        //                                    dr["REF_TRAN_NO"] = string.Empty;
        //                                    dr["REF_SRNO"] = string.Empty;
        //                                    dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
        //                                    dr["PRODUCT_DESC"] = string.Empty;
        //                                    dr["HSN_NO"] = string.Empty;
        //                                    dr["QTY"] = 1;
        //                                    dr["RATE"] = FilterBarcode.Rows[0]["RATE"].ToString();
        //                                    dr["AMT"] = HfAmountString;
        //                                    dr["DIS_PER"] = string.Empty;
        //                                    dr["DIS_AMT"] = string.Empty;
        //                                    dr["ADD_DIS_PER"] = string.Empty;
        //                                    dr["ADD_DIS_AMT"] = string.Empty;
        //                                    dr["G_AMT"] = string.Empty;
        //                                    dr["ST_PER"] = string.Empty;
        //                                    dr["ST_AMT"] = string.Empty;
        //                                    dr["ADD_ST_PER"] = string.Empty;
        //                                    dr["ADD_ST_AMT"] = string.Empty;
        //                                    dr["DC_TRAN_DATE"] = string.Empty;
        //                                    dr["DC_TRAN_NO"] = string.Empty;
        //                                    dr["DC_SRNO"] = string.Empty;
        //                                    dr["GST_RATE"] = string.Empty; // FilterBarcode.Rows[0]["GST_RATE"].ToString();
        //                                    dr["GST_AMT"] = string.Empty; //HfGSTAmount;
        //                                    dr["CGST_RATE"] = string.Empty; // CGST_AMTString != string.Empty ? FilterBarcode.Rows[0]["CGST_RATE"].ToString() : "";
        //                                    dr["CGST_AMT"] = string.Empty;  // CGST_AMTString;
        //                                    dr["SGST_RATE"] = string.Empty;  // SGST_AMTString != string.Empty ? FilterBarcode.Rows[0]["SGST_RATE"].ToString() : "";
        //                                    dr["SGST_AMT"] = string.Empty;  //SGST_AMTString;
        //                                    dr["IGST_RATE"] = string.Empty;  //IGST_AMTString != string.Empty ? FilterBarcode.Rows[0]["IGST_RATE"].ToString() : "";
        //                                    dr["IGST_AMT"] = string.Empty;  // IGST_AMTString;
        //                                    dr["T_AMT"] = T_AMTString;
        //                                    dr["INV_TRAN_DATE"] = string.Empty;
        //                                    dr["INV_TRAN_NO"] = string.Empty;
        //                                    dr["INV_SR"] = string.Empty;
        //                                    dr["ENTRY_TYPE"] = string.Empty;
        //                                    dr["ENDT"] = string.Empty;
        //                                    dr["ACT_RATE"] = string.Empty;
        //                                    dr["ACT_AMT"] = string.Empty;
        //                                    dr["CAL_RATE"] = string.Empty;
        //                                    dr["CAL_AMT"] = string.Empty;
        //                                    dr["PART_NO"] = string.Empty;
        //                                    dr["ADD_PART_NO"] = string.Empty;
        //                                    dr["PER_QTY_WT"] = string.Empty;
        //                                    dr["TOT_QTY_WT"] = string.Empty;
        //                                    dr["EX_DUTY_AMT"] = string.Empty;
        //                                    dr["EX_CESS_AMT"] = string.Empty;
        //                                    dr["EX_SHCESS_AMT"] = string.Empty;
        //                                    dr["CHA_NO"] = string.Empty;
        //                                    dr["SERIALNO"] = string.Empty;
        //                                    dr["ChallanDate"] = string.Empty;

        //                                    table.Rows.Add(dr);

        //                                    dr = DtBarcodeTemp.NewRow();
        //                                    dr["BARCODE"] = TxtBarcode.Text.Trim();
        //                                    dr["QTY"] = "1";
        //                                    dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
        //                                    dr["BAR_TRAN_DATE"] = FilterBarcode.Rows[0]["TRAN_DATE"].ToString();
        //                                    dr["BAR_TRAN_NO"] = FilterBarcode.Rows[0]["TRAN_NO"].ToString();
        //                                    dr["BAR_SRNO"] = FilterBarcode.Rows[0]["SRNO"].ToString();
        //                                    DtBarcodeTemp.Rows.Add(dr);
        //                                }
        //                            }

        //                            else
        //                            {

        //                                #region Calculation


        //                                if (FilterBarcode.Rows[0]["RATE"].ToString().Trim() != string.Empty)
        //                                {
        //                                    HfAmountString = Convert.ToString(Convert.ToDouble(FilterBarcode.Rows[0]["RATE"].ToString().Trim()) * Convert.ToDouble(1));
        //                                    T_AMTString = HfAmountString;

        //                                    //if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
        //                                    //{
        //                                    //    CGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["CGST_RATE"].ToString())) / 100).ToString();
        //                                    //    SGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["SGST_RATE"].ToString())) / 100).ToString();
        //                                    //    HfGSTAmount = (Convert.ToDouble(CGST_AMTString.Trim()) + Convert.ToDouble(SGST_AMTString.Trim())).ToString();
        //                                    //    double d;
        //                                    //    d = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(CGST_AMTString)) + (Convert.ToDouble(SGST_AMTString)));
        //                                    //    T_AMTString = Convert.ToString(d);
        //                                    //}
        //                                    //else if (DdlPartyType.SelectedValue.ToString() == "CST")
        //                                    //{
        //                                    //    //HiddenField IGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");
        //                                    //    //HiddenField IGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfIGSTAmount");

        //                                    //    IGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["IGST_RATE"].ToString())) / 100).ToString();
        //                                    //    HfGSTAmount = IGST_AMTString;
        //                                    //    T_AMTString = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(IGST_AMTString))).ToString();
        //                                    //}

        //                                }

        //                                else
        //                                {
        //                                    HfAmountString = Convert.ToString(Convert.ToDouble(0));
        //                                }

        //                                #endregion

        //                                //Add New Row Product
        //                                dr = table.NewRow();

        //                                dr["COMP_CODE"] = 0;
        //                                dr["TRAN_DATE"] = string.Empty;
        //                                dr["TRAN_NO"] = string.Empty;
        //                                dr["SR"] = string.Empty;
        //                                dr["REF_TRAN_DATE"] = string.Empty;
        //                                dr["REF_TRAN_NO"] = string.Empty;
        //                                dr["REF_SRNO"] = string.Empty;
        //                                dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
        //                                dr["PRODUCT_DESC"] = string.Empty;
        //                                dr["HSN_NO"] = string.Empty;
        //                                dr["QTY"] = 1;
        //                                dr["RATE"] = FilterBarcode.Rows[0]["RATE"].ToString();
        //                                dr["AMT"] = HfAmountString;
        //                                dr["DIS_PER"] = string.Empty;
        //                                dr["DIS_AMT"] = string.Empty;
        //                                dr["ADD_DIS_PER"] = string.Empty;
        //                                dr["ADD_DIS_AMT"] = string.Empty;
        //                                dr["G_AMT"] = string.Empty;
        //                                dr["ST_PER"] = string.Empty;
        //                                dr["ST_AMT"] = string.Empty;
        //                                dr["ADD_ST_PER"] = string.Empty;
        //                                dr["ADD_ST_AMT"] = string.Empty;
        //                                dr["DC_TRAN_DATE"] = string.Empty;
        //                                dr["DC_TRAN_NO"] = string.Empty;
        //                                dr["DC_SRNO"] = string.Empty;
        //                                dr["GST_RATE"] = string.Empty; // FilterBarcode.Rows[0]["GST_RATE"].ToString();
        //                                dr["GST_AMT"] = string.Empty; //HfGSTAmount;
        //                                dr["CGST_RATE"] = string.Empty; // CGST_AMTString != string.Empty ? FilterBarcode.Rows[0]["CGST_RATE"].ToString() : "";
        //                                dr["CGST_AMT"] = string.Empty;  // CGST_AMTString;
        //                                dr["SGST_RATE"] = string.Empty;  // SGST_AMTString != string.Empty ? FilterBarcode.Rows[0]["SGST_RATE"].ToString() : "";
        //                                dr["SGST_AMT"] = string.Empty;  //SGST_AMTString;
        //                                dr["IGST_RATE"] = string.Empty;  //IGST_AMTString != string.Empty ? FilterBarcode.Rows[0]["IGST_RATE"].ToString() : "";
        //                                dr["IGST_AMT"] = string.Empty;  // IGST_AMTString;
        //                                dr["T_AMT"] = T_AMTString;
        //                                dr["INV_TRAN_DATE"] = string.Empty;
        //                                dr["INV_TRAN_NO"] = string.Empty;
        //                                dr["INV_SR"] = string.Empty;
        //                                dr["ENTRY_TYPE"] = string.Empty;
        //                                dr["ENDT"] = string.Empty;
        //                                dr["ACT_RATE"] = string.Empty;
        //                                dr["ACT_AMT"] = string.Empty;
        //                                dr["CAL_RATE"] = string.Empty;
        //                                dr["CAL_AMT"] = string.Empty;
        //                                dr["PART_NO"] = string.Empty;
        //                                dr["ADD_PART_NO"] = string.Empty;
        //                                dr["PER_QTY_WT"] = string.Empty;
        //                                dr["TOT_QTY_WT"] = string.Empty;
        //                                dr["EX_DUTY_AMT"] = string.Empty;
        //                                dr["EX_CESS_AMT"] = string.Empty;
        //                                dr["EX_SHCESS_AMT"] = string.Empty;
        //                                dr["CHA_NO"] = string.Empty;
        //                                dr["SERIALNO"] = string.Empty;
        //                                dr["ChallanDate"] = string.Empty;

        //                                table.Rows.Add(dr);

        //                                dr = DtBarcodeTemp.NewRow();

        //                                dr["BARCODE"] = TxtBarcode.Text.Trim();
        //                                dr["QTY"] = "1";
        //                                dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
        //                                dr["BAR_TRAN_DATE"] = FilterBarcode.Rows[0]["TRAN_DATE"].ToString();
        //                                dr["BAR_TRAN_NO"] = FilterBarcode.Rows[0]["TRAN_NO"].ToString();
        //                                dr["BAR_SRNO"] = FilterBarcode.Rows[0]["SRNO"].ToString();
        //                                DtBarcodeTemp.Rows.Add(dr);
        //                            }

        //                            ViewState["BarcodeTemp"] = DtBarcodeTemp;


        //                            DataView DvFilterNull = new DataView(table);
        //                            DvFilterNull.RowFilter = "SCODE<>0";
        //                            DataTable DtFilterNull = DvFilterNull.ToTable();


        //                            ViewState["CurrentTable"] = DtFilterNull;

        //                            GvStockRecDetails.DataSource = DtFilterNull;
        //                            GvStockRecDetails.DataBind();

        //                            #endregion
        //                        }
        //                        else
        //                        {
        //                            //alert
        //                            //  lblbarduperror.Text = "Barcode is not available..! " ;
        //                            // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Barcode is not available..!!');", true);
        //                            TxtBarcode.ForeColor = Color.Red;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        TxtBarcode.ForeColor = Color.Red;

        //                    }

        //                }
        //            }

        //            lblbarduperror.Text = string.Empty;
        //        }
        //        else
        //        {
        //            lblbarduperror.Text = "Duplicate Barcode Found! Details:- " + dupbarcode.TrimEnd(',');
        //        }

        //    }


        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        //protected void btnReturnBarcodeProcess_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataTable DtBarcodeTemp = new DataTable();
        //        if (ViewState["BarcodeTemp"] != null)
        //        {
        //            DtBarcodeTemp = (DataTable)ViewState["BarcodeTemp"];
        //        }

        //        if (DtBarcodeTemp.Rows.Count > 0)
        //        {
        //            lblbarduperror.Text = string.Empty;
        //            foreach (GridViewRow row in GvViewBarcode.Rows)
        //            {
        //                if (row.RowType == DataControlRowType.DataRow)
        //                {
        //                    TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
        //                    TextBox TxtQty = row.FindControl("TxtQty") as TextBox;

        //                    DataView DvBarcodeTemptable = new DataView(DtBarcodeTemp);
        //                    DvBarcodeTemptable.RowFilter = "BARCODE='" + TxtBarcode.Text.Trim() + "'";
        //                    DataTable DtBarcodeTempFiltertable = DvBarcodeTemptable.ToTable();



        //                    if (DtBarcodeTempFiltertable.Rows.Count > 0)
        //                    {
        //                        for (int i = DtBarcodeTemp.Rows.Count - 1; i >= 0; i--)
        //                        {
        //                            DataRow drReturn = DtBarcodeTemp.Rows[i];

        //                            if (drReturn["BARCODE"].ToString() == TxtBarcode.Text.Trim())
        //                            {
        //                                if (Convert.ToInt32(drReturn["QTY"]) == Convert.ToInt32(TxtQty.Text.Trim()))
        //                                {
        //                                    drReturn.Delete();
        //                                }
        //                                else if (Convert.ToInt32(drReturn["QTY"].ToString()) > Convert.ToInt32(TxtQty.Text.Trim()))
        //                                {
        //                                    drReturn["QTY"] = (Convert.ToInt32(drReturn["QTY"]) - Convert.ToInt32(TxtQty.Text.Trim()));
        //                                }
        //                                else
        //                                {
        //                                    lblbarduperror.Text = "Return Qty more than issue Qty !";
        //                                }
        //                            }

        //                        }
        //                        DtBarcodeTemp.AcceptChanges();
        //                        ViewState["BarcodeTemp"] = DtBarcodeTemp;


        //                        #region Add Product INTO LIST AND CHECK IF EXIST

        //                        DataTable table = new DataTable();
        //                        DataRow dr = null;
        //                        if (ViewState["CurrentTable"] != null)
        //                        {
        //                            table = (DataTable)ViewState["CurrentTable"];
        //                        }
        //                        else
        //                        {
        //                            if (table.Rows.Count <= 0)
        //                            {

        //                                table.Columns.Add("COMP_CODE", typeof(string));
        //                                table.Columns.Add("TRAN_DATE", typeof(string));
        //                                table.Columns.Add("TRAN_NO", typeof(string));
        //                                table.Columns.Add("SR", typeof(string));
        //                                table.Columns.Add("REF_TRAN_DATE", typeof(string));
        //                                table.Columns.Add("REF_TRAN_NO", typeof(string));
        //                                table.Columns.Add("REF_SRNO", typeof(string));
        //                                table.Columns.Add("SCODE", typeof(string));
        //                                table.Columns.Add("PRODUCT_DESC", typeof(string));
        //                                table.Columns.Add("HSN_NO", typeof(string));
        //                                table.Columns.Add("QTY", typeof(string));
        //                                table.Columns.Add("RATE", typeof(string));
        //                                table.Columns.Add("AMT", typeof(string));
        //                                table.Columns.Add("DIS_PER", typeof(string));
        //                                table.Columns.Add("DIS_AMT", typeof(string));
        //                                table.Columns.Add("ADD_DIS_PER", typeof(string));
        //                                table.Columns.Add("ADD_DIS_AMT", typeof(string));
        //                                table.Columns.Add("G_AMT", typeof(string));
        //                                table.Columns.Add("ST_PER", typeof(string));
        //                                table.Columns.Add("ST_AMT", typeof(string));
        //                                table.Columns.Add("ADD_ST_PER", typeof(string));
        //                                table.Columns.Add("ADD_ST_AMT", typeof(string));
        //                                table.Columns.Add("DC_TRAN_DATE", typeof(string));
        //                                table.Columns.Add("DC_TRAN_NO", typeof(string));
        //                                table.Columns.Add("DC_SRNO", typeof(string));
        //                                table.Columns.Add("GST_RATE", typeof(string));
        //                                table.Columns.Add("GST_AMT", typeof(string));
        //                                table.Columns.Add("CGST_RATE", typeof(string));
        //                                table.Columns.Add("CGST_AMT", typeof(string));
        //                                table.Columns.Add("SGST_RATE", typeof(string));
        //                                table.Columns.Add("SGST_AMT", typeof(string));
        //                                table.Columns.Add("IGST_RATE", typeof(string));
        //                                table.Columns.Add("IGST_AMT", typeof(string));
        //                                table.Columns.Add("T_AMT", typeof(string));
        //                                table.Columns.Add("INV_TRAN_DATE", typeof(string));
        //                                table.Columns.Add("INV_TRAN_NO", typeof(string));
        //                                table.Columns.Add("INV_SR", typeof(string));
        //                                table.Columns.Add("ENTRY_TYPE", typeof(string));
        //                                table.Columns.Add("ENDT", typeof(string));
        //                                table.Columns.Add("ACT_RATE", typeof(string));
        //                                table.Columns.Add("ACT_AMT", typeof(string));
        //                                table.Columns.Add("CAL_RATE", typeof(string));
        //                                table.Columns.Add("CAL_AMT", typeof(string));
        //                                table.Columns.Add("PART_NO", typeof(string));
        //                                table.Columns.Add("ADD_PART_NO", typeof(string));
        //                                table.Columns.Add("PER_QTY_WT", typeof(string));
        //                                table.Columns.Add("TOT_QTY_WT", typeof(string));
        //                                table.Columns.Add("EX_DUTY_AMT", typeof(string));
        //                                table.Columns.Add("EX_CESS_AMT", typeof(string));
        //                                table.Columns.Add("EX_SHCESS_AMT", typeof(string));
        //                                table.Columns.Add("CHA_NO", typeof(string));
        //                                table.Columns.Add("SERIALNO", typeof(string));
        //                                table.Columns.Add("ChallanDate", typeof(string));

        //                            }
        //                        }

        //                        if (table.Rows.Count > 0)
        //                        {
        //                            DataView Dvtable = new DataView(table);
        //                            Dvtable.RowFilter = "SCODE=" + DtBarcodeTempFiltertable.Rows[0]["SCODE"].ToString();
        //                            DataTable DtFilterTable = Dvtable.ToTable();
        //                            if (DtFilterTable.Rows.Count > 0)
        //                            {
        //                                //Update Qty
        //                                foreach (DataRow drlp in table.Rows) // search whole table
        //                                {
        //                                    if (drlp["SCODE"].ToString() == DtBarcodeTempFiltertable.Rows[0]["SCODE"].ToString())
        //                                    {
        //                                        if ((Convert.ToDouble(drlp["QTY"]) - 1) == 0)
        //                                        {
        //                                            drlp.Delete();
        //                                        }
        //                                        else
        //                                        {

        //                                            drlp["QTY"] = (Convert.ToDouble(drlp["QTY"]) - 1);
        //                                        }
        //                                        break;
        //                                    }
        //                                }

        //                            }
        //                        }

        //                        ViewState["CurrentTable"] = table;



        //                        #endregion
        //                    }
        //                    else
        //                    {
        //                        TxtBarcode.ForeColor = Color.Red;
        //                    }





        //                }
        //            }
        //            GvViewBarcode.DataSource = DtBarcodeTemp;
        //            GvViewBarcode.DataBind();
        //        }
        //        else
        //        {
        //            lblbarduperror.Text = "Barcode not exist";

        //        }
        //        GvStockRecDetails.DataSource = (DataTable)ViewState["CurrentTable"];
        //        GvStockRecDetails.DataBind();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //protected void TxtBarcode_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        TextBox txt = (TextBox)sender;
        //        GridViewRow row = (GridViewRow)txt.Parent.Parent;
        //        int idx = row.RowIndex;

        //        TextBox TxtQty = (TextBox)row.Cells[2].FindControl("TxtQty");

        //        TxtQty.Text = "1";
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //protected void BtnAddRowModelBarCode_ViewGrid_Click(object sender, EventArgs e)
        //{
        //    AddNewRowBarcodeView();
        //}



        //protected void AddNewRowBarcodeView()
        //{
        //    try
        //    {

        //        DataTable dtCurrentTable = new DataTable();
        //        DataRow dr = null;
        //        if (ViewState["BarcodeTempNew"] != null)
        //        {
        //            dtCurrentTable = (DataTable)ViewState["BarcodeTempNew"];
        //        }
        //        else
        //        {
        //            dtCurrentTable.Columns.Add("BARCODE", typeof(System.String));
        //            dtCurrentTable.Columns.Add("QTY", typeof(System.String));
        //            dtCurrentTable.Columns.Add("SCODE", typeof(System.String));
        //            dtCurrentTable.Columns.Add("BAR_TRAN_DATE", typeof(System.String));
        //            dtCurrentTable.Columns.Add("BAR_TRAN_NO", typeof(System.String));
        //            dtCurrentTable.Columns.Add("BAR_SRNO", typeof(System.String));

        //            foreach (GridViewRow row in GvViewBarcode.Rows)
        //            {
        //                if (row.RowType == DataControlRowType.DataRow)
        //                {
        //                    TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
        //                    TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
        //                    HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
        //                    HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
        //                    HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;

        //                    if (TxtBarcode.Text.Trim() != string.Empty)
        //                    {
        //                        dr = dtCurrentTable.NewRow();

        //                        dr["BARCODE"] = TxtBarcode.Text.Trim();
        //                        dr["QTY"] = TxtQty.Text.Trim();
        //                        dr["SCODE"] = "";
        //                        dr["BAR_TRAN_DATE"] = HfBarTranDate.Value;
        //                        dr["BAR_TRAN_NO"] = HfBarTranNo.Value;
        //                        dr["BAR_SRNO"] = HfBarSrNo.Value;
        //                        dtCurrentTable.Rows.Add(dr);
        //                    }
        //                }
        //            }
        //        }





        //        dr = dtCurrentTable.NewRow();

        //        dr["BARRCODE"] = "";
        //        dr["QTY"] = "";
        //        dr["SCODE"] = "";
        //        dr["BAR_TRAN_DATE"] = "";
        //        dr["BAR_TRAN_NO"] = "";
        //        dr["BAR_SRNO"] = "";

        //        dtCurrentTable.Rows.Add(dr);

        //        ViewState["BarcodeTempNew"] = dtCurrentTable;

        //        GvViewBarcode.DataSource = dtCurrentTable;
        //        GvViewBarcode.DataBind();


        //        //}
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}





        #endregion

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtSearch.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtSearch);
                    Dv.RowFilter = "AccountNameDebit like '%" + TxtSearch.Text.Trim() + "%' OR Convert(INV_NO, 'System.String') like '%" + TxtSearch.Text.Trim() + "%' ";
                    GvTaxInvoiceMaster.DataSource = Dv.ToTable();
                    GvTaxInvoiceMaster.DataBind();
                }
                else
                {
                    GvTaxInvoiceMaster.DataSource = DtSearch;
                    GvTaxInvoiceMaster.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void TxtDueDays_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double duedays = 0;
                if (TxtDueDays.Text != string.Empty)
                {
                    duedays = Convert.ToDouble(TxtDueDays.Text.Trim());

                }

                DateTime InvoiceDate = Convert.ToDateTime(TxtInvoiceDate.Text).AddDays(duedays);
                TxtDueDate.Text = Convert.ToDateTime(InvoiceDate.ToString()).ToString("dd-MM-yyyy");
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtDueDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtDueDate.Text == string.Empty)
                {
                    TxtDueDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    DateTime InvoiceDate = Convert.ToDateTime(TxtInvoiceDate.Text);
                    DateTime DueDate = Convert.ToDateTime(TxtDueDate.Text);

                    double DueDays = (DueDate - InvoiceDate).TotalDays;
                    TxtDueDays.Text = DueDays.ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }




        #region Calculation For Stock Details Grid


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

        public void FillOnGridDetailChanged()
        {
            try
            {
                #region Assign To Stock Grid

                int rowIndex = 0;

                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //extract the TextBox values 
                            //TextBox TxtSr = (TextBox)GvQuotation_C.Rows[rowIndex].Cells[1].FindControl("TxtSr");



                            Label lblSumTotalQty = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalQty"));
                            Label lblCGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                            Label lblSGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                            Label lblIGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                            Label lblSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalAmount"));


                            HiddenField HfDetailSCode = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                            HiddenField HfGSTRate = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                            HiddenField HfGSTAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                            HiddenField HfAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                            HiddenField HfDisAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                            HiddenField HfGrossAmount = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfGrossAmount");
                            HiddenField HfEntryType = (HiddenField)GvStockRecDetails.Rows[rowIndex].Cells[0].FindControl("HfEntryType");


                            TextBox TxtChallanNo = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[1].FindControl("TxtChallanNo");
                            TextBox TxtChallanDate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[2].FindControl("TxtChallanDate");
                            TextBox TxtGRNNo = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[3].FindControl("TxtGRNNo");
                            TextBox TxtProductCode = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[4].FindControl("TxtProductCode");
                            TextBox TxtHSNCode = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[5].FindControl("TxtHSNCode");
                            TextBox TxtProductName = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[6].FindControl("TxtProductName");
                            TextBox TxtProductDescrption = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[7].FindControl("TxtProductDescrption");
                            TextBox TxtQty = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[8].FindControl("TxtQty");
                            TextBox TxtRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[9].FindControl("TxtRate");
                            TextBox TxtDisRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[10].FindControl("TxtDisRate");
                            TextBox TxtCGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[11].FindControl("TxtCGSTRate");
                            TextBox TxtCGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[12].FindControl("TxtCGSTAmount");
                            TextBox TxtSGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[13].FindControl("TxtSGSTRate");
                            TextBox TxtSGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[14].FindControl("TxtSGSTAmount");
                            TextBox TxtIGSTRate = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[15].FindControl("TxtIGSTRate");
                            TextBox TxtIGSTAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[16].FindControl("TxtIGSTAmount");
                            TextBox TxtTotalAmount = (TextBox)GvStockRecDetails.Rows[rowIndex].Cells[17].FindControl("TxtTotalAmount");



                            //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["PRODUCT_DESC"] = TxtProductDescrption.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["HSN_NO"] = TxtHSNCode.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["AMT"] = HfAmount.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["DIS_PER"] = TxtDisRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["DIS_AMT"] = HfDisAmount.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["G_AMT"] = HfGrossAmount.Value.Trim();
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
                TextBox TxtProductName = (TextBox)row.Cells[7].FindControl("TxtProductName");
                TextBox TxtHsn = (TextBox)row.Cells[6].FindControl("TxtHSNCode");
                TextBox TxtRateString = (TextBox)row.Cells[10].FindControl("TxtRate");

                HiddenField HfGSTRateString = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                TextBox TxtCGSTRateString = (TextBox)row.Cells[12].FindControl("TxtCGSTRate");
                TextBox TxtSGSTRateString = (TextBox)row.Cells[14].FindControl("TxtSGSTRate");
                TextBox TxtIGSTRateString = (TextBox)row.Cells[16].FindControl("TxtIGSTRate");

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
                        TxtHsn.Text = DtView.Rows[0]["HSN_NO"].ToString();
                        FillOnGridDetailChanged();

                        if (txt.Text != string.Empty && DdlPartyType.SelectedIndex != 0)
                        {
                            DataTable DsStock = STOCK_MASLogicLayer.STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(HfDetailSCode.Value), DdlPartyType.SelectedValue);
                            if (DsStock.Rows.Count > 0)
                            {
                                if ((HfTranType.Value == "S" && HfTrnType.Value == "P") || (HfTranType.Value == "S" && HfTrnType.Value == "T") || (HfTranType.Value == "S" && HfTrnType.Value == "R"))
                                {

                                    TxtRateString.Text = DsStock.Rows[0]["SAL_RATE"].ToString();
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
                        else
                        {
                            //   TxtRateString.Text = "0";
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
                TextBox TxtProductCode = (TextBox)row.Cells[5].FindControl("TxtProductCode");
                TextBox TxtHsn = (TextBox)row.Cells[6].FindControl("TxtHSNCode");
                TextBox TxtRateString = (TextBox)row.Cells[10].FindControl("TxtRate");

                HiddenField HfGSTRateString = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                TextBox TxtCGSTRateString = (TextBox)row.Cells[12].FindControl("TxtCGSTRate");
                TextBox TxtSGSTRateString = (TextBox)row.Cells[14].FindControl("TxtSGSTRate");
                TextBox TxtIGSTRateString = (TextBox)row.Cells[16].FindControl("TxtIGSTRate");

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
                        TxtHsn.Text = DtView.Rows[0]["HSN_NO"].ToString();
                        FillOnGridDetailChanged();

                        if (txt.Text != string.Empty && DdlPartyType.SelectedIndex != 0)
                        {

                            DataTable DsStock = STOCK_MASLogicLayer.STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(HfDetailSCode.Value), DdlPartyType.SelectedValue);
                            if (DsStock.Rows.Count > 0)
                            {

                                if ((HfTranType.Value == "S" && HfTrnType.Value == "P") || (HfTranType.Value == "S" && HfTrnType.Value == "T") || (HfTranType.Value == "S" && HfTrnType.Value == "R"))
                                {

                                    TxtRateString.Text = DsStock.Rows[0]["SAL_RATE"].ToString();
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

                        else
                        {
                            //   TxtRateString.Text = "0";
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




        protected void TxtRate_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;



                Label lblSumTotalQty = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalQty"));
                Label lblCGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                Label lblSGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                Label lblIGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                Label lblSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalAmount"));

                TextBox TxtQty = (TextBox)row.Cells[9].FindControl("TxtQty");
                HiddenField HfAmount = (HiddenField)row.Cells[0].FindControl("HfAmount");
                HiddenField HfDisAmount = (HiddenField)row.Cells[0].FindControl("HfDisAmount");
                HiddenField HfGrossAmount = (HiddenField)row.Cells[0].FindControl("HfGrossAmount");


                TextBox TxtDisRate = (TextBox)row.Cells[11].FindControl("TxtDisRate");
                TextBox CGST_RATEString = (TextBox)row.Cells[12].FindControl("TxtCGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[13].FindControl("TxtCGSTAmount");
                TextBox SGST_RATEString = (TextBox)row.Cells[14].FindControl("TxtSGSTRate");
                TextBox SGST_AMTString = (TextBox)row.Cells[15].FindControl("TxtSGSTAmount");

                TextBox T_AMTString = (TextBox)row.Cells[17].FindControl("TxtTotalAmount");

                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                if (TxtQty.Text == string.Empty)
                {
                    TxtQty.Text = "0";
                }


                if (txt.Text.Trim() != string.Empty && TxtQty.Text.Trim() != string.Empty)
                {
                    HfAmount.Value = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtQty.Text.Trim()));
                    HfGrossAmount.Value = HfAmount.Value;

                    if ((HfTranType.Value == "S" && HfTrnType.Value == "P") || (HfTranType.Value == "S" && HfTrnType.Value == "T") || (HfTranType.Value == "S" && HfTrnType.Value == "R"))
                    {

                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            CGST_AMTString.Text = ((Convert.ToDouble(HfAmount.Value.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                            SGST_AMTString.Text = ((Convert.ToDouble(HfAmount.Value.Trim()) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                            HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                            double d;
                            d = ((Convert.ToDouble(HfAmount.Value.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                            T_AMTString.Text = Convert.ToString(d);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            TextBox IGST_RATEString = (TextBox)row.Cells[16].FindControl("TxtIGSTRate");
                            TextBox IGST_AMTString = (TextBox)row.Cells[17].FindControl("TxtIGSTAmount");

                            IGST_AMTString.Text = ((Convert.ToDouble(HfAmount.Value.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                            HfGSTAmount.Value = IGST_AMTString.Text;
                            T_AMTString.Text = ((Convert.ToDouble(HfAmount.Value.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();
                        }

                    }


                    else
                    {
                        T_AMTString.Text = HfGrossAmount.Value.Trim();
                    }

                    double SumTotalQuantity = TotalQuantity();
                    lblSumTotalQty.Text = SumTotalQuantity.ToString();

                    double SumTotalHfAmount = TotalHfAmt();

                    // double SumTotalGrossAmount = TotalGrossAmount();
                    double SumTotalGrossAmount = TotalHfAmt();

                    double SumTotalCGSTAmount = TotalCGSTAmount();
                    lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                    double SumTotalSGSTAmount = TotalSGSTAmount();
                    lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                    double SumTotalIGSTAmount = TotalIGSTAmount();
                    lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                    double SumTotalAmount = TotalAmount();
                    lblSumTotalAmount.Text = SumTotalAmount.ToString();

                    if (SumTotalGrossAmount.ToString() != string.Empty)
                    {
                        ViewState["GrossAmtCurrentTable_Details"] = SumTotalGrossAmount;
                    }

                    if (lblSumTotalAmount.Text != string.Empty)
                    {

                        ViewState["TotalCurrentTable_Details"] = lblSumTotalAmount.Text.Trim();
                    }

                    if (lblCGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalCGSTAmount_Deatils"] = lblCGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblSGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalSGSTAmount_Deatils"] = lblSGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblIGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalIGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text.Trim();
                    }

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        ViewState["TotalGSTAmount_Deatils"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        ViewState["TotalGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text;
                    }
                    else { }

                    FillNetAmount();
                    TotalAmountCalculationInREC_ISS_M();

                }
                else
                {
                    HfAmount.Value = Convert.ToString(Convert.ToDouble(0));
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

                    Label lblSumTotalQty = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalQty"));
                    Label lblCGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                    Label lblSGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                    Label lblIGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                    Label lblSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalAmount"));

                    TextBox TxtQuantityString = (TextBox)row.Cells[9].FindControl("TxtQty");
                    TextBox TxtRateString = (TextBox)row.Cells[10].FindControl("TxtRate");
                    HiddenField HfAmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");
                    HiddenField HfDisAmount = (HiddenField)row.Cells[0].FindControl("HfDisAmount");
                    HiddenField HfGrossAmount = (HiddenField)row.Cells[0].FindControl("HfGrossAmount");


                    TextBox TxtDisRate = (TextBox)row.Cells[11].FindControl("TxtDisRate");
                    TextBox CGST_RATEString = (TextBox)row.Cells[12].FindControl("TxtCGSTRate");
                    TextBox CGST_AMTString = (TextBox)row.Cells[13].FindControl("TxtCGSTAmount");
                    TextBox SGST_RATEString = (TextBox)row.Cells[14].FindControl("TxtSGSTRate");
                    TextBox SGST_AMTString = (TextBox)row.Cells[15].FindControl("TxtSGSTAmount");

                    TextBox T_AMTString = (TextBox)row.Cells[17].FindControl("TxtTotalAmount");

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
                        HfGrossAmount.Value = disamt.ToString();

                        if ((HfTranType.Value == "S" && HfTrnType.Value == "P") || (HfTranType.Value == "S" && HfTrnType.Value == "T") || (HfTranType.Value == "S" && HfTrnType.Value == "R"))
                        {

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
                        }


                        else
                        {
                            T_AMTString.Text = HfGrossAmount.Value.Trim();
                        }

                        double SumTotalQuantity = TotalQuantity();
                        lblSumTotalQty.Text = SumTotalQuantity.ToString();

                        double SumTotalHfAmount = TotalHfAmt();

                        double SumTotalGrossAmount = TotalGrossAmount();
                        //  double SumTotalGrossAmount = TotalHfAmt();

                        double SumTotalCGSTAmount = TotalCGSTAmount();
                        lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                        double SumTotalSGSTAmount = TotalSGSTAmount();
                        lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                        double SumTotalIGSTAmount = TotalIGSTAmount();
                        lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                        double SumTotalAmount = TotalAmount();
                        lblSumTotalAmount.Text = SumTotalAmount.ToString();

                        if (SumTotalGrossAmount.ToString() != string.Empty)
                        {
                            ViewState["GrossAmtCurrentTable_Details"] = SumTotalGrossAmount;
                        }

                        if (lblSumTotalAmount.Text != string.Empty)
                        {

                            ViewState["TotalCurrentTable_Details"] = lblSumTotalAmount.Text.Trim();
                        }

                        if (lblCGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalCGSTAmount_Deatils"] = lblCGSTSumTotalAmount.Text.Trim();
                        }

                        if (lblSGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalSGSTAmount_Deatils"] = lblSGSTSumTotalAmount.Text.Trim();
                        }

                        if (lblIGSTSumTotalAmount.Text != string.Empty)
                        {
                            ViewState["TotalIGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text.Trim();
                        }

                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            ViewState["TotalGSTAmount_Deatils"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            ViewState["TotalGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text;
                        }
                        else { }

                        FillNetAmount();
                        TotalAmountCalculationInREC_ISS_M();

                    }
                    else
                    {
                        HfGrossAmount.Value = Convert.ToString(Convert.ToDouble(0));
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




        protected void TxtQty_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                Label lblSumTotalQty = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalQty"));
                Label lblCGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                Label lblSGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                Label lblIGSTSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                Label lblSumTotalAmount = (Label)(GvStockRecDetails.FooterRow.FindControl("lblSumTotalAmount"));

                TextBox TxtRate = (TextBox)row.Cells[10].FindControl("TxtRate");
                HiddenField HfAmount = (HiddenField)row.Cells[0].FindControl("HfAmount");
                HiddenField HfDisAmount = (HiddenField)row.Cells[0].FindControl("HfDisAmount");
                HiddenField HfGrossAmount = (HiddenField)row.Cells[0].FindControl("HfGrossAmount");


                TextBox TxtDisRate = (TextBox)row.Cells[11].FindControl("TxtDisRate");
                TextBox CGST_RATEString = (TextBox)row.Cells[12].FindControl("TxtCGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[13].FindControl("TxtCGSTAmount");
                TextBox SGST_RATEString = (TextBox)row.Cells[14].FindControl("TxtSGSTRate");
                TextBox SGST_AMTString = (TextBox)row.Cells[15].FindControl("TxtSGSTAmount");

                TextBox T_AMTString = (TextBox)row.Cells[17].FindControl("TxtTotalAmount");

                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                if (TxtRate.Text == string.Empty)
                {
                    TxtRate.Text = "0";
                }

                if (txt.Text.Trim() != string.Empty && TxtRate.Text.Trim() != string.Empty)
                {
                    HfAmount.Value = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtRate.Text.Trim()));
                    HfGrossAmount.Value = HfAmount.Value;

                    if ((HfTranType.Value == "S" && HfTrnType.Value == "P") || (HfTranType.Value == "S" && HfTrnType.Value == "T") || (HfTranType.Value == "S" && HfTrnType.Value == "R"))
                    {

                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            CGST_AMTString.Text = ((Convert.ToDouble(HfAmount.Value.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                            SGST_AMTString.Text = ((Convert.ToDouble(HfAmount.Value.Trim()) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                            HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                            double d;
                            d = ((Convert.ToDouble(HfAmount.Value.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                            T_AMTString.Text = Convert.ToString(d);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            TextBox IGST_RATEString = (TextBox)row.Cells[16].FindControl("TxtIGSTRate");
                            TextBox IGST_AMTString = (TextBox)row.Cells[17].FindControl("TxtIGSTAmount");

                            IGST_AMTString.Text = ((Convert.ToDouble(HfAmount.Value.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                            HfGSTAmount.Value = IGST_AMTString.Text;
                            T_AMTString.Text = ((Convert.ToDouble(HfAmount.Value.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();
                        }

                    }

                    else
                    {
                        T_AMTString.Text = HfGrossAmount.Value.Trim();
                    }

                    double SumTotalQuantity = TotalQuantity();
                    lblSumTotalQty.Text = SumTotalQuantity.ToString();

                    double SumTotalHfAmount = TotalHfAmt();

                    // double SumTotalGrossAmount = TotalGrossAmount();
                    double SumTotalGrossAmount = TotalHfAmt();

                    double SumTotalCGSTAmount = TotalCGSTAmount();
                    lblCGSTSumTotalAmount.Text = SumTotalCGSTAmount.ToString();

                    double SumTotalSGSTAmount = TotalSGSTAmount();
                    lblSGSTSumTotalAmount.Text = SumTotalSGSTAmount.ToString();

                    double SumTotalIGSTAmount = TotalIGSTAmount();
                    lblIGSTSumTotalAmount.Text = SumTotalIGSTAmount.ToString();

                    double SumTotalAmount = TotalAmount();
                    lblSumTotalAmount.Text = SumTotalAmount.ToString();

                    if (SumTotalGrossAmount.ToString() != string.Empty)
                    {
                        ViewState["GrossAmtCurrentTable_Details"] = SumTotalGrossAmount;
                    }

                    if (lblSumTotalAmount.Text != string.Empty)
                    {

                        ViewState["TotalCurrentTable_Details"] = lblSumTotalAmount.Text.Trim();
                    }

                    if (lblCGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalCGSTAmount_Deatils"] = lblCGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblSGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalSGSTAmount_Deatils"] = lblSGSTSumTotalAmount.Text.Trim();
                    }

                    if (lblIGSTSumTotalAmount.Text != string.Empty)
                    {
                        ViewState["TotalIGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text.Trim();
                    }

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        ViewState["TotalGSTAmount_Deatils"] = Convert.ToDouble(lblCGSTSumTotalAmount.Text) + Convert.ToDouble(lblSGSTSumTotalAmount.Text);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {
                        ViewState["TotalGSTAmount_Deatils"] = lblIGSTSumTotalAmount.Text;
                    }
                    else { }

                    FillNetAmount();
                    TotalAmountCalculationInREC_ISS_M();



                }
                else
                {
                    HfAmount.Value = Convert.ToString(Convert.ToDouble(0));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }




        #endregion


        protected void btnViewInvoive_Click(object sender, EventArgs e)
        {
            //if (HfTranType.Value.ToString() == "S" && HfTrnType.Value.ToString() == "C" || HfTranType.Value.ToString() == "S" && HfTrnType.Value.ToString() == "M")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../reportviewPages/CashSalesMemoInvoicePrint.aspx', '_blank');", true);
            //}
            //else
            //{
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../reportviewPages/ServiceBillInvoicePrint.aspx', '_blank');", true);
            //}

        }

        protected void DdlFigureFlag_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
