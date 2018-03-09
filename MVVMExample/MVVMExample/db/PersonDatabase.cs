using System;
using System.Collections.Generic;
using System.Text;
using MVVMExample.models;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMExample.db
{
    public class PersonDatabase
    {
        public SQLite.SQLiteAsyncConnection databaseConnection;
        public PersonDatabase(String dbPath)
        {
           databaseConnection =  new SQLite.SQLiteAsyncConnection(dbPath);
           databaseConnection.CreateTableAsync<Person>().Wait();
        }

        public Task<List<Person>> getPersonListAsync()
        {
            return databaseConnection.Table<Person>().ToListAsync();
        }

        public Task<int> savePersonAsync(Person personItem)
        {
            return databaseConnection.InsertAsync(personItem);
        }
    }
}
