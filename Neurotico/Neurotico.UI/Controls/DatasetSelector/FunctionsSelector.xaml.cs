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
using MahApps.Metro.Controls;
using Neurotico.UI.Helpers;

namespace Neurotico.UI.Controls.DatasetSelector
{
    public partial class FunctionsSelector : UserControl
    {
        public delegate void FunctionSelectedDelegate(double[] x, double[] y);
        public event FunctionSelectedDelegate OnFunctionSelected;
                
        public const int n = 50;

        private RangeSlider slider;
        private bool inverted = false;

        string CurrentFunction = null;

        public FunctionsSelector()
        {
            InitializeComponent();
            slider = xRangeSlider;            
            swapAxisBt.Click += SwapAxisBt_Click;

            foreach (var fBt in functionsPannel.Children.OfType<Tile>())
            {
                fBt.Click += FBt_Click;
            }
        }

        private void FBt_Click(object sender, RoutedEventArgs e)
        {
            CurrentFunction = ((Tile)sender).Tag.ToString();
            SendFunction();
        }

        private void SendFunction()
        {
            double[] input = FunctionHelper.MakeInterval(slider.LowerValue, slider.UpperValue, n);
            double[] outputs = FunctionHelper.GetFunctionByName(CurrentFunction).Invoke(input);

            double[] X = inverted ? outputs : input;
            double[] Y = inverted ? input : outputs;

            OnFunctionSelected?.Invoke(X, Y);
        }
        
        private void SwapAxisBt_Click(object sender, RoutedEventArgs e)
        {
            inverted = !inverted;
            swapAxisBt.Content = inverted ? "y" : "x";

            slider = inverted ? yRangeSlider : xRangeSlider;

            if (CurrentFunction != null)
            {
                SendFunction();
            }
        }
    }
}
