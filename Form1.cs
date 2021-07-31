using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace ZoomPad
{
    public partial class Form1 : Form
    {
        string namefile;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        public void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string FileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = FileText;
            string textform = "ZoomPad - " + filename;
            namefile = filename;
            this.Text = textform;
        }
        public void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(namefile, textBox1.Text);
        }
        private void openFileDialog1_FileOk(object sender, EventArgs e)
        {

        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) 
            {
                string filename = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(filename, textBox1.Text);
                string textform = "ZoomPad - " + filename;
                this.Text = textform;
                namefile = filename;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            string language = System.IO.File.ReadAllText("language.txt");
            if (language == "RU")
            {
                string line = "Строка: ";
                int intcurrentLine = textBox1.GetLineFromCharIndex(textBox1.GetFirstCharIndexOfCurrentLine());
                string currentline = line + intcurrentLine;
                label2.Text = currentline;
            }
            else if (language == "USA")
            {
                string line = "Line: ";
                int intcurrentLine = textBox1.GetLineFromCharIndex(textBox1.GetFirstCharIndexOfCurrentLine());
                string currentline = line + intcurrentLine;
                label2.Text = currentline;
            }
            else
            {
                int intcurrentLine = textBox1.GetLineFromCharIndex(textBox1.GetFirstCharIndexOfCurrentLine());
                string currentline = "Строка: " + intcurrentLine;
                label2.Text = currentline;
            }
            
        }
        private void rUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText("language.txt", "");
            System.IO.File.WriteAllText("language.txt", "RU");

        }

        private void uSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText("language.txt", "");
            System.IO.File.WriteAllText("language.txt", "USA");
            файлToolStripMenuItem.Text = "File";
            сохранитьToolStripMenuItem.Text = "Save";
            сохранитьКакToolStripMenuItem.Text = "Save as...";
            настройкиToolStripMenuItem.Text = "Settings";
            языкиToolStripMenuItem.Text = "Languages";
            открытьToolStripMenuItem.Text = "Open";
            label2.Text = "Line: ";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string language = System.IO.File.ReadAllText("language.txt");
            if (language == "USA")
            {
                файлToolStripMenuItem.Text = "File";
                сохранитьToolStripMenuItem.Text = "Save";
                сохранитьКакToolStripMenuItem.Text = "Save as...";
                настройкиToolStripMenuItem.Text = "Settings";
                языкиToolStripMenuItem.Text = "Languages";
                открытьToolStripMenuItem.Text = "Open";
                label2.Text = "Line: ";
            }
        }

        private void запуститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(namefile, textBox1.Text);
            Process.Start(namefile);
        }
    }
}
