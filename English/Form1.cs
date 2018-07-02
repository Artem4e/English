using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace English
{
    public partial class Form1 : Form
    {
        public static Form2 form2;

        int Index;
        int RightAnswer = 0;
        int FalseAnswer = 0;
        public static string patch;

        public Form1()
        {
            InitializeComponent();
        }

        Dictionary dictionary;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void selectAtopic_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            label1.Text = "Всего слов:";
            label2.Text = "Правильно: ";
            label3.Text = "Неправильно: ";
            label4.Text = "Осталось слов: ";

            form2.ShowDialog();
            dictionary = new Dictionary(form2.patch);
            Index = outWord();
            label1.Text = "Всего слов: " + dictionary.leng().ToString();
            label4.Text = "Осталось слов: " + dictionary.leng().ToString();
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (testWord(Index, textBoxAnswer.Text.ToLower()))
                    {
                        dictionary.deleteWord(Index);
                        RightAnswer++;
                        label2.Text = "Правильно: " + RightAnswer;
                    }
                    else
                    {
                        dictionary.addWord(Index);
                        FalseAnswer++;
                        label3.Text = "Неправильно: " + FalseAnswer;
                    }
                    label4.Text = "Осталось слов: " + dictionary.leng().ToString();

                    textBoxAnswer.Clear();
                    labelQuestion.Text = "";

                    if (dictionary.leng() > 0)
                    {
                        outWord();
                    }
                    else MessageBox.Show("Все слова введены верно");
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите не пустой файл!", "Ошибка!");
                }
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Сначала выберите тему");
            }

}

        //Вывод слова
        public int outWord()
        {
            try
            {
                Random random = new Random();
                Index = random.Next(0, dictionary.leng() - 1);

                labelQuestion.Text = dictionary.outE(Index);
                return Index;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Файл пуст!", "Ошибка!");
                return 0;
            }
        }

        //Проверка правильности введенного слова
        public bool testWord(int i, string word)
        {
            if (dictionary.outR(i) == word) return true;
            else return false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputWords input = new InputWords();
            input.ShowDialog();
        }
    }
}
