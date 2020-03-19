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
    public partial class UserMaster : System.Web.UI.Page
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
                TxtUserPassword.Attributes["value"] = TxtUserPassword.Text;
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
                //  btnDelete.Visible = false;
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
                        //   btnDelete.Enabled = true;
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
            //TxtUserCode.Text = string.Empty;
            TxtUserName.Enabled = true;
            DdlUserType.Enabled = true;
            DdlUserActive.Enabled = true;
            TxtUserPassword.Enabled = true;


        }

        public void ControllerDisable()
        {
            //TxtUserCode.Text = string.Empty;
            TxtUserName.Enabled = false;
            DdlUserType.Enabled = false;
            DdlUserActive.Enabled = false;
            TxtUserPassword.Enabled = false;


        }

        public void clear()
        {
            try
            {
                btnDelete.Visible = false;
                //TxtUserCode.Text = string.Empty;
                DivEntry.Visible = false;
                DivView.Visible = true;
                TxtUserName.Text = string.Empty;
                DdlUserType.SelectedIndex = 0;
                DdlUserActive.SelectedIndex = 0;
                TxtUserPassword.Attributes["value"] = string.Empty;

                BtncallUpd.Text = "SAVE";
              

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnClear_click(object sender, EventArgs e)
        {
            clear();
          //  btnSave.Text = "SAVE";
            lblmsg.Text = string.Empty;
            UserRights();
        }

        protected void btnSave_click(object sender, EventArgs e)
        {
            try
            {

                USER_MASLogicLayer insert = new USER_MASLogicLayer();
                // insert.USERCODE = TxtUserCode.Text.Trim().ToUpper();
                insert.USERCODE = HfUSER_CODE.Value.Trim();
                insert.USERNAME = TxtUserName.Text.Trim();
                insert.USERPASS = encrypt(TxtUserPassword.Text.Trim());
                insert.USERTYPE = DdlUserType.SelectedValue.Trim().ToUpper();
                insert.ACTIVE = DdlUserActive.SelectedValue.Trim().ToUpper();
                insert.DEACTIVE_DATE = string.Empty;


                if (btnSave.Text.Trim().ToUpper() == "SAVE")
                {
                    string str = USER_MASLogicLayer.InsertUSER_MASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "User Detail Add Successfully.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                    {
                        lblmsg.Text = "User Code already Exist.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "Error : User Detail Not Save";
                        lblmsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    string str = USER_MASLogicLayer.UpdateUSER_MASDetail(insert);
                    if (str.Contains("successfully"))
                    {
                        lblmsg.Text = "User Detail Update Successfully.";
                        lblmsg.ForeColor = Color.Green;
                        clear();
                        FillGrid();
                        UserRights();
                    }
                    else if (str.Contains("Already"))
                    {
                        lblmsg.Text = "User Code already Exist.";
                        lblmsg.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblmsg.Text = "Error : User Detail Not Update";
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
                Dt = USER_MASLogicLayer.GetAllUSER_MASDetials(Convert.ToInt32(Session["USERCODE"].ToString()), Convert.ToInt32(Session["COMP_CODE"].ToString()));
                GvUserMas.DataSource = Dt;
                GvUserMas.DataBind();

            }
            catch (Exception)
            {
                throw;
            }
        }



        protected void GvUserMas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Deletea")
                {
                    clear();
                    DataTable dt = USER_MASLogicLayer.GetAllIDWiseUSER_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;
                        HfUSER_CODE.Value = dt.Rows[0]["USERCODE"].ToString();
                        TxtUserName.Text = dt.Rows[0]["USERNAME"].ToString();
                        TxtUserPassword.Attributes.Add("value", Decrypt(dt.Rows[0]["USERPASS"].ToString()));
                        DdlUserType.SelectedValue = dt.Rows[0]["USERTYPE"].ToString();
                        DdlUserActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                        //TxtDeActivateDate.Text = dt.Rows[0]["DEACTIVE_DATE"].ToString();
                    }

                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    Btncalldel.Visible = true;
                    BtncallUpd.Visible = false;
                    ControllerDisable();
                }


                if (e.CommandName == "Edita")
                {
                    #region EDIT

                    clear();
                    DataTable dt = USER_MASLogicLayer.GetAllIDWiseUSER_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;
                        HfUSER_CODE.Value = dt.Rows[0]["USERCODE"].ToString();
                        TxtUserName.Text = dt.Rows[0]["USERNAME"].ToString();
                        //TxtUserPassword.Attributes["value"] = Decrypt(dt.Rows[0]["USERPASS"].ToString());
                        //TxtUserPassword.Text= Decrypt(dt.Rows[0]["USERPASS"].ToString());
                        TxtUserPassword.Attributes.Add("value", Decrypt(dt.Rows[0]["USERPASS"].ToString()));
                        DdlUserType.SelectedValue = dt.Rows[0]["USERTYPE"].ToString();
                        DdlUserActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                        //TxtDeActivateDate.Text = dt.Rows[0]["DEACTIVE_DATE"].ToString();

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
                    btnSave.Visible = true;
                    Btncalldel.Visible = false;
                    BtncallUpd.Visible = true;
                    UserRights();
                }


                if (e.CommandName == "Viewa")
                {
                    clear();


                    DataTable dt = USER_MASLogicLayer.GetAllIDWiseUSER_MASDetials(e.CommandArgument.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        DivEntry.Visible = true;
                        DivView.Visible = false;
                        HfUSER_CODE.Value = dt.Rows[0]["USERCODE"].ToString();
                        TxtUserName.Text = dt.Rows[0]["USERNAME"].ToString();
                        TxtUserPassword.Attributes.Add("value", Decrypt(dt.Rows[0]["USERPASS"].ToString()));
                        DdlUserType.SelectedValue = dt.Rows[0]["USERTYPE"].ToString();
                        DdlUserActive.SelectedValue = dt.Rows[0]["ACTIVE"].ToString();
                        //TxtDeActivateDate.Text = dt.Rows[0]["DEACTIVE_DATE"].ToString();

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



        protected void GvUserMas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvUserMas.PageIndex = e.NewPageIndex;
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
                Btncalldel.Visible = false;
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


        protected void btnDelete_click(object sender, EventArgs e)
        {
            try
            {
                if (HfUSER_CODE.Value != string.Empty)
                {
                    string str = USER_MASLogicLayer.DeleteUSER_MASDetailsByID(HfUSER_CODE.Value);
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
                        lblmsg.Text = "Error:User Not Deleted";
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

        protected void BtnExit_Click(object sender, EventArgs e)
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
                if(BtncallUpd.Text == "UPDATE")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel1", "ShowModel1()", true);
                }
                else
                {
                    USER_MASLogicLayer insert = new USER_MASLogicLayer();
                    // insert.USERCODE = TxtUserCode.Text.Trim().ToUpper();
                    insert.USERCODE = HfUSER_CODE.Value.Trim();
                    insert.USERNAME = TxtUserName.Text.Trim();
                    insert.USERPASS = encrypt(TxtUserPassword.Text.Trim());
                    insert.USERTYPE = DdlUserType.SelectedValue.Trim().ToUpper();
                    insert.ACTIVE = DdlUserActive.SelectedValue.Trim().ToUpper();
                    insert.DEACTIVE_DATE = string.Empty;

                    if(BtncallUpd.Text.Trim().ToUpper() == "SAVE")
                    {
                        string str = USER_MASLogicLayer.InsertUSER_MASDetail(insert);
                        if (str.Contains("successfully"))
                        {
                            lblmsg.Text = "User Detail Add Successfully.";
                            lblmsg.ForeColor = Color.Green;
                            clear();
                            FillGrid();
                            UserRights();
                        }
                        else if (str.Contains("Already") || str.Contains("PRIMARY KEY"))
                        {
                            lblmsg.Text = "User Code already Exist.";
                            lblmsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblmsg.Text = "Error : User Detail Not Save";
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

        //protected void GvUserMas_DataBound(object sender, EventArgs e)
        //{
        //    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        //    for (int i = 0; i < GvUserMas.Columns.Count; i++)
        //    {
        //        TableHeaderCell cell = new TableHeaderCell();
        //        TextBox txtSearch = new TextBox();
        //        txtSearch.BackColor = Color.Pink;
                
        //        txtSearch.Style.Add("color", "black");
        //        //txtSearch.Attributes["placeholder"] = GvUserMas.Columns[i].HeaderText;
        //        txtSearch.CssClass = "search_textbox";
        //        cell.Controls.Add(txtSearch);
        //        row.Controls.Add(cell);
        //    }
        //    GvUserMas.HeaderRow.Parent.Controls.AddAt(1, row);
        //}
    }
}
