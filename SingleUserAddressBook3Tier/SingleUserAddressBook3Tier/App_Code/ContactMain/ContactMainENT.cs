using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactMainENT
/// </summary>
namespace ContactMain.ENT
{
    public class ContactMainENT
    {
        public ContactMainENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region ContactID
        protected SqlInt32 _ContactID;

        public SqlInt32 ContactID
        {
            get
            {
                return _ContactID;
            }
            set
            {
                _ContactID = value;
            }
        }
        #endregion ContactID

        #region ContactName

        protected SqlString _ContactName;

        public SqlString ContactName
        {
            get
            {
                return _ContactName;
            }
            set
            {
                _ContactName = value;
            }
        }


        #endregion CityName

        #region MobileNo

        protected SqlString _MobileNo;

        public SqlString MobileNo
        {
            get
            {
                return _MobileNo;
            }
            set
            {
                _MobileNo = value;
            }
        }
        #endregion MobileNo

        #region Address

        protected SqlString _Address;
        public SqlString Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        #endregion Address

        #region CityID

        protected SqlInt32 _CityID;

        public SqlInt32 CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }


        #endregion StateID

        #region StateID

        protected SqlInt32 _StateID;

        public SqlInt32 StateID
        {
            get
            {
                return _StateID;
            }
            set
            {
                _StateID = value;
            }
        }


        #endregion StateID

        #region CountryID
        protected SqlInt32 _CountryID;

        public SqlInt32 CountryID
        {
            get
            {
                return _CountryID;
            }
            set
            {
                _CountryID = value;
            }
        }
        #endregion CountryID

        #region ContactCategoryID
        protected SqlInt32 _ContactCategoryID;
        public SqlInt32 ContactCategoryID
        {
            get
            {
                return _ContactCategoryID;
            }
            set
            {
                _ContactCategoryID = value;
            }
        }
        #endregion ContactCategoryID

        #region BloodGroupID
        protected SqlInt32 _BloodGroupID;

        public SqlInt32 BloodGroupID
        {
            get
            {
                return _BloodGroupID;
            }
            set
            {
                _BloodGroupID = value;
            }
        }
        #endregion BloodGroupID

        #region Twitter
        protected SqlString _Twitter;
        public SqlString Twitter
        {
            get
            {
                return _Twitter;
            }
            set
            {
                _Twitter = value;
            }
        }
        #endregion Twitter

        #region LinkedIn
        protected SqlString _LinkedIn;

        public SqlString LinkedIn
        {
            get
            {
                return _LinkedIn;
            }
            set
            {
                _LinkedIn = value;
            }
        }
        #endregion LinkedIn

        #region Facebook

        protected SqlString _Facebook;

        public SqlString Facebook
        {
            get
            {
                return _Facebook;
            }
            set
            {
                _Facebook = value;
            }
        }
        #endregion Facebook

        #region Profession
        protected SqlString _Profession;

        public SqlString Profession
        {
            get
            {
                return _Profession;
            }
            set
            {
                _Profession = value;
            }
        }

        #endregion Profession
    }
}