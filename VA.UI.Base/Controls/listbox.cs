#region using
using System;
using System.Drawing;
using System.Web.UI;

using VA.Services.Common;
#endregion

// -------------------------------------------------------------------------------------------------------------------------------------------
// Project	 : VA.UI.Base
// Class	 : listbox
// 
// -------------------------------------------------------------------------------------------------------------------------------------------
// <summary>
//      This Custom Control Class will allow the application to control permissions by Roles.
// </summary>
// <remarks>  
// </remarks>
// <history>
// 	  [Amina Johnson]	20210311  Created
//    
// </history>
// -------------------------------------------------------------------------------------------------------------------------------------------

namespace VA.UI.Base
{
    [ToolboxBitmap(typeof(System.Web.UI.WebControls.ListBox))]
    public class ListBox : System.Web.UI.WebControls.ListBox
    {
        #region Properties
        string _lockID = String.Empty;

        bool _ignorePgPermissions = false;

        public string LockID
        {
            get { return _lockID; }
            set { _lockID = value; }
        }

        public bool IgnorePagePermissions
        {
            get { return _ignorePgPermissions; }
            set { _ignorePgPermissions = value; }
        }

        public override bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;

                //set to false to ignore permission
                if (value == false)
                {
                    IgnorePagePermissions = true;
                }
            }
        }

        public Enums.permission PagePermissionLevel
        {
            get { return ((Page)Page).LockPermissionLevel; }
        }

        public Page basePage
        {
            get { return ((Page)basePage); }
        }
        #endregion // End of Properties     

        #region Methods
        #region Functions
        #endregion // End of Functions

        #region Voids
        protected override void CreateChildControls()
        {
            if (Enabled)
            {
                Page parentPage = (Page)Page;

                Enums.permission permission = parentPage.LockPermissionLevel;

                SetPermission(permission);

                return;
            }

            if (!IgnorePagePermissions)
            {
                SetPermission(PagePermissionLevel);
            }
        }


        void SetPermission(Enums.permission permission)
        {
            switch (permission)
            {
                case Enums.permission.none:
                    Visible = false;
                    break;

                case Enums.permission.view:
                    Visible = true;
                    Enabled = false;
                    break;

                case Enums.permission.update:
                    Visible = true;
                    Enabled = true;
                    break;
            }
        }
        #endregion // End of Voids
        #endregion // End of Methods
    }
}
