using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CityList : System.Web.UI.Page
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
            FillCityGridView();
        }
    }
    #endregion LoadEvent


    #region FillCityGridView
    private void FillCityGridView()
    {
        CityBAL balCity = new CityBAL();
        DataTable dtCity = new DataTable();

        dtCity = balCity.SelectAll();

        if (dtCity != null && dtCity.Rows.Count > 0)
        {
            gvCity.DataSource = dtCity;
            gvCity.DataBind();
        }
    }
    #endregion FillCityGridView


    #region Onrowcommand
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                CityBAL balCity = new CityBAL();
                if (balCity.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillCityGridView();
                }
                else
                {
                    lblMessage.Text = balCity.Message;
                    divMessage.Visible = true;
                }
            }
        }
    }
    #endregion Onrowcommand

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/City/CityAddEdit.aspx");
    }
}