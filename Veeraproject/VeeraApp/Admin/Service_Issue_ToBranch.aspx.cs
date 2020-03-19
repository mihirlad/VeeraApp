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

namespace VeeraApp.Admin
{
    public partial class Service_Issue__ToBranch : System.Web.UI.Page
    {

        public static string compcode;
        public static string Branchcode;
        public static string ToBranchcode;
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
                Branchcode = Session["BRANCH_CODE"].ToString();



                if (!IsPostBack == true)
                {
                  //  this.Form.Target = "_blank";
                    DivEntry.Visible = false;
                    DivView.Visible = true;
                    SetInitialRow();
                    SetInitialRow_ChargesGrid();

                    string ACODE = Request.QueryString["ACODE"];
                    string COMP_CODE = Request.QueryString["COMP_CODE"];

                    CalendarExtenderServiceDate.StartDate = Convert.ToDateTime(Session["FIN_YEAR"].ToString());
                    CalendarExtenderServiceDate.EndDate = Convert.ToDateTime(Session["FIN_YEAR_END"].ToString());

                    if (!string.IsNullOrWhiteSpace(Request.QueryString["Service_type"]))
                    {
                        HfBranchIssueToServiceType.Value = Request.QueryString["Service_type"];
                    }

                    FillSERVICE_ISSUE_TOBRANCH_MasterGrid(Session["COMP_CODE"].ToString());

                    if (HfBranchIssueToServiceType.Value == "T")
                    {

                        PageTiltle1.Visible = true;
                        PageTiltle2.Visible = false;
                        BtnAdd.Enabled = true;
                    }

                    else if (HfBranchIssueToServiceType.Value == "F")
                    {

                        PageTiltle1.Visible = false;
                        PageTiltle2.Visible = true;
                        BtnAdd.Enabled = false;

                    }
                    else
                    { }



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

        private double TotalChargesAmount()
        {
            double GTotal = 0;
            for (int i = 0; i < GvChagresTranDetails.Rows.Count; i++)
            {
                string total = (GvChagresTranDetails.Rows[i].FindControl("TxtChargesAmount") as TextBox).Text;
                if (total == string.Empty)
                {
                    total = "0";
                }
                GTotal += Convert.ToDouble(total);
            }
            return GTotal;

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

        public void FillVisitServicePerson1(string ServicePerson)
        {
            try
            {
                if (HfBranchIssueToServiceType.Value == "T")
                {



                    string Comp_Code = HfCompCode.Value.Trim();
                    string Branch_Code = HfBranchCode.Value.Trim();

                    DataTable Dt = new DataTable();
                    Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                    if (HfServicePerson1.Value.ToString() != "0" && HfServicePerson1.Value.ToString() != null && HfServicePerson1.Value.ToString() != string.Empty)
                    {
                        DataView Dv = new DataView(Dt);
                        Dv.RowFilter = "BCODE=" + ServicePerson;
                        DataTable DtView = Dv.ToTable();

                        TxtServicePersonName1.Text = DtView.Rows[0]["BNAME"].ToString();
                        HfServicePerson1.Value = DtView.Rows[0]["BCODE"].ToString();

                    }
                    else
                    {
                        TxtServicePersonName1.Text = string.Empty;

                    }
                }
                else if(HfBranchIssueToServiceType.Value == "F")
                {

                    string Comp_Code = HfCompCode.Value.Trim();
                    string Branch_Code = HfBranchCode.Value.Trim();

                    DataTable Dt = new DataTable();
                    Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                    if (HfServicePerson1.Value.ToString() != "0" && HfServicePerson1.Value.ToString() != null && HfServicePerson1.Value.ToString() != string.Empty)
                    {
                        DataView Dv = new DataView(Dt);
                        Dv.RowFilter = "BCODE=" + ServicePerson;
                        DataTable DtView = Dv.ToTable();

                        TxtServicePersonName1.Text = DtView.Rows[0]["BNAME"].ToString();
                        HfServicePerson1.Value = DtView.Rows[0]["BCODE"].ToString();

                    }
                    else
                    {
                        TxtServicePersonName1.Text = string.Empty;

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillVisitServicePerson2(string ServicePerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfServicePerson2.Value.ToString() != "0" && HfServicePerson2.Value.ToString() != null && HfServicePerson2.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ServicePerson;
                    DataTable DtView = Dv.ToTable();

                    TxtServicePersonName2.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfServicePerson2.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtServicePersonName2.Text = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillVisitServicePerson3(string ServicePerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfServicePerson3.Value.ToString() != "0" && HfServicePerson3.Value.ToString() != null && HfServicePerson3.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ServicePerson;
                    DataTable DtView = Dv.ToTable();

                    TxtServicePersonName3.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfServicePerson3.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtServicePersonName3.Text = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillVisitServicePerson4(string ServicePerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfServicePerson4.Value.ToString() != "0" && HfServicePerson4.Value.ToString() != null && HfServicePerson4.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ServicePerson;
                    DataTable DtView = Dv.ToTable();

                    TxtServicePersonName4.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfServicePerson4.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtServicePersonName4.Text = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillVisitServicePerson5(string ServicePerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfServicePerson5.Value.ToString() != "0" && HfServicePerson5.Value.ToString() != null && HfServicePerson5.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ServicePerson;
                    DataTable DtView = Dv.ToTable();

                    TxtServicePersonName5.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfServicePerson5.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtServicePersonName5.Text = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillVisitDeliveredPersonBy(string ServicePerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfDeliveredPersonBy.Value.ToString() != "0" && HfDeliveredPersonBy.Value.ToString() != null && HfDeliveredPersonBy.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ServicePerson;
                    DataTable DtView = Dv.ToTable();

                    TxtDeliveredPersonName.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfDeliveredPersonBy.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtDeliveredPersonName.Text = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FillVisitCheckedPersonBy(string ServicePerson)
        {
            try
            {
                string Comp_Code = HfCompCode.Value.Trim();
                string Branch_Code = HfBranchCode.Value.Trim();

                DataTable Dt = new DataTable();
                Dt = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Comp_Code, Branch_Code);


                if (HfCheckedByPerson.Value.ToString() != "0" && HfCheckedByPerson.Value.ToString() != null && HfCheckedByPerson.Value.ToString() != string.Empty)
                {
                    DataView Dv = new DataView(Dt);
                    Dv.RowFilter = "BCODE=" + ServicePerson;
                    DataTable DtView = Dv.ToTable();

                    TxtCheckedBy.Text = DtView.Rows[0]["BNAME"].ToString();
                    HfCheckedByPerson.Value = DtView.Rows[0]["BCODE"].ToString();

                }
                else
                {
                    TxtCheckedBy.Text = string.Empty;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void clear()
        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            TxtSrNo.Text = string.Empty;
            TxtServiceDate.Text = string.Empty;
            TxtFromBranch.Text = string.Empty;
            TxtToBranch.Text = string.Empty;
            TxtVisitStartTime.Text = string.Empty;
            TxtVisitCloseTime.Text = string.Empty;
            TxtServicePersonName1.Text = string.Empty;
            TxtServicePersonName2.Text = string.Empty;
            TxtServicePersonName3.Text = string.Empty;
            TxtServicePersonName4.Text = string.Empty;
            TxtServicePersonName5.Text = string.Empty;
            TxtDeliveredPersonName.Text = string.Empty;
            TxtJobStartTime.Text = string.Empty;
            TxtJobCloseTime.Text = string.Empty;
            TxtCheckedBy.Text = string.Empty;
            TxtTotalChargesAmt.Text = string.Empty;
            DdlReceivedFlag.SelectedValue = "N";
            TxtReceivedBy.Text = string.Empty;
            TxtReceivedDate.Text = string.Empty;

            SetInitialRow();
            SetInitialRow_ChargesGrid();
            BtncallUpd.Text = "SAVE";
        }


        public void ControllerEnable()
        {
            TxtSrNo.Enabled = false;
            TxtServiceDate.Enabled = true;
            TxtFromBranch.Enabled = false;
            TxtToBranch.Enabled = true;
            TxtVisitStartTime.Enabled = true;
            TxtVisitCloseTime.Enabled = true;
            TxtServicePersonName1.Enabled = true;
            TxtServicePersonName2.Enabled = true;
            TxtServicePersonName3.Enabled = true;
            TxtServicePersonName4.Enabled = true;
            TxtServicePersonName5.Enabled = true;
            TxtDeliveredPersonName.Enabled = true;
            TxtJobStartTime.Enabled = true;
            TxtJobCloseTime.Enabled = true;
            TxtCheckedBy.Enabled = true;
            TxtTotalChargesAmt.Enabled = true;

            if (HfBranchIssueToServiceType.Value == "T")
            {
                DdlReceivedFlag.Enabled = false;
                TxtReceivedBy.Enabled = false;
                TxtReceivedDate.Enabled = false;
            }
            else if (HfBranchIssueToServiceType.Value == "F")
            {
                DdlReceivedFlag.Enabled = true;
                TxtReceivedBy.Enabled = true;
                TxtReceivedDate.Enabled = true;
                TxtSrNo.Enabled = false;
                TxtServiceDate.Enabled = false;
                TxtFromBranch.Enabled = false;
                TxtToBranch.Enabled = false;
                TxtVisitStartTime.Enabled = false;
                TxtVisitCloseTime.Enabled = false;
                TxtServicePersonName1.Enabled = false;
                TxtServicePersonName2.Enabled = false;
                TxtServicePersonName3.Enabled = false;
                TxtServicePersonName4.Enabled = false;
                TxtServicePersonName5.Enabled = false;
                TxtDeliveredPersonName.Enabled = false;
                TxtJobStartTime.Enabled = false;
                TxtJobCloseTime.Enabled = false;
                TxtCheckedBy.Enabled = false;
                TxtTotalChargesAmt.Enabled = false;
            }


        }


        public void ControllerDisable()
        {
            TxtSrNo.Enabled = false;
            TxtServiceDate.Enabled = false;
            TxtFromBranch.Enabled = false;
            TxtToBranch.Enabled = false;
            TxtVisitStartTime.Enabled = false;
            TxtVisitCloseTime.Enabled = false;
            TxtServicePersonName1.Enabled = false;
            TxtServicePersonName2.Enabled = false;
            TxtServicePersonName3.Enabled = false;
            TxtServicePersonName4.Enabled = false;
            TxtServicePersonName5.Enabled = false;
            TxtDeliveredPersonName.Enabled = false;
            TxtJobStartTime.Enabled = false;
            TxtJobCloseTime.Enabled = false;
            TxtCheckedBy.Enabled = false;
            TxtTotalChargesAmt.Enabled = false;
            DdlReceivedFlag.Enabled = false;
            TxtReceivedBy.Enabled = false;
            TxtReceivedDate.Enabled = false;

            GvBranchPartyTranDetails.Enabled = false;
            GvChagresTranDetails.Enabled = false;
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
                TxtFromBranch.Enabled = false;
                TxtServiceDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                GvBranchPartyTranDetails.Enabled = true;
                GvChagresTranDetails.Enabled = true;

                if (HfBranchIssueToServiceType.Value == "T")
                {


                    DdlReceivedFlag.Enabled = false;
                    TxtReceivedBy.Enabled = false;
                    TxtReceivedDate.Enabled = false;
                    GvChagresTranDetails.Enabled = true;
                }

                else if (HfBranchIssueToServiceType.Value == "F")
                {

                    DdlReceivedFlag.Enabled = true;
                    TxtReceivedBy.Enabled = true;
                    TxtReceivedDate.Enabled = true;
                    GvChagresTranDetails.Enabled = false;

                }
                else
                { }

                string Service_SRNO = BRANCH_TRANMASLogicLayer.GetSerialNumberForServiceIssueToBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtServiceDate.Text.Trim()).ToString("yyyy-MM-dd"));
                if (Service_SRNO.Length <= 8)
                {
                    TxtSrNo.Text = Service_SRNO;
                    TxtSrNo.Enabled = false;
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

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Dashboard.aspx");
        }

        protected void TxtServiceDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Service_SRNO = BRANCH_TRANMASLogicLayer.GetSerialNumberForServiceIssueToBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(TxtServiceDate.Text.Trim()).ToString("yyyy-MM-dd"));
                if (Service_SRNO.Length <= 8)
                {
                    TxtSrNo.Text = Service_SRNO;
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

        protected void TxtChargesAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {

                Label lblISumChargesTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblISumChargesTotalAmount"));


                double lblTotalAmount = TotalChargesAmount();
                lblISumChargesTotalAmount.Text = lblTotalAmount.ToString();

                TxtTotalChargesAmt.Text = lblISumChargesTotalAmount.Text;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public void FillSERVICE_ISSUE_TOBRANCH_MasterGrid(string CompCode)
        {

            DataTable Dt = new DataTable();

            Dt = BRANCH_TRANMASLogicLayer.GetAllSERVICE_ISSUE_BRANCH_MASDetails(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()), Convert.ToInt32(Session["BRANCH_CODE"].ToString()), HfBranchIssueToServiceType.Value.ToString());
            DataView Dv = new DataView(Dt);
            if (CompCode != string.Empty)
            {
                Dv.RowFilter = "COMP_CODE=" + Session["COMP_CODE"].ToString();
            }
            GvServiceIssueBranchMaster.DataSource = Dv.ToTable();
            GvServiceIssueBranchMaster.DataBind();

            DtSearch = Dv.ToTable();

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


        protected void TxtToBranch_TextChanged(object sender, EventArgs e)
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
                ToBranchcode = HfToBranchCode.Value;

            }
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetServicePersonName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from BROKER where COMP_CODE=@COMP_CODE and BRANCH_CODE=@BRANCH_CODE and BNAME like @BNAME + '%'", con);
            cmd.Parameters.AddWithValue("@BNAME", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            cmd.Parameters.AddWithValue("@BRANCH_CODE", Branchcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> BrokerName = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BrokerName.Add(dt.Rows[i][3].ToString());
            }
            return BrokerName;
        }



        protected void TxtServicePersonName1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtServicePersonName1.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtServicePersonName1.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfServicePerson1.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtServicePersonName2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtServicePersonName2.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtServicePersonName2.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfServicePerson2.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtServicePersonName3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtServicePersonName3.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtServicePersonName3.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfServicePerson3.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtServicePersonName4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtServicePersonName4.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtServicePersonName4.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfServicePerson4.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtServicePersonName5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtServicePersonName5.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtServicePersonName5.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfServicePerson5.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void TxtCheckedBy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtCheckedBy.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtCheckedBy.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfCheckedByPerson.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void TxtDeliveredPersonName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DtBrokerName = new DataTable();

                DtBrokerName = BROKER_MASLogicLayer.GetAllBROKERDetialsWiseComapnyAndBranch(Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString());
                if (TxtDeliveredPersonName.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtBrokerName);
                    Dv.RowFilter = "BNAME='" + TxtDeliveredPersonName.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfDeliveredPersonBy.Value = DtView.Rows[0]["BCODE"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Party Details Grid

        private void SetInitialRow()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("ACODE", typeof(string));
            table.Columns.Add("CONTACT_PERSON", typeof(string));
            table.Columns.Add("CONTACT_PHONE", typeof(string));
            table.Columns.Add("COMPANY_REMARK", typeof(string));
            table.Columns.Add("JOBSTART_TIME", typeof(string));
            table.Columns.Add("JOBCLOSE_TIME", typeof(string));
            table.Columns.Add("TOT_TIME", typeof(string));
            table.Columns.Add("JOB_COMPFLAG", typeof(string));
            table.Columns.Add("OWN_REMARK", typeof(string));
            table.Columns.Add("INS_USERID", typeof(string));
            table.Columns.Add("INS_TERMINAL", typeof(string));
            table.Columns.Add("INS_DATE", typeof(string));
            table.Columns.Add("UPD_USERID", typeof(string));
            table.Columns.Add("UPD_DATE", typeof(string));
            table.Columns.Add("UPD_TERMINAL", typeof(string));


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["ACODE"] = string.Empty;
            dr["CONTACT_PERSON"] = string.Empty;
            dr["CONTACT_PHONE"] = string.Empty;
            dr["COMPANY_REMARK"] = string.Empty;
            dr["JOBSTART_TIME"] = string.Empty;
            dr["JOBCLOSE_TIME"] = string.Empty;
            dr["TOT_TIME"] = string.Empty;
            dr["JOB_COMPFLAG"] = "N";
            dr["OWN_REMARK"] = string.Empty;
            dr["INS_USERID"] = string.Empty;
            dr["INS_TERMINAL"] = string.Empty;
            dr["INS_DATE"] = string.Empty;
            dr["UPD_USERID"] = string.Empty;
            dr["UPD_DATE"] = string.Empty;
            dr["UPD_TERMINAL"] = string.Empty;



            table.Rows.Add(dr);

            ViewState["CurrentTable"] = table;

            GvBranchPartyTranDetails.DataSource = table;
            GvBranchPartyTranDetails.DataBind();

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


                        HiddenField HfACODE = (HiddenField)GvBranchPartyTranDetails.Rows[rowIndex].Cells[0].FindControl("HfACODE");
                        HiddenField HfTotalTime = (HiddenField)GvBranchPartyTranDetails.Rows[rowIndex].Cells[0].FindControl("HfTotalTime");
                        HiddenField HfJobCompletedFlag = (HiddenField)GvBranchPartyTranDetails.Rows[rowIndex].Cells[0].FindControl("HfJobCompletedFlag");

                        TextBox TxtPartyName = (TextBox)GvBranchPartyTranDetails.Rows[rowIndex].Cells[1].FindControl("TxtPartyName");
                        TextBox TxtContactPerson = (TextBox)GvBranchPartyTranDetails.Rows[rowIndex].Cells[2].FindControl("TxtContactPerson");
                        TextBox TxtContactPhone = (TextBox)GvBranchPartyTranDetails.Rows[rowIndex].Cells[3].FindControl("TxtContactPhone");
                        TextBox TxtCompanyRemark = (TextBox)GvBranchPartyTranDetails.Rows[rowIndex].Cells[4].FindControl("TxtCompanyRemark");
                        TextBox TxtJobStartTime = (TextBox)GvBranchPartyTranDetails.Rows[rowIndex].Cells[5].FindControl("TxtJobStartTime");
                        TextBox TxtJobCloseTime = (TextBox)GvBranchPartyTranDetails.Rows[rowIndex].Cells[6].FindControl("TxtJobCloseTime");
                        TextBox TxtTotalTime = (TextBox)GvBranchPartyTranDetails.Rows[rowIndex].Cells[7].FindControl("TxtTotalTime");
                        DropDownList DdlCompletedStaus = (DropDownList)GvBranchPartyTranDetails.Rows[rowIndex].Cells[8].FindControl("DdlCompletedStaus");
                        TextBox TxtOwnRemark = (TextBox)GvBranchPartyTranDetails.Rows[rowIndex].Cells[9].FindControl("TxtOwnRemark");


                        //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();


                        dtCurrentTable.Rows[i - 1]["ACODE"] = HfACODE.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["CONTACT_PERSON"] = TxtContactPerson.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["CONTACT_PHONE"] = TxtContactPhone.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["COMPANY_REMARK"] = TxtCompanyRemark.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["JOBSTART_TIME"] = TxtJobStartTime.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["JOBCLOSE_TIME"] = TxtJobCloseTime.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["TOT_TIME"] = HfTotalTime.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["JOB_COMPFLAG"] = HfJobCompletedFlag.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["OWN_REMARK"] = TxtOwnRemark.Text.Trim();


                        rowIndex++;


                    }

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["ACODE"] = "0";
                    drCurrentRow["CONTACT_PERSON"] = "";
                    drCurrentRow["CONTACT_PHONE"] = "";
                    drCurrentRow["COMPANY_REMARK"] = "";
                    drCurrentRow["JOBSTART_TIME"] = "";
                    drCurrentRow["JOBCLOSE_TIME"] = "";
                    drCurrentRow["TOT_TIME"] = "";
                    drCurrentRow["JOB_COMPFLAG"] = "";
                    drCurrentRow["OWN_REMARK"] = "";


                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    GvBranchPartyTranDetails.DataSource = dtCurrentTable;
                    GvBranchPartyTranDetails.DataBind();


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


                        HiddenField HfACODE = (HiddenField)GvBranchPartyTranDetails.Rows[rowIndex].Cells[0].FindControl("HfACODE");
                        HiddenField HfTotalTime = (HiddenField)GvBranchPartyTranDetails.Rows[rowIndex].Cells[0].FindControl("HfTotalTime");
                        HiddenField HfJobCompletedFlag = (HiddenField)GvBranchPartyTranDetails.Rows[rowIndex].Cells[0].FindControl("HfJobCompletedFlag");

                        TextBox TxtPartyName = (TextBox)GvBranchPartyTranDetails.Rows[rowIndex].Cells[1].FindControl("TxtPartyName");
                        TextBox TxtContactPerson = (TextBox)GvBranchPartyTranDetails.Rows[rowIndex].Cells[2].FindControl("TxtContactPerson");
                        TextBox TxtContactPhone = (TextBox)GvBranchPartyTranDetails.Rows[rowIndex].Cells[3].FindControl("TxtContactPhone");
                        TextBox TxtCompanyRemark = (TextBox)GvBranchPartyTranDetails.Rows[rowIndex].Cells[4].FindControl("TxtCompanyRemark");
                        TextBox TxtJobStartTime = (TextBox)GvBranchPartyTranDetails.Rows[rowIndex].Cells[5].FindControl("TxtJobStartTime");
                        TextBox TxtJobCloseTime = (TextBox)GvBranchPartyTranDetails.Rows[rowIndex].Cells[6].FindControl("TxtJobCloseTime");
                        TextBox TxtTotalTime = (TextBox)GvBranchPartyTranDetails.Rows[rowIndex].Cells[7].FindControl("TxtTotalTime");
                        DropDownList DdlCompletedStaus = (DropDownList)GvBranchPartyTranDetails.Rows[rowIndex].Cells[8].FindControl("DdlCompletedStaus");
                        TextBox TxtOwnRemark = (TextBox)GvBranchPartyTranDetails.Rows[rowIndex].Cells[9].FindControl("TxtOwnRemark");



                        //TxtSrNo.Text = dt.Rows[i]["SRNO"].ToString();
                        HfACODE.Value = dt.Rows[i]["ACODE"].ToString();
                        TxtContactPerson.Text = dt.Rows[i]["CONTACT_PERSON"].ToString();
                        TxtContactPhone.Text = dt.Rows[i]["CONTACT_PHONE"].ToString();
                        TxtCompanyRemark.Text = dt.Rows[i]["COMPANY_REMARK"].ToString();
                        TxtJobStartTime.Text = dt.Rows[i]["JOBSTART_TIME"].ToString();
                        TxtJobCloseTime.Text = dt.Rows[i]["JOBCLOSE_TIME"].ToString();
                        HfTotalTime.Value = dt.Rows[i]["TOT_TIME"].ToString();
                        HfJobCompletedFlag.Value = dt.Rows[i]["JOB_COMPFLAG"].ToString();
                        TxtOwnRemark.Text = dt.Rows[i]["OWN_REMARK"].ToString();


                        rowIndex++;


                    }
                }
            }
        }


        protected void BtnDeleteRowModelPartyDetailGrid_Click(object sender, EventArgs e)
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
                GvBranchPartyTranDetails.DataSource = dt;
                GvBranchPartyTranDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }

        protected void BtnAddRowModelPartyDetailGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        #endregion


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetAccountName(string prefixText)
        {

            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from ACCOUNTS where COMP_CODE=@COMP_CODE AND BRANCH_CODE=@BRANCH_CODE AND ANAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            cmd.Parameters.AddWithValue("@BRANCH_CODE", Branchcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> ANames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ANames.Add(dt.Rows[i][2].ToString());
            }
            return ANames;
        }

        protected void TxtPartyName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfACODE = (HiddenField)row.Cells[0].FindControl("HfACODE");

                TextBox TxtContactPerson = (TextBox)row.Cells[2].FindControl("TxtContactPerson");
                TextBox TxtContactPhone = (TextBox)row.Cells[3].FindControl("TxtContactPhone");

                DataTable DtPartyName = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();
                string Branch_Code = ToBranchcode;

                DtPartyName = ACCOUNTS_MASLogicLayer.GetAllACCOUNTDetialsByComapnyAndBranch(Comp_Code, Branch_Code);
                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtPartyName);
                    Dv.RowFilter = "ANAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {

                        HfACODE.Value = DtView.Rows[0]["ACODE"].ToString();
                        TxtContactPerson.Text = DtView.Rows[0]["CONTACT_NAME"].ToString();
                        TxtContactPhone.Text = DtView.Rows[0]["PHONE_NO"].ToString();

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvBranchPartyTranDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    TextBox TxtPartyName = (e.Row.FindControl("TxtPartyName") as TextBox);
                    HiddenField HfACODE = (e.Row.FindControl("HfACODE") as HiddenField);
                    TextBox TxtTotalTime = (e.Row.FindControl("TxtTotalTime") as TextBox);
                    HiddenField HfTotalTime = (e.Row.FindControl("HfTotalTime") as HiddenField);

                    DropDownList DdlCompletedStaus = (e.Row.FindControl("DdlCompletedStaus") as DropDownList);
                    HiddenField HfJobCompletedFlag = (e.Row.FindControl("HfJobCompletedFlag") as HiddenField);




                    string Comp_Code = Session["COMP_CODE"].ToString();

                    DataTable Dt = new DataTable();
                    Dt = ACCOUNTS_MASLogicLayer.GetAllACCOUNTS_MASDetialsWIiseCompanyFor_DDL(Comp_Code);

                    if (HfACODE.Value != "0" && HfACODE.Value != string.Empty)
                    {
                        DataView Dv = new DataView(Dt);
                        Dv.RowFilter = "ACODE=" + HfACODE.Value;
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            TxtPartyName.Text = DtView.Rows[0]["ANAME"].ToString();
                        }
                        else
                        {
                            TxtPartyName.Text = string.Empty;

                        }

                    }



                    if (HfTotalTime.Value.Trim() != string.Empty)
                    {

                        Int32 totalMinute = Decimal.ToInt32(Convert.ToDecimal(HfTotalTime.Value));
                        Int32 Minute = default(Int32);
                        Int32 Hour = default(Int32);
                        {
                            //txtBxTotal.Text = totalMinute.ToString();
                            totalMinute = totalMinute % 1440;

                            Hour = totalMinute / 60;
                            Minute = totalMinute % 60;
                            TxtTotalTime.Text = FormatTwoDigits(Hour) + ":" + FormatTwoDigits(Minute) + " ";
                        }

                    }


                    
                    DdlCompletedStaus.SelectedValue = HfJobCompletedFlag.Value;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string FormatTwoDigits(Int32 i)
        {
            string functionReturnValue = null;
            if (10 > i)
            {
                functionReturnValue = "0" + i.ToString();
            }
            else
            {
                functionReturnValue = i.ToString();
            }
            return functionReturnValue;
        }


        #region ENCRYPT FUNTION QUERYSTRING VALUE

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

        #endregion

        protected void GvBranchPartyTranDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "ViewContactDetails")
                {
                    int id;
                    //     clear();
                    if (e.CommandArgument.ToString() != string.Empty)
                    {
                        id = int.Parse(e.CommandArgument.ToString());
                    }
                    Control ctrl = e.CommandSource as Control;
                    if (ctrl != null)
                    {
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;

                        TextBox TxtPartyName = (row.FindControl("TxtPartyName")) as TextBox;
                        HiddenField HfACODE = (row.FindControl("HfACODE")) as HiddenField;


                        if (HfACODE.Value == string.Empty)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Must be select Party Name..!!');", true);

                        }
                        else
                        {
                            string COMP_CODE = HttpUtility.UrlEncode(encrypt(Session["COMP_CODE"].ToString()));
                            string ACODE = HttpUtility.UrlEncode(encrypt(HfACODE.Value.ToString()));

                            if (btnSave.Visible == true)
                            {
                                // string url = String.Format("PartyContactDetails.aspx?ACODE={0}&COMP_CODE={1}", ACODE, COMP_CODE);

                                //Build your client-side script that will open your target in a new page
                                // string script = String.Format("window.open('{0}','_blank');", url);  

                                //Combine these two together so that when your page is loaded it will open your target URL in a new window
                               // ClientScript.RegisterStartupScript(GetType(), "YourStartupScript", script, true);

                               // Response.Redirect("~/Admin/Dashboard.aspx");
                                //ClientScript.RegisterStartupScript(this.GetType(), "scr", "window.open(PartyContactDetails.aspx?ACODE=" + ACODE + "&COMP_CODE=" + COMP_CODE + ", _blank)", true);
                                Response.Write("<script>window.open ('PartyContactDetails.aspx?ACODE=" + ACODE + "&COMP_CODE=" + COMP_CODE + "', '_blank');</script>");
                               // Response.Redirect("PartyContactDetails.aspx?ACODE=" + ACODE + "&COMP_CODE=" + COMP_CODE);
                              //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('PartyContactDetails.aspx?ACODE=" + ACODE + "&COMP_CODE=" + COMP_CODE + ", '_blank');", true);
                                }
                            else
                            {
                                Response.Write("<script>window.open ('PartyContactDetails.aspx?ACODE=" + ACODE + "&COMP_CODE=" + COMP_CODE + "&Flag=1', '_blank');</script>");
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

        protected void GvBranchPartyTranDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }


        #region ADD NEW ROW IN BRANCH CHARGES GRID

        private void SetInitialRow_ChargesGrid()
        {
            DataTable table = new DataTable();
            DataRow dr = null;
            table.Columns.Add("COMP_CODE", typeof(string));
            table.Columns.Add("TRAN_DATE", typeof(string));
            table.Columns.Add("TRAN_NO", typeof(string));
            table.Columns.Add("SRNO", typeof(string));
            table.Columns.Add("CCODE", typeof(string));
            table.Columns.Add("CHARGES_DESC", typeof(string));
            table.Columns.Add("AMT", typeof(string));
            table.Columns.Add("INS_USERID", typeof(string));
            table.Columns.Add("INS_TERMINAL", typeof(string));
            table.Columns.Add("INS_DATE", typeof(string));
            table.Columns.Add("UPD_USERID", typeof(string));
            table.Columns.Add("UPD_DATE", typeof(string));
            table.Columns.Add("UPD_TERMINAL", typeof(string));


            dr = table.NewRow();
            dr["COMP_CODE"] = string.Empty;
            dr["TRAN_DATE"] = string.Empty;
            dr["TRAN_NO"] = string.Empty;
            dr["SRNO"] = string.Empty;
            dr["CCODE"] = string.Empty;
            dr["CHARGES_DESC"] = string.Empty;
            dr["AMT"] = string.Empty;
            dr["INS_USERID"] = string.Empty;
            dr["INS_TERMINAL"] = string.Empty;
            dr["INS_DATE"] = string.Empty;
            dr["UPD_USERID"] = string.Empty;
            dr["UPD_DATE"] = string.Empty;
            dr["UPD_TERMINAL"] = string.Empty;



            table.Rows.Add(dr);

            ViewState["CurrentTable_C"] = table;

            GvChagresTranDetails.DataSource = table;
            GvChagresTranDetails.DataBind();

        }



        private void AddNewRowToGrid_ChargesGrid()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable_C"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable_C"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values 

                        Label lblISumChargesTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblISumChargesTotalAmount"));

                        HiddenField HfChargesCode = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfChargesCode");

                        TextBox TxtChargesName = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[1].FindControl("TxtChargesName");
                        TextBox TxtChargesDesription = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[2].FindControl("TxtChargesDesription");
                        TextBox TxtChargesAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[3].FindControl("TxtChargesAmount");



                        //dtCurrentTable.Rows[i - 1]["SRNO"] = TxtSrNo.Text.Trim();


                        dtCurrentTable.Rows[i - 1]["CCODE"] = HfChargesCode.Value.Trim();
                        dtCurrentTable.Rows[i - 1]["CHARGES_DESC"] = TxtChargesDesription.Text.Trim();
                        dtCurrentTable.Rows[i - 1]["AMT"] = TxtChargesAmount.Text.Trim();

                        rowIndex++;

                        double lblTotalAmount = TotalChargesAmount();
                        lblISumChargesTotalAmount.Text = lblTotalAmount.ToString();

                        TxtTotalChargesAmt.Text = lblISumChargesTotalAmount.Text;


                    }

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["CCODE"] = "0";
                    drCurrentRow["CHARGES_DESC"] = "";
                    drCurrentRow["AMT"] = "";


                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable_C"] = dtCurrentTable;

                    GvChagresTranDetails.DataSource = dtCurrentTable;
                    GvChagresTranDetails.DataBind();


                }
            }

            else
            {
                Response.Write("ViewState is null");
            }

            SetPreviousData_ChargesGrid();
        }



        private void SetPreviousData_ChargesGrid()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable_C"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable_C"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Label lblISumChargesTotalAmount = (Label)(GvChagresTranDetails.FooterRow.FindControl("lblISumChargesTotalAmount"));

                        HiddenField HfChargesCode = (HiddenField)GvChagresTranDetails.Rows[rowIndex].Cells[0].FindControl("HfChargesCode");

                        TextBox TxtChargesName = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[1].FindControl("TxtChargesName");
                        TextBox TxtChargesDesription = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[2].FindControl("TxtChargesDesription");
                        TextBox TxtChargesAmount = (TextBox)GvChagresTranDetails.Rows[rowIndex].Cells[3].FindControl("TxtChargesAmount");




                        //TxtSrNo.Text = dt.Rows[i]["SRNO"].ToString();
                        HfChargesCode.Value = dt.Rows[i]["CCODE"].ToString();
                        TxtChargesDesription.Text = dt.Rows[i]["CHARGES_DESC"].ToString();
                        TxtChargesAmount.Text = dt.Rows[i]["AMT"].ToString();


                        rowIndex++;

                        double lblTotalAmount = TotalChargesAmount();
                        lblISumChargesTotalAmount.Text = lblTotalAmount.ToString();

                        TxtTotalChargesAmt.Text = lblISumChargesTotalAmount.Text;

                    }
                }
            }
        }


        protected void BtnDeleteRowModelChargesDetailGrid_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex + 1;
            if (ViewState["CurrentTable_C"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable_C"];
                if (dt.Rows.Count > 1)
                {

                    if (gvRow.RowIndex <= dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data
                        dt.Rows.Remove(dt.Rows[rowID - 1]);
                    }
                }
                //Store the current data in ViewState for future reference
                ViewState["CurrentTable_C"] = dt;
                //Re bind the GridView for the updated data
                GvChagresTranDetails.DataSource = dt;
                GvChagresTranDetails.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData_ChargesGrid();
        }

        protected void BtnAddRowModelChargesDetailGrid_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid_ChargesGrid();
        }

        #endregion


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetChargesName(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CHARGES where COMP_CODE=@COMP_CODE and NAME like @name + '%'", con);
            cmd.Parameters.AddWithValue("@name", prefixText);
            cmd.Parameters.AddWithValue("@COMP_CODE", compcode);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> ChargesNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChargesNames.Add(dt.Rows[i][2].ToString());
            }
            return ChargesNames;
        }

        protected void TxtChargesName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                HiddenField HfChargesCode = (HiddenField)row.Cells[0].FindControl("HfChargesCode");

                DataTable DtChargesName = new DataTable();
                string Comp_Code = Session["COMP_CODE"].ToString();

                DtChargesName = CHARGES_MASLogicLayer.GetAllCHARGESDetialsForComapnyWise_DDL(Comp_Code);
                if (txt.Text != string.Empty)
                {
                    DataView Dv = new DataView(DtChargesName);
                    Dv.RowFilter = "NAME='" + txt.Text.Trim() + "'";
                    DataTable DtView = Dv.ToTable();
                    if (DtView.Rows.Count > 0)
                    {
                        HfChargesCode.Value = DtView.Rows[0]["CCODE"].ToString();
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvChagresTranDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvChagresTranDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvChagresTranDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    TextBox TxtChargesName = (e.Row.FindControl("TxtChargesName") as TextBox);
                    HiddenField HfChargesCode = (e.Row.FindControl("HfChargesCode") as HiddenField);

                    DataTable DtChargesName = new DataTable();
                    string Comp_Code = Session["COMP_CODE"].ToString();

                    DtChargesName = CHARGES_MASLogicLayer.GetAllCHARGESDetialsForComapnyWise_DDL(Comp_Code);

                    if (HfChargesCode.Value != "0" && HfChargesCode.Value != string.Empty)
                    {
                        DataView Dv = new DataView(DtChargesName);
                        Dv.RowFilter = "CCODE=" + HfChargesCode.Value;
                        DataTable DtView = Dv.ToTable();
                        if (DtView.Rows.Count > 0)
                        {
                            TxtChargesName.Text = DtView.Rows[0]["NAME"].ToString();
                        }
                        else
                        {
                            TxtChargesName.Text = string.Empty;

                        }
                    }
                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblISumChargesTotalAmount = (Label)e.Row.FindControl("lblISumChargesTotalAmount");

                    double lblTotalAmount = TotalChargesAmount();
                    lblISumChargesTotalAmount.Text = lblTotalAmount.ToString();

                    TxtTotalChargesAmt.Text = lblISumChargesTotalAmount.Text;

                }

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
                #region UPDATE SERVICE ISSUE TO BRANCH MASTER

                #region INSERT SERVICE ISSUE TO BRANCH MASTER

                BRANCH_TRANMASLogicLayer insert = new BRANCH_TRANMASLogicLayer();

                insert.COMP_CODE = Session["COMP_CODE"].ToString();
                insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                insert.TRAN_DATE = Convert.ToDateTime(HfTranDate.Value.Trim()).ToString("MM-dd-yyyy");
                insert.TRAN_NO = HfTranNo.Value.Trim();
                insert.TRNDT = Convert.ToDateTime(TxtServiceDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                insert.SRNO = TxtSrNo.Text.Trim();
                insert.TO_BRANCH_CODE = HfToBranchCode.Value.Trim();

                if (TxtServicePersonName1.Text == string.Empty)
                {
                    insert.VISIT_BCODE1 = null;
                }
                else
                {
                    insert.VISIT_BCODE1 = HfServicePerson1.Value.Trim();
                }

                if (TxtServicePersonName2.Text == string.Empty)
                {
                    insert.VISIT_BCODE2 = null;
                }
                else
                {
                    insert.VISIT_BCODE2 = HfServicePerson2.Value.Trim();
                }

                if (TxtServicePersonName3.Text == string.Empty)
                {
                    insert.VISIT_BCODE3 = null;
                }
                else
                {
                    insert.VISIT_BCODE3 = HfServicePerson3.Value.Trim();
                }

                if (TxtServicePersonName4.Text == string.Empty)
                {
                    insert.VISIT_BCODE4 = null;
                }
                else
                {
                    insert.VISIT_BCODE4 = HfServicePerson4.Value.Trim();
                }

                if (TxtServicePersonName5.Text == string.Empty)
                {
                    insert.VISIT_BCODE5 = null;
                }
                else
                {
                    insert.VISIT_BCODE5 = HfServicePerson5.Value.Trim();
                }

                insert.VISITSTART_TIME = TxtVisitStartTime.Text.Trim().ToUpper();
                insert.VISITCLOSE_TIME = TxtVisitCloseTime.Text.Trim().ToUpper();
                insert.JOBSTART_TIME = TxtJobStartTime.Text.Trim().ToUpper();
                insert.JOBCLOSE_TIME = TxtJobCloseTime.Text.Trim().ToUpper();

                if (TxtTotalChargesAmt.Text == string.Empty)
                {
                    insert.TOT_CHARGES_AMT = "0";
                }
                else
                {
                    insert.TOT_CHARGES_AMT = TxtTotalChargesAmt.Text.Trim();
                }

                if (TxtDeliveredPersonName.Text == string.Empty)
                {
                    insert.BCODE = null;
                }
                else
                {
                    insert.BCODE = HfDeliveredPersonBy.Value.Trim();
                }

                if (TxtCheckedBy.Text == string.Empty)
                {
                    insert.REC_BCODE = null;
                }
                else
                {
                    insert.REC_BCODE = HfCheckedByPerson.Value.Trim();
                }

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

                //insert.INS_USERID = Session["USERNAME"].ToString();
                //insert.INS_TERMINAL = Session["PC"].ToString();
                //insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_DATE = "";
                insert.UPD_TERMINAL = Session["PC"].ToString();


                #endregion

                #region INSERT PARTY DETAILS INTO GRID

                XmlDocument XDoc1 = new XmlDocument();
                XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                XDoc1.AppendChild(dec1);// Create the root element
                XmlElement root1 = XDoc1.CreateElement("root");
                XDoc1.AppendChild(root1);
                int SRNODETAIL = 1;
                foreach (GridViewRow row in GvBranchPartyTranDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        HiddenField HfACODE = row.FindControl("HfACODE") as HiddenField;
                        HiddenField HfTotalTime = row.FindControl("HfTotalTime") as HiddenField;
                        TextBox TxtPartyName = row.FindControl("TxtPartyName") as TextBox;
                        TextBox TxtContactPerson = row.FindControl("TxtContactPerson") as TextBox;
                        TextBox TxtContactPhone = row.FindControl("TxtContactPhone") as TextBox;
                        TextBox TxtCompanyRemark = row.FindControl("TxtCompanyRemark") as TextBox;
                        TextBox TxtJobStartTime = row.FindControl("TxtJobStartTime") as TextBox;
                        TextBox TxtJobCloseTime = row.FindControl("TxtJobCloseTime") as TextBox;
                        TextBox TxtTotalTime = row.FindControl("TxtTotalTime") as TextBox;
                        DropDownList DdlCompletedStaus = row.FindControl("DdlCompletedStaus") as DropDownList;
                        TextBox TxtOwnRemark = row.FindControl("TxtOwnRemark") as TextBox;

                        if (TxtPartyName.Text != string.Empty && TxtPartyName.Text != null)
                        {


                            XmlElement HandleDetail2 = XDoc1.CreateElement("BRANCH_TRAN_PARTYDetails");
                            HandleDetail2.SetAttribute("SRNO", SRNODETAIL.ToString());
                            HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                            HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                            if (TxtPartyName.Text == string.Empty)
                            {
                                HandleDetail2.SetAttribute("ACODE", null);
                            }
                            else
                            {
                                HandleDetail2.SetAttribute("ACODE", (HfACODE.Value));
                            }

                            HandleDetail2.SetAttribute("CONTACT_PERSON", (TxtContactPerson.Text.Trim().ToUpper()));

                            HandleDetail2.SetAttribute("CONTACT_PHONE", (TxtContactPhone.Text.Trim().ToUpper()));

                            HandleDetail2.SetAttribute("COMPANY_REMARK", (TxtCompanyRemark.Text.Trim().ToUpper()));

                            HandleDetail2.SetAttribute("JOBSTART_TIME", (TxtJobStartTime.Text.Trim().ToUpper()));

                            HandleDetail2.SetAttribute("JOBCLOSE_TIME", (TxtJobCloseTime.Text.Trim().ToUpper()));


                            HandleDetail2.SetAttribute("TOT_TIME", HfTotalTime.Value.Trim() != string.Empty ? (HfTotalTime.Value.Trim().ToUpper()) : "0");

                            HandleDetail2.SetAttribute("JOB_COMPFLAG", (DdlCompletedStaus.SelectedValue.Trim().ToUpper()));

                            HandleDetail2.SetAttribute("OWN_REMARK", (TxtOwnRemark.Text.Trim().ToUpper()));

                            //HandleDetail2.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));

                            //HandleDetail2.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));

                            //HandleDetail2.SetAttribute("INS_DATE", "");

                            HandleDetail2.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));

                            HandleDetail2.SetAttribute("UPD_DATE", "");

                            HandleDetail2.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));

                            root1.AppendChild(HandleDetail2);
                            SRNODETAIL++;

                        }
                    }
                }

                #endregion


                #region Insert Branch Charges Details Into GRid

                XmlDocument XDoc2 = new XmlDocument();
                XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                XDoc2.AppendChild(dec2);// Create the root element
                XmlElement root2 = XDoc2.CreateElement("root");
                XDoc2.AppendChild(root2);
                int SRNOCharges = 1;

                foreach (GridViewRow row in GvChagresTranDetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        HiddenField HfChargesCode = row.FindControl("HfChargesCode") as HiddenField;
                        TextBox TxtChargesName = row.FindControl("TxtChargesName") as TextBox;
                        TextBox TxtChargesDesription = row.FindControl("TxtChargesDesription") as TextBox;
                        TextBox TxtChargesAmount = row.FindControl("TxtChargesAmount") as TextBox;


                        XmlElement HandleDetail3 = XDoc2.CreateElement("BRANCH_TRANDETDetails");

                        if (TxtChargesName.Text != string.Empty && TxtChargesName.Text != null)
                        {
                            HandleDetail3.SetAttribute("SRNO", SRNOCharges.ToString());
                            HandleDetail3.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                            HandleDetail3.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                            HandleDetail3.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                            if (TxtChargesName.Text == string.Empty)
                            {
                                HandleDetail3.SetAttribute("CCODE", null);
                            }
                            else
                            {
                                HandleDetail3.SetAttribute("CCODE", (HfChargesCode.Value));
                            }

                            HandleDetail3.SetAttribute("CHARGES_DESC", (TxtChargesDesription.Text.Trim().ToUpper()));

                            HandleDetail3.SetAttribute("AMT", TxtChargesAmount.Text.Trim() != string.Empty ? (TxtChargesAmount.Text.Trim().ToUpper()) : "0");

                            //HandleDetail3.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));

                            //HandleDetail3.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));

                            //HandleDetail3.SetAttribute("INS_DATE", "");

                            HandleDetail3.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));

                            HandleDetail3.SetAttribute("UPD_DATE", "");

                            HandleDetail3.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));

                            root2.AppendChild(HandleDetail3);
                            SRNOCharges++;

                        }
                    }
                }
                #endregion


                string str = BRANCH_TRANMASLogicLayer.UpdateSERVICE_ISSUE_BRANCH_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"));


                if (str.Contains("successfully"))
                {
                    lblmsg.Text = "SERVICE ISSUE TO BRANCH MASTER UPDATE SUCCESSFULLY.";
                    lblmsg.ForeColor = Color.Green;
                    clear();
                    FillSERVICE_ISSUE_TOBRANCH_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();


                }
                else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                {
                    lblmsg.Text = "SERVICE ISSUE TO BRANCH MASTER ALREADY EXIST.";
                    lblmsg.ForeColor = Color.Red;
                }
                else
                {
                    lblmsg.Text = "ERROR : SERVICE ISSUE TO BRANCH MASTER NOT SAVED";
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


                    #region INSERT SERVICE ISSUE TO BRANCH MASTER

                    BRANCH_TRANMASLogicLayer insert = new BRANCH_TRANMASLogicLayer();

                    insert.COMP_CODE = Session["COMP_CODE"].ToString();
                    insert.BRANCH_CODE = Session["BRANCH_CODE"].ToString();
                    //insert.TRAN_DATE    = HfTranDate.Value.Trim();
                    //insert.TRAN_NO      = HfTranNo.Value.Trim();
                    insert.TRNDT = Convert.ToDateTime(TxtServiceDate.Text.Trim().ToUpper()).ToString("MM-dd-yyyy");
                    insert.SRNO = TxtSrNo.Text.Trim();
                    insert.TO_BRANCH_CODE = HfToBranchCode.Value.Trim();

                    if (TxtServicePersonName1.Text == string.Empty)
                    {
                        insert.VISIT_BCODE1 = null;
                    }
                    else
                    {
                        insert.VISIT_BCODE1 = HfServicePerson1.Value.Trim();
                    }

                    if (TxtServicePersonName2.Text == string.Empty)
                    {
                        insert.VISIT_BCODE2 = null;
                    }
                    else
                    {
                        insert.VISIT_BCODE2 = HfServicePerson2.Value.Trim();
                    }

                    if (TxtServicePersonName3.Text == string.Empty)
                    {
                        insert.VISIT_BCODE3 = null;
                    }
                    else
                    {
                        insert.VISIT_BCODE3 = HfServicePerson3.Value.Trim();
                    }

                    if (TxtServicePersonName4.Text == string.Empty)
                    {
                        insert.VISIT_BCODE4 = null;
                    }
                    else
                    {
                        insert.VISIT_BCODE4 = HfServicePerson4.Value.Trim();
                    }

                    if (TxtServicePersonName5.Text == string.Empty)
                    {
                        insert.VISIT_BCODE5 = null;
                    }
                    else
                    {
                        insert.VISIT_BCODE5 = HfServicePerson5.Value.Trim();
                    }

                    insert.VISITSTART_TIME = TxtVisitStartTime.Text.Trim().ToUpper();
                    insert.VISITCLOSE_TIME = TxtVisitCloseTime.Text.Trim().ToUpper();
                    insert.JOBSTART_TIME = TxtJobStartTime.Text.Trim().ToUpper();
                    insert.JOBCLOSE_TIME = TxtJobCloseTime.Text.Trim().ToUpper();

                    if (TxtTotalChargesAmt.Text == string.Empty)
                    {
                        insert.TOT_CHARGES_AMT = "0";
                    }
                    else
                    {
                        insert.TOT_CHARGES_AMT = TxtTotalChargesAmt.Text.Trim();
                    }

                    if (TxtDeliveredPersonName.Text == string.Empty)
                    {
                        insert.BCODE = null;
                    }
                    else
                    {
                        insert.BCODE = HfDeliveredPersonBy.Value.Trim();
                    }

                    if (TxtCheckedBy.Text == string.Empty)
                    {
                        insert.REC_BCODE = null;
                    }
                    else
                    {
                        insert.REC_BCODE = HfCheckedByPerson.Value.Trim();
                    }

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

                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_DATE = "";
                    insert.UPD_TERMINAL = Session["PC"].ToString();


                    #endregion

                    #region INSERT PARTY DETAILS INTO GRID

                    XmlDocument XDoc1 = new XmlDocument();
                    XmlDeclaration dec1 = XDoc1.CreateXmlDeclaration("1.0", null, null);
                    XDoc1.AppendChild(dec1);// Create the root element
                    XmlElement root1 = XDoc1.CreateElement("root");
                    XDoc1.AppendChild(root1);
                    int SRNODETAIL = 1;
                    foreach (GridViewRow row in GvBranchPartyTranDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {

                            HiddenField HfACODE = row.FindControl("HfACODE") as HiddenField;
                            HiddenField HfTotalTime = row.FindControl("HfTotalTime") as HiddenField;
                            TextBox TxtPartyName = row.FindControl("TxtPartyName") as TextBox;
                            TextBox TxtContactPerson = row.FindControl("TxtContactPerson") as TextBox;
                            TextBox TxtContactPhone = row.FindControl("TxtContactPhone") as TextBox;
                            TextBox TxtCompanyRemark = row.FindControl("TxtCompanyRemark") as TextBox;
                            TextBox TxtJobStartTime = row.FindControl("TxtJobStartTime") as TextBox;
                            TextBox TxtJobCloseTime = row.FindControl("TxtJobCloseTime") as TextBox;
                            TextBox TxtTotalTime = row.FindControl("TxtTotalTime") as TextBox;
                            DropDownList DdlCompletedStaus = row.FindControl("DdlCompletedStaus") as DropDownList;
                            TextBox TxtOwnRemark = row.FindControl("TxtOwnRemark") as TextBox;

                            if (TxtPartyName.Text != string.Empty && TxtPartyName.Text != null)
                            {


                                XmlElement HandleDetail2 = XDoc1.CreateElement("BRANCH_TRAN_PARTYDetails");
                                HandleDetail2.SetAttribute("SRNO", SRNODETAIL.ToString());
                                HandleDetail2.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //HandleDetail2.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //HandleDetail2.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                if (TxtPartyName.Text == string.Empty)
                                {
                                    HandleDetail2.SetAttribute("ACODE", null);
                                }
                                else
                                {
                                    HandleDetail2.SetAttribute("ACODE", (HfACODE.Value));
                                }

                                HandleDetail2.SetAttribute("CONTACT_PERSON", (TxtContactPerson.Text.Trim().ToUpper()));

                                HandleDetail2.SetAttribute("CONTACT_PHONE", (TxtContactPhone.Text.Trim().ToUpper()));

                                HandleDetail2.SetAttribute("COMPANY_REMARK", (TxtCompanyRemark.Text.Trim().ToUpper()));

                                HandleDetail2.SetAttribute("JOBSTART_TIME", (TxtJobStartTime.Text.Trim().ToUpper()));

                                HandleDetail2.SetAttribute("JOBCLOSE_TIME", (TxtJobCloseTime.Text.Trim().ToUpper()));


                                HandleDetail2.SetAttribute("TOT_TIME", HfTotalTime.Value.Trim() != string.Empty ? (HfTotalTime.Value.Trim().ToUpper()) : "0");

                                HandleDetail2.SetAttribute("JOB_COMPFLAG", (DdlCompletedStaus.SelectedValue.Trim().ToUpper()));

                                HandleDetail2.SetAttribute("OWN_REMARK", (TxtOwnRemark.Text.Trim().ToUpper()));

                                HandleDetail2.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));

                                HandleDetail2.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));

                                HandleDetail2.SetAttribute("INS_DATE", "");

                                HandleDetail2.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));

                                HandleDetail2.SetAttribute("UPD_DATE", "");

                                HandleDetail2.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));

                                root1.AppendChild(HandleDetail2);
                                SRNODETAIL++;

                            }
                        }
                    }

                    #endregion


                    #region Insert Branch Charges Details Into GRid

                    XmlDocument XDoc2 = new XmlDocument();
                    XmlDeclaration dec2 = XDoc2.CreateXmlDeclaration("1.0", null, null);
                    XDoc2.AppendChild(dec2);// Create the root element
                    XmlElement root2 = XDoc2.CreateElement("root");
                    XDoc2.AppendChild(root2);
                    int SRNOCharges = 1;

                    foreach (GridViewRow row in GvChagresTranDetails.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            HiddenField HfChargesCode = row.FindControl("HfChargesCode") as HiddenField;
                            TextBox TxtChargesName = row.FindControl("TxtChargesName") as TextBox;
                            TextBox TxtChargesDesription = row.FindControl("TxtChargesDesription") as TextBox;
                            TextBox TxtChargesAmount = row.FindControl("TxtChargesAmount") as TextBox;


                            XmlElement HandleDetail3 = XDoc2.CreateElement("BRANCH_TRANDETDetails");

                            if (TxtChargesName.Text != string.Empty && TxtChargesName.Text != null)
                            {
                                HandleDetail3.SetAttribute("SRNO", SRNOCharges.ToString());
                                HandleDetail3.SetAttribute("COMP_CODE", Session["COMP_CODE"].ToString());
                                //    HandleDetail4.SetAttribute("TRAN_NO", HfTranNo.Value.Trim());
                                //    HandleDetail4.SetAttribute("TRAN_DATE", HfTranDate.Value.Trim());

                                if (TxtChargesName.Text == string.Empty)
                                {
                                    HandleDetail3.SetAttribute("CCODE", null);
                                }
                                else
                                {
                                    HandleDetail3.SetAttribute("CCODE", (HfChargesCode.Value));
                                }

                                HandleDetail3.SetAttribute("CHARGES_DESC", (TxtChargesDesription.Text.Trim().ToUpper()));

                                HandleDetail3.SetAttribute("AMT", TxtChargesAmount.Text.Trim() != string.Empty ? (TxtChargesAmount.Text.Trim().ToUpper()) : "0");

                                HandleDetail3.SetAttribute("INS_USERID", (Session["USERNAME"].ToString()));

                                HandleDetail3.SetAttribute("INS_TERMINAL", (Session["PC"].ToString()));

                                HandleDetail3.SetAttribute("INS_DATE", "");

                                HandleDetail3.SetAttribute("UPD_USERID", (Session["USERNAME"].ToString()));

                                HandleDetail3.SetAttribute("UPD_DATE", "");

                                HandleDetail3.SetAttribute("UPD_TERMINAL", (Session["PC"].ToString()));

                                root2.AppendChild(HandleDetail3);
                                SRNOCharges++;

                            }
                        }
                    }
                    #endregion

                    string str = BRANCH_TRANMASLogicLayer.InsertSERVICE_ISSUE_TOBRANCH_MASDetail(insert, validation.RSC(XDoc1.OuterXml), validation.RSC(XDoc2.OuterXml), Session["COMP_CODE"].ToString(), Session["BRANCH_CODE"].ToString(), Convert.ToDateTime(Session["FIN_YEAR"].ToString()).ToString("yyyy-MM-dd"));

                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "SERVICE ISSUE BRANCH MASTER SAVE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillSERVICE_ISSUE_TOBRANCH_MasterGrid(Session["COMP_CODE"].ToString());
                        UserRights();


                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "SERVICE ISSUE BRANCH MASTER ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : SERVICE ISSUE BRANCH MASTER NOT SAVED";
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



        protected void GvServiceIssueBranchMaster_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void GvServiceIssueBranchMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GvServiceIssueBranchMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                //ViewState["CurrentTable"] = null;
                //ViewState["CurrentTable_C"] = null;


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


                        DataSet ds = BRANCH_TRANMASLogicLayer.GetAllIDWiseSERVICE_ISSUE_BRANCH_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtPartyDetails = ds.Tables[1];
                        DataTable DtChargesDetails = ds.Tables[2];

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
                            TxtServiceDate.Text = Convert.ToDateTime(dt.Rows[0]["TRNDT"].ToString()).ToString("dd-MM-yyyy");
                            TxtSrNo.Text = dt.Rows[0]["SRNO"].ToString();
                            HfServicePerson1.Value = dt.Rows[0]["VISIT_BCODE1"].ToString();
                            FillVisitServicePerson1(dt.Rows[0]["VISIT_BCODE1"].ToString());
                            HfServicePerson2.Value = dt.Rows[0]["VISIT_BCODE2"].ToString();
                            FillVisitServicePerson2(dt.Rows[0]["VISIT_BCODE2"].ToString());
                            HfServicePerson3.Value = dt.Rows[0]["VISIT_BCODE3"].ToString();
                            FillVisitServicePerson3(dt.Rows[0]["VISIT_BCODE3"].ToString());
                            HfServicePerson4.Value = dt.Rows[0]["VISIT_BCODE4"].ToString();
                            FillVisitServicePerson4(dt.Rows[0]["VISIT_BCODE4"].ToString());
                            HfServicePerson5.Value = dt.Rows[0]["VISIT_BCODE5"].ToString();
                            FillVisitServicePerson5(dt.Rows[0]["VISIT_BCODE5"].ToString());
                            TxtVisitStartTime.Text = dt.Rows[0]["VISITSTART_TIME"].ToString();
                            TxtVisitCloseTime.Text = dt.Rows[0]["VISITCLOSE_TIME"].ToString();
                            TxtJobStartTime.Text = dt.Rows[0]["JOBSTART_TIME"].ToString();
                            TxtJobCloseTime.Text = dt.Rows[0]["JOBCLOSE_TIME"].ToString();
                            TxtTotalChargesAmt.Text = dt.Rows[0]["TOT_CHARGES_AMT"].ToString();
                            HfDeliveredPersonBy.Value = dt.Rows[0]["BCODE"].ToString();
                            FillVisitDeliveredPersonBy(dt.Rows[0]["BCODE"].ToString());
                            HfCheckedByPerson.Value = dt.Rows[0]["REC_BCODE"].ToString();
                            FillVisitCheckedPersonBy(dt.Rows[0]["REC_BCODE"].ToString());
                            DdlReceivedFlag.SelectedValue = dt.Rows[0]["REC_FLAG"].ToString();
                            TxtReceivedBy.Text = dt.Rows[0]["REC_USERID"].ToString(); ;
                            TxtReceivedDate.Text = dt.Rows[0]["REC_DATE"].ToString();

                            if (DtPartyDetails.Rows.Count > 0)
                            {
                                GvBranchPartyTranDetails.DataSource = DtPartyDetails;
                                GvBranchPartyTranDetails.DataBind();
                                GvBranchPartyTranDetails.Enabled = false;
                            }

                            if (DtChargesDetails.Rows.Count > 0)
                            {

                                GvChagresTranDetails.DataSource = DtChargesDetails;
                                GvChagresTranDetails.DataBind();
                                GvChagresTranDetails.Enabled = false;
                            }

                            btnSave.Visible = false;
                            btnDelete.Visible = true;
                            Btncalldel.Visible = true;
                            BtncallUpd.Visible = false;
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


                        DataSet ds = BRANCH_TRANMASLogicLayer.GetAllIDWiseSERVICE_ISSUE_BRANCH_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtPartyDetails = ds.Tables[1];
                        DataTable DtChargesDetails = ds.Tables[2];

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
                            TxtServiceDate.Text = Convert.ToDateTime(dt.Rows[0]["TRNDT"].ToString()).ToString("dd-MM-yyyy");
                            TxtSrNo.Text = dt.Rows[0]["SRNO"].ToString();
                            HfServicePerson1.Value = dt.Rows[0]["VISIT_BCODE1"].ToString();
                            FillVisitServicePerson1(dt.Rows[0]["VISIT_BCODE1"].ToString());
                            HfServicePerson2.Value = dt.Rows[0]["VISIT_BCODE2"].ToString();
                            FillVisitServicePerson2(dt.Rows[0]["VISIT_BCODE2"].ToString());
                            HfServicePerson3.Value = dt.Rows[0]["VISIT_BCODE3"].ToString();
                            FillVisitServicePerson3(dt.Rows[0]["VISIT_BCODE3"].ToString());
                            HfServicePerson4.Value = dt.Rows[0]["VISIT_BCODE4"].ToString();
                            FillVisitServicePerson4(dt.Rows[0]["VISIT_BCODE4"].ToString());
                            HfServicePerson5.Value = dt.Rows[0]["VISIT_BCODE5"].ToString();
                            FillVisitServicePerson5(dt.Rows[0]["VISIT_BCODE5"].ToString());
                            TxtVisitStartTime.Text = dt.Rows[0]["VISITSTART_TIME"].ToString();
                            TxtVisitCloseTime.Text = dt.Rows[0]["VISITCLOSE_TIME"].ToString();
                            TxtJobStartTime.Text = dt.Rows[0]["JOBSTART_TIME"].ToString();
                            TxtJobCloseTime.Text = dt.Rows[0]["JOBCLOSE_TIME"].ToString();
                            TxtTotalChargesAmt.Text = dt.Rows[0]["TOT_CHARGES_AMT"].ToString();
                            HfDeliveredPersonBy.Value = dt.Rows[0]["BCODE"].ToString();
                            FillVisitDeliveredPersonBy(dt.Rows[0]["BCODE"].ToString());
                            HfCheckedByPerson.Value = dt.Rows[0]["REC_BCODE"].ToString();
                            FillVisitCheckedPersonBy(dt.Rows[0]["REC_BCODE"].ToString());
                            DdlReceivedFlag.SelectedValue = dt.Rows[0]["REC_FLAG"].ToString();
                            TxtReceivedBy.Text = dt.Rows[0]["REC_USERID"].ToString(); ;
                            TxtReceivedDate.Text = dt.Rows[0]["REC_DATE"].ToString();

                            if (DtPartyDetails.Rows.Count > 0)
                            {
                                GvBranchPartyTranDetails.DataSource = DtPartyDetails;
                                GvBranchPartyTranDetails.DataBind();
                                GvBranchPartyTranDetails.Enabled = true;
                            }

                            if (DtChargesDetails.Rows.Count > 0)
                            {

                                GvChagresTranDetails.DataSource = DtChargesDetails;
                                GvChagresTranDetails.DataBind();
                                GvChagresTranDetails.Enabled = true;
                            }

                            BtncallUpd.Text = "UPDATE";

                            #endregion


                            if (HfBranchIssueToServiceType.Value == "T")
                            {


                                DdlReceivedFlag.Enabled = false;
                                TxtReceivedBy.Enabled = false;
                                TxtReceivedDate.Enabled = false;
                                GvChagresTranDetails.Enabled = true;
                            }

                            else if (HfBranchIssueToServiceType.Value == "F")
                            {

                                DdlReceivedFlag.Enabled = true;
                                TxtReceivedBy.Enabled = true;
                                TxtReceivedDate.Enabled = true;
                                GvChagresTranDetails.Enabled = false;

                            }
                            else { }
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


                        DataSet ds = BRANCH_TRANMASLogicLayer.GetAllIDWiseSERVICE_ISSUE_BRANCH_MASDetials(e.CommandArgument.ToString(), Convert.ToDateTime(HfTranDateGrid.Value.ToString()));
                        DataTable dt = ds.Tables[0];
                        DataTable DtPartyDetails = ds.Tables[1];
                        DataTable DtChargesDetails = ds.Tables[2];

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
                            TxtServiceDate.Text = Convert.ToDateTime(dt.Rows[0]["TRNDT"].ToString()).ToString("dd-MM-yyyy");
                            TxtSrNo.Text = dt.Rows[0]["SRNO"].ToString();
                            HfServicePerson1.Value = dt.Rows[0]["VISIT_BCODE1"].ToString();
                            FillVisitServicePerson1(dt.Rows[0]["VISIT_BCODE1"].ToString());
                            HfServicePerson2.Value = dt.Rows[0]["VISIT_BCODE2"].ToString();
                            FillVisitServicePerson2(dt.Rows[0]["VISIT_BCODE2"].ToString());
                            HfServicePerson3.Value = dt.Rows[0]["VISIT_BCODE3"].ToString();
                            FillVisitServicePerson3(dt.Rows[0]["VISIT_BCODE3"].ToString());
                            HfServicePerson4.Value = dt.Rows[0]["VISIT_BCODE4"].ToString();
                            FillVisitServicePerson4(dt.Rows[0]["VISIT_BCODE4"].ToString());
                            HfServicePerson5.Value = dt.Rows[0]["VISIT_BCODE5"].ToString();
                            FillVisitServicePerson5(dt.Rows[0]["VISIT_BCODE5"].ToString());
                            TxtVisitStartTime.Text = dt.Rows[0]["VISITSTART_TIME"].ToString();
                            TxtVisitCloseTime.Text = dt.Rows[0]["VISITCLOSE_TIME"].ToString();
                            TxtJobStartTime.Text = dt.Rows[0]["JOBSTART_TIME"].ToString();
                            TxtJobCloseTime.Text = dt.Rows[0]["JOBCLOSE_TIME"].ToString();
                            TxtTotalChargesAmt.Text = dt.Rows[0]["TOT_CHARGES_AMT"].ToString();
                            HfDeliveredPersonBy.Value = dt.Rows[0]["BCODE"].ToString();
                            FillVisitDeliveredPersonBy(dt.Rows[0]["BCODE"].ToString());
                            HfCheckedByPerson.Value = dt.Rows[0]["REC_BCODE"].ToString();
                            FillVisitCheckedPersonBy(dt.Rows[0]["REC_BCODE"].ToString());
                            DdlReceivedFlag.SelectedValue = dt.Rows[0]["REC_FLAG"].ToString();
                            TxtReceivedBy.Text = dt.Rows[0]["REC_USERID"].ToString(); ;
                            TxtReceivedDate.Text = dt.Rows[0]["REC_DATE"].ToString();

                            if (DtPartyDetails.Rows.Count > 0)
                            {
                                GvBranchPartyTranDetails.DataSource = DtPartyDetails;
                                GvBranchPartyTranDetails.DataBind();
                                GvBranchPartyTranDetails.Enabled = false;
                            }

                            if (DtChargesDetails.Rows.Count > 0)
                            {

                                GvChagresTranDetails.DataSource = DtChargesDetails;
                                GvChagresTranDetails.DataBind();
                                GvChagresTranDetails.Enabled = false;
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
            catch (Exception ex)
            {

                lblmsg.Text = ex.Message.ToString();
            }
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                #region  DELETE 

                if (HfTranNo.Value != string.Empty && HfTranDate.Value != string.Empty)
                {
                    string str = BRANCH_TRANMASLogicLayer.DeleteSERVICE_ISSUE_TO_BRANCHDetailsByID(HfTranNo.Value, Convert.ToDateTime(HfTranDate.Value.ToString()));
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
                        lblmsg.Text = "Error:Service Issue to Branch Master Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillSERVICE_ISSUE_TOBRANCH_MasterGrid(Session["COMP_CODE"].ToString());
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }




        protected void BtnViewChallan_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openpage", "window.open('../reportviewPages/ServiceIssueToBranch_Print.aspx', '_blank');", true);
        }



        protected void TxtJobCloseTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow row = (GridViewRow)txt.Parent.Parent;
                int idx = row.RowIndex;

                TextBox TxtJobStartTime = (TextBox)row.Cells[5].FindControl("TxtJobStartTime");
                TextBox TxtJobCloseTime = (TextBox)row.Cells[6].FindControl("TxtJobCloseTime");
                TextBox TxtTotalTime = (TextBox)row.Cells[7].FindControl("TxtTotalTime");

                HiddenField HfTotalTime = (HiddenField)row.Cells[0].FindControl("HfTotalTime");


                TimeSpan ts1 = TimeSpan.Parse(TxtJobStartTime.Text); //"1:35"
                TimeSpan ts2 = TimeSpan.Parse(TxtJobCloseTime.Text); //"3:30"

                TxtTotalTime.Text = (ts2 - ts1).ToString();
                HfTotalTime.Value = (ts2 - ts1).TotalMinutes.ToString();




            }
            catch (Exception)
            {

                throw;
            }
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

    }

}