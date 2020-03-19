using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;
using MihirValid;

namespace VeeraApp
{
    public partial class PartyModelMaster : System.Web.UI.Page
    {
        public static string compcode;
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
            Session["DELETE"] != null)

            {
                compcode = Session["COMP_CODE"].ToString();

                if (!Page.IsPostBack)
                {

                    DivEntry.Visible = false;
                    DivView.Visible = true;
                    FillDdlAccountName();

                    FillDdlBrandName();
                    FillDdlPersonName();
                    FillPartyModelMasterGrid(Session["COMP_CODE"].ToString());
                    FillPartyModalDetailGrid();
                    SetInitialRow();
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        public void FillModelSrNo(int CompanyCode, int Acode)
        {
            try
            {
                string ID = PARTY_MODELMASLogicLayer.Get_model_srno(Acode, CompanyCode);
                if (ID.Length <= 8)
                {
                    TxtModelSrNo.Text = ID;
                }
                else
                {
                    TxtModelSrNo.Text = "INVALID";
                }
            }
            catch (Exception)
            {

                throw;
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
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select ACODE from ACCOUNTS where ANAME = '" + TxtAccountName.Text + "' and COMP_CODE = " + Session["COMP_CODE"].ToString(), con);
                int x = Convert.ToInt32(cmd.ExecuteScalar());
                if (x == 0)
                {
                    TxtAccountName.BackColor = Color.Red;
                }
                else
                {
                    HfACODE.Value = cmd.ExecuteScalar().ToString();
                    TxtAccountName.BackColor = Color.White; con.Close();


                    if (TxtAccountName.Text!=string.Empty)
                    {
                        FillModelSrNo(Convert.ToInt32(Session["COMP_CODE"]), Convert.ToInt32(HfACODE.Value));
                    }
                    else
                    {
                        TxtModelSrNo.Text = string.Empty;
                    }
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void FillDdlAccountName()
        {
            try
            {
                //string Comp_Code = Session["COMP_CODE"].ToString();

                //DataTable Dt = new DataTable();
                //Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
                //DdlAccountName.DataSource = Dt;
                //DdlAccountName.DataValueField = "ACODE";
                //DdlAccountName.DataTextField = "ANAME";
                //DdlAccountName.DataBind();
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

        public void FillDdlBrandName()
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = STOCK_BRANDMASLogicLayer.GetSTOCKBRANDMAS_BrandNameCompanyWiseFor_Ddl(Comp_Code);
                DdlBrandName.DataSource = Dt;
                DdlBrandName.DataValueField = "BRAND_CODE";
                DdlBrandName.DataTextField = "BRAND_NAME";
                DdlBrandName.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        public void FillDdlModelName()
        {
            try
            {
                string Brand_Code = DdlBrandName.SelectedValue;

                DataTable Dt = new DataTable();
                Dt = STOCK_MODELMASLogicLayer.GetSTOCK_MODELMAS_ModelNameBrandWiseFor_Ddl(Brand_Code);
                DdlModelName.DataSource = Dt;
                DdlModelName.DataValueField = "MODEL_CODE";
                DdlModelName.DataTextField = "MODEL_NAME";
                DdlModelName.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlBrandName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDdlModelName();
        }

        public void FillDdlPersonName()
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKER_MASDetialsCompanyWiseFor_DDL(Comp_Code);
                DdlServicePersonName.DataSource = Dt;
                DdlServicePersonName.DataValueField = "BCODE";
                DdlServicePersonName.DataTextField = "BNAME";
                DdlServicePersonName.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillPartyModalDetailGrid()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = PARTY_MODELDETLogicLayer.GetAllPARTY_MODELDETDetailByCompany((Session["COMP_CODE"].ToString()));
                GvPartyModalDetails.DataSource = Dt;
                GvPartyModalDetails.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvPartyModalDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvPartyModalDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    TextBox TxtProductCode = (e.Row.FindControl("TxtProductCode") as TextBox);
                    TextBox TxtProductName = (e.Row.FindControl("TxtProductName") as TextBox);
                    DropDownList DdlProductName = (e.Row.FindControl("DdlProductName") as DropDownList);
                    HiddenField HfDetailSCode = (e.Row.FindControl("HfDetailSCode") as HiddenField);

                    DataTable DtProduct = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();

                    DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
                    //DdlProductName.DataValueField = "SCODE";
                    //DdlProductName.DataTextField = "SNAME";
                    //DdlProductName.DataSource = Dt;
                    //DdlProductName.DataBind();

                    //DdlProductName.SelectedValue = HfDetailSCode.Value;


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

            }
            catch (Exception)
            {

                throw;
            }
        }


        private void ClearSetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("ACODE", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("CHK_MAJOR", typeof(string));
            table.Columns.Add("CHK_NORMAL", typeof(string));
            table.Columns.Add("ORD", typeof(string));




            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["ACODE"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["SCODE"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["CHK_MAJOR"] = false;
            dr["CHK_NORMAL"] = false;
            dr["ORD"] = string.Empty;

            table.Rows.Add(dr);

            //ViewState["CurrentTable"] = table;

            GvPartyModalDetails.DataSource = table;
            GvPartyModalDetails.DataBind();
        }

        private void SetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("ACODE", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("CHK_MAJOR", typeof(string));
            table.Columns.Add("CHK_NORMAL", typeof(string));
            table.Columns.Add("ORD", typeof(string));




            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["ACODE"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["SCODE"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["CHK_MAJOR"] = false;
            dr["CHK_NORMAL"] = false;
            dr["ORD"] = string.Empty;

            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvPartyModalDetails.DataSource = table;
            GvPartyModalDetails.DataBind();
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

                        HiddenField HfDetailSCode = (HiddenField)GvPartyModalDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtOrder = (TextBox)GvPartyModalDetails.Rows[rowIndex].Cells[1].FindControl("TxtOrder");
                        TextBox TxtProductCode = (TextBox)GvPartyModalDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvPartyModalDetails.Rows[rowIndex].Cells[3].FindControl("TxtProductName");
                        DropDownList DdlProductName = (DropDownList)GvPartyModalDetails.Rows[rowIndex].Cells[4].FindControl("DdlProductName");
                        TextBox TxtQuantity = (TextBox)GvPartyModalDetails.Rows[rowIndex].Cells[5].FindControl("TxtQuantity");
                        CheckBox ChkBoxMajor = (CheckBox)GvPartyModalDetails.Rows[rowIndex].Cells[6].FindControl("ChkBoxMajor");
                        CheckBox ChkBoxNormal = (CheckBox)GvPartyModalDetails.Rows[rowIndex].Cells[7].FindControl("ChkBoxNormal");



                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["CHK_MAJOR"] = ChkBoxMajor.Checked;
                        dtCurrentTable.Rows[i - 1]["CHK_NORMAL"] = ChkBoxNormal.Checked;
                        dtCurrentTable.Rows[i - 1]["ORD"] = TxtOrder.Text;

                        rowIndex++;

                    }

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["SRNO"] = rowIndex + 1;
                    drCurrentRow["SCODE"] = "0";
                    drCurrentRow["QTY"] = "0";
                    drCurrentRow["CHK_MAJOR"] = "false";
                    drCurrentRow["CHK_NORMAL"] = "false";
                    drCurrentRow["ORD"] = "0";

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvPartyModalDetails.DataSource = dtCurrentTable;
                    GvPartyModalDetails.DataBind();
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
                        HiddenField HfDetailSCode = (HiddenField)GvPartyModalDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtOrder = (TextBox)GvPartyModalDetails.Rows[rowIndex].Cells[1].FindControl("TxtOrder");
                        TextBox TxtProductCode = (TextBox)GvPartyModalDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvPartyModalDetails.Rows[rowIndex].Cells[3].FindControl("TxtProductName");
                        DropDownList DdlProductName = (DropDownList)GvPartyModalDetails.Rows[rowIndex].Cells[4].FindControl("DdlProductName");
                        TextBox TxtQuantity = (TextBox)GvPartyModalDetails.Rows[rowIndex].Cells[5].FindControl("TxtQuantity");
                        CheckBox ChkBoxMajor = (CheckBox)GvPartyModalDetails.Rows[rowIndex].Cells[6].FindControl("ChkBoxMajor");
                        CheckBox ChkBoxNormal = (CheckBox)GvPartyModalDetails.Rows[rowIndex].Cells[7].FindControl("ChkBoxNormal");

                        HfDetailSCode.Value = dt.Rows[i]["SCODE"].ToString();
                        TxtQuantity.Text = dt.Rows[i]["QTY"].ToString();
                        ChkBoxMajor.Checked = Convert.ToBoolean(dt.Rows[i]["CHK_MAJOR"].ToString());
                        ChkBoxNormal.Checked = Convert.ToBoolean(dt.Rows[i]["CHK_NORMAL"].ToString());
                        TxtOrder.Text = dt.Rows[i]["ORD"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        protected void BtnAddRowModelDetailGrid_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewRowToGrid();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnDeleteRowModelDetailGrid_Click(object sender, EventArgs e)
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
                GvPartyModalDetails.DataSource = dt;
                GvPartyModalDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }

        public void ControllerEnable()
        {
            TxtAccountName.Enabled = true;
            TxtModelSrNo.Enabled = false;
            TxtPartySrNo.Enabled = true;
            DdlBrandName.Enabled = true;
            DdlModelName.Enabled = true;
            TxtModelRemark.Enabled = true;
            DdlActive.Enabled = true;
            TxtMfgSrNo.Enabled = true;
            DdlServiceType.Enabled = true;
            TxtLastAMCNo.Enabled = false;
            TxtLastAMCDate.Enabled = false;
            TxtInstallationDate.Enabled = true;
            DdlServicePersonName.Enabled = true;
            TxtOtherRemarks.Enabled = true;
            TxtAMCFromDate.Enabled = false;
            TxtToDate.Enabled = false;
        }

        public void ControllerDisable()
        {
            TxtAccountName.Enabled = false;
            TxtModelSrNo.Enabled = false;
            TxtPartySrNo.Enabled = false;
            DdlBrandName.Enabled = false;
            DdlModelName.Enabled = false;
            TxtModelRemark.Enabled = false;
            DdlActive.Enabled = false;
            TxtMfgSrNo.Enabled = false;
            DdlServiceType.Enabled = false;
            TxtLastAMCNo.Enabled = false;
            TxtLastAMCDate.Enabled = false;
            TxtInstallationDate.Enabled = false;
            DdlServicePersonName.Enabled = false;
            TxtOtherRemarks.Enabled = false;
            TxtAMCFromDate.Enabled = false;
            TxtToDate.Enabled = false;
        }


        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfCompCode.Value = string.Empty;
            HfBranchCode.Value = string.Empty;
            HfSrNo.Value = string.Empty;
            HfSubSrNo.Value = string.Empty;
            TxtAccountName.Text = string.Empty;
            TxtModelSrNo.Text = string.Empty;
            TxtPartySrNo.Text = string.Empty;
            DdlBrandName.SelectedIndex = 0;
            DdlModelName.SelectedIndex = 0;
            TxtModelRemark.Text = string.Empty;
            DdlActive.SelectedIndex = 0;
            TxtMfgSrNo.Text = string.Empty;
            DdlServiceType.SelectedIndex = 0;
            TxtLastAMCNo.Text = string.Empty;
            TxtLastAMCDate.Text = string.Empty;
            TxtInstallationDate.Text = string.Empty;
            DdlServicePersonName.SelectedIndex = 0;
            TxtOtherRemarks.Text = string.Empty;
            TxtAMCFromDate.Text = string.Empty;
            TxtToDate.Text = string.Empty;

            ClearSetInitialRow();

            BtncallUpd.Text = "SAVE";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            lblmsg.Text = string.Empty;
            UserRights();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                FillDdlModelName();
                clear();
                ControllerEnable();
                UserRights();
                Btncalldel.Visible = false;
                BtncallUpd.Visible = true;
                btnSave.Enabled = true;
                btnSave.Visible = true;
                DivEntry.Visible = true;
                DivView.Visible = false;
                GvPartyModalDetails.Enabled = true;
             
                if (TxtAccountName.Text!=string.Empty)
                {
                    FillModelSrNo(Convert.ToInt32(Session["COMP_CODE"]), Convert.ToInt32(HfACODE.Value));
                }
                else
                {
                    TxtModelSrNo.Text = string.Empty;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlAccountName_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (DdlAccountName.SelectedIndex > 0)
            //    {
            //        FillModelSrNo(Convert.ToInt32(Session["COMP_CODE"]), Convert.ToInt32(DdlAccountName.SelectedValue));
            //    }
            //    else
            //    {
            //        TxtModelSrNo.Text = string.Empty;
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

      


        public void FillPartyModelMasterGrid(string CompCode)
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = PARTY_MODELMASLogicLayer.GetAllPARTY_MODELMASDetail(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvPartyModelMaster.DataSource = Dv.ToTable();
                GvPartyModelMaster.DataBind();

                DtSearch = Dv.ToTable();
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

        protected void GvPartyModelMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvPartyModalDetails.PageIndex = e.NewPageIndex;
                clear();
                FillPartyModelMasterGrid(Session["COMP_CODE"].ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvPartyModelMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Deletea")
                {
                    #region DELETE
             //       clear();
                    DataSet ds = PARTY_MODELMASLogicLayer.GetAllIDWisePARTY_MODELMASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable dtDet = ds.Tables[1];

                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                        HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        FillDdlAccountNameOnUpdate( dt.Rows[0]["ACODE"].ToString());
                        //     FillModelSrNo(Convert.ToInt32(Session["COMP_CODE"]), Convert.ToInt32(DdlAccountName.SelectedValue));
                        TxtModelSrNo.Text = dt.Rows[0]["MODEL_SRNO"].ToString();
                        TxtPartySrNo.Text = dt.Rows[0]["PARTY_SRNO"].ToString();
                        FillDdlBrandName();
                        DdlBrandName.SelectedValue = dt.Rows[0]["BRAND_CODE"].ToString();
                        FillDdlModelName();
                        DdlModelName.SelectedValue = dt.Rows[0]["MODEL_CODE"].ToString();
                        TxtModelRemark.Text = dt.Rows[0]["MODEL_REMARK"].ToString();
                        DdlActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                        TxtMfgSrNo.Text = dt.Rows[0]["MFG_SRNO"].ToString();
                        DdlServiceType.SelectedValue = dt.Rows[0]["SERVICE_TYPE"].ToString();
                        TxtLastAMCDate.Text = dt.Rows[0]["AMC_TRAN_DATE"].ToString();
                        TxtLastAMCNo.Text = dt.Rows[0]["AMC_TRAN_NO"].ToString();
                        TxtInstallationDate.Text = Convert.ToDateTime(dt.Rows[0]["INSTALL_DATE"].ToString()).ToString("dd-MM-yyyy");
                        DdlServicePersonName.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                        TxtOtherRemarks.Text = dt.Rows[0]["REMARK"].ToString();

                        if (dtDet.Rows.Count > 0)
                        {
                            ViewState["CurrentTable"] = dtDet;
                            GvPartyModalDetails.DataSource = dtDet;
                            GvPartyModalDetails.DataBind();
                        }
                    }
                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    Btncalldel.Visible = true;
                    BtncallUpd.Visible = false;
                    ControllerDisable();
                    GvPartyModalDetails.Enabled = false;

                    #endregion
                }


                if (e.CommandName == "Edita")
                {
                    #region EDIT
                 //   clear();
                    DataSet ds = PARTY_MODELMASLogicLayer.GetAllIDWisePARTY_MODELMASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable dtDet = ds.Tables[1];

                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                        HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        FillDdlAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                   //     FillModelSrNo(Convert.ToInt32(Session["COMP_CODE"]), Convert.ToInt32(DdlAccountName.SelectedValue));
                        TxtModelSrNo.Text = dt.Rows[0]["MODEL_SRNO"].ToString();
                        TxtPartySrNo.Text = dt.Rows[0]["PARTY_SRNO"].ToString();
                        FillDdlBrandName();
                        DdlBrandName.SelectedValue = dt.Rows[0]["BRAND_CODE"].ToString();
                        FillDdlModelName();
                        DdlModelName.SelectedValue = dt.Rows[0]["MODEL_CODE"].ToString();
                        TxtModelRemark.Text = dt.Rows[0]["MODEL_REMARK"].ToString();
                        DdlActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                        TxtMfgSrNo.Text = dt.Rows[0]["MFG_SRNO"].ToString();
                        DdlServiceType.SelectedValue = dt.Rows[0]["SERVICE_TYPE"].ToString();
                        TxtLastAMCDate.Text = dt.Rows[0]["AMC_TRAN_DATE"].ToString();
                        TxtLastAMCNo.Text = dt.Rows[0]["AMC_TRAN_NO"].ToString();
                        TxtInstallationDate.Text = Convert.ToDateTime(dt.Rows[0]["INSTALL_DATE"].ToString()).ToString("dd-MM-yyyy");
                        DdlServicePersonName.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                        TxtOtherRemarks.Text = dt.Rows[0]["REMARK"].ToString();

                        if (dtDet.Rows.Count > 0)
                        {
                            ViewState["CurrentTable"] = dtDet;
                            GvPartyModalDetails.DataSource = dtDet;
                            GvPartyModalDetails.DataBind();
                        }

                        BtncallUpd.Text = "UPDATE";

                        #endregion
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
                    GvPartyModalDetails.Enabled = true;
                }

                if (e.CommandName == "Viewa")
                {
                    #region SET TEXT ON VIEW
               //     clear();
                    DataSet ds = PARTY_MODELMASLogicLayer.GetAllIDWisePARTY_MODELMASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable dtDet = ds.Tables[1];

                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                        HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        FillDdlAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                        //     FillModelSrNo(Convert.ToInt32(Session["COMP_CODE"]), Convert.ToInt32(DdlAccountName.SelectedValue));
                        TxtModelSrNo.Text = dt.Rows[0]["MODEL_SRNO"].ToString();
                        TxtPartySrNo.Text = dt.Rows[0]["PARTY_SRNO"].ToString();
                        FillDdlBrandName();
                        DdlBrandName.SelectedValue = dt.Rows[0]["BRAND_CODE"].ToString();
                        FillDdlModelName();
                        DdlModelName.SelectedValue = dt.Rows[0]["MODEL_CODE"].ToString();
                        TxtModelRemark.Text = dt.Rows[0]["MODEL_REMARK"].ToString();
                        DdlActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                        TxtMfgSrNo.Text = dt.Rows[0]["MFG_SRNO"].ToString();
                        DdlServiceType.SelectedValue = dt.Rows[0]["SERVICE_TYPE"].ToString();
                        TxtLastAMCDate.Text = dt.Rows[0]["AMC_TRAN_DATE"].ToString();
                        TxtLastAMCNo.Text = dt.Rows[0]["AMC_TRAN_NO"].ToString();
                        TxtInstallationDate.Text = Convert.ToDateTime(dt.Rows[0]["INSTALL_DATE"].ToString()).ToString("dd-MM-yyyy");
                        DdlServicePersonName.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                        TxtOtherRemarks.Text = dt.Rows[0]["REMARK"].ToString();

                        if (dtDet.Rows.Count > 0)
                        {
                            ViewState["CurrentTable"] = dtDet;
                            GvPartyModalDetails.DataSource = dtDet;
                            GvPartyModalDetails.DataBind();
                        }
                    }

                    #endregion
                    ControllerDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    UserRights();
                    GvPartyModalDetails.Enabled = false;

                }
            }
            catch (Exception ex)
            {

                lblmsg.Text = ex.Message.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region UPDATE PARTY MODEL MASTER

                #region INSERT PARTY MODEL MASTER

                PARTY_MODELMASLogicLayer insert = new PARTY_MODELMASLogicLayer();
                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.BRANCH_CODE = HfBranchCode.Value.Trim();
                insert.ACODE = HfACODE.Value.Trim();
                insert.SRNO = HfSrNo.Value.Trim();
                insert.MODEL_SRNO = TxtModelSrNo.Text.Trim();
                insert.PARTY_SRNO = TxtPartySrNo.Text.Trim().ToUpper();
                insert.BRAND_CODE = DdlBrandName.SelectedValue.Trim();
                insert.MODEL_CODE = DdlModelName.SelectedValue.Trim();
                insert.MODEL_REMARK = TxtModelRemark.Text.Trim().ToUpper();
                insert.ACTIVE = DdlActive.SelectedValue.Trim();
                insert.MFG_SRNO = TxtMfgSrNo.Text.Trim().ToUpper();
                insert.SERVICE_TYPE = DdlServiceType.SelectedValue.Trim();
                insert.BCODE = DdlServicePersonName.SelectedValue.Trim();
                insert.REMARK = TxtOtherRemarks.Text.Trim().ToUpper();
                insert.AMC_TRAN_DATE = TxtLastAMCDate.Text.Trim();
                if (TxtLastAMCNo.Text == string.Empty)
                {
                    insert.AMC_TRAN_NO = "0";
                }
                else
                {
                    insert.AMC_TRAN_NO = TxtLastAMCNo.Text.Trim();
                }
                insert.AMC_SRNO = "0";
                if (TxtInstallationDate.Text == string.Empty)
                {
                    insert.INSTALL_DATE = "";
                }
                else
                {
                    insert.INSTALL_DATE = Convert.ToDateTime(TxtInstallationDate.Text.Trim()).ToString("MM-dd-yyyy");
                }
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";

                #endregion

                #region INSERT PARTY MODEL DETAILS

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);
                int SUBSRNO_DET = 1;

                foreach (GridViewRow row in GvPartyModalDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        TextBox TxtOrder = row.FindControl("TxtOrder") as TextBox;
                        DropDownList DdlProductName = row.FindControl("DdlProductName") as DropDownList;
                        TextBox TxtQuantity = row.FindControl("TxtQuantity") as TextBox;
                        CheckBox ChkBoxMajor = row.FindControl("ChkBoxMajor") as CheckBox;
                        CheckBox ChkBoxNormal = row.FindControl("ChkBoxNormal") as CheckBox;
                        HiddenField HfDetailsACode = row.FindControl("HfDetailsACode") as HiddenField;
                        HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                        HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;

                        XmlElement HandleDetail2 = XDoc1.CreateElement("Detail");
                        HandleDetail2.SetAttribute("SUB_SRNO", SUBSRNO_DET.ToString().Trim());
                        HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                        HandleDetail2.SetAttribute("ACODE", (HfACODE.Value.Trim()));
                        //    HandleDetail2.SetAttribute("SRNO", (HfSrNo.Value.Trim()));                       

                        HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value.Trim()));
                        if(TxtQuantity.Text==string.Empty)
                        {
                            HandleDetail2.SetAttribute("QTY", ("0"));
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("QTY", (TxtQuantity.Text));
                        }
                        

                        if (ChkBoxMajor.Checked == true)
                        {
                            HandleDetail2.SetAttribute("CHK_MAJOR", "Y");
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("CHK_MAJOR", "N");
                        }

                        if (ChkBoxNormal.Checked == true)
                        {
                            HandleDetail2.SetAttribute("CHK_NORMAL", "Y");
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("CHK_NORMAL", "N");
                        }

                        if(TxtOrder.Text==string.Empty)
                        {
                            HandleDetail2.SetAttribute("ORD", ("0"));
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("ORD", (TxtOrder.Text));
                        }
                       
                        HandleDetail2.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));
                        HandleDetail2.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));
                        HandleDetail2.SetAttribute("INS_DATE", (""));
                        HandleDetail2.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));
                        HandleDetail2.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));
                        HandleDetail2.SetAttribute("UPD_DATE", (""));

                        root1.AppendChild(HandleDetail2);
                        SUBSRNO_DET++;

                    }
                }
                #endregion

                string str = PARTY_MODELMASLogicLayer.UpdatePARTY_MODELMASDetail(insert, validation.RSC(XDoc1.OuterXml));

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "PARTY MODEL MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillPartyModelMasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "PARTY MODEL MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : PARTY MODEL MASTER NOT SAVED";
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

                    #region INSERT PARTY MODEL MASTER

                    PARTY_MODELMASLogicLayer insert = new PARTY_MODELMASLogicLayer();
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                    insert.ACODE = HfACODE.Value.Trim();
                    insert.SRNO = HfSrNo.Value.Trim();
                    insert.MODEL_SRNO = TxtModelSrNo.Text.Trim();
                    insert.PARTY_SRNO = TxtPartySrNo.Text.Trim().ToUpper();
                    insert.BRAND_CODE = DdlBrandName.SelectedValue.Trim();
                    insert.MODEL_CODE = DdlModelName.SelectedValue.Trim();
                    insert.MODEL_REMARK = TxtModelRemark.Text.Trim().ToUpper();
                    insert.ACTIVE = DdlActive.SelectedValue.Trim();
                    insert.MFG_SRNO = TxtMfgSrNo.Text.Trim().ToUpper();
                    insert.SERVICE_TYPE = DdlServiceType.SelectedValue.Trim();
                    insert.BCODE = DdlServicePersonName.SelectedValue.Trim();
                    insert.REMARK = TxtOtherRemarks.Text.Trim().ToUpper();
                    insert.AMC_TRAN_DATE = TxtLastAMCDate.Text.Trim();
                    if (TxtLastAMCNo.Text == string.Empty)
                    {
                        insert.AMC_TRAN_NO = "0";
                    }
                    else
                    {
                        insert.AMC_TRAN_NO = TxtLastAMCNo.Text.Trim();
                    }
                    insert.AMC_SRNO = "0";
                    if(TxtInstallationDate.Text==string.Empty)
                    {
                        insert.INSTALL_DATE = "";
                    }
                    else
                    {
                        insert.INSTALL_DATE = Convert.ToDateTime(TxtInstallationDate.Text.Trim()).ToString("MM-dd-yyyy");
                    }
                    
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";

                    #endregion

                    #region INSERT PARTY MODEL DETAILS

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int SUBSRNO_DET = 1;

                    foreach (GridViewRow row in GvPartyModalDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {

                            TextBox TxtOrder = row.FindControl("TxtOrder") as TextBox;
                            DropDownList DdlProductName = row.FindControl("DdlProductName") as DropDownList;
                            TextBox TxtQuantity = row.FindControl("TxtQuantity") as TextBox;
                            CheckBox ChkBoxMajor = row.FindControl("ChkBoxMajor") as CheckBox;
                            CheckBox ChkBoxNormal = row.FindControl("ChkBoxNormal") as CheckBox;
                            HiddenField HfDetailsACode = row.FindControl("HfDetailsACode") as HiddenField;
                            HiddenField HfDetailSrNo = row.FindControl("HfDetailSrNo") as HiddenField;
                            HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;

                            XmlElement HandleDetail2 = XDoc1.CreateElement("Detail");
                            HandleDetail2.SetAttribute("SUB_SRNO", SUBSRNO_DET.ToString().Trim());
                            HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString().Trim());
                            HandleDetail2.SetAttribute("ACODE", (HfACODE.Value.Trim()));
                            //    HandleDetail2.SetAttribute("SRNO", (HfDetailSrNo.Value.Trim()));
                            //    HandleDetail2.SetAttribute("SUB_SRNO", HfSubSrNo.Value.Trim());

                            HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value.Trim()));
                            if(TxtQuantity.Text==string.Empty)
                            {
                                HandleDetail2.SetAttribute("QTY", ("0"));
                            }
                           else
                            {
                                HandleDetail2.SetAttribute("QTY", (TxtQuantity.Text));
                            }

                            if (ChkBoxMajor.Checked == true)
                            {
                                HandleDetail2.SetAttribute("CHK_MAJOR", "Y");
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("CHK_MAJOR", "N");
                            }

                            if (ChkBoxNormal.Checked == true)
                            {
                                HandleDetail2.SetAttribute("CHK_NORMAL", "Y");
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("CHK_NORMAL", "N");
                            }

                            if(TxtOrder.Text==string.Empty)
                            {
                                HandleDetail2.SetAttribute("ORD", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("ORD", (TxtOrder.Text));
                            }
                           
                            HandleDetail2.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));
                            HandleDetail2.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));
                            HandleDetail2.SetAttribute("INS_DATE", (""));
                            HandleDetail2.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));
                            HandleDetail2.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));
                            HandleDetail2.SetAttribute("UPD_DATE", (""));

                            root1.AppendChild(HandleDetail2);
                            SUBSRNO_DET++;

                        }
                    }
                    #endregion

                    string str = PARTY_MODELMASLogicLayer.InsertPARTY_MODELMASDetail(insert, validation.RSC(XDoc1.OuterXml));

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "PARTY MODEL MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillPartyModelMasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "PARTY MODEL MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : PARTY MODEL MASTER NOT SAVED";
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
                if (HfSrNo.Value != string.Empty)
                {
                    string str = PARTY_MODELMASLogicLayer.DeletePARTY_MODELMASDetailsByID(HfSrNo.Value);
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
                        lblmsg.Text = "Error:Party Model Master Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillPartyModelMasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvPartyModelMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) // Bind nested grid view with parent grid view
                {
                    string Id = ((HiddenField)e.Row.FindControl("HfSrNoGrid")).Value;
                    GridView PartyDet = (GridView)e.Row.FindControl("GvNestedPartyModalDetails");


                    DataTable Dt = new DataTable();

                    Dt = PARTY_MODELDETLogicLayer.GetAll_PARTY_MODELDETWiseSrNo(Id);
                    PartyDet.DataSource = Dt;
                    PartyDet.DataBind();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (TxtSearch.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtSearch);
                    Dv.RowFilter = "AccountName like '%" + TxtSearch.Text.Trim() + "%' OR BrandName like '%" + TxtSearch.Text.Trim() + "%' OR ModelName like '%" + TxtSearch.Text.Trim() + "%'";
                    GvPartyModelMaster.DataSource = Dv.ToTable();
                    GvPartyModelMaster.DataBind();

                }
                else
                {
                    GvPartyModelMaster.DataSource = DtSearch;
                    GvPartyModelMaster.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillOnGriStockdDetailChanged()
        {
            #region Assign to Stock Details Grid

            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
              
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values 

                        HiddenField HfDetailSCode = (HiddenField)GvPartyModalDetails.Rows[rowIndex].Cells[1].FindControl("HfDetailSCode");
                        TextBox TxtOrder = (TextBox)GvPartyModalDetails.Rows[rowIndex].Cells[1].FindControl("TxtOrder");
                        TextBox TxtProductCode = (TextBox)GvPartyModalDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvPartyModalDetails.Rows[rowIndex].Cells[3].FindControl("TxtProductName");
                        DropDownList DdlProductName = (DropDownList)GvPartyModalDetails.Rows[rowIndex].Cells[4].FindControl("DdlProductName");
                        TextBox TxtQuantity = (TextBox)GvPartyModalDetails.Rows[rowIndex].Cells[5].FindControl("TxtQuantity");
                        CheckBox ChkBoxMajor = (CheckBox)GvPartyModalDetails.Rows[rowIndex].Cells[6].FindControl("ChkBoxMajor");
                        CheckBox ChkBoxNormal = (CheckBox)GvPartyModalDetails.Rows[rowIndex].Cells[7].FindControl("ChkBoxNormal");



                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["CHK_MAJOR"] = ChkBoxMajor.Checked;
                        dtCurrentTable.Rows[i - 1]["CHK_NORMAL"] = ChkBoxNormal.Checked;
                        dtCurrentTable.Rows[i - 1]["ORD"] = TxtOrder.Text;

                        rowIndex++;

                    }
                }
            }

                        #endregion
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

                        FillOnGriStockdDetailChanged();
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


        protected void TxtProductCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");
                TextBox TxtProductName = (TextBox)row.Cells[1].FindControl("TxtProductName");

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

                        FillOnGriStockdDetailChanged();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnCopyModelItem_Click(object sender, EventArgs e)
        {
            try
            {
                string COMP_CODE = Session["COMP_CODE"].ToString();
                string MODEL_CODE = DdlModelName.SelectedValue;

                if (DdlModelName.SelectedIndex != 0)
                {
                    DataTable Dt = new DataTable();
                    Dt = STOCK_MODELDETLogicLayer.GetAllSTOCK_MODELDETDetailByCompanyAndModelName(COMP_CODE, MODEL_CODE);

                    DataTable table = new DataTable();
                    DataRow dr = null;
                    table.Columns.Add("COMP_CODE", typeof(string));
                    table.Columns.Add("ACODE", typeof(string));
                    table.Columns.Add("SRNO", typeof(string));
                    table.Columns.Add("SCODE", typeof(string));
                    table.Columns.Add("QTY", typeof(string));
                    table.Columns.Add("CHK_MAJOR", typeof(string));
                    table.Columns.Add("CHK_NORMAL", typeof(string));
                    table.Columns.Add("ORD", typeof(string));

                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {

                            dr = table.NewRow();


                            dr["SCODE"] = Dt.Rows[i]["SCODE"].ToString();
                            dr["QTY"] = Dt.Rows[i]["QTY"].ToString();
                            dr["CHK_MAJOR"] = Dt.Rows[i]["CHK_MAJOR"].ToString();
                            dr["CHK_NORMAL"] = Dt.Rows[i]["CHK_NORMAL"].ToString();
                            dr["ORD"] = Dt.Rows[i]["ORD"].ToString();

                            table.Rows.Add(dr);
                        }

                        ViewState["CurrentTable"] = table;

                        GvPartyModalDetails.DataSource = table;
                        GvPartyModalDetails.DataBind();

                        DivEntry.Visible = true;
                        DivView.Visible = false;

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