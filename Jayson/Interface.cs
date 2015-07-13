using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Data;

namespace Jayson
{
    public class Interface
    {
        //SpeechSynthesizer synth;
        //SpeechRecognitionEngine sre;

        public Interface(JayDictionary dictionary)
        {

            //synth = new SpeechSynthesizer();
            //sre = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-GB"));
            
            //Choices words = new Choices();
            //foreach(Word word in dictionary.Words)
            //{
            //    words.Add(word.Name);
            //}

            //GrammarBuilder gb = new GrammarBuilder();
            //gb.Append(words);

            // Create the Grammar instance.
            //Grammar g = new Grammar(gb);
            //sre.LoadGrammar(g);
            //sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_Speechrecognised);
            //sre.SetInputToDefaultAudioDevice();
            //synth.SetOutputToDefaultAudioDevice();
            //synth.Speak("Hi, I'm Jason. Give me a sentence to learn!");
            Console.WriteLine("Hi, I'm Jason. Give me a sentence to learn!");
        }

        public void Say(string sentence)
        {
            //synth.Speak("You Typed: " + sentence);
        }
        public List<String[]> Read()
        {
            List<String[]> sentences = new List<String[]>();
            String raw_input;

            raw_input = Console.ReadLine();
            foreach (String sentence in raw_input.Split('.'))
            {
                sentences.Add(sentence.Split(' '));
            }

            return sentences;
        }

        public void Listen()
        {
            //sre.Recognize();
        }

        private void sre_Speechrecognised(object sender, SpeechRecognizedEventArgs e)
        {
            //synth.Speak("What does "+e.Result.Text+" mean?");
        }

    }
}
