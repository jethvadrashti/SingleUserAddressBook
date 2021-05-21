using AddressBook;
using AddressBook.BAL;
using State.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_State_StateAddEdit : System.Web.UI.Page
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

            if (Request.QueryString["StateID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["StateID"]));
            }
        }
    }
    

    #region FillDropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListCountry(ddlCountryID);
        //CommonFillMethods.FillDropDownListCity(ddl);
    }

    #endregion FillDropDownList

    #region Clear Controls

    private void ClearControls()
    {
        ddlCountryID.SelectedIndex = 0;
        txtStateName.Text = "";


        ddlCountryID.Focus();
    }

    #endregion Clear Controls

    #region FillControls

    private void FillControls(SqlInt32 StateID)
    {
        StateENT entState = new StateENT();
        StateBAL balState = new StateBAL();

        entState = balState.SelectByPK(StateID);

        if (!entState.StateName.IsNull)
            txtStateName.Text = entState.StateName.Value.ToString();



        if (!entState.CountryID.IsNull)
            ddlCountryID.SelectedValue = entState.CountryID.Value.ToString();
    }

    #endregion FillControls

    

    #region CancelButtonEvent
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/State/StateList.aspx");
    }
    #endregion CancelButtonEvent


    #region SaveButtonEvent
    protected void btnSave_Click1(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (ddlCountryID.SelectedIndex == 0)
            strErrorMessage += "- Select Country<br />";

        if (txtStateName.Text.Trim() == "")
            strErrorMessage += " - Enter State Name<br />";

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        StateENT entState = new StateENT();

        if (ddlCountryID.SelectedIndex > 0)
            entState.CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);

        if (txtStateName.Text.Trim() != "")
            entState.StateName = txtStateName.Text.Trim();


        #endregion Collect Form Data

        StateBAL balState = new StateBAL();

        if (Request.QueryString["StateID"] == null)
        {
            if (balState.Insert(entState))
            {
                ClearControls();
                lblErrorMessage.Text = "Data Inserted Successfully";

            }
            else
            {
                lblErrorMessage.Text = balState.Message;

            }
        }
        else
        {
            entState.StateID = Convert.ToInt32(Request.QueryString["StateID"]);
            if (balState.Update(entState))
            {
                ClearControls();
                Response.Redirect("~/Admin/State/StateList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balState.Message;

            }
        }
    }
    #endregion SaveButtonEvent

}