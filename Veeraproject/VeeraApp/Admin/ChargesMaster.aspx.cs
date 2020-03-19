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
    public partial class ChargesMaster : System.Web.UI.Page
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
                DivEntry.Visible = false;
                DivView.Visible = true;
                FillDdlAccountName();
                FillGrid(Session["COMP_CODE"].ToString());
            }
        }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }



        public void FillDdlAccountName()
        {
            try
            {
                DataTable Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(Session["COMP_CODE"].ToString());
                DdlAccountName.DataSource = Dt;
                DdlAccountName.DataValueField = "ACODE";
                DdlAccountName.DataTextField = "ANAME";
                DdlAccountName.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlChargesName()
        {
            try
            {
                //string ACODE = DdlAccountName.SelectedValue;
                //DataTable Dt = CHARGES_MASLogicLayer.GetAllCHARGESDetialsFor_DDL(ACODE);
                //DdlChanrgesName.DataSource = Dt;
                //DdlChanrgesName.DataValueField = "CCODE";
                //DdlChanrgesName.DataTextField = "NAME";
                //DdlChanrgesName.DataBind();

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
        public void ControllerEnable()
        {
            //  HfChargesCode.Value = string.Empty;
            TxtChargesName.Enabled = true;
            TxtHSNCode.Enabled = true;
            TxtRate.Enabled = true;
            DdlSign.Enabled = true;
            DdlAccountName.Enabled = true;
            TxtGST.Enabled = true;
            TxtCGST.Enabled = true;
            TxtSGST.Enabled = true;
            TxtIGST.Enabled = true;
        }

        public void ControllerDisable()
        {
            //  HfChargesCode.Value = string.Empty;
            TxtChargesName.Enabled = false;
            TxtHSNCode.Enabled = false;
            TxtRate.Enabled = false;
            DdlSign.Enabled = false;
            DdlAccountName.Enabled = false;
            TxtGST.Enabled = false;
            TxtCGST.Enabled = false;
            TxtSGST.Enabled = false;
            TxtIGST.Enabled = false;
        }
        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfCompCode.Value = string.Empty;
            HfChargesCode.Value = string.Empty;
            HfYearDate1.Value = string.Empty;
            TxtChargesName.Text = string.Empty;
            TxtHSNCode.Text = string.Empty;
            TxtRate.Text = string.Empty;
            DdlSign.SelectedIndex = 0;
            DdlAccountName.SelectedIndex = 0;
            TxtGST.Text = string.Empty;
            TxtCGST.Text = string.Empty;
            TxtSGST.Text = string.Empty;
            TxtIGST.Text = string.Empty;



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
                clear();
                ControllerEnable();
                UserRights();
                Btncalldel.Visible = false;
                BtncallUpd.Visible = true;
                btnSave.Enabled = true;
                btnSave.Visible = true;
                DivEntry.Visible = true;
                DivView.Visible = false;

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region INSERT _ UPDATE VALUE

                CHARGES_MASLogicLayer insert = new CHARGES_MASLogicLayer();
                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.CCODE = HfChargesCode.Value.Trim();
                insert.NAME = TxtChargesName.Text.Trim().ToUpper();
                
                if (TxtRate.Text == string.Empty)
                {
                    insert.PER = "0";
                }
                else
                {
                    insert.PER = TxtRate.Text.Trim();
                }
                insert.SIGN = DdlSign.SelectedValue.Trim().ToUpper();
                insert.ACODE = DdlAccountName.SelectedValue.Trim().ToUpper();

                if (TxtHSNCode.Text == string.Empty)
                {
                    insert.HSN_NO = "0";
                }
                else
                {
                    insert.HSN_NO = TxtHSNCode.Text.Trim();
                }
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";
                #endregion

                if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = CHARGES_MASLogicLayer.InsertCHARGESDetail(insert);
                    if (str.Length <= 8)
                    {     
                        lblmsg.Text = "CHARGES DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(Session["COMP_CODE"].ToString());
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "CHARGES CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : CHARGES DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }

                else
                {
                    string str = CHARGES_MASLogicLayer.UpdateCHARGESDetails(insert);
                    if (str.Contains("successfully"))
                    {

                        //INSERT CHARGE RATE
                        CHARGES_RATEMASLogicLayer InsertRate = new CHARGES_RATEMASLogicLayer();
                        InsertRate.CCODE = HfChargesCode.Value.Trim();
                        InsertRate.COMP_CODE = HfCompCode.Value.Trim();
                        InsertRate.YRDT1 = Convert.ToDateTime(HfYearDate1.Value.Trim()).ToString("yyyy-MM-dd");

                        if (TxtGST.Text == string.Empty)
                        {
                            InsertRate.GST_RATE = "0";
                        }
                        else
                        {
                            InsertRate.GST_RATE = TxtGST.Text.Trim();
                        }

                        if (TxtCGST.Text == string.Empty)
                        {
                            InsertRate.CGST_RATE = "0";
                        }
                        else
                        {
                            InsertRate.CGST_RATE = TxtCGST.Text.Trim();
                        }

                        if (TxtSGST.Text == string.Empty)
                        {
                            InsertRate.SGST_RATE = "0";
                        }
                        else
                        {
                            InsertRate.SGST_RATE = TxtSGST.Text.Trim();
                        }

                        if (TxtIGST.Text == string.Empty)
                        {
                            InsertRate.IGST_RATE = "0";
                        }
                        else
                        {
                            InsertRate.IGST_RATE = TxtIGST.Text.Trim();
                        }
                        InsertRate.INS_USERID = Session["USERNAME"].ToString();
                        InsertRate.INS_TERMINAL = Session["PC"].ToString();
                        InsertRate.INS_DATE = "";
                        InsertRate.UPD_USERID = Session["USERNAME"].ToString();
                        InsertRate.UPD_TERMINAL = Session["PC"].ToString();
                        InsertRate.UPD_DATE = "";

                        CHARGES_RATEMASLogicLayer.UpdateCHARGES_RATEMASDetails(InsertRate);

                        lblmsg.Text = "CHARGES DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(Session["COMP_CODE"].ToString());
                        UserRights();
                    }
                    else if (str.Contains("Already"))
                    {
                        lblmsg.Text = "CHARGES CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR :CHARGES DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillGrid(string CompCode)
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = CHARGES_MASLogicLayer.GetAllCHARGESDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvChargestMaster.DataSource = Dv.ToTable();
                GvChargestMaster.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void GvChargestMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvChargestMaster.PageIndex = e.NewPageIndex;
                FillGrid(Session["COMP_CODE"].ToString());
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvChargestMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {


                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataTable dt = CHARGES_MASLogicLayer.GetAllIDWiseCHARGESDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfChargesCode.Value = dt.Rows[0]["CCODE"].ToString();
                        TxtChargesName.Text = dt.Rows[0]["NAME"].ToString();
                        TxtRate.Text = dt.Rows[0]["PER"].ToString();
                        DdlSign.SelectedValue = dt.Rows[0]["SIGN"].ToString();
                        DdlAccountName.SelectedValue = dt.Rows[0]["ACODE"].ToString();
                        TxtHSNCode.Text = dt.Rows[0]["HSN_NO"].ToString();
                        TxtGST.Text = dt.Rows[0]["GST_RATE"].ToString();
                        TxtCGST.Text = dt.Rows[0]["CGST_RATE"].ToString();
                        TxtSGST.Text = dt.Rows[0]["SGST_RATE"].ToString();
                        TxtIGST.Text = dt.Rows[0]["IGST_RATE"].ToString();
                        HfYearDate1.Value = dt.Rows[0]["YRDT1"].ToString();

                    }

                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    Btncalldel.Visible = true;
                    BtncallUpd.Visible = false;
                    ControllerDisable();

                    #endregion
                }

                if (e.CommandName == "Edita")
                {
                    #region EDIT
                    clear();
                    DataTable dt = CHARGES_MASLogicLayer.GetAllIDWiseCHARGESDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfChargesCode.Value = dt.Rows[0]["CCODE"].ToString();
                        TxtChargesName.Text = dt.Rows[0]["NAME"].ToString();
                        TxtRate.Text = dt.Rows[0]["PER"].ToString();
                        DdlSign.SelectedValue = dt.Rows[0]["SIGN"].ToString();
                        DdlAccountName.SelectedValue = dt.Rows[0]["ACODE"].ToString();
                        TxtHSNCode.Text = dt.Rows[0]["HSN_NO"].ToString();
                        TxtGST.Text = dt.Rows[0]["GST_RATE"].ToString();
                        TxtCGST.Text = dt.Rows[0]["CGST_RATE"].ToString();
                        TxtSGST.Text = dt.Rows[0]["SGST_RATE"].ToString();
                        TxtIGST.Text = dt.Rows[0]["IGST_RATE"].ToString();
                        HfYearDate1.Value = dt.Rows[0]["YRDT1"].ToString();

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

                }

                if (e.CommandName == "Viewa")
                {
                    #region SET TEXT ON VIEW
                    clear();
                    DataTable dt = CHARGES_MASLogicLayer.GetAllIDWiseCHARGESDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfChargesCode.Value = dt.Rows[0]["CCODE"].ToString();
                        TxtChargesName.Text = dt.Rows[0]["NAME"].ToString();
                        TxtRate.Text = dt.Rows[0]["PER"].ToString();
                        DdlSign.SelectedValue = dt.Rows[0]["SIGN"].ToString();
                        DdlAccountName.SelectedValue = dt.Rows[0]["ACODE"].ToString();
                        TxtHSNCode.Text = dt.Rows[0]["HSN_NO"].ToString();
                        TxtGST.Text = dt.Rows[0]["GST_RATE"].ToString();
                        TxtCGST.Text = dt.Rows[0]["CGST_RATE"].ToString();
                        TxtSGST.Text = dt.Rows[0]["SGST_RATE"].ToString();
                        TxtIGST.Text = dt.Rows[0]["IGST_RATE"].ToString();
                        HfYearDate1.Value = dt.Rows[0]["YRDT1"].ToString();


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
                    CHARGES_MASLogicLayer insert = new CHARGES_MASLogicLayer();
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();                   
                    insert.NAME = TxtChargesName.Text.Trim().ToUpper();
                    if (TxtRate.Text == string.Empty)
                    {
                        insert.PER = "0";
                    }
                    else
                    {
                        insert.PER = TxtRate.Text.Trim();
                    }
                    insert.SIGN = DdlSign.SelectedValue.Trim().ToUpper();
                    insert.ACODE = DdlAccountName.SelectedValue.Trim().ToUpper();

                    if (TxtHSNCode.Text == string.Empty)
                    {
                        insert.HSN_NO = "0";
                    }
                    else
                    {
                        insert.HSN_NO = TxtHSNCode.Text.Trim();
                    }
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";

                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = CHARGES_MASLogicLayer.InsertCHARGESDetail(insert);
                        if (str.Length <= 8)
                        {
                            //INSERT CHARGE RATE
                            CHARGES_RATEMASLogicLayer InsertRate = new CHARGES_RATEMASLogicLayer();

                            InsertRate.CCODE = str;
                            InsertRate.COMP_CODE = Session["COMP_CODE"].ToString();
                            InsertRate.YRDT1 = Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd");


                            if (TxtGST.Text == string.Empty)
                            {
                                InsertRate.GST_RATE = "0";
                            }
                            else
                            {
                                InsertRate.GST_RATE = TxtGST.Text.Trim();
                            }

                            if (TxtCGST.Text == string.Empty)
                            {
                                InsertRate.CGST_RATE = "0";
                            }
                            else
                            {
                                InsertRate.CGST_RATE = TxtCGST.Text.Trim();
                            }

                            if (TxtSGST.Text == string.Empty)
                            {
                                InsertRate.SGST_RATE = "0";
                            }
                            else
                            {
                                InsertRate.SGST_RATE = TxtSGST.Text.Trim();
                            }

                            if (TxtIGST.Text == string.Empty)
                            {
                                InsertRate.IGST_RATE = "0";
                            }
                            else
                            {
                                InsertRate.IGST_RATE = TxtIGST.Text.Trim();
                            }
                            InsertRate.INS_USERID = Session["USERNAME"].ToString();
                            InsertRate.INS_TERMINAL = Session["PC"].ToString();
                            InsertRate.INS_DATE = "";
                            InsertRate.UPD_USERID = Session["USERNAME"].ToString();
                            InsertRate.UPD_TERMINAL = Session["PC"].ToString();
                            InsertRate.UPD_DATE = "";
                            CHARGES_RATEMASLogicLayer.InsertCHARGES_RATEMASDetail(InsertRate);

                            lblmsg.Text = "CHARGES DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid(Session["COMP_CODE"].ToString());
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "CHARGES CODE ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : CHARGES DETAIL NOT SAVED";
                            lblmsg.ForeColor = Color.Red;
                        }
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
                if (HfChargesCode.Value != string.Empty)
                {
                    string str = CHARGES_MASLogicLayer.DeleteCHARGESDetailsByID(HfChargesCode.Value);
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
                        lblmsg.Text = "Error:Charges Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillGrid(Session["COMP_CODE"].ToString());
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlAccountName_SelectedIndexChanged(object sender, EventArgs e)
        {
           // FillDdlChargesName();
        }

        protected void TxtGST_TextChanged(object sender, EventArgs e)
        {
            int tax;
            tax = Convert.ToInt32(TxtGST.Text);
            if( tax == 0)
            {
                TxtCGST.Text = "0";
                TxtSGST.Text = "0";
                TxtIGST.Text = "0";
            }
            else if (tax == 5)
            {
                TxtCGST.Text = "2.5";
                TxtSGST.Text = "2.5";
                TxtIGST.Text = "5";
            }
            else if (tax == 12)
            {
                TxtCGST.Text = "6";
                TxtSGST.Text = "6";
                TxtIGST.Text = "12";
            }
            else if (tax == 18)
            {
                TxtCGST.Text = "9";
                TxtSGST.Text = "9";
                TxtIGST.Text = "18";
            }
            else if (tax == 28)
            {
                TxtCGST.Text = "14";
                TxtSGST.Text = "14";
                TxtIGST.Text = "28";
            }
        }
    }
}