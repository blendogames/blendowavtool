//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

using System.Diagnostics;
using System.Drawing.Text;

namespace BlendoWavTool2
{
    public partial class form_programpaths : Form
    {
        public form_programpaths()
        {
            InitializeComponent();

            textBox_pathPlayer.Text = Properties.Settings.Default.pathPlayer;
            textBox_pathEditor.Text = Properties.Settings.Default.pathEditor;
            textBox_soundfiletypes.Text = Properties.Settings.Default.soundfiletypes;

            if (!string.IsNullOrWhiteSpace(textBox_pathPlayer.Text))
            {
                textBox_pathPlayer.Select(textBox_pathPlayer.Text.Length, 0);
            }

            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            if (!DoesFileExist(textBox_pathPlayer.Text))
            {
                error += string.Format("ERROR: invalid player filepath:\n{0}\nPlease verify this file exists.\n\n", textBox_pathPlayer.Text);
            }
            if (!DoesFileExist(textBox_pathEditor.Text))
            {
                error += string.Format("ERROR: invalid editor filepath:\n{0}\nPlease verify this file exists.\n\n", textBox_pathEditor.Text);
            }

            if (string.IsNullOrWhiteSpace(textBox_soundfiletypes.Text))
            {
                error += "ERROR: sound filetypes is empty. Please add sound filetypes.";
            }

            if (!string.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error, "Error");
                return;
            }


            Properties.Settings.Default.pathPlayer = textBox_pathPlayer.Text;
            Properties.Settings.Default.pathEditor = textBox_pathEditor.Text;
            Properties.Settings.Default.soundfiletypes = textBox_soundfiletypes.Text;

            Properties.Settings.Default.Save();

            this.Close();
        }

        private bool DoesFileExist(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return true;
            }

            if (File.Exists(path))
            {
                return true;
            }

            return false;
        }





        private void button_viewPlayer_Click(object sender, EventArgs e)
        {
            OpenFolder(textBox_pathPlayer.Text);
        }

        private void button_viewEditor_Click(object sender, EventArgs e)
        {
            OpenFolder(textBox_pathEditor.Text);
        }

        private void OpenFolder(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("Filepath field is empty.", "Error");
                return;
            }

            if (!File.Exists(path))
            {
                string justDirectory = Path.GetDirectoryName(path);

                if (Directory.Exists(justDirectory))
                {
                    if (!justDirectory.EndsWith(Path.DirectorySeparatorChar))
                    {
                        justDirectory += Path.DirectorySeparatorChar;
                    }

                    Process.Start("explorer.exe", justDirectory);
                    return;
                }
                else
                {
                    MessageBox.Show("File doesn't exist.", "Error");
                    return;
                }
            }

            Process.Start("explorer.exe", $"/select,\"{path}\"");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_soundfiletypes.Text = "wav ogg mp3 flac opus";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("\"Sound filetypes\" determines what sound files to search for.\n\n• This is a list of file extensions. Example: wav mp3 ogg\n\n• Separate multiple entries with a space.\n\n• Do not include the period.");
        }
    }
}
