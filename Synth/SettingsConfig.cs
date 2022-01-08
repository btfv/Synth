using System;
using System.Collections.Generic;
using System.Configuration;


namespace Synth
{
    class SettingsConfig
    {
        private static SettingsConfig instance;
        public event EventHandler OnSettingsChanged;
        Configuration config;
        private SettingsConfig()
        {
            config = ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath);
        }

        public static SettingsConfig getInstance()
        {
            if (instance == null)
                instance = new SettingsConfig();
            return instance;
        }

        public string PresetsFolder
        {
            get => config.AppSettings.Settings["PresetsFolder"]?.Value ?? Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            set
            {
                if (value != null)
                {
                    config.AppSettings.Settings.Remove("PresetsFolder");
                    config.AppSettings.Settings.Add("PresetsFolder", value);
                    config.Save(ConfigurationSaveMode.Modified);
                    OnSettingsChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }

}
