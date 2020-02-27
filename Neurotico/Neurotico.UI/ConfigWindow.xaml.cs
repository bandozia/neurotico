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
using System.Windows.Shapes;

namespace Neurotico.UI
{
    public partial class ConfigWindow : Window
    {
        public ConfigWindow()
        {
            InitializeComponent();

            saveBt.Click += SaveBt_Click;
            Loaded += ConfigWindow_Loaded;
        }

        private void ConfigWindow_Loaded(object sender, RoutedEventArgs e)
        {
            pythonPathTx.Text = Properties.Settings.Default.PythonPath;
            pythonModulesTx.Text = Properties.Settings.Default.PythonModulesLocation;
        }

        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            //TODO: test dirs
            Properties.Settings.Default.PythonPath = string.IsNullOrEmpty(pythonPathTx.Text) ? "python" : pythonPathTx.Text;
            Properties.Settings.Default.PythonModulesLocation = string.IsNullOrEmpty(pythonModulesTx.Text) ? "modules/python" : pythonModulesTx.Text;

            Properties.Settings.Default.Save();

            Close();
            
        }
    }
}
