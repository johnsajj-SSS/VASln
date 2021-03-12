#region using
using System;
using System.Data;
using System.Data.SqlClient;

using VA.Business;
using VA.Data.Common;
#endregion

namespace VA.BusinessObject
{
    public class ItemBO : VA.BusinessObject.BusObject
    {
        #region Properties
        //ItemBE objBE;
        #endregion // End of Properties

        #region Implement Methods from the Base Class
        public override int Create(object clsBE)
        {
            throw new NotImplementedException("Not being used at this time");
        }

        public override int Update(object clsBE)
        {
            throw new NotImplementedException("Not being used at this time");
        }
        #endregion // End of Implement ...

        #region Other
        public DataSet GetItemInfo(int value)
        {
            SqlParameter[] @params = new SqlParameter[3];

            @params[0] = new SqlParameter("@id", value);

            DataSet ds = DataServices.RunSPReturnDS("usp_Select_Items_GetItemInfo", DataServices.DataBaseEntity.VAWeb, @params);

            return ds;
        }
        #endregion // End of Other

    }
}
