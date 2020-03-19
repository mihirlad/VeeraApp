using MihirValid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class StockBarcodeAudit : System.Web.UI.Page
    {
        public static string compcode;
        static DataTable DtSearch = new DataTable();
        public static string Branchcode;

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
                Branchcode = Session["BRANCH_CODE"].ToString();

                if (!Page.IsPostBack)
                {
                    DivEntry.Visible = false;

                    SetInitialRowAuditDetails();
                    DivView.Visible = true;
                    //   FillINCREMENT_MasterGrid(Session["COMP_CODE"].ToString());
                }
            }

            else
            {
                Response.Redirect("../Login.aspx");
            }
        }



        private void SetInitialRowAuditDetails()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("BARCODE", typeof(string));
            table.Columns.Add("BAR_TRAN_DATE", typeof(string));
            table.Columns.Add("BAR_TRAN_NO", typeof(string));
            table.Columns.Add("BAR_SRNO", typeof(string));
            table.Columns.Add("INS_USERID", typeof(string));
            table.Columns.Add("INS_DATE", typeof(string));
            table.Columns.Add("STATUS", typeof(string));
         


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["SCODE"] = string.Empty;
            dr["BARCODE"] = string.Empty;
            dr["BAR_TRAN_DATE"] = string.Empty;
            dr["BAR_TRAN_NO"] = string.Empty;
            dr["BAR_SRNO"] = string.Empty;
            dr["INS_USERID"] = string.Empty;
            dr["INS_DATE"] = string.Empty;
            dr["STATUS"] = string.Empty;
            

            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvBarcodeAuditDetails.DataSource = table;
            GvBarcodeAuditDetails.DataBind();
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


        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfCompCode.Value = string.Empty;
            HfBranchCode.Value = string.Empty;
            HfTranDate.Value = string.Empty;
            HfTranNo.Value = string.Empty;
            HfTPreparedByBCODE.Value = string.Empty;

            TxtSrNo.Text = string.Empty;
            TxtStartDate.Text = string.Empty;
            TxtEndDate.Text = string.Empty;
            TxtPreparedBy.Text = string.Empty;
            TxtRemarks.Text = string.Empty;

            BtncallUpd.Text = "SAVE";
        }

        public void ControllerEnable()
        {
            TxtSrNo.Enabled = true;
            TxtStartDate.Enabled = true;
            TxtEndDate.Enabled = true;
            TxtPreparedBy.Enabled = true;
            TxtRemarks.Enabled = true;
        }

        public void ControllerDisable()
        {
            TxtSrNo.Enabled = false;
            TxtStartDate.Enabled = false;
            TxtEndDate.Enabled = false;
            TxtPreparedBy.Enabled = false;
            TxtRemarks.Enabled = false;
        }

        protected void GvBarcodeAuditDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

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
                TxtStartDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
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
            ViewState["CurrentTable"] = null;
            clear();
            lblmsg.Text = string.Empty;
            UserRights();
        }

        protected void BtncallUpd_Click(object sender, EventArgs e)
        {

        }

        protected void Btncalldel_Click(object sender, EventArgs e)
        {

        }


        protected void GvStockBarcodeAuditMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvStockBarcodeAuditMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }



        #region ADD BARCODE PROCESS INTO GRID

        public void FillOnlyViewBarcodePopup()
        {
            try
            {
                DataTable dt = new DataTable();
                if (ViewState["BarcodeTemp"] != null)
                {
                    dt = (DataTable)ViewState["BarcodeTemp"];
                }
                else
                {

                    dt.Columns.Add("BARRCODE", typeof(System.String));
                    dt.Columns.Add("QTY", typeof(System.String));
                    dt.Columns.Add("SCODE", typeof(System.String));
                    dt.Columns.Add("BAR_TRAN_DATE", typeof(System.String));
                    dt.Columns.Add("BAR_TRAN_NO", typeof(System.String));
                    dt.Columns.Add("BAR_SRNO", typeof(System.String));

                    for (int i = 0; i < 50; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["BARRCODE"] = "";
                        dr["QTY"] = "";
                        dr["SCODE"] = "";
                        dr["BAR_TRAN_DATE"] = "";
                        dr["BAR_TRAN_NO"] = "";
                        dr["BAR_SRNO"] = "";
                        dt.Rows.Add(dr);
                    }
                }

                GvViewBarcode.DataSource = dt;
                GvViewBarcode.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillViewBarcodePopup(int C)
        {
            try
            {
                DataTable dt = new DataTable();


                dt.Columns.Add("BARRCODE", typeof(System.String));
                dt.Columns.Add("QTY", typeof(System.String));
                dt.Columns.Add("SCODE", typeof(System.String));
                dt.Columns.Add("BAR_TRAN_DATE", typeof(System.String));
                dt.Columns.Add("BAR_TRAN_NO", typeof(System.String));
                dt.Columns.Add("BAR_SRNO", typeof(System.String));


                for (int i = 0; i < 50; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["BARRCODE"] = "";
                    dr["QTY"] = "";
                    dr["SCODE"] = "";
                    dr["BAR_TRAN_DATE"] = "";
                    dr["BAR_TRAN_NO"] = "";
                    dr["BAR_SRNO"] = "";

                    dt.Rows.Add(dr);
                }
                if (C == 1)
                {
                    //ViewState["BarcodeTemp"] = dt;
                }
                GvViewBarcode.DataSource = dt;
                GvViewBarcode.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnAddBarcode_Click(object sender, EventArgs e)
        {
            ViewState["BarcodeTempNew"] = null;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelViewBarcode", "ShowModelViewBarcode()", true);
            FillViewBarcodePopup(1);
            foreach (GridViewRow row in GvViewBarcode.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                    TxtBarcode.Focus();
                }
            }
            btnAddBarcodeProcess.Visible = true;
            btnUploadBarcodeProcess.Visible = true;
            FileUpload1.Visible = true;
            DivBarcodeInput.Visible = true;
        }

        protected void TxtBarcodeInputNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtBarcodeInputNo.Text.Trim() != string.Empty && validation.isNumberWithoutComa(TxtBarcodeInputNo.Text.Trim()))
                {
                    DataTable dtCurrentTableBlankFilter = new DataTable();
                    DataTable dtCurrentTable = new DataTable();
                    DataRow dr = null;
                    if (ViewState["BarcodeTempNew"] != null)
                    {
                        dtCurrentTableBlankFilter = (DataTable)ViewState["BarcodeTempNew"];

                        DataView dvBlankFilter = new DataView(dtCurrentTableBlankFilter);
                        dvBlankFilter.RowFilter = "BARRCODE<>''";
                        dtCurrentTable = dvBlankFilter.ToTable();



                        //NEW BLOCK FOR ADD SECOND ROW ISSUE  ON 13-09-2019
                        foreach (GridViewRow row in GvViewBarcode.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {
                                TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                                TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                                HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                                HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                                HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;

                                if (TxtBarcode.Text.Trim() != string.Empty)
                                {
                                    DataView dv = new DataView(dtCurrentTable);
                                    dv.RowFilter = "BARRCODE='" + TxtBarcode.Text.Trim() + "'";
                                    DataTable dtCurrentTableFilter = new DataTable();
                                    dtCurrentTableFilter = dv.ToTable();
                                    if (dtCurrentTableFilter.Rows.Count <= 0)
                                    {
                                        dr = dtCurrentTable.NewRow();
                                        //dr = dtCurrentTable.Rows[dtCurrentTable.Rows.Count - 1];

                                        dr["BARRCODE"] = TxtBarcode.Text.Trim();
                                        dr["QTY"] = TxtQty.Text.Trim();
                                        dr["SCODE"] = "";
                                        dr["BAR_TRAN_DATE"] = HfBarTranDate.Value;
                                        dr["BAR_TRAN_NO"] = HfBarTranNo.Value;
                                        dr["BAR_SRNO"] = HfBarSrNo.Value;
                                        dtCurrentTable.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                        //*****//
                    }
                    else
                    {
                        dtCurrentTable.Columns.Add("BARRCODE", typeof(System.String));
                        dtCurrentTable.Columns.Add("QTY", typeof(System.String));
                        dtCurrentTable.Columns.Add("SCODE", typeof(System.String));
                        dtCurrentTable.Columns.Add("BAR_TRAN_DATE", typeof(System.String));
                        dtCurrentTable.Columns.Add("BAR_TRAN_NO", typeof(System.String));
                        dtCurrentTable.Columns.Add("BAR_SRNO", typeof(System.String));

                        foreach (GridViewRow row in GvViewBarcode.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {
                                TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                                TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                                HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                                HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                                HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;

                                if (TxtBarcode.Text.Trim() != string.Empty)
                                {
                                    dr = dtCurrentTable.NewRow();

                                    dr["BARRCODE"] = TxtBarcode.Text.Trim();
                                    dr["QTY"] = TxtQty.Text.Trim();
                                    dr["SCODE"] = "";
                                    dr["BAR_TRAN_DATE"] = HfBarTranDate.Value;
                                    dr["BAR_TRAN_NO"] = HfBarTranNo.Value;
                                    dr["BAR_SRNO"] = HfBarSrNo.Value;
                                    dtCurrentTable.Rows.Add(dr);
                                }
                            }
                        }
                    }



                    for (int j = 0; j < Convert.ToInt32(TxtBarcodeInputNo.Text.Trim()); j++)
                    {
                        dr = dtCurrentTable.NewRow();

                        dr["BARRCODE"] = "";
                        dr["QTY"] = "";
                        dr["SCODE"] = "";
                        dr["BAR_TRAN_DATE"] = "";
                        dr["BAR_TRAN_NO"] = "";
                        dr["BAR_SRNO"] = "";

                        dtCurrentTable.Rows.Add(dr);
                    }
                    ViewState["BarcodeTempNew"] = dtCurrentTable;

                    GvViewBarcode.DataSource = dtCurrentTable;
                    GvViewBarcode.DataBind();
                    TxtBarcodeInputNo.Text = string.Empty;
                }
                else
                {
                    //alert
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('invalid number')", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        public bool CheckforDuplicates(string[] array)
        {
            var duplicates = array
             .GroupBy(p => p)
             .Where(g => g.Count() > 1)
             .Select(g => g.Key);
            return (duplicates.Count() > 0);
        }
        public string dupbarcode = "";
        private void HasDuplicates(string[] arrayList)
        {
            List<string> vals = new List<string>();
            foreach (string s in arrayList)
            {
                if (vals.Contains(s))
                {
                    dupbarcode = dupbarcode + s + ",";
                }
                vals.Add(s);
            }
        }


        protected void TxtBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {


                List<string> list = new List<string>();
                foreach (GridViewRow row in GvViewBarcode.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                        HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                        HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                        HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;
                        Label lblmsg = row.FindControl("lblmsg") as Label;

                        if (TxtBarcode.Text == "")
                        {

                        }
                        else
                        {
                            list.Add(TxtBarcode.Text);
                        }
                    }
                }

                string[] name = list.ToArray();

                HasDuplicates(name);
                if (dupbarcode == "")
                {
                    //DataTable DtBarcodeTemp = new DataTable();
                    //if (ViewState["BarcodeTemp"] != null)
                    //{
                    //    DtBarcodeTemp = (DataTable)ViewState["BarcodeTemp"];
                    //}
                    //else
                    //{
                    //    DtBarcodeTemp.Columns.Add("BARRCODE", typeof(string));
                    //    DtBarcodeTemp.Columns.Add("QTY", typeof(string));
                    //    DtBarcodeTemp.Columns.Add("SCODE", typeof(string));
                    //    DtBarcodeTemp.Columns.Add("BAR_TRAN_DATE", typeof(string));
                    //    DtBarcodeTemp.Columns.Add("BAR_TRAN_NO", typeof(string));
                    //    DtBarcodeTemp.Columns.Add("BAR_SRNO", typeof(string));
                    //}


                    //foreach (GridViewRow row in GvViewBarcode.Rows)
                    //{
                    //    if (row.RowType == DataControlRowType.DataRow)
                    //    {

                    TextBox txt = (TextBox)sender;
                    GridViewRow rowinner = (GridViewRow)txt.Parent.Parent;
                    int idx = rowinner.RowIndex;

                    TextBox TxtBarcodeinner = (TextBox)rowinner.Cells[1].FindControl("TxtBarcode");
                    TextBox TxtQtyinner = (TextBox)rowinner.Cells[2].FindControl("TxtQty");
                    Label lblmsg = (Label)rowinner.Cells[3].FindControl("lblmsg");

                    //TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                    //        TextBox TxtQty = row.FindControl("TxtQty") as TextBox;


                    DataTable DtBarcode = new DataTable();
                    DtBarcode = BARCODE_MASLogicLayer.GetBarcodeDetail_WiseBarcodeNo(TxtBarcodeinner.Text.Trim());
                    DataView Dv = new DataView(DtBarcode);
                    Dv.RowFilter = "STATUSFlag='O'";
                    DataTable FilterBarcode = Dv.ToTable();


                    //DataView DvBarcodeTemptable = new DataView(DtBarcodeTemp);
                    //DvBarcodeTemptable.RowFilter = "BARRCODE='" + TxtBarcode.Text.Trim() + "'";
                    //DataTable DtBarcodeTempFiltertable = DvBarcodeTemptable.ToTable();

                    //if (DtBarcodeTempFiltertable.Rows.Count <= 0)
                    //{
                    if (FilterBarcode.Rows.Count > 0)
                    {

                        TxtQtyinner.Text = "1";
                        TxtBarcodeinner.ForeColor = Color.Black;
                        lblmsg.Text = string.Empty;
                        TextBox nexTextbox = GvViewBarcode.Rows[name.Length].Cells[1].FindControl("TxtBarcode") as TextBox;

                        //nexTextbox.Text = "jigar";
                        //nexTextbox.Focus();
                    }
                    else
                    {
                        //alert
                        //  lblbarduperror.Text = "Barcode is not available..! " ;
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Barcode is not available..!!');", true);
                        TxtBarcodeinner.ForeColor = Color.Red;
                        TxtBarcodeinner.Focus();
                    }
                    int index = ((TextBox)sender).TabIndex;
                    TextBox TxtBarcodeMove = (TextBox)GvViewBarcode.Rows[index + 1].FindControl("TxtBarcode");
                    TxtBarcodeMove.Focus();
                    //TxtBarcodeMove.BackColor = Color.Gray;

                    //}
                    //else
                    //{
                    //    TxtBarcode.ForeColor = Color.Red;


                    //}

                    //    }
                    //}
                    //GvViewBarcode.DataSource = DtBarcodeTemp;
                    //GvViewBarcode.DataBind();
                    lblbarduperror.Text = string.Empty;
                    //GvViewBarcode.Rows[idx].FindControl("TxtBarcode").Focus();
                }
                else
                {
                    //lblbarduperror.Text = "Duplicate Barcode Found! Details:- " + dupbarcode.TrimEnd(',');
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Duplicate Barcode Found!Details:-" + dupbarcode.TrimEnd(',') + "');", true);
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAddBarcodeProcess_Click(object sender, EventArgs e)
        {

        }

        public DataTable ImportExceltoDatatable(string filepath)
        {
            // string sqlquery= "Select * From [SheetName$] Where YourCondition";
            string sqlquery = "Select * From [Sheet1$]";
            DataSet ds = new DataSet();
            string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
            OleDbConnection con = new OleDbConnection(constring + "");
            OleDbDataAdapter da = new OleDbDataAdapter(sqlquery, con);
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }


        protected void btnUploadBarcodeProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile == true)
                {
                    string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                    string FilePath = Server.MapPath(FolderPath + FileName);

                    FileUpload1.SaveAs(FilePath);
                    DataTable DtCust = ImportExceltoDatatable(FilePath);

                    DataTable DtBarcodeTemp = new DataTable();
                    DtBarcodeTemp.Columns.Add("BARRCODE", typeof(string));
                    DtBarcodeTemp.Columns.Add("QTY", typeof(string));
                    DtBarcodeTemp.Columns.Add("SCODE", typeof(string));
                    DtBarcodeTemp.Columns.Add("BAR_TRAN_DATE", typeof(string));
                    DtBarcodeTemp.Columns.Add("BAR_TRAN_NO", typeof(string));
                    DtBarcodeTemp.Columns.Add("BAR_SRNO", typeof(string));

                    DataRow dr = null;

                    for (int i = 0; i < DtCust.Rows.Count; i++)
                    {
                        dr = DtBarcodeTemp.NewRow();
                        dr["BARRCODE"] = DtCust.Rows[i]["BARRCODE"].ToString();
                        dr["QTY"] = "1";
                        dr["SCODE"] = string.Empty;
                        dr["BAR_TRAN_DATE"] = string.Empty;
                        dr["BAR_TRAN_NO"] = string.Empty;
                        dr["BAR_SRNO"] = string.Empty;
                        DtBarcodeTemp.Rows.Add(dr);
                    }

                    GvViewBarcode.DataSource = DtBarcodeTemp;
                    GvViewBarcode.DataBind();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelViewBarcode", "ShowModelViewBarcode()", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void AddNewRowBarcodeView()
        {
            try
            {

                //if (ViewState["BarcodeTemp"] != null)
                //{
                //    DataTable dtCurrentTable = (DataTable)ViewState["BarcodeTemp"];
                //    DataRow dr = null;
                //    if (dtCurrentTable.Rows.Count > 0)
                //    {
                //        dr = dtCurrentTable.NewRow();

                //        dr["BARRCODE"] = "";
                //        dr["QTY"] = "";
                //        dr["SCODE"] = "";
                //        dr["BAR_TRAN_DATE"] = "";
                //        dr["BAR_TRAN_NO"] = "";
                //        dr["BAR_SRNO"] = "";




                //        dtCurrentTable.Rows.Add(dr);
                //        ViewState["BarcodeTemp"] = dtCurrentTable;

                //        GvViewBarcode.DataSource = dtCurrentTable;
                //        GvViewBarcode.DataBind();
                //    }
                //}
                //else
                //{
                DataTable dtCurrentTableBlankFilter = new DataTable();
                DataTable dtCurrentTable = new DataTable();
                DataRow dr = null;
                if (ViewState["BarcodeTempNew"] != null)
                {
                    dtCurrentTableBlankFilter = (DataTable)ViewState["BarcodeTempNew"];

                    DataView dvBlankFilter = new DataView(dtCurrentTableBlankFilter);
                    dvBlankFilter.RowFilter = "BARRCODE<>''";
                    dtCurrentTable = dvBlankFilter.ToTable();

                    //dtCurrentTable = (DataTable)ViewState["BarcodeTempNew"];

                    //NEW BLOCK FOR ADD SECOND ROW ISSUE  ON 13-09-2019
                    foreach (GridViewRow row in GvViewBarcode.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                            HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                            HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;

                            if (TxtBarcode.Text.Trim() != string.Empty)
                            {
                                DataView dv = new DataView(dtCurrentTable);
                                dv.RowFilter = "BARRCODE='" + TxtBarcode.Text.Trim() + "'";
                                DataTable dtCurrentTableFilter = new DataTable();
                                dtCurrentTableFilter = dv.ToTable();
                                if (dtCurrentTableFilter.Rows.Count <= 0)
                                {
                                    dr = dtCurrentTable.NewRow();
                                    //dr = dtCurrentTable.Rows[dtCurrentTable.Rows.Count - 1];

                                    dr["BARRCODE"] = TxtBarcode.Text.Trim();
                                    dr["QTY"] = TxtQty.Text.Trim();
                                    dr["SCODE"] = "";
                                    dr["BAR_TRAN_DATE"] = HfBarTranDate.Value;
                                    dr["BAR_TRAN_NO"] = HfBarTranNo.Value;
                                    dr["BAR_SRNO"] = HfBarSrNo.Value;
                                    dtCurrentTable.Rows.Add(dr);
                                }
                            }
                        }
                    }
                    //*****//
                }
                else
                {
                    dtCurrentTable.Columns.Add("BARRCODE", typeof(System.String));
                    dtCurrentTable.Columns.Add("QTY", typeof(System.String));
                    dtCurrentTable.Columns.Add("SCODE", typeof(System.String));
                    dtCurrentTable.Columns.Add("BAR_TRAN_DATE", typeof(System.String));
                    dtCurrentTable.Columns.Add("BAR_TRAN_NO", typeof(System.String));
                    dtCurrentTable.Columns.Add("BAR_SRNO", typeof(System.String));

                    foreach (GridViewRow row in GvViewBarcode.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                            HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                            HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;

                            if (TxtBarcode.Text.Trim() != string.Empty)
                            {
                                dr = dtCurrentTable.NewRow();

                                dr["BARRCODE"] = TxtBarcode.Text.Trim();
                                dr["QTY"] = TxtQty.Text.Trim();
                                dr["SCODE"] = "";
                                dr["BAR_TRAN_DATE"] = HfBarTranDate.Value;
                                dr["BAR_TRAN_NO"] = HfBarTranNo.Value;
                                dr["BAR_SRNO"] = HfBarSrNo.Value;
                                dtCurrentTable.Rows.Add(dr);
                            }
                        }
                    }
                }





                dr = dtCurrentTable.NewRow();

                dr["BARRCODE"] = "";
                dr["QTY"] = "";
                dr["SCODE"] = "";
                dr["BAR_TRAN_DATE"] = "";
                dr["BAR_TRAN_NO"] = "";
                dr["BAR_SRNO"] = "";

                dtCurrentTable.Rows.Add(dr);

                ViewState["BarcodeTempNew"] = dtCurrentTable;

                GvViewBarcode.DataSource = dtCurrentTable;
                GvViewBarcode.DataBind();


                //}
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void BtnAddRowModelBarCode_ViewGrid_Click(object sender, EventArgs e)
        {
            AddNewRowBarcodeView();
        }


        #endregion


    }
}