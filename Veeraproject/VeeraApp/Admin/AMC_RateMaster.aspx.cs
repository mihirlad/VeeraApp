using MihirValid;
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


namespace VeeraApp.Admin
{
    public partial class AMC_RateMaster : System.Web.UI.Page
    {
        public static string compcode;
        public static string brandname;
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
                    FillAMCRateMasterGrid(Session["COMP_CODE"].ToString());


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

        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfCompCode.Value = string.Empty;
            HfBranchCode.Value = string.Empty;
            TxtFromDate.Text = string.Empty;
            TxtToDate.Text = string.Empty;
            TxtRemark.Text = string.Empty;
            DdlActive.SelectedIndex = 0;
            TxtCreatedBy.Text = string.Empty;
            TxtCreatedDate.Text = string.Empty;
            TxtUpdatedBy.Text = string.Empty;
            TxtUpdatedDate.Text = string.Empty;

            BtncallUpd.Text = "SAVE";
        }

        public void ControllerEnable()
        {
            TxtFromDate.Enabled = true;
            TxtToDate.Enabled = true;
            TxtRemark.Enabled = true;
            DdlActive.Enabled = true;
            TxtCreatedBy.Enabled = false;
            TxtCreatedDate.Enabled = false;
            TxtUpdatedBy.Enabled = false;
            TxtUpdatedDate.Enabled = false;
        }

        public void ControllerDisable()
        {
            TxtFromDate.Enabled = false;
            TxtToDate.Enabled = false;
            TxtRemark.Enabled = false;
            DdlActive.Enabled = false;
            TxtCreatedBy.Enabled = false;
            TxtCreatedDate.Enabled = false;
            TxtUpdatedBy.Enabled = false;
            TxtUpdatedDate.Enabled = false;
        }

