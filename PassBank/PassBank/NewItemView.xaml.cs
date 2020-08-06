using System.Windows;
using System.Windows.Controls;
namespace PassBank
{
    /// <summary>
    /// Interaction logic for NewItemView.xaml
    /// </summary>
    public partial class NewItemView : Page
    {
        MainWindow mainWindows;

        public NewItemView(MainWindow windowsContext)
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
