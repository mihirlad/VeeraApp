using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeeraApp
{
    public partial class AccountsMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void clear()
        {
            try
            {
           //   TxtAccCode.Text = string.Empty;
                TxtAccountName.Text = string.Empty;
                TxtAccountShort.Text = string.Empty;
                TxtAccountGroupName.Text = string.Empty;
                TxtBranchName.Text = string.Empty;
                TxtPlaceName.Text = string.Empty;
                TxtRouteName.Text = string.Empty;
                TxtGpsLocation.Text = string.Empty;
                TxtMktgPersonName.Text = string.Empty;
                TxtPyamentPersonName.Text = string.Empty;
                TxtServicePersonName.Text = string.Empty;
                TxtContactPersonName.Text = string.Empty;
                TxtVendorCode.Text = string.Empty;
                TxtAddress1.Text = string.Empty;
                TxtAddress2.Text = string.Empty;
                TxtAddress3.Text = string.Empty;
                TxtCity.Text = string.Empty;
                TxtStateName.Text = string.Empty;
                TxtStateCode.Text = string.Empty;
                TxtCountry.Text = string.Empty;
                TxtCreditAmount.Text = string.Empty;
                TxtCreditDays.Text = string.Empty;
                TxtPhoneO.Text = string.Empty;

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnHODetails_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowModel", "ShowModel()", true);
        }

        protected void BtnExportAccount_Click(object sender, EventArgs e)
        {

        }

        protected void BtnContactDetail_Click(object sender, EventArgs e)
        {

        }

        protected void BtnModalDetail_Click(object sender, EventArgs e)
        {

        }
    }
}