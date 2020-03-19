using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp
{
    public partial class TransportMaster : System.Web.UI.Page
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
                FillGrid();
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

        public void ControllerEnable()
        {
            // HfTransportCode.Value = string.Empty;
            TxtTransportName.Enabled = true;
            TxtVehicleNo.Enabled = true;
            TxtMDLNo.Enabled = true;
            TxtMDLState.Enabled = true;
            TxtPhoneO.Enabled = true;
            TxtPhoneM.Enabled = true;
            TxtAddress1.Enabled = true;
            TxtContactPerson.Enabled = true;
            TxtFax.Enabled = true;
            TxtEmail.Enabled = true;
        }
        public void ControllerDisable()
        {
            // HfTransportCode.Value = string.Empty;
            TxtTransportName.Enabled = false;
            TxtVehicleNo.Enabled = false;
            TxtMDLNo.Enabled = false;
            TxtMDLState.Enabled = false;
            TxtPhoneO.Enabled = false;
            TxtPhoneM.Enabled = false;
            TxtAddress1.Enabled = false;
            TxtContactPerson.Enabled = false;
            TxtFax.Enabled = false;
            TxtEmail.Enabled = false;
        }

      public void clear()

        {
            DivEntry.Visible = false;
            DivView.Visible = true;

            HfTransportCode.Value = string.Empty;
            TxtTransportName.Text = string.Empty;
            TxtVehicleNo.Text = string.Empty;
            TxtMDLNo.Text = string.Empty;
            TxtMDLState.Text = string.Empty;
            TxtPhoneO.Text = string.Empty;
            TxtPhoneM.Text = string.Empty;
            TxtAddress1.Text = string.Empty;
            TxtContactPerson.Text = string.Empty;
            TxtFax.Text = string.Empty;
            TxtEmail.Text = string.Empty;

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
                #region INSERT _ UPDATE VALUE

                TRANSPORT_MASLogicLayer insert = new TRANSPORT_MASLogicLayer();
                insert.TCODE = HfTransportCode.Value.Trim();
                insert.TNAME = TxtTransportName.Text.Trim().ToUpper();
                insert.CONTACT_PER = TxtContactPerson.Text.Trim().ToUpper();
                insert.ADD1 = TxtAddress1.Text.Trim().ToUpper();
                insert.ADD2 = "";
                insert.ADD3 = "";
                insert.PHONE_O = TxtPhoneO.Text.Trim().ToUpper();
                insert.PHONE_M = TxtPhoneM.Text.Trim().ToUpper();
                insert.FAX = TxtFax.Text.Trim().ToUpper();
                insert.EMAIL = TxtEmail.Text.Trim();
                insert.VEHICLE_NO = TxtVehicleNo.Text.Trim().ToUpper();
                insert.MDLNO = TxtMDLNo.Text.Trim().ToUpper();
                insert.MDLSTATE = TxtMDLState.Text.Trim().ToUpper();
                insert.INS_USERID = Session["USERNAME"].ToString();
                insert.INS_TERMINAL = Session["PC"].ToString();
                insert.INS_DATE = "";
                insert.UPD_USERID = Session["USERNAME"].ToString();
                insert.UPD_TERMINAL = Session["PC"].ToString();
                insert.UPD_DATE = "";

                #endregion
                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = TRANSPORT_MASLogicLayer.InsertTRANSPORT_MASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "TRANSPORT DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "TRANSPORT CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : TRANSPORT DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }

                else
                {
                    string str = TRANSPORT_MASLogicLayer.UpdateTRANSPORT_MASDetails(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "TRANSPORT DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already"))
                    {
                        lblmsg.Text = "TRANSPORT CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : TRANSPORT DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void FillGrid()
        {
            try
            {
                DataTable Dt = new DataTable();

                Dt = TRANSPORT_MASLogicLayer.GetAllTRANSPORT_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                GvTransportMaster.DataSource = Dt;
                GvTransportMaster.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void GvTransportMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvTransportMaster.PageIndex = e.NewPageIndex;
                FillGrid();
                clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvTransportMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Deletea")
                {
                    #region DELETE
                    clear();
                    DataTable dt = TRANSPORT_MASLogicLayer.GetAllIDWiseTRANSPORT_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfTransportCode.Value = dt.Rows[0]["TCODE"].ToString();
                        TxtTransportName.Text = dt.Rows[0]["TNAME"].ToString();
                        TxtContactPerson.Text = dt.Rows[0]["CONTACT_PER"].ToString();
                        TxtAddress1.Text = dt.Rows[0]["ADD1"].ToString();
                        TxtPhoneO.Text = dt.Rows[0]["PHONE_O"].ToString();
                        TxtPhoneM.Text = dt.Rows[0]["PHONE_M"].ToString();
                        TxtFax.Text = dt.Rows[0]["FAX"].ToString();
                        TxtEmail.Text = dt.Rows[0]["EMAIL"].ToString();
                        TxtVehicleNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                        TxtMDLNo.Text = dt.Rows[0]["MDLNO"].ToString();
                        TxtMDLState.Text = dt.Rows[0]["MDLSTATE"].ToString();

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
                    DataTable dt = TRANSPORT_MASLogicLayer.GetAllIDWiseTRANSPORT_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfTransportCode.Value = dt.Rows[0]["TCODE"].ToString();
                        TxtTransportName.Text = dt.Rows[0]["TNAME"].ToString();
                        TxtContactPerson.Text = dt.Rows[0]["CONTACT_PER"].ToString();
                        TxtAddress1.Text = dt.Rows[0]["ADD1"].ToString();
                        TxtPhoneO.Text = dt.Rows[0]["PHONE_O"].ToString();
                        TxtPhoneM.Text = dt.Rows[0]["PHONE_M"].ToString();
                        TxtFax.Text = dt.Rows[0]["FAX"].ToString();
                        TxtEmail.Text = dt.Rows[0]["EMAIL"].ToString();
                        TxtVehicleNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                        TxtMDLNo.Text = dt.Rows[0]["MDLNO"].ToString();
                        TxtMDLState.Text = dt.Rows[0]["MDLSTATE"].ToString();

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
                    DataTable dt = TRANSPORT_MASLogicLayer.GetAllIDWiseTRANSPORT_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        DivEntry.Visible = true;
                        DivView.Visible = false;

                        HfTransportCode.Value = dt.Rows[0]["TCODE"].ToString();
                        TxtTransportName.Text = dt.Rows[0]["TNAME"].ToString();
                        TxtContactPerson.Text = dt.Rows[0]["CONTACT_PER"].ToString();
                        TxtAddress1.Text = dt.Rows[0]["ADD1"].ToString();
                        TxtPhoneO.Text = dt.Rows[0]["PHONE_O"].ToString();
                        TxtPhoneM.Text = dt.Rows[0]["PHONE_M"].ToString();
                        TxtFax.Text = dt.Rows[0]["FAX"].ToString();
                        TxtEmail.Text = dt.Rows[0]["EMAIL"].ToString();
                        TxtVehicleNo.Text = dt.Rows[0]["VEHICLE_NO"].ToString();
                        TxtMDLNo.Text = dt.Rows[0]["MDLNO"].ToString();
                        TxtMDLState.Text = dt.Rows[0]["MDLSTATE"].ToString();

                        #endregion
                    }
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

                    TRANSPORT_MASLogicLayer insert = new TRANSPORT_MASLogicLayer();
                    insert.TCODE = HfTransportCode.Value.Trim();
                    insert.TNAME = TxtTransportName.Text.Trim().ToUpper();
                    insert.CONTACT_PER = TxtContactPerson.Text.Trim().ToUpper();
                    insert.ADD1 = TxtAddress1.Text.Trim().ToUpper();
                    insert.ADD2 = "";
                    insert.ADD3 = "";
                    insert.PHONE_O = TxtPhoneO.Text.Trim().ToUpper();
                    insert.PHONE_M = TxtPhoneM.Text.Trim().ToUpper();
                    insert.FAX = TxtFax.Text.Trim().ToUpper();
                    insert.EMAIL = TxtEmail.Text.Trim();
                    insert.VEHICLE_NO = TxtVehicleNo.Text.Trim().ToUpper();
                    insert.MDLNO = TxtMDLNo.Text.Trim().ToUpper();
                    insert.MDLSTATE = TxtMDLState.Text.Trim().ToUpper();
                    insert.INS_USERID = Session["USERNAME"].ToString();
                    insert.INS_TERMINAL = Session["PC"].ToString();
                    insert.INS_DATE = "";
                    insert.UPD_USERID = Session["USERNAME"].ToString();
                    insert.UPD_TERMINAL = Session["PC"].ToString();
                    insert.UPD_DATE = "";

                    if (BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = TRANSPORT_MASLogicLayer.InsertTRANSPORT_MASDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "TRANSPORT DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid();
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "TRANSPORT CODE ALREADY EXIST.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "ERROR : TRANSPORT DETAIL NOT SAVED";
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
                if (HfTransportCode.Value != string.Empty)
                {
                    string str = TRANSPORT_MASLogicLayer.DeleteTRANSPORT_MASDetailsByID(HfTransportCode.Value);
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
                        lblmsg.Text = "Error:Branch Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillGrid();
                    UserRights();

                }
                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }
    
      
    }
}