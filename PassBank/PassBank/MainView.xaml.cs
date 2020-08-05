using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace PassBank
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        MainWindow mainWindows;

        public MainView(MainWindow windowsContext)
        {
            mainWindows = windowsContext;
            InitializeComponent();
        }

        private void NewFileButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindows.openNewFileView();
        }
    }
}
