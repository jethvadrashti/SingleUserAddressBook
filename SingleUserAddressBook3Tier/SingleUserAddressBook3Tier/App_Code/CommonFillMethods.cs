using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonFillMethods
/// </summary>
namespace AddressBook
{
    public class CommonFillMethods
    {
        public CommonFillMethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static void FillDropDownListCountry(DropDownList ddlCountryID)
        {
            ContactMainBAL balContactMain = new ContactMainBAL();
            ddlCountryID.DataSource = balContactMain.SelectForDropdownListCountry();
            ddlCountryID.DataValueField = "CountryID";
            ddlCountryID.DataTextField = "CountryName";
            ddlCountryID.DataBind();
            ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));
        }
        public static void FillDropDownListContactCategory(DropDownList ddlContactCategory)
        {
            ContactMainBAL balContactMain = new ContactMainBAL();
            ddlContactCategory.DataSource = balContactMain.SelectForDropdownListContactCategory();
            ddlContactCategory.DataValueField = "ContactCategoryID";
            ddlContactCategory.DataTextField = "ContactCategory";
            ddlContactCategory.DataBind();
            ddlContactCategory.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));
        }
        public static void FillDropDownListBloodGroup(DropDownList ddlBloodGroupID)
        {
            ContactMainBAL balContactMain = new ContactMainBAL();
            ddlBloodGroupID.DataSource = balContactMain.SelectForDropdownListBloodGroup();
            ddlBloodGroupID.DataValueField = "BloodGroupID";
            ddlBloodGroupID.DataTextField = "BloodGroupName";
            ddlBloodGroupID.DataBind();
            ddlBloodGroupID.Items.Insert(0, new ListItem("Select BloodGroup", "-1"));
        }
        public static void FillDropDownListState(DropDownList ddlCountryID)
        {
            StateBAL balState = new StateBAL();
            ddlCountryID.DataSource = balState.SelectForDropdownList();
            ddlCountryID.DataValueField = "StateID";
            ddlCountryID.DataTextField = "StateName";
            ddlCountryID.DataBind();
            ddlCountryID.Items.Insert(0, new ListItem("Select State", "-1"));
        }

        public static void FillDropDownListCity(DropDownList ddlStateID)
        {
            CityBAL balCity = new CityBAL();
            ddlStateID.DataSource = balCity.SelectForDropdownList();
            ddlStateID.DataValueField = "CityID";
            ddlStateID.DataTextField = "CityName";
            ddlStateID.DataBind();
            ddlStateID.Items.Insert(0, new ListItem("Select City", "-1"));
        }
        public static void FillDropDownListStateByCountryID(DropDownList ddlStateID, SqlInt32 CountryID)
        {
            StateBAL balState = new StateBAL();
            ddlStateID.DataSource = balState.SelectForDropdownListByCountryID(CountryID);
            ddlStateID.DataValueField = "StateID";
            ddlStateID.DataTextField = "StateName";
            ddlStateID.DataBind();
            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
        }
        public static void FillDropDownListCityByStateID(DropDownList ddlCityID, SqlInt32 StateID)
        {
            CityBAL balCity = new CityBAL();
            ddlCityID.DataSource = balCity.SelectForDropdownListByStateID(StateID);
            ddlCityID.DataValueField = "CityID";
            ddlCityID.DataTextField = "CityName";
            ddlCityID.DataBind();
            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
        }

        public static void FillDropDownListEmpty(DropDownList ddl, String DropDownListName)
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("Select " + DropDownListName, "-1"));
        }
    }
}