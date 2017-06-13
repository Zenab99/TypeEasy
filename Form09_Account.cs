using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ImageString;
using System.Globalization;
using CustomExtensions;

namespace type_easy
{
    public partial class Form09_Account : Form
    {
        public Form09_Account()
        {
            InitializeComponent();
            ChangeLanguage(); 
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            var shape = new System.Drawing.Drawing2D.GraphicsPath();
            var point1 = new Point(0, 12);
            var point2 = new Point(133, 12);
            var point3 = new Point(141, 0);
            var point4 = new Point(149, 12);
            var point5 = new Point(282, 12);
            var point6 = new Point(282, 238);
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

      

        private void inputRichTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.usrname = inputRichTextBox.Text;
            Properties.Settings.Default.Save();
            var frm1 = (Form01_mainForm)this.Owner;
            frm1.UserName = Properties.Settings.Default.usrname;

        }

        private void AvatarButton_Click(object sender, EventArgs e)
        {
           
            openFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var path = openFileDialog1.FileNames[0];
                var img = Image.FromFile(path);
                var frm1 = (Form01_mainForm)this.Owner;
                frm1.UserAvatar = img;
                Properties.Settings.Default.avatar_img_b64 = ImageBase64.ImageToBase64(img);
                Properties.Settings.Default.Save();
               // this.Close();
            }
           // this.Close();
        }

        private void Form09_Account_Load(object sender, EventArgs e)
        {
          
            this.LevelNoLabel.Text = Convert.ToInt64(
                Properties.Settings.Default.BestScore).ToString() + "@" + 
                Properties.Settings.Default.BestScore_time;
            this.GoalNoLabel.Text = Convert.ToInt64(
                Properties.Settings.Default.Level_requirement).ToString();
        }

        private void Form09_Account_Deactivate(object sender, EventArgs e)
        {
            this.Visible = false;

        }

             private void ChangeLanguage()
        {
            var lang = Properties.Settings.Default.Language_Select;

            foreach (Control c in this.GetControlHierarchy())
            {
                var resources = new ComponentResourceManager(typeof(Form09_Account));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
    }
}
