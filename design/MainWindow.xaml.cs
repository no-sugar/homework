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

        private void OnSace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _Model.Submit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Onseatch(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void OnCansearch(object sender, CanExecuteRoutedEventArgs e)
        {

        }
    }

  
}
