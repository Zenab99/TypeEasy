using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ImageString;
using FileTypeDetective;
using Quiz;
using System.Linq;
using CustomExtensions;
using System.ComponentModel;
using System.Globalization;

namespace type_easy
{
    public partial class Form01_mainForm : Form
    {
      
        public static Form02_setting frm2;
        public static Form04_Welcome frm4;
        public static Form08_theme frm8;
        public static Form09_Account frm9;
        public static Form05_tutorial frm5;
        public static Form03_type_word frm3;
        public static Form06_test frm6;
        public static Form07_game frm7;
        public static Form11_chatbot frm11;
        public static Form12_type_text frm12;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public Image UserAvatar
        {
            get { return UsrPicBox.Image; }
            set { UsrPicBox.Image = value; }
        }


        public string UserName
        {
            get { return UsrnameButton.Text; }
            set { UsrnameButton.Text = value; }
        }

        public Form01_mainForm()
        {
            InitializeComponent();
            ChangeLanguage();
        }


        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }



        private void exitButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }


        private void themeButton_Click(object sender, EventArgs e)
        {
            frm8 = new Form08_theme();
            frm8.Location = themeButton.PointToScreen(new Point(Point.Empty.X - (int)(0.670 * frm8.Size.Width), Point.Empty.Y + 24));
            frm8.Show(this);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            var gp = new GraphicsPath();
            gp.AddEllipse(0, 0, UsrPicBox.Width, UsrPicBox.Height);
            UsrPicBox.Region = new Region(gp);
            gp.Reset();
            gp.AddEllipse(0, 0, SettingButton.Width, SettingButton.Height);
            SettingButton.Region = new Region(gp);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            var ava = (System.Drawing.Bitmap)ImageBase64.Base64ToImage(Properties.Settings.Default.avatar_img_b64);
            UsrPicBox.Image = ava;
            if (File.Exists(Properties.Settings.Default.theme_img_path))
            {
                var file = new FileInfo(Properties.Settings.Default.theme_img_path);
                if (file.IsJpeg() || file.IsGif() || file.IsPng())
                {
                    this.BackgroundImage = Image.FromFile(Properties.Settings.Default.theme_img_path);
                }
            }
            else
            {
                var img = new Bitmap(Form01_mainForm.mainPanel.FindForm().Width,
                        Form01_mainForm.mainPanel.FindForm().Height);

                using (Graphics g = Graphics.FromImage(img))
                    g.Clear(Color.LightPink);
                this.BackgroundImage = img;
            }

            frm2 = new Form02_setting();
            frm8 = new Form08_theme();
            RowPanel.BackColor = Color.FromArgb(40, Color.White);
            MenuPanel.BackColor = Color.FromArgb(120, Color.White);
            UsrnameButton.Text = Properties.Settings.Default.usrname;
            show_mainMenu();
        }

        public void show_mainMenu()
        {
            frm4 = new Form04_Welcome
            {
                TopLevel = false,
                Size = mainPanel.Size,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None,
                Dock = DockStyle.Fill,
                //Parent = mainPanel
            };
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(frm4);
            frm4.Show();
        }

        private void minButton_Click(object sender, EventArgs e)
        {
            WindowState = WindowState = FormWindowState.Minimized;
        }



        private void logoPicBox_Click(object sender, EventArgs e)
        {
            show_mainMenu();
        }


        private void userPicBox_Click(object sender, EventArgs e)
        {
            //do something, I will write something here later 
        }



        private void UsrnameButton_Click(object sender, EventArgs e)
        {
            frm9 = new Form09_Account();
            frm9.Location = UsrnameButton.PointToScreen(new Point(Point.Empty.X - (int)(0.60 * frm9.Size.Width), Point.Empty.Y + 22));
            frm9.Show(this);
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            frm2.Location = SettingButton.PointToScreen(new Point(Point.Empty.X - (int)(0.69 * frm2.Size.Width),
            Point.Empty.Y - (int)(0.95 * frm2.Size.Height)));
            frm2.Show();
        }

        private void TutorialButton_Click(object sender, EventArgs e)
        {
            frm5 = new Form05_tutorial
            {
                TopLevel = false,
                Size = Form01_mainForm.mainPanel.Size,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            Form01_mainForm.mainPanel.Controls.Clear();
            Form01_mainForm.mainPanel.Controls.Add(frm5);
            frm5.Show();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
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

        private void GameButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
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
            frm7.Focus();
        }

        private void WordButton_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
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
        }

        private void TextButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frm12 = new Form12_type_text
            {
                TopLevel = false,
                Size = Form01_mainForm.mainPanel.Size,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            Form01_mainForm.mainPanel.Controls.Clear();
            Form01_mainForm.mainPanel.Controls.Add(frm12);
            frm12.Show();
        }

        private void ChatBotButton_Click(object sender, EventArgs e)
        {
            frm11 = new Form11_chatbot
            {
                TopLevel = false,
                Size = Form01_mainForm.mainPanel.Size,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            Form01_mainForm.mainPanel.Controls.Clear();
            Form01_mainForm.mainPanel.Controls.Add(frm11);
            frm11.Show();
            frm11.Focus();
        }

        private void mainPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            if (Application.OpenForms.OfType<Form07_game>().Any())
            {
                Application.OpenForms.OfType<Form07_game>().First().Close();
            }
        }

        private void ChangeLanguage()
        {
            var lang = Properties.Settings.Default.Language_Select;
            foreach (Control c in this.GetControlHierarchy())
            {
                var resources = new ComponentResourceManager(typeof(Form01_mainForm));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
    }
}