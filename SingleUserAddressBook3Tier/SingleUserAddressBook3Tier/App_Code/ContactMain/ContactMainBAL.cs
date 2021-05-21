using AddressBook.DAL;
using ContactMain.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactMainBAL
/// </summary>
namespace AddressBook.BAL
{
    public class ContactMainBAL
    {
        public ContactMainBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Local Variable

        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Local Variable

        #region Insert Operation
        public Boolean Insert(ContactMainENT entContactMain)
        {
            ContactMainDAL dalContactMain = new ContactMainDAL();
            if (dalContactMain.Insert(entContactMain))
            {
                return true;
            }
            else
            {
                Message = dalContactMain.Message;
                return false;
            }
        }

        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(ContactMainENT entContactMain)
        {
            ContactMainDAL dalContactMain = new ContactMainDAL();
            if (dalContactMain.Update(entContactMain))
            {
                return true;
            }
            else
            {
                Message = dalContactMain.Message;
                return false;
            }
        }

        #endregion Update Operation

        #region Delete Operation

        public Boolean Delete(SqlInt32 ContactID)
        {
            ContactMainDAL dalContactMain = new ContactMainDAL();

            if (dalContactMain.Delete(ContactID))
            {
                return true;
            }
            else
            {
                Message = dalContactMain.Message;
                return false;
            }
        }

        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            ContactMainDAL dalContactMain = new ContactMainDAL();
            return dalContactMain.SelectAll();
        }
        #endregion SelectAll


        #region SelectByPK
        public ContactMainENT SelectByPK(SqlInt32 ContactID)
        {
            ContactMainDAL dalContactMain = new ContactMainDAL();
            return dalContactMain.SelectByPK(ContactID);
        }
        #endregion SelectByPK

        #region SelectByDropdownList
        public DataTable SelectForDropdownListCountry()
        {
            ContactMainDAL dalContactMain = new ContactMainDAL();
            return dalContactMain.SelectForDropdownListCountry();
        }
        public DataTable SelectForDropdownListByStateID(SqlInt32 StateID)
        {
            ContactMainDAL dalContactMain = new ContactMainDAL();
            return dalContactMain.SelectForDropdownListByStateID(StateID);
        }
        public DataTable SelectForDropdownListByCountryID(SqlInt32 CountryID)
        {
            ContactMainDAL dalContactMain = new ContactMainDAL();
            return dalContactMain.SelectForDropdownListByCountryID(CountryID);
        }
        public DataTable SelectForDropdownListContactCategory()
        {
            ContactMainDAL dalContactMain = new ContactMainDAL();
            return dalContactMain.SelectForDropdownListContactCategory();
        }
        public DataTable SelectForDropdownListBloodGroup()
        {
            ContactMainDAL dalContactMain = new ContactMainDAL();
            return dalContactMain.SelectForDropdownListBloodGroup();
        }
        
        #endregion SelectByDropdownList


        #endregion Select Operation



    }

}