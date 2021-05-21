using AddressBook.BAL;
using Country.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Country_CountryAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/LoginPage.aspx");
        }
        #endregion Check Valid User

        if (Request.QueryString["CountryID"] != null)
        {
            FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

       

        if (txtCountryName.Text.Trim() == "")
            strErrorMessage += " - Enter Country Name<br />";

        if (txtCountryCode.Text.Trim() == "")
            strErrorMessage += " - Enter Country Code<br />";

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        CountryENT entCountry = new CountryENT();

       

        if (txtCountryName.Text.Trim() != "")
            entCountry.CountryName = txtCountryName.Text.Trim();

        if (txtCountryCode.Text.Trim() != "")
            entCountry.CountryCode = txtCountryCode.Text.Trim();

        #endregion Collect Form Data

        CountryBAL balCountry = new CountryBAL();

        if (Request.QueryString["CountryID"] == null)
        {
            if (balCountry.Insert(entCountry))
            {
                ClearControls();
                lblErrorMessage.Text = "Data Inserted Successfully";
              
            }
            else
            {
                lblErrorMessage.Text = balCountry.Message;
                
            }
        }
        else
        {
            entCountry.CountryID = Convert.ToInt32(Request.QueryString["CountryID"]);
            if (balCountry.Update(entCountry))
            {
                ClearControls();
                Response.Redirect("~/Admin/Country/CountryList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balCountry.Message;
                
            }
        }
    }
    #region Clear Controls

    private void ClearControls()
    {

        txtCountryName.Text = "";
        txtCountryCode.Text = "";

        txtCountryName.Focus();
    }

    #endregion Clear Controls

    #region FillControls

    private void FillControls(SqlInt32 CountryID)
    {
        CountryENT entCountry = new CountryENT();
        CountryBAL balCountry = new CountryBAL();

        entCountry = balCountry.SelectByPK(CountryID);

        if (!entCountry.CountryName.IsNull)
            txtCountryName.Text = entCountry.CountryName.Value.ToString();



        if (!entCountry.CountryCode.IsNull)
            txtCountryCode.Text = entCountry.CountryCode.Value.ToString();
    }

    #endregion FillControls
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Country/CountryList.aspx");
    }
}

    

  