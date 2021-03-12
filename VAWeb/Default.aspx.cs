#region using
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.UI;

using VA.UI.Base;
#endregion

// -------------------------------------------------------------------------------------------------------------------------------------------
// Project	 : SSSLLCWeb
// Class	 : Default
// 
// -------------------------------------------------------------------------------------------------------------------------------------------
// <summary>
//      This is just the first page for http://.. path (url) that will be assigned to this application
// </summary>
// <remarks>      
// </remarks>
// <history>
// 	  [Amina Johnson]	07/18/2020  Created
//    
// </history>
// -------------------------------------------------------------------------------------------------------------------------------------------

namespace VAWeb
{
    public partial class Default : VA.UI.Base.Page
    {
        #region Properties       
        #endregion // End of Properties

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        { 
            PageSetup();
            AuthorizePage();
        }
        #endregion // End of Events

        #region Methods
        #region Functions
        #endregion // End of Functions

        #region Voids
        void AuthorizePage()
        {
            if (IsValid)
                Response.Redirect(this.ResolveUrl("~/Source/login.aspx"));
        }

        void PageSetup()
        {
          
        }

        void SetDataSets()
        {
            try
            {
               
            }
            catch (Exception)
            {
               
            }
        }
        #endregion // End of Voids
        #endregion // End of Methods

        #region Constructor
        public Default()
        {
            Load += Page_Load;

        }
        #endregion // End of Constructor
    }
}