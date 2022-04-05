﻿using Microsoft.CognitiveServices.Speech;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCVRCWiz
{
    public class AudioSynthesis
    {
        

        //TTS
        public static async Task SynthesizeAudioAsync(string text, string style, string rate, string pitch, string volume, string voice) //TTS Outputs through speakers //can not change voice style
        {
            try
            {
                
                var config = SpeechConfig.FromSubscription(VoiceWizardWindow.YourSubscriptionKey, VoiceWizardWindow.YourServiceRegion);
               
              
                // Note: if only language is set, the default voice of that language is chosen.
                //  config.SpeechSynthesisLanguage = "<your-synthesis-language>"; // For example, "de-DE"
                // The voice setting will overwrite the language setting.
                // The voice setting will not overwrite the voice element in input SSML.
                //config.SpeechSynthesisVoiceName = "en-US-JennyNeural";
                // config.SpeechSynthesisVoiceName = "en-US-SaraNeural";




                // https://docs.microsoft.com/en-us/azure/cognitive-services/speech-service/language-support#speaker-recognition
                string angry = "<mstts:express-as style=\"angry\">"; //1
                string happy = "<mstts:express-as style=\"cheerful\">"; //2
                string sad = "<mstts:express-as style=\"sad\">";//3

                string chat = "<mstts:express-as style=\"chat\">"; //1
                string customerservice = "<mstts:express-as style=\"customerservice\">"; //2
                string empathetic = "<mstts:express-as style=\"empathetic\">";//3
                string narrationProf = "<mstts:express-as style=\"narration-professional\">"; //1
                string newscastCas = "<mstts:express-as style=\"newscast-casual\">"; //2
                string newscastForm = "<mstts:express-as style=\"newscast-formal\">";//3
                string newscast = "<mstts:express-as style=\"newscast\">"; //1
                string assistant = "<mstts:express-as style=\"assistant\">"; //2


                string ratexslow = "<prosody rate=\"x-slow\">"; //1
                string rateslow = "<prosody rate=\"slow\">"; //2
                string ratemedium = "<prosody rate=\"medium\">"; //3
                string ratefast = "<prosody rate=\"fast\">"; //4
                string ratexfast = "<prosody rate=\"x-fast\">"; //5

                string pitchxlow = "<prosody pitch=\"x-low\">"; //1
                string pitchlow = "<prosody pitch=\"low\">"; //2
                string pitchmedium = "<prosody pitch=\"medium\">"; //3
                string pitchhigh = "<prosody pitch=\"high\">"; //4
                string pitchxhigh = "<prosody pitch=\"x-high\">"; //5

                string volumexlow = "<prosody volume=\"x-soft\">"; //1
                string volumelow = "<prosody volume=\"soft\">"; //2
                string volumemedium = "<prosody volume=\"medium\">"; //3
                string volumehigh = "<prosody volume=\"loud\">"; //4
                string volumexhigh = "<prosody volume=\"x-loud\">"; //5


                string sara = "<voice name=\"en-US-SaraNeural\">";//1
                string jenny = "<voice name=\"en-US-JennyNeural\">";//2
                string guy = "<voice name=\"en-US-GuyNeural\">";//3
                string amber = "<voice name=\"en-US-AmberNeural\">";//4
                string ana = "<voice name=\"en-US-AnaNeural\">";//5
                string aria = "<voice name=\"en-US-AriaNeural\">";//6
                string ashley = "<voice name=\"en-US-AshleyNeural\">";//7
                string brandon = "<voice name=\"en-US-BrandonNeural\">";//8
                string christopher = "<voice name=\"en-US-ChristopherNeural\">";//9
                string cora = "<voice name=\"en-US-CoraNeural\">";//10
                string elizabeth = "<voice name=\"en-US-ElizabethNeural\">";//11
                string eric = "<voice name=\"en-US-EricNeural\">";//12
                string jacob = "<voice name=\"en-US-JacobNeural\">";//13
                string michelle = "<voice name=\"en-US-MichelleNeural\">";//14
                string monica = "<voice name=\"en-US-MonicaNeural\">";//15
                string davis = "<voice name=\"en-US-DavisNeural\">";//16

                string natashaAU = "<voice name=\"en-AU-NatashaNeural\">";//17
                string williamAU = "<voice name=\"en-AU-WilliamNeural\">";//18
                string claraCA = "<voice name=\"en-CA-ClaraNeural\">";//19
                string liamCA = "<voice name=\"en-CA-LiamNeural\">";//20
                string soniaUK = "<voice name=\"en-GB-SoniaNeural\">";//21
                string ryanUK = "<voice name=\"en-GB-RyanNeural\">";//22


                string abbiUK = "<voice name=\"en-GB-AbbiNeural\">";//23
                string bellaUK = "<voice name=\"en-GB-BellaNeural\">";//23
                string hollieUK = "<voice name=\"en-GB-HollieNeural\">";//24
                string oliviaUK = "<voice name=\"en-GB-OliviaNeural\">";//25
                string maisieUK = "<voice name=\"en-GB-MaisieNeural\">";//26

                string alfieUK = "<voice name=\"	en-GB-AlfieNeural\">";//
                string elliotUK = "<voice name=\"en-GB-ElliotNeural\">";//
                string ethanUK = "<voice name=\"en-GB-EthanNeural\">";//
                string noahUK = "<voice name=\"en-GB-NoahNeural\">";//
                string oliverUK = "<voice name=\"en-GB-OliverNeural\">";//
                string thomasUK = "<voice name=\"en-GB-ThomasNeural\">";//

                string daliaSpanish_Mexico = "<voice name=\"es-MX-DaliaNeural\">";//
                string jorgeSpanish_Mexico = "<voice name=\"es-MX-JorgeNeural\">";//

                string brigitteFrench = "<voice name=\"fr-FR-BrigitteNeural\">";//
                string jeromeFrench = "<voice name=\"fr-FR-JeromeNeural\">";//

                string amalaGerman = "<voice name=\"de-DE-AmalaNeural\">";//
                string christophGerman = "<voice name=\"de-DE-ChristophNeural\">";//

                string arabicFemale_Egypt = "<voice name=\"ar-EG-SalmaNeural\">";//
                string arabicMale_Egypt = "<voice name=\"ar-EG-ShakirNeural\">";//

                string chineseFemale_MandarinSimple = "<voice name=\"zh-CN-XiaomoNeural\">";//
                string chineseMale_MandarinSimple = "<voice name=\"	zh-CN-YunyeNeural\">";//

                string danishFemale = "<voice name=\"da-DK-ChristelNeural\">";//
                string danishMale = "<voice name=\"da-DK-JeppeNeural\">";//

                string dutchFemale = "<voice name=\"nl-BE-DenaNeural\">";//
                string dutchMale = "<voice name=\"nl-BE-ArnaudNeural\">";//

                string hendiFemale = "<voice name=\"hi-IN-SwaraNeural\">";//
                string hendiMale = "<voice name=\"hi-IN-MadhurNeural\">";//

                string irishFemale = "<voice name=\"ga-IE-OrlaNeural\">";//
                string irishMale = "<voice name=\"ga-IE-ColmNeural\">";//
                string italianFemale = "<voice name=\"it-IT-ElsaNeural\">";//
                string italianMale = "<voice name=\"it-IT-DiegoNeural\">";//
                string japaneseFemale = "<voice name=\"ja-JP-NanamiNeural\">";//
                string japaneseMale = "<voice name=\"ja-JP-KeitaNeural\">";//
                string koreanFemale = "<voice name=\"ko-KR-SunHiNeural\">";//
                string koreanMale = "<voice name=\"	ko-KR-InJoonNeural\">";//
                string norwegianFemale = "<voice name=\"nb-NO-PernilleNeural\">";//
                string norweigianMale = "<voice name=\"nb-NO-FinnNeural\">";//
                string polishFemale = "<voice name=\"pl-PL-AgnieszkaNeural\">";//
                string polishMale = "<voice name=\"	pl-PL-MarekNeural\">";//
                string portugueseFemale = "<voice name=\"pt-BR-FranciscaNeural\">";//
                string portugueseMale = "<voice name=\"pt-BR-AntonioNeural\">";//
                string russianFemale = "<voice name=\"ru-RU-DariyaNeural\">";//
                string russianMale = "<voice name=\"ru-RU-DmitryNeural\">";//
                
                string swedishFemale = "<voice name=\"sv-SE-HilleviNeural\">";//
                string swedishMale = "<voice name=\"sv-SE-MattiasNeural\">";//
                string thaiFemale = "<voice name=\"th-TH-AcharaNeural\">";//
                string thaiMale = "<voice name=\"th-TH-NiwatNeural\">";//
                string ukranianFemale = "<voice name=\"uk-UA-PolinaNeural\">";//
                string ukranianMale = "<voice name=\"uk-UA-OstapNeural\">";//
                string vietnameseFemale = "<voice name=\"vi-VN-HoaiMyNeural\">";//
                string vietnameseMale = "<voice name=\"vi-VN-NamMinhNeural\">";//



                System.Diagnostics.Debug.WriteLine(rate);
                System.Diagnostics.Debug.WriteLine(pitch);
                System.Diagnostics.Debug.WriteLine(volume);








                var synthesizer = new Microsoft.CognitiveServices.Speech.SpeechSynthesizer(config);

                string ssml0 = "<speak version=\"1.0\"";
                ssml0 += " xmlns=\"http://www.w3.org/2001/10/synthesis\"";
                if (style != "Normal") { ssml0 += " xmlns:mstts=\"https://www.w3.org/2001/mstts\""; }
                ssml0 += " xml:lang=\"en-US\">";

                switch (voice)
                {
                    case "Sara": ssml0 += sara; break;
                    case "Jenny": ssml0 += jenny; ; break;
                    case "Guy": ssml0 += guy; ; break;
                    case "Amber": ssml0 += amber; ; break;
                    case "Ana": ssml0 += ana; ; break;
                    case "Aria": ssml0 += aria; ; break;
                    case "Ashley": ssml0 += ashley; ; break;
                    case "Brandon": ssml0 += brandon; ; break;
                    case "Christopher": ssml0 += christopher; ; break;
                    case "Cora": ssml0 += cora; ; break;
                    case "Elizabeth": ssml0 += elizabeth; ; break;
                    case "Eric": ssml0 += eric; ; break;
                    case "Jacob": ssml0 += jacob; ; break;
                    case "Michelle": ssml0 += michelle; ; break;
                    case "Monica": ssml0 += monica; ; break;
                    case "Davis": ssml0 += davis; ; break;

                    case "Natasha (AU)": ssml0 += natashaAU; ; break;
                    case "William (AU)": ssml0 += williamAU; ; break;
                    case "Clara (CA)": ssml0 += claraCA; ; break;
                    case "Liam (CA)": ssml0 += liamCA; ; break;
                    case "Sonia (UK)": ssml0 += soniaUK; ; break;
                    case "Ryan (UK)": ssml0 += ryanUK; ; break;

                    case "Abbi (UK)": ssml0 += abbiUK; ; break;
                    case "Bella (UK)": ssml0 += bellaUK; ; break;
                    case "Hollie (UK)": ssml0 += hollieUK; ; break;
                    case "Olivia (UK)": ssml0 += oliviaUK; ; break;
                    case "Maisie (UK)": ssml0 += maisieUK; ; break;

                    case "Alfie (UK)": ssml0 += alfieUK; ; break;
                    case "Elliot (UK)": ssml0 += elliotUK; ; break;
                    case "Ethan (UK)": ssml0 += ethanUK; ; break;
                    case "Noah (UK)": ssml0 += noahUK; ; break;
                    case "Oliver (UK)": ssml0 += oliverUK; ; break;
                    case "Thomas (UK)": ssml0 += thomasUK; ; break;

                   


                    case "[Arabic] {Female} (Egypt)": ssml0 += arabicFemale_Egypt; ; break;
                    case "[Arabic] {Male} (Egypt)": ssml0 += arabicMale_Egypt; ; break;

                    case "[Chinese] {Female} (Mandarin, Simplified)": ssml0 += chineseFemale_MandarinSimple; ; break;
                    case "[Chinese] {Male} (Mandarin, Simplified)": ssml0 += chineseMale_MandarinSimple; ; break;
                    case "[Danish] {Female}": ssml0 += danishFemale; ; break;
                    case "[Danish] {Male}": ssml0 += danishMale; ; break;
                    case "[Dutch] {Female}": ssml0 += dutchFemale; ; break;
                    case "[Dutch] {Male}": ssml0 += dutchMale; ; break;


                    case "Brigitte [French] {Female}": ssml0 += brigitteFrench; ; break;
                    case "Jerome [French] {Male}": ssml0 += jeromeFrench; ; break;

                    case "Amala [German] {Female}": ssml0 += amalaGerman; ; break;
                    case "Christoph [German] {Male}": ssml0 += christophGerman; ; break;


                    case "[Hendi] {Female}": ssml0 += hendiFemale; ; break;
                    case "[Hendi] {Male}": ssml0 += hendiMale; ; break;
                    case "[Irish] {Female}": ssml0 += irishFemale; ; break;
                    case "[Irish] {Male}": ssml0 += irishMale; ; break;
                    case "[Italian] {Female}": ssml0 += italianFemale; ; break;
                    case "[Italian] {Male}": ssml0 += italianMale; ; break;
                    case "[Japanese] {Female}": ssml0 += japaneseFemale; ; break;
                    case "[Japanese] {Male}": ssml0 += japaneseMale; ; break;
                    case "[Korean] {Female}": ssml0 += koreanFemale; ; break;
                    case "[Korean] {Male}": ssml0 += koreanMale; ; break;
                    case "[Norwegian] {Female}": ssml0 += norwegianFemale; ; break;
                    case "[Norwegian] {Male}": ssml0 += norweigianMale; ; break;
                    case "[Polish] {Female}": ssml0 +=polishFemale ; ; break;
                    case "[Polish] {Male}": ssml0 += polishMale; ; break;
                    case "[Portuguese] {Female}": ssml0 += portugueseFemale; ; break;
                    case "[Portuguese] {Male}": ssml0 += portugueseMale; ; break;
                    case "[Russian] {Female}": ssml0 += russianFemale; ; break;
                    case "[Russian] {Male}": ssml0 += russianMale; ; break;

                    case "Dalia [Spanish] {Female} (Mexico)": ssml0 += daliaSpanish_Mexico; ; break;
                    case "Jorge [Spanish] {Male} (Mexcio)": ssml0 += jorgeSpanish_Mexico; ; break;

                    case "[Swedish] {Female}": ssml0 += swedishFemale; ; break;
                    case "[Swedish] {Male}": ssml0 += swedishMale; ; break;
                    case "[Thai] {Female}": ssml0 += thaiFemale; ; break;
                    case "[Thai] {Male}": ssml0 += thaiMale; ; break;
                    case "[Ukrainian] {Female}": ssml0 += ukranianFemale; ; break;
                    case "[Ukrainian] {Male}": ssml0 += ukranianMale; ; break;
                    case "[Vietnamese] {Female}": ssml0 += vietnameseFemale; ; break;
                    case "[Vietnamese] {Male}": ssml0 +=vietnameseMale ; ; break;





                    default: ssml0 += "<voice name=\"en-US-SaraNeural\">"; break;
                }

                if (style != "Normal")
                {

                    if (style == "Angry") { ssml0 += angry; }
                    if (style == "Happy") { ssml0 += happy; }
                    if (style == "Sad") { ssml0 += sad; }
                    if (style == "Chat") { ssml0 += chat; }
                    if (style == "Customer Service") { ssml0 += customerservice; }
                    if (style == "Empathetic") { ssml0 += empathetic; }
                    if (style == "Narration (Professional)") { ssml0 += narrationProf; }
                    if (style == "Newscast (Casual)") { ssml0 += newscastCas; }
                    if (style == "Newscast (Formal)") { ssml0 += newscastForm; }
                    if (style == "Newscast") { ssml0 += newscast; }
                    if (style == "Assistant") { ssml0 += assistant; }

                }
                if (rate != "default")
                {
                    if (rate == "x-slow") { ssml0 += ratexslow; }
                    if (rate == "slow") { ssml0 += rateslow; }
                    if (rate == "medium") { ssml0 += ratemedium; }
                    if (rate == "fast") { ssml0 += ratefast; }
                    if (rate == "x-fast") { ssml0 += ratexfast; }

                }
                if (pitch != "default")
                {
                    if (pitch == "x-low") { ssml0 += pitchxlow; }
                    if (pitch == "low") { ssml0 += pitchlow; }
                    if (pitch == "medium") { ssml0 += pitchmedium; }
                    if (pitch == "high") { ssml0 += pitchhigh; }
                    if (pitch == "x-high") { ssml0 += pitchxhigh; }

                }
                if (volume != "default")
                {
                    if (volume == "x-soft") { ssml0 += volumexlow; }
                    if (volume == "soft") { ssml0 += volumelow; }
                    if (volume == "medium") { ssml0 += volumemedium; }
                    if (volume == "loud") { ssml0 += volumehigh; }
                    if (volume == "x-loud") { ssml0 += volumexhigh; }

                }


                ssml0 += text;
                if (rate != "default") { ssml0 += "</prosody>"; }
                if (pitch != "default") { ssml0 += "</prosody>"; }
                if (volume != "default") { ssml0 += "</prosody>"; }

                if (style != "Normal") { ssml0 += "</mstts:express-as>"; }
                ssml0 += "</voice>";
                ssml0 += "</speak>";

                System.Diagnostics.Debug.WriteLine(ssml0);
                await synthesizer.SpeakSsmlAsync(ssml0);
            
            
               
            
                //using var result = await synthesizer.SpeakSsmlAsync(ssml0);

          }
          catch (Exception ex)
          {
                MessageBox.Show("No valid subscription key given or speech service has been disabled");

            }



        }
       
    }
}