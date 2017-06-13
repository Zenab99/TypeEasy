namespace type_easy
{
    partial class Form02_setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form02_setting));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.musicButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RestartLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.HelpButton = new System.Windows.Forms.Button();
            this.LanguagecomboBox = new System.Windows.Forms.ComboBox();
            this.LanguagepictureBox = new System.Windows.Forms.PictureBox();
            this.ResetpictureBox = new System.Windows.Forms.PictureBox();
            this.ResetScoreButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.InfopictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.titleLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LanguagepictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResetpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfopictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // musicButton
            // 
            this.musicButton.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.musicButton, "musicButton");
            this.musicButton.FlatAppearance.BorderSize = 0;
            this.musicButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.musicButton.Name = "musicButton";
            this.musicButton.UseVisualStyleBackColor = false;
            this.musicButton.Click += new System.EventHandler(this.musicButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.RestartLabel);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.HelpButton);
            this.panel1.Controls.Add(this.LanguagecomboBox);
            this.panel1.Controls.Add(this.LanguagepictureBox);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.ResetpictureBox);
            this.panel1.Controls.Add(this.ResetScoreButton);
            this.panel1.Controls.Add(this.infoLabel);
            this.panel1.Controls.Add(this.InfopictureBox);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.musicButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // RestartLabel
            // 
            resources.ApplyResources(this.RestartLabel, "RestartLabel");
            this.RestartLabel.Name = "RestartLabel";
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // HelpButton
            // 
            this.HelpButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.HelpButton, "HelpButton");
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // LanguagecomboBox
            // 
            this.LanguagecomboBox.FormattingEnabled = true;
            this.LanguagecomboBox.Items.AddRange(new object[] {
            resources.GetString("LanguagecomboBox.Items"),
            resources.GetString("LanguagecomboBox.Items1")});
            resources.ApplyResources(this.LanguagecomboBox, "LanguagecomboBox");
            this.LanguagecomboBox.Name = "LanguagecomboBox";
            this.LanguagecomboBox.SelectedIndexChanged += new System.EventHandler(this.LanguagecomboBox_SelectedIndexChanged);
            // 
            // LanguagepictureBox
            // 
            resources.ApplyResources(this.LanguagepictureBox, "LanguagepictureBox");
            this.LanguagepictureBox.Name = "LanguagepictureBox";
            this.LanguagepictureBox.TabStop = false;
            // 
            // ResetpictureBox
            // 
            resources.ApplyResources(this.ResetpictureBox, "ResetpictureBox");
            this.ResetpictureBox.Name = "ResetpictureBox";
            this.ResetpictureBox.TabStop = false;
            // 
            // ResetScoreButton
            // 
            this.ResetScoreButton.BackColor = System.Drawing.Color.Transparent;
            this.ResetScoreButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.ResetScoreButton, "ResetScoreButton");
            this.ResetScoreButton.Name = "ResetScoreButton";
            this.ResetScoreButton.UseVisualStyleBackColor = false;
            this.ResetScoreButton.Click += new System.EventHandler(this.ResetScoreButton_Click);
            // 
            // infoLabel
            // 
            resources.ApplyResources(this.infoLabel, "infoLabel");
            this.infoLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Click += new System.EventHandler(this.infoLabel_Click);
            // 
            // InfopictureBox
            // 
            resources.ApplyResources(this.InfopictureBox, "InfopictureBox");
            this.InfopictureBox.Name = "InfopictureBox";
            this.InfopictureBox.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.Name = "titleLabel";
            // 
            // Form02_setting
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form02_setting";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.Form2_Deactivate);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LanguagepictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResetpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfopictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button musicButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.PictureBox InfopictureBox;
        private System.Windows.Forms.Button ResetScoreButton;
        private System.Windows.Forms.ComboBox LanguagecomboBox;
        private System.Windows.Forms.PictureBox LanguagepictureBox;
        private System.Windows.Forms.PictureBox ResetpictureBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.Label RestartLabel;
    }
}