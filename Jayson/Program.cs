using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;

namespace Jayson
{
    class Program
    {
        private static SpeechSynthesizer synth = new SpeechSynthesizer();
        static void Main(string[] args)
        {
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            synth.SelectVoiceByHints(VoiceGender.Female);
            Choices words = new Choices();
            words.Add(new string[] { "red", "green", "jason", "blue", "peter is the most awesome person ever"});

            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(words);

            // Create the Grammar instance.
            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_Speechrecognised);
            sre.SetInputToDefaultAudioDevice();
            synth.SetOutputToDefaultAudioDevice();
            while (true)
            {
                sre.Recognize();
            }
        }

        private static void sre_Speechrecognised(object sender, SpeechRecognizedEventArgs e)
        {
            synth.Speak("Speech recognized: " + e.Result.Text);
        }

    }
}
