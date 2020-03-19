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
    public partial class ServiceTaxMaster : System.Web.UI.Page
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
                FillGrid();
                //   HfTranDate.Value = DateTime.Now.ToString();
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
            //  HfTranNo.Value = string.Empty;
            TxtFromDate.Enabled = true;
            TxtToDate.Enabled = true;
            TxtGST.Enabled = true;
            TxtSGST.Enabled = true;
            TxtCGST.Enabled = true;
            TxtIGST.Enabled = true;
            TxtTax1.Enabled = true;
            TxtTitle1.Enabled = true;
            TxtTax2.Enabled = true;
            TxtTitle2.Enabled = true;
            TxtTax3.Enabled = true;
            TxtTitle3.Enabled = true;
        }

        public void ControllerDisable()
        {
            //  HfTranNo.Value = string.Empty;
            TxtFromDate.Enabled = false;
            TxtToDate.Enabled = false;
            TxtGST.Enabled = false;
            TxtSGST.Enabled = false;
            TxtCGST.Enabled = false;
            TxtIGST.Enabled = false;
            TxtTax1.Enabled = false;
            TxtTitle1.Enabled = false;
            TxtTax2.Enabled = false;
            TxtTitle2.Enabled = false;
            TxtTax3.Enabled = false;
            TxtTitle3.Enabled = false;
        }
        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfTranNo.Value = string.Empty;
            TxtFromDate.Text = string.Empty;
            TxtToDate.Text = string.Empty;
            TxtGST.Text = string.Empty;
            TxtSGST.Text = string.Empty;
            TxtCGST.Text = string.Empty;
            TxtIGST.Text = string.Empty;
            TxtTax1.Text = string.Empty;
            TxtTitle1.Text = string.Empty;
            TxtTax2.Text = string.Empty;
            TxtTitle2.Text = string.Empty;
            TxtTax3.Text = string.Empty;
            TxtTitle3.Text = string.Empty;

            BtncallUpd.Text = "SAVE";
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            lblmsg.Text = string.Empty;
            UserRights();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region INSERT _ UPDATE VALUE
             //   string TranDate = HfTranDate.Value;
                EXCISE_RATEMASLogicLayer insert = new EXCISE_RATEMASLogicLayer();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value;
                insert.FRDT = Convert.ToDateTime(TxtFromDate.Text.Trim()).ToString("MM-dd-yyyy");//TxtFromDate.Text.Trim();
                insert.TODT = Convert.ToDateTime(TxtToDate.Text.Trim()).ToString("MM-dd-yyyy");//TxtToDate.Text.Trim();		            

                if (TxtTax1.Text == string.Empty)
                {
                    insert.EX_DUTY_PER = "0";
                }
                else
                {
                    insert.EX_DUTY_PER = TxtTax1.Text.Trim();
                }

                insert.EX_DUTY_TITLE = TxtTitle1.Text.Trim().ToUpper();

                if (TxtTax2.Text == string.Empty)
                {
                    insert.EX_CESS_PER = "0";
                }
                else
                {
                    insert.EX_CESS_PER = TxtTax2.Text.Trim();
                }

                insert.EX_CESS_TITLE = TxtTitle2.Text.Trim().ToUpper();


                if (TxtTax3.Text == string.Empty)
                {
                    insert.EX_SHCESS_PER = "0";
                }
                else
                {
                    insert.EX_SHCESS_PER = TxtTax3.Text.Trim();
                }

                insert.EX_SHCESS_TITLE = TxtTitle3.Text.Trim().ToUpper();

                if (TxtGST.Text == string.Empty)
                {
                    insert.GST_RATE = "0";
                }
                else
                {
                    insert.GST_RATE = TxtGST.Text.Trim();
                }

                if (TxtCGST.Text == string.Empty)
                {
                    insert.CGST_RATE = "0";
                }
                else
                {
                    insert.CGST_RATE = TxtCGST.Text.Trim();
                }

                if (TxtSGST.Text == string.Empty)
                {
                    insert.SGST_RATE = "0";
                }
                else
                {
                    insert.SGST_RATE = TxtSGST.Text.Trim();
                }

                if (TxtIGST.Text == string.Empty)
                {
                    insert.IGST_RATE = "0";
                }
                else
                {
                    insert.IGST_RATE = TxtIGST.Text.Trim();
                }
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
              //  insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
            //    insert.UPD_DATE = "";

                #endregion


                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = EXCISE_RATEMASLogicLayer.InsertEXCISE_RATEMASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "SERVICE TAX DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "SERVICE TAX MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : SERVICE TAX DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    string str = EXCISE_RATEMASLogicLayer.UpdateEXCISE_RATEMASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "SERVICE TAX DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "SERVICE TAX MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : SERVICE TAX DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void FillGrid()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = EXCISE_RATEMASLogicLayer.GetAllEXCISE_RATEMASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                GvServiceTaxMaster.DataSource = Dt;
                GvServiceTaxMaster.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void GvServiceTaxMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvServiceTaxMaster.PageIndex = e.NewPageIndex;
                FillGrid();
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvServiceTaxMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    int id = int.Parse(e.CommandArgument.ToString());
                    //GridViewRow row = grdValidations.Rows[];
                    GridViewRow row = GvServiceTaxMaster.Rows[id - 1];

                    //Fetch value of Name.                  

                    HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;
                    //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    //HiddenField HfTranDateGrid = (HiddenField)e.row.FindControl("HfTranDateGrid");

                    DataTable dt = EXCISE_RATEMASLogicLayer.GetAllIDWiseEXCISE_RATEMASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                        HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                        TxtFromDate.Text = Convert.ToDateTime(dt.Rows[0]["FRDT"].ToString()).ToString();//dt.Rows[0]["FRDT"].ToString();
                        TxtToDate.Text = Convert.ToDateTime(dt.Rows[0]["TODT"].ToString()).ToString();//dt.Rows[0]["TODT"].ToString();
                        TxtTax1.Text = dt.Rows[0]["EX_DUTY_PER"].ToString();
                        TxtTitle1.Text = dt.Rows[0]["EX_DUTY_TITLE"].ToString();
                        TxtTax2.Text = dt.Rows[0]["EX_CESS_PER"].ToString();
                        TxtTitle2.Text = dt.Rows[0]["EX_CESS_TITLE"].ToString();
                        TxtTax3.Text = dt.Rows[0]["EX_SHCESS_PER"].ToString();
                        TxtTitle3.Text = dt.Rows[0]["EX_SHCESS_TITLE"].ToString();
                        TxtGST.Text = dt.Rows[0]["GST_RATE"].ToString();
                        TxtCGST.Text = dt.Rows[0]["CGST_RATE"].ToString();
                        TxtSGST.Text = dt.Rows[0]["SGST_RATE"].ToString();
                        TxtIGST.Text = dt.Rows[0]["IGST_RATE"].ToString();

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

                    int id = int.Parse(e.CommandArgument.ToString());
                    //GridViewRow row = grdValidations.Rows[];
                    GridViewRow row = GvServiceTaxMaster.Rows[id - 1];

                    //Fetch value of Name.                  

                    HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;
                    //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    //HiddenField HfTranDateGrid = (HiddenField)e.row.FindControl("HfTranDateGrid");

                    DataTable dt = EXCISE_RATEMASLogicLayer.GetAllIDWiseEXCISE_RATEMASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                        HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                        TxtFromDate.Text = Convert.ToDateTime(dt.Rows[0]["FRDT"].ToString()).ToString("MM-dd-yyyy");//dt.Rows[0]["FRDT"].ToString();
                        TxtToDate.Text = Convert.ToDateTime(dt.Rows[0]["TODT"].ToString()).ToString("MM-dd-yyyy");//dt.Rows[0]["TODT"].ToString();
                        TxtTax1.Text = dt.Rows[0]["EX_DUTY_PER"].ToString();
                        TxtTitle1.Text = dt.Rows[0]["EX_DUTY_TITLE"].ToString();
                        TxtTax2.Text = dt.Rows[0]["EX_CESS_PER"].ToString();
                        TxtTitle2.Text = dt.Rows[0]["EX_CESS_TITLE"].ToString();
                        TxtTax3.Text = dt.Rows[0]["EX_SHCESS_PER"].ToString();
                        TxtTitle3.Text = dt.Rows[0]["EX_SHCESS_TITLE"].ToString();
                        TxtGST.Text = dt.Rows[0]["GST_RATE"].ToString();
                        TxtCGST.Text = dt.Rows[0]["CGST_RATE"].ToString();
                        TxtSGST.Text = dt.Rows[0]["SGST_RATE"].ToString();
                        TxtIGST.Text = dt.Rows[0]["IGST_RATE"].ToString();

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


                    int id = int.Parse(e.CommandArgument.ToString());
                    //GridViewRow row = grdValidations.Rows[];
                    GridViewRow row = GvServiceTaxMaster.Rows[id - 1];

                    //Fetch value of Name.                  

                    HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;
                    //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    //HiddenField HfTranDateGrid = (HiddenField)e.row.FindControl("HfTranDateGrid");
                   
                    DataTable dt = EXCISE_RATEMASLogicLayer.GetAllIDWiseEXCISE_RATEMASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                        HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                        TxtFromDate.Text = Convert.ToDateTime(dt.Rows[0]["FRDT"].ToString()).ToString();//dt.Rows[0]["FRDT"].ToString();
                        TxtToDate.Text = Convert.ToDateTime(dt.Rows[0]["TODT"].ToString()).ToString();//dt.Rows[0]["TODT"].ToString();
                        TxtTax1.Text = dt.Rows[0]["EX_DUTY_PER"].ToString();
                        TxtTitle1.Text = dt.Rows[0]["EX_DUTY_TITLE"].ToString();
                        TxtTax2.Text = dt.Rows[0]["EX_CESS_PER"].ToString();
                        TxtTitle2.Text = dt.Rows[0]["EX_CESS_TITLE"].ToString();
                        TxtTax3.Text = dt.Rows[0]["EX_SHCESS_PER"].ToString();
                        TxtTitle3.Text = dt.Rows[0]["EX_SHCESS_TITLE"].ToString();
                        TxtGST.Text = dt.Rows[0]["GST_RATE"].ToString();
                        TxtCGST.Text = dt.Rows[0]["CGST_RATE"].ToString();
                        TxtSGST.Text = dt.Rows[0]["SGST_RATE"].ToString();
                        TxtIGST.Text = dt.Rows[0]["IGST_RATE"].ToString();

                        #endregion
                    }
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
                    EXCISE_RATEMASLogicLayer insert = new EXCISE_RATEMASLogicLayer();

                    insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.FRDT = Convert.ToDateTime(TxtFromDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");//TxtFromDate.Text.Trim();
                    insert.TODT = Convert.ToDateTime(TxtToDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");//TxtToDate.Text.Trim();		   

                    if (TxtTax1.Text == string.Empty)
                    {
                        insert.EX_DUTY_PER = "0";
                    }
                    else
                    {
                        insert.EX_DUTY_PER = TxtTax1.Text.Trim();
                    }

                    insert.EX_DUTY_TITLE = TxtTitle1.Text.Trim().ToUpper();

                    if (TxtTax2.Text == string.Empty)
                    {
                        insert.EX_CESS_PER = "0";
                    }
                    else
                    {
                        insert.EX_CESS_PER = TxtTax2.Text.Trim();
                    }

                    insert.EX_CESS_TITLE = TxtTitle2.Text.Trim().ToUpper();


                    if (TxtTax3.Text == string.Empty)
                    {
                        insert.EX_SHCESS_PER = "0";
                    }
                    else
                    {
                        insert.EX_SHCESS_PER = TxtTax3.Text.Trim();
                    }

                    insert.EX_SHCESS_TITLE = TxtTitle3.Text.Trim().ToUpper();

                    if (TxtGST.Text == string.Empty)
                    {
                        insert.GST_RATE = "0";
                    }
                    else
                    {
                        insert.GST_RATE = TxtGST.Text.Trim();
                    }

                    if (TxtCGST.Text == string.Empty)
                    {
                        insert.CGST_RATE = "0";
                    }
                    else
                    {
                        insert.CGST_RATE = TxtCGST.Text.Trim();
                    }

                    if (TxtSGST.Text == string.Empty)
                    {
                        insert.SGST_RATE = "0";
                    }
                    else
                    {
                        insert.SGST_RATE = TxtSGST.Text.Trim();
                    }

                    if (TxtIGST.Text == string.Empty)
                    {
                        insert.IGST_RATE = "0";
                    }
                    else
                    {
                        insert.IGST_RATE = TxtIGST.Text.Trim();
                    }
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();

                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();


                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = EXCISE_RATEMASLogicLayer.InsertEXCISE_RATEMASDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "SERVICE TAX DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid();
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "SERVICE TAX MASTER ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : SERVICE TAX DETAIL NOT SAVED";
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
              //  string TranDate = HfTranDate.Value;
                if (HfTranNo.Value != string.Empty && HfTranDate.Value != string.Empty)
                {
                    string str = EXCISE_RATEMASLogicLayer.DeleteCHARGESDetailsByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value.ToString()));
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
                        lblmsg.Text = "Error:Service Tax Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillGrid();
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtGST_TextChanged(object sender, EventArgs e)
        {
            int tax;
            tax = Convert.ToInt32(TxtGST.Text);
            if (tax == 0)
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