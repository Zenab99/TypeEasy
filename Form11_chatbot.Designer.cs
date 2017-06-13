namespace type_easy
{
    partial class Form11_chatbot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form11_chatbot));
            this.label1 = new System.Windows.Forms.Label();
            this.BotRichTextBox = new System.Windows.Forms.RichTextBox();
            this.UsrLabel = new System.Windows.Forms.Label();
            this.UsrRichTextBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // BotRichTextBox
            // 
            resources.ApplyResources(this.BotRichTextBox, "BotRichTextBox");
            this.BotRichTextBox.ForeColor = System.Drawing.Color.HotPink;
            this.BotRichTextBox.Name = "BotRichTextBox";
            this.BotRichTextBox.TextChanged += new System.EventHandler(this.BotRichTextBox_TextChanged);
            // 
            // UsrLabel
            // 
            resources.ApplyResources(this.UsrLabel, "UsrLabel");
            this.UsrLabel.Name = "UsrLabel";
            this.UsrLabel.Click += new System.EventHandler(this.UsrLabel_Click);
            // 
            // UsrRichTextBox
            // 
            resources.ApplyResources(this.UsrRichTextBox, "UsrRichTextBox");
            this.UsrRichTextBox.ForeColor = System.Drawing.Color.HotPink;
            this.UsrRichTextBox.Name = "UsrRichTextBox";
            this.UsrRichTextBox.TextChanged += new System.EventHandler(this.UsrRichTextBox_TextChanged);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HelpButton
            // 
            resources.ApplyResources(this.HelpButton, "HelpButton");
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // Form11_chatbot
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UsrRichTextBox);
            this.Controls.Add(this.UsrLabel);
            this.Controls.Add(this.BotRichTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form11_chatbot";
            this.Load += new System.EventHandler(this.Form11_chatbot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox BotRichTextBox;
        private System.Windows.Forms.Label UsrLabel;
        private System.Windows.Forms.RichTextBox UsrRichTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button HelpButton;
    }
}