using System.ComponentModel;
using System.Reflection;
using System.Diagnostics;

using System.Security.Cryptography;

using NAudio.Wave;

using TagLib;

namespace BlendoWavTool2
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 0x000B;

        enum COLUMNS
        {
            folderpath,
            filename,
            filetype,
            hz,
            channels,
            length,
            filesize,
            metadata
        };

        const int SILENCE_ANALYSIS_DURATION = 10000;
        const float SILENCE_THRESHOLD = 0.1f;

        DateTime start;
        int filesLoaded;

        WavFileInfo[] wavfileInfos;

        BackgroundWorker backgroundWorker;

        public Form1()
        {
            InitializeComponent();

            textBox_folderpath.Text = Properties.Settings.Default.soundfolder;

            textBox_folderfilter.TextChanged += TextBox_folderfilter_TextChanged;
            textBox_filenamefilter.TextChanged += TextBox_filenamefilter_TextChanged;

            textBox_folderpath.KeyDown += TextBox_folderpath_KeyDown;

            //This makes datagridview scroll much smoother/faster.
            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                Type dgvType = dataGridView1.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dataGridView1, true, null);
            }

            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            dataGridView1.CellMouseDown += DataGridView1_CellMouseDown;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;

            dataGridView1.Columns[(int)COLUMNS.length].DefaultCellStyle.Format = "N2";

            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);

            this.FormClosed += Form1_FormClosed;

            if (!string.IsNullOrWhiteSpace(textBox_folderpath.Text))
            {
                LoadSoundFolder(textBox_folderpath.Text);
            }
        }

        private void TextBox_folderpath_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                LoadSoundFolder(textBox_folderpath.Text);
            }
        }

        private void Form1_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.soundfolder = textBox_folderpath.Text;
            Properties.Settings.Default.Save();
        }

        private void DataGridView1_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;

            playToolStripMenuItem_Click(null, null);
        }

        private void DataGridView1_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.RowCount)
            {
                return;
            }

            dataGridView1.ClearSelection();
            dataGridView1.Rows[e.RowIndex].Selected = true;
            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }

        private void DataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            int selectedCount = dataGridView1.SelectedCells.Cast<DataGridViewCell>()
                                       .Select(c => c.RowIndex).Distinct().Count();

            label_selectedrows.Text = string.Format("Selected rows: {0}", selectedCount);
        }

        private void TextBox_filenamefilter_TextChanged(object? sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void TextBox_folderfilter_TextChanged(object? sender, EventArgs e)
        {
            RefreshGrid();
        }

        void LoadSoundFolder(string folderpath)
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += OnLoadSoundsDoWork;
            backgroundWorker.RunWorkerCompleted += OnLoadSoundsCompleted;
            backgroundWorker.RunWorkerAsync();
        }

        private void OnLoadSoundsDoWork(object sender, DoWorkEventArgs e)
        {
            start = DateTime.Now;

            //Gather up all of the sound files.
            string folderpath = textBox_folderpath.Text;
            DirectoryInfo dir = new DirectoryInfo(folderpath);
            if (!dir.Exists)
            {
                e.Cancel = true;

                AddLogInvoked("ERROR: folder not found:");
                AddLogInvoked(folderpath);

                return;
            }

            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.soundfiletypes))
            {
                AddLogInvoked("ERROR: sound filetypes is empty. Go to: File > Options");
                return;
            }

            string rawExtensions = Properties.Settings.Default.soundfiletypes;
            string[] extensions = rawExtensions.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < extensions.Length; i++)
            {
                extensions[i] = string.Format("*.{0}", extensions[i]);
            }

            IEnumerable<string> allfiles = Enumerable.Empty<string>();
            foreach (string ext in extensions)
            {
                allfiles = allfiles.Union(Directory.EnumerateFiles(folderpath, ext, SearchOption.AllDirectories));
            }

            string[] soundFiles = allfiles.ToArray();
            if (soundFiles.Length <= 0)
            {
                AddLogInvoked("No sound files found in folder.");
                return;
            }

            AddLogInvoked(string.Format("Loading {0} sound files. Searching for filetypes: {1}. Please wait...", soundFiles.Length, Properties.Settings.Default.soundfiletypes));

            List<WavFileInfo> wavlist = new List<WavFileInfo>();
            filesLoaded = 0;
            for (int i = 0; i < soundFiles.Length; i++)
            {
                TagLib.File tagFile = TagLib.File.Create(soundFiles[i], ReadStyle.Average);

                if (tagFile == null)
                {
                    AddLogInvoked("ERROR: failed to load: {0}", soundFiles[i]);
                    continue;
                }

                if (tagFile.Properties == null)
                {
                    AddLogInvoked("ERROR: file has no properties: {0}", soundFiles[i]);
                    continue;
                }

                FileInfo file = new FileInfo(soundFiles[i]);

                int filesize = (int)file.Length;

                float duration = (float)tagFile.Properties.Duration.TotalSeconds;

                string fileExtension = file.Extension;
                if (fileExtension.StartsWith("."))
                {
                    fileExtension = fileExtension.Remove(0, 1);
                }

                string folderName = file.DirectoryName;
                folderName = folderName.Replace(textBox_folderpath.Text, "", StringComparison.InvariantCultureIgnoreCase);
                if (folderName.StartsWith("\\"))
                {
                    folderName = folderName.Remove(0, 1);
                }

                WavFileInfo newwavinfo = new WavFileInfo();
                newwavinfo.folderpath = folderName;
                newwavinfo.filename = Path.GetFileNameWithoutExtension(soundFiles[i]);
                newwavinfo.filetype = fileExtension;
                newwavinfo.hz = tagFile.Properties.AudioSampleRate;
                newwavinfo.channels = tagFile.Properties.AudioChannels;
                newwavinfo.length = duration;
                newwavinfo.filesize = filesize;
                wavlist.Add(newwavinfo);

                filesLoaded++;
            }

            wavfileInfos = wavlist.ToArray();
        }

        private void OnLoadSoundsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.ClearSelection();
                return;                
            }

            RefreshGrid();

            TimeSpan delta = DateTime.Now.Subtract(start);
            float secondsLoadtime = (int)(delta.TotalMilliseconds) / (float)1000.0f;
            AddLogInvoked("Loaded  {0} sound files. Load time: {1} seconds.", filesLoaded.ToString(), secondsLoadtime.ToString("0.0"));
            AddLogInvoked(string.Empty);
        }

        void RefreshGrid()
        {
            //disable redrawing of the datagrid.
            SendMessage(dataGridView1.Handle, WM_SETREDRAW, false, 0);

            dataGridView1.Rows.Clear();
            dataGridView1.ClearSelection();

            string filenameFilter = textBox_filenamefilter.Text;
            string folderFilter = textBox_folderfilter.Text;

            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            if (wavfileInfos == null)
            {
                return;
            }

            if (wavfileInfos.Length <= 0)
            {
                return;
            }

            for (int i = 0; i < wavfileInfos.Count(); i++)
            {
                if (!FitsFilter(wavfileInfos[i].filename, filenameFilter))
                    continue;

                if (!FitsFilter(wavfileInfos[i].folderpath, folderFilter))
                    continue;

                float displayFilesize = wavfileInfos[i].filesize;
                displayFilesize /= 1000.0f;
                displayFilesize = (float)Math.Round(displayFilesize, 0);

                //Populate the data grid fields.
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[(int)COLUMNS.folderpath].Value = wavfileInfos[i].folderpath;
                row.Cells[(int)COLUMNS.filename].Value = wavfileInfos[i].filename;
                row.Cells[(int)COLUMNS.filetype].Value = wavfileInfos[i].filetype;
                row.Cells[(int)COLUMNS.hz].Value = wavfileInfos[i].hz;
                row.Cells[(int)COLUMNS.channels].Value = wavfileInfos[i].channels;
                row.Cells[(int)COLUMNS.length].Value = wavfileInfos[i].length;
                row.Cells[(int)COLUMNS.filesize].Value = displayFilesize;
                row.Cells[(int)COLUMNS.metadata].Value = string.Empty;
                rows.Add(row);
            }

            dataGridView1.Rows.AddRange(rows.ToArray());

            //re-enable redrawing of the datagrid.
            SendMessage(dataGridView1.Handle, WM_SETREDRAW, true, 0);
            dataGridView1.Refresh();

            label_totalrows.Text = string.Format("Total rows: {0}", rows.Count.ToString());
        }

        private bool FitsFilter(string _text, string _filter)
        {
            if (string.IsNullOrWhiteSpace(_filter))
                return true;

            string[] filterArray = _filter.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < filterArray.Length; i++)
            {
                if (_text.IndexOf(filterArray[i], StringComparison.InvariantCultureIgnoreCase) < 0)
                    return false;
            }

            return true;
        }


        private void AddLogInvoked(string text, params string[] args)
        {
            System.Windows.Forms.MethodInvoker mi = delegate () { AddLog(text, args); };
            this.Invoke(mi);
        }

        private void AddLog(string text, params string[] args)
        {
            listBox1.Items.Add(string.Format(text, args));

            int nItems = (int)(listBox1.Height / listBox1.ItemHeight);
            listBox1.TopIndex = listBox1.Items.Count - nItems;

        }

        private void displayMaxAmplitudesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLog("---- Determining max amplitudes for {0} files. Please wait ----", dataGridView1.RowCount.ToString());
            this.Update();
            this.Refresh();

            float globalMax = -1;
            float globalMin = 1;

            List<float> medianList = new List<float>();
            float totalamount = 0;
            for (int k = 0; k < dataGridView1.RowCount - 1; k++)
            {
                float max = 0;
                string filename = string.Format("{0}.{1}", dataGridView1.Rows[k].Cells[(int)COLUMNS.filename].Value.ToString(), dataGridView1.Rows[k].Cells[(int)COLUMNS.filetype].Value.ToString());
                var inPath = Path.Combine(textBox_folderpath.Text, dataGridView1.Rows[k].Cells[(int)COLUMNS.folderpath].Value.ToString(), filename);
                using (var reader = new NAudio.Wave.AudioFileReader(inPath))
                {
                    // find the max peak
                    float[] buffer = new float[reader.WaveFormat.SampleRate];
                    int read;
                    do
                    {
                        read = reader.Read(buffer, 0, buffer.Length);
                        for (int n = 0; n < read; n++)
                        {
                            var abs = Math.Abs(buffer[n]);
                            if (abs > max)
                            {
                                max = abs;
                            }
                        }
                    }
                    while (read > 0);

                    dataGridView1.Rows[k].Cells[(int)COLUMNS.metadata].Value = string.Format("Peak: {0}", max.ToString("N2"));

                    if (max > globalMax)
                        globalMax = max;

                    if (max < globalMin)
                        globalMin = max;

                    totalamount += max;

                    medianList.Add(max);
                }
            }

            float average = totalamount / (float)dataGridView1.RowCount;

            medianList.Sort();
            float median = medianList[medianList.Count / 2];

            AddLog("Done.  Max={0}  Min={1}  Average={2}  Median={3}", globalMax.ToString("N4"), globalMin.ToString("N4"), average.ToString("N4"), median.ToString("N4"));
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Blendo Wav Tool\nby Brendon Chung\n\nAudio asset helper tool. Used to browse, find, and hear audio assets.\n\n• Double-click to play sound.\n\n• Drag sound files into window to automatically copy/overwrite existing sound files. Will automatically find correct subfolders.",
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void detectSilenceatStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLog("---- Determining start silence for {0} files, please wait ----", dataGridView1.RowCount.ToString());
            this.Update();
            this.Refresh();

            int silenceCount = 0;
            for (int k = 0; k <= dataGridView1.RowCount - 1; k++)
            {
                string filename = string.Format("{0}.{1}", dataGridView1.Rows[k].Cells[(int)COLUMNS.filename].Value.ToString(), dataGridView1.Rows[k].Cells[(int)COLUMNS.filetype].Value.ToString());
                var inPath = Path.Combine(textBox_folderpath.Text, dataGridView1.Rows[k].Cells[(int)COLUMNS.folderpath].Value.ToString(), filename);
                using (var reader = new AudioFileReader(inPath))
                {
                    bool isSilent = true;

                    // find the max peak
                    float[] buffer = new float[reader.WaveFormat.SampleRate];
                    int read;
                    do
                    {
                        read = reader.Read(buffer, 0, buffer.Length);
                        read = Math.Min(read, SILENCE_ANALYSIS_DURATION);
                        for (int n = 0; n < read; n++)
                        {
                            if (Math.Abs(buffer[n]) >= SILENCE_THRESHOLD)
                            {
                                isSilent = false;
                                break;
                            }
                        }
                    }
                    while (read > 0);

                    dataGridView1.Rows[k].Cells[(int)COLUMNS.metadata].Value = string.Format("Start silence: {0}", isSilent ? "YES" : "NO");

                    if (isSilent)
                    {
                        silenceCount++;
                    }
                }
            }

            AddLog("Done. Silences found: {0}", silenceCount.ToString());
        }

        private void detectSilenceatEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLog("---- Determining end silence for {0} files, please wait ----", dataGridView1.RowCount.ToString());
            this.Update();
            this.Refresh();

            int silenceCount = 0;
            for (int k = 0; k <= dataGridView1.RowCount - 1; k++)
            {
                string filename = string.Format("{0}.{1}", dataGridView1.Rows[k].Cells[(int)COLUMNS.filename].Value.ToString(), dataGridView1.Rows[k].Cells[(int)COLUMNS.filetype].Value.ToString());
                var inPath = Path.Combine(textBox_folderpath.Text, dataGridView1.Rows[k].Cells[(int)COLUMNS.folderpath].Value.ToString(), filename);
                using (var reader = new AudioFileReader(inPath))
                {
                    bool isSilent = true;

                    // find the max peak
                    float[] buffer = new float[reader.WaveFormat.SampleRate];
                    int read;
                    do
                    {
                        read = reader.Read(buffer, 0, buffer.Length);
                        int startReadValue = Math.Max(read - SILENCE_ANALYSIS_DURATION, 0);
                        for (int n = startReadValue; n < read; n++)
                        {
                            if (Math.Abs(buffer[n]) >= SILENCE_THRESHOLD)
                            {
                                isSilent = false;
                                break;
                            }
                        }
                    }
                    while (read > 0);

                    dataGridView1.Rows[k].Cells[(int)COLUMNS.metadata].Value = string.Format("End silence: {0}", isSilent ? "YES" : "NO");

                    if (isSilent)
                        silenceCount++;
                }
            }

            AddLog("Done. Silences found: {0}", silenceCount.ToString());

        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.pathPlayer))
            {
                AddLog("No program set to play sounds.\n\nSet player in: File > Options");
                return;
            }

            if (!System.IO.File.Exists(Properties.Settings.Default.pathPlayer))
            {
                AddLog("Cannot find player:\n{0}\n\nSet player in: File > Options", Properties.Settings.Default.pathPlayer);
                return;
            }

            StartProgramOnFile(Properties.Settings.Default.pathPlayer, GetSelectedFullpath());
        }

        private void openInEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.pathEditor))
            {
                AddLog("No program set to edit sounds.\n\nSet player in: File > Options");
                return;
            }

            if (!System.IO.File.Exists(Properties.Settings.Default.pathEditor))
            {
                AddLog("Cannot find editor:\n{0}\n\nSet editor in: File > Options", Properties.Settings.Default.pathEditor);
                return;
            }

            StartProgramOnFile(Properties.Settings.Default.pathEditor, GetSelectedFullpath());
        }

        private void StartProgramOnFile(string executablePath, string arguments)
        {
            if (string.IsNullOrWhiteSpace(arguments))
            {
                AddLogInvoked("Error: no argument found.");
                return;
            }

            arguments = string.Format($"\"{arguments}\""); //add quotes to handle any spaces in the path

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = executablePath;
            startInfo.Arguments = arguments;
            Process proc = new Process();

            try
            {
                proc.StartInfo = startInfo;
                proc.Start();
            }
            catch (Exception err)
            {
                AddLogInvoked(err.Message);
            }
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fullpath = GetSelectedFullpath();

            if (string.IsNullOrWhiteSpace(fullpath))
                return;

            Process.Start("explorer.exe", $"/select,\"{fullpath}\"");
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fullpath = GetSelectedFullpath();

            if (string.IsNullOrWhiteSpace(fullpath))
                return;

            Clipboard.SetText(fullpath);
        }

        //Get filepath of the selected row. If multiple rows, just get filepath of first one.
        private string GetSelectedFullpath()
        {
            if (dataGridView1.SelectedCells.Count <= 0)
            {
                return string.Empty;
            }

            int selectedRow = dataGridView1.SelectedCells[0].RowIndex;

            string filename = string.Format("{0}.{1}", dataGridView1.Rows[selectedRow].Cells[(int)COLUMNS.filename].Value.ToString(), dataGridView1.Rows[selectedRow].Cells[(int)COLUMNS.filetype].Value.ToString());
            string fullpath = Path.Combine(textBox_folderpath.Text, dataGridView1.Rows[selectedRow].Cells[(int)COLUMNS.folderpath].Value.ToString(), filename);

            return fullpath;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            form_programpaths programPathForm = new form_programpaths();
            programPathForm.ShowDialog();
        }

        private void copySelectedLinesToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Copy selected to log.
            listBox1.BackColor = Color.White;

            string output = string.Empty;

            foreach (object item in listBox1.SelectedItems)
            {
                output += item.ToString() + "\r\n";
            }

            if (string.IsNullOrWhiteSpace(output))
            {
                return;
            }

            Clipboard.SetText(output);
        }

        private void copyEntireLogToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Copy entire log.
            listBox1.BackColor = Color.White;

            string output = string.Empty;

            foreach (object item in listBox1.Items)
                output += item.ToString() + "\r\n";

            if (string.IsNullOrWhiteSpace(output))
            {
                AddLog(string.Empty);
                AddLog("No log found.");
                return;
            }

            Clipboard.SetText(output);
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clear log.
            listBox1.Items.Clear();
            listBox1.BackColor = Color.White;
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.FileDrop))
            //{
            //    var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            //}

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            AddLog(string.Empty);
            AddLog("---- Dragged in {0} files ----", files.Length.ToString());

            //we now have a list of files that were dragged in.
            //now we iterate through them to find the files that we want to overwrite.

            //string[] wavFiles = System.IO.Directory.GetFiles(textBox1.Text, "*.wav", System.IO.SearchOption.AllDirectories);

            List<string> tmpList = new List<string>();
            for (int i = 0; i < wavfileInfos.Length; i++)
            {
                string path = Path.Combine(textBox_folderpath.Text, wavfileInfos[i].folderpath, string.Format("{0}.{1}", wavfileInfos[i].filename, wavfileInfos[i].filetype));
                tmpList.Add(path);
            }


            string[] wavFiles = tmpList.ToArray();



            int filesOverwritten = 0;
            int errors = 0;
            for (int i = 0; i < files.Length; i++)
            {
                FileAttributes attr = System.IO.File.GetAttributes(files[i]);

                if (attr.HasFlag(FileAttributes.Directory))
                {
                    AddLog("ERROR: cannot parse folders ('{0}'). Only drag files here.", files[i]);
                    errors++;
                    continue;
                }

                FileInfo currentfile = new FileInfo(files[i]);

                int[] fileIndexes = FindExistingFile(currentfile.Name, wavFiles);

                if (fileIndexes.Length <= 0)
                {
                    //Error. CANNOT FIND THE FILE.
                    AddLog("ERROR: cannot find existing '{0}'", currentfile.Name);
                    errors++;
                }
                else if (fileIndexes.Length >= 2)
                {
                    //Error. MULTIPLE INSTANCES.
                    AddLog("ERROR: multiple instances of '{0}'", currentfile.Name);
                    for (int k = 0; k < fileIndexes.Length; k++)
                    {
                        int index = fileIndexes[k];
                        AddLog(">> {0}", wavFiles[index]);
                    }
                    errors++;
                }
                else
                {
                    //Success. Copy and overwrite the file.
                    int index = fileIndexes[0];
                    try
                    {
                        currentfile.CopyTo(wavFiles[index], true);
                        AddLog("     Copying: {0} -> {1}", currentfile.Name, Path.GetDirectoryName(wavFiles[index]));
                    }
                    catch (Exception ee)
                    {
                        AddLog("ERROR: failed to copy file '{0}' (error: '{1}')", currentfile.Name, ee.Message);
                        errors++;
                        continue;
                    }

                    filesOverwritten++;
                }
            }

            if (errors > 0)
            {
                AddLog("============== {0} ERRORS (see above) ==============", errors.ToString());
            }

            AddLog("Done. {0} files copied.", filesOverwritten.ToString());
        }

        int[] FindExistingFile(string filename, string[] allFiles)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < allFiles.Length; i++)
            {
                FileInfo existingFile = new FileInfo(allFiles[i]);

                if (string.Compare(filename, existingFile.Name, true) == 0)
                {
                    //Match.
                    indexes.Add(i);
                }
            }

            return indexes.ToArray();
        }

        private void checkForDuplicateFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLog("---- Checking for duplicate files. Please wait ----");
            this.Update();
            this.Refresh();

            int counter = 0;

            List<int> allMatches = new List<int>();

            for (int i = 0; i < wavfileInfos.Length; i++)
            {
                if (allMatches.Contains(i)) //this is so we don't check files that we already know are matches.
                    continue;

                int[] matches = FindFilesizeMatch(i);

                if (matches.Length <= 0)
                    continue; //no matches.

                AddLog("Duplicate file set #{0}:", (counter + 1).ToString());

                AddLog("    {0}", Path.Combine(wavfileInfos[i].folderpath, wavfileInfos[i].filename));
                for (int k = 0; k < matches.Length; k++)
                {
                    int matchIndex = matches[k];
                    AddLog("    {0}", Path.Combine(wavfileInfos[matchIndex].folderpath, wavfileInfos[matchIndex].filename));
                }
                AddLog(string.Empty);

                counter++;

                allMatches.AddRange(matches);
            }

            AddLog("---- Done. Found {0} duplicate files ----", counter.ToString());
        }

        private int[] FindFilesizeMatch(int currentIndex)
        {
            List<int> matches = new List<int>();

            int fileSize = wavfileInfos[currentIndex].filesize;

            byte[] currentHash = null;

            for (int k = 0; k < wavfileInfos.Length; k++)
            {
                if (currentIndex == k)
                {
                    continue; //don't compare to self.
                }

                //first do a filesize check, just as a quick check to filter out obvious non-duplicate sounds
                if (wavfileInfos[k].filesize != fileSize)
                {
                    continue; //no filesize match. early exit.
                }

                //ok, filesize matches. now do an expensive hash check.

                if (currentHash == null)
                {
                    currentHash = GetHash(GetFullPathOfIndex(currentIndex));
                }

                byte[] thisHash = GetHash(GetFullPathOfIndex(k));

                if (!currentHash.SequenceEqual(thisHash))
                    continue;

                matches.Add(k);
            }

            return matches.ToArray();
        }

        string GetFullPathOfIndex(int index)
        {
            string filename = string.Format("{0}.{1}", dataGridView1.Rows[index].Cells[(int)COLUMNS.filename].Value.ToString(), dataGridView1.Rows[index].Cells[(int)COLUMNS.filetype].Value.ToString());
            string fullpath = Path.Combine(textBox_folderpath.Text, dataGridView1.Rows[index].Cells[(int)COLUMNS.folderpath].Value.ToString(), filename);

            return fullpath;
        }


        byte[] GetHash(string filepath)
        {
            using var sha256 = SHA256.Create();
            using var stream = System.IO.File.OpenRead(filepath);
            byte[] hash = sha256.ComputeHash(stream);
            return hash;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rootFolder = string.Empty;
            if (!string.IsNullOrWhiteSpace(textBox_folderpath.Text))
            {
                if (Directory.Exists(textBox_folderpath.Text))
                {
                    rootFolder = textBox_folderpath.Text;
                }                
            }

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select folder";
                
                if (!string.IsNullOrWhiteSpace(rootFolder))
                {
                    folderDialog.InitialDirectory = rootFolder;
                }

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox_folderpath.Text = folderDialog.SelectedPath;
                    LoadSoundFolder(textBox_folderpath.Text);
                }
            }
        }
    }



    struct WavFileInfo
    {
        public string folderpath;
        public string filename;
        public string filetype;
        public int hz;
        public int channels;
        public float length;
        public int filesize;
        public string metadata;
    }
}
