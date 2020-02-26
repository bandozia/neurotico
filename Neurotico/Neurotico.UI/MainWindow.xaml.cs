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
using MahApps.Metro;
using MahApps.Metro.Controls;
using Neurotico.UI.Views.DataExplorer;
using Neurotico.Bridge;

namespace Neurotico.UI
{
    public partial class MainWindow : MetroWindow
    {
        private readonly PythonBridge pythonBridge = PythonBridge.Instance;

        public MainWindow()
        {
            InitializeComponent();
            
            pythonBridge.InterpreterPath = "python";

            topSettingButtom.Click += TopSettingButtom_Click;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(Application.Current, Properties.Settings.Default.CurrentTheme);
            mainContent.Content = new DataPreviwer();
        }

        private void TopSettingButtom_Click(object sender, RoutedEventArgs e)
        {
            topConfigFlyout.IsOpen = true;            
        }
    }
}
