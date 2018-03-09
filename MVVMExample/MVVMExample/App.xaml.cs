using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MVVMExample
{
	public partial class App : Application
	{
        static db.PersonDatabase database;

        public static db.PersonDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new db.PersonDatabase(DependencyService.Get<platforminterface.DBFileLocator>().getLocatDBPath("PersonDB.db3"));
                }
                return database;
            }
        }

        public App ()
		{
			InitializeComponent();
			MainPage = new MVVMExample.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
