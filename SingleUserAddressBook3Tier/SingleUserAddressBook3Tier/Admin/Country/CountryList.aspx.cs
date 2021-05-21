using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Country_CountryList : System.Web.UI.Page
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
            FillCountryGridView();
        }
    }
    #endregion LoadEvent

    #region FillCountryGridView
    private void FillCountryGridView()
    {
        CountryBAL balCountry = new CountryBAL();
        DataTable dtCountry = new DataTable();

        dtCountry = balCountry.SelectAll();

        if (dtCountry != null && dtCountry.Rows.Count > 0)
        {
            gvCountry.DataSource = dtCountry;
            gvCountry.DataBind();
        }
    }
    #endregion FillCountryGridView

    #region NewButtonEvent
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Country/CountryAddEdit.aspx");
    }
    #endregion NewButtonEvent

    #region RowCommand
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                CountryBAL balCountry = new CountryBAL();
                if (balCountry.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillCountryGridView();
                }
                else
                {
                    lblMessage.Text = balCountry.Message;
                    divMessage.Visible = true;
                }
            }
        }
    }
    #endregion RowCommand
}