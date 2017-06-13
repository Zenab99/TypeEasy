using System.Collections.Generic;
using Newtonsoft.Json;


namespace Phonetic_transcription
{
    class Phonetic
    {
        static string json = System.IO.File.ReadAllText("dictionary//English-phonetic-transcription.json");
        private static Dictionary<string, string> dic;
        public Phonetic()
        {
            dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }
        public static string Ipa_map(string str)
        {
            str = str.Replace("0", "ɒ");
            str = str.Replace("@", "ə");
            str = str.Replace("&", "æ");
            str = str.Replace(".", "ˌ");
            str = str.Replace("U", "ʊ");
            str = str.Replace("S", "ʃ");
            str = str.Replace("R", "r");
            str = str.Replace("O", "ɔː");
            str = str.Replace("Z", "ʒ");
            str = str.Replace("V", "ʌ");
            str = str.Replace("N", "ŋ");
            str = str.Replace("u", "uː");
            str = str.Replace("T", "θ");
            str = str.Replace("D", "ð");
            str = str.Replace("i", "i:");
            str = str.Replace("A", "ɑ:");
            str = str.Replace("3", "3ː");
            return str;
        }
        public static string GetPhonetic(string word)
        {
            if (dic.ContainsKey(word))
            {
                var phon = "/"+dic[word]+"/";
                phon = Ipa_map(phon);
                return phon;
            }
            return "";
        }
    }
}
