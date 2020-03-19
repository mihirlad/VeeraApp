using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Veera.LogicLayer;
using MihirValid;
namespace VeeraApp
{
    public partial class PriceMaster : System.Web.UI.Page
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
                    FillStockPriceMasterGrid(Session["COMP_CODE"].ToString());
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

        public void ControllerDisable()
        {
            //  TxtSrNo.Enabled = false;
            TxtFromDate.Enabled = false;
            TxtToDate.Enabled = false;
            TxtRemark.Enabled = false;
            DdlActive.Enabled = false;
        }
        public void ControllerEnable()
        {
            //   TxtSrNo.Enabled = true;
            TxtFromDate.Enabled = true;
            TxtToDate.Enabled = true;
            TxtRemark.Enabled = true;
            DdlActive.Enabled = true;
        }

        public void clear()
        {

            DivEntry.Visible = false;
            DivView.Visible = true;

            HfCompCode.Value = string.Empty;
            //    TxtSrNo.Text = string.Empty;
            TxtFromDate.Text = string.Empty;
            TxtToDate.Text = string.Empty;
            TxtRemark.Text = string.Empty;
            DdlActive.SelectedIndex = 0;

            BtncallUpd.Text = "SAVE";

        }

        public void FillStockPriceMasterGrid(string CompCode)
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = STOCK_PRICE_MASLogicLayer.GetAllSTOCK_PRICE_MASDetail(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvStockPriceMaster.DataSource = Dv.ToTable(); ;
                GvStockPriceMaster.DataBind();
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
                    Dt = STOCK_BALLogicLayer.GetAllSTOCK_PRICEDetailByCompany((Session["COMP_CODE"].ToString()), Convert.ToDateTime(TxtFromDate.Text.Trim()), Convert.ToDateTime(TxtToDate.Text.Trim()));
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



        protected void GvStockPriceDet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvStockPriceDet.PageIndex = e.NewPageIndex;
                FillStockPriceDetailGrid();
                clear();

            }
            catch (Exception)
            {

                throw;
            }
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
                FillStockPriceDetailGrid();


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
                #region INSERT_UPDATE PRICE MASTER 

                STOCK_PRICE_MASLogicLayer insert = new STOCK_PRICE_MASLogicLayer();
                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.SRNO = HfSrNo.Value;
                insert.FRDT = Convert.ToDateTime(TxtFromDate.Text.Trim()).ToString("MM-dd-yyyy");
                insert.TODT = Convert.ToDateTime(TxtToDate.Text.Trim()).ToString("MM-dd-yyyy");
                insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                insert.ACTIVE = DdlActive.SelectedValue.Trim().ToUpper();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";

