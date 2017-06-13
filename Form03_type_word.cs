using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GCIDE;
using IO_Ext;
using CustomExtensions;
using QuickType;
using System.Globalization;
using System.Diagnostics;

namespace type_easy
{
    public partial class Form03_type_word : Form
    {
        private List<string> Prompts { get; set; }
        private List<string> UserInput { get; set; }
        private List<int> CurrentChar { get; set; }
        private string rightInput;
        private int currentPrompt;
        private int MAX_PROMPTS;
     
        private Stopwatch tm = new Stopwatch(); 
        Stats _stats = new Stats();
        public static Form03_type_word frm3;
        Gcide dic = new Gcide();
        public Form03_type_word()
        {
            InitializeComponent();
            ChangeLanguage();
            UserInput = new List<string>();
            //the no. of input char, start from 0
            CurrentChar = new List<int>();
            //the prompt index, the no. of line
            rightInput = "";
      
            currentPrompt = 0;

            //read the prompts(lines) into the prompts list
            Prompts = new List<string>();
            TextComboBox_init("course\\text\\word");

            var path = Properties.Settings.Default.type_word_path;
            TextReader reader = File.OpenText(path);
            MAX_PROMPTS = File.ReadLines(path).Count();
            //initialize all our lists
            for (int i = 0; i < MAX_PROMPTS; i++)
            {
                Prompts.Add(reader.ReadLine().Trim());
                UserInput.Add("");
                CurrentChar.Add(0);
            }
            Prompts.Shuffle_List();
            reader.Close();

            Prompts.Add("");
            UserInput.Add("");
            CurrentChar.Add(0);

            tm.Start();
            timer1.Start();
            var promptText = Prompts[0];

            TextBoxDisplay_Config(promptText);
            inputRichTextBox.Focus();
        }

        private void TextBoxDisplay_Config(string promptText)
        {

            promptText.Text2Speech(3, false);
            PromptLineRichTextBox.AppendText(promptText + " ");
            PromptLineRichTextBox.ScrollToBottom();
         
            var tmp_exp = Gcide.GetMeaning(promptText);
            ExplanationRichTextBox.Text = tmp_exp;
            //ExplanationRichTextBox1.ColorWord(tmp_exp, Color.DarkOrange, 0);
            ExplanationRichTextBox.ColorWord(promptText, Color.Black, 0);
            //  ExplanationRichTextBox1.ColorWord(Gcide.GetPhoonetic(promptText), Color.Green, 0);
            //promptRichTextBox.Text = promptText;
            var pos = new List<string>(new string[]
            {
               "noun", "pronoun", "verb", "adjective", "adverb",
                "preposition", "conjunction", "interjection"
            });

            foreach (string p in pos)
            {
                ExplanationRichTextBox.ColorWord(p, Color.DarkCyan, 0);
            }
            var num = new List<string>();
            var no_max = 20;
            for(int i = 0; i < no_max; i++)
            {
                num.Add(Convert.ToString(i));
            }

            foreach (string n in num)
            {
                ExplanationRichTextBox.ColorWord(n, Color.MediumBlue, 0);
            }

        }



        private void TextComboBox_init(string path)
        {
            WordComboBox.Items.Clear();
            WordComboBox.Items.AddRange(PathExt.GetAllFileInDirectory(path, ".txt").Cast<object>().ToArray());
        }
      

       
        private static void inputRichTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


      

        private void OnKeyDown(object sender, KeyEventArgs e)
        {

            var converter = new KeysConverter();
            var text = converter.ConvertToString(e.KeyData);
            if (Control.ModifierKeys == Keys.Shift)
            {
                shiftPicBox.Image = (Bitmap)Image.FromFile("image//keyboard//press//shift.png", true);
                rshiftPicBox.Image = (Bitmap)Image.FromFile("image//keyboard//press//shift-right.png", true);
            }
            ChangeKeyColor(e.KeyCode, true);
        }

