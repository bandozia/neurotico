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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Neurotico.UI.Controls.DatasetSelector;

namespace Neurotico.UI.Views.DataExplorer
{
    public partial class DataPreviwer : UserControl
    {
        private SeriesCollection CurrentSeriesCollection;
        private LineSeries CurrentLine;

        public DataPreviwer()
        {
            InitializeComponent();
            Loaded += DataPreviwer_Loaded;
        }

        private void DataPreviwer_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO: check if dataset is already selected
            CurrentSeriesCollection = new SeriesCollection();
            chart.Series = CurrentSeriesCollection;
            MakeDumySeries();           
            OpenDatasetSelector();
        }

        private void MakeDumySeries()
        {
            var points = Enumerable.Range(0, FunctionsSelector.n).Select(i => new ObservablePoint(i, 5)).ToList();

            CurrentLine = new LineSeries
            {
                Values = new ChartValues<ObservablePoint>(points),
                LineSmoothness = 0,
                PointGeometry = Geometry.Empty,
                Fill = Brushes.Transparent
            };

            CurrentSeriesCollection.Add(CurrentLine);
        }

        private void OpenDatasetSelector()
        {
            DatasetSelector datasetSelector = new DatasetSelector();
            datasetSelector.OnSimpleDatasetSelected += DatasetSelector_OnSimpleDatasetSelected;
            rightContent.Content = datasetSelector;
        }

        private void DatasetSelector_OnSimpleDatasetSelected(double[] x, double[] y)
        {           
            int c = 0;
            foreach (var p in (ChartValues<ObservablePoint>)CurrentLine.Values)
            {
                p.X = x[c];
                p.Y = y[c];
                c++;
            }
        }

    }
}
