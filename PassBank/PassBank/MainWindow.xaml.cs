using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace PassBank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        FilesSettings _fileSetting = new FilesSettings();

        public MainWindow()
        {
            InitializeComponent();
            RecentListView.ItemsSource = _fileSetting.recentFilesList;
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();

            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                string fileName = openFileDlg.SafeFileName;
                string filePath = openFileDlg.FileName;


                PasswordWindow passWindow = new PasswordWindow();
                passWindow.Title = fileName;
                passWindow.Show();

                this.AddRecentFile(fileName, filePath);


                ///Para Teste visualizar o arquivo como texto
                TesteBox.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            PasswordWindow passWindow = new PasswordWindow();
            passWindow.Show();
        }

        public void AddRecentFile(string name, string path)
        {
            _fileSetting.AddRecentFile(name, path);
            _fileSetting.Save();
            UpdateRecentFileList();
        }

        public void RemoveRecentFile(int index)
        {
            _fileSetting.RemoveRecentFile(index);
            _fileSetting.Save();
            UpdateRecentFileList();
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            RecentFile item = (sender as FrameworkElement).DataContext as RecentFile;
            //int index = RecentListView.Items.IndexOf(item);

            string fileName = item.name;
            string filePath = item.path;

            PasswordWindow passWindow = new PasswordWindow();
            passWindow.Title = fileName;
            passWindow.Show();

            this.AddRecentFile(fileName, filePath);

            ///Para Teste visualizar o arquivo como texto
            TesteBox.Text = System.IO.File.ReadAllText(filePath);

        }

        private void Button_Click_RemoveRecentFileItem(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            int index = RecentListView.Items.IndexOf(item);
            this.RemoveRecentFile(index);
        }

        public void UpdateRecentFileList() {
            //RecentListView.ItemsSource = _fileSetting.recentFilesList;
            RecentListView.Items.Refresh();
        }

        [Serializable]
        public class RecentFile
        {
            public string name { get; set; }
            public string path { get; set; }

            public RecentFile(string name, string path)
            {
                this.name = name;
                this.path = path;
            }
        }

        sealed class FilesSettings : ApplicationSettingsBase
        {
            [DefaultSettingValue(""), UserScopedSetting]
            [SettingsSerializeAs(SettingsSerializeAs.Binary)]
            public List<RecentFile> recentFilesList
            {
                get { return this["recentFilesList"] as List<RecentFile>;  }
            }

            public void AddRecentFile(string name, string path)
            {
                recentFilesList.RemoveAll(element => element.path == path);
                recentFilesList.Insert(0, new RecentFile(name, path));
                this["recentFilesList"] = recentFilesList;
            }

            public void RemoveRecentFile(int index)
            {
                recentFilesList.RemoveAt(index);
                this["recentFilesList"] = recentFilesList;
            }
        }

    }
}
