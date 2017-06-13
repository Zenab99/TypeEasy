using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ImageControls;
using IO_Ext;
using CutoutPro.Winforms;//colorDialog from third party 
using System.Drawing.Imaging;
using System.IO;
using CustomExtensions;
using System.Globalization;

namespace type_easy
{
    public partial class Form08_theme : Form
    {
        public Form08_theme()
        {
            InitializeComponent();
            ChangeLanguage();

        }
        private void Form8_theme_Load(object sender, EventArgs e)
        {
            foreach (string file in PathExt.GetAllFileInDirectory("image\\theme", ".jpg"))
            {
                this.imageAccordion1.Add(new Thumbnail("", Image.FromFile(file)));
            }

            this.imageAccordion1.SelectThumnail(0);
            imageAccordion1.HoverColor = Color.Orange;
            imageAccordion1.SelectedColor = Color.DarkBlue;

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



        private void imageAccordion1_ThumbnailChanged(int OldIndex, int NewIndex, Thumbnail thumbnail)
        {
            pictureBox1.BackgroundImage = thumbnail.Image;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var frm1 = (Form01_mainForm)this.Owner;
            frm1.BackgroundImage = pictureBox1.BackgroundImage;
            SaveImageToFile();
            this.Close();
        }

        private void Form8_theme_Deactivate(object sender, EventArgs e)
        {
            this.Visible = false;
         
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
           
            openFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var path = openFileDialog1.FileNames[0];
                var frm1 = (Form01_mainForm)this.Owner;
                frm1.BackgroundImage = Image.FromFile(path);
                SaveImageToFile();
                this.Close();
            }
            this.Close();
        }

        private static void SaveImageToFile()
        {
            var img = Form01_mainForm.mainPanel.FindForm().BackgroundImage;
            var fpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            fpath = Path.Combine(fpath, System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            Directory.CreateDirectory(fpath);
            fpath = Path.Combine(fpath, "theme.jpg");
            if (System.IO.File.Exists(fpath))
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                System.IO.File.Delete(fpath);
            }
            img.Save(fpath, ImageFormat.Jpeg);
            Properties.Settings.Default.theme_img_path = fpath;
            Properties.Settings.Default.Save();
        }

        private void colorDlgButton_Click(object sender, EventArgs e)
        {
            
            using (var dialog = new ArgbColorDialog
            {
                Color = Color.SkyBlue
            })
            {

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var frm1 = (Form01_mainForm)this.Owner;
                   
                    var img = new Bitmap(frm1.Width, frm1.Height);

                    using (Graphics g = Graphics.FromImage(img))
                        g.Clear(dialog.Color);
                    
                   frm1.BackgroundImage = img;
                    SaveImageToFile();

                    this.Close();
                    return;

                }
                if (dialog.ShowDialog() != DialogResult.OK) return;
                this.Close();
            }

        }
        private void ChangeLanguage()
        {
            var lang = Properties.Settings.Default.Language_Select;

            foreach (Control c in this.GetControlHierarchy())
            {
                var resources = new ComponentResourceManager(typeof(Form08_theme));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
    }
}

