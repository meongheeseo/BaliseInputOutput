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
using System.Windows.Shapes;

namespace BaliseInputOutput
{
    /// <summary>
    /// Interaction logic for OptionPopup.xaml
    /// </summary>
    public partial class OptionPopup : Window
    {
        public String min;
        public String max;
        public String steps;
        public String timeInterval;
        public String comport;
        
        public OptionPopup(String min, String max, String steps, String timeInterval, String comport)
        {
            InitializeComponent();
            Init_combobox();

            this.min = min;
            this.max = max;
            this.steps = steps;
            this.timeInterval = timeInterval;
            this.comport = comport;

            output_min.Text = this.min;
            output_max.Text = this.max;
            stepsize.Text = this.steps;
            interval.Text = this.timeInterval;

            if (comport != "") Adamcomport.Text = comport;
        }

        private void Init_combobox()
        {
            Adamcomport.DisplayMemberPath = "Text";
            Adamcomport.SelectedValuePath = "Value";

            var items = new[] {
                new { Text = "COM1", Value = "COM1" }, new { Text = "COM2", Value = "COM2" },
                new { Text = "COM3", Value = "COM3" }, new { Text = "COM4", Value = "COM4" },
                new { Text = "COM5", Value = "COM5" }, new { Text = "COM6", Value = "COM6" },
                new { Text = "COM7", Value = "COM7" }, new { Text = "COM8", Value = "COM8" },
                new { Text = "COM9", Value = "COM9" }, new { Text = "COM10", Value = "COM10" },
                new { Text = "COM11", Value = "COM11" }, new { Text = "COM12", Value = "COM12" },
                new { Text = "COM13", Value = "COM13" }, new { Text = "COM14", Value = "COM14" },
                new { Text = "COM15", Value = "COM15" }, new { Text = "COM16", Value = "COM16" },
                new { Text = "COM17", Value = "COM17" }, new { Text = "COM18", Value = "COM18" },
                new { Text = "COM19", Value = "COM19" }, new { Text = "COM20", Value = "COM20" },
                new { Text = "COM21", Value = "COM21" }, new { Text = "COM22", Value = "COM22" },
                new { Text = "COM23", Value = "COM23" }, new { Text = "COM24", Value = "COM24" },
                new { Text = "COM25", Value = "COM25" }, new { Text = "COM26", Value = "COM26" },
                new { Text = "COM27", Value = "COM27" }, new { Text = "COM28", Value = "COM28" },
                new { Text = "COM29", Value = "COM29" }, new { Text = "COM30", Value = "COM30" },
                new { Text = "COM31", Value = "COM31" }, new { Text = "COM32", Value = "COM32" },
                new { Text = "COM33", Value = "COM33" }, new { Text = "COM34", Value = "COM34" },
                new { Text = "COM35", Value = "COM35" }, new { Text = "COM36", Value = "COM36" },
                new { Text = "COM37", Value = "COM37" }, new { Text = "COM38", Value = "COM38" },
                new { Text = "COM39", Value = "COM39" }, new { Text = "COM40", Value = "COM40" },
                new { Text = "COM41", Value = "COM41" }, new { Text = "COM42", Value = "COM42" },
                new { Text = "COM43", Value = "COM43" }, new { Text = "COM44", Value = "COM44" },
                new { Text = "COM45", Value = "COM45" }, new { Text = "COM46", Value = "COM46" },
                new { Text = "COM47", Value = "COM47" }, new { Text = "COM48", Value = "COM48" },
                new { Text = "COM49", Value = "COM49" }, new { Text = "COM50", Value = "COM50" }
            };

            Adamcomport.ItemsSource = items;
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            this.min = output_min.Text;
            this.max = output_max.Text;
            this.steps = stepsize.Text;
            this.timeInterval = interval.Text;
            this.comport = Adamcomport.Text;
            this.Close();
        }
    }
}
