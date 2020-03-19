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

namespace VeeraApp.Admin
{
    public partial class BranchReceviedMaster : System.Web.UI.Page
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
                    SetInitialRow();
                    SetInitialRowBarcodeGrid();
                    FillBRANCH_RECMAS_MasterGrid(Session["COMP_CODE"].ToString());
                    BtnAdd.Enabled = false;
                    //ViewState["BarcodeTemp"] = null;
                    //ViewState["CurrentTable"] = null;

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

            TxtChallanNo.Text = string.Empty;
            TxtChallanDate.Text = string.Empty;
            TxtSrNo.Text = string.Empty;
            TxtToBranch.Text = string.Empty;
            TxtRemark.Text = string.Empty;
            TxtTransportName.Text = string.Empty;
            TxtVehclieNo.Text = string.Empty;
            TxtDriverName.Text = string.Empty;
            TxtDriverAddress.Text = string.Empty;
            TxtMDLNo.Text = string.Empty;
            TxtMDLState.Text = string.Empty;
            TxtLRDate.Text = string.Empty;
            TxtLRNumber.Text = string.Empty;
            DdlReceivedFlag.SelectedValue = "N";
            TxtReceivedDate.Text = string.Empty;
            TxtReceivedBy.Text = string.Empty;

            SetInitialRow();
            SetInitialRowBarcodeGrid();
            BtncallUpd.Text = "SAVE";

        }

        public void ControllerEnable()
        {
            TxtChallanNo.Enabled = false;
            TxtChallanDate.Enabled = false;
            TxtSrNo.Enabled = false;
            TxtToBranch.Enabled = false;
            TxtRemark.Enabled = false;
            TxtTransportName.Enabled = false;
            TxtVehclieNo.Enabled = false;
            TxtDriverName.Enabled = false;
            TxtDriverAddress.Enabled = false;
            TxtMDLNo.Enabled = false;
            TxtMDLState.Enabled = false;
            TxtLRDate.Enabled = false;
            TxtLRNumber.Enabled = false;
            DdlReceivedFlag.Enabled = true;
            TxtReceivedDate.Enabled = true;
            TxtReceivedBy.Enabled = true;

        }

        public void ControllerDisable()
        {
            TxtChallanNo.Enabled = false;
            TxtChallanDate.Enabled = false;
            TxtSrNo.Enabled = false;
            TxtToBranch.Enabled = false;
            TxtRemark.Enabled = false;
            TxtTransportName.Enabled = false;
            TxtVehclieNo.Enabled = false;
            TxtDriverName.Enabled = false;
            TxtDriverAddress.Enabled = false;
            TxtMDLNo.Enabled = false;
            TxtMDLState.Enabled = false;
            TxtLRDate.Enabled = false;
            TxtLRNumber.Enabled = false;
            DdlReceivedFlag.Enabled = false;
            TxtReceivedDate.Enabled = false;
            TxtReceivedBy.Enabled = false;

        }

        public void FillBRANCH_RECMAS_MasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = BRANCH_RECMASLogicLayer.GetAllBRANCH_REC_MASDetails(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvBranchReceivedMaster.DataSource = Dv.ToTable();
            GvBranchReceivedMaster.DataBind();

            DtSearch = Dv.ToTable();

        }

        protected void BtnDriverDetails_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelDriverDetails", "ShowModelDriverDetails()", true);
        }

        protected void DdlReceivedFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlReceivedFlag.SelectedValue == "Y")
                {
                    TxtReceivedBy.Text = Session["USERNAME"].ToString();
                    TxtReceivedDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    TxtReceivedBy.Text = "";
                    TxtReceivedDate.Text = "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvBranchReceivedDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }





        #region BRANCH RECEIVED DETAILS INTO GRID

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

            GvBranchReceivedDetails.DataSource = table;
            GvBranchReceivedDetails.DataBind();
        }

        protected void GvBranchReceivedDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GvBranchReceivedDetails_RowDataBound(object sender, GridViewRowEventArgs e)
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

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion


        #region BRANCH RECEIVED BARCODE INTO GRID

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

            GvBranchReceivedBarcodeGrid.DataSource = table;
            GvBranchReceivedBarcodeGrid.DataBind();
        }


        protected void GvBranchReceivedBarcodeGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }


        #endregion

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

                GvBranchReceivedDetails.Enabled = true;
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
    

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            lblmsg.Text = string.Empty;
            UserRights();
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

        protected void BtncallUpd_Click(object sender, EventArgs e)
        {
            if (BtncallUpd.Text == "UPDATE")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel1", "ShowModel1()", true);
            }
            else
            {
            }
         }

        protected void Btncalldel_Click(object sender, EventArgs e)
        {

        }

        protected void GvBranchReceivedMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvBranchReceivedMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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


                        DataSet ds = BRANCH_RECMASLogicLayer.GetAllIDWiseBRANCH_REC_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtBarcode = ds.Tables[2];
                        DataTable DtNewBarcode = ds.Tables[3];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            FillToBranchOnUpdate(dt.Rows[0]["TO_BRANCH_CODE"].ToString());
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfRef_TranDate.Value = dt.Rows[0]["REF_TRAN_DATE"].ToString();
                            HfRef_TranNo.Value = dt.Rows[0]["REF_TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtChallanNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            TxtChallanDate.Text = Convert.ToDateTime(dt.Rows[0]["CHA_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtSrNo.Text = dt.Rows[0]["SERIALNO"].ToString();
                            TxtTransportName.Text= dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtDriverName.Text = dt.Rows[0]["DRIVER_NAME"].ToString();
                            TxtDriverAddress.Text = dt.Rows[0]["DRIVER_ADD"].ToString();
                            TxtMDLNo.Text = dt.Rows[0]["MDLNO"].ToString();
                            TxtMDLState.Text = dt.Rows[0]["MDLSTATE"].ToString();
                            TxtLRDate.Text = dt.Rows[0]["LR_DATE"].ToString();//Convert.ToDateTime(dt.Rows[0]["LR_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtLRNumber.Text = dt.Rows[0]["LR_NO"].ToString();
                            DdlReceivedFlag.SelectedValue = dt.Rows[0]["REC_FLAG"].ToString();
                            TxtReceivedDate.Text = dt.Rows[0]["REC_DATE"].ToString();
                            TxtReceivedBy.Text = dt.Rows[0]["REC_USERID"].ToString();


                            if (DtDetails.Rows.Count > 0)
                            {
                                GvBranchReceivedDetails.DataSource = DtDetails;
                                GvBranchReceivedDetails.DataBind();
                                GvBranchReceivedDetails.Enabled = false;
                            }

                            if (DdlReceivedFlag.SelectedValue == "N")
                            {

                                if (DtBarcode.Rows.Count > 0)
                                {

                                    GvBranchReceivedBarcodeGrid.DataSource = DtBarcode;
                                    GvBranchReceivedBarcodeGrid.DataBind();
                                    GvBranchReceivedBarcodeGrid.Enabled = false;
                                }

                            }
                            else
                               if (DdlReceivedFlag.SelectedValue == "Y")
                            {
                                GvBranchReceivedBarcodeGrid.DataSource = DtNewBarcode;
                                GvBranchReceivedBarcodeGrid.DataBind();
                                GvBranchReceivedBarcodeGrid.Enabled = false;
                            }

                            btnSave.Visible = false;
                            btnDelete.Visible = true;
                            Btncalldel.Visible = true;
                            BtncallUpd.Visible = false;
                            ControllerDisable();
                        }                   
                    }
                }

                #endregion


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


                        DataSet ds = BRANCH_RECMASLogicLayer.GetAllIDWiseBRANCH_REC_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtBarcode = ds.Tables[2];
                        DataTable DtNewBarcode = ds.Tables[3];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            FillToBranchOnUpdate(dt.Rows[0]["TO_BRANCH_CODE"].ToString());
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfRef_TranDate.Value = dt.Rows[0]["REF_TRAN_DATE"].ToString();
                            HfRef_TranNo.Value = dt.Rows[0]["REF_TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtChallanNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            TxtChallanDate.Text = Convert.ToDateTime(dt.Rows[0]["CHA_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtSrNo.Text = dt.Rows[0]["SERIALNO"].ToString();
                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtDriverName.Text = dt.Rows[0]["DRIVER_NAME"].ToString();
                            TxtDriverAddress.Text = dt.Rows[0]["DRIVER_ADD"].ToString();
                            TxtMDLNo.Text = dt.Rows[0]["MDLNO"].ToString();
                            TxtMDLState.Text = dt.Rows[0]["MDLSTATE"].ToString();
                            TxtLRDate.Text = dt.Rows[0]["LR_DATE"].ToString();//Convert.ToDateTime(dt.Rows[0]["LR_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtLRNumber.Text = dt.Rows[0]["LR_NO"].ToString();
                            DdlReceivedFlag.SelectedValue = dt.Rows[0]["REC_FLAG"].ToString();
                            TxtReceivedDate.Text = dt.Rows[0]["REC_DATE"].ToString();
                            TxtReceivedBy.Text = dt.Rows[0]["REC_USERID"].ToString();


                            if (DtDetails.Rows.Count > 0)
                            {
                                GvBranchReceivedDetails.DataSource = DtDetails;
                                GvBranchReceivedDetails.DataBind();
                                GvBranchReceivedDetails.Enabled = false;
                            }


                            if(DdlReceivedFlag.SelectedValue=="N")
                            {
                       
                                if (DtBarcode.Rows.Count > 0)
                              {

                                GvBranchReceivedBarcodeGrid.DataSource = DtBarcode;
                                GvBranchReceivedBarcodeGrid.DataBind();
                                GvBranchReceivedBarcodeGrid.Enabled = false;
                              }

                           }
                            else
                             if(DdlReceivedFlag.SelectedValue == "Y")
                            {
                                GvBranchReceivedBarcodeGrid.DataSource = DtNewBarcode;
                                GvBranchReceivedBarcodeGrid.DataBind();
                                GvBranchReceivedBarcodeGrid.Enabled = false;
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


                        DataSet ds = BRANCH_RECMASLogicLayer.GetAllIDWiseBRANCH_REC_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];
                        DataTable DtBarcode = ds.Tables[2];
                        DataTable DtNewBarcode = ds.Tables[3];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            FillToBranchOnUpdate(dt.Rows[0]["TO_BRANCH_CODE"].ToString());
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfRef_TranDate.Value = dt.Rows[0]["REF_TRAN_DATE"].ToString();
                            HfRef_TranNo.Value = dt.Rows[0]["REF_TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtChallanNo.Text = dt.Rows[0]["CHA_NO"].ToString();
                            TxtChallanDate.Text = Convert.ToDateTime(dt.Rows[0]["CHA_DT"].ToString()).ToString("dd-MM-yyyy");
                            TxtSrNo.Text = dt.Rows[0]["SERIALNO"].ToString();
                            TxtTransportName.Text = dt.Rows[0]["TRANSPORT"].ToString();
                            TxtVehclieNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                            TxtDriverName.Text = dt.Rows[0]["DRIVER_NAME"].ToString();
                            TxtDriverAddress.Text = dt.Rows[0]["DRIVER_ADD"].ToString();
                            TxtMDLNo.Text = dt.Rows[0]["MDLNO"].ToString();
                            TxtMDLState.Text = dt.Rows[0]["MDLSTATE"].ToString();
                            TxtLRDate.Text = dt.Rows[0]["LR_DATE"].ToString();//Convert.ToDateTime(dt.Rows[0]["LR_DATE"].ToString()).ToString("dd-MM-yyyy");
                            TxtLRNumber.Text = dt.Rows[0]["LR_NO"].ToString();
                            DdlReceivedFlag.SelectedValue = dt.Rows[0]["REC_FLAG"].ToString();
                            TxtReceivedDate.Text = dt.Rows[0]["REC_DATE"].ToString();
                            TxtReceivedBy.Text = dt.Rows[0]["REC_USERID"].ToString();


                            if (DtDetails.Rows.Count > 0)
                            {
                                GvBranchReceivedDetails.DataSource = DtDetails;
                                GvBranchReceivedDetails.DataBind();
                                GvBranchReceivedDetails.Enabled = false;
                            }

                            if (DdlReceivedFlag.SelectedValue == "N")
                            {

                                if (DtBarcode.Rows.Count > 0)
                                {

                                    GvBranchReceivedBarcodeGrid.DataSource = DtBarcode;
                                    GvBranchReceivedBarcodeGrid.DataBind();
                                    GvBranchReceivedBarcodeGrid.Enabled = false;
                                }

                            }
                            else
                             if (DdlReceivedFlag.SelectedValue == "Y")
                            {
                                GvBranchReceivedBarcodeGrid.DataSource = DtNewBarcode;
                                GvBranchReceivedBarcodeGrid.DataBind();
                                GvBranchReceivedBarcodeGrid.Enabled = false;
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

        protected void GvBranchReceivedMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Button btnedit = (e.Row.FindControl("btnEdit") as Button);
                    Button btndelete = (e.Row.FindControl("btnDelete") as Button);
                    Label lblRecFlag = (e.Row.FindControl("lblReceived") as Label);

                    HiddenField hfREC_UPD = (e.Row.FindControl("hfREC_UPD") as HiddenField);
                    HiddenField hfREC_DEL = (e.Row.FindControl("hfREC_DEL") as HiddenField);
                    HiddenField hfREC_INS = (e.Row.FindControl("hfREC_INS") as HiddenField);

                    btndelete.Enabled = false;

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
            catch (Exception)
            {

                throw;
            }
        }

     
        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region UPADTE BRANCH RECEIVED MASTER


                BRANCH_RECMASLogicLayer insert = new BRANCH_RECMASLogicLayer();

                //insert.COMP_CODE = HfCompCode.Value.Trim();
                //insert.BRANCH_CODE = HfBranchCode.Value.Trim();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                //insert.TRAN_TYPE   = HfTranType.Value.Trim().ToUpper();
                //insert.TO_BRANCH_CODE = HfToBranchCode.Value.Trim();
                //insert.CHA_NO = TxtChallanNo.Text.Trim();
                //insert.CHA_DT   = Convert.ToDateTime(TxtChallanDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                //insert.SERIALNO = TxtSrNo.Text.Trim();
                //insert.VEHICLE_NO = TxtVehclieNo.Text.Trim().ToUpper();
                //insert.TCODE = null;
                //insert.TRANSPORT = TxtTransportName.Text.Trim().ToUpper();
                //insert.LR_NO = TxtLRNumber.Text.Trim();
                //insert.LR_DATE   = Convert.ToDateTime(TxtChallanDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                //insert.DRIVER_NAME = TxtDriverName.Text.Trim().ToUpper();
                //insert.DRIVER_ADD = TxtDriverAddress.Text.Trim().ToUpper();
                //insert.MDLNO = TxtMDLNo.Text.Trim().ToUpper();
                //insert.MDLSTATE = TxtMDLState.Text.Trim().ToUpper();
                //insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                //insert.FORM_SRNO = null;
                //insert.CHECKPOST_NAME = "";
                //insert.TOT_QTY = null;
                //insert.TOT_AMT = null;
                //insert.ENDT = "";
                //insert.STATUS = "";
                //insert.INS_USERID = Session["USERNAME"].ToString();
                //insert.INS_DATE = "";
                //insert.UPD_USERID = Session["USERNAME"].ToString();
                //insert.UPD_DATE = "";
                //insert.REF_TRAN_DATE = "";
                //insert.REF_TRAN_NO = null;
                //insert.ISS_FLAG = "";
                insert.REC_FLAG = DdlReceivedFlag.SelectedValue.Trim().ToUpper();
                if (DdlReceivedFlag.SelectedValue == "Y")
                {
                    insert.REC_USERID = TxtReceivedBy.Text.Trim().ToUpper();
                   
                }
                else
                {
                    insert.REC_USERID = "";
                }

                if (DdlReceivedFlag.SelectedValue == "Y")
                {
                 
                    insert.REC_DATE = Convert.ToDateTime(TxtReceivedDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.REC_DATE = "";
                }

                //insert.GST_APP_FLAG = "";
                //insert.PARTY_TYPE = "";
                //insert.INV_NO = "";
                //insert.INV_DT = "";
                //insert.EWAY_BILLNO = "";
                //insert.GST_RATE = null;
                //insert.GST_AMT = null;
                //insert.CGST_RATE = null;
                //insert.CGST_AMT = null;
                //insert.SGST_RATE = null;
                //insert.SGST_AMT = null;
                //insert.IGST_RATE = null;
                //insert.IGST_AMT = null;
                //insert.RO_AMT = null;
                //insert.NET_AMT = null;
                //insert.FROM_BRANCH_ACODE = null;

                #endregion

                #region BRANCH RECEIVED STOCK DETAILS

                //XmlDocument XDoc1 = new XmlDocument();
                //XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                //XDoc1.AppendChild(dec1);// Create the root element
                //XmlElement root1 = XDoc1.CreateElement("root");
                //XDoc1.AppendChild(root1);
                //int SRNODETAIL = 1;
                //foreach (GridViewRow row in GvBranchReceivedDetails.Rows)
                //{
                //    if (row.RowType == DataControlRowType.DataRow)
                //    {

                //        HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                //        HiddenField HfRefTranDate = row.FindControl("HfRefTranDate") as HiddenField;
                //        HiddenField HfRefTranNo = row.FindControl("HfRefTranNo") as HiddenField;
                //        HiddenField HfRefSrNo = row.FindControl("HfRefSrNo") as HiddenField;

                //        TextBox TxtProductName = row.FindControl("TxtProductName") as TextBox;
                //        TextBox TxtQty = row.FindControl("TxtQty") as TextBox;
                //        TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                //        TextBox TxtAmount = row.FindControl("TxtAmount") as TextBox;



                //        if (HfDetailSCode.Value != "0" && HfDetailSCode.Value != null)
                //        {


                //            XmlElement HandleDetail2 = XDoc1.CreateElement("STK_IRDETDetails");
                //            HandleDetail2.SetAttribute("SRNO", SRNODETAIL.ToString());
                //            HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                //            HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                //            HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                //            if (HfDetailSCode.Value == string.Empty)
                //            {
                //                HandleDetail2.SetAttribute("SCODE", ("0"));
                //            }
                //            else
                //            {
                //                HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value));
                //            }

                //            if (HfRefTranDate.Value == string.Empty)
                //            {
                //                HandleDetail2.SetAttribute("REF_TRAN_DATE", (""));
                //            }
                //            else
                //            {
                //                HandleDetail2.SetAttribute("REF_TRAN_DATE", (Convert.ToDateTime(HfRefTranDate.Value).ToString("MM-dd-yyyy")));
                //            }

                //            if (HfRefTranNo.Value == string.Empty)
                //            {
                //                HandleDetail2.SetAttribute("REF_TRAN_NO", ("0"));
                //            }
                //            else
                //            {
                //                HandleDetail2.SetAttribute("REF_TRAN_NO", (HfRefTranNo.Value.Trim()));
                //            }

                //            if (HfRefSrNo.Value == string.Empty)
                //            {
                //                HandleDetail2.SetAttribute("REF_SRNO", ("0"));
                //            }
                //            else
                //            {
                //                HandleDetail2.SetAttribute("REF_SRNO", (SRNODETAIL.ToString()));
                //            }

                //            if (TxtQty.Text == string.Empty)
                //            {
                //                HandleDetail2.SetAttribute("QTY", ("0"));
                //            }
                //            else
                //            {
                //                HandleDetail2.SetAttribute("QTY", (TxtQty.Text.Trim()));
                //            }

                //            if (TxtRate.Text == string.Empty)
                //            {
                //                HandleDetail2.SetAttribute("RATE", ("0"));
                //            }
                //            else
                //            {
                //                HandleDetail2.SetAttribute("RATE", (TxtRate.Text.Trim()));
                //            }

                //            if (TxtAmount.Text == string.Empty)
                //            {
                //                HandleDetail2.SetAttribute("AMT", ("0"));
                //            }
                //            else
                //            {
                //                HandleDetail2.SetAttribute("AMT", (TxtAmount.Text.Trim()));
                //            }

                //            root1.AppendChild(HandleDetail2);
                //            SRNODETAIL++;

                //        }
                //   }
                #endregion
                // }

                string str = BRANCH_RECMASLogicLayer.UpdateBRANCH_REC_MASDetail(insert);

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "BRANCH RECEIVED  MASTER SAVE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillBRANCH_RECMAS_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "BRANCH RECEIVED  MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR :BRANCH RECEIVED MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

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
                    Dv.RowFilter = "CHA_NO like '%" + TxtSearch.Text.Trim() + "%' OR FromBranchName like '%" + TxtSearch.Text.Trim() + "%'  OR ToBranchName like '%" + TxtSearch.Text.Trim() + "%' OR Convert(SERIALNO, 'System.String') like '%" + TxtSearch.Text.Trim() + "%'";
                    GvBranchReceivedMaster.DataSource = Dv.ToTable();
                    GvBranchReceivedMaster.DataBind();
                }
                else
                {
                    GvBranchReceivedMaster.DataSource = DtSearch;
                    GvBranchReceivedMaster.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}
