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
using MihirValid;

namespace VeeraApp
{
    public partial class StockBrandTypeMaster : System.Web.UI.Page
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
                SetInitialRow();
                FillStockBrandTypeMasterGrid(Session["COMP_CODE"].ToString());

                 string BRANDTYPE_CODE = Request.QueryString["BRANDTYPE_CODE"];
                 string COMP_CODE = Request.QueryString["COMP_CODE"];
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
                throw;
            }
        }


        public void FillStockBrandTypeMasterGrid(string CompCode)
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = STOCK_BRANDTYPEMASLogicLayer.GetAllSTOCK_BRANDTYEPMASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvStocktBrandTypeMaster.DataSource = Dv.ToTable();
                GvStocktBrandTypeMaster.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillStockBrandTypeDetailGrid()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = STOCK_BRANDTYPDETLogicLayer.GetAllSTOCK_BRANDTYPEDETAILSDetailByCompany((Session["COMP_CODE"].ToString()));
                GvStockBrandTypeDetail.DataSource = Dt;
                GvStockBrandTypeDetail.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ControllerEnable()
        {
            TxtBrandTypeName.Enabled = true;
            //     TxtWorkDescription.Enabled = true;

        }

        public void ControllerDisable()
        {
            TxtBrandTypeName.Enabled = false;
            //    TxtWorkDescription.Enabled = false;

        }
        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfCompCode.Value = string.Empty;
            HfBrandTypeCode.Value = string.Empty;
            HfSrNo.Value = string.Empty;
            TxtBrandTypeName.Text = string.Empty;
     ///    TxtWorkDescription.Text = string.Empty;
            
            ClearSetInitialRow();

            BtncallUpd.Text = "SAVE";

        }




        protected void GvStockBrandTypeDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvStockBrandTypeDetail.PageIndex = e.NewPageIndex;
                clear();
                FillStockBrandTypeDetailGrid();


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
                BtnJobComplainMas.Enabled = false;
                BtnBrandComplainMaster.Enabled = false;
                BtnViewReports.Enabled = false;
                DivEntry.Visible = true;
                DivView.Visible = false;
                GvStockBrandTypeDetail.Enabled = true;


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
                #region UPDATE STOCK BRAND TYPE MASTER 

                STOCK_BRANDTYPEMASLogicLayer insert = new STOCK_BRANDTYPEMASLogicLayer();
                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.BRANDTYPE_CODE = HfBrandTypeCode.Value.Trim();
                insert.BRANDTYPE_NAME = TxtBrandTypeName.Text.Trim().ToUpper();
                insert.BRANDTYPE_REMARK = "";
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";

                #endregion

                #region INSERT STOCK BRAND TYPE DETAIL

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);
                int SRNO_DET = 1;

                foreach (GridViewRow row in GvStockBrandTypeDetail.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfCompCodeVal = row.FindControl("HfCompCode") as HiddenField;
                        //  HiddenField HfBrandTypeCode = row.FindControl("HfBrandTypeCode") as HiddenField;
                        //  HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;

                        TextBox TxtWorkDescrition = row.FindControl("TxtWorkDescrition") as TextBox;
                        TextBox TxtRESULT_1_1 = row.FindControl("TxtRESULT_1_1") as TextBox;
                        TextBox TxtRESULT_1_2 = row.FindControl("TxtRESULT_1_2") as TextBox;
                        DropDownList DdlPrintFlag1 = row.FindControl("DdlPrintFlag1") as DropDownList;
                        TextBox TxtRESULT_2_1 = row.FindControl("TxtRESULT_2_1") as TextBox;
                        TextBox TxtRESULT_2_2 = row.FindControl("TxtRESULT_2_2") as TextBox;
                        DropDownList DdlPrintFlag2 = row.FindControl("DdlPrintFlag2") as DropDownList;
                        TextBox TxtRESULT_3_1 = row.FindControl("TxtRESULT_3_1") as TextBox;
                        TextBox TxtRESULT_3_2 = row.FindControl("TxtRESULT_3_2") as TextBox;
                        DropDownList DdlPrintFlag3 = row.FindControl("DdlPrintFlag3") as DropDownList;

                        XmlElement HandleDetail2 = XDoc1.CreateElement("Detail");
                        HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                        HandleDetail2.SetAttribute("SRNO", SRNO_DET.ToString());
                        //       HandleDetail2.SetAttribute("BRANDTYPE_CODE", (HfBrandTypeCode.Value));
                        //       HandleDetail2.SetAttribute("SRNO", (HfSrNo.Value));
                        HandleDetail2.SetAttribute("DESC_NAME", (TxtWorkDescrition.Text));
                        HandleDetail2.SetAttribute("RESULT_1_1", (TxtRESULT_1_1.Text));
                        HandleDetail2.SetAttribute("RESULT_1_2", (TxtRESULT_1_2.Text));
                        HandleDetail2.SetAttribute("PRINT_FLAG_1", (DdlPrintFlag1.SelectedValue));
                        HandleDetail2.SetAttribute("RESULT_2_1", (TxtRESULT_2_1.Text));
                        HandleDetail2.SetAttribute("RESULT_2_2", (TxtRESULT_2_2.Text));
                        HandleDetail2.SetAttribute("PRINT_FLAG_2", (DdlPrintFlag2.SelectedValue));
                        HandleDetail2.SetAttribute("RESULT_3_1", (TxtRESULT_3_1.Text));
                        HandleDetail2.SetAttribute("RESULT_3_2", (TxtRESULT_3_2.Text));
                        HandleDetail2.SetAttribute("PRINT_FLAG_3", (DdlPrintFlag3.SelectedValue));

                        HandleDetail2.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));
                        HandleDetail2.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));
                        HandleDetail2.SetAttribute("INS_DATE", (""));
                        HandleDetail2.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));
                        HandleDetail2.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));
                        HandleDetail2.SetAttribute("UPD_DATE", (""));

                        root1.AppendChild(HandleDetail2);
                        SRNO_DET++;

                    }
                }

                #endregion

                string str = STOCK_BRANDTYPEMASLogicLayer.UpdateSTOCK_BRANDTYPEMASDetail(insert, validation.RSC(XDoc1.OuterXml));

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "STOCK BRAND TYPE MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillStockBrandTypeMasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();

                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "STOCK BRAND TYPE MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : STOCK BRAND TYPE MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStocktBrandTypeMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvStocktBrandTypeMaster.PageIndex = e.NewPageIndex;
                FillStockBrandTypeMasterGrid(Session["COMP_CODE"].ToString());
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStocktBrandTypeMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataSet ds = STOCK_BRANDTYPEMASLogicLayer.GetAllIDWiseSTOCK_BRANDTYPEMASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable dtBal = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBrandTypeCode.Value = dt.Rows[0]["BRANDTYPE_CODE"].ToString();
                        // HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        TxtBrandTypeName.Text = dt.Rows[0]["BRANDTYPE_NAME"].ToString();


                        if (dtBal.Rows.Count > 0)
                        {

                            GvStockBrandTypeDetail.DataSource = dtBal;
                            GvStockBrandTypeDetail.DataBind();
                        }

                    }


                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    Btncalldel.Visible = true;
                    BtncallUpd.Visible = false;
                    BtnJobComplainMas.Enabled = true;
                    BtnBrandComplainMaster.Enabled = true;
                    BtnViewReports.Enabled = true;
                    ControllerDisable();
                    GvStockBrandTypeDetail.Enabled = false;

                    #endregion
                }

                if (e.CommandName == "Edita")
                {
                    #region EDIT
                    clear();
                    DataSet ds = STOCK_BRANDTYPEMASLogicLayer.GetAllIDWiseSTOCK_BRANDTYPEMASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable dtBal = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBrandTypeCode.Value = dt.Rows[0]["BRANDTYPE_CODE"].ToString();
                        // HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        TxtBrandTypeName.Text = dt.Rows[0]["BRANDTYPE_NAME"].ToString();

                        ViewState["CurrentTable"] = dtBal;
                        if (dtBal.Rows.Count > 0)
                        {
                            GvStockBrandTypeDetail.DataSource = dtBal;
                            GvStockBrandTypeDetail.DataBind();
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
                    BtnJobComplainMas.Enabled = true;
                    BtnBrandComplainMaster.Enabled = true;
                    BtnViewReports.Enabled = true;
                    UserRights();
                    GvStockBrandTypeDetail.Enabled = true;
                }

                if (e.CommandName == "Viewa")
                {
                    #region SET TEXT ON VIEW
                    clear();
                    DataSet ds = STOCK_BRANDTYPEMASLogicLayer.GetAllIDWiseSTOCK_BRANDTYPEMASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable dtBal = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBrandTypeCode.Value = dt.Rows[0]["BRANDTYPE_CODE"].ToString();
                        // HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        TxtBrandTypeName.Text = dt.Rows[0]["BRANDTYPE_NAME"].ToString();


                        if (dtBal.Rows.Count > 0)
                        {
                            GvStockBrandTypeDetail.DataSource = dtBal;
                            GvStockBrandTypeDetail.DataBind();
                        }
                    }

                    #endregion
                    ControllerDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    BtnJobComplainMas.Enabled = true;
                    BtnBrandComplainMaster.Enabled = true;
                    BtnViewReports.Enabled = true;
                    UserRights();
                    GvStockBrandTypeDetail.Enabled = false;
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
                    #region INSERT STOCK BRAND TYPE MASTER 

                    STOCK_BRANDTYPEMASLogicLayer insert = new STOCK_BRANDTYPEMASLogicLayer();
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.BRANDTYPE_CODE = HfBrandTypeCode.Value.Trim();
                    insert.BRANDTYPE_NAME = TxtBrandTypeName.Text.Trim().ToUpper();
                    insert.BRANDTYPE_REMARK = "";
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";

                    #endregion

                    #region INSERT STOCK BRAND TYPE DETAIL

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int SRNO_DET = 1;

                    foreach (GridViewRow row in GvStockBrandTypeDetail.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfCompCodeVal = row.FindControl("HfCompCode") as HiddenField;
                            //  HiddenField HfBrandTypeCode = row.FindControl("HfBrandTypeCode") as HiddenField;
                            //  HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;

                            TextBox TxtWorkDescrition = row.FindControl("TxtWorkDescrition") as TextBox;
                            TextBox TxtRESULT_1_1 = row.FindControl("TxtRESULT_1_1") as TextBox;
                            TextBox TxtRESULT_1_2 = row.FindControl("TxtRESULT_1_2") as TextBox;
                            DropDownList DdlPrintFlag1 = row.FindControl("DdlPrintFlag1") as DropDownList;
                            TextBox TxtRESULT_2_1 = row.FindControl("TxtRESULT_2_1") as TextBox;
                            TextBox TxtRESULT_2_2 = row.FindControl("TxtRESULT_2_2") as TextBox;
                            DropDownList DdlPrintFlag2 = row.FindControl("DdlPrintFlag2") as DropDownList;
                            TextBox TxtRESULT_3_1 = row.FindControl("TxtRESULT_3_1") as TextBox;
                            TextBox TxtRESULT_3_2 = row.FindControl("TxtRESULT_3_2") as TextBox;
                            DropDownList DdlPrintFlag3 = row.FindControl("DdlPrintFlag3") as DropDownList;

                            XmlElement HandleDetail2 = XDoc1.CreateElement("Detail");
                            HandleDetail2.SetAttribute("SRNO", SRNO_DET.ToString());
                            HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());

                            //       HandleDetail2.SetAttribute("BRANDTYPE_CODE", (HfBrandTypeCode.Value));
                            //       HandleDetail2.SetAttribute("SRNO", (HfSrNo.Value));
                            HandleDetail2.SetAttribute("DESC_NAME", (TxtWorkDescrition.Text));
                            HandleDetail2.SetAttribute("RESULT_1_1", (TxtRESULT_1_1.Text));
                            HandleDetail2.SetAttribute("RESULT_1_2", (TxtRESULT_1_2.Text));
                            HandleDetail2.SetAttribute("PRINT_FLAG_1", (DdlPrintFlag1.SelectedValue));
                            HandleDetail2.SetAttribute("RESULT_2_1", (TxtRESULT_2_1.Text));
                            HandleDetail2.SetAttribute("RESULT_2_2", (TxtRESULT_2_2.Text));
                            HandleDetail2.SetAttribute("PRINT_FLAG_2", (DdlPrintFlag2.SelectedValue));
                            HandleDetail2.SetAttribute("RESULT_3_1", (TxtRESULT_3_1.Text));
                            HandleDetail2.SetAttribute("RESULT_3_2", (TxtRESULT_3_2.Text));
                            HandleDetail2.SetAttribute("PRINT_FLAG_3", (DdlPrintFlag3.SelectedValue));

                            HandleDetail2.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));
                            HandleDetail2.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));
                            HandleDetail2.SetAttribute("INS_DATE", (""));
                            HandleDetail2.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));
                            HandleDetail2.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));
                            HandleDetail2.SetAttribute("UPD_DATE", (""));

                            root1.AppendChild(HandleDetail2);
                            SRNO_DET++;

                        }
                    }

                    #endregion

                    string str = STOCK_BRANDTYPEMASLogicLayer.InsertSTOCK_BRANDTYPEMASDetail(insert, validation.RSC(XDoc1.OuterXml));

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "STOCK BRAND TYPE MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillStockBrandTypeMasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();

                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "STOCK BRAND TYPE MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : STOCK BRAND TYPE MASTER NOT SAVED";
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
                if (HfBrandTypeCode.Value != string.Empty)
                {
                    string str = STOCK_BRANDTYPEMASLogicLayer.DeleteSTOCK_BRANDTYPEMASDetailsByID(HfBrandTypeCode.Value);
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
                        lblmsg.Text = "Error:Stock Brand Type Master Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillStockBrandTypeMasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();

                }
                #endregion
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
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("DESC_NAME", typeof(string));
            table.Columns.Add("RESULT_1_1", typeof(string));
            table.Columns.Add("RESULT_1_2", typeof(string));
            table.Columns.Add("RESULT_2_1", typeof(string));
            table.Columns.Add("RESULT_2_2", typeof(string));
            table.Columns.Add("RESULT_3_1", typeof(string));
            table.Columns.Add("RESULT_3_2", typeof(string));
            table.Columns.Add("PRINT_FLAG_1", typeof(string));
            table.Columns.Add("PRINT_FLAG_2", typeof(string));
            table.Columns.Add("PRINT_FLAG_3", typeof(string));
            dr = table.NewRow();

            dr["SRNO"] = 1;
            dr["DESC_NAME"] = string.Empty;
            dr["RESULT_1_1"] = string.Empty;
            dr["RESULT_1_2"] = string.Empty;
            dr["RESULT_2_1"] = string.Empty;
            dr["RESULT_2_2"] = string.Empty;
            dr["RESULT_3_1"] = string.Empty;
            dr["RESULT_3_2"] = string.Empty;
            dr["PRINT_FLAG_1"] = string.Empty;
            dr["PRINT_FLAG_2"] = string.Empty;
            dr["PRINT_FLAG_3"] = string.Empty;

            table.Rows.Add(dr);

            //ViewState["CurrentTable"] = table;

            GvStockBrandTypeDetail.DataSource = table;
            GvStockBrandTypeDetail.DataBind();
        }

        private void SetInitialRow() 
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("DESC_NAME", typeof(string));
            table.Columns.Add("RESULT_1_1", typeof(string));
            table.Columns.Add("RESULT_1_2", typeof(string));
            table.Columns.Add("RESULT_2_1", typeof(string));
            table.Columns.Add("RESULT_2_2", typeof(string));
            table.Columns.Add("RESULT_3_1", typeof(string));
            table.Columns.Add("RESULT_3_2", typeof(string));
            table.Columns.Add("PRINT_FLAG_1", typeof(string));
            table.Columns.Add("PRINT_FLAG_2", typeof(string));
            table.Columns.Add("PRINT_FLAG_3", typeof(string));
            dr = table.NewRow();
            dr["SRNO"] = 1;
            dr["DESC_NAME"] = string.Empty;
            dr["RESULT_1_1"] = string.Empty;
            dr["RESULT_1_2"] = string.Empty;
            dr["RESULT_2_1"] = string.Empty;
            dr["RESULT_2_2"] = string.Empty;
            dr["RESULT_3_1"] = string.Empty;
            dr["RESULT_3_2"] = string.Empty;
            dr["PRINT_FLAG_1"] = string.Empty;
            dr["PRINT_FLAG_2"] = string.Empty;
            dr["PRINT_FLAG_3"] = string.Empty;

            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvStockBrandTypeDetail.DataSource = table;
            GvStockBrandTypeDetail.DataBind();
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

                        TextBox TxtWorkDescrition = (TextBox)GvStockBrandTypeDetail.Rows[rowIndex].Cells[1].FindControl("TxtWorkDescrition");
                        TextBox TxtRESULT_1_1 = (TextBox)GvStockBrandTypeDetail.Rows[rowIndex].Cells[2].FindControl("TxtRESULT_1_1");
                        TextBox TxtRESULT_1_2 = (TextBox)GvStockBrandTypeDetail.Rows[rowIndex].Cells[3].FindControl("TxtRESULT_1_2");
                        DropDownList DdlPrintFlag1 = (DropDownList)GvStockBrandTypeDetail.Rows[rowIndex].Cells[4].FindControl("DdlPrintFlag1");
                        TextBox TxtRESULT_2_1 = (TextBox)GvStockBrandTypeDetail.Rows[rowIndex].Cells[5].FindControl("TxtRESULT_2_1");
                        TextBox TxtRESULT_2_2 = (TextBox)GvStockBrandTypeDetail.Rows[rowIndex].Cells[6].FindControl("TxtRESULT_2_2");
                        DropDownList DdlPrintFlag2 = (DropDownList)GvStockBrandTypeDetail.Rows[rowIndex].Cells[7].FindControl("DdlPrintFlag2");
                        TextBox TxtRESULT_3_1 = (TextBox)GvStockBrandTypeDetail.Rows[rowIndex].Cells[8].FindControl("TxtRESULT_3_1");
                        TextBox TxtRESULT_3_2 = (TextBox)GvStockBrandTypeDetail.Rows[rowIndex].Cells[9].FindControl("TxtRESULT_3_2");
                        DropDownList DdlPrintFlag3 = (DropDownList)GvStockBrandTypeDetail.Rows[rowIndex].Cells[10].FindControl("DdlPrintFlag3");


                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["SRNO"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["DESC_NAME"] = TxtWorkDescrition.Text;
                        dtCurrentTable.Rows[i - 1]["RESULT_1_1"] = TxtRESULT_1_1.Text;
                        dtCurrentTable.Rows[i - 1]["RESULT_1_2"] = TxtRESULT_1_2.Text;
                        dtCurrentTable.Rows[i - 1]["PRINT_FLAG_1"] = DdlPrintFlag1.Text;
                        dtCurrentTable.Rows[i - 1]["RESULT_2_1"] = TxtRESULT_2_1.Text;
                        dtCurrentTable.Rows[i - 1]["RESULT_2_2"] = TxtRESULT_2_2.Text;
                        dtCurrentTable.Rows[i - 1]["PRINT_FLAG_2"] = DdlPrintFlag2.Text;
                        dtCurrentTable.Rows[i - 1]["RESULT_3_1"] = TxtRESULT_3_1.Text;
                        dtCurrentTable.Rows[i - 1]["RESULT_3_2"] = TxtRESULT_3_2.Text;
                        dtCurrentTable.Rows[i - 1]["PRINT_FLAG_3"] = DdlPrintFlag3.Text;


                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvStockBrandTypeDetail.DataSource = dtCurrentTable;
                    GvStockBrandTypeDetail.DataBind();
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
                        TextBox TxtWorkDescrition = (TextBox)GvStockBrandTypeDetail.Rows[rowIndex].Cells[1].FindControl("TxtWorkDescrition");
                        TextBox TxtRESULT_1_1 = (TextBox)GvStockBrandTypeDetail.Rows[rowIndex].Cells[2].FindControl("TxtRESULT_1_1");
                        TextBox TxtRESULT_1_2 = (TextBox)GvStockBrandTypeDetail.Rows[rowIndex].Cells[3].FindControl("TxtRESULT_1_2");
                        DropDownList DdlPrintFlag1 = (DropDownList)GvStockBrandTypeDetail.Rows[rowIndex].Cells[4].FindControl("DdlPrintFlag1");
                        TextBox TxtRESULT_2_1 = (TextBox)GvStockBrandTypeDetail.Rows[rowIndex].Cells[5].FindControl("TxtRESULT_2_1");
                        TextBox TxtRESULT_2_2 = (TextBox)GvStockBrandTypeDetail.Rows[rowIndex].Cells[6].FindControl("TxtRESULT_2_2");
                        DropDownList DdlPrintFlag2 = (DropDownList)GvStockBrandTypeDetail.Rows[rowIndex].Cells[7].FindControl("DdlPrintFlag2");
                        TextBox TxtRESULT_3_1 = (TextBox)GvStockBrandTypeDetail.Rows[rowIndex].Cells[8].FindControl("TxtRESULT_3_1");
                        TextBox TxtRESULT_3_2 = (TextBox)GvStockBrandTypeDetail.Rows[rowIndex].Cells[9].FindControl("TxtRESULT_3_2");
                        DropDownList DdlPrintFlag3 = (DropDownList)GvStockBrandTypeDetail.Rows[rowIndex].Cells[10].FindControl("DdlPrintFlag3");

                        TxtWorkDescrition.Text = dt.Rows[i]["DESC_NAME"].ToString();
                        TxtRESULT_1_1.Text = dt.Rows[i]["RESULT_1_1"].ToString();
                        TxtRESULT_1_2.Text = dt.Rows[i]["RESULT_1_2"].ToString();
                        DdlPrintFlag1.Text = dt.Rows[i]["PRINT_FLAG_1"].ToString();
                        TxtRESULT_2_1.Text = dt.Rows[i]["RESULT_2_1"].ToString();
                        TxtRESULT_2_2.Text = dt.Rows[i]["RESULT_2_2"].ToString();
                        DdlPrintFlag2.Text = dt.Rows[i]["PRINT_FLAG_2"].ToString();
                        TxtRESULT_3_1.Text = dt.Rows[i]["RESULT_3_1"].ToString();
                        TxtRESULT_3_2.Text = dt.Rows[i]["RESULT_3_2"].ToString();
                        DdlPrintFlag3.Text = dt.Rows[i]["PRINT_FLAG_3"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        protected void LinkButtonDeleteRow_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex + 1;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
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
                GvStockBrandTypeDetail.DataSource = dt;
                GvStockBrandTypeDetail.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }

        protected void BtnJobComplainMas_Click(object sender, EventArgs e)
        {
            //  Response.Redirect("~/Admin/JobComplainMaster.aspx");

            Response.Write("<script>window.open ('JobComplainMaster.aspx?BRANDTYPE_CODE=" + HfBrandTypeCode.Value + "&COMP_CODE=" + HfCompCode.Value + "', '_blank');</script>");
        }

        protected void GvStockBrandTypeDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnBrandComplainMaster_Click(object sender, EventArgs e)
        {
            // Response.Redirect("~/Admin/BrandComplainMaster.aspx");
            Response.Write("<script>window.open ('BrandComplainMaster.aspx?BRANDTYPE_CODE=" + HfBrandTypeCode.Value + "&COMP_CODE=" + HfCompCode.Value + "', '_blank');</script>");
        }

        protected void GvStocktBrandTypeMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) // Bind nested grid view with parent grid view
                {
                    string Id = ((HiddenField)e.Row.FindControl("HfBrandTypeCode")).Value;
                    GridView childgrd = (GridView)e.Row.FindControl("GvNestedStockBrandTypeDetail");

                    DataTable Dt = new DataTable();

                    Dt = STOCK_BRANDTYPDETLogicLayer.GetAll_BRANDTYPE_CODEWise_BRANDTYPE_DETAILS(Id);
                    childgrd.DataSource = Dt;
                    childgrd.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void BtnViewReports_Click(object sender, EventArgs e)
        {

        }

      
    }
}