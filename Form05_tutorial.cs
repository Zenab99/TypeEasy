using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageControls;
using System.IO;
using IO_Ext;

namespace type_easy
{
    public partial class Form05_tutorial : Form
    {
        public Form05_tutorial()
        {
            //InitializeComponent();
            var applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            foreach (string path in PathExt.GetAllFileInDirectory("course//tutorial", @"\.[ \w -]").Cast<object>().ToArray())
            {
                System.Diagnostics.Process.Start(path);
            }
            Application.Restart();
        }


    }
}

