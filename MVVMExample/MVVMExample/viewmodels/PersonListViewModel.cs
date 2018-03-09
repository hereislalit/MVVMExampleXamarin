using MVVMExample.models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMExample.viewmodels
{
    public 
    class PersonListViewModel : INotifyPropertyChanged
    {
        public ICommand CommandAddPerson { get; set; }
        public string FullName { get; set; }

        public Person CurrentPerson { get; set; }
        
        public ObservableCollection<Person> personList { get; set; }

        public PersonListViewModel()
        {
            personList = new ObservableCollection<Person>();
            CurrentPerson = new Person();
            CommandAddPerson = new Command(() =>
            {
                addPersonCommand();
            }, ()=> {
                if (string.IsNullOrEmpty(CurrentPerson.Name))
                {
                    return false;
                }
                return true;
            });
            CurrentPerson.PropertyChanged += CurrentPerson_PropertyChanged;
            loadInitData();
        }

        private async void loadInitData()
        {
            Task<List<Person>> task = App.Database.getPersonListAsync();
            List<Person> listOfPerson = await task;
            for(int i=0;i< listOfPerson.Count; i++)
            {
                personList.Add(listOfPerson[i]);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        /*
        public async void addPersonToListAsync(string name, string lastName) {
            Person person = new Person();
            person.Name = name;
            person.LastName = lastName;
            Task<int> task = App.Database.savePersonAsync(person);
            if (await task > 0 ) {
                personList.Add(person);
                FullName = CurrentPerson.Name + " " + CurrentPerson.LastName;
                onPropertyChanged("FullName");
                CurrentPerson = new Person();
                onPropertyChanged("CurrentPerson");
            }
        }
        */

        public async void addPersonToListAsync()
        {
            Task<int> task = App.Database.savePersonAsync(CurrentPerson);
            if (await task > 0)
            {
                personList.Add(CurrentPerson);
                FullName = CurrentPerson.Name + " " + CurrentPerson.LastName;
                onPropertyChanged("FullName");
                CurrentPerson = new Person();
                CurrentPerson.PropertyChanged += CurrentPerson_PropertyChanged;
                onPropertyChanged("CurrentPerson");
            }
        }

        public void onPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /*public void addPersonCommand(string personName, string personLastName)
        {
            if (!String.IsNullOrWhiteSpace(personName))
            {
                addPersonToListAsync(personName, personLastName);
            }
        }
        */

        public void addPersonCommand()
        {
            addPersonToListAsync();
        }


        public void CurrentPerson_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ((Command)CommandAddPerson).ChangeCanExecute();
        }
    }
}
