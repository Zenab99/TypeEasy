using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace IO_Ext
{
    class PathExt
    {
        public static List<string> GetAllFileInDirectory(string path, string filter)
        {
            List<string> flist;
            flist = new List<string>();
            if (File.Exists(path) && path.EndsWith(filter, StringComparison.CurrentCulture))
            {
                // This path is a file
                flist.Add(path);
                return flist;
            }
            else if (Directory.Exists(path))
            {
                // This path is a directory
                var pat = @"(.*)" + filter;

                // Instantiate the regular expression object.
                var r = new Regex(pat, RegexOptions.IgnoreCase);
                flist.AddRange(Directory.GetFiles(path).Where((s => r.Match(s).Success)));
                return flist;
            }
            else
            {
                throw new System.InvalidOperationException("Not a valid file or directory.");
            }

        }


    }
}