                #endregion
                #region INSERT_UPDATE PRICE DETAILS

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);

                foreach (GridViewRow row in GvStockPriceDet.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfCompCodeVal = row.FindControl("HfCompCode") as HiddenField;
                        //   HiddenField HfSrNoVal = row.FindControl("HfSrNo") as HiddenField;
                        HiddenField HfStockCodeVal = row.FindControl("HfStockCode") as HiddenField;

                        Label lblCategoryName = row.FindControl("lblCategoryName") as Label;
                        Label lblProdCode = row.FindControl("lblProdCode") as Label;
                        Label lblPartNo = row.FindControl("lblPartNo") as Label;
                        Label lblProductName = row.FindControl("lblProductName") as Label;

                        TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                        TextBox TxtCustDis = row.FindControl("TxtCustDis") as TextBox;
                        TextBox TxtCustDisRate = row.FindControl("TxtCustDisRate") as TextBox;
                        TextBox TxtDealerDis = row.FindControl("TxtDealerDis") as TextBox;
                        TextBox TxtDealerRate = row.FindControl("TxtDealerRate") as TextBox;
                        TextBox TxtMaxDis = row.FindControl("TxtMaxDis") as TextBox;
                        TextBox TxtMaxRate = row.FindControl("TxtMaxRate") as TextBox;

                        XmlElement HandleDetail2 = XDoc1.CreateElement("Detail");
                        HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());


                        // HandleDetail2.SetAttribute("SRNO", (HfSrNoVal.Value));
                        HandleDetail2.SetAttribute("SCODE", (HfStockCodeVal.Value));
                        if (TxtRate.Text == string.Empty)
                        {
                            HandleDetail2.SetAttribute("RATE", ("0"));
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("RATE", (TxtRate.Text));
                        }
                        if (TxtCustDis.Text == string.Empty)
                        {
                            HandleDetail2.SetAttribute("DIS_PER", ("0"));
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("DIS_PER", (TxtCustDis.Text));
                        }
                        if (TxtCustDisRate.Text == string.Empty)
                        {
                            HandleDetail2.SetAttribute("DIS_RATE", ("0"));
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("DIS_RATE", (TxtCustDisRate.Text));
                        }
                        if (TxtDealerDis.Text == string.Empty)
                        {
                            HandleDetail2.SetAttribute("DEL_PER", ("0"));
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("DEL_PER", (TxtDealerDis.Text));
                        }
                        if (TxtDealerRate.Text == string.Empty)
                        {
                            HandleDetail2.SetAttribute("DEL_RATE", ("0"));
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("DEL_RATE", (TxtDealerRate.Text));
                        }
                        if (TxtMaxDis.Text == string.Empty)
                        {
                            HandleDetail2.SetAttribute("MAX_PER", ("0"));
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("MAX_PER", (TxtMaxDis.Text));
                        }
                        if (TxtMaxRate.Text == string.Empty)
                        {
                            HandleDetail2.SetAttribute("MAX_RATE", ("0"));
                        }
                        else
                        {
                            HandleDetail2.SetAttribute("MAX_RATE", (TxtMaxRate.Text));
                        }

                        HandleDetail2.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));
                        HandleDetail2.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));
                        HandleDetail2.SetAttribute("INS_DATE", (""));
                        HandleDetail2.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));
                        HandleDetail2.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));
                        HandleDetail2.SetAttribute("UPD_DATE", (""));
                        root1.AppendChild(HandleDetail2);

                    }
                }
                #endregion

                string str = STOCK_PRICE_MASLogicLayer.UpdateSTOCK_PRICE_MASDetail(insert, validation.RSC(XDoc1.OuterXml));

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "STOCK PRICE MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillStockPriceMasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();



                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "STOCK PRICE MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : STOCK PRICE MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;
                }
            }

            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStockPriceMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvStockPriceMaster.PageIndex = e.NewPageIndex;
                FillStockPriceMasterGrid(Session["COMP_CODE"].ToString());
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStockPriceMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataSet ds = STOCK_PRICE_MASLogicLayer.GetAllIDWiseSTOCK_PRICE_MASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable dtBal = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        // HfStockCode.Value= dt.Rows[0][""].ToString();
                        TxtFromDate.Text = Convert.ToDateTime(dt.Rows[0]["FRDT"].ToString()).ToString("dd-MM-yyyy");
                        TxtToDate.Text = Convert.ToDateTime(dt.Rows[0]["TODT"].ToString()).ToString("dd-MM-yyyy");
                        TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                        DdlActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();

                        if (dtBal.Rows.Count > 0)
                        {
                            GvStockPriceDet.DataSource = dtBal;
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
                    DivStockGrid.Style.Add("Display", "block");
                    #endregion
                }


                if (e.CommandName == "Edita")
                {
                    #region EDIT
                    clear();
                    DataSet ds = STOCK_PRICE_MASLogicLayer.GetAllIDWiseSTOCK_PRICE_MASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable dtBal = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        // HfStockCode.Value= dt.Rows[0][""].ToString();
                        TxtFromDate.Text = Convert.ToDateTime(dt.Rows[0]["FRDT"].ToString()).ToString("dd-MM-yyyy");
                        TxtToDate.Text = Convert.ToDateTime(dt.Rows[0]["TODT"].ToString()).ToString("dd-MM-yyyy");
                        TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                        DdlActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();

                        if (dtBal.Rows.Count > 0)
                        {
                            GvStockPriceDet.DataSource = dtBal;
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
                    //GvStockPriceDet.Visible = true;
                    DivStockGrid.Style.Add("Display", "block");
                }

                if (e.CommandName == "Viewa")
                {
                    #region SET TEXT ON VIEW
                    clear();
                    DataSet ds = STOCK_PRICE_MASLogicLayer.GetAllIDWiseSTOCK_PRICE_MASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable dtBal = ds.Tables[1];
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        // HfStockCode.Value= dt.Rows[0][""].ToString();
                        TxtFromDate.Text = Convert.ToDateTime(dt.Rows[0]["FRDT"].ToString()).ToString("dd-MM-yyyy");
                        TxtToDate.Text = Convert.ToDateTime(dt.Rows[0]["TODT"].ToString()).ToString("dd-MM-yyyy");
                        TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                        DdlActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();

                        if (dtBal.Rows.Count > 0)
                        {
                            GvStockPriceDet.DataSource = dtBal;
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
                    // GvStockPriceDet.Visible = true;
                    DivStockGrid.Style.Add("Display", "block");
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
                    #region INSERT_UPDATE PRICE MASTER 

                    STOCK_PRICE_MASLogicLayer insert = new STOCK_PRICE_MASLogicLayer();
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.SRNO = HfSrNo.Value;
                    insert.FRDT = Convert.ToDateTime(TxtFromDate.Text.Trim()).ToString("MM-dd-yyyy");
                    insert.TODT = Convert.ToDateTime(TxtToDate.Text.Trim()).ToString("MM-dd-yyyy");
                    insert.REMARK = TxtRemark.Text.Trim().ToUpper();
                    insert.ACTIVE = DdlActive.SelectedValue.Trim().ToUpper();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";

                    #endregion
                    #region INSERT_UPDATE PRICE DETAILS

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);

                    foreach (GridViewRow row in GvStockPriceDet.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfCompCodeVal = row.FindControl("HfCompCode") as HiddenField;
                            // HiddenField HfSrNoVal = row.FindControl("HfSrNo") as HiddenField;
                            HiddenField HfStockCodeVal = row.FindControl("HfStockCode") as HiddenField;

                            Label lblCategoryName = row.FindControl("lblCategoryName") as Label;
                            Label lblProdCode = row.FindControl("lblProdCode") as Label;
                            Label lblPartNo = row.FindControl("lblPartNo") as Label;
                            Label lblProductName = row.FindControl("lblProductName") as Label;

                            TextBox TxtRate = row.FindControl("TxtRate") as TextBox;
                            TextBox TxtCustDis = row.FindControl("TxtCustDis") as TextBox;
                            TextBox TxtCustDisRate = row.FindControl("TxtCustDisRate") as TextBox;
                            TextBox TxtDealerDis = row.FindControl("TxtDealerDis") as TextBox;
                            TextBox TxtDealerRate = row.FindControl("TxtDealerRate") as TextBox;
                            TextBox TxtMaxDis = row.FindControl("TxtMaxDis") as TextBox;
                            TextBox TxtMaxRate = row.FindControl("TxtMaxRate") as TextBox;

                            XmlElement HandleDetail2 = XDoc1.CreateElement("Detail");
                            HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());


                            // HandleDetail2.SetAttribute("SRNO", (HfSrNoVal.Value));
                            HandleDetail2.SetAttribute("SCODE", (HfStockCodeVal.Value));
                            if (TxtRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("RATE", (TxtRate.Text));
                            }
                            if (TxtCustDis.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("DIS_PER", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("DIS_PER", (TxtCustDis.Text));
                            }
                            if (TxtCustDisRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("DIS_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("DIS_RATE", (TxtCustDisRate.Text));
                            }
                            if (TxtDealerDis.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("DEL_PER", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("DEL_PER", (TxtDealerDis.Text));
                            }
                            if (TxtDealerRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("DEL_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("DEL_RATE", (TxtDealerRate.Text));
                            }
                            if (TxtMaxDis.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("MAX_PER", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("MAX_PER", (TxtMaxDis.Text));
                            }
                            if (TxtMaxRate.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("MAX_RATE", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("MAX_RATE", (TxtMaxRate.Text));
                            }

                            HandleDetail2.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));
                            HandleDetail2.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));
                            HandleDetail2.SetAttribute("INS_DATE", (""));
                            HandleDetail2.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));
                            HandleDetail2.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));
                            HandleDetail2.SetAttribute("UPD_DATE", (""));
                            root1.AppendChild(HandleDetail2);

                        }
                    }
                    #endregion

                    string str = STOCK_PRICE_MASLogicLayer.InsertSTOCK_PRICE_MASDetail(insert, validation.RSC(XDoc1.OuterXml));

                    if (str.Length <= 8)
                    {
                        lblmsg.Text = "STOCK PRICE MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        //clear();
                        //FillStockPriceMasterGrid();
                        //UserRights();

                        #region ViewDetail

                        #region SET TEXT ON VIEW
                        clear();
                        DataSet ds = STOCK_PRICE_MASLogicLayer.GetAllIDWiseSTOCK_PRICE_MASDetail(str);
                        DataTable dt = ds.Tables[0];
                        DataTable dtBal = ds.Tables[1];
                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                            // HfStockCode.Value= dt.Rows[0][""].ToString();
                            TxtFromDate.Text = Convert.ToDateTime(dt.Rows[0]["FRDT"].ToString()).ToString("dd-MM-yyyy");
                            TxtToDate.Text = Convert.ToDateTime(dt.Rows[0]["TODT"].ToString()).ToString("dd-MM-yyyy");
                            TxtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                            DdlActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();

                            if (dtBal.Rows.Count > 0)
                            {
                                GvStockPriceDet.DataSource = dtBal;
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
                        // GvStockPriceDet.Visible = true;
                        DivStockGrid.Style.Add("Display", "block");
                        FillStockPriceMasterGrid(Session["COMP_CODE"].ToString());
                        #endregion

                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "STOCK PRICE MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : STOCK PRICE MASTER NOT SAVED";
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
                if (HfSrNo.Value != string.Empty)
                {
                    string str = STOCK_PRICE_MASLogicLayer.DeleteSTOCK_PRISE_MASDetailsByID(HfSrNo.Value);
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
                        lblmsg.Text = "Error:Stock Price Master Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillStockPriceMasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStockPriceMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) // Bind nested grid view with parent grid view
                {
                    string Id = ((HiddenField)e.Row.FindControl("HfSrNo")).Value;
                    GridView childgrd = (GridView)e.Row.FindControl("GvNestedPriceMasDetails");

                    DataTable Dt = new DataTable();

                    Dt = STOCK_PRICE_MASLogicLayer.GetAllWiseSRNO_PRICE_MASDetail(Id);
                    childgrd.DataSource = Dt;
                    childgrd.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtFromDate_TextChange(object sender, EventArgs e)
        {
            try
            {
                if (BtncallUpd.Text == "SAVE")
                {
                    FillStockPriceDetailGrid();
                    // GvStockPriceDet.Visible = false;
                    DivStockGrid.Style.Add("Display", "none");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtToDate_TextChange(object sender, EventArgs e)
        {
            try
            {
                if (BtncallUpd.Text == "SAVE")
                {
                    FillStockPriceDetailGrid();
                    DivStockGrid.Style.Add("Display", "none");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}