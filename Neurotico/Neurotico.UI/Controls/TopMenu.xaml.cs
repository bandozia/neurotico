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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Neurotico.UI.Controls
{
    public partial class TopMenu : UserControl
    {        
        public TopMenu()
        {
            InitializeComponent();

            foreach (Button menuButton in buttonsPanel.Children.OfType<Button>())
            {
                menuButton.Click += MenuButton_Click;
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            Button btSender = sender as Button;
            Point pos = btSender.TransformToAncestor(mainGrid).Transform(new Point(0, 0));

            ThicknessAnimation a = new ThicknessAnimation(new Thickness(pos.X, pointerGraphic.Margin.Top, pointerGraphic.Margin.Right, pointerGraphic.Margin.Bottom), TimeSpan.FromMilliseconds(300))
            {
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            pointerGraphic.BeginAnimation(MarginProperty, a);
        }
    }
}
