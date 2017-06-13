using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GCIDE;
using QuickType;
using System.IO;
using System.Diagnostics;
using CustomExtensions;
using System.Globalization;

namespace type_easy
{
    public partial class Form07_game : Form
    {
        public static Form07_game frm7;
        private List<string> wordList { get; set; }
        Stats _stats = new Stats();
        int error_no = 36; 
        int wl_idx = 0;
        private string rightInput;
        Gcide dic = new Gcide();
      
        //used to hold the list of characters typed
        private string _stringBuffer = String.Empty;
        private Stopwatch tm = new Stopwatch();

        public Form07_game()
        {
            InitializeComponent();
            ChangeLanguage();
            this.Focus();
            this.KeyPreview = true;
            this.Text += " Type the word displayed and press 'enter'";
            timer_interval_config();
            wordList = new List<string>();
            wordList_init("course//text//word//allWords.txt", ".txt").Shuffle_List();
            DisplayWord();
            rightInput = ""; 
         
            tm.Start();
            
            timer1.Start();
        }

        private List<string> wordList_init(string path, string filter)
        {
           
            if (File.Exists(path) && path.EndsWith(filter, StringComparison.CurrentCulture))
            {
                TextReader reader = File.OpenText(path);
                var lines = File.ReadLines(path).Count();
                //initialize all our lists
                for (int i = 0; i < lines; i++)
                {
                    wordList.Add(reader.ReadLine().Trim());
                }

                reader.Close();
                return wordList;
            }
            else
            {
                throw new System.InvalidOperationException("Not a valid file");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Focus();
            timer_interval_config();
            DisplayWord();
            if (listBox1.Items.Count >= error_no)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Game Over");
                ExplanationRichTextBox.Visible = false;
                timer1.Stop();
            }
           

            var time_second = tm.Elapsed.TotalSeconds;
            var time = TimeSpan.FromSeconds(time_second);
            var str = time.ToString(@"hh\:mm\:ss");
            timeLabel.Text = str;

            var wpm = Convert.ToInt32((rightInput.Length / 5.0 / (time_second / 60.0)));
            _stats.SetBestScore(wpm);
            WPMLabel.Text =  wpm.ToString();
            accuracyLabel.Text = _stats.Accuracy + "%";
            healthLabel.Text = 
                Convert.ToString(Convert.ToInt16( (1 - listBox1.Items.Count / (1.0*error_no))*100
                ) ) + "%";
        }

        private void timer_interval_config()
        {
            timer1.Interval = Convert.ToInt16(timeIntervalNUD.Value);
            if (timer1.Interval > 1000) timer1.Interval -= 15;
            if (timer1.Interval > 800) timer1.Interval -= 8;
            if (timer1.Interval > 400) timer1.Interval -= 6;
            if (timer1.Interval > 250) timer1.Interval -= 4;
            if (timer1.Interval > 100) timer1.Interval -= 3;
        }

        private void Form7_game_KeyDown(object sender, KeyEventArgs e)
        {
          
            OnKeyDown(sender, e);
            if(timer1.Enabled)
            {
                //if the key is not 'enter' then add the character to the string buffer
                if (e.KeyCode == Keys.Back)
                {
                    if (_stringBuffer.Length > 1)
                    {
                        _stringBuffer = _stringBuffer.Remove(_stringBuffer.Length - 1);
                    }
                    else
                    {
                        _stringBuffer = "";
                    }
                }
                else if (e.KeyCode != Keys.Enter)
                {
                    _stringBuffer += e.KeyCode;
                }
                else
                {
                    var temp = _stringBuffer.ToLower(); //adjust for shift/capslock
                    _stringBuffer = String.Empty; //reset string buffer
                    if (listBox1.Items.Contains(temp)) // see if the string is in the list
                    {
                        rightInput += temp;
                        listBox1.Items.Remove(temp); //remove the word
                        listBox1.Refresh(); //refresh the display
                                            //speed the game up
                        if (timer1.Interval > 1000) timer1.Interval -= 15;
                        if (timer1.Interval > 800) timer1.Interval -= 8;
                        if (timer1.Interval > 400) timer1.Interval -= 6;
                        if (timer1.Interval > 250) timer1.Interval -= 4;
                        if (timer1.Interval > 100) timer1.Interval -= 3;
                        //difficultyProgressBar.Value = INITIAL_DELAY - timer1.Interval;

                        //correct key : update stats
                        _stats.Update(true);
                    }
                    else
                    {
                        //incorrect key : update stats : game speed stays the same
                        _stats.Update(false);
                    }

                }
            }
           
        }



       
        // Re-factored this to it's own function, rather than have the same line in the
        //  form load and the timer_tick
        private void DisplayWord()
        {
            var word = wordList[wl_idx++];
          
            listBox1.Items.Add(word);
            var word_last = listBox1.Items[listBox1.Items.Count - 1].ToString();
           
            TextBoxDisplay_Config(word);
            
        }

        private void TextBoxDisplay_Config(string promptText)
        {

            promptText.Text2Speech(3, false);
          

            var tmp_exp = Gcide.GetMeaning(promptText);
            ExplanationRichTextBox.Text = tmp_exp;
         
            ExplanationRichTextBox.ColorWord(promptText, Color.Black, 0);
          
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
            for (int i = 0; i < no_max; i++)
            {
                num.Add(Convert.ToString(i));
            }

            foreach (string n in num)
            {
                ExplanationRichTextBox.ColorWord(n, Color.MediumBlue, 0);
            }

        }

        private void RestartPicBox_Click(object sender, EventArgs e)
        {
            this.Close();
            frm7 = new Form07_game
            {
                TopLevel = false,
                Size = Form01_mainForm.mainPanel.Size,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            Form01_mainForm.mainPanel.Controls.Clear();
            Form01_mainForm.mainPanel.Controls.Add(frm7);
          
            frm7.Show();
            
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

        //private void OnKeyRelease(object sender, KeyEventArgs e)
        //{
        //    ChangeKeyColor(e.KeyCode, false);
        //}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //basically intercepts the tab key and changes it's color
            //Tab is special key, which switch between buttons
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
            //worst switch statement ever
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

        private void Form07_game_KeyUp(object sender, KeyEventArgs e)
        {
            ChangeKeyColor(e.KeyCode, false);
        }

        private void timeIntervalNUD_Validated(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt16(timeIntervalNUD.Value);
        }

        private void Form07_game_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

      


        private void PausepictureBox_Click(object sender, EventArgs e)
        {

            if(timer1.Enabled)
            {
                listBox1.Enabled = false;
                timer1.Enabled = false;
                tm.Stop();
                PausepictureBox.Image = Image.FromFile("image//icon//pause.png");
            }
            else
            {
                listBox1.Enabled = true;
                timer1.Enabled = true;
                tm.Start();
                PausepictureBox.Image = Image.FromFile("image//icon//play.png");
            }
        }
        private void ChangeLanguage()
        {
            var lang = Properties.Settings.Default.Language_Select;
            foreach (Control c in this.GetControlHierarchy())
            {
                var resources = new ComponentResourceManager(typeof(Form07_game));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
    }
}
