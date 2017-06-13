namespace type_easy
{
    partial class Form08_theme
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form08_theme));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageAccordion1 = new ImageControls.ImageAccordion();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ImageButton = new System.Windows.Forms.Button();
            this.colorDlgButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, resources.GetString("pictureBox1.ToolTip"));
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // imageAccordion1
            // 
            resources.ApplyResources(this.imageAccordion1, "imageAccordion1");
            this.imageAccordion1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageAccordion1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imageAccordion1.HoverColor = System.Drawing.Color.Purple;
            this.imageAccordion1.Name = "imageAccordion1";
            this.imageAccordion1.SelectedColor = System.Drawing.Color.DarkBlue;
            this.toolTip1.SetToolTip(this.imageAccordion1, resources.GetString("imageAccordion1.ToolTip"));
            this.imageAccordion1.ThumbnailChanged += new ImageControls.ImageAccordion.ThumbnailChangedDelegate(this.imageAccordion1_ThumbnailChanged);
            // 
            // ImageButton
            // 
            resources.ApplyResources(this.ImageButton, "ImageButton");
            this.ImageButton.Name = "ImageButton";
            this.toolTip1.SetToolTip(this.ImageButton, resources.GetString("ImageButton.ToolTip"));
            this.ImageButton.UseVisualStyleBackColor = true;
            this.ImageButton.Click += new System.EventHandler(this.ImageButton_Click);
            // 
            // colorDlgButton
            // 
            resources.ApplyResources(this.colorDlgButton, "colorDlgButton");
            this.colorDlgButton.Name = "colorDlgButton";
            this.toolTip1.SetToolTip(this.colorDlgButton, resources.GetString("colorDlgButton.ToolTip"));
            this.colorDlgButton.UseVisualStyleBackColor = true;
            this.colorDlgButton.Click += new System.EventHandler(this.colorDlgButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // Form08_theme
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.colorDlgButton);
            this.Controls.Add(this.ImageButton);
            this.Controls.Add(this.imageAccordion1);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form08_theme";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Deactivate += new System.EventHandler(this.Form8_theme_Deactivate);
            this.Load += new System.EventHandler(this.Form8_theme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private ImageControls.ImageAccordion imageAccordion1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ImageButton;
        private System.Windows.Forms.Button colorDlgButton;
    }
}