using AddressBook;
using AddressBook.BAL;
using ContactMain.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Contact_ContactAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/LoginPage.aspx");
        }
        #endregion Check Valid User
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if (Request.QueryString["ContactID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";
        if (txtContactName.Text.Trim() == "")
            strErrorMessage += " - Enter Contact Name<br />";
        if (txtAddress.Text.Trim() == "")
            strErrorMessage += " - Enter Address<br />";
        if (txtMobileNo.Text.Trim() == "")
            strErrorMessage += " - Enter MobileNo<br />";
        if (ddlCountryID.SelectedIndex == 0)
            strErrorMessage += "- Select Country<br />";
        if (ddlStateID.SelectedIndex == 0)
            strErrorMessage += "- Select State<br />";
        if (ddlCityID.SelectedIndex == 0)
            strErrorMessage += "- Select City<br />";
        if (ddlContactCategoryID.SelectedIndex == 0)
            strErrorMessage += "- Select ContactCategory<br />";
        if (ddlBloodGroupID.SelectedIndex == 0)
            strErrorMessage += "- Select BloodGroup<br />";
        if (txtTwitter.Text.Trim() == "")
            strErrorMessage += " - Enter Twitter<br />";
        if (txtLinkedIn.Text.Trim() == "")
            strErrorMessage += " - Enter LinkedIn<br />";
        if (txtFacebook.Text.Trim() == "")
            strErrorMessage += " - Enter Facebook<br />";
        if (txtProfession.Text.Trim() == "")
            strErrorMessage += " - Enter Profession<br />";
        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        ContactMainENT entContactMain = new ContactMainENT();


        if (txtContactName.Text.Trim() != "")
            entContactMain.ContactName = txtContactName.Text.Trim();
        if (txtAddress.Text.Trim() != "")
            entContactMain.Address = txtAddress.Text.Trim();
        if (txtMobileNo.Text.Trim() != "")
            entContactMain.MobileNo = txtMobileNo.Text.Trim();
        if (ddlCountryID.SelectedIndex > 0)
            entContactMain.CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        if (ddlStateID.SelectedIndex > 0)
            entContactMain.StateID = Convert.ToInt32(ddlStateID.SelectedValue);
        if (ddlCityID.SelectedIndex > 0)
            entContactMain.CityID = Convert.ToInt32(ddlCityID.SelectedValue);
        if (ddlContactCategoryID.SelectedIndex > 0)
            entContactMain.ContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);
        if (ddlBloodGroupID.SelectedIndex > 0)
            entContactMain.BloodGroupID = Convert.ToInt32(ddlBloodGroupID.SelectedValue);
        if (txtTwitter.Text.Trim() != "")
            entContactMain.Twitter = txtTwitter.Text.Trim();
        if (txtLinkedIn.Text.Trim() != "")
            entContactMain.LinkedIn = txtLinkedIn.Text.Trim();
        if (txtFacebook.Text.Trim() != "")
            entContactMain.Facebook = txtFacebook.Text.Trim();
        if (txtProfession.Text.Trim() != "")
            entContactMain.Profession = txtProfession.Text.Trim();


        #endregion Collect Form Data

        ContactMainBAL balContactMain = new ContactMainBAL();

        if (Request.QueryString["ContactID"] == null)
        {
            if (balContactMain.Insert(entContactMain))
            {
                ClearControls();
                lblErrorMessage.Text = "Data Inserted Successfully";

            }
            else
            {
                lblErrorMessage.Text = balContactMain.Message;

            }
        }
        else
        {
            entContactMain.ContactID = Convert.ToInt32(Request.QueryString["ContactID"]);
            if (balContactMain.Update(entContactMain))
            {
                ClearControls();
                Response.Redirect("~/Admin/Contact/ContactList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balContactMain.Message;

            }
        }
    }
   
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Contact/ContactList.aspx");
    }

    #region FillDropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListCountry(ddlCountryID);
        CommonFillMethods.FillDropDownListStateByCountryID(ddlStateID, Convert.ToInt32(ddlCountryID.SelectedValue.Trim()));
        CommonFillMethods.FillDropDownListCityByStateID(ddlCityID, Convert.ToInt32(ddlStateID.SelectedValue.Trim()));
        CommonFillMethods.FillDropDownListContactCategory(ddlContactCategoryID);
        CommonFillMethods.FillDropDownListBloodGroup(ddlBloodGroupID);
    }

    #endregion FillDropDownList


    #region Clear Controls

    private void ClearControls()
    {
        txtContactName.Text = "";
        txtAddress.Text = "";
        txtMobileNo.Text = "";
        ddlCountryID.SelectedIndex = 0;
        ddlStateID.SelectedIndex = 0;
        ddlCityID.SelectedIndex = 0;
        ddlContactCategoryID.SelectedIndex = 0;
        ddlBloodGroupID.SelectedIndex = 0;
        txtTwitter.Text = "";
        txtLinkedIn.Text = "";
        txtFacebook.Text = "";
        txtProfession.Text = "";
        txtContactName.Focus();
    }

    #endregion Clear Controls

    #region FillControls

    private void FillControls(SqlInt32 ContactID)
    {
        ContactMainENT entContactMain = new ContactMainENT();
        ContactMainBAL balContactMain = new ContactMainBAL();

        entContactMain = balContactMain.SelectByPK(ContactID);

        if (!entContactMain.ContactName.IsNull)
            txtContactName.Text = entContactMain.ContactName.Value.ToString();
        if (!entContactMain.Address.IsNull)
            txtAddress.Text = entContactMain.Address.Value.ToString();
        if (!entContactMain.MobileNo.IsNull)
            txtMobileNo.Text = entContactMain.MobileNo.Value.ToString();
        if (!entContactMain.CountryID.IsNull)
            ddlCountryID.SelectedValue = entContactMain.CountryID.Value.ToString();
        if (!entContactMain.StateID.IsNull)
            ddlStateID.SelectedValue = entContactMain.StateID.Value.ToString();
        if (!entContactMain.CityID.IsNull)
            ddlCityID.SelectedValue = entContactMain.CityID.Value.ToString();
        if (!entContactMain.ContactCategoryID.IsNull)
            ddlContactCategoryID.SelectedValue = entContactMain.ContactCategoryID.Value.ToString();
        if (!entContactMain.BloodGroupID.IsNull)
            ddlBloodGroupID.SelectedValue = entContactMain.BloodGroupID.Value.ToString();
        if (!entContactMain.Twitter.IsNull)
            txtTwitter.Text = entContactMain.Twitter.Value.ToString();
        if (!entContactMain.LinkedIn.IsNull)
            txtLinkedIn.Text = entContactMain.LinkedIn.Value.ToString();
        if (!entContactMain.Facebook.IsNull)
            txtFacebook.Text = entContactMain.Facebook.Value.ToString();
        if (!entContactMain.Profession.IsNull)
            txtProfession.Text = entContactMain.Profession.Value.ToString();
    }

    #endregion FillControls
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountryID.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownListStateByCountryID(ddlStateID, Convert.ToInt32(ddlCountryID.SelectedValue.Trim()));
        }
        else
        {
            CommonFillMethods.FillDropDownListEmpty(ddlStateID, "State");
        }
    }


    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStateID.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownListCityByStateID(ddlCityID, Convert.ToInt32(ddlStateID.SelectedValue.Trim()));
        }
        else
        {
            CommonFillMethods.FillDropDownListEmpty(ddlCityID, "City");
        }
    }
   
   
}