using BloodGroup.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BloodGroupDAL
/// </summary>
namespace AddressBook.DAL
{
    public class BloodGroupDAL:DatabaseConfig
    {
        #region Constructor
        public BloodGroupDAL()
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
        public Boolean Insert(BloodGroupENT entBloodGroup)
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
                        objCmd.CommandText = "PR_BloodGroup_Insert_ThreeTier";
                        objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int,4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@BloodGroupName", SqlDbType.VarChar).Value = entBloodGroup.BloodGroupName;
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                      if(objCmd.Parameters["@BloodGroupID"]!=null)
                        {
                            entBloodGroup.BloodGroupID = Convert.ToInt32(objCmd.Parameters["@BloodGroupID"].Value);
                        }

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
            }
        }

        #endregion Insert Operation


        #region Update Operation 
        public Boolean Update(BloodGroupENT entBloodGroup)
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
                        objCmd.CommandText = "PR_BloodGroup_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@BloodGroupID", entBloodGroup.BloodGroupID);
                        objCmd.Parameters.AddWithValue("@BloodGroupName", entBloodGroup.BloodGroupName);
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

            }
        }

        #endregion Update Operation 



        #region Delete Operation
        public Boolean Delete(SqlInt32 BloodGroupID)
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
                        objCmd.CommandText = "PR_BloodGroup_DeleteByPK";
                        objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = BloodGroupID;
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
                        objCmd.CommandText = "PR_BloodGroup_SelectAll";
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
        public BloodGroupENT SelectByPK(SqlInt32 BloodGroupID)
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
                        objCmd.CommandText = "PR_BloodGroup_SelectByPK";
                        objCmd.Parameters.AddWithValue("@BloodGroupID", BloodGroupID);
                        #endregion Prepare Command

                        BloodGroupENT entBloodGroup = new BloodGroupENT();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["BloodGroupID"].Equals(DBNull.Value))
                                {
                                    entBloodGroup.BloodGroupID = Convert.ToInt32(objSDR["BloodGroupID"]);
                                }
                                if (!objSDR["BloodGroupName"].Equals(DBNull.Value))
                                {
                                    entBloodGroup.BloodGroupName = Convert.ToString(objSDR["BloodGroupName"]);
                                }
                            }
                        }
                        return entBloodGroup;
                    }
                }
                catch(SqlException sqlex)
                {
                    Message = sqlex.Message;
                    return null;
                }
                catch(Exception ex)
                {
                    Message = ex.Message;
                    return null;
                }
            }
        }
        #endregion SelectByPK

       


        #endregion Select Operation


    }
}