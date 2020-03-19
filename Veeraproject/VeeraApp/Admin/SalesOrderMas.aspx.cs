using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;
using MihirValid;
using System.Text.RegularExpressions;

namespace VeeraApp
{
    public partial class SalesOrderMas : System.Web.UI.Page
    {
        public static string compcode;
        int rowIndex = 0;
        static DataTable DtSearch = new DataTable();
        //public static decimal OrderItemGrid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if
              (Session["USERCODE"] != null &&
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
                    //   FillDdlAccountName();
                    FillDdlPersonName();
                    //  FillORDER_ITEMGrid();
                    FillOrder_MasterGrid(Session["COMP_CODE"].ToString());
                    SetInitialRow();
                    CalendarOrderDate.StartDate = Convert.ToDateTime(Session["FIN_YEAR"].ToString());
                    CalendarOrderDate.EndDate = Convert.ToDateTime(Session["FIN_YEAR_END"].ToString());
                    HfTransType.Value = "S";
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




        public void FillOrder_MasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = ORDER_MASLogicLayer.GetAllSales_ORDER_MASDetails(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()), "S".ToString());
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvOrder_Master.DataSource = Dv.ToTable();
            GvOrder_Master.DataBind();

            DtSearch = Dv.ToTable();
        }

        protected void DdlOrdConfirm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlOrdConfirm.SelectedValue == "Y")
                {
                    TxtConfirmBy.Text = Session["USERNAME"].ToString();
                    TxtConfirmDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    TxtConfirmBy.Text = "";
                    TxtConfirmDate.Text = "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ControllerEnable()
        {

            TxtOrderNo.Enabled = true;
            TxtOrderDate.Enabled = true;
            TxtValidityDate.Enabled = true;
            TxtValidityDays.Enabled = true;
            TxtAccountName.Enabled = true;
            DdlPartyType.Enabled = true;
            DdlPreparedBy.Enabled = true;
            TxtRemarks.Enabled = true;
            TxtOrderReference.Enabled = true;
            TxtOrderRefDate.Enabled = true;
            TxtDispatchThru.Enabled = true;
            TxtStatus.Enabled = true;
            DdlOrderClose.Enabled = true;
            DdlOrdConfirm.Enabled = true;
            DdlAutoIndent.Enabled = true;
            TxtConfirmBy.Enabled = true;
            TxtConfirmDate.Enabled = true;
        }

        public void ControllerDisable()
        {
            TxtOrderNo.Enabled = false;
            TxtOrderDate.Enabled = false;
            TxtValidityDate.Enabled = false;
            TxtValidityDays.Enabled = false;
            TxtAccountName.Enabled = false;
            DdlPartyType.Enabled = false;
            DdlPreparedBy.Enabled = false;
            TxtRemarks.Enabled = false;
            TxtOrderReference.Enabled = false;
            TxtOrderRefDate.Enabled = false;
            TxtDispatchThru.Enabled = false;
            TxtStatus.Enabled = false;
            DdlOrderClose.Enabled = false;
            DdlOrdConfirm.Enabled = false;
            DdlAutoIndent.Enabled = false;
            TxtConfirmBy.Enabled = false;
            TxtConfirmDate.Enabled = false;
        }

        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfCompCode.Value = string.Empty;
            HfBranchCode.Value = string.Empty;
            HfTranDate.Value = string.Empty;
            HfTranNo.Value = string.Empty;
            TxtOrderNo.Text = string.Empty;
            TxtOrderDate.Text = string.Empty;
            TxtValidityDate.Text = string.Empty;
            TxtValidityDays.Text = string.Empty;
            TxtAccountName.Text = string.Empty;
            //  DdlAccountName.SelectedIndex = 0;
            DdlPartyType.SelectedIndex = 0;
            DdlPreparedBy.SelectedIndex = 0;
            TxtRemarks.Text = string.Empty;
            TxtOrderReference.Text = string.Empty;
            TxtOrderRefDate.Text = string.Empty;
            TxtDispatchThru.Text = string.Empty;
            TxtStatus.Text = string.Empty;
            DdlOrderClose.SelectedValue = "N";
            DdlOrdConfirm.SelectedValue = "N";
            DdlAutoIndent.SelectedIndex = 0;
            TxtConfirmBy.Text = string.Empty;
            TxtConfirmDate.Text = string.Empty;

            ClearSetInitialRow();


            BtncallUpd.Text = "SAVE";
        }

        #region TOTAL OF FOOTER TEMPLETES

        private double TotalOrderQty()
        {
            double GTotal = 0;
            for (int i = 0; i < GvOrderItem.Rows.Count; i++)
            {
                string total = (GvOrderItem.Rows[i].FindControl("TxtOrderQty") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }


        private double TotalGrossAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvOrderItem.Rows.Count; i++)
            {
                string total = (GvOrderItem.Rows[i].FindControl("TxtGrossAmount") as TextBox).Text;
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
            for (int i = 0; i < GvOrderItem.Rows.Count; i++)
            {
                string total = (GvOrderItem.Rows[i].FindControl("TxtCGSTAmount") as TextBox).Text;
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
            for (int i = 0; i < GvOrderItem.Rows.Count; i++)
            {
                string total = (GvOrderItem.Rows[i].FindControl("TxtSGSTAmount") as TextBox).Text;
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
            for (int i = 0; i < GvOrderItem.Rows.Count; i++)
            {
                string total = (GvOrderItem.Rows[i].FindControl("TxtIGSTAmount") as TextBox).Text;
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
            for (int i = 0; i < GvOrderItem.Rows.Count; i++)
            {
                string total = (GvOrderItem.Rows[i].FindControl("TxtTotalAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

        }


        #endregion


        public void FillNetAmount()
        {
            try
            {
                double GridmergeTotalAmt = Convert.ToDouble(ViewState["Total_OrderItem_Grid"]);


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



        public void FillORDER_ITEMGrid()
        {
            try
            {

                DataTable Dt = new DataTable();

                Dt = ORDER_ITEMLogicLayer.GetAllORDER_ITEMDetailByCompany((Session["COMP_CODE"].ToString()));
                GvOrderItem.DataSource = Dt;
                //   GvOrderItem.Columns[6].FooterText = Dt.AsEnumerable().Select(x => x.Field<Int32>("QTY")).Sum().ToString();
                GvOrderItem.DataBind();
            }
            catch (Exception)
            {

                throw;
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
                    TxtAccountName.BackColor = Color.White;
                }

                con.Close();

                FillDdlAccountPartyType();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void FillDdlAccountName(string Id)
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

        public void FillDdlAccountPartyType()
        {
            try
            {
                string ACODE = HfACODE.Value;
                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllIDWiseACCOUNTDetials(ACODE);
                if (Dt.Rows.Count > 0)
                {
                    DdlPartyType.SelectedValue = Dt.Rows[0]["PARTY_TYPE_String"].ToString().ToUpper();
                }
                else
                {
                    DdlPartyType.SelectedIndex = 0;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlAccountName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDdlAccountPartyType();
        }

        protected void GvOrderItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvOrderItem.PageIndex = e.NewPageIndex;
            clear();
            FillORDER_ITEMGrid();
        }

        protected void GvOrderItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //RangeValidator rng = (RangeValidator)e.Row.FindControl("RangeDis");
                    //rng.MinimumValue = "0"; //Set index of min value column
                    //rng.MaximumValue = "100"; //Set index of max value column
                    //rng.ErrorMessage = "Invalid Percentage";
                    //rng.ControlToValidate = "TxtDiscPer";
                    //rng.Type = ValidationDataType.Double;
                    //rng.ForeColor = Color.Red;

                    //RegularExpressionValidator RegExpforOrderQty = (RegularExpressionValidator)e.Row.FindControl("RegExpforOrderQty");
                    //RegExpforOrderQty.ErrorMessage = " Only Integer Value";
                    //RegExpforOrderQty.ControlToValidate = "TxtOrderQty";
                    //RegExpforOrderQty.ForeColor = Color.Red;
                    //Regex regexNumber = new Regex(@"^\d$");
                    //RegExpforOrderQty.ValidationExpression = regexNumber.ToString();            

                    TextBox TxtProductName = (e.Row.FindControl("TxtProductName") as TextBox);
                    TextBox TxtProductCode = (e.Row.FindControl("TxtProductCode") as TextBox);
                    HiddenField HfDetailSCode = (e.Row.FindControl("HfDetailSCode") as HiddenField);
                    TextBox TxtUOM = (TextBox)e.Row.FindControl("TxtUOM");

                    TextBox TxtOrderQty = (TextBox)e.Row.FindControl("TxtOrderQty");
                    TextBox TxtKeptQty = (TextBox)e.Row.FindControl("TxtKeptQty");
                    TextBox TxtReturnQty = (TextBox)e.Row.FindControl("TxtReturnQty");
                    TextBox TxtOSQty = (TextBox)e.Row.FindControl("TxtOSQty");
                    TextBox TxtStatusQty = (TextBox)e.Row.FindControl("TxtStatusQty");


                    DataTable DtProduct = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();

                    DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
                    //DdlProductName.DataValueField = "SCODE";
                    //DdlProductName.DataTextField = "SNAME";
                    //DdlProductName.DataSource = DtProduct;
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
                            TxtUOM.Text = DtView.Rows[0]["UOM"].ToString();
                        }
                        else
                        {
                            TxtProductName.Text = string.Empty;
                            TxtProductCode.Text = string.Empty;
                            TxtUOM.Text = string.Empty;
                        }

                    }

                    double Ord_Qty = 0, Kept_Qty = 0, Ret_Qty = 0;
                    if (TxtOrderQty.Text.Trim() != String.Empty)
                    {
                        Ord_Qty = Convert.ToDouble(TxtOrderQty.Text.Trim());
                    }

                    if (TxtKeptQty.Text.Trim() != string.Empty)
                    {
                        Kept_Qty = Convert.ToDouble(TxtKeptQty.Text.Trim());
                    }

                    if (TxtReturnQty.Text.Trim() != string.Empty)
                    {
                        Ret_Qty = Convert.ToDouble(TxtReturnQty.Text.Trim());
                    }


                    TxtOSQty.Text = Convert.ToString(Convert.ToInt32((Ord_Qty - Kept_Qty) + Ret_Qty)).ToString();


                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {

                    Label lblSumTotalQty = (Label)e.Row.FindControl("lblSumTotalQty");
                    Label lblSumTotalGrossAmount = (Label)e.Row.FindControl("lblSumTotalGrossAmount");
                    Label lblSumTotalCGST_AMT = (Label)e.Row.FindControl("lblSumTotalCGST_AMT");
                    Label lblSumTotalSGST_AMT = (Label)e.Row.FindControl("lblSumTotalSGST_AMT");
                    Label lblSumTotalIGST_AMT = (Label)e.Row.FindControl("lblSumTotalIGST_AMT");
                    Label lblSumTotalAmount = (Label)e.Row.FindControl("lblSumTotalAmount");


                    double lblTotOrderQty = TotalOrderQty();
                    lblSumTotalQty.Text = lblTotOrderQty.ToString();

                    double lblTotGamount = TotalGrossAmount();
                    lblSumTotalGrossAmount.Text = lblTotGamount.ToString();

                    double lblTotCGSTAmt = TotalCGSTAmount();
                    lblSumTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                    double lblTotSGSTAmt = TotalSGSTAmount();
                    lblSumTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                    double lblTotIGSTAmt = TotalIGSTAmount();
                    lblSumTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                    double lblTotAmount = TotalAmount();
                    lblSumTotalAmount.Text = lblTotAmount.ToString();




                    if (lblSumTotalAmount.Text == string.Empty)
                    {
                        lblSumTotalAmount.Text = "0";
                        HfOrderItem_Grid.Value = "0";
                    }
                    else
                    {

                        ViewState["Total_OrderItem_Grid"] = lblSumTotalAmount.Text.Trim();

                        //OrderItemGrid = Convert.ToDecimal(lblSumTotalAmount.Text.Trim());

                    }

                    FillNetAmount();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtRateString = (TextBox)row.Cells[4].FindControl("TxtRatePerQty");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");
                TextBox TxtCGSTRateString = (TextBox)row.Cells[6].FindControl("TxtCGSTRate");
                TextBox TxtSGSTRateString = (TextBox)row.Cells[8].FindControl("TxtSGSTRate");
                TextBox TxtIGSTRateString = (TextBox)row.Cells[10].FindControl("TxtIGSTRate");
                TextBox TxtUOM = (TextBox)row.Cells[2].FindControl("TxtUOM");

                if (ddl.SelectedIndex != 0 && DdlPartyType.SelectedIndex != 0)
                {
                    DataTable DsStock = STOCK_MASLogicLayer.STOCK_MAS_STOCK_RATEMAS_DetailByAccountPartyType(Convert.ToInt32(ddl.SelectedValue), DdlPartyType.SelectedValue);
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


                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select UOM from STOCK_MAS where SCODE = '" + ddl.SelectedValue + "'", con);
                TxtUOM.Text = cmd.ExecuteScalar().ToString();
                con.Close();
                TxtUOM.Enabled = false;

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
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("ADD_PART_NO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("UOM", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("RATE", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("DIS_PER", typeof(string));
            table.Columns.Add("DIS_AMT", typeof(string));
            table.Columns.Add("G_AMT", typeof(string));
            table.Columns.Add("CGST_RATE", typeof(string));
            table.Columns.Add("GST_AMT", typeof(string));
            table.Columns.Add("GST_RATE", typeof(string));
            table.Columns.Add("CGST_AMT", typeof(string));
            table.Columns.Add("SGST_RATE", typeof(string));
            table.Columns.Add("SGST_AMT", typeof(string));
            table.Columns.Add("IGST_RATE", typeof(string));
            table.Columns.Add("IGST_AMT", typeof(string));
            table.Columns.Add("T_AMT", typeof(string));
            table.Columns.Add("KEPT_QTY", typeof(string));
            table.Columns.Add("REJ_QTY", typeof(string));
            table.Columns.Add("STATUS", typeof(string));
            table.Columns.Add("OS_QTY", typeof(string));


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["ADD_PART_NO"] = string.Empty;
            dr["SCODE"] = string.Empty;
            dr["UOM"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["RATE"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["DIS_AMT"] = string.Empty;
            dr["DIS_PER"] = string.Empty;
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
            dr["KEPT_QTY"] = string.Empty;
            dr["REJ_QTY"] = string.Empty;
            dr["STATUS"] = string.Empty;
            dr["OS_QTY"] = string.Empty;

            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvOrderItem.DataSource = table;
            GvOrderItem.DataBind();
        }

        private void SetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("ADD_PART_NO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("UOM", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("RATE", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("DIS_PER", typeof(string));
            table.Columns.Add("DIS_AMT", typeof(string));
            table.Columns.Add("G_AMT", typeof(string));
            table.Columns.Add("CGST_RATE", typeof(string));
            table.Columns.Add("GST_AMT", typeof(string));
            table.Columns.Add("GST_RATE", typeof(string));
            table.Columns.Add("CGST_AMT", typeof(string));
            table.Columns.Add("SGST_RATE", typeof(string));
            table.Columns.Add("SGST_AMT", typeof(string));
            table.Columns.Add("IGST_RATE", typeof(string));
            table.Columns.Add("IGST_AMT", typeof(string));
            table.Columns.Add("T_AMT", typeof(string));
            table.Columns.Add("KEPT_QTY", typeof(string));
            table.Columns.Add("REJ_QTY", typeof(string));
            table.Columns.Add("STATUS", typeof(string));
            table.Columns.Add("OS_QTY", typeof(string));


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["ADD_PART_NO"] = string.Empty;
            dr["SCODE"] = string.Empty;
            dr["UOM"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["RATE"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["DIS_AMT"] = string.Empty;
            dr["DIS_PER"] = string.Empty;
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
            dr["KEPT_QTY"] = string.Empty;
            dr["REJ_QTY"] = string.Empty;
            dr["STATUS"] = string.Empty;
            dr["OS_QTY"] = string.Empty;

            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvOrderItem.DataSource = table;
            GvOrderItem.DataBind();
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
                        //TextBox TxtSrNo = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("TxtSrNo");

                        Label lblSumTotalQty = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalQty"));
                        Label lblSumTotalGrossAmount = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalGrossAmount"));
                        Label lblSumTotalCGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalCGST_AMT"));
                        Label lblSumTotalSGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalSGST_AMT"));
                        Label lblSumTotalIGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalIGST_AMT"));
                        Label lblSumTotalAmount = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalAmount"));

                        TextBox TxtProductName = (TextBox)GvOrderItem.Rows[rowIndex].Cells[1].FindControl("TxtProductName");
                        HiddenField HfDetailSCode = (HiddenField)GvOrderItem.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtProductPartNo = (TextBox)GvOrderItem.Rows[rowIndex].Cells[1].FindControl("TxtProductPartNo");
                        DropDownList DdlProductName = (DropDownList)GvOrderItem.Rows[rowIndex].Cells[2].FindControl("DdlProductName");
                        TextBox TxtUOM = (TextBox)GvOrderItem.Rows[rowIndex].Cells[3].FindControl("TxtUOM");
                        TextBox TxtOrderQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[4].FindControl("TxtOrderQty");
                        TextBox TxtRatePerQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[5].FindControl("TxtRatePerQty");
                        TextBox TxtDiscPer = (TextBox)GvOrderItem.Rows[rowIndex].Cells[6].FindControl("TxtDiscPer");
                        TextBox TxtGrossAmount = (TextBox)GvOrderItem.Rows[rowIndex].Cells[7].FindControl("TxtGrossAmount");
                        TextBox TxtCGSTRate = (TextBox)GvOrderItem.Rows[rowIndex].Cells[8].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvOrderItem.Rows[rowIndex].Cells[9].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvOrderItem.Rows[rowIndex].Cells[10].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvOrderItem.Rows[rowIndex].Cells[11].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvOrderItem.Rows[rowIndex].Cells[12].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvOrderItem.Rows[rowIndex].Cells[13].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvOrderItem.Rows[rowIndex].Cells[14].FindControl("TxtTotalAmount");
                        TextBox TxtKeptQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[15].FindControl("TxtKeptQty");
                        TextBox TxtReturnQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[16].FindControl("TxtReturnQty");
                        TextBox TxtStatusQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[17].FindControl("TxtStatusQty");
                        TextBox TxtOSQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[18].FindControl("TxtOSQty");

                        HiddenField HfGSTRate = (HiddenField)GvOrderItem.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                        HiddenField HfGSTAmount = (HiddenField)GvOrderItem.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfAmount = (HiddenField)GvOrderItem.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        HiddenField HfDisAmount = (HiddenField)GvOrderItem.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");



                        //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();
                        //dtCurrentTable.Rows[i - 1]["SCODE"] = TxtProductName.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["ADD_PART_NO"] = TxtProductPartNo.Text.Trim();
                        //dtCurrentTable.Rows[i - 1]["SCODE"] = DdlProductName.SelectedValue.Trim();
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtOrderQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["RATE"] = TxtRatePerQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = HfAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["DIS_AMT"] = HfDisAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["DIS_PER"] = TxtDiscPer.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["G_AMT"] = TxtGrossAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["GST_RATE"] = HfGSTRate.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["CGST_RATE"] = TxtCGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["CGST_AMT"] = TxtCGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SGST_RATE"] = TxtSGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SGST_AMT"] = TxtSGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["IGST_RATE"] = TxtIGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["IGST_AMT"] = TxtIGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["T_AMT"] = TxtTotalAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["KEPT_QTY"] = TxtKeptQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["REJ_QTY"] = TxtReturnQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["STATUS"] = TxtStatusQty.Text.Trim();


                        rowIndex++;

                        double lblTotOrderQty = TotalOrderQty();
                        lblSumTotalQty.Text = lblTotOrderQty.ToString();

                        double lblTotGamount = TotalGrossAmount();
                        lblSumTotalGrossAmount.Text = lblTotGamount.ToString();

                        double lblTotCGSTAmt = TotalCGSTAmount();
                        lblSumTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                        double lblTotSGSTAmt = TotalSGSTAmount();
                        lblSumTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                        double lblTotIGSTAmt = TotalIGSTAmount();
                        lblSumTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                        double lblTotAmount = TotalAmount();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();



                        if (lblSumTotalAmount.Text == string.Empty)
                        {
                            lblSumTotalAmount.Text = "0";
                        }
                        else
                        {

                            ViewState["Total_OrderItem_Grid"] = lblSumTotalAmount.Text.Trim();

                            //  OrderItemGrid = Convert.ToDecimal(lblSumTotalAmount.Text.Trim());

                        }

                        FillNetAmount();


                    }

                    drCurrentRow = dtCurrentTable.NewRow();



                    //drCurrentRow["SRNO"] = "";
                    drCurrentRow["ADD_PART_NO"] = "";
                    drCurrentRow["SCODE"] = "0";
                    drCurrentRow["QTY"] = "0";
                    drCurrentRow["RATE"] = "0";
                    drCurrentRow["AMT"] = "0";
                    drCurrentRow["DIS_PER"] = "0";
                    drCurrentRow["DIS_AMT"] = "0";
                    drCurrentRow["G_AMT"] = "0";
                    drCurrentRow["GST_RATE"] = "0";
                    drCurrentRow["GST_AMT"] = "0";
                    drCurrentRow["CGST_RATE"] = "0";
                    drCurrentRow["CGST_AMT"] = "0";
                    drCurrentRow["SGST_RATE"] = "0";
                    drCurrentRow["SGST_AMT"] = "0";
                    drCurrentRow["IGST_RATE"] = "0";
                    drCurrentRow["IGST_AMT"] = "0";
                    drCurrentRow["T_AMT"] = "0";
                    drCurrentRow["KEPT_QTY"] = "0";
                    drCurrentRow["REJ_QTY"] = "0";
                    drCurrentRow["STATUS"] = "";



                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvOrderItem.DataSource = dtCurrentTable;
                    GvOrderItem.DataBind();


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
            // System.Windows.Forms.MessageBox.Show(ViewState["CurrentTable"].ToString());

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        //TextBox TxtSrNo = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("TxtSrNo");
                        Label lblSumTotalQty = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalQty"));
                        Label lblSumTotalGrossAmount = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalGrossAmount"));
                        Label lblSumTotalCGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalCGST_AMT"));
                        Label lblSumTotalSGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalSGST_AMT"));
                        Label lblSumTotalIGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalIGST_AMT"));
                        Label lblSumTotalAmount = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalAmount"));

                        HiddenField HfDetailSCode = (HiddenField)GvOrderItem.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtProductName = (TextBox)GvOrderItem.Rows[rowIndex].Cells[1].FindControl("TxtProductName");
                        TextBox TxtProductPartNo = (TextBox)GvOrderItem.Rows[rowIndex].Cells[1].FindControl("TxtProductPartNo");
                        DropDownList DdlProductName = (DropDownList)GvOrderItem.Rows[rowIndex].Cells[2].FindControl("DdlProductName");
                        TextBox TxtUOM = (TextBox)GvOrderItem.Rows[rowIndex].Cells[3].FindControl("TxtUOM");
                        TextBox TxtOrderQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[4].FindControl("TxtOrderQty");
                        TextBox TxtRatePerQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[5].FindControl("TxtRatePerQty");
                        TextBox TxtDiscPer = (TextBox)GvOrderItem.Rows[rowIndex].Cells[6].FindControl("TxtDiscPer");
                        TextBox TxtGrossAmount = (TextBox)GvOrderItem.Rows[rowIndex].Cells[7].FindControl("TxtGrossAmount");
                        TextBox TxtCGSTRate = (TextBox)GvOrderItem.Rows[rowIndex].Cells[8].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvOrderItem.Rows[rowIndex].Cells[9].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvOrderItem.Rows[rowIndex].Cells[10].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvOrderItem.Rows[rowIndex].Cells[11].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvOrderItem.Rows[rowIndex].Cells[12].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvOrderItem.Rows[rowIndex].Cells[13].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvOrderItem.Rows[rowIndex].Cells[14].FindControl("TxtTotalAmount");
                        TextBox TxtKeptQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[15].FindControl("TxtKeptQty");
                        TextBox TxtReturnQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[16].FindControl("TxtReturnQty");
                        TextBox TxtStatusQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[17].FindControl("TxtStatusQty");
                        TextBox TxtOSQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[18].FindControl("TxtOSQty");

                        HiddenField HfGSTRate = (HiddenField)GvOrderItem.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                        HiddenField HfGSTAmount = (HiddenField)GvOrderItem.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfAmount = (HiddenField)GvOrderItem.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        HiddenField HfDisAmount = (HiddenField)GvOrderItem.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");


                        //TxtSrNo.Text = dt.Rows[i]["SRNO"].ToString();
                        //TxtProductName.Text = dt.Rows[i]["SCODE"].ToString();
                        HfDetailSCode.Value = dt.Rows[i]["SCODE"].ToString();
                        TxtProductPartNo.Text = dt.Rows[i]["ADD_PART_NO"].ToString();
                        //DdlProductName.SelectedValue = dt.Rows[i]["SCODE"].ToString();
                        TxtOrderQty.Text = dt.Rows[i]["QTY"].ToString();
                        TxtRatePerQty.Text = dt.Rows[i]["RATE"].ToString();
                        HfAmount.Value = dt.Rows[i]["AMT"].ToString();
                        TxtDiscPer.Text = dt.Rows[i]["DIS_PER"].ToString();
                        HfDisAmount.Value = dt.Rows[i]["DIS_AMT"].ToString();
                        TxtGrossAmount.Text = dt.Rows[i]["G_AMT"].ToString();
                        HfGSTRate.Value = dt.Rows[i]["GST_RATE"].ToString();
                        HfGSTAmount.Value = dt.Rows[i]["GST_AMT"].ToString();
                        TxtCGSTRate.Text = dt.Rows[i]["CGST_RATE"].ToString();
                        TxtCGSTAmount.Text = dt.Rows[i]["CGST_AMT"].ToString();
                        TxtSGSTRate.Text = dt.Rows[i]["SGST_RATE"].ToString();
                        TxtSGSTAmount.Text = dt.Rows[i]["SGST_AMT"].ToString();
                        TxtIGSTRate.Text = dt.Rows[i]["IGST_RATE"].ToString();
                        TxtIGSTAmount.Text = dt.Rows[i]["IGST_AMT"].ToString();
                        TxtTotalAmount.Text = dt.Rows[i]["T_AMT"].ToString();
                        TxtKeptQty.Text = dt.Rows[i]["KEPT_QTY"].ToString();
                        TxtReturnQty.Text = dt.Rows[i]["REJ_QTY"].ToString();
                        TxtStatusQty.Text = dt.Rows[i]["STATUS"].ToString();

                        double lblTotOrderQty = TotalOrderQty();
                        lblSumTotalQty.Text = lblTotOrderQty.ToString();

                        double lblTotGamount = TotalGrossAmount();
                        lblSumTotalGrossAmount.Text = lblTotGamount.ToString();

                        double lblTotCGSTAmt = TotalCGSTAmount();
                        lblSumTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                        double lblTotSGSTAmt = TotalSGSTAmount();
                        lblSumTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                        double lblTotIGSTAmt = TotalIGSTAmount();
                        lblSumTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                        double lblTotAmount = TotalAmount();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();


                        if (lblSumTotalAmount.Text == string.Empty)
                        {
                            lblSumTotalAmount.Text = "0";
                        }
                        else
                        {
                            ViewState["Total_OrderItem_Grid"] = lblSumTotalAmount.Text.Trim();
                            //  OrderItemGrid = Convert.ToDecimal(lblSumTotalAmount.Text.Trim());

                        }

                        FillNetAmount();

                        rowIndex++;
                    }
                }
            }
        }

        protected void BtnAddRowModelOrder_ItemGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        protected void BtnDeleteRowModelOrder_ItemGrid_Click(object sender, EventArgs e)
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
                else
                {

                }
                //Store the current data in ViewState for future reference
                ViewState["CurrentTable"] = dt;
                //Re bind the GridView for the updated data
                GvOrderItem.DataSource = dt;
                GvOrderItem.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }








        protected void BtnAdd_Click(object sender, EventArgs e)
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
            TxtStatus.Text = "O";
            TxtOrderDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            GvOrderItem.Enabled = true;

            if (HfTransType.Value == "S")
            {
                DivOrderRefDate.Visible = false;
            }
            else
            {
                DivOrderRefDate.Visible = true;
            }

            string OrderNo = ORDER_MASLogicLayer.GetOrderNoORDER_MASDetailCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtOrderDate.Text.Trim()).ToString("yyyy-MM-dd"),HfTransType.Value.ToString());
            if (OrderNo.Length <= 8)
            {
                TxtOrderNo.Text = OrderNo;
            }
            else
            {
                TxtOrderNo.Text = string.Empty;
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

        protected void GvOrder_Master_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvOrder_Master.PageIndex = e.NewPageIndex;
            clear();
            FillOrder_MasterGrid(Session["COMP_CODE"].ToString());
        }

        protected void GvOrder_Master_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataSet ds = ORDER_MASLogicLayer.GetAllIDWiseORDER_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable dtOt = ds.Tables[1];
                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfTransType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            TxtOrderNo.Text = dt.Rows[0]["ORD_NO"].ToString();
                            TxtOrderDate.Text = Convert.ToDateTime(dt.Rows[0]["ORD_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtValidityDate.Text = Convert.ToDateTime(dt.Rows[0]["VALID_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtValidityDays.Text = dt.Rows[0]["VALID_DAYS"].ToString();
                            //   FillDdlAccountName();
                            FillDdlAccountName(dt.Rows[0]["ACODE"].ToString());
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            FillDdlPersonName();
                            DdlPreparedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            TxtRemarks.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtOrderReference.Text = dt.Rows[0]["ORD_REF"].ToString();
                            TxtOrderRefDate.Text = Convert.ToDateTime(dt.Rows[0]["ORD_REFDATETIME"].ToString()).ToString("dd-MM-yyyy");
                            TxtDispatchThru.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtStatus.Text = dt.Rows[0]["STATUS"].ToString();
                            DdlOrderClose.SelectedValue = dt.Rows[0]["CLOSE_ORDER"].ToString();
                            DdlOrdConfirm.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            //    DdlAutoIndent.SelectedValue= dt.Rows[0][""].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();

                            if (dtOt.Rows.Count > 0)
                            {
                                GvOrderItem.DataSource = dtOt;
                                GvOrderItem.DataBind();

                                GvOrderItem.Enabled = false;
                            }

                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            Session["TRAN_TYPE"] = HfTransType.Value;


                        }
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

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = ORDER_MASLogicLayer.GetAllIDWiseORDER_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable dtOt = ds.Tables[1];
                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfTransType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            TxtOrderNo.Text = dt.Rows[0]["ORD_NO"].ToString();
                            TxtOrderDate.Text = Convert.ToDateTime(dt.Rows[0]["ORD_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtValidityDate.Text = Convert.ToDateTime(dt.Rows[0]["VALID_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtValidityDays.Text = dt.Rows[0]["VALID_DAYS"].ToString();
                            //     FillDdlAccountName();
                            FillDdlAccountName(dt.Rows[0]["ACODE"].ToString());
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            FillDdlPersonName();
                            DdlPreparedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            TxtRemarks.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtOrderReference.Text = dt.Rows[0]["ORD_REF"].ToString();
                            TxtOrderRefDate.Text = Convert.ToDateTime(dt.Rows[0]["ORD_REFDATETIME"].ToString()).ToString("dd-MM-yyyy");
                            TxtDispatchThru.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtStatus.Text = dt.Rows[0]["STATUS"].ToString();
                            DdlOrderClose.SelectedValue = dt.Rows[0]["CLOSE_ORDER"].ToString();
                            DdlOrdConfirm.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            //    DdlAutoIndent.SelectedValue= dt.Rows[0][""].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();

                            if (dtOt.Rows.Count > 0)
                            {
                                ViewState["CurrentTable"] = dtOt;
                                GvOrderItem.DataSource = dtOt;
                                GvOrderItem.DataBind();
                                GvOrderItem.Enabled = true;


                            }

                            BtncallUpd.Text = "UPDATE";

                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            Session["TRAN_TYPE"] = HfTransType.Value;

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

                if (e.CommandName == "Viewa")
                {
                    #region SET TEXT ON VIEW
                    clear();
                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;

                        DataSet ds = ORDER_MASLogicLayer.GetAllIDWiseORDER_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable dtOt = ds.Tables[1];
                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfTransType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            TxtOrderNo.Text = dt.Rows[0]["ORD_NO"].ToString();
                            TxtOrderDate.Text = Convert.ToDateTime(dt.Rows[0]["ORD_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtValidityDate.Text = Convert.ToDateTime(dt.Rows[0]["VALID_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtValidityDays.Text = dt.Rows[0]["VALID_DAYS"].ToString();
                            //  FillDdlAccountName();
                            FillDdlAccountName(dt.Rows[0]["ACODE"].ToString());
                            DdlPartyType.SelectedValue = dt.Rows[0]["PARTY_TYPE"].ToString();
                            FillDdlPersonName();
                            DdlPreparedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            TxtRemarks.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtOrderReference.Text = dt.Rows[0]["ORD_REF"].ToString();
                            TxtOrderRefDate.Text = Convert.ToDateTime(dt.Rows[0]["ORD_REFDATETIME"].ToString()).ToString("dd-MM-yyyy");
                            TxtDispatchThru.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtStatus.Text = dt.Rows[0]["STATUS"].ToString();
                            DdlOrderClose.SelectedValue = dt.Rows[0]["CLOSE_ORDER"].ToString();
                            DdlOrdConfirm.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            //    DdlAutoIndent.SelectedValue= dt.Rows[0][""].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();

                            if (dtOt.Rows.Count > 0)
                            {
                                GvOrderItem.DataSource = dtOt;
                                GvOrderItem.DataBind();
                                GvOrderItem.Enabled = false;
                            }

                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value;
                            Session["TRAN_TYPE"] = HfTransType.Value;
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
            catch (Exception ex)
            {

                lblmsg.Text = ex.Message.ToString();
            }
        }

        protected void GvOrder_Master_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) // Bind nested grid view with parent grid view
                {

                    string TransNo = ((HiddenField)e.Row.FindControl("HfTranNoGrid")).Value;
                    string TransDate = ((HiddenField)e.Row.FindControl("HfTranDateGrid")).Value;
                    GridView childgrd = (GridView)e.Row.FindControl("GvNestedOrderItem");


                    Button btnedit = (e.Row.FindControl("btnEdit") as Button);
                    Button btndelete = (e.Row.FindControl("btnDelete") as Button);
                    Label lblchk = (e.Row.FindControl("lblOrderFlag") as Label);

                    HiddenField hfREC_UPD = (e.Row.FindControl("hfREC_UPD") as HiddenField);
                    HiddenField hfREC_DEL = (e.Row.FindControl("hfREC_DEL") as HiddenField);
                    HiddenField hfREC_INS = (e.Row.FindControl("hfREC_INS") as HiddenField);

                    DataTable Dt = new DataTable();

                    Dt = ORDER_ITEMLogicLayer.GetAllWiseID_ORDER_MASDetail(TransNo.ToString(), Convert.ToDateTime(TransDate.ToString()));
                    childgrd.DataSource = Dt;
                    childgrd.DataBind();


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


                        if (lblchk.Text == "YES")
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


                        if (lblchk.Text == "YES")
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
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvNestedOrderItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region UPDATE ORDER MASTER

                #region INSERT ORDER MAS

                ORDER_MASLogicLayer insert = new ORDER_MASLogicLayer();
                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.TRAN_TYPE = HfTransType.Value.Trim().ToUpper();
                if (TxtOrderNo.Text == string.Empty)
                {
                    insert.ORD_NO = "0";
                }
                else
                {
                    insert.ORD_NO = TxtOrderNo.Text.Trim();
                }
                insert.ORD_DT = Convert.ToDateTime(TxtOrderDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");  //TxtOrderDate.Text.Trim();
                insert.ACODE = HfACODE.Value.Trim().ToUpper();
                insert.TRANSPORT = TxtDispatchThru.Text.Trim().ToUpper();
                insert.ORD_REF = TxtOrderReference.Text.Trim().ToUpper();
                insert.REMARK = TxtRemarks.Text.Trim().ToUpper();
                insert.TOT_QTY = "0";
                insert.TOT_KEPT = "0";
                insert.TOT_REJ = "0";
                insert.STATUS = TxtStatus.Text.Trim().ToUpper();
                insert.CLOSE_ORDER = DdlOrderClose.SelectedValue.Trim();
                insert.ENDT = "";
                insert.ST_PER = "0";
                insert.ST_AMT = "0";
                insert.ADD_ST_PER = "0";
                insert.ADD_ST_AMT = "0";
                if (TxtNetAmt.Text == string.Empty)
                {
                    insert.NET_AMT = "0";
                }
                else
                {
                    insert.NET_AMT = TxtNetAmt.Text.Trim();
                }

                insert.PROJECT_NO = "";
                insert.DRAWING_NO = "";
                if (TxtOrderRefDate.Text.Trim() != string.Empty)
                {
                    insert.ORD_REFDATETIME = Convert.ToDateTime(TxtOrderRefDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                insert.DRIVER_NAME = "";
                insert.DRIVER_ADD = "";
                insert.MDLNO = "";
                insert.MDLSTATE = "";
                insert.EX_DUTY_PER = "0";
                insert.EX_DUTY_AMT = "0";
                insert.EX_CESS_PER = "0";
                insert.EX_CESS_AMT = "0";
                insert.EX_SHCESS_PER = "0";
                insert.EX_SHCESS_AMT = "0";
                if (TxtROamt.Text == string.Empty)
                {
                    insert.RO_AMT = "0";
                }
                else
                {
                    insert.RO_AMT = TxtROamt.Text.Trim();
                }
                insert.BRANCH_CODE = HfBranchCode.Value.Trim();
                insert.BCODE = DdlPreparedBy.SelectedValue.Trim();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";
                insert.CONF_FLAG = DdlOrdConfirm.SelectedValue.Trim().ToUpper();
                if (DdlOrdConfirm.SelectedValue == "Y")
                {
                    insert.CONF_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.CONF_DATE = "";
                }

                if (DdlOrdConfirm.SelectedValue == "Y")
                {
                    insert.CONF_USERID = TxtConfirmBy.Text.Trim().ToString();
                }
                else
                {
                    insert.CONF_USERID = "";
                }
                if (TxtValidityDays.Text == string.Empty)
                {
                    insert.VALID_DAYS = "0";
                }
                else
                {
                    insert.VALID_DAYS = TxtValidityDays.Text.Trim().ToUpper();
                }
                insert.VALID_DATE = Convert.ToDateTime(TxtValidityDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                insert.FIN_YEAR = Convert.ToDateTime(Session["FIN_YEAR"].ToString()).Year.ToString() + "-" + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).Year.ToString();
                insert.OS_YEAR = Convert.ToDateTime(Session["FIN_YEAR"].ToString()).Year.ToString() + "-" + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).Year.ToString();
                insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToUpper();
                insert.GST_RATE = "0";
                insert.GST_AMT = "0";
                insert.CGST_RATE = "0";
                insert.CGST_AMT = "0";
                insert.SGST_RATE = "0";
                insert.SGST_AMT = "0";
                insert.IGST_RATE = "0";
                insert.IGST_AMT = "0";
                insert.GROSS_AMT = "0";

                #endregion

                #region INSERT ORDER ITEM

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);
                int ORDERSRNO = 1;

                foreach (GridViewRow row in GvOrderItem.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                        TextBox TxtProductPartNo = row.FindControl("TxtProductPartNo") as TextBox;
                        TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                        TextBox TxtOrderQty = row.FindControl("TxtOrderQty") as TextBox;
                        TextBox TxtRatePerQty = row.FindControl("TxtRatePerQty") as TextBox;
                        TextBox TxtDiscPer = row.FindControl("TxtDiscPer") as TextBox;
                        TextBox TxtGrossAmount = row.FindControl("TxtGrossAmount") as TextBox;
                        TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                        TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                        TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                        TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                        TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                        TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                        TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;
                        TextBox TxtKeptQty = row.FindControl("TxtKeptQty") as TextBox;
                        TextBox TxtReturnQty = row.FindControl("TxtReturnQty") as TextBox;
                        TextBox TxtStatusQty = row.FindControl("TxtStatusQty") as TextBox;

                        HiddenField HfAmount = row.FindControl("HfAmount") as HiddenField;
                        HiddenField HfDisAmount = row.FindControl("HfDisAmount") as HiddenField;
                        HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                        HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;

                        if (HfDetailSCode.Value != "0")
                        {

                            XmlElement HandleDetail2 = XDoc1.CreateElement("OrderItem");
                            HandleDetail2.SetAttribute("SRNO", ORDERSRNO.ToString().Trim());
                            HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                            HandleDetail2.SetAttribute("BRANCH_CODE", HfBranchCode.Value.Trim());
                            HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                            HandleDetail2.SetAttribute("ADD_PART_NO", (TxtProductPartNo.Text.Trim()));

                            if (HfDetailSCode.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("SCODE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value.Trim()));
                            }
                            if (TxtOrderQty.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("QTY", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("QTY", (TxtOrderQty.Text));
                            }

                            if (TxtRatePerQty.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("RATE", (TxtRatePerQty.Text));
                            }


                            if (HfAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("AMT", (HfAmount.Value));
                            }

                            if (TxtDiscPer.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("DIS_PER", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("DIS_PER", (TxtDiscPer.Text));
                            }

                            if (HfDisAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("DIS_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("DIS_AMT", (HfDisAmount.Value));
                            }

                            if (TxtGrossAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("G_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("G_AMT", (TxtGrossAmount.Text));
                            }

                            if (HfGSTRate.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("GST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("GST_RATE", (HfGSTRate.Value));
                            }

                            if (HfGSTAmount.Value == string.Empty)
                            {
                                HandleDetail2.SetAttribute("GST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("GST_AMT", (HfGSTAmount.Value));
                            }

                            if (TxtCGSTRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("CGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("CGST_RATE", (TxtCGSTRate.Text));
                            }
                            if (TxtCGSTAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("CGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text));
                            }
                            if (TxtSGSTRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("SGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("SGST_RATE", (TxtSGSTRate.Text));
                            }
                            if (TxtSGSTAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("SGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text));
                            }
                            if (TxtIGSTRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("IGST_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("IGST_RATE", (TxtIGSTRate.Text));
                            }
                            if (TxtIGSTAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("IGST_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text));
                            }
                            if (TxtTotalAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("T_AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("T_AMT", (TxtTotalAmount.Text));
                            }

                            if (TxtKeptQty.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("KEPT_QTY", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("KEPT_QTY", (TxtKeptQty.Text));
                            }
                            if (TxtReturnQty.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("REJ_QTY", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("REJ_QTY", (TxtReturnQty.Text));
                            }

                            HandleDetail2.SetAttribute("STATUS", (TxtStatus.Text.Trim()));

                            root1.AppendChild(HandleDetail2);
                            ORDERSRNO++;
                        }
                    }

                }

                #endregion

                #region INSERT INTO ORDER_MAS_QUOTATION

                XmlDocument XDocQOU = new XmlDocument();
                XmlDeclaration decQUO = XDocQOU.CreateXmlDeclaration("1.0", null, null);
                XDocQOU.AppendChild(decQUO);// Create the root element
                XmlElement rootQUO = XDocQOU.CreateElement("root");
                XDocQOU.AppendChild(rootQUO);
                int QUO_SRNO = 1;

                if (ViewState["AddQuotationTable"] != null)
                {
                    DataTable DtQUOMASter = (DataTable)ViewState["AddQuotationTable"];
                    if (DtQUOMASter.Rows.Count > 0)
                    {
                        for (int m = 0; m < DtQUOMASter.Rows.Count; m++)
                        {
                            XmlElement HandleDetailDC = XDocQOU.CreateElement("OrderMasQoutation");

                            HandleDetailDC.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                            HandleDetailDC.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetailDC.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                            HandleDetailDC.SetAttribute("SRNO", QUO_SRNO.ToString());

                            HandleDetailDC.SetAttribute("QUO_TRAN_DATE", (Convert.ToDateTime(DtQUOMASter.Rows[m]["QUOTranDate"].ToString()).ToString("MM-dd-yyyy")));
                            HandleDetailDC.SetAttribute("QUO_TRAN_NO", DtQUOMASter.Rows[m]["QUOTranNo"].ToString());

                            rootQUO.AppendChild(HandleDetailDC);
                            QUO_SRNO++;
                        }
                    }
                }

                #endregion

                string str = ORDER_MASLogicLayer.UpdateORDER_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDocQOU.OuterXml));

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "SALES ORDER MASTER UPDATE  SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillOrder_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "SALES ORDER MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR :SALES ORDER MASTER NOT SAVED";
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
                    #region INSERT ORDER MAS

                    ORDER_MASLogicLayer insert = new ORDER_MASLogicLayer();
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    //insert.TRAN_DATE = HfTranDate.Value.Trim();
                    //insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.TRAN_TYPE = HfTransType.Value.Trim().ToUpper();
                    if (TxtOrderNo.Text == string.Empty)
                    {
                        insert.ORD_NO = "0";
                    }
                    else
                    {
                        insert.ORD_NO = TxtOrderNo.Text.Trim();
                    }
                    insert.ORD_DT = Convert.ToDateTime(TxtOrderDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");  //TxtOrderDate.Text.Trim();
                    insert.ACODE = HfACODE.Value.Trim().ToUpper();
                    insert.TRANSPORT = TxtDispatchThru.Text.Trim().ToUpper();
                    insert.ORD_REF = TxtOrderReference.Text.Trim().ToUpper();
                    insert.REMARK = TxtRemarks.Text.Trim().ToUpper();
                    insert.TOT_QTY = "0";
                    insert.TOT_KEPT = "0";
                    insert.TOT_REJ = "0";
                    insert.STATUS = TxtStatus.Text.Trim().ToUpper();
                    insert.CLOSE_ORDER = DdlOrderClose.SelectedValue.Trim();
                    insert.ENDT = "";
                    insert.ST_PER = "0";
                    insert.ST_AMT = "0";
                    insert.ADD_ST_PER = "0";
                    insert.ADD_ST_AMT = "0";
                    if (TxtNetAmt.Text == string.Empty)
                    {
                        insert.NET_AMT = "0";
                    }
                    else
                    {
                        insert.NET_AMT = TxtNetAmt.Text.Trim();
                    }
                    insert.PROJECT_NO = "";
                    insert.DRAWING_NO = "";
                    if (TxtOrderRefDate.Text.Trim() != string.Empty)
                    {
                        insert.ORD_REFDATETIME = Convert.ToDateTime(TxtOrderRefDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    insert.DRIVER_NAME = "";
                    insert.DRIVER_ADD = "";
                    insert.MDLNO = "";
                    insert.MDLSTATE = "";
                    insert.EX_DUTY_PER = "0";
                    insert.EX_DUTY_AMT = "0";
                    insert.EX_CESS_PER = "0";
                    insert.EX_CESS_AMT = "0";
                    insert.EX_SHCESS_PER = "0";
                    insert.EX_SHCESS_AMT = "0";
                    if (TxtROamt.Text == string.Empty)
                    {
                        insert.RO_AMT = "0";
                    }
                    else
                    {
                        insert.RO_AMT = TxtROamt.Text.Trim();
                    }
                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                    insert.BCODE = DdlPreparedBy.SelectedValue.Trim();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";
                    insert.CONF_FLAG = DdlOrdConfirm.SelectedValue.Trim().ToUpper();
                    if (DdlOrdConfirm.SelectedValue == "Y")
                    {
                        insert.CONF_DATE = Convert.ToDateTime(TxtConfirmDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CONF_DATE = "";
                    }

                    if (DdlOrdConfirm.SelectedValue == "Y")
                    {
                        insert.CONF_USERID = TxtConfirmBy.Text.Trim().ToString();
                    }
                    else
                    {
                        insert.CONF_USERID = "";
                    }

                    if (TxtValidityDays.Text == string.Empty)
                    {
                        insert.VALID_DAYS = "0";
                    }
                    else
                    {
                        insert.VALID_DAYS = TxtValidityDays.Text.Trim().ToUpper();
                    }
                    insert.VALID_DATE = Convert.ToDateTime(TxtValidityDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    insert.FIN_YEAR = Convert.ToDateTime(Session["FIN_YEAR"].ToString()).Year.ToString() + "-" + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).Year.ToString();
                    insert.OS_YEAR = Convert.ToDateTime(Session["FIN_YEAR"].ToString()).Year.ToString() + "-" + Convert.ToDateTime(Session["FIN_YEAR_END"].ToString()).Year.ToString();
                    insert.PARTY_TYPE = DdlPartyType.SelectedValue.Trim().ToUpper();
                    insert.GST_RATE = "0";
                    insert.GST_AMT = "0";
                    insert.CGST_RATE = "0";
                    insert.CGST_AMT = "0";
                    insert.SGST_RATE = "0";
                    insert.SGST_AMT = "0";
                    insert.IGST_RATE = "0";
                    insert.IGST_AMT = "0";
                    insert.GROSS_AMT = "0";

                    #endregion

                    #region INSERT ORDER ITEM

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int ORDERSRNO = 1;

                    foreach (GridViewRow row in GvOrderItem.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                            TextBox TxtProductPartNo = row.FindControl("TxtProductPartNo") as TextBox;
                            TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                            TextBox TxtOrderQty = row.FindControl("TxtOrderQty") as TextBox;
                            TextBox TxtRatePerQty = row.FindControl("TxtRatePerQty") as TextBox;
                            TextBox TxtDiscPer = row.FindControl("TxtDiscPer") as TextBox;
                            TextBox TxtGrossAmount = row.FindControl("TxtGrossAmount") as TextBox;
                            TextBox TxtCGSTRate = row.FindControl("TxtCGSTRate") as TextBox;
                            TextBox TxtCGSTAmount = row.FindControl("TxtCGSTAmount") as TextBox;
                            TextBox TxtSGSTRate = row.FindControl("TxtSGSTRate") as TextBox;
                            TextBox TxtSGSTAmount = row.FindControl("TxtSGSTAmount") as TextBox;
                            TextBox TxtIGSTRate = row.FindControl("TxtIGSTRate") as TextBox;
                            TextBox TxtIGSTAmount = row.FindControl("TxtIGSTAmount") as TextBox;
                            TextBox TxtTotalAmount = row.FindControl("TxtTotalAmount") as TextBox;
                            TextBox TxtKeptQty = row.FindControl("TxtKeptQty") as TextBox;
                            TextBox TxtReturnQty = row.FindControl("TxtReturnQty") as TextBox;
                            TextBox TxtStatusQty = row.FindControl("TxtStatusQty") as TextBox;

                            HiddenField HfAmount = row.FindControl("HfAmount") as HiddenField;
                            HiddenField HfDisAmount = row.FindControl("HfDisAmount") as HiddenField;
                            HiddenField HfGSTRate = row.FindControl("HfGSTRate") as HiddenField;
                            HiddenField HfGSTAmount = row.FindControl("HfGSTAmount") as HiddenField;

                            if (HfDetailSCode.Value != "0")
                            {

                                XmlElement HandleDetail2 = XDoc1.CreateElement("OrderItem");
                                HandleDetail2.SetAttribute("SRNO", ORDERSRNO.ToString());
                                HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                TxtStatusQty.Text = "O";

                                HandleDetail2.SetAttribute("ADD_PART_NO", (TxtProductPartNo.Text.Trim()));

                                if (HfDetailSCode.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SCODE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value.Trim()));
                                }

                                if (TxtOrderQty.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("QTY", (TxtOrderQty.Text));
                                }

                                if (TxtRatePerQty.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("RATE", (TxtRatePerQty.Text));
                                }


                                if (HfAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("AMT", (HfAmount.Value));
                                }

                                if (TxtDiscPer.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DIS_PER", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("DIS_PER", (TxtDiscPer.Text));
                                }

                                if (HfDisAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("DIS_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("DIS_AMT", (HfDisAmount.Value));
                                }

                                if (TxtGrossAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("G_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("G_AMT", (TxtGrossAmount.Text));
                                }

                                if (HfGSTRate.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("GST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("GST_RATE", (HfGSTRate.Value));
                                }

                                if (HfGSTAmount.Value == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("GST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("GST_AMT", (HfGSTAmount.Value));
                                }

                                if (TxtCGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CGST_RATE", (TxtCGSTRate.Text));
                                }
                                if (TxtCGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("CGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CGST_AMT", (TxtCGSTAmount.Text));
                                }
                                if (TxtSGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SGST_RATE", (TxtSGSTRate.Text));
                                }
                                if (TxtSGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("SGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("SGST_AMT", (TxtSGSTAmount.Text));
                                }
                                if (TxtIGSTRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("IGST_RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("IGST_RATE", (TxtIGSTRate.Text));
                                }
                                if (TxtIGSTAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("IGST_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("IGST_AMT", (TxtIGSTAmount.Text));
                                }
                                if (TxtTotalAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("T_AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("T_AMT", (TxtTotalAmount.Text));
                                }

                                if (TxtKeptQty.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("KEPT_QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("KEPT_QTY", (TxtKeptQty.Text));
                                }
                                if (TxtReturnQty.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("REJ_QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("REJ_QTY", (TxtReturnQty.Text));
                                }

                                HandleDetail2.SetAttribute("STATUS", (TxtStatus.Text.Trim()));

                                root1.AppendChild(HandleDetail2);
                                ORDERSRNO++;
                            }
                        }

                    }

                    #endregion

                    #region INSERT INTO ORDER_MAS_QUOTATION

                    XmlDocument XDocQOU = new XmlDocument();
                    XmlDeclaration decQUO = XDocQOU.CreateXmlDeclaration("1.0", null, null);
                    XDocQOU.AppendChild(decQUO);// Create the root element
                    XmlElement rootQUO = XDocQOU.CreateElement("root");
                    XDocQOU.AppendChild(rootQUO);
                    int QUO_SRNO = 1;

                    if (ViewState["AddQuotationTable"] != null)
                    {
                        DataTable DtQUOMASter = (DataTable)ViewState["AddQuotationTable"];
                        if (DtQUOMASter.Rows.Count > 0)
                        {
                            for (int m = 0; m < DtQUOMASter.Rows.Count; m++)
                            {
                                XmlElement HandleDetailDC = XDocQOU.CreateElement("OrderMasQoutation");

                                HandleDetailDC.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetailDC.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetailDC.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                                HandleDetailDC.SetAttribute("SRNO", QUO_SRNO.ToString());

                                HandleDetailDC.SetAttribute("QUO_TRAN_DATE", (Convert.ToDateTime(DtQUOMASter.Rows[m]["QUOTranDate"].ToString()).ToString("MM-dd-yyyy")));
                                HandleDetailDC.SetAttribute("QUO_TRAN_NO", DtQUOMASter.Rows[m]["QUOTranNo"].ToString());

                                rootQUO.AppendChild(HandleDetailDC);
                                QUO_SRNO++;
                            }
                        }
                    }

                    #endregion

                    string str = ORDER_MASLogicLayer.InsertORDER_MASDetail(insert, validation.RSC(XDoc1.OuterXml),validation.RSC(XDocQOU.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(),HfTransType.Value.ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"));

                    if (str.Contains("successfully"))
                    {
                        //      string BarCodeStr = ORDER_MASLogicLayer.GenerateBracodeForPurchaseOrder('O', Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"),);
                        lblmsg.Text = "SALES ORDER MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillOrder_MasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "SALES ORDER MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : SALES ORDER MASTER NOT SAVED";
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
                //  string TranDate = HfTranDate.Value;
                if (HfTranNo.Value != string.Empty && HfTranDate.Value != string.Empty)
                {
                    string str = ORDER_MASLogicLayer.DeleteORDER_MASDetailsByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value.ToString()));
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
                        lblmsg.Text = "Error:Purchase Order Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillOrder_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region CALCULATION FOR GST IN ORDER ITEM

        public void FillOnGridDetailChanged()
        {
            #region Assign To Stock Grid Table

            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values 
                        //TextBox TxtSrNo = (TextBox)GvQuotation_T.Rows[rowIndex].Cells[0].FindControl("TxtSrNo");

                        Label lblSumTotalQty = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalQty"));
                        Label lblSumTotalGrossAmount = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalGrossAmount"));
                        Label lblSumTotalCGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalCGST_AMT"));
                        Label lblSumTotalSGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalSGST_AMT"));
                        Label lblSumTotalIGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalIGST_AMT"));
                        Label lblSumTotalAmount = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalAmount"));

                        TextBox TxtProductName = (TextBox)GvOrderItem.Rows[rowIndex].Cells[1].FindControl("TxtProductName");
                        HiddenField HfDetailSCode = (HiddenField)GvOrderItem.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtProductPartNo = (TextBox)GvOrderItem.Rows[rowIndex].Cells[1].FindControl("TxtProductPartNo");
                        DropDownList DdlProductName = (DropDownList)GvOrderItem.Rows[rowIndex].Cells[2].FindControl("DdlProductName");
                        TextBox TxtUOM = (TextBox)GvOrderItem.Rows[rowIndex].Cells[3].FindControl("TxtUOM");
                        TextBox TxtOrderQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[4].FindControl("TxtOrderQty");
                        TextBox TxtRatePerQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[5].FindControl("TxtRatePerQty");
                        TextBox TxtDiscPer = (TextBox)GvOrderItem.Rows[rowIndex].Cells[6].FindControl("TxtDiscPer");
                        TextBox TxtGrossAmount = (TextBox)GvOrderItem.Rows[rowIndex].Cells[7].FindControl("TxtGrossAmount");
                        TextBox TxtCGSTRate = (TextBox)GvOrderItem.Rows[rowIndex].Cells[8].FindControl("TxtCGSTRate");
                        TextBox TxtCGSTAmount = (TextBox)GvOrderItem.Rows[rowIndex].Cells[9].FindControl("TxtCGSTAmount");
                        TextBox TxtSGSTRate = (TextBox)GvOrderItem.Rows[rowIndex].Cells[10].FindControl("TxtSGSTRate");
                        TextBox TxtSGSTAmount = (TextBox)GvOrderItem.Rows[rowIndex].Cells[11].FindControl("TxtSGSTAmount");
                        TextBox TxtIGSTRate = (TextBox)GvOrderItem.Rows[rowIndex].Cells[12].FindControl("TxtIGSTRate");
                        TextBox TxtIGSTAmount = (TextBox)GvOrderItem.Rows[rowIndex].Cells[13].FindControl("TxtIGSTAmount");
                        TextBox TxtTotalAmount = (TextBox)GvOrderItem.Rows[rowIndex].Cells[14].FindControl("TxtTotalAmount");
                        TextBox TxtKeptQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[15].FindControl("TxtKeptQty");
                        TextBox TxtReturnQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[16].FindControl("TxtReturnQty");
                        TextBox TxtStatusQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[17].FindControl("TxtStatusQty");
                        TextBox TxtOSQty = (TextBox)GvOrderItem.Rows[rowIndex].Cells[18].FindControl("TxtOSQty");

                        HiddenField HfGSTRate = (HiddenField)GvOrderItem.Rows[rowIndex].Cells[0].FindControl("HfGSTRate");
                        HiddenField HfGSTAmount = (HiddenField)GvOrderItem.Rows[rowIndex].Cells[0].FindControl("HfGSTAmount");
                        HiddenField HfAmount = (HiddenField)GvOrderItem.Rows[rowIndex].Cells[0].FindControl("HfAmount");
                        HiddenField HfDisAmount = (HiddenField)GvOrderItem.Rows[rowIndex].Cells[0].FindControl("HfDisAmount");



                        //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();
                        //dtCurrentTable.Rows[i - 1]["SCODE"] = TxtProductName.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["ADD_PART_NO"] = TxtProductPartNo.Text.Trim();
                        //dtCurrentTable.Rows[i - 1]["SCODE"] = DdlProductName.SelectedValue.Trim();
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtOrderQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["RATE"] = TxtRatePerQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = HfAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["DIS_AMT"] = HfDisAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["DIS_PER"] = TxtDiscPer.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["G_AMT"] = TxtGrossAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["GST_RATE"] = HfGSTRate.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["GST_AMT"] = HfGSTAmount.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["CGST_RATE"] = TxtCGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["CGST_AMT"] = TxtCGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SGST_RATE"] = TxtSGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SGST_AMT"] = TxtSGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["IGST_RATE"] = TxtIGSTRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["IGST_AMT"] = TxtIGSTAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["T_AMT"] = TxtTotalAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["KEPT_QTY"] = TxtKeptQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["REJ_QTY"] = TxtReturnQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["STATUS"] = TxtStatusQty.Text.Trim();


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


                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");
                TextBox TxtProductName = (TextBox)row.Cells[1].FindControl("TxtProductName");
                TextBox TxtRateString = (TextBox)row.Cells[4].FindControl("TxtRatePerQty");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");
                TextBox TxtCGSTRateString = (TextBox)row.Cells[6].FindControl("TxtCGSTRate");
                TextBox TxtSGSTRateString = (TextBox)row.Cells[8].FindControl("TxtSGSTRate");
                TextBox TxtIGSTRateString = (TextBox)row.Cells[10].FindControl("TxtIGSTRate");
                TextBox TxtUOM = (TextBox)row.Cells[2].FindControl("TxtUOM");

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
                        TxtUOM.Text = DtView.Rows[0]["UOM"].ToString();
                        TxtUOM.Enabled = false;
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
                else
                {

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

                //    Label lblSumTotalGrossAmount = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalGrossAmount"));

                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");
                TextBox TxtProductCode = (TextBox)row.Cells[1].FindControl("TxtProductCode");
                TextBox TxtRateString = (TextBox)row.Cells[4].FindControl("TxtRatePerQty");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");
                TextBox TxtCGSTRateString = (TextBox)row.Cells[6].FindControl("TxtCGSTRate");
                TextBox TxtSGSTRateString = (TextBox)row.Cells[8].FindControl("TxtSGSTRate");
                TextBox TxtIGSTRateString = (TextBox)row.Cells[10].FindControl("TxtIGSTRate");
                TextBox TxtUOM = (TextBox)row.Cells[2].FindControl("TxtUOM");

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
                        TxtUOM.Text = DtView.Rows[0]["UOM"].ToString();
                        TxtUOM.Enabled = false;
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
                else
                {

                }

            }

            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtOrderQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                if (validation.InToNumber(txt.Text.Trim()))
                {

                    Label lblSumTotalQty = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalQty"));
                    Label lblSumTotalGrossAmount = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalGrossAmount"));
                    Label lblSumTotalCGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalCGST_AMT"));
                    Label lblSumTotalSGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalSGST_AMT"));
                    Label lblSumTotalIGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalIGST_AMT"));
                    Label lblSumTotalAmount = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalAmount"));

                    TextBox TxtRateString = (TextBox)row.Cells[4].FindControl("TxtRatePerQty");
                    TextBox TxtG_AmountString = (TextBox)row.Cells[5].FindControl("TxtGrossAmount");

                    TextBox TxtDiscPer = (TextBox)row.Cells[4].FindControl("TxtDiscPer");
                    HiddenField HfDisAmount = (HiddenField)row.Cells[0].FindControl("HfDisAmount");

                    TextBox CGST_RATEString = (TextBox)row.Cells[6].FindControl("TxtCGSTRate");
                    TextBox SGST_RATEString = (TextBox)row.Cells[8].FindControl("TxtSGSTRate");
                    TextBox CGST_AMTString = (TextBox)row.Cells[7].FindControl("TxtCGSTAmount");
                    TextBox SGST_AMTString = (TextBox)row.Cells[9].FindControl("TxtSGSTAmount");
                    TextBox IGST_RATEString = (TextBox)row.Cells[9].FindControl("TxtIGSTRate");
                    TextBox IGST_AMTString = (TextBox)row.Cells[10].FindControl("TxtIGSTAmount");
                    TextBox T_AMTString = (TextBox)row.Cells[12].FindControl("TxtTotalAmount");

                    TextBox TxtKeptQty = (TextBox)row.Cells[14].FindControl("TxtKeptQty");
                    TextBox TxtReturnQty = (TextBox)row.Cells[15].FindControl("TxtReturnQty");
                    TextBox TxtTotalOSQty = (TextBox)row.Cells[16].FindControl("TxtOSQty");

                    HiddenField HfAmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");
                    HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                    HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                    if (TxtDiscPer.Text == string.Empty)
                    {
                        TxtDiscPer.Text = "0";
                    }

                    if (TxtKeptQty.Text == string.Empty)
                    {
                        TxtKeptQty.Text = "0";
                    }
                    if (TxtReturnQty.Text == string.Empty)
                    {
                        TxtReturnQty.Text = "0";
                    }

                    TxtTotalOSQty.Text = Convert.ToString((Convert.ToDouble(txt.Text.Trim()) - Convert.ToDouble(TxtKeptQty.Text.Trim())) + Convert.ToDouble(TxtReturnQty.Text.Trim()));


                    if (CGST_AMTString.Text == string.Empty)
                    {
                        CGST_AMTString.Text = "0";
                    }

                    if (SGST_AMTString.Text == string.Empty)
                    {
                        SGST_AMTString.Text = "0";
                    }
                    if (IGST_AMTString.Text == string.Empty)
                    {
                        IGST_AMTString.Text = "0";
                    }



                    if (txt.Text.Trim() != string.Empty && TxtRateString.Text.Trim() != string.Empty && TxtDiscPer.Text.Trim() != string.Empty)
                    {
                        //  HfAmountString.Value = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtRateString.Text.Trim()));

                        double amt, disamt;
                        amt = (Convert.ToDouble(txt.Text) * Convert.ToDouble(TxtRateString.Text));
                        HfAmountString.Value = Convert.ToString(amt);

                        HfDisAmount.Value = ((amt * Convert.ToDouble(TxtDiscPer.Text)) / 100).ToString();
                        disamt = Convert.ToDouble(HfAmountString.Value) - Convert.ToDouble(HfDisAmount.Value);
                        TxtG_AmountString.Text = disamt.ToString();


                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            CGST_AMTString.Text = ((Convert.ToDouble(TxtG_AmountString.Text.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                            SGST_AMTString.Text = ((Convert.ToDouble(TxtG_AmountString.Text.Trim()) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                            HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();

                            double d;
                            d = ((Convert.ToDouble(TxtG_AmountString.Text.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                            T_AMTString.Text = Convert.ToString(d);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {

                            IGST_AMTString.Text = ((Convert.ToDouble(TxtG_AmountString.Text.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                            HfGSTAmount.Value = IGST_AMTString.Text;
                            T_AMTString.Text = ((Convert.ToDouble(TxtG_AmountString.Text.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();
                        }

                        double lblTotOrderQty = TotalOrderQty();
                        lblSumTotalQty.Text = lblTotOrderQty.ToString();

                        double lblTotGamount = TotalGrossAmount();
                        lblSumTotalGrossAmount.Text = lblTotGamount.ToString();

                        double lblTotCGSTAmt = TotalCGSTAmount();
                        lblSumTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                        double lblTotSGSTAmt = TotalSGSTAmount();
                        lblSumTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                        double lblTotIGSTAmt = TotalIGSTAmount();
                        lblSumTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                        double lblTotAmount = TotalAmount();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();


                        if (lblSumTotalAmount.Text == string.Empty)
                        {
                            lblSumTotalAmount.Text = "0";
                        }
                        else
                        {
                            ViewState["Total_OrderItem_Grid"] = lblSumTotalAmount.Text.Trim();
                            // OrderItemGrid = Convert.ToDecimal(lblSumTotalAmount.Text.Trim());

                        }

                        FillNetAmount();
                        FillOnGridDetailChanged();
                    }


                    else
                    {
                        TxtG_AmountString.Text = Convert.ToString(Convert.ToDouble(0));
                    }
                }
                else
                {
                    //Give Javascript Error message
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Order Quantity should be Greater than 0 and Must be Number..!!');", true);
                    txt.Focus();
                }
            }

            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtRatePerQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                Label lblSumTotalQty = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalQty"));
                Label lblSumTotalGrossAmount = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalGrossAmount"));
                Label lblSumTotalCGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalCGST_AMT"));
                Label lblSumTotalSGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalSGST_AMT"));
                Label lblSumTotalIGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalIGST_AMT"));
                Label lblSumTotalAmount = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalAmount"));

                TextBox TxtQuantityString = (TextBox)row.Cells[3].FindControl("TxtOrderQty");
                TextBox TxtG_AmountString = (TextBox)row.Cells[5].FindControl("TxtGrossAmount");

                TextBox TxtDiscPer = (TextBox)row.Cells[4].FindControl("TxtDiscPer");
                HiddenField HfDisAmount = (HiddenField)row.Cells[0].FindControl("HfDisAmount");

                TextBox CGST_RATEString = (TextBox)row.Cells[6].FindControl("TxtCGSTRate");
                TextBox SGST_RATEString = (TextBox)row.Cells[8].FindControl("TxtSGSTRate");
                TextBox CGST_AMTString = (TextBox)row.Cells[7].FindControl("TxtCGSTAmount");
                TextBox SGST_AMTString = (TextBox)row.Cells[9].FindControl("TxtSGSTAmount");
                TextBox IGST_RATEString = (TextBox)row.Cells[9].FindControl("TxtIGSTRate");
                TextBox IGST_AMTString = (TextBox)row.Cells[10].FindControl("TxtIGSTAmount");
                TextBox T_AMTString = (TextBox)row.Cells[12].FindControl("TxtTotalAmount");

                HiddenField HfAmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");
                HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");


                if (TxtDiscPer.Text == string.Empty)
                {
                    TxtDiscPer.Text = "0";
                }

                if (CGST_AMTString.Text == string.Empty)
                {
                    CGST_AMTString.Text = "0";
                }

                if (SGST_AMTString.Text == string.Empty)
                {
                    SGST_AMTString.Text = "0";
                }
                if (IGST_AMTString.Text == string.Empty)
                {
                    IGST_AMTString.Text = "0";
                }

                if (txt.Text.Trim() != string.Empty && TxtQuantityString.Text.Trim() != string.Empty && TxtDiscPer.Text.Trim() != string.Empty)
                {
                    //  HfAmountString.Value = Convert.ToString(Convert.ToDouble(txt.Text.Trim()) * Convert.ToDouble(TxtQuantityString.Text.Trim()));

                    double amt, disamt;
                    amt = (Convert.ToDouble(txt.Text) * Convert.ToDouble(TxtQuantityString.Text));
                    HfAmountString.Value = Convert.ToString(amt);

                    HfDisAmount.Value = ((amt * Convert.ToDouble(TxtDiscPer.Text)) / 100).ToString();
                    disamt = Convert.ToDouble(HfAmountString.Value) - Convert.ToDouble(HfDisAmount.Value);
                    TxtG_AmountString.Text = disamt.ToString();

                    if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                    {
                        CGST_AMTString.Text = ((Convert.ToDouble(TxtG_AmountString.Text.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                        SGST_AMTString.Text = ((Convert.ToDouble(TxtG_AmountString.Text.Trim()) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                        double d;
                        d = ((Convert.ToDouble(TxtG_AmountString.Text.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                        T_AMTString.Text = Convert.ToString(d);
                    }
                    else if (DdlPartyType.SelectedValue.ToString() == "CST")
                    {

                        IGST_AMTString.Text = ((Convert.ToDouble(TxtG_AmountString.Text.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                        HfGSTAmount.Value = IGST_AMTString.Text;
                        T_AMTString.Text = ((Convert.ToDouble(TxtG_AmountString.Text.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();
                    }

                    double lblTotOrderQty = TotalOrderQty();
                    lblSumTotalQty.Text = lblTotOrderQty.ToString();

                    double lblTotGamount = TotalGrossAmount();
                    lblSumTotalGrossAmount.Text = lblTotGamount.ToString();

                    double lblTotCGSTAmt = TotalCGSTAmount();
                    lblSumTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                    double lblTotSGSTAmt = TotalSGSTAmount();
                    lblSumTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                    double lblTotIGSTAmt = TotalIGSTAmount();
                    lblSumTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                    double lblTotAmount = TotalAmount();
                    lblSumTotalAmount.Text = lblTotAmount.ToString();


                    if (lblSumTotalAmount.Text == string.Empty)
                    {
                        lblSumTotalAmount.Text = "0";
                    }
                    else
                    {

                        ViewState["Total_OrderItem_Grid"] = lblSumTotalAmount.Text.Trim();
                        //  OrderItemGrid = Convert.ToDecimal(lblSumTotalAmount.Text.Trim());

                    }

                    FillNetAmount();
                    FillOnGridDetailChanged();
                }
                else
                {
                    HfAmountString.Value = Convert.ToString(Convert.ToDouble(0));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtDiscPer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                if (validation.ispercentage(txt.Text.Trim()))
                {

                    Label lblSumTotalQty = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalQty"));
                    Label lblSumTotalGrossAmount = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalGrossAmount"));
                    Label lblSumTotalCGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalCGST_AMT"));
                    Label lblSumTotalSGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalSGST_AMT"));
                    Label lblSumTotalIGST_AMT = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalIGST_AMT"));
                    Label lblSumTotalAmount = (Label)(GvOrderItem.FooterRow.FindControl("lblSumTotalAmount"));

                    TextBox TxtRateString = (TextBox)row.Cells[4].FindControl("TxtRatePerQty");
                    TextBox TxtQuantityString = (TextBox)row.Cells[3].FindControl("TxtOrderQty");
                    TextBox TxtG_AmountString = (TextBox)row.Cells[5].FindControl("TxtGrossAmount");

                    TextBox TxtDiscPer = (TextBox)row.Cells[4].FindControl("TxtDiscPer");
                    HiddenField HfDisAmount = (HiddenField)row.Cells[0].FindControl("HfDisAmount");

                    TextBox CGST_RATEString = (TextBox)row.Cells[6].FindControl("TxtCGSTRate");
                    TextBox SGST_RATEString = (TextBox)row.Cells[8].FindControl("TxtSGSTRate");
                    TextBox CGST_AMTString = (TextBox)row.Cells[7].FindControl("TxtCGSTAmount");
                    TextBox SGST_AMTString = (TextBox)row.Cells[9].FindControl("TxtSGSTAmount");
                    TextBox T_AMTString = (TextBox)row.Cells[12].FindControl("TxtTotalAmount");

                    HiddenField HfAmountString = (HiddenField)row.Cells[0].FindControl("HfAmount");
                    HiddenField HfGSTAmount = (HiddenField)row.Cells[0].FindControl("HfGSTAmount");
                    HiddenField HfGSTRate = (HiddenField)row.Cells[0].FindControl("HfGSTRate");

                    if (txt.Text.Trim() != string.Empty && TxtQuantityString.Text.Trim() != string.Empty && TxtRateString.Text.Trim() != string.Empty && TxtDiscPer.Text.Trim() != string.Empty)
                    {
                        //  HfAmountString.Value = Convert.ToString(Convert.ToDouble(TxtRateString.Text.Trim()) * Convert.ToDouble(TxtQuantityString.Text.Trim()));

                        double amt, disamt;
                        amt = (Convert.ToDouble(TxtRateString.Text) * Convert.ToDouble(TxtQuantityString.Text));
                        HfAmountString.Value = Convert.ToString(amt);

                        HfDisAmount.Value = ((amt * Convert.ToDouble(TxtDiscPer.Text)) / 100).ToString();
                        disamt = Convert.ToDouble(HfAmountString.Value) - Convert.ToDouble(HfDisAmount.Value);
                        TxtG_AmountString.Text = disamt.ToString();


                        if (DdlPartyType.SelectedValue.ToString() == "LOCAL")
                        {
                            CGST_AMTString.Text = ((Convert.ToDouble(TxtG_AmountString.Text.Trim()) * Convert.ToDouble(CGST_RATEString.Text)) / 100).ToString();
                            SGST_AMTString.Text = ((Convert.ToDouble(TxtG_AmountString.Text.Trim()) * Convert.ToDouble(SGST_RATEString.Text)) / 100).ToString();
                            HfGSTAmount.Value = (Convert.ToDouble(CGST_AMTString.Text.Trim()) + Convert.ToDouble(SGST_AMTString.Text.Trim())).ToString();
                            double d;
                            d = ((Convert.ToDouble(TxtG_AmountString.Text.Trim())) + (Convert.ToDouble(CGST_AMTString.Text)) + (Convert.ToDouble(SGST_AMTString.Text)));
                            T_AMTString.Text = Convert.ToString(d);
                        }
                        else if (DdlPartyType.SelectedValue.ToString() == "CST")
                        {
                            TextBox IGST_RATEString = (TextBox)row.Cells[9].FindControl("TxtIGSTRate");
                            TextBox IGST_AMTString = (TextBox)row.Cells[10].FindControl("TxtIGSTAmount");

                            IGST_AMTString.Text = ((Convert.ToDouble(TxtG_AmountString.Text.Trim()) * Convert.ToDouble(IGST_RATEString.Text)) / 100).ToString();
                            HfGSTAmount.Value = IGST_AMTString.Text;
                            T_AMTString.Text = ((Convert.ToDouble(TxtG_AmountString.Text.Trim())) + (Convert.ToDouble(IGST_AMTString.Text))).ToString();
                        }

                        double lblTotOrderQty = TotalOrderQty();
                        lblSumTotalQty.Text = lblTotOrderQty.ToString();

                        double lblTotGamount = TotalGrossAmount();
                        lblSumTotalGrossAmount.Text = lblTotGamount.ToString();

                        double lblTotCGSTAmt = TotalCGSTAmount();
                        lblSumTotalCGST_AMT.Text = lblTotCGSTAmt.ToString();

                        double lblTotSGSTAmt = TotalSGSTAmount();
                        lblSumTotalSGST_AMT.Text = lblTotSGSTAmt.ToString();

                        double lblTotIGSTAmt = TotalIGSTAmount();
                        lblSumTotalIGST_AMT.Text = lblTotIGSTAmt.ToString();

                        double lblTotAmount = TotalAmount();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();


                        if (lblSumTotalAmount.Text == string.Empty)
                        {
                            lblSumTotalAmount.Text = "0";
                        }
                        else
                        {

                            ViewState["Total_OrderItem_Grid"] = lblSumTotalAmount.Text.Trim();
                            //   OrderItemGrid = Convert.ToDecimal(lblSumTotalAmount.Text.Trim());

                        }

                        FillNetAmount();
                        FillOnGridDetailChanged();
                    }
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

        protected void TxtKeptQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtOrderQty = (TextBox)row.Cells[3].FindControl("TxtOrderQty");
                TextBox TxtReturnQty = (TextBox)row.Cells[14].FindControl("TxtReturnQty");
                TextBox TxtTotalOSQty = (TextBox)row.Cells[15].FindControl("TxtOSQty");


                if (txt.Text.Trim() != string.Empty && TxtOrderQty.Text.Trim() != string.Empty)
                {
                    string keptqty;

                    keptqty = Convert.ToString(Convert.ToDouble(TxtOrderQty.Text.Trim()) - Convert.ToDouble(txt.Text.Trim()));
                    TxtTotalOSQty.Text = Convert.ToString(Convert.ToDouble(keptqty.ToString()) + Convert.ToDouble(TxtReturnQty.Text.Trim()));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtReturnQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtOrderQty = (TextBox)row.Cells[3].FindControl("TxtOrderQty");
                TextBox TxtKeptQty = (TextBox)row.Cells[13].FindControl("TxtKeptQty");
                TextBox TxtTotalOSQty = (TextBox)row.Cells[15].FindControl("TxtOSQty");

                if (TxtKeptQty.Text.Trim() != string.Empty && TxtOrderQty.Text.Trim() != string.Empty)
                {
                    string keptqty;

                    keptqty = Convert.ToString(Convert.ToDouble(TxtOrderQty.Text.Trim()) - Convert.ToDouble(TxtKeptQty.Text.Trim()));
                    TxtTotalOSQty.Text = Convert.ToString(Convert.ToDouble(keptqty.ToString()) + Convert.ToDouble(txt.Text.Trim()));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        protected void btnprint_Click(object sender, EventArgs e)
        {
           
      //      Response.Redirect("~/reportviewPages/Purchase_Order.aspx");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../reportviewPages/Purchase_Order.aspx', '_blank');", true);
        }

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtSearch.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtSearch);
                    Dv.RowFilter = "AccountName like '%" + TxtSearch.Text.Trim() + "%' OR Convert(ORD_NO,'System.String') like '%" + TxtSearch.Text.Trim() + "%' OR PersonName Like '" + TxtSearch.Text.Trim() + "' ";
                    GvOrder_Master.DataSource = Dv.ToTable();
                    GvOrder_Master.DataBind();
                }
                else
                {
                    GvOrder_Master.DataSource = DtSearch;
                    GvOrder_Master.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtValidityDays_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime add_Months = Convert.ToDateTime(DateTime.Now).AddDays(Convert.ToDouble(TxtValidityDays.Text));
                TxtValidityDate.Text = add_Months.ToString("dd/MM/yyyy");

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtValidityDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime Curr_Date = Convert.ToDateTime(DateTime.Now.Date);
                DateTime Val_Date = Convert.ToDateTime(TxtValidityDate.Text);
                TimeSpan diff = Val_Date - Curr_Date;
                //Response.Write(diff.Days);
                TxtValidityDays.Text = (diff.Days).ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtOrderDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string OrderNo = ORDER_MASLogicLayer.GetOrderNoORDER_MASDetailCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtOrderDate.Text.Trim()).ToString("yyyy-MM-dd"),HfTransType.Value.ToString());
                if (OrderNo.Length <= 8)
                {
                    TxtOrderNo.Text = OrderNo;
                }
                else
                {
                    TxtOrderNo.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillAddQuotationGridrPopup()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = QUOTATION_MLogicLayer.GetAllQUOATATION_MASDetialsByACODE(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), HfACODE.Value.ToString());
                GvAddQuotationDetails.DataSource = Dt;
                GvAddQuotationDetails.DataBind();

                //ViewState["AddQuotationTable"] = Dt;

                //if (ViewState["AddQuotationTable"] != null)
                //{
                //    foreach (GridViewRow row in GvAddQuotationDetails.Rows)
                //    {
                //        if (row.RowType == DataControlRowType.DataRow)
                //        {
                //            HiddenField HfQuoTranDate = row.FindControl("HfQuoTranDate") as HiddenField;
                //            HiddenField HfQuoTranNo = row.FindControl("HfQuoTranNo") as HiddenField;
                //            CheckBox ChkQuotationNo = row.FindControl("ChkQuotationNo") as CheckBox;


                //            DataTable Dt1 = (DataTable)ViewState["AddQuotationTable"];
                //            if (Dt1.Rows.Count > 0)
                //            {
                //                DataView Dv = new DataView(Dt1);
                //                Dv.RowFilter = "DCTransNo='" + HfQuoTranNo.Value + "' and DCTransDate='" + HfQuoTranDate.Value + "'";
                //                DataTable DtFIlter = Dv.ToTable();
                //                if (DtFIlter.Rows.Count > 0)
                //                {
                //                    ChkQuotationNo.Checked = true;
                //                }
                //            }
                //        }
                //   }
               // }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnAddQuotation_Click(object sender, EventArgs e)
        {

            try
            {
                if (HfACODE.Value == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SelectionAlert", "SelectionAlert()", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelAddQoutation", "ShowModelAddQoutation()", true);
                    FillAddQuotationGridrPopup();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAddQuotationProcess_Click(object sender, EventArgs e)
        {
            try
            {

                ViewState["AddQuotationTable"] = null;

                DataTable tblQuoat = new DataTable();


                #region Define Table

                DataRow drQuotation = null;
                tblQuoat.Columns.Add("QUOTranDate", typeof(string));
                tblQuoat.Columns.Add("QUOTranNo", typeof(string));

                #endregion

                DataTable table = new DataTable();

                #region Define Table For Product Details

                DataRow dr = null;
                table.Columns.Add("COMP_CODE", typeof(string));
                table.Columns.Add("TRAN_DATE", typeof(string));
                table.Columns.Add("TRAN_NO", typeof(string));
                table.Columns.Add("SRNO", typeof(string));
                table.Columns.Add("ADD_PART_NO", typeof(string));
                table.Columns.Add("SCODE", typeof(string));
                table.Columns.Add("UOM", typeof(string));
                table.Columns.Add("QTY", typeof(string));
                table.Columns.Add("RATE", typeof(string));
                table.Columns.Add("AMT", typeof(string));
                table.Columns.Add("DIS_PER", typeof(string));
                table.Columns.Add("DIS_AMT", typeof(string));
                table.Columns.Add("G_AMT", typeof(string));
                table.Columns.Add("CGST_RATE", typeof(string));
                table.Columns.Add("GST_AMT", typeof(string));
                table.Columns.Add("GST_RATE", typeof(string));
                table.Columns.Add("CGST_AMT", typeof(string));
                table.Columns.Add("SGST_RATE", typeof(string));
                table.Columns.Add("SGST_AMT", typeof(string));
                table.Columns.Add("IGST_RATE", typeof(string));
                table.Columns.Add("IGST_AMT", typeof(string));
                table.Columns.Add("T_AMT", typeof(string));
                table.Columns.Add("KEPT_QTY", typeof(string));
                table.Columns.Add("REJ_QTY", typeof(string));
                table.Columns.Add("STATUS", typeof(string));
                table.Columns.Add("OS_QTY", typeof(string));

                #endregion

                foreach (GridViewRow row in GvAddQuotationDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfQuoTranDate = row.FindControl("HfQuoTranDate") as HiddenField;
                        HiddenField HfQuoTranNo = row.FindControl("HfQuoTranNo") as HiddenField;
                        CheckBox ChkQuotationNo = row.FindControl("ChkQuotationNo") as CheckBox;


                        if (ChkQuotationNo.Checked == true)
                        {
                            drQuotation = tblQuoat.NewRow();
                            drQuotation["QUOTranDate"] = HfQuoTranDate.Value.ToString();
                            drQuotation["QUOTranNo"] = HfQuoTranNo.Value.ToString();
                            tblQuoat.Rows.Add(drQuotation);


                            ViewState["AddQuotationTable"] = tblQuoat;


                            DataSet ds = QUOTATION_MLogicLayer.GetAllIDWiseQUOATATION_MASDetials(HfQuoTranNo.Value.ToString(), Convert.ToDateTime(HfQuoTranDate.Value.ToString()));
                            DataTable dt = ds.Tables[0];
                            DataTable dtOt = ds.Tables[1];

                            if (dtOt.Rows.Count > 0)
                            {

                                for (int i = 0; i < dtOt.Rows.Count; i++)
                                {

                                    #region Assign Value to Table

                                    dr = table.NewRow();

                                    dr["COMP_CODE"] = dtOt.Rows[i]["COMP_CODE"].ToString();
                                    //dr["TRAN_DATE"] = dtOt.Rows[i]["TRAN_DATE"].ToString();
                                    //dr["TRAN_NO"] = dtOt.Rows[i]["TRAN_NO"].ToString();
                                    //dr["SRNO"] = dtOt.Rows[i]["SRNO"].ToString();
                                    dr["ADD_PART_NO"] = string.Empty; 
                                    dr["SCODE"] = dtOt.Rows[i]["SCODE"].ToString();
                                    dr["UOM"] = string.Empty;
                                    dr["QTY"] = dtOt.Rows[i]["QTY"].ToString();
                                    dr["RATE"] = dtOt.Rows[i]["RATE"].ToString();
                                    dr["AMT"] = dtOt.Rows[i]["AMT"].ToString();
                                    dr["DIS_AMT"] =dtOt.Rows[i]["DISC_AMT"].ToString();
                                    dr["DIS_PER"] = dtOt.Rows[i]["DISC_PER"].ToString();
                                    dr["G_AMT"] = dtOt.Rows[i]["G_AMT"].ToString();
                                    dr["GST_RATE"] = dtOt.Rows[i]["GST_RATE"].ToString();
                                    dr["GST_AMT"] = dtOt.Rows[i]["GST_AMT"].ToString();
                                    dr["CGST_RATE"] = dtOt.Rows[i]["CGST_RATE"].ToString();
                                    dr["CGST_AMT"] = dtOt.Rows[i]["CGST_AMT"].ToString();
                                    dr["SGST_RATE"] = dtOt.Rows[i]["SGST_RATE"].ToString();
                                    dr["SGST_AMT"] = dtOt.Rows[i]["SGST_AMT"].ToString();
                                    dr["IGST_RATE"] = dtOt.Rows[i]["IGST_RATE"].ToString();
                                    dr["IGST_AMT"] = dtOt.Rows[i]["IGST_AMT"].ToString();
                                    dr["T_AMT"] = dtOt.Rows[i]["T_AMT"].ToString();
                                    dr["KEPT_QTY"] = string.Empty;
                                    dr["REJ_QTY"] = string.Empty;
                                    dr["STATUS"] = string.Empty;
                                    dr["OS_QTY"] = string.Empty;


                                    #endregion

                                    table.Rows.Add(dr);

                                }

                                ViewState["CurrentTable"] = table;

                            }

                         }
                    }

                }


                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideModelAddQoutation", "HideModelAddQoutation()", true);

                GvOrderItem.DataSource = table;
                GvOrderItem.DataBind();

                DivEntry.Visible = true;
                DivView.Visible = false;


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}