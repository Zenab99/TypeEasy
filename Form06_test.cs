using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using type_easy;
using CustomExtensions;
using IO_Ext;
using System.Globalization;

namespace Quiz
{
    public partial class Form06_test : Form
    {
        public Form06_test()
        {
            InitializeComponent();
            ChangeLanguage();
            quizComboBox_init("course\\question");
        }

        public static Form06_test frm6;
        private int ques_idx = 0;
        private int points = 0;
        private string path = "";
        private int no_ques = 0;
        List<int> quesIDList = new List<int>();

        private void quizComboBox_init(string path)
        {
            quizComboBox.Items.Clear();
            quizComboBox.Items.AddRange(PathExt.GetAllFileInDirectory(path, ".xml").Cast<object>().ToArray());
        }
        private void quizComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GoButton.Enabled = true;//once user select the source of xml file, test can be started
        }
        private List<int> quesIDList_init()
        {
            var q = new Question();
            no_ques = Question.CountQuestion(path);
            var qid = Enumerable.Range(1, no_ques).ToList();
            qid.Shuffle_List();
            Shuffle.Shuffle_List<int>(qid);
            return qid;
        }

        private void GoButton_Click(object sender, EventArgs e)
        {


            path = quizComboBox.SelectedItem.ToString();
            var list = new ArrayList();


            quizComboBox.Enabled = false;
            GoButton.Enabled = false;
            SubmitButton.Enabled = true;
            go_click_firstQuestion();
        }
        private void go_click_firstQuestion()
        {
            var list = new ArrayList();
            quesIDList = quesIDList_init();
            var q = new Question();
            list = q.GetQuestion(quesIDList[ques_idx], path);
            if (list.Count > 1)// the description of the problem is the list[0]
            {
                var num = 1;
                quesTextLabel.Text = list[0].ToString();
                foreach (Control control in optionsGrpBox.Controls)
                {
                    var radio = control as RadioButton;
                    radio.Visible = false;
                    radio.Enabled = false;
                    radio.Text = "";
                    if (num <= list.Count - 1)
                    {
                        radio.Visible = true;
                        radio.Enabled = true;
                        radio.Text = list[num].ToString();
                        num++;
                    }
                }
            }
            else
            {
                SubmitButton.Enabled = false;
                NextButton.Enabled = false;
            }
            //NextButton.PerformClick();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            optionsGrpBox.Enabled = false;
            SubmitButton.Enabled = false;
            NextButton.Enabled = true;

            var result = "NO SELECTION";
            var res = new Result();

            foreach (Control control in optionsGrpBox.Controls)
            {
                var radio = control as RadioButton;
                if (radio.Checked)
                {
                    result = res.getResult(radio.Text, quesIDList[ques_idx++], path);
                }
            }

            if (result == "CORRECT")
            {
                points = points + 10;
                pointsvalue.Text = points.ToString();
                pointsvalue.ForeColor = Color.Green;
                var file = "image\\icon\\correct.png";
                ExplainPictureBox.Image = Image.FromFile(file);

            }
            else if (result == "WRONG" || result == "NO SELECTION")
            {
                pointsvalue.Text = points.ToString();
                pointsvalue.ForeColor = Color.Red;
                var file = "image\\icon\\wrong.jpg";
                ExplainPictureBox.Image = Image.FromFile(file);

            }
            else
            {
                SubmitButton.Enabled = false;
                NextButton.Enabled = false;
            }
            //NextButton.PerformClick();

        }

       
       

        private void NextButton_Click(object sender, EventArgs e)
        {

            //explain.Visible = false;
            ExplainPictureBox.Image = null;
            foreach (Control control in optionsGrpBox.Controls)
            {
                var radio = control as RadioButton;
                radio.Checked = false;
            }

            NextButton.Enabled = false;
            SubmitButton.Enabled = true;
            optionsGrpBox.Enabled = true;
            optionsGrpBox.Refresh();

            var q = new Question();
            var list = new ArrayList();
            if (ques_idx < no_ques)
            {
                list = q.GetQuestion(quesIDList[ques_idx], path);
                var num = 1;
                if (list.Count > 1)
                {
                    quesTextLabel.Text = list[0].ToString();
                    foreach (Control control in optionsGrpBox.Controls)
                    {
                        var radio = control as RadioButton;
                        radio.Visible = false;
                        radio.Enabled = false;
                        radio.Text = "              ";
                        if (num <= list.Count - 1)
                        {
                            radio.Visible = true;
                            radio.Enabled = true;
                            radio.Text = list[num].ToString();
                            num++;
                        }
                    }
                }
                else
                {
                    SubmitButton.Enabled = false;
                    NextButton.Enabled = false;
                }
            }
            else
            {
                var file = "image\\icon\\finish.png";
                ExplainPictureBox.Image = Image.FromFile(file);
                //MessageBox.Show("You have successfully completed the quiz and scored " + points + " points");
                SubmitButton.Enabled = false;
                foreach (Control control in optionsGrpBox.Controls)
                {
                    var radio = control as RadioButton;
                    radio.Enabled = false;
                }

            }
        }
      

        private void startagainButton_Click(object sender, EventArgs e)
        {
            //Application.Restart();
            this.Close();
            frm6 = new Form06_test
            {
                TopLevel = false,
                Size = Form01_mainForm.mainPanel.Size,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            Form01_mainForm.mainPanel.Controls.Clear();
            Form01_mainForm.mainPanel.Controls.Add(frm6);
          
            frm6.Show();
            
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ChangeLanguage()
        {
            var lang = type_easy.Properties.Settings.Default.Language_Select;

            foreach (Control c in this.GetControlHierarchy())
            {
                var resources = new ComponentResourceManager(typeof(Form06_test));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
          
        }
       
    }



}
