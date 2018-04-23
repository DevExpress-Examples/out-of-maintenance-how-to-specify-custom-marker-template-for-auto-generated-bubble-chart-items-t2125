using System;
using System.Data;
using System.Windows;

namespace BubbleSettings_CustomMarkerTemplate {
    public partial class MainWindow : Window {
        const string filepath = "..\\..\\Earthquakes.xml";
        
        double minMagnitude = 7;
        double maxMagnitude = 9;
        DataTable table;

        public DataTable DataTable { get { return table; } }

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(filepath);
            table = dataSet.Tables[0];
            
            table.ReadXml(filepath);
            table.DefaultView.RowFilter = String.Format("(mag >= {0}) AND (mag <= {1})", minMagnitude, maxMagnitude);
            this.DataContext = this;
        }
    }
}
