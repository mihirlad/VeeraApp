using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class GroupMaster : System.Web.UI.Page
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
                FillGrid();
                UserRights();
                DivEntry.Visible = false;
                DivView.Visible = true;
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
                     //   btnDelete.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
            }
        }


        public void ControllerEnable()
        {
            try
            {

                //TxtGroupCode.Text = string.Empty;
                TxtGroupName.Enabled = true;
                DdlGroupType.Enabled = true;
                TxtGroupOrder.Enabled = true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ControllerDisable()
        {
            try
            {

                //TxtGroupCode.Text = string.Empty;
                TxtGroupName.Enabled = false;
                DdlGroupType.Enabled = false;
                TxtGroupOrder.Enabled = false;
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
                //TxtGroupCode.Text = string.Empty;
                DivEntry.Visible = false;
                DivView.Visible = true;
                TxtGroupName.Text = string.Empty;
                DdlGroupType.SelectedIndex = 0;
                TxtGroupOrder.Text = string.Empty;

                BtncallUpd.Text = "SAVE";
                //btnSave.Text = "SAVE";
                Btncalldel.Visible = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void btnClear_click(object sender, EventArgs e)
        {
            clear();
         //   btnSave.Text = "SAVE";
            lblmsg.Text = string.Empty;
            UserRights();
        }

        protected void btnSave_click(object sender, EventArgs e)
        {
            try
            {
                GROUP_MASLogicLayer insert = new GROUP_MASLogicLayer();
                //insert.GROUP_CODE = TxtGroupCode.Text.Trim().ToUpper();
                insert.GROUP_NAME = TxtGroupName.Text.Trim().ToUpper();
                insert.GROUP_TYPE = DdlGroupType.SelectedValue.Trim().ToUpper();
                insert.GROUP_ORD = TxtGroupOrder.Text.Trim().ToUpper();
                insert.GROUP_CODE = HfGROUP_CODE.Value.Trim();

                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = GROUP_MASLogicLayer.InsertGROUPMASTERDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "MASTER GROUP DETAIL ADD SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "GROUP CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : GROUP MASTER DETAIL NOT SAVED";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    string str = GROUP_MASLogicLayer.UpdateGROUPMASTERDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "GROUP MASTER DETAIL UPDATE SUCCESSFULLY.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already"))
                    {
                        lblmsg.Text = "GROUP CODE ALREADY EXIST.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "ERROR : GROUP MASTER DETAIL NOT SAVED";
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
                Dt = GROUP_MASLogicLayer.GetAllGROUP_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                GvGroupMaster.DataSource = Dt;
                GvGroupMaster.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }



        protected void GvGroupMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Deletea")
                {
                    clear();
                    DataTable dt = GROUP_MASLogicLayer.GetGROUP_CODEWISEGROUP_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;
                        //TxtGroupCode.Text = dt.Rows[0]["GROUP_CODE"].ToString();
                        TxtGroupName.Text = dt.Rows[0]["GROUP_NAME"].ToString();
                        DdlGroupType.SelectedValue = dt.Rows[0]["GROUP_TYPE"].ToString();
                        TxtGroupOrder.Text = dt.Rows[0]["GROUP_ORD"].ToString();
                        HfGROUP_CODE.Value = dt.Rows[0]["GROUP_CODE"].ToString();
                    }

                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    Btncalldel.Visible = true;
                    BtncallUpd.Visible = false;
                    ControllerDisable();
                }

                if (e.CommandName == "Edita")
                {
                    clear();
                    DataTable dt = GROUP_MASLogicLayer.GetGROUP_CODEWISEGROUP_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;
                        //TxtGroupCode.Text = dt.Rows[0]["GROUP_CODE"].ToString();
                        TxtGroupName.Text = dt.Rows[0]["GROUP_NAME"].ToString();
                        DdlGroupType.SelectedValue = dt.Rows[0]["GROUP_TYPE"].ToString();
                        TxtGroupOrder.Text = dt.Rows[0]["GROUP_ORD"].ToString();
                        HfGROUP_CODE.Value = dt.Rows[0]["GROUP_CODE"].ToString();
                    }
                      BtncallUpd.Text = "UPDATE";
                  //  btnSave.Text = "UPDATE";

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

                    btnSave.Visible = true;
                    BtncallUpd.Visible = true;
                    Btncalldel.Visible = false;
                    UserRights();

                }




                if (e.CommandName == "Viewa")
                {

                    clear();
                  
                  DataTable dt = GROUP_MASLogicLayer.GetGROUP_CODEWISEGROUP_MASDetials(e.CommandArgument.ToString());
                   if (dt.Rows.Count > 0)
                   {
               
                        DivEntry.Visible = true;
                        DivView.Visible = false;
                       
                        //TxtGroupCode.Text = dt.Rows[0]["GROUP_CODE"].ToString();
                        TxtGroupName.Text = dt.Rows[0]["GROUP_NAME"].ToString();
                        DdlGroupType.SelectedValue = dt.Rows[0]["GROUP_TYPE"].ToString();
                        TxtGroupOrder.Text = dt.Rows[0]["GROUP_ORD"].ToString();
                        HfGROUP_CODE.Value = dt.Rows[0]["GROUP_CODE"].ToString();
                    }

                    ControllerDisable();
                    btnSave.Visible = false;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = false;
                    UserRights();
                 //   btnDelete.Visible = true;
                 //   btnSave.Text = "UPDATE";

              }
           }

            catch (Exception)
            {

                throw;
            }
        }




        protected void GvGroupMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvGroupMaster.PageIndex = e.NewPageIndex;
                FillGrid();
                clear();
            }
            catch (Exception)
            {


            }
        }

        protected void BtnAdd_OnClick(object sender, EventArgs e)
        {
            try
            {
                clear();
                ControllerEnable();
                UserRights();
                BtncallUpd.Visible = true;
                btnSave.Enabled = true;
                btnSave.Visible = true;
                DivEntry.Visible = true;
                DivView.Visible = false;
            }
            catch (Exception)
            {

            }

        }



        protected void btnDelete_click(object sender, EventArgs e)
        {
            try
            {

                if (HfGROUP_CODE.Value != string.Empty)
                {
                    string str = GROUP_MASLogicLayer.DeleteGROUP_MASDetailsByID(HfGROUP_CODE.Value);
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
                        lblmsg.Text = "Error:Group Master Not Deleted";
                        lblmsg.ForeColor = Color.Red;
                    }
                    clear();
                    FillGrid();
                    UserRights();
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

        protected void Btncalldel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
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
                    GROUP_MASLogicLayer insert = new GROUP_MASLogicLayer();
                    //insert.GROUP_CODE = TxtGroupCode.Text.Trim().ToUpper();
                    insert.GROUP_NAME = TxtGroupName.Text.Trim().ToUpper();
                    insert.GROUP_TYPE = DdlGroupType.SelectedValue.Trim().ToUpper();
                    insert.GROUP_ORD = TxtGroupOrder.Text.Trim().ToUpper();
                    insert.GROUP_CODE = HfGROUP_CODE.Value.Trim();

                    if(BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = GROUP_MASLogicLayer.InsertGROUPMASTERDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "MASTER GROUP DETAIL ADD SUCCESSFULLY.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid();
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "GROUP CODE ALREADY EXIST.";
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
    }
}
