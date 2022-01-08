using System;
using System.Windows;
using System.Windows.Forms;

namespace Synth.UI
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            InitValues(this, EventArgs.Empty);
            SettingsConfig.getInstance().OnSettingsChanged += InitValues;
        }

        private void InitValues(object o, EventArgs e)
        {
            PresetsFolderPath.Content = SettingsConfig.getInstance().PresetsFolder;
        }

        private void OnOpenSettingsWindowClick(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    SettingsConfig.getInstance().PresetsFolder = fbd.SelectedPath;
                }
            }

        }
    }
}
