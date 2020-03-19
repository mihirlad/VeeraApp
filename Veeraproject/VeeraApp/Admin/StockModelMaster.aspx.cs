using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp
{
    public partial class StockModelMaster : System.Web.UI.Page
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
                    FillDdlModelTypeName();
                    FillGrid(Session["COMP_CODE"].ToString());


                    string BRAND_CODE = Request.QueryString["BRAND_CODE"];
                    string COMP_CODE = Request.QueryString["COMP_CODE"];
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }



        public void FillDdlModelTypeName()
        {
            try
            {
                string Comp_Code = Session["COMP_CODE"].ToString();

                DataTable Dt = new DataTable();
                Dt = STOCK_BRANDTYPEMASLogicLayer.GetSTOCK_BRANDTYPEMASCompanyWiseFor_Ddl(Comp_Code);
                DdlModelTypeName.DataSource = Dt;
                DdlModelTypeName.DataValueField = "BRANDTYPE_CODE";
                DdlModelTypeName.DataTextField = "BRANDTYPE_NAME";
                DdlModelTypeName.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ControllerEnable()
        {
            TxtBrandName.Enabled = true;
            DdlModelTypeName.Enabled = true;
       //     lnkQuotationTerms.Enabled = true;
       //     lnkAMCTerms.Enabled = true;
       //     lnkWarrantyTerms.Enabled = true;
            TxtAMCQuoatationTerms.Enabled = true;
            TxtAMCTerms.Enabled = true;
            TxtWarrantyTerms.Enabled = true;
        }

        public void ControllerDisable()
        {
            TxtBrandName.Enabled = false;
            DdlModelTypeName.Enabled = false;
        //    lnkQuotationTerms.Enabled = false;
        //    lnkAMCTerms.Enabled = false;
        //    lnkWarrantyTerms.Enabled = false;
            TxtAMCQuoatationTerms.Enabled = false;
            TxtAMCTerms.Enabled = false;
            TxtWarrantyTerms.Enabled = false;
        }


        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfCompCode.Value = string.Empty;
            HfBrandCode.Value = string.Empty;
            TxtBrandName.Text = string.Empty;
            DdlModelTypeName.SelectedIndex = 0;
            //lnkQuotationTerms.Checked = false;
            //lnkAMCTerms.Checked = false;
            //lnkWarrantyTerms.Checked = false;
            TxtAMCQuoatationTerms.Text = string.Empty;
            TxtAMCTerms.Text = string.Empty;
            TxtWarrantyTerms.Text = string.Empty;

            BtncallUpd.Text = "SAVE";
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
                #region INSERT_UPDATE BRAND_MASTER


                STOCK_BRANDMASLogicLayer insert = new STOCK_BRANDMASLogicLayer();
                insert.COMP_CODE = Session["COMP_CODE"].ToString();
                insert.BRAND_CODE = HfBrandCode.Value.Trim();
                insert.BRAND_NAME = TxtBrandName.Text.Trim().ToUpper();
                insert.BRANDTYPE_CODE = DdlModelTypeName.SelectedValue.Trim();
                insert.BRAND_TERMS = TxtAMCQuoatationTerms.Text.Trim();
                insert.BRAND_AMC_TERMS = TxtAMCTerms.Text.Trim();
                insert.BRAND_WARRANTY_TERMS = TxtWarrantyTerms.Text.Trim();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";

                #endregion

                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = STOCK_BRANDMASLogicLayer.InsertSTOCK_BRANDMASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "BRAND MASTER DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(Session["COMP_CODE"].ToString());
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "BRAND CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : BRAND MASTER DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    string str = STOCK_BRANDMASLogicLayer.UpdateSTOCK_BRANDMASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "BRAND MASTER DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid(Session["COMP_CODE"].ToString());
                        UserRights();
                    }
                    else if (str.Contains("Already"))
                    {
                        lblmsg.Text = "BRAND CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : BRAND MASTER NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvStockBrandMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
          
        }


        public string encrypt(string encryptString)
        {
            string EncryptionKey = "mihirlad9021";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
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

        protected void GvStockBrandMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "AddModel")
                {
                    int id = int.Parse(e.CommandArgument.ToString());
               
                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow gvRow = ctrl.Parent.NamingContainer as GridViewRow;

                        HiddenField HfCompCodeGrid = (HiddenField)gvRow.FindControl("HfCompCodeGrid");

                        Label lbl1 = (Label)gvRow.FindControl("lblBrandName");
                        Session["lblBrandName"] = lbl1.Text.ToString();

                        Label lbl = (Label)gvRow.FindControl("lblModelTypeName");
                        Session["lblModelTypeName"] = lbl.Text.ToString();

                        string COMP_CODE = HttpUtility.UrlEncode(encrypt(HfCompCodeGrid.Value));
                        string BRAND_CODE = HttpUtility.UrlEncode(encrypt(Convert.ToString(id)));


                        Response.Write("<script>window.open ('StockModelMaster2.aspx?BRAND_CODE=" + BRAND_CODE + "&COMP_CODE=" + COMP_CODE + "', '_blank');</script>");

                    }
                }

                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataTable dt = STOCK_BRANDMASLogicLayer.GetAllIDWiseSTOCK_BRANDMASDetail(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBrandCode.Value = dt.Rows[0]["BRAND_CODE"].ToString();
                        TxtBrandName.Text = dt.Rows[0]["BRAND_NAME"].ToString();
                        DdlModelTypeName.SelectedValue = dt.Rows[0]["BRANDTYPE_CODE"].ToString();
                        TxtAMCQuoatationTerms.Text = dt.Rows[0]["BRAND_TERMS"].ToString();
                        TxtAMCTerms.Text = dt.Rows[0]["BRAND_AMC_TERMS"].ToString();
                        TxtWarrantyTerms.Text = dt.Rows[0]["BRAND_WARRANTY_TERMS"].ToString();

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
                    DataTable dt = STOCK_BRANDMASLogicLayer.GetAllIDWiseSTOCK_BRANDMASDetail(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBrandCode.Value = dt.Rows[0]["BRAND_CODE"].ToString();
                        TxtBrandName.Text = dt.Rows[0]["BRAND_NAME"].ToString();
                        DdlModelTypeName.SelectedValue = dt.Rows[0]["BRANDTYPE_CODE"].ToString();
                        TxtAMCQuoatationTerms.Text = dt.Rows[0]["BRAND_TERMS"].ToString();
                        TxtAMCTerms.Text = dt.Rows[0]["BRAND_AMC_TERMS"].ToString();
                        TxtWarrantyTerms.Text = dt.Rows[0]["BRAND_WARRANTY_TERMS"].ToString();

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

                }


                if (e.CommandName == "Viewa")
                {
                    #region SET TEXT ON VIEW
                    clear();
                    DataTable dt = STOCK_BRANDMASLogicLayer.GetAllIDWiseSTOCK_BRANDMASDetail(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                        HfBrandCode.Value = dt.Rows[0]["BRAND_CODE"].ToString();
                        TxtBrandName.Text = dt.Rows[0]["BRAND_NAME"].ToString();
                        DdlModelTypeName.SelectedValue = dt.Rows[0]["BRANDTYPE_CODE"].ToString();
                        TxtAMCQuoatationTerms.Text = dt.Rows[0]["BRAND_TERMS"].ToString();
                        TxtAMCTerms.Text = dt.Rows[0]["BRAND_AMC_TERMS"].ToString();
                        TxtWarrantyTerms.Text = dt.Rows[0]["BRAND_WARRANTY_TERMS"].ToString();

                        #endregion
                    }

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



        public void FillGrid(string CompCode)
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = STOCK_BRANDMASLogicLayer.GetAllSTOCK_BRANDMASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvStockBrandMaster.DataSource = Dv.ToTable();
                GvStockBrandMaster.DataBind();
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
                    #region INSERT BRAND MASTER

                    STOCK_BRANDMASLogicLayer insert = new STOCK_BRANDMASLogicLayer();
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.BRAND_CODE = HfBrandCode.Value.Trim();
                    insert.BRAND_NAME = TxtBrandName.Text.Trim().ToUpper();
                    insert.BRANDTYPE_CODE = DdlModelTypeName.SelectedValue.Trim();
                    insert.BRAND_TERMS = TxtAMCQuoatationTerms.Text.Trim();
                    insert.BRAND_AMC_TERMS = TxtAMCTerms.Text.Trim();
                    insert.BRAND_WARRANTY_TERMS = TxtWarrantyTerms.Text.Trim();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";

                    #endregion

                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = STOCK_BRANDMASLogicLayer.InsertSTOCK_BRANDMASDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "STOCK BRAND MASTER DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid(Session["COMP_CODE"].ToString());
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "STOCK BRAND CODE ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : STOCK BRAND MASTER DETAIL NOT SAVED";
                            lblmsg.ForeColor = Color.Red;
                        }
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
                if (HfBrandCode.Value != string.Empty)
                {
                    string str =STOCK_BRANDMASLogicLayer.DeleteSTOCK_BRANDMASDetailByID(HfBrandCode.Value);
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
                        lblmsg.Text = "Error:Stock Brand Master Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillGrid(Session["COMP_CODE"].ToString());
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void lnkQuotationTerms_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelAMCQuotationTerms", "ShowModelAMCQuotationTerms()", true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void lnkAMCTerms_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelAMCTerms", "ShowModelAMCTerms()", true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void lnkWarrantyTerms_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModelWarrantyTerms", "ShowModelWarrantyTerms()", true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
