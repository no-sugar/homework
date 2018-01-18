using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.ComponentModel;
using System.Text.RegularExpressions;

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
        public string Search_result { get { return _Search_result; } private set { if (_Search_result == value) return; _Search_result = value; OnPropertyChanged(nameof(Search_result)); } }
        private string _Search_result;

        //public string search(string s,out string result)
        //{
        //    result = "";
        //    List<string> Datalist = new List<string>();
        //    var contact = from r in DataContext.Contacts select r;
        //    foreach(Contacts aContact in contact)
        //    {
        //        string contact_data = "ID:" + aContact.id + "Name" + aContact.name + "Telephone" + aContact.telephone + "Organization" + aContact.organization + "Email" + aContact.email + "Remarks" + aContact.remarks;
        //        Datalist.Add(contact_data);
        //    }
        //    string RegexStr = ".*?Remarks:" + s;
        //    for (int i = 0; i < Datalist.Count; i++)
        //    {
        //        if (Regex.IsMatch(Datalist[i], RegexStr))
        //            result = result + Datalist[i] + "\r";
        //    }
        //    return result;
        //}


        public void search(string s)
        {
            string result = "";
            List<string> Datalist = new List<string>();
            var contact = from r in DataContext.Contacts select r;
            foreach (Contacts aContact in contact)
            {
                string contact_data = "ID: " + aContact.id + " Name: " + aContact.name + " Telephone: " + aContact.telephone + " Organization: " + aContact.organization + " Email: " + aContact.email + " Remarks: " + aContact.remarks;
                Datalist.Add(contact_data);
            }
            string RegexStr = ".*?Remarks: " + s;
            for (int i = 0; i < Datalist.Count; i++)
            {
                if (Regex.IsMatch(Datalist[i], RegexStr))
                    result = result + Datalist[i] + "\r";
            }
            Search_result = result+"test";
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
