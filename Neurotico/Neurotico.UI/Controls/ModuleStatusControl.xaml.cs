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
using MahApps.Metro.IconPacks;
using Neurotico.Bridge.Model;

namespace Neurotico.UI.Controls
{   
    public partial class ModuleStatusControl : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(ModuleStatusControl));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public ModuleStatusControl()
        {
            InitializeComponent();
        }

        public void MarkComplete(PyCommandResult result)
        {
            mainGrid.Children.Remove(processRing);
            PackIconBoxIcons icon = new PackIconBoxIcons
            {
                Kind = result.Success ? PackIconBoxIconsKind.RegularCheck : PackIconBoxIconsKind.RegularError,
                Foreground = result.Success ? Brushes.Green : Brushes.DarkRed,
                Width = 20, Height = 20                
            };
            icon.SetValue(Grid.ColumnProperty, 1);
            mainGrid.Children.Add(icon);
            if (!result.Success)
            {
                errorTextbox.Visibility = Visibility.Visible;
                errorTextbox.Text = result.Reason;
            }
        }
    }
}
