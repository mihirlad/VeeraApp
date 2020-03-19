using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;

namespace VeeraApp
{
    public partial class Menu_Rights : System.Web.UI.Page
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
                FillDdlCompany();
                FillDdlUser();
              //  btnSAVE.Visible = true;
                btnEXIT.Visible = true;

            }
        }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        public void Clear()
        {
            try
            {
                DdlCompany.SelectedIndex = 0;
                DdlUser.SelectedIndex = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void FillDdlCompany()
        {
            try
            {
                DataTable dt = COMPANYLogicLayer.GetAllCOMPANYDetials_DDL();
                DdlCompany.SelectedValue = Session["COMP_CODE"].ToString();
                DdlCompany.DataSource = dt;
                DdlCompany.DataValueField = "COMP_CODE";
                DdlCompany.DataTextField = "NAME";
                DdlCompany.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void FillDdlUser()
        {
            try
            {
                string COMP_CODE = DdlCompany.SelectedValue;
                DataTable dt = USER_MASLogicLayer.GetAllUserWiseCompanyRights(COMP_CODE);
                DdlUser.DataSource = dt;
                DdlUser.DataValueField = "USERCODE";
                DdlUser.DataTextField = "USERNAME";
                DdlUser.DataBind();
               
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void FillGridMenu()
        {
            try
            {
                string COMP_CODE = DdlCompany.SelectedValue;
                string USERCODE = DdlUser.SelectedValue;
                DataTable Dt = new DataTable();
                Dt = MENU_MASLogicLayer.GetAllMENU_MASDetialsFor_Grid(Convert.ToInt32(COMP_CODE), Convert.ToInt32((USERCODE)));
                GridMainMenu.DataSource = Dt;
                GridMainMenu.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void DdlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDdlUser();
        }
        protected void DdlUser_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(DdlUser.SelectedIndex==0)
            {
                GridMainMenu.Visible = false;
            }
            else
            {
                FillGridMenu();

            }
           
            if (DdlUser.SelectedIndex != 0)
            {
                btnSAVE.Visible = true;
            }
            else
            {

                btnSAVE.Visible = false;
            }
                btnEXIT.Visible = true;
        }

        protected void GridMainMenu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridMainMenu.PageIndex = e.NewPageIndex;
                FillGridMenu();
                Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //protected void GridMainMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        string COMP_CODE = DdlCompany.SelectedValue;
        //        string USERCODE = DdlUser.SelectedValue;
        //        if (e.CommandName == "ViewAdda")
        //        {

        //            string str = MENU_MASLogicLayer.InsertUSER_RIGHTSDetail(COMP_CODE, USERCODE, e.CommandArgument.ToString()).ToString();
        //            if (str.Contains("successfully"))
        //            {
        //                lblmsg.Text = "MENU VIEW RIGHTS ADD SUCCESSFULLY.";
        //                lblmsg.ForeColor = Color.Green;

        //            }
        //            else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
        //            {
        //                lblmsg.Text = "MENU VIEW RIGHTS ALREADY EXIST.";
        //                lblmsg.ForeColor = Color.Red;
        //            }
        //            else
        //            {
        //                lblmsg.Text = "ERROR : MENU VIEW RIGHTS NOT ASSIGNED";
        //                lblmsg.ForeColor = Color.Red;
        //            }
        //        }
        //        else if (e.CommandName == "ViewRemovea")
        //        {

        //            string str = MENU_MASLogicLayer.DELETEUSER_RIGHTSDetail(COMP_CODE, USERCODE, e.CommandArgument.ToString()).ToString();
        //            if (str.Contains("successfully"))
        //            {
        //                lblmsg.Text = "MENU VIEW RIGHTS REMOVE SUCCESSFULLY.";
        //                lblmsg.ForeColor = Color.Green;

        //            }
        //            else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
        //            {
        //                lblmsg.Text = "MENU VIEW RIGHTS ALREADY EXIST.";
        //                lblmsg.ForeColor = Color.Red;
        //            }
        //            else
        //            {
        //                lblmsg.Text = "ERROR : MENU VIEW RIGHTS NOT REMOVED";
        //                lblmsg.ForeColor = Color.Red;
        //            }
        //        }
        //        FillGridMenu();

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //protected void GridMainMenu_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            Button btn = (e.Row.FindControl("btnViewAdd") as Button);
        //            HiddenField HfId = (e.Row.FindControl("HfCODE") as HiddenField);
        //            CheckBox CheckBoxCompany = (e.Row.FindControl("chkMenuView") as CheckBox);

        //            DataTable Dt = new DataTable();
        //            string COMP_CODE = DdlCompany.SelectedValue;
        //            string USERCODE = DdlUser.SelectedValue;

        //            Dt = MENU_MASLogicLayer.GetAllMENU_MASDetialsFor_Grid(Convert.ToInt32(COMP_CODE), Convert.ToInt32((USERCODE)));
        //            for (int i = 0; i < Dt.Rows.Count; i++)
        //            {
        //                if (HfId.Value == Dt.Rows[i]["CODE"].ToString() && COMP_CODE == Dt.Rows[i]["COMP_CODE"].ToString() && USERCODE == Dt.Rows[i]["USERCODE"].ToString())
        //                {
        //                    btn.Enabled = false;
        //                    CheckBoxCompany.Checked = true;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        protected void btnSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                USER_RIGHTSLogicLayer insert = new USER_RIGHTSLogicLayer();
               
                insert.COMP_CODE = DdlCompany.SelectedValue.ToString();
                insert.USERCODE = DdlUser.SelectedValue.ToString();
                insert.REF_CODE = "0";
                insert.CODE = "0";
                insert.SYSCODE = "0";
                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);


                foreach (GridViewRow row in GridMainMenu.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfCODEVal = row.FindControl("HfCODE") as HiddenField;
                        HiddenField HfSYSCODEVAL = row.FindControl("HfSYSCODE") as HiddenField;
                        HiddenField HfREF_CODEVal = row.FindControl("HfREF_CODE") as HiddenField;
                        CheckBox CheckboxView = row.FindControl("chkMenuView") as CheckBox;
                        CheckBox chkMenuInsert = row.FindControl("chkMenuInsert") as CheckBox;
                        CheckBox chkMenuUpdate = row.FindControl("chkMenuUpdate") as CheckBox;
                        CheckBox chkMenuDelete = row.FindControl("chkMenuDelete") as CheckBox;
                        CheckBox chkUniConfirm = row.FindControl("chkUnConfirm") as CheckBox;
                        CheckBox chkApproval = row.FindControl("chkApproval") as CheckBox;
                        CheckBox chkAuthorise = row.FindControl("chkAuthorise") as CheckBox;

                     
                        XmlElement HandleDetail2 = XDoc1.CreateElement("Detail");
                        HandleDetail2.SetAttribute("CODE", HfCODEVal.Value);
                        HandleDetail2.SetAttribute("SYSCODE", HfSYSCODEVAL.Value);
                        HandleDetail2.SetAttribute("REF_CODE", HfREF_CODEVal.Value==""?"0": HfREF_CODEVal.Value);
                        HandleDetail2.SetAttribute("MENU_VIEW", Convert.ToString(CheckboxView.Checked == true ? "Y" : "N"));
                        HandleDetail2.SetAttribute("REC_INS", Convert.ToString(chkMenuInsert.Checked == true ? "Y" : "N"));
                        HandleDetail2.SetAttribute("REC_UPD", Convert.ToString(chkMenuUpdate.Checked == true ? "Y" : "N"));
                        HandleDetail2.SetAttribute("REC_DEL", Convert.ToString(chkMenuDelete.Checked == true ? "Y" : "N"));
                        HandleDetail2.SetAttribute("UNCONFIRM", Convert.ToString(chkUniConfirm.Checked == true ? "Y" : "N"));
                        HandleDetail2.SetAttribute("APPROVAL", Convert.ToString(chkApproval.Checked == true ? "Y" : "N"));
                        HandleDetail2.SetAttribute("AUTHORISE", Convert.ToString(chkAuthorise.Checked == true ? "Y" : "N"));
                        root1.AppendChild(HandleDetail2);
                    }
                }

                string str = USER_RIGHTSLogicLayer.InsertUSER_RIGHTSDetail(insert, XDoc1.OuterXml);

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "MENU  RIGHTS ADD SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;

                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "MENU RIGHTS ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : MENU RIGHTS NOT ASSIGNED";
                    lblmsg.ForeColor = Color.Red;
                }
            }

                    //XDoc1.OuterXml
        

            catch (Exception)
            {

                throw;
            }
        }

        protected void btnEXIT_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }
    }


}
