using System;
using System.Linq;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace Quiz
{
    class Result
    {
        private string file;
        private string result = "";
        private string quesid;

        public string getResult(string option, int id, string path)
        {

            try
            {
                quesid = id.ToString();
                file = path;
                var root = XElement.Load(file);
                var address =
                from el in root.Elements("question")
                where (string)el.Attribute("id") == quesid
                select el;
                foreach (XElement el in address)
                    foreach (XElement el1 in el.Elements())
                    {
                        if (el1.Name == "correct")
                        {
                            if (el1.Value == option)
                            {
                                result = "CORRECT";
                            }
                            else
                            {
                                result = "WRONG";
                            }
                        }
                    }
                return result;
            }
            catch (XmlException)
            {
                return "XML Exception has occured! Please contact administrator.";

            }
            catch (FileLoadException)
            {
                return "Not able to load data from backend! Please contact administrator.";
            }
            catch (FileNotFoundException)
            {
                return "Data file not found in backend! Please contact administrator.";
            }
            catch (Exception ex)
            {
                return @"Unknown error! Please contact administrator.";
            }

        }

    }
}
