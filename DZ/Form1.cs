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

namespace DZ
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
            //Если слово для поиска не пусто 
            if (!string.IsNullOrWhiteSpace(word) && List.Count > 0)
            {
                if (!int.TryParse(this.distanceNum.Text.Trim(), out int distanceNum))
                {
                    MessageBox.Show("Необходимо указать максимальное расстояние");
                    return;
                }

                if (distanceNum < 1 || distanceNum > 6)
                {
                    MessageBox.Show("Максимальное расстояние должно быть в диапазоне от 1 до 6");
                    return;
                }

                int ThreadCount;
                if (!int.TryParse(this.textBox_threads.Text.Trim(), out ThreadCount))
                {
                    MessageBox.Show("Необходимо указать количество потоков");
                    return;
                }
                bool isDamerau = checkBox_Damerau.Checked;
                Stopwatch t = new Stopwatch();
                t.Start();
                //-------------------------------------------------
                // Начало параллельного поиска
                //-------------------------------------------------

                //Результирующий список  
                List<ParallelSearchResult> Result = new List<ParallelSearchResult>();

                //Деление списка на фрагменты для параллельного запуска в потоках
                List<MinMax> arrayDivList = SubArrays.DivideSubArrays(0, list.Count, ThreadCount);
                int count = arrayDivList.Count;

                //Количество потоков соответствует количеству фрагментов массива
                Task<List<ParallelSearchResult>>[] tasks = new Task<List<ParallelSearchResult>>[count];

                //Запуск потоков
                for (int i = 0; i < count; i++)
                {
                    //Создание временного списка, чтобы потоки не работали параллельно с одной коллекцией
                    List<string> tempTaskList = list.GetRange(arrayDivList[i].Min, arrayDivList[i].Max - arrayDivList[i].Min);

                    tasks[i] = new Task<List<ParallelSearchResult>>(
                        //Метод, который будет выполняться в потоке
                        ArrayThreadTask,
                        //Параметры потока 
                        new ParallelSearchThreadParam()
                        {
                            tempList = tempTaskList,
                            maxDist = distanceNum,
                            ThreadNum = i,
                            wordPattern = word,
                            IsDamerau = isDamerau
                        });

                    //Запуск потока
                    tasks[i].Start();
                }

                Task.WaitAll(tasks);

                t.Stop();

                //Объединение результатов
                for (int i = 0; i < count; i++)
                {
                    Result.AddRange(tasks[i].Result);
                }

                //-------------------------------------------------
                // Завершение параллельного поиска
                //-------------------------------------------------

                t.Stop();

                //Вывод результатов

                //Время поиска
                this.textBox_search_time.Text = t.Elapsed.ToString();

                //Вычисленное количество потоков
                this.textBoxThreadCountAll.Text = count.ToString();

                //Начало обновления списка результатов
                this.listBox_result.BeginUpdate();

                //Очистка списка
                this.listBox_result.Items.Clear();

                //Вывод результатов поиска 
                foreach (var x in Result)
                {
                    string temp = x.word + " (расстояние=" + x.dist.ToString() + " поток=" + x.ThreadNum.ToString() + ")";
                    this.listBox_result.Items.Add(temp);
                }

                //Окончание обновления списка результатов
                this.listBox_result.EndUpdate();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");
            }
        }
        /// <summary>
        /// Выполняется в параллельном потоке для поиска строк
        /// </summary>
        public static List<ParallelSearchResult> ArrayThreadTask(object paramObj)
        {
            ParallelSearchThreadParam param = (ParallelSearchThreadParam)paramObj;

            //Слово для поиска в верхнем регистре
            string wordUpper = param.wordPattern.Trim().ToUpper();

            //Результаты поиска в одном потоке
            List<ParallelSearchResult> Result = new List<ParallelSearchResult>();

            //Перебор всех слов во временном списке данного потока 
            foreach (string str in param.tempList)
            {
                //Вычисление расстояния Дамерау-Левенштейна
                int dist = EditDistance.Distance(str.ToUpper(), wordUpper, param.IsDamerau);

                //Если расстояние меньше порогового, то слово добавляется в результат
                if (dist <= param.maxDist)
                {
                    ParallelSearchResult temp = new ParallelSearchResult()
                    {
                        word = str,
                        dist = dist,
                        ThreadNum = param.ThreadNum
                    };

                    Result.Add(temp);
                }
            }
            return Result;
        }
        private void button_simple_search_Click(object sender, EventArgs e)
        {
            //Слово для поиска 
            string word = this.textBox_search.Text.Trim();
            //Если слово для поиска не пусто 
            if (!string.IsNullOrWhiteSpace(word) && List.Count > 0)
            {
                //Слово для поиска в верхнем регистре 
                string wordUpper = word.ToUpper();
                //Временные результаты поиска 
                List<string> tempList = new List<string>();
                Stopwatch t = new Stopwatch();
                t.Start();
                foreach (string str in List)
                {
                    if (str.ToUpper().Contains(wordUpper))
                    {
                        tempList.Add(str);
                    }
                }
                t.Stop();
                this.textBox_simple_time.Text = t.Elapsed.ToString();
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
                MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox_search_time_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSaveReport_Click(object sender, EventArgs e)
        {
            //Имя файла отчета
            string TempReportFileName = "Report_" + DateTime.Now.ToString("dd_MM_yyyy_hhmmss");

            //Диалог сохранения файла отчета
            SaveFileDialog fd = new SaveFileDialog();
            fd.FileName = TempReportFileName;
            fd.DefaultExt = ".txt";
            fd.Filter = "текстовые файлы|*.txt";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string ReportFileName = fd.FileName;
                StringBuilder b = new StringBuilder();
                b.AppendLine("Отчет: " + ReportFileName + "\n\n\n");
                b.AppendLine("Время чтения из файла: ");
                b.AppendLine("\t" + this.textBox_time.Text + "\n\n");

                b.AppendLine("Количество уникальных слов в файле: ");
                b.AppendLine("\t" + this.textBox_words.Text + "\n\n");

                b.AppendLine("Слово для поиска: ");
                b.AppendLine("\t" + this.textBox_search.Text + "\n\n");

                b.AppendLine("Максимальное расстояние для нечеткого поиска: ");
                b.AppendLine("\t" + this.distanceNum.Text + "\n\n");

                b.AppendLine("Время четкого поиска: ");
                b.AppendLine("\t" + this.textBox_simple_time.Text + "\n\n");

                b.AppendLine("Время нечеткого поиска");
                b.AppendLine("\t" + this.textBox_search_time.Text + "\n\n");

                b.AppendLine("Результаты поиска:");
                foreach (var x in this.listBox_result.Items)
                {
                    b.AppendLine("\t" + x.ToString());
                }

                //Сохранение файла
                File.AppendAllText(ReportFileName, b.ToString());

                MessageBox.Show("Отчет сформирован. Файл: " + ReportFileName);
            }
        }
    }
}
