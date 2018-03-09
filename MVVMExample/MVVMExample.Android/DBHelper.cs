using MVVMExample.platforminterface;
using System.IO;
using Xamarin.Forms;
[assembly: Dependency(typeof(MVVMExample.Droid.DBHelper))]

namespace MVVMExample.Droid
{

    class DBHelper : DBFileLocator
    {
        public string getLocatDBPath(string dbFileName)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, dbFileName);
        }
    }
}