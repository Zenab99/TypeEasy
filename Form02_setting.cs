using NAudio.Wave;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NAudio_LoopStrem;
using System.IO;
using System.Globalization;
using CustomExtensions;
using System.Collections.Generic;

namespace type_easy
{
    public partial class Form02_setting : Form
    {
        private WaveOut waveOut;
        AudioFileReader audioFileReader;
        private static Form10_AboutBox frm10;

        internal static Form10_AboutBox Frm10 { get => frm10; set => frm10 = value; }

        public Form02_setting()
        {
            InitializeComponent();
            ChangeLanguage(); 
            //waveOut = new WaveOut();
          
            checkBox1.Checked = Properties.Settings.Default.type_effect;
            checkBox2.Checked = false;
        }



        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            var shape = new System.Drawing.Drawing2D.GraphicsPath();
            var point1 = new Point(0, 0);
            var point2 = new Point(282, 0);
            var point3 = new Point(282, 238);
            var point4 = new Point(149, 238);
            var point5 = new Point(141, 248);
            var point6 = new Point(133, 238);
            var point7 = new Point(0, 238);
            Point[] curvePoints =
                     {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5,
                 point6,
                 point7
             };

            shape.AddPolygon(curvePoints);
            this.Region = new System.Drawing.Region(shape);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            var state = checkBox1.CheckState;

            if (state == CheckState.Checked)
            {
                Properties.Settings.Default.type_effect = true;
            }
            else
            {
                Properties.Settings.Default.type_effect = false;
            }
            Properties.Settings.Default.Save();


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            var state = checkBox2.CheckState;
            if (state == CheckState.Checked)
            {
                musicButton.Enabled = true;
                if (File.Exists(Properties.Settings.Default.bgm_mp3_path))
                {
                    var file = new FileInfo(Properties.Settings.Default.bgm_mp3_path);
                    play_bgm(Properties.Settings.Default.bgm_mp3_path, true);
                }
                else
                {

                }

            }
            else
            {
                musicButton.Enabled = false;
                CloseWaveOut();
            }
            Properties.Settings.Default.Save();
        }

        private void Form2_Deactivate(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        public void play_bgm(string file, bool shouldPlay)
        {
            if (shouldPlay == true)
            {
                if (waveOut == null)
                {
                    audioFileReader = new AudioFileReader(file);
                   var loop = new LoopStream(audioFileReader);
                    waveOut = new WaveOut();
                    waveOut.Init(loop);
                 
                    waveOut.Play();
                }
                else
                {
                    waveOut.Stop();
                    waveOut.Dispose();
                    waveOut = null;
                }
            }

        }
        public void CloseWaveOut()
        {
            if (waveOut != null)
            {
                waveOut.Stop();
            }
            if (waveOut != null)
            {
                waveOut.Dispose();
                waveOut = null;
            }
        }


        private void infoLabel_Click(object sender, EventArgs e)
        {
            frm10 = new Form10_AboutBox();
          
            //frm10.Location = infoLabel.PointToScreen(new Point(Point.Empty.X - (int)(0.7 * frm10.Size.Width), Point.Empty.Y + 14));
            frm10.Show();
        }

        private void musicButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var path = openFileDialog1.FileNames[0];
                CloseWaveOut();
                play_bgm(path, true);
                CopyAudioToFile(path);
            }
        }

        private static void CopyAudioToFile(string file)
        {

            var fpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            fpath = Path.Combine(fpath, System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            System.IO.Directory.CreateDirectory(fpath);
            fpath = Path.Combine(fpath, Path.GetFileName(file));
            if (System.IO.File.Exists(fpath))
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                System.IO.File.Delete(fpath);
            }
            File.Copy(file, fpath);
            Properties.Settings.Default.bgm_mp3_path = fpath;
            Properties.Settings.Default.Save();
        }

        private void ResetScoreButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.BestScore = 0;
            Properties.Settings.Default.Level_requirement = 0;
            Properties.Settings.Default.Save();
        }

        private void LanguagecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lang = new Dictionary<string, string>() {
                {"English", "en-US" },
                {"简体中文", "zh-CN" }
            };
            if (Properties.Settings.Default.Language_Select != lang[LanguagecomboBox.SelectedItem.ToString()])
            {
                Properties.Settings.Default.Language_Select = lang[LanguagecomboBox.SelectedItem.ToString()];
                Properties.Settings.Default.Save();
                Application.Restart();
            }
            
        }



        private void ChangeLanguage()
        {
            var lang = Properties.Settings.Default.Language_Select;
            foreach (Control c in this.GetControlHierarchy())
            {
                var resources = new ComponentResourceManager(typeof(Form02_setting));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
           
            var applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
           
            var fpath = applicationDirectory + @"\" + Properties.Settings.Default.Language_Select  +
                @"\" + "TypeEasy2017_Help.rtf";
            System.Diagnostics.Process.Start(@fpath);
        }
    }

}