        #region ADD NEW ROW INTO STOCK DETAIL GRID 

      
        private void SetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string)); 
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("SUB_SRNO", typeof(string));
            table.Columns.Add("BRAND_CODE", typeof(string));
            table.Columns.Add("MODEL_CODE", typeof(string));
            table.Columns.Add("AMC_RATE", typeof(string));
            table.Columns.Add("MAX_DIS_PER", typeof(string));
            table.Columns.Add("MAX_DIS_RATE", typeof(string));
            table.Columns.Add("MIN_DIS_PER", typeof(string));
            table.Columns.Add("MIN_DIS_RATE", typeof(string));
            table.Columns.Add("PER_SERVICE_RATE", typeof(string));
            table.Columns.Add("INS_USERID", typeof(string));
            table.Columns.Add("INS_DATE", typeof(string));
            table.Columns.Add("UPD_USERID", typeof(string));
            table.Columns.Add("UPD_DATE", typeof(string));
            table.Columns.Add("REMARK", typeof(string));
         

            dr = table.NewRow();

            dr["COMP_CODE"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["SUB_SRNO"] = string.Empty;
            dr["BRAND_CODE"] = string.Empty;
            dr["MODEL_CODE"] = string.Empty;
            dr["AMC_RATE"] = string.Empty;
            dr["MAX_DIS_RATE"] = string.Empty;
            dr["MAX_DIS_PER"] = string.Empty;
            dr["MIN_DIS_PER"] = string.Empty;
            dr["MIN_DIS_RATE"] = string.Empty;
            dr["PER_SERVICE_RATE"] = string.Empty;
            dr["INS_USERID"] = string.Empty;
            dr["INS_DATE"] = string.Empty;
            dr["UPD_USERID"] = string.Empty;
            dr["UPD_DATE"] = string.Empty;
            dr["REMARK"] = string.Empty;
          

            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvStockPriceDet.DataSource = table;
            GvStockPriceDet.DataBind();
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

                        HiddenField HfBrandCodeGrid = (HiddenField)GvStockPriceDet.Rows[rowIndex].Cells[0].FindControl("HfBrandCodeGrid");
                        HiddenField HfModelCodeGrid = (HiddenField)GvStockPriceDet.Rows[rowIndex].Cells[0].FindControl("HfModelCodeGrid");
                     
                        TextBox TxtBrandName = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[1].FindControl("TxtBrandName");
                        TextBox TxtModelName = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[2].FindControl("TxtModelName");
                        TextBox TxtModelDescription = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[3].FindControl("TxtModelDescription");
                        TextBox TxtAMCRate = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[4].FindControl("TxtAMCRate");
                        TextBox TxtMaxDiscount = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[5].FindControl("TxtMaxDiscount");
                        TextBox TxtMaxDiscountRate = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[6].FindControl("TxtMaxDiscountRate");
                        TextBox TxtMinDiscount = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[7].FindControl("TxtMinDiscount");
                        TextBox TxtMinDiscountRate = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[8].FindControl("TxtMinDiscountRate");
                        TextBox TxtPerServiceRate = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[9].FindControl("TxtPerServiceRate");


                        //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["BRAND_CODE"] = HfBrandCodeGrid.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["MODEL_CODE"] = HfModelCodeGrid.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["AMC_RATE"] = TxtAMCRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["MAX_DIS_PER"] = TxtMaxDiscount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["MAX_DIS_RATE"] = TxtMaxDiscountRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["MIN_DIS_PER"] = TxtMinDiscount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["MIN_DIS_RATE"] = TxtMinDiscountRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["PER_SERVICE_RATE"] = TxtPerServiceRate.Text.Trim();
                        
                       

                        rowIndex++;
                    
                    }


                    drCurrentRow = dtCurrentTable.NewRow();

                    //drCurrentRow["SR"] = "";
                    drCurrentRow["BRAND_CODE"] = "0";
                    drCurrentRow["MODEL_CODE"] = "0";
                    drCurrentRow["AMC_RATE"] = "0";
                    drCurrentRow["MAX_DIS_PER"] = "0";
                    drCurrentRow["MAX_DIS_RATE"] = "0";
                    drCurrentRow["MIN_DIS_PER"] = "0";
                    drCurrentRow["MIN_DIS_RATE"] = "0";
                    drCurrentRow["PER_SERVICE_RATE"] = "0";
                  


                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvStockPriceDet.DataSource = dtCurrentTable;
                    GvStockPriceDet.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousDataToStockGrid();
        }


        private void SetPreviousDataToStockGrid()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        HiddenField HfBrandCodeGrid = (HiddenField)GvStockPriceDet.Rows[rowIndex].Cells[0].FindControl("HfBrandCodeGrid");
                        HiddenField HfModelCodeGrid = (HiddenField)GvStockPriceDet.Rows[rowIndex].Cells[0].FindControl("HfModelCodeGrid");

                        TextBox TxtBrandName = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[1].FindControl("TxtBrandName");
                        TextBox TxtModelName = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[2].FindControl("TxtModelName");
                        TextBox TxtModelDescription = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[3].FindControl("TxtModelDescription");
                        TextBox TxtAMCRate = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[4].FindControl("TxtAMCRate");
                        TextBox TxtMaxDiscount = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[5].FindControl("TxtMaxDiscount");
                        TextBox TxtMaxDiscountRate = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[6].FindControl("TxtMaxDiscountRate");
                        TextBox TxtMinDiscount = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[7].FindControl("TxtMinDiscount");
                        TextBox TxtMinDiscountRate = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[8].FindControl("TxtMinDiscountRate");
                        TextBox TxtPerServiceRate = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[9].FindControl("TxtPerServiceRate");



                        HfBrandCodeGrid.Value = dt.Rows[i]["BRAND_CODE"].ToString();
                        HfModelCodeGrid.Value = dt.Rows[i]["MODEL_CODE"].ToString();
                        TxtAMCRate.Text = dt.Rows[i]["AMC_RATE"].ToString();
                        TxtMaxDiscount.Text = dt.Rows[i]["MAX_DIS_PER"].ToString();
                        TxtMaxDiscountRate.Text = dt.Rows[i]["MAX_DIS_RATE"].ToString();
                        TxtMinDiscount.Text = dt.Rows[i]["MIN_DIS_PER"].ToString();
                        TxtMinDiscountRate.Text = dt.Rows[i]["MIN_DIS_RATE"].ToString();
                        TxtPerServiceRate.Text = dt.Rows[i]["PER_SERVICE_RATE"].ToString();
                       
                        rowIndex++;                   

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
                GvStockPriceDet.DataSource = dt;
                GvStockPriceDet.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousDataToStockGrid();
        }


        protected void BtnAddRowModelStockDetailGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToStockGrid();
        }

        #endregion

        public void FillAMCRateMasterGrid(string CompCode)
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = AMC_RATEMASLogicLayer.GetAllAMC_RATE_MASDetail(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvAMCRateMaster.DataSource = Dv.ToTable(); ;
                GvAMCRateMaster.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillStockPriceDetailGrid()
        {
            try
            {

                DataTable Dt = new DataTable();
                if (TxtFromDate.Text.Trim() != string.Empty && TxtToDate.Text.Trim() != string.Empty)
                {
                    Dt = STOCK_MODELMASLogicLayer.GetAllBRANDS_MODELSDetailByCompanyForGrid((Session["COMP_CODE"].ToString()), Convert.ToDateTime(TxtFromDate.Text.Trim()), Convert.ToDateTime(TxtToDate.Text.Trim()));
                    GvStockPriceDet.DataSource = Dt;
                    GvStockPriceDet.DataBind();
                }
                else
                {

                    GvStockPriceDet.DataSource = null;
                    GvStockPriceDet.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStockPriceDet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    TextBox TxtBrandName = (e.Row.FindControl("TxtBrandName") as TextBox);
                    TextBox TxtModelName = (e.Row.FindControl("TxtModelName") as TextBox);
                  
                    HiddenField HfBrandCodeGrid = (e.Row.FindControl("HfBrandCodeGrid") as HiddenField);
                    HiddenField HfModelCodeGrid = (e.Row.FindControl("HfModelCodeGrid") as HiddenField);
                    TextBox TxtModelDescription = (TextBox)e.Row.FindControl("TxtModelDescription");


                    DataTable DtBrandName = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();

                    DtBrandName = STOCK_BRANDMASLogicLayer.GetSTOCKBRANDMAS_BrandNameCompanyWiseFor_Ddl(Comp_Code);

                    if (HfBrandCodeGrid.Value != "0" && HfBrandCodeGrid.Value != string.Empty)
                    {
                        DataView Dv = new DataView(DtBrandName);
                        Dv.RowFilter = "BRAND_CODE=" + HfBrandCodeGrid.Value;
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            TxtBrandName.Text = DtView.Rows[0]["BRAND_NAME"].ToString();

                            if (HfBrandCodeGrid.Value != string.Empty)
                            {

                                DataTable dtModelName = STOCK_MODELMASLogicLayer.GetSTOCK_MODELMAS_ModelNameBrandWiseFor_Ddl(HfBrandCodeGrid.Value);


                                if (HfModelCodeGrid.Value != "0" && HfModelCodeGrid.Value != string.Empty)
                                {
                                    DataView DvModel = new DataView(dtModelName);
                                    DvModel.RowFilter = "MODEL_CODE=" + HfModelCodeGrid.Value;
                                    DataTable DtViewModel = DvModel.ToTable();
                                    if (DtViewModel.Rows.Count > 0)
                                    {
                                        TxtModelName.Text = DtViewModel.Rows[0]["MODEL_NAME"].ToString();
                                    }
                                }


                                if (HfModelCodeGrid.Value != string.Empty)
                                {
                                    DataView DvModel = new DataView(dtModelName);
                                    DvModel.RowFilter = "MODEL_CODE=" + HfModelCodeGrid.Value;
                                    DataTable DtViewModel = DvModel.ToTable();
                                    TxtModelDescription.Text = DtViewModel.Rows[0]["MODEL_DESC"].ToString();
                                }
                            }

                        }
                        else
                        {
                            TxtBrandName.Text = string.Empty;

                        }
                    }

                }
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
                DivEntry.Visible = true;
                DivView.Visible = false;
                SetInitialRow();
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
                #region UPDATE AMC RATE MASTER DETAILS

                #region INSERT DATA INTO AMC_RATE MASTER 

                AMC_RATEMASLogicLayer insert = new AMC_RATEMASLogicLayer();

                insert.COMP_CODE = Session["COMP_CODE"].ToString();
                insert.SRNO = HfSrNo.Value.Trim();
                insert.FRDT = Convert.ToDateTime(TxtFromDate.Text.Trim()).ToString("MM-dd-yyyy");
                insert.TODT = Convert.ToDateTime(TxtToDate.Text.Trim()).ToString("MM-dd-yyyy");
                insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                //insert.INS_USERID = Session["USERNAME"].ToString();
                //insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_DATE = "";
                insert.ACTIVE = DdlActive.SelectedValue.Trim();

                #endregion

                #region INSERT DATA INTO AMC_RATE STOCK DETAILS 

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);
                int SUB_SRNO = 1;

                foreach (GridViewRow row in GvStockPriceDet.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfBrandCodeGrid = row.FindControl("HfBrandCodeGrid") as HiddenField;
                        HiddenField HfModelCodeGrid = row.FindControl("HfModelCodeGrid") as HiddenField;

                        TextBox TxtAMCRate = row.FindControl("TxtAMCRate") as TextBox;
                        TextBox TxtMaxDiscount = row.FindControl("TxtMaxDiscount") as TextBox;
                        TextBox TxtMaxDiscountRate = row.FindControl("TxtMaxDiscountRate") as TextBox;
                        TextBox TxtMinDiscount = row.FindControl("TxtMinDiscount") as TextBox;
                        TextBox TxtMinDiscountRate = row.FindControl("TxtMinDiscountRate") as TextBox;
                        TextBox TxtPerServiceRate = row.FindControl("TxtPerServiceRate") as TextBox;

                        if (HfBrandCodeGrid.Value != "0" && HfBrandCodeGrid.Value != null && HfBrandCodeGrid.Value != string.Empty)
                        {


                            XmlElement HandleDetail2 = XDoc1.CreateElement("AMC_RATEDetails");
                            HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());

                            // HandleDetail2.SetAttribute("SRNO", (HfSrNoVal.Value));
                            HandleDetail2.SetAttribute("SUB_SRNO", SUB_SRNO.ToString());

                            HandleDetail2.SetAttribute("BRAND_CODE", (HfBrandCodeGrid.Value.Trim()));
                            HandleDetail2.SetAttribute("MODEL_CODE", (HfModelCodeGrid.Value.Trim()));

                            if (TxtAMCRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("AMC_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("AMC_RATE", (TxtAMCRate.Text));
                            }

                            if (TxtMaxDiscount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("MAX_DIS_PER", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("MAX_DIS_PER", (TxtMaxDiscount.Text));
                            }

                            if (TxtMaxDiscountRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("MAX_DIS_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("MAX_DIS_RATE", (TxtMaxDiscountRate.Text));
                            }

                            if (TxtMinDiscount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("MIN_DIS_PER", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("MIN_DIS_PER", (TxtMinDiscount.Text));
                            }

                            if (TxtMinDiscountRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("MIN_DIS_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("MIN_DIS_RATE", (TxtMinDiscountRate.Text));
                            }

                            if (TxtPerServiceRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("PER_SERVICE_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("PER_SERVICE_RATE", (TxtPerServiceRate.Text));
                            }

                            HandleDetail2.SetAttribute("INS_USERID", Session["USERNAME"].ToString());
                            HandleDetail2.SetAttribute("INS_DATE", "");
                            HandleDetail2.SetAttribute("UPD_USERID", Session["USERNAME"].ToString());
                            HandleDetail2.SetAttribute("UPD_DATE","");
                            HandleDetail2.SetAttribute("REMARK", "");

                            root1.AppendChild(HandleDetail2);
                            SUB_SRNO++;
                        }
                    }
                }

                #endregion

                string str = AMC_RATEMASLogicLayer.UpdateAMC_RATE_MASDetail(insert, validation.RSC(XDoc1.OuterXml));

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "AMC RATE MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillAMCRateMasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();



                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "AMC RATE MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : AMC RATE MASTER NOT SAVED";
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

                    #region INSERT DATA INTO AMC_RATE MASTER 

                    AMC_RATEMASLogicLayer insert = new AMC_RATEMASLogicLayer();

                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    //insert.SRNO = HfSrNo.Value.Trim();
                    insert.FRDT = Convert.ToDateTime(TxtFromDate.Text.Trim()).ToString("MM-dd-yyyy");
                    insert.TODT= Convert.ToDateTime(TxtToDate.Text.Trim()).ToString("MM-dd-yyyy");
                    insert.REMARK= TxtRemark.Text.Trim().ToUpper();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_DATE = "";
                    insert.ACTIVE = DdlActive.SelectedValue.Trim();

                    #endregion

                    #region INSERT DATA INTO AMC_RATE STOCK DETAILS 

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int SUB_SRNO = 1;

                    foreach (GridViewRow row in GvStockPriceDet.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfBrandCodeGrid = row.FindControl("HfBrandCodeGrid") as HiddenField;
                            HiddenField HfModelCodeGrid = row.FindControl("HfModelCodeGrid") as HiddenField;

                            TextBox TxtAMCRate = row.FindControl("TxtAMCRate") as TextBox;
                            TextBox TxtMaxDiscount = row.FindControl("TxtMaxDiscount") as TextBox;
                            TextBox TxtMaxDiscountRate = row.FindControl("TxtMaxDiscountRate") as TextBox;
                            TextBox TxtMinDiscount = row.FindControl("TxtMinDiscount") as TextBox;
                            TextBox TxtMinDiscountRate = row.FindControl("TxtMinDiscountRate") as TextBox;
                            TextBox TxtPerServiceRate = row.FindControl("TxtPerServiceRate") as TextBox;

                            if (HfBrandCodeGrid.Value != "0" && HfBrandCodeGrid.Value != null && HfBrandCodeGrid.Value != string.Empty)
                            {


                                XmlElement HandleDetail2 = XDoc1.CreateElement("AMC_RATEDetails");
                                HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());

                                // HandleDetail2.SetAttribute("SRNO", (HfSrNoVal.Value));
                                HandleDetail2.SetAttribute("SUB_SRNO", SUB_SRNO.ToString());

                                HandleDetail2.SetAttribute("BRAND_CODE", (HfBrandCodeGrid.Value.Trim()));
                                HandleDetail2.SetAttribute("MODEL_CODE", (HfModelCodeGrid.Value.Trim()));

                                if (TxtAMCRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("AMC_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("AMC_RATE", (TxtAMCRate.Text));
                                }

                                if (TxtMaxDiscount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("MAX_DIS_PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("MAX_DIS_PER", (TxtMaxDiscount.Text));
                                }

                                if (TxtMaxDiscountRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("MAX_DIS_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("MAX_DIS_RATE", (TxtMaxDiscountRate.Text));
                                }

                                if (TxtMinDiscount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("MIN_DIS_PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("MIN_DIS_PER", (TxtMinDiscount.Text));
                                }

                                if (TxtMinDiscountRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("MIN_DIS_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("MIN_DIS_RATE", (TxtMinDiscountRate.Text));
                                }

                                if (TxtPerServiceRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("PER_SERVICE_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("PER_SERVICE_RATE", (TxtPerServiceRate.Text));
                                }

                                HandleDetail2.SetAttribute("INS_USERID", Session["USERNAME"].ToString());
                                HandleDetail2.SetAttribute("INS_DATE", "");
                                HandleDetail2.SetAttribute("UPD_USERID", Session["USERNAME"].ToString());
                                HandleDetail2.SetAttribute("UPD_DATE", "");
                                HandleDetail2.SetAttribute("REMARK", "");

                                root1.AppendChild(HandleDetail2);
                                SUB_SRNO++;
                            }
                        }
                    }

                    #endregion


                    string str = AMC_RATEMASLogicLayer.InsertAMC_RATE_MASDetail(insert, validation.RSC(XDoc1.OuterXml));

                    if (str.Length <= 8)
                    {
                        lblmsg.Text = "AMC RATE MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillAMCRateMasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "AMC RATE MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : AMC RATE MASTER NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
           
            }
            catch (Exception)
            {

                throw;
            }
        }

    
        protected void GvAMCRateMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                GvStockPriceDet.PageIndex = e.NewPageIndex;
                FillAMCRateMasterGrid(Session["COMP_CODE"].ToString());
                clear();
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

        protected void GvAMCRateMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataSet ds = AMC_RATEMASLogicLayer.GetAllIDWiseAMC_RATE_MASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable AMCDetail = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        TxtFromDate.Text = Convert.ToDateTime(dt.Rows[0]["FRDT"].ToString()).ToString("dd-MM-yyyy");
                        TxtToDate.Text = Convert.ToDateTime(dt.Rows[0]["TODT"].ToString()).ToString("dd-MM-yyyy");
                        TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                        DdlActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                        TxtCreatedBy.Text = dt.Rows[0]["INS_USERID"].ToString();
                        TxtCreatedDate.Text = Convert.ToDateTime(dt.Rows[0]["INS_DATE"].ToString()).ToString("dd-MM-yyyy");
                        TxtUpdatedBy.Text= dt.Rows[0]["UPD_USERID"].ToString();
                        TxtUpdatedDate.Text= Convert.ToDateTime(dt.Rows[0]["UPD_DATE"].ToString()).ToString("dd-MM-yyyy");

                        if (AMCDetail.Rows.Count > 0)
                        {
                            GvStockPriceDet.DataSource = AMCDetail;
                            GvStockPriceDet.DataBind();
                        }

                    }
                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    Btncalldel.Visible = true;
                    BtncallUpd.Visible = false;
                    ControllerDisable();
                    GvStockPriceDet.Enabled = false;
                    //GvStockPriceDet.Visible = true;
                 
                    #endregion
                }

                if (e.CommandName == "Edita")
                {
                    #region EDIT
                    clear();
                    DataSet ds = AMC_RATEMASLogicLayer.GetAllIDWiseAMC_RATE_MASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable AMCDetail = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        TxtFromDate.Text = Convert.ToDateTime(dt.Rows[0]["FRDT"].ToString()).ToString("dd-MM-yyyy");
                        TxtToDate.Text = Convert.ToDateTime(dt.Rows[0]["TODT"].ToString()).ToString("dd-MM-yyyy");
                        TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                        DdlActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                        TxtCreatedBy.Text = dt.Rows[0]["INS_USERID"].ToString();
                        TxtCreatedDate.Text = Convert.ToDateTime(dt.Rows[0]["INS_DATE"].ToString()).ToString("dd-MM-yyyy");
                        TxtUpdatedBy.Text = dt.Rows[0]["UPD_USERID"].ToString();
                        TxtUpdatedDate.Text = Convert.ToDateTime(dt.Rows[0]["UPD_DATE"].ToString()).ToString("dd-MM-yyyy");

                        if (AMCDetail.Rows.Count > 0)
                        {
                            ViewState["CurrentTable"] = AMCDetail;
                            GvStockPriceDet.DataSource = AMCDetail;
                            GvStockPriceDet.DataBind();
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
                    GvStockPriceDet.Enabled = true;
                    GvStockPriceDet.Visible = true;
                   
                }

                if (e.CommandName == "Viewa")
                {
                    #region SET TEXT ON VIEW
                    clear();
                    DataSet ds = AMC_RATEMASLogicLayer.GetAllIDWiseAMC_RATE_MASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable AMCDetail = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        TxtFromDate.Text = Convert.ToDateTime(dt.Rows[0]["FRDT"].ToString()).ToString("dd-MM-yyyy");
                        TxtToDate.Text = Convert.ToDateTime(dt.Rows[0]["TODT"].ToString()).ToString("dd-MM-yyyy");
                        TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                        DdlActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                        TxtCreatedBy.Text = dt.Rows[0]["INS_USERID"].ToString();
                        TxtCreatedDate.Text = Convert.ToDateTime(dt.Rows[0]["INS_DATE"].ToString()).ToString("dd-MM-yyyy");
                        TxtUpdatedBy.Text = dt.Rows[0]["UPD_USERID"].ToString();
                        TxtUpdatedDate.Text = Convert.ToDateTime(dt.Rows[0]["UPD_DATE"].ToString()).ToString("dd-MM-yyyy");

                        if (AMCDetail.Rows.Count > 0)
                        {
                            GvStockPriceDet.DataSource = AMCDetail;
                            GvStockPriceDet.DataBind();
                        }
                    }
                    #endregion
                    ControllerDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    UserRights();
                    GvStockPriceDet.Enabled = false;
                    GvStockPriceDet.Visible = true;
                   
                  }
                }
            catch (Exception ex)
            {

                lblmsg.Text = ex.Message.ToString();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE  
                if (HfSrNo.Value != string.Empty)
                {
                    string str = AMC_RATEMASLogicLayer.DeleteAMC_RATE_MASDetailsByID(HfSrNo.Value.Trim());
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
                        lblmsg.Text = "Error:AMC Rate Master Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillAMCRateMasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

    

        protected void TxtToDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
               

                if (BtncallUpd.Text == "SAVE")
                {
                  //  FillStockPriceDetailGrid();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtFromDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (BtncallUpd.Text == "SAVE")
                {
                  //  FillStockPriceDetailGrid();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region AMC_RATE Stock Details Grid 

        public void FillOnGridModelItemDetailChanged()
        {
            try
            {
                #region Assign to Stock Deatils Grid

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

                            HiddenField HfBrandCodeGrid = (HiddenField)GvStockPriceDet.Rows[rowIndex].Cells[0].FindControl("HfBrandCodeGrid");
                            HiddenField HfModelCodeGrid = (HiddenField)GvStockPriceDet.Rows[rowIndex].Cells[0].FindControl("HfModelCodeGrid");

                            TextBox TxtBrandName = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[1].FindControl("TxtBrandName");
                            TextBox TxtModelName = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[2].FindControl("TxtModelName");
                            TextBox TxtModelDescription = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[3].FindControl("TxtModelDescription");
                            TextBox TxtAMCRate = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[4].FindControl("TxtAMCRate");
                            TextBox TxtMaxDiscount = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[5].FindControl("TxtMaxDiscount");
                            TextBox TxtMaxDiscountRate = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[6].FindControl("TxtMaxDiscountRate");
                            TextBox TxtMinDiscount = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[7].FindControl("TxtMinDiscount");
                            TextBox TxtMinDiscountRate = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[8].FindControl("TxtMinDiscountRate");
                            TextBox TxtPerServiceRate = (TextBox)GvStockPriceDet.Rows[rowIndex].Cells[9].FindControl("TxtPerServiceRate");


                            //dtCurrentTable_C.Rows[i - 1]["SR"] = TxtSr.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["BRAND_CODE"] = HfBrandCodeGrid.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["MODEL_CODE"] = HfModelCodeGrid.Value.Trim();
                            dtCurrentTable.Rows[i - 1]["AMC_RATE"] = TxtAMCRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["MAX_DIS_PER"] = TxtMaxDiscount.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["MAX_DIS_RATE"] = TxtMaxDiscountRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["MIN_DIS_PER"] = TxtMinDiscount.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["MIN_DIS_RATE"] = TxtMinDiscountRate.Text.Trim();
                            dtCurrentTable.Rows[i - 1]["PER_SERVICE_RATE"] = TxtPerServiceRate.Text.Trim();



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

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetBrandName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from STOCK_BRANDMAS where COMP_CODE=@COMP_CODE and BRAND_NAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> BrandNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BrandNames.Add(dt.Rows[i][2].ToString());
            }
            return BrandNames;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetModelName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from STOCK_MODELMAS where BRAND_CODE=@BRAND_CODE and MODEL_NAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@BRAND_CODE", brandname);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> ModelNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ModelNames.Add(dt.Rows[i][3].ToString());
            }
            return ModelNames;
        }

        protected void TxtBrandName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfBrandCodeGrid = (HiddenField)row.Cells[0].FindControl("HfBrandCodeGrid");
                HiddenField HfModelCodeGrid = (HiddenField)row.Cells[0].FindControl("HfModelCodeGrid");
                TextBox TxtModelName = (TextBox)row.Cells[1].FindControl("TxtModelName");
            

                DataTable DtBrand = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtBrand = STOCK_BRANDMASLogicLayer.GetSTOCKBRANDMAS_BrandNameCompanyWiseFor_Ddl(Comp_Code);
                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrand);
                    Dv.RowFilter = "BRAND_NAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfBrandCodeGrid.Value = DtView.Rows[0]["BRAND_CODE"].ToString();
                        brandname = HfBrandCodeGrid.Value;

                       FillOnGridModelItemDetailChanged();

                    }
                }



            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtModelName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfBrandCodeGrid = (HiddenField)row.Cells[0].FindControl("HfBrandCodeGrid");
                HiddenField HfModelCodeGrid = (HiddenField)row.Cells[0].FindControl("HfModelCodeGrid");
                TextBox TxtModelName = (TextBox)row.Cells[1].FindControl("TxtModelName");
                TextBox TxtModelDescription = (TextBox)row.Cells[3].FindControl("TxtModelDescription");

                DataTable DtModel = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtModel = STOCK_MODELMASLogicLayer.GetSTOCK_MODELMAS_ModelNameBrandWiseFor_Ddl(HfBrandCodeGrid.Value);

                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtModel);
                    Dv.RowFilter = "MODEL_NAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfModelCodeGrid.Value = DtView.Rows[0]["MODEL_CODE"].ToString();
                        TxtModelDescription.Text = DtView.Rows[0]["MODEL_DESC"].ToString();

                       FillOnGridModelItemDetailChanged();
                    }

                }



            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtMaxDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;
                if (validation.ispercentage(txt.Text.Trim()))
                {
                    TextBox TxtAMCRate = (TextBox)row.Cells[3].FindControl("TxtAMCRate");
                    TextBox TxtMaxDiscount = (TextBox)row.Cells[4].FindControl("TxtMaxDiscount");
                    TextBox TxtMaxDiscountRate = (TextBox)row.Cells[5].FindControl("TxtMaxDiscountRate");
                    TextBox TxtMinDiscount = (TextBox)row.Cells[6].FindControl("TxtMinDiscount");
                    TextBox TxtMinDiscountRate = (TextBox)row.Cells[7].FindControl("TxtMinDiscountRate");
                    TextBox TxtPerServiceRate = (TextBox)row.Cells[8].FindControl("TxtPerServiceRate");

                    if (txt.Text.Trim() != string.Empty && TxtAMCRate.Text != string.Empty)
                    {

                        double disamt, amt, GrossAmt ;
                        
                        amt = (Convert.ToDouble(TxtAMCRate.Text));
                        TxtAMCRate.Text = Convert.ToString(amt);

                        disamt = ((amt * Convert.ToDouble(txt.Text)) / 100);
                        GrossAmt = Convert.ToDouble(TxtAMCRate.Text) - Convert.ToDouble(disamt);
                        TxtMaxDiscountRate.Text = GrossAmt.ToString();
                    }
                    FillOnGridModelItemDetailChanged();
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

        protected void TxtMinDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;
                if (validation.ispercentage(txt.Text.Trim()))
                {
                    TextBox TxtAMCRate = (TextBox)row.Cells[3].FindControl("TxtAMCRate");
                    TextBox TxtMaxDiscount = (TextBox)row.Cells[4].FindControl("TxtMaxDiscount");
                    TextBox TxtMaxDiscountRate = (TextBox)row.Cells[5].FindControl("TxtMaxDiscountRate");
                    TextBox TxtMinDiscount = (TextBox)row.Cells[6].FindControl("TxtMinDiscount");
                    TextBox TxtMinDiscountRate = (TextBox)row.Cells[7].FindControl("TxtMinDiscountRate");
                    TextBox TxtPerServiceRate = (TextBox)row.Cells[8].FindControl("TxtPerServiceRate");

                    if (txt.Text.Trim() != string.Empty && TxtAMCRate.Text != string.Empty)
                    {

                        double disamt, amt, GrossAmt;

                        amt = (Convert.ToDouble(TxtAMCRate.Text));
                        TxtAMCRate.Text = Convert.ToString(amt);

                        disamt = ((amt * Convert.ToDouble(txt.Text)) / 100);
                        GrossAmt = Convert.ToDouble(TxtAMCRate.Text) - Convert.ToDouble(disamt);
                        TxtMinDiscountRate.Text = GrossAmt.ToString();
                    }
                    FillOnGridModelItemDetailChanged();
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



        #endregion

    }
}