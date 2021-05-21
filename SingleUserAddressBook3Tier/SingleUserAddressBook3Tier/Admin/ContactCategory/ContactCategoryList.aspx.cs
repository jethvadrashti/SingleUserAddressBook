using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ContactCategory_ContactCategoryList : System.Web.UI.Page
{

    #region LoadEvent
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
            FillContactCategoryGridView();
        }
    }
    #endregion LoadEvent


    #region FillContactCategoryGridView
    private void FillContactCategoryGridView()
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        DataTable dtContactCategory = new DataTable();

        dtContactCategory = balContactCategory.SelectAll();

        if (dtContactCategory != null && dtContactCategory.Rows.Count > 0)
        {
            gvContactCategory.DataSource = dtContactCategory;
            gvContactCategory.DataBind();
        }
    }
    #endregion FillContactCategoryGridView

    #region RowCommand
    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
                if (balContactCategory.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillContactCategoryGridView();
                }
                else
                {
                    lblMessage.Text = balContactCategory.Message;
                    divMessage.Visible = true;
                }
            }
        }
    }
    #endregion RowCommand

   
    #region NewButtonEvent
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ContactCategory/ContactCategoryAddEdit.aspx");
    }
    #endregion NewButtonEvent


}