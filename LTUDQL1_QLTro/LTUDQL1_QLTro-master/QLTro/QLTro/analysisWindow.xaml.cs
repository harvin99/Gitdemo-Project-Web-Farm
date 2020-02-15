using LiveCharts;
using LiveCharts.Wpf;
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

namespace QLTro
{
    /// <summary>
    /// Interaction logic for analysisWindow.xaml
    /// </summary>
    public partial class analysisWindow : Window
    {
        public analysisWindow()
        {
            InitializeComponent();
        }

        public SeriesCollection MyData
        {
            get
            {
                return new SeriesCollection
                {
                    new LineSeries()
                    {
                        Values = new ChartValues<double> { 3, 5, 7, 4 },
                        Stroke = Brushes.Red,
                        Fill = Brushes.Yellow,
                        StrokeDashArray = new DoubleCollection {2, 5, 8},
                        Title = "Doanh so quy I 2019"
                    },
                    new ColumnSeries()
                    {
                        Values = new ChartValues<double> { 5, 6, 2, 7},
                        Stroke = Brushes.Green,
                        Fill = Brushes.Black,
                        StrokeThickness = 3,
                        Title = "Cac mat hang ban chay trong quy I 2019"
                    }
                };
            }
        }

        public string[] Months => new string[] { "04", "05", "06", "07" };

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
        }

        private void PieChart_DataClick(object sender, ChartPoint chartPoint)
        {
            var chart = chartPoint.ChartView as PieChart;

            foreach (PieSeries pie in chart.Series)
            {
                pie.PushOut = 0;
            }

            var selectedChart = chartPoint.SeriesView as PieSeries;
            selectedChart.PushOut = 15;
        }
    }
}
