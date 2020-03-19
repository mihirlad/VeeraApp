using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veera.LogicLayer;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace VeeraApp.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    try
                    {
                        //Session["USERCODE"] = "1";
                        //Session["USERNAME"] = "mihir";//"admin";
                        //Session["USERTYPE"] = "O";
                        //Session["COMP_CODE"] = "506";
                        //Session["COMP_NAME"] = "VEERA PIPE & FITTING";
                        //Session["WORK_VIEWFLAG"] = "I";
                        //Session["BRANCH_CODE"] = "511";
                        //Session["BRANCH_NAME"] = "LAVACHHA";
                        //Session["BRANCH_TYPE"] = "B";
                        //Session["FIN_YEAR"] = "01-04-2018 00:00:00";
                        //Session["FIN_YEAR_END"] = "31-03-2019 00:00:00";
                        //Session["MAC"] = "588A5A22820E";
                        //Session["PC"] = "Dell";
                        //Session["INSERT"] = "Y";
                        //Session["UPDATE"] = "Y";
                        //Session["DELETE"] = "Y";

                        Session["USERCODE"] = "2";// "1";
                        Session["USERNAME"] = "admin";//  "mihir";
                        Session["USERTYPE"] = "A";// "O";
                        Session["COMP_CODE"] = "101";
                        Session["COMP_NAME"] = "VEERA COMPRESSOR";
                        Session["WORK_VIEWFLAG"] = "B";
                        Session["INVTYPE_FLAG"] = "T";
                        Session["BRANCH_CODE"] = "508"; //"510";
                        Session["BRANCH_NAME"] = "LAVACHHA";//"VAPI";
                        Session["BRANCH_TYPE"] = "B";
                        Session["FIN_YEAR"] = "01-04-2019 00:00:00";
                        Session["FIN_YEAR_END"] = "31-03-2020 00:00:00";
                        Session["MAC"] = "588A5A22820E";
                        Session["PC"] = "Dell";
                        Session["INSERT"] = "Y";
                        Session["UPDATE"] = "Y";
                        Session["DELETE"] = "Y";



                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select Convert(varchar(100),COMP_CODE)+SCREEN_PATH from company where comp_code = '" + Session["COMP_CODE"].ToString() + "'", con);

                        imgdash.ImageUrl = "~/Admin/Company/SCREEN/" + cmd.ExecuteScalar().ToString(); //+ ".jpg";

                        
                    }
                    catch (Exception)
                    {

                        throw;
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