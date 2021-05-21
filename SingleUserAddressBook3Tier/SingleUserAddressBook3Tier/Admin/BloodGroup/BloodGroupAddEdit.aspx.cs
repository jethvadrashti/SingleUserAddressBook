using AddressBook.BAL;
using BloodGroup.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_BloodGroup_BloodGroupAddEdit : System.Web.UI.Page
{
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

            if (Request.QueryString["BloodGroupID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["BloodGroupID"]));
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        #region Server Side Validation

        String strErrorMessage = "";
        if (txtBloodGroup.Text.Trim() == "")
            strErrorMessage += " - Enter BloodGroup<br />";

        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }

        #endregion Server Side Validation

        #region Collect Form Data

        BloodGroupENT entBloodGroup = new BloodGroupENT();

        

        if (txtBloodGroup.Text.Trim() != "")
            entBloodGroup.BloodGroupName = txtBloodGroup.Text.Trim();


        #endregion Collect Form Data

        BloodGroupBAL balBloodGroup = new BloodGroupBAL();

        if (Request.QueryString["BloodGroupID"] == null)
        {
            if (balBloodGroup.Insert(entBloodGroup))
            {
                ClearControls();
                lblErrorMessage.Text = "Data Inserted Successfully";

            }
            else
            {
                lblErrorMessage.Text = balBloodGroup.Message;

            }
        }
        else
        {
            entBloodGroup.BloodGroupID = Convert.ToInt32(Request.QueryString["BloodGroupID"]);
            if (balBloodGroup.Update(entBloodGroup))
            {
                ClearControls();
                Response.Redirect("~/Admin/BloodGroup/BloodGroupList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balBloodGroup.Message;

            }
        }
    }
    #region Clear Controls

    private void ClearControls()
    {
       
        txtBloodGroup.Text = "";


        txtBloodGroup.Focus();
    }

    #endregion Clear Controls

    #region FillControls

    private void FillControls(SqlInt32 BloodGroupID)
    {
        BloodGroupENT entBloodGroup = new BloodGroupENT();
        BloodGroupBAL balBloodGroup = new BloodGroupBAL();

        entBloodGroup = balBloodGroup.SelectByPK(BloodGroupID);

        if (!entBloodGroup.BloodGroupName.IsNull)
            txtBloodGroup.Text = entBloodGroup.BloodGroupName.Value.ToString();



        
    }

    #endregion FillControls



   
     
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/BloodGroup/BloodGroupList.aspx");
    }
}