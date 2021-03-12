#region using
using log4net;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.UI;

using VA.Services.Common;
using System.Runtime.Remoting;
#endregion

// -------------------------------------------------------------------------------------------------------------------------------------------
// Project	 : VA.UI.Base
// Class	 : page
// 
// -------------------------------------------------------------------------------------------------------------------------------------------
// <summary>
//      This Class will be the Base Page that every aspx will Inherit (must) so that the Information Needed (ex. UserId, Role etc...) will be 
//      in Session. This information can also be overridden.
// </summary>
// <remarks>  
// </remarks>
// <history>
// 	  [Amina Johnson]	20210311      Created
// </history>
// -------------------------------------------------------------------------------------------------------------------------------------------

namespace VA.UI.Base
{
    public class Page : System.Web.UI.Page
    {
        #region Properties
        Enums.permission _lockPermissionLevel;

        public Enums.permission LockPermissionLevel
        {
            get
            {
                object o = null;

                o = Session["LockPermissionLevel"];

                if ((o != null))
                {
                    _lockPermissionLevel = (Enums.permission)o;

                }

                return _lockPermissionLevel;
            }
            set
            {
                _lockPermissionLevel = value;

                Session["LockPermissionLevel"] = value;
            }
        }
        #endregion // End of Properties

    }
}
