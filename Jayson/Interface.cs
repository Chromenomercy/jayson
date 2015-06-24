using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Jayson
{
    public class Interface
    {
        SpeechSynthesizer synth;
        SpeechRecognitionEngine sre;
        public Interface()
        {
            synth = new SpeechSynthesizer();
            sre = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            synth.SelectVoiceByHints(VoiceGender.Female);
            Choices words = new Choices();
            words.Add(new string[] { "red", "green", "jason", "blue", "peter", "jack"});

            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(words);

            // Create the Grammar instance.
            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_Speechrecognised);
            sre.SetInputToDefaultAudioDevice();
            synth.SetOutputToDefaultAudioDevice();
        }

        public Tuple<string, Int16, string> Read()
        {
            String raw_input;
            String[] input;
            String name;
            Int16 type;
            String value;

            raw_input = Console.ReadLine();
            input = raw_input.Split(':');
            try
            {
                name = input[0];
                type = Convert.ToInt16(input[1]);
                value = input[2];
            }
            catch (Exception e)
            {
                return new Tuple<string, Int16, string>("jayson_error", 1, e.ToString());
            }
            
            Tuple<string, Int16, string> data = new Tuple<string, Int16, string>(name, type, value);
            return data;
        }

        private void sre_Speechrecognised(object sender, SpeechRecognizedEventArgs e)
        {
            synth.Speak("You said: " + e.Result.Text);
        }

    }
}
