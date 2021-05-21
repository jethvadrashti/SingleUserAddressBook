using AddressBook;
using AddressBook.BAL;
using City.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_City_CityAddEdit : System.Web.UI.Page
{
   
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            #region Check Valid User
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/LoginPage.aspx");
            }
            #endregion Check Valid User
            FillDropDownList();

            if (Request.QueryString["CityID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["CityID"]));
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (ddlStateID.SelectedIndex == 0)
            strErrorMessage += "- Select State<br />";

        if (txtCityName.Text.Trim() == "")
            strErrorMessage += " - Enter City Name<br />";

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        CityENT entCity = new CityENT();

        if (ddlStateID.SelectedIndex > 0)
            entCity.StateID = Convert.ToInt32(ddlStateID.SelectedValue);

        if (txtCityName.Text.Trim() != "")
            entCity.CityName = txtCityName.Text.Trim();

   
        #endregion Collect Form Data

        CityBAL balCity = new CityBAL();

        if (Request.QueryString["CityID"] == null)
        {
            if (balCity.Insert(entCity))
            {
                ClearControls();
                lblErrorMessage.Text = "Data Inserted Successfully";
                
            }
            else
            {
                lblErrorMessage.Text = balCity.Message;
               
            }
        }
        else
        {
            entCity.CityID = Convert.ToInt32(Request.QueryString["CityID"]);
            if (balCity.Update(entCity))
            {
                ClearControls();
                Response.Redirect("~/Admin/City/CityList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balCity.Message;
                
            }
        }
    }
    #endregion Button : Save

    #region FillDropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListState(ddlStateID);
        //CommonFillMethods.FillDropDownListCity(ddl);
    }

    #endregion FillDropDownList

    #region Clear Controls

    private void ClearControls()
    {
        ddlStateID.SelectedIndex = 0;
        txtCityName.Text = "";


        ddlStateID.Focus();
    }

    #endregion Clear Controls

    #region FillControls

    private void FillControls(SqlInt32 CityID)
    {
        CityENT entCity = new CityENT();
        CityBAL balCity = new CityBAL();

        entCity = balCity.SelectByPK(CityID);

        if (!entCity.CityName.IsNull)
            txtCityName.Text = entCity.CityName.Value.ToString();



        if (!entCity.StateID.IsNull)
            ddlStateID.SelectedValue = entCity.StateID.Value.ToString();
    }

    #endregion FillControls



    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/City/CityList.aspx");
    }
}