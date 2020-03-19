using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillCompany()
        {
            try
            {
                DataTable Dt = COMPANYLogicLayer.GetCompanyDetailUserWiseRights(ViewState["USERCODE"].ToString());
                DdlCompany.DataSource = Dt;
                DdlCompany.DataValueField = "COMP_CODE";
                DdlCompany.DataTextField = "NAME";
                DdlCompany.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillBranch(string CompCode)
        {
            try
            {

                DataTable Dt = BRANCH_MASLogicLayer.GetBranchDetailUserWiseRightsAndCompanyWise(ViewState["USERCODE"].ToString(), CompCode);
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

        public static string GetCurrentFinancialYear()
        {
            string FinYear = null;
            try
            {
                int CurrentYear = DateTime.Today.Year;
                int PreviousYear = DateTime.Today.Year - 1;
                int NextYear = DateTime.Today.Year + 1;
                string PreYear = PreviousYear.ToString();
                string NexYear = NextYear.ToString();
                string CurYear = CurrentYear.ToString();

                if (DateTime.Today.Month > 3)
                    FinYear = CurYear;// + "-" + NexYear;
                else
                    FinYear = PreYear;// + "-" + CurYear;


            }
            catch (Exception)
            { }
            return FinYear.Trim();

        }

        public void FillYear(string CompCode)
        {
            try
            {
                DataTable GetYear = COMPANYLogicLayer.GetAllFinancialYearDetials(CompCode);
                string Year = GetCurrentFinancialYear();
                if (GetYear.Rows.Count > 0)
                {
                    DataView DV = new DataView(GetYear);
                    DV.RowFilter = "YRDT1='" + Year + "-04-01 00:00:00.000'";

                    DataTable DT = DV.ToTable();

                    if (DT.Rows.Count == 0)
                    {
                        string Ans = COMPANYLogicLayer.InsertFinancialYearDetials(CompCode, Year + "-04-01 00:00:00.000", (Convert.ToInt32(Year) + 1).ToString() + "-03-31 00:00:00.000");
                    }
                }
                DataTable Dt = COMPANYLogicLayer.GetFIN_YEARSDetailUserWiseRightsAndCompanyWise(ViewState["USERCODE"].ToString(), CompCode);
                DdlFinYear.DataSource = Dt;
                DdlFinYear.DataValueField = "YRDT1";
                DdlFinYear.DataTextField = "YearString";
                DdlFinYear.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnLogin_click(object sender, EventArgs e)
        {
            try
            {
                //string en = encrypt(TxtPassword.Text.Trim());
                DataTable DtLogin = USER_MASLogicLayer.GetUserMasterAuthentication(TxtUserName.Text.Trim(), encrypt(TxtPassword.Text.Trim()));
                if (DtLogin.Rows.Count > 0)
                {
                    lblMsg.Text = string.Empty;
                    ViewState["USERCODE"] = DtLogin.Rows[0]["USERCODE"].ToString();
                    ViewState["USERNAME"] = DtLogin.Rows[0]["USERNAME"].ToString();
                    ViewState["USERTYPE"] = DtLogin.Rows[0]["USERTYPE"].ToString();
                    FillCompany();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
                }
                else
                {
                    lblMsg.Text = "USERNAME OR PASSWORD INCORRECT...!";
                    lblMsg.ForeColor = Color.Red;
                }
            }
            catch (Exception)
            {

                throw;
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

        public string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

        public static string GetMachinName()
        {
            string domainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
            string hostName = Dns.GetHostName();
            string fqdn = "";
            if (!hostName.Contains(domainName))
                fqdn = hostName + "." + domainName;
            else
                fqdn = hostName;

            return fqdn;
        }

        protected void BtnCompanyLogin_click(object sender, EventArgs e)
        {
            try
            {
                Session["USERCODE"] = ViewState["USERCODE"].ToString();
                Session["USERNAME"] = ViewState["USERNAME"].ToString();
                Session["USERTYPE"] = ViewState["USERTYPE"].ToString();
                Session["COMP_CODE"] = DdlCompany.SelectedValue;
                Session["COMP_NAME"] = DdlCompany.SelectedItem.Text;
                //Session["WORK_VIEWFLAG"] 
                DataTable DtWorkFlag = COMPANYLogicLayer.GetCompanyDetailUserWiseRights(ViewState["USERCODE"].ToString());
                if (DtWorkFlag.Rows.Count > 0)
                {
                    DataView DvFlag = new DataView(DtWorkFlag);
                    DvFlag.RowFilter = "COMP_CODE='" + Session["COMP_CODE"].ToString() + "'";
                    DataTable Dtflag = DvFlag.ToTable();
                    if (Dtflag.Rows.Count > 0)
                    {
                        Session["WORK_VIEWFLAG"] = Dtflag.Rows[0]["WORK_VIEWFLAG"].ToString();
                        Session["INVTYPE_FLAG"] = Dtflag.Rows[0]["INVTYPE_FLAG"].ToString();
                    }
                    else
                    {
                        Session["WORK_VIEWFLAG"] = null;
                        Session["INVTYPE_FLAG"] = null;
                    }
                }


                Session["BRANCH_CODE"] = DdlBranch.SelectedValue;
                Session["BRANCH_NAME"] = DdlBranch.SelectedItem.Text;

                DataTable dt = BRANCH_MASLogicLayer.GetIDWiseBRANCH_MASDetialsByCompany(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (dt.Rows.Count > 0)
                {
                    Session["BRANCH_TYPE"] = dt.Rows[0]["BRANCH_TYPE"].ToString();
                }

                Session["FIN_YEAR"] = DdlFinYear.SelectedValue;//YRDT1

                Session["MAC"] = GetMACAddress();
                Session["PC"] = GetMachinName();
                Session["INSERT"] = "Y";
                Session["UPDATE"] = "Y";
                Session["DELETE"] = "Y";

                DataTable Dt = COMPANYLogicLayer.GetFIN_YEARSDetailUserWiseRightsAndCompanyWise(Session["USERCODE"].ToString(), Session["COMP_CODE"].ToString());
                if (Dt.Rows.Count > 0)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "YRDT1='" + Session["FIN_YEAR"].ToString() + "'";
                    DataTable DtV = Dv.ToTable();
                    if (DtV.Rows.Count > 0)
                    {
                        Session["FIN_YEAR_END"] = DtV.Rows[0]["YRDT2"].ToString();
                    }
                    else
                    {
                        Session["FIN_YEAR_END"] = null;
                    }
                }
                else
                {
                    Session["FIN_YEAR_END"] = null;
                }

                USERLOGINLogicLayer insert = new USERLOGINLogicLayer();
                insert.LCL_ID = Session["PC"].ToString();
                insert.MAC_ID = Session["MAC"].ToString();
                insert.USERNAME = Session["USERNAME"].ToString();
                string str = USERLOGINLogicLayer.InsertUSERLOGINDetials(insert);
                if (!str.Contains("successfully"))
                {
                    //Response.Redirect("../Login.aspx");
                }

                Response.Redirect("~/Admin/Dashboard.aspx", false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlCompany_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlCompany.SelectedIndex != 0)
                {
                    FillBranch(DdlCompany.SelectedValue);
                    FillYear(DdlCompany.SelectedValue);
                }
                else
                {
                    DdlBranch.Items.Clear();
                    DdlFinYear.Items.Clear();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}