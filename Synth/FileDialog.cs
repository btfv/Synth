using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Synth.UI
{
    class FileDialog
    {
        private OpenFileDialog openFileDialog;
        private System.Xml.Serialization.XmlSerializer x;

        public FileDialog()
        {
            x = new System.Xml.Serialization.XmlSerializer(typeof(Preset));
            openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
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
            title = Regex.Replace(title, @"\s+", "");

            string presetFolder = SettingsConfig.getInstance().PresetsFolder;
            string path = presetFolder + "\\" + title + ".xml";
            if (File.Exists(path) )
            {
                DialogResult dialogResult = MessageBox.Show("You will overwrite existing preset.\nAre you sure?", "Warning!", MessageBoxButtons.YesNo);
                if(dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            FileStream file = File.Create(path);
            x.Serialize(file, p);
        }
    }
}
