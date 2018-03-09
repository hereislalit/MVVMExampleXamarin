using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMExample.platforminterface
{
    public interface DBFileLocator
    {
        string getLocatDBPath(string dbFileName);
    }
}
