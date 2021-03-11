#region using
using System;
using System.Data;

using VA.Services.Common;
#endregion

// -------------------------------------------------------------------------------------------------------------------------------------------
// Project	 : VA.Business.Base
// Class	 : busEntity
// 
// -------------------------------------------------------------------------------------------------------------------------------------------
// <summary>
//      This is the Base Class for all Business Entity Objects (DB Mapped --> UI)
// </summary>
// <remarks>      
// </remarks>
// <history>
// 	  [Amina Johnson]	20210311  Created
//    
// </history>
// -------------------------------------------------------------------------------------------------------------------------------------------

namespace VA.Business
{
    [Serializable()]
    public abstract class BusEntity
    {
        #region Properties
        int _UserID;

        bool _IsDirtyFlag;

        protected DataSet _dataSet;
        protected DataTable _dataTable;

        Logging _logging;

        public int UserID
        {
            get;
            set;
        }

        protected Logging Logging
        {
            get
            {
                return _logging;
            }
        }
        #endregion // End of Properties

        #region Methods
        void Initialize()
        {           
           _logging = new Logging(GetType());
        }
        #endregion // End of Methods

        #region Constructor
        public void New()
        {
            Initialize();
        }
        #endregion // End of Constructor
    }
}
