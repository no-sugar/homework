using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.ComponentModel;

namespace design
{
    class MainModel : INotifyPropertyChanged
    {
        public const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=contacts_data;Integrated Security=True;";
        public MainModel()
        {
            DataContext = new contact_dataDataContext(ConnectionString);
        }
        public void Submit()
        {
            DataContext.SubmitChanges();
        }
        public Table<Contacts> Contacts
        {
            get { return DataContext.Contacts; }
        }
        public contact_dataDataContext DataContext { get; }
        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
