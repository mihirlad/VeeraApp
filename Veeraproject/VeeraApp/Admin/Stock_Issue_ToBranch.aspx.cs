using MihirValid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class Stock_Issue_ToBranch : System.Web.UI.Page
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

                if (!IsPostBack == true)
                {

                    DivEntry.Visible = false;
                    DivView.Visible = true;
                    HfTranType.Value= "BI";
                    FillSTOCK_ISSUE_TOBRANCH_MasterGrid(Session["COMP_CODE"].ToString());
                    FillDdlCheckedPersonName();
                    FillDdlDeliveredPersonName();
                    SetInitialRow();
                    ViewState["BarcodeTemp"] = null;
                    ViewState["CurrentTable"] = null;
                    CalendarExtenderChallanDate.StartDate = Convert.ToDateTime(Session["FIN_YEAR"].ToString());
                    CalendarExtenderChallanDate.EndDate = Convert.ToDateTime(Session["FIN_YEAR_END"].ToString());
                    
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }

            if (Session["WORK_VIEWFLAG"].ToString() == "B")
            {          
                BtnAddBarcode.Visible = true;
                BtnViewBarcode.Visible = true;
                BtnReturnBarcode.Visible = true;
            }
            else if (Session["WORK_VIEWFLAG"].ToString() == "I")
            {
             
                BtnAddBarcode.Visible = false;
                BtnViewBarcode.Visible = false;
                BtnReturnBarcode.Visible = false;
            }
            else
            {

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


        public void FillDdlDeliveredPersonName()
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKER_MASDetialsCompanyWiseFor_DDL(Comp_Code);
                DdlDeliveredBy.DataSource = Dt;
                DdlDeliveredBy.DataValueField = "BCODE";
                DdlDeliveredBy.DataTextField = "BNAME";
                DdlDeliveredBy.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillDdlCheckedPersonName()
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKER_MASDetialsCompanyWiseFor_DDL(Comp_Code);
                DdlCheckedBy.DataSource = Dt;
                DdlCheckedBy.DataValueField = "BCODE";
                DdlCheckedBy.DataTextField = "BNAME";
                DdlCheckedBy.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillSTOCK_ISSUE_TOBRANCH_MasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = STK_IRMASLogicLayer.GetAllSTOCK_ISSUE_BRANCH_MASDetails(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()), HfTranType.Value.ToString());
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvStockIssueBranchMaster.DataSource = Dv.ToTable();
            GvStockIssueBranchMaster.DataBind();

            DtSearch = Dv.ToTable();

        }


        public void FillFromBranchOnUpdate(string Id)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BRANCH_MASLogicLayer.GetBranchDetailCompanyWiseFor_Ddl(Comp_Code);


                if (HfBranchCode.Value.ToString() != "0")
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BRANCH_CODE=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtFromBranch.Text = DtView.Rows[0]["BRANCH_NAME"].ToString();
                    HfBranchCode.Value = DtView.Rows[0]["BRANCH_CODE"].ToString();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillToBranchOnUpdate(string Id)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BRANCH_MASLogicLayer.GetBranchDetailCompanyWiseFor_Ddl(Comp_Code);


                if (HfToBranchCode.Value.ToString() != "0")
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BRANCH_CODE=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtToBranch.Text = DtView.Rows[0]["BRANCH_NAME"].ToString();
                    HfToBranchCode.Value = DtView.Rows[0]["BRANCH_CODE"].ToString();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ControllerEnable()
        {
            TxtChallanNo.Enabled = true;
            TxtChallanDate.Enabled = true;
            TxtFromBranch.Enabled = false;
            TxtToBranch.Enabled = true;
            DdlPartyType.Enabled = true;
            TxtRemark.Enabled = true;
            TxtTransportName.Enabled = true;
            TxtVehclieNo.Enabled = true;
            TxtLRDate.Enabled = true;
            TxtLRNumber.Enabled = true;
            DdlDeliveredBy.Enabled = true;
            DdlCheckedBy.Enabled = true;
            DdlGSTApplicable.Enabled = true;
            TxtInvoiveDate.Enabled = true;
            TxtInvoiveNo.Enabled = true;
            TxtEWayBillNo.Enabled = true;
            DdlReceivedFlag.Enabled = true;
            TxtReceivedBy.Enabled = true;
            TxtReceivedDate.Enabled = true;
            TxtDriverName.Enabled = true;
            TxtDriverAddress.Enabled = true;
            TxtMDLNo.Enabled = true;
            TxtMDLState.Enabled = true;
            TxtROamt.Enabled = true;
            TxtNetAmt.Enabled = true;
        }


        public void ControllerDisable()
        {
            TxtChallanNo.Enabled = false;
            TxtChallanDate.Enabled = false;
            TxtFromBranch.Enabled = false;
            TxtToBranch.Enabled = false;
            DdlPartyType.Enabled = false;
            TxtRemark.Enabled = false;
            TxtTransportName.Enabled = false;
            TxtVehclieNo.Enabled = false;
            TxtLRDate.Enabled = false;
            TxtLRNumber.Enabled = false;
            DdlDeliveredBy.Enabled = false;
            DdlCheckedBy.Enabled = false;
            DdlGSTApplicable.Enabled = false;
            TxtInvoiveDate.Enabled = false;
            TxtInvoiveNo.Enabled = false;
            TxtEWayBillNo.Enabled = false;
            DdlReceivedFlag.Enabled = false;
            TxtReceivedBy.Enabled = false;
            TxtReceivedDate.Enabled = false;
            TxtDriverName.Enabled = false;
            TxtDriverAddress.Enabled = false;
            TxtMDLNo.Enabled = false;
            TxtMDLState.Enabled = false;
            TxtROamt.Enabled = false;
            TxtNetAmt.Enabled = false;
        }

        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            ViewState["BarcodeTemp"] = null;
            ViewState["BarcodeTempNew"] = null;
            ViewState["CurrentTable"] = null;
            ViewState["CurrentTable_Ex"] = null;

            TxtChallanNo.Text = string.Empty;
            TxtChallanDate.Text = string.Empty;
            TxtFromBranch.Text = string.Empty;
            TxtToBranch.Text = string.Empty;
            DdlPartyType.SelectedIndex = 0;
            TxtRemark.Text = string.Empty;
            TxtTransportName.Text = string.Empty;
            TxtVehclieNo.Text = string.Empty;
            TxtLRDate.Text = string.Empty;
            TxtLRNumber.Text = string.Empty;
            DdlDeliveredBy.SelectedIndex = 0;
            DdlCheckedBy.SelectedIndex = 0;
            DdlGSTApplicable.SelectedValue = "N";
            TxtInvoiveDate.Text = string.Empty;
            TxtInvoiveNo.Text = string.Empty;
            TxtEWayBillNo.Text = string.Empty;
            DdlReceivedFlag.SelectedValue = "N";
            TxtReceivedBy.Text = string.Empty;
            TxtReceivedDate.Text = string.Empty;
            TxtDriverName.Text = string.Empty;
            TxtDriverAddress.Text = string.Empty;
            TxtMDLNo.Text = string.Empty;
            TxtMDLState.Text = string.Empty;
            TxtROamt.Text = string.Empty;
            TxtNetAmt.Text = string.Empty;

            SetInitialRow();
           // SetInitialRowBarcodeGrid();
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
                TxtFromBranch.Text = Session["BRANCH_NAME"].ToString();
                HfTranType.Value = "BI";
                TxtChallanDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                string CHA_NO = STK_IRMASLogicLayer.GetChal_NoSTOCK_IRMASDetailCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtChallanDate.Text.Trim()).ToString("yyyy-MM-dd"), HfTranType.Value) ;
                if (CHA_NO.Length <= 8)
                {
                    TxtChallanNo.Text = CHA_NO;
                }
                else
                {
                    TxtChallanNo.Text = string.Empty;
                }

                if (Session["WORK_VIEWFLAG"].ToString() == "B")
                {
                    
                    GvStockIssueDetails.Enabled = false;
                }
                else
                if (Session["WORK_VIEWFLAG"].ToString() == "I")
                {
                    
                    GvStockIssueDetails.Enabled = true;
                }
                else
                {

                }

                //  ViewState["CurrentTable"] = null;
                ViewState["BarcodeTemp"] = null;
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


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetBranchName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from BRANCH_MAS where COMP_CODE=@COMP_CODE and BRANCH_NAME like @BRANCH_NAME + '%'", con);
            cmd.Parameters.AddWithValue("@BRANCH_NAME", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> BranchName = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BranchName.Add(dt.Rows[i][2].ToString());
            }
            return BranchName;
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetTransporterName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from TRANSPORT_MAS where TNAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> TNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TNames.Add(dt.Rows[i][1].ToString());
            }
            return TNames;
        }



        public void FillNetAmount()
        {
            try
            {
              
                if (HfIssueDetailsGrid.Value == string.Empty)
                {
                    HfIssueDetailsGrid.Value = "0";
                }

                double GridmergeTotalAmt = Convert.ToDouble(ViewState["TOTAL_CurrentTable"]);


                double decimalpoints = Math.Abs(GridmergeTotalAmt - Math.Floor(GridmergeTotalAmt));
                if (decimalpoints > 0.5)
                {
                    double ro = 1 - decimalpoints;

                    TxtROamt.Text = Math.Round(ro, 2).ToString();

                    TxtNetAmt.Text = Convert.ToString(Convert.ToDouble(GridmergeTotalAmt) + ro);
                }

                else
                {

                    double ro = (1 - decimalpoints) - 1;

                    TxtROamt.Text = Math.Round(ro, 2).ToString();

                    TxtNetAmt.Text = Convert.ToString(Math.Floor(GridmergeTotalAmt));
                }
                UpdateTotalAmount.Update();

            }
            catch (Exception)
            {

                throw;
            }
        }


        #region TOATL CALCULATION OF FOOTER TEMPLATE IN GRID

        private double TotalQuantity()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockIssueDetails.Rows.Count; i++)
            {
                string total = (GvStockIssueDetails.Rows[i].FindControl("TxtQty") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockIssueDetails.Rows.Count; i++)
            {
                string total = (GvStockIssueDetails.Rows[i].FindControl("TxtAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalCGSTAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockIssueDetails.Rows.Count; i++)
            {
                string total = (GvStockIssueDetails.Rows[i].FindControl("TxtCGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalSGSTAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockIssueDetails.Rows.Count; i++)
            {
                string total = (GvStockIssueDetails.Rows[i].FindControl("TxtSGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalIGSTAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockIssueDetails.Rows.Count; i++)
            {
                string total = (GvStockIssueDetails.Rows[i].FindControl("TxtIGSTAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }

        private double TotalAllAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvStockIssueDetails.Rows.Count; i++)
            {
                string total = (GvStockIssueDetails.Rows[i].FindControl("TxtTotalAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }


        #endregion


        protected void BtnDriverDetails_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelDriverDetails", "ShowModelDriverDetails()", true);
        }

        protected void DdlGSTApplicable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DdlReceivedFlag_SelectedIndexChanged(object sender, EventArgs e)
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

                    dt.Columns.Add("BARCODE", typeof(System.String));
                    dt.Columns.Add("QTY", typeof(System.String));
                    dt.Columns.Add("SCODE", typeof(System.String));
                    dt.Columns.Add("BAR_TRAN_DATE", typeof(System.String));
                    dt.Columns.Add("BAR_TRAN_NO", typeof(System.String));
                    dt.Columns.Add("BAR_SRNO", typeof(System.String));
                    dt.Columns.Add("RATE", typeof(System.String));

                    for (int i = 0; i < 10; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["BARCODE"] = "";
                        dr["QTY"] = "";
                        dr["SCODE"] = "";
                        dr["BAR_TRAN_DATE"] = "";
                        dr["BAR_TRAN_NO"] = "";
                        dr["BAR_SRNO"] = "";
                        dr["RATE"] = "";
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


                dt.Columns.Add("BARCODE", typeof(System.String));
                dt.Columns.Add("QTY", typeof(System.String));
                dt.Columns.Add("SCODE", typeof(System.String));
                dt.Columns.Add("BAR_TRAN_DATE", typeof(System.String));
                dt.Columns.Add("BAR_TRAN_NO", typeof(System.String));
                dt.Columns.Add("BAR_SRNO", typeof(System.String));
                dt.Columns.Add("RATE", typeof(System.String));

                for (int i = 0; i < 10; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["BARCODE"] = "";
                    dr["QTY"] = "";
                    dr["SCODE"] = "";
                    dr["BAR_TRAN_DATE"] = "";
                    dr["BAR_TRAN_NO"] = "";
                    dr["BAR_SRNO"] = "";
                    dr["RATE"] = "";

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


        protected void TxtBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtQty = (TextBox)row.Cells[2].FindControl("TxtQty");

                TxtQty.Text = "1";
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnViewBarcode_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelViewBarcode", "ShowModelViewBarcode()", true);
            FillOnlyViewBarcodePopup();

            Button AddNewBracodeBtn = (Button)(GvViewBarcode.FooterRow.FindControl("BtnAddRowModelBarCode_ViewGrid"));

            btnAddBarcodeProcess.Visible = false;
            btnUploadBarcodeProcess.Visible = false;
            btnReturnBarcodeProcess.Visible = false;
            FileUpload1.Visible = false;
            AddNewBracodeBtn.Visible = false;

        }

        protected void BtnAddBarcode_Click(object sender, EventArgs e)
        {
            ViewState["BarcodeTempNew"] = null;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelViewBarcode", "ShowModelViewBarcode()", true);
            FillViewBarcodePopup(1);

            btnAddBarcodeProcess.Visible = true;
            btnUploadBarcodeProcess.Visible = true;
            btnReturnBarcodeProcess.Visible = false;
            FileUpload1.Visible = true;

        }

        protected void BtnReturnBarcode_Click(object sender, EventArgs e)
        {
            ViewState["BarcodeTempNew"] = null;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelViewBarcode", "ShowModelViewBarcode()", true);
            FillViewBarcodePopup(2);

            btnAddBarcodeProcess.Visible = false;
            btnUploadBarcodeProcess.Visible = false;
            btnReturnBarcodeProcess.Visible = true;
            FileUpload1.Visible = false;
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

        protected void btnAddBarcodeProcess_Click(object sender, EventArgs e)
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
                        HiddenField HfRate = row.FindControl("HfRate") as HiddenField;

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
                    DataTable DtBarcodeTemp = new DataTable();
                    if (ViewState["BarcodeTemp"] != null)
                    {
                        DtBarcodeTemp = (DataTable)ViewState["BarcodeTemp"];
                    }
                    else
                    {
                        DtBarcodeTemp.Columns.Add("BARCODE", typeof(string));
                        DtBarcodeTemp.Columns.Add("QTY", typeof(string));
                        DtBarcodeTemp.Columns.Add("SCODE", typeof(string));
                        DtBarcodeTemp.Columns.Add("BAR_TRAN_DATE", typeof(string));
                        DtBarcodeTemp.Columns.Add("BAR_TRAN_NO", typeof(string));
                        DtBarcodeTemp.Columns.Add("BAR_SRNO", typeof(string));
                        DtBarcodeTemp.Columns.Add("RATE", typeof(string));
                    }


                    foreach (GridViewRow row in GvViewBarcode.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                            HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                            HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;
                            HiddenField HfRate = row.FindControl("HfRate") as HiddenField;


                            DataTable DtBarcode = new DataTable();
                            DtBarcode = BARCODE_MASLogicLayer.GetBarcodeDetail_WiseBarcodeNo(TxtBarcode.Text.Trim());
                            DataView Dv = new DataView(DtBarcode);
                            Dv.RowFilter = "STATUSFlag='O'";
                            DataTable FilterBarcode = Dv.ToTable();


                            DataView DvBarcodeTemptable = new DataView(DtBarcodeTemp);
                            DvBarcodeTemptable.RowFilter = "BARCODE='" + TxtBarcode.Text.Trim() + "'";
                            DataTable DtBarcodeTempFiltertable = DvBarcodeTemptable.ToTable();

                            if (DtBarcodeTempFiltertable.Rows.Count <= 0)
                            {
                                if (FilterBarcode.Rows.Count > 0)
                                {
                                    HfBarTranNo.Value = FilterBarcode.Rows[0]["TRAN_NO"].ToString();
                                    HfBarTranDate.Value = FilterBarcode.Rows[0]["TRAN_DATE"].ToString();
                                    HfBarSrNo.Value = FilterBarcode.Rows[0]["SRNO"].ToString();
                                    HfRate.Value = FilterBarcode.Rows[0]["RATE"].ToString();

                                    #region Add Product INTO LIST AND CHECK IF EXIST

                                    DataTable table = new DataTable();
                                    DataRow dr = null;
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
                                            table.Columns.Add("REF_TRAN_DATE", typeof(string));
                                            table.Columns.Add("REF_TRAN_NO", typeof(string));
                                            table.Columns.Add("REF_SRNO", typeof(string));
                                            table.Columns.Add("SCODE", typeof(string));
                                            table.Columns.Add("QTY", typeof(string));
                                            table.Columns.Add("RATE", typeof(string));
                                            table.Columns.Add("AMT", typeof(string));
                                            table.Columns.Add("DIS_PER", typeof(string));
                                            table.Columns.Add("DIS_AMT", typeof(string));
                                            table.Columns.Add("G_AMT", typeof(string));
                                            table.Columns.Add("GST_RATE", typeof(string));
                                            table.Columns.Add("GST_AMT", typeof(string));
                                            table.Columns.Add("CGST_RATE", typeof(string));
                                            table.Columns.Add("CGST_AMT", typeof(string));
                                            table.Columns.Add("SGST_RATE", typeof(string));
                                            table.Columns.Add("SGST_AMT", typeof(string));
                                            table.Columns.Add("IGST_RATE", typeof(string));
                                            table.Columns.Add("IGST_AMT", typeof(string));
                                            table.Columns.Add("T_AMT", typeof(string));
                                            table.Columns.Add("STATUS", typeof(string));

                                        }
                                    }


                                    string HfAmountString = "";
                                    string CGST_AMTString = "";
                                    string SGST_AMTString = "";
                                    string HfGSTAmount = "";
                                    string IGST_AMTString = "";
                                    string T_AMTString = "";


                                    if (table.Rows.Count > 0)
                                    {
                                        DataView Dvtable = new DataView(table);
                                        Dvtable.RowFilter = "SCODE=" + FilterBarcode.Rows[0]["SCODE"].ToString();
                                        DataTable DtFilterTable = Dvtable.ToTable();
                                        if (DtFilterTable.Rows.Count > 0)
                                        {
                                            //Update Qty
                                            foreach (DataRow drlp in table.Rows) // search whole table
                                            {
                                                if (drlp["SCODE"].ToString() == FilterBarcode.Rows[0]["SCODE"].ToString())
                                                {
                                                    drlp["QTY"] = (Convert.ToDouble(drlp["QTY"]) + 1);

                                                    #region Calculation For Change Qty
                                                    if (FilterBarcode.Rows[0]["RATE"].ToString().Trim() != string.Empty)
                                                    {
                                                        HfAmountString = Convert.ToString(Convert.ToDouble(FilterBarcode.Rows[0]["RATE"].ToString().Trim()) * Convert.ToDouble(drlp["QTY"]));

                                                        if (DdlGSTApplicable.SelectedValue.ToString() == "Y")
                                                        {

                                                            if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                                                            {
                                                                CGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["CGST_RATE"].ToString())) / 100).ToString();
                                                                SGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["SGST_RATE"].ToString())) / 100).ToString();
                                                                HfGSTAmount = (Convert.ToDouble(CGST_AMTString.Trim()) + Convert.ToDouble(SGST_AMTString.Trim())).ToString();
                                                                double d;
                                                                d = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(CGST_AMTString)) + (Convert.ToDouble(SGST_AMTString)));
                                                                T_AMTString = Convert.ToString(d);

                                                            }
                                                            else if (DdlPartyType.SelectedValue.ToString() == "CST")
                                                            {
                                                                //HiddenField IGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");
                                                                //HiddenField IGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfIGSTAmount");

                                                                IGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["IGST_RATE"].ToString())) / 100).ToString();
                                                                HfGSTAmount = IGST_AMTString;
                                                                T_AMTString = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(IGST_AMTString))).ToString();
                                                            }

                                                        }
                                                        else
                                                        {
                                                            T_AMTString = HfAmountString;
                                                        }
                                                    }
                                                    #endregion


                                                    drlp["GST_AMT"] = HfGSTAmount;

                                                    drlp["CGST_AMT"] = CGST_AMTString;

                                                    drlp["SGST_AMT"] = SGST_AMTString;

                                                    drlp["IGST_AMT"] = IGST_AMTString;

                                                    drlp["AMT"] = HfAmountString;

                                                    drlp["T_AMT"] = T_AMTString;
                                                    break;
                                                }
                                            }




                                            dr = DtBarcodeTemp.NewRow();
                                            dr["BARCODE"] = TxtBarcode.Text.Trim();
                                            dr["QTY"] = "1";
                                            dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
                                            dr["BAR_TRAN_DATE"] = FilterBarcode.Rows[0]["TRAN_DATE"].ToString();
                                            dr["BAR_TRAN_NO"] = FilterBarcode.Rows[0]["TRAN_NO"].ToString();
                                            dr["BAR_SRNO"] = FilterBarcode.Rows[0]["SRNO"].ToString();
                                            dr["RATE"] = FilterBarcode.Rows[0]["RATE"].ToString();
                                            DtBarcodeTemp.Rows.Add(dr);
                                        }
                                        else
                                        {

                                            #region Calculation

                                            dr = table.NewRow();

                                            if (FilterBarcode.Rows[0]["RATE"].ToString().Trim() != string.Empty)
                                            {
                                                HfAmountString = Convert.ToString(Convert.ToDouble(FilterBarcode.Rows[0]["RATE"].ToString().Trim()) * Convert.ToDouble(1));

                                                if (DdlGSTApplicable.SelectedValue.ToString() == "Y")
                                                {


                                                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                                                    {
                                                        CGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["CGST_RATE"].ToString())) / 100).ToString();
                                                        SGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["SGST_RATE"].ToString())) / 100).ToString();
                                                        HfGSTAmount = (Convert.ToDouble(CGST_AMTString.Trim()) + Convert.ToDouble(SGST_AMTString.Trim())).ToString();
                                                        double d;
                                                        d = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(CGST_AMTString)) + (Convert.ToDouble(SGST_AMTString)));
                                                        T_AMTString = Convert.ToString(d);

                                                        dr["CGST_RATE"] = FilterBarcode.Rows[0]["CGST_RATE"].ToString();
                                                        dr["CGST_AMT"] = CGST_AMTString;
                                                        dr["SGST_RATE"] = FilterBarcode.Rows[0]["SGST_RATE"].ToString();
                                                        dr["SGST_AMT"] = SGST_AMTString;
                                                        dr["IGST_RATE"] = null;
                                                        dr["IGST_AMT"] = IGST_AMTString;
                                                    }
                                                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                                                    {
                                                        //HiddenField IGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");
                                                        //HiddenField IGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfIGSTAmount");

                                                        IGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["IGST_RATE"].ToString())) / 100).ToString();
                                                        HfGSTAmount = IGST_AMTString;
                                                        T_AMTString = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(IGST_AMTString))).ToString();

                                                       
                                                        dr["CGST_RATE"] = null;
                                                        dr["CGST_AMT"] = CGST_AMTString;
                                                        dr["SGST_RATE"] = null;
                                                        dr["SGST_AMT"] = SGST_AMTString;
                                                        dr["IGST_RATE"] = FilterBarcode.Rows[0]["IGST_RATE"].ToString();
                                                        dr["IGST_AMT"] = IGST_AMTString;
                                                    }

                                                    //dr["CGST_RATE"] = FilterBarcode.Rows[0]["CGST_RATE"].ToString();
                                                    //dr["CGST_AMT"] = CGST_AMTString;
                                                    //dr["SGST_RATE"] = FilterBarcode.Rows[0]["SGST_RATE"].ToString();
                                                    //dr["SGST_AMT"] = SGST_AMTString;
                                                    //dr["IGST_RATE"] = FilterBarcode.Rows[0]["IGST_RATE"].ToString();
                                                    //dr["IGST_AMT"] = IGST_AMTString;
                                                }
                                                else
                                                {
                                                    T_AMTString = HfAmountString ;

                                                    dr["GST_RATE"] = null;
                                                    dr["GST_AMT"] = null;
                                                    dr["CGST_RATE"] = null;
                                                    dr["CGST_AMT"] = null; 
                                                    dr["SGST_RATE"] = null;
                                                    dr["SGST_AMT"] = null;
                                                    dr["IGST_RATE"] = null;
                                                    dr["IGST_AMT"] = null;
                                                }
                                            }

                                            else
                                            {
                                                HfAmountString = Convert.ToString(Convert.ToDouble(0));
                                            }

                                            #endregion
                                            //Add New Row Product
                                           
                                            dr["COMP_CODE"] = 0;
                                            dr["TRAN_DATE"] = string.Empty;
                                            dr["TRAN_NO"] = string.Empty;
                                            dr["SRNO"] = string.Empty;
                                            dr["REF_TRAN_DATE"] = string.Empty;
                                            dr["REF_TRAN_NO"] = string.Empty;
                                            dr["REF_SRNO"] = string.Empty;
                                            dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
                                            dr["QTY"] = "1";
                                            dr["RATE"] = FilterBarcode.Rows[0]["RATE"].ToString();
                                            dr["AMT"] = HfAmountString;
                                            dr["DIS_PER"] = string.Empty;
                                            dr["DIS_AMT"] = string.Empty;
                                            dr["G_AMT"] = string.Empty;
                                            dr["GST_RATE"] = FilterBarcode.Rows[0]["GST_RATE"].ToString();
                                            dr["GST_AMT"] = HfGSTAmount;
                                           
                                            dr["T_AMT"] = T_AMTString;
                                            dr["STATUS"] = string.Empty;

                                            table.Rows.Add(dr);

                                            dr = DtBarcodeTemp.NewRow();
                                            dr["BARCODE"] = TxtBarcode.Text.Trim();
                                            dr["QTY"] = "1";
                                            dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
                                            dr["BAR_TRAN_DATE"] = FilterBarcode.Rows[0]["TRAN_DATE"].ToString();
                                            dr["BAR_TRAN_NO"] = FilterBarcode.Rows[0]["TRAN_NO"].ToString();
                                            dr["BAR_SRNO"] = FilterBarcode.Rows[0]["SRNO"].ToString();
                                            dr["RATE"] = FilterBarcode.Rows[0]["RATE"].ToString();
                                            DtBarcodeTemp.Rows.Add(dr);
                                        }

                                    }
                                    else
                                    {
                                        #region Calculation

                                        dr = table.NewRow();

                                        if (FilterBarcode.Rows[0]["RATE"].ToString().Trim() != string.Empty)
                                        {
                                            HfAmountString = Convert.ToString(Convert.ToDouble(FilterBarcode.Rows[0]["RATE"].ToString().Trim()) * Convert.ToDouble(1));

                                            if (DdlGSTApplicable.SelectedValue.ToString() == "Y")
                                            {


                                                if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                                                {
                                                    CGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["CGST_RATE"].ToString())) / 100).ToString();
                                                    SGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["SGST_RATE"].ToString())) / 100).ToString();
                                                    HfGSTAmount = (Convert.ToDouble(CGST_AMTString.Trim()) + Convert.ToDouble(SGST_AMTString.Trim())).ToString();
                                                    double d;
                                                    d = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(CGST_AMTString)) + (Convert.ToDouble(SGST_AMTString)));
                                                    T_AMTString = Convert.ToString(d);

                                                    dr["CGST_RATE"] = FilterBarcode.Rows[0]["CGST_RATE"].ToString();
                                                    dr["CGST_AMT"] = CGST_AMTString;
                                                    dr["SGST_RATE"] = FilterBarcode.Rows[0]["SGST_RATE"].ToString();
                                                    dr["SGST_AMT"] = SGST_AMTString;
                                                    dr["IGST_RATE"] = null;
                                                    dr["IGST_AMT"] = IGST_AMTString;
                                                }
                                                else if (DdlPartyType.SelectedValue.ToString() == "CST")
                                                {
                                                    //HiddenField IGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");
                                                    //HiddenField IGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfIGSTAmount");

                                                    IGST_AMTString = ((Convert.ToDouble(HfAmountString.Trim()) * Convert.ToDouble(FilterBarcode.Rows[0]["IGST_RATE"].ToString())) / 100).ToString();
                                                    HfGSTAmount = IGST_AMTString;
                                                    T_AMTString = ((Convert.ToDouble(HfAmountString.Trim())) + (Convert.ToDouble(IGST_AMTString))).ToString();


                                                    dr["CGST_RATE"] = null;
                                                    dr["CGST_AMT"] = CGST_AMTString;
                                                    dr["SGST_RATE"] = null;
                                                    dr["SGST_AMT"] = SGST_AMTString;
                                                    dr["IGST_RATE"] = FilterBarcode.Rows[0]["IGST_RATE"].ToString();
                                                    dr["IGST_AMT"] = IGST_AMTString;
                                                }

                                                //dr["CGST_RATE"] = FilterBarcode.Rows[0]["CGST_RATE"].ToString();
                                                //dr["CGST_AMT"] = CGST_AMTString;
                                                //dr["SGST_RATE"] = FilterBarcode.Rows[0]["SGST_RATE"].ToString();
                                                //dr["SGST_AMT"] = SGST_AMTString;
                                                //dr["IGST_RATE"] = FilterBarcode.Rows[0]["IGST_RATE"].ToString();
                                                //dr["IGST_AMT"] = IGST_AMTString;
                                            }
                                            else
                                            {
                                                T_AMTString = HfAmountString;

                                                dr["GST_RATE"] = null;
                                                dr["GST_AMT"] = null;
                                                dr["CGST_RATE"] = null;
                                                dr["CGST_AMT"] = null;
                                                dr["SGST_RATE"] = null;
                                                dr["SGST_AMT"] = null;
                                                dr["IGST_RATE"] = null;
                                                dr["IGST_AMT"] = null;
                                            }
                                        }

                                        else
                                        {
                                            HfAmountString = Convert.ToString(Convert.ToDouble(0));
                                        }

                                        #endregion

                                        //Add New Row Product
                                        dr = table.NewRow();
                                        dr["COMP_CODE"] = 0;
                                        dr["TRAN_DATE"] = string.Empty;
                                        dr["TRAN_NO"] = string.Empty;
                                        dr["SRNO"] = string.Empty;
                                        dr["REF_TRAN_DATE"] = string.Empty;
                                        dr["REF_TRAN_NO"] = string.Empty;
                                        dr["REF_SRNO"] = string.Empty;
                                        dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
                                        dr["QTY"] = "1";
                                        dr["RATE"] = FilterBarcode.Rows[0]["RATE"].ToString();
                                        dr["AMT"] = HfAmountString;
                                        dr["DIS_PER"] = string.Empty;
                                        dr["DIS_AMT"] = string.Empty;
                                        dr["G_AMT"] = string.Empty;
                                        dr["GST_RATE"] = FilterBarcode.Rows[0]["GST_RATE"].ToString();
                                        dr["GST_AMT"] = HfGSTAmount;
                                        dr["CGST_RATE"] = FilterBarcode.Rows[0]["CGST_RATE"].ToString();
                                        dr["CGST_AMT"] = CGST_AMTString;
                                        dr["SGST_RATE"] = FilterBarcode.Rows[0]["SGST_RATE"].ToString();
                                        dr["SGST_AMT"] = SGST_AMTString;
                                        dr["IGST_RATE"] = FilterBarcode.Rows[0]["IGST_RATE"].ToString();
                                        dr["IGST_AMT"] = IGST_AMTString;
                                        dr["T_AMT"] = T_AMTString;
                                        dr["STATUS"] = string.Empty;
                                        table.Rows.Add(dr);

                                        dr = DtBarcodeTemp.NewRow();
                                        dr["BARCODE"] = TxtBarcode.Text.Trim();
                                        dr["QTY"] = "1";
                                        dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
                                        dr["BAR_TRAN_DATE"] = FilterBarcode.Rows[0]["TRAN_DATE"].ToString();
                                        dr["BAR_TRAN_NO"] = FilterBarcode.Rows[0]["TRAN_NO"].ToString();
                                        dr["BAR_SRNO"] = FilterBarcode.Rows[0]["SRNO"].ToString();
                                        dr["RATE"] = FilterBarcode.Rows[0]["RATE"].ToString();


                                        DtBarcodeTemp.Rows.Add(dr);
                                    }

                                    ViewState["BarcodeTemp"] = DtBarcodeTemp;


                                    DataView DvFilterNull = new DataView(table);
                                    DvFilterNull.RowFilter = "SCODE<>0";
                                    DataTable DtFilterNull = DvFilterNull.ToTable();


                                    ViewState["CurrentTable"] = DtFilterNull;

                                    GvStockIssueDetails.DataSource = DtFilterNull;
                                    GvStockIssueDetails.DataBind();

                                    #endregion
                                }
                                else
                                {
                                    //alert                                 
                                    // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Barcode is not available..!!');", true);
                                    TxtBarcode.ForeColor = Color.Red;
                                }
                            }
                            else
                            {
                                TxtBarcode.ForeColor = Color.Red;
                            }
                        }
                    }

                    lblbarduperror.Text = string.Empty;
                }
                else
                {
                    lblbarduperror.Text = "Duplicate Barcode Found! Details:- " + dupbarcode.TrimEnd(',');
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void btnReturnBarcodeProcess_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBarcodeTemp = new DataTable();
                if (ViewState["BarcodeTemp"] != null)
                {
                    DtBarcodeTemp = (DataTable)ViewState["BarcodeTemp"];
                }

                if (DtBarcodeTemp.Rows.Count > 0)
                {
                    lblbarduperror.Text = string.Empty;
                    foreach (GridViewRow row in GvViewBarcode.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;

                            DataView DvBarcodeTemptable = new DataView(DtBarcodeTemp);
                            DvBarcodeTemptable.RowFilter = "BARCODE='" + TxtBarcode.Text.Trim() + "'";
                            DataTable DtBarcodeTempFiltertable = DvBarcodeTemptable.ToTable();



                            if (DtBarcodeTempFiltertable.Rows.Count > 0)
                            {
                                for (int i = DtBarcodeTemp.Rows.Count - 1; i >= 0; i--)
                                {
                                    DataRow drReturn = DtBarcodeTemp.Rows[i];

                                    if (drReturn["BARCODE"].ToString() == TxtBarcode.Text.Trim())
                                    {
                                        if (Convert.ToInt32(drReturn["QTY"]) == Convert.ToInt32(TxtQty.Text.Trim()))
                                        {
                                            drReturn.Delete();
                                        }
                                        else if (Convert.ToInt32(drReturn["QTY"].ToString()) > Convert.ToInt32(TxtQty.Text.Trim()))
                                        {
                                            drReturn["QTY"] = (Convert.ToInt32(drReturn["QTY"]) - Convert.ToInt32(TxtQty.Text.Trim()));
                                        }
                                        else
                                        {
                                            lblbarduperror.Text = "Return Qty more than issue Qty !";
                                        }
                                    }

                                }
                                DtBarcodeTemp.AcceptChanges();
                                ViewState["BarcodeTemp"] = DtBarcodeTemp;

                                #region Return Product INTO LIST AND CHECK IF EXIST

                                DataTable table = new DataTable();

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
                                        table.Columns.Add("REF_TRAN_DATE", typeof(string));
                                        table.Columns.Add("REF_TRAN_NO", typeof(string));
                                        table.Columns.Add("REF_SRNO", typeof(string));
                                        table.Columns.Add("SCODE", typeof(string));
                                        table.Columns.Add("QTY", typeof(string));
                                        table.Columns.Add("RATE", typeof(string));
                                        table.Columns.Add("AMT", typeof(string));
                                        table.Columns.Add("DIS_PER", typeof(string));
                                        table.Columns.Add("DIS_AMT", typeof(string));
                                        table.Columns.Add("G_AMT", typeof(string));
                                        table.Columns.Add("GST_RATE", typeof(string));
                                        table.Columns.Add("GST_AMT", typeof(string));
                                        table.Columns.Add("CGST_RATE", typeof(string));
                                        table.Columns.Add("CGST_AMT", typeof(string));
                                        table.Columns.Add("SGST_RATE", typeof(string));
                                        table.Columns.Add("SGST_AMT", typeof(string));
                                        table.Columns.Add("IGST_RATE", typeof(string));
                                        table.Columns.Add("IGST_AMT", typeof(string));
                                        table.Columns.Add("T_AMT", typeof(string));
                                        table.Columns.Add("STATUS", typeof(string));
                                    }
                                }



                                if (table.Rows.Count > 0)
                                {
                                    DataView Dvtable = new DataView(table);
                                    Dvtable.RowFilter = "SCODE=" + DtBarcodeTempFiltertable.Rows[0]["SCODE"].ToString();
                                    DataTable DtFilterTable = Dvtable.ToTable();
                                    if (DtFilterTable.Rows.Count > 0)
                                    {
                                        //Update Qty
                                        foreach (DataRow drlp in table.Rows) // search whole table
                                        {
                                            if (drlp["SCODE"].ToString() == DtBarcodeTempFiltertable.Rows[0]["SCODE"].ToString())
                                            {
                                                if ((Convert.ToDouble(drlp["QTY"]) - 1) == 0)
                                                {
                                                    drlp.Delete();
                                                }
                                                else
                                                {

                                                    drlp["QTY"] = (Convert.ToDouble(drlp["QTY"]) - 1);
                                                }
                                                break;
                                            }
                                        }

                                    }
                                }

                                ViewState["CurrentTable"] = table;



                                #endregion
                            }
                            else
                            {
                                TxtBarcode.ForeColor = Color.Red;
                            }





                        }
                    }
                    GvViewBarcode.DataSource = DtBarcodeTemp;
                    GvViewBarcode.DataBind();
                }
                else
                {
                    lblbarduperror.Text = "Barcode not exist";

                }
                GvStockIssueDetails.DataSource = (DataTable)ViewState["CurrentTable"];
                GvStockIssueDetails.DataBind();
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

        protected void AddNewRowBarcodeView()
        {
            try
            {

                DataTable dtCurrentTable = new DataTable();
                DataRow dr = null;
                if (ViewState["BarcodeTempNew"] != null)
                {
                    dtCurrentTable = (DataTable)ViewState["BarcodeTempNew"];
                }
                else
                {
                    dtCurrentTable.Columns.Add("BARCODE", typeof(System.String));
                    dtCurrentTable.Columns.Add("QTY", typeof(System.String));
                    dtCurrentTable.Columns.Add("SCODE", typeof(System.String));
                    dtCurrentTable.Columns.Add("BAR_TRAN_DATE", typeof(System.String));
                    dtCurrentTable.Columns.Add("BAR_TRAN_NO", typeof(System.String));
                    dtCurrentTable.Columns.Add("BAR_SRNO", typeof(System.String));
                    dtCurrentTable.Columns.Add("RATE", typeof(System.String));

                    foreach (GridViewRow row in GvViewBarcode.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                            HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                            HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;
                            HiddenField HfRate = row.FindControl("HfRate") as HiddenField;

                            if (TxtBarcode.Text.Trim() != string.Empty)
                            {
                                dr = dtCurrentTable.NewRow();

                                dr["BARRCODE"] = TxtBarcode.Text.Trim();
                                dr["QTY"] = TxtQty.Text.Trim();
                                dr["SCODE"] = "";
                                dr["BAR_TRAN_DATE"] = HfBarTranDate.Value;
                                dr["BAR_TRAN_NO"] = HfBarTranNo.Value;
                                dr["BAR_SRNO"] = HfBarSrNo.Value;
                                dr["RATE"] = HfRate.Value;
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
                dr["RATE"] = "";

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


        #endregion


        #region  IMPORT EXCEL DATA TO GRIDVIEW

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
                    DtBarcodeTemp.Columns.Add("BARCODE", typeof(string));
                    DtBarcodeTemp.Columns.Add("QTY", typeof(string));
                    DtBarcodeTemp.Columns.Add("SCODE", typeof(string));
                    DtBarcodeTemp.Columns.Add("BAR_TRAN_DATE", typeof(string));
                    DtBarcodeTemp.Columns.Add("BAR_TRAN_NO", typeof(string));
                    DtBarcodeTemp.Columns.Add("BAR_SRNO", typeof(string));
                    DtBarcodeTemp.Columns.Add("RATE", typeof(string));

                    DataRow dr = null;

                    for (int i = 0; i < DtCust.Rows.Count; i++)
                    {
                        dr = DtBarcodeTemp.NewRow();
                        dr["BARCODE"] = DtCust.Rows[i]["BARCODE"].ToString();
                        dr["QTY"] = "1";
                        dr["SCODE"] = string.Empty;
                        dr["BAR_TRAN_DATE"] = string.Empty;
                        dr["BAR_TRAN_NO"] = string.Empty;
                        dr["BAR_SRNO"] = string.Empty;
                        dr["RATE"] = string.Empty;
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


        #endregion



        #region ISSUE ITEMS DETAILS INTO GRID

        private void SetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("REF_TRAN_DATE", typeof(string));
            table.Columns.Add("REF_TRAN_NO", typeof(string));
            table.Columns.Add("REF_SRNO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("RATE", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("DIS_PER", typeof(string));
            table.Columns.Add("DIS_AMT", typeof(string));
            table.Columns.Add("G_AMT", typeof(string));
            table.Columns.Add("GST_RATE", typeof(string));
            table.Columns.Add("GST_AMT", typeof(string));
            table.Columns.Add("CGST_RATE", typeof(string));
            table.Columns.Add("CGST_AMT", typeof(string));
            table.Columns.Add("SGST_RATE", typeof(string));
            table.Columns.Add("SGST_AMT", typeof(string));
            table.Columns.Add("IGST_RATE", typeof(string));
            table.Columns.Add("IGST_AMT", typeof(string));
            table.Columns.Add("T_AMT", typeof(string));
            table.Columns.Add("STATUS", typeof(string));



            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["REF_TRAN_DATE"] = string.Empty;
            dr["REF_TRAN_NO"] = string.Empty;
            dr["REF_SRNO"] = string.Empty;
            dr["SCODE"] = "0";
            dr["QTY"] = "0";
            dr["RATE"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["DIS_PER"] = string.Empty;
            dr["DIS_AMT"] = string.Empty;
            dr["G_AMT"] = string.Empty;
            dr["GST_RATE"] = string.Empty;
            dr["GST_AMT"] = string.Empty;
            dr["CGST_RATE"] = string.Empty;
            dr["CGST_AMT"] = string.Empty;
            dr["SGST_RATE"] = string.Empty;
            dr["SGST_AMT"] = string.Empty;
            dr["IGST_RATE"] = string.Empty;
            dr["IGST_AMT"] = string.Empty;
            dr["T_AMT"] = string.Empty;
            dr["STATUS"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvStockIssueDetails.DataSource = table;
            GvStockIssueDetails.DataBind();
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

                        Label lblSumTotalQty = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSumTotalQty"));
                        Label lblSumAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSumAmount"));
                        Label lblCGSTSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                        Label lblSGSTSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                        Label lblIGSTSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                        Label lblSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSumTotalAmount"));

                      
                        HiddenField HfDetailSCode = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");

                        HiddenField HfRefTranDate = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfRefTranDate");
                        HiddenField HfRefTranNo = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfRefTranNo");
                        HiddenField HfRefSrNo = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfRefSrNo");
                        HiddenField HfStatus = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfStatus");

                        HiddenField HfDisRate = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfDisRate");
                        HiddenField HfDisAmount = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                        HiddenField HfGSTAmount = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfGSTRate = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");

                        TextBox TxtProductCode = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[1].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductName");
                        TextBox TxtQty = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[3].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[4].FindControl("TxtRate");
                        TextBox TxtAmount = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[5].FindControl("TxtAmount");
                        TextBox TxtCGSTRate = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[6].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[7].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[8].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[9].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[10].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[11].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[12].FindControl("TxtTotalAmount");


                        //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();


                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = TxtAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["DIS_PER"] = HfDisRate.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["DIS_AMT"] = HfDisAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["GST_RATE"] = HfGSTRate.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["CGST_RATE"] = TxtCGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["CGST_AMT"] = TxtCGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SGST_RATE"] = TxtSGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SGST_AMT"] = TxtSGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["IGST_RATE"] = TxtIGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["IGST_AMT"] = TxtIGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["T_AMT"] = TxtTotalAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["STATUS"] = HfStatus.Value.Trim();

                        rowIndex++;

                        double lblTotalQuantity = TotalQuantity();
                        lblSumTotalQty.Text = lblTotalQuantity.ToString();

                        double lblAmount = TotalAmount();
                        lblSumAmount.Text = lblAmount.ToString();

                        double lblTotCGSTAmt = TotalCGSTAmount();
                        lblCGSTSumTotalAmount.Text = lblTotCGSTAmt.ToString();

                        double lblTotSGSTAmt = TotalSGSTAmount();
                        lblSGSTSumTotalAmount.Text = lblTotSGSTAmt.ToString();

                        double lblTotIGSTAmt = TotalIGSTAmount();
                        lblIGSTSumTotalAmount.Text = lblTotIGSTAmt.ToString();

                        double lblTotAmount = TotalAllAmount();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();

                        if (lblSumTotalAmount.Text == string.Empty)
                        {
                            lblSumTotalAmount.Text = "0";
                            HfIssueDetailsGrid.Value = "0";

                        }
                        else
                        {
                            ViewState["TOTAL_CurrentTable"] = lblSumTotalAmount.Text.Trim();

                        }

                        FillNetAmount();

                    }

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["SCODE"] = "0";
                    drCurrentRow["QTY"] = "0";
                    drCurrentRow["RATE"] = "0";
                    drCurrentRow["AMT"] = "0";
                    drCurrentRow["DIS_PER"] = "0";
                    drCurrentRow["DIS_AMT"] = "0";
                    drCurrentRow["GST_RATE"] = "0";
                    drCurrentRow["GST_AMT"] = "0";
                    drCurrentRow["CGST_RATE"] = "0";
                    drCurrentRow["CGST_AMT"] = "0";
                    drCurrentRow["SGST_RATE"] = "0";
                    drCurrentRow["SGST_AMT"] = "0";
                    drCurrentRow["IGST_RATE"] = "";
                    drCurrentRow["IGST_AMT"] = "0";
                    drCurrentRow["T_AMT"] = "0";
                    drCurrentRow["STATUS"] = "";

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvStockIssueDetails.DataSource = dtCurrentTable;
                    GvStockIssueDetails.DataBind();


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


                        Label lblSumTotalQty = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSumTotalQty"));
                        Label lblSumAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSumAmount"));
                        Label lblCGSTSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                        Label lblSGSTSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                        Label lblIGSTSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                        Label lblSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSumTotalAmount"));


                        HiddenField HfDetailSCode = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");

                        HiddenField HfRefTranDate = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfRefTranDate");
                        HiddenField HfRefTranNo = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfRefTranNo");
                        HiddenField HfRefSrNo = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfRefSrNo");
                        HiddenField HfStatus = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfStatus");

                        HiddenField HfDisRate = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfDisRate");
                        HiddenField HfDisAmount = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                        HiddenField HfGSTAmount = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfGSTRate = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");

                        TextBox TxtProductCode = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[1].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductName");
                        TextBox TxtQty = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[3].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[4].FindControl("TxtRate");
                        TextBox TxtAmount = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[5].FindControl("TxtAmount");
                        TextBox TxtCGSTRate = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[6].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[7].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[8].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[9].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[10].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[11].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[12].FindControl("TxtTotalAmount");



                        //TxtSrNo.Text = dt.Rows[i]["SRNO"].ToString();
                        HfDetailSCode.Value = dt.Rows[i]["SCODE"].ToString();
                        TxtQty.Text = dt.Rows[i]["QTY"].ToString();
                        TxtRate.Text = dt.Rows[i]["RATE"].ToString();
                        TxtAmount.Text = dt.Rows[i]["AMT"].ToString();
                        HfDisRate.Value = dt.Rows[i]["DIS_PER"].ToString();
                        HfDisAmount.Value = dt.Rows[i]["DIS_AMT"].ToString();
                        HfGSTRate.Value = dt.Rows[i]["GST_RATE"].ToString();
                        HfGSTAmount.Value = dt.Rows[i]["GST_AMT"].ToString();
                        TxtCGSTRate.Text = dt.Rows[i]["CGST_RATE"].ToString();
                        TxtCGSTAmount.Text = dt.Rows[i]["CGST_AMT"].ToString();
                        TxtSGSTRate.Text = dt.Rows[i]["SGST_RATE"].ToString();
                        TxtSGSTAmount.Text = dt.Rows[i]["SGST_AMT"].ToString();
                        TxtIGSTRate.Text = dt.Rows[i]["IGST_RATE"].ToString();
                        TxtIGSTAmount.Text = dt.Rows[i]["IGST_AMT"].ToString();
                        TxtTotalAmount.Text = dt.Rows[i]["T_AMT"].ToString();
                        HfStatus.Value = dt.Rows[i]["STATUS"].ToString();


                        rowIndex++;

                        double lblTotalQuantity = TotalQuantity();
                        lblSumTotalQty.Text = lblTotalQuantity.ToString();

                        double lblAmount = TotalAmount();
                        lblSumAmount.Text = lblAmount.ToString();

                        double lblTotCGSTAmt = TotalCGSTAmount();
                        lblCGSTSumTotalAmount.Text = lblTotCGSTAmt.ToString();

                        double lblTotSGSTAmt = TotalSGSTAmount();
                        lblSGSTSumTotalAmount.Text = lblTotSGSTAmt.ToString();

                        double lblTotIGSTAmt = TotalIGSTAmount();
                        lblIGSTSumTotalAmount.Text = lblTotIGSTAmt.ToString();

                        double lblTotAmount = TotalAllAmount();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();

                        if (lblSumTotalAmount.Text == string.Empty)
                        {
                            lblSumTotalAmount.Text = "0";
                            HfIssueDetailsGrid.Value = "0";

                        }
                        else
                        {
                            ViewState["TOTAL_CurrentTable"] = lblSumTotalAmount.Text.Trim();

                        }

                        FillNetAmount();

                    }
                }
            }
        }

        protected void BtnDeleteRowModelIssueItemGrid_Click(object sender, EventArgs e)
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
                GvStockIssueDetails.DataSource = dt;
                GvStockIssueDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }

        protected void BtnAddRowModelIssueItemGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        #endregion


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

        public void FillOnGridDetailChanged()
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

                        Label lblSumTotalQty = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSumTotalQty"));
                        Label lblSumAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSumAmount"));
                        Label lblCGSTSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                        Label lblSGSTSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                        Label lblIGSTSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                        Label lblSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSumTotalAmount"));


                        HiddenField HfDetailSCode = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");

                        HiddenField HfRefTranDate = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfRefTranDate");
                        HiddenField HfRefTranNo = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfRefTranNo");
                        HiddenField HfRefSrNo = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfRefSrNo");
                        HiddenField HfStatus = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfStatus");

                        HiddenField HfDisRate = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfDisRate");
                        HiddenField HfDisAmount = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");
                        HiddenField HfGSTAmount = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfGSTRate = (HiddenField)GvStockIssueDetails.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");

                        TextBox TxtProductCode = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[1].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductName");
                        TextBox TxtQty = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[3].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[4].FindControl("TxtRate");
                        TextBox TxtAmount = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[5].FindControl("TxtAmount");
                        TextBox TxtCGSTRate = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[6].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[7].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[8].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[9].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[10].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[11].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvStockIssueDetails.Rows[rowIndex].Cells[12].FindControl("TxtTotalAmount");


                        //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();


                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = TxtAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["DIS_PER"] = HfDisRate.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["DIS_AMT"] = HfDisAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["GST_RATE"] = HfGSTRate.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["CGST_RATE"] = TxtCGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["CGST_AMT"] = TxtCGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SGST_RATE"] = TxtSGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SGST_AMT"] = TxtSGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["IGST_RATE"] = TxtIGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["IGST_AMT"] = TxtIGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["T_AMT"] = TxtTotalAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["STATUS"] = HfStatus.Value.Trim();

                        rowIndex++;
                    }
                }
            }

                        #endregion
        }

        protected void TxtProductCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtProductName = (TextBox)row.Cells[1].FindControl("TxtProductName");
                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");
                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");

                TextBox TxtRateString = (TextBox)row.Cells[4].FindControl("TxtRate");
                TextBox TxtAmountString = (TextBox)row.Cells[5].FindControl("TxtAmount");

                TextBox TxtCGSTRateString = (TextBox)row.Cells[6].FindControl("TxtCGSTRate");
                TextBox TxtCGSTAmountString = (TextBox)row.Cells[7].FindControl("TxtCGSTAmount");
                TextBox TxtSGSTRateString = (TextBox)row.Cells[8].FindControl("TxtSGSTRate");
                TextBox TxtSGSTAmountString = (TextBox)row.Cells[9].FindControl("TxtSGSTAmount");
                TextBox TxtIGSTRateString = (TextBox)row.Cells[10].FindControl("TxtIGSTRate");
                TextBox TxtIGSTAmountString = (TextBox)row.Cells[11].FindControl("TxtIGSTAmount");

                TextBox TxtTotalAmountString = (TextBox)row.Cells[12].FindControl("TxtTotalAmount");

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
                       
                        TxtProductName.Text = DtView.Rows[0]["SNAME"].ToString();
                        HfDetailSCode.Value = DtView.Rows[0]["SCODE"].ToString();
                        FillOnGridDetailChanged();

                        if (txt.Text != string.Empty && DdlPartyType.SelectedIndex != 0)
                        {
                            DataTable DsStock = STOCK_MASLogicLayer.STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(HfDetailSCode.Value), DdlPartyType.SelectedValue);
                            if (DsStock.Rows.Count > 0)
                            {
                                TxtRateString.Text = DsStock.Rows[0]["SAL_RATE"].ToString();
                                HfGSTRate.Value = DsStock.Rows[0]["GST_RATE"].ToString();
                                TxtCGSTRateString.Text = DsStock.Rows[0]["CGST_RATE"].ToString();
                                TxtSGSTRateString.Text = DsStock.Rows[0]["SGST_RATE"].ToString();
                                TxtIGSTRateString.Text = DsStock.Rows[0]["IGST_RATE"].ToString();
                            }
                            else
                            {
                                TxtRateString.Text = "0";
                                HfGSTRate.Value = "0";
                                TxtCGSTRateString.Text = "0";
                                TxtSGSTRateString.Text = "0";
                                TxtIGSTRateString.Text = "0";


                            }
                        }
                        else
                        {
                            TxtRateString.Text = "0";
                            HfGSTRate.Value = "0";
                            TxtCGSTRateString.Text = "0";
                            TxtSGSTRateString.Text = "0";
                            TxtIGSTRateString.Text = "0";


                        }




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

                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");
                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");

                TextBox TxtRateString = (TextBox)row.Cells[4].FindControl("TxtRate");
                TextBox TxtAmountString = (TextBox)row.Cells[5].FindControl("TxtAmount");

                TextBox TxtCGSTRateString = (TextBox)row.Cells[6].FindControl("TxtCGSTRate");
                TextBox TxtCGSTAmountString = (TextBox)row.Cells[7].FindControl("TxtCGSTAmount");
                TextBox TxtSGSTRateString = (TextBox)row.Cells[8].FindControl("TxtSGSTRate");
                TextBox TxtSGSTAmountString = (TextBox)row.Cells[9].FindControl("TxtSGSTAmount");
                TextBox TxtIGSTRateString = (TextBox)row.Cells[10].FindControl("TxtIGSTRate");
                TextBox TxtIGSTAmountString = (TextBox)row.Cells[11].FindControl("TxtIGSTAmount");

                TextBox TxtTotalAmountString = (TextBox)row.Cells[12].FindControl("TxtTotalAmount");

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
                        TxtProductCode.Text = DtView.Rows[0]["PROD_CODE"].ToString();
                        HfDetailSCode.Value = DtView.Rows[0]["SCODE"].ToString();
                        FillOnGridDetailChanged();

                        if (txt.Text != string.Empty && DdlPartyType.SelectedIndex != 0)
                        {
                            DataTable DsStock = STOCK_MASLogicLayer.STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(HfDetailSCode.Value), DdlPartyType.SelectedValue);
                            if (DsStock.Rows.Count > 0)
                            {
                                TxtRateString.Text = DsStock.Rows[0]["SAL_RATE"].ToString();
                                HfGSTRate.Value = DsStock.Rows[0]["GST_RATE"].ToString();
                                TxtCGSTRateString.Text = DsStock.Rows[0]["CGST_RATE"].ToString();
                                TxtSGSTRateString.Text = DsStock.Rows[0]["SGST_RATE"].ToString();
                                TxtIGSTRateString.Text = DsStock.Rows[0]["IGST_RATE"].ToString();
                            }
                            else
                            {
                                TxtRateString.Text = "0";
                                HfGSTRate.Value = "0";
                                TxtCGSTRateString.Text = "0";
                                TxtSGSTRateString.Text = "0";
                                TxtIGSTRateString.Text = "0";


                            }
                        }
                        else
                        {
                            TxtRateString.Text = "0";
                            HfGSTRate.Value = "0";
                            TxtCGSTRateString.Text = "0";
                            TxtSGSTRateString.Text = "0";
                            TxtIGSTRateString.Text = "0";


                        }
                    }
                }
           }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvStockIssueDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvStockIssueDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GvStockIssueDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    TextBox TxtProductName = (e.Row.FindControl("TxtProductName") as TextBox);
                    TextBox TxtProductCode = (e.Row.FindControl("TxtProductCode") as TextBox);
                    TextBox TxtQty = (e.Row.FindControl("TxtQty") as TextBox);
                    HiddenField HfDetailSCode = (e.Row.FindControl("HfDetailSCode") as HiddenField);

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
                    Label lblSumTotalQty = (Label)e.Row.FindControl("lblSumTotalQty");
                    Label lblSumAmount = (Label)e.Row.FindControl("lblSumAmount");
                    Label lblCGSTSumTotalAmount = (Label)e.Row.FindControl("lblCGSTSumTotalAmount");
                    Label lblSGSTSumTotalAmount = (Label)e.Row.FindControl("lblSGSTSumTotalAmount");
                    Label lblIGSTSumTotalAmount = (Label)e.Row.FindControl("lblIGSTSumTotalAmount");
                    Label lblSumTotalAmount = (Label)e.Row.FindControl("lblSumTotalAmount");

                    double lblTotalQuantity = TotalQuantity();
                    lblSumTotalQty.Text = lblTotalQuantity.ToString();

                    double lblAmount = TotalAmount();
                    lblSumAmount.Text = lblAmount.ToString();

                    double lblTotCGSTAmt = TotalCGSTAmount();
                    lblCGSTSumTotalAmount.Text = lblTotCGSTAmt.ToString();

                    double lblTotSGSTAmt = TotalSGSTAmount();
                    lblSGSTSumTotalAmount.Text = lblTotSGSTAmt.ToString();

                    double lblTotIGSTAmt = TotalIGSTAmount();
                    lblIGSTSumTotalAmount.Text = lblTotIGSTAmt.ToString();

                    double lblTotAmount = TotalAllAmount();
                    lblSumTotalAmount.Text = lblTotAmount.ToString();


                    if (lblSumTotalAmount.Text == string.Empty)
                    {
                        lblSumTotalAmount.Text = "0";
                        HfIssueDetailsGrid.Value = "0";

                    }
                    else
                    {
                        ViewState["TOTAL_CurrentTable"] = lblSumTotalAmount.Text.Trim();
                     
                    }

                    FillNetAmount();


                }


                if (Session["WORK_VIEWFLAG"].ToString() == "B")
                {
                    GvStockIssueDetails.Columns[13].Visible = false;
                    GvStockIssueDetails.Enabled = false;
                }
                else
                if(Session["WORK_VIEWFLAG"].ToString() == "I")
                {
                    GvStockIssueDetails.Columns[13].Visible = true;
                    GvStockIssueDetails.Enabled = true;
                }
                else
                {

                }

            

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
                    #region INSERT STOCK ISSUE TO BRANCH MASTER

                    STK_IRMASLogicLayer insert = new STK_IRMASLogicLayer();

                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                    //insert.TRAN_DATE = HfTranDate.Value.Trim();
                    //insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.TRAN_TYPE = HfTranType.Value.Trim().ToUpper();
                    insert.TO_BRANCH_CODE = HfToBranchCode.Value.Trim();
                    insert.CHA_NO = TxtChallanNo.Text.Trim();
                    insert.CHA_DT = Convert.ToDateTime(TxtChallanDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    insert.SERIALNO = "0";
                    insert.VEHICLE_NO = TxtVehclieNo.Text.Trim().ToUpper();
                    insert.TCODE = "0";
                    insert.TRANSPORT = TxtTransportName.Text.Trim().ToUpper();
                    insert.LR_NO = TxtLRNumber.Text.Trim().ToUpper();
                    if (TxtLRDate.Text == string.Empty)
                    {
                        insert.LR_DATE = "";
                    }
                    else
                    {
                        insert.LR_DATE = Convert.ToDateTime(TxtLRDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    insert.DRIVER_NAME = TxtDriverName.Text.Trim().ToUpper();
                    insert.DRIVER_ADD = TxtDriverAddress.Text.Trim().ToUpper();
                    insert.MDLNO = TxtMDLNo.Text.Trim().ToUpper();
                    insert.MDLSTATE = TxtMDLState.Text.Trim().ToUpper();
                    insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                    insert.FORM_SRNO = "0";
                    insert.CHECKPOST_NAME = "";
                    insert.TOT_QTY = "0";
                    insert.TOT_AMT = "0";
                    insert.ENDT = "";
                    insert.STATUS = "";
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_DATE = "";
                    //insert.REF_TRAN_DATE = "";
                    //insert.REF_TRAN_NO = "0";
                    insert.ISS_FLAG = "";
                    insert.REC_FLAG = DdlReceivedFlag.SelectedValue.Trim().ToUpper();
                    insert.REC_USERID = TxtReceivedBy.Text.Trim().ToUpper();
                    insert.REC_DATE = "";
                    insert.BCODE = DdlDeliveredBy.SelectedValue.Trim();
                    insert.CHK_FLAG = "";
                    insert.CHK_DATE = "";
                    insert.CHK_USERID = "";
                    insert.CHK_BCODE = DdlCheckedBy.SelectedValue.Trim().ToUpper();
                    insert.GST_APP_FLAG = DdlGSTApplicable.SelectedValue.Trim().ToUpper();
                    insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToUpper();

                    if (TxtInvoiveNo.Text == string.Empty)
                    {
                        insert.INV_NUMBER = "0";
                    }
                    else
                    {
                        insert.INV_NUMBER = TxtInvoiveNo.Text.Trim().ToUpper();
                    }

                    if (TxtInvoiveDate.Text == string.Empty)
                    {
                        insert.INV_DT = "";
                    }
                    else
                    {
                        insert.INV_DT = Convert.ToDateTime(TxtInvoiveDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }

                    insert.EWAY_BILLNO = TxtEWayBillNo.Text.Trim().ToUpper();
                    insert.GST_RATE = null;
                    insert.GST_AMT = null;
                    insert.CGST_RATE = null;
                    insert.CGST_AMT = null;
                    insert.SGST_RATE = null;
                    insert.SGST_AMT = null;
                    insert.IGST_RATE = null;
                    insert.IGST_AMT = null;
                    insert.RO_AMT = TxtROamt.Text.Trim();
                    insert.NET_AMT = TxtNetAmt.Text.Trim();
                    insert.TO_BRANCH_ACODE = null;

                    #endregion

                    #region INSERT STOCK ISSUE ITEMS IN GRID

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int SRNODETAIL = 1;
                    foreach (GridViewRow row in GvStockIssueDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {

                            HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                            HiddenField HfRefTranDate = row.FindControl("HfRefTranDate") as HiddenField;
                            HiddenField HfRefTranNo = row.FindControl("HfRefTranNo") as HiddenField;
                            HiddenField HfRefSrNo = row.FindControl("HfRefSrNo") as HiddenField;

                            HiddenField HfDisRate = row.FindControl("HfDisRate") as HiddenField;
                            HiddenField HfDisAmount = row.FindControl("HfDisAmount") as HiddenField;

                            HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;
                            HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                            HiddenField HfGrossAmount = row.FindControl("HfGrossAmount") as HiddenField;
                            HiddenField HfStatus = row.FindControl("HfStatus") as HiddenField;

                            TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtAmount = row.FindControl("TxtAmount") as TextBox;
                            TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                            TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                            TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                            TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                            TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                            TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                            TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;


                            if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != null)
                            {


                                XmlElement HandleDetail2 = XDoc1.CreateElement("STK_IRDETDetails");
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

                                //if (HfRefTranDate.Value == string.Empty)
                                //{
                                //    HandleDetail2.SetAttribute("REF_TRAN_DATE", (""));
                                //}
                                //else
                                //{
                                //    HandleDetail2.SetAttribute("REF_TRAN_DATE", (Convert.ToDateTime(HfRefTranDate.Value).ToString("MM-dd-yyyy")));
                                //}

                                //if (HfRefTranNo.Value == string.Empty)
                                //{
                                //    HandleDetail2.SetAttribute("REF_TRAN_NO", ("0"));
                                //}
                                //else
                                //{
                                //    HandleDetail2.SetAttribute("REF_TRAN_NO", (HfRefTranNo.Value.Trim()));
                                //}

                              
                                HandleDetail2.SetAttribute("REF_SRNO", (SRNODETAIL.ToString()));
                               
                                if (TxtQty.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("QTY", (TxtQty.Text.Trim()));
                                }

                                if (TxtRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("RATE", (TxtRate.Text.Trim()));
                                }

                                if (TxtAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("AMT", (TxtAmount.Text.Trim()));
                                }

                                if (HfGSTRate.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("GST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("GST_RATE", (HfGSTRate.Value.Trim()));
                                }

                                if (HfGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("GST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("GST_AMT", (HfGSTAmount.Value.Trim()));
                                }

                                if (TxtCGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CGST_RATE", (TxtCGSTRate.Text.Trim()));
                                }

                                if (TxtCGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text.Trim()));
                                }

                                if (TxtSGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SGST_RATE", (TxtSGSTRate.Text.Trim()));
                                }

                                if (TxtSGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text.Trim()));
                                }

                                if (TxtIGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("IGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("IGST_RATE", (TxtIGSTRate.Text.Trim()));
                                }

                                if (TxtIGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("IGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text.Trim()));
                                }

                                if (TxtTotalAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("T_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("T_AMT", (TxtTotalAmount.Text.Trim()));
                                }

                                HandleDetail2.SetAttribute("STATUS", (""));


                                root1.AppendChild(HandleDetail2);
                                SRNODETAIL++;

                            }
                        }
                    }

                    #endregion


                    #region INSERT STOCK_IRMAS_BARCODE

                    XmlDocument XDoc2 = new XmlDocument();
                    XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                    XDoc2.AppendChild(dec2);// Create the root element
                    XmlElement root2 = XDoc2.CreateElement("root");
                    XDoc2.AppendChild(root2);
                    int SRNOBARCODE = 1;
                    double TotalAmt;
                    foreach (GridViewRow row in GvViewBarcode.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfStockcode = row.FindControl("HfStockcode") as HiddenField;
                            HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                            HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                            HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;
                            TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            HiddenField HfRate = row.FindControl("HfRate") as HiddenField;


                            XmlElement HandleDetail3 = XDoc2.CreateElement("BarcodeDetails");

                            if (TxtBarcode.Text != string.Empty && TxtBarcode.Text != null)
                            {
                                HandleDetail3.SetAttribute("SRNO", SRNOBARCODE.ToString());
                                HandleDetail3.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //    HandleDetail4.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //    HandleDetail4.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());


                                HandleDetail3.SetAttribute("BAR_TRAN_DATE", Convert.ToDateTime(HfBarTranDate.Value).ToString("MM-dd-yyyy"));


                                if (HfBarTranNo.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("BAR_TRAN_NO", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("BAR_TRAN_NO", (HfBarTranNo.Value));
                                }


                                if (HfBarSrNo.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("BAR_SRNO", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("BAR_SRNO", (HfBarSrNo.Value));
                                }

                                if (TxtQty.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("QTY", (TxtQty.Text));
                                }

                                if (HfRate.Value == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("RATE", (HfRate.Value));
                                }

                                TotalAmt = Convert.ToDouble(TxtQty.Text.Trim()) * Convert.ToDouble(HfRate.Value.Trim());

                                if (TotalAmt.ToString() == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("AMT", (TotalAmt.ToString()));
                                }

                                root2.AppendChild(HandleDetail3);
                                SRNOBARCODE++;

                            }
                        }
                    }
                    #endregion

                    string str = STK_IRMASLogicLayer.InsertSTOCK_ISSUE_BRANCH_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"), HfTranType.Value.ToString());

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "STOCK ISSUE BRANCH MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillSTOCK_ISSUE_TOBRANCH_MasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "STOCK ISSUE BRANCH MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : STOCK ISSUE BRANCH MASTER NOT SAVED";
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

        protected void GvStockIssueBranchMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvStockIssueBranchMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ViewState["BarcodeTemp"] = null;
                ViewState["CurrentTable"] = null;

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


                        DataSet ds = STK_IRMASLogicLayer.GetAllIDWiseSTOCK_ISSUE_BRANCH_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtBarcode = ds.Tables[2];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            FillFromBranchOnUpdate(dt.Rows[0]["BRANCH_CODE"].ToString());
                            FillToBranchOnUpdate(dt.Rows[0]["TO_BRANCH_CODE"].ToString());
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfRef_TranDate.Value = dt.Rows[0]["REF_TRAN_DATE"].ToString();
                            HfRef_TranNo.Value = dt.Rows[0]["REF_TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtChallanNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            TxtChallanDate.Text = Convert.ToDateTime(dt.Rows[0]["CHA_DT"].ToString()).ToString("dd-MM-yyyy");
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtDriverName.Text = dt.Rows[0]["DRIVER_NAME"].ToString();
                            TxtDriverAddress.Text = dt.Rows[0]["DRIVER_ADD"].ToString();
                            TxtMDLNo.Text = dt.Rows[0]["MDLNO"].ToString();
                            TxtMDLState.Text = dt.Rows[0]["MDLSTATE"].ToString();
                            TxtLRDate.Text = dt.Rows[0]["LR_DATE"].ToString();
                            TxtLRNumber.Text = dt.Rows[0]["LR_NO"].ToString();
                            DdlCheckedBy.SelectedValue = dt.Rows[0]["CHK_BCODE"].ToString();
                            DdlDeliveredBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            DdlGSTApplicable.SelectedValue = dt.Rows[0]["GST_APP_FLAG"].ToString();
                            TxtInvoiveNo.Text = dt.Rows[0]["INV_NUMBER"].ToString();
                            TxtInvoiveDate.Text = dt.Rows[0]["INV_DT"].ToString();
                            TxtEWayBillNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            DdlReceivedFlag.SelectedValue = dt.Rows[0]["REC_FLAG"].ToString();
                            TxtReceivedDate.Text = dt.Rows[0]["REC_DATE"].ToString();
                            TxtReceivedBy.Text = dt.Rows[0]["REC_USERID"].ToString();
                            TxtROamt.Text = dt.Rows[0]["RO_AMT"].ToString();
                            TxtNetAmt.Text = dt.Rows[0]["NET_AMT"].ToString();

                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value.ToString();
                            Session["TRAN_TYPE"] = HfTranType.Value.ToString();


                            if (DtDetails.Rows.Count > 0)
                            {
                                GvStockIssueDetails.DataSource = DtDetails;
                                GvStockIssueDetails.DataBind();
                                GvStockIssueDetails.Enabled = false;
                            }

                            if (DtBarcode.Rows.Count > 0)
                            {
                                ViewState["BarcodeTemp"] = DtBarcode;
                                GvViewBarcode.DataSource = DtBarcode;
                                GvViewBarcode.DataBind();
                            }

                            btnSave.Visible = false;
                            btnDelete.Visible = true;
                            Btncalldel.Visible = true;
                            BtncallUpd.Visible = false;
                            BtnAddBarcode.Enabled = false;
                            BtnViewBarcode.Enabled = true;
                            BtnReturnBarcode.Enabled = false;
                            GvStockIssueDetails.Enabled = false;
                            ControllerDisable();

                            #endregion
                        }
                    }
                }


                if (e.CommandName == "Edita")
                    {
                        #region EDIT
                        //     clear();

                        int id = int.Parse(e.CommandArgument.ToString());

                        Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = STK_IRMASLogicLayer.GetAllIDWiseSTOCK_ISSUE_BRANCH_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtBarcode = ds.Tables[2];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            FillFromBranchOnUpdate(dt.Rows[0]["BRANCH_CODE"].ToString());
                            FillToBranchOnUpdate(dt.Rows[0]["TO_BRANCH_CODE"].ToString());
                            HfRef_TranDate.Value = dt.Rows[0]["REF_TRAN_DATE"].ToString();
                            HfRef_TranNo.Value = dt.Rows[0]["REF_TRAN_NO"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtChallanNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            TxtChallanDate.Text = Convert.ToDateTime(dt.Rows[0]["CHA_DT"].ToString()).ToString("dd-MM-yyyy");
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtDriverName.Text = dt.Rows[0]["DRIVER_NAME"].ToString();
                            TxtDriverAddress.Text = dt.Rows[0]["DRIVER_ADD"].ToString();
                            TxtMDLNo.Text = dt.Rows[0]["MDLNO"].ToString();
                            TxtMDLState.Text = dt.Rows[0]["MDLSTATE"].ToString();
                            TxtLRDate.Text = dt.Rows[0]["LR_DATE"].ToString();
                            TxtLRNumber.Text = dt.Rows[0]["LR_NO"].ToString();
                            DdlCheckedBy.SelectedValue = dt.Rows[0]["CHK_BCODE"].ToString();
                            DdlDeliveredBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            DdlGSTApplicable.SelectedValue = dt.Rows[0]["GST_APP_FLAG"].ToString();
                            TxtInvoiveNo.Text = dt.Rows[0]["INV_NUMBER"].ToString();
                            TxtInvoiveDate.Text = dt.Rows[0]["INV_DT"].ToString();
                            TxtEWayBillNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            DdlReceivedFlag.SelectedValue = dt.Rows[0]["REC_FLAG"].ToString();
                            TxtReceivedDate.Text = dt.Rows[0]["REC_DATE"].ToString();
                            TxtReceivedBy.Text = dt.Rows[0]["REC_USERID"].ToString();
                            TxtROamt.Text = dt.Rows[0]["RO_AMT"].ToString();
                            TxtNetAmt.Text = dt.Rows[0]["NET_AMT"].ToString();

                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value.ToString();
                            Session["TRAN_TYPE"] = HfTranType.Value.ToString();

                            if (DtDetails.Rows.Count > 0)
                            {

                                #region Assign to Table

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
                                        table.Columns.Add("REF_TRAN_DATE", typeof(string));
                                        table.Columns.Add("REF_TRAN_NO", typeof(string));
                                        table.Columns.Add("REF_SRNO", typeof(string));
                                        table.Columns.Add("SCODE", typeof(string));
                                        table.Columns.Add("QTY", typeof(string));
                                        table.Columns.Add("RATE", typeof(string));
                                        table.Columns.Add("AMT", typeof(string));
                                        table.Columns.Add("DIS_PER", typeof(string));
                                        table.Columns.Add("DIS_AMT", typeof(string));
                                        table.Columns.Add("G_AMT", typeof(string));
                                        table.Columns.Add("GST_RATE", typeof(string));
                                        table.Columns.Add("GST_AMT", typeof(string));
                                        table.Columns.Add("CGST_RATE", typeof(string));
                                        table.Columns.Add("CGST_AMT", typeof(string));
                                        table.Columns.Add("SGST_RATE", typeof(string));
                                        table.Columns.Add("SGST_AMT", typeof(string));
                                        table.Columns.Add("IGST_RATE", typeof(string));
                                        table.Columns.Add("IGST_AMT", typeof(string));
                                        table.Columns.Add("T_AMT", typeof(string));
                                        table.Columns.Add("STATUS", typeof(string));
                                    }
                                }

                                for (int m = 0; m < DtDetails.Rows.Count; m++)
                                {
                                    drm = table.NewRow();
                                    drm["COMP_CODE"] = DtDetails.Rows[m]["COMP_CODE"].ToString();
                                    drm["TRAN_DATE"] = DtDetails.Rows[m]["TRAN_DATE"].ToString();
                                    drm["TRAN_NO"] = DtDetails.Rows[m]["TRAN_NO"].ToString();
                                    drm["SRNO"] = DtDetails.Rows[m]["SRNO"].ToString();
                                    drm["REF_TRAN_DATE"] = DtDetails.Rows[m]["REF_TRAN_DATE"].ToString();
                                    drm["REF_TRAN_NO"] = DtDetails.Rows[m]["REF_TRAN_NO"].ToString();
                                    drm["REF_SRNO"] = DtDetails.Rows[m]["REF_SRNO"].ToString();
                                    drm["SCODE"] = DtDetails.Rows[m]["SCODE"].ToString();
                                    drm["QTY"] = DtDetails.Rows[m]["QTY"].ToString();
                                    drm["RATE"] = DtDetails.Rows[m]["RATE"].ToString();
                                    drm["AMT"] = DtDetails.Rows[m]["AMT"].ToString();
                                    drm["DIS_PER"] = DtDetails.Rows[m]["DIS_PER"].ToString();
                                    drm["DIS_AMT"] = DtDetails.Rows[m]["DIS_AMT"].ToString();
                                    drm["G_AMT"] = DtDetails.Rows[m]["G_AMT"].ToString();
                                    drm["GST_RATE"] = DtDetails.Rows[m]["GST_RATE"].ToString();
                                    drm["GST_AMT"] = DtDetails.Rows[m]["GST_AMT"].ToString();
                                    drm["CGST_RATE"] = DtDetails.Rows[m]["CGST_RATE"].ToString();
                                    drm["CGST_AMT"] = DtDetails.Rows[m]["CGST_AMT"].ToString();
                                    drm["SGST_RATE"] = DtDetails.Rows[m]["SGST_RATE"].ToString();
                                    drm["SGST_AMT"] = DtDetails.Rows[m]["SGST_AMT"].ToString();
                                    drm["IGST_RATE"] = DtDetails.Rows[m]["IGST_RATE"].ToString();
                                    drm["IGST_AMT"] = DtDetails.Rows[m]["IGST_AMT"].ToString();
                                    drm["T_AMT"] = DtDetails.Rows[m]["T_AMT"].ToString();
                                    drm["STATUS"] = DtDetails.Rows[m]["STATUS"].ToString();
                                    table.Rows.Add(drm);

                                }

                                #endregion

                                ViewState["CurrentTable"] = table;
                                GvStockIssueDetails.DataSource = DtDetails;
                                GvStockIssueDetails.DataBind();
                                GvStockIssueDetails.Enabled = true;
                            }

                            if (DtBarcode.Rows.Count > 0)
                            {
                                ViewState["BarcodeTemp"] = DtBarcode;
                                GvViewBarcode.DataSource = DtBarcode;
                                GvViewBarcode.DataBind();
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
                BtnAddBarcode.Enabled = true;
                BtnViewBarcode.Enabled = true;
                BtnReturnBarcode.Enabled = true;
                GvStockIssueDetails.Enabled = true;
                }

                if (e.CommandName == "Viewa")
                {
                    #region  SET TEXT ON VIEW

                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = STK_IRMASLogicLayer.GetAllIDWiseSTOCK_ISSUE_BRANCH_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtBarcode = ds.Tables[2];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            FillFromBranchOnUpdate(dt.Rows[0]["BRANCH_CODE"].ToString());
                            FillToBranchOnUpdate(dt.Rows[0]["TO_BRANCH_CODE"].ToString());
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfRef_TranDate.Value = dt.Rows[0]["REF_TRAN_DATE"].ToString();
                            HfRef_TranNo.Value = dt.Rows[0]["REF_TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtChallanNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            TxtChallanDate.Text = Convert.ToDateTime(dt.Rows[0]["CHA_DT"].ToString()).ToString("dd-MM-yyyy");
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtDriverName.Text = dt.Rows[0]["DRIVER_NAME"].ToString();
                            TxtDriverAddress.Text = dt.Rows[0]["DRIVER_ADD"].ToString();
                            TxtMDLNo.Text = dt.Rows[0]["MDLNO"].ToString();
                            TxtMDLState.Text = dt.Rows[0]["MDLSTATE"].ToString();
                            TxtLRDate.Text = dt.Rows[0]["LR_DATE"].ToString();
                            TxtLRNumber.Text = dt.Rows[0]["LR_NO"].ToString();
                            DdlCheckedBy.SelectedValue = dt.Rows[0]["CHK_BCODE"].ToString();
                            DdlDeliveredBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            DdlGSTApplicable.SelectedValue = dt.Rows[0]["GST_APP_FLAG"].ToString();
                            TxtInvoiveNo.Text = dt.Rows[0]["INV_NUMBER"].ToString();
                            TxtInvoiveDate.Text = dt.Rows[0]["INV_DT"].ToString();
                            TxtEWayBillNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            DdlReceivedFlag.SelectedValue = dt.Rows[0]["REC_FLAG"].ToString();
                            TxtReceivedDate.Text = dt.Rows[0]["REC_DATE"].ToString();
                            TxtReceivedBy.Text = dt.Rows[0]["REC_USERID"].ToString();
                            TxtROamt.Text = dt.Rows[0]["RO_AMT"].ToString();
                            TxtNetAmt.Text = dt.Rows[0]["NET_AMT"].ToString();

                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value.ToString();
                            Session["TRAN_TYPE"] = HfTranType.Value.ToString();


                            if (DtDetails.Rows.Count > 0)
                            {
                                GvStockIssueDetails.DataSource = DtDetails;
                                GvStockIssueDetails.DataBind();
                                GvStockIssueDetails.Enabled = false;
                            }

                            if (DtBarcode.Rows.Count > 0)
                            {
                                ViewState["BarcodeTemp"] = DtBarcode;
                                GvViewBarcode.DataSource = DtBarcode;
                                GvViewBarcode.DataBind();
                            }
                        }
                    }
               

                #endregion
                ControllerDisable();
                btnSave.Visible = false;
                Btncalldel.Visible = false;
                BtncallUpd.Visible = false;
                BtnAddBarcode.Enabled = false;
                BtnViewBarcode.Enabled = true;
                BtnReturnBarcode.Enabled = false;
                GvStockIssueDetails.Enabled = false;
                UserRights();
              }
            }
            catch (Exception ex)
            {

                lblmsg.Text = ex.Message.ToString();
            }
        }

        protected void GvStockIssueBranchMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btnedit = (e.Row.FindControl("btnEdit") as Button);
                    Button btndelete = (e.Row.FindControl("btnDelete") as Button);
                    Label lblRecFlag = (e.Row.FindControl("lblReceivedFlag") as Label);

                    HiddenField hfREC_UPD = (e.Row.FindControl("hfREC_UPD") as HiddenField);
                    HiddenField hfREC_DEL = (e.Row.FindControl("hfREC_DEL") as HiddenField);
                    HiddenField hfREC_INS = (e.Row.FindControl("hfREC_INS") as HiddenField);


                    if (hfREC_INS.Value.ToString() == "Y")
                    {
                        BtnAdd.Enabled = true;
                    }
                    else
                    {
                        BtnAdd.Enabled = false;
                    }

                    if (hfREC_UPD.Value.ToString() == "Y")
                    {


                        if (lblRecFlag.Text == "YES")
                        {
                            if (Session["USERTYPE"].ToString() == "A")
                            {
                                btnedit.Enabled = true;

                            }
                            else
                            {
                                btnedit.Enabled = false;

                            }
                        }
                    }

                    if (hfREC_DEL.Value.ToString() == "Y")
                    {


                        if (lblRecFlag.Text == "YES")
                        {
                            if (Session["USERTYPE"].ToString() == "A")
                            {

                                btndelete.Enabled = true;
                            }
                            else
                            {

                                btndelete.Enabled = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Response.AppendToLog(ex.ToString());
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE 

                if (HfTranNo.Value != string.Empty && HfTranDate.Value != string.Empty)
                {
                    string str = STK_IRMASLogicLayer.DeleteSTOCK_ISSUE_TO_BRANCHDetailsByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value.ToString()));
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
                        lblmsg.Text = "Error:Stock Issue to Branch Master Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                   FillSTOCK_ISSUE_TOBRANCH_MasterGrid(Session["COMP_CODE"].ToString());
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
                #region UPDATE STOCK ISSUE TO BRANCH MASTER

                #region INSERT STOCK ISSUE TO BRANCH MASTER

                STK_IRMASLogicLayer insert = new STK_IRMASLogicLayer();

                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.BRANCH_CODE = HfBranchCode.Value.Trim();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.TRAN_TYPE = HfTranType.Value.Trim().ToUpper();
                insert.TO_BRANCH_CODE = HfToBranchCode.Value.Trim();
                insert.CHA_NO = TxtChallanNo.Text.Trim();
                insert.CHA_DT = Convert.ToDateTime(TxtChallanDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                insert.SERIALNO = "0";
                insert.VEHICLE_NO = TxtVehclieNo.Text.Trim().ToUpper();
                insert.TCODE = "0";
                insert.TRANSPORT = TxtTransportName.Text.Trim().ToUpper();
                insert.LR_NO = TxtLRNumber.Text.Trim().ToUpper();
                if (TxtLRDate.Text == string.Empty)
                {
                    insert.LR_DATE = "";
                }
                else
                {
                    insert.LR_DATE = Convert.ToDateTime(TxtLRDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                insert.DRIVER_NAME = TxtDriverName.Text.Trim().ToUpper();
                insert.DRIVER_ADD = TxtDriverAddress.Text.Trim().ToUpper();
                insert.MDLNO = TxtMDLNo.Text.Trim().ToUpper();
                insert.MDLSTATE = TxtMDLState.Text.Trim().ToUpper();
                insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                insert.FORM_SRNO = "0";
                insert.CHECKPOST_NAME = "";
                insert.TOT_QTY = "0";
                insert.TOT_AMT = "0";
                insert.ENDT = "";
                insert.STATUS = "";
                //insert.INS_USERID = Session["USERNAME"].ToString();
                //insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_DATE = "";
                insert.REF_TRAN_DATE = Convert.ToDateTime(HfRef_TranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.REF_TRAN_NO = HfRef_TranNo.Value.Trim();
                insert.ISS_FLAG = "";
                insert.REC_FLAG = DdlReceivedFlag.SelectedValue.Trim().ToUpper();
                insert.REC_USERID = TxtReceivedBy.Text.Trim().ToUpper();
                insert.REC_DATE = "";
                insert.BCODE = DdlDeliveredBy.SelectedValue.Trim();
                insert.CHK_FLAG = "";
                insert.CHK_DATE = "";
                insert.CHK_USERID = "";
                insert.CHK_BCODE = DdlCheckedBy.SelectedValue.Trim().ToUpper();
                insert.GST_APP_FLAG = DdlGSTApplicable.SelectedValue.Trim().ToUpper();
                insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToUpper();

                if (TxtInvoiveNo.Text == string.Empty)
                {
                    insert.INV_NUMBER = "0";
                }
                else
                {
                    insert.INV_NUMBER = TxtInvoiveNo.Text.Trim().ToUpper();
                }

                if (TxtInvoiveDate.Text == string.Empty)
                {
                    insert.INV_DT = "";
                }
                else
                {
                    insert.INV_DT = Convert.ToDateTime(TxtInvoiveDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }

                insert.EWAY_BILLNO = TxtEWayBillNo.Text.Trim().ToUpper();
                insert.GST_RATE = null;
                insert.GST_AMT = null;
                insert.CGST_RATE = null;
                insert.CGST_AMT = null;
                insert.SGST_RATE = null;
                insert.SGST_AMT = null;
                insert.IGST_RATE = null;
                insert.IGST_AMT = null;
                insert.RO_AMT = TxtROamt.Text.Trim();
                insert.NET_AMT = TxtNetAmt.Text.Trim();
                insert.TO_BRANCH_ACODE = null;

                #endregion

                #region INSERT STOCK ISSUE ITEMS IN GRID

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);
                int SRNODETAIL = 1;
                foreach (GridViewRow row in GvStockIssueDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                        HiddenField HfRefTranDate = row.FindControl("HfRefTranDate") as HiddenField;
                        HiddenField HfRefTranNo = row.FindControl("HfRefTranNo") as HiddenField;
                        HiddenField HfRefSrNo = row.FindControl("HfRefSrNo") as HiddenField;

                        HiddenField HfDisRate = row.FindControl("HfDisRate") as HiddenField;
                        HiddenField HfDisAmount = row.FindControl("HfDisAmount") as HiddenField;

                        HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;
                        HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                        HiddenField HfGrossAmount = row.FindControl("HfGrossAmount") as HiddenField;
                        HiddenField HfStatus = row.FindControl("HfStatus") as HiddenField;

                        TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                        TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                        TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                        TextBox TxtAmount = row.FindControl("TxtAmount") as TextBox;
                        TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                        TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                        TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                        TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                        TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                        TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                        TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;


                        if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != null)
                        {


                            XmlElement HandleDetail2 = XDoc1.CreateElement("STK_IRDETDetails");
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

                            if (HfRefTranDate.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("REF_TRAN_DATE", (""));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("REF_TRAN_DATE", (Convert.ToDateTime(HfRefTranDate.Value).ToString("MM-dd-yyyy")));
                            }

                            if (HfRefTranNo.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("REF_TRAN_NO", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("REF_TRAN_NO", (HfRefTranNo.Value.Trim()));
                            }

                            if (HfRefSrNo.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("REF_SRNO", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("REF_SRNO", (SRNODETAIL.ToString()));
                            }

                            if (TxtQty.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("QTY", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("QTY", (TxtQty.Text.Trim()));
                            }

                            if (TxtRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("RATE", (TxtRate.Text.Trim()));
                            }

                            if (TxtAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("AMT", (TxtAmount.Text.Trim()));
                            }

                            if (HfGSTRate.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("GST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("GST_RATE", (HfGSTRate.Value.Trim()));
                            }

                            if (HfGSTAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("GST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("GST_AMT", (HfGSTAmount.Value.Trim()));
                            }

                            if (TxtCGSTRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("CGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("CGST_RATE", (TxtCGSTRate.Text.Trim()));
                            }

                            if (TxtCGSTAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("CGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text.Trim()));
                            }

                            if (TxtSGSTRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("SGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("SGST_RATE", (TxtSGSTRate.Text.Trim()));
                            }

                            if (TxtSGSTAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("SGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text.Trim()));
                            }

                            if (TxtIGSTRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("IGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("IGST_RATE", (TxtIGSTRate.Text.Trim()));
                            }

                            if (TxtIGSTAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("IGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text.Trim()));
                            }

                            if (TxtTotalAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("T_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("T_AMT", (TxtTotalAmount.Text.Trim()));
                            }

                            HandleDetail2.SetAttribute("STATUS", (""));


                            root1.AppendChild(HandleDetail2);
                            SRNODETAIL++;

                        }
                    }
                }

                #endregion


                #region 

                XmlDocument XDoc2 = new XmlDocument();
                XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                XDoc2.AppendChild(dec2);// Create the root element
                XmlElement root2 = XDoc2.CreateElement("root");
                XDoc2.AppendChild(root2);
                int SRNOBARCODE = 1;
                double TotalAmt;

             
                            foreach (GridViewRow row in GvViewBarcode.Rows)
                            {
                                if (row.RowType == DataControlRowType.DataRow)
                                {
                                    HiddenField HfStockcode = row.FindControl("HfStockcode") as HiddenField;
                                    HiddenField HfBarTranNo = row.FindControl("HfBarTranNo") as HiddenField;
                                    HiddenField HfBarTranDate = row.FindControl("HfBarTranDate") as HiddenField;
                                    HiddenField HfBarSrNo = row.FindControl("HfBarSrNo") as HiddenField;
                                    TextBox TxtBarcode = row.FindControl("TxtBarcode") as TextBox;
                                    TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                                    HiddenField HfRate = row.FindControl("HfRate") as HiddenField;


                                     XmlElement HandleDetail3 = XDoc2.CreateElement("BarcodeDetails");

                                    if (TxtBarcode.Text != string.Empty && TxtBarcode.Text != null)
                                    {
                                        HandleDetail3.SetAttribute("SRNO", SRNOBARCODE.ToString());
                                        HandleDetail3.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                        HandleDetail3.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                        HandleDetail3.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());


                                        HandleDetail3.SetAttribute("BAR_TRAN_DATE", Convert.ToDateTime(HfBarTranDate.Value).ToString("MM-dd-yyyy"));


                                        if (HfBarTranNo.Value == string.Empty)
                                        {
                                            HandleDetail3.SetAttribute("BAR_TRAN_NO", ("0"));
                                        }
                                        else
                                        {
                                            HandleDetail3.SetAttribute("BAR_TRAN_NO", (HfBarTranNo.Value));
                                        }


                                        if (HfBarSrNo.Value == string.Empty)
                                        {
                                            HandleDetail3.SetAttribute("BAR_SRNO", ("0"));
                                        }
                                        else
                                        {
                                            HandleDetail3.SetAttribute("BAR_SRNO", (HfBarSrNo.Value));
                                        }

                                        if (TxtQty.Text == string.Empty)
                                        {
                                            HandleDetail3.SetAttribute("QTY", ("0"));
                                        }
                                        else
                                        {
                                            HandleDetail3.SetAttribute("QTY", (TxtQty.Text));
                                        }

                                        if (HfRate.Value == string.Empty)
                                        {
                                            HandleDetail3.SetAttribute("RATE", ("0"));
                                        }
                                        else
                                        {
                                            HandleDetail3.SetAttribute("RATE", (HfRate.Value));
                                        }

                                        TotalAmt = Convert.ToDouble(TxtQty.Text.Trim()) * Convert.ToDouble(HfRate.Value.Trim());

                                        if (TotalAmt.ToString() == string.Empty)
                                        {
                                            HandleDetail3.SetAttribute("AMT", ("0"));
                                        }
                                        else
                                        {
                                            HandleDetail3.SetAttribute("AMT", (TotalAmt.ToString()));
                                        }

                                        root2.AppendChild(HandleDetail3);
                                        SRNOBARCODE++;


                              
                        }
                    }
                }
                #endregion

                string str = STK_IRMASLogicLayer.UpdateSTOCK_ISSUE_BRANCH_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml), HfCompCode.Value, HfBranchCode.Value, Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"), HfTranType.Value.ToString(), Session["WORK_VIEWFLAG"].ToString());

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "STOCK ISSUE TO BRANCH MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillSTOCK_ISSUE_TOBRANCH_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "STOCK ISSUE TO BRANCH MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : STOCK ISSUE TO BRANCH MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }


                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnViewInvioce_Click(object sender, EventArgs e)
        {

        }

        protected void BtnViewChallan_Click(object sender, EventArgs e)
        {
            // Response.Redirect("~/reportviewPages/StockIssuetoBranchPrint.aspx");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../reportviewPages/StockIssuetoBranchPrint.aspx', '_blank');", true);
        }

        protected void TxtToBranch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select BRANCH_CODE from BRANCH_MAS where BRANCH_NAME = '" + TxtToBranch.Text + "' and COMP_CODE = " + Session["COMP_CODE"].ToString(), con);
                int x = Convert.ToInt32(cmd.ExecuteScalar());
                if (x == 0)
                {
                    TxtToBranch.BackColor = Color.Red;
                }
                else
                {
                    HfToBranchCode.Value = cmd.ExecuteScalar().ToString();
                    TxtToBranch.BackColor = Color.White; con.Close();


                }

                DataTable Dt = new DataTable();
                Dt = STK_IRMASLogicLayer.GetPartytypeGSTApplicableBranchWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), HfToBranchCode.Value.ToString(), Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()));

                DdlPartyType.SelectedValue = Dt.Rows[0]["PartyType"].ToString();
                DdlGSTApplicable.SelectedValue = Dt.Rows[0]["GstApplicableFlag"].ToString();
                DdlPartyType.Enabled = false;
                DdlGSTApplicable.Enabled = false;

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
                    Dv.RowFilter = "CHA_NO like '%" + TxtSearch.Text.Trim() + "%' OR FromBranchName like '%" + TxtSearch.Text.Trim() + "%'  OR ToBranchName like '%" + TxtSearch.Text.Trim() + "%'  OR DeliverPersonName Like '" + TxtSearch.Text.Trim() + "' ";
                    GvStockIssueBranchMaster.DataSource = Dv.ToTable();
                    GvStockIssueBranchMaster.DataBind();
                }
                else
                {
                    GvStockIssueBranchMaster.DataSource = DtSearch;
                    GvStockIssueBranchMaster.DataBind();
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

                if (validation.InToNumber(txt.Text.Trim()))
                {


                    Label lblSumTotalQty = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSumTotalQty"));
                    Label lblSumAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSumAmount"));
                    Label lblCGSTSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                    Label lblSGSTSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                    Label lblIGSTSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                    Label lblSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSumTotalAmount"));

                    HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");
                    HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");

                    TextBox TxtRateString = (TextBox)row.Cells[4].FindControl("TxtRate");
                    TextBox TxtAmountString = (TextBox)row.Cells[5].FindControl("TxtAmount");

                    TextBox TxtCGSTRateString = (TextBox)row.Cells[6].FindControl("TxtCGSTRate");
                    TextBox TxtCGSTAmountString = (TextBox)row.Cells[7].FindControl("TxtCGSTAmount");
                    TextBox TxtSGSTRateString = (TextBox)row.Cells[8].FindControl("TxtSGSTRate");
                    TextBox TxtSGSTAmountString = (TextBox)row.Cells[9].FindControl("TxtSGSTAmount");
                    TextBox TxtIGSTRateString = (TextBox)row.Cells[10].FindControl("TxtIGSTRate");
                    TextBox TxtIGSTAmountString = (TextBox)row.Cells[11].FindControl("TxtIGSTAmount");

                    TextBox TxtTotalAmountString = (TextBox)row.Cells[12].FindControl("TxtTotalAmount");

                    if (TxtRateString.Text == string.Empty)
                    {
                        TxtRateString.Text = "0";
                    }

                    if (txt.Text.Trim() != string.Empty && TxtRateString.Text.Trim() != string.Empty)
                    {
                        TxtAmountString.Text = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtRateString.Text.Trim()));


                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            TxtCGSTAmountString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(TxtCGSTRateString.Text)) / 100).ToString();
                            TxtSGSTAmountString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(TxtSGSTRateString.Text)) / 100).ToString();
                            HfGSTAmount.Value = (Convert.ToDouble(TxtCGSTAmountString.Text.Trim()) + Convert.ToDouble(TxtSGSTAmountString.Text.Trim())).ToString();
                            double d;
                            d = ((Convert.ToDouble(TxtAmountString.Text.Trim())) + (Convert.ToDouble(TxtCGSTAmountString.Text)) + (Convert.ToDouble(TxtSGSTAmountString.Text)));
                            TxtTotalAmountString.Text = Convert.ToString(d);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            HiddenField IGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");
                            HiddenField IGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfIGSTAmount");

                            TxtIGSTAmountString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(TxtIGSTRateString.Text)) / 100).ToString();
                            HfGSTAmount.Value = TxtIGSTAmountString.Text;
                            TxtTotalAmountString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim())) + (Convert.ToDouble(TxtIGSTAmountString.Text))).ToString();
                        }

                        double lblTotalQuantity = TotalQuantity();
                        lblSumTotalQty.Text = lblTotalQuantity.ToString();

                        double lblAmount = TotalAmount();
                        lblSumAmount.Text = lblAmount.ToString();

                        double lblTotCGSTAmt = TotalCGSTAmount();
                        lblCGSTSumTotalAmount.Text = lblTotCGSTAmt.ToString();

                        double lblTotSGSTAmt = TotalSGSTAmount();
                        lblSGSTSumTotalAmount.Text = lblTotSGSTAmt.ToString();

                        double lblTotIGSTAmt = TotalIGSTAmount();
                        lblIGSTSumTotalAmount.Text = lblTotIGSTAmt.ToString();

                        double lblTotAmount = TotalAllAmount();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();

                    }



                    else
                    {
                        TxtAmountString.Text = Convert.ToString(Convert.ToDouble(0));
                    }


                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                if (validation.InToNumber(txt.Text.Trim()))
                {


                    Label lblSumTotalQty = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSumTotalQty"));
                    Label lblSumAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSumAmount"));
                    Label lblCGSTSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblCGSTSumTotalAmount"));
                    Label lblSGSTSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSGSTSumTotalAmount"));
                    Label lblIGSTSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblIGSTSumTotalAmount"));
                    Label lblSumTotalAmount = (Label)(GvStockIssueDetails.FooterRow.FindControl("lblSumTotalAmount"));

                    HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");
                    HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");

                    TextBox TxtQty = (TextBox)row.Cells[3].FindControl("TxtQty");
                    TextBox TxtAmountString = (TextBox)row.Cells[5].FindControl("TxtAmount");

                    TextBox TxtCGSTRateString = (TextBox)row.Cells[6].FindControl("TxtCGSTRate");
                    TextBox TxtCGSTAmountString = (TextBox)row.Cells[7].FindControl("TxtCGSTAmount");
                    TextBox TxtSGSTRateString = (TextBox)row.Cells[8].FindControl("TxtSGSTRate");
                    TextBox TxtSGSTAmountString = (TextBox)row.Cells[9].FindControl("TxtSGSTAmount");
                    TextBox TxtIGSTRateString = (TextBox)row.Cells[10].FindControl("TxtIGSTRate");
                    TextBox TxtIGSTAmountString = (TextBox)row.Cells[11].FindControl("TxtIGSTAmount");

                    TextBox TxtTotalAmountString = (TextBox)row.Cells[12].FindControl("TxtTotalAmount");

                    if (TxtQty.Text == string.Empty)
                    {
                        TxtQty.Text = "0";
                    }

                    if (txt.Text.Trim() != string.Empty && TxtQty.Text.Trim() != string.Empty)
                    {
                        TxtAmountString.Text = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtQty.Text.Trim()));


                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            TxtCGSTAmountString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(TxtCGSTRateString.Text)) / 100).ToString();
                            TxtSGSTAmountString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(TxtSGSTRateString.Text)) / 100).ToString();
                            HfGSTAmount.Value = (Convert.ToDouble(TxtCGSTAmountString.Text.Trim()) + Convert.ToDouble(TxtSGSTAmountString.Text.Trim())).ToString();
                            double d;
                            d = ((Convert.ToDouble(TxtAmountString.Text.Trim())) + (Convert.ToDouble(TxtCGSTAmountString.Text)) + (Convert.ToDouble(TxtSGSTAmountString.Text)));
                            TxtTotalAmountString.Text = Convert.ToString(d);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            //HiddenField IGST_RATEString = (HiddenField)row.Cells[0].FindControl("HfIGSTRate");
                            //HiddenField IGST_AMTString = (HiddenField)row.Cells[0].FindControl("HfIGSTAmount");

                            TxtIGSTAmountString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim()) * Convert.ToDouble(TxtIGSTRateString.Text)) / 100).ToString();
                            HfGSTAmount.Value = TxtIGSTAmountString.Text;
                            TxtTotalAmountString.Text = ((Convert.ToDouble(TxtAmountString.Text.Trim())) + (Convert.ToDouble(TxtIGSTAmountString.Text))).ToString();
                        }

                        double lblTotalQuantity = TotalQuantity();
                        lblSumTotalQty.Text = lblTotalQuantity.ToString();

                        double lblAmount = TotalAmount();
                        lblSumAmount.Text = lblAmount.ToString();

                        double lblTotCGSTAmt = TotalCGSTAmount();
                        lblCGSTSumTotalAmount.Text = lblTotCGSTAmt.ToString();

                        double lblTotSGSTAmt = TotalSGSTAmount();
                        lblSGSTSumTotalAmount.Text = lblTotSGSTAmt.ToString();

                        double lblTotIGSTAmt = TotalIGSTAmount();
                        lblIGSTSumTotalAmount.Text = lblTotIGSTAmt.ToString();

                        double lblTotAmount = TotalAllAmount();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();

                    }



                    else
                    {
                        TxtAmountString.Text = Convert.ToString(Convert.ToDouble(0));
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