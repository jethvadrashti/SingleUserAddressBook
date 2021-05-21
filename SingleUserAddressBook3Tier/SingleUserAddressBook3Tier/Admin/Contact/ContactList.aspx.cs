using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Contact_ContactList : System.Web.UI.Page
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
            FillContactGridView();
        }
    }
    #endregion LoadEvent

    #region FillContactGridView
    private void FillContactGridView()
    {
        ContactMainBAL balContact = new ContactMainBAL();
        DataTable dtContact = new DataTable();

        dtContact = balContact.SelectAll();

        if (dtContact != null && dtContact.Rows.Count > 0)
        {
            gvContact.DataSource = dtContact;
            gvContact.DataBind();
        }
    }
    #endregion FillContactGridView

    #region RowCommand
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                ContactMainBAL balContact = new ContactMainBAL();
                if (balContact.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillContactGridView();
                }
                else
                {
                    lblMessage.Text = balContact.Message;
                    divMessage.Visible = true;
                }
            }
        }
    }
    #endregion RowCommand

    #region NewButtonEvent
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Contact/ContactAddEdit.aspx");
    }

    #endregion NewButtonEvent

}