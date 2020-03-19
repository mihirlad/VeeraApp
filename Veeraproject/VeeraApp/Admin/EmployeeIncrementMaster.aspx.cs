using MihirValid;
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
    public partial class EmployeeIcrementMaster : System.Web.UI.Page
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
                    DivView.Visible = true;
                   FillINCREMENT_MasterGrid(Session["COMP_CODE"].ToString());
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
            
            TxtFromDate.Enabled = false;
            TxtToDate.Enabled = false;
            TxtRemark.Enabled = false;
            DdlActive.Enabled = false;
        }
        public void ControllerEnable()
        {
          
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
            TxtFromDate.Text = string.Empty;
            TxtToDate.Text = string.Empty;
            TxtRemark.Text = string.Empty;
            DdlActive.SelectedIndex = 0;

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
               // FillStockPriceDetailGrid();


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


        public void FillINCREMENT_MasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = INCREMENT_MASLogicLayer.GetAllINCREMENT_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvIncrementTransactionMaster.DataSource = Dv.ToTable();
            GvIncrementTransactionMaster.DataBind();

            DtSearch = Dv.ToTable();

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
                    #region INSERT INTO INCREMENT MASTER

                    INCREMENT_MASLogicLayer insert = new INCREMENT_MASLogicLayer();

                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.YRDT1 = Convert.ToDateTime(TxtFromDate.Text.Trim()).ToString("MM-dd-yyyy");  //Session["FIN_YEAR"].ToString();
                    insert.YRDT2 = Convert.ToDateTime(TxtToDate.Text.Trim()).ToString("MM-dd-yyyy");  //Session["FIN_YEAR_END"].ToString();
                    insert.ACTIVE = DdlActive.SelectedValue.Trim().ToUpper().ToString();
                    insert.REMARK = TxtRemark.Text.Trim().ToString();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_DATE = "";
                    //insert.UPD_USERID = Session["USERNAME"].ToString();
                    //insert.UPD_DATE = "";

                    #endregion

                    //#region INSERT INTO INCREMENT TRANSACTION DETAILS

                    //XmlDocument XDoc1 = new XmlDocument();
                    //XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    //XDoc1.AppendChild(dec1);// Create the root element
                    //XmlElement root1 = XDoc1.CreateElement("root");
                    //XDoc1.AppendChild(root1);


                    //foreach (GridViewRow row in GvIncrementTransactionDet.Rows)
                    //{
                    //    if (row.RowType == DataControlRowType.DataRow)
                    //    {
                    //        HiddenField HfCompCode = row.FindControl("HfCompCode") as HiddenField;
                    //        HiddenField HfYRDT1 = row.FindControl("HfYRDT1") as HiddenField;
                    //        HiddenField HfEmployeeCode = row.FindControl("HfEmployeeCode") as HiddenField;

                    //        TextBox TxtBasicRate = row.FindControl("TxtBasicRate") as TextBox;
                    //        TextBox TxtConvRate = row.FindControl("TxtConvRate") as TextBox;
                    //        TextBox TxtMedicalRate = row.FindControl("TxtMedicalRate") as TextBox;
                    //        TextBox TxtHRARate = row.FindControl("TxtHRARate") as TextBox;
                    //        TextBox TxtOldBasicRate = row.FindControl("TxtOldBasicRate") as TextBox;
                    //        TextBox TxtOldConvRate = row.FindControl("TxtOldConvRate") as TextBox;
                    //        TextBox TxtOldMedicalRate = row.FindControl("TxtOldMedicalRate") as TextBox;
                    //        TextBox TxtOldHRARate = row.FindControl("TxtOldHRARate") as TextBox;


                    //        if (HfEmployeeCode.Value != string.Empty && HfEmployeeCode.Value != null)
                    //        {


                    //            XmlElement HandleDetail2 = XDoc1.CreateElement("PAY_REC_Details");

                    //            //HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                    //            //HandleDetail2.SetAttribute("YRDT1", HfYRDT1.Value.Trim());
                    //            //HandleDetail2.SetAttribute("EMP_CODE", HfEmployeeCode.Value.Trim());

                    //            if(TxtBasicRate.Text!=string.Empty)
                    //            {
                    //                HandleDetail2.SetAttribute("BASIC_RATE", TxtBasicRate.Text.Trim());
                    //            }

                    //            if (TxtConvRate.Text != string.Empty)
                    //            {
                    //                HandleDetail2.SetAttribute("CONV_RATE", TxtConvRate.Text.Trim());
                    //            }

                    //            if (TxtMedicalRate.Text != string.Empty)
                    //            {
                    //                HandleDetail2.SetAttribute("MEDICAL_RATE", TxtMedicalRate.Text.Trim());
                    //            }

                    //            if (TxtHRARate.Text != string.Empty)
                    //            {
                    //                HandleDetail2.SetAttribute("HRA_RATE", TxtHRARate.Text.Trim());
                    //            }

                    //            if (TxtOldBasicRate.Text != string.Empty)
                    //            {
                    //                HandleDetail2.SetAttribute("OLD_BASIC_RATE", TxtOldBasicRate.Text.Trim());
                    //            }

                    //            if (TxtOldConvRate.Text != string.Empty)
                    //            {
                    //                HandleDetail2.SetAttribute("OLD_CONV_RATE", TxtOldConvRate.Text.Trim());
                    //            }

                    //            if (TxtOldMedicalRate.Text != string.Empty)
                    //            {
                    //                HandleDetail2.SetAttribute("OLD_MEDICAL_RATE", TxtOldMedicalRate.Text.Trim());
                    //            }

                    //            if (TxtOldHRARate.Text != string.Empty)
                    //            {
                    //                HandleDetail2.SetAttribute("OLD_HRA_RATE", TxtOldHRARate.Text.Trim());
                    //            }



                    //            root1.AppendChild(HandleDetail2);


                    //        }
                    //    }
                    //}

                    //#endregion


                    string str = INCREMENT_MASLogicLayer.InsertINCREMENT_TRAN_MASDetail(insert);

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "INCREMENT MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillINCREMENT_MasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "INCREMENT MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : INCREMENT MASTER NOT SAVED";
                        lblmsg.ForeColor = Color.Red;

                    }
                }
            }



            catch (Exception)
            {

                throw;
            }
        }



        protected void GvIncrementTransactionDet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvIncrementTransactionDet.PageIndex = e.NewPageIndex;
          //  FillREC_ISS_MasterGrid(Session["COMP_CODE"].ToString());
            clear();
        }


        protected void GvIncrementTransactionMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvIncrementTransactionMaster.PageIndex = e.NewPageIndex;
            FillINCREMENT_MasterGrid(Session["COMP_CODE"].ToString());
            clear();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
        }

        protected void Btncalldel_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE  

                string str = INCREMENT_MASLogicLayer.DeleteINCREMENT_TRAN_MASDetaislByID(HfCompCode.Value.ToString(),Convert.ToDateTime(TxtFromDate.Text.Trim().ToString()).ToString("yyyy-MM-dd"));
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
                    lblmsg.Text = "Error:Increment Master Deleted";
                    lblmsg.ForeColor = Color.Red;
                }

                clear();
                UserRights();
               FillINCREMENT_MasterGrid(Convert.ToString(Session["COMP_CODE"]));

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
                #region UPDATE INCREMENT TRANSACTION MASTER DETAILS

                #region INSERT INTO INCREMENT MASTER

                INCREMENT_MASLogicLayer insert = new INCREMENT_MASLogicLayer();

                insert.COMP_CODE = HfCompCode.Value.Trim();
                insert.YRDT1 = Convert.ToDateTime(TxtFromDate.Text.Trim()).ToString("MM-dd-yyyy");  //Session["FIN_YEAR"].ToString();
                insert.YRDT2 = Convert.ToDateTime(TxtToDate.Text.Trim()).ToString("MM-dd-yyyy");  //Session["FIN_YEAR_END"].ToString();
                insert.ACTIVE = DdlActive.SelectedValue.Trim().ToUpper().ToString();
                insert.REMARK = TxtRemark.Text.Trim().ToString();
                //insert.INS_USERID = Session["USERNAME"].ToString();
                //insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_DATE = "";

                #endregion

                #region INSERT INTO INCREMENT TRANSACTION DETAILS

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);


                foreach (GridViewRow row in GvIncrementTransactionDet.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfCompCode = row.FindControl("HfCompCode") as HiddenField;
                        HiddenField HfYRDT1 = row.FindControl("HfYRDT1") as HiddenField;
                        HiddenField HfEmployeeCode = row.FindControl("HfEmployeeCode") as HiddenField;

                        TextBox TxtBasicRate = row.FindControl("TxtBasicRate") as TextBox;
                        TextBox TxtConvRate = row.FindControl("TxtConvRate") as TextBox;
                        TextBox TxtMedicalRate = row.FindControl("TxtMedicalRate") as TextBox;
                        TextBox TxtHRARate = row.FindControl("TxtHRARate") as TextBox;
                        TextBox TxtOldBasicRate = row.FindControl("TxtOldBasicRate") as TextBox;
                        TextBox TxtOldConvRate = row.FindControl("TxtOldConvRate") as TextBox;
                        TextBox TxtOldMedicalRate = row.FindControl("TxtOldMedicalRate") as TextBox;
                        TextBox TxtOldHRARate = row.FindControl("TxtOldHRARate") as TextBox;


                        if (HfEmployeeCode.Value != string.Empty && HfEmployeeCode.Value != null)
                        {


                            XmlElement HandleDetail2 = XDoc1.CreateElement("INCREMENT_TRAN_Details");

                            HandleDetail2.SetAttribute("COMP_CODE", HfCompCode.Value.Trim());
                            HandleDetail2.SetAttribute("YRDT1", (Convert.ToDateTime(TxtFromDate.Text.Trim())).ToString("yyyy-MM-dd"));
                            HandleDetail2.SetAttribute("EMP_CODE", HfEmployeeCode.Value.Trim());

                            if (TxtBasicRate.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("BASIC_RATE", TxtBasicRate.Text.Trim());
                            }

                            if (TxtConvRate.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("CONV_RATE", TxtConvRate.Text.Trim());
                            }

                            if (TxtMedicalRate.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("MEDICAL_RATE", TxtMedicalRate.Text.Trim());
                            }

                            if (TxtHRARate.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("HRA_RATE", TxtHRARate.Text.Trim());
                            }

                            if (TxtOldBasicRate.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("OLD_BASIC_RATE", TxtOldBasicRate.Text.Trim());
                            }

                            if (TxtOldConvRate.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("OLD_CONV_RATE", TxtOldConvRate.Text.Trim());
                            }

                            if (TxtOldMedicalRate.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("OLD_MEDICAL_RATE", TxtOldMedicalRate.Text.Trim());
                            }

                            if (TxtOldHRARate.Text != string.Empty)
                            {
                                HandleDetail2.SetAttribute("OLD_HRA_RATE", TxtOldHRARate.Text.Trim());
                            }

                            root1.AppendChild(HandleDetail2);


                        }
                    }
                }

                #endregion


                string str = INCREMENT_MASLogicLayer.UpdateINCREMENT_TRAN_MASDetail(insert, validation.RSC(XDoc1.OuterXml));

                if (str.Contains("successfully"))
                {

                    lblmsg.Text = "INCREMENT TRANSACTION MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillINCREMENT_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "INCREMENT TRANSACTION MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : INCREMENT TRANSACTIONMASTER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }


                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvIncrementTransactionMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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

                        HiddenField HfYRDT1 = (row.FindControl("HfYRDT1")) as HiddenField;


                        DataSet ds = INCREMENT_MASLogicLayer.GetAllIDWiseINCREMENT_MAS_TRANSACTION_Details(e.CommandArgument.ToString(), Convert.ToDateTime(HfYRDT1.Value.Trim()).ToString("yyyy-MM-dd"));
                        DataTable dtMAS = ds.Tables[0];
                        DataTable dTRANS = ds.Tables[1];

                        if (dtMAS.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dtMAS.Rows[0]["COMP_CODE"].ToString();
                            TxtFromDate.Text = Convert.ToDateTime(dtMAS.Rows[0]["YRDT1"].ToString()).ToString("dd-MM-yyyy");
                            TxtToDate.Text = Convert.ToDateTime(dtMAS.Rows[0]["YRDT2"].ToString()).ToString("dd-MM-yyyy");
                            TxtRemark.Text = dtMAS.Rows[0]["REMARK"].ToString();
                            DdlActive.SelectedValue = dtMAS.Rows[0]["ACTIVE"].ToString();

                        }

                        if (dTRANS.Rows.Count > 0)
                        {
                            GvIncrementTransactionDet.DataSource = dTRANS;
                            GvIncrementTransactionDet.DataBind();
                        }


                        btnSave.Visible = false;
                        btnDelete.Visible = true;
                        Btncalldel.Visible = true;
                        BtncallUpd.Visible = false;
                        ControllerDisable();


                    }
                    #endregion
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

                        HiddenField HfYRDT1 = (row.FindControl("HfYRDT1")) as HiddenField;


                        DataSet ds = INCREMENT_MASLogicLayer.GetAllIDWiseINCREMENT_MAS_TRANSACTION_Details(e.CommandArgument.ToString(), Convert.ToDateTime(HfYRDT1.Value.Trim()).ToString("yyyy-MM-dd"));
                        DataTable dtMAS = ds.Tables[0];
                        DataTable dTRANS = ds.Tables[1];

                        if (dtMAS.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dtMAS.Rows[0]["COMP_CODE"].ToString();
                            TxtFromDate.Text = Convert.ToDateTime(dtMAS.Rows[0]["YRDT1"].ToString()).ToString("dd-MM-yyyy");
                            TxtToDate.Text = Convert.ToDateTime(dtMAS.Rows[0]["YRDT2"].ToString()).ToString("dd-MM-yyyy");
                            TxtRemark.Text = dtMAS.Rows[0]["REMARK"].ToString();
                            DdlActive.SelectedValue = dtMAS.Rows[0]["ACTIVE"].ToString();

                        }

                        if (dTRANS.Rows.Count > 0)
                        {
                            GvIncrementTransactionDet.DataSource = dTRANS;
                            GvIncrementTransactionDet.DataBind();
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

                        HiddenField HfYRDT1 = (row.FindControl("HfYRDT1")) as HiddenField;


                        DataSet ds = INCREMENT_MASLogicLayer.GetAllIDWiseINCREMENT_MAS_TRANSACTION_Details(e.CommandArgument.ToString(), Convert.ToDateTime(HfYRDT1.Value.Trim()).ToString("yyyy-MM-dd"));
                        DataTable dtMAS = ds.Tables[0];
                        DataTable dTRANS = ds.Tables[1];

                        if (dtMAS.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dtMAS.Rows[0]["COMP_CODE"].ToString();
                            TxtFromDate.Text = Convert.ToDateTime(dtMAS.Rows[0]["YRDT1"].ToString()).ToString("dd-MM-yyyy");
                            TxtToDate.Text = Convert.ToDateTime(dtMAS.Rows[0]["YRDT2"].ToString()).ToString("dd-MM-yyyy");
                            TxtRemark.Text = dtMAS.Rows[0]["REMARK"].ToString();
                            DdlActive.SelectedValue = dtMAS.Rows[0]["ACTIVE"].ToString();

                        }

                        if (dTRANS.Rows.Count > 0)
                        {
                            GvIncrementTransactionDet.DataSource = dTRANS;
                            GvIncrementTransactionDet.DataBind();
                        }


                        #endregion
                        ControllerDisable();
                        btnSave.Visible = false;
                        Btncalldel.Visible = false;
                        BtncallUpd.Visible = false;
                        UserRights();
                    }
                }
            
                    }
            catch (Exception Ex)
            {

                Ex.ToString();
            }
        }
    }
}