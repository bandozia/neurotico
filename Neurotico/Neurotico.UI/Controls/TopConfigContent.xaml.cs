using MahApps.Metro;
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
using Neurotico.Bridge;

namespace Neurotico.UI.Controls
{
    public partial class TopConfigContent : UserControl
    {
        private readonly PythonBridge pythonBridge = PythonBridge.Instance;

        public TopConfigContent()
        {
            InitializeComponent();

            darkmodeSwitch.IsChecked = Properties.Settings.Default.CurrentTheme == "Dark.Steel";
            darkmodeSwitch.Click += DarkmodeSwitch_Click;

            Loaded += TopConfigContent_Loaded;
        }

        private async void TopConfigContent_Loaded(object sender, RoutedEventArgs e)
        {
            await RunModulesDiagnostics();
        }

        private async Task RunModulesDiagnostics()
        {
            var skleranStatusResult = await pythonBridge.PingSklearn();
            sklearnStatus.MarkComplete(skleranStatusResult);
        }
                
        private void DarkmodeSwitch_Click(object sender, RoutedEventArgs e)
        {            
            if (darkmodeSwitch.IsChecked.Value)
            {
                Properties.Settings.Default.CurrentTheme = "Dark.Steel";
            }
            else
            {
                Properties.Settings.Default.CurrentTheme = "Light.Steel";
            }
            ThemeManager.ChangeTheme(Application.Current, Properties.Settings.Default.CurrentTheme);            
            Properties.Settings.Default.Save();
        }
    }
}
