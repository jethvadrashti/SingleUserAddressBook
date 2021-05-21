using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_BloodGroup_BloodGroupList : System.Web.UI.Page
{
    #region Load Event
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
            FillBloodGroupGridView();
        }
    }
    #endregion Load Event
    #region FillBloodGridView
         private void FillBloodGroupGridView()
        {
            BloodGroupBAL balBloodGroup = new BloodGroupBAL();
            DataTable dtBloodGroup = new DataTable();

            dtBloodGroup = balBloodGroup.SelectAll();

            if (dtBloodGroup != null && dtBloodGroup.Rows.Count > 0)
            {
                gvBloodGroup.DataSource = dtBloodGroup;
                gvBloodGroup.DataBind();
            }
        }
    #endregion FillBloodGridView

    #region RowCommand
    protected void gvBloodGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                CityBAL balBlood = new CityBAL();
                if (balBlood.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillBloodGroupGridView();
                }
                else
                {
                    lblMessage.Text = balBlood.Message;
                  
                }
            }
        }
    }
    #endregion RowCommand


    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/BloodGroup/BloodGroupAddEdit.aspx");
    }
}