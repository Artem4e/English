using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace English
{
    class Dictionary
    {
        List<string> RusWords = new List<string>();
        List<string> EngWords = new List<string>();

        public Dictionary(string path)
        {

            List<string> AllWords = new List<string>();

            FileStream file = new FileStream(path, FileMode.Open);
            StreamReader stream = new StreamReader(file);
            while (!stream.EndOfStream)
            {
                AllWords.Add(stream.ReadLine().ToLower());
            }
            fillingOutLists(AllWords);
            file.Close();
        }

        //Длина списка
        public int leng()
        {
            return RusWords.Count;
        }

        //Добавление слова в список при ошибке
        public void addWord(int i)
        {
            RusWords.Add(RusWords[i]);
            EngWords.Add(EngWords[i]);
        }

        //Удаление слова из списка при правильном ответе
        public void deleteWord(int i)
        {
            RusWords.RemoveAt(i);
            EngWords.RemoveAt(i);
        }

        public string outR(int i)
        {
            return RusWords[i];
        }

        public string outE(int i)
        {
            return EngWords[i];
        }

        //Заполнение списков с Русскими и Английскими словами
        private void fillingOutLists(List<string> AllWords)
        {
            string PatternRus = @"%(\D+)+$";
            string PatternEng = @"^(\D+)+%";
            Regex regexRus = new Regex(PatternRus);
            Regex regexEng = new Regex(PatternEng);

            for (int i = 0; i < AllWords.Count; i++)
            {
                foreach (Match RusMatch in regexRus.Matches(AllWords[i]))
                {
                    RusWords.Add(RusMatch.Groups[1].Value);
                }

                foreach (Match EngMatch in regexEng.Matches(AllWords[i]))
                {
                    EngWords.Add(EngMatch.Groups[1].Value);
                }
            }
        }

    }
}
