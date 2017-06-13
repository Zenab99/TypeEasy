using Quiz;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CustomExtensions;
using System.Globalization;

namespace type_easy
{
    public partial class Form04_Welcome : Form
    {
        public static Form04_Welcome frm4;
        public static Form05_tutorial frm5;
        public static Form03_type_word frm3;
        public static Form06_test frm6;
        public static Form07_game frm7;
        public static Form11_chatbot frm11;
        public static Form12_type_text frm12;
        public Form04_Welcome()
        {
            InitializeComponent();
            ChangeLanguage();

        }




        private void ChangeLanguage()
        {

            var lang = Properties.Settings.Default.Language_Select;


            foreach (Control c in this.GetControlHierarchy())
            {
                var resources = new ComponentResourceManager(typeof(Form04_Welcome));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private void Form04_Welcome_Load(object sender, EventArgs e)
        {
           
           

        }

      
    }
}
