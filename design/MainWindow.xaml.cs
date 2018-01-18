using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Linq;
using System.ComponentModel;
using Microsoft.VisualBasic; //添加VB的引用

namespace design
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    ///
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _Model = new MainModel();
            this.DataContext = _Model;
        }
        private MainModel _Model;
        //public string Search_result { get { return _Search_result; } private set { if (_Search_result == value) return; _Search_result = value; OnPropertyChanged(nameof(Search_result)); } }
        //private string _Search_result;


        private void OnSace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _Model.Submit();
                //重新载入数据，好让新建的数据读入
                _Model = new MainModel();
                this.DataContext = _Model;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Onseatch(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                string remark_seatch = Interaction.InputBox("请输入要搜索的备注信息", "搜索", "例如：客服");
                //string result;
                //_Model.search(remark_seatch,out result);
                _Model.search(remark_seatch);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnCansearch(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }


        private void OnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnNew_Click(object sender, RoutedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
            _Model = new MainModel();
            this.DataContext = _Model;
        }

        private void Ondelete(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                const string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=contacts_data;Integrated Security=true;";
                string id = Interaction.InputBox("请输入要删除的联系人id","删除","例如，输入：3");
                using (contact_dataDataContext aDataContext = new contact_dataDataContext(ConnectionString))
                {
                    Contacts aExistContact = (from r in aDataContext.Contacts where r.id == int.Parse(id) select r).FirstOrDefault();
                    if (aExistContact != null)
                    {
                        aDataContext.Contacts.DeleteOnSubmit(aExistContact);
                        aDataContext.SubmitChanges();
                    }
                }
                _Model = new MainModel();
                this.DataContext = _Model;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnCandelete(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OnChange_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("请在右侧区域直接修改后保存","提示");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("这是一个通讯录管理软件V1.0", "关于软件");
        }
    }

  
}
