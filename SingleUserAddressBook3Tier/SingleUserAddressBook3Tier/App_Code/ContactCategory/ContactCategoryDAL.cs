using ContactCategory.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactCategoryDAL
/// </summary>
namespace AddressBook.DAL
{
    public class ContactCategoryDAL:DatabaseConfig
    {
        #region Constructor
        public ContactCategoryDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

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
        public Boolean Insert(ContactCategoryENT entContactCategory)
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
                        objCmd.CommandText = "PR_ContactCategory_Insert_ThreeTier";
                        objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@ContactCategory", SqlDbType.VarChar).Value = entContactCategory.ContactCategory;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        if (objCmd.Parameters["@ContactCategoryID"] != null)
                        {
                            entContactCategory.ContactCategoryID = Convert.ToInt32(objCmd.Parameters["@ContactCategoryID"].Value);
                        }

                        return true;
                    }

                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.InnerException.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message = ex.InnerException.Message;
                    return false;
                }
            }
        }

        #endregion Insert Operation


        #region Update Operation 
        public Boolean Update(ContactCategoryENT entContactCategory)
        {
            using (SqlConnection objCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    objCon.Open();
                    using (SqlCommand objCmd = objCon.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategoryTable_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@ContactCategoryID", entContactCategory.ContactCategoryID);
                        objCmd.Parameters.AddWithValue("@ContactCategory", entContactCategory.ContactCategory);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.InnerException.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message = ex.InnerException.Message;
                    return false;
                }

            }
        }

        #endregion Update Operation 



        #region Delete Operation
        public Boolean Delete(SqlInt32 ContactCategoryID)
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
                        objCmd.CommandText = "PR_ContactCategoryTable_DeleteByPK";
                        objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = ContactCategoryID;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;

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
                finally
                {
                    if (objCon.State == ConnectionState.Open)
                    {
                        objCon.Close();
                    }
                }
            }
        }
        #endregion Delete Operation



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
                        objCmd.CommandText = "PR_ContactCategoryTable_SelectAll";
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
                        Message = sqlex.InnerException.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
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
        public ContactCategoryENT SelectByPK(SqlInt32 ContactCategoryID)
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
                        objCmd.CommandText = "PR_ContactCategoryTable_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID);
                        #endregion Prepare Command

                        ContactCategoryENT entContactCategory = new ContactCategoryENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                                {
                                    entContactCategory.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"]);
                                }
                                if (!objSDR["ContactCategory"].Equals(DBNull.Value))
                                {
                                    entContactCategory.ContactCategory = Convert.ToString(objSDR["ContactCategory"]);
                                }
                            }
                        }
                        return entContactCategory;
                    }
                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return null;
                }
                finally
                {
                    if (objCon.State == ConnectionState.Open)
                        objCon.Close();
                }
            }
        }
        #endregion SelectByPK




        #endregion Select Operation


    }
}