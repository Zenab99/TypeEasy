using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Speech.Synthesis;
using System.Globalization;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Speech.AudioFormat;
using System.Reflection;
using NAudio.Wave;



namespace CustomExtensions
{
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
        public static void ColorWord(this RichTextBox box, string word, Color color, int startIndex)
        {
            if (box.Text.Contains(word))
            {
                var index = -1;
                var selectStart = box.SelectionStart;

                while ((index = box.Text.IndexOf(word, (index + 1), StringComparison.CurrentCulture)) != -1)
                {
                    box.Select((index + startIndex), word.Length);
                    box.SelectionColor = color;
                    box.Select(selectStart, 0);
                    box.SelectionColor = Color.Black;
                }
            }
            box.SelectionLength = 0;
        }
        public static void ColorChar(this RichTextBox box, int startIndex, int length, Color color)
        {
            if (startIndex >= 0 && startIndex <= box.Text.Length - 1)
            {
                box.SelectionStart = startIndex;
                box.SelectionLength = length;
                box.SelectionColor = color;
                box.SelectionStart = box.Text.Length;//move caret to the end
                box.SelectionLength = 0; // clear
            }
        }
        public static void ScrollToBottom(this RichTextBox box)
        {

            box.SelectionStart = box.Text.Length;
            box.ScrollToCaret();
        }
    }

    public static class Shuffle
    {
        public static void Shuffle_List<T>(this IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public static class ThreadSafeRandom
        {
            [ThreadStatic] private static Random Local;

            public static Random ThisThreadsRandom
            {
                get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
            }
        }
    }

    public static class StringExtension
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
        public static void Text2Speech(this string text, int rate, bool wait_play)
        {
            if (wait_play == true)
            {
                var thread = new Thread(() => texttospeech.tts(text, rate));
                thread.Start();
            }
            else
            {
                texttospeech.tts(text, rate);
            }

        }

        public static void PlayWave(this string fpath, bool play)
        {
            if (fpath.EndsWith(".wav", StringComparison.CurrentCulture) && play)
            {
                using (var player = new System.Media.SoundPlayer
                {
                    SoundLocation = fpath
                })
                {
                   
                        player.Play();
                  

                }
            }
        

        }

       

        public static class texttospeech
        {

            public static void tts(string text, int rate)
            {
                using (var synth = new SpeechSynthesizer())
                {
                    synth.SetOutputToDefaultAudioDevice();
                    synth.Rate = rate;
                    synth.Speak(text);
                }
            }

        }

    }

    public static class ControlExtension
    {
        public static IEnumerable<Control> GetControlHierarchy(this Control root)
        {
            var queue = new Queue<Control>();

            queue.Enqueue(root);

            do
            {
                var control = queue.Dequeue();

                yield return control;

                foreach (var child in control.Controls.OfType<Control>())
                    queue.Enqueue(child);

            } while (queue.Count > 0);

        }

    }

}

