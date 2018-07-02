using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace English
{
    public partial class InputWords : Form
    {
        string Words = "";
        public InputWords()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text += textBox1.Text + "%" + textBox2.Text+"\r\n";
            Words += textBox4.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Words != "")
            {
                if (textBox3.Text != "")
                {
                    try
                    {
                        FileStream file = new FileStream("resources/" + textBox3.Text, FileMode.Open);
                        //Проверяем, есть ли файл с таким названием
                        file.Close();
                        MessageBox.Show("Файл с таким названием уже существует.", "Ошибка!");
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        FileStream file = new FileStream("resources/" + textBox3.Text, FileMode.Create);
                        StreamWriter write = new StreamWriter(file);
                        write.Write(Words);
                        write.Close();
                        file.Close();

                        file = new FileStream("resources/list.txt", FileMode.Append);
                        write = new StreamWriter(file);
                        write.WriteLine(textBox3.Text);
                        write.Close();
                        file.Close();

                        MessageBox.Show("Файл сохранен");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                    }
                }
                else MessageBox.Show("Введите название!", "Ошибка!");
            }
            else MessageBox.Show("Файл пустой!", "Ошибка!");
        }
    }
}
