#region using
using log4net;

using Microsoft.ApplicationBlocks.Data;
using Microsoft.VisualBasic;

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
#endregion

// -------------------------------------------------------------------------------------------------------------------------------------------
// Project	 : VA.Data.Common
// Class	 : dataServices
// 
// -------------------------------------------------------------------------------------------------------------------------------------------
// <summary>
//      This Class Provides a Set of Static Wrapper Functions for Executing SQL code against the Database. Additionally, this 
//      manages the Retriveing of the Connection Strings needed for the Database to Exeucte the SQL code. 
// <remarks>      
// </remarks>
// <history>
// 	  [Amina Johnson]	20210311 Created
//    
// </history>
// -------------------------------------------------------------------------------------------------------------------------------------------


namespace VA.Data.Common
{
    public class DataServices
    {
        #region Enum
        public enum DataBaseEntity
        {
            VAWeb
        }

        private enum State : byte
        {
            DELETE_NOT_ALLOWED = 120,
            TIMESTAMP_CHANGED = 100
        }
        #endregion

        #region Properties
        public const string ReturnValueName = "@returnValue";

        static string oErrLog = string.Empty;
        static string sLogFile = string.Empty;

        static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion // End of Properties

        #region Connection Strings
        /// <summary>  
		/// Gets the Connection String from the Web Config File to Connect to a Database(s)
		/// </summary>	
		/// <param name="databaseOption">Represents a Trigger to Connection String</param> 
        /// <returns>string</returns>
        public static string GetConnectionString(DataBaseEntity databaseOption)
        {
            string connString = null;

            switch (databaseOption)
            {
                case DataBaseEntity.VAWeb:
                    connString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                    break;

                default:
                    // throw new Customize Exception
                    break;
            }

            if (connString.Length == 0)
            {
                // throw new Customize Exception
            }

            return connString;
        }
        #endregion // End of Properties

        #region Methods
        #region Functions
        public static DataSet RunSPReturnDS(string spName, DataBaseEntity databaseOption, SqlParameter[] @params)
        {
            string connString = null;

            DataSet ds = null;

            try
            {
                // Start timer
                TimeSpan startTime = default(TimeSpan);

                connString = GetConnectionString(databaseOption);

                if (_log.IsInfoEnabled)
                {
                    startTime = DateTime.Now.TimeOfDay;
                }

                // Executes the Query
                ds = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, spName, @params);

                if (_log.IsInfoEnabled)
                {
                    _log.Info("Execution of " + spName + " took " + DateTime.Now.TimeOfDay.Subtract(startTime).ToString());
                }
            }
            catch (SqlException e)
            {
                // Write a Global Void to Perform the Operation
            }
            catch (Exception e)
            {      
                // Write a Global Void to Perform the Operation
            }

            return ds;
        }
        #endregion // End of Voids
        #region Voids
        public static void CheckSQLException(SqlException e, string spName)
        {
            LogDataException("RunSP " + spName, e);
        }

        static void LogDataException(string message, Exception e)
        {
            try
            {
                _log.Error(message, e);
            }
            catch
            {
                //Leave Blank for now
            }
        }
        #endregion // End of Void       
        #endregion // End of Methods
    }
}
