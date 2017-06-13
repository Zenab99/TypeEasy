namespace type_easy
{
    partial class Form04_Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form04_Welcome));
            this.WelcomeTextBox = new System.Windows.Forms.TextBox();
            this.AimRichTextBox = new System.Windows.Forms.RichTextBox();
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WelcomeTextBox
            // 
            resources.ApplyResources(this.WelcomeTextBox, "WelcomeTextBox");
            this.WelcomeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WelcomeTextBox.ForeColor = System.Drawing.Color.Red;
            this.WelcomeTextBox.Name = "WelcomeTextBox";
            // 
            // AimRichTextBox
            // 
            resources.ApplyResources(this.AimRichTextBox, "AimRichTextBox");
            this.AimRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AimRichTextBox.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.AimRichTextBox.Name = "AimRichTextBox";
            // 
            // InstructionLabel
            // 
            resources.ApplyResources(this.InstructionLabel, "InstructionLabel");
            this.InstructionLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionLabel.Name = "InstructionLabel";
            // 
            // Form04_Welcome
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.InstructionLabel);
            this.Controls.Add(this.AimRichTextBox);
            this.Controls.Add(this.WelcomeTextBox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form04_Welcome";
            this.Load += new System.EventHandler(this.Form04_Welcome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox WelcomeTextBox;
        private System.Windows.Forms.RichTextBox AimRichTextBox;
        private System.Windows.Forms.Label InstructionLabel;
    }
}