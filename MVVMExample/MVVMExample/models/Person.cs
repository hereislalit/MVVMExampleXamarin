using SQLite;
using System.ComponentModel;

namespace MVVMExample.models
{
    public class Person : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        string name;
        string lastName;
        public string Name
        {
            get { return name; }
            set { name = value;
                onProperyChanged("Name");
            }
        }

        public string LastName {
            get { return lastName; }
            set { lastName = value;
                onProperyChanged("LastName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void onProperyChanged(string propertyName)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
