using System.Windows;
using System.Windows.Controls;

namespace PassBank
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Page mainView;
        Page newFileView;

        public MainWindow()
        {
            mainView = new MainView(this);
            newFileView = new NewFileView(this);

            InitializeComponent();

            openMainView();
        }

        public void openMainView() {
            this.Content = mainView;
        }

        public void openNewFileView()
        {
            this.Content = newFileView;
        }
    }
}
