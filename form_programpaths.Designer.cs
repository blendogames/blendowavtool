namespace BlendoWavTool2
{
    partial class form_programpaths
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox_pathPlayer = new TextBox();
            label1 = new Label();
            textBox_pathEditor = new TextBox();
            label2 = new Label();
            button1 = new Button();
            button_viewPlayer = new Button();
            button_viewEditor = new Button();
            textBox_soundfiletypes = new TextBox();
            button2 = new Button();
            label3 = new Label();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // textBox_pathPlayer
            // 
            textBox_pathPlayer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_pathPlayer.Font = new Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_pathPlayer.Location = new Point(140, 12);
            textBox_pathPlayer.Name = "textBox_pathPlayer";
            textBox_pathPlayer.Size = new Size(477, 25);
            textBox_pathPlayer.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 1;
            label1.Text = "Sound player filepath:";
            // 
            // textBox_pathEditor
            // 
            textBox_pathEditor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_pathEditor.Font = new Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_pathEditor.Location = new Point(140, 43);
            textBox_pathEditor.Name = "textBox_pathEditor";
            textBox_pathEditor.Size = new Size(477, 25);
            textBox_pathEditor.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 48);
            label2.Name = "label2";
            label2.Size = new Size(121, 15);
            label2.TabIndex = 3;
            label2.Text = "Sound editor filepath:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(515, 132);
            button1.Name = "button1";
            button1.Size = new Size(157, 33);
            button1.TabIndex = 4;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button_viewPlayer
            // 
            button_viewPlayer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_viewPlayer.Location = new Point(623, 12);
            button_viewPlayer.Name = "button_viewPlayer";
            button_viewPlayer.Size = new Size(49, 25);
            button_viewPlayer.TabIndex = 1;
            button_viewPlayer.Text = "View";
            button_viewPlayer.UseVisualStyleBackColor = true;
            button_viewPlayer.Click += button_viewPlayer_Click;
            // 
            // button_viewEditor
            // 
            button_viewEditor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_viewEditor.Location = new Point(623, 43);
            button_viewEditor.Name = "button_viewEditor";
            button_viewEditor.Size = new Size(49, 25);
            button_viewEditor.TabIndex = 3;
            button_viewEditor.Text = "View";
            button_viewEditor.UseVisualStyleBackColor = true;
            button_viewEditor.Click += button_viewEditor_Click;
            // 
            // textBox_soundfiletypes
            // 
            textBox_soundfiletypes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_soundfiletypes.Font = new Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_soundfiletypes.Location = new Point(140, 91);
            textBox_soundfiletypes.Name = "textBox_soundfiletypes";
            textBox_soundfiletypes.Size = new Size(477, 25);
            textBox_soundfiletypes.TabIndex = 5;
            textBox_soundfiletypes.Text = "wav ogg mp3 flac opus";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(623, 91);
            button2.Name = "button2";
            button2.Size = new Size(49, 25);
            button2.TabIndex = 6;
            button2.Text = "Reset";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 96);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 7;
            label3.Text = "Sound filetypes:";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.Location = new Point(21, 92);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(24, 20);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = " ? ";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // form_programpaths
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 177);
            Controls.Add(linkLabel1);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(textBox_soundfiletypes);
            Controls.Add(button_viewEditor);
            Controls.Add(button_viewPlayer);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox_pathEditor);
            Controls.Add(label1);
            Controls.Add(textBox_pathPlayer);
            MinimumSize = new Size(300, 216);
            Name = "form_programpaths";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Options";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_pathPlayer;
        private Label label1;
        private TextBox textBox_pathEditor;
        private Label label2;
        private Button button1;
        private Button button_viewPlayer;
        private Button button_viewEditor;
        private TextBox textBox_soundfiletypes;
        private Button button2;
        private Label label3;
        private LinkLabel linkLabel1;
    }
}