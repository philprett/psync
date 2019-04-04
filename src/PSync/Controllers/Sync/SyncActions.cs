using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSync.Controllers.Sync
{
    public enum SyncActions
    {
        None,
        CopyFrom1To2,
        CopyFrom2To1,
        Delete1,
        Delete2,
        DeleteBoth,
    }
}
