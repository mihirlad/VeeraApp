using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Veera.LogicLayer;

namespace VeeraApp.Admin
{
    public partial class Main : System.Web.UI.MasterPage
    {
        static DataTable DtMenu;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                    LblUser.Text = Session["USERNAME"].ToString();
                    DateTime dt = Convert.ToDateTime(Session["FIN_YEAR"]);
                    lblheader.Text = Session["COMP_NAME"].ToString() + " : " + dt.Year + "-" + (dt.Year + 1) + " " + "{" + Session["USERNAME"].ToString().ToUpper() + " : " + Session["BRANCH_NAME"].ToString() + "}";
                    DtMenu = USERLOGINLogicLayer.GetMenuWithNullREF_CODE();
                    if (DtMenu != null)
                    {
                        if (DtMenu.Rows.Count > 0)
                        {
                            FillMenu();
                        }
                    }
                    else
                    {
                        DtMenu = USERLOGINLogicLayer.GetMenuWithNullREF_CODE();
                        if (DtMenu != null)
                        {
                            if (DtMenu.Rows.Count > 0)
                            {
                                FillMenu();
                            }
                        }
                        else
                        { Response.Redirect("../Login.aspx"); }
                    }
                }
                else
                { Response.Redirect("../Login.aspx"); }

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public void FillMenu()
        {
            try
            {
                DataView Dv = new DataView(DtMenu);
                Dv.RowFilter = "REF_CODE IS NULL";

                DataTable Dt = Dv.ToTable();// USERLOGINLogicLayer.GetMenuWithNullREF_CODE();
                RptMenu.DataSource = Dt;
                RptMenu.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void RptMenu_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfcode = e.Item.FindControl("HfRefCode") as HiddenField;
                Repeater rptSubMenu = e.Item.FindControl("rptChildMenu") as Repeater;

                HiddenField HfMENU_NAME = e.Item.FindControl("HfMENU_NAME") as HiddenField;
                HtmlGenericControl Ul = e.Item.FindControl("ulRptMenu") as HtmlGenericControl;

                if (HfMENU_NAME.Value == "#")
                {
                    DataView Dv = new DataView(DtMenu);
                    Dv.RowFilter = "REF_CODE=" + hfcode.Value;

                    rptSubMenu.DataSource = Dv.ToTable();// USERLOGINLogicLayer.GetSubMenuWithNullREF_CODE(hfcode.Value);//((System.Data.DataRowView)(e.Item.DataItem)).Row[0].ToString());
                    rptSubMenu.DataBind();
                }
                else
                {
                    Ul.Visible = false;
                }
            }
        }

        protected void rptChildMenu_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfcode = e.Item.FindControl("HfChildRefCode") as HiddenField;
                Repeater rptSubMenu = e.Item.FindControl("rptSubChildMenu") as Repeater;

                HiddenField HfMENU_NAME = e.Item.FindControl("HfMENU_NAME") as HiddenField;
                HtmlGenericControl Ul = e.Item.FindControl("ulrptChildMenu") as HtmlGenericControl;

                if (HfMENU_NAME.Value == "#")
                {
                    DataView Dv = new DataView(DtMenu);
                    Dv.RowFilter = "REF_CODE=" + hfcode.Value;

                    rptSubMenu.DataSource = Dv.ToTable();// USERLOGINLogicLayer.GetSubMenuWithNullREF_CODE(hfcode.Value);//((System.Data.DataRowView)(e.Item.DataItem)).Row[0].ToString());
                    rptSubMenu.DataBind();
                }
                else
                {
                    Ul.Visible = false;
                }
            }
        }

        protected void rptSubChildMenu_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfcode = e.Item.FindControl("HfSubChildRefCode") as HiddenField;
                Repeater rptSubMenu = e.Item.FindControl("rptSubChildInnerMenu") as Repeater;

                HiddenField HfMENU_NAME = e.Item.FindControl("HfMENU_NAME") as HiddenField;
                HtmlGenericControl Ul = e.Item.FindControl("ulrptSubChildMenu") as HtmlGenericControl;

                if (HfMENU_NAME.Value == "#")
                {
                    DataView Dv = new DataView(DtMenu);
                    Dv.RowFilter = "REF_CODE=" + hfcode.Value;

                    rptSubMenu.DataSource = Dv.ToTable();//USERLOGINLogicLayer.GetSubMenuWithNullREF_CODE(hfcode.Value);//((System.Data.DataRowView)(e.Item.DataItem)).Row[0].ToString());
                    rptSubMenu.DataBind();
                }
                else
                {
                    Ul.Visible = false;
                }

            }
        }

        protected void lnkbtnLogOut_OnClick(object sender, EventArgs e)
        {
            try
            {
                Session["USERCODE"] = null;
                Session["USERNAME"] = null;
                Session["COMP_CODE"] = null;
                Session["COMP_NAME"] = null;
                Session["BRANCH_CODE"] = null;
                Session["BRANCH_NAME"] = null;
                Session["BRANCH_TYPE"] = null;
                Session["FIN_YEAR"] = null;
                Session["MAC"] = null;
                Session["PC"] = null;
                Session["INSERT"] = null;
                Session["UPDATE"] = null;
                Session["DELETE"] = null;

                Response.Redirect("../Login.aspx");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}