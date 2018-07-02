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
    public partial class Form2 : Form
    {
        public string patch = "";
        public bool Form1Start = false;

        public Form2()
        {
            InitializeComponent();

            FileStream file = new FileStream("resources/list.txt", FileMode.Open);
            StreamReader read = new StreamReader(file);

            while (!read.EndOfStream)
            {
                comboBox1.Items.Add(read.ReadLine());
            }

            read.Close();
            file.Close();

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
            patch = "resources/"+selectedState;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.patch = patch;
            Form1.form2.Close();
        }
    }
}