using System;
using System.Linq;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Collections;

namespace Quiz
{
    class Question
    {
        private string file;
        private string quesid;
        ArrayList list = new ArrayList();
        public static int CountQuestion(string path)
        {
            var xmldoc = new XmlDocument();
            xmldoc.Load(path);

            // Get and display all the book titles.
            var xmlnode = xmldoc.GetElementsByTagName("question");
            return xmlnode.Count;
        }
  
        public ArrayList GetQuestion(int id, string path)
        {

            try
            {
                file = path;
                quesid = id.ToString();
                var root = XElement.Load(file);
                var address =
                from el in root.Elements("question")
                where (string)el.Attribute("id") == quesid
                select el;
                foreach (XElement el in address)
                    foreach (XElement el1 in el.Elements())
                    {
                        list.Add(el1.Value);
                    }
              
                return list;
            }
            catch (XmlException)
            {
                list.Add("XML Exception has occured! Please contact administrator.");
                return list;
            }
            catch (FileLoadException)
            {
                list.Add("Not able to load data from backend! Please contact administrator.");
                return list;
            }
            catch (FileNotFoundException)
            {
                list.Add("Data file not found in backend! Please contact administrator.");
                return list;
            }
            catch (Exception ex)
            {
                list.Add("Unknown error! Please contact administrator.");
                return list;
            }

        }

    }
}
