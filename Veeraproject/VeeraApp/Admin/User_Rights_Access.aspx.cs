using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using Veera.LogicLayer;

namespace VeeraApp
{
    public partial class User_Rights : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                    if (!IsPostBack == true)
                {
                    FillUser();
                    Home();
                }
            }
                else
                {
                    Response.Redirect("../Login.aspx");
                }
            }

            catch (Exception)
            {
            }
        }

        public void Home()
        {
            try
            {
                BtnExit.Visible = false;
                DivSelection.Visible = true;
                DivCompany.Visible = false;
                DivBranch.Visible = false;
                DivYear.Visible = false;
                DdlBranch.Visible = false;
                DdlCompany.Visible = false;
                DivEntry.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void HideDivision()
        {
            try
            {
                BtnExit.Visible = false;
                DivCompany.Visible = false;
                DivBranch.Visible = false;
                DivYear.Visible = false;
                DdlBranch.Visible = false;
                DdlCompany.Visible = false;
                DivSelection.Visible = false;
            }
            catch (Exception)
            {
            }
        }



        public void Clear()
        {
            try
            {
                DdlUser.SelectedIndex = 0;
                DdlCompany.SelectedIndex = 0;
                DdlBranch.SelectedIndex = 0;
                lblmsg.Text = string.Empty;


            }
            catch (Exception)
            {
                throw;
            }
        }

        public void FillGridCompany()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = COMPANYLogicLayer.GetAllCOMPANYDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                GridCompany.DataSource = Dt;
                GridCompany.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillGridBranch()
        {
            try
            {
                DataTable Dt = new DataTable();
                string USERCODE = DdlUser.SelectedValue;
                string COMPANYCODE = DdlCompany.SelectedValue;

                Dt = BRANCH_MASLogicLayer.GetBranchDetailCompanyWise(COMPANYCODE, USERCODE);
                GridBranch.DataSource = Dt;
                GridBranch.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillFinYears()
        {
            try
            {
                DataTable Dt = new DataTable();
                //  string USERCODE = DdlUser.SelectedValue;
                string COMPANYCODE = DdlCompany.SelectedValue;
                Dt = COMPANYLogicLayer.GetAllFIN_YEARSDetialsForGrid(COMPANYCODE);
                GridYear.DataSource = Dt;
                GridYear.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void FillUser()
        {
            try
            {
                DataTable dt = USER_MASLogicLayer.GetAllUSER_MASDetials_ForDDl();
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




        private void GetCompanyOfSelectedUser()
        {
            try
            {
                DataTable Dt = new DataTable();
                string selectedUser = DdlUser.SelectedValue;
                Dt = COMPANYLogicLayer.GetCompanyDetailUserWiseRights(selectedUser);
                GridCompany.DataSource = Dt;
                GridCompany.DataBind();
            }
            catch (Exception)
            {
                throw;

            }
        }


        private void GetComapnyByUser()
        {
            try
            {
                string selectedUser = DdlUser.SelectedValue;
                DataTable Dt = COMPANYLogicLayer.GetCompanyDetailUserWiseRights(selectedUser);
                DdlCompany.DataSource = Dt;
                DdlCompany.DataTextField = "NAME";
                DdlCompany.DataValueField = "COMP_CODE";
                DdlCompany.DataBind();

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GetBranchBySelectedCompany()
        {
            try
            {
                DataTable Dt = new DataTable();
                string USERCODE = DdlUser.SelectedValue;
                string COMPANYCODE = DdlCompany.SelectedValue;
                Dt = BRANCH_MASLogicLayer.GetBranchDetailUserWiseRightsAndCompanyWise(USERCODE, COMPANYCODE);
                GridBranch.DataSource = Dt;
                GridBranch.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void GetBranchByCompany()
        {
            try
            {
                string selectedUser = DdlUser.SelectedValue;
                string selectedCompany = DdlCompany.SelectedValue;
                DataTable Dt = BRANCH_MASLogicLayer.GetBranchDetailUserWiseRightsAndCompanyWise(selectedUser, selectedCompany);
                DdlBranch.DataSource = Dt;
                DdlBranch.DataTextField = "BRANCH_NAME";
                DdlBranch.DataValueField = "BRANCH_CODE";
                DdlBranch.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GetFin_YearsByCompanyByUser()
        {
            try
            {
                DataTable Dt = new DataTable();
                string USERCODE = DdlUser.SelectedValue;
                string COMPANYCODE = DdlCompany.SelectedValue;
                string BRANCHCODE = DdlBranch.SelectedValue;
                Dt = COMPANYLogicLayer.GetFIN_YEARSDetailUserWiseRightsAndCompanyWiseForGrid(USERCODE, COMPANYCODE);
                GridYear.DataSource = Dt;
                GridYear.DataBind();

            }
            catch (Exception)
            {
                throw;
            }
        }



        protected void DdlUser_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GetComapnyByUser();
            FillGridCompany();
        }


        protected void DdlCompany_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // GetBranchBySelectedCompany();
            if (DivYear.Visible == true)
            {
                FillFinYears();
            }
            else
            {
                FillGridBranch();
            }
            GetBranchByCompany();

        }

        protected void DdlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetFin_YearsByCompanyByUser();
        }


        protected void GridBranch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridBranch.PageIndex = e.NewPageIndex;
                FillGridBranch();
                Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GridBranch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Adda")
                {

                    string str = BRANCH_MASLogicLayer.InsertUSER_BRANCHDetail(e.CommandArgument.ToString(), DdlUser.SelectedValue.ToString(), DdlCompany.SelectedValue.ToString());
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "BRANCH ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;

                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "BRANCH ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : BRANCH NOT ASSIGNED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else if (e.CommandName == "Removea")
                {

                    string str = BRANCH_MASLogicLayer.DELETEUSER_BRANCHDetail(e.CommandArgument.ToString(), DdlUser.SelectedValue.ToString(), DdlCompany.SelectedValue.ToString());
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "BRANCH REMOVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;

                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "BRANCH ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : BRANCH NOT REMOVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }

                FillGridBranch();

            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void GridYear_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridYear.PageIndex = e.NewPageIndex;
            FillFinYears();
            Clear();
        }

        protected void GridYear_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Adda")
                {

                    string str = COMPANYLogicLayer.InsertUSER_YEARS_RIGHTSDetail(DdlCompany.SelectedValue.ToString(), DdlUser.SelectedValue.ToString(), e.CommandArgument.ToString());
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "YEAR ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;

                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "YEAR ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : YEAR NOT ASSIGNED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else if (e.CommandName == "Removea")
                {

                    string str = COMPANYLogicLayer.DELETEUSER_YEARS_RIGHTSDetail(DdlCompany.SelectedValue.ToString(), DdlUser.SelectedValue.ToString(), e.CommandArgument.ToString());
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "YEAR REMOVED SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;

                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "YEAR ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : YEAR NOT REMOVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                FillFinYears();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GridCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridCompany.PageIndex = e.NewPageIndex;
            FillGridCompany();
            Clear();
        }

        protected void GridCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Adda")
                {

                    string str = COMPANYLogicLayer.InsertUSER_COMPANY_RIGHTSDetail(e.CommandArgument.ToString(), DdlUser.SelectedValue.ToString());
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "COMPANY ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;

                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "COMPANY ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : COMPANY NOT ASSIGNED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else if (e.CommandName == "Removea")
                {
                    string str = COMPANYLogicLayer.DELETEUSER_COMPANY_RIGHTSDetail(e.CommandArgument.ToString(), DdlUser.SelectedValue.ToString());
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "COMPANY REMOVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;

                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "COMPANY ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : COMPANY NOT REMOVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                FillGridCompany();

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnCompany_Click(object sender, EventArgs e)
        {
            //  FillGridCompany();
            DivEntry.Visible = true;
            HideDivision();
            DivCompany.Visible = true;
            //DdlBranch.Visible = false;
            //DdlCompany.Visible = true;
            BtnExit.Visible = true;
        }

        protected void btnBranch_Click(object sender, EventArgs e)
        {
            // FillGridBranch();

            HideDivision();
            DivEntry.Visible = true;
            DivBranch.Visible = true;
            DdlCompany.Visible = true;
            BtnExit.Visible = true;

        }

        protected void btnYear_Click(object sender, EventArgs e)
        {
            //FillFinYears();
            HideDivision();
            DivEntry.Visible = true;
            DdlCompany.Visible = true;
            DivYear.Visible = true;
            BtnExit.Visible = true;
        }

        protected void GridCompany_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btn = (e.Row.FindControl("btnAdd") as Button);
                    HiddenField HfId = (e.Row.FindControl("HfCOMP_CODE") as HiddenField);
                    CheckBox CheckBoxCompany = (e.Row.FindControl("chkCompany") as CheckBox);

                    DataTable Dt = new DataTable();
                    string selectedUser = DdlUser.SelectedValue;
                    Dt = COMPANYLogicLayer.GetCompanyDetailUserWiseRights(selectedUser);
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (HfId.Value == Dt.Rows[i]["COMP_CODE"].ToString())
                        {
                            btn.Enabled = false;
                            CheckBoxCompany.Checked = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GridBranch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btn = (e.Row.FindControl("btnAdd") as Button);
                    HiddenField HfId = (e.Row.FindControl("HfBranch_Code") as HiddenField);
                    CheckBox CheckBoxCompany = (e.Row.FindControl("chkBranch") as CheckBox);

                    DataTable Dt = new DataTable();
                    string USERCODE = DdlUser.SelectedValue;
                    string COMPANYCODE = DdlCompany.SelectedValue;
                    // string brachCode = HfBranch_Code.Value;
                    Dt = BRANCH_MASLogicLayer.GetBranchDetailCompanyWise(COMPANYCODE, USERCODE);
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (HfId.Value == Dt.Rows[i]["BRANCH_CODE"].ToString())
                        {
                            btn.Enabled = false;
                            CheckBoxCompany.Checked = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GridYear_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btn = (e.Row.FindControl("btnAdd") as Button);
                    HiddenField HfId = (e.Row.FindControl("HfYRDT1") as HiddenField);
                    CheckBox CheckBoxFinYear = (e.Row.FindControl("chkFinYear") as CheckBox);

                    DataTable Dt = new DataTable();
                    string USERCODE = DdlUser.SelectedValue;
                    string COMPANYCODE = DdlCompany.SelectedValue;

                    Dt = COMPANYLogicLayer.GetFIN_YEARSDetailUserWiseRightsAndCompanyWiseForGrid(USERCODE, COMPANYCODE);
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (HfId.Value == Dt.Rows[i]["YRDT1"].ToString())
                        {
                            btn.Enabled = false;
                            CheckBoxFinYear.Checked = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void BtnExit_OnClick(object sender, EventArgs e)
        {
            try
            {
                Home();
                Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void chkCompany_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
                CheckBox cb = (CheckBox)GridCompany.Rows[selRowIndex].FindControl("chkCompany");
                HiddenField CompanyCode = (HiddenField)GridCompany.Rows[selRowIndex].FindControl("HfCOMP_CODE");

                if (cb.Checked)
                {
                    //ADD 

                    string str = COMPANYLogicLayer.InsertUSER_COMPANY_RIGHTSDetail(CompanyCode.Value, DdlUser.SelectedValue.ToString());
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "COMPANY ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;

                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "COMPANY ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : COMPANY NOT ASSIGNED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    //REMOVE

                    string str = COMPANYLogicLayer.DELETEUSER_COMPANY_RIGHTSDetail(CompanyCode.Value, DdlUser.SelectedValue.ToString());
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "COMPANY REMOVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;

                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "COMPANY ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : COMPANY NOT REMOVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }


                FillGridCompany();
            }
            catch (Exception)
            {
                throw;
            }


        }

        protected void chkBranch_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
                CheckBox cb = (CheckBox)GridBranch.Rows[selRowIndex].FindControl("chkBranch");
                HiddenField BranchCode = (HiddenField)GridBranch.Rows[selRowIndex].FindControl("HfBranch_Code");

                if (cb.Checked)
                {
                    //ADD

                    string str = BRANCH_MASLogicLayer.InsertUSER_BRANCHDetail(BranchCode.Value, DdlUser.SelectedValue.ToString(), DdlCompany.SelectedValue.ToString());
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "BRANCH ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;

                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "BRANCH ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : BRANCH NOT ASSIGNED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    //REMOVE


                    string str = BRANCH_MASLogicLayer.DELETEUSER_BRANCHDetail(BranchCode.Value, DdlUser.SelectedValue.ToString(), DdlCompany.SelectedValue.ToString());
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "BRANCH REMOVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;

                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "BRANCH ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : BRANCH NOT REMOVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }

                FillGridBranch();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void chkFinYear_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
                CheckBox cb = (CheckBox)GridYear.Rows[selRowIndex].FindControl("chkFinYear");
                HiddenField YearDate1 = (HiddenField)GridYear.Rows[selRowIndex].FindControl("HfYRDT1");

                if (cb.Checked)
                {
                    //ADD

                    string str = COMPANYLogicLayer.InsertUSER_YEARS_RIGHTSDetail(DdlCompany.SelectedValue.ToString(), DdlUser.SelectedValue.ToString(), YearDate1.Value);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "YEAR ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;

                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "YEAR ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : YEAR NOT ASSIGNED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }

                else
                {
                    //REMOVE

                    string str = COMPANYLogicLayer.DELETEUSER_YEARS_RIGHTSDetail(DdlCompany.SelectedValue.ToString(), DdlUser.SelectedValue.ToString(), YearDate1.Value);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "YEAR REMOVED SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;

                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "YEAR ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : YEAR NOT REMOVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }

                FillFinYears();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void chkBranchDefault_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
                CheckBox cb = (CheckBox)GridBranch.Rows[selRowIndex].FindControl("chkBranchDefault");
                HiddenField BranchCode = (HiddenField)GridBranch.Rows[selRowIndex].FindControl("HfBranch_Code");
                string flag = "N";
                if (cb.Checked)
                {
                    flag = "Y";
                }

                int type = 1;
                //ADD

                string str = BRANCH_MASLogicLayer.UpdateUSER_BRANCHDetail(BranchCode.Value, DdlUser.SelectedValue.ToString(), DdlCompany.SelectedValue.ToString(), flag, type);
                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "BRANCH UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;

                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "BRANCH ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : BRANCH NOT ASSIGNED";
                    lblmsg.ForeColor = Color.Red;
                }


                FillGridBranch();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void chkBranchApproval_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
                CheckBox cb = (CheckBox)GridBranch.Rows[selRowIndex].FindControl("chkBranchApproval");
                HiddenField BranchCode = (HiddenField)GridBranch.Rows[selRowIndex].FindControl("HfBranch_Code");
                string flag = "N";
                if (cb.Checked)
                {
                    flag = "Y";
                }

                //ADD
                int type = 2;
                string str = BRANCH_MASLogicLayer.UpdateUSER_BRANCHDetail(BranchCode.Value, DdlUser.SelectedValue.ToString(), DdlCompany.SelectedValue.ToString(), flag, type);
                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "BRANCH UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;

                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "BRANCH ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : BRANCH NOT ASSIGNED";
                    lblmsg.ForeColor = Color.Red;
                }


                FillGridBranch();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void BtnMenuRight_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Menu_Rights.aspx");
        }
    }
}


