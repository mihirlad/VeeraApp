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
using MihirValid;

namespace VeeraApp.Admin
{
    public partial class AssemblyTransaction : System.Web.UI.Page
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
                    FillDdlPersonName();
                    SetInitialRow();
                    SetInitialRowBarcodeGrid();
                    HfTranType.Value = "A";
                    CalendarExtenderAssembleDate.StartDate = Convert.ToDateTime(Session["FIN_YEAR"].ToString());
                    CalendarExtenderAssembleDate.EndDate = Convert.ToDateTime(Session["FIN_YEAR_END"].ToString());
                    FillASSEMBLE_TRANMasterGrid(Session["COMP_CODE"].ToString());
                    ViewState["BarcodeTemp"] = null;
                    ViewState["CurrentTable"] = null;
                    
                }
            }

            else
            {
                Response.Redirect("../Login.aspx");
            }



            if(Session["WORK_VIEWFLAG"].ToString() == "B")
            {
                barcodegrid.Visible = true;
                BtnAddBarcode.Visible = true;
                BtnViewBarcode.Visible = true;
                BtnReturnBarcode.Visible = true;
                TxtPartAmount.Visible = true;
                TxtLabourAmount.Visible = true;
                lblPartAmount.Visible = true;
                lblLabourAmount.Visible = true;
                lblTotalAss_Amt.Text = "Total Assembly Amount";
            }
            else if (Session["WORK_VIEWFLAG"].ToString() == "I")
            {
                barcodegrid.Visible = false;
                BtnAddBarcode.Visible = false;
                BtnViewBarcode.Visible = false;
                BtnReturnBarcode.Visible = false;
                TxtPartAmount.Visible = false;
                TxtLabourAmount.Visible = false;
                lblPartAmount.Visible = false;
                lblLabourAmount.Visible = false;
                lblTotalAss_Amt.Text = "Amount";
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
            TxtTotalAss_Amt.Text = string.Empty;
            DdlPreparedBy.SelectedIndex = 0;
            TxtRemark.Text = string.Empty;
            TxtPartAmount.Text = string.Empty;
            TxtLabourAmount.Text = string.Empty;
            TxtAuthorisedDate.Text = string.Empty;
            TxtAuthorisedBy.Text = string.Empty;
            DdlAuthoriseFlag.SelectedValue = "N";
            DdlConfirmFlag.SelectedValue = "N";
            TxtConfirmDate.Text = string.Empty;
            TxtConfirmBy.Text = string.Empty;

            SetInitialRow();
            SetInitialRowBarcodeGrid();
            BtncallUpd.Text = "SAVE";

        }


        public void ControllerEnable()
        {
            TxtSrNo.Enabled = true;
            TxtAssemblyDate.Enabled = true;
            TxtProductCode.Enabled = true;
            TxtProductName.Enabled = true;
            TxtQty.Enabled = true;
            TxtRate.Enabled = true;
            TxtTotalAss_Amt.Enabled = true;
            DdlPreparedBy.Enabled = true;
            TxtRemark.Enabled = true;
            TxtPartAmount.Enabled = true;
            TxtLabourAmount.Enabled = true;
            TxtAuthorisedBy.Enabled = true;
            TxtAuthorisedDate.Enabled = true;
            DdlAuthoriseFlag.Enabled = true;
            DdlConfirmFlag.Enabled = true;
            TxtConfirmDate.Enabled = true;
            TxtConfirmBy.Enabled = true;

            GvNewBarcodeGrid.Enabled = true;
        }


        public void ControllerDisable()
        {
            TxtSrNo.Enabled = false;
            TxtAssemblyDate.Enabled = false;
            TxtProductCode.Enabled = false;
            TxtProductName.Enabled = false;
            TxtQty.Enabled = false;
            TxtRate.Enabled = false;
            TxtTotalAss_Amt.Enabled = false;
            DdlPreparedBy.Enabled = false;
            TxtRemark.Enabled = false;
            TxtPartAmount.Enabled = false;
            TxtLabourAmount.Enabled = false;
            TxtAuthorisedBy.Enabled = false;
            TxtAuthorisedDate.Enabled = false;
            DdlAuthoriseFlag.Enabled = false;
            DdlConfirmFlag.Enabled = false;
            TxtConfirmDate.Enabled = false;
            TxtConfirmBy.Enabled = false;
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




        private double TotalPartAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvAssemblyTransDetails.Rows.Count; i++)
            {
                string total = (GvAssemblyTransDetails.Rows[i].FindControl("TxtAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);

            }
            return GTotal;

        }

        protected void TxtQty_TextChanged(object sender, EventArgs e)
        {
            if (TxtTotalAss_Amt.Text == string.Empty)
            {
                TxtTotalAss_Amt.Text = "0";
            }
            else
            {
                TxtRate.Text = Convert.ToString(Convert.ToDouble(TxtTotalAss_Amt.Text) / Convert.ToDouble(TxtQty.Text));
            }
        }

        protected void TxtLabourAmount_TextChanged(object sender, EventArgs e)
        {
            Label lblSumTotalAmount = (Label)(GvAssemblyTransDetails.FooterRow.FindControl("lblSumTotalAmount"));

            double lblTotAmount = TotalPartAmount();
            lblSumTotalAmount.Text = lblTotAmount.ToString();

            if (TxtLabourAmount.Text != string.Empty)
            {

                TxtTotalAss_Amt.Text = Convert.ToString(Convert.ToDouble(lblSumTotalAmount.Text) + Convert.ToDouble(TxtLabourAmount.Text));
            }

            if (TxtQty.Text == string.Empty)
            {
                TxtQty.Text = "0";
            }
            else
            {
                TxtRate.Text = Convert.ToString(Convert.ToDouble(TxtTotalAss_Amt.Text) / Convert.ToDouble(TxtQty.Text));
            }

        }

        public void FillASSEMBLE_TRANMasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = ASS_TRANMASLogicLayer.GetAllASSEMBLE_TRAN_MASDetails(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()), HfTranType.Value.ToString());
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvAssembleTransactionMaster.DataSource = Dv.ToTable();
            GvAssembleTransactionMaster.DataBind();

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
                BtnAddBarcode.Enabled = true;
                BtnViewBarcode.Enabled = true;
                BtnReturnBarcode.Enabled = true;
                TxtAssemblyDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            
                string ASSEMBLE_SRNO = ASS_TRANMASLogicLayer.GetSrNo_ForAssembleTransaction(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtAssemblyDate.Text.Trim()).ToString("yyyy-MM-dd"), HfTranType.Value);
                if (ASSEMBLE_SRNO.Length <= 8)
                {
                    TxtSrNo.Text = ASSEMBLE_SRNO;
                }
                else
                {
                    TxtSrNo.Text = string.Empty;
                }

                //ViewState["CurrentTable"] = null;
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
                DataTable DtProduct = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
                if (TxtProductCode.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtProduct);
                    Dv.RowFilter = "PROD_CODE='" + TxtProductCode.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        hfSCODE.Value = DtView.Rows[0]["SCODE"].ToString();
                        TxtProductName.Text = DtView.Rows[0]["SNAME"].ToString();
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
            SqlCommand cmd = new SqlCommand("select * from STOCK_MAS where COMP_CODE=@COMP_CODE and sname like  @name + '%'", con);
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
                DataTable DtProductCode = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtProductCode = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
                if (TxtProductName.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtProductCode);
                    Dv.RowFilter = "SNAME='" + TxtProductName.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        hfSCODE.Value = DtView.Rows[0]["SCODE"].ToString();
                        TxtProductCode.Text = DtView.Rows[0]["PROD_CODE"].ToString();
                    }
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

                    if (TxtTotalAss_Amt.Text == string.Empty)
                    {
                        insert.AMT = "0";
                    }
                    else
                    {
                        insert.AMT = TxtTotalAss_Amt.Text.Trim();
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
                    if (TxtPartAmount.Text == string.Empty)
                    {
                        insert.PART_AMT = "0";
                    }
                    else
                    {
                        insert.PART_AMT = TxtPartAmount.Text.Trim();
                    }

                    if (TxtLabourAmount.Text == string.Empty)
                    {
                        insert.LAB_AMT = "0";
                    }
                    else
                    {
                        insert.LAB_AMT = TxtLabourAmount.Text.Trim();
                    }

                    insert.BAR_TRAN_DATE = null;
                    insert.BAR_TRAN_NO = null;
                    insert.BAR_SRNO = null;

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
                    foreach (GridViewRow row in GvAssemblyTransDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                            HiddenField HfTransNo = row.FindControl("HfTransNo") as HiddenField;
                            HiddenField HfStatus = row.FindControl("HfStatus") as HiddenField;
                            HiddenField HfPer = row.FindControl("HfPer") as HiddenField;
                            HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                            HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;

                            TextBox TxtProductCode = row.FindControl("TxtProductCode") as TextBox;
                            TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                            TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtAmount = row.FindControl("TxtAmount") as TextBox;

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

                                if (TxtRate.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("RATE", (TxtRate.Text));
                                }

                                if (TxtAmount.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("AMT", (TxtAmount.Text));
                                }

                                HandleDetail2.SetAttribute("STATUS", ("O"));

                                root1.AppendChild(HandleDetail2);
                                SRNODETAIL++;
                            }

                        }
                    }

                    #endregion


                    #region INSERT ASS_TRAN BARCODE DETAILS 


                    XmlDocument XDoc3 = new XmlDocument();
                    XmlDeclaration dec3 = XDoc3.CreateXmlDeclaration("1.0", null, null);
                    XDoc3.AppendChild(dec3);// Create the root element
                    XmlElement root3 = XDoc3.CreateElement("root");
                    XDoc3.AppendChild(root3);
                    int SRNOBARCODE = 1;
                    double TotalAmt;
                    if (ViewState["BarcodeTemp"] != null)
                    {
                        DataTable DtBarcodeTemp = (DataTable)ViewState["BarcodeTemp"];
                        if (DtBarcodeTemp.Rows.Count > 0)
                        {
                            for (int i = 0; i < DtBarcodeTemp.Rows.Count; i++)
                            {
                                //DtBarcodeTemp.Columns.Add("BARCODE", typeof(string));
                                //DtBarcodeTemp.Columns.Add("QTY", typeof(string));
                                //DtBarcodeTemp.Columns.Add("SCODE", typeof(string));
                                //DtBarcodeTemp.Columns.Add("BAR_TRAN_DATE", typeof(string));
                                //DtBarcodeTemp.Columns.Add("BAR_TRAN_NO", typeof(string));
                                //DtBarcodeTemp.Columns.Add("BAR_SRNO", typeof(string));

                                XmlElement HandleDetail4 = XDoc3.CreateElement("BarcodeDetails");

                                if (DtBarcodeTemp.Rows[i]["BARCODE"].ToString() != string.Empty)
                                {
                                    HandleDetail4.SetAttribute("SRNO", SRNOBARCODE.ToString());
                                    HandleDetail4.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                    //    HandleDetail4.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                    //    HandleDetail4.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());


                                    HandleDetail4.SetAttribute("BAR_TRAN_DATE", Convert.ToDateTime(DtBarcodeTemp.Rows[i]["BAR_TRAN_DATE"].ToString()).ToString("MM-dd-yyyy"));


                                    if (DtBarcodeTemp.Rows[i]["BAR_TRAN_NO"].ToString() == string.Empty)
                                    {
                                        HandleDetail4.SetAttribute("BAR_TRAN_NO", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail4.SetAttribute("BAR_TRAN_NO", (DtBarcodeTemp.Rows[i]["BAR_TRAN_NO"].ToString()));
                                    }


                                    if (DtBarcodeTemp.Rows[i]["BAR_SRNO"].ToString() == string.Empty)
                                    {
                                        HandleDetail4.SetAttribute("BAR_SRNO", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail4.SetAttribute("BAR_SRNO", (DtBarcodeTemp.Rows[i]["BAR_SRNO"].ToString()));
                                    }

                                    if (DtBarcodeTemp.Rows[i]["QTY"].ToString() == string.Empty)
                                    {
                                        HandleDetail4.SetAttribute("QTY", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail4.SetAttribute("QTY", (DtBarcodeTemp.Rows[i]["QTY"].ToString()));
                                    }

                                    if (DtBarcodeTemp.Rows[i]["RATE"].ToString() == string.Empty)
                                    {
                                        HandleDetail4.SetAttribute("RATE", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail4.SetAttribute("RATE", (DtBarcodeTemp.Rows[i]["RATE"].ToString()));
                                    }

                                    TotalAmt = Convert.ToDouble(DtBarcodeTemp.Rows[i]["RATE"])* Convert.ToDouble(DtBarcodeTemp.Rows[i]["QTY"]);

                                    if (TotalAmt.ToString() == string.Empty)
                                    {
                                        HandleDetail4.SetAttribute("AMT", ("0"));
                                    }
                                    else
                                    {
                                        HandleDetail4.SetAttribute("AMT", (TotalAmt.ToString()));
                                    }

                                    root3.AppendChild(HandleDetail4);
                                    SRNOBARCODE++;
                                }
                            }
                        }

                    }
                    #endregion

                    string str = ASS_TRANMASLogicLayer.InsertASSEMBLE_TRAN_MASDetailNew(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc3.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"), HfTranType.Value, Session["WORK_VIEWFLAG"].ToString());

                    //string P_Type = "I";
                    //if (str != null)
                    //{
                    //    if (str.Tables.Count > 0)
                    //    {
                    //        DataTable DtDetail = str.Tables[0];
                    //        if (Session["WORK_VIEWFLAG"].ToString() == "B")
                    //        {
                    //            for (int d = 0; d < DtDetail.Rows.Count; d++)
                    //            {

                    //                string BarCodeStr = DC_MASLogicLayer.GenerateBracodeForPurchaseOrder(P_Type.ToString(), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()), TxtSrNo.Text, DtDetail.Rows[d]["SCODE"].ToString(), DtDetail.Rows[d]["QTY"].ToString(), DtDetail.Rows[d]["RATE"].ToString(), HfTranType.Value.ToString(), Convert.ToDateTime(DtDetail.Rows[d]["TRAN_DATE"].ToString()), DtDetail.Rows[d]["TRAN_NO"].ToString(), DtDetail.Rows[d]["SRNO"].ToString());
                    //            }
                    //        }

                    //    }

                        if (str.Contains("successfully"))
                        {
                        lblmsg.Text = "ASSEMBLE TRANSACTION SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillASSEMBLE_TRANMasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "ASSEMBLE TRANSACTION MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : ASSEMBLE TRANSACTION MASTER NOT SAVED";
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


        protected void GvAssembleTransactionMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvAssembleTransactionMaster.PageIndex = e.NewPageIndex;
            clear();
            FillASSEMBLE_TRANMasterGrid(Session["COMP_CODE"].ToString());
        }

        protected void GvAssembleTransactionMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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


                        DataSet ds = ASS_TRANMASLogicLayer.GetAllIDWiseASSEMBLE_TRAN_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
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
                            TxtSrNo.Text = dt.Rows[0]["SRNO"].ToString();
                            TxtAssemblyDate.Text = Convert.ToDateTime(dt.Rows[0]["TRNDT"].ToString()).ToString("dd-MM-yyyy");
                            FillProductNameOnUpdate(dt.Rows[0]["SCODE"].ToString());
                            TxtQty.Text = dt.Rows[0]["QTY"].ToString();
                            TxtRate.Text = dt.Rows[0]["RATE"].ToString();
                            TxtTotalAss_Amt.Text = dt.Rows[0]["AMT"].ToString();
                            DdlPreparedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtPartAmount.Text = dt.Rows[0]["PART_AMT"].ToString();
                            TxtLabourAmount.Text = dt.Rows[0]["LAB_AMT"].ToString();
                            TxtAuthorisedDate.Text = dt.Rows[0]["AUTH_DATE"].ToString();
                            TxtAuthorisedBy.Text = dt.Rows[0]["AUTH_USERID"].ToString();
                            DdlAuthoriseFlag.SelectedValue = dt.Rows[0]["AUTH_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString(); //Convert.ToDateTime(dt.Rows[0]["CONF_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();

                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value.ToString();
                            Session["TRAN_TYPE"] = HfTranType.Value.ToString();

                            if (DtPartDetails.Rows.Count > 0)
                            {
                                GvAssemblyTransDetails.DataSource = DtPartDetails;
                                GvAssemblyTransDetails.DataBind();
                                GvAssemblyTransDetails.Enabled = false;
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
                            BtnAddBarcode.Enabled = false;
                            BtnViewBarcode.Enabled = true;
                            BtnReturnBarcode.Enabled = false;
                            ControllerDisable();

                            #endregion
                        }
                    }
                }


                if (e.CommandName == "Edita")
                {
                    #region Edita
                    //     clear();

                    int id = int.Parse(e.CommandArgument.ToString());

                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = ASS_TRANMASLogicLayer.GetAllIDWiseASSEMBLE_TRAN_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtPartDetails = ds.Tables[1];
                        DataTable DtPartDetailsBarcode = ds.Tables[2];
                        DataTable NewBracode = ds.Tables[3];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtSrNo.Text = dt.Rows[0]["SRNO"].ToString();
                            TxtAssemblyDate.Text = Convert.ToDateTime(dt.Rows[0]["TRNDT"].ToString()).ToString("dd-MM-yyyy");
                            FillProductNameOnUpdate(dt.Rows[0]["SCODE"].ToString());
                            TxtQty.Text = dt.Rows[0]["QTY"].ToString();
                            TxtRate.Text = dt.Rows[0]["RATE"].ToString();
                            TxtTotalAss_Amt.Text = dt.Rows[0]["AMT"].ToString();
                            DdlPreparedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtPartAmount.Text = dt.Rows[0]["PART_AMT"].ToString();
                            TxtLabourAmount.Text = dt.Rows[0]["LAB_AMT"].ToString();
                            TxtAuthorisedDate.Text = dt.Rows[0]["AUTH_DATE"].ToString();
                            TxtAuthorisedBy.Text = dt.Rows[0]["AUTH_USERID"].ToString();
                            DdlAuthoriseFlag.SelectedValue = dt.Rows[0]["AUTH_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString(); //Convert.ToDateTime(dt.Rows[0]["CONF_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
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
                                GvAssemblyTransDetails.DataSource = DtPartDetails;
                                GvAssemblyTransDetails.DataBind();
                                GvAssemblyTransDetails.Enabled = false;

                            }

                            if(DtPartDetailsBarcode.Rows.Count > 0)
                            {
                                ViewState["BarcodeTemp"] = DtPartDetailsBarcode;
                            }

                            if (NewBracode.Rows.Count > 0)
                            {                  
                                GvNewBarcodeGrid.DataSource = NewBracode;
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
                    BtnAddBarcode.Enabled = true;
                    BtnViewBarcode.Enabled = true;
                    BtnReturnBarcode.Enabled = true;

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


                        DataSet ds = ASS_TRANMASLogicLayer.GetAllIDWiseASSEMBLE_TRAN_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
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
                            TxtSrNo.Text = dt.Rows[0]["SRNO"].ToString();
                            TxtAssemblyDate.Text = Convert.ToDateTime(dt.Rows[0]["TRNDT"].ToString()).ToString("dd-MM-yyyy");
                            FillProductNameOnUpdate(dt.Rows[0]["SCODE"].ToString());
                            TxtQty.Text = dt.Rows[0]["QTY"].ToString();
                            TxtRate.Text = dt.Rows[0]["RATE"].ToString();
                            TxtTotalAss_Amt.Text = dt.Rows[0]["AMT"].ToString();
                            DdlPreparedBy.SelectedValue = dt.Rows[0]["BCODE"].ToString();
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            TxtPartAmount.Text = dt.Rows[0]["PART_AMT"].ToString();
                            TxtLabourAmount.Text = dt.Rows[0]["LAB_AMT"].ToString();
                            TxtAuthorisedDate.Text = dt.Rows[0]["AUTH_DATE"].ToString();
                            TxtAuthorisedBy.Text = dt.Rows[0]["AUTH_USERID"].ToString();
                            DdlAuthoriseFlag.SelectedValue = dt.Rows[0]["AUTH_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString(); //Convert.ToDateTime(dt.Rows[0]["CONF_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();

                            Session["TRAN_NO"] = e.CommandArgument.ToString();
                            Session["TRAN_DATE"] = HfTranDateGrid.Value.ToString();
                            Session["TRAN_TYPE"] = HfTranType.Value.ToString();

                            if (DtPartDetails.Rows.Count > 0)
                            {
                                GvAssemblyTransDetails.DataSource = DtPartDetails;
                                GvAssemblyTransDetails.DataBind();
                                GvAssemblyTransDetails.Enabled = false;
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
                    BtnAddBarcode.Enabled = false;
                    BtnViewBarcode.Enabled = true;
                    BtnReturnBarcode.Enabled = false;
                    UserRights();
                }
            }
            catch (Exception ex)
            {

                lblmsg.Text = ex.Message.ToString();
            }
        }

        protected void GvAssembleTransactionMaster_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    FillASSEMBLE_TRANMasterGrid(Session["COMP_CODE"].ToString());
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
                #region UPDATE ASSEMBLE TRANSACTION 

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

                if (TxtTotalAss_Amt.Text == string.Empty)
                {
                    insert.AMT = "0";
                }
                else
                {
                    insert.AMT = TxtTotalAss_Amt.Text.Trim();
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
                if (TxtPartAmount.Text == string.Empty)
                {
                    insert.PART_AMT = "0";
                }
                else
                {
                    insert.PART_AMT = TxtPartAmount.Text.Trim();
                }

                if (TxtLabourAmount.Text == string.Empty)
                {
                    insert.LAB_AMT = "0";
                }
                else
                {
                    insert.LAB_AMT = TxtLabourAmount.Text.Trim();
                }

                insert.BAR_TRAN_DATE = null;
                insert.BAR_TRAN_NO = null;
                insert.BAR_SRNO = null;

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
                foreach (GridViewRow row in GvAssemblyTransDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfTranDate = row.FindControl("HfTranDate") as HiddenField;
                        HiddenField HfTransNo = row.FindControl("HfTransNo") as HiddenField;
                        HiddenField HfStatus = row.FindControl("HfStatus") as HiddenField;
                        HiddenField HfPer = row.FindControl("HfPer") as HiddenField;
                        HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;
                        HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;

                        TextBox TxtProductCode = row.FindControl("TxtProductCode") as TextBox;
                        TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                        TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                        TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                        TextBox TxtAmount = row.FindControl("TxtAmount") as TextBox;

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

                            if (TxtRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("RATE", (TxtRate.Text));
                            }

                            if (TxtAmount.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("AMT", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("AMT", (TxtAmount.Text));
                            }

                            HandleDetail2.SetAttribute("STATUS", ("O"));

                            root1.AppendChild(HandleDetail2);
                            SRNODETAIL++;
                        }

                    }
                }

                #endregion


                #region INSERT ASS_TRAN BARCODE DETAILS 


                XmlDocument XDoc3 = new XmlDocument();
                XmlDeclaration dec3 = XDoc3.CreateXmlDeclaration("1.0", null, null);
                XDoc3.AppendChild(dec3);// Create the root element
                XmlElement root3 = XDoc3.CreateElement("root");
                XDoc3.AppendChild(root3);
                int SRNOBARCODE = 1;
                double TotalAmt;
                if (ViewState["BarcodeTemp"] != null)
                {
                    DataTable DtBarcodeTemp = (DataTable)ViewState["BarcodeTemp"];
                    if (DtBarcodeTemp.Rows.Count > 0)
                    {
                        for (int i = 0; i < DtBarcodeTemp.Rows.Count; i++)
                        {
                         
                            XmlElement HandleDetail4 = XDoc3.CreateElement("BarcodeDetails");

                            if (DtBarcodeTemp.Rows[i]["BARCODE"].ToString() != string.Empty)
                            {
                                HandleDetail4.SetAttribute("SRNO", SRNOBARCODE.ToString());
                                HandleDetail4.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                HandleDetail4.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                HandleDetail4.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());


                                HandleDetail4.SetAttribute("BAR_TRAN_DATE", Convert.ToDateTime(DtBarcodeTemp.Rows[i]["BAR_TRAN_DATE"].ToString()).ToString("MM-dd-yyyy"));


                                if (DtBarcodeTemp.Rows[i]["BAR_TRAN_NO"].ToString() == string.Empty)
                                {
                                    HandleDetail4.SetAttribute("BAR_TRAN_NO", ("0"));
                                }
                                else
                                {
                                    HandleDetail4.SetAttribute("BAR_TRAN_NO", (DtBarcodeTemp.Rows[i]["BAR_TRAN_NO"].ToString()));
                                }


                                if (DtBarcodeTemp.Rows[i]["BAR_SRNO"].ToString() == string.Empty)
                                {
                                    HandleDetail4.SetAttribute("BAR_SRNO", ("0"));
                                }
                                else
                                {
                                    HandleDetail4.SetAttribute("BAR_SRNO", (DtBarcodeTemp.Rows[i]["BAR_SRNO"].ToString()));
                                }

                                if (DtBarcodeTemp.Rows[i]["QTY"].ToString() == string.Empty)
                                {
                                    HandleDetail4.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail4.SetAttribute("QTY", (DtBarcodeTemp.Rows[i]["QTY"].ToString()));
                                }

                                if (DtBarcodeTemp.Rows[i]["RATE"].ToString() == string.Empty)
                                {
                                    HandleDetail4.SetAttribute("RATE", ("0"));
                                }
                                else
                                {
                                    HandleDetail4.SetAttribute("RATE", (DtBarcodeTemp.Rows[i]["RATE"].ToString()));
                                }

                                TotalAmt = Convert.ToDouble(DtBarcodeTemp.Rows[i]["RATE"]) * Convert.ToDouble(DtBarcodeTemp.Rows[i]["QTY"]);

                                if (TotalAmt.ToString() == string.Empty)
                                {
                                    HandleDetail4.SetAttribute("AMT", ("0"));
                                }
                                else
                                {
                                    HandleDetail4.SetAttribute("AMT", (TotalAmt.ToString()));
                                }

                                root3.AppendChild(HandleDetail4);
                                SRNOBARCODE++;
                            }
                        }
                    }

                }
                #endregion

                string str = ASS_TRANMASLogicLayer.UpdateASSEMBLE_TRAN_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc3.OuterXml), HfCompCode.Value, HfBranchCode.Value, Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"), HfTranType.Value.ToString(),Session["WORK_VIEWFLAG"].ToString());

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "ASSEMBLE TRANSACTION UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillASSEMBLE_TRANMasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "ASSEMBLE TRANSACTION ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : ASSEMBLE TRANSACTION NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }


                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }



        protected void GvAssemblyTransDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvAssemblyTransDetails.PageIndex = e.NewPageIndex;
            clear();

        }

        protected void GvAssemblyTransDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GvAssemblyTransDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField HfDetailSCode = (e.Row.FindControl("HfDetailSCode") as HiddenField);
                    TextBox TxtProductName = (e.Row.FindControl("TxtProductName") as TextBox);
                    TextBox TxtProductCode = (e.Row.FindControl("TxtProductCode") as TextBox);
                    TextBox TxtRate = (e.Row.FindControl("TxtRate") as TextBox);
                    TextBox TxtQty = (e.Row.FindControl("TxtQty") as TextBox);
                    TextBox TxtAmount = (e.Row.FindControl("TxtAmount") as TextBox);


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



                    if (Session["WORK_VIEWFLAG"].ToString() == "B")
                    {

                        TxtProductName.Enabled = false;
                        TxtProductCode.Enabled = false;
                        TxtRate.Enabled = false;
                        TxtQty.Enabled = false;
                        TxtAmount.Enabled = false;

                    }
                    else
                    {
                        TxtProductName.Enabled = true;
                        TxtProductCode.Enabled = true;
                        TxtRate.Enabled = true;
                        TxtQty.Enabled = true;
                        TxtAmount.Enabled = true;
                    }


                }



                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblSumTotalAmount = (Label)e.Row.FindControl("lblSumTotalAmount");

                    double lblTotRecQty = TotalPartAmount();
                    lblSumTotalAmount.Text = lblTotRecQty.ToString();

                    TxtPartAmount.Text = lblSumTotalAmount.Text;
                    TxtTotalAss_Amt.Text = lblSumTotalAmount.Text;

                    if (TxtLabourAmount.Text != string.Empty)
                    {
                        TxtTotalAss_Amt.Text = Convert.ToString(Convert.ToDouble(TxtPartAmount.Text) + Convert.ToDouble(TxtLabourAmount.Text));

                    }

                    if (TxtQty.Text == string.Empty)
                    {
                        TxtQty.Text = "0";
                    }
                    else
                    {
                        TxtRate.Text = Convert.ToString(Convert.ToDouble(TxtTotalAss_Amt.Text) / Convert.ToDouble(TxtQty.Text));

                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #region ADD NEW ROW IN ASSEMBLE PARTS DETAIL IN GRID

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

            GvAssemblyTransDetails.DataSource = table;
            GvAssemblyTransDetails.DataBind();
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

                        Label lblSumTotalAmount = (Label)(GvAssemblyTransDetails.FooterRow.FindControl("lblSumTotalAmount"));

                        HiddenField HfDetailSCode = (HiddenField)GvAssemblyTransDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtProductCode = (TextBox)GvAssemblyTransDetails.Rows[rowIndex].Cells[1].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvAssemblyTransDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductName");
                        TextBox TxtQty = (TextBox)GvAssemblyTransDetails.Rows[rowIndex].Cells[3].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvAssemblyTransDetails.Rows[rowIndex].Cells[4].FindControl("TxtRate");
                        TextBox TxtAmount = (TextBox)GvAssemblyTransDetails.Rows[rowIndex].Cells[5].FindControl("TxtAmount");
                        HiddenField HfStatus = (HiddenField)GvAssemblyTransDetails.Rows[rowIndex].Cells[0].FindControl("HfStatus");
                        HiddenField HfPer = (HiddenField)GvAssemblyTransDetails.Rows[rowIndex].Cells[0].FindControl("HfPer");

                        //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();


                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = TxtAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["STATUS"] = HfStatus.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["PER"] = HfPer.Value.Trim();

                        rowIndex++;

                        double lblTotAmount = TotalPartAmount();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();

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

                    GvAssemblyTransDetails.DataSource = dtCurrentTable;
                    GvAssemblyTransDetails.DataBind();


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
                        Label lblSumTotalAmount = (Label)(GvAssemblyTransDetails.FooterRow.FindControl("lblSumTotalAmount"));

                        HiddenField HfDetailSCode = (HiddenField)GvAssemblyTransDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtProductCode = (TextBox)GvAssemblyTransDetails.Rows[rowIndex].Cells[1].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvAssemblyTransDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductName");
                        TextBox TxtQty = (TextBox)GvAssemblyTransDetails.Rows[rowIndex].Cells[3].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvAssemblyTransDetails.Rows[rowIndex].Cells[4].FindControl("TxtRate");
                        TextBox TxtAmount = (TextBox)GvAssemblyTransDetails.Rows[rowIndex].Cells[5].FindControl("TxtAmount");
                        HiddenField HfStatus = (HiddenField)GvAssemblyTransDetails.Rows[rowIndex].Cells[0].FindControl("HfStatus");
                        HiddenField HfPer = (HiddenField)GvAssemblyTransDetails.Rows[rowIndex].Cells[0].FindControl("HfPer");


                        HfStatus.Value = dt.Rows[i]["STATUS"].ToString();
                        HfDetailSCode.Value = dt.Rows[i]["SCODE"].ToString();
                        TxtQty.Text = dt.Rows[i]["QTY"].ToString();
                        TxtRate.Text = dt.Rows[i]["RATE"].ToString();
                        TxtAmount.Text = dt.Rows[i]["AMT"].ToString();
                        HfStatus.Value = dt.Rows[i]["PER"].ToString();

                        rowIndex++;

                        double lblTotAmount = TotalPartAmount();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();

                    }
                }
            }
        }


        protected void BtnDeleteRowModelAssemblePartsGrid_Click(object sender, EventArgs e)
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
                GvAssemblyTransDetails.DataSource = dt;
                GvAssemblyTransDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }

        protected void BtnAddRowModelAssemblePartsGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }



        #endregion


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
            //table.Columns.Add("BAR_TRAN_DATE", typeof(string));
            //table.Columns.Add("BAR_TRAN_NO", typeof(string));
            //table.Columns.Add("BAR_SRNO", typeof(string));
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
            //dr["BAR_TRAN_DATE"] = string.Empty;
            //dr["BAR_TRAN_NO"] = string.Empty;
            //dr["BAR_SRNO"] = string.Empty;
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





        protected void AddNewRowBarcodeView()
        {
            try
            {

                if (ViewState["BarcodeTemp"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["BarcodeTemp"];
                    DataRow dr = null;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        dr = dtCurrentTable.NewRow();

                        dr["BARCODE"] = "";
                        dr["QTY"] = "";
                        dr["SCODE"] = "";
                        dr["BAR_TRAN_DATE"] = "";
                        dr["BAR_TRAN_NO"] = "";
                        dr["BAR_SRNO"] = "";
                        dr["RATE"] = "";




                        dtCurrentTable.Rows.Add(dr);
                        ViewState["BarcodeTemp"] = dtCurrentTable;

                        GvViewBarcode.DataSource = dtCurrentTable;
                        GvViewBarcode.DataBind();
                    }
                }
                else
                {
                    Response.Write("ViewState is null");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnAddRowModelBarCode_ViewGrid_Click(object sender, EventArgs e)
        {
            // AddNewRowBarcodeView();
        }

        protected void TxtBarcodeInputNo_TextChanged(object sender, EventArgs e)
        {

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
                  

                    for (int i = 0; i < 50; i++)
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


                for (int i = 0; i < 50; i++)
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
                    // ViewState["BarcodeTemp"] = dt;
                }
                GvViewBarcode.DataSource = dt;
                GvViewBarcode.DataBind();
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
            DivBarcodeInput.Visible = false;

            GvViewBarcode.Columns[3].Visible = true;
        }

        protected void BtnAddBarcode_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelViewBarcode", "ShowModelViewBarcode()", true);
            FillViewBarcodePopup(1);

            btnAddBarcodeProcess.Visible = true;
            btnUploadBarcodeProcess.Visible = true;
            btnReturnBarcodeProcess.Visible = false;
            DivBarcodeInput.Visible = true;
            FileUpload1.Visible = true;


            GvViewBarcode.Columns[3].Visible = false;
        }

        protected void BtnReturnBarcode_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelViewBarcode", "ShowModelViewBarcode()", true);
            FillViewBarcodePopup(2);

            btnAddBarcodeProcess.Visible = false;
            btnUploadBarcodeProcess.Visible = false;
            btnReturnBarcodeProcess.Visible = true;
            DivBarcodeInput.Visible = true;
            FileUpload1.Visible = false;

            GvViewBarcode.Columns[3].Visible = false;
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
                        TextBox TxtRate = row.FindControl("TxtRate") as TextBox;

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
                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;


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
                                    TxtRate.Text= FilterBarcode.Rows[0]["RATE"].ToString();

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
                                            table.Columns.Add("SCODE", typeof(string));
                                            table.Columns.Add("QTY", typeof(string));
                                            table.Columns.Add("RATE", typeof(string));
                                            table.Columns.Add("AMT", typeof(string));
                                            table.Columns.Add("STATUS", typeof(string));
                                            table.Columns.Add("PER", typeof(string));

                                        }
                                    }

                                    string HfAmountString = "";

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

                                                    #region Calculation for change Qty

                                                    if (FilterBarcode.Rows[0]["RATE"].ToString().Trim() != string.Empty)
                                                    {
                                                        HfAmountString = Convert.ToString(Convert.ToDouble(FilterBarcode.Rows[0]["RATE"].ToString().Trim()) * Convert.ToDouble(drlp["QTY"]));
                                                    }

                                                    #endregion

                                                    drlp["AMT"] = HfAmountString;
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
                                            #region Calculation Ammount


                                            if (FilterBarcode.Rows[0]["RATE"].ToString().Trim() != string.Empty)
                                            {
                                                HfAmountString = Convert.ToString(Convert.ToDouble(FilterBarcode.Rows[0]["RATE"].ToString().Trim()) * Convert.ToDouble(1));
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
                                            dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
                                            dr["QTY"] = "1";
                                            dr["RATE"] = FilterBarcode.Rows[0]["RATE"].ToString();
                                            dr["AMT"] = HfAmountString;
                                            dr["STATUS"] = string.Empty;
                                            dr["PER"] = string.Empty;
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
                                        //Add New Row Product
                                        dr = table.NewRow();
                                        dr["COMP_CODE"] = 0;
                                        dr["TRAN_DATE"] = string.Empty;
                                        dr["TRAN_NO"] = string.Empty;
                                        dr["SRNO"] = string.Empty;
                                        dr["SCODE"] = FilterBarcode.Rows[0]["SCODE"].ToString();
                                        dr["QTY"] = "1";
                                        dr["RATE"] = FilterBarcode.Rows[0]["RATE"].ToString();
                                        dr["AMT"] = HfAmountString;
                                        dr["STATUS"] = string.Empty;
                                        dr["PER"] = string.Empty;
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

                                    GvAssemblyTransDetails.DataSource = DtFilterNull;
                                    GvAssemblyTransDetails.DataBind();

                                    #endregion
                                }
                            }
                            else
                            {
                                TxtBarcode.ForeColor = Color.Red;
                            }
                        }
                    }
                    GvViewBarcode.DataSource = DtBarcodeTemp;
                    GvViewBarcode.DataBind();
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
                                        table.Columns.Add("SCODE", typeof(string));
                                        table.Columns.Add("QTY", typeof(string));
                                        table.Columns.Add("RATE", typeof(string));
                                        table.Columns.Add("AMT", typeof(string));
                                        table.Columns.Add("STATUS", typeof(string));
                                        table.Columns.Add("PER", typeof(string));

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
                GvAssemblyTransDetails.DataSource = (DataTable)ViewState["CurrentTable"];
                GvAssemblyTransDetails.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

      


        #endregion


        protected void Btnprintchallan_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../reportviewPages/AssemblyChallanPrint.aspx', '_blank');", true);
        }

        protected void TxtAssemblyDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string ASSEMBLE_SRNO = ASS_TRANMASLogicLayer.GetSrNo_ForAssembleTransaction(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtAssemblyDate.Text.Trim()).ToString("yyyy-MM-dd"), HfTranType.Value);
                if (ASSEMBLE_SRNO.Length <= 8)
                {
                    TxtSrNo.Text = ASSEMBLE_SRNO;
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

        protected void DdlAuthoriseFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlAuthoriseFlag.SelectedValue == "Y")
            {
                TxtAuthorisedDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                TxtAuthorisedBy.Text = Session["USERNAME"].ToString();
            }
            else
            {
                TxtAuthorisedDate.Text = "";
                TxtAuthorisedBy.Text = "";
            }
        }

        protected void DdlConfirmFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlConfirmFlag.SelectedValue == "Y")
            {
                TxtConfirmDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                TxtConfirmBy.Text = Session["USERNAME"].ToString();
            }
            else
            {
                TxtConfirmDate.Text = "";
                TxtConfirmBy.Text = "";
            }
        }

        #region PARTS DETAILS GRID

        public void FillOnGridStockDetailChanged()
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

                        Label lblSumTotalAmount = (Label)(GvAssemblyTransDetails.FooterRow.FindControl("lblSumTotalAmount"));

                        HiddenField HfDetailSCode = (HiddenField)GvAssemblyTransDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtProductCode = (TextBox)GvAssemblyTransDetails.Rows[rowIndex].Cells[1].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvAssemblyTransDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductName");
                        TextBox TxtQty = (TextBox)GvAssemblyTransDetails.Rows[rowIndex].Cells[3].FindControl("TxtQty");
                        TextBox TxtRate = (TextBox)GvAssemblyTransDetails.Rows[rowIndex].Cells[4].FindControl("TxtRate");
                        TextBox TxtAmount = (TextBox)GvAssemblyTransDetails.Rows[rowIndex].Cells[5].FindControl("TxtAmount");
                        HiddenField HfStatus = (HiddenField)GvAssemblyTransDetails.Rows[rowIndex].Cells[0].FindControl("HfStatus");
                        HiddenField HfPer = (HiddenField)GvAssemblyTransDetails.Rows[rowIndex].Cells[0].FindControl("HfPer");

                        //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();


                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtQty.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["RATE"] = TxtRate.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = TxtAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["STATUS"] = HfStatus.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["PER"] = HfPer.Value.Trim();

                        rowIndex++;
                    }
                }
            }

                        #endregion
         }

        protected void TxtProductCode_TextChanged1(object sender, EventArgs e)
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

                        FillOnGridStockDetailChanged();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void TxtProductName_TextChanged1(object sender, EventArgs e)
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

                        FillOnGridStockDetailChanged();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtSearch.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtSearch);
                    Dv.RowFilter = "ProductCode like '%" + TxtSearch.Text.Trim() + "%' OR Convert(SRNO, 'System.String') like '%" + TxtSearch.Text.Trim() + "%'  OR ProductName like '%" + TxtSearch.Text.Trim() + "%'  OR PersonName like '%" + TxtSearch.Text.Trim() + "%' ";
                    GvAssembleTransactionMaster.DataSource = Dv.ToTable();
                    GvAssembleTransactionMaster.DataBind();
                }
                else
                {
                    GvAssembleTransactionMaster.DataSource = DtSearch;
                    GvAssembleTransactionMaster.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

       
    }
}