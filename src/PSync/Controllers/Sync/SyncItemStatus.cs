using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSync.Controllers.Sync
{
    public enum SyncItemStatus
    {
        NoActionRequired,
        ActionPending,
        ActionOK,
        ActionFailed,
    }
}
