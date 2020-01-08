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
        public MainWindow()
        {
            InitializeComponent();
            recentListView
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

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


                this.NewRecentFile(fileName, filePath);



                TesteBox.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
                //FileNameTextBox.Text = openFileDlg.FileName;
                //TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            PasswordWindow passWindow = new PasswordWindow();
            passWindow.Show();
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
            

        public void NewRecentFile(string name, string path)
        {
            RecentFilesSettings recentFileSetting = new RecentFilesSettings();
            recentFileSetting.Add(name, path);
            recentFileSetting.Save();
        }

        sealed class RecentFilesSettings : ApplicationSettingsBase
        {
            [DefaultSettingValue(""), UserScopedSetting]
            [SettingsSerializeAs(SettingsSerializeAs.Binary)]
            public List<RecentFile> recentFilesList
            {
                get { return this["recentFilesList"] as List<RecentFile>;  }
            }

            public void Add(string name, string path)
            {
                recentFilesList.Add(new RecentFile(name, path));
                this["recentFilesList"] = recentFilesList;
            }
        }
    }
}
