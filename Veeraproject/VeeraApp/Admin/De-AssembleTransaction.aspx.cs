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

namespace VeeraApp.Admin
{
    public partial class De_AssembleTransaction : System.Web.UI.Page
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
               Session["WORK_VIEWFLAG"] != null &&
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
                    SetInitialRow();
                    SetInitialRowBarcodeGrid();
                    HfTranType.Value = "D";
                    FillDdlPersonName();
                    CalendarExtenderAssembleDate.StartDate = Convert.ToDateTime(Session["FIN_YEAR"].ToString());
                    CalendarExtenderAssembleDate.EndDate = Convert.ToDateTime(Session["FIN_YEAR_END"].ToString());
                    FillDE_ASSEMBLE_TRANMasterGrid(Session["COMP_CODE"].ToString());
                }

            }
            else
            {
                Response.Redirect("../Login.aspx");
            }

            if (Session["WORK_VIEWFLAG"].ToString() == "B")
            {
                barcodegrid.Visible = true;

                
            }
            else if (Session["WORK_VIEWFLAG"].ToString() == "I")
            {
                barcodegrid.Visible = false;                
                pnlfullwidth.Style.Add("width", "100%");
            }
            else
            {

            }

            if (Session["USERTYPE"].ToString() == "A")
            {
                authorisedflag.Visible = true;
            }
            else if (Session["USERTYPE"].ToString() == "O")
            {
                authorisedflag.Visible = false;
            }
            else if (Session["USERTYPE"].ToString() == "S")
            {
                authorisedflag.Visible = false;
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
                        // btnSave.Enabled = true;
                    }
                    else
                    {
                        // btnSave.Enabled = false;
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


        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            TxtSrNo.Text = string.Empty;
            TxtAssemblyDate.Text = string.Empty;
            TxtProductCode.Text = string.Empty;
            TxtProductName.Text = string.Empty;
            TxtQty.Text = string.Empty;
            TxtRate.Text = string.Empty;
            TxtBarcode.Text = string.Empty;
            DdlPreparedBy.SelectedIndex = 0;
            TxtRemark.Text = string.Empty;
            TxtAuthorisedDate.Text = string.Empty;
            TxtAuthorisedBy.Text = string.Empty;
            DdlAuthoriseFlag.SelectedValue = "N";
            DdlConfirmFlag.SelectedValue = "N";
            TxtConfirmDate.Text = string.Empty;
            TxtConfirmedBy.Text = string.Empty;


            SetInitialRow();
            SetInitialRowBarcodeGrid();
            BtncallUpd.Text = "SAVE";
        }

        public void ControllerEnable()
        {

            TxtSrNo.Enabled = true;
            TxtAssemblyDate.Enabled = true;
            TxtProductCode.Enabled = false;
            TxtProductName.Enabled = false;
            TxtQty.Enabled = false;
            TxtRate.Enabled = false;
            TxtBarcode.Enabled = false;
            DdlPreparedBy.Enabled = true;
            TxtRemark.Enabled = true;
            TxtAuthorisedDate.Enabled = true;
            TxtAuthorisedBy.Enabled = true;
            DdlAuthoriseFlag.Enabled = true;
            DdlConfirmFlag.Enabled = true;
            TxtConfirmDate.Enabled = true;
            TxtConfirmedBy.Enabled = true;
        }

        public void ControllerDisable()
        {

            TxtSrNo.Enabled = false;
            TxtAssemblyDate.Enabled = false;
            TxtProductCode.Enabled = false;
            TxtProductName.Enabled = false;
            TxtQty.Enabled = false;
            TxtRate.Enabled = false;
            TxtBarcode.Enabled = false;
            DdlPreparedBy.Enabled = false;
            TxtRemark.Enabled = false;
            TxtAuthorisedDate.Enabled = false;
            TxtAuthorisedBy.Enabled = false;
            DdlAuthoriseFlag.Enabled = false;
            DdlConfirmFlag.Enabled = false;
            TxtConfirmDate.Enabled = false;
            TxtConfirmedBy.Enabled = false;
        }


        public void FillDdlPersonName()
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKER_MASDetialsCompanyWiseFor_DDL(Comp_Code);
                DdlPreparedBy.DataSource = Dt;
                DdlPreparedBy.DataValueField = "BCODE";
                DdlPreparedBy.DataTextField = "BNAME";
                DdlPreparedBy.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDE_ASSEMBLE_TRANMasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = ASS_TRANMASLogicLayer.GetAllDE_ASSEMBLE_TRAN_MASDetails(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()), HfTranType.Value.ToString());
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvDe_AssembleTransactionMaster.DataSource = Dv.ToTable();
            GvDe_AssembleTransactionMaster.DataBind();

            DtSearch = Dv.ToTable();

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
                TxtBarcode.Enabled = true;
                GvDeAssemblyPartDetails.Enabled = true;
                GvNewBarcodeGrid.Enabled = true;
                TxtAssemblyDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                string DE_ASSEMBLE_SRNO = ASS_TRANMASLogicLayer.GetSrNo_ForAssembleTransaction(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtAssemblyDate.Text.Trim()).ToString("yyyy-MM-dd"), HfTranType.Value);
                if (DE_ASSEMBLE_SRNO.Length <= 8)
                {
                    TxtSrNo.Text = DE_ASSEMBLE_SRNO;
                }
                else
                {
                    TxtSrNo.Text = string.Empty;
                }

                //ViewState["CurrentTable"] = null;
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


        protected void TxtAssemblyDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string DE_ASSEMBLE_SRNO = ASS_TRANMASLogicLayer.GetSrNo_ForAssembleTransaction(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtAssemblyDate.Text.Trim()).ToString("yyyy-MM-dd"), HfTranType.Value);
                if (DE_ASSEMBLE_SRNO.Length <= 8)
                {
                    TxtSrNo.Text = DE_ASSEMBLE_SRNO;
                }
                else
                {
                    TxtSrNo.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        #region Total Footer Amount

        private double TotalQuantity()
        {
            double GTotal = 0;
            for (int i = 0; i < GvDeAssemblyPartDetails.Rows.Count; i++)
            {
                string total = (GvDeAssemblyPartDetails.Rows[i].FindControl("TxtQty") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);

            }
            return GTotal;

        }

        private double TotalRatePer()
        {
            double GTotal = 0;
            for (int i = 0; i < GvDeAssemblyPartDetails.Rows.Count; i++)
            {
                string total = (GvDeAssemblyPartDetails.Rows[i].FindControl("TxtRatePer") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);

            }
            return GTotal;

        }


        private double TotalRate()
        {
            double GTotal = 0;
            for (int i = 0; i < GvDeAssemblyPartDetails.Rows.Count; i++)
            {
                string total = (GvDeAssemblyPartDetails.Rows[i].FindControl("TxtRate") as TextBox).Text;
                string Qty = (GvDeAssemblyPartDetails.Rows[i].FindControl("TxtQty") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total) * Convert.ToDouble(Qty);

            }
            return GTotal;

        }

        #endregion




        #region ADD NEW ROW IN DE-ASSEMBLE PARTS GRID

        private void SetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("RATE", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("STATUS", typeof(string));
            table.Columns.Add("PER", typeof(string));

            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["SCODE"] = "0";
            dr["QTY"] = "0";
            dr["RATE"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["STATUS"] = string.Empty;
            dr["PER"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvDeAssemblyPartDetails.DataSource = table;
            GvDeAssemblyPartDetails.DataBind();
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

                        Label lblSumTotalQuantity = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalQuantity"));
                        Label lblSumTotalRatePercentage = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalRatePercentage"));
                        Label lblSumTotalRate = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalRate"));
                        Button BtnAddRowModelDeAssemblePartsGrid = (Button)(GvDeAssemblyPartDetails.FooterRow.FindControl("BtnAddRowModelDeAssemblePartsGrid"));

                        HiddenField HfDetailSCode = (HiddenField)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        HiddenField HfStatus = (HiddenField)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[0].FindControl("HfStatus");
                        HiddenField HfAmount = (HiddenField)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        TextBox TxtProductCode = (TextBox)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[1].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductName");
                        TextBox TxtQty = (TextBox)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[3].FindControl("TxtQty");
                        TextBox TxtRatePer = (TextBox)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[4].FindControl("TxtRatePer");
                        TextBox TxtRate = (TextBox)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[5].FindControl("TxtRate");


                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = HfAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["STATUS"] = HfStatus.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["PER"] = TxtRatePer.Text.Trim();


                        rowIndex++;

                        double lblTotalQty = TotalQuantity();
                        lblSumTotalQuantity.Text = lblTotalQty.ToString();

                        double lblTotalRatePer = TotalRatePer();
                        lblSumTotalRatePercentage.Text = lblTotalRatePer.ToString();

                        double lblTotalRate = TotalRate();
                        lblSumTotalRate.Text = lblTotalRate.ToString();

                        if (Convert.ToDecimal(lblSumTotalRatePercentage.Text) < 100)
                        {
                            BtnAddRowModelDeAssemblePartsGrid.Enabled = true;
                        }
                        else
                        {
                            BtnAddRowModelDeAssemblePartsGrid.Enabled = false;
                        }


                    }

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["SCODE"] = "0";
                    drCurrentRow["QTY"] = "0";
                    drCurrentRow["RATE"] = "0";
                    drCurrentRow["AMT"] = "0";
                    drCurrentRow["STATUS"] = "";
                    drCurrentRow["PER"] = "0";

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvDeAssemblyPartDetails.DataSource = dtCurrentTable;
                    GvDeAssemblyPartDetails.DataBind();


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
                        Label lblSumTotalQuantity = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalQuantity"));
                        Label lblSumTotalRatePercentage = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalRatePercentage"));
                        Label lblSumTotalRate = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalRate"));

                        Button BtnAddRowModelDeAssemblePartsGrid = (Button)(GvDeAssemblyPartDetails.FooterRow.FindControl("BtnAddRowModelDeAssemblePartsGrid"));

                        HiddenField HfDetailSCode = (HiddenField)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        HiddenField HfStatus = (HiddenField)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[0].FindControl("HfStatus");
                        HiddenField HfAmount = (HiddenField)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        TextBox TxtProductCode = (TextBox)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[1].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductName");
                        TextBox TxtQty = (TextBox)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[3].FindControl("TxtQty");
                        TextBox TxtRatePer = (TextBox)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[4].FindControl("TxtRatePer");
                        TextBox TxtRate = (TextBox)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[5].FindControl("TxtRate");


                        HfStatus.Value = dt.Rows[i]["STATUS"].ToString();
                        HfDetailSCode.Value = dt.Rows[i]["SCODE"].ToString();
                        TxtQty.Text = dt.Rows[i]["QTY"].ToString();
                        TxtRate.Text = dt.Rows[i]["RATE"].ToString();
                        HfAmount.Value = dt.Rows[i]["AMT"].ToString();
                        TxtRatePer.Text = dt.Rows[i]["PER"].ToString();

                        rowIndex++;

                        double lblTotalQty = TotalQuantity();
                        lblSumTotalQuantity.Text = lblTotalQty.ToString();

                        double lblTotalRatePer = TotalRatePer();
                        lblSumTotalRatePercentage.Text = lblTotalRatePer.ToString();

                        double lblTotalRate = TotalRate();
                        lblSumTotalRate.Text = lblTotalRate.ToString();

                        if (Convert.ToDecimal(lblSumTotalRatePercentage.Text) < 100)
                        {
                            BtnAddRowModelDeAssemblePartsGrid.Enabled = true;
                        }
                        else
                        {
                            BtnAddRowModelDeAssemblePartsGrid.Enabled = false;
                        }

                    }
                }
            }
        }


        protected void BtnAddRowModelDeAssemblePartsGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        protected void BtnDeleteRowModelDeAssemblePartsGrid_Click(object sender, EventArgs e)
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
                GvDeAssemblyPartDetails.DataSource = dt;
                GvDeAssemblyPartDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }

        #endregion

        protected void GvDeAssemblyPartDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvDeAssemblyPartDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField HfDetailSCode = (e.Row.FindControl("HfDetailSCode") as HiddenField);
                    TextBox TxtProductName = (e.Row.FindControl("TxtProductName") as TextBox);
                    TextBox TxtProductCode = (e.Row.FindControl("TxtProductCode") as TextBox);
                    TextBox TxtRate = (e.Row.FindControl("TxtRate") as TextBox);
                    TextBox TxtRatePer = (e.Row.FindControl("TxtRatePer") as TextBox);
                    HiddenField HfAmount = (e.Row.FindControl("HfAmount") as HiddenField);



                    DataTable DtProduct = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();

                    DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);

                    if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != string.Empty)
                    {
                        DataView Dv = new DataView(DtProduct);
                        Dv.RowFilter = "SCODE=" + HfDetailSCode.Value;
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            TxtProductName.Text = DtView.Rows[0]["SNAME"].ToString();
                            TxtProductCode.Text = DtView.Rows[0]["PROD_CODE"].ToString();
                            HfDetailSCode.Value = DtView.Rows[0]["SCODE"].ToString();

                        }
                        else
                        {
                            TxtProductName.Text = string.Empty;
                            TxtProductCode.Text = string.Empty;
                        }
                    }


                }


                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblSumTotalQuantity = (Label)e.Row.FindControl("lblSumTotalQuantity");
                    Label lblSumTotalRatePercentage = (Label)e.Row.FindControl("lblSumTotalRatePercentage");
                    Label lblSumTotalRate = (Label)e.Row.FindControl("lblSumTotalRate");

                    Button BtnAddRowModelDeAssemblePartsGrid = (Button)e.Row.FindControl("BtnAddRowModelDeAssemblePartsGrid");

                    double lblTotalQty = TotalQuantity();
                    lblSumTotalQuantity.Text = lblTotalQty.ToString();

                    double lblTotalRatePer = TotalRatePer();
                    lblSumTotalRatePercentage.Text = lblTotalRatePer.ToString();

                    double lblTotalRate = TotalRate();
                    lblSumTotalRate.Text = lblTotalRate.ToString();

                    if (Convert.ToDecimal(lblSumTotalRatePercentage.Text) <= 100)
                    {
                        BtnAddRowModelDeAssemblePartsGrid.Enabled = true;
                    }
                    else
                    {
                        BtnAddRowModelDeAssemblePartsGrid.Enabled = false;
                    }

                }




            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void GvNewBarcodeGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        #region ADD NEW ROW IN BARCODE GRID

        private void SetInitialRowBarcodeGrid()
        {

            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("ASS_TRAN_DATE", typeof(string));
            table.Columns.Add("ASS_TRAN_NO", typeof(string));
            table.Columns.Add("ASS_SRNO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            //table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("RATE", typeof(string));
            //table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("BARCODE", typeof(string));
            table.Columns.Add("STATUS", typeof(string));


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["ASS_TRAN_DATE"] = string.Empty;
            dr["ASS_TRAN_NO"] = string.Empty;
            dr["ASS_SRNO"] = string.Empty;
            dr["SCODE"] = string.Empty;
            //dr["QTY"] = string.Empty;
            dr["RATE"] = string.Empty;
            //dr["AMT"] = string.Empty;
            dr["BARCODE"] = string.Empty;
            dr["STATUS"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["CurrentTable_Barcode"] = table;

            GvNewBarcodeGrid.DataSource = table;
            GvNewBarcodeGrid.DataBind();
        }



        #endregion

        protected void BtnPrintchallan_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../reportviewPages/DeAssemblyChallanPrint.aspx', '_blank');", true);
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
                    #region INSERT INTO ASSEMPBLE_TRAN MASTER

                    ASS_TRANMASLogicLayer insert = new ASS_TRANMASLogicLayer();
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                    //insert.TRAN_DATE = HfTranDate.Value.Trim();
                    //insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.TRAN_TYPE = HfTranType.Value.Trim().ToUpper();
                    insert.TRNDT = Convert.ToDateTime(TxtAssemblyDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    if (TxtSrNo.Text == string.Empty)
                    {
                        insert.SRNO = "0";
                    }
                    else
                    {
                        insert.SRNO = TxtSrNo.Text.Trim();
                    }
                    if (hfSCODE.Value != string.Empty)
                    {
                        insert.SCODE = hfSCODE.Value.Trim();
                    }

                    insert.BCODE = DdlPreparedBy.SelectedValue.Trim();

                    if (TxtQty.Text == string.Empty)
                    {
                        insert.QTY = "0";
                    }
                    else
                    {
                        insert.QTY = TxtQty.Text.Trim();
                    }

                    if (TxtRate.Text == string.Empty)
                    {
                        insert.RATE = "0";
                    }
                    else
                    {
                        insert.RATE = TxtRate.Text.Trim();
                    }

                    if (HfAmount.Value == string.Empty)
                    {
                        insert.AMT = "0";
                    }
                    else
                    {
                        insert.AMT = HfAmount.Value.Trim();
                    }
                  
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_DATE = "";
                    insert.AUTH_FLAG = DdlAuthoriseFlag.SelectedValue.Trim().ToUpper();
                    if (DdlAuthoriseFlag.SelectedValue == "Y")
                    {
                        insert.AUTH_DATE = Convert.ToDateTime(TxtAuthorisedDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.AUTH_DATE = "";
                    }
                    if (DdlAuthoriseFlag.SelectedValue == "Y")
                    {
                        insert.AUTH_USERID = Session["USERNAME"].ToString();
                    }
                    else
                    {
                        insert.AUTH_USERID = "";
                    }

                    insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                    insert.ENDT = "";
                    insert.STATUS = "O";
                    insert.PART_AMT = "0";
                    insert.LAB_AMT = "0";
                    insert.BAR_TRAN_DATE = Convert.ToDateTime(HfBar_Tran_Date.Value.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    insert.BAR_TRAN_NO = HfBar_Tran_No.Value.Trim();
                    insert.BAR_SRNO = HfBar_SrNo.Value.Trim();
                    insert.CONF_FLAG = DdlConfirmFlag.SelectedValue.Trim().ToUpper();
                    if (DdlConfirmFlag.SelectedValue == "Y")
                    {
                        insert.CONF_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CONF_DATE = "";
                    }
                    if (DdlConfirmFlag.SelectedValue == "Y")
                    {
                        insert.CONF_USERID = Session["USERNAME"].ToString();
                    }
                    else
                    {
                        insert.CONF_USERID = "";
                    }


                    #endregion


                    #region INSERT INTO ASSEMBLE_TRAN DETAILS

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int SRNODETAIL = 1;
                    foreach (GridViewRow row in GvDeAssemblyPartDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                            HiddenField HfTransNo = row.FindControl("HfTransNo") as HiddenField;
                            HiddenField HfStatus = row.FindControl("HfStatus") as HiddenField;
                            HiddenField HfAmount = row.FindControl("HfAmount") as HiddenField;
                            HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                            HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;

                            TextBox TxtProductCode = row.FindControl("TxtProductCode") as TextBox;
                            TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtRatePer = row.FindControl("TxtRatePer") as TextBox;

                            if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != null)
                            {

                                XmlElement HandleDetail2 = XDoc1.CreateElement("ASS_TRANDetails");

                                HandleDetail2.SetAttribute("SRNO", SRNODETAIL.ToString());
                                HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                if (HfDetailSCode.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SCODE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value));
                                }

                                if (TxtQty.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("QTY", (TxtQty.Text));
                                }

                                if (TxtRatePer.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("PER", (TxtRatePer.Text));
                                }

                                if (TxtRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("RATE", (TxtRate.Text));
                                }

                                if (HfAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("AMT", (HfAmount.Value));
                                }

                                HandleDetail2.SetAttribute("STATUS", ("O"));

                                root1.AppendChild(HandleDetail2);
                                SRNODETAIL++;
                            }

                        }
                    }

                    #endregion

                    Label lblSumTotalRatePercentage = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalRatePercentage"));

                    if (Convert.ToDecimal(lblSumTotalRatePercentage.Text) == 100)
                    {
                        DataSet str = ASS_TRANMASLogicLayer.InsertDE_ASSEMBLE_TRAN_MASDetail(insert, validation.RSC(XDoc1.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"), HfTranType.Value);


                        string P_Type = "I";
                        if (str != null)
                        {
                            if (str.Tables.Count > 0)
                            {
                                DataTable DtDetail = str.Tables[0];
                                if (Session["WORK_VIEWFLAG"].ToString() == "B")
                                {
                                    for (int d = 0; d < DtDetail.Rows.Count; d++)
                                    {

                                        string BarCodeStr = DC_MASLogicLayer.GenerateBracodeForPurchaseOrder(P_Type.ToString(), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), TxtSrNo.Text, DtDetail.Rows[d]["SCODE"].ToString(), DtDetail.Rows[d]["QTY"].ToString(), DtDetail.Rows[d]["RATE"].ToString(), HfTranType.Value.ToString(), Convert.ToDateTime(DtDetail.Rows[d]["TRAN_DATE"].ToString()), DtDetail.Rows[d]["TRAN_NO"].ToString(), DtDetail.Rows[d]["SRNO"].ToString());
                                    }
                                }

                            }

                            lblmsg.Text = "DELIVERY CHALLAN SAVE SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillDE_ASSEMBLE_TRANMasterGrid(Session["COMP_CODE"].ToString());
                            UserRights();


                        }
                        else if (str == null)
                        {
                            lblmsg.Text = "DELIVERY CHALLAN ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : DELIVERY CHALLAN MASTER NOT SAVED";
                            lblmsg.ForeColor = Color.Red;

                        }
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : PERCENTAGE SHOULD BE 100%";
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


        protected void GvDe_AssembleTransactionMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }


        public void FillBarcodeNoOnUpdate()
        {
            try
            {

                DataTable Dt = new DataTable();
                Dt = BARCODE_MASLogicLayer.GetBarcodeDetailsFor_DeAseembleBarcodeGrid(HfCompCode.Value.ToString(), HfBranchCode.Value.ToString(), HfBar_Tran_No.Value.ToString(), Convert.ToDateTime(HfBar_Tran_Date.Value.ToString()), HfBar_SrNo.Value.ToString());



                TxtBarcode.Text = Dt.Rows[0]["BARCODE"].ToString();


            }

            catch (Exception)
            {

                throw;
            }
        }



        public void FillProductNameOnUpdate(string Id)
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);


                if (hfSCODE.Value.ToString() != "0")
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "SCODE=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtProductName.Text = DtView.Rows[0]["SNAME"].ToString();
                    TxtProductCode.Text = DtView.Rows[0]["PROD_CODE"].ToString();
                    hfSCODE.Value = DtView.Rows[0]["SCODE"].ToString();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvDe_AssembleTransactionMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = ASS_TRANMASLogicLayer.GetAllIDWiseDE_ASSEMBLE_TRAN_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtPartDetails = ds.Tables[1];
                        DataTable DtBarcode = ds.Tables[2];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            HfBar_Tran_Date.Value = dt.Rows[0]["BAR_TRAN_DATE"].ToString();
                            HfBar_Tran_No.Value = dt.Rows[0]["BAR_TRAN_NO"].ToString();
                            HfBar_SrNo.Value = dt.Rows[0]["BAR_SRNO"].ToString();
                            HfAmount.Value= dt.Rows[0]["AMT"].ToString();
                            TxtSrNo.Text = dt.Rows[0]["SRNO"].ToString();
                            TxtAssemblyDate.Text = Convert.ToDateTime(dt.Rows[0]["TRNDT"].ToString()).ToString("dd-MM-yyyy");
                            FillProductNameOnUpdate(dt.Rows[0]["SCODE"].ToString());
                            FillBarcodeNoOnUpdate();
                            TxtQty.Text = dt.Rows[0]["QTY"].ToString();
                            TxtRate.Text = dt.Rows[0]["RATE"].ToString();
                            DdlPreparedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtAuthorisedDate.Text = dt.Rows[0]["AUTH_DATE"].ToString();
                            TxtAuthorisedBy.Text = dt.Rows[0]["AUTH_USERID"].ToString();
                            DdlAuthoriseFlag.SelectedValue = dt.Rows[0]["AUTH_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString(); //Convert.ToDateTime(dt.Rows[0]["CONF_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtConfirmedBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();


                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value.ToString();
                            Session["TRAN_TYPE"] = HfTranType.Value.ToString();

                            if (DtPartDetails.Rows.Count > 0)
                            {
                                GvDeAssemblyPartDetails.DataSource = DtPartDetails;
                                GvDeAssemblyPartDetails.DataBind();
                                GvDeAssemblyPartDetails.Enabled = false;
                            }

                            if (DtBarcode.Rows.Count > 0)
                            {

                                GvNewBarcodeGrid.DataSource = DtBarcode;
                                GvNewBarcodeGrid.DataBind();
                                GvNewBarcodeGrid.Enabled = false;
                            }


                            btnSave.Visible = false;
                            btnDelete.Visible = true;
                            Btncalldel.Visible = true;
                            BtncallUpd.Visible = false;
                            ControllerDisable();

                            #endregion
                        }
                    }
                }


                if (e.CommandName == "Edita")
                {
                    ViewState["CurrentTable"] = null;

                    #region Edita
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        Button BtnAddRowModelDeAssemblePartsGrid = (Button)(GvDeAssemblyPartDetails.FooterRow.FindControl("BtnAddRowModelDeAssemblePartsGrid"));

                        Label lblSumTotalRatePercentage = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalRatePercentage"));

                        DataSet ds = ASS_TRANMASLogicLayer.GetAllIDWiseDE_ASSEMBLE_TRAN_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtPartDetails = ds.Tables[1];
                        DataTable DtBarcode = ds.Tables[2];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                           
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            HfBar_Tran_Date.Value = dt.Rows[0]["BAR_TRAN_DATE"].ToString();
                            HfBar_Tran_No.Value = dt.Rows[0]["BAR_TRAN_NO"].ToString();
                            HfBar_SrNo.Value = dt.Rows[0]["BAR_SRNO"].ToString();
                            HfAmount.Value = dt.Rows[0]["AMT"].ToString();
                            TxtSrNo.Text = dt.Rows[0]["SRNO"].ToString();
                            TxtAssemblyDate.Text = Convert.ToDateTime(dt.Rows[0]["TRNDT"].ToString()).ToString("dd-MM-yyyy");
                            FillProductNameOnUpdate(dt.Rows[0]["SCODE"].ToString());
                            FillBarcodeNoOnUpdate();
                            TxtQty.Text = dt.Rows[0]["QTY"].ToString();
                            TxtRate.Text = dt.Rows[0]["RATE"].ToString();
                            DdlPreparedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtAuthorisedDate.Text = dt.Rows[0]["AUTH_DATE"].ToString();
                            TxtAuthorisedBy.Text = dt.Rows[0]["AUTH_USERID"].ToString();
                            DdlAuthoriseFlag.SelectedValue = dt.Rows[0]["AUTH_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString(); //Convert.ToDateTime(dt.Rows[0]["CONF_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtConfirmedBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();


                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value.ToString();
                            Session["TRAN_TYPE"] = HfTranType.Value.ToString();
                           



                            if (DtPartDetails.Rows.Count > 0)
                            {
                                #region Assign Table

                                DataTable table = new DataTable();
                                DataRow drm = null;
                                if (ViewState["CurrentTable"] != null)
                                {
                                    table = (DataTable)ViewState["CurrentTable"];
                                }
                                else
                                {
                                    if (table.Rows.Count <= 0)
                                    {
                                        table.Columns.Add("COMP_CODE", typeof(string));
                                        table.Columns.Add("TRAN_DATE", typeof(string));
                                        table.Columns.Add("TRAN_NO", typeof(string));
                                        table.Columns.Add("SRNO", typeof(string));
                                        table.Columns.Add("SCODE", typeof(string));
                                        table.Columns.Add("QTY", typeof(string));
                                        table.Columns.Add("RATE", typeof(string));
                                        table.Columns.Add("AMT", typeof(string));
                                        table.Columns.Add("STATUS", typeof(string));
                                        table.Columns.Add("PER", typeof(string));

                                    }
                                }
                                for (int m = 0; m < DtPartDetails.Rows.Count; m++)
                                {
                                    drm = table.NewRow();
                                    drm["COMP_CODE"] = DtPartDetails.Rows[m]["COMP_CODE"].ToString();
                                    drm["TRAN_DATE"] = DtPartDetails.Rows[m]["TRAN_DATE"].ToString();
                                    drm["TRAN_NO"] = DtPartDetails.Rows[m]["TRAN_NO"].ToString();
                                    drm["SRNO"] = DtPartDetails.Rows[m]["SRNO"].ToString();
                                    drm["SCODE"] = DtPartDetails.Rows[m]["SCODE"].ToString();
                                    drm["QTY"] = DtPartDetails.Rows[m]["QTY"].ToString();
                                    drm["RATE"] = DtPartDetails.Rows[m]["RATE"].ToString();
                                    drm["AMT"] = DtPartDetails.Rows[m]["AMT"].ToString();
                                    drm["STATUS"] = DtPartDetails.Rows[m]["STATUS"].ToString();
                                    drm["PER"] = DtPartDetails.Rows[m]["PER"].ToString();
                                    table.Rows.Add(drm);
                                }


                                #endregion

                                ViewState["CurrentTable"] = table;
                                GvDeAssemblyPartDetails.DataSource = DtPartDetails;
                                GvDeAssemblyPartDetails.DataBind();
                                GvDeAssemblyPartDetails.Enabled = true;


                                if (DtBarcode.Rows.Count > 0)
                                {

                                    GvNewBarcodeGrid.DataSource = DtBarcode;
                                    GvNewBarcodeGrid.DataBind();
                                    GvNewBarcodeGrid.Enabled = true;
                                }

                                BtncallUpd.Text = "UPDATE";


                                #endregion
                            }
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
                }



                if (e.CommandName == "Viewa")
                {
                    #region SET TEXT ON VIEW
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = ASS_TRANMASLogicLayer.GetAllIDWiseDE_ASSEMBLE_TRAN_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtPartDetails = ds.Tables[1];
                        DataTable DtBarcode = ds.Tables[2];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            HfBar_Tran_Date.Value = dt.Rows[0]["BAR_TRAN_DATE"].ToString();
                            HfBar_Tran_No.Value = dt.Rows[0]["BAR_TRAN_NO"].ToString();
                            HfBar_SrNo.Value = dt.Rows[0]["BAR_SRNO"].ToString();
                            HfAmount.Value = dt.Rows[0]["AMT"].ToString();
                            TxtSrNo.Text = dt.Rows[0]["SRNO"].ToString();
                            TxtAssemblyDate.Text = Convert.ToDateTime(dt.Rows[0]["TRNDT"].ToString()).ToString("dd-MM-yyyy");
                            FillProductNameOnUpdate(dt.Rows[0]["SCODE"].ToString());
                            FillBarcodeNoOnUpdate();
                            TxtQty.Text = dt.Rows[0]["QTY"].ToString();
                            TxtRate.Text = dt.Rows[0]["RATE"].ToString();
                            DdlPreparedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtAuthorisedDate.Text = dt.Rows[0]["AUTH_DATE"].ToString();
                            TxtAuthorisedBy.Text = dt.Rows[0]["AUTH_USERID"].ToString();
                            DdlAuthoriseFlag.SelectedValue = dt.Rows[0]["AUTH_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString(); //Convert.ToDateTime(dt.Rows[0]["CONF_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtConfirmedBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();

                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value.ToString();
                            Session["TRAN_TYPE"] = HfTranType.Value.ToString();

                            if (DtPartDetails.Rows.Count > 0)
                            {
                                GvDeAssemblyPartDetails.DataSource = DtPartDetails;
                                GvDeAssemblyPartDetails.DataBind();
                                GvDeAssemblyPartDetails.Enabled = false;
                            }

                            if (DtBarcode.Rows.Count > 0)
                            {

                                GvNewBarcodeGrid.DataSource = DtBarcode;
                                GvNewBarcodeGrid.DataBind();
                                GvNewBarcodeGrid.Enabled = false;
                            }
                        }
                    }

                    #endregion

                    ControllerDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    UserRights();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvDe_AssembleTransactionMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE 

                if (HfTranNo.Value != string.Empty && HfTranDate.Value != string.Empty)
                {
                    string str = ASS_TRANMASLogicLayer.DeleteASSEMBLE_TRAN_MASDetailsByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value.ToString()));
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
                        lblmsg.Text = "Error:Assemble Transaction Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillDE_ASSEMBLE_TRANMasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region UPDATE DE-TRANSACTION MASTER

                #region INSERT INTO ASSEMPBLE_TRAN MASTER

                ASS_TRANMASLogicLayer insert = new ASS_TRANMASLogicLayer();
                insert.COMP_CODE = Session["COMP_CODE"].ToString();
                insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.TRAN_TYPE = HfTranType.Value.Trim().ToUpper();
                insert.TRNDT = Convert.ToDateTime(TxtAssemblyDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                if (TxtSrNo.Text == string.Empty)
                {
                    insert.SRNO = "0";
                }
                else
                {
                    insert.SRNO = TxtSrNo.Text.Trim();
                }
                if (hfSCODE.Value != string.Empty)
                {
                    insert.SCODE = hfSCODE.Value.Trim();
                }

                insert.BCODE = DdlPreparedBy.SelectedValue.Trim();

                if (TxtQty.Text == string.Empty)
                {
                    insert.QTY = "0";
                }
                else
                {
                    insert.QTY = TxtQty.Text.Trim();
                }

                if (TxtRate.Text == string.Empty)
                {
                    insert.RATE = "0";
                }
                else
                {
                    insert.RATE = TxtRate.Text.Trim();
                }


                if (HfAmount.Value == string.Empty)
                {
                    insert.AMT = "0";
                }
                else
                {
                    insert.AMT = HfAmount.Value.Trim();
                }

                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_DATE = "";
                insert.AUTH_FLAG = DdlAuthoriseFlag.SelectedValue.Trim().ToUpper();
                if (DdlAuthoriseFlag.SelectedValue == "Y")
                {
                    insert.AUTH_DATE = Convert.ToDateTime(TxtAuthorisedDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.AUTH_DATE = "";
                }
                if (DdlAuthoriseFlag.SelectedValue == "Y")
                {
                    insert.AUTH_USERID = Session["USERNAME"].ToString();
                }
                else
                {
                    insert.AUTH_USERID = "";
                }

                insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                insert.ENDT = "";
                insert.STATUS = "O";
                insert.PART_AMT = "0";
                insert.LAB_AMT = "0";
                insert.BAR_TRAN_DATE = Convert.ToDateTime(HfBar_Tran_Date.Value.Trim().ToUpper()).ToString("MM-dd-yyyy");
                insert.BAR_TRAN_NO = HfBar_Tran_No.Value.Trim();
                insert.BAR_SRNO = HfBar_SrNo.Value.Trim();

                insert.CONF_FLAG = DdlConfirmFlag.SelectedValue.Trim().ToUpper();
                if (DdlConfirmFlag.SelectedValue == "Y")
                {
                    insert.CONF_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.CONF_DATE = "";
                }
                if (DdlConfirmFlag.SelectedValue == "Y")
                {
                    insert.CONF_USERID = Session["USERNAME"].ToString();
                }
                else
                {
                    insert.CONF_USERID = "";
                }

                #endregion


                #region INSERT INTO ASSEMBLE_TRAN DETAILS

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);
                int SRNODETAIL = 1;
                foreach (GridViewRow row in GvDeAssemblyPartDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                        HiddenField HfTransNo = row.FindControl("HfTransNo") as HiddenField;
                        HiddenField HfStatus = row.FindControl("HfStatus") as HiddenField;
                        HiddenField HfAmount = row.FindControl("HfAmount") as HiddenField;
                        HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                        HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;

                        TextBox TxtProductCode = row.FindControl("TxtProductCode") as TextBox;
                        TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                        TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                        TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                        TextBox TxtRatePer = row.FindControl("TxtRatePer") as TextBox;

                        if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != null)
                        {

                            XmlElement HandleDetail2 = XDoc1.CreateElement("ASS_TRANDetails");

                            HandleDetail2.SetAttribute("SRNO", SRNODETAIL.ToString());
                            HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                            HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                            if (HfDetailSCode.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("SCODE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value));
                            }

                            if (TxtQty.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("QTY", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("QTY", (TxtQty.Text));
                            }

                            if (TxtRatePer.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("PER", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("PER", (TxtRatePer.Text));
                            }

                            if (TxtRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("RATE", (TxtRate.Text));
                            }

                            if (HfAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("AMT", (HfAmount.Value));
                            }

                            HandleDetail2.SetAttribute("STATUS", ("O"));

                            root1.AppendChild(HandleDetail2);
                            SRNODETAIL++;
                        }

                    }
                }

                #endregion


                Label lblSumTotalRatePercentage = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalRatePercentage"));

                if (Convert.ToDecimal(lblSumTotalRatePercentage.Text) == 100)
                {
                    DataSet str = ASS_TRANMASLogicLayer.UpdateDE_ASSEMBLE_TRAN_MASDetail(insert, validation.RSC(XDoc1.OuterXml));

                    string P_Type = "U";

                    if (str != null)
                    {

                        if (str.Tables.Count > 0)
                        {
                            DataTable DtDetail = str.Tables[0];

                            if (Session["WORK_VIEWFLAG"].ToString() == "B")
                            {
                                for (int d = 0; d < DtDetail.Rows.Count; d++)
                                {

                                    string BarCodeStr = DC_MASLogicLayer.GenerateBracodeForPurchaseOrder(P_Type.ToString(), HfCompCode.Value.ToString(), HfBranchCode.Value.ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), TxtSrNo.Text, DtDetail.Rows[d]["SCODE"].ToString(), DtDetail.Rows[d]["QTY"].ToString(), DtDetail.Rows[d]["RATE"].ToString(), HfTranType.Value.ToString(), Convert.ToDateTime(DtDetail.Rows[d]["TRAN_DATE"].ToString()), DtDetail.Rows[d]["TRAN_NO"].ToString(), DtDetail.Rows[d]["SRNO"].ToString());
                                }
                            }
                        }

                        lblmsg.Text = "DE-ASSEMBLE TRANSACTION UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillDE_ASSEMBLE_TRANMasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str != null)
                    {
                        lblmsg.Text = "DE-ASSEMBLE TRANSACTION ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : DE-ASSEMBLE TRANSACTION MASTER NOT SAVED";
                        lblmsg.ForeColor = Color.Red;

                    }


                    #endregion
                }

                else
                {
                    lblmsg.Text = "ERROR : PERCENTAGE SHOULD BE 100%";
                    lblmsg.ForeColor = Color.Red;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (TxtBarcode.Text != string.Empty)
                {
                    DataTable Dt = new DataTable();
                    Dt = BARCODE_MASLogicLayer.GetBarcodeDetail_ForDeAssembleTransaction(TxtBarcode.Text.Trim());
                    TxtProductCode.Text = Dt.Rows[0]["PROD_CODE"].ToString();
                    TxtProductName.Text = Dt.Rows[0]["SNAME"].ToString();
                    hfSCODE.Value = Dt.Rows[0]["SCODE"].ToString();
                    TxtQty.Text = "1";
                    TxtRate.Text = Dt.Rows[0]["RATE"].ToString();
                    HfBar_Tran_No.Value = Dt.Rows[0]["TRAN_NO"].ToString();
                    HfBar_Tran_Date.Value = Dt.Rows[0]["TRAN_DATE"].ToString();
                    HfBar_SrNo.Value = Dt.Rows[0]["SRNO"].ToString();
                    HfASEEMBLE_TRAN_DATE.Value = Dt.Rows[0]["ASS_TRAN_DATE"].ToString();
                    HfASSEMBLE_TRAN_NO.Value = Dt.Rows[0]["ASS_TRAN_NO"].ToString();

                    HfAmount.Value = Convert.ToString(Convert.ToDouble(TxtRate.Text) * Convert.ToDouble(TxtQty.Text)).ToString();


                }


                //DataSet ds = ASS_TRANMASLogicLayer.GetAllIDWiseASSEMBLE_TRAN_MASDetials(HfASSEMBLE_TRAN_NO.Value.ToString(), Convert.ToDateTime(HfASEEMBLE_TRAN_DATE.Value.ToString()));
                //DataTable DtPartDetails = ds.Tables[1];

                //if (DtPartDetails.Rows.Count > 0)
                //{
                //    #region Assign Table

                //    DataTable table = new DataTable();
                //    DataRow drm = null;
                //    if (ViewState["CurrentTable"] != null)
                //    {
                //        table = (DataTable)ViewState["CurrentTable"];
                //    }
                //    else
                //    {
                //        if (table.Rows.Count <= 0)
                //        {
                //            table.Columns.Add("COMP_CODE", typeof(string));
                //            table.Columns.Add("TRAN_DATE", typeof(string));
                //            table.Columns.Add("TRAN_NO", typeof(string));
                //            table.Columns.Add("SRNO", typeof(string));
                //            table.Columns.Add("SCODE", typeof(string));
                //            table.Columns.Add("QTY", typeof(string));
                //            table.Columns.Add("RATE", typeof(string));
                //            table.Columns.Add("AMT", typeof(string));
                //            table.Columns.Add("STATUS", typeof(string));
                //            table.Columns.Add("PER", typeof(string));

                //        }
                //    }
                //    for (int m = 0; m < DtPartDetails.Rows.Count; m++)
                //    {
                //        drm = table.NewRow();
                //        drm["COMP_CODE"] = DtPartDetails.Rows[m]["COMP_CODE"].ToString();
                //        drm["TRAN_DATE"] = DtPartDetails.Rows[m]["TRAN_DATE"].ToString();
                //        drm["TRAN_NO"] = DtPartDetails.Rows[m]["TRAN_NO"].ToString();
                //        drm["SRNO"] = DtPartDetails.Rows[m]["SRNO"].ToString();
                //        drm["SCODE"] = DtPartDetails.Rows[m]["SCODE"].ToString();
                //        drm["QTY"] = DtPartDetails.Rows[m]["QTY"].ToString();
                //        drm["RATE"] = DtPartDetails.Rows[m]["RATE"].ToString();
                //        drm["AMT"] = DtPartDetails.Rows[m]["AMT"].ToString();
                //        drm["STATUS"] = DtPartDetails.Rows[m]["STATUS"].ToString();
                //        drm["PER"] = DtPartDetails.Rows[m]["PER"].ToString();
                //        table.Rows.Add(drm);
                //    }
                //    #endregion

                //    ViewState["CurrentTable"] = table;
                //    GvDeAssemblyPartDetails.DataSource = DtPartDetails;
                //    GvDeAssemblyPartDetails.DataBind();

                //} 

            }
            catch (Exception)
            {

                throw;
            }
        }


        #region Calculation On Deassemble Stocks Parts Grids

        public void FillOnGridDetailChanged()
        {
            #region Assiggn to stock parts grid table

            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values 

                        Label lblSumTotalQuantity = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalQuantity"));
                        Label lblSumTotalRatePercentage = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalRatePercentage"));
                        Label lblSumTotalRate = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalRate"));
                        Button BtnAddRowModelDeAssemblePartsGrid = (Button)(GvDeAssemblyPartDetails.FooterRow.FindControl("BtnAddRowModelDeAssemblePartsGrid"));

                        HiddenField HfDetailSCode = (HiddenField)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        HiddenField HfStatus = (HiddenField)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[0].FindControl("HfStatus");
                        HiddenField HfAmount = (HiddenField)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        TextBox TxtProductCode = (TextBox)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[1].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductName");
                        TextBox TxtQty = (TextBox)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[3].FindControl("TxtQty");
                        TextBox TxtRatePer = (TextBox)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[4].FindControl("TxtRatePer");
                        TextBox TxtRate = (TextBox)GvDeAssemblyPartDetails.Rows[rowIndex].Cells[5].FindControl("TxtRate");


                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = HfAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["STATUS"] = HfStatus.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["PER"] = TxtRatePer.Text.Trim();


                        rowIndex++;
                    }
                }
            }

                        #endregion
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

                TextBox TxtProductName = (TextBox)row.Cells[2].FindControl("TxtProductName");
                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");


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
                        FillOnGridDetailChanged();
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

                TextBox TxtProductCode = (TextBox)row.Cells[1].FindControl("TxtProductCode");
                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");


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
                        FillOnGridDetailChanged();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void TxtRatePer_TextChanged(object sender, EventArgs e)
        {
            try
            {

                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;



                Button BtnAddRowModelDeAssemblePartsGrid = (Button)(GvDeAssemblyPartDetails.FooterRow.FindControl("BtnAddRowModelDeAssemblePartsGrid"));

                Label lblSumTotalQuantity = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalQuantity"));
                Label lblSumTotalRatePercentage = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalRatePercentage"));
                Label lblSumTotalRate = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalRate"));

                TextBox TxtQtyDetailGrid = (TextBox)row.Cells[4].FindControl("TxtQty");
                TextBox TxtRateDetailGrid = (TextBox)row.Cells[6].FindControl("TxtRate");
                HiddenField HfAmount = (HiddenField)row.Cells[0].FindControl("HfAmount");

                double lblTotalQty = TotalQuantity();
                lblSumTotalQuantity.Text = lblTotalQty.ToString();

                double lblTotalRatePer = TotalRatePer();
                lblSumTotalRatePercentage.Text = lblTotalRatePer.ToString();



                if (Convert.ToDecimal(lblSumTotalRatePercentage.Text) <= 100)
                {
                    if (TxtRate.Text != string.Empty)
                    {
                        if (TxtQtyDetailGrid.Text != string.Empty)
                        {
                            TxtRateDetailGrid.Text = (((Convert.ToDouble(TxtRate.Text.Trim()) * Convert.ToDouble(txt.Text)) / 100) / Convert.ToDouble(TxtQtyDetailGrid.Text)).ToString();
                            HfAmount.Value = ((Convert.ToDouble(TxtRateDetailGrid.Text.Trim()) * Convert.ToDouble(TxtQtyDetailGrid.Text)).ToString());
                        }
                        else
                        {
                            TxtRateDetailGrid.Text = ((Convert.ToDouble(TxtRate.Text.Trim()) * Convert.ToDouble(txt.Text)) / 100).ToString();
                        }


                        double lblTotalRate = TotalRate();
                        lblSumTotalRate.Text = lblTotalRate.ToString();

                        if (Convert.ToDecimal(lblSumTotalRatePercentage.Text) < 100)
                        {
                            BtnAddRowModelDeAssemblePartsGrid.Enabled = true;
                        }
                        else
                        {
                            BtnAddRowModelDeAssemblePartsGrid.Enabled = false;
                        }

                    }


                    else
                    {
                        TxtRateDetailGrid.Text = Convert.ToString(Convert.ToDouble(0));
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Percentage should be less than 100 and Must be Number..!!');", true);
                    BtnAddRowModelDeAssemblePartsGrid.Enabled = false;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                Button BtnAddRowModelDeAssemblePartsGrid = (Button)(GvDeAssemblyPartDetails.FooterRow.FindControl("BtnAddRowModelDeAssemblePartsGrid"));

                Label lblSumTotalQuantity = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalQuantity"));
                Label lblSumTotalRatePercentage = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalRatePercentage"));
                Label lblSumTotalRate = (Label)(GvDeAssemblyPartDetails.FooterRow.FindControl("lblSumTotalRate"));

                TextBox TxtRatePerDetailGrid = (TextBox)row.Cells[4].FindControl("TxtRatePer");
                TextBox TxtRateDetailGrid = (TextBox)row.Cells[6].FindControl("TxtRate");
                HiddenField HfAmount = (HiddenField)row.Cells[0].FindControl("HfAmount");

                if (TxtRatePerDetailGrid.Text == string.Empty)
                {
                    TxtRatePerDetailGrid.Text = "0";

                }

                if (Convert.ToDecimal(lblSumTotalRatePercentage.Text) <= 100)
                {
                    if (TxtRate.Text != string.Empty)
                    {
                        if (TxtRatePerDetailGrid.Text != string.Empty)
                        {
                            TxtRateDetailGrid.Text = (((Convert.ToDouble(TxtRate.Text.Trim()) * Convert.ToDouble(TxtRatePerDetailGrid.Text)) / 100) / Convert.ToDouble(txt.Text)).ToString();
                            HfAmount.Value = ((Convert.ToDouble(TxtRateDetailGrid.Text.Trim()) * Convert.ToDouble(txt.Text)).ToString());
                        }
                        else
                        {
                            TxtRateDetailGrid.Text = ((Convert.ToDouble(TxtRate.Text.Trim()) * Convert.ToDouble(TxtRatePerDetailGrid.Text)) / 100).ToString();
                        }


                        double lblTotalQty = TotalQuantity();
                        lblSumTotalQuantity.Text = lblTotalQty.ToString();

                        double lblTotalRatePer = TotalRatePer();
                        lblSumTotalRatePercentage.Text = lblTotalRatePer.ToString();

                        double lblTotalRate = TotalRate();
                        lblSumTotalRate.Text = lblTotalRate.ToString();

                        if (Convert.ToDecimal(lblSumTotalRatePercentage.Text) < 100)
                        {
                            BtnAddRowModelDeAssemblePartsGrid.Enabled = true;
                        }
                        else
                        {
                            BtnAddRowModelDeAssemblePartsGrid.Enabled = false;
                        }

                    }


                    else
                    {
                        TxtRateDetailGrid.Text = Convert.ToString(Convert.ToDouble(0));
                    }
                }
                else
                {
                    // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Percentage should be less than 100 and Must be Number..!!');", true);
                    BtnAddRowModelDeAssemblePartsGrid.Enabled = false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion


        protected void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../reportviewPages/DeAssembleTransactionPrint.aspx', '_blank');", true);
        }

        protected void DdlAuthoriseFlag_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DdlConfirmFlag_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtSearch.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtSearch);
                    Dv.RowFilter = "ProductCode like '%" + TxtSearch.Text.Trim() + "%' OR Convert(SRNO, 'System.String') like '%" + TxtSearch.Text.Trim() + "%'  OR ProductName like '%" + TxtSearch.Text.Trim() + "%'  OR PersonName like '%" + TxtSearch.Text.Trim() + "%' ";
                    GvDe_AssembleTransactionMaster.DataSource = Dv.ToTable();
                    GvDe_AssembleTransactionMaster.DataBind();
                }
                else
                {
                    GvDe_AssembleTransactionMaster.DataSource = DtSearch;
                    GvDe_AssembleTransactionMaster.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}