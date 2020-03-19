using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp
{
    public partial class RightAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack == true)
                {
                    FillUser();

                    DivCompany.Visible = false;
                    DivBranch.Visible = false;
                    DivYear.Visible = false;
                    DdlBranch.Visible = false;
                    DdlCompany.Visible = false;
                }
            }
            catch (Exception)
            {
            }
        }

        public void HideDivision()
        {
            try
            {
                DivCompany.Visible = false;
                DivBranch.Visible = false;
                DivYear.Visible = false;
                DdlBranch.Visible = false;
                DdlCompany.Visible = false;
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
             //   Dt = COMPANYLogicLayer.GetAllCOMPANYDetials();
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
                string COMPANYCODE = DdlCompany.SelectedValue;
                Dt = BRANCH_MASLogicLayer.GetBranchDetailCompanyWise(COMPANYCODE);
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
            catch(Exception)
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
            catch(Exception)
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
            catch(Exception)
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
            catch(Exception)
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
               FillGridBranch();
               GetBranchByCompany();
        
        }

        protected void DdlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFinYears();
           GetFin_YearsByCompanyByUser();
        }


        protected void GridBranch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
          
        }

        protected void GridBranch_RowCommand(object sender, GridViewCommandEventArgs e)
       {
            try
            {
                if (e.CommandName == "Adda")
                {

                    string str = BRANCH_MASLogicLayer.InsertUSER_BRANCHDetail(e.CommandArgument.ToString(), DdlUser.SelectedValue.ToString(),DdlCompany.SelectedValue.ToString());
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

            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void GridYear_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridYear_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Adda")
                {

                    string str = COMPANYLogicLayer.InsertUSER_YEARS_RIGHTSDetail(DdlCompany.SelectedValue.ToString(), DdlUser.SelectedValue.ToString(),e.CommandArgument.ToString());
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

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GridCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

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

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnCompany_Click(object sender, EventArgs e)
        {
            FillGridCompany();
            HideDivision();
            DivCompany.Visible = true;
        }

        protected void btnBranch_Click(object sender, EventArgs e)
        {
           // FillGridBranch();
            HideDivision();
           
            DdlCompany.Visible = true;
            DivBranch.Visible = true;
        }

        protected void btnYear_Click(object sender, EventArgs e)
        {
            FillFinYears();
            HideDivision();
            DdlBranch.Visible = false;
            DdlCompany.Visible = true;
            DivYear.Visible = true;
        }

        protected void GridCompany_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btn = (e.Row.FindControl("btnAdd") as Button);
                    HiddenField HfId = (e.Row.FindControl("HfCOMP_CODE") as HiddenField);


                    DataTable Dt = new DataTable();
                    string selectedUser = DdlUser.SelectedValue;
                    Dt = COMPANYLogicLayer.GetCompanyDetailUserWiseRights(selectedUser);
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (HfId.Value == Dt.Rows[i]["COMP_CODE"].ToString())
                            btn.Enabled = false;
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

                    DataTable Dt = new DataTable();
                    string USERCODE = DdlUser.SelectedValue;
                    string COMPANYCODE = DdlCompany.SelectedValue;
                    // string brachCode = HfBranch_Code.Value;
                    Dt = BRANCH_MASLogicLayer.GetBranchDetailUserWiseRightsAndCompanyWise(USERCODE, COMPANYCODE);
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (HfId.Value == Dt.Rows[i]["BRANCH_CODE"].ToString())
                            btn.Enabled = false;
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

                    DataTable Dt = new DataTable();
                    string USERCODE = DdlUser.SelectedValue;
                    string COMPANYCODE = DdlCompany.SelectedValue;

                    Dt = COMPANYLogicLayer.GetFIN_YEARSDetailUserWiseRightsAndCompanyWiseForGrid(USERCODE, COMPANYCODE);
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (HfId.Value == Dt.Rows[i]["YRDT1"].ToString())
                            btn.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}