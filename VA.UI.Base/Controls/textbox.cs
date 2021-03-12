#region using
using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

using VA.Services.Common;
#endregion

// -------------------------------------------------------------------------------------------------------------------------------------------
// Project	 : VA.UI.Base
// Class	 : textbox
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
    [ToolboxBitmap(typeof(System.Web.UI.WebControls.TextBox))]
    public class TextBox : System.Web.UI.WebControls.TextBox
    {
        #region Properties
        string _lockID = String.Empty;

        bool _overrideReadOnlyReset;
        bool _ignorePgPermissions = false;

        public string LockID
        {
            get { return _lockID; }
            set { _lockID = value; }
        }

        public override string Text
        {
            get { return base.Text.Trim(); }

            set
            {
                if ((value != null))
                {
                    base.Text = value.Trim();
                }
                else
                {
                    base.Text = string.Empty;
                }

                if (ReadOnly == true)
                {
                    _overrideReadOnlyReset = true;
                }
                else
                {
                    _overrideReadOnlyReset = false;
                }
            }
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

                if (value == false)
                {
                    IgnorePagePermissions = true;
                }
            }
        }

        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                base.ReadOnly = value;

                if (value == true)
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

        #region Events  
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }

        void TextBox_Load(object sender, EventArgs e)
        {
            if (base.Page.IsPostBack && base.ReadOnly)
            {
                if ((base.Text != base.Page.Request[base.UniqueID]) && !(_overrideReadOnlyReset))
                {
                    base.Text = base.Page.Request[base.UniqueID];
                }
            }

            base.AutoCompleteType = AutoCompleteType.Disabled;
        }
        #endregion // End of Events

        #region Method
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
                SetStyleSheet();
                return;
            }

            if (!IgnorePagePermissions)
            {
                // Add code to check permission and set textbox readonly, visible accordingly.
                SetPermission(PagePermissionLevel);
            }
        }

        void SetStyleSheet()
        {
            switch (ReadOnly)
            {
                case true:
                    base.CssClass = "DataFieldReadOnly";
                    break;

                case false:
                    base.CssClass = "DataField";
                    break;

                default:
                    base.CssClass = "DataFieldReadOnly";
                    break;
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
                    ReadOnly = true;
                    break;

                case Enums.permission.update:
                    Visible = true;

                    if (!ReadOnly)
                    {
                        ReadOnly = false;
                    }
                    break;
            }
        }
        #endregion // End of Voids
        #endregion // End of Methods

        #region Constructor
        public void Textbox()
        {
            Load += TextBox_Load;
        }
        #endregion // End of Constructor
    }
}
