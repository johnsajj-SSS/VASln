#region using
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Windows;

using VA.Services.Common;
using VA.UI.Base;
#endregion

namespace VAWeb.Source
{
    public partial class Item : VA.UI.Base.Page
    {
        #region "Variables
        int _index = 0;

        #endregion // End of Variables

        #region Properties  
        Label _oLbl1
        {
            get { return this.lbl1; }
            set { this.lbl1 = value; }
        }

        ListBox _oLstBx
        {
            get { return this.lstbx; }
            set { this.lstbx = value; }
        }

        TextBox _oTxtBx1
        {
            get { return this.txtbx1; }
            set { this.txtbx1 = value; }
        }

        List<string> _lstItem
        {
            get
            {
                List<string> o = new List<string>();

                if ((o != null))
                {
                    o = (List<string>)Session["_lstItem"];
                }

                return o;
            }

            set { Session["_lstItem"] = value; }
        }
        #endregion // End of Properties

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            AppAuthorization();
            PageSetup();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddItemstoList();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteItemsList();
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            DoneItemsList();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EditItemstoList();
        }
        protected void lstbx_SIC(object sender, EventArgs e)
        {
            SetTextbox();
        }
        #endregion // End of Events

        #region Methods
        #region Functions 
        #endregion // End of Functions

        #region Voids
        void AddItemstoList()
        {
            try
            {
                if (_oLstBx.Items.Count > 0)
                {
                    for (int i = 0; i <= _oLstBx.Items.Count - 1; i++)
                    {
                        if (_oLstBx.Items[i].Text != _oTxtBx1.Text)
                        {
                            _oLstBx.Items.Add(_oTxtBx1.Text);

                            i = 15;
                        }
                        else
                        {
                            //oLblErr.Text = ("The Item it already in the List");
                        }
                    }
                }
                else
                {
                    _oLstBx.Items.Add(_oTxtBx1.Text);
                }
                
                SetControlDefault();
                SetControlVisibility(true, true, true, true, true);
            }
            catch (Exception)
            {
                //oLblErr.Text = ("Error occurred while trying to Set the Item Page in the AddItemstoList() Method. Please Contact ...");

                SetControlVisibility(true, true, false, false, false);

                IsValid = false;

                return;
            }
        }

        void AuthorizePage()
        {
            ValPage();

            if (IsValid)
            {
                PageSetup();
            }

        }

        void DeleteItemsList()
        {
            try
            {
                for (int i = 0; i <= _oLstBx.Items.Count - 1; i++)
                {
                    int _index = _oLstBx.SelectedIndex;
                    _oLstBx.Items.RemoveAt(_index);

                    i = 15;
                }

                SetControlDefault();
                SetControlVisibility(true, true, true, true, true);              
            }
            catch (Exception)
            {
                //oLblErr.Text = ("Error occurred while trying to Set the Item Page in the DeleteItemsList() Method. Please Contact ...");

                SetControlVisibility(true, true, false, false, false);

                IsValid = false;

                return;
            }
        }

        void DoneItemsList()
        {
            try
            {
                for (int i = 0; i <= _oLstBx.Items.Count - 1; i++)
                {
                    if (_oLstBx.Items[i].Text == _oTxtBx1.Text)
                    {  
                        _oLstBx.Attributes.Add("style", "text-decoration: line-through");

                        i = 15;
                    }
                }

                SetControlDefault();
                SetControlVisibility(true, true, true, true, true);
            }
            catch (Exception)
            {
                //oLblErr.Text = ("Error occurred while trying to Set the Item Page in the DoneItemsList() Method. Please Contact ...");

                SetControlVisibility(true, true, false, false, false);

                IsValid = false;

                return;
            }
        }

        void EditItemstoList()
        {
            try
            {
                for (int i = 0; i <= _oLstBx.Items.Count - 1; i++)
                {
                    int _index = _oLstBx.SelectedIndex;

                    if (_oLstBx.SelectedItem.Text != _oTxtBx1.Text)
                    {
                        _oLstBx.Items.Add(_oTxtBx1.Text);
                        _oLstBx.Items.RemoveAt(_index);

                        i = 15;
                    }
                }

                SetControlDefault();
                SetControlVisibility(true, true, true, true, true);
            }
            catch (Exception)
            {
                //oLblErr.Text = ("Error occurred while trying to Set the Item Page in the EditItemstoList() Method. Please Contact ...");

                SetControlVisibility(true, true, false, true, false);

                IsValid = false;

                return;
            }
        }
       
        void PageSetup()
        {
            //if (IsAuthorizedPage)
            //{
                SetControlDefault();
                //SetLabelControls();
                SetControlVisibility(true, true, false, false, false);

                SetPropertiesDefault(Enums.permission.update);
            //}
            //else
            //{
            //    //NotAuthorized();
            //}
        }

        void SetControlDefault()
        {
            _oLbl1.Visible = true;

            //_oTxtBx1.Text = "New Todo Item";
        }

        void SetControlVisibility(bool value, bool value1, bool value2, bool value3, bool value4)
        {
            _oLbl1.Visible = value;

            btnAdd.Visible = value1;
            btnDelete.Visible = value2;
            btnDone.Visible = value3;
            btnEdit.Visible = value4;
        }

        void SetLabelControls()
        {
            try
            {
                DataSet ds = (DataSet)Session["dsItemsPg"];

                for (int i = 0; i <= ds.Tables.Cast<DataTable>().Sum(x => x.Rows.Count) - 1; i++)
                {
                    _oLbl1.Text = ds.Tables[_index].Rows[i]["lbl2"].ToString();

                }
            }
            catch (Exception)
            {
                //oLblErr.Text = ("Error occurred while trying to Set the Item Page in the SetLabelControls() Method. Please Contact ...");

                SetControlVisibility(true, true, false, false, false);

                IsValid = false;

                return;
            }
        }

        void SetTextbox()
        {

            //_oLstBx.DataSource = // Bind to ds or lst<>;
            //_oLstBx.DataBind();
        }

        void SetPropertiesDefault(Enums.permission value)
        {
            IsValid = true;

            LockPermissionLevel = value;
        }

        void ValPage()
        {
           // Validate All Required Fields
        }
        #endregion // End of Voids
        #endregion // End of Methods
    }
}