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

namespace Neurotico.UI.Views.DataExplorer
{    
    public partial class DatasetSelector : UserControl
    {
        public delegate void SimpleDatasetSelectedDelegate(double[] x, double[] y);
        public event SimpleDatasetSelectedDelegate OnSimpleDatasetSelected;

        public DatasetSelector()
        {
            InitializeComponent();

            funciontSelector.OnFunctionSelected += FunciontSelector_OnFunctionSelected;
        }

        private void FunciontSelector_OnFunctionSelected(double[] x, double[] y)
        {
            OnSimpleDatasetSelected?.Invoke(x, y);
        }
    }
}
