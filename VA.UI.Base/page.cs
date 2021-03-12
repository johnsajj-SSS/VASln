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
        Logging _logging;

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

        public bool IsAuthorizedPage
        {
            get
            {
                object o = null;

                o = Session["IsAuthorizedPage"];

                if ((o != null))
                {
                    return Convert.ToBoolean(o);
                }

                return false;
            }

            set { Session["IsAuthorizedPage"] = value; }
        }



        public new bool IsValid
        {
            get
            {
                object o = null;

                o = Session["IsValid"];

                if ((o != null))
                {
                    return Convert.ToBoolean(o);
                }

                return false;
            }

            set { Session["IsValid"] = value; }
        }
        #endregion // End of Properties

        #region Methods
        #region Functions

        #endregion // End of Functions

        #region Voids
        public void AppAuthorization()
        {
            _logging = new Logging(this.GetType());

            //IsAuthorizedPage = IsEntryPage();

            if (IsAuthorizedPage)
            {
                //AuthorizePage();
            }
            else
            {
                //NotAuthorized();
            }
        }
        #endregion // End of Voids
        #endregion // End of Methods

    }
}
