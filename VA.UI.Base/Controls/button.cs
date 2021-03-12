#region using
using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using VA.Services.Common;
#endregion

// -------------------------------------------------------------------------------------------------------------------------------------------
// Project	 : VA.UI.Base
// Class	 : button
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
    [ToolboxBitmap(typeof(System.Web.UI.WebControls.Button))]
    public class Button : System.Web.UI.WebControls.Button
    {
        #region Properties
        int _radius = 4;

        string _lockID = String.Empty;

        bool _ignorePgPermissions = false;

        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public bool IgnorePagePermissions
        {
            get { return _ignorePgPermissions; }
            set { _ignorePgPermissions = value; }
        }

        public Enums.permission PagePermissionLevel => ((Page)Page).LockPermissionLevel;

        public Page basePage
        {
            get { return ((Page)basePage); }
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
        #endregion // End of Properties

        #region Events
        private void ccRoundCornerPanel_Load(object sender, EventArgs e)
        {
            EnsureChildControls();
        }
        #endregion // End of Events

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

        protected override void Render(HtmlTextWriter output)
        {
            if (base.Enabled)
            {
                string js = string.Empty;

                js = string.Empty;
            }

            base.Render(output);
        }

        void SetPermission(Enums.permission permission)
        {
            switch (permission)
            {
                case Enums.permission.none:
                    Visible = false;
                    break;

                case Enums.permission.noAccess:
                case Enums.permission.view:
                    Visible = false;
                    Enabled = false;
                    break;


                case Enums.permission.sysErr:
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
