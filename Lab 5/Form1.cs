using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    private List<String> list;
    public List<string> List { get => list; set => list = value; }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void Open_file_button_Click(object sender, EventArgs e)
    {
        List = new List<string>();
        OpenFileDialog fd = new OpenFileDialog();
        fd.Filter = "текстовые файлы|*.txt";
        if (fd.ShowDialog() == DialogResult.OK)
        {

            Stopwatch t = new Stopwatch();
            t.Start();
            //Чтение файла в виде строки 
            string text = File.ReadAllText(fd.FileName);
            //Разделительные символы для чтения из файла 
            char[] separators =
            new char[] { ';', ' ', '.', ',', '!', '?', '/', '\t', '\n', '\r' };
            string[] textArray = text.Split(separators);
            foreach (string strTemp in textArray)
            {
                //Удаление пробелов в начале и конце строки 
                string str = strTemp.Trim();
                //Добавление строки в список, если строка не содержится в списке 
                if (str.Length > 0 && str != "-" && !List.Contains(str)) List.Add(str);
            }

            t.Stop();
            this.textBox_time.Text = t.Elapsed.ToString();
            this.textBox_words.Text = List.Count.ToString();
            //foreach (var x in List) Console.WriteLine(x);
        }
        else
        {
            MessageBox.Show("Необходимо выбрать файл");
        }
    }
    private void button_search_word_Click(object sender, EventArgs e)
    {
        //Слово для поиска 
        string word = this.textBox_search.Text.Trim();
        int.TryParse(this.distanceNum.Text.Trim(), out int distanceNum);
        //Если слово для поиска не пусто 
        if (!string.IsNullOrWhiteSpace(word) && List.Count > 0 && distanceNum > 0)
        {
            //Слово для поиска в верхнем регистре 
            string wordUpper = word.ToUpper();
            //Временные результаты поиска 
            List<string> tempList = new List<string>();
            bool isDamerau = checkBox_Damerau.Checked; 
            Stopwatch t = new Stopwatch();
            t.Start();
            foreach (string str in List)
            {
                int dist = Program.Distance(str.ToUpper(), wordUpper, isDamerau);
                if ( dist < distanceNum) {
                    string distOut = "\tрасстояние: " + dist;
                    tempList.Add(str+distOut);
                }
            }
            t.Stop();
            this.textBox_search_time.Text = t.Elapsed.ToString();
            this.listBox_result.BeginUpdate();
            //Очистка списка 
            this.listBox_result.Items.Clear();
            //Вывод результатов поиска 
            foreach (string str in tempList)
            {
                this.listBox_result.Items.Add(str);
            }
            this.listBox_result.EndUpdate();
        }
        else
        {
            MessageBox.Show("Необходимо выбрать файл, ввести слово для поиска, указать расстояние");
        }
    }

        
    }
}
