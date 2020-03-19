using MihirValid;
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

namespace VeeraApp.Admin
{
    public partial class Journal : System.Web.UI.Page
    {

        public static string compcode;
        public static string branchCode;
        public static double netamount;
        public static double roamount; static DataTable DtSearch = new DataTable();
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
                Session["DELETE"] != null
                )
            {
                compcode = Session["COMP_CODE"].ToString();
                branchCode = Session["BRANCH_CODE"].ToString();
                if (!Page.IsPostBack)
                {
                    DivEntry.Visible = false;
                    DivView.Visible = true;
                 
                    FillJournal_Grid(Session["COMP_CODE"].ToString());
                    
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }



        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetNarrationsName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from NARRATION WHERE NARRN like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);         
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> Narration = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Narration.Add(dt.Rows[i][0].ToString());
            }
            return Narration;
        }



        private double TotalAmountGrid()
        {
            double GTotal = 0;
            for (int i = 0; i < GvJournalDetail.Rows.Count; i++)
            {
                string total = (GvJournalDetail.Rows[i].FindControl("TxtAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);

            }
            return GTotal;

        }




        protected void GvJournalMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvJournalMaster.PageIndex = e.NewPageIndex;
                clear();
                FillJournal_Grid(Session["COMP_CODE"].ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void clear()
        {
            try
            {

                DivEntry.Visible = false;
                DivView.Visible = true;

             

                TxtVoucherDate.Text = string.Empty;
                TxtVoucherNo.Text = string.Empty;
                TxtNarration.Text = string.Empty;
                TxtAccountName.Text = string.Empty;
                DdlApproveFlag.SelectedValue = "N";
                TxtApproveBy.Text = string.Empty;
                TxtApproveDate.Text = string.Empty;
                DdlConfirmFlag.SelectedValue = "N";
                TxtConfirmBy.Text = string.Empty;
                TxtConfirmDate.Text = string.Empty;
                TxtAmount.Text = string.Empty;
                DdlSign.SelectedValue = "DR";

                ClearSetInitialRow();

                BtncallUpd.Text = "SAVE";
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void ControllerEnable()
        {

            TxtVoucherDate.Enabled = true;
            TxtVoucherNo.Enabled = true;
            TxtNarration.Enabled = true;
            TxtAccountName.Enabled = true;
            DdlApproveFlag.Enabled = true;
            TxtApproveBy.Enabled = true;
            TxtApproveDate.Enabled = true;
            DdlConfirmFlag.Enabled = true;
            TxtConfirmBy.Enabled = true;
            TxtConfirmDate.Enabled = true;
            TxtAmount.Enabled = true;
            DdlSign.Enabled = true;

        }

        public void ControllerDisable()
        {
            TxtVoucherDate.Enabled = false;
            TxtVoucherNo.Enabled = false;
            TxtNarration.Enabled = false;
            TxtAccountName.Enabled = false;
            DdlApproveFlag.Enabled = false;
            TxtApproveBy.Enabled = false;
            TxtApproveDate.Enabled = false;
            DdlConfirmFlag.Enabled = false;
            TxtConfirmBy.Enabled = false;
            TxtConfirmDate.Enabled = false;
            TxtAmount.Enabled = false;
            DdlSign.Enabled = false;


        }


        public void FillJournal_Grid(string CompCode)
        {
            try
            {

                DataTable Dt = new DataTable();

                Dt = PAY_REC_MLogicLayer.GetAllPAY_REC_MDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()),"J".ToString());
                DataView Dv = new DataView(Dt);
                if (CompCode != string.Empty)
                {
                    Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
                }
                GvJournalMaster.DataSource = Dv.ToTable();
                GvJournalMaster.DataBind();

                DtSearch = Dv.ToTable();
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
                    #region INSERT Journal_M

                    PAY_REC_MLogicLayer insert = new PAY_REC_MLogicLayer();
                    //insert.TRAN_DATE = HfTranDate.Value.Trim();
                    //insert.TRAN_NO = HfTranNo.Value.Trim();
                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.ACODE = HfACODE.Value.Trim();
                    insert.ADD_ST_AMT = null;
                    insert.ADD_ST_PER = null;
                    insert.AMT = TxtAmount.Text.Trim();
                    insert.BCODE = null;
                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                    insert.CHK_FLAG = DdlApproveFlag.SelectedValue.Trim().ToUpper();
                    if (DdlApproveFlag.SelectedValue == "Y")
                    {
                        insert.CHK_DATE = Convert.ToDateTime(TxtApproveDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    }
                    else
                    {
                        insert.CHK_DATE = "";
                    }

                    if (DdlApproveFlag.SelectedValue == "Y")
                    {
                        insert.CHK_USERID = TxtApproveBy.Text.Trim().ToUpper();
                    }
                    else
                    {
                        insert.CHK_USERID = "";
                    }

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
                        insert.CONF_USERID = TxtConfirmBy.Text.Trim().ToUpper();
                    }
                    else
                    {
                        insert.CONF_USERID = "";
                    }


                    insert.ENDT = "";
                    insert.EX_CESS_AMT = null;
                    insert.EX_CESS_PER = null;
                    insert.EX_DUTY_AMT = null;
                    insert.EX_DUTY_PER = null;
                    insert.EX_SHCESS_AMT = null;
                    insert.EX_SHCESS_PER = null;
                    insert.FIGURE_FLAG = null;
                    insert.INS_DATE = "";
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.NARRN = TxtNarration.Text.Trim();
                    insert.RW_CODE = null;
                    insert.RW_TYPE = null;
                    insert.SIGN = DdlSign.SelectedValue;
                    insert.ST_AMT = null;
                    insert.ST_PER = null;
                    insert.TOT_GROSS_AMT = TxtAmount.Text.Trim();
                    insert.TRAN_TYPE = "J";
                    insert.TRNDT = null;
                    insert.TRN_TYPE = null;
                    insert.UPD_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.VOU_DATE = Convert.ToDateTime(TxtVoucherDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    insert.VOU_NO = TxtVoucherNo.Text.Trim();


                    #endregion

                



                    #region INSERT INTO PAY_REC_T 


                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int TSRNO = 1;

                    

                    foreach (GridViewRow row in GvJournalDetail.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfCreditACode = row.FindControl("HfCreditACode") as HiddenField;
                            HiddenField HfDebitACode = row.FindControl("HfDebitACode") as HiddenField;
                            TextBox TxtAccountNameG = row.FindControl("TxtAccountNameG") as TextBox;
                            DropDownList ddlSign = row.FindControl("DdlSign") as DropDownList;
                            TextBox TxtAmount = row.FindControl("TxtAmount") as TextBox;
                            TextBox TxtNarration = row.FindControl("TxtNarration") as TextBox;

                            if (TxtAccountNameG.Text != string.Empty && TxtAccountNameG.Text != null)
                            {

                                XmlElement HandleDetail2 = XDoc1.CreateElement("PAY_REC_Details");

                                HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());
                                HandleDetail2.SetAttribute("SR", TSRNO.ToString());

                                if (ddlSign.SelectedValue == "CR")
                                {
                                    HandleDetail2.SetAttribute("CRACODE", HfCreditACode.Value);
                                    HandleDetail2.SetAttribute("DRACODE", HfACODE.Value);
                                }
                                else if (ddlSign.SelectedValue == "DR")
                                {
                                    HandleDetail2.SetAttribute("CRACODE", HfACODE.Value);
                                    HandleDetail2.SetAttribute("DRACODE", HfDebitACode.Value);
                                }

                                HandleDetail2.SetAttribute("SIGN", ddlSign.SelectedValue);
                                HandleDetail2.SetAttribute("NARRN", TxtNarration.Text.Trim());

                                if (TxtAmount.Text.Trim() != string.Empty)
                                {
                                    HandleDetail2.SetAttribute("AMT", TxtAmount.Text.Trim());
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("AMT", "0");
                                }
                                HandleDetail2.SetAttribute("TRAN_TYPE", "J");
                                root1.AppendChild(HandleDetail2);
                                TSRNO++;
                            }
                        }
                    }

                    #endregion

                    Label lbllSumTotalAmountGrid = (Label)(GvJournalDetail.FooterRow.FindControl("lblSumTotalAmount"));
                    if (Convert.ToDecimal(lbllSumTotalAmountGrid.Text.Trim()) == Convert.ToDecimal(TxtAmount.Text.Trim()))
                    {

                        string str = PAY_REC_MLogicLayer.InsertPAY_REC_MDetail(insert, validation.RSC(XDoc1.OuterXml), null, Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"), "J");

                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "JOURNAL VOUCHER SAVE SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillJournal_Grid(Session["COMP_CODE"].ToString());
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "JOURNAL VOUCHER ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR :JOURNAL VOUCHER  NOT SAVED";
                            lblmsg.ForeColor = Color.Red;

                        }
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : DEBIT AND CREDIT AMOUNT SHOULD BE SAME%";
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
                string str = PAY_REC_MLogicLayer.DeletePAY_REC_MASDetailsByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value));
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
                    lblmsg.Text = "Error:Journal Voucher Deleted";
                    lblmsg.ForeColor = Color.Red;
                }
                clear();
                UserRights();
                FillJournal_Grid(Convert.ToString(Session["COMP_CODE"]));
                #endregion
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region UPDATE JOURNAL VOUCHER

                #region INSERT Journal_M

                PAY_REC_MLogicLayer insert = new PAY_REC_MLogicLayer();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.COMP_CODE = Session["COMP_CODE"].ToString();
                insert.ACODE = HfACODE.Value.Trim();
                insert.ADD_ST_AMT = null;
                insert.ADD_ST_PER = null;
                insert.AMT = TxtAmount.Text.Trim();
                insert.BCODE = null;
                insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                insert.CHK_FLAG = DdlApproveFlag.SelectedValue.Trim().ToUpper();
                if (DdlApproveFlag.SelectedValue == "Y")
                {
                    insert.CHK_DATE = Convert.ToDateTime(TxtApproveDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                }
                else
                {
                    insert.CHK_DATE = "";
                }

                if (DdlApproveFlag.SelectedValue == "Y")
                {
                    insert.CHK_USERID = TxtApproveBy.Text.Trim().ToUpper();
                }
                else
                {
                    insert.CHK_USERID = "";
                }

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
                    insert.CONF_USERID = TxtConfirmBy.Text.Trim().ToUpper();
                }
                else
                {
                    insert.CONF_USERID = "";
                }


                insert.ENDT = "";
                insert.EX_CESS_AMT = null;
                insert.EX_CESS_PER = null;
                insert.EX_DUTY_AMT = null;
                insert.EX_DUTY_PER = null;
                insert.EX_SHCESS_AMT = null;
                insert.EX_SHCESS_PER = null;
                insert.FIGURE_FLAG = null;
                insert.INS_DATE = "";
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.NARRN = TxtNarration.Text.Trim();
                insert.RW_CODE = null;
                insert.RW_TYPE = null;
                insert.SIGN = DdlSign.SelectedValue;
                insert.ST_AMT = null;
                insert.ST_PER = null;
                insert.TOT_GROSS_AMT = TxtAmount.Text.Trim();
                insert.TRAN_TYPE = "J";
                insert.TRNDT = null;
                insert.TRN_TYPE = null;
                insert.UPD_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.VOU_DATE = Convert.ToDateTime(TxtVoucherDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                insert.VOU_NO = TxtVoucherNo.Text.Trim();


                #endregion





                #region INSERT INTO PAY_REC_T 


                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);
                int TSRNO = 1;



                foreach (GridViewRow row in GvJournalDetail.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfCreditACode = row.FindControl("HfCreditACode") as HiddenField;
                        HiddenField HfDebitACode = row.FindControl("HfDebitACode") as HiddenField;
                        TextBox TxtAccountNameG = row.FindControl("TxtAccountNameG") as TextBox;
                        DropDownList ddlSign = row.FindControl("DdlSign") as DropDownList;
                        TextBox TxtAmount = row.FindControl("TxtAmount") as TextBox;
                        TextBox TxtNarration = row.FindControl("TxtNarration") as TextBox;

                        if (TxtAccountNameG.Text != string.Empty && TxtAccountNameG.Text != null)
                        {


                            XmlElement HandleDetail2 = XDoc1.CreateElement("PAY_REC_Details");

                            HandleDetail2.SetAttribute("SR", TSRNO.ToString());
                            HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());

                            if (ddlSign.SelectedValue == "CR")
                            {
                                HandleDetail2.SetAttribute("CRACODE", HfCreditACode.Value);
                                HandleDetail2.SetAttribute("DRACODE", HfACODE.Value);
                            }
                            else if (ddlSign.SelectedValue == "DR")
                            {
                                HandleDetail2.SetAttribute("CRACODE", HfACODE.Value);
                                HandleDetail2.SetAttribute("DRACODE", HfDebitACode.Value);
                            }
                            HandleDetail2.SetAttribute("SIGN", ddlSign.SelectedValue);
                            HandleDetail2.SetAttribute("NARRN", TxtNarration.Text.Trim());

                            if (TxtAmount.Text.Trim() != string.Empty)
                            {
                                HandleDetail2.SetAttribute("AMT", TxtAmount.Text.Trim());
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("AMT", "0");
                            }
                            HandleDetail2.SetAttribute("TRAN_TYPE", "J");
                            root1.AppendChild(HandleDetail2);
                            TSRNO++;
                        }
                    }
                }

                #endregion


                string str = PAY_REC_MLogicLayer.UpdatePAY_REC_MASDetail(insert, validation.RSC(XDoc1.OuterXml), null);

                if (str.Contains("successfully"))
                {

                    lblmsg.Text = "PAY JOURNAL VOUCHER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillJournal_Grid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "PAY JOURNAL VOUCHER  ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : PAY JOURNAL VOUCHER NOT SAVED";
                    lblmsg.ForeColor = Color.Red;

                }

                #endregion
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
            SqlCommand cmd = new SqlCommand("select * from ACCOUNTS where COMP_CODE=@COMP_CODE AND BRANCH_CODE=@BRANCH_CODE  AND ANAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            cmd.Parameters.AddWithValue("@BRANCH_CODE", branchCode);
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
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select ACODE from ACCOUNTS where ANAME = '" + TxtAccountName.Text + "'and COMP_CODE = " + Session["COMP_CODE"].ToString() , con);
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


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtNarration_TextChanged(object sender, EventArgs e)
        {
            try
            {



            }
            catch (Exception)
            {

                throw;
            }
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

                TxtVoucherDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");

                string Voucher_NO = PAY_REC_MLogicLayer.GetVoucherNumber_PAY_REC_MASCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtVoucherDate.Text.Trim()).ToString("yyyy-MM-dd"), "J");
                if (Voucher_NO.Length <= 8)
                {
                    TxtVoucherNo.Text = Voucher_NO;
                }
                else
                {
                    TxtVoucherNo.Text = string.Empty;
                }

            

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

     
        protected void TxtVoucherDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Voucher_NO = PAY_REC_MLogicLayer.GetVoucherNumber_PAY_REC_MASCompanyBranchYearWise(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtVoucherDate.Text.Trim()).ToString("yyyy-MM-dd"),"J");
                if (Voucher_NO.Length <= 8)
                {
                    TxtVoucherNo.Text = Voucher_NO;
                }
                else
                {
                    TxtVoucherNo.Text = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DdlConfirmFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlConfirmFlag.SelectedValue == "Y")
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


        protected void DdlApproveFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DdlApproveFlag.SelectedValue == "Y")
                {
                    TxtApproveBy.Text = Session["USERNAME"].ToString();
                    TxtApproveDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    TxtApproveBy.Text = "";
                    TxtApproveDate.Text = "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtAccountNameG_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfDebitACode = (HiddenField)row.Cells[0].FindControl("HfDebitACode");
                HiddenField HfCreditACode = (HiddenField)row.Cells[0].FindControl("HfCreditACode");
                TextBox TxtAccountNameG = (TextBox)row.Cells[1].FindControl("TxtAccountNameG");

                DataTable DtAccountName = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();


                DtAccountName = ACCOUNTS_MASLogicLayer.GetAllACCOUNTDetialsByComapnyAndBranch(Comp_Code, Session["BRANCH_CODE"].ToString());

                if(DdlSign.SelectedValue=="DR")
                {
                    DataView Dv = new DataView(DtAccountName);
                    Dv.RowFilter = "ANAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfCreditACode.Value = DtView.Rows[0]["ACODE"].ToString();
                        HfDebitACode.Value = HfACODE.Value.Trim();

                        //  FillOnGridChargesDetailChanged();
                    }
                    else
                    {
                        HfCreditACode.Value = null;
                        HfDebitACode.Value = null;
                    }
                }

                else if (DdlSign.SelectedValue == "CR")
                {
                    DataView Dv = new DataView(DtAccountName);
                    Dv.RowFilter = "ANAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfDebitACode.Value = DtView.Rows[0]["ACODE"].ToString();
                        HfCreditACode.Value = HfACODE.Value.Trim();

                        //  FillOnGridChargesDetailChanged();
                    }
                    else
                    {
                        HfCreditACode.Value = null;
                        HfDebitACode.Value = null;
                    }
                }



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
            table.Columns.Add("SR", typeof(string));
            table.Columns.Add("DRACODE", typeof(string));
            table.Columns.Add("CRACODE", typeof(string));
            table.Columns.Add("SIGN", typeof(string));
            table.Columns.Add("NARRN", typeof(string));
            table.Columns.Add("CHQ_NO", typeof(string));
            table.Columns.Add("CHQ_DT", typeof(string));
            table.Columns.Add("BANKDT", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("STATUS", typeof(string));
            table.Columns.Add("ENDT", typeof(string));
            table.Columns.Add("DR_PAID_AMT", typeof(string));
            table.Columns.Add("CR_PAID_AMT", typeof(string));
            table.Columns.Add("BILL_NO", typeof(string));
            table.Columns.Add("BILL_DATE", typeof(string));
            table.Columns.Add("BILL_AMT", typeof(string));
            table.Columns.Add("T_RATE", typeof(string));
            table.Columns.Add("T_AMT", typeof(string));
            table.Columns.Add("S_RATE", typeof(string));
            table.Columns.Add("S_AMT", typeof(string));
            table.Columns.Add("TOT_TDS", typeof(string));
            table.Columns.Add("TDSACODE", typeof(string));
            table.Columns.Add("TRAN_TYPE", typeof(string));
            table.Columns.Add("BANK_NARRN", typeof(string));
            table.Columns.Add("PARTY_BANK", typeof(string));
            table.Columns.Add("OA_AMT", typeof(string));
            table.Columns.Add("OA_FLAG", typeof(string));
            table.Columns.Add("PARTY_TYPE", typeof(string));


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SR"] = string.Empty;
            dr["DRACODE"] = string.Empty;
            dr["CRACODE"] = string.Empty;
            dr["SIGN"] = string.Empty;
            dr["NARRN"] = string.Empty;
            dr["CHQ_NO"] = string.Empty;
            dr["CHQ_DT"] = string.Empty;
            dr["BANKDT"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["STATUS"] = string.Empty;
            dr["ENDT"] = string.Empty;
            dr["DR_PAID_AMT"] = string.Empty;
            dr["CR_PAID_AMT"] = string.Empty;
            dr["BILL_NO"] = string.Empty;
            dr["BILL_DATE"] = string.Empty;
            dr["BILL_AMT"] = string.Empty;
            dr["T_RATE"] = string.Empty;
            dr["T_AMT"] = string.Empty;
            dr["S_RATE"] = string.Empty;
            dr["S_AMT"] = string.Empty;
            dr["TOT_TDS"] = string.Empty;
            dr["TDSACODE"] = string.Empty;
            dr["BANK_NARRN"] = string.Empty;
            dr["PARTY_BANK"] = string.Empty;
            dr["OA_AMT"] = string.Empty;
            dr["OA_FLAG"] = string.Empty;
            dr["PARTY_TYPE"] = string.Empty;


            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvJournalDetail.DataSource = table;
            GvJournalDetail.DataBind();
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


                        Label lblSumTotalAmount = (Label)(GvJournalDetail.FooterRow.FindControl("lblSumTotalAmount"));

                        HiddenField HfDebitACode = (HiddenField)GvJournalDetail.Rows[rowIndex].Cells[0].FindControl("HfDebitACode");
                        HiddenField HfCreditACode = (HiddenField)GvJournalDetail.Rows[rowIndex].Cells[0].FindControl("HfCreditACode");
                        TextBox TxtAccountNameG = (TextBox)GvJournalDetail.Rows[rowIndex].Cells[1].FindControl("TxtAccountNameG");
                        TextBox TxtNarration = (TextBox)GvJournalDetail.Rows[rowIndex].Cells[2].FindControl("TxtNarration");
                        TextBox TxtAmount = (TextBox)GvJournalDetail.Rows[rowIndex].Cells[3].FindControl("TxtAmount");
                        DropDownList DdlSign = (DropDownList)GvJournalDetail.Rows[rowIndex].Cells[4].FindControl("DdlSign");




                        dtCurrentTable.Rows[i - 1]["DRACODE"] = HfDebitACode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["CRACODE"] = HfCreditACode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["NARRN"] = TxtNarration.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = TxtAmount.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["SIGN"] = DdlSign.SelectedValue.Trim();


                        rowIndex++;

                        double lblTotAmount = TotalAmountGrid();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();



                    }

                    drCurrentRow = dtCurrentTable.NewRow();



                    //drCurrentRow["SRNO"] = "";
                    drCurrentRow["DRACODE"] = "0";
                    drCurrentRow["CRACODE"] = "0";
                    drCurrentRow["NARRN"] = string.Empty;
                    drCurrentRow["AMT"] = "0";
                    drCurrentRow["SIGN"] = string.Empty;


                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvJournalDetail.DataSource = dtCurrentTable;
                    GvJournalDetail.DataBind();


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
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Label lblSumTotalAmount = (Label)(GvJournalDetail.FooterRow.FindControl("lblSumTotalAmount"));

                        HiddenField HfDebitACode = (HiddenField)GvJournalDetail.Rows[rowIndex].Cells[0].FindControl("HfDebitACode");
                        HiddenField HfCreditACode = (HiddenField)GvJournalDetail.Rows[rowIndex].Cells[0].FindControl("HfCreditACode");
                        TextBox TxtAccountNameG = (TextBox)GvJournalDetail.Rows[rowIndex].Cells[1].FindControl("TxtAccountNameG");
                        TextBox TxtNarration = (TextBox)GvJournalDetail.Rows[rowIndex].Cells[2].FindControl("TxtNarration");
                        TextBox TxtAmount = (TextBox)GvJournalDetail.Rows[rowIndex].Cells[3].FindControl("TxtAmount");
                        DropDownList DdlSign = (DropDownList)GvJournalDetail.Rows[rowIndex].Cells[4].FindControl("DdlSign");


                        HfDebitACode.Value = dt.Rows[i]["DRACODE"].ToString();
                        HfCreditACode.Value = dt.Rows[i]["CRACODE"].ToString();
                        TxtNarration.Text = dt.Rows[i]["NARRN"].ToString();
                        TxtAmount.Text = dt.Rows[i]["AMT"].ToString();
                        DdlSign.SelectedValue = dt.Rows[i]["SIGN"].ToString();


                        rowIndex++;

                        double lblTotAmount = TotalAmountGrid();
                        lblSumTotalAmount.Text = lblTotAmount.ToString();
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
                GvJournalDetail.DataSource = dt;
                GvJournalDetail.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }


        public void FillAccountNameOnUpdate(string Id)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Brabch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTWiseComapnyAndBranchForInvoice(Comp_Code, Brabch_Code);


                if (HfACODE.Value.ToString() != "0" && HfACODE.Value != null && HfACODE.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "ACODE=" + Id;
                    DataTable DtView = Dv.ToTable();

                    TxtAccountName.Text = DtView.Rows[0]["ANAME"].ToString();
                    HfACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                }
                else
                {
                    TxtAccountName.Text = string.Empty;
                    HfACODE.Value = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvJournalMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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


                        DataSet ds = PAY_REC_MLogicLayer.GetAllIDWisePAY_REC_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtVoucherNo.Text = dt.Rows[0]["VOU_NO"].ToString();
                            TxtVoucherDate.Text = Convert.ToDateTime(dt.Rows[0]["VOU_DATE"].ToString()).ToString("dd-MM-yyyy");
                            HfACODE.Value = dt.Rows[0]["ACODE"].ToString();
                            FillAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            TxtNarration.Text = dt.Rows[0]["NARRN"].ToString();
                            TxtAmount.Text = dt.Rows[0]["AMT"].ToString();
                            DdlSign.SelectedValue = dt.Rows[0]["SIGN"].ToString();
                            DdlApproveFlag.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtApproveDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            TxtApproveBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();

                        }

                        Session["TRAN_NO"] = e.CommandArgument.ToString();
                        Session["TRAN_DATE"] = HfTranDateGrid.Value;
                        Session["TRAN_TYPE"] = HfTranType.Value;


                        if (DtDetails.Rows.Count > 0)
                            {
                                GvJournalDetail.DataSource = DtDetails;
                                GvJournalDetail.DataBind();
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

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = PAY_REC_MLogicLayer.GetAllIDWisePAY_REC_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtVoucherNo.Text = dt.Rows[0]["VOU_NO"].ToString();
                            TxtVoucherDate.Text = Convert.ToDateTime(dt.Rows[0]["VOU_DATE"].ToString()).ToString("dd-MM-yyyy");
                            HfACODE.Value = dt.Rows[0]["ACODE"].ToString();
                            FillAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            TxtNarration.Text = dt.Rows[0]["NARRN"].ToString();
                            TxtAmount.Text = dt.Rows[0]["AMT"].ToString();
                            DdlSign.SelectedValue = dt.Rows[0]["SIGN"].ToString();
                            DdlApproveFlag.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtApproveDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            TxtApproveBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                          }

                        Session["TRAN_NO"] = e.CommandArgument.ToString();
                        Session["TRAN_DATE"] = HfTranDateGrid.Value;
                        Session["TRAN_TYPE"] = HfTranType.Value;

                        if (DtDetails.Rows.Count > 0)
                            {
                                GvJournalDetail.DataSource = DtDetails;
                                GvJournalDetail.DataBind();

                                ViewState["CurrentTable"] = DtDetails;
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

                        HiddenField HfTranDateGrid = (row.FindControl("HfTranDateGrid")) as HiddenField;


                        DataSet ds = PAY_REC_MLogicLayer.GetAllIDWisePAY_REC_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtDetails = ds.Tables[1];

                        if (dt.Rows.Count > 0)
                        {

                            DivEntry.Visible = true;
                            DivView.Visible = false;

                            HfCompCode.Value = dt.Rows[0]["COMP_CODE"].ToString();
                            HfBranchCode.Value = dt.Rows[0]["BRANCH_CODE"].ToString();
                            HfTranDate.Value = dt.Rows[0]["TRAN_DATE"].ToString();
                            HfTranNo.Value = dt.Rows[0]["TRAN_NO"].ToString();
                            HfTranType.Value = dt.Rows[0]["TRAN_TYPE"].ToString();
                            TxtVoucherNo.Text = dt.Rows[0]["VOU_NO"].ToString();
                            TxtVoucherDate.Text = Convert.ToDateTime(dt.Rows[0]["VOU_DATE"].ToString()).ToString("dd-MM-yyyy");
                            HfACODE.Value = dt.Rows[0]["ACODE"].ToString();
                            FillAccountNameOnUpdate(dt.Rows[0]["ACODE"].ToString());
                            TxtNarration.Text = dt.Rows[0]["NARRN"].ToString();
                            TxtAmount.Text = dt.Rows[0]["AMT"].ToString();
                            DdlSign.SelectedValue = dt.Rows[0]["SIGN"].ToString();
                            DdlApproveFlag.SelectedValue = dt.Rows[0]["CHK_FLAG"].ToString();
                            TxtApproveDate.Text = dt.Rows[0]["CHK_DATE"].ToString();
                            TxtApproveBy.Text = dt.Rows[0]["CHK_USERID"].ToString();
                            DdlConfirmFlag.SelectedValue = dt.Rows[0]["CONF_FLAG"].ToString();
                            TxtConfirmDate.Text = dt.Rows[0]["CONF_DATE"].ToString();
                            TxtConfirmBy.Text = dt.Rows[0]["CONF_USERID"].ToString();
                        }

                        Session["TRAN_NO"] = e.CommandArgument.ToString();
                        Session["TRAN_DATE"] = HfTranDateGrid.Value;
                        Session["TRAN_TYPE"] = HfTranType.Value;


                        if (DtDetails.Rows.Count > 0)
                        {
                            GvJournalDetail.DataSource = DtDetails;
                            GvJournalDetail.DataBind();
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
            catch (Exception)
            {

                throw;
            }
        }

     

        protected void GvJournalDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    HiddenField HfDebitACode = (e.Row.FindControl("HfDebitACode") as HiddenField);
                    HiddenField HfCreditACode = (e.Row.FindControl("HfCreditACode") as HiddenField);
                    TextBox TxtAccountNameG = (e.Row.FindControl("TxtAccountNameG") as TextBox);

                    DataTable DtAccountName = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();


                    DtAccountName = ACCOUNTS_MASLogicLayer.GetAllACCOUNTDetialsByComapnyAndBranch(Comp_Code, Session["BRANCH_CODE"].ToString());

                    if (DdlSign.SelectedValue == "DR")
                    {
                        if (HfCreditACode.Value != string.Empty && HfCreditACode.Value != null)
                        {

                            DataView Dv = new DataView(DtAccountName);
                            Dv.RowFilter = "ACODE='" + HfCreditACode.Value.Trim() + "'";
                            DataTable DtView = Dv.ToTable();
                            if (DtView.Rows.Count > 0)
                            {
                                HfCreditACode.Value = DtView.Rows[0]["ACODE"].ToString();
                                TxtAccountNameG.Text = DtView.Rows[0]["ANAME"].ToString();

                                //  FillOnGridChargesDetailChanged();
                            }
                        }
                        else
                        {
                            HfCreditACode.Value = null;
                        }
                    }

                    else if (DdlSign.SelectedValue == "CR")
                    {
                        if (HfDebitACode.Value != string.Empty && HfDebitACode.Value != null)
                        {

                            DataView Dv = new DataView(DtAccountName);
                            Dv.RowFilter = "ACODE='" + HfDebitACode.Value.Trim() + "'";
                            DataTable DtView = Dv.ToTable();
                            if (DtView.Rows.Count > 0)
                            {
                                HfDebitACode.Value = DtView.Rows[0]["ACODE"].ToString();
                                TxtAccountNameG.Text = DtView.Rows[0]["ANAME"].ToString();
                                //  FillOnGridChargesDetailChanged();
                            }
                        }
                        else
                        {
                            HfCreditACode.Value = null;
                            HfDebitACode.Value = null;
                        }
                    }
                }


                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblSumTotalAmount = (Label)e.Row.FindControl("lblSumTotalAmount");

                    double lblTotAmount = TotalAmountGrid();
                    lblSumTotalAmount.Text = lblTotAmount.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                Label lblSumTotalAmount = (Label)(GvJournalDetail.FooterRow.FindControl("lblSumTotalAmount"));

                double lblTotAmount = TotalAmountGrid();
                lblSumTotalAmount.Text = lblTotAmount.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

       
        protected void DdlSign_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {


                foreach (GridViewRow row in GvJournalDetail.Rows)
                {
                    //  string DdlSignGrid = ((DropDownList)row.FindControl("DdlSign")).Text;
                    DropDownList DdlSignGrid = (DropDownList)row.FindControl("DdlSign");

                    if (DdlSign.SelectedValue.ToString() == "DR")
                    {
                        DdlSignGrid.SelectedValue = "CR";
                    }
                    else if (DdlSign.SelectedValue.ToString() == "CR")
                    {
                        DdlSignGrid.SelectedValue = "DR";
                    }
                    else
                    {

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnprintFullJournalVoucher_Click(object sender, EventArgs e)
        {
            Session["PAGE_HEIGHT_JV"] = "A4";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewJournalVoucherPrint.aspx', '_blank');", true);
        }

        protected void btnprintHalfJournalVoucher_Click(object sender, EventArgs e)
        {
            Session["PAGE_HEIGHT_JV"] = "A5";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../ViewerAccount/ViewJournalVoucherPrint.aspx', '_blank');", true);
        }
    }
}