using System.Windows;
using System.Windows.Controls;
namespace PassBank
{
    /// <summary>
    /// Interaction logic for NewFileView.xaml
    /// </summary>
    public partial class NewFileView : Page
    {
        MainWindow mainWindows;

        public NewFileView(MainWindow windowsContext)
        {
            mainWindows = windowsContext;
            InitializeComponent();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindows.openMainView();
        }
    }
}
