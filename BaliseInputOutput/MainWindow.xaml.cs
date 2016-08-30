using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Windows.Controls;

namespace BaliseInputOutput
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            progressLabel.Text = String.Format("{0}%", progressBar.Value);
        }

        private void progressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            progressLabel.Text = String.Format("{0}%", progressBar.Value);
        }

        String min = "-5.00";
        String max = "-1.00";
        String totstep = "50";
        String timeInterval = "1000";
        String Adamcomp = "";
        
        private void options_btn_Click(object sender, RoutedEventArgs e)
        {
            OptionPopup popup = new OptionPopup(min, max, totstep, timeInterval, Adamcomp);
            popup.ShowDialog();

            min = popup.min;
            max = popup.max;
            totstep = popup.steps;
            timeInterval = popup.timeInterval;
            Adamcomp = popup.comport;
        }
    }
}