        private void OnKeyRelease(object sender, KeyEventArgs e)
        {
            ChangeKeyColor(e.KeyCode, false);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
          
            if (keyData == Keys.Tab)
            {
                if (tabPicBox.ImageLocation == "image//keyboard//press//tab.png")
                    ChangeKeyColor(Keys.Tab, false);
                else
                    ChangeKeyColor(Keys.Tab, true);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ChangeKeyColor(Keys key, bool isPressed)
        {
          
            var path = "";
            if (isPressed)
            {
                path = "image//keyboard//press//";
            }
            else
            {
                path = "image//keyboard//release//";
            }
            switch (key)
            {
                //letters

                case Keys.Q: qPicBox.Image = (Bitmap)Image.FromFile(path + "q.png", true); break;
                case Keys.W: wPicBox.Image = (Bitmap)Image.FromFile(path + "w.png", true); break;
                case Keys.E: ePicBox.Image = (Bitmap)Image.FromFile(path + "e.png", true); break;
                case Keys.R: rPicBox.Image = (Bitmap)Image.FromFile(path + "r.png", true); break;
                case Keys.T: tPicBox.Image = (Bitmap)Image.FromFile(path + "t.png", true); break;
                case Keys.Y: yPicBox.Image = (Bitmap)Image.FromFile(path + "y.png", true); break;
                case Keys.U: uPicBox.Image = (Bitmap)Image.FromFile(path + "u.png", true); break;
                case Keys.I: iPicBox.Image = (Bitmap)Image.FromFile(path + "i.png", true); break;
                case Keys.O: oPicBox.Image = (Bitmap)Image.FromFile(path + "o.png", true); break;
                case Keys.P: pPicBox.Image = (Bitmap)Image.FromFile(path + "p.png", true); break;
                case Keys.A: aPicBox.Image = (Bitmap)Image.FromFile(path + "a.png", true); break;
                case Keys.S: sPicBox.Image = (Bitmap)Image.FromFile(path + "s.png", true); break;
                case Keys.D: dPicBox.Image = (Bitmap)Image.FromFile(path + "d.png", true); break;
                case Keys.F: fPicBox.Image = (Bitmap)Image.FromFile(path + "f.png", true); break;
                case Keys.G: gPicBox.Image = (Bitmap)Image.FromFile(path + "g.png", true); break;
                case Keys.H: hPicBox.Image = (Bitmap)Image.FromFile(path + "h.png", true); break;
                case Keys.J: jPicBox.Image = (Bitmap)Image.FromFile(path + "j.png", true); break;
                case Keys.K: kPicBox.Image = (Bitmap)Image.FromFile(path + "k.png", true); break;
                case Keys.L: lPicBox.Image = (Bitmap)Image.FromFile(path + "l.png", true); break;
                case Keys.Z: zPicBox.Image = (Bitmap)Image.FromFile(path + "z.png", true); break;
                case Keys.X: xPicBox.Image = (Bitmap)Image.FromFile(path + "x.png", true); break;
                case Keys.C: cPicBox.Image = (Bitmap)Image.FromFile(path + "c.png", true); break;
                case Keys.V: vPicBox.Image = (Bitmap)Image.FromFile(path + "v.png", true); break;
                case Keys.B: bPicBox.Image = (Bitmap)Image.FromFile(path + "b.png", true); break;
                case Keys.N: nPicBox.Image = (Bitmap)Image.FromFile(path + "n.png", true); break;
                case Keys.M: mPicBox.Image = (Bitmap)Image.FromFile(path + "m.png", true); break;

                //numbers

                case Keys.D1: PicBox1.Image = (Bitmap)Image.FromFile(path + "1.png", true); break;
                case Keys.D2: PicBox2.Image = (Bitmap)Image.FromFile(path + "2.png", true); break;
                case Keys.D3: PicBox3.Image = (Bitmap)Image.FromFile(path + "3.png", true); break;
                case Keys.D4: PicBox4.Image = (Bitmap)Image.FromFile(path + "4.png", true); break;
                case Keys.D5: PicBox5.Image = (Bitmap)Image.FromFile(path + "5.png", true); break;
                case Keys.D6: PicBox6.Image = (Bitmap)Image.FromFile(path + "6.png", true); break;
                case Keys.D7: PicBox7.Image = (Bitmap)Image.FromFile(path + "7.png", true); break;
                case Keys.D8: PicBox8.Image = (Bitmap)Image.FromFile(path + "8.png", true); break;
                case Keys.D9: PicBox9.Image = (Bitmap)Image.FromFile(path + "9.png", true); break;
                case Keys.D0: PicBox0.Image = (Bitmap)Image.FromFile(path + "0.png", true); break;

                //symbols

                case Keys.Oemtilde: tildePicBox.Image = (Bitmap)Image.FromFile(path + "apostroph.png", true); break;
                case Keys.Oemcomma: commaPicBox.Image = (Bitmap)Image.FromFile(path + "comma-lt.png", true); break;
                case Keys.OemPeriod: periodPicBox.Image = (Bitmap)Image.FromFile(path + "period-gt.png", true); break;
                case Keys.OemQuestion: forwardslashPicBox.Image = (Bitmap)Image.FromFile(path + "slash-questionmark.png", true); break;
                case Keys.OemSemicolon: colonPicBox.Image = (Bitmap)Image.FromFile(path + "semicolon-dble.png", true); break;
                case Keys.OemQuotes: quotePicBox.Image = (Bitmap)Image.FromFile(path + "comma.png", true); break;
                case Keys.OemOpenBrackets: lbracePicBox.Image = (Bitmap)Image.FromFile(path + "bracket-open.png", true); break;
                case Keys.OemCloseBrackets: rbracePicBox.Image = (Bitmap)Image.FromFile(path + "bracket-close.png", true); break;
                case Keys.OemMinus: minusPicBox.Image = (Bitmap)Image.FromFile(path + "minus.png", true); break;
                case Keys.Oemplus: equalPicBox.Image = (Bitmap)Image.FromFile(path + "equals-plus.png", true); break;
                case Keys.Oem5: backslashPicBox.Image = (Bitmap)Image.FromFile(path + "backslash.png", true); break;

                ////other PicBoxs

                case Keys.Tab: tabPicBox.Image = (Bitmap)Image.FromFile(path + "tab.png", true); break;
                case Keys.Back: backspacePicBox.Image = (Bitmap)Image.FromFile(path + "backspace.png", true); break;
                case Keys.CapsLock: capsPicBox.Image = (Bitmap)Image.FromFile(path + "capslock.png", true); break;
                case Keys.Space: spacebarPicBox.Image = (Bitmap)Image.FromFile(path + "spacebar.png", true); break;
                case Keys.Enter: enterPicBox.Image = (Bitmap)Image.FromFile(path + "enter.png", true); break;
                case Keys.ShiftKey:
                    {
                        shiftPicBox.Image = (Bitmap)Image.FromFile(path + "shift.png", true);
                        rshiftPicBox.Image = (Bitmap)Image.FromFile(path + "shift-right.png", true); break;
                    }
            }

        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            //prep for the next prompt
            if (currentPrompt < MAX_PROMPTS - 1)
                ShowNextPrompt();

            //print the results screen
            else
                ShowFinalScreen();
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            ShowPrevPrompt();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            RestartPrompt();
        }

        private void RestartPrompt()
        {
            //reinitialize the user input and the textbox
            UserInput[currentPrompt] = "";
            inputRichTextBox.Text = " ";
            inputRichTextBox.Enabled = true;
            CurrentChar[currentPrompt] = 0;

            UpdateStats(currentPrompt);
        }

        private static void UpdateStats(int index)
        {
           


        }

        private static void UpdateFinalStats()
        {
           
        }


        private void ShowNextPrompt()
        {
            //save off the current user input
            //assume currentPrompt = 5
            UserInput[currentPrompt] = inputRichTextBox.Text;//5
            inputRichTextBox.Enabled = true;
            inputRichTextBox.Text = UserInput[++currentPrompt];//6, 5+1 do add here
            var promptText = Prompts[currentPrompt];//6
       
            TextBoxDisplay_Config(promptText);

        }

        private void ShowPrevPrompt()
        {
            //allows the user to look at and redo past prompts
            if (currentPrompt > 1)
            {
                UserInput[currentPrompt] = inputRichTextBox.Text;
                inputRichTextBox.Enabled = true;
                inputRichTextBox.Text = UserInput[--currentPrompt];
                UpdateStats(currentPrompt);
            }
            else
            {
                //leftButton.Enabled = false;
                //save off current user input
                UserInput[currentPrompt] = inputRichTextBox.Text;

                inputRichTextBox.Text = UserInput[--currentPrompt];
               // promptRichTextBox.Text = Prompts[currentPrompt];

                UpdateStats(currentPrompt);
            }
        }

        private void ShowFinalScreen()
        {

            //save off the current user input
            UserInput[currentPrompt] = inputRichTextBox.Text;
           
            inputRichTextBox.Text = UserInput[++currentPrompt];
          
            inputRichTextBox.Enabled = false;

            UpdateFinalStats();
        }

        private void inputRichTextBox_TextChanged(object sender, EventArgs e)
        {

           var inputText = inputRichTextBox.Text;
           var wd = Prompts[currentPrompt];
            //when we hit the end of a prompt, switch to the next prompt
            if (inputText.Length == wd.Length  )
            {
                if (object.Equals(wd, inputText))
                {
                    _stats.Update(true);
                }
                else
                {
                    _stats.Update(false);
                }
               
            }
            else
            {
            }
            

            if (inputRichTextBox.Text.Contains(Prompts[currentPrompt]) == false)
            {
                
                var idx = PromptLineRichTextBox.Text.IndexOf(wd, StringComparison.CurrentCulture);
                if (inputText.Length <= Prompts[currentPrompt].Length && inputText.Length > 0)
                {
                    
                    PromptLineRichTextBox.ColorChar(idx+ inputText.Length - 1, wd.Length -
                   inputText.Length + 1, Color.Gray);
                    var in_ch = inputText[inputText.Length - 1];
                    var right_ch = Prompts[currentPrompt][inputText.Length - 1];
                    if (in_ch == right_ch)
                    {
                        PromptLineRichTextBox.ColorChar(idx + inputText.Length - 1,  1, Color.Gray);
                        inputRichTextBox.ColorChar(inputText.Length - 1, 1, Color.Gray);
                        "audio//sys//type.wav".PlayWave(Properties.Settings.Default.type_effect);
                    }
                    else
                    {
                        PromptLineRichTextBox.ColorChar(idx + inputText.Length - 1, 1, Color.Red);
                        inputRichTextBox.ColorChar(inputText.Length - 1, 1, Color.Red);
                         "audio//sys//error.wav".PlayWave(Properties.Settings.Default.type_effect);
                    }
                }
                else if (inputText.Length > Prompts[currentPrompt].Length)
                {
                    inputRichTextBox.ColorChar(inputText.Length - 1, 1, Color.Red);

                    "audio//sys//error.wav".PlayWave(Properties.Settings.Default.type_effect);
                }
                else if (inputText.Length == 0)
                {
                    PromptLineRichTextBox.ColorChar(idx, 1, Color.Gray);

                }
            }
            else
            {
                rightInput += inputText;
                CurrentChar[currentPrompt]++;
                if (currentPrompt < MAX_PROMPTS - 1)
                    ShowNextPrompt();
                else if (currentPrompt == MAX_PROMPTS - 1)
                    ShowFinalScreen();
            }
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            var time_second = tm.Elapsed.TotalSeconds;
            var time = TimeSpan.FromSeconds(time_second);
            var str = time.ToString(@"hh\:mm\:ss");
            timeLabel.Text = str;
            var wpm = Convert.ToInt32((rightInput.Length / 5.0 / (time_second / 60.0)));
            _stats.SetBestScore(wpm);
            WPMLabel.Text = wpm.ToString();
            accuracyLabel.Text = _stats.Accuracy + "%";
            healthLabel.Text = 
                 Convert.ToString(Convert.ToInt16( ((currentPrompt + 1)/(1.0*Prompts.Count) * 100
                 ) ) ) + "%";
        }


        private void WordComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.type_word_path = WordComboBox.SelectedItem.ToString();
            Properties.Settings.Default.Save();
            frm3 = new Form03_type_word
            {
                TopLevel = false,
                Size = Form01_mainForm.mainPanel.Size,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            Form01_mainForm.mainPanel.Controls.Clear();
            Form01_mainForm.mainPanel.Controls.Add(frm3);
          
            frm3.Show();
            
            this.Close();
        }

        private void ChangeLanguage()
        {
            var lang = Properties.Settings.Default.Language_Select;
            foreach (Control c in this.GetControlHierarchy())
            {
                var resources = new ComponentResourceManager(typeof(Form03_type_word));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
    }
}
