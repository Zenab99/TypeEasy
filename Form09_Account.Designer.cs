namespace type_easy
{
    partial class Form09_Account
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form09_Account));
            this.usrnameLabel = new System.Windows.Forms.Label();
            this.inputRichTextBox = new System.Windows.Forms.TextBox();
            this.AvatarLabel = new System.Windows.Forms.Label();
            this.AvatarButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.LevelNoLabel = new System.Windows.Forms.Label();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.GoalLabel = new System.Windows.Forms.Label();
            this.GoalNoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usrnameLabel
            // 
            resources.ApplyResources(this.usrnameLabel, "usrnameLabel");
            this.usrnameLabel.Name = "usrnameLabel";
            // 
            // inputRichTextBox
            // 
            resources.ApplyResources(this.inputRichTextBox, "inputRichTextBox");
            this.inputRichTextBox.Name = "inputRichTextBox";
            this.inputRichTextBox.TextChanged += new System.EventHandler(this.inputRichTextBox_TextChanged);
            // 
            // AvatarLabel
            // 
            resources.ApplyResources(this.AvatarLabel, "AvatarLabel");
            this.AvatarLabel.Name = "AvatarLabel";
            // 
            // AvatarButton
            // 
            resources.ApplyResources(this.AvatarButton, "AvatarButton");
            this.AvatarButton.Name = "AvatarButton";
            this.AvatarButton.UseVisualStyleBackColor = true;
            this.AvatarButton.Click += new System.EventHandler(this.AvatarButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // LevelNoLabel
            // 
            resources.ApplyResources(this.LevelNoLabel, "LevelNoLabel");
            this.LevelNoLabel.ForeColor = System.Drawing.Color.Red;
            this.LevelNoLabel.Name = "LevelNoLabel";
            this.LevelNoLabel.Tag = "";
            // 
            // LevelLabel
            // 
            resources.ApplyResources(this.LevelLabel, "LevelLabel");
            this.LevelLabel.Name = "LevelLabel";
            // 
            // GoalLabel
            // 
            resources.ApplyResources(this.GoalLabel, "GoalLabel");
            this.GoalLabel.Name = "GoalLabel";
            // 
            // GoalNoLabel
            // 
            resources.ApplyResources(this.GoalNoLabel, "GoalNoLabel");
            this.GoalNoLabel.ForeColor = System.Drawing.Color.Blue;
            this.GoalNoLabel.Name = "GoalNoLabel";
            this.GoalNoLabel.Tag = "";
            // 
            // Form09_Account
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.GoalNoLabel);
            this.Controls.Add(this.GoalLabel);
            this.Controls.Add(this.LevelNoLabel);
            this.Controls.Add(this.LevelLabel);
            this.Controls.Add(this.AvatarButton);
            this.Controls.Add(this.AvatarLabel);
            this.Controls.Add(this.inputRichTextBox);
            this.Controls.Add(this.usrnameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form09_Account";
            this.Deactivate += new System.EventHandler(this.Form09_Account_Deactivate);
            this.Load += new System.EventHandler(this.Form09_Account_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usrnameLabel;
        private System.Windows.Forms.TextBox inputRichTextBox;
        private System.Windows.Forms.Label AvatarLabel;
        private System.Windows.Forms.Button AvatarButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label LevelNoLabel;
        private System.Windows.Forms.Label LevelLabel;
        private System.Windows.Forms.Label GoalLabel;
        private System.Windows.Forms.Label GoalNoLabel;
    }
}