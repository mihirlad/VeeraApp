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
    
    public partial class StockModelMaster2 : System.Web.UI.Page
    {
        public static string compcode;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblBrandname.Text = Session["lblBrandName"].ToString();
            lblModeltypename.Text = Session["lblModelTypeName"].ToString();

            
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
              

                if (!string.IsNullOrWhiteSpace(Request.QueryString["BRAND_CODE"]) && !string.IsNullOrWhiteSpace(Request.QueryString["COMP_CODE"]))
                {
                    HfCompCode.Value = HttpUtility.UrlDecode(Decrypt(Request.QueryString["COMP_CODE"]));
                    HfBrandCode.Value = HttpUtility.UrlDecode(Decrypt(Request.QueryString["BRAND_CODE"]));
                }

                DivEntry.Visible = false;
                DivView.Visible = true;
                FillStockModelMasterGrid();
                FillStockModalCostGrid();
                FillStockModalDetailGrid();
                SetInitialRow();
                SetInitialRow1();
            }
        }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }


        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "mihirlad9021";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
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
            TxtModelName.Enabled = true;
            TxtModelDescription.Enabled = true;
        }

        public void ControllerDisable()
        {
            TxtModelName.Enabled = false;
            TxtModelDescription.Enabled = false;
        }

        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            //HfCompCode.Value = string.Empty;
            //HfBrandCode.Value = string.Empty;
            HfModelCode.Value = string.Empty;
            HfSrNo.Value = string.Empty;
            TxtModelName.Text = string.Empty;
            TxtModelDescription.Text = string.Empty;

            ClearStockModelCostGrid();
            ClearStockModelDeatilGrid();



            BtncallUpd.Text = "SAVE";
        }


        public void FillStockModelMasterGrid()
        {

            DataTable Dt = new DataTable();

            Dt = STOCK_MODELMASLogicLayer.GetAllSTOCK_MODELMASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()),Convert.ToInt32(HfBrandCode.Value));
            GvStockModelMaster.DataSource = Dt;
            GvStockModelMaster.DataBind();
        }

        public void FillStockModalDetailGrid()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = STOCK_MODELDETLogicLayer.GetAllSTOCK_MODELDETDetailByCompany((Session["COMP_CODE"].ToString()));
                GvStockModalDetails.DataSource = Dt;
                GvStockModalDetails.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillStockModalCostGrid()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = STOCK_MODELCOSTLogicLayer.GetAllSTOCK_MODELCOSTSDetailByCompany((Session["COMP_CODE"].ToString()));
                GvStockModelCost.DataSource = Dt;
                GvStockModelCost.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStockModelCost_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            lblmsg.Text = string.Empty;
            UserRights();
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/StockModelMaster.aspx");
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
                GvStockModalDetails.Enabled = true;
                GvStockModelCost.Enabled = true;

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
                #region UPDATE STOCK MODEL

                #region INSERT STOCK MODEL MASTER

                STOCK_MODELMASLogicLayer insert = new STOCK_MODELMASLogicLayer();

                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.BRAND_CODE = HfBrandCode.Value.Trim();
                insert.MODEL_CODE = HfModelCode.Value.Trim();
                insert.MODEL_NAME = TxtModelName.Text.Trim().ToUpper();
                insert.MODEL_DESC = TxtModelDescription.Text.Trim().ToUpper();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";

                #endregion

                #region INSERT STOCK MODEL DETAILS

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);

                foreach (GridViewRow row in GvStockModalDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                        TextBox TxtOrder = row.FindControl("TxtOrder") as TextBox;
                        DropDownList DdlProductName = row.FindControl("DdlProductName") as DropDownList;
                        TextBox TxtQuantity = row.FindControl("TxtQuantity") as TextBox;
                        CheckBox ChkBoxMajor = row.FindControl("ChkBoxMajor") as CheckBox;
                        CheckBox ChkBoxNormal = row.FindControl("ChkBoxNormal") as CheckBox;

                        if (HfDetailSCode.Value != "0")
                        {
                            XmlElement HandleDetail2 = XDoc1.CreateElement("StockModelDetails");
                            HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                            HandleDetail2.SetAttribute("MODEL_CODE", HfModelCode.Value.Trim());

                            HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value.Trim()));
                            if (TxtQuantity.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("QTY", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("QTY", (TxtQuantity.Text));
                            }
                            if (ChkBoxMajor.Checked == true)
                            {
                                HandleDetail2.SetAttribute("CHK_MAJOR", "Y");
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("CHK_MAJOR", "N");
                            }

                            if (ChkBoxNormal.Checked == true)
                            {
                                HandleDetail2.SetAttribute("CHK_NORMAL", "Y");
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("CHK_NORMAL", "N");
                            }

                            if (TxtOrder.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("ORD", ("0"));
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("ORD", (TxtOrder.Text));
                            }


                            HandleDetail2.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));
                            HandleDetail2.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));
                            HandleDetail2.SetAttribute("INS_DATE", (""));
                            HandleDetail2.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));
                            HandleDetail2.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));
                            HandleDetail2.SetAttribute("UPD_DATE", (""));




                            root1.AppendChild(HandleDetail2);
                            #endregion
                        }
                    }
                }


                #region INSERT STOCK MODEL COST

                XmlDocument XDoc2 = new XmlDocument();
                XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                XDoc2.AppendChild(dec2);// Create the root element
                XmlElement root2 = XDoc2.CreateElement("root");
                XDoc2.AppendChild(root2);

                foreach (GridViewRow row in GvStockModelCost.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        TextBox TxtFromAmt = row.FindControl("TxtFromAmt") as TextBox;
                        TextBox TxtToAmt = row.FindControl("TxtToAmt") as TextBox;
                        DropDownList DdlCostlevel = row.FindControl("DdlCostlevel") as DropDownList;
                        HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;

                        XmlElement HandleDetail3 = XDoc2.CreateElement("StockModelCost");
                        HandleDetail3.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                        HandleDetail3.SetAttribute("MODEL_CODE", HfModelCode.Value.Trim());

                        //HandleDetail3.SetAttribute("SRNO", HfSrNo.Value.Trim());
                        if (TxtFromAmt.Text == string.Empty)
                        {
                            HandleDetail3.SetAttribute("FRAMT", ("0"));
                        }
                        else
                        {
                            HandleDetail3.SetAttribute("FRAMT", (TxtFromAmt.Text));
                        }
                        if (TxtToAmt.Text == string.Empty)
                        {
                            HandleDetail3.SetAttribute("TOAMT", ("0"));
                        }
                        else
                        {
                            HandleDetail3.SetAttribute("TOAMT", (TxtToAmt.Text));
                        }
                        HandleDetail3.SetAttribute("COST_LEVEL", DdlCostlevel.SelectedValue);

                        HandleDetail3.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));
                        HandleDetail3.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));
                        HandleDetail3.SetAttribute("INS_DATE", (""));
                        HandleDetail3.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));
                        HandleDetail3.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));
                        HandleDetail3.SetAttribute("UPD_DATE", (""));


                        root2.AppendChild(HandleDetail3);

                    }
                }

                #endregion


                string str = STOCK_MODELMASLogicLayer.UpdateSTOCK_MODELMASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml));

                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "STOCK MODEL MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillStockModelMasterGrid();
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "STOCK MODEL MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : STOCK MODEL MASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }

                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStockModelMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvStockModelMaster.PageIndex = e.NewPageIndex;
                FillStockModelMasterGrid();
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStockModelMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataSet ds = STOCK_MODELMASLogicLayer.GetAllIDWiseSTOCK_MODELMASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable dtDet = ds.Tables[1];
                    DataTable dtCost = ds.Tables[2];
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfModelCode.Value = dt.Rows[0]["MODEL_CODE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBrandCode.Value = dt.Rows[0]["BRAND_CODE"].ToString();
                    //    HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        TxtModelName.Text = dt.Rows[0]["MODEL_NAME"].ToString();
                        TxtModelDescription.Text = dt.Rows[0]["MODEL_DESC"].ToString();

                        if (dtDet.Rows.Count > 0)
                        {
                            ViewState["CurrentTable"] = dtDet;
                            GvStockModalDetails.DataSource = dtDet;
                            GvStockModalDetails.DataBind();
                        }

                        if (dtCost.Rows.Count > 0)
                        {
                            ViewState["CurrentTableCost"] = dtCost;
                            GvStockModelCost.DataSource = dtCost;
                            GvStockModelCost.DataBind();
                        }
                    }
                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    Btncalldel.Visible = true;
                    BtncallUpd.Visible = false;
                    ControllerDisable();
                    GvStockModalDetails.Enabled = false;
                    GvStockModelCost.Enabled = false;

                    #endregion
                }

                if (e.CommandName == "Edita")
                {
                    #region EDIT
                    clear();
                    DataSet ds = STOCK_MODELMASLogicLayer.GetAllIDWiseSTOCK_MODELMASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable dtDet = ds.Tables[1];
                    DataTable dtCost = ds.Tables[2];
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfModelCode.Value = dt.Rows[0]["MODEL_CODE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBrandCode.Value = dt.Rows[0]["BRAND_CODE"].ToString();
                   //     HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        TxtModelName.Text = dt.Rows[0]["MODEL_NAME"].ToString();
                        TxtModelDescription.Text = dt.Rows[0]["MODEL_DESC"].ToString();

                        if (dtDet.Rows.Count > 0)
                        {
                            ViewState["CurrentTable"] = dtDet;
                            GvStockModalDetails.DataSource = dtDet;
                            GvStockModalDetails.DataBind();
                        }

                        if (dtCost.Rows.Count > 0)
                        {
                            ViewState["CurrentTableCost"] = dtCost;
                            GvStockModelCost.DataSource = dtCost;
                            GvStockModelCost.DataBind();
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
                    GvStockModelCost.Enabled = true;
                    GvStockModalDetails.Enabled = true;
                }

                if (e.CommandName == "Viewa")
                {
                    #region SET TEXT ON VIEW
                    clear();
                    DataSet ds = STOCK_MODELMASLogicLayer.GetAllIDWiseSTOCK_MODELMASDetail(e.CommandArgument.ToString());
                    DataTable dt = ds.Tables[0];
                    DataTable dtDet = ds.Tables[1];
                    DataTable dtCost = ds.Tables[2];
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfModelCode.Value = dt.Rows[0]["MODEL_CODE"].ToString();
                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBrandCode.Value = dt.Rows[0]["BRAND_CODE"].ToString();
                     //   HfSrNo.Value = dt.Rows[0]["SRNO"].ToString();
                        TxtModelName.Text = dt.Rows[0]["MODEL_NAME"].ToString();
                        TxtModelDescription.Text = dt.Rows[0]["MODEL_DESC"].ToString();

                        if (dtDet.Rows.Count > 0)
                        {
                            ViewState["CurrentTable"] = dtDet;
                            GvStockModalDetails.DataSource = dtDet;
                            GvStockModalDetails.DataBind();
                        }

                        if (dtCost.Rows.Count > 0)
                        {
                            ViewState["CurrentTableCost"] = dtCost; ;
                            GvStockModelCost.DataSource = dtCost;
                            GvStockModelCost.DataBind();
                        }

                    }


                    #endregion
                    ControllerDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    UserRights();
                    GvStockModalDetails.Enabled = false;
                    GvStockModelCost.Enabled = false;
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
                    #region INSERT STOCK MODEL MASTER

                    STOCK_MODELMASLogicLayer insert = new STOCK_MODELMASLogicLayer();

                    insert.COMP_CODE = HfCompCode.Value.Trim();
                    insert.BRAND_CODE = HfBrandCode.Value.Trim();
                    insert.MODEL_CODE = HfModelCode.Value.Trim();
                    insert.MODEL_NAME = TxtModelName.Text.Trim().ToUpper();
                    insert.MODEL_DESC = TxtModelDescription.Text.Trim().ToUpper();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";

                    #endregion

                    #region INSERT STOCK MODEL DETAILS

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);

                    foreach (GridViewRow row in GvStockModalDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfDetailSCode = row.FindControl("HfDetailSCode") as HiddenField;
                            TextBox TxtOrder = row.FindControl("TxtOrder") as TextBox;
                            DropDownList DdlProductName = row.FindControl("DdlProductName") as DropDownList;
                            TextBox TxtQuantity = row.FindControl("TxtQuantity") as TextBox;
                            CheckBox ChkBoxMajor = row.FindControl("ChkBoxMajor") as CheckBox;
                            CheckBox ChkBoxNormal = row.FindControl("ChkBoxNormal") as CheckBox;

                            if (HfDetailSCode.Value != "0")
                            {

                                XmlElement HandleDetail2 = XDoc1.CreateElement("StockModelDetails");
                                HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());

                                HandleDetail2.SetAttribute("SCODE", (HfDetailSCode.Value.Trim()));
                                if (TxtQuantity.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("QTY", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("QTY", (TxtQuantity.Text));
                                }

                                if (ChkBoxMajor.Checked == true)
                                {
                                    HandleDetail2.SetAttribute("CHK_MAJOR", "Y");
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CHK_MAJOR", "N");
                                }

                                if (ChkBoxNormal.Checked == true)
                                {
                                    HandleDetail2.SetAttribute("CHK_NORMAL", "Y");
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("CHK_NORMAL", "N");
                                }

                                if (TxtOrder.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("ORD", ("0"));
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("ORD", (TxtOrder.Text));
                                }


                                HandleDetail2.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));
                                HandleDetail2.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));
                                HandleDetail2.SetAttribute("INS_DATE", (""));
                                HandleDetail2.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));
                                HandleDetail2.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));
                                HandleDetail2.SetAttribute("UPD_DATE", (""));

                                root1.AppendChild(HandleDetail2);
                                #endregion
                            }
                        }
                    }


                    #region INSERT STOCK MODEL COST

                    XmlDocument XDoc2 = new XmlDocument();
                    XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                    XDoc2.AppendChild(dec2);// Create the root element
                    XmlElement root2 = XDoc2.CreateElement("root");
                    XDoc2.AppendChild(root2);

                    foreach (GridViewRow row in GvStockModelCost.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {

                            TextBox TxtFromAmt = row.FindControl("TxtFromAmt") as TextBox;
                            TextBox TxtToAmt = row.FindControl("TxtToAmt") as TextBox;
                            DropDownList DdlCostlevel = row.FindControl("DdlCostlevel") as DropDownList;
                            HiddenField HfSrNo = row.FindControl("HfSrNo") as HiddenField;

                            XmlElement HandleDetail3 = XDoc2.CreateElement("StockModelCost");
                            HandleDetail3.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());

                            //HandleDetail3.SetAttribute("SRNO", HfSrNo.Value.Trim());
                            if(TxtFromAmt.Text==string.Empty)
                            {
                                HandleDetail3.SetAttribute("FRAMT", ("0"));
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("FRAMT", (TxtFromAmt.Text));
                            }
                           if(TxtToAmt.Text==string.Empty)
                            {
                                HandleDetail3.SetAttribute("TOAMT", ("0"));
                            }
                           else
                            {
                                HandleDetail3.SetAttribute("TOAMT", (TxtToAmt.Text));
                            }
                           
                            HandleDetail3.SetAttribute("COST_LEVEL", (DdlCostlevel.SelectedValue));

                            HandleDetail3.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));
                            HandleDetail3.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));
                            HandleDetail3.SetAttribute("INS_DATE", (""));
                            HandleDetail3.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));
                            HandleDetail3.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));
                            HandleDetail3.SetAttribute("UPD_DATE", (""));


                            root2.AppendChild(HandleDetail3);

                        }
                    }

                    #endregion

                    string str = STOCK_MODELMASLogicLayer.InsertSTOCK_MODELMASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml));

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "STOCK MODEL MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillStockModelMasterGrid();
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "STOCK MODEL MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : STOCK MODEL MASTER NOT SAVED";
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
                if (HfModelCode.Value != string.Empty)
                {
                    string str = STOCK_MODELMASLogicLayer.DeleteSTOCK_MODELMASDetailsByID(HfModelCode.Value);
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
                        lblmsg.Text = "Error:Stock Model Master Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillStockModelMasterGrid();
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvStockModalDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvStockModalDetails.PageIndex = e.NewPageIndex;
                clear();
                FillStockModalDetailGrid();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStockModalDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField HfModelCode = (e.Row.FindControl("HfModelCode") as HiddenField);
                    TextBox TxtProductCode = (e.Row.FindControl("TxtProductCode") as TextBox);
                    TextBox TxtProductName = (e.Row.FindControl("TxtProductName") as TextBox);
                    HiddenField HfDetailSCode = (e.Row.FindControl("HfDetailSCode") as HiddenField);
                    
                    DataTable DtProduct = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();

                    DtProduct = STOCK_MASLogicLayer.GetAllSTOCK_MASDetialsWIiseCompanyFor_DDL(Comp_Code);
                    //DdlProductName.DataValueField = "SCODE";
                    //DdlProductName.DataTextField = "SNAME";
                    //DdlProductName.DataSource = Dt;
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

        #region STOCK COST MODEL DETAILS GRID

        private void ClearStockModelCostGrid()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("FRAMT", typeof(string));
            table.Columns.Add("TOAMT", typeof(string));
            table.Columns.Add("COST_LEVEL", typeof(string));

            dr = table.NewRow();
            dr["SRNO"] = 1;
            dr["FRAMT"] = string.Empty;
            dr["TOAMT"] = string.Empty;
            dr["COST_LEVEL"] = string.Empty;

            table.Rows.Add(dr);

            ViewState["CurrentTableCost"] = table;

            GvStockModelCost.DataSource = table;
            GvStockModelCost.DataBind();
        }

        private void SetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("FRAMT", typeof(string));
            table.Columns.Add("TOAMT", typeof(string));
            table.Columns.Add("COST_LEVEL", typeof(string));

            dr = table.NewRow();
            dr["SRNO"] = 1;
            dr["FRAMT"] = string.Empty;
            dr["TOAMT"] = string.Empty;
            dr["COST_LEVEL"] = string.Empty;

            table.Rows.Add(dr);

            ViewState["CurrentTableCost"] = table;

            GvStockModelCost.DataSource = table;
            GvStockModelCost.DataBind();
        }

        private void AddNewRowToGrid()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTableCost"] != null)
            {
                DataTable dtCurrentTableCost = (DataTable)ViewState["CurrentTableCost"];
                DataRow drCurrentRow = null;
                if (dtCurrentTableCost.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTableCost.Rows.Count; i++)
                    {
                        //extract the TextBox values 

                        TextBox TxtFromAmt = (TextBox)GvStockModelCost.Rows[rowIndex].Cells[1].FindControl("TxtFromAmt");
                        TextBox TxtToAmt = (TextBox)GvStockModelCost.Rows[rowIndex].Cells[2].FindControl("TxtToAmt");
                        DropDownList DdlCostlevel = (DropDownList)GvStockModelCost.Rows[rowIndex].Cells[3].FindControl("DdlCostlevel");

                        drCurrentRow = dtCurrentTableCost.NewRow();
                        drCurrentRow["SRNO"] = i + 1;

                        dtCurrentTableCost.Rows[i - 1]["FRAMT"] = TxtFromAmt.Text;
                        dtCurrentTableCost.Rows[i - 1]["TOAMT"] = TxtToAmt.Text;
                        dtCurrentTableCost.Rows[i - 1]["COST_LEVEL"] = DdlCostlevel.SelectedValue;

                        rowIndex++;
                    }

                    drCurrentRow = dtCurrentTableCost.NewRow();
                    drCurrentRow["FRAMT"] = "0";
                    drCurrentRow["TOAMT"] = "0";
                    drCurrentRow["COST_LEVEL"] = "";
                   

                    dtCurrentTableCost.Rows.Add(drCurrentRow);
                    ViewState["CurrentTableCost"] = dtCurrentTableCost;

                    GvStockModelCost.DataSource = dtCurrentTableCost;
                    GvStockModelCost.DataBind();
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
            if (ViewState["CurrentTableCost"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTableCost"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox TxtFromAmt = (TextBox)GvStockModelCost.Rows[rowIndex].Cells[1].FindControl("TxtFromAmt");
                        TextBox TxtToAmt = (TextBox)GvStockModelCost.Rows[rowIndex].Cells[2].FindControl("TxtToAmt");
                        DropDownList DdlCostlevel = (DropDownList)GvStockModelCost.Rows[rowIndex].Cells[3].FindControl("DdlCostlevel");

                        TxtFromAmt.Text = dt.Rows[i]["FRAMT"].ToString();
                        TxtToAmt.Text = dt.Rows[i]["TOAMT"].ToString();
                        DdlCostlevel.SelectedValue = dt.Rows[i]["COST_LEVEL"].ToString();

                        rowIndex++;
                    }
                }
            }
        }
        protected void BtnAddRowModelCostGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        protected void BtnDeleteRowModelCostGrid_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex + 1;
            if (ViewState["CurrentTableCost"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTableCost"];
                if (dt.Rows.Count > 1)
                {

                    if (gvRow.RowIndex <= dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data
                        dt.Rows.Remove(dt.Rows[rowID - 1]);
                    }
                }
                //Store the current data in ViewState for future reference
                ViewState["CurrentTableCost"] = dt;
                //Re bind the GridView for the updated data
                GvStockModelCost.DataSource = dt;
                GvStockModelCost.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }

        #endregion


        #region  STOCK MODEL DETAILS GRID

        private void ClearStockModelDeatilGrid()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("CHK_MAJOR", typeof(string));
            table.Columns.Add("CHK_NORMAL", typeof(string));
            table.Columns.Add("ORD", typeof(string));

            dr = table.NewRow();
            dr["SRNO"] = string.Empty;
            dr["SCODE"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["CHK_MAJOR"] = false;
            dr["CHK_NORMAL"] = false;
            dr["ORD"] = string.Empty;

            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvStockModalDetails.DataSource = table;
            GvStockModalDetails.DataBind();
        }

        private void SetInitialRow1()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("SCODE", typeof(string));
            table.Columns.Add("QTY", typeof(string));
            table.Columns.Add("CHK_MAJOR", typeof(string));
            table.Columns.Add("CHK_NORMAL", typeof(string));
            table.Columns.Add("ORD", typeof(string));

            dr = table.NewRow();
            dr["SRNO"] = string.Empty;
            dr["SCODE"] = string.Empty;
            dr["QTY"] = string.Empty;
            dr["CHK_MAJOR"] = false;
            dr["CHK_NORMAL"] = false;
            dr["ORD"] = string.Empty;

            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvStockModalDetails.DataSource = table;
            GvStockModalDetails.DataBind();
        }

        private void AddNewRowToGrid1()
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
                        HiddenField HfDetailSCode = (HiddenField)GvStockModalDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtOrder = (TextBox)GvStockModalDetails.Rows[rowIndex].Cells[1].FindControl("TxtOrder");
                        TextBox TxtProductCode = (TextBox)GvStockModalDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvStockModalDetails.Rows[rowIndex].Cells[3].FindControl("TxtProductName");
                        TextBox TxtQuantity = (TextBox)GvStockModalDetails.Rows[rowIndex].Cells[4].FindControl("TxtQuantity");
                        CheckBox ChkBoxMajor = (CheckBox)GvStockModalDetails.Rows[rowIndex].Cells[5].FindControl("ChkBoxMajor");
                        CheckBox ChkBoxNormal = (CheckBox)GvStockModalDetails.Rows[rowIndex].Cells[6].FindControl("ChkBoxNormal");

                        

                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value;
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["CHK_MAJOR"] = ChkBoxMajor.Checked;
                        dtCurrentTable.Rows[i - 1]["CHK_NORMAL"] = ChkBoxNormal.Checked;
                        dtCurrentTable.Rows[i - 1]["ORD"] = TxtOrder.Text;

                        rowIndex++;

                    }

                    drCurrentRow = dtCurrentTable.NewRow();
                 //   drCurrentRow["SRNO"] = rowIndex + 1;
                    drCurrentRow["SCODE"] = "0";
                    drCurrentRow["QTY"] = "0";
                    drCurrentRow["CHK_MAJOR"] = "false";
                    drCurrentRow["CHK_NORMAL"] = "false";
                    drCurrentRow["ORD"] = "0";

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvStockModalDetails.DataSource = dtCurrentTable;
                    GvStockModalDetails.DataBind();
                }
            }

            else
            {
                Response.Write("ViewState is null");
            }


            SetPreviousData1();
        }

        private void SetPreviousData1()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        HiddenField HfDetailSCode = (HiddenField)GvStockModalDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtOrder = (TextBox)GvStockModalDetails.Rows[rowIndex].Cells[1].FindControl("TxtOrder");
                        TextBox TxtProductCode = (TextBox)GvStockModalDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvStockModalDetails.Rows[rowIndex].Cells[3].FindControl("TxtProductName");
                        TextBox TxtQuantity = (TextBox)GvStockModalDetails.Rows[rowIndex].Cells[4].FindControl("TxtQuantity");
                        CheckBox ChkBoxMajor = (CheckBox)GvStockModalDetails.Rows[rowIndex].Cells[5].FindControl("ChkBoxMajor");
                        CheckBox ChkBoxNormal = (CheckBox)GvStockModalDetails.Rows[rowIndex].Cells[6].FindControl("ChkBoxNormal");

                        HfDetailSCode.Value = dt.Rows[i]["SCODE"].ToString();
                        TxtQuantity.Text = dt.Rows[i]["QTY"].ToString();
                        ChkBoxMajor.Checked = Convert.ToBoolean(dt.Rows[i]["CHK_MAJOR"].ToString());
                        ChkBoxNormal.Checked = Convert.ToBoolean(dt.Rows[i]["CHK_NORMAL"].ToString());
                        TxtOrder.Text = dt.Rows[i]["ORD"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        protected void BtnAddRowModelDetailGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid1();
        }

        protected void BtnDeleteRowModelDetailGrid_Click(object sender, EventArgs e)
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
                GvStockModalDetails.DataSource = dt;
                GvStockModalDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData1();

        }

        #endregion

        protected void GvStockModelMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow) // Bind nested grid view with parent grid view
                {
                    string Id = ((HiddenField)e.Row.FindControl("HfModelCodeGrid")).Value;
                    GridView ModelDet = (GridView)e.Row.FindControl("GvNestedStockModalDetails");
                    GridView ModelCost = (GridView)e.Row.FindControl("GvNestedStockModelCost");

                    DataTable Dt = new DataTable();

                    Dt = STOCK_MODELDETLogicLayer.GetAll_MODELCODEEWise_STOCK_MODELDET(Id);
                    ModelDet.DataSource = Dt;
                    ModelDet.DataBind();

                    DataTable DtCost = STOCK_MODELCOSTLogicLayer.GetAll_MODELCODEEWise_STOCK_MODELCOST(Id);
                    ModelCost.DataSource = DtCost;
                    ModelCost.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void  DdlProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Response.Write("jigar");
            //DropDownList chk = (DropDownList)sender;
            //GridViewRow row = (GridViewRow)chk.Parent.Parent;
            //Response.Write(chk.SelectedValue.ToString());

            //try
            //{
            //    System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            //    con.Open();
            //    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select SM.PROD_CODE from STOCK_MAS SM INNER JOIN ACCOUNTS_STOCKMAS ASM ON ASM.SCODE= SM.SCODE where  SM.SCODE = '" + chk.SelectedValue.ToString() + "'", con);
            //    productcode = cmd.ExecuteScalar().ToString();
            //    con.Close();
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
        }

        protected void GvStockModelCost_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField HfCostlevel = (e.Row.FindControl("HfCostlevel") as HiddenField);
                    DropDownList DdlCostlevel = (e.Row.FindControl("DdlCostlevel") as DropDownList);

                    DdlCostlevel.SelectedValue = HfCostlevel.Value;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnCopyModelItem_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelCopyModelItem", "ShowModelCopyModelItem()", true);
         
            FillDdlBrandName();
            FillDdlModelNameByBrand();
        }


        public void FillDdlBrandName()
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();
                DdlBrandNameCopy.SelectedValue = HfBrandCode.Value;

                DataTable Dt = new DataTable();
                Dt = STOCK_BRANDMASLogicLayer.GetSTOCKBRANDMAS_BrandNameCompanyWiseFor_Ddl(Comp_Code);
                DdlBrandNameCopy.DataSource = Dt;
                DdlBrandNameCopy.DataValueField = "BRAND_CODE";
                DdlBrandNameCopy.DataTextField = "BRAND_NAME";
                DdlBrandNameCopy.DataBind();
                DdlBrandNameCopy.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillDdlModelNameByBrand()
        {
            try
            {
                string Brand_Code = DdlBrandNameCopy.SelectedValue;

                DataTable Dt = new DataTable();
                Dt = STOCK_MODELMASLogicLayer.GetSTOCK_MODELMAS_ModelNameBrandWiseFor_Ddl(Brand_Code);
                DdlModelNameCopy.DataSource = Dt;
                DdlModelNameCopy.DataValueField = "MODEL_CODE";
                DdlModelNameCopy.DataTextField = "MODEL_NAME";
                DdlModelNameCopy.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlBrandNameCopy_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDdlModelNameByBrand();
        }

      
        protected void DdlModelNameCopy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnCopyProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string COMP_CODE = Session["COMP_CODE"].ToString();
                string MODEL_CODE = DdlModelNameCopy.SelectedValue;

                if(DdlModelNameCopy.SelectedIndex!=0)
                {
                    DataTable Dt = new DataTable();
                    Dt = STOCK_MODELDETLogicLayer.GetAllSTOCK_MODELDETDetailByCompanyAndModelName(COMP_CODE,MODEL_CODE);

                    DataTable table = new DataTable();
                    DataRow dr = null;
                    table.Columns.Add("SRNO", typeof(string));
                    table.Columns.Add("SCODE", typeof(string));
                    table.Columns.Add("QTY", typeof(string));
                    table.Columns.Add("CHK_MAJOR", typeof(string));
                    table.Columns.Add("CHK_NORMAL", typeof(string));
                    table.Columns.Add("ORD", typeof(string));

                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {

                            dr = table.NewRow();

                          
                            dr["SCODE"] = Dt.Rows[i]["SCODE"].ToString();
                            dr["QTY"] = Dt.Rows[i]["QTY"].ToString();
                            dr["CHK_MAJOR"] = Dt.Rows[i]["CHK_MAJOR"].ToString();
                            dr["CHK_NORMAL"] = Dt.Rows[i]["CHK_NORMAL"].ToString();
                            dr["ORD"] = Dt.Rows[i]["ORD"].ToString();

                            table.Rows.Add(dr);
                        }

                        ViewState["CurrentTable"] = table;

                        GvStockModalDetails.DataSource = table;
                        GvStockModalDetails.DataBind();

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        public void FillOnStockGridDetailChanged()
        {
            #region Assign to Stock Grid Table

            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values 
                        HiddenField HfDetailSCode = (HiddenField)GvStockModalDetails.Rows[rowIndex].Cells[0].FindControl("HfDetailSCode");
                        TextBox TxtOrder = (TextBox)GvStockModalDetails.Rows[rowIndex].Cells[1].FindControl("TxtOrder");
                        TextBox TxtProductCode = (TextBox)GvStockModalDetails.Rows[rowIndex].Cells[2].FindControl("TxtProductCode");
                        TextBox TxtProductName = (TextBox)GvStockModalDetails.Rows[rowIndex].Cells[3].FindControl("TxtProductName");
                        TextBox TxtQuantity = (TextBox)GvStockModalDetails.Rows[rowIndex].Cells[4].FindControl("TxtQuantity");
                        CheckBox ChkBoxMajor = (CheckBox)GvStockModalDetails.Rows[rowIndex].Cells[5].FindControl("ChkBoxMajor");
                        CheckBox ChkBoxNormal = (CheckBox)GvStockModalDetails.Rows[rowIndex].Cells[6].FindControl("ChkBoxNormal");



                        dtCurrentTable.Rows[i - 1]["SCODE"] = HfDetailSCode.Value;
                        dtCurrentTable.Rows[i - 1]["QTY"] = TxtQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["CHK_MAJOR"] = ChkBoxMajor.Checked;
                        dtCurrentTable.Rows[i - 1]["CHK_NORMAL"] = ChkBoxNormal.Checked;
                        dtCurrentTable.Rows[i - 1]["ORD"] = TxtOrder.Text;

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

                        FillOnStockGridDetailChanged();
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

                HiddenField HfDetailSCode = (HiddenField)row.Cells[0].FindControl("HfDetailSCode");
                TextBox TxtProductCode = (TextBox)row.Cells[1].FindControl("TxtProductCode");

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

                        FillOnStockGridDetailChanged();
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