using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phonetic_transcription;

namespace GCIDE
{
    class Gcide
    {
        Phonetic pho = new Phonetic();
        private static IList<string> _keyWords;

        public static string GetPhoonetic(string word)
        {
            return Phonetic.GetPhonetic(word);
        }

        public static string GetMeaning(string word)
        {
            word = word.ToLower();
            var ch = word[0];
            if (word.Length > 0 && ch >= 'a' && ch <= 'z')
            {
                var path = "dictionary//gcide//gcide_" + ch.ToString() + "-entries.json";
                var json = System.IO.File.ReadAllText(path);
                var rss = JObject.Parse(json);
                if (rss[word] != null && rss[word]["definitions"] != null)
                {
                  
                    var explanation = Phonetic.GetPhonetic(word) + System.Environment.NewLine;
                    var builder = new StringBuilder();
                    builder.Append(explanation);
                    for (int i = 0; i < rss[word]["definitions"].Count(); i++)
                    {
                        var wd = rss[word]["definitions"][i];
                        var defi = (string)wd["definition"];
                        var pos = (string)wd["part_of_speech"];
                        if (String.IsNullOrEmpty(pos) == false)
                        {
                            builder.Append(Convert.ToString(i+1) + "  " + pos + "  ");
                        }
                        if (String.IsNullOrEmpty(defi) == false)
                        {
                            builder.Append(defi + "  ");
                        }
                        if (String.IsNullOrEmpty(explanation) == false)
                        {
                            builder.Append(System.Environment.NewLine);
                        }
                        else
                        {
                            builder.Clear();
                        }
                    }
                    return builder.ToString();
                }
                return "";
            }
            else
            {
                return "";
            }
        }
        public static void Dic_atz_load()
        {
            var random = new Random();
            var atz = random.Next(0, 26);
            var ch = Convert.ToChar(Convert.ToInt16('a') + atz).ToString();
            var path = "dictionary//gcide//gcide_" + ch.ToString() + "-entries.json";
            var json = System.IO.File.ReadAllText(path);
            var rss = JObject.Parse(json);
            _keyWords = new List<string>();
            foreach (var ele in rss)
            {
                _keyWords.Add(ele.Key.ToString());
            }
        }
        public static string GetRandomWord(int word_len)
        {
            var random = new Random();
            Dic_atz_load();
            while (true)
            {
                var word = _keyWords[random.Next(_keyWords.Count - 1)];
                if (word.Length <= word_len)
                {
                    return word.ToLower();
                }
            }
        }
    }
}

