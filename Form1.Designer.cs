namespace BlendoWavTool2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            displayMaxAmplitudesToolStripMenuItem = new ToolStripMenuItem();
            detectSilenceatStartToolStripMenuItem = new ToolStripMenuItem();
            detectSilenceatEndToolStripMenuItem = new ToolStripMenuItem();
            checkForDuplicateFilesToolStripMenuItem = new ToolStripMenuItem();
            textBox_folderpath = new TextBox();
            label1 = new Label();
            splitContainer1 = new SplitContainer();
            label2 = new Label();
            textBox_folderfilter = new TextBox();
            label3 = new Label();
            textBox_filenamefilter = new TextBox();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            contextMenu_datagrid = new ContextMenuStrip(components);
            playToolStripMenuItem = new ToolStripMenuItem();
            openInEditorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            openFolderToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            listBox1 = new ListBox();
            contextMenu_log = new ContextMenuStrip(components);
            copySelectedLinesToClipboardToolStripMenuItem = new ToolStripMenuItem();
            copyEntireLogToClipboardToolStripMenuItem = new ToolStripMenuItem();
            clearLogToolStripMenuItem = new ToolStripMenuItem();
            splitContainer2 = new SplitContainer();
            label_totalrows = new Label();
            label_selectedrows = new Label();
            button1 = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenu_datagrid.SuspendLayout();
            contextMenu_log.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1284, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripSeparator1, aboutToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(116, 22);
            toolStripMenuItem1.Text = "Options";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(113, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(116, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(116, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { displayMaxAmplitudesToolStripMenuItem, detectSilenceatStartToolStripMenuItem, detectSilenceatEndToolStripMenuItem, checkForDuplicateFilesToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(46, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // displayMaxAmplitudesToolStripMenuItem
            // 
            displayMaxAmplitudesToolStripMenuItem.Name = "displayMaxAmplitudesToolStripMenuItem";
            displayMaxAmplitudesToolStripMenuItem.Size = new Size(201, 22);
            displayMaxAmplitudesToolStripMenuItem.Text = "Display max amplitudes";
            displayMaxAmplitudesToolStripMenuItem.Click += displayMaxAmplitudesToolStripMenuItem_Click;
            // 
            // detectSilenceatStartToolStripMenuItem
            // 
            detectSilenceatStartToolStripMenuItem.Name = "detectSilenceatStartToolStripMenuItem";
            detectSilenceatStartToolStripMenuItem.Size = new Size(201, 22);
            detectSilenceatStartToolStripMenuItem.Text = "Detect silence (at start)";
            detectSilenceatStartToolStripMenuItem.Click += detectSilenceatStartToolStripMenuItem_Click;
            // 
            // detectSilenceatEndToolStripMenuItem
            // 
            detectSilenceatEndToolStripMenuItem.Name = "detectSilenceatEndToolStripMenuItem";
            detectSilenceatEndToolStripMenuItem.Size = new Size(201, 22);
            detectSilenceatEndToolStripMenuItem.Text = "Detect silence (at end)";
            detectSilenceatEndToolStripMenuItem.Click += detectSilenceatEndToolStripMenuItem_Click;
            // 
            // checkForDuplicateFilesToolStripMenuItem
            // 
            checkForDuplicateFilesToolStripMenuItem.Name = "checkForDuplicateFilesToolStripMenuItem";
            checkForDuplicateFilesToolStripMenuItem.Size = new Size(201, 22);
            checkForDuplicateFilesToolStripMenuItem.Text = "Check for duplicate files";
            checkForDuplicateFilesToolStripMenuItem.Click += checkForDuplicateFilesToolStripMenuItem_Click;
            // 
            // textBox_folderpath
            // 
            textBox_folderpath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_folderpath.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_folderpath.Location = new Point(91, 27);
            textBox_folderpath.Name = "textBox_folderpath";
            textBox_folderpath.Size = new Size(1149, 23);
            textBox_folderpath.TabIndex = 1;
            textBox_folderpath.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 30);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 2;
            label1.Text = "Folder path:";
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 56);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(textBox_folderfilter);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(textBox_filenamefilter);
            splitContainer1.Size = new Size(1260, 39);
            splitContainer1.SplitterDistance = 630;
            splitContainer1.TabIndex = 3;
            splitContainer1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 11);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 1;
            label2.Text = "Folder filter:";
            // 
            // textBox_folderfilter
            // 
            textBox_folderfilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_folderfilter.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_folderfilter.Location = new Point(79, 3);
            textBox_folderfilter.Name = "textBox_folderfilter";
            textBox_folderfilter.Size = new Size(548, 30);
            textBox_folderfilter.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 11);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 1;
            label3.Text = "Filename filter:";
            // 
            // textBox_filenamefilter
            // 
            textBox_filenamefilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_filenamefilter.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_filenamefilter.Location = new Point(94, 3);
            textBox_filenamefilter.Name = "textBox_filenamefilter";
            textBox_filenamefilter.Size = new Size(529, 30);
            textBox_filenamefilter.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8 });
            dataGridView1.ContextMenuStrip = contextMenu_datagrid;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(3, 7);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(1254, 430);
            dataGridView1.TabIndex = 4;
            dataGridView1.TabStop = false;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.FillWeight = 55F;
            Column1.HeaderText = "Folder";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.FillWeight = 45F;
            Column2.HeaderText = "Filename";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column3.HeaderText = "Filetype";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 60;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column4.HeaderText = "Hz";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 60;
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column5.HeaderText = "Channels";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 70;
            // 
            // Column6
            // 
            Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column6.HeaderText = "Duration";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.ToolTipText = "duration in seconds.";
            Column6.Width = 60;
            // 
            // Column7
            // 
            Column7.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column7.HeaderText = "Filesize";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.ToolTipText = "filesize in kilobytes. 1000 kilobytes = 1 megabyte.";
            Column7.Width = 60;
            // 
            // Column8
            // 
            Column8.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Column8.HeaderText = "Other";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            Column8.Width = 200;
            // 
            // contextMenu_datagrid
            // 
            contextMenu_datagrid.Items.AddRange(new ToolStripItem[] { playToolStripMenuItem, openInEditorToolStripMenuItem, toolStripSeparator2, openFolderToolStripMenuItem, copyToolStripMenuItem });
            contextMenu_datagrid.Name = "contextMenu_datagrid";
            contextMenu_datagrid.Size = new Size(213, 98);
            // 
            // playToolStripMenuItem
            // 
            playToolStripMenuItem.Image = (Image)resources.GetObject("playToolStripMenuItem.Image");
            playToolStripMenuItem.Name = "playToolStripMenuItem";
            playToolStripMenuItem.Size = new Size(212, 22);
            playToolStripMenuItem.Text = "Play";
            playToolStripMenuItem.Click += playToolStripMenuItem_Click;
            // 
            // openInEditorToolStripMenuItem
            // 
            openInEditorToolStripMenuItem.Image = (Image)resources.GetObject("openInEditorToolStripMenuItem.Image");
            openInEditorToolStripMenuItem.Name = "openInEditorToolStripMenuItem";
            openInEditorToolStripMenuItem.Size = new Size(212, 22);
            openInEditorToolStripMenuItem.Text = "Edit";
            openInEditorToolStripMenuItem.Click += openInEditorToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(209, 6);
            // 
            // openFolderToolStripMenuItem
            // 
            openFolderToolStripMenuItem.Image = (Image)resources.GetObject("openFolderToolStripMenuItem.Image");
            openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            openFolderToolStripMenuItem.Size = new Size(212, 22);
            openFolderToolStripMenuItem.Text = "Open folder";
            openFolderToolStripMenuItem.Click += openFolderToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = (Image)resources.GetObject("copyToolStripMenuItem.Image");
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(212, 22);
            copyToolStripMenuItem.Text = "Copy filepath to clipboard";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.ContextMenuStrip = contextMenu_log;
            listBox1.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 14;
            listBox1.Location = new Point(3, 3);
            listBox1.Name = "listBox1";
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            listBox1.Size = new Size(1254, 88);
            listBox1.TabIndex = 5;
            listBox1.TabStop = false;
            // 
            // contextMenu_log
            // 
            contextMenu_log.Items.AddRange(new ToolStripItem[] { copySelectedLinesToClipboardToolStripMenuItem, copyEntireLogToClipboardToolStripMenuItem, clearLogToolStripMenuItem });
            contextMenu_log.Name = "contextMenu_log";
            contextMenu_log.Size = new Size(243, 70);
            // 
            // copySelectedLinesToClipboardToolStripMenuItem
            // 
            copySelectedLinesToClipboardToolStripMenuItem.Image = (Image)resources.GetObject("copySelectedLinesToClipboardToolStripMenuItem.Image");
            copySelectedLinesToClipboardToolStripMenuItem.Name = "copySelectedLinesToClipboardToolStripMenuItem";
            copySelectedLinesToClipboardToolStripMenuItem.Size = new Size(242, 22);
            copySelectedLinesToClipboardToolStripMenuItem.Text = "Copy selected lines to clipboard";
            copySelectedLinesToClipboardToolStripMenuItem.Click += copySelectedLinesToClipboardToolStripMenuItem_Click;
            // 
            // copyEntireLogToClipboardToolStripMenuItem
            // 
            copyEntireLogToClipboardToolStripMenuItem.Image = (Image)resources.GetObject("copyEntireLogToClipboardToolStripMenuItem.Image");
            copyEntireLogToClipboardToolStripMenuItem.Name = "copyEntireLogToClipboardToolStripMenuItem";
            copyEntireLogToClipboardToolStripMenuItem.Size = new Size(242, 22);
            copyEntireLogToClipboardToolStripMenuItem.Text = "Copy entire log to clipboard";
            copyEntireLogToClipboardToolStripMenuItem.Click += copyEntireLogToClipboardToolStripMenuItem_Click;
            // 
            // clearLogToolStripMenuItem
            // 
            clearLogToolStripMenuItem.Image = (Image)resources.GetObject("clearLogToolStripMenuItem.Image");
            clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            clearLogToolStripMenuItem.Size = new Size(242, 22);
            clearLogToolStripMenuItem.Text = "Clear log";
            clearLogToolStripMenuItem.Click += clearLogToolStripMenuItem_Click;
            // 
            // splitContainer2
            // 
            splitContainer2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer2.Location = new Point(12, 101);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(listBox1);
            splitContainer2.Size = new Size(1260, 540);
            splitContainer2.SplitterDistance = 440;
            splitContainer2.TabIndex = 6;
            splitContainer2.TabStop = false;
            // 
            // label_totalrows
            // 
            label_totalrows.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label_totalrows.AutoSize = true;
            label_totalrows.Location = new Point(12, 641);
            label_totalrows.Name = "label_totalrows";
            label_totalrows.Size = new Size(63, 15);
            label_totalrows.TabIndex = 7;
            label_totalrows.Text = "Total rows:";
            // 
            // label_selectedrows
            // 
            label_selectedrows.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label_selectedrows.AutoSize = true;
            label_selectedrows.Location = new Point(131, 641);
            label_selectedrows.Name = "label_selectedrows";
            label_selectedrows.Size = new Size(82, 15);
            label_selectedrows.TabIndex = 8;
            label_selectedrows.Text = "Selected rows:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(1244, 27);
            button1.Name = "button1";
            button1.Size = new Size(25, 23);
            button1.TabIndex = 9;
            button1.TabStop = false;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 661);
            Controls.Add(button1);
            Controls.Add(label_selectedrows);
            Controls.Add(label_totalrows);
            Controls.Add(splitContainer2);
            Controls.Add(splitContainer1);
            Controls.Add(label1);
            Controls.Add(textBox_folderpath);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blendo Wav Tool";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenu_datagrid.ResumeLayout(false);
            contextMenu_log.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private TextBox textBox_folderpath;
        private Label label1;
        private SplitContainer splitContainer1;
        private TextBox textBox_folderfilter;
        private Label label2;
        private Label label3;
        private TextBox textBox_filenamefilter;
        private DataGridView dataGridView1;
        private ListBox listBox1;
        private SplitContainer splitContainer2;
        private ToolStripMenuItem displayMaxAmplitudesToolStripMenuItem;
        private ToolStripMenuItem detectSilenceatStartToolStripMenuItem;
        private ToolStripMenuItem detectSilenceatEndToolStripMenuItem;
        private Label label_totalrows;
        private Label label_selectedrows;
        private ContextMenuStrip contextMenu_datagrid;
        private ToolStripMenuItem playToolStripMenuItem;
        private ToolStripMenuItem openInEditorToolStripMenuItem;
        private ToolStripMenuItem openFolderToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ContextMenuStrip contextMenu_log;
        private ToolStripMenuItem copySelectedLinesToClipboardToolStripMenuItem;
        private ToolStripMenuItem copyEntireLogToClipboardToolStripMenuItem;
        private ToolStripMenuItem clearLogToolStripMenuItem;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private ToolStripMenuItem checkForDuplicateFilesToolStripMenuItem;
        private Button button1;
    }
}
