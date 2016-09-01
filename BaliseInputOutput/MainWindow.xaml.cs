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
using Microsoft.Win32;
using System.IO;

namespace BaliseInputOutput
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Option setting variables
        String min = "-5.00";
        String max = "-1.00";
        String totstep = "50";
        String timeInterval = "1000";
        String Adamcomp = "";

        public MainWindow()
        {
            InitializeComponent();
            progressLabel.Text = String.Format("{0}%", progressBar.Value);
        }

        private void progressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            progressLabel.Text = String.Format("{0}%", progressBar.Value);
        }

        // --------------------------------------------------------------
        //                            BUTTONS                           |
        // --------------------------------------------------------------
        private void reset_btn_Click(object sender, RoutedEventArgs e)
        {
            rawdata_txt.Document.Blocks.Clear();
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Save filter
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == true && saveFileDialog.FileName.Length > 0)
            {
                TextRange range;
                FileStream fStream = new FileStream(saveFileDialog.FileName, FileMode.Create);

                AddText(fStream, min, false);
                AddText(fStream, max, false);
                AddText(fStream, totstep, false);
                AddText(fStream, timeInterval, true);

                range = new TextRange(rawdata_txt.Document.ContentStart, rawdata_txt.Document.ContentEnd);
                range.Save(fStream, DataFormats.Text);
                fStream.Close();
            }
        }

        private static void AddText(FileStream fs, String value, Boolean isNewline)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);

            if (isNewline)
            {
                byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                fs.Write(newline, 0, newline.Length);
            }
            else
            {
                info = new UTF8Encoding(true).GetBytes(", ");
                fs.Write(info, 0, info.Length);
            }
        }

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
