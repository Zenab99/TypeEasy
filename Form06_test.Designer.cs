namespace Quiz
{
    partial class Form06_test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form06_test));
            this.startagain = new System.Windows.Forms.Button();
            this.quizComboBox = new System.Windows.Forms.ComboBox();
            this.catgorayLabel = new System.Windows.Forms.Label();
            this.NextButton = new System.Windows.Forms.Button();
            this.pointsvalue = new System.Windows.Forms.Label();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.GoButton = new System.Windows.Forms.Button();
            this.quesTextLabel = new System.Windows.Forms.Label();
            this.questionLabel = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.optionsGrpBox = new System.Windows.Forms.GroupBox();
            this.option4RdoBtn = new System.Windows.Forms.RadioButton();
            this.option3RdoBtn = new System.Windows.Forms.RadioButton();
            this.option2RdoBtn = new System.Windows.Forms.RadioButton();
            this.option1RdoBtn = new System.Windows.Forms.RadioButton();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ExplainPictureBox = new System.Windows.Forms.PictureBox();
            this.optionsGrpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExplainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // startagain
            // 
            resources.ApplyResources(this.startagain, "startagain");
            this.startagain.Name = "startagain";
            this.startagain.UseVisualStyleBackColor = true;
            this.startagain.Click += new System.EventHandler(this.startagainButton_Click);
            // 
            // quizComboBox
            // 
            this.quizComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.quizComboBox.FormattingEnabled = true;
            this.quizComboBox.Items.AddRange(new object[] {
            resources.GetString("quizComboBox.Items"),
            resources.GetString("quizComboBox.Items1")});
            resources.ApplyResources(this.quizComboBox, "quizComboBox");
            this.quizComboBox.Name = "quizComboBox";
            this.quizComboBox.SelectedIndexChanged += new System.EventHandler(this.quizComboBox_SelectedIndexChanged);
            // 
            // catgorayLabel
            // 
            resources.ApplyResources(this.catgorayLabel, "catgorayLabel");
            this.catgorayLabel.Name = "catgorayLabel";
            // 
            // NextButton
            // 
            resources.ApplyResources(this.NextButton, "NextButton");
            this.NextButton.Name = "NextButton";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // pointsvalue
            // 
            resources.ApplyResources(this.pointsvalue, "pointsvalue");
            this.pointsvalue.Name = "pointsvalue";
            // 
            // pointsLabel
            // 
            resources.ApplyResources(this.pointsLabel, "pointsLabel");
            this.pointsLabel.Name = "pointsLabel";
            // 
            // GoButton
            // 
            resources.ApplyResources(this.GoButton, "GoButton");
            this.GoButton.Name = "GoButton";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // quesTextLabel
            // 
            resources.ApplyResources(this.quesTextLabel, "quesTextLabel");
            this.quesTextLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.quesTextLabel.Name = "quesTextLabel";
            // 
            // questionLabel
            // 
            resources.ApplyResources(this.questionLabel, "questionLabel");
            this.questionLabel.Name = "questionLabel";
            // 
            // SubmitButton
            // 
            resources.ApplyResources(this.SubmitButton, "SubmitButton");
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // optionsGrpBox
            // 
            this.optionsGrpBox.Controls.Add(this.option4RdoBtn);
            this.optionsGrpBox.Controls.Add(this.option3RdoBtn);
            this.optionsGrpBox.Controls.Add(this.option2RdoBtn);
            this.optionsGrpBox.Controls.Add(this.option1RdoBtn);
            resources.ApplyResources(this.optionsGrpBox, "optionsGrpBox");
            this.optionsGrpBox.Name = "optionsGrpBox";
            this.optionsGrpBox.TabStop = false;
            // 
            // option4RdoBtn
            // 
            resources.ApplyResources(this.option4RdoBtn, "option4RdoBtn");
            this.option4RdoBtn.Name = "option4RdoBtn";
            this.option4RdoBtn.TabStop = true;
            this.option4RdoBtn.UseVisualStyleBackColor = true;
            // 
            // option3RdoBtn
            // 
            resources.ApplyResources(this.option3RdoBtn, "option3RdoBtn");
            this.option3RdoBtn.Name = "option3RdoBtn";
            this.option3RdoBtn.TabStop = true;
            this.option3RdoBtn.UseVisualStyleBackColor = true;
            // 
            // option2RdoBtn
            // 
            resources.ApplyResources(this.option2RdoBtn, "option2RdoBtn");
            this.option2RdoBtn.Name = "option2RdoBtn";
            this.option2RdoBtn.TabStop = true;
            this.option2RdoBtn.UseVisualStyleBackColor = true;
            // 
            // option1RdoBtn
            // 
            resources.ApplyResources(this.option1RdoBtn, "option1RdoBtn");
            this.option1RdoBtn.Name = "option1RdoBtn";
            this.option1RdoBtn.TabStop = true;
            this.option1RdoBtn.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            resources.ApplyResources(this.ExitButton, "ExitButton");
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ExplainPictureBox
            // 
            resources.ApplyResources(this.ExplainPictureBox, "ExplainPictureBox");
            this.ExplainPictureBox.Name = "ExplainPictureBox";
            this.ExplainPictureBox.TabStop = false;
            // 
            // Form06_test
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExplainPictureBox);
            this.Controls.Add(this.optionsGrpBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.startagain);
            this.Controls.Add(this.quizComboBox);
            this.Controls.Add(this.catgorayLabel);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.pointsvalue);
            this.Controls.Add(this.pointsLabel);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.quesTextLabel);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.SubmitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form06_test";
            this.optionsGrpBox.ResumeLayout(false);
            this.optionsGrpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExplainPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startagain;
        private System.Windows.Forms.ComboBox quizComboBox;
        private System.Windows.Forms.Label catgorayLabel;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label pointsvalue;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Label quesTextLabel;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.GroupBox optionsGrpBox;
        private System.Windows.Forms.RadioButton option4RdoBtn;
        private System.Windows.Forms.RadioButton option3RdoBtn;
        private System.Windows.Forms.RadioButton option2RdoBtn;
        private System.Windows.Forms.RadioButton option1RdoBtn;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.PictureBox ExplainPictureBox;
    }
}