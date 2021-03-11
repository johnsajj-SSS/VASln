#region using
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

using VA.Data.Common;
using VA.Services.Common;
#endregion

// -------------------------------------------------------------------------------------------------------------------------------------------
// Project	 : VA.BusinessObject.Base
// Class	 : busObj
// 
// -------------------------------------------------------------------------------------------------------------------------------------------
// <summary>
//      This is the Base Class for all Business Objects (UI Mapped --> DB)
// </summary>
// <remarks>      
// </remarks>
// <history>
// 	  [Amina Johnson]	20210311  Created
//    
// </history>
// -------------------------------------------------------------------------------------------------------------------------------------------

namespace VA.BusinessObject
{
    [Serializable()]
    public abstract class BusObject
    {
        #region Properties
        public abstract int Create(object clsBE);
        public abstract int Update(object clsBE);

        Logging _logging;

        protected Logging Logging
        {
            get { return _logging; }
            set { _logging = value; }
        }
        #endregion // End of Properties

        #region Methods
        #region Functions
        protected SqlParameter[] CreateParameterArray(Hashtable parameters)
        {

            return CreateParameterArray(parameters, false);

        }

        protected SqlParameter[] CreateParameterArray(string name, object value)
        {

            SqlParameter[] sqlParameters = new SqlParameter[1];

            sqlParameters[0] = new SqlParameter(name, value);

            return sqlParameters;

        }

        protected SqlParameter[] CreateParameterArray(Hashtable parameters, bool includeReturn)
        {
            int index = 0;
            int upper = parameters.Count - 1;

            SqlParameter[] sqlParameters = new SqlParameter[upper + 1];

            if (includeReturn)
            {
                upper = upper + 1;
            }

            foreach (DictionaryEntry parameter in parameters)
            {
                sqlParameters[index] = new SqlParameter(parameter.Key.ToString(), parameter.Value);
                index = index + 1;
            }

            if (includeReturn)
            {
                sqlParameters[upper] = new SqlParameter(DataServices.ReturnValueName, null);
                sqlParameters[upper].Direction = ParameterDirection.Output;
            }

            return sqlParameters;
        }
        #endregion // End of Functions

        #region Voids
        void Initialize()
        {
            _logging = new Logging(GetType());
        }
        #endregion // End of Voids       
        #endregion // End of Methods

        #region Constructors
        public void New()
        {
            Initialize();
        }
        #endregion // End of Constuctors
    }
}
