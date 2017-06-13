using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using JR.Utils.GUI.Forms;
using CustomExtensions;
using System.Globalization;

namespace type_easy
{
    public partial class Form11_chatbot : Form
    {
        public Form11_chatbot()
        {
            InitializeComponent();
            ChangeLanguage();
        }

        private void Form11_chatbot_Load(object sender, EventArgs e)
        {
            UsrLabel.Text = Properties.Settings.Default.usrname;
            var msg = "你好！";
            BotRichTextBox.Text = msg;
        }
        private static string GetRequest(string url, string msg)
        {
            var html = string.Empty;
            url = @url + @msg;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
       
            return html;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var url = "http://api.douqq.com/?key=czVkOXliQ249PWZrWENtNGc3Sng4eWhZQ3hBQUFBPT0&msg=";
            var msg = "";
            msg = UsrRichTextBox.Text;
            var ans = GetRequest(url, msg);
           
            var file = "";
            switch (ans)
            {
                case "换个说法吧！根本听不懂你说的什么？":
                    {
                        break;
                    }

                case "自己看着办吧":
                    {
                        ans = "我不知道";
                        break;
                    }

            }
            BotRichTextBox.Text = ans;
            
        }

        public static string readAll(string path)
        {

            var allText = "";
            if (File.Exists(path))
            {
                allText = File.ReadAllText(path, Encoding.UTF8);
            }
            return allText;
        }


        private void HelpButton_Click(object sender, EventArgs e)
        {
            var path = "xiaoduqq_readme.txt";
            FlexibleMessageBox.MAX_HEIGHT_FACTOR = 0.5;
            FlexibleMessageBox.MAX_WIDTH_FACTOR = 0.5;
            FlexibleMessageBox.Show(readAll(path), "How to use?");
        }



      
        private void ChangeLanguage()
        {
            var lang = Properties.Settings.Default.Language_Select;

            foreach (Control c in this.GetControlHierarchy())
            {
                var resources = new ComponentResourceManager(typeof(Form11_chatbot));
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BotRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void UsrRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void UsrLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

//换个说法吧！根本听不懂你说的什么？
//自己看着办吧