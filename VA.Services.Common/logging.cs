#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using log4net;
#endregion

// -------------------------------------------------------------------------------------------------------------------------------------------
// Project	 : VA.Services.Common
// Class	 : logging
// 
// -------------------------------------------------------------------------------------------------------------------------------------------
// <summary>
//      This Class provides Logging Support for All Applications
// </summary>
// <remarks>   
//      Currently logging is directly supported by log4Net which can be configured external to the application.The loggers used by this class 
//      are initialized in the Base Class, so it is important that your pages Inherit from that Base Page.  Serializable/NonSerialized 
//      attributes are available so this class can be used with the messaging architecture. 
// </remarks>
// <history>
// 	  [Amina Johnson]	05/06/2020  Created
//    
// </history>
// --------------------------------------------------------------------------------------------------------------------------------------------

namespace VA.Services.Common
{
    [Serializable()]
    public class Logging
    {
        #region Properties
        [NonSerialized()]
        ILog _Log;

        public ILog CurrentLog
        {
            get { return _Log; }
        }
        #endregion // End of Properties

        #region Methods
        #region Functions
        public Logging(Type logType)
        {
            _Log = LogManager.GetLogger(logType);
        }
        #endregion // End of Functions

        #region Voids
        #endregion // End of Voids
        #endregion // End of Methods

    }
}
