using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA.Services.Common
{
    [Serializable()]
    public class Enums
    {
        public enum permission
        {
            none,
            noAccess,
            sysErr,
            update,
            view,
        }
    }
}
