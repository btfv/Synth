using System.Windows.Forms;
using System.IO;
using System;

namespace Synth.UI
{
    class FileDialog
    {
        private OpenFileDialog openFileDialog;
        private System.Xml.Serialization.XmlSerializer x;
        string presetFolder;

        public FileDialog()
        {
            x = new System.Xml.Serialization.XmlSerializer(typeof(Preset));
            openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            presetFolder = SettingsConfig.getInstance().PresetsFolder;
        }

        public Preset GetPreset()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                return deserializePreset(fileStream);
            }
            return null;
        }
        private Preset deserializePreset(Stream stream)
        {
            return (Preset)x.Deserialize(stream);
        }

        public void SavePreset(Preset p, string title)
        {
            FileStream file = File.Create(presetFolder + "\\" + title + ".xml");
            x.Serialize(file, p);
        }
    }
}
