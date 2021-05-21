using ContactMain.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactMainDAL
/// </summary>
namespace AddressBook.DAL
{
    public class ContactMainDAL:DatabaseConfig
    {
        public ContactMainDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Local Variable

        protected String _Message;

        public String Message
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
            using (SqlConnection objCon = new SqlConnection(ConnectionString))
            {
                objCon.Open();
                try
                {
                    using (SqlCommand objCmd = objCon.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PK_ContactTable_Insert3TierSingle";
                        objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = entContactMain.ContactName;
                        objCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = entContactMain.MobileNo;
                        objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = entContactMain.Address;
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value= entContactMain.CountryID;
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entContactMain.StateID;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entContactMain.CityID;
                        objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = entContactMain.ContactCategoryID;
                        objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = entContactMain.BloodGroupID;
                        objCmd.Parameters.Add("@Twitter", SqlDbType.VarChar).Value = entContactMain.Twitter;
                        objCmd.Parameters.Add("@LinkedIn", SqlDbType.VarChar).Value = entContactMain.LinkedIn;
                        objCmd.Parameters.Add("@Facebook", SqlDbType.VarChar).Value = entContactMain.Facebook;
                        objCmd.Parameters.Add("@Profession", SqlDbType.VarChar).Value = entContactMain.Profession;
                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["@ContactID"] != null)
                            entContactMain.ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);
                        return true;
                        #endregion Prepare Command
                    }
                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return false;
                }
            }
        }

      

        #endregion Insert Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 ContactID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PK_ContactTable_DeleteByID";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();


                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return false;
                    }
                }
            }
        }

        #endregion Delete Operation

        #region Update Operation
        public Boolean Update(ContactMainENT entContactMain)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PK_ContactTable_UpdateByPK_3tier";
                        objCmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = entContactMain.ContactID;
                        objCmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = entContactMain.ContactName;
                        objCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = entContactMain.MobileNo;
                        objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = entContactMain.Address;
                        objCmd.Parameters.Add("@CountryID",SqlDbType.Int).Value = entContactMain.CountryID;
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entContactMain.StateID;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entContactMain.CityID;
                        objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = entContactMain.ContactCategoryID;
                        objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = entContactMain.BloodGroupID;
                        objCmd.Parameters.Add("@Twitter", SqlDbType.VarChar).Value = entContactMain.Twitter;
                        objCmd.Parameters.Add("@LinkedIn", SqlDbType.VarChar).Value = entContactMain.LinkedIn;
                        objCmd.Parameters.Add("@Facebook", SqlDbType.VarChar).Value = entContactMain.Facebook;
                        objCmd.Parameters.Add("@Profession", SqlDbType.VarChar).Value = entContactMain.Profession;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return false;
                    }
                }
            }
        }

        #endregion Update Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactTable_Jon";
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        #endregion SelectAll

        #region SelectByPK
        public ContactMainENT SelectByPK(SqlInt32 ContactID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_Table_SelectByPKJoin3tier";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        ContactMainENT entContactMain = new ContactMainENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactID"].Equals(DBNull.Value))
                                {
                                    entContactMain.ContactID = Convert.ToInt32(objSDR["ContactID"]);
                                }
                                if (!objSDR["ContactName"].Equals(DBNull.Value))
                                {
                                    entContactMain.ContactName = Convert.ToString(objSDR["ContactName"]);
                                }
                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                {
                                    entContactMain.MobileNo = Convert.ToString(objSDR["MobileNo"]);
                                }
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                {
                                    entContactMain.Address = Convert.ToString(objSDR["Address"]);
                                }
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    entContactMain.CountryID = Convert.ToInt32(objSDR["CountryID"]);
                                }
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                {
                                    entContactMain.StateID = Convert.ToInt32(objSDR["StateID"]);
                                }
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                {
                                    entContactMain.CityID = Convert.ToInt32(objSDR["CityID"]);
                                }
                                if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                                {
                                    entContactMain.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"]);
                                }
                                if (!objSDR["BloodGroupID"].Equals(DBNull.Value))
                                {
                                    entContactMain.BloodGroupID = Convert.ToInt32(objSDR["BloodGroupID"]);
                                }
                                if (!objSDR["Twitter"].Equals(DBNull.Value))
                                {
                                    entContactMain.Twitter = Convert.ToString(objSDR["Twitter"]);
                                }
                                if (!objSDR["LinkedIn"].Equals(DBNull.Value))
                                {
                                    entContactMain.LinkedIn = Convert.ToString(objSDR["LinkedIn"]);
                                }
                                if (!objSDR["Facebook"].Equals(DBNull.Value))
                                {
                                    entContactMain.Facebook = Convert.ToString(objSDR["Facebook"]);
                                }
                                if (!objSDR["Profession"].Equals(DBNull.Value))
                                {
                                    entContactMain.Profession = Convert.ToString(objSDR["Profession"]);
                                }
                            }
                        }

                        return entContactMain;
                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        #endregion SelectByPK

        #region SelectDropDownListCountry
        public DataTable SelectForDropdownListCountry()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_CountryTable_SelectForDropdownList";
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }


        #endregion SelectDropDownListCountry

        public DataTable SelectForDropdownListByStateID(SqlInt32 StateID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_CityTable_SelectForDropdownListStateID";
                        objCmd.Parameters.AddWithValue("@StateID", StateID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        public DataTable SelectForDropdownListByCountryID(SqlInt32 CountryID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_StateTable_SelectForDropdownListCountryID";
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }

        #region SelectDropDownListBloodGroup
        public DataTable SelectForDropdownListBloodGroup()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR__BloodGroupSelectForDropdownList";
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }


        #endregion SelectDropDownListBloodGroup


        #region SelectDropDownListContactCategory
        public DataTable SelectForDropdownListContactCategory()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR__ContactCategoryTableSelectForDropdownList";
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;

                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }


        #endregion SelectDropDownListContactCategory
        #endregion Select Operation

    }
}
