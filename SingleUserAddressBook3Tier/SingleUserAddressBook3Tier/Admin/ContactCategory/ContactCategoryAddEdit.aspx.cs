using AddressBook.BAL;
using ContactCategory.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
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


            if (Request.QueryString["ContactCategoryID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";
        if (txtContactCategory.Text.Trim() == "")
            strErrorMessage += " - Enter ContactCategory<br />";

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        ContactCategoryENT entContactCategory = new ContactCategoryENT();



        if (txtContactCategory.Text.Trim() != "")
            entContactCategory.ContactCategory = txtContactCategory.Text.Trim();


        #endregion Collect Form Data

        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        if (Request.QueryString["ContactCategoryID"] == null)
        {
            if (balContactCategory.Insert(entContactCategory))
            {
                ClearControls();
                lblErrorMessage.Text = "Data Inserted Successfully";

            }
            else
            {
                lblErrorMessage.Text = balContactCategory.Message;

            }
        }
        else
        {
            entContactCategory.ContactCategoryID = Convert.ToInt32(Request.QueryString["ContactCategoryID"]);
            if (balContactCategory.Update(entContactCategory))
            {
                ClearControls();
                Response.Redirect("~/Admin/ContactCategory/ContactCategoryList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balContactCategory.Message;

            }
        }
    }
    #region Clear Controls

    private void ClearControls()
    {

        txtContactCategory.Text = "";


        txtContactCategory.Focus();
    }

    #endregion Clear Controls

    #region FillControls

    private void FillControls(SqlInt32 ContactCategoryID)
    {
        ContactCategoryENT entContactCategory = new ContactCategoryENT();
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();


        entContactCategory = balContactCategory.SelectByPK(ContactCategoryID);

        if (!entContactCategory.ContactCategory.IsNull)
            txtContactCategory.Text = entContactCategory.ContactCategory.Value.ToString();




    }

    #endregion FillControls


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ContactCategory/ContactCategoryList.aspx");
    }
}