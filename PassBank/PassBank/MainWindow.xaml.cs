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
        Page configView;

        public MainWindow()
        {
            mainView = new MainView(this);
            newFileView = new NewItemView(this);
            //configView = new ConfigView(this);

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

        public void openConfigView()
        {
            this.Content = configView;
        }
    }
}
