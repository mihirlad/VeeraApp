using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class CompanyYearSelection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERCODE"] != null &&
               Session["USERNAME"] != null &&
               Session["USERTYPE"] != null)

            {
                if (!IsPostBack == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
                    FillCompany();
                  

                }
              
            }
        }



        public void FillCompany()
        {
            try
            {
                DataTable Dt = COMPANYLogicLayer.GetCompanyDetailUserWiseRights(Session["USERCODE"].ToString());
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

                DataTable Dt = BRANCH_MASLogicLayer.GetBranchDetailUserWiseRightsAndCompanyWise(Session["USERCODE"].ToString(), CompCode);
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

        public void FillYear(string CompCode)
        {
            try
            {
                DataTable Dt = COMPANYLogicLayer.GetFIN_YEARSDetailUserWiseRightsAndCompanyWise(Session["USERCODE"].ToString(), CompCode);
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

        protected void DdlCompany_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void BtnCompanyLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Session["USERCODE"] = Session["USERCODE"].ToString();
                Session["USERNAME"] = Session["USERNAME"].ToString();
                Session["USERTYPE"] = Session["USERTYPE"].ToString();
                Session["COMP_CODE"] = DdlCompany.SelectedValue;
                Session["COMP_NAME"] = DdlCompany.SelectedItem.Text;
                //Session["WORK_VIEWFLAG"] 
                DataTable DtWorkFlag = COMPANYLogicLayer.GetCompanyDetailUserWiseRights(Session["USERCODE"].ToString());
                if (DtWorkFlag.Rows.Count > 0)
                {
                    DataView DvFlag = new DataView(DtWorkFlag);
                    DvFlag.RowFilter = "COMP_CODE='" + Session["COMP_CODE"].ToString() + "'";
                    DataTable Dtflag = DvFlag.ToTable();
                    if (Dtflag.Rows.Count > 0)
                    {
                        Session["WORK_VIEWFLAG"] = Dtflag.Rows[0]["WORK_VIEWFLAG"].ToString();
                    }
                    else
                    {
                        Session["WORK_VIEWFLAG"] = null;
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

                Response.Redirect("/Admin/Dashboard.aspx", false);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}